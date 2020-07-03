using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Atmc;

namespace KMC_S2_CHT
{
    public class AIniPartOffset
    { 
        private string m_strType;

        public ASDef._stXY[,] m_ppstHoleXY = new ASDef._stXY[ASDef._3D_POSITION_COUNT, 2];
        public ASDef._stXYZ[] m_pstCalibXYZ = new ASDef._stXYZ[ASDef._3D_POSITION_COUNT];
        public ASDef._stXYZ[] m_pstXYZ = new ASDef._stXYZ[ASDef._3D_POSITION_COUNT];

        // 2011.08.15
        public ASDef._stXYZ[] m_pstCalibSubXYZ = new ASDef._stXYZ[ASDef._3D_POSITION_COUNT];
                
        public AIniPartOffset(string strType)
        {
            m_strType = strType;
        }

        public void Set(string strType)
        {
            m_strType = strType;
        }

        public void Read()
        {
            StringBuilder sb = new StringBuilder(32);
            string strKeyName;

            for (int i = 0; i < ASDef._3D_POSITION_COUNT; i++)
            {
                strKeyName = "PartOffset_HoleX_P" + (i+1).ToString() + "L";
                AUtil.GetPrivateProfileString(m_strType, strKeyName, "0", sb, 32, ASDef._INI_FILE);
                m_ppstHoleXY[i, 0].dX = Convert.ToDouble(sb.ToString());
                strKeyName = "PartOffset_HoleX_P" + (i + 1).ToString() + "R";
                AUtil.GetPrivateProfileString(m_strType, strKeyName, "0", sb, 32, ASDef._INI_FILE);
                m_ppstHoleXY[i, 1].dX = Convert.ToDouble(sb.ToString());

                strKeyName = "PartOffset_HoleY_P" + (i + 1).ToString() + "L";
                AUtil.GetPrivateProfileString(m_strType, strKeyName, "0", sb, 32, ASDef._INI_FILE);
                m_ppstHoleXY[i, 0].dY = Convert.ToDouble(sb.ToString());
                strKeyName = "PartOffset_HoleY_P" + (i + 1).ToString() + "R";
                AUtil.GetPrivateProfileString(m_strType, strKeyName, "0", sb, 32, ASDef._INI_FILE);
                m_ppstHoleXY[i, 1].dY = Convert.ToDouble(sb.ToString());

                // 2011.07.29---------------
                strKeyName = "PartOffset_CalibX";
                AUtil.GetPrivateProfileString("P"+(i + 1).ToString(), strKeyName, "0", sb, 32, ASDef._INI_FILE);
                m_pstCalibXYZ[i].dX = Convert.ToDouble(sb.ToString());

                strKeyName = "PartOffset_CalibY";
                AUtil.GetPrivateProfileString("P" + (i + 1).ToString(), strKeyName, "0", sb, 32, ASDef._INI_FILE);
                m_pstCalibXYZ[i].dY = Convert.ToDouble(sb.ToString());

                strKeyName = "PartOffset_CalibZ";
                AUtil.GetPrivateProfileString("P" + (i + 1).ToString(), strKeyName, "0", sb, 32, ASDef._INI_FILE);
                m_pstCalibXYZ[i].dZ = Convert.ToDouble(sb.ToString());
                //--------------------------
                
                
                strKeyName = "PartOffset_X_P" + (i + 1).ToString();
                AUtil.GetPrivateProfileString(m_strType, strKeyName, "0", sb, 32, ASDef._INI_FILE);
                m_pstXYZ[i].dX = Convert.ToDouble(sb.ToString());

                strKeyName = "PartOffset_Y_P" + (i + 1).ToString();
                AUtil.GetPrivateProfileString(m_strType, strKeyName, "0", sb, 32, ASDef._INI_FILE);
                m_pstXYZ[i].dY = Convert.ToDouble(sb.ToString());

                strKeyName = "PartOffset_Z_P" + (i + 1).ToString();
                AUtil.GetPrivateProfileString(m_strType, strKeyName, "0", sb, 32, ASDef._INI_FILE);
                m_pstXYZ[i].dZ = Convert.ToDouble(sb.ToString());

                // 2011.08.15---------------
                strKeyName = "CalibSubX_P" + (i + 1).ToString();
                AUtil.GetPrivateProfileString(m_strType, strKeyName, "0", sb, 32, ASDef._INI_FILE);
                m_pstCalibSubXYZ[i].dX = Convert.ToDouble(sb.ToString());

                strKeyName = "CalibSubY_P" + (i + 1).ToString();
                AUtil.GetPrivateProfileString(m_strType, strKeyName, "0", sb, 32, ASDef._INI_FILE);
                m_pstCalibSubXYZ[i].dY = Convert.ToDouble(sb.ToString());

                strKeyName = "CalibSubZ_P" + (i + 1).ToString();
                AUtil.GetPrivateProfileString(m_strType, strKeyName, "0", sb, 32, ASDef._INI_FILE);
                m_pstCalibSubXYZ[i].dZ = Convert.ToDouble(sb.ToString());
                //---------------------------
            }
        }

