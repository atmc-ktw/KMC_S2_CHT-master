using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cognex.VisionPro;
using Cognex.VisionPro.CalibFix;
using System.Collections;
using System.Windows.Forms;

namespace AVisionPro
{
    public class AFixtureNPointToNPoint : ACogToolBase
    {
        private CogFixtureNPointToNPointTool m_cogFixtureNPointToNPointTool = null;

        public AFixtureNPointToNPoint()
        {
            m_cogFixtureNPointToNPointTool = new CogFixtureNPointToNPointTool();
            Init();
        }

        public AFixtureNPointToNPoint(Object oTool)
        {
            m_cogFixtureNPointToNPointTool = oTool as CogFixtureNPointToNPointTool;
            Init();            
        }

        private void Init()
        {
            // 2015.04.08            
            m_cogFixtureNPointToNPointTool.Ran += new EventHandler(RanEvent);
        }

        public CogFixtureNPointToNPointTool GetTool()
        {
            return m_cogFixtureNPointToNPointTool;
        }

        public string Name
        {
            get { return m_cogFixtureNPointToNPointTool.Name; }
            set { m_cogFixtureNPointToNPointTool.Name = (string)value; }
        }

        public ICogImage InputImage
        {
            get { return m_cogFixtureNPointToNPointTool.InputImage; }
            set { m_cogFixtureNPointToNPointTool.InputImage = value; }            
        }

        public ICogImage OutputImage
        {
            get 
            {
                if (m_cogFixtureNPointToNPointTool.Result != null)
                    return m_cogFixtureNPointToNPointTool.Result.OutputImage;
                else
                    return null;
            }
        }

        public ICogImage Run(ICogImage cogImage)
        {
            InputImage = cogImage;

            m_bRan = false;
            m_cogFixtureNPointToNPointTool.Run();

            WaitRanEvent();

            if (m_cogFixtureNPointToNPointTool.Result == null)
                return InputImage;
            else
                return OutputImage;
        }
    }
}
