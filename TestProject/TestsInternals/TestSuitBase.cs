using AttentyPractice.Internals;
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
        public static ApplicationFactory apiFactory;
        public IWebDriver driver;
        public string convectorSiteUrl = "https://www.metric-conversions.org/";
        public string weatherSiteUrl = "https://weather.com/";       

        public TestSuitBase()
        {
            GetApplication();
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

        public ApplicationFactory GetApplication()
        {
            return apiFactory = apiFactory ?? new ApplicationFactory();
        }

        [OneTimeSetUp]
        protected void Setup()
        {
            ReportSetUp();
        }

        [SetUp]
        public void SetUp()
        {
            BeforeTest();
        }

        [OneTimeTearDown]
        protected void OneTimeTearDown()
        {
            ExtendTearDoun();
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
