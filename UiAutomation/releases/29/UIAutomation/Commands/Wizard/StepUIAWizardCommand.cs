/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08/02/2012
 * Time: 02:30 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of StepUIAWizardCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Step, "UIAWizard")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class StepUIAWizardCommand : WizardRunCmdletBase
    //internal class StepUIAWizardCommand : WizardCmdletBase
    {
        public StepUIAWizardCommand()
        {
            Forward = true;
        }
        
        
        #region Parameters
        [Parameter]
        public SwitchParameter Forward { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            WriteVerbose(this, "Timeout = " + Timeout.ToString());
            startDate = System.DateTime.Now;
        }
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            // getting the step the user ordered to run
            if (InputObject != null && InputObject is Wizard) {
                WizardStep stepToRun = null;
                WriteVerbose(this, "searching for a step");
                foreach (WizardStep step in InputObject.Steps) {
                    WriteVerbose(this, "found step: " + step.Name);
                    if (step.Name == Name) {
                        WriteVerbose(this, "found the step we've been searching for");
                        stepToRun = step;
                        break;
                    }
                }
                if (stepToRun == null) {
                    ErrorRecord err = 
                        new ErrorRecord(
                            new Exception("Couldn't find the step"),
                            "StepNotFound",
                            ErrorCategory.InvalidArgument,
                            stepToRun.Name);
                    err.ErrorDetails = 
                        new ErrorDetails(
                            "Failed to find the step");
                    WriteError(this, err, true);
                }
                
                bool result = false;
                do {
                    WriteVerbose(this, "checking controls' properties");
                    result = 
                        testControlProperties(
                            stepToRun.SearchCriteria);
                    if (result) {
                        WriteVerbose(this, "control state is confirmed");
                        //WriteObject(this, true);
                        //return;
                    } else {
                        WriteVerbose(this, "control state is not yet confirmed. Checking the timeout");
                        SleepAndRunScriptBlocks(this);
                        // wait until timeout expires or the state will be confirmed as valid
                        System.DateTime nowDate = 
                            System.DateTime.Now;
                        if ((nowDate - startDate).TotalSeconds > this.Timeout / 1000) {
                            //WriteObject(this, false);
                            //result = true;
                            //return;
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
                        }
                    }
                } while (!result);
                
                WriteVerbose(this, "running script blocks");
                RunWizardStepScriptBlocks(this, stepToRun, Forward);
//WriteVerbose(this, "018");
                if (PassThru) {
//WriteVerbose(this, "019");
                    WriteObject(this, InputObject);
                } else {
//WriteVerbose(this, "020");
                    WriteObject(this, true);
                }
            } else {
//WriteVerbose(this, "021");
                ErrorRecord err = 
                    new ErrorRecord(
                        new Exception("The wizard object you provided is not valid"),
                        "WrongWizardObject",
                        ErrorCategory.InvalidArgument,
                        InputObject);
                err.ErrorDetails = 
                    new ErrorDetails(
                        "The wizard object you provided is not valid");
                WriteError(this, err, true);
            }
        }
        
    }
}
