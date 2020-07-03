namespace AVisionPro
{
    partial class ATbCalibNPointToNPoint
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATbCalibNPointToNPoint));
            this.lblTitle = new System.Windows.Forms.Label();
            this.cogDisplay = new Cognex.VisionPro.Display.CogDisplay();
            this.tmrTime = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPoint1X = new System.Windows.Forms.TextBox();
            this.txtPoint0X = new System.Windows.Forms.TextBox();
            this.lblPoint0 = new System.Windows.Forms.Label();
            this.grpbxPlate = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPoint2Y = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPoint1Y = new System.Windows.Forms.TextBox();
            this.txtPoint0Y = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPoint2X = new System.Windows.Forms.TextBox();
            this.lblRawCalibratedY = new System.Windows.Forms.Label();
            this.lblRawCalibratedX = new System.Windows.Forms.Label();
            this.lblPoint2 = new System.Windows.Forms.Label();
            this.lblPoint1 = new System.Windows.Forms.Label();
            this.btnLoadInit = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnAcquireLive = new System.Windows.Forms.Button();
            this.btnAcquireSingle = new System.Windows.Forms.Button();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSaveVPP = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stslblAtmlogo = new System.Windows.Forms.ToolStripStatusLabel();
            this.stslblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.stslblTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnLoadCalibImage = new System.Windows.Forms.Button();
            this.cogDisplayStatusBar = new Cognex.VisionPro.CogDisplayStatusBarV2();
            this.btnSetup = new System.Windows.Forms.Button();
            this.btnLoadDirectory = new System.Windows.Forms.Button();
            this.tmrLive = new System.Windows.Forms.Timer(this.components);
            this.btnLoadBefore = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnLoadNext = new System.Windows.Forms.Button();
            this.grpbxAcquisition = new System.Windows.Forms.GroupBox();
            this.txtBrightness = new System.Windows.Forms.TextBox();
            this.lblBrightness = new System.Windows.Forms.Label();
            this.txtContrast = new System.Windows.Forms.TextBox();
            this.txtExposure = new System.Windows.Forms.TextBox();
            this.lblExposure = new System.Windows.Forms.Label();
            this.lblContrast = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay)).BeginInit();
            this.grpbxPlate.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.grpbxAcquisition.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Gray;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Lavender;
            this.lblTitle.Location = new System.Drawing.Point(12, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(867, 43);
            this.lblTitle.TabIndex = 99;
            this.lblTitle.Text = "TypeName";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.DoubleClick += new System.EventHandler(this.lblTitle_DoubleClick);
            // 
            // cogDisplay
            // 
            this.cogDisplay.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisplay.ColorMapLowerRoiLimit = 0D;
            this.cogDisplay.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisplay.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisplay.ColorMapUpperRoiLimit = 1D;
            this.cogDisplay.Location = new System.Drawing.Point(12, 52);
            this.cogDisplay.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisplay.MouseWheelSensitivity = 1D;
            this.cogDisplay.Name = "cogDisplay";
            this.cogDisplay.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisplay.OcxState")));
            this.cogDisplay.Size = new System.Drawing.Size(867, 640);
            this.cogDisplay.TabIndex = 87;
            this.cogDisplay.DoubleClick += new System.EventHandler(this.cogDisplay_DoubleClick);
            // 
            // tmrTime
            // 
            this.tmrTime.Enabled = true;
            this.tmrTime.Interval = 1000;
            this.tmrTime.Tick += new System.EventHandler(this.tmrTime_Tick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(201, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 16);
            this.label7.TabIndex = 4;
            this.label7.Text = "mm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(201, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "mm";
            // 
            // txtPoint1X
            // 
            this.txtPoint1X.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPoint1X.Location = new System.Drawing.Point(105, 79);
            this.txtPoint1X.Name = "txtPoint1X";
            this.txtPoint1X.Size = new System.Drawing.Size(94, 22);
            this.txtPoint1X.TabIndex = 3;
            this.txtPoint1X.Text = "1";
            this.txtPoint1X.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoubleKeyPress);
            // 
            // txtPoint0X
            // 
            this.txtPoint0X.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPoint0X.Location = new System.Drawing.Point(105, 44);
            this.txtPoint0X.Name = "txtPoint0X";
            this.txtPoint0X.Size = new System.Drawing.Size(94, 22);
            this.txtPoint0X.TabIndex = 3;
            this.txtPoint0X.Text = "1";
            this.txtPoint0X.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoubleKeyPress);
            // 
            // lblPoint0
            // 
            this.lblPoint0.BackColor = System.Drawing.Color.Gray;
            this.lblPoint0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoint0.ForeColor = System.Drawing.Color.LightYellow;
            this.lblPoint0.Location = new System.Drawing.Point(6, 43);
            this.lblPoint0.Name = "lblPoint0";
            this.lblPoint0.Size = new System.Drawing.Size(84, 23);
            this.lblPoint0.TabIndex = 0;
            this.lblPoint0.Text = "Point0";
            this.lblPoint0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpbxPlate
            // 
            this.grpbxPlate.Controls.Add(this.label8);
            this.grpbxPlate.Controls.Add(this.txtPoint2Y);
            this.grpbxPlate.Controls.Add(this.label12);
            this.grpbxPlate.Controls.Add(this.label13);
            this.grpbxPlate.Controls.Add(this.txtPoint1Y);
            this.grpbxPlate.Controls.Add(this.txtPoint0Y);
            this.grpbxPlate.Controls.Add(this.label6);
            this.grpbxPlate.Controls.Add(this.txtPoint2X);
            this.grpbxPlate.Controls.Add(this.lblRawCalibratedY);
            this.grpbxPlate.Controls.Add(this.lblRawCalibratedX);
            this.grpbxPlate.Controls.Add(this.lblPoint2);
            this.grpbxPlate.Controls.Add(this.lblPoint1);
            this.grpbxPlate.Controls.Add(this.label7);
            this.grpbxPlate.Controls.Add(this.label1);
            this.grpbxPlate.Controls.Add(this.txtPoint1X);
            this.grpbxPlate.Controls.Add(this.txtPoint0X);
            this.grpbxPlate.Controls.Add(this.lblPoint0);
            this.grpbxPlate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxPlate.ForeColor = System.Drawing.Color.Gray;
            this.grpbxPlate.Location = new System.Drawing.Point(893, 6);
            this.grpbxPlate.Name = "grpbxPlate";
            this.grpbxPlate.Size = new System.Drawing.Size(367, 162);
            this.grpbxPlate.TabIndex = 88;
            this.grpbxPlate.TabStop = false;
            this.grpbxPlate.Text = "Calibration Setting";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(332, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 16);
            this.label8.TabIndex = 16;
            this.label8.Text = "mm";
            // 
            // txtPoint2Y
            // 
            this.txtPoint2Y.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPoint2Y.Location = new System.Drawing.Point(236, 113);
            this.txtPoint2Y.Name = "txtPoint2Y";
            this.txtPoint2Y.Size = new System.Drawing.Size(94, 22);
            this.txtPoint2Y.TabIndex = 15;
            this.txtPoint2Y.Text = "1";
            this.txtPoint2Y.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoubleKeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(332, 84);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 16);
            this.label12.TabIndex = 14;
            this.label12.Text = "mm";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(332, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 16);
            this.label13.TabIndex = 13;
            this.label13.Text = "mm";
            // 
            // txtPoint1Y
            // 
            this.txtPoint1Y.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPoint1Y.Location = new System.Drawing.Point(236, 78);
            this.txtPoint1Y.Name = "txtPoint1Y";
            this.txtPoint1Y.Size = new System.Drawing.Size(94, 22);
            this.txtPoint1Y.TabIndex = 11;
            this.txtPoint1Y.Text = "1";
            this.txtPoint1Y.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoubleKeyPress);
            // 
            // txtPoint0Y
            // 
            this.txtPoint0Y.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPoint0Y.Location = new System.Drawing.Point(236, 43);
            this.txtPoint0Y.Name = "txtPoint0Y";
            this.txtPoint0Y.Size = new System.Drawing.Size(94, 22);
            this.txtPoint0Y.TabIndex = 12;
            this.txtPoint0Y.Text = "1";
            this.txtPoint0Y.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoubleKeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(201, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "mm";
            // 
            // txtPoint2X
            // 
            this.txtPoint2X.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPoint2X.Location = new System.Drawing.Point(105, 114);
            this.txtPoint2X.Name = "txtPoint2X";
            this.txtPoint2X.Size = new System.Drawing.Size(94, 22);
            this.txtPoint2X.TabIndex = 9;
            this.txtPoint2X.Text = "1";
            this.txtPoint2X.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoubleKeyPress);
            // 
            // lblRawCalibratedY
            // 
            this.lblRawCalibratedY.BackColor = System.Drawing.Color.Gray;
            this.lblRawCalibratedY.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRawCalibratedY.ForeColor = System.Drawing.Color.LightYellow;
            this.lblRawCalibratedY.Location = new System.Drawing.Point(233, 17);
            this.lblRawCalibratedY.Name = "lblRawCalibratedY";
            this.lblRawCalibratedY.Size = new System.Drawing.Size(94, 23);
            this.lblRawCalibratedY.TabIndex = 8;
            this.lblRawCalibratedY.Text = "Raw Calibrated Y";
            this.lblRawCalibratedY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRawCalibratedX
            // 
            this.lblRawCalibratedX.BackColor = System.Drawing.Color.Gray;
            this.lblRawCalibratedX.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRawCalibratedX.ForeColor = System.Drawing.Color.LightYellow;
            this.lblRawCalibratedX.Location = new System.Drawing.Point(102, 17);
            this.lblRawCalibratedX.Name = "lblRawCalibratedX";
            this.lblRawCalibratedX.Size = new System.Drawing.Size(94, 23);
            this.lblRawCalibratedX.TabIndex = 7;
            this.lblRawCalibratedX.Text = "Raw Calibrated X";
            this.lblRawCalibratedX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPoint2
            // 
            this.lblPoint2.BackColor = System.Drawing.Color.Gray;
            this.lblPoint2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoint2.ForeColor = System.Drawing.Color.LightYellow;
            this.lblPoint2.Location = new System.Drawing.Point(6, 113);
            this.lblPoint2.Name = "lblPoint2";
            this.lblPoint2.Size = new System.Drawing.Size(84, 23);
            this.lblPoint2.TabIndex = 6;
            this.lblPoint2.Text = "Point2";
            this.lblPoint2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPoint1
            // 
            this.lblPoint1.BackColor = System.Drawing.Color.Gray;
            this.lblPoint1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPoint1.ForeColor = System.Drawing.Color.LightYellow;
            this.lblPoint1.Location = new System.Drawing.Point(6, 78);
            this.lblPoint1.Name = "lblPoint1";
            this.lblPoint1.Size = new System.Drawing.Size(84, 23);
            this.lblPoint1.TabIndex = 5;
            this.lblPoint1.Text = "Point1";
            this.lblPoint1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLoadInit
            // 
            this.btnLoadInit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadInit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLoadInit.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadInit.Image")));
            this.btnLoadInit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadInit.Location = new System.Drawing.Point(672, 794);
            this.btnLoadInit.Name = "btnLoadInit";
            this.btnLoadInit.Size = new System.Drawing.Size(207, 48);
            this.btnLoadInit.TabIndex = 100;
            this.btnLoadInit.Text = "        Load Init Image";
            this.btnLoadInit.UseVisualStyleBackColor = true;
            this.btnLoadInit.Click += new System.EventHandler(this.btnLoadInit_Click);
            // 
            // btnRun
            // 
            this.btnRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRun.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRun.Image = ((System.Drawing.Image)(resources.GetObject("btnRun.Image")));
            this.btnRun.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRun.Location = new System.Drawing.Point(893, 729);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(211, 48);
            this.btnRun.TabIndex = 97;
            this.btnRun.Text = "     Run Calibration";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnAcquireLive
            // 
            this.btnAcquireLive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcquireLive.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAcquireLive.Image = ((System.Drawing.Image)(resources.GetObject("btnAcquireLive.Image")));
            this.btnAcquireLive.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAcquireLive.Location = new System.Drawing.Point(232, 794);
            this.btnAcquireLive.Name = "btnAcquireLive";
            this.btnAcquireLive.Size = new System.Drawing.Size(207, 48);
            this.btnAcquireLive.TabIndex = 96;
            this.btnAcquireLive.Text = "        Acquire Live Video";
            this.btnAcquireLive.UseVisualStyleBackColor = true;
            this.btnAcquireLive.Click += new System.EventHandler(this.btnAcquireLive_Click);
            // 
            // btnAcquireSingle
            // 
            this.btnAcquireSingle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcquireSingle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAcquireSingle.Image = ((System.Drawing.Image)(resources.GetObject("btnAcquireSingle.Image")));
            this.btnAcquireSingle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAcquireSingle.Location = new System.Drawing.Point(12, 794);
            this.btnAcquireSingle.Name = "btnAcquireSingle";
            this.btnAcquireSingle.Size = new System.Drawing.Size(207, 48);
            this.btnAcquireSingle.TabIndex = 98;
            this.btnAcquireSingle.Text = "        Acquire Single Image";
            this.btnAcquireSingle.UseVisualStyleBackColor = true;
            this.btnAcquireSingle.Click += new System.EventHandler(this.btnAcquireSingle_Click);
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveImage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSaveImage.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveImage.Image")));
            this.btnSaveImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveImage.Location = new System.Drawing.Point(672, 848);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(207, 48);
            this.btnSaveImage.TabIndex = 95;
            this.btnSaveImage.Text = "       Save Image File";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.AllowDrop = true;
            this.btnLoadImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadImage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLoadImage.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadImage.Image")));
            this.btnLoadImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadImage.Location = new System.Drawing.Point(12, 848);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(207, 48);
            this.btnLoadImage.TabIndex = 94;
            this.btnLoadImage.Text = "       Load Image File";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            this.btnLoadImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnLoadImage_DragDrop);
            this.btnLoadImage.DragOver += new System.Windows.Forms.DragEventHandler(this.btnLoadImage_DragOver);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1014, 878);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(235, 48);
            this.btnClose.TabIndex = 92;
            this.btnClose.Text = "    Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSaveVPP
            // 
            this.btnSaveVPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveVPP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSaveVPP.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveVPP.Image")));
            this.btnSaveVPP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveVPP.Location = new System.Drawing.Point(1014, 824);
            this.btnSaveVPP.Name = "btnSaveVPP";
            this.btnSaveVPP.Size = new System.Drawing.Size(235, 48);
            this.btnSaveVPP.TabIndex = 93;
            this.btnSaveVPP.Text = "    Save Calibraiton VPP";
            this.btnSaveVPP.UseVisualStyleBackColor = true;
            this.btnSaveVPP.Click += new System.EventHandler(this.btnSaveVPP_Click);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(788, 657);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(91, 35);
            this.btnOK.TabIndex = 90;
            this.btnOK.Text = "   OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stslblAtmlogo,
            this.stslblStatus,
            this.stslblTime});
            this.statusStrip1.Location = new System.Drawing.Point(0, 934);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1272, 30);
            this.statusStrip1.TabIndex = 104;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.DoubleClick += new System.EventHandler(this.statusStrip1_DoubleClick);
            // 
            // stslblAtmlogo
            // 
            this.stslblAtmlogo.AutoSize = false;
            this.stslblAtmlogo.Image = ((System.Drawing.Image)(resources.GetObject("stslblAtmlogo.Image")));
            this.stslblAtmlogo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.stslblAtmlogo.Name = "stslblAtmlogo";
            this.stslblAtmlogo.Size = new System.Drawing.Size(255, 25);
            // 
            // stslblStatus
            // 
            this.stslblStatus.AutoSize = false;
            this.stslblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stslblStatus.ForeColor = System.Drawing.Color.Crimson;
            this.stslblStatus.Name = "stslblStatus";
            this.stslblStatus.Size = new System.Drawing.Size(850, 25);
            this.stslblStatus.Text = "Not Calibrated!";
            // 
            // stslblTime
            // 
            this.stslblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stslblTime.Name = "stslblTime";
            this.stslblTime.Size = new System.Drawing.Size(122, 25);
            this.stslblTime.Text = "2010-01-01 12:00:00";
            // 
            // btnLoadCalibImage
            // 
            this.btnLoadCalibImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadCalibImage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLoadCalibImage.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadCalibImage.Image")));
            this.btnLoadCalibImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadCalibImage.Location = new System.Drawing.Point(452, 794);
            this.btnLoadCalibImage.Name = "btnLoadCalibImage";
            this.btnLoadCalibImage.Size = new System.Drawing.Size(207, 48);
            this.btnLoadCalibImage.TabIndex = 105;
            this.btnLoadCalibImage.Text = "       Calibration Image";
            this.btnLoadCalibImage.UseVisualStyleBackColor = true;
            this.btnLoadCalibImage.Click += new System.EventHandler(this.btnLoadCalibImage_Click);
            // 
            // cogDisplayStatusBar
            // 
            this.cogDisplayStatusBar.CoordinateSpaceName = "*\\#";
            this.cogDisplayStatusBar.Location = new System.Drawing.Point(12, 692);
            this.cogDisplayStatusBar.Name = "cogDisplayStatusBar";
            this.cogDisplayStatusBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cogDisplayStatusBar.Size = new System.Drawing.Size(867, 23);
            this.cogDisplayStatusBar.TabIndex = 106;
            // 
            // btnSetup
            // 
            this.btnSetup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSetup.Image = ((System.Drawing.Image)(resources.GetObject("btnSetup.Image")));
            this.btnSetup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetup.Location = new System.Drawing.Point(893, 563);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(211, 48);
            this.btnSetup.TabIndex = 107;
            this.btnSetup.Text = "           Setup Calibration";
            this.btnSetup.UseVisualStyleBackColor = true;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // btnLoadDirectory
            // 
            this.btnLoadDirectory.AllowDrop = true;
            this.btnLoadDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadDirectory.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLoadDirectory.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadDirectory.Image")));
            this.btnLoadDirectory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadDirectory.Location = new System.Drawing.Point(232, 848);
            this.btnLoadDirectory.Name = "btnLoadDirectory";
            this.btnLoadDirectory.Size = new System.Drawing.Size(207, 48);
            this.btnLoadDirectory.TabIndex = 108;
            this.btnLoadDirectory.Text = "       Load Image Directory";
            this.btnLoadDirectory.UseVisualStyleBackColor = true;
            this.btnLoadDirectory.Click += new System.EventHandler(this.btnLoadDirectory_Click);
            this.btnLoadDirectory.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnLoadDirectory_DragDrop);
            this.btnLoadDirectory.DragOver += new System.Windows.Forms.DragEventHandler(this.btnLoadDirectory_DragOver);
            // 
            // tmrLive
            // 
            this.tmrLive.Interval = 300;
            this.tmrLive.Tick += new System.EventHandler(this.tmrLive_Tick);
            // 
            // btnLoadBefore
            // 
            this.btnLoadBefore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadBefore.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLoadBefore.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadBefore.Image")));
            this.btnLoadBefore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadBefore.Location = new System.Drawing.Point(452, 848);
            this.btnLoadBefore.Name = "btnLoadBefore";
            this.btnLoadBefore.Size = new System.Drawing.Size(104, 48);
            this.btnLoadBefore.TabIndex = 115;
            this.btnLoadBefore.Text = "        Before";
            this.btnLoadBefore.UseVisualStyleBackColor = true;
            this.btnLoadBefore.Click += new System.EventHandler(this.btnLoadBefore_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(17, 721);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(11, 12);
            this.lblFileName.TabIndex = 114;
            this.lblFileName.Text = "_";
            // 
            // btnLoadNext
            // 
            this.btnLoadNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadNext.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLoadNext.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadNext.Image")));
            this.btnLoadNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoadNext.Location = new System.Drawing.Point(555, 848);
            this.btnLoadNext.Name = "btnLoadNext";
            this.btnLoadNext.Size = new System.Drawing.Size(104, 48);
            this.btnLoadNext.TabIndex = 113;
            this.btnLoadNext.Text = "    Next";
            this.btnLoadNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadNext.UseVisualStyleBackColor = true;
            this.btnLoadNext.Click += new System.EventHandler(this.btnLoadNext_Click);
            // 
            // grpbxAcquisition
            // 
            this.grpbxAcquisition.Controls.Add(this.txtBrightness);
            this.grpbxAcquisition.Controls.Add(this.lblBrightness);
            this.grpbxAcquisition.Controls.Add(this.txtContrast);
            this.grpbxAcquisition.Controls.Add(this.txtExposure);
            this.grpbxAcquisition.Controls.Add(this.lblExposure);
            this.grpbxAcquisition.Controls.Add(this.lblContrast);
            this.grpbxAcquisition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxAcquisition.ForeColor = System.Drawing.Color.Gray;
            this.grpbxAcquisition.Location = new System.Drawing.Point(13, 740);
            this.grpbxAcquisition.Name = "grpbxAcquisition";
            this.grpbxAcquisition.Size = new System.Drawing.Size(867, 50);
            this.grpbxAcquisition.TabIndex = 112;
            this.grpbxAcquisition.TabStop = false;
            this.grpbxAcquisition.Text = "Acquisition";
            // 
            // txtBrightness
            // 
            this.txtBrightness.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrightness.Location = new System.Drawing.Point(491, 18);
            this.txtBrightness.Name = "txtBrightness";
            this.txtBrightness.Size = new System.Drawing.Size(69, 22);
            this.txtBrightness.TabIndex = 39;
            this.txtBrightness.Text = "0.5";
            this.txtBrightness.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUDoubleKeyPress);
            // 
            // lblBrightness
            // 
            this.lblBrightness.BackColor = System.Drawing.Color.Gray;
            this.lblBrightness.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrightness.ForeColor = System.Drawing.Color.LightYellow;
            this.lblBrightness.Location = new System.Drawing.Point(400, 18);
            this.lblBrightness.Name = "lblBrightness";
            this.lblBrightness.Size = new System.Drawing.Size(85, 23);
            this.lblBrightness.TabIndex = 38;
            this.lblBrightness.Text = "Brightness";
            this.lblBrightness.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtContrast
            // 
            this.txtContrast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrast.Location = new System.Drawing.Point(316, 19);
            this.txtContrast.Name = "txtContrast";
            this.txtContrast.Size = new System.Drawing.Size(69, 22);
            this.txtContrast.TabIndex = 3;
            this.txtContrast.Text = "0.5";
            this.txtContrast.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUDoubleKeyPress);
            // 
            // txtExposure
            // 
            this.txtExposure.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExposure.Location = new System.Drawing.Point(115, 19);
            this.txtExposure.Name = "txtExposure";
            this.txtExposure.Size = new System.Drawing.Size(69, 22);
            this.txtExposure.TabIndex = 3;
            this.txtExposure.Text = "0.5";
            this.txtExposure.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExposure_KeyPress);
            // 
            // lblExposure
            // 
            this.lblExposure.BackColor = System.Drawing.Color.Gray;
            this.lblExposure.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExposure.ForeColor = System.Drawing.Color.LightYellow;
            this.lblExposure.Location = new System.Drawing.Point(24, 19);
            this.lblExposure.Name = "lblExposure";
            this.lblExposure.Size = new System.Drawing.Size(85, 23);
            this.lblExposure.TabIndex = 0;
            this.lblExposure.Text = "Exposure";
            this.lblExposure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblContrast
            // 
            this.lblContrast.BackColor = System.Drawing.Color.Gray;
            this.lblContrast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrast.ForeColor = System.Drawing.Color.LightYellow;
            this.lblContrast.Location = new System.Drawing.Point(225, 19);
            this.lblContrast.Name = "lblContrast";
            this.lblContrast.Size = new System.Drawing.Size(85, 23);
            this.lblContrast.TabIndex = 0;
            this.lblContrast.Text = "Contrast";
            this.lblContrast.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ATbCalibNPointToNPoint
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1272, 964);
            this.Controls.Add(this.btnLoadBefore);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnLoadNext);
            this.Controls.Add(this.grpbxAcquisition);
            this.Controls.Add(this.btnLoadDirectory);
            this.Controls.Add(this.btnSetup);
            this.Controls.Add(this.cogDisplayStatusBar);
            this.Controls.Add(this.btnLoadCalibImage);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnLoadInit);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnAcquireLive);
            this.Controls.Add(this.btnAcquireSingle);
            this.Controls.Add(this.btnSaveImage);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSaveVPP);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpbxPlate);
            this.Controls.Add(this.cogDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ATbCalibNPointToNPoint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CalibNPointToNPoint";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ATbCalibNPointToNPoint_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay)).EndInit();
            this.grpbxPlate.ResumeLayout(false);
            this.grpbxPlate.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grpbxAcquisition.ResumeLayout(false);
            this.grpbxAcquisition.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadInit;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Button btnAcquireLive;
        private System.Windows.Forms.Button btnAcquireSingle;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSaveVPP;
        private Cognex.VisionPro.Display.CogDisplay cogDisplay;
        private System.Windows.Forms.Timer tmrTime;
        private System.Windows.Forms.Label lblPoint0;
        private System.Windows.Forms.TextBox txtPoint0X;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox grpbxPlate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPoint1X;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stslblAtmlogo;
        private System.Windows.Forms.ToolStripStatusLabel stslblStatus;
        private System.Windows.Forms.ToolStripStatusLabel stslblTime;
        private System.Windows.Forms.Button btnLoadCalibImage;
        private Cognex.VisionPro.CogDisplayStatusBarV2 cogDisplayStatusBar;
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPoint2Y;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPoint1Y;
        private System.Windows.Forms.TextBox txtPoint0Y;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPoint2X;
        private System.Windows.Forms.Label lblRawCalibratedY;
        private System.Windows.Forms.Label lblRawCalibratedX;
        private System.Windows.Forms.Label lblPoint2;
        private System.Windows.Forms.Label lblPoint1;
        private System.Windows.Forms.Button btnLoadDirectory;
        private System.Windows.Forms.Timer tmrLive;
        private System.Windows.Forms.Button btnLoadBefore;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnLoadNext;
        private System.Windows.Forms.GroupBox grpbxAcquisition;
        private System.Windows.Forms.TextBox txtBrightness;
        private System.Windows.Forms.Label lblBrightness;
        private System.Windows.Forms.TextBox txtContrast;
        private System.Windows.Forms.TextBox txtExposure;
        private System.Windows.Forms.Label lblExposure;
        private System.Windows.Forms.Label lblContrast;
    }
}