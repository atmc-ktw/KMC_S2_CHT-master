using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Atmc;

namespace AVisionPro
{
    public class AIniPMAlign
    {
        private int m_nType;
        private int m_nPoint;
        private int m_nToolIndex;
        
        private string m_strInitX;
        private string m_strInitY;
        private string m_strInitAngle;
                
        private string m_strCalibCase;

        // 2020.03.11
        private int m_nFixtureNPointToNPoint;

        // 2014.08.27
        private string m_strInitSearchRegionX;
        private string m_strInitSearchRegionY;

        public AIniPMAlign(int nType, int nPoint, int nToolIndex)
        {
            m_nType = nType;
            m_nPoint = nPoint;
            m_nToolIndex = nToolIndex;
        }

        public void Read()
        {
            StringBuilder sb = new StringBuilder(32);

            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_PMAlign" + m_nToolIndex.ToString() + "_Init_X", "0", sb, 32, ASDef._INI_FILE);
            m_strInitX = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_PMAlign" + m_nToolIndex.ToString() + "_Init_Y", "0", sb, 32, ASDef._INI_FILE);
            m_strInitY = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_PMAlign" + m_nToolIndex.ToString() + "_Init_Angle", "0", sb, 32, ASDef._INI_FILE);
            m_strInitAngle = sb.ToString();

            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_PMAlign" + m_nToolIndex.ToString() + "_CalibCase", "No Calib", sb, 32, ASDef._INI_FILE);
            m_strCalibCase = sb.ToString();

            // 2020.03.11
            m_nFixtureNPointToNPoint = AUtil.GetPrivateProfileInt(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_PMAlign" + m_nToolIndex.ToString() + "_FixtureNPointToNPoint", 0, ASDef._INI_FILE);

            // 2014.08.27
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_PMAlign" + m_nToolIndex.ToString() + "_Init_SearchRegion_X", "0", sb, 32, ASDef._INI_FILE);
            m_strInitSearchRegionX = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_PMAlign" + m_nToolIndex.ToString() + "_Init_SearchRegion_Y", "0", sb, 32, ASDef._INI_FILE);
            m_strInitSearchRegionY = sb.ToString();
        }

        public void Write()
        {
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_PMAlign" + m_nToolIndex.ToString() + "_Init_X", m_strInitX, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_PMAlign" + m_nToolIndex.ToString() + "_Init_Y", m_strInitY, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_PMAlign" + m_nToolIndex.ToString() + "_Init_Angle", m_strInitAngle, ASDef._INI_FILE);

            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_PMAlign" + m_nToolIndex.ToString() + "_CalibCase", m_strCalibCase, ASDef._INI_FILE);

            // 2020.03.11
            if (m_nFixtureNPointToNPoint == 0)
                AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_PMAlign" + m_nToolIndex.ToString() + "_FixtureNPointToNPoint", "0", ASDef._INI_FILE);
            else
                AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_PMAlign" + m_nToolIndex.ToString() + "_FixtureNPointToNPoint", "1", ASDef._INI_FILE);

            // 2014.08.27
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_PMAlign" + m_nToolIndex.ToString() + "_Init_SearchRegion_X", m_strInitSearchRegionX, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_PMAlign" + m_nToolIndex.ToString() + "_Init_SearchRegion_Y", m_strInitSearchRegionY, ASDef._INI_FILE);
        }

        public string InitX
        {
            get { return m_strInitX; }
            set { m_strInitX = (string)value; }
        }

        public string InitY
        {
            get { return m_strInitY; }
            set { m_strInitY = (string)value; }
        }
        
        public string InitAngle
        {
            get { return m_strInitAngle; }
            set { m_strInitAngle = (string)value; }
        }
        public string CalibCase
        {
            get { return m_strCalibCase; }
            set { m_strCalibCase = (string)value; }
        }

        // 2020.03.11
        public bool FixtureNPointToNPoint
        {
            get
            {
                if (m_nFixtureNPointToNPoint == 0)
                    return false;
                else
                    return true;
            }
            set
            {
                if ((bool)value == false)
                    m_nFixtureNPointToNPoint = 0;
                else
                    m_nFixtureNPointToNPoint = 1;
            }
        }

        // 2014.08.27
        public string InitSearchRegionX
        {
            get { return m_strInitSearchRegionX; }
            set { m_strInitSearchRegionX = (string)value; }
        }        
        public string InitSearchRegionY
        {
            get { return m_strInitSearchRegionY; }
            set { m_strInitSearchRegionY = (string)value; }
        }
    }

    public class AIniBlob
    {
        private int m_nType;
        private int m_nPoint;
        private int m_nToolIndex;

        private bool m_bShowRegion;
        private bool m_bShowCenter;

        // 2014.10.01
        private string m_strCalibCase;
        // 2015.04.01
        public AVisionProBuild._stPreprocess m_stPreprocess;
        
        public AIniBlob(int nType, int nPoint, int nToolIndex)
        {
            m_nType = nType;
            m_nPoint = nPoint;
            m_nToolIndex = nToolIndex;            
        }

        // 2015.04.01
        public void Set(int nType, int nPoint, int nToolIndex)
        {
            m_nType = nType;
            m_nPoint = nPoint;
            m_nToolIndex = nToolIndex;
        }

