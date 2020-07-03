using System;
using System.Text;
using System.IO.Ports;
using System.Threading;

using Atmc;

namespace ADrv
{    
    public class AComm
    {
        public const byte _SOH = 0x01;        // 통신에서 사용되는 문자의 선언
        public const byte _STX = 0x02;
        public const byte _ETX = 0x03;
        public const byte _EOT = 0x04;
        public const byte _ENQ = 0x05;
        public const byte _ACK = 0x06;
        public const byte _NAK = 0x15;
        public const byte _CR = 0x0D;
        public const byte _LF = 0x0A;
        public const byte _DLE = 0x10;

        
        public struct stCommCfg
        {
            public string strPort;
            public int nBaud;
            public Parity emParity;
            public int nData;
            public StopBits emStop;
            public Handshake emHandshake;            
        }

        public int m_nID;

        private SerialPort m_SerialPort;

        private stCommCfg m_stCommCfg;

        public AComm(int nID)
        {
            m_nID = nID;
			
			LoadIni("Com" + m_nID.ToString());
        }

		public AComm(int nID, string strComPort, int nBaudRate, Parity emParity, int nDataBits, StopBits emStopBits)
		{
			m_nID = nID;

			m_stCommCfg.strPort = strComPort;
            m_stCommCfg.nBaud = nBaudRate;
            m_stCommCfg.emParity = emParity;            
            m_stCommCfg.nData = nDataBits;
            m_stCommCfg.emStop = emStopBits;

            m_stCommCfg.emHandshake = Handshake.None;
		}

		public int GetInQue()
		{
			return m_SerialPort.BytesToRead;
		}
		
		public int OpenPort()
		{
			try
			{
                m_SerialPort = new SerialPort(m_stCommCfg.strPort, m_stCommCfg.nBaud, m_stCommCfg.emParity, m_stCommCfg.nData, m_stCommCfg.emStop);
                m_SerialPort.Handshake = m_stCommCfg.emHandshake;

				m_SerialPort.Open();
			}
			catch
			{
				return -100;
			}
			
			return 1;
		}

        public void ClosePort()
        {
            try
            {
                m_SerialPort.Close();
            }
            catch { }
        }
		
    
        public void LoadIni(string strApp)
		{
            // 2011.05.24
			StringBuilder strTmp = new StringBuilder(32);

            AUtil.GetPrivateProfileString(strApp, "Port", "COM1", strTmp, 10, ASDef._INI_FILE);
            m_stCommCfg.strPort = strTmp.ToString();

            m_stCommCfg.nBaud = (int)AUtil.GetPrivateProfileInt(strApp, "Baud", 9600, ASDef._INI_FILE);

            AUtil.GetPrivateProfileString(strApp, "Parity", "N", strTmp, 10, ASDef._INI_FILE);
            switch (strTmp[0])
			{
                case 'N': m_stCommCfg.emParity = Parity.None; break;
                case 'E': m_stCommCfg.emParity = Parity.Even; break;
                case 'O': m_stCommCfg.emParity = Parity.Odd; break;
			}

            m_stCommCfg.nData = (int)AUtil.GetPrivateProfileInt(strApp, "Data", 8, ASDef._INI_FILE);

			int nStopBit = (int)AUtil.GetPrivateProfileInt(strApp, "Stop", 1, ASDef._INI_FILE);
			switch (nStopBit)
			{
                case 0: m_stCommCfg.emStop = StopBits.None; break;
                case 1: m_stCommCfg.emStop = StopBits.One; break;
                case 2: m_stCommCfg.emStop = StopBits.Two; break;
			}

            AUtil.GetPrivateProfileString(strApp, "HandShake", "N", strTmp, 10, ASDef._INI_FILE);
            switch (strTmp[0])
            {
                case 'N': m_stCommCfg.emHandshake = Handshake.None; break;
                case 'X': m_stCommCfg.emHandshake = Handshake.XOnXOff; break;
                case 'R': m_stCommCfg.emHandshake = Handshake.RequestToSend; break;
                case 'A': m_stCommCfg.emHandshake = Handshake.RequestToSendXOnXOff; break;
            }
		}


		/********************************************************************************************
		 * PLC DATA WRITE
		 * *****************************************************************************************/
        public int WriteStr(byte[] pbyWriteCmd, int nLen)
        {
            if (m_SerialPort.IsOpen == false)
                return -99;

            try
            {
                if (nLen == 0)
                {
                    nLen = pbyWriteCmd.Length;
                }
                m_SerialPort.Write(pbyWriteCmd, 0, nLen);
                
                return 1;                                
            }
            catch
            {
                return -100;
            }
        }

        public int WriteStr(byte[] pbWriteCmd)
        {
            return WriteStr(pbWriteCmd, 0);
        }

        public int WriteByte(byte bWriteCmd, int nTime)
        {
            if (m_SerialPort.IsOpen == false)
                return -99;
            
            byte[] pbyStr = new byte[2];

            pbyStr[0] = bWriteCmd;
            pbyStr[1] = (byte)0;

            try
            {
                
                m_SerialPort.Write(pbyStr, 0, 1);

            
                return 1;
            }
            catch
            {
                return -100;
            }
        }
		
      
	    /********************************************************************************************
		 * PLC DATA READ
		 * *****************************************************************************************/

