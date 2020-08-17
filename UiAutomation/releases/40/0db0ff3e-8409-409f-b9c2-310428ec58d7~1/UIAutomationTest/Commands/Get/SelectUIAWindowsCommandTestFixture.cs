/*
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

namespace UIAutomationTest.Commands.Select
{
    /// <summary>
    /// Description of GetUIAWindowsCommandTestFixture.
    /// </summary>
    [TestFixture(Description="Get-UIAWindowsCommand test")]
    public class GetUIAWindowsCommandTestFixture
    {
        public GetUIAWindowsCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
//            TestRunspace.IitializeRunspace();
//            string codeSnippet = 
//                @"$ErrorPreference = [System.Management.Automation.ActionPreference]::SilentlyContinue;";
            TestRunspace.PrepareRunspace();
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            // TestRunspace.DisposeRunspace();
            TestRunspace.DisposeRunspace();
        }
    }
}
