#define _USE_PC_RUN
using System;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using System.Net.NetworkInformation;
using ADrv;
using Atmc;
#if _USE_PC_RUN
using AVisionPro;
#endif
namespace ACom
{
    struct _stStartAddress
    {
        public int nDB;
        public int nDW;
    }

    class AThrdClientSocketPlcSiemens
    {
        // 2011.04.28 
        public const int _RETRY = 3;

		public const int _WM_SOCKET_FETCH_OK = ASDef._WM_USER + 140;
		public const int _WM_SOCKET_FETCH_NG = ASDef._WM_USER + 141;
		public const int _WM_SOCKET_WRITE_OK = ASDef._WM_USER + 142;
		public const int _WM_SOCKET_WRITE_NG = ASDef._WM_USER + 143;
		public const int _WM_PLC_RECONNECT = ASDef._WM_USER + 144;

		private AClientSocketPlcSiemens m_AClientSocketPlcSiemensFetch = null;
		private AClientSocketPlcSiemens m_AClientSocketPlcSiemensWrite = null;
        
		private int[] m_pnDI = new int[ASDef._MAX_PLC_DI];
		private int[] m_pnDO = new int[ASDef._MAX_PLC_DO];

        // 2015.02.25
		//private int[] m_pnOldDI = new int[ASDef._MAX_PLC_DI];

		private int[] m_pnOldDO = new int[ASDef._MAX_PLC_DO];

        public _stStartAddress m_stReadAddress;
        public _stStartAddress m_stWriteAddress;

        public static IntPtr m_hParent;
        public Thread m_Thrd = null;
		private bool m_bStop = false;
        private int m_nDelayTime = 0;
		public int m_nID;

        //2014.08.10
        private bool m_bReConnecting = false;

        // 2015.03.01
        public int m_nReadCount = 0;
        
        public AThrdClientSocketPlcSiemens(int nID, IntPtr hParent)
        {
            m_nID = nID;
            m_hParent = hParent;

            for (int i = 0; i < ASDef._MAX_PLC_DI; i++)
            {
                // 2015.02.25
                //m_pnOldDI[i] = m_pnDI[i] = 0;
                m_pnDI[i] = 0;

            }
            for (int i = 0; i < ASDef._MAX_PLC_DO; i++)
            {
                m_pnOldDO[i] = m_pnDO[i] = 0;
            }

			m_bStop = false;

            LoadIni("ThrdClientSocketPlcSiemens" + m_nID.ToString(), ASDef._INI_FILE);

            m_AClientSocketPlcSiemensFetch = new AClientSocketPlcSiemens(m_nID, m_hParent);
			m_AClientSocketPlcSiemensFetch.LoadIni("ClientSocketPlcSiemensFetch" + m_nID.ToString());
            m_AClientSocketPlcSiemensWrite = new AClientSocketPlcSiemens(m_nID, m_hParent);
			m_AClientSocketPlcSiemensWrite.LoadIni("ClientSocketPlcSiemensWrite" + m_nID.ToString());
        }

        public void Init()
        {
            // 2013.04.04
            Ping ping = new Ping();
            // 2014.08.26
            PingReply pr = null;
            try
            {
                pr = ping.Send(m_AClientSocketPlcSiemensFetch.m_strIP);
            }
            catch
            {   
            }
            if (pr != null)
            {
                if (pr.Status == IPStatus.Success)
                {
                    if (m_AClientSocketPlcSiemensFetch.Connect() == false)
                    {
                        // 2014.07.15
                        AUtil.TopMostMessageBox.Show("ClientSocketPlcSiemensFetch" + m_nID.ToString() + " Socket Connect Error!");
                    }

                    if (m_AClientSocketPlcSiemensWrite.Connect() == false)
                    {
                        // 2014.07.15
                        AUtil.TopMostMessageBox.Show("ClientSocketPlcSiemensWrite" + m_nID.ToString() + " Socket Connect Error!");
                    }
                }
                else
                {
                    m_AClientSocketPlcSiemensFetch.m_bConnect = false;
                    m_AClientSocketPlcSiemensWrite.m_bConnect = false;

                    // 2014.07.15
                    AUtil.TopMostMessageBox.Show("Ping Error " + m_AClientSocketPlcSiemensFetch.m_strIP);
                }
            }
            else
            {
                m_AClientSocketPlcSiemensFetch.m_bConnect = false;
                m_AClientSocketPlcSiemensWrite.m_bConnect = false;
                AUtil.TopMostMessageBox.Show("PLC Not Connect!");
            }

			if (m_AClientSocketPlcSiemensFetch.m_bConnect && m_AClientSocketPlcSiemensWrite.m_bConnect)
			{
				m_Thrd = new Thread(new ThreadStart(Run));
				m_Thrd.Start();
			}
        }

