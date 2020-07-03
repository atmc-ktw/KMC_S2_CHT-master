using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Atmc;
using System.Windows.Forms;

using LotusAPI;
using LotusAPI.MV;
using LotusAPI.Math;

namespace ACom
{
    public class ACalculationLotus3D
    {

        private StereoCamera[] m_pStereoCamera = new StereoCamera[4];
        private Matrix44d[] m_pX = new Matrix44d[4];
        private Matrix44d[] m_pCamPose = new Matrix44d[4];

        public struct _stMeasure
        { 
	        public ASDef._stXY[] pstHole;
	        
	        public ASDef._stXYZ stShift;
            public ASDef._stXYZ stCalibXYZ;

            // 2012.02.21
            public bool[] pbR;
            public string[] pstrBmpTxt;
        }

        public struct _stHoleLength
        {
	        public double dP1_P2;  // 길이
	        public double dP2_P3;
	        public double dP3_P4;
	        public double dP1_P4;
	        public double dP1_P3;
	        public double dP2_P4;

	        public double dShiftP1_P2;  // 길이
	        public double dShiftP2_P3;
	        public double dShiftP3_P4;
	        public double dShiftP1_P4;
	        public double dShiftP1_P3;
	        public double dShiftP2_P4;

	        public bool bP1_P2;  
	        public bool bP2_P3;
	        public bool bP3_P4;
	        public bool bP1_P4;
	        public bool bP1_P3;
	        public bool bP2_P4;

	        public int nCase;
	        /*
	        0 : P1 P2 
	               P3
	        1 :    P2
	            P4 P3
	        2 : P1 P2 
		        P4
	        3 : P1
	            P4 P3
	        */
        }

        public enum _emPosition
        {
	        P1,
	        P2,
	        P3,
	        P4
        }

        public enum _emRotationOrder
        {
	        ZYX,
	        ZYZ
        }

        public ASDef._stRobotShift m_stFrameCommon;
        // 2016.10.11
        public ASDef._stRobotShift m_stFramePose; 


        public ACalculationLotus3D()
        {
	        
        }



        private void LoadCalib(_emPosition emPosition)
        {
            string strFName = String.Format("{0:s}\\steoreo_calibP{1:d}.json", ASDef._INI_PATH, emPosition + 1);
            try
            {
                m_pStereoCamera[(int)emPosition] = JsonUtils.Read<StereoCamera>(Json.ReadFromFile(strFName));
            }
            catch (Exception ex)
            {
                LotusAPI.Logger.Error(ex.Message);
            }

            strFName = String.Format("{0:s}\\robot_camera_calibresultP{1:d}.json", ASDef._INI_PATH, emPosition + 1);
            try
            {
                var j = Json.ReadFromFile(strFName);
                m_pX[(int)emPosition] = JsonUtils.Read<Matrix44d>(j["X"]);
                m_pCamPose[(int)emPosition] = JsonUtils.Read<Matrix44d>(j["CamPose"]);
            }
            catch (Exception ex)
            {
                LotusAPI.Logger.Error(ex.Message);
            }

        }


        public void Init()
        {
            int i;
            for (i = 0; i < 4; i++)
            {
                LoadCalib((_emPosition)i);
            }
        }
        
        public void SetFramePose(ASDef._stRobotShift stFrame)
        {
            m_stFramePose = stFrame;
        }
        
        public void SetFrameCommon(ASDef._stRobotShift stFrame)
        {
            m_stFrameCommon = stFrame;
        }


        /* 2016.06.17
        public void PoseToBase(ASDef._stXYZ stSource, ref ASDef._stXYZ stDest, _emRotationOrder emRotationOrder)
        {
            // **********************************************************
            // [ stDest.dX ]       [ stSource.dX ]   [ m_stFramePose.dX ]
            // | stDest.dY |  =  M | stSource.dY | + | m_stFramePose.dY |
            // [ stDest.dZ ]       [ stSource.dZ ]   [ m_stFramePose.dZ ]
            // **********************************************************
          
	        double[,] M = new double[3,3];
	        double RX = m_stFramePose.dAX * Math.PI / 180;
	        double RY = m_stFramePose.dAY * Math.PI / 180;
	        double RZ = m_stFramePose.dAZ * Math.PI / 180;

            switch (emRotationOrder)
            {
                case _emRotationOrder.ZYX:
	                M[0,0] = Math.Cos(RZ)*Math.Cos(RY);
	                M[0,1] = -Math.Sin(RZ)*Math.Cos(RX)+Math.Sin(RX)*Math.Cos(RZ)*Math.Sin(RY);
	                M[0,2] = Math.Sin(RX)*Math.Sin(RZ)+Math.Cos(RX)*Math.Cos(RZ)*Math.Sin(RY);
	                
	                M[1,0] = Math.Sin(RZ)*Math.Cos(RY);
	                M[1,1] = Math.Cos(RX)*Math.Cos(RZ)+Math.Sin(RX)*Math.Sin(RY)*Math.Sin(RZ);
	                M[1,2] = -Math.Sin(RX)*Math.Cos(RZ)+Math.Sin(RY)*Math.Sin(RZ)*Math.Cos(RX);
	                
	                M[2,0] = -Math.Sin(RY);
	                M[2,1] = Math.Sin(RX)*Math.Cos(RY);
	                M[2,2] = Math.Cos(RX)*Math.Cos(RY);
	                break;
                case _emRotationOrder.ZYZ:
	                M[0,0] = Math.Cos(RZ)*Math.Cos(RX)*Math.Cos(RY)-Math.Sin(RZ)*Math.Sin(RX);
	                M[0,1] = -Math.Sin(RZ)*Math.Cos(RX)*Math.Cos(RY)-Math.Cos(RZ)*Math.Sin(RX);
	                // 2010.07.12
	                M[0,2] = Math.Cos(RX)*Math.Sin(RY);
	                
	                M[1,0] = Math.Cos(RZ)*Math.Sin(RX)*Math.Cos(RY)+Math.Sin(RZ)*Math.Cos(RX);
	                M[1,1] = -Math.Sin(RZ)*Math.Sin(RX)*Math.Cos(RY)+Math.Cos(RZ)*Math.Cos(RX);
	                M[1,2] = Math.Sin(RX)*Math.Sin(RY);
	                
	                M[2,0] = -Math.Sin(RY)*Math.Cos(RZ);
	                M[2,1] = Math.Sin(RZ)*Math.Sin(RY);
	                M[2,2] = Math.Cos(RY);
	                break;
            }
	        
            stDest.dX = M[0,0] *  stSource.dX + M[0,1] *  stSource.dY + M[0,2] *  stSource.dZ + m_stFramePose.dX;
	        stDest.dY = M[1,0] *  stSource.dX + M[1,1] *  stSource.dY + M[1,2] *  stSource.dZ + m_stFramePose.dY;
	        stDest.dZ = M[2,0] *  stSource.dX + M[2,1] *  stSource.dY + M[2,2] *  stSource.dZ + m_stFramePose.dZ;
        }
        */

