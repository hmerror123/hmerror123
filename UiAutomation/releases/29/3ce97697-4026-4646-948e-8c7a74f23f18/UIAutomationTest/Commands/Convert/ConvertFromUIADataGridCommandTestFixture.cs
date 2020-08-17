/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08.12.2011
 * Time: 11:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Convert
{
    using System;
    using NUnit.Framework;
    using System.Management.Automation;

    /// <summary>
    /// Description of ConvertFromUIADataGridCommandTestFixture.
    /// </summary>
    [TestFixture(Description="ConvertFrom-UIADataGridCommand test")]
    public class ConvertFromUIADataGridCommandTestFixture
    {
        public ConvertFromUIADataGridCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
// CmdletUnitTest.TestRunspace.IitializeRunspace();
// string codeSnippet = 
// @"$ErrorPreference = [System.Management.Automation.ActionPreference]::SilentlyContinue;";
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test(Description="InputObject ProcessRecord test Null via pipeline")]
        [Category("NoForms")]
        public void TestPipelineInput()
        {
            string codeSnippet = 
                @"if ( ($null | ConvertFrom-UIADataGrid) ) { 1; }else{ 0; }";
            System.Collections.ObjectModel.Collection<PSObject >  coll = 
                CmdletUnitTest.TestRunspace.RunPSCode(codeSnippet);
            Assert.IsTrue(coll[0].ToString() == "0");
        }
        
        [Test(Description="ProcessRecord test Null via parameter")]
        [Category("NoForms")]
        public void TestParameterInputNull()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsNull(
                @"if ((ConvertFrom-UIADataGrid -InputObject $null)) { 1; }else{ 0; }");
        }
        
        [Test(Description="ProcessRecord test Is Not AutomationElement")]
        [Category("NoForms")]
        public void TestParameterInputOtherType()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsNull(
                @"if ((ConvertFrom-UIADataGrid -InputObject (New-Object System.Windows.forms.Label))) { 1; }else{ 0; }");
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
    }
    
    

}