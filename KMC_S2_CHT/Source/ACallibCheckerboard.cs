using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cognex.VisionPro;
using Cognex.VisionPro.CalibFix;
using System.Windows.Forms;

namespace AVisionPro
{
    public class ACalibCheckerboard : ACogToolBase
    {
        private CogCalibCheckerboardTool m_cogCalibCheckerboardTool = null;
        public CogCoordinateAxes m_cogCoordinateAxes = new CogCoordinateAxes();
        private CogCalibFixComputationModeConstants m_emComputationMode;
        private CogCalibCheckerboardFiducialConstants m_emFiducial;
        private ICogImage m_icogImageCalibration = null;

        public delegate void SendMes(Object sender, EventArgs e);
        public event SendMes CoordinateAxes_DraggingStopped;

        private double m_dSizeX = 0; //size x
        private double m_dSizeY = 0; //mm
        
        private double m_dOriginX;
        private double m_dCaibratedOriginX;
        private double m_dOriginY;
        private double m_dCaibratedOriginY;
        private double m_dRotation = 0; //radian
        private double m_dCaibratedRotation = 0; //radian
        private bool m_bSwapY = false;
        
        private bool m_bGrabed = false;
        private bool m_bCalibrated = false;
        private readonly double m_dPI = Math.PI;

        public ACalibCheckerboard()
        {
            m_cogCalibCheckerboardTool = new CogCalibCheckerboardTool();
            Init();
            // 2012.01.17
            //m_cogCalibCheckerboardTool.Calibration.ComputationMode = CogCalibFixComputationModeConstants.Linear;
            m_cogCalibCheckerboardTool.Calibration.ComputationMode = CogCalibFixComputationModeConstants.PerspectiveAndRadialWarp;
            m_emComputationMode = m_cogCalibCheckerboardTool.Calibration.ComputationMode;

            m_cogCalibCheckerboardTool.Calibration.FiducialMark = CogCalibCheckerboardFiducialConstants.None;
        }

        public ACalibCheckerboard(Object objTool)
        {
            m_cogCalibCheckerboardTool = objTool as CogCalibCheckerboardTool;
            Init();
        }

        private void Init()
        {
            m_dSizeX = m_cogCalibCheckerboardTool.Calibration.PhysicalTileSizeX;
            m_dSizeY = m_cogCalibCheckerboardTool.Calibration.PhysicalTileSizeY;
            m_emComputationMode = m_cogCalibCheckerboardTool.Calibration.ComputationMode;
            m_emFiducial = m_cogCalibCheckerboardTool.Calibration.FiducialMark;
            m_bSwapY = m_cogCalibCheckerboardTool.Calibration.SwapCalibratedHandedness;
            m_bCalibrated = m_cogCalibCheckerboardTool.Calibration.Calibrated;
            m_icogImageCalibration = m_cogCalibCheckerboardTool.Calibration.CalibrationImage;
            m_dCaibratedOriginX = m_cogCalibCheckerboardTool.Calibration.CalibratedOriginX;
            m_dCaibratedOriginY = m_cogCalibCheckerboardTool.Calibration.CalibratedOriginY;
            m_dCaibratedRotation = m_cogCalibCheckerboardTool.Calibration.CalibratedXAxisRotation;
            m_dOriginX = m_dCaibratedOriginX;
            m_dOriginY = m_dCaibratedOriginY;
            m_dRotation = m_dCaibratedRotation;

            m_cogCoordinateAxes.DraggingStopped += new CogDraggingStoppedEventHandler(MyCoordinateAxes_DraggingStopped);

            // 2015.04.08            
            m_cogCalibCheckerboardTool.Ran += new EventHandler(RanEvent);
        }

