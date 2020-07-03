//#define _USE_BASLER_PYLON

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Cognex.VisionPro;

using Atmc;

#if _USE_BASLER_PYLON
using BaslerPylon;
#endif


namespace AVisionPro
{
    public partial class AFrmCameraSet_Cog : Form
    {
        private class clsPoint
        {
            public int m_nIndex = 0;
            public string m_strName = "";
            public string m_strSerialNumber = "";
            // 2016.08.01 by kdi
            public string m_strPixelFormat = "";
        }

        private IntPtr m_hParent;

        private List<clsPoint> m_lstPoint = new List<clsPoint>();
        private int m_nCopyType = -1;

        public AFrmCameraSet_Cog(IntPtr hParent)
        {
            InitializeComponent();

            m_hParent = hParent;

            m_nCopyType = -1;
            m_lstPoint.Clear();
            btnPaste.Enabled = false;

            Init();

            InitLanguage();
        }

        // 2013.12.02
        private void InitLanguage()
        {


            // Common------------
            btnClose.Text = AUtil.GetXmlLanguage("Close");

            // AFrmCameraSet------------
            //lblTitle.Text = AUtil.GetXmlLanguage("Type_Setup");
            //btnModify.Text = AUtil.GetXmlLanguage("Del");
            // 2015.12.09
            lblTitle.Text = AUtil.GetXmlLanguage("Camera_Setup");
            _lblBody.Text = AUtil.GetXmlLanguage("Body");
            btnCopy.Text = AUtil.GetXmlLanguage("Copy");
            btnPaste.Text = AUtil.GetXmlLanguage("Paste");
            btnModify.Text = AUtil.GetXmlLanguage("Modify");
            btnSave.Text = AUtil.GetXmlLanguage("Save");
        }

        private void Init()
        {
            ListViewItem lstItem = new ListViewItem();

            for (int i = 0; i < AVisionProBuild.GetTypeCount(); ++i)
            {
                cmbType.Items.Add(AVisionProBuild.m_lstAType[i].Name);
            }

            cmbType.SelectedIndex = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Modify
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (txtPoint == null || txtPoint.Text.Length == 0)
                return;
            if (txtSerialNumber == null || txtSerialNumber.Text.Length == 0)
                return;
            if (cmbPixelFormat.SelectedIndex < 0)
                return;

            int nPoint = Convert.ToInt32(txtPoint.Text);
            if( nPoint < 0 )
                return;

            string strTemp = "";

            // S/N
            strTemp = txtSerialNumber.Text.Trim();
            lstvwPoint.Items[nPoint].SubItems[2].Text = strTemp;
            // Pixel Format
            strTemp = cmbPixelFormat.Text.Trim();
            lstvwPoint.Items[nPoint].SubItems[3].Text = strTemp;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nType = cmbType.SelectedIndex;

            lstvwPoint.Items.Clear();
            ListViewItem lstItem = new ListViewItem();

            AType aType = AVisionProBuild.GetType(nType);
//#if !_USE_1Camera && !_USE_BASLER_PYLON
            string strSN = "";
//#endif
            StringBuilder sb = new StringBuilder(100);

            for (int i = 0; i < aType.m_lstAPoint.Count; i++)
            {
#if !_USE_1Camera && !_USE_BASLER_PYLON
                //if (aType.m_lstAPoint[i] != null)
                //{
                //    // index
                //    lstItem = lstvwPoint.Items.Add(i.ToString());
                //    lstItem.Checked = true;
                //    // point name
                //    lstItem.SubItems.Add(aType.m_lstAPoint[i].Name);
                //    // camera serial number(현재)
                //    lstItem.SubItems.Add(GetCameraSerialNumber(aType.GetPoint(i).GetAcq().AcqFifoTool));
                //    // camera serial number(기존)
                //    AUtil.GetPrivateProfileString(aType.Name, "Point" + i.ToString() + "_Camera_SN", "", sb, 100, ASDef._INI_FILE);
                //    strSN = sb.ToString();
                //    if( strSN.Length > 0 )
                //        strSN = strSN + GetCameraPort(aType.GetPoint(i).GetAcq().AcqFifoTool);
                //    lstItem.SubItems.Add(strSN);
                //}
                //else
                //    lstItem = lstvwPoint.Items.Add(i.ToString());

                if (aType.m_lstAPoint[i] != null)
                {
                    // index
                    lstItem = lstvwPoint.Items.Add(i.ToString());
                    lstItem.Checked = true;
                    // point name
                    lstItem.SubItems.Add(aType.m_lstAPoint[i].Name);
                    // camera serial number
                    lstItem.SubItems.Add(aType.m_lstAPoint[i].m_strDevName);
                    // pixel format
                    lstItem.SubItems.Add(aType.m_lstAPoint[i].m_strPixelFormat);

                    lstItem.SubItems.Add(strSN);
                }
                else
                    lstItem = lstvwPoint.Items.Add(i.ToString());
#elif _USE_BASLER_PYLON
                //** to do:

                if (aType.m_lstAPoint[i] != null)
                {
                    // index
                    lstItem = lstvwPoint.Items.Add(i.ToString());
                    lstItem.Checked = true;
                    // point name
                    lstItem.SubItems.Add(aType.m_lstAPoint[i].Name);
                    // camera serial number
                    lstItem.SubItems.Add(aType.m_lstAPoint[i].m_strDevName);
                    // pixel format
                    lstItem.SubItems.Add(aType.m_lstAPoint[i].m_strPixelFormat);

                    lstItem.SubItems.Add(strSN);
                }
                else
                    lstItem = lstvwPoint.Items.Add(i.ToString());
#endif
            }

            
            txtSerialNumber.Text = "";
            grbPoint.Text = "";
        }
        
