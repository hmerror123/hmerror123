/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 07/12/2011
 * Time: 07:48 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Common
{
    using System;
    using NUnit.Framework;
    using System.Management.Automation;

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
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test(Description="InputObject ProcessRecord test Null via pipeline")]
        [Category("NoForms")]
        public void TestPipelineInput()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsTrue(
                @"if ( ($null | Move-UIACursor -X 1 -Y 1) ) { 1; }else{ 0; }",
                "0");
        }
        
        [Test(Description="ProcessRecord test Null via parameter")]
        [Category("NoForms")]
        public void TestParameterInputNull()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsNull(
                @"if ((Move-UIACursor -InputObject $null -X 1 -Y 1)) { 1; }else{ 0; }");
        }
        
        [Test(Description="ProcessRecord test Is Not AutomationElement")]
        [Category("NoForms")]
        public void TestParameterInputOtherType()
        {
            CmdletUnitTest.TestRunspace.RunAndEvaluateIsNull(
                @"if ((Move-UIACursor -InputObject (New-Object System.Windows.forms.Label) -X 1 -Y 1)) { 1; }else{ 0; }");
        }
        
        [Test(Description="ProcessRecord test Is AutomationElement")]
        [Category("WinForms")]
        public void TestParameterInputAutomationElement()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
                           MiddleLevelCode.TestFormProcess +
                           " | Move-UIACursor -X 1 -Y 1)) { 1; } else { 0; }");
        }
        
        //[System.Windows.Forms.Cursor]::Position.X
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
        
    }
    
    

}
