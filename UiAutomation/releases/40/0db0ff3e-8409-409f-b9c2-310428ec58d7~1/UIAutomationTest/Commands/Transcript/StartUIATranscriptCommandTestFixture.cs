﻿/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08.12.2011
 * Time: 11:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;
using System.Management.Automation;

namespace UIAutomationTest.Commands.Transcript
{
    /// <summary>
    /// Description of StartUIATranscriptCommandTestFixture.
    /// </summary>
    [TestFixture(Description="Start-UIATranscriptCommand test")]
    public class StartUIATranscriptCommandTestFixture
    {
        public StartUIATranscriptCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            TestRunspace.PrepareRunspace();
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            TestRunspace.DisposeRunspace();
        }
    }
}
