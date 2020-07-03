//#define _USE_BASLER_PYLON

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;
using AVisionPro;
using Atmc;
using ACom;
using ADrv;
using Cognex.VisionPro;
using System.IO;

#if _USE_BASLER_PYLON
using BaslerPylon;
#endif

using System.Net.NetworkInformation;

using LotusAPI;
//using LotusAPI.Controls;

namespace KMC_S2_CHT
{
    public partial class FrmMain : Form
    {
#region Member Variable


        #region 3D_Source
        //-------------------------------------------------------------
        // 2016.10.14 private=>public
        //public CheckBox[] m_pchkUse = null;

        private CheckBox[] m_pchkLive = null;
        private CheckBox[] m_pchkLiveSearch = null;
        private Label[] m_plblStateCommRbt = null;
        private Label[] m_plblResult = null;
        private Label[] m_plblX_Calib = null;
        private Label[] m_plblY_Calib = null;
        private Label[] m_plblZ_Calib = null;
        private Label[] m_plblX_3D = null;
        private Label[] m_plblY_3D = null;
        private Label[] m_plblZ_3D = null;

        // 2011.08.15
        private Label[] m_plblX_CalibSub = null;
        private Label[] m_plblY_CalibSub = null;
        private Label[] m_plblZ_CalibSub = null;

        // 2020.03.12
        //private Label[] m_plblX_Calcu = null;
        //private Label[] m_plblY_Calcu = null;
        //private Label[] m_plblZ_Calcu = null;

        private Label[] m_plblX_L = null;
        private Label[] m_plblY_L = null;
        private Label[] m_plblX_R = null;
        private Label[] m_plblY_R = null;

        public ACalculationLotus3D m_aCalculationLotus3D;

        // 2015.10.26
        //private int m_nCalibX, m_nCalibY, m_nCalibZ;
        // 2016.10.14 private=>public
        public ACalculationLotus3D._stMeasure[] m_pstMeasure = new ACalculationLotus3D._stMeasure[ASDef._3D_POSITION_COUNT];

        private ASDef._stRobotShift m_stShift;
        private ACalculationLotus3D._stHoleLength m_stHoleLength;
        private int[] m_pnR_3D = new int[ASDef._3D_POSITION_COUNT];
        // 2015.10.26
        //public bool m_bSaveCalib;

        AIniHoleLocation m_aIniHoleLocation = null;
        AIniPartOffset m_aIniPartOffset = null;

        // 2012.02.29
        private bool m_bLive = false;
        //-------------------------------------------------------------
        #endregion

        #region 2D_Source
        //-------------------------------------------------------------
        private Label[] m_plblX = null;
        private Label[] m_plblY = null;

        private struct _stResult
        {
            public ASDef._stXY stXY;
            
            public ASDef._emResult emR;

            //public double dTok;

            public int nP_Index;
            public int nL_Index;
            public string strP_Name;
            public double dP_Score;

        }
        private _stResult[] m_pstResult = new _stResult[ASDef._2D_POINT_COUNT];
        //-------------------------------------------------------------
        #endregion

        //DateTime m_dtRunRevisions;
        //private string m_strDateTimeRunRevisions;

        private AThrdClientSocketPlcSiemens m_AThrdPlc = null;
        private AThrdUdpServerSocketRbtHHI[] m_pAThrdRbt = null;

        // 2016.11.09
        private ACommLightControl[] m_pACommLightControl = new ACommLightControl[ASDef._MAX_LIGHT_CONTROL];
        
        private bool m_IsInitializing = false;


        // 2014.10.25
        private bool m_bClosing = false;

        // 2015.01.03
        private int m_nPlcErrCountR = 0;
        private int m_nPlcErrCountW = 0;
        private float m_fFreeHDD_Percent = 0;
        private int[] m_pnDI = new int[ASDef._MAX_PLC_DI];
        private int[] m_pnOldDI = new int[ASDef._MAX_PLC_DI];
        private bool m_bLockDI = false;

        // 2016.06.15
        private bool m_bTopWindow = true;

        // 2020.03.11
        private Dictionary<string, string> m_dicDisconnectedCamera = new Dictionary<string, string>();


#endregion
        //동기화 문제를 위한 델리게이트
        delegate void dgDisplayThreadLabelText(Label lbl, string strdata);
        
        delegate void dgAddLstBxMessage(string strdata);

#if _USE_BASLER_PYLON
        // 2017.01.10 by kdi
        delegate void dgSetTimer(System.Windows.Forms.Timer tmr, bool bEnable, bool bForciblyDisable);
#endif

        public FrmMain()
        {
            //-----------------------------------
            //             Splash
            FrmSplash frmSplash = new FrmSplash();
            this.Hide();
            Thread beginThrd = new Thread(new ThreadStart(frmSplash.ShowSplashScreen));
            beginThrd.IsBackground = true;
            beginThrd.Start();
            Application.DoEvents();
            //-----------------------------------

            InitializeComponent();

            #region 3D_Source

            /*
            //init registry
            LotusAPI.Registry.SetApplicationName("ATMC\\KMC_S2_CHT");
            //setup logger
            LotusAPI.Logger.Add(new LogViewLogger(logView1), LogLevel.All);
            //init library
            LotusAPI.Library.Initialize();
            if (LotusAPI.Library.IsInitialized)
            {
                LotusAPI.Logger.Info("System ready!");
            }
            else
                LotusAPI.Logger.Error("Failed to initialize LotusAPI!");
            */

            //-------------------------------------------------------------
            // 2020.03.12 P4삭제
            //m_pchkUse = new CheckBox[] { chkUseP1, chkUseP2, chkUseP3}; //, chkUseP4 };
            m_pchkLive = new CheckBox[] { chkLiveP1, chkLiveP2, chkLiveP3}; //, chkLiveP4 };
            m_pchkLiveSearch = new CheckBox[] { chkLiveSearchP1, chkLiveSearchP2, chkLiveSearchP3}; //, chkLiveSearchP4 };
            m_plblStateCommRbt = new Label[] { lblStateCommRbtL, lblStateCommRbtR};
            m_plblResult = new Label[] { lblResultP1, lblResultP2, lblResultP3};//, lblResultP4 };
            m_plblX_Calib = new Label[] { lblX_CalibP1, lblX_CalibP2, lblX_CalibP3};//, lblX_CalibP4 };
            m_plblY_Calib = new Label[] { lblY_CalibP1, lblY_CalibP2, lblY_CalibP3};//, lblY_CalibP4 };
            m_plblZ_Calib = new Label[] { lblZ_CalibP1, lblZ_CalibP2, lblZ_CalibP3};//, lblZ_CalibP4 };
            m_plblX_3D = new Label[] { lblX_P1, lblX_P2, lblX_P3};//, lblX_P4 };
            m_plblY_3D = new Label[] { lblY_P1, lblY_P2, lblY_P3};//, lblY_P4 };
            m_plblZ_3D = new Label[] { lblZ_P1, lblZ_P2, lblZ_P3};//, lblZ_P4 };

            // 2011.08.15
            m_plblX_CalibSub = new Label[] { lblX_CalibSubP1, lblX_CalibSubP2, lblX_CalibSubP3};//, lblX_CalibSubP4 };
            m_plblY_CalibSub = new Label[] { lblY_CalibSubP1, lblY_CalibSubP2, lblY_CalibSubP3};//, lblY_CalibSubP4 };
            m_plblZ_CalibSub = new Label[] { lblZ_CalibSubP1, lblZ_CalibSubP2, lblZ_CalibSubP3};//, lblZ_CalibSubP4 };

            // 2020.03.12
            //m_plblX_Calcu = new Label[] { lblX_CalcuP1, lblX_CalcuP2, lblX_CalcuP3, lblX_CalcuP4 };
            //m_plblY_Calcu = new Label[] { lblY_CalcuP1, lblY_CalcuP2, lblY_CalcuP3, lblY_CalcuP4 };
            //m_plblZ_Calcu = new Label[] { lblZ_CalcuP1, lblZ_CalcuP2, lblZ_CalcuP3, lblZ_CalcuP4 };

            m_plblX_L = new Label[] { lblX_P1L, lblX_P2L, lblX_P3L};//, lblX_P4L };
            m_plblY_L = new Label[] { lblY_P1L, lblY_P2L, lblY_P3L};//, lblY_P4L };
            m_plblX_R = new Label[] { lblX_P1R, lblX_P2R, lblX_P3R};//, lblX_P4R };
            m_plblY_R = new Label[] { lblY_P1R, lblY_P2R, lblY_P3R};//, lblY_P4R };
            //-------------------------------------------------------------
            #endregion

            #region 2D_Source
            //-------------------------------------------------------------
            
            m_plblX = new Label[] { lblX_LH1_L, lblX_LH2_L, lblX_RH1_L, lblX_RH2_L,
                                    lblX_LH1_R, lblX_LH2_R, lblX_RH1_R, lblX_RH2_R};
            m_plblY = new Label[] { lblY_LH1_L, lblY_LH2_L, lblY_RH1_L, lblY_RH2_L,
                                    lblY_LH1_R, lblY_LH2_R, lblY_RH1_R, lblY_RH2_R};

            //-------------------------------------------------------------
            #endregion

            for (int i = 0; i < ASDef._MAX_LIGHT_CONTROL; i++)
            {
                m_pACommLightControl[i] = new ACommLightControl(i);
                m_pACommLightControl[i].SendToOnOff(0, false);
            }



            // 2020.03.11
            AVisionProBuild.MainFrameHandle = this.Handle;

            AVisionProBuild.Init();

            // 2020.03.11
            m_dicDisconnectedCamera.Clear();
#if _USE_BASLER_PYLON
            ABaslerPylon.Init(false);
            // 2017.01.10 by kdi
            ABaslerPylon.evtDisconnectedCamera += new ABaslerPylon.delegateDisconnectedCamera(DisconnectedCamera);
#else
            // 2020.03.11
            InitCameraInfo();

#endif

            // 2016.06.18
            // 측정 포인트별 카메라 상태 검사
            string strInvalidCamera = CheckCamera();
            if (strInvalidCamera.Length > 0)
            {
                string strError = "";
                //strError = string.Format("카메라 설정 변경이 감지되었습니다.\r\n변경 사항을 확인하시기 바랍니다.\r\n일련번호={0}", strInvalidCamera);
                //strError = string.Format("Change camera settings have been detected.\r\nPlease check your changes.\r\nSerial Number={0}", strInvalidCamera);
                strError = string.Format("{0} \r\nS/N={1}", AUtil.GetXmlLanguage("Check_the_camera_setting"), strInvalidCamera);
                AUtil.TopMostMessageBox.Show(strError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            #region 3D_Source
            //-------------------------------------------------------------
            AVisionProBuild.AddDisplay(cogDisplayP1_L, "P1_L");
            // 2011.09.29
            cogDisplayStatusBarP1_L.Display = cogDisplayP1_L;
            AVisionProBuild.AddDisplay(cogDisplayP1_R, "P1_R");
            cogDisplayStatusBarP1_R.Display = cogDisplayP1_R;
            AVisionProBuild.AddDisplay(cogDisplayP2_L, "P2_L");
            cogDisplayStatusBarP2_L.Display = cogDisplayP2_L;
            AVisionProBuild.AddDisplay(cogDisplayP2_R, "P2_R");
            cogDisplayStatusBarP2_R.Display = cogDisplayP2_R;
            AVisionProBuild.AddDisplay(cogDisplayP3_L, "P3_L");
            cogDisplayStatusBarP3_L.Display = cogDisplayP3_L;
            AVisionProBuild.AddDisplay(cogDisplayP3_R, "P3_R");
            cogDisplayStatusBarP3_R.Display = cogDisplayP3_R;
            /* 2020.03.12
            AVisionProBuild.AddDisplay(cogDisplayP4_L, "P4_L");
            cogDisplayStatusBarP4_L.Display = cogDisplayP4_L;
            AVisionProBuild.AddDisplay(cogDisplayP4_R, "P4_R");
            cogDisplayStatusBarP4_R.Display = cogDisplayP4_R;
            */

            // 2015.10.26
            /*
            m_nCalibX = 0;
	        m_nCalibY = 0;
	        m_nCalibZ = 0;
            */

            m_aCalculationLotus3D = new ACalculationLotus3D();
            m_aCalculationLotus3D.Init();

            for (int i = 0; i < ASDef._3D_POSITION_COUNT; i++)
	        {
		        m_pnR_3D[i] = -1;

                m_pstMeasure[i].pstHole = new ASDef._stXY[2];
                // 2012.02.21
                m_pstMeasure[i].pbR = new bool[2];
                m_pstMeasure[i].pstrBmpTxt = new string[2];
        	
	        }

            // 2014.10.12
            m_aIniHoleLocation = new AIniHoleLocation(cmbType.Text);
            m_aIniPartOffset = new AIniPartOffset(cmbType.Text);

            //-------------------------------------------------------------
            #endregion

            #region 2D_Source
            //-------------------------------------------------------------
            AVisionProBuild.AddDisplay(cogDisplayLH1_L, "LH1_L");
            AVisionProBuild.AddDisplay(cogDisplayLH2_L, "LH2_L");
            AVisionProBuild.AddDisplay(cogDisplayRH1_L, "RH1_L");
            AVisionProBuild.AddDisplay(cogDisplayRH2_L, "RH2_L");

            AVisionProBuild.AddDisplay(cogDisplayLH1_R, "LH1_R");
            AVisionProBuild.AddDisplay(cogDisplayLH2_R, "LH2_R");
            AVisionProBuild.AddDisplay(cogDisplayRH1_R, "RH1_R");
            AVisionProBuild.AddDisplay(cogDisplayRH2_R, "RH2_R");
            //-------------------------------------------------------------
            #endregion

            // 2014.10.04
            LoadIni();

            // 2015.07.17
            AVisionProBuild.m_bAuto = false;

            m_AThrdPlc = new AThrdClientSocketPlcSiemens(0, this.Handle);
            m_AThrdPlc.Init();

            m_pAThrdRbt = new AThrdUdpServerSocketRbtHHI[ASDef._MAX_ROBOT];
            for (int i = 0; i < ASDef._MAX_ROBOT; i++)
            {
                m_pAThrdRbt[i] = new AThrdUdpServerSocketRbtHHI(i, this.Handle);
                m_pAThrdRbt[i].Init();

                SetRbtShift(i, 0, 0, 0, 0, 0);
                SetRbtShift(i, 1, 0, 0, 0, 0);
                SetRbtShift(i, 2, 0, 0, 0, 0);
            }

            AVisionProBuild.WriteLogFile("Program Start");

            // 2014.10.04
            RunReset(true);

            // 2015.03.01
            DisplayStatusBar();
            // 2016.06.15
            DisplayStatusBar_TopWindow();

            //-----------------------------------
            //             Splash
            this.Show();
            beginThrd.Abort();
            frmSplash.CloseSplashScreen();

            AUtil.TopWindow(this.Handle, this.DefaultMargin.Left + 1, this.DefaultMargin.Top + 1);
            //-----------------------------------
        }
        // 2014.10.04  
        // cognex디지탈 카메라 종료시 R6025 runtime error 발생 해결 방안
        // FrmMain.Designer.cs에 있는 Dispose는 삭제해야 함
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            CogFrameGrabbers frameGrabbers = new CogFrameGrabbers();
            foreach (ICogFrameGrabber fg in frameGrabbers)
                fg.Disconnect(false);

            base.Dispose(disposing);
        }

#region Tool Event
        private void FrmMain_Load(object sender, EventArgs e)
        {
            try
            {
                if (AVisionProBuild.GetTypeCount() > 0)
                {
                    cmbType.SelectedIndex = AVisionProBuild.GetTypeCount() - 1;
                    Application.DoEvents();
                    cmbType.SelectedIndex = 0;
                }
            }
            catch { }

            SetAutoMan(true);
            tmrFileDel.Enabled = true;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // 2014.10.25
                m_bClosing = true;

                string strText, strCaption;
                strText = AUtil.GetXmlLanguage("Program_Exit");
                strCaption = AUtil.GetXmlLanguage("Exit");
                if (MessageBox.Show(strText, strCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    m_AThrdPlc.Stop();
                    
                    for (int i=0; i < ASDef._MAX_ROBOT; i++)
                    {
                        m_pAThrdRbt[i].Stop();
                    }
                    

                    // 2016.06.20
#if _USE_BASLER_PYLON
                    ABaslerPylon.Close();
#endif

                    // 2015.04.16
                    AVisionProBuild.WriteLogFile("Program Close");
                    AVisionProBuild.Close();

                    // 2015.04.08
                    Application.ExitThread();
                }
                else
                {
                    // 2014.10.25
                    m_bClosing = false;

                    e.Cancel = true;
                }
            }
            catch { Application.ExitThread(); }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_IsInitializing = true;

            #region 3D_Source
            //-------------------------------------------------------------
            /*
            AIniUse aIniUse;
            aIniUse = new AIniUse(cmbType.SelectedIndex, 0);
            // 2020.03.12 4->ASDef._3D_POSITION_COUNT
            for (int i = 0; i < ASDef._3D_POSITION_COUNT; i++)
            {
                aIniUse.Set(cmbType.SelectedIndex, i);
                aIniUse.Read();
                m_pchkUse[i].Checked = aIniUse.m_bUse;
            }
            */

            // 2014.10.12
            m_aIniHoleLocation.Set(cmbType.Text);

            m_aIniHoleLocation.Read();

            // 2014.10.12
            m_aIniPartOffset.Set(cmbType.Text);
            
            m_aIniPartOffset.Read();
            //-------------------------------------------------------------
            #endregion

            m_IsInitializing = false;

            // 2014.10.04
            lblType.Text = cmbType.Text;
        }

        /* 2020.03.12
        private void cmbCase_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCaseImg.ImageIndex = cmbCase.SelectedIndex + 1;

            AUtil.WritePrivateProfileString("Case", "선택", cmbCase.Text, ASDef._INI_FILE);
        }
        */

        #region 3D_Source
        //-------------------------------------------------------------
        // 2014.11.12
        private void lblTitlePX_DragDrop(object sender, DragEventArgs e)
        {
            // 2020.03.11
            if (AVisionProBuild.Auto)
                return;

            string strImagePath = AUtil.ADragDrop.DoDragDrop(sender, e);

            if (strImagePath.Length > 0)
            {
                if (!Directory.Exists(strImagePath))
                    return;

                // 2014.11.18
                ICogImage cogImage = null;
                string[] pstrFName = AVisionProBuild.LoadDir(strImagePath, ref cogImage).Split('\\');
                LoadImage3D(pstrFName);
                RunRevisions3D();
            }
        }

        // 2014.11.12
        private void lblTitlePX_DragOver(object sender, DragEventArgs e)
        {
            AUtil.ADragDrop.DoDragOver(sender, e);
        }
        //-------------------------------------------------------------
        #endregion

        #region 2D_Source
        //-------------------------------------------------------------
        private void lblTitleLH1_L_DragDrop(object sender, DragEventArgs e)
        {
            if (AVisionProBuild.Auto)
                return;

            string strImagePath = AUtil.ADragDrop.DoDragDrop(sender, e);

            if (strImagePath.Length > 0)
            {
                if (!Directory.Exists(strImagePath))
                    return;

                ICogImage cogImage = null;
                string[] pstrFName = AVisionProBuild.LoadDir(strImagePath, ref cogImage).Split('\\');
                LoadImage(pstrFName, 0 + ASDef._3D_POINT_COUNT);

                RunRevision(0 + ASDef._3D_POINT_COUNT);
            }
        }
        private void lblTitleLH2_L_DragDrop(object sender, DragEventArgs e)
        {
            if (AVisionProBuild.Auto)
                return;

            string strImagePath = AUtil.ADragDrop.DoDragDrop(sender, e);

            if (strImagePath.Length > 0)
            {
                if (!Directory.Exists(strImagePath))
                    return;

                ICogImage cogImage = null;
                string[] pstrFName = AVisionProBuild.LoadDir(strImagePath, ref cogImage).Split('\\');
                LoadImage(pstrFName, 1 + ASDef._3D_POINT_COUNT);

                RunRevision(1 + ASDef._3D_POINT_COUNT);
            }
        }
        private void lblTitleRH1_L_DragDrop(object sender, DragEventArgs e)
        {
            if (AVisionProBuild.Auto)
                return;

            string strImagePath = AUtil.ADragDrop.DoDragDrop(sender, e);

            if (strImagePath.Length > 0)
            {
                if (!Directory.Exists(strImagePath))
                    return;

                ICogImage cogImage = null;
                string[] pstrFName = AVisionProBuild.LoadDir(strImagePath, ref cogImage).Split('\\');
                LoadImage(pstrFName, 2 + ASDef._3D_POINT_COUNT);

                RunRevision(2 + ASDef._3D_POINT_COUNT);
            }
        }
        private void lblTitleRH2_L_DragDrop(object sender, DragEventArgs e)
        {
            if (AVisionProBuild.Auto)
                return;

            string strImagePath = AUtil.ADragDrop.DoDragDrop(sender, e);

            if (strImagePath.Length > 0)
            {
                if (!Directory.Exists(strImagePath))
                    return;

                ICogImage cogImage = null;
                string[] pstrFName = AVisionProBuild.LoadDir(strImagePath, ref cogImage).Split('\\');
                LoadImage(pstrFName, 3 + ASDef._3D_POINT_COUNT);

                RunRevision(3 + ASDef._3D_POINT_COUNT);
            }
        }

        private void lblTitleLH1_R_DragDrop(object sender, DragEventArgs e)
        {
            if (AVisionProBuild.Auto)
                return;

            string strImagePath = AUtil.ADragDrop.DoDragDrop(sender, e);

            if (strImagePath.Length > 0)
            {
                if (!Directory.Exists(strImagePath))
                    return;

                ICogImage cogImage = null;
                string[] pstrFName = AVisionProBuild.LoadDir(strImagePath, ref cogImage).Split('\\');
                LoadImage(pstrFName, 4 + ASDef._3D_POINT_COUNT);

                RunRevision(4 + ASDef._3D_POINT_COUNT);
            }
        }
        private void lblTitleLH2_R_DragDrop(object sender, DragEventArgs e)
        {
            if (AVisionProBuild.Auto)
                return;

            string strImagePath = AUtil.ADragDrop.DoDragDrop(sender, e);

            if (strImagePath.Length > 0)
            {
                if (!Directory.Exists(strImagePath))
                    return;

                ICogImage cogImage = null;
                string[] pstrFName = AVisionProBuild.LoadDir(strImagePath, ref cogImage).Split('\\');
                LoadImage(pstrFName, 5 + ASDef._3D_POINT_COUNT);

                RunRevision(5 + ASDef._3D_POINT_COUNT);
            }
        }
        private void lblTitleRH1_R_DragDrop(object sender, DragEventArgs e)
        {
            if (AVisionProBuild.Auto)
                return;

            string strImagePath = AUtil.ADragDrop.DoDragDrop(sender, e);

            if (strImagePath.Length > 0)
            {
                if (!Directory.Exists(strImagePath))
                    return;

                ICogImage cogImage = null;
                string[] pstrFName = AVisionProBuild.LoadDir(strImagePath, ref cogImage).Split('\\');
                LoadImage(pstrFName, 6 + ASDef._3D_POINT_COUNT);

                RunRevision(6 + ASDef._3D_POINT_COUNT);
            }
        }
        private void lblTitleRH2_R_DragDrop(object sender, DragEventArgs e)
        {
            if (AVisionProBuild.Auto)
                return;

            string strImagePath = AUtil.ADragDrop.DoDragDrop(sender, e);

            if (strImagePath.Length > 0)
            {
                if (!Directory.Exists(strImagePath))
                    return;

                ICogImage cogImage = null;
                string[] pstrFName = AVisionProBuild.LoadDir(strImagePath, ref cogImage).Split('\\');
                LoadImage(pstrFName, 7 + ASDef._3D_POINT_COUNT);

                RunRevision(7 + ASDef._3D_POINT_COUNT);
            }
        }
        private void lblTitle_DragOver(object sender, DragEventArgs e)
        {
            AUtil.ADragDrop.DoDragOver(sender, e);
        }
        //-------------------------------------------------------------
        #endregion

#endregion

#region Tool Click
        private void btnAuto_Click(object sender, EventArgs e)
        {
            SetAutoMan(!AVisionProBuild.Auto);
        }
        
        private void btnLimitSet_Click(object sender, EventArgs e)
        {
            int nType = cmbType.SelectedIndex;

            // 2014.10.04
            if (Application.OpenForms["AFrmLimit"] == null)
            {
                AFrmLimit frmLimit = new AFrmLimit(this.Handle, nType, 0, "");
                // 2014.10.04
                frmLimit.Show(this);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {

                Close();
            }
            catch
            {
                Application.ExitThread();
            }
        }

        private void btnTypeSet_Click(object sender, EventArgs e)
        {
            AFrmPW dlgPW = new AFrmPW(this.Handle);
            dlgPW.ShowDialog(this);

            if (dlgPW.m_bPW)
            {
                AFrmTypeSet dlg = new AFrmTypeSet(this.Handle);
                dlg.ShowDialog(this);

                LoadType();
            }
        }

        private void btnFileDel_Click(object sender, EventArgs e)
        {
            // 2015.04.15
            if (Application.OpenForms["AFrmFileDel"] == null)
            {
                AFrmFileDel Dlg = new AFrmFileDel(this.Handle);
                // 2015.03.20
                Dlg.Show(this);
            }
        }

        // 2013.08.10
        private void btnExposure_Click(object sender, EventArgs e)
        {
            // 2016.11.09
            /*
            // 2014.10.04
            if (Application.OpenForms["AFrmExposure"] == null)
            {
                AFrmExposure dlg = new AFrmExposure(this.Handle, cmbType.SelectedIndex);
                // 2014.10.04
                dlg.Show(this);
            }
            */
            if (Application.OpenForms["AFrmLight"] == null)
            {
                AFrmLight dlg = new AFrmLight(this.Handle, cmbType.SelectedIndex);
                dlg.Show(this);
            }
        }

        private void lblStateCommPLC_R_DoubleClick(object sender, EventArgs e)
        {
            // 2014.10.04
            if (Application.OpenForms["AFrmPlcMap"] == null)
            {
                /*
            IntPtr hWnd = AUtil.FindWindow(null, "PLC MAP List");

            if (hWnd.ToInt32() == 0)
            {
                string[] pstrAddress = new string[2];
                pstrAddress[0] = "";
                pstrAddress[1] = "";
                */

                AFrmPlcMap dlg = new AFrmPlcMap(this.Handle);
                // 2014.10.04
                dlg.Show(this);
            }
        }

        private void aioMapIN_evtItemDblClick(object sender, int nIndex)
        {
            RunDI(nIndex, false);
        }
        private void aioMapIN_evtTitleDblClick(object sender)
        {
            int nType = cmbType.SelectedIndex;
            AType aType = AVisionProBuild.GetType(nType);
            AFrmCogToolGroup frm = new AFrmCogToolGroup(aType.m_cogtgType);
            frm.Show(this);
        }
        private void aioMapOUT_evtItemDblClick(object sender, int nIndex)
        {
            XorBitDO(Convert.ToInt32(ASDef._DO_SIGNAL), nIndex);
        }
        private void aioMapOUT_evtTitleDblClick(object sender)
        {
            if (Application.OpenForms["AFrmTypeReload"] == null)
            {
                AFrmTypeReload frm = new AFrmTypeReload(cmbType.SelectedIndex);
                frm.SetParentCenter(this.Left, this.Right, this.Top, this.Bottom);
                frm.Show(this);
            }
            else
            {
                Application.OpenForms["AFrmTypeReload"].Focus();
            }
        }

        private void chkTopWindow_Clicked(object sender, EventArgs e)
        {
            // 2016.02.12 2->statusStrip.Items.Count-1
            ToolStripControlHost host = statusStrip.Items[statusStrip.Items.Count - 1] as ToolStripControlHost;
            CheckBox chkTopWindow = host.Control as CheckBox;

            m_bTopWindow = chkTopWindow.Checked;

            if (chkTopWindow.Checked == true)
                AUtil.WritePrivateProfileString("Select", "TopWindow", "1", ASDef._INI_FILE);
            else
                AUtil.WritePrivateProfileString("Select", "TopWindow", "0", ASDef._INI_FILE);
        }

        #region 3D_Source
        //-------------------------------------------------------------
        /*
        private void chkUseP1_Click(object sender, EventArgs e)
        {
            CheckUse(0);
        }

        private void chkUseP2_Click(object sender, EventArgs e)
        {
            CheckUse(1);
        }

        private void chkUseP3_Click(object sender, EventArgs e)
        {
            CheckUse(2);
        }
        */

        /* 2020.03.12
        private void chkUseP4_Click(object sender, EventArgs e)
        {
            CheckUse(3);
        }
        */

        private void lblTitleP1_DoubleClick(object sender, EventArgs e)
        {
            ShowStereoSet(0);
        }

        private void lblTitleP2_DoubleClick(object sender, EventArgs e)
        {
            ShowStereoSet(1);            
        }

        private void lblTitleP3_DoubleClick(object sender, EventArgs e)
        {
            ShowStereoSet(2);
        }

        /* 2020.03.12
        private void lblTitleP4_DoubleClick(object sender, EventArgs e)
        {
            ShowStereoSet(3);
        }
        */

        private void lblCalibP1_DoubleClick(object sender, EventArgs e)
        {
            ShowFrameSet(0);
        }

        private void lblCalibP2_DoubleClick(object sender, EventArgs e)
        {
            ShowFrameSet(1);
        }

        private void lblCalibP3_DoubleClick(object sender, EventArgs e)
        {
            ShowFrameSet(2);
        }

        /* 2020.03.12
        private void lblCalibP4_DoubleClick(object sender, EventArgs e)
        {
            ShowFrameSet(3);
        }
        */

        private void btnPartOffsetSet_Click(object sender, EventArgs e)
        {
            int nType = cmbType.SelectedIndex;

            // 2014.10.04
            if (Application.OpenForms["FrmPartOffset"] == null)
            {
                FrmPartOffset frmPartOffset = new FrmPartOffset(this, nType);
                // 2014.10.04
                frmPartOffset.Show(this);
            }
        }

        private void btnLengthSet_Click(object sender, EventArgs e)
        {
            int nType = cmbType.SelectedIndex;

            FrmHoleLocationSet frmHoleLocationSet = new FrmHoleLocationSet(this.Handle, nType);
            // 2015.03.20
            frmHoleLocationSet.ShowDialog(this);

            m_aIniHoleLocation.Set(cmbType.Text);
            m_aIniHoleLocation.Read();
        }

        // 2016.06.18
        private void btnLengthLoad_Click(object sender, EventArgs e)
        {
            AFrmPW dlgPW = new AFrmPW(this.Handle);
            dlgPW.ShowDialog(this);

            if (dlgPW.m_bPW)
            {
                AIniHoleLocation aIniHoleLocation = new AIniHoleLocation(cmbType.Text);
                aIniHoleLocation.Read();

                for (int i = 0; i < ASDef._3D_POSITION_COUNT; i++)
                {
                    aIniHoleLocation.m_pstXYZ[i].dX = Convert.ToDouble(m_plblX_3D[i].Text);
                    aIniHoleLocation.m_pstXYZ[i].dY = Convert.ToDouble(m_plblY_3D[i].Text);
                    aIniHoleLocation.m_pstXYZ[i].dZ = Convert.ToDouble(m_plblZ_3D[i].Text);
                }

                aIniHoleLocation.Write();
            }
        }

        private void btnManualP1_Click(object sender, EventArgs e)
        {
            RunRevision3D(0, true);
        }

        private void btnManualP2_Click(object sender, EventArgs e)
        {
            RunRevision3D(1, true);
        }

        private void btnManualP3_Click(object sender, EventArgs e)
        {
            RunRevision3D(2, true);
        }

        private void btnManual3D_Click(object sender, EventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                // 2014.11.18
                ICogImage cogImage = null;
                string[] pstrFName = AVisionProBuild.BeforeImg(ref cogImage).Split('\\');
                LoadImage3D(pstrFName);

                RunRevisions3D();
            }
            else if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                // 2014.11.18
                ICogImage cogImage = null;
                string[] pstrFName = AVisionProBuild.NextImg(ref cogImage).Split('\\');
                LoadImage3D(pstrFName);

                RunRevisions3D();
            }
            else
            {
                CheckCalcu();
            }

        }