        public void Write()
        {
            string strKeyName, strValue;
            for (int i = 0; i < ASDef._3D_POSITION_COUNT; i++)
            {
                strKeyName = "PartOffset_HoleX_P" + (i + 1).ToString() + "L";
                strValue = m_ppstHoleXY[i, 0].dX.ToString("0.00");
                AUtil.WritePrivateProfileString(m_strType, strKeyName, strValue, ASDef._INI_FILE);
                strKeyName = "PartOffset_HoleX_P" + (i + 1).ToString() + "R";
                // 2011.08.22 0->1
                strValue = m_ppstHoleXY[i, 1].dX.ToString("0.00");
                AUtil.WritePrivateProfileString(m_strType, strKeyName, strValue, ASDef._INI_FILE);

                strKeyName = "PartOffset_HoleY_P" + (i + 1).ToString() + "L";
                strValue = m_ppstHoleXY[i, 0].dY.ToString("0.00");
                AUtil.WritePrivateProfileString(m_strType, strKeyName, strValue, ASDef._INI_FILE);
                strKeyName = "PartOffset_HoleY_P" + (i + 1).ToString() + "R";
                // 2011.08.22 0->1
                strValue = m_ppstHoleXY[i, 1].dY.ToString("0.00");
                AUtil.WritePrivateProfileString(m_strType, strKeyName, strValue, ASDef._INI_FILE);

                // 2011.07.29---------------
                strKeyName = "PartOffset_CalibX";
                strValue = m_pstCalibXYZ[i].dX.ToString("0.00");
                AUtil.WritePrivateProfileString("P" + (i + 1).ToString(), strKeyName, strValue, ASDef._INI_FILE);

                strKeyName = "PartOffset_CalibY";
                strValue = m_pstCalibXYZ[i].dY.ToString("0.00");
                AUtil.WritePrivateProfileString("P" + (i + 1).ToString(), strKeyName, strValue, ASDef._INI_FILE);
                
                strKeyName = "PartOffset_CalibZ";
                strValue = m_pstCalibXYZ[i].dZ.ToString("0.00");
                AUtil.WritePrivateProfileString("P" + (i + 1).ToString(), strKeyName, strValue, ASDef._INI_FILE);
                

                strKeyName = "PartOffset_X_P" + (i + 1).ToString();
                strValue = m_pstXYZ[i].dX.ToString("0.00");
                AUtil.WritePrivateProfileString(m_strType, strKeyName, strValue, ASDef._INI_FILE);
                
                strKeyName = "PartOffset_Y_P" + (i + 1).ToString();
                strValue = m_pstXYZ[i].dY.ToString("0.00");
                AUtil.WritePrivateProfileString(m_strType, strKeyName, strValue, ASDef._INI_FILE);
                
                strKeyName = "PartOffset_Z_P" + (i + 1).ToString();
                strValue = m_pstXYZ[i].dZ.ToString("0.00");
                AUtil.WritePrivateProfileString(m_strType, strKeyName, strValue, ASDef._INI_FILE);
                //---------------------------
            }
        }
    }

    public class AIniFrame
    {
        // 2016.10.11
        // 2016.06.17
        private string m_strType;

        private int m_nPosition;

        public ASDef._stRobotShift m_stCommon;
        // 2016.10.11
        public ASDef._stRobotShift m_stPose;
                
        // 2016.10.11
        // 2016.06.17
        public AIniFrame(string strType, int nPosition)
        //public AIniFrame(int nPosition)
        {
            // 2016.10.11
            // 2016.06.17
            m_strType = strType;

            m_nPosition = nPosition;
        }

