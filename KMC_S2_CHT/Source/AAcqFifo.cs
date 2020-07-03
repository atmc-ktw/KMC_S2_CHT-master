//#define _USE_TRIGGER_ACQ

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cognex.VisionPro;
using Cognex.VisionPro.Display;
using System.Windows.Forms;
// 2011.07.07
using Cognex.VisionPro.ImageProcessing;
// 2011.07.29
using Cognex.VisionPro.ImageFile;
using System.IO;
// 2011.07.30
using Cognex.VisionPro.Exceptions;
using Atmc;
using System.Drawing;

namespace AVisionPro
{
    public class AAcqFifo : ACogToolBase
    {
        public const int _WM_ACQFIFO_COMPLETE = ASDef._WM_USER + 99;
        public const int _WM_ACQFIFO_COMPLETE_NG = ASDef._WM_USER + 100;

        public const int _WM_CACQFIFO_COMPLETE_NG = ASDef._WM_USER + 100;

        // 2017.11.16 by kdi
        public const string _CONST_CAMERA_DISCONNECTION_MESSAGE = "Unable to communicate with camera";
        public const string _CONST_CAMERA_DISCONNECTION_MESSAGE2 = "Acquisition halted due to network problem";
        public const string _CONST_CAMERA_DISCONNECTION_MESSAGE3 = "ccGigEVisionCamera::NetworkError";


        private CogAcqFifoTool m_cogAcqFifoTool = null;
        public CogAcqFifoTool cogAcqFifoTool
        {
            get { return m_cogAcqFifoTool; }
            set { m_cogAcqFifoTool = value; }
        }
        private static CogImageFile m_cogImageFile = new CogImageFile();

        
        // 2011.07.30
        //private ICogAcqTrigger m_cogAcqTrigger = null;
        public ICogAcqTrigger m_cogAcqTrigger = null;

        // 2014.12.16
        //public ADisplay m_aDisplayTrigger = null;
        public ICogImage m_cogImageTrigger = null;

        private int m_nNumAqcs = 0;
        private IntPtr m_hMain;
        public IntPtr MainFrameHandle
        {
            get { return m_hMain; }
            set { m_hMain = value; }
        }
        private int m_nPoint = 0;

        private int m_nSection = 0;
        private int m_nAcqCount = 0;
        private int m_nCompleteCount = 0;


        //** 2016.02.22 by kdi
        private string m_strError = "";

        public string ErrorMessage
        {
            get { return m_strError; }
            set { m_strError = value; }
        }
        //*/

        public AAcqFifo()
        {
            m_cogAcqFifoTool = new CogAcqFifoTool();
            m_cogAcqFifoTool.Name = "AcquireFifo";
            // 2015.04.08
            Init();
        }

        public AAcqFifo(Object oTool)
        {
            m_cogAcqFifoTool = oTool as CogAcqFifoTool;
            // 2015.04.08
            Init();
        }

        // 2015.04.08            
        private void Init()
        {
            m_cogAcqFifoTool.Ran += new EventHandler(RanEvent);
        }

        public void StopLiveAcquisition(CogDisplay cogDisplay)
        {
            cogDisplay.StopLiveDisplay();
        }

        // 2012.04.24
        public string GetFrameGrabberName()
        {
            // 2015.04.02
            try
            {
                return m_cogAcqFifoTool.Operator.FrameGrabber.Name;
                
            }
            catch
            {
                return "";
            }                
        }
        public double Exposure
        {
            get 
            {
                // 2015.04.02
                try
                {
					/* 2015.10.18
                    // 2013.03.28
                    if (GetFrameGrabberName().Contains("acA2500"))
                    {
                        string strVal = GetGigE_Feature("ExposureTimeRaw");
                        return Convert.ToDouble(strVal);
                    }
                    else
					*/
                    {

                        return m_cogAcqFifoTool.Operator.OwnedExposureParams.Exposure;
                    }
                }
                catch
                {
                    return 0.5;
                }
            }
            set
            {
                try
                {
					/* 2015.10.18
                    // 2013.03.28
                    if (GetFrameGrabberName().Contains("acA2500"))
                    {
                        string strVal;

                        Int64 nV = Convert.ToInt64(value.ToString());
                        nV = (nV / 35) * 35;
                        strVal = nV.ToString();

                        SetGigE_Feature("ExposureTimeRaw", strVal);
                    }
                    else
					*/
                    {
                        m_cogAcqFifoTool.Operator.OwnedExposureParams.Exposure = value;
                    }
                }
                catch
                {
                    // 2013.05.03
                    //MessageBox.Show("Exposure is Not Set Yet!");
                }
            }
        }

