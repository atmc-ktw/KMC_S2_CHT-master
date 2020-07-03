using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cognex.VisionPro;
using Cognex.VisionPro.CalibFix;
using System.Windows.Forms;

namespace AVisionPro
{
    public class ACalibNPointToNPoint : ACogToolBase
    {
        private CogCalibNPointToNPointTool m_cogCalibNPointToNPointTool = null;
        public CogPointMarker[] m_pcogPointMaker = new CogPointMarker[3];
        public CogCoordinateAxes m_cogCoordinateAxes = new CogCoordinateAxes();
        private ICogImage m_icogImageCalibration = null;

        public double[] m_pdRawX = new double[3];
        public double[] m_pdRawY = new double[3];

        private bool m_bGrabed = false;
        private bool m_bCalibrated = false;

        public double[] m_pdPixelX = new double[3];
        public double[] m_pdPixelY = new double[3];
        
        private double m_dOriginX;
        private double m_dCaibratedOriginX;
        private double m_dOriginY;
        private double m_dCaibratedOriginY;
        private double m_dRotation = 0; //radian
        private double m_dCaibratedRotation = 0; //radian
        private bool m_bSwapY = false;
        

        private readonly double m_dPI = Math.PI;

        public ACalibNPointToNPoint()
        {
            m_cogCalibNPointToNPointTool = new CogCalibNPointToNPointTool();
            Init();
        }

        public ACalibNPointToNPoint(Object objTool)
        {
            m_cogCalibNPointToNPointTool = objTool as CogCalibNPointToNPointTool;
            Init();
        }

        private void Init()
        {
            m_cogCalibNPointToNPointTool.Calibration.NumPoints = 3;
            for(int i=0;i<3;i++)
            {
                m_pcogPointMaker[i] = new CogPointMarker();

                m_cogCalibNPointToNPointTool.Calibration.GetRawCalibratedPoint(i, out m_pdRawX[i], out m_pdRawY[i]);
                m_cogCalibNPointToNPointTool.Calibration.GetUncalibratedPoint(i, out m_pdPixelX[i], out m_pdPixelY[i]);
            }

            m_bCalibrated = m_cogCalibNPointToNPointTool.Calibration.Calibrated;
            m_icogImageCalibration = m_cogCalibNPointToNPointTool.CalibrationImage;
            
            m_bSwapY = m_cogCalibNPointToNPointTool.Calibration.SwapCalibratedHandedness;
            m_dCaibratedOriginX = m_cogCalibNPointToNPointTool.Calibration.CalibratedOriginX;
            m_dCaibratedOriginY = m_cogCalibNPointToNPointTool.Calibration.CalibratedOriginY;
            m_dCaibratedRotation = m_cogCalibNPointToNPointTool.Calibration.CalibratedXAxisRotation;
            m_dOriginX = m_dCaibratedOriginX;
            m_dOriginY = m_dCaibratedOriginY;
            m_dRotation = m_dCaibratedRotation;

            // 2015.04.08            
            m_cogCalibNPointToNPointTool.Ran += new EventHandler(RanEvent);
        }

        private void SetCalibNPointToNPointParam()
        {
            m_bCalibrated = false;
            if (m_cogCalibNPointToNPointTool != null)
            {
                m_cogCalibNPointToNPointTool.Calibration.NumPoints = 3;
                for (int i = 0; i < 3; i++)
                {
                    m_cogCalibNPointToNPointTool.Calibration.SetRawCalibratedPoint(i, m_pdRawX[i], m_pdRawY[i]);
                    m_cogCalibNPointToNPointTool.Calibration.SetUncalibratedPoint(i, m_pdPixelX[i], m_pdPixelY[i]);
                }
                
                m_cogCalibNPointToNPointTool.Calibration.SwapCalibratedHandedness = m_bSwapY;
                m_cogCalibNPointToNPointTool.Calibration.CalibratedOriginX = m_dOriginX;
                m_cogCalibNPointToNPointTool.Calibration.CalibratedOriginY = m_dOriginY;
                m_cogCalibNPointToNPointTool.Calibration.CalibratedXAxisRotation = m_dRotation;
                
                
            }
        }
        