        private void SetCalibCheckerboardParam()
        {
            m_bCalibrated = false;

            if (m_cogCalibCheckerboardTool != null)
            {
                m_cogCalibCheckerboardTool.Calibration.PhysicalTileSizeX = m_dSizeX;
                m_cogCalibCheckerboardTool.Calibration.PhysicalTileSizeY = m_dSizeY;
                m_cogCalibCheckerboardTool.Calibration.ComputationMode = m_emComputationMode;
                m_cogCalibCheckerboardTool.Calibration.FeatureFinder = CogCalibCheckerboardFeatureFinderConstants.CheckerboardExhaustive;
                m_cogCalibCheckerboardTool.Calibration.CalibratedOriginSpace = CogCalibCheckerboardAdjustmentSpaceConstants.RawCalibrated;
                m_cogCalibCheckerboardTool.Calibration.FiducialMark = m_emFiducial;
                m_cogCalibCheckerboardTool.Calibration.SwapCalibratedHandedness = m_bSwapY;
                m_cogCalibCheckerboardTool.Calibration.CalibratedOriginX = m_dOriginX;
                m_cogCalibCheckerboardTool.Calibration.CalibratedOriginY = m_dOriginY;
                m_cogCalibCheckerboardTool.Calibration.CalibratedXAxisRotation = m_dRotation;
            }
        }
        
        public ICogImage GrabCalibrationImage(ADisplay aDisplay)
        {
            if (aDisplay.Image != null)
            {
                m_cogCalibCheckerboardTool.Calibration.CalibrationImage = aDisplay.Image;
                m_icogImageCalibration = aDisplay.Image;
                m_bGrabed = true;
            }
            else
            {
                m_bGrabed = false;
            }

            return m_icogImageCalibration;
        }

        public void Uncalibrate()
        {
            m_bCalibrated = false;
            m_cogCalibCheckerboardTool.Calibration.Uncalibrate();
        }

        public bool Calibrate(ADisplay aDisplay, bool isShowDistorted)
        {
            if (m_bGrabed == true)
            {
                try
                {
                    SetCalibCheckerboardParam();

                    m_cogCalibCheckerboardTool.Calibration.Calibrate();
                    m_bCalibrated = m_cogCalibCheckerboardTool.Calibration.Calibrated;
                    m_dCaibratedOriginX = m_cogCalibCheckerboardTool.Calibration.CalibratedOriginX;
                    m_dCaibratedOriginY = m_cogCalibCheckerboardTool.Calibration.CalibratedOriginY;
                    m_dCaibratedRotation = m_cogCalibCheckerboardTool.Calibration.CalibratedXAxisRotation;

                    if (m_bCalibrated)
                    {
                        ShowCalibratedPoints(aDisplay, isShowDistorted, false);
                    }
                }
                catch
                {
                    MessageBox.Show("Calibration Error!");
                    m_bCalibrated = false;
                    return false;
                }
            }

            return m_bCalibrated;
        }

        public void TransUncalibrated2CalibratedCoord(double uncalibratedX, double uncalibratedY, out double calibratedX, out double calibratedY) // 영상 pixel값은 calibrated값으로 변환한다
        {
            calibratedX = 0;
            calibratedY = 0;

            ICogTransform2D transform2D = m_cogCalibCheckerboardTool.Calibration.GetComputedUncalibratedFromRawCalibratedTransform();
            ICogTransform2D transform2DInvert = transform2D.InvertBase();

            if (transform2DInvert != null)
            {
                transform2DInvert.MapPoint(uncalibratedX, uncalibratedY, out calibratedX, out calibratedY);
            }
        }

        public void TransCalibrated2UncalibratedCoord(double calibratedX, double calibratedY, out double uncalibratedX, out double uncalibratedY) // 영상 calibrated값은 pixel값으로 변환한다
        {
            uncalibratedX = 0;
            uncalibratedY = 0;

            ICogTransform2D transform2D = m_cogCalibCheckerboardTool.Calibration.GetComputedUncalibratedFromRawCalibratedTransform();

            if (transform2D != null)
            {
                transform2D.MapPoint(calibratedX, calibratedY, out uncalibratedX, out uncalibratedY);
            }
        }

