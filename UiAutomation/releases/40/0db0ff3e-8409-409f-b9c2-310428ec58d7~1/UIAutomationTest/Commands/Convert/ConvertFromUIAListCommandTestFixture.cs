/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08.12.2011
 * Time: 11:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;
using System.Management.Automation;

namespace UIAutomationTest.Commands.Convert
{
    /// <summary>
    /// Description of ConvertFromUIAListCommandTestFixture.
    /// </summary>
    [TestFixture(Description="ConvertFrom-UIAListCommand test")]
    public class ConvertFromUIAListCommandTestFixture
    {
        public ConvertFromUIAListCommandTestFixture()
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
            string codeSnippet = 
                @"if( ($null | ConvertFrom-UIAList) ){ 1; }else{ 0; }";
            System.Collections.ObjectModel.Collection<PSObject> coll = 
                TestRunspace.RunPSCode(codeSnippet);
            Assert.IsTrue(coll[0].ToString()=="0");
        }
        
        [Test(Description="ProcessRecord test Null via parameter")]
        [Category("NoForms")]
        public void TestParameterInputNull()
        {
            string codeSnippet = 
                @"if ((ConvertFrom-UIAList -Control $null)){ 1; }else{ 0; }";
            System.Collections.ObjectModel.Collection<PSObject> coll =
                TestRunspace.RunPSCode(codeSnippet);
            Assert.IsNull(coll);
        }
        
        [Test(Description="ProcessRecord test Is Not AutomationElement")]
        [Category("NoForms")]
        public void TestParameterInputOtherType()
        {
            string codeSnippet = 
                @"if ((ConvertFrom-UIAList -Control (New-Object System.Windows.forms.Label))){ 1; }else{ 0; }";
            System.Collections.ObjectModel.Collection<PSObject> coll =
                TestRunspace.RunPSCode(codeSnippet);
            Assert.IsNull(coll);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            TestRunspace.DisposeRunspace();
        }
        
    }
    
    

}