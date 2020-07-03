/* 2017.03.23
#define _CHECK_ANGLE
#define _CHECK_SCALE
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cognex.VisionPro;
using Cognex.VisionPro.ToolGroup;
using Atmc;


namespace AVisionPro
{
    public class APMAligns
    {
        private CogToolGroup m_cogtg;
        private APMAlign m_aPMAlign;

        private List<APMAlign> m_lstAPMAlign = new List<APMAlign>();

        public struct _stResult
        {
            public bool bResult;

            public double dX;
            public double dY;
            public double dAngle;
            public double dScore;
            public int nFindIndex;

            // 2017.03.21
            public void Clear()
            {
                bResult = false;
                dX = 0;
                dY = 0;
                dAngle = 0;
                dScore = 0;
                nFindIndex = -1;
            }

            // 2020.03.03
            public CogTransform2DLinear cogTransPose;

        }
        public _stResult m_stResult;

        public struct _stInit
        {
            public double dX;
            public double dY;
            public double dAngle;
        }
        public _stInit m_stInit;


        public APMAligns(string strName)
        {
            m_cogtg = new CogToolGroup();
            m_cogtg.Name = strName;
        }

        public APMAligns(CogToolGroup cogtg)
        {
            m_cogtg = cogtg;

            if (m_cogtg != null)
            {
                for (int i = 0; i < m_cogtg.Tools.Count; ++i)
                {
                    m_aPMAlign = new APMAlign(m_cogtg.Tools[i]);
                    m_lstAPMAlign.Add(m_aPMAlign);                    
                }
            }
        }        
        
        public int GetCount()
        {
            return m_lstAPMAlign.Count;
        }

        public Object GetTool()
        {
            return m_cogtg;
        }

        public Object GetTools()
        {
            return m_lstAPMAlign as Object;
        }

        public APMAlign GetAPMAlign(int nToolIndex)
        {
            if (m_lstAPMAlign.Count > nToolIndex)
                return m_lstAPMAlign[nToolIndex];
            else
                return null;
        }

        public string Name
        {
            get { return m_cogtg.Name; }
            set { m_cogtg.Name = value.ToString(); }
        }

        private void AddTool(Object oTool)
        {
            m_cogtg.Tools.Add(oTool as ICogTool);
        }

        private void RemoveTool(Object oTool)
        {
            m_cogtg.Tools.Remove(oTool as ICogTool);
        }

        public void Add(APMAlign aPMAlign)
        {
            m_aPMAlign = aPMAlign;
            m_lstAPMAlign.Add(m_aPMAlign);
            AddTool(m_aPMAlign.GetTool());
        }

        public void Remove(APMAlign aPMAlign)
        {
            m_aPMAlign = aPMAlign;
            m_lstAPMAlign.Remove(m_aPMAlign);
            RemoveTool(m_aPMAlign.GetTool());
        }

        public int RunPMAlign(ADisplay aDisplay)
        {
            return RunPMAlign(aDisplay, true, true, 0, 0);
        }
        public int RunPMAlign(ADisplay aDisplay, bool bViewTxt)
        {
            return RunPMAlign(aDisplay, bViewTxt, true, 0, 0);
        }
        // 2013.08.24
        public int RunPMAlign(ADisplay aDisplay, bool bViewTxt, bool bShowResult, double dX, double dY)
        {
            int nResultIndex = -1;
            double dResultScore = 0;

            for (int i = 0; i < m_lstAPMAlign.Count; i++)
            {
                if (m_lstAPMAlign[i].Run(aDisplay) > 0)
                {
                    // 2011.04.25
                    //2017.03.15 by kdi. if (m_lstAPMAlign[i].Score > m_lstAPMAlign[i].AcceptThreshold &&
                    if (m_lstAPMAlign[i].Score >= m_lstAPMAlign[i].AcceptThreshold &&
                        m_lstAPMAlign[i].Score > dResultScore &&
                        // 2017.03.23
                        m_lstAPMAlign[i].Result == true)
                    {
                        /* 2017.03.23
                        
                        // 2016.01.29
                        bool bR = true;                        
#if _CHECK_ANGLE
                        if (!(m_lstAPMAlign[i].ZoneAngleLow == 0 && m_lstAPMAlign[i].ZoneAngleHigh == 0))
                        {
                            if (m_lstAPMAlign[i].Angle < m_lstAPMAlign[i].ZoneAngleLow ||
                                m_lstAPMAlign[i].Angle > m_lstAPMAlign[i].ZoneAngleHigh)
                            {
                                bR = false;
                            }
                        }
#endif
#if _CHECK_SCALE
                        if (!(m_lstAPMAlign[i].ZoneScaleLow == 1 && m_lstAPMAlign[i].ZoneScaleHigh == 1))
                        {
                            if (m_lstAPMAlign[i].Scale < m_lstAPMAlign[i].ZoneScaleLow ||
                                m_lstAPMAlign[i].Scale > m_lstAPMAlign[i].ZoneScaleHigh)
                            {
                                bR = false;
                            }
                        }

                        // 2017.03.21
                        if (!(m_lstAPMAlign[i].ZoneScaleX_Low == 1 && m_lstAPMAlign[i].ZoneScaleX_High == 1))
                        {
                            if (m_lstAPMAlign[i].ScaleX < m_lstAPMAlign[i].ZoneScaleX_Low ||
                                m_lstAPMAlign[i].ScaleX > m_lstAPMAlign[i].ZoneScaleX_High)
                            {
                                bR = false;
                            }
                        }
                        if (!(m_lstAPMAlign[i].ZoneScaleY_Low == 1 && m_lstAPMAlign[i].ZoneScaleY_High == 1))
                        {
                            if (m_lstAPMAlign[i].ScaleY < m_lstAPMAlign[i].ZoneScaleY_Low ||
                                m_lstAPMAlign[i].ScaleY > m_lstAPMAlign[i].ZoneScaleY_High)
                            {
                                bR = false;
                            }
                        }

#endif
                        if (bR == true)
                        */
                        {
                            dResultScore = m_lstAPMAlign[i].Score;
                            nResultIndex = i;
                        }
                    }
                }
            }
            if (nResultIndex >= 0)
            {
                // 2014.09.03
                m_lstAPMAlign[nResultIndex].ShowResult(aDisplay, bShowResult);

                m_stResult.dX = m_lstAPMAlign[nResultIndex].X;
                m_stResult.dY = m_lstAPMAlign[nResultIndex].Y;
                m_stResult.dAngle = m_lstAPMAlign[nResultIndex].Angle;
                m_stResult.dScore = m_lstAPMAlign[nResultIndex].Score;
                m_stResult.nFindIndex = nResultIndex;

                m_stResult.bResult = true;

                // 2020.03.03
                m_stResult.cogTransPose = m_lstAPMAlign[nResultIndex].TransPose;

                if (bViewTxt)
                    aDisplay.AddTxt(dX, dY, "PMAlign:OK(" + (nResultIndex+1).ToString() + ":" + Math.Round(m_stResult.dScore*100, 2).ToString() + "%)", CogColorConstants.Green);
            }        
            else
            {
                // 2013.08.24
                if (bShowResult
					// 2018.09.05
                    && m_lstAPMAlign.Count > 0)
				{
                    m_lstAPMAlign[0].ShowSearchRegion(aDisplay);
				}
				
                m_stResult.bResult = false;
                m_stResult.nFindIndex = -1;
                if (bViewTxt)
                    aDisplay.AddTxt(dX, dY, "PMAlign:NG", CogColorConstants.Red);
            }

            return nResultIndex;
        }

        // 2020.03.03
        public int RunPMAlign(ADisplay aDisplay, bool bViewTxt, bool bShowResult, double dX, double dY, string strSelectedSpaceName)
        {
            int nResultIndex = -1;
            double dResultScore = 0;

            for (int i = 0; i < m_lstAPMAlign.Count; i++)
            {
                if (m_lstAPMAlign[i].Run(aDisplay) > 0)
                {
                    // 2011.04.25
                    //2017.03.15 by kdi. if (m_lstAPMAlign[i].Score > m_lstAPMAlign[i].AcceptThreshold &&
                    if (m_lstAPMAlign[i].Score >= m_lstAPMAlign[i].AcceptThreshold &&
                        m_lstAPMAlign[i].Score > dResultScore &&
                        // 2017.03.23
                        m_lstAPMAlign[i].Result == true)
                    {
                        /* 2017.03.23
                        
                        // 2016.01.29
                        bool bR = true;                        
#if _CHECK_ANGLE
                        if (!(m_lstAPMAlign[i].ZoneAngleLow == 0 && m_lstAPMAlign[i].ZoneAngleHigh == 0))
                        {
                            if (m_lstAPMAlign[i].Angle < m_lstAPMAlign[i].ZoneAngleLow ||
                                m_lstAPMAlign[i].Angle > m_lstAPMAlign[i].ZoneAngleHigh)
                            {
                                bR = false;
                            }
                        }
#endif
#if _CHECK_SCALE
                        if (!(m_lstAPMAlign[i].ZoneScaleLow == 1 && m_lstAPMAlign[i].ZoneScaleHigh == 1))
                        {
                            if (m_lstAPMAlign[i].Scale < m_lstAPMAlign[i].ZoneScaleLow ||
                                m_lstAPMAlign[i].Scale > m_lstAPMAlign[i].ZoneScaleHigh)
                            {
                                bR = false;
                            }
                        }

                        // 2017.03.21
                        if (!(m_lstAPMAlign[i].ZoneScaleX_Low == 1 && m_lstAPMAlign[i].ZoneScaleX_High == 1))
                        {
                            if (m_lstAPMAlign[i].ScaleX < m_lstAPMAlign[i].ZoneScaleX_Low ||
                                m_lstAPMAlign[i].ScaleX > m_lstAPMAlign[i].ZoneScaleX_High)
                            {
                                bR = false;
                            }
                        }
                        if (!(m_lstAPMAlign[i].ZoneScaleY_Low == 1 && m_lstAPMAlign[i].ZoneScaleY_High == 1))
                        {
                            if (m_lstAPMAlign[i].ScaleY < m_lstAPMAlign[i].ZoneScaleY_Low ||
                                m_lstAPMAlign[i].ScaleY > m_lstAPMAlign[i].ZoneScaleY_High)
                            {
                                bR = false;
                            }
                        }

#endif
                        if (bR == true)
                        */
                        {
                            dResultScore = m_lstAPMAlign[i].Score;
                            nResultIndex = i;
                        }
                    }
                }
            }
            if (nResultIndex >= 0)
            {
                // 2014.09.03
                m_lstAPMAlign[nResultIndex].ShowResult(aDisplay, bShowResult, strSelectedSpaceName);

                m_stResult.dX = m_lstAPMAlign[nResultIndex].X;
                m_stResult.dY = m_lstAPMAlign[nResultIndex].Y;
                m_stResult.dAngle = m_lstAPMAlign[nResultIndex].Angle;
                m_stResult.dScore = m_lstAPMAlign[nResultIndex].Score;
                m_stResult.nFindIndex = nResultIndex;

                m_stResult.bResult = true;

                // 2020.03.03
                m_stResult.cogTransPose = m_lstAPMAlign[nResultIndex].TransPose;

                if (bViewTxt)
                    aDisplay.AddTxt(dX, dY, "PMAlign:OK(" + (nResultIndex + 1).ToString() + ":" + Math.Round(m_stResult.dScore * 100, 2).ToString() + "%)", CogColorConstants.Green);
            }
            else
            {
                // 2013.08.24
                if (bShowResult
                    // 2018.09.05
                    && m_lstAPMAlign.Count > 0)
                {
                    m_lstAPMAlign[0].ShowSearchRegion(aDisplay, strSelectedSpaceName);
                }

                m_stResult.bResult = false;
                m_stResult.nFindIndex = -1;
                if (bViewTxt)
                    aDisplay.AddTxt(dX, dY, "PMAlign:NG", CogColorConstants.Red);
            }

            return nResultIndex;
        }

        // 2014.08.27
        public int RunPMAlign(ADisplay aDisplay, bool bViewTxt, bool bShowResult, double dX, double dY, 
            double dSearchRegionX, double dSearchRegionY, 
            double dMoveX, double dMoveY)
        {
            int nResultIndex = -1;
            double dResultScore = 0;

            for (int i = 0; i < m_lstAPMAlign.Count; i++)
            {
                m_lstAPMAlign[i].SetInitSearchRegion(dSearchRegionX, dSearchRegionY);
                m_lstAPMAlign[i].MoveSearchRegion(dMoveX, dMoveY);
                
                if (m_lstAPMAlign[i].Run(aDisplay) > 0)
                {
                    // 2017.03.23
                    // 2011.04.25
                    //if (m_lstAPMAlign[i].Score > m_lstAPMAlign[i].AcceptThreshold &&
                    if (m_lstAPMAlign[i].Score >= m_lstAPMAlign[i].AcceptThreshold &&
                        m_lstAPMAlign[i].Score > dResultScore &&
                        // 2017.03.23
                        m_lstAPMAlign[i].Result == true)
                    {
                        /* 2017.03.23
                        // 2016.01.29
                        bool bR = true;
#if _CHECK_ANGLE
                        if (!(m_lstAPMAlign[i].ZoneAngleLow == 0 && m_lstAPMAlign[i].ZoneAngleHigh == 0))
                        {
                            if (m_lstAPMAlign[i].Angle < m_lstAPMAlign[i].ZoneAngleLow ||
                                m_lstAPMAlign[i].Angle > m_lstAPMAlign[i].ZoneAngleHigh)
                            {
                                bR = false;
                            }
                        }
#endif
#if _CHECK_SCALE
                        if (!(m_lstAPMAlign[i].ZoneScaleLow == 1 && m_lstAPMAlign[i].ZoneScaleHigh == 1))
                        {
                            if (m_lstAPMAlign[i].Scale < m_lstAPMAlign[i].ZoneScaleLow ||
                                m_lstAPMAlign[i].Scale > m_lstAPMAlign[i].ZoneScaleHigh)
                            {
                                bR = false;
                            }
                        }

                        // 2017.03.21
                        if (!(m_lstAPMAlign[i].ZoneScaleX_Low == 1 && m_lstAPMAlign[i].ZoneScaleX_High == 1))
                        {
                            if (m_lstAPMAlign[i].ScaleX < m_lstAPMAlign[i].ZoneScaleX_Low ||
                                m_lstAPMAlign[i].ScaleX > m_lstAPMAlign[i].ZoneScaleX_High)
                            {
                                bR = false;
                            }
                        }
                        if (!(m_lstAPMAlign[i].ZoneScaleY_Low == 1 && m_lstAPMAlign[i].ZoneScaleY_High == 1))
                        {
                            if (m_lstAPMAlign[i].ScaleY < m_lstAPMAlign[i].ZoneScaleY_Low ||
                                m_lstAPMAlign[i].ScaleY > m_lstAPMAlign[i].ZoneScaleY_High)
                            {
                                bR = false;
                            }
                        }

#endif
                        if (bR == true)
                        */

                        {
                            dResultScore = m_lstAPMAlign[i].Score;
                            nResultIndex = i;
                        }
                    }
                }
            }
            if (nResultIndex >= 0)
            {
                // 2014.09.03
                m_lstAPMAlign[nResultIndex].ShowResult(aDisplay, bShowResult);

                m_stResult.dX = m_lstAPMAlign[nResultIndex].X;
                m_stResult.dY = m_lstAPMAlign[nResultIndex].Y;
                m_stResult.dAngle = m_lstAPMAlign[nResultIndex].Angle;
                m_stResult.dScore = m_lstAPMAlign[nResultIndex].Score;
                m_stResult.nFindIndex = nResultIndex;

                m_stResult.bResult = true;

                // 2020.03.03
                m_stResult.cogTransPose = m_lstAPMAlign[nResultIndex].TransPose;

                if (bViewTxt)
                    aDisplay.AddTxt(dX, dY, "PMAlign:OK(" + (nResultIndex + 1).ToString() + ":" + Math.Round(m_stResult.dScore * 100, 2).ToString() + "%)", CogColorConstants.Green);
            }
            else
            {
                if (bShowResult
                    // 2018.09.05
                    && m_lstAPMAlign.Count > 0)
                {
                    m_lstAPMAlign[0].ShowSearchRegion(aDisplay);
                }

                m_stResult.bResult = false;
                m_stResult.nFindIndex = -1;
                if (bViewTxt)
                    aDisplay.AddTxt(dX, dY, "PMAlign:NG", CogColorConstants.Red);
            }

            return nResultIndex;
        }

        // 2015.10.18 ----------------------------------------------------------
        public int RunPMAlign(ADisplay aDisplay, ICogImage cogImage)
        {
            return RunPMAlign(aDisplay, true, true, 0, 0, cogImage);
        }
        public int RunPMAlign(ADisplay aDisplay, bool bViewTxt, ICogImage cogImage)
        {
            return RunPMAlign(aDisplay, bViewTxt, true, 0, 0, cogImage);
        }
        public int RunPMAlign(ADisplay aDisplay, bool bViewTxt, bool bShowResult, double dX, double dY, ICogImage cogImage)
        {
            int nResultIndex = -1;
            double dResultScore = 0;

            for (int i = 0; i < m_lstAPMAlign.Count; i++)
            {
                if (m_lstAPMAlign[i].Run(cogImage) > 0)
                {
                    // 2017.03.23
                    // 2011.04.25
                    //if (m_lstAPMAlign[i].Score > m_lstAPMAlign[i].AcceptThreshold &&
                    if (m_lstAPMAlign[i].Score >= m_lstAPMAlign[i].AcceptThreshold &&
                        m_lstAPMAlign[i].Score > dResultScore &&
                        // 2017.03.23
                        m_lstAPMAlign[i].Result == true)
                    {
                        /* 2017.03.23
                        // 2016.01.29
                        bool bR = true;
#if _CHECK_ANGLE
                        if (!(m_lstAPMAlign[i].ZoneAngleLow == 0 && m_lstAPMAlign[i].ZoneAngleHigh == 0))
                        {
                            if (m_lstAPMAlign[i].Angle < m_lstAPMAlign[i].ZoneAngleLow ||
                                m_lstAPMAlign[i].Angle > m_lstAPMAlign[i].ZoneAngleHigh)
                            {
                                bR = false;
                            }
                        }
#endif
#if _CHECK_SCALE
                        if (!(m_lstAPMAlign[i].ZoneScaleLow == 1 && m_lstAPMAlign[i].ZoneScaleHigh == 1))
                        {
                            if (m_lstAPMAlign[i].Scale < m_lstAPMAlign[i].ZoneScaleLow ||
                                m_lstAPMAlign[i].Scale > m_lstAPMAlign[i].ZoneScaleHigh)
                            {
                                bR = false;
                            }
                        }

                        // 2017.03.21
                        if (!(m_lstAPMAlign[i].ZoneScaleX_Low == 1 && m_lstAPMAlign[i].ZoneScaleX_High == 1))
                        {
                            if (m_lstAPMAlign[i].ScaleX < m_lstAPMAlign[i].ZoneScaleX_Low ||
                                m_lstAPMAlign[i].ScaleX > m_lstAPMAlign[i].ZoneScaleX_High)
                            {
                                bR = false;
                            }
                        }
                        if (!(m_lstAPMAlign[i].ZoneScaleY_Low == 1 && m_lstAPMAlign[i].ZoneScaleY_High == 1))
                        {
                            if (m_lstAPMAlign[i].ScaleY < m_lstAPMAlign[i].ZoneScaleY_Low ||
                                m_lstAPMAlign[i].ScaleY > m_lstAPMAlign[i].ZoneScaleY_High)
                            {
                                bR = false;
                            }
                        }

#endif
                        if (bR == true)
                        */

                        {
                            dResultScore = m_lstAPMAlign[i].Score;
                            nResultIndex = i;
                        }
                    }
                }
            }
            if (nResultIndex >= 0)
            {
                // 2014.09.03
                m_lstAPMAlign[nResultIndex].ShowResult(aDisplay, bShowResult);

                m_stResult.dX = m_lstAPMAlign[nResultIndex].X;
                m_stResult.dY = m_lstAPMAlign[nResultIndex].Y;
                m_stResult.dAngle = m_lstAPMAlign[nResultIndex].Angle;
                m_stResult.dScore = m_lstAPMAlign[nResultIndex].Score;
                m_stResult.nFindIndex = nResultIndex;

                m_stResult.bResult = true;

                // 2020.03.03
                m_stResult.cogTransPose = m_lstAPMAlign[nResultIndex].TransPose;

                if (bViewTxt)
                    aDisplay.AddTxt(dX, dY, "PMAlign:OK(" + (nResultIndex + 1).ToString() + ":" + Math.Round(m_stResult.dScore * 100, 2).ToString() + "%)", CogColorConstants.Green);
            }
            else
            {
                // 2013.08.24
                if (bShowResult
                    // 2018.09.05
                    && m_lstAPMAlign.Count > 0)
                {
                    m_lstAPMAlign[0].ShowSearchRegion(aDisplay);
                }

                m_stResult.bResult = false;
                m_stResult.nFindIndex = -1;
                if (bViewTxt)
                    aDisplay.AddTxt(dX, dY, "PMAlign:NG", CogColorConstants.Red);
            }

            return nResultIndex;
        }

        public int RunPMAlign(ADisplay aDisplay, bool bViewTxt, bool bShowResult, double dX, double dY,
            double dSearchRegionX, double dSearchRegionY,
            double dMoveX, double dMoveY, ICogImage cogImage)
        {
            int nResultIndex = -1;
            double dResultScore = 0;

            for (int i = 0; i < m_lstAPMAlign.Count; i++)
            {
                m_lstAPMAlign[i].SetInitSearchRegion(dSearchRegionX, dSearchRegionY);
                m_lstAPMAlign[i].MoveSearchRegion(dMoveX, dMoveY);

                if (m_lstAPMAlign[i].Run(cogImage) > 0)
                {
                    // 2017.03.23
                    // 2011.04.25
                    //if (m_lstAPMAlign[i].Score > m_lstAPMAlign[i].AcceptThreshold &&
                    if (m_lstAPMAlign[i].Score >= m_lstAPMAlign[i].AcceptThreshold &&
                        m_lstAPMAlign[i].Score > dResultScore &&
                        // 2017.03.23
                        m_lstAPMAlign[i].Result == true)
                    {
                        /* 2017.03.23
                        // 2016.01.29
                        bool bR = true;
#if _CHECK_ANGLE
                        if (!(m_lstAPMAlign[i].ZoneAngleLow == 0 && m_lstAPMAlign[i].ZoneAngleHigh == 0))
                        {
                            if (m_lstAPMAlign[i].Angle < m_lstAPMAlign[i].ZoneAngleLow ||
                                m_lstAPMAlign[i].Angle > m_lstAPMAlign[i].ZoneAngleHigh)
                            {
                                bR = false;
                            }
                        }
#endif
#if _CHECK_SCALE
                        if (!(m_lstAPMAlign[i].ZoneScaleLow == 1 && m_lstAPMAlign[i].ZoneScaleHigh == 1))
                        {
                            if (m_lstAPMAlign[i].Scale < m_lstAPMAlign[i].ZoneScaleLow ||
                                m_lstAPMAlign[i].Scale > m_lstAPMAlign[i].ZoneScaleHigh)
                            {
                                bR = false;
                            }
                        }

                        // 2017.03.21
                        if (!(m_lstAPMAlign[i].ZoneScaleX_Low == 1 && m_lstAPMAlign[i].ZoneScaleX_High == 1))
                        {
                            if (m_lstAPMAlign[i].ScaleX < m_lstAPMAlign[i].ZoneScaleX_Low ||
                                m_lstAPMAlign[i].ScaleX > m_lstAPMAlign[i].ZoneScaleX_High)
                            {
                                bR = false;
                            }
                        }
                        if (!(m_lstAPMAlign[i].ZoneScaleY_Low == 1 && m_lstAPMAlign[i].ZoneScaleY_High == 1))
                        {
                            if (m_lstAPMAlign[i].ScaleY < m_lstAPMAlign[i].ZoneScaleY_Low ||
                                m_lstAPMAlign[i].ScaleY > m_lstAPMAlign[i].ZoneScaleY_High)
                            {
                                bR = false;
                            }
                        }

#endif
                        if (bR == true)
                        */
                        {
                            dResultScore = m_lstAPMAlign[i].Score;
                            nResultIndex = i;
                        }
                    }
                }
            }
            if (nResultIndex >= 0)
            {
                // 2014.09.03
                m_lstAPMAlign[nResultIndex].ShowResult(aDisplay, bShowResult);

                m_stResult.dX = m_lstAPMAlign[nResultIndex].X;
                m_stResult.dY = m_lstAPMAlign[nResultIndex].Y;
                m_stResult.dAngle = m_lstAPMAlign[nResultIndex].Angle;
                m_stResult.dScore = m_lstAPMAlign[nResultIndex].Score;
                m_stResult.nFindIndex = nResultIndex;

                m_stResult.bResult = true;

                // 2020.03.03
                m_stResult.cogTransPose = m_lstAPMAlign[nResultIndex].TransPose;

                if (bViewTxt)
                    aDisplay.AddTxt(dX, dY, "PMAlign:OK(" + (nResultIndex + 1).ToString() + ":" + Math.Round(m_stResult.dScore * 100, 2).ToString() + "%)", CogColorConstants.Green);
            }
            else
            {
                if (bShowResult
                    // 2018.09.05
                    && m_lstAPMAlign.Count > 0)
                {
                    m_lstAPMAlign[0].ShowSearchRegion(aDisplay);
                }

                m_stResult.bResult = false;
                m_stResult.nFindIndex = -1;
                if (bViewTxt)
                    aDisplay.AddTxt(dX, dY, "PMAlign:NG", CogColorConstants.Red);
            }

            return nResultIndex;
        }
        //---------------------------------------------------------

        // 2017.03.21
        public int RunPMAlign(ICogImage cogImage)
        {
            int nResultIndex = -1;
            double dResultScore = 0;

            for (int i = 0; i < m_lstAPMAlign.Count; i++)
            {
                if (m_lstAPMAlign[i].Run(cogImage) > 0)
                {
                    // 2017.03.23
                    //if (m_lstAPMAlign[i].Score > m_lstAPMAlign[i].AcceptThreshold &&
                    if (m_lstAPMAlign[i].Score >= m_lstAPMAlign[i].AcceptThreshold &&
                        m_lstAPMAlign[i].Score > dResultScore &&
                        // 2017.03.23
                        m_lstAPMAlign[i].Result == true)
                    {
                        /* 2017.03.23
                        bool bR = true;
#if _CHECK_ANGLE
                        if (!(m_lstAPMAlign[i].ZoneAngleLow == 0 && m_lstAPMAlign[i].ZoneAngleHigh == 0))
                        {
                            if (m_lstAPMAlign[i].Angle < m_lstAPMAlign[i].ZoneAngleLow ||
                                m_lstAPMAlign[i].Angle > m_lstAPMAlign[i].ZoneAngleHigh)
                            {
                                bR = false;
                            }
                        }
#endif
#if _CHECK_SCALE
                        if (!(m_lstAPMAlign[i].ZoneScaleLow == 1 && m_lstAPMAlign[i].ZoneScaleHigh == 1))
                        {
                            if (m_lstAPMAlign[i].Scale < m_lstAPMAlign[i].ZoneScaleLow ||
                                m_lstAPMAlign[i].Scale > m_lstAPMAlign[i].ZoneScaleHigh)
                            {
                                bR = false;
                            }
                        }
                        // 2017.03.21
                        if (!(m_lstAPMAlign[i].ZoneScaleX_Low == 1 && m_lstAPMAlign[i].ZoneScaleX_High == 1))
                        {
                            if (m_lstAPMAlign[i].ScaleX < m_lstAPMAlign[i].ZoneScaleX_Low ||
                                m_lstAPMAlign[i].ScaleX > m_lstAPMAlign[i].ZoneScaleX_High)
                            {
                                bR = false;
                            }
                        }
                        if (!(m_lstAPMAlign[i].ZoneScaleY_Low == 1 && m_lstAPMAlign[i].ZoneScaleY_High == 1))
                        {
                            if (m_lstAPMAlign[i].ScaleY < m_lstAPMAlign[i].ZoneScaleY_Low ||
                                m_lstAPMAlign[i].ScaleY > m_lstAPMAlign[i].ZoneScaleY_High)
                            {
                                bR = false;
                            }
                        }

#endif
                        if (bR == true)
                        */

                        {
                            dResultScore = m_lstAPMAlign[i].Score;
                            nResultIndex = i;
                        }
                    }
                }
            }
            if (nResultIndex >= 0)
            {
                m_stResult.dX = m_lstAPMAlign[nResultIndex].X;
                m_stResult.dY = m_lstAPMAlign[nResultIndex].Y;
                m_stResult.dAngle = m_lstAPMAlign[nResultIndex].Angle;
                m_stResult.dScore = m_lstAPMAlign[nResultIndex].Score;
                m_stResult.nFindIndex = nResultIndex;

                m_stResult.bResult = true;

                // 2020.03.03
                m_stResult.cogTransPose = m_lstAPMAlign[nResultIndex].TransPose;

            }
            else
            {
                m_stResult.bResult = false;
                m_stResult.nFindIndex = -1;
            }

            return nResultIndex;
        }

        // 2015.04.22
        public void SetTimeOut(double dT)
        {
            for (int i = 0; i < m_lstAPMAlign.Count; i++)
            {
                m_lstAPMAlign[i].TimeoutEnabled = true;
                m_lstAPMAlign[i].TimeOut = dT;
            }
        }
    }
}
