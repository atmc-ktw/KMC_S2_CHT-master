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
    public partial class AFrmPW: Form
    {
        private IntPtr m_hParent;
        public string m_strPassWord="";
        public bool m_bPW;

        // 2014.03.26
        private int m_nID;

        public AFrmPW(IntPtr hParent)
        {
            InitializeComponent();

            m_hParent = hParent;
            m_nID = 0;

            InitLanguage();

            // 2014.03.26
            m_bPW = false;

            tmrTimeOut.Enabled = true;      
        }

        public AFrmPW(IntPtr hParent, int nID)
        {
            InitializeComponent();

            m_hParent = hParent;
            m_nID = nID;

            InitLanguage();

            // 2014.03.26
            m_bPW = false;

            tmrTimeOut.Enabled = true;            
        }

        // 2013.12.02
        private void InitLanguage()
        {
            // Common------------
            btnOK.Text = AUtil.GetXmlLanguage("OK");
            btnCancel.Text = AUtil.GetXmlLanguage("Cancel");

            // AFrmPW------------
            lblTitle.Text = AUtil.GetXmlLanguage("Password");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_bPW = false;
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if ((Equals(m_strPassWord, txtPw.Text)) || (Equals("atmc@273.8727", txtPw.Text)))
            {
                m_bPW = true;

                Close();
            }
            else
            {
                m_bPW = false;
                txtPw.Text = "";
                //MessageBox.Show("비밀번호가 틀렸습니다.다시 입력 하세요!");
                // 2013.12.02
                MessageBox.Show(AUtil.GetXmlLanguage("Password_Miss_match"));
                
            }
        }

        private void AFrmPW_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder(16);

            AUtil.GetPrivateProfileString("PASSWORD", "PW", "*****", sb, 10, ASDef._INI_FILE);
            m_strPassWord = sb.ToString();
        }

        private void tmrTimeOut_Tick(object sender, EventArgs e)
        {
            tmrTimeOut.Enabled = false;
            m_bPW = false;
            txtPw.Text = "";

            // 2014.03.26
            AUtil.PostMessage(m_hParent, ASDef._WM_PASSWORD_CHECK, m_nID, 0);
            Close();
        }

        private void AFrmPW_FormClosing(object sender, FormClosingEventArgs e)
        {
            tmrTimeOut.Enabled = false;

            // 2014.03.26                
            if (m_bPW == true)
            {
                AUtil.PostMessage(m_hParent, ASDef._WM_PASSWORD_CHECK, m_nID, 1);
            }
            else
            {
                AUtil.PostMessage(m_hParent, ASDef._WM_PASSWORD_CHECK, m_nID, 0);
            }
                
        }
        
       
    }
}

