// 2018.01.18 by kdi #define _USE_BASLER_PYLON
//#define _USE_IMAGING_CONTROL
//#define _USE_FLIR
// 2014.10.30
//#define _USE_1Camera
// 2015.01.01
//#define _TYPE_SORT
// 2016.08.01
#define _USE_FIXTURENPOINTTONPOINT
// 2019.04.21
#define _VPRO9_6

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.Display;
using Cognex.VisionPro.ToolGroup;
using Cognex.VisionPro.ImageProcessing;
using Atmc;

using Cognex.VisionPro;
using System.Windows.Forms;
using System.Drawing;
// 2015.07.20
using System.Drawing.Imaging;

// 2020.03.03
using Cognex.VisionPro.CalibFix;

#if _USE_BASLER_PYLON
using BaslerPylon;
#elif _USE_IMAGING_CONTROL
using ImagingControl;
#elif _USE_FLIR
using FLIR_Camera;
#endif



namespace AVisionPro
{    
    // 2015.04.08
    public class ACogToolBase
    {
        // 2015.04.08
        public bool m_bRan = false;
        public void RanEvent(object sender, EventArgs e)
        {
            m_bRan = true;
        }
        public void WaitRanEvent()
        {
            DateTime oldDateTime = DateTime.Now;
            while (m_bRan == false)
            {
                // 2015.04.13
                //Application.DoEvents();

                TimeSpan span = DateTime.Now - oldDateTime;
                if (span.TotalMilliseconds > 100)
                    break;

                System.Threading.Thread.Sleep(1);
            }
        }
    }

    public class AVisionProBuild
    {
        public enum _emRegionShape { Entire = 0, Circle, Ellipse, Rectangle, RectangleAffine, CircularAnnulusSection, EllipticalAnnulusSection };

        public static CogImageFile m_cogImageFile = new CogImageFile();
        public static List<ADisplay> m_lstDisplay = new List<ADisplay>();
        public static List<AType> m_lstAType = new List<AType>();
        public static int m_nFileCount = 0;
        public static int m_nFileAmount = 0;
        public static string[] m_pstrName;
        public static string m_strIDB = "";
        public static string m_strResultPath;

        public static bool m_bAuto = false;
        
        public static int m_nTypeCount;

        // 2011.06.23
        public static CogToolGroup m_cogtgTmp;

        // 2015.12.07 by kdi
        public static bool m_bExistInvalidCamera = false;

		// 2018.01.18 by kdi
        private static IntPtr m_MainFrameHandle;
        public static IntPtr MainFrameHandle
        {
            get { return m_MainFrameHandle; }
            set { m_MainFrameHandle = value; }
        }

        // 2020.03.03
        private static CogFixtureTool m_FixtureTool = new CogFixtureTool();

        // 2014.10.30
#if _USE_1Camera
        private static AAcqFifo m_aAcqFifo = null;
		// 2018.01.18 by kdi
        public static AAcqFifo AcqFifo
        {
            get { return m_aAcqFifo; }
        }

        //private static ICogAcqFifo m_CogAcqFifo = null;
        //public static ICogAcqFifo CogAcqFifo
        //{
        //    get { return m_CogAcqFifo; }
        //    set { m_CogAcqFifo = value; }
        //}
#endif

        // 2015.04.01
        public struct _stPreprocess
        {
            public int nLow;
            public int nHigh;
            public int nValue;
        }

        // 2015.04.10
        public static AThrdLogWriter m_aThrdLogWriter = null;
                
        public static string GetTypeName(int nType)
        {
            // 2013.08.24 32->255
            StringBuilder sb = new StringBuilder(255);

            AUtil.GetPrivateProfileString("Name", "Type" + nType.ToString(), nType.ToString(), sb, 255, ASDef._INI_FILE);
            return sb.ToString();
        }
         
        public static APoint GetPoint(int nType, int nPoint)
        {
            return GetType(nType).GetPoint(nPoint);
        }

        public static string GetResultFName(bool bOK_NG, int nType, int nPoint, string strName)
        {
            string strFName, strDate, strDateTime;

            strDate = DateTime.Now.ToString("yyyy_MM_dd");
            strDateTime = DateTime.Now.ToString("yyyy_MM_dd_HHmmss");

            strFName = m_strResultPath;
            /* 2014.07.17
            if (!Directory.Exists(strFName))
            {
                // 2013.11.22
                try
                {
                    Directory.CreateDirectory(strFName);
                }
                catch
                {
                }
                
            }
            */
            if (bOK_NG)
                strFName += "\\OK";
            else
                strFName += "\\NG";
            /* 2014.07.17
            if (!Directory.Exists(strFName))
            {
                // 2013.11.22
                try
                {
                    Directory.CreateDirectory(strFName);
                }
                catch
                {
                }
            }
            */
            strFName += "\\" + strDate;
            /* 2014.07.17
            if (!Directory.Exists(strFName))
            {
                // 2013.11.22
                try
                {
                    Directory.CreateDirectory(strFName);
                }
                catch
                {
                }
            }
            */
            strFName += "\\" + AVisionProBuild.GetTypeName(nType);
            /* 2014.07.17
            if (!Directory.Exists(strFName))
            {
                // 2013.11.22
                try
                {
                    Directory.CreateDirectory(strFName);
                }
                catch
                {
                }
            }
            */
            strFName += "\\" + AVisionProBuild.GetPoint(nType, nPoint).Name;
            if (!Directory.Exists(strFName))
            {
                // 2013.11.22
                try
                {
                    Directory.CreateDirectory(strFName);
                }
                catch
                {
                }
            }

            strFName += "\\" + strDateTime + strName + ".bmp";

            return strFName;
        }

        // 2014.11.12
        public static string GetResultFName(bool bOK_NG, int nType, int nPoint, string strDateTime, string strName)
        {
            string strFName, strDate; //, strDateTime;

            strDate = DateTime.Now.ToString("yyyy_MM_dd");
            //strDateTime = DateTime.Now.ToString("yyyy_MM_dd_HHmmss");

            strFName = m_strResultPath;
            /* 2014.07.17
            if (!Directory.Exists(strFName))
            {
                // 2013.11.22
                try
                {
                    Directory.CreateDirectory(strFName);
                }
                catch
                {
                }
                
            }
            */
            if (bOK_NG)
                strFName += "\\OK";
            else
                strFName += "\\NG";
            /* 2014.07.17
            if (!Directory.Exists(strFName))
            {
                // 2013.11.22
                try
                {
                    Directory.CreateDirectory(strFName);
                }
                catch
                {
                }
            }
            */
            strFName += "\\" + strDate;
            /* 2014.07.17
            if (!Directory.Exists(strFName))
            {
                // 2013.11.22
                try
                {
                    Directory.CreateDirectory(strFName);
                }
                catch
                {
                }
            }
            */
            strFName += "\\" + AVisionProBuild.GetTypeName(nType);
            /* 2014.07.17
            if (!Directory.Exists(strFName))
            {
                // 2013.11.22
                try
                {
                    Directory.CreateDirectory(strFName);
                }
                catch
                {
                }
            }
            */
            strFName += "\\" + AVisionProBuild.GetPoint(nType, nPoint).Name;
            if (!Directory.Exists(strFName))
            {
                // 2013.11.22
                try
                {
                    Directory.CreateDirectory(strFName);
                }
                catch
                {
                }
            }

            strFName += "\\" + strDateTime + strName + ".bmp";

            return strFName;
        }

        // 2014.11.18
        public static int FindResultFName(int nType, int nPoint, string strDateTime, ref string[] pstrResultFName)
        {
            int nCount = 0;
            bool bFind = false;
            string strFName, strDate;

            strDate = strDateTime.Substring(0, 10);
            strFName = m_strResultPath;
            strFName += "\\NG";
            strFName += "\\" + strDate;
            strFName += "\\" + AVisionProBuild.GetTypeName(nType);
            strFName += "\\" + AVisionProBuild.GetPoint(nType, nPoint).Name;

            if (Directory.Exists(strFName))
            {
                string[] pstrName;
                int i;

                pstrName = Directory.GetFiles(strFName);
                int nFileAmount = pstrName.Length;
                strFName = "";
                for(i=0;i<nFileAmount;i++)
                {
                    if (pstrName[i].Contains(strDateTime) == true)
                    {
                        bFind = true;
                        pstrResultFName[nCount] = pstrName[i];
                        nCount++;                        
                    }
                    else
                    {
                        if (bFind == true)
                            break;
                    }
                }
            }

            bFind = false;
            strFName = m_strResultPath;
            strFName += "\\OK";
            strFName += "\\" + strDate;
            strFName += "\\" + AVisionProBuild.GetTypeName(nType);
            strFName += "\\" + AVisionProBuild.GetPoint(nType, nPoint).Name;

            if (Directory.Exists(strFName))
            {
                string[] pstrName;
                int i;

                pstrName = Directory.GetFiles(strFName);
                int nFileAmount = pstrName.Length;
                strFName = "";
                for (i = 0; i < nFileAmount; i++)
                {
                    if (pstrName[i].Contains(strDateTime) == true)
                    {
                        bFind = true;
                        pstrResultFName[nCount] = pstrName[i];
                        nCount++;
                    }
                    else
                    {
                        if (bFind == true)
                            break;
                    }
                }
            }

            return nCount;
        }