        public void BaseToCommon(ASDef._stXYZ stSource, ref ASDef._stXYZ stDest, _emRotationOrder emRotationOrder)
        {
            // 2016.07.07 by khWoo
            // **********************************************************************
            // [ stDest.dX ]            [ stSource.dX ]   [ m_stFrameCommon.dX ]
            // | stDest.dY |  =  RevM ( | stSource.dY | - | m_stFrameCommon.dY |  )
            // [ stDest.dZ ]            [ stSource.dZ ]   [ m_stFrameCommon.dZ ]
            //
            //                   RevM = Transpose of M
            // **********************************************************************

	        double[,] RevM = new double[3,3];
	        double RX = m_stFrameCommon.dAX * Math.PI / 180;
	        double RY = m_stFrameCommon.dAY * Math.PI / 180;
	        double RZ = m_stFrameCommon.dAZ * Math.PI / 180;

            double dX = stSource.dX - m_stFrameCommon.dX;
            double dY = stSource.dY - m_stFrameCommon.dY;
            double dZ = stSource.dZ - m_stFrameCommon.dZ;

            switch (emRotationOrder)
            {
                case _emRotationOrder.ZYX:
                    RevM[0, 0] = Math.Cos(RZ) * Math.Cos(RY);
                    RevM[0, 1] = Math.Sin(RZ) * Math.Cos(RY);
                    RevM[0, 2] = -Math.Sin(RY);
                    
                    RevM[1, 0] = -Math.Sin(RZ) * Math.Cos(RX) + Math.Sin(RX) * Math.Cos(RZ) * Math.Sin(RY);
                    RevM[1, 1] = Math.Cos(RX) * Math.Cos(RZ) + Math.Sin(RX) * Math.Sin(RY) * Math.Sin(RZ);
                    RevM[1, 2] = Math.Sin(RX) * Math.Cos(RY);
                    
                    RevM[2, 0] = Math.Sin(RX) * Math.Sin(RZ) + Math.Cos(RX) * Math.Cos(RZ) * Math.Sin(RY);
                    RevM[2, 1] = -Math.Sin(RX) * Math.Cos(RZ) + Math.Sin(RY) * Math.Sin(RZ) * Math.Cos(RX);
                    RevM[2, 2] = Math.Cos(RX) * Math.Cos(RY);
                    break;
                case _emRotationOrder.ZYZ:
                    RevM[0, 0] = Math.Cos(RZ) * Math.Cos(RX) * Math.Cos(RY) - Math.Sin(RZ) * Math.Sin(RX);
                    RevM[0, 1] = Math.Cos(RZ) * Math.Sin(RX) * Math.Cos(RY) + Math.Sin(RZ) * Math.Cos(RX);
                    RevM[0, 2] = -Math.Sin(RY) * Math.Cos(RZ);
                    
                    RevM[1, 0] = -Math.Sin(RZ) * Math.Cos(RX) * Math.Cos(RY) - Math.Cos(RZ) * Math.Sin(RX);
                    RevM[1, 1] = -Math.Sin(RZ) * Math.Sin(RX) * Math.Cos(RY) + Math.Cos(RZ) * Math.Cos(RX);
                    RevM[1, 2] = Math.Sin(RZ) * Math.Sin(RY);
                    
                    RevM[2, 0] = Math.Cos(RX) * Math.Sin(RY);
                    RevM[2, 1] = Math.Sin(RX) * Math.Sin(RY);
                    RevM[2, 2] = Math.Cos(RY);
                    break;
            }

	        stDest.dX = RevM[0,0] *  dX + RevM[0,1] *  dY + RevM[0,2] *  dZ;
	        stDest.dY = RevM[1,0] *  dX + RevM[1,1] *  dY + RevM[1,2] *  dZ;
	        stDest.dZ = RevM[2,0] *  dX + RevM[2,1] *  dY + RevM[2,2] *  dZ;
        }

