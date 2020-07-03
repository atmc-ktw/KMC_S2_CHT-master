using System;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;

using Atmc;

namespace ADrv
{
    class AClientSocket 
    {
        public const int _WM_ASOCKET = (ASDef._WM_USER+420); 
        public const int _WM_ASOCKET_RECEIVE = (_WM_ASOCKET+0);
        //public const int _WM_ASOCKET_CLOSE  = (_WM_ASOCKET+1);
        public const int _WM_ASOCKET_RECONNECT = (_WM_ASOCKET+3);

        public int m_nID;
        public string m_strIP;
        public int m_nPort;
		public TcpClient m_TcpClient = null;
        private NetworkStream m_NetworkStream = null;

		public bool m_bConnect = false;
        public static IntPtr m_hParent;
        // 2010.10.20
        public bool m_bMsg = true;

        // 2013.09.03
        public string m_strReadData = "";
        
        public AClientSocket(int nID, IntPtr hParent)
        {
            m_nID = nID;
            m_hParent = hParent;

			m_bConnect = false;

			LoadIni("ClientSocket" + m_nID.ToString());
        }

        public void LoadIni(string strName)
        {
            StringBuilder strIP = new StringBuilder(32);
            AUtil.GetPrivateProfileString(strName, "IP", "127.0.0.1", strIP, 20, ASDef._INI_FILE);
            m_strIP = strIP.ToString();

            m_nPort = AUtil.GetPrivateProfileInt(strName, "Port", 1000, ASDef._INI_FILE);
        }

