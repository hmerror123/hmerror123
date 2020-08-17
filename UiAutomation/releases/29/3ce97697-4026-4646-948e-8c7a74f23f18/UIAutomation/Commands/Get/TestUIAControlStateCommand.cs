﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 17/02/2012
 * Time: 12:23 a.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;
    
    //using System.Windows.Automation;
    //using System.Xml.Serialization.Configuration;

    /// <summary>
    /// Description of TestUIAControlStateCommand.
    /// </summary>
    [Cmdlet(VerbsDiagnostic.Test, "UIAControlState")]
    [OutputType(new[]{ typeof(object) })]
    public class TestUIAControlStateCommand : GetControlStateCmdletBase
    {
        #region Constructor
        public TestUIAControlStateCommand()
        {
        }
        #endregion Constructor
        
        #region Parameters
        [Parameter]
        internal new int Timeout { get; set; }
        #endregion Parameters
        
        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            if (!this.CheckControl(this)) { return; }
            
            bool result = 
                testControlProperties(
                    this.SearchCriteria);
            if (result) {
                WriteObject(this, true);
            } else {
                WriteObject(this, false);
            }
        }
    }
}
