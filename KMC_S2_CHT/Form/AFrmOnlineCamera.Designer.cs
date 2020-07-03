namespace AVisionPro
{
    partial class AFrmOnlineCamera
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
            this.btnClose = new System.Windows.Forms.Button();
            this.lstvwCamera = new ATMC.Controls.AListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSelect = new System.Windows.Forms.Button();
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
            this.lblTitle.Size = new System.Drawing.Size(339, 40);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "CAMERA SELECTION";
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
            this.lblTypeList.Size = new System.Drawing.Size(339, 27);
            this.lblTypeList.TabIndex = 3;
            this.lblTypeList.Text = "Camera List";
            this.lblTypeList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.Location = new System.Drawing.Point(260, 420);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 45);
            this.btnClose.TabIndex = 73;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
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
            this.lstvwCamera.Size = new System.Drawing.Size(339, 318);
            this.lstvwCamera.TabIndex = 2;
            this.lstvwCamera.Tag = "";
            this.lstvwCamera.UseCompatibleStateImageBehavior = false;
            this.lstvwCamera.View = System.Windows.Forms.View.Details;
            this.lstvwCamera.Click += new System.EventHandler(this.lstvwCamera_Click);
            // 
            // colName
            // 
            this.colName.Text = "Camera Name";
            this.colName.Width = 310;
            // 
            // btnSelect
            // 
            this.btnSelect.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSelect.Location = new System.Drawing.Point(151, 420);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(94, 45);
            this.btnSelect.TabIndex = 76;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // AFrmOnlineCamera
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(368, 477);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lstvwCamera);
            this.Controls.Add(this.lblTypeList);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AFrmOnlineCamera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Camera";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AFrmCamera_FormClosed);
            this.Load += new System.EventHandler(this.AFrmCamera_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private ATMC.Controls.AListView lstvwCamera;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.Label lblTypeList;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSelect;
    }
}