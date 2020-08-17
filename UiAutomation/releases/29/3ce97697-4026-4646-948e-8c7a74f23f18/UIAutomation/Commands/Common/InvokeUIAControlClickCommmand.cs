/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 28.01.2012
 * Time: 10:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    // using System.Runtime.InteropServices;
    using System.Windows.Automation;

    /// <summary>
    /// Description of InvokeUIAControlClickCommmand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Invoke, "UIAControlClick")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class InvokeUIAControlClickCommmand : HasControlInputCmdletBase
    {
        #region Constructor
        public InvokeUIAControlClickCommmand()
        {
            RightClick = false;
            MidClick = false;
            Alt = false;
            Shift = false;
            Ctrl = false;
            DoubleClick = false;
        }
        #endregion Constructor
        
        #region Parameters
        [Parameter(Mandatory = false)]
        public SwitchParameter RightClick { get; set; }
        [Parameter(Mandatory = false)]
        public SwitchParameter MidClick { get; set; }
        [Parameter(Mandatory = false)]
        public SwitchParameter Alt { get; set; }
        [Parameter(Mandatory = false)]
        public SwitchParameter Shift { get; set; }
        [Parameter(Mandatory = false)]
        public SwitchParameter Ctrl { get; set; }
        [Parameter(Mandatory = false)]
        public SwitchParameter DoubleClick { get; set; }
        [Parameter(Mandatory = false)]
        public int X { get; set; }
        [Parameter(Mandatory = false)]
        public int Y { get; set; }
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!this.CheckControl(this)) { return; }
            
            ClickControl(
                this,
                this.InputObject,
                this.RightClick,
                this.MidClick,
                this.Alt,
                this.Shift,
                this.Ctrl,
                false,
                this.DoubleClick,
                this.X,
                this.Y);

            if (this.PassThru) {
                WriteObject(this, this.InputObject);
            } else {
                WriteObject(this, true);
            }
        }
    }
}
