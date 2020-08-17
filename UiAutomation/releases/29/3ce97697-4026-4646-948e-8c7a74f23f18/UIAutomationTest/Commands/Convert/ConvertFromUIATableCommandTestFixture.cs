﻿/*
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
    /// Description of ConvertFromUIATableCommandTestFixture.
    /// </summary>
    [TestFixture(Description="ConvertFrom-UIATableCommand test")]
    public class ConvertFromUIATableCommandTestFixture
    {
        public ConvertFromUIATableCommandTestFixture()
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
            string codeSnippet = 
                @"if ( ($null | ConvertFrom-UIATable) ) { 1; }else{ 0; }";
            System.Collections.ObjectModel.Collection<PSObject >  coll = 
                CmdletUnitTest.TestRunspace.RunPSCode(codeSnippet);
            Assert.IsTrue(coll[0].ToString() == "0");
        }
        
        [Test(Description="ProcessRecord test Null via parameter")]
        [Category("NoForms")]
        public void TestParameterInputNull()
        {
            string codeSnippet = 
                @"if ((ConvertFrom-UIATable -InputObject $null)) { 1; }else{ 0; }";
            System.Collections.ObjectModel.Collection<PSObject >  coll =
                CmdletUnitTest.TestRunspace.RunPSCode(codeSnippet);
            Assert.IsNull(coll);
        }
        
        [Test(Description="ProcessRecord test Is Not AutomationElement")]
        [Category("NoForms")]
        public void TestParameterInputOtherType()
        {
            string codeSnippet = 
                @"if ((ConvertFrom-UIATable -InputObject (New-Object System.Windows.forms.Label))) { 1; }else{ 0; }";
            System.Collections.ObjectModel.Collection<PSObject >  coll =
                CmdletUnitTest.TestRunspace.RunPSCode(codeSnippet);
            Assert.IsNull(coll);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
    }
    
    

}