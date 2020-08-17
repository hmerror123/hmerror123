/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/29/2012
 * Time: 1:09 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Helpers
{
    using System;
    //using System.Diagnostics;
    using NUnit.Framework;
    
    /// <summary>
    /// Description of PreferencesTestFixture.
    /// </summary>
    [TestFixture(Description="Preferences test")]
    public class PreferencesTestFixture
    {
        public PreferencesTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Preferences")]
        public void PreferencesAfterFailTurboTimeoutDefaultValue()
        {
            string timeoutInterval = "2000";
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Mode]::Profile = [UIAutomation.Modes]::Presentation; " +
                @"[UIAutomation.Preferences]::AfterFailTurboTimeout;",
                timeoutInterval);
        }

        [Test]
        [Category("WinForms")]
        [Category("Preferences")]
        public void PreferencesTimeoutAfterSuccessWindow1()
        {
            string timeoutInterval = "10000"; // default in unit tests
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Preferences]::Timeout = 10000; " +
                //@"[UIAutomation.Preferences]::Timeout; " +
                //@"sleep -seconds 1; " +
                @"$null = Get-UIAWindow -pn '" +
                MiddleLevelCode.TestFormProcess + 
                "'; " + 
                @"[UIAutomation.Preferences]::Timeout;",
                timeoutInterval);
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Preferences")]
        public void PreferencesTimeoutAfterSuccessWindow2()
        {
            string timeoutInterval = "10000";
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Preferences]::Timeout = 10000; " +
                @"$null = Get-UIAWindow -n " + 
                MiddleLevelCode.TestFormNameEmpty +
                "; " + 
                @"[UIAutomation.Preferences]::Timeout;",
                timeoutInterval);
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Preferences")]
        public void PreferencesTimeoutAfterSuccessWindow3()
        {
            string timeoutInterval = "10000";
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Preferences]::Timeout = 10000; " +
                @"$null = Get-UIAWindow -pid " + 
                @"(Get-Process -Name '" + 
                MiddleLevelCode.TestFormProcess +
                "').Id; " +
                @"[UIAutomation.Preferences]::Timeout;",
                timeoutInterval);
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Preferences")]
        public void PreferencesTimeoutAfterFailWindow1_ProcessName()
        {
            string processName = "no such process";
            string timeoutInterval = "2000";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Preferences]::Timeout = 4000; " +
                @"try{ $null = Get-UIAWindow -pn '" + 
                processName + 
                "';} catch {} " + 
                @"[UIAutomation.Preferences]::Timeout;",
                timeoutInterval);
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Preferences")]
        public void PreferencesTimeoutAfterFailWindow2_WindowTitle()
        {
            string windowTitle = "no such window";
            string timeoutInterval = "2000";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Preferences]::Timeout = 4000; " +
                @"try{ $null = Get-UIAWindow -n '" + 
                windowTitle + 
                "';} catch {} " + 
                @"[UIAutomation.Preferences]::Timeout;",
                timeoutInterval);
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Preferences")]
        public void PreferencesTimeoutAfterFailWindow3_ProcessId()
        {
            string processId = "-1";
            string timeoutInterval = "2000";
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Preferences]::Timeout = 4000; " +
                @"try{ $null = Get-UIAWindow -pid " + 
                processId + 
                ";} catch {} " + 
                @"[UIAutomation.Preferences]::Timeout;",
                timeoutInterval);
        }
        
//        [Test]
//        [Category("WinForms")]
//        [Category("Preferences")]
//        public void PreferencesTimeoutAfterFailWindow4_Process()
//        {
//            string timeoutInterval = "2000";
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
//                @"[UIAutomation.Preferences]::Timeout = 4000; " +
//                @"$process = Get-Process -Name '" + 
//                MiddleLevelCode.TestFormProcess +
//                "'; " +
//                @"$null = Stop-Process -InputObject $process; " +
//                @"try{ $process | Get-UIAWindow;} catch {} " + 
//                @"[UIAutomation.Preferences]::Timeout;",
//                timeoutInterval);
//        }

        [Test]
        [Category("WinForms")]
        [Category("Preferences")]
        public void PreferencesTimeoutAfterFailAndFurtherSuccessWindow1_ProcessName()
        {
            string processName = "no such process";
            string timeoutInterval = "4000";
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Preferences]::Timeout = 4000; " +
                @"try{ $null = Get-UIAWindow -pn '" + 
                processName + 
                "';} catch {} " + 
                @"try{ $null = Get-UIAWindow -pn '" + 
                MiddleLevelCode.TestFormProcess + 
                "';} catch {} " + 
                @"[UIAutomation.Preferences]::Timeout;",
                timeoutInterval);
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Preferences")]
        public void PreferencesTimeoutAfterFailAndFurtherSuccessWindow2_WindowTitle()
        {
            string windowTitle = "no such window";
            string timeoutInterval = "4000";
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Preferences]::Timeout = 4000; " +
                @"try{ $null = Get-UIAWindow -n '" + 
                windowTitle + 
                "';} catch {} " + 
                @"try{ $null = Get-UIAWindow -n '" + 
                MiddleLevelCode.TestFormNameEmpty + 
                "';} catch {} " + 
                @"[UIAutomation.Preferences]::Timeout;",
                timeoutInterval);
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Preferences")]
        public void PreferencesTimeoutAfterFailAndFurtherSuccessWindow3_ProcessId()
        {
            string processId = "-1";
            string timeoutInterval = "4000";
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[UIAutomation.Preferences]::Timeout = 4000; " +
                @"try{ $null = Get-UIAWindow -pid " + 
                processId + 
                ";} catch {} " + 
                @"try{ $null = Get-UIAWindow -pid (" + 
                @"Get-Process -Name '" + 
                MiddleLevelCode.TestFormProcess +
                "').Id;} catch {} " + 
                @"[UIAutomation.Preferences]::Timeout;",
                timeoutInterval);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