        public double Contrast
        {
            get { return m_cogAcqFifoTool.Operator.OwnedContrastParams.Contrast; }
            set
            {
                try
                {
                    m_cogAcqFifoTool.Operator.OwnedContrastParams.Contrast = value;
                }
                catch
                {
                    //MessageBox.Show("Contrast is Not Set Yet!");
                }
            }
        }

        public double Brightness
        {
            get { return m_cogAcqFifoTool.Operator.OwnedBrightnessParams.Brightness; }
            set
            {
                try
                {
                    m_cogAcqFifoTool.Operator.OwnedBrightnessParams.Brightness = value;
                }
                catch
                {
                    //MessageBox.Show("Brightness is Not Set Yet!");
                }
            }
        }

        public int Section
        {
            get { return m_nSection; }
            set
            {
                m_nSection = value;
            }
        }

        public int AcqCount
        {
            get { return m_nAcqCount; }
            set
            {
                m_nAcqCount = value;
            }
        }

        public int CompleteCount
        {
            get { return m_nCompleteCount; }
            set
            {
                m_nCompleteCount = value;
            }
        }

        public CogAcqFifoTool AcqFifoTool
        {
            get { return m_cogAcqFifoTool; }
            set { m_cogAcqFifoTool = value; }
        }

        public CogAcqFifoTool GetTool()
        {
            return m_cogAcqFifoTool;
        }

        // 2014.10.30
        public void SetTool(CogAcqFifoTool acqFifoTool)
        {
            m_cogAcqFifoTool = acqFifoTool;
        }

        public void ClearCount()
        {
            m_nAcqCount = 0;
            m_nCompleteCount = 0;
        }

