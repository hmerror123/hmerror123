/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 07/12/2011
 * Time: 07:48 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;
using System.Management.Automation;

namespace UIAutomationTest.Commands.Common
{
    /// <summary>
    /// Description of MoveUIACursorCommandTestFixture.
    /// </summary>
    [TestFixture(Description="Move-UIACursorCommand test")]
    public class MoveUIACursorCommandTestFixture
    {
        public MoveUIACursorCommandTestFixture()
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
                @"if( ($null | Move-UIACursor) ){ 1; }else{ 0; }",
                "0");
        }
        
        [Test(Description="ProcessRecord test Null via parameter")]
        [Category("NoForms")]
        public void TestParameterInputNull()
        {
            TestRunspace.RunAndEvaluateIsNull(
                @"if ((Move-UIACursor -Control $null)){ 1; }else{ 0; }");
        }
        
        [Test(Description="ProcessRecord test Is Not AutomationElement")]
        [Category("NoForms")]
        public void TestParameterInputOtherType()
        {
            TestRunspace.RunAndEvaluateIsNull(
                @"if ((Move-UIACursor -Control (New-Object System.Windows.forms.Label))){ 1; }else{ 0; }");
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            TestRunspace.DisposeRunspace();
        }
        
    }
    
    

}
