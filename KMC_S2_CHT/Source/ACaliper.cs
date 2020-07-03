// 2019.04.21
#define _VPRO9_6

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cognex.VisionPro;
using Cognex.VisionPro.Caliper;
using System.Windows.Forms;
using Atmc;


namespace AVisionPro
{
    public class ACaliper : ACogToolBase
    {
        private CogCaliperTool m_cogCaliperTool = null;
        private CogRectangleAffine m_cogRegion = null;
        private CogCaliperPolarityConstants m_emEdge0Polarity;
        private CogCaliperPolarityConstants m_emEdge1Polarity;
        private CogCaliperEdgeModeConstants m_emEdgeMode;

        private double m_dContrastThreshold = 5.0;
        private int m_nFilterHalfSize = 2;
        private int m_nFindCount = 0;
        private double m_dExpectedWidth = 10;

        private double m_dScore = 0;
        private double m_dPositionX = 0;
        private double m_dPositionY = 0;
        private double m_dPosition = 0;
        private double m_dEdge0PositionX = 0;
        private double m_dEdge0PositionY = 0;
        private double m_dEdge0Position = 0;
        private double m_dEdge0Contrast = 0;
        private double m_dEdge1PositionX = 0;
        private double m_dEdge1PositionY = 0;
        private double m_dEdge1Position = 0;
        private double m_dEdge1Contrast = 0;
        private double m_dWidth = 0;

        //** 2016.01.26 by kdi  // 2016.03.11. by SCH : 자료형 수정
        public CogRectangleAffine TrainedRegion
        {
            get { return m_cogRegion; }
            set 
            { 
                m_cogRegion = value;
                // 2016.03.18
                m_cogCaliperTool.Region = value;
            }
        }

        public struct _stResult
        {
            public bool bResult;
            
            public double dEdge0PositionX;
            public double dEdge0PositionY;
            public double dEdge0Contrast;
            public double dEdge1PositionX;
            public double dEdge1PositionY;
            public double dEdge1Contrast;
            public double dWidth;
        }
        public _stResult m_stResult;

        // 2014.09.02
        public double m_dMoveSearchRegionX = 0;
        public double m_dMoveSearchRegionY = 0;
        public double m_dInitSearchRegionX = 0;
        public double m_dInitSearchRegionY = 0;
                
        // 2015.01.15 by kdi
        public CogCaliperTool CaliperTool
        {
            get { return m_cogCaliperTool; }
            set { m_cogCaliperTool = value; }
        }

        public ACaliper()
        {
            m_cogCaliperTool = new CogCaliperTool();

            //-------------------------------
            // 2015.05.11
            // default 값
            StringBuilder sb = new StringBuilder(256);
            AUtil.GetPrivateProfileString("CaliperTool", "ContrastThreshold", "5", sb, 32, ASDef._INI_FILE);
            m_cogCaliperTool.RunParams.ContrastThreshold = Convert.ToDouble(sb.ToString());

            AUtil.GetPrivateProfileString("CaliperTool", "FilterHalfSizeInPixels", "2", sb, 32, ASDef._INI_FILE);
            m_cogCaliperTool.RunParams.FilterHalfSizeInPixels = Convert.ToInt32(sb.ToString());
            //-------------------------------

            Init();
        }

        public ACaliper(Object oTool)
        {
            m_cogCaliperTool = oTool as CogCaliperTool;
            Init();                
        }

        private void Init()
        {
            m_cogRegion = m_cogCaliperTool.Region;
            m_emEdgeMode = m_cogCaliperTool.RunParams.EdgeMode;
            m_emEdge0Polarity = m_cogCaliperTool.RunParams.Edge0Polarity;
            m_emEdge1Polarity = m_cogCaliperTool.RunParams.Edge1Polarity;
            m_dExpectedWidth = m_cogCaliperTool.RunParams.Edge1Position * 2;

            // 2011.06.17
            m_dContrastThreshold = m_cogCaliperTool.RunParams.ContrastThreshold;
            m_nFilterHalfSize = m_cogCaliperTool.RunParams.FilterHalfSizeInPixels;

            // 2014.09.02
            SetInitSearchRegion();

            // 2015.04.08            
            m_cogCaliperTool.Ran += new EventHandler(RanEvent);
        }

