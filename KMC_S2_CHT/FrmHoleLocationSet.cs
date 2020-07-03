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
    public partial class FrmHoleLocationSet : Form
    {
        private IntPtr m_hParent;

        private TextBox[] m_ptxtX = null;
        private TextBox[] m_ptxtY = null;
        private TextBox[] m_ptxtZ = null;

        public FrmHoleLocationSet(IntPtr hParent, int nType)
        {
            InitializeComponent();

            m_hParent = hParent;

            m_ptxtX = new TextBox[] { txtX_P1, txtX_P2, txtX_P3, txtX_P4 };
            m_ptxtY = new TextBox[] { txtY_P1, txtY_P2, txtY_P3, txtY_P4 };
            m_ptxtZ = new TextBox[] { txtZ_P1, txtZ_P2, txtZ_P3, txtZ_P4 };

            int i;
            string strType;
            for (i = 0; i < AVisionProBuild.GetTypeCount(); i++)
            {
                strType = AVisionProBuild.GetType(i).Name;

                cmbType.Items.Add(strType);
            }
            cmbType.SelectedIndex = nType;
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 2016.06.20
            lblTitle.Text = AUtil.GetXmlLanguage("Body") + ":" + cmbType.Text;

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
            AIniHoleLocation aIniHoleLocation = new AIniHoleLocation(cmbType.Text);
            aIniHoleLocation.Read();

            for(int i=0;i<ASDef._3D_POSITION_COUNT;i++)
            {
                m_ptxtX[i].Text = aIniHoleLocation.m_pstXYZ[i].dX.ToString("0.00");
                m_ptxtY[i].Text = aIniHoleLocation.m_pstXYZ[i].dY.ToString("0.00");
                m_ptxtZ[i].Text = aIniHoleLocation.m_pstXYZ[i].dZ.ToString("0.00");
            }
            txtCheckLength.Text = aIniHoleLocation.m_dCheckLength.ToString("0.00");
        }

        private void WriteData()
        {
            AIniHoleLocation aIniHoleLocation = new AIniHoleLocation(cmbType.Text);

            for (int i = 0; i < ASDef._3D_POSITION_COUNT; i++)
            {
                aIniHoleLocation.m_pstXYZ[i].dX = Convert.ToDouble(m_ptxtX[i].Text);
                aIniHoleLocation.m_pstXYZ[i].dY = Convert.ToDouble(m_ptxtY[i].Text);
                aIniHoleLocation.m_pstXYZ[i].dZ = Convert.ToDouble(m_ptxtZ[i].Text);
            }
            aIniHoleLocation.m_dCheckLength = Convert.ToDouble(txtCheckLength.Text);

            aIniHoleLocation.Write();

            // 2015.04.08
            string strTxt = "Hole Location Change: " + cmbType.Text;
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            for (int i = 0; i < ASDef._3D_POSITION_COUNT; i++)
            {
                strTxt = "P" + (i + 1).ToString() + "_X: " + m_ptxtX[i].Text;
                AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
                strTxt = "P" + (i + 1).ToString() + "_Y: " + m_ptxtY[i].Text;
                AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
                strTxt = "P" + (i + 1).ToString() + "_Z: " + m_ptxtZ[i].Text;
                AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            }
            strTxt = "Check Length: " + txtCheckLength.Text;
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
        }

        private void txtKeyPress_Double(object sender, KeyPressEventArgs e)
        {
            AUtil.OnlyNumberDouble(ref e);
        }
    }
}
