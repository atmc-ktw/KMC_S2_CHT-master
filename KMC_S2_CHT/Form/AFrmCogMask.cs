using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Cognex.VisionPro;
using Atmc;
// 2016.03.16
using Cognex.VisionPro.PMAlign;

namespace AVisionPro
{
    public partial class AFrmCogMask : Form
    {
        // 2014.11.21
        private CogImage8Grey m_MaskedImage = null;
        // 2014.11.21
        private CogMaskGraphic m_MaskedGraphic = null;

        public bool m_IsApplied = false;

        
        public AFrmCogMask(ICogImage image, CogImage8Grey mask)
        {
            InitializeComponent();
            cogImageMaskEditV2.Image = image;

            if (mask != null)
            {
                cogImageMaskEditV2.MaskImage = mask;
                // 2014.11.21
                m_MaskedImage = cogImageMaskEditV2.MaskImage;
                m_MaskedGraphic = new CogMaskGraphic();
                m_MaskedGraphic.Image = m_MaskedImage;
            }

            InitLanguage();
        }

        // 2013.12.02
        private void InitLanguage()
        {
            // Common------------
            btnApply.Text = AUtil.GetXmlLanguage("Apply");
            btnCancel.Text = AUtil.GetXmlLanguage("Cancel");
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            // 2014.11.21
            if (m_MaskedGraphic == null)
                m_MaskedGraphic = new CogMaskGraphic();

            m_MaskedImage = cogImageMaskEditV2.MaskImage;
            m_MaskedGraphic.Image = m_MaskedImage;
            m_IsApplied = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // 2014.11.21
            //cogImageMaskEditV2.Image = null;
            //m_MaskedImage = null;

            m_IsApplied = false;
            this.Close();
        }

        public CogMaskGraphic MaskedGraphic
        {
            get { return m_MaskedGraphic; }
        }

        public CogImage8Grey MaskedImage
        {
            get { return m_MaskedImage; }
        }

        public bool MaskApplied
        {
            get { return m_IsApplied; }
        }

        private void AFrmCogMask_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 2015.03.17
            cogImageMaskEditV2.Dispose();            
        }
    }
}