        public void Run(ref ICogImage cogImage, int nFlipRotation)
        {
            // 2013.05.03
            try
            {
                m_nAcqCount++;

                if (nFlipRotation == 0)
                {
                    //Acquire(cogDisplay);                    
                    // 2015.04.08
                    m_bRan = false;

                    m_cogAcqFifoTool.Run();

                    // 2015.04.08
                    WaitRanEvent();

                    if (m_cogAcqFifoTool.OutputImage != null)
                    {
                        cogImage = m_cogAcqFifoTool.OutputImage;

#if !_USE_TRIGGER_ACQ
                        // 2017.11.16 by kdi.
                        m_cogImageTrigger = cogImage;
                        AUtil.PostMessage(m_hMain, _WM_ACQFIFO_COMPLETE, m_nPoint, m_nSection);
#endif
                    }
#if !_USE_TRIGGER_ACQ
                    else
                    {
                        cogImage = null;

                        //var property = m_cogAcqFifoTool.RunStatus.Exception.GetType().GetProperty("HResult", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                        //var value = property.GetValue(m_cogAcqFifoTool.RunStatus.Exception, null);

                        int nHResult = System.Runtime.InteropServices.Marshal.GetHRForException(m_cogAcqFifoTool.RunStatus.Exception);
                        //if (m_cogAcqFifoTool.RunStatus.Message.Contains(_CONST_CAMERA_DISCONNECTION_MESSAGE) == true ||
                        //    m_cogAcqFifoTool.RunStatus.Message.Contains(_CONST_CAMERA_DISCONNECTION_MESSAGE2) == true ||
                        //    m_cogAcqFifoTool.RunStatus.Message.Contains(_CONST_CAMERA_DISCONNECTION_MESSAGE3) == true 
                        //    )
                        //** to do:
                        //  1. 네트워크 단절 에러와 일반 예외 값이 동일한지 확인 필요
                        //      동일한 값을 가진다면, 이 조건을 적용할 수 없음
                        if ((UInt32) nHResult == (UInt32)0x80131600)    // Application Exception
                        {
                            // ip address
                            System.Net.IPAddress ipaddress = System.Net.IPAddress.Parse(m_cogAcqFifoTool.Operator.FrameGrabber.OwnedGigEAccess.CurrentIPAddress);
                            int intAddress = BitConverter.ToInt32(ipaddress.GetAddressBytes(), 0);

                            //AUtil.PostMessage(m_hMain, ASDef._WM_CAMERA_IS_DISCONNECTED, m_nPoint, intAddress);
                            AUtil.PostMessage(m_hMain, clsCamera._WM_CAMERA_IS_DISCONNECTED, m_nPoint, intAddress);

                        }

                        string strMsg = "";
                        strMsg = string.Format("AAcqFifo.Run: Error. {0}", m_cogAcqFifoTool.RunStatus.Message);
                        m_strError = strMsg;
                        AVisionProBuild.WriteLogFile(strMsg, ".AcqFifo.err.txt");
                    }
#endif

                    return;
                }

                // 2015.04.08
                m_bRan = false;
                //DateTime Now = DateTime.Now;

                m_cogAcqFifoTool.Run();

                // 2015.04.08
                WaitRanEvent();

                //TimeSpan span  = DateTime.Now - Now;

                if (m_cogAcqFifoTool.OutputImage != null)
                {
                    // 2011.07.29
                    CogIPOneImageFlipRotate cogIPOneImageFlipRotate = new CogIPOneImageFlipRotate();
                    cogIPOneImageFlipRotate.OperationInPixelSpace = (CogIPOneImageFlipRotateOperationConstants)nFlipRotation;

                    // 2012.04.25
                    ICogImage cogImageFR = cogIPOneImageFlipRotate.Execute(m_cogAcqFifoTool.OutputImage, CogRegionModeConstants.PixelAlignedBoundingBox, null);
                    Bitmap Bmp = cogImageFR.ToBitmap();
                    if ((Bmp.Flags & (16 | 32 | 64 | 128 | 256)) != 0)
                        cogImage = new CogImage24PlanarColor(Bmp);
                    else
                        cogImage = new CogImage8Grey(Bmp);

#if !_USE_TRIGGER_ACQ
                    // 2017.11.16 by kdi.
                    m_cogImageTrigger = cogImage;
                    AUtil.PostMessage(m_hMain, _WM_ACQFIFO_COMPLETE, m_nPoint, m_nSection);
#endif

                    // 2012.06.06
                    if (Bmp != null)
                    {
                        Bmp.Dispose();
                        Bmp = null;
                    }
                }
#if !_USE_TRIGGER_ACQ
                else
                {
                    cogImage = null;

                    int nHResult = System.Runtime.InteropServices.Marshal.GetHRForException(m_cogAcqFifoTool.RunStatus.Exception);
                    //if (m_cogAcqFifoTool.RunStatus.Message.Contains(_CONST_CAMERA_DISCONNECTION_MESSAGE) == true ||
                    //       m_cogAcqFifoTool.RunStatus.Message.Contains(_CONST_CAMERA_DISCONNECTION_MESSAGE2) == true ||
                    //       m_cogAcqFifoTool.RunStatus.Message.Contains(_CONST_CAMERA_DISCONNECTION_MESSAGE3) == true
                    //       )
                    //** to do:
                    //  1. 네트워크 단절 에러와 일반 예외 값이 동일한지 확인 필요
                    //      동일한 값을 가진다면, 이 조건을 적용할 수 없음
                    if ((UInt32)nHResult == (UInt32)0x80131600)    // Application Exception
                    {
                        // 2018.04.09
                        //AUtil.PostMessage(m_hMain, ASDef._WM_CAMERA_IS_DISCONNECTED, m_nPoint, 0);
                        AUtil.PostMessage(m_hMain, clsCamera._WM_CAMERA_IS_DISCONNECTED, m_nPoint, 0);

                    }

                    string strMsg = "";
                    strMsg = string.Format("AAcqFifo.Run: Error. {0}", m_cogAcqFifoTool.RunStatus.Message);
                    m_strError = strMsg;
                    AVisionProBuild.WriteLogFile(strMsg, ".AcqFifo.err.txt");
                }
#endif


                /*
                ICogImage cogImageFR = cogIPOneImageFlipRotate.Execute(m_cogAcqFifoTool.OutputImage, CogRegionModeConstants.PixelAlignedBoundingBox, null);

                lock (m_cogImageFile)
                {
                    string strFName = "c:\\" + AVisionProBuild.MakeName("Flip", DateTime.Now) + ".bmp";
                    m_cogImageFile.Open(strFName, CogImageFileModeConstants.Write);
                    m_cogImageFile.Append(cogImageFR);
                    m_cogImageFile.Close();
                    m_cogImageFile.Open(strFName, CogImageFileModeConstants.Read);
                    cogImage = m_cogImageFile[0];
                    m_cogImageFile.Close();
                    File.Delete(strFName);
                }
                */
            }
            catch (CogException ex)
            {
                cogImage = null;
                m_cogImageTrigger = cogImage;

#if !_USE_TRIGGER_ACQ
                if (ex.Message.Contains(_CONST_CAMERA_DISCONNECTION_MESSAGE) == true ||
                    ex.Message.Contains(_CONST_CAMERA_DISCONNECTION_MESSAGE2) == true)
                {
                    // 2018.04.09
                    //AUtil.PostMessage(m_hMain, ASDef._WM_CAMERA_IS_DISCONNECTED, m_nPoint, 0);
                    AUtil.PostMessage(m_hMain, clsCamera._WM_CAMERA_IS_DISCONNECTED, m_nPoint, 0);
                    
                }

                string strMsg = "";
                strMsg = string.Format("AAcqFifo.Run: CogException. {0}", ex.Message);
                m_strError = strMsg;
                AVisionProBuild.WriteLogFile(strMsg, ".AcqFifo.err.txt");
#endif
            }
            catch
            {
                cogImage = null;
            }
        }