        // 2014.11.18
        public static int FindResultFName(int nType, int nPoint, string strDateTime, ref string strResultFName)
        {
            string strFName, strDate;

            strDate = strDateTime.Substring(0, 10);
            strFName = m_strResultPath;
            strFName += "\\NG";
            strFName += "\\" + strDate;
            strFName += "\\" + AVisionProBuild.GetTypeName(nType);
            strFName += "\\" + AVisionProBuild.GetPoint(nType, nPoint).Name;

            if (Directory.Exists(strFName))
            {
                string[] pstrName;
                int i;

                pstrName = Directory.GetFiles(strFName);
                int nFileAmount = pstrName.Length;
                strFName = "";
                for (i = 0; i < nFileAmount; i++)
                {
                    if (pstrName[i].Contains(strDateTime) == true)
                    {
                        strResultFName = pstrName[i];
                        return 1;
                    }
                }
            }

            strFName = m_strResultPath;
            strFName += "\\OK";
            strFName += "\\" + strDate;
            strFName += "\\" + AVisionProBuild.GetTypeName(nType);
            strFName += "\\" + AVisionProBuild.GetPoint(nType, nPoint).Name;

            if (Directory.Exists(strFName))
            {
                string[] pstrName;
                int i;

                pstrName = Directory.GetFiles(strFName);
                int nFileAmount = pstrName.Length;
                strFName = "";
                for (i = 0; i < nFileAmount; i++)
                {
                    if (pstrName[i].Contains(strDateTime) == true)
                    {
                        strResultFName = pstrName[i];
                        return 1;
                    }
                }
            }

            return 0;
        }

        public static string GetTotalFName(bool bOK_NG, string strName)
        {
            string strFName, strDate, strDateTime;

            strDate = DateTime.Now.ToString("yyyy_MM_dd");
            strDateTime = DateTime.Now.ToString("yyyy_MM_dd_HHmmss");

            strFName = m_strResultPath;
            /* 2014.07.17
            if (!Directory.Exists(strFName))
            {
                // 2013.11.22
                try
                {
                    Directory.CreateDirectory(strFName);
                }
                catch
                {
                }
            }
            */
            if (bOK_NG)
                strFName += "\\TotalOK";
            else
                strFName += "\\TotalNG";
            /* 2014.07.17
            if (!Directory.Exists(strFName))
            {
                // 2013.11.22
                try
                {
                    Directory.CreateDirectory(strFName);
                }
                catch
                {
                }
            }
            */
            strFName += "\\" + strDate;
            if (!Directory.Exists(strFName))
            {
                // 2013.11.22
                try
                {
                    Directory.CreateDirectory(strFName);
                }
                catch
                {
                }
            }            
            
            strFName += "\\" + strDateTime + strName + ".jpg";

            return strFName;
        }

        // 2013.12.24
        public static string GetTotalFNamePass(string strName)
        {
            string strFName, strDate, strDateTime;

            strDate = DateTime.Now.ToString("yyyy_MM_dd");
            strDateTime = DateTime.Now.ToString("yyyy_MM_dd_HHmmss");

            strFName = m_strResultPath;
            /*
            if (!Directory.Exists(strFName))
            {
                // 2013.11.22
                try
                {
                    Directory.CreateDirectory(strFName);
                }
                catch
                {
                }
            }
            */
            strFName += "\\TotalPass";
            /* 2014.07.17
            if (!Directory.Exists(strFName))
            {
                // 2013.11.22
                try
                {
                    Directory.CreateDirectory(strFName);
                }
                catch
                {
                }
            }
            */
            strFName += "\\" + strDate;            
            if (!Directory.Exists(strFName))
            {
                // 2013.11.22
                try
                {
                    Directory.CreateDirectory(strFName);
                }
                catch
                {
                }
            }

            strFName += "\\" + strDateTime + strName + ".jpg";

            return strFName;
        }

        // 2015.04.10
        /*
        public static void WriteLogFile(string strData)
        {
            DateTime dt = DateTime.Now;
            StreamWriter sw = null;
            try
            {
                string strYMD = dt.Year.ToString() + dt.Month.ToString().PadLeft(2, '0');

                string strFName = m_strResultPath;
                strFName += "\\Log";
                strFName += "\\" + dt.ToString("yyyy_MM");                
                if (!Directory.Exists(strFName))
                {
                    try
                    {
                        Directory.CreateDirectory(strFName);
                    }
                    catch
                    {
                    }
                }

                strFName += "\\" + dt.ToString("yyyy_MM_dd") + ".txt";


                sw = new StreamWriter(strFName, true);
                sw.WriteLine(dt.ToString("HH:mm:ss.fff") + "  " + strData);
            }
            catch { }
            finally
            {
                if (sw != null)
                {
                    sw.Flush();
                    sw.Close();
                }
            }
        }

        // 2013.07.28
        public static void WriteLogFile(string strData, string strExt)
        {
            DateTime dt = DateTime.Now;
            StreamWriter sw = null;
            try
            {
                string strYMD = dt.Year.ToString() + dt.Month.ToString().PadLeft(2, '0');

                string strFName = m_strResultPath;
                strFName += "\\Log";
                strFName += "\\" + dt.ToString("yyyy_MM");
                if (!Directory.Exists(strFName))
                {
                    // 2013.11.22
                    try
                    {
                        Directory.CreateDirectory(strFName);
                    }
                    catch
                    {
                    }
                }

                // 2014.07.17
                if (strExt.Contains("."))
                    strFName += "\\" + dt.ToString("yyyy_MM_dd") + strExt;
                else
                    strFName += "\\" + dt.ToString("yyyy_MM_dd") + "." + strExt;


                sw = new StreamWriter(strFName, true);
                // 2015.02.27
                sw.WriteLine(dt.ToString("HH:mm:ss.fff") + "  " + strData);
            }
            catch { }
            finally
            {
                if (sw != null)
                {
                    sw.Flush();
                    sw.Close();
                }
            }
        }
        */
        // 2015.04.10
        public static void WriteLogFile(string strData)
        {
            WriteLogFile(strData, "");
        }
        // 2015.04.10
        public static void WriteLogFile(string strData, string strExt)
        {
            if (m_aThrdLogWriter == null)
                return;

            ALogInfo ALog = new ALogInfo();

            ALog.m_dtDateTime = DateTime.Now;
            ALog.m_strData = strData;
            ALog.m_strFileExt = strExt;

            // 2015.04.16
            m_aThrdLogWriter.ResultPath = m_strResultPath;

            m_aThrdLogWriter.AddLog(ALog);
        }
                
        // 2012.01.17
        public static bool LoadImg(string strImgName, ref ICogImage cogImage)
        {
            if (File.Exists(strImgName))
            {
                // 2011.05.07
                try
                {
                    // 2014.11.12
                    //m_nFileCount = 0;

                    m_cogImageFile.Open(strImgName, CogImageFileModeConstants.Read);
                    cogImage = m_cogImageFile[0];
                    if (m_cogImageFile.Count > 1)
                    {
                        m_strIDB = strImgName;
                    }
                    else
                    {
                        m_strIDB = "";
                    }
                    m_cogImageFile.Close();

                    return true;
                }
                catch { }
            }

            return false;
        }

