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
    public partial class AFrmCogCalibNPointToNPoint : Form
    {        
        public AFrmCogCalibNPointToNPoint(ACalibNPointToNPoint aCalibNPointToNPoint)
        {
            InitializeComponent();
            
            cogCalibNPointToNPointEditV2.Subject = aCalibNPointToNPoint.GetTool();
        }

        private void AFrmCogCalibNPointToNPoint_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 2017.01.09
            cogCalibNPointToNPointEditV2.Subject = null;

            // 2015.03.17
            cogCalibNPointToNPointEditV2.Dispose();
        }
    }
}