        // 2019.05.21
        public void Run(ref ICogVisionData cogVisionData)
        {
            try
            {
                m_nAcqCount++;

                //Acquire(cogDisplay);                    
                m_bRan = false;

                m_cogAcqFifoTool.Run();

                WaitRanEvent();

                if (m_cogAcqFifoTool.OutputVisionData != null)
                {                    
                    cogVisionData = m_cogAcqFifoTool.OutputVisionData;
                    
                }
#if !_USE_TRIGGER_ACQ
                else
                {
                    cogVisionData = null;

                    //var property = m_cogAcqFifoTool.RunStatus.Exception.GetType().GetProperty("HResult", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                    //var value = property.GetValue(m_cogAcqFifoTool.RunStatus.Exception, null);

                    int nHResult = System.Runtime.InteropServices.Marshal.GetHRForException(m_cogAcqFifoTool.RunStatus.Exception);
                    //if (m_cogAcqFifoTool.RunStatus.Message.Contains(_CONST_CAMERA_DISCONNECTION_MESSAGE) == true ||
                    //    m_cogAcqFifoTool.RunStatus.Message.Contains(_CONST_CAMERA_DISCONNECTION_MESSAGE2) == true ||
                    //    m_cogAcqFifoTool.RunStatus.Message.Contains(_CONST_CAMERA_DISCONNECTION_MESSAGE3) == true 
                    //    )
                    //** to do:
                    //  1. 네트워크 단절 에러와 일반 예외 값이 동일한지 확인 필요
                    //      동일한 값을 가진다면, 이 조건을 적용할 수 없음
                    if ((UInt32)nHResult == (UInt32)0x80131600)    // Application Exception
                    {
                        // ip address
                        System.Net.IPAddress ipaddress = System.Net.IPAddress.Parse(m_cogAcqFifoTool.Operator.FrameGrabber.OwnedGigEAccess.CurrentIPAddress);
                        int intAddress = BitConverter.ToInt32(ipaddress.GetAddressBytes(), 0);

                        //AUtil.PostMessage(m_hMain, ASDef._WM_CAMERA_IS_DISCONNECTED, m_nPoint, intAddress);
                        AUtil.PostMessage(m_hMain, clsCamera._WM_CAMERA_IS_DISCONNECTED, m_nPoint, intAddress);

                    }

                    string strMsg = "";
                    strMsg = string.Format("AAcqFifo.Run: Error. {0}", m_cogAcqFifoTool.RunStatus.Message);
                    m_strError = strMsg;
                    AVisionProBuild.WriteLogFile(strMsg, ".AcqFifo.err.txt");
                }
#endif

                return;
                
            }
            catch (CogException ex)
            {
                cogVisionData = null;
                
#if !_USE_TRIGGER_ACQ
                if (ex.Message.Contains(_CONST_CAMERA_DISCONNECTION_MESSAGE) == true ||
                    ex.Message.Contains(_CONST_CAMERA_DISCONNECTION_MESSAGE2) == true)
                {
                    //AUtil.PostMessage(m_hMain, ASDef._WM_CAMERA_IS_DISCONNECTED, m_nPoint, 0);
                    AUtil.PostMessage(m_hMain, clsCamera._WM_CAMERA_IS_DISCONNECTED, m_nPoint, 0);

                }

                string strMsg = "";
                strMsg = string.Format("AAcqFifo.Run: CogException. {0}", ex.Message);
                m_strError = strMsg;
                AVisionProBuild.WriteLogFile(strMsg, ".AcqFifo.err.txt");
#endif
            }
            catch
            {
                cogVisionData = null;
            }
        }

