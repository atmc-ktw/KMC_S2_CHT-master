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
using Cognex.VisionPro.PMAlign;
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
    public partial class ATbPMAlign : Form
    {
        private enum _emRegionWorkType { TrainRegion = 0, SearchRegion };
        private APMAlign m_aPMAlign = null;
        private APMAligns m_aPMAligns = null;
        private List<APMAlign> m_lstAPMAlign = new List<APMAlign>();
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL)
        private AAcqFifo m_aAcqFifo = null;
#endif
        private APoint m_aPoint = null;
        private ADisplay m_aDisplay = null;
        private ADisplay m_aDisplayPattern = null;
        private _emRegionWorkType m_emRegionWorkType;
        private AIniPMAlign m_aIni = null;

        private int m_nType = 0;
        private int m_nPoint = 0;
        private int m_nToolIndex = 0;

        private int m_nPatternCurrentIndex = 0;
        private int m_nPatternTotalCount = 0;

        private bool m_IsToolExist = false;
        private bool m_IsInitializing = false;
        //private string m_strTrainedPattern = "";
        //private string m_strTrainedImage = "";
        //private string m_strIniImage = "";
        private CogImage8Grey m_cogimgMask;

        // 2012.01.17
        private ICogImage m_cogImage = null;

        // 2012.02.19
        private bool m_bLive = false;

        //** 2016.01.26 by kdi, Cancle 버튼 활성화
        private CogPMAlignPattern m_Pattern_Backup = null;
        //private CogImage8Grey m_MaskImage_Backup = null;
        private ICogRegion m_SearchRegion_Backup = null;
        //*/

        public ATbPMAlign(int nType, int nPoint, int nToolIndex)
        {
            InitializeComponent();
            cogDisplayStatusBar.Display = cogDisplay;
            m_aPoint = AVisionProBuild.GetPoint(nType, nPoint);
            m_nType = nType;
            m_nPoint = nPoint;
            m_nToolIndex = nToolIndex;

            //m_strTrainedImage = ASDef._INI_PATH + "\\IniImg\\TrainedImage_Type_" + m_nType.ToString() + "_Vision_" + m_nPoint.ToString();
            //m_strTrainedPattern = ASDef._INI_PATH + "\\IniImg\\Pattern_Type_" + m_nType.ToString() + "_Vision_" + m_nPoint.ToString();
            //m_strIniImage = ASDef._INI_PATH + "\\IniImg\\IniImage_Type_" + m_nType.ToString() + "_Vision_" + m_nPoint.ToString() + ".bmp";

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
            List<APMAligns> lstAPMAligns = new List<APMAligns>();

            if (m_aPoint.GetToolCount("PMAligns") > m_nToolIndex)
            {
                m_aPMAligns = m_aPoint.GetTool("PMAligns", m_nToolIndex) as APMAligns;
                lstAPMAligns = m_aPoint.GetTools("PMAligns") as List<APMAligns>;
                m_lstAPMAlign = lstAPMAligns[m_nToolIndex].GetTools() as List<APMAlign>;
                if (m_lstAPMAlign.Count > 0)
                {
                    m_IsToolExist = true;
                }
                else
                {
                    m_aPMAlign = new APMAlign();
                    m_aPMAlign.Name = AVisionProBuild.MakeName("PMAlign", DateTime.Now);

                    m_aPMAligns.Add(m_aPMAlign);

                    m_IsToolExist = false;
                }
            }
            else
            {
                m_aPMAligns = new APMAligns("PMAligns" + m_nToolIndex.ToString());
                m_aPMAlign = new APMAlign();
                m_aPMAlign.Name = AVisionProBuild.MakeName("PMAlign", DateTime.Now);

                m_aPMAligns.Add(m_aPMAlign);

                m_aPoint.Add("PMAligns", m_aPMAligns);

                lstAPMAligns = m_aPoint.GetTools("PMAligns") as List<APMAligns>;
                m_lstAPMAlign = lstAPMAligns[m_nToolIndex].GetTools() as List<APMAlign>;
                m_IsToolExist = false;
            }

            m_aDisplay = new ADisplay(cogDisplay, "");
            m_aDisplayPattern = new ADisplay(cogDisplayPattern, "");
            lblTitle.Text = AVisionProBuild.GetTypeName(m_nType) + " [" + m_aPoint.Name + "]";

            m_aIni = new AIniPMAlign(m_nType, m_nPoint, m_nToolIndex);
            m_aIni.Read();
            txtOriginX.Text = m_aIni.InitX;
            txtOriginY.Text = m_aIni.InitY;
            txtOriginAngle.Text = m_aIni.InitAngle;

            InitLanguage();
            InitializePMAlign(0);
            
            cogDisplay.Image = m_aPMAlign.InputImage;

            // 2014.12.27 by kdi
            m_cogImage = cogDisplay.Image;

            // 2012.06.03
            m_aPMAlign.ShowSearchRegion(m_aDisplay);

            m_aDisplay.Display.Fit(true);

            // 2016.06.22
            chkFixtureNPointToNPoint.Checked = m_aIni.FixtureNPointToNPoint;

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

            cmbPatternShape.Items.Clear();
            cmbPatternShape.Items.Add(AUtil.GetXmlLanguage("Entire_Image"));
            cmbPatternShape.Items.Add(AUtil.GetXmlLanguage("Circle"));
            cmbPatternShape.Items.Add(AUtil.GetXmlLanguage("Ellipse"));
            cmbPatternShape.Items.Add(AUtil.GetXmlLanguage("Rectangle"));
            cmbPatternShape.Items.Add(AUtil.GetXmlLanguage("RectangleAffine"));
            cmbPatternShape.Items.Add(AUtil.GetXmlLanguage("CircularAnnulusSection"));
            cmbPatternShape.Items.Add(AUtil.GetXmlLanguage("EllipticalAnnulusSection"));

            cmbRegionShape.Items.Clear();
            cmbRegionShape.Items.Add(AUtil.GetXmlLanguage("Entire_Image"));
            cmbRegionShape.Items.Add(AUtil.GetXmlLanguage("Circle"));
            cmbRegionShape.Items.Add(AUtil.GetXmlLanguage("Ellipse"));
            cmbRegionShape.Items.Add(AUtil.GetXmlLanguage("Rectangle"));
            cmbRegionShape.Items.Add(AUtil.GetXmlLanguage("RectangleAffine"));
            cmbRegionShape.Items.Add(AUtil.GetXmlLanguage("CircularAnnulusSection"));
            cmbRegionShape.Items.Add(AUtil.GetXmlLanguage("EllipticalAnnulusSection"));

            // 2011.04.12
            //stslblStatus.Text = AUtil.GetXmlLanguage("Not_Calibrated");
            //ATbPMAlign---------------------
            grpbxPattern.Text = AUtil.GetXmlLanguage("Pattern");
            btnLoadTrainedImage.Text = AUtil.GetXmlLanguage("Load_Trained_Image");
            grpbxSetting.Text = AUtil.GetXmlLanguage("Setting");
            btnAdd.Text = "      " + AUtil.GetXmlLanguage("Add_Pattern");
            btnDelete.Text = "     " + AUtil.GetXmlLanguage("Delete_Pattern");
            grpbxShape.Text = AUtil.GetXmlLanguage("Training_Shape");
            lblShape.Text = AUtil.GetXmlLanguage("Shape");
            grpbxRegion.Text = AUtil.GetXmlLanguage("Region");
            btnSearchRegion.Text = "    " + AUtil.GetXmlLanguage("Search_Region");
            grpbxParameters.Text = AUtil.GetXmlLanguage("Parameters");
            lblThreshold.Text = AUtil.GetXmlLanguage("Threshold");
            lblAngle.Text = AUtil.GetXmlLanguage("Angle");
            lblCount.Text = AUtil.GetXmlLanguage("Count");
            lblScale.Text = AUtil.GetXmlLanguage("Scale");
            // 2016.05.10
            lblScaleX.Text = "X " + AUtil.GetXmlLanguage("Scale");
            lblScaleY.Text = "Y " + AUtil.GetXmlLanguage("Scale");

            lblParameterContrast.Text = AUtil.GetXmlLanguage("Contrast");
            // 2014.12.29
            chkClutter.Text = AUtil.GetXmlLanguage("Clutter");

            chkPolarity.Text = AUtil.GetXmlLanguage("Polarity");
            btnTeach.Text = "   " + AUtil.GetXmlLanguage("Teach");
            btnMasking.Text = "    " + AUtil.GetXmlLanguage("Masking");            
            grpbxUlitity.Text = AUtil.GetXmlLanguage("Ulitity");
            btnSearch.Text = "  " + AUtil.GetXmlLanguage("Search");
            btnMeasure.Text = "    " + AUtil.GetXmlLanguage("Measure");
            btnInitialize.Text = "  " + AUtil.GetXmlLanguage("Initialize");
            chkCalibCase.Text = AUtil.GetXmlLanguage("Calibration_Case");
            grpbxDatumData.Text = AUtil.GetXmlLanguage("Datum_Data");
            lblOrginPosition.Text = AUtil.GetXmlLanguage("Origin_Position");
            lblOriginAngle.Text = AUtil.GetXmlLanguage("Angle");
            grpbxResult.Text = AUtil.GetXmlLanguage("Result");
            lblMeasuredResult.Text = AUtil.GetXmlLanguage("Measured_Result");
            lblResultAngle.Text = AUtil.GetXmlLanguage("Angle");
            lblScore.Text = AUtil.GetXmlLanguage("Score");
            lblResultScale.Text = AUtil.GetXmlLanguage("Scale");
            lblResultResult.Text = AUtil.GetXmlLanguage("Result");

            // 2016.08.31 Gammma & Equalize
            btnGamma.Text = AUtil.GetXmlLanguage("Gamma") + " && " + AUtil.GetXmlLanguage("Equalize");

        }

        public void InitializePMAlign(int nPMAlignIndex)
        {
            m_IsInitializing = true;
            m_aPMAlign = m_lstAPMAlign[nPMAlignIndex];

            m_nPatternCurrentIndex = nPMAlignIndex;
            m_nPatternTotalCount = m_lstAPMAlign.Count;

            if (m_IsToolExist == false)
            {
                m_cogimgMask = null;
                // 2016.05.13
                m_aDisplayPattern.ClearAll();
            }
            else
            {
                if (m_aPMAlign.Trained)
                {
                    // 2016.03.16
                    //m_cogimgMask = m_aPMAlign.MaskImage;
                    //LoadPattern(nPMAlignIndex);
                    LoadPattern(nPMAlignIndex);
                    m_cogimgMask = m_aPMAlign.MaskImage;
                }
            }

            lblPatternCount.Text = (nPMAlignIndex + 1).ToString() + "/" + m_nPatternTotalCount.ToString();
            // 2014.12.29
            chkClutter.Checked = m_aPMAlign.UsingClutter;

            chkPolarity.Checked = m_aPMAlign.IgnorePolarity;
            txtAcceptThreshold.Text = m_aPMAlign.AcceptThreshold.ToString();
            txtContrastThreshold.Text = m_aPMAlign.ContrastThreshold.ToString();
            txtSearchCount.Text = m_aPMAlign.NumberToFind.ToString();
            //-------------------------
            // 2016.11.15
            if (m_aPMAlign.GetTool().RunParams.ZoneAngle.Configuration == CogPMAlignZoneConstants.Nominal)
            {
                m_aPMAlign.ZoneAngleHigh = 0;
                m_aPMAlign.ZoneAngleLow = 0;
            }
            if (m_aPMAlign.GetTool().RunParams.ZoneScale.Configuration == CogPMAlignZoneConstants.Nominal)
            {
                m_aPMAlign.ZoneScaleHigh = 1;
                m_aPMAlign.ZoneScaleLow = 1;
            }
            if (m_aPMAlign.GetTool().RunParams.ZoneScaleX.Configuration == CogPMAlignZoneConstants.Nominal)
            {
                m_aPMAlign.ZoneScaleX_High = 1;
                m_aPMAlign.ZoneScaleX_Low = 1;
            }
            if (m_aPMAlign.GetTool().RunParams.ZoneScaleY.Configuration == CogPMAlignZoneConstants.Nominal)
            {
                m_aPMAlign.ZoneScaleY_High = 1;
                m_aPMAlign.ZoneScaleY_Low = 1;
            }
            //-------------------------
            txtAngleMax.Text = m_aPMAlign.ZoneAngleHigh.ToString();
            txtAngleMin.Text = m_aPMAlign.ZoneAngleLow.ToString();
            txtScaleMax.Text = m_aPMAlign.ZoneScaleHigh.ToString();
            txtScaleMin.Text = m_aPMAlign.ZoneScaleLow.ToString();
            // 2016.05.10
            txtScaleX_Max.Text = m_aPMAlign.ZoneScaleX_High.ToString();
            txtScaleX_Min.Text = m_aPMAlign.ZoneScaleX_Low.ToString();
            txtScaleY_Max.Text = m_aPMAlign.ZoneScaleY_High.ToString();
            txtScaleY_Min.Text = m_aPMAlign.ZoneScaleY_Low.ToString();

            switch (m_aPMAlign.SearchShape)
            {
                case AVisionProBuild._emRegionShape.Entire:
                    cmbRegionShape.SelectedIndex = 0;
                    break;
                case AVisionProBuild._emRegionShape.Circle:
                    cmbRegionShape.SelectedIndex = 1;
                    break;
                case AVisionProBuild._emRegionShape.Ellipse:
                    cmbRegionShape.SelectedIndex = 2;
                    break;
                case AVisionProBuild._emRegionShape.Rectangle:
                    cmbRegionShape.SelectedIndex = 3;
                    break;
                case AVisionProBuild._emRegionShape.RectangleAffine:
                    cmbRegionShape.SelectedIndex = 4;
                    break;
                case AVisionProBuild._emRegionShape.CircularAnnulusSection:
                    cmbRegionShape.SelectedIndex = 5;
                    break;
                case AVisionProBuild._emRegionShape.EllipticalAnnulusSection:
                    cmbRegionShape.SelectedIndex = 6;
                    break;
            }

            switch (m_aPMAlign.PatternShape)
            {
                case AVisionProBuild._emRegionShape.Entire:
                    cmbPatternShape.SelectedIndex = 0;
                    break;
                case AVisionProBuild._emRegionShape.Circle:
                    cmbPatternShape.SelectedIndex = 1;
                    break;
                case AVisionProBuild._emRegionShape.Ellipse:
                    cmbPatternShape.SelectedIndex = 2;
                    break;
                case AVisionProBuild._emRegionShape.Rectangle:
                    cmbPatternShape.SelectedIndex = 3;
                    break;
                case AVisionProBuild._emRegionShape.RectangleAffine:
                    cmbPatternShape.SelectedIndex = 4;
                    break;
                case AVisionProBuild._emRegionShape.CircularAnnulusSection:
                    cmbPatternShape.SelectedIndex = 5;
                    break;
                case AVisionProBuild._emRegionShape.EllipticalAnnulusSection:
                    cmbPatternShape.SelectedIndex = 6;
                    break;
            }

            cmbCalibCase.SelectedItem = m_aIni.CalibCase;

            // 2014.07.28
            if (m_aPMAlign != null)
            {
                if (m_aPMAlign.TrainMode == CogPMAlignTrainModeConstants.Image)
                {
                    btnMasking.Text = "    " + AUtil.GetXmlLanguage("Masking");
                    m_aPMAlign.TrainRegionMode = CogRegionModeConstants.PixelAlignedBoundingBoxAdjustMask;
                }
                else
                {
                    btnMasking.Text = "    " + AUtil.GetXmlLanguage("Model") + " " + AUtil.GetXmlLanguage("Maker");
                    m_aPMAlign.TrainRegionMode = CogRegionModeConstants.PixelAlignedBoundingBox;
                }
            }
            else
            {
                btnMasking.Text = "    " + AUtil.GetXmlLanguage("Masking");
            }

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

            m_IsInitializing = false;
        }

        private void btnAcquireSingle_Click(object sender, EventArgs e)
        {
            // 2016.12.01
            chkRun.Visible = false;

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
                // 2012.01.17
                //RunCalibImage();
                m_aDisplay.Image = RunCalibImage();
                
                m_aDisplay.Display.Fit(true);
                m_aPMAlign.InputImage = m_aDisplay.GetImage8Grey();
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
            if (btnAcquireLive.Text == "        " + AUtil.GetXmlLanguage("Acquire_Live"))
            {
                btnAcquireLive.Text = "        " + AUtil.GetXmlLanguage("Acquire_Stop");
                //----------------------------------
                // 2011.04.21 Live
                //m_aAcqFifo.Acquire(cogDisplay, AAcqFifo._emAcquireMode.LiveVideo);                
                tmrLive.Enabled = true;
                // 2012.02.19
                m_bLive = true;

                btnTeach.Enabled = false;
                btnSearchRegion.Enabled = false;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnInitialize.Enabled = false;
                btnMasking.Enabled = false;
                //----------------------------------
                // 2011.06.09
                lblFileName.Text = "";
            }
            else
            {
                btnAcquireLive.Text = "        " + AUtil.GetXmlLanguage("Acquire_Live");
                //----------------------------------
                // 2011.04.21 Live
                //m_aAcqFifo.StopLiveAcquisition(cogDisplay);
                //btnAcquireSingle_Click(null, null);
                // 2012.02.19
                //tmrLive.Enabled = false;
                m_bLive = false;

                btnTeach.Enabled = true;
                btnSearchRegion.Enabled = true;
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnInitialize.Enabled = true;
                btnMasking.Enabled = true;
                //----------------------------------

            }
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

        private void btnLoadTrainedImage_Click(object sender, EventArgs e)
        {
            m_aDisplay.ClearAll();
            m_aDisplay.Display.Image = m_aPMAlign.GetTool().Pattern.TrainImage;
            m_aDisplay.Display.Fit(true);

            m_aPMAlign.InputImage = m_aDisplay.GetImage8Grey();

            // 2014.12.28
            m_cogImage = m_aPMAlign.InputImage;

            // 2012.06.03
            m_cogimgMask = m_aPMAlign.GetTool().Pattern.TrainImageMask;

            if (m_cogimgMask != null)
            {
                CogMaskGraphic mask = new CogMaskGraphic();
                mask.Image = m_cogimgMask;
                m_aDisplay.AddStaticGraphic(mask as ICogGraphic, "");
            }


        }

        private void btnTeach_Click(object sender, EventArgs e)
        {
            if (cmbPatternShape.Enabled == false && m_aDisplay.Image != null)
            {
                cmbPatternShape.Enabled = true;
                m_aDisplay.ClearOverlay();

                if (m_aPMAlign.Trained)
                {
                    m_aPMAlign.ViewLastTrainRegion(m_aDisplay);
                }
                else
                {
                    m_aPMAlign.GrabTrainRegion(m_aDisplay, m_aPMAlign.PatternShape);
                }
                m_aPMAlign.ShowSearchRegion(m_aDisplay);
                m_emRegionWorkType = _emRegionWorkType.TrainRegion;

                //** 2016.01.26 by kdi.
                m_Pattern_Backup = new CogPMAlignPattern(m_aPMAlign.GetTool().Pattern);
                //*/

                btnOK.Visible = true;
                btnCancel.Visible = true;

                // 2011.07.10
                EnabledButton(false);
                btnSearchRegion.Enabled = false;

                m_aDisplay.Display.Fit(true);
            }
        }

        private void btnSearchRegion_Click(object sender, EventArgs e)
        {
            if (cmbRegionShape.Enabled == false && m_aDisplay.Image != null)
            {
                cmbRegionShape.Enabled = true;
                m_aDisplay.ClearOverlay();
                m_aPMAlign.ViewLastSearchRegion(m_aDisplay);
                m_emRegionWorkType = _emRegionWorkType.SearchRegion;

                btnOK.Visible = true;
                btnCancel.Visible = true;

                // 2011.07.10
                EnabledButton(false);
                btnTeach.Enabled = false;

                m_aDisplay.Display.Fit(true);

                // 2016.03.16
                // 2016.01.26 by kdi
                //m_SearchRegion_Backup = CopySearchRegion(m_aPMAlign.GetTool().SearchRegion);
                m_SearchRegion_Backup = CopySearchRegion(m_aPMAlign.SearchRegion);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (m_emRegionWorkType == _emRegionWorkType.SearchRegion)
            {
                //m_aPMAlign.SetSearchRegion(m_aDisplay);
                for (int i = 0; i < m_lstAPMAlign.Count; ++i)
                {
                    m_lstAPMAlign[i].SetSearchRegion(m_aDisplay);
                }

                btnOK.Visible = false;
                btnCancel.Visible = false;
                cmbRegionShape.Enabled = false;
                btnSearchRegion.Enabled = true;
                // 2011.07.10
                btnTeach.Enabled = true;
            }
            else if (m_emRegionWorkType == _emRegionWorkType.TrainRegion)
            {
                // 2016.01.26 by kdi
                m_aPMAlign.Untrain(m_aDisplayPattern);

                m_aPMAlign.SetTrainRegion(m_aDisplay);

                btnOK.Visible = false;
                btnCancel.Visible = false;
                cmbPatternShape.Enabled = false;
                btnTeach.Enabled = true;
                // 2011.07.10
                btnSearchRegion.Enabled = true;

                m_aPMAlign.Train(m_aDisplay, m_cogimgMask);
                m_aPMAlign.ShowSearchRegion(m_aDisplay);
                m_aPMAlign.ShowPattern(m_aDisplayPattern);
                // 2016.05.12
                if (m_aDisplayPattern.Image != null)
                {
                    if (m_aDisplayPattern.Image.Height > 241 || m_aDisplayPattern.Image.Width > 351)
                    {
                        m_aDisplayPattern.FitImage();
                    }

                    // 2016.05.16
                    m_IsToolExist = true;
                }
            }

            // 2011.07.10
            EnabledButton(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            m_aDisplay.ClearOverlay();

            if (m_emRegionWorkType == _emRegionWorkType.SearchRegion)
            {
                //** 2016.01.26 by kdi
                SetRegionShape(m_SearchRegion_Backup, cmbRegionShape);
                // 2016.03.16
                //m_aPMAlign.GetTool().SearchRegion = CopySearchRegion(m_SearchRegion_Backup);
                m_aPMAlign.SearchRegion = CopySearchRegion(m_SearchRegion_Backup);
                //*/

                btnOK.Visible = false;
                btnCancel.Visible = false;
                btnSearchRegion.Enabled = true;
                // 2011.07.10
                btnTeach.Enabled = true;
                cmbRegionShape.Enabled = false;
            }
            if (m_emRegionWorkType == _emRegionWorkType.TrainRegion)
            {
                //** 2016.01.26 by kdi
                SetRegionShape(m_aPMAlign.TrainedRegion, cmbPatternShape);
                m_aPMAlign.GetTool().Pattern = new CogPMAlignPattern(m_Pattern_Backup);
                m_aPMAlign.TrainedRegion = m_aPMAlign.GetTool().Pattern.TrainRegion;
                //*/

                btnOK.Visible = false;
                btnCancel.Visible = false;
                btnTeach.Enabled = true;
                // 2011.07.10
                btnSearchRegion.Enabled = true;
                cmbPatternShape.Enabled = false;
            }

            // 2011.07.10
            EnabledButton(true);
        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            m_aPMAlign.Train(m_aDisplay, m_cogimgMask);
            m_aPMAlign.ShowPattern(m_aDisplayPattern);
            // 2011.06.23
            if (m_aDisplayPattern.Image.Height > 241 || m_aDisplayPattern.Image.Width > 351)
            {
                m_aDisplayPattern.FitImage();
            }
        }

        private void btnSaveVPP_Click(object sender, EventArgs e)
        {
            APMAlign aPMAlign = m_lstAPMAlign[m_nPatternCurrentIndex];

            aPMAlign.Name = AVisionProBuild.MakeName("PMAlign", DateTime.Now);

            AVisionProBuild.SaveVpp(m_nType);
            m_IsToolExist = true;

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
            // 2014.10.30
#if _USE_1Camera
            CogSerializer.SaveObjectToFile(m_aAcqFifo.GetTool(), ASDef._INI_PATH + "\\1Camera.vpp", typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.Minimum);
#endif

            //MessageBox.Show("PMAlign Tool is Saved!");
            // 2013.12.02
            MessageBox.Show(AUtil.GetXmlLanguage("Tool_is_Saved"));
            btnSaveVPP.Enabled = false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMasking_Click(object sender, EventArgs e)
        {
            if (m_aDisplay.Image != null)
            {
                // 2016.01.26 by kdi.
                AFrmCogMask frmMask = new AFrmCogMask(cogDisplay.Image, m_cogimgMask);
                // 2016.01.09
                frmMask.ShowDialog(this);

                if (frmMask.m_IsApplied)
                {
                    m_aPMAlign.Untrain(m_aDisplayPattern);

                    m_cogimgMask = frmMask.MaskedImage;
                    ICogGraphic image = frmMask.MaskedGraphic as ICogGraphic;

                    if (image != null)
                    {
                        m_aDisplay.ClearStaticGraphic();
                        m_aDisplay.AddStaticGraphic(image, "");

                        //if (m_aPMAlign.GetTool().Pattern.TrainRegion != null)
                        {
                            btnTeach_Click(sender, null);
                            btnOK_Click(sender, null);
                        }

                    }
                }
                //*/

                /** 2016.01.26 by kdi.
                // 2014.07.28
                if (m_aPMAlign.TrainMode == CogPMAlignTrainModeConstants.Image)
                {

                    AFrmCogMask frmMask = new AFrmCogMask(cogDisplay.Image, m_cogimgMask);
                    // 2015.03.18
                    frmMask.ShowDialog(this);

                    if (frmMask.m_IsApplied)
                        m_aPMAlign.Untrain(m_aDisplayPattern);

                    m_cogimgMask = frmMask.MaskedImage;
                    ICogGraphic image = frmMask.MaskedGraphic as ICogGraphic;

                    if (image != null)
                    {
                        m_aDisplay.ClearStaticGraphic();
                        m_aDisplay.AddStaticGraphic(image, "");
                    }
                }
                else
                {
                    AFrmCogModelMaker frmModelMaker = new AFrmCogModelMaker(cogDisplay.Image, m_aPMAlign.TrainShapeModels);
                    // 2015.03.18
                    frmModelMaker.ShowDialog(this);
                    
                    m_aPMAlign.Untrain(m_aDisplayPattern);
                }
                //*/
            }
        }

        private void btnMeasure_Click(object sender, EventArgs e)
        {
            if (m_aDisplay.Image != null)
            {
                /*
                int nResultIndex = 0;
                double dResultScore = 0;

                for (int i = 0; i < m_lstAPMAlign.Count; i++)
                {
                    m_lstAPMAlign[i].Run(m_aDisplay);

                    if (m_lstAPMAlign[i].Score > dResultScore)
                    {
                        dResultScore = m_lstAPMAlign[i].Score;
                        nResultIndex = i;
                    }
                }
                */
                m_aDisplay.ClearExcludeImage();
                int nResultIndex = m_aPMAligns.RunPMAlign(m_aDisplay);

                if (nResultIndex >= 0)
                {
                    InitializePMAlign(nResultIndex);

                    txtResultX.Text = Math.Round(m_lstAPMAlign[nResultIndex].X, 3).ToString();
                    txtResultY.Text = Math.Round(m_lstAPMAlign[nResultIndex].Y, 3).ToString();
                    txtResultAngle.Text = Math.Round(m_lstAPMAlign[nResultIndex].Angle, 3).ToString();
                    txtResultScale.Text = Math.Round(m_lstAPMAlign[nResultIndex].Scale, 3).ToString();
                    txtResultScore.Text = Math.Round(m_lstAPMAlign[nResultIndex].Score, 3).ToString();

                    lblResult.Text = "OK";
                    lblResult.BackColor = Color.ForestGreen;

                    btnInitialize.Enabled = true;

                    double startX = Convert.ToDouble(txtOriginX.Text);
                    double startY = Convert.ToDouble(txtOriginY.Text);
                    double endX = Convert.ToDouble(txtResultX.Text);
                    double endY = Convert.ToDouble(txtResultY.Text);

                    m_aDisplay.AddLine(startX, startY, endX, endY, CogColorConstants.Yellow);

                }
                else
                {
                    txtResultX.Text = "";
                    txtResultY.Text = "";
                    txtResultAngle.Text = "";
                    txtResultScale.Text = "";
                    txtResultScore.Text = "";

                    lblResult.Text = "NG";
                    lblResult.BackColor = Color.Crimson;

                    btnInitialize.Enabled = false;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cogDisplay.Image != null)
            {
                m_aDisplay.ClearExcludeImage();

                // 2014.12.29
                m_aPMAlign.UsingClutter = chkClutter.Checked;

                m_aPMAlign.IgnorePolarity = chkPolarity.Checked;
                m_aPMAlign.AcceptThreshold = Convert.ToDouble(txtAcceptThreshold.Text);
                m_aPMAlign.ContrastThreshold = Convert.ToDouble(txtContrastThreshold.Text);
                m_aPMAlign.NumberToFind = Convert.ToInt16(txtSearchCount.Text);
                m_aPMAlign.ZoneAngleHigh = Convert.ToDouble(txtAngleMax.Text);
                m_aPMAlign.ZoneAngleLow = Convert.ToDouble(txtAngleMin.Text);
                m_aPMAlign.ZoneScaleHigh = Convert.ToDouble(txtScaleMax.Text);
                m_aPMAlign.ZoneScaleLow = Convert.ToDouble(txtScaleMin.Text);
                // 2016.05.10
                m_aPMAlign.ZoneScaleX_High = Convert.ToDouble(txtScaleX_Max.Text);
                m_aPMAlign.ZoneScaleX_Low = Convert.ToDouble(txtScaleX_Min.Text);
                m_aPMAlign.ZoneScaleY_High = Convert.ToDouble(txtScaleY_Max.Text);
                m_aPMAlign.ZoneScaleY_Low = Convert.ToDouble(txtScaleY_Min.Text);

                m_aPMAlign.Run(m_aDisplay);
                // 2014.09.03
                m_aPMAlign.ShowResult(m_aDisplay, true);

                txtResultX.Text = Math.Round(m_aPMAlign.X, 3).ToString();
                txtResultY.Text = Math.Round(m_aPMAlign.Y, 3).ToString();
                txtResultAngle.Text = Math.Round(m_aPMAlign.Angle, 3).ToString();
                txtResultScale.Text = Math.Round(m_aPMAlign.Scale, 3).ToString();
                txtResultScore.Text = Math.Round(m_aPMAlign.Score, 3).ToString();
                if (m_aPMAlign.Result == true)
                {
                    lblResult.Text = "OK";
                    lblResult.BackColor = Color.ForestGreen;
                }
                else
                {
                    lblResult.Text = "NG";
                    lblResult.BackColor = Color.Crimson;
                }

                btnSaveVPP.Enabled = true;
            }
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            // 2013.12.02
            if (MessageBox.Show(AUtil.GetXmlLanguage("Do_you_want_to_Initialize"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                txtOriginX.Text = txtResultX.Text;
                txtOriginY.Text = txtResultY.Text;
                txtOriginAngle.Text = txtResultAngle.Text;

                m_aIni.InitX = txtOriginX.Text;
                m_aIni.InitY = txtOriginY.Text;
                m_aIni.InitAngle = txtOriginAngle.Text;

                // 2014.08.27
                m_aPMAlign.SetInitSearchRegion();
                m_aIni.InitSearchRegionX = m_aPMAlign.m_dInitSearchRegionX.ToString("0.00");
                m_aIni.InitSearchRegionY = m_aPMAlign.m_dInitSearchRegionY.ToString("0.00");

                m_aIni.Write();

                string strFName;
                strFName = ASDef._INI_PATH + "\\Img\\" + "Init_" + AVisionProBuild.ToolName(m_nType, m_nPoint, "PMAlign") + ".bmp";
                // 2012.01.17
                //AVisionProBuild.SaveImg(strFName, cogDisplay);
                // 2014.12.10
                //AVisionProBuild.SaveImg(strFName, m_aDisplay.Image);
                AVisionProBuild.SaveImg(strFName, m_cogImage);

                //MessageBox.Show("Initialized!");
                MessageBox.Show(AUtil.GetXmlLanguage("Initialized"));
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
                //RunCalibImage();
                m_aDisplay.Image = RunCalibImage();
                
                m_aPMAlign.InputImage = m_aDisplay.GetImage8Grey();
            }
            // 2011.06.09
            lblFileName.Text = strFileName;

            // 2014.07.28
            if (chkRun.Checked)
            {
                btnMeasure_Click(btnMeasure, null);
            }
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
                //RunCalibImage();
                m_aDisplay.Image = RunCalibImage();
                
                m_aPMAlign.InputImage = m_aDisplay.GetImage8Grey();
            }
            lblFileName.Text = strFileName;

            // 2014.07.28
            if (chkRun.Checked)
            {
                btnMeasure_Click(btnMeasure, null);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (m_nPatternCurrentIndex > 0)
            {
                m_aDisplayPattern.ClearAll();
                m_nPatternCurrentIndex--;
                InitializePMAlign(m_nPatternCurrentIndex);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (m_nPatternCurrentIndex < m_nPatternTotalCount - 1)
            {
                m_aDisplayPattern.ClearAll();
                m_nPatternCurrentIndex++;
                InitializePMAlign(m_nPatternCurrentIndex);
            }
        }

        public void LoadPattern(int index)
        {
            m_aPMAlign.ShowPattern(m_aDisplayPattern);
            // 2012.01.25
            if (m_aDisplayPattern.Image != null)
            {
                // 2011.06.23
                if (m_aDisplayPattern.Image.Height > 241 || m_aDisplayPattern.Image.Width > 351)
                {
                    m_aDisplayPattern.FitImage();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 2013.03.29 찾을 영역 변경 문제로 추가
            m_aPMAlign.ShowSearchRegion(m_aDisplay);

            m_nPatternTotalCount++;
            m_nPatternCurrentIndex = m_nPatternTotalCount - 1;

            APMAlign aPMAlign = new APMAlign();
            aPMAlign.Name = AVisionProBuild.MakeName("PMAlign", DateTime.Now);
            m_aPMAligns.Add(aPMAlign);

            //--------------------            
            aPMAlign.SetSearchRegion(m_aDisplay);
            // 2016.05.09
            m_cogimgMask = null;

            m_aDisplayPattern.ClearAll();
            m_aDisplay.ClearOverlay();
            m_aDisplay.ClearStaticGraphic();
            //--------------------

            InitializePMAlign(m_nPatternCurrentIndex);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (m_nPatternTotalCount > 1)
            {
                //if (MessageBox.Show("Confirm To Delete Current Pattern?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                if (MessageBox.Show(AUtil.GetXmlLanguage("Confirm_To_Delete_Current_Pattern") + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    APMAlign aPMAlign = m_lstAPMAlign[m_nPatternCurrentIndex];
                    m_aPMAligns.Remove(aPMAlign);

                    if (m_nPatternCurrentIndex == m_nPatternTotalCount - 1)
                    {
                        m_nPatternCurrentIndex--;
                        m_nPatternTotalCount--;
                    }
                    else if (m_nPatternTotalCount - m_nPatternCurrentIndex > 1)
                    {
                        m_nPatternTotalCount--;
                    }

                    InitializePMAlign(m_nPatternCurrentIndex);
                }
            }
        }

        private void tmrTime_Tick(object sender, EventArgs e)
        {
            stslblTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void cmbRegionShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            //2011.05.07
            //2011.10.11
            if (cogDisplay.Image != null && m_IsInitializing == false)
            {
                switch (cmbRegionShape.SelectedIndex)
                {
                    case 0:
                        m_aPMAlign.GrabSearchRegion(m_aDisplay, AVisionProBuild._emRegionShape.Entire);
                        break;
                    case 1:
                        m_aPMAlign.GrabSearchRegion(m_aDisplay, AVisionProBuild._emRegionShape.Circle);
                        break;
                    case 2:
                        m_aPMAlign.GrabSearchRegion(m_aDisplay, AVisionProBuild._emRegionShape.Ellipse);
                        break;
                    case 3:
                        m_aPMAlign.GrabSearchRegion(m_aDisplay, AVisionProBuild._emRegionShape.Rectangle);
                        break;
                    case 4:
                        m_aPMAlign.GrabSearchRegion(m_aDisplay, AVisionProBuild._emRegionShape.RectangleAffine);
                        break;
                    case 5:
                        m_aPMAlign.GrabSearchRegion(m_aDisplay, AVisionProBuild._emRegionShape.CircularAnnulusSection);
                        break;
                    case 6:
                        m_aPMAlign.GrabSearchRegion(m_aDisplay, AVisionProBuild._emRegionShape.EllipticalAnnulusSection);
                        break;
                }
                //2011.05.07
                if (m_IsInitializing == false)
                {
                    // 2011.06.18
                    if (cmbRegionShape.Enabled == true)
                    {
                        btnOK.Visible = true;
                        btnCancel.Visible = true;
                        btnSearchRegion.Enabled = false;
                        m_emRegionWorkType = _emRegionWorkType.SearchRegion;
                    }
                }
            }
        }

        private void cmbPatternShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cogDisplay.Image != null && m_IsInitializing == false)
            {
                // 2016.01.26 by kdi. m_aPMAlign.Untrain(m_aDisplayPattern);

                switch (cmbPatternShape.SelectedIndex)
                {
                    case 0:
                        m_aPMAlign.GrabTrainRegion(m_aDisplay, AVisionProBuild._emRegionShape.Entire);
                        break;
                    case 1:
                        m_aPMAlign.GrabTrainRegion(m_aDisplay, AVisionProBuild._emRegionShape.Circle);
                        break;
                    case 2:
                        m_aPMAlign.GrabTrainRegion(m_aDisplay, AVisionProBuild._emRegionShape.Ellipse);
                        break;
                    case 3:
                        m_aPMAlign.GrabTrainRegion(m_aDisplay, AVisionProBuild._emRegionShape.Rectangle);
                        break;
                    case 4:
                        m_aPMAlign.GrabTrainRegion(m_aDisplay, AVisionProBuild._emRegionShape.RectangleAffine);
                        break;
                    case 5:
                        m_aPMAlign.GrabTrainRegion(m_aDisplay, AVisionProBuild._emRegionShape.CircularAnnulusSection);
                        break;
                    case 6:
                        m_aPMAlign.GrabTrainRegion(m_aDisplay, AVisionProBuild._emRegionShape.EllipticalAnnulusSection);
                        break;
                }
                // 2011.06.18
                if (cmbPatternShape.Enabled == true)
                {
                    btnOK.Visible = true;
                    btnCancel.Visible = true;
                    btnTeach.Enabled = false;
                    m_emRegionWorkType = _emRegionWorkType.TrainRegion;
                }
            }
        }

        private void statusStrip1_DoubleClick(object sender, EventArgs e)
        {
            AFrmCogToolGroup frm = new AFrmCogToolGroup(m_aPoint.m_cogtgPoint);
            // 2015.03.18
            frm.Show(this);
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

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            string strDateTimeNow = DateTime.Now.ToString("yyyy_MM_dd_HHmmss");
            // 2012.01.17
            //AVisionProBuild.SaveImg(AVisionProBuild.m_strResultPath + "\\" + strDateTimeNow + ".BMP", cogDisplay);
            // 2014.12.10
            //AVisionProBuild.SaveImg(AVisionProBuild.m_strResultPath + "\\" + strDateTimeNow + ".BMP", m_aDisplay.Image);
            AVisionProBuild.SaveImg(AVisionProBuild.m_strResultPath + "\\" + strDateTimeNow + ".BMP", m_cogImage);
        }

        private void btnLoadInit_Click(object sender, EventArgs e)
        {
            string strFName;
            strFName = ASDef._INI_PATH + "\\Img\\" + "Init_" + AVisionProBuild.ToolName(m_nType, m_nPoint, "PMAlign") + ".bmp";
            // 2011.05.07                
            m_aDisplay.ClearAll();
            // 2012.01.17
            //if (AVisionProBuild.LoadImg(strFName, cogDisplay) == true)
            if (AVisionProBuild.LoadImg(strFName, ref m_cogImage) == true)
            {                
                // 2012.01.17
                //RunCalibImage();
                m_aDisplay.Image = RunCalibImage();
                
                m_aDisplay.Display.Fit(true);

                m_aPMAlign.InputImage = m_aDisplay.GetImage8Grey();
                m_aPoint.m_strLoadFileName = strFName;
            }

        }

        private void cmbCalibCase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_IsInitializing == false)
            {
                m_aIni.CalibCase = cmbCalibCase.SelectedItem.ToString();

                for (int i = 0; i < m_lstAPMAlign.Count; i++)
                {
                    m_lstAPMAlign[i].Untrain(m_aDisplayPattern);
                }
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

        // 2012.01.17            
        private ICogImage RunCalibImage()
        {
            // 2016.06.22
            bool bU = m_aIni.FixtureNPointToNPoint;
            m_cogImage = AVisionProBuild.RunFixtureImage(m_cogImage, ref bU, 0, m_nPoint);
            if (bU == false)
                chkFixtureNPointToNPoint.BackColor = Color.Gray;
            else
                chkFixtureNPointToNPoint.BackColor = Color.GreenYellow;

            //cogDisplay.Image = m_aPoint.RunCalibImage(cogDisplay.Image, m_aIni.CalibCase);            
            // 2016.06.21
            return m_aPoint.RunCalibImage(m_cogImage, m_aIni.CalibCase);
        }

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            AFrmCogPMAlign frm = new AFrmCogPMAlign(m_aPMAlign);
            // 2015.03.18
            frm.ShowDialog(this);

            // 2014.07.28
            InitializePMAlign(m_nPatternCurrentIndex);
        }

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
        // 2011.04.21 Live
        private void tmrLive_Tick(object sender, EventArgs e)
        {
            // 2012.02.19
            tmrLive.Enabled = false;
            try
            {
                // 2012.04.25
                AVisionProBuild.Acq(m_nType, m_nPoint, ref m_cogImage);
                // 2012.01.17
                //RunCalibImage();
                m_aDisplay.Image = RunCalibImage();

                // 2011.08.17
                //m_aDisplay.Display.Fit(true)
                m_aDisplay.AddCross();
                m_aPMAlign.InputImage = m_aDisplay.GetImage8Grey();
            }
            catch
            {
            }

            GC.Collect();

            // 2012.02.19
            if (m_bLive == true)
                tmrLive.Enabled = true;

        }
        /*
        public void SetSearchRegion(Cognex.VisionPro.ICogRegion Region)
        {
            for (int i = 0; i < m_lstPMAligns.Count; ++i)
            {
                m_lstPMAligns[i].ppSearchRegion = Region;
            }
        }
        */
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
            btnPrevious.Enabled = bEnabled;
            btnNext.Enabled = bEnabled;
            btnLoadTrainedImage.Enabled = bEnabled;
            btnAdd.Enabled = bEnabled;
            btnDelete.Enabled = bEnabled;
            btnMasking.Enabled = bEnabled;
            btnSearch.Enabled = bEnabled;
            btnMeasure.Enabled = bEnabled;
            //btnInitialize.Enabled = bEnabled;
            chkCalibCase.Enabled = bEnabled;
            // 2014.12.29
            chkClutter.Enabled = bEnabled;

            chkPolarity.Enabled = bEnabled;

            // 2016.12.02
            btnGamma.Enabled = bEnabled;
            cmbCalibCase.Enabled = bEnabled;

        }

        // 2016.01.26 by kdi
        private ICogRegion CopySearchRegion(ICogRegion region)
        {
            if (region == null)
                return null;

            ICogRegion TempRegion = region;
            ICogRegion SearchRegion = null;

            if (TempRegion is CogCircle)
            {
                SearchRegion = new CogCircle(TempRegion as CogCircle);
            }
            else if (TempRegion is CogEllipse)
            {
                SearchRegion = new CogEllipse(TempRegion as CogEllipse);
            }
            else if (TempRegion is CogRectangle)
            {
                SearchRegion = new CogRectangle(TempRegion as CogRectangle);
            }
            else if (TempRegion is CogRectangleAffine)
            {
                SearchRegion = new CogRectangleAffine(TempRegion as CogRectangleAffine);
            }
            else if (TempRegion is CogCircularAnnulusSection)
            {
                SearchRegion = new CogCircularAnnulusSection(TempRegion as CogCircularAnnulusSection);
            }
            else if (TempRegion is CogEllipticalAnnulusSection)
            {
                SearchRegion = new CogEllipticalAnnulusSection(TempRegion as CogEllipticalAnnulusSection);
            }

            return SearchRegion;
        }

        // 2016.01.26 by kdi
        private void SetTrainRegion()
        {
            m_aPMAlign.SetTrainRegion(m_aDisplay);

            //btnOK.Visible = false;
            //btnCancel.Visible = false;
            //cmbPatternShape.Enabled = false;
            //btnTeach.Enabled = true;
            //// 2011.07.10
            //btnSearchRegion.Enabled = true;

            m_aPMAlign.Train(m_aDisplay, m_cogimgMask);
            m_aPMAlign.ShowSearchRegion(m_aDisplay);
            m_aPMAlign.ShowPattern(m_aDisplayPattern);

            if (m_aDisplayPattern.Image.Height > 241 || m_aDisplayPattern.Image.Width > 351)
            {
                m_aDisplayPattern.FitImage();
            }
        }

        // 2016.01.26 by kdi
        private void SetRegionShape(ICogRegion region, ComboBox cmbTarget)
        {
            if (region == null)
                cmbTarget.SelectedIndex = 0;

            ICogRegion TempRegion = region;

            if (TempRegion is CogCircle)
            {
                cmbTarget.SelectedIndex = 1;
            }
            else if (TempRegion is CogEllipse)
            {
                cmbTarget.SelectedIndex = 2;
            }
            else if (TempRegion is CogRectangle)
            {
                cmbTarget.SelectedIndex = 3;
            }
            else if (TempRegion is CogRectangleAffine)
            {
                cmbTarget.SelectedIndex = 4;
            }
            else if (TempRegion is CogCircularAnnulusSection)
            {
                cmbTarget.SelectedIndex = 5;
            }
            else if (TempRegion is CogEllipticalAnnulusSection)
            {
                cmbTarget.SelectedIndex = 6;
            }
            else
                cmbTarget.SelectedIndex = 0;
        }

        // 2011.10.31
        private void ATbPMAlign_FormClosed(object sender, FormClosedEventArgs e)
        {
            tmrLive.Enabled = false;
            tmrTime.Enabled = false;

            // 2015.03.17
            cogDisplay.Dispose();
            cogDisplayStatusBar.Dispose();
            cogDisplayPattern.Dispose();

            // 2017.01.09
            m_aPMAlign = null;
            m_aPMAligns = null;
            m_lstAPMAlign = null;
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL)
            m_aAcqFifo = null;
#endif
            m_aPoint = null;
            m_aDisplay = null;
            m_aDisplayPattern = null;

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

        private void txtDoubleKeyPress(object sender, KeyPressEventArgs e)
        {
            AUtil.OnlyNumberDouble(ref e);
        }

        private void txtUIntKeyPress(object sender, KeyPressEventArgs e)
        {
            AUtil.OnlyNumberUInt(ref e);
        }

        // 2013.06.03
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(!base.ProcessCmdKey(ref msg, keyData))
            {

                if(keyData.Equals(Keys.B))
                {
                    btnLoadBefore_Click(btnLoadBefore, null);
                    return true;
                }

                else if(keyData.Equals(Keys.N))
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
            // 2016.12.01
            chkRun.Visible = false;

            m_aDisplay.ClearAll();

            if (AVisionProBuild.LoadImg(strImageFile, ref m_cogImage) == true)
            {
                m_aDisplay.Image = RunCalibImage();

                m_aDisplay.Display.Fit(true);

                m_aPMAlign.InputImage = m_aDisplay.GetImage8Grey();

                m_aPoint.m_strLoadFileName = strImageFile;
                lblFileName.Text = strImageFile;
            }
        }

        private void LoadImageDirectory(string strImagePath)
        {
            // 2016.12.01
            chkRun.Visible = true;

            m_aDisplay.ClearAll();

            string strFileName = AVisionProBuild.LoadDir(strImagePath, ref m_cogImage);
            if (strFileName != "")
            {
                m_aPoint.m_strLoadFileName = strFileName;
                m_aDisplay.Image = RunCalibImage();
                m_aDisplay.Display.Fit(true);
                m_aPMAlign.InputImage = m_aDisplay.GetImage8Grey();
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

        // 2015.10.08
        private void cogDisplayPattern_DoubleClick(object sender, EventArgs e)
        {
            // 2016.12.22
            AFrm3D_1_Set frm3D_1_Set = new AFrm3D_1_Set(m_nType, m_nPoint, m_nToolIndex, m_aDisplay.Image);
            frm3D_1_Set.ShowDialog(this);

            // 2016.12.22
            m_aPoint = AVisionProBuild.GetPoint(m_nType, m_nPoint);


            if (frm3D_1_Set.m_nPage == 0)
            {
                AFindEllipse aFindEllipse = m_aPoint.GetTool("FindEllipse", 0) as AFindEllipse;
                aFindEllipse.Run(m_aDisplay);
                if (aFindEllipse.m_stResult.nR == 0)
                {
                    m_aPMAlign.SetOriginXY(aFindEllipse.m_stResult.dX, aFindEllipse.m_stResult.dY);
                    m_aPMAlign.ShowPattern(m_aDisplayPattern);
                }
            }
            else
            {
                AFindCorner aFindCorner = m_aPoint.GetTool("FindCorner", 0) as AFindCorner;
                aFindCorner.Run(m_aDisplay);
                if (aFindCorner.m_stResult.nR == 0)
                {
                    m_aPMAlign.SetOriginXY(aFindCorner.m_stResult.dX, aFindCorner.m_stResult.dY);
                    m_aPMAlign.ShowPattern(m_aDisplayPattern);
                }
            }
        }

        // 2015.12.09
        private void btnGamma_Click(object sender, EventArgs e)
        {
            m_cogImage = AVisionProBuild.RunGamma(m_cogImage, 0.5f);
            // 2016.12.01
            // 2016.08.31
            //m_cogImage = AVisionProBuild.RunEqualizeImage(m_cogImage, m_aPMAlign.SearchRegion);
            CogRectangle box;
            m_aPoint.TransCalibrated2UncalibratedCoord(m_aIni.CalibCase, m_aPMAlign.SearchRegion, out box);
            m_cogImage = AVisionProBuild.RunEqualizeImage(m_cogImage, box);
            
            m_aDisplay.Image = RunCalibImage();
                        
            m_aDisplay.Display.Fit(true);
            m_aPMAlign.InputImage = m_aDisplay.GetImage8Grey();
        }

        // 2016.06.22            
        private void chkFixtureNPointToNPoint_CheckedChanged(object sender, EventArgs e)
        {
            m_aIni.FixtureNPointToNPoint = chkFixtureNPointToNPoint.Checked;
        }
    }
}
