using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Atmc;
using AVisionPro;

namespace AVisionPro
{
    public partial class AFrmLight : Form
    {
        public const int _WM_LIGHT0 = (ASDef._WM_USER + 220);
        public const int _WM_LIGHT1 = (ASDef._WM_USER + 221);
        public const int _WM_LIGHT2 = (ASDef._WM_USER + 222);

        private IntPtr m_hParent;

        private TextBox[] m_ptxtExposure = null;
        private TextBox[] m_ptxtLed = null;
        
        public AFrmLight(IntPtr hParent, int nType)
        {
            InitializeComponent();

            m_hParent = hParent;

            m_ptxtExposure = new TextBox[] { txtExposure0, txtExposure1, txtExposure2 };
            m_ptxtLed = new TextBox[] { txtLed0, txtLed1, txtLed2 };

            int i;
            string strType;
            for (i = 0; i < AVisionProBuild.GetTypeCount(); i++)
            {
                strType = AVisionProBuild.GetType(i).Name;

                cmbType.Items.Add(strType);
            }
            cmbType.SelectedIndex = nType;

            InitLanguage();
        }

        // 2013.12.02
        private void InitLanguage()
        {
            // Common------------
            btnSave.Text = AUtil.GetXmlLanguage("Save");
            btnClose.Text = AUtil.GetXmlLanguage("Close");
            lblType.Text = AUtil.GetXmlLanguage("Type");
            // AFrmLight------------
            lblPoint.Text = AUtil.GetXmlLanguage("Point");
            lblIndex.Text = AUtil.GetXmlLanguage("Index");
            lblChannel.Text = AUtil.GetXmlLanguage("Channel");
            lblExposure.Text = AUtil.GetXmlLanguage("Exposure");
            lblLed.Text = AUtil.GetXmlLanguage("LED_brightness");
        }

        private void WriteData()
        {
            int nType = cmbType.SelectedIndex;
            int nPoint = cmbPoint.SelectedIndex;

            AIniLight aIniLight = new AIniLight(nType, nPoint);

            aIniLight.m_strIndex = txtIndex.Text;
            aIniLight.m_strChannel = txtChannel.Text;
            int i;
            for (i = 0; i < 3; i++)
            {
                aIniLight.m_pstrExposure[i] = m_ptxtExposure[i].Text;
                aIniLight.m_pstrLed[i] = m_ptxtLed[i].Text;
            }
            aIniLight.Write();

            // 2012.12.27
            string strTxt = "Light Change: " + cmbType.Text + "(" + cmbPoint.Text + ")";
            // 2015.02.11
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "HW: " + txtIndex.Text + "\t" + txtChannel.Text;/* +"\t" +
                txtIndex_s1.Text + "\t" + txtChannel_s1.Text + "\t" +
                txtIndex_s2.Text + "\t" + txtChannel_s3.Text + "\t" +
                txtIndex_s2.Text + "\t" + txtChannel_s3.Text;*/
            // 2015.02.11
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            for (i = 0; i < 3; i++)
            {
                strTxt = Convert.ToString(i + 1) + ": " + m_ptxtExposure[i].Text + "\t" + m_ptxtLed[i].Text;
                /*
                strTxt = Convert.ToString(i + 1) + ": " + m_ptxtExposure[i].Text + "\t" + m_pptxtLed[0, i].Text +"\t_\t" +
                    m_pptxtLed[1, i].Text + "\t_\t" +
                    m_pptxtLed[2, i].Text + "\t_\t" +
                    m_pptxtLed[3, i].Text;
                */
                // 2015.02.11
                AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            WriteData();
            MessageBox.Show("SAVE SUCCESS", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Close();
        }

        private void ReadData()
        {
            int nType = cmbType.SelectedIndex;
            int nPoint = cmbPoint.SelectedIndex;
            
            AIniLight aIniLight = new AIniLight(nType, nPoint);
            aIniLight.Read();

            txtIndex.Text = aIniLight.m_strIndex;
            txtChannel.Text = aIniLight.m_strChannel;
            int i;
            for (i = 0; i < 3; i++)
            {
                m_ptxtExposure[i].Text = aIniLight.m_pstrExposure[i];
                m_ptxtLed[i].Text = aIniLight.m_pstrLed[i];
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i;
            string strPoint;
            int nType = cmbType.SelectedIndex;

            AType aType = AVisionProBuild.GetType(nType);
            cmbPoint.Items.Clear();
            for (i = 0; i < aType.m_lstAPoint.Count; i++)
            {
                strPoint = aType.m_lstAPoint[i].Name;

                cmbPoint.Items.Add(strPoint);
            }
            cmbPoint.SelectedIndex = 0;

            
        }

        private void cmbPoint_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadData();
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            WriteData();

            int nType = cmbType.SelectedIndex;
            int nPoint = cmbPoint.SelectedIndex;

            AUtil.PostMessage(m_hParent, _WM_LIGHT0, nType, nPoint);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            WriteData();

            int nType = cmbType.SelectedIndex;
            int nPoint = cmbPoint.SelectedIndex;

            AUtil.PostMessage(m_hParent, _WM_LIGHT1, nType, nPoint);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            WriteData();

            int nType = cmbType.SelectedIndex;
            int nPoint = cmbPoint.SelectedIndex;

            AUtil.PostMessage(m_hParent, _WM_LIGHT2, nType, nPoint);
        }

        private void txtUIntKeyPress(object sender, KeyPressEventArgs e)
        {
            AUtil.OnlyNumberUInt(ref e);
        }

        private void txtUDoubleKeyPress(object sender, KeyPressEventArgs e)
        {
            AUtil.OnlyNumberUDouble(ref e);
        }

        // 2014.07.17
        private void txtIntKeyPress(object sender, KeyPressEventArgs e)
        {
            AUtil.OnlyNumberInt(ref e);
        }

    }
}
