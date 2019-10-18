﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Collections.Generic;

namespace ReportDAL
{  
    public class ReportsGenerationClass
    {
        private static string reportPath;      
        protected ExtentReports _extent;
        protected ExtentTest _test;
        protected DateTime time = DateTime.Now;
        protected static string screenShotName;
        Status logstatus;
        protected ExtentHtmlReporter _htmlReporter;

        public void ReportSetUp()
        {
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            string Todaysdate = DateTime.Now.ToString("-dd-MM-yyyy-(hh-mm-ss)");
            reportPath = Path.Combine(projectPath + "Reports", $"Report{Todaysdate}", "Screenshots");
            Directory.CreateDirectory(reportPath);
            _htmlReporter = new ExtentHtmlReporter(reportPath);
            _extent = new ExtentReports();
            _extent.AttachReporter(_htmlReporter);
            _extent.AddSystemInfo("Host Name", "LocalHost");
            _extent.AddSystemInfo("Environment", "QA");
            _extent.AddSystemInfo("UserName", "TestUser");
        }
          
        public void BeforeTest()
        {
            _test = _extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }
        public void ExtendTearDoun()
        {
            _extent.Flush();
        }

        public void AfterTest(IWebDriver driver)
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var testName = TestContext.CurrentContext.Test.Name;
            var stacktrace = TestContext.CurrentContext.Result.StackTrace
            ?? string.Format("{ 0}", TestContext.CurrentContext.Result.StackTrace);



            switch (status)
            {
                case TestStatus.Failed:
                    FailCase(driver, testName);
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }
            _test.Log(logstatus, "Test ended with " + logstatus + stacktrace);
            _extent.Flush();
        }

        private static string Capture(IWebDriver driver, String screenShotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();       
            screenshot.SaveAsFile(Path.Combine(reportPath, screenShotName), ScreenshotImageFormat.Png);
            return reportPath;
        }

        private void FailCase(IWebDriver driver, string testName)
        {
            logstatus = Status.Fail;
            DateTime time = DateTime.Now;
            screenShotName = "Screenshot_" + time.ToString("-dd-MM-yyyy-(hh-mm-ss)") + ".png";
            String screenShotPath = Capture(driver, screenShotName);
            _test.Log(Status.Fail, "Fail");
            _test.Log(Status.Fail, "Snapshot below: " + _test.AddScreenCaptureFromPath(Path.Combine(screenShotPath, screenShotName)));
            _test.Log(Status.Fail, testName);
        }
    }
}