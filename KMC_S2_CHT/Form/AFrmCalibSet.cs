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
    public partial class AFrmCalibSet : Form
    {
      
        //private AFrmPMAlign m_frmPMAlign = null;
        private ATbCalibCheckerboard m_tbCalibCheckerboard = null;
        private ATbCalibNPointToNPoint m_tbCalibNPointToNPoint = null;
        
        private int m_nType;
        private int m_nPoint;

        public AFrmCalibSet(int nType, int nPoint, int nPage)
        {
            InitializeComponent();

            m_nType = nType;
            m_nPoint = nPoint;

            
            //m_frmPMAlign = new AFrmPMAlign(m_nType, m_nPoint, 0);
            //AddTabPage(m_frmPMAlign, tp1);   
            // 2013.09.18
            m_tbCalibNPointToNPoint = new ATbCalibNPointToNPoint(m_nType, m_nPoint, 0);
            AddTabPage(m_tbCalibNPointToNPoint, tp1);
            m_tbCalibCheckerboard = new ATbCalibCheckerboard(m_nType, m_nPoint, 0);
            AddTabPage(m_tbCalibCheckerboard, tp2);

            // 2013.09.18
            TC.SelectedIndex = nPage;
        }
        
        public void AddTabPage(Form form, TabPage tp)
        {
            form.TopLevel = false;
            form.Parent = tp;
            
           // form.AutoSize = true;
            form.Show();
        }

        // 2014.08.28
        private void AFrmCalibSet_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_tbCalibNPointToNPoint.Close();
            m_tbCalibCheckerboard.Close();
        }
    }
}
