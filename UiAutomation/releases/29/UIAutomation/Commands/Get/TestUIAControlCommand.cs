/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17/02/2012
 * Time: 12:23 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Management.Automation;
using System.Windows.Automation;

//using System.Windows.Automation;
//using System.Xml.Serialization.Configuration;

namespace UIAutomation.Commands
{
	/// <summary>
	/// Description of TestUIAControlCommand.
	/// </summary>
	[Cmdlet(VerbsDiagnostic.Test, "UIAControl")]
    [OutputType(new[]{ typeof(object) })]
    public class TestUIAControlCommand : GetControlCmdletBase
	{
    	#region Constructor
		public TestUIAControlCommand()
		{
		}
        #endregion Constructor
        
        #region Parameters
        [Parameter(Mandatory=false)]
        internal new string Class { get; set; }
        [Parameter(Mandatory=false)]
        internal new string Name { get; set; }
        [Parameter(Mandatory=false)]
        internal new string ControlType { get; set; }
        [Parameter(Mandatory=false)]
        internal new string AutomationId { get; set; }
		[Parameter(Mandatory=true)]
		[ValidateNotNullOrEmpty]
		public System.Collections.Hashtable[] SearchCriteria { get; set; }
        #endregion Parameters
        
        protected override void ProcessRecord()
        {
        	if (!base.CheckControl(this)) return;
        	
        	testControlProperties();
        }
        
