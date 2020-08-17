﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08.12.2011
 * Time: 11:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Get
{
    using System;
    using System.Diagnostics;
    using NUnit.Framework;

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
            MiddleLevelCode.PrepareRunspace();
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByProcessNameWrong()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
//                           "'wrong process name'" +
//                           ")) { 0; } else { 1; }");
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Get-UIAWindow -pn " + 
                "'wrong process name' -Seconds 2" +
                ")) { 0; } else { 1; }",
                "System.NullReferenceException",
                "Object reference not set to an instance of an object.");
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByProcessNameTimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
                           MiddleLevelCode.TestFormProcess +
                           ")) { 1; } else { 0; }");
        }
        
// [Test]
// [Category("WinForms")]
// [Category("May Fail")]
// public void GetWindowByProcessNameTimeout1000()
// {
// MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
// CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
// MiddleLevelCode.TestFormProcess +
// " -timeout 1000)) { 0; } else { 1; }");
// }
        
        [Test]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByProcessNameDelay1000()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay1000);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                ")) { 1; } else { 0; }");
        }
        
// [Test("May Fail")]
// [Category("WinForms")]
// [Category("May Fail")]
// public void GetWindowByProcessNameTimeout2000()
// {
// MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
// CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
// MiddleLevelCode.TestFormProcess +
// " -timeout 2000)) { 0; } else { 1; }");
// }
        
        [Test]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByProcessNameDelay2000()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay2000);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                ")) { 1; } else { 0; }");
        }
        
        [Test]
        [Category("WinForms")]
        [Category("May Fail")]
        [Category("Get_UIAWindow")]
        public void GetWindowByProcessNameTimeout5000()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " -timeout 5000)) { 1; } else { 0; }");
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByProcessNameDelay3000()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay3000);
            //CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Get-UIAWindow -pn " +
                MiddleLevelCode.TestFormProcess +
                ")) { 1; } else { 0; }",
                "System.NullReferenceException",
                "Object reference not set to an instance of an object.");
        }
        
//        [Test]
//        [Category("WinForms")]
//        public void GetWindowByProcessNameTimeout10000()
//        {
//            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
//                MiddleLevelCode.TestFormProcess +
//                " -timeout 10000)) { 1; } else { 0; }");
//        }
        
        [Test]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByProcessNameTimeout6000Delay3000()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Control_Timeout6000Delay3000_Delay);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " -timeout 6000)) { 1; } else { 0; }");
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByProcessNameTimeout20000()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " -timeout 20000)) { 1; } else { 0; }");
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByProcessNameDelay4000()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay4000);
            //CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Get-UIAWindow -pn " +
                MiddleLevelCode.TestFormProcess +
                ")) { 1; } else { 0; }",
                "System.NullReferenceException",
                "Object reference not set to an instance of an object.");
        }
    
// since the default timeout has been changed from 60000 to 10000,
// these tests make no sense
// [Test]
// [Category("WinForms")]
// public void GetWindowByProcessNameTimeout120000()
// {
// MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
// CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
// MiddleLevelCode.TestFormProcess +
// " -timeout 120000)) { 1; } else { 0; }");
// }
// 
// [Test]
// [Category("WinForms")]
// public void GetWindowByProcessNameDelay120000()
// {
// MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 120000);
// CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
// MiddleLevelCode.TestFormProcess +
// ")) { 1; } else { 0; }");
// }
        
        [Test]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByProcessNameTimeout8000Delay5000()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay5000);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " -timeout 8000)) { 1; } else { 0; }");
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByProcessNameTimeout12000Delay11000()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay11000);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pn " + 
                MiddleLevelCode.TestFormProcess +
                " -timeout 12000)) { 1; } else { 0; }");
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByNameWrong()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Name " + 
//                "'wrong name'" +
//                " -timeout 2000" +
//                ")) { 0; } else { 1; }");
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Get-UIAWindow -n " + 
                "'wrong name' -Seconds 2" +
                ")) { 0; } else { 1; }",
                "System.NullReferenceException",
                "Object reference not set to an instance of an object.");
        }
        

        [Test]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowAsGlobalVariableEmpty()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if (([uiautomation.currentdata]::currentwindow.current.name" + 
                ")) { 0; } else { 1; }");
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowAsGlobalVariableNotEmpty()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"Get-UIAWindow -Name " +
                MiddleLevelCode.TestFormNameEmpty + 
                "; " +
                @"if (([uiautomation.currentdata]::currentwindow.current.name" +
                ")) { 0; } else { 1; }",
                "System.Windows.Automation.AutomationElement");
        }
        
