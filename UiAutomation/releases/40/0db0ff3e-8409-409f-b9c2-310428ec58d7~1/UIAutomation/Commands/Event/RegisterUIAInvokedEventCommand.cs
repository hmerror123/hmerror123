﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 20/01/2012
 * Time: 09:50 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Management.Automation;
using System.Windows.Automation;

namespace UIAutomation.Commands
{
    /// <summary>
    /// Description of RegisterUIAInvokedEventCommand.
    /// </summary>
    [Cmdlet(VerbsLifecycle.Register, "UIAInvokedEvent")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class RegisterUIAInvokedEventCommand : EventCmdletBase
    {
        #region Constructor
        public RegisterUIAInvokedEventCommand()
        {
            base.AutomationEventType = InvokePattern.InvokedEvent;
            base.AutomationEventHandler = OnUIAutomationEvent;
        }
        #endregion Constructor
    }
}