        public void LoadIni(string strName, string strIni)
        {
            m_nDelayTime = AUtil.GetPrivateProfileInt(strName, "Delay", 200, strIni);
            m_stReadAddress.nDB = AUtil.GetPrivateProfileInt(strName, "Read_DB", 100, strIni);
            m_stReadAddress.nDW = AUtil.GetPrivateProfileInt(strName, "Read_DW", 0, strIni);
            m_stWriteAddress.nDB = AUtil.GetPrivateProfileInt(strName, "Write_DB", 101, strIni);
            m_stWriteAddress.nDW = AUtil.GetPrivateProfileInt(strName, "Write_DW", 0, strIni);
        }

		public int GetWordDO(int nAddress) { return m_pnDO[nAddress]; }
		public int GetWordOldDO(int nAddress) { return m_pnOldDO[nAddress]; }
		public int GetWordDI(int nAddress) { return m_pnDI[nAddress]; }
        // 2015.02.25
		//public int GetWordOldDI(int nAddress) { return m_pnOldDI[nAddress]; }


        public int SetBitDO(int nAddress, int n, bool bVal)
        {
            int nR = -1;
            int nTemp;

            lock(m_AClientSocketPlcSiemensWrite)
			{
                // 2014.10.09
                nTemp = m_pnOldDO[nAddress];
                m_pnOldDO[nAddress] = m_pnDO[nAddress];

                if (bVal == true)
                {
                    m_pnDO[nAddress] |= (1 << n);
                }
                else
                {
                    m_pnDO[nAddress] &= (0xFFFF ^ (1 << n));
                }
                AClientSocketPlcSiemens._stCfgSocketPlcSiemens stCfg;
                stCfg = new AClientSocketPlcSiemens._stCfgSocketPlcSiemens();
                stCfg.nORG = 1;
                stCfg.nDBNR = m_stWriteAddress.nDB;
                stCfg.nStart = m_stWriteAddress.nDW * 2 + nAddress * 2;
                stCfg.nLen = 1;
                
                m_AClientSocketPlcSiemensWrite.m_pnDataWrite[0] = m_pnDO[nAddress];
                
                // 2011.04.28
                for (int i = 0; i < _RETRY; i++)
                {
                    nR = m_AClientSocketPlcSiemensWrite.WritePlc(stCfg);
                    if (nR == 1)
                        break;
                }
			}
            if (nR == 1)
            {
				AUtil.PostMessage(m_hParent, _WM_SOCKET_WRITE_OK, 0, m_nID);

                /* 2015.02.25
                if (m_pnOldDO[nAddress] != m_pnDO[nAddress])
                {
					AUtil.PostMessage(m_hParent, ASDef._WM_CHANGE_DO + m_nID, nAddress, m_pnDO[nAddress]);
                }
                */
            }
            else
            {
                m_pnDO[nAddress] = m_pnOldDO[nAddress];
                m_pnOldDO[nAddress] = nTemp;

                AUtil.PostMessage(m_hParent, _WM_SOCKET_WRITE_NG, nR, m_nID);
            }

            return nR;
        }

