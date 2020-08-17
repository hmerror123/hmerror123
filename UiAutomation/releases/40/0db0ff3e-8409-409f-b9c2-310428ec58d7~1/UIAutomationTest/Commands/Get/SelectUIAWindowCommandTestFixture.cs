/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08.12.2011
 * Time: 11:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using NUnit.Framework;

namespace UIAutomationTest.Commands.Select
{
    /// <summary>
    /// Description of GetUIAWindowCommandTestFixture.
    /// </summary>
    [TestFixture(Description="Get-UIAWindowCommand test")]
    public class GetUIAWindowCommandTestFixture
    {
        public GetUIAWindowCommandTestFixture()
        {
        }
        
        public System.Diagnostics.Process process;
        // 20120206 System.Diagnostics.ProcessStartInfo startInfo;
        
        [SetUp]
        public void PrepareRunspace()
        {
            TestRunspace.PrepareRunspace();
        }
        
        [Test]
        [Category("WinForms")]
        public void SelectWindowByProcessNameWrong()
        {
            TestRunspace.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -p " + 
                           "'wrong process name'" +
                           ")){ 0; }else{ 1; }");
        }
        
        [Test]
        [Category("WinForms")]
        public void SelectWindowByProcessNameTimeoutDefault()
        {
            TestRunspace.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -p " + 
                           TestRunspace.TestFormProcess +
                           ")){ 1; }else{ 0; }");
        }
        
//        [Test]
//        [Category("WinForms")]
//        [Category("May Fail")]
//        public void SelectWindowByProcessNameTimeout1000()
//        {
//            TestRunspace.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
//            TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -p " + 
//                TestRunspace.TestFormProcess +
//                " -timeout 1000)){ 0; }else{ 1; }");
//        }
        
        [Test]
        [Category("WinForms")]
        public void SelectWindowByProcessNameDelay1000()
        {
            TestRunspace.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 1000);
            TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -p " + 
                TestRunspace.TestFormProcess +
                ")){ 1; }else{ 0; }");
        }
        
//        [Test("May Fail")]
//        [Category("WinForms")]
//        [Category("May Fail")]
//        public void SelectWindowByProcessNameTimeout2000()
//        {
//            TestRunspace.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
//            TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -p " + 
//                TestRunspace.TestFormProcess +
//                " -timeout 2000)){ 0; }else{ 1; }");
//        }
        
        [Test]
        [Category("WinForms")]
        public void SelectWindowByProcessNameDelay2000()
        {
            TestRunspace.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 2000);
            TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -p " + 
                TestRunspace.TestFormProcess +
                ")){ 1; }else{ 0; }");
        }
        
        [Test]
        [Category("WinForms")]
        [Category("May Fail")]
        public void SelectWindowByProcessNameTimeout5000()
        {
            TestRunspace.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -p " + 
                TestRunspace.TestFormProcess +
                " -timeout 5000)){ 1; }else{ 0; }");
        }
        
        [Test]
        [Category("WinForms")]
        public void SelectWindowByProcessNameDelay5000()
        {
            TestRunspace.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 5000);
            TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -p " + 
                TestRunspace.TestFormProcess +
                ")){ 1; }else{ 0; }");
        }
        
        [Test]
        [Category("WinForms")]
        public void SelectWindowByProcessNameTimeout10000()
        {
            TestRunspace.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -p " + 
                TestRunspace.TestFormProcess +
                " -timeout 10000)){ 1; }else{ 0; }");
        }
        
        [Test]
        [Category("WinForms")]
        public void SelectWindowByProcessNameDelay10000()
        {
            TestRunspace.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 10000);
            TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -p " + 
                TestRunspace.TestFormProcess +
                ")){ 1; }else{ 0; }");
        }
        
        [Test]
        [Category("WinForms")]
        public void SelectWindowByProcessNameTimeout60000()
        {
            TestRunspace.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -p " + 
                TestRunspace.TestFormProcess +
                " -timeout 60000)){ 1; }else{ 0; }");
        }
        
        [Test]
        [Category("WinForms")]
        public void SelectWindowByProcessNameDelay60000()
        {
            TestRunspace.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 60000);
            TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -p " + 
                TestRunspace.TestFormProcess +
                ")){ 1; }else{ 0; }");
        }
    
