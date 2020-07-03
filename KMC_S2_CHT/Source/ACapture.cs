using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

// 2016.07.04
using AVisionPro;

namespace Atmc
{
	public class Capture
	{
        public static void SaveJPG(string strFile, Form form)
        {
            // 2014.12.16
            try
            {
                Image img = new Bitmap(form.Size.Width, form.Size.Height);
                Graphics g = Graphics.FromImage(img);
                try
                {

                    g.CopyFromScreen(form.Location.X, form.Location.Y, 0, 0, form.Size);

                    img.Save(strFile);
                    g.Dispose();
                }
                catch (Exception ex)
                {
                    // 2016.07.04
                    AVisionProBuild.WriteLogFile("SaveJpg Err (" + strFile + ")" + ex.Message, ".Err.txt");
                }
                // 2013.11.22
                finally
                {
                    if (g != null)
                    {
                        g.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                // 2016.07.04
                AVisionProBuild.WriteLogFile("SaveJpg Err (" + strFile + ")" + ex.Message, ".Err.txt");
            }
        }

        // 2014.01.13
        public static void SaveJPG(string strFile, Form form, int nWidth, int nHeight)
        {
            // 2014.12.16
            try
            {
                Image img = new Bitmap(nWidth, nHeight);
                Graphics g = Graphics.FromImage(img);
                
                try
                {                    
                    Size TmpSize = new Size(nWidth, nHeight);
                    g.CopyFromScreen(form.Location.X, form.Location.Y, 0, 0, TmpSize);

                    img.Save(strFile);
                    g.Dispose();
                }
                catch (Exception ex)
                {
                    // 2016.07.04
                    AVisionProBuild.WriteLogFile("SaveJpg Err (" + strFile + ")" + ex.Message, ".Err.txt");
                }
                // 2013.11.22
                finally
                {
                    if (g != null)
                    {
                        g.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                // 2016.07.04
                AVisionProBuild.WriteLogFile("SaveJpg Err (" + strFile + ")" + ex.Message, ".Err.txt");
            }
        }
	}
}
