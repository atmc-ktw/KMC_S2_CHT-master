using System;
using System.Threading;

using ACom;
using Atmc;

namespace ADrv
{
    class AClientSocketPlcSiemens : AClientSocket
    {
        // 2014.12.21
        private const int _RETRY_RECEIVE = 7;
        // 2014.12.21
		public const int _RESPONSE_DELAY = 100;

        // 2015.04.08 마cto 3000->1000->500
        public const int _RESPONSE_TIME = 500;
        public const int _MAX_BUFFER = 256;

        public struct _stCfgSocketPlcSiemens
        {
            public int nORG;
            public int nDBNR;
            public int nStart;
            public int nLen;
        }

        private _stCfgSocketPlcSiemens m_stCfgRead;
        private _stCfgSocketPlcSiemens m_stCfgWrite;

        public int[] m_pnDataRead = new int[_MAX_BUFFER];
        public int[] m_pnDataWrite = new int[_MAX_BUFFER];

        public AClientSocketPlcSiemens(int nID, IntPtr hParent)
            : base(nID, hParent)
        {
            LoadIni("ClientSocketPlcSiemens" + m_nID.ToString());
        }		
        
		//public int Fetch(_stCfgSocketPlcSiemens stCfg)
        public int ReadPlc(_stCfgSocketPlcSiemens stCfg)
        {
            byte[] pbyBuff = new byte[255];
            int nR;

            m_stCfgRead = stCfg;

			pbyBuff[0] = (byte)'S';
            pbyBuff[1] = (byte)'5';
            pbyBuff[2] = (byte)16;
            pbyBuff[3] = (byte)1;
            pbyBuff[4] = (byte)3;
            pbyBuff[5] = (byte)5;
            pbyBuff[6] = (byte)3;
            pbyBuff[7] = (byte)8;
            pbyBuff[8] = (byte)m_stCfgRead.nORG;
            pbyBuff[9] = (byte)m_stCfgRead.nDBNR;
            pbyBuff[10] = (byte)((m_stCfgRead.nStart >> 8) & 0xFF);
            pbyBuff[11] = (byte)((m_stCfgRead.nStart >> 0) & 0xFF);
            pbyBuff[12] = (byte)((m_stCfgRead.nLen >> 8) & 0xFF);
            pbyBuff[13] = (byte)((m_stCfgRead.nLen >> 0) & 0xFF);
            pbyBuff[14] = 0xFF;
            pbyBuff[15] = (byte)2;

            // 2011.04.30 마cto
            ClearBuffer();
            nR = Send(pbyBuff, 16, _RESPONSE_TIME);

            if (nR == 1)
            {
                // 2014.12.21
                for (int i = 0; i < _RETRY_RECEIVE; i++)
                {
                    nR = FetchResponse(_RESPONSE_TIME);

                    if (nR == 0)
                    {
                        return 1;
                    }
                    // 2015.04.13
                    Thread.Sleep(_RESPONSE_DELAY);
                    //AUtil.Delay(_RESPONSE_DELAY, true);
                }

                nR *= 10;
            }

            return nR;
        }

        private int FetchResponse(int nTime)
        {
            byte[] pbyBuff = new byte[2048 + 16];
            int nR = 0, nLen;

            nR = Receive(ref pbyBuff, nTime);
            
            if (nR <= 0)
            {
                return -1;
            }

            if (pbyBuff[5] == 6 && nR > 16)
            {
                nR = pbyBuff[8];

                if (nR == 0)
                {
                    if (m_stCfgRead.nORG != 1)
                    {
                        nLen = m_stCfgRead.nLen;

                        for (int i = 0; i < nLen; i++)
                        {
                            m_pnDataRead[i] = pbyBuff[i + 16];
                        }
                    }
                    else // DB
                    {
                        nLen = m_stCfgRead.nLen * 2;

                        for (int i = 0; i < nLen; i += 2)
                        {
                            m_pnDataRead[i / 2] = 0;
                            m_pnDataRead[i / 2] |= ((int)(pbyBuff[i + 16 + 0]) << 8);
                            m_pnDataRead[i / 2] |= ((int)(pbyBuff[i + 16 + 1]) << 0);
                        }
                    }
                }

                return nR;  // 0일때 OK
            }
            else
            {
                return -2;
            }
        }

   

        //public int Write(_stCfgSocketPlcSiemens stCfg)
        public int WritePlc(_stCfgSocketPlcSiemens stCfg)
        {
            byte[] pbyBuff = new byte[2048 + 16];
            int nLen, nR;

            m_stCfgWrite = stCfg;

            pbyBuff[0] = (byte)'S';
            pbyBuff[1] = (byte)'5';
            pbyBuff[2] = (byte)16;
            pbyBuff[3] = (byte)1;
            pbyBuff[4] = (byte)3;
            pbyBuff[5] = (byte)3;
            pbyBuff[6] = (byte)3;
            pbyBuff[7] = (byte)8;
            pbyBuff[8] = (byte)m_stCfgWrite.nORG;
            pbyBuff[9] = (byte)m_stCfgWrite.nDBNR;
            pbyBuff[10] = (byte)((m_stCfgWrite.nStart >> 8) & 0xFF);
            pbyBuff[11] = (byte)((m_stCfgWrite.nStart >> 0) & 0xFF);
            pbyBuff[12] = (byte)((m_stCfgWrite.nLen >> 8) & 0xFF);
            pbyBuff[13] = (byte)((m_stCfgWrite.nLen >> 0) & 0xFF);
            pbyBuff[14] = 0xFF;
            pbyBuff[15] = (byte)2;

            nLen = m_stCfgWrite.nLen;

            if (m_stCfgWrite.nORG != 1)
            {
                for (int i = 0; i < nLen; i++)
                {
                    pbyBuff[i + 16] = (byte)m_pnDataWrite[i];
                }
            }
            else
            {
                nLen *= 2;
                for (int i = 0; i < nLen; i += 2)
                {
                    pbyBuff[i + 16 + 0] = (byte)((m_pnDataWrite[i / 2] >> 8) & 0xFF);
                    pbyBuff[i + 16 + 1] = (byte)((m_pnDataWrite[i / 2] >> 0) & 0xFF);
                }
            }

            // 2011.04.30 마cto
            ClearBuffer();
            nR = Send(pbyBuff, 16 + nLen, _RESPONSE_TIME);

            if (nR == 1)
            {
                // 2014.12.21
                for (int i = 0; i < _RETRY_RECEIVE; i++)
                {
                    nR = WriteAcknowledgement(_RESPONSE_TIME);

                    if (nR == 0)
                    {
                        return 1;
                    }
                    // 2015.04.13
                    Thread.Sleep(_RESPONSE_DELAY);
                    //AUtil.Delay(_RESPONSE_DELAY, true);
                }

                nR *= 10;
            }

            return nR;
        }
        
        private int WriteAcknowledgement(int nTime)
        {
            byte[] pbyBuff = new byte[2048 + 16];
            int nR;

            nR = Receive(ref pbyBuff, nTime);

            if (nR < 0)
            {
                return -1;
            }

            if (pbyBuff[5] == 4 && nR == 16)
            {
                nR = pbyBuff[8];
				return nR; // 0일때 OK
            }
            else
            {
                return -2;
            }
        }



        public static int ChangeLH(int nVal)
        {
            int nL, nH, nR;

            nL = ((nVal >> 0) & 0xFF);
            nH = ((nVal >> 8) & 0xFF);
            nR = ((nL << 8) | nH);

            return nR;
        }
    }
}
