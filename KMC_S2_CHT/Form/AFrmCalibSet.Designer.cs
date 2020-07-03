namespace AVisionPro
{
    partial class AFrmCalibSet
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
            this.tp2 = new System.Windows.Forms.TabPage();
            this.tp1 = new System.Windows.Forms.TabPage();
            this.TC = new System.Windows.Forms.TabControl();
            this.TC.SuspendLayout();
            this.SuspendLayout();
            // 
            // tp2
            // 
            this.tp2.Location = new System.Drawing.Point(4, 22);
            this.tp2.Name = "tp2";
            this.tp2.Size = new System.Drawing.Size(1266, 974);
            this.tp2.TabIndex = 2;
            this.tp2.Text = "CalibCheckerboard";
            this.tp2.UseVisualStyleBackColor = true;
            // 
            // tp1
            // 
            this.tp1.Location = new System.Drawing.Point(4, 22);
            this.tp1.Name = "tp1";
            this.tp1.Size = new System.Drawing.Size(1256, 964);
            this.tp1.TabIndex = 1;
            this.tp1.Text = "CalibNPointToNPoint";
            this.tp1.UseVisualStyleBackColor = true;
            // 
            // TC
            // 
            this.TC.Controls.Add(this.tp1);
            this.TC.Controls.Add(this.tp2);
            this.TC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TC.Location = new System.Drawing.Point(0, 0);
            this.TC.Name = "TC";
            this.TC.SelectedIndex = 0;
            this.TC.Size = new System.Drawing.Size(1264, 990);
            this.TC.TabIndex = 2;
            // 
            // AFrmCalibSet
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1264, 990);
            this.Controls.Add(this.TC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AFrmCalibSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AFrmCalibSet_FormClosed);
            this.TC.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tp2;
        private System.Windows.Forms.TabPage tp1;
        private System.Windows.Forms.TabControl TC;


    }
}