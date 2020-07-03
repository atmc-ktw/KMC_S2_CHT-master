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
    public partial class AFrmCogCalibCheckerboard : Form
    {        
        public AFrmCogCalibCheckerboard(ACalibCheckerboard aCalibCheckerboard)
        {
            InitializeComponent();
            
            cogCalibCheckerboardEditV2.Subject = aCalibCheckerboard.GetTool();
        }

        private void AFrmCogCalibCheckerboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 2017.01.09
            cogCalibCheckerboardEditV2.Subject = null;

            // 2015.03.17
            cogCalibCheckerboardEditV2.Dispose();
        }
    }
}
