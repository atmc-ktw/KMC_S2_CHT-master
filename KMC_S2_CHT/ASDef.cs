using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Drawing;

namespace Atmc
{
    public class ASDef
    {
        public const int _WM_USER = 0x0400;
        public const int _WM_CHANGE_DI = (_WM_USER + 10);
        public const int _WM_CHANGE_DO = (_WM_USER + 11);
        public const int _WM_LOAD_FILEDEL = (_WM_USER + 14);
        public const int _WM_PASSWORD_CHECK = (_WM_USER + 207);
        // 2020.03.11
        public const int _WM_CAMERA_IS_DISCONNECTED = (_WM_USER + 230);

        public const int _WM_CHANGE_XYZ = (_WM_USER + 500);

        public static readonly string _INI_PATH = "C:\\ATM\\InitFiles_KMC_S2_CHT";
        public static readonly string _INI_FILE = "C:\\ATM\\InitFiles_KMC_S2_CHT\\KMC_S2_CHT.ini";
        // 2016.07.31
        public static readonly string _CAM_FILE = "C:\\ATM\\InitFiles_KMC_S2_CHT\\KMC_S2_CHT.cam.ini";

        public static readonly string _XML_LANGUAGE = "C:\\ATM\\InitFiles_KMC_S2_CHT\\Language.xml";
        public static string _LANGUAGE = "kor";
        
        public static readonly int _WM_LOAD_INI = 202;

        #region 3D_Source
        public const int _3D_POINT_COUNT = 6;
        public const int _3D_POSITION_COUNT = 3;
        #endregion

        #region 2D_Source
        public const int _2D_POINT_COUNT = 8; //(4+4)
        #endregion

        public const int _POINT_COUNT = 14; //(_3D_POINT_COUNT + _2D_POINT_COUNT)

        public const int _LIMIT_COUNT = 1;
        public const int _MAX_LIGHT_CONTROL = 1;
        
        // 2011.07.22        
        public const int _PMALIGN_TRAIN_ALGORITHM = 2; // 0:PatMax, 1:PatQuick 2:PatMaxAndPatQuick 4:PatMaxHighSensitivity
        
        public const int _MAX_ROBOT = 2;
        
        //public const int _OFFSET_COUNT = 4 * _MAX_ROBOT;
        public const int _OFFSET_COUNT = 8;
        
        // 2016.11.09
        public const int _DELAY_LIGHT_CONTROL = 200;

        /*
        // 2011.07.30
        public const int _MOVE_MIN_X = -180;
        public const int _MOVE_MAX_X = 180;
        public const int _MOVE_MIN_Y = -120;
        public const int _MOVE_MAX_Y = 120;
        public const int _MOVE_MIN_Z = -80;
        public const int _MOVE_MAX_Z = 80;

        public const int _MOVE_STEP_X = 10;
        public const int _MOVE_STEP_Y = 10;
        public const int _MOVE_STEP_Z = 10;
        public const int _MOVE_SIZE_X = 37;   //((_MOVE_MAX_X-_MOVE_MIN_X)/_MOVE_STEP_X+1)
        public const int _MOVE_SIZE_Y = 25;   //((_MOVE_MAX_Y-_MOVE_MIN_Y)/_MOVE_STEP_Y+1)
        public const int _MOVE_SIZE_Z = 17;   //((_MOVE_MAX_Z-_MOVE_MIN_Z)/_MOVE_STEP_Z+1)
        */

        public struct _stXY
        {
            public double dX;
            public double dY;
        };

        public struct _stXYZ
        {
            public double dX;
            public double dY;
            public double dZ;
        };

        public struct _stRobotShift
        {
            public double dX;
            public double dY;
            public double dZ;
            public double dAX;
            public double dAY;
            public double dAZ;
        };

        public enum _emResult { Over = -2, NG, NO, OK, Pass };
        public static readonly Color[] pclrResult = { Color.Indigo, Color.Red, Color.Gray, Color.GreenYellow, Color.OrangeRed };

        //PLC
        public const uint _DI = 0;
        public const uint _DO = 1;

        public const int _MAX_PLC_DI = 8;
        public const int _MAX_PLC_DO = 2;

        public const int _DI_SIGNAL = 0;
        public const int _DI_BODY = 1;
        public const int _DI_SEQ_NO = 2;
        public const int _DI_BODY_NO = 4;
        
        public const int _DI_BIT_START_P1 = 0;
        public const int _DI_BIT_START_P2 = 1;
        public const int _DI_BIT_START_P3 = 2;

        public const int _DI_BIT_START_LH1_L = 3;
        public const int _DI_BIT_START_LH2_L = 4;
        public const int _DI_BIT_START_RH1_L = 5;
        public const int _DI_BIT_START_RH2_L = 6;

        public const int _DI_BIT_START_LH1_R = 7;
        public const int _DI_BIT_START_LH2_R = 8;
        public const int _DI_BIT_START_RH1_R = 9;
        public const int _DI_BIT_START_RH2_R = 10;
        
        
        public const int _DI_BIT_COMPLETE = 11;
        public const int _DI_BIT_RESET = 12;

        public const int _DO_SIGNAL = 0;
        public const int _DO_PC_RUN = 1;
        
        public const int _DO_BIT_COMPLETE_P1 = 0;
        public const int _DO_BIT_COMPLETE_P2 = 1;
        public const int _DO_BIT_COMPLETE_P3 = 2;

        public const int _DO_BIT_OK_LH1 = 3;
        public const int _DO_BIT_NG_LH1 = 4;
        public const int _DO_BIT_OK_LH2 = 5;
        public const int _DO_BIT_NG_LH2 = 6;
        public const int _DO_BIT_OK_RH1 = 7;
        public const int _DO_BIT_NG_RH1 = 8;
        public const int _DO_BIT_OK_RH2 = 9;
        public const int _DO_BIT_NG_RH2 = 10;
                
        public const int _DO_BIT_PC_RUN = 15;
        

    }
}
