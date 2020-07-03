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
using Cognex.VisionPro.Caliper;
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
    public partial class ATbEdtFindCorner : Form
    {
        private AFindCorner m_aFindCorner = null;
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL)
        private AAcqFifo m_aAcqFifo = null;
#endif
        private APoint m_aPoint = null;

        // 2014.03.27
        private AIniFindCorner m_aIni = null;
        private bool m_IsInitializing = false;

        private int m_nType = 0;
        private int m_nPoint = 0;
        private int m_nToolIndex = 0;

        private ICogImage m_cogImage = null;

        // 2012.02.19
        private bool m_bLive = false;

        public ATbEdtFindCorner(int nType, int nPoint, int nToolIndex)
        {
            InitializeComponent();

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
            if (m_aPoint.GetToolCount("FindCorner") > m_nToolIndex)
            {
                m_aFindCorner = m_aPoint.GetTool("FindCorner", m_nToolIndex) as AFindCorner;
            }
            else
            {
                m_aFindCorner = new AFindCorner();

                m_aFindCorner.Name = AVisionProBuild.MakeName("FindCorner", DateTime.Now);
                m_aPoint.Add("FindCorner", m_aFindCorner);
            }

            cogFindCornerEditV2.Subject = m_aFindCorner.GetTool();

            InitLanguage();
            InitializeFindCorner();
        }

        private void InitLanguage()
        {
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

            btnSaveImage.Text = "       " + AUtil.GetXmlLanguage("Save_Image_File");
            btnLoadInit.Text = "        " + AUtil.GetXmlLanguage("Load_Init_Image");
            btnSaveVPP.Text = "    " + AUtil.GetXmlLanguage("Save_VPP");

            chkCalibCase.Text = AUtil.GetXmlLanguage("Calibration_Case");
          
        }

        private void InitializeFindCorner()
        {
            // 2014.03.27
            m_IsInitializing = true;
            m_aIni = new AIniFindCorner(m_nType, m_nPoint, m_nToolIndex);
            m_aIni.Read();
            cmbCalibCase.SelectedItem = m_aIni.CalibCase;

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
            // 2014.03.27
            m_IsInitializing = false;
        }

        private void statusStrip1_DoubleClick(object sender, EventArgs e)
        {
            AFrmCogToolGroup frm = new AFrmCogToolGroup(m_aPoint.m_cogtgPoint);
            // 2015.03.18
            frm.Show(this);
        }

        private void btnSaveVPP_Click(object sender, EventArgs e)
        {
            string strFName;
            strFName = ASDef._INI_PATH + "\\Img\\" + AVisionProBuild.ToolName(m_nType, m_nPoint, m_aFindCorner.Name) + ".bmp";
            FileInfo fileDel = new FileInfo(strFName);
            if (fileDel.Exists)
            {
                fileDel.Delete();
            }

            m_aFindCorner.Name = AVisionProBuild.MakeName("FindCorner", DateTime.Now);
            AVisionProBuild.SaveVpp(m_nType);

            strFName = ASDef._INI_PATH + "\\Img\\" + AVisionProBuild.ToolName(m_nType, m_nPoint, m_aFindCorner.Name) + ".bmp";
            AVisionProBuild.SaveImg(strFName, m_cogImage);

            // 2014.03.31
            m_aIni.Write();
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
                    // 2013.07.22
                    if (aIniExposure.m_nExposure > 0)
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
            MessageBox.Show("Vpp is Saved!");
        }

        private void btnAcquireSingle_Click(object sender, EventArgs e)
        {
            // 2016.12.01
            chkRun.Visible = false;

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
            if (btnAcquireLive.Text != "        " + AUtil.GetXmlLanguage("Acquire_Live"))
            {
                // 2011.04.21 Live
                //btnAcquireLive.Text = "        " + AUtil.GetXmlLanguage("Acquire_Live");
                //m_aAcqFifo.StopLiveAcquisition(cogDisplay);
                btnAcquireLive_Click(null, null);
            }

            try
            {
                // 2012.04.25
                AVisionProBuild.Acq(m_nType, m_nPoint, ref m_cogImage);

                // 2014.03.27
                m_aFindCorner.InputImage = RunCalibImage();
                
            }
            catch
            {
            }
            // 2011.06.09
            lblFileName.Text = "";
        }

        private void btnAcquireLive_Click(object sender, EventArgs e)
        {
            if (btnAcquireLive.Text == "        " + AUtil.GetXmlLanguage("Acquire_Live"))
            {
                btnAcquireLive.Text = "        " + AUtil.GetXmlLanguage("Acquire_Stop");

                tmrLive.Enabled = true;
                // 2012.02.19
                m_bLive = true;

                lblFileName.Text = "";
            }
            else
            {
                btnAcquireLive.Text = "        " + AUtil.GetXmlLanguage("Acquire_Live");
                // 2012.02.19
                //tmrLive.Enabled = false;
                m_bLive = false;
            }
        }

        public CogImage8Grey GetImage8Grey()
        {
            if (m_cogImage == null)
                return null;

            return CogImageConvert.GetIntensityImage(m_cogImage, 0, 0, m_cogImage.Width, m_cogImage.Height);
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            stslblTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void tmrLive_Tick(object sender, EventArgs e)
        {
            // 2012.02.19
            tmrLive.Enabled = false;
            try
            {
                // 2012.04.25
                AVisionProBuild.Acq(m_nType, m_nPoint, ref m_cogImage);
                m_aFindCorner.InputImage = RunCalibImage();
            }
            catch
            {
            }

            // 2012.06.07
            GC.Collect();

            // 2012.02.19
            if (m_bLive == true)
                tmrLive.Enabled = true;
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

        private void btnLoadBefore_Click(object sender, EventArgs e)
        {
            string strFileName = AVisionProBuild.BeforeImg(ref m_cogImage);
            if (strFileName != "")
            {
                m_aPoint.m_strLoadFileName = strFileName;
                // 2014.03.27
                m_aFindCorner.InputImage = RunCalibImage();
            }
            lblFileName.Text = strFileName;

            // 2014.07.29
            if (chkRun.Checked)
            {
                cogFindCornerEditV2.Subject.Run();
            }
        }

        private void btnLoadNext_Click(object sender, EventArgs e)
        {
            string strFileName = AVisionProBuild.NextImg(ref m_cogImage);
            if (strFileName != "")
            {
                m_aPoint.m_strLoadFileName = strFileName;
                // 2014.03.27
                m_aFindCorner.InputImage = RunCalibImage();
            }
            // 2011.06.09
            lblFileName.Text = strFileName;

            // 2014.07.29
            if (chkRun.Checked)
            {
                cogFindCornerEditV2.Subject.Run();
            }
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            string strDateTimeNow = DateTime.Now.ToString("yyyy_MM_dd_HHmmss");
            // 2012.01.17
            //AVisionProBuild.SaveImg(AVisionProBuild.m_strResultPath + "\\" + strDateTimeNow + ".BMP", cogDisplay);
            AVisionProBuild.SaveImg(AVisionProBuild.m_strResultPath + "\\" + strDateTimeNow + ".BMP", m_cogImage);
        }

        private void ATbEdtFindCorner_FormClosed(object sender, FormClosedEventArgs e)
        {
            tmrLive.Enabled = false;
            tmrTime.Enabled = false;

            // 2017.01.09
            cogFindCornerEditV2.Subject = null;

            // 2015.03.17
            cogFindCornerEditV2.Dispose();

            // 2017.01.09
            m_aFindCorner = null;
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL)
            m_aAcqFifo = null;
#endif
            m_aPoint = null;

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
            AUtil.OnlyNumberUDouble(ref e);
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

        // 2014.03.27
        private void btnLoadInit_Click(object sender, EventArgs e)
        {
            string strFName;
            strFName = ASDef._INI_PATH + "\\Img\\" + "Init_" + AVisionProBuild.ToolName(m_nType, m_nPoint, "FindCorner") + ".bmp";
            if (AVisionProBuild.LoadImg(strFName, ref m_cogImage) == true)
            {
                m_aFindCorner.InputImage = RunCalibImage();

                m_aPoint.m_strLoadFileName = strFName;

                lblFileName.Text = strFName;
            }
        }

        // 2014.03.27
        private ICogImage RunCalibImage()
        {
            return m_aPoint.RunCalibImage(m_cogImage, m_aIni.CalibCase);
        }

        // 2014.03.27
        private void chkCalibCase_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCalibCase.Checked)
            {
                cmbCalibCase.Enabled = true;
            }
            else
            {
                cmbCalibCase.Enabled = false;
            }
        }
        // 2014.03.27
        private void chkCalibCase_Click(object sender, EventArgs e)
        {
            AFrmPW dlgPW = new AFrmPW(this.Handle);
            dlgPW.ShowDialog(this);

            if (dlgPW.m_bPW)
            {
                chkCalibCase.Checked = true;
            }
            else
            {
                chkCalibCase.Checked = false;
            }
        }

        // 2014.03.27
        private void cmbCalibCase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_IsInitializing == false)
            {
                m_aIni.CalibCase = cmbCalibCase.SelectedItem.ToString();
            }


            if (m_aPoint.IsCalib(m_aIni.CalibCase) == false)
            {
                stslblStatus.Text = AUtil.GetXmlLanguage("Not_Calibrated");
                stslblStatus.ForeColor = Color.Crimson;
            }
            else
            {
                stslblStatus.Text = AUtil.GetXmlLanguage("Calibrated");
                stslblStatus.ForeColor = Color.ForestGreen;
            }
        }

        // 2014.10.12
        public void SetInputImage(ICogImage InputImage)
        {
            // 2016.11.20
            //m_aFindCorner.InputImage = m_aPoint.RunCalibImage(InputImage, m_aIni.CalibCase);
            m_aFindCorner.InputImage = InputImage;
        }

        // 2014.10.24-----------------------------------
        private void LoadImageFile(string strImageFile)
        {
            // 2016.12.01
            chkRun.Visible = false;

            if (AVisionProBuild.LoadImg(strImageFile, ref m_cogImage) == true)
            {
                m_aFindCorner.InputImage = RunCalibImage();

                m_aPoint.m_strLoadFileName = strImageFile;

                lblFileName.Text = strImageFile;
            }
        }

        private void LoadImageDirectory(string strImagePath)
        {
            // 2016.12.01
            chkRun.Visible = true;

            string strFileName = AVisionProBuild.LoadDir(strImagePath, ref m_cogImage);
            if (strFileName != "")
            {
                m_aPoint.m_strLoadFileName = strFileName;

                m_aFindCorner.InputImage = RunCalibImage();

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