        public void Set(string strType, int nPosition)
        //public void Set(string strType, int nPosition)
        {
            // 2016.10.11
            // 2016.06.17
            m_strType = strType;

            m_nPosition = nPosition;
        }

        public void Read()
        {
            StringBuilder sb = new StringBuilder(32);

            AUtil.GetPrivateProfileString("P" + (m_nPosition + 1), "Frame_CommonX", "0", sb, 32, ASDef._INI_FILE);
            m_stCommon.dX = Convert.ToDouble(sb.ToString());
            AUtil.GetPrivateProfileString("P" + (m_nPosition + 1), "Frame_CommonY", "0", sb, 32, ASDef._INI_FILE);
            m_stCommon.dY = Convert.ToDouble(sb.ToString());
            AUtil.GetPrivateProfileString("P" + (m_nPosition + 1), "Frame_CommonZ", "0", sb, 32, ASDef._INI_FILE);
            m_stCommon.dZ = Convert.ToDouble(sb.ToString());
            AUtil.GetPrivateProfileString("P" + (m_nPosition + 1), "Frame_CommonAX", "0", sb, 32, ASDef._INI_FILE);
            m_stCommon.dAX = Convert.ToDouble(sb.ToString());
            AUtil.GetPrivateProfileString("P" + (m_nPosition + 1), "Frame_CommonAY", "0", sb, 32, ASDef._INI_FILE);
            m_stCommon.dAY = Convert.ToDouble(sb.ToString());
            AUtil.GetPrivateProfileString("P" + (m_nPosition + 1), "Frame_CommonAZ", "0", sb, 32, ASDef._INI_FILE);
            m_stCommon.dAZ = Convert.ToDouble(sb.ToString());
            // 2016.10.11
            AUtil.GetPrivateProfileString(m_strType, "Frame_PoseX_P" + (m_nPosition + 1).ToString(), "0", sb, 32, ASDef._INI_FILE);
            m_stPose.dX = Convert.ToDouble(sb.ToString());
            AUtil.GetPrivateProfileString(m_strType, "Frame_PoseY_P" + (m_nPosition + 1).ToString(), "0", sb, 32, ASDef._INI_FILE);
            m_stPose.dY = Convert.ToDouble(sb.ToString());
            AUtil.GetPrivateProfileString(m_strType, "Frame_PoseZ_P" + (m_nPosition + 1).ToString(), "0", sb, 32, ASDef._INI_FILE);
            m_stPose.dZ = Convert.ToDouble(sb.ToString());
            AUtil.GetPrivateProfileString(m_strType, "Frame_PoseAX_P" + (m_nPosition + 1).ToString(), "0", sb, 32, ASDef._INI_FILE);
            m_stPose.dAX = Convert.ToDouble(sb.ToString());
            AUtil.GetPrivateProfileString(m_strType, "Frame_PoseAY_P" + (m_nPosition + 1).ToString(), "0", sb, 32, ASDef._INI_FILE);
            m_stPose.dAY = Convert.ToDouble(sb.ToString());
            AUtil.GetPrivateProfileString(m_strType, "Frame_PoseAZ_P" + (m_nPosition + 1).ToString(), "0", sb, 32, ASDef._INI_FILE);
            m_stPose.dAZ = Convert.ToDouble(sb.ToString());
            
        }

