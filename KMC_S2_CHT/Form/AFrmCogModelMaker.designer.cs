namespace AVisionPro
{
    partial class AFrmCogModelMaker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AFrmCogModelMaker));
            this.cogSynthModelEditorV2 = new Cognex.VisionPro.CogSynthModelEditorV2();
            this.SuspendLayout();
            // 
            // cogSynthModelEditorV2
            // 
            this.cogSynthModelEditorV2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogSynthModelEditorV2.Image = null;
            this.cogSynthModelEditorV2.Location = new System.Drawing.Point(0, 0);
            this.cogSynthModelEditorV2.Name = "cogSynthModelEditorV2";
            this.cogSynthModelEditorV2.ShowToolTips = false;
            this.cogSynthModelEditorV2.Size = new System.Drawing.Size(1008, 730);
            this.cogSynthModelEditorV2.Subject = ((Cognex.VisionPro.ICogShapeModelCollection)(resources.GetObject("cogSynthModelEditorV2.Subject")));
            this.cogSynthModelEditorV2.TabIndex = 1;
            // 
            // AFrmCogModelMaker
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.cogSynthModelEditorV2);
            this.Name = "AFrmCogModelMaker";
            this.Text = "CogModelMaker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AFrmCogModelMaker_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.VisionPro.CogSynthModelEditorV2 cogSynthModelEditorV2;
        
    }
}