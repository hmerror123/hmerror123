/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 01.02.2012
 * Time: 12:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of GetUIAControlChildrenCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAControlChildren")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAControlChildrenCommand : GetControlCollectionCmdletBase
    {
        #region Constructor
        public GetUIAControlChildrenCommand()
        {
        }
        #endregion Constructor

        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            GetAutomationElements(TreeScope.Children);
        }
    }
    
    /// <summary>
    /// Description of GetUIAControlDescendantsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAControlDescendants")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAControlDescendantsCommand : GetControlCollectionCmdletBase
    {
        #region Constructor
        public GetUIAControlDescendantsCommand()
        {
        }
        #endregion Constructor

        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            GetAutomationElements(TreeScope.Descendants);
        }
    }
    
    /// <summary>
    /// Description of GetUIAControlParentCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAControlParent")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAControlParentCommand : GetControlCollectionCmdletBase
    {
        #region Constructor
        public GetUIAControlParentCommand()
        {
        }
        #endregion Constructor

        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            GetAutomationElements(TreeScope.Parent);
        }
    }
    
    /// <summary>
    /// Description of GetUIAControlAncestorsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "UIAControlAncestors")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UIA")]
    public class GetUIAControlAncestorsCommand : GetControlCollectionCmdletBase
    {
        #region Constructor
        public GetUIAControlAncestorsCommand()
        {
        }
        #endregion Constructor

        /// <summary>
        /// Processes the pipeline.
        /// </summary>
        protected override void ProcessRecord()
        {
            GetAutomationElements(TreeScope.Ancestors);
        }
    }
}
