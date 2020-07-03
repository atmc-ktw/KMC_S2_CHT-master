using System;
using System.Threading;

using Atmc;

namespace ADrv
{
    class AUdpServerSocketRbtHHI : AUdpServerSocket
	{

        public AUdpServerSocketRbtHHI(int nID, IntPtr hParent)
			: base(nID, hParent)
		{
			LoadIni("UdpServerSocketRbtHHI" + nID.ToString());
		}


		public int SendToRobot(double dX, double dY, double dZ, double dAX, double dAY, double dAZ)
		{
            byte[] pbyStr = new byte[255];

			//sprintf(pbyStr, "SHIFT %.1lf,%.1lf,%.1lf,%.2lf,%.2lf,%.2lf\r", dX, dY, dZ, dAX, dAY, dAZ);			
			string strTmp = String.Format("({0:f1},{1:f1},{2:f1},{3:f2},{4:f2},{5:f2})\r\n", dX, dY, dZ, dAX, dAY, dAZ);

            pbyStr = System.Text.Encoding.ASCII.GetBytes(strTmp);
            return Send(pbyStr, strTmp.Length);
		}

        public int SendToRobot(string strData)
        {
            byte[] pbyStr = System.Text.Encoding.ASCII.GetBytes(strData + "\r\n");

            return Send(pbyStr, strData.Length + 1);
        }

		public int ReadShift()
		{
            byte[] pbyBuff = new byte[1024];
			if (Receive(ref pbyBuff) > 7)
			{
                if (pbyBuff[0] == 'S' &&
                    pbyBuff[1] == 'H' &&
                    pbyBuff[2] == 'I' &&
                    pbyBuff[3] == 'F' &&
                    pbyBuff[4] == 'T' &&
                    pbyBuff[5] == ' ')
				{
                    return (int)pbyBuff[6] - (int)'0';

				}
                return -2;
			}

			return 0;
		}
	}
}