        public bool Connect(string strIP, int nPort)
        {
			m_bConnect = false;
            m_strIP = strIP;
            m_nPort = nPort;

            try
            {
				if (m_TcpClient != null)
				{
					if (m_TcpClient.Connected == true)
					{
                        m_bConnect = true;
                        return m_bConnect;
					}
					m_TcpClient = null;                    
				}
				m_TcpClient = new TcpClient();
                m_TcpClient.Connect(m_strIP, m_nPort);//서버에 연결
                // 2014.08.10
                if (m_TcpClient.Connected == true)
                {
                    if (m_NetworkStream != null)
                    {
                        m_NetworkStream = null;
                    }
                    m_NetworkStream = m_TcpClient.GetStream();//스트림 얻기

                    m_bConnect = true;
                }
            }
            catch (Exception e)
            {
                // 2010.10.20
                if (m_bMsg)
                {
                    // 2014.07.17
                    AUtil.TopMostMessageBox.Show(e.Message, "Connect Exception occurs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

			return m_bConnect;
        }

        public bool ConnectCallback(string strIP, int nPort)
        {
            m_bConnect = false;
            m_strIP = strIP;
            m_nPort = nPort;

            try
            {
                if (m_TcpClient != null)
                {
                    if (m_TcpClient.Connected == true)
                    {
                        // 2013.09.16
                        m_TcpClient.Close();
                    }
                    m_TcpClient = null;
                }
                m_TcpClient = new TcpClient();
                m_TcpClient.Connect(m_strIP, m_nPort);//서버에 연결
                if (m_NetworkStream != null)
                {
                    // 2013.09.16
                    m_NetworkStream.Close();
                    m_NetworkStream = null;
                }
                m_NetworkStream = m_TcpClient.GetStream();//스트림 얻기

                if (m_NetworkStream.CanRead)
                {
                    byte[] pbyReceived = new byte[4096];
                    m_NetworkStream.BeginRead(pbyReceived, 0, 0, new AsyncCallback(OnBeginRead), m_NetworkStream);

                    m_bConnect = true;
                }
            }
            catch (Exception e)
            {
                // 2010.10.20
                if (m_bMsg)
                {
                    // 2014.07.17
                    AUtil.TopMostMessageBox.Show(e.Message, "Connect Exception occurs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return m_bConnect;
        }

        public bool Connect()
        {
            return Connect(m_strIP, m_nPort);
        }

		public void Close()
		{
            // 2011.04.21
            if (m_NetworkStream != null)
                m_NetworkStream.Close();
            /*
            Socket SocketClient = m_TcpClient.Client;
            SocketClient.Shutdown(SocketShutdown.Both);
            */
            // 2011.04.21
            if (m_TcpClient != null)
                m_TcpClient.Close();
            
			m_bConnect = false;
		}

        // 2015.04.08
        private void WaitforAvailableData(int nTimeout)
        {
            DateTime dtStart = new DateTime();
            TimeSpan tmsInterval = new TimeSpan(0, 0, 0, 0, nTimeout);

            dtStart = DateTime.Now;

            while ((DateTime.Now - dtStart) < tmsInterval)
            {
                if (CanRead() == true)
                    break;

                //System.Windows.Forms.Application.DoEvents();

                System.Threading.Thread.Sleep(1);
            }
        }

        // 2015.04.08
        private bool CanRead()
        {
            if (m_bConnect == false)
            {
                return false;
            }

            try
            {
                if (m_NetworkStream == null)
                    return false;

                if (m_NetworkStream.DataAvailable == false)
                    return false;
            }
            catch
            {
                return false;
            }

            return true;
        }

        public int Receive(ref byte[] pbyData, int nTime)
        {
            int nLen = -1;

            if (m_bConnect == false)
            {
                // 2012.12.03
                //AUtil.SendMessage(m_hParent, _WM_ASOCKET_RECONNECT, 0, m_nID);
                AUtil.PostMessage(m_hParent, _WM_ASOCKET_RECONNECT, 0, m_nID);
                return -99;
            }

            try
            {
                // 2015.04.08
                WaitforAvailableData(nTime);

                // 2015.03.14
                if (m_NetworkStream.DataAvailable == false)
                    return 0;
                
                byte[] pbyBuf = new byte[4096];
                m_NetworkStream.ReadTimeout = nTime;
                nLen = m_NetworkStream.Read(pbyBuf, 0, pbyBuf.Length);

                if (nLen > 0)
                {
                    pbyData = new byte[nLen];
                    Array.Copy(pbyBuf, pbyData, nLen);
                }
            }
            catch            
            {
                return -100;
            }

            return nLen;
        }

        public int Send(byte[] pbyData, int nLen, int nTime)
        {
			if (m_bConnect == false)
            {
                // 2012.12.03
                //AUtil.SendMessage(m_hParent, _WM_ASOCKET_RECONNECT, 0, m_nID);
                AUtil.PostMessage(m_hParent, _WM_ASOCKET_RECONNECT, 0, m_nID);
                return -99;
            }

            try
            {
                m_NetworkStream.WriteTimeout = nTime;
                m_NetworkStream.Write(pbyData, 0, nLen);
            }
            catch
            {
                return -100;
            }
            return 1;
        }

        // 2011.04.21 마cto
        public bool ConnectNoMessage()
        {
            m_bConnect = false;

            try
            {
                if (m_TcpClient != null)
                {
                    if (m_TcpClient.Connected == true)
                    {
                        m_TcpClient.Close();
                    }
                    m_TcpClient = null;
                }
                m_TcpClient = new TcpClient();
                m_TcpClient.Connect(m_strIP, m_nPort);//서버에 연결
                if (m_NetworkStream != null)
                {
                    m_NetworkStream = null;
                }
                m_NetworkStream = m_TcpClient.GetStream();//스트림 얻기

                m_bConnect = true;
            }
            catch
            {

            }

            return m_bConnect;
        }

        // 2011.04.30 마cto
        public int ClearBuffer()
        {
            byte[] pbyBuff = new byte[4096];
            int nR = Receive(ref pbyBuff, 5);
            if (nR > 0)
                return nR;
            return nR;
        }

     

        private void OnBeginRead(IAsyncResult ar)
        {
            // 2013.11.22 종료시 예외 처리 발생
            try
            {
                NetworkStream ns = (NetworkStream)ar.AsyncState;
                int BUFFER_SIZE = 4096;
                byte[] pbyReceived = new byte[BUFFER_SIZE];

                ns.EndRead(ar);

                int nRead = 0;
                while (ns.DataAvailable)
                {
                    nRead += ns.Read(pbyReceived, 0, BUFFER_SIZE);
                    m_strReadData += Encoding.ASCII.GetString(pbyReceived);
                    pbyReceived = new byte[BUFFER_SIZE];
                }
                m_strReadData = m_strReadData.Trim(new char[] { '\0' });
                // Want to update Form here with result

                // 2013.12.04 Server프로그램 종료시 계속 호출로 
                if (nRead == 0)
                {
                    AUtil.PostMessage(m_hParent, _WM_ASOCKET_RECONNECT, 0, m_nID);
                    return;
                }
                // 2013.09.16
                if (m_NetworkStream.CanRead)
                {
                    m_NetworkStream.BeginRead(pbyReceived, 0, 0, new AsyncCallback(OnBeginRead), m_NetworkStream);

                    m_bConnect = true;
                }

                AUtil.PostMessage(m_hParent, _WM_ASOCKET_RECEIVE, nRead, m_nID);
            }
            catch
            {
                // 2013.11.22
                AUtil.PostMessage(m_hParent, _WM_ASOCKET_RECONNECT, 0, m_nID);
            }
        }
    }
}