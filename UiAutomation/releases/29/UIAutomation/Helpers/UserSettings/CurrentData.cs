/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 16/12/2011
 * Time: 11:43 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Windows.Automation;

    /// <summary>
    /// Description of CurrentData.
    /// </summary>
    public static class CurrentData
    {
        static CurrentData()
        {
            Error = new System.Collections.ArrayList(Preferences.MaximumErrorCount);
            //TestResults = 
            // new System.Collections.Generic.List<TestResult > ();
            ////initTestResults();
        }
        
        public static AutomationElement CurrentWindow { get; internal set; }
        public static System.Collections.ArrayList Error { get; set; }
        public static string LastCmdlet { get; internal set; }
        public static object LastResult { get; internal set; }
        
        
        internal static Commands.RecorderForm formRecorder { get; set; }
        
        public static void ResetData()
        {
            CurrentWindow = null;
            Error.Clear();
            LastCmdlet = null;
            LastResult = null;
        }
        
        public static void SetCurrentWindow(AutomationElement window)
        {
            if (window is AutomationElement) {
                CurrentData.CurrentWindow = window;
            } else {
                CurrentData.CurrentWindow = null;
            }
        }
        
// private static void initTestResults()
// {
// if (TestResults.Count<1) {
// TestResults.Add(new TestResult());
// }
// }
    }
}