        // 2016.11.25 static
        public static void ConvertFrame(ASDef._stRobotShift stFrame, ASDef._stXYZ stSource, ref ASDef._stXYZ stDest, _emRotationOrder emRotationOrder)
        {
            // 2016.07.07 by khWoo
            // *****************************************************
            // [ stDest.dX ]       [ stSource.dX ]   [ stFrame.dX ]
            // | stDest.dY |  =  M | stSource.dY | + | stFrame.dY |
            // [ stDest.dZ ]       [ stSource.dZ ]   [ stFrame.dZ ]
            // *****************************************************

	        double[,] M = new double[3,3];
	        double RX = stFrame.dAX * Math.PI / 180;
	        double RY = stFrame.dAY * Math.PI / 180;
	        double RZ = stFrame.dAZ * Math.PI / 180;

            switch (emRotationOrder)
            {
                case _emRotationOrder.ZYX:
	                M[0,0] = Math.Cos(RZ)*Math.Cos(RY);
	                M[0,1] = -Math.Sin(RZ)*Math.Cos(RX)+Math.Sin(RX)*Math.Cos(RZ)*Math.Sin(RY);
	                M[0,2] = Math.Sin(RX)*Math.Sin(RZ)+Math.Cos(RX)*Math.Cos(RZ)*Math.Sin(RY);
	                
	                M[1,0] = Math.Sin(RZ)*Math.Cos(RY);
	                M[1,1] = Math.Cos(RX)*Math.Cos(RZ)+Math.Sin(RX)*Math.Sin(RY)*Math.Sin(RZ);
	                M[1,2] = -Math.Sin(RX)*Math.Cos(RZ)+Math.Sin(RY)*Math.Sin(RZ)*Math.Cos(RX);
	                
	                M[2,0] = -Math.Sin(RY);
	                M[2,1] = Math.Sin(RX)*Math.Cos(RY);
	                M[2,2] = Math.Cos(RX)*Math.Cos(RY);
	                break;
                case _emRotationOrder.ZYZ:
	                M[0,0] = Math.Cos(RZ)*Math.Cos(RX)*Math.Cos(RY)-Math.Sin(RZ)*Math.Sin(RX);
	                M[0,1] = -Math.Sin(RZ)*Math.Cos(RX)*Math.Cos(RY)-Math.Cos(RZ)*Math.Sin(RX);
	                M[0,2] = Math.Cos(RX)*Math.Sin(RY);
	                
	                M[1,0] = Math.Cos(RZ)*Math.Sin(RX)*Math.Cos(RY)+Math.Sin(RZ)*Math.Cos(RX);
	                M[1,1] = -Math.Sin(RZ)*Math.Sin(RX)*Math.Cos(RY)+Math.Cos(RZ)*Math.Cos(RX);
	                M[1,2] = Math.Sin(RX)*Math.Sin(RY);
	                
	                M[2,0] = -Math.Sin(RY)*Math.Cos(RZ);
	                M[2,1] = Math.Sin(RZ)*Math.Sin(RY);
	                M[2,2] = Math.Cos(RY);
	                break;
            }

            stDest.dX = M[0, 0] * stSource.dX + M[0, 1] * stSource.dY + M[0, 2] * stSource.dZ + stFrame.dX;
            stDest.dY = M[1, 0] * stSource.dX + M[1, 1] * stSource.dY + M[1, 2] * stSource.dZ + stFrame.dY;
            stDest.dZ = M[2, 0] * stSource.dX + M[2, 1] * stSource.dY + M[2, 2] * stSource.dZ + stFrame.dZ;
        }

        // 2016.11.25 static
        public static void ConvertFrameInverse(ASDef._stRobotShift stFrame, ASDef._stXYZ stSource, ref ASDef._stXYZ stDest, _emRotationOrder emRotationOrder)
        {
            // 2016.07.07 by khWoo
            // **********************************************************************
            // [ stDest.dX ]            [ stSource.dX ]   [ stFrame.dX ]
            // | stDest.dY |  =  RevM ( | stSource.dY | - | stFrame.dY |  )
            // [ stDest.dZ ]            [ stSource.dZ ]   [ stFrame.dZ ]
            // **********************************************************************

	        double[,] RevM = new double[3, 3];
	        double RX = stFrame.dAX * Math.PI / 180;
	        double RY = stFrame.dAY * Math.PI / 180;
	        double RZ = stFrame.dAZ * Math.PI / 180;

            double dX = stSource.dX - stFrame.dX;
            double dY = stSource.dY - stFrame.dY;
            double dZ = stSource.dZ - stFrame.dZ;

            switch (emRotationOrder)
            {
                case _emRotationOrder.ZYX:
                    RevM[0, 0] = Math.Cos(RZ) * Math.Cos(RY);
                    RevM[0, 1] = Math.Sin(RZ) * Math.Cos(RY);
                    RevM[0, 2] = -Math.Sin(RY);

                    RevM[1, 0] = -Math.Sin(RZ) * Math.Cos(RX) + Math.Sin(RX) * Math.Cos(RZ) * Math.Sin(RY);
                    RevM[1, 1] = Math.Cos(RX) * Math.Cos(RZ) + Math.Sin(RX) * Math.Sin(RY) * Math.Sin(RZ);
                    RevM[1, 2] = Math.Sin(RX) * Math.Cos(RY);

                    RevM[2, 0] = Math.Sin(RX) * Math.Sin(RZ) + Math.Cos(RX) * Math.Cos(RZ) * Math.Sin(RY);
                    RevM[2, 1] = -Math.Sin(RX) * Math.Cos(RZ) + Math.Sin(RY) * Math.Sin(RZ) * Math.Cos(RX);
                    RevM[2, 2] = Math.Cos(RX) * Math.Cos(RY);
                    break;
                case _emRotationOrder.ZYZ:
                    RevM[0, 0] = Math.Cos(RZ) * Math.Cos(RX) * Math.Cos(RY) - Math.Sin(RZ) * Math.Sin(RX);
                    RevM[0, 1] = Math.Cos(RZ) * Math.Sin(RX) * Math.Cos(RY) + Math.Sin(RZ) * Math.Cos(RX);
                    RevM[0, 2] = -Math.Sin(RY) * Math.Cos(RZ);

                    RevM[1, 0] = -Math.Sin(RZ) * Math.Cos(RX) * Math.Cos(RY) - Math.Cos(RZ) * Math.Sin(RX);
                    RevM[1, 1] = -Math.Sin(RZ) * Math.Sin(RX) * Math.Cos(RY) + Math.Cos(RZ) * Math.Cos(RX);
                    RevM[1, 2] = Math.Sin(RZ) * Math.Sin(RY);

                    RevM[2, 0] = Math.Cos(RX) * Math.Sin(RY);
                    RevM[2, 1] = Math.Sin(RX) * Math.Sin(RY);
                    RevM[2, 2] = Math.Cos(RY);
                    break;
            }

	        stDest.dX = RevM[0,0] *  dX + RevM[0,1] *  dY + RevM[0,2] *  dZ;
	        stDest.dY = RevM[1,0] *  dX + RevM[1,1] *  dY + RevM[1,2] *  dZ;
	        stDest.dZ = RevM[2,0] *  dX + RevM[2,1] *  dY + RevM[2,2] *  dZ;
        }

        public static bool InverseMatrix(double nNum, double[,] ppdSource, double[,] ppdDest)
        {
	        if (DeterminantMatrix(ppdSource, nNum) == 0)
		        return false;
        	
	        Cofactors(ppdSource, nNum, ppdDest);
        	
            return true;
        }

