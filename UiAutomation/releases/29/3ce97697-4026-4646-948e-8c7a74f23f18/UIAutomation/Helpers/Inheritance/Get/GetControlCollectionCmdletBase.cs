/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 02/16/2012
 * Time: 01:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of GetControlCollectionCmdletBase.
    /// </summary>
    public class GetControlCollectionCmdletBase : GetControlCmdletBase
    {
        public GetControlCollectionCmdletBase()
        {
            this.PassThru = false;
        }
        
        #region Parameters
        [Parameter(Mandatory = false)]
        internal new SwitchParameter Wait { get; set; }
        [Alias("Milliseconds")]
        [Parameter(Mandatory = false)]
        internal new int Timeout { get; set; }
        [Parameter(Mandatory = false)]
        internal new int Seconds {
            get{ return Timeout / 1000; } 
            set{ Timeout = value * 1000; }
        }
        
        [Parameter(Mandatory = false)]
        public new string[] ControlType { get; set; }
        
        [Parameter(Mandatory = false)]
        internal new SwitchParameter PassThru { get; set; }
        #endregion Parameters

        
        protected override void BeginProcessing() {
            WriteVerbose(this, "ControlType = " + ControlType);
            WriteVerbose(this, "Class = " + Class);
            WriteVerbose(this, "Name = " + Name);
            WriteVerbose(this, "AutomationId = " + AutomationId);
        }
        
        protected void GetAutomationElements(TreeScope scope)
        {
            if (!this.CheckControl(this)) { return; }
            
            System.Collections.Generic.List<AutomationElement >  searchResults = 
                new System.Collections.Generic.List<AutomationElement > ();
            AutomationElementCollection temporaryResults = null;
            AutomationElement[] outResult;
            
            if (scope == TreeScope.Children ||
                scope == TreeScope.Descendants) {
                WriteVerbose(this, "selected TreeScope." + scope.ToString());
                AndCondition[] conditions = getControlsConditions(this);
                if (conditions != null && conditions.Length > 0) {
                    WriteVerbose(this, "conditions number: " +
                                 conditions.Length.ToString());
                    for (int i = 0; i < conditions.Length; i++) {
                        if (conditions[i] != null) {
                            WriteVerbose(this, conditions[i].GetConditions());
                            temporaryResults =
                                this.InputObject.FindAll(scope,
                                                         conditions[i]);
                            if (temporaryResults.Count > 0) {
                                foreach (AutomationElement element in temporaryResults) {
                                    searchResults.Add(element);
                                }
                            }
                        }
                    }
                } else {
                    WriteVerbose(this, "no conditions. Performing search with TrueCondition");
                    temporaryResults =
                        this.InputObject.FindAll(scope,
                                                 Condition.TrueCondition);
                    if (temporaryResults.Count > 0) {
                        WriteVerbose(this, 
                                     "returned " + 
                                     temporaryResults.Count.ToString() + 
                                     " results");
                        foreach (AutomationElement element in temporaryResults) {
                            searchResults.Add(element);
                        }
                    }
                }
                WriteVerbose(this, "results found: " + searchResults.Count.ToString());
                WriteObject(this, searchResults.ToArray());
            }
            if (scope == TreeScope.Parent ||
                scope == TreeScope.Ancestors) {
                outResult = 
                    UIAHelper.GetParentOrAncestor(this.InputObject, scope);
                WriteObject(this, outResult);
            }
        }
    }
}
