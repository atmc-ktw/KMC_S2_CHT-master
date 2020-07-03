using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.Windows.Forms;
using System.IO;

using AVisionPro;


namespace Atmc
{
    public class ALogInfo
    {
        public DateTime m_dtDateTime;
        public string m_strData = "";
        public string m_strFileExt = "";
    }

    public class AThrdLogWriter
    {
        private Thread m_Thrd = null;
        public bool m_bTerminated;
        //FrmMain m_PfrmMain = null;
        //IntPtr m_hParent = IntPtr.Zero;
        //private int m_nPoint;

        private string m_strResultPath = "";
        private List<ALogInfo> m_lstLog = new List<ALogInfo>();

        public List<ALogInfo> LogList
        {
            get { return m_lstLog; }
            set { m_lstLog = value; }
        }

        public string ResultPath
        {
            get { return m_strResultPath; }
            set { m_strResultPath = value; }
        }

        public bool Terminated
        {
            get { return m_bTerminated; }
            set
            {
                m_bTerminated = value;
            }
        }

        public AThrdLogWriter()
        {
            m_bTerminated = false;
            m_Thrd = new Thread(new ThreadStart(Run));
            m_Thrd.Priority = ThreadPriority.AboveNormal;
            m_Thrd.Start();
        }

        public AThrdLogWriter(string strResultPath)
        {
            ResultPath = strResultPath;
            m_bTerminated = false;
            m_Thrd = new Thread(new ThreadStart(Run));
            m_Thrd.Priority = ThreadPriority.AboveNormal;
            m_Thrd.Start();
        }

        public void Run()
        {
            while (!m_bTerminated)
            {
                DoWriteLog();
                //2017.01.16
                //AUtil.Delay(1, true);
                Thread.Sleep(1);
            }
            
        }

        public void Close()
        {
            m_bTerminated = true;
            //2017.01.16
            //AUtil.Delay(4, true);
            Thread.Sleep(4);

            m_Thrd.Abort();

            DoWriteLog();            
        }

        public void Clear()
        {
            lock( m_lstLog )
            {
                m_lstLog.Clear();
            }
        }

        public void AddLog(ALogInfo log)
        {
            if (log == null)
                return;

            lock (m_lstLog)
            {
                m_lstLog.Add(log);
            }
        }

        public ALogInfo GetFirstLog()
        {
            ALogInfo log = null;

            lock (m_lstLog)
            {
                if( m_lstLog.Count > 0 )
                {
                    log = m_lstLog[0];
                    m_lstLog.RemoveAt(0);
                }
            }

            return log;
        }

        private void DoWriteLog()
        {
            ALogInfo log = null;

            log = GetFirstLog();
            if (log == null)
                return;

            if( log.m_strFileExt == "" )
            {
                WriteLogFile(log.m_dtDateTime, log.m_strData);
            }
            else
            {
                WriteLogFile(log.m_dtDateTime, log.m_strData, log.m_strFileExt);
            }

            log = null;
        }

        public void WriteLogFile(DateTime date, string strData)
        {
            WriteLogFile(date, strData, ".txt");            
        }

        public void WriteLogFile(DateTime date, string strData, string strExt)
        {
            DateTime dt = date;
            StreamWriter sw = null;
            try
            {
                string strYMD = dt.Year.ToString() + dt.Month.ToString().PadLeft(2, '0');

                string strFName = m_strResultPath;

                strFName += "\\Log";
                strFName += "\\" + dt.ToString("yyyy_MM");
                if (!Directory.Exists(strFName))
                {
                    try
                    {
                        Directory.CreateDirectory(strFName);
                    }
                    catch
                    {
                    }
                }

                // 2014.07.17
                if (strExt.Contains("."))
                    strFName += "\\" + dt.ToString("yyyy_MM_dd") + strExt;
                else
                    strFName += "\\" + dt.ToString("yyyy_MM_dd") + "." + strExt;


                sw = new StreamWriter(strFName, true);
                // 2015.04.27
                if (strExt.Contains("CSV"))
                    sw.WriteLine(dt.ToString("HH:mm:ss") + "  " + strData);
                else
                    sw.WriteLine(dt.ToString("HH:mm:ss.fff") + "  " + strData);
            }
            catch { }
            finally
            {
                if (sw != null)
                {
                    sw.Flush();
                    sw.Close();
                }
            }
        }

    }
}
