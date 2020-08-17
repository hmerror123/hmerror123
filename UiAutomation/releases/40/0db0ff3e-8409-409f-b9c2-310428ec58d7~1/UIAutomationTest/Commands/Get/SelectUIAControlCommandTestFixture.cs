/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08.12.2011
 * Time: 11:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;
using System.Management.Automation;

namespace UIAutomationTest.Commands.Select
{
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
            TestRunspace.PrepareRunspace();
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Control")]
        public void SelectControlByAutomationIDTimeoutDefault()
        {
            TestRunspace.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                0);
            TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -p " + 
                TestRunspace.TestFormProcess +
                " | Get-UIAControl -AutomationId Button | " + 
                "Out-UIAControlAutomationId",
                "Button");
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Control")]
        public void SelectControlByTitleTimeoutDefault()
        {
            TestRunspace.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                0);
            TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -p " + 
                TestRunspace.TestFormProcess +
                " | Get-UIAControl -Title Button | " + 
                "Out-UIAControlTitle",
                "Button");
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Control")]
        public void SelectControlByControlTypeTimeoutDefault()
        {
            TestRunspace.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                System.Windows.Automation.ControlType.Button,
                0);
            TestRunspace.RunAndEvaluateAreEqual(
                @"(Get-UIAWindow -p " + 
                TestRunspace.TestFormProcess +
                " | Get-UIAControl -ControlType Button).Current.ControlType.ProgrammaticName",
                "ControlType.Button");
        }
        
//        [Test]
//        [Category("WinForms")]
//        [Category("Control")]
//        public void SelectControlByClassTimeoutDefault()
//        {
//            TestRunspace.StartProcessWithFormAndControl(
//                UIAutomationTestForms.Forms.WinFormsEmpty, 
//                0,
//                System.Windows.Automation.ControlType.Button,
//                0);
//            TestRunspace.RunAndEvaluateAreEqual(
//                @"Get-UIAWindow -p " + 
//                TestRunspace.TestFormProcess +
//                " | Get-UIAControl -Class 'WindowsForms10.BUTTON.app.0.141b42a_r15_ad1' | " + 
//                "Out-UIAControlClass",
//                "WindowsForms10.BUTTON.app.0.141b42a_r15_ad1");
//        } // WindowsForms10.BUTTON.app.0.378734a
        
        [TearDown]
        public void DisposeRunspace()
        {
            TestRunspace.DisposeRunspace();
        }
    }
}
