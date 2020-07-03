using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using AVisionPro;
using Atmc;
using System.Collections;

namespace ACom
{
    public partial class AFrmPlcMap : Form
    {
        private IntPtr m_hParent;
        private ListViewItem m_lstItem = new ListViewItem();
        private ArrayList listItem = null;

        public AFrmPlcMap(IntPtr hParent)
        {
            m_hParent = hParent;

            InitializeComponent();

        }
        
        // 2017.02.12
        private string GetAddressFromIni(int nRW, int nAddress)
        {
            StringBuilder sb = new StringBuilder(256);
            string strVal = "";
            if (nRW == 0)
            {
                // 2017.04.15 32->255
                AUtil.GetPrivateProfileString("PLC", "R_Address" + nAddress.ToString(),
                    nAddress.ToString(), sb, 255, ASDef._INI_FILE);
                strVal = "R:" + sb.ToString();
            }
            else
            {
                // 2017.04.15 32->255
                AUtil.GetPrivateProfileString("PLC", "W_Address" + nAddress.ToString(),
                    nAddress.ToString(), sb, 255, ASDef._INI_FILE);
                strVal = "W:" + sb.ToString();
            }

            return strVal;
        }
        private string GetCommentFromIni(int nRW, int nAddress)
        {
            StringBuilder sb = new StringBuilder(256);

            if (nRW == 0)
            {
                // 2017.04.15 32->255
                AUtil.GetPrivateProfileString("PLC", "R_Comment" + nAddress.ToString(), "", sb, 255, ASDef._INI_FILE);
            }
            else
            {
                // 2017.04.15 32->255
                AUtil.GetPrivateProfileString("PLC", "W_Comment" + nAddress.ToString(), "", sb, 255, ASDef._INI_FILE);
            }

            return sb.ToString();
        }

        private void AtpPlcMap_Load(object sender, EventArgs e)
        {
            if (m_hParent != null)
                AUtil.PostMessage(m_hParent, ASDef._WM_CHANGE_DI, 0xFF, 0xFF);
        }

        public string _10to2(int nData, int nL)
        {
            var vR = 0;
            int i;
            string str2 = "";
            string strTmp = "";

            while (true)
            {
                vR = nData % 2;
                if (vR == 0)
                    strTmp += "0";
                else
                    strTmp += "1";
                nData /= 2;
                if (nData == 0) break;
            }

            for (i = strTmp.Length; i < nL; i++)
            {
                str2 += "0";
            }

            for (i = strTmp.Length - 1; i >= 0; i--)
            {
                str2 += strTmp.Substring(i, 1);

            }

            return str2;
        }

        public void UpdateItem(int nRW, int nAddress, int nData)
        {
            string strAddress, strTmp, strComment;
            int n;
            string[] pstrData = new string[3];
            bool IsItemExist = false;
            
            // 2017.02.12
            //strAddress = m_pstrAddress[nRW] + nAddress.ToString();
            strAddress = GetAddressFromIni(nRW, nAddress);
            strComment = GetCommentFromIni(nRW, nAddress);

            pstrData[0] = nData.ToString();
            pstrData[1] = nData.ToString("X4");

            strTmp = _10to2(nData, 16);

            pstrData[2] = strTmp.Substring(0, 4) + " " + strTmp.Substring(4, 4) + " " + strTmp.Substring(8, 4) + " " + strTmp.Substring(12, 4);

            n = lstPlcMap.Items.Count;

            if (n == 0)
            {
                m_lstItem = lstPlcMap.Items.Add(strAddress);
                m_lstItem.SubItems.Add(pstrData[0]);
                m_lstItem.SubItems.Add(pstrData[1]);
                m_lstItem.SubItems.Add(pstrData[2]);
                // 2017.02.12
                m_lstItem.SubItems.Add(strComment);

            }
            else
            {
                listItem = new ArrayList();
                for (int i = 0; i < n; i++)
                {
                    listItem.Add(lstPlcMap.Items[i]);
                }
                ListViewItem[] plstItem = (ListViewItem[])listItem.ToArray(typeof(ListViewItem));

                foreach (ListViewItem item in plstItem)
                {
                    if (item.Text == strAddress)
                    {
                        IsItemExist = true;
                        m_lstItem = item;
                        // 2010.04.05 마cto
                        break;
                    }
                    else
                    {
                        IsItemExist = false;                        
                    }
                }

                if (IsItemExist)
                {
                    // 2010.04.05 마cto 0,1,2->1,2,3
                    m_lstItem.SubItems[1].Text = pstrData[0];
                    m_lstItem.SubItems[2].Text = pstrData[1];
                    m_lstItem.SubItems[3].Text = pstrData[2];
                    // 2017.02.12
                    m_lstItem.SubItems[4].Text = strComment;

                }
                else
                {
                    m_lstItem = lstPlcMap.Items.Add(strAddress);
                    m_lstItem.SubItems.Add(pstrData[0]);
                    m_lstItem.SubItems.Add(pstrData[1]);
                    m_lstItem.SubItems.Add(pstrData[2]);
                    // 2017.02.12
                    m_lstItem.SubItems.Add(strComment);

                }
            }
            
            //else
            //{
            ////lstPlcMap.Items[Convert.ToInt32(strAddress)].SubItems[1].Text = pstrData[0];
            ////lstPlcMap.Items[Convert.ToInt32(strAddress)].SubItems[2].Text = pstrData[1];
            ////lstPlcMap.Items[Convert.ToInt32(strAddress)].SubItems[3].Text = pstrData[2];
            //m_lstItem = lstPlcMap.Items.Add(strAddress);
            //m_lstItem.SubItems.Add(pstrData[0]);
            //m_lstItem.SubItems.Add(pstrData[1]);
            //m_lstItem.SubItems.Add(pstrData[2]);
            //}
            
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case ASDef._WM_CHANGE_DI:
                    UpdateItem(0, m.WParam.ToInt32(), m.LParam.ToInt32());
                    break;
                case ASDef._WM_CHANGE_DO:
                    UpdateItem(1, m.WParam.ToInt32(), m.LParam.ToInt32());
                    break;
            }

            base.WndProc(ref m);
        }
    }
}
