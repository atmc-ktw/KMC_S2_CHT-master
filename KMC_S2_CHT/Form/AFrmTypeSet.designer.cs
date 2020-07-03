namespace AVisionPro
{
    partial class AFrmTypeSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AFrmTypeSet));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblTypeList = new System.Windows.Forms.Label();
            this.lblTypeName = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnSaveVpp = new System.Windows.Forms.Button();
            this.btnPlcToPcSave = new System.Windows.Forms.Button();
            this.lblPlcToPc = new System.Windows.Forms.Label();
            this.txtTypeName = new System.Windows.Forms.TextBox();
            this.txtPlcToPc = new System.Windows.Forms.TextBox();
            this.btnViewVpp = new System.Windows.Forms.Button();
            this.lblPointList = new System.Windows.Forms.Label();
            this.lblPointCount = new System.Windows.Forms.Label();
            this.txtPointName = new System.Windows.Forms.TextBox();
            this.lblPointName = new System.Windows.Forms.Label();
            this.btnModifyPointName = new System.Windows.Forms.Button();
            this.btnModifyTypeName = new System.Windows.Forms.Button();
            this.nmUpDnPointCount = new System.Windows.Forms.NumericUpDown();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLoadVpp = new System.Windows.Forms.Button();
            this.btnCameraSet = new System.Windows.Forms.Button();
            this.lstvwPoint = new ATMC.Controls.AListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstvwType = new ATMC.Controls.AListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDnPointCount)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(929, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "TYPE SETUP";
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
            this.lblTypeList.Size = new System.Drawing.Size(417, 27);
            this.lblTypeList.TabIndex = 1;
            this.lblTypeList.Text = "Type List";
            this.lblTypeList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTypeName
            // 
            this.lblTypeName.BackColor = System.Drawing.Color.Gray;
            this.lblTypeName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTypeName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeName.ForeColor = System.Drawing.Color.Gold;
            this.lblTypeName.Location = new System.Drawing.Point(15, 524);
            this.lblTypeName.Name = "lblTypeName";
            this.lblTypeName.Size = new System.Drawing.Size(188, 27);
            this.lblTypeName.TabIndex = 2;
            this.lblTypeName.Text = "Type Name";
            this.lblTypeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("돋움", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAdd.Location = new System.Drawing.Point(756, 85);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(188, 45);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "ADD";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("돋움", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDel.Location = new System.Drawing.Point(756, 136);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(188, 45);
            this.btnDel.TabIndex = 11;
            this.btnDel.Text = "DEL";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSaveVpp
            // 
            this.btnSaveVpp.Font = new System.Drawing.Font("돋움", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSaveVpp.Location = new System.Drawing.Point(756, 417);
            this.btnSaveVpp.Name = "btnSaveVpp";
            this.btnSaveVpp.Size = new System.Drawing.Size(188, 45);
            this.btnSaveVpp.TabIndex = 15;
            this.btnSaveVpp.Text = "Save VPP";
            this.btnSaveVpp.UseVisualStyleBackColor = true;
            this.btnSaveVpp.Click += new System.EventHandler(this.btnSaveVpp_Click);
            // 
            // btnPlcToPcSave
            // 
            this.btnPlcToPcSave.Font = new System.Drawing.Font("돋움", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPlcToPcSave.Location = new System.Drawing.Point(756, 194);
            this.btnPlcToPcSave.Name = "btnPlcToPcSave";
            this.btnPlcToPcSave.Size = new System.Drawing.Size(188, 46);
            this.btnPlcToPcSave.TabIndex = 12;
            this.btnPlcToPcSave.Text = "PLC ->> PC SAVE";
            this.btnPlcToPcSave.UseVisualStyleBackColor = true;
            this.btnPlcToPcSave.Click += new System.EventHandler(this.btnPlcToPcSave_Click);
            // 
            // lblPlcToPc
            // 
            this.lblPlcToPc.BackColor = System.Drawing.Color.Gray;
            this.lblPlcToPc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPlcToPc.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlcToPc.ForeColor = System.Drawing.Color.Gold;
            this.lblPlcToPc.Location = new System.Drawing.Point(210, 524);
            this.lblPlcToPc.Name = "lblPlcToPc";
            this.lblPlcToPc.Size = new System.Drawing.Size(96, 27);
            this.lblPlcToPc.TabIndex = 31;
            this.lblPlcToPc.Text = "PLC to PC";
            this.lblPlcToPc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTypeName
            // 
            this.txtTypeName.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTypeName.Location = new System.Drawing.Point(15, 554);
            this.txtTypeName.Name = "txtTypeName";
            this.txtTypeName.Size = new System.Drawing.Size(188, 39);
            this.txtTypeName.TabIndex = 0;
            // 
            // txtPlcToPc
            // 
            this.txtPlcToPc.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPlcToPc.Location = new System.Drawing.Point(210, 554);
            this.txtPlcToPc.Name = "txtPlcToPc";
            this.txtPlcToPc.Size = new System.Drawing.Size(96, 39);
            this.txtPlcToPc.TabIndex = 1;
            // 
            // btnViewVpp
            // 
            this.btnViewVpp.Font = new System.Drawing.Font("돋움", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnViewVpp.Location = new System.Drawing.Point(756, 467);
            this.btnViewVpp.Name = "btnViewVpp";
            this.btnViewVpp.Size = new System.Drawing.Size(188, 45);
            this.btnViewVpp.TabIndex = 16;
            this.btnViewVpp.Text = "VIEW VPP ";
            this.btnViewVpp.UseVisualStyleBackColor = true;
            this.btnViewVpp.Click += new System.EventHandler(this.btnViewVpp_Click);
            // 
            // lblPointList
            // 
            this.lblPointList.BackColor = System.Drawing.Color.Gray;
            this.lblPointList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPointList.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointList.ForeColor = System.Drawing.Color.Gold;
            this.lblPointList.Location = new System.Drawing.Point(438, 55);
            this.lblPointList.Name = "lblPointList";
            this.lblPointList.Size = new System.Drawing.Size(306, 27);
            this.lblPointList.TabIndex = 60;
            this.lblPointList.Text = "Point List";
            this.lblPointList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPointCount
            // 
            this.lblPointCount.BackColor = System.Drawing.Color.Gray;
            this.lblPointCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPointCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointCount.ForeColor = System.Drawing.Color.Gold;
            this.lblPointCount.Location = new System.Drawing.Point(312, 524);
            this.lblPointCount.Name = "lblPointCount";
            this.lblPointCount.Size = new System.Drawing.Size(120, 27);
            this.lblPointCount.TabIndex = 61;
            this.lblPointCount.Text = "Point Count";
            this.lblPointCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPointName
            // 
            this.txtPointName.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPointName.Location = new System.Drawing.Point(501, 554);
            this.txtPointName.Name = "txtPointName";
            this.txtPointName.Size = new System.Drawing.Size(243, 39);
            this.txtPointName.TabIndex = 5;
            // 
            // lblPointName
            // 
            this.lblPointName.BackColor = System.Drawing.Color.Gray;
            this.lblPointName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPointName.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPointName.ForeColor = System.Drawing.Color.Gold;
            this.lblPointName.Location = new System.Drawing.Point(501, 524);
            this.lblPointName.Name = "lblPointName";
            this.lblPointName.Size = new System.Drawing.Size(243, 27);
            this.lblPointName.TabIndex = 63;
            this.lblPointName.Text = "Point Name";
            this.lblPointName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnModifyPointName
            // 
            this.btnModifyPointName.Font = new System.Drawing.Font("돋움", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnModifyPointName.Location = new System.Drawing.Point(756, 300);
            this.btnModifyPointName.Name = "btnModifyPointName";
            this.btnModifyPointName.Size = new System.Drawing.Size(188, 45);
            this.btnModifyPointName.TabIndex = 14;
            this.btnModifyPointName.Text = "Modify Point Name";
            this.btnModifyPointName.UseVisualStyleBackColor = true;
            this.btnModifyPointName.Click += new System.EventHandler(this.btnModifyPointName_Click);
            // 
            // btnModifyTypeName
            // 
            this.btnModifyTypeName.Font = new System.Drawing.Font("돋움", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnModifyTypeName.Location = new System.Drawing.Point(756, 247);
            this.btnModifyTypeName.Name = "btnModifyTypeName";
            this.btnModifyTypeName.Size = new System.Drawing.Size(188, 45);
            this.btnModifyTypeName.TabIndex = 13;
            this.btnModifyTypeName.Text = "Modify Type Name";
            this.btnModifyTypeName.UseVisualStyleBackColor = true;
            this.btnModifyTypeName.Click += new System.EventHandler(this.btnModifyTypeName_Click);
            // 
            // nmUpDnPointCount
            // 
            this.nmUpDnPointCount.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nmUpDnPointCount.Location = new System.Drawing.Point(312, 554);
            this.nmUpDnPointCount.Name = "nmUpDnPointCount";
            this.nmUpDnPointCount.Size = new System.Drawing.Size(120, 39);
            this.nmUpDnPointCount.TabIndex = 4;
            this.nmUpDnPointCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("돋움", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(756, 575);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(188, 45);
            this.btnClose.TabIndex = 70;
            this.btnClose.Text = "       Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLoadVpp
            // 
            this.btnLoadVpp.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLoadVpp.Location = new System.Drawing.Point(756, 524);
            this.btnLoadVpp.Name = "btnLoadVpp";
            this.btnLoadVpp.Size = new System.Drawing.Size(188, 45);
            this.btnLoadVpp.TabIndex = 71;
            this.btnLoadVpp.Text = "\".vpp\" File Load View";
            this.btnLoadVpp.UseVisualStyleBackColor = true;
            this.btnLoadVpp.Click += new System.EventHandler(this.btnLoadVpp_Click);
            // 
            // btnCameraSet
            // 
            this.btnCameraSet.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCameraSet.Location = new System.Drawing.Point(756, 353);
            this.btnCameraSet.Name = "btnCameraSet";
            this.btnCameraSet.Size = new System.Drawing.Size(188, 45);
            this.btnCameraSet.TabIndex = 72;
            this.btnCameraSet.Text = "GigE Camera Setup";
            this.btnCameraSet.UseVisualStyleBackColor = true;
            this.btnCameraSet.Click += new System.EventHandler(this.btnCameraSet_Click);
            // 
            // lstvwPoint
            // 
            this.lstvwPoint.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.lstvwPoint.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvwPoint.FullRowSelect = true;
            this.lstvwPoint.GridLines = true;
            this.lstvwPoint.HideSelection = false;
            this.lstvwPoint.LabelWrap = false;
            this.lstvwPoint.Location = new System.Drawing.Point(438, 85);
            this.lstvwPoint.MultiSelect = false;
            this.lstvwPoint.Name = "lstvwPoint";
            this.lstvwPoint.Size = new System.Drawing.Size(306, 426);
            this.lstvwPoint.TabIndex = 1;
            this.lstvwPoint.Tag = "";
            this.lstvwPoint.UseCompatibleStateImageBehavior = false;
            this.lstvwPoint.View = System.Windows.Forms.View.Details;
            this.lstvwPoint.Click += new System.EventHandler(this.lstvwPoint_Click);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Index";
            this.columnHeader4.Width = 70;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Point Name";
            this.columnHeader5.Width = 240;
            // 
            // lstvwType
            // 
            this.lstvwType.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lstvwType.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvwType.FullRowSelect = true;
            this.lstvwType.GridLines = true;
            this.lstvwType.HideSelection = false;
            this.lstvwType.Location = new System.Drawing.Point(15, 85);
            this.lstvwType.MultiSelect = false;
            this.lstvwType.Name = "lstvwType";
            this.lstvwType.Size = new System.Drawing.Size(417, 426);
            this.lstvwType.TabIndex = 0;
            this.lstvwType.Tag = "";
            this.lstvwType.UseCompatibleStateImageBehavior = false;
            this.lstvwType.View = System.Windows.Forms.View.Details;
            this.lstvwType.Click += new System.EventHandler(this.lstvwType_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Type Name";
            this.columnHeader1.Width = 180;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "PLC to PC";
            this.columnHeader2.Width = 110;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Point Count";
            this.columnHeader3.Width = 120;
            // 
            // AFrmTypeSet
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(956, 631);
            this.Controls.Add(this.btnCameraSet);
            this.Controls.Add(this.btnLoadVpp);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.nmUpDnPointCount);
            this.Controls.Add(this.btnModifyTypeName);
            this.Controls.Add(this.btnModifyPointName);
            this.Controls.Add(this.txtPointName);
            this.Controls.Add(this.lblPointName);
            this.Controls.Add(this.lblPointCount);
            this.Controls.Add(this.lblPointList);
            this.Controls.Add(this.lstvwPoint);
            this.Controls.Add(this.btnViewVpp);
            this.Controls.Add(this.txtPlcToPc);
            this.Controls.Add(this.txtTypeName);
            this.Controls.Add(this.lstvwType);
            this.Controls.Add(this.lblPlcToPc);
            this.Controls.Add(this.btnPlcToPcSave);
            this.Controls.Add(this.btnSaveVpp);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lblTypeName);
            this.Controls.Add(this.lblTypeList);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AFrmTypeSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TypeSet";
            ((System.ComponentModel.ISupportInitialize)(this.nmUpDnPointCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTypeList;
        private System.Windows.Forms.Label lblTypeName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnSaveVpp;
        private System.Windows.Forms.Button btnPlcToPcSave;
        private System.Windows.Forms.Label lblPlcToPc;
        // 2014.11.29
        private ATMC.Controls.AListView lstvwType;
        
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox txtTypeName;
        private System.Windows.Forms.TextBox txtPlcToPc;
        private System.Windows.Forms.Button btnViewVpp;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        // 2014.11.29
        private ATMC.Controls.AListView lstvwPoint;

        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label lblPointList;
        private System.Windows.Forms.Label lblPointCount;
        private System.Windows.Forms.TextBox txtPointName;
        private System.Windows.Forms.Label lblPointName;
        private System.Windows.Forms.Button btnModifyPointName;
        private System.Windows.Forms.Button btnModifyTypeName;
        private System.Windows.Forms.NumericUpDown nmUpDnPointCount;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnLoadVpp;
        private System.Windows.Forms.Button btnCameraSet;
    }
}