        public void ShowCalibratedOrigin(ADisplay aDisplay, bool isShowDistorted, bool isSwapHandedness)
        {
            double dOriginX, dOriginY, dMappedX, dMappedY;
            ICogTransform2D transform2D;
            CogTransform2DLinear transform2DLinear = null;

            try
            {
                if (m_bCalibrated == true)
                {
                    if (m_emComputationMode == CogCalibFixComputationModeConstants.Linear)
                    {
                        TransCalibrated2UncalibratedCoord(m_dOriginX, m_dOriginY, out dOriginX, out dOriginY);

                        m_cogCoordinateAxes.OriginX = dOriginX;
                        m_cogCoordinateAxes.OriginY = dOriginY;

                        transform2D = m_cogCalibCheckerboardTool.Calibration.GetComputedUncalibratedFromCalibratedTransform();
                        transform2DLinear = transform2D.LinearTransform(m_dOriginX, m_dOriginY);

                        m_cogCoordinateAxes.Rotation = transform2DLinear.MapAngle(m_dRotation - m_dCaibratedRotation);
                        m_cogCoordinateAxes.Skew = transform2DLinear.MapAngle(m_dRotation - m_dCaibratedRotation + m_dPI / 2) - (m_cogCoordinateAxes.Rotation + m_dPI / 2);
                    }
                    else if (m_emComputationMode == CogCalibFixComputationModeConstants.PerspectiveAndRadialWarp)
                    {
                        if (isShowDistorted == true)
                        {
                            transform2D = m_cogCalibCheckerboardTool.Calibration.OwnedWarpParams.GetOutputImageRootFromCalibratedTransform();
                            transform2D.MapPoint(m_dOriginX - m_dCaibratedOriginX, m_dOriginY - m_dCaibratedOriginY, out dMappedX, out dMappedY);

                            m_cogCoordinateAxes.OriginX = dMappedX;
                            m_cogCoordinateAxes.OriginY = dMappedY;

                            transform2DLinear = transform2D.LinearTransform(dMappedX, dMappedY);
                            m_cogCoordinateAxes.Rotation = transform2DLinear.MapAngle(m_dRotation - m_dCaibratedRotation);
                            m_cogCoordinateAxes.Skew = transform2DLinear.Skew;
                        }
                        else
                        {
                            TransCalibrated2UncalibratedCoord(m_dOriginX, m_dOriginY, out dOriginX, out dOriginY);

                            m_cogCoordinateAxes.OriginX = dOriginX;
                            m_cogCoordinateAxes.OriginY = dOriginY;

                            transform2D = m_cogCalibCheckerboardTool.Calibration.GetComputedUncalibratedFromCalibratedTransform();
                            transform2DLinear = transform2D.LinearTransform(m_dOriginX, m_dOriginY);

                            m_cogCoordinateAxes.Rotation = transform2DLinear.MapAngle(m_dRotation - m_dCaibratedRotation);
                            m_cogCoordinateAxes.Skew = transform2DLinear.MapAngle(m_dRotation - m_dCaibratedRotation + m_dPI / 2) - (m_cogCoordinateAxes.Rotation + m_dPI / 2);
                        }
                    }
                }
                else
                {
                    if (m_emComputationMode == CogCalibFixComputationModeConstants.Linear)
                    {
                        TransCalibrated2UncalibratedCoord(m_dOriginX, m_dOriginY, out dOriginX, out dOriginY);

                        m_cogCoordinateAxes.OriginX = dOriginX;
                        m_cogCoordinateAxes.OriginY = dOriginY;

                        transform2D = m_cogCalibCheckerboardTool.Calibration.GetComputedUncalibratedFromCalibratedTransform();
                        transform2DLinear = transform2D.LinearTransform(m_dOriginX, m_dOriginY);

                        m_cogCoordinateAxes.Rotation = transform2DLinear.MapAngle(m_dRotation - m_dCaibratedRotation);
                        if (isSwapHandedness == false)
                        {
                            m_cogCoordinateAxes.Skew = transform2DLinear.MapAngle(m_dRotation - m_dCaibratedRotation + m_dPI / 2) - (m_cogCoordinateAxes.Rotation + m_dPI / 2);
                        }
                        else
                        {
                            m_cogCoordinateAxes.Skew = transform2DLinear.MapAngle(m_dRotation - m_dCaibratedRotation + m_dPI / 2 + m_dPI) - (m_cogCoordinateAxes.Rotation + m_dPI / 2);
                        }
                    }
                    else if (m_emComputationMode == CogCalibFixComputationModeConstants.PerspectiveAndRadialWarp)
                    {
                        if (isShowDistorted == true)
                        {
                            transform2D = m_cogCalibCheckerboardTool.Calibration.OwnedWarpParams.GetOutputImageRootFromCalibratedTransform();
                            transform2D.MapPoint(m_dOriginX - m_dCaibratedOriginX, m_dOriginY - m_dCaibratedOriginY, out dMappedX, out dMappedY);

                            m_cogCoordinateAxes.OriginX = dMappedX;
                            m_cogCoordinateAxes.OriginY = dMappedY;

                            transform2DLinear = transform2D.LinearTransform(dMappedX, dMappedY);
                            m_cogCoordinateAxes.Rotation = transform2DLinear.MapAngle(m_dRotation - m_dCaibratedRotation);
                            if (isSwapHandedness == false)
                            {
                                m_cogCoordinateAxes.Skew = transform2DLinear.Skew;
                            }
                            else
                            {
                                m_cogCoordinateAxes.Skew = transform2DLinear.Skew + m_dPI;
                            }
                        }
                        else
                        {
                            TransCalibrated2UncalibratedCoord(m_dOriginX, m_dOriginY, out dOriginX, out dOriginY);

                            m_cogCoordinateAxes.OriginX = dOriginX;
                            m_cogCoordinateAxes.OriginY = dOriginY;

                            transform2D = m_cogCalibCheckerboardTool.Calibration.GetComputedUncalibratedFromCalibratedTransform();
                            transform2DLinear = transform2D.LinearTransform(m_dOriginX, m_dOriginY);

                            m_cogCoordinateAxes.Rotation = transform2DLinear.MapAngle(m_dRotation - m_dCaibratedRotation);
                            if (isSwapHandedness == false)
                            {
                                m_cogCoordinateAxes.Skew = transform2DLinear.MapAngle(m_dRotation - m_dCaibratedRotation + m_dPI / 2) - (m_cogCoordinateAxes.Rotation + m_dPI / 2);
                            }
                            else
                            {
                                m_cogCoordinateAxes.Skew = transform2DLinear.MapAngle(m_dRotation - m_dCaibratedRotation + m_dPI / 2 + m_dPI) - (m_cogCoordinateAxes.Rotation + m_dPI / 2);
                            }
                        }
                    }
                }

                m_cogCoordinateAxes.GraphicDOFEnable = (CogCoordinateAxesDOFConstants)(-2147483644);//Position+Rotation
                m_cogCoordinateAxes.Interactive = true;
                m_cogCoordinateAxes.Color = CogColorConstants.Cyan;
                m_cogCoordinateAxes.XAxisLabel.Color = CogColorConstants.Cyan;
                m_cogCoordinateAxes.YAxisLabel.Color = CogColorConstants.Cyan;
                m_cogCoordinateAxes.TipText = "Calibrated Origin";
                aDisplay.AddOverlay(m_cogCoordinateAxes as ICogGraphicInteractive, "");
            }
            catch { }
        }

