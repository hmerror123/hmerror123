/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12.12.2011
 * Time: 12:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace UIAutomationTestForms
{
    /// <summary>
    /// Description of WinFormsForm.
    /// </summary>
    public partial class WinFormsForm : Form
    {
        public WinFormsForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }
        
        protected System.Windows.Automation.ControlType ControlType;
        protected int ControlDelay = 0;
        protected System.Windows.Forms.Form ChildForm;
        
        void WinFormsFormShown(object sender, EventArgs e)
        {
// Console.WriteLine("Shown");
            System.Threading.Thread.Sleep(this.ControlDelay);
// Console.WriteLine("Sleeped");
            if (this.ControlType==null){ return; }
// Console.WriteLine("not null");
            // string _controlType = this.ControlType.ToString();
            string _controlType = this.ControlType.ProgrammaticName.Substring(
                this.ControlType.ProgrammaticName.IndexOf(".") + 1);
// Console.WriteLine(_controlType);
            switch (_controlType) {
                case "Button":
                    Button b = new Button();
                    b.Name = _controlType;
                    b.Text = _controlType;
                    b.Visible = true;
                    // this.Controls.Add(b);
                    ChildForm.Controls.Add(b);
                    break;
                default:
                    
                    break;
            }
        }
    }
}
