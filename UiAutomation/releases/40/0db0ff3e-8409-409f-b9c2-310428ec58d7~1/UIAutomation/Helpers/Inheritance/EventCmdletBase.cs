/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 20/01/2012
 * Time: 09:29 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Management.Automation;
using System.Windows.Automation;

namespace UIAutomation
{
    /// <summary>
    /// Description of HasScriptBlockCmdletBase.
    /// </summary>
    //[Cmdlet(VerbsLifecycle.Register, "UIADummyEvent")]
    public class EventCmdletBase: HasControlInputCmdletBase
    {
        #region Constructor
        public EventCmdletBase()
        {
            this.InputObject = CurrentData.CurrentWindow;
            this.AutomationEventType = null;
            this.AutomationProperty = null;
            this.AutomationEventHandler = null;
            this.AutomationPropertyChangedEventHandler = null;
            this.StructureChangedEventHandler = null;
        }
        #endregion Constructor

        #region Parameters
        [Parameter(Mandatory=false)]
        internal new SwitchParameter OnErrorScreenShot { get; set; }
//        [Parameter(Mandatory=false)]
//        public new ScriptBlock[] EventAction { get; set; }
        #endregion Parameters
        
        #region Properties
        #endregion Properties
        
        protected override void ProcessRecord()
        {
            if (this.InputObject==null) return;
            //WriteVerbose(this,
            //             "subscribing to the event " + 
            //             this.AutomationEventType.ProgrammaticName);
            SubscribeToEvents(this,
                              this.InputObject, 
                              this.AutomationEventType,
                              this.AutomationProperty);
        }
    }
}