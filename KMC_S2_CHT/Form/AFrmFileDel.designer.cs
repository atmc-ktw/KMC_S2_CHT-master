namespace AVisionPro
{
    partial class AFrmFileDel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AFrmFileDel));
            this.txtOk = new System.Windows.Forms.TextBox();
            this.txtNg = new System.Windows.Forms.TextBox();
            this.lblOK = new System.Windows.Forms.Label();
            this.lblNG = new System.Windows.Forms.Label();
            this.lblDelTime = new System.Windows.Forms.Label();
            this.dTDel = new System.Windows.Forms.DateTimePicker();
            this.lblLog = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblTotalOK = new System.Windows.Forms.Label();
            this.txtTotalOK = new System.Windows.Forms.TextBox();
            this.txtTotalNG = new System.Windows.Forms.TextBox();
            this.lblTotalNG = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.lblPathSetup = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtOk
            // 
            this.txtOk.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtOk.Location = new System.Drawing.Point(302, 58);
            this.txtOk.Name = "txtOk";
            this.txtOk.Size = new System.Drawing.Size(100, 26);
            this.txtOk.TabIndex = 0;
            this.txtOk.Text = "1";
            this.txtOk.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUIntKeyPress);
            // 
            // txtNg
            // 
            this.txtNg.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtNg.Location = new System.Drawing.Point(302, 90);
            this.txtNg.Name = "txtNg";
            this.txtNg.Size = new System.Drawing.Size(100, 26);
            this.txtNg.TabIndex = 1;
            this.txtNg.Text = "1";
            this.txtNg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUIntKeyPress);
            // 
            // lblOK
            // 
            this.lblOK.AutoSize = true;
            this.lblOK.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOK.Location = new System.Drawing.Point(37, 61);
            this.lblOK.Name = "lblOK";
            this.lblOK.Size = new System.Drawing.Size(143, 16);
            this.lblOK.TabIndex = 12;
            this.lblOK.Text = "OK 영상 저장(일)";
            // 
            // lblNG
            // 
            this.lblNG.AutoSize = true;
            this.lblNG.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNG.Location = new System.Drawing.Point(37, 93);
            this.lblNG.Name = "lblNG";
            this.lblNG.Size = new System.Drawing.Size(143, 16);
            this.lblNG.TabIndex = 13;
            this.lblNG.Text = "NG 영상 저장(일)";
            // 
            // lblDelTime
            // 
            this.lblDelTime.AutoSize = true;
            this.lblDelTime.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDelTime.Location = new System.Drawing.Point(37, 216);
            this.lblDelTime.Name = "lblDelTime";
            this.lblDelTime.Size = new System.Drawing.Size(122, 16);
            this.lblDelTime.TabIndex = 14;
            this.lblDelTime.Text = "삭제 실행 시간";
            // 
            // dTDel
            // 
            this.dTDel.CustomFormat = "HH:mm";
            this.dTDel.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dTDel.Location = new System.Drawing.Point(302, 216);
            this.dTDel.MinDate = new System.DateTime(2009, 1, 1, 0, 0, 0, 0);
            this.dTDel.Name = "dTDel";
            this.dTDel.ShowUpDown = true;
            this.dTDel.Size = new System.Drawing.Size(100, 21);
            this.dTDel.TabIndex = 5;
            this.dTDel.Value = new System.DateTime(2009, 6, 2, 14, 33, 0, 0);
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLog.Location = new System.Drawing.Point(37, 186);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(120, 16);
            this.lblLog.TabIndex = 18;
            this.lblLog.Text = "LOG  저장(일)";
            // 
            // txtLog
            // 
            this.txtLog.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtLog.Location = new System.Drawing.Point(302, 185);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(100, 26);
            this.txtLog.TabIndex = 4;
            this.txtLog.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUIntKeyPress);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Gray;
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitle.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.Lavender;
            this.lblTitle.Location = new System.Drawing.Point(3, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(443, 37);
            this.lblTitle.TabIndex = 78;
            this.lblTitle.Text = "파일 삭제 설정";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(288, 320);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(114, 40);
            this.btnClose.TabIndex = 7;
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
            this.btnSave.Location = new System.Drawing.Point(66, 320);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 40);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "      Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblTotalOK
            // 
            this.lblTotalOK.AutoSize = true;
            this.lblTotalOK.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTotalOK.Location = new System.Drawing.Point(37, 125);
            this.lblTotalOK.Name = "lblTotalOK";
            this.lblTotalOK.Size = new System.Drawing.Size(193, 16);
            this.lblTotalOK.TabIndex = 482;
            this.lblTotalOK.Text = "Total OK 영상 보관기간";
            // 
            // txtTotalOK
            // 
            this.txtTotalOK.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTotalOK.Location = new System.Drawing.Point(302, 121);
            this.txtTotalOK.Name = "txtTotalOK";
            this.txtTotalOK.Size = new System.Drawing.Size(100, 26);
            this.txtTotalOK.TabIndex = 2;
            this.txtTotalOK.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUIntKeyPress);
            // 
            // txtTotalNG
            // 
            this.txtTotalNG.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTotalNG.Location = new System.Drawing.Point(302, 153);
            this.txtTotalNG.Name = "txtTotalNG";
            this.txtTotalNG.Size = new System.Drawing.Size(100, 26);
            this.txtTotalNG.TabIndex = 3;
            this.txtTotalNG.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUIntKeyPress);
            // 
            // lblTotalNG
            // 
            this.lblTotalNG.AutoSize = true;
            this.lblTotalNG.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTotalNG.Location = new System.Drawing.Point(37, 157);
            this.lblTotalNG.Name = "lblTotalNG";
            this.lblTotalNG.Size = new System.Drawing.Size(193, 16);
            this.lblTotalNG.TabIndex = 484;
            this.lblTotalNG.Text = "Total NG 영상 보관기간";
            // 
            // txtPath
            // 
            this.txtPath.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPath.Location = new System.Drawing.Point(40, 273);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(362, 26);
            this.txtPath.TabIndex = 486;
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Font = new System.Drawing.Font("돋움", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSelectPath.Location = new System.Drawing.Point(249, 243);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(153, 29);
            this.btnSelectPath.TabIndex = 487;
            this.btnSelectPath.Text = "Select Path";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // lblPathSetup
            // 
            this.lblPathSetup.AutoSize = true;
            this.lblPathSetup.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPathSetup.Location = new System.Drawing.Point(37, 252);
            this.lblPathSetup.Name = "lblPathSetup";
            this.lblPathSetup.Size = new System.Drawing.Size(112, 16);
            this.lblPathSetup.TabIndex = 488;
            this.lblPathSetup.Text = "PATH SETUP";
            // 
            // AFrmFileDel
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(450, 382);
            this.Controls.Add(this.lblPathSetup);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnSelectPath);
            this.Controls.Add(this.txtTotalNG);
            this.Controls.Add(this.lblTotalNG);
            this.Controls.Add(this.txtTotalOK);
            this.Controls.Add(this.lblTotalOK);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.dTDel);
            this.Controls.Add(this.lblDelTime);
            this.Controls.Add(this.lblNG);
            this.Controls.Add(this.lblOK);
            this.Controls.Add(this.txtNg);
            this.Controls.Add(this.txtOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AFrmFileDel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FileDel";
            this.Load += new System.EventHandler(this.AFrmFileDel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOk;
        private System.Windows.Forms.TextBox txtNg;
        private System.Windows.Forms.Label lblOK;
        private System.Windows.Forms.Label lblNG;
        private System.Windows.Forms.Label lblDelTime;
        private System.Windows.Forms.DateTimePicker dTDel;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblTotalOK;
        private System.Windows.Forms.TextBox txtTotalOK;
        private System.Windows.Forms.TextBox txtTotalNG;
        private System.Windows.Forms.Label lblTotalNG;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.Label lblPathSetup;
    }
}