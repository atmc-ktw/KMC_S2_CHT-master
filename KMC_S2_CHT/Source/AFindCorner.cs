using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cognex.VisionPro;
using Cognex.VisionPro.Caliper;
using System.Collections;
using System.Windows.Forms;

namespace AVisionPro
{
    public class AFindCorner : ACogToolBase
    {
        private CogFindCornerTool m_cogFindCornerTool = null;

        // 2014.03.27
        public struct _stResult
        {
            public int nR;

            public double dX;
            public double dY;
            // 2016.11.10
            public double dAngle;
        }
        public _stResult m_stResult;

        public AFindCorner()
        {
            m_cogFindCornerTool = new CogFindCornerTool();
            Init();
        }

        public AFindCorner(Object oTool)
        {
            m_cogFindCornerTool = oTool as CogFindCornerTool;
            Init();            
        }

        private void Init()
        {
            // 2015.04.08            
            m_cogFindCornerTool.Ran += new EventHandler(RanEvent);
        }

        public CogFindCornerTool GetTool()
        {
            return m_cogFindCornerTool;
        }

        public string Name
        {
            get { return m_cogFindCornerTool.Name; }
            set { m_cogFindCornerTool.Name = (string)value; }
        }

        // 2014.03.27
        public ICogImage InputImage
        {
            /*
            get { return m_cogFindCornerTool.InputImage; }
            set { m_cogFindCornerTool.InputImage = value; }            
            */
            get { return m_cogFindCornerTool.InputImage as ICogImage; }
            set { m_cogFindCornerTool.InputImage = value as CogImage8Grey; }
        }

        // 2014.03.27
        public int Run(ADisplay aDisplay)
        {
            m_stResult.dX = 0;
            m_stResult.dY = 0;
            m_stResult.dAngle = 0;

            if (m_cogFindCornerTool != null)
            {
                InputImage = aDisplay.Image;

                // 2015.04.08
                m_bRan = false;

                m_cogFindCornerTool.Run();

                // 2015.04.08
                WaitRanEvent();

                m_stResult.nR = (int)m_cogFindCornerTool.RunStatus.Result;
                // 2014.08.28
                if (m_stResult.nR == 0 && m_cogFindCornerTool.Result.CornerFound == true)
                {
                    m_stResult.dX = m_cogFindCornerTool.Result.CornerX;
                    m_stResult.dY = m_cogFindCornerTool.Result.CornerY;
                    // 2016.11.10
                    m_stResult.dAngle =
                        (m_cogFindCornerTool.Result.LineResultsB.GetLine().Rotation - m_cogFindCornerTool.Result.LineResultsA.GetLine().Rotation)
                         * (180 / Math.PI);
                }
                else
                {
                    m_stResult.nR = -2;
                }
            }
            else
            {
                m_stResult.nR = -1;
            }

            return m_stResult.nR;
        }

        // 2016.11.10 
        public int Run(ICogImage cogImage)
        {
            m_stResult.dX = 0;
            m_stResult.dY = 0;
            m_stResult.dAngle = 0;

            if (m_cogFindCornerTool != null)
            {
                InputImage =  CogImageConvert.GetIntensityImage(cogImage, 0, 0, cogImage.Width, cogImage.Height);

                m_bRan = false;

                m_cogFindCornerTool.Run();

                WaitRanEvent();

                m_stResult.nR = (int)m_cogFindCornerTool.RunStatus.Result;
                if (m_stResult.nR == 0 && m_cogFindCornerTool.Result.CornerFound == true)
                {
                    m_stResult.dX = m_cogFindCornerTool.Result.CornerX;
                    m_stResult.dY = m_cogFindCornerTool.Result.CornerY;
                    m_stResult.dAngle =
                        (m_cogFindCornerTool.Result.LineResultsB.GetLine().Rotation - m_cogFindCornerTool.Result.LineResultsA.GetLine().Rotation)
                         * (180 / Math.PI);
                }
                else
                {
                    m_stResult.nR = -2;
                }
            }
            else
            {
                m_stResult.nR = -1;
            }

            return m_stResult.nR;
        }

        // 2014.03.27
        public int GetResult()
        {
            return m_stResult.nR;  // 0:OK 나머지:NG
        }
    }
}
