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

namespace UIAutomationTest.Commands.Pattern
{
    /// <summary>
    /// Description of InvokeUIAWindowPatternCommandTestFixture.
    /// </summary>
    [TestFixture(Description="Invoke-UIAWindowPatternCommand test")]
    public class InvokeUIAWindowPatternCommandTestFixture
    {
        public InvokeUIAWindowPatternCommandTestFixture()
        {
        }
        
        [SetUp]
        public void PrepareRunspace()
        {
            MiddleLevelCode.PrepareRunspace();
        }
        
        [TearDown]
        public void DisposeRunspace()
        {
            MiddleLevelCode.DisposeRunspace();
        }
    }
}