        /*
        public static bool LoadImg(string strImgName, CogDisplay cogDisplay)
        {
            if (File.Exists(strImgName))
            {
                // 2011.05.07
                try
                {
                    m_nFileCount = 0;
                    m_cogImageFile.Open(strImgName, CogImageFileModeConstants.Read);
                    cogDisplay.Image = m_cogImageFile[0];
                    if (m_cogImageFile.Count > 1)
                    {
                        m_strIDB = strImgName;
                    }
                    else
                    {
                        m_strIDB = "";
                    }
                    m_cogImageFile.Close();

                    return true;
                }
                catch { }
            }

            return false;
        }

        public static bool LoadImg(string strBmpName, ADisplay aDisplay)
        {
            return LoadImg(strBmpName, aDisplay.m_cogDisplay);
        }
        */
        // 2012.01.17
        public static bool LoadGrayImg(string strImgName, ref ICogImage cogImage)
        {
            if (File.Exists(strImgName))
            {
                // 2011.05.07
                try
                {
                    // 2014.11.12
                    //m_nFileCount = 0;

                    m_cogImageFile.Open(strImgName, CogImageFileModeConstants.Read);

                    //cogDisplay.Image = m_cogImageFile[0];
                    cogImage = CogImageConvert.GetIntensityImage(m_cogImageFile[0], 0, 0, m_cogImageFile[0].Width, m_cogImageFile[0].Height);

                    if (m_cogImageFile.Count > 1)
                    {
                        m_strIDB = strImgName;
                    }
                    else
                    {
                        m_strIDB = "";
                    }
                    m_cogImageFile.Close();

                    return true;
                }
                catch { }
            }

            return false;
        }
        /*
        // 2011.12.30
        public static bool LoadGrayImg(string strImgName, CogDisplay cogDisplay)
        {
            if (File.Exists(strImgName))
            {
                // 2011.05.07
                try
                {
                    m_nFileCount = 0;
                    m_cogImageFile.Open(strImgName, CogImageFileModeConstants.Read);

                    //cogDisplay.Image = m_cogImageFile[0];
                    cogDisplay.Image = CogImageConvert.GetIntensityImage(m_cogImageFile[0], 0, 0, m_cogImageFile[0].Width, m_cogImageFile[0].Height);

                    if (m_cogImageFile.Count > 1)
                    {
                        m_strIDB = strImgName;
                    }
                    else
                    {
                        m_strIDB = "";
                    }
                    m_cogImageFile.Close();

                    return true;
                }
                catch { }
            }

            return false;
        }
        // 2011.12.30
        public static bool LoadGrayImg(string strBmpName, ADisplay aDisplay)
        {
            return LoadGrayImg(strBmpName, aDisplay.m_cogDisplay);
        }
        */
        // 2012.01.17
        public static string LoadDir(string strDirName, ref ICogImage cogImage)
        {
            m_nFileCount = 0;

            if (Directory.Exists(strDirName))
            {
                m_pstrName = Directory.GetFiles(strDirName);
                m_nFileAmount = m_pstrName.Length;

                if (m_nFileAmount > 0)
                {
                    try
                    {
                        m_cogImageFile.Open(m_pstrName[0], CogImageFileModeConstants.Read);
                        cogImage = m_cogImageFile[0];
                        m_cogImageFile.Close();

                        return m_pstrName[0];
                    }
                    catch { }
                }
            }

            return "";
        }
        /*
        public static string LoadDir(string strDirName, CogDisplay cogDisplay)
        {
            m_nFileCount = 0;

            if (Directory.Exists(strDirName))
            {
                m_pstrName = Directory.GetFiles(strDirName);
                m_nFileAmount = m_pstrName.Length;

                if (m_nFileAmount > 0)
                {
                    try
                    {
                        m_cogImageFile.Open(m_pstrName[0], CogImageFileModeConstants.Read);
                        cogDisplay.Image = m_cogImageFile[0];
                        m_cogImageFile.Close();

                        return m_pstrName[0];
                    }
                    catch { }
                }
            }

            return "";
        }
        */
        // 2012.01.17
        public static string NextImg(ref ICogImage cogImage)
        {
            int nMax = m_nFileAmount;
            // 2011.06.09
            m_nFileCount++;
            if (m_nFileAmount > 0 && m_nFileCount < m_nFileAmount && m_nFileCount >= 0)
            {
                try
                {
                    m_cogImageFile.Open(m_pstrName[m_nFileCount], CogImageFileModeConstants.Read);
                    cogImage = m_cogImageFile[0];
                    m_cogImageFile.Close();

                    return m_pstrName[m_nFileCount];
                }
                catch { }
            }
            else if (m_strIDB != "")
            {
                try
                {

                    m_cogImageFile.Open(m_strIDB, CogImageFileModeConstants.Read);
                    nMax = m_cogImageFile.Count;
                    // 2011.06.09
                    if (m_cogImageFile.Count > 0 && m_nFileCount < m_cogImageFile.Count && m_nFileCount >= 0)
                    {
                        cogImage = m_cogImageFile[m_nFileCount];
                        m_cogImageFile.Close();
                        // 2011.06.09
                        return m_strIDB;
                    }

                }
                catch { }
            }

            if (m_nFileCount > nMax)
                m_nFileCount = nMax;

            return "";
        }
        /*
        public static string NextImg(CogDisplay cogDisplay)
        {
            int nMax = m_nFileAmount;
            // 2011.06.09
            m_nFileCount++;
            if (m_nFileAmount > 0 && m_nFileCount < m_nFileAmount && m_nFileCount >= 0)
            {                
                try
                {
                    m_cogImageFile.Open(m_pstrName[m_nFileCount], CogImageFileModeConstants.Read);
                    cogDisplay.Image = m_cogImageFile[0];
                    m_cogImageFile.Close();

                    return m_pstrName[m_nFileCount];
                }
                catch { }
            }
            else if (m_strIDB != "")
            {
                try
                {
                    
                    m_cogImageFile.Open(m_strIDB, CogImageFileModeConstants.Read);
                    nMax = m_cogImageFile.Count;
                    // 2011.06.09
                    if (m_cogImageFile.Count > 0 && m_nFileCount < m_cogImageFile.Count && m_nFileCount >= 0)
                    {
                        cogDisplay.Image = m_cogImageFile[m_nFileCount];
                        m_cogImageFile.Close();
                        // 2011.06.09
                        return m_strIDB;
                    }
                    
                }
                catch { }
            }

            if (m_nFileCount > nMax)
                m_nFileCount = nMax;

            return "";
        }
        */
        // 2012.01.17
        public static string BeforeImg(ref ICogImage cogImage)
        {
            m_nFileCount--;
            if (m_nFileAmount > 0 && m_nFileCount < m_nFileAmount && m_nFileCount >= 0)
            {

                try
                {
                    m_cogImageFile.Open(m_pstrName[m_nFileCount], CogImageFileModeConstants.Read);
                    cogImage = m_cogImageFile[0];
                    m_cogImageFile.Close();

                    return m_pstrName[m_nFileCount];
                }
                catch { }
            }
            else if (m_strIDB != "")
            {
                try
                {
                    m_cogImageFile.Open(m_strIDB, CogImageFileModeConstants.Read);
                    if (m_cogImageFile.Count > 0 && m_nFileCount < m_cogImageFile.Count && m_nFileCount >= 0)
                    {
                        cogImage = m_cogImageFile[m_nFileCount];
                        m_cogImageFile.Close();

                        return m_strIDB;

                    }

                }
                catch { }
            }

            if (m_nFileCount < -1)
                m_nFileCount = -1;

            return "";
        }
        /*
        // 2011.06.09
        public static string BeforeImg(CogDisplay cogDisplay)
        {
            m_nFileCount--;
            if (m_nFileAmount > 0 && m_nFileCount < m_nFileAmount && m_nFileCount >= 0)
            {
                
                try
                {
                    m_cogImageFile.Open(m_pstrName[m_nFileCount], CogImageFileModeConstants.Read);
                    cogDisplay.Image = m_cogImageFile[0];
                    m_cogImageFile.Close();

                    return m_pstrName[m_nFileCount];
                }
                catch { }
            }
            else if (m_strIDB != "")
            {
                try
                {
                    m_cogImageFile.Open(m_strIDB, CogImageFileModeConstants.Read);
                    if (m_cogImageFile.Count > 0 && m_nFileCount < m_cogImageFile.Count && m_nFileCount >= 0 )
                    {
                        cogDisplay.Image = m_cogImageFile[m_nFileCount];
                        m_cogImageFile.Close();

                        return m_strIDB;

                    }
                    
                }
                catch { }
            }

            if (m_nFileCount < -1)
                m_nFileCount = -1;

            return "";
        }
        */
        // 2012.01.17
        public static bool SaveImg(string strImgName, ICogImage cogImage)            
        {
            // 2015.10.18
            //lock (m_cogImageFile)
            {
                try
                {
					// 2018.01.18 by kdi
                    CogImageFile cogImageFile = new CogImageFile();
                    cogImageFile.Open(strImgName, CogImageFileModeConstants.Write);
                    cogImageFile.Append(cogImage);
                    cogImageFile.Close();
                    return true;
                }
                // 2016.07.04
                catch (Exception ex)
                {
                    // 2015.10.18
                    WriteLogFile("SaveImg Err (" + strImgName + ")" + ex.Message, ".Err.txt");

                    return false;
                }
            }
        }
        /*
        public static bool SaveImg(string strImgName, CogDisplay cogDisplay)
        {
            // 2011.07.19
            lock (m_cogImageFile)
            {
                try
                {
                    m_cogImageFile.Open(strImgName, CogImageFileModeConstants.Write);
                    m_cogImageFile.Append(cogDisplay.Image);
                    m_cogImageFile.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
        
        public static bool SaveImg(string strImgName, ADisplay aDisplay)
        {
            return SaveImg(strImgName, aDisplay.m_cogDisplay);
        }
        */

        public static void RemoveImg(string strImgName)
        {
            if (File.Exists(strImgName))
            {
                FileInfo file = new FileInfo(strImgName);
                file.Delete();
            }
        }

        public static void RenameImg(string strImgPreviousName, string strImgNewName)
        {
            if (File.Exists(strImgPreviousName))
            {
                FileInfo file = new FileInfo(strImgPreviousName);
                file.CopyTo(strImgNewName, true);
                RemoveImg(strImgPreviousName);
            }
        }

        // 2017.06.27
        public static void RotateBitmap(int nRotateType, ref Bitmap bitmap)
        {
            /*
            None = 0
            Rotate90Deg = 1
            Rotate180Deg = 2
            Rotate270Deg = 3
            Flip = 4
            FlipAndRotate90Deg = 5
            FlipAndRotate180Deg = 6
            FlipAndRotate270Deg = 7
            */
            switch(nRotateType)
            {
                case 1:
                    bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    break;
                case 2:
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    break;
                case 3:
                    bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    break;
                case 4:
                    bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
                    break;
                case 5:
                    bitmap.RotateFlip(RotateFlipType.Rotate90FlipX);
                    break;
                case 6:
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
                    break;
                case 7:
                    bitmap.RotateFlip(RotateFlipType.Rotate270FlipX);
                    break;
            }
        }

        public static void Init()
        {
            // 2016.03.09
            if (ASDef._LANGUAGE == "kor")
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ko");
                Cognex.VisionPro.CogLocalizer.SetVisionProCulture();
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
                Cognex.VisionPro.CogLocalizer.SetVisionProCulture();
            }
            
            m_nTypeCount = AUtil.GetPrivateProfileInt("Type", "Count", 1, ASDef._INI_FILE);

            string strTypeName;
            for (int i = 0; i < m_nTypeCount; ++i)
            {
                strTypeName = GetTypeName(i);
                AType aType = new AType(strTypeName);
                m_lstAType.Add(aType);

            }


            // 2015.01.01
#if _TYPE_SORT
            StringCompare sc = new StringCompare();
            m_lstAType.Sort(sc);
#endif

            if (!Directory.Exists(ASDef._INI_PATH))
            {
                // 2013.11.22
                try
                {
                    Directory.CreateDirectory(ASDef._INI_PATH);
                }
                catch
                {
                }
            }
            if (!Directory.Exists(ASDef._INI_PATH + "\\Img"))
            {
                // 2013.11.22
                try
                {
                    Directory.CreateDirectory(ASDef._INI_PATH + "\\Img");
                }
                catch
                {
                }
            }

            StringBuilder sb = new StringBuilder(256);
            AUtil.GetPrivateProfileString("PATH", "ResultPath", "C:\\RESULT", sb, 256, ASDef._INI_FILE);
            m_strResultPath = sb.ToString();