        public void ShowCalibratedPoints(ADisplay aDisplay, bool isShowDistorted, bool isSwapHandedness)
        {
            try
            {
                int pointCount = m_cogCalibCheckerboardTool.Calibration.NumPoints;

                if (isShowDistorted == true)
                {
                    double x, y, mappedX, mappedY;
                    aDisplay.ClearAll();
                    aDisplay.Display.Image = m_cogCalibCheckerboardTool.Calibration.OwnedWarpParams.UndistortedCalibrationImage;
                    aDisplay.Display.Fit(true);
                    ICogGraphic mask = m_cogCalibCheckerboardTool.Calibration.OwnedWarpParams.OutputImageMask as ICogGraphic;
                    if (mask != null)
                    {
                        aDisplay.AddStaticGraphic(mask, "");
                    }

                    for (int i = 0; i < pointCount; i++)
                    {
                        CogPointMarker cogPointMaker = new CogPointMarker();
                        x = m_cogCalibCheckerboardTool.Calibration.GetUncalibratedPointX(i);
                        y = m_cogCalibCheckerboardTool.Calibration.GetUncalibratedPointY(i);

                        ICogTransform2D transform2D = m_cogCalibCheckerboardTool.Calibration.OwnedWarpParams.GetInputPixelFromOutputPixelTransform(aDisplay.Image);
                        transform2D.InvertBase().MapPoint(x, y, out mappedX, out mappedY);

                        cogPointMaker.GraphicType = CogPointMarkerGraphicTypeConstants.Crosshair;
                        cogPointMaker.Color = CogColorConstants.Magenta;
                        cogPointMaker.X = mappedX;
                        cogPointMaker.Y = mappedY;
                        cogPointMaker.GraphicDOFEnable = CogPointMarkerDOFConstants.None;
                        cogPointMaker.Interactive = true;
                        cogPointMaker.TipText = "Uncalibrated Point " + i.ToString();

                        aDisplay.AddOverlay(cogPointMaker as ICogGraphicInteractive, "");
                    }
                }
                else
                {
                    aDisplay.ClearAll();
                    aDisplay.Display.Image = m_cogCalibCheckerboardTool.Calibration.CalibrationImage;
                    aDisplay.Display.Fit(true);

                    for (int i = 0; i < pointCount; i++)
                    {
                        CogPointMarker cogPointMaker = new CogPointMarker();

                        cogPointMaker.GraphicType = CogPointMarkerGraphicTypeConstants.Crosshair;
                        cogPointMaker.Color = CogColorConstants.Magenta;
                        cogPointMaker.X = m_cogCalibCheckerboardTool.Calibration.GetUncalibratedPointX(i);
                        cogPointMaker.Y = m_cogCalibCheckerboardTool.Calibration.GetUncalibratedPointY(i);
                        cogPointMaker.GraphicDOFEnable = CogPointMarkerDOFConstants.None;
                        cogPointMaker.Interactive = true;
                        cogPointMaker.TipText = "Uncalibrated Point " + i.ToString();

                        aDisplay.AddOverlay(cogPointMaker as ICogGraphicInteractive, "");
                    }
                }

                ShowCalibratedOrigin(aDisplay, isShowDistorted, isSwapHandedness);
            }
            catch { }
        }
                
