//#define _CHECK_ANGLE
//#define _CHECK_SCALE

// 2016.12.06
#define _VPRO9

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cognex.VisionPro;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro.Display;
using System.Windows.Forms;
using System.IO;
using Atmc;

namespace AVisionPro
{
    public class APMAlign : ACogToolBase
    {
        private CogPMAlignTool m_cogPMAlignTool = null;
        private ICogRegion m_icogRegionTrain = null;
        private ICogRegion m_icogRegionSearch = null;
        private CogImage8Grey m_icogImgMask = null;

        // 2020.03.03
        public CogTransform2DLinear m_cogTransPose = null;

        public CogCoordinateAxes m_cogCoordinateAxes = new CogCoordinateAxes();
        public ICogGraphicInteractive m_icogGraphicInteractive;

        private readonly double m_dPI = Math.PI;
        private double m_dAcceptThreshold = 0;
        private double m_dContrastThreshold = 0;
        private int m_nNumToFind = 0;
        private double m_dZoneAngleHigh = 0;
        private double m_dZoneAngleLow = 0;
        // 2016.05.10
        private double m_dZoneScaleHigh = 1;
        private double m_dZoneScaleLow = 1;
        private double m_dZoneScaleX_High = 1;
        private double m_dZoneScaleX_Low = 1;
        private double m_dZoneScaleY_High = 1;
        private double m_dZoneScaleY_Low = 1;

        private bool m_IsUsingClutter = true;
        private bool m_IsIgnorePolarity = true;

        private bool m_bFound = false;
        private int m_nFoundCount = 0;
        private double m_dScore = 0;
        private double m_dTranslationX = 0;
        private double m_dTranslationY = 0;
        private double m_dAngle = 0;
        private double m_dScale = 0;
        private bool m_bResult = false;
        private bool m_bTrained = false;

        // 2017.03.21
        private double m_dScaleX = 0;
        private double m_dScaleY = 0;

        //** 2016.01.26 by kdi
        public ICogRegion TrainedRegion
        {
            get { return m_icogRegionTrain; }
            set { m_icogRegionTrain = value; }
        }

        // 2020.03.03
        public CogTransform2DLinear TransPose
        {
            get { return m_cogTransPose; }
        }

        // 2016.03.16
        public ICogRegion SearchRegion
        {
            get { return m_icogRegionSearch; }
            set 
            { 
                m_icogRegionSearch = value;
                // 2016.03.18
                m_cogPMAlignTool.SearchRegion = value;
            }
        }

        // 2014.08.27
        public double m_dMoveSearchRegionX = 0;
        public double m_dMoveSearchRegionY = 0;
        public double m_dInitSearchRegionX = 0;
        public double m_dInitSearchRegionY = 0;
                

        public APMAlign()
        {
            m_cogPMAlignTool = new CogPMAlignTool();

            m_cogPMAlignTool.RunParams.ZoneAngle.High = 0;
            m_cogPMAlignTool.RunParams.ZoneAngle.Low = 0;
            m_cogPMAlignTool.RunParams.ZoneScale.High = 1;
            m_cogPMAlignTool.RunParams.ZoneScale.Low = 1;

            // 2013.11.29
            m_cogPMAlignTool.RunParams.ScoreUsingClutter = false;

            // 2011.07.22
            m_cogPMAlignTool.Pattern.TrainAlgorithm = (CogPMAlignTrainAlgorithmConstants)ASDef._PMALIGN_TRAIN_ALGORITHM;

            //-------------------------------
            // 2014.11.19
            // default 값
            StringBuilder sb = new StringBuilder(256);
            AUtil.GetPrivateProfileString("PMAlignTool", "AcceptThreshold", "0.7", sb, 32, ASDef._INI_FILE);
            m_cogPMAlignTool.RunParams.AcceptThreshold = Convert.ToDouble(sb.ToString());
            AUtil.GetPrivateProfileString("PMAlignTool", "ZoneAngle.High", "0", sb, 32, ASDef._INI_FILE);
            m_cogPMAlignTool.RunParams.ZoneAngle.High = Convert.ToDouble(sb.ToString()) *m_dPI / 180;
            AUtil.GetPrivateProfileString("PMAlignTool", "ZoneAngle.Low", "0", sb, 32, ASDef._INI_FILE);
            m_cogPMAlignTool.RunParams.ZoneAngle.Low = Convert.ToDouble(sb.ToString()) *m_dPI / 180;

            // 2017.07.11
            if (m_cogPMAlignTool.RunParams.ZoneAngle.High == 0 && m_cogPMAlignTool.RunParams.ZoneAngle.Low == 0)
                m_cogPMAlignTool.RunParams.ZoneAngle.Configuration = CogPMAlignZoneConstants.Nominal;
            else
                m_cogPMAlignTool.RunParams.ZoneAngle.Configuration = CogPMAlignZoneConstants.LowHigh;

            AUtil.GetPrivateProfileString("PMAlignTool", "ZoneScale.High", "1", sb, 32, ASDef._INI_FILE);
            m_cogPMAlignTool.RunParams.ZoneScale.High = Convert.ToDouble(sb.ToString());
            AUtil.GetPrivateProfileString("PMAlignTool", "ZoneScale.Low", "1", sb, 32, ASDef._INI_FILE);
            m_cogPMAlignTool.RunParams.ZoneScale.Low = Convert.ToDouble(sb.ToString());

            // 2017.07.11
            if (m_cogPMAlignTool.RunParams.ZoneScale.High == 1 && m_cogPMAlignTool.RunParams.ZoneScale.Low == 1)
                m_cogPMAlignTool.RunParams.ZoneScale.Configuration = CogPMAlignZoneConstants.Nominal;
            else
                m_cogPMAlignTool.RunParams.ZoneScale.Configuration = CogPMAlignZoneConstants.LowHigh;

            // 2017.06.08
            AUtil.GetPrivateProfileString("PMAlignTool", "ZoneScaleX.High", "1", sb, 32, ASDef._INI_FILE);
            m_cogPMAlignTool.RunParams.ZoneScaleX.High = Convert.ToDouble(sb.ToString());
            AUtil.GetPrivateProfileString("PMAlignTool", "ZoneScaleX.Low", "1", sb, 32, ASDef._INI_FILE);
            m_cogPMAlignTool.RunParams.ZoneScaleX.Low = Convert.ToDouble(sb.ToString());

            // 2017.07.11
            if (m_cogPMAlignTool.RunParams.ZoneScaleX.High == 1 && m_cogPMAlignTool.RunParams.ZoneScaleX.Low == 1)
                m_cogPMAlignTool.RunParams.ZoneScaleX.Configuration = CogPMAlignZoneConstants.Nominal;
            else
                m_cogPMAlignTool.RunParams.ZoneScaleX.Configuration = CogPMAlignZoneConstants.LowHigh;

            AUtil.GetPrivateProfileString("PMAlignTool", "ZoneScaleY.High", "1", sb, 32, ASDef._INI_FILE);
            m_cogPMAlignTool.RunParams.ZoneScaleY.High = Convert.ToDouble(sb.ToString());
            AUtil.GetPrivateProfileString("PMAlignTool", "ZoneScaleY.Low", "1", sb, 32, ASDef._INI_FILE);
            m_cogPMAlignTool.RunParams.ZoneScaleY.Low = Convert.ToDouble(sb.ToString());
            
            // 2017.07.11
            if (m_cogPMAlignTool.RunParams.ZoneScaleY.High == 1 && m_cogPMAlignTool.RunParams.ZoneScaleY.Low == 1)
                m_cogPMAlignTool.RunParams.ZoneScaleY.Configuration = CogPMAlignZoneConstants.Nominal;
            else
                m_cogPMAlignTool.RunParams.ZoneScaleY.Configuration = CogPMAlignZoneConstants.LowHigh;
            AUtil.GetPrivateProfileString("PMAlignTool", "ContrastThreshold", "10", sb, 32, ASDef._INI_FILE);
            m_cogPMAlignTool.RunParams.ContrastThreshold = Convert.ToDouble(sb.ToString());

            // 2015.04.22
            if (AUtil.GetPrivateProfileInt("PMAlignTool", "TimeOutEnabled", 1, ASDef._INI_FILE) == 0)
                m_cogPMAlignTool.RunParams.TimeoutEnabled = false;
            else
                m_cogPMAlignTool.RunParams.TimeoutEnabled = true;
            AUtil.GetPrivateProfileString("PMAlignTool", "TimeOut", "200", sb, 32, ASDef._INI_FILE);
            m_cogPMAlignTool.RunParams.Timeout = Convert.ToInt32(sb.ToString());

            //-------------------------------

            Init();
        }

