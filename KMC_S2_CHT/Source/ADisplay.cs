using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Cognex.VisionPro;
using Cognex.VisionPro.Display;

// 2014.09.11
using System.Drawing;

namespace AVisionPro
{
    public class ADisplay        
    {
        public CogDisplay m_cogDisplay = null;
        public string m_strName;

        public CogDisplay Display
        {
            get { return m_cogDisplay; }
            set
            {
                m_cogDisplay = value; 
            }
        }

        public ADisplay(CogDisplay cogDisplay, string strName)
        {
            m_cogDisplay = cogDisplay;
            m_strName = strName;
        }

        public void ClearAll()
        {
            m_cogDisplay.Image = null;
            m_cogDisplay.InteractiveGraphics.Clear();
            m_cogDisplay.StaticGraphics.Clear();
        }

        public void ClearExcludeImage()
        {
            m_cogDisplay.InteractiveGraphics.Clear();
            m_cogDisplay.StaticGraphics.Clear();
        }

        public void ClearImage()
        {
            m_cogDisplay.Image = null;
        }

        public void ClearOverlay()
        {
            m_cogDisplay.InteractiveGraphics.Clear();
        }

        public void ClearStaticGraphic()
        {
            m_cogDisplay.StaticGraphics.Clear();
        }

        public void AddCross()
        {
            // 2011.07.30
            double dHeight;
            double dWidth;
            if (m_cogDisplay.Image != null)
            {
                dHeight = m_cogDisplay.Image.Height;
                dWidth = m_cogDisplay.Image.Width;            
            }
            else
            {
                dHeight = m_cogDisplay.PanYMax;
                dWidth = m_cogDisplay.PanXMax;
            }
            double dHeightCenter = dHeight / 2;
            double dWidthCenter = dWidth / 2;

            // 2011.10.11 "#" 
            AddLine(0, dHeightCenter, dWidth, dHeightCenter, CogColorConstants.Blue, "#");
            AddLine(dWidthCenter, 0, dWidthCenter, dHeight, CogColorConstants.Blue, "#");
        }

        public void AddLine(double dStartX, double dStartY, double dEndX, double dEndY, CogColorConstants color)
        {
            CogLineSegment cogLineSegment = new CogLineSegment();
            cogLineSegment.StartX = dStartX;
            cogLineSegment.StartY = dStartY;
            cogLineSegment.EndX = dEndX;
            cogLineSegment.EndY = dEndY;

            ICogGraphic icogGraphic = cogLineSegment as ICogGraphic;
            icogGraphic.Color = color;
            AddStaticGraphic(icogGraphic, "");
        }

        // 2013.12.22
        public void AddLine(double dX, double dY, double dRotation, CogColorConstants color)
        {
            CogLine cogLine = new CogLine();
            cogLine.X = dX;
            cogLine.Y = dY;
            cogLine.Rotation = dRotation;

            ICogGraphic icogGraphic = cogLine as ICogGraphic;
            icogGraphic.Color = color;
            AddStaticGraphic(icogGraphic, "");
        }

        // 2011.10.11
        public void AddLine(double dStartX, double dStartY, double dEndX, double dEndY, CogColorConstants color, string strSpaceName)
        {
            CogLineSegment cogLineSegment = new CogLineSegment();
            cogLineSegment.StartX = dStartX;
            cogLineSegment.StartY = dStartY;
            cogLineSegment.EndX = dEndX;
            cogLineSegment.EndY = dEndY;

            cogLineSegment.SelectedSpaceName = strSpaceName;

            ICogGraphic icogGraphic = cogLineSegment as ICogGraphic;
            icogGraphic.Color = color;
            AddStaticGraphic(icogGraphic, "");
        }

        // 2013.12.22
        public void AddLine(double dX, double dY, double dRotation, CogColorConstants color, string strSpaceName)
        {
            CogLine cogLine = new CogLine();
            cogLine.X = dX;
            cogLine.Y = dY;
            cogLine.Rotation = dRotation;

            cogLine.SelectedSpaceName = strSpaceName;

            ICogGraphic icogGraphic = cogLine as ICogGraphic;
            icogGraphic.Color = color;
            AddStaticGraphic(icogGraphic, "");
        }

