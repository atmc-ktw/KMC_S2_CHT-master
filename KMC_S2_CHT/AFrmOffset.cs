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
    public partial class AFrmOffset : Form
    {
        private IntPtr m_hParent;

        private int m_nCount;
        
        private string m_strLoc;

        public AFrmOffset(IntPtr hParent, int nType, int nCount, string strLoc)
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
            // AFrmOffset------------
            lblTitle.Text = AUtil.GetXmlLanguage("Offset_Setting");
        }

        private void AFrmOffset_Load(object sender, EventArgs e)
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

            txtOffsetX.Text = String.Format("{0:f2}", AVisionProBuild.GetType(nType).m_pstOffset[m_nCount].dX);
            txtOffsetY.Text = String.Format("{0:f2}", AVisionProBuild.GetType(nType).m_pstOffset[m_nCount].dY);
            txtOffsetZ.Text = String.Format("{0:f2}", AVisionProBuild.GetType(nType).m_pstOffset[m_nCount].dZ);

            txtOffsetAX.Text = String.Format("{0:f2}", AVisionProBuild.GetType(nType).m_pstOffset[m_nCount].dAX);
            txtOffsetAY.Text = String.Format("{0:f2}", AVisionProBuild.GetType(nType).m_pstOffset[m_nCount].dAY);
            txtOffsetAZ.Text = String.Format("{0:f2}", AVisionProBuild.GetType(nType).m_pstOffset[m_nCount].dAZ);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int nType = cmbType.SelectedIndex;
            // 2016.04.04
            try
            {
                AVisionProBuild.GetType(nType).m_pstOffset[m_nCount].dX = Convert.ToDouble(txtOffsetX.Text);
                AVisionProBuild.GetType(nType).m_pstOffset[m_nCount].dY = Convert.ToDouble(txtOffsetY.Text);
                AVisionProBuild.GetType(nType).m_pstOffset[m_nCount].dZ = Convert.ToDouble(txtOffsetZ.Text);
                AVisionProBuild.GetType(nType).m_pstOffset[m_nCount].dAX = Convert.ToDouble(txtOffsetAX.Text);
                AVisionProBuild.GetType(nType).m_pstOffset[m_nCount].dAY = Convert.ToDouble(txtOffsetAY.Text);
                AVisionProBuild.GetType(nType).m_pstOffset[m_nCount].dAZ = Convert.ToDouble(txtOffsetAZ.Text);
            }
            catch (Exception exc)
            {
                AUtil.TopMostMessageBox.Show(exc.Message, "Connect Exception occurs", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AVisionProBuild.GetType(nType).WriteIniOffset(m_nCount);

            // 2012.12.27
            string strTxt = "Offset Change: " + lblTypeName.Text;
            // 2015.02.11
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "X: " + txtOffsetX.Text;
            // 2015.02.11
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "Y: " + txtOffsetY.Text;
            // 2015.02.11
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "Z: " + txtOffsetZ.Text;
            // 2015.02.11
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "AX: " + txtOffsetAX.Text;
            // 2015.02.11
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "AY: " + txtOffsetAY.Text;
            // 2015.02.11
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "AZ: " + txtOffsetAZ.Text;
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
