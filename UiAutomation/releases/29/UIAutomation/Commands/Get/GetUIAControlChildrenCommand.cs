/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 01.02.2012
 * Time: 12:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Management.Automation;
using System.Windows.Automation;

namespace UIAutomation.Commands
{
    /// <summary>
    /// Description of GetUIAControlChildrenCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAControlChildren")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAControlChildrenCommand : GetControlCollectionCmdletBase //GetUIAControlCommand
    {
        #region Constructor
        public GetUIAControlChildrenCommand()
        {
        }
        #endregion Constructor
        
        #region Parameters
        [Parameter(Mandatory=false)]
        internal new SwitchParameter Wait { get; set; }
        [Alias("Milliseconds")]
        [Parameter(Mandatory=false)]
        internal new int Timeout { get; set; }
        [Parameter(Mandatory=false)]
        internal new int Seconds {
            get{ return Timeout / 1000; } 
            set{ Timeout = value * 1000; }
        }
        
//        [Parameter(Mandatory=false)]
//        public new string[] ControlType { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing(){
            WriteVerbose(this, "ControlType = " + ControlType);
            WriteVerbose(this, "Class = " + Class);
            WriteVerbose(this, "Name = " + Name);
            WriteVerbose(this, "AutomationId = " + AutomationId);
        }
        
        protected override void ProcessRecord()
        {
//            if (!base.CheckControl(this)) return;
//            AndCondition[] conditions = getControlsConditions(this);
//            AutomationElementCollection result = null;
//            if (conditions!=null){
//                result = 
//                    this.InputObject.FindAll(TreeScope.Children,
//                                             conditions);
//            } else {
//                result =
//                    this.InputObject.FindAll(TreeScope.Children,
//                                             Condition.TrueCondition);
//            }
//            WriteObject(this, result);

            if (!base.CheckControl(this)) return;
            AndCondition[] conditions = getControlsConditions(this);
            AutomationElementCollection result = null;
            if (conditions!=null){
            	for (int i = 0; i < conditions.Length; i++){
                	result = 
                    	this.InputObject.FindAll(TreeScope.Children,
                		                         conditions[i]);
                	WriteObject(this, result);
            	}
            } else {
                result =
                    this.InputObject.FindAll(TreeScope.Descendants,
                                             Condition.TrueCondition);
                WriteObject(this, result);
            }
        }
    }
}
