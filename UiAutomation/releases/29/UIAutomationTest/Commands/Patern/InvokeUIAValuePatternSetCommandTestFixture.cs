/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08.12.2011
 * Time: 11:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;
using System.Management.Automation;

namespace UIAutomationTest.Commands.Pattern
{
    /// <summary>
    /// Description of InvokeUIAValuePatternSetCommandTestFixture.
    /// </summary>
    [TestFixture(Description="Invoke-UIAValuePatternSetCommand test")]
    public class InvokeUIAValuePatternSetCommandTestFixture
    {
        public InvokeUIAValuePatternSetCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Control")]
        public void GetTextBoxTextTimeoutDefault()
        {
            string name = "aaa";
            string auId = "TextBox111";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Edit,
                name,
                auId,
                TimeoutsAndDelays.Control_Timeout2000Delay4000_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIATextBox -AutomationId " + 
                auId + 
                " -timeout 2000 | " +
                "Get-UIATextBoxText",
                name);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
