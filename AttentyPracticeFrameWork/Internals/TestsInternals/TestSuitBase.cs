using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using ReportDAL;
using System;
using System.IO;
using System.Net.Http;

namespace Tests
{
     public class TestSuitBase : ReportsGenerationClass
    {
        public IWebDriver driver;
        public string convectorSiteUrl = "https://www.metric-conversions.org/";
        public string weatherSiteUrl = "https://weather.com/";       

        public HttpClient HttpClient;
        public TestSuitBase()
        {

            driver = GetDriver("Chrome");
        }
        
        public IWebDriver GetDriver(string driverType)
        {
            switch (driverType)
            {
                case "Chrome":
                    return new ChromeDriver();            

                default:
                    return new ChromeDriver();
            }
        }

        [OneTimeSetUp]
        protected void Setup()
        {
            ReportSetUp();
        }

        [OneTimeTearDown]
        protected void OneTimeTearDown()
        {
            _extent.Flush();
        }

        [SetUp]
        public void SetUp()
        {
            BeforeTest();
        }

        [TearDown]
        public void TearDown()
        {
            AfterTest(driver);
            driver.Quit();
            driver = null;
        }       
    }
}
