namespace AVisionPro
{
    partial class AFrmLimit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AFrmLimit));
            this.lblTypeName = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLowX = new System.Windows.Forms.TextBox();
            this.txtHighX = new System.Windows.Forms.TextBox();
            this.txtLowY = new System.Windows.Forms.TextBox();
            this.txtHighY = new System.Windows.Forms.TextBox();
            this.txtLowZ = new System.Windows.Forms.TextBox();
            this.txtHighZ = new System.Windows.Forms.TextBox();
            this.txtLowAX = new System.Windows.Forms.TextBox();
            this.txtHighAX = new System.Windows.Forms.TextBox();
            this.txtLowAY = new System.Windows.Forms.TextBox();
            this.txtHighAY = new System.Windows.Forms.TextBox();
            this.txtLowAZ = new System.Windows.Forms.TextBox();
            this.txtHighAZ = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblLower = new System.Windows.Forms.Label();
            this.lblUpper = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblTypeName
            // 
            this.lblTypeName.BackColor = System.Drawing.Color.Gray;
            this.lblTypeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTypeName.ForeColor = System.Drawing.Color.Gold;
            this.lblTypeName.Location = new System.Drawing.Point(6, 38);
            this.lblTypeName.Name = "lblTypeName";
            this.lblTypeName.Size = new System.Drawing.Size(303, 32);
            this.lblTypeName.TabIndex = 21;
            this.lblTypeName.Text = "name";
            this.lblTypeName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Gray;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Lavender;
            this.lblTitle.Location = new System.Drawing.Point(6, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(303, 29);
            this.lblTitle.TabIndex = 20;
            this.lblTitle.Text = "Limit Value";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "X";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLowX
            // 
            this.txtLowX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLowX.Location = new System.Drawing.Point(79, 155);
            this.txtLowX.Name = "txtLowX";
            this.txtLowX.Size = new System.Drawing.Size(96, 26);
            this.txtLowX.TabIndex = 1;
            this.txtLowX.Text = "123";
            this.txtLowX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoubleKeyPress);
            // 
            // txtHighX
            // 
            this.txtHighX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHighX.Location = new System.Drawing.Point(201, 155);
            this.txtHighX.Name = "txtHighX";
            this.txtHighX.Size = new System.Drawing.Size(96, 26);
            this.txtHighX.TabIndex = 2;
            this.txtHighX.Text = "123";
            this.txtHighX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoubleKeyPress);
            // 
            // txtLowY
            // 
            this.txtLowY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLowY.Location = new System.Drawing.Point(79, 187);
            this.txtLowY.Name = "txtLowY";
            this.txtLowY.Size = new System.Drawing.Size(96, 26);
            this.txtLowY.TabIndex = 3;
            this.txtLowY.Text = "123";
            this.txtLowY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoubleKeyPress);
            // 
            // txtHighY
            // 
            this.txtHighY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHighY.Location = new System.Drawing.Point(201, 187);
            this.txtHighY.Name = "txtHighY";
            this.txtHighY.Size = new System.Drawing.Size(96, 26);
            this.txtHighY.TabIndex = 4;
            this.txtHighY.Text = "123";
            this.txtHighY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoubleKeyPress);
            // 
            // txtLowZ
            // 
            this.txtLowZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLowZ.Location = new System.Drawing.Point(79, 219);
            this.txtLowZ.Name = "txtLowZ";
            this.txtLowZ.Size = new System.Drawing.Size(96, 26);
            this.txtLowZ.TabIndex = 5;
            this.txtLowZ.Text = "123";
            this.txtLowZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoubleKeyPress);
            // 
            // txtHighZ
            // 
            this.txtHighZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHighZ.Location = new System.Drawing.Point(201, 219);
            this.txtHighZ.Name = "txtHighZ";
            this.txtHighZ.Size = new System.Drawing.Size(96, 26);
            this.txtHighZ.TabIndex = 6;
            this.txtHighZ.Text = "123";
            this.txtHighZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoubleKeyPress);
            // 
            // txtLowAX
            // 
            this.txtLowAX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLowAX.Location = new System.Drawing.Point(79, 251);
            this.txtLowAX.Name = "txtLowAX";
            this.txtLowAX.Size = new System.Drawing.Size(96, 26);
            this.txtLowAX.TabIndex = 7;
            this.txtLowAX.Text = "123";
            this.txtLowAX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoubleKeyPress);
            // 
            // txtHighAX
            // 
            this.txtHighAX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHighAX.Location = new System.Drawing.Point(201, 251);
            this.txtHighAX.Name = "txtHighAX";
            this.txtHighAX.Size = new System.Drawing.Size(96, 26);
            this.txtHighAX.TabIndex = 8;
            this.txtHighAX.Text = "123";
            this.txtHighAX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoubleKeyPress);
            // 
            // txtLowAY
            // 
            this.txtLowAY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLowAY.Location = new System.Drawing.Point(79, 283);
            this.txtLowAY.Name = "txtLowAY";
            this.txtLowAY.Size = new System.Drawing.Size(96, 26);
            this.txtLowAY.TabIndex = 9;
            this.txtLowAY.Text = "123";
            this.txtLowAY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoubleKeyPress);
            // 
            // txtHighAY
            // 
            this.txtHighAY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHighAY.Location = new System.Drawing.Point(201, 283);
            this.txtHighAY.Name = "txtHighAY";
            this.txtHighAY.Size = new System.Drawing.Size(96, 26);
            this.txtHighAY.TabIndex = 10;
            this.txtHighAY.Text = "123";
            this.txtHighAY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoubleKeyPress);
            // 
            // txtLowAZ
            // 
            this.txtLowAZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLowAZ.Location = new System.Drawing.Point(79, 315);
            this.txtLowAZ.Name = "txtLowAZ";
            this.txtLowAZ.Size = new System.Drawing.Size(96, 26);
            this.txtLowAZ.TabIndex = 11;
            this.txtLowAZ.Text = "123";
            this.txtLowAZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoubleKeyPress);
            // 
            // txtHighAZ
            // 
            this.txtHighAZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHighAZ.Location = new System.Drawing.Point(201, 315);
            this.txtHighAZ.Name = "txtHighAZ";
            this.txtHighAZ.Size = new System.Drawing.Size(96, 26);
            this.txtHighAZ.TabIndex = 12;
            this.txtHighAZ.Text = "123";
            this.txtHighAZ.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDoubleKeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 20);
            this.label5.TabIndex = 22;
            this.label5.Text = "Y";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(31, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "Z";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(25, 254);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 20);
            this.label7.TabIndex = 22;
            this.label7.Text = "AX";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(25, 286);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "AY";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(25, 318);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 20);
            this.label9.TabIndex = 22;
            this.label9.Text = "AZ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(183, 369);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(114, 40);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "       Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(29, 369);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 40);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "      Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblLower
            // 
            this.lblLower.BackColor = System.Drawing.Color.Gray;
            this.lblLower.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLower.ForeColor = System.Drawing.Color.LightYellow;
            this.lblLower.Location = new System.Drawing.Point(79, 127);
            this.lblLower.Name = "lblLower";
            this.lblLower.Size = new System.Drawing.Size(96, 26);
            this.lblLower.TabIndex = 28;
            this.lblLower.Text = "하한";
            this.lblLower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUpper
            // 
            this.lblUpper.BackColor = System.Drawing.Color.Gray;
            this.lblUpper.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpper.ForeColor = System.Drawing.Color.LightYellow;
            this.lblUpper.Location = new System.Drawing.Point(201, 127);
            this.lblUpper.Name = "lblUpper";
            this.lblUpper.Size = new System.Drawing.Size(96, 26);
            this.lblUpper.TabIndex = 28;
            this.lblUpper.Text = "상한";
            this.lblUpper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblType
            // 
            this.lblType.BackColor = System.Drawing.Color.Gray;
            this.lblType.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblType.ForeColor = System.Drawing.Color.Gold;
            this.lblType.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblType.Location = new System.Drawing.Point(29, 82);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(84, 24);
            this.lblType.TabIndex = 421;
            this.lblType.Text = "차종(Body)";
            this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(119, 82);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(134, 24);
            this.cmbType.TabIndex = 0;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // AFrmLimit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(321, 431);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblUpper);
            this.Controls.Add(this.lblLower);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtHighAZ);
            this.Controls.Add(this.txtLowAZ);
            this.Controls.Add(this.txtHighAY);
            this.Controls.Add(this.txtLowAY);
            this.Controls.Add(this.txtHighAX);
            this.Controls.Add(this.txtLowAX);
            this.Controls.Add(this.txtHighZ);
            this.Controls.Add(this.txtLowZ);
            this.Controls.Add(this.txtHighY);
            this.Controls.Add(this.txtLowY);
            this.Controls.Add(this.txtHighX);
            this.Controls.Add(this.txtLowX);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTypeName);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AFrmLimit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Limit";
            this.Load += new System.EventHandler(this.AFrmLimit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTypeName;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLowX;
        private System.Windows.Forms.TextBox txtHighX;
        private System.Windows.Forms.TextBox txtLowY;
        private System.Windows.Forms.TextBox txtHighY;
        private System.Windows.Forms.TextBox txtLowZ;
        private System.Windows.Forms.TextBox txtHighZ;
        private System.Windows.Forms.TextBox txtLowAX;
        private System.Windows.Forms.TextBox txtHighAX;
        private System.Windows.Forms.TextBox txtLowAY;
        private System.Windows.Forms.TextBox txtHighAY;
        private System.Windows.Forms.TextBox txtLowAZ;
        private System.Windows.Forms.TextBox txtHighAZ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblLower;
        private System.Windows.Forms.Label lblUpper;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbType;

    }
}