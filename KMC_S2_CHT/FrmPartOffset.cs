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
using ACom;

namespace KMC_S2_CHT
{
    public partial class FrmPartOffset : Form
    {
        // 2014.10.12
        public const int _WM_PARTOFFSET_CLOSE = ASDef._WM_USER + 1009;

        private FrmMain m_PMain = null;
        
        private TextBox[,] m_pptxtHoleX = null;
        private TextBox[,] m_pptxtHoleY = null;

        private TextBox[] m_ptxtCalibX = null;
        private TextBox[] m_ptxtCalibY = null;
        private TextBox[] m_ptxtCalibZ = null;

        private TextBox[] m_ptxtX = null;
        private TextBox[] m_ptxtY = null;
        private TextBox[] m_ptxtZ = null;

        private CheckBox[] m_pchkAutoFind = null; 
        private TextBox[] m_ptxtAutoX = null;
        private TextBox[] m_ptxtAutoY = null;
        private TextBox[] m_ptxtAutoZ = null;

        // 2011.08.08
        private int m_nType;
        
        public FrmPartOffset(FrmMain PMain, int nType)
        {
            InitializeComponent();

            m_PMain = PMain;
            // 2011.08.08
            m_nType = nType;

            //---------------------------------------------------------
            // 2020.03.12 ASDef._3D_POSITION_COUNT->4
            m_pptxtHoleX = new TextBox[4, 2] { 
                {txtHoleX_P1L, txtHoleX_P1R},
                {txtHoleX_P2L, txtHoleX_P2R},
                {txtHoleX_P3L, txtHoleX_P3R},
                {txtHoleX_P4L, txtHoleX_P4R}};
            m_pptxtHoleY = new TextBox[4, 2] { 
                {txtHoleY_P1L, txtHoleY_P1R},
                {txtHoleY_P2L, txtHoleY_P2R},
                {txtHoleY_P3L, txtHoleY_P3R},
                {txtHoleY_P4L, txtHoleY_P4R}};

            m_ptxtCalibX = new TextBox[4] { txtCalibX_P1, txtCalibX_P2, txtCalibX_P3, txtCalibX_P4 };
            m_ptxtCalibY = new TextBox[4] { txtCalibY_P1, txtCalibY_P2, txtCalibY_P3, txtCalibY_P4 };
            m_ptxtCalibZ = new TextBox[4] { txtCalibZ_P1, txtCalibZ_P2, txtCalibZ_P3, txtCalibZ_P4 };

            m_ptxtX = new TextBox[4] { txtX_P1, txtX_P2, txtX_P3, txtX_P4 };
            m_ptxtY = new TextBox[4] { txtY_P1, txtY_P2, txtY_P3, txtY_P4 };
            m_ptxtZ = new TextBox[4] { txtZ_P1, txtZ_P2, txtZ_P3, txtZ_P4 };

            m_pchkAutoFind = new CheckBox[4] { chkAutoFindP1, chkAutoFindP2, chkAutoFindP3, chkAutoFindP4 };
            m_ptxtAutoX = new TextBox[4] { txtAutoX_P1, txtAutoX_P2, txtAutoX_P3, txtAutoX_P4 };
            m_ptxtAutoY = new TextBox[4] { txtAutoY_P1, txtAutoY_P2, txtAutoY_P3, txtAutoY_P4 };
            m_ptxtAutoZ = new TextBox[4] { txtAutoZ_P1, txtAutoZ_P2, txtAutoZ_P3, txtAutoZ_P4 };
            //---------------------------------------------------------

            /* 2011.08.08
            int i;
            string strType;
            for (i = 0; i < AVisionProBuild.GetTypeCount(); i++)
            {
                strType = AVisionProBuild.GetType(i).Name;

                cmbType.Items.Add(strType);
            }
            cmbType.SelectedIndex = nType;
            */
            lblTypeName.Text = AVisionProBuild.GetType(nType).Name; ;
            // 2016.06.20
            lblTitle.Text = AUtil.GetXmlLanguage("Part") + " " + AUtil.GetXmlLanguage("Offset") + " " + AUtil.GetXmlLanguage("Setup");

            ReadData();
        }

        /* 2011.08.08
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblTypeName.Text = "  차종:" + cmbType.Text;
            ReadData();
        }
         * */

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
            // 2011.08.08
            AIniPartOffset aIniPartOffset = new AIniPartOffset(lblTypeName.Text);
            aIniPartOffset.Read();

