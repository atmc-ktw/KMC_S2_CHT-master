using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Cognex.VisionPro;

namespace AVisionPro
{
    public partial class AFrmCogPMAlign : Form
    {
        public AFrmCogPMAlign(APMAlign aPMAlign)
        {
            InitializeComponent();
            cogPMAlignEditV2.Subject = aPMAlign.GetTool();
        }

        private void AFrmCogPMAlign_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 2017.01.09
            cogPMAlignEditV2.Subject = null;

            // 2015.03.17
            cogPMAlignEditV2.Dispose();
        }
    }
}