        public APMAlign(Object objTool)
        {
            m_cogPMAlignTool = objTool as CogPMAlignTool;
            Init();
        }

        private void Init()
        {
            m_icogRegionTrain = m_cogPMAlignTool.Pattern.TrainRegion;
            m_icogRegionSearch = m_cogPMAlignTool.SearchRegion;
            m_icogImgMask = m_cogPMAlignTool.RunParams.SearchImageMask;
            m_dAcceptThreshold = m_cogPMAlignTool.RunParams.AcceptThreshold;
            m_nNumToFind = m_cogPMAlignTool.RunParams.ApproximateNumberToFind;
            m_dContrastThreshold = m_cogPMAlignTool.RunParams.ContrastThreshold;
            m_IsUsingClutter = m_cogPMAlignTool.RunParams.ScoreUsingClutter;
            m_IsIgnorePolarity = m_cogPMAlignTool.Pattern.IgnorePolarity;

            // 2016.12.24            
            // 2016.05.10 ----------------
            if (m_cogPMAlignTool.RunParams.ZoneAngle.Configuration == CogPMAlignZoneConstants.LowHigh)
            {
                m_dZoneAngleHigh = m_cogPMAlignTool.RunParams.ZoneAngle.High * 180 / m_dPI;
                m_dZoneAngleLow = m_cogPMAlignTool.RunParams.ZoneAngle.Low * 180 / m_dPI;
            }
            else
            {
                m_dZoneAngleHigh = 0;
                m_dZoneAngleLow = 0;
            }

            if (m_cogPMAlignTool.RunParams.ZoneScale.Configuration == CogPMAlignZoneConstants.LowHigh)
            {
                m_dZoneScaleHigh = m_cogPMAlignTool.RunParams.ZoneScale.High;
                m_dZoneScaleLow = m_cogPMAlignTool.RunParams.ZoneScale.Low;
            }
            else
            {
                m_dZoneScaleHigh = 1;
                m_dZoneScaleLow = 1;
            }

            if (m_cogPMAlignTool.RunParams.ZoneScaleX.Configuration == CogPMAlignZoneConstants.LowHigh)
            {
                m_dZoneScaleX_High = m_cogPMAlignTool.RunParams.ZoneScaleX.High;
                m_dZoneScaleX_Low = m_cogPMAlignTool.RunParams.ZoneScaleX.Low;
            }
            else
            {
                m_dZoneScaleX_High = 1;
                m_dZoneScaleX_Low = 1;
            }
            
            if (m_cogPMAlignTool.RunParams.ZoneScaleY.Configuration == CogPMAlignZoneConstants.LowHigh)
            {
                m_dZoneScaleY_High = m_cogPMAlignTool.RunParams.ZoneScaleY.High;
                m_dZoneScaleY_Low = m_cogPMAlignTool.RunParams.ZoneScaleY.Low;
            }
            else
            {
                m_dZoneScaleY_High = 1;
                m_dZoneScaleY_Low = 1;
            }
            //------------------------------
            /*
            m_dZoneAngleHigh = m_cogPMAlignTool.RunParams.ZoneAngle.High * 180 / m_dPI;
            m_dZoneAngleLow = m_cogPMAlignTool.RunParams.ZoneAngle.Low * 180 / m_dPI;
            m_dZoneScaleHigh = m_cogPMAlignTool.RunParams.ZoneScale.High;
            m_dZoneScaleLow = m_cogPMAlignTool.RunParams.ZoneScale.Low;
            */

            m_bTrained = m_cogPMAlignTool.Pattern.Trained;

            // 2014.08.27
            SetInitSearchRegion();

            // 2015.04.08            
            m_cogPMAlignTool.Ran += new EventHandler(RanEvent);
        }

        private void SetPMAlignParam()
        {
            m_nFoundCount = 0;

            if (m_cogPMAlignTool != null)
            {
                // 2014.08.08 Graphics-Disgnostics-Show Match Features 
                m_cogPMAlignTool.RunParams.SaveMatchInfo = true;

                m_cogPMAlignTool.RunParams.AcceptThreshold = m_dAcceptThreshold;
                m_cogPMAlignTool.RunParams.ApproximateNumberToFind = m_nNumToFind;
                m_cogPMAlignTool.RunParams.ContrastThreshold = m_dContrastThreshold;
                m_cogPMAlignTool.RunParams.ScoreUsingClutter = m_IsUsingClutter;
                // 2016.05.10 -----------------------
                if (m_dZoneAngleHigh == 0 && m_dZoneAngleLow == 0)
                {
                    m_cogPMAlignTool.RunParams.ZoneAngle.Configuration = CogPMAlignZoneConstants.Nominal;
                    // 2016.12.24
                    m_cogPMAlignTool.RunParams.ZoneAngle.High = 0;
                    m_cogPMAlignTool.RunParams.ZoneAngle.Low = 0;

                }
                // 2016.12.24
                //else
                else if (m_cogPMAlignTool.RunParams.ZoneAngle.Configuration == CogPMAlignZoneConstants.LowHigh)
                {
                    m_cogPMAlignTool.RunParams.ZoneAngle.Configuration = CogPMAlignZoneConstants.LowHigh;
                    m_cogPMAlignTool.RunParams.ZoneAngle.High = m_dZoneAngleHigh * m_dPI / 180;
                    m_cogPMAlignTool.RunParams.ZoneAngle.Low = m_dZoneAngleLow * m_dPI / 180;
                }

                if (m_dZoneScaleHigh == 1 && m_dZoneScaleLow == 1)
                {
                    m_cogPMAlignTool.RunParams.ZoneScale.Configuration = CogPMAlignZoneConstants.Nominal;
                    // 2016.12.24
                    m_cogPMAlignTool.RunParams.ZoneScale.High = 1;
                    m_cogPMAlignTool.RunParams.ZoneScale.Low = 1;

                }
                // 2016.12.24
                //else
                else if (m_cogPMAlignTool.RunParams.ZoneScale.Configuration == CogPMAlignZoneConstants.LowHigh)
                {
                    m_cogPMAlignTool.RunParams.ZoneScale.Configuration = CogPMAlignZoneConstants.LowHigh;
                    m_cogPMAlignTool.RunParams.ZoneScale.High = m_dZoneScaleHigh;
                    m_cogPMAlignTool.RunParams.ZoneScale.Low = m_dZoneScaleLow;
                }

                if (m_dZoneScaleX_High == 1 && m_dZoneScaleX_Low == 1)
                {
                    m_cogPMAlignTool.RunParams.ZoneScaleX.Configuration = CogPMAlignZoneConstants.Nominal;
                    // 2016.12.24
                    m_cogPMAlignTool.RunParams.ZoneScaleX.High = 1;
                    m_cogPMAlignTool.RunParams.ZoneScaleX.Low = 1;

                }
                // 2016.12.24
                //else
                else if (m_cogPMAlignTool.RunParams.ZoneScaleX.Configuration == CogPMAlignZoneConstants.LowHigh)
                {
                    m_cogPMAlignTool.RunParams.ZoneScaleX.Configuration = CogPMAlignZoneConstants.LowHigh;
                    m_cogPMAlignTool.RunParams.ZoneScaleX.High = m_dZoneScaleX_High;
                    m_cogPMAlignTool.RunParams.ZoneScaleX.Low = m_dZoneScaleX_Low;
                }
                
                if (m_dZoneScaleY_High == 1 && m_dZoneScaleY_Low == 1)
                {
                    m_cogPMAlignTool.RunParams.ZoneScaleY.Configuration = CogPMAlignZoneConstants.Nominal;
                    // 2016.12.24
                    m_cogPMAlignTool.RunParams.ZoneScaleY.High = 1;
                    m_cogPMAlignTool.RunParams.ZoneScaleY.Low = 1;

                }
                // 2016.12.24
                //else
                else if (m_cogPMAlignTool.RunParams.ZoneScaleY.Configuration == CogPMAlignZoneConstants.LowHigh)
                {
                    m_cogPMAlignTool.RunParams.ZoneScaleY.Configuration = CogPMAlignZoneConstants.LowHigh;
                    m_cogPMAlignTool.RunParams.ZoneScaleY.High = m_dZoneScaleY_High;
                    m_cogPMAlignTool.RunParams.ZoneScaleY.Low = m_dZoneScaleY_Low;
                }
                //------------------------------------

                m_cogPMAlignTool.Pattern.IgnorePolarity = m_IsIgnorePolarity;                

                if (m_icogRegionTrain != null)
                {
                    m_cogPMAlignTool.Pattern.TrainRegion = m_icogRegionTrain;
                }
                if (m_icogRegionSearch != null)
                {
                    m_cogPMAlignTool.SearchRegion = m_icogRegionSearch;
                }
            }
        }

