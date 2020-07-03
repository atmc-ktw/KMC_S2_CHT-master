using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AVisionPro
{
    public partial class AFrmCogAcqFifo : Form
    {
        public AFrmCogAcqFifo(AAcqFifo aAcqFifo)
        {
            InitializeComponent();
            cogAcqFifoEditV2.Subject = aAcqFifo.AcqFifoTool;
        }

        private void AFrmCogAcqFifo_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 2017.01.09
            cogAcqFifoEditV2.Subject = null;

            // 2015.03.17
            cogAcqFifoEditV2.Dispose();
        }
    }
}
