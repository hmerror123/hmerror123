/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 07/12/2011
 * Time: 11:45 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;
using System.Management.Automation;

namespace UIAutomationTest.Commands.Common
{
    /// <summary>
    /// Description of OutUIAControlTitleCommandTestFixture.
    /// </summary>
    [TestFixture(Description="Out-UIAControlTitleCommand test")]
    public class OutUIAControlTitleCommandTestFixture
    {
        public OutUIAControlTitleCommandTestFixture()
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
            TestRunspace.RunAndEvaluateAreEqual(
                @"if( ($null | Out-UIAControlTitle) ){ 1; }else{ 0; }",
                "0");
        }
        
        [Test(Description="ProcessRecord test Null via parameter")]
        [Category("NoForms")]
        public void TestParameterInputNull()
        {
            TestRunspace.RunAndEvaluateIsNull(
                @"if ((Out-UIAControlTitle -Control $null)){ 1; }else{ 0; }");
        }
        
        [Test(Description="ProcessRecord test Is Not AutomationElement")]
        [Category("NoForms")]
        public void TestParameterInputOtherType()
        {
            TestRunspace.RunAndEvaluateIsNull(
                @"if ((Out-UIAControlTitle -Control (New-Object System.Windows.forms.Label))){ 1; }else{ 0; }");
        }
        
        [Test(Description="ProcessRecord test Is AutomationElement")]
        [Category("NUnit")]
        public void TestParameterInputFormWithTitle()
        {
            TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -Title '" + 
                TestRunspace.NUnitTitle + 
                "' | Out-UIAControlTitle",
                TestRunspace.NUnitTitle);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            TestRunspace.DisposeRunspace();
        }
        
    }
}