            for (int i = 0; i < ASDef._3D_POSITION_COUNT; i++)
            {
                m_pptxtHoleX[i, 0].Text = aIniPartOffset.m_ppstHoleXY[i, 0].dX.ToString("0.00");
                m_pptxtHoleX[i, 1].Text = aIniPartOffset.m_ppstHoleXY[i, 1].dX.ToString("0.00");
                m_pptxtHoleY[i, 0].Text = aIniPartOffset.m_ppstHoleXY[i, 0].dY.ToString("0.00");
                m_pptxtHoleY[i, 1].Text = aIniPartOffset.m_ppstHoleXY[i, 1].dY.ToString("0.00");

                m_ptxtCalibX[i].Text = aIniPartOffset.m_pstCalibXYZ[i].dX.ToString("0.00");
                m_ptxtCalibY[i].Text = aIniPartOffset.m_pstCalibXYZ[i].dY.ToString("0.00");
                m_ptxtCalibZ[i].Text = aIniPartOffset.m_pstCalibXYZ[i].dZ.ToString("0.00");

                m_ptxtX[i].Text = aIniPartOffset.m_pstXYZ[i].dX.ToString("0.00");
                m_ptxtY[i].Text = aIniPartOffset.m_pstXYZ[i].dY.ToString("0.00");
                m_ptxtZ[i].Text = aIniPartOffset.m_pstXYZ[i].dZ.ToString("0.00");
            }
        }

        private void WriteData()
        {
            AIniPartOffset aIniPartOffset = new AIniPartOffset(lblTypeName.Text);
            
            for (int i = 0; i < ASDef._3D_POSITION_COUNT; i++)
            {
                aIniPartOffset.m_ppstHoleXY[i, 0].dX = Convert.ToDouble(m_pptxtHoleX[i, 0].Text);
                aIniPartOffset.m_ppstHoleXY[i, 1].dX = Convert.ToDouble(m_pptxtHoleX[i, 1].Text);
                aIniPartOffset.m_ppstHoleXY[i, 0].dY = Convert.ToDouble(m_pptxtHoleY[i, 0].Text);
                aIniPartOffset.m_ppstHoleXY[i, 1].dY = Convert.ToDouble(m_pptxtHoleY[i, 1].Text);

                aIniPartOffset.m_pstCalibXYZ[i].dX = Convert.ToDouble(m_ptxtCalibX[i].Text);
                aIniPartOffset.m_pstCalibXYZ[i].dY = Convert.ToDouble(m_ptxtCalibY[i].Text);
                aIniPartOffset.m_pstCalibXYZ[i].dZ = Convert.ToDouble(m_ptxtCalibZ[i].Text);

                aIniPartOffset.m_pstXYZ[i].dX = Convert.ToDouble(m_ptxtX[i].Text);
                aIniPartOffset.m_pstXYZ[i].dY = Convert.ToDouble(m_ptxtY[i].Text);
                aIniPartOffset.m_pstXYZ[i].dZ = Convert.ToDouble(m_ptxtZ[i].Text);
            }

            aIniPartOffset.Write();

            // 2015.04.08
            string strTxt = "Part Offset Change: " + lblTypeName.Text;
            AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            for (int i = 0; i < ASDef._3D_POSITION_COUNT; i++)
            {
                strTxt = "P" + (i + 1).ToString() + "_HoleL_X: " + m_pptxtHoleX[i, 0].Text;
                AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
                strTxt = "P" + (i + 1).ToString() + "_HoleL_Y: " + m_pptxtHoleY[i, 0].Text;
                AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
                strTxt = "P" + (i + 1).ToString() + "_HoleR_X: " + m_pptxtHoleX[i, 1].Text;
                AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
                strTxt = "P" + (i + 1).ToString() + "_HoleR_Y: " + m_pptxtHoleY[i, 1].Text;
                AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
                strTxt = "P" + (i + 1).ToString() + "_Calib_X: " + m_ptxtCalibX[i].Text;
                AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
                strTxt = "P" + (i + 1).ToString() + "_Calib_Y: " + m_ptxtCalibY[i].Text;
                AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
                strTxt = "P" + (i + 1).ToString() + "_Calib_Z: " + m_ptxtCalibZ[i].Text;
                AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
                strTxt = "P" + (i + 1).ToString() + "_X: " + m_ptxtX[i].Text;
                AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
                strTxt = "P" + (i + 1).ToString() + "_Y: " + m_ptxtY[i].Text;
                AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
                strTxt = "P" + (i + 1).ToString() + "_Z: " + m_ptxtZ[i].Text;
                AVisionProBuild.WriteLogFile(strTxt, ".Setup.txt");
            }
        }