//        [Test]
//        [Category("WinForms")]
//        public void GetWindowAsGlobalVariablePossiblyNotEmpty()
//        {
//            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(
//                @"if (([uiautomation.currentdata]::currentwindow.current.name" +
//                ")) { 0; } else { 1; }");
//        }
        
        [Test]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowAsGlobalVariableSetNull()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(
                @"$ErrorActionPreference = [system.management.automation.actionpreference]::SilentlyContinue; " +
                @"try{ Get-UIAWindow -pn 'no such process' -seconds 2; } catch {} " +
                @"if (([uiautomation.currentdata]::currentwindow.current.name" +
                ")) { 0; } else { 1; }");
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByNameTimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Name " + 
                MiddleLevelCode.TestFormNameEmpty +
                ")) { 1; } else { 0; }");
        }
        
// [Test]
// [Category("WinForms")]
// [Category("May Fail")]
// public void GetWindowByNameTimeout1000()
// {
// MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
// CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Name " + 
// MiddleLevelCode.TestFormNameEmpty +
// " -timeout 1000)) { 0; } else { 1; }");
// }
        
        [Test]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByNameDelay1000()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay1000);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Name " + 
                MiddleLevelCode.TestFormNameEmpty +
                ")) { 1; } else { 0; }");
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByNameTimeout5000()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Name " + 
                MiddleLevelCode.TestFormNameEmpty +
                " -timeout 5000)) { 1; } else { 0; }");
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByNameTimeout12000()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Name " + 
                MiddleLevelCode.TestFormNameEmpty +
                " -timeout 12000)) { 1; } else { 0; }");
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByNameTimeout3000Delay5000()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay5000);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Name " + 
//                MiddleLevelCode.TestFormNameEmpty +
//                " -timeout 3000 " + 
//                ")) { 0; } else { 1; }");
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Get-UIAWindow -Name " + 
                MiddleLevelCode.TestFormNameEmpty +
                " -timeout 3000 " + 
                ")) { 0; } else { 1; }",
                "System.NullReferenceException",
                "Object reference not set to an instance of an object.");
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByNameDelay2500()
        {
            MiddleLevelCode.StartProcessWithForm(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay2500);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Name " + 
                MiddleLevelCode.TestFormNameEmpty +
                ")) { 1; } else { 0; }");
        }
        
//        [Test]
//        [Category("WinForms")]
//        public void GetWindowByNameDelay60000()
//        {
//            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 60000);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -Name " + 
//                MiddleLevelCode.TestFormNameEmpty +
//                ")) { 0; } else { 1; }");
//        }
        
        [Test]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByPIDWrong()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
//            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pid " + 
//                "0" +
//                " -timeout 2000" +
//                ")) { 0; } else { 1; }");
            CmdletUnitTest.TestRunspace.RunAndGetTheException(
                @"if ((Get-UIAWindow -pid " + 
                "12345678 -Seconds 2" +
                ")) { 0; } else { 1; }",
                "System.NullReferenceException",
                "Object reference not set to an instance of an object.");
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByPIDTimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-UIAWindow -pid " + 
                "(Get-Process -Name " +
                MiddleLevelCode.TestFormProcess +
                ").Id " +
                ")) { 1; } else { 0; }");
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByProcessFoundTimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(@"if ((Get-Process -Name " +
                MiddleLevelCode.TestFormProcess +
                " | Get-UIAWindow" +
                ")) { 1; } else { 0; }");
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Get_UIAWindow")]
        public void GetWindowByProcessStartedTimeoutDefault()
        {
//            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual1(
                @"if ((Start-Process '" +
                MiddleLevelCode.TestFormPath + 
                "' -PassThru" +
                " | Get-UIAWindow" +
                ")) { 1; } else { 0; }");
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Get_UIAActiveWindow")]
        public void GetActiveWindow()
        {
            MiddleLevelCode.StartProcessWithFormAndControl(
                UIAutomationTestForms.Forms.WinFormsEmpty, 
                TimeoutsAndDelays.Form_Delay0,
                System.Windows.Automation.ControlType.Button,
                "btn",
                "id",
                TimeoutsAndDelays.Control_Delay2000);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"sleep -Seconds 1; " +
                @"Get-UIAActiveWindow | Read-UIAcontrolName;",
                MiddleLevelCode.TestFormNameEmpty);
        }
        
        [Test]
        [Category("WinForms")]
        [Category("Get_UIAWindowFromHandle")]
        public void GetWindowByHandle1TimeoutDefault()
        {
            MiddleLevelCode.StartProcessWithForm(UIAutomationTestForms.Forms.WinFormsEmpty, 0);
            CmdletUnitTest.TestRunspace.RunAndEvaluateAreEqual(
                @"[void]($handle = (Get-Process -Name " +
                MiddleLevelCode.TestFormProcess + 
                " | Get-UIAWindow).Current.NativeWindowHandle); " +
                @"[void]([UIAutomation.CurrentData]::ResetData()); " +
                @"sleep -Seconds 2; " +
                "(Get-UIAWindowFromHandle -Handle $handle).Current.Name;",
                MiddleLevelCode.TestFormNameEmpty);
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
