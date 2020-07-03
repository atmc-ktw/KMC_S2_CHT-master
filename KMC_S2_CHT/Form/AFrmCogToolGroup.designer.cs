namespace AVisionPro
{
    partial class AFrmCogToolGroup
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
            this.cogToolGroupEditV2 = new Cognex.VisionPro.ToolGroup.CogToolGroupEditV2();
            ((System.ComponentModel.ISupportInitialize)(this.cogToolGroupEditV2)).BeginInit();
            this.SuspendLayout();
            // 
            // cogToolGroupEditV2
            // 
            this.cogToolGroupEditV2.AllowDrop = true;
            this.cogToolGroupEditV2.ContextMenuCustomizer = null;
            this.cogToolGroupEditV2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogToolGroupEditV2.Location = new System.Drawing.Point(0, 0);
            this.cogToolGroupEditV2.MinimumSize = new System.Drawing.Size(489, 0);
            this.cogToolGroupEditV2.Name = "cogToolGroupEditV2";
            this.cogToolGroupEditV2.ShowNodeToolTips = true;
            this.cogToolGroupEditV2.Size = new System.Drawing.Size(870, 499);
            this.cogToolGroupEditV2.SuspendElectricRuns = false;
            this.cogToolGroupEditV2.TabIndex = 0;
            // 
            // AFrmCogToolGroup
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(870, 499);
            this.Controls.Add(this.cogToolGroupEditV2);
            this.Name = "AFrmCogToolGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CogToolGroup";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AFrmCogToolGroup_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.cogToolGroupEditV2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.VisionPro.ToolGroup.CogToolGroupEditV2 cogToolGroupEditV2;
    }
}