            // 2014.10.30
#if _USE_1Camera
            // 2019.06.14
			// 2018.01.18 by kdi
            if (File.Exists(ASDef._INI_PATH + "\\1Camera.vpp"))
                m_aAcqFifo = new AAcqFifo(CogSerializer.LoadObjectFromFile(ASDef._INI_PATH + "\\1Camera.vpp") as CogAcqFifoTool);
            else
                m_aAcqFifo = new AAcqFifo();            
            //m_aAcqFifo = new AAcqFifo();
            m_aAcqFifo.MainFrameHandle = m_MainFrameHandle;
#endif
            // 2015.04.16
            m_aThrdLogWriter = new AThrdLogWriter();
            m_aThrdLogWriter.ResultPath = m_strResultPath;
        }

        // 2015.04.16
        public static void Close()
        {
            m_cogImageFile.Close();

            if (m_aThrdLogWriter != null)
                m_aThrdLogWriter.Close();
        }

        public static bool SaveVpp(int nTypeCount)
        {
            return m_lstAType[nTypeCount].SaveVpp();
        }

        public static void AddType(string strTypeName, int nPointCount)
        {
            AType aType = new AType(strTypeName, nPointCount);
            m_lstAType.Add(aType);

            // 2015.01.01
#if _TYPE_SORT
            StringCompare sc = new StringCompare();
            m_lstAType.Sort(sc);
#endif
        }

        public static void RemoveType(string strTypeName)
        {
            AType aType = GetType(strTypeName);

            m_lstAType.Remove(aType);
        }

        public static int GetTypeCount()
        {
            return m_lstAType.Count;
        }

        public static AType GetType(int nIndex)
        {
            return m_lstAType[nIndex];
        }

        public static AType GetType(string strTypeName)
        {
            for (int i = 0; i < GetTypeCount(); ++i)
            {
                AType aType = GetType(i);
                if (aType.Name == strTypeName)
                {
                    return aType;
                }
            }

            return null;
        }

        public static void SaveType()
        {
            AUtil.WritePrivateProfileString("Type", "Count", m_nTypeCount.ToString(), ASDef._INI_FILE);
        
            for(int i=0;i<m_nTypeCount;i++)
            {
                AUtil.WritePrivateProfileString("Name", "Type" + i.ToString(), m_lstAType[i].Name, ASDef._INI_FILE);
            }
        }

#if _USE_1Camera
        // 2018.01.18 by kdi
        public static void SetSection(int nSection)
        {
            m_aAcqFifo.Section = nSection;
        }
#endif

        public static string MakeName(string strTool, DateTime dateTime)
        {
            // 2011.05.27 fff
            return strTool + dateTime.ToString("_yyyy-MM-dd_HHmmssfff");
        }

        public static string ToolName(int nType, int nPoint, string strTool)
        {
            return GetTypeName(nType) + "_Point" + nPoint.ToString() + "_" + strTool;
        }

        public static bool Auto // set auto run
        {
            get { return m_bAuto; }
            set
            {
                m_bAuto = (bool)value;
            }
        }

        public static void AddDisplay(CogDisplay Display, string strDisplayName)
        {
            m_lstDisplay.Add(new ADisplay(Display, strDisplayName));
        }

        public static int GetDisplayCount()
        {
            return m_lstDisplay.Count;
        }

        public static ADisplay GetDisplay(int nIndex)
        {
            return m_lstDisplay[nIndex];
        }

        public static string GetDisplayName(int nIndex)
        {
            return GetDisplay(nIndex).m_strName;
        }
        // 2014.10.30
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL && !_USE_FLIR && !_USE_1Camera)

        // 2018.04.10
        private static bool CheckCameraDevName(int nType, int nPoint)
        {
            // 2019.04.29 마CTO
            // KMS CPAD 패턴 Reload 후 여기서 이상발생
            // 잠시 작동하지 못하게 막음
            return true;
            /*
            APoint aPoint = GetPoint(nType, nPoint);

            ICogAcqFifo cogAcqFifo = null;

            if (aPoint.aAcqFifo.AcqFifoTool != null)
            {
                if (aPoint.aAcqFifo.AcqFifoTool.Operator != null)
                {
                    if (aPoint.aAcqFifo.AcqFifoTool.Operator.FrameGrabber != null)
                    {
                        // 2018.07.28
                        if (aPoint.aAcqFifo.AcqFifoTool.Operator.FrameGrabber.OwnedGigEAccess != null)
                        {

                            if (aPoint.aAcqFifo.AcqFifoTool.Operator.FrameGrabber.SerialNumber == aPoint.m_strDevName)
                            {
                                cogAcqFifo = clsCamera.GetAcqFifo(aPoint.m_strDevName);
                                if (cogAcqFifo != null)
                                {
                                    if (cogAcqFifo.OutputPixelFormat != aPoint.aAcqFifo.AcqFifoTool.Operator.OutputPixelFormat)
                                        aPoint.aAcqFifo.AcqFifoTool.Operator = cogAcqFifo;
                                }
                                return true;

                            }

                        }
                        else
                            return true;

                    }
                }
            }
            cogAcqFifo = clsCamera.GetAcqFifo(aPoint.m_strDevName);

            // 2018.04.03
            if (cogAcqFifo != null)
            {
                aPoint.aAcqFifo.AcqFifoTool.Operator = cogAcqFifo;
                return true;
            }
            else
            {
                return false;
            }
            */
        }

        // 2019.05.21
        public static void Acq(int nType, int nPoint, ref ICogVisionData cogVisionData)
        {
            APoint aPoint = GetPoint(nType, nPoint);
            aPoint.GetAcq().Run(ref cogVisionData);
        }

        // 2012.01.17
        public static void Acq(int nType, int nPoint, ref ICogImage cogImage)
        {
            // 2018.04.10
            if (CheckCameraDevName(nType, nPoint) == false)
            {
                cogImage = null;
                return;
            }

            APoint aPoint = GetPoint(nType, nPoint);
            // 2013.02.03
            aPoint.GetAcq().Run(ref cogImage, aPoint.m_nFlipRotation);
        }
        public static void Acq(int nType, int nPoint, double dExposure, ref ICogImage cogImage)
        {
            // 2018.04.10
            if (CheckCameraDevName(nType, nPoint) == false)
            {
                cogImage = null;
                return;
            }

            APoint aPoint = GetPoint(nType, nPoint);
            aPoint.GetAcq().Exposure = dExposure;

            // 2013.02.03
            aPoint.GetAcq().Run(ref cogImage, aPoint.m_nFlipRotation);
        }
        public static void Acq(int nType, int nPoint, double dExposure, double dContrast, ref ICogImage cogImage)
        {
            // 2018.04.10
            if (CheckCameraDevName(nType, nPoint) == false)
            {
                cogImage = null;
                return;
            }

            APoint aPoint = GetPoint(nType, nPoint);
            aPoint.GetAcq().Exposure = dExposure;
            aPoint.GetAcq().Contrast = dContrast;

            // 2013.02.03
            aPoint.GetAcq().Run(ref cogImage, aPoint.m_nFlipRotation);
        }
        public static void Acq(int nType, int nPoint, double dExposure, double dContrast, double dBrightness, ref ICogImage cogImage)
        {
            // 2018.04.10
            if (CheckCameraDevName(nType, nPoint) == false)
            {
                cogImage = null;
                return;
            }

            APoint aPoint = GetPoint(nType, nPoint);
            aPoint.GetAcq().Exposure = dExposure;
            aPoint.GetAcq().Contrast = dContrast;
            aPoint.GetAcq().Brightness = dBrightness;

            // 2013.02.03
            aPoint.GetAcq().Run(ref cogImage, aPoint.m_nFlipRotation);
        }
        // 2012.04.25
#elif _USE_BASLER_PYLON
        public static void Acq(int nType, int nPoint, ref ICogImage cogImage)
        {
            APoint aPoint = GetPoint(nType, nPoint);

            Bitmap Bmp = null;
            if (ABaslerPylon.Run(aPoint.m_strDevName, ref Bmp))
            {
                // 2017.06.27
                if (Bmp == null)
                {
                    cogImage = null;
                    return;
                }
                // 이미지 회전
                RotateBitmap(aPoint.m_nFlipRotation, ref Bmp);

                ICogImage cogImageBmp;

                // 2017.06.27
                /*
                if ((Bmp.Flags & (16 | 32 | 64 | 128 | 256)) != 0)
                    cogImageBmp = new CogImage24PlanarColor(Bmp);
                else
                    cogImageBmp = new CogImage8Grey(Bmp);
                */
                if (Bmp.PixelFormat == PixelFormat.Format8bppIndexed)
                    cogImageBmp = new CogImage8Grey(Bmp);
                else
                    cogImageBmp = new CogImage24PlanarColor(Bmp);
                /*
                // 2013.02.03
                if (aPoint.m_nFlipRotation >= 4)
                    LoadGrayImgFlipRotation(cogImageBmp, ref cogImage, aPoint.m_nFlipRotation - 4);
                else
                    LoadGrayImgFlipRotation(cogImageBmp, ref cogImage, aPoint.m_nFlipRotation);
                */
                cogImage = cogImageBmp;
                if (Bmp != null)
                {
                    Bmp.Dispose();
                    Bmp = null;
                }

            }
            else
            {
                cogImage = null;
            }
        }
        public static void Acq(int nType, int nPoint, double dExposure, ref ICogImage cogImage)
        {
            APoint aPoint = GetPoint(nType, nPoint);

            Int64 nVal = Convert.ToInt64(dExposure);
            ABaslerPylon.SetExposureTime(aPoint.m_strDevName, nVal);

            Acq(nType, nPoint, ref cogImage);
        }
        public static void Acq(int nType, int nPoint, double dExposure, double dContrast, ref ICogImage cogImage)
        {
            Acq(nType, nPoint, dExposure, ref cogImage);
        }
        public static void Acq(int nType, int nPoint, double dExposure, double dContrast, double dBrightness, ref ICogImage cogImage)
        {
            Acq(nType, nPoint, dExposure, ref cogImage);
        }
        // 2012.04.25
