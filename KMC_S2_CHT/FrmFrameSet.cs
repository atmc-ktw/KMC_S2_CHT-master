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

namespace KMC_S2_CHT
{
    public partial class FrmFrameSet : Form
    {
        private IntPtr m_hParent;
        private int m_nPosition;

        // 2016.10.11
        // 2016.06.17
        public FrmFrameSet(IntPtr hParent, int nType, int nPosition)
        //public FrmFrameSet(IntPtr hParent, int nPosition)
        {
            InitializeComponent();

            m_hParent = hParent;

            m_nPosition = nPosition;

            // 2016.10.11
            // 2016.06.17
            int i;
            string strType;
            for (i = 0; i < AVisionProBuild.GetTypeCount(); i++)
            {
                strType = AVisionProBuild.GetType(i).Name;

                cmbType.Items.Add(strType);
            }
                        
            cmbType.SelectedIndex = nType;

            lblTitle.Text = "P" + (m_nPosition + 1).ToString() + "  :" + cmbType.Text;
            ReadData();            
        }

        // 2016.10.11
        // 2016.06.17
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 2011.08.04
            lblTitle.Text = "P" + (m_nPosition + 1).ToString() + "  :" + cmbType.Text;
            ReadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            WriteData();
            MessageBox.Show("SAVE SUCCESS", "SAVE", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ReadData()
        {
            // 2016.10.11
            // 2016.06.17
            AIniFrame aIniFrame = new AIniFrame(cmbType.Text, m_nPosition);
            //AIniFrame aIniFrame = new AIniFrame(m_nPosition);

            aIniFrame.Read();

            txtX_C.Text = aIniFrame.m_stCommon.dX.ToString("0.000");
            txtY_C.Text = aIniFrame.m_stCommon.dY.ToString("0.000");
            txtZ_C.Text = aIniFrame.m_stCommon.dZ.ToString("0.000");
            txtAX_C.Text = aIniFrame.m_stCommon.dAX.ToString("0.000");
            txtAY_C.Text = aIniFrame.m_stCommon.dAY.ToString("0.000");
            txtAZ_C.Text = aIniFrame.m_stCommon.dAZ.ToString("0.000");

            // 2016.10.11
            txtX_P.Text = aIniFrame.m_stPose.dX.ToString("0.000");
            txtY_P.Text = aIniFrame.m_stPose.dY.ToString("0.000");
            txtZ_P.Text = aIniFrame.m_stPose.dZ.ToString("0.000");
            txtAX_P.Text = aIniFrame.m_stPose.dAX.ToString("0.000");
            txtAY_P.Text = aIniFrame.m_stPose.dAY.ToString("0.000");
            txtAZ_P.Text = aIniFrame.m_stPose.dAZ.ToString("0.000");
            
        }

        private void WriteData()
        {
            // 2016.10.11
            // 2016.06.17
            AIniFrame aIniFrame = new AIniFrame(cmbType.Text, m_nPosition);
            //AIniFrame aIniFrame = new AIniFrame(m_nPosition);

            aIniFrame.m_stCommon.dX = Convert.ToDouble(txtX_C.Text);
            aIniFrame.m_stCommon.dY = Convert.ToDouble(txtY_C.Text);
            aIniFrame.m_stCommon.dZ = Convert.ToDouble(txtZ_C.Text);
            aIniFrame.m_stCommon.dAX = Convert.ToDouble(txtAX_C.Text);
            aIniFrame.m_stCommon.dAY = Convert.ToDouble(txtAY_C.Text);
            aIniFrame.m_stCommon.dAZ = Convert.ToDouble(txtAZ_C.Text);

            // 2016.10.11
            aIniFrame.m_stPose.dX = Convert.ToDouble(txtX_P.Text);
            aIniFrame.m_stPose.dY = Convert.ToDouble(txtY_P.Text);
            aIniFrame.m_stPose.dZ = Convert.ToDouble(txtZ_P.Text);
            aIniFrame.m_stPose.dAX = Convert.ToDouble(txtAX_P.Text);
            aIniFrame.m_stPose.dAY = Convert.ToDouble(txtAY_P.Text);
            aIniFrame.m_stPose.dAZ = Convert.ToDouble(txtAZ_P.Text);
                        
            aIniFrame.Write();

            // 2016.10.11
            // 2015.04.08
            string strTxt = "Frame Setting Change(P" + (m_nPosition + 1).ToString() + "):" + cmbType.Text;

            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "Common_X: " + txtX_C.Text;
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "Common_Y: " + txtY_C.Text;
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "Common_Z: " + txtZ_C.Text;
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "Common_AX: " + txtAX_C.Text;
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "Common_AY: " + txtAY_C.Text;
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "Common_AZ: " + txtAZ_C.Text;
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");

            // 2016.10.11
            strTxt = "Pose_X: " + txtX_P.Text;
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "Pose_Y: " + txtY_P.Text;
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "Pose_Z: " + txtZ_P.Text;
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "Pose_AX: " + txtAX_P.Text;
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "Pose_AY: " + txtAY_P.Text;
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            strTxt = "Pose_AZ: " + txtAZ_P.Text;
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            
        }
        
        private void txtKeyPress_Double(object sender, KeyPressEventArgs e)
        {
            AUtil.OnlyNumberDouble(ref e);
        }
    }
}
