using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Diagnostics;
using AVisionPro;
using System.ComponentModel;

namespace Atmc
{   
    
    public class AFile
    {
        // 2011.04.12 마cto
        private static bool m_bRun = false;

        // 2015.04.10
        //Thread m_Thread;

        int m_nOk, m_nNg, m_nLog;
        // 2011.08.17
        int m_nTotalOK, m_nTotalNG;
        public string m_strTime;

        // 2015.02.08
        public AFile()
        {
            Init(100);
        }

        // 2015.02.08
        public AFile(float fFreeHDD_Percent)
        {
            Init(fFreeHDD_Percent);
        }

        // 2015.02.08
        private void Init(float fFreeHDD_Percent)
        {
            StringBuilder sb = new StringBuilder(16);

            // 2013.10.01
            AUtil.GetPrivateProfileString("DelTime", "OK", "30", sb, 5, ASDef._INI_FILE);
            m_nOk = Convert.ToInt32(sb.ToString());
            // 2013.10.01
            AUtil.GetPrivateProfileString("DelTime", "NG", "30", sb, 5, ASDef._INI_FILE);
            m_nNg = Convert.ToInt32(sb.ToString());
            // 2011.08.17
            AUtil.GetPrivateProfileString("DelTime", "TOTAL_OK", "30", sb, 5, ASDef._INI_FILE);
            m_nTotalOK = Convert.ToInt32(sb.ToString());
            AUtil.GetPrivateProfileString("DelTime", "TOTAL_NG", "30", sb, 5, ASDef._INI_FILE);
            m_nTotalNG = Convert.ToInt32(sb.ToString());
            AUtil.GetPrivateProfileString("DelTime", "LOG", "30", sb, 5, ASDef._INI_FILE);
            m_nLog = Convert.ToInt32(sb.ToString());
            AUtil.GetPrivateProfileString("DelTime", "TIME", "11:10", sb, 6, ASDef._INI_FILE);
            m_strTime = sb.ToString();

            // 2015.02.08
            if (fFreeHDD_Percent < 10)
            {
                m_nOk = 2;
                m_nNg = 2;
                m_nTotalOK = 2;
                m_nTotalNG = 2;
                m_nLog = 2;
            }

            // 2015.04.10
            //m_Thread = new Thread(new ThreadStart(Run));
            BackgroundWorker backWorker = new BackgroundWorker();
            backWorker.DoWork += TaskDeleteFolder;
            backWorker.RunWorkerAsync();
        }

        public void TaskDeleteFolder(object sender, DoWorkEventArgs e)
        {
            Run();
        }

        // 2015.03.16
        private void DelFolder(string strDateFolder, int nDay)
        {
            int n = 0, i = 0;
            DirectoryInfo folerPath, folerSubPath;
            try
            {
                folerPath = new DirectoryInfo(strDateFolder);
                if (folerPath.Exists == true)
                {
                    foreach (DirectoryInfo di in folerPath.GetDirectories())
                    {
                        i = di.LastWriteTime.CompareTo(DateTime.Now.AddDays(-(nDay)));

                        folerSubPath = new DirectoryInfo(di.FullName);
                        if (folerSubPath.Exists == true)
                        {
                            foreach (DirectoryInfo subdi in folerSubPath.GetDirectories())
                            {
                                n = subdi.LastWriteTime.CompareTo(DateTime.Now.AddDays(-(nDay)));
                                if (n <= 0)
                                {
                                    foreach (FileInfo fi in subdi.GetFiles())
                                    {
                                        if ((fi.Attributes & FileAttributes.ReadOnly) > 0)
                                        {
                                            fi.Attributes = FileAttributes.Normal;
                                        }
                                    }
                                    try
                                    {
                                        subdi.Delete(true);
                                    }
                                    catch
                                    {
                                        Process[] procs = Process.GetProcessesByName("explorer");

                                        foreach (Process proc in procs)
                                        {
                                            proc.Kill();
                                        }
                                        continue;
                                    }
                                }
                            }


                        }
                        try
                        {
                            if (i <= 0)
                            {
                                di.Delete(true);
                            }
                        }
                        catch
                        {
                            Process[] procs = Process.GetProcessesByName("explorer");

                            foreach (Process proc in procs)
                            {
                                proc.Kill();
                            }
                            continue;
                        }
                    }

                }
            }
            catch { }
        }

        // 2015.03.16
        public void DelFolderAll()
        {
            DelFolder(AVisionProBuild.m_strResultPath + "\\OK\\", m_nOk);
            DelFolder(AVisionProBuild.m_strResultPath + "\\NG\\", m_nNg);
            
            DelFolder(AVisionProBuild.m_strResultPath + "\\TotalOK\\", m_nTotalOK);
            DelFolder(AVisionProBuild.m_strResultPath + "\\TotalNG\\", m_nTotalNG);
            DelFolder(AVisionProBuild.m_strResultPath + "\\TotalOK1\\", m_nTotalOK);
            DelFolder(AVisionProBuild.m_strResultPath + "\\TotalPass\\", m_nTotalNG);
            
            DelFolder(AVisionProBuild.m_strResultPath + "\\LOG\\", m_nLog);
        }

        /*
        public void Start()
        {
            m_Thread.Start();
        }
        public void Stop()
        {
            // 2015.03.16
            //Thread.Sleep(1000);
            AUtil.Delay(1000, true);

            m_Thread.Abort();
        }
        */

        private void Run()
        {
            // 2011.04.12 마cto
            if (m_strTime == DateTime.Now.ToString("HH:mm") && m_bRun == false)
            {
                m_bRun = true;
                DelFolderAll();
                m_bRun = false;
            }

        }
    }
}