        public ICogImage GrabCalibrationImage(ADisplay aDisplay)
        {
            if (aDisplay.Image != null)
            {
                m_cogCalibNPointToNPointTool.CalibrationImage = aDisplay.Image;
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
            m_cogCalibNPointToNPointTool.Calibration.Uncalibrate();
        }

        public bool Calibrate(ADisplay aDisplay)
        {
            if (m_bGrabed == true)
            {
          		try
                {
	                SetCalibNPointToNPointParam();                               
	
	                m_cogCalibNPointToNPointTool.Calibration.Calibrate();
	                m_bCalibrated = m_cogCalibNPointToNPointTool.Calibration.Calibrated;
	                
	                if (m_bCalibrated)
	                {
                        ShowCalibratedPoints(aDisplay, false);
	                    ShowCalibratedOrigin(aDisplay, false);
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

            ICogTransform2D transform2D = m_cogCalibNPointToNPointTool.Calibration.GetComputedUncalibratedFromRawCalibratedTransform();
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

            ICogTransform2D transform2D = m_cogCalibNPointToNPointTool.Calibration.GetComputedUncalibratedFromRawCalibratedTransform();

            if (transform2D != null)
            {
                transform2D.MapPoint(calibratedX, calibratedY, out uncalibratedX, out uncalibratedY);
            }
        }

        public void ShowCalibratedOrigin(ADisplay aDisplay, bool isSwapHandedness)
        {
            double dOriginX, dOriginY;
            ICogTransform2D transform2D;
            CogTransform2DLinear transform2DLinear = null;

            try
            {
                if (m_bCalibrated == true)
                {
                    TransCalibrated2UncalibratedCoord(m_dOriginX, m_dOriginY, out dOriginX, out dOriginY);

                    m_cogCoordinateAxes.OriginX = dOriginX;
                    m_cogCoordinateAxes.OriginY = dOriginY;

                    transform2D = m_cogCalibNPointToNPointTool.Calibration.GetComputedUncalibratedFromCalibratedTransform();
                    transform2DLinear = transform2D.LinearTransform(m_dOriginX, m_dOriginY);

                    m_cogCoordinateAxes.Rotation = transform2DLinear.MapAngle(m_dRotation - m_dCaibratedRotation);
                    m_cogCoordinateAxes.Skew = transform2DLinear.MapAngle(m_dRotation - m_dCaibratedRotation + m_dPI / 2) - (m_cogCoordinateAxes.Rotation + m_dPI / 2);                    
                }
                else
                {
                    TransCalibrated2UncalibratedCoord(m_dOriginX, m_dOriginY, out dOriginX, out dOriginY);

                    m_cogCoordinateAxes.OriginX = dOriginX;
                    m_cogCoordinateAxes.OriginY = dOriginY;

                    transform2D = m_cogCalibNPointToNPointTool.Calibration.GetComputedUncalibratedFromCalibratedTransform();
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

                //m_cogCoordinateAxes.GraphicDOFEnable = (CogCoordinateAxesDOFConstants)(-2147483644);//Position+Rotation
                m_cogCoordinateAxes.GraphicDOFEnable = CogCoordinateAxesDOFConstants.None;
                m_cogCoordinateAxes.Interactive = true;
                m_cogCoordinateAxes.Color = CogColorConstants.Cyan;
                m_cogCoordinateAxes.XAxisLabel.Color = CogColorConstants.Cyan;
                m_cogCoordinateAxes.YAxisLabel.Color = CogColorConstants.Cyan;
                m_cogCoordinateAxes.TipText = "Calibrated Origin";
                aDisplay.AddOverlay(m_cogCoordinateAxes as ICogGraphicInteractive, "");
            }
            catch { }
        }

        public void ShowCalibratedPoints(ADisplay aDisplay, bool bMove)
        {
            try
            {
                aDisplay.ClearAll();
                aDisplay.Display.Image = m_cogCalibNPointToNPointTool.CalibrationImage;
                aDisplay.Display.Fit(true);

                for (int i = 0; i < 3; i++)
                {
                    m_pcogPointMaker[i].GraphicType = CogPointMarkerGraphicTypeConstants.Crosshair;
                    m_pcogPointMaker[i].Color = CogColorConstants.Magenta;
                    m_pcogPointMaker[i].X = m_cogCalibNPointToNPointTool.Calibration.GetUncalibratedPointX(i);
                    m_pcogPointMaker[i].Y = m_cogCalibNPointToNPointTool.Calibration.GetUncalibratedPointY(i);
                    if (bMove)
                        m_pcogPointMaker[i].GraphicDOFEnable = CogPointMarkerDOFConstants.Position;
                    else
                        m_pcogPointMaker[i].GraphicDOFEnable = CogPointMarkerDOFConstants.None;

                    m_pcogPointMaker[i].Interactive = true;
                    m_pcogPointMaker[i].TipText = "Uncalibrated Point " + i.ToString();

                    aDisplay.AddOverlay(m_pcogPointMaker[i] as ICogGraphicInteractive, "");
                }
            }
            catch { }
        }
        
        public void Run(ADisplay aDisplay)
        {     
            if (m_bCalibrated == true)
            {
                aDisplay.ClearOverlay();
                m_cogCalibNPointToNPointTool.InputImage = aDisplay.Image;
                
                // 2015.04.08
                m_bRan = false;

                m_cogCalibNPointToNPointTool.Run();

                // 2015.04.08
                WaitRanEvent();

                aDisplay.Display.Image = m_cogCalibNPointToNPointTool.OutputImage;
                aDisplay.Display.Fit(true);

                m_cogCoordinateAxes.OriginX = 0;
                m_cogCoordinateAxes.OriginY = 0;
                m_cogCoordinateAxes.Rotation = 0;
                m_cogCoordinateAxes.Skew = 0;
                
                m_cogCoordinateAxes.GraphicDOFEnable = CogCoordinateAxesDOFConstants.None;
                m_cogCoordinateAxes.Interactive = false;
                m_cogCoordinateAxes.Color = CogColorConstants.Green;
                m_cogCoordinateAxes.XAxisLabel.Color = CogColorConstants.Green;
                m_cogCoordinateAxes.YAxisLabel.Color = CogColorConstants.Green;
                m_cogCoordinateAxes.TipText = "";
                aDisplay.AddOverlay(m_cogCoordinateAxes as ICogGraphicInteractive, "");
            }
        }
        /*
        public void GetPointParam(ADisplay aDisplay)
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
                    transform2D = m_cogCalibNPointToNPointTool.Calibration.OwnedWarpParams.GetOutputImageRootFromCalibratedTransform();
                    transform2DLinear = transform2D.LinearTransform(dOriginX, dOriginY).Invert();
                    m_dRotation = transform2DLinear.MapAngle(m_cogCoordinateAxes.Rotation) + m_dCaibratedRotation;
                }
                else
                {
                    transform2D = m_cogCalibNPointToNPointTool.Calibration.GetComputedUncalibratedFromCalibratedTransform();
                    transform2DLinear = transform2D.LinearTransform(m_dOriginX, m_dOriginY).Invert();
                    m_dRotation = transform2DLinear.MapAngle(coordinateAxes.Rotation) + m_dCaibratedRotation;
                }
            } 
        }
        */

        public void GetAxesParam(ADisplay aDisplay)
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

                transform2D = m_cogCalibNPointToNPointTool.Calibration.GetComputedUncalibratedFromCalibratedTransform();
                transform2DLinear = transform2D.LinearTransform(m_dOriginX, m_dOriginY).Invert();
                m_dRotation = transform2DLinear.MapAngle(coordinateAxes.Rotation) + m_dCaibratedRotation;
            }
        }

        public ICogImage CalibrationImage
        {
            get { return m_icogImageCalibration; } 
        }

        public ICogImage InputImage
        {
            get { return m_cogCalibNPointToNPointTool.InputImage; }
            set { m_cogCalibNPointToNPointTool.InputImage = value; }
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
        
        public bool Calibrated
        {
            get { return m_bCalibrated; }
            set { m_bCalibrated = value; }
        }

        public string Name
        {
            get { return m_cogCalibNPointToNPointTool.Name; }
            set
            {
                m_cogCalibNPointToNPointTool.Name = (string)value;
            }
        }

        public CogCalibNPointToNPointTool GetTool()
        {
            return m_cogCalibNPointToNPointTool;
        }

    }
}