        private void chkLiveP1_CheckedChanged(object sender, EventArgs e)
        {
            // 2012.02.29
            if (chkLiveP1.Checked)
            {
                m_bLive = true;
                tmrLive.Enabled = true;
            }
            else
            {
                if (chkLiveP1.Checked == false &&
                    chkLiveP2.Checked == false &&
                    chkLiveP3.Checked == false)
                    // 2020.03.12
                    //&& chkLiveP4.Checked == false)

                    m_bLive = false;
            }
        }

        private void chkLiveP2_CheckedChanged(object sender, EventArgs e)
        {
            // 2012.02.29
            if (chkLiveP2.Checked)
            {
                m_bLive = true;
                tmrLive.Enabled = true;
            }
            else
            {
                if (chkLiveP1.Checked == false &&
                    chkLiveP2.Checked == false &&
                    chkLiveP3.Checked == false)
                    // 2020.03.12
                    //&& chkLiveP4.Checked == false)

                    m_bLive = false;
            }
        }

        private void chkLiveP3_CheckedChanged(object sender, EventArgs e)
        {
            // 2012.02.29
            if (chkLiveP3.Checked)
            {
                m_bLive = true;
                tmrLive.Enabled = true;
            }
            else
            {
                if (chkLiveP1.Checked == false &&
                    chkLiveP2.Checked == false &&
                    chkLiveP3.Checked == false)
                    // 2020.03.12
                    //&& chkLiveP4.Checked == false)

                    m_bLive = false;
            }
        }

        /* 2020.03.12
        private void chkLiveP4_CheckedChanged(object sender, EventArgs e)
        {
            // 2012.02.29
            if (chkLiveP4.Checked)
            {
                m_bLive = true;
                tmrLive.Enabled = true;
            }
            else
            {
                if (chkLiveP1.Checked == false &&
                    chkLiveP2.Checked == false &&
                    chkLiveP3.Checked == false &&
                    chkLiveP4.Checked == false)
                    m_bLive = false;
            }
        }
        */

        private void lblResult_DoubleClick(object sender, EventArgs e)
        {
            RunRevisions3D();
        }

        // 2011.09.29
        private void cogDisplayP1_L_DoubleClick(object sender, EventArgs e)
        {
            if (cogDisplayStatusBarP1_L.Visible)
                cogDisplayStatusBarP1_L.Visible = false;
            else
                cogDisplayStatusBarP1_L.Visible = true;
        }

        private void cogDisplayP1_R_DoubleClick(object sender, EventArgs e)
        {
            if (cogDisplayStatusBarP1_R.Visible)
                cogDisplayStatusBarP1_R.Visible = false;
            else
                cogDisplayStatusBarP1_R.Visible = true;
        }

        private void cogDisplayP2_L_DoubleClick(object sender, EventArgs e)
        {
            if (cogDisplayStatusBarP2_L.Visible)
                cogDisplayStatusBarP2_L.Visible = false;
            else
                cogDisplayStatusBarP2_L.Visible = true;
        }

        private void cogDisplayP2_R_DoubleClick(object sender, EventArgs e)
        {
            if (cogDisplayStatusBarP2_R.Visible)
                cogDisplayStatusBarP2_R.Visible = false;
            else
                cogDisplayStatusBarP2_R.Visible = true;
        }

        private void cogDisplayP3_L_DoubleClick(object sender, EventArgs e)
        {
            if (cogDisplayStatusBarP3_L.Visible)
                cogDisplayStatusBarP3_L.Visible = false;
            else
                cogDisplayStatusBarP3_L.Visible = true;
        }

        private void cogDisplayP3_R_DoubleClick(object sender, EventArgs e)
        {
            if (cogDisplayStatusBarP3_R.Visible)
                cogDisplayStatusBarP3_R.Visible = false;
            else
                cogDisplayStatusBarP3_R.Visible = true;
        }

        /* 2020.03.12
        private void cogDisplayP4_L_DoubleClick(object sender, EventArgs e)
        {
            if (cogDisplayStatusBarP4_L.Visible)
                cogDisplayStatusBarP4_L.Visible = false;
            else
                cogDisplayStatusBarP4_L.Visible = true;
        }

        private void cogDisplayP4_R_DoubleClick(object sender, EventArgs e)
        {
            if (cogDisplayStatusBarP4_R.Visible)
                cogDisplayStatusBarP4_R.Visible = false;
            else
                cogDisplayStatusBarP4_R.Visible = true;
        }
        */
        //-------------------------------------------------------------
        #endregion


        #region 2D_Source
        //-------------------------------------------------------------
        private void lblTitleLH1_L_DoubleClick(object sender, EventArgs e)
        {
            ShowPMAlign(0 + ASDef._3D_POINT_COUNT, 0);
        }
        private void lblTitleLH2_L_DoubleClick(object sender, EventArgs e)
        {
            ShowPMAlign(1 + ASDef._3D_POINT_COUNT, 0);
        }
        private void lblTitleRH1_L_DoubleClick(object sender, EventArgs e)
        {
            ShowPMAlign(2 + ASDef._3D_POINT_COUNT, 0);
        }
        private void lblTitleRH2_L_DoubleClick(object sender, EventArgs e)
        {
            ShowPMAlign(3 + ASDef._3D_POINT_COUNT, 0);
        }

        private void lblTitleLH1_R_DoubleClick(object sender, EventArgs e)
        {
            ShowPMAlign(4 + ASDef._3D_POINT_COUNT, 0);
        }
        private void lblTitleLH2_R_DoubleClick(object sender, EventArgs e)
        {
            ShowPMAlign(5 + ASDef._3D_POINT_COUNT, 0);
        }
        private void lblTitleRH1_R_DoubleClick(object sender, EventArgs e)
        {
            ShowPMAlign(6 + ASDef._3D_POINT_COUNT, 0);
        }
        private void lblTitleRH2_R_DoubleClick(object sender, EventArgs e)
        {
            ShowPMAlign(7 + ASDef._3D_POINT_COUNT, 0);
        }

        private void btnOffsetSetLH1_L_Click(object sender, EventArgs e)
        {
            ShowOffset(0, "LH1 (LH Robot)");
        }
        private void btnOffsetSetLH2_L_Click(object sender, EventArgs e)
        {
            ShowOffset(1, "LH2 (LH Robot)");
        }
        private void btnOffsetSetRH1_L_Click(object sender, EventArgs e)
        {
            ShowOffset(2, "RH1 (LH Robot)");
        }
        private void btnOffsetSetRH2_L_Click(object sender, EventArgs e)
        {
            ShowOffset(3, "RH2 (LH Robot)");
        }

        private void btnOffsetSetLH1_R_Click(object sender, EventArgs e)
        {
            ShowOffset(4, "LH1 (RH Robot)");
        }
        private void btnOffsetSetLH2_R_Click(object sender, EventArgs e)
        {
            ShowOffset(5, "LH2 (RH Robot)");
        }
        private void btnOffsetSetRH1_R_Click(object sender, EventArgs e)
        {
            ShowOffset(6, "RH1 (RH Robot)");
        }
        private void btnOffsetSetRH2_R_Click(object sender, EventArgs e)
        {
            ShowOffset(7, "RH2 (RH Robot)");
        }

        private void btnManualLH1_L_Click(object sender, EventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                ICogImage cogImage = null;

                string[] pstrFName = AVisionProBuild.BeforeImg(ref cogImage).Split('\\');

                LoadImage(pstrFName, 0 + ASDef._3D_POINT_COUNT);
            }
            else if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                ICogImage cogImage = null;

                string[] pstrFName = AVisionProBuild.NextImg(ref cogImage).Split('\\');

                LoadImage(pstrFName, 0 + ASDef._3D_POINT_COUNT);
            }
            RunRevision(0 + ASDef._3D_POINT_COUNT);
        }
        private void btnManualLH2_L_Click(object sender, EventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                ICogImage cogImage = null;

                string[] pstrFName = AVisionProBuild.BeforeImg(ref cogImage).Split('\\');

                LoadImage(pstrFName, 1 + ASDef._3D_POINT_COUNT);
            }
            else if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                ICogImage cogImage = null;

                string[] pstrFName = AVisionProBuild.NextImg(ref cogImage).Split('\\');

                LoadImage(pstrFName, 1 + ASDef._3D_POINT_COUNT);
            }
            RunRevision(1 + ASDef._3D_POINT_COUNT);
        }
        private void btnManualRH1_L_Click(object sender, EventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                ICogImage cogImage = null;

                string[] pstrFName = AVisionProBuild.BeforeImg(ref cogImage).Split('\\');

                LoadImage(pstrFName, 2 + ASDef._3D_POINT_COUNT);
            }
            else if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                ICogImage cogImage = null;

                string[] pstrFName = AVisionProBuild.NextImg(ref cogImage).Split('\\');

                LoadImage(pstrFName, 2 + ASDef._3D_POINT_COUNT);
            }
            RunRevision(2 + ASDef._3D_POINT_COUNT);
        }
        private void btnManualRH2_L_Click(object sender, EventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                ICogImage cogImage = null;

                string[] pstrFName = AVisionProBuild.BeforeImg(ref cogImage).Split('\\');

                LoadImage(pstrFName, 3 + ASDef._3D_POINT_COUNT);
            }
            else if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                ICogImage cogImage = null;

                string[] pstrFName = AVisionProBuild.NextImg(ref cogImage).Split('\\');

                LoadImage(pstrFName, 3 + ASDef._3D_POINT_COUNT);
            }
            RunRevision(3 + ASDef._3D_POINT_COUNT);
        }

        private void btnManualLH1_R_Click(object sender, EventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                ICogImage cogImage = null;

                string[] pstrFName = AVisionProBuild.BeforeImg(ref cogImage).Split('\\');

                LoadImage(pstrFName, 4 + ASDef._3D_POINT_COUNT);
            }
            else if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                ICogImage cogImage = null;

                string[] pstrFName = AVisionProBuild.NextImg(ref cogImage).Split('\\');

                LoadImage(pstrFName, 4 + ASDef._3D_POINT_COUNT);
            }
            RunRevision(4 + ASDef._3D_POINT_COUNT);
        }
        private void btnManualLH2_R_Click(object sender, EventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                ICogImage cogImage = null;

                string[] pstrFName = AVisionProBuild.BeforeImg(ref cogImage).Split('\\');

                LoadImage(pstrFName, 5 + ASDef._3D_POINT_COUNT);
            }
            else if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                ICogImage cogImage = null;

                string[] pstrFName = AVisionProBuild.NextImg(ref cogImage).Split('\\');

                LoadImage(pstrFName, 5 + ASDef._3D_POINT_COUNT);
            }
            RunRevision(5 + ASDef._3D_POINT_COUNT);
        }
        private void btnManualRH1_R_Click(object sender, EventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                ICogImage cogImage = null;

                string[] pstrFName = AVisionProBuild.BeforeImg(ref cogImage).Split('\\');

                LoadImage(pstrFName, 6 + ASDef._3D_POINT_COUNT);
            }
            else if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                ICogImage cogImage = null;

                string[] pstrFName = AVisionProBuild.NextImg(ref cogImage).Split('\\');

                LoadImage(pstrFName, 6 + ASDef._3D_POINT_COUNT);
            }
            RunRevision(6 + ASDef._3D_POINT_COUNT);
        }
        private void btnManualRH2_R_Click(object sender, EventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Alt) == Keys.Alt)
            {
                ICogImage cogImage = null;

                string[] pstrFName = AVisionProBuild.BeforeImg(ref cogImage).Split('\\');

                LoadImage(pstrFName, 7 + ASDef._3D_POINT_COUNT);
            }
            else if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                ICogImage cogImage = null;

                string[] pstrFName = AVisionProBuild.NextImg(ref cogImage).Split('\\');

                LoadImage(pstrFName, 7 + ASDef._3D_POINT_COUNT);
            }
            RunRevision(7 + ASDef._3D_POINT_COUNT);
        }
        //-------------------------------------------------------------
        #endregion

        

#endregion
#region Timer

        #region 3D_Source
        //-------------------------------------------------------------
        private void tmrLive_Tick(object sender, EventArgs e)
        {
            // 2012.02.29
            tmrLive.Enabled = false;

            if (chkLiveSearchP1.Checked)
            {
                RunRevision3D((int)ACalculationLotus3D._emPosition.P1, true);
            }
            else if (chkLiveP1.Checked)
            {
                int nType = cmbType.SelectedIndex;
                ADisplay aDisplayL = AVisionProBuild.GetDisplay(0);
                ADisplay aDisplayR = AVisionProBuild.GetDisplay(1);
                aDisplayL.ClearExcludeImage();
                aDisplayR.ClearExcludeImage();

                ICogImage cogImage = null;
                AVisionProBuild.Acq(nType, 0, ref cogImage);
                aDisplayL.Image = cogImage;
                AVisionProBuild.Acq(nType, 1, ref cogImage);
                aDisplayR.Image = cogImage;

                aDisplayL.AddCross();
                aDisplayR.AddCross();
            }

            if (chkLiveSearchP2.Checked)
            {
                RunRevision3D((int)ACalculationLotus3D._emPosition.P2, true);
            }
            else if (chkLiveP2.Checked)
            {
                int nType = cmbType.SelectedIndex;
                ADisplay aDisplayL = AVisionProBuild.GetDisplay(2);
                ADisplay aDisplayR = AVisionProBuild.GetDisplay(3);
                aDisplayL.ClearExcludeImage();
                aDisplayR.ClearExcludeImage();

                ICogImage cogImage = null;
                AVisionProBuild.Acq(nType, 2, ref cogImage);
                aDisplayL.Image = cogImage;
                AVisionProBuild.Acq(nType, 3, ref cogImage);
                aDisplayR.Image = cogImage;

                aDisplayL.AddCross();
                aDisplayR.AddCross();
            }

            if (chkLiveSearchP3.Checked)
            {
                RunRevision3D((int)ACalculationLotus3D._emPosition.P3, true);
            }
            else if (chkLiveP3.Checked)
            {
                int nType = cmbType.SelectedIndex;
                ADisplay aDisplayL = AVisionProBuild.GetDisplay(4);
                ADisplay aDisplayR = AVisionProBuild.GetDisplay(5);
                aDisplayL.ClearExcludeImage();
                aDisplayR.ClearExcludeImage();

                ICogImage cogImage = null;
                AVisionProBuild.Acq(nType, 4, ref cogImage);
                aDisplayL.Image = cogImage;
                AVisionProBuild.Acq(nType, 5, ref cogImage);
                aDisplayR.Image = cogImage;

                aDisplayL.AddCross();
                aDisplayR.AddCross();
            }

            /* 2020.03.12
            if (chkLiveSearchP4.Checked)
            {
                RunRevision3D((int)ACalculationLotus3D._emPosition.P4, true);
            }
            else if (chkLiveP4.Checked)
            {
                int nType = cmbType.SelectedIndex;
                ADisplay aDisplayL = AVisionProBuild.GetDisplay(6);
                ADisplay aDisplayR = AVisionProBuild.GetDisplay(7);
                aDisplayL.ClearExcludeImage();
                aDisplayR.ClearExcludeImage();
                
                ICogImage cogImage = null;
                AVisionProBuild.Acq(nType, 6, ref cogImage);
                aDisplayL.Image = cogImage;
                AVisionProBuild.Acq(nType, 7, ref cogImage);
                aDisplayR.Image = cogImage;

                aDisplayL.AddCross();
                aDisplayR.AddCross();
            }
            */

            if (m_bLive == true)
                tmrLive.Enabled = true;
        }
        //-------------------------------------------------------------
        #endregion

        private void tmrFileDel_Tick(object sender, EventArgs e)
        {
            // 2015.03.01
            DisplayStatusBar();

            //파일 삭제 타이머
            // 2015.03.01
            AFile aFile = new AFile(m_fFreeHDD_Percent);
            // 2015.04.10
            //aFile.Start();
        }

        private void tmrSaveJpeg_Tick(object sender, EventArgs e)
        {
            tmrSaveJpeg.Enabled = false;
            SaveJpg();

        }

        private void tmrReconnect_Tick(object sender, EventArgs e)
        {
            tmrReconnect.Enabled = false;
            // 2014.10.25
            /*
            if (!m_AThrdPlc.Reconnect() == false)
            {
                tmrReconnect.Enabled = true;
            }
            AddLstBxMessage(" Plc Reconnect");
            */
            if (m_bClosing == false)
            {
                // 2015.04.10
                //(new Thread(new ThreadStart(ReconnectToPLCProc))).Start();
                BackgroundWorker backWorker = new BackgroundWorker();
                backWorker.DoWork += ReconnectToPLCProc;
                backWorker.RunWorkerAsync();
            }
        }

        // 2015.07.17 ------------------------
        public delegate void dgReconnectToPLC(int nResult);

        public void ReconnectToPLC(int nResult)   //     ==> 쓰레드 내부 함수에서 Invoke를 사용하여 호출되는 함수
        {
            if (nResult == 0) // need to re_connect
                tmrReconnect.Enabled = true;

            AddLstBxMessage("PLC Reconnect");
        }

        //public void ReconnectToPLCProc()
        public void ReconnectToPLCProc(object sender, DoWorkEventArgs e)
        {            
            if (this.m_bClosing == false)
            {
                // 2020.03.11
                bool bRet = false;
                bRet = m_AThrdPlc.Reconnect();

                // 2017.01.17
                //if (this.InvokeRequired)
                    this.Invoke(new dgReconnectToPLC(ReconnectToPLC), new object[] { bRet == true ? 1 : 0 });
                /*
                else
                    ReconnectToPLC(bRet == true ? 1 : 0);
                */
            }
        }
        //------------------------------------------
                

#if _USE_BASLER_PYLON
        // 2017.01.10 by kdi
        private void tmrGigEReconnect_Tick(object sender, EventArgs e)
        {
            tmrGigEReconnect.Enabled = false;

            lock (m_dicDisconnectedCamera)
            {
                if (m_dicDisconnectedCamera.Count <= 0)
                    return;

                List<string> lstConnectedCamera = new List<string>();

                foreach (KeyValuePair<string, string> stDevice in m_dicDisconnectedCamera)
                {
                    if (stDevice.Key != null && stDevice.Key.Length != 0 &&
                        stDevice.Value != null && stDevice.Value.Length != 0)
                    {
                        Ping ping = new Ping();
                        PingReply pr = null;
                        try
                        {
                            pr = ping.Send(stDevice.Value, 100);
                            if (pr != null && pr.Status == IPStatus.Success)
                            {
                                if (ABaslerPylon.GetDevHandle(stDevice.Key) == null)
                                {
                                    if (ABaslerPylon.Init(stDevice.Key, false) == 0)
                                    {
                                        lstConnectedCamera.Add(stDevice.Key);

                                        AddLstBxMessage("카메라 재접속. S/N=" + stDevice.Key);
                                        AVisionProBuild.WriteLogFile("카메라 재접속. S/N=" + stDevice.Key, ".Err.txt");
                                    }
                                }
                                else
                                {
                                    lstConnectedCamera.Add(stDevice.Key);

                                    AddLstBxMessage("카메라 재접속. S/N=" + stDevice.Key);
                                    AVisionProBuild.WriteLogFile("카메라 재접속. S/N=" + stDevice.Key, ".Err.txt");
                                }
                            }
                        }
                        catch
                        {
                            //
                        }
                    }
                }

                foreach (string strSerialNumber in lstConnectedCamera)
                {
                    m_dicDisconnectedCamera.Remove(strSerialNumber);
                }
                lstConnectedCamera.Clear();

                if (m_dicDisconnectedCamera.Count != 0)
                    tmrGigEReconnect.Enabled = true;
            }
        }
#else
        // 2020.03.11
        private void tmrGigEReconnect_Tick(object sender, EventArgs e)
        {
            tmrGigEReconnect.Enabled = false;

            lock (m_dicDisconnectedCamera)
            {
                if (m_dicDisconnectedCamera.Count <= 0)
                    return;

                List<string> lstConnectedCamera = new List<string>();

                foreach (KeyValuePair<string, string> stDevice in m_dicDisconnectedCamera)
                {
                    //bool bOK = false;
                    string strCameraIP = (string)stDevice.Value;
                    CogFrameGrabbers grabbers = new CogFrameGrabbers();

                    foreach (ICogFrameGrabber grabber in grabbers)
                    {
                        if (grabber.OwnedGigEAccess == null)
                            continue;

                        if (grabber.OwnedGigEAccess.CurrentIPAddress == strCameraIP)
                        {
                            //AddLstBxMessage("카메라 연결확인. S/N=" + strCameraIP);
                            AddLstBxMessage("Check the Camera. S/N=" + strCameraIP);

                            Ping ping = new Ping();
                            PingReply pr = null;
                            try
                            {
                                pr = ping.Send(strCameraIP, 100);
                                if (pr != null && pr.Status == IPStatus.Success)
                                {
                                    //AddLstBxMessage("카메라 재접속. S/N=" + strCameraIP);
                                    //AVisionProBuild.WriteLogFile("카메라 재접속. S/N=" + strCameraIP, ".AcqFifo.err.txt");
                                    AddLstBxMessage("Camera is connected. S/N=" + strCameraIP);
                                    AVisionProBuild.WriteLogFile("Camera is connected. S/N=" + strCameraIP, ".AcqFifo.err.txt");
                                    //bOK = true;

                                    lstConnectedCamera.Add(stDevice.Key);
                                    break;
                                }
                            }
                            catch
                            {
                                //
                            }
                        }
                    }
                }

                foreach (string strSerialNumber in lstConnectedCamera)
                {
                    m_dicDisconnectedCamera.Remove(strSerialNumber);
                }
                lstConnectedCamera.Clear();

                if (m_dicDisconnectedCamera.Count != 0)
                    tmrGigEReconnect.Enabled = true;
            }
        }
#endif

