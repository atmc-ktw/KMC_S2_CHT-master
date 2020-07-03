namespace AVisionPro
{
    partial class ATbEdtFixtureNPointToNPoint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ATbEdtFixtureNPointToNPoint));
            this.lblFileName = new System.Windows.Forms.Label();
            this.grpbxAcquisition = new System.Windows.Forms.GroupBox();
            this.chkRun = new System.Windows.Forms.CheckBox();
            this.btnLoadInit = new System.Windows.Forms.Button();
            this.btnSaveVPP = new System.Windows.Forms.Button();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.btnLoadNext = new System.Windows.Forms.Button();
            this.btnLoadBefore = new System.Windows.Forms.Button();
            this.txtBrightness = new System.Windows.Forms.TextBox();
            this.lblBrightness = new System.Windows.Forms.Label();
            this.btnAcquireLive = new System.Windows.Forms.Button();
            this.btnLoadDirectory = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.txtContrast = new System.Windows.Forms.TextBox();
            this.btnAcquireSingle = new System.Windows.Forms.Button();
            this.txtExposure = new System.Windows.Forms.TextBox();
            this.lblExposure = new System.Windows.Forms.Label();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.lblContrast = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stslblAtmLogo = new System.Windows.Forms.ToolStripStatusLabel();
            this.stslblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.stslblTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrTime = new System.Windows.Forms.Timer(this.components);
            this.tmrLive = new System.Windows.Forms.Timer(this.components);
            this.cogFixtureNPointToNPointEditV2 = new Cognex.VisionPro.CalibFix.CogFixtureNPointToNPointEditV2();
            this.grpbxAcquisition.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogFixtureNPointToNPointEditV2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(6, 17);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(14, 15);
            this.lblFileName.TabIndex = 102;
            this.lblFileName.Text = "_";
            // 
            // grpbxAcquisition
            // 
            this.grpbxAcquisition.Controls.Add(this.chkRun);
            this.grpbxAcquisition.Controls.Add(this.btnLoadInit);
            this.grpbxAcquisition.Controls.Add(this.btnSaveVPP);
            this.grpbxAcquisition.Controls.Add(this.lblFileName);
            this.grpbxAcquisition.Controls.Add(this.btnSaveImage);
            this.grpbxAcquisition.Controls.Add(this.btnLoadNext);
            this.grpbxAcquisition.Controls.Add(this.btnLoadBefore);
            this.grpbxAcquisition.Controls.Add(this.txtBrightness);
            this.grpbxAcquisition.Controls.Add(this.lblBrightness);
            this.grpbxAcquisition.Controls.Add(this.btnAcquireLive);
            this.grpbxAcquisition.Controls.Add(this.btnLoadDirectory);
            this.grpbxAcquisition.Controls.Add(this.label14);
            this.grpbxAcquisition.Controls.Add(this.txtContrast);
            this.grpbxAcquisition.Controls.Add(this.btnAcquireSingle);
            this.grpbxAcquisition.Controls.Add(this.txtExposure);
            this.grpbxAcquisition.Controls.Add(this.lblExposure);
            this.grpbxAcquisition.Controls.Add(this.btnLoadImage);
            this.grpbxAcquisition.Controls.Add(this.lblContrast);
            this.grpbxAcquisition.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpbxAcquisition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpbxAcquisition.ForeColor = System.Drawing.Color.Gray;
            this.grpbxAcquisition.Location = new System.Drawing.Point(0, 801);
            this.grpbxAcquisition.Name = "grpbxAcquisition";
            this.grpbxAcquisition.Size = new System.Drawing.Size(1270, 133);
            this.grpbxAcquisition.TabIndex = 101;
            this.grpbxAcquisition.TabStop = false;
            this.grpbxAcquisition.Text = "Acquisition";
            // 
            // chkRun
            // 
            this.chkRun.AutoSize = true;
            this.chkRun.Location = new System.Drawing.Point(654, 88);
            this.chkRun.Name = "chkRun";
            this.chkRun.Size = new System.Drawing.Size(15, 14);
            this.chkRun.TabIndex = 133;
            this.chkRun.UseVisualStyleBackColor = true;
            this.chkRun.Visible = false;
            // 
            // btnLoadInit
            // 
            this.btnLoadInit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadInit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLoadInit.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadInit.Image")));
            this.btnLoadInit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadInit.Location = new System.Drawing.Point(676, 73);
            this.btnLoadInit.Name = "btnLoadInit";
            this.btnLoadInit.Size = new System.Drawing.Size(190, 48);
            this.btnLoadInit.TabIndex = 124;
            this.btnLoadInit.Text = "        Load Init Image";
            this.btnLoadInit.UseVisualStyleBackColor = true;
            this.btnLoadInit.Visible = false;
            this.btnLoadInit.Click += new System.EventHandler(this.btnLoadInit_Click);
            // 
            // btnSaveVPP
            // 
            this.btnSaveVPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveVPP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSaveVPP.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveVPP.Image")));
            this.btnSaveVPP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveVPP.Location = new System.Drawing.Point(1068, 73);
            this.btnSaveVPP.Name = "btnSaveVPP";
            this.btnSaveVPP.Size = new System.Drawing.Size(190, 48);
            this.btnSaveVPP.TabIndex = 123;
            this.btnSaveVPP.Text = "     Save VPP";
            this.btnSaveVPP.UseVisualStyleBackColor = true;
            this.btnSaveVPP.Click += new System.EventHandler(this.btnSaveVPP_Click);
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveImage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSaveImage.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveImage.Image")));
            this.btnSaveImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveImage.Location = new System.Drawing.Point(872, 73);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(190, 48);
            this.btnSaveImage.TabIndex = 117;
            this.btnSaveImage.Text = "       Save Image File";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // btnLoadNext
            // 
            this.btnLoadNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadNext.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLoadNext.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadNext.Image")));
            this.btnLoadNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoadNext.Location = new System.Drawing.Point(547, 73);
            this.btnLoadNext.Name = "btnLoadNext";
            this.btnLoadNext.Size = new System.Drawing.Size(104, 48);
            this.btnLoadNext.TabIndex = 121;
            this.btnLoadNext.Text = "    Next";
            this.btnLoadNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadNext.UseVisualStyleBackColor = true;
            this.btnLoadNext.Click += new System.EventHandler(this.btnLoadNext_Click);
            // 
            // btnLoadBefore
            // 
            this.btnLoadBefore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadBefore.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLoadBefore.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadBefore.Image")));
            this.btnLoadBefore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadBefore.Location = new System.Drawing.Point(437, 73);
            this.btnLoadBefore.Name = "btnLoadBefore";
            this.btnLoadBefore.Size = new System.Drawing.Size(104, 48);
            this.btnLoadBefore.TabIndex = 122;
            this.btnLoadBefore.Text = "        Before";
            this.btnLoadBefore.UseVisualStyleBackColor = true;
            this.btnLoadBefore.Click += new System.EventHandler(this.btnLoadBefore_Click);
            // 
            // txtBrightness
            // 
            this.txtBrightness.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBrightness.Location = new System.Drawing.Point(494, 45);
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
            this.lblBrightness.Location = new System.Drawing.Point(397, 44);
            this.lblBrightness.Name = "lblBrightness";
            this.lblBrightness.Size = new System.Drawing.Size(85, 23);
            this.lblBrightness.TabIndex = 38;
            this.lblBrightness.Text = "Brightness";
            this.lblBrightness.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAcquireLive
            // 
            this.btnAcquireLive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcquireLive.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAcquireLive.Image = ((System.Drawing.Image)(resources.GetObject("btnAcquireLive.Image")));
            this.btnAcquireLive.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAcquireLive.Location = new System.Drawing.Point(1068, 20);
            this.btnAcquireLive.Name = "btnAcquireLive";
            this.btnAcquireLive.Size = new System.Drawing.Size(190, 48);
            this.btnAcquireLive.TabIndex = 118;
            this.btnAcquireLive.Text = "        Acquire Live Video";
            this.btnAcquireLive.UseVisualStyleBackColor = true;
            this.btnAcquireLive.Click += new System.EventHandler(this.btnAcquireLive_Click);
            // 
            // btnLoadDirectory
            // 
            this.btnLoadDirectory.AllowDrop = true;
            this.btnLoadDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadDirectory.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLoadDirectory.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadDirectory.Image")));
            this.btnLoadDirectory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadDirectory.Location = new System.Drawing.Point(224, 73);
            this.btnLoadDirectory.Name = "btnLoadDirectory";
            this.btnLoadDirectory.Size = new System.Drawing.Size(207, 48);
            this.btnLoadDirectory.TabIndex = 120;
            this.btnLoadDirectory.Text = "       Load Image Directory";
            this.btnLoadDirectory.UseVisualStyleBackColor = true;
            this.btnLoadDirectory.Click += new System.EventHandler(this.btnLoadDirectory_Click);
            this.btnLoadDirectory.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnLoadDirectory_DragDrop);
            this.btnLoadDirectory.DragOver += new System.Windows.Forms.DragEventHandler(this.btnLoadDirectory_DragOver);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(185, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 15);
            this.label14.TabIndex = 33;
            this.label14.Text = "ms";
            // 
            // txtContrast
            // 
            this.txtContrast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrast.Location = new System.Drawing.Point(313, 44);
            this.txtContrast.Name = "txtContrast";
            this.txtContrast.Size = new System.Drawing.Size(69, 22);
            this.txtContrast.TabIndex = 3;
            this.txtContrast.Text = "0.5";
            this.txtContrast.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUDoubleKeyPress);
            // 
            // btnAcquireSingle
            // 
            this.btnAcquireSingle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcquireSingle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAcquireSingle.Image = ((System.Drawing.Image)(resources.GetObject("btnAcquireSingle.Image")));
            this.btnAcquireSingle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAcquireSingle.Location = new System.Drawing.Point(872, 20);
            this.btnAcquireSingle.Name = "btnAcquireSingle";
            this.btnAcquireSingle.Size = new System.Drawing.Size(190, 48);
            this.btnAcquireSingle.TabIndex = 119;
            this.btnAcquireSingle.Text = "        Acquire Single Image";
            this.btnAcquireSingle.UseVisualStyleBackColor = true;
            this.btnAcquireSingle.Click += new System.EventHandler(this.btnAcquireSingle_Click);
            // 
            // txtExposure
            // 
            this.txtExposure.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExposure.Location = new System.Drawing.Point(110, 43);
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
            this.lblExposure.Location = new System.Drawing.Point(10, 43);
            this.lblExposure.Name = "lblExposure";
            this.lblExposure.Size = new System.Drawing.Size(85, 23);
            this.lblExposure.TabIndex = 0;
            this.lblExposure.Text = "Exposure";
            this.lblExposure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.AllowDrop = true;
            this.btnLoadImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadImage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLoadImage.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadImage.Image")));
            this.btnLoadImage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadImage.Location = new System.Drawing.Point(9, 73);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(207, 48);
            this.btnLoadImage.TabIndex = 116;
            this.btnLoadImage.Text = "       Load Image File";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            this.btnLoadImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.btnLoadImage_DragDrop);
            this.btnLoadImage.DragOver += new System.Windows.Forms.DragEventHandler(this.btnLoadImage_DragOver);
            // 
            // lblContrast
            // 
            this.lblContrast.BackColor = System.Drawing.Color.Gray;
            this.lblContrast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrast.ForeColor = System.Drawing.Color.LightYellow;
            this.lblContrast.Location = new System.Drawing.Point(222, 43);
            this.lblContrast.Name = "lblContrast";
            this.lblContrast.Size = new System.Drawing.Size(85, 23);
            this.lblContrast.TabIndex = 0;
            this.lblContrast.Text = "Contrast";
            this.lblContrast.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stslblAtmLogo,
            this.stslblStatus,
            this.stslblTime,
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 934);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1270, 30);
            this.statusStrip1.TabIndex = 102;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.DoubleClick += new System.EventHandler(this.statusStrip1_DoubleClick);
            // 
            // stslblAtmLogo
            // 
            this.stslblAtmLogo.AutoSize = false;
            this.stslblAtmLogo.Image = ((System.Drawing.Image)(resources.GetObject("stslblAtmLogo.Image")));
            this.stslblAtmLogo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.stslblAtmLogo.Name = "stslblAtmLogo";
            this.stslblAtmLogo.Size = new System.Drawing.Size(255, 25);
            // 
            // stslblStatus
            // 
            this.stslblStatus.AutoSize = false;
            this.stslblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stslblStatus.Name = "stslblStatus";
            this.stslblStatus.Size = new System.Drawing.Size(850, 25);
            // 
            // stslblTime
            // 
            this.stslblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stslblTime.Name = "stslblTime";
            this.stslblTime.Size = new System.Drawing.Size(122, 25);
            this.stslblTime.Text = "2010-01-01 12:00:00";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(121, 15);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // tmrTime
            // 
            this.tmrTime.Enabled = true;
            this.tmrTime.Interval = 1000;
            this.tmrTime.Tick += new System.EventHandler(this.tmrTime_Tick);
            // 
            // tmrLive
            // 
            this.tmrLive.Interval = 300;
            this.tmrLive.Tick += new System.EventHandler(this.tmrLive_Tick);
            // 
            // cogFixtureNPointToNPointEditV2
            // 
            this.cogFixtureNPointToNPointEditV2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogFixtureNPointToNPointEditV2.Location = new System.Drawing.Point(0, 0);
            this.cogFixtureNPointToNPointEditV2.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogFixtureNPointToNPointEditV2.Name = "cogFixtureNPointToNPointEditV2";
            this.cogFixtureNPointToNPointEditV2.Size = new System.Drawing.Size(1270, 801);
            this.cogFixtureNPointToNPointEditV2.SuspendElectricRuns = false;
            this.cogFixtureNPointToNPointEditV2.TabIndex = 103;
            // 
            // ATbEdtFixtureNPointToNPoint
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1270, 964);
            this.Controls.Add(this.cogFixtureNPointToNPointEditV2);
            this.Controls.Add(this.grpbxAcquisition);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ATbEdtFixtureNPointToNPoint";
            this.Text = "ATbEdtFixtureNPointToNPoint";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ATbEdtFixtureNPointToNPoint_FormClosed);
            this.grpbxAcquisition.ResumeLayout(false);
            this.grpbxAcquisition.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogFixtureNPointToNPointEditV2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.GroupBox grpbxAcquisition;
        private System.Windows.Forms.TextBox txtBrightness;
        private System.Windows.Forms.Label lblBrightness;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtContrast;
        private System.Windows.Forms.TextBox txtExposure;
        private System.Windows.Forms.Label lblExposure;
        private System.Windows.Forms.Label lblContrast;
        private System.Windows.Forms.Button btnLoadBefore;
        private System.Windows.Forms.Button btnLoadNext;
        private System.Windows.Forms.Button btnLoadDirectory;
        private System.Windows.Forms.Button btnAcquireLive;
        private System.Windows.Forms.Button btnAcquireSingle;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stslblAtmLogo;
        private System.Windows.Forms.ToolStripStatusLabel stslblStatus;
        private System.Windows.Forms.ToolStripStatusLabel stslblTime;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Timer tmrTime;
        private System.Windows.Forms.Timer tmrLive;
        private System.Windows.Forms.Button btnSaveVPP;
        private System.Windows.Forms.Button btnLoadInit;
        private System.Windows.Forms.CheckBox chkRun;
        private Cognex.VisionPro.CalibFix.CogFixtureNPointToNPointEditV2 cogFixtureNPointToNPointEditV2;
    }
}