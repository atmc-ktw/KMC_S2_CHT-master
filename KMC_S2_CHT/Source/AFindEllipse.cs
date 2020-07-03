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
    // 2014.08.28
    public class AFindEllipse : ACogToolBase
    {
        private CogFindEllipseTool m_cogFindEllipseTool = null;

        // 2014.03.27
        public struct _stResult
        {
            public int nR;

            public double dX;
            public double dY;
            public double dRadiusX;
            public double dRadiusY;
        }
        public _stResult m_stResult;

        public AFindEllipse()
        {
            m_cogFindEllipseTool = new CogFindEllipseTool();
            Init();
        }

        public AFindEllipse(Object oTool)
        {
            m_cogFindEllipseTool = oTool as CogFindEllipseTool;
            Init();            
        }

        private void Init()
        {
            // 2015.04.08            
            m_cogFindEllipseTool.Ran += new EventHandler(RanEvent);
        }

        public CogFindEllipseTool GetTool()
        {
            return m_cogFindEllipseTool;
        }

        public string Name
        {
            get { return m_cogFindEllipseTool.Name; }
            set { m_cogFindEllipseTool.Name = (string)value; }
        }

        public ICogImage InputImage
        {
            /*
            get { return m_cogFindEllipseTool.InputImage; }
            set { m_cogFindEllipseTool.InputImage = value; }            
            */
            get { return m_cogFindEllipseTool.InputImage as ICogImage; }
            set { m_cogFindEllipseTool.InputImage = value as CogImage8Grey; }
        }

        public int Run(ADisplay aDisplay)
        {
            m_stResult.dX = 0;
            m_stResult.dY = 0;
            m_stResult.dRadiusX = 0;
            m_stResult.dRadiusY = 0;

            if (m_cogFindEllipseTool != null)
            {
                InputImage = aDisplay.Image;
                
                // 2015.04.08
                m_bRan = false;

                m_cogFindEllipseTool.Run();

                // 2015.04.08
                WaitRanEvent();

                m_stResult.nR = (int)m_cogFindEllipseTool.RunStatus.Result;
                if (m_stResult.nR == 0 && m_cogFindEllipseTool.Results.GetEllipse() != null)
                {
                    m_stResult.dX = m_cogFindEllipseTool.Results.GetEllipse().CenterX;
                    m_stResult.dY = m_cogFindEllipseTool.Results.GetEllipse().CenterY;
                    m_stResult.dRadiusX = m_cogFindEllipseTool.Results.GetEllipse().RadiusX;
                    m_stResult.dRadiusY = m_cogFindEllipseTool.Results.GetEllipse().RadiusY;
                }
                else
                {
                    m_stResult.nR = -2;
                }
            }
            else
            {
                m_stResult.nR = 2;
            }

            return m_stResult.nR;
        }
    
        public int GetResult()
        {
            return m_stResult.nR;  // 0:OK 나머지:NG
        }
    }
}
