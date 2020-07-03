using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using Atmc;
// 2016.06.18
using AVisionPro;

namespace KMC_S2_CHT
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //-------------------------
            // 2번 실행 안 되도록
            string strExe = "KMC_S2_CHT.exe";
            if (!AUtil.IsAppFirstRun(strExe))
            {
                MessageBox.Show("Program(" + strExe + ") is running!", "Program execution", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //-------------------------
            
            // 2016.06.18
            // license check
            AVisionProBuild.CheckLicense("VisionPro.PatMax");
            ExceptionLogger logger = new ExceptionLogger();
            TextFileLogger txtLogger = new TextFileLogger();
            logger.AddLogger(txtLogger);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());
        }                
    }
}