#endregion
        private void AddLstBxMessage(string strVal)
        {
            if (lstbxMessage.InvokeRequired == true)
            {
                this.Invoke(new dgAddLstBxMessage(AddLstBxMessage), new object[] { strVal });
                return;
            }

            DateTime dt = DateTime.Now;
            // 2012.02.29
            string strTime = dt.ToString("HH:mm:ss.fff ");

            if (lstbxMessage.Items.Count > 100)
            {
                lstbxMessage.Items.RemoveAt(100);
            }
            lstbxMessage.Items.Insert(0, strTime + strVal);

            // 2014.10.04
            AVisionProBuild.WriteLogFile(strVal);
        }

        public void ChangeBody(int nBody)
        {
            if (AVisionProBuild.Auto)
            {
                for (int i = 0; i < AVisionProBuild.GetTypeCount(); i++)
                {
                    string[] pstrPlcToPc = AVisionProBuild.m_lstAType[i].PlcToPc.Split(',');
                    foreach (string strPlctoPc in pstrPlcToPc)
                    {
                        if (strPlctoPc == "")
                            continue;
                        if (Convert.ToInt32(strPlctoPc) == nBody && cmbType.SelectedIndex != i)
                        {
                            cmbType.SelectedIndex = i;
                            
                            AddLstBxMessage("I:Body(" + lblType.Text + ")");
                            return;
                        }
                    }
                }

            }
        }

        private void ChangeSeqNo()
        {
            string strTemp = String.Format("{0:d}", m_AThrdPlc.GetWordDI(Convert.ToInt32(ASDef._DI_SEQ_NO)));
            // 2016.06.15
            if ((strTemp != "") && (!lblSeqNo.Text.Equals(strTemp)))
            {

                lblSeqNo.Text = strTemp;
                AVisionProBuild.WriteLogFile("I:SeqNo(" + strTemp + ")");
            }
        }

        private void ChangeBodyNo()
        {
            string strBodyNo =
                Convert.ToChar((m_AThrdPlc.GetWordDI(ASDef._DI_BODY_NO + 0) & 0xFF00) >> 8).ToString() +
                Convert.ToChar((m_AThrdPlc.GetWordDI(ASDef._DI_BODY_NO + 0) & 0xFF)).ToString() +
                Convert.ToChar((m_AThrdPlc.GetWordDI(ASDef._DI_BODY_NO + 1) & 0xFF00) >> 8).ToString() +
                Convert.ToChar((m_AThrdPlc.GetWordDI(ASDef._DI_BODY_NO + 1) & 0xFF)).ToString() +
                Convert.ToChar((m_AThrdPlc.GetWordDI(ASDef._DI_BODY_NO + 2) & 0xFF00) >> 8).ToString() +
                Convert.ToChar((m_AThrdPlc.GetWordDI(ASDef._DI_BODY_NO + 2) & 0xFF)).ToString() +
                Convert.ToChar((m_AThrdPlc.GetWordDI(ASDef._DI_BODY_NO + 3) & 0xFF00) >> 8).ToString() +
                Convert.ToChar((m_AThrdPlc.GetWordDI(ASDef._DI_BODY_NO + 3) & 0xFF)).ToString();                

            // 2016.06.15
            if ((strBodyNo != "") && (!lblBodyNo.Text.Equals(strBodyNo)))
            {
                lblBodyNo.Text = strBodyNo;
                AVisionProBuild.WriteLogFile("I:BodyNo(" + strBodyNo + ")");
            }
        }

        /*
        private void CheckUse(int nIndex)
        {
            if (m_IsInitializing == false)
            {
                AFrmPW dlgPW = new AFrmPW(this.Handle);
                dlgPW.ShowDialog(this);

                if (dlgPW.m_bPW)
                {
                    AIniUse aIniUse = new AIniUse(cmbType.SelectedIndex, nIndex);
                    aIniUse.m_bUse = m_pchkUse[nIndex].Checked;
                    aIniUse.Write();
                }                
                else // 2011.08.15
                {
                    m_IsInitializing = true;
                    m_pchkUse[nIndex].Checked = !m_pchkUse[nIndex].Checked;
                    m_IsInitializing = false;
                }
            }
        }
        */

