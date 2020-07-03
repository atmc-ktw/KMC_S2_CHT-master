using System;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using ADrv;
using Atmc;

namespace ACom
{
    class AThrdUdpServerSocketRbtHHI
    {
        public const int _WM_AUDP_SOCKET_ROBOT_OK = ASDef._WM_USER + 342;
        public const int _WM_AUDP_SOCKET_ROBOT_NG = ASDef._WM_USER + 343;

		private ASDef._stRobotShift[] m_pstRobotShift = new ASDef._stRobotShift[100];

		private AUdpServerSocketRbtHHI m_AUdpServerSocketRbt;
        public Thread m_Thrd;


        private bool m_bStop = false;
        public int m_nID;
                    

        private static IntPtr m_hParent;
        private int m_nDelayTime;

        // 2015.03.01
        public int m_nReadCount = 0;

        public AThrdUdpServerSocketRbtHHI(int nID, IntPtr hParent)
        {
            m_nID = nID;
            m_hParent = hParent;

            LoadIni("ThrdUdpServerSocketRbtHHI" + m_nID.ToString(), ASDef._INI_FILE);

            m_AUdpServerSocketRbt = new AUdpServerSocketRbtHHI(m_nID, m_hParent);
        }

        public void Init()
        {
            m_AUdpServerSocketRbt.Bind();

            m_Thrd = new Thread(new ThreadStart(Run));
            m_Thrd.Start();
        }

		public void LoadIni(string strName, string strIni)
		{
			StringBuilder strBuilder = new StringBuilder(32);
			m_nDelayTime = AUtil.GetPrivateProfileInt(strName, "Delay", 200, strIni);
		}

		public void Stop()
        {
            m_bStop = true;
        }

		private void Run() 
        {
	        int nR;

	        while (!m_bStop)
            {
                try
                {
                    lock (m_AUdpServerSocketRbt)
                    {
                        nR = m_AUdpServerSocketRbt.ReadShift();

                        if (nR > 0)
                        {
                            int n = m_AUdpServerSocketRbt.SendToRobot(
                                m_pstRobotShift[nR - 1].dX,
                                m_pstRobotShift[nR - 1].dY,
                                m_pstRobotShift[nR - 1].dZ,
                                m_pstRobotShift[nR - 1].dAX,
                                m_pstRobotShift[nR - 1].dAY,
                                m_pstRobotShift[nR - 1].dAZ);

                            // 2015.03.01
                            if (++m_nReadCount > 9999)
                                m_nReadCount = 0;

                            AUtil.PostMessage(m_hParent, _WM_AUDP_SOCKET_ROBOT_OK, m_nID, nR);
                        }
                        else if (nR < 0)
                        {
                            AUtil.PostMessage(m_hParent, _WM_AUDP_SOCKET_ROBOT_NG, m_nID, nR);
                        }
                    }
                }
                catch
                {
                }

                // 2015.04.13
                Thread.Sleep(m_nDelayTime);
                //AUtil.Delay(m_nDelayTime, true);
	        }
            m_AUdpServerSocketRbt.Close();
        }


        public void Send(int n)
		{
			lock (m_AUdpServerSocketRbt)
            {
				m_AUdpServerSocketRbt.SendToRobot(
					m_pstRobotShift[n].dX, 
					m_pstRobotShift[n].dY,
					m_pstRobotShift[n].dZ,
					m_pstRobotShift[n].dAX,
					m_pstRobotShift[n].dAY,
					m_pstRobotShift[n].dAZ);
			}
		}


        public void SetValue(int n, double dX, double dY, double dZ, 
				double dAX, double dAY, double dAZ)
		{

			m_pstRobotShift[n].dX = dX; 
			m_pstRobotShift[n].dY = dY;
			m_pstRobotShift[n].dZ = dZ;
			m_pstRobotShift[n].dAX = dAX;
			m_pstRobotShift[n].dAY = dAY;
			m_pstRobotShift[n].dAZ = dAZ;
		}
	}
}