        public void GetResultToList(ListView list)
        {
            list.Items.Clear();
            ListViewItem lstvwItem = new ListViewItem();

            if (m_bCalibrated)
            {
                for (int i = 0; i < m_cogCalibCheckerboardTool.Calibration.NumPoints; i++)
                {
                    lstvwItem = list.Items.Add((i).ToString());
                    lstvwItem.SubItems.Add(m_cogCalibCheckerboardTool.Calibration.GetUncalibratedPointX(i).ToString());
                    lstvwItem.SubItems.Add(m_cogCalibCheckerboardTool.Calibration.GetUncalibratedPointY(i).ToString());
                    lstvwItem.SubItems.Add(m_cogCalibCheckerboardTool.Calibration.GetRawCalibratedPointX(i).ToString());
                    lstvwItem.SubItems.Add(m_cogCalibCheckerboardTool.Calibration.GetRawCalibratedPointY(i).ToString());
                }
            }
        }
        /*
        public void Run(ADisplay aDisplay)
        {            
            if (m_bCalibrated == true)
            {
                aDisplay.ClearOverlay();
                double dMappedX, dMappedY;
                m_cogCalibCheckerboardTool.InputImage = aDisplay.Image;
                
                // 2015.04.08
                m_bRan = false;

                m_cogCalibCheckerboardTool.Run();

                // 2015.04.08
                WaitRanEvent();
         * 
                aDisplay.Display.Image = m_cogCalibCheckerboardTool.OutputImage;
                aDisplay.Display.Fit(true);

                if (m_emComputationMode == CogCalibFixComputationModeConstants.Linear)
                {
                    m_cogCoordinateAxes.OriginX = 0;
                    m_cogCoordinateAxes.OriginY = 0;
                    m_cogCoordinateAxes.Rotation = 0;
                    m_cogCoordinateAxes.Skew = 0;
                }
                else if (m_emComputationMode == CogCalibFixComputationModeConstants.PerspectiveAndRadialWarp)
                {
                    ICogTransform2D transform2D = m_cogCalibCheckerboardTool.Calibration.OwnedWarpParams.GetOutputImageRootFromCalibratedTransform();
                    transform2D.MapPoint(0, 0, out dMappedX, out dMappedY);

                    m_cogCoordinateAxes.OriginX = 0;
                    m_cogCoordinateAxes.OriginY = 0;

                    CogTransform2DLinear transform2DLinear = transform2D.LinearTransform(dMappedX, dMappedY);
                    m_cogCoordinateAxes.Rotation = 0;
                    m_cogCoordinateAxes.Skew = 0;
                }                

                m_cogCoordinateAxes.GraphicDOFEnable = CogCoordinateAxesDOFConstants.None;
                m_cogCoordinateAxes.Interactive = false;
                m_cogCoordinateAxes.Color = CogColorConstants.Green;
                m_cogCoordinateAxes.XAxisLabel.Color = CogColorConstants.Green;
                m_cogCoordinateAxes.YAxisLabel.Color = CogColorConstants.Green;
                m_cogCoordinateAxes.TipText = "";
                aDisplay.AddOverlay(m_cogCoordinateAxes as ICogGraphicInteractive, "");
            }
        }
        */

