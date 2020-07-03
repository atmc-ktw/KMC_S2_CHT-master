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

namespace AVisionPro
{
    public partial class AFrmCogModelMaker : Form
    {
        public AFrmCogModelMaker(ICogImage image, ICogShapeModelCollection Subject)
        {
            InitializeComponent();
            cogSynthModelEditorV2.Image = image;
            cogSynthModelEditorV2.Subject = Subject;
        }

        private void AFrmCogModelMaker_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 2017.01.09
            cogSynthModelEditorV2.Subject = null;

            // 2015.03.17
            cogSynthModelEditorV2.Dispose();
        }        
    }
}
