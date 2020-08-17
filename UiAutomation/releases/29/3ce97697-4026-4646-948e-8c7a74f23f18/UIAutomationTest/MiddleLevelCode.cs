/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/15/2012
 * Time: 9:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest
{
    using System;
    using NUnit;
    using System.Diagnostics;
    //using System.Management.Automation;
    
    /// <summary>
    /// Description of MiddleLevelCode.
    /// </summary>
    public static class MiddleLevelCode
    {
        static MiddleLevelCode()
        {
        }
        
        //public static string RunspaceCommand { get; set; }
        
        public static string TestFormPath {
            get{
#if DEBUG
                return @"..\..\..\UIAutomationTestForms\bin\Debug\UIAutomationTestForms.exe";
#else
                return @"..\..\..\UIAutomationTestForms\bin\Release35\UIAutomationTestForms.exe";
#endif
            }
        }
        
        public static string TestFormProcess { get{ return @"UIAutomationTestForms"; } }
        // public static string TestFormProcess { get{ return @"nunit"; } }
        public static System.Diagnostics.Process TestProcess { get; set; }
        public static System.Diagnostics.ProcessStartInfo TestProcessStartInfo { get; set; }
        public static string TestFormNameEmpty { get{ return @"WinFormsEmpty"; } }
        public static string TestFormNameAnonymous { get{ return @""; } }
        public static string TestFormNameMinimized { get{ return @"WinFormsMinimized"; } }
        public static string TestFormNameMaximized { get{ return @"WinFormsMaximized"; } }
        public static string TestFormNameNoTaskBar { get{ return @"WinFormsNoTaskBar"; } }
        public static string TestFormNameRich { get{ return @"WinFormsRich"; } }
        
        public static string TestFormWPFNameEmpty { get{ return @"WPFEmpty"; } }
        public static string TestFormWPFNameAnonymous { get{ return @""; } }
        public static string TestFormWPFNameMinimized { get{ return @"WPFMinimized"; } }
        public static string TestFormWPFNameMaximized { get{ return @"WPFMaximized"; } }
        public static string TestFormWPFNameCollapsed { get{ return @"WPFCollapsed"; } }
        // public static string TestFormNameNoTaskBar { get{ return @"WinFormsNoTaskBar"; } }
        // public static string TestFormNameRich { get{ return @"WinFormsRich"; } }
        
        public static void StartProcessWithForm(UIAutomationTestForms.Forms formCode,
                                                TimeoutsAndDelays formDelayEn)
        {
            int formDelay = (int)formDelayEn;
            TestProcessStartInfo.Arguments = 
                ((int)formCode).ToString();
            TestProcessStartInfo.CreateNoWindow = true;
            TestProcessStartInfo.UseShellExecute = false;
            if (formDelay > 0)
            {
                TestProcessStartInfo.Arguments += " ";
                TestProcessStartInfo.Arguments +=
                    formDelay.ToString();
            }
            TestProcess =
                System.Diagnostics.Process.Start(TestProcessStartInfo);
        }
        
        public static void StartProcessWithFormAndControl(
            UIAutomationTestForms.Forms formCode,
            TimeoutsAndDelays formDelayEn,
            System.Windows.Automation.ControlType controlType,
            string controlName,
            string controlAutomationId,
            TimeoutsAndDelays controlDelayEn)
        {
            int formDelay = (int)formDelayEn;
            int controlDelay = (int)controlDelayEn;
            
            TestProcessStartInfo.Arguments = 
                ((int)formCode).ToString();
            TestProcessStartInfo.CreateNoWindow = true;
            TestProcessStartInfo.UseShellExecute = false;
            // form delay
            TestProcessStartInfo.Arguments += " ";
            TestProcessStartInfo.Arguments +=
                formDelay.ToString();
            // control type
            TestProcessStartInfo.Arguments += " ";
            string _controlType = 
                controlType.ProgrammaticName.Substring(
                    controlType.ProgrammaticName.IndexOf(".") + 1);
            TestProcessStartInfo.Arguments +=
                _controlType;
            // control delay
            TestProcessStartInfo.Arguments += " ";
            TestProcessStartInfo.Arguments +=
                controlDelay.ToString();
            TestProcessStartInfo.Arguments += " ";
            TestProcessStartInfo.Arguments +=
                controlName;
            TestProcessStartInfo.Arguments += " ";
            TestProcessStartInfo.Arguments +=
                controlAutomationId;
            Console.WriteLine(TestProcessStartInfo.Arguments);
            TestProcess =
                System.Diagnostics.Process.Start(TestProcessStartInfo);
        }
        
        public static void PrepareRunspace() //string command)
        {
            CmdletUnitTest.TestRunspace.IitializeRunspace(Settings.RunspaceCommand);
// string codeSnippet = 
// @"$ErrorPreference = [System.Management.Automation.ActionPreference]::SilentlyContinue;";
            TestProcessStartInfo =
                new ProcessStartInfo();
            TestProcessStartInfo.FileName = 
                //CmdletUnitTest.TestRunspace.TestFormPath;
                MiddleLevelCode.TestFormPath;
        }
        
        public static void DisposeRunspace()
        {
            CmdletUnitTest.TestRunspace.RunPSCode(
                @"[UIAutomation.CurrentData]::ResetData();");
            CmdletUnitTest.TestRunspace.CloseRunspace();
            // TestProcess.CloseMainWindow();
            if (TestProcess != null)
            {
                try { TestProcess.CloseMainWindow(); } 
                catch { }
            }
            System.Diagnostics.Process[] processes = 
                System.Diagnostics.Process.GetProcessesByName(
                    //MiddleLevelCode.TestFormProcess);
                    MiddleLevelCode.TestFormProcess);
            foreach (System.Diagnostics.Process p in processes)
            {
                p.CloseMainWindow();
            }
            TestProcessStartInfo = null;
            TestProcess = null;
        }
        
        
    }
}
