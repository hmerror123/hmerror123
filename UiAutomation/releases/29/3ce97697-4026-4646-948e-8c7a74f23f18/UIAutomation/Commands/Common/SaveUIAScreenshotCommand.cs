/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17.01.2012
 * Time: 11:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    using System.Runtime.InteropServices;
    using System.Windows.Automation;
    
    /// <summary>
    /// Description of SaveUIAScreenshotCommand.
    /// </summary>
    //[Cmdlet(VerbsData.Save, "UIAScreenshot")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class ScreenshotCmdletBase : GetControlCmdletBase //HasControlInputCmdletBase
    {
        #region Constructor
        public ScreenshotCmdletBase()
        {
        }
        #endregion Constructor
        
        #region Parameters
        [Parameter(Mandatory = false)]
        public string Description { get; set; }
        [Parameter(Mandatory = false)]
        public int Left {get; set; }
        [Parameter(Mandatory = false)]
        public int Top {get; set; }
        [Parameter(Mandatory = false)]
        public int Height {get; set; }
        [Parameter(Mandatory = false)]
        public int Width {get; set; }
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            //if (this.InputObject == null ||
            // !(this.InputObject is AutomationElement)) {
            bool save = false;
            if (this.GetType().Name == "SaveUIAScreenshotCommand") {
                save = true;
            }
            
            UIAHelper.GetDesktopScreenshot(this,
                                           this.Description,
                                           save,
                                           Left,
                                           Top,
                                           Height,
                                           Width);
            //TMX.
            //} else {
            // UIAHelper.GetControlScreenshot(this.InputObject, this.Description);
            //}
        }
    }
    
    /// <summary>
    /// Description of SaveUIAScreenshotCommand.
    /// </summary>
    [Cmdlet(VerbsData.Save, "UIAScreenshot")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class SaveUIAScreenshotCommand : ScreenshotCmdletBase //GetControlCmdletBase //HasControlInputCmdletBase
    {
        #region Constructor
        public SaveUIAScreenshotCommand()
        {
        }
        #endregion Constructor
    }
    
    /// <summary>
    /// Description of GetUIAScreenshotCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAScreenshot")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAScreenshotCommand : ScreenshotCmdletBase //GetControlCmdletBase //HasControlInputCmdletBase
    {
        #region Constructor
        public GetUIAScreenshotCommand()
        {
        }
        #endregion Constructor
    }
}
