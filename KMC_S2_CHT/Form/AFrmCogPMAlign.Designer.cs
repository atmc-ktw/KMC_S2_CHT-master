namespace AVisionPro
{
    partial class AFrmCogPMAlign
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
            this.cogPMAlignEditV2 = new Cognex.VisionPro.PMAlign.CogPMAlignEditV2();
            ((System.ComponentModel.ISupportInitialize)(this.cogPMAlignEditV2)).BeginInit();
            this.SuspendLayout();
            // 
            // cogPMAlignEditV2
            // 
            this.cogPMAlignEditV2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogPMAlignEditV2.Location = new System.Drawing.Point(0, 0);
            this.cogPMAlignEditV2.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogPMAlignEditV2.Name = "cogPMAlignEditV2";
            this.cogPMAlignEditV2.Size = new System.Drawing.Size(1040, 601);
            this.cogPMAlignEditV2.SuspendElectricRuns = false;
            this.cogPMAlignEditV2.TabIndex = 0;
            // 
            // AFrmCogPMAlign
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1040, 601);
            this.Controls.Add(this.cogPMAlignEditV2);
            this.Name = "AFrmCogPMAlign";
            this.Text = "CogPMAlign";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AFrmCogPMAlign_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.cogPMAlignEditV2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.VisionPro.PMAlign.CogPMAlignEditV2 cogPMAlignEditV2;
    }
}