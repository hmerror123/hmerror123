/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 29.11.2011
 * Time: 4:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    //using System.Windows.Automation;
    //using System.Runtime.InteropServices;

    /// <summary>
    /// Description of GetUIAWindow.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAWindow")]
    [OutputType(typeof(object))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAWindowCommand : GetWindowCmdletBase
    {
//  // http://pinvoke.net/default.aspx/user32.FindWindow
// [DllImport("user32.dll", EntryPoint="FindWindow", SetLastError = true)]
// private static extern System.IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);
//  // You can also call FindWindow(default(string), lpWindowName) or FindWindow((string)null, lpWindowName)
        
        
        #region Constructor
        public GetUIAWindowCommand()
        {
        }
        #endregion Constructor

        #region Parameters
        #endregion Parameters

// protected override void BeginProcessing()
// {
// WriteVerbose(this, "ProcessName = " + this.ProcessName);
// WriteVerbose(this, "ProcessId = " + this.ProcessId);
//  //WriteVerbose(this, "Process = " + this.inputObject.ProcessName);
// WriteVerbose(this, "Name = " + this.Name);
// WriteVerbose(this, "Timeout " + this.Timeout.ToString());
// 
// startDate = System.DateTime.Now;
// System.Windows.Automation.AutomationElement _returnedWindow = null;
// try {
//  // if (this.ProcessName == "" && this.Title == "") 
// if (this.ProcessName == string.Empty && 
// this.Name == string.Empty &&
//  //this.inputObject == null && 
// this.ProcessId == 0)
// {
// WriteVerbose(
// this, 
// "this.ProcessName == string.Empty && this.Name == string.Empty && this.Process == null && this.ProcessId == 0");
// WriteObject(this, _returnedWindow);
//WriteVerbose(this, "1");
// UIAHelper.GetDesktopScreenshot(this, CmdletName(this) + "_ProcessNameEqNullAndTitleEqNull", true, 0, 0, 0, 0);
//WriteVerbose(this, "2");
//  //return;
// ErrorRecord err = 
// new ErrorRecord(
// new Exception("Neither ProcessName nor window Name are provided"),
// "NoParametersInGetWindow",
// ErrorCategory.InvalidArgument,
// this);
//WriteVerbose(this, "3");
// err.ErrorDetails = 
// new ErrorDetails(
// "Neither ProcessName nor window Name are provided");
//WriteVerbose(this, "4");
// WriteError(this, err, true);
//WriteVerbose(this, "5");
// } // describe
// WriteVerbose(this, "timeout countdown started for process: " + 
// this.ProcessName + ", name: " + this.Name);
//  // this.ProcessName + ", title: " + this.Title);
// } 
// catch (Exception eCheckParameters) {
// WriteVerbose(this, eCheckParameters.Message);
// WriteObject(this, _returnedWindow);
// UIAHelper.GetDesktopScreenshot(this, CmdletName(this) + "_BeginProcessing", true, 0, 0, 0, 0);
//  //return;
// ErrorRecord err = 
// new ErrorRecord(
// new Exception("Unknown exception"),
// "UnknownInGetWindow",
// ErrorCategory.InvalidResult,
// this);
// err.ErrorDetails = 
// new ErrorDetails(
// "Unknown error in BeginProcessing");
// WriteError(this, err, true);
// } // describe
//  //System.Windows.Automation.AutomationElement _returnedWindow = 
// _returnedWindow =
// GetWindow(this, null, this.ProcessName, this.ProcessId, this.Name);
//  // GetWindow(this.ProcessName, this.Title);
// WriteObject(this, _returnedWindow);
// }
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            WriteVerbose(this, "ProcessName = " + this.ProcessName);
            WriteVerbose(this, "ProcessId = " + this.ProcessId);
            try{WriteVerbose(this, "Process = " + this.InputObject.ProcessName);} 
            catch {}
            WriteVerbose(this, "Name = " + this.Name);
            WriteVerbose(this, "Timeout " + this.Timeout.ToString());
            
            startDate = System.DateTime.Now;
            System.Windows.Automation.AutomationElement _returnedWindow = null;
            try {
                // if (this.ProcessName == "" && this.Title == "") 
                if (this.ProcessName == string.Empty && 
                    this.Name == string.Empty &&
                    (this.InputObject as System.Diagnostics.Process) == null &&
                    this.ProcessId == 0)
                {
                    WriteVerbose(
                        this, 
                        "this.ProcessName == string.Empty && this.Name == string.Empty && this.Process == null && this.ProcessId == 0");
                    //WriteObject(this, _returnedWindow);
                    UIAHelper.GetDesktopScreenshot(this, CmdletName(this) + "_ProcessNameEqNullAndTitleEqNull", true, 0, 0, 0, 0);
                    // return;
                    ErrorRecord err = 
                        new ErrorRecord(
                            new Exception("Neither ProcessName nor window Name are provided. Or ProcessId == 0"),
                            "NoParametersInGetWindow",
                            ErrorCategory.InvalidArgument,
                            this);
                    err.ErrorDetails = 
                        new ErrorDetails(
                            "Neither ProcessName nor window Name are provided. Or ProcessId == 0");
                    WriteError(this, err, true);
                    //return; //// ????????????????
                } // describe
//                WriteVerbose(
//                    this, 
//                    "timeout countdown started for process: " +
//                    this.ProcessName + ", name: " + this.Name);
//                             // this.ProcessName + ", title: " + this.Title);
            } 
            catch (Exception eCheckParameters) {
                WriteVerbose(this, eCheckParameters.Message);
                //WriteObject(this, _returnedWindow);
                UIAHelper.GetDesktopScreenshot(this, CmdletName(this) + "_BeginProcessing", true, 0, 0, 0, 0);
                //return;
                ErrorRecord err = 
                    new ErrorRecord(
                        new Exception("Unknown exception"),
                        "UnknownInGetWindow",
                        ErrorCategory.InvalidResult,
                        this);
                err.ErrorDetails = 
                    new ErrorDetails(
                        "Unknown error in '" + CmdletName(this) + "' ProcessRecord"); //BeginProcessing");
                WriteError(this, err, true);
                //return; //// ????????????????
            } // describe
            //System.Windows.Automation.AutomationElement _returnedWindow = 
            _returnedWindow =
                GetWindow(this, this.InputObject, this.ProcessName, this.ProcessId, this.Name);
                // GetWindow(this.ProcessName, this.Title);
            if (_returnedWindow != null) {
                WriteObject(this, _returnedWindow);
            } else {
                ErrorRecord err = 
                    new ErrorRecord(
                        new Exception("Failed to get the window"),
                        "FailedToGetWindow",
                        ErrorCategory.InvalidResult,
                        _returnedWindow);
                string procName = string.Empty;
                string procId = string.Empty;
                try{ procName = this.ProcessName; } 
                catch {}
                try{ procId = this.ProcessId.ToString(); }
                catch {}
                try{ if (procName.Length == 0) { procName = this.InputObject.ProcessName; } }
                catch {}
                err.ErrorDetails = 
                    new ErrorDetails(
                        "Failed to get the window" + 
                        "\r\nprocess name: " +
                        procName +
                        "\r\nprocess Id: " + 
                        procId + 
                        "\r\nprocess: " + 
                        procName);
                        
                WriteError(this, err, true);
            }
            
            
            
            
// System.Windows.Automation.AutomationElement _returnedWindow =
// GetWindow(this, this.inputObject, string.Empty, 0, string.Empty);
//  // GetWindow(this.ProcessName, this.Title);
// WriteObject(this, _returnedWindow);
        }
        
        protected override void EndProcessing()
        {
            // 20120206 aeForm = null;
            rootElement = null;
        }
        
// internal System.Windows.Automation.AutomationElement GetWindow(
// string processName,
// string title)
// {
// System.Windows.Automation.AutomationElement aeWnd = null;
// WriteDebug(this, "getting the root element");
// rootElement = 
// System.Windows.Automation.AutomationElement.RootElement;
// if (rootElement == null)
// {
// WriteVerbose(this, "rootElement == null");
// return null;
// }
// else
// {
//  // try { WriteDebug(this, "rootElement: " + rootElement.Current); } catch { }
// WriteDebug(this, "rootElement: " + rootElement.Current);
// }
// 
// do {
// aeWnd = null; // ??????
// if (processName.Length > 0) {
// aeWnd = getWindowByProcessName(processName);
// }
// else
// {
// aeWnd = getWindowByTitle(title);
// }
// if (aeWnd != null)
// {
// WriteDebug(this, "aeWnd != null");
// }
//  // 20120123
//  // checkTimeout(ref aeWnd, true);
// checkTimeout(aeWnd, true);
// } while (this.Wait);
// try {
// if (aeWnd != null)
// {
// WriteDebug(this, "" + aeWnd);
// WriteDebug(this, "aeWnd.Current.GetType() = " +
// aeWnd.Current.GetType().Name);
//  //} // 20120127
//  // 20120208 if (Highlight) { Global.PaintRectangle(aeWnd); }
// } // 20120127
// CurrentData.CurrentWindow = aeWnd;
// return aeWnd;
// } catch (Exception eEveluatingWindowAndWritingToPipeline) {
// WriteDebug(this, "exception: " +
// eEveluatingWindowAndWritingToPipeline.Message);
//  // 20120206 return aeWnd; // ??
//  // 20120206 
// CurrentData.CurrentWindow = aeWnd;
// UIAHelper.GetDesktopScreenshot(CmdletName(this) + "_WindowEqNull");
// return aeWnd; // ??
// }
// }
        
// private System.Windows.Automation.AutomationElement getWindowByProcessName(string processName)
// {
// int processId = 0;
// System.Windows.Automation.AndCondition conditionsProcessId = null;
// System.Windows.Automation.AutomationElement aeWndByProcId = null;
// WriteDebug(this, "processName.Length > 0");
// try {
// WriteDebug(this, "getting process Id");
// System.Diagnostics.Process[] processes = 
// System.Diagnostics.Process.GetProcessesByName(processName);
//  // only the first
// processId = processes[0].Id;
// WriteVerbose(this, "processId = " + processId.ToString());
// conditionsProcessId = 
// new System.Windows.Automation.AndCondition(
// new System.Windows.Automation.PropertyCondition(
// System.Windows.Automation.AutomationElement.ProcessIdProperty,
// processId),
// new System.Windows.Automation.OrCondition(
// new System.Windows.Automation.PropertyCondition(
// System.Windows.Automation.AutomationElement.ControlTypeProperty,
// System.Windows.Automation.ControlType.Window),
// new System.Windows.Automation.PropertyCondition(
// System.Windows.Automation.AutomationElement.ControlTypeProperty,
// System.Windows.Automation.ControlType.Pane),
// new System.Windows.Automation.PropertyCondition(
// System.Windows.Automation.AutomationElement.ControlTypeProperty,
// System.Windows.Automation.ControlType.Menu)));
// 
// WriteVerbose(this, "using processId = " + 
// processId.ToString() +
// " and ControlType.Window or ControlType.Pane conditions");
// } catch { // 20120206  (Exception eCouldNotGetProcessId) {
//  // if (fromCmdlet) WriteDebug(this, "" + eCouldNotGetProcessId.Message);
// conditionsProcessId = 
// new System.Windows.Automation.AndCondition(
// new System.Windows.Automation.PropertyCondition(
// System.Windows.Automation.AutomationElement.ProcessIdProperty,
// processId),
// new System.Windows.Automation.OrCondition(
// new System.Windows.Automation.PropertyCondition(
// System.Windows.Automation.AutomationElement.ControlTypeProperty,
// System.Windows.Automation.ControlType.Window),
// new System.Windows.Automation.PropertyCondition(
// System.Windows.Automation.AutomationElement.ControlTypeProperty,
// System.Windows.Automation.ControlType.Pane),
// new System.Windows.Automation.PropertyCondition(
// System.Windows.Automation.AutomationElement.ControlTypeProperty,
// System.Windows.Automation.ControlType.Menu)));
// 
// }
// 
// WriteVerbose(this, "trying to get aeWndByProcId: by processId = " +
// processId.ToString());
//
// if (rootElement == null) { WriteDebug(this, "rootEl is null"); }
// try {
// aeWndByProcId =
// rootElement.FindFirst(System.Windows.Automation.TreeScope.Children,
// conditionsProcessId);
// } catch (Exception eGetFirstChildOfRootByProcessId) {
// WriteDebug(this, "exception: " +
// eGetFirstChildOfRootByProcessId.Message);
// }
// if (aeWndByProcId != null) {
// WriteVerbose(this, "aeWndByProcId: " +
// aeWndByProcId.Current.Name + 
// " is caught by processId = " + processId.ToString());
// }
// else{
// WriteDebug(this, "aeWndByProcId is still null");
// }
// return aeWndByProcId;
// }
// 
// private System.Windows.Automation.AutomationElement getWindowByTitle(string title)
// {
// System.Windows.Automation.AndCondition conditionsTitle = null;
// System.Windows.Automation.AutomationElement aeWndByTitle = null;
// WriteVerbose(this, "processName.Length == 0");
// conditionsTitle = 
// new AndCondition(
// new System.Windows.Automation.OrCondition(
// new System.Windows.Automation.PropertyCondition(
// System.Windows.Automation.AutomationElement.ControlTypeProperty,
// System.Windows.Automation.ControlType.Window),
// new System.Windows.Automation.PropertyCondition(
// System.Windows.Automation.AutomationElement.ControlTypeProperty,
// System.Windows.Automation.ControlType.Pane),
// new System.Windows.Automation.PropertyCondition(
// System.Windows.Automation.AutomationElement.ControlTypeProperty,
// System.Windows.Automation.ControlType.Menu)),
// new PropertyCondition(
// System.Windows.Automation.AutomationElement.NameProperty,
// title));
// WriteVerbose(this, "trying to get aeWndByTitle: by title = " +
// title);
// aeWndByTitle =
// rootElement.FindFirst(System.Windows.Automation.TreeScope.Children,
// conditionsTitle);
// if (aeWndByTitle != null) {
// WriteVerbose(this, "aeWndByTitle: " +
// aeWndByTitle.Current.Name + 
// " is caught by title = " + title);
// } else {
//  // one more attempt using the FindWindow function
// System.IntPtr wndHandle = 
// FindWindowByCaption(System.IntPtr.Zero, title);
// if (wndHandle != null && wndHandle != System.IntPtr.Zero) {
// aeWndByTitle = 
// AutomationElement.FromHandle(wndHandle);
// }
// if (aeWndByTitle != null) {
// WriteVerbose(this, "aeWndByTitle: " +
// aeWndByTitle.Current.Name + 
// " is caught by title = " + title + 
// " using the FindWindow function");
// }
// }
// return aeWndByTitle;
// }
// 
//  // 20120123
//  // private void checkTimeout(ref System.Windows.Automation.AutomationElement aeWindow,
// private void checkTimeout(System.Windows.Automation.AutomationElement aeWindow,
// bool fromCmdlet)
// {
//  // RunOnRefreshScriptBlocks(this);
//  // System.Threading.Thread.Sleep(Preferences.SleepInterval);
//  // RunScriptBlocks(this);
// SleepAndRunScriptBlocks(this);
// System.DateTime nowDate = System.DateTime.Now;
// WriteVerbose(this, "process: " +
//  // processName + 
// this.ProcessName +
// ", title: " + 
// this.Name + 
// ", seconds: " + (nowDate - startDate).TotalSeconds);
// try {
// if (aeWindow != null || (nowDate - startDate).TotalSeconds > this.Timeout/1000)
// {
// if (aeWindow == null) {
// ErrorRecord err = 
// new ErrorRecord(
// new Exception(),
// "ControlIsNull",
// ErrorCategory.OperationTimeout,
// aeWindow);
// err.ErrorDetails = 
// new ErrorDetails(
// CmdletName(this) + ": timeout expired for process: " +
// this.ProcessName + ", title: " + this.Name);
// WriteError(this, err, false);
// }else{
// WriteVerbose(this, "got the window: " +
// aeWindow.Current.Name);
// }
// this.Wait = false;
//  // break;
// }
// } catch (Exception eEvaluatingWindowOrMeasuringTimeout) {
//// try { WriteDebug(CmdletName(this) + ": exception: " +
//// eEvaluatingWindowOrMeasuringTimeout.Message); } catch { }
// WriteDebug(this, "exception: " +
// eEvaluatingWindowOrMeasuringTimeout.Message);
// UIAHelper.GetDesktopScreenshot(CmdletName(this) + "_Timeout");
// }
// }
    }
}
