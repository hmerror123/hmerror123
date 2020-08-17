/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 08.12.2011
 * Time: 11:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;
using System.Management.Automation;

namespace UIAutomationTest.Commands.Wait
{
    /// <summary>
    /// Description of WaitUIAControlIsEnabledCommandTestFixture.
    /// </summary>
    [TestFixture(Description="Wait-UIAControlIsEnabledCommand test")]
    public class WaitUIAControlIsEnabledCommandTestFixture
    {
        public WaitUIAControlIsEnabledCommandTestFixture()
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
