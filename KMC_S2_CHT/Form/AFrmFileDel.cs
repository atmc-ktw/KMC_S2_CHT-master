using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Atmc;

namespace AVisionPro
{
    public partial class AFrmFileDel: Form
    {
        private IntPtr m_hParent;

        public AFrmFileDel(IntPtr hParent)
        {
            InitializeComponent();

            m_hParent = hParent;

            InitLanguage();
        }

        // 2013.12.02
        private void InitLanguage()
        {
            // Common------------
            btnSave.Text = AUtil.GetXmlLanguage("Save");
            btnClose.Text = AUtil.GetXmlLanguage("Close");

            // AFrmFileDel------------
            lblTitle.Text = AUtil.GetXmlLanguage("File_Delete_Setting");
            lblOK.Text = AUtil.GetXmlLanguage("OK_Save_Date");
            lblNG.Text = AUtil.GetXmlLanguage("NG_Save_Date");
            lblTotalOK.Text = AUtil.GetXmlLanguage("Total_OK_Save_Date");
            lblTotalNG.Text = AUtil.GetXmlLanguage("Total_NG_Save_Date");
            lblLog.Text = AUtil.GetXmlLanguage("LOG_Save_Date");
            lblDelTime.Text = AUtil.GetXmlLanguage("Delete_Time");

            // 2017.06.08
            lblPathSetup.Text = AUtil.GetXmlLanguage("Path_Setup");
            btnSelectPath.Text = AUtil.GetXmlLanguage("Select_Path");

        }

        private void AFrmFileDel_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder(16);

            AUtil.GetPrivateProfileString("DelTime", "OK", "30", sb, 5, ASDef._INI_FILE);
            txtOk.Text = sb.ToString();
            AUtil.GetPrivateProfileString("DelTime", "NG", "30", sb, 5, ASDef._INI_FILE);
            txtNg.Text = sb.ToString();
            // 2011.08.17
            AUtil.GetPrivateProfileString("DelTime", "TOTAL_OK", "30", sb, 5, ASDef._INI_FILE);
            txtTotalOK.Text = sb.ToString();
            AUtil.GetPrivateProfileString("DelTime", "TOTAL_NG", "30", sb, 5, ASDef._INI_FILE);
            txtTotalNG.Text = sb.ToString();
            AUtil.GetPrivateProfileString("DelTime", "LOG", "30", sb, 5, ASDef._INI_FILE);
            txtLog.Text = sb.ToString();
            AUtil.GetPrivateProfileString("DelTime", "TIME", "11:10", sb, 6, ASDef._INI_FILE);
            dTDel.Text = sb.ToString();

            // 2017.06.08
            txtPath.Text = AVisionProBuild.m_strResultPath;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AUtil.WritePrivateProfileString("DelTime", "OK", txtOk.Text, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString("DelTime", "NG", txtNg.Text, ASDef._INI_FILE);
            // 2011.08.17
            AUtil.WritePrivateProfileString("DelTime", "TOTAL_OK", txtTotalOK.Text, ASDef._INI_FILE);
            // 2011.08.17
            AUtil.WritePrivateProfileString("DelTime", "TOTAL_NG", txtTotalNG.Text, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString("DelTime", "LOG", txtLog.Text, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString("DelTime", "TIME", dTDel.Text, ASDef._INI_FILE);

            // 2017.06.08
            AVisionProBuild.m_strResultPath = txtPath.Text;
            AUtil.WritePrivateProfileString("PATH", "ResultPath", txtPath.Text, ASDef._INI_FILE);

            AUtil.PostMessage(m_hParent, ASDef._WM_LOAD_FILEDEL, 0, 0);

            // 2015.02.11
            string strTxt = "FileDel Change: ";
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "OK: " + txtOk.Text;
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "NG: " + txtNg.Text;
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "TotalOK: " + txtTotalOK.Text;
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "TotalNG: " + txtTotalNG.Text;
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "LOG: " + txtLog.Text;
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "TIME: " + dTDel.Text;
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            // 2017.06.08
            strTxt = "Path: " + AVisionProBuild.m_strResultPath;
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtUIntKeyPress(object sender, KeyPressEventArgs e)
        {
            AUtil.OnlyNumberUInt(ref e);
        }

        // 2017.06.08
        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                AVisionProBuild.m_strResultPath = dlg.SelectedPath;
                txtPath.Text = AVisionProBuild.m_strResultPath;
            }
        }               
       
    }
}
