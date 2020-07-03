namespace AVisionPro
{
    partial class AFrmLight
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AFrmLight));
            this.txtExposure0 = new System.Windows.Forms.TextBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblExposure = new System.Windows.Forms.Label();
            this.lblLed = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.txtExposure1 = new System.Windows.Forms.TextBox();
            this.txtExposure2 = new System.Windows.Forms.TextBox();
            this.txtLed0 = new System.Windows.Forms.TextBox();
            this.txtLed1 = new System.Windows.Forms.TextBox();
            this.txtLed2 = new System.Windows.Forms.TextBox();
            this.btn0 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.lblChannel = new System.Windows.Forms.Label();
            this.lblIndex = new System.Windows.Forms.Label();
            this.txtChannel = new System.Windows.Forms.TextBox();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.lblPoint = new System.Windows.Forms.Label();
            this.cmbPoint = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtExposure0
            // 
            this.txtExposure0.Location = new System.Drawing.Point(84, 164);
            this.txtExposure0.Name = "txtExposure0";
            this.txtExposure0.Size = new System.Drawing.Size(83, 21);
            this.txtExposure0.TabIndex = 4;
            this.txtExposure0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUDoubleKeyPress);
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(104, 12);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(160, 24);
            this.cmbType.TabIndex = 0;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // lblExposure
            // 
            this.lblExposure.BackColor = System.Drawing.Color.Gray;
            this.lblExposure.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblExposure.ForeColor = System.Drawing.Color.Gold;
            this.lblExposure.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblExposure.Location = new System.Drawing.Point(84, 143);
            this.lblExposure.Name = "lblExposure";
            this.lblExposure.Size = new System.Drawing.Size(83, 20);
            this.lblExposure.TabIndex = 413;
            this.lblExposure.Text = "Exposure";
            this.lblExposure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLed
            // 
            this.lblLed.BackColor = System.Drawing.Color.Gray;
            this.lblLed.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLed.ForeColor = System.Drawing.Color.Gold;
            this.lblLed.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblLed.Location = new System.Drawing.Point(172, 143);
            this.lblLed.Name = "lblLed";
            this.lblLed.Size = new System.Drawing.Size(92, 20);
            this.lblLed.TabIndex = 414;
            this.lblLed.Text = "LED brightness";
            this.lblLed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLed.Visible = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Navy;
            this.label4.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Gold;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(12, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(252, 20);
            this.label4.TabIndex = 415;
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Gray;
            this.label7.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Gold;
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(12, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 20);
            this.label7.TabIndex = 416;
            this.label7.Text = "S/W";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblType
            // 
            this.lblType.BackColor = System.Drawing.Color.Gray;
            this.lblType.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblType.ForeColor = System.Drawing.Color.Gold;
            this.lblType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblType.Location = new System.Drawing.Point(14, 12);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(84, 24);
            this.lblType.TabIndex = 417;
            this.lblType.Text = "기종(Type)";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtExposure1
            // 
            this.txtExposure1.Location = new System.Drawing.Point(84, 186);
            this.txtExposure1.Name = "txtExposure1";
            this.txtExposure1.Size = new System.Drawing.Size(83, 21);
            this.txtExposure1.TabIndex = 6;
            this.txtExposure1.Visible = false;
            this.txtExposure1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUDoubleKeyPress);
            // 
            // txtExposure2
            // 
            this.txtExposure2.Location = new System.Drawing.Point(84, 208);
            this.txtExposure2.Name = "txtExposure2";
            this.txtExposure2.Size = new System.Drawing.Size(83, 21);
            this.txtExposure2.TabIndex = 8;
            this.txtExposure2.Visible = false;
            this.txtExposure2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUDoubleKeyPress);
            // 
            // txtLed0
            // 
            this.txtLed0.Location = new System.Drawing.Point(172, 164);
            this.txtLed0.Name = "txtLed0";
            this.txtLed0.Size = new System.Drawing.Size(92, 21);
            this.txtLed0.TabIndex = 5;
            this.txtLed0.Visible = false;
            this.txtLed0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUIntKeyPress);
            // 
            // txtLed1
            // 
            this.txtLed1.Location = new System.Drawing.Point(172, 186);
            this.txtLed1.Name = "txtLed1";
            this.txtLed1.Size = new System.Drawing.Size(92, 21);
            this.txtLed1.TabIndex = 7;
            this.txtLed1.Visible = false;
            this.txtLed1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUIntKeyPress);
            // 
            // txtLed2
            // 
            this.txtLed2.Location = new System.Drawing.Point(172, 208);
            this.txtLed2.Name = "txtLed2";
            this.txtLed2.Size = new System.Drawing.Size(92, 21);
            this.txtLed2.TabIndex = 9;
            this.txtLed2.Visible = false;
            this.txtLed2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUIntKeyPress);
            // 
            // btn0
            // 
            this.btn0.BackColor = System.Drawing.Color.Gray;
            this.btn0.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn0.ForeColor = System.Drawing.Color.Gold;
            this.btn0.Location = new System.Drawing.Point(12, 164);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(72, 22);
            this.btn0.TabIndex = 449;
            this.btn0.Text = "1";
            this.btn0.UseVisualStyleBackColor = false;
            this.btn0.Click += new System.EventHandler(this.btn0_Click);
            // 
            // btn1
            // 
            this.btn1.BackColor = System.Drawing.Color.Gray;
            this.btn1.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn1.ForeColor = System.Drawing.Color.Gold;
            this.btn1.Location = new System.Drawing.Point(12, 184);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(72, 24);
            this.btn1.TabIndex = 450;
            this.btn1.Text = "2";
            this.btn1.UseVisualStyleBackColor = false;
            this.btn1.Visible = false;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn3
            // 
            this.btn3.BackColor = System.Drawing.Color.Gray;
            this.btn3.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn3.ForeColor = System.Drawing.Color.Gold;
            this.btn3.Location = new System.Drawing.Point(12, 206);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(72, 24);
            this.btn3.TabIndex = 451;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = false;
            this.btn3.Visible = false;
            this.btn3.Click += new System.EventHandler(this.btn3_Click);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Gray;
            this.label17.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold);
            this.label17.ForeColor = System.Drawing.Color.Gold;
            this.label17.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label17.Location = new System.Drawing.Point(12, 100);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(71, 40);
            this.label17.TabIndex = 468;
            this.label17.Text = "H/W";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblChannel
            // 
            this.lblChannel.BackColor = System.Drawing.Color.Gray;
            this.lblChannel.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblChannel.ForeColor = System.Drawing.Color.Gold;
            this.lblChannel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblChannel.Location = new System.Drawing.Point(172, 100);
            this.lblChannel.Name = "lblChannel";
            this.lblChannel.Size = new System.Drawing.Size(92, 20);
            this.lblChannel.TabIndex = 467;
            this.lblChannel.Text = "Channel";
            this.lblChannel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIndex
            // 
            this.lblIndex.BackColor = System.Drawing.Color.Gray;
            this.lblIndex.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIndex.ForeColor = System.Drawing.Color.Gold;
            this.lblIndex.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblIndex.Location = new System.Drawing.Point(84, 100);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(83, 20);
            this.lblIndex.TabIndex = 466;
            this.lblIndex.Text = "Index";
            this.lblIndex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChannel
            // 
            this.txtChannel.Location = new System.Drawing.Point(172, 119);
            this.txtChannel.Name = "txtChannel";
            this.txtChannel.Size = new System.Drawing.Size(92, 21);
            this.txtChannel.TabIndex = 3;
            this.txtChannel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUIntKeyPress);
            // 
            // txtIndex
            // 
            this.txtIndex.Location = new System.Drawing.Point(84, 119);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(83, 21);
            this.txtIndex.TabIndex = 2;
            this.txtIndex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIntKeyPress);
            // 
            // lblPoint
            // 
            this.lblPoint.BackColor = System.Drawing.Color.Gray;
            this.lblPoint.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPoint.ForeColor = System.Drawing.Color.Gold;
            this.lblPoint.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblPoint.Location = new System.Drawing.Point(14, 43);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(84, 24);
            this.lblPoint.TabIndex = 475;
            this.lblPoint.Text = "지점(Point)";
            this.lblPoint.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbPoint
            // 
            this.cmbPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPoint.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbPoint.FormattingEnabled = true;
            this.cmbPoint.Location = new System.Drawing.Point(104, 43);
            this.cmbPoint.Name = "cmbPoint";
            this.cmbPoint.Size = new System.Drawing.Size(160, 24);
            this.cmbPoint.TabIndex = 1;
            this.cmbPoint.SelectedIndexChanged += new System.EventHandler(this.cmbPoint_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(150, 236);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 40);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "       Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(12, 236);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 40);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "      Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AFrmLight
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(279, 288);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblPoint);
            this.Controls.Add(this.cmbPoint);
            this.Controls.Add(this.txtChannel);
            this.Controls.Add(this.txtIndex);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lblChannel);
            this.Controls.Add(this.lblIndex);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.txtLed2);
            this.Controls.Add(this.txtLed1);
            this.Controls.Add(this.txtLed0);
            this.Controls.Add(this.txtExposure2);
            this.Controls.Add(this.txtExposure1);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblLed);
            this.Controls.Add(this.lblExposure);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.txtExposure0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AFrmLight";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Light";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtExposure0;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblExposure;
        private System.Windows.Forms.Label lblLed;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TextBox txtExposure1;
        private System.Windows.Forms.TextBox txtExposure2;
        private System.Windows.Forms.TextBox txtLed0;
        private System.Windows.Forms.TextBox txtLed1;
        private System.Windows.Forms.TextBox txtLed2;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblChannel;
        private System.Windows.Forms.Label lblIndex;
        private System.Windows.Forms.TextBox txtChannel;
        private System.Windows.Forms.TextBox txtIndex;
        private System.Windows.Forms.Label lblPoint;
        private System.Windows.Forms.ComboBox cmbPoint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
    }
}