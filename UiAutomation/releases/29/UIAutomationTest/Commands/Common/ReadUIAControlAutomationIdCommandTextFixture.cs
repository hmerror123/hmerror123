/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 07/12/2011
 * Time: 11:44 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Common
{
    using System;
    using System.Windows.Automation;
    using NUnit.Framework;
    using System.Management.Automation;

    /// <summary>
    /// Description of ReadUIAControlAutomationIdCommandTextFixture.
    /// </summary>
    [TestFixture(Description="Read-UIAControlAutomationIdCommand test")]
    public class ReadUIAControlAutomationIdCommandTestFixture
    {
        public ReadUIAControlAutomationIdCommandTestFixture()
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
                @"if ( ($null | Read-UIAControlAutomationId) ) { 1; }else{ 0; }",
                "0");
        }
        
        [Test(Description="ProcessRecord test Null via parameter")]
        [Category("NoForms")]
        public void TestParameterInputNull()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsNull(
                @"if ((Read-UIAControlAutomationId -InputObject $null)) { 1; }else{ 0; }");
        }
        
        [Test(Description="ProcessRecord test Is Not AutomationElement")]
        [Category("NoForms")]
        public void TestParameterInputOtherType()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsNull(
                @"if ((Read-UIAControlAutomationId -InputObject (New-Object System.Windows.forms.Label))) { 1; }else{ 0; }");
        }
        
        [Test(Description="ProcessRecord test Is AutomationElement")]
        //[Category("NUnit")]
        [Category("WinForms")]
        [Category("Control")]
        public void TestParameterInputControlWithAutomationId()
        {
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"Get-UIAWindow -Name '" + 
//                CmdletUnitTest.TestRunspace.NUnitTitle + 
//                "' | Get-UIAPane -AutomationId '" + 
//                CmdletUnitTest.TestRunspace.NUnitTreeSplitterAutomationId + 
//                "' | Read-UIAControlAutomationId",
//                CmdletUnitTest.TestRunspace.NUnitTreeSplitterAutomationId);
            string automationId = "btnAuId";
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                0,
                ControlType.Button,
                "btnName",
                automationId,
                0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"if ((Get-UIAWindow -n " +
                MiddleLevelCode.TestFormNameEmpty +
                " | Get-UIAButton -name btnName | Read-UIAControlAutomationId)) { '" + 
                automationId + 
                "'; } else { ''; }",
                automationId);
        }

        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
    }
}
