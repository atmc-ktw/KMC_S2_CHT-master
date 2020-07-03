namespace AVisionPro
{
    partial class AFrmTypeReload
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
            this.btnReload = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lstvwType = new ATMC.Controls.AListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
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
            this.lblTitle.Size = new System.Drawing.Size(324, 40);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "TYPE RELOAD";
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
            this.lblTypeList.Text = "Type List";
            this.lblTypeList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnReload
            // 
            this.btnReload.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReload.Location = new System.Drawing.Point(145, 420);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(94, 45);
            this.btnReload.TabIndex = 72;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("돋움", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnClose.Location = new System.Drawing.Point(245, 420);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(94, 45);
            this.btnClose.TabIndex = 73;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lstvwType
            // 
            this.lstvwType.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstvwType.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstvwType.FullRowSelect = true;
            this.lstvwType.GridLines = true;
            this.lstvwType.Location = new System.Drawing.Point(15, 85);
            this.lstvwType.MultiSelect = false;
            this.lstvwType.Name = "lstvwType";
            this.lstvwType.Size = new System.Drawing.Size(324, 318);
            this.lstvwType.TabIndex = 2;
            this.lstvwType.Tag = "";
            this.lstvwType.UseCompatibleStateImageBehavior = false;
            this.lstvwType.View = System.Windows.Forms.View.Details;
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
            // AFrmTypeReload
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(353, 477);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.lstvwType);
            this.Controls.Add(this.lblTypeList);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AFrmTypeReload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reload";
            this.Load += new System.EventHandler(this.AFrmTypeReload_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private ATMC.Controls.AListView lstvwType;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label lblTypeList;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnClose;
    }
}