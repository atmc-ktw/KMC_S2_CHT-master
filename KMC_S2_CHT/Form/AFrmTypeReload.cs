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
    public partial class AFrmTypeReload : Form
    {
        private int m_nParentLeft;
        private int m_nParentRight;
        private int m_nParentTop;
        private int m_nParentBottom;

        // 2015.08.09
        private int m_nType;
        public delegate void delegateUpdateType();
        public event delegateUpdateType evtUpdateType;


        public AFrmTypeReload(int nType)
        {
            InitializeComponent();

            // 2015.08.09
            m_nType = nType;

            Init();

            InitLanguage();
        }

        // reload
        private void btnReload_Click(object sender, EventArgs e)
        {
            string strTemp = "";

            if (lstvwType.SelectedItems.Count == 0)
            {
                MessageBox.Show(AUtil.GetXmlLanguage("Type_Not_Select"));
                return;
            }

            if (lstvwType.FocusedItem.Text != lstvwType.SelectedItems[0].Text)
            {
                MessageBox.Show(AUtil.GetXmlLanguage("Type_Not_Select"));
                return;
            }

            string strTypeName = lstvwType.FocusedItem.Text;

            strTemp = string.Format("Do you reload the {0}'s VPP Information?", strTypeName);
            if (MessageBox.Show(strTemp, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int nType = lstvwType.FocusedItem.Index;

            //** 2016.04.26 by kdi
            BackgroundWorker backWorker = new BackgroundWorker();
            backWorker.DoWork += DoProcess;
            backWorker.RunWorkerCompleted += DoEnd;
            backWorker.RunWorkerAsync(strTypeName);
            //*/

            /** 2016.04.26 by kdi. 쓰레드로 이동
            AType aType = new AType(strTypeName);
            int nIndex = AVisionProBuild.FindType(strTypeName);
            if (nIndex == -1)
            {
                MessageBox.Show("Type is not found");
                return;
            }

            AVisionProBuild.SetType(aType, nIndex);

            MessageBox.Show("Successfully done");

            // 2015.08.09
            if (evtUpdateType != null)
            {
                if( m_nType == nIndex )
                    evtUpdateType();
            }

            strTemp = string.Format("type reload: type={0}", strTypeName);
            AVisionProBuild.WriteLogFile(strTemp);
            //*/
        }

        // close
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        // 2016.04.26 by kdi
        public void DoProcess(object sender, DoWorkEventArgs e)
        {
            if (e.Argument == null)
                return;
            string strTypeName = (string) e.Argument;

            AType aType = new AType(strTypeName);
            int nIndex = AVisionProBuild.FindType(strTypeName);

            if (nIndex != -1)
            {
                AVisionProBuild.SetType(aType, nIndex);

                GC.Collect();
            }

            e.Result = Tuple.Create<int, string>(nIndex, strTypeName);
        }

        // 2016.04.26 by kdi
        public void DoEnd(object sender, RunWorkerCompletedEventArgs e)
        {
            Tuple<int, string> res = e.Result as Tuple<int, string>;

            int nIndex = (int)res.Item1;
            string strTypeName = (string)res.Item2;

            if (nIndex == -1)
            {
                MessageBox.Show("Type is not found");
                return;
            }

            MessageBox.Show("Successfully done");

            // 2015.08.09
            if (evtUpdateType != null)
            {
                if (m_nType == nIndex)
                    evtUpdateType();
            }

            string strTemp = string.Format("type reload: type={0}", strTypeName);
            AVisionProBuild.WriteLogFile(strTemp);
        }

        private void Init()
        {
            ListViewItem lstItem = new ListViewItem();

            lstvwType.Items.Clear();

            for (int i = 0; i < AVisionProBuild.GetTypeCount(); ++i)
            {
                lstItem = lstvwType.Items.Add(AVisionProBuild.m_lstAType[i].Name);

                lstItem.SubItems.Add(AVisionProBuild.m_lstAType[i].PlcToPc.ToString());
            }
        }

        private void InitLanguage()
        {
            // Common------------
            btnClose.Text = AUtil.GetXmlLanguage("Close");

            // AFrmTypeReload------------
            lblTitle.Text = AUtil.GetXmlLanguage("Type_Reload");
            lblTypeList.Text = AUtil.GetXmlLanguage("Type_List");
            btnReload.Text = AUtil.GetXmlLanguage("Reload");
        }

        public void SetCenter(int nLeft, int nRight, int nTop, int nBottom)
        {
            if (nLeft > nRight)
                return;
            if (nBottom < nTop)
                return;

            int nCenterX = nLeft + (nRight - nLeft) / 2;
            int nCenterY = nTop + (nBottom - nTop) / 2;

            this.Left = nCenterX - this.Width/2;
            this.Top = nCenterY - this.Height/2;
        }

        public void SetParentCenter(int nLeft, int nRight, int nTop, int nBottom)
        {
            m_nParentLeft = nLeft;
            m_nParentRight = nRight;
            m_nParentTop = nTop;
            m_nParentBottom = nBottom;
        }

        private void AFrmTypeReload_Load(object sender, EventArgs e)
        {
            SetCenter(m_nParentLeft, m_nParentRight, m_nParentTop, m_nParentBottom);
        }
    }
}
