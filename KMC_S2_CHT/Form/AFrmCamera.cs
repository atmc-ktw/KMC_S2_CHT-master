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
    public partial class AFrmCamera : Form
    {
        private int m_nParentLeft;
        private int m_nParentRight;
        private int m_nParentTop;
        private int m_nParentBottom;

        // 2015.08.09
        //private int m_nType;
        //public delegate void delegateUpdateType();
        //public event delegateUpdateType evtUpdateType;

        public List<clsCAM_Info> m_lstCamInfo = null;

        private int m_nMode = 0;   // 0, view(or modify) 1: add, 2: delete
        private bool m_bNeedUpdate = false;

        private bool m_bSelectCamera = false;   // false: 카메라 선택 모드, true: 카메라 설정 모드
        private string m_strSerialNumber = "";

        public string SerialNumber
        {
            get { return m_strSerialNumber; }
        }


        public AFrmCamera(bool bSelectCamera)
        {
            InitializeComponent();

            // 2015.08.09
            //m_nType = nType;

            m_nMode = 0;

            m_bSelectCamera = bSelectCamera;

            if (m_bSelectCamera == false)
            {
                btnSelect.Visible = false;
            }
            else
            {
                btnAdd.Visible = false;
                btnDelete.Visible = false;
                btnSave.Visible = false;

                txtName.Enabled = false;
                txtSerialNumber.Enabled = false;
                txtExposureTime.Enabled = false;
                txtContrast.Enabled = false;
                txtBrightness.Enabled = false;
                txtTimeout.Enabled = false;
                btnOnlineCamera.Enabled = false;
                cmbPixelFormat.Enabled = false;
            }

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
            m_lstCamInfo = clsCamera.CamInfoList;

            ListViewItem lstItem = new ListViewItem();

            lstvwCamera.Items.Clear();

            for (int i = 0; i < m_lstCamInfo.Count; ++i)
            {
                lstItem = lstvwCamera.Items.Add(m_lstCamInfo[i].m_strName + " : " + m_lstCamInfo[i].m_strSerialNumber);

                lstItem.Tag = m_lstCamInfo[i];
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
            int nIndex = lstvwCamera.FocusedItem.Index;

            if (nIndex < 0)
                return;

            clsCAM_Info CameraInfo = (clsCAM_Info)lstvwCamera.Items[nIndex].Tag;

            txtName.Text = CameraInfo.m_strName;
            txtSerialNumber.Text = CameraInfo.m_strSerialNumber;
            cmbPixelFormat.Text = CameraInfo.m_strPixelFormat;
            //txtIPAddress.Text = ABaslerPylon.GetDeviceIPAddress(CameraInfo.m_strSerialNumber);
            //txtCameraType.Text = ABaslerPylon.GetDevFullName(CameraInfo.m_strSerialNumber);

            clsFrameGrabber grabber = clsCamera.GetFrameGrabberInfo(CameraInfo.m_strSerialNumber);
            if (grabber != null && grabber.m_Grabber != null && grabber.m_Grabber.OwnedGigEAccess != null)
            {
                txtIPAddress.Text = grabber.m_Grabber.OwnedGigEAccess.CurrentIPAddress;
                txtCameraType.Text = grabber.m_Grabber.Name;
            }

            txtExposureTime.Text = CameraInfo.m_n64Exposure.ToString();
            txtContrast.Text = CameraInfo.m_dContrast.ToString("0.0000");
            txtBrightness.Text = CameraInfo.m_dBrightness.ToString("0.0000");
            txtTimeout.Text = CameraInfo.m_nTimeout.ToString();

            txtName.Enabled = false;
            if (m_bSelectCamera == false)
            {
                txtSerialNumber.Enabled = true;
                btnOnlineCamera.Enabled = true;
                cmbPixelFormat.Enabled = true;
                txtExposureTime.Enabled = true;
                txtContrast.Enabled = true;
                txtBrightness.Enabled = true;
                txtTimeout.Enabled = true;
            }
            else
            {
                txtSerialNumber.Enabled = false;
                btnOnlineCamera.Enabled = false;
                cmbPixelFormat.Enabled = false;
                txtExposureTime.Enabled = false;
                txtContrast.Enabled = false;
                txtBrightness.Enabled = false;
                txtTimeout.Enabled = false;
            }

            m_nMode = 0;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtSerialNumber.Text = "";
            txtIPAddress.Text = "";
            txtCameraType.Text = "";
            cmbPixelFormat.SelectedIndex = 0;
            txtExposureTime.Text = Convert.ToInt64(clsCAM_Info._CONST_GIGE_EXPOSURE_TIME).ToString();
            txtContrast.Text = Convert.ToDouble(clsCAM_Info._CONST_GIGE_CONTRAST).ToString("0.0000");
            txtBrightness.Text = Convert.ToDouble(clsCAM_Info._CONST_GIGE_BRIGHTNESS).ToString("0.0000");
            txtTimeout.Text = "10000";  //10 secs

            txtName.Enabled = true;
            txtSerialNumber.Enabled = true;
            btnOnlineCamera.Enabled = true;
            cmbPixelFormat.Enabled = true;
            txtExposureTime.Enabled = true;
            txtContrast.Enabled = true;
            txtBrightness.Enabled = true;
            txtTimeout.Enabled = true;

            m_nMode = 1;    // add
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("저장하시겠습니까?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            clsCAM_Info CamInfo = new clsCAM_Info();

            txtName.Text = txtName.Text.Trim();
            if (txtName.Text.Length == 0)
                return;
            txtSerialNumber.Text = txtSerialNumber.Text.Trim();
            if (txtSerialNumber.Text.Length == 0)
                return;
            cmbPixelFormat.Text = cmbPixelFormat.Text.Trim();
            if (cmbPixelFormat.Text.Length == 0)
                return;

            CamInfo.m_strName = txtName.Text;
            CamInfo.m_strSerialNumber = txtSerialNumber.Text;
            CamInfo.m_strPixelFormat = cmbPixelFormat.Text;
            CamInfo.m_n64Exposure = Convert.ToInt64(txtExposureTime.Text);
            CamInfo.m_dContrast = Convert.ToDouble(txtContrast.Text);
            CamInfo.m_dBrightness = Convert.ToDouble(txtBrightness.Text);
            CamInfo.m_nTimeout = Convert.ToInt32(txtTimeout.Text);

            try
            {
                if (m_nMode == 1) // add
                {
                    m_lstCamInfo.Add(CamInfo);

                    ListViewItem lstItem = new ListViewItem();
                    lstItem = lstvwCamera.Items.Add(CamInfo.m_strName);
                    lstItem.Tag = m_lstCamInfo[m_lstCamInfo.Count - 1];

                    m_bNeedUpdate = true;
                }
                else // modify
                {
                    if (txtName.Text.Length == 0)
                        return;

                    for (int i = 0; i < m_lstCamInfo.Count; i++)
                    {
                        if (m_lstCamInfo[i].m_strName == CamInfo.m_strName)
                        {
                            m_lstCamInfo[i].m_strPixelFormat = CamInfo.m_strPixelFormat;
                            m_lstCamInfo[i].m_strSerialNumber = CamInfo.m_strSerialNumber;
                            m_lstCamInfo[i].m_n64Exposure = CamInfo.m_n64Exposure;
                            m_lstCamInfo[i].m_dContrast = CamInfo.m_dContrast;
                            m_lstCamInfo[i].m_dBrightness = CamInfo.m_dBrightness;
                            m_lstCamInfo[i].m_nTimeout = CamInfo.m_nTimeout;

                            int nIndex = lstvwCamera.FocusedItem.Index;
                            if (nIndex >= 0)
                            {
                                lstvwCamera.Items[nIndex].Text = CamInfo.m_strName + " : " + CamInfo.m_strSerialNumber;
                            }

                            m_bNeedUpdate = true;
                        }
                    }
                }
            }
            catch
            {
            }

            //if (m_nMode == 1)
            {
                txtName.Enabled = false;
                txtSerialNumber.Enabled = false;
                btnOnlineCamera.Enabled = false;
                cmbPixelFormat.Enabled = false;
                txtExposureTime.Enabled = false;
                txtContrast.Enabled = false;
                txtBrightness.Enabled = false;
                txtTimeout.Enabled = false;

                m_nMode = 0;
            }
        }

        private void AFrmCamera_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_bNeedUpdate == true)
                clsCamera.WriteCameraInfo();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("삭제하시겠습니까?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int nIndex = lstvwCamera.FocusedItem.Index;

            if (nIndex < 0)
                return;

            clsCAM_Info CamInfo = (clsCAM_Info)lstvwCamera.Items[nIndex].Tag;

            for (int i = 0; i < m_lstCamInfo.Count; i++)
            {
                if (m_lstCamInfo[i].m_strName == CamInfo.m_strName)
                {
                    m_lstCamInfo.RemoveAt(i);

                    lstvwCamera.Items.RemoveAt(nIndex);

                    m_bNeedUpdate = true;
                }
            }

            txtName.Enabled = false;
            txtSerialNumber.Enabled = false;
            btnOnlineCamera.Enabled = false;
            cmbPixelFormat.Enabled = false;
            txtExposureTime.Enabled = false;
            txtContrast.Enabled = false;
            txtBrightness.Enabled = false;
            txtTimeout.Enabled = false;

            m_nMode = 0;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            int nIndex = lstvwCamera.FocusedItem.Index;
            if (nIndex < 0)
                return;

            clsCAM_Info CamInfo = (clsCAM_Info)lstvwCamera.Items[nIndex].Tag;
            if (CamInfo == null)
                return;

            m_strSerialNumber = CamInfo.m_strSerialNumber;

            Close();
        }

        private void btnOnlineCamera_Click(object sender, EventArgs e)
        {
            AFrmOnlineCamera select = new AFrmOnlineCamera();
            select.SetParentCenter(this.Left, this.Right, this.Top, this.Bottom);
            select.ShowDialog(this);

            if (select.SerialNumber != null && select.SerialNumber.Length > 0)
                txtSerialNumber.Text = select.SerialNumber;
        }
    }
}
