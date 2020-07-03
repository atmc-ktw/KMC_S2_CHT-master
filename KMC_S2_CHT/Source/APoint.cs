//#define _USE_BASLER_PYLON
//#define _USE_IMAGING_CONTROL
//#define _USE_FLIR
// 2014.10.30
//#define _USE_1Camera

//#define _USE_TOOLBLOCK
//#define _USE_FINDLINE
//#define _USE_FINDCIRCLE
//#define _USE_SEARCHMAX
//#define _USE_PATINSPECT
//#define _USE_COLOREXTRACTOR
//#define _USE_COLORMATCH
//#define _USE_COLORSEGMENTER
//#define _USE_COMPOSITECOLORMATCH
//#define _USE_OCRMAX
//#define _USE_OCVMAX
//#define _USE_ID
// 2018.04.09
//#define _USE_LINEMAX
// 2019.04.21
//#define _USE_PMREDLINE

// 2019.05.21
//#define _USE_3DPATMAX
// 2019.06.14
//#define _USE_eCLASSIFIER

// 2016.06.21
#define _USE_FIXTURENPOINTTONPOINT

#define _USE_FINDCORNER
#define _USE_FINDELLIPSE

// 2018.04.09
// Vpro9.2 삭제됨
//#define _USE_2DSYMBOL
//#define _USE_2DSYMBOLVERIFY
//#define _USE_BARCODE


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cognex.VisionPro;
using Cognex.VisionPro.ToolGroup;
using Atmc;

namespace AVisionPro
{
    public class APoint
    {
        public CogToolGroup m_cogtgPoint;
        // 2014.10.30
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL && !_USE_FLIR && !_USE_1Camera)
        private AAcqFifo m_aAcqFifo = null;
		// 2018.01.18 by kdi
        public AAcqFifo aAcqFifo
        {
            get { return m_aAcqFifo; }
            set { m_aAcqFifo = value; }
        }
#endif
        private ABlob m_aBlob;
        private ACaliper m_aCaliper;
        private ACalibCheckerboard m_aCalibCheckerboard;
        private ACalibNPointToNPoint m_aCalibNPointToNPoint;
        private AHistogram m_aHistogram;
        private APMAligns m_aPMAligns;

#if _USE_BARCODE
        private ABarcode m_aBarcode;        
#endif
#if _USE_ID
        private AID m_aID;
#endif
#if _USE_FINDLINE
        private AFindLine m_aFindLine;
#endif
#if _USE_FINDCIRCLE
        private AFindCircle m_aFindCircle;
#endif
#if _USE_FINDELLIPSE
        private AFindEllipse m_aFindEllipse;
#endif
#if _USE_FINDCORNER
        private AFindCorner m_aFindCorner;
#endif
#if _USE_LINEMAX
        private ALineMax m_aLineMax;
#endif
#if _USE_PATINSPECT
        private APatInspect m_aPatInspect;
#endif
/*
// 2019.05.21
#if _USE_3DPATMAX
        private A3DPatMax m_a3DPatMax;
#endif
*/
#if _USE_SEARCHMAX
        // 2016.05.09
        private ASearchMaxs m_aSearchMaxs;
#endif
#if _USE_PMREDLINE
        // 2019.04.21
        private APMRedLines m_aPMRedLines;
#endif
#if _USE_COLOREXTRACTOR
        private AColorExtractor m_aColorExtractor;
#endif
#if _USE_COLORMATCH
        private AColorMatch m_aColorMatch;
#endif
#if _USE_COLORSEGMENTER
        private AColorSegmenter m_aColorSegmenter;
#endif
#if _USE_COMPOSITECOLORMATCH
        private ACompositeColorMatch m_aCompositeColorMatch;
#endif

#if _USE_2DSYMBOL
        private A2DSymbol m_a2DSymbol;
#endif
#if _USE_2DSYMBOLVERIFY
        private A2DSymbolVerify m_a2DSymbolVerify;
#endif
#if _USE_OCV
        private AOCV m_aOCV;
#endif
#if _USE_OCVMAX
        private AOCVMax m_aOCVMax;
#endif
#if _USE_OCRMAX
        private AOCRMax m_aOCRMax;
#endif
// 2016.06.21
#if _USE_FIXTURENPOINTTONPOINT
        private AFixtureNPointToNPoint m_aFixtureNPointToNPoint;
#endif

// 2019.06.14
#if _USE_eCLASSIFIER
        private AeClassifier m_aeClassifier = null;
#endif

#if _USE_TOOLBLOCK
        private AToolBlock m_aToolBlock;
#endif
        // 2014.10.30
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL && !_USE_FLIR && !_USE_1Camera)
        private List<AAcqFifo> m_lstAAcqFifo = new List<AAcqFifo>();
#endif
        private List<ABlob> m_lstABlob = new List<ABlob>();
        private List<ACaliper> m_lstACaliper = new List<ACaliper>();
        private List<ACalibCheckerboard> m_lstACalibCheckerboard = new List<ACalibCheckerboard>();
        private List<ACalibNPointToNPoint> m_lstACalibNPointToNPoint = new List<ACalibNPointToNPoint>();
        private List<AHistogram> m_lstAHistogram = new List<AHistogram>();
        private List<APMAligns> m_lstAPMAligns = new List<APMAligns>();

#if _USE_BARCODE
        private List<ABarcode> m_lstABarcode = new List<ABarcode>();
#endif
#if _USE_ID
        private List<AID> m_lstAID = new List<AID>();
#endif
#if _USE_FINDLINE
        private List<AFindLine> m_lstAFindLine = new List<AFindLine>();
#endif
#if _USE_FINDCIRCLE
        private List<AFindCircle> m_lstAFindCircle = new List<AFindCircle>();
#endif
#if _USE_FINDELLIPSE
        private List<AFindEllipse> m_lstAFindEllipse = new List<AFindEllipse>();
#endif
#if _USE_FINDCORNER
        private List<AFindCorner> m_lstAFindCorner = new List<AFindCorner>();
#endif
#if _USE_LINEMAX
        private List<ALineMax> m_lstALineMax = new List<ALineMax>();
#endif
#if _USE_PATINSPECT
        private List<APatInspect> m_lstAPatInspect = new List<APatInspect>();
#endif
/*
// 2019.05.21
#if _USE_3DPATMAX
        private List<A3DPatMax> m_lstA3DPatMax = new List<A3DPatMax>();
#endif
*/
#if _USE_SEARCHMAX
        // 2016.05.09
        private List<ASearchMaxs> m_lstASearchMaxs = new List<ASearchMaxs>();
#endif
#if _USE_PMREDLINE
        // 2019.04.21
        private List<APMRedLines> m_lstAPMRedLines = new List<APMRedLines>();
#endif
#if _USE_COLOREXTRACTOR
        private List<AColorExtractor> m_lstAColorExtractor = new List<AColorExtractor>();
#endif
#if _USE_COLORMATCH
        private List<AColorMatch> m_lstAColorMatch = new List<AColorMatch>();
#endif
#if _USE_COLORSEGMENTER
        private List<AColorSegmenter> m_lstAColorSegmenter = new List<AColorSegmenter>();
#endif
#if _USE_COMPOSITECOLORMATCH
        private List<ACompositeColorMatch> m_lstACompositeColorMatch = new List<ACompositeColorMatch>();
#endif

#if _USE_2DSYMBOL
        private List<A2DSymbol> m_lstA2DSymbol = new List<A2DSymbol>();
#endif
#if _USE_2DSYMBOLVERIFY
        private List<A2DSymbolVerify> m_lstA2DSymbolVerify = new List<A2DSymbolVerify>();
