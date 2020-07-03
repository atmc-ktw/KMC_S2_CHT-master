using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Cognex.VisionPro.ToolGroup;

namespace AVisionPro
{
    public partial class AFrmCogToolGroup : Form
    {
        public AFrmCogToolGroup()
        {
            InitializeComponent();
        }

        public AFrmCogToolGroup(Object objToolGroup)
        {
            InitializeComponent();
            cogToolGroupEditV2.Subject = objToolGroup as CogToolGroup;

            Text = cogToolGroupEditV2.Subject.Name;
        }

        private void AFrmCogToolGroup_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 2017.01.09
            cogToolGroupEditV2.Subject = null;

            // 2015.03.17
            cogToolGroupEditV2.Dispose();
        }
    }
}
