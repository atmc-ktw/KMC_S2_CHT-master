using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cognex.VisionPro;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.Display;
using System.Collections;
using System.Windows.Forms;

namespace AVisionPro
{
    public class AHistogram : ACogToolBase
    {
        private CogHistogramTool m_cogHistogramTool = null;
        // 2014.09.03
        public ICogRegion m_icogRegion = null;
        private CogImage8Grey m_icogImgMask = null;

        private int m_nNumBins = 0;
        private int m_nWGVThreshold = 0;
        private int m_nMinValue = 0;
        private int m_nMaxValue = 0;
        private int m_nMode = 0;
        private double m_dMean = 0;
        private int m_nMedian = 0;
        private int m_nSampleCount = 0;
        // 2014.06.12
        private double m_dStandardDeviation = 0;

        private bool m_isRun = false;

        //** 2016.01.26 by kdi
        public ICogRegion TrainedRegion
        {
            get { return m_icogRegion; }
            set 
            { 
                m_icogRegion = value;
                // 2016.03.18
                m_cogHistogramTool.Region = value;
            }
        }
        //*/

        public struct _stResult
        {
            public double dMean;
            public int nMedian;
            // 2014.06.12
            public double dStandardDeviation;
        }
        public _stResult m_stResult;

        // 2014.09.02
        public double m_dMoveSearchRegionX = 0;
        public double m_dMoveSearchRegionY = 0;
        public double m_dInitSearchRegionX = 0;
        public double m_dInitSearchRegionY = 0;

        public AHistogram()
        {
            m_cogHistogramTool = new CogHistogramTool();
            Init();
        }

        public AHistogram(Object objTool)
        {
            m_cogHistogramTool = objTool as CogHistogramTool;
            Init();
        }

        private void Init()
        {
            m_icogImgMask = m_cogHistogramTool.RunParams.InputImageMask;
            m_icogRegion = m_cogHistogramTool.Region;
            m_nNumBins = m_cogHistogramTool.RunParams.NumBins;

            // 2014.09.02
            SetInitSearchRegion();

            // 2015.04.08            
            m_cogHistogramTool.Ran += new EventHandler(RanEvent);
        }

        private void SetHistParam()
        {
            if (m_cogHistogramTool != null)
            {
                m_cogHistogramTool.RunParams.NumBins = m_nNumBins;
                m_cogHistogramTool.Region = m_icogRegion;
            }
        }

        public bool GrabRegion(ADisplay display, AVisionProBuild._emRegionShape emRegionShape)
        {
            display.ClearOverlay();

            ICogGraphicInteractive icogGraphInteractive = null;
            ICogRegion region = m_cogHistogramTool.Region;

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
                        m_icogRegion = null;
                        display.ClearOverlay();
                    }
                    break;

                default:
                    m_icogRegion = null;

                    return false;
            }

            if (icogGraphInteractive != null)
            {
                icogGraphInteractive.GraphicDOFEnableBase = CogGraphicDOFConstants.All;
                icogGraphInteractive.Interactive = true;
                icogGraphInteractive.TipText = "Region of Interest";
                display.AddOverlay(icogGraphInteractive, "");
            }

