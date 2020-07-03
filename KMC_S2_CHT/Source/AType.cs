//#define _USE_BASLER_PYLON
//#define _USE_IMAGING_CONTROL
// 2015.10.06
//#define _USE_1Camera

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using Cognex.VisionPro;
using Cognex.VisionPro.ToolGroup;
using Atmc;
using System.Windows.Forms;

namespace AVisionPro
{
    public class AType
    {
        private int m_nPointCount;
        public CogToolGroup m_cogtgType;
// 2016.06.20
//#if !_USE_1Camera
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL && !_USE_FLIR && !_USE_1Camera)
        // 2015.10.02 by kdi
        public CogToolGroup m_cogtgType_Acq;
#endif
        public List<APoint> m_lstAPoint = new List<APoint>();

        // 2011.06.23
        public ASDef._stRobotShift[] m_pstLimitLow;
        public ASDef._stRobotShift[] m_pstLimitHigh;

        public ASDef._stRobotShift[] m_pstOffset;
        // 2011.06.23
        private string m_strPlcToPc;

        // 2014.11.04
        private bool m_bUse;

        
        public AType(string strName, int nPointCount)
        {
            m_cogtgType = new CogToolGroup();
            m_cogtgType.Name = strName;
// 2016.06.20
//#if !_USE_1Camera
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL && !_USE_FLIR && !_USE_1Camera)
            // 2015.10.02 by kdi
            m_cogtgType_Acq = new CogToolGroup();
            m_cogtgType_Acq.Name = strName;
#endif            
            m_nPointCount = nPointCount;
            // 2014.11.04
            m_bUse = false;

            Init(true);
        }

        public AType(string strName)
        {
            m_cogtgType = new CogToolGroup();
            m_cogtgType.Name = strName;
// 2016.06.20
//#if !_USE_1Camera
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL && !_USE_FLIR && !_USE_1Camera)
            // 2015.10.02 by kdi
            m_cogtgType_Acq = new CogToolGroup();
            m_cogtgType_Acq.Name = strName;
