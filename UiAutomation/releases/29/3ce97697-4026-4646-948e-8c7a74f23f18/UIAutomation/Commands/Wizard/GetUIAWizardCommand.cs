/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/23/2012
 * Time: 12:32 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of GetUIAWizardCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAWizard")]
    public class GetUIAWizardCommand : WizardContainerCmdletBase
    {
        public GetUIAWizardCommand()
        {
        }
        
        protected override void BeginProcessing()
        {
//WriteVerbose(this, WizardCollection.Wizards.Count.ToString());
            Wizard wzd = GetWizard(Name);
//WriteVerbose(this, WizardCollection.Wizards.Count.ToString());
            if (wzd != null) {
//WriteVerbose(this, "00001");

                WriteObject(this, wzd);
//WriteVerbose(this, "00002");
            } else {
                ErrorRecord err = 
                    new ErrorRecord(
                        new Exception("Can't get the wizard you asked for"),
                        "NoWizard",
                        ErrorCategory.InvalidArgument,
                        Name);
                err.ErrorDetails = 
                    new ErrorDetails(
                        "Failed to get the wizard you asked for");
//WriteVerbose(this, "00003");
                ThrowTerminatingError(err);
//WriteVerbose(this, "00004");
            }
//WriteVerbose(this, "00005");
        }
    }
}
