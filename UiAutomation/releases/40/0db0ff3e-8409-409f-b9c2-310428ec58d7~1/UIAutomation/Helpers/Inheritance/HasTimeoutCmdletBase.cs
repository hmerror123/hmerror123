﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 29.11.2011
 * Time: 14:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Management.Automation;
using System.Windows.Automation;
using System.Runtime.InteropServices;

namespace UIAutomation
{
    /// <summary>
    /// Description of HasTimeoutCmdletBase.
    /// </summary>
    public class HasTimeoutCmdletBase : HasControlInputCmdletBase
    {
        // http://pinvoke.net/default.aspx/user32.FindWindow
        [DllImport("user32.dll", EntryPoint="FindWindow", SetLastError = true)]
        private static extern System.IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);
        // You can also call FindWindow(default(string), lpWindowName) or FindWindow((string)null, lpWindowName)
    	
        #region Constructor
        public HasTimeoutCmdletBase()
        {
            Wait = true;
            Timeout = Preferences.Timeout;
            Seconds = Timeout / 1000;
            OnErrorScreenShot = Preferences.OnErrorScreenShot;
            OnSuccessAction = null;
            OnErrorAction = null;
        }
        #endregion Constructor

        #region Parameters
        [Parameter(Mandatory=false)]
        internal SwitchParameter Wait { get; set; }
        [Alias("Milliseconds")]
        [Parameter(Mandatory=false)]
        public int Timeout { get; set; }
        [Parameter(Mandatory=false)]
        public int Seconds {
            get{ return Timeout / 1000; } 
            set{ Timeout = value * 1000; }
        }
        
        [Parameter(Mandatory=false)]
        public ScriptBlock[] OnSleepAction { get; set; }
        #endregion Parameters
    
        internal System.Windows.Automation.AutomationElement GetWindow(
        	GetWindowCmdletBase cmdlet,
            string processName,
            string title)
        {
            System.Windows.Automation.AutomationElement aeWnd = null;
            WriteDebug(cmdlet, "getting the root element");
            rootElement = 
                System.Windows.Automation.AutomationElement.RootElement;
            if (rootElement==null)
            {
                WriteVerbose(cmdlet, "rootElement==null");
                return null;
            }
            else
            {
                // try{ WriteDebug(cmdlet, "rootElement: " + rootElement.Current); } catch{ }
                WriteDebug(cmdlet, "rootElement: " + rootElement.Current);
            }
            
            do {
                aeWnd = null; // ??????
                if (processName.Length>0){
                    aeWnd = getWindowByProcessName(processName);
                }
                else
                {
                    aeWnd = getWindowByTitle(title);
                }
                if (aeWnd!=null)
                {
                    WriteDebug(cmdlet, "aeWnd!=null");
                }
                // 20120123
                // checkTimeout(ref aeWnd, true);
                checkTimeout(cmdlet, aeWnd, true);
            } while (cmdlet.Wait);
            try{
                if (aeWnd!=null)
                {
                    WriteDebug(cmdlet, "" + aeWnd);
                    WriteDebug(cmdlet, "aeWnd.Current.GetType() = " +
                               aeWnd.Current.GetType().Name);
                //} // 20120127
                // 20120208 if (Highlight){ Global.PaintRectangle(aeWnd); }
                } // 20120127
                CurrentData.CurrentWindow = aeWnd;
                return aeWnd;
            } catch (Exception eEveluatingWindowAndWritingToPipeline) {
                WriteDebug(cmdlet, "exception: " +
                           eEveluatingWindowAndWritingToPipeline.Message);
                // 20120206 return aeWnd; // ??
                // 20120206 
                CurrentData.CurrentWindow = aeWnd;
                UIAHelper.GetDesktopScreenshot(CmdletName(cmdlet) + "_WindowEqNull");
                return aeWnd; // ??
            }
        }
        
        private System.Windows.Automation.AutomationElement getWindowByProcessName(string processName)
        {
            int processId = 0;
            System.Windows.Automation.AndCondition conditionsProcessId = null;
            System.Windows.Automation.AutomationElement aeWndByProcId = null;
            WriteDebug(this, "processName.Length>0");
            try{
                WriteDebug(this, "getting process Id");
                System.Diagnostics.Process[] processes = 
                    System.Diagnostics.Process.GetProcessesByName(processName);
                // only the first
                processId = processes[0].Id;
                WriteVerbose(this, "processId = " + processId.ToString());
                conditionsProcessId = 
                        new System.Windows.Automation.AndCondition(
                            new System.Windows.Automation.PropertyCondition(
                                System.Windows.Automation.AutomationElement.ProcessIdProperty,
                                processId),
                            new System.Windows.Automation.OrCondition(
                                new System.Windows.Automation.PropertyCondition(
                                    System.Windows.Automation.AutomationElement.ControlTypeProperty,
                                    System.Windows.Automation.ControlType.Window),
                                new System.Windows.Automation.PropertyCondition(
                                    System.Windows.Automation.AutomationElement.ControlTypeProperty,
                                    System.Windows.Automation.ControlType.Pane),
                                new System.Windows.Automation.PropertyCondition(
                                    System.Windows.Automation.AutomationElement.ControlTypeProperty,
                                    System.Windows.Automation.ControlType.Menu)));
                
                WriteVerbose(this, "using processId = " + 
                             processId.ToString() +
                             " and ControlType.Window or ControlType.Pane conditions");
            } catch { // 20120206  (Exception eCouldNotGetProcessId) {
                // if (fromCmdlet) WriteDebug(this, "" + eCouldNotGetProcessId.Message);
                conditionsProcessId = 
                        new System.Windows.Automation.AndCondition(
                            new System.Windows.Automation.PropertyCondition(
                                System.Windows.Automation.AutomationElement.ProcessIdProperty,
                                processId),
                            new System.Windows.Automation.OrCondition(
                                new System.Windows.Automation.PropertyCondition(
                                    System.Windows.Automation.AutomationElement.ControlTypeProperty,
                                    System.Windows.Automation.ControlType.Window),
                                new System.Windows.Automation.PropertyCondition(
                                    System.Windows.Automation.AutomationElement.ControlTypeProperty,
                                    System.Windows.Automation.ControlType.Pane),
                                new System.Windows.Automation.PropertyCondition(
                                    System.Windows.Automation.AutomationElement.ControlTypeProperty,
                                    System.Windows.Automation.ControlType.Menu)));
                
            }
            
            WriteVerbose(this, "trying to get aeWndByProcId: by processId = " +
                         processId.ToString());

            if (rootElement==null){ WriteDebug(this, "rootEl is null"); }
            try{
                aeWndByProcId =
                    rootElement.FindFirst(System.Windows.Automation.TreeScope.Children,
                                        conditionsProcessId);
            } catch (Exception eGetFirstChildOfRootByProcessId){
                WriteDebug(this, "exception: " +
                           eGetFirstChildOfRootByProcessId.Message);
            }
            if (aeWndByProcId!=null){
                WriteVerbose(this, "aeWndByProcId: " +
                             aeWndByProcId.Current.Name + 
                             " is caught by processId = " + processId.ToString());
            }
            else{
                WriteDebug(this, "aeWndByProcId is still null");
            }
            return aeWndByProcId;
        }
        