        /*
        // 2011.07.07
        public void Run(ADisplay aDisplay, int nFlipRotation)
        {
            Run(aDisplay.Display, nFlipRotation);            
        }

        // 2011.07.07
        public void Run(CogDisplay cogDisplay, int nFlipRotation)
        {
            
            if (nFlipRotation == 0)
            {
                //Acquire(cogDisplay);
                // 2015.04.08
                m_bRan = false;

                m_cogAcqFifoTool.Run();

                // 2015.04.08
                WaitRanEvent();
         
                cogDisplay.Image = m_cogAcqFifoTool.OutputImage;
                return;
            }

            // 2015.04.08
            m_bRan = false;

            m_cogAcqFifoTool.Run();

            // 2015.04.08
            WaitRanEvent();
         
            // 2011.07.29
            CogIPOneImageFlipRotate cogIPOneImageFlipRotate = new CogIPOneImageFlipRotate();            
            cogIPOneImageFlipRotate.OperationInPixelSpace = (CogIPOneImageFlipRotateOperationConstants)nFlipRotation;
            
            ICogImage cogImage = cogIPOneImageFlipRotate.Execute(m_cogAcqFifoTool.OutputImage, CogRegionModeConstants.PixelAlignedBoundingBox, null);

            lock (m_cogImageFile)
            {
                string strFName = "c:\\" + AVisionProBuild.MakeName("Flip", DateTime.Now) + ".bmp";
                m_cogImageFile.Open(strFName, CogImageFileModeConstants.Write);
                m_cogImageFile.Append(cogImage);
                m_cogImageFile.Close();
                m_cogImageFile.Open(strFName, CogImageFileModeConstants.Read);
                cogDisplay.Image = m_cogImageFile[0];
                m_cogImageFile.Close();
                File.Delete(strFName);
            }
        }
        */


