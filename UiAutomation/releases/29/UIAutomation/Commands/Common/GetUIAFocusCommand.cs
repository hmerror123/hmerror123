/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/16/2012
 * Time: 11:11 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands.Common
{
    using System;
    using System.Management.Automation;
    //using System.Runtime.InteropServices;
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of GetUIAFocusCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAFocus")]
    public class GetUIAFocusCommand : HasControlInputCmdletBase
    {
        #region Constructor
        public GetUIAFocusCommand()
        {
        }
        #endregion Constructor
        
        #region Parameters
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!this.CheckControl(this)) { return; }
            
            System.IntPtr controlHandle; // = 
                //IntPtr.Zero;
            controlHandle = NativeMethods.GetFocus();
            if (controlHandle != IntPtr.Zero) {
                WriteVerbose(this, "the handle is gotten");
            } else {
                WriteVerbose(this, "there has not been gotten a handle");
            }
            
//            AutomationElement element =
//                UIAHelper.GetAutomationElementFromHandle(
//                    cmdlet,
//                    element);
            AutomationElement element =
                AutomationElement.FromHandle(controlHandle);
            WriteObject(this, element);
            
//            if (this.PassThru) {
//                WriteObject(this, this.InputObject);
//            } else {
//                WriteObject(this, true);
//            }
        }
    }
}