        private void btnAutoFind_Click(object sender, EventArgs e)
        {
            // 2016.10.14
            /*
            ASDef._stXYZ[] pstXYZ = new ASDef._stXYZ[ASDef._3D_POSITION_COUNT];
	        int i;
	        double dRange, dMm;	        
	        dRange = Convert.ToDouble(txtAutoRange.Text);
            dMm = Convert.ToDouble(txtAutoMM.Text);

            double[] pdRange = new double[ASDef._3D_POSITION_COUNT];
            for (i = 0; i < ASDef._3D_POSITION_COUNT; i++)
	        {
                if (m_pchkAutoFind[i].Checked)
                {
                    pdRange[i] = dRange;
		        }
		        else
		        {
			        pdRange[i] = 0;
		        }
	        }
        	
	        m_PMain.RunAutoOffsetFind(ref pstXYZ, pdRange, dMm);

            for(i=0;i<ASDef._3D_POSITION_COUNT;i++)
	        {
                m_ptxtAutoX[i].Text = pstXYZ[i].dX.ToString("0.0");
		        m_ptxtAutoY[i].Text = pstXYZ[i].dY.ToString("0.0");
                m_ptxtAutoZ[i].Text = pstXYZ[i].dZ.ToString("0.0");
	        }
            */
            double[] pdAve = new double[3];
            double[] pdSum = new double[3];
            int i, nCount = 0;

            for (i = 0; i < ASDef._3D_POSITION_COUNT; i++)
            {
                //if (m_PMain.m_pchkUse[i].Checked)
                {
                    nCount++;
                    pdSum[0] += m_PMain.m_pstMeasure[i].stShift.dX;
                    pdSum[1] += m_PMain.m_pstMeasure[i].stShift.dY;
                    pdSum[2] += m_PMain.m_pstMeasure[i].stShift.dZ;
                }
            }
            for (i = 0; i < 3; i++)
            {
                pdAve[i] = pdSum[i] / nCount;
            }
            for (i = 0; i < ASDef._3D_POSITION_COUNT; i++)
            {
                m_ptxtX[i].Text = (pdAve[0] - m_PMain.m_pstMeasure[i].stShift.dX).ToString("0.00");
                m_ptxtY[i].Text = (pdAve[1] - m_PMain.m_pstMeasure[i].stShift.dY).ToString("0.00");
                m_ptxtZ[i].Text = (pdAve[2] - m_PMain.m_pstMeasure[i].stShift.dZ).ToString("0.00");
            }
        }
                
        // 2011.08.08
        private void btnFindLostP1_Click(object sender, EventArgs e)
        {
            int nPosition = 0;
            ASDef._stXYZ stAuto;
            stAuto = default(ASDef._stXYZ);
            // 2020.03.12
            //m_PMain.FindLost1Point(nPosition, ref stAuto);

            m_ptxtAutoX[nPosition].Text = stAuto.dX.ToString("0.0");
            m_ptxtAutoY[nPosition].Text = stAuto.dY.ToString("0.0");
            m_ptxtAutoZ[nPosition].Text = stAuto.dZ.ToString("0.0");
        }

        private void btnFindLostP2_Click(object sender, EventArgs e)
        {
            int nPosition = 1;
            ASDef._stXYZ stAuto;
            stAuto = default(ASDef._stXYZ);
            // 2020.03.12
            //m_PMain.FindLost1Point(nPosition, ref stAuto);

            m_ptxtAutoX[nPosition].Text = stAuto.dX.ToString("0.0");
            m_ptxtAutoY[nPosition].Text = stAuto.dY.ToString("0.0");
            m_ptxtAutoZ[nPosition].Text = stAuto.dZ.ToString("0.0");
        }

        private void btnFindLostP3_Click(object sender, EventArgs e)
        {
            int nPosition = 2;
            ASDef._stXYZ stAuto;
            stAuto = default(ASDef._stXYZ);
            // 2020.03.12
            //m_PMain.FindLost1Point(nPosition, ref stAuto);

            m_ptxtAutoX[nPosition].Text = stAuto.dX.ToString("0.0");
            m_ptxtAutoY[nPosition].Text = stAuto.dY.ToString("0.0");
            m_ptxtAutoZ[nPosition].Text = stAuto.dZ.ToString("0.0");
        }

        private void btnFindLostP4_Click(object sender, EventArgs e)
        {
            int nPosition = 3;
            ASDef._stXYZ stAuto;
            stAuto = default(ASDef._stXYZ);
            // 2020.03.12
            //m_PMain.FindLost1Point(nPosition, ref stAuto);

            m_ptxtAutoX[nPosition].Text = stAuto.dX.ToString("0.0");
            m_ptxtAutoY[nPosition].Text = stAuto.dY.ToString("0.0");
            m_ptxtAutoZ[nPosition].Text = stAuto.dZ.ToString("0.0");
        }

        // 2014.10.12
        private void FrmPartOffset_FormClosed(object sender, FormClosedEventArgs e)
        {
            AUtil.PostMessage(m_PMain.Handle, _WM_PARTOFFSET_CLOSE, 0, 0);
        }

        private void txtKeyPress_Double(object sender, KeyPressEventArgs e)
        {
            AUtil.OnlyNumberDouble(ref e);
        }
    }
}