#elif _USE_IMAGING_CONTROL
        public static void Acq(int nType, int nPoint, ref ICogImage cogImage)
        {
            // 2013.02.03
            APoint aPoint = GetPoint(nType, nPoint);

            Bitmap Bmp = null;
            cogImage = null;
            if (AImagingControl.Run(ref Bmp))
            {   
                // 2017.06.27
                if (Bmp == null)
                {
                    cogImage = null;
                    return;
                }
                // 이미지 회전
                RotateBitmap(aPoint.m_nFlipRotation, ref Bmp);

                ICogImage cogImageBmp;
                // 2017.06.27
                /*
                if ((Bmp.Flags & (16 | 32 | 64 | 128 | 256)) != 0)
                    cogImageBmp = new CogImage24PlanarColor(Bmp);
                else
                    cogImageBmp = new CogImage8Grey(Bmp);
                */
                if (Bmp.PixelFormat == PixelFormat.Format8bppIndexed)
                    cogImageBmp = new CogImage8Grey(Bmp);
                else
                    cogImageBmp = new CogImage24PlanarColor(Bmp);
                /*
                // 2013.02.03
                LoadGrayImgFlipRotation(cogImageBmp, ref cogImage, aPoint.m_nFlipRotation);
                */
                cogImage = cogImageBmp;
                if (Bmp != null)
                {
                    Bmp.Dispose();
                    Bmp = null;
                }
            }
        }
        public static void Acq(int nType, int nPoint, double dExposure, ref ICogImage cogImage)
        {
            AImagingControl.m_rngpExposure.Value = Convert.ToInt32(dExposure);

            Acq(nType, nPoint, ref cogImage);            
        }
        public static void Acq(int nType, int nPoint, double dExposure, double dContrast, ref ICogImage cogImage)
        {
            AImagingControl.m_rngpExposure.Value = Convert.ToInt32(dExposure);
            
            Acq(nType, nPoint, ref cogImage);
        }

        public static void Acq(int nType, int nPoint, double dExposure, double dContrast, double dBrightness, ref ICogImage cogImage)
        {
            AImagingControl.m_rngpExposure.Value = Convert.ToInt32(dExposure);
            AImagingControl.m_rngpBrightness.Value = Convert.ToInt32(dBrightness);

            Acq(nType, nPoint, ref cogImage);
        }
#elif _USE_FLIR
        public static void Acq(int nType, int nPoint, ref ICogImage cogImage)
        {
            APoint aPoint = GetPoint(nType, nPoint);

            if (!AFLIR_Camera.StartAcquisition())
            {
                cogImage = null;
                return;
            }

            if (!AFLIR_Camera.GetRawData())
            {
                cogImage = null;
                return;
            }

            Bitmap Bmp = null;
            if (AFLIR_Camera.IsGrayImage)
                Bmp = AFLIR_Camera.CreateBitmap_8(320, 256, AFLIR_Camera.ImageData);
            else
                Bmp = AFLIR_Camera.CreateBitmap(320, 256, AFLIR_Camera.ImageData, 0);
        
            // 취득 정지
            AFLIR_Camera.StopAcquisition();

            GC.Collect();

            // 2017.06.27
            if (Bmp == null)
            {
                cogImage = null;
                return;
            }
            // 이미지 회전
            RotateBitmap(aPoint.m_nFlipRotation, ref Bmp);

            ICogImage cogImageBmp;
            // 2017.06.27
            /*
            if ((Bmp.Flags & (16 | 32 | 64 | 128 | 256)) != 0)
                cogImageBmp = new CogImage24PlanarColor(Bmp);
            else
                cogImageBmp = new CogImage8Grey(Bmp);
            */
            if (Bmp.PixelFormat == PixelFormat.Format8bppIndexed)
                cogImageBmp = new CogImage8Grey(Bmp);
            else
                cogImageBmp = new CogImage24PlanarColor(Bmp);
            /*
            // 2013.02.03
            LoadGrayImgFlipRotation(cogImageBmp, ref cogImage, aPoint.m_nFlipRotation);
            */
            cogImage = cogImageBmp;
            if (Bmp != null)
            {
                Bmp.Dispose();
                Bmp = null;
            }
            
        }
        public static void Acq(int nType, int nPoint, double dExposure, ref ICogImage cogImage)
        {
            Acq(nType, nPoint, ref cogImage);
        }
        public static void Acq(int nType, int nPoint, double dExposure, double dContrast, ref ICogImage cogImage)
        {
            Acq(nType, nPoint, dExposure, ref cogImage);
        }
        public static void Acq(int nType, int nPoint, double dExposure, double dContrast, double dBrightness, ref ICogImage cogImage)
        {
            Acq(nType, nPoint, dExposure, ref cogImage);
        }
// 2014.10.30
#elif _USE_1Camera
        // 2014.11.04
        public static void Acq(ref ICogImage cogImage)
        {
            m_aAcqFifo.Run(ref cogImage, 0);
        }

        public static void Acq(int nType, int nPoint, ref ICogImage cogImage)
        {
            APoint aPoint = GetPoint(nType, nPoint);
            m_aAcqFifo.Run(ref cogImage, aPoint.m_nFlipRotation);
        }
        public static void Acq(int nType, int nPoint, double dExposure, ref ICogImage cogImage)
        {
            APoint aPoint = GetPoint(nType, nPoint);
            m_aAcqFifo.Exposure = dExposure;
            m_aAcqFifo.Run(ref cogImage, aPoint.m_nFlipRotation);
        }
        public static void Acq(int nType, int nPoint, double dExposure, double dContrast, ref ICogImage cogImage)
        {
            APoint aPoint = GetPoint(nType, nPoint);
            m_aAcqFifo.Exposure = dExposure;
            m_aAcqFifo.Contrast = dContrast;
            m_aAcqFifo.Run(ref cogImage, aPoint.m_nFlipRotation);
        }
        public static void Acq(int nType, int nPoint, double dExposure, double dContrast, double dBrightness, ref ICogImage cogImage)
        {
            APoint aPoint = GetPoint(nType, nPoint);
            m_aAcqFifo.Exposure = dExposure;
            m_aAcqFifo.Contrast = dContrast;
            m_aAcqFifo.Brightness = dBrightness;
            m_aAcqFifo.Run(ref cogImage, aPoint.m_nFlipRotation);
        }
#endif

        // 2016.06.20
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL && !_USE_FLIR)
        public static double GetExposure(int nType, int nPoint)
        {
#if _USE_1Camera
            return m_aAcqFifo.Exposure;
#else
            APoint aPoint = GetPoint(nType, nPoint);
            return aPoint.GetAcq().Exposure;
#endif
        }