        public int SetWordDO(int nAddress, int nVal)
        {
            int nR = -1;
            int nTemp;
            
			lock (m_AClientSocketPlcSiemensWrite)
			{
                // 2014.10.09
                nTemp = m_pnOldDO[nAddress];
                m_pnOldDO[nAddress] = m_pnDO[nAddress];
                m_pnDO[nAddress] = nVal;

                AClientSocketPlcSiemens._stCfgSocketPlcSiemens stCfg;
                stCfg = new AClientSocketPlcSiemens._stCfgSocketPlcSiemens();
                stCfg.nORG = 1;
                stCfg.nDBNR = m_stWriteAddress.nDB;
                stCfg.nStart = m_stWriteAddress.nDW * 2 + nAddress * 2;
                stCfg.nLen = 1;

                
                m_AClientSocketPlcSiemensWrite.m_pnDataWrite[0] = m_pnDO[nAddress];
                // 2011.04.28
                for (int i = 0; i < _RETRY; i++)
                {
                    nR = m_AClientSocketPlcSiemensWrite.WritePlc(stCfg);
                    if (nR == 1)
                        break;
                }
			}
            if (nR == 1)
            {
				AUtil.PostMessage(m_hParent, _WM_SOCKET_WRITE_OK, 0, m_nID);

                /* 2015.02.25
                if (m_pnOldDO[nAddress] != m_pnDO[nAddress])
                {
                    // 2012.12.03
                    //AUtil.SendMessage(m_hParent, ASDef._WM_CHANGE_DO + m_nID, nAddress, m_pnDO[nAddress]);
					AUtil.PostMessage(m_hParent, ASDef._WM_CHANGE_DO + m_nID, nAddress, m_pnDO[nAddress]);
                }
                */
            }
            else
            {
                m_pnDO[nAddress] = m_pnOldDO[nAddress];
                m_pnOldDO[nAddress] = nTemp;

				AUtil.PostMessage(m_hParent, _WM_SOCKET_WRITE_NG, nR, m_nID);
            }

            return nR;
        }

        public int SetWordDOLen(int nStartAddress, int nLen, int[] pnVal)
        {
            int nR = -1;
            
			lock (m_AClientSocketPlcSiemensWrite)
			{
                // 2014.10.09
                AClientSocketPlcSiemens._stCfgSocketPlcSiemens stCfg;
                stCfg = new AClientSocketPlcSiemens._stCfgSocketPlcSiemens();
                stCfg.nORG = 1;
                stCfg.nDBNR = m_stWriteAddress.nDB;
                stCfg.nStart = m_stWriteAddress.nDW * 2 + nStartAddress * 2;
                stCfg.nLen = nLen;

				
                for (int i = 0; i < nLen; i++)
                {
                    m_pnOldDO[nStartAddress + i] = m_pnDO[nStartAddress + i];
                    m_pnDO[nStartAddress + i] = pnVal[i];
                    m_AClientSocketPlcSiemensWrite.m_pnDataWrite[i] = m_pnDO[nStartAddress + i];
                }
                // 2011.04.28
                for (int i = 0; i < _RETRY; i++)
                {
                    nR = m_AClientSocketPlcSiemensWrite.WritePlc(stCfg);
                    if (nR == 1)
                        break;
                }
			}
            if (nR == 1)
            {
				AUtil.PostMessage(m_hParent, _WM_SOCKET_WRITE_OK, 0, m_nID);
            }
            else
            {
				AUtil.PostMessage(m_hParent, _WM_SOCKET_WRITE_NG, nR, m_nID);
            }

            /* 2015.02.25
            for (int i = 0; i < nLen; i++)
            {
                if (m_pnOldDO[nStartAddress + i] != m_pnDO[nStartAddress + i])
                {
					AUtil.PostMessage(m_hParent, ASDef._WM_CHANGE_DO + m_nID, nStartAddress + i, m_pnDO[nStartAddress + i]);
                }
            }
            */

            return nR;
        }

        public int SetWordDBDW(int nDB, int nDW, int nVal)
        {
            int nR = -1;
            
			lock (m_AClientSocketPlcSiemensWrite)
			{
                // 2014.10.09
                AClientSocketPlcSiemens._stCfgSocketPlcSiemens stCfg;
                stCfg = new AClientSocketPlcSiemens._stCfgSocketPlcSiemens();
                stCfg.nORG = 1;
                stCfg.nDBNR = nDB;
                stCfg.nStart = nDW * 2;
                stCfg.nLen = 1;

				
                m_AClientSocketPlcSiemensWrite.m_pnDataWrite[0] = nVal;
                // 2011.04.28
                for (int i = 0; i < _RETRY; i++)
                {
                    nR = m_AClientSocketPlcSiemensWrite.WritePlc(stCfg);
                    if (nR == 1)
                        break;
                }
			}
            if (nR == 1)
            {
				AUtil.PostMessage(m_hParent, _WM_SOCKET_WRITE_OK, 0, m_nID);
            }
            else
            {
				AUtil.PostMessage(m_hParent, _WM_SOCKET_WRITE_NG, nR, m_nID);
            }

            return nR;
        }

