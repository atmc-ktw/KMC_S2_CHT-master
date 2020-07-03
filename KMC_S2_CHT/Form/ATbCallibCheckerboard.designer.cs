namespace AVisionPro
{
    partial class ATbCalibCheckerboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATbCalibCheckerboard));
            this.lblTitle = new System.Windows.Forms.Label();
            this.cogDisplay = new Cognex.VisionPro.Display.CogDisplay();
            this.tmrTime = new System.Windows.Forms.Timer(this.components);
            this.colCalibratedY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCalibratedX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUncalibratedY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpbxPlate = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSizeY = new System.Windows.Forms.TextBox();
            this.txtSizeX = new System.Windows.Forms.TextBox();
            this.chkMark = new System.Windows.Forms.CheckBox();
            this.lblSizeY = new System.Windows.Forms.Label();
            this.lblSizeX = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoNonlinear = new System.Windows.Forms.RadioButton();
            this.rdoLinear = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.grpbxResult = new System.Windows.Forms.GroupBox();
            this.chkShowUndistort = new System.Windows.Forms.CheckBox();
            this.btnCompute = new System.Windows.Forms.Button();
            this.lstvwResult = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUncalibratedX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpbxSetting = new System.Windows.Forms.GroupBox();
            this.grpbxOrigin = new System.Windows.Forms.GroupBox();
            this.chkSwap = new System.Windows.Forms.CheckBox();
            this.numUpDnY = new System.Windows.Forms.NumericUpDown();
            this.numUpDnX = new System.Windows.Forms.NumericUpDown();
            this.numUpDnRotation = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblX_AxisRotation = new System.Windows.Forms.Label();
            this.lblOriginY = new System.Windows.Forms.Label();
            this.lblOriginX = new System.Windows.Forms.Label();
            this.btnLoadInit = new System.Windows.Forms.Button();
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
            this.groupBox1.SuspendLayout();
            this.grpbxResult.SuspendLayout();
            this.grpbxSetting.SuspendLayout();
            this.grpbxOrigin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnRotation)).BeginInit();
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
            // colCalibratedY
            // 
            this.colCalibratedY.Text = "CalibratedY";
            this.colCalibratedY.Width = 78;
            // 
            // colCalibratedX
            // 
            this.colCalibratedX.Text = "CalibratedX";
            this.colCalibratedX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colCalibratedX.Width = 89;
            // 
            // colUncalibratedY
            // 
            this.colUncalibratedY.Text = "UncalibratedY";
            this.colUncalibratedY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colUncalibratedY.Width = 73;
            // 
            // grpbxPlate
            // 
            this.grpbxPlate.Controls.Add(this.label7);
            this.grpbxPlate.Controls.Add(this.label1);
            this.grpbxPlate.Controls.Add(this.txtSizeY);
            this.grpbxPlate.Controls.Add(this.txtSizeX);
            this.grpbxPlate.Controls.Add(this.chkMark);
            this.grpbxPlate.Controls.Add(this.lblSizeY);
            this.grpbxPlate.Controls.Add(this.lblSizeX);
            this.grpbxPlate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxPlate.ForeColor = System.Drawing.Color.Gray;
            this.grpbxPlate.Location = new System.Drawing.Point(11, 82);
            this.grpbxPlate.Name = "grpbxPlate";
            this.grpbxPlate.Size = new System.Drawing.Size(345, 126);
            this.grpbxPlate.TabIndex = 3;
            this.grpbxPlate.TabStop = false;
            this.grpbxPlate.Text = "Calibration Plate";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(274, 62);
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
            this.label1.Location = new System.Drawing.Point(274, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "mm";
            // 
            // txtSizeY
            // 
            this.txtSizeY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSizeY.Location = new System.Drawing.Point(162, 59);
            this.txtSizeY.Name = "txtSizeY";
            this.txtSizeY.Size = new System.Drawing.Size(106, 22);
            this.txtSizeY.TabIndex = 3;
            this.txtSizeY.Text = "1";
            this.txtSizeY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUDoubleKeyPress);
            // 
            // txtSizeX
            // 
            this.txtSizeX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSizeX.Location = new System.Drawing.Point(162, 29);
            this.txtSizeX.Name = "txtSizeX";
            this.txtSizeX.Size = new System.Drawing.Size(106, 22);
            this.txtSizeX.TabIndex = 3;
            this.txtSizeX.Text = "1";
            this.txtSizeX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUDoubleKeyPress);
            // 
            // chkMark
            // 
            this.chkMark.AutoSize = true;
            this.chkMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMark.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkMark.Location = new System.Drawing.Point(22, 92);
            this.chkMark.Name = "chkMark";
            this.chkMark.Size = new System.Drawing.Size(107, 20);
            this.chkMark.TabIndex = 3;
            this.chkMark.Text = "Fiducial Mark";
            this.chkMark.UseVisualStyleBackColor = true;
            this.chkMark.Click += new System.EventHandler(this.chkMark_Click);
            // 
            // lblSizeY
            // 
            this.lblSizeY.BackColor = System.Drawing.Color.Gray;
            this.lblSizeY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSizeY.ForeColor = System.Drawing.Color.LightYellow;
            this.lblSizeY.Location = new System.Drawing.Point(19, 59);
            this.lblSizeY.Name = "lblSizeY";
            this.lblSizeY.Size = new System.Drawing.Size(126, 23);
            this.lblSizeY.TabIndex = 0;
            this.lblSizeY.Text = "Size Y";
            this.lblSizeY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSizeX
            // 
            this.lblSizeX.BackColor = System.Drawing.Color.Gray;
            this.lblSizeX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSizeX.ForeColor = System.Drawing.Color.LightYellow;
            this.lblSizeX.Location = new System.Drawing.Point(19, 29);
            this.lblSizeX.Name = "lblSizeX";
            this.lblSizeX.Size = new System.Drawing.Size(126, 23);
            this.lblSizeX.TabIndex = 0;
            this.lblSizeX.Text = "Size X";
            this.lblSizeX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoNonlinear);
            this.groupBox1.Controls.Add(this.rdoLinear);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Gray;
            this.groupBox1.Location = new System.Drawing.Point(11, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 58);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Calibration Mode";
            this.groupBox1.Visible = false;
            // 
            // rdoNonlinear
            // 
            this.rdoNonlinear.AutoSize = true;
            this.rdoNonlinear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoNonlinear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rdoNonlinear.Location = new System.Drawing.Point(158, 25);
            this.rdoNonlinear.Name = "rdoNonlinear";
            this.rdoNonlinear.Size = new System.Drawing.Size(171, 20);
            this.rdoNonlinear.TabIndex = 0;
            this.rdoNonlinear.TabStop = true;
            this.rdoNonlinear.Text = "Nonlinear (with Warping)";
            this.rdoNonlinear.UseVisualStyleBackColor = true;
            this.rdoNonlinear.Click += new System.EventHandler(this.rdoNonlinear_Click);
            // 
            // rdoLinear
            // 
            this.rdoLinear.AutoSize = true;
            this.rdoLinear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoLinear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rdoLinear.Location = new System.Drawing.Point(22, 25);
            this.rdoLinear.Name = "rdoLinear";
            this.rdoLinear.Size = new System.Drawing.Size(63, 20);
            this.rdoLinear.TabIndex = 0;
            this.rdoLinear.TabStop = true;
            this.rdoLinear.Text = "Linear";
            this.rdoLinear.UseVisualStyleBackColor = true;
            this.rdoLinear.Click += new System.EventHandler(this.rdoLinear_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Gray;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.LightYellow;
            this.label3.Location = new System.Drawing.Point(230, 348);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Threshold";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpbxResult
            // 
            this.grpbxResult.Controls.Add(this.chkShowUndistort);
            this.grpbxResult.Controls.Add(this.btnCompute);
            this.grpbxResult.Controls.Add(this.lstvwResult);
            this.grpbxResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxResult.ForeColor = System.Drawing.Color.Gray;
            this.grpbxResult.Location = new System.Drawing.Point(893, 401);
            this.grpbxResult.Name = "grpbxResult";
            this.grpbxResult.Size = new System.Drawing.Size(366, 388);
            this.grpbxResult.TabIndex = 91;
            this.grpbxResult.TabStop = false;
            this.grpbxResult.Text = "Result";
            // 
            // chkShowUndistort
            // 
            this.chkShowUndistort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShowUndistort.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkShowUndistort.Location = new System.Drawing.Point(233, 329);
            this.chkShowUndistort.Name = "chkShowUndistort";
            this.chkShowUndistort.Size = new System.Drawing.Size(132, 37);
            this.chkShowUndistort.TabIndex = 99;
            this.chkShowUndistort.Text = "Show Undistorted Calibration Image";
            this.chkShowUndistort.UseVisualStyleBackColor = true;
            this.chkShowUndistort.Visible = false;
            this.chkShowUndistort.CheckedChanged += new System.EventHandler(this.chkShowUndistort_CheckedChanged);
            // 
            // btnCompute
            // 
            this.btnCompute.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompute.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCompute.Image = ((System.Drawing.Image)(resources.GetObject("btnCompute.Image")));
            this.btnCompute.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCompute.Location = new System.Drawing.Point(10, 328);
            this.btnCompute.Name = "btnCompute";
            this.btnCompute.Size = new System.Drawing.Size(211, 48);
            this.btnCompute.TabIndex = 98;
            this.btnCompute.Text = "           Compute Calibration";
            this.btnCompute.UseVisualStyleBackColor = true;
            this.btnCompute.Click += new System.EventHandler(this.btnCompute_Click);
            // 
            // lstvwResult
            // 
            this.lstvwResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colUncalibratedX,
            this.colUncalibratedY,
            this.colCalibratedX,
            this.colCalibratedY});
            this.lstvwResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvwResult.FullRowSelect = true;
            this.lstvwResult.GridLines = true;
            this.lstvwResult.HideSelection = false;
            this.lstvwResult.Location = new System.Drawing.Point(10, 17);
            this.lstvwResult.MultiSelect = false;
            this.lstvwResult.Name = "lstvwResult";
            this.lstvwResult.Size = new System.Drawing.Size(345, 290);
            this.lstvwResult.TabIndex = 17;
            this.lstvwResult.UseCompatibleStateImageBehavior = false;
            this.lstvwResult.View = System.Windows.Forms.View.Details;
            this.lstvwResult.SelectedIndexChanged += new System.EventHandler(this.lstvwResult_SelectedIndexChanged);
            // 
            // colID
            // 
            this.colID.Text = "ID";
            this.colID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colID.Width = 30;
            // 
            // colUncalibratedX
            // 
            this.colUncalibratedX.Text = "UncalibratedX";
            this.colUncalibratedX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colUncalibratedX.Width = 68;
            // 
            // grpbxSetting
            // 
            this.grpbxSetting.Controls.Add(this.grpbxOrigin);
            this.grpbxSetting.Controls.Add(this.groupBox1);
            this.grpbxSetting.Controls.Add(this.grpbxPlate);
            this.grpbxSetting.Controls.Add(this.label3);
            this.grpbxSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxSetting.ForeColor = System.Drawing.Color.Gray;
            this.grpbxSetting.Location = new System.Drawing.Point(893, 6);
            this.grpbxSetting.Name = "grpbxSetting";
            this.grpbxSetting.Size = new System.Drawing.Size(367, 389);
            this.grpbxSetting.TabIndex = 88;
            this.grpbxSetting.TabStop = false;
            this.grpbxSetting.Text = "Calibration Setting";
            // 
            // grpbxOrigin
            // 
            this.grpbxOrigin.Controls.Add(this.chkSwap);
            this.grpbxOrigin.Controls.Add(this.numUpDnY);
            this.grpbxOrigin.Controls.Add(this.numUpDnX);
            this.grpbxOrigin.Controls.Add(this.numUpDnRotation);
            this.grpbxOrigin.Controls.Add(this.label17);
            this.grpbxOrigin.Controls.Add(this.label8);
            this.grpbxOrigin.Controls.Add(this.label12);
            this.grpbxOrigin.Controls.Add(this.lblX_AxisRotation);
            this.grpbxOrigin.Controls.Add(this.lblOriginY);
            this.grpbxOrigin.Controls.Add(this.lblOriginX);
            this.grpbxOrigin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxOrigin.ForeColor = System.Drawing.Color.Gray;
            this.grpbxOrigin.Location = new System.Drawing.Point(11, 216);
            this.grpbxOrigin.Name = "grpbxOrigin";
            this.grpbxOrigin.Size = new System.Drawing.Size(345, 155);
            this.grpbxOrigin.TabIndex = 36;
            this.grpbxOrigin.TabStop = false;
            this.grpbxOrigin.Text = "Calibration Origin";
            // 
            // chkSwap
            // 
            this.chkSwap.AutoSize = true;
            this.chkSwap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSwap.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkSwap.Location = new System.Drawing.Point(22, 121);
            this.chkSwap.Name = "chkSwap";
            this.chkSwap.Size = new System.Drawing.Size(142, 20);
            this.chkSwap.TabIndex = 10;
            this.chkSwap.Text = "Swap Handedness";
            this.chkSwap.UseVisualStyleBackColor = true;
            // 
            // numUpDnY
            // 
            this.numUpDnY.DecimalPlaces = 3;
            this.numUpDnY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numUpDnY.Location = new System.Drawing.Point(162, 59);
            this.numUpDnY.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numUpDnY.Minimum = new decimal(new int[] {
            1410065408,
            2,
            0,
            -2147483648});
            this.numUpDnY.Name = "numUpDnY";
            this.numUpDnY.Size = new System.Drawing.Size(106, 22);
            this.numUpDnY.TabIndex = 9;
            this.numUpDnY.ValueChanged += new System.EventHandler(this.numUpDownY_ValueChanged);
            // 
            // numUpDnX
            // 
            this.numUpDnX.DecimalPlaces = 3;
            this.numUpDnX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numUpDnX.Location = new System.Drawing.Point(162, 29);
            this.numUpDnX.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numUpDnX.Minimum = new decimal(new int[] {
            1410065408,
            2,
            0,
            -2147483648});
            this.numUpDnX.Name = "numUpDnX";
            this.numUpDnX.Size = new System.Drawing.Size(106, 22);
            this.numUpDnX.TabIndex = 8;
            this.numUpDnX.ValueChanged += new System.EventHandler(this.numUpDownX_ValueChanged);
            // 
            // numUpDnRotation
            // 
            this.numUpDnRotation.DecimalPlaces = 3;
            this.numUpDnRotation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numUpDnRotation.Location = new System.Drawing.Point(162, 89);
            this.numUpDnRotation.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numUpDnRotation.Minimum = new decimal(new int[] {
            1410065408,
            2,
            0,
            -2147483648});
            this.numUpDnRotation.Name = "numUpDnRotation";
            this.numUpDnRotation.Size = new System.Drawing.Size(106, 22);
            this.numUpDnRotation.TabIndex = 7;
            this.numUpDnRotation.ValueChanged += new System.EventHandler(this.numUpDownRotation_ValueChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(274, 92);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 16);
            this.label17.TabIndex = 6;
            this.label17.Text = "deg";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(274, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "mm";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(274, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 16);
            this.label12.TabIndex = 5;
            this.label12.Text = "mm";
            // 
            // lblX_AxisRotation
            // 
            this.lblX_AxisRotation.BackColor = System.Drawing.Color.Gray;
            this.lblX_AxisRotation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblX_AxisRotation.ForeColor = System.Drawing.Color.LightYellow;
            this.lblX_AxisRotation.Location = new System.Drawing.Point(19, 89);
            this.lblX_AxisRotation.Name = "lblX_AxisRotation";
            this.lblX_AxisRotation.Size = new System.Drawing.Size(126, 23);
            this.lblX_AxisRotation.TabIndex = 0;
            this.lblX_AxisRotation.Text = "X Axis Rotation";
            this.lblX_AxisRotation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOriginY
            // 
            this.lblOriginY.BackColor = System.Drawing.Color.Gray;
            this.lblOriginY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOriginY.ForeColor = System.Drawing.Color.LightYellow;
            this.lblOriginY.Location = new System.Drawing.Point(19, 59);
            this.lblOriginY.Name = "lblOriginY";
            this.lblOriginY.Size = new System.Drawing.Size(126, 23);
            this.lblOriginY.TabIndex = 0;
            this.lblOriginY.Text = "Origin Y";
            this.lblOriginY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOriginX
            // 
            this.lblOriginX.BackColor = System.Drawing.Color.Gray;
            this.lblOriginX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOriginX.ForeColor = System.Drawing.Color.LightYellow;
            this.lblOriginX.Location = new System.Drawing.Point(19, 29);
            this.lblOriginX.Name = "lblOriginX";
            this.lblOriginX.Size = new System.Drawing.Size(126, 23);
            this.lblOriginX.TabIndex = 0;
            this.lblOriginX.Text = "Origin X";
            this.lblOriginX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btnLoadDirectory.TabIndex = 107;
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
            this.btnLoadBefore.TabIndex = 111;
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
            this.lblFileName.TabIndex = 110;
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
            this.btnLoadNext.TabIndex = 109;
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
            this.grpbxAcquisition.TabIndex = 108;
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
            // ATbCalibCheckerboard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1272, 964);
            this.Controls.Add(this.btnLoadBefore);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnLoadNext);
            this.Controls.Add(this.grpbxAcquisition);
            this.Controls.Add(this.btnLoadDirectory);
            this.Controls.Add(this.cogDisplayStatusBar);
            this.Controls.Add(this.btnLoadCalibImage);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnLoadInit);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnAcquireLive);
            this.Controls.Add(this.btnAcquireSingle);
            this.Controls.Add(this.btnSaveImage);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSaveVPP);
            this.Controls.Add(this.grpbxResult);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpbxSetting);
            this.Controls.Add(this.cogDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ATbCalibCheckerboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CalibCheckerboard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ATbCalibCheckerboard_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisplay)).EndInit();
            this.grpbxPlate.ResumeLayout(false);
            this.grpbxPlate.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpbxResult.ResumeLayout(false);
            this.grpbxSetting.ResumeLayout(false);
            this.grpbxOrigin.ResumeLayout(false);
            this.grpbxOrigin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDnRotation)).EndInit();
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
        private System.Windows.Forms.Button btnAcquireLive;
        private System.Windows.Forms.Button btnAcquireSingle;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSaveVPP;
        private Cognex.VisionPro.Display.CogDisplay cogDisplay;
        private System.Windows.Forms.Timer tmrTime;
        private System.Windows.Forms.ColumnHeader colCalibratedY;
        private System.Windows.Forms.ColumnHeader colCalibratedX;
        private System.Windows.Forms.ColumnHeader colUncalibratedY;
        private System.Windows.Forms.GroupBox grpbxPlate;
        private System.Windows.Forms.CheckBox chkMark;
        private System.Windows.Forms.Label lblSizeX;
        private System.Windows.Forms.TextBox txtSizeX;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpbxResult;
        private System.Windows.Forms.ListView lstvwResult;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colUncalibratedX;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox grpbxSetting;
        private System.Windows.Forms.RadioButton rdoNonlinear;
        private System.Windows.Forms.RadioButton rdoLinear;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSizeY;
        private System.Windows.Forms.Label lblSizeY;
        private System.Windows.Forms.GroupBox grpbxOrigin;
        private System.Windows.Forms.NumericUpDown numUpDnY;
        private System.Windows.Forms.NumericUpDown numUpDnX;
        private System.Windows.Forms.NumericUpDown numUpDnRotation;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblX_AxisRotation;
        private System.Windows.Forms.Label lblOriginY;
        private System.Windows.Forms.Label lblOriginX;
        private System.Windows.Forms.CheckBox chkSwap;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnCompute;
        private System.Windows.Forms.CheckBox chkShowUndistort;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stslblAtmlogo;
        private System.Windows.Forms.ToolStripStatusLabel stslblStatus;
        private System.Windows.Forms.ToolStripStatusLabel stslblTime;
        private System.Windows.Forms.Button btnLoadCalibImage;
        private Cognex.VisionPro.CogDisplayStatusBarV2 cogDisplayStatusBar;
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