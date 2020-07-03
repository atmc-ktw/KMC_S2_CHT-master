using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Atmc;

using Cognex.VisionPro;

namespace AVisionPro
{
    public partial class AFrm3D_1_Set : Form
    {

        private ATbEdtFindEllipse m_tbEdtFindEllipse = null;
        private ATbEdtFindCorner m_tbEdtFindCorner = null;
        
        private int m_nType;
        private int m_nPoint;
        // 2016.12.20
        private int m_nToolIndex;

        public int m_nPage;

        // 2016.12.20
        //public AFrm3D_1_Set(int nType, int nPoint, ICogImage InputImage)
        public AFrm3D_1_Set(int nType, int nPoint, int nToolIndex, ICogImage InputImage)
        {
            InitializeComponent();

            m_nType = nType;
            m_nPoint = nPoint;
            // 2016.12.20
            m_nToolIndex = nToolIndex;

            // 2016.12.20
            //m_tbEdtFindEllipse = new ATbEdtFindEllipse(m_nType, m_nPoint, 0);
            m_tbEdtFindEllipse = new ATbEdtFindEllipse(m_nType, m_nPoint, m_nToolIndex);

            m_tbEdtFindEllipse.SetInputImage(InputImage);
            AddTabPage(m_tbEdtFindEllipse, tp1);
            // 2016.12.20
            //m_tbEdtFindCorner = new ATbEdtFindCorner(m_nType, m_nPoint, 0);
            m_tbEdtFindCorner = new ATbEdtFindCorner(m_nType, m_nPoint, m_nToolIndex);

            m_tbEdtFindCorner.SetInputImage(InputImage);
            AddTabPage(m_tbEdtFindCorner, tp2);
        }
        
        public void AddTabPage(Form form, TabPage tp)
        {
            form.TopLevel = false;
            form.Parent = tp;
            
           // form.AutoSize = true;
            form.Show();
        }

        private void AFrm3D_1_Set_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_nPage = TC.SelectedIndex;
            m_tbEdtFindEllipse.Close();
            m_tbEdtFindCorner.Close();
        }
    }
}