#endif
            LoadVpp();
            m_nPointCount = m_cogtgType.Tools.Count;
            // 2014.11.04
            m_bUse = false;

            Init(false);
        }

        private void ReLoad()
        {
            m_lstAPoint.Clear();
            Init(false);
        }

        public void Init(bool bNew)
        {
            // 2011.06.23
            m_pstLimitLow = new ASDef._stRobotShift[ASDef._LIMIT_COUNT];
            m_pstLimitHigh = new ASDef._stRobotShift[ASDef._LIMIT_COUNT];

            m_pstOffset = new ASDef._stRobotShift[ASDef._OFFSET_COUNT]; 

            StringBuilder sb = new StringBuilder(256);

            int i;
            for (i = 0; i < m_nPointCount; ++i)
            {
                if (bNew)
                {
					// 2018.01.18 by kdi
                    APoint aPoint = new APoint("Point" + i.ToString(), false);
                    m_lstAPoint.Add(aPoint);
                    m_cogtgType.Tools.Add(aPoint.GetToolGroupPoint() as ICogTool);
// 2016.06.20
//#if !_USE_1Camera
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL && !_USE_FLIR && !_USE_1Camera)
                    // 2015.10.02 by kdi.
                    APoint aPoint_Acq = new APoint("Point" + i.ToString(), true);
                    m_cogtgType_Acq.Tools.Add(aPoint_Acq.GetToolGroupPoint() as ICogTool);
                    aPoint.SetAcqFifo(m_cogtgType_Acq.Tools[i] as CogToolGroup);
#endif
                    // 2013.02.03
                    AUtil.GetPrivateProfileString(m_cogtgType.Name, "Point" + i.ToString() + "_FlipRotation", "0", sb, 10, ASDef._INI_FILE);
                    aPoint.m_nFlipRotation = Convert.ToInt32(sb.ToString());
                    AUtil.WritePrivateProfileString(m_cogtgType.Name, "Point" + i.ToString() + "_FlipRotation", aPoint.m_nFlipRotation.ToString(), ASDef._INI_FILE);

// 2018.01.18 by kdi #if _USE_BASLER_PYLON
                    // 2012.01.02
                    AUtil.GetPrivateProfileString(m_cogtgType.Name, "Dev_Point" + i.ToString(), aPoint.Name, sb, 255, ASDef._INI_FILE);
                    aPoint.m_strDevName = sb.ToString();
                    //AUtil.WritePrivateProfileString(m_cogtgType.Name, "Dev_Point" + i.ToString(), aPoint.m_strDevName, ASDef._INI_FILE);
// 2018.01.18 by kdi #endif
                }
                else
                {
                    APoint aPoint = new APoint(m_cogtgType.Tools[i] as CogToolGroup);
// 2016.06.20
//#if !_USE_1Camera
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL && !_USE_FLIR && !_USE_1Camera)
                    // 2015.10.06
                    if (m_cogtgType_Acq.Tools.Count > i)
                    {
                        // 2015.10.02 by kdi
                        aPoint.SetAcqFifo(m_cogtgType_Acq.Tools[i] as CogToolGroup);
                    }
                    else
                    {
                        APoint aPoint_Acq = new APoint("Point" + i.ToString(), true);
                        m_cogtgType_Acq.Tools.Add(aPoint_Acq.GetToolGroupPoint() as ICogTool);
                        aPoint.SetAcqFifo(m_cogtgType_Acq.Tools[i] as CogToolGroup);
                    }
#endif
                        m_lstAPoint.Add(aPoint);

                    // 2013.02.03
                    AUtil.GetPrivateProfileString(m_cogtgType.Name, "Point" + i.ToString() + "_FlipRotation", "0", sb, 10, ASDef._INI_FILE);
                    aPoint.m_nFlipRotation = Convert.ToInt32(sb.ToString());
                    AUtil.WritePrivateProfileString(m_cogtgType.Name, "Point" + i.ToString() + "_FlipRotation", aPoint.m_nFlipRotation.ToString(), ASDef._INI_FILE);

/* 2013.04.12
                    // 2012.04.24
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL)
                    AAcqFifo aAcqFifo = aPoint.GetTool("AcqFifo", 0) as AAcqFifo;
                    if (aAcqFifo != null)
                    {
                        // 2012.05.08
                        if (aAcqFifo.AcqFifoTool.Operator != null)
                        {
                            if (aAcqFifo.GetFrameGrabberName().Contains("acA2500"))
                            {
                                AIniExposure aIniExposure = new AIniExposure(m_cogtgType.Name, i);
                                aIniExposure.Read();
                                aAcqFifo.Exposure = Convert.ToDouble(aIniExposure.m_nExposure);
                            }
                        }
                    }

#elif _USE_BASLER_PYLON
*/
// 2018.01.18 by kdi #if _USE_BASLER_PYLON
                    // 2012.01.02
                    //AUtil.GetPrivateProfileString(m_cogtgType.Name, "Dev_" + aPoint.Name, aPoint.Name, sb, 255, ASDef._INI_FILE);
                    AUtil.GetPrivateProfileString(m_cogtgType.Name, "Dev_Point" + i.ToString(), aPoint.Name, sb, 255, ASDef._INI_FILE);
                    aPoint.m_strDevName = sb.ToString();
                    //AUtil.WritePrivateProfileString(m_cogtgType.Name, "Dev_" + aPoint.Name, aPoint.m_strDevName, ASDef._INI_FILE);
					
					// 2016.09.30 by kdi
                    AUtil.GetPrivateProfileString(m_cogtgType.Name, "Point" + i.ToString() + "_PixelFormat", "Mono 8", sb, 100, ASDef._INI_FILE);
                    aPoint.m_strPixelFormat = sb.ToString();
					
// 2018.01.18 by kdi #endif
                }
                
            }

            for (i = 0; i < ASDef._OFFSET_COUNT; ++i)
            {
                ReadIniOffset(i);
            }
            // 2011.06.23
            for (i = 0; i < ASDef._LIMIT_COUNT; ++i)
            {
                ReadIniLimit(i);
            }
            ReadIniPlcToPc();

            // 2014.11.04
            ReadIniUse();
        }

        public string Name
        {
            get { return m_cogtgType.Name; }
            set 
            { 
                m_cogtgType.Name = value.ToString();
// 2016.06.20
//#if !_USE_1Camera
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL && !_USE_FLIR && !_USE_1Camera)
                // 2015.10.02 by kdi
                m_cogtgType_Acq.Name = m_cogtgType.Name;
#endif
            }
        }

        public int PointCount        
        {
            get { return m_nPointCount; }
            set { m_nPointCount = (int)value; }
        }
        // 2011.06.23
        public string PlcToPc        
        {
            get { return m_strPlcToPc; }
            set { m_strPlcToPc = value.ToString(); }
        }

        public bool isUse
        {
            get { return m_bUse; }
            set { m_bUse = (bool)value; }
        }

        public bool LoadVpp(string strVppName) // load vpp file
        {
            try
            {
                m_cogtgType = CogSerializer.LoadObjectFromFile(strVppName) as Cognex.VisionPro.ToolGroup.CogToolGroup;
// 2016.06.20
//#if !_USE_1Camera
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL && !_USE_FLIR && !_USE_1Camera)
                //** 2015.10.02 by kdi
                string strFolderName = Path.GetDirectoryName(strVppName);
                string strOnlyFileName = Path.GetFileNameWithoutExtension(strVppName);
                string strExtName = Path.GetExtension(strVppName);
                string strAcqVppName = strFolderName + "\\" + strOnlyFileName + "_CAM" + strExtName;
                m_cogtgType_Acq = CogSerializer.LoadObjectFromFile(strAcqVppName) as Cognex.VisionPro.ToolGroup.CogToolGroup;
                //*/
#endif
                return true;
            }
            catch
            {
                // 2014.07.15
                AUtil.TopMostMessageBox.Show(strVppName + " File Load Error!");
                return false;
            }
        }

        public bool LoadVpp()
        {
            return LoadVpp(ASDef._INI_PATH + "\\" + Name + ".Vpp");
        }

        public bool SaveVpp(string strVppName)
        {
            try
            {
                // 2011.04.13
                //CogSerializer.SaveObjectToFile(m_cogtgType, strVppName, typeof(System.Runtime.Serialization.Formatters.Soap.SoapFormatter), CogSerializationOptionsConstants.Minimum);
                CogSerializer.SaveObjectToFile(m_cogtgType, strVppName, typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.Minimum);
// 2016.06.20
//#if !_USE_1Camera
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL && !_USE_FLIR && !_USE_1Camera)
                //** 2015.10.02 by kdi
                string strFolderName = Path.GetDirectoryName(strVppName);
                string strOnlyFileName = Path.GetFileNameWithoutExtension(strVppName);
                string strExtName = Path.GetExtension(strVppName);
                string strAcqVppName = strFolderName + "\\" + strOnlyFileName + "_CAM" + strExtName;
                CogSerializer.SaveObjectToFile(m_cogtgType_Acq, strAcqVppName, typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.Minimum);
                //*/
#endif
                ReLoad();

                return true;
            }
            catch
            {
                MessageBox.Show(strVppName + " File Save Error!");
                return false;
            }
        }

        public bool SaveVpp()
        {
            return SaveVpp(ASDef._INI_PATH + "\\" + Name + ".Vpp");
        }