        private System.Windows.Automation.AutomationElement getWindowByTitle(string title)
        {
            System.Windows.Automation.AndCondition conditionsTitle = null;
            System.Windows.Automation.AutomationElement aeWndByTitle = null;
            WriteVerbose(this, "processName.Length==0");
            conditionsTitle = 
                new AndCondition(
                    new System.Windows.Automation.OrCondition(
                        new System.Windows.Automation.PropertyCondition(
                            System.Windows.Automation.AutomationElement.ControlTypeProperty,
                            System.Windows.Automation.ControlType.Window),
                        new System.Windows.Automation.PropertyCondition(
                            System.Windows.Automation.AutomationElement.ControlTypeProperty,
                            System.Windows.Automation.ControlType.Pane),
                        new System.Windows.Automation.PropertyCondition(
                            System.Windows.Automation.AutomationElement.ControlTypeProperty,
                            System.Windows.Automation.ControlType.Menu)),
                    new PropertyCondition(
                        System.Windows.Automation.AutomationElement.NameProperty,
                        title));
            WriteVerbose(this, "trying to get aeWndByTitle: by title = " +
                         title);
            aeWndByTitle =
                rootElement.FindFirst(System.Windows.Automation.TreeScope.Children,
                                    conditionsTitle);
            if (aeWndByTitle!=null){
                WriteVerbose(this, "aeWndByTitle: " +
                             aeWndByTitle.Current.Name + 
                             " is caught by title = " + title);
            } else {
                // one more attempt using the FindWindow function
                System.IntPtr wndHandle = 
                    FindWindowByCaption(System.IntPtr.Zero, title);
                if (wndHandle!=null && wndHandle!=System.IntPtr.Zero){
                    aeWndByTitle = 
                        AutomationElement.FromHandle(wndHandle);
                }
                if (aeWndByTitle!=null){
                    WriteVerbose(this, "aeWndByTitle: " +
                                 aeWndByTitle.Current.Name + 
                                 " is caught by title = " + title + 
                                 " using the FindWindow function");
                }
            }
            return aeWndByTitle;
        }
        
        // 20120123
        // private void checkTimeout(ref System.Windows.Automation.AutomationElement aeWindow,
        private void checkTimeout(GetWindowCmdletBase cmdlet,
                                  System.Windows.Automation.AutomationElement aeWindow,
                                  bool fromCmdlet)
        {
            // RunOnRefreshScriptBlocks(this);
            // System.Threading.Thread.Sleep(Preferences.SleepInterval);
            // RunScriptBlocks(this);
            SleepAndRunScriptBlocks(this);
            System.DateTime nowDate = System.DateTime.Now;
            WriteVerbose(this, "process: " +
                         // processName + 
                         cmdlet.ProcessName +
                         ", title: " + 
                         cmdlet.Name + 
                         ", seconds: " + (nowDate - startDate).TotalSeconds);
            try{
                if (aeWindow!=null || (nowDate - startDate).TotalSeconds>this.Timeout/1000)
                {
                    if (aeWindow==null){
                        ErrorRecord err = 
                            new ErrorRecord(
                                new Exception(),
                                "ControlIsNull",
                                ErrorCategory.OperationTimeout,
                                aeWindow);
                        err.ErrorDetails = 
                            new ErrorDetails(
                                CmdletName(this) + ": timeout expired for process: " +
                                cmdlet.ProcessName + ", title: " + cmdlet.Name);
                        WriteError(this, err, false);
                    }else{
                        WriteVerbose(this, "got the window: " +
                                     aeWindow.Current.Name);
                    }
                    this.Wait = false;
                    // break;
                }
            } catch (Exception eEvaluatingWindowOrMeasuringTimeout) {
//                try{ WriteDebug(CmdletName(this) + ": exception: " +
//                            eEvaluatingWindowOrMeasuringTimeout.Message); } catch{ }
                WriteDebug(this, "exception: " +
                            eEvaluatingWindowOrMeasuringTimeout.Message);
                UIAHelper.GetDesktopScreenshot(CmdletName(this) + "_Timeout");
            }
        }
	}
}
