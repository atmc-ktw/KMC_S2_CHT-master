//#define _USE_BASLER_PYLON
//#define _USE_IMAGING_CONTROL
// 2014.10.30
//#define _USE_1Camera

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Cognex.VisionPro;
using Cognex.VisionPro.CalibFix;
using Cognex.VisionPro.ToolGroup;
using Atmc;
using System.Threading;

#if _USE_BASLER_PYLON
using BaslerPylon;
#elif _USE_IMAGING_CONTROL
using ImagingControl;
#endif

namespace AVisionPro
{
    public partial class ATbCalibCheckerboard : Form
    {
        private ACalibCheckerboard m_aCalibCheckerboard = null;
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL)
        private AAcqFifo m_aAcqFifo = null;
#endif
        private APoint m_aPoint = null;
        private ADisplay m_aDisplay = null;
        
        private int m_nType = 0;
        private int m_nPoint = 0;
        private int m_nToolIndex = 0;

        // 2012.01.17
        private ICogImage m_cogImage = null;

        // 2012.02.19
        private bool m_bLive = false;

        public ATbCalibCheckerboard(int nType, int nPoint, int nToolIndex)
        {
            InitializeComponent();
            cogDisplayStatusBar.Display = cogDisplay;
            m_aPoint = AVisionProBuild.GetPoint(nType, nPoint);
            m_nType = nType;
            m_nPoint = nPoint;
            m_nToolIndex = nToolIndex;

            // 2014.10.30
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL && !_USE_1Camera)
            if (m_aPoint.GetToolCount("AcqFifo") > 0)
#endif
            {
                // 2014.10.30
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL && !_USE_1Camera)
                m_aAcqFifo = m_aPoint.GetTool("AcqFifo", 0) as AAcqFifo;
#elif _USE_1Camera
                m_aAcqFifo = AVisionProBuild.GetAcq();
#endif
            }
            // 2016.07.29
            if (m_aPoint.GetToolCount("CalibCheckerboard") > m_nToolIndex)
            {
                m_aCalibCheckerboard = m_aPoint.GetTool("CalibCheckerboard", m_nToolIndex) as ACalibCheckerboard;
            }
            else
            {                    
                m_aCalibCheckerboard = new ACalibCheckerboard();

                m_aCalibCheckerboard.Name = AVisionProBuild.MakeName("CalibCheckerboard", DateTime.Now);
                m_aPoint.Add("CalibCheckerboard", m_aCalibCheckerboard);
            }
            
            m_aDisplay = new ADisplay(cogDisplay, "");
            lblTitle.Text = AVisionProBuild.GetTypeName(m_nType) + " [" + m_aPoint.Name + "]";
            
            //m_aDisplay.Display.Image = m_aCalibCheckerboard.InputImage;
            //m_aDisplay.Display.Fit(true);
            InitLanguage();
            // 2011.10.07 위치이동
            InitializeCalibration();
        }

        // 2013.12.02
        private void InitLanguage()
        {
            // Common------------
            grpbxAcquisition.Text = AUtil.GetXmlLanguage("Acquisition");

            lblExposure.Text = AUtil.GetXmlLanguage("Exposure");
            lblContrast.Text = AUtil.GetXmlLanguage("Contrast");
            lblBrightness.Text = AUtil.GetXmlLanguage("Brightness");

            btnAcquireSingle.Text = "        " + AUtil.GetXmlLanguage("Acquire_Single");
            btnAcquireLive.Text = "        " + AUtil.GetXmlLanguage("Acquire_Live");
            btnLoadImage.Text = "       " + AUtil.GetXmlLanguage("Load_Image_File");
            btnLoadDirectory.Text = "       " + AUtil.GetXmlLanguage("Load_Image_Directory");
            // 2016.01.19
            btnLoadBefore.Text = "     " + AUtil.GetXmlLanguage("Before") + "[B]";
            btnLoadNext.Text = "    " + AUtil.GetXmlLanguage("Next") + "[N]";

            btnLoadInit.Text = "        " + AUtil.GetXmlLanguage("Load_Init_Image");
            btnSaveImage.Text = "       " + AUtil.GetXmlLanguage("Save_Image_File");

            btnSaveVPP.Text = "    " + AUtil.GetXmlLanguage("Save_VPP");
            btnClose.Text = "    " + AUtil.GetXmlLanguage("Close");

            // 2011.10.07
            stslblStatus.Text = AUtil.GetXmlLanguage("Not_Calibrated");
            stslblStatus.ForeColor = Color.Crimson;
            //AFrmCalibCheckerboard---------------------
            btnLoadCalibImage.Text = "       " + AUtil.GetXmlLanguage("Load_Calibration_Image");
            grpbxSetting.Text = AUtil.GetXmlLanguage("Setting");
            grpbxPlate.Text = AUtil.GetXmlLanguage("Calibration_Plate");
            lblSizeX.Text = AUtil.GetXmlLanguage("Size_X");
            lblSizeY.Text = AUtil.GetXmlLanguage("Size_Y");
            chkMark.Text = AUtil.GetXmlLanguage("Fiducial_Mark");
            grpbxOrigin.Text = AUtil.GetXmlLanguage("Origin");
            lblOriginX.Text = AUtil.GetXmlLanguage("Origin") + " X";
            lblOriginY.Text = AUtil.GetXmlLanguage("Origin") + " Y";
            lblX_AxisRotation.Text = AUtil.GetXmlLanguage("X_Axis_Rotation");
            chkSwap.Text = AUtil.GetXmlLanguage("Swap_Handedness");
            grpbxResult.Text = AUtil.GetXmlLanguage("Result");
            btnCompute.Text = "           " + AUtil.GetXmlLanguage("Compute_Calibration");
        }

        private void InitializeCalibration()
        {
            switch(m_aCalibCheckerboard.ComputationMode)
            {
                case CogCalibFixComputationModeConstants.Linear:
                    rdoLinear.Checked = true;
                    chkShowUndistort.Checked = false;
                    chkShowUndistort.Enabled = false;
                    break;
                case CogCalibFixComputationModeConstants.PerspectiveAndRadialWarp:
                    rdoNonlinear.Checked = true;
                    chkShowUndistort.Enabled = true;
                    break;
            }
            
            switch(m_aCalibCheckerboard.Fiducial)
            {
                case CogCalibCheckerboardFiducialConstants.StandardRectangles:
                    chkMark.Checked = true;
                    break;
                case CogCalibCheckerboardFiducialConstants.None:
                    chkMark.Checked = false;
                    break;
            }

            if (m_aCalibCheckerboard.Calibrated == true)
            {
                // 2013.12.02
                stslblStatus.Text = AUtil.GetXmlLanguage("Calibrated");
                stslblStatus.ForeColor = Color.ForestGreen;                
            }

            chkSwap.Checked = m_aCalibCheckerboard.SwapHandedness;
            txtSizeX.Text = m_aCalibCheckerboard.SizeX.ToString();
            txtSizeY.Text = m_aCalibCheckerboard.SizeY.ToString();
            numUpDnX.Value= (decimal)m_aCalibCheckerboard.OriginX;
            numUpDnY.Value = (decimal)m_aCalibCheckerboard.OriginY;
            numUpDnRotation.Value = (decimal)(m_aCalibCheckerboard.OriginRotation / Math.PI * 180);

            /*
            btnLoadCalibImage_Click(null, null);
            m_aCalibCheckerboard.GrabCalibrationImage(m_aDisplay);
            if (m_aCalibCheckerboard.Calibrate(m_aDisplay, chkShowUndistort.Checked) == true)
            {
                m_aCalibCheckerboard.GetResultToList(lstvwResult);
                stslblStatus.Text = "Calibrated!";
                stslblStatus.ForeColor = Color.ForestGreen;                
            }
            */

            m_aCalibCheckerboard.CoordinateAxes_DraggingStopped += new ACalibCheckerboard.SendMes(CoordinateAxes_DraggingStopped);

            try
            {
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL)
                txtExposure.Text = m_aAcqFifo.Exposure.ToString();
                txtContrast.Text = m_aAcqFifo.Contrast.ToString();
                txtBrightness.Text = m_aAcqFifo.Brightness.ToString();
#elif _USE_BASLER_PYLON
                txtExposure.Text = ABaslerPylon.GetExposureTime(m_aPoint.m_strDevName).ToString();
                txtContrast.Text = "";
                txtBrightness.Text = "";
#elif _USE_IMAGING_CONTROL
                txtExposure.Text = AImagingControl.m_rngpExposure.Value.ToString();
                txtContrast.Text = "";
                txtBrightness.Text = AImagingControl.m_rngpBrightness.Value.ToString();
#endif
            }
            catch
            {
                txtExposure.Text = "0.5";
                txtContrast.Text = "0.5";
                txtBrightness.Text = "0.5";
            }
        }

        private void btnAcquireSingle_Click(object sender, EventArgs e)
        {
            //m_aDisplay.ClearAll();
            m_aDisplay.ClearExcludeImage();
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL)
            // 2012.04.24
            m_aAcqFifo.Exposure = Convert.ToDouble(txtExposure.Text);
            /* 2015.10.18
            if (m_aAcqFifo.AcqFifoTool.Operator != null)
            {
                if (m_aAcqFifo.GetFrameGrabberName().Contains("acA2500"))
                {
                    txtExposure.Text = m_aAcqFifo.Exposure.ToString();
                }
            }
            */
            m_aAcqFifo.Contrast = Convert.ToDouble(txtContrast.Text);
            m_aAcqFifo.Brightness = Convert.ToDouble(txtBrightness.Text);