// since the default timeout has been changed from 60000 to 10000,
// these tests make no sense
//        [Test]
//        [Category("WinForms")]
//        public void SelectWindowByProcessNameTimeout120000()
//        {
//            TestRunspace.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
//            TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -p " + 
//                TestRunspace.TestFormProcess +
//                " -timeout 120000)){ 1; }else{ 0; }");
//        }
//        
//        [Test]
//        [Category("WinForms")]
//        public void SelectWindowByProcessNameDelay120000()
//        {
//            TestRunspace.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 120000);
//            TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -p " + 
//                TestRunspace.TestFormProcess +
//                ")){ 1; }else{ 0; }");
//        }
        
        [Test]
        [Category("WinForms")]
        public void SelectWindowByProcessNameTimeout120000Delay100000()
        {
            TestRunspace.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 100000);
            TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -p " + 
                TestRunspace.TestFormProcess +
                " -timeout 120000)){ 1; }else{ 0; }");
        }
        
        [Test]
        [Category("WinForms")]
        public void SelectWindowByTitleWrong()
        {
            TestRunspace.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 1000);
            TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -title " + 
                "'wrong title'" +
                ")){ 0; }else{ 1; }");
        }
        
        [Test]
        [Category("WinForms")]
        public void SelectWindowByTitleTimeoutDefault()
        {
            TestRunspace.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -title " + 
                TestRunspace.TestFormNameEmpty +
                ")){ 1; }else{ 0; }");
        }
        
//        [Test]
//        [Category("WinForms")]
//        [Category("May Fail")]
//        public void SelectWindowByTitleTimeout1000()
//        {
//            TestRunspace.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
//            TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -title " + 
//                TestRunspace.TestFormNameEmpty +
//                " -timeout 1000)){ 0; }else{ 1; }");
//        }
        
        [Test]
        [Category("WinForms")]
        public void SelectWindowByTitleDelay1000()
        {
            TestRunspace.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 1000);
            TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -title " + 
                TestRunspace.TestFormNameEmpty +
                ")){ 1; }else{ 0; }");
        }
        
        [Test]
        [Category("WinForms")]
        public void SelectWindowByTitleTimeout10000()
        {
            TestRunspace.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -title " + 
                TestRunspace.TestFormNameEmpty +
                " -timeout 10000)){ 1; }else{ 0; }");
        }
        
        [Test]
        [Category("WinForms")]
        public void SelectWindowByTitleDelay10000()
        {
            TestRunspace.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 10000);
            TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -title " + 
                TestRunspace.TestFormNameEmpty +
                ")){ 1; }else{ 0; }");
        }
        
        [Test]
        [Category("WinForms")]
        public void SelectWindowByTitleTimeout60000()
        {
            TestRunspace.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -title " + 
                TestRunspace.TestFormNameEmpty +
                " -timeout 60000)){ 1; }else{ 0; }");
        }
        
        [Test]
        [Category("WinForms")]
        public void SelectWindowByTitleDelay60000()
        {
            TestRunspace.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 60000);
            TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -title " + 
                TestRunspace.TestFormNameEmpty +
                ")){ 0; }else{ 1; }");
        }
        
        [Test]
        [Category("WinForms")]
        public void SelectWindowByTitleTimeout120000()
        {
            TestRunspace.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -title " + 
                TestRunspace.TestFormNameEmpty +
                " -timeout 120000)){ 1; }else{ 0; }");
        }
        
        [Test]
        [Category("WinForms")]
        public void SelectWindowByTitleDelay120000()
        {
            TestRunspace.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 120000);
            TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -title " + 
                TestRunspace.TestFormNameEmpty +
                ")){ 0; }else{ 1; }");
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            TestRunspace.DisposeRunspace();
        }
    }
}
