using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Atmc;
//using BaslerPylon;

namespace AVisionPro
{
    public partial class AFrmOnlineCamera : Form
    {
        private int m_nParentLeft;
        private int m_nParentRight;
        private int m_nParentTop;
        private int m_nParentBottom;

        private string m_strSerialNumber = "";

        public string SerialNumber
        {
            get { return m_strSerialNumber; }
        }


        public AFrmOnlineCamera()
        {
            InitializeComponent();

            Init();

            InitLanguage();
        }

        private void AFrmCamera_Load(object sender, EventArgs e)
        {
            SetCenter(m_nParentLeft, m_nParentRight, m_nParentTop, m_nParentBottom);
        }

        // close
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Init()
        {
            string strTemp;
            int nIndex;

            foreach( clsFrameGrabber grabber in clsCamera.FrameGrabberList )
            {
                nIndex = grabber.m_Grabber.Name.IndexOf(": ");
                if( nIndex == -1 )
                    lstvwCamera.Items.Add(grabber.m_Grabber.Name + "(" + grabber.m_strSerialNumber + ")");
                else
                {
                    strTemp = grabber.m_Grabber.Name.Substring(nIndex + 1);
                    lstvwCamera.Items.Add(strTemp + "(" + grabber.m_strSerialNumber + ")");
                }

            }
        }

        private void InitLanguage()
        {
            // Common------------
            btnClose.Text = AUtil.GetXmlLanguage("Close");

            // AFrmCamera------------
            //lblTitle.Text = AUtil.GetXmlLanguage("Type_Reload");
            //lblTypeList.Text = AUtil.GetXmlLanguage("Type_List");
            //btnAdd.Text = AUtil.GetXmlLanguage("Reload");
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

        private void lstvwCamera_Click(object sender, EventArgs e)
        {
        }


        private void AFrmCamera_FormClosed(object sender, FormClosedEventArgs e)
        {
        }


        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (lstvwCamera.FocusedItem == null)
                return;

            int nIndex = lstvwCamera.FocusedItem.Index;
            if (nIndex < 0)
                return;

            string strName = lstvwCamera.Items[nIndex].Text;
            if (strName == null || strName.Length == 0)
                return;

            int nFirst = strName.IndexOf('(');
            int nLast = strName.IndexOf(')');

            m_strSerialNumber = strName.Substring(nFirst + 1, nLast - nFirst - 1);

            Close();
        }
    }
}