        private void testControlProperties()
        {
			for (int i = 0; i < SearchCriteria.Length; i++){
        		this.Class = string.Empty;
        		this.ControlType = string.Empty;
        		this.Name = string.Empty;
        		this.AutomationId = string.Empty;
        		System.Collections.Generic.Dictionary<string, string> dict = 
        			new System.Collections.Generic.Dictionary<string, string>();
        		foreach(string key1 in SearchCriteria[i].Keys){
        			WriteVerbose(this, "found key: " + key1);
        			if (key1.ToUpper()=="CLASS"){
        				base.Class = SearchCriteria[i][key1].ToString();
        				WriteVerbose(this, "Class = " + this.Class);
        			} else 
        			if (key1.ToUpper()=="CONTROLTYPE"){
        				base.ControlType = SearchCriteria[i][key1].ToString();
        				WriteVerbose(this, "ControlType = " + this.ControlType);
        			} else 
        			if (key1.ToUpper()=="NAME"){
        				base.Name = SearchCriteria[i][key1].ToString();
        				WriteVerbose(this, "Name = " + this.Name);
        			} else 
        			if (key1.ToUpper()=="AUTOMATIONID"){
        				base.AutomationId = SearchCriteria[i][key1].ToString();
        				WriteVerbose(this, "AutomationId = " + this.AutomationId);
        			} //else {
        			dict.Add(key1, SearchCriteria[i][key1].ToString());
        			WriteVerbose(this, "added to the dictionary: " + 
        			             key1 + " = " + dict[key1].ToString());
        			//}
        		}
        		AutomationElement elementToWorkWith = getControl(this);
    			if (elementToWorkWith==null){
    				//elementToWorkWith.Current.AcceleratorKey
    				//elementToWorkWith.Current.AccessKey
    				//elementToWorkWith.Current.FrameworkId
    				//elementToWorkWith.Current.HasKeyboardFocus
    				//elementToWorkWith.Current.HelpText
    				//elementToWorkWith.Current.IsContentElement
    				//elementToWorkWith.Current.IsControlElement
    				//elementToWorkWith.Current.IsEnabled
    				//elementToWorkWith.Current.IsKeyboardFocusable
    				//elementToWorkWith.Current.IsOffscreen
    				//elementToWorkWith.Current.IsPassword
    				//elementToWorkWith.Current.IsRequiredForForm
    				//elementToWorkWith.Current.ItemStatus
    				//elementToWorkWith.Current.ItemType
    				//elementToWorkWith.Current.LabeledBy
    				//elementToWorkWith.Current.LocalizedControlType
    				//elementToWorkWith.Current.NativeWindowHandle
    				//elementToWorkWith.Current.Orientation
    				//elementToWorkWith.Current.ProcessId
    				WriteVerbose(this, "couln't get the control");
    				WriteObject(this, false);
    				return;
    			} else {
    				foreach(string key in dict.Keys){
        				WriteVerbose(this, "Key = " + key + "; Value = " + dict[key].ToString());
    					string keyValue = dict[key].ToUpper();
    					switch (key.ToUpper()){
    						case "ACCELERATORKEY":
    							if (elementToWorkWith.Current.AcceleratorKey.ToUpper()!=keyValue){
    								WriteObject(this, false);
    								return;
    							}
    							break;
    						case "ACCESSKEY":
    							if (elementToWorkWith.Current.AccessKey.ToUpper()!=keyValue){
    								WriteObject(this, false);
    								return;
    							}
    							break;
    						case "AUTOMATIONID":
    							if (elementToWorkWith.Current.AutomationId.ToUpper()!=keyValue){
    								WriteObject(this, false);
    								return;
    							}
    							break;
    						case "CLASS":
    						case "CLASSNAME":
    							if (elementToWorkWith.Current.ClassName.ToUpper()!=keyValue){
    								WriteObject(this, false);
    								return;
    							}
    							break;
//    						case "CONTROLTYPE":
//    							if (elementToWorkWith.Current.ClassName.ToUpper()!=keyValue){
//    								WriteObject(this, false);
//    								return;
//    							}
//    							break;
    						case "FRAMEWORKID":
    							if (elementToWorkWith.Current.FrameworkId.ToUpper()!=keyValue){
    								WriteObject(this, false);
    								return;
    							}
    							break;
    						case "HASKEYBOARDFOCUS":
    							if (elementToWorkWith.Current.HasKeyboardFocus.ToString().ToUpper()!=keyValue){
    								WriteObject(this, false);
    								return;
    							}
    							break;
    						case "HELPTEXT":
    							if (elementToWorkWith.Current.HelpText.ToUpper()!=keyValue){
    								WriteObject(this, false);
    								return;
    							}
    							break;
    						case "ISCONTENTELEMENT":
    							if (elementToWorkWith.Current.IsContentElement.ToString().ToUpper()!=keyValue){
    								WriteObject(this, false);
    								return;
    							}
    							break;
    						case "ISCONTROLELEMENT":
    							if (elementToWorkWith.Current.IsControlElement.ToString().ToUpper()!=keyValue){
    								WriteObject(this, false);
    								return;
    							}
    							break;
    						case "ISENABLED":
    							if (elementToWorkWith.Current.IsEnabled.ToString().ToUpper()!=keyValue){
    								WriteObject(this, false);
    								return;
    							}
    							break;
    						case "ISKEYBOARDFOCUSABLE":
    							if (elementToWorkWith.Current.IsKeyboardFocusable.ToString().ToUpper()!=keyValue){
    								WriteObject(this, false);
    								return;
    							}
    							break;
    						case "ISOFFSCREEN":
    							if (elementToWorkWith.Current.IsOffscreen.ToString().ToUpper()!=keyValue){
    								WriteObject(this, false);
    								return;
    							}
    							break;
    						case "ISPASWORD":
    							if (elementToWorkWith.Current.IsPassword.ToString().ToUpper()!=keyValue){
    								WriteObject(this, false);
    								return;
    							}
    							break;
    						case "ISREQUIREDFORFORM":
    							if (elementToWorkWith.Current.IsRequiredForForm.ToString().ToUpper()!=keyValue){
    								WriteObject(this, false);
    								return;
    							}
    							break;
    						case "ITEMSTATUS":
    							if (elementToWorkWith.Current.ItemStatus.ToUpper()!=keyValue){
    								WriteObject(this, false);
    								return;
    							}
    							break;
    						case "ITEMTYPE":
    							if (elementToWorkWith.Current.ItemType.ToUpper()!=keyValue){
    								WriteObject(this, false);
    								return;
    							}
    							break;
//        						case "LABELEDBY":
//        							if (elementToWorkWith.Current.la!=keyValue){
//        								WriteObject(this, false);
//        								return;
//        							}
//        							break;
							case "LOCALIZEDCONTROLTYPE":
    							if (elementToWorkWith.Current.LocalizedControlType.ToUpper()!=keyValue){
    								WriteObject(this, false);
    								return;
    							}
    							break;
							case "NAME":
    							if (elementToWorkWith.Current.Name.ToUpper()!=keyValue){
    								WriteObject(this, false);
    								return;
    							}
    							break;
    						case "NATIVEWINDOWHANDLE":
    							if (elementToWorkWith.Current.NativeWindowHandle.ToString()!=keyValue){
    								WriteObject(this, false);
    								return;
    							}
    							break;
//        						case "ORIENTATION":
//        							if (elementToWorkWith.Current.o!=keyValue){
//        								WriteObject(this, false);
//        								return;
//        							}
//        							break;
							case "PROCESSID":
    							if (elementToWorkWith.Current.ProcessId.ToString()!=keyValue){
    								WriteObject(this, false);
    								return;
    							}
    							break;
    						default:
    							ErrorRecord err = 
    								new ErrorRecord(new Exception("Wrong AutomationElement parameter is provided"),
    								                "WrongParameter",
    								                ErrorCategory.InvalidArgument,
    								                key);
    							ThrowTerminatingError(err);
    							break;
    					}
    				}
    			}
        	}
        	WriteObject(this, true);
        }
	}
}
