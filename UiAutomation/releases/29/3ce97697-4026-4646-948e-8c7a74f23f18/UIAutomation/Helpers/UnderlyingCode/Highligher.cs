﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08/02/2012
 * Time: 09:08 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomation
{
    using System;
    using System.Windows.Automation;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;

    /// <summary>
    /// Description of Highlighter.
    /// </summary>
    public class Highlighter : IDisposable
    {
        
//        public struct CursorPoint
//        {
//            public int X;
//            public int Y;
//        }
//        
//        [System.Runtime.InteropServices.DllImport("user32.dll")]
//        [return: MarshalAs(UnmanagedType.Bool)]
//        internal static extern bool GetPhysicalCursorPos(ref CursorPoint lpPoint);
//        
//        [System.Runtime.InteropServices.DllImport("user32.dll")]
//        [return: MarshalAs(UnmanagedType.Bool)]
//        internal static extern bool PhysicalToLogicalPoint(IntPtr hWnd, ref CursorPoint lpPoint);
        
        internal Side leftSide = null;
        internal Side topSide = null;
        internal Side rightSide = null;
        internal Side bottomSide = null;
        
        public Highlighter(AutomationElement element)
        {
            try {
                if (element != null) { // &&
                    //((element.Cached.BoundingRectangle != null) ||
                    // ((int)element.Current.ProcessId > 0))) {
                    paintLeftSide(element);
                    paintTopSide(element);
                    paintRightSide(element);
                    paintBottomSide(element);
                }
            }
            catch { //(Exception eHighlighter) {
                // usually nothing to do
                //throw (eHighlighter);
//                Exception eHighlighter2 = 
//                    new Exception(
//                        "public Highlighter(AutomationElement element)\r\n" + 
//                        eHighlighter.Message);
//                throw (eHighlighter2);
            }
        }
        
        public void Dispose()
        {
            leftSide.Dispose();
            topSide.Dispose();
            rightSide.Dispose();
            bottomSide.Dispose();
        }
        
        private  NativeMethods.CursorPoint getPoint(AutomationElement element)
        {
            NativeMethods.CursorPoint p = new NativeMethods.CursorPoint();
            p.X = (int)element.Current.BoundingRectangle.X;
            p.Y = (int)element.Current.BoundingRectangle.Y;
            if (element.Current.NativeWindowHandle != 0) {
                try { // Windows Vista or higher only
                    IntPtr handle = 
                        new IntPtr(element.Current.NativeWindowHandle);
                     NativeMethods.PhysicalToLogicalPoint(handle, ref p);
                } 
                catch {}
            }
            return p;
        }
        
        private void paintLeftSide(AutomationElement element)
        {
            NativeMethods.CursorPoint p = getPoint(element);
            leftSide = new Side(p.X - (Preferences.HighlighterBorder / 2),
                                p.Y,
                                Preferences.HighlighterBorder,
                                element.Current.BoundingRectangle.Height);
        }
        
        private void paintTopSide(AutomationElement element)
        {
            NativeMethods.CursorPoint p = getPoint(element);
            topSide = new Side(p.X,
                               p.Y - (Preferences.HighlighterBorder / 2),
                                element.Current.BoundingRectangle.Width,
                                Preferences.HighlighterBorder);
        }
        
        private void paintRightSide(AutomationElement element)
        {
            NativeMethods.CursorPoint p = getPoint(element);
            rightSide = new Side(p.X +
                                 element.Current.BoundingRectangle.Width - 
                                     (Preferences.HighlighterBorder / 2),
                                p.Y,
                                Preferences.HighlighterBorder,
                                element.Current.BoundingRectangle.Height);
        }
        
        private void paintBottomSide(AutomationElement element)
        {
            NativeMethods.CursorPoint p = getPoint(element);
            bottomSide = new Side(p.X,
                                p.Y +
                                element.Current.BoundingRectangle.Height - 
                                    (Preferences.HighlighterBorder / 2),
                                element.Current.BoundingRectangle.Width,
                                Preferences.HighlighterBorder);
        }
    }
    
    internal class Side : Form, IDisposable
    {
        
        public Side(double left, double top, double width, double height)
        {
            this.Left = 0;
            this.Top = 0;
            this.Width = 1;
            this.Height = 1;
            this.TopMost = true;
            //this.FormBorderStyle = FormBorderStyle.None;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Visible = false;
            this.Opacity = 0.5;
            this.BackColor = Preferences.HighlighterColor;
            this.ForeColor = Preferences.HighlighterColor;
            
            this.AllowTransparency = true;
            this.ControlBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopLevel = true;
            this.UseWaitCursor = false;
            this.WindowState = FormWindowState.Normal;
            this.Show();
            this.Hide();
            this.Left = (int)left;
            this.Top = (int)top;
            this.Width = (int)width;
            this.Height = (int)height;
            this.Enabled = false;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.ShowInTaskbar = false;
            this.UseWaitCursor = false;
            this.Visible = true;
            this.Show();
        }
        
        public new void Dispose()
        {
            this.Close();
        }
    }
}
