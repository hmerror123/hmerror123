﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 22/02/2012
 * Time: 05:28 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of WaitUIAControlStateCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Wait, "UIAControlState")]
    [OutputType(new[]{ typeof(object) })]
    public class WaitUIAControlStateCommand : GetControlStateCmdletBase
    {
        public WaitUIAControlStateCommand()
        {
        }
        
        #region Parameters
        #endregion Parameters
        
        protected override void BeginProcessing() {
            WriteVerbose(this, "Timeout = " + Timeout.ToString());
            
            startDate = System.DateTime.Now;
            // 20120208 if (Highlight) { Global.MinimizeRectangle(); }
        }
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!this.CheckControl(this)) { return; }
            
            bool result = false;
            do {
                result = 
                    testControlProperties(
                        this.SearchCriteria);
                if (result) {
                    WriteObject(this, true);
                    return;
                } else {
                    SleepAndRunScriptBlocks(this);
                    // wait until timeout expires or the state will be confirmed as valid
                    System.DateTime nowDate = 
                        System.DateTime.Now;
                    if ((nowDate - startDate).TotalSeconds > Timeout / 1000) {
                        //WriteObject(this, false);
                        result = true;
                        //write
                        //return;
                    }
                }
            } while (!result);
            //WriteObject(this, false);
            ErrorRecord err = 
                new ErrorRecord(
                    new Exception("Timeout expired"),
                    "TimeoutExpired",
                    ErrorCategory.OperationTimeout,
                    this.InputObject);
            err.ErrorDetails = 
                new ErrorDetails(
                    "Timeout expired");
            WriteError(this, err, true);
            return;
        }
    }
}