#elif _USE_BASLER_PYLON
            // 2017.06.27
            if (ABaslerPylon.GetPixelFormat(m_aPoint.m_strDevName) != m_aPoint.m_strPixelFormat)
                ABaslerPylon.SetPixelFormat(m_aPoint.m_strDevName, m_aPoint.m_strPixelFormat);

            Int64 nVal = Convert.ToInt64(txtExposure.Text);
            nVal = ABaslerPylon.SetExposureTime(m_aPoint.m_strDevName, nVal);
            txtExposure.Text = nVal.ToString();
#elif _USE_IMAGING_CONTROL
            int nVal = Convert.ToInt32(txtExposure.Text);
            if (AImagingControl.m_rngpExposure.RangeMax < nVal)
            {
                nVal = AImagingControl.m_rngpExposure.RangeMax;
                txtExposure.Text = nVal.ToString();
            }
            if (AImagingControl.m_rngpExposure.RangeMin > nVal)
            {
                nVal = AImagingControl.m_rngpExposure.RangeMin;
                txtExposure.Text = nVal.ToString();
            }
            AImagingControl.m_rngpExposure.Value = nVal;

            nVal = Convert.ToInt32(txtBrightness.Text);
            if (AImagingControl.m_rngpBrightness.RangeMax < nVal)
            {
                nVal = AImagingControl.m_rngpBrightness.RangeMax;
                txtBrightness.Text = nVal.ToString();
            }
            if (AImagingControl.m_rngpBrightness.RangeMin > nVal)
            {
                nVal = AImagingControl.m_rngpBrightness.RangeMin;
                txtBrightness.Text = nVal.ToString();
            }
            AImagingControl.m_rngpBrightness.Value = nVal;
