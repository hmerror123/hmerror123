/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 02.02.2012
 * Time: 1:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using NUnit.Framework;
using System.Windows.Automation;

namespace UIAutomationTest.Commands.Select
{
    /// <summary>
    /// Description of CommonCmdletBase.
    /// </summary>
    [TestFixture(Description="CommonCmdletBase test")]
    public class CommonCmdletBaseTestFixture
    {
        public CommonCmdletBaseTestFixture()
        {
        }
        
        UIAutomation.HasControlInputCmdletBase cmdlet = null;
        UIAutomation.CommonCmdletBase cmdletBase = null;
        
        [SetUp]
        public void PrepareRunspace()
        {
//            TestRunspace.PrepareRunspace();
            cmdlet = 
                new UIAutomation.GetControlCmdletBase();
            cmdletBase = 
                new UIAutomation.CommonCmdletBase();
        }
        
        [Test]
        [Category("CSCode")]
        public void SelectParameterControlType()
        {
            // cmdlet.ControlType = ControlType.Button;
            // cmdletBase.
//            TestRunspace.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 120000);
//            TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -title " + 
//                TestRunspace.TestFormNameEmpty +
//                ")){ 0; }else{ 1; }");
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
//            TestRunspace.DisposeRunspace();
            cmdlet = null;
        }
    }
}