        public int ReadStr(byte[] pbyReadCmd, int nLen, int nTime)
        {
            if (m_SerialPort.IsOpen == false)
                return -99;

            DateTime dtStart = new DateTime();
            
            // 2014.07.17
            TimeSpan tmsInterval = new TimeSpan(0, 0, 0, 0, nTime);
            
            int nCommByts = 0;

            try
            {
                if (nTime > 0)
                {
                    dtStart = DateTime.Now;

                    while ((DateTime.Now - dtStart) < tmsInterval)
                    {
                        if (m_SerialPort.BytesToRead >= nLen)
                        {
                            nCommByts = m_SerialPort.Read(pbyReadCmd, 0, nLen);

                            if (nCommByts == 0)
                            {
                                return -2;
                            }

                            return 1;
                        }

                        // 2015.04.13
                        Thread.Sleep(1);
                        //AUtil.Delay(1, true);
                    }

                    return -1;
                }
                else
                {
                    nCommByts = m_SerialPort.Read(pbyReadCmd, 0, nLen);

                    if (nCommByts == 0)
                    {
                        return -2;
                    }

                    return 1;
                }               
            }
            catch
            {
                return -100;
            }
        }

        public int ReadByte(int nTime)
        {
            if (m_SerialPort.IsOpen == false)
                return -99;

            DateTime dtStart = new DateTime();
            // 2014.07.17
            TimeSpan tmsInterval = new TimeSpan(0, 0, 0, 0, nTime);

            int nCommByts = 0;
            byte[] pbyStr = new byte[2];

            try
            {
                if (nTime > 0)
                {
                    dtStart = DateTime.Now;

                    while ((DateTime.Now - dtStart) < tmsInterval)
                    {
                        if (m_SerialPort.BytesToRead > 0)
                        {
                            nCommByts = m_SerialPort.Read(pbyStr, 0, 1);

                            if (nCommByts == 0)
                            {
                                return -2;
                            }

                            return (int)pbyStr[0];
                        }

                        // 2015.04.13
                        Thread.Sleep(1);
                        //AUtil.Delay(1, true);
                    }

                    return -1;
                }
                else
                {
                    nCommByts = m_SerialPort.Read(pbyStr, 0, 1);

                    if (nCommByts == 0)
                    {
                        return -2;
                    }

                    return (int)pbyStr[0];
                }
            }
            catch
            {
                return -100;
            }
        }

        public int ReadCheckStr(byte[] pbyStr, int nLen, int nTime)
        {
	        int nCh, i;
        	
	        for(i=0;i<nLen;i++)
	        {
		        nCh = ReadByte(nTime);
		        if (nCh < 0 ) return -1;  // 수신된 문자가 없음
		        if (nCh != (int)pbyStr[i])
		        {
			        return -2;  // 다른 문자
		        }
	        }
	        return 1;
        }

        public int ReadCheckPoint(byte[] pbyPoint, int nLen, int nTime)
        {
	        int nCh, i;
	        while(true)
	        {
		        nCh = ReadByte(nTime);
		        if (nCh < 0 ) 
                    return -1;  // 수신된 문자가 없음
		        for(i=0;i<nLen;i++)
		        {
			        if (nCh == (int)pbyPoint[i])
                        return nCh;			
		        }
	        }
        }


		public void ClearBuffer()
		{
            if (m_SerialPort.IsOpen == false)
                return;
			try
			{
				m_SerialPort.DiscardInBuffer();
				m_SerialPort.DiscardOutBuffer();
			}
			catch{}
		}
        
		/********************************************************************************************
		 * Utility
		 * *****************************************************************************************/
		/*
        public void BytesToInts(byte[] bytes, int[] ints)
		{
			for (int i = 0; i < bytes.Length / 2; ++i)
			{
				ints[i] = (bytes[(i * 2)] << 8) + bytes[(i * 2) + 1];
			}
		}

        public static byte[] HexToBytes(string strData)
        {
			byte[] bytes = new byte[strData.Length];
			
            for (int i = 0; i < bytes.Length; i++)
                bytes[i] = Convert.ToByte(strData[i]);

            return bytes;
        }

        public static byte IntToByte(uint nData, int nIndex)
        {
            return (byte)((nData & (0xff << (nIndex * 8))) >> (nIndex*8));
        }

		public static byte IntToByte(int nData, int nIndex)
		{
			return (byte)((nData & (0xff << (nIndex * 8))) >> (nIndex * 8));
		}

        public char ASC2Char(int ASCIICode)
        {
            try
            {
                char chr = (char)ASCIICode;
                return chr;
            }
            catch
            {
                return '0';
            }

        }

        public int Char2ASC(char chr)
        {
            try
            {
                int ascCode = (short)chr;
                return ascCode;
            }
            catch
            {
                return 0;
            }
        }
        */
    }
}
