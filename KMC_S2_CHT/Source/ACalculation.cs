using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACom
{
    // 2013.02.04 모두 static으로
    class ACalculation
    {
        public static readonly double _PI = 3.14159265358979;

        /*
        입력
	        0: dxVL
	        1: dyVL
	        2: dxVR
	        3: dyVR
        길이
	        0: lenVL2R
	        1: xVL2PL
	        2: yVL2PL
	        3: xVR2PR
	        4: yVR2PR
        출력
            0: dxPL
	        1: dyPL
	        2: dxPR
	        3: dyPR
        */
        public static void CalcuShift2Point(double[] pdIn, double[] pdLen, out double[] pdOut)
        {
            double dxVL = 0, dyVL = 0, dxVR = 0, dyVR = 0;
            double lenVL2R = 0, xVL2PL = 0, yVL2PL = 0, xVR2PR = 0, yVR2PR = 0;
            double dxPL = 0, dyPL = 0, dxPR = 0, dyPR = 0;
            double dAngle = 0;

            if (pdIn.Length >= 4)
            {
                dxVL = pdIn[0];
                dyVL = pdIn[1];
                dxVR = pdIn[2];
                dyVR = pdIn[3];
            }
            if (pdLen.Length >= 5)
            {
                lenVL2R = pdLen[0];
                xVL2PL = pdLen[1];
                yVL2PL = pdLen[2];
                xVR2PR = pdLen[3];
                yVR2PR = pdLen[4];
            }

            dAngle = Math.Asin((dyVR - dyVL) / lenVL2R);

            dxPL = dxVL + Math.Cos(dAngle) * xVL2PL - Math.Sin(dAngle) * yVL2PL - xVL2PL;
            dyPL = dyVL + Math.Sin(dAngle) * xVL2PL + Math.Cos(dAngle) * yVL2PL - yVL2PL;
            dxPR = dxVR + Math.Cos(dAngle) * xVR2PR - Math.Sin(dAngle) * yVR2PR - xVR2PR;
            dyPR = dyVR + Math.Sin(dAngle) * xVR2PR + Math.Cos(dAngle) * yVR2PR - yVR2PR;

            pdOut = new double[5];
            pdOut[0] = dxPL;
            pdOut[1] = dyPL;
            pdOut[2] = dxPR;
            pdOut[3] = dyPR;
        }

        /*
        입력
	        0: dxV
	        1: dyV
	        2: angle
        길이
	        0: lenVL2R
	        1: xVL2PL
	        2: yVL2PL
	        3: xVR2PR
	        4: yVR2PR
        출력
            0: dxPL
	        1: dyPL
	        2: dxPR
	        3: dyPR
        */
        public static void CalcuShiftAngle(double[] pdIn, double[] pdLen, out double[] pdOut)
        {
            double dxV = 0, dyV = 0, dAngle = 0;
            double lenVL2R = 0, xVL2PL = 0, yVL2PL = 0, xVR2PR = 0, yVR2PR = 0;
            double dxPL = 0, dyPL = 0, dxPR = 0, dyPR = 0;

            if (pdIn.Length >= 3)
            {
                dxV = pdIn[0];
                dyV = pdIn[1];
                dAngle = pdIn[2];
            }
            if (pdLen.Length >= 5)
            {
                lenVL2R = pdLen[0];
                xVL2PL = pdLen[1];
                yVL2PL = pdLen[2];
                xVR2PR = pdLen[3];
                yVR2PR = pdLen[4];
            }

            dAngle = dAngle * _PI / 180;

            dxPL = dxV + Math.Cos(dAngle) * xVL2PL - Math.Sin(dAngle) * yVL2PL - xVL2PL;
            dyPL = dyV + Math.Sin(dAngle) * xVL2PL + Math.Cos(dAngle) * yVL2PL - yVL2PL;
            dxPR = dxV + Math.Cos(dAngle) * xVR2PR - Math.Sin(dAngle) * yVR2PR - xVR2PR;
            dyPR = dyV + Math.Sin(dAngle) * xVR2PR + Math.Cos(dAngle) * yVR2PR - yVR2PR;

            pdOut = new double[4];
            pdOut[0] = dxPL;
            pdOut[1] = dyPL;
            pdOut[2] = dxPR;
            pdOut[3] = dyPR;
        }

        /*
        입력
	        0: dxV
	        1: dyV
	        2: angle
        출력
	        0: dxP
	        1: dyP
        */
        public static void CalcuAngle(double[] pdIn, out double[] pdOut)
        {
            //입력
            double dxV = 0;
            double dyV = 0;
            double angle = 0;
            //출력
            double dxP;
            double dyP;

            if (pdIn.Length >= 3)
            {
                dxV = pdIn[0];
                dyV = pdIn[1];
                angle = pdIn[2];
            }

            // 2013.02.04
            /*
            angle = (90 - angle) * _PI / 180;
            dxP = Math.Sin(angle) * dyV + Math.Cos(angle) * dxV;
            dyP = Math.Cos(angle) * dyV - Math.Sin(angle) * dxV;
            */
            angle = angle * _PI / 180;
            dxP = Math.Cos(angle) * dxV - Math.Sin(angle) * dyV;
            dyP = Math.Sin(angle) * dxV + Math.Cos(angle) * dyV;
            
            pdOut = new double[2];

            pdOut[0] = dxP;
            pdOut[1] = dyP;
        }

        public static void CalcuAnglePC(double[] pdIn, out double[] pdOut)
        {
            //입력
            double dxV = 0;
            double dyV = 0;
            double angle = 0;
            //출력
            double dxP;
            double dyP;

            if (pdIn.Length >= 3)
            {
                dxV = pdIn[0];
                dyV = pdIn[1];
                angle = pdIn[2];
            }

            angle = (90 - angle) * _PI / 180;
            dxP = Math.Sin(angle) * dyV + Math.Cos(angle) * dxV;
            dyP = Math.Cos(angle) * dyV - Math.Sin(angle) * dxV;
            
            pdOut = new double[2];

            pdOut[0] = dxP;
            pdOut[1] = dyP;
        }
        /*
        입력
           pdP1[0]: 초기위치-홀가운데점 x
               [1]: 초기위치-홀가운데점 y
          
           pdP1[0]: 이동위치-홀가운데점 x
               [1]: 이동위치-홀가운데점 y
          
           isColockWise : 시계방향:1 
        */
        public static double CalcuAngleBetweenTwoPoint(double[] pdP1, double[] pdP2, bool isClockWise)
        {
            //acos()나 asin()함수로 구하는 각도를 degree로 나타냈을때
            //그 범위는 0~180이다.

            //각도를 0~360으로 나타내기 위한 사전작업으로
            //기준점(stPoint1)을 90도 회전시킨 점을 구한다.
            double dRotated90Point1X = 0;
            double dRotated90Point1Y = 0;

            if (isClockWise)
            {
                dRotated90Point1X = -pdP1[1];
                dRotated90Point1Y = pdP1[0];
            }
            else
            {
                dRotated90Point1X = pdP1[1];
                dRotated90Point1Y = -pdP1[0];
            }

            //앞서 계산한 점과 두번째 인자로 받은 점간의 각도를 구함.
            //이 각도가 90도보다 크다면 첫번째인자로 받은 기준점과 두번째 점간의 각도가
            //180도보다 크다는 것을 의미한다.

            double dAng = Math.Acos((dRotated90Point1X * pdP2[0] + dRotated90Point1Y * pdP2[1]) /
                (Math.Sqrt(dRotated90Point1X * dRotated90Point1X + dRotated90Point1Y * dRotated90Point1Y) *
                Math.Sqrt(pdP2[0] * pdP2[0] + pdP2[1] * pdP2[1])))
                * 180 / _PI;

            //fAng의 크기에 따라 두점사이의 각도를 다른 방식으로 구함.
            if (dAng > 90)
                dAng = 360 - Math.Acos((pdP1[0] * pdP2[0] + pdP1[1] * pdP2[1]) /
                    (Math.Sqrt(pdP1[0] * pdP1[0] + pdP1[1] * pdP1[1]) *
                    Math.Sqrt(pdP2[0] * pdP2[0] + pdP2[1] * pdP2[1])))
                    * 180 / _PI;

            else
                dAng = Math.Acos((pdP1[0] * pdP2[0] + pdP1[1] * pdP2[1]) /
                    (Math.Sqrt(pdP1[0] * pdP1[0] + pdP1[1] * pdP1[1]) *
                    Math.Sqrt(pdP2[0] * pdP2[0] + pdP2[1] * pdP2[1])))
                    * 180 / _PI;

            if (dAng >= 180)
            {
                dAng -= 360;
            }
            else if (dAng <= -180)
            {
                dAng += 360;
            }
            return dAng;
        }
    }
}
