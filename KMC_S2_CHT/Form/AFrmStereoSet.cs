using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Atmc;

namespace AVisionPro
{
    public partial class AFrmStereoSet : Form
    {
      
        private ATbPMAlign m_tbPMAlignL = null;
        private ATbPMAlign m_tbPMAlignR = null;
        
        private int m_nType;
        private int m_nPosition;

        public AFrmStereoSet(int nType, int nPosition)
        {
            InitializeComponent();

            m_nType = nType;
            m_nPosition = nPosition;


            m_tbPMAlignL = new ATbPMAlign(m_nType, m_nPosition * 2 + 0, 0);
            AddTabPage(m_tbPMAlignL, tp1);
            m_tbPMAlignR = new ATbPMAlign(m_nType, m_nPosition * 2 + 1, 0);
            AddTabPage(m_tbPMAlignR, tp2);
            
        }
        
        public void AddTabPage(Form form, TabPage tp)
        {
            form.TopLevel = false;
            form.Parent = tp;
            
           // form.AutoSize = true;
            form.Show();
        }

        private void AFrmStereoSet_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_tbPMAlignL.Close();
            m_tbPMAlignR.Close();
        }
    }
}