        public void AddTxt(double dX, double dY, string strTxt, CogColorConstants color)
        {
            CogGraphicLabel cogGraphicLabel = new CogGraphicLabel();
            cogGraphicLabel.X = dX;
            cogGraphicLabel.Y = dY;
            cogGraphicLabel.SelectedSpaceName = "#";
            cogGraphicLabel.Alignment = CogGraphicLabelAlignmentConstants.TopLeft;
            cogGraphicLabel.Text = strTxt;

            ICogGraphic icogGraphic = cogGraphicLabel as ICogGraphic;
            icogGraphic.Color = color;
            AddStaticGraphic(icogGraphic, "");
        }

        // 2014.09.11
        public void AddTxt(double dX, double dY, string strTxt, CogColorConstants color, CogColorConstants bkcolor, Font font)
        {
            CogGraphicLabel cogGraphicLabel = new CogGraphicLabel();
            cogGraphicLabel.X = dX;
            cogGraphicLabel.Y = dY;
            cogGraphicLabel.SelectedSpaceName = "#";
            cogGraphicLabel.Alignment = CogGraphicLabelAlignmentConstants.TopLeft;
            cogGraphicLabel.Text = strTxt;
            cogGraphicLabel.BackgroundColor = bkcolor;
            cogGraphicLabel.Font = font;

            ICogGraphic icogGraphic = cogGraphicLabel as ICogGraphic;
            icogGraphic.Color = color;
            AddStaticGraphic(icogGraphic, "");
        }

        // 2013.01.07
        public void AddTxt(double dX, double dY, string strTxt, CogColorConstants color, int nSize)
        {
            CogGraphicLabel cogGraphicLabel = new CogGraphicLabel();
            cogGraphicLabel.X = dX;
            cogGraphicLabel.Y = dY;
            cogGraphicLabel.SelectedSpaceName = "#";
            cogGraphicLabel.Alignment = CogGraphicLabelAlignmentConstants.TopLeft;
            cogGraphicLabel.Text = strTxt;

            // 2013.01.07
            System.Drawing.Font tmpFont = new System.Drawing.Font("Microsoft Sans Serif", nSize);
            cogGraphicLabel.Font = tmpFont;

            ICogGraphic icogGraphic = cogGraphicLabel as ICogGraphic;
            icogGraphic.Color = color;
            AddStaticGraphic(icogGraphic, "");

            tmpFont.Dispose();
        }

        public void AddOverlay(ICogGraphicInteractive icogGraphicInteractive, string strGroupName)
        {
            try
            {
                m_cogDisplay.InteractiveGraphics.Add(icogGraphicInteractive, strGroupName, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AddStaticGraphic(ICogGraphic icogGraphic, string strGroupName)
        {
	        m_cogDisplay.StaticGraphics.Add(icogGraphic, strGroupName);
        }

        public ICogGraphicInteractive GetInteractiveGraphics(string strItemName)
        {
            for(int i=0; i < m_cogDisplay.InteractiveGraphics.Count; ++i)
	        {
                if (m_cogDisplay.InteractiveGraphics[i].TipText == strItemName)
                {
                    return m_cogDisplay.InteractiveGraphics[i];
                }
	        }

	        return null;
        }

        public CogImage8Grey GetImage8Grey()
        {
            if (m_cogDisplay.Image == null)
                return null;

            return CogImageConvert.GetIntensityImage(m_cogDisplay.Image, 0, 0, m_cogDisplay.Image.Width, m_cogDisplay.Image.Height);
        }

        public ICogImage Image
        {
            get { return m_cogDisplay.Image; }
            set { m_cogDisplay.Image = value; }
        }

        public void FitImage()
        {
            m_cogDisplay.Fit(true);
        }

        // 2013.03.28
        public void SetZoom(double dZoom)  // 0~100%
        {
            m_cogDisplay.Zoom = dZoom / 100;
        }
        public void SetPan(double x, double y)  // 이동
        {
            m_cogDisplay.PanX = x;
            m_cogDisplay.PanY = y;
        }
        
        // 2018.04.09
        public void ColorMap_Height()
        {
            m_cogDisplay.ColorMapLoad("c:\\atm\\colormap_Height.xml");
        }

        public void ColorMap_Thermal()
        {
            m_cogDisplay.ColorMapLoad("c:\\atm\\colormap_Thermal.xml");
        }
        public void ColorMap_Clear()
        {
            m_cogDisplay.ClearImage16GreyColorMap();
            m_cogDisplay.ClearImage8GreyColorMap();
            m_cogDisplay.ClearImage16RangeColorMap();
        }

    }
}
