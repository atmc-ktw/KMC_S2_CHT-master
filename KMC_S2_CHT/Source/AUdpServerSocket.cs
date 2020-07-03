using System;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;

using System.Net;

using Atmc;

namespace ADrv
{
    class AUdpServerSocket 
    {
        public const int _WM_AUDP_SOCKET = (ASDef._WM_USER+430); 
        //public const int _WM_AUDP_SOCKET_RECEIVE = (_WM_AUDP_SOCKET+0);
        //public const int _WM_AUDP_SOCKET_CLOSE  = (_WM_AUDP_SOCKET+1);
        public const int _WM_AUDP_SOCKET_RECONNECT = (_WM_AUDP_SOCKET+3);

        public int m_nID;
        // 2020.04.23
        public int m_nLPort;
        public int m_nRPort;

		public Socket m_UdpServer = null;
        IPEndPoint m_EP_Local = null;
        EndPoint m_EP_Remote = null;
        
		public bool m_bConnect = false;
        public static IntPtr m_hParent;
        public bool m_bMsg = true;

        
        public AUdpServerSocket(int nID, IntPtr hParent)
        {
            m_nID = nID;
            m_hParent = hParent;

			m_bConnect = false;

            m_UdpServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            m_UdpServer.ReceiveTimeout = 1000;
            m_UdpServer.SendTimeout = 1000;
            
			LoadIni("UdpServerSocket" + m_nID.ToString());
        }

        public void LoadIni(string strName)
        {
            StringBuilder strIP = new StringBuilder(32);

            // 2020.04.23
            m_nLPort = AUtil.GetPrivateProfileInt(strName, "LPort", 1000, ASDef._INI_FILE);
            m_nRPort = AUtil.GetPrivateProfileInt(strName, "RPort", 1000, ASDef._INI_FILE);

        }


        public bool Bind()
        {
            m_bConnect = false;

            // 2020.04.23
            m_EP_Local = new IPEndPoint(IPAddress.Any, m_nLPort);
            m_EP_Remote = new IPEndPoint(IPAddress.None, m_nRPort);
                        
            try
            {
                /*
                if (m_UdpServer != null)
                {
                    if (m_UdpServer.EnableBroadcast == true)
                    {
                        m_bConnect = true;
                        return m_bConnect;
                    }
                    m_UdpServer = null;
                }
                m_UdpServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                */
                m_UdpServer.Bind(m_EP_Local);

                m_bConnect = true;
            }
            catch (SocketException e)
            {
                if (m_bMsg)
                {
                    // 2014.07.17
                    AUtil.TopMostMessageBox.Show(e.Message, "Connect Exception occurs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            return m_bConnect;
        }

		public void Close()
		{
            if (m_UdpServer != null)
                m_UdpServer.Close();
            
			m_bConnect = false;
		}

        public int Receive(ref byte[] pbyData)
        {
            int nLen = -1;

            if (m_bConnect == false)
            {
                // 2012.12.03
                //AUtil.SendMessage(m_hParent, _WM_AUDP_SOCKET_RECONNECT, 0, m_nID);
                AUtil.PostMessage(m_hParent, _WM_AUDP_SOCKET_RECONNECT, 0, m_nID);
                return -99;
            }

            try
            {               

                byte[] pbyBuf = new byte[1024];
                nLen = m_UdpServer.ReceiveFrom(pbyBuf, ref m_EP_Remote);
                
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

        public int Send(byte[] pbyData, int nLen)
        {
			if (m_bConnect == false)
            {
                // 2012.12.03
                //AUtil.SendMessage(m_hParent, _WM_AUDP_SOCKET_RECONNECT, 0, m_nID);
                AUtil.PostMessage(m_hParent, _WM_AUDP_SOCKET_RECONNECT, 0, m_nID);
                return -99;
            }

            try
            {
                m_UdpServer.SendTo(pbyData, nLen, SocketFlags.None, m_EP_Remote);
            }
            catch
            {
                return -100;
            }
            return 1;
        }
                

        public int ClearBuffer()
        {
            byte[] pbyBuf = new byte[10240];
            return m_UdpServer.Receive(pbyBuf, 0, pbyBuf.Length, SocketFlags.None);
        }
    }
}