        public static double DeterminantMatrix(double[,] a, double k)
        {
            double s=1,det=0;
            double[,] b = new double[25,25];
            int i,j,m,n,c;
            if(k==1)
            {
                return(a[0,0]);
            }
            else
            {
                det=0;
                for(c=0;c<k;c++)
                {
                    m=0;
                    n=0;
                    for(i=0;i<k;i++)
                    {
                        for(j=0;j<k;j++)
                        {
                            b[i,j]=0;
                            if(i!=0&&j!=c)
                            {
                                b[m,n]=a[i,j];
                                if(n<(k-2))
                                    n++;
                                else
                                {
                                    n=0;
                                    m++;
                                }
                            }
                        }
                    }
                    det=det+s*(a[0,c]*DeterminantMatrix(b,k-1));
                    s=-1*s;
                }
            }
            return det;
        }

        public static void Cofactors(double[,] num,double f, double[,] ppdRev)
        {
            double[,] b = new double[25,25];
            double[,] fac = new double[25,25];
            int p,q,m,n,i,j;
            for(q=0;q<f;q++)
            {
                for(p=0;p<f;p++)
                {
                    m=0;
                    n=0;
                    for(i=0;i<f;i++)
                    {
                        for(j=0;j<f;j++)
                        {
                            b[i,j]=0;
                            if(i!=q&&j!=p)
                            {
                                b[m,n]=num[i,j];
                                if(n<(f-2))
                                    n++;
                                else
                                {
                                    n=0;
                                    m++;
                                }
                            }
                        }
                    }
                    fac[q,p]=Math.Pow(-1,q+p)*DeterminantMatrix(b,f-1);
                }
            }
	        Transpose(num,fac,f, ppdRev);
        }

