/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08.12.2011
 * Time: 11:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Get
{
    using System;
    using NUnit.Framework;
    using System.Management.Automation;

    /// <summary>
    /// Description of GetUIAControlsCommandTestFixture.
    /// </summary>
    //[TestFixture(Description="Get-UIAControlsCommand test")]
    public class GetUIAControlsCommandTestFixture
    {
        public GetUIAControlsCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
// CmdletUnitTest.TestRunspace.IitializeRunspace();
// string codeSnippet = 
// @"$ErrorPreference = [System.Management.Automation.ActionPreference]::SilentlyContinue;";
            MiddleLevelCode.PrepareRunspace();
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
