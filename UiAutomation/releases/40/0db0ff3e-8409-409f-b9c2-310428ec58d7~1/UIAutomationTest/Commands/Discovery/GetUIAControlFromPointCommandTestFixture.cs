/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08.12.2011
 * Time: 11:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;
using System.Management.Automation;

namespace UIAutomationTest.Commands.Discovery
{
    /// <summary>
    /// Description of GetUIAControlFromPointCommandTestFixture.
    /// </summary>
    [TestFixture(Description="Get-UIAControlFromPointCommand test")]
    public class GetUIAControlFromPointCommandTestFixture
    {
        public GetUIAControlFromPointCommandTestFixture()
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