        public void Read()
        {
            // 2011.06.18
            if (AUtil.GetPrivateProfileInt(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Blob" + m_nToolIndex + "_IsShowRegion", 1, ASDef._INI_FILE) == 1)
            {
                m_bShowRegion = true;
            }
            else
            {
                m_bShowRegion = false;
            }

            if (AUtil.GetPrivateProfileInt(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Blob" + m_nToolIndex.ToString() + "_IsShowCenter", 0, ASDef._INI_FILE) == 1)
            {
                m_bShowCenter = true;
            }
            else
            {
                m_bShowCenter = false;
            }

            // 2014.10.01
            StringBuilder sb = new StringBuilder(32);
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Blob" + m_nToolIndex.ToString() + "_CalibCase", "No Calib", sb, 32, ASDef._INI_FILE);
            m_strCalibCase = sb.ToString();

            // 2015.04.01
            m_stPreprocess.nLow = AUtil.GetPrivateProfileInt(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Blob" + m_nToolIndex.ToString() + "_Preprocess_Low", 0, ASDef._INI_FILE);
            m_stPreprocess.nHigh = AUtil.GetPrivateProfileInt(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Blob" + m_nToolIndex.ToString() + "_Preprocess_High", 255, ASDef._INI_FILE);
            m_stPreprocess.nValue = AUtil.GetPrivateProfileInt(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Blob" + m_nToolIndex.ToString() + "_Preprocess_Value", 255, ASDef._INI_FILE);
        }

        public void Write()
        {
            if (m_bShowRegion == true)
            {
                AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Blob" + m_nToolIndex.ToString() + "_IsShowRegion", "1", ASDef._INI_FILE);
            }
            else
            {
                AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Blob" + m_nToolIndex.ToString() + "_IsShowRegion", "0", ASDef._INI_FILE);
            }

            if (m_bShowCenter == true)
            {
                AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Blob" + m_nToolIndex.ToString() + "_IsShowCenter", "1", ASDef._INI_FILE);
            }
            else
            {
                AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Blob" + m_nToolIndex.ToString() + "_IsShowCenter", "0", ASDef._INI_FILE);
            }

            // 2014.10.01
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Blob" + m_nToolIndex.ToString() + "_CalibCase", m_strCalibCase, ASDef._INI_FILE);

            // 2015.04.01
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Blob" + m_nToolIndex.ToString() + "_Preprocess_Low", m_stPreprocess.nLow.ToString(), ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Blob" + m_nToolIndex.ToString() + "_Preprocess_High", m_stPreprocess.nHigh.ToString(), ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Blob" + m_nToolIndex.ToString() + "_Preprocess_Value", m_stPreprocess.nValue.ToString(), ASDef._INI_FILE);
        }

        public bool ShowRegion
        {
            get { return m_bShowRegion; }
            set { m_bShowRegion = (bool)value; }
        }

        public bool ShowCenter
        {
            get { return m_bShowCenter; }
            set { m_bShowCenter = (bool)value; }
        }

        // 2014.10.01
        public string CalibCase
        {
            get { return m_strCalibCase; }
            set { m_strCalibCase = (string)value; }
        }
    }

    public class AIniCaliper
    {
        private int m_nType;
        private int m_nPoint;
        private int m_nToolIndex;

        private bool m_bShowRegion;

        private string m_strInitX;
        private string m_strInitY;
        // 2012.08.27
        private string m_strInitWidth;
        private string m_strCalibCase;

        // 2014.09.02
        private string m_strInitSearchRegionX;
        private string m_strInitSearchRegionY;

        public AIniCaliper(int nType, int nPoint, int nToolIndex)
        {
            m_nType = nType;
            m_nPoint = nPoint;
            m_nToolIndex = nToolIndex;
        }

        public void Read()
        {
            StringBuilder sb = new StringBuilder(32);

            // 2011.06.18
            if (AUtil.GetPrivateProfileInt(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Caliper" + m_nToolIndex.ToString() + "_IsShowRegion", 1, ASDef._INI_FILE) == 1)
            {
                m_bShowRegion = true;
            }
            else
            {
                m_bShowRegion = false;
            }
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Caliper" + m_nToolIndex.ToString() + "_Init_X", "0", sb, 32, ASDef._INI_FILE);
            m_strInitX = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Caliper" + m_nToolIndex.ToString() + "_Init_Y", "0", sb, 32, ASDef._INI_FILE);
            m_strInitY = sb.ToString();
            // 2012.08.27
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Caliper" + m_nToolIndex.ToString() + "_Init_Width", "0", sb, 32, ASDef._INI_FILE);
            m_strInitWidth = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Caliper" + m_nToolIndex.ToString() + "_CalibCase", "No Calib", sb, 32, ASDef._INI_FILE);
            m_strCalibCase = sb.ToString();

            // 2014.08.27
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Caliper" + m_nToolIndex.ToString() + "_Init_SearchRegion_X", "0", sb, 32, ASDef._INI_FILE);
            m_strInitSearchRegionX = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Caliper" + m_nToolIndex.ToString() + "_Init_SearchRegion_Y", "0", sb, 32, ASDef._INI_FILE);
            m_strInitSearchRegionY = sb.ToString();
        }

        public void Write()
        {            
            if (m_bShowRegion == true)
            {
                AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Caliper" + m_nToolIndex.ToString() + "_IsShowRegion", "1", ASDef._INI_FILE);
            }
            else
            {
                AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Caliper" + m_nToolIndex.ToString() + "_IsShowRegion", "0", ASDef._INI_FILE);
            }
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Caliper" + m_nToolIndex.ToString() + "_Init_X", m_strInitX, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Caliper" + m_nToolIndex.ToString() + "_Init_Y", m_strInitY, ASDef._INI_FILE);
            // 2012.08.27
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Caliper" + m_nToolIndex.ToString() + "_Init_Width", m_strInitWidth, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Caliper" + m_nToolIndex.ToString() + "_CalibCase", m_strCalibCase, ASDef._INI_FILE);

            // 2014.09.02
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Caliper" + m_nToolIndex.ToString() + "_Init_SearchRegion_X", m_strInitSearchRegionX, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Caliper" + m_nToolIndex.ToString() + "_Init_SearchRegion_Y", m_strInitSearchRegionY, ASDef._INI_FILE);
        }

        public bool ShowRegion
        {
            get { return m_bShowRegion; }
            set { m_bShowRegion = (bool)value; }
        }

        public string InitX
        {
            get { return m_strInitX; }
            set { m_strInitX = (string)value; }
        }

        public string InitY
        {
            get { return m_strInitY; }
            set { m_strInitY = (string)value; }
        }

        // 2012.08.27
        public string InitWidth
        {
            get { return m_strInitWidth; }
            set { m_strInitWidth = (string)value; }
        }

        public string CalibCase
        {
            get { return m_strCalibCase; }
            set { m_strCalibCase = (string)value; }
        }

        // 2014.09.02
        public string InitSearchRegionX
        {
            get { return m_strInitSearchRegionX; }
            set { m_strInitSearchRegionX = (string)value; }
        }
        public string InitSearchRegionY
        {
            get { return m_strInitSearchRegionY; }
            set { m_strInitSearchRegionY = (string)value; }
        }
    }

    public class AIniHistogram
    {
        private int m_nType;
        private int m_nPoint;
        private int m_nToolIndex;

        private bool m_bShowRegion;
        private bool m_bShowMedian;
        private bool m_bShowMean;

        // 2014.09.02
        private string m_strInitSearchRegionX;
        private string m_strInitSearchRegionY;
        private string m_strInitMean;
        private string m_strInitMedian;

        public AIniHistogram(int nType, int nPoint, int nToolIndex)
        {
            m_nType = nType;
            m_nPoint = nPoint;
            m_nToolIndex = nToolIndex;
        }

        public void Read()
        {
            // 2011.06.18
            if (AUtil.GetPrivateProfileInt(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Histogram" + m_nToolIndex.ToString() + "_IsShowRegion", 1, ASDef._INI_FILE) == 1)
            {
                m_bShowRegion = true;
            }
            else
            {
                m_bShowRegion = false;
            }

            if (AUtil.GetPrivateProfileInt(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Histogram" + m_nToolIndex.ToString() + "_IsShowMedian", 0, ASDef._INI_FILE) == 1)
            {
                m_bShowMedian = true;
            }
            else
            {
                m_bShowMedian = false;
            }

            if (AUtil.GetPrivateProfileInt(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Histogram" + m_nToolIndex.ToString() + "_IsShowMean", 0, ASDef._INI_FILE) == 1)
            {
                m_bShowMean = true;
            }
            else
            {
                m_bShowMean = false;
            }

            // 2014.09.02
            StringBuilder sb = new StringBuilder(32);
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Histogram" + m_nToolIndex.ToString() + "_Init_SearchRegion_X", "0", sb, 32, ASDef._INI_FILE);
            m_strInitSearchRegionX = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Histogram" + m_nToolIndex.ToString() + "_Init_SearchRegion_Y", "0", sb, 32, ASDef._INI_FILE);
            m_strInitSearchRegionY = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Histogram" + m_nToolIndex.ToString() + "_Init_Mean", "0", sb, 32, ASDef._INI_FILE);
            m_strInitMean = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Histogram" + m_nToolIndex.ToString() + "_Init_Median", "0", sb, 32, ASDef._INI_FILE);
            m_strInitMedian = sb.ToString();
        }

        public void Write()
        {
            if (m_bShowRegion == true)
            {
                AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Histogram" + m_nToolIndex + "_IsShowRegion", "1", ASDef._INI_FILE);
            }
            else
            {
                AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Histogram" + m_nToolIndex + "_IsShowRegion", "0", ASDef._INI_FILE);
            }

            if (m_bShowMedian == true)
            {
                AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Histogram" + m_nToolIndex + "_IsShowMedian", "1", ASDef._INI_FILE);
            }
            else
            {
                AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Histogram" + m_nToolIndex + "_IsShowMedian", "0", ASDef._INI_FILE);
            }

            if (m_bShowMean == true)
            {
                AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Histogram" + m_nToolIndex + "_IsShowMean", "1", ASDef._INI_FILE);
            }
            else
            {
                AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Histogram" + m_nToolIndex + "_IsShowMean", "0", ASDef._INI_FILE);
            }

            // 2014.09.02
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Histogram" + m_nToolIndex.ToString() + "_Init_SearchRegion_X", m_strInitSearchRegionX, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Histogram" + m_nToolIndex.ToString() + "_Init_SearchRegion_Y", m_strInitSearchRegionY, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Histogram" + m_nToolIndex.ToString() + "_Init_Mean", m_strInitMean, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Histogram" + m_nToolIndex.ToString() + "_Init_Median", m_strInitMedian, ASDef._INI_FILE);
        }

        public bool ShowRegion
        {
            get { return m_bShowRegion; }
            set { m_bShowRegion = (bool)value; }
        }

        public bool ShowMedian
        {
            get { return m_bShowMedian; }
            set { m_bShowMedian = (bool)value; }
        }

        public bool ShowMean
        {
            get { return m_bShowMean; }
            set { m_bShowMean = (bool)value; }
        }

        // 2014.09.02
        public string InitSearchRegionX
        {
            get { return m_strInitSearchRegionX; }
            set { m_strInitSearchRegionX = (string)value; }
        }
        public string InitSearchRegionY
        {
            get { return m_strInitSearchRegionY; }
            set { m_strInitSearchRegionY = (string)value; }
        }
        public string InitMean
        {
            get { return m_strInitMean; }
            set { m_strInitMean = (string)value; }
        }
        public string InitMedian
        {
            get { return m_strInitMedian; }
            set { m_strInitMedian = (string)value; }
        }
    }

    public class AIniBarcode
    {
        private int m_nType;
        private int m_nPoint;
        private int m_nToolIndex;
        private bool m_bShowRegion;

        public AIniBarcode(int nType, int nPoint, int nToolIndex)
        {
            m_nType = nType;
            m_nPoint = nPoint;
            m_nToolIndex = nToolIndex;
        }

        public void Read()
        {
            if (AUtil.GetPrivateProfileInt(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Barcode" + m_nToolIndex.ToString() + "_IsShowRegion", 1, ASDef._INI_FILE) == 1)
            {
                m_bShowRegion = true;
            }
            else
            {
                m_bShowRegion = false;
            }
        }

        public void Write()
        {            
            if (m_bShowRegion == true)
            {
                AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Barcode" + m_nToolIndex.ToString() + "_IsShowRegion", "1", ASDef._INI_FILE);
            }
            else
            {
                AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Barcode" + m_nToolIndex.ToString() + "_IsShowRegion", "0", ASDef._INI_FILE);
            }
        }

        public bool ShowRegion
        {
            get { return m_bShowRegion; }
            set { m_bShowRegion = (bool)value; }
        }
    }

    public class AIniToolBlock
    {
        private int m_nType;
        private int m_nPoint;
        private int m_nToolIndex;

        private string m_strInitX;
        private string m_strInitY;
        private string m_strInitAngle;

        private string m_strCalibCase;

        public AIniToolBlock(int nType, int nPoint, int nToolIndex)
        {
            m_nType = nType;
            m_nPoint = nPoint;
            m_nToolIndex = nToolIndex;
        }

        public void Read()
        {
            StringBuilder sb = new StringBuilder(32);

            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_ToolBlock" + m_nToolIndex.ToString() + "_Init_X", "0", sb, 32, ASDef._INI_FILE);
            m_strInitX = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_ToolBlock" + m_nToolIndex.ToString() + "_Init_Y", "0", sb, 32, ASDef._INI_FILE);
            m_strInitY = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_ToolBlock" + m_nToolIndex.ToString() + "_Init_Angle", "0", sb, 32, ASDef._INI_FILE);
            m_strInitAngle = sb.ToString();
            
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_ToolBlock" + m_nToolIndex.ToString() + "_CalibCase", "No Calib", sb, 32, ASDef._INI_FILE);
            m_strCalibCase = sb.ToString();
        }

        public void Write()
        {
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_ToolBlock" + m_nToolIndex.ToString() + "_Init_X", m_strInitX, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_ToolBlock" + m_nToolIndex.ToString() + "_Init_Y", m_strInitY, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_ToolBlock" + m_nToolIndex.ToString() + "_Init_Angle", m_strInitAngle, ASDef._INI_FILE);

            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_ToolBlock" + m_nToolIndex.ToString() + "_CalibCase", m_strCalibCase, ASDef._INI_FILE);
        }

        public string InitX
        {
            get { return m_strInitX; }
            set { m_strInitX = (string)value; }
        }

        public string InitY
        {
            get { return m_strInitY; }
            set { m_strInitY = (string)value; }
        }

        public string InitAngle
        {
            get { return m_strInitAngle; }
            set { m_strInitAngle = (string)value; }
        }

        public string CalibCase
        {
            get { return m_strCalibCase; }
            set { m_strCalibCase = (string)value; }
        }
    }

    // 2014.03.27
    public class AIniFindLine
    {
        private int m_nType;
        private int m_nPoint;
        private int m_nToolIndex;

        private string m_strInitX;
        private string m_strInitY;
        private string m_strInitAngle;
        
        private string m_strInitStartX;
        private string m_strInitStartY;
        private string m_strInitEndX;
        private string m_strInitEndY;
        
        private string m_strCalibCase;

        public AIniFindLine(int nType, int nPoint, int nToolIndex)
        {
            m_nType = nType;
            m_nPoint = nPoint;
            m_nToolIndex = nToolIndex;
        }

        public void Read()
        {
            StringBuilder sb = new StringBuilder(32);

            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindLine" + m_nToolIndex.ToString() + "_Init_X", "0", sb, 32, ASDef._INI_FILE);
            m_strInitX = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindLine" + m_nToolIndex.ToString() + "_Init_Y", "0", sb, 32, ASDef._INI_FILE);
            m_strInitY = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindLine" + m_nToolIndex.ToString() + "_Init_Angle", "0", sb, 32, ASDef._INI_FILE);
            m_strInitAngle = sb.ToString();

            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindLine" + m_nToolIndex.ToString() + "_Init_StartX", "0", sb, 32, ASDef._INI_FILE);
            m_strInitStartX = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindLine" + m_nToolIndex.ToString() + "_Init_StartY", "0", sb, 32, ASDef._INI_FILE);
            m_strInitStartY = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindLine" + m_nToolIndex.ToString() + "_Init_EndX", "0", sb, 32, ASDef._INI_FILE);
            m_strInitEndX = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindLine" + m_nToolIndex.ToString() + "_Init_EndY", "0", sb, 32, ASDef._INI_FILE);
            m_strInitEndY = sb.ToString();
            
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindLine" + m_nToolIndex.ToString() + "_CalibCase", "No Calib", sb, 32, ASDef._INI_FILE);
            m_strCalibCase = sb.ToString();
        }

        public void Write()
        {
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindLine" + m_nToolIndex.ToString() + "_Init_X", m_strInitX, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindLine" + m_nToolIndex.ToString() + "_Init_Y", m_strInitY, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindLine" + m_nToolIndex.ToString() + "_Init_Angle", m_strInitAngle, ASDef._INI_FILE);

            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindLine" + m_nToolIndex.ToString() + "_Init_StartX", m_strInitStartX, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindLine" + m_nToolIndex.ToString() + "_Init_StartY", m_strInitStartY, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindLine" + m_nToolIndex.ToString() + "_Init_EndX", m_strInitEndX, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindLine" + m_nToolIndex.ToString() + "_Init_EndY", m_strInitEndY, ASDef._INI_FILE);

            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindLine" + m_nToolIndex.ToString() + "_CalibCase", m_strCalibCase, ASDef._INI_FILE);
        }

        public string InitX
        {
            get { return m_strInitX; }
            set { m_strInitX = (string)value; }
        }

        public string InitY
        {
            get { return m_strInitY; }
            set { m_strInitY = (string)value; }
        }

        public string InitAngle
        {
            get { return m_strInitAngle; }
            set { m_strInitAngle = (string)value; }
        }

        public string InitStartX
        {
            get { return m_strInitStartX; }
            set { m_strInitStartX = (string)value; }
        }

        public string InitStartY
        {
            get { return m_strInitStartY; }
            set { m_strInitStartY = (string)value; }
        }

        public string InitEndX
        {
            get { return m_strInitEndX; }
            set { m_strInitEndX = (string)value; }
        }

        public string InitEndY
        {
            get { return m_strInitEndY; }
            set { m_strInitEndY = (string)value; }
        }


        public string CalibCase
        {
            get { return m_strCalibCase; }
            set { m_strCalibCase = (string)value; }
        }
    }

    // 2014.03.27
    public class AIniFindCircle
    {
        private int m_nType;
        private int m_nPoint;
        private int m_nToolIndex;

        private string m_strInitX;
        private string m_strInitY;
        private string m_strInitRadius;

        private string m_strCalibCase;

        public AIniFindCircle(int nType, int nPoint, int nToolIndex)
        {
            m_nType = nType;
            m_nPoint = nPoint;
            m_nToolIndex = nToolIndex;
        }

        public void Read()
        {
            StringBuilder sb = new StringBuilder(32);

            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindCircle" + m_nToolIndex.ToString() + "_Init_X", "0", sb, 32, ASDef._INI_FILE);
            m_strInitX = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindCircle" + m_nToolIndex.ToString() + "_Init_Y", "0", sb, 32, ASDef._INI_FILE);
            m_strInitY = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindCircle" + m_nToolIndex.ToString() + "_Init_Radius", "0", sb, 32, ASDef._INI_FILE);
            m_strInitRadius = sb.ToString();

            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindCircle" + m_nToolIndex.ToString() + "_CalibCase", "No Calib", sb, 32, ASDef._INI_FILE);
            m_strCalibCase = sb.ToString();
        }

        public void Write()
        {
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindCircle" + m_nToolIndex.ToString() + "_Init_X", m_strInitX, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindCircle" + m_nToolIndex.ToString() + "_Init_Y", m_strInitY, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindCircle" + m_nToolIndex.ToString() + "_Init_Radius", m_strInitRadius, ASDef._INI_FILE);

            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindCircle" + m_nToolIndex.ToString() + "_CalibCase", m_strCalibCase, ASDef._INI_FILE);
        }

        public string InitX
        {
            get { return m_strInitX; }
            set { m_strInitX = (string)value; }
        }

        public string InitY
        {
            get { return m_strInitY; }
            set { m_strInitY = (string)value; }
        }

        public string InitRadius
        {
            get { return m_strInitRadius; }
            set { m_strInitRadius = (string)value; }
        }

        public string CalibCase
        {
            get { return m_strCalibCase; }
            set { m_strCalibCase = (string)value; }
        }
    }

    // 2014.08.28
    public class AIniFindEllipse
    {
        private int m_nType;
        private int m_nPoint;
        private int m_nToolIndex;

        private string m_strInitX;
        private string m_strInitY;
        private string m_strInitRadiusX;
        private string m_strInitRadiusY;

        private string m_strCalibCase;

        public AIniFindEllipse(int nType, int nPoint, int nToolIndex)
        {
            m_nType = nType;
            m_nPoint = nPoint;
            m_nToolIndex = nToolIndex;
        }

        public void Read()
        {
            StringBuilder sb = new StringBuilder(32);

            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindEllipse" + m_nToolIndex.ToString() + "_Init_X", "0", sb, 32, ASDef._INI_FILE);
            m_strInitX = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindEllipse" + m_nToolIndex.ToString() + "_Init_Y", "0", sb, 32, ASDef._INI_FILE);
            m_strInitY = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindEllipse" + m_nToolIndex.ToString() + "_Init_RadiusX", "0", sb, 32, ASDef._INI_FILE);
            m_strInitRadiusX = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindEllipse" + m_nToolIndex.ToString() + "_Init_RadiusY", "0", sb, 32, ASDef._INI_FILE);
            m_strInitRadiusY = sb.ToString();

            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindEllipse" + m_nToolIndex.ToString() + "_CalibCase", "No Calib", sb, 32, ASDef._INI_FILE);
            m_strCalibCase = sb.ToString();
        }

        public void Write()
        {
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindEllipse" + m_nToolIndex.ToString() + "_Init_X", m_strInitX, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindEllipse" + m_nToolIndex.ToString() + "_Init_Y", m_strInitY, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindEllipse" + m_nToolIndex.ToString() + "_Init_RadiusX", m_strInitRadiusX, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindEllipse" + m_nToolIndex.ToString() + "_Init_RadiusY", m_strInitRadiusY, ASDef._INI_FILE);

            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindEllipse" + m_nToolIndex.ToString() + "_CalibCase", m_strCalibCase, ASDef._INI_FILE);
        }

        public string InitX
        {
            get { return m_strInitX; }
            set { m_strInitX = (string)value; }
        }

        public string InitY
        {
            get { return m_strInitY; }
            set { m_strInitY = (string)value; }
        }

        public string InitRadiusX
        {
            get { return m_strInitRadiusX; }
            set { m_strInitRadiusX = (string)value; }
        }

        public string InitRadiusY
        {
            get { return m_strInitRadiusY; }
            set { m_strInitRadiusY = (string)value; }
        }

        public string CalibCase
        {
            get { return m_strCalibCase; }
            set { m_strCalibCase = (string)value; }
        }
    }

    // 2014.08.28
    public class AIniFindCorner
    {
        private int m_nType;
        private int m_nPoint;
        private int m_nToolIndex;

        private string m_strInitX;
        private string m_strInitY;
        
        private string m_strCalibCase;

        public AIniFindCorner(int nType, int nPoint, int nToolIndex)
        {
            m_nType = nType;
            m_nPoint = nPoint;
            m_nToolIndex = nToolIndex;
        }

        public void Read()
        {
            StringBuilder sb = new StringBuilder(32);

            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindCorner" + m_nToolIndex.ToString() + "_Init_X", "0", sb, 32, ASDef._INI_FILE);
            m_strInitX = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindCorner" + m_nToolIndex.ToString() + "_Init_Y", "0", sb, 32, ASDef._INI_FILE);
            m_strInitY = sb.ToString();
            
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindCorner" + m_nToolIndex.ToString() + "_CalibCase", "No Calib", sb, 32, ASDef._INI_FILE);
            m_strCalibCase = sb.ToString();
        }

        public void Write()
        {
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindCorner" + m_nToolIndex.ToString() + "_Init_X", m_strInitX, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindCorner" + m_nToolIndex.ToString() + "_Init_Y", m_strInitY, ASDef._INI_FILE);
            
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_FindCorner" + m_nToolIndex.ToString() + "_CalibCase", m_strCalibCase, ASDef._INI_FILE);
        }

        public string InitX
        {
            get { return m_strInitX; }
            set { m_strInitX = (string)value; }
        }

        public string InitY
        {
            get { return m_strInitY; }
            set { m_strInitY = (string)value; }
        }

        public string CalibCase
        {
            get { return m_strCalibCase; }
            set { m_strCalibCase = (string)value; }
        }
    }

    // 2018.04.09
    public class AIniLineMax
    {
        private int m_nType;
        private int m_nPoint;
        private int m_nToolIndex;

        private string m_strInitX;
        private string m_strInitY;
        private string m_strInitAngle;

        private string m_strInitStartX;
        private string m_strInitStartY;
        private string m_strInitEndX;
        private string m_strInitEndY;

        private string m_strCalibCase;

        public AIniLineMax(int nType, int nPoint, int nToolIndex)
        {
            m_nType = nType;
            m_nPoint = nPoint;
            m_nToolIndex = nToolIndex;
        }

        public void Read()
        {
            StringBuilder sb = new StringBuilder(32);

            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_LineMax" + m_nToolIndex.ToString() + "_Init_X", "0", sb, 32, ASDef._INI_FILE);
            m_strInitX = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_LineMax" + m_nToolIndex.ToString() + "_Init_Y", "0", sb, 32, ASDef._INI_FILE);
            m_strInitY = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_LineMax" + m_nToolIndex.ToString() + "_Init_Angle", "0", sb, 32, ASDef._INI_FILE);
            m_strInitAngle = sb.ToString();

            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_LineMax" + m_nToolIndex.ToString() + "_Init_StartX", "0", sb, 32, ASDef._INI_FILE);
            m_strInitStartX = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_LineMax" + m_nToolIndex.ToString() + "_Init_StartY", "0", sb, 32, ASDef._INI_FILE);
            m_strInitStartY = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_LineMax" + m_nToolIndex.ToString() + "_Init_EndX", "0", sb, 32, ASDef._INI_FILE);
            m_strInitEndX = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_LineMax" + m_nToolIndex.ToString() + "_Init_EndY", "0", sb, 32, ASDef._INI_FILE);
            m_strInitEndY = sb.ToString();

            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_LineMax" + m_nToolIndex.ToString() + "_CalibCase", "No Calib", sb, 32, ASDef._INI_FILE);
            m_strCalibCase = sb.ToString();
        }

        public void Write()
        {
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_LineMax" + m_nToolIndex.ToString() + "_Init_X", m_strInitX, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_LineMax" + m_nToolIndex.ToString() + "_Init_Y", m_strInitY, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_LineMax" + m_nToolIndex.ToString() + "_Init_Angle", m_strInitAngle, ASDef._INI_FILE);

            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_LineMax" + m_nToolIndex.ToString() + "_Init_StartX", m_strInitStartX, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_LineMax" + m_nToolIndex.ToString() + "_Init_StartY", m_strInitStartY, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_LineMax" + m_nToolIndex.ToString() + "_Init_EndX", m_strInitEndX, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_LineMax" + m_nToolIndex.ToString() + "_Init_EndY", m_strInitEndY, ASDef._INI_FILE);

            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_LineMax" + m_nToolIndex.ToString() + "_CalibCase", m_strCalibCase, ASDef._INI_FILE);
        }

        public string InitX
        {
            get { return m_strInitX; }
            set { m_strInitX = (string)value; }
        }

        public string InitY
        {
            get { return m_strInitY; }
            set { m_strInitY = (string)value; }
        }

        public string InitAngle
        {
            get { return m_strInitAngle; }
            set { m_strInitAngle = (string)value; }
        }

        public string InitStartX
        {
            get { return m_strInitStartX; }
            set { m_strInitStartX = (string)value; }
        }

        public string InitStartY
        {
            get { return m_strInitStartY; }
            set { m_strInitStartY = (string)value; }
        }

        public string InitEndX
        {
            get { return m_strInitEndX; }
            set { m_strInitEndX = (string)value; }
        }

        public string InitEndY
        {
            get { return m_strInitEndY; }
            set { m_strInitEndY = (string)value; }
        }


        public string CalibCase
        {
            get { return m_strCalibCase; }
            set { m_strCalibCase = (string)value; }
        }
    }

    /* 2016.05.09
    // 2014.03.27
    public class AIniSearchMax
    {
        private int m_nType;
        private int m_nPoint;
        private int m_nToolIndex;

        private string m_strInitX;
        private string m_strInitY;
        private string m_strInitAngle;

        private string m_strCalibCase;

        public AIniSearchMax(int nType, int nPoint, int nToolIndex)
        {
            m_nType = nType;
            m_nPoint = nPoint;
            m_nToolIndex = nToolIndex;
        }

        public void Read()
        {
            StringBuilder sb = new StringBuilder(32);

            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_SearchMax" + m_nToolIndex.ToString() + "_Init_X", "0", sb, 32, ASDef._INI_FILE);
            m_strInitX = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_SearchMax" + m_nToolIndex.ToString() + "_Init_Y", "0", sb, 32, ASDef._INI_FILE);
            m_strInitY = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_SearchMax" + m_nToolIndex.ToString() + "_Init_Angle", "0", sb, 32, ASDef._INI_FILE);
            m_strInitAngle = sb.ToString();

            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_SearchMax" + m_nToolIndex.ToString() + "_CalibCase", "No Calib", sb, 32, ASDef._INI_FILE);
            m_strCalibCase = sb.ToString();
        }

        public void Write()
        {
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_SearchMax" + m_nToolIndex.ToString() + "_Init_X", m_strInitX, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_SearchMax" + m_nToolIndex.ToString() + "_Init_Y", m_strInitY, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_SearchMax" + m_nToolIndex.ToString() + "_Init_Angle", m_strInitAngle, ASDef._INI_FILE);

            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_SearchMax" + m_nToolIndex.ToString() + "_CalibCase", m_strCalibCase, ASDef._INI_FILE);
        }

        public string InitX
        {
            get { return m_strInitX; }
            set { m_strInitX = (string)value; }
        }

        public string InitY
        {
            get { return m_strInitY; }
            set { m_strInitY = (string)value; }
        }

        public string InitAngle
        {
            get { return m_strInitAngle; }
            set { m_strInitAngle = (string)value; }
        }

        public string CalibCase
        {
            get { return m_strCalibCase; }
            set { m_strCalibCase = (string)value; }
        }
    }
    */
    public class AIniSearchMax
    {
        private int m_nType;
        private int m_nPoint;
        private int m_nToolIndex;

        private string m_strInitX;
        private string m_strInitY;
        private string m_strInitAngle;

        private string m_strCalibCase;

        private string m_strInitSearchRegionX;
        private string m_strInitSearchRegionY;

        public AIniSearchMax(int nType, int nPoint, int nToolIndex)
        {
            m_nType = nType;
            m_nPoint = nPoint;
            m_nToolIndex = nToolIndex;
        }

        public void Read()
        {
            StringBuilder sb = new StringBuilder(32);

            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_SearchMax" + m_nToolIndex.ToString() + "_Init_X", "0", sb, 32, ASDef._INI_FILE);
            m_strInitX = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_SearchMax" + m_nToolIndex.ToString() + "_Init_Y", "0", sb, 32, ASDef._INI_FILE);
            m_strInitY = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_SearchMax" + m_nToolIndex.ToString() + "_Init_Angle", "0", sb, 32, ASDef._INI_FILE);
            m_strInitAngle = sb.ToString();

            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_SearchMax" + m_nToolIndex.ToString() + "_CalibCase", "No Calib", sb, 32, ASDef._INI_FILE);
            m_strCalibCase = sb.ToString();

            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_SearchMax" + m_nToolIndex.ToString() + "_Init_SearchRegion_X", "0", sb, 32, ASDef._INI_FILE);
            m_strInitSearchRegionX = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_SearchMax" + m_nToolIndex.ToString() + "_Init_SearchRegion_Y", "0", sb, 32, ASDef._INI_FILE);
            m_strInitSearchRegionY = sb.ToString();
        }

        public void Write()
        {
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_SearchMax" + m_nToolIndex.ToString() + "_Init_X", m_strInitX, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_SearchMax" + m_nToolIndex.ToString() + "_Init_Y", m_strInitY, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_SearchMax" + m_nToolIndex.ToString() + "_Init_Angle", m_strInitAngle, ASDef._INI_FILE);

            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_SearchMax" + m_nToolIndex.ToString() + "_CalibCase", m_strCalibCase, ASDef._INI_FILE);

            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_SearchMax" + m_nToolIndex.ToString() + "_Init_SearchRegion_X", m_strInitSearchRegionX, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_SearchMax" + m_nToolIndex.ToString() + "_Init_SearchRegion_Y", m_strInitSearchRegionY, ASDef._INI_FILE);
        }

        public string InitX
        {
            get { return m_strInitX; }
            set { m_strInitX = (string)value; }
        }

        public string InitY
        {
            get { return m_strInitY; }
            set { m_strInitY = (string)value; }
        }

        public string InitAngle
        {
            get { return m_strInitAngle; }
            set { m_strInitAngle = (string)value; }
        }
        public string CalibCase
        {
            get { return m_strCalibCase; }
            set { m_strCalibCase = (string)value; }
        }

        public string InitSearchRegionX
        {
            get { return m_strInitSearchRegionX; }
            set { m_strInitSearchRegionX = (string)value; }
        }
        public string InitSearchRegionY
        {
            get { return m_strInitSearchRegionY; }
            set { m_strInitSearchRegionY = (string)value; }
        }
    }

    public class AIniPMRedLine
    {
        private int m_nType;
        private int m_nPoint;
        private int m_nToolIndex;

        private string m_strInitX;
        private string m_strInitY;
        private string m_strInitAngle;

        private string m_strCalibCase;

        // 2014.08.27
        private string m_strInitSearchRegionX;
        private string m_strInitSearchRegionY;

        public AIniPMRedLine(int nType, int nPoint, int nToolIndex)
        {
            m_nType = nType;
            m_nPoint = nPoint;
            m_nToolIndex = nToolIndex;
        }

        public void Read()
        {
            StringBuilder sb = new StringBuilder(32);

            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_PMAlign" + m_nToolIndex.ToString() + "_Init_X", "0", sb, 32, ASDef._INI_FILE);
            m_strInitX = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_PMAlign" + m_nToolIndex.ToString() + "_Init_Y", "0", sb, 32, ASDef._INI_FILE);
            m_strInitY = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_PMAlign" + m_nToolIndex.ToString() + "_Init_Angle", "0", sb, 32, ASDef._INI_FILE);
            m_strInitAngle = sb.ToString();

            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_PMAlign" + m_nToolIndex.ToString() + "_CalibCase", "No Calib", sb, 32, ASDef._INI_FILE);
            m_strCalibCase = sb.ToString();

            // 2014.08.27
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_PMAlign" + m_nToolIndex.ToString() + "_Init_SearchRegion_X", "0", sb, 32, ASDef._INI_FILE);
            m_strInitSearchRegionX = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_PMAlign" + m_nToolIndex.ToString() + "_Init_SearchRegion_Y", "0", sb, 32, ASDef._INI_FILE);
            m_strInitSearchRegionY = sb.ToString();
        }

        public void Write()
        {
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_PMAlign" + m_nToolIndex.ToString() + "_Init_X", m_strInitX, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_PMAlign" + m_nToolIndex.ToString() + "_Init_Y", m_strInitY, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_PMAlign" + m_nToolIndex.ToString() + "_Init_Angle", m_strInitAngle, ASDef._INI_FILE);

            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_PMAlign" + m_nToolIndex.ToString() + "_CalibCase", m_strCalibCase, ASDef._INI_FILE);

            // 2014.08.27
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_PMAlign" + m_nToolIndex.ToString() + "_Init_SearchRegion_X", m_strInitSearchRegionX, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_PMAlign" + m_nToolIndex.ToString() + "_Init_SearchRegion_Y", m_strInitSearchRegionY, ASDef._INI_FILE);
        }

        public string InitX
        {
            get { return m_strInitX; }
            set { m_strInitX = (string)value; }
        }

        public string InitY
        {
            get { return m_strInitY; }
            set { m_strInitY = (string)value; }
        }

        public string InitAngle
        {
            get { return m_strInitAngle; }
            set { m_strInitAngle = (string)value; }
        }
        public string CalibCase
        {
            get { return m_strCalibCase; }
            set { m_strCalibCase = (string)value; }
        }

        // 2014.08.27
        public string InitSearchRegionX
        {
            get { return m_strInitSearchRegionX; }
            set { m_strInitSearchRegionX = (string)value; }
        }
        public string InitSearchRegionY
        {
            get { return m_strInitSearchRegionY; }
            set { m_strInitSearchRegionY = (string)value; }
        }
    }

    public class AIniLight
    {
        private int m_nType;
        private int m_nPoint;

        public string m_strIndex;
        public string m_strChannel;
        public string[] m_pstrExposure = new string[3];
        public string[] m_pstrLed = new string[3];

        public AIniLight(int nType, int nPoint)
        {
            m_nType = nType;
            m_nPoint = nPoint;
        }

        public void Set(int nType, int nPoint)
        {
            m_nType = nType;
            m_nPoint = nPoint;
        }

        public void Read()
        {
            StringBuilder sb = new StringBuilder(32);

            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Light_Index", "0", sb, 32, ASDef._INI_FILE);
            m_strIndex = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Light_Channel", "1", sb, 32, ASDef._INI_FILE);
            m_strChannel = sb.ToString();
            for (int i = 0; i < 3; i++)
            {
                AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Light_Exposure" + i.ToString(), "1", sb, 32, ASDef._INI_FILE);
                m_pstrExposure[i] = sb.ToString();
                // 2014.06.25 100->46
                AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Light_Led" + i.ToString(), "46", sb, 32, ASDef._INI_FILE);
                m_pstrLed[i] = sb.ToString();
            }
            
        }

        public void Write()
        {
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Light_Index", m_strIndex, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Light_Channel", m_strChannel, ASDef._INI_FILE);
            for (int i = 0; i < 3; i++)
            {
                AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Light_Exposure" + i.ToString(), m_pstrExposure[i], ASDef._INI_FILE);
                AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Light_Led" + i.ToString(), m_pstrLed[i], ASDef._INI_FILE);
            }
        }
    }

    // 2013.12.27
	public class AIniLight4
    {
        private int m_nType;
        private int m_nPoint;

        // 2012.03.28
        public string[] m_pstrIndex = new string[4];
        public string[] m_pstrChannel = new string[4];

        public string[] m_pstrExposure = new string[3];
        // 2012.03.28
        public string[,] m_ppstrLed = new string[4, 3];

        public AIniLight4(int nType, int nPoint)
        {
            m_nType = nType;
            m_nPoint = nPoint;
        }

        public void Set(int nType, int nPoint)
        {
            m_nType = nType;
            m_nPoint = nPoint;
        }

        public void Read()
        {
            StringBuilder sb = new StringBuilder(32);

            // 2011.09.18
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Light_Index", "0", sb, 32, ASDef._INI_FILE);
            m_pstrIndex[0] = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Light_Channel", "1", sb, 32, ASDef._INI_FILE);
            m_pstrChannel[0] = sb.ToString();

            // 2012.03.28
            for (int i = 1; i <= 3; i++)
            {
                AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Light_Index_s" + i.ToString(), "-1", sb, 32, ASDef._INI_FILE);
                m_pstrIndex[i] = sb.ToString();
                AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Light_Channel_s" + i.ToString(), "1", sb, 32, ASDef._INI_FILE);
                m_pstrChannel[i] = sb.ToString();
            }

            for (int i = 0; i < 3; i++)
            {
                AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Light_Exposure" + i.ToString(), "1", sb, 32, ASDef._INI_FILE);
                m_pstrExposure[i] = sb.ToString();
                // 2014.06.25 100->46
                AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Light_Led" + i.ToString(), "46", sb, 32, ASDef._INI_FILE);
                m_ppstrLed[0, i] = sb.ToString();

                
                // 2011.09.18
                for (int j = 1; j <= 3; j++)
                {
                    // 2014.06.25 100->46
                    AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Light_Led" + i.ToString() + "_s" + j.ToString(), "46", sb, 32, ASDef._INI_FILE);
                    m_ppstrLed[j, i] = sb.ToString();
                }
            }
            
        }

        public void Write()
        {
            // 2011.09.18
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Light_Index", m_pstrIndex[0], ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Light_Channel", m_pstrChannel[0], ASDef._INI_FILE);

            // 2012.03.28
            for (int i = 1; i <= 3; i++)
            {
                AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Light_Index_s" + i.ToString(), m_pstrIndex[i], ASDef._INI_FILE);
                AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Light_Channel_s" + i.ToString(), m_pstrChannel[i], ASDef._INI_FILE);
            }
            for (int i = 0; i < 3; i++)
            {
                AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Light_Exposure" + i.ToString(), m_pstrExposure[i], ASDef._INI_FILE);
                // 2011.09.18
                AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Light_Led" + i.ToString(), m_ppstrLed[0, i], ASDef._INI_FILE);
                // 2012.03.28
                for (int j = 1; j <= 3; j++)
                {
                    AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Light_Led" + i.ToString() + "_s" + j.ToString(), m_ppstrLed[j, i], ASDef._INI_FILE);
                }
            }
        }
    }

    // 2014.11.07
    public class AIniLight_1
    {
        public string m_strIndex;
        public string m_strChannel;
        public string[] m_pstrExposure = new string[3];
        public string[] m_pstrLed = new string[3];

        public void Read()
        {
            StringBuilder sb = new StringBuilder(32);

            AUtil.GetPrivateProfileString("1Camera", "Light_Index", "0", sb, 32, ASDef._INI_FILE);
            m_strIndex = sb.ToString();
            AUtil.GetPrivateProfileString("1Camera", "Light_Channel", "1", sb, 32, ASDef._INI_FILE);
            m_strChannel = sb.ToString();
            for (int i = 0; i < 3; i++)
            {
                AUtil.GetPrivateProfileString("1Camera", "Light_Exposure" + i.ToString(), "1", sb, 32, ASDef._INI_FILE);
                m_pstrExposure[i] = sb.ToString();
                // 2014.06.25 100->46
                AUtil.GetPrivateProfileString("1Camera", "Light_Led" + i.ToString(), "46", sb, 32, ASDef._INI_FILE);
                m_pstrLed[i] = sb.ToString();
            }

        }

        public void Write()
        {
            AUtil.WritePrivateProfileString("1Camera", "Light_Index", m_strIndex, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString("1Camera", "Light_Channel", m_strChannel, ASDef._INI_FILE);
            for (int i = 0; i < 3; i++)
            {
                AUtil.WritePrivateProfileString("1Camera", "Light_Exposure" + i.ToString(), m_pstrExposure[i], ASDef._INI_FILE);
                AUtil.WritePrivateProfileString("1Camera", "Light_Led" + i.ToString(), m_pstrLed[i], ASDef._INI_FILE);
            }
        }
    }

    // 2014.11.07
    public class AIniLight4_1
    {

        public string[] m_pstrIndex = new string[4];
        public string[] m_pstrChannel = new string[4];

        public string[] m_pstrExposure = new string[3];
        public string[,] m_ppstrLed = new string[4, 3];

        
        public void Read()
        {
            StringBuilder sb = new StringBuilder(32);

            AUtil.GetPrivateProfileString("1Camera", "Light_Index", "0", sb, 32, ASDef._INI_FILE);
            m_pstrIndex[0] = sb.ToString();
            AUtil.GetPrivateProfileString("1Camera", "Light_Channel", "1", sb, 32, ASDef._INI_FILE);
            m_pstrChannel[0] = sb.ToString();

            for (int i = 1; i <= 3; i++)
            {
                AUtil.GetPrivateProfileString("1Camera", "Light_Index_s" + i.ToString(), "-1", sb, 32, ASDef._INI_FILE);
                m_pstrIndex[i] = sb.ToString();
                AUtil.GetPrivateProfileString("1Camera", "Light_Channel_s" + i.ToString(), "1", sb, 32, ASDef._INI_FILE);
                m_pstrChannel[i] = sb.ToString();
            }

            for (int i = 0; i < 3; i++)
            {
                AUtil.GetPrivateProfileString("1Camera", "Light_Exposure" + i.ToString(), "1", sb, 32, ASDef._INI_FILE);
                m_pstrExposure[i] = sb.ToString();
                AUtil.GetPrivateProfileString("1Camera", "Light_Led" + i.ToString(), "46", sb, 32, ASDef._INI_FILE);
                m_ppstrLed[0, i] = sb.ToString();

                for (int j = 1; j <= 3; j++)
                {
                    AUtil.GetPrivateProfileString("1Camera", "Light_Led" + i.ToString() + "_s" + j.ToString(), "46", sb, 32, ASDef._INI_FILE);
                    m_ppstrLed[j, i] = sb.ToString();
                }
            }

        }

        public void Write()
        {
            AUtil.WritePrivateProfileString("1Camera", "Light_Index", m_pstrIndex[0], ASDef._INI_FILE);
            AUtil.WritePrivateProfileString("1Camera", "Light_Channel", m_pstrChannel[0], ASDef._INI_FILE);

            for (int i = 1; i <= 3; i++)
            {
                AUtil.WritePrivateProfileString("1Camera", "Light_Index_s" + i.ToString(), m_pstrIndex[i], ASDef._INI_FILE);
                AUtil.WritePrivateProfileString("1Camera", "Light_Channel_s" + i.ToString(), m_pstrChannel[i], ASDef._INI_FILE);
            }
            for (int i = 0; i < 3; i++)
            {
                AUtil.WritePrivateProfileString("1Camera", "Light_Exposure" + i.ToString(), m_pstrExposure[i], ASDef._INI_FILE);
                AUtil.WritePrivateProfileString("1Camera", "Light_Led" + i.ToString(), m_ppstrLed[0, i], ASDef._INI_FILE);
                for (int j = 1; j <= 3; j++)
                {
                    AUtil.WritePrivateProfileString("1Camera", "Light_Led" + i.ToString() + "_s" + j.ToString(), m_ppstrLed[j, i], ASDef._INI_FILE);
                }
            }
        }
    }

    public class AIniMux
    {
        private int m_nType;
        private int m_nPoint;

        public string m_strIndex;
        public string m_strChannel;

        public AIniMux(int nType, int nPoint)
        {
            m_nType = nType;
            m_nPoint = nPoint;
        }

        public void Set(int nType, int nPoint)
        {
            m_nType = nType;
            m_nPoint = nPoint;
        }

        public void Read()
        {
            StringBuilder sb = new StringBuilder(32);

            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Mux_Index", "0", sb, 32, ASDef._INI_FILE);
            m_strIndex = sb.ToString();
            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Mux_Channel", "1", sb, 32, ASDef._INI_FILE);
            m_strChannel = sb.ToString();
        }

        public void Write()
        {
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Mux_Index", m_strIndex, ASDef._INI_FILE);
            AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Mux_Channel", m_strChannel, ASDef._INI_FILE);
        }
    }

    public class AIniUse
    {
        private int m_nType;
        private int m_nPoint;

        public bool m_bUse;

        public AIniUse(int nType, int nPoint)
        {
            m_nType = nType;
            m_nPoint = nPoint;
        }

        public void Set(int nType, int nPoint)
        {
            m_nType = nType;
            m_nPoint = nPoint;
        }

        public void Read()
        {
            StringBuilder sb = new StringBuilder(32);

            AUtil.GetPrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Use", "1", sb, 32, ASDef._INI_FILE);
            if (sb.ToString() == "0")
                m_bUse = false;
            else
                m_bUse = true;
           
        }

        public void Write()
        {
            if (m_bUse)
                AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Use", "1", ASDef._INI_FILE);
            else
                AUtil.WritePrivateProfileString(AVisionProBuild.GetTypeName(m_nType), "Point" + m_nPoint.ToString() + "_Use", "0", ASDef._INI_FILE);
        }
    }

    public class AIniExposure
    {
        private string m_strType;
        private int m_nPoint;

        // 2015.12.08 int64->double
        public double m_dExposure;

        public AIniExposure(int nType, int nPoint)
        {
            m_strType = AVisionProBuild.GetTypeName(nType);
            m_nPoint = nPoint;
        }

        public AIniExposure(string strType, int nPoint)
        {
            m_strType = strType;
            m_nPoint = nPoint;
        }

        public void Set(string strType, int nPoint)
        {
            m_strType = strType;
            m_nPoint = nPoint;
        }

        public void Read()
        {
            StringBuilder sb = new StringBuilder(32);

            // 2013.03.29 35000->1
            AUtil.GetPrivateProfileString(m_strType, "Point" + m_nPoint.ToString() + "_Exposure", "1", sb, 32, ASDef._INI_FILE);
            m_dExposure = Convert.ToDouble(sb.ToString());
        }

        public void Write()
        {
            AUtil.WritePrivateProfileString(m_strType, "Point" + m_nPoint.ToString() + "_Exposure", m_dExposure.ToString("0.0"), ASDef._INI_FILE);
        }
    }
}