        // copy
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (cmbType.SelectedIndex < 0)
            {
                m_nCopyType = -1;
                m_lstPoint.Clear();
                return;
            }

            int nCount = lstvwPoint.Items.Count;

            m_lstPoint.Clear();

            for( int i = 0; i < nCount; i++ )
            {
                clsPoint point = new clsPoint();

                point.m_nIndex = Convert.ToInt32(lstvwPoint.Items[i].Text);
                point.m_strName = lstvwPoint.Items[i].SubItems[1].Text;
                point.m_strSerialNumber = lstvwPoint.Items[i].SubItems[2].Text;
                // 2016.08.01 by kdi
                point.m_strPixelFormat = lstvwPoint.Items[i].SubItems[3].Text;

                m_lstPoint.Add(point);
            }

            m_nCopyType = cmbType.SelectedIndex;

            btnPaste.Enabled = true;
        }

        // paste
        private void btnPaste_Click(object sender, EventArgs e)
        {
            if (m_nCopyType == -1)
                return;

            int nType = cmbType.SelectedIndex;

            if (nType == m_nCopyType)
            {
                m_nCopyType = -1;
                m_lstPoint.Clear();
                return;
            }

            int nCount = m_lstPoint.Count;

            for (int i = 0; i < nCount; i++)
            {
                lstvwPoint.Items[i].SubItems[2].Text = m_lstPoint[i].m_strSerialNumber;
                // 2016.08.01 by kdi
                lstvwPoint.Items[i].SubItems[3].Text = m_lstPoint[i].m_strPixelFormat;
            }

            m_nCopyType = -1;
            m_lstPoint.Clear();

            btnPaste.Enabled = false;
        }

