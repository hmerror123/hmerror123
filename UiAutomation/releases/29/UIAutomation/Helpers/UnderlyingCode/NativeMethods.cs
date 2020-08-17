/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 3/5/2012
 * Time: 9:29 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Runtime.InteropServices;
    
    /// <summary>
    /// Description of NativeMethods.
    /// </summary>
    internal static class NativeMethods
    {
        static NativeMethods()
        {
        }
        
        #region Screenshot taking
        [DllImport("user32.dll")] 
        internal extern static IntPtr GetDesktopWindow();
  
        [DllImport("user32.dll")] 
        internal static extern IntPtr GetWindowDC(IntPtr hwnd);
         
        [DllImport("user32.dll")] 
        internal static extern IntPtr ReleaseDC(IntPtr hwnd, IntPtr hDc); 
  
        [DllImport("gdi32.dll")] 
         internal static extern UInt64 BitBlt 
             (IntPtr hDestDC, 
             int x, int y, int nWidth, int nHeight, 
             IntPtr hSrcDC, 
             int xSrc, int ySrc, 
             System.Int32 dwRop); 
         
        [Flags]
        internal enum DrawingOptions
        {
            PRF_CHECKVISIBLE = 0x00000001,
            PRF_NONCLIENT = 0x00000002,
            PRF_CLIENT = 0x00000004,
            PRF_ERASEBKGND = 0x00000008,
            PRF_CHILDREN = 0x00000010,
            PRF_OWNED = 0x00000020
        }

        internal const int WM_PRINT = 0x0317;
        internal const int WM_PRINTCLIENT = 0x0318;

        [DllImport("user32.dll")]
        internal static extern int SendMessage(IntPtr hWnd, int msg, IntPtr dc,
            DrawingOptions opts);

        #endregion Screenshot taking
        
        [DllImport("user32.dll")] 
        internal extern static IntPtr GetFocus();
        
        #region Highligher
        internal struct CursorPoint
        {
            internal int X;
            internal int Y;
        }
        
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool GetPhysicalCursorPos(ref CursorPoint lpPoint);
        
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool PhysicalToLogicalPoint(IntPtr hWnd, ref CursorPoint lpPoint);
        #endregion Highlighter
        
        #region the click
        #region declarations
        // http://msdn.microsoft.com/en-us/library/windows/desktop/ms646244(v=vs.85).aspx
        internal static uint WM_MOUSEACTIVATE             = 0x0021;
        internal static uint WM_LBUTTONDOWN               = 0x0201;
        internal static uint WM_LBUTTONUP                 = 0x0202;
        internal static uint WM_LBUTTONDBLCLK             = 0x0203;
        internal static uint WM_RBUTTONDOWN               = 0x0204;
        internal static uint WM_RBUTTONUP                 = 0x0205;
        internal static uint WM_RBUTTONDBLCLK             = 0x0206;
        internal static uint WM_MBUTTONDOWN               = 0x0207;
        internal static uint WM_MBUTTONUP                 = 0x0208;
        internal static uint WM_MBUTTONDBLCLK             = 0x0209;
        
        internal static uint MK_CONTROL                    = 0x0008;    // The CTRL key is down.
        internal static uint MK_LBUTTON                    = 0x0001;    // The left mouse button is down.
        internal static uint MK_MBUTTON                    = 0x0010;    // The middle mouse button is down.
        internal static uint MK_RBUTTON                    = 0x0002;    // The right mouse button is down.
        internal static uint MK_SHIFT                        = 0x0004;    // The SHIFT key is down.
        // 20120206 internal static uint MK_XBUTTON1                    = 0x0020;    // The first X button is down.
        // 20120206 internal static uint MK_XBUTTON2                    = 0x0040;    // The second X button is down.
        
        internal static uint WM_KEYDOWN                   = 0x0100;
        internal static uint WM_KEYUP                     = 0x0101;
        internal static uint WM_SYSKEYDOWN                = 0x0104;
        internal static uint WM_SYSKEYUP                  = 0x0105;
        
        // http://msdn.microsoft.com/en-us/library/ms927178.aspx
        internal static uint VK_SHIFT                        = 0x0010;    // SHIFT key
        internal static uint VK_CONTROL                    = 0x0011;    // CTRL key
        
        internal static uint VK_LSHIFT                    = 0xA0;    // Left SHIFT
        internal static uint VK_RSHIFT                    = 0xA1;    // Right SHIFT
        internal static uint VK_LCONTROL                    = 0xA2;    // Left CTRL
        internal static uint VK_RCONTROL                    = 0xA3;    // Right CTRL
            
        [DllImport("user32.dll", EntryPoint = "PostMessage", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool PostMessage1(IntPtr hWnd, uint Msg,
                                                IntPtr wParam, IntPtr lParam);
        
        [DllImport("user32.dll", EntryPoint = "SendMessage", CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SendMessage1(IntPtr hWnd, uint Msg,
                                                IntPtr wParam, IntPtr lParam);
        
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SetCursorPos(int X, int Y);
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "INPUT")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "MOUSE")]
        internal static int INPUT_MOUSE = 0;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "INPUT")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "KEYBOARD")]
        internal static int INPUT_KEYBOARD = 1;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "INPUT")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "HARDWARE")]
        internal static int INPUT_HARDWARE = 2;
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "KEYEVENTF")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "EXTENDEDKEY")]
        internal static uint KEYEVENTF_EXTENDEDKEY = 0x0001;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "KEYEVENTF")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "KEYUP")]
        internal static uint KEYEVENTF_KEYUP = 0x0002;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "KEYEVENTF")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "UNICODE")]
        internal static uint KEYEVENTF_UNICODE = 0x0004;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "KEYEVENTF")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "SCANCODE")]
        internal static uint KEYEVENTF_SCANCODE = 0x0008;
        

        
        [DllImport("user32.dll", SetLastError = true)]
        // internal static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);
        //internal static extern uint SendInput(uint nInputs, INPUT pInputs, int cbSize);
        private static extern uint SendInput(uint nInputs, INPUT pInputs, int cbSize);
        
// [DllImport("user32.dll")]
// internal static extern void keybd_event(byte bVk, byte bScan, uint dwFlags,
// UIntPtr dwExtraInfo);
        
        [DllImport("user32.dll")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "keybd")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "event")]
        internal static extern void keybd_event(byte bVk, byte bScan, uint dwFlags,
           int dwExtraInfo);
        
        
        [DllImport("user32.dll")]
        internal static extern short GetKeyState(uint vkCode);
        
        #endregion declarations
        #endregion the click
        
        #region Set-UIAControlText
        #region declarations
        internal static uint WM_CHAR                        = 0x0102;
        // 20120206 uint WM_SETTEXT                        = 0x000C;
// uint WM_KEYDOWN                        = 0x0100;
// uint WM_KEYUP                        = 0x0100;


            
        [DllImport("user32.dll", EntryPoint="SendMessage", CharSet=CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SendMessage1(IntPtr hWnd, uint Msg,
                                        int wParam, int lParam);
        #endregion declarations
        #endregion Set-UIAControlText
        
        #region Get-UIAActiveWindow
        #region declarations
        [DllImport("user32.dll")]
        internal static extern IntPtr GetForegroundWindow();
        #endregion declarations
        #endregion Get-UIAActiveWindow
        
    }
}