#endif

            if (btnAcquireLive.Text != AUtil.GetXmlLanguage("Acquire_Live"))
            {
                // 2011.04.21 Live
                //btnAcquireLive.Text = AUtil.GetXmlLanguage("Acquire_Live");
                //m_aAcqFifo.StopLiveAcquisition(cogDisplay);
                btnAcquireLive_Click(null, null);                
            }

            try
            {
                // 2012.04.25
                AVisionProBuild.Acq(m_nType, m_nPoint, ref m_cogImage);
                // 2012.01.17
                m_aDisplay.Image = m_cogImage;

                m_aDisplay.Display.Fit(true);
                m_aCalibCheckerboard.InputImage = m_aDisplay.GetImage8Grey();
            }
            catch
            {
            }

            // 2011.06.09
            lblFileName.Text = "";
        }

        private void btnAcquireLive_Click(object sender, EventArgs e)
        {
            m_aDisplay.ClearExcludeImage();
            if (btnAcquireLive.Text == AUtil.GetXmlLanguage("Acquire_Live"))
            {
                btnAcquireLive.Text = AUtil.GetXmlLanguage("Acquire_Stop");
                //----------------------------------
                // 2011.04.21 Live
                //m_aAcqFifo.Acquire(cogDisplay, AAcqFifo._emAcquireMode.LiveVideo);                
                tmrLive.Enabled = true;
                // 2012.02.19
                m_bLive = true;

                btnCompute.Enabled = false;
                //----------------------------------

                // 2011.06.09
                lblFileName.Text = "";
            }
            else
            {
                btnAcquireLive.Text = AUtil.GetXmlLanguage("Acquire_Live");
                //----------------------------------
                // 2011.04.21 Live
                //m_aAcqFifo.StopLiveAcquisition(cogDisplay);
                //btnAcquireSingle_Click(null, null);
                // 2012.02.19
                //tmrLive.Enabled = false;
                m_bLive = false;

                btnCompute.Enabled = true;
                //----------------------------------
            }
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            string strDateTimeNow = DateTime.Now.ToString("yyyy_MM_dd_HHmmss");
            // 2012.01.17
            //AVisionProBuild.SaveImg(AVisionProBuild.m_strResultPath + "\\" + strDateTimeNow + ".BMP", cogDisplay);
            AVisionProBuild.SaveImg(AVisionProBuild.m_strResultPath + "\\" + strDateTimeNow + ".BMP", m_cogImage);
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            // 2015.03.18
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                // 2014.10.24
                LoadImageFile(dlg.FileName);
            }
        }

        private void btnLoadInit_Click(object sender, EventArgs e)
        {
            m_aDisplay.ClearAll();
            string strFName;
            strFName = ASDef._INI_PATH + "\\Img\\" + AVisionProBuild.ToolName(m_nType, m_nPoint, m_aCalibCheckerboard.Name) + ".bmp";
            // 2011.05.07
            m_aDisplay.ClearAll();
            // 2012.01.17
            //if (AVisionProBuild.LoadImg(strFName, cogDisplay) == true)
            if (AVisionProBuild.LoadImg(strFName, ref m_cogImage) == true)
            {
                // 2012.01.17
                m_aDisplay.Image = m_cogImage;

                m_aDisplay.Display.Fit(true);
                m_aCalibCheckerboard.InputImage = m_aDisplay.GetImage8Grey();
                m_aPoint.m_strLoadFileName = strFName;
            }
        }

        private void btnLoadCalibImage_Click(object sender, EventArgs e)
        {
            m_aDisplay.ClearAll();
            m_aDisplay.Display.Image = m_aCalibCheckerboard.CalibrationImage;
            m_aDisplay.Display.Fit(true);

            m_aCalibCheckerboard.InputImage = m_aDisplay.GetImage8Grey();

            // 2014.12.28 by kdi
            m_cogImage = m_aCalibCheckerboard.InputImage;

            m_aCalibCheckerboard.ShowCalibratedOrigin(m_aDisplay, chkShowUndistort.Checked, false);
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            btnSaveVPP.Enabled = true;

            //if (MessageBox.Show("Do you want to compute the calibration?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            if (MessageBox.Show(AUtil.GetXmlLanguage("Do_you_want_to_compute_the_calibration") + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (rdoLinear.Checked)
                {
                    m_aCalibCheckerboard.ComputationMode = CogCalibFixComputationModeConstants.Linear;
                }
                else
                {
                    m_aCalibCheckerboard.ComputationMode = CogCalibFixComputationModeConstants.PerspectiveAndRadialWarp;
                }

                if (chkMark.Checked)
                {
                    m_aCalibCheckerboard.Fiducial = CogCalibCheckerboardFiducialConstants.StandardRectangles;
                }
                else
                {
                    m_aCalibCheckerboard.Fiducial = CogCalibCheckerboardFiducialConstants.None;
                }

                m_aCalibCheckerboard.SwapHandedness = chkSwap.Checked;

                try
                {
                    m_aCalibCheckerboard.SizeX = Convert.ToDouble(txtSizeX.Text);
                    m_aCalibCheckerboard.SizeY = Convert.ToDouble(txtSizeY.Text);
                }
                catch { }

                m_aCalibCheckerboard.OriginX = (double)numUpDnX.Value;
                m_aCalibCheckerboard.OriginY = (double)numUpDnY.Value;
                m_aCalibCheckerboard.OriginRotation = (((double)numUpDnRotation.Value) / 180) * Math.PI;

                m_aCalibCheckerboard.GrabCalibrationImage(m_aDisplay);
                if (m_aCalibCheckerboard.Calibrate(m_aDisplay, chkShowUndistort.Checked) == true)
                {
                    m_aCalibCheckerboard.GetResultToList(lstvwResult);
                    stslblStatus.Text = AUtil.GetXmlLanguage("Calibrated");
                    stslblStatus.ForeColor = Color.ForestGreen;
                }
            }            
        }

        private void numUpDownX_ValueChanged(object sender, EventArgs e)
        {
            if (m_aDisplay.GetInteractiveGraphics("Calibrated Origin") != null)
            {
                m_aCalibCheckerboard.Calibrated = false;
                m_aCalibCheckerboard.OriginX = (double)numUpDnX.Value;
                m_aCalibCheckerboard.ShowCalibratedOrigin(m_aDisplay, chkShowUndistort.Checked, chkSwap.Checked);
                // 2013.12.02
                stslblStatus.Text = AUtil.GetXmlLanguage("Not_Calibrated");
                stslblStatus.ForeColor = Color.Crimson;
            }
        }

        private void numUpDownY_ValueChanged(object sender, EventArgs e)
        {
            if (m_aDisplay.GetInteractiveGraphics("Calibrated Origin") != null)
            {
                m_aCalibCheckerboard.Calibrated = false;
                m_aCalibCheckerboard.OriginY = (double)numUpDnY.Value;
                m_aCalibCheckerboard.ShowCalibratedOrigin(m_aDisplay, chkShowUndistort.Checked, chkSwap.Checked);
                // 2013.12.02
                stslblStatus.Text = AUtil.GetXmlLanguage("Not_Calibrated");
                stslblStatus.ForeColor = Color.Crimson;
            }
        }

        private void numUpDownRotation_ValueChanged(object sender, EventArgs e)
        {
            if (m_aDisplay.GetInteractiveGraphics("Calibrated Origin") != null)
            {
                m_aCalibCheckerboard.Calibrated = false;
                m_aCalibCheckerboard.OriginRotation = (((double)numUpDnRotation.Value) / 180) * Math.PI;
                m_aCalibCheckerboard.ShowCalibratedOrigin(m_aDisplay, chkShowUndistort.Checked, chkSwap.Checked);
                stslblStatus.Text = AUtil.GetXmlLanguage("Not_Calibrated");
                stslblStatus.ForeColor = Color.Crimson;
            }
        }

        private void CoordinateAxes_DraggingStopped(object sender, EventArgs e)
        {
            btnOK.Visible = true;

            // 2011.07.10
            EnabledButton(false);
        }

        private void btnSaveVPP_Click(object sender, EventArgs e)
        {
            string strFName;
            strFName = ASDef._INI_PATH + "\\Img\\" + AVisionProBuild.ToolName(m_nType, m_nPoint, m_aCalibCheckerboard.Name) + ".bmp";
            FileInfo fileDel = new FileInfo(strFName);
            if (fileDel.Exists)
            {
                fileDel.Delete();
            }

            // 2017.06.08
            //m_aCalibCheckerboard.Name = AVisionProBuild.MakeName("CalibCheckerboard", DateTime.Now);

            AVisionProBuild.SaveVpp(m_nType);
            
            strFName = ASDef._INI_PATH + "\\Img\\" + AVisionProBuild.ToolName(m_nType, m_nPoint, m_aCalibCheckerboard.Name) + ".bmp";
            // 2012.01.17
            //AVisionProBuild.SaveImg(strFName, cogDisplay);
            AVisionProBuild.SaveImg(strFName, m_cogImage);

            // 2012.04.24
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL)
            /* 2015.10.18
            if (m_aAcqFifo.AcqFifoTool.Operator != null)
            {
                // 2013.05.15
                if (m_aAcqFifo.GetFrameGrabberName().Contains("acA2500"))
                {
                    AIniExposure aIniExposure = new AIniExposure(m_nType, m_nPoint);
                    aIniExposure.m_nExposure = Convert.ToInt64(txtExposure.Text);
                    aIniExposure.Write();
                }
            }
            */
