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
    /// Description of OutUIAControlClassCommandTestFixture.
    /// </summary>
    [TestFixture(Description="Out-UIAControlClassCommand test")]
    public class OutUIAControlClassCommandTestFixture
    {
        public OutUIAControlClassCommandTestFixture()
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
                @"if( ($null | Out-UIAControlClass) ){ 1; }else{ 0; }",
                "0");
        }
        
        [Test(Description="ProcessRecord test Null via parameter")]
        [Category("NoForms")]
        public void TestParameterInputNull()
        {
            TestRunspace.RunAndEvaluateIsNull(
                @"if ((Out-UIAControlClass -Control $null)){ 1; }else{ 0; }");
        }
        
        [Test(Description="ProcessRecord test Is Not AutomationElement")]
        [Category("NoForms")]
        public void TestParameterInputOtherType()
        {
            TestRunspace.RunAndEvaluateIsNull(
                @"if ((Out-UIAControlClass -Control (New-Object System.Windows.forms.Label))){ 1; }else{ 0; }");
        }
        
//        [Test(Description="ProcessRecord test Is AutomationElement")]
//        [Category("NUnit")]
//        [Ignore("Unstable being run on various operationg systems")]
//        public void TestParameterInputFormWithClass()
//        {
//            string codeSnippet = 
//                @"Get-UIAWindow -Title '" + 
//                TestRunspace.NUnitTitle + 
//                "' | Out-UIAControlClass";
//            System.Collections.ObjectModel.Collection<PSObject> coll =
//                TestRunspace.RunPSCode(codeSnippet);
//            Assert.AreEqual(TestRunspace.NUnitClass, coll[0].ToString());
//        }

        [TearDown]
        public void DisposeRunspace()
        {
            TestRunspace.DisposeRunspace();
        }
        
    }
}
