/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/11/2012
 * Time: 8:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of GetUIAControlByWin32ApiCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAControlByWin32Api")]
    public class GetUIAControlByWin32ApiCommand : GetControlCmdletBase
    {
        public GetUIAControlByWin32ApiCommand()
        {
        }
        
        #region Parameters
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty()]
        public new string Name { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
            WriteVerbose(this, "checking the container control");
            
            if (!this.CheckControl(this)) { return; }
            
            if (this.Name == null || this.Name == string.Empty || this.Name.Length == 0){
                WriteVerbose(this, "the Name parameter is null or an empty string");
                ErrorRecord err = 
                    new ErrorRecord(
                        new Exception("The Name parameter is null or empty"),
                        "EmptyParameter",
                        ErrorCategory.InvalidArgument,
                        null);
                err.ErrorDetails = 
                    new ErrorDetails("The Name parameter is null or empty");
                WriteVerbose(this, "exiting");
                WriteError(this, err, true);
            }
            AutomationElement element = 
                UIAHelper.GetControlByName(
                    this,
                    this.InputObject,
                    this.Name);
            if (element == null){
                WriteVerbose(this, "the automation element returned from FindWindowEx is null");
                ErrorRecord err1 = 
                    new ErrorRecord(
                        new Exception(
                            "Unable to get the control with name '" + 
                            this.Name + 
                            "'"),
                        "FailedToGetControl",
                        ErrorCategory.InvalidResult,
                        this.InputObject);
                err1.ErrorDetails = 
                    new ErrorDetails(
                        "Unable to get the control with name '" + 
                        this.Name +
                        "'");
                WriteVerbose(this, "exiting");
                WriteError(this, err1, true);
            } else {
                WriteVerbose(this, "the control was captured");
                WriteObject(this, element);
            }
        }
        
    }
}
