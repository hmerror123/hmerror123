/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08.12.2011
 * Time: 11:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Get
{
    using System;
    using NUnit.Framework;
    using System.Management.Automation;

    /// <summary>
    /// Description of GetUIAControlCommandTestFixture.
    /// </summary>
    [TestFixture(Description="Get-UIAControlCommand test")]
    public class GetUIAControlCommandTestFixture
    {
        public GetUIAControlCommandTestFixture()
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
        [Category("Get_UIAControl")]
        public void GetControlByAutomationIDTimeoutDefault()
        {
            string auId = "Button111";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                "aaa",
                auId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -AutomationId " + 
                auId + 
                " | " +
                "Read-UIAControlAutomationId",
                auId);
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Control")]
        [Category("Get_UIAControl")]
        public void GetControlByAutomationIDTimeout2000()
        {
            string auId = "Button111";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                "aaa",
                auId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -AutomationId " + 
                auId + 
                " -timeout 2000 | " +
                "Read-UIAControlAutomationId",
                auId);
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Control")]
        [Category("Get_UIAControl")]
        public void GetControlByAutomationIDTimeout3000Delay500()
        {
            string auId = "Button111";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                "aaa",
                auId,
                TimeoutsAndDelays.Control_Timeout3000Delay500_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -AutomationId " + 
                auId + 
                " -timeout 3000 | " +
                "Read-UIAControlAutomationId",
                auId);
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Control")]
        [Category("Get_UIAControl")]
        public void GetControlByAutomationIDTimeout2000Delay4000()
        {
            string auId = "Button111";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                "aaa",
                auId,
                TimeoutsAndDelays.Control_Timeout2000Delay4000_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -AutomationId " + 
                auId + 
                " -timeout 2000 | " +
                "Read-UIAControlAutomationId",
                auId);
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Control")]
        [Category("Get_UIAControl")]
        public void GetControlByTitleTimeoutDefault()
        {
            string name = "Button222";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -Name " + 
                name + " | " +
                "Read-UIAControlName",
                name);
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Control")]
        [Category("Get_UIAControl")]
        public void GetControlByTitleTimeout2000()
        {
            string name = "Button222";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -Name " + 
                name + " -timeout 2000 | " +
                "Read-UIAControlName",
                name);
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Control")]
        [Category("Get_UIAControl")]
        public void GetControlByTitleTimeout3000Delay500()
        {
            string name = "Button222";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                TimeoutsAndDelays.Control_Timeout3000Delay500_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -Name " + 
                name + " -timeout 3000 | " +
                "Read-UIAControlName",
                name);
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Control")]
        [Category("Get_UIAControl")]
        public void GetControlByTitleTimeout2000Delay4000()
        {
            string name = "Button222";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                name,
                "btn",
                TimeoutsAndDelays.Control_Timeout2000Delay4000_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -Name " + 
                name + " -timeout 2000 | " +
                "Read-UIAControlName",
                name);
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Control")]
        [Category("Get_UIAControl")]
        public void GetControlByControlTypeTimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                "ccc",
                "ddd",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -ControlType Button | Read-UIAControlType",
                "ControlType.Button");
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Control")]
        [Category("Get_UIAControl")]
        public void GetControlByControlTypeTimeout2000()
        {
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                "ccc",
                "ddd",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -ControlType Button -timeout 2000 | Read-UIAControlType",
                "ControlType.Button");
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Control")]
        [Category("Get_UIAControl")]
        public void GetControlByControlTypeTimeout3000Delay500()
        {
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                "ccc",
                "ddd",
                TimeoutsAndDelays.Control_Timeout3000Delay500_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -ControlType Button -timeout 3000 | Read-UIAControlType",
                "ControlType.Button");
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Control")]
        [Category("Get_UIAControl")]
        public void GetControlByControlTypeTimeout2000Delay4000()
        {
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                "ccc",
                "ddd",
                TimeoutsAndDelays.Control_Timeout2000Delay4000_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAControl -ControlType Button -timeout 2000 | Read-UIAControlType",
                "ControlType.Button");
        }
        
// [Test]
// [Category("WinForms")]
// [Category("Control")]
// public void GetControlByClassTimeoutDefault()
// {
// MiddleLevelCode.StartProcessWithFormAndControl(
// UIAutomationTestForms.Forms.WinFormsEmpty, 
// 0,
// System.Windows.Automation.ControlType.Button,
// 0);
// CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
// @"Get-UIAWindow -pn " + 
// MiddleLevelCode.TestFormProcess +
// " | Get-UIAControl -Class 'WindowsForms10.BUTTON.app.0.141b42a_r15_ad1' | " + 
// "Read-UIAControlClass",
// "WindowsForms10.BUTTON.app.0.141b42a_r15_ad1");
// } // WindowsForms10.BUTTON.app.0.378734a
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