        public void Write()
        {
            string strValue;

            strValue = m_stCommon.dX.ToString("0.000");
            AUtil.WritePrivateProfileString("P" + (m_nPosition + 1).ToString(), "Frame_CommonX", strValue, ASDef._INI_FILE);
            strValue = m_stCommon.dY.ToString("0.000");
            AUtil.WritePrivateProfileString("P" + (m_nPosition + 1).ToString(), "Frame_CommonY", strValue, ASDef._INI_FILE);
            strValue = m_stCommon.dZ.ToString("0.000");
            AUtil.WritePrivateProfileString("P" + (m_nPosition + 1).ToString(), "Frame_CommonZ", strValue, ASDef._INI_FILE);
            strValue = m_stCommon.dAX.ToString("0.000");
            AUtil.WritePrivateProfileString("P" + (m_nPosition + 1).ToString(), "Frame_CommonAX", strValue, ASDef._INI_FILE);
            strValue = m_stCommon.dAY.ToString("0.000");
            AUtil.WritePrivateProfileString("P" + (m_nPosition + 1).ToString(), "Frame_CommonAY", strValue, ASDef._INI_FILE);
            strValue = m_stCommon.dAZ.ToString("0.000");
            AUtil.WritePrivateProfileString("P" + (m_nPosition + 1).ToString(), "Frame_CommonAZ", strValue, ASDef._INI_FILE);

            // 2016.10.11
            strValue = m_stPose.dX.ToString("0.000");
            AUtil.WritePrivateProfileString(m_strType, "Frame_PoseX_P" + (m_nPosition + 1).ToString(), strValue, ASDef._INI_FILE);
            strValue = m_stPose.dY.ToString("0.000");
            AUtil.WritePrivateProfileString(m_strType, "Frame_PoseY_P" + (m_nPosition + 1).ToString(), strValue, ASDef._INI_FILE);
            strValue = m_stPose.dZ.ToString("0.000");
            AUtil.WritePrivateProfileString(m_strType, "Frame_PoseZ_P" + (m_nPosition + 1).ToString(), strValue, ASDef._INI_FILE);
            strValue = m_stPose.dAX.ToString("0.000");
            AUtil.WritePrivateProfileString(m_strType, "Frame_PoseAX_P" + (m_nPosition + 1).ToString(), strValue, ASDef._INI_FILE);
            strValue = m_stPose.dAY.ToString("0.000");
            AUtil.WritePrivateProfileString(m_strType, "Frame_PoseAY_P" + (m_nPosition + 1).ToString(), strValue, ASDef._INI_FILE);
            strValue = m_stPose.dAZ.ToString("0.000");
            AUtil.WritePrivateProfileString(m_strType, "Frame_PoseAZ_P" + (m_nPosition + 1).ToString(), strValue, ASDef._INI_FILE);

        }
    }
    
    public class AIniHoleLocation
    {
        private string m_strType;

        public ASDef._stXYZ[] m_pstXYZ = new ASDef._stXYZ[4];
        public double m_dCheckLength;

        public AIniHoleLocation(string strType)
        {
            m_strType = strType;
        }

        public void Set(string strType)
        {
            m_strType = strType;
        }

        public void Read()
        {
            StringBuilder sb = new StringBuilder(32);

            for(int i=0;i<ASDef._3D_POSITION_COUNT;i++)
            {
                AUtil.GetPrivateProfileString(m_strType, "HoleLocation_P" + (i + 1).ToString() + "_X", "0", sb, 32, ASDef._INI_FILE);
                m_pstXYZ[i].dX = Convert.ToDouble(sb.ToString());
                AUtil.GetPrivateProfileString(m_strType, "HoleLocation_P" + (i + 1).ToString() + "_Y", "0", sb, 32, ASDef._INI_FILE);
                m_pstXYZ[i].dY = Convert.ToDouble(sb.ToString());
                AUtil.GetPrivateProfileString(m_strType, "HoleLocation_P" + (i + 1).ToString() + "_Z", "0", sb, 32, ASDef._INI_FILE);
                m_pstXYZ[i].dZ = Convert.ToDouble(sb.ToString());
            }

            AUtil.GetPrivateProfileString(m_strType, "HoleLocation_CheckLength", "5", sb, 32, ASDef._INI_FILE);
            m_dCheckLength = Convert.ToDouble(sb.ToString());
        }

        public void Write()
        {
            string strValue;

            for (int i = 0; i < ASDef._3D_POSITION_COUNT; i++)
            {
                strValue = m_pstXYZ[i].dX.ToString("0.00");
                AUtil.WritePrivateProfileString(m_strType, "HoleLocation_P" + (i + 1).ToString() + "_X", strValue, ASDef._INI_FILE);
                strValue = m_pstXYZ[i].dY.ToString("0.00");
                AUtil.WritePrivateProfileString(m_strType, "HoleLocation_P" + (i + 1).ToString() + "_Y", strValue, ASDef._INI_FILE);
                strValue = m_pstXYZ[i].dZ.ToString("0.00");
                AUtil.WritePrivateProfileString(m_strType, "HoleLocation_P" + (i + 1).ToString() + "_Z", strValue, ASDef._INI_FILE);
            }

            strValue = m_dCheckLength.ToString("0.00");
            AUtil.WritePrivateProfileString(m_strType, "HoleLocation_CheckLength", strValue, ASDef._INI_FILE);
        }
    }
}