        // 2014.010.07
        public void SetOriginXY(double dX, double dY)
        {
            m_cogPMAlignTool.Pattern.Origin.TranslationX = dX;
            m_cogPMAlignTool.Pattern.Origin.TranslationY = dY;
        }

        public bool GrabTrainRegion(ADisplay display, AVisionProBuild._emRegionShape emRegionShape)
        {
            double dScaling, dAspect, dRotation, dSkew, dTranslationX, dTranslationY;

            display.ClearOverlay();
            m_cogPMAlignTool.Pattern.Origin.GetScalingAspectRotationSkewTranslation(out dScaling, out dAspect, out dRotation, out dSkew, out dTranslationX, out dTranslationY);

            

            m_cogCoordinateAxes.SetOriginLengthAspectRotationSkew(dTranslationX, dTranslationY, dScaling, dAspect, dRotation, dSkew);
            m_cogCoordinateAxes.Interactive = true;
            // 2011.05.06
            //m_cogCoordinateAxes.GraphicDOFEnable = CogCoordinateAxesDOFConstants.All;
            m_cogCoordinateAxes.GraphicDOFEnable = CogCoordinateAxesDOFConstants.Position;
            m_cogCoordinateAxes.TipText = "Pattern Origin";
            display.AddOverlay(m_cogCoordinateAxes as ICogGraphicInteractive, "");

            ICogRegion region = m_cogPMAlignTool.Pattern.TrainRegion;
            CogCircle circle = region as CogCircle;
            CogEllipse ellipse = region as CogEllipse;
            CogRectangle rectangle = region as CogRectangle;
            CogRectangleAffine rectangleAffine = region as CogRectangleAffine;
            CogCircularAnnulusSection circularAnnuluns = region as CogCircularAnnulusSection;
            CogEllipticalAnnulusSection ellipticalAnnuluns = region as CogEllipticalAnnulusSection;

            switch (emRegionShape)
            {
                case AVisionProBuild._emRegionShape.Circle:
                    {
                        if (circle == null)
                        {
                            circle = new CogCircle();
                            //circle.FitToImage(display.GetImage8Grey(), 0.2, 0.2);
                        }
                        m_icogGraphicInteractive = circle as ICogGraphicInteractive;
                    }
                    break;
                case AVisionProBuild._emRegionShape.Ellipse:
                    {
                        if (ellipse == null)
                        {
                            ellipse = new CogEllipse();
                        }
                        m_icogGraphicInteractive = ellipse as ICogGraphicInteractive;
                    }
                    break;
                case AVisionProBuild._emRegionShape.Rectangle:
                    {
                        if (rectangle == null)
                        {
                            rectangle = new CogRectangle();
                        }
                        m_icogGraphicInteractive = rectangle as ICogGraphicInteractive;
                    }
                    break;
                case AVisionProBuild._emRegionShape.RectangleAffine:
                    {
                        if (rectangleAffine == null)
                        {
                            rectangleAffine = new CogRectangleAffine();
                        }
                        m_icogGraphicInteractive = rectangleAffine as ICogGraphicInteractive;
                    }
                    break;
                case AVisionProBuild._emRegionShape.CircularAnnulusSection:
                    {
                        if (circularAnnuluns == null)
                        {
                            circularAnnuluns = new CogCircularAnnulusSection();
                        }
                        m_icogGraphicInteractive = circularAnnuluns as ICogGraphicInteractive;
                    }
                    break;
                case AVisionProBuild._emRegionShape.EllipticalAnnulusSection:
                    {
                        if (ellipticalAnnuluns == null)
                        {
                            ellipticalAnnuluns = new CogEllipticalAnnulusSection();
                        }
                        m_icogGraphicInteractive = ellipticalAnnuluns as ICogGraphicInteractive;
                    }
                    break;
                case AVisionProBuild._emRegionShape.Entire:
                    {
                        m_icogRegionTrain = null;
                        display.ClearOverlay();

                        m_icogGraphicInteractive = null;
                    }
                    break;

                default:
                    m_icogRegionTrain = null;

                    return false;
            }

            if (m_icogGraphicInteractive != null)
            {
                m_icogGraphicInteractive.GraphicDOFEnableBase = CogGraphicDOFConstants.All;
                m_icogGraphicInteractive.Interactive = true;
                m_icogGraphicInteractive.TipText = "Region of Interest";
                display.AddOverlay(m_icogGraphicInteractive, "");
            }

            return true;
        }

        public bool GrabSearchRegion(ADisplay display, AVisionProBuild._emRegionShape emRegionShape)
        {
            display.ClearOverlay();

            ICogGraphicInteractive icogGraphInteractive = null;
            ICogRegion region = m_cogPMAlignTool.SearchRegion;

            CogCircle circle = region as CogCircle;
            CogEllipse ellipse = region as CogEllipse;
            CogRectangle rectangle = region as CogRectangle;
            CogRectangleAffine rectangleAffine = region as CogRectangleAffine;
            CogCircularAnnulusSection circularAnnuluns = region as CogCircularAnnulusSection;
            CogEllipticalAnnulusSection ellipticalAnnuluns = region as CogEllipticalAnnulusSection;

            switch (emRegionShape)
            {
                case AVisionProBuild._emRegionShape.Circle:
                    {
                        if (circle == null)
                        {
                            circle = new CogCircle();
                            circle.FitToImage(display.GetImage8Grey(), 0.5, 0.5);
                        }
                        icogGraphInteractive = circle as ICogGraphicInteractive;
                    }
                    break;
                case AVisionProBuild._emRegionShape.Ellipse:
                    {
                        if (ellipse == null)
                        {
                            ellipse = new CogEllipse();
                            ellipse.FitToImage(display.GetImage8Grey(), 0.5, 0.5);
                        }
                        icogGraphInteractive = ellipse as ICogGraphicInteractive;
                    }
                    break;
                case AVisionProBuild._emRegionShape.Rectangle:
                    {
                        if (rectangle == null)
                        {
                            rectangle = new CogRectangle();
                            rectangle.FitToImage(display.GetImage8Grey(), 0.5, 0.5);
                        }
                        icogGraphInteractive = rectangle as ICogGraphicInteractive;
                    }
                    break;
                case AVisionProBuild._emRegionShape.RectangleAffine:
                    {
                        if (rectangleAffine == null)
                        {
                            rectangleAffine = new CogRectangleAffine();
                            rectangleAffine.FitToImage(display.GetImage8Grey(), 0.5, 0.5);
                        }
                        icogGraphInteractive = rectangleAffine as ICogGraphicInteractive;
                    }
                    break;
                case AVisionProBuild._emRegionShape.CircularAnnulusSection:
                    {
                        if (circularAnnuluns == null)
                        {
                            circularAnnuluns = new CogCircularAnnulusSection();
                            circularAnnuluns.FitToImage(display.GetImage8Grey(), 0.5, 0.5);
                        }
                        icogGraphInteractive = circularAnnuluns as ICogGraphicInteractive;
                    }
                    break;
                case AVisionProBuild._emRegionShape.EllipticalAnnulusSection:
                    {
                        if (ellipticalAnnuluns == null)
                        {
                            ellipticalAnnuluns = new CogEllipticalAnnulusSection();
                            ellipticalAnnuluns.FitToImage(display.GetImage8Grey(), 0.5, 0.5);
                        }
                        icogGraphInteractive = ellipticalAnnuluns as ICogGraphicInteractive;
                    }
                    break;
                case AVisionProBuild._emRegionShape.Entire:
                    {
                        m_icogRegionSearch = null;
                        display.ClearOverlay();
                    }
                    break;

                default:
                    m_icogRegionSearch = null;
                    return false;
            }

            if (icogGraphInteractive != null)
            {
                icogGraphInteractive.GraphicDOFEnableBase = CogGraphicDOFConstants.All;
                icogGraphInteractive.Interactive = true;
                icogGraphInteractive.TipText = "Region To Search";
                display.AddOverlay(icogGraphInteractive, "");
            }

            
            return true;
        }

