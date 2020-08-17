/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/2/2012
 * Time: 10:16 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation.Commands
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of SetUIAHighligherSettingsCommand.
    /// </summary>
    [Cmdlet(VerbsCommon.Set, "UIAHighligherSettings")]
    public class SetUIAHighligherSettingsCommand : ModuleSettingsCmdletBase
    {
        public SetUIAHighligherSettingsCommand()
        {
            this.Highlight = Preferences.Highlight;
            this.Color = Preferences.HighlighterColor;
            this.Border = Preferences.HighlighterBorder;
        }
        
        #region Parameters
        [Parameter(Mandatory=true)]
        public SwitchParameter Highlight { get; set; }
        [Parameter(Mandatory=false)]
        public System.Drawing.Color Color { get; set; }
        [Parameter(Mandatory=false)]
        public int Border { get; set; }
        #endregion Parameters
        
        protected override void BeginProcessing()
        {
            Preferences.Highlight = this.Highlight;
            Preferences.HighlighterColor = this.Color;
            Preferences.HighlighterBorder = this.Border;
        }
    }
}