        private void SetCaliperParam()
        {
            m_nFindCount = 0;

            if (m_cogCaliperTool != null)
            {
                m_cogCaliperTool.RunParams.EdgeMode = m_emEdgeMode;
                m_cogCaliperTool.RunParams.Edge0Polarity = m_emEdge0Polarity;                

                m_cogCaliperTool.RunParams.ContrastThreshold = m_dContrastThreshold;
                m_cogCaliperTool.RunParams.FilterHalfSizeInPixels = m_nFilterHalfSize;

                if (m_cogRegion != null)
                {
                    m_cogCaliperTool.Region = m_cogRegion as CogRectangleAffine;
                }

                if (m_emEdgeMode == CogCaliperEdgeModeConstants.Pair)
                {
                    m_cogCaliperTool.RunParams.Edge1Polarity = m_emEdge1Polarity;
                    m_cogCaliperTool.RunParams.Edge0Position = -m_dExpectedWidth / 2;
                    m_cogCaliperTool.RunParams.Edge1Position = m_dExpectedWidth / 2;
                }

                // 2015.01.15 by kdi 프로젝션 데이터
                //m_cogCaliperTool.CurrentRecordEnable = CogCaliperCurrentRecordConstants.All;
                //m_cogCaliperTool.LastRunRecordEnable = CogCaliperLastRunRecordConstants.All;
                m_cogCaliperTool.LastRunRecordDiagEnable = CogCaliperLastRunRecordDiagConstants.InputImageByReference |
                                                            CogCaliperLastRunRecordDiagConstants.TransformedRegionPixels |
                                                            CogCaliperLastRunRecordDiagConstants.None;
            }
        }

        public bool GrabRegion(ADisplay aDisplay)
        {
            try
            {
                aDisplay.ClearOverlay();

                ICogGraphicInteractive icogGraphInteractive = null;
                CogRectangleAffine cogRectangleAffine = m_cogCaliperTool.Region;
                
                if (cogRectangleAffine == null)
                {
                    cogRectangleAffine = new CogRectangleAffine();
                    cogRectangleAffine.FitToImage(aDisplay.GetImage8Grey(), 0.5, 0.5);
                }

                icogGraphInteractive = cogRectangleAffine as ICogGraphicInteractive;

                if (icogGraphInteractive != null)
                {
                    icogGraphInteractive.GraphicDOFEnableBase = CogGraphicDOFConstants.All;
                    icogGraphInteractive.Interactive = true;                    
                    icogGraphInteractive.TipText = "Region of Interest";
                    aDisplay.AddOverlay(icogGraphInteractive, "");
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public void SetRegion(ADisplay aDisplay)
        {
            ICogGraphicInteractive icogGraphInteractive = aDisplay.GetInteractiveGraphics("Region of Interest");

            if (icogGraphInteractive != null)
            {
                icogGraphInteractive.GraphicDOFEnableBase = CogGraphicDOFConstants.None;
                icogGraphInteractive.Color = CogColorConstants.Cyan;
                icogGraphInteractive.Interactive = false;
            }

            m_cogRegion = icogGraphInteractive as CogRectangleAffine;
        }


        public void ViewLastRegion(ADisplay aDisplay)
        {
            ICogRegion icogRegion = m_cogCaliperTool.Region;
            ICogGraphicInteractive icogGraphInteractive = icogRegion as ICogGraphicInteractive;

            if (icogGraphInteractive != null)
            {
                icogGraphInteractive.GraphicDOFEnableBase = CogGraphicDOFConstants.All;
                icogGraphInteractive.Color = CogColorConstants.Cyan;
                icogGraphInteractive.Interactive = true;
				// 2016.09.19 by kdi
                icogGraphInteractive.TipText = "Region of Interest";
				
                aDisplay.AddOverlay(icogGraphInteractive, "");
            }
        }

        public void ShowRegion(ADisplay aDisplay)
        {
            // 2015.06.15
            if (m_cogCaliperTool == null)
                return;

            // 2017.05.08
            if (m_cogCaliperTool.Region == null)
                return;

            // 2014.07.02
            ICogRegion icogRegion = m_cogCaliperTool.Region.Copy(CogCopyShapeConstants.GeometryOnly);
            ICogGraphicInteractive icogGraphInteractive = icogRegion as ICogGraphicInteractive;

            if (icogGraphInteractive != null)
            {
                icogGraphInteractive.GraphicDOFEnableBase = CogGraphicDOFConstants.None;
                icogGraphInteractive.Interactive = false;
                icogGraphInteractive.Color = CogColorConstants.DarkGreen;
                aDisplay.AddOverlay(icogGraphInteractive, "");
            }  
        }

        // 2015.05.05
        public void ShowRegion(ADisplay aDisplay, string strSpaceName)
        {
            ICogRegion icogRegion = m_cogCaliperTool.Region.Copy(CogCopyShapeConstants.GeometryOnly);
            icogRegion.SelectedSpaceName = strSpaceName;
            ICogGraphicInteractive icogGraphInteractive = icogRegion as ICogGraphicInteractive;

            if (icogGraphInteractive != null)
            {
                icogGraphInteractive.GraphicDOFEnableBase = CogGraphicDOFConstants.None;
                icogGraphInteractive.Interactive = false;
                icogGraphInteractive.Color = CogColorConstants.DarkGreen;
                                
                aDisplay.AddOverlay(icogGraphInteractive, "");
            }
        }

        public int Run(ADisplay aDisplay)
        {
            SetCaliperParam();

            if (m_cogCaliperTool != null)
            {
                m_cogCaliperTool.InputImage = aDisplay.GetImage8Grey();

                // 2015.04.08
                m_bRan = false;

                m_cogCaliperTool.Run();

                // 2015.04.08
                WaitRanEvent();

                // 2012.02.02
                if (m_cogCaliperTool.Results == null)
                {
                    m_nFindCount = 0;
                    return m_nFindCount;
                }

                if (m_cogCaliperTool.Results.Count > 0)
                {
                    m_dScore = m_cogCaliperTool.Results[0].Score;
                    m_dPositionX = m_cogCaliperTool.Results[0].PositionX;
                    m_dPositionY = m_cogCaliperTool.Results[0].PositionY;
                    m_dPosition = m_cogCaliperTool.Results[0].Position;

                    if (m_emEdgeMode == CogCaliperEdgeModeConstants.SingleEdge)
                    {
                        m_dEdge0PositionX = m_cogCaliperTool.Results[0].Edge0.PositionX;
                        m_dEdge0PositionY = m_cogCaliperTool.Results[0].Edge0.PositionY;
                        m_dEdge0Position = m_cogCaliperTool.Results[0].Edge0.Position;
                        m_dEdge0Contrast = m_cogCaliperTool.Results[0].Edge0.Contrast;
                        m_dEdge1PositionX = 0;
                        m_dEdge1PositionY = 0;
                        m_dEdge1Position = 0;
                        m_dEdge1Contrast = 0;
                    }
                    else
                    {
                        m_dEdge0PositionX = m_cogCaliperTool.Results[0].Edge0.PositionX;
                        m_dEdge0PositionY = m_cogCaliperTool.Results[0].Edge0.PositionY;
                        m_dEdge0Position = m_cogCaliperTool.Results[0].Edge0.Position;
                        m_dEdge0Contrast = m_cogCaliperTool.Results[0].Edge0.Contrast;
                        m_dEdge1PositionX = m_cogCaliperTool.Results[0].Edge1.PositionX;
                        m_dEdge1PositionY = m_cogCaliperTool.Results[0].Edge1.PositionY;
                        m_dEdge1Position = m_cogCaliperTool.Results[0].Edge1.Position;
                        m_dEdge1Contrast = m_cogCaliperTool.Results[0].Edge1.Contrast;
                    }

                    m_dWidth = m_cogCaliperTool.Results[0].Width;
                    m_nFindCount = m_cogCaliperTool.Results.Count;
                }
                else
                {
                    m_dScore = 0;
                    m_dPositionX = 0;
                    m_dPositionY = 0;
                    m_dPosition = 0;
                    m_dEdge0PositionX = 0;
                    m_dEdge0PositionY = 0;
                    m_dEdge0Position = 0;
                    m_dEdge0Contrast = 0;
                    m_dEdge1PositionX = 0;
                    m_dEdge1PositionY = 0;
                    m_dEdge1Position = 0;
                    m_dEdge1Contrast = 0;
                    m_dWidth = 0;
                    m_nFindCount = 0;
                }
            }

            return m_nFindCount;
        }

        // 2015.06.15
        public int Run(ICogImage cogImage)
        {
            SetCaliperParam();

            if (m_cogCaliperTool != null)
            {
                m_cogCaliperTool.InputImage = CogImageConvert.GetIntensityImage(cogImage, 0, 0, cogImage.Width, cogImage.Height);

                // 2015.04.08
                m_bRan = false;

                m_cogCaliperTool.Run();

                // 2015.04.08
                WaitRanEvent();

                // 2012.02.02
                if (m_cogCaliperTool.Results == null)
                {
                    m_nFindCount = 0;
                    return m_nFindCount;
                }

                if (m_cogCaliperTool.Results.Count > 0)
                {
                    m_dScore = m_cogCaliperTool.Results[0].Score;
                    m_dPositionX = m_cogCaliperTool.Results[0].PositionX;
                    m_dPositionY = m_cogCaliperTool.Results[0].PositionY;
                    m_dPosition = m_cogCaliperTool.Results[0].Position;

                    if (m_emEdgeMode == CogCaliperEdgeModeConstants.SingleEdge)
                    {
                        m_dEdge0PositionX = m_cogCaliperTool.Results[0].Edge0.PositionX;
                        m_dEdge0PositionY = m_cogCaliperTool.Results[0].Edge0.PositionY;
                        m_dEdge0Position = m_cogCaliperTool.Results[0].Edge0.Position;
                        m_dEdge0Contrast = m_cogCaliperTool.Results[0].Edge0.Contrast;
                        m_dEdge1PositionX = 0;
                        m_dEdge1PositionY = 0;
                        m_dEdge1Position = 0;
                        m_dEdge1Contrast = 0;
                    }
                    else
                    {
                        m_dEdge0PositionX = m_cogCaliperTool.Results[0].Edge0.PositionX;
                        m_dEdge0PositionY = m_cogCaliperTool.Results[0].Edge0.PositionY;
                        m_dEdge0Position = m_cogCaliperTool.Results[0].Edge0.Position;
                        m_dEdge0Contrast = m_cogCaliperTool.Results[0].Edge0.Contrast;
                        m_dEdge1PositionX = m_cogCaliperTool.Results[0].Edge1.PositionX;
                        m_dEdge1PositionY = m_cogCaliperTool.Results[0].Edge1.PositionY;
                        m_dEdge1Position = m_cogCaliperTool.Results[0].Edge1.Position;
                        m_dEdge1Contrast = m_cogCaliperTool.Results[0].Edge1.Contrast;
                    }

                    //m_dWidth = m_cogCaliperTool.Results[0].Width;
                    m_nFindCount = m_cogCaliperTool.Results.Count;
                }
                else
                {
                    //m_dScore = 0;
                    //m_dPositionX = 0;
                    //m_dPositionY = 0;
                    //m_dPosition = 0;
                    //m_dEdge0PositionX = 0;
                    //m_dEdge0PositionY = 0;
                    //m_dEdge0Position = 0;
                    //m_dEdge0Contrast = 0;
                    //m_dEdge1PositionX = 0;
                    //m_dEdge1PositionY = 0;
                    //m_dEdge1Position = 0;
                    //m_dEdge1Contrast = 0;
                    //m_dWidth = 0;
                    m_nFindCount = 0;
                }
            }

            return m_nFindCount;
        }

        // 2013.02.05
        public int GetRun()
        {
            SetCaliperParam();

            if (m_cogCaliperTool != null)
            {
                if (m_cogCaliperTool.Results == null)
                {
                    m_nFindCount = 0;
                    return m_nFindCount;
                }

                if (m_cogCaliperTool.Results.Count > 0)
                {
                    m_dScore = m_cogCaliperTool.Results[0].Score;
                    m_dPositionX = m_cogCaliperTool.Results[0].PositionX;
                    m_dPositionY = m_cogCaliperTool.Results[0].PositionY;
                    m_dPosition = m_cogCaliperTool.Results[0].Position;

                    if (m_emEdgeMode == CogCaliperEdgeModeConstants.SingleEdge)
                    {
                        m_dEdge0PositionX = m_cogCaliperTool.Results[0].Edge0.PositionX;
                        m_dEdge0PositionY = m_cogCaliperTool.Results[0].Edge0.PositionY;
                        m_dEdge0Position = m_cogCaliperTool.Results[0].Edge0.Position;
                        m_dEdge0Contrast = m_cogCaliperTool.Results[0].Edge0.Contrast;
                        m_dEdge1PositionX = 0;
                        m_dEdge1PositionY = 0;
                        m_dEdge1Position = 0;
                        m_dEdge1Contrast = 0;
                    }
                    else
                    {
                        m_dEdge0PositionX = m_cogCaliperTool.Results[0].Edge0.PositionX;
                        m_dEdge0PositionY = m_cogCaliperTool.Results[0].Edge0.PositionY;
                        m_dEdge0Position = m_cogCaliperTool.Results[0].Edge0.Position;
                        m_dEdge0Contrast = m_cogCaliperTool.Results[0].Edge0.Contrast;
                        m_dEdge1PositionX = m_cogCaliperTool.Results[0].Edge1.PositionX;
                        m_dEdge1PositionY = m_cogCaliperTool.Results[0].Edge1.PositionY;
                        m_dEdge1Position = m_cogCaliperTool.Results[0].Edge1.Position;
                        m_dEdge1Contrast = m_cogCaliperTool.Results[0].Edge1.Contrast;
                    }

                    m_dWidth = m_cogCaliperTool.Results[0].Width;
                    m_nFindCount = m_cogCaliperTool.Results.Count;
                }
                else
                {
                    m_dScore = 0;
                    m_dPositionX = 0;
                    m_dPositionY = 0;
                    m_dPosition = 0;
                    m_dEdge0PositionX = 0;
                    m_dEdge0PositionY = 0;
                    m_dEdge0Position = 0;
                    m_dEdge0Contrast = 0;
                    m_dEdge1PositionX = 0;
                    m_dEdge1PositionY = 0;
                    m_dEdge1Position = 0;
                    m_dEdge1Contrast = 0;
                    m_dWidth = 0;
                    m_nFindCount = 0;
                }
            }

            return m_nFindCount;
        }

        public void ViewResult(ADisplay aDisplay, bool isShowRegion)
        {
            // 2015.02.09
            if (isShowRegion)
            {
                ShowRegion(aDisplay);
            }

            if (m_nFindCount>0)
            {
                CogCaliperResults cogCaliperResults = new CogCaliperResults();                
                cogCaliperResults = m_cogCaliperTool.Results;

                if (cogCaliperResults != null && cogCaliperResults.Count >= 1)
                {
                    CogCaliperResult caliperResult = new CogCaliperResult();
                    caliperResult = cogCaliperResults[0];

                    CogCompositeShape compositeShape = new CogCompositeShape();
                    // 2015.02.09
                    /*
                    if (isShowRegion)
                    {
                        ShowRegion(aDisplay);           
                    }     
                    */

                    compositeShape = caliperResult.CreateResultGraphics((CogCaliperResultGraphicConstants)(1 + 2));                    

                    aDisplay.AddOverlay((ICogGraphicInteractive)compositeShape, "");
                }
            }
        }

        // 2015.06.15 
        public void ViewResult2(ADisplay aDisplay, bool isShowRegion)
        {
            if (m_cogCaliperTool == null)
                return;

            // 2015.02.09
            if (isShowRegion)
            {
                ShowRegion(aDisplay);
            }

            int nFindCount = m_cogCaliperTool.Results.Count;
            if (nFindCount > 0)
            {
                CogCaliperResults cogCaliperResults = new CogCaliperResults();
                cogCaliperResults = m_cogCaliperTool.Results;

                if (cogCaliperResults != null && cogCaliperResults.Count >= 1)
                {
                    CogCaliperResult caliperResult = new CogCaliperResult();
                    caliperResult = cogCaliperResults[0];

                    CogCompositeShape compositeShape = new CogCompositeShape();

                    compositeShape = caliperResult.CreateResultGraphics((CogCaliperResultGraphicConstants)(1 + 2));
                    aDisplay.AddOverlay((ICogGraphicInteractive)compositeShape, "");
                }
            }
        }

#if !_VPRO9_6
        public CogImage8Grey InputImage
#else
        public ICogImage InputImage
#endif
        {
            get { return m_cogCaliperTool.InputImage; }
            set { m_cogCaliperTool.InputImage = value; }
        }

        public CogCaliperTool GetTool()
        {
            return m_cogCaliperTool;
        }

        // 2015.06.25
        public void SetTool(CogCaliperTool caliperTool)
        {
            if (m_cogCaliperTool != null)
                m_cogCaliperTool = null;

            m_cogCaliperTool = caliperTool;
        }

        public CogCaliperEdgeModeConstants EdgeMode
        {
            get { return m_emEdgeMode; }
            set
            {
                m_emEdgeMode = value;
            }
        }

        public CogCaliperPolarityConstants Edge0Polarity
        {
            get { return m_emEdge0Polarity; }
            set
            {
                m_emEdge0Polarity = value;
            }
        }

        public CogCaliperPolarityConstants Edge1Polarity
        {
            get { return m_emEdge1Polarity; }
            set
            {
                m_emEdge1Polarity = value;
            }
        }

        public double ContrastThreshold
        {
            get { return m_dContrastThreshold; }
            set
            {
                m_dContrastThreshold = (double)value;
            }
        }

        public int FilterHalfSize
        {
            get { return m_nFilterHalfSize; }
            set
            {
                m_nFilterHalfSize = (int)value;
            }
        }

        public double ExpectedWidth
        {
            get { return m_dExpectedWidth; }
            set
            {
                m_dExpectedWidth = (double)value;
            }
        }

        public string Name
        {
            get { return m_cogCaliperTool.Name; }
            set
            {
                m_cogCaliperTool.Name = (string)value;
            }
        }

        public double Width
        {
            get { return m_dWidth; }
        }

        public double Score
        {
            get { return m_dScore; }
        }

        public double PositionX
        {
            get { return m_dPositionX; }
        }

        public double PositionY
        {
            get { return m_dPositionY; }
        }

        public double Position
        {
            get { return m_dPosition; }
        }

        public double Edge0PositionX
        {
            get { return m_dEdge0PositionX; }
        }

        public double Edge0PositionY
        {
            get { return m_dEdge0PositionY; }
        }

        public double Edge0Position
        {
            get { return m_dEdge0Position; }
        }

        public double Edge0Contrast
        {
            get { return m_dEdge0Contrast; }
        }

        public double Edge1PositionX
        {
            get { return m_dEdge1PositionX; }
        }

        public double Edge1PositionY
        {
            get { return m_dEdge1PositionY; }
        }

        public double Edge1Position
        {
            get { return m_dEdge1Position; }
        }
        public double Edge1Contrast
        {
            get { return m_dEdge1Contrast; }
        }

        // 2014.08.19
        public CogRectangleAffine Region
        {
            get { return m_cogRegion; }
        }

        public bool RunCaliper(ADisplay aDisplay)
        {
            return RunCaliper(aDisplay, true, true, 0, 0);
        }
        public bool RunCaliper(ADisplay aDisplay, bool bViewTxt)
        {
            return RunCaliper(aDisplay, bViewTxt, true, 0, 0);
        }
        public bool RunCaliper(ADisplay aDisplay, bool bViewTxt, bool bShowRegion, double dX, double dY)
        {
            if (Run(aDisplay) > 0)
            {
                ViewResult(aDisplay, bShowRegion);

                m_stResult.bResult = true;

                m_stResult.dEdge0PositionX = Edge0PositionX;
                m_stResult.dEdge0PositionY = Edge0PositionY;
                m_stResult.dEdge0Contrast = Edge0Contrast;
                m_stResult.dEdge1PositionX = Edge1PositionX;
                m_stResult.dEdge1PositionY = Edge1PositionY;
                m_stResult.dEdge1Contrast = Edge1Contrast;
                m_stResult.dWidth = Width;

                if (bViewTxt)
                    aDisplay.AddTxt(dX, dY, "Caliper:OK(" + Math.Round(m_stResult.dEdge0Contrast, 2).ToString()+")", CogColorConstants.Green);
            }
            else
            {
                ShowRegion(aDisplay);

                m_stResult.bResult = false;

                if (bViewTxt)
                    aDisplay.AddTxt(dX, dY, "Caliper:NG", CogColorConstants.Red);
            }

            return m_stResult.bResult;
        }

        // 2014.09.02
        public bool RunCaliper(ADisplay aDisplay, bool bViewTxt, bool bShowRegion, double dX, double dY,
            double dSearchRegionX, double dSearchRegionY, 
            double dMoveX, double dMoveY)
        {
            SetInitSearchRegion(dSearchRegionX, dSearchRegionY);
            MoveSearchRegion(dMoveX, dMoveY);

            if (Run(aDisplay) > 0)
            {
                ViewResult(aDisplay, bShowRegion);

                m_stResult.bResult = true;

                m_stResult.dEdge0PositionX = Edge0PositionX;
                m_stResult.dEdge0PositionY = Edge0PositionY;
                m_stResult.dEdge0Contrast = Edge0Contrast;
                m_stResult.dEdge1PositionX = Edge1PositionX;
                m_stResult.dEdge1PositionY = Edge1PositionY;
                m_stResult.dEdge1Contrast = Edge1Contrast;
                m_stResult.dWidth = Width;

                if (bViewTxt)
                    aDisplay.AddTxt(dX, dY, "Caliper:OK(" + Math.Round(m_stResult.dEdge0Contrast, 2).ToString() + ")", CogColorConstants.Green);
            }
            else
            {
                ShowRegion(aDisplay);

                m_stResult.bResult = false;

                if (bViewTxt)
                    aDisplay.AddTxt(dX, dY, "Caliper:NG", CogColorConstants.Red);
            }

            return m_stResult.bResult;
        }

        // 2013.02.18
        public void SetRegionInteractive(bool bVal)
        {
            try
            {
                ICogGraphicInteractive icogGraphInteractive = null;

                icogGraphInteractive = m_cogCaliperTool.Region as ICogGraphicInteractive;

                if (icogGraphInteractive != null)
                {
                    icogGraphInteractive.GraphicDOFEnableBase = CogGraphicDOFConstants.All;
                    icogGraphInteractive.Interactive = bVal;
                }
            }
            catch
            {
            }
        }

        // 2014.09.02
        public void SetInitSearchRegion(double dX, double dY)
        {
            m_dInitSearchRegionX = dX;
            m_dInitSearchRegionY = dY;

            ICogRegion region = m_cogCaliperTool.Region;

            if (region is CogRectangleAffine)
            {
                CogRectangleAffine rectangleAffine = region as CogRectangleAffine;

                rectangleAffine.CenterX = m_dInitSearchRegionX;
                rectangleAffine.CenterY = m_dInitSearchRegionY;
            }            
        }

        // 2014.09.02
        public void SetInitSearchRegion()
        {
            ICogRegion region = m_cogCaliperTool.Region;

            if (region is CogRectangleAffine)
            {
                CogRectangleAffine rectangleAffine = region as CogRectangleAffine;

                m_dInitSearchRegionX = rectangleAffine.CenterX - m_dMoveSearchRegionX;
                m_dInitSearchRegionY = rectangleAffine.CenterY - m_dMoveSearchRegionY;
            }
        }

        // 2014.09.02
        public void MoveSearchRegion(double x, double y)
        {
            m_dMoveSearchRegionX = x;
            m_dMoveSearchRegionY = y;

            ICogRegion region = m_cogCaliperTool.Region;

            if (region is CogRectangleAffine)
            {
                CogRectangleAffine rectangleAffine = region as CogRectangleAffine;

                rectangleAffine.CenterX = m_dInitSearchRegionX + x;
                rectangleAffine.CenterY = m_dInitSearchRegionY + y;
            }            
        }
    }
}