        private void OnAcqFifoComplete(object sender, Cognex.VisionPro.CogCompleteEventArgs e)
        {
            int nPending, nReady, nTicket, nTriggerNumber; 
            bool bUsy;
            bool bFirst = true;
            bool bOK = false;

            for (int nRetry = 0; nRetry < 2; nRetry++)  // 2016.02.22 by kdi.
            {
                try
                {
                    m_cogAcqFifoTool.Operator.GetFifoState(out nPending, out nReady, out bUsy);
                    if (nReady > 0)
                    {
                        // 2014.12.16
                        m_cogImageTrigger = m_cogAcqFifoTool.Operator.CompleteAcquire(-1, out nTicket, out nTriggerNumber);
                        m_nNumAqcs += 1;

                        //AUtil.PostMessage(m_hMain, _WM_ACQFIFO_COMPLETE, m_nPoint, nTriggerNumber);
                        AUtil.PostMessage(m_hMain, _WM_ACQFIFO_COMPLETE, m_nPoint, m_nSection);

                        m_nCompleteCount++;

                        if (m_nNumAqcs > 4)
                        {
                            GC.Collect();
                            m_nNumAqcs = 0;
                        }

                        bOK = true;
                        break;  // 2016.02.22 by kdi

                    }
                    if (m_nNumAqcs > 4)
                    {
                        GC.Collect();
                        m_nNumAqcs = 0;
                    }
                    //break;
                }
                catch (CogException ex)
                {
                    // 2016.02.22 by kdi. MessageBox.Show("The following error has occured:" + ex.Message);

                    if (ex.Message.Contains(_CONST_CAMERA_DISCONNECTION_MESSAGE) == true ||
                        ex.Message.Contains(_CONST_CAMERA_DISCONNECTION_MESSAGE2) == true)
                    {
                        // 2018.04.09
                        //AUtil.PostMessage(m_hMain, ASDef._WM_CAMERA_IS_DISCONNECTED, m_nPoint, 0);
                        AUtil.PostMessage(m_hMain, clsCamera._WM_CAMERA_IS_DISCONNECTED, m_nPoint, 0);                        

                    }

                    string strMsg = "";
                    strMsg = string.Format("OnAcqFifoComplete: CogException. {0}", ex.Message);
                    m_strError = strMsg;
                    AVisionProBuild.WriteLogFile(strMsg, ".AcqFifo.err.txt");

                    // 취득 실패 시, 재시도 1회
                    if (bFirst == true)
                        bFirst = false;
                }
                catch (System.Exception ex)
                {
                    // 2016.02.22 by kdi. MessageBox.Show("The following error has occured:" + ex.Message);

                    string strMsg = "";
                    strMsg = string.Format("OnAcqFifoComplete: Exception. {0}", ex.Message);
                    m_strError = strMsg;
                    AVisionProBuild.WriteLogFile(strMsg, ".AcqFifo.err.txt");

                    // 취득 실패 시, 재시도 1회
                    if (bFirst == true)
                        bFirst = false;
                }
            }

            if (bOK == false)
            {
                AUtil.PostMessage(m_hMain, _WM_ACQFIFO_COMPLETE_NG, m_nPoint, m_nSection);
            }
        }