            return true;
        }

        public void SetRegion(ADisplay display)
        {
            ICogGraphicInteractive icogGraphInteractive = display.GetInteractiveGraphics("Region of Interest");

            if (icogGraphInteractive != null)
            {
                icogGraphInteractive.GraphicDOFEnableBase = CogGraphicDOFConstants.None;
                icogGraphInteractive.Color = CogColorConstants.Cyan;
                icogGraphInteractive.Interactive = false;
            }

            m_icogRegion = icogGraphInteractive as ICogRegion;
        }

        public void ViewLastRegion(ADisplay display)
        {
            ICogRegion region = m_cogHistogramTool.Region;
            ICogGraphicInteractive icogGraphInteractive = region as ICogGraphicInteractive;

            if (icogGraphInteractive != null)
            {
                icogGraphInteractive.GraphicDOFEnableBase = CogGraphicDOFConstants.All;
                icogGraphInteractive.Interactive = true;
                // 2016.09.19 by kdi
                icogGraphInteractive.TipText = "Region of Interest";

                display.AddOverlay(icogGraphInteractive, "");
            }
        }

        public void ShowRegion(ADisplay display)
        {

            ICogRegion region = m_cogHistogramTool.Region;
            ICogGraphicInteractive icogGraphInteractive = region as ICogGraphicInteractive;

            if (icogGraphInteractive != null)
            {
                icogGraphInteractive.GraphicDOFEnableBase = CogGraphicDOFConstants.None;
                icogGraphInteractive.Interactive = false;
                icogGraphInteractive.Color = CogColorConstants.DarkGreen;
                display.AddOverlay(icogGraphInteractive, "");
            }
        }
        // 2013.02.05
        public void GetRun()
        {
            SetHistParam();

            if (m_cogHistogramTool != null)
            {
                try
                {
                    if (m_cogHistogramTool.Result != null)
                    {
                        m_nWGVThreshold = m_cogHistogramTool.Result.GetMinimumWGVThreshold();
                        m_nMinValue = m_cogHistogramTool.Result.Minimum;
                        m_nMaxValue = m_cogHistogramTool.Result.Maximum;
                        m_dMean = m_cogHistogramTool.Result.Mean;
                        m_nMode = m_cogHistogramTool.Result.Mode;
                        m_nMedian = m_cogHistogramTool.Result.Median;
                        m_nSampleCount = m_cogHistogramTool.Result.NumSamples;
                        // 2014.06.12
                        m_dStandardDeviation = m_cogHistogramTool.Result.StandardDeviation;

                        m_isRun = true;
                    }
                }
                catch
                {
                    m_isRun = false;
                }
            }
        }

        public void Run(ADisplay display)
        {
            SetHistParam();

            if (m_cogHistogramTool != null)
            {
                m_cogHistogramTool.InputImage = display.GetImage8Grey();
                if (m_icogImgMask != null)
                {
                    m_cogHistogramTool.RunParams.InputImageMask = m_icogImgMask;
                }

                try
                {
                    // 2015.04.08
                    m_bRan = false;

                    m_cogHistogramTool.Run();

                    // 2015.04.08
                    WaitRanEvent();

                    if (m_cogHistogramTool.Result != null)
                    {
                        m_nWGVThreshold = m_cogHistogramTool.Result.GetMinimumWGVThreshold();
                        m_nMinValue = m_cogHistogramTool.Result.Minimum;
                        m_nMaxValue = m_cogHistogramTool.Result.Maximum;
                        m_dMean = m_cogHistogramTool.Result.Mean;
                        m_nMode = m_cogHistogramTool.Result.Mode;
                        m_nMedian = m_cogHistogramTool.Result.Median;
                        m_nSampleCount = m_cogHistogramTool.Result.NumSamples;
                        // 2014.06.12
                        m_dStandardDeviation = m_cogHistogramTool.Result.StandardDeviation;

                        m_isRun = true;
                    }
                }
                catch
                {
                    MessageBox.Show("Run Histogram Error");
                    m_isRun = false;
                }
            }            
        }

        public void ViewResult(ADisplay displayInput, ADisplay displayOutput, bool isShowMedian, bool isShowMean, bool isShowRegion)
        {
            int nOption = 0;
            if (isShowMean )
            {
                nOption = nOption + 64;
            }
            if (isShowMedian)
            {
                nOption = nOption + 128;
            }

            // 2015.02.09
            if (isShowRegion)
            {
                ShowRegion(displayInput);
            }

            if (m_isRun)
            {
                CogHistogramResult histResult = new CogHistogramResult();                
                histResult = m_cogHistogramTool.Result;
                
                if (histResult != null)
                {
                    // 2015.02.09
                    /*
                    if (isShowRegion)
                    {
                        ShowRegion(displayInput);
                    }
                    */

                    CogCompositeShape compositeShape = new CogCompositeShape();                    
                    compositeShape = histResult.CreateResultGraphics((CogHistogramResultGraphicConstants)(1 + 2 + 16 + nOption));

                    if (displayOutput != null)
                    {
                        displayOutput.ClearAll();
                        displayOutput.AddOverlay((ICogGraphicInteractive)compositeShape, "");
                        displayOutput.Display.Fit(true);
                    }
                }
            }
        }

        public void ViewResult(ADisplay displayInput, bool isShowRegion)
        {
            // 2015.02.09
            if (isShowRegion)
            {
                ShowRegion(displayInput);
            }

            if (m_isRun)
            {
                CogHistogramResult histResult = new CogHistogramResult();
                histResult = m_cogHistogramTool.Result;

                if (histResult != null)
                {
                    // 2015.02.09
                    /*
                    if (isShowRegion)
                    {
                        ShowRegion(displayInput);
                    }
                    */
                }
            }
        }

        public ICogImage InputImage
        {
            get { return m_cogHistogramTool.InputImage; }
            set { m_cogHistogramTool.InputImage = value; }
        }

        public CogHistogramTool GetTool()
        {
            return m_cogHistogramTool;
        }

        public int NumBins
        {
            get { return m_nNumBins; }
            set
            {
                m_nNumBins = (int)value;
            }
        }

        public string Name
        {
            get { return m_cogHistogramTool.Name; }
            set
            {
                m_cogHistogramTool.Name = (string)value;
            }
        }

        public int WGVThreshold
        {
            get { return m_nWGVThreshold; }
        }

        public int Minimum
        {
            get { return m_nMinValue; }
        }

        public int Maximum
        {
            get { return m_nMaxValue; }
        }

        public int Mode
        {
            get { return m_nMode; }
        }

        public int Median
        {
            get { return m_nMedian; }
        }

        public double Mean
        {
            get { return m_dMean; }
        }

        // 2014.06.12
        public double StandardDeviation
        {
            get { return m_dStandardDeviation; }
        }

        public int SampleCount
        {
            get { return m_nSampleCount; }
        }

        public CogImage8Grey MaskImage
        {
            get { return m_icogImgMask; }
            set 
            { 
                m_icogImgMask = value;
            }
        }

        public AVisionProBuild._emRegionShape Shape
        {
            get
            {
                if (m_cogHistogramTool.Region is CogCircle)
                {
                    return AVisionProBuild._emRegionShape.Circle;
                }
                else if (m_cogHistogramTool.Region is CogEllipse)
                {
                    return AVisionProBuild._emRegionShape.Ellipse;
                }
                else if (m_cogHistogramTool.Region is CogRectangle)
                {
                    return AVisionProBuild._emRegionShape.Rectangle;
                }
                else if (m_cogHistogramTool.Region is CogRectangleAffine)
                {
                    return AVisionProBuild._emRegionShape.RectangleAffine;
                }
                else if (m_cogHistogramTool.Region is CogCircularAnnulusSection)
                {
                    return AVisionProBuild._emRegionShape.CircularAnnulusSection;
                }
                else if (m_cogHistogramTool.Region is CogEllipticalAnnulusSection)
                {
                    return AVisionProBuild._emRegionShape.EllipticalAnnulusSection;
                }
                else
                {
                    return AVisionProBuild._emRegionShape.Entire;
                }
            }
        }

        public void RunHistogram(ADisplay aDisplay)
        {
            RunHistogram(aDisplay, true, true, 0, 0);
        }
        public void RunHistogram(ADisplay aDisplay, bool bViewTxt)
        {
            RunHistogram(aDisplay, bViewTxt,  true, 0, 0);
        }
        public void RunHistogram(ADisplay aDisplayInput, bool bViewTxt, bool bShowRegion, double dX, double dY)
        {
            Run(aDisplayInput);
            ViewResult(aDisplayInput, bShowRegion);

            m_stResult.dMean = Mean;
            m_stResult.nMedian = Median;
            // 2014.06.12
            m_stResult.dStandardDeviation = StandardDeviation; 

            if (bViewTxt)
                aDisplayInput.AddTxt(dX, dY, "Histogram:" + m_stResult.nMedian.ToString(), CogColorConstants.Green);
        }

        // 2014.09.02
        public void RunHistogram(ADisplay aDisplayInput, bool bViewTxt, bool bShowRegion, double dX, double dY,
            double dSearchRegionX, double dSearchRegionY, 
            double dMoveX, double dMoveY)
        {
            SetInitSearchRegion(dSearchRegionX, dSearchRegionY);
            MoveSearchRegion(dMoveX, dMoveY);

            Run(aDisplayInput);
            ViewResult(aDisplayInput, bShowRegion);

            m_stResult.dMean = Mean;
            m_stResult.nMedian = Median;
            // 2014.06.12
            m_stResult.dStandardDeviation = StandardDeviation;

            if (bViewTxt)
                aDisplayInput.AddTxt(dX, dY, "Histogram:" + m_stResult.nMedian.ToString(), CogColorConstants.Green);
        }

        // 2014.09.02
        public void MoveSearchRegion(double x, double y)
        {
            m_dMoveSearchRegionX = x;
            m_dMoveSearchRegionY = y;

            ICogRegion region = m_icogRegion;

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

        // 2014.09.02
        public void SetInitSearchRegion(double dX, double dY)
        {
            m_dInitSearchRegionX = dX;
            m_dInitSearchRegionY = dY;

            ICogRegion region = m_icogRegion;

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

        // 2014.09.02
        public void SetInitSearchRegion()
        {
            ICogRegion region = m_icogRegion;

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
    }
}