// 2016.06.20
//#if !_USE_1Camera
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL && !_USE_FLIR && !_USE_1Camera)
        // 2015.10.02 by kdi
        public void SetPointNameOfAcq(int nIndex, string strName)
        {
            if (nIndex < m_cogtgType_Acq.Tools.Count)
                m_cogtgType_Acq.Tools[nIndex].Name = strName;
        }
#endif
        public APoint GetPoint(int nIndex)
        {
            return m_lstAPoint[nIndex];
        }
        // 2011.06.23
        public void WriteIniLimit(int nCount)
        {
            try
            {
                // 2012.02.08
                AUtil.WritePrivateProfileString(Name, "Limit" + nCount.ToString() + "_Low_X", m_pstLimitLow[nCount].dX.ToString(), ASDef._INI_FILE);
                AUtil.WritePrivateProfileString(Name, "Limit" + nCount.ToString() + "_Low_Y", m_pstLimitLow[nCount].dY.ToString(), ASDef._INI_FILE);
                AUtil.WritePrivateProfileString(Name, "Limit" + nCount.ToString() + "_Low_Z", m_pstLimitLow[nCount].dZ.ToString(), ASDef._INI_FILE);
                AUtil.WritePrivateProfileString(Name, "Limit" + nCount.ToString() + "_Low_AX", m_pstLimitLow[nCount].dAX.ToString(), ASDef._INI_FILE);
                AUtil.WritePrivateProfileString(Name, "Limit" + nCount.ToString() + "_Low_AY", m_pstLimitLow[nCount].dAY.ToString(), ASDef._INI_FILE);
                AUtil.WritePrivateProfileString(Name, "Limit" + nCount.ToString() + "_Low_AZ", m_pstLimitLow[nCount].dAZ.ToString(), ASDef._INI_FILE);

                AUtil.WritePrivateProfileString(Name, "Limit" + nCount.ToString() + "_High_X", m_pstLimitHigh[nCount].dX.ToString(), ASDef._INI_FILE);
                AUtil.WritePrivateProfileString(Name, "Limit" + nCount.ToString() + "_High_Y", m_pstLimitHigh[nCount].dY.ToString(), ASDef._INI_FILE);
                AUtil.WritePrivateProfileString(Name, "Limit" + nCount.ToString() + "_High_Z", m_pstLimitHigh[nCount].dZ.ToString(), ASDef._INI_FILE);
                AUtil.WritePrivateProfileString(Name, "Limit" + nCount.ToString() + "_High_AX", m_pstLimitHigh[nCount].dAX.ToString(), ASDef._INI_FILE);
                AUtil.WritePrivateProfileString(Name, "Limit" + nCount.ToString() + "_High_AY", m_pstLimitHigh[nCount].dAY.ToString(), ASDef._INI_FILE);
                AUtil.WritePrivateProfileString(Name, "Limit" + nCount.ToString() + "_High_AZ", m_pstLimitHigh[nCount].dAZ.ToString(), ASDef._INI_FILE);
            }
            catch
            {

            }
        }
        // 2011.06.23
        public void ReadIniLimit(int nCount)
        {
            try
            {
                // 2011.05.24
                StringBuilder sb = new StringBuilder(32);

                // 2012.02.08
                AUtil.GetPrivateProfileString(Name, "Limit" + nCount.ToString() + "_Low_X", "-100", sb, 32, ASDef._INI_FILE);
                m_pstLimitLow[nCount].dX = Convert.ToDouble(sb.ToString());
                AUtil.GetPrivateProfileString(Name, "Limit" + nCount.ToString() + "_Low_Y", "-100", sb, 32, ASDef._INI_FILE);
                m_pstLimitLow[nCount].dY = Convert.ToDouble(sb.ToString());
                AUtil.GetPrivateProfileString(Name, "Limit" + nCount.ToString() + "_Low_Z", "-100", sb, 32, ASDef._INI_FILE);
                m_pstLimitLow[nCount].dZ = Convert.ToDouble(sb.ToString());
                AUtil.GetPrivateProfileString(Name, "Limit" + nCount.ToString() + "_Low_AX", "-10", sb, 32, ASDef._INI_FILE);
                m_pstLimitLow[nCount].dAX = Convert.ToDouble(sb.ToString());
                AUtil.GetPrivateProfileString(Name, "Limit" + nCount.ToString() + "_Low_AY", "-10", sb, 32, ASDef._INI_FILE);
                m_pstLimitLow[nCount].dAY = Convert.ToDouble(sb.ToString());
                AUtil.GetPrivateProfileString(Name, "Limit" + nCount.ToString() + "_Low_AZ", "-10", sb, 32, ASDef._INI_FILE);
                m_pstLimitLow[nCount].dAZ = Convert.ToDouble(sb.ToString());

                AUtil.GetPrivateProfileString(Name, "Limit" + nCount.ToString() + "_High_X", "100", sb, 32, ASDef._INI_FILE);
                m_pstLimitHigh[nCount].dX = Convert.ToDouble(sb.ToString());
                AUtil.GetPrivateProfileString(Name, "Limit" + nCount.ToString() + "_High_Y", "100", sb, 32, ASDef._INI_FILE);
                m_pstLimitHigh[nCount].dY = Convert.ToDouble(sb.ToString());
                AUtil.GetPrivateProfileString(Name, "Limit" + nCount.ToString() + "_High_Z", "100", sb, 32, ASDef._INI_FILE);
                m_pstLimitHigh[nCount].dZ = Convert.ToDouble(sb.ToString());
                AUtil.GetPrivateProfileString(Name, "Limit" + nCount.ToString() + "_High_AX", "10", sb, 32, ASDef._INI_FILE);
                m_pstLimitHigh[nCount].dAX = Convert.ToDouble(sb.ToString());
                AUtil.GetPrivateProfileString(Name, "Limit" + nCount.ToString() + "_High_AY", "10", sb, 32, ASDef._INI_FILE);
                m_pstLimitHigh[nCount].dAY = Convert.ToDouble(sb.ToString());
                AUtil.GetPrivateProfileString(Name, "Limit" + nCount.ToString() + "_High_AZ", "10", sb, 32, ASDef._INI_FILE);
                m_pstLimitHigh[nCount].dAZ = Convert.ToDouble(sb.ToString());
            }
            catch
            {

            }
        }

        public void WriteIniOffset(int nCount)
        {
            try
            {
                AUtil.WritePrivateProfileString(Name, "Offset" + nCount.ToString() + "_X", m_pstOffset[nCount].dX.ToString(), ASDef._INI_FILE);
                AUtil.WritePrivateProfileString(Name, "Offset" + nCount.ToString() + "_Y", m_pstOffset[nCount].dY.ToString(), ASDef._INI_FILE);
                AUtil.WritePrivateProfileString(Name, "Offset" + nCount.ToString() + "_Z", m_pstOffset[nCount].dZ.ToString(), ASDef._INI_FILE);
                AUtil.WritePrivateProfileString(Name, "Offset" + nCount.ToString() + "_AX", m_pstOffset[nCount].dAX.ToString(), ASDef._INI_FILE);
                AUtil.WritePrivateProfileString(Name, "Offset" + nCount.ToString() + "_AY", m_pstOffset[nCount].dAY.ToString(), ASDef._INI_FILE);
                AUtil.WritePrivateProfileString(Name, "Offset" + nCount.ToString() + "_AZ", m_pstOffset[nCount].dAZ.ToString(), ASDef._INI_FILE);
            }
            catch
            {

            }
        }

        public void ReadIniOffset(int nCount)
        {
            try
            {
                // 2011.05.24 
                StringBuilder sb = new StringBuilder(32);

                AUtil.GetPrivateProfileString(Name, "Offset" + nCount.ToString() + "_X", "0", sb, 32, ASDef._INI_FILE);
                m_pstOffset[nCount].dX = Convert.ToDouble(sb.ToString());
                AUtil.GetPrivateProfileString(Name, "Offset" + nCount.ToString() + "_Y", "0", sb, 32, ASDef._INI_FILE);
                m_pstOffset[nCount].dY = Convert.ToDouble(sb.ToString());
                AUtil.GetPrivateProfileString(Name, "Offset" + nCount.ToString() + "_Z", "0", sb, 32, ASDef._INI_FILE);
                m_pstOffset[nCount].dZ = Convert.ToDouble(sb.ToString());
                AUtil.GetPrivateProfileString(Name, "Offset" + nCount.ToString() + "_AX", "0", sb, 32, ASDef._INI_FILE);
                m_pstOffset[nCount].dAX = Convert.ToDouble(sb.ToString());
                AUtil.GetPrivateProfileString(Name, "Offset" + nCount.ToString() + "_AY", "0", sb, 32, ASDef._INI_FILE);
                m_pstOffset[nCount].dAY = Convert.ToDouble(sb.ToString());
                AUtil.GetPrivateProfileString(Name, "Offset" + nCount.ToString() + "_AZ", "0", sb, 32, ASDef._INI_FILE);
                m_pstOffset[nCount].dAZ = Convert.ToDouble(sb.ToString());
            }
            catch
            {

            }
        }
        
        public void ReadIniPlcToPc()
        {
            try
            {
                // 2011.06.23
                StringBuilder sb = new StringBuilder(255);
                AUtil.GetPrivateProfileString(Name, "PlcToPc", "0", sb, 255, ASDef._INI_FILE);
                m_strPlcToPc = sb.ToString();
            }
            catch
            {

            }
        }

        public void WriteIniPlcToPc()
        {
            try
            {
                // 2011.06.23
                AUtil.WritePrivateProfileString(Name, "PlcToPc", m_strPlcToPc, ASDef._INI_FILE);
            }
            catch
            {

            }
        }

        // 2014.11.04
        public void ReadIniUse()
        {
            try
            {
                StringBuilder sb = new StringBuilder(255);
                AUtil.GetPrivateProfileString(Name, "Use", "X", sb, 10, ASDef._INI_FILE);
                if (sb.ToString() == "O")
                    m_bUse = true;
                else
                    m_bUse = false;
            }
            catch
            {

            }
        }

        // 2014.11.04
        public void WriteIniUse()
        {
            try
            {
                if (m_bUse)
                    AUtil.WritePrivateProfileString(Name, "Use", "O", ASDef._INI_FILE);
                else
                    AUtil.WritePrivateProfileString(Name, "Use", "X", ASDef._INI_FILE);
            }
            catch
            {

            }
        }
    }

    // 2015.01.01
    public class StringCompare : IComparer<AType>
    {
        public int Compare(AType x, AType y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