        public void SetSearchRegion(ADisplay display)
        {
            ICogGraphicInteractive icogGraphInteractive = display.GetInteractiveGraphics("Region To Search");

            if (icogGraphInteractive != null)
            {
                icogGraphInteractive.GraphicDOFEnableBase = CogGraphicDOFConstants.None;
                icogGraphInteractive.Interactive = false;
            }

            m_cogPMAlignTool.SearchRegion = icogGraphInteractive as ICogRegion;
            // 2011.04.21
            m_icogRegionSearch = m_cogPMAlignTool.SearchRegion;

        }

        // 2014.08.27
        public void MoveSearchRegion(double x, double y)
        {
            m_dMoveSearchRegionX = x;
            m_dMoveSearchRegionY = y;

            ICogRegion region = m_cogPMAlignTool.SearchRegion;

            if (region is CogCircle)
            {
                CogCircle circle = region as CogCircle;

                circle.CenterX = m_dInitSearchRegionX + x;
                circle.CenterY = m_dInitSearchRegionY + y;
            }
            else if (region is CogEllipse)
            {
                CogEllipse ellipse = region as CogEllipse;
                ellipse.CenterX = m_dInitSearchRegionX + x;
                ellipse.CenterY = m_dInitSearchRegionY + y;
            }
            else if (region is CogRectangle)
            {
                CogRectangle rectangle = region as CogRectangle;
                rectangle.X = m_dInitSearchRegionX + x;
                rectangle.Y = m_dInitSearchRegionY + y;
            }
            else if (region is CogRectangleAffine)
            {
                CogRectangleAffine rectangleAffine = region as CogRectangleAffine;
                rectangleAffine.CenterX = m_dInitSearchRegionX + x;
                rectangleAffine.CenterY = m_dInitSearchRegionY + y;
            }            
            else if (region is CogCircularAnnulusSection)
            {
                CogCircularAnnulusSection circularAnnuluns = region as CogCircularAnnulusSection;
                circularAnnuluns.CenterX = m_dInitSearchRegionX + x;
                circularAnnuluns.CenterY = m_dInitSearchRegionY + y;
            }
            else if (region is CogEllipticalAnnulusSection)
            {
                CogEllipticalAnnulusSection ellipticalAnnuluns = region as CogEllipticalAnnulusSection;
                ellipticalAnnuluns.CenterX = m_dInitSearchRegionX + x;
                ellipticalAnnuluns.CenterY = m_dInitSearchRegionY + y;
            }
        }

        // 2014.08.27
        public void SetInitSearchRegion(double dX, double dY)
        {
            m_dInitSearchRegionX = dX;
            m_dInitSearchRegionY = dY;

            ICogRegion region = m_cogPMAlignTool.SearchRegion;

            if (region is CogCircle)
            {
                CogCircle circle = region as CogCircle;

                circle.CenterX = m_dInitSearchRegionX;
                circle.CenterY = m_dInitSearchRegionY;
            }
            else if (region is CogEllipse)
            {
                CogEllipse ellipse = region as CogEllipse;
                ellipse.CenterX = m_dInitSearchRegionX;
                ellipse.CenterY = m_dInitSearchRegionY;
            }
            else if (region is CogRectangle)
            {
                CogRectangle rectangle = region as CogRectangle;
                rectangle.X = m_dInitSearchRegionX;
                rectangle.Y = m_dInitSearchRegionY;
            }
            else if (region is CogRectangleAffine)
            {
                CogRectangleAffine rectangleAffine = region as CogRectangleAffine;
                rectangleAffine.CenterX = m_dInitSearchRegionX;
                rectangleAffine.CenterY = m_dInitSearchRegionY;
            }
            else if (region is CogCircularAnnulusSection)
            {
                CogCircularAnnulusSection circularAnnuluns = region as CogCircularAnnulusSection;
                circularAnnuluns.CenterX = m_dInitSearchRegionX;
                circularAnnuluns.CenterY = m_dInitSearchRegionY;
            }
            else if (region is CogEllipticalAnnulusSection)
            {
                CogEllipticalAnnulusSection ellipticalAnnuluns = region as CogEllipticalAnnulusSection;
                ellipticalAnnuluns.CenterX = m_dInitSearchRegionX;
                ellipticalAnnuluns.CenterY = m_dInitSearchRegionY;
            }
        }
        public void SetInitSearchRegion()
        {
            ICogRegion region = m_cogPMAlignTool.SearchRegion;

            if (region is CogCircle)
            {
                CogCircle circle = region as CogCircle;

                m_dInitSearchRegionX = circle.CenterX - m_dMoveSearchRegionX;
                m_dInitSearchRegionY = circle.CenterY - m_dMoveSearchRegionY;
            }
            else if (region is CogEllipse)
            {
                CogEllipse ellipse = region as CogEllipse;
                m_dInitSearchRegionX = ellipse.CenterX - m_dMoveSearchRegionX;
                m_dInitSearchRegionY = ellipse.CenterY - m_dMoveSearchRegionY;
            }
            else if (region is CogRectangle)
            {
                CogRectangle rectangle = region as CogRectangle;
                m_dInitSearchRegionX = rectangle.X - m_dMoveSearchRegionX;
                m_dInitSearchRegionY = rectangle.Y - m_dMoveSearchRegionY;
            }
            else if (region is CogRectangleAffine)
            {
                CogRectangleAffine rectangleAffine = region as CogRectangleAffine;
                m_dInitSearchRegionX = rectangleAffine.CenterX - m_dMoveSearchRegionX;
                m_dInitSearchRegionY = rectangleAffine.CenterY - m_dMoveSearchRegionY;
            }
            else if (region is CogCircularAnnulusSection)
            {
                CogCircularAnnulusSection circularAnnuluns = region as CogCircularAnnulusSection;
                m_dInitSearchRegionX = circularAnnuluns.CenterX - m_dMoveSearchRegionX;
                m_dInitSearchRegionY = circularAnnuluns.CenterY - m_dMoveSearchRegionY;
            }
            else if (region is CogEllipticalAnnulusSection)
            {
                CogEllipticalAnnulusSection ellipticalAnnuluns = region as CogEllipticalAnnulusSection;
                m_dInitSearchRegionX = ellipticalAnnuluns.CenterX - m_dMoveSearchRegionX;
                m_dInitSearchRegionY = ellipticalAnnuluns.CenterY - m_dMoveSearchRegionY;
            }

        }

        public void SetTrainRegion(ADisplay display)
        {
            m_icogGraphicInteractive = display.GetInteractiveGraphics("Region of Interest");

            if (m_icogGraphicInteractive != null)
            {
                m_icogGraphicInteractive.GraphicDOFEnableBase = CogGraphicDOFConstants.None;
                m_icogGraphicInteractive.Interactive = false;

                ICogGraphicInteractive axes = display.GetInteractiveGraphics("Pattern Origin");

                if (axes != null)
                {
                    axes.GraphicDOFEnableBase = CogGraphicDOFConstants.None;
                    axes.Interactive = false;
                    double dScaling, dAspect, dRotation, dSkew, dTranslationX, dTranslationY;

                    m_cogCoordinateAxes.GetOriginLengthAspectRotationSkew(out dTranslationX, out dTranslationY, out dScaling, out dAspect, out dRotation, out dSkew);
                    m_cogPMAlignTool.Pattern.Origin.SetScalingAspectRotationSkewTranslation(dScaling, dAspect, dRotation, dSkew, dTranslationX, dTranslationY);
                }
            }
            
            m_cogPMAlignTool.Pattern.TrainRegion = m_icogGraphicInteractive as ICogRegion;
            // 2011.04.21
            m_icogRegionTrain = m_cogPMAlignTool.Pattern.TrainRegion;
        }

        public void Untrain(ADisplay displayPattern)
        {
            if (m_bTrained == true)
            {
                m_cogPMAlignTool.Pattern.Untrain();
                displayPattern.ClearAll();

                m_bTrained = false;
            }
        }

        // 2016.01.26 by kdi
        public bool Train(ADisplay display)
        {
            return Train(display, m_icogImgMask);
        }

