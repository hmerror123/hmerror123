/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 12.12.2011
 * Time: 1:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using UIAutomation.Commands;
using UIAutomation;

using System.Reflection;

namespace UIAutomationTestForms
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            // Console.WriteLine(System.Windows.Automation.ControlType.Button.ToString());
            // Console.WriteLine(System.Windows.Automation.ControlType.Button.ProgrammaticName.ToString());
            // Console.WriteLine(System.Windows.Automation.ControlType.Button.GetType().Name);
            
            dumpTypes(System.Environment.GetEnvironmentVariable("TEMP",
                                                                EnvironmentVariableTarget.User) + 
                      @"\types.txt");
            
            if (args.Length>1 && args[1]!=null && args[1]!="")
            {
                try{
                    if ((System.Convert.ToInt32(args[0])!=0) &&
                        (System.Convert.ToInt32(args[1])!=0))
                    {
                        int sleepTime = 
                            System.Convert.ToInt32(args[1]);
                        System.Threading.Thread.Sleep(sleepTime);
                    }
                } catch {
                    // Console.WriteLine("Wrong arguments!Use numbers:");
                    // Console.WriteLine("TetUIAutomation Forms SleepBefore");
                    return; // 1;
                }
            }
            
//            if (Delay>0){
//                System.Threading.Thread.Sleep(Delay);
//            }
            
            if (args.Length>0 && args[0]!=null && args[0]!="")
            {
                Forms formCode;
                try{
                    formCode = (Forms)(System.Convert.ToInt32(args[0]));
                } catch {
                    // Console.WriteLine("Wrong arguments!Use numbers:");
                    // Console.WriteLine("TetUIAutomation Forms SleepBefore");
                    return; // 2;
                }
    
                System.Windows.Forms.Application.EnableVisualStyles();
                System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
                // System.Windows.Forms.Application.Run(new MainForm());
                
                
                System.Windows.Automation.ControlType ctrlType = null;
                if (args.Length>2 && args[2]!=null && args[2]!=""){
                    // string _controlType = String.Empty;
                    //_controlType = args[2].ToUpper();
                    ctrlType = 
                        UIAHelper.GetControlTypeByTypeName(args[2]);
//                    switch (_controlType)
//                    {
//                        case "BUTTON": { ctrlType = System.Windows.Automation.ControlType.Button; break; }
//                        case "CALENDAR": { ctrlType = System.Windows.Automation.ControlType.Calendar; break; }
//                        case "CHECKBOX": { ctrlType = System.Windows.Automation.ControlType.CheckBox; break; }
//                        case "COMBOBOX": { ctrlType = System.Windows.Automation.ControlType.ComboBox; break; }
//                        case "CUSTOM": { ctrlType = System.Windows.Automation.ControlType.Custom; break; }
//                        case "DATAGRID": { ctrlType = System.Windows.Automation.ControlType.DataGrid; break; }
//                        case "DATAITEM": { ctrlType = System.Windows.Automation.ControlType.DataItem; break; }
//                        case "DOCUMENT": { ctrlType = System.Windows.Automation.ControlType.Document; break; }
//                        case "EDIT": { ctrlType = System.Windows.Automation.ControlType.Edit; break; }
//                        case "GROUP": { ctrlType = System.Windows.Automation.ControlType.Group; break; }
//                        case "HEADER": { ctrlType = System.Windows.Automation.ControlType.Header; break; }
//                        case "HEADERITEM": { ctrlType = System.Windows.Automation.ControlType.HeaderItem; break; }
//                        case "HYPERLINK": { ctrlType = System.Windows.Automation.ControlType.Hyperlink; break; }
//                        case "IMAGE": { ctrlType = System.Windows.Automation.ControlType.Image; break; }
//                        case "LIST": { ctrlType = System.Windows.Automation.ControlType.List; break; }
//                        case "LISTITEM": { ctrlType = System.Windows.Automation.ControlType.ListItem; break; }
//                        case "MENU": { ctrlType = System.Windows.Automation.ControlType.Menu; break; }
//                        case "MENUBAR": { ctrlType = System.Windows.Automation.ControlType.MenuBar; break; }
//                        case "MENUITEM": { ctrlType = System.Windows.Automation.ControlType.MenuItem; break; }
//                        case "PANE": { ctrlType = System.Windows.Automation.ControlType.Pane; break; }
//                        case "PROGRESSBAR": { ctrlType = System.Windows.Automation.ControlType.ProgressBar; break; }
//                        case "RADIOBUTTON": { ctrlType = System.Windows.Automation.ControlType.RadioButton; break; }
//                        case "SCROLLBAR": { ctrlType = System.Windows.Automation.ControlType.ScrollBar; break; }
//                        case "SEPARATOR": { ctrlType = System.Windows.Automation.ControlType.Separator; break; }
//                        case "SLIDER": { ctrlType = System.Windows.Automation.ControlType.Slider; break; }
//                        case "SPINNER": { ctrlType = System.Windows.Automation.ControlType.Spinner; break; }
//                        case "SPLITBUTTON": { ctrlType = System.Windows.Automation.ControlType.SplitButton; break; }
//                        case "STATUSBAR": { ctrlType = System.Windows.Automation.ControlType.StatusBar; break; }
//                        case "TAB": { ctrlType = System.Windows.Automation.ControlType.Tab; break; }
//                        case "TABITEM": { ctrlType = System.Windows.Automation.ControlType.TabItem; break; }
//                        case "TABLE": { ctrlType = System.Windows.Automation.ControlType.Table; break; }
//                        case "TEXT": { ctrlType = System.Windows.Automation.ControlType.Text; break; }
//                        case "THUMB": { ctrlType = System.Windows.Automation.ControlType.Thumb; break; }
//                        case "TITLEBAR": { ctrlType = System.Windows.Automation.ControlType.TitleBar; break; }
//                        case "TOOLBAR": { ctrlType = System.Windows.Automation.ControlType.ToolBar; break; }
//                        case "TOOLTIP": { ctrlType = System.Windows.Automation.ControlType.ToolTip; break; }
//                        case "TREE": { ctrlType = System.Windows.Automation.ControlType.Tree; break; }
//                        case "TREEITEM": { ctrlType = System.Windows.Automation.ControlType.TreeItem; break; }
//                        case "WINDOW": { ctrlType = System.Windows.Automation.ControlType.Window; break; }
//                        default:
//                            ctrlType = null;
//                            break;
//                    }
                }
                
                int controlDelay = 0;
                if (args.Length>3 && args[3]!=null && args[3]!=""){
                    try{
                        controlDelay = System.Convert.ToInt32(args[3]);
                    } catch { }
                }
                
                switch (formCode)
                {
                    case Forms.WinFormsEmpty:
                        System.Windows.Forms.Application.Run(
                            new WinFormsEmpty(ctrlType, controlDelay));
                        // WinFormsEmpty frmWFE = new WinFormsEmpty();
                        // frmWFE.ShowDialog();
                        break;
                    case Forms.WinFormsEmptyX2:
                        System.Windows.Forms.Application.Run(
                            new WinFormsEmpty(ctrlType, controlDelay));
                        System.Windows.Forms.Application.Run(
                            new WinFormsEmpty(ctrlType, controlDelay));
                        break;
                    case Forms.WinFormsAnonymous:
                        System.Windows.Forms.Application.Run(
                            new WinFormsAnonymous(
                                ctrlType, controlDelay));
                        break;
                    case Forms.WinFormsMinimized:
                        System.Windows.Forms.Application.Run(
                            new WinFormsMinimized(ctrlType, controlDelay));
                        break;
                    case Forms.WinFormsMaximized:
                        System.Windows.Forms.Application.Run(
                            new WinFormsMaximized(ctrlType, controlDelay));
                        break;
                    case Forms.WinFormsNoTaskBar:
                        System.Windows.Forms.Application.Run(
                            new WinFormsNoTaskBar(ctrlType, controlDelay));
                        break;
                    case Forms.WinFormsRich:
                        System.Windows.Forms.Application.Run(
                            new WinFormsRich(ctrlType, controlDelay));
                        break;
                    
                        
                    case Forms.WPFEmpty:
                        WPFEmpty frmWPFE = new WPFEmpty();
                        frmWPFE.ShowDialog();
                        break;
                    case Forms.WPFEmptyX2:
                        WPFEmpty frmWPFE1 = new WPFEmpty();
                        frmWPFE1.ShowDialog();
                        WPFEmpty frmWPFE2 = new WPFEmpty();
                        frmWPFE2.ShowDialog();
                        break;
                    case Forms.WPFAnonymous:
                        WPFAnonymous frmWPFA = new WPFAnonymous();
                        frmWPFA.ShowDialog();
                        break;
                    case Forms.WPFMinimized:
                        WPFMinimized frmWPFMi = new WPFMinimized();
                        frmWPFMi.ShowDialog();
                        break;
                    case Forms.WPFMaximized:
                        WPFMaximized frmWPFMa = new WPFMaximized();
                        frmWPFMa.ShowDialog();
                        break;
                    case Forms.WPFCollapsed:
                        WPFCollapsed frmWPFCo = new WPFCollapsed();
                        frmWPFCo.ShowDialog();
                        break;
                        
                }
            }
        }
        
        private static void dumpTypes(string path)
        {
            Assembly[] allAssms = 
                System.AppDomain.CurrentDomain.GetAssemblies();
            
            System.IO.StreamWriter writer = 
                new System.IO.StreamWriter(path);
            
            foreach(Assembly asm in allAssms){
                if (asm.FullName.Contains("UIAutomation,")){
                    Type[] types = 
                        asm.GetTypes();
                    foreach (Type t in types){
                        
                        if (t.FullName.Contains("UIAutomation.Commands")){
                            // Console.WriteLine(t.FullName);
                            PropertyInfo[] properties = 
                                t.GetProperties(); // BindingFlags.Instance);
                            foreach(PropertyInfo property in properties){
                                // Console.WriteLine(property.Name);
                                // Console.WriteLine(property.PropertyType);
                                // Console.WriteLine(property.Attributes);
                                // Console.WriteLine(t.FullName + "\t" + property.Name + "\t" + property.PropertyType);
                                if (property.Name!="ParameterSetName" && 
                                    property.Name!="MyInvocation" && 
                                    property.Name!="InvokeCommand" && 
                                    property.Name!="Host" && 
                                    property.Name!="SessionState" && 
                                    property.Name!="Events" && 
                                    property.Name!="JobRepository" && 
                                    property.Name!="InvokeProvider" && 
                                    property.Name!="Stopping" && 
                                    property.Name!="CommandRuntime" && 
                                    property.Name!="CurrentPSTransaction" && 
                                    property.Name!="CommandOrigin"){
                                    if (t.FullName.Contains(".Get") ||
                                        t.FullName.Contains(".Set") ||
                                        t.FullName.Contains(".Invoke") ||
                                        t.FullName.Contains(".Register") ||
                                        t.FullName.Contains(".Unregister") ||
                                        t.FullName.Contains(".Out") ||
                                        t.FullName.Contains(".ConvertFrom") ||
                                        t.FullName.Contains(".Move") ||
                                        t.FullName.Contains(".Start") ||
                                        t.FullName.Contains(".Stop") ||
                                        t.FullName.Contains(".Wait")){
                                    writer.WriteLine(t.FullName.Replace("UIAutomation.Commands.", "").Replace("Command", "").
                                                         Replace("UIA", "-UIA") + "\t" + property.Name + "\t" + property.PropertyType);
                                        }
                                }
                            }
                        }
                    }
                    Console.WriteLine("!");
                }
            }
            
            writer.Flush();
            writer.Close();
        }
    }
    
    public enum Forms
    {
        WinFormsEmpty = 1,
        WinFormsEmptyX2 = 2,
        WinFormsAnonymous = 3,
        WinFormsMinimized = 4,
        WinFormsMaximized = 5,
        WinFormsNoTaskBar = 11,
        WinFormsRich = 31,
        
        
        WPFEmpty = 101,
        WPFEmptyX2 = 102,
        WPFAnonymous = 103,
        WPFMinimized = 104,
        WPFMaximized = 105,
        WPFCollapsed = 106,
        
        WPFRich = 131
        
    }
}