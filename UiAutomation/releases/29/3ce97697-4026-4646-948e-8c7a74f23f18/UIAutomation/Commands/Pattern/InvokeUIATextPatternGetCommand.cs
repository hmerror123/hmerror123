/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/6/2012
 * Time: 11:30 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    
    /// <summary>
    /// Description of InvokeUIATextPatternGetCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIATextPatternGet")]
    public class InvokeUIATextPatternGetCommand : PatternCmdletBase
    { public InvokeUIATextPatternGetCommand() 
        { 
            WhatToDo = "TextGet"; 
            this.PassThru = false;
            this.TextLength = -1;
        }
        
        [Parameter]
        internal new SwitchParameter PassThru { get; set; }
        [Parameter]
        public int TextLength { get; set; }
    }
    
    /// <summary>
    /// Description of SetUIADocumentRangeTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIADocumentRangeText")]
    [OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIADocumentRangeTextCommand : InvokeUIATextPatternGetCommand
    { public GetUIADocumentRangeTextCommand() { } }
    
    /// <summary>
    /// Description of SetUIAEditRangeTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAEditRangeText")]
    [OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAEditRangeTextCommand : InvokeUIATextPatternGetCommand
    { public GetUIAEditRangeTextCommand() { } }
    
    /// <summary>
    /// Description of SetUIATextRangeTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIATextRangeText")]
    [OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIATextRangeTextCommand : InvokeUIATextPatternGetCommand
    { public GetUIATextRangeTextCommand() { } }
    
    /// <summary>
    /// Description of SetUIAToolTipRangeTextCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAToolTipRangeText")]
    [OutputType(typeof(bool))]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAToolTipRangeTextCommand : InvokeUIATextPatternGetCommand
    { public GetUIAToolTipRangeTextCommand() { } }
}