#elif _USE_BASLER_PYLON
            AIniExposure aIniExposure = new AIniExposure(m_nType, m_nPoint);
            // 2015.12.09
            aIniExposure.m_dExposure = Convert.ToDouble(txtExposure.Text);
            if (aIniExposure.m_dExposure > 0)
                aIniExposure.Write();
#endif
            // 2014.10.30
#if _USE_1Camera
            CogSerializer.SaveObjectToFile(m_aAcqFifo.GetTool(), ASDef._INI_PATH + "\\1Camera.vpp", typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.Minimum);
#endif

            //MessageBox.Show("Tool is Saved!");
            // 2013.12.02
            MessageBox.Show(AUtil.GetXmlLanguage("Tool_is_Saved"));
            btnSaveVPP.Enabled = false;
        }

        private void lstvwResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvwResult.SelectedItems.Count != 0)
            {
                int i = lstvwResult.SelectedIndices[0];
                string strID = lstvwResult.Items[i].Text;

                if (strID != "")
                {
                    for (int j = 0; j < m_aDisplay.Display.InteractiveGraphics.Count; ++j)
                    {
                        if (m_aDisplay.Display.InteractiveGraphics[j] != null && m_aDisplay.Display.InteractiveGraphics[j].TipText == "Uncalibrated Point " + strID)
                        {
                            m_aDisplay.Display.InteractiveGraphics[j].Selected = true;
                        }
                    }
                }
                else
                {
                    for (int j = 0; j < m_aDisplay.Display.InteractiveGraphics.Count; ++j)
                    {
                        m_aDisplay.Display.InteractiveGraphics[j].Selected = false;
                    }
                }
            }
        }
        
        private void rdoLinear_Click(object sender, EventArgs e)
        {
            rdoLinear.Checked = true;
            rdoNonlinear.Checked = false;

            chkShowUndistort.Checked = false;
            chkShowUndistort.Enabled = false;
            m_aCalibCheckerboard.Uncalibrate();
            m_aDisplay.ClearOverlay();
            stslblStatus.Text = AUtil.GetXmlLanguage("Not_Calibrated");
            stslblStatus.ForeColor = Color.Crimson;
        }

        private void rdoNonlinear_Click(object sender, EventArgs e)
        {
            rdoNonlinear.Checked = true;
            rdoLinear.Checked = false;

            chkShowUndistort.Enabled = true;
            m_aCalibCheckerboard.Uncalibrate();
            m_aDisplay.ClearOverlay();
            stslblStatus.Text = AUtil.GetXmlLanguage("Not_Calibrated");
            stslblStatus.ForeColor = Color.Crimson;
        }

        private void chkMark_Click(object sender, EventArgs e)
        {
            m_aCalibCheckerboard.Uncalibrate();
            m_aDisplay.ClearOverlay();
            stslblStatus.Text = AUtil.GetXmlLanguage("Not_Calibrated");
            stslblStatus.ForeColor = Color.Crimson;
        }

        private void chkShowUndistort_CheckedChanged(object sender, EventArgs e)
        {
            if (m_aDisplay.Display.InteractiveGraphics.Count > 0)
            {
                m_aCalibCheckerboard.ShowCalibratedPoints(m_aDisplay, chkShowUndistort.Checked, chkSwap.Checked);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            btnOK.Visible = false;
            m_aCalibCheckerboard.GetAxesParam(m_aDisplay, chkShowUndistort.Checked);
            numUpDnX.Value = (decimal)m_aCalibCheckerboard.OriginX;
            numUpDnY.Value = (decimal)m_aCalibCheckerboard.OriginY;
            numUpDnRotation.Value = (decimal)((m_aCalibCheckerboard.OriginRotation * 180) / Math.PI);
            stslblStatus.Text = AUtil.GetXmlLanguage("Not_Calibrated");
            stslblStatus.ForeColor = Color.Crimson;

            m_aCalibCheckerboard.ShowCalibratedOrigin(m_aDisplay, chkShowUndistort.Checked, chkSwap.Checked);

            // 2011.07.10
            EnabledButton(true);
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            stslblTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void cogDisplay_DoubleClick(object sender, EventArgs e)
        {
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL)
            if (m_aAcqFifo != null)
            {
                AFrmCogAcqFifo frm = new AFrmCogAcqFifo(m_aAcqFifo);
                // 2015.03.18
                frm.Show(this);
            }
            else
            {
                MessageBox.Show(AUtil.GetXmlLanguage("Acquisition_Tool_Is_Not_Exist"));
            }
#elif _USE_IMAGING_CONTROL
            AImagingControl.ShowPropertyDialog();
#endif
        }

        private void statusStrip1_DoubleClick(object sender, EventArgs e)
        {
            AFrmCogToolGroup frm = new AFrmCogToolGroup(m_aPoint.m_cogtgPoint);
            // 2015.03.18
            frm.Show(this);
        }

        private void btnLoadDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();

            // 2014.01.19
            dlg.SelectedPath = AVisionProBuild.m_strResultPath;
            // 2015.03.18
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                // 2014.10.24
                LoadImageDirectory(dlg.SelectedPath);
            }
        }

        private void btnLoadNext_Click(object sender, EventArgs e)
        {
            // 2011.05.07
            m_aDisplay.ClearAll();
            // 2012.01.17
            //string strFileName = AVisionProBuild.NextImg(cogDisplay);
            string strFileName = AVisionProBuild.NextImg(ref m_cogImage);
            if (strFileName != "")
            {
                m_aPoint.m_strLoadFileName = strFileName;
                // 2012.01.17
                m_aDisplay.Image = m_cogImage;

                m_aCalibCheckerboard.InputImage = m_aDisplay.GetImage8Grey();
            }
            // 2011.06.09
            lblFileName.Text = strFileName;
        }

        // 2011.06.09
        private void btnLoadBefore_Click(object sender, EventArgs e)
        {
            m_aDisplay.ClearAll();
            // 2012.01.17
            //string strFileName = AVisionProBuild.BeforeImg(cogDisplay);
            string strFileName = AVisionProBuild.BeforeImg(ref m_cogImage);
            if (strFileName != "")
            {
                m_aPoint.m_strLoadFileName = strFileName;
                // 2012.01.17
                m_aDisplay.Image = m_cogImage;

                m_aCalibCheckerboard.InputImage = m_aDisplay.GetImage8Grey();
            }
            lblFileName.Text = strFileName;
        }

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            AFrmCogCalibCheckerboard frm = new AFrmCogCalibCheckerboard(m_aCalibCheckerboard);
            // 2015.03.18
            frm.Show(this);
        }

        // 2011.04.21 Live
        private void tmrLive_Tick(object sender, EventArgs e)
        {
            // 2012.02.19
            tmrLive.Enabled = false;

            try
            {
                // 2017.01.26
                m_aDisplay.m_cogDisplay.DrawingEnabled = false;
            
                // 2012.04.25
                AVisionProBuild.Acq(m_nType, m_nPoint, ref m_cogImage);
                // 2012.01.17
                m_aDisplay.Image = m_cogImage;
                // 2011.08.17
                //m_aDisplay.Display.Fit(true);
                m_aDisplay.AddCross();
                m_aCalibCheckerboard.InputImage = m_aDisplay.GetImage8Grey();
            }
            catch
            {
            }
            // 2017.01.26
            finally
            {
                m_aDisplay.m_cogDisplay.DrawingEnabled = true;
            }

            GC.Collect();

            // 2012.02.19
            if (m_bLive == true)
                tmrLive.Enabled = true;
        }

        // 2011.07.10
        private void EnabledButton(bool bEnabled)
        {
            btnAcquireSingle.Enabled = bEnabled;
            btnAcquireLive.Enabled = bEnabled;
            btnLoadInit.Enabled = bEnabled;
            btnSaveVPP.Enabled = bEnabled;
            btnLoadImage.Enabled = bEnabled;
            btnLoadDirectory.Enabled = bEnabled;
            btnLoadBefore.Enabled = bEnabled;
            btnLoadNext.Enabled = bEnabled;
            btnSaveImage.Enabled = bEnabled;

            btnLoadCalibImage.Enabled = bEnabled;
            chkMark.Enabled = bEnabled;
            chkSwap.Enabled = bEnabled;
            btnCompute.Enabled = bEnabled;
            chkShowUndistort.Enabled = bEnabled;
        }

        // 2011.10.31
        private void ATbCalibCheckerboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            tmrLive.Enabled = false;
            tmrTime.Enabled = false;

            // 2015.03.17
            cogDisplay.Dispose();
            cogDisplayStatusBar.Dispose();

            // 2017.01.09
            m_aCalibCheckerboard = null;
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL)
            m_aAcqFifo = null;
