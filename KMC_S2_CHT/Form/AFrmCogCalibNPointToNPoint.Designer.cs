namespace AVisionPro
{
    partial class AFrmCogCalibNPointToNPoint
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
            this.cogCalibNPointToNPointEditV2 = new Cognex.VisionPro.CalibFix.CogCalibNPointToNPointEditV2();
            ((System.ComponentModel.ISupportInitialize)(this.cogCalibNPointToNPointEditV2)).BeginInit();
            this.SuspendLayout();
            // 
            // cogCalibNPointToNPointEditV2
            // 
            this.cogCalibNPointToNPointEditV2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogCalibNPointToNPointEditV2.Location = new System.Drawing.Point(0, 0);
            this.cogCalibNPointToNPointEditV2.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogCalibNPointToNPointEditV2.Name = "cogCalibNPointToNPointEditV2";
            this.cogCalibNPointToNPointEditV2.Size = new System.Drawing.Size(1044, 564);
            this.cogCalibNPointToNPointEditV2.SuspendElectricRuns = false;
            this.cogCalibNPointToNPointEditV2.TabIndex = 0;
            // 
            // AFrmCogCalibNPointToNPoint
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1044, 564);
            this.Controls.Add(this.cogCalibNPointToNPointEditV2);
            this.Name = "AFrmCogCalibNPointToNPoint";
            this.Text = "CogCalibNPointToNPoint";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AFrmCogCalibNPointToNPoint_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.cogCalibNPointToNPointEditV2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.VisionPro.CalibFix.CogCalibNPointToNPointEditV2 cogCalibNPointToNPointEditV2;
    }
}