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
    public partial class AFrmStereoFixtureSet : Form
    {

        private ATbEdtFixtureNPointToNPoint m_tbEdtFixtureNPointToNPointL = null;
        private ATbEdtFixtureNPointToNPoint m_tbEdtFixtureNPointToNPointR = null;
        
        private int m_nType;
        private int m_nPosition;

        public AFrmStereoFixtureSet(int nPosition)
        {
            InitializeComponent();

            m_nType = 0;
            m_nPosition = nPosition;


            m_tbEdtFixtureNPointToNPointL = new ATbEdtFixtureNPointToNPoint(m_nType, m_nPosition * 2 + 0, 0);
            AddTabPage(m_tbEdtFixtureNPointToNPointL, tp1);
            m_tbEdtFixtureNPointToNPointR = new ATbEdtFixtureNPointToNPoint(m_nType, m_nPosition * 2 + 1, 0);
            AddTabPage(m_tbEdtFixtureNPointToNPointR, tp2);
            
        }
        
        public void AddTabPage(Form form, TabPage tp)
        {
            form.TopLevel = false;
            form.Parent = tp;
            
           // form.AutoSize = true;
            form.Show();
        }

        private void AFrmStereoFixtureSet_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_tbEdtFixtureNPointToNPointL.Close();
            m_tbEdtFixtureNPointToNPointR.Close();
        }
    }
}