#endif
#if _USE_OCV
        private List<AOCV> m_lstAOCV = new List<AOCV>();
#endif
#if _USE_OCVMAX
        private List<AOCVMax> m_lstAOCVMax = new List<AOCVMax>();
#endif
#if _USE_OCRMAX
        private List<AOCRMax> m_lstAOCRMax = new List<AOCRMax>();
#endif
// 2016.06.21
#if _USE_FIXTURENPOINTTONPOINT
        private List<AFixtureNPointToNPoint> m_lstAFixtureNPointToNPoint = new List<AFixtureNPointToNPoint>();
#endif
#if _USE_TOOLBLOCK
        private List<AToolBlock> m_lstAToolBlock = new List<AToolBlock>();
#endif

        public string m_strLoadFileName = "";

        // 2012.01.02
        public string m_strDevName;
        // 2016.07.15 by kdi
        public string m_strPixelFormat = "";

        // 2013.02.03
        public int m_nFlipRotation;

        // 2015.10.02 by kdi. public APoint(string strPointName)
        public APoint(string strPointName, bool bAcqFifo)
        {
            m_cogtgPoint = new CogToolGroup();
            m_cogtgPoint.Name = strPointName;

            if (bAcqFifo == true)   // 2015.10.02 by kdi.
            {
                // 2014.10.30
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL && !_USE_FLIR && !_USE_1Camera)
                m_aAcqFifo = new AAcqFifo();
				// 2018.01.18 by kdi
                m_aAcqFifo.MainFrameHandle = AVisionProBuild.MainFrameHandle;
                Add("AcqFifo", m_aAcqFifo);
#endif
            }
        }

        public APoint(CogToolGroup cogtgPoint)
        {
            m_cogtgPoint = cogtgPoint;

            if (m_cogtgPoint != null)
            {
                for (int i = 0; i < m_cogtgPoint.Tools.Count; ++i)
                {
                    Type type = m_cogtgPoint.Tools[i].GetType();

                    switch (type.Name)
                    {
                        // 2014.10.30
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL && !_USE_FLIR && !_USE_1Camera)
                        case "CogAcqFifoTool":
                            m_aAcqFifo = new AAcqFifo(m_cogtgPoint.Tools[i]);
							// 2018.01.18 by kdi
                            m_aAcqFifo.MainFrameHandle = AVisionProBuild.MainFrameHandle;
                            m_lstAAcqFifo.Add(m_aAcqFifo);
                            break;
#endif
                        case "CogBlobTool":
                            m_aBlob = new ABlob(m_cogtgPoint.Tools[i]);
                            m_lstABlob.Add(m_aBlob);
                            break;
                        case "CogHistogramTool":
                            m_aHistogram = new AHistogram(m_cogtgPoint.Tools[i]);
                            m_lstAHistogram.Add(m_aHistogram);
                            break;
                        case "CogCaliperTool":
                            m_aCaliper = new ACaliper(m_cogtgPoint.Tools[i]);
                            m_lstACaliper.Add(m_aCaliper);
                            break;
                            /*
                        case "CogPMAlignTool":
                            m_aPMAlign = new APMAlign(m_cogtgPoint.Tools[i]);
                            m_lstAPMAlign.Add(m_aPMAlign);
                            break;
                            */
                        case "CogToolGroup":
                            // 2016.05.09
                            if(m_cogtgPoint.Tools[i].Name.Contains("PMAlign"))
                            {
                                m_aPMAligns = new APMAligns(m_cogtgPoint.Tools[i] as CogToolGroup);
                                m_lstAPMAligns.Add(m_aPMAligns);
                            }
#if _USE_SEARCHMAX
                            else if (m_cogtgPoint.Tools[i].Name.Contains("SearchMax"))
                            {
                                m_aSearchMaxs = new ASearchMaxs(m_cogtgPoint.Tools[i] as CogToolGroup);
                                m_lstASearchMaxs.Add(m_aSearchMaxs);
                            }
#endif
#if _USE_PMREDLINE
                            // 2019.04.21
                            else if (m_cogtgPoint.Tools[i].Name.Contains("PMRedLine"))
                            {
                                m_aPMRedLines = new APMRedLines(m_cogtgPoint.Tools[i] as CogToolGroup);
                                m_lstAPMRedLines.Add(m_aPMRedLines);
                            }
#endif
                            break;
                        case "CogCalibCheckerboardTool":
                            m_aCalibCheckerboard = new ACalibCheckerboard(m_cogtgPoint.Tools[i]);
                            m_lstACalibCheckerboard.Add(m_aCalibCheckerboard);
                            break;
                        case "CogCalibNPointToNPointTool":
                            m_aCalibNPointToNPoint = new ACalibNPointToNPoint(m_cogtgPoint.Tools[i]);
                            m_lstACalibNPointToNPoint.Add(m_aCalibNPointToNPoint);
                            break;
#if _USE_BARCODE
                        case "CogBarcodeTool":
                            m_aBarcode = new ABarcode(m_cogtgPoint.Tools[i]);
                            m_lstABarcode.Add(m_aBarcode);
                            break;
#endif
#if _USE_ID
                        case "CogIDTool":
                            m_aID = new AID(m_cogtgPoint.Tools[i]);
                            m_lstAID.Add(m_aID);
                            break;
#endif
#if _USE_FINDLINE
                        case "CogFindLineTool":
                            m_aFindLine = new AFindLine(m_cogtgPoint.Tools[i]);
                            m_lstAFindLine.Add(m_aFindLine);
                            break;
#endif
#if _USE_FINDCIRCLE
                        case "CogFindCircleTool":
                            m_aFindCircle = new AFindCircle(m_cogtgPoint.Tools[i]);
                            m_lstAFindCircle.Add(m_aFindCircle);
                            break;
#endif
#if _USE_FINDELLIPSE
                        case "CogFindEllipseTool":
                            m_aFindEllipse = new AFindEllipse(m_cogtgPoint.Tools[i]);
                            m_lstAFindEllipse.Add(m_aFindEllipse);
                            break;
#endif                            
#if _USE_FINDCORNER
                        case "CogFindCornerTool":
                            m_aFindCorner = new AFindCorner(m_cogtgPoint.Tools[i]);
                            m_lstAFindCorner.Add(m_aFindCorner);
                            break;
#endif
#if _USE_LINEMAX
                        case "CogLineMaxTool":
                            m_aLineMax = new ALineMax(m_cogtgPoint.Tools[i]);
                            m_lstALineMax.Add(m_aLineMax);
                            break;
#endif                            
#if _USE_PATINSPECT
                        case "CogPatInspectTool":
                            m_aPatInspect = new APatInspect(m_cogtgPoint.Tools[i]);
                            m_lstAPatInspect.Add(m_aPatInspect);
                            break;
#endif
/*
// 2019.05.21
#if _USE_3DPATMAX
                        case "Cog3DPatMaxTool":
                            m_a3DPatMax = new A3DPatMax(m_cogtgPoint.Tools[i]);
                            m_lstA3DPatMax.Add(m_a3DPatMax);
                            break;
#endif
*/
                        /* 2016.05.09
#if _USE_SEARCHMAX
                        case "CogSearchMaxTool":
                            m_aSearchMax = new ASearchMax(m_cogtgPoint.Tools[i]);
                            m_lstASearchMax.Add(m_aSearchMax);
                            break;
#endif
                        */
#if _USE_COLOREXTRACTOR
                        case "CogColorExtractorTool":
                            m_aColorExtractor = new AColorExtractor(m_cogtgPoint.Tools[i]);
                            m_lstAColorExtractor.Add(m_aColorExtractor);
                            break;
#endif
#if _USE_COLORMATCH
                        case "CogColorMatchTool":
                            m_aColorMatch = new AColorMatch(m_cogtgPoint.Tools[i]);
                            m_lstAColorMatch.Add(m_aColorMatch);
                            break;
#endif
#if _USE_COLORSEGMENTER
                        case "CogColorSegmenterTool":
                            m_aColorSegmenter = new AColorSegmenter(m_cogtgPoint.Tools[i]);
                            m_lstAColorSegmenter.Add(m_aColorSegmenter);
                            break;
#endif
#if _USE_COMPOSITECOLORMATCH
                        case "CogCompositeColorMatchTool":
                            m_aCompositeColorMatch = new ACompositeColorMatch(m_cogtgPoint.Tools[i]);
                            m_lstACompositeColorMatch.Add(m_aCompositeColorMatch);
                            break;
#endif

#if _USE_2DSYMBOL
                        case "Cog2DSymbolTool":
                            m_a2DSymbol = new A2DSymbol(m_cogtgPoint.Tools[i]);
                            m_lstA2DSymbol.Add(m_a2DSymbol);
                            break;
#endif
#if _USE_2DSYMBOLVERIFY
                        case "Cog2DSymbolVerifyTool":
                            m_a2DSymbolVerify = new A2DSymbolVerify(m_cogtgPoint.Tools[i]);
                            m_lstA2DSymbolVerify.Add(m_a2DSymbolVerify);
                            break;
#endif
#if _USE_OCV
                        case "CogOCVTool":
                            m_aOCV = new AOCV(m_cogtgPoint.Tools[i]);
                            m_lstAOCV.Add(m_aOCV);
                            break;
#endif
#if _USE_OCVMAX
                        case "CogOCVMaxTool":
                            m_aOCVMax = new AOCVMax(m_cogtgPoint.Tools[i]);
                            m_lstAOCVMax.Add(m_aOCVMax);
                            break;
#endif
#if _USE_OCRMAX
                        case "CogOCRMaxTool":
                            m_aOCRMax = new AOCRMax(m_cogtgPoint.Tools[i]);
                            m_lstAOCRMax.Add(m_aOCRMax);
                            break;
#endif
// 2016.06.21
#if _USE_FIXTURENPOINTTONPOINT
                        case "CogFixtureNPointToNPointTool":
                            m_aFixtureNPointToNPoint = new AFixtureNPointToNPoint(m_cogtgPoint.Tools[i]);
                            m_lstAFixtureNPointToNPoint.Add(m_aFixtureNPointToNPoint);
                            break;
#endif

// 2019.06.14
#if _USE_eCLASSIFIER
                        case "CogDataAnalysisTool":
						case "CogResultsAnalysisTool":
                            m_aeClassifier = new AeClassifier();
                            m_aeClassifier.Init(m_cogtgPoint.Tools[i].Name);
                            m_aeClassifier.Load(ASDef._INI_PATH + "\\" + m_cogtgPoint.Tools[i].Name + ".ecl");
                            break;
#endif

#if _USE_TOOLBLOCK
                        case "CogToolBlock":
                            m_aToolBlock = new AToolBlock(m_cogtgPoint.Tools[i]);
                            m_lstAToolBlock.Add(m_aToolBlock);
                            break;
#endif

                    }
                }
            }
        }
        /* 2011.06.08
        public bool IniPoint(int nFrameGrabberindex, string strVideoFormat, int nCamPort)
        {
            CogFrameGrabbers cogFrameGrabbers = new CogFrameGrabbers();

            if (cogFrameGrabbers.Count < 1)
            {
                return false;
            }
            else
            {
                m_icogFrameGrabber = cogFrameGrabbers[nFrameGrabberindex];
                m_icogAcqFifo = m_icogFrameGrabber.CreateAcqFifo(strVideoFormat, CogAcqFifoPixelFormatConstants.Format8Grey, nCamPort, true);

                return true;
            }           
        }
        */
        public Object GetTools(string strToolType)
        {
            Object lstTools = null;

            switch (strToolType)
            {
                // 2014.10.30
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL && !_USE_FLIR  && !_USE_1Camera)
                case "AcqFifo":
                    lstTools = m_lstAAcqFifo as Object;
                    break;
#endif
                case "Blob":
                    lstTools = m_lstABlob as Object;
                    break;
                case "Histogram":
                    lstTools = m_lstAHistogram as Object;
                    break;
                case "Caliper":
                    lstTools = m_lstACaliper as Object;
                    break;
                    /*
                case "PMAlign":
                    lstTools = m_lstAPMAlign as Object;
                    break;
                    */
                case "PMAligns":
                    lstTools = m_lstAPMAligns as Object;
                    break;
                case "CalibCheckerboard":
                    lstTools = m_lstACalibCheckerboard as Object;
                    break;
                case "CalibNPointToNPoint":
                    lstTools = m_lstACalibNPointToNPoint as Object;
                    break;
#if _USE_BARCODE
                case "Barcode":
                    lstTools = m_lstABarcode as Object;
                    break;
#endif
#if _USE_ID
                case "ID":
                    lstTools = m_lstAID as Object;
                    break;
#endif
#if _USE_FINDLINE
                case "FindLine":
                    lstTools = m_lstAFindLine as Object;
                    break;
#endif
#if _USE_FINDCIRCLE
                case "FindCircle":
                    lstTools = m_lstAFindCircle as Object;
                    break;
#endif
#if _USE_FINDELLIPSE
                case "FindEllipse":
                    lstTools = m_lstAFindEllipse as Object;
                    break;
#endif
#if _USE_FINDCORNER
                case "FindCorner":
                    lstTools = m_lstAFindCorner as Object;
                    break;
#endif
#if _USE_LINEMAX
                case "LineMax":
                    lstTools = m_lstALineMax as Object;
                    break;
#endif
#if _USE_PATINSPECT
                case "PatInspect":
                    lstTools = m_lstAPatInspect as Object;
                    break;
#endif
/*
// 2019.05.21
#if _USE_3DPATMAX
                case "3DPatMax":
                    lstTools = m_lstA3DPatMax as Object;
                    break;
#endif
*/
#if _USE_SEARCHMAX
                // 2016.05.09
                /*
                case "SearchMax":
                    lstTools = m_lstASearchMax as Object;
                    break;
                */
                case "SearchMaxs":
                    lstTools = m_lstASearchMaxs as Object;
                    break;
#endif
#if _USE_PMREDLINE
                // 2019.04.21
                case "PMRedLines":
                    lstTools = m_lstAPMRedLines as Object;
                    break;
#endif
#if _USE_COLOREXTRACTOR
                case "ColorExtractor":
                    lstTools = m_lstAColorExtractor as Object;
                    break;
#endif
#if _USE_COLORMATCH
                case "ColorMatch":
                    lstTools = m_lstAColorMatch as Object;
                    break;
#endif
#if _USE_COLORSEGMENTER
                case "ColorSegmenter":
                    lstTools = m_lstAColorSegmenter as Object;
                    break;
#endif
#if _USE_COMPOSITECOLORMATCH
                case "CompositeColorMatch":
                    lstTools = m_lstACompositeColorMatch as Object;
                    break;
#endif

#if _USE_2DSYMBOL
                case "2DSymbol":
                    lstTools = m_lstA2DSymbol as Object;
                    break;
#endif
#if _USE_2DSYMBOLVERIFY
                case "2DSymbolVerify":
                    lstTools = m_lstA2DSymbolVerify as Object;
                    break;
#endif
#if _USE_OCV
                case "OCV":
                    lstTools = m_lstAOCV as Object;
                    break;
#endif
#if _USE_OCVMAX
                case "OCVMax":
                    lstTools = m_lstAOCVMax as Object;
                    break;
#endif
#if _USE_OCRMAX
                case "OCRMax":
                    lstTools = m_lstAOCRMax as Object;
                    break;
#endif
// 2016.06.21
#if _USE_FIXTURENPOINTTONPOINT
                case "FixtureNPointToNPoint":
                    lstTools = m_lstAFixtureNPointToNPoint as Object;
                    break;
#endif

// 2019.06.14
#if _USE_eCLASSIFIER
                case "eClassifier":
                    lstTools = m_aeClassifier as Object;
                    break;
#endif

#if _USE_TOOLBLOCK
                case "ToolBlock":
                    lstTools = m_lstAToolBlock as Object;
                    break;
#endif
            }
            return lstTools;
        }

        public Object GetTool(string strToolType, int nIndex)
        {
            Object oTool = null;

            switch (strToolType)
            {
                    // 2014.10.30
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL && !_USE_FLIR && !_USE_1Camera)
                case "AcqFifo":
                    if (nIndex < m_lstAAcqFifo.Count)
                    {
                        oTool = m_lstAAcqFifo[nIndex];
                    }
                    break;
#endif
                case "Blob":
                    if (nIndex < m_lstABlob.Count)
                    {
                        oTool = m_lstABlob[nIndex];
                    }
                    break;
                case "Histogram":
                    if (nIndex < m_lstAHistogram.Count)
                    {
                        oTool = m_lstAHistogram[nIndex];
                    }
                    break;
                case "Caliper":
                    if (nIndex < m_lstACaliper.Count)
                    {
                        oTool = m_lstACaliper[nIndex];
                    }
                    break;
                    /*
                case "PMAlign":
                    if (nIndex < m_lstAPMAlign.Count)
                    {
                        oTool = m_lstAPMAlign[nIndex];
                    }
                    break;
                    */
                case "PMAligns":
                    if (nIndex < m_lstAPMAligns.Count)
                    {
                        oTool = m_lstAPMAligns[nIndex];
                    }
                    break;
                case "CalibCheckerboard":
                    if (nIndex < m_lstACalibCheckerboard.Count)
                    {
                        oTool = m_lstACalibCheckerboard[nIndex];
                    }
                    break;
                case "CalibNPointToNPoint":
                    if (nIndex < m_lstACalibNPointToNPoint.Count)
                    {
                        oTool = m_lstACalibNPointToNPoint[nIndex];
                    }
                    break;
#if _USE_BARCODE
                case "Barcode":
                    if (nIndex < m_lstABarcode.Count)
                    {
                        oTool = m_lstABarcode[nIndex];
                    }
                    break;
#endif
#if _USE_ID
                case "ID":
                    if (nIndex < m_lstAID.Count)
                    {
                        oTool = m_lstAID[nIndex];
                    }
                    break;
#endif
#if _USE_FINDLINE
                case "FindLine":
                    if (nIndex < m_lstAFindLine.Count)
                    {
                        oTool = m_lstAFindLine[nIndex];
                    }
                    break;
#endif
#if _USE_FINDCIRCLE
                case "FindCircle":
                    if (nIndex < m_lstAFindCircle.Count)
                    {
                        oTool = m_lstAFindCircle[nIndex];
                    }
                    break;
#endif
#if _USE_FINDELLIPSE
                case "FindEllipse":
                    if (nIndex < m_lstAFindEllipse.Count)
                    {
                        oTool = m_lstAFindEllipse[nIndex];
                    }
                    break;
#endif
#if _USE_FINDCORNER
                case "FindCorner":
                    if (nIndex < m_lstAFindCorner.Count)
                    {
                        oTool = m_lstAFindCorner[nIndex];
                    }
                    break;
#endif
#if _USE_LINEMAX
                case "LineMax":
                    if (nIndex < m_lstALineMax.Count)
                    {
                        oTool = m_lstALineMax[nIndex];
                    }
                    break;
#endif
#if _USE_PATINSPECT
                case "PatInspect":
                    if (nIndex < m_lstAPatInspect.Count)
                    {
                        oTool = m_lstAPatInspect[nIndex];
                    }
                    break;
#endif
/*
// 2019.05.21
#if _USE_3DPATMAX
                case "3DPatMax":
                    if (nIndex < m_lstA3DPatMax.Count)
                    {
                        oTool = m_lstA3DPatMax[nIndex];
                    }
                    break;
#endif
*/
#if _USE_SEARCHMAX
                // 2016.05.09
                /*
                case "SearchMax":
                    if (nIndex < m_lstASearchMax.Count)
                    {
                        oTool = m_lstASearchMax[nIndex];
                    }
                    break;
                */
                case "SearchMaxs":
                    if (nIndex < m_lstASearchMaxs.Count)
                    {
                        oTool = m_lstASearchMaxs[nIndex];
                    }
                    break;
#endif
#if _USE_PMREDLINE
                // 2019.04.21
                case "PMRedLines":
                    if (nIndex < m_lstAPMRedLines.Count)
                    {
                        oTool = m_lstAPMRedLines[nIndex];
                    }
                    break;
#endif
#if _USE_COLOREXTRACTOR
                case "ColorExtractor":
                    if (nIndex < m_lstAColorExtractor.Count)
                    {
                        oTool = m_lstAColorExtractor[nIndex];
                    }
                    break;
#endif
#if _USE_COLORMATCH
                case "ColorMatch":
                    if (nIndex < m_lstAColorMatch.Count)
                    {
                        oTool = m_lstAColorMatch[nIndex];
                    }
                    break;
#endif
#if _USE_COLORSEGMENTER
                case "ColorSegmenter":
                    if (nIndex < m_lstAColorSegmenter.Count)
                    {
                        oTool = m_lstAColorSegmenter[nIndex];
                    }
                    break;
#endif
#if _USE_COMPOSITECOLORMATCH
                case "CompositeColorMatch":
                    if (nIndex < m_lstACompositeColorMatch.Count)
                    {
                        oTool = m_lstACompositeColorMatch[nIndex];
                    }
                    break;
#endif

#if _USE_2DSYMBOL
                case "2DSymbol":
                    if (nIndex < m_lstA2DSymbol.Count)
                    {
                        oTool = m_lstA2DSymbol[nIndex];
                    }
                    break;
#endif
#if _USE_2DSYMBOLVERIFY
                case "2DSymbolVerify":
                    if (nIndex < m_lstA2DSymbolVerify.Count)
                    {
                        oTool = m_lstA2DSymbolVerify[nIndex];
                    }
                    break;
#endif
#if _USE_OCV
                case "OCV":
                    if (nIndex < m_lstAOCV.Count)
                    {
                        oTool = m_lstAOCV[nIndex];
                    }
                    break;
#endif
#if _USE_OCVMAX
                case "OCVMax":
                    if (nIndex < m_lstAOCVMax.Count)
                    {
                        oTool = m_lstAOCVMax[nIndex];
                    }
                    break;
#endif
#if _USE_OCRMAX
                case "OCRMax":
                    if (nIndex < m_lstAOCRMax.Count)
                    {
                        oTool = m_lstAOCRMax[nIndex];
                    }
                    break;
#endif
// 2016.06.21
#if _USE_FIXTURENPOINTTONPOINT
                case "FixtureNPointToNPoint":
                    if (nIndex < m_lstAFixtureNPointToNPoint.Count)
                    {
                        oTool = m_lstAFixtureNPointToNPoint[nIndex];
                    }
                    break;
#endif

// 2019.06.14
#if _USE_eCLASSIFIER
                case "eClassifier":
                    oTool = m_aeClassifier as Object;
                    break;
#endif

#if _USE_TOOLBLOCK
                case "ToolBlock":
                    if (nIndex < m_lstAToolBlock.Count)
                    {
                        oTool = m_lstAToolBlock[nIndex];
                    }
                    break;
#endif
            }
            return oTool;
        }

        public int GetToolCount(string strToolType)
        {
            int nCount = 0;

            switch (strToolType)
            {
                    // 2014.10.30
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL && !_USE_FLIR && !_USE_1Camera)
                case "AcqFifo":
                    nCount = m_lstAAcqFifo.Count;
                    break;
#endif
                case "Blob":
                    nCount = m_lstABlob.Count;
                    break;
                case "Histogram":
                    nCount = m_lstAHistogram.Count;
                    break;
                case "Caliper":
                    nCount = m_lstACaliper.Count;
                    break;
                    /*
                case "PMAlign":
                    nCount = m_lstAPMAlign.Count;
                    break;
                    */
                case "PMAligns":
                    nCount = m_lstAPMAligns.Count;
                    break;
                case "CalibCheckerboard":
                    nCount = m_lstACalibCheckerboard.Count;
                    break;
                case "CalibNPointToNPoint":
                    nCount = m_lstACalibNPointToNPoint.Count;
                    break;
#if _USE_BARCODE
                case "Barcode":
                    nCount = m_lstABarcode.Count;
                    break;
#endif
#if _USE_ID
                case "ID":
                    nCount = m_lstAID.Count;
                    break;
#endif                    
#if _USE_FINDLINE
                case "FindLine":
                    nCount = m_lstAFindLine.Count;
                    break;
#endif
#if _USE_FINDCIRCLE
                case "FindCircle":
                    nCount = m_lstAFindCircle.Count;
                    break;
#endif
#if _USE_FINDELLIPSE
                case "FindEllipse":
                    nCount = m_lstAFindEllipse.Count;
                    break;
#endif
#if _USE_FINDCORNER
                case "FindCorner":
                    nCount = m_lstAFindCorner.Count;
                    break;
#endif
#if _USE_LINEMAX
                case "LineMax":
                    nCount = m_lstALineMax.Count;
                    break;
#endif
#if _USE_PATINSPECT
                case "PatInspect":
                    nCount = m_lstAPatInspect.Count;
                    break;
#endif
/*
                // 2019.05.21
#if _USE_3DPATMAX
                case "3DPatMax":
                    nCount = m_lstA3DPatMax.Count;
                    break;
#endif
*/
#if _USE_SEARCHMAX
                // 2016.05.09
                /*
                case "SearchMax":
                    nCount = m_lstASearchMax.Count;
                    break;
                */
                case "SearchMaxs":
                    nCount = m_lstASearchMaxs.Count;
                    break;
#endif
#if _USE_PMREDLINE
                // 2019.04.21
                case "PMRedLines":
                    nCount = m_lstAPMRedLines.Count;
                    break;
#endif
#if _USE_COLOREXTRACTOR
                case "ColorExtractor":
                    nCount = m_lstAColorExtractor.Count;
                    break;
#endif
#if _USE_COLORMATCH
                case "ColorMatch":
                    nCount = m_lstAColorMatch.Count;
                    break;
#endif
#if _USE_COLORSEGMENTER
                case "ColorSegmenter":
                    nCount = m_lstAColorSegmenter.Count;
                    break;
#endif
#if _USE_COMPOSITECOLORMATCH
                case "CompositeColorMatch":
                    nCount = m_lstACompositeColorMatch.Count;
                    break;
#endif

#if _USE_2DSYMBOL
                case "2DSymbol":
                    nCount = m_lstA2DSymbol.Count;
                    break;
#endif
#if _USE_2DSYMBOLVERIFY
                case "2DSymbolVerify":
                    nCount = m_lstA2DSymbolVerify.Count;
                    break;
#endif
#if _USE_OCV
                case "OCV":
                    nCount = m_lstAOCV.Count;
                    break;
#endif
#if _USE_OCVMAX
                case "OCVMax":
                    nCount = m_lstAOCVMax.Count;
                    break;
#endif
#if _USE_OCRMAX
                case "OCRMax":
                    nCount = m_lstAOCRMax.Count;
                    break;
#endif
// 2016.06.21
#if _USE_FIXTURENPOINTTONPOINT
                case "FixtureNPointToNPoint":
                    nCount = m_lstAFixtureNPointToNPoint.Count;
                    break;
#endif
#if _USE_TOOLBLOCK
                case "ToolBlock":
                    nCount = m_lstAToolBlock.Count;
                    break;
#endif
            }
            return nCount;
        }

        public Object GetToolGroupPoint()
        {
            return m_cogtgPoint;
        }

        public string Name
        {
            get { return m_cogtgPoint.Name; }
            set { m_cogtgPoint.Name = value.ToString(); }
        }

        private void AddTool(Object oTool)
        {
            m_cogtgPoint.Tools.Add(oTool as ICogTool);
        }
         
        private void RemoveTool(Object oTool)
        {
            m_cogtgPoint.Tools.Remove(oTool as ICogTool);
        }

        public void Remove(string strName, Object oTool)
        {
            switch (strName)
            {
                case "Blob":
                    m_aBlob = oTool as ABlob;
                    m_lstABlob.Remove(m_aBlob);
                    RemoveTool(m_aBlob.GetTool());
                    break;
                case "Histogram":
                    m_aHistogram = oTool as AHistogram;
                    m_lstAHistogram.Remove(m_aHistogram);
                    RemoveTool(m_aHistogram.GetTool());
                    break;
                case "Caliper":
                    m_aCaliper = oTool as ACaliper;
                    m_lstACaliper.Remove(m_aCaliper);
                    RemoveTool(m_aCaliper.GetTool());
                    break;
                case "PMAligns":
                    m_aPMAligns = oTool as APMAligns;
                    m_lstAPMAligns.Remove(m_aPMAligns);
                    RemoveTool(m_aPMAligns.GetTool());
                    break;
                case "CalibCheckerboard":
                    m_aCalibCheckerboard = oTool as ACalibCheckerboard;
                    m_lstACalibCheckerboard.Remove(m_aCalibCheckerboard);
                    RemoveTool(m_aCalibCheckerboard.GetTool());
                    break;
                case "CalibNPointToNPoint":
                    m_aCalibNPointToNPoint = oTool as ACalibNPointToNPoint;
                    m_lstACalibNPointToNPoint.Remove(m_aCalibNPointToNPoint);
                    RemoveTool(m_aCalibNPointToNPoint.GetTool());
                    break;
#if _USE_BARCODE
                case "Barcode":
                    m_aBarcode = oTool as ABarcode;
                    m_lstABarcode.Remove(m_aBarcode);
                    RemoveTool(m_aBarcode.GetTool());
                    break;
#endif
#if _USE_ID
                case "ID":
                    m_aID = oTool as AID;
                    m_lstAID.Remove(m_aID);
                    RemoveTool(m_aID.GetTool());
                    break;
#endif                    
#if _USE_FINDLINE
                case "FindLine":
                    m_aFindLine = oTool as AFindLine;
                    m_lstAFindLine.Remove(m_aFindLine);
                    RemoveTool(m_aFindLine.GetTool());
                    break;
#endif
#if _USE_FINDCIRCLE
                case "FindCircle":
                    m_aFindCircle = oTool as AFindCircle;
                    m_lstAFindCircle.Remove(m_aFindCircle);
                    RemoveTool(m_aFindCircle.GetTool());
                    break;
#endif
#if _USE_FINDELLIPSE
                case "FindEllipse":
                    m_aFindEllipse = oTool as AFindEllipse;
                    m_lstAFindEllipse.Remove(m_aFindEllipse);
                    RemoveTool(m_aFindEllipse.GetTool());
                    break;
#endif
#if _USE_FINDCORNER
                case "FindCorner":
                    m_aFindCorner = oTool as AFindCorner;
                    m_lstAFindCorner.Remove(m_aFindCorner);
                    RemoveTool(m_aFindCorner.GetTool());
                    break;
#endif
#if _USE_LINEMAX
                case "LineMax":
                    m_aLineMax = oTool as ALineMax;
                    m_lstALineMax.Remove(m_aLineMax);
                    RemoveTool(m_aLineMax.GetTool());
                    break;
#endif
#if _USE_PATINSPECT
                case "PatInspect":
                    m_aPatInspect = oTool as APatInspect;
                    m_lstAPatInspect.Remove(m_aPatInspect);
                    RemoveTool(m_aPatInspect.GetTool());
                    break;
#endif
/*
// 2019.05.21
#if _USE_3DPATMAX
                case "3DPatMax":
                    m_a3DPatMax = oTool as A3DPatMax;
                    m_lstA3DPatMax.Remove(m_a3DPatMax);
                    RemoveTool(m_a3DPatMax.GetTool());
                    break;
#endif
*/
#if _USE_SEARCHMAX
                // 2016.05.09
                /*
                case "SearchMax":
                    m_aSearchMax = oTool as ASearchMax;
                    m_lstASearchMax.Remove(m_aSearchMax);
                    RemoveTool(m_aSearchMax.GetTool());
                    break;
                */
                case "SearchMaxs":
                    m_aSearchMaxs = oTool as ASearchMaxs;
                    m_lstASearchMaxs.Remove(m_aSearchMaxs);
                    RemoveTool(m_aSearchMaxs.GetTool());
                    break;
#endif
#if _USE_PMREDLINE
                // 2019.04.21
                case "PMRedLines":
                    m_aPMRedLines = oTool as APMRedLines;
                    m_lstAPMRedLines.Remove(m_aPMRedLines);
                    RemoveTool(m_aPMRedLines.GetTool());
                    break;
#endif
#if _USE_COLOREXTRACTOR
                case "ColorExtractor":
                    m_aColorExtractor = oTool as AColorExtractor;
                    m_lstAColorExtractor.Remove(m_aColorExtractor);
                    RemoveTool(m_aColorExtractor.GetTool());
                    break;
#endif
#if _USE_COLORMATCH
                case "ColorMatch":
                    m_aColorMatch = oTool as AColorMatch;
                    m_lstAColorMatch.Remove(m_aColorMatch);
                    RemoveTool(m_aColorMatch.GetTool());
                    break;
#endif
#if _USE_COLORSEGMENTER
                case "ColorSegmenter":
                    m_aColorSegmenter = oTool as AColorSegmenter;
                    m_lstAColorSegmenter.Remove(m_aColorSegmenter);
                    RemoveTool(m_aColorSegmenter.GetTool());
                    break;
#endif
#if _USE_COMPOSITECOLORMATCH
                case "CompositeColorMatch":
                    m_aCompositeColorMatch = oTool as ACompositeColorMatch;
                    m_lstACompositeColorMatch.Remove(m_aCompositeColorMatch);
                    RemoveTool(m_aCompositeColorMatch.GetTool());
                    break;
#endif

#if _USE_2DSYMBOL
                case "2DSymbol":
                    m_a2DSymbol = oTool as A2DSymbol;
                    m_lstA2DSymbol.Remove(m_a2DSymbol);
                    RemoveTool(m_a2DSymbol.GetTool());
                    break;
#endif
#if _USE_2DSYMBOLVERIFY
                case "2DSymbolVerify":
                    m_a2DSymbolVerify = oTool as A2DSymbolVerify;
                    m_lstA2DSymbolVerify.Remove(m_a2DSymbolVerify);
                    RemoveTool(m_a2DSymbolVerify.GetTool());
                    break;
#endif
#if _USE_OCV
                case "OCV":
                    m_aOCV = oTool as AOCV;
                    m_lstAOCV.Remove(m_aOCV);
                    RemoveTool(m_aOCV.GetTool());
                    break;
#endif
#if _USE_OCVMAX
                case "OCVMax":
                    m_aOCVMax = oTool as AOCVMax;
                    m_lstAOCVMax.Remove(m_aOCVMax);
                    RemoveTool(m_aOCVMax.GetTool());
                    break;
#endif
#if _USE_OCRMAX
                case "OCRMax":
                    m_aOCRMax = oTool as AOCRMax;
                    m_lstAOCRMax.Remove(m_aOCRMax);
                    RemoveTool(m_aOCRMax.GetTool());
                    break;
#endif
// 2016.06.21
#if _USE_FIXTURENPOINTTONPOINT
                case "FixtureNPointToNPoint":
                    m_aFixtureNPointToNPoint = oTool as AFixtureNPointToNPoint;
                    m_lstAFixtureNPointToNPoint.Remove(m_aFixtureNPointToNPoint);
                    RemoveTool(m_aFixtureNPointToNPoint.GetTool());
                    break;
#endif
#if _USE_TOOLBLOCK
                case "ToolBlock":
                    m_aToolBlock = oTool as AToolBlock;
                    m_lstAToolBlock.Remove(m_aToolBlock);
                    RemoveTool(m_aToolBlock.GetTool());
                    break;
#endif
            }
        }
        public void Add(string strName, Object oTool)
        {
            switch (strName)
            {
                    // 2014.10.30
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL && !_USE_FLIR && !_USE_1Camera)
                case "AcqFifo":
                    m_aAcqFifo = oTool as AAcqFifo;
                    m_lstAAcqFifo.Add(m_aAcqFifo);
                    AddTool(m_aAcqFifo.GetTool());
                    break;
#endif
                case "Blob":
                    m_aBlob = oTool as ABlob;
                    m_lstABlob.Add(m_aBlob);
                    AddTool(m_aBlob.GetTool());
                    break;
                case "Histogram":
                    m_aHistogram = oTool as AHistogram;
                    m_lstAHistogram.Add(m_aHistogram);
                    AddTool(m_aHistogram.GetTool());
                    break;
                case "Caliper":
                    m_aCaliper = oTool as ACaliper;
                    m_lstACaliper.Add(m_aCaliper);
                    AddTool(m_aCaliper.GetTool());
                    break;
                case "PMAligns":
                    m_aPMAligns = oTool as APMAligns;
                    m_lstAPMAligns.Add(m_aPMAligns);
                    AddTool(m_aPMAligns.GetTool());
                    break;
                case "CalibCheckerboard":
                    m_aCalibCheckerboard = oTool as ACalibCheckerboard;
                    m_lstACalibCheckerboard.Add(m_aCalibCheckerboard);
                    AddTool(m_aCalibCheckerboard.GetTool());
                    break;
                case "CalibNPointToNPoint":
                    m_aCalibNPointToNPoint = oTool as ACalibNPointToNPoint;
                    m_lstACalibNPointToNPoint.Add(m_aCalibNPointToNPoint);
                    AddTool(m_aCalibNPointToNPoint.GetTool());
                    break;
#if _USE_BARCODE
                case "Barcode":
                    m_aBarcode = oTool as ABarcode;
                    m_lstABarcode.Add(m_aBarcode);
                    AddTool(m_aBarcode.GetTool());
                    break;
#endif
#if _USE_ID
                case "ID":
                    m_aID = oTool as AID;
                    m_lstAID.Add(m_aID);
                    AddTool(m_aID.GetTool());
                    break;
#endif
#if _USE_FINDLINE
                case "FindLine":
                    m_aFindLine = oTool as AFindLine;
                    m_lstAFindLine.Add(m_aFindLine);
                    AddTool(m_aFindLine.GetTool());
                    break;
#endif
#if _USE_FINDCIRCLE
                case "FindCircle":
                    m_aFindCircle = oTool as AFindCircle;
                    m_lstAFindCircle.Add(m_aFindCircle);
                    AddTool(m_aFindCircle.GetTool());
                    break;
#endif
#if _USE_FINDELLIPSE
                case "FindEllipse":
                    m_aFindEllipse = oTool as AFindEllipse;
                    m_lstAFindEllipse.Add(m_aFindEllipse);
                    AddTool(m_aFindEllipse.GetTool());
                    break;
#endif
#if _USE_FINDCORNER
                case "FindCorner":
                    m_aFindCorner = oTool as AFindCorner;
                    m_lstAFindCorner.Add(m_aFindCorner);
                    AddTool(m_aFindCorner.GetTool());
                    break;
#endif
#if _USE_LINEMAX
                case "LineMax":
                    m_aLineMax = oTool as ALineMax;
                    m_lstALineMax.Add(m_aLineMax);
                    AddTool(m_aLineMax.GetTool());
                    break;
#endif
#if _USE_PATINSPECT
                case "PatInpsect":
                    m_aPatInspect = oTool as APatInspect;
                    m_lstAPatInspect.Add(m_aPatInspect);
                    AddTool(m_aPatInspect.GetTool());
                    break;
#endif
/*
// 2019.05.21
#if _USE_3DPATMAX
                case "3DPatMax":
                    m_a3DPatMax = oTool as A3DPatMax;
                    m_lstA3DPatMax.Add(m_a3DPatMax);
                    AddTool(m_a3DPatMax.GetTool());
                    break;
#endif
*/
#if _USE_SEARCHMAX
                // 2016.05.09
                /*
                case "SearchMax":
                    m_aSearchMax = oTool as ASearchMax;
                    m_lstASearchMax.Add(m_aSearchMax);
                    AddTool(m_aSearchMax.GetTool());
                    break;
                */
                case "SearchMaxs":
                    m_aSearchMaxs = oTool as ASearchMaxs;
                    m_lstASearchMaxs.Add(m_aSearchMaxs);
                    AddTool(m_aSearchMaxs.GetTool());
                    break;
#endif
#if _USE_PMREDLINE
                // 2019.04.21
                case "PMRedLines":
                    m_aPMRedLines = oTool as APMRedLines;
                    m_lstAPMRedLines.Add(m_aPMRedLines);
                    AddTool(m_aPMRedLines.GetTool());
                    break;
#endif
#if _USE_COLOREXTRACTOR
                case "ColorExtractor":
                    m_aColorExtractor = oTool as AColorExtractor;
                    m_lstAColorExtractor.Add(m_aColorExtractor);
                    AddTool(m_aColorExtractor.GetTool());
                    break;
#endif
#if _USE_COLORMATCH
                case "ColorMatch":
                    m_aColorMatch = oTool as AColorMatch;
                    m_lstAColorMatch.Add(m_aColorMatch);
                    AddTool(m_aColorMatch.GetTool());
                    break;
#endif
#if _USE_COLORSEGMENTER
                case "ColorSegmenter":
                    m_aColorSegmenter = oTool as AColorSegmenter;
                    m_lstAColorSegmenter.Add(m_aColorSegmenter);
                    AddTool(m_aColorSegmenter.GetTool());
                    break;
#endif
#if _USE_COMPOSITECOLORMATCH
                case "CompositeColorMatch":
                    m_aCompositeColorMatch = oTool as ACompositeColorMatch;
                    m_lstACompositeColorMatch.Add(m_aCompositeColorMatch);
                    AddTool(m_aCompositeColorMatch.GetTool());
                    break;
#endif

#if _USE_2DSYMBOL
                case "2DSymbol":
                    m_a2DSymbol = oTool as A2DSymbol;
                    m_lstA2DSymbol.Add(m_a2DSymbol);
                    AddTool(m_a2DSymbol.GetTool());
                    break;
#endif
#if _USE_2DSYMBOLVERIFY
                case "2DSymbolVerify":
                    m_a2DSymbolVerify = oTool as A2DSymbolVerify;
                    m_lstA2DSymbolVerify.Add(m_a2DSymbolVerify);
                    AddTool(m_a2DSymbolVerify.GetTool());
                    break;
#endif
#if _USE_OCV
                case "OCV":
                    m_aOCV = oTool as AOCV;
                    m_lstAOCV.Add(m_aOCV);
                    AddTool(m_aOCV.GetTool());
                    break;
#endif
#if _USE_OCVMAX
                case "OCVMax":
                    m_aOCVMax = oTool as AOCVMax;
                    m_lstAOCVMax.Add(m_aOCVMax);
                    AddTool(m_aOCVMax.GetTool());
                    break;
#endif
#if _USE_OCRMAX
                case "OCRMax":
                    m_aOCRMax = oTool as AOCRMax;
                    m_lstAOCRMax.Add(m_aOCRMax);
                    AddTool(m_aOCRMax.GetTool());
                    break;
#endif
// 2016.06.21
#if _USE_FIXTURENPOINTTONPOINT
                case "FixtureNPointToNPoint":
                    m_aFixtureNPointToNPoint = oTool as AFixtureNPointToNPoint;
                    m_lstAFixtureNPointToNPoint.Add(m_aFixtureNPointToNPoint);
                    AddTool(m_aFixtureNPointToNPoint.GetTool());
                    break;
#endif
#if _USE_TOOLBLOCK
                case "ToolBlock":
                    m_aToolBlock = oTool as AToolBlock;
                    m_lstAToolBlock.Add(m_aToolBlock);
                    AddTool(m_aToolBlock.GetTool());
                    break;
#endif
            }
        }
        // 2012.01.17
        public ICogImage RunCalibImage(ICogImage icogImgInput, string strCalibCase)
        {
            ICogImage icogImgOutput;

            icogImgOutput = icogImgInput;

            switch(strCalibCase)
            {
                case "No Calib":
                    return icogImgOutput;
                case "Checkerboard":
                    if (m_lstACalibCheckerboard.Count < 1)
                        return icogImgOutput;
                    if (m_aCalibCheckerboard.Calibrated == false)
                        return icogImgOutput;
                    m_aCalibCheckerboard.GetTool().InputImage = icogImgInput;
                    // 2015.04.08
                    m_aCalibCheckerboard.m_bRan = false;

                    m_aCalibCheckerboard.GetTool().Run();
                    // 2015.04.08
                    m_aCalibCheckerboard.WaitRanEvent();

                    icogImgOutput = m_aCalibCheckerboard.GetTool().OutputImage;
                    break;
                case "NPointToNPoint":
                    if (m_lstACalibNPointToNPoint.Count < 1)
                        return icogImgOutput;
                    if (m_aCalibNPointToNPoint.Calibrated == false)
                        return icogImgOutput;
                    m_aCalibNPointToNPoint.GetTool().InputImage = icogImgInput;
                    // 2015.04.08
                    m_aCalibNPointToNPoint.m_bRan = false;

                    m_aCalibNPointToNPoint.GetTool().Run();
                    // 2015.04.08
                    m_aCalibNPointToNPoint.WaitRanEvent();

                    icogImgOutput = m_aCalibNPointToNPoint.GetTool().OutputImage;
                    break;
            }

            return icogImgOutput;
        }

        // 2016.12.02
        public int TransCalibrated2UncalibratedCoord(string strCalibCase, double calibratedX, double calibratedY, out double uncalibratedX, out double uncalibratedY)
        {
            uncalibratedX = 0;
            uncalibratedY = 0;

            switch (strCalibCase)
            {
                case "No Calib":
                    uncalibratedX = calibratedX;
                    uncalibratedY = calibratedY;
                    return 1;
                case "Checkerboard":
                    if (m_lstACalibCheckerboard.Count < 1)
                        return -1;
                    if (m_aCalibCheckerboard.Calibrated == false)
                        return -2;
                    m_aCalibCheckerboard.TransCalibrated2UncalibratedCoord(calibratedX, calibratedY, out uncalibratedX, out uncalibratedY);
                    return 1;
                case "NPointToNPoint":
                    if (m_lstACalibNPointToNPoint.Count < 1)
                        return -1;
                    if (m_aCalibNPointToNPoint.Calibrated == false)
                        return -2;
                    m_aCalibNPointToNPoint.TransCalibrated2UncalibratedCoord(calibratedX, calibratedY, out uncalibratedX, out uncalibratedY);
                    return 1;
            }

            return 0;
        }

        public void TransCalibrated2UncalibratedCoord(string strCalibCase, ICogRegion region, out CogRectangle box)
        {
            box = new CogRectangle();
            if (region != null && (strCalibCase == "NPointToNPoint" || strCalibCase == "No Calib"))
            {
                double[] pdX = new double[4];
                double[] pdY = new double[4];
                double x, y;
                int i;
                TransCalibrated2UncalibratedCoord(strCalibCase,
                    region.EnclosingRectangle(CogCopyShapeConstants.All).X,
                    region.EnclosingRectangle(CogCopyShapeConstants.All).Y,
                    out pdX[0], out pdY[0]);
                TransCalibrated2UncalibratedCoord(strCalibCase,
                    region.EnclosingRectangle(CogCopyShapeConstants.All).X + region.EnclosingRectangle(CogCopyShapeConstants.All).Width,
                    region.EnclosingRectangle(CogCopyShapeConstants.All).Y,
                    out pdX[1], out pdY[1]);
                TransCalibrated2UncalibratedCoord(strCalibCase,
                    region.EnclosingRectangle(CogCopyShapeConstants.All).X + region.EnclosingRectangle(CogCopyShapeConstants.All).Width,
                    region.EnclosingRectangle(CogCopyShapeConstants.All).Y + region.EnclosingRectangle(CogCopyShapeConstants.All).Height,
                    out pdX[2], out pdY[2]);
                TransCalibrated2UncalibratedCoord(strCalibCase,
                    region.EnclosingRectangle(CogCopyShapeConstants.All).X,
                    region.EnclosingRectangle(CogCopyShapeConstants.All).Y + region.EnclosingRectangle(CogCopyShapeConstants.All).Height,
                    out pdX[3], out pdY[3]);
                x = pdX[0];
                y = pdY[0];
                for (i = 1; i < 4; i++)
                {
                    x = Math.Min(x, pdX[i]);
                    y = Math.Min(y, pdY[i]);
                }
                box.X = x;
                box.Y = y;
                x = pdX[0];
                y = pdY[0];
                for (i = 1; i < 4; i++)
                {
                    x = Math.Max(x, pdX[i]);
                    y = Math.Max(y, pdY[i]);
                }
                box.Width = x - box.X;
                box.Height = y - box.Y;
            }
            else
                box = null;
        }

        // 2013.09.09
        public ICogImage GetCalibInputImage(string strCalibCase)
        {
            ICogImage icogImgOutput =null;
            switch (strCalibCase)
            {
                case "No Calib":
                    return null;
                case "Checkerboard":
                    if (m_lstACalibCheckerboard.Count < 1)
                        return icogImgOutput;
                    if (m_aCalibCheckerboard.Calibrated == false)
                        return icogImgOutput;
                    icogImgOutput = m_aCalibCheckerboard.GetTool().InputImage;
                    break;
                case "NPointToNPoint":
                    if (m_lstACalibNPointToNPoint.Count < 1)
                        return icogImgOutput;
                    if (m_aCalibNPointToNPoint.Calibrated == false)
                        return icogImgOutput;
                    icogImgOutput = m_aCalibNPointToNPoint.GetTool().InputImage;
                    break;
            }
            return icogImgOutput;
        }
        /*
        public void RunCalibImage(ADisplay aDisplay, string strCalibCase)
        {
            ICogImage icogImgOutput;

            icogImgOutput = aDisplay.Image;

            switch (strCalibCase)
            {
                case "No Calib":
                    break;
                case "Checkerboard":
                    if (m_lstACalibCheckerboard.Count < 1)
                        return;
                    if (m_aCalibCheckerboard.Calibrated == false)
                        return;
                    m_aCalibCheckerboard.GetTool().InputImage = aDisplay.Image;
                    m_aCalibCheckerboard.GetTool().Run();
                    icogImgOutput = m_aCalibCheckerboard.GetTool().OutputImage;
                    break;
                case "NPointToNPoint":
                    if (m_lstACalibNPointToNPoint.Count < 1)
                        return;
                    if (m_aCalibNPointToNPoint.Calibrated == false)
                        return;
                    m_aCalibNPointToNPoint.GetTool().InputImage = aDisplay.Image;
                    m_aCalibNPointToNPoint.GetTool().Run();
                    icogImgOutput = m_aCalibNPointToNPoint.GetTool().OutputImage;
                    break;
            }

            aDisplay.Image = icogImgOutput;
        }
        */
        public bool IsCalib(string strCalibCase)
        {
            switch (strCalibCase)
            {
                case "No Calib":
                    return false;
                case "Checkerboard":
                    if (m_lstACalibCheckerboard.Count < 1)
                        return false;
                    if (m_lstACalibCheckerboard[0].Calibrated == false)
                        return false;
                    break;
                case "NPointToNPoint":
                    if (m_lstACalibNPointToNPoint.Count < 1)
                        return false;
                    if (m_lstACalibNPointToNPoint[0].Calibrated == false)
                        return false;
                    break;
            }

            return true;
        }
        // 2014.10.30
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL && !_USE_FLIR && !_USE_1Camera)
        public AAcqFifo GetAcq()
        {
            return m_aAcqFifo;
        }
#endif

// 2016.06.20
//#if !_USE_1Camera
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL && !_USE_FLIR && !_USE_1Camera)
        // 2015.10.02 by kdi
        public void SetAcqFifo(CogToolGroup cogtgPoint)
        {
            CogToolGroup cogtgTempPoint = cogtgPoint;

            if (m_cogtgPoint != null)
            {
                for (int i = 0; i < cogtgTempPoint.Tools.Count; ++i)
                {
                    Type type = cogtgTempPoint.Tools[i].GetType();

                    switch (type.Name)
                    {
                        case "CogAcqFifoTool":
                            m_aAcqFifo = new AAcqFifo(cogtgTempPoint.Tools[i]);
							// 2018.01.18 by kdi
                            m_aAcqFifo.MainFrameHandle = AVisionProBuild.MainFrameHandle;
                            m_lstAAcqFifo.Add(m_aAcqFifo);
                            break;
                    }
                }
            }
        }
#endif
    }
}