        // save
        private void btnSave_Click(object sender, EventArgs e)
        {
            int nType = cmbType.SelectedIndex;

            AType aType = AVisionProBuild.GetType(nType);
            string strSN = "";//, strTempSN = "";
            //int nPos = -1;
            StringBuilder sb = new StringBuilder(100);

            for (int i = 0; i < aType.m_lstAPoint.Count; i++)
            {
                strSN = lstvwPoint.Items[i].SubItems[2].Text;
                strSN = strSN.Trim();
                if (strSN.Length == 0)
                {
                    MessageBox.Show(AUtil.GetXmlLanguage("The_camera_is_not_set_point_exists") + "\r\n" + AUtil.GetXmlLanguage("First_Set_your_camera_to_the_point"), "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //MessageBox.Show("카메라가 설정되지 않는 포인트가 존재합니다\r\n해당 포인트에 카메라 설정을 먼저 하세요", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            for (int i = 0; i < aType.m_lstAPoint.Count; i++)
            {
                // camera serial number
                strSN = lstvwPoint.Items[i].SubItems[2].Text;
                strSN = strSN.Trim();

                //AUtil.WritePrivateProfileString(aType.Name, "Dev_" + lstvwPoint.Items[i].SubItems[1].Text, strSN, ASDef._INI_FILE);
                AUtil.WritePrivateProfileString(aType.Name, "Dev_Point" + i.ToString(), strSN, ASDef._INI_FILE);

                aType.m_lstAPoint[i].m_strDevName = strSN;

                // pixel format
                strSN = lstvwPoint.Items[i].SubItems[3].Text;
                strSN = strSN.Trim();

                AUtil.WritePrivateProfileString(aType.Name, "Point" + i.ToString() + "_PixelFormat", strSN, ASDef._INI_FILE);

                aType.m_lstAPoint[i].m_strPixelFormat = strSN;
            }

            MessageBox.Show(AUtil.GetXmlLanguage("Completed_the_save"));
            //MessageBox.Show("저장을 완료하였습니다");
        }

        private void lstvwPoint_Click(object sender, EventArgs e)
        {
            int nIndex = lstvwPoint.FocusedItem.Index;

            grbPoint.Text = lstvwPoint.Items[nIndex].SubItems[1].Text;

            txtPoint.Text = lstvwPoint.Items[nIndex].Text;
            txtName.Text = lstvwPoint.Items[nIndex].SubItems[1].Text;
            string strTempSN = lstvwPoint.Items[nIndex].SubItems[2].Text;
            int nPos = strTempSN.IndexOf('_');
            if (nPos >= 0)
                strTempSN = strTempSN.Substring(0, nPos);
            // Serial Number
            txtSerialNumber.Text = strTempSN;
            // pixel format
            cmbPixelFormat.Text = lstvwPoint.Items[nIndex].SubItems[3].Text;

//#if !_USE_1Camera && !_USE_BASLER_PYLON
            int nType = cmbType.SelectedIndex;
            AType aType = AVisionProBuild.GetType(nType);
            txtIP.Text = GetCameraIPAddress(aType.GetPoint(nIndex).GetAcq().AcqFifoTool);
//#elif _USE_BASLER_PYLON
//            txtIP.Text = ABaslerPylon.GetDeviceIPAddress(txtSerialNumber.Text);
//#endif
        }

        private void grbPoint_Enter(object sender, EventArgs e)
        {

        }

        private string GetCameraSerialNumber(CogAcqFifoTool acqFifo)
        {
            string strSN = "";

            if (acqFifo != null &&
                acqFifo.Operator != null &&
                acqFifo.Operator.FrameGrabber != null)
            {
                //*
                // Digital Camera
                if (acqFifo.Operator.FrameGrabber.OwnedGigEAccess != null)
                {
                    strSN = acqFifo.Operator.FrameGrabber.SerialNumber;
                }
                // Analog Camera
                else
                {
                    strSN = acqFifo.Operator.FrameGrabber.SerialNumber + "_#" + acqFifo.Operator.CameraPort.ToString();
                }
                //*/

                //strSN = acqFifo.Operator.FrameGrabber.SerialNumber;
            }
            else
                strSN = "";

            return strSN;
        }

        private string GetCameraPort(CogAcqFifoTool acqFifo)
        {
            string strSN = "";

            if (acqFifo != null &&
                acqFifo.Operator != null &&
                acqFifo.Operator.FrameGrabber != null)
            {
                //*
                // Digital Camera
                if (acqFifo.Operator.FrameGrabber.OwnedGigEAccess != null)
                {
                    strSN = "";
                }
                // Analog Camera
                else
                {
                    strSN = "_#" + acqFifo.Operator.CameraPort.ToString();
                }
                //*/

                //strSN = "";
            }
            else
                strSN = "";

            return strSN;
        }

        private string GetCameraIPAddress(CogAcqFifoTool acqFifo)
        {
            string strIP = "";

            if (acqFifo != null &&
                acqFifo.Operator != null &&
                acqFifo.Operator.FrameGrabber != null)
            {
                // Digital Camera
                if (acqFifo.Operator.FrameGrabber.OwnedGigEAccess != null)
                {
                    strIP = acqFifo.Operator.FrameGrabber.OwnedGigEAccess.CurrentIPAddress;
                }
                // Analog Camera
                else
                {
                    strIP = "";
                }
            }
            else
                strIP = "";

            return strIP;
        }

        private void btnCamera_Click(object sender, EventArgs e)
        {
//#if _USE_BASLER_PYLON
            AFrmCamera setup = new AFrmCamera(false);
            setup.SetParentCenter(this.Left, this.Right, this.Top, this.Bottom);
            setup.Show(this);
//#endif
        }

        private void btnSelectCamera_Click(object sender, EventArgs e)
        {
            AFrmCamera select = new AFrmCamera(true);
            select.SetParentCenter(this.Left, this.Right, this.Top, this.Bottom);
            select.ShowDialog(this);

            if (select.SerialNumber != null && select.SerialNumber.Length > 0)
                txtSerialNumber.Text = select.SerialNumber;
        }

        
    }
}
