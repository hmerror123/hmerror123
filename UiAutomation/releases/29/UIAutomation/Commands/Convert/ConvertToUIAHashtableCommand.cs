/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 2/26/2012
 * Time: 10:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of ConvertToUIAHashtableCommand.
    /// </summary>
    [Cmdlet(VerbsData.ConvertTo, "UIAHashtable")]
    public class ConvertToUIAHashtableCommand : ConvertCmdletBase
    {
        /// <summary>
        ///  /// </summary>
        public ConvertToUIAHashtableCommand()
        {
        }
        
        #region Parameters
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            // if (!this.CheckControl(this)) { return; }
            if (!this.CheckControl(this)) { return; }

            System.Collections.Hashtable hashtable = 
                new System.Collections.Hashtable();
            hashtable.Add("Name", this.InputObject.Current.Name);
            hashtable.Add("AutomationId", this.InputObject.Current.AutomationId);
            hashtable.Add("ControlType", this.InputObject.Current.ControlType.ProgrammaticName);
            hashtable.Add("Class", this.InputObject.Current.ClassName);
            hashtable.Add("AcceleratorKey", this.InputObject.Current.AcceleratorKey);
            hashtable.Add("AccessKey", this.InputObject.Current.AccessKey);
            hashtable.Add("BoundingRectangle", this.InputObject.Current.BoundingRectangle.ToString());
            hashtable.Add("FrameworkId", this.InputObject.Current.FrameworkId);
            hashtable.Add("HasKeyboardFocus", this.InputObject.Current.HasKeyboardFocus.ToString());
            hashtable.Add("HelpText", this.InputObject.Current.HelpText);
            hashtable.Add("IsContentElement", this.InputObject.Current.IsContentElement.ToString());
            hashtable.Add("IsControlElement", this.InputObject.Current.IsControlElement.ToString());
            hashtable.Add("IsEnabled", this.InputObject.Current.IsEnabled.ToString());
            hashtable.Add("IsKeyboardFocusable", this.InputObject.Current.IsKeyboardFocusable.ToString());
            hashtable.Add("IsOffscreen", this.InputObject.Current.IsOffscreen.ToString());
            hashtable.Add("IsPassword", this.InputObject.Current.IsPassword.ToString());
            hashtable.Add("IsRequiredForForm", this.InputObject.Current.IsRequiredForForm.ToString());
            hashtable.Add("ItemStatus", this.InputObject.Current.ItemStatus);
            hashtable.Add("ItemType", this.InputObject.Current.ItemType);
            //hashtable.Add("LabeledBy", this.InputObject.Current.LabeledBy);
            hashtable.Add("LocalizedControlType", this.InputObject.Current.LocalizedControlType);
            hashtable.Add("NativeWindowHandle", this.InputObject.Current.NativeWindowHandle.ToString());
            hashtable.Add("Orientation", this.InputObject.Current.Orientation.ToString());
            hashtable.Add("ProcessId", this.InputObject.Current.ProcessId.ToString());
            WriteObject(this, hashtable);
        }
    }
    
    /// <summary>
    /// Description of ConvertToUIASearchCriteriaCommand.
    /// </summary>
    [Cmdlet(VerbsData.ConvertTo, "UIASearchCriteria")]
    public class ConvertToUIASearchCriteriaCommand : ConvertCmdletBase
    {
        public ConvertToUIASearchCriteriaCommand()
        {
        }
        
        #region Parameters
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!this.CheckControl(this)) { return; }

            string result = "@{";
            result += "Name=" + this.propertyToString(this.InputObject.Current.Name);
            result += ";AutomationId=" + this.propertyToString(this.InputObject.Current.AutomationId);
            result += ";ControlType=" + this.propertyToString(this.InputObject.Current.ControlType.ProgrammaticName.Substring(12));
            result += ";Class=" + this.propertyToString(this.InputObject.Current.ClassName);
            result += ";AcceleratorKey=" + this.propertyToString(this.InputObject.Current.AcceleratorKey);
            result += ";AccessKey=" + this.propertyToString(this.InputObject.Current.AccessKey);
            result += ";BoundingRectangle=" + this.propertyToString(this.InputObject.Current.BoundingRectangle.ToString());
            result += ";FrameworkId=" + this.propertyToString(this.InputObject.Current.FrameworkId);
            result += ";HasKeyboardFocus=" + this.propertyToString(this.InputObject.Current.HasKeyboardFocus.ToString());
            result += ";HelpText=" + this.propertyToString(this.InputObject.Current.HelpText);
            result += ";IsContentElement=" + this.propertyToString(this.InputObject.Current.IsContentElement.ToString());
            result += ";IsControlElement=" + this.propertyToString(this.InputObject.Current.IsControlElement.ToString());
            result += ";IsEnabled=" + this.propertyToString(this.InputObject.Current.IsEnabled.ToString());
            result += ";IsKeyboardFocusable=" + this.propertyToString(this.InputObject.Current.IsKeyboardFocusable.ToString());
            result += ";IsOffscreen=" + this.propertyToString(this.InputObject.Current.IsOffscreen.ToString());
            result += ";IsPassword=" + this.propertyToString(this.InputObject.Current.IsPassword.ToString());
            result += ";IsRequiredForForm=" + this.propertyToString(this.InputObject.Current.IsRequiredForForm.ToString());
            result += ";ItemStatus=" + this.propertyToString(this.InputObject.Current.ItemStatus);
            result += ";ItemType=" + this.propertyToString(this.InputObject.Current.ItemType);
            //result += ";LabeledBy=" + this.propertyToString(this.InputObject.Current.LabeledBy;
            result += ";LocalizedControlType=" + this.propertyToString(this.InputObject.Current.LocalizedControlType);
            result += ";NativeWindowHandle=" + this.propertyToString(this.InputObject.Current.NativeWindowHandle.ToString());
            result += ";Orientation=" + this.propertyToString(this.InputObject.Current.Orientation.ToString());
            result += ";ProcessId=" + this.propertyToString(this.InputObject.Current.ProcessId.ToString());
            result += "}";
            WriteObject(this, result);
        }
        
        private string propertyToString(object property)
        {
            string result = "\"\"";
            string tempResult = 
                property.ToString();
            if (tempResult.ToUpper() == "TRUE") {
                tempResult = "$true";
            }
            if (tempResult.ToUpper() == "FALSE") {
                tempResult = "$false";
            }
            if (tempResult != "$true" && tempResult != "$false" && tempResult != string.Empty) {
                tempResult = 
                    "\"" + 
                    tempResult + 
                    "\"";
            }
            if (tempResult != null && tempResult.Length > 0) {
                result = tempResult;
            }
            return result;
        }
    }
}