        public void Run()
        {
            int nR = 0;
			AClientSocketPlcSiemens._stCfgSocketPlcSiemens stCfg;
			stCfg = new AClientSocketPlcSiemens._stCfgSocketPlcSiemens();
            stCfg.nORG = 1; //DB
            stCfg.nDBNR = m_stReadAddress.nDB; //DB
            stCfg.nStart = m_stReadAddress.nDW * 2; //DW
            stCfg.nLen = ASDef._MAX_PLC_DI;
            
            // 2011.07.18
#if _USE_PC_RUN
            int nPcRun = 0;
#endif
            while (!m_bStop)
            {
                try
                {
                    // 2014.08.10
                    if (m_bReConnecting == true)
                    {
                        // 2015.04.13
                        Thread.Sleep(1000);
                        //AUtil.Delay(1000, true);

                        continue;
                    }

					lock (m_AClientSocketPlcSiemensFetch)
					{
                        // 2014.11.12
                        for (int j = 0; j < _RETRY; j++)
                        {
                            nR = m_AClientSocketPlcSiemensFetch.ReadPlc(stCfg);
                            if (nR == 1)
                            {
                                for (int i = 0; i < ASDef._MAX_PLC_DI; i++)
                                {
                                    // 2015.02.25
                                    //m_pnOldDI[i] = m_pnDI[i];

                                    m_pnDI[i] = m_AClientSocketPlcSiemensFetch.m_pnDataRead[i];
                                }

                                // 2015.03.01
                                if (++m_nReadCount > 9999)
                                    m_nReadCount = 0;

                                break;
                            }
                        }
					}
                    if (nR == 1)
                    {
                        AUtil.PostMessage(m_hParent, _WM_SOCKET_FETCH_OK, 0, m_nID);

                        /* 2015.02.25
                        for (int i = 0; i < ASDef._MAX_PLC_DI; i++)
                        {
                            if (m_pnOldDI[i] != m_pnDI[i])
                            {
                                //AUtil.SendMessage(m_hParent, ASDef._WM_CHANGE_DI + m_nID, i, m_pnDI[i]);
                                AUtil.PostMessage(m_hParent, ASDef._WM_CHANGE_DI + m_nID, i, m_pnDI[i]);
                            }
                        }
                        */
#if _USE_PC_RUN
                        if (AVisionProBuild.Auto)
                        {
                            if (nPcRun > 4)
                            {
                                nPcRun = 0;
                                if (((GetWordDO(ASDef._DO_PC_RUN) >> ASDef._DO_BIT_PC_RUN) & 0x01) == 0x01)
                                {
                                    // 2014.07.17
                                    if (SetBitDO(Convert.ToInt32(ASDef._DO_PC_RUN), Convert.ToInt32(ASDef._DO_BIT_PC_RUN), false) == 1)
                                    {
                                        // 2015.02.11
                                        AVisionProBuild.WriteLogFile("O_Off:PC Run", ".PcRun.txt");
                                    }
                                }
                                else
                                {
                                    // 2014.07.17
                                    if (SetBitDO(Convert.ToInt32(ASDef._DO_PC_RUN), Convert.ToInt32(ASDef._DO_BIT_PC_RUN), true) == 1)
                                    {
                                        // 2015.02.11
                                        AVisionProBuild.WriteLogFile("O:PC Run", ".PcRun.txt");
                                    }
                                }
                            }
                            else
                                nPcRun++;
                        }
#endif
                    }
                    else
                    {
						AUtil.PostMessage(m_hParent, _WM_SOCKET_FETCH_NG, nR, m_nID);
                        
                    }
                }
                catch
                {
                }

                // 2015.04.13
                Thread.Sleep(m_nDelayTime);
                //AUtil.Delay(m_nDelayTime, true);
            }
        }

        public void Stop()
        {
            m_bStop = true;
        }       
        