        public static void Transpose(double[,] num, double[,] fac,double r, double[,] ppdRev )
        {
            int i,j;
            double[,] b = new double[25,25];
            double d;
            for(i=0;i<r;i++)
            {
                for(j=0;j<r;j++)
                {
                    b[i,j]=fac[j,i];
                }
            }
            d=DeterminantMatrix(num,r);
            for(i=0;i<r;i++)
            {
                for(j=0;j<r;j++)
                {
                    if (d==1 || b[i,j]==0)
			        {
				        ppdRev[i,j] = b[i,j];
                    }
                    else
			        {
				        ppdRev[i,j] = b[i,j]/d;
                    }
                }
            }
        }
        //--------------------------
        // 2011.08.14
        public static void SubXYZ(ASDef._stXYZ stSource1, ASDef._stXYZ stSource2, ref ASDef._stXYZ stDest)
        {
            stDest.dX = stSource1.dX - stSource2.dX;
            stDest.dY = stSource1.dY - stSource2.dY;
            stDest.dZ = stSource1.dZ - stSource2.dZ;
        }
        // 외적
        public static void MulXYZ(ASDef._stXYZ stSource1, ASDef._stXYZ stSource2, ref ASDef._stXYZ stDest)
        {
            stDest.dX = stSource1.dY * stSource2.dZ - stSource1.dZ * stSource2.dY;
            stDest.dY = stSource1.dZ * stSource2.dX - stSource1.dX * stSource2.dZ;
            stDest.dZ = stSource1.dX * stSource2.dY - stSource1.dY * stSource2.dX;
        }
        public static double LengthXYZ(ASDef._stXYZ stSource)
        {
            return Math.Sqrt(Math.Pow(stSource.dX, 2) + Math.Pow(stSource.dY, 2) + Math.Pow(stSource.dZ, 2));
        }
        //--------------------------
        /*
         * 3점으로 좌표계 생성
         * pstP[0] : ORG
         * pstP[1] : XX
         * pstP[2] : XY
         * 
         * 주의 : Y축 +-90도 이상 , X축 +-90도 이상 계산 못함
         * 
         * 
         */
        public static void MakeFrame(ASDef._stXYZ[] pstP, ref ASDef._stRobotShift stFrame)
        {
            ASDef._stXYZ stPa, stPb, stPn;

            /*
             *              |n
             *              |
             *              |
             *              |
             *              |              b
             *             / ---------------
             *            /
             *           /
             *          /
             *          a
             */         
            
            stPa = default(ASDef._stXYZ);
            stPb = default(ASDef._stXYZ);
            stPn = default(ASDef._stXYZ);
            SubXYZ(pstP[1], pstP[0], ref stPa);
            SubXYZ(pstP[2], pstP[0], ref stPb);
            MulXYZ(stPa, stPb, ref stPn);   // stPa X stPb
            // 2016.07.07 by khWoo
            //MulXYZ(stPn, stPa, ref stPb);   // (stPa X stPb) X stPa

            stFrame.dX = pstP[0].dX;
            stFrame.dY = pstP[0].dY;
            stFrame.dZ = pstP[0].dZ;

            // 2016.07.21 by khWoo
            // Vector Normalize
            double dTmp = Math.Sqrt(Math.Pow(stPa.dX, 2) + Math.Pow(stPa.dY, 2) + Math.Pow(stPa.dZ, 2));
            stPa.dX /= dTmp;
            stPa.dY /= dTmp;
            stPa.dZ /= dTmp;

            dTmp = Math.Sqrt(Math.Pow(stPn.dX, 2) + Math.Pow(stPn.dY, 2) + Math.Pow(stPn.dZ, 2));
            stPn.dX /= dTmp;
            stPn.dY /= dTmp;
            stPn.dZ /= dTmp;

            /* 
            // 2011.08.09
            if (stPn.dY == 0)
                stFrame.dAX = Math.Acos(stPn.dZ / Math.Sqrt(Math.Pow(stPn.dZ, 2) + Math.Pow(stPn.dX, 2)));
            else
                stFrame.dAX = (stPn.dY / Math.Abs(stPn.dY)) * Math.Acos(stPn.dZ / Math.Sqrt(Math.Pow(stPn.dZ, 2) + Math.Pow(stPn.dX, 2)));

            if (stPn.dX == 0)
                stFrame.dAY = Math.Acos(stPn.dZ / Math.Sqrt(Math.Pow(stPn.dZ, 2) + Math.Pow(stPn.dY, 2)));
            else
                stFrame.dAY = (stPn.dX / Math.Abs(stPn.dX)) * Math.Acos(stPn.dZ / Math.Sqrt(Math.Pow(stPn.dZ, 2) + Math.Pow(stPn.dY, 2)));

            if (stPa.dY == 0)
                stFrame.dAZ = Math.Acos(stPa.dX / Math.Sqrt(Math.Pow(stPa.dX, 2) + Math.Pow(stPa.dY, 2)));
            else
                stFrame.dAZ = (stPa.dY / Math.Abs(stPa.dY)) * Math.Acos(stPa.dX / Math.Sqrt(Math.Pow(stPa.dX, 2) + Math.Pow(stPa.dY, 2)));
            stFrame.dAX *= 180 / Math.PI;
            stFrame.dAY *= 180 / Math.PI;
            stFrame.dAZ *= 180 / Math.PI;
            */
            // 2011.08.11
            /*
            if (stPa.dY == 0)
                stFrame.dAZ = Math.Acos(stPa.dX / Math.Sqrt(Math.Pow(stPa.dX, 2) + Math.Pow(stPa.dY, 2)));
            else
                stFrame.dAZ = (stPa.dY / Math.Abs(stPa.dY)) * Math.Acos(stPa.dX / Math.Sqrt(Math.Pow(stPa.dX, 2) + Math.Pow(stPa.dY, 2)));
            */
            /*// 2011.08.15 Z축 회전 구하는 루틴 수정
            if (stPa.dX >= 0)
            {
                if (stPa.dX == 0 && stPa.dY == 0)
                    stFrame.dAZ = 0;
                else
                    stFrame.dAZ = Math.Asin(stPa.dY / Math.Sqrt(Math.Pow(stPa.dX, 2) + Math.Pow(stPa.dY, 2)));
            }
            else
            {
                if (stPa.dY == 0)
                {
                    stFrame.dAZ = Math.PI; // Math.Acos(stPa.dX / Math.Sqrt(Math.Pow(stPa.dX, 2) + Math.Pow(stPa.dY, 2)));
                }
                else
                {
                    stFrame.dAZ = (stPa.dY / Math.Abs(stPa.dY)) * Math.Acos(stPa.dX / Math.Sqrt(Math.Pow(stPa.dX, 2) + Math.Pow(stPa.dY, 2)));
                }
            }

            stFrame.dAZ = stFrame.dAZ * 180 / Math.PI;

            ASDef._stXYZ stPnz, stPny;
            stPnz = default(ASDef._stXYZ);
            RotateZ(-stFrame.dAZ, stPn, ref stPnz);

            if (stPnz.dX == 0)
                stFrame.dAY = Math.Acos(stPnz.dZ / Math.Sqrt(Math.Pow(stPnz.dZ, 2) + Math.Pow(stPnz.dX, 2)));
            else
                stFrame.dAY = (stPnz.dX / Math.Abs(stPnz.dX)) * Math.Acos(stPnz.dZ / Math.Sqrt(Math.Pow(stPnz.dZ, 2) + Math.Pow(stPnz.dX, 2)));
            stFrame.dAY = stFrame.dAY * 180 / Math.PI;

            stPny = default(ASDef._stXYZ);
            RotateY(-stFrame.dAY, stPnz, ref stPny);


            if (stPny.dY == 0)
                stFrame.dAX = Math.Acos(stPny.dZ / Math.Sqrt(Math.Pow(stPny.dZ, 2) + Math.Pow(stPny.dY, 2)));
            else
                stFrame.dAX = -(stPny.dY / Math.Abs(stPny.dY)) * Math.Acos(stPny.dZ / Math.Sqrt(Math.Pow(stPny.dZ, 2) + Math.Pow(stPny.dY, 2)));
            stFrame.dAX = stFrame.dAX * 180 / Math.PI;
            */

            // 2016.07.07 by khWoo
            //------ z축 중심으로 회전
            if (stPa.dX >= 0)   // (stPa.dX, stPa.dY)  <-- x축이 기준축
            {
                if (stPa.dX == 0 && stPa.dY == 0)   // origin
                    stFrame.dAZ = 0;
                else            // -90 ~ +90 (1사분면, 4사분면)
                    stFrame.dAZ = Math.Asin(stPa.dY / Math.Sqrt(Math.Pow(stPa.dX, 2) + Math.Pow(stPa.dY, 2)));
            }
            else
            {
                if (stPa.dY == 0)   // -x축 위
                {
                    stFrame.dAZ = Math.PI;   // Math.Acos(stPa.dX / Math.Sqrt(Math.Pow(stPa.dX, 2) + Math.Pow(stPa.dY, 2)));
                }
                else   // 2사분면, 3사분면
                {
                    stFrame.dAZ = (stPa.dY / Math.Abs(stPa.dY)) * Math.Acos(stPa.dX / Math.Sqrt(Math.Pow(stPa.dX, 2) + Math.Pow(stPa.dY, 2)));
                }
            }
            
            stFrame.dAZ = stFrame.dAZ * 180 / Math.PI;

            /*
            ASDef._stXYZ stPnz, stPbz;  //, stPaz; 
            stPnz = default(ASDef._stXYZ);
            //stPaz = default(ASDef._stXYZ);
            stPbz = default(ASDef._stXYZ);
            RotateZ(-stFrame.dAZ, stPn, ref stPnz);
            //RotateZ(-stFrame.dAZ, stPa, ref stPaz);
            RotateZ(-stFrame.dAZ, stPb, ref stPbz);   // stPa, stPb, stPn을 dAZ만큼 z축 중심으로 회전
            */
            ASDef._stXYZ stPnz, stPaz;
            stPnz = default(ASDef._stXYZ);
            stPaz = default(ASDef._stXYZ);
            RotateZ(-stFrame.dAZ, stPn, ref stPnz);     // stPn을 -dAZ만큼 z축 중심으로 회전
            RotateZ(-stFrame.dAZ, stPa, ref stPaz);     // stPa을 -dAZ만큼 z축 중심으로 회전
           

            // 2016.07.21 bby khWoo
            //------ y축 중심으로 회전
            if (stPaz.dX >= 0)     // (stPaz.dX, stPaz.dZ)  <-- x축이 기준축
            {
                if (stPaz.dZ == 0 && stPaz.dX == 0)    // origin
                    stFrame.dAY = 0;
                else          // -90 ~ +90 (1사분면, 4사분면)
                    stFrame.dAY = Math.Asin(stPaz.dZ / Math.Sqrt(Math.Pow(stPaz.dX, 2) + Math.Pow(stPaz.dZ, 2)));
            }
            else
            {
                if (stPaz.dZ == 0)    // -x축 위
                    stFrame.dAY = Math.PI;
                else
                    stFrame.dAY = (stPaz.dZ / Math.Abs(stPaz.dZ)) * Math.Acos(stPaz.dX / Math.Sqrt(Math.Pow(stPaz.dX, 2) + Math.Pow(stPaz.dZ, 2)));
            }

            stFrame.dAY = -stFrame.dAY * 180 / Math.PI;

            ASDef._stXYZ stPny;
            stPny = default(ASDef._stXYZ);
            RotateY(-stFrame.dAY, stPnz, ref stPny);  // stPnz을 dAY만큼 y축 중심으로 회전

            // 2016.07.21 bby khWoo
            //------ x축 중심으로 회전
            if (stPny.dZ >= 0)  // (stPby.dZ, stPby.dY)  <-- z축이 기준축
            {
                if (stPny.dY == 0 && stPny.dZ == 0)
                    stFrame.dAX = 0;    // origin
                else          // -90 ~ +90 (1사분면, 4사분면)
                    stFrame.dAX = Math.Asin(stPny.dY / Math.Sqrt(Math.Pow(stPny.dY, 2) + Math.Pow(stPny.dZ, 2)));
            }
            else
            {
                if (stPny.dY == 0)   // -z축 위
                    stFrame.dAX = Math.PI;
                else
                    stFrame.dAX = (stPny.dY / Math.Abs(stPny.dY)) * Math.Acos(stPny.dZ / Math.Sqrt(Math.Pow(stPny.dY, 2) + Math.Pow(stPny.dZ, 2)));
            }
            stFrame.dAX = -stFrame.dAX * 180 / Math.PI;
            
        }
        // 기준 좌표계의 값을 다른 좌표계 값으로 변환
        public static void BaseToFrame(ASDef._stXYZ stSource, ref ASDef._stXYZ stDest, _emRotationOrder emRotationOrder, ASDef._stRobotShift stFrame)
        {
            // 2016.07.07 by khWoo
            // **********************************************************************
            // [ stDest.dX ]            [ stSource.dX ]   [ stFrame.dX ]
            // | stDest.dY |  =  RevM ( | stSource.dY | - | stFrame.dY |  )
            // [ stDest.dZ ]            [ stSource.dZ ]   [ stFrame.dZ ]
            // **********************************************************************

            double[,] RevM = new double[3, 3];
            double RX = stFrame.dAX * Math.PI / 180;
            double RY = stFrame.dAY * Math.PI / 180;
            double RZ = stFrame.dAZ * Math.PI / 180;

            double dX = stSource.dX - stFrame.dX;
            double dY = stSource.dY - stFrame.dY;
            double dZ = stSource.dZ - stFrame.dZ;

            switch (emRotationOrder)
            {
                case _emRotationOrder.ZYX:
                    RevM[0, 0] = Math.Cos(RZ) * Math.Cos(RY);
                    RevM[0, 1] = Math.Sin(RZ) * Math.Cos(RY);
                    RevM[0, 2] = -Math.Sin(RY);

                    RevM[1, 0] = -Math.Sin(RZ) * Math.Cos(RX) + Math.Sin(RX) * Math.Cos(RZ) * Math.Sin(RY);
                    RevM[1, 1] = Math.Cos(RX) * Math.Cos(RZ) + Math.Sin(RX) * Math.Sin(RY) * Math.Sin(RZ);
                    RevM[1, 2] = Math.Sin(RX) * Math.Cos(RY);

                    RevM[2, 0] = Math.Sin(RX) * Math.Sin(RZ) + Math.Cos(RX) * Math.Cos(RZ) * Math.Sin(RY);
                    RevM[2, 1] = -Math.Sin(RX) * Math.Cos(RZ) + Math.Sin(RY) * Math.Sin(RZ) * Math.Cos(RX);
                    RevM[2, 2] = Math.Cos(RX) * Math.Cos(RY);
                    break;
                case _emRotationOrder.ZYZ:
                    RevM[0, 0] = Math.Cos(RZ) * Math.Cos(RX) * Math.Cos(RY) - Math.Sin(RZ) * Math.Sin(RX);
                    RevM[0, 1] = Math.Cos(RZ) * Math.Sin(RX) * Math.Cos(RY) + Math.Sin(RZ) * Math.Cos(RX);
                    RevM[0, 2] = -Math.Sin(RY) * Math.Cos(RZ);

                    RevM[1, 0] = -Math.Sin(RZ) * Math.Cos(RX) * Math.Cos(RY) - Math.Cos(RZ) * Math.Sin(RX);
                    RevM[1, 1] = -Math.Sin(RZ) * Math.Sin(RX) * Math.Cos(RY) + Math.Cos(RZ) * Math.Cos(RX);
                    RevM[1, 2] = Math.Sin(RZ) * Math.Sin(RY);

                    RevM[2, 0] = Math.Cos(RX) * Math.Sin(RY);
                    RevM[2, 1] = Math.Sin(RX) * Math.Sin(RY);
                    RevM[2, 2] = Math.Cos(RY);
                    break;
            }
            
            stDest.dX = RevM[0, 0] * dX + RevM[0, 1] * dY + RevM[0, 2] * dZ;
            stDest.dY = RevM[1, 0] * dX + RevM[1, 1] * dY + RevM[1, 2] * dZ;
            stDest.dZ = RevM[2, 0] * dX + RevM[2, 1] * dY + RevM[2, 2] * dZ;
        }

