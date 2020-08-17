/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 07/12/2011
 * Time: 11:44 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;
using System.Management.Automation;

namespace UIAutomationTest.Commands.Common
{
    /// <summary>
    /// Description of OutUIAControlAutomationIdCommandTextFixture.
    /// </summary>
    [TestFixture(Description="Out-UIAControlAutomationIdCommand test")]
    public class OutUIAControlAutomationIdCommandTestFixture
    {
        public OutUIAControlAutomationIdCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            TestRunspace.PrepareRunspace();
        }
        
        [Test(Description="InputObject ProcessRecord test Null via pipeline")]
        [Category("NoForms")]
        public void TestPipelineInput()
        {
            TestRunspace.RunAndEvaluateIsTrue(
                @"if( ($null | Out-UIAControlAutomationId) ){ 1; }else{ 0; }",
                "0");
        }
        
        [Test(Description="ProcessRecord test Null via parameter")]
        [Category("NoForms")]
        public void TestParameterInputNull()
        {
            TestRunspace.RunAndEvaluateIsNull(
                @"if ((Out-UIAControlAutomationId -Control $null)){ 1; }else{ 0; }");
        }
        
        [Test(Description="ProcessRecord test Is Not AutomationElement")]
        [Category("NoForms")]
        public void TestParameterInputOtherType()
        {
            TestRunspace.RunAndEvaluateIsNull(
                @"if ((Out-UIAControlAutomationId -Control (New-Object System.Windows.forms.Label))){ 1; }else{ 0; }");
        }
        
        [Test(Description="ProcessRecord test Is AutomationElement")]
        [Category("NUnit")]
        public void TestParameterInputControlWithAutomationId()
        {
            TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -Title '" + 
                TestRunspace.NUnitTitle + 
                "' | Get-UIAPane -AutomationId '" + 
                TestRunspace.NUnitTreeSplitterAutomationId + 
                "' | Out-UIAControlAutomationId",
                TestRunspace.NUnitTreeSplitterAutomationId);
        }

        [TearDown]
        public void DisposeRunspace()
        {
            TestRunspace.DisposeRunspace();
        }
        
    }
}
