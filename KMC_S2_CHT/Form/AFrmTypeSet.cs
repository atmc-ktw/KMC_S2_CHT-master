// 2015.10.06
//#define _USE_1Camera
// 2016.06.20
//#define _USE_BASLER_PYLON
//#define _USE_IMAGING_CONTROL
//#define _USE_FLIR

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
    public partial class AFrmTypeSet : Form
    {
        private IntPtr m_hParent;

        public AFrmTypeSet(IntPtr hParent)
        {
            InitializeComponent();

            m_hParent = hParent;

            Init();

            InitLanguage();
        }

        // 2013.12.02
        private void InitLanguage()
        {
            // Common------------
            btnClose.Text = AUtil.GetXmlLanguage("Close");

            // AFrmTypeSet------------
            lblTitle.Text = AUtil.GetXmlLanguage("Type_Setup");
            lblTypeList.Text = AUtil.GetXmlLanguage("Type_List");
            lblPointList.Text = AUtil.GetXmlLanguage("Point_List");
            lblTypeName.Text = AUtil.GetXmlLanguage("Type_Name");
            lblPlcToPc.Text = AUtil.GetXmlLanguage("PLC_To_PC");
            lblPointCount.Text = AUtil.GetXmlLanguage("Point_Count");
            lblPointName.Text = AUtil.GetXmlLanguage("Point_Name");
            // 2017.06.08
            //lblPathSetup.Text = AUtil.GetXmlLanguage("Path_Setup");
            //btnSelectPath.Text = AUtil.GetXmlLanguage("Select_Path");
            //btnSavePath.Text = AUtil.GetXmlLanguage("Save_Path");

            btnAdd.Text = AUtil.GetXmlLanguage("Add");
            btnDel.Text = AUtil.GetXmlLanguage("Del");
            btnPlcToPcSave.Text = AUtil.GetXmlLanguage("PLC_To_PC") + " " + AUtil.GetXmlLanguage("Save");
            btnModifyTypeName.Text = AUtil.GetXmlLanguage("Modify_Type_Name");
            btnModifyPointName.Text = AUtil.GetXmlLanguage("Modify_Point_Name");
            btnSaveVpp.Text = AUtil.GetXmlLanguage("Save_VPP");
            btnViewVpp.Text = AUtil.GetXmlLanguage("View_VPP");
            // 2015.12.09
            btnCameraSet.Text = "GigE " + AUtil.GetXmlLanguage("Camera_Setup");
        }

        private void Init()
        {
            ListViewItem lstItem = new ListViewItem();

            lstvwType.Items.Clear();
            lstvwPoint.Items.Clear();
            txtPointName.Text = ""; // 2014.10.24 by kdi
            
            for (int i = 0; i < AVisionProBuild.GetTypeCount(); ++i)
            {
                lstItem = lstvwType.Items.Add(AVisionProBuild.m_lstAType[i].Name);

                lstItem.SubItems.Add(AVisionProBuild.m_lstAType[i].PlcToPc.ToString());
                lstItem.SubItems.Add(AVisionProBuild.m_lstAType[i].PointCount.ToString());
            }
            // 2017.06.08
            //txtPath.Text = AVisionProBuild.m_strResultPath;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {            
            if (txtTypeName.Text != "")
            {
                this.Cursor = Cursors.WaitCursor;

                AVisionProBuild.AddType(txtTypeName.Text, (int)nmUpDnPointCount.Value);
                AVisionProBuild.m_nTypeCount++;

                // 2011.06.23
                AVisionProBuild.GetType(AVisionProBuild.m_nTypeCount - 1).PlcToPc = txtPlcToPc.Text;
                AVisionProBuild.GetType(AVisionProBuild.m_nTypeCount - 1).WriteIniPlcToPc();
                Init();

                this.Cursor = Cursors.Default;

            }            
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lstvwType.FocusedItem == null)
            {
                //MessageBox.Show("Type이 선택되지 않았습니다. Type을 선택 하세요!");
                // 2013.12.02
                MessageBox.Show(AUtil.GetXmlLanguage("Type_Not_Select"));
                return;
            }          
                
            AVisionProBuild.RemoveType(lstvwType.SelectedItems[0].Text);
            AVisionProBuild.m_nTypeCount--;

            Init();
        }

        private void btnSaveVpp_Click(object sender, EventArgs e)
        {
            if (lstvwType.FocusedItem == null)
            {
                //MessageBox.Show("Type이 선택되지 않았습니다. Type을 선택 하세요!");
                // 2013.12.02
                MessageBox.Show(AUtil.GetXmlLanguage("Type_Not_Select"));
                return;
            }

            int nType = lstvwType.FocusedItem.Index;

            if (AVisionProBuild.SaveVpp(nType) == true)
            {
                AVisionProBuild.SaveType();

                MessageBox.Show(AVisionProBuild.GetTypeName(nType) +  ".Vpp is Saved!");
            }
        }

        private void btnPlcToPcSave_Click(object sender, EventArgs e)
        {
            if (lstvwType.FocusedItem == null)
            {
                //MessageBox.Show("Type이 선택되지 않았습니다. Type을 선택 하세요!");
                // 2013.12.02
                MessageBox.Show(AUtil.GetXmlLanguage("Type_Not_Select"));
                return;
            }
    
            int nType = lstvwType.FocusedItem.Index;
            // 2011.06.23
            AVisionProBuild.GetType(nType).PlcToPc = txtPlcToPc.Text;
            AVisionProBuild.GetType(nType).WriteIniPlcToPc();
            Init();            
        }

        private void btnModifyPointName_Click(object sender, EventArgs e)
        {
            if (lstvwType.FocusedItem == null || lstvwPoint.FocusedItem == null)
            {
                //MessageBox.Show("Type 또는 Point가 선택되지 않았습니다. Type 또는 Point를 선택 하세요!");
                // 2013.12.02
                MessageBox.Show(AUtil.GetXmlLanguage("Type_or_Point_Not_Select"));
                return;
            }

            int nType = lstvwType.FocusedItem.Index;
            int nPoint = lstvwPoint.FocusedItem.Index;

            AType aType = AVisionProBuild.GetType(nType);
            if (aType != null && nType >= 0)
            {
                if (aType.m_lstAPoint[nPoint] != null && nPoint >= 0)
                {
                    aType.m_lstAPoint[nPoint].Name = txtPointName.Text;
// 2016.06.20
//#if !_USE_1Camera
#if (!_USE_BASLER_PYLON && !_USE_IMAGING_CONTROL && !_USE_1Camera)
                    // 2015.10.02 by kdi
                    aType.SetPointNameOfAcq(nPoint, txtPointName.Text);
#endif

                    lstvwType_Click(null, null);
                }
            }
        }

        private void lstvwType_Click(object sender, EventArgs e)
        {
            try
            {
            
                int nType = lstvwType.FocusedItem.Index;
                txtTypeName.Text = lstvwType.Items[nType].SubItems[0].Text;
                txtPlcToPc.Text = lstvwType.Items[nType].SubItems[1].Text;
                nmUpDnPointCount.Value = Convert.ToInt32(lstvwType.Items[nType].SubItems[2].Text);

                txtPointName.Text = ""; // 2014.10.24 by kdi
                lstvwPoint.Items.Clear();
                ListViewItem lstItem = new ListViewItem();

                for (int i = 0; i < nmUpDnPointCount.Value; i++)
                {
                    AType aType = AVisionProBuild.GetType(nType);
                    if (aType.m_lstAPoint[i] != null)
                    {
                        lstItem = lstvwPoint.Items.Add(i.ToString());
                        lstItem.SubItems.Add(aType.m_lstAPoint[i].Name);
                    }
                    else
                        lstItem = lstvwPoint.Items.Add(i.ToString());

                }
            }
            catch
            {
            }
        }

        private void lstvwPoint_Click(object sender, EventArgs e)
        {
            try
            {

                int nPoint = lstvwPoint.FocusedItem.Index;
                txtPointName.Text = lstvwPoint.Items[nPoint].SubItems[1].Text;
            }
            catch
            {
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnModifyTypeName_Click(object sender, EventArgs e)
        {
            if (lstvwType.FocusedItem == null)
            {
                //MessageBox.Show("Type이 선택되지 않았습니다. Type을 선택 하세요!");
                // 2013.12.02
                MessageBox.Show(AUtil.GetXmlLanguage("Type_Not_Select"));
                return;
            }
            
            int nType = lstvwType.FocusedItem.Index;

            AType aType = AVisionProBuild.GetType(nType);
            if (aType != null && nType >= 0)
            {
                aType.Name = txtTypeName.Text;

                Init();
            }
        }

        private void btnViewVpp_Click(object sender, EventArgs e)
        {
            if (lstvwType.FocusedItem == null)
            {
                //MessageBox.Show("Type이 선택되지 않았습니다. Type을 선택 하세요!");
                // 2013.12.02
                MessageBox.Show(AUtil.GetXmlLanguage("Type_Not_Select"));
                return;
            }

            int nType = lstvwType.FocusedItem.Index;
            AType aType = AVisionProBuild.GetType(nType);
            AFrmCogToolGroup frm = new AFrmCogToolGroup(aType.m_cogtgType);
            // 2015.03.20
            frm.Show(this);
        }

        /* 2017.06.08
        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                AVisionProBuild.m_strResultPath = dlg.SelectedPath;
                txtPath.Text = AVisionProBuild.m_strResultPath;
            }
        }

        private void btnSavePath_Click(object sender, EventArgs e)
        {
            // 2011.04.21
            AVisionProBuild.m_strResultPath = txtPath.Text;
            AUtil.WritePrivateProfileString("PATH", "ResultPath", txtPath.Text, ASDef._INI_FILE);
        }
        */

        // 2011.06.23
        private void btnLoadVpp_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Vpp Files(*.vpp)|*.vpp";
            // 2015.03.18
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                AVisionProBuild.LoadVpp(dlg.FileName);
                AFrmCogToolGroup frm = new AFrmCogToolGroup(AVisionProBuild.m_cogtgTmp);
                // 2015.03.20
                frm.Show(this);
            }
        }

        // 2015.12.09
        private void btnCameraSet_Click(object sender, EventArgs e)
        {
            // 2018.01.18 by kdi
//#if _USE_BASLER_PYLON
            AFrmCameraSet_Cog setup = new AFrmCameraSet_Cog(this.Handle);
            setup.Show(this);
//#elif (!_USE_IMAGING_CONTROL)
//            AFrmCameraSet setup = new AFrmCameraSet(this.Handle);
//            setup.Show(this);
//#endif
        }     
    }
}
