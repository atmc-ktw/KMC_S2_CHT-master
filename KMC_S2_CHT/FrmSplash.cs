using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
// 2017.04.15
using Atmc;

namespace KMC_S2_CHT
{
    public partial class FrmSplash : Form
    {
        delegate void SplashShowCloseDelegate();

        public FrmSplash()
        {
            InitializeComponent();

            //** 2017.04.15
            string strTitle = lblFileVersion.Text;
            DateTime dateFile = AUtil.GetFileDateTime(Application.ExecutablePath);
            string strFileDate = string.Format("{0}.{1:00}", dateFile.Year, dateFile.Month);
            strTitle = string.Format(strTitle, AUtil.GetFileVersion(System.Reflection.Assembly.GetExecutingAssembly()), strFileDate);
            lblFileVersion.Text = strTitle;
            //*/

        }

        public void ShowSplashScreen()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SplashShowCloseDelegate(ShowSplashScreen));
                return;
            }

            this.Show();
            Application.Run(this);
        }

        public void CloseSplashScreen()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new SplashShowCloseDelegate(CloseSplashScreen));
                return;
            }

            this.Close();
        }
    }
}