#endif
            m_aPoint = null;
            m_aDisplay = null;

        }

        private void txtExposure_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 2013.05.15
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL)
            /* 2015.10.18
            if (m_aAcqFifo.AcqFifoTool.Operator != null)
            {
                if (m_aAcqFifo.GetFrameGrabberName().Contains("acA2500"))
                {
                    AUtil.OnlyNumberUInt(ref e);
                    return;
                }
            }
            */
            AUtil.OnlyNumberUDouble(ref e);
#elif _USE_BASLER_PYLON            
            AUtil.OnlyNumberUInt(ref e);
            return;
#endif
            
        }

        private void txtUDoubleKeyPress(object sender, KeyPressEventArgs e)
        {

        }

        // 2013.06.03
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!base.ProcessCmdKey(ref msg, keyData))
            {

                if (keyData.Equals(Keys.B))
                {
                    btnLoadBefore_Click(btnLoadBefore, null);
                    return true;
                }

                else if (keyData.Equals(Keys.N))
                {
                    btnLoadNext_Click(btnLoadNext, null);
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return true;
            }
        }

        // 2014.10.24-----------------------------------
        private void LoadImageFile(string strImageFile)
        {
            m_aDisplay.ClearAll();
            if (AVisionProBuild.LoadImg(strImageFile, ref m_cogImage) == true)
            {
                m_aDisplay.Image = m_cogImage;

                m_aDisplay.Display.Fit(true);

                m_aCalibCheckerboard.InputImage = m_aDisplay.GetImage8Grey();

                m_aPoint.m_strLoadFileName = strImageFile;
                lblFileName.Text = strImageFile;
            }
        }

        private void LoadImageDirectory(string strImagePath)
        {
            m_aDisplay.ClearAll();

            string strFileName = AVisionProBuild.LoadDir(strImagePath, ref m_cogImage);
            if (strFileName != "")
            {
                m_aPoint.m_strLoadFileName = strFileName;
                m_aDisplay.Image = m_cogImage;

                m_aDisplay.Display.Fit(true);
                m_aCalibCheckerboard.InputImage = m_aDisplay.GetImage8Grey();

                lblFileName.Text = strFileName;
            }
        }

        private void btnLoadDirectory_DragDrop(object sender, DragEventArgs e)
        {
            string strImagePath = AUtil.ADragDrop.DoDragDrop(sender, e);

            if (strImagePath.Length > 0)
            {
                if (!Directory.Exists(strImagePath))
                    return;

                LoadImageDirectory(strImagePath);
            }
        }

        private void btnLoadDirectory_DragOver(object sender, DragEventArgs e)
        {
            AUtil.ADragDrop.DoDragOver(sender, e);
        }

        private void btnLoadImage_DragDrop(object sender, DragEventArgs e)
        {
            string strImageFile = AUtil.ADragDrop.DoDragDrop(sender, e);

            if (strImageFile.Length > 0)
            {
                if (!File.Exists(strImageFile))
                    return;

                LoadImageFile(strImageFile);
            }
        }

        private void btnLoadImage_DragOver(object sender, DragEventArgs e)
        {
            AUtil.ADragDrop.DoDragOver(sender, e);
        }

        //----------------------------------------------
    }
}