        // 2014.12.16
        //public void InitTrigger(IntPtr hMain, int nPoint, ADisplay aDisplay, bool bUseTirgger)
        // 2016.02.22 by kdi. public void InitTrigger(IntPtr hMain, int nPoint)
        public void InitTrigger(IntPtr hMain, int nPoint, bool bShowMessage)
        {
            string strMsg = "";

            m_hMain = hMain;
            m_nPoint = nPoint;
            // 2014.12.16
            //m_aDisplayTrigger = aDisplay;

            try
            {
                // 1. Assign the CogAcqFifo CogAcqTrigger 
                // 2014.12.15
                //ICogAcqTrigger m_cogAcqTrigger = m_cogAcqFifoTool.Operator.OwnedTriggerParams;
                m_cogAcqTrigger = m_cogAcqFifoTool.Operator.OwnedTriggerParams;

                if (m_cogAcqTrigger == null)
                {
                    // 2016.02.22 by kdi. MessageBox.Show("This board type does not support trigger mode !");

                    strMsg = string.Format("InitTrigger: This board type does not support trigger mode !", ".AcqFifo.err.txt");
                    m_strError = strMsg;
                    AVisionProBuild.WriteLogFile(strMsg, ".AcqFifo.err.txt");

                    if (bShowMessage == true)
                        MessageBox.Show(strMsg);

                    return;
                }

                SetTrigger(false);                
            }
            catch (CogException ex)
            {
                // 2016.02.22 by kdi. MessageBox.Show(ex.Message);

                strMsg = string.Format("InitTrigger: CogException. {0}", ex.Message);
                m_strError = strMsg;
                AVisionProBuild.WriteLogFile(strMsg, ".AcqFifo.err.txt");

                if (bShowMessage == true)
                    MessageBox.Show(strMsg);
            }
            catch (System.Exception ex)
            {
                // 2016.02.22 by kdi. MessageBox.Show(ex.Message);

                strMsg = string.Format("InitTrigger: Exception. {0}", ex.Message);
                m_strError = strMsg;
                AVisionProBuild.WriteLogFile(strMsg, ".AcqFifo.err.txt");

                if (bShowMessage == true)
                    MessageBox.Show(strMsg);
            }
        }

        // 2014.12.16
        public void SetTrigger(bool bT)
        {
            try
            {                
                if (bT)
                {
                    m_cogAcqTrigger.TriggerModel = CogAcqTriggerModelConstants.Auto;
                    m_cogAcqFifoTool.Operator.Complete -= this.OnAcqFifoComplete;
                    m_cogAcqFifoTool.Operator.Complete += new Cognex.VisionPro.CogCompleteEventHandler(this.OnAcqFifoComplete);

                    m_cogAcqTrigger.TriggerEnabled = true;
                }
                else
                {                    
                    m_cogAcqTrigger.TriggerModel = CogAcqTriggerModelConstants.Manual;
                    m_cogAcqFifoTool.Operator.Complete -= this.OnAcqFifoComplete;
#if _USE_TRIGGER_ACQ
                    // 2017.11.16 by kdi. 
                    m_cogAcqFifoTool.Operator.Complete += new Cognex.VisionPro.CogCompleteEventHandler(this.OnAcqFifoComplete);
#endif
                    m_cogAcqTrigger.TriggerEnabled = true;
                }
            }
            catch
            {
                
            }
        }

        public CogAcqTriggerModelConstants GetTriggerMode()
        {
            if (m_cogAcqTrigger != null)
                return m_cogAcqTrigger.TriggerModel;
            else
                return CogAcqTriggerModelConstants.Manual;
        }

        public void WaitTrigger(bool bRun)
        {
            if (m_cogAcqTrigger == null)
                return;
            
            try
            {
                if (bRun)
                {
                    // Flush all outstanding acquisitions since they are not part of new acquisitions.
                    m_cogAcqFifoTool.Operator.Flush();
                    // The trigger enabled bit must be set to true in order to acquire images.
                    m_cogAcqTrigger.TriggerEnabled = true;
                }
                else
                {
                    // No images will be acquired when the trigger is disabled.
                    m_cogAcqTrigger.TriggerEnabled = false;
                }
            }
            catch
            {
               
            }
        }

        // 2012.04.24
        public string GetGigE_Feature(string strNode)
        {
            ICogGigEAccess cogGigEAccess = m_cogAcqFifoTool.Operator.FrameGrabber.OwnedGigEAccess;
            
            return cogGigEAccess.GetFeature(strNode);
        }

        // 2012.04.24
        public void SetGigE_Feature(string strNode, string strValue)
        {
            ICogGigEAccess cogGigEAccess = m_cogAcqFifoTool.Operator.FrameGrabber.OwnedGigEAccess;

            cogGigEAccess.SetFeature(strNode, strValue);
        }
    }
}
