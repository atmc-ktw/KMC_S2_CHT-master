using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;
using System.Xml;
using System.Windows.Forms;
using System.Diagnostics;
// 2017.02.17
using System.Reflection;
using System.IO;
// 2019.06.13
using System.Drawing;
using System.Drawing.Imaging;

namespace Atmc
{
    // 2016.07.31
    //class AUtil
    public partial class AUtil
    {
        [DllImport("user32.dll")]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, int wParam, int IParam);

        /*
        //-------------------------------------------------------------
        // 2015.03.01
        //[DllImport("user32.dll")]
        //public static extern bool SendMessage(IntPtr hWnd, int Msg, int wParam, int IParam);
        public const Int32 WM_COPYDATA = 0x004A;

        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public UInt32 cbData;
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, ref Win32API.COPYDATASTRUCT lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, StringBuilder lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPStr)] string lParam);

        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, UInt32 Msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SendMessage(HandleRef hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        [Flags] 
        public enum SendMessageTimeoutFlags : uint
        { 
            SMTO_NORMAL = 0x0, 
            SMTO_BLOCK = 0x1, 
            SMTO_ABORTIFHUNG = 0x2, 
            SMTO_NOTIMEOUTIFNOTHUNG = 0x8, 
            SMTO_ERRORONEXIT = 0x0020 
        } 

        [DllImport("user32.dll")]
        public static extern bool SendMessageTimeout(IntPtr hWnd, int Msg, int wParam, int IParam, SendMessageTimeoutFlags flags, uint uTimeout, out IntPtr lpdwResult);

        //예)
        //IntPtr temp;                  
        // var res =  SendMessageTimeout(hWnd, mesg, IntPtr.Zero, IntPtr.Zero, SendMessageTimeoutFlags.SMTO_ABORTIFHUNG | SendMessageTimeoutFlags.SMTO_BLOCK, 500, out temp);        
        //-------------------------------------------------------------
        */

        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("kernel32")]
        public static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

        [DllImport("kernel32")]
        public static extern int GetPrivateProfileInt(string lpAppName, string lpKeyName, int nDefault, string lpFileName);

        [DllImport("kernel32")]
        public static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, 
                                                            StringBuilder lpReturnedString, int nSize, string lpFileName);

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr OpenMutex(uint dwDesiredAccess, int bInheritHandle, string lpName);

        [DllImport("Kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr CreateMutex(IntPtr lpMutexAttributes, int bInitialOwner, string lpName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

        
        //[DllImport("user32.dll", SetLastError=true)]
        //public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        // When you don't want the ProcessId, use this overload and pass IntPtr.Zero for the second parameter
        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, IntPtr ProcessId);

        [DllImport("user32.dll")]
        public static extern bool AttachThreadInput(uint idAttach, uint idAttachTo, bool fAttach);
        
        
        [DllImport("user32.dll", SetLastError=true)]
        public static extern bool BringWindowToTop(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError=true)]
        public static extern bool BringWindowToTop(HandleRef hWnd);

        // 2011.08.11
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        // 2011.08.11
        [DllImport("user32.dll")]
        public static extern void SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool MoveWindow(IntPtr hWnd, int x, int y, int cx, int cy, bool repaint);

        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint uFlags);
        
        //---- hWndInsertAfter -------------
        static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        static readonly IntPtr HWND_TOP = new IntPtr(0);
        static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        /*
        ----- uFlags ---------------
        NOSIZE = 0x0001,
        NOMOVE = 0x0002,
        NOZORDER = 0x0004,
        NOREDRAW = 0x0008,
        NOACTIVATE = 0x0010,
        DRAWFRAME = 0x0020,
        FRAMECHANGED = 0x0020,
        SHOWWINDOW = 0x0040,
        HIDEWINDOW = 0x0080,
        NOCOPYBITS = 0x0100,
        NOOWNERZORDER = 0x0200,
        NOREPOSITION = 0x0200,
        NOSENDCHANGING = 0x0400,
        DEFERERASE = 0x2000,
        ASYNCWINDOWPOS = 0x4000;
        ---------------------------
        */


        public static bool IsAppFirstRun(string appID)
        {
            bool ret = false;
            if (OpenMutex(0x1F0001, 0, appID) == IntPtr.Zero)
            {
                CreateMutex(IntPtr.Zero, 0, appID);
                ret = true;
            }
            return ret;
        }
 
        public static string GetWordString(string strData, int nNum, char cSec)
        {
            int i, n, nSPos, nLen;
            string strResult;

            n = 0;
            nSPos = 0;
            strResult = "";
            for (i = 1; i < strData.Length; i++)
            {
                if ((strData[i - 1] != cSec) && (strData[i] == cSec))
                {
                    nLen = i - nSPos;
                    if (n == nNum)
                    {
                        strResult = strData.Substring(nSPos, nLen);
                        return strResult;
                    }
                }
                if ((strData[i - 1] == cSec) && (strData[i] != cSec))
                {
                    nSPos = i;
                    n++;
                } 
            }
            if (n == nNum)
            {
                nLen = strData.Length - nSPos + 1;
                strResult = strData.Substring(nSPos, nLen);
            }
            return strResult;
        }

        public static string CharszToString(char[] szSource)
        {
            string strR = "";
            for (int i = 0; i < szSource.Length; i++)
            {
                if (szSource[i] == '\0')
                    break;

                strR += szSource[i];
            }
            return strR;
        }

        public static string CharToString(char[] szSource, int nLen)
        {
            string strR = "";
            if (nLen > szSource.Length)
                return strR;

            for (int i = 0; i < nLen; i++)
            {
                strR += szSource[i];
            }
            return strR;
        }

        public static byte[] RawSerialize(object Anything)
        {
            int nRawsize = Marshal.SizeOf(Anything);
            IntPtr pBuffer = Marshal.AllocHGlobal(nRawsize);
            Marshal.StructureToPtr(Anything, pBuffer, false);
            byte[] pbyRawdatas = new byte[nRawsize];
            Marshal.Copy(pBuffer, pbyRawdatas, 0, nRawsize);
            Marshal.FreeHGlobal(pBuffer);
            return pbyRawdatas;
        }

        // 2017.02.17 by kdi
        public static string GetFileVersion(Assembly assembly)
        {
            if (assembly == null || assembly.Location == null)
                return "";

            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            return fvi.FileVersion.ToString();
        }

        // 2017.02.17 by kdi
        public static DateTime GetFileDateTime(string strFile)
        {
            if (File.Exists(strFile) == false)
                return DateTime.Now;

            FileInfo file = new FileInfo(strFile);
            return file.LastWriteTime;
        }

        // 2017.02.17 by kdi
        public static string GetAssemblyVersion(Assembly assembly)
        {
            if (assembly == null || assembly.Location == null)
                return "";

            Assembly asm = Assembly.LoadFrom(assembly.Location);
            AssemblyName name = asm.GetName();
            string strVer = name.Version.ToString();
            return name.Version.ToString();
        }

        public static string GetDateTimeString(DateTime datetime, bool bSaveToFile)
        {
            string strDateTime = "";

            if (bSaveToFile)
                strDateTime = string.Format("{0:0000}{1:00}{2:00}_{3:00}{4:00}{5:00}{6:000}", datetime.Year, datetime.Month, datetime.Day, datetime.Hour, datetime.Minute, datetime.Second, datetime.Millisecond);
            else
                strDateTime = string.Format("{0:0000}-{1:00}-{2:00} {3:00}:{4:00}:{5:00}.{6:000}", datetime.Year, datetime.Month, datetime.Day, datetime.Hour, datetime.Minute, datetime.Second, datetime.Millisecond);

            return strDateTime;
        }

        // 2016.01.12
        public static XmlDocument m_XmlFile = null;
        
        // 2013.12.02
        public static string GetXmlLanguage(string strItem)
        {
            string strXMLData = "";

            try
            {
                // 2016.01.29 try 안으로 이동
                // 2016.01.12
                if (m_XmlFile == null)
                {
                    m_XmlFile = new XmlDocument();
                    m_XmlFile.Load(ASDef._XML_LANGUAGE);
                }

                // 2016.01.12
                //XmlFile.Load(ASDef._XML_LANGUAGE);
                // 2016.01.29
                if (ASDef._LANGUAGE == "eng" || m_XmlFile == null)
                {
                    strXMLData = strItem.Replace('_', ' ');
                }
                else
                {
                    // 2016.01.12
                    XmlNode currentNode = m_XmlFile.DocumentElement.SelectSingleNode("//" + strItem + "//" + ASDef._LANGUAGE);
                    strXMLData = currentNode.InnerText;

                    if (strXMLData == "")
                        strXMLData = strItem.Replace('_', ' ');
                }
                
            }
            catch
            {
                // 2014.07.28
                //MessageBox.Show("<" + strItem + "> Language.Xml File reading failed!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                strXMLData = strItem.Replace('_', ' ');
                // 2016.01.29
                m_XmlFile = null;
            }

            return strXMLData;
        }

        
        // 2013.11.19
        public static string GetXmlData(string strItem, string strXML)
        {
            string strXMLData = "";

            XmlDocument XmlFile = new XmlDocument();

            try
            {
                XmlFile.Load(strXML);
                XmlNode currentNode = XmlFile.DocumentElement.SelectSingleNode("//" + strItem);
                strXMLData = currentNode.InnerText;
            }
            catch
            {
                MessageBox.Show(strXML + " File reading failed!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return strXMLData;
        }
        
        // 2013.12.02
        public static void WriteXmlData(string strItem, string strText, string strXML)
        {
            XmlDocument XmlFile = new XmlDocument();

            if (strText != "")
            {
                try
                {
                    XmlFile.Load(strXML);
                    XmlNode currentNode = XmlFile.SelectSingleNode("//" + strItem);
                    currentNode.FirstChild.Value = strText;
                    XmlFile.Save(strXML);
                }
                catch
                {
                    MessageBox.Show(strXML + " File reading failed!", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        // 2011.07.26
        public static string[] GetSplit(char [] pcSplit, string strLine)
        {
            return strLine.Split(pcSplit, StringSplitOptions.RemoveEmptyEntries);

        }

        // 2011.07.26
        public static string[] GetSplit(char cSplit, string strLine)
        {
            char[] pcSplit = new char[]{ cSplit };
            return strLine.Split(pcSplit, StringSplitOptions.RemoveEmptyEntries);

        }

        // 2011.07.26
        public static object ByteToStructure(byte[] data, Type type) // byte 배열를 구조체로 
        {

            IntPtr buff = Marshal.AllocHGlobal(data.Length); // 배열의 크기만큼 비관리 메모리 영역에 메모리를 할당한다.

            Marshal.Copy(data, 0, buff, data.Length); // 배열에 저장된 데이터를 위에서 할당한 메모리 영역에 복사한다.
            object obj = Marshal.PtrToStructure(buff, type); // 복사된 데이터를 구조체 객체로 변환한다.

            Marshal.FreeHGlobal(buff); // 비관리 메모리 영역에 할당했던 메모리를 해제함



            if (Marshal.SizeOf(obj) != data.Length)// (((PACKET_DATA)obj).TotalBytes != data.Length) // 구조체와 원래의 데이터의 크기 비교
            {

                return null; // 크기가 다르면 null 리턴

            }

            return obj; // 구조체 리턴

        }

        // 2011.07.26        
        public static byte[] StructureToByte(object obj) // 구조체를 byte 배열로 
        {

            int datasize = Marshal.SizeOf(obj);//((PACKET_DATA)obj).TotalBytes; // 구조체에 할당된 메모리의 크기를 구한다.

            IntPtr buff = Marshal.AllocHGlobal(datasize); // 비관리 메모리 영역에 구조체 크기만큼의 메모리를 할당한다.

            Marshal.StructureToPtr(obj, buff, false); // 할당된 구조체 객체의 주소를 구한다.

            byte[] data = new byte[datasize]; // 구조체가 복사될 배열

            Marshal.Copy(buff, data, 0, datasize); // 구조체 객체를 배열에 복사

            Marshal.FreeHGlobal(buff); // 비관리 메모리 영역에 할당했던 메모리를 해제함

            return data; // 배열을 리턴
        }

        // 2015.12.29
        /*
        public static void TopWindow(IntPtr hNowHandle)
        {
            SetWindowPos(hNowHandle, HWND_TOP, 0, 0, 0, 0, 0x0001);

            if (GetForegroundWindow() != hNowHandle)
            {
                IntPtr h_active_wnd = GetForegroundWindow();
                if (h_active_wnd != null)
                {
                    uint thread_id = GetWindowThreadProcessId(h_active_wnd, (IntPtr)null);
                    //uint current_thread_id = (uint)AppDomain.GetCurrentThreadId();
                    //uint current_thread_id = (uint)Thread.CurrentThread.ManagedThreadId;
                    uint current_thread_id = GetWindowThreadProcessId(hNowHandle, (IntPtr)null);
                    if (current_thread_id != thread_id)
                    {
                        if (AttachThreadInput(current_thread_id, thread_id, true))
                        {
                            // 2011.08.16
                            ShowWindow(hNowHandle, 1);
                            BringWindowToTop(hNowHandle);
                            AttachThreadInput(current_thread_id, thread_id, false);
                        }
                    }
                }
            }
        }
        */
        public static void TopWindow(IntPtr hNowHandle, int nLeft, int nTop)
        {
            // 2015.12.22 by kdi. SetWindowPos(hNowHandle, HWND_TOP, 0, 0, 0, 0, 0x0001);
            SetWindowPos(hNowHandle, HWND_TOP, nLeft, nTop, 0, 0, 0x0001);

            if (GetForegroundWindow() != hNowHandle)
            {
                IntPtr h_active_wnd = GetForegroundWindow();
                if (h_active_wnd != null)
                {
                    uint thread_id = GetWindowThreadProcessId(h_active_wnd, (IntPtr)null);
                    //uint current_thread_id = (uint)AppDomain.GetCurrentThreadId();
                    //uint current_thread_id = (uint)Thread.CurrentThread.ManagedThreadId;
                    uint current_thread_id = GetWindowThreadProcessId(hNowHandle, (IntPtr)null);
                    if (current_thread_id != thread_id)
                    {
                        if (AttachThreadInput(current_thread_id, thread_id, true))
                        {
                            // 2011.08.16
                            ShowWindow(hNowHandle, 1);
                            BringWindowToTop(hNowHandle);
                            AttachThreadInput(current_thread_id, thread_id, false);
                        }
                    }
                }
            }
            else // 2015.12.22 by kdi
            {
                SetForegroundWindow(hNowHandle);
                BringWindowToTop(hNowHandle);
            }

            /*
            // 2011.08.11
            Process[] procs;
            IntPtr prHandle;
            string strName;

            procs = Process.GetProcesses();
            foreach (Process aProc in procs)
            {
                strName = aProc.ProcessName.ToString();
                if (strName == strProcessName || strName == strProcessName + ".vshost")
                {
                    prHandle = aProc.MainWindowHandle;
                    ShowWindow(prHandle, 1);
                    BringWindowToTop(prHandle);
                    SetForegroundWindow(prHandle);
                    return;
                }
            }
            */
        }

        // 2012.11.26
        public static void Delay(int nMS)
        {
            // 2015.03.16
            /*
            DateTime dtStart = new DateTime();
            TimeSpan tmsInterval = new TimeSpan(0, 0, 0, 0, nMS);
            dtStart = DateTime.Now;
            while ((DateTime.Now - dtStart) < tmsInterval)
            {
                Application.DoEvents();

            }
            */
            Delay(nMS, false);
        }

        // 2015.03.13 by kdi
        public static void Delay(int nMS, bool bSleep)
        {
            DateTime dtStart = new DateTime();
            TimeSpan tmsInterval = new TimeSpan(0, 0, 0, 0, nMS);
            dtStart = DateTime.Now;
            while ((DateTime.Now - dtStart) < tmsInterval)
            {
                // 2017.10.01
                // HMC U52 샤시토크 에서
                // 조명 후 Delay애서 DoEvents를 안하면
                // PMAlign에서 Display.Image가
                // NPointToNPoint에 수치가 안 나오는 현상 발생
                // 2017.08.02
                // 2017.02.17
                // 2016.12.15
                Application.DoEvents();

                if (bSleep == true)
                    System.Threading.Thread.Sleep(1);
            }
        }

        // 2013.05.06
        public static void OnlyNumberDouble(ref KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) 
                || e.KeyChar == Convert.ToChar(Keys.Back)
                || e.KeyChar == 3  //Ctrl+C
                || e.KeyChar == 22 //Ctrl+V
                || e.KeyChar == '.' || e.KeyChar == '-' || e.KeyChar == '+'))
            {
                e.Handled = true;
            }
        }

        // 2013.05.06
        public static void OnlyNumberUDouble(ref KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)
                || e.KeyChar == Convert.ToChar(Keys.Back)
                || e.KeyChar == 3  //Ctrl+C
                || e.KeyChar == 22 //Ctrl+V
                || e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        // 2013.05.06
        public static void OnlyNumberInt(ref KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)
                || e.KeyChar == Convert.ToChar(Keys.Back)
                || e.KeyChar == 3  //Ctrl+C
                || e.KeyChar == 22 //Ctrl+V
                || e.KeyChar == '-' || e.KeyChar == '+'))
            {
                e.Handled = true;
            }
        }

        // 2013.05.06
        public static void OnlyNumberUInt(ref KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)
                || e.KeyChar == Convert.ToChar(Keys.Back)
                || e.KeyChar == 3  //Ctrl+C
                || e.KeyChar == 22 //Ctrl+V
                ))
            {
                e.Handled = true;
            }
        }

        // 2014.07.15
        static public class TopMostMessageBox
        {
            static public DialogResult Show(string message)
            {
                return Show(message, string.Empty, MessageBoxButtons.OK);
            }

            static public DialogResult Show(string message, string title)
            {
                return Show(message, title, MessageBoxButtons.OK);
            }

            static public DialogResult Show(string message, string title,
                MessageBoxButtons buttons)
            {
                return Show(message, title, buttons, MessageBoxIcon.None);
            }

            // 2014.07.17
            static public DialogResult Show(string message, string title,
                MessageBoxButtons buttons, MessageBoxIcon icon)
            {
                // Create a host form that is a TopMost window which will be the 
                // parent of the MessageBox.
                Form topmostForm = new Form();
                // We do not want anyone to see this window so position it off the 
                // visible screen and make it as small as possible
                topmostForm.Size = new System.Drawing.Size(1, 1);
                topmostForm.StartPosition = FormStartPosition.Manual;
                System.Drawing.Rectangle rect = SystemInformation.VirtualScreen;
                topmostForm.Location = new System.Drawing.Point(rect.Bottom + 10,
                    rect.Right + 10);
                topmostForm.Show();
                // Make this form the active form and make it TopMost
                topmostForm.Focus();
                topmostForm.BringToFront();
                // 2015.12.29 by kdi. 
                //topmostForm.TopMost = true;
                AUtil.TopWindow(topmostForm.Handle, -100, -100);

                // Finally show the MessageBox with the form just created as its owner
                DialogResult result = MessageBox.Show(topmostForm, message, title,
                    buttons, icon);
                topmostForm.Dispose(); // clean it up all the way

                return result;
            }
        }

        // 2014.10.22 by kdi
        static public class ADragDrop
        {
            static public void DoDragOver(object sender, DragEventArgs e)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    if ((e.AllowedEffect & DragDropEffects.Move) != 0)
                        e.Effect = DragDropEffects.Move;
                    else
                        e.Effect = DragDropEffects.None;
                }
                else
                    e.Effect = DragDropEffects.None;
            }

            static public string DoDragDrop(object sender, DragEventArgs e)
            {
                string strPath = "";
                List<string> _data = new List<string>();

                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    _data.AddRange((string[])e.Data.GetData(DataFormats.FileDrop));
                    strPath = _data[0];
                }

                return strPath;
            }
        }

        // 2015.01.05        
        public static uint ReverseBit(uint x)
        {
            uint y = 0;
            for (int i = 0; i < 16; ++i)
            {
                y <<= 1;
                y |= (x & 1);
                x >>= 1;
            }
            return y;
        }

        // 2015.04.03
        // nCount = GetCountDirFiles("V:\\Result\\핸즈2\\alsdream.vol1\\OK2015_03_24\\GM0025\\Point0", "*.jpg");
        public static int GetCountDirFiles(string strDir, string strSearchPattern)
        {
            try
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(strDir);
                System.IO.FileInfo[] f = di.GetFiles(strSearchPattern);
                return f.GetLength(0);
            }
            catch
            {
                return 0;
            }
        }

        // 2016.01.20 by kdi
        /// <summary>
        /// 입력받은 프로세스가 실행중인지 체크한다.
        /// </summary>
        /// <param name="processName">프로세스명(대소문자 구분함)</param>
        /// <returns>실행되고 있으면 : true, 실행되어있지 않으면 : false</returns>
        public static bool CheckProcess(string processName)
        {
            try
            {
                Process[] procs;
                procs = Process.GetProcesses();
                foreach (Process aProc in procs)
                {
                    if (aProc.ProcessName.ToString().Equals(processName))
                    {
                        return true;
                    }
                }
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                throw new Exception(err.Message);
            }
            return false;
        }

        // 2016.01.20
        public static void RunProcess(string strFN, string strWD)
        {
            System.Diagnostics.Process ps = new System.Diagnostics.Process();
            ps.StartInfo.FileName = strFN;
            ps.StartInfo.WorkingDirectory = strWD;
            ps.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            try
            {
                ps.Start();
            }
            catch
            {
            }
            //ps.WaitForExit(1000);
            ps.Dispose();
        }

        // 2019.06.13
        public static void SetGrayscalePalette(Bitmap Image)
        {
            ColorPalette GraycalePalette = Image.Palette;

            for (int i = 0; i < 256; i++)
                GraycalePalette.Entries[i] = Color.FromArgb(i, i, i);
            Image.Palette = GraycalePalette;
        }
        public static Bitmap BitmapToGrayscale(Bitmap source)
        {
            // Create target image.
            int width = source.Width;
            int height = source.Height;
            Bitmap target = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
            // Set the palette to discrete shades of gray
            ColorPalette palette = target.Palette;
            for (int i = 0; i < palette.Entries.Length; i++)
            {
                //palette.Entries[i] = Color.FromArgb(0, i, i, i);
                palette.Entries[i] = Color.FromArgb(i, i, i);
            }
            target.Palette = palette;

            // Lock bits so we have direct access to bitmap data
            BitmapData targetData = target.LockBits(new Rectangle(0, 0, width, height),
                                                    ImageLockMode.ReadWrite, PixelFormat.Format8bppIndexed);
            BitmapData sourceData = source.LockBits(new Rectangle(0, 0, width, height),
                                                    ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            unsafe
            {
                for (int r = 0; r < height; r++)
                {
#if _VS2008
                    byte* pTarget = (byte*)(targetData.Scan0.ToInt32() + r * targetData.Stride);
                    byte* pSource = (byte*)(sourceData.Scan0.ToInt32() + r * sourceData.Stride);
#else
                    byte* pTarget = (byte*)(targetData.Scan0 + r * targetData.Stride);
                    byte* pSource = (byte*)(sourceData.Scan0 + r * sourceData.Stride);                    
#endif
                    for (int c = 0; c < width; c++)
                    {
                        byte colorIndex = (byte)(((*pSource) * 0.3 + *(pSource + 1) * 0.59 + *(pSource + 2) * 0.11));
                        *pTarget = colorIndex;
                        pTarget++;
                        pSource += 3;
                    }
                }
            }

            target.UnlockBits(targetData);
            source.UnlockBits(sourceData);
            return target;
        }

        public static bool ExistFile(string strFName)
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(strFName);
            return fi.Exists;
        }
        public static bool ExistDirectory(string strDName)
        {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(strDName);
            return di.Exists;
        }
    }
}