        // 다른 좌표계의 값을 기준 좌표계 값으로 변환
        public static void FrameToBase(ASDef._stXYZ stSource, ref ASDef._stXYZ stDest, _emRotationOrder emRotationOrder, ASDef._stRobotShift stFrame)
        {
            // 2016.07.07 by khWoo
            // *****************************************************
            // [ stDest.dX ]       [ stSource.dX ]   [ stFrame.dX ]
            // | stDest.dY |  =  M | stSource.dY | + | stFrame.dY |
            // [ stDest.dZ ]       [ stSource.dZ ]   [ stFrame.dZ ]
            // *****************************************************

            double[,] M = new double[3, 3];
            double RX = stFrame.dAX * Math.PI / 180;
            double RY = stFrame.dAY * Math.PI / 180;
            double RZ = stFrame.dAZ * Math.PI / 180;

            switch (emRotationOrder)
            {
                case _emRotationOrder.ZYX:
                    M[0, 0] = Math.Cos(RZ) * Math.Cos(RY);
                    M[0, 1] = -Math.Sin(RZ) * Math.Cos(RX) + Math.Sin(RX) * Math.Cos(RZ) * Math.Sin(RY);
                    M[0, 2] = Math.Sin(RX) * Math.Sin(RZ) + Math.Cos(RX) * Math.Cos(RZ) * Math.Sin(RY);
                    
                    M[1, 0] = Math.Sin(RZ) * Math.Cos(RY);
                    M[1, 1] = Math.Cos(RX) * Math.Cos(RZ) + Math.Sin(RX) * Math.Sin(RY) * Math.Sin(RZ);
                    M[1, 2] = -Math.Sin(RX) * Math.Cos(RZ) + Math.Sin(RY) * Math.Sin(RZ) * Math.Cos(RX);
                    
                    M[2, 0] = -Math.Sin(RY);
                    M[2, 1] = Math.Sin(RX) * Math.Cos(RY);
                    M[2, 2] = Math.Cos(RX) * Math.Cos(RY);
                    break;
                case _emRotationOrder.ZYZ:
                    M[0, 0] = Math.Cos(RZ) * Math.Cos(RX) * Math.Cos(RY) - Math.Sin(RZ) * Math.Sin(RX);
                    M[0, 1] = -Math.Sin(RZ) * Math.Cos(RX) * Math.Cos(RY) - Math.Cos(RZ) * Math.Sin(RX);
                    M[0, 2] = Math.Cos(RX) * Math.Sin(RY);
                    
                    M[1, 0] = Math.Cos(RZ) * Math.Sin(RX) * Math.Cos(RY) + Math.Sin(RZ) * Math.Cos(RX);
                    M[1, 1] = -Math.Sin(RZ) * Math.Sin(RX) * Math.Cos(RY) + Math.Cos(RZ) * Math.Cos(RX);
                    M[1, 2] = Math.Sin(RX) * Math.Sin(RY);
                    
                    M[2, 0] = -Math.Sin(RY) * Math.Cos(RZ);
                    M[2, 1] = Math.Sin(RZ) * Math.Sin(RY);
                    M[2, 2] = Math.Cos(RY);
                    break;
            }

            stDest.dX = M[0, 0] * stSource.dX + M[0, 1] * stSource.dY + M[0, 2] * stSource.dZ + stFrame.dX;
            stDest.dY = M[1, 0] * stSource.dX + M[1, 1] * stSource.dY + M[1, 2] * stSource.dZ + stFrame.dY;
            stDest.dZ = M[2, 0] * stSource.dX + M[2, 1] * stSource.dY + M[2, 2] * stSource.dZ + stFrame.dZ;
        }
        public static void RotateZ(double dRotate, ASDef._stXYZ stSource, ref ASDef._stXYZ stDest)
        {
            double[,] M = new double[4, 4];
            double dA = dRotate * Math.PI / 180;

            M[0, 0] = Math.Cos(dA);
            M[0, 1] = -Math.Sin(dA);
            M[0, 2] = 0;
            M[0, 3] = 0;

            M[1, 0] = Math.Sin(dA);
            M[1, 1] = Math.Cos(dA);
            M[1, 2] = 0;
            M[1, 3] = 0;

            M[2, 0] = 0;
            M[2, 1] = 0;
            M[2, 2] = 1;
            M[2, 3] = 0;

            M[3, 0] = 0;
            M[3, 1] = 0;
            M[3, 2] = 0;
            M[3, 3] = 1;

            stDest.dX = M[0, 0] * stSource.dX + M[0, 1] * stSource.dY + M[0, 2] * stSource.dZ + M[0, 3] * 1;
            stDest.dY = M[1, 0] * stSource.dX + M[1, 1] * stSource.dY + M[1, 2] * stSource.dZ + M[1, 3] * 1;
            stDest.dZ = M[2, 0] * stSource.dX + M[2, 1] * stSource.dY + M[2, 2] * stSource.dZ + M[2, 3] * 1;
        }

