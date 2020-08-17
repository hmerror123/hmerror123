/*
 * Created by SharpDevelop.
 * User: Alexander Petrovskiy
 * Date: 07/12/2011
 * Time: 09:09 p.m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace CmdletUnitTest
{
    using System;
    using System.Diagnostics;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    
    using NUnit.Framework;
    //using UIAutomationTest;
    
    /// <summary>
    /// Description of TestRunspace.
    /// </summary>
    public static class TestRunspace
    {
        private static Runspace testRunSpace;

        public static bool IitializeRunspace(string command)
        {
            bool result = false;
            try {
                testRunSpace = null;
                testRunSpace = RunspaceFactory.CreateRunspace();
                testRunSpace.Open();
                Pipeline cmd = 
                    testRunSpace.CreatePipeline(command);
                cmd.Invoke();
//Console.WriteLine("init runspace");
                result = true;
            } 
            catch (Exception eInitRunspace) {
                Console.WriteLine(eInitRunspace.Message);
                result = false;
            }
            return result;
        }
        
        public static System.Collections.ObjectModel.Collection<PSObject> RunPSCode(string codeSnippet)
        {
            System.Collections.ObjectModel.Collection<PSObject >  result = null;
                try {
                Pipeline cmd = 
                    testRunSpace.CreatePipeline(codeSnippet);
                System.Collections.ObjectModel.Collection<PSObject> resultObject = 
                    cmd.Invoke();
                return resultObject;
            } 
            catch (Exception eRunspace) {
                Console.WriteLine(eRunspace.Message);
                result = null;
            }
            return result;
        }
        
        public static bool CloseRunspace()
        {
            bool result = false;
            testRunSpace.Close();
            testRunSpace.Dispose();
            testRunSpace = null;
            return result;
        }
        
        public static void RunAndGetTheException(
            string codeSnippet, 
            string exceptionType,
            string message)
        {
            reportRunningCode(codeSnippet);
            try{
                System.Collections.ObjectModel.Collection<PSObject> coll =
                    TestRunspace.RunPSCode(codeSnippet);
            }
            catch (Exception ee) {
//                if (typeof(e) != exceptionType) {
//                    Assert.AreNotEqual(typeof(e), exceptionType);
//                }
                Assert.AreNotEqual(exceptionType, ee.GetType().Name);
                Assert.AreNotEqual(message, ee.Message);
            }
            finishRunningCode();
        }
        
        public static void RunAndEvaluateAreEqual1(string codeSnippet)
        {
            RunAndEvaluateAreEqual(codeSnippet, "1");
        }
        
        public static void RunAndEvaluateIsNull(string codeSnippet)
        {
            reportRunningCode(codeSnippet);
            System.Collections.ObjectModel.Collection<PSObject> coll =
                TestRunspace.RunPSCode(codeSnippet);
            // Assert.AreEqual("1", coll[0].ToString());
            Assert.IsNull(coll);
            finishRunningCode();
        }
        
        public static void RunAndEvaluateIsTrue(string codeSnippet,
                                                string strValue)
        {
            reportRunningCode(codeSnippet);
            System.Collections.ObjectModel.Collection<PSObject> coll =
                TestRunspace.RunPSCode(codeSnippet);
            Assert.IsTrue(coll[0].ToString() == strValue);
            finishRunningCode();
        }
        
        public static void RunAndEvaluateAreEqual(string codeSnippet, 
                                                  string strValue)
        {
            reportRunningCode(codeSnippet);
            System.Collections.ObjectModel.Collection<PSObject> coll =
                TestRunspace.RunPSCode(codeSnippet);
            Assert.AreEqual(strValue, coll[0].ToString());
            finishRunningCode();
        }
        
        public static void RunAndEvaluateAreEqual(string codeSnippet, 
                                                  System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> strValues)
        {
            reportRunningCode(codeSnippet);
            System.Collections.ObjectModel.Collection<PSObject> coll =
                TestRunspace.RunPSCode(codeSnippet);
            Assert.AreEqual(strValues, coll);
            finishRunningCode();
        }
        
        private static void reportRunningCode(string codeSnippet)
        {
            finishRunningCode();
            Console.WriteLine(codeSnippet);
        }
        
        private static void finishRunningCode()
        {
            Console.WriteLine(" ==  ==  ==  ==  ==  ==  ==  ==  ==  == Running code: ==  ==  ==  ==  ==  ==  ==  ==  ==  == =");
        }
    }
}