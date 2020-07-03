namespace KMC_S2_CHT
{
    partial class FrmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /* 2014.10.04
        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        */
        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.tmrFileDel = new System.Windows.Forms.Timer(this.components);
            this.tmrReconnect = new System.Windows.Forms.Timer(this.components);
            this.tmrSaveJpeg = new System.Windows.Forms.Timer(this.components);
            this.lstbxMessage = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.aioMapOUT = new ATMC.Controls.AIOMapControl();
            this.aioMapIN = new ATMC.Controls.AIOMapControl();
            this._lblResult = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblStateCommPLC_R = new System.Windows.Forms.Label();
            this.lblStateCommRbtL = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.btnAuto = new System.Windows.Forms.Button();
            this._grpbxCommState = new System.Windows.Forms.GroupBox();
            this.label38 = new System.Windows.Forms.Label();
            this.lblStateCommRbtR = new System.Windows.Forms.Label();
            this.lblStateCommPLC_W = new System.Windows.Forms.Label();
            this.btnLimitSet = new System.Windows.Forms.Button();
            this.btnManual3D = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.cmbLoadImg = new System.Windows.Forms.ComboBox();
            this.lblAuto = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.lblBodyNo = new System.Windows.Forms.Label();
            this.lblSeqNo = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this._lblCar = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.btnTypeSet = new System.Windows.Forms.Button();
            this.btnFileDel = new System.Windows.Forms.Button();
            this.imglstCase = new System.Windows.Forms.ImageList(this.components);
            this.tmrLive = new System.Windows.Forms.Timer(this.components);
            this.btnExposure = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrGigEReconnect = new System.Windows.Forms.Timer(this.components);
            this.tc3D_2D = new System.Windows.Forms.TabControl();
            this.TC1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnManualP3 = new System.Windows.Forms.Button();
            this.btnManualP2 = new System.Windows.Forms.Button();
            this.btnManualP1 = new System.Windows.Forms.Button();
            this.btnLengthLoad = new System.Windows.Forms.Button();
            this.cogDisplayStatusBarP3_R = new Cognex.VisionPro.CogDisplayStatusBarV2();
            this.cogDisplayStatusBarP2_R = new Cognex.VisionPro.CogDisplayStatusBarV2();
            this.cogDisplayStatusBarP1_R = new Cognex.VisionPro.CogDisplayStatusBarV2();
            this.cogDisplayStatusBarP3_L = new Cognex.VisionPro.CogDisplayStatusBarV2();
            this.cogDisplayStatusBarP2_L = new Cognex.VisionPro.CogDisplayStatusBarV2();
            this.label2 = new System.Windows.Forms.Label();
            this.lblY_P3R = new System.Windows.Forms.Label();
            this.lblX_P3R = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.lblY_P3L = new System.Windows.Forms.Label();
            this.lblX_P3L = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lblY_P2R = new System.Windows.Forms.Label();
            this.lblX_P2R = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.lblY_P2L = new System.Windows.Forms.Label();
            this.lblX_P2L = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblY_P1R = new System.Windows.Forms.Label();
            this.lblX_P1R = new System.Windows.Forms.Label();
            this.cogDisplayStatusBarP1_L = new Cognex.VisionPro.CogDisplayStatusBarV2();
            this.label3 = new System.Windows.Forms.Label();
            this.lblY_P1L = new System.Windows.Forms.Label();
            this.lblX_P1L = new System.Windows.Forms.Label();
            this.lblZ_CalibSubP3 = new System.Windows.Forms.Label();
            this.lblY_CalibSubP3 = new System.Windows.Forms.Label();
            this.lblX_CalibSubP3 = new System.Windows.Forms.Label();
            this.lblZ_CalibSubP2 = new System.Windows.Forms.Label();
            this.lblY_CalibSubP2 = new System.Windows.Forms.Label();
            this.lblX_CalibSubP2 = new System.Windows.Forms.Label();
            this.lblZ_CalibSubP1 = new System.Windows.Forms.Label();
            this.lblY_CalibSubP1 = new System.Windows.Forms.Label();
            this.lblX_CalibSubP1 = new System.Windows.Forms.Label();
            this.chkLiveSearchP3 = new System.Windows.Forms.CheckBox();
            this.chkLiveSearchP2 = new System.Windows.Forms.CheckBox();
            this.chkLiveSearchP1 = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblZ_CalibP3 = new System.Windows.Forms.Label();
            this.lblY_CalibP3 = new System.Windows.Forms.Label();
            this.lblX_CalibP3 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblZ_CalibP2 = new System.Windows.Forms.Label();
            this.lblY_CalibP2 = new System.Windows.Forms.Label();
            this.lblX_CalibP2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblZ_P2 = new System.Windows.Forms.Label();
            this.lblY_P2 = new System.Windows.Forms.Label();
            this.lblX_P2 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.lblZ_P3 = new System.Windows.Forms.Label();
            this.lblY_P3 = new System.Windows.Forms.Label();
            this.lblX_P3 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.chkLiveP3 = new System.Windows.Forms.CheckBox();
            this.chkLiveP2 = new System.Windows.Forms.CheckBox();
            this.chkLiveP1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblZ_CalibP1 = new System.Windows.Forms.Label();
            this.lblY_CalibP1 = new System.Windows.Forms.Label();
            this.lblX_CalibP1 = new System.Windows.Forms.Label();
            this.lblZ_P1 = new System.Windows.Forms.Label();
            this.lblY_P1 = new System.Windows.Forms.Label();
            this.lblX_P1 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblCalibP2 = new System.Windows.Forms.Label();
            this.lblTitleP2 = new System.Windows.Forms.Label();
            this.lblCalibP3 = new System.Windows.Forms.Label();
            this.lblTitleP3 = new System.Windows.Forms.Label();
            this.lblCalibP1 = new System.Windows.Forms.Label();
            this.lblTitleP1 = new System.Windows.Forms.Label();
            this.cogDisplayP3_R = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplayP3_L = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplayP2_R = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplayP1_L = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplayP2_L = new Cognex.VisionPro.Display.CogDisplay();
            this.cogDisplayP1_R = new Cognex.VisionPro.Display.CogDisplay();
            this.btnLengthSet = new System.Windows.Forms.Button();
            this.btnPartOffsetSet = new System.Windows.Forms.Button();
            this.TC2 = new System.Windows.Forms.TabPage();
            this.btnManualRH2_R = new System.Windows.Forms.Button();
            this.btnManualLH2_R = new System.Windows.Forms.Button();
            this.btnManualRH1_R = new System.Windows.Forms.Button();
            this.btnManualLH1_R = new System.Windows.Forms.Button();
            this.btnManualRH2_L = new System.Windows.Forms.Button();
            this.btnManualLH2_L = new System.Windows.Forms.Button();
            this.btnManualRH1_L = new System.Windows.Forms.Button();
            this.btnManualLH1_L = new System.Windows.Forms.Button();
            this.btnOffsetSetRH2_R = new System.Windows.Forms.Button();
            this.btnOffsetSetLH2_R = new System.Windows.Forms.Button();
            this.btnOffsetSetRH1_R = new System.Windows.Forms.Button();
            this.btnOffsetSetLH1_R = new System.Windows.Forms.Button();
            this.btnOffsetSetRH2_L = new System.Windows.Forms.Button();
            this.btnOffsetSetLH2_L = new System.Windows.Forms.Button();
            this.btnOffsetSetRH1_L = new System.Windows.Forms.Button();
            this.btnOffsetSetLH1_L = new System.Windows.Forms.Button();
            this.lblY_RH2_R = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.lblX_RH2_R = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.lblY_RH1_R = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.lblX_RH1_R = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.lblY_LH2_R = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.lblX_LH2_R = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.lblY_LH1_R = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.lblX_LH1_R = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.lblY_RH2_L = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblX_RH2_L = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lblY_RH1_L = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.lblX_RH1_L = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.lblY_LH2_L = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblX_LH2_L = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblY_LH1_L = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblX_LH1_L = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cogDisplayRH2_L = new Cognex.VisionPro.Display.CogDisplay();
            this.lblTitleRH2_L = new System.Windows.Forms.Label();
            this.cogDisplayRH1_R = new Cognex.VisionPro.Display.CogDisplay();
            this.lblTitleRH1_R = new System.Windows.Forms.Label();
            this.cogDisplayRH2_R = new Cognex.VisionPro.Display.CogDisplay();
            this.lblTitleRH2_R = new System.Windows.Forms.Label();
            this.cogDisplayRH1_L = new Cognex.VisionPro.Display.CogDisplay();
            this.lblTitleRH1_L = new System.Windows.Forms.Label();
            this.cogDisplayLH2_L = new Cognex.VisionPro.Display.CogDisplay();
            this.lblTitleLH2_L = new System.Windows.Forms.Label();
            this.cogDisplayLH1_R = new Cognex.VisionPro.Display.CogDisplay();
            this.lblTitleLH1_R = new System.Windows.Forms.Label();
            this.cogDisplayLH2_R = new Cognex.VisionPro.Display.CogDisplay();
            this.lblTitleLH2_R = new System.Windows.Forms.Label();
            this.cogDisplayLH1_L = new Cognex.VisionPro.Display.CogDisplay();
            this.lblTitleLH1_L = new System.Windows.Forms.Label();
            this.lblP1_P2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblResultP1 = new System.Windows.Forms.Label();
            this.grpbxShift = new System.Windows.Forms.GroupBox();
            this.lblAZ = new System.Windows.Forms.Label();
            this.lblAY = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.lblAX = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.lblZ = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.lblP1_P3 = new System.Windows.Forms.Label();
            this.lblXY_XX = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.lblP2_P3 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.lblResultP2 = new System.Windows.Forms.Label();
            this.lblResultP3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            this._grpbxCommState.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tc3D_2D.SuspendLayout();
            this.TC1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayP3_R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayP3_L)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayP2_R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayP1_L)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayP2_L)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayP1_R)).BeginInit();
            this.TC2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayRH2_L)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayRH1_R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayRH2_R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayRH1_L)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayLH2_L)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayLH1_R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayLH2_R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayLH1_L)).BeginInit();
            this.grpbxShift.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrFileDel
            // 
            this.tmrFileDel.Enabled = true;
            this.tmrFileDel.Interval = 50000;
            this.tmrFileDel.Tick += new System.EventHandler(this.tmrFileDel_Tick);
            // 
            // tmrReconnect
            // 
            this.tmrReconnect.Interval = 5000;
            this.tmrReconnect.Tick += new System.EventHandler(this.tmrReconnect_Tick);
            // 
            // tmrSaveJpeg
            // 
            this.tmrSaveJpeg.Interval = 1000;
            this.tmrSaveJpeg.Tick += new System.EventHandler(this.tmrSaveJpeg_Tick);
            // 
            // lstbxMessage
            // 
            this.lstbxMessage.FormattingEnabled = true;
            this.lstbxMessage.HorizontalScrollbar = true;
            this.lstbxMessage.ItemHeight = 12;
            this.lstbxMessage.Location = new System.Drawing.Point(839, 619);
            this.lstbxMessage.Name = "lstbxMessage";
            this.lstbxMessage.Size = new System.Drawing.Size(172, 340);
            this.lstbxMessage.TabIndex = 438;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox3.Controls.Add(this.aioMapOUT);
            this.groupBox3.Controls.Add(this.aioMapIN);
            this.groupBox3.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox3.Location = new System.Drawing.Point(1014, 612);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(245, 348);
            this.groupBox3.TabIndex = 436;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PLC I/O";
            // 
            // aioMapOUT
            // 
            this.aioMapOUT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(28)))));
            this.aioMapOUT.ColumnCount = 1;
            this.aioMapOUT.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.aioMapOUT.ForeColor = System.Drawing.Color.White;
            this.aioMapOUT.ItemBkColor = System.Drawing.Color.White;
            this.aioMapOUT.ItemBkColorOn = System.Drawing.Color.GreenYellow;
            this.aioMapOUT.ItemColor = System.Drawing.Color.Black;
            this.aioMapOUT.ItemCounts = 16;
            this.aioMapOUT.ItemHeight = 19;
            this.aioMapOUT.Items = new string[] {
        "0.",
        "1.",
        "2.",
        "3.",
        "4.",
        "5.",
        "6.",
        "7.",
        "8.",
        "9.",
        "10.",
        "11.",
        "12.",
        "13.",
        "14.",
        "15."};
            this.aioMapOUT.Location = new System.Drawing.Point(123, 17);
            this.aioMapOUT.Name = "aioMapOUT";
            this.aioMapOUT.Size = new System.Drawing.Size(116, 329);
            this.aioMapOUT.TabIndex = 410;
            this.aioMapOUT.Title = "OUTPUT";
            this.aioMapOUT.TitleBkColor = System.Drawing.Color.Gray;
            this.aioMapOUT.TitleColor = System.Drawing.Color.Gold;
            this.aioMapOUT.TitleFont = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.aioMapOUT.TitleHeight = 23;
            this.aioMapOUT.evtTitleDblClick += new ATMC.Controls.AIOMapControl.eventTitleDblClick(this.aioMapOUT_evtTitleDblClick);
            this.aioMapOUT.evtItemDblClick += new ATMC.Controls.AIOMapControl.eventItemDblClick(this.aioMapOUT_evtItemDblClick);
            // 
            // aioMapIN
            // 
            this.aioMapIN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(25)))), ((int)(((byte)(28)))));
            this.aioMapIN.ColumnCount = 1;
            this.aioMapIN.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.aioMapIN.ForeColor = System.Drawing.Color.White;
            this.aioMapIN.ItemBkColor = System.Drawing.Color.White;
            this.aioMapIN.ItemBkColorOn = System.Drawing.Color.GreenYellow;
            this.aioMapIN.ItemColor = System.Drawing.Color.Black;
            this.aioMapIN.ItemCounts = 16;
            this.aioMapIN.ItemHeight = 19;
            this.aioMapIN.Items = new string[] {
        "0.",
        "1.",
        "2.",
        "3.",
        "4.",
        "5.",
        "6.",
        "7.",
        "8.",
        "9.",
        "10.",
        "11.",
        "12.",
        "13.",
        "14.",
        "15."};
            this.aioMapIN.Location = new System.Drawing.Point(6, 17);
            this.aioMapIN.Name = "aioMapIN";
            this.aioMapIN.Size = new System.Drawing.Size(116, 329);
            this.aioMapIN.TabIndex = 409;
            this.aioMapIN.Title = "INPUT";
            this.aioMapIN.TitleBkColor = System.Drawing.Color.Gray;
            this.aioMapIN.TitleColor = System.Drawing.Color.Gold;
            this.aioMapIN.TitleFont = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.aioMapIN.TitleHeight = 23;
            this.aioMapIN.evtTitleDblClick += new ATMC.Controls.AIOMapControl.eventTitleDblClick(this.aioMapIN_evtTitleDblClick);
            this.aioMapIN.evtItemDblClick += new ATMC.Controls.AIOMapControl.eventItemDblClick(this.aioMapIN_evtItemDblClick);
            // 
            // _lblResult
            // 
            this._lblResult.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this._lblResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lblResult.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this._lblResult.ForeColor = System.Drawing.Color.White;
            this._lblResult.Location = new System.Drawing.Point(839, 256);
            this._lblResult.Name = "_lblResult";
            this._lblResult.Size = new System.Drawing.Size(160, 25);
            this._lblResult.TabIndex = 446;
            this._lblResult.Text = "결과";
            this._lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResult
            // 
            this.lblResult.BackColor = System.Drawing.Color.Chartreuse;
            this.lblResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblResult.Font = new System.Drawing.Font("Arial Black", 30F, System.Drawing.FontStyle.Bold);
            this.lblResult.ForeColor = System.Drawing.Color.Black;
            this.lblResult.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblResult.Location = new System.Drawing.Point(839, 283);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(161, 94);
            this.lblResult.TabIndex = 447;
            this.lblResult.Text = "OK !";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblResult.DoubleClick += new System.EventHandler(this.lblResult_DoubleClick);
            // 
            // lblStateCommPLC_R
            // 
            this.lblStateCommPLC_R.BackColor = System.Drawing.Color.Chartreuse;
            this.lblStateCommPLC_R.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStateCommPLC_R.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStateCommPLC_R.ForeColor = System.Drawing.Color.White;
            this.lblStateCommPLC_R.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblStateCommPLC_R.Location = new System.Drawing.Point(5, 35);
            this.lblStateCommPLC_R.Name = "lblStateCommPLC_R";
            this.lblStateCommPLC_R.Size = new System.Drawing.Size(35, 24);
            this.lblStateCommPLC_R.TabIndex = 466;
            this.lblStateCommPLC_R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStateCommPLC_R.DoubleClick += new System.EventHandler(this.lblStateCommPLC_R_DoubleClick);
            // 
            // lblStateCommRbtL
            // 
            this.lblStateCommRbtL.BackColor = System.Drawing.Color.GreenYellow;
            this.lblStateCommRbtL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStateCommRbtL.Font = new System.Drawing.Font("Gulim", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStateCommRbtL.ForeColor = System.Drawing.Color.White;
            this.lblStateCommRbtL.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblStateCommRbtL.Location = new System.Drawing.Point(80, 36);
            this.lblStateCommRbtL.Name = "lblStateCommRbtL";
            this.lblStateCommRbtL.Size = new System.Drawing.Size(35, 24);
            this.lblStateCommRbtL.TabIndex = 465;
            this.lblStateCommRbtL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Gray;
            this.label19.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.Color.Cornsilk;
            this.label19.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label19.Location = new System.Drawing.Point(80, 17);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(70, 18);
            this.label19.TabIndex = 464;
            this.label19.Text = "로봇 통신";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAuto
            // 
            this.btnAuto.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnAuto.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAuto.ForeColor = System.Drawing.Color.Black;
            this.btnAuto.Location = new System.Drawing.Point(1134, 19);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(127, 49);
            this.btnAuto.TabIndex = 472;
            this.btnAuto.Text = "자동/수동";
            this.btnAuto.UseVisualStyleBackColor = false;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // _grpbxCommState
            // 
            this._grpbxCommState.Controls.Add(this.label38);
            this._grpbxCommState.Controls.Add(this.lblStateCommRbtR);
            this._grpbxCommState.Controls.Add(this.lblStateCommPLC_W);
            this._grpbxCommState.Controls.Add(this.label19);
            this._grpbxCommState.Controls.Add(this.lblStateCommRbtL);
            this._grpbxCommState.Controls.Add(this.lblStateCommPLC_R);
            this._grpbxCommState.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this._grpbxCommState.Location = new System.Drawing.Point(840, 187);
            this._grpbxCommState.Name = "_grpbxCommState";
            this._grpbxCommState.Size = new System.Drawing.Size(156, 66);
            this._grpbxCommState.TabIndex = 480;
            this._grpbxCommState.TabStop = false;
            this._grpbxCommState.Text = "통신상태";
            // 
            // label38
            // 
            this.label38.BackColor = System.Drawing.Color.Gray;
            this.label38.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.label38.ForeColor = System.Drawing.Color.Cornsilk;
            this.label38.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label38.Location = new System.Drawing.Point(6, 17);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(69, 18);
            this.label38.TabIndex = 803;
            this.label38.Text = "PLC 통신";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStateCommRbtR
            // 
            this.lblStateCommRbtR.BackColor = System.Drawing.Color.GreenYellow;
            this.lblStateCommRbtR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStateCommRbtR.Font = new System.Drawing.Font("Gulim", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStateCommRbtR.ForeColor = System.Drawing.Color.White;
            this.lblStateCommRbtR.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblStateCommRbtR.Location = new System.Drawing.Point(115, 36);
            this.lblStateCommRbtR.Name = "lblStateCommRbtR";
            this.lblStateCommRbtR.Size = new System.Drawing.Size(35, 24);
            this.lblStateCommRbtR.TabIndex = 468;
            this.lblStateCommRbtR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStateCommPLC_W
            // 
            this.lblStateCommPLC_W.BackColor = System.Drawing.Color.Chartreuse;
            this.lblStateCommPLC_W.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStateCommPLC_W.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStateCommPLC_W.ForeColor = System.Drawing.Color.White;
            this.lblStateCommPLC_W.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblStateCommPLC_W.Location = new System.Drawing.Point(40, 35);
            this.lblStateCommPLC_W.Name = "lblStateCommPLC_W";
            this.lblStateCommPLC_W.Size = new System.Drawing.Size(35, 24);
            this.lblStateCommPLC_W.TabIndex = 467;
            this.lblStateCommPLC_W.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLimitSet
            // 
            this.btnLimitSet.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnLimitSet.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLimitSet.Location = new System.Drawing.Point(1134, 281);
            this.btnLimitSet.Name = "btnLimitSet";
            this.btnLimitSet.Size = new System.Drawing.Size(122, 45);
            this.btnLimitSet.TabIndex = 501;
            this.btnLimitSet.Text = "리미트 설정";
            this.btnLimitSet.UseVisualStyleBackColor = false;
            this.btnLimitSet.Click += new System.EventHandler(this.btnLimitSet_Click);
            // 
            // btnManual3D
            // 
            this.btnManual3D.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnManual3D.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnManual3D.Location = new System.Drawing.Point(696, 744);
            this.btnManual3D.Name = "btnManual3D";
            this.btnManual3D.Size = new System.Drawing.Size(122, 35);
            this.btnManual3D.TabIndex = 505;
            this.btnManual3D.Text = "3D 계산";
            this.btnManual3D.UseVisualStyleBackColor = false;
            this.btnManual3D.Click += new System.EventHandler(this.btnManual3D_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnExit.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExit.Location = new System.Drawing.Point(1134, 333);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(122, 45);
            this.btnExit.TabIndex = 513;
            this.btnExit.Text = "종료";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cmbLoadImg
            // 
            this.cmbLoadImg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLoadImg.FormattingEnabled = true;
            this.cmbLoadImg.Items.AddRange(new object[] {
            "카메라영상",
            "저장영상"});
            this.cmbLoadImg.Location = new System.Drawing.Point(313, 82);
            this.cmbLoadImg.Name = "cmbLoadImg";
            this.cmbLoadImg.Size = new System.Drawing.Size(95, 20);
            this.cmbLoadImg.TabIndex = 571;
            // 
            // lblAuto
            // 
            this.lblAuto.BackColor = System.Drawing.Color.Black;
            this.lblAuto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAuto.Font = new System.Drawing.Font("Gulim", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAuto.ForeColor = System.Drawing.Color.Yellow;
            this.lblAuto.Location = new System.Drawing.Point(840, 21);
            this.lblAuto.Name = "lblAuto";
            this.lblAuto.Size = new System.Drawing.Size(291, 47);
            this.lblAuto.TabIndex = 638;
            this.lblAuto.Text = "AUTO(RUN)";
            this.lblAuto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label52);
            this.groupBox2.Controls.Add(this.label51);
            this.groupBox2.Controls.Add(this.label50);
            this.groupBox2.Controls.Add(this.lblBodyNo);
            this.groupBox2.Controls.Add(this.lblSeqNo);
            this.groupBox2.Controls.Add(this.lblType);
            this.groupBox2.Controls.Add(this._lblCar);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cmbType);
            this.groupBox2.Controls.Add(this.cmbLoadImg);
            this.groupBox2.Location = new System.Drawing.Point(843, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(421, 111);
            this.groupBox2.TabIndex = 639;
            this.groupBox2.TabStop = false;
            // 
            // label52
            // 
            this.label52.BackColor = System.Drawing.Color.Gray;
            this.label52.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label52.ForeColor = System.Drawing.Color.Cornsilk;
            this.label52.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label52.Location = new System.Drawing.Point(310, 59);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(98, 21);
            this.label52.TabIndex = 806;
            this.label52.Text = "이미지 소스";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label51
            // 
            this.label51.BackColor = System.Drawing.Color.Gray;
            this.label51.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Bold);
            this.label51.ForeColor = System.Drawing.Color.Cornsilk;
            this.label51.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label51.Location = new System.Drawing.Point(11, 76);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(79, 24);
            this.label51.TabIndex = 805;
            this.label51.Text = "Body No.";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label50
            // 
            this.label50.BackColor = System.Drawing.Color.Gray;
            this.label50.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Bold);
            this.label50.ForeColor = System.Drawing.Color.Cornsilk;
            this.label50.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label50.Location = new System.Drawing.Point(11, 47);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(79, 24);
            this.label50.TabIndex = 804;
            this.label50.Text = "CMT.No";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBodyNo
            // 
            this.lblBodyNo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblBodyNo.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblBodyNo.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblBodyNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblBodyNo.Location = new System.Drawing.Point(94, 76);
            this.lblBodyNo.Name = "lblBodyNo";
            this.lblBodyNo.Size = new System.Drawing.Size(133, 24);
            this.lblBodyNo.TabIndex = 803;
            this.lblBodyNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSeqNo
            // 
            this.lblSeqNo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblSeqNo.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblSeqNo.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblSeqNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblSeqNo.Location = new System.Drawing.Point(94, 47);
            this.lblSeqNo.Name = "lblSeqNo";
            this.lblSeqNo.Size = new System.Drawing.Size(133, 24);
            this.lblSeqNo.TabIndex = 802;
            this.lblSeqNo.Text = "1234";
            this.lblSeqNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblType
            // 
            this.lblType.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblType.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblType.ForeColor = System.Drawing.Color.Cornsilk;
            this.lblType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblType.Location = new System.Drawing.Point(94, 19);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(133, 24);
            this.lblType.TabIndex = 505;
            this.lblType.Text = "RB4";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lblCar
            // 
            this._lblCar.BackColor = System.Drawing.Color.Gray;
            this._lblCar.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Bold);
            this._lblCar.ForeColor = System.Drawing.Color.Cornsilk;
            this._lblCar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._lblCar.Location = new System.Drawing.Point(11, 19);
            this._lblCar.Name = "_lblCar";
            this._lblCar.Size = new System.Drawing.Size(79, 24);
            this._lblCar.TabIndex = 504;
            this._lblCar.Text = "차종";
            this._lblCar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Gray;
            this.label10.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Cornsilk;
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(-94, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 18);
            this.label10.TabIndex = 500;
            this.label10.Text = "PLC";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(233, 19);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(120, 20);
            this.cmbType.TabIndex = 503;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // btnTypeSet
            // 
            this.btnTypeSet.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold);
            this.btnTypeSet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTypeSet.Location = new System.Drawing.Point(1009, 231);
            this.btnTypeSet.Name = "btnTypeSet";
            this.btnTypeSet.Size = new System.Drawing.Size(122, 45);
            this.btnTypeSet.TabIndex = 726;
            this.btnTypeSet.Text = "차종 설정";
            this.btnTypeSet.UseVisualStyleBackColor = true;
            this.btnTypeSet.Click += new System.EventHandler(this.btnTypeSet_Click);
            // 
            // btnFileDel
            // 
            this.btnFileDel.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFileDel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnFileDel.Location = new System.Drawing.Point(1009, 282);
            this.btnFileDel.Name = "btnFileDel";
            this.btnFileDel.Size = new System.Drawing.Size(122, 45);
            this.btnFileDel.TabIndex = 727;
            this.btnFileDel.Text = "파일 삭제 설정";
            this.btnFileDel.UseVisualStyleBackColor = true;
            this.btnFileDel.Click += new System.EventHandler(this.btnFileDel_Click);
            // 
            // imglstCase
            // 
            this.imglstCase.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglstCase.ImageStream")));
            this.imglstCase.TransparentColor = System.Drawing.Color.Transparent;
            this.imglstCase.Images.SetKeyName(0, "0.bmp");
            this.imglstCase.Images.SetKeyName(1, "1.bmp");
            this.imglstCase.Images.SetKeyName(2, "2.bmp");
            this.imglstCase.Images.SetKeyName(3, "3.bmp");
            this.imglstCase.Images.SetKeyName(4, "4.bmp");
            // 
            // tmrLive
            // 
            this.tmrLive.Interval = 500;
            this.tmrLive.Tick += new System.EventHandler(this.tmrLive_Tick);
            // 
            // btnExposure
            // 
            this.btnExposure.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExposure.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnExposure.Location = new System.Drawing.Point(1009, 333);
            this.btnExposure.Name = "btnExposure";
            this.btnExposure.Size = new System.Drawing.Size(122, 45);
            this.btnExposure.TabIndex = 1290;
            this.btnExposure.Text = "조명 설정";
            this.btnExposure.UseVisualStyleBackColor = true;
            this.btnExposure.Click += new System.EventHandler(this.btnExposure_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.SystemColors.Control;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3});
            this.statusStrip.Location = new System.Drawing.Point(0, 965);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1264, 22);
            this.statusStrip.TabIndex = 1291;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(45, 17);
            this.toolStripStatusLabel1.Text = "HDD : ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(55, 17);
            this.toolStripStatusLabel2.Text = "Memory:";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(57, 17);
            this.toolStripStatusLabel3.Text = "exe Date:";
            // 
            // tmrGigEReconnect
            // 
            this.tmrGigEReconnect.Interval = 1000;
            this.tmrGigEReconnect.Tick += new System.EventHandler(this.tmrGigEReconnect_Tick);
            // 
            // tc3D_2D
            // 
            this.tc3D_2D.Controls.Add(this.TC1);
            this.tc3D_2D.Controls.Add(this.TC2);
            this.tc3D_2D.Location = new System.Drawing.Point(0, -1);
            this.tc3D_2D.Name = "tc3D_2D";
            this.tc3D_2D.SelectedIndex = 0;
            this.tc3D_2D.Size = new System.Drawing.Size(834, 965);
            this.tc3D_2D.TabIndex = 1293;
            // 
            // TC1
            // 
            this.TC1.BackColor = System.Drawing.Color.Gainsboro;
            this.TC1.Controls.Add(this.pictureBox1);
            this.TC1.Controls.Add(this.btnManualP3);
            this.TC1.Controls.Add(this.btnManualP2);
            this.TC1.Controls.Add(this.btnManualP1);
            this.TC1.Controls.Add(this.btnLengthLoad);
            this.TC1.Controls.Add(this.cogDisplayStatusBarP3_R);
            this.TC1.Controls.Add(this.cogDisplayStatusBarP2_R);
            this.TC1.Controls.Add(this.cogDisplayStatusBarP1_R);
            this.TC1.Controls.Add(this.cogDisplayStatusBarP3_L);
            this.TC1.Controls.Add(this.cogDisplayStatusBarP2_L);
            this.TC1.Controls.Add(this.btnManual3D);
            this.TC1.Controls.Add(this.label2);
            this.TC1.Controls.Add(this.lblY_P3R);
            this.TC1.Controls.Add(this.lblX_P3R);
            this.TC1.Controls.Add(this.label43);
            this.TC1.Controls.Add(this.lblY_P3L);
            this.TC1.Controls.Add(this.lblX_P3L);
            this.TC1.Controls.Add(this.label26);
            this.TC1.Controls.Add(this.lblY_P2R);
            this.TC1.Controls.Add(this.lblX_P2R);
            this.TC1.Controls.Add(this.label30);
            this.TC1.Controls.Add(this.lblY_P2L);
            this.TC1.Controls.Add(this.lblX_P2L);
            this.TC1.Controls.Add(this.label23);
            this.TC1.Controls.Add(this.lblY_P1R);
            this.TC1.Controls.Add(this.lblX_P1R);
            this.TC1.Controls.Add(this.cogDisplayStatusBarP1_L);
            this.TC1.Controls.Add(this.label3);
            this.TC1.Controls.Add(this.lblY_P1L);
            this.TC1.Controls.Add(this.lblX_P1L);
            this.TC1.Controls.Add(this.lblZ_CalibSubP3);
            this.TC1.Controls.Add(this.lblY_CalibSubP3);
            this.TC1.Controls.Add(this.lblX_CalibSubP3);
            this.TC1.Controls.Add(this.lblZ_CalibSubP2);
            this.TC1.Controls.Add(this.lblY_CalibSubP2);
            this.TC1.Controls.Add(this.lblX_CalibSubP2);
            this.TC1.Controls.Add(this.lblZ_CalibSubP1);
            this.TC1.Controls.Add(this.lblY_CalibSubP1);
            this.TC1.Controls.Add(this.lblX_CalibSubP1);
            this.TC1.Controls.Add(this.chkLiveSearchP3);
            this.TC1.Controls.Add(this.chkLiveSearchP2);
            this.TC1.Controls.Add(this.chkLiveSearchP1);
            this.TC1.Controls.Add(this.label16);
            this.TC1.Controls.Add(this.label14);
            this.TC1.Controls.Add(this.label13);
            this.TC1.Controls.Add(this.label9);
            this.TC1.Controls.Add(this.lblZ_CalibP3);
            this.TC1.Controls.Add(this.lblY_CalibP3);
            this.TC1.Controls.Add(this.lblX_CalibP3);
            this.TC1.Controls.Add(this.label22);
            this.TC1.Controls.Add(this.lblZ_CalibP2);
            this.TC1.Controls.Add(this.lblY_CalibP2);
            this.TC1.Controls.Add(this.lblX_CalibP2);
            this.TC1.Controls.Add(this.label15);
            this.TC1.Controls.Add(this.lblZ_P2);
            this.TC1.Controls.Add(this.lblY_P2);
            this.TC1.Controls.Add(this.lblX_P2);
            this.TC1.Controls.Add(this.label58);
            this.TC1.Controls.Add(this.lblZ_P3);
            this.TC1.Controls.Add(this.lblY_P3);
            this.TC1.Controls.Add(this.lblX_P3);
            this.TC1.Controls.Add(this.label41);
            this.TC1.Controls.Add(this.chkLiveP3);
            this.TC1.Controls.Add(this.chkLiveP2);
            this.TC1.Controls.Add(this.chkLiveP1);
            this.TC1.Controls.Add(this.label4);
            this.TC1.Controls.Add(this.label5);
            this.TC1.Controls.Add(this.lblZ_CalibP1);
            this.TC1.Controls.Add(this.lblY_CalibP1);
            this.TC1.Controls.Add(this.lblX_CalibP1);
            this.TC1.Controls.Add(this.lblZ_P1);
            this.TC1.Controls.Add(this.lblY_P1);
            this.TC1.Controls.Add(this.lblX_P1);
            this.TC1.Controls.Add(this.label56);
            this.TC1.Controls.Add(this.label7);
            this.TC1.Controls.Add(this.lblCalibP2);
            this.TC1.Controls.Add(this.lblTitleP2);
            this.TC1.Controls.Add(this.lblCalibP3);
            this.TC1.Controls.Add(this.lblTitleP3);
            this.TC1.Controls.Add(this.lblCalibP1);
            this.TC1.Controls.Add(this.lblTitleP1);
            this.TC1.Controls.Add(this.cogDisplayP3_R);
            this.TC1.Controls.Add(this.cogDisplayP3_L);
            this.TC1.Controls.Add(this.cogDisplayP2_R);
            this.TC1.Controls.Add(this.cogDisplayP1_L);
            this.TC1.Controls.Add(this.cogDisplayP2_L);
            this.TC1.Controls.Add(this.cogDisplayP1_R);
            this.TC1.Controls.Add(this.btnLengthSet);
            this.TC1.Controls.Add(this.btnPartOffsetSet);
            this.TC1.Location = new System.Drawing.Point(4, 22);
            this.TC1.Name = "TC1";
            this.TC1.Padding = new System.Windows.Forms.Padding(3);
            this.TC1.Size = new System.Drawing.Size(826, 939);
            this.TC1.TabIndex = 0;
            this.TC1.Text = "3D";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::KMC_S2_CHT.Properties.Resources.기아_design;
            this.pictureBox1.Location = new System.Drawing.Point(6, 736);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(584, 192);
            this.pictureBox1.TabIndex = 1394;
            this.pictureBox1.TabStop = false;
            // 
            // btnManualP3
            // 
            this.btnManualP3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnManualP3.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnManualP3.Location = new System.Drawing.Point(731, 521);
            this.btnManualP3.Name = "btnManualP3";
            this.btnManualP3.Size = new System.Drawing.Size(85, 28);
            this.btnManualP3.TabIndex = 1393;
            this.btnManualP3.Text = "수동 측정";
            this.btnManualP3.UseVisualStyleBackColor = false;
            this.btnManualP3.Click += new System.EventHandler(this.btnManualP3_Click);
            // 
            // btnManualP2
            // 
            this.btnManualP2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnManualP2.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnManualP2.Location = new System.Drawing.Point(732, 277);
            this.btnManualP2.Name = "btnManualP2";
            this.btnManualP2.Size = new System.Drawing.Size(85, 28);
            this.btnManualP2.TabIndex = 1392;
            this.btnManualP2.Text = "수동 측정";
            this.btnManualP2.UseVisualStyleBackColor = false;
            this.btnManualP2.Click += new System.EventHandler(this.btnManualP2_Click);
            // 
            // btnManualP1
            // 
            this.btnManualP1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnManualP1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnManualP1.Location = new System.Drawing.Point(732, 41);
            this.btnManualP1.Name = "btnManualP1";
            this.btnManualP1.Size = new System.Drawing.Size(85, 28);
            this.btnManualP1.TabIndex = 1391;
            this.btnManualP1.Text = "수동 측정";
            this.btnManualP1.UseVisualStyleBackColor = false;
            this.btnManualP1.Click += new System.EventHandler(this.btnManualP1_Click);
            // 
            // btnLengthLoad
            // 
            this.btnLengthLoad.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnLengthLoad.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLengthLoad.Location = new System.Drawing.Point(759, 835);
            this.btnLengthLoad.Name = "btnLengthLoad";
            this.btnLengthLoad.Size = new System.Drawing.Size(59, 45);
            this.btnLengthLoad.TabIndex = 1390;
            this.btnLengthLoad.Text = "거리값 초기화";
            this.btnLengthLoad.UseVisualStyleBackColor = false;
            this.btnLengthLoad.Click += new System.EventHandler(this.btnLengthLoad_Click);
            // 
            // cogDisplayStatusBarP3_R
            // 
            this.cogDisplayStatusBarP3_R.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cogDisplayStatusBarP3_R.CoordinateSpaceName = "*\\#";
            this.cogDisplayStatusBarP3_R.CoordinateSpaceName3D = "*\\#";
            this.cogDisplayStatusBarP3_R.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cogDisplayStatusBarP3_R.Location = new System.Drawing.Point(411, 696);
            this.cogDisplayStatusBarP3_R.Margin = new System.Windows.Forms.Padding(0);
            this.cogDisplayStatusBarP3_R.Name = "cogDisplayStatusBarP3_R";
            this.cogDisplayStatusBarP3_R.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cogDisplayStatusBarP3_R.ShowZoomPane = false;
            this.cogDisplayStatusBarP3_R.Size = new System.Drawing.Size(321, 23);
            this.cogDisplayStatusBarP3_R.TabIndex = 1389;
            this.cogDisplayStatusBarP3_R.Use3DCoordinateSpaceTree = false;
            this.cogDisplayStatusBarP3_R.Visible = false;
            // 
            // cogDisplayStatusBarP2_R
            // 
            this.cogDisplayStatusBarP2_R.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cogDisplayStatusBarP2_R.CoordinateSpaceName = "*\\#";
            this.cogDisplayStatusBarP2_R.CoordinateSpaceName3D = "*\\#";
            this.cogDisplayStatusBarP2_R.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cogDisplayStatusBarP2_R.Location = new System.Drawing.Point(411, 455);
            this.cogDisplayStatusBarP2_R.Margin = new System.Windows.Forms.Padding(0);
            this.cogDisplayStatusBarP2_R.Name = "cogDisplayStatusBarP2_R";
            this.cogDisplayStatusBarP2_R.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cogDisplayStatusBarP2_R.ShowZoomPane = false;
            this.cogDisplayStatusBarP2_R.Size = new System.Drawing.Size(321, 23);
            this.cogDisplayStatusBarP2_R.TabIndex = 1388;
            this.cogDisplayStatusBarP2_R.Use3DCoordinateSpaceTree = false;
            this.cogDisplayStatusBarP2_R.Visible = false;
            // 
            // cogDisplayStatusBarP1_R
            // 
            this.cogDisplayStatusBarP1_R.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cogDisplayStatusBarP1_R.CoordinateSpaceName = "*\\#";
            this.cogDisplayStatusBarP1_R.CoordinateSpaceName3D = "*\\#";
            this.cogDisplayStatusBarP1_R.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cogDisplayStatusBarP1_R.Location = new System.Drawing.Point(411, 216);
            this.cogDisplayStatusBarP1_R.Margin = new System.Windows.Forms.Padding(0);
            this.cogDisplayStatusBarP1_R.Name = "cogDisplayStatusBarP1_R";
            this.cogDisplayStatusBarP1_R.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cogDisplayStatusBarP1_R.ShowZoomPane = false;
            this.cogDisplayStatusBarP1_R.Size = new System.Drawing.Size(321, 23);
            this.cogDisplayStatusBarP1_R.TabIndex = 1387;
            this.cogDisplayStatusBarP1_R.Use3DCoordinateSpaceTree = false;
            this.cogDisplayStatusBarP1_R.Visible = false;
            // 
            // cogDisplayStatusBarP3_L
            // 
            this.cogDisplayStatusBarP3_L.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cogDisplayStatusBarP3_L.CoordinateSpaceName = "*\\#";
            this.cogDisplayStatusBarP3_L.CoordinateSpaceName3D = "*\\#";
            this.cogDisplayStatusBarP3_L.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cogDisplayStatusBarP3_L.Location = new System.Drawing.Point(1, 697);
            this.cogDisplayStatusBarP3_L.Margin = new System.Windows.Forms.Padding(0);
            this.cogDisplayStatusBarP3_L.Name = "cogDisplayStatusBarP3_L";
            this.cogDisplayStatusBarP3_L.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cogDisplayStatusBarP3_L.ShowZoomPane = false;
            this.cogDisplayStatusBarP3_L.Size = new System.Drawing.Size(321, 23);
            this.cogDisplayStatusBarP3_L.TabIndex = 1386;
            this.cogDisplayStatusBarP3_L.Use3DCoordinateSpaceTree = false;
            this.cogDisplayStatusBarP3_L.Visible = false;
            // 
            // cogDisplayStatusBarP2_L
            // 
            this.cogDisplayStatusBarP2_L.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cogDisplayStatusBarP2_L.CoordinateSpaceName = "*\\#";
            this.cogDisplayStatusBarP2_L.CoordinateSpaceName3D = "*\\#";
            this.cogDisplayStatusBarP2_L.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cogDisplayStatusBarP2_L.Location = new System.Drawing.Point(1, 456);
            this.cogDisplayStatusBarP2_L.Margin = new System.Windows.Forms.Padding(0);
            this.cogDisplayStatusBarP2_L.Name = "cogDisplayStatusBarP2_L";
            this.cogDisplayStatusBarP2_L.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cogDisplayStatusBarP2_L.ShowZoomPane = false;
            this.cogDisplayStatusBarP2_L.Size = new System.Drawing.Size(321, 23);
            this.cogDisplayStatusBarP2_L.TabIndex = 1385;
            this.cogDisplayStatusBarP2_L.Use3DCoordinateSpaceTree = false;
            this.cogDisplayStatusBarP2_L.Visible = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(734, 605);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 26);
            this.label2.TabIndex = 1384;
            this.label2.Text = "X Y";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY_P3R
            // 
            this.lblY_P3R.BackColor = System.Drawing.Color.LightYellow;
            this.lblY_P3R.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblY_P3R.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblY_P3R.ForeColor = System.Drawing.Color.Black;
            this.lblY_P3R.Location = new System.Drawing.Point(751, 619);
            this.lblY_P3R.Name = "lblY_P3R";
            this.lblY_P3R.Size = new System.Drawing.Size(64, 12);
            this.lblY_P3R.TabIndex = 1383;
            this.lblY_P3R.Text = "123.12";
            this.lblY_P3R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblX_P3R
            // 
            this.lblX_P3R.BackColor = System.Drawing.Color.LightYellow;
            this.lblX_P3R.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblX_P3R.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblX_P3R.ForeColor = System.Drawing.Color.Black;
            this.lblX_P3R.Location = new System.Drawing.Point(751, 605);
            this.lblX_P3R.Name = "lblX_P3R";
            this.lblX_P3R.Size = new System.Drawing.Size(64, 12);
            this.lblX_P3R.TabIndex = 1382;
            this.lblX_P3R.Text = "123.32";
            this.lblX_P3R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label43
            // 
            this.label43.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label43.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.ForeColor = System.Drawing.Color.White;
            this.label43.Location = new System.Drawing.Point(325, 605);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(18, 26);
            this.label43.TabIndex = 1381;
            this.label43.Text = "X Y";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY_P3L
            // 
            this.lblY_P3L.BackColor = System.Drawing.Color.LightYellow;
            this.lblY_P3L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblY_P3L.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblY_P3L.ForeColor = System.Drawing.Color.Black;
            this.lblY_P3L.Location = new System.Drawing.Point(342, 619);
            this.lblY_P3L.Name = "lblY_P3L";
            this.lblY_P3L.Size = new System.Drawing.Size(64, 12);
            this.lblY_P3L.TabIndex = 1380;
            this.lblY_P3L.Text = "123.12";
            this.lblY_P3L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblX_P3L
            // 
            this.lblX_P3L.BackColor = System.Drawing.Color.LightYellow;
            this.lblX_P3L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblX_P3L.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblX_P3L.ForeColor = System.Drawing.Color.Black;
            this.lblX_P3L.Location = new System.Drawing.Point(342, 605);
            this.lblX_P3L.Name = "lblX_P3L";
            this.lblX_P3L.Size = new System.Drawing.Size(64, 12);
            this.lblX_P3L.TabIndex = 1379;
            this.lblX_P3L.Text = "123.32";
            this.lblX_P3L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label26.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.White;
            this.label26.Location = new System.Drawing.Point(734, 364);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(18, 26);
            this.label26.TabIndex = 1378;
            this.label26.Text = "X Y";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY_P2R
            // 
            this.lblY_P2R.BackColor = System.Drawing.Color.LightYellow;
            this.lblY_P2R.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblY_P2R.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblY_P2R.ForeColor = System.Drawing.Color.Black;
            this.lblY_P2R.Location = new System.Drawing.Point(751, 378);
            this.lblY_P2R.Name = "lblY_P2R";
            this.lblY_P2R.Size = new System.Drawing.Size(64, 12);
            this.lblY_P2R.TabIndex = 1377;
            this.lblY_P2R.Text = "123.12";
            this.lblY_P2R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblX_P2R
            // 
            this.lblX_P2R.BackColor = System.Drawing.Color.LightYellow;
            this.lblX_P2R.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblX_P2R.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblX_P2R.ForeColor = System.Drawing.Color.Black;
            this.lblX_P2R.Location = new System.Drawing.Point(751, 364);
            this.lblX_P2R.Name = "lblX_P2R";
            this.lblX_P2R.Size = new System.Drawing.Size(64, 12);
            this.lblX_P2R.TabIndex = 1376;
            this.lblX_P2R.Text = "123.32";
            this.lblX_P2R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.White;
            this.label30.Location = new System.Drawing.Point(325, 364);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(18, 26);
            this.label30.TabIndex = 1375;
            this.label30.Text = "X Y";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY_P2L
            // 
            this.lblY_P2L.BackColor = System.Drawing.Color.LightYellow;
            this.lblY_P2L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblY_P2L.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblY_P2L.ForeColor = System.Drawing.Color.Black;
            this.lblY_P2L.Location = new System.Drawing.Point(342, 378);
            this.lblY_P2L.Name = "lblY_P2L";
            this.lblY_P2L.Size = new System.Drawing.Size(64, 12);
            this.lblY_P2L.TabIndex = 1374;
            this.lblY_P2L.Text = "123.12";
            this.lblY_P2L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblX_P2L
            // 
            this.lblX_P2L.BackColor = System.Drawing.Color.LightYellow;
            this.lblX_P2L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblX_P2L.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblX_P2L.ForeColor = System.Drawing.Color.Black;
            this.lblX_P2L.Location = new System.Drawing.Point(342, 364);
            this.lblX_P2L.Name = "lblX_P2L";
            this.lblX_P2L.Size = new System.Drawing.Size(64, 12);
            this.lblX_P2L.TabIndex = 1373;
            this.lblX_P2L.Text = "123.32";
            this.lblX_P2L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(734, 125);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(18, 26);
            this.label23.TabIndex = 1372;
            this.label23.Text = "X Y";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY_P1R
            // 
            this.lblY_P1R.BackColor = System.Drawing.Color.LightYellow;
            this.lblY_P1R.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblY_P1R.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblY_P1R.ForeColor = System.Drawing.Color.Black;
            this.lblY_P1R.Location = new System.Drawing.Point(751, 139);
            this.lblY_P1R.Name = "lblY_P1R";
            this.lblY_P1R.Size = new System.Drawing.Size(64, 12);
            this.lblY_P1R.TabIndex = 1371;
            this.lblY_P1R.Text = "123.12";
            this.lblY_P1R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblX_P1R
            // 
            this.lblX_P1R.BackColor = System.Drawing.Color.LightYellow;
            this.lblX_P1R.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblX_P1R.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblX_P1R.ForeColor = System.Drawing.Color.Black;
            this.lblX_P1R.Location = new System.Drawing.Point(751, 125);
            this.lblX_P1R.Name = "lblX_P1R";
            this.lblX_P1R.Size = new System.Drawing.Size(64, 12);
            this.lblX_P1R.TabIndex = 1370;
            this.lblX_P1R.Text = "123.32";
            this.lblX_P1R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cogDisplayStatusBarP1_L
            // 
            this.cogDisplayStatusBarP1_L.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.cogDisplayStatusBarP1_L.CoordinateSpaceName = "*\\#";
            this.cogDisplayStatusBarP1_L.CoordinateSpaceName3D = "*\\#";
            this.cogDisplayStatusBarP1_L.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cogDisplayStatusBarP1_L.Location = new System.Drawing.Point(1, 217);
            this.cogDisplayStatusBarP1_L.Margin = new System.Windows.Forms.Padding(0);
            this.cogDisplayStatusBarP1_L.Name = "cogDisplayStatusBarP1_L";
            this.cogDisplayStatusBarP1_L.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cogDisplayStatusBarP1_L.ShowZoomPane = false;
            this.cogDisplayStatusBarP1_L.Size = new System.Drawing.Size(321, 23);
            this.cogDisplayStatusBarP1_L.TabIndex = 1369;
            this.cogDisplayStatusBarP1_L.Use3DCoordinateSpaceTree = false;
            this.cogDisplayStatusBarP1_L.Visible = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(325, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 26);
            this.label3.TabIndex = 1368;
            this.label3.Text = "X Y";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY_P1L
            // 
            this.lblY_P1L.BackColor = System.Drawing.Color.LightYellow;
            this.lblY_P1L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblY_P1L.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblY_P1L.ForeColor = System.Drawing.Color.Black;
            this.lblY_P1L.Location = new System.Drawing.Point(342, 139);
            this.lblY_P1L.Name = "lblY_P1L";
            this.lblY_P1L.Size = new System.Drawing.Size(64, 12);
            this.lblY_P1L.TabIndex = 1367;
            this.lblY_P1L.Text = "123.12";
            this.lblY_P1L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblX_P1L
            // 
            this.lblX_P1L.BackColor = System.Drawing.Color.LightYellow;
            this.lblX_P1L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblX_P1L.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblX_P1L.ForeColor = System.Drawing.Color.Black;
            this.lblX_P1L.Location = new System.Drawing.Point(342, 125);
            this.lblX_P1L.Name = "lblX_P1L";
            this.lblX_P1L.Size = new System.Drawing.Size(64, 12);
            this.lblX_P1L.TabIndex = 1366;
            this.lblX_P1L.Text = "123.32";
            this.lblX_P1L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblZ_CalibSubP3
            // 
            this.lblZ_CalibSubP3.BackColor = System.Drawing.Color.Olive;
            this.lblZ_CalibSubP3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblZ_CalibSubP3.Font = new System.Drawing.Font("Gulim", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblZ_CalibSubP3.ForeColor = System.Drawing.Color.White;
            this.lblZ_CalibSubP3.Location = new System.Drawing.Point(342, 708);
            this.lblZ_CalibSubP3.Name = "lblZ_CalibSubP3";
            this.lblZ_CalibSubP3.Size = new System.Drawing.Size(64, 11);
            this.lblZ_CalibSubP3.TabIndex = 1365;
            this.lblZ_CalibSubP3.Text = "X";
            this.lblZ_CalibSubP3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY_CalibSubP3
            // 
            this.lblY_CalibSubP3.BackColor = System.Drawing.Color.Olive;
            this.lblY_CalibSubP3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblY_CalibSubP3.Font = new System.Drawing.Font("Gulim", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblY_CalibSubP3.ForeColor = System.Drawing.Color.White;
            this.lblY_CalibSubP3.Location = new System.Drawing.Point(342, 685);
            this.lblY_CalibSubP3.Name = "lblY_CalibSubP3";
            this.lblY_CalibSubP3.Size = new System.Drawing.Size(64, 11);
            this.lblY_CalibSubP3.TabIndex = 1364;
            this.lblY_CalibSubP3.Text = "X";
            this.lblY_CalibSubP3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblX_CalibSubP3
            // 
            this.lblX_CalibSubP3.BackColor = System.Drawing.Color.Olive;
            this.lblX_CalibSubP3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblX_CalibSubP3.Font = new System.Drawing.Font("Gulim", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblX_CalibSubP3.ForeColor = System.Drawing.Color.White;
            this.lblX_CalibSubP3.Location = new System.Drawing.Point(342, 662);
            this.lblX_CalibSubP3.Name = "lblX_CalibSubP3";
            this.lblX_CalibSubP3.Size = new System.Drawing.Size(64, 11);
            this.lblX_CalibSubP3.TabIndex = 1363;
            this.lblX_CalibSubP3.Text = "123.32";
            this.lblX_CalibSubP3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblZ_CalibSubP2
            // 
            this.lblZ_CalibSubP2.BackColor = System.Drawing.Color.Olive;
            this.lblZ_CalibSubP2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblZ_CalibSubP2.Font = new System.Drawing.Font("Gulim", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblZ_CalibSubP2.ForeColor = System.Drawing.Color.White;
            this.lblZ_CalibSubP2.Location = new System.Drawing.Point(342, 467);
            this.lblZ_CalibSubP2.Name = "lblZ_CalibSubP2";
            this.lblZ_CalibSubP2.Size = new System.Drawing.Size(64, 11);
            this.lblZ_CalibSubP2.TabIndex = 1362;
            this.lblZ_CalibSubP2.Text = "X";
            this.lblZ_CalibSubP2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY_CalibSubP2
            // 
            this.lblY_CalibSubP2.BackColor = System.Drawing.Color.Olive;
            this.lblY_CalibSubP2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblY_CalibSubP2.Font = new System.Drawing.Font("Gulim", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblY_CalibSubP2.ForeColor = System.Drawing.Color.White;
            this.lblY_CalibSubP2.Location = new System.Drawing.Point(342, 444);
            this.lblY_CalibSubP2.Name = "lblY_CalibSubP2";
            this.lblY_CalibSubP2.Size = new System.Drawing.Size(64, 11);
            this.lblY_CalibSubP2.TabIndex = 1361;
            this.lblY_CalibSubP2.Text = "X";
            this.lblY_CalibSubP2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblX_CalibSubP2
            // 
            this.lblX_CalibSubP2.BackColor = System.Drawing.Color.Olive;
            this.lblX_CalibSubP2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblX_CalibSubP2.Font = new System.Drawing.Font("Gulim", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblX_CalibSubP2.ForeColor = System.Drawing.Color.White;
            this.lblX_CalibSubP2.Location = new System.Drawing.Point(342, 421);
            this.lblX_CalibSubP2.Name = "lblX_CalibSubP2";
            this.lblX_CalibSubP2.Size = new System.Drawing.Size(64, 11);
            this.lblX_CalibSubP2.TabIndex = 1360;
            this.lblX_CalibSubP2.Text = "123.32";
            this.lblX_CalibSubP2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblZ_CalibSubP1
            // 
            this.lblZ_CalibSubP1.BackColor = System.Drawing.Color.Olive;
            this.lblZ_CalibSubP1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblZ_CalibSubP1.Font = new System.Drawing.Font("Gulim", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblZ_CalibSubP1.ForeColor = System.Drawing.Color.White;
            this.lblZ_CalibSubP1.Location = new System.Drawing.Point(342, 228);
            this.lblZ_CalibSubP1.Name = "lblZ_CalibSubP1";
            this.lblZ_CalibSubP1.Size = new System.Drawing.Size(64, 11);
            this.lblZ_CalibSubP1.TabIndex = 1359;
            this.lblZ_CalibSubP1.Text = "123.12";
            this.lblZ_CalibSubP1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY_CalibSubP1
            // 
            this.lblY_CalibSubP1.BackColor = System.Drawing.Color.Olive;
            this.lblY_CalibSubP1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblY_CalibSubP1.Font = new System.Drawing.Font("Gulim", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblY_CalibSubP1.ForeColor = System.Drawing.Color.White;
            this.lblY_CalibSubP1.Location = new System.Drawing.Point(342, 205);
            this.lblY_CalibSubP1.Name = "lblY_CalibSubP1";
            this.lblY_CalibSubP1.Size = new System.Drawing.Size(64, 11);
            this.lblY_CalibSubP1.TabIndex = 1358;
            this.lblY_CalibSubP1.Text = "123.12";
            this.lblY_CalibSubP1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblX_CalibSubP1
            // 
            this.lblX_CalibSubP1.BackColor = System.Drawing.Color.Olive;
            this.lblX_CalibSubP1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblX_CalibSubP1.Font = new System.Drawing.Font("Gulim", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblX_CalibSubP1.ForeColor = System.Drawing.Color.White;
            this.lblX_CalibSubP1.Location = new System.Drawing.Point(342, 182);
            this.lblX_CalibSubP1.Name = "lblX_CalibSubP1";
            this.lblX_CalibSubP1.Size = new System.Drawing.Size(64, 11);
            this.lblX_CalibSubP1.TabIndex = 1357;
            this.lblX_CalibSubP1.Text = "123.32";
            this.lblX_CalibSubP1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkLiveSearchP3
            // 
            this.chkLiveSearchP3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.chkLiveSearchP3.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkLiveSearchP3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.chkLiveSearchP3.Location = new System.Drawing.Point(329, 536);
            this.chkLiveSearchP3.Name = "chkLiveSearchP3";
            this.chkLiveSearchP3.Size = new System.Drawing.Size(64, 28);
            this.chkLiveSearchP3.TabIndex = 1356;
            this.chkLiveSearchP3.Text = "Live Search";
            this.chkLiveSearchP3.UseVisualStyleBackColor = false;
            // 
            // chkLiveSearchP2
            // 
            this.chkLiveSearchP2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.chkLiveSearchP2.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkLiveSearchP2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.chkLiveSearchP2.Location = new System.Drawing.Point(329, 295);
            this.chkLiveSearchP2.Name = "chkLiveSearchP2";
            this.chkLiveSearchP2.Size = new System.Drawing.Size(64, 28);
            this.chkLiveSearchP2.TabIndex = 1354;
            this.chkLiveSearchP2.Text = "Live Search";
            this.chkLiveSearchP2.UseVisualStyleBackColor = false;
            // 
            // chkLiveSearchP1
            // 
            this.chkLiveSearchP1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.chkLiveSearchP1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkLiveSearchP1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.chkLiveSearchP1.Location = new System.Drawing.Point(329, 56);
            this.chkLiveSearchP1.Name = "chkLiveSearchP1";
            this.chkLiveSearchP1.Size = new System.Drawing.Size(64, 28);
            this.chkLiveSearchP1.TabIndex = 1352;
            this.chkLiveSearchP1.Text = "Live Search";
            this.chkLiveSearchP1.UseVisualStyleBackColor = false;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(734, 651);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(19, 68);
            this.label16.TabIndex = 1350;
            this.label16.Text = "X Y Z";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(325, 651);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(19, 68);
            this.label14.TabIndex = 1349;
            this.label14.Text = "X Y Z";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(734, 410);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(19, 68);
            this.label13.TabIndex = 1348;
            this.label13.Text = "X Y Z";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(325, 410);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 68);
            this.label9.TabIndex = 1347;
            this.label9.Text = "X Y Z";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblZ_CalibP3
            // 
            this.lblZ_CalibP3.BackColor = System.Drawing.Color.LightYellow;
            this.lblZ_CalibP3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblZ_CalibP3.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblZ_CalibP3.ForeColor = System.Drawing.Color.Black;
            this.lblZ_CalibP3.Location = new System.Drawing.Point(342, 697);
            this.lblZ_CalibP3.Name = "lblZ_CalibP3";
            this.lblZ_CalibP3.Size = new System.Drawing.Size(64, 12);
            this.lblZ_CalibP3.TabIndex = 1346;
            this.lblZ_CalibP3.Text = "X";
            this.lblZ_CalibP3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY_CalibP3
            // 
            this.lblY_CalibP3.BackColor = System.Drawing.Color.LightYellow;
            this.lblY_CalibP3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblY_CalibP3.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblY_CalibP3.ForeColor = System.Drawing.Color.Black;
            this.lblY_CalibP3.Location = new System.Drawing.Point(342, 674);
            this.lblY_CalibP3.Name = "lblY_CalibP3";
            this.lblY_CalibP3.Size = new System.Drawing.Size(64, 12);
            this.lblY_CalibP3.TabIndex = 1345;
            this.lblY_CalibP3.Text = "X";
            this.lblY_CalibP3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblX_CalibP3
            // 
            this.lblX_CalibP3.BackColor = System.Drawing.Color.LightYellow;
            this.lblX_CalibP3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblX_CalibP3.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblX_CalibP3.ForeColor = System.Drawing.Color.Black;
            this.lblX_CalibP3.Location = new System.Drawing.Point(342, 651);
            this.lblX_CalibP3.Name = "lblX_CalibP3";
            this.lblX_CalibP3.Size = new System.Drawing.Size(64, 12);
            this.lblX_CalibP3.TabIndex = 1344;
            this.lblX_CalibP3.Text = "X";
            this.lblX_CalibP3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label22.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(325, 631);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(81, 19);
            this.label22.TabIndex = 1343;
            this.label22.Text = "Calib";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblZ_CalibP2
            // 
            this.lblZ_CalibP2.BackColor = System.Drawing.Color.LightYellow;
            this.lblZ_CalibP2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblZ_CalibP2.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblZ_CalibP2.ForeColor = System.Drawing.Color.Black;
            this.lblZ_CalibP2.Location = new System.Drawing.Point(342, 456);
            this.lblZ_CalibP2.Name = "lblZ_CalibP2";
            this.lblZ_CalibP2.Size = new System.Drawing.Size(64, 12);
            this.lblZ_CalibP2.TabIndex = 1342;
            this.lblZ_CalibP2.Text = "X";
            this.lblZ_CalibP2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY_CalibP2
            // 
            this.lblY_CalibP2.BackColor = System.Drawing.Color.LightYellow;
            this.lblY_CalibP2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblY_CalibP2.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblY_CalibP2.ForeColor = System.Drawing.Color.Black;
            this.lblY_CalibP2.Location = new System.Drawing.Point(342, 433);
            this.lblY_CalibP2.Name = "lblY_CalibP2";
            this.lblY_CalibP2.Size = new System.Drawing.Size(64, 12);
            this.lblY_CalibP2.TabIndex = 1341;
            this.lblY_CalibP2.Text = "X";
            this.lblY_CalibP2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblX_CalibP2
            // 
            this.lblX_CalibP2.BackColor = System.Drawing.Color.LightYellow;
            this.lblX_CalibP2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblX_CalibP2.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblX_CalibP2.ForeColor = System.Drawing.Color.Black;
            this.lblX_CalibP2.Location = new System.Drawing.Point(342, 410);
            this.lblX_CalibP2.Name = "lblX_CalibP2";
            this.lblX_CalibP2.Size = new System.Drawing.Size(64, 12);
            this.lblX_CalibP2.TabIndex = 1340;
            this.lblX_CalibP2.Text = "X";
            this.lblX_CalibP2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(325, 390);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(81, 19);
            this.label15.TabIndex = 1339;
            this.label15.Text = "Calib";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblZ_P2
            // 
            this.lblZ_P2.BackColor = System.Drawing.Color.LightYellow;
            this.lblZ_P2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblZ_P2.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblZ_P2.ForeColor = System.Drawing.Color.Black;
            this.lblZ_P2.Location = new System.Drawing.Point(751, 456);
            this.lblZ_P2.Name = "lblZ_P2";
            this.lblZ_P2.Size = new System.Drawing.Size(64, 12);
            this.lblZ_P2.TabIndex = 1338;
            this.lblZ_P2.Text = "X";
            this.lblZ_P2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY_P2
            // 
            this.lblY_P2.BackColor = System.Drawing.Color.LightYellow;
            this.lblY_P2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblY_P2.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblY_P2.ForeColor = System.Drawing.Color.Black;
            this.lblY_P2.Location = new System.Drawing.Point(751, 433);
            this.lblY_P2.Name = "lblY_P2";
            this.lblY_P2.Size = new System.Drawing.Size(64, 12);
            this.lblY_P2.TabIndex = 1337;
            this.lblY_P2.Text = "X";
            this.lblY_P2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblX_P2
            // 
            this.lblX_P2.BackColor = System.Drawing.Color.LightYellow;
            this.lblX_P2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblX_P2.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblX_P2.ForeColor = System.Drawing.Color.Black;
            this.lblX_P2.Location = new System.Drawing.Point(751, 410);
            this.lblX_P2.Name = "lblX_P2";
            this.lblX_P2.Size = new System.Drawing.Size(64, 12);
            this.lblX_P2.TabIndex = 1336;
            this.lblX_P2.Text = "X";
            this.lblX_P2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label58
            // 
            this.label58.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label58.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label58.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label58.ForeColor = System.Drawing.Color.White;
            this.label58.Location = new System.Drawing.Point(734, 390);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(81, 19);
            this.label58.TabIndex = 1335;
            this.label58.Text = "Common";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblZ_P3
            // 
            this.lblZ_P3.BackColor = System.Drawing.Color.LightYellow;
            this.lblZ_P3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblZ_P3.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblZ_P3.ForeColor = System.Drawing.Color.Black;
            this.lblZ_P3.Location = new System.Drawing.Point(751, 697);
            this.lblZ_P3.Name = "lblZ_P3";
            this.lblZ_P3.Size = new System.Drawing.Size(64, 12);
            this.lblZ_P3.TabIndex = 1334;
            this.lblZ_P3.Text = "X";
            this.lblZ_P3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY_P3
            // 
            this.lblY_P3.BackColor = System.Drawing.Color.LightYellow;
            this.lblY_P3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblY_P3.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblY_P3.ForeColor = System.Drawing.Color.Black;
            this.lblY_P3.Location = new System.Drawing.Point(751, 674);
            this.lblY_P3.Name = "lblY_P3";
            this.lblY_P3.Size = new System.Drawing.Size(64, 12);
            this.lblY_P3.TabIndex = 1333;
            this.lblY_P3.Text = "X";
            this.lblY_P3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblX_P3
            // 
            this.lblX_P3.BackColor = System.Drawing.Color.LightYellow;
            this.lblX_P3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblX_P3.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblX_P3.ForeColor = System.Drawing.Color.Black;
            this.lblX_P3.Location = new System.Drawing.Point(751, 651);
            this.lblX_P3.Name = "lblX_P3";
            this.lblX_P3.Size = new System.Drawing.Size(64, 12);
            this.lblX_P3.TabIndex = 1332;
            this.lblX_P3.Text = "X";
            this.lblX_P3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label41
            // 
            this.label41.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label41.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label41.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label41.ForeColor = System.Drawing.Color.White;
            this.label41.Location = new System.Drawing.Point(734, 631);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(81, 19);
            this.label41.TabIndex = 1331;
            this.label41.Text = "Common";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkLiveP3
            // 
            this.chkLiveP3.AutoSize = true;
            this.chkLiveP3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.chkLiveP3.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkLiveP3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.chkLiveP3.Location = new System.Drawing.Point(329, 521);
            this.chkLiveP3.Name = "chkLiveP3";
            this.chkLiveP3.Size = new System.Drawing.Size(51, 16);
            this.chkLiveP3.TabIndex = 1330;
            this.chkLiveP3.Text = "Live";
            this.chkLiveP3.UseVisualStyleBackColor = false;
            this.chkLiveP3.CheckedChanged += new System.EventHandler(this.chkLiveP3_CheckedChanged);
            // 
            // chkLiveP2
            // 
            this.chkLiveP2.AutoSize = true;
            this.chkLiveP2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.chkLiveP2.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkLiveP2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chkLiveP2.Location = new System.Drawing.Point(329, 277);
            this.chkLiveP2.Name = "chkLiveP2";
            this.chkLiveP2.Size = new System.Drawing.Size(51, 16);
            this.chkLiveP2.TabIndex = 1329;
            this.chkLiveP2.Text = "Live";
            this.chkLiveP2.UseVisualStyleBackColor = false;
            this.chkLiveP2.CheckedChanged += new System.EventHandler(this.chkLiveP2_CheckedChanged);
            // 
            // chkLiveP1
            // 
            this.chkLiveP1.AutoSize = true;
            this.chkLiveP1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.chkLiveP1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkLiveP1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.chkLiveP1.Location = new System.Drawing.Point(329, 41);
            this.chkLiveP1.Name = "chkLiveP1";
            this.chkLiveP1.Size = new System.Drawing.Size(51, 16);
            this.chkLiveP1.TabIndex = 1328;
            this.chkLiveP1.Text = "Live";
            this.chkLiveP1.UseVisualStyleBackColor = false;
            this.chkLiveP1.CheckedChanged += new System.EventHandler(this.chkLiveP1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(734, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 68);
            this.label4.TabIndex = 1327;
            this.label4.Text = "X Y Z";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(325, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 68);
            this.label5.TabIndex = 1326;
            this.label5.Text = "X Y Z";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblZ_CalibP1
            // 
            this.lblZ_CalibP1.BackColor = System.Drawing.Color.LightYellow;
            this.lblZ_CalibP1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblZ_CalibP1.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblZ_CalibP1.ForeColor = System.Drawing.Color.Black;
            this.lblZ_CalibP1.Location = new System.Drawing.Point(342, 217);
            this.lblZ_CalibP1.Name = "lblZ_CalibP1";
            this.lblZ_CalibP1.Size = new System.Drawing.Size(64, 12);
            this.lblZ_CalibP1.TabIndex = 1325;
            this.lblZ_CalibP1.Text = "123.12";
            this.lblZ_CalibP1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY_CalibP1
            // 
            this.lblY_CalibP1.BackColor = System.Drawing.Color.LightYellow;
            this.lblY_CalibP1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblY_CalibP1.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblY_CalibP1.ForeColor = System.Drawing.Color.Black;
            this.lblY_CalibP1.Location = new System.Drawing.Point(342, 194);
            this.lblY_CalibP1.Name = "lblY_CalibP1";
            this.lblY_CalibP1.Size = new System.Drawing.Size(64, 12);
            this.lblY_CalibP1.TabIndex = 1324;
            this.lblY_CalibP1.Text = "123.12";
            this.lblY_CalibP1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblX_CalibP1
            // 
            this.lblX_CalibP1.BackColor = System.Drawing.Color.LightYellow;
            this.lblX_CalibP1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblX_CalibP1.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblX_CalibP1.ForeColor = System.Drawing.Color.Black;
            this.lblX_CalibP1.Location = new System.Drawing.Point(342, 171);
            this.lblX_CalibP1.Name = "lblX_CalibP1";
            this.lblX_CalibP1.Size = new System.Drawing.Size(64, 12);
            this.lblX_CalibP1.TabIndex = 1323;
            this.lblX_CalibP1.Text = "123.32";
            this.lblX_CalibP1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblZ_P1
            // 
            this.lblZ_P1.BackColor = System.Drawing.Color.LightYellow;
            this.lblZ_P1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblZ_P1.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblZ_P1.ForeColor = System.Drawing.Color.Black;
            this.lblZ_P1.Location = new System.Drawing.Point(751, 217);
            this.lblZ_P1.Name = "lblZ_P1";
            this.lblZ_P1.Size = new System.Drawing.Size(64, 12);
            this.lblZ_P1.TabIndex = 1322;
            this.lblZ_P1.Text = "X";
            this.lblZ_P1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY_P1
            // 
            this.lblY_P1.BackColor = System.Drawing.Color.LightYellow;
            this.lblY_P1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblY_P1.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblY_P1.ForeColor = System.Drawing.Color.Black;
            this.lblY_P1.Location = new System.Drawing.Point(751, 194);
            this.lblY_P1.Name = "lblY_P1";
            this.lblY_P1.Size = new System.Drawing.Size(64, 12);
            this.lblY_P1.TabIndex = 1321;
            this.lblY_P1.Text = "X";
            this.lblY_P1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblX_P1
            // 
            this.lblX_P1.BackColor = System.Drawing.Color.LightYellow;
            this.lblX_P1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblX_P1.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblX_P1.ForeColor = System.Drawing.Color.Black;
            this.lblX_P1.Location = new System.Drawing.Point(751, 171);
            this.lblX_P1.Name = "lblX_P1";
            this.lblX_P1.Size = new System.Drawing.Size(64, 12);
            this.lblX_P1.TabIndex = 1320;
            this.lblX_P1.Text = "X";
            this.lblX_P1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label56
            // 
            this.label56.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label56.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label56.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label56.ForeColor = System.Drawing.Color.White;
            this.label56.Location = new System.Drawing.Point(734, 151);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(81, 19);
            this.label56.TabIndex = 1319;
            this.label56.Text = "Common";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(325, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 19);
            this.label7.TabIndex = 1318;
            this.label7.Text = "Calib";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCalibP2
            // 
            this.lblCalibP2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblCalibP2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCalibP2.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCalibP2.ForeColor = System.Drawing.Color.Orange;
            this.lblCalibP2.Location = new System.Drawing.Point(732, 242);
            this.lblCalibP2.Name = "lblCalibP2";
            this.lblCalibP2.Size = new System.Drawing.Size(86, 237);
            this.lblCalibP2.TabIndex = 1317;
            this.lblCalibP2.Text = "P2_R";
            this.lblCalibP2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblCalibP2.DoubleClick += new System.EventHandler(this.lblCalibP2_DoubleClick);
            // 
            // lblTitleP2
            // 
            this.lblTitleP2.AllowDrop = true;
            this.lblTitleP2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblTitleP2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleP2.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleP2.ForeColor = System.Drawing.Color.Orange;
            this.lblTitleP2.Location = new System.Drawing.Point(323, 242);
            this.lblTitleP2.Name = "lblTitleP2";
            this.lblTitleP2.Size = new System.Drawing.Size(86, 237);
            this.lblTitleP2.TabIndex = 1316;
            this.lblTitleP2.Text = "P2_L";
            this.lblTitleP2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblTitleP2.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblTitlePX_DragDrop);
            this.lblTitleP2.DragOver += new System.Windows.Forms.DragEventHandler(this.lblTitlePX_DragOver);
            this.lblTitleP2.DoubleClick += new System.EventHandler(this.lblTitleP2_DoubleClick);
            // 
            // lblCalibP3
            // 
            this.lblCalibP3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblCalibP3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCalibP3.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCalibP3.ForeColor = System.Drawing.Color.Orange;
            this.lblCalibP3.Location = new System.Drawing.Point(732, 483);
            this.lblCalibP3.Name = "lblCalibP3";
            this.lblCalibP3.Size = new System.Drawing.Size(86, 237);
            this.lblCalibP3.TabIndex = 1315;
            this.lblCalibP3.Text = "P3_R";
            this.lblCalibP3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblCalibP3.DoubleClick += new System.EventHandler(this.lblCalibP3_DoubleClick);
            // 
            // lblTitleP3
            // 
            this.lblTitleP3.AllowDrop = true;
            this.lblTitleP3.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblTitleP3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleP3.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleP3.ForeColor = System.Drawing.Color.Orange;
            this.lblTitleP3.Location = new System.Drawing.Point(323, 483);
            this.lblTitleP3.Name = "lblTitleP3";
            this.lblTitleP3.Size = new System.Drawing.Size(86, 237);
            this.lblTitleP3.TabIndex = 1314;
            this.lblTitleP3.Text = "P3_L";
            this.lblTitleP3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblTitleP3.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblTitlePX_DragDrop);
            this.lblTitleP3.DragOver += new System.Windows.Forms.DragEventHandler(this.lblTitlePX_DragOver);
            this.lblTitleP3.DoubleClick += new System.EventHandler(this.lblTitleP3_DoubleClick);
            // 
            // lblCalibP1
            // 
            this.lblCalibP1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblCalibP1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCalibP1.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCalibP1.ForeColor = System.Drawing.Color.Orange;
            this.lblCalibP1.Location = new System.Drawing.Point(732, 3);
            this.lblCalibP1.Name = "lblCalibP1";
            this.lblCalibP1.Size = new System.Drawing.Size(86, 237);
            this.lblCalibP1.TabIndex = 1313;
            this.lblCalibP1.Text = "P1_R";
            this.lblCalibP1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblCalibP1.DoubleClick += new System.EventHandler(this.lblCalibP1_DoubleClick);
            // 
            // lblTitleP1
            // 
            this.lblTitleP1.AllowDrop = true;
            this.lblTitleP1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblTitleP1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleP1.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleP1.ForeColor = System.Drawing.Color.Orange;
            this.lblTitleP1.Location = new System.Drawing.Point(323, 3);
            this.lblTitleP1.Name = "lblTitleP1";
            this.lblTitleP1.Size = new System.Drawing.Size(86, 237);
            this.lblTitleP1.TabIndex = 1312;
            this.lblTitleP1.Text = "P1_L";
            this.lblTitleP1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblTitleP1.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblTitlePX_DragDrop);
            this.lblTitleP1.DragOver += new System.Windows.Forms.DragEventHandler(this.lblTitlePX_DragOver);
            this.lblTitleP1.DoubleClick += new System.EventHandler(this.lblTitleP1_DoubleClick);
            // 
            // cogDisplayP3_R
            // 
            this.cogDisplayP3_R.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplayP3_R.ColorMapLowerRoiLimit = 0D;
            this.cogDisplayP3_R.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplayP3_R.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplayP3_R.ColorMapUpperRoiLimit = 1D;
            this.cogDisplayP3_R.DoubleTapZoomCycleLength = 2;
            this.cogDisplayP3_R.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplayP3_R.Location = new System.Drawing.Point(411, 483);
            this.cogDisplayP3_R.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplayP3_R.MouseWheelSensitivity = 1D;
            this.cogDisplayP3_R.Name = "cogDisplayP3_R";
            this.cogDisplayP3_R.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplayP3_R.OcxState")));
            this.cogDisplayP3_R.Size = new System.Drawing.Size(320, 236);
            this.cogDisplayP3_R.TabIndex = 1311;
            this.cogDisplayP3_R.DoubleClick += new System.EventHandler(this.cogDisplayP3_R_DoubleClick);
            // 
            // cogDisplayP3_L
            // 
            this.cogDisplayP3_L.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplayP3_L.ColorMapLowerRoiLimit = 0D;
            this.cogDisplayP3_L.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplayP3_L.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplayP3_L.ColorMapUpperRoiLimit = 1D;
            this.cogDisplayP3_L.DoubleTapZoomCycleLength = 2;
            this.cogDisplayP3_L.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplayP3_L.Location = new System.Drawing.Point(2, 483);
            this.cogDisplayP3_L.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplayP3_L.MouseWheelSensitivity = 1D;
            this.cogDisplayP3_L.Name = "cogDisplayP3_L";
            this.cogDisplayP3_L.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplayP3_L.OcxState")));
            this.cogDisplayP3_L.Size = new System.Drawing.Size(320, 236);
            this.cogDisplayP3_L.TabIndex = 1310;
            this.cogDisplayP3_L.DoubleClick += new System.EventHandler(this.cogDisplayP3_L_DoubleClick);
            // 
            // cogDisplayP2_R
            // 
            this.cogDisplayP2_R.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplayP2_R.ColorMapLowerRoiLimit = 0D;
            this.cogDisplayP2_R.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplayP2_R.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplayP2_R.ColorMapUpperRoiLimit = 1D;
            this.cogDisplayP2_R.DoubleTapZoomCycleLength = 2;
            this.cogDisplayP2_R.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplayP2_R.Location = new System.Drawing.Point(411, 243);
            this.cogDisplayP2_R.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplayP2_R.MouseWheelSensitivity = 1D;
            this.cogDisplayP2_R.Name = "cogDisplayP2_R";
            this.cogDisplayP2_R.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplayP2_R.OcxState")));
            this.cogDisplayP2_R.Size = new System.Drawing.Size(320, 236);
            this.cogDisplayP2_R.TabIndex = 1309;
            this.cogDisplayP2_R.DoubleClick += new System.EventHandler(this.cogDisplayP2_R_DoubleClick);
            // 
            // cogDisplayP1_L
            // 
            this.cogDisplayP1_L.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplayP1_L.ColorMapLowerRoiLimit = 0D;
            this.cogDisplayP1_L.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplayP1_L.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplayP1_L.ColorMapUpperRoiLimit = 1D;
            this.cogDisplayP1_L.DoubleTapZoomCycleLength = 2;
            this.cogDisplayP1_L.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplayP1_L.Location = new System.Drawing.Point(2, 3);
            this.cogDisplayP1_L.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplayP1_L.MouseWheelSensitivity = 1D;
            this.cogDisplayP1_L.Name = "cogDisplayP1_L";
            this.cogDisplayP1_L.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplayP1_L.OcxState")));
            this.cogDisplayP1_L.Size = new System.Drawing.Size(320, 236);
            this.cogDisplayP1_L.TabIndex = 1307;
            this.cogDisplayP1_L.DoubleClick += new System.EventHandler(this.cogDisplayP1_L_DoubleClick);
            // 
            // cogDisplayP2_L
            // 
            this.cogDisplayP2_L.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplayP2_L.ColorMapLowerRoiLimit = 0D;
            this.cogDisplayP2_L.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplayP2_L.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplayP2_L.ColorMapUpperRoiLimit = 1D;
            this.cogDisplayP2_L.DoubleTapZoomCycleLength = 2;
            this.cogDisplayP2_L.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplayP2_L.Location = new System.Drawing.Point(2, 243);
            this.cogDisplayP2_L.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplayP2_L.MouseWheelSensitivity = 1D;
            this.cogDisplayP2_L.Name = "cogDisplayP2_L";
            this.cogDisplayP2_L.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplayP2_L.OcxState")));
            this.cogDisplayP2_L.Size = new System.Drawing.Size(320, 236);
            this.cogDisplayP2_L.TabIndex = 1306;
            this.cogDisplayP2_L.DoubleClick += new System.EventHandler(this.cogDisplayP2_L_DoubleClick);
            // 
            // cogDisplayP1_R
            // 
            this.cogDisplayP1_R.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplayP1_R.ColorMapLowerRoiLimit = 0D;
            this.cogDisplayP1_R.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplayP1_R.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplayP1_R.ColorMapUpperRoiLimit = 1D;
            this.cogDisplayP1_R.DoubleTapZoomCycleLength = 2;
            this.cogDisplayP1_R.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplayP1_R.Location = new System.Drawing.Point(411, 3);
            this.cogDisplayP1_R.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplayP1_R.MouseWheelSensitivity = 1D;
            this.cogDisplayP1_R.Name = "cogDisplayP1_R";
            this.cogDisplayP1_R.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplayP1_R.OcxState")));
            this.cogDisplayP1_R.Size = new System.Drawing.Size(320, 236);
            this.cogDisplayP1_R.TabIndex = 1308;
            this.cogDisplayP1_R.DoubleClick += new System.EventHandler(this.cogDisplayP1_R_DoubleClick);
            // 
            // btnLengthSet
            // 
            this.btnLengthSet.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnLengthSet.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLengthSet.Location = new System.Drawing.Point(696, 835);
            this.btnLengthSet.Name = "btnLengthSet";
            this.btnLengthSet.Size = new System.Drawing.Size(59, 45);
            this.btnLengthSet.TabIndex = 1294;
            this.btnLengthSet.Text = "거리  설정";
            this.btnLengthSet.UseVisualStyleBackColor = false;
            this.btnLengthSet.Click += new System.EventHandler(this.btnLengthSet_Click);
            // 
            // btnPartOffsetSet
            // 
            this.btnPartOffsetSet.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnPartOffsetSet.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPartOffsetSet.Location = new System.Drawing.Point(696, 784);
            this.btnPartOffsetSet.Name = "btnPartOffsetSet";
            this.btnPartOffsetSet.Size = new System.Drawing.Size(122, 45);
            this.btnPartOffsetSet.TabIndex = 1293;
            this.btnPartOffsetSet.Text = "부분 Offset 설정";
            this.btnPartOffsetSet.UseVisualStyleBackColor = false;
            this.btnPartOffsetSet.Click += new System.EventHandler(this.btnPartOffsetSet_Click);
            // 
            // TC2
            // 
            this.TC2.BackColor = System.Drawing.Color.Gainsboro;
            this.TC2.Controls.Add(this.btnManualRH2_R);
            this.TC2.Controls.Add(this.btnManualLH2_R);
            this.TC2.Controls.Add(this.btnManualRH1_R);
            this.TC2.Controls.Add(this.btnManualLH1_R);
            this.TC2.Controls.Add(this.btnManualRH2_L);
            this.TC2.Controls.Add(this.btnManualLH2_L);
            this.TC2.Controls.Add(this.btnManualRH1_L);
            this.TC2.Controls.Add(this.btnManualLH1_L);
            this.TC2.Controls.Add(this.btnOffsetSetRH2_R);
            this.TC2.Controls.Add(this.btnOffsetSetLH2_R);
            this.TC2.Controls.Add(this.btnOffsetSetRH1_R);
            this.TC2.Controls.Add(this.btnOffsetSetLH1_R);
            this.TC2.Controls.Add(this.btnOffsetSetRH2_L);
            this.TC2.Controls.Add(this.btnOffsetSetLH2_L);
            this.TC2.Controls.Add(this.btnOffsetSetRH1_L);
            this.TC2.Controls.Add(this.btnOffsetSetLH1_L);
            this.TC2.Controls.Add(this.lblY_RH2_R);
            this.TC2.Controls.Add(this.label39);
            this.TC2.Controls.Add(this.lblX_RH2_R);
            this.TC2.Controls.Add(this.label45);
            this.TC2.Controls.Add(this.label46);
            this.TC2.Controls.Add(this.lblY_RH1_R);
            this.TC2.Controls.Add(this.label47);
            this.TC2.Controls.Add(this.lblX_RH1_R);
            this.TC2.Controls.Add(this.label48);
            this.TC2.Controls.Add(this.label49);
            this.TC2.Controls.Add(this.lblY_LH2_R);
            this.TC2.Controls.Add(this.label33);
            this.TC2.Controls.Add(this.lblX_LH2_R);
            this.TC2.Controls.Add(this.label34);
            this.TC2.Controls.Add(this.label35);
            this.TC2.Controls.Add(this.lblY_LH1_R);
            this.TC2.Controls.Add(this.label37);
            this.TC2.Controls.Add(this.lblX_LH1_R);
            this.TC2.Controls.Add(this.label42);
            this.TC2.Controls.Add(this.label44);
            this.TC2.Controls.Add(this.label32);
            this.TC2.Controls.Add(this.lblY_RH2_L);
            this.TC2.Controls.Add(this.label18);
            this.TC2.Controls.Add(this.lblX_RH2_L);
            this.TC2.Controls.Add(this.label21);
            this.TC2.Controls.Add(this.label25);
            this.TC2.Controls.Add(this.lblY_RH1_L);
            this.TC2.Controls.Add(this.label27);
            this.TC2.Controls.Add(this.lblX_RH1_L);
            this.TC2.Controls.Add(this.label29);
            this.TC2.Controls.Add(this.label31);
            this.TC2.Controls.Add(this.lblY_LH2_L);
            this.TC2.Controls.Add(this.label20);
            this.TC2.Controls.Add(this.lblX_LH2_L);
            this.TC2.Controls.Add(this.label8);
            this.TC2.Controls.Add(this.label24);
            this.TC2.Controls.Add(this.lblY_LH1_L);
            this.TC2.Controls.Add(this.label11);
            this.TC2.Controls.Add(this.lblX_LH1_L);
            this.TC2.Controls.Add(this.label12);
            this.TC2.Controls.Add(this.label17);
            this.TC2.Controls.Add(this.label6);
            this.TC2.Controls.Add(this.cogDisplayRH2_L);
            this.TC2.Controls.Add(this.lblTitleRH2_L);
            this.TC2.Controls.Add(this.cogDisplayRH1_R);
            this.TC2.Controls.Add(this.lblTitleRH1_R);
            this.TC2.Controls.Add(this.cogDisplayRH2_R);
            this.TC2.Controls.Add(this.lblTitleRH2_R);
            this.TC2.Controls.Add(this.cogDisplayRH1_L);
            this.TC2.Controls.Add(this.lblTitleRH1_L);
            this.TC2.Controls.Add(this.cogDisplayLH2_L);
            this.TC2.Controls.Add(this.lblTitleLH2_L);
            this.TC2.Controls.Add(this.cogDisplayLH1_R);
            this.TC2.Controls.Add(this.lblTitleLH1_R);
            this.TC2.Controls.Add(this.cogDisplayLH2_R);
            this.TC2.Controls.Add(this.lblTitleLH2_R);
            this.TC2.Controls.Add(this.cogDisplayLH1_L);
            this.TC2.Controls.Add(this.lblTitleLH1_L);
            this.TC2.Location = new System.Drawing.Point(4, 22);
            this.TC2.Name = "TC2";
            this.TC2.Padding = new System.Windows.Forms.Padding(3);
            this.TC2.Size = new System.Drawing.Size(826, 939);
            this.TC2.TabIndex = 1;
            this.TC2.Text = "2D";
            // 
            // btnManualRH2_R
            // 
            this.btnManualRH2_R.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnManualRH2_R.Location = new System.Drawing.Point(439, 834);
            this.btnManualRH2_R.Name = "btnManualRH2_R";
            this.btnManualRH2_R.Size = new System.Drawing.Size(75, 29);
            this.btnManualRH2_R.TabIndex = 839;
            this.btnManualRH2_R.Text = "수동측정";
            this.btnManualRH2_R.UseVisualStyleBackColor = true;
            this.btnManualRH2_R.Click += new System.EventHandler(this.btnManualRH2_R_Click);
            // 
            // btnManualLH2_R
            // 
            this.btnManualLH2_R.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnManualLH2_R.Location = new System.Drawing.Point(333, 834);
            this.btnManualLH2_R.Name = "btnManualLH2_R";
            this.btnManualLH2_R.Size = new System.Drawing.Size(75, 29);
            this.btnManualLH2_R.TabIndex = 838;
            this.btnManualLH2_R.Text = "수동측정";
            this.btnManualLH2_R.UseVisualStyleBackColor = true;
            this.btnManualLH2_R.Click += new System.EventHandler(this.btnManualLH2_R_Click);
            // 
            // btnManualRH1_R
            // 
            this.btnManualRH1_R.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnManualRH1_R.Location = new System.Drawing.Point(439, 649);
            this.btnManualRH1_R.Name = "btnManualRH1_R";
            this.btnManualRH1_R.Size = new System.Drawing.Size(75, 29);
            this.btnManualRH1_R.TabIndex = 837;
            this.btnManualRH1_R.Text = "수동측정";
            this.btnManualRH1_R.UseVisualStyleBackColor = true;
            this.btnManualRH1_R.Click += new System.EventHandler(this.btnManualRH1_R_Click);
            // 
            // btnManualLH1_R
            // 
            this.btnManualLH1_R.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnManualLH1_R.Location = new System.Drawing.Point(333, 649);
            this.btnManualLH1_R.Name = "btnManualLH1_R";
            this.btnManualLH1_R.Size = new System.Drawing.Size(75, 29);
            this.btnManualLH1_R.TabIndex = 836;
            this.btnManualLH1_R.Text = "수동측정";
            this.btnManualLH1_R.UseVisualStyleBackColor = true;
            this.btnManualLH1_R.Click += new System.EventHandler(this.btnManualLH1_R_Click);
            // 
            // btnManualRH2_L
            // 
            this.btnManualRH2_L.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnManualRH2_L.Location = new System.Drawing.Point(439, 364);
            this.btnManualRH2_L.Name = "btnManualRH2_L";
            this.btnManualRH2_L.Size = new System.Drawing.Size(75, 29);
            this.btnManualRH2_L.TabIndex = 835;
            this.btnManualRH2_L.Text = "수동측정";
            this.btnManualRH2_L.UseVisualStyleBackColor = true;
            this.btnManualRH2_L.Click += new System.EventHandler(this.btnManualRH2_L_Click);
            // 
            // btnManualLH2_L
            // 
            this.btnManualLH2_L.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnManualLH2_L.Location = new System.Drawing.Point(333, 364);
            this.btnManualLH2_L.Name = "btnManualLH2_L";
            this.btnManualLH2_L.Size = new System.Drawing.Size(75, 29);
            this.btnManualLH2_L.TabIndex = 834;
            this.btnManualLH2_L.Text = "수동측정";
            this.btnManualLH2_L.UseVisualStyleBackColor = true;
            this.btnManualLH2_L.Click += new System.EventHandler(this.btnManualLH2_L_Click);
            // 
            // btnManualRH1_L
            // 
            this.btnManualRH1_L.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnManualRH1_L.Location = new System.Drawing.Point(439, 179);
            this.btnManualRH1_L.Name = "btnManualRH1_L";
            this.btnManualRH1_L.Size = new System.Drawing.Size(75, 29);
            this.btnManualRH1_L.TabIndex = 833;
            this.btnManualRH1_L.Text = "수동측정";
            this.btnManualRH1_L.UseVisualStyleBackColor = true;
            this.btnManualRH1_L.Click += new System.EventHandler(this.btnManualRH1_L_Click);
            // 
            // btnManualLH1_L
            // 
            this.btnManualLH1_L.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnManualLH1_L.Location = new System.Drawing.Point(335, 179);
            this.btnManualLH1_L.Name = "btnManualLH1_L";
            this.btnManualLH1_L.Size = new System.Drawing.Size(75, 29);
            this.btnManualLH1_L.TabIndex = 832;
            this.btnManualLH1_L.Text = "수동측정";
            this.btnManualLH1_L.UseVisualStyleBackColor = true;
            this.btnManualLH1_L.Click += new System.EventHandler(this.btnManualLH1_L_Click);
            // 
            // btnOffsetSetRH2_R
            // 
            this.btnOffsetSetRH2_R.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOffsetSetRH2_R.Location = new System.Drawing.Point(439, 802);
            this.btnOffsetSetRH2_R.Name = "btnOffsetSetRH2_R";
            this.btnOffsetSetRH2_R.Size = new System.Drawing.Size(75, 29);
            this.btnOffsetSetRH2_R.TabIndex = 831;
            this.btnOffsetSetRH2_R.Text = "OFFSET";
            this.btnOffsetSetRH2_R.UseVisualStyleBackColor = true;
            this.btnOffsetSetRH2_R.Click += new System.EventHandler(this.btnOffsetSetRH2_R_Click);
            // 
            // btnOffsetSetLH2_R
            // 
            this.btnOffsetSetLH2_R.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOffsetSetLH2_R.Location = new System.Drawing.Point(333, 802);
            this.btnOffsetSetLH2_R.Name = "btnOffsetSetLH2_R";
            this.btnOffsetSetLH2_R.Size = new System.Drawing.Size(75, 29);
            this.btnOffsetSetLH2_R.TabIndex = 830;
            this.btnOffsetSetLH2_R.Text = "OFFSET";
            this.btnOffsetSetLH2_R.UseVisualStyleBackColor = true;
            this.btnOffsetSetLH2_R.Click += new System.EventHandler(this.btnOffsetSetLH2_R_Click);
            // 
            // btnOffsetSetRH1_R
            // 
            this.btnOffsetSetRH1_R.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOffsetSetRH1_R.Location = new System.Drawing.Point(439, 617);
            this.btnOffsetSetRH1_R.Name = "btnOffsetSetRH1_R";
            this.btnOffsetSetRH1_R.Size = new System.Drawing.Size(75, 29);
            this.btnOffsetSetRH1_R.TabIndex = 829;
            this.btnOffsetSetRH1_R.Text = "OFFSET";
            this.btnOffsetSetRH1_R.UseVisualStyleBackColor = true;
            this.btnOffsetSetRH1_R.Click += new System.EventHandler(this.btnOffsetSetRH1_R_Click);
            // 
            // btnOffsetSetLH1_R
            // 
            this.btnOffsetSetLH1_R.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOffsetSetLH1_R.Location = new System.Drawing.Point(333, 617);
            this.btnOffsetSetLH1_R.Name = "btnOffsetSetLH1_R";
            this.btnOffsetSetLH1_R.Size = new System.Drawing.Size(75, 29);
            this.btnOffsetSetLH1_R.TabIndex = 828;
            this.btnOffsetSetLH1_R.Text = "OFFSET";
            this.btnOffsetSetLH1_R.UseVisualStyleBackColor = true;
            this.btnOffsetSetLH1_R.Click += new System.EventHandler(this.btnOffsetSetLH1_R_Click);
            // 
            // btnOffsetSetRH2_L
            // 
            this.btnOffsetSetRH2_L.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOffsetSetRH2_L.Location = new System.Drawing.Point(439, 332);
            this.btnOffsetSetRH2_L.Name = "btnOffsetSetRH2_L";
            this.btnOffsetSetRH2_L.Size = new System.Drawing.Size(75, 29);
            this.btnOffsetSetRH2_L.TabIndex = 827;
            this.btnOffsetSetRH2_L.Text = "OFFSET";
            this.btnOffsetSetRH2_L.UseVisualStyleBackColor = true;
            this.btnOffsetSetRH2_L.Click += new System.EventHandler(this.btnOffsetSetRH2_L_Click);
            // 
            // btnOffsetSetLH2_L
            // 
            this.btnOffsetSetLH2_L.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOffsetSetLH2_L.Location = new System.Drawing.Point(333, 332);
            this.btnOffsetSetLH2_L.Name = "btnOffsetSetLH2_L";
            this.btnOffsetSetLH2_L.Size = new System.Drawing.Size(75, 29);
            this.btnOffsetSetLH2_L.TabIndex = 826;
            this.btnOffsetSetLH2_L.Text = "OFFSET";
            this.btnOffsetSetLH2_L.UseVisualStyleBackColor = true;
            this.btnOffsetSetLH2_L.Click += new System.EventHandler(this.btnOffsetSetLH2_L_Click);
            // 
            // btnOffsetSetRH1_L
            // 
            this.btnOffsetSetRH1_L.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOffsetSetRH1_L.Location = new System.Drawing.Point(439, 148);
            this.btnOffsetSetRH1_L.Name = "btnOffsetSetRH1_L";
            this.btnOffsetSetRH1_L.Size = new System.Drawing.Size(75, 29);
            this.btnOffsetSetRH1_L.TabIndex = 825;
            this.btnOffsetSetRH1_L.Text = "OFFSET";
            this.btnOffsetSetRH1_L.UseVisualStyleBackColor = true;
            this.btnOffsetSetRH1_L.Click += new System.EventHandler(this.btnOffsetSetRH1_L_Click);
            // 
            // btnOffsetSetLH1_L
            // 
            this.btnOffsetSetLH1_L.Font = new System.Drawing.Font("Gulim", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOffsetSetLH1_L.Location = new System.Drawing.Point(335, 148);
            this.btnOffsetSetLH1_L.Name = "btnOffsetSetLH1_L";
            this.btnOffsetSetLH1_L.Size = new System.Drawing.Size(75, 29);
            this.btnOffsetSetLH1_L.TabIndex = 824;
            this.btnOffsetSetLH1_L.Text = "OFFSET";
            this.btnOffsetSetLH1_L.UseVisualStyleBackColor = true;
            this.btnOffsetSetLH1_L.Click += new System.EventHandler(this.btnOffsetSetLH1_L_Click);
            // 
            // lblY_RH2_R
            // 
            this.lblY_RH2_R.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblY_RH2_R.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblY_RH2_R.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblY_RH2_R.ForeColor = System.Drawing.Color.Black;
            this.lblY_RH2_R.Location = new System.Drawing.Point(441, 769);
            this.lblY_RH2_R.Name = "lblY_RH2_R";
            this.lblY_RH2_R.Size = new System.Drawing.Size(73, 28);
            this.lblY_RH2_R.TabIndex = 823;
            this.lblY_RH2_R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label39
            // 
            this.label39.BackColor = System.Drawing.Color.Gray;
            this.label39.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label39.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold);
            this.label39.ForeColor = System.Drawing.Color.Black;
            this.label39.Location = new System.Drawing.Point(413, 769);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(28, 30);
            this.label39.TabIndex = 822;
            this.label39.Text = "Y";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblX_RH2_R
            // 
            this.lblX_RH2_R.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblX_RH2_R.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblX_RH2_R.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblX_RH2_R.ForeColor = System.Drawing.Color.Black;
            this.lblX_RH2_R.Location = new System.Drawing.Point(441, 739);
            this.lblX_RH2_R.Name = "lblX_RH2_R";
            this.lblX_RH2_R.Size = new System.Drawing.Size(73, 28);
            this.lblX_RH2_R.TabIndex = 821;
            this.lblX_RH2_R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label45
            // 
            this.label45.BackColor = System.Drawing.Color.Gray;
            this.label45.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label45.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold);
            this.label45.ForeColor = System.Drawing.Color.Black;
            this.label45.Location = new System.Drawing.Point(413, 739);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(28, 30);
            this.label45.TabIndex = 820;
            this.label45.Text = "X";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label46
            // 
            this.label46.BackColor = System.Drawing.Color.Gray;
            this.label46.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label46.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold);
            this.label46.ForeColor = System.Drawing.Color.Pink;
            this.label46.Location = new System.Drawing.Point(413, 706);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(103, 30);
            this.label46.TabIndex = 819;
            this.label46.Text = "RH2";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY_RH1_R
            // 
            this.lblY_RH1_R.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblY_RH1_R.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblY_RH1_R.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblY_RH1_R.ForeColor = System.Drawing.Color.Black;
            this.lblY_RH1_R.Location = new System.Drawing.Point(441, 584);
            this.lblY_RH1_R.Name = "lblY_RH1_R";
            this.lblY_RH1_R.Size = new System.Drawing.Size(73, 28);
            this.lblY_RH1_R.TabIndex = 818;
            this.lblY_RH1_R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label47
            // 
            this.label47.BackColor = System.Drawing.Color.Gray;
            this.label47.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label47.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold);
            this.label47.ForeColor = System.Drawing.Color.Black;
            this.label47.Location = new System.Drawing.Point(413, 584);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(28, 30);
            this.label47.TabIndex = 817;
            this.label47.Text = "Y";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblX_RH1_R
            // 
            this.lblX_RH1_R.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblX_RH1_R.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblX_RH1_R.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblX_RH1_R.ForeColor = System.Drawing.Color.Black;
            this.lblX_RH1_R.Location = new System.Drawing.Point(441, 554);
            this.lblX_RH1_R.Name = "lblX_RH1_R";
            this.lblX_RH1_R.Size = new System.Drawing.Size(73, 28);
            this.lblX_RH1_R.TabIndex = 816;
            this.lblX_RH1_R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label48
            // 
            this.label48.BackColor = System.Drawing.Color.Gray;
            this.label48.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label48.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold);
            this.label48.ForeColor = System.Drawing.Color.Black;
            this.label48.Location = new System.Drawing.Point(413, 554);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(28, 30);
            this.label48.TabIndex = 815;
            this.label48.Text = "X";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label49
            // 
            this.label49.BackColor = System.Drawing.Color.Gray;
            this.label49.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label49.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold);
            this.label49.ForeColor = System.Drawing.Color.Pink;
            this.label49.Location = new System.Drawing.Point(413, 521);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(103, 30);
            this.label49.TabIndex = 814;
            this.label49.Text = "RH1";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY_LH2_R
            // 
            this.lblY_LH2_R.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblY_LH2_R.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblY_LH2_R.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblY_LH2_R.ForeColor = System.Drawing.Color.Black;
            this.lblY_LH2_R.Location = new System.Drawing.Point(335, 769);
            this.lblY_LH2_R.Name = "lblY_LH2_R";
            this.lblY_LH2_R.Size = new System.Drawing.Size(73, 28);
            this.lblY_LH2_R.TabIndex = 813;
            this.lblY_LH2_R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label33
            // 
            this.label33.BackColor = System.Drawing.Color.Gray;
            this.label33.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label33.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold);
            this.label33.ForeColor = System.Drawing.Color.Black;
            this.label33.Location = new System.Drawing.Point(307, 769);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(28, 30);
            this.label33.TabIndex = 812;
            this.label33.Text = "Y";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblX_LH2_R
            // 
            this.lblX_LH2_R.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblX_LH2_R.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblX_LH2_R.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblX_LH2_R.ForeColor = System.Drawing.Color.Black;
            this.lblX_LH2_R.Location = new System.Drawing.Point(335, 739);
            this.lblX_LH2_R.Name = "lblX_LH2_R";
            this.lblX_LH2_R.Size = new System.Drawing.Size(73, 28);
            this.lblX_LH2_R.TabIndex = 811;
            this.lblX_LH2_R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label34
            // 
            this.label34.BackColor = System.Drawing.Color.Gray;
            this.label34.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label34.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold);
            this.label34.ForeColor = System.Drawing.Color.Black;
            this.label34.Location = new System.Drawing.Point(307, 739);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(28, 30);
            this.label34.TabIndex = 810;
            this.label34.Text = "X";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.Color.Gray;
            this.label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label35.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold);
            this.label35.ForeColor = System.Drawing.Color.Pink;
            this.label35.Location = new System.Drawing.Point(307, 706);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(103, 30);
            this.label35.TabIndex = 809;
            this.label35.Text = "LH2";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY_LH1_R
            // 
            this.lblY_LH1_R.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblY_LH1_R.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblY_LH1_R.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblY_LH1_R.ForeColor = System.Drawing.Color.Black;
            this.lblY_LH1_R.Location = new System.Drawing.Point(335, 584);
            this.lblY_LH1_R.Name = "lblY_LH1_R";
            this.lblY_LH1_R.Size = new System.Drawing.Size(73, 28);
            this.lblY_LH1_R.TabIndex = 808;
            this.lblY_LH1_R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label37
            // 
            this.label37.BackColor = System.Drawing.Color.Gray;
            this.label37.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label37.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold);
            this.label37.ForeColor = System.Drawing.Color.Black;
            this.label37.Location = new System.Drawing.Point(307, 584);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(28, 30);
            this.label37.TabIndex = 807;
            this.label37.Text = "Y";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblX_LH1_R
            // 
            this.lblX_LH1_R.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblX_LH1_R.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblX_LH1_R.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblX_LH1_R.ForeColor = System.Drawing.Color.Black;
            this.lblX_LH1_R.Location = new System.Drawing.Point(335, 554);
            this.lblX_LH1_R.Name = "lblX_LH1_R";
            this.lblX_LH1_R.Size = new System.Drawing.Size(73, 28);
            this.lblX_LH1_R.TabIndex = 806;
            this.lblX_LH1_R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.Color.Gray;
            this.label42.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label42.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold);
            this.label42.ForeColor = System.Drawing.Color.Black;
            this.label42.Location = new System.Drawing.Point(307, 554);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(28, 30);
            this.label42.TabIndex = 805;
            this.label42.Text = "X";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label44
            // 
            this.label44.BackColor = System.Drawing.Color.Gray;
            this.label44.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label44.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold);
            this.label44.ForeColor = System.Drawing.Color.Pink;
            this.label44.Location = new System.Drawing.Point(307, 521);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(103, 30);
            this.label44.TabIndex = 804;
            this.label44.Text = "LH1";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.Color.Gray;
            this.label32.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label32.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold);
            this.label32.ForeColor = System.Drawing.Color.Pink;
            this.label32.Location = new System.Drawing.Point(307, 471);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(209, 45);
            this.label32.TabIndex = 803;
            this.label32.Text = "RH Robot";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY_RH2_L
            // 
            this.lblY_RH2_L.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblY_RH2_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblY_RH2_L.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblY_RH2_L.ForeColor = System.Drawing.Color.Black;
            this.lblY_RH2_L.Location = new System.Drawing.Point(441, 299);
            this.lblY_RH2_L.Name = "lblY_RH2_L";
            this.lblY_RH2_L.Size = new System.Drawing.Size(73, 28);
            this.lblY_RH2_L.TabIndex = 802;
            this.lblY_RH2_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Gray;
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label18.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold);
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(413, 299);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(28, 30);
            this.label18.TabIndex = 801;
            this.label18.Text = "Y";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblX_RH2_L
            // 
            this.lblX_RH2_L.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblX_RH2_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblX_RH2_L.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblX_RH2_L.ForeColor = System.Drawing.Color.Black;
            this.lblX_RH2_L.Location = new System.Drawing.Point(441, 269);
            this.lblX_RH2_L.Name = "lblX_RH2_L";
            this.lblX_RH2_L.Size = new System.Drawing.Size(73, 28);
            this.lblX_RH2_L.TabIndex = 800;
            this.lblX_RH2_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Gray;
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label21.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold);
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(413, 269);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(28, 30);
            this.label21.TabIndex = 799;
            this.label21.Text = "X";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.BackColor = System.Drawing.Color.Gray;
            this.label25.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label25.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold);
            this.label25.ForeColor = System.Drawing.Color.Cyan;
            this.label25.Location = new System.Drawing.Point(413, 236);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(103, 30);
            this.label25.TabIndex = 798;
            this.label25.Text = "RH2";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY_RH1_L
            // 
            this.lblY_RH1_L.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblY_RH1_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblY_RH1_L.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblY_RH1_L.ForeColor = System.Drawing.Color.Black;
            this.lblY_RH1_L.Location = new System.Drawing.Point(441, 115);
            this.lblY_RH1_L.Name = "lblY_RH1_L";
            this.lblY_RH1_L.Size = new System.Drawing.Size(73, 28);
            this.lblY_RH1_L.TabIndex = 797;
            this.lblY_RH1_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.Gray;
            this.label27.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label27.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold);
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(413, 115);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(28, 30);
            this.label27.TabIndex = 796;
            this.label27.Text = "Y";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblX_RH1_L
            // 
            this.lblX_RH1_L.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblX_RH1_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblX_RH1_L.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblX_RH1_L.ForeColor = System.Drawing.Color.Black;
            this.lblX_RH1_L.Location = new System.Drawing.Point(441, 85);
            this.lblX_RH1_L.Name = "lblX_RH1_L";
            this.lblX_RH1_L.Size = new System.Drawing.Size(73, 28);
            this.lblX_RH1_L.TabIndex = 795;
            this.lblX_RH1_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.Gray;
            this.label29.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label29.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold);
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(413, 85);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(28, 30);
            this.label29.TabIndex = 794;
            this.label29.Text = "X";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.Color.Gray;
            this.label31.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label31.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold);
            this.label31.ForeColor = System.Drawing.Color.Cyan;
            this.label31.Location = new System.Drawing.Point(413, 52);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(103, 30);
            this.label31.TabIndex = 793;
            this.label31.Text = "RH1";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY_LH2_L
            // 
            this.lblY_LH2_L.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblY_LH2_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblY_LH2_L.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblY_LH2_L.ForeColor = System.Drawing.Color.Black;
            this.lblY_LH2_L.Location = new System.Drawing.Point(335, 299);
            this.lblY_LH2_L.Name = "lblY_LH2_L";
            this.lblY_LH2_L.Size = new System.Drawing.Size(73, 28);
            this.lblY_LH2_L.TabIndex = 792;
            this.lblY_LH2_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Gray;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label20.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold);
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(307, 299);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(28, 30);
            this.label20.TabIndex = 791;
            this.label20.Text = "Y";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblX_LH2_L
            // 
            this.lblX_LH2_L.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblX_LH2_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblX_LH2_L.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblX_LH2_L.ForeColor = System.Drawing.Color.Black;
            this.lblX_LH2_L.Location = new System.Drawing.Point(335, 269);
            this.lblX_LH2_L.Name = "lblX_LH2_L";
            this.lblX_LH2_L.Size = new System.Drawing.Size(73, 28);
            this.lblX_LH2_L.TabIndex = 790;
            this.lblX_LH2_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Gray;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(307, 269);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 30);
            this.label8.TabIndex = 789;
            this.label8.Text = "X";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.Gray;
            this.label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label24.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold);
            this.label24.ForeColor = System.Drawing.Color.Cyan;
            this.label24.Location = new System.Drawing.Point(307, 236);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(103, 30);
            this.label24.TabIndex = 788;
            this.label24.Text = "LH2";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY_LH1_L
            // 
            this.lblY_LH1_L.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblY_LH1_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblY_LH1_L.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblY_LH1_L.ForeColor = System.Drawing.Color.Black;
            this.lblY_LH1_L.Location = new System.Drawing.Point(335, 116);
            this.lblY_LH1_L.Name = "lblY_LH1_L";
            this.lblY_LH1_L.Size = new System.Drawing.Size(73, 28);
            this.lblY_LH1_L.TabIndex = 787;
            this.lblY_LH1_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Gray;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(307, 115);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 30);
            this.label11.TabIndex = 786;
            this.label11.Text = "Y";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblX_LH1_L
            // 
            this.lblX_LH1_L.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblX_LH1_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblX_LH1_L.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblX_LH1_L.ForeColor = System.Drawing.Color.Black;
            this.lblX_LH1_L.Location = new System.Drawing.Point(335, 85);
            this.lblX_LH1_L.Name = "lblX_LH1_L";
            this.lblX_LH1_L.Size = new System.Drawing.Size(73, 28);
            this.lblX_LH1_L.TabIndex = 785;
            this.lblX_LH1_L.Text = "11.1";
            this.lblX_LH1_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Gray;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(307, 85);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 30);
            this.label12.TabIndex = 784;
            this.label12.Text = "X";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Gray;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label17.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.Cyan;
            this.label17.Location = new System.Drawing.Point(307, 52);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(103, 30);
            this.label17.TabIndex = 783;
            this.label17.Text = "LH1";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Gray;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Gulim", 14F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.Cyan;
            this.label6.Location = new System.Drawing.Point(307, 1);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(209, 45);
            this.label6.TabIndex = 782;
            this.label6.Text = "LH Robot";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cogDisplayRH2_L
            // 
            this.cogDisplayRH2_L.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplayRH2_L.ColorMapLowerRoiLimit = 0D;
            this.cogDisplayRH2_L.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplayRH2_L.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplayRH2_L.ColorMapUpperRoiLimit = 1D;
            this.cogDisplayRH2_L.DoubleTapZoomCycleLength = 2;
            this.cogDisplayRH2_L.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplayRH2_L.Location = new System.Drawing.Point(520, 259);
            this.cogDisplayRH2_L.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplayRH2_L.MouseWheelSensitivity = 1D;
            this.cogDisplayRH2_L.Name = "cogDisplayRH2_L";
            this.cogDisplayRH2_L.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplayRH2_L.OcxState")));
            this.cogDisplayRH2_L.Size = new System.Drawing.Size(300, 211);
            this.cogDisplayRH2_L.TabIndex = 781;
            // 
            // lblTitleRH2_L
            // 
            this.lblTitleRH2_L.AllowDrop = true;
            this.lblTitleRH2_L.BackColor = System.Drawing.Color.Gray;
            this.lblTitleRH2_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleRH2_L.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleRH2_L.ForeColor = System.Drawing.Color.Cyan;
            this.lblTitleRH2_L.Location = new System.Drawing.Point(520, 236);
            this.lblTitleRH2_L.Name = "lblTitleRH2_L";
            this.lblTitleRH2_L.Size = new System.Drawing.Size(300, 24);
            this.lblTitleRH2_L.TabIndex = 780;
            this.lblTitleRH2_L.Text = "RH2";
            this.lblTitleRH2_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitleRH2_L.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblTitleRH2_L_DragDrop);
            this.lblTitleRH2_L.DragOver += new System.Windows.Forms.DragEventHandler(this.lblTitle_DragOver);
            this.lblTitleRH2_L.DoubleClick += new System.EventHandler(this.lblTitleRH2_L_DoubleClick);
            // 
            // cogDisplayRH1_R
            // 
            this.cogDisplayRH1_R.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplayRH1_R.ColorMapLowerRoiLimit = 0D;
            this.cogDisplayRH1_R.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplayRH1_R.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplayRH1_R.ColorMapUpperRoiLimit = 1D;
            this.cogDisplayRH1_R.DoubleTapZoomCycleLength = 2;
            this.cogDisplayRH1_R.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplayRH1_R.Location = new System.Drawing.Point(520, 494);
            this.cogDisplayRH1_R.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplayRH1_R.MouseWheelSensitivity = 1D;
            this.cogDisplayRH1_R.Name = "cogDisplayRH1_R";
            this.cogDisplayRH1_R.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplayRH1_R.OcxState")));
            this.cogDisplayRH1_R.Size = new System.Drawing.Size(300, 211);
            this.cogDisplayRH1_R.TabIndex = 779;
            // 
            // lblTitleRH1_R
            // 
            this.lblTitleRH1_R.AllowDrop = true;
            this.lblTitleRH1_R.BackColor = System.Drawing.Color.Gray;
            this.lblTitleRH1_R.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleRH1_R.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleRH1_R.ForeColor = System.Drawing.Color.Pink;
            this.lblTitleRH1_R.Location = new System.Drawing.Point(520, 471);
            this.lblTitleRH1_R.Name = "lblTitleRH1_R";
            this.lblTitleRH1_R.Size = new System.Drawing.Size(300, 24);
            this.lblTitleRH1_R.TabIndex = 778;
            this.lblTitleRH1_R.Text = "RH1";
            this.lblTitleRH1_R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitleRH1_R.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblTitleRH1_R_DragDrop);
            this.lblTitleRH1_R.DragOver += new System.Windows.Forms.DragEventHandler(this.lblTitle_DragOver);
            this.lblTitleRH1_R.DoubleClick += new System.EventHandler(this.lblTitleRH1_R_DoubleClick);
            // 
            // cogDisplayRH2_R
            // 
            this.cogDisplayRH2_R.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplayRH2_R.ColorMapLowerRoiLimit = 0D;
            this.cogDisplayRH2_R.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplayRH2_R.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplayRH2_R.ColorMapUpperRoiLimit = 1D;
            this.cogDisplayRH2_R.DoubleTapZoomCycleLength = 2;
            this.cogDisplayRH2_R.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplayRH2_R.Location = new System.Drawing.Point(520, 729);
            this.cogDisplayRH2_R.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplayRH2_R.MouseWheelSensitivity = 1D;
            this.cogDisplayRH2_R.Name = "cogDisplayRH2_R";
            this.cogDisplayRH2_R.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplayRH2_R.OcxState")));
            this.cogDisplayRH2_R.Size = new System.Drawing.Size(300, 211);
            this.cogDisplayRH2_R.TabIndex = 777;
            // 
            // lblTitleRH2_R
            // 
            this.lblTitleRH2_R.AllowDrop = true;
            this.lblTitleRH2_R.BackColor = System.Drawing.Color.Gray;
            this.lblTitleRH2_R.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleRH2_R.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleRH2_R.ForeColor = System.Drawing.Color.Pink;
            this.lblTitleRH2_R.Location = new System.Drawing.Point(520, 706);
            this.lblTitleRH2_R.Name = "lblTitleRH2_R";
            this.lblTitleRH2_R.Size = new System.Drawing.Size(300, 24);
            this.lblTitleRH2_R.TabIndex = 776;
            this.lblTitleRH2_R.Text = "RH2";
            this.lblTitleRH2_R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitleRH2_R.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblTitleRH2_R_DragDrop);
            this.lblTitleRH2_R.DragOver += new System.Windows.Forms.DragEventHandler(this.lblTitle_DragOver);
            this.lblTitleRH2_R.DoubleClick += new System.EventHandler(this.lblTitleRH2_R_DoubleClick);
            // 
            // cogDisplayRH1_L
            // 
            this.cogDisplayRH1_L.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplayRH1_L.ColorMapLowerRoiLimit = 0D;
            this.cogDisplayRH1_L.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplayRH1_L.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplayRH1_L.ColorMapUpperRoiLimit = 1D;
            this.cogDisplayRH1_L.DoubleTapZoomCycleLength = 2;
            this.cogDisplayRH1_L.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplayRH1_L.Location = new System.Drawing.Point(520, 24);
            this.cogDisplayRH1_L.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplayRH1_L.MouseWheelSensitivity = 1D;
            this.cogDisplayRH1_L.Name = "cogDisplayRH1_L";
            this.cogDisplayRH1_L.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplayRH1_L.OcxState")));
            this.cogDisplayRH1_L.Size = new System.Drawing.Size(300, 211);
            this.cogDisplayRH1_L.TabIndex = 775;
            // 
            // lblTitleRH1_L
            // 
            this.lblTitleRH1_L.AllowDrop = true;
            this.lblTitleRH1_L.BackColor = System.Drawing.Color.Gray;
            this.lblTitleRH1_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleRH1_L.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleRH1_L.ForeColor = System.Drawing.Color.Cyan;
            this.lblTitleRH1_L.Location = new System.Drawing.Point(520, 1);
            this.lblTitleRH1_L.Name = "lblTitleRH1_L";
            this.lblTitleRH1_L.Size = new System.Drawing.Size(300, 24);
            this.lblTitleRH1_L.TabIndex = 774;
            this.lblTitleRH1_L.Text = "RH1";
            this.lblTitleRH1_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitleRH1_L.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblTitleRH1_L_DragDrop);
            this.lblTitleRH1_L.DragOver += new System.Windows.Forms.DragEventHandler(this.lblTitle_DragOver);
            this.lblTitleRH1_L.DoubleClick += new System.EventHandler(this.lblTitleRH1_L_DoubleClick);
            // 
            // cogDisplayLH2_L
            // 
            this.cogDisplayLH2_L.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplayLH2_L.ColorMapLowerRoiLimit = 0D;
            this.cogDisplayLH2_L.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplayLH2_L.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplayLH2_L.ColorMapUpperRoiLimit = 1D;
            this.cogDisplayLH2_L.DoubleTapZoomCycleLength = 2;
            this.cogDisplayLH2_L.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplayLH2_L.Location = new System.Drawing.Point(3, 259);
            this.cogDisplayLH2_L.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplayLH2_L.MouseWheelSensitivity = 1D;
            this.cogDisplayLH2_L.Name = "cogDisplayLH2_L";
            this.cogDisplayLH2_L.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplayLH2_L.OcxState")));
            this.cogDisplayLH2_L.Size = new System.Drawing.Size(300, 211);
            this.cogDisplayLH2_L.TabIndex = 769;
            // 
            // lblTitleLH2_L
            // 
            this.lblTitleLH2_L.AllowDrop = true;
            this.lblTitleLH2_L.BackColor = System.Drawing.Color.Gray;
            this.lblTitleLH2_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleLH2_L.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleLH2_L.ForeColor = System.Drawing.Color.Cyan;
            this.lblTitleLH2_L.Location = new System.Drawing.Point(3, 236);
            this.lblTitleLH2_L.Name = "lblTitleLH2_L";
            this.lblTitleLH2_L.Size = new System.Drawing.Size(300, 24);
            this.lblTitleLH2_L.TabIndex = 768;
            this.lblTitleLH2_L.Text = "LH2";
            this.lblTitleLH2_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitleLH2_L.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblTitleLH2_L_DragDrop);
            this.lblTitleLH2_L.DragOver += new System.Windows.Forms.DragEventHandler(this.lblTitle_DragOver);
            this.lblTitleLH2_L.DoubleClick += new System.EventHandler(this.lblTitleLH2_L_DoubleClick);
            // 
            // cogDisplayLH1_R
            // 
            this.cogDisplayLH1_R.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplayLH1_R.ColorMapLowerRoiLimit = 0D;
            this.cogDisplayLH1_R.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplayLH1_R.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplayLH1_R.ColorMapUpperRoiLimit = 1D;
            this.cogDisplayLH1_R.DoubleTapZoomCycleLength = 2;
            this.cogDisplayLH1_R.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplayLH1_R.Location = new System.Drawing.Point(3, 494);
            this.cogDisplayLH1_R.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplayLH1_R.MouseWheelSensitivity = 1D;
            this.cogDisplayLH1_R.Name = "cogDisplayLH1_R";
            this.cogDisplayLH1_R.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplayLH1_R.OcxState")));
            this.cogDisplayLH1_R.Size = new System.Drawing.Size(300, 211);
            this.cogDisplayLH1_R.TabIndex = 767;
            // 
            // lblTitleLH1_R
            // 
            this.lblTitleLH1_R.AllowDrop = true;
            this.lblTitleLH1_R.BackColor = System.Drawing.Color.Gray;
            this.lblTitleLH1_R.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleLH1_R.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleLH1_R.ForeColor = System.Drawing.Color.Pink;
            this.lblTitleLH1_R.Location = new System.Drawing.Point(3, 471);
            this.lblTitleLH1_R.Name = "lblTitleLH1_R";
            this.lblTitleLH1_R.Size = new System.Drawing.Size(300, 24);
            this.lblTitleLH1_R.TabIndex = 766;
            this.lblTitleLH1_R.Text = "LH1";
            this.lblTitleLH1_R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitleLH1_R.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblTitleLH1_R_DragDrop);
            this.lblTitleLH1_R.DragOver += new System.Windows.Forms.DragEventHandler(this.lblTitle_DragOver);
            this.lblTitleLH1_R.DoubleClick += new System.EventHandler(this.lblTitleLH1_R_DoubleClick);
            // 
            // cogDisplayLH2_R
            // 
            this.cogDisplayLH2_R.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplayLH2_R.ColorMapLowerRoiLimit = 0D;
            this.cogDisplayLH2_R.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplayLH2_R.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplayLH2_R.ColorMapUpperRoiLimit = 1D;
            this.cogDisplayLH2_R.DoubleTapZoomCycleLength = 2;
            this.cogDisplayLH2_R.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplayLH2_R.Location = new System.Drawing.Point(3, 729);
            this.cogDisplayLH2_R.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplayLH2_R.MouseWheelSensitivity = 1D;
            this.cogDisplayLH2_R.Name = "cogDisplayLH2_R";
            this.cogDisplayLH2_R.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplayLH2_R.OcxState")));
            this.cogDisplayLH2_R.Size = new System.Drawing.Size(300, 211);
            this.cogDisplayLH2_R.TabIndex = 765;
            // 
            // lblTitleLH2_R
            // 
            this.lblTitleLH2_R.AllowDrop = true;
            this.lblTitleLH2_R.BackColor = System.Drawing.Color.Gray;
            this.lblTitleLH2_R.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleLH2_R.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleLH2_R.ForeColor = System.Drawing.Color.Pink;
            this.lblTitleLH2_R.Location = new System.Drawing.Point(3, 706);
            this.lblTitleLH2_R.Name = "lblTitleLH2_R";
            this.lblTitleLH2_R.Size = new System.Drawing.Size(300, 24);
            this.lblTitleLH2_R.TabIndex = 764;
            this.lblTitleLH2_R.Text = "LH2";
            this.lblTitleLH2_R.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitleLH2_R.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblTitleLH2_R_DragDrop);
            this.lblTitleLH2_R.DragOver += new System.Windows.Forms.DragEventHandler(this.lblTitle_DragOver);
            this.lblTitleLH2_R.DoubleClick += new System.EventHandler(this.lblTitleLH2_R_DoubleClick);
            // 
            // cogDisplayLH1_L
            // 
            this.cogDisplayLH1_L.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplayLH1_L.ColorMapLowerRoiLimit = 0D;
            this.cogDisplayLH1_L.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplayLH1_L.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplayLH1_L.ColorMapUpperRoiLimit = 1D;
            this.cogDisplayLH1_L.DoubleTapZoomCycleLength = 2;
            this.cogDisplayLH1_L.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisplayLH1_L.Location = new System.Drawing.Point(3, 24);
            this.cogDisplayLH1_L.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplayLH1_L.MouseWheelSensitivity = 1D;
            this.cogDisplayLH1_L.Name = "cogDisplayLH1_L";
            this.cogDisplayLH1_L.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplayLH1_L.OcxState")));
            this.cogDisplayLH1_L.Size = new System.Drawing.Size(300, 211);
            this.cogDisplayLH1_L.TabIndex = 763;
            // 
            // lblTitleLH1_L
            // 
            this.lblTitleLH1_L.AllowDrop = true;
            this.lblTitleLH1_L.BackColor = System.Drawing.Color.Gray;
            this.lblTitleLH1_L.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitleLH1_L.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitleLH1_L.ForeColor = System.Drawing.Color.Cyan;
            this.lblTitleLH1_L.Location = new System.Drawing.Point(3, 1);
            this.lblTitleLH1_L.Name = "lblTitleLH1_L";
            this.lblTitleLH1_L.Size = new System.Drawing.Size(300, 24);
            this.lblTitleLH1_L.TabIndex = 762;
            this.lblTitleLH1_L.Text = "LH1";
            this.lblTitleLH1_L.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitleLH1_L.DragDrop += new System.Windows.Forms.DragEventHandler(this.lblTitleLH1_L_DragDrop);
            this.lblTitleLH1_L.DragOver += new System.Windows.Forms.DragEventHandler(this.lblTitle_DragOver);
            this.lblTitleLH1_L.DoubleClick += new System.EventHandler(this.lblTitleLH1_L_DoubleClick);
            // 
            // lblP1_P2
            // 
            this.lblP1_P2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblP1_P2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblP1_P2.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblP1_P2.ForeColor = System.Drawing.Color.Black;
            this.lblP1_P2.Location = new System.Drawing.Point(223, 38);
            this.lblP1_P2.Name = "lblP1_P2";
            this.lblP1_P2.Size = new System.Drawing.Size(130, 55);
            this.lblP1_P2.TabIndex = 1305;
            this.lblP1_P2.Text = "400.02/ 394.98 (2.3)";
            this.lblP1_P2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Gulim", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(164, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 1304;
            this.label1.Text = "P1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResultP1
            // 
            this.lblResultP1.BackColor = System.Drawing.Color.Chartreuse;
            this.lblResultP1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblResultP1.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultP1.ForeColor = System.Drawing.Color.White;
            this.lblResultP1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblResultP1.Location = new System.Drawing.Point(164, 38);
            this.lblResultP1.Name = "lblResultP1";
            this.lblResultP1.Size = new System.Drawing.Size(59, 55);
            this.lblResultP1.TabIndex = 1303;
            this.lblResultP1.Text = "OK";
            this.lblResultP1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpbxShift
            // 
            this.grpbxShift.Controls.Add(this.lblAZ);
            this.grpbxShift.Controls.Add(this.lblAY);
            this.grpbxShift.Controls.Add(this.label72);
            this.grpbxShift.Controls.Add(this.lblAX);
            this.grpbxShift.Controls.Add(this.label76);
            this.grpbxShift.Controls.Add(this.lblZ);
            this.grpbxShift.Controls.Add(this.label40);
            this.grpbxShift.Controls.Add(this.lblY);
            this.grpbxShift.Controls.Add(this.label69);
            this.grpbxShift.Controls.Add(this.lblX);
            this.grpbxShift.Controls.Add(this.label70);
            this.grpbxShift.Controls.Add(this.label71);
            this.grpbxShift.Font = new System.Drawing.Font("Gulim", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.grpbxShift.Location = new System.Drawing.Point(8, 27);
            this.grpbxShift.Name = "grpbxShift";
            this.grpbxShift.Size = new System.Drawing.Size(119, 171);
            this.grpbxShift.TabIndex = 1302;
            this.grpbxShift.TabStop = false;
            this.grpbxShift.Text = "Shift 값";
            // 
            // lblAZ
            // 
            this.lblAZ.BackColor = System.Drawing.Color.LightYellow;
            this.lblAZ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAZ.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAZ.ForeColor = System.Drawing.Color.Black;
            this.lblAZ.Location = new System.Drawing.Point(51, 140);
            this.lblAZ.Name = "lblAZ";
            this.lblAZ.Size = new System.Drawing.Size(50, 20);
            this.lblAZ.TabIndex = 798;
            this.lblAZ.Text = "123.32";
            this.lblAZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAY
            // 
            this.lblAY.BackColor = System.Drawing.Color.LightYellow;
            this.lblAY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAY.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAY.ForeColor = System.Drawing.Color.Black;
            this.lblAY.Location = new System.Drawing.Point(51, 116);
            this.lblAY.Name = "lblAY";
            this.lblAY.Size = new System.Drawing.Size(50, 20);
            this.lblAY.TabIndex = 797;
            this.lblAY.Text = "123.32";
            this.lblAY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label72
            // 
            this.label72.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label72.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label72.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label72.ForeColor = System.Drawing.Color.White;
            this.label72.Location = new System.Drawing.Point(17, 92);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(33, 20);
            this.label72.TabIndex = 787;
            this.label72.Text = "RX";
            this.label72.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAX
            // 
            this.lblAX.BackColor = System.Drawing.Color.LightYellow;
            this.lblAX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAX.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAX.ForeColor = System.Drawing.Color.Black;
            this.lblAX.Location = new System.Drawing.Point(51, 92);
            this.lblAX.Name = "lblAX";
            this.lblAX.Size = new System.Drawing.Size(50, 20);
            this.lblAX.TabIndex = 796;
            this.lblAX.Text = "123.32";
            this.lblAX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label76
            // 
            this.label76.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label76.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label76.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label76.ForeColor = System.Drawing.Color.White;
            this.label76.Location = new System.Drawing.Point(17, 116);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(33, 20);
            this.label76.TabIndex = 788;
            this.label76.Text = "RY";
            this.label76.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblZ
            // 
            this.lblZ.BackColor = System.Drawing.Color.LightYellow;
            this.lblZ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblZ.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblZ.ForeColor = System.Drawing.Color.Black;
            this.lblZ.Location = new System.Drawing.Point(51, 67);
            this.lblZ.Name = "lblZ";
            this.lblZ.Size = new System.Drawing.Size(49, 20);
            this.lblZ.TabIndex = 795;
            this.lblZ.Text = "123.32";
            this.lblZ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label40
            // 
            this.label40.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label40.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label40.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label40.ForeColor = System.Drawing.Color.White;
            this.label40.Location = new System.Drawing.Point(17, 140);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(33, 20);
            this.label40.TabIndex = 789;
            this.label40.Text = "RZ";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblY
            // 
            this.lblY.BackColor = System.Drawing.Color.LightYellow;
            this.lblY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblY.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblY.ForeColor = System.Drawing.Color.Black;
            this.lblY.Location = new System.Drawing.Point(51, 43);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(49, 20);
            this.lblY.TabIndex = 794;
            this.lblY.Text = "123.32";
            this.lblY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label69
            // 
            this.label69.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label69.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label69.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label69.ForeColor = System.Drawing.Color.White;
            this.label69.Location = new System.Drawing.Point(17, 19);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(33, 20);
            this.label69.TabIndex = 790;
            this.label69.Text = "X";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblX
            // 
            this.lblX.BackColor = System.Drawing.Color.LightYellow;
            this.lblX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblX.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblX.ForeColor = System.Drawing.Color.Black;
            this.lblX.Location = new System.Drawing.Point(51, 19);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(49, 20);
            this.lblX.TabIndex = 793;
            this.lblX.Text = "123.32";
            this.lblX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label70
            // 
            this.label70.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label70.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label70.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label70.ForeColor = System.Drawing.Color.White;
            this.label70.Location = new System.Drawing.Point(17, 43);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(33, 20);
            this.label70.TabIndex = 791;
            this.label70.Text = "Y";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label71
            // 
            this.label71.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label71.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label71.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label71.ForeColor = System.Drawing.Color.White;
            this.label71.Location = new System.Drawing.Point(17, 67);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(33, 20);
            this.label71.TabIndex = 792;
            this.label71.Text = "Z";
            this.label71.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblP1_P3
            // 
            this.lblP1_P3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.lblP1_P3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblP1_P3.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblP1_P3.ForeColor = System.Drawing.Color.Black;
            this.lblP1_P3.Location = new System.Drawing.Point(223, 105);
            this.lblP1_P3.Name = "lblP1_P3";
            this.lblP1_P3.Size = new System.Drawing.Size(130, 30);
            this.lblP1_P3.TabIndex = 1301;
            this.lblP1_P3.Text = "400.02/  394.98(2.3)";
            this.lblP1_P3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblXY_XX
            // 
            this.lblXY_XX.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblXY_XX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblXY_XX.Font = new System.Drawing.Font("Gulim", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblXY_XX.ForeColor = System.Drawing.Color.Orange;
            this.lblXY_XX.Location = new System.Drawing.Point(223, 91);
            this.lblXY_XX.Name = "lblXY_XX";
            this.lblXY_XX.Size = new System.Drawing.Size(130, 16);
            this.lblXY_XX.TabIndex = 1300;
            this.lblXY_XX.Text = "P1 - P3";
            this.lblXY_XX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label36
            // 
            this.label36.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label36.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label36.Font = new System.Drawing.Font("Gulim", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label36.ForeColor = System.Drawing.Color.Orange;
            this.label36.Location = new System.Drawing.Point(352, 17);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(59, 20);
            this.label36.TabIndex = 1299;
            this.label36.Text = "P2";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblP2_P3
            // 
            this.lblP2_P3.BackColor = System.Drawing.Color.LimeGreen;
            this.lblP2_P3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblP2_P3.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblP2_P3.ForeColor = System.Drawing.Color.Black;
            this.lblP2_P3.Location = new System.Drawing.Point(352, 93);
            this.lblP2_P3.Name = "lblP2_P3";
            this.lblP2_P3.Size = new System.Drawing.Size(59, 60);
            this.lblP2_P3.TabIndex = 1298;
            this.lblP2_P3.Text = "400.02/  394.98(2.3)";
            this.lblP2_P3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label28.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label28.Font = new System.Drawing.Font("Gulim", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label28.ForeColor = System.Drawing.Color.Orange;
            this.label28.Location = new System.Drawing.Point(353, 154);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(58, 20);
            this.label28.TabIndex = 1297;
            this.label28.Text = "P3";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResultP2
            // 
            this.lblResultP2.BackColor = System.Drawing.Color.Chartreuse;
            this.lblResultP2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblResultP2.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultP2.ForeColor = System.Drawing.Color.White;
            this.lblResultP2.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblResultP2.Location = new System.Drawing.Point(353, 37);
            this.lblResultP2.Name = "lblResultP2";
            this.lblResultP2.Size = new System.Drawing.Size(59, 55);
            this.lblResultP2.TabIndex = 1296;
            this.lblResultP2.Text = "OK";
            this.lblResultP2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblResultP3
            // 
            this.lblResultP3.BackColor = System.Drawing.Color.Chartreuse;
            this.lblResultP3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblResultP3.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResultP3.ForeColor = System.Drawing.Color.White;
            this.lblResultP3.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblResultP3.Location = new System.Drawing.Point(352, 175);
            this.lblResultP3.Name = "lblResultP3";
            this.lblResultP3.Size = new System.Drawing.Size(59, 53);
            this.lblResultP3.TabIndex = 1295;
            this.lblResultP3.Text = "OK";
            this.lblResultP3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblResultP2);
            this.groupBox1.Controls.Add(this.lblResultP3);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.lblP2_P3);
            this.groupBox1.Controls.Add(this.label36);
            this.groupBox1.Controls.Add(this.lblXY_XX);
            this.groupBox1.Controls.Add(this.lblP1_P3);
            this.groupBox1.Controls.Add(this.lblResultP1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblP1_P2);
            this.groupBox1.Controls.Add(this.grpbxShift);
            this.groupBox1.Font = new System.Drawing.Font("Gulim", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(840, 380);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(419, 229);
            this.groupBox1.TabIndex = 1294;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "3D 결과";
            // 
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1264, 987);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tc3D_2D);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.btnExposure);
            this.Controls.Add(this.btnFileDel);
            this.Controls.Add(this.btnTypeSet);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblAuto);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this._lblResult);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnLimitSet);
            this.Controls.Add(this._grpbxCommState);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.lstbxMessage);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "샤시토크";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox3.ResumeLayout(false);
            this._grpbxCommState.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tc3D_2D.ResumeLayout(false);
            this.TC1.ResumeLayout(false);
            this.TC1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayP3_R)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayP3_L)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayP2_R)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayP1_L)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayP2_L)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayP1_R)).EndInit();
            this.TC2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayRH2_L)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayRH1_R)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayRH2_R)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayRH1_L)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayLH2_L)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayLH1_R)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayLH2_R)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplayLH1_L)).EndInit();
            this.grpbxShift.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer tmrFileDel;
        private System.Windows.Forms.Timer tmrReconnect;
        private System.Windows.Forms.Timer tmrSaveJpeg;
        private System.Windows.Forms.ListBox lstbxMessage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label _lblResult;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lblStateCommPLC_R;
        private System.Windows.Forms.Label lblStateCommRbtL;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.GroupBox _grpbxCommState;
        private System.Windows.Forms.Button btnLimitSet;
        private System.Windows.Forms.Button btnManual3D;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ComboBox cmbLoadImg;
        private System.Windows.Forms.Label lblAuto;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label _lblCar;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblStateCommPLC_W;
        private System.Windows.Forms.Button btnTypeSet;
        private System.Windows.Forms.Button btnFileDel;
        private System.Windows.Forms.Label lblBodyNo;
        private System.Windows.Forms.Label lblSeqNo;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label lblStateCommRbtR;
        private System.Windows.Forms.Timer tmrLive;
        private System.Windows.Forms.Button btnExposure;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private ATMC.Controls.AIOMapControl aioMapOUT;
        private ATMC.Controls.AIOMapControl aioMapIN;
        private System.Windows.Forms.ImageList imglstCase;
        private System.Windows.Forms.Timer tmrGigEReconnect;
        private System.Windows.Forms.TabControl tc3D_2D;
        private System.Windows.Forms.TabPage TC1;
        private System.Windows.Forms.Button btnLengthLoad;
        private Cognex.VisionPro.CogDisplayStatusBarV2 cogDisplayStatusBarP3_R;
        private Cognex.VisionPro.CogDisplayStatusBarV2 cogDisplayStatusBarP2_R;
        private Cognex.VisionPro.CogDisplayStatusBarV2 cogDisplayStatusBarP1_R;
        private Cognex.VisionPro.CogDisplayStatusBarV2 cogDisplayStatusBarP3_L;
        private Cognex.VisionPro.CogDisplayStatusBarV2 cogDisplayStatusBarP2_L;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblY_P3R;
        private System.Windows.Forms.Label lblX_P3R;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label lblY_P3L;
        private System.Windows.Forms.Label lblX_P3L;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label lblY_P2R;
        private System.Windows.Forms.Label lblX_P2R;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label lblY_P2L;
        private System.Windows.Forms.Label lblX_P2L;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label lblY_P1R;
        private System.Windows.Forms.Label lblX_P1R;
        private Cognex.VisionPro.CogDisplayStatusBarV2 cogDisplayStatusBarP1_L;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblY_P1L;
        private System.Windows.Forms.Label lblX_P1L;
        private System.Windows.Forms.Label lblZ_CalibSubP3;
        private System.Windows.Forms.Label lblY_CalibSubP3;
        private System.Windows.Forms.Label lblX_CalibSubP3;
        private System.Windows.Forms.Label lblZ_CalibSubP2;
        private System.Windows.Forms.Label lblY_CalibSubP2;
        private System.Windows.Forms.Label lblX_CalibSubP2;
        private System.Windows.Forms.Label lblZ_CalibSubP1;
        private System.Windows.Forms.Label lblY_CalibSubP1;
        private System.Windows.Forms.Label lblX_CalibSubP1;
        private System.Windows.Forms.CheckBox chkLiveSearchP3;
        private System.Windows.Forms.CheckBox chkLiveSearchP2;
        private System.Windows.Forms.CheckBox chkLiveSearchP1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblZ_CalibP3;
        private System.Windows.Forms.Label lblY_CalibP3;
        private System.Windows.Forms.Label lblX_CalibP3;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblZ_CalibP2;
        private System.Windows.Forms.Label lblY_CalibP2;
        private System.Windows.Forms.Label lblX_CalibP2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblZ_P2;
        private System.Windows.Forms.Label lblY_P2;
        private System.Windows.Forms.Label lblX_P2;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label lblZ_P3;
        private System.Windows.Forms.Label lblY_P3;
        private System.Windows.Forms.Label lblX_P3;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.CheckBox chkLiveP3;
        private System.Windows.Forms.CheckBox chkLiveP2;
        private System.Windows.Forms.CheckBox chkLiveP1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblZ_CalibP1;
        private System.Windows.Forms.Label lblY_CalibP1;
        private System.Windows.Forms.Label lblX_CalibP1;
        private System.Windows.Forms.Label lblZ_P1;
        private System.Windows.Forms.Label lblY_P1;
        private System.Windows.Forms.Label lblX_P1;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblCalibP2;
        private System.Windows.Forms.Label lblTitleP2;
        private System.Windows.Forms.Label lblCalibP3;
        private System.Windows.Forms.Label lblTitleP3;
        private System.Windows.Forms.Label lblCalibP1;
        private System.Windows.Forms.Label lblTitleP1;
        private Cognex.VisionPro.Display.CogDisplay cogDisplayP3_R;
        private Cognex.VisionPro.Display.CogDisplay cogDisplayP3_L;
        private Cognex.VisionPro.Display.CogDisplay cogDisplayP2_R;
        private Cognex.VisionPro.Display.CogDisplay cogDisplayP1_L;
        private Cognex.VisionPro.Display.CogDisplay cogDisplayP2_L;
        private Cognex.VisionPro.Display.CogDisplay cogDisplayP1_R;
        private System.Windows.Forms.Label lblP1_P2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblResultP1;
        private System.Windows.Forms.GroupBox grpbxShift;
        private System.Windows.Forms.Label lblAZ;
        private System.Windows.Forms.Label lblAY;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Label lblAX;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.Label lblZ;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Label lblP1_P3;
        private System.Windows.Forms.Label lblXY_XX;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label lblP2_P3;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label lblResultP2;
        private System.Windows.Forms.Label lblResultP3;
        private System.Windows.Forms.Button btnLengthSet;
        private System.Windows.Forms.Button btnPartOffsetSet;
        private System.Windows.Forms.TabPage TC2;
        private System.Windows.Forms.Label lblY_RH2_R;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label lblX_RH2_R;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label lblY_RH1_R;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Label lblX_RH1_R;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label lblY_LH2_R;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label lblX_LH2_R;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label lblY_LH1_R;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label lblX_LH1_R;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label lblY_RH2_L;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblX_RH2_L;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lblY_RH1_L;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lblX_RH1_L;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label lblY_LH2_L;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblX_LH2_L;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblY_LH1_L;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblX_LH1_L;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label6;
        private Cognex.VisionPro.Display.CogDisplay cogDisplayRH2_L;
        private System.Windows.Forms.Label lblTitleRH2_L;
        private Cognex.VisionPro.Display.CogDisplay cogDisplayRH1_R;
        private System.Windows.Forms.Label lblTitleRH1_R;
        private Cognex.VisionPro.Display.CogDisplay cogDisplayRH2_R;
        private System.Windows.Forms.Label lblTitleRH2_R;
        private Cognex.VisionPro.Display.CogDisplay cogDisplayRH1_L;
        private System.Windows.Forms.Label lblTitleRH1_L;
        private Cognex.VisionPro.Display.CogDisplay cogDisplayLH2_L;
        private System.Windows.Forms.Label lblTitleLH2_L;
        private Cognex.VisionPro.Display.CogDisplay cogDisplayLH1_R;
        private System.Windows.Forms.Label lblTitleLH1_R;
        private Cognex.VisionPro.Display.CogDisplay cogDisplayLH2_R;
        private System.Windows.Forms.Label lblTitleLH2_R;
        private Cognex.VisionPro.Display.CogDisplay cogDisplayLH1_L;
        private System.Windows.Forms.Label lblTitleLH1_L;
        private System.Windows.Forms.Button btnOffsetSetRH2_R;
        private System.Windows.Forms.Button btnOffsetSetLH2_R;
        private System.Windows.Forms.Button btnOffsetSetRH1_R;
        private System.Windows.Forms.Button btnOffsetSetLH1_R;
        private System.Windows.Forms.Button btnOffsetSetRH2_L;
        private System.Windows.Forms.Button btnOffsetSetLH2_L;
        private System.Windows.Forms.Button btnOffsetSetRH1_L;
        private System.Windows.Forms.Button btnOffsetSetLH1_L;
        private System.Windows.Forms.Button btnManualP3;
        private System.Windows.Forms.Button btnManualP2;
        private System.Windows.Forms.Button btnManualP1;
        private System.Windows.Forms.Button btnManualRH2_R;
        private System.Windows.Forms.Button btnManualLH2_R;
        private System.Windows.Forms.Button btnManualRH1_R;
        private System.Windows.Forms.Button btnManualLH1_R;
        private System.Windows.Forms.Button btnManualRH2_L;
        private System.Windows.Forms.Button btnManualLH2_L;
        private System.Windows.Forms.Button btnManualRH1_L;
        private System.Windows.Forms.Button btnManualLH1_L;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