        public static void RotateY(double dRotate, ASDef._stXYZ stSource, ref ASDef._stXYZ stDest)
        {
            double[,] M = new double[4, 4];
            double dA = dRotate * Math.PI / 180;

            M[0, 0] = Math.Cos(dA);
            M[0, 1] = 0;
            M[0, 2] = Math.Sin(dA);
            M[0, 3] = 0;

            M[1, 0] = 0;
            M[1, 1] = 1;
            M[1, 2] = 0;
            M[1, 3] = 0;

            M[2, 0] = -Math.Sin(dA);
            M[2, 1] = 0;
            M[2, 2] = Math.Cos(dA);
            M[2, 3] = 0;

            M[3, 0] = 0;
            M[3, 1] = 0;
            M[3, 2] = 0;
            M[3, 3] = 1;

            stDest.dX = M[0, 0] * stSource.dX + M[0, 1] * stSource.dY + M[0, 2] * stSource.dZ + M[0, 3] * 1;
            stDest.dY = M[1, 0] * stSource.dX + M[1, 1] * stSource.dY + M[1, 2] * stSource.dZ + M[1, 3] * 1;
            stDest.dZ = M[2, 0] * stSource.dX + M[2, 1] * stSource.dY + M[2, 2] * stSource.dZ + M[2, 3] * 1;
        }

