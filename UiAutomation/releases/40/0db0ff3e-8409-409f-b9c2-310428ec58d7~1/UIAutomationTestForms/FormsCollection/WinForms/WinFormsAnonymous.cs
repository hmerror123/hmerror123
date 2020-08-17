﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08.12.2011
 * Time: 9:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UIAutomationTestForms
{
    /// <summary>
    /// Description of WinFormsAnonymous.
    /// </summary>
    public partial class WinFormsAnonymous : WinFormsForm // Form
    {
        public WinFormsAnonymous(
            System.Windows.Automation.ControlType controlType,
            int controlDelay)
        {
            this.ControlType = controlType;
            this.ControlDelay = controlDelay;
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }
    }
}