#endif

        // 2011.06.23
        public static void LoadVpp(string strVppName)
        {
            try
            {
                m_cogtgTmp = CogSerializer.LoadObjectFromFile(strVppName) as Cognex.VisionPro.ToolGroup.CogToolGroup;
            }
            catch
            {
                // 2014.07.15
                AUtil.TopMostMessageBox.Show(strVppName + " File Load Error!");
            }
        }

        
        // 2012.04.25
        public static int LoadGrayImgFlipRotation(ICogImage cogImageSou, ref ICogImage cogImageDes, int nFlipRotation)
        {
            try
            {
                if (nFlipRotation == 0)
                {
                    cogImageDes = CogImageConvert.GetIntensityImage(cogImageSou, 0, 0, cogImageSou.Width, cogImageSou.Height);                    
                }
                else
                {
                        
                    CogIPOneImageFlipRotate cogIPOneImageFlipRotate = new CogIPOneImageFlipRotate();
                    cogIPOneImageFlipRotate.OperationInPixelSpace = (CogIPOneImageFlipRotateOperationConstants)nFlipRotation;

                    ICogImage cogImageFR = cogIPOneImageFlipRotate.Execute(
                        CogImageConvert.GetIntensityImage(cogImageSou, 0, 0, cogImageSou.Width, cogImageSou.Height),
                        CogRegionModeConstants.PixelAlignedBoundingBox, null);
                                        
                    Bitmap Bmp = cogImageFR.ToBitmap();
                    if ((Bmp.Flags & (16 | 32 | 64 | 128 | 256)) != 0)
                        cogImageDes = new CogImage24PlanarColor(Bmp);
                    else
                        cogImageDes = new CogImage8Grey(Bmp);
                    
                }
                return 1;

            }
            catch
            {
                return -2;
            }
        }
        /*
        // 2012.01.17
        public static int LoadGrayImgFlipRotation(string strImgName, ref ICogImage cogImage, int nFlipRotation)
        {
            if (File.Exists(strImgName))
            {
                if (nFlipRotation == 0)
                {
                    // 2011.05.07
                    try
                    {
                        m_nFileCount = 0;
                        m_cogImageFile.Open(strImgName, CogImageFileModeConstants.Read);

                        //cogDisplay.Image = m_cogImageFile[0];
                        cogImage = CogImageConvert.GetIntensityImage(m_cogImageFile[0], 0, 0, m_cogImageFile[0].Width, m_cogImageFile[0].Height);

                        m_cogImageFile.Close();
                    }
                    catch
                    {
                        return -2;
                    }

                    return 1;
                }
                else
                {
                    try
                    {
                        m_nFileCount = 0;
                        m_cogImageFile.Open(strImgName, CogImageFileModeConstants.Read);


                        CogIPOneImageFlipRotate cogIPOneImageFlipRotate = new CogIPOneImageFlipRotate();
                        cogIPOneImageFlipRotate.OperationInPixelSpace = (CogIPOneImageFlipRotateOperationConstants)nFlipRotation;

                        ICogImage cogImageFR = cogIPOneImageFlipRotate.Execute(
                            CogImageConvert.GetIntensityImage(m_cogImageFile[0], 0, 0, m_cogImageFile[0].Width, m_cogImageFile[0].Height),
                            CogRegionModeConstants.PixelAlignedBoundingBox, null);

                        m_cogImageFile.Close();


                        lock (m_cogImageFile)
                        {
                            string strFName = "c:\\" + AVisionProBuild.MakeName("Flip", DateTime.Now) + ".bmp";
                            m_cogImageFile.Open(strFName, CogImageFileModeConstants.Write);
                            m_cogImageFile.Append(cogImageFR);
                            m_cogImageFile.Close();
                            m_cogImageFile.Open(strFName, CogImageFileModeConstants.Read);
                            cogImage = m_cogImageFile[0];
                            m_cogImageFile.Close();
                            File.Delete(strFName);
                        }
                        return 1;

                    }
                    catch
                    {
                        return -3;
                    }
                }
            }
            return -1;
        }        
        // 2012.01.09
        public static int LoadGrayImgFlipRotation(string strImgName, CogDisplay cogDisplay, int nFlipRotation)
        {
            if (File.Exists(strImgName))
            {
                if (nFlipRotation == 0)
                {
                    // 2011.05.07
                    try
                    {
                        m_nFileCount = 0;
                        m_cogImageFile.Open(strImgName, CogImageFileModeConstants.Read);

                        //cogDisplay.Image = m_cogImageFile[0];
                        cogDisplay.Image = CogImageConvert.GetIntensityImage(m_cogImageFile[0], 0, 0, m_cogImageFile[0].Width, m_cogImageFile[0].Height);

                        m_cogImageFile.Close();
                    }
                    catch
                    {
                        return -2;
                    }

                    return 1;
                }
                else
                {    
                    try
                    {
                        m_nFileCount = 0;
                        m_cogImageFile.Open(strImgName, CogImageFileModeConstants.Read);


                        CogIPOneImageFlipRotate cogIPOneImageFlipRotate = new CogIPOneImageFlipRotate();
                        cogIPOneImageFlipRotate.OperationInPixelSpace = (CogIPOneImageFlipRotateOperationConstants)nFlipRotation;

                        ICogImage cogImage = cogIPOneImageFlipRotate.Execute(
                            CogImageConvert.GetIntensityImage(m_cogImageFile[0], 0, 0, m_cogImageFile[0].Width, m_cogImageFile[0].Height),
                            CogRegionModeConstants.PixelAlignedBoundingBox, null);

                        m_cogImageFile.Close();
                    

                        lock (m_cogImageFile)
                        {
                            string strFName = "c:\\" + AVisionProBuild.MakeName("Flip", DateTime.Now) + ".bmp";
                            m_cogImageFile.Open(strFName, CogImageFileModeConstants.Write);
                            m_cogImageFile.Append(cogImage);
                            m_cogImageFile.Close();
                            m_cogImageFile.Open(strFName, CogImageFileModeConstants.Read);
                            cogDisplay.Image = m_cogImageFile[0];
                            m_cogImageFile.Close();
                            File.Delete(strFName);
                        }
                        return 1;

                    }
                    catch
                    {
                        return -3;
                    }
                }
            }
            return -1;
        }

        // 2012.01.09
        public static int LoadGrayImgFlipRotation(string strBmpName, ADisplay aDisplay, int nFlipRotation)
        {
            return LoadGrayImgFlipRotation(strBmpName, aDisplay.m_cogDisplay, nFlipRotation);
        }
        */
// 2014.10.30
#if _USE_1Camera
        public static AAcqFifo GetAcq()
        {
            return m_aAcqFifo;
        }
