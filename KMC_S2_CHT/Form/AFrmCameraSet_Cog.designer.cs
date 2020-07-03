namespace AVisionPro
{
    partial class AFrmCameraSet_Cog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AFrmCameraSet_Cog));
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnModify = new System.Windows.Forms.Button();
            this.lblPointList = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this._lblBody = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.grbPoint = new System.Windows.Forms.GroupBox();
            this.cmbPixelFormat = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.lblIP = new System.Windows.Forms.Label();
            this.txtPoint = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lstvwPoint = new ATMC.Controls.AListView();
            this.colPoint = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSerial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPixelFormat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCamera = new System.Windows.Forms.Button();
            this.btnSelectCamera = new System.Windows.Forms.Button();
            this.grbPoint.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.lblTitle.BackColor = System.Drawing.Color.Gray;
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Lavender;
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(658, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CAMERA SETUP";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnModify
            // 
            this.btnModify.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnModify.Location = new System.Drawing.Point(552, 48);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(88, 21);
            this.btnModify.TabIndex = 11;
            this.btnModify.Text = "Modify";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // lblPointList
            // 
            this.lblPointList.BackColor = System.Drawing.Color.Gray;
            this.lblPointList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPointList.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointList.ForeColor = System.Drawing.Color.Gold;
            this.lblPointList.Location = new System.Drawing.Point(15, 100);
            this.lblPointList.Name = "lblPointList";
            this.lblPointList.Size = new System.Drawing.Size(658, 24);
            this.lblPointList.TabIndex = 60;
            this.lblPointList.Text = "Point List";
            this.lblPointList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnClose.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(568, 522);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 41);
            this.btnClose.TabIndex = 70;
            this.btnClose.Text = "       Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // _lblBody
            // 
            this._lblBody.BackColor = System.Drawing.Color.Gray;
            this._lblBody.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this._lblBody.ForeColor = System.Drawing.Color.Gold;
            this._lblBody.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this._lblBody.Location = new System.Drawing.Point(16, 68);
            this._lblBody.Name = "_lblBody";
            this._lblBody.Size = new System.Drawing.Size(84, 24);
            this._lblBody.TabIndex = 423;
            this._lblBody.Text = "차종(Body)";
            this._lblBody.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(106, 68);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(164, 24);
            this.cmbType.TabIndex = 422;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // grbPoint
            // 
            this.grbPoint.Controls.Add(this.btnSelectCamera);
            this.grbPoint.Controls.Add(this.cmbPixelFormat);
            this.grbPoint.Controls.Add(this.label1);
            this.grbPoint.Controls.Add(this.txtIP);
            this.grbPoint.Controls.Add(this.lblIP);
            this.grbPoint.Controls.Add(this.txtPoint);
            this.grbPoint.Controls.Add(this.label4);
            this.grbPoint.Controls.Add(this.label3);
            this.grbPoint.Controls.Add(this.txtName);
            this.grbPoint.Controls.Add(this.label2);
            this.grbPoint.Controls.Add(this.txtSerialNumber);
            this.grbPoint.Controls.Add(this.btnModify);
            this.grbPoint.Location = new System.Drawing.Point(15, 426);
            this.grbPoint.Name = "grbPoint";
            this.grbPoint.Size = new System.Drawing.Size(658, 79);
            this.grbPoint.TabIndex = 424;
            this.grbPoint.TabStop = false;
            this.grbPoint.Enter += new System.EventHandler(this.grbPoint_Enter);
            // 
            // cmbPixelFormat
            // 
            this.cmbPixelFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPixelFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPixelFormat.FormattingEnabled = true;
            this.cmbPixelFormat.Items.AddRange(new object[] {
            "Mono 8",
            "YUV 422 Packed",
            "YUV 422(YUYV) Packed"});
            this.cmbPixelFormat.Location = new System.Drawing.Point(384, 48);
            this.cmbPixelFormat.Name = "cmbPixelFormat";
            this.cmbPixelFormat.Size = new System.Drawing.Size(147, 20);
            this.cmbPixelFormat.TabIndex = 428;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(288, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 434;
            this.label1.Text = "Pixel Format :";
            // 
            // txtIP
            // 
            this.txtIP.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtIP.Location = new System.Drawing.Point(360, 17);
            this.txtIP.Name = "txtIP";
            this.txtIP.ReadOnly = true;
            this.txtIP.Size = new System.Drawing.Size(111, 22);
            this.txtIP.TabIndex = 432;
            this.txtIP.Text = "255.255.255.255";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblIP.Location = new System.Drawing.Point(330, 20);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(27, 13);
            this.lblIP.TabIndex = 431;
            this.lblIP.Text = "IP :";
            // 
            // txtPoint
            // 
            this.txtPoint.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPoint.Location = new System.Drawing.Point(69, 17);
            this.txtPoint.Name = "txtPoint";
            this.txtPoint.ReadOnly = true;
            this.txtPoint.Size = new System.Drawing.Size(40, 22);
            this.txtPoint.TabIndex = 430;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(22, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 429;
            this.label4.Text = "Point :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(134, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 428;
            this.label3.Text = "Name :";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtName.Location = new System.Drawing.Point(190, 17);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(119, 22);
            this.txtName.TabIndex = 427;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(22, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 426;
            this.label2.Text = "Serial Number :";
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSerialNumber.Location = new System.Drawing.Point(131, 48);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(100, 22);
            this.txtSerialNumber.TabIndex = 425;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Index";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 118;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Serial Number";
            this.columnHeader6.Width = 200;
            // 
            // btnCopy
            // 
            this.btnCopy.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCopy.Location = new System.Drawing.Point(301, 68);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(70, 24);
            this.btnCopy.TabIndex = 425;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.Font = new System.Drawing.Font("돋움", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPaste.Location = new System.Drawing.Point(377, 68);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(70, 24);
            this.btnPaste.TabIndex = 426;
            this.btnPaste.Text = "Paste";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(452, 523);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(105, 41);
            this.btnSave.TabIndex = 427;
            this.btnSave.Text = "    Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lstvwPoint
            // 
            this.lstvwPoint.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPoint,
            this.colName,
            this.colSerial,
            this.colPixelFormat});
            this.lstvwPoint.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvwPoint.FullRowSelect = true;
            this.lstvwPoint.GridLines = true;
            this.lstvwPoint.HideSelection = false;
            this.lstvwPoint.LabelWrap = false;
            this.lstvwPoint.Location = new System.Drawing.Point(15, 127);
            this.lstvwPoint.MultiSelect = false;
            this.lstvwPoint.Name = "lstvwPoint";
            this.lstvwPoint.Size = new System.Drawing.Size(658, 293);
            this.lstvwPoint.TabIndex = 1;
            this.lstvwPoint.Tag = "";
            this.lstvwPoint.UseCompatibleStateImageBehavior = false;
            this.lstvwPoint.View = System.Windows.Forms.View.Details;
            this.lstvwPoint.Click += new System.EventHandler(this.lstvwPoint_Click);
            // 
            // colPoint
            // 
            this.colPoint.Text = "Point";
            this.colPoint.Width = 57;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 164;
            // 
            // colSerial
            // 
            this.colSerial.Text = "S/N";
            this.colSerial.Width = 135;
            // 
            // colPixelFormat
            // 
            this.colPixelFormat.Text = "PixelFormat";
            this.colPixelFormat.Width = 264;
            // 
            // btnCamera
            // 
            this.btnCamera.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCamera.Location = new System.Drawing.Point(266, 524);
            this.btnCamera.Name = "btnCamera";
            this.btnCamera.Size = new System.Drawing.Size(90, 41);
            this.btnCamera.TabIndex = 428;
            this.btnCamera.Text = "Camera";
            this.btnCamera.UseVisualStyleBackColor = true;
            this.btnCamera.Click += new System.EventHandler(this.btnCamera_Click);
            // 
            // btnSelectCamera
            // 
            this.btnSelectCamera.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSelectCamera.Location = new System.Drawing.Point(233, 48);
            this.btnSelectCamera.Name = "btnSelectCamera";
            this.btnSelectCamera.Size = new System.Drawing.Size(30, 22);
            this.btnSelectCamera.TabIndex = 429;
            this.btnSelectCamera.Text = "...";
            this.btnSelectCamera.UseVisualStyleBackColor = true;
            this.btnSelectCamera.Click += new System.EventHandler(this.btnSelectCamera_Click);
            // 
            // AFrmCameraSet_Basler
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(686, 575);
            this.Controls.Add(this.btnCamera);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnPaste);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.lstvwPoint);
            this.Controls.Add(this.grbPoint);
            this.Controls.Add(this._lblBody);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblPointList);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AFrmCameraSet_Basler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CameraSet";
            this.grbPoint.ResumeLayout(false);
            this.grbPoint.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnModify;
        // 2014.11.29
        // 2014.11.29
        //private ATMC.Controls.AListView lstvwPoint;

        private System.Windows.Forms.ColumnHeader colPoint;
        private System.Windows.Forms.ColumnHeader colSerial;
        private System.Windows.Forms.Label lblPointList;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label _lblBody;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.GroupBox grbPoint;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader colName;
        private ATMC.Controls.AListView lstvwPoint;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtPoint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader colPixelFormat;
        private System.Windows.Forms.ComboBox cmbPixelFormat;
        private System.Windows.Forms.Button btnCamera;
        private System.Windows.Forms.Button btnSelectCamera;
    }
}