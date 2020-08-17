/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 4/2/2012
 * Time: 10:22 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace UIAutomationTest.Commands.Settings
{
    using System;
    using NUnit.Framework;
    using System.Management.Automation;

    /// <summary>
    /// Description of SetUIAOnSleepActionSettingsCommandTestFixture.
    /// </summary>
    [TestFixture(Description="Set-UIAOnSleepActionSettingsCommand test")]
    public class SetUIAOnSleepActionSettingsCommandTestFixture
    {
        public SetUIAOnSleepActionSettingsCommandTestFixture()
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
