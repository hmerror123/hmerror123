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
using System.Reflection;
using System.Windows.Forms;

namespace UIAutomationTestForms
{
    /// <summary>
    /// Description of WinFormsForm.
    /// </summary>
    public partial class WinFormsForm : Form
    {
//        public WinFormsForm()
//        {
//            //  // The InitializeComponent() call is required for Windows Forms designer support.
//            // InitializeComponent();
//            
//            //  // TODO: Add constructor code after the InitializeComponent() call.
//            // 
//        }
        
        protected WinFormsForm(
            string formName,
            string formTitle,
            System.Windows.Automation.ControlType controlType,
            int controlDelay)
        {
            this.ControlType = controlType;
            this.ControlDelay = controlDelay;
            this.FormName = formName;
            this.FormTitle = formTitle;
            //this.ChildForm = this;
            //  // The InitializeComponent() call is required for Windows Forms designer support.
            // 
            InitializeComponent();
            
            //  // TODO: Add constructor code after the InitializeComponent() call.
            // 
        }
        
        protected WinFormsForm(
            string formName,
            string formTitle,
            System.Windows.Automation.ControlType controlType,
            string controlName,
            string controlAutomationId,
            int controlDelay)
        {
            this.ControlType = controlType;
            this.ControlDelay = controlDelay;
            this.ControlName = controlName;
            this.ControlAutomationId = controlAutomationId;
            this.FormName = formName;
            this.FormTitle = formTitle;
            //this.ChildForm = this;
            //  // The InitializeComponent() call is required for Windows Forms designer support.
            // 
            InitializeComponent();
            
            //  // TODO: Add constructor code after the InitializeComponent() call.
            // 
        }
        
        protected System.Windows.Automation.ControlType ControlType;
        protected int ControlDelay; // = 0;
        protected System.Windows.Forms.Form ChildForm;
        protected string ControlName;
        protected string ControlAutomationId;
        private string FormName;
        private string FormTitle;
        
        void WinFormsFormShown(object sender, EventArgs e)
        {
// Console.WriteLine("Shown");
            //System.Threading.Thread.Sleep(this.ControlDelay);
// Console.WriteLine("Sleeped");
            if (this.ControlType == null) { return; }
// Console.WriteLine("not null");
            // string _controlType = this.ControlType.ToString();
            string _controlType = this.ControlType.ProgrammaticName.Substring(
                this.ControlType.ProgrammaticName.IndexOf(".") + 1);
// Console.WriteLine(_controlType);
            switch (_controlType) {
                case "Button":
                    Button b = new Button();
                    loadControl(b, _controlType);
//                    if (this.ControlName != string.Empty){
//                        b.Text = this.ControlName;
//                    } else {
//                        b.Text = _controlType;
//                    }
//                    if (this.ControlAutomationId != string.Empty){
//                        b.Name = this.ControlAutomationId;
//                    } else {
//                        b.Name = _controlType;
//                    }
//                    b.Visible = true;
//                    // this.Controls.Add(b);
//                    ChildForm.Controls.Add(b);
                    break;
                case "MonthCalendar":
                case "Calendar":
                    MonthCalendar mc = new MonthCalendar();
                    loadControl(mc, _controlType);
                    break;
                case "CheckBox":
                    CheckBox chk = new CheckBox();
                    loadControl(chk, _controlType);
                    break;
                case "ComboBox":
                    ComboBox cmb = new ComboBox();
                    loadControl(cmb, _controlType);
                    break;
                case "GroupBox":
                case "Group":
                    GroupBox gb = new GroupBox();
                    loadControl(gb, _controlType);
                    break;
                case "Label":
                case "Text":
                    Label l = new Label();
                    loadControl(l, _controlType);
                    break;
                case "ListBox":
                case "List":
                    ListBox lb = new ListBox();
                    loadControl(lb, _controlType);
                    break;
                case "ListView":
                //case "Table":
                    ListView lv = new ListView();
                    loadControl(lv, _controlType);
                    break;
                case "MenuBar":
                    MenuStrip ms = new MenuStrip();
                    loadControl(ms, _controlType);
                    break;
                case "ProgressBar":
                    ProgressBar pb = new ProgressBar();
                    loadControl(pb, _controlType);
                    break;
                case "RadioButton":
                    RadioButton rb = new RadioButton();
                    loadControl(rb, _controlType);
                    break;
                case "RichTextBox":
                case "Document":
                    RichTextBox rtb = new RichTextBox();
                    loadControl(rtb, _controlType);
                    break;
                case "StatusBar":
                    StatusBar sb = new StatusBar();
                    loadControl(sb, _controlType);
                    break;
                case "Table":
                    PropertyGrid pg = new PropertyGrid();
                    loadControl(pg, _controlType);
                    break;
                case "TextBox":
                case "Edit":
                    TextBox tb = new TextBox();
                    loadControl(tb, _controlType);
                    break;
                case "TreeView":
                case "Tree":
                    TreeView tv = new TreeView();
                    loadControl(tv, _controlType);
                    break;
                default:
                    //System.Windows.Forms.DataGridTextBox
                    //System.Windows.Forms.DataGridView
                    //System.Windows.Forms.GridItem
                    //System.Windows.Forms.DomainUpDown
                    //System.Windows.Forms.RichTextBox
                    //System.Windows.Automation.ControlType.Document
                    break;
            }
        }
        
        private void loadControl<T>(T control, string _controlType)
        {
            if (this.ControlName != string.Empty){
                (control as System.Windows.Forms.Control).GetType().GetProperty("Text").SetValue(control, this.ControlName, null);
            } else {
                (control as System.Windows.Forms.Control).GetType().GetProperty("Text").SetValue(control, _controlType, null);
            }
            if (this.ControlAutomationId != string.Empty){
                (control as System.Windows.Forms.Control).GetType().GetProperty("Name").SetValue(control, this.ControlAutomationId, null);
            } else {
                (control as System.Windows.Forms.Control).GetType().GetProperty("Name").SetValue(control, _controlType, null);
            }
            (control as System.Windows.Forms.Control).Visible = false;
            // this.Controls.Add(b);
            this.ChildForm.Controls.Add(control as System.Windows.Forms.Control);
            
            ShowControl showControlDelegate = new ShowControl(runTimeout);
            // WriteVerbose(this, "runScriptBlocks 5 fired");
            showControlDelegate(this.ControlDelay, control as System.Windows.Forms.Control);
        }
        
        private void runTimeout(int timeout, System.Windows.Forms.Control control)
        {
            System.Threading.Thread.Sleep(timeout);
            control.Visible = true;
        }
        
    }
    
    delegate void ShowControl(int timeout, System.Windows.Forms.Control control);
}
