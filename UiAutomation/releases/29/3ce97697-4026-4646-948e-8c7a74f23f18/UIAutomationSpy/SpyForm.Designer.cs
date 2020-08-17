/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 24/02/2012
 * Time: 07:18 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Automation;
using System.Windows.Forms;
using System.Drawing;

namespace UIAutomationSpy
{
    partial class SpyForm
    {
        private bool stopNow = false;
        
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing" > true if managed resources should be disposed; otherwise, false.</param > 
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components  !=  null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.richResult = new System.Windows.Forms.RichTextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(20, 20);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 30);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStartClick);
            // 
            // richResult
            // 
            this.richResult.AutoWordSelection = true;
            this.richResult.HideSelection = false;
            this.richResult.Location = new System.Drawing.Point(20, 60);
            this.richResult.Name = "richResult";
            this.richResult.Size = new System.Drawing.Size(380, 80);
            this.richResult.TabIndex = 1;
            this.richResult.Text = "";
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(100, 20);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 30);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.BtnStopClick);
            // 
            // richTextBox1
            // 
            this.richTextBox1.AutoWordSelection = true;
            this.richTextBox1.HideSelection = false;
            this.richTextBox1.Location = new System.Drawing.Point(20, 146);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(380, 130);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // SpyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 291);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.richResult);
            this.Controls.Add(this.btnStart);
            this.MaximizeBox = false;
            this.Name = "SpyForm";
            this.Text = "UIAutomationSpy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SpyFormFormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SpyFormFormClosed);
            this.Resize += new System.EventHandler(this.SpyFormResize);
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.RichTextBox richResult;
        private System.Windows.Forms.Button btnStart;
        
        void btnStartClick(object sender, System.EventArgs e)
        {
            if (this.btnStart.Text == "Start") {
                stopNow = false;
                this.btnStart.Enabled = false;
                this.btnStop.Enabled = true;
                //UIAutomation.UIAHelper.
                    
                //Global.GTranscript = true;
                //int counter = 0;
                AutomationElement rootElement = 
                    System.Windows.Automation.AutomationElement.RootElement;
                //System.DateTime startDate =
                // System.DateTime.Now;
                do{
                    System.Windows.Forms.Application.DoEvents();
                    
                    try {
                        // use Windows forms mouse code instead of WPF
                        System.Drawing.Point mouse = System.Windows.Forms.Cursor.Position;
                        System.Windows.Automation.AutomationElement element = 
                            System.Windows.Automation.AutomationElement.FromPoint(
                                new System.Windows.Point(mouse.X, mouse.Y));
                        if (element != null) { // && (int)element.Current.ProcessId > 0)
                            if ((element.Current is AutomationElement.AutomationElementInformation) || 
                                (element.Cached is AutomationElement.AutomationElementInformation)) {
                                UIAutomation.TranscriptCmdletBase cmdlet = 
                                    new UIAutomation.TranscriptCmdletBase();
                                cmdlet.NoClassInformation = true;
                                cmdlet.NoScriptHeader = true;
                                cmdlet.NoUI = true;
                                cmdlet.WriteCurrentPattern = true;
                                cmdlet.Timeout = 600000000;
                                cmdlet.Highlight = true;
                                cmdlet.PassThru = false;
                                //cmdlet.Seconds = 3;
                                UIAutomation.Preferences.TranscriptInterval = 500; //200;
                                try{
                                    bool res =
                                        UIAutomation.UIAHelper.ProcessingElement(cmdlet, element);
                                    if (!res) {
                                        //this.richTextBox1.Text = "false";
//                                        stopNow = false;
//                                        continue;
                                    }
                                } 
                                catch (Exception eProcessingElement) {
                                    this.richTextBox1.Text = 
                                        "eProcessingElement element method:\r\n" + 
                                        eProcessingElement.Message;
                                    stopNow = false;
                                    continue;
                                }
                                if (cmdlet.LastRecordedItem.Count > 0) {
                                    try {
                                        this.richResult.Text = cmdlet.WritingRecord(
                                            cmdlet.LastRecordedItem,
                                            null,
                                            null,
                                            null);
                                    } 
                                    catch (Exception eCollectingElements) {
                                        // there is usually nothing to report
                                        this.richTextBox1.Text = 
                                            "Collecting:\r\n" + 
                                            eCollectingElements.Message;
                                        Exception eCollectingElements2 =
                                            new Exception(
                                                "Collecting:\r\n" + 
                                                eCollectingElements.Message);
                                        //stopNow = false;
                                        //continue;
                                        throw(eCollectingElements2);
                                        //stopNow = false;
                                    }
                                }
                            }
                        }
                    } catch (Exception eUnknown) {
                        this.richTextBox1.Text = 
                            "External cycle:\r\n" + 
                            eUnknown.Message; // +
                            //"\r\n" +
                            //eUnknown.GetType().Name; // +  
                            //"\r\n" + 
                            //eUnknown.Source +
                            //"\r\n" + 
                            //eUnknown.InnerException.Message;
                        stopNow = false;
                        continue;
//                        Exception eUnknown3 =
//                            new Exception(
//                                "Unknown3\r\n" + 
//                                eUnknown.Message);
//                        throw(eUnknown3);
                        //rootElement = 
                        // System.Windows.Automation.AutomationElement.RootElement;
                        
                    }
                    
                } while (!stopNow);
            }
        }
        
        void SpyFormFormClosing(object sender, FormClosingEventArgs e)
        {
            this.stopNow = true;
            this.Dispose(); //// ?
        }
        
        
        void BtnStopClick(object sender, EventArgs e)
        {
            this.stopNow = true;
            this.btnStop.Enabled = false;
            this.btnStart.Enabled = true;
        }
        
        void SpyFormResize(object sender, EventArgs e)
        {
            this.richResult.Width = this.Width - 60;
            /////////////////////this.richResult.Height = this.Height - 120;
            
            this.richTextBox1.Width = this.richResult.Width;            
            this.richTextBox1.Height = this.Height - 200;
        }
        
        void SpyFormFormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose(); //// ?
        }
    }
}