        public bool IsConnect(int nCase)
        {
            if (nCase == 0)
            {
				return m_AClientSocketPlcSiemensFetch.m_bConnect;
				
            }
            else
            {
				return m_AClientSocketPlcSiemensWrite.m_bConnect;
            }
        }

        // 2011.04.21 마cto
        /*
        public void Reconnect()
        {
            Ping ping = new Ping();

            if (ping.Send(m_AClientSocketPlcSiemensFetch.m_strIP).Status == IPStatus.Success)
            {
                m_AClientSocketPlcSiemensFetch = new AClientSocketPlcSiemens(m_nID, m_hParent);
				m_AClientSocketPlcSiemensFetch.LoadIni("ClientSocketPlcSiemensFetch" + m_nID.ToString());
                m_AClientSocketPlcSiemensFetch.m_bMsg = false;
				if (m_AClientSocketPlcSiemensFetch.Connect() == true)
				{

					for (int i = 0; i < ASDef._MAX_PLC_DI; i++)
					{
						m_pnOldDI[i] = m_pnDI[i] = 0;
					}
                }
                m_AClientSocketPlcSiemensWrite = new AClientSocketPlcSiemens(m_nID, m_hParent);
				m_AClientSocketPlcSiemensWrite.LoadIni("ClientSocketPlcSiemensWrite" + m_nID.ToString());
                m_AClientSocketPlcSiemensWrite.m_bMsg = false;
				if (m_AClientSocketPlcSiemensWrite.Connect() == true)
				{
					for (int i = 0; i < ASDef._MAX_PLC_DO; i++)
					{
						m_pnOldDO[i] = m_pnDO[i] = 0;
					}
                }
                
				AUtil.PostMessage(m_hParent, _WM_PLC_RECONNECT, Convert.ToInt16(m_AClientSocketPlcSiemensFetch.m_bConnect), 0);
				
            }
        }
        */
        public bool Reconnect()
        {
            // 2014.08.10
            m_bReConnecting = true;

            Ping ping = new Ping();

            // 2014.12.05
            try
            {
                if (ping.Send(m_AClientSocketPlcSiemensFetch.m_strIP).Status == IPStatus.Success)
                {
                    //m_Thrd.Suspend();
                    if (m_Thrd != null)
                    {
                        m_Thrd.Abort();
                        m_Thrd.Join();
                    }
                    m_Thrd = null;
                    // 2016.01.04 by kdi.
                    m_bStop = false;

                    m_AClientSocketPlcSiemensFetch.Close();
                    m_AClientSocketPlcSiemensFetch = null;
                    m_AClientSocketPlcSiemensFetch = new AClientSocketPlcSiemens(m_nID, m_hParent);
                    m_AClientSocketPlcSiemensFetch.LoadIni("ClientSocketPlcSiemensFetch" + m_nID.ToString());
                    if (m_AClientSocketPlcSiemensFetch.ConnectNoMessage() == true)
                    {
                        for (int i = 0; i < ASDef._MAX_PLC_DI; i++)
                        {
                            // 2015.02.25
                            //m_pnOldDI[i] = m_pnDI[i] = 0;
                            m_pnDI[i] = 0;

                        }
                        m_AClientSocketPlcSiemensWrite.Close();
                        m_AClientSocketPlcSiemensWrite = null;
                        m_AClientSocketPlcSiemensWrite = new AClientSocketPlcSiemens(m_nID, m_hParent);
                        m_AClientSocketPlcSiemensWrite.LoadIni("ClientSocketPlcSiemensWrite" + m_nID.ToString());
                        if (m_AClientSocketPlcSiemensWrite.ConnectNoMessage() == true)
                        {
                            for (int i = 0; i < ASDef._MAX_PLC_DO; i++)
                            {
                                m_pnOldDO[i] = m_pnDO[i] = 0;
                            }

                            //m_Thrd.Resume();
                            m_Thrd = new Thread(new ThreadStart(Run));
                            m_Thrd.Start();

                            // 2014.08.10
                            m_bReConnecting = false;

                            return true;
                        }
                    }
                }
            }
            catch
            {

            }

            // 2014.08.10
            m_bReConnecting = false;

            return false;
        }
    }
}
