/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12/2/2011
 * Time: 5:51 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Threading;
    using System.Management.Automation.Runspaces;
    using System.Windows.Automation;
    
    /// <summary>
    /// The CommonCmdletBase class in the top of cmdlet hierarchy.
    /// </summary>
    [Cmdlet(VerbsCommon.Show, "UIAModuleSettings")]
    public class CommonCmdletBase : PSCmdlet
    // internal class CommonCmdletBase : PSCmdlet
    {
        #region Constructor
        public CommonCmdletBase()
        {
            #region creating the log file
            try {
                Global.CreateLogFile();
            } catch { }
            #endregion creating the log file
            CurrentData.LastCmdlet = this.CmdletName(this);
        }
        #endregion Constructor
        
        #region Properties
        protected AutomationElement EventSource { get; set; }
        protected AutomationEventArgs EventArgs { get; set; }
        #endregion Properties
        
        #region Show-UIAModuleSettings
        protected override void BeginProcessing()
        {
            WriteObject("\r\nTimeout settings:");
            WriteObject("[UIAutomation.Preferences]::Timeout = " + 
                        Preferences.Timeout.ToString());
            
            WriteObject("\r\nError collection settings:");
            WriteObject("[UIAutomation.Preferences]::MaximumErrorCount = " + 
                        Preferences.MaximumErrorCount.ToString());
            
            WriteObject("\r\nCommon actions:");
            WriteObject("[UIAutomation.Preferences]::OnErrorAction = " + 
                        Preferences.OnErrorAction);
            WriteObject("[UIAutomation.Preferences]::OnSleepAction = " + 
                        Preferences.OnSleepAction);
            WriteObject("[UIAutomation.Preferences]::OnSuccessAction = " + 
                        Preferences.OnSuccessAction);
            
            WriteObject("\r\nScreenshot settings:");
            WriteObject("[UIAutomation.Preferences]::OnErrorScreenShot = " +
                        Preferences.OnErrorScreenShot.ToString());
            WriteObject("[UIAutomation.Preferences]::ScreenShotFolder = " + 
                        Preferences.ScreenShotFolder);
            
            WriteObject("\r\nLog settings:");
            WriteObject("[UIAutomation.Preferences]::Log = " + 
                        Preferences.Log.ToString());
            WriteObject("[UIAutomation.Preferences]::LogPath = " + 
                        Preferences.LogPath);
            
            WriteObject("\r\nDebugging delays:");
            WriteObject("[UIAutomation.Preferences]::OnClickDelay = " + 
                        Preferences.OnClickDelay.ToString());
            WriteObject("[UIAutomation.Preferences]::OnErrorDelay = " + 
                        Preferences.OnErrorDelay.ToString());
            WriteObject("[UIAutomation.Preferences]::OnSleepDelay = " + 
                        Preferences.OnSleepDelay.ToString());
            WriteObject("[UIAutomation.Preferences]::OnSuccessDelay = " + 
                        Preferences.OnSuccessDelay.ToString());
            
            WriteObject("\r\nTranscript settings");
            WriteObject("[UIAutomation.Preferences]::TranscriptInterval = " + 
                        Preferences.TranscriptInterval.ToString());
            
            WriteObject("\r\nHighlighter settings:");
            WriteObject("[UIAutomation.Preferences]::Highlight = " + 
                        Preferences.Highlight.ToString());
            WriteObject("[UIAutomation.Preferences]::HighlighterBorder = " + 
                        Preferences.HighlighterBorder.ToString());
            WriteObject("[UIAutomation.Preferences]::HighlighterColor = " + 
                        Preferences.HighlighterColor.ToString());
        }
        #endregion Show-UIAModuleSettings
        
        protected override void EndProcessing()
        {
            #region close the log
            try {
                Global.CloseLogFile();
            } catch { }
            #endregion close the log
        }
        
        #region Write methods
        private void WriteLog(string record)
        {
            try {
                Global.WriteToLogFile(record);
            } catch (Exception e) {
                WriteVerbose(this, "Unable to write to the log file: " +
                             Preferences.LogPath);
                WriteVerbose(this, e.Message);
            }
        }
        
            #region Cmdlet Signature
        internal string CmdletName(CommonCmdletBase cmdlet)
        {
            string result = String.Empty;
            if (cmdlet == null) return result;
            result = 
                cmdlet.GetType().Name;
            result = 
                result.Replace("UIA", "-UIA").Replace("Command", "");
            return result;
        }
            
        private string CmdletSignature(CommonCmdletBase cmdlet)
        {
            string result = this.CmdletName(cmdlet);
            result += ": ";
            return result;
        }
            #endregion Cmdlet Signature
        
        protected internal void WriteVerbose(CommonCmdletBase cmdlet, string text)
        {
            string reportString = string.Empty;
            reportString = 
                CmdletSignature(cmdlet) +  
                text;
            if (cmdlet != null) try { WriteVerbose(reportString); } catch { }
            //try {WriteVerbose(reportString); } catch {}
            WriteLog(reportString);
        }
        
        protected internal void WriteVerbose(CommonCmdletBase cmdlet, object obj)
        {
            string reportString = string.Empty;
            reportString =
                CmdletSignature(cmdlet) +  
                obj.ToString();
            if (cmdlet != null) try { WriteVerbose(reportString); } catch { }
            //try {WriteVerbose(reportString); } catch {}
            WriteLog(reportString);
        }
        
        protected internal void WriteDebug(CommonCmdletBase cmdlet, string text)
        {
            string reportString = 
                CmdletSignature(cmdlet) +  
                text;
            WriteLog(reportString);
        }
        
        protected internal void WriteDebug(CommonCmdletBase cmdlet, object obj)
        {
            string reportString = 
                CmdletSignature(cmdlet) +  
                obj.ToString();
            WriteLog(reportString);
        }
        
        protected internal void WriteObject(CommonCmdletBase cmdlet, object obj)
        {
            try{
                // Global.
                // UIAHelper.Highlight(obj);
                AutomationElement element = null;
    //WriteVerbose(this, "WriteObject!!!!!!!!!!!!!!!");
                if (cmdlet != null && !(cmdlet is WizardCmdletBase)) {
                    //AutomationElement element = null;
                //  //  //if (cmdlet != null && !(cmdlet is WizardCmdletBase)) {
                    try {
                        //AutomationElement elt = obj as AutomationElement;
                        element = obj as AutomationElement;
                        if (element is AutomationElement &&
                            (int)element.Current.ProcessId > 0) {
                            // 20120222
                            WriteVerbose(this, "current cmdlet: " + this.GetType().Name);
                            // 
                            WriteVerbose(this, "highlighting the following element:");
                            WriteVerbose(this, "Name = " + element.Current.Name);
                            WriteVerbose(this, "AutomationId = " + element.Current.AutomationId);
                            WriteVerbose(this, "ControlType = " + element.Current.ControlType.ProgrammaticName);
                            WriteVerbose(this, "X = " + element.Current.BoundingRectangle.X.ToString());
                            WriteVerbose(this, "Y = " + element.Current.BoundingRectangle.Y.ToString());
                            WriteVerbose(this, "Width = " + element.Current.BoundingRectangle.Width.ToString());
                            WriteVerbose(this, "Height = " + element.Current.BoundingRectangle.Height.ToString());
                        }
                    } catch { //(Exception eee) {
                        // nothing to do
                        // just failed to highlight
    //WriteVerbose("1 !!!!!1");
                    }
                //  // 
                if (element != null && element is AutomationElement &&
                        (int)element.Current.ProcessId > 0) {
                        WriteVerbose(this, "as it is an AutomationElement, it should be highlighted");
                        if (Preferences.Highlight || ((HasScriptBlockCmdletBase)cmdlet).Highlight) {
                            //WriteVerbose(this, "run Highlighter");
                            try {
    //WriteVerbose("5 !!!!!!");
                                //AutomationElement element = 
                                //element =
                                // obj as AutomationElement;
                                WriteVerbose(this, "run Highlighter");
                                UIAHelper.Highlight(element);
                                WriteVerbose(this, "after running the Highlighter");
                            } catch (Exception ee) {
                                WriteVerbose(this, "unable to highlight: " + ee.Message);
                                WriteVerbose(this, obj.ToString());
    //WriteVerbose("8 !!!!!!");
                            }
            // try { UIAHelper.Highlight(obj); } catch (Exception ee) {
            // WriteVerbose(this, "unable to highlight: " + ee.Message);
            // }
                        }
                    }
                }
                
                WriteVerbose(this, "is going to run scriptblocks");
                if (cmdlet != null) {
                    // run scriptblocks
                    if (cmdlet is HasScriptBlockCmdletBase) {
                        // if (obj == null || (obj is bool && ((bool)obj) == false)) {
                        WriteVerbose(this, "cmdlet is of the HasScriptBlockCmdletBase type");
                        if (obj == null) {
                            WriteVerbose(this, "run OnError script blocks (null)");
                            RunOnErrorScriptBlocks(((HasScriptBlockCmdletBase)cmdlet));
                        } else if (obj is bool && ((bool)obj) == false) {
                            WriteVerbose(this, "run OnError script blocks (false)");
                            RunOnErrorScriptBlocks(((HasScriptBlockCmdletBase)cmdlet));
                        } else if (obj != null) {
                            WriteVerbose(this, "run OnSuccess script blocks");
                            RunOnSuccessScriptBlocks(((HasScriptBlockCmdletBase)cmdlet));
                        }
                    }
                    try {
                        CurrentData.LastResult = obj;
                        if (((HasScriptBlockCmdletBase)cmdlet).TestResultName != null &&
                            ((HasScriptBlockCmdletBase)cmdlet).TestResultName.Length > 0) {
//WriteVerbose(this, " >>>>>>>>>>>>>>>>>>>>>>>>>>>>> OK");
//WriteVerbose(this, "((HasScriptBlockCmdletBase)cmdlet).TestResultName = " + ((HasScriptBlockCmdletBase)cmdlet).TestResultName);
//WriteVerbose(this, "((HasScriptBlockCmdletBase)cmdlet).TestResultId = " + ((HasScriptBlockCmdletBase)cmdlet).TestResultId);
//WriteVerbose(this, "((HasScriptBlockCmdletBase)cmdlet).TestPassed = " + ((HasScriptBlockCmdletBase)cmdlet).TestPassed.ToString());
//WriteVerbose(this, TMX.TestData.TestSuites);
                            string iInfo = string.Empty;
                            if (((HasScriptBlockCmdletBase)cmdlet).TestLog){
                                iInfo = TMX.TMXHelper.GetInvocationInfo(this.MyInvocation);
                            }
                            TMX.TMXHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
                                                          ((HasScriptBlockCmdletBase)cmdlet).TestResultId,
                                                          ((HasScriptBlockCmdletBase)cmdlet).TestPassed,
                                                          false, // isKnownIssue
                                                          iInfo,
                                                          string.Empty);
                                                          //((HasScriptBlockCmdletBase)cmdlet).TestLog);
//WriteVerbose(this, " >>>>>>>>>>>>>>>>>>>>>>>>>>>>> closed?");
                        }
                    }
                    catch (Exception eeee) {
//WriteVerbose(this, eeee.Message);
                        WriteVerbose(this, "for working with test results you need to import the TMX module");
                    }
//Console.WriteLine("<<< TestData.CurrentTestResult = " + TMX.TestData.CurrentTestResult.Name + " " + TMX.TestData.CurrentTestResult.Id);
//Console.WriteLine("<<< TestData.CurrentTestScenario.TestResults.Count = " + TMX.TestData.CurrentTestScenario.TestResults.Count.ToString());


                    // remove the Turbo timeout
                    if ((cmdlet as HasTimeoutCmdletBase) != null) {
                        if (CurrentData.CurrentWindow != null &&
                            CurrentData.LastResult != null) {
                            if (Preferences.StoredDefaultTimeout != 0) {
                                if (! Preferences.TimeoutSetByCustomer) {
                                    Preferences.Timeout = Preferences.StoredDefaultTimeout;
                                    Preferences.StoredDefaultTimeout = 0;
                                }
                            }
                        }
                    }


                }
                WriteVerbose(this, "sleeping if sleep time is provided");
                System.Threading.Thread.Sleep(Preferences.OnSuccessDelay);
                //if (cmdlet != null && !(cmdlet is WizardCmdletBase)) try { WriteObject(obj);
                WriteVerbose(this, "outputting the result object");
                if (cmdlet != null) {
                    try { 
                        element = obj as AutomationElement;
                        WriteVerbose("getting the element again to ensure that it still exists");
                        WriteVerbose((element as AutomationElement).ToString());
                        if (!(cmdlet is WizardCmdletBase) &&
                            (element is AutomationElement)){
                            WriteVerbose(this, "returning the object");
                            WriteObject(obj);
                        } else if ((cmdlet is WizardCmdletBase)) {
                            WriteVerbose(this, "returning the wizard or step");
                            WriteObject(obj);
                        } else {
                            WriteVerbose("returning true");
                            WriteObject(true);
                        }
                    } catch { // (Exception eeeee) {
                        // test
                        WriteVerbose(this, "failed to issue the result object of AutomationElement type");
                        WriteVerbose(this, "returning as is");
                        WriteObject(obj);
                    }
                }
                string reportString =
                    CmdletSignature(cmdlet) +  
                    obj.ToString();
                
                // 20120206 try { WriteVerbose(reportString); } catch { }
                if (cmdlet != null && reportString != null && reportString != string.Empty) { //try { WriteVerbose(reportString);
                    WriteVerbose(reportString);
                
                //} catch { }
                } 
                //catch (Exception eeeeee) {
                //}
                WriteVerbose(this, "writing into the log");
                WriteLog(reportString);
                WriteVerbose(this, "the log record has been written");
            }
            catch {}
        }
        
        protected internal void WriteObject(CommonCmdletBase cmdlet, object[] obj)
        {
            try{
                if (cmdlet != null) {
                    // run scriptblocks
                    if (cmdlet is HasScriptBlockCmdletBase) {
                        if (obj == null) {
                            RunOnErrorScriptBlocks(((HasScriptBlockCmdletBase)cmdlet));
                        //} else if (obj is bool && ((bool)obj) == false) {
                        // RunOnErrorScriptBlocks(((HasScriptBlockCmdletBase)cmdlet));
                        } else if (obj != null) {
                            RunOnSuccessScriptBlocks(((HasScriptBlockCmdletBase)cmdlet));
                        }
                    }
                    try {
                        CurrentData.LastResult = obj;
                        if (((HasScriptBlockCmdletBase)cmdlet).TestResultName != null &&
                            ((HasScriptBlockCmdletBase)cmdlet).TestResultName.Length > 0) {
                            string iInfo = string.Empty;
                            if (((HasScriptBlockCmdletBase)cmdlet).TestLog){
                                iInfo = TMX.TMXHelper.GetInvocationInfo(this.MyInvocation);
                            }
                            TMX.TMXHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
                                                          ((HasScriptBlockCmdletBase)cmdlet).TestResultId,
                                                          ((HasScriptBlockCmdletBase)cmdlet).TestPassed,
                                                          false, // isKnownIssue
                                                          iInfo,
                                                          string.Empty);
                                                          //((HasScriptBlockCmdletBase)cmdlet).TestLog);
                        }
                    }
                    catch {
                        WriteVerbose(this, "for working with test results you need to import the TMX module");
                    }
                    
//                    // remove the Turbo timeout
//                    if ((cmdlet as HasTimeoutCmdletBase) != null) {
//                        if (CurrentData.CurrentWindow != null &&
//                            CurrentData.LastResult != null) {
//                            if (Preferences.StoredDefaultTimeout != 0) {
//                                Preferences.Timeout = Preferences.StoredDefaultTimeout;
//                                Preferences.StoredDefaultTimeout = 0;
//                            }
//                        }
//                    }
                    
                    // remove the Turbo timeout
                    if ((cmdlet as HasTimeoutCmdletBase) != null) {
                        if (CurrentData.CurrentWindow != null &&
                            CurrentData.LastResult != null) {
                            if (Preferences.StoredDefaultTimeout != 0) {
                                if (! Preferences.TimeoutSetByCustomer) {
                                    Preferences.Timeout = Preferences.StoredDefaultTimeout;
                                    Preferences.StoredDefaultTimeout = 0;
                                }
                            }
                        }
                    }
                    
                }
                System.Threading.Thread.Sleep(Preferences.OnSuccessDelay);
                //if (cmdlet != null && !(cmdlet is WizardCmdletBase)) try { WriteObject(obj);
                
                if (cmdlet != null) {
                    if (obj != null && obj.Length > 0) {
                        for (int i = 0; i < obj.Length; i++) {
                            WriteObject(obj[i]);
                        }
                    }
                } //if (cmdlet != null) try { WriteObject(obj);
                
    // } catch { // (Exception eeeee) {
    //  // test
    // }
                
                string reportString =
                    CmdletSignature(cmdlet) +  
                    obj.ToString();
                
                if (cmdlet != null && reportString != null && reportString != string.Empty) {
                    WriteVerbose(reportString);
                } 
                WriteLog(reportString);
            
            }
            catch {}
        }
        
        private void writeErrorToTheList(ErrorRecord err)
        {
            CurrentData.Error.Add(err);
            if (CurrentData.Error.Count > Preferences.MaximumErrorCount) {
                do{
                    CurrentData.Error.RemoveAt(0);
                } while (CurrentData.Error.Count > Preferences.MaximumErrorCount);
                CurrentData.Error.Capacity = Preferences.MaximumErrorCount;
            }
        }
        
        protected void WriteError(CommonCmdletBase cmdlet, ErrorRecord err, bool terminating)
        {
            if (cmdlet != null) {
                // run scriptblocks
                if (cmdlet is HasScriptBlockCmdletBase) {
                    RunOnErrorScriptBlocks(((HasScriptBlockCmdletBase)cmdlet));
                }
                
                // write error to the test results collection
                // CurrentData.TestResults[CurrentData.TestResults.Count - 1].Details.Add(err);
                //TMX.TestData.AddTestResultDetail(err);
                TMX.TMXHelper.AddTestResultErrorDetail(err);
            
                // write test result label
                try {
                    // 20120328
                    CurrentData.LastResult = null;
                    if (((HasScriptBlockCmdletBase)cmdlet).TestResultName != null &&
                        ((HasScriptBlockCmdletBase)cmdlet).TestResultName.Length > 0) {
                        //TMX.TestData.AddTestResult
                        string iInfo = string.Empty;
                        if (((HasScriptBlockCmdletBase)cmdlet).TestLog){
                            iInfo = TMX.TMXHelper.GetInvocationInfo(this.MyInvocation);
                        }
                        TMX.TMXHelper.CloseTestResult(((HasScriptBlockCmdletBase)cmdlet).TestResultName,
                                                      ((HasScriptBlockCmdletBase)cmdlet).TestResultId,
                                                      ((HasScriptBlockCmdletBase)cmdlet).TestPassed,
                                                      ((HasScriptBlockCmdletBase)cmdlet).KnownIssue,
                                                      iInfo,
                                                      string.Empty);
                                                      //((HasScriptBlockCmdletBase)cmdlet).TestLog);
                    }
                }
                catch {
                    WriteVerbose(this, "for working with test results you need to import the TMX module");
                }
                
                // set the Turbo timeout
                if ((cmdlet as HasTimeoutCmdletBase) != null) {
                    if (CurrentData.CurrentWindow == null &&
                        CurrentData.LastResult == null &&
                        terminating) {
                        int timeoutToStore = Preferences.Timeout;
                        Preferences.Timeout = Preferences.AfterFailTurboTimeout;
                        Preferences.TimeoutSetByCustomer = false;
                        Preferences.StoredDefaultTimeout = timeoutToStore;
                    }
                }
                
//                    // remove the Turbo timeout
//                    if (cmdlet is HasTimeoutCmdletBase) {
//                        if (CurrentData.CurrentWindow != null &&
//                            CurrentData.LastResult != null) {
//                            if (Preferences.StoredDefaultTimeout != 0) {
//                                Preferences.Timeout = Preferences.StoredDefaultTimeout;
//                                Preferences.StoredDefaultTimeout = 0;
//                            }
//                        }
//                    }
                
                // write an error to the Error list
                this.writeErrorToTheList(err);
                System.Threading.Thread.Sleep(Preferences.OnErrorDelay);
                if (terminating) {
                    ThrowTerminatingError(err);
                } else {
                    WriteError(err);
                }
            }
        }
        #endregion Write methods
        
        #region sleep and run scripts
        // 20120312 0.6.11
        //protected void SleepAndRunScriptBlocks(HasTimeoutCmdletBase cmdlet)
        protected void SleepAndRunScriptBlocks(HasControlInputCmdletBase cmdlet)
        {
            RunOnSleepScriptBlocks(cmdlet);
            System.Threading.Thread.Sleep(Preferences.OnSleepDelay);
            // RunScriptBlocks(cmdlet);
        }
        #endregion sleep and run scripts
        
        #region Invoke-UIAScript
        // 20120209 protected void RunEventScriptBlocks(EventCmdletBase cmdlet)
        //protected internal void RunEventScriptBlocks(EventCmdletBase cmdlet)
        protected internal void RunEventScriptBlocks(HasControlInputCmdletBase cmdlet)
        {
            System.Collections.Generic.List<ScriptBlock >  blocks =
                new System.Collections.Generic.List<ScriptBlock > ();
            WriteVerbose(cmdlet,
                         blocks.Count.ToString() + 
                         " events to fire");
            if (cmdlet.EventAction != null &&
                cmdlet.EventAction.Length > 0) {
                foreach (ScriptBlock sb in cmdlet.EventAction) {
                    blocks.Add(sb);
                    WriteVerbose(cmdlet,
                                 "the scriptblock: " + 
                                 sb.ToString() + 
                                 " is ready to be fired");
                }
            }
            runScriptBlocks(blocks, cmdlet, true);
            // runEventScriptBlocks(blocks, cmdlet); //, true);
        }
        
        // 20120209 protected void RunOnSuccessScriptBlocks(HasScriptBlockCmdletBase cmdlet)
        protected internal void RunOnSuccessScriptBlocks(HasScriptBlockCmdletBase cmdlet)
        {
            runTwoScriptBlockCollections(
                Preferences.OnSuccessAction,
                cmdlet.OnSuccessAction,
                cmdlet);
        }
        
        // 20120209 protected void RunOnErrorScriptBlocks(HasScriptBlockCmdletBase cmdlet)
        protected internal void RunOnErrorScriptBlocks(HasScriptBlockCmdletBase cmdlet)
        {
            runTwoScriptBlockCollections(
                Preferences.OnErrorAction,
                cmdlet.OnErrorAction,
                cmdlet);
        }
        
        // 20120209 protected void RunOnSleepScriptBlocks(HasTimeoutCmdletBase cmdlet)
        // 20120312 0.6.11
        //protected internal void RunOnSleepScriptBlocks(HasTimeoutCmdletBase cmdlet)
        protected internal void RunOnSleepScriptBlocks(HasControlInputCmdletBase cmdlet)
        {
            runTwoScriptBlockCollections(
                Preferences.OnSleepAction,
                ((HasTimeoutCmdletBase)cmdlet).OnSleepAction,
                cmdlet);
        }
        
        protected internal void RunWizardScriptBlocks(WizardCmdletBase cmdlet, Wizard wizard)
        {
            runTwoScriptBlockCollections(
                null,
                wizard.StartAction,
                cmdlet);
        }
        
        protected internal void RunWizardStepScriptBlocks(
            WizardCmdletBase cmdlet, 
            WizardStep wizardStep,
            bool forward)
        {
            if (forward) {
                runTwoScriptBlockCollections(
                    null,
                    wizardStep.StepForwardAction,
                    cmdlet);
            } else {
                runTwoScriptBlockCollections(
                    null,
                    wizardStep.StepBackwardAction,
                    cmdlet);
            }
        }
        
        private void runTwoScriptBlockCollections(
            ScriptBlock[] blocks1,
            ScriptBlock[] blocks2,
            HasScriptBlockCmdletBase cmdlet)
        {
            System.Collections.Generic.List<ScriptBlock >  blocks =
                new System.Collections.Generic.List<ScriptBlock > ();
            if (blocks1 != null &&
                blocks1.Length > 0) {
                foreach (ScriptBlock sb in blocks1) {
                    blocks.Add(sb);
                }
            }
            if (blocks2 != null &&
                blocks2.Length > 0) {
                foreach (ScriptBlock sb in blocks2) {
                    blocks.Add(sb);
                }
            }
            runScriptBlocks(blocks, cmdlet, false);
        }
        
        private void runScriptBlocks(System.Collections.Generic.List<ScriptBlock >  blocks,
                                     HasScriptBlockCmdletBase cmdlet,
                                     bool eventHandlers)
        {
            try {
                if (blocks != null &&
                    blocks.Count > 0) {
                    // WriteVerbose(this, "runScriptBlocks 1 fired");
                    foreach (ScriptBlock sb in blocks) {
                        // WriteVerbose(this, "runScriptBlocks 2 fired");
                        if (sb != null) {
                            // WriteVerbose(this, "runScriptBlocks 3 fired");
                            try {
                                if (eventHandlers) {
                                    // WriteVerbose(this, "runScriptBlocks 4 fired");
                                    // runScriptBlock runner = new runScriptBlock(runSBEvent);
                                    // runScriptBlock runner = new runScriptBlock(runSBEvent);
                                    // test
                                    runScriptBlock runner = new runScriptBlock(runSBEvent);
                                    // WriteVerbose(this, "runScriptBlocks 5 fired");
                                    runner(sb, cmdlet.EventSource, cmdlet.EventArgs);
                                    // WriteVerbose(this, "runScriptBlocks 6 fired");
                                } else {
                                    // runScriptBlock runner = new runScriptBlock(runSB);
                                    runScriptBlock runner = new runScriptBlock(runSBAction);
                                    runner(sb, cmdlet.EventSource, cmdlet.EventArgs);
                                }
                            } catch (Exception eInner) {
                                ErrorRecord err = 
                                    new ErrorRecord(
                                        eInner,
                                        "InvokeException",
                                        ErrorCategory.OperationStopped,
                                        sb);
                                err.ErrorDetails = 
                                    new ErrorDetails("Error in " +
                                                     sb.ToString());
                                WriteError(this, err, false);
                            }
                        }
                    }
                }
            } catch (Exception eOuter) {
                WriteError(this, 
                           new ErrorRecord(eOuter, "runScriptBlocks", ErrorCategory.InvalidArgument, null),
                           true);
            }
        }
        #endregion Invoke-UIAScript
        
        //protected internal System.DateTime startDate;
        protected internal System.DateTime startDate { get; set; }
        //protected System.Windows.Automation.AutomationElement _window = null;
        protected AutomationElement _window { get; set; }
        //protected System.Windows.Automation.AutomationElement aeCtrl = null;
        protected AutomationElement aeCtrl { get; set; }
        //protected internal System.Windows.Automation.AutomationElement rootElement;
        protected internal AutomationElement rootElement { get; set; }
        
        #region Get-UIAControl
        public AndCondition[] getControlsConditions(GetControlCollectionCmdletBase cmdlet)
        {
            System.Collections.Generic.List<AndCondition >  conditions = 
                new System.Collections.Generic.List<AndCondition > ();
            if (cmdlet.ControlType != null && cmdlet.ControlType.Length > 0) {
                for (int i = 0; i < cmdlet.ControlType.Length; i++) {
                    WriteVerbose(this, "control type: " + cmdlet.ControlType[i]);
                    conditions.Add(getControlConditions(((GetControlCmdletBase)cmdlet), cmdlet.ControlType[i]));
                }
            } else{
                WriteVerbose(this, "without control type");
                conditions.Add(getControlConditions(((GetControlCmdletBase)cmdlet), ""));
            }
            return conditions.ToArray();
        }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "get")]
        //public AndCondition getControlConditions(GetControlCmdletBase cmdlet, string controlType)
        public AndCondition getControlConditions(HasControlInputCmdletBase cmdlet1, string controlType)
        {
            System.Windows.Automation.ControlType ctrlType = null;
            System.Windows.Automation.AndCondition conditions = null;
            System.Windows.Automation.PropertyCondition condition = null;
            
            GetControlCmdletBase cmdlet = 
                (GetControlCmdletBase)cmdlet1;
            
            //if (cmdlet.ControlType != null && cmdlet.ControlType.Length > 0) {
            if (controlType != null && controlType.Length > 0) {
                WriteVerbose(this, 
                             "getting control with control type = " + 
                             controlType);
                ctrlType = 
                    UIAHelper.GetControlTypeByTypeName(controlType);
                WriteVerbose(cmdlet, "ctrlType = " + ctrlType.ProgrammaticName);
            }
            System.Windows.Automation.PropertyCondition ctrlTypeCondition = null,
                classCondition = null, titleCondition = null, autoIdCondition = null;
            //WriteVerbose(cmdlet, "ctrlType = " + ctrlType.ProgrammaticName);
            int conditionsCounter = 0;
            if (ctrlType != null) {
                ctrlTypeCondition =
                    new System.Windows.Automation.PropertyCondition(
                                System.Windows.Automation.AutomationElement.ControlTypeProperty,
                                ctrlType);
                WriteVerbose(cmdlet, "ControlTypeProperty '" +
                             ctrlType.ProgrammaticName + "' is used");
                conditionsCounter++;
            }
            if (cmdlet.Class != null && cmdlet.Class != "")
            {
                classCondition =
                    new System.Windows.Automation.PropertyCondition(
                                System.Windows.Automation.AutomationElement.ClassNameProperty,
                                cmdlet.Class);
                WriteVerbose(cmdlet, "ClassNameProperty '" + 
                             cmdlet.Class + "' is used");
                conditionsCounter++;
            }
            if (cmdlet.AutomationId != null && cmdlet.AutomationId != "")
            {
                autoIdCondition =
                    new System.Windows.Automation.PropertyCondition(
                                System.Windows.Automation.AutomationElement.AutomationIdProperty,
                                cmdlet.AutomationId);
                WriteVerbose(cmdlet, "AutomationIdProperty '" + 
                             cmdlet.AutomationId + "' is used");
                conditionsCounter++;
            }
            if (cmdlet.Name != null && cmdlet.Name != "") // allow empty name
            {
                titleCondition =
                    new System.Windows.Automation.PropertyCondition(
                                System.Windows.Automation.AutomationElement.NameProperty,
                                cmdlet.Name);
                WriteVerbose(cmdlet, "NameProperty '" + 
                             cmdlet.Name + "' is used");
                conditionsCounter++;
            }

            if (conditionsCounter > 1)
            {
                try {
                    System.Collections.ArrayList l = new System.Collections.ArrayList();
                    if (classCondition != null)l.Add(classCondition);
                    if (ctrlTypeCondition != null)l.Add(ctrlTypeCondition);
                    if (titleCondition != null)l.Add(titleCondition);
                    if (autoIdCondition != null)l.Add(autoIdCondition);
                    System.Type t = typeof(System.Windows.Automation.Condition);
                    System.Windows.Automation.Condition[] conds = 
                        ((System.Windows.Automation.Condition[])l.ToArray(t));
                conditions =
                    new System.Windows.Automation.AndCondition(conds);
                WriteVerbose(cmdlet, "used conditions " + 
                             "ClassName = '" + classCondition.Value + "', " + 
                             "ControlType = '" + ctrlTypeCondition.Value + "', " + 
                             "Name = '" + titleCondition.Value + "', " + 
                             "AutomationId = '" + autoIdCondition.Value + "'");
                } catch (Exception eConditions) {
                    WriteDebug(cmdlet, "conditions related exception " +
                                eConditions.Message);
                }
            } else if (conditionsCounter == 1)
            {
                if (classCondition != null) { condition = classCondition; }
                else if (ctrlTypeCondition != null) { condition = ctrlTypeCondition; }
                else if (titleCondition != null) { condition = titleCondition; }
                else if (autoIdCondition != null) { condition = autoIdCondition; }
                WriteVerbose(cmdlet, "condition " + 
                             condition.GetType().Name + " '" + 
                             condition.Value + "' is used");
            }
            else if (conditionsCounter == 0)
            {
                WriteVerbose(cmdlet, "neither ControlType nor Class nor Name are present");
                //WriteObject(null); //# produce the output
                //return null;
                
                ////return conditions;
                ////return Condition.TrueCondition;
                return (new AndCondition(Condition.TrueCondition,
                                         Condition.TrueCondition));
            }
            try {
                if (conditions != null) {
                    Condition[] tempConditions = conditions.GetConditions();
                    for (int i = 0; i < tempConditions.Length; i++) {
                        WriteVerbose(cmdlet, "condition: " + tempConditions[i].ToString());
                    }
                    //WriteVerbose(cmdlet, "conditions: " +
                    // conditions.GetConditions());
                } else if (condition != null) {
                    WriteVerbose(cmdlet, "conditions (only one): " +
                                 condition.Property.ProgrammaticName + 
                                 " = " + 
                                 condition.Value.ToString());
                    conditions = 
                        new AndCondition(condition,
                                         Condition.TrueCondition);
                }
                return conditions;
            } catch {
                WriteVerbose(cmdlet, "conditions or condition are null");
                //return null;
                return conditions;
            }
        }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "get")]
        //protected void getControl(GetControlCmdletBase cmdlet)
        protected AutomationElement getControl(GetControlCmdletBase cmdlet)
        {
            try {
                aeCtrl = null;
                System.Windows.Automation.AndCondition conditions = null;
                
                conditions = getControlConditions(cmdlet, cmdlet.ControlType);
                Condition[] tempConditions = conditions.GetConditions();
                for (int i = 0; i < tempConditions.Length; i++) {
                    WriteVerbose(cmdlet, "[getting the control] " + tempConditions[i].ToString());
                }
                int processId = 0;
                do {
                    if (conditions != null) { // && condition == null) {
                        if (cmdlet.InputObject != null && 
                            (int)cmdlet.InputObject.Current.ProcessId > 0) {
                            aeCtrl = cmdlet.InputObject.FindFirst(System.Windows.Automation.TreeScope.Descendants,
                                                           conditions);
                        } //else if (UIAutomation.CurrentData.LastResult
                        if (aeCtrl != null && (int)aeCtrl.Current.ProcessId > 0) {
                            WriteVerbose(cmdlet, "[getting the control] aeCtrl = " + aeCtrl.Current.Name);
                        }
                    }
                    //WriteVerbose(cmdlet, "[getting the control] _window = " + _window.Current.Name);
                    if (cmdlet.InputObject != null &&
                        (int)cmdlet.InputObject.Current.ProcessId > 0) {
                        try {
                          WriteVerbose(cmdlet, cmdlet.InputObject.GetType().Name);
                        }
                        catch (Exception e11) {
                            WriteVerbose(cmdlet, e11.Message);
                        }
                        try {
                            WriteVerbose(cmdlet, "[getting the control] _window (cmdlet.InputObject) = " + cmdlet.InputObject.Current.Name);
                        }
                        catch (Exception e22) {
                            WriteVerbose(cmdlet, e22.Message);
                        }
                    } else {
                        WriteVerbose(cmdlet, "cmdlet.InputObject == null");
                    }
                    //processId = _window.Current.ProcessId;
                    if (cmdlet.InputObject != null &&
                        (int)cmdlet.InputObject.Current.ProcessId > 0) {
                        WriteVerbose(cmdlet, "cmdlet.InputObject != null");
                        processId = cmdlet.InputObject.Current.ProcessId;
                    }
                    // if (aeCtrl == null && cmdlet.Title.Length > 0) {
                    if (aeCtrl == null && cmdlet.Name.Length > 0) {
                    // using API
                        WriteVerbose(cmdlet, "[getting the control] using FindWindowEx");
                        aeCtrl =
                            UIAHelper.GetControlByName(
                                cmdlet,
                                cmdlet.InputObject,
                                cmdlet.Name);
                                                        // cmdlet.Title);
                    }
                    
                    if (aeCtrl != null && (int)aeCtrl.Current.ProcessId > 0)
                    {
                        WriteVerbose(cmdlet, "aeCtrl = " + aeCtrl.Current.Name);
                        break;
                    }
                    SleepAndRunScriptBlocks(cmdlet);
                    // System.Threading.Thread.Sleep(Preferences.SleepInterval);
                    ////impossible due to inheritance and the absense of scriptblock here
                    // SleepAndRunScriptBlocks(cmdlet);
                    System.DateTime nowDate = System.DateTime.Now;
                    
                    try {
                        WriteVerbose(cmdlet, "class: '" +
                                     cmdlet.Class + 
                                     "', control type: '" + 
                                     cmdlet.ControlType + 
                                     "' , title: '" +
                                     cmdlet.Name +                                 
                                     // cmdlet.Title +
                                     "' , seconds: " + 
                                     ((nowDate - startDate).TotalSeconds).ToString());
                    } catch { }
                    
                    if ((aeCtrl != null && (int)aeCtrl.Current.ProcessId > 0) || 
                        (nowDate - startDate).TotalSeconds > cmdlet.Timeout / 1000)
                    {
                        if (aeCtrl == null) {
                            ErrorRecord err = 
                                new ErrorRecord(
                                    new Exception(),
                                    "ControlIsNull",
                                    ErrorCategory.OperationTimeout,
                                    aeCtrl);
                            err.ErrorDetails =
                                new ErrorDetails(
                                    CmdletSignature(cmdlet) + "timeout expired for class: ' + " +
                                    cmdlet.Class + 
                                    ", control type: " + 
                                    cmdlet.ControlType + 
                                    ", title: " +
                                    cmdlet.Name);
                                    // cmdlet.Title);
                            UIAHelper.GetDesktopScreenshot(cmdlet, "Get-UIAControl_ControlEqNull", true, 0, 0, 0, 0);
                            WriteError(this, err, true);
                        } else{
                            WriteVerbose(cmdlet, "got the control: " +
                                         aeCtrl);
                        }
                        break;
                    }
                    else{
                        rootElement =
                            System.Windows.Automation.AutomationElement.RootElement;
                        if (processId > 0) {
                        try {
                            System.Windows.Automation.PropertyCondition pIDcondition =
                                new System.Windows.Automation.PropertyCondition(
                                    System.Windows.Automation.AutomationElement.ProcessIdProperty,
                                                processId);
                                //_window =
                                //cmdlet.InputObject =
                                AutomationElement tempElement =
                                    rootElement.FindFirst(System.Windows.Automation.TreeScope.Children,
                                                         pIDcondition);
                                if (tempElement != null && 
                                    (int)tempElement.Current.ProcessId > 0) {
                                    cmdlet.InputObject = tempElement;
                                }
                            } catch {//"process is gone"
                                // get new window
                            }
                        } else {
                            WriteVerbose(cmdlet, "failed to get the process Id");
                            // 20120220
                            //WriteObject(this, null);
                            //return;
                            return null;
                        } //#describe the output
                    }
                } while (cmdlet.Wait);
                if (aeCtrl != null && (int)aeCtrl.Current.ProcessId > 0)
                {
                    WriteVerbose(cmdlet, aeCtrl);
                //} // 20120127
                // if (SetFocus) { aeCtrl.SetFocus(); }
                // 20120208 if (cmdlet.Highlight) { Global.PaintRectangle(aeCtrl); }
                } // 20120127
                // 20120220
                //WriteObject(this, aeCtrl);
                //return;
                return aeCtrl;
            }
            catch (Exception eGetControlException) {
                ErrorRecord err = 
                    new ErrorRecord(
                        new Exception("Failed to get the control"),
                        "UnableToGetControl",
                        ErrorCategory.InvalidResult,
                        aeCtrl);
                err.ErrorDetails = 
                    new ErrorDetails(eGetControlException.Message);
                WriteError(this, err, true);
//WriteVerbose(cmdlet, eGetControlException.Message);
                return null;
            }
// catch {
//WriteVerbose(cmdlet, "unknown exception!!!!!!!!");
// return null;
// }
        }
        #endregion Get-UIAControl
        
        #region Action delegate
        private void runSBEvent(ScriptBlock sb, 
                                AutomationElement src,
                                AutomationEventArgs e)
        {
            // 20120206 Collection<PSObject >  psObjects = null;
            try {
                System.Management.Automation.Runspaces.Runspace.DefaultRunspace =
                    RunspaceFactory.CreateRunspace();
                try {
                    System.Management.Automation.Runspaces.Runspace.DefaultRunspace.Open();
                } catch (Exception e1) {
                    ErrorRecord err = 
                        new ErrorRecord(e1,
                                        "ErrorOnOpeningRunspace",
                                        ErrorCategory.InvalidOperation,
                                        sb);
                    err.ErrorDetails = 
                        new ErrorDetails(
                            "Unable to run a scriptblock:\r\n" + 
                            sb.ToString());
                    WriteError(this, err, false);
                }
                try {
// System.Management.Automation.Runspaces.Runspace.
// DefaultRunspace.SessionStateProxy.SetVariable("src", src);
// System.Management.Automation.Runspaces.Runspace.
// DefaultRunspace.SessionStateProxy.SetVariable("e", e);
// System.Management.Automation.Runspaces.Runspace.
// DefaultRunspace.SessionStateProxy.SetVariable("global:src1", src);
// System.Management.Automation.Runspaces.Runspace.
// DefaultRunspace.SessionStateProxy.SetVariable("global:e1", e);
                    // Pipeline p1 = 
                    // System.Management.Automation.Runspaces.Runspace.
                    // DefaultRunspace.CreateNestedPipeline(sb.ToString(), false);
                    // p1.Input.Write(src);
                    // p1.Input.Write(e);
                    // psObjects =
                    // p1.Invoke();
                    System.Collections.Generic.List<object >  inputParams = 
                        new System.Collections.Generic.List<object > ();
                    inputParams.Add(src);
                    inputParams.Add(e);
                    object[] inputParamsArray = inputParams.ToArray();
                    // psObjects = 
                        sb.InvokeReturnAsIs(inputParamsArray);
                        // sb.Invoke(inputParamsArray);
                    
                } catch (Exception e2) {
                    ErrorRecord err = 
                        new ErrorRecord(e2,
                                        "ErrorInOpenedRunspace",
                                        ErrorCategory.InvalidOperation,
                                        sb);
                    err.ErrorDetails = 
                        new ErrorDetails("Unable to run a scriptblock");
                    WriteError(this, err, true);
                }
// psObjects =
// sb.Invoke();
            } catch (Exception eOuter) {
                ErrorRecord err = 
                    new ErrorRecord(eOuter,
                                    "ErrorInInvokingScriptBlock", //"ErrorinCreatingRunspace",
                                    ErrorCategory.InvalidOperation,
                                    System.Management.Automation.Runspaces.Runspace.DefaultRunspace);
                err.ErrorDetails = 
                    new ErrorDetails("Unable to issue the following command:\r\n" + 
                                     "System.Management.Automation.Runspaces.Runspace.DefaultRunspace = RunspaceFactory.CreateRunspace();" +
                                     "\r\nException raised is\r\n" +
                                     eOuter.Message);
            }
        }
        #endregion Action delegate
        
        #region Action delegate
        private void runSBAction(ScriptBlock sb, 
                                 AutomationElement src,
                                 AutomationEventArgs e)
        {
            Collection<PSObject >  psObjects = null;
            try {
                psObjects =
                    sb.Invoke();
// int counter = 0;
// foreach (PSObject pso in psObjects) {
//  //if pso.
// counter++;
// WriteVerbose("result " + counter.ToString() + ":");
// WriteVerbose(pso.ToString());
//  //WriteObject(pso.TypeNames
// foreach ( string typeName in pso.TypeNames) {
// WriteVerbose(typeName);
// }
// }
            } catch (Exception eOuter) {
                ErrorRecord err = 
                    new ErrorRecord(eOuter,
                                    "ErrorInInvokingScriptBlock",
                                    ErrorCategory.InvalidOperation,
                                    System.Management.Automation.Runspaces.Runspace.DefaultRunspace);
                err.ErrorDetails = 
                    new ErrorDetails(
                        "Unable to issue the following command:\r\n" +
                        sb.ToString() + 
                        "\r\nThe exception raised is\r\n" + 
                        eOuter.Message);
                                     //"System.Management.Automation.Runspaces.Runspace.DefaultRunspace = RunspaceFactory.CreateRunspace();");
                WriteError(err);
            }
        }
        #endregion Action delegate
    
    }
    #region Action delegate
    delegate void runScriptBlock(ScriptBlock sb, 
                                 AutomationElement src, 
                                 AutomationEventArgs e);
    #endregion Action delegate
}
