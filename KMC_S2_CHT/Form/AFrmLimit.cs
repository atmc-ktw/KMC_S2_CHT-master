using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Atmc;

namespace AVisionPro
{
    public partial class AFrmLimit : Form
    {
        private IntPtr m_hParent;
        private int m_nCount;
        private string m_strLoc;

        public AFrmLimit(IntPtr hParent, int nType, int nCount, string strLoc)
        {
            InitializeComponent();

            m_hParent = hParent;

            m_nCount = nCount;

            m_strLoc = strLoc;

            InitLanguage();

            int i;
            string strType;
            for (i = 0; i < AVisionProBuild.GetTypeCount(); i++)
            {
                strType = AVisionProBuild.GetType(i).Name;

                cmbType.Items.Add(strType);
            }
            cmbType.SelectedIndex = nType;
        }

        // 2013.12.02
        private void InitLanguage()
        {
            // Common------------
            btnSave.Text = AUtil.GetXmlLanguage("Save");
            btnCancel.Text = AUtil.GetXmlLanguage("Cancel");
            lblType.Text = AUtil.GetXmlLanguage("Type");
            // AFrmLimit------------
            lblTitle.Text = AUtil.GetXmlLanguage("Limit_Setting");            
            lblLower.Text = AUtil.GetXmlLanguage("Lower");
            lblUpper.Text = AUtil.GetXmlLanguage("Upper");
        }
        private void AFrmLimit_Load(object sender, EventArgs e)
        {
            ReadData();
        }

        private void ReadData()
        {
            int nType = cmbType.SelectedIndex;

            if (m_strLoc == "")
            {
                lblTypeName.Text = AVisionProBuild.GetType(nType).Name;
            }
            else
            {
                lblTypeName.Text = AVisionProBuild.GetType(nType).Name + "(" + m_strLoc + ")";
            }

            // 2011.06.23
            txtLowX.Text = String.Format("{0:f2}", AVisionProBuild.GetType(nType).m_pstLimitLow[m_nCount].dX);
            txtLowY.Text = String.Format("{0:f2}", AVisionProBuild.GetType(nType).m_pstLimitLow[m_nCount].dY);
            txtLowZ.Text = String.Format("{0:f2}", AVisionProBuild.GetType(nType).m_pstLimitLow[m_nCount].dZ);
            txtLowAX.Text = String.Format("{0:f2}", AVisionProBuild.GetType(nType).m_pstLimitLow[m_nCount].dAX);
            txtLowAY.Text = String.Format("{0:f2}", AVisionProBuild.GetType(nType).m_pstLimitLow[m_nCount].dAY);
            txtLowAZ.Text = String.Format("{0:f2}", AVisionProBuild.GetType(nType).m_pstLimitLow[m_nCount].dAZ);

            txtHighX.Text = String.Format("{0:f2}", AVisionProBuild.GetType(nType).m_pstLimitHigh[m_nCount].dX);
            txtHighY.Text = String.Format("{0:f2}", AVisionProBuild.GetType(nType).m_pstLimitHigh[m_nCount].dY);
            txtHighZ.Text = String.Format("{0:f2}", AVisionProBuild.GetType(nType).m_pstLimitHigh[m_nCount].dZ);
            txtHighAX.Text = String.Format("{0:f2}", AVisionProBuild.GetType(nType).m_pstLimitHigh[m_nCount].dAX);
            txtHighAY.Text = String.Format("{0:f2}", AVisionProBuild.GetType(nType).m_pstLimitHigh[m_nCount].dAY);
            txtHighAZ.Text = String.Format("{0:f2}", AVisionProBuild.GetType(nType).m_pstLimitHigh[m_nCount].dAZ);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int nType = cmbType.SelectedIndex;
            // 2016.04.04
            try
            {
                // 2011.06.23
                AVisionProBuild.GetType(nType).m_pstLimitLow[m_nCount].dX = Convert.ToDouble(txtLowX.Text);
                AVisionProBuild.GetType(nType).m_pstLimitLow[m_nCount].dY = Convert.ToDouble(txtLowY.Text);
                AVisionProBuild.GetType(nType).m_pstLimitLow[m_nCount].dZ = Convert.ToDouble(txtLowZ.Text);
                AVisionProBuild.GetType(nType).m_pstLimitLow[m_nCount].dAX = Convert.ToDouble(txtLowAX.Text);
                AVisionProBuild.GetType(nType).m_pstLimitLow[m_nCount].dAY = Convert.ToDouble(txtLowAY.Text);
                AVisionProBuild.GetType(nType).m_pstLimitLow[m_nCount].dAZ = Convert.ToDouble(txtLowAZ.Text);


                AVisionProBuild.GetType(nType).m_pstLimitHigh[m_nCount].dX = Convert.ToDouble(txtHighX.Text);
                AVisionProBuild.GetType(nType).m_pstLimitHigh[m_nCount].dY = Convert.ToDouble(txtHighY.Text);
                AVisionProBuild.GetType(nType).m_pstLimitHigh[m_nCount].dZ = Convert.ToDouble(txtHighZ.Text);
                AVisionProBuild.GetType(nType).m_pstLimitHigh[m_nCount].dAX = Convert.ToDouble(txtHighAX.Text);
                AVisionProBuild.GetType(nType).m_pstLimitHigh[m_nCount].dAY = Convert.ToDouble(txtHighAY.Text);
                AVisionProBuild.GetType(nType).m_pstLimitHigh[m_nCount].dAZ = Convert.ToDouble(txtHighAZ.Text);
            }
            catch (Exception exc)
            {
                AUtil.TopMostMessageBox.Show(exc.Message, "Connect Exception occurs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AVisionProBuild.GetType(nType).WriteIniLimit(m_nCount);

            // 2012.12.27
            string strTxt = "Limit Change: " + lblTypeName.Text;
            // 2015.02.11
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "Low_X: " + txtLowX.Text + "\tHigh_X: " + txtHighX.Text;
            // 2015.02.11
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "Low_Y: " + txtLowY.Text + "\tHigh_Y: " + txtHighY.Text;
            // 2015.02.11
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "Low_Z: " + txtLowZ.Text + "\tHigh_Z: " + txtHighZ.Text;
            // 2015.02.11
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "Low_AX: " + txtLowAX.Text + "\tHigh_AX: " + txtHighAX.Text;
            // 2015.02.11
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "Low_AY: " + txtLowAY.Text + "\tHigh_AY: " + txtHighAY.Text;
            // 2015.02.11
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "Low_AZ: " + txtLowAZ.Text + "\tHigh_AZ: " + txtHighAZ.Text;
            // 2015.02.11
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");

            //this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadData();
        }

        
        private void txtDoubleKeyPress(object sender, KeyPressEventArgs e)
        {
            AUtil.OnlyNumberDouble(ref e);
        }
    }
}
