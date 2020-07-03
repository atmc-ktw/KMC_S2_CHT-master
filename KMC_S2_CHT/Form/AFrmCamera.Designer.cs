namespace AVisionPro
{
    partial class AFrmCamera
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTypeList = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBrightness = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtContrast = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtExposureTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnOnlineCamera = new System.Windows.Forms.Button();
            this.cmbPixelFormat = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCameraType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstvwCamera = new ATMC.Controls.AListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSelect = new System.Windows.Forms.Button();
            this.txtTimeout = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
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
            this.lblTitle.Size = new System.Drawing.Size(685, 40);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "CAMERA SETUP";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTypeList
            // 
            this.lblTypeList.BackColor = System.Drawing.Color.Gray;
            this.lblTypeList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTypeList.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeList.ForeColor = System.Drawing.Color.Gold;
            this.lblTypeList.Location = new System.Drawing.Point(15, 55);
            this.lblTypeList.Name = "lblTypeList";
            this.lblTypeList.Size = new System.Drawing.Size(324, 27);
            this.lblTypeList.TabIndex = 3;
            this.lblTypeList.Text = "Camera List";
            this.lblTypeList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAdd.Location = new System.Drawing.Point(145, 420);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 45);
            this.btnAdd.TabIndex = 72;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.Location = new System.Drawing.Point(606, 420);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 45);
            this.btnClose.TabIndex = 73;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDelete.Location = new System.Drawing.Point(245, 420);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 45);
            this.btnDelete.TabIndex = 74;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTimeout);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtBrightness);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtContrast);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtExposureTime);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnOnlineCamera);
            this.groupBox1.Controls.Add(this.cmbPixelFormat);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtIPAddress);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCameraType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtSerialNumber);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(360, 58);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 345);
            this.groupBox1.TabIndex = 75;
            this.groupBox1.TabStop = false;
            // 
            // txtBrightness
            // 
            this.txtBrightness.Enabled = false;
            this.txtBrightness.Location = new System.Drawing.Point(123, 178);
            this.txtBrightness.Name = "txtBrightness";
            this.txtBrightness.Size = new System.Drawing.Size(195, 21);
            this.txtBrightness.TabIndex = 82;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(42, 182);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 12);
            this.label8.TabIndex = 81;
            this.label8.Text = "Brightness :";
            // 
            // txtContrast
            // 
            this.txtContrast.Enabled = false;
            this.txtContrast.Location = new System.Drawing.Point(123, 151);
            this.txtContrast.Name = "txtContrast";
            this.txtContrast.Size = new System.Drawing.Size(195, 21);
            this.txtContrast.TabIndex = 80;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 12);
            this.label7.TabIndex = 79;
            this.label7.Text = "Contrast :";
            // 
            // txtExposureTime
            // 
            this.txtExposureTime.Enabled = false;
            this.txtExposureTime.Location = new System.Drawing.Point(123, 121);
            this.txtExposureTime.Name = "txtExposureTime";
            this.txtExposureTime.Size = new System.Drawing.Size(195, 21);
            this.txtExposureTime.TabIndex = 78;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 12);
            this.label6.TabIndex = 77;
            this.label6.Text = "Exposure Time :";
            // 
            // btnOnlineCamera
            // 
            this.btnOnlineCamera.Enabled = false;
            this.btnOnlineCamera.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOnlineCamera.Location = new System.Drawing.Point(289, 62);
            this.btnOnlineCamera.Name = "btnOnlineCamera";
            this.btnOnlineCamera.Size = new System.Drawing.Size(29, 21);
            this.btnOnlineCamera.TabIndex = 76;
            this.btnOnlineCamera.Text = "...";
            this.btnOnlineCamera.UseVisualStyleBackColor = true;
            this.btnOnlineCamera.Click += new System.EventHandler(this.btnOnlineCamera_Click);
            // 
            // cmbPixelFormat
            // 
            this.cmbPixelFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPixelFormat.Enabled = false;
            this.cmbPixelFormat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPixelFormat.FormattingEnabled = true;
            this.cmbPixelFormat.Items.AddRange(new object[] {
            "Mono 8",
            "YUV 422 Packed",
            "YUV 422(YUYV) Packed"});
            this.cmbPixelFormat.Location = new System.Drawing.Point(123, 91);
            this.cmbPixelFormat.Name = "cmbPixelFormat";
            this.cmbPixelFormat.Size = new System.Drawing.Size(194, 20);
            this.cmbPixelFormat.TabIndex = 75;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 12);
            this.label5.TabIndex = 74;
            this.label5.Text = "Pixel Format :";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.Location = new System.Drawing.Point(223, 300);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 31);
            this.btnSave.TabIndex = 73;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(123, 265);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.ReadOnly = true;
            this.txtIPAddress.Size = new System.Drawing.Size(194, 21);
            this.txtIPAddress.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "IP Address :";
            // 
            // txtCameraType
            // 
            this.txtCameraType.Location = new System.Drawing.Point(123, 234);
            this.txtCameraType.Name = "txtCameraType";
            this.txtCameraType.ReadOnly = true;
            this.txtCameraType.Size = new System.Drawing.Size(194, 21);
            this.txtCameraType.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Camera Type :";
            // 
            // txtSerialNumber
            // 
            this.txtSerialNumber.Enabled = false;
            this.txtSerialNumber.Location = new System.Drawing.Point(123, 63);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(164, 21);
            this.txtSerialNumber.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Serial Number :";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(123, 31);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(194, 21);
            this.txtName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Camera Name :";
            // 
            // lstvwCamera
            // 
            this.lstvwCamera.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName});
            this.lstvwCamera.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvwCamera.FullRowSelect = true;
            this.lstvwCamera.GridLines = true;
            this.lstvwCamera.Location = new System.Drawing.Point(15, 85);
            this.lstvwCamera.MultiSelect = false;
            this.lstvwCamera.Name = "lstvwCamera";
            this.lstvwCamera.Size = new System.Drawing.Size(324, 318);
            this.lstvwCamera.TabIndex = 2;
            this.lstvwCamera.Tag = "";
            this.lstvwCamera.UseCompatibleStateImageBehavior = false;
            this.lstvwCamera.View = System.Windows.Forms.View.Details;
            this.lstvwCamera.Click += new System.EventHandler(this.lstvwCamera_Click);
            // 
            // colName
            // 
            this.colName.Text = "Camera Name";
            this.colName.Width = 296;
            // 
            // btnSelect
            // 
            this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSelect.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSelect.Location = new System.Drawing.Point(497, 420);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(94, 45);
            this.btnSelect.TabIndex = 76;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // txtTimeout
            // 
            this.txtTimeout.Enabled = false;
            this.txtTimeout.Location = new System.Drawing.Point(123, 205);
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.Size = new System.Drawing.Size(195, 21);
            this.txtTimeout.TabIndex = 84;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(57, 210);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 83;
            this.label9.Text = "Timeout :";
            // 
            // AFrmCamera
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(712, 477);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstvwCamera);
            this.Controls.Add(this.lblTypeList);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AFrmCamera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Camera";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AFrmCamera_FormClosed);
            this.Load += new System.EventHandler(this.AFrmCamera_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private ATMC.Controls.AListView lstvwCamera;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.Label lblTypeList;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCameraType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPixelFormat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnOnlineCamera;
        private System.Windows.Forms.TextBox txtBrightness;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtContrast;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtExposureTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTimeout;
        private System.Windows.Forms.Label label9;
    }
}