        private void MyCoordinateAxes_DraggingStopped(object sender, EventArgs e)
        {
            m_bCalibrated = false;
            CoordinateAxes_DraggingStopped(this, new EventArgs());
        }

        public void GetAxesParam(ADisplay aDisplay, bool isShowDistorted)
        {
            double dOriginX, dOriginY;
            ICogTransform2D transform2D;
            CogTransform2DLinear transform2DLinear = null;
            ICogGraphicInteractive axes = aDisplay.GetInteractiveGraphics("Calibrated Origin");

            if (axes != null)
            {
                CogCoordinateAxes coordinateAxes = axes as CogCoordinateAxes;                

                dOriginX = coordinateAxes.OriginX;
                dOriginY = coordinateAxes.OriginY;
                TransUncalibrated2CalibratedCoord(dOriginX, dOriginY, out m_dOriginX, out m_dOriginY);

                if (isShowDistorted == true)
                {
                    transform2D = m_cogCalibCheckerboardTool.Calibration.OwnedWarpParams.GetOutputImageRootFromCalibratedTransform();
                    transform2DLinear = transform2D.LinearTransform(dOriginX, dOriginY).Invert();
                    m_dRotation = transform2DLinear.MapAngle(m_cogCoordinateAxes.Rotation) + m_dCaibratedRotation;
                }
                else
                {
                    transform2D = m_cogCalibCheckerboardTool.Calibration.GetComputedUncalibratedFromCalibratedTransform();
                    transform2DLinear = transform2D.LinearTransform(m_dOriginX, m_dOriginY).Invert();
                    m_dRotation = transform2DLinear.MapAngle(coordinateAxes.Rotation) + m_dCaibratedRotation;
                }
            }            
        }

        public ICogImage CalibrationImage
        {
            get { return m_icogImageCalibration; } 
        }

        public ICogImage InputImage
        {
            get { return m_cogCalibCheckerboardTool.InputImage; }
            set { m_cogCalibCheckerboardTool.InputImage = value; }
        }

        public double SizeX
        {
            get { return m_dSizeX; }
            set { m_dSizeX = value; }
        }

        public double SizeY
        {
            get { return m_dSizeY; }
            set { m_dSizeY = value; }
        }

        public double OriginX
        {
            get { return m_dOriginX; }
            set { m_dOriginX = value; }
        }

        public double OriginY
        {
            get { return m_dOriginY; }
            set { m_dOriginY = value; }
        }

        public double OriginRotation
        {
            get { return m_dRotation; }
            set { m_dRotation = value; }
        }

        public CogCalibFixComputationModeConstants ComputationMode
        {
            get { return m_emComputationMode; }
            set { m_emComputationMode = value; }
        }

        public CogCalibCheckerboardFiducialConstants Fiducial
        {
            get { return m_emFiducial; }
            set { m_emFiducial = value; }
        }

        public bool SwapHandedness
        {
            get { return m_bSwapY; }
            set { m_bSwapY = value; }
        }

        public bool Calibrated
        {
            get { return m_bCalibrated; }
            set { m_bCalibrated = value; }
        }

        public string Name
        {
            get { return m_cogCalibCheckerboardTool.Name; }
            set
            {
                m_cogCalibCheckerboardTool.Name = (string)value;
            }
        }

        public CogCalibCheckerboardTool GetTool()
        {
            return m_cogCalibCheckerboardTool;
        }

    }
}