#if _USE_BASLER_PYLON
        // 2016.07.18 by kdi
        private string CheckCamera()
        {
            string strInvalidCamera = "";

            try
            {
                int nCamCount = AUtil.GetPrivateProfileInt("Camera", "Count", 1, ASDef._CAM_FILE);

                AType aType;
                APoint aPoint;
                string strSN = "";
                clsCAM_Info CamInfo = null;

                for (int nCam = 0; nCam < nCamCount; ++nCam)
                {
                    aType = AVisionProBuild.GetType(nCam);

                    for (int i = 0; i < ASDef._POINT_COUNT; i++)
                    {
                        aPoint = AVisionProBuild.GetPoint(nCam, i);
                        strSN = aPoint.m_strDevName;

                        // 2016.08.01
                        if (strSN != "0")
                        {
                            CamInfo = ABaslerPylon.GetCameraInfo(strSN);
                            if (CamInfo == null)
                            {
                                if (strInvalidCamera.IndexOf(strSN) == -1)
                                {
                                    if (strInvalidCamera.Length > 0)
                                        strInvalidCamera += ", ";
                                    strInvalidCamera += strSN;
                                }
                            }
                            else
                            {
                                if (FindCamera(CamInfo.m_strSerialNumber) == false)
                                {
                                    if (strInvalidCamera.IndexOf(strSN) == -1)
                                    {
                                        if (strInvalidCamera.Length > 0)
                                            strInvalidCamera += ", ";
                                        strInvalidCamera += strSN;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch { }

            return strInvalidCamera;

        }

        private bool FindCamera(string strDev)
        {
            bool bFound = false;

            List<ABaslerPylon._stPylonDevice> CamList = ABaslerPylon.CamList;

            for (int i = 0; i < CamList.Count; i++)
            {
                if (CamList[i].strName.Contains(strDev) == true)
                {
                    bFound = true;
                    break;
                }
            }

            return bFound;
        }
#else
        // 2020.03.11
        private string CheckCamera()
        {
            string strInvalidCamera = "";
            // 2015.12.10
            try
            {
                int nTypeCount = AUtil.GetPrivateProfileInt("Type", "Count", 1, ASDef._INI_FILE);

                AType aType;
                APoint aPoint;
                string strSN1 = "", strSN2 = "";
                StringBuilder sb = new StringBuilder(100);

                for (int nType = 0; nType < nTypeCount; ++nType)
                {
                    aType = AVisionProBuild.GetType(nType);

                    for (int i = 0; i < ASDef._POINT_COUNT; i++)
                    {
                        // Vpp의 카메라 S/N
                        aPoint = AVisionProBuild.GetPoint(nType, i);
                        strSN1 = AVisionProBuild.GetCameraSerialNumber((CogAcqFifoTool)aPoint.GetAcq().AcqFifoTool, false);

                        // 2019.07.26
                        // INI의 카메라 S/N
                        //AUtil.GetPrivateProfileString(aType.Name, "Point" + i.ToString() + "_Camera_SN", "", sb, 100, ASDef._INI_FILE);
                        //strSN2 = sb.ToString();
                        strSN2 = aPoint.m_strDevName;

                        // 2019.08.02
                        int nChknum = 0;
                        Boolean bNum = int.TryParse(strSN2, out nChknum);
                        if (bNum)
                        {

                            if (strSN1 != strSN2)
                            {
                                if (strInvalidCamera.IndexOf(strSN2) == -1)
                                {
                                    if (strInvalidCamera.Length > 0)
                                        strInvalidCamera += ", ";
                                    strInvalidCamera += strSN2;

                                    //AVisionProBuild.m_bExistInvalidCamera = true;
                                }
                            }
                        }
                    }
                }
            }
            catch { }

            return strInvalidCamera;

        }

        // 2020.03.11
        private bool InitCameraInfo()
        {
            // 카메라 정보를 읽어온다.
            clsCamera.GetCameraInfo();

            string strTemp = "";
            CogFrameGrabbers cogFrameGrabbers = new CogFrameGrabbers();

            if (cogFrameGrabbers.Count < 1)
            {
                return false;
            }
            else
            {
                foreach (ICogFrameGrabber grabber in cogFrameGrabbers)
                {
                    if (grabber.OwnedGigEAccess == null)
                        continue;

                    clsCAM_Info camInfo = clsCamera.GetCameraInfo(grabber.SerialNumber);
                    if (camInfo == null)
                    {
                        strTemp = string.Format("카메라 목록에 등록되지 않은 카메라입니다.\r\n카메라 정보={0}-{1}", grabber.Name, grabber.SerialNumber);
                        MessageBox.Show(strTemp);
                    }
                    else
                    {
                        clsFrameGrabber GrabberInfo = new clsFrameGrabber();

                        ICogAcqFifo acqfifo = null;

                        if (camInfo.m_strPixelFormat == "Mono 8")
                            acqfifo = grabber.CreateAcqFifo("Generic GigEVision (Mono)", CogAcqFifoPixelFormatConstants.Format8Grey, 0, false);
                        else
                            acqfifo = grabber.CreateAcqFifo("Generic GigEVision (YUV422 Packed)", CogAcqFifoPixelFormatConstants.Format32RGB, 0, false);

                        acqfifo.OwnedContrastParams.Contrast = camInfo.m_dContrast;
                        acqfifo.OwnedBrightnessParams.Brightness = camInfo.m_dBrightness;
                        acqfifo.OwnedExposureParams.Exposure = camInfo.m_n64Exposure;
                        acqfifo.Timeout = (double)camInfo.m_nTimeout;
                        acqfifo.Flush();

                        GrabberInfo.m_AcqFifo = acqfifo;
                        GrabberInfo.m_strSerialNumber = camInfo.m_strSerialNumber;
                        GrabberInfo.m_Grabber = grabber;
                        clsCamera.FrameGrabberList.Add(GrabberInfo);
                    }
                }
                //m_icogFrameGrabber = cogFrameGrabbers[nFrameGrabberindex];
                //m_icogAcqFifo = m_icogFrameGrabber.CreateAcqFifo(strVideoFormat, CogAcqFifoPixelFormatConstants.Format8Grey, nCamPort, true);

                //return true;


            }

            return true;
        }

#endif

        private void DisplayDIO_Bit(uint nDIO, int nValue)
        {
            int i = 0;

            if (nDIO == ASDef._DI)
            {
                for (i = 0; i < 16; i++)
                {
                    if (((nValue >> i) & 0x01) == 0x01)
                    {
                        // 2016.06.15
                        //m_plblIN[i].BackColor = Color.GreenYellow;
                        aioMapIN.SetBit(i, true);
                    }
                    else
                    {
                        // 2016.06.15
                        //m_plblIN[i].BackColor = Color.White;
                        aioMapIN.SetBit(i, false);
                    }
                }
            }
            else
            {
                for (i = 0; i < 16; i++)
                {
                    if (((nValue >> i) & 0x01) == 0x01)
                    {
                        // 2016.06.15
                        //m_plblOUT[i].BackColor = Color.GreenYellow;
                        aioMapOUT.SetBit(i, true);
                    }
                    else
                    {
                        // 2016.06.15
                        //m_plblOUT[i].BackColor = Color.White;
                        aioMapOUT.SetBit(i, false);
                    }
                }
            }
        }

        private void DisplayResult(Label lbl, ASDef._emResult emResult)
        {

            lbl.BackColor = ASDef.pclrResult[(int)emResult + 2];
            // 2015.11.13
            if (emResult == ASDef._emResult.NO)
                lbl.Text = "";
            else
                lbl.Text = emResult.ToString();
        }
        
        private void DisplayThreadLabelText(Label lbl, string strdata)
        {
            // 스레드에서 Label을 수정할때 예외 방지
            if (lbl.InvokeRequired)
            {
                this.Invoke(new dgDisplayThreadLabelText(DisplayThreadLabelText), new object[] { lbl, strdata });
            }
            else
            {
                lbl.Text = strdata;

            }
        }

        // 2015.03.01
        private int DisplayStatusBar()
        {
            string strPath = AVisionProBuild.m_strResultPath;
            // 2017.01.17
            if (strPath == null)
                return -2;

            int nPos = strPath.IndexOf(':');
            if (nPos < 0)
            {
                // error
                return -1;
            }
            string strDrive = strPath.Substring(0, nPos);

            try
            {
                DriveInfo drv = new DriveInfo(strDrive);
                string strTotal = drv.TotalSize.ToString();

                float lFree = drv.TotalFreeSpace / (float)1024 / (float)1024 / (float)1024; // GB
                float lPercent = ((float)drv.TotalFreeSpace / (float)drv.TotalSize) * 100;
                string strTemp = string.Format("HDD : {0:N}GB ({1:N}%) Free", lFree, lPercent);

                statusStrip.Items[0].Text = strTemp;
                if (lPercent < 10)
                {
                    statusStrip.Items[0].BackColor = Color.Crimson;
                    statusStrip.Items[0].ForeColor = Color.Yellow;

                    AddLstBxMessage(strTemp);
                }
                else if (lPercent < 30)
                {
                    statusStrip.Items[0].BackColor = Color.OrangeRed;
                    statusStrip.Items[0].ForeColor = Color.Black;
                }
                else
                {
                    statusStrip.Items[0].BackColor = Color.FromArgb(250, 240, 240, 240);
                    statusStrip.Items[0].ForeColor = Color.Black;
                }

                m_fFreeHDD_Percent = lPercent;
            }
            catch
            {
                statusStrip.Items[0].Text = "HDD : " +
                    AUtil.GetXmlLanguage("Error");
                statusStrip.Items[0].BackColor = Color.Red;

                AddLstBxMessage(statusStrip.Items[0].Text);
            }

            System.Diagnostics.Process myProcesses;
            myProcesses = System.Diagnostics.Process.GetCurrentProcess();
            statusStrip.Items[1].Text = " [Memory : " + (myProcesses.PrivateMemorySize64 / 1048576).ToString() + " MB]";
            //statusStrip.Items[1].Text = " [Memory : " + (myProcesses.VirtualMemorySize64 / 1048576).ToString() + " MB]";
            //statusStrip.Items[1].Text = " [Memory : " + (myProcesses.PagedMemorySize64 / 1048576).ToString() + " MB]";

            // 2017.03.15
            // 2016.06.15
            strPath = Application.ExecutablePath;
            /*
            FileInfo file = new FileInfo(strPath);
            statusStrip.Items[2].Text = " [exe Date : " + file.LastWriteTime + "] ";
            */
            statusStrip.Items[2].Text = string.Format(" [exe Ver: {0}, Date : {1}]", AUtil.GetFileVersion(System.Reflection.Assembly.GetExecutingAssembly()), AUtil.GetFileDateTime(strPath));

            return 0;
        }

        // 2016.06.15
        private void DisplayStatusBar_TopWindow()
        {
            int nTopWindow = AUtil.GetPrivateProfileInt("Select", "TopWindow", 1, ASDef._INI_FILE);

            CheckBox chkTopWindow = new CheckBox();
            chkTopWindow.Checked = nTopWindow == 1 ? true : false;
            chkTopWindow.Text = "Top Window";
            chkTopWindow.Click += new EventHandler(chkTopWindow_Clicked);
            ToolStripControlHost host = new ToolStripControlHost(chkTopWindow);
            statusStrip.Items.Add(host);

            m_bTopWindow = chkTopWindow.Checked;
        }

#if _USE_BASLER_PYLON
        // 2017.01.10 by kdi
        private void DisconnectedCamera(ABaslerPylon._stPylonDevice stDevice)
        {
            //AVisionPro.AVisionProBuild.WriteLogFile("DisconnectedCamera: start");

            if (stDevice.strSerialNumber == null)
                return;

            if (ABaslerPylon.GetDevHandle(stDevice.strSerialNumber) != null)
                return;

            lock (m_dicDisconnectedCamera)
            {
                if (m_dicDisconnectedCamera.ContainsKey(stDevice.strSerialNumber) == false)
                    m_dicDisconnectedCamera.Add(stDevice.strSerialNumber, stDevice.strIP);
            }

            AddLstBxMessage("카메라 연결해제. S/N=" + stDevice.strSerialNumber);
            AVisionProBuild.WriteLogFile("카메라 연결해제. S/N=" + stDevice.strSerialNumber, ".Err.txt");

            SetTimer(tmrGigEReconnect, true, false);

            //AVisionPro.AVisionProBuild.WriteLogFile("DisconnectedCamera: end");
        }
#endif

        // 2016.06.18
        private void InitLanguage()
        {
            // Common------------
            btnExit.Text = AUtil.GetXmlLanguage("Exit");

            // FrmMain---------------------
            btnManual3D.Text = AUtil.GetXmlLanguage("Manual") + " " + AUtil.GetXmlLanguage("Measure");
            btnAuto.Text = AUtil.GetXmlLanguage("Auto");
            _lblCar.Text = AUtil.GetXmlLanguage("Body");
            //_lblLoadImg.Text = AUtil.GetXmlLanguage("Image_Source");
            cmbLoadImg.Items.Clear();
            cmbLoadImg.Items.Add(AUtil.GetXmlLanguage("Camera"));
            cmbLoadImg.Items.Add(AUtil.GetXmlLanguage("ImageFile"));
            cmbLoadImg.SelectedIndex = 0;
            btnTypeSet.Text = AUtil.GetXmlLanguage("Body_Setup");
            btnFileDel.Text = AUtil.GetXmlLanguage("File_Del_Setup");
            _grpbxCommState.Text = AUtil.GetXmlLanguage("Comm_State");

            /*
            chkUseP1.Text = AUtil.GetXmlLanguage("Use");
            chkUseP2.Text = AUtil.GetXmlLanguage("Use");
            chkUseP3.Text = AUtil.GetXmlLanguage("Use");
            */
            // 2020.03.12
            //chkUseP4.Text = AUtil.GetXmlLanguage("Use");

            _lblResult.Text = AUtil.GetXmlLanguage("Result");

            btnLimitSet.Text = AUtil.GetXmlLanguage("Limit_Setting");
            
            //grpbxShift.Text = "Robot " + AUtil.GetXmlLanguage("Shift");
            // 2020.03.12
            //_grpbxCase.Text = AUtil.GetXmlLanguage("Case");

            btnPartOffsetSet.Text = AUtil.GetXmlLanguage("Part") + " " + AUtil.GetXmlLanguage("Offset") + " " + AUtil.GetXmlLanguage("Setup");
            //btnExposure.Text = AUtil.GetXmlLanguage("Exposure") + " " + AUtil.GetXmlLanguage("Setup");
            btnLengthSet.Text = AUtil.GetXmlLanguage("Distance") + " " + AUtil.GetXmlLanguage("Setup");
            btnLengthLoad.Text = AUtil.GetXmlLanguage("Distance") + " " + AUtil.GetXmlLanguage("Load");
        }

        private void LoadType()
        {
            try
            {
                // 차종
                cmbType.Items.Clear();
                for (int i = 0; i < AVisionProBuild.GetTypeCount(); ++i)
                {
                    string strType = AVisionProBuild.GetTypeName(i);

                    cmbType.Items.Add(strType);
                }
                cmbType.SelectedIndex = 0;
            }
            catch
            {

            }
        }

        private void LoadIni()
        {
            StringBuilder sb = new StringBuilder(256);
            // 2016.06.15
            string[] pstrItemsIN = new string[16];
            string[] pstrItemsOUT = new string[16];

            // DIO
            for (int j = 0; j < 16; ++j)
            {
                AUtil.GetPrivateProfileString("DIO", "IN" + j.ToString(), j.ToString(), sb, 32, ASDef._INI_FILE);
                // 2016.06.15
                //m_plblIN[j].Text = sb.ToString();
                pstrItemsIN[j] = sb.ToString();

                AUtil.GetPrivateProfileString("DIO", "OUT" + j.ToString(), j.ToString(), sb, 32, ASDef._INI_FILE);
                // 2016.06.15
                //m_plblOUT[j].Text = sb.ToString();
                pstrItemsOUT[j] = sb.ToString();

            }
            // 2016.06.15
            aioMapIN.Items = pstrItemsIN;
            aioMapOUT.Items = pstrItemsOUT;

            LoadType();

            // 2020.03.12
            //AUtil.GetPrivateProfileString("Case", "선택", "1", sb, 10, ASDef._INI_FILE);
            //cmbCase.SelectedIndex = Convert.ToInt32(sb.ToString());

            // 2016.06.18
            InitLanguage();
        }
        
        private void RunDI_Off(int nIndex)
        {
            string strMsg;

            // 2016.06.15
            //strMsg = "I_Off:" + m_plblIN[nIndex].Text;
            strMsg = "I_Off:" + aioMapIN.GetItem(nIndex);

            AddLstBxMessage(strMsg);
        }

        private void RunDI(int nIndex)
        {
            RunDI(nIndex, true);
        }

        private void RunDI(int nIndex, bool bAuto)
        {
            string strMsg;

            // 2014.10.04
            if (bAuto)
                // 2016.06.15
                //strMsg = "I:" + m_plblIN[nIndex].Text;
                strMsg = "I:" + aioMapIN.GetItem(nIndex);
            else
                // 2016.06.15
                //strMsg = "I(M):" + m_plblIN[nIndex].Text;
                strMsg = "I(M):" + aioMapIN.GetItem(nIndex);

            AddLstBxMessage(strMsg);

            switch (nIndex)
            {
                case ASDef._DI_BIT_START_P1:
                    {
                        RunRevision3D(0, true);
                    }
                    break;
                case ASDef._DI_BIT_START_P2:
                    {
                        RunRevision3D(1, true);
                    }
                    break;
                case ASDef._DI_BIT_START_P3:
                    {
                        RunRevision3D(2, true);
                        CheckCalcu();
                        tc3D_2D.SelectedIndex = 0;
                        if (AVisionProBuild.Auto)
                        {
                            if (m_bTopWindow)
                                AUtil.TopWindow(this.Handle, this.DefaultMargin.Left + 1, this.DefaultMargin.Top + 1);

                            tmrSaveJpeg.Enabled = true;

                            string strDateTime = DateTime.Now.ToString("yyyy_MM_dd_HHmmss");
                            for (int i = 0; i < ASDef._3D_POSITION_COUNT; i++)
                            {
                                SaveImage(i, strDateTime);
                            }                            
                        }
                    }
                    break;
                /*
                case ASDef._DI_BIT_START:
                    {
                        RunReset(true);
                        Application.DoEvents();

                        RunRevisions3D();
                    }
                    break;
                */
                case ASDef._DI_BIT_START_LH1_L:
                    {
                        RunRevision(ASDef._3D_POINT_COUNT + 0);
                        RunBlue(ASDef._3D_POINT_COUNT + 4);
                    }
                    break;
                case ASDef._DI_BIT_START_LH2_L:
                    {
                        RunRevision(ASDef._3D_POINT_COUNT + 1);
                        RunBlue(ASDef._3D_POINT_COUNT + 5);
                    }
                    break;
                case ASDef._DI_BIT_START_RH1_L:
                    {
                        RunRevision(ASDef._3D_POINT_COUNT + 2);
                        RunBlue(ASDef._3D_POINT_COUNT + 6);
                    }
                    break;
                case ASDef._DI_BIT_START_RH2_L:
                    {
                        RunRevision(ASDef._3D_POINT_COUNT + 3);
                        RunBlue(ASDef._3D_POINT_COUNT + 7);
                    }
                    break;
                case ASDef._DI_BIT_START_LH1_R:
                    {
                        RunRevision(ASDef._3D_POINT_COUNT + 4);
                        RunBlue(ASDef._3D_POINT_COUNT + 0);
                    }
                    break;
                case ASDef._DI_BIT_START_LH2_R:
                    {
                        RunRevision(ASDef._3D_POINT_COUNT + 5);
                        RunBlue(ASDef._3D_POINT_COUNT + 1);
                    }
                    break;
                case ASDef._DI_BIT_START_RH1_R:
                    {
                        RunRevision(ASDef._3D_POINT_COUNT + 6);
                        RunBlue(ASDef._3D_POINT_COUNT + 2);
                    }
                    break;
                case ASDef._DI_BIT_START_RH2_R:
                    {
                        RunRevision(ASDef._3D_POINT_COUNT + 7);
                        RunBlue(ASDef._3D_POINT_COUNT + 3);
                    }
                    break;
                case ASDef._DI_BIT_COMPLETE:
                    {
                        RunReset(false);
                    }
                    break;
                case ASDef._DI_BIT_RESET:
                    {
                        RunReset(true);
                    }
                    break;
            }
        }

        private void RunReset(bool bDisplay)
        {
            int i;


            int nVal;
            nVal = m_AThrdPlc.GetWordDO(ASDef._DO_SIGNAL);

            /*
            nVal &= (0xFFFF ^ (1 << ASDef._DO_BIT_COMPLETE_P1));
            nVal &= (0xFFFF ^ (1 << ASDef._DO_BIT_COMPLETE_P2));
            nVal &= (0xFFFF ^ (1 << ASDef._DO_BIT_COMPLETE_P3));
            
            nVal &= (0xFFFF ^ (1 << ASDef._DO_BIT_OK_LH1));
            nVal &= (0xFFFF ^ (1 << ASDef._DO_BIT_NG_LH1));
            nVal &= (0xFFFF ^ (1 << ASDef._DO_BIT_OK_LH2));
            nVal &= (0xFFFF ^ (1 << ASDef._DO_BIT_NG_LH2));
            nVal &= (0xFFFF ^ (1 << ASDef._DO_BIT_OK_RH1));
            nVal &= (0xFFFF ^ (1 << ASDef._DO_BIT_NG_RH1));
            nVal &= (0xFFFF ^ (1 << ASDef._DO_BIT_OK_RH2));
            nVal &= (0xFFFF ^ (1 << ASDef._DO_BIT_NG_RH2));
            */
            nVal = 0;

            m_AThrdPlc.SetWordDO(ASDef._DO_SIGNAL, nVal);

            if (bDisplay == true)
            {
                #region 3D_Source
                //-------------------------------------------------------------
                for (i = 0; i < ASDef._3D_POSITION_COUNT; i++)
                {
                    m_pstMeasure[i].stShift.dX = 0;
                    m_pstMeasure[i].stShift.dY = 0;
                    m_pstMeasure[i].stShift.dZ = 0;

                    m_pnR_3D[i] = -1;

                    DisplayResult3D(i, ASDef._emResult.NO);
                }
                //-------------------------------------------------------------
                #endregion

                #region 2D_Source
                //-------------------------------------------------------------
                for (i = 0; i < ASDef._2D_POINT_COUNT; i++)
                {
                    m_plblX[i].Text = "";
                    m_plblY[i].Text = "";
                    m_plblY[i].BackColor = Color.Gray;
                }
                //-------------------------------------------------------------
                #endregion

                DisplayResult(lblResult, ASDef._emResult.NO);
            }

            // 2016.11.09
            for (i = 0; i < ASDef._MAX_LIGHT_CONTROL; i++)
            {
                m_pACommLightControl[i].SendToOnOff(0, false);
            }

            // 2011.09.16
            GC.Collect();
        }

        private void RunBlue(int nPoint)
        {
            ADisplay aDisplay = AVisionProBuild.GetDisplay(nPoint);
            if (aDisplay == null)
                return;
            aDisplay.ClearAll();
        }

        private void SetResultDO(ASDef._emResult emResult, int nPoint)
        {
            int nBit = 0;
            int nVal = m_AThrdPlc.GetWordDO(ASDef._DO_SIGNAL);

            if (emResult == ASDef._emResult.OK || emResult == ASDef._emResult.NO || emResult == ASDef._emResult.Pass)
            {
                switch (nPoint)
                {
                    case (ASDef._3D_POINT_COUNT + 0):
                    case (ASDef._3D_POINT_COUNT + 4):
                        nBit = ASDef._DO_BIT_OK_LH1;
                        nVal |= (1 << ASDef._DO_BIT_OK_LH1);
                        break;
                    case (ASDef._3D_POINT_COUNT + 1):
                    case (ASDef._3D_POINT_COUNT + 5):
                        nBit = ASDef._DO_BIT_OK_LH2;
                        nVal |= (1 << ASDef._DO_BIT_OK_LH2);
                        break;
                    case (ASDef._3D_POINT_COUNT + 2):
                    case (ASDef._3D_POINT_COUNT + 6):
                        nBit = ASDef._DO_BIT_OK_RH1;
                        nVal |= (1 << ASDef._DO_BIT_OK_RH1);
                        break;
                    case (ASDef._3D_POINT_COUNT + 3):
                    case (ASDef._3D_POINT_COUNT + 7):
                        nBit = ASDef._DO_BIT_OK_RH2;
                        nVal |= (1 << ASDef._DO_BIT_OK_RH2);
                        break;
                }
                
            }
            else
            {
                switch (nPoint)
                {
                    case (ASDef._3D_POINT_COUNT + 0):
                    case (ASDef._3D_POINT_COUNT + 4):
                        nBit = ASDef._DO_BIT_NG_LH1;
                        nVal |= (1 << ASDef._DO_BIT_NG_LH1);
                        break;
                    case (ASDef._3D_POINT_COUNT + 1):
                    case (ASDef._3D_POINT_COUNT + 5):
                        nBit = ASDef._DO_BIT_NG_LH2;
                        nVal |= (1 << ASDef._DO_BIT_NG_LH2);
                        break;
                    case (ASDef._3D_POINT_COUNT + 2):
                    case (ASDef._3D_POINT_COUNT + 6):
                        nBit = ASDef._DO_BIT_NG_RH1;
                        nVal |= (1 << ASDef._DO_BIT_NG_RH1);
                        break;
                    case (ASDef._3D_POINT_COUNT + 3):
                    case (ASDef._3D_POINT_COUNT + 7):
                        nBit = ASDef._DO_BIT_NG_RH2;
                        nVal |= (1 << ASDef._DO_BIT_NG_RH2);
                        break;
                }
            }
            m_AThrdPlc.SetWordDO(ASDef._DO_SIGNAL, nVal);

            string strTmp;
            // 2016.06.15
            //strTmp = "O:" +  m_plblOUT[nBit].Text;
            strTmp = "O:" + aioMapOUT.Items[nBit];

            AddLstBxMessage(strTmp);
        }

#if _USE_BASLER_PYLON
        // 2017.01.10 by kdi
        private void SetTimer(System.Windows.Forms.Timer tmr, bool bEnable, bool bForcibilyDisable)
        {
            if (this.InvokeRequired)
                this.Invoke(new dgSetTimer(SetTimer), new object[] { tmr, bEnable, bForcibilyDisable });
            else
            {
                if (bEnable == true && bForcibilyDisable == true)
                    tmr.Enabled = false;

                tmr.Enabled = bEnable;
            }
        }
#endif

        private void SaveJpg()
        {
            string strFName;
            if (lblResult.Text.Substring(0, 2) == "OK")
                strFName = AVisionProBuild.GetTotalFName(true, "");
            else
                strFName = AVisionProBuild.GetTotalFName(false, "");

            Atmc.Capture.SaveJPG(strFName, this);
        }

        private void SetAutoMan(bool bAuto)
        {
            if (bAuto)
            {
                AVisionProBuild.Auto = bAuto;

                // 2014.10.04
                AddLstBxMessage("Auto");

                // 2016.06.18
                lblAuto.Text = AUtil.GetXmlLanguage("Auto");

                lblAuto.BackColor = Color.Black;
                lblAuto.ForeColor = Color.Yellow;

                cmbLoadImg.SelectedIndex = 0;

                ChangeBody(m_AThrdPlc.GetWordDI(ASDef._DI_BODY));

                // 2016.11.09
                for (int i = 0; i < ASDef._MAX_LIGHT_CONTROL; i++)
                {
                    m_pACommLightControl[i].SendToOnOff(0, false);
                }

                LiveOff();
            }
            else
            {
                /*
                AFrmPW dlgPW = new AFrmPW(this.Handle);
                dlgPW.ShowDialog(this);

                if (dlgPW.m_bPW == false)
                    return;
                */

                AVisionProBuild.Auto = bAuto;

                // 2014.10.04
                AddLstBxMessage("Manual");

                // 2016.06.18
                lblAuto.Text = AUtil.GetXmlLanguage("Manual");

                lblAuto.BackColor = Color.Red;
                lblAuto.ForeColor = Color.Black;
            }

            cmbType.Enabled = !bAuto;
            cmbLoadImg.Enabled = !bAuto;
            btnTypeSet.Enabled = !bAuto;
            btnExit.Enabled = !bAuto;
            btnFileDel.Enabled = !bAuto;

            #region 3D_Source
            //-------------------------------------------------------------
            // 2011.08.07
            //btnPartOffsetSet.Enabled = !bAuto;
            btnLengthSet.Enabled = !bAuto;
            chkLiveP1.Enabled = !bAuto;
            chkLiveP2.Enabled = !bAuto;
            chkLiveP3.Enabled = !bAuto;
            // 2020.03.12
            //chkLiveP4.Enabled = !bAuto;

            chkLiveSearchP1.Enabled = !bAuto;
            chkLiveSearchP2.Enabled = !bAuto;
            chkLiveSearchP3.Enabled = !bAuto;
            // 2020.03.12
            //chkLiveSearchP4.Enabled = !bAuto;

            /*
            for (int i = 0; i < ASDef._3D_POSITION_COUNT; i++)
            {
                m_pchkUse[i].Enabled = !bAuto;
            }
            */

            // 2011.08.06
            btnManual3D.Enabled = !bAuto;

            // 2020.03.12
            //cmbCase.Enabled = !bAuto;

            // 2016.07.18
            btnLengthSet.Enabled = !bAuto;
            // 2016.06.20
            btnLengthLoad.Enabled = !bAuto;
            //-------------------------------------------------------------
            #endregion

            #region 2D_Source
            //-------------------------------------------------------------
            btnManualLH1_L.Enabled = !bAuto;
            btnManualLH2_L.Enabled = !bAuto;
            btnManualRH1_L.Enabled = !bAuto;
            btnManualRH2_L.Enabled = !bAuto;

            btnManualLH1_R.Enabled = !bAuto;
            btnManualLH2_R.Enabled = !bAuto;
            btnManualRH1_R.Enabled = !bAuto;
            btnManualRH2_R.Enabled = !bAuto;
            //-------------------------------------------------------------
            #endregion
        }

        

        // 2015.02.25
        private void CheckSingalData()
        {
            int i, j;
            // 2016.06.15
            //for (j = 0; j < ASDef._MAX_PLC_DI; j++)
            for (j = ASDef._MAX_PLC_DI - 1; j >= 0; j--)
            {
                m_pnDI[j] = m_AThrdPlc.GetWordDI(j);

                if (m_pnDI[j] != m_pnOldDI[j])
                {
                    IntPtr hWnd = AUtil.FindWindow(null, "PLC MAP List");
                    if (hWnd.ToInt32() != 0)
                    {
                        AUtil.PostMessage(hWnd, ASDef._WM_CHANGE_DI, j, m_pnDI[j]);
                    }

                    switch (j)
                    {
                        case ASDef._DI_SIGNAL:
                            {
                                DisplayDIO_Bit(ASDef._DI, m_pnDI[j]);

                                if (AVisionProBuild.Auto == true)
                                {
                                    for (i = 0; i < 16; i++)
                                    {
                                        if ((((m_pnDI[j] >> i) & 0x01) == 0x01) &&
                                            (((m_pnOldDI[j] >> i) & 0x01) == 0x00))
                                        {
                                            RunDI(i);

                                            // 2017.01.17
                                            // 2016.06.15
                                            //Application.DoEvents();
                                        }
                                    }

                                    for (i = 0; i < 16; i++)
                                    {
                                        if ((((m_pnDI[j] >> i) & 0x01) == 0x00) &&
                                            (((m_pnOldDI[j] >> i) & 0x01) == 0x01))
                                        {
                                            RunDI_Off(i);

                                            // 2017.01.17
                                            // 2016.06.15
                                            //Application.DoEvents();
                                        }
                                    }
                                }
                            }
                            break;
                        case ASDef._DI_BODY:
                            {
                                if (AVisionProBuild.Auto == true)
                                {
                                    if (m_pnDI[j] != 0)
                                    {
                                        ChangeBody(m_pnDI[j]);
                                    }
                                }
                            }
                            break;
                        case ASDef._DI_SEQ_NO:
                        //case ASDef._DI_SEQ_NO + 1:
                            {
                                ChangeSeqNo();
                            }
                            break;

                        case ASDef._DI_BODY_NO:
                        case ASDef._DI_BODY_NO + 1:
                        case ASDef._DI_BODY_NO + 2:
                        case ASDef._DI_BODY_NO + 3:
                            {
                                ChangeBodyNo();
                            }
                            break;
                    }
                    m_pnOldDI[j] = m_pnDI[j];

                    // 2017.01.17
                    // 2016.06.15
                    //Application.DoEvents();
                }
            }
        }

        protected override void WndProc(ref Message m)  // IO thread message 받는 것
        {
            int i;

            switch (m.Msg)
            {
                case ASDef._WM_CHANGE_DI:
                    {

                        //-----------------------------------
                        IntPtr hWnd = AUtil.FindWindow(null, "PLC MAP List");

                        if (hWnd.ToInt32() != 0)
                        {
                            if (m.WParam.ToInt32() == 0xFF && m.LParam.ToInt32() == 0xFF)
                            {
                                for (i = 0; i < ASDef._MAX_PLC_DI; i++)
                                {
                                    AUtil.PostMessage(hWnd, ASDef._WM_CHANGE_DI, i, m_AThrdPlc.GetWordDI(i));
                                }
                                for (i = 0; i < ASDef._MAX_PLC_DO; i++)
                                {
                                    AUtil.PostMessage(hWnd, ASDef._WM_CHANGE_DO, i, m_AThrdPlc.GetWordDO(i));
                                }
                            }
                            /* 2015.03.01
                            else
                            {
                                AUtil.PostMessage(hWnd, ASDef._WM_CHANGE_DI, m.WParam.ToInt32(), m.LParam.ToInt32());
                            }
                            */
                        }
                        //-----------------------------------
                        /* 2015.03.01
                        if (m.WParam.ToInt32() == ASDef._DI_SIGNAL)
                        {
                            DisplayDIO_Bit(ASDef._DI, m.LParam.ToInt32());

                            if (AVisionProBuild.Auto == true)
                            {
                                // 2014.10.04
                                int nDI = m_AThrdPlc.GetWordDI(Convert.ToInt32(ASDef._DI_SIGNAL));
                                int nOldDI = m_AThrdPlc.GetWordOldDI(Convert.ToInt32(ASDef._DI_SIGNAL));
                                for (i = 0; i < 16; i++)
                                {
                                    if ((((nDI >> i) & 0x01) == 0x01) &&
                                        (((nOldDI >> i) & 0x01) == 0x00))
                                    {
                                        RunDI(i);
                                    }
                                }
                                for (i = 0; i < 16; i++)
                                {
                                    if ((((nDI >> i) & 0x01) == 0x00) &&
                                        (((nOldDI >> i) & 0x01) == 0x01))
                                    {
                                        RunDI_Off(i);
                                    }
                                }
                            }
                        }
                        if (m.WParam.ToInt32() == ASDef._DI_BODY)
                        {
                            if (AVisionProBuild.Auto == true)
                            {
                                if (m.LParam.ToInt32() != 0)
                                {
                                    ChangeBody(m.LParam.ToInt32());
                                }
                            }
                        }
                        if (m.WParam.ToInt32() == ASDef._DI_SEQ_NO)
                        {
                            ChangeSeqNo();
                        }
                        if (m.WParam.ToInt32() == ASDef._DI_BODY_NO + 0 ||
                             m.WParam.ToInt32() == (ASDef._DI_BODY_NO + 1) ||
                             m.WParam.ToInt32() == (ASDef._DI_BODY_NO + 2) ||
                             m.WParam.ToInt32() == (ASDef._DI_BODY_NO + 3))
                        {
                            ChangeBodyNo();
                        }
                        */
                    }
                    break;
                /* 2015.03.01
                case ASDef._WM_CHANGE_DO:
                    {
                        //---------------------------------
                        IntPtr hWnd = AUtil.FindWindow(null, "PLC MAP List");
                        if (hWnd.ToInt32() != 0)
                        {
                            AUtil.PostMessage(hWnd, ASDef._WM_CHANGE_DO, m.WParam.ToInt32(), m.LParam.ToInt32());
                        }
                        //-----------------------------------

                        if (m.WParam.ToInt32() == ASDef._DO_SIGNAL)
                        {
                            DisplayDIO_Bit(ASDef._DO, m.LParam.ToInt32());
                        }

                    }
                    break;
                */
                case AThrdClientSocketPlcSiemens._WM_SOCKET_FETCH_OK:
                    {
                        lblStateCommPLC_R.Text = "F";

                        if (lblStateCommPLC_R.BackColor == Color.GreenYellow)
                        {
                            lblStateCommPLC_R.BackColor = Color.ForestGreen;
                        }
                        else
                        {
                            lblStateCommPLC_R.BackColor = Color.GreenYellow;
                        }

                        // 2015.03.01
                        //tmrReconnect.Enabled = false;
                        m_nPlcErrCountR = 0;
                        //------------------------------------------
                        // 2015.03.01
                        if (m_bLockDI == false)
                        {
                            m_bLockDI = true;
                            try
                            {
                                CheckSingalData();
                            }
                            finally
                            {
                                m_bLockDI = false;
                            }
                        }
                        //------------------------------------------
                    }
                    break;
                case AThrdClientSocketPlcSiemens._WM_SOCKET_FETCH_NG:
                    {
                        lblStateCommPLC_R.Text = "F:" + m.WParam.ToString();
                        lblStateCommPLC_R.BackColor = Color.Red;

                        // 2015.03.01
                        //if ((int)m.WParam != -10)   // 소켓 send는 되나, receive가 안되는 상태
                        m_nPlcErrCountR++;
                        if (m_nPlcErrCountR > 3)
                        {
                            m_nPlcErrCountR = 0;
                            // 2016.06.15
                            m_AThrdPlc.Stop();

                            if (tmrReconnect.Enabled == false)
                            {
                                tmrReconnect.Enabled = true;
                            }
                        }
                    }
                    break;

                case AThrdClientSocketPlcSiemens._WM_SOCKET_WRITE_OK:
                    {
                        lblStateCommPLC_W.Text = "W";

                        if (lblStateCommPLC_W.BackColor == Color.GreenYellow)
                        {
                            lblStateCommPLC_W.BackColor = Color.ForestGreen;
                        }
                        else
                        {
                            lblStateCommPLC_W.BackColor = Color.GreenYellow;
                        }
                        m_nPlcErrCountW = 0;

                        // 2015.03.01                       
                        for (int j = 0; j < ASDef._MAX_PLC_DO; j++)
                        {
                            // 2017.01.17
                            //if (m_AThrdPlc.GetWordDO(j) != m_AThrdPlc.GetWordOldDO(j))
                            {
                                if (j == ASDef._DO_SIGNAL)
                                    DisplayDIO_Bit(ASDef._DO, m_AThrdPlc.GetWordDO(ASDef._DO_SIGNAL));

                                IntPtr hWnd = AUtil.FindWindow(null, "PLC MAP List");
                                if (hWnd.ToInt32() != 0)
                                {
                                    AUtil.PostMessage(hWnd, ASDef._WM_CHANGE_DO, j, m_AThrdPlc.GetWordDO(j));
                                }
                            }
                        }
                    }
                    break;
                case AThrdClientSocketPlcSiemens._WM_SOCKET_WRITE_NG:
                    {
                        lblStateCommPLC_W.Text = "W:" + m.WParam.ToString();
                        lblStateCommPLC_W.BackColor = Color.Red;

                        m_nPlcErrCountW++;
                        if (m_nPlcErrCountW > 3)
                        {
                            m_nPlcErrCountW = 0;
                            m_AThrdPlc.Stop();

                            if (tmrReconnect.Enabled == false)
                            {
                                tmrReconnect.Enabled = true;
                            }
                        }

                    }
                    break;
                case AThrdUdpServerSocketRbtHHI._WM_AUDP_SOCKET_ROBOT_OK:
                    {
                        string strTmp = "";
                        int n = m.WParam.ToInt32();

                        switch (n)
                        {
                            case 0: 
                                strTmp = "Rbt_LH Send";
                                break;
                            case 1: 
                                strTmp = "Rbt_RH Send";
                                break;
                            default:
                                strTmp = "Rbt_" + (m.WParam.ToInt32()+1).ToString() + " Send";
                                break;
                        }
                        strTmp += (m.LParam.ToInt32()).ToString();

                        if (m_plblStateCommRbt[n].BackColor == Color.GreenYellow)
                        {
                            m_plblStateCommRbt[n].BackColor = Color.ForestGreen;
                        }
                        else
                        {
                            m_plblStateCommRbt[n].BackColor = Color.GreenYellow;
                        }
                        m_plblStateCommRbt[n].Text = "";

                        AddLstBxMessage(strTmp);

                    }
                    break;
                case AThrdUdpServerSocketRbtHHI._WM_AUDP_SOCKET_ROBOT_NG:
                    {
                        string strTmp = "";

                        int n = m.WParam.ToInt32();
                        switch (n)
                        {
                            case 0: 
                                strTmp = "Rbt_LH Err:";
                                break;
                            case 1: 
                                strTmp = "Rbt_RH Err:";
                                break;
                            default:
                                strTmp = "Rbt_" + (m.WParam.ToInt32() + 1).ToString() + " Send";
                                break;
                        }
                        strTmp += (m.LParam.ToInt32()).ToString();

                        m_plblStateCommRbt[n].Text = m.WParam.ToString();
                        m_plblStateCommRbt[n].BackColor = Color.Red;

                        AddLstBxMessage(strTmp);
                    }
                    break;
                // 2014.10.12
                case FrmPartOffset._WM_PARTOFFSET_CLOSE:
                    {
                        m_aIniPartOffset.Set(cmbType.Text);
                        m_aIniPartOffset.Read();
                    }
                    break;

                // 2016.11.09
                case AFrmLight._WM_LIGHT0:
                    {
                        LightOnOff(m.WParam.ToInt32(), m.LParam.ToInt32() , true);
                        SetLightControl(m.WParam.ToInt32(), m.LParam.ToInt32() , 0);
                    }
                    break;

                // 2020.03.11
                case ASDef._WM_CAMERA_IS_DISCONNECTED:
                    {
                        int nPoint = m.WParam.ToInt32();
                        int nIPAddress = m.LParam.ToInt32();

                        //string strIP = "192.168.87.27";
                        //System.Net.IPAddress ipaddress = System.Net.IPAddress.Parse(strIP);
                        //int intAddress = BitConverter.ToInt32(ipaddress.GetAddressBytes(), 0);
                        string ipAddress = new System.Net.IPAddress(BitConverter.GetBytes(nIPAddress)).ToString();

                        foreach (clsFrameGrabber grabber in clsCamera.FrameGrabberList)
                        {
                            if (grabber.m_Grabber.OwnedGigEAccess.CurrentIPAddress == ipAddress)
                            {
                                lock (m_dicDisconnectedCamera)
                                {
                                    if (m_dicDisconnectedCamera.ContainsKey(grabber.m_Grabber.SerialNumber) == false)
                                        m_dicDisconnectedCamera.Add(grabber.m_Grabber.SerialNumber, ipAddress);
                                }
                            }
                        }
                        //AddLstBxMessage("카메라 연결해제. S/N=" + stDevice.strSerialNumber);
                        //AVisionProBuild.WriteLogFile("카메라 연결해제. S/N=" + stDevice.strSerialNumber, ".Err.txt");

                        string strTemp = "";
                        strTemp = string.Format("Camera is disconnected");
                        AddLstBxMessage(strTemp);

                        tmrGigEReconnect.Enabled = true;
                    }
                    break;
            }

            base.WndProc(ref m);
        }

        private void XorBitDO(int nAddress, int nNum)
        {
            // 2011.08.06
            //if (AVisionProBuild.Auto == false)
            {
                if (((m_AThrdPlc.GetWordDO(nAddress) >> nNum) & 0x01) == 0x01)
                {
                    m_AThrdPlc.SetBitDO(nAddress, nNum, false);
                }
                else
                {
                    m_AThrdPlc.SetBitDO(nAddress, nNum, true);
                }
            }
        }

        #region 3D_Source
        //-------------------------------------------------------------

        // 2011.08.11   
        private void CalcuShift(int nCase)
        {
            // 계산
            m_stShift = default(ASDef._stRobotShift);

            int i, nBody = cmbType.SelectedIndex;
            ACalculationLotus3D._emPosition[] pemPosition = new ACalculationLotus3D._emPosition[3];

            if (nCase >= 0)
            {
                // 2011.08.07-----------------
                ASDef._stXYZ[] pstInit = new ASDef._stXYZ[3];
                ASDef._stXYZ[] pstMove = new ASDef._stXYZ[3];
                ASDef._stRobotShift stInitFrame;
                stInitFrame = default(ASDef._stRobotShift);
                ASDef._stRobotShift stMoveFrame;
                stMoveFrame = default(ASDef._stRobotShift);

                pemPosition[0] = ACalculationLotus3D._emPosition.P2;
                pemPosition[1] = ACalculationLotus3D._emPosition.P1;
                pemPosition[2] = ACalculationLotus3D._emPosition.P3;

                for (i = 0; i < 3; i++)
                {
                    pstInit[i].dX = m_aIniHoleLocation.m_pstXYZ[(int)pemPosition[i]].dX;
                    pstInit[i].dY = m_aIniHoleLocation.m_pstXYZ[(int)pemPosition[i]].dY;
                    pstInit[i].dZ = m_aIniHoleLocation.m_pstXYZ[(int)pemPosition[i]].dZ;

                    pstMove[i].dX = pstInit[i].dX + m_pstMeasure[(int)pemPosition[i]].stShift.dX;
                    pstMove[i].dY = pstInit[i].dY + m_pstMeasure[(int)pemPosition[i]].stShift.dY;
                    pstMove[i].dZ = pstInit[i].dZ + m_pstMeasure[(int)pemPosition[i]].stShift.dZ;
                }
                /* 2020.03.12
                ASDef._stXYZ st1Point;
                st1Point = default(ASDef._stXYZ);

                switch (nCase)
                {
                    case 0:
                        break;                    
                    case 1:
                        {
                            // P#1
                            FindLost1Point(0, ref st1Point);
                            pstMove[1].dX = pstInit[1].dX + st1Point.dX;
                            pstMove[1].dY = pstInit[1].dY + st1Point.dY;
                            pstMove[1].dZ = pstInit[1].dZ + st1Point.dZ;
                        }
                        break;
                    case 2:
                        {
                            // P#3
                            FindLost1Point(2, ref st1Point);
                            pstMove[2].dX = pstInit[2].dX + st1Point.dX;
                            pstMove[2].dY = pstInit[2].dY + st1Point.dY;
                            pstMove[2].dZ = pstInit[2].dZ + st1Point.dZ;
                        }
                        break;
                    case 3:
                        {
                            // P#2
                            FindLost1Point(1, ref st1Point);
                            pstMove[0].dX = pstInit[0].dX + st1Point.dX;
                            pstMove[0].dY = pstInit[0].dY + st1Point.dY;
                            pstMove[0].dZ = pstInit[0].dZ + st1Point.dZ;
                        }
                        break;
                    default:
                        {
                            for (i = 0; i < 3; i++)
                            {
                                pstMove[i].dX = pstInit[i].dX;
                                pstMove[i].dY = pstInit[i].dY;
                                pstMove[i].dZ = pstInit[i].dZ;
                            }
                        }
                        break;
                }
                */

                ACalculationLotus3D.MakeFrame(pstInit, ref stInitFrame);
                ACalculationLotus3D.MakeFrame(pstMove, ref stMoveFrame);

                m_stShift.dX = stMoveFrame.dX - stInitFrame.dX;
                m_stShift.dY = stMoveFrame.dY - stInitFrame.dY;
                m_stShift.dZ = stMoveFrame.dZ - stInitFrame.dZ;
                m_stShift.dAX = stMoveFrame.dAX - stInitFrame.dAX;
                m_stShift.dAY = stMoveFrame.dAY - stInitFrame.dAY;
                m_stShift.dAZ = stMoveFrame.dAZ - stInitFrame.dAZ;
                // 2012.04.19-------------------
                if (m_stShift.dAX > 180)
                {
                    m_stShift.dAX -= 360;
                }
                else if (m_stShift.dAX < -180)
                {
                    m_stShift.dAX += 360;
                }
                if (m_stShift.dAY > 180)
                {
                    m_stShift.dAY -= 360;
                }
                else if (m_stShift.dAY < -180)
                {
                    m_stShift.dAY += 360;
                }
                if (m_stShift.dAZ > 180)
                {
                    m_stShift.dAZ -= 360;
                }
                else if (m_stShift.dAZ < -180)
                {
                    m_stShift.dAZ += 360;
                }
                //--------------------------------
            }

            lblX.Text = m_stShift.dX.ToString("0.00");
            lblY.Text = m_stShift.dY.ToString("0.00");
            lblZ.Text = m_stShift.dZ.ToString("0.00");
            lblAX.Text = m_stShift.dAX.ToString("0.00");
            lblAY.Text = m_stShift.dAY.ToString("0.00");
            lblAZ.Text = m_stShift.dAZ.ToString("0.00");

            lblX.BackColor = Color.LightYellow;
            lblY.BackColor = Color.LightYellow;
            lblZ.BackColor = Color.LightYellow;
            lblAX.BackColor = Color.LightYellow;
            lblAY.BackColor = Color.LightYellow;
            lblAZ.BackColor = Color.LightYellow;

            if (m_stShift.dX < AVisionProBuild.GetType(nBody).m_pstLimitLow[0].dX ||
                m_stShift.dX > AVisionProBuild.GetType(nBody).m_pstLimitHigh[0].dX)
            {
                lblX.BackColor = ASDef.pclrResult[(int)ASDef._emResult.NG + 2];
            }
            if (
                m_stShift.dY < AVisionProBuild.GetType(nBody).m_pstLimitLow[0].dY ||
                m_stShift.dY > AVisionProBuild.GetType(nBody).m_pstLimitHigh[0].dY)
            {
                lblY.BackColor = ASDef.pclrResult[(int)ASDef._emResult.NG + 2];
            }
            if (
                m_stShift.dZ < AVisionProBuild.GetType(nBody).m_pstLimitLow[0].dZ ||
                m_stShift.dZ > AVisionProBuild.GetType(nBody).m_pstLimitHigh[0].dZ)
            {
                lblZ.BackColor = ASDef.pclrResult[(int)ASDef._emResult.NG + 2];
            }
            if (m_stShift.dX < AVisionProBuild.GetType(nBody).m_pstLimitLow[0].dX ||
                m_stShift.dX > AVisionProBuild.GetType(nBody).m_pstLimitHigh[0].dX)
            {
                lblX.BackColor = ASDef.pclrResult[(int)ASDef._emResult.NG + 2];
            }
            if (
                m_stShift.dY < AVisionProBuild.GetType(nBody).m_pstLimitLow[0].dY ||
                m_stShift.dY > AVisionProBuild.GetType(nBody).m_pstLimitHigh[0].dY)
            {
                lblY.BackColor = ASDef.pclrResult[(int)ASDef._emResult.NG + 2];
            }
            if (
                m_stShift.dZ < AVisionProBuild.GetType(nBody).m_pstLimitLow[0].dZ ||
                m_stShift.dZ > AVisionProBuild.GetType(nBody).m_pstLimitHigh[0].dZ)
            {
                lblZ.BackColor = ASDef.pclrResult[(int)ASDef._emResult.NG + 2];
            }
            if (m_stShift.dX < AVisionProBuild.GetType(nBody).m_pstLimitLow[0].dX ||
                m_stShift.dX > AVisionProBuild.GetType(nBody).m_pstLimitHigh[0].dX)
            {
                lblX.BackColor = ASDef.pclrResult[(int)ASDef._emResult.NG + 2];
            }
            if (
                m_stShift.dY < AVisionProBuild.GetType(nBody).m_pstLimitLow[0].dY ||
                m_stShift.dY > AVisionProBuild.GetType(nBody).m_pstLimitHigh[0].dY)
            {
                lblY.BackColor = ASDef.pclrResult[(int)ASDef._emResult.NG + 2];
            }
            if (
                m_stShift.dZ < AVisionProBuild.GetType(nBody).m_pstLimitLow[0].dZ ||
                m_stShift.dZ > AVisionProBuild.GetType(nBody).m_pstLimitHigh[0].dZ)
            {
                lblZ.BackColor = ASDef.pclrResult[(int)ASDef._emResult.NG + 2];
            }

            if (m_stShift.dAX < AVisionProBuild.GetType(nBody).m_pstLimitLow[0].dAX ||
                m_stShift.dAX > AVisionProBuild.GetType(nBody).m_pstLimitHigh[0].dAX)
            {
                lblAX.BackColor = ASDef.pclrResult[(int)ASDef._emResult.NG + 2];
            }
            if (
                m_stShift.dAY < AVisionProBuild.GetType(nBody).m_pstLimitLow[0].dAY ||
                m_stShift.dAY > AVisionProBuild.GetType(nBody).m_pstLimitHigh[0].dAY)
            {
                lblAY.BackColor = ASDef.pclrResult[(int)ASDef._emResult.NG + 2];
            }
            if (
                m_stShift.dAZ < AVisionProBuild.GetType(nBody).m_pstLimitLow[0].dAZ ||
                m_stShift.dAZ > AVisionProBuild.GetType(nBody).m_pstLimitHigh[0].dAZ)
            {
                lblAZ.BackColor = ASDef.pclrResult[(int)ASDef._emResult.NG + 2];
            }
        }

        private int CalcuHoleLength(int[] pnR)
        {
            double dDiffP1_P2;
            double dDiffP1_P3;
            // 2020.03.12
            //double dDiffP1_P4;

            double dDiffP2_P3;
            // 2020.03.12
            //double dDiffP2_P4;
            //double dDiffP3_P4;

            int nFail = 0;

            m_stHoleLength.dP1_P2 = GetLength(0, ACalculationLotus3D._emPosition.P1, ACalculationLotus3D._emPosition.P2);
            m_stHoleLength.dP1_P3 = GetLength(0, ACalculationLotus3D._emPosition.P1, ACalculationLotus3D._emPosition.P3);
            // 2020.03.12
            //m_stHoleLength.dP1_P4 = GetLength(0, ACalculationLotus3D._emPosition.P1, ACalculationLotus3D._emPosition.P4);
            
            m_stHoleLength.dP2_P3 = GetLength(0, ACalculationLotus3D._emPosition.P2, ACalculationLotus3D._emPosition.P3);

            // 2020.03.12
            //m_stHoleLength.dP2_P4 = GetLength(0, ACalculationLotus3D._emPosition.P2, ACalculationLotus3D._emPosition.P4);
            //m_stHoleLength.dP3_P4 = GetLength(0, ACalculationLotus3D._emPosition.P3, ACalculationLotus3D._emPosition.P4);

            m_stHoleLength.dShiftP1_P2 = GetLength(1, ACalculationLotus3D._emPosition.P1, ACalculationLotus3D._emPosition.P2);
            m_stHoleLength.dShiftP1_P3 = GetLength(1, ACalculationLotus3D._emPosition.P1, ACalculationLotus3D._emPosition.P3);
            // 2020.03.12
            //m_stHoleLength.dShiftP1_P4 = GetLength(1, ACalculationLotus3D._emPosition.P1, ACalculationLotus3D._emPosition.P4);

            m_stHoleLength.dShiftP2_P3 = GetLength(1, ACalculationLotus3D._emPosition.P2, ACalculationLotus3D._emPosition.P3);

            // 2020.03.12
            //m_stHoleLength.dShiftP2_P4 = GetLength(1, ACalculationLotus3D._emPosition.P2, ACalculationLotus3D._emPosition.P4);
            //m_stHoleLength.dShiftP3_P4 = GetLength(1, ACalculationLotus3D._emPosition.P3, ACalculationLotus3D._emPosition.P4);

            // Hole Error시  길이 측정 불가
            if (pnR[(int)ACalculationLotus3D._emPosition.P1] != 0)// || m_pchkUse[(int)ACalculationLotus3D._emPosition.P1].Checked == false)
            {
                m_stHoleLength.dShiftP1_P2 = 0;
                m_stHoleLength.dShiftP1_P3 = 0;
                m_stHoleLength.dShiftP1_P4 = 0;

                nFail++;
            }
            if (pnR[(int)ACalculationLotus3D._emPosition.P2] != 0)// || m_pchkUse[(int)ACalculationLotus3D._emPosition.P2].Checked == false)
            {
                m_stHoleLength.dShiftP1_P2 = 0;
                m_stHoleLength.dShiftP2_P3 = 0;
                m_stHoleLength.dShiftP2_P4 = 0;

                nFail++;
            }
            if (pnR[(int)ACalculationLotus3D._emPosition.P3] != 0)// || m_pchkUse[(int)ACalculationLotus3D._emPosition.P3].Checked == false)
            {
                m_stHoleLength.dShiftP1_P3 = 0;
                m_stHoleLength.dShiftP2_P3 = 0;
                m_stHoleLength.dShiftP3_P4 = 0;

                nFail++;
            }
            /* 2020.03.12
            if (pnR[(int)ACalculationLotus3D._emPosition.P4] != 0 || m_pchkUse[(int)ACalculationLotus3D._emPosition.P4].Checked == false)
            {
                m_stHoleLength.dShiftP1_P4 = 0;
                m_stHoleLength.dShiftP2_P4 = 0;
                m_stHoleLength.dShiftP3_P4 = 0;

                nFail++;
            }
            */

            dDiffP1_P2 = Math.Abs(m_stHoleLength.dP1_P2 - m_stHoleLength.dShiftP1_P2);
            dDiffP1_P3 = Math.Abs(m_stHoleLength.dP1_P3 - m_stHoleLength.dShiftP1_P3);
            // 2020.03.12
            //dDiffP1_P4 = Math.Abs(m_stHoleLength.dP1_P4 - m_stHoleLength.dShiftP1_P4);

            dDiffP2_P3 = Math.Abs(m_stHoleLength.dP2_P3 - m_stHoleLength.dShiftP2_P3);

            // 2020.03.12
            //dDiffP2_P4 = Math.Abs(m_stHoleLength.dP2_P4 - m_stHoleLength.dShiftP2_P4);
            //dDiffP3_P4 = Math.Abs(m_stHoleLength.dP3_P4 - m_stHoleLength.dShiftP3_P4);

            string strTmp;

            // 2011.08.20
            strTmp = m_stHoleLength.dShiftP1_P2.ToString("0.00") + "/기준:" + m_stHoleLength.dP1_P2.ToString("0.00") + " (편차:" + (m_stHoleLength.dShiftP1_P2 - m_stHoleLength.dP1_P2).ToString("0.00") + ")";
            lblP1_P2.Text = strTmp;
            strTmp = m_stHoleLength.dShiftP1_P3.ToString("0.00") + "/기준:" + m_stHoleLength.dP1_P3.ToString("0.00") + " (편차:" + (m_stHoleLength.dShiftP1_P3 - m_stHoleLength.dP1_P3).ToString("0.00") + ")";
            lblP1_P3.Text = strTmp;
            // 2020.03.12
            //strTmp = m_stHoleLength.dShiftP1_P4.ToString("0.00") + "/기준:" + m_stHoleLength.dP1_P4.ToString("0.00") + " (편차:" + (m_stHoleLength.dShiftP1_P4 - m_stHoleLength.dP1_P4).ToString("0.00") + ")";
            //lblP1_P4.Text = strTmp;

            strTmp = m_stHoleLength.dShiftP2_P3.ToString("0.00") + "/기준:" + m_stHoleLength.dP2_P3.ToString("0.00") + " (편차:" + (m_stHoleLength.dShiftP2_P3 - m_stHoleLength.dP2_P3).ToString("0.00") + ")";
            lblP2_P3.Text = strTmp;
            // 2020.03.12
            //strTmp = m_stHoleLength.dShiftP2_P4.ToString("0.00") + "/기준:" + m_stHoleLength.dP2_P4.ToString("0.00") + " (편차:" + (m_stHoleLength.dShiftP2_P4 - m_stHoleLength.dP2_P4).ToString("0.00") + ")";
            //lblP2_P4.Text = strTmp;
            //strTmp = m_stHoleLength.dShiftP3_P4.ToString("0.00") + "/기준:" + m_stHoleLength.dP3_P4.ToString("0.00") + " (편차:" + (m_stHoleLength.dShiftP3_P4 - m_stHoleLength.dP3_P4).ToString("0.00") + ")";
            //lblP3_P4.Text = strTmp;

            if (dDiffP1_P2 > m_aIniHoleLocation.m_dCheckLength)
                m_stHoleLength.bP1_P2 = false;
            else
                m_stHoleLength.bP1_P2 = true;

            if (dDiffP1_P3 > m_aIniHoleLocation.m_dCheckLength)
                m_stHoleLength.bP1_P3 = false;
            else
                m_stHoleLength.bP1_P3 = true;

            /* 2020.03.12
            if (dDiffP1_P4 > m_aIniHoleLocation.m_dCheckLength)
                m_stHoleLength.bP1_P4 = false;
            else
                m_stHoleLength.bP1_P4 = true;
            */

            if (dDiffP2_P3 > m_aIniHoleLocation.m_dCheckLength)
                m_stHoleLength.bP2_P3 = false;
            else
                m_stHoleLength.bP2_P3 = true;

            /* 2020.03.12
            if (dDiffP2_P4 > m_aIniHoleLocation.m_dCheckLength)
                m_stHoleLength.bP2_P4 = false;
            else
                m_stHoleLength.bP2_P4 = true;

            if (dDiffP3_P4 > m_aIniHoleLocation.m_dCheckLength)
                m_stHoleLength.bP3_P4 = false;
            else
                m_stHoleLength.bP3_P4 = true;

            int nCase = cmbCase.SelectedIndex;
            
            // 2011.08.07
            //--------------------------------------------------------------
            // Case Find
            double[] pdLen = new double[4];

            // Case1 - Lose P1
            if (m_stHoleLength.bP2_P3 == true &&
                m_stHoleLength.bP2_P4 == true &&
                m_stHoleLength.bP3_P4 == true)
            {
                pdLen[1] = dDiffP2_P3 + dDiffP2_P4 + dDiffP3_P4;
            }
            else
            {
                pdLen[1] = 99999;
            }
            // Case3 - Lose P2
            if (m_stHoleLength.bP1_P3 == true &&
                m_stHoleLength.bP1_P4 == true &&
                m_stHoleLength.bP3_P4 == true)
            {
                pdLen[3] = dDiffP1_P3 + dDiffP2_P4 + dDiffP3_P4;
            }
            else
            {
                pdLen[3] = 99999;
            }

            // Case2 - Lose P3
            if (m_stHoleLength.bP1_P2 == true &&
                m_stHoleLength.bP1_P4 == true &&
                m_stHoleLength.bP2_P4 == true)
            {
                pdLen[2] = dDiffP1_P2 + dDiffP1_P4 + dDiffP2_P4;
            }
            else
            {
                pdLen[2] = 99999;
            }
            // Case0 - Lose P4
            if (m_stHoleLength.bP1_P2 == true &&
                m_stHoleLength.bP1_P3 == true &&
                m_stHoleLength.bP2_P3 == true)
            {
                pdLen[0] = dDiffP1_P2 + dDiffP1_P3 + dDiffP2_P3;
            }
            else
            {
                pdLen[0] = 99999;
            }

            double dMinLen = 99999;
         
            if (pdLen[cmbCase.SelectedIndex] != 99999)
            {
                nCase = cmbCase.SelectedIndex;
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (pdLen[i] < dMinLen)
                    {
                        dMinLen = pdLen[i];
                        nCase = i;
                    }
                }
                if (dMinLen == 99999)
                {
                    nCase = -1;
                }
            }
            //-----------------------------
            lblCaseImg.ImageIndex = nCase + 1;
            */
            int nCase = 0;

            Color clrFalse, clrTrue, clrNotUse;
            clrFalse = Color.DarkGray;
            clrTrue = Color.LimeGreen;
            clrNotUse = Color.DarkGreen;
            // P1-P2
            if (m_stHoleLength.bP1_P2 == false)
                lblP1_P2.BackColor = clrFalse;
            else
            {
                if (nCase == 1 || nCase == 3)
                    lblP1_P2.BackColor = clrNotUse;
                else
                    lblP1_P2.BackColor = clrTrue;
            }

            // P1-P3
            if (m_stHoleLength.bP1_P3 == false)
                lblP1_P3.BackColor = clrFalse;
            else
            {
                if (nCase == 1 || nCase == 2)
                    lblP1_P3.BackColor = clrNotUse;
                else
                    lblP1_P3.BackColor = clrTrue;
            }

            /* 2020.03.12
            // P1-P4
            if (m_stHoleLength.bP1_P4 == false)
                lblP1_P4.BackColor = clrFalse;
            else
            {
                if (nCase == 0 || nCase == 1)
                    lblP1_P4.BackColor = clrNotUse;
                else
                    lblP1_P4.BackColor = clrTrue;
            }
            */

            // P2-P3
            if (m_stHoleLength.bP2_P3 == false)
                lblP2_P3.BackColor = clrFalse;
            else
            {
                if (nCase == 2 || nCase == 3)
                    lblP2_P3.BackColor = clrNotUse;
                else
                    lblP2_P3.BackColor = clrTrue;
            }

            /* 2020.03.12
            // P2-P4
            if (m_stHoleLength.bP2_P4 == false)
                lblP2_P4.BackColor = clrFalse;
            else
            {
                if (nCase == 0 || nCase == 3)
                    lblP2_P4.BackColor = clrNotUse;
                else
                    lblP2_P4.BackColor = clrTrue;
            }

            // P3-P4
            if (m_stHoleLength.bP3_P4 == false)
                lblP3_P4.BackColor = clrFalse;
            else
            {
                if (nCase == 0 || nCase == 2)
                    lblP3_P4.BackColor = clrNotUse;
                else
                    lblP3_P4.BackColor = clrTrue;
            }
            */

            // 2020.03.12
            //if (nFail >= 2)
            if (nFail >= 1)
            {
                nCase = -1;
            }

            //---------------------------
            return nCase;
        }

        private ASDef._emResult CheckCalcu()
        {
            int nBody = cmbType.SelectedIndex;
            int i;
            string strLog;

            m_stHoleLength.nCase = CalcuHoleLength(m_pnR_3D);
            
            CalcuShift(m_stHoleLength.nCase);
            

            DrawLocation();

            // 2020.03.12
            //DisplayCalucPoint();

            if (m_stHoleLength.nCase < 0 ||
                m_stShift.dX < AVisionProBuild.GetType(nBody).m_pstLimitLow[0].dX ||
                m_stShift.dX > AVisionProBuild.GetType(nBody).m_pstLimitHigh[0].dX ||
                m_stShift.dY < AVisionProBuild.GetType(nBody).m_pstLimitLow[0].dY ||
                m_stShift.dY > AVisionProBuild.GetType(nBody).m_pstLimitHigh[0].dY ||
                m_stShift.dZ < AVisionProBuild.GetType(nBody).m_pstLimitLow[0].dZ ||
                m_stShift.dZ > AVisionProBuild.GetType(nBody).m_pstLimitHigh[0].dZ ||
                // 2011.08.11
                m_stShift.dAX < AVisionProBuild.GetType(nBody).m_pstLimitLow[0].dAX ||
                m_stShift.dAX > AVisionProBuild.GetType(nBody).m_pstLimitHigh[0].dAX ||
                m_stShift.dAY < AVisionProBuild.GetType(nBody).m_pstLimitLow[0].dAY ||
                m_stShift.dAY > AVisionProBuild.GetType(nBody).m_pstLimitHigh[0].dAY ||
                m_stShift.dAZ < AVisionProBuild.GetType(nBody).m_pstLimitLow[0].dAZ ||
                m_stShift.dAZ > AVisionProBuild.GetType(nBody).m_pstLimitHigh[0].dAZ)
            {
                for (i = 0; i < ASDef._MAX_ROBOT; i++)
                {
                    SetRbtShift(i, 0, 0, 0, 0, m_stHoleLength.nCase);
                    SetRbtShift(i, 1, 0, 0, 0, m_stHoleLength.nCase);
                    SetRbtShift(i, 2, 0, 0, 0, m_stHoleLength.nCase);
                }

                DisplayResult(lblResult, ASDef._emResult.NG);
                
                return ASDef._emResult.NG;
            }
            else
            {
                // 2011.08.06 OK에만 Log 기록
                if (AVisionProBuild.Auto)
                {
                    string strTmp = "";
                    strLog = "";
                    // 2020.03.12 4->ASDef._3D_POSITION_COUNT
                    for (i = 0; i < ASDef._3D_POSITION_COUNT; i++)
                    {
                        strTmp = m_pstMeasure[i].stShift.dX.ToString("0.00") + " " +
                            m_pstMeasure[i].stShift.dY.ToString("0.00") + " " +
                            m_pstMeasure[i].stShift.dZ.ToString("0.00") + " ";
                        strLog += strTmp;
                    }
                    strTmp = m_stHoleLength.nCase.ToString();

                    strLog += strTmp;

                    AVisionProBuild.WriteLogFile(strLog);
                }

                /* 2020.03.12
                // 2014.11.20 ---------------
                // 로봇이 계산에서 PC가 계산으로 변경
                switch (m_stHoleLength.nCase)
                {
                    case 1:
                        m_pstMeasure[0].stShift.dX = Convert.ToDouble(m_plblX_Calcu[0].Text);
                        m_pstMeasure[0].stShift.dY = Convert.ToDouble(m_plblY_Calcu[0].Text);
                        m_pstMeasure[0].stShift.dZ = Convert.ToDouble(m_plblZ_Calcu[0].Text);
                        break;
                    case 2:
                        m_pstMeasure[2].stShift.dX = Convert.ToDouble(m_plblX_Calcu[2].Text);
                        m_pstMeasure[2].stShift.dY = Convert.ToDouble(m_plblY_Calcu[2].Text);
                        m_pstMeasure[2].stShift.dZ = Convert.ToDouble(m_plblZ_Calcu[2].Text);
                        break;
                    case 3:
                        m_pstMeasure[1].stShift.dX = Convert.ToDouble(m_plblX_Calcu[1].Text);
                        m_pstMeasure[1].stShift.dY = Convert.ToDouble(m_plblY_Calcu[1].Text);
                        m_pstMeasure[1].stShift.dZ = Convert.ToDouble(m_plblZ_Calcu[1].Text);
                        break;
                }
                m_stHoleLength.nCase = 0;
                //----------------------------
                */
                                
                for (i = 0; i < ASDef._MAX_ROBOT; i++)
                {
                    switch (m_stHoleLength.nCase)
                    {
                        case 0:
                            {
                                // SHIFT 1,2,3
                                SetRbtShift(i, 0,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P2].stShift.dX,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P2].stShift.dY,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P2].stShift.dZ,
                                    m_stHoleLength.nCase);
                                SetRbtShift(i, 1,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P1].stShift.dX,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P1].stShift.dY,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P1].stShift.dZ,
                                    m_stHoleLength.nCase);
                                SetRbtShift(i, 2,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P3].stShift.dX,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P3].stShift.dY,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P3].stShift.dZ,
                                    m_stHoleLength.nCase);
                            }
                            break;
                        /* 2020.03.12
                        case 1:
                            {
                                SetRbtShift(i, 0,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P3].stShift.dX,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P3].stShift.dY,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P3].stShift.dZ,
                                    m_stHoleLength.nCase);
                                // 2011.08.16 4->2
                                SetRbtShift(i, 1,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P2].stShift.dX,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P2].stShift.dY,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P2].stShift.dZ,
                                    m_stHoleLength.nCase);
                                // 2011.08.16 2->4
                                SetRbtShift(i, 2,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P4].stShift.dX,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P4].stShift.dY,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P4].stShift.dZ,
                                    m_stHoleLength.nCase);
                            }
                            break;
                        case 2:
                            {
                                SetRbtShift(i, 0,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P1].stShift.dX,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P1].stShift.dY,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P1].stShift.dZ,
                                    m_stHoleLength.nCase);
                                // 2011.08.16 2->4
                                SetRbtShift(i, 1,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P4].stShift.dX,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P4].stShift.dY,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P4].stShift.dZ,
                                    m_stHoleLength.nCase);
                                // 2011.08.16 4->2
                                SetRbtShift(i, 2,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P2].stShift.dX,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P2].stShift.dY,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P2].stShift.dZ,
                                    m_stHoleLength.nCase);
                            }
                            break;
                        case 3:
                            {
                                SetRbtShift(i, 0,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P4].stShift.dX,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P4].stShift.dY,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P4].stShift.dZ,
                                    m_stHoleLength.nCase);
                                SetRbtShift(i, 1,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P3].stShift.dX,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P3].stShift.dY,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P3].stShift.dZ,
                                    m_stHoleLength.nCase);
                                SetRbtShift(i, 2,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P1].stShift.dX,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P1].stShift.dY,
                                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P1].stShift.dZ,
                                    m_stHoleLength.nCase);
                            }
                            break;
                        */
                    }

                }
                
                DisplayResult(lblResult, ASDef._emResult.OK);

                return ASDef._emResult.OK;
            }

        }

        /* 2020.03.12
        // 2011.09.29
        private void DisplayCalucPoint()
        {
            int i;
            for (i = 0; i < 4; i++)
            {
                m_plblX_Calcu[i].Text = "";
                m_plblY_Calcu[i].Text = "";
                m_plblZ_Calcu[i].Text = "";
            }
            ASDef._stXYZ stAuto;
            // case 0
            if ((m_pnR_3D[0] == 0 && m_pchkUse[0].Checked == true) &&
                (m_pnR_3D[1] == 0 && m_pchkUse[1].Checked == true) &&
                (m_pnR_3D[2] == 0 && m_pchkUse[2].Checked == true))
            {
                stAuto = default(ASDef._stXYZ);
                FindLost1Point(3, ref stAuto);
                m_plblX_Calcu[3].Text = stAuto.dX.ToString("0.00");
                m_plblY_Calcu[3].Text = stAuto.dY.ToString("0.00");
                m_plblZ_Calcu[3].Text = stAuto.dZ.ToString("0.00");
            }
            // case 1
            if ((m_pnR_3D[1] == 0 && m_pchkUse[1].Checked == true) &&
                (m_pnR_3D[2] == 0 && m_pchkUse[2].Checked == true) &&
                (m_pnR_3D[3] == 0 && m_pchkUse[3].Checked == true))
            {
                stAuto = default(ASDef._stXYZ);
                FindLost1Point(0, ref stAuto);
                m_plblX_Calcu[0].Text = stAuto.dX.ToString("0.00");
                m_plblY_Calcu[0].Text = stAuto.dY.ToString("0.00");
                m_plblZ_Calcu[0].Text = stAuto.dZ.ToString("0.00");
            }
            // case 2
            if ((m_pnR_3D[0] == 0 && m_pchkUse[0].Checked == true) &&
                (m_pnR_3D[1] == 0 && m_pchkUse[1].Checked == true) &&
                (m_pnR_3D[3] == 0 && m_pchkUse[3].Checked == true))
            {
                stAuto = default(ASDef._stXYZ);
                FindLost1Point(2, ref stAuto);
                m_plblX_Calcu[2].Text = stAuto.dX.ToString("0.00");
                m_plblY_Calcu[2].Text = stAuto.dY.ToString("0.00");
                m_plblZ_Calcu[2].Text = stAuto.dZ.ToString("0.00");
            }
            // case 3
            if ((m_pnR_3D[0] == 0 && m_pchkUse[0].Checked == true) &&
                (m_pnR_3D[2] == 0 && m_pchkUse[2].Checked == true) &&
                (m_pnR_3D[3] == 0 && m_pchkUse[3].Checked == true))
            {
                stAuto = default(ASDef._stXYZ);
                FindLost1Point(1, ref stAuto);
                m_plblX_Calcu[1].Text = stAuto.dX.ToString("0.00");
                m_plblY_Calcu[1].Text = stAuto.dY.ToString("0.00");
                m_plblZ_Calcu[1].Text = stAuto.dZ.ToString("0.00");
            }
        }
        */

        private void DisplayResult3D(int nPosition, ASDef._emResult emResult)
        {

            m_plblResult[nPosition].BackColor = ASDef.pclrResult[(int)emResult + 2];
            // 2015.11.13
            if (emResult == ASDef._emResult.NO)
                m_plblResult[nPosition].Text = "";
            else
                m_plblResult[nPosition].Text = emResult.ToString();

            if (emResult != ASDef._emResult.NO)
            {
                m_plblX_Calib[nPosition].Text = m_pstMeasure[nPosition].stCalibXYZ.dX.ToString("0.00");
                m_plblY_Calib[nPosition].Text = m_pstMeasure[nPosition].stCalibXYZ.dY.ToString("0.00");
                m_plblZ_Calib[nPosition].Text = m_pstMeasure[nPosition].stCalibXYZ.dZ.ToString("0.00");

                m_plblX_3D[nPosition].Text = m_pstMeasure[nPosition].stShift.dX.ToString("0.00");
                m_plblY_3D[nPosition].Text = m_pstMeasure[nPosition].stShift.dY.ToString("0.00");
                m_plblZ_3D[nPosition].Text = m_pstMeasure[nPosition].stShift.dZ.ToString("0.00");

                // 2011.08.15
                m_plblX_CalibSub[nPosition].Text = (m_pstMeasure[nPosition].stCalibXYZ.dX - m_aIniPartOffset.m_pstCalibSubXYZ[nPosition].dX).ToString("0.00");
                m_plblY_CalibSub[nPosition].Text = (m_pstMeasure[nPosition].stCalibXYZ.dY - m_aIniPartOffset.m_pstCalibSubXYZ[nPosition].dY).ToString("0.00");
                m_plblZ_CalibSub[nPosition].Text = (m_pstMeasure[nPosition].stCalibXYZ.dZ - m_aIniPartOffset.m_pstCalibSubXYZ[nPosition].dZ).ToString("0.00");
            }
            else
            {
                m_plblX_Calib[nPosition].Text = "";
                m_plblY_Calib[nPosition].Text = "";
                m_plblZ_Calib[nPosition].Text = "";

                m_plblX_3D[nPosition].Text = "";
                m_plblY_3D[nPosition].Text = "";
                m_plblZ_3D[nPosition].Text = "";

                // 2011.08.15
                m_plblX_CalibSub[nPosition].Text = "";
                m_plblY_CalibSub[nPosition].Text = "";
                m_plblZ_CalibSub[nPosition].Text = "";
            }

            m_plblX_Calib[nPosition].BackColor = ASDef.pclrResult[(int)emResult + 2];
            m_plblY_Calib[nPosition].BackColor = ASDef.pclrResult[(int)emResult + 2];
            m_plblZ_Calib[nPosition].BackColor = ASDef.pclrResult[(int)emResult + 2];

            m_plblX_3D[nPosition].BackColor = ASDef.pclrResult[(int)emResult + 2];
            m_plblY_3D[nPosition].BackColor = ASDef.pclrResult[(int)emResult + 2];
            m_plblZ_3D[nPosition].BackColor = ASDef.pclrResult[(int)emResult + 2];
        }
        
        private void DrawLocation()
        {
            int nBody = cmbType.SelectedIndex;
            double dPP = 3, dOffsetX = 0, dOffsetY = 600, dDD = 5;
            int nDirect;
            StringBuilder sb = new StringBuilder(100);

            AUtil.GetPrivateProfileString("DrawLocation", "PP", "3", sb, 100, ASDef._INI_FILE);
            dPP = Convert.ToDouble(sb.ToString());
            AUtil.GetPrivateProfileString("DrawLocation", "OffsetX", "0", sb, 100, ASDef._INI_FILE);
            dOffsetX = Convert.ToDouble(sb.ToString());
            AUtil.GetPrivateProfileString("DrawLocation", "OffsetY", "0", sb, 100, ASDef._INI_FILE);
            dOffsetY = Convert.ToDouble(sb.ToString());
            AUtil.GetPrivateProfileString("DrawLocation", "DD", "5", sb, 100, ASDef._INI_FILE);
            dDD = Convert.ToDouble(sb.ToString());

            AUtil.GetPrivateProfileString("DrawLocation", "Direct", "1", sb, 100, ASDef._INI_FILE);
            nDirect = Convert.ToInt32(sb.ToString());

            ADisplay aDisplay = AVisionProBuild.GetDisplay(1);

            int i;
            double[] pdX = new double[4];
            double[] pdY = new double[4];

            // 2016.11.24
            /*
            // 2011.07.30
            double dMaxHeight = aDisplay.Display.PanYMax / 2;
            double dMaxWidth = aDisplay.Display.PanXMax / 2;
            */
            for (i = 0; i < ASDef._3D_POSITION_COUNT; i++)
            {
                switch (nDirect)
                {
                    // 2016.11.24
                    /*
                    case 1:
                        pdX[i] = m_aIniHoleLocation.m_pstXYZ[i].dX / dPP + dOffsetX;
                        pdY[i] = -m_aIniHoleLocation.m_pstXYZ[i].dY / dPP + dOffsetY;
                        break;
                    case 2:
                        pdX[i] = m_aIniHoleLocation.m_pstXYZ[i].dX / dPP + dOffsetX;
                        pdY[i] = dMaxHeight + m_aIniHoleLocation.m_pstXYZ[i].dY / dPP + dOffsetY;
                        break;
                    case 3:
                        pdX[i] = dMaxWidth - m_aIniHoleLocation.m_pstXYZ[i].dX / dPP + dOffsetX;
                        pdY[i] = -m_aIniHoleLocation.m_pstXYZ[i].dY / dPP + dOffsetY;
                        break;
                    case 4:
                        pdX[i] = dMaxWidth - m_aIniHoleLocation.m_pstXYZ[i].dX / dPP + dOffsetX;
                        pdY[i] = dMaxHeight + m_aIniHoleLocation.m_pstXYZ[i].dY / dPP + dOffsetY;
                        break;
                    case -1:
                        pdY[i] = m_aIniHoleLocation.m_pstXYZ[i].dX / dPP + dOffsetX;
                        pdX[i] = -m_aIniHoleLocation.m_pstXYZ[i].dY / dPP + dOffsetY;
                        break;
                    case -2:
                        pdY[i] = m_aIniHoleLocation.m_pstXYZ[i].dX / dPP + dOffsetX;
                        pdX[i] = dMaxHeight + m_aIniHoleLocation.m_pstXYZ[i].dY / dPP + dOffsetY;
                        break;
                    case -3:
                        pdY[i] = dMaxWidth - m_aIniHoleLocation.m_pstXYZ[i].dX / dPP + dOffsetX;
                        pdX[i] = -m_aIniHoleLocation.m_pstXYZ[i].dY / dPP + dOffsetY;
                        break;
                    case -4:
                        pdY[i] = dMaxWidth - m_aIniHoleLocation.m_pstXYZ[i].dX / dPP + dOffsetX;
                        pdX[i] = dMaxHeight + m_aIniHoleLocation.m_pstXYZ[i].dY / dPP + dOffsetY;
                        break;
                    */
                    case 1:
                        pdX[i] = m_aIniHoleLocation.m_pstXYZ[i].dX / dPP + dOffsetX;
                        pdY[i] = -m_aIniHoleLocation.m_pstXYZ[i].dY / dPP + dOffsetY;
                        break;
                    case 2:
                        pdX[i] = m_aIniHoleLocation.m_pstXYZ[i].dX / dPP + dOffsetX;
                        pdY[i] = m_aIniHoleLocation.m_pstXYZ[i].dY / dPP + dOffsetY;
                        break;
                    case 3:
                        pdX[i] = -m_aIniHoleLocation.m_pstXYZ[i].dX / dPP + dOffsetX;
                        pdY[i] = -m_aIniHoleLocation.m_pstXYZ[i].dY / dPP + dOffsetY;
                        break;
                    case 4:
                        pdX[i] = -m_aIniHoleLocation.m_pstXYZ[i].dX / dPP + dOffsetX;
                        pdY[i] = m_aIniHoleLocation.m_pstXYZ[i].dY / dPP + dOffsetY;
                        break;
                    case -1:
                        pdY[i] = m_aIniHoleLocation.m_pstXYZ[i].dX / dPP + dOffsetY;
                        pdX[i] = -m_aIniHoleLocation.m_pstXYZ[i].dY / dPP + dOffsetX;
                        break;
                    case -2:
                        pdY[i] = m_aIniHoleLocation.m_pstXYZ[i].dX / dPP + dOffsetY;
                        pdX[i] = m_aIniHoleLocation.m_pstXYZ[i].dY / dPP + dOffsetX;
                        break;
                    case -3:
                        pdY[i] = -m_aIniHoleLocation.m_pstXYZ[i].dX / dPP + dOffsetY;
                        pdX[i] = -m_aIniHoleLocation.m_pstXYZ[i].dY / dPP + dOffsetX;
                        break;
                    case -4:
                        pdY[i] = -m_aIniHoleLocation.m_pstXYZ[i].dX / dPP + dOffsetY;
                        pdX[i] = m_aIniHoleLocation.m_pstXYZ[i].dY / dPP + dOffsetX;
                        break;
                }


            }

            // 2015.11.10
            //if (m_pchkUse[0].Checked && m_pchkUse[1].Checked)
                aDisplay.AddLine(pdX[0], pdY[0], pdX[1], pdY[1], CogColorConstants.Orange);
            //if (m_pchkUse[0].Checked && m_pchkUse[2].Checked)
                aDisplay.AddLine(pdX[0], pdY[0], pdX[2], pdY[2], CogColorConstants.Orange);
            // 2020.03.12
            //if (m_pchkUse[0].Checked && m_pchkUse[3].Checked)
            //    aDisplay.AddLine(pdX[0], pdY[0], pdX[3], pdY[3], CogColorConstants.Orange);

            //if (m_pchkUse[1].Checked && m_pchkUse[2].Checked)
                aDisplay.AddLine(pdX[1], pdY[1], pdX[2], pdY[2], CogColorConstants.Orange);

            // 2020.03.12
            //if (m_pchkUse[1].Checked && m_pchkUse[3].Checked)
            //    aDisplay.AddLine(pdX[1], pdY[1], pdX[3], pdY[3], CogColorConstants.Orange);
            //if (m_pchkUse[2].Checked && m_pchkUse[3].Checked)
            //    aDisplay.AddLine(pdX[2], pdY[2], pdX[3], pdY[3], CogColorConstants.Orange);

            for (i = 0; i < ASDef._3D_POSITION_COUNT; i++)
            {
                switch (nDirect)
                {
                    // 2016.11.24
                    /*
                    case 1:
                        pdX[i] = (m_aIniHoleLocation.m_pstXYZ[i].dX + m_pstMeasure[i].stShift.dX * dDD) / dPP + dOffsetX;
                        pdY[i] = -(m_aIniHoleLocation.m_pstXYZ[i].dY + m_pstMeasure[i].stShift.dY * dDD) / dPP + dOffsetY;
                        break;
                    case 2:
                        pdX[i] = (m_aIniHoleLocation.m_pstXYZ[i].dX + m_pstMeasure[i].stShift.dX * dDD) / dPP + dOffsetX;
                        pdY[i] = dMaxHeight + (m_aIniHoleLocation.m_pstXYZ[i].dY + m_pstMeasure[i].stShift.dY * dDD) / dPP + dOffsetY;
                        break;
                    case 3:
                        pdX[i] = dMaxWidth - (m_aIniHoleLocation.m_pstXYZ[i].dX + m_pstMeasure[i].stShift.dX * dDD) / dPP + dOffsetX;
                        pdY[i] = -(m_aIniHoleLocation.m_pstXYZ[i].dY + m_pstMeasure[i].stShift.dY * dDD) / dPP + dOffsetY;
                        break;
                    case 4:
                        pdX[i] = dMaxWidth - (m_aIniHoleLocation.m_pstXYZ[i].dX + m_pstMeasure[i].stShift.dX * dDD) / dPP + dOffsetX;
                        pdY[i] = dMaxHeight + (m_aIniHoleLocation.m_pstXYZ[i].dY + m_pstMeasure[i].stShift.dY * dDD) / dPP + dOffsetY;
                        break;
                    case -1:
                        pdY[i] = (m_aIniHoleLocation.m_pstXYZ[i].dX + m_pstMeasure[i].stShift.dX * dDD) / dPP + dOffsetX;
                        pdX[i] = -(m_aIniHoleLocation.m_pstXYZ[i].dY + m_pstMeasure[i].stShift.dY * dDD) / dPP + dOffsetY;
                        break;
                    case -2:
                        pdY[i] = (m_aIniHoleLocation.m_pstXYZ[i].dX + m_pstMeasure[i].stShift.dX * dDD) / dPP + dOffsetX;
                        pdX[i] = dMaxHeight + (m_aIniHoleLocation.m_pstXYZ[i].dY + m_pstMeasure[i].stShift.dY * dDD) / dPP + dOffsetY;
                        break;
                    case -3:
                        pdY[i] = dMaxWidth - (m_aIniHoleLocation.m_pstXYZ[i].dX + m_pstMeasure[i].stShift.dX * dDD) / dPP + dOffsetX;
                        pdX[i] = -(m_aIniHoleLocation.m_pstXYZ[i].dY + m_pstMeasure[i].stShift.dY * dDD) / dPP + dOffsetY;
                        break;
                    case -4:
                        pdY[i] = dMaxWidth - (m_aIniHoleLocation.m_pstXYZ[i].dX + m_pstMeasure[i].stShift.dX * dDD) / dPP + dOffsetX;
                        pdX[i] = dMaxHeight + (m_aIniHoleLocation.m_pstXYZ[i].dY + m_pstMeasure[i].stShift.dY * dDD) / dPP + dOffsetY;
                        break;
                    */
                    case 1:
                        pdX[i] = (m_aIniHoleLocation.m_pstXYZ[i].dX + m_pstMeasure[i].stShift.dX * dDD) / dPP + dOffsetX;
                        pdY[i] = -(m_aIniHoleLocation.m_pstXYZ[i].dY + m_pstMeasure[i].stShift.dY * dDD) / dPP + dOffsetY;
                        break;
                    case 2:
                        pdX[i] = (m_aIniHoleLocation.m_pstXYZ[i].dX + m_pstMeasure[i].stShift.dX * dDD) / dPP + dOffsetX;
                        pdY[i] = (m_aIniHoleLocation.m_pstXYZ[i].dY + m_pstMeasure[i].stShift.dY * dDD) / dPP + dOffsetY;
                        break;
                    case 3:
                        pdX[i] = -(m_aIniHoleLocation.m_pstXYZ[i].dX + m_pstMeasure[i].stShift.dX * dDD) / dPP + dOffsetX;
                        pdY[i] = -(m_aIniHoleLocation.m_pstXYZ[i].dY + m_pstMeasure[i].stShift.dY * dDD) / dPP + dOffsetY;
                        break;
                    case 4:
                        pdX[i] = -(m_aIniHoleLocation.m_pstXYZ[i].dX + m_pstMeasure[i].stShift.dX * dDD) / dPP + dOffsetX;
                        pdY[i] = (m_aIniHoleLocation.m_pstXYZ[i].dY + m_pstMeasure[i].stShift.dY * dDD) / dPP + dOffsetY;
                        break;
                    case -1:
                        pdY[i] = (m_aIniHoleLocation.m_pstXYZ[i].dX + m_pstMeasure[i].stShift.dX * dDD) / dPP + dOffsetY;
                        pdX[i] = -(m_aIniHoleLocation.m_pstXYZ[i].dY + m_pstMeasure[i].stShift.dY * dDD) / dPP + dOffsetX;
                        break;
                    case -2:
                        pdY[i] = (m_aIniHoleLocation.m_pstXYZ[i].dX + m_pstMeasure[i].stShift.dX * dDD) / dPP + dOffsetY;
                        pdX[i] = (m_aIniHoleLocation.m_pstXYZ[i].dY + m_pstMeasure[i].stShift.dY * dDD) / dPP + dOffsetX;
                        break;
                    case -3:
                        pdY[i] = -(m_aIniHoleLocation.m_pstXYZ[i].dX + m_pstMeasure[i].stShift.dX * dDD) / dPP + dOffsetY;
                        pdX[i] = -(m_aIniHoleLocation.m_pstXYZ[i].dY + m_pstMeasure[i].stShift.dY * dDD) / dPP + dOffsetX;
                        break;
                    case -4:
                        pdY[i] = -(m_aIniHoleLocation.m_pstXYZ[i].dX + m_pstMeasure[i].stShift.dX * dDD) / dPP + dOffsetY;
                        pdX[i] = (m_aIniHoleLocation.m_pstXYZ[i].dY + m_pstMeasure[i].stShift.dY * dDD) / dPP + dOffsetX;
                        break;
                }
            }
            if (m_stHoleLength.dShiftP1_P2 > 0)
                aDisplay.AddLine(pdX[0], pdY[0], pdX[1], pdY[1], CogColorConstants.Yellow);
            if (m_stHoleLength.dShiftP1_P3 > 0)
                aDisplay.AddLine(pdX[0], pdY[0], pdX[2], pdY[2], CogColorConstants.Yellow);
            // 2020.03.12
            //if (m_stHoleLength.dShiftP1_P4 > 0)
            //    aDisplay.AddLine(pdX[0], pdY[0], pdX[3], pdY[3], CogColorConstants.Yellow);

            if (m_stHoleLength.dShiftP2_P3 > 0)
                aDisplay.AddLine(pdX[1], pdY[1], pdX[2], pdY[2], CogColorConstants.Yellow);

            // 2020.03.12
            //if (m_stHoleLength.dShiftP2_P4 > 0)
            //    aDisplay.AddLine(pdX[1], pdY[1], pdX[3], pdY[3], CogColorConstants.Yellow);
            //if (m_stHoleLength.dShiftP3_P4 > 0)
            //    aDisplay.AddLine(pdX[2], pdY[2], pdX[3], pdY[3], CogColorConstants.Yellow);
        }

        /* 2020.03.12
        // 2011.08.11
        public void FindLost1Point(int nPosition, ref ASDef._stXYZ st1Point)
        {
            ASDef._stXYZ[] pstSource = new ASDef._stXYZ[4];
            ASDef._stXYZ[] pstMove = new ASDef._stXYZ[4];
            ASDef._stXYZ stLost1Point;
            stLost1Point = default(ASDef._stXYZ);

            int i;
            for (i = 0; i < 4; i++)
            {
                GetHoleLocation(i, ref pstSource[i]);
                GetShift(i, ref pstMove[i]);
                pstMove[i].dX = pstSource[i].dX + pstMove[i].dX;
                pstMove[i].dY = pstSource[i].dY + pstMove[i].dY;
                pstMove[i].dZ = pstSource[i].dZ + pstMove[i].dZ;
            }
            
            switch (nPosition)
            {
                case 0:
                    ACalculationLotus3D.FindLost1Point(pstSource, pstMove, ref stLost1Point, 1);
                    break;
                case 1:
                    ACalculationLotus3D.FindLost1Point(pstSource, pstMove, ref stLost1Point, 3);
                    break;
                case 2:
                    ACalculationLotus3D.FindLost1Point(pstSource, pstMove, ref stLost1Point, 2);
                    break;
                case 3:
                    ACalculationLotus3D.FindLost1Point(pstSource, pstMove, ref stLost1Point, 0);
                    break;
            }

            st1Point.dX = stLost1Point.dX - pstSource[nPosition].dX;
            st1Point.dY = stLost1Point.dY - pstSource[nPosition].dY;
            st1Point.dZ = stLost1Point.dZ - pstSource[nPosition].dZ;

        }
        */

        // 2011.08.08
        public void GetShift(int nPosition, ref ASDef._stXYZ stShift)
        {
            stShift = m_pstMeasure[nPosition].stShift;
        }

        // 2011.08.08
        public void GetHoleLocation(int nPosition, ref ASDef._stXYZ stHole)
        {
            stHole = m_aIniHoleLocation.m_pstXYZ[nPosition];
        }
                
        public string GetCalibDir(int nPosition)
        {
            int nType = cmbType.SelectedIndex;
            string strDir = "";
            switch (nPosition)
            {
                case (int)ACalculationLotus3D._emPosition.P1:
                    strDir = ASDef._INI_PATH + "\\CalibP1";
                    break;
                case (int)ACalculationLotus3D._emPosition.P2:
                    strDir = ASDef._INI_PATH + "\\CalibP2";
                    break;
                case (int)ACalculationLotus3D._emPosition.P3:
                    strDir = ASDef._INI_PATH + "\\CalibP3";
                    break;
                case (int)ACalculationLotus3D._emPosition.P4:
                    strDir = ASDef._INI_PATH + "\\CalibP4";
                    break;
            }
            if (!Directory.Exists(strDir))
            {
                Directory.CreateDirectory(strDir);
            }

            return strDir;
        }

        // 2015.10.26
        /*
        public void GetCalibXYZ(ref int x, ref int y, ref int z)
        {            
	        x = m_nCalibX;
	        y = m_nCalibY;
	        z = m_nCalibZ;
        }
        */

        double GetLength(int nCase, ACalculationLotus3D._emPosition emS, ACalculationLotus3D._emPosition emE)
        {
            int nBody = cmbType.SelectedIndex;
	        double dX, dY, dZ;
                        
	        if (nCase == 0)
	        {
                dX = (m_aIniHoleLocation.m_pstXYZ[(int)emS].dX)
                    - (m_aIniHoleLocation.m_pstXYZ[(int)emE].dX);
                dY = (m_aIniHoleLocation.m_pstXYZ[(int)emS].dY)
                    - (m_aIniHoleLocation.m_pstXYZ[(int)emE].dY);
                dZ = (m_aIniHoleLocation.m_pstXYZ[(int)emS].dZ)
                    - (m_aIniHoleLocation.m_pstXYZ[(int)emE].dZ);
	        }
	        else
	        {
                dX = (m_aIniHoleLocation.m_pstXYZ[(int)emS].dX + m_pstMeasure[(int)emS].stShift.dX)
                    - (m_aIniHoleLocation.m_pstXYZ[(int)emE].dX + m_pstMeasure[(int)emE].stShift.dX);
                dY = (m_aIniHoleLocation.m_pstXYZ[(int)emS].dY + m_pstMeasure[(int)emS].stShift.dY)
                    - (m_aIniHoleLocation.m_pstXYZ[(int)emE].dY + m_pstMeasure[(int)emE].stShift.dY);
                dZ = (m_aIniHoleLocation.m_pstXYZ[(int)emS].dZ + m_pstMeasure[(int)emS].stShift.dZ)
                    - (m_aIniHoleLocation.m_pstXYZ[(int)emE].dZ + m_pstMeasure[(int)emE].stShift.dZ);		        
	        }
	        return Math.Sqrt(
		        Math.Pow(dX, 2) +
                Math.Pow(dY, 2) +
                Math.Pow(dZ, 2));
        }
                
        void GetMeasure(ACalculationLotus3D._emPosition emPosition, ref ACalculationLotus3D._stMeasure stMeasure)
        {
            stMeasure = m_pstMeasure[(int)emPosition];
        }

        // 2014.11.18
        private void LoadImage3D(string[] pstrFName)
        {
            int i;

            cmbLoadImg.SelectedIndex = 1;

            if (pstrFName.Length > 1)
            {
                string strDateTime = pstrFName[pstrFName.Length - 1].Substring(0, 17);

                AddLstBxMessage("Image:" + strDateTime);

                int nCount;
                string strFName = "";
                // 2020.03.12 8->ASDef._3D_POINT_COUNT
                for (i = 0; i < ASDef._3D_POINT_COUNT; i++)
                {
                    nCount = AVisionProBuild.FindResultFName(cmbType.SelectedIndex, i, strDateTime, ref strFName);
                    APoint aPoint = AVisionProBuild.GetPoint(cmbType.SelectedIndex, i);
                    if (nCount > 0)
                        aPoint.m_strLoadFileName = strFName;
                    else
                        aPoint.m_strLoadFileName = null;
                }
            }
            else
            {
                AddLstBxMessage("Image:null");

                // 2020.03.12 8->ASDef._3D_POINT_COUNT
                for (i = 0; i < ASDef._3D_POINT_COUNT; i++)
                {
                    APoint aPoint = AVisionProBuild.GetPoint(cmbType.SelectedIndex, i);
                    aPoint.m_strLoadFileName = null;
                }
            }
        }

        private void LiveOff()
        {
            chkLiveP1.Checked = false;
            chkLiveP2.Checked = false;
            chkLiveP3.Checked = false;
            // 2020.03.12
            //chkLiveP4.Checked = false;

            chkLiveSearchP1.Checked = false;
            chkLiveSearchP2.Checked = false;
            chkLiveSearchP3.Checked = false;
            // 2020.03.12
            //chkLiveSearchP4.Checked = false;

        }

        private void LightOnOff3D(int nType, int nPosition, int nLR, bool bOnOff)
        {
            AIniLight aIni = new AIniLight(nType, nPosition * 2 + nLR);
            aIni.Read();
            int nIndex = Convert.ToInt32(aIni.m_strIndex);
            if (nIndex != -1 && nLR == 0)
            {
                int nChannel = Convert.ToInt32(aIni.m_strChannel);

                m_pACommLightControl[nIndex].SendToOnOff(nChannel, bOnOff);
                AUtil.Delay(300);
            }
        }

        /* 2020.03.12
        public void RunAutoOffsetFind(ref ASDef._stXYZ[] pstXYZ, double[] pdRange, double dMm)
        {
            int i;
            ASDef._stXYZ[] pstSourceShift = new ASDef._stXYZ[ASDef._3D_POSITION_COUNT];
            
            for(i=0;i<ASDef._3D_POSITION_COUNT;i++)
            {
                pstXYZ[i] = default(ASDef._stXYZ);
                pstSourceShift[i] = m_pstMeasure[i].stShift;
            }
            
            // Hole Error시  길이 측정 불가
            if (m_pnR_3D[(int)ACalculationLotus3D._emPosition.P1] != 0 || m_pchkUse[(int)ACalculationLotus3D._emPosition.P1].Checked == false ||
                m_pnR_3D[(int)ACalculationLotus3D._emPosition.P2] != 0 || m_pchkUse[(int)ACalculationLotus3D._emPosition.P2].Checked == false ||
                m_pnR_3D[(int)ACalculationLotus3D._emPosition.P3] != 0 || m_pchkUse[(int)ACalculationLotus3D._emPosition.P3].Checked == false ||
                m_pnR_3D[(int)ACalculationLotus3D._emPosition.P4] != 0 || m_pchkUse[(int)ACalculationLotus3D._emPosition.P4].Checked == false)
            {
                return;
            }
        	
            double dDiffP1_P2;
            double dDiffP1_P3;
            double dDiffP1_P4;
            double dDiffP2_P3;
            double dDiffP2_P4;
            double dDiffP3_P4;

            double dLen, dMinLen= 100;

            double[] x = new double[4];
            double[] y = new double[4];
            double[] z = new double[4];
                
            double[] pdL = new double[2];

            dMm = Math.Abs(dMm);
        	
            // P1
            for(x[(int)ACalculationLotus3D._emPosition.P1]=-pdRange[(int)ACalculationLotus3D._emPosition.P1];x[(int)ACalculationLotus3D._emPosition.P1]<=pdRange[(int)ACalculationLotus3D._emPosition.P1];x[(int)ACalculationLotus3D._emPosition.P1]+=dMm)
            {
                m_pstMeasure[(int)ACalculationLotus3D._emPosition.P1].stShift.dX = pstSourceShift[(int)ACalculationLotus3D._emPosition.P1].dX + x[(int)ACalculationLotus3D._emPosition.P1];
        		
            for(y[(int)ACalculationLotus3D._emPosition.P1]=-pdRange[(int)ACalculationLotus3D._emPosition.P1];y[(int)ACalculationLotus3D._emPosition.P1]<=pdRange[(int)ACalculationLotus3D._emPosition.P1];y[(int)ACalculationLotus3D._emPosition.P1]+=dMm)
            {
                m_pstMeasure[(int)ACalculationLotus3D._emPosition.P1].stShift.dY = pstSourceShift[(int)ACalculationLotus3D._emPosition.P1].dY + y[(int)ACalculationLotus3D._emPosition.P1];
        		
            for(z[(int)ACalculationLotus3D._emPosition.P1]=-pdRange[(int)ACalculationLotus3D._emPosition.P1];z[(int)ACalculationLotus3D._emPosition.P1]<=pdRange[(int)ACalculationLotus3D._emPosition.P1];z[(int)ACalculationLotus3D._emPosition.P1]+=dMm)
            {
                m_pstMeasure[(int)ACalculationLotus3D._emPosition.P1].stShift.dZ = pstSourceShift[(int)ACalculationLotus3D._emPosition.P1].dZ + z[(int)ACalculationLotus3D._emPosition.P1];

                // P2
                for(x[(int)ACalculationLotus3D._emPosition.P2]=-pdRange[(int)ACalculationLotus3D._emPosition.P2];x[(int)ACalculationLotus3D._emPosition.P2]<=pdRange[(int)ACalculationLotus3D._emPosition.P2];x[(int)ACalculationLotus3D._emPosition.P2]+=dMm)
                {
                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P2].stShift.dX = pstSourceShift[(int)ACalculationLotus3D._emPosition.P2].dX + x[(int)ACalculationLotus3D._emPosition.P2];
                    pdL[0] = GetLength(0, ACalculationLotus3D._emPosition.P1, ACalculationLotus3D._emPosition.P2);
                    pdL[1] = GetLength(1, ACalculationLotus3D._emPosition.P1, ACalculationLotus3D._emPosition.P2);
                    dDiffP1_P2 = Math.Abs(pdL[0] - pdL[1]);
                    if (dDiffP1_P2 > m_aIniHoleLocation.m_dCheckLength)
                        continue;
        			
                for(y[(int)ACalculationLotus3D._emPosition.P2]=-pdRange[(int)ACalculationLotus3D._emPosition.P2];y[(int)ACalculationLotus3D._emPosition.P2]<=pdRange[(int)ACalculationLotus3D._emPosition.P2];y[(int)ACalculationLotus3D._emPosition.P2]+=dMm)
                {
                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P2].stShift.dY = pstSourceShift[(int)ACalculationLotus3D._emPosition.P2].dY + y[(int)ACalculationLotus3D._emPosition.P2];
                    pdL[0] = GetLength(0, ACalculationLotus3D._emPosition.P1, ACalculationLotus3D._emPosition.P2);
                    pdL[1] = GetLength(1, ACalculationLotus3D._emPosition.P1, ACalculationLotus3D._emPosition.P2);
                    dDiffP1_P2 = Math.Abs(pdL[0] - pdL[1]);
                    if (dDiffP1_P2 > m_aIniHoleLocation.m_dCheckLength)
                        continue;
        			
                for(z[(int)ACalculationLotus3D._emPosition.P2]=-pdRange[(int)ACalculationLotus3D._emPosition.P2];z[(int)ACalculationLotus3D._emPosition.P2]<=pdRange[(int)ACalculationLotus3D._emPosition.P2];z[(int)ACalculationLotus3D._emPosition.P2]+=dMm)
                {
                    m_pstMeasure[(int)ACalculationLotus3D._emPosition.P2].stShift.dZ = pstSourceShift[(int)ACalculationLotus3D._emPosition.P2].dZ + z[(int)ACalculationLotus3D._emPosition.P2];
                    pdL[0] = GetLength(0, ACalculationLotus3D._emPosition.P1, ACalculationLotus3D._emPosition.P2);
                    pdL[1] = GetLength(1, ACalculationLotus3D._emPosition.P1, ACalculationLotus3D._emPosition.P2);
                    dDiffP1_P2 = Math.Abs(pdL[0] - pdL[1]);
                    if (dDiffP1_P2 > m_aIniHoleLocation.m_dCheckLength)
                        continue;
        			
                    // P3
                    for(x[(int)ACalculationLotus3D._emPosition.P3]=-pdRange[(int)ACalculationLotus3D._emPosition.P3];x[(int)ACalculationLotus3D._emPosition.P3]<=pdRange[(int)ACalculationLotus3D._emPosition.P3];x[(int)ACalculationLotus3D._emPosition.P3]+=dMm)
                    {
                        m_pstMeasure[(int)ACalculationLotus3D._emPosition.P3].stShift.dX = pstSourceShift[(int)ACalculationLotus3D._emPosition.P3].dX + x[(int)ACalculationLotus3D._emPosition.P3];
                        pdL[0] = GetLength(0, ACalculationLotus3D._emPosition.P1, ACalculationLotus3D._emPosition.P3);
                        pdL[1] = GetLength(1, ACalculationLotus3D._emPosition.P1, ACalculationLotus3D._emPosition.P3);
                        dDiffP1_P3 = Math.Abs(pdL[0] - pdL[1]);
                        if (dDiffP1_P3 > m_aIniHoleLocation.m_dCheckLength)
                            continue;				
                        pdL[0] = GetLength(0, ACalculationLotus3D._emPosition.P2, ACalculationLotus3D._emPosition.P3);
                        pdL[1] = GetLength(1, ACalculationLotus3D._emPosition.P2, ACalculationLotus3D._emPosition.P3);
                        dDiffP2_P3 = Math.Abs(pdL[0] - pdL[1]);
                        if (dDiffP2_P3 > m_aIniHoleLocation.m_dCheckLength)
                            continue;
        				
                    for(y[(int)ACalculationLotus3D._emPosition.P3]=-pdRange[(int)ACalculationLotus3D._emPosition.P3];y[(int)ACalculationLotus3D._emPosition.P3]<=pdRange[(int)ACalculationLotus3D._emPosition.P3];y[(int)ACalculationLotus3D._emPosition.P3]+=dMm)
                    {
                        m_pstMeasure[(int)ACalculationLotus3D._emPosition.P3].stShift.dY = pstSourceShift[(int)ACalculationLotus3D._emPosition.P3].dY + y[(int)ACalculationLotus3D._emPosition.P3];
                        pdL[0] = GetLength(0, ACalculationLotus3D._emPosition.P1, ACalculationLotus3D._emPosition.P3);
                        pdL[1] = GetLength(1, ACalculationLotus3D._emPosition.P1, ACalculationLotus3D._emPosition.P3);
                        dDiffP1_P3 = Math.Abs(pdL[0] - pdL[1]);
                        if (dDiffP1_P3 > m_aIniHoleLocation.m_dCheckLength)
                            continue;				
                        pdL[0] = GetLength(0, ACalculationLotus3D._emPosition.P2, ACalculationLotus3D._emPosition.P3);
                        pdL[1] = GetLength(1, ACalculationLotus3D._emPosition.P2, ACalculationLotus3D._emPosition.P3);
                        dDiffP2_P3 = Math.Abs(pdL[0] - pdL[1]);
                        if (dDiffP2_P3 > m_aIniHoleLocation.m_dCheckLength)
                            continue;
        				
                    for(z[(int)ACalculationLotus3D._emPosition.P3]=-pdRange[(int)ACalculationLotus3D._emPosition.P3];z[(int)ACalculationLotus3D._emPosition.P3]<=pdRange[(int)ACalculationLotus3D._emPosition.P3];z[(int)ACalculationLotus3D._emPosition.P3]+=dMm)
                    {
                        m_pstMeasure[(int)ACalculationLotus3D._emPosition.P3].stShift.dZ = pstSourceShift[(int)ACalculationLotus3D._emPosition.P3].dZ + z[(int)ACalculationLotus3D._emPosition.P3];
                        pdL[0] = GetLength(0, ACalculationLotus3D._emPosition.P1, ACalculationLotus3D._emPosition.P3);
                        pdL[1] = GetLength(1, ACalculationLotus3D._emPosition.P1, ACalculationLotus3D._emPosition.P3);
                        dDiffP1_P3 = Math.Abs(pdL[0] - pdL[1]);
                        if (dDiffP1_P3 > m_aIniHoleLocation.m_dCheckLength)
                            continue;				
                        pdL[0] = GetLength(0, ACalculationLotus3D._emPosition.P2, ACalculationLotus3D._emPosition.P3);
                        pdL[1] = GetLength(1, ACalculationLotus3D._emPosition.P2, ACalculationLotus3D._emPosition.P3);
                        dDiffP2_P3 = Math.Abs(pdL[0] - pdL[1]);
                        if (dDiffP2_P3 > m_aIniHoleLocation.m_dCheckLength)
                            continue;
        				
                        // P4
                        for(x[(int)ACalculationLotus3D._emPosition.P4]=-pdRange[(int)ACalculationLotus3D._emPosition.P4];x[(int)ACalculationLotus3D._emPosition.P4]<=pdRange[(int)ACalculationLotus3D._emPosition.P4];x[(int)ACalculationLotus3D._emPosition.P4]+=dMm)
                        {
                            m_pstMeasure[(int)ACalculationLotus3D._emPosition.P4].stShift.dX = pstSourceShift[(int)ACalculationLotus3D._emPosition.P4].dX + x[(int)ACalculationLotus3D._emPosition.P4];
                            pdL[0] = GetLength(0, ACalculationLotus3D._emPosition.P1, ACalculationLotus3D._emPosition.P4);
                            pdL[1] = GetLength(1, ACalculationLotus3D._emPosition.P1, ACalculationLotus3D._emPosition.P4);
                            dDiffP1_P4 = Math.Abs(pdL[0] - pdL[1]);
                            if (dDiffP1_P4 > m_aIniHoleLocation.m_dCheckLength)
                                continue;					
                            pdL[0] = GetLength(0, ACalculationLotus3D._emPosition.P2, ACalculationLotus3D._emPosition.P4);
                            pdL[1] = GetLength(1, ACalculationLotus3D._emPosition.P2, ACalculationLotus3D._emPosition.P4);
                            dDiffP2_P4 = Math.Abs(pdL[0] - pdL[1]);
                            if (dDiffP2_P4 > m_aIniHoleLocation.m_dCheckLength)
                                continue;					
                            pdL[0] = GetLength(0, ACalculationLotus3D._emPosition.P3, ACalculationLotus3D._emPosition.P4);
                            pdL[1] = GetLength(1, ACalculationLotus3D._emPosition.P3, ACalculationLotus3D._emPosition.P4);
                            dDiffP3_P4 = Math.Abs(pdL[0] - pdL[1]);
                            if (dDiffP3_P4 > m_aIniHoleLocation.m_dCheckLength)
                                continue;
        					
                        for(y[(int)ACalculationLotus3D._emPosition.P4]=-pdRange[(int)ACalculationLotus3D._emPosition.P4];y[(int)ACalculationLotus3D._emPosition.P4]<=pdRange[(int)ACalculationLotus3D._emPosition.P4];y[(int)ACalculationLotus3D._emPosition.P4]+=dMm)
                        {
                            m_pstMeasure[(int)ACalculationLotus3D._emPosition.P4].stShift.dY = pstSourceShift[(int)ACalculationLotus3D._emPosition.P4].dY + y[(int)ACalculationLotus3D._emPosition.P4];
                            pdL[0] = GetLength(0, ACalculationLotus3D._emPosition.P1, ACalculationLotus3D._emPosition.P4);
                            pdL[1] = GetLength(1, ACalculationLotus3D._emPosition.P1, ACalculationLotus3D._emPosition.P4);
                            dDiffP1_P4 = Math.Abs(pdL[0] - pdL[1]);
                            if (dDiffP1_P4 > m_aIniHoleLocation.m_dCheckLength)
                                continue;					
                            pdL[0] = GetLength(0, ACalculationLotus3D._emPosition.P2, ACalculationLotus3D._emPosition.P4);
                            pdL[1] = GetLength(1, ACalculationLotus3D._emPosition.P2, ACalculationLotus3D._emPosition.P4);
                            dDiffP2_P4 = Math.Abs(pdL[0] - pdL[1]);
                            if (dDiffP2_P4 > m_aIniHoleLocation.m_dCheckLength)
                                continue;					
                            pdL[0] = GetLength(0, ACalculationLotus3D._emPosition.P3, ACalculationLotus3D._emPosition.P4);
                            pdL[1] = GetLength(1, ACalculationLotus3D._emPosition.P3, ACalculationLotus3D._emPosition.P4);
                            dDiffP3_P4 = Math.Abs(pdL[0] - pdL[1]);
                            if (dDiffP3_P4 > m_aIniHoleLocation.m_dCheckLength)
                                continue;
        					
                        for(z[(int)ACalculationLotus3D._emPosition.P4]=-pdRange[(int)ACalculationLotus3D._emPosition.P4];z[(int)ACalculationLotus3D._emPosition.P4]<=pdRange[(int)ACalculationLotus3D._emPosition.P4];z[(int)ACalculationLotus3D._emPosition.P4]+=dMm)
                        {
                            m_pstMeasure[(int)ACalculationLotus3D._emPosition.P4].stShift.dZ = pstSourceShift[(int)ACalculationLotus3D._emPosition.P4].dZ + z[(int)ACalculationLotus3D._emPosition.P4];										
                            pdL[0] = GetLength(0, ACalculationLotus3D._emPosition.P1, ACalculationLotus3D._emPosition.P4);
                            pdL[1] = GetLength(1, ACalculationLotus3D._emPosition.P1, ACalculationLotus3D._emPosition.P4);
                            dDiffP1_P4 = Math.Abs(pdL[0] - pdL[1]);
                            if (dDiffP1_P4 > m_aIniHoleLocation.m_dCheckLength)
                                continue;					
                            pdL[0] = GetLength(0, ACalculationLotus3D._emPosition.P2, ACalculationLotus3D._emPosition.P4);
                            pdL[1] = GetLength(1, ACalculationLotus3D._emPosition.P2, ACalculationLotus3D._emPosition.P4);
                            dDiffP2_P4 = Math.Abs(pdL[0] - pdL[1]);
                            if (dDiffP2_P4 > m_aIniHoleLocation.m_dCheckLength)
                                continue;					
                            pdL[0] = GetLength(0, ACalculationLotus3D._emPosition.P3, ACalculationLotus3D._emPosition.P4);
                            pdL[1] = GetLength(1, ACalculationLotus3D._emPosition.P3, ACalculationLotus3D._emPosition.P4);
                            dDiffP3_P4 = Math.Abs(pdL[0] - pdL[1]);
                            if (dDiffP3_P4 > m_aIniHoleLocation.m_dCheckLength)
                                continue;

                            dLen = dDiffP1_P2 + dDiffP1_P3 + dDiffP1_P4 + dDiffP2_P3 + dDiffP2_P4 + dDiffP3_P4;
        					
                            if (dLen < dMinLen)
                            {
                                dMinLen = dLen;
                                for(i=0;i<ASDef._3D_POSITION_COUNT;i++)
                                {
                                    pstXYZ[i].dX = x[i];
                                    pstXYZ[i].dY = y[i];
                                    pstXYZ[i].dZ = z[i];
                                }
                            }
                        }
                        }
                        }
                    }
                    }
                    }
                }
                }
                }
            }
            }
            }
        	
            // X 평행 이동
            if (pstXYZ[0].dX == pstXYZ[1].dX &&
                pstXYZ[0].dX == pstXYZ[2].dX &&
                pstXYZ[0].dX == pstXYZ[3].dX &&
                pstXYZ[1].dX == pstXYZ[2].dX &&
                pstXYZ[1].dX == pstXYZ[3].dX &&
                pstXYZ[2].dX == pstXYZ[3].dX)
            {
                for(i=0;i<ASDef._3D_POSITION_COUNT;i++)
                {
                    pstXYZ[i].dX = 0;
                }
            }
            // Y 평행 이동
            if (pstXYZ[0].dY == pstXYZ[1].dY &&
                pstXYZ[0].dY == pstXYZ[2].dY &&
                pstXYZ[0].dY == pstXYZ[3].dY &&
                pstXYZ[1].dY == pstXYZ[2].dY &&
                pstXYZ[1].dY == pstXYZ[3].dY &&
                pstXYZ[2].dY == pstXYZ[3].dY)
            {
                for(i=0;i<ASDef._3D_POSITION_COUNT;i++)
                {
                    pstXYZ[i].dY = 0;
                }
            }

            // Z 평행 이동
            if (pstXYZ[0].dZ == pstXYZ[1].dZ &&
                pstXYZ[0].dZ == pstXYZ[2].dZ &&
                pstXYZ[0].dZ == pstXYZ[3].dZ &&
                pstXYZ[1].dZ == pstXYZ[2].dZ &&
                pstXYZ[1].dZ == pstXYZ[3].dZ &&
                pstXYZ[2].dZ == pstXYZ[3].dZ)
            {
                for(i=0;i<ASDef._3D_POSITION_COUNT;i++)
                {
                    pstXYZ[i].dZ = 0;
                }
            }

            //for (i = 0; i < ASDef._3D_POSITION_COUNT; i++)
            //    m_pstMeasure[i].stShift = pstSourceShift[i];
        }
        */

        private void RunRevisions3D()
        {
            int i;
            // 2011.08.21
            try
            {
                StringBuilder sb = new StringBuilder(32);
                AUtil.GetPrivateProfileString("Start", "Delay", "0", sb, 32, ASDef._INI_FILE);
                int nDelay = Convert.ToInt32(sb.ToString());
                if (nDelay > 0)
                {
                    // 2015.03.20
                    //Thread.Sleep(nDelay);
                    AUtil.Delay(nDelay);
                }
            }
            catch
            {
            }

            // 2011.08.18
            try
            {
                // 2011.08.20
                for (i = ASDef._3D_POSITION_COUNT - 1; i >= 0; i--)
                {
                    RunRevision3D(i, true);

                    //if (m_pchkUse[i].Checked)
                    {
                        AddLstBxMessage("P" + (i + 1).ToString() + "_Camera");
                    }
                }
            }
            catch
            {
                for (i = 0; i < ASDef._3D_POSITION_COUNT; i++)
                {
                    m_pnR_3D[i] = -100;
                }
            }
            CheckCalcu();
            // 2012.02.29
            if (AVisionProBuild.Auto)
            {
                if (m_bTopWindow)
                    AUtil.TopWindow(this.Handle, this.DefaultMargin.Left + 1, this.DefaultMargin.Top + 1);

                tmrSaveJpeg.Enabled = true;
            }

        }

        // 2014.11.12
        public int RunRevision3D(int nPosition, bool bCalcu) 
        {
            tc3D_2D.SelectedIndex = 0;

            int nBody = cmbType.SelectedIndex, nR = 0;
        	
            string strLog; //, strBmp;

            ICogImage cogImage = null;

            for(int i = 0;i<2;i++)
            {
                ADisplay aDisplay = AVisionProBuild.GetDisplay(nPosition*2 + i);
                APoint aPoint = AVisionProBuild.GetPoint(nBody, nPosition*2+i);
                APMAligns aPMAligns = aPoint.GetTool("PMAligns", 0) as APMAligns;

                AIniPMAlign aIniPMAlign = new AIniPMAlign(nBody, nPosition*2+i, 0);
                aIniPMAlign.Read();
                // 2016.06.22
                bool bU = aIniPMAlign.FixtureNPointToNPoint;

                //if (m_pchkUse[nPosition].Checked)
                {
                    if (cmbLoadImg.SelectedIndex == 0)
                    {
                        LightOnOff3D(nBody, nPosition, i, true);
                        SetLightControl3D(nBody, nPosition, i, 0);

                        AVisionProBuild.Acq(nBody, nPosition * 2 + i, ref cogImage);
                        // 2016.06.21
                        //aDisplay.Image = cogImage;
                        aDisplay.Image = AVisionProBuild.RunFixtureImage(cogImage, ref bU, 0, nPosition * 2 + i);
                    }
                    else
                    {
                        if (AVisionProBuild.LoadImg(aPoint.m_strLoadFileName, ref cogImage) == true)
                        {
                            // 2016.06.21
                            //aDisplay.Image = cogImage;
                            aDisplay.Image = AVisionProBuild.RunFixtureImage(cogImage, ref bU, 0, nPosition * 2 + i);

                            aDisplay.FitImage();
                        }
                        else
                        {
                            aDisplay.ClearAll();
                        }

                    }

                    aDisplay.ClearExcludeImage();
                    aPMAligns.RunPMAlign(aDisplay, false);
                    // 2012.02.21
                    m_pstMeasure[nPosition].pbR[i] = aPMAligns.m_stResult.bResult;
                    
                    if (aPMAligns.m_stResult.bResult)
                    {
                        /*
                        m_pstMeasure[nPosition].pstHole[i].dX = aPMAligns.m_stResult.dX - Convert.ToDouble(aIniPMAlign.InitX);
                        m_pstMeasure[nPosition].pstHole[i].dY = aPMAligns.m_stResult.dY - Convert.ToDouble(aIniPMAlign.InitY);
                        */
                        m_pstMeasure[nPosition].pstHole[i].dX = aPMAligns.m_stResult.dX;
                        m_pstMeasure[nPosition].pstHole[i].dY = aPMAligns.m_stResult.dY;
                        
                        double startX = Convert.ToDouble(aIniPMAlign.InitX);
                        double startY = Convert.ToDouble(aIniPMAlign.InitY);
                        double endX = aPMAligns.m_stResult.dX;
                        double endY = aPMAligns.m_stResult.dY;

                        // 2011.09.29
                        if (i == 0)
                        {
                            m_plblX_L[nPosition].Text = (endX - startX).ToString("0.00");
                            m_plblY_L[nPosition].Text = (endY - startY).ToString("0.00");
                        }
                        else
                        {
                            m_plblX_R[nPosition].Text = (endX - startX).ToString("0.00");
                            m_plblY_R[nPosition].Text = (endY - startY).ToString("0.00");
                        }

                        aDisplay.AddLine(startX, startY, endX, endY, CogColorConstants.Yellow);

                        if (AVisionProBuild.Auto)
                        {
                            string strTmp = "";
                            strTmp = String.Format("_{0:d}_{1:f0}", aPMAligns.m_stResult.nFindIndex + 1, aPMAligns.m_stResult.dScore * 100);
                            // 2012.02.21
                            m_pstMeasure[nPosition].pstrBmpTxt[i] = strTmp;
                            //strBmp = AVisionProBuild.GetResultFName(true, nBody, nPosition*2+i, strTmp);
                            //AVisionProBuild.SaveImg(strBmp, cogImage);
                        }

                        aDisplay.AddTxt(0, 0, "PMAlign:OK(" + (aPMAligns.m_stResult.nFindIndex + 1).ToString() + ":" + Math.Round(aPMAligns.m_stResult.dScore * 100, 2).ToString() + "%)", CogColorConstants.Green);

                    }
                    else
                    {
                        nR |= (1 << i);
                        m_pstMeasure[nPosition].pstHole[i].dX = 0; 
                        m_pstMeasure[nPosition].pstHole[i].dY = 0;

                        // 2011.09.29
                        if (i == 0)
                        {
                            m_plblX_L[nPosition].Text = "";
                            m_plblY_L[nPosition].Text = "";
                        }
                        else
                        {
                            m_plblX_R[nPosition].Text = "";
                            m_plblY_R[nPosition].Text = "";
                        }

                        if (AVisionProBuild.Auto)
                        {
                            // 2012.02.21
                            m_pstMeasure[nPosition].pstrBmpTxt[i] = "";
                            //strBmp = AVisionProBuild.GetResultFName(false, nBody, nPosition*2+i, "");
                            //AVisionProBuild.SaveImg(strBmp, cogImage);
                        }
                        aDisplay.AddTxt(0, 0, "PMAlign:NG", CogColorConstants.Red);
                    }

                    m_pstMeasure[nPosition].pstHole[i].dX += m_aIniPartOffset.m_ppstHoleXY[nPosition, i].dX;
                    m_pstMeasure[nPosition].pstHole[i].dY += m_aIniPartOffset.m_ppstHoleXY[nPosition, i].dY;

                }
                /*
                else
                {
                    aDisplay.ClearAll();
                    m_pstMeasure[nPosition].pstHole[i].dX = 0; 
                    m_pstMeasure[nPosition].pstHole[i].dY = 0;
                }
                */
            }

            if (cmbLoadImg.SelectedIndex == 0)
            {
                LightOnOff3D(nBody, nPosition, 0, false);
            }

            // 2016.10.11
            // 2016.06.17
            AIniFrame aIniFrame = new AIniFrame(cmbType.Text, nPosition);
            //AIniFrame aIniFrame = new AIniFrame(nPosition);

            aIniFrame.Read();


            m_aCalculationLotus3D.SetFrameCommon(aIniFrame.m_stCommon);
            // 2016.10.11
            // 2016.06.17
            m_aCalculationLotus3D.SetFramePose(aIniFrame.m_stPose);

            
            if (nR == 0 && bCalcu == true)// && m_pchkUse[nPosition].Checked)                
            {
                float fRMS = m_aCalculationLotus3D.FindXYZ((ACalculationLotus3D._emPosition)nPosition, ref m_pstMeasure[nPosition]);
                // 2012.03.08
                ADisplay aDisplay = AVisionProBuild.GetDisplay(nPosition * 2);
                if (fRMS <= 2.0)
                    aDisplay.AddTxt(0, 100, fRMS.ToString("0.00") + " RMS", CogColorConstants.Green);
                else if (fRMS <= 5.0)
                    aDisplay.AddTxt(0, 100, fRMS.ToString("0.00") + " RMS", CogColorConstants.Yellow);
                else
                    aDisplay.AddTxt(0, 100, fRMS.ToString("0.00") + " RMS", CogColorConstants.Orange);


                if (AVisionProBuild.Auto)
                {
                    // 2011.08.06
                    strLog = string.Format("{0:f2} {1:f2} {2:f2} ", 
                        m_pstMeasure[nPosition].stShift.dX,
                        m_pstMeasure[nPosition].stShift.dY,
                        m_pstMeasure[nPosition].stShift.dZ);

                    AVisionProBuild.WriteLogFile(strLog);
                }                
            }
            else
            {
                m_pstMeasure[nPosition].stShift.dX = 0;
                m_pstMeasure[nPosition].stShift.dY = 0;
                m_pstMeasure[nPosition].stShift.dZ = 0;
                if (AVisionProBuild.Auto)
                {
                    // 2011.08.06
                    strLog = string.Format("{0:d} {1:d} {2:d} {3:f2} {4:f2} {5:f2} ", 
                        0, 0, 0, 0, 0, 0);
                    
                    AVisionProBuild.WriteLogFile(strLog);
                }
            }

            
            if (bCalcu == true)
            {
                /* 2016.06.17
                // 2012.01.25  ------------------------------------
                //m_pstMeasure[nPosition].stCalibXYZ = m_pstMeasure[nPosition].stShift;
                m_pstMeasure[nPosition].stCalibXYZ.dX = 0;
                m_pstMeasure[nPosition].stCalibXYZ.dY = 0;
                m_pstMeasure[nPosition].stCalibXYZ.dZ = 0;
                
                switch (aIniFrame.m_nCalibDirectX)
                {
                    case 0: // -X
                        m_pstMeasure[nPosition].stCalibXYZ.dX = -m_pstMeasure[nPosition].stShift.dX;
                        break;
                    case 1: // +X
                        m_pstMeasure[nPosition].stCalibXYZ.dX = m_pstMeasure[nPosition].stShift.dX;
                        break;
                    case 2: // -Y
                        m_pstMeasure[nPosition].stCalibXYZ.dY = -m_pstMeasure[nPosition].stShift.dX;
                        break;
                    case 3: // +Y
                        m_pstMeasure[nPosition].stCalibXYZ.dY = m_pstMeasure[nPosition].stShift.dX;
                        break;
                    case 4: // -Z
                        m_pstMeasure[nPosition].stCalibXYZ.dZ = -m_pstMeasure[nPosition].stShift.dX;
                        break;
                    case 5: // +Z
                        m_pstMeasure[nPosition].stCalibXYZ.dZ = m_pstMeasure[nPosition].stShift.dX;
                        break;
                }
                switch (aIniFrame.m_nCalibDirectY)
                {
                    case 0: // -X
                        m_pstMeasure[nPosition].stCalibXYZ.dX = -m_pstMeasure[nPosition].stShift.dY;
                        break;
                    case 1: // +X
                        m_pstMeasure[nPosition].stCalibXYZ.dX = m_pstMeasure[nPosition].stShift.dY;
                        break;
                    case 2: // -Y
                        m_pstMeasure[nPosition].stCalibXYZ.dY = -m_pstMeasure[nPosition].stShift.dY;
                        break;
                    case 3: // +Y
                        m_pstMeasure[nPosition].stCalibXYZ.dY = m_pstMeasure[nPosition].stShift.dY;
                        break;
                    case 4: // -Z
                        m_pstMeasure[nPosition].stCalibXYZ.dZ = -m_pstMeasure[nPosition].stShift.dY;
                        break;
                    case 5: // +Z
                        m_pstMeasure[nPosition].stCalibXYZ.dZ = m_pstMeasure[nPosition].stShift.dY;
                        break;
                }
                switch (aIniFrame.m_nCalibDirectZ)
                {
                    case 0: // -X
                        m_pstMeasure[nPosition].stCalibXYZ.dX = -m_pstMeasure[nPosition].stShift.dZ;
                        break;
                    case 1: // +X
                        m_pstMeasure[nPosition].stCalibXYZ.dX = m_pstMeasure[nPosition].stShift.dZ;
                        break;
                    case 2: // -Y
                        m_pstMeasure[nPosition].stCalibXYZ.dY = -m_pstMeasure[nPosition].stShift.dZ;
                        break;
                    case 3: // +Y
                        m_pstMeasure[nPosition].stCalibXYZ.dY = m_pstMeasure[nPosition].stShift.dZ;
                        break;
                    case 4: // -Z
                        m_pstMeasure[nPosition].stCalibXYZ.dZ = -m_pstMeasure[nPosition].stShift.dZ;
                        break;
                    case 5: // +Z
                        m_pstMeasure[nPosition].stCalibXYZ.dZ = m_pstMeasure[nPosition].stShift.dZ;
                        break;
                }
                //-------------------------------------------------
                */
                m_pstMeasure[nPosition].stCalibXYZ = m_pstMeasure[nPosition].stShift;


                m_pstMeasure[nPosition].stCalibXYZ.dX += m_aIniPartOffset.m_pstCalibXYZ[nPosition].dX;
                m_pstMeasure[nPosition].stCalibXYZ.dY += m_aIniPartOffset.m_pstCalibXYZ[nPosition].dY;
                m_pstMeasure[nPosition].stCalibXYZ.dZ += m_aIniPartOffset.m_pstCalibXYZ[nPosition].dZ;

                //---------------------------
                // 2016.10.11 3->4
                // 2016.06.17 2->3
                ASDef._stXYZ[] pstSource = new ASDef._stXYZ[4];
                
                /* 2016.06.17
                pstSource[0].dX = aIniFrame.m_stTarget.dX + m_pstMeasure[nPosition].stCalibXYZ.dX;
                pstSource[0].dY = aIniFrame.m_stTarget.dY + m_pstMeasure[nPosition].stCalibXYZ.dY;
                pstSource[0].dZ = aIniFrame.m_stTarget.dZ + m_pstMeasure[nPosition].stCalibXYZ.dZ;
                */

                pstSource[0].dX = m_pstMeasure[nPosition].stCalibXYZ.dX;
                pstSource[0].dY = m_pstMeasure[nPosition].stCalibXYZ.dY;
                pstSource[0].dZ = m_pstMeasure[nPosition].stCalibXYZ.dZ;
                
                /* 2016.06.17
                // 2015.10.26 Kawasaki => Yaskawa
                //m_aCalculationLotus3D.PoseToBase(pstSource[0], ref pstSource[1], ACalculationLotus3D._emRotationOrder.ZYZ);
                //m_aCalculationLotus3D.BaseToCommon(pstSource[1], ref m_pstMeasure[nPosition].stShift, ACalculationLotus3D._emRotationOrder.ZYZ);
                m_aCalculationLotus3D.PoseToBase(pstSource[0], ref pstSource[1], ACalculationLotus3D._emRotationOrder.ZYX);
                m_aCalculationLotus3D.BaseToCommon(pstSource[1], ref m_pstMeasure[nPosition].stShift, ACalculationLotus3D._emRotationOrder.ZYX);
        		*/
                
                // 2016.11.25
                //ACalculationLotus3D.ConvertFrameInverse(m_aCalculationLotus3D.m_stFrameVision, pstSource[0], ref pstSource[1], ACalculationLotus3D._emRotationOrder.ZYX);
                //ACalculationLotus3D.ConvertFrame(m_aCalculationLotus3D.m_stFrameRobot, pstSource[1], ref pstSource[2], ACalculationLotus3D._emRotationOrder.ZYX);
                ACalculationLotus3D.ConvertFrame(m_aCalculationLotus3D.m_stFramePose, pstSource[2], ref pstSource[3], ACalculationLotus3D._emRotationOrder.ZYX);
                
                m_aCalculationLotus3D.BaseToCommon(pstSource[3], ref m_pstMeasure[nPosition].stShift, ACalculationLotus3D._emRotationOrder.ZYX);
                                
                m_pstMeasure[nPosition].stShift.dX -= m_aIniHoleLocation.m_pstXYZ[nPosition].dX;
                m_pstMeasure[nPosition].stShift.dY -= m_aIniHoleLocation.m_pstXYZ[nPosition].dY;
                m_pstMeasure[nPosition].stShift.dZ -= m_aIniHoleLocation.m_pstXYZ[nPosition].dZ;
                
                //---------------------
                // Offset Part
                m_pstMeasure[nPosition].stShift.dX += m_aIniPartOffset.m_pstXYZ[nPosition].dX;
                m_pstMeasure[nPosition].stShift.dY += m_aIniPartOffset.m_pstXYZ[nPosition].dY;
                m_pstMeasure[nPosition].stShift.dZ += m_aIniPartOffset.m_pstXYZ[nPosition].dZ;
        		

                if (
                    m_pstMeasure[nPosition].stShift.dX < AVisionProBuild.GetType(nBody).m_pstLimitLow[0].dX ||
                    m_pstMeasure[nPosition].stShift.dX > AVisionProBuild.GetType(nBody).m_pstLimitHigh[0].dX ||
                    m_pstMeasure[nPosition].stShift.dY < AVisionProBuild.GetType(nBody).m_pstLimitLow[0].dY ||
                    m_pstMeasure[nPosition].stShift.dY > AVisionProBuild.GetType(nBody).m_pstLimitHigh[0].dY ||
                    m_pstMeasure[nPosition].stShift.dZ < AVisionProBuild.GetType(nBody).m_pstLimitLow[0].dZ ||
                    m_pstMeasure[nPosition].stShift.dZ > AVisionProBuild.GetType(nBody).m_pstLimitHigh[0].dZ)
                {
                    nR |= 0x10;
                }
            }

            m_pnR_3D[nPosition] = nR;

        	if (nR == 0)
                DisplayResult3D(nPosition, ASDef._emResult.OK);
            else
                DisplayResult3D(nPosition, ASDef._emResult.NG);

            if (AVisionProBuild.Auto)
                SetCompleteDO(nPosition);
            
            return nR;
        }

        // 2014.11.12
        private void SaveImage(int nPosition, string strDateTime)
        {
            int nBody = cmbType.SelectedIndex;
            string strBmp;

            for (int i = 0; i < 2; i++)
            {
                ADisplay aDisplay = AVisionProBuild.GetDisplay(nPosition * 2 + i);

                if (AVisionProBuild.Auto) // && m_pchkUse[nPosition].Checked)
                {
                    if (m_pstMeasure[nPosition].pbR[i])
                    {
                        // 2014.11.12
                        strBmp = AVisionProBuild.GetResultFName(true, nBody, nPosition * 2 + i, strDateTime, m_pstMeasure[nPosition].pstrBmpTxt[i]);
                        AVisionProBuild.SaveImg(strBmp, aDisplay.Image);
                    }
                    else
                    {
                        // 2014.11.12
                        strBmp = AVisionProBuild.GetResultFName(false, nBody, nPosition * 2 + i, strDateTime, "");
                        AVisionProBuild.SaveImg(strBmp, aDisplay.Image);
                    }

                }
            }
        }

        private void SaveXYZ_Bmp(string strDir, ACalculationLotus3D._emPosition emPosition, int x, int y, int z)
        {
            string strTmp;
            int nType = cmbType.SelectedIndex;

            ICogImage cogImageL = null, cogImageR = null;

            ADisplay aDisplayL = AVisionProBuild.GetDisplay((int)emPosition * 2);

            AVisionProBuild.Acq(nType, (int)emPosition * 2, ref cogImageL);
            aDisplayL.Image = cogImageL;

            strTmp = strDir + "\\L_" + x.ToString("###") + "_" + y.ToString("###") + "_" + z.ToString("###") + ".bmp";
            AVisionProBuild.SaveImg(strTmp, cogImageL);

            ADisplay aDisplayR = AVisionProBuild.GetDisplay((int)emPosition * 2 + 1);

            AVisionProBuild.Acq(nType, (int)emPosition * 2 + 1, ref cogImageR);
            aDisplayR.Image = cogImageR;

            strTmp = strDir + "\\R_" + x.ToString("###") + "_" + y.ToString("###") + "_" + z.ToString("###") + ".bmp";
            AVisionProBuild.SaveImg(strTmp, cogImageR);
        }

        // SHIFT 1,2,3
        private void SetRbtShift(int nRobot, int n, double dX, double dY, double dZ, int nType)
        {
            //m_pAThrdRbt[nRobot].SetValue(n, dX, dY, dZ, (double)nType, 0, 0);

            int nBody = cmbType.SelectedIndex;

            if (nType >= 0 && nType <= 3)
            {
                /*
                m_pAThrdRbt[nRobot].m_pstRobotShift[n].dX = dX + AVisionProBuild.GetType(nBody).m_pstOffset[nRobot + nType * 4].dX;
                m_pAThrdRbt[nRobot].m_pstRobotShift[n].dY = dY + AVisionProBuild.GetType(nBody).m_pstOffset[nRobot + nType * 4].dY;
                m_pAThrdRbt[nRobot].m_pstRobotShift[n].dZ = dZ + AVisionProBuild.GetType(nBody).m_pstOffset[nRobot + nType * 4].dZ;
                */
                // 2020.04.23
                //m_pAThrdRbt[nRobot].m_pstRobotShift[n].dX = dX;
                //m_pAThrdRbt[nRobot].m_pstRobotShift[n].dY = dY;
                //m_pAThrdRbt[nRobot].m_pstRobotShift[n].dZ = dZ;
                m_pAThrdRbt[nRobot].SetValue(n, dX, dY, dZ, 0, 0, 0);

            }
            else
            {
                // 2020.04.23
                //m_pAThrdRbt[nRobot].m_pstRobotShift[n].dX = 0;
                //m_pAThrdRbt[nRobot].m_pstRobotShift[n].dY = 0;
                //m_pAThrdRbt[nRobot].m_pstRobotShift[n].dZ = 0;
                m_pAThrdRbt[nRobot].SetValue(n, 0, 0, 0, 0, 0, 0);

            }

        }

        // 2015.10.26
        /*
        public void SetCalibXYZ(int x, int y, int z)
        {
            m_nCalibX = x;
            m_nCalibY = y;
            m_nCalibZ = z;
        }
        */

        private void SetCompleteDO(int nPosition)
        {
            int nBit;
            int nVal = m_AThrdPlc.GetWordDO(ASDef._DO_SIGNAL);

            nBit = ASDef._DO_BIT_COMPLETE_P1 + nPosition;
            nVal |= (1 << nBit);

            m_AThrdPlc.SetWordDO(ASDef._DO_SIGNAL, nVal);

            string strTmp;
            strTmp = "O:" + aioMapOUT.Items[nBit];
            AddLstBxMessage(strTmp);
        }
        
        // 2014.10.04
        private void ShowStereoSet(int nPosition)
        {
            // 2016.06.21
            if (!AVisionProBuild.Auto && ((Control.ModifierKeys & Keys.Alt) == Keys.Alt))
            {
                LiveOff();
                this.Cursor = Cursors.WaitCursor;

                int nType = cmbType.SelectedIndex;
                if (Application.OpenForms["AFrmStereoFixtureSet"] == null)
                {
                    AFrmStereoFixtureSet dlg = new AFrmStereoFixtureSet(nPosition);
                    dlg.Show(this);
                }

                this.Cursor = Cursors.Default;
            }
            // 2014.10.04
            else if (!AVisionProBuild.Auto || ((Control.ModifierKeys & Keys.Shift) == Keys.Shift))
            {
                LiveOff();
                this.Cursor = Cursors.WaitCursor;

                int nType = cmbType.SelectedIndex;
                // 2014.10.04
                if (Application.OpenForms["AFrmStereoSet"] == null)
                {
                    AFrmStereoSet dlg = new AFrmStereoSet(nType, nPosition);
                    // 2014.10.04
                    dlg.Show(this);
                }

                this.Cursor = Cursors.Default;
            }
        }

        // 2014.10.04
        private void ShowFrameSet(int nPosition)
        {
            // 2013.04.05
            if (!AVisionProBuild.Auto)
            {
                LiveOff();

                int nType = cmbType.SelectedIndex;

                // 2015.04.15
                if (Application.OpenForms["FrmFrameSet"] == null)
                {
                    // 2016.10.11
                    // 2016.06.17
                    FrmFrameSet dlg = new FrmFrameSet(this.Handle, nType, nPosition);
                    //FrmFrameSet dlg = new FrmFrameSet(this.Handle, nPosition);

                    // 2015.03.20
                    dlg.Show(this);
                }
            }
        }

        private void SetLightControl3D(int nType, int nPosition, int nLR, int nStep)
        {
            AIniLight aIni = new AIniLight(nType, nPosition * 2 + nLR);
            aIni.Read();

            APoint aPoint = AVisionProBuild.GetPoint(nType, nPosition * 2 + nLR);
#if (!_USE_BASLER_PYLON)
            aPoint.GetAcq().Exposure = Convert.ToDouble(aIni.m_pstrExposure[nStep]);
#elif _USE_BASLER_PYLON
            ABaslerPylon.SetExposureTime(aPoint.m_strDevName, Convert.ToInt32(aIni.m_pstrExposure[nStep]));
#endif
            int nIndex = Convert.ToInt32(aIni.m_strIndex);
            int nChannel = Convert.ToInt32(aIni.m_strChannel);
            int nLed = Convert.ToInt32(aIni.m_pstrLed[nStep]);
            if (nIndex != -1 && nLR == 0)
            {
                m_pACommLightControl[nIndex].SendToVal(nChannel, nLed);
                AUtil.Delay(ASDef._DELAY_LIGHT_CONTROL);
            }
        }

        //-------------------------------------------------------------
        #endregion

        #region 2D_Source
        //-------------------------------------------------------------
        private void Calcu(int nPoint)
        {
            int nBody = cmbType.SelectedIndex;
                        
            int i = nPoint - ASDef._3D_POINT_COUNT;

            //for (i = 0; i < ASDef._POINT_COUNT; i++)
            {   
                m_pstResult[i].stXY.dX += AVisionProBuild.GetType(nBody).m_pstOffset[i].dX;
                m_pstResult[i].stXY.dY += AVisionProBuild.GetType(nBody).m_pstOffset[i].dY;
             
                //---------Over------------------------
                if (m_pstResult[i].stXY.dX > AVisionProBuild.GetType(nBody).m_pstLimitHigh[0].dX ||
                    m_pstResult[i].stXY.dX < AVisionProBuild.GetType(nBody).m_pstLimitLow[0].dX)
                {
                    m_pstResult[i].emR = ASDef._emResult.Over;
                }
                if (m_pstResult[i].stXY.dY > AVisionProBuild.GetType(nBody).m_pstLimitHigh[0].dY ||
                    m_pstResult[i].stXY.dY < AVisionProBuild.GetType(nBody).m_pstLimitLow[0].dY)
                {
                    m_pstResult[i].emR = ASDef._emResult.Over;
                }

            }

        }

        private void DisplayResultXY(int nPoint)
        {
            Color clrBack;

            int i = nPoint - ASDef._3D_POINT_COUNT;
            //for (int i = 0; i < ASDef._POINT_COUNT; i++)
            {
                if (m_pstResult[i].emR == ASDef._emResult.OK)
                    clrBack = Color.LemonChiffon;
                else
                    clrBack = Color.OrangeRed;
                m_plblX[i].BackColor = clrBack;
                m_plblY[i].BackColor = clrBack;

                m_plblX[i].Text = m_pstResult[i].stXY.dX.ToString("0.00");
                m_plblY[i].Text = m_pstResult[i].stXY.dY.ToString("0.00");
            }
        }

        private void LoadImage(string[] pstrFName, int nPoint)
        {
            int i = nPoint;
            int nTotal;

            cmbLoadImg.SelectedIndex = 1;

            if (pstrFName.Length > 1)
            {
                string strDateTime = pstrFName[pstrFName.Length - 1].Substring(0, 17);
                string[] pstrFN = new string[1];
                AddLstBxMessage("Image:" + strDateTime);

                //for (i = 0; i < 8; i++)
                {
                    nTotal = AVisionProBuild.FindResultFName(cmbType.SelectedIndex, i, strDateTime, ref pstrFN);
                    APoint aPoint = AVisionProBuild.GetPoint(cmbType.SelectedIndex, i);
                    if (nTotal > 0)
                        aPoint.m_strLoadFileName = pstrFN[0];
                    else
                        aPoint.m_strLoadFileName = null;
                }
            }
            else
            {
                AddLstBxMessage("Image:null");
                //for (i = 0; i < 10; i++)
                {
                    APoint aPoint = AVisionProBuild.GetPoint(cmbType.SelectedIndex, i);
                    aPoint.m_strLoadFileName = null;
                }
            }
        }

        private void LightOnOff(int nType, int nPoint, bool bOnOff)
        {
            AIniLight aIni = new AIniLight(nType, nPoint);
            aIni.Read();
            int nIndex = Convert.ToInt32(aIni.m_strIndex);
            if (nIndex != -1)
            {
                int nChannel = Convert.ToInt32(aIni.m_strChannel);

                m_pACommLightControl[nIndex].SendToOnOff(nChannel, bOnOff);
                if (bOnOff)
                    AUtil.Delay(ASDef._DELAY_LIGHT_CONTROL);
            }
        }


        private bool RunRevision(int nPoint)           //  각각 검사
        {
            tc3D_2D.SelectedIndex = 1;

            bool bR = false;
            string strBmp = "";
            int nType = cmbType.SelectedIndex;

            ADisplay aDisplay = AVisionProBuild.GetDisplay(nPoint);
            // 2012.05.17
            if (aDisplay == null)
                return false;

            APoint aPoint = AVisionProBuild.GetPoint(nType, nPoint);
            // 2012.05.17
            if (aPoint == null)
                return false;

            APMAligns aPMAligns = aPoint.GetTool("PMAligns", 0) as APMAligns;
            // 2012.05.17
            if (aPMAligns == null)
                return false;

            AIniPMAlign aIniPMAlign = new AIniPMAlign(nType, nPoint, 0);
            aIniPMAlign.Read();
                        
            ICogImage cogImage = null;

            if (cmbLoadImg.SelectedIndex == 0)
            {
                LightOnOff(nType, nPoint, true);
                SetLightControl(nType, nPoint, 0);
                AVisionProBuild.Acq(nType, nPoint, ref cogImage);
                // 2012.12.04
                aDisplay.Image = aPoint.RunCalibImage(cogImage, aIniPMAlign.CalibCase);

                aDisplay.ClearExcludeImage();
                aPMAligns.RunPMAlign(aDisplay, false);
            }
            else
            {
                if (AVisionProBuild.LoadImg(aPoint.m_strLoadFileName, ref cogImage) == true)
                {
                    aDisplay.FitImage();
                }
                else
                {
                    aDisplay.ClearAll();
                }
                // 2012.12.04
                aDisplay.Image = aPoint.RunCalibImage(cogImage, aIniPMAlign.CalibCase);
                aDisplay.ClearExcludeImage();
                aPMAligns.RunPMAlign(aDisplay, false);
            }

            // 2012.05.29
            aDisplay.FitImage();

            if (cmbLoadImg.SelectedIndex == 0)
            {
                LightOnOff(nType, nPoint, false);
            }

            if (aPMAligns.m_stResult.bResult)
            {
                // 2020.05.12 - ASDef._3D_POINT_COUNT
                m_pstResult[nPoint - ASDef._3D_POINT_COUNT].nP_Index = aPMAligns.m_stResult.nFindIndex + 1;
                m_pstResult[nPoint - ASDef._3D_POINT_COUNT].nL_Index = 1;
                m_pstResult[nPoint - ASDef._3D_POINT_COUNT].strP_Name = aPMAligns.GetAPMAlign(aPMAligns.m_stResult.nFindIndex).Name;
                m_pstResult[nPoint - ASDef._3D_POINT_COUNT].dP_Score = aPMAligns.m_stResult.dScore * 100;

                m_pstResult[nPoint - ASDef._3D_POINT_COUNT].stXY.dX = aPMAligns.m_stResult.dX - Convert.ToDouble(aIniPMAlign.InitX);
                m_pstResult[nPoint - ASDef._3D_POINT_COUNT].stXY.dY = aPMAligns.m_stResult.dY - Convert.ToDouble(aIniPMAlign.InitY);

                m_pstResult[nPoint - ASDef._3D_POINT_COUNT].emR = ASDef._emResult.OK;

                double startX = Convert.ToDouble(aIniPMAlign.InitX);
                double startY = Convert.ToDouble(aIniPMAlign.InitY);
                double endX = aPMAligns.m_stResult.dX;
                double endY = aPMAligns.m_stResult.dY;
                aDisplay.AddLine(startX, startY, endX, endY, CogColorConstants.Yellow);

                if (AVisionProBuild.Auto)
                {
                    string strTmp = "";
                    strTmp = String.Format("_{0:d}_{1:f0}", aPMAligns.m_stResult.nFindIndex + 1, aPMAligns.m_stResult.dScore * 100);
                    //strBmp = AVisionProBuild.GetResultFName(true, nType, nPoint, m_strDateTimeRunRevisions, strTmp);
                    strBmp = AVisionProBuild.GetResultFName(true, nType, nPoint, strTmp);
                    AVisionProBuild.SaveImg(strBmp, cogImage);
                }

                aDisplay.AddTxt(0, 0, "PMAlign:OK(" + (aPMAligns.m_stResult.nFindIndex + 1).ToString() + ":" + Math.Round(aPMAligns.m_stResult.dScore * 100, 2).ToString() + "%)", CogColorConstants.Green);

                bR = true;                
            }
            else
            {
                // 2020.05.12 - ASDef._3D_POINT_COUNT
                m_pstResult[nPoint - ASDef._3D_POINT_COUNT].stXY.dX = 0;
                m_pstResult[nPoint - ASDef._3D_POINT_COUNT].stXY.dY = 0;

                m_pstResult[nPoint - ASDef._3D_POINT_COUNT].emR = ASDef._emResult.NG;
                m_pstResult[nPoint - ASDef._3D_POINT_COUNT].nP_Index = 0;
                m_pstResult[nPoint - ASDef._3D_POINT_COUNT].nL_Index = 0;
                m_pstResult[nPoint - ASDef._3D_POINT_COUNT].strP_Name = "";
                m_pstResult[nPoint - ASDef._3D_POINT_COUNT].dP_Score = 0;

                m_pstResult[nPoint - ASDef._3D_POINT_COUNT].emR = ASDef._emResult.NG;
                if (AVisionProBuild.Auto)
                {
                    //strBmp = AVisionProBuild.GetResultFName(false, nType, nPoint, m_strDateTimeRunRevisions, "");
                    strBmp = AVisionProBuild.GetResultFName(false, nType, nPoint, "");
                    AVisionProBuild.SaveImg(strBmp, cogImage);
                }
                // 2011.06.30
                aDisplay.AddTxt(0, 0, "PMAlign:NG", CogColorConstants.Red);

            }

            Calcu(nPoint);
            DisplayResultXY(nPoint);
            DisplayResult(lblResult, m_pstResult[nPoint - ASDef._3D_POINT_COUNT].emR);

            int n = nPoint - ASDef._3D_POINT_COUNT;
            if (nPoint < (ASDef._3D_POINT_COUNT + ASDef._2D_POINT_COUNT / 2))
            {
                // SHIFT 4,5,6,7
                m_pAThrdRbt[0].SetValue(n + 3, m_pstResult[n].stXY.dX, m_pstResult[n].stXY.dY, AVisionProBuild.GetType(nType).m_pstOffset[n].dZ, 0, 0, 0);
            }
            else
            {
                // SHIFT 4,5,6,7
                m_pAThrdRbt[1].SetValue(n - 4 + 3, m_pstResult[n].stXY.dX, m_pstResult[n].stXY.dY, AVisionProBuild.GetType(nType).m_pstOffset[n].dZ, 0, 0, 0);
            }

            if (AVisionProBuild.Auto)
            {
                SetResultDO(m_pstResult[n].emR, nPoint);

                if (m_bTopWindow == true)
                    AUtil.TopWindow(this.Handle, this.DefaultMargin.Left + 1, this.DefaultMargin.Top + 1);

                tmrSaveJpeg.Enabled = true;
            }
            
            return bR;
        }

        private void ShowOffset(int nCount, string strLoc)
        {
            int nType = cmbType.SelectedIndex;

            if (Application.OpenForms["AFrmOffset"] == null)
            {                
                AFrmOffset frmOffset = new AFrmOffset(this.Handle, nType, nCount, strLoc);
                frmOffset.Show(this);
            }
        }

        private void ShowPMAlign(int nPoint, int nToolIndex)
        {
            // 2014.06.30                    
            if (!AVisionProBuild.Auto && ((Control.ModifierKeys & Keys.Alt) == Keys.Alt))
            {
                this.Cursor = Cursors.WaitCursor;

                int nType = cmbType.SelectedIndex;
                AFrmCalibSet dlg = new AFrmCalibSet(nType, nPoint, 0);
                // 2015.06.18
                dlg.Show(this);

                this.Cursor = Cursors.Default;

                return;
            }
            if (!AVisionProBuild.Auto || ((Control.ModifierKeys & Keys.Shift) == Keys.Shift))
            {
                this.Cursor = Cursors.WaitCursor;

                if (Application.OpenForms["AFrmPMAlign"] == null)
                {
                    int nType = cmbType.SelectedIndex;
                    AFrmPMAlign dlg = new AFrmPMAlign(nType, nPoint, nToolIndex);
                    dlg.Show(this);
                }

                this.Cursor = Cursors.Default;
            }
        }

        private void SetLightControl(int nType, int nPoint, int nStep)
        {
            AIniLight aIni = new AIniLight(nType, nPoint);
            aIni.Read();

            APoint aPoint = AVisionProBuild.GetPoint(nType, nPoint);
#if (!_USE_BASLER_PYLON)
            aPoint.GetAcq().Exposure = Convert.ToDouble(aIni.m_pstrExposure[nStep]);
#elif _USE_BASLER_PYLON
            ABaslerPylon.SetExposureTime(aPoint.m_strDevName, Convert.ToInt32(aIni.m_pstrExposure[nStep]));
#endif
            int nIndex = Convert.ToInt32(aIni.m_strIndex);
            int nChannel = Convert.ToInt32(aIni.m_strChannel);
            int nLed = Convert.ToInt32(aIni.m_pstrLed[nStep]);
            if (nIndex != -1)
            {
                m_pACommLightControl[nIndex].SendToVal(nChannel, nLed);
                AUtil.Delay(ASDef._DELAY_LIGHT_CONTROL);
            }
        }

        //-------------------------------------------------------------
        #endregion

    }
}
