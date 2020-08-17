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
    /// Description of ReadUIAControlClassCommandTestFixture.
    /// </summary>
    [TestFixture(Description="Read-UIAControlClassCommand test")]
    public class ReadUIAControlClassCommandTestFixture
    {
        public ReadUIAControlClassCommandTestFixture()
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
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsTrue(
                @"if ( ($null | Read-UIAControlClass) ) { 1; }else{ 0; }",
                "0");
        }
        
        [Test(Description="ProcessRecord test Null via parameter")]
        [Category("NoForms")]
        public void TestParameterInputNull()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsNull(
                @"if ((Read-UIAControlClass -InputObject $null)) { 1; }else{ 0; }");
        }
        
        [Test(Description="ProcessRecord test Is Not AutomationElement")]
        [Category("NoForms")]
        public void TestParameterInputOtherType()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsNull(
                @"if ((Read-UIAControlClass -InputObject (New-Object System.Windows.forms.Label))) { 1; }else{ 0; }");
        }
        
// [Test(Description="ProcessRecord test Is AutomationElement")]
// [Category("NUnit")]
// [Ignore("Unstable being run on various operationg systems")]
// public void TestParameterInputFormWithClass()
// {
// string codeSnippet = 
// @"Get-UIAWindow -Name '" + 
// CmdletUnitTest.TestRunspace.NUnitTitle + 
// "' | Read-UIAControlClass";
// System.Collections.ObjectModel.Collection<PSObject >  coll =
// CmdletUnitTest.TestRunspace.RunPSCode(codeSnippet);
// Assert.AreEqual(CmdletUnitTest.TestRunspace.NUnitClass, coll[0].ToString());
// }

        [Test(Description="ProcessRecord test Is Class")]
        //[Category("NUnit")]
        [Category("WinForms")]
        [Category("Control")]
        public void TestParameterInputControlWithAutomationId()
        {
            string className = "Button";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                ControlType.Button,
                "btnName",
                "auid",
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"if ((Get-UIAWindow -n " +
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UIAButton -name btnName | Read-UIAControlClass)) { '" + 
                className + 
                "'; } else { ''; }",
                className);
        }

        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
    }
}