#endif
        // 2014.12.12
        public static int GetWord8500DI(int nIndex)
        {
            int n = 0, i;
            int nR = 0;
            CogFrameGrabbers frameGrabbers = new CogFrameGrabbers();
            foreach (ICogFrameGrabber fg in frameGrabbers)
            {
                if (fg.Name.Contains("Cognex 85"))
                {
                    if (nIndex == n)
                    {
                        CogInputLines InputLines = fg.InputLines;
                        for(i=0;i<4;i++)
                        {
                            CogInputLine InputLine = InputLines[i];
                            if (InputLine.CanBeEnabled == true)
                            {
                                if (InputLine.Enabled != true)
                                    InputLine.Enabled = true;
                                if (InputLine.Value == false)
                                {
                                    nR |= (1 << i);
                                }
                            }
                        }
                        return nR;
                    }
                    n++;
                }
            }
            return -1;
        }

		// 2016.01.15
		public static int GetBit8500DI(int nIndex, int nC,ref bool bV)
        {
            int n = 0;
            CogFrameGrabbers frameGrabbers = new CogFrameGrabbers();
            foreach (ICogFrameGrabber fg in frameGrabbers)
            {
                if (fg.Name.Contains("Cognex 85"))
                {
                    if (nIndex == n)
                    {
                        CogInputLines InputLines = fg.InputLines;

                        if (nC < InputLines.Count)
                        {
                            CogInputLine InputLine = InputLines[nC];
                            if (InputLine.CanBeEnabled == true)
                            {
                                if (InputLine.Enabled != true)
                                    InputLine.Enabled = true;

                                bV = !InputLine.Value;
                                return 0;
                            }
                            else
                                return -3;
                        }
                        else
                            return -2;
                    }
                    n++;
                }
            }
            return -1;
        }
		
        // 2014.12.12 (nC: 4~7)
        public static int SetBit8500DO(int nIndex, int nC, bool bV)
        {
            int n = 0;
            CogFrameGrabbers frameGrabbers = new CogFrameGrabbers();
            foreach (ICogFrameGrabber fg in frameGrabbers)
            {
                if (fg.Name.Contains("Cognex 85"))
                {
                    if (nIndex == n)
                    {
                        CogOutputLines OutputLines = fg.OutputLines;
                        
                        if (nC < OutputLines.Count)
                        {
                            CogOutputLine OutputLine = OutputLines[nC];
                            if (OutputLine.CanBeEnabled == true)
                            {
                                if (OutputLine.Enabled != true)
                                    OutputLine.Enabled = true;
                                OutputLine.Value = !bV;
                                return 0;
                            }
                            else
                                return -3;
                        }
                        else
                            return -2;
                    }
                    n++;
                }
            }
            return -1;
        }

        // 2014.12.12
        public static int GetWord8500DO(int nIndex)
        {
            int n = 0, i;
            int nR = 0;
            CogFrameGrabbers frameGrabbers = new CogFrameGrabbers();
            foreach (ICogFrameGrabber fg in frameGrabbers)
            {
                if (fg.Name.Contains("Cognex 85"))
                {
                    if (nIndex == n)
                    {
                        CogOutputLines OutputLines = fg.OutputLines;
                        for (i = 4; i < 8; i++)
                        {
                            CogOutputLine OutputLine = OutputLines[i];
                            if (OutputLine.CanBeEnabled == true)
                            {
                                if (OutputLine.Enabled != true)
                                    OutputLine.Enabled = true;
                                if (OutputLine.Value == false)
                                {
                                    nR |= (1 << i);
                                }
                            }
                        }
                        return nR;
                    }
                    n++;
                }
            }
            return -1;
        }

        // 2014.12.12 (nC: 4~7)
        public static int GetBit8500DO(int nIndex, int nC,ref bool bV)
        {
            int n = 0;
            CogFrameGrabbers frameGrabbers = new CogFrameGrabbers();
            foreach (ICogFrameGrabber fg in frameGrabbers)
            {
                if (fg.Name.Contains("Cognex 85"))
                {
                    if (nIndex == n)
                    {
                        CogOutputLines OutputLines = fg.OutputLines;

                        if (nC < OutputLines.Count)
                        {
                            CogOutputLine OutputLine = OutputLines[nC];
                            if (OutputLine.CanBeEnabled == true)
                            {
                                if (OutputLine.Enabled != true)
                                    OutputLine.Enabled = true;
                                bV = !OutputLine.Value;
                                return 0;
                            }
                            else
                                return -3;
                        }
                        else
                            return -2;
                    }
                    n++;
                }
            }
            return -1;
        }

        // 2015.04.01
        public static ICogImage RunPreprocessImage(ICogImage icogImgInput, _stPreprocess stPreprocess)
        {
            // 2016.08.19
            if (stPreprocess.nLow == 0 && stPreprocess.nHigh == 255)
                return icogImgInput;

            ICogImage icogImgOutput;

            CogIPOneImagePixelMap cogIPOneImagePixelMap = new CogIPOneImagePixelMap();
            Byte[] pbValue = new Byte[256];
            int i = 0;
            for (i = 0; i < 256; i++)
            {
                if (stPreprocess.nLow > i || stPreprocess.nHigh < i)
                    pbValue[i] = (Byte)stPreprocess.nValue;
                else
                    pbValue[i] = (Byte)i;
            }
            cogIPOneImagePixelMap.SetMap(pbValue);
            icogImgOutput = cogIPOneImagePixelMap.Execute(icogImgInput, CogRegionModeConstants.PixelAlignedBoundingBox, null);

            return icogImgOutput;
        }

        // 2016.08.31
        public static ICogImage RunEqualizeImage(ICogImage icogImgInput)
        {
            // 2016.09.14
            if (icogImgInput == null)
                return null;

            ICogImage icogImgOutput;

            CogIPOneImageEqualize cogIPOneImageEqualize = new CogIPOneImageEqualize();
            icogImgOutput = cogIPOneImageEqualize.Execute(icogImgInput, CogRegionModeConstants.PixelAlignedBoundingBox, null);

            return icogImgOutput;
        }

        // 2016.12.01
        public static ICogImage RunEqualizeImage(ICogImage icogImgInput, Cognex.VisionPro.ICogRegion region)
        {
            if (region == null)
                return RunEqualizeImage(icogImgInput);

            if (icogImgInput == null)
                return null;

            ICogImage icogImgOutput;

            CogIPOneImageEqualize cogIPOneImageEqualize = new CogIPOneImageEqualize();
            icogImgOutput = cogIPOneImageEqualize.Execute(icogImgInput, CogRegionModeConstants.PixelAlignedBoundingBox, region);

            Bitmap b0 = icogImgInput.ToBitmap();
            Bitmap b1 = icogImgOutput.ToBitmap();
            Graphics g = Graphics.FromImage(b0);
            int x, y;
            if (region.EnclosingRectangle(CogCopyShapeConstants.All).X < 0)
                x = 0;
            else
                x = (int)region.EnclosingRectangle(CogCopyShapeConstants.All).X;
            if (region.EnclosingRectangle(CogCopyShapeConstants.All).Y < 0)
                y = 0;
            else
                y = (int)region.EnclosingRectangle(CogCopyShapeConstants.All).Y;

            g.DrawImage(b1, new Point(x, y));

            icogImgOutput = new CogImage8Grey(b0);
            b0.Dispose();
            b1.Dispose();
            g.Dispose();

            return icogImgOutput;
        }

        // 2015.06.15
        public static int FindType(string strTypeName)
        {
            int nCount = m_lstAType.Count;

            for (int i = 0; i < nCount; i++)
            {
                if (m_lstAType[i].Name == strTypeName)
                    return i;
            }

            return -1;
        }

        // 2015.06.15
        public static void SetType(AType aType, int nIndex)
        {
            if (nIndex > m_lstAType.Count)
                return;

            m_lstAType[nIndex] = aType;
        }

        
        // 2015.07.20
        public static Bitmap ProcessGamma(Bitmap bmp, float fVal)
        {
            if (bmp == null)
            {
                return null;
            }

            // 1 means no change, do not 
            if (fVal == 1.0000f)
                return bmp;

            try
            {
                Bitmap b = new Bitmap(bmp.Width, bmp.Height, PixelFormat.Format24bppRgb);
                Graphics g = Graphics.FromImage(b);
                ImageAttributes attr = new ImageAttributes();

                attr.SetGamma(fVal, ColorAdjustType.Bitmap);
                g.DrawImage(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attr);
                g.Dispose();
                return b;
            }
            catch //(Exception e)
            {
                return null;
            }
        }

        // 2015.07.20
        public static ICogImage RunGamma(ICogImage icogImgInput, float fVal)
        {
            if (icogImgInput == null)
                return null;

            ICogImage icogImgOutput;

            icogImgOutput = icogImgInput;

            Bitmap b = ProcessGamma(icogImgInput.ToBitmap(), fVal);
            if (b != null)
            {
                icogImgOutput = new CogImage8Grey(b);
            }

            return icogImgOutput;
        }

        //-----------------------------------------------
        // 2019.06.13        
        public static Bitmap ConvertBmp(ICogImage cogImg, bool bColor)
        {
            Bitmap bmp = cogImg.ToBitmap();
            if (bColor)
            {
                return bmp;
            }
            else
            {
                Bitmap bmp1 = AUtil.BitmapToGrayscale(bmp);
                //AUtil.SetGrayscalePalette(bmp1);
                return bmp1;
            }
        }
        public static ICogImage ConvertCogImage(Bitmap bmp, bool bColor)
        {
            if (bColor)
            {
                return (new CogImage24PlanarColor(bmp));
            }
            else
            {
                return (new CogImage8Grey(bmp));
            }            
        }
        //-----------------------------------------------

        // 2015.12.07
        public static bool CheckLicense(string strLicense)
        {
            // 2019.04.21
#if !_VPRO9_6
            CogStringCollection LicensedFeatures = CogMisc.GetLicensedFeatures(false);
#else
            CogStringCollection LicensedFeatures = CogLicense.GetLicensedFeatures(false, false);
#endif

            if (LicensedFeatures.Count == 0)
            {
                //MessageBox.Show("비전 라이선스를 확인하세요", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                MessageBox.Show("Please check your vision License", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (strLicense.Length == 0)
                return true;

            foreach (string strFeature in LicensedFeatures)
            {
                if (strFeature == strLicense)
                    return true;
            }

            //MessageBox.Show("해당 라이선스를 확인할 수 없습니다", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            MessageBox.Show("You can't verify that license", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
        }

        // 2015.12.07 by kdi
        public static string GetCameraSerialNumber(CogAcqFifoTool acqFifo, bool bExtension)
        {
            string strSN = "";

            if (acqFifo != null &&
                acqFifo.Operator != null &&
                acqFifo.Operator.FrameGrabber != null)
            {
                //*
                // Digital Camera
                if (acqFifo.Operator.FrameGrabber.OwnedGigEAccess != null)
                {
                    strSN = acqFifo.Operator.FrameGrabber.SerialNumber;
                }
                // Analog Camera
                else
                {
                    if (bExtension == true)
                        strSN = acqFifo.Operator.FrameGrabber.SerialNumber + "_#" + acqFifo.Operator.CameraPort.ToString();
                    else
                        strSN = acqFifo.Operator.FrameGrabber.SerialNumber;
                }
                //*/

                //strSN = acqFifo.Operator.FrameGrabber.SerialNumber;
            }
            else
                strSN = "";

            return strSN;
        }

        // 2016.03.22
        public static void SetStartXY(ref ICogRegion cogRegion, double dX, double dY)
        {
            if (cogRegion == null)
            {
                return;
            }

            if (cogRegion is CogCircle)
            {
                CogCircle region = cogRegion as CogCircle;
                region.CenterX = dX;
                region.CenterY = dY;
            }
            else if (cogRegion is CogEllipse)
            {
                CogEllipse region = cogRegion as CogEllipse;
                region.CenterX = dX;
                region.CenterY = dY;
            }
            else if (cogRegion is CogRectangle)
            {
                CogRectangle region = cogRegion as CogRectangle;
                region.X = dX - region.Width / 2;
                region.Y = dY - region.Height / 2;
            }
            else if (cogRegion is CogRectangleAffine)
            {
                CogRectangleAffine region = cogRegion as CogRectangleAffine;
                region.CenterX = dX;
                region.CenterY = dY;
            }
            else if (cogRegion is CogCircularAnnulusSection)
            {
                CogCircularAnnulusSection region = cogRegion as CogCircularAnnulusSection;
                region.CenterX = dX;
                region.CenterY = dY;
            }
            else if (cogRegion is CogEllipticalAnnulusSection)
            {
                CogCircularAnnulusSection region = cogRegion as CogCircularAnnulusSection;
                region.CenterX = dX;
                region.CenterY = dY;
            }
        }

        // 2016.03.22
        public static void SetStartX(ref ICogRegion cogRegion, double dX)
        {
            if (cogRegion == null)
            {
                return;
            }

            if (cogRegion is CogCircle)
            {
                CogCircle region = cogRegion as CogCircle;
                region.CenterX = dX;
            }
            else if (cogRegion is CogEllipse)
            {
                CogEllipse region = cogRegion as CogEllipse;
                region.CenterX = dX;
            }
            else if (cogRegion is CogRectangle)
            {
                CogRectangle region = cogRegion as CogRectangle;
                region.X = dX - region.Width / 2;
            }
            else if (cogRegion is CogRectangleAffine)
            {
                CogRectangleAffine region = cogRegion as CogRectangleAffine;
                region.CenterX = dX;
            }
            else if (cogRegion is CogCircularAnnulusSection)
            {
                CogCircularAnnulusSection region = cogRegion as CogCircularAnnulusSection;
                region.CenterX = dX;
            }
            else if (cogRegion is CogEllipticalAnnulusSection)
            {
                CogCircularAnnulusSection region = cogRegion as CogCircularAnnulusSection;
                region.CenterX = dX;
            }
        }

        // 2016.03.22
        public static void SetStartY(ref ICogRegion cogRegion, double dY)
        {
            if (cogRegion == null)
            {
                return;
            }

            if (cogRegion is CogCircle)
            {
                CogCircle region = cogRegion as CogCircle;
                region.CenterY = dY;
            }
            else if (cogRegion is CogEllipse)
            {
                CogEllipse region = cogRegion as CogEllipse;
                region.CenterY = dY;
            }
            else if (cogRegion is CogRectangle)
            {
                CogRectangle region = cogRegion as CogRectangle;
                region.Y = dY - region.Height / 2;
            }
            else if (cogRegion is CogRectangleAffine)
            {
                CogRectangleAffine region = cogRegion as CogRectangleAffine;
                region.CenterY = dY;
            }
            else if (cogRegion is CogCircularAnnulusSection)
            {
                CogCircularAnnulusSection region = cogRegion as CogCircularAnnulusSection;
                region.CenterY = dY;
            }
            else if (cogRegion is CogEllipticalAnnulusSection)
            {
                CogCircularAnnulusSection region = cogRegion as CogCircularAnnulusSection;
                region.CenterY = dY;
            }
        }

        // 2016.08.01
#if _USE_FIXTURENPOINTTONPOINT
        // 2016.06.21
        public static ICogImage RunFixtureImage(ICogImage icogImgInput, ref bool bU, int nBody, int nPoint)
        {
            ICogImage icogImgOutput;

            icogImgOutput = icogImgInput;

            if (bU == false)
                return icogImgOutput;

            APoint aPoint = GetPoint(nBody, nPoint);
            AFixtureNPointToNPoint aFixtureNPointToNPoint = aPoint.GetTool("FixtureNPointToNPoint", 0) as AFixtureNPointToNPoint;

            icogImgOutput = aFixtureNPointToNPoint.Run(icogImgInput);

            if (aFixtureNPointToNPoint.GetTool().Result == null)
                bU = false;
            else
                bU = true;

            return icogImgOutput;
        }
#endif

        // 2020.03.03
        public static ICogImage RunFixtureTool(double dX, double dY, ICogImage cogImage)
        {

            //CogFixtureTool cogFixtureTool = new CogFixtureTool();
            m_FixtureTool.InputImage = cogImage;
            (m_FixtureTool.RunParams.UnfixturedFromFixturedTransform as CogTransform2DLinear).TranslationX = dX;
            (m_FixtureTool.RunParams.UnfixturedFromFixturedTransform as CogTransform2DLinear).TranslationY = dY;
            m_FixtureTool.Run();
            if (m_FixtureTool.RunStatus.Result == 0)
                return m_FixtureTool.OutputImage;
            else
                return cogImage;
        }

        // 2020.03.03
        public static ICogImage RunFixtureTool(CogTransform2DLinear cogTransPose, ICogImage cogImage)
        {

            //CogFixtureTool cogFixtureTool = new CogFixtureTool();
            m_FixtureTool.InputImage = cogImage;
            m_FixtureTool.RunParams.UnfixturedFromFixturedTransform = cogTransPose;
            m_FixtureTool.Run();
            if (m_FixtureTool.RunStatus.Result == 0)
                return m_FixtureTool.OutputImage;
            else
                return cogImage;
        }

    }

    //------------------------------------------------
    // 2018.04.09

    // 2018.01.18 by kdi
    public class clsCAM_Info
    {
        public const Int64 _CONST_GIGE_EXPOSURE_TIME = 10;
        public const double _CONST_GIGE_CONTRAST = 0.108342361863489;
        public const double _CONST_GIGE_BRIGHTNESS = 0.0625610948191593;
        public const int _CONST_GIGE_TIMEOUT = 10000;

        public string m_strName = "";
        public string m_strSerialNumber = "";
        public string m_strPixelFormat = "";
        public Int64 m_n64Exposure = _CONST_GIGE_EXPOSURE_TIME;
        public double m_dContrast = _CONST_GIGE_CONTRAST;
        public double m_dBrightness = _CONST_GIGE_BRIGHTNESS;
        public int m_nTimeout = _CONST_GIGE_TIMEOUT;

        public clsCAM_Info()
        {
            Init();
        }

        void Init()
        {
            m_strName = "";
            m_strSerialNumber = "";
            m_strPixelFormat = "";
            m_n64Exposure = _CONST_GIGE_EXPOSURE_TIME;
            m_dContrast = _CONST_GIGE_CONTRAST;
            m_dBrightness = _CONST_GIGE_BRIGHTNESS;
            m_nTimeout = _CONST_GIGE_TIMEOUT;
        }
    }

    // 2018.01.18 by kdi
    public class clsFrameGrabber
    {
        public ICogFrameGrabber m_Grabber;
        public string m_strSerialNumber;
        public ICogAcqFifo m_AcqFifo;
    }

    // 2018.01.18 by kdi
    public class clsCamera
    {
        // 2018.04.09
        // 2018.01.18 by kdi
        public const int _WM_CAMERA_IS_DISCONNECTED = (0x0400 + 230);

        // 등록된 카메라 목록
        static private List<clsCAM_Info> m_lstCamInfo = new List<clsCAM_Info>();
        static public List<clsCAM_Info> CamInfoList
        {
            get { return m_lstCamInfo; }
        }

        // 사용 가능한 FrameGrabber 목록
        static private List<clsFrameGrabber> m_lstFrameGrabber = new List<clsFrameGrabber>();
        static public List<clsFrameGrabber> FrameGrabberList
        {
            get { return m_lstFrameGrabber; }
            set { m_lstFrameGrabber = value; }
        }

        public static void GetCameraInfo()
        {
            StringBuilder sb = new StringBuilder(256);
            int nCount = 0;

            nCount = AUtil.GetPrivateProfileInt("CAMERA", "Count", 0, ASDef._CAM_FILE);

            // Camera Info
            for (int j = 0; j < nCount; ++j)
            {
                clsCAM_Info CamInfo = new clsCAM_Info();

                AUtil.GetPrivateProfileString("CAMERA", "Camera" + j.ToString(), "", sb, 32, ASDef._CAM_FILE);
                CamInfo.m_strName = sb.ToString();

                AUtil.GetPrivateProfileString(CamInfo.m_strName, "SN", "", sb, 32, ASDef._CAM_FILE);
                CamInfo.m_strSerialNumber = sb.ToString();

                AUtil.GetPrivateProfileString(CamInfo.m_strName, "PixelFormat", "Mono 8", sb, 32, ASDef._CAM_FILE);
                CamInfo.m_strPixelFormat = sb.ToString();

                AUtil.GetPrivateProfileString(CamInfo.m_strName, "ExposureTime", "10", sb, 32, ASDef._CAM_FILE);
                CamInfo.m_n64Exposure = Convert.ToInt64(sb.ToString());

                AUtil.GetPrivateProfileString(CamInfo.m_strName, "Contrast", "0.108342361863489", sb, 32, ASDef._CAM_FILE);
                CamInfo.m_dContrast = Convert.ToDouble(sb.ToString());

                AUtil.GetPrivateProfileString(CamInfo.m_strName, "Brightness", "0.0625610948191593", sb, 32, ASDef._CAM_FILE);
                CamInfo.m_dBrightness = Convert.ToDouble(sb.ToString());

                AUtil.GetPrivateProfileString(CamInfo.m_strName, "Timeout", "10000", sb, 32, ASDef._CAM_FILE);
                CamInfo.m_nTimeout = Convert.ToInt32(sb.ToString());

                m_lstCamInfo.Add(CamInfo);
            }
        }

        public static clsFrameGrabber GetFrameGrabberInfo(string strSerialNumber)
        {
            clsFrameGrabber grabber = null;

            for (int j = 0; j < m_lstFrameGrabber.Count; ++j)
            {
                if (m_lstFrameGrabber[j].m_strSerialNumber == strSerialNumber)
                {
                    return m_lstFrameGrabber[j];
                }
            }

            return grabber;
        }

        public static clsCAM_Info GetCameraInfo(string strDev)
        {
            for (int j = 0; j < m_lstCamInfo.Count; ++j)
            {
                if (m_lstCamInfo[j].m_strSerialNumber == strDev)
                {
                    return m_lstCamInfo[j];
                }
            }

            return null;
        }

        public static ICogAcqFifo GetAcqFifo(string strSerialNumber)
        {
            foreach (clsFrameGrabber grabber in m_lstFrameGrabber)
            {
                if (grabber.m_strSerialNumber == strSerialNumber)
                    return grabber.m_AcqFifo;
            }

            return null;
        }

        public static bool FindCamera(string strDev)
        {
            bool bFound = false;

            for (int j = 0; j < m_lstCamInfo.Count; ++j)
            {
                if (m_lstCamInfo[j].m_strSerialNumber == strDev)
                {
                    bFound = true;
                    break;
                }
            }

            return bFound;
        }

        public static void WriteCameraInfo()
        {
            AUtil.WritePrivateProfileString("Camera", "Count", m_lstCamInfo.Count.ToString(), ASDef._CAM_FILE);

            // Camera Info
            for (int j = 0; j < m_lstCamInfo.Count; ++j)
            {
                AUtil.WritePrivateProfileString("Camera", "Camera" + j.ToString(), m_lstCamInfo[j].m_strName, ASDef._CAM_FILE);

                clsCAM_Info CamInfo = new clsCAM_Info();

                AUtil.WritePrivateProfileString(m_lstCamInfo[j].m_strName, "SN", m_lstCamInfo[j].m_strSerialNumber, ASDef._CAM_FILE);

                AUtil.WritePrivateProfileString(m_lstCamInfo[j].m_strName, "PixelFormat", m_lstCamInfo[j].m_strPixelFormat, ASDef._CAM_FILE);

                AUtil.WritePrivateProfileString(m_lstCamInfo[j].m_strName, "ExposureTime", m_lstCamInfo[j].m_n64Exposure.ToString(), ASDef._CAM_FILE);
                AUtil.WritePrivateProfileString(m_lstCamInfo[j].m_strName, "Contrast", m_lstCamInfo[j].m_dContrast.ToString("0.0000"), ASDef._CAM_FILE);
                AUtil.WritePrivateProfileString(m_lstCamInfo[j].m_strName, "Brightness", m_lstCamInfo[j].m_dBrightness.ToString("0.0000"), ASDef._CAM_FILE);
                AUtil.WritePrivateProfileString(m_lstCamInfo[j].m_strName, "Timeout", m_lstCamInfo[j].m_nTimeout.ToString(), ASDef._CAM_FILE);
            }
        }

        public static void WriteCameraInfo(clsCAM_Info camInfo)
        {
            // Camera Info
            for (int j = 0; j < m_lstCamInfo.Count; ++j)
            {
                if (m_lstCamInfo[j].m_strSerialNumber == camInfo.m_strSerialNumber)
                {
                    AUtil.WritePrivateProfileString(m_lstCamInfo[j].m_strName, "SN", camInfo.m_strSerialNumber, ASDef._CAM_FILE);
                    AUtil.WritePrivateProfileString(m_lstCamInfo[j].m_strName, "PixelFormat", camInfo.m_strPixelFormat, ASDef._CAM_FILE);
                    AUtil.WritePrivateProfileString(m_lstCamInfo[j].m_strName, "ExposureTime", camInfo.m_n64Exposure.ToString(), ASDef._CAM_FILE);
                    AUtil.WritePrivateProfileString(m_lstCamInfo[j].m_strName, "Contrast", camInfo.m_dContrast.ToString("0.0000"), ASDef._CAM_FILE);
                    AUtil.WritePrivateProfileString(m_lstCamInfo[j].m_strName, "Brightness", camInfo.m_dBrightness.ToString("0.0000"), ASDef._CAM_FILE);
                    AUtil.WritePrivateProfileString(m_lstCamInfo[j].m_strName, "Timeout", camInfo.m_nTimeout.ToString(), ASDef._CAM_FILE);
                }
            }
        }
        
    }
    //------------------------------------------------

}