        public bool Train(ADisplay display, CogImage8Grey imageMask)
        {
            CogImage8Grey inputImage = display.GetImage8Grey();

            if (inputImage == null)
            {
                m_bTrained = false;
            }
            else
            {
                if (imageMask != null)
                {
                    m_cogPMAlignTool.Pattern.TrainImageMask = imageMask;
                }

                // 2011.06.18
                try
                {
                    m_cogPMAlignTool.Pattern.TrainImage = inputImage;
                    m_cogPMAlignTool.Pattern.Train();
                    m_icogRegionTrain = m_cogPMAlignTool.Pattern.TrainRegion;
                    display.ClearOverlay();

                    m_bTrained = true;
                }
                catch{};
                
            }

            return m_bTrained;
        }

        public void ViewLastTrainRegion(ADisplay display)
        {
            if (m_bTrained == true)
            {
                ICogRegion region = m_icogRegionTrain;
                m_icogGraphicInteractive = region as ICogGraphicInteractive;

                if (m_icogGraphicInteractive != null)
                {
                    m_icogGraphicInteractive.GraphicDOFEnableBase = CogGraphicDOFConstants.All;
                    m_icogGraphicInteractive.Interactive = true;
                    display.AddOverlay(m_icogGraphicInteractive, "");

                    double dScaling, dAspect, dRotation, dSkew, dTranslationX, dTranslationY;

                    CogTransform2DLinear Transform2DLinear = m_cogPMAlignTool.Pattern.Origin;
                    Transform2DLinear.GetScalingAspectRotationSkewTranslation(out dScaling, out dAspect, out dRotation, out dSkew, out dTranslationX, out dTranslationY);

                    if (Transform2DLinear != null)
                    {
                        m_cogCoordinateAxes.SetOriginLengthAspectRotationSkew(dTranslationX, dTranslationY, dScaling, dAspect, dRotation, dSkew);
                        ICogGraphicInteractive axesIntercative = m_cogCoordinateAxes as ICogGraphicInteractive;

                        // 2011.04.22
                        //axesIntercative.GraphicDOFEnableBase = CogGraphicDOFConstants.All;
                        axesIntercative.GraphicDOFEnableBase = CogGraphicDOFConstants.Position;

                        axesIntercative.Interactive = true;
                        axesIntercative.TipText = "Pattern Origin";
                        display.AddOverlay(axesIntercative, "");
                    }
                }
            }
        }

        public void ViewLastSearchRegion(ADisplay display)
        {
            ICogRegion region = m_cogPMAlignTool.SearchRegion;
            ICogGraphicInteractive icogGraphInteractive = region as ICogGraphicInteractive;

            if (icogGraphInteractive != null)
            {
                icogGraphInteractive.GraphicDOFEnableBase = CogGraphicDOFConstants.All;
                icogGraphInteractive.Interactive = true;
                // 2016.09.19 by kdi
                icogGraphInteractive.TipText = "Region To Search";

                display.AddOverlay(icogGraphInteractive, "");                
            }
        }

        public void ShowPattern(ADisplay display)
        {
            if (m_bTrained == true)
            {
                try
                {
                    display.ClearAll();
                    display.Display.Image = m_cogPMAlignTool.Pattern.GetTrainedPatternImage();

                    // 2014.07.28
                    if (TrainMode == CogPMAlignTrainModeConstants.Image)
                    {
                        CogImage8Grey mask = m_cogPMAlignTool.Pattern.GetTrainedPatternImageMask();
                        if (mask != null)
                        {
                            CogMaskGraphic MaskGraphic = new CogMaskGraphic();
                            MaskGraphic.Image = mask;
                            display.AddStaticGraphic(MaskGraphic as ICogGraphic, "");

                            // 2016.03.16
                            m_icogImgMask = m_cogPMAlignTool.Pattern.TrainImageMask;
                        }
                    }
                    
                    ShowPatternOrigin(display);
                    ShowPatternRegion(display);
                    ShowCoarse(display);
                    ShowFine(display);

                    // 2018.04.09
                    // 2014.07.28
                    //ShowTrainShapeModel(display);                      

                }
                catch
                {
                }
                
            }
        }

        private void ShowPatternRegion(ADisplay display)
        {
            ICogRegion region = m_icogRegionTrain;
            m_icogGraphicInteractive = region as ICogGraphicInteractive;

            if (m_icogGraphicInteractive != null)
            {
                m_icogGraphicInteractive.GraphicDOFEnableBase = CogGraphicDOFConstants.None;
                m_icogGraphicInteractive.Interactive = false;
                m_icogGraphicInteractive.Color = CogColorConstants.Cyan;
                display.AddStaticGraphic(m_icogGraphicInteractive, "");
            }
        }

        private void ShowPatternOrigin(ADisplay display)
        {
            double dScaling, dAspect, dRotation, dSkew, dOriginX, dOriginY;

            CogTransform2DLinear Transform2DLinear = m_cogPMAlignTool.Pattern.Origin;
            Transform2DLinear.GetScalingAspectRotationSkewTranslation(out dScaling, out dAspect, out dRotation, out dSkew, out dOriginX, out dOriginY);

            CogCoordinateAxes coordinateAxes = new CogCoordinateAxes(m_cogCoordinateAxes);
            coordinateAxes.SetOriginLengthAspectRotationSkew(dOriginX, dOriginY, dScaling, dAspect, dRotation, dSkew);

            ICogGraphicInteractive icogGraphInteractive = coordinateAxes as ICogGraphicInteractive;
            icogGraphInteractive.Interactive = false;
            icogGraphInteractive.Color = CogColorConstants.Cyan;

            display.AddStaticGraphic(icogGraphInteractive, "");
        }

        private void ShowCoarse(ADisplay display)
        {
            CogGraphicCollection GraphicCollection = m_cogPMAlignTool.Pattern.CreateGraphicsCoarse(CogColorConstants.Yellow);

            for (int i = 0; i < GraphicCollection.Count; i++)
            {
                display.AddStaticGraphic(GraphicCollection[i] as ICogGraphic, "");
            }
        }

        private void ShowFine(ADisplay display)
        {
            CogGraphicCollection GraphicCollection = m_cogPMAlignTool.Pattern.CreateGraphicsFine(CogColorConstants.Green);

            for (int i = 0; i < GraphicCollection.Count; i++)
            {
                display.AddStaticGraphic(GraphicCollection[i] as ICogGraphic, "");
            } 
        }

        /* 2018.04.09
        // 2014.07.28
        private void ShowTrainShapeModel(ADisplay display)
        {
            for (int i = 0; i < m_cogPMAlignTool.Pattern.GetTrainedPatternShapeModels().Count; i++)
            {
                display.AddStaticGraphic(m_cogPMAlignTool.Pattern.GetTrainedPatternShapeModels().get_Item(i) as ICogGraphic, "");
            }
        }
        */

        public void ShowTrainRegion(ADisplay display)
        {
            ShowPatternRegion(display);
        }

        public void ShowTrainOrigin(ADisplay display)
        {
            ShowPatternOrigin(display);
        }

        public void ShowSearchRegion(ADisplay display)
        {
            ICogRegion searchRegion = m_cogPMAlignTool.SearchRegion;
            ICogGraphicInteractive searchInteractive = searchRegion as ICogGraphicInteractive;

            if (searchInteractive != null)
            {
                searchInteractive.GraphicDOFEnableBase = CogGraphicDOFConstants.None;
                searchInteractive.Interactive = false;
                searchInteractive.Color = CogColorConstants.DarkGreen;
                display.AddOverlay(searchInteractive, "");
            }
        }

        // 2020.03.03
        public void ShowSearchRegion(ADisplay display, string strSelectedSpaceName)
        {
            ICogRegion searchRegion = m_cogPMAlignTool.SearchRegion;
            ICogGraphicInteractive searchInteractive = searchRegion as ICogGraphicInteractive;

            if (searchInteractive != null)
            {
                searchInteractive.SelectedSpaceName = strSelectedSpaceName;

                searchInteractive.GraphicDOFEnableBase = CogGraphicDOFConstants.None;
                searchInteractive.Interactive = false;
                searchInteractive.Color = CogColorConstants.DarkGreen;
                display.AddOverlay(searchInteractive, "");
            }
        }

        private void ShowSearchedResult(ADisplay display, int nIndex)
        {
            CogPMAlignResult pmAlignResult = new CogPMAlignResult();
            pmAlignResult=m_cogPMAlignTool.Results[nIndex];

            
            if (pmAlignResult != null)
            {
                // 2014.07.25
                if (m_bFound == true)
                {
                    CogCompositeShape compositeShape = new CogCompositeShape();

                    // 2014.07.28 +16
                    compositeShape = pmAlignResult.CreateResultGraphics((CogPMAlignResultGraphicConstants)(1 + 64 + 32 + 16));
                                        
                    display.AddOverlay(compositeShape as ICogGraphicInteractive, "");
                }
            }
        }