        public static void RotateX(double dRotate, ASDef._stXYZ stSource, ref ASDef._stXYZ stDest)
        {
            double[,] M = new double[4, 4];
            double dA = dRotate * Math.PI / 180;

            M[0, 0] = 1;
            M[0, 1] = 0;
            M[0, 2] = 0;
            M[0, 3] = 0;

            M[1, 0] = 0;
            M[1, 1] = Math.Cos(dA);
            M[1, 2] = -Math.Sin(dA);
            M[1, 3] = 0;

            M[2, 0] = 0;
            M[2, 1] = Math.Sin(dA);
            M[2, 2] = Math.Cos(dA);
            M[2, 3] = 0;

            M[3, 0] = 0;
            M[3, 1] = 0;
            M[3, 2] = 0;
            M[3, 3] = 1;

            stDest.dX = M[0, 0] * stSource.dX + M[0, 1] * stSource.dY + M[0, 2] * stSource.dZ + M[0, 3] * 1;
            stDest.dY = M[1, 0] * stSource.dX + M[1, 1] * stSource.dY + M[1, 2] * stSource.dZ + M[1, 3] * 1;
            stDest.dZ = M[2, 0] * stSource.dX + M[2, 1] * stSource.dY + M[2, 2] * stSource.dZ + M[2, 3] * 1;
        }
        
        /*
         * 기준 4포인트에서 이동후 1포인트의 이동값을 모르는 경우 찾는
         * 3 --------------4
         * |               |
         * |               | 
         * |               |
         * |               |
         * 2---------------1
         * 0 : 4번을 모르는 경우 2:Org 1:xx 3:xy
         * 1 : 1번을 모르는 경우 3:Org 2:xx 4:xy
         * 2 : 3번을 모르는 경우 1:Org 4:xx 2:xy
         * 3 : 2번을 모르는 경우 4:Org 3:xx 1:xy
         */
        public static void FindLost1Point(ASDef._stXYZ[] pstSource, ASDef._stXYZ[] pstMove, ref ASDef._stXYZ stLost1Point, int nCase)
        {
            ASDef._stRobotShift stFrame;
            stFrame = default(ASDef._stRobotShift);
            ASDef._stXYZ[] pst3Point = new ASDef._stXYZ[3];
            ASDef._stXYZ st1Point;
            st1Point = default(ASDef._stXYZ);

            switch(nCase)
            {
                // 0 : 4번을 모르는 경우 2:Org 1:xx 3:xy
                case 0:
                    {
                        pst3Point[0] = pstSource[1]; // ORG
                        pst3Point[1] = pstSource[0]; // XX
                        pst3Point[2] = pstSource[2]; // XY
                        MakeFrame(pst3Point, ref stFrame);
                        BaseToFrame(pstSource[3], ref st1Point, _emRotationOrder.ZYX, stFrame);

                        pst3Point[0] = pstMove[1]; // ORG
                        pst3Point[1] = pstMove[0]; // XX
                        pst3Point[2] = pstMove[2]; // XY
                        MakeFrame(pst3Point, ref stFrame);
                        FrameToBase(st1Point, ref stLost1Point, _emRotationOrder.ZYX, stFrame);
                    }
                    break;
                // 2011.08.16 4<->2
                //  1 : 1번을 모르는 경우 3:Org 2:xx 4:xy
                case 1:
                    {
                        pst3Point[0] = pstSource[2]; // ORG
                        pst3Point[1] = pstSource[1]; // XX
                        pst3Point[2] = pstSource[3]; // XY
                        MakeFrame(pst3Point, ref stFrame);
                        BaseToFrame(pstSource[0], ref st1Point, _emRotationOrder.ZYX, stFrame);

                        pst3Point[0] = pstMove[2]; // ORG
                        pst3Point[1] = pstMove[1]; // XX
                        pst3Point[2] = pstMove[3]; // XY
                        MakeFrame(pst3Point, ref stFrame);
                        FrameToBase(st1Point, ref stLost1Point, _emRotationOrder.ZYX, stFrame);
                    }
                    break;
                // 2011.08.16 4<->2
                // 2 : 3번을 모르는 경우 1:Org 4:xx 2:xy
                case 2:
                    {
                        pst3Point[0] = pstSource[0]; // ORG
                        pst3Point[1] = pstSource[3]; // XX
                        pst3Point[2] = pstSource[1]; // XY
                        MakeFrame(pst3Point, ref stFrame);
                        BaseToFrame(pstSource[2], ref st1Point, _emRotationOrder.ZYX, stFrame);

                        pst3Point[0] = pstMove[0]; // ORG
                        pst3Point[1] = pstMove[3]; // XX
                        pst3Point[2] = pstMove[1]; // XY
                        MakeFrame(pst3Point, ref stFrame);
                        FrameToBase(st1Point, ref stLost1Point, _emRotationOrder.ZYX, stFrame);
                    }
                    break;
                // 3 : 2번을 모르는 경우 4:Org 3:xx 1:xy
                case 3:
                    {
                        pst3Point[0] = pstSource[3]; // ORG
                        pst3Point[1] = pstSource[2]; // XX
                        pst3Point[2] = pstSource[0]; // XY
                        MakeFrame(pst3Point, ref stFrame);
                        BaseToFrame(pstSource[1], ref st1Point, _emRotationOrder.ZYX, stFrame);

                        pst3Point[0] = pstMove[3]; // ORG
                        pst3Point[1] = pstMove[2]; // XX
                        pst3Point[2] = pstMove[0]; // XY
                        MakeFrame(pst3Point, ref stFrame);
                        FrameToBase(st1Point, ref stLost1Point, _emRotationOrder.ZYX, stFrame);
                    }
                    break;
            }
        }
                
        public float FindXYZ(_emPosition emPosition, ref _stMeasure stMeasure)
        {   
            Point2f p0 = new Point2f((float)stMeasure.pstHole[0].dX, (float)stMeasure.pstHole[0].dY);
            Point2f p1 = new Point2f((float)stMeasure.pstHole[1].dX, (float)stMeasure.pstHole[1].dY);
            float fRMS;
            var center = m_pStereoCamera[(int)emPosition].Triangulate( p0, p1, out fRMS);
            Vector4d vcenter = m_pCamPose[(int)emPosition] * LotusAPI.Math.Utils.ToHomogeneous(LotusAPI.Math.Utils.ToVector3d(center));
            
            Vector3d vxyz = LotusAPI.Math.Utils.FromHomogeneous(vcenter);

            stMeasure.stShift.dX = vxyz.X;
            stMeasure.stShift.dY = vxyz.Y;
            stMeasure.stShift.dZ = vxyz.Z;

            return fRMS;
        }
        
    }
}
