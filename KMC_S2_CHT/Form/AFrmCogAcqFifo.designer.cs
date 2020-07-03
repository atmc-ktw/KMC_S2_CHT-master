namespace AVisionPro
{
    partial class AFrmCogAcqFifo
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
            this.cogAcqFifoEditV2 = new Cognex.VisionPro.CogAcqFifoEditV2();
            ((System.ComponentModel.ISupportInitialize)(this.cogAcqFifoEditV2)).BeginInit();
            this.SuspendLayout();
            // 
            // cogAcqFifoEditV2
            // 
            this.cogAcqFifoEditV2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogAcqFifoEditV2.Location = new System.Drawing.Point(0, 0);
            this.cogAcqFifoEditV2.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogAcqFifoEditV2.Name = "cogAcqFifoEditV2";
            this.cogAcqFifoEditV2.Size = new System.Drawing.Size(992, 466);
            this.cogAcqFifoEditV2.SuspendElectricRuns = false;
            this.cogAcqFifoEditV2.TabIndex = 0;
            // 
            // AFrmCogAcqFifo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(992, 466);
            this.Controls.Add(this.cogAcqFifoEditV2);
            this.Name = "AFrmCogAcqFifo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CogAcqFifo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AFrmCogAcqFifo_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.cogAcqFifoEditV2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.VisionPro.CogAcqFifoEditV2 cogAcqFifoEditV2;
    }
}