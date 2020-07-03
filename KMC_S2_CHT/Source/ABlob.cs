using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cognex.VisionPro;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.Display;
using System.Collections;
using System.Windows.Forms;

namespace AVisionPro
{
    public class ABlob : ACogToolBase
    {
        private CogBlobTool m_cogBlobTool = null;
        private CogBlobSegmentationPolarityConstants m_emPolarity;
        private ICogRegion m_icogRegion = null;
        private CogImage8Grey m_cogimgMask = null;

        private int m_nFindCount = 0;
        private int m_nThreshold = 0;
        private int m_nMinArea = 0;

        //** 2016.01.26 by kdi
        public ICogRegion TrainedRegion
        {
            //** 2016.03.10. by SCH
            //get { return m_icogRegionTrain; }
            get { return m_icogRegion; }
            //set { m_icogRegionTrain = value; }
            set 
            { 
                m_icogRegion = value;
                // 2016.03.18
                m_cogBlobTool.Region = value;
            }
            //*/
        }
        
        public struct _stResult
        {
            public bool bResult;

            public int nCount;
        }
        public _stResult m_stResult;
                
        public ABlob()
        {
            m_cogBlobTool = new CogBlobTool();
            Init();
            m_cogBlobTool.RunParams.SegmentationParams.Mode = CogBlobSegmentationModeConstants.HardFixedThreshold;            
        }

        public ABlob(Object oTool)
        {
            m_cogBlobTool = oTool as CogBlobTool;
            Init();            
        }

        private void Init()
        {
            m_icogRegion = m_cogBlobTool.Region;
            m_cogimgMask = m_cogBlobTool.RunParams.InputImageMask;
            m_nThreshold = m_cogBlobTool.RunParams.SegmentationParams.HardFixedThreshold;
            m_emPolarity = m_cogBlobTool.RunParams.SegmentationParams.Polarity;
            m_nMinArea = m_cogBlobTool.RunParams.ConnectivityMinPixels;
            // 2015.04.08
            m_cogBlobTool.Ran += new EventHandler(RanEvent);
        }

        private void SetBlobParam()
        {
            m_nFindCount = 0;

            if (m_cogBlobTool != null)
            {
                m_cogBlobTool.RunParams.SegmentationParams.HardFixedThreshold = m_nThreshold;
                m_cogBlobTool.RunParams.ConnectivityMinPixels = m_nMinArea;
                m_cogBlobTool.RunParams.SegmentationParams.Polarity = m_emPolarity;

                m_cogBlobTool.Region = m_icogRegion;
            }
        }

        public bool GrabRegion(ADisplay aDisplay, AVisionProBuild._emRegionShape emRegionShape)
        {
            aDisplay.ClearOverlay();

            ICogGraphicInteractive icogGraphInteractive = null;
            ICogRegion icogRegion = m_cogBlobTool.Region;

            CogCircle circle = icogRegion as CogCircle;
            CogEllipse ellipse = icogRegion as CogEllipse;
            CogRectangle rectangle = icogRegion as CogRectangle;
            CogRectangleAffine rectangleAffine = icogRegion as CogRectangleAffine;
            CogCircularAnnulusSection circularAnnuluns = icogRegion as CogCircularAnnulusSection;
            CogEllipticalAnnulusSection ellipticalAnnuluns = icogRegion as CogEllipticalAnnulusSection;

            switch (emRegionShape)
            {
                case AVisionProBuild._emRegionShape.Circle:
                    {
                        if (circle == null)
                        {
                            circle = new CogCircle();
                            circle.FitToImage(aDisplay.GetImage8Grey(), 0.5, 0.5);
                        }                        
                        icogGraphInteractive = circle as ICogGraphicInteractive;
                    }
                    break;
                case AVisionProBuild._emRegionShape.Ellipse:
                    {
                        if (ellipse == null)
                        {
                            ellipse = new CogEllipse();
                            ellipse.FitToImage(aDisplay.GetImage8Grey(), 0.5, 0.5);
                        }
                        icogGraphInteractive = ellipse as ICogGraphicInteractive;
                    }
                    break;
                case AVisionProBuild._emRegionShape.Rectangle:
                    {
                        if (rectangle == null)
                        {
                            rectangle = new CogRectangle();
                            rectangle.FitToImage(aDisplay.GetImage8Grey(), 0.5, 0.5);
                        }
                        icogGraphInteractive = rectangle as ICogGraphicInteractive;
                    }
                    break;
                case AVisionProBuild._emRegionShape.RectangleAffine:
                    {
                        if (rectangleAffine == null)
                        {
                            rectangleAffine = new CogRectangleAffine();
                            rectangleAffine.FitToImage(aDisplay.GetImage8Grey(), 0.5, 0.5);
                        }
                        icogGraphInteractive = rectangleAffine as ICogGraphicInteractive;
                    }
                    break;
                case AVisionProBuild._emRegionShape.CircularAnnulusSection:
                    {
                        if (circularAnnuluns == null)
                        {
                            circularAnnuluns = new CogCircularAnnulusSection();
                            circularAnnuluns.FitToImage(aDisplay.GetImage8Grey(), 0.5, 0.5);
                        }
                        icogGraphInteractive = circularAnnuluns as ICogGraphicInteractive;
                    }
                    break;
                case AVisionProBuild._emRegionShape.EllipticalAnnulusSection:
                    {
                        if (ellipticalAnnuluns == null)
                        {
                            ellipticalAnnuluns = new CogEllipticalAnnulusSection();
                            ellipticalAnnuluns.FitToImage(aDisplay.GetImage8Grey(), 0.5, 0.5);
                        }
                        icogGraphInteractive = ellipticalAnnuluns as ICogGraphicInteractive;
                    }
                    break;
                case AVisionProBuild._emRegionShape.Entire:
                    {
                        m_icogRegion = null;
                        aDisplay.ClearOverlay();
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
                aDisplay.AddOverlay(icogGraphInteractive, "");
            }

            return true;
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

            m_icogRegion = icogGraphInteractive as ICogRegion;
        }

        public void ViewLastRegion(ADisplay aDisplay)
        {
            ICogRegion icogRegion = m_cogBlobTool.Region;
            ICogGraphicInteractive icogGraphInteractive = icogRegion as ICogGraphicInteractive;

            if (icogGraphInteractive != null)
            {
                icogGraphInteractive.GraphicDOFEnableBase = CogGraphicDOFConstants.All;
                icogGraphInteractive.Interactive = true;
                // 2016.09.19 by kdi
                icogGraphInteractive.TipText = "Region of Interest";

                aDisplay.AddOverlay(icogGraphInteractive, "");
            }           
        }

        public void ShowRegion(ADisplay aDisplay)
        {
            ICogRegion icogRegion = m_cogBlobTool.Region;
            ICogGraphicInteractive icogGraphInteractive = icogRegion as ICogGraphicInteractive;

            if (icogGraphInteractive != null)
            {
                icogGraphInteractive.GraphicDOFEnableBase = CogGraphicDOFConstants.None;
                icogGraphInteractive.Interactive = false;
                icogGraphInteractive.Color = CogColorConstants.DarkGreen;
                aDisplay.AddOverlay(icogGraphInteractive, "");
            }
        }

        // 2013.02.05
        public int GetRun()
        {
            SetBlobParam();

            if (m_cogBlobTool != null)
            {
                try
                {
                    if (m_cogBlobTool.Results != null)
                    {
                        // 2011.05.24
                        m_nFindCount = m_cogBlobTool.Results.GetBlobs().Count;
                    }
                }
                catch
                {
                }
            }

            return m_nFindCount;
        }

        public int Run(ADisplay aDisplay)
        {
            // 2016.03.22
            m_nFindCount = 0;

            SetBlobParam();

            if (m_cogBlobTool != null)
            {
                m_cogBlobTool.InputImage = aDisplay.GetImage8Grey();
                if (m_cogimgMask != null)
                {
                    m_cogBlobTool.RunParams.InputImageMask = m_cogimgMask;
                }

                try
                {
                    // 2015.04.08
                    m_bRan = false;

                    m_cogBlobTool.Run();

                    // 2015.04.08
                    WaitRanEvent();

                    if (m_cogBlobTool.Results != null)
                    {
                        // 2011.05.24
                        m_nFindCount = m_cogBlobTool.Results.GetBlobs().Count;
                    }
                }
                catch
                {
                    MessageBox.Show("Run Blob Error");
                }
            }

            return m_nFindCount;
        }

        // 2015.04.01
        public int Run(ICogImage cogImage)
        {
            // 2016.03.22
            m_nFindCount = 0;

            SetBlobParam();

            // 2016.03.29
            //if (m_cogBlobTool != null)
            if (m_cogBlobTool != null && cogImage != null)
            {
                m_cogBlobTool.InputImage = CogImageConvert.GetIntensityImage(cogImage, 0, 0, cogImage.Width, cogImage.Height);
                if (m_cogimgMask != null)
                {
                    m_cogBlobTool.RunParams.InputImageMask = m_cogimgMask;
                }

                try
                {
                    // 2015.04.08
                    m_bRan = false;

                    m_cogBlobTool.Run();
                    // 2015.04.08
                    WaitRanEvent();

                    if (m_cogBlobTool.Results != null)
                    {
                        // 2011.05.24
                        m_nFindCount = m_cogBlobTool.Results.GetBlobs().Count;
                    }
                }
                catch
                {
                    MessageBox.Show("Run Blob Error");
                }
            }

            return m_nFindCount;
        }
             
        public void ViewResult(ADisplay aDisplay, bool isShowCenter, bool isShowRegion)
        {
            int nOption = 0;
            if (isShowCenter)
            {
                nOption = 2;
            }
            // 2015.02.09
            if (isShowRegion)
            {
                ShowRegion(aDisplay);
            }

            if (m_nFindCount > 0)
            {
                CogBlobResult cogBlobResult = new CogBlobResult();

                // 2016.03.22
                int[] pnID = new int[m_nFindCount];
                pnID = m_cogBlobTool.Results.GetBlobIDs(true);

                for (int i = 0; i < m_nFindCount; i++)
                {
                    // 2016.03.22 i => pnID[i]
                    cogBlobResult = m_cogBlobTool.Results.GetBlobByID(pnID[i]);

                    if (cogBlobResult != null)
                    {  
                        CogCompositeShape cogCompositeShape = new CogCompositeShape();                       
                        cogCompositeShape = cogBlobResult.CreateResultGraphics((CogBlobResultGraphicConstants)(1 + 4 + nOption));     
                        aDisplay.AddOverlay((ICogGraphicInteractive)cogCompositeShape, "");
                    }
                }

                // 2015.02.09
                /*
                if (isShowRegion)
                {
                    ShowRegion(aDisplay);
                }
                */
            }
        }

        public void GetResultToList(ListView lstvwResult)
        {
            lstvwResult.Items.Clear();
            ListViewItem lstvwItem = new ListViewItem();

            if (m_nFindCount > 0)
            {
                // 2016.03.22
                int[] pnID = new int[m_nFindCount];
                pnID = m_cogBlobTool.Results.GetBlobIDs(true);

                for (int i = 0; i < m_nFindCount; i++)
                {
                    lstvwItem = lstvwResult.Items.Add((i).ToString());
                    // 2016.03.22 i => pnID[i]
                    lstvwItem.SubItems.Add(m_cogBlobTool.Results.GetBlobByID(pnID[i]).Area.ToString());
                    lstvwItem.SubItems.Add(Math.Round(m_cogBlobTool.Results.GetBlobByID(pnID[i]).CenterOfMassX, 3).ToString());
                    lstvwItem.SubItems.Add(Math.Round(m_cogBlobTool.Results.GetBlobByID(pnID[i]).CenterOfMassY, 3).ToString());
                    if (m_cogBlobTool.Results.GetBlobByID(pnID[i]).Label == CogBlobLabelConstants.Blob)
                    {
                        lstvwItem.SubItems.Add("Blob");
                    }
                    else
                    {
                        lstvwItem.SubItems.Add("Hole");
                    }   
                }
            }           
        }

        public CogImage8Grey InputImage
        {
            // 2013.04.19
            get { return (CogImage8Grey)m_cogBlobTool.InputImage; }
            set { m_cogBlobTool.InputImage = value; }
        }

        public CogBlobTool GetTool()
        {
            return m_cogBlobTool;
        }

        public CogBlobSegmentationPolarityConstants Polarity
        {
            get { return m_emPolarity; }
            set
            {
                m_emPolarity = value;
            }
        }

        public int Threshold
        {
            get { return m_nThreshold; }
            set
            {
                m_nThreshold = (int)value;
            }
        }

        public int MinPixels
        {
            get { return m_nMinArea; }
            set
            {
                m_nMinArea = (int)value; 
            }
        }
        // 2011.05.24
        public int FindCount
        {
            get { return m_nFindCount; }
            set
            {
                m_nFindCount = (int)value;
            }
        }

        public string Name
        {
            get { return m_cogBlobTool.Name; }
            set
            {
                m_cogBlobTool.Name = (string)value;
            }
        }

        public CogImage8Grey MaskImage
        {
            get { return m_cogimgMask; }
            set
            {
                m_cogimgMask = value;
            }
        }

        public AVisionProBuild._emRegionShape Shape
        {
            get
            {
                if (m_cogBlobTool.Region is CogCircle)
                {
                    return AVisionProBuild._emRegionShape.Circle;
                }
                else if (m_cogBlobTool.Region is CogEllipse)
                {
                    return AVisionProBuild._emRegionShape.Ellipse;
                }
                else if (m_cogBlobTool.Region is CogRectangle)
                {
                    return AVisionProBuild._emRegionShape.Rectangle;
                }
                else if (m_cogBlobTool.Region is CogRectangleAffine)
                {
                    return AVisionProBuild._emRegionShape.RectangleAffine;
                }
                else if (m_cogBlobTool.Region is CogCircularAnnulusSection)
                {
                    return AVisionProBuild._emRegionShape.CircularAnnulusSection;
                }
                else if (m_cogBlobTool.Region is CogEllipticalAnnulusSection)
                {
                    return AVisionProBuild._emRegionShape.EllipticalAnnulusSection;
                }
                else
                {
                    return AVisionProBuild._emRegionShape.Entire;
                }
            }
        }
        public bool RunBlob(ADisplay aDisplay)
        {
            return RunBlob(aDisplay, true, true, true, 0, 0);
        }
        public bool RunBlob(ADisplay aDisplay, bool bViewTxt)
        {
            return RunBlob(aDisplay, bViewTxt, true, true, 0, 0);
        }
        public bool RunBlob(ADisplay aDisplay, bool bViewTxt, bool bShowCenter, bool bShowRegion, double dX, double dY)
        {
            if (Run(aDisplay) > 0)
            {
                ViewResult(aDisplay, bShowCenter, bShowRegion);

                m_stResult.bResult = true;
                m_stResult.nCount = m_nFindCount;
                if (bViewTxt)
                    aDisplay.AddTxt(dX, dY, "Blob:find" + m_nFindCount.ToString(), CogColorConstants.Green);
            }
            else
            {
                ShowRegion(aDisplay);

                m_stResult.bResult = false;
                m_stResult.nCount = 0;
                if (bViewTxt)
                    aDisplay.AddTxt(dX, dY, "Blob:NG", CogColorConstants.Red);
            }

            return m_stResult.bResult;
        }

        public bool GetResult(int n, ref double dX, ref double dY, ref double dArea)
        {
            if (m_nFindCount > n && n >= 0)
            {
                // 2016.03.22
                int[] pnID = new int[m_nFindCount];
                pnID = m_cogBlobTool.Results.GetBlobIDs(true);

                // 2016.03.22 n => pnID[n]
                dArea = m_cogBlobTool.Results.GetBlobByID(pnID[n]).Area;
                dX = m_cogBlobTool.Results.GetBlobByID(pnID[n]).CenterOfMassX;
                dY = m_cogBlobTool.Results.GetBlobByID(pnID[n]).CenterOfMassY;

                return true;
            }
            return false;
        }
        
        public double GetResultTotalArea()
        {
            double dArea = 0;
            // 2016.03.22
            if (m_nFindCount > 0)
            {
                int[] pnID = new int[m_nFindCount];
                pnID = m_cogBlobTool.Results.GetBlobIDs(true);

                for (int i = 0; i < m_nFindCount; i++)
                {
                    // 2016.03.22 i => pnID[i]
                    dArea += m_cogBlobTool.Results.GetBlobByID(pnID[i]).Area;
                }
            }
            
            return dArea;
        }

        // 2015.04.07
        public CogImage8Grey GetBlobImage()
        {
            try
            {
                return m_cogBlobTool.Results.CreateBlobImage();
            }
            catch
            {
                return null;
            }
        }
    }
}
