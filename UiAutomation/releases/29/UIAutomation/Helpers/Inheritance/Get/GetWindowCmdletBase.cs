/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 19/01/2012
 * Time: 11:32 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;
    using System.Diagnostics;

    /// <summary>
    /// Description of GetWindowCmdletBase.
    /// </summary>
    public class GetWindowCmdletBase : GetCmdletBase
    {
        #region Constructor
        public GetWindowCmdletBase()
        {
            this.ProcessName = String.Empty;
            // Title = String.Empty;
            this.Name = String.Empty;
            this.ProcessId = 0;
            this.InputObject = null;
        }
        #endregion Constructor
        
        #region Parameters
        [Parameter(Mandatory = false)]
        [Alias("pn")]
        public string ProcessName { get; set; }
        
        [Parameter(Mandatory = false)]
        [Alias("Title")]
        public string Name { get; set; }
        
        [Parameter(Mandatory = false,
                   ValueFromPipeline = true)]
        [Alias("Process", "p")]
        public new Process InputObject { get; set; }
        
        [Parameter(Mandatory = false)]
        [Alias("pid")]
        public int ProcessId { get; set; }
        
        [Parameter(Mandatory = false)]
        [Alias("temporary", "fake")]
        // 20120206 public new string AutomationId { get; set; }
        public string AutomationId { get; set; }
        [Parameter(Mandatory = false)]
        [Alias("oneMoreFakeParameter")]
        public string Class { get; set; }
        
//        [Parameter(Mandatory = false)]
//        internal new System.Windows.Automation.AutomationElement InputObject { get; set; }
        #endregion Parameters
    }
}