        // 2020.03.03
        private void ShowSearchedResult(ADisplay display, int nIndex, string strSelectedSpaceName)
        {
            CogPMAlignResult pmAlignResult = new CogPMAlignResult();
            pmAlignResult = m_cogPMAlignTool.Results[nIndex];


            if (pmAlignResult != null)
            {
                // 2014.07.25
                if (m_bFound == true)
                {
                    CogCompositeShape compositeShape = new CogCompositeShape();

                    // 2014.07.28 +16
                    compositeShape = pmAlignResult.CreateResultGraphics((CogPMAlignResultGraphicConstants)(1 + 64 + 32 + 16));
                    compositeShape.SelectedSpaceName = strSelectedSpaceName;

                    display.AddOverlay(compositeShape as ICogGraphicInteractive, "");
                }
            }
        }
        
        public void GetResult(int nIndex)
        {
            if (nIndex >= 0)
            {
                // 2020.03.03
                m_cogTransPose =  m_cogPMAlignTool.Results[nIndex].GetPose();

                m_dTranslationX = m_cogPMAlignTool.Results[nIndex].GetPose().TranslationX;
                m_dTranslationY = m_cogPMAlignTool.Results[nIndex].GetPose().TranslationY;
                m_dScore = m_cogPMAlignTool.Results[nIndex].Score;
                m_dAngle = m_cogPMAlignTool.Results[nIndex].GetPose().Rotation / m_dPI * 180;
                m_dScale = m_cogPMAlignTool.Results[nIndex].GetPose().Scaling;

                // 2017.03.21
                m_dScaleX = m_cogPMAlignTool.Results[nIndex].GetPose().ScalingX;
                m_dScaleY = m_cogPMAlignTool.Results[nIndex].GetPose().ScalingY;

                if (m_dScore >= m_dAcceptThreshold)
                {
                    m_bResult = true;

                    // 2017.03.23  --------------------------------------------------
#if _CHECK_ANGLE
                    if (!(ZoneAngleLow == 0 && ZoneAngleHigh == 0))
                    {
                        if (m_dAngle < ZoneAngleLow ||
                            m_dAngle > ZoneAngleHigh)
                        {
                            m_bResult = false;
                        }
                    }
#endif
#if _CHECK_SCALE
                    if (!(ZoneScaleLow == 1 && ZoneScaleHigh == 1))
                    {
                        if (m_dScale < ZoneScaleLow ||
                            m_dScale > ZoneScaleHigh)
                        {
                            m_bResult = false;
                        }
                    }

                    if (!(ZoneScaleX_Low == 1 && ZoneScaleX_High == 1))
                    {
                        if (m_dScaleX < ZoneScaleX_Low ||
                            m_dScaleX > ZoneScaleX_High)
                        {
                            m_bResult = false;
                        }
                    }
                    if (!(ZoneScaleY_Low == 1 && ZoneScaleY_High == 1))
                    {
                        if (m_dScaleY < ZoneScaleY_Low ||
                            m_dScaleY > ZoneScaleY_High)
                        {
                            m_bResult = false;
                        }
                    }

#endif
                    // -----------------------------------------------------------------

                }
                else
                {
                    m_bResult = false;
                }
            }
            else
            {
                m_dTranslationX = 0;
                m_dTranslationY = 0;
                m_dScore = 0;
                m_dAngle = 0;
                m_dScale = 0;
                m_bResult = false;

                // 2017.03.21
                m_dScaleX = 0;
                m_dScaleY = 0;

            }
        }
        // 2013.02.05
        public int GetRun()
        {
            SetPMAlignParam();

            if (m_cogPMAlignTool != null)
            {
                try
                {
                    if (m_bTrained == true)
                    {
                        if (m_cogPMAlignTool.Results != null)
                        {
                            m_nFoundCount = m_cogPMAlignTool.Results.Count;

                            // 2017.03.23
                            // 2014.07.25
                            double score = 0;
                            //double score = m_dAcceptThreshold;

                            // 2016.01.28
                            double dAngle = 0, dScale = 0;
                            // 2017.03.21
                            double dScaleX = 0, dScaleY = 0;


                            for (int i = 0; i < m_nFoundCount; i++)
                            {
                                if (m_cogPMAlignTool.Results[i].Score > score)
                                {
                                    score = m_cogPMAlignTool.Results[i].Score;
                                    // 2016.01.29
                                    dAngle = m_cogPMAlignTool.Results[i].GetPose().Rotation / m_dPI * 180;
                                    dScale = m_cogPMAlignTool.Results[i].GetPose().Scaling;

                                    // 2017.03.21
                                    dScaleX = m_cogPMAlignTool.Results[i].GetPose().ScalingX;
                                    dScaleY = m_cogPMAlignTool.Results[i].GetPose().ScalingY;

                                }
                            }

                            // 2017.03.23
                            // 2014.07.25
                            //if (score > m_dAcceptThreshold)
                            if (score >= m_dAcceptThreshold)
                            {
                                m_dScore = score;
                                m_bFound = true;
                                // 2016.01.29
                                m_dAngle = dAngle;
                                m_dScale = dScale;

                                // 2017.03.21
                                m_dScaleX = dScaleX;
                                m_dScaleY = dScaleY;


                                // 2017.03.23  --------------------------------------------------
                                m_bResult = true;
#if _CHECK_ANGLE
                                if (!(ZoneAngleLow == 0 && ZoneAngleHigh == 0))
                                {
                                    if (m_dAngle < ZoneAngleLow ||
                                        m_dAngle > ZoneAngleHigh)
                                    {
                                        m_bResult = false;
                                    }
                                }
#endif
#if _CHECK_SCALE
                                if (!(ZoneScaleLow == 1 && ZoneScaleHigh == 1))
                                {
                                    if (m_dScale < ZoneScaleLow ||
                                        m_dScale > ZoneScaleHigh)
                                    {
                                        m_bResult = false;
                                    }
                                }

                                if (!(ZoneScaleX_Low == 1 && ZoneScaleX_High == 1))
                                {
                                    if (m_dScaleX < ZoneScaleX_Low ||
                                        m_dScaleX > ZoneScaleX_High)
                                    {
                                        m_bResult = false;
                                    }
                                }
                                if (!(ZoneScaleY_Low == 1 && ZoneScaleY_High == 1))
                                {
                                    if (m_dScaleY < ZoneScaleY_Low ||
                                        m_dScaleY > ZoneScaleY_High)
                                    {
                                        m_bResult = false;
                                    }
                                }

#endif
                                // -----------------------------------------------------------------

                            }
                            else
                            {
                                m_dScore = 0;
                                m_bResult = false;
                                m_bFound = false;

                                // 2017.03.23
                                m_dAngle = 0;
                                m_dScale = 0;

                                // 2017.03.21
                                m_dScaleX = 0;
                                m_dScaleY = 0;

                            }
                        }
                        else
                        {
                            m_bFound = false;
                        }
                    }
                }
                catch
                {
                }
            }

            return m_nFoundCount;
        }

