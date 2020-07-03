using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;
using System.Runtime.InteropServices;

namespace ADrv
{
    class ACommLightControl : AComm
    {
        public ACommLightControl(int nID) : base(nID)
        {
            LoadIni("LightControl"+nID.ToString());
            if (OpenPort() != 1)
            {
                MessageBox.Show("LightControl" + nID.ToString() + " Com Port Error!");
            }
        }

        public int SendToVal(int nChanel, int nVal)
        {
	        int nR=0;
	        byte[] pbySend = new byte[255];
            string strTmp;

 
	        ClearBuffer();

	        if (nVal < 0  || nVal > 255)
	        {
		        return -1;
	        }
          

	        if (nChanel >=1 && nChanel <= 8)
	        {
                strTmp = String.Format("{0}WCH{1}{2:000}{3}", (char)AComm._STX, nChanel, nVal, (char)AComm._ETX);
	        }
	        else if (nChanel == 0)
	        {
                strTmp = String.Format("{0}WCHA{1:000}{2}", (char)AComm._STX, nVal, (char)AComm._ETX);                
	        }
	        else
	        {
		        return -2;
	        }

            pbySend = System.Text.Encoding.ASCII.GetBytes(strTmp);
            nR = WriteStr(pbySend, pbySend.Length);

            if (nR != 1)
                return -3;

            Thread.Sleep(100);

            if (ReadCheckStr(pbySend, 8, 1000) != 1)
            {
                return -4;
            }

            nR = ReadByte(100);	
            if ((char)nR != 'M' && (char)nR != 'R')
            {
                return -5;
            }
            if (ReadByte(100) != (int)AComm._ETX)
            {
                return -6;
            }	
	        return nR;
        }


        public int SendToOnOff(int nChanel, bool bVal)
        {
            int nR = 0;
            byte[] pbySend = new byte[255];
            string strTmp;

            ClearBuffer();
	        if (nChanel >=1 && nChanel <= 8)
	        {
                if (bVal)
                {
                    strTmp = String.Format("{0}CCH{1}1{2}", (char)AComm._STX, nChanel, (char)AComm._ETX);
                }
                else
                {
                    strTmp = String.Format("{0}CCH{1}0{2}", (char)AComm._STX, nChanel, (char)AComm._ETX);                    
                }
	        }
	        else if (nChanel == 0)
	        {
                if (bVal)
                {
                    strTmp = String.Format("{0}CCHA1{1}", (char)AComm._STX, (char)AComm._ETX);                    
                }
                else
                {
                    strTmp = String.Format("{0}CCHA0{1}", (char)AComm._STX, (char)AComm._ETX);                    
                }
	        }
	        else
	        {
		        return -1;
	        }

            pbySend = System.Text.Encoding.ASCII.GetBytes(strTmp);
            nR = WriteStr(pbySend, pbySend.Length);
            /*
            if (nR != 1)
                return -2;

            Thread.Sleep(100);

            if (ReadCheckStr(pbySend, 8, 1000) != 1)
            {
                return -3;
            }

            nR = ReadByte(100);
            if ((char)nR != 'M' && (char)nR != 'R')
            {
                return -4;
            }
            if (ReadByte(100) != (int)AComm._ETX)
            {
                return -5;
            }	
            */
	        return nR;
        }
             
    }
}
