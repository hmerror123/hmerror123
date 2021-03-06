﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 03.12.2011
 * Time: 16:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Management.Automation;

    /// <summary>
    /// Description of Preferences.
    /// </summary>
    public static class Preferences
    {
        static Preferences()
        {
            Highlight = true;
            HighlighterColor = System.Drawing.Color.Red;
            HighlighterBorder = 3;
            Timeout = 10000;
            AfterFailTurboTimeout = 2000;
            ScreenShotFolder = 
                System.Environment.GetEnvironmentVariable(
                    "TEMP",
                    EnvironmentVariableTarget.User);
            OnErrorScreenShot = false;

            TranscriptInterval = 200;
            OnSuccessDelay = 500;
            OnSuccessAction = null;
            OnErrorDelay = 500;
            OnErrorAction = null;
            OnSleepDelay = 1000;
            OnSleepAction = null;
            OnClickDelay = 0;
            Log = true;
            LogPath = 
                System.Environment.GetEnvironmentVariable(
                    "TEMP",
                    EnvironmentVariableTarget.User) + 
                @"\UIAutomation.log";
            MaximumErrorCount = 256;
            Mode.Profile = Modes.Presentation;
        }
        
        /// <summary>
        /// The flag that initiates the Highlighter to run.
        /// </summary>
        public static bool Highlight { get; set; }
        /// <summary>
        /// Color of Highlighter
        /// </summary>
        public static System.Drawing.Color HighlighterColor { get; set; }
        /// <summary>
        /// Thikness of Highlighter's border.
        /// </summary>
        public static int HighlighterBorder { get; set; }
        /// <summary>
        /// The timeout in Get- and Wait- cmdlets that abrupts
        /// the Automation tree queries' flow.
        /// MIlliseconds
        /// </summary>
        public static int Timeout
        { 
            get {
                return _timeout;
            }
            set { 
                _timeout = value;
                TimeoutSetByCustomer = true;
                StoredDefaultTimeout = 0;
            }
        }
        private static int _timeout;
        /// <summary>
        /// The timeout that is set automatically in the situation when
        /// a Get- or -Wait- cmdlet failed to retrieve an object.
        /// To prevent a series of useless queries to the Automation tree,
        /// the shorter timeout is set until an object will be caught
        /// by a cmdlet called further in code flow.
        /// After an object is gotten, the timeout that was set by default will be used.
        /// </summary>
        public static int AfterFailTurboTimeout { get; set; }
        internal static int StoredDefaultTimeout { get; set; }
        internal static bool TimeoutSetByCustomer { get; set; }
        /// <summary>
        /// The folder where screenshots are stored.
        /// </summary>
        public static string ScreenShotFolder { get; set; }
        /// <summary>
        /// this flag turns on automatic saving of screenshots 
        /// if a terminating or non-terminating error has been raised.
        /// </summary>
        public static bool OnErrorScreenShot { get; set; }
        
        /// <summary>
        /// This property defines an interval
        /// the Start-UIARecorer cmdlet queries the element
        /// beneath the cursor. Usually, the default value meets
        /// better conditions. Exceptions may be needed in highly 
        /// load environments.
        /// Milliseconds
        /// </summary>
        public static int TranscriptInterval { get; set; }
        /// <summary>
        /// The time between the requested action is performed successfully 
        /// and outputting the loot to the pipeline.
        /// Milliseconds.
        /// </summary>
        public static int OnSuccessDelay { get; set; }
        /// <summary>
        /// Common action(s) that are being run before 
        /// OnSuccessDelay and outputting to the pipeline.
        /// </summary>
        public static ScriptBlock[] OnSuccessAction { get; set; }
        /// <summary>
        /// The time interval between a terminating error 
        /// is raised and returning the error to the pipeline.
        /// Milliseconds
        /// </summary>
        public static int OnErrorDelay { get; set; }
        /// <summary>
        /// Common action(s) that are being run before 
        /// OnErrorDelay and outputting the error to the pipeline.
        /// </summary>
        public static ScriptBlock[] OnErrorAction { get; set; }
        /// <summary>
        /// The time interval of a sleep between subsequent
        /// queries of the Automation tree. Used in Get- and
        /// Wait- cmdlets.
        /// Milliseconds
        /// </summary>
        public static int OnSleepDelay { get; set; }
        /// <summary>
        /// Common action(s) that are used during the subsequent
        /// queries to the Automation tree in the Get- cmdlets.
        /// </summary>
        public static ScriptBlock[] OnSleepAction { get; set; }
        /// <summary>
        /// The time interval between a Win32 click and
        /// outputting the element clickedto the pipeline.
        /// Milliseconds
        /// </summary>
        public static int OnClickDelay { get; set; }
        /// <summary>
        /// Logging flag
        /// </summary>
        public static bool Log { get; set; }
        /// <summary>
        /// Path to the log file
        /// </summary>
        public static string LogPath { get; set; }
        private static int maximumErrorCount;
        /// <summary>
        /// The upper limit of number of errors that
        /// are stored in the Error collection.
        /// </summary>
        public static int MaximumErrorCount
        {
            get{ return maximumErrorCount; } 
            set{ maximumErrorCount = value; }
        }
        
    }
    
    public static class Mode
    {
        static Mode()
        {
            Profile = Modes.Presentation;
            Preferences.TimeoutSetByCustomer = false;
        }
        
        private static Modes mode;
        public static Modes Profile
        {
            get{ return mode; }
            set
            {
                mode = value;
                switch (value) {
                    case UIAutomation.Modes.Normal:
                        Preferences.OnSuccessDelay = 0;
                        Preferences.OnErrorDelay = 0;
                        Preferences.OnSleepDelay = 0;
                        Preferences.Highlight = false;
                        Preferences.Timeout = 10000;
                        Preferences.TimeoutSetByCustomer = true;
                        Preferences.AfterFailTurboTimeout = 2000;
                        break;
                    case UIAutomation.Modes.Debug:
                        Preferences.OnSuccessDelay = 1000;
                        Preferences.OnErrorDelay = 5000;
                        Preferences.OnSleepDelay = 1000; // ??
                        Preferences.Highlight = true;
                        Preferences.Timeout = 30000;
                        Preferences.TimeoutSetByCustomer = true;
                        Preferences.AfterFailTurboTimeout = 2000;
                        break;
                    case UIAutomation.Modes.Presentation:
                        Preferences.OnSuccessDelay = 500;
                        Preferences.OnErrorDelay = 500;
                        Preferences.OnSleepDelay = 0;
                        Preferences.Highlight = true;
                        Preferences.Timeout = 20000;
                        Preferences.TimeoutSetByCustomer = true;
                        Preferences.AfterFailTurboTimeout = 2000;
                        break;
                    default:
                        throw new Exception("Invalid value for Modes"); // case Modes.Normal:
                }
            }
        }
    }
    
    public enum Modes
    {
        Normal = 0,
        Debug = 1,
        Presentation = 2//,
        // Custom = 3 // several custom modes?
    }
}