        public int Run(ADisplay display)
        {
            SetPMAlignParam();
            
            if (m_cogPMAlignTool != null)
            {
                m_cogPMAlignTool.InputImage = display.GetImage8Grey();                

                try
                {
                    if (m_bTrained == true)
                    {
                        // 2014.07.25
                        if (m_dAcceptThreshold > 0.5)
                            m_cogPMAlignTool.RunParams.AcceptThreshold = 0.5;
                        
                        // 2015.04.08
                        m_bRan = false;

                        m_cogPMAlignTool.Run();

                        // 2015.04.08
                        WaitRanEvent();

                        if (m_cogPMAlignTool.Results != null)
                        {
                            m_nFoundCount = m_cogPMAlignTool.Results.Count;
                            // 2013.08.29
                            if (m_nFoundCount > 0)
                            {
                                // 2017.03.15 
                                // 2014.07.25
                                double score = 0;
                                //double score = m_dAcceptThreshold;
                                
                                // 2017.03.21
                                int nIndex = 0;

                                for (int i = 0; i < m_nFoundCount; i++)
                                {
                                    if (m_cogPMAlignTool.Results[i].Score > score)
                                    {
                                        score = m_cogPMAlignTool.Results[i].Score;
                                        // 2017.03.21
                                        nIndex = i;
                                    }
                                }

                                // 2014.07.25
                                //2017.03.15 by kdi. if (score > m_dAcceptThreshold)
                                if (score >= m_dAcceptThreshold)
                                {
                                    m_dScore = score;
                                    m_bFound = true;

                                    // 2017.03.21
                                    GetResult(nIndex);

                                }
                                else
                                {
                                    m_dScore = 0;
                                    m_bResult = false;
                                    m_bFound = false;
                                    // 2017.03.21
                                    m_nFoundCount = 0;

                                }
                            }
                            else
                            {
                                // 2013.09.24
                                m_dScore = 0;
                                m_bResult = false;
                                m_bFound = false;

                                // 2017.03.21
                                m_nFoundCount = 0;
                            }
                        }
                        else
                        {
                            // 2013.09.24
                            m_dScore = 0;
                            m_bResult = false;
                            m_bFound = false;

                            // 2017.03.21
                            m_nFoundCount = 0;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Run PMAlign Error");
                }
                // 2014.07.25
                finally
                {
                    m_cogPMAlignTool.RunParams.AcceptThreshold = m_dAcceptThreshold;
                }
            }

            return m_nFoundCount;
        }

        // 2015.10.18
        public int Run(ICogImage cogImage)
        {
            SetPMAlignParam();

            if (m_cogPMAlignTool != null)
            {
                m_cogPMAlignTool.InputImage = (CogImage8Grey)cogImage;

                try
                {
                    if (m_bTrained == true)
                    {
                        // 2014.07.25
                        if (m_dAcceptThreshold > 0.5)
                            m_cogPMAlignTool.RunParams.AcceptThreshold = 0.5;

                        // 2015.04.08
                        m_bRan = false;

                        m_cogPMAlignTool.Run();

                        // 2015.04.08
                        WaitRanEvent();

                        if (m_cogPMAlignTool.Results != null)
                        {
                            m_nFoundCount = m_cogPMAlignTool.Results.Count;
                            // 2013.08.29
                            if (m_nFoundCount > 0)
                            {
                                // 2017.03.23
                                // 2014.07.25
                                double score = 0;
                                //double score = m_dAcceptThreshold;

                                // 2017.03.23
                                int nIndex = 0;

                                for (int i = 0; i < m_nFoundCount; i++)
                                {
                                    if (m_cogPMAlignTool.Results[i].Score > score)
                                    {
                                        score = m_cogPMAlignTool.Results[i].Score;
                                        // 2017.03.23
                                        nIndex = i;

                                    }
                                }

                                // 2017.03.23
                                // 2014.07.25
                                //if (score > m_dAcceptThreshold)
                                if (score >= m_dAcceptThreshold)
                                {
                                    m_dScore = score;
                                    m_bFound = true;

                                    // 2017.03.23
                                    GetResult(nIndex);

                                }
                                else
                                {
                                    m_dScore = 0;
                                    m_bResult = false;
                                    m_bFound = false;
                                }
                            }
                            else
                            {
                                // 2013.09.24
                                m_dScore = 0;
                                m_bResult = false;
                                m_bFound = false;
                            }
                        }
                        else
                        {
                            // 2013.09.24
                            m_dScore = 0;
                            m_bResult = false;
                            m_bFound = false;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Run PMAlign Error");
                }
                // 2014.07.25
                finally
                {
                    m_cogPMAlignTool.RunParams.AcceptThreshold = m_dAcceptThreshold;
                }
            }

            return m_nFoundCount;
        }

        // 2014.09.03
        public void ShowResult(ADisplay display, bool bView)
        {
            int count = 0;
            
            if (m_nFoundCount > 0)
            {
                int index = 0;

                for (int i = 0; i < m_nFoundCount; i++)
                {
                    if (m_cogPMAlignTool.Results[i].Score == m_dScore)
                    {
                        index = i;
                        break;
                    }
                }

                GetResult(index);                
            }

            // 2014.09.03
            if (bView)
            {
                if (m_nNumToFind <= m_nFoundCount)
                {
                    count = m_nNumToFind;
                }
                else
                {
                    count = m_nFoundCount;
                }

                for (int i = 0; i < count; i++)
                {
                    ShowSearchedResult(display, i);
                }

                ShowSearchRegion(display);
            }
        }

        // 2020.03.03
        public void ShowResult(ADisplay display, bool bView, string strSelectedSpaceName)
        {
            int count = 0;

            if (m_nFoundCount > 0)
            {
                int index = 0;

                for (int i = 0; i < m_nFoundCount; i++)
                {
                    if (m_cogPMAlignTool.Results[i].Score == m_dScore)
                    {
                        index = i;
                        break;
                    }
                }

                GetResult(index);
            }

            // 2014.09.03
            if (bView)
            {
                if (m_nNumToFind <= m_nFoundCount)
                {
                    count = m_nNumToFind;
                }
                else
                {
                    count = m_nFoundCount;
                }

                for (int i = 0; i < count; i++)
                {
                    ShowSearchedResult(display, i, strSelectedSpaceName);
                }

                ShowSearchRegion(display, strSelectedSpaceName);
            }
        }

        public void SavePattern(string strPtnName, CogPMAlignPattern pattern)
        {
            CogSerializer.SaveObjectToFile(pattern, strPtnName);
        }

        public bool LoadPattern(string strPtnName, ADisplay display)
        {
            if (File.Exists(strPtnName))
            {
                try
                {
                    CogPMAlignPattern pattern = CogSerializer.LoadObjectFromFile(strPtnName) as CogPMAlignPattern;

                    display.ClearAll();
                    display.Display.Image = pattern.GetTrainedPatternImage();

                    CogImage8Grey mask = pattern.GetTrainedPatternImageMask();
                    if (mask != null)
                    {
                        CogMaskGraphic MaskGraphic = new CogMaskGraphic();
                        MaskGraphic.Image = mask;
                        display.AddStaticGraphic(MaskGraphic as ICogGraphic, "");
                    }

                    ShowPatternOrigin(display);
                    ShowCoarse(display);
                    ShowFine(display);

                    return true;
                }
                catch { }
            }

            display.ClearAll();
            return false;
        }

// 2016.12.06
#if !_VPRO9
        public CogImage8Grey InputImage
#else
        public ICogImage InputImage
#endif
        {
            get { return m_cogPMAlignTool.InputImage; }
            set { m_cogPMAlignTool.InputImage = value; }
        }

        public CogPMAlignTool GetTool()
        {
            return m_cogPMAlignTool;
        }

        public bool Trained
        {
            get { return m_bTrained; }
        }

        public double AcceptThreshold
        {
            get { return m_dAcceptThreshold; }
            set { m_dAcceptThreshold = (double)value; }
        }

        public double ContrastThreshold
        {
            get { return m_dContrastThreshold; }
            set { m_dContrastThreshold = (double)value; }
        }

        public int NumberToFind
        {
            get { return m_nNumToFind; }
            set { m_nNumToFind = (int)value; }
        }

        public bool IsFound
        {
            get { return m_bFound; }
        }       
                
        public double ZoneAngleHigh
        {
            get { return m_dZoneAngleHigh; }
            set 
            { 
                m_dZoneAngleHigh = (double)value;

                // 2017.01.16
                if (ZoneAngleHigh == 0 && ZoneAngleLow == 0)
                    m_cogPMAlignTool.RunParams.ZoneAngle.Configuration = CogPMAlignZoneConstants.Nominal;
                else
                    m_cogPMAlignTool.RunParams.ZoneAngle.Configuration = CogPMAlignZoneConstants.LowHigh;

            }
        }

        public double ZoneAngleLow
        {
            get { return m_dZoneAngleLow; }
            set 
            { 
                m_dZoneAngleLow = (double)value;

                // 2017.01.16
                if (ZoneAngleHigh == 0 && ZoneAngleLow == 0)
                    m_cogPMAlignTool.RunParams.ZoneAngle.Configuration = CogPMAlignZoneConstants.Nominal;
                else
                    m_cogPMAlignTool.RunParams.ZoneAngle.Configuration = CogPMAlignZoneConstants.LowHigh;

            }
        }

        public double ZoneScaleHigh
        {
            get { return m_dZoneScaleHigh; }
            set 
            { 
                m_dZoneScaleHigh = (double)value;

                // 2017.01.16
                if (ZoneScaleHigh == 1 && ZoneScaleLow == 1)
                    m_cogPMAlignTool.RunParams.ZoneScale.Configuration = CogPMAlignZoneConstants.Nominal;
                else
                    m_cogPMAlignTool.RunParams.ZoneScale.Configuration = CogPMAlignZoneConstants.LowHigh;

            }
        }

        public double ZoneScaleLow
        {
            get { return m_dZoneScaleLow; }
            set 
            { 
                m_dZoneScaleLow = (double)value; 
                // 2017.01.16
                if (ZoneScaleHigh == 1 && ZoneScaleLow == 1)
                    m_cogPMAlignTool.RunParams.ZoneScale.Configuration = CogPMAlignZoneConstants.Nominal;
                else
                    m_cogPMAlignTool.RunParams.ZoneScale.Configuration = CogPMAlignZoneConstants.LowHigh;

            }
        }
        // 2016.05.10 -------------------------
        public double ZoneScaleX_High
        {
            get { return m_dZoneScaleX_High; }
            set 
            { 
                m_dZoneScaleX_High = (double)value; 

                // 2017.01.16
                if (ZoneScaleX_High == 1 && ZoneScaleX_Low == 1)
                    m_cogPMAlignTool.RunParams.ZoneScaleX.Configuration = CogPMAlignZoneConstants.Nominal;
                else
                    m_cogPMAlignTool.RunParams.ZoneScaleX.Configuration = CogPMAlignZoneConstants.LowHigh;

            }
        }
        public double ZoneScaleX_Low
        {
            get { return m_dZoneScaleX_Low; }
            set 
            { 
                m_dZoneScaleX_Low = (double)value;

                // 2017.01.16
                if (ZoneScaleX_High == 1 && ZoneScaleX_Low == 1)
                    m_cogPMAlignTool.RunParams.ZoneScaleX.Configuration = CogPMAlignZoneConstants.Nominal;
                else
                    m_cogPMAlignTool.RunParams.ZoneScaleX.Configuration = CogPMAlignZoneConstants.LowHigh;

            }
        }

        public double ZoneScaleY_High
        {
            get { return m_dZoneScaleY_High; }
            set 
            { 
                m_dZoneScaleY_High = (double)value;

                // 2017.01.16
                if (ZoneScaleY_High == 1 && ZoneScaleY_Low == 1)
                    m_cogPMAlignTool.RunParams.ZoneScaleY.Configuration = CogPMAlignZoneConstants.Nominal;
                else
                    m_cogPMAlignTool.RunParams.ZoneScaleY.Configuration = CogPMAlignZoneConstants.LowHigh;

            }
        }
        public double ZoneScaleY_Low
        {
            get { return m_dZoneScaleY_Low; }
            set 
            { 
                m_dZoneScaleY_Low = (double)value;

                // 2017.01.16
                if (ZoneScaleY_High == 1 && ZoneScaleY_Low == 1)
                    m_cogPMAlignTool.RunParams.ZoneScaleY.Configuration = CogPMAlignZoneConstants.Nominal;
                else
                    m_cogPMAlignTool.RunParams.ZoneScaleY.Configuration = CogPMAlignZoneConstants.LowHigh;

            }
        }
        // --------------------------------------

        public bool UsingClutter
        {
            get { return m_IsUsingClutter; }
            set { m_IsUsingClutter = (bool)value; }
        }

        public bool IgnorePolarity
        {
            get { return m_IsIgnorePolarity; }
            set { m_IsIgnorePolarity = (bool)value; }
        }

        public int FoundCount
        {
            get { return m_nFoundCount; }
        }

        public double Score
        {
            get { return m_dScore; }
        }

        public bool Result
        {
            get { return m_bResult; }
        }

        public double X
        {
            get { return m_dTranslationX; }
        }

        public double Y
        {
            get { return m_dTranslationY; }
        }

        public double Angle
        {
            get { return m_dAngle; }
            // 2014.04.09
            set { m_dAngle = (double)value; }
        }

        public double Scale
        {
            get { return m_dScale; }
        }

        // 2017.03.21
        public double ScaleX
        {
            get { return m_dScaleX; }
        }
        public double ScaleY
        {
            get { return m_dScaleY; }
        }


        public string Name
        {
            get { return m_cogPMAlignTool.Name; }
            set { m_cogPMAlignTool.Name = (string)value; }
        }

        public CogImage8Grey MaskImage
        {
            get { return m_icogImgMask; }
            set { m_icogImgMask = value; }  // 2016.01.26 by kdi
        }

        public AVisionProBuild._emRegionShape SearchShape
        {
            get
            {
                if (m_cogPMAlignTool.SearchRegion is CogCircle)
                {
                    return AVisionProBuild._emRegionShape.Circle;
                }
                else if (m_cogPMAlignTool.SearchRegion is CogEllipse)
                {
                    return AVisionProBuild._emRegionShape.Ellipse;
                }
                else if (m_cogPMAlignTool.SearchRegion is CogRectangle)
                {
                    return AVisionProBuild._emRegionShape.Rectangle;
                }
                else if (m_cogPMAlignTool.SearchRegion is CogRectangleAffine)
                {
                    return AVisionProBuild._emRegionShape.RectangleAffine;
                }
                else if (m_cogPMAlignTool.SearchRegion is CogCircularAnnulusSection)
                {
                    return AVisionProBuild._emRegionShape.CircularAnnulusSection;
                }
                else if (m_cogPMAlignTool.SearchRegion is CogEllipticalAnnulusSection)
                {
                    return AVisionProBuild._emRegionShape.EllipticalAnnulusSection;
                }
                else
                {
                    return AVisionProBuild._emRegionShape.Entire;
                }
            }
        }

        public AVisionProBuild._emRegionShape PatternShape
        {
            get
            {
                if (m_cogPMAlignTool.Pattern.TrainRegion is CogCircle)
                {
                    return AVisionProBuild._emRegionShape.Circle;
                }
                else if (m_cogPMAlignTool.Pattern.TrainRegion is CogEllipse)
                {
                    return AVisionProBuild._emRegionShape.Ellipse;
                }
                else if (m_cogPMAlignTool.Pattern.TrainRegion is CogRectangle)
                {
                    return AVisionProBuild._emRegionShape.Rectangle;
                }
                else if (m_cogPMAlignTool.Pattern.TrainRegion is CogRectangleAffine)
                {
                    return AVisionProBuild._emRegionShape.RectangleAffine;
                }
                else if (m_cogPMAlignTool.Pattern.TrainRegion is CogCircularAnnulusSection)
                {
                    return AVisionProBuild._emRegionShape.CircularAnnulusSection;
                }
                else if (m_cogPMAlignTool.Pattern.TrainRegion is CogEllipticalAnnulusSection)
                {
                    return AVisionProBuild._emRegionShape.EllipticalAnnulusSection;
                }
                else
                {
                    return AVisionProBuild._emRegionShape.Entire;
                }
            }
        }

        // 2014.07.28
        public CogPMAlignTrainModeConstants TrainMode
        {
            get { return m_cogPMAlignTool.Pattern.TrainMode; }
            set { m_cogPMAlignTool.Pattern.TrainMode = (CogPMAlignTrainModeConstants)value; }
        }

        // 2014.07.28
        public ICogShapeModelCollection TrainShapeModels
        {
            get { return m_cogPMAlignTool.Pattern.TrainShapeModels; }
            set { m_cogPMAlignTool.Pattern.TrainShapeModels = value as ICogShapeModelCollection; }
        }

        // 2014.07.28
        public CogRegionModeConstants TrainRegionMode
        {
            get { return m_cogPMAlignTool.Pattern.TrainRegionMode; }
            set { m_cogPMAlignTool.Pattern.TrainRegionMode = (CogRegionModeConstants)value; }
        }
        
        // 2014.07.30
        public CogPMAlignLastRunRecordDiagConstants LastRunRecordDiagEnable
        {
            get { return m_cogPMAlignTool.LastRunRecordDiagEnable; }
            set { m_cogPMAlignTool.LastRunRecordDiagEnable = (CogPMAlignLastRunRecordDiagConstants)value; }
        }

        // 2015.04.22
        public double TimeOut
        {
            get { return m_cogPMAlignTool.RunParams.Timeout; }
            set { m_cogPMAlignTool.RunParams.Timeout = value; }
        }

        // 2015.04.22
        public bool TimeoutEnabled
        {
            get { return m_cogPMAlignTool.RunParams.TimeoutEnabled; }
            set { m_cogPMAlignTool.RunParams.TimeoutEnabled = value; }
        }
    }
}
