/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 07/12/2011
 * Time: 11:45 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Common
{
    using System;
    using NUnit.Framework;
    using System.Management.Automation;
    using System.Windows.Automation;

    /// <summary>
    /// Description of OutUIAControlNameCommandTestFixture.
    /// </summary>
    [TestFixture(Description="Read-UIAControlNameCommand test")]
    public class ReadUIAControlNameCommandTestFixture
    {
        public ReadUIAControlNameCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test(Description="InputObject ProcessRecord test Null via pipeline")]
        [Category("NoForms")]
        public void TestPipelineInput()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"if ( ($null | Read-UIAControlName) ) { 1; }else{ 0; }",
                "0");
        }
        
        [Test(Description="ProcessRecord test Null via parameter")]
        [Category("NoForms")]
        public void TestParameterInputNull()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsNull(
                @"if ((Read-UIAControlName -InputObject $null)) { 1; }else{ 0; }");
        }
        
        [Test(Description="ProcessRecord test Is Not AutomationElement")]
        [Category("NoForms")]
        public void TestParameterInputOtherType()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsNull(
                @"if ((Read-UIAControlName -InputObject (New-Object System.Windows.forms.Label))) { 1; }else{ 0; }");
        }
        
        [Test(Description="ProcessRecord test Is AutomationElement")]
        //[Category("NUnit")]
        [Category("WinForms")]
        public void TestParameterInputFormWithTitle()
        {
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"Get-UIAWindow -Name '" + 
//                CmdletUnitTest.TestRunspace.NUnitTitle + 
//                "' | Read-UIAControlName",
//                CmdletUnitTest.TestRunspace.NUnitTitle);
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -n " + 
                           MiddleLevelCode.TestFormNameEmpty +
                           " | Read-UIAControlName)) { 1; } else { 0; }");
        }
        
        [Test(Description="ProcessRecord test Is Name")]
        //[Category("NUnit")]
        [Category("WinForms")]
        [Category("Control")]
        public void TestParameterInputControlWithAutomationId()
        {
            string name = "btnName";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                ControlType.Button,
                name,
                "autoid",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"if ((Get-UIAWindow -n " +
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UIAButton -name btnName | Read-UIAControlName)) { '" + 
                name + 
                "'; } else { ''; }",
                name);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
    }
}
