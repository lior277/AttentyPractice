using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Net.Http;

namespace Tests
{
    public class TestSuitBase
    {
        private static string driverDir = Environment.CurrentDirectory;

        public string convectorSiteUrl = "https://www.metric-conversions.org/";
        public string weatherSiteUrl = "https://weather.com/";

        private IWebDriver m_WebDriver;
        public virtual IWebDriver WebDriver { get => m_WebDriver ?? 
                (m_WebDriver = new ChromeDriver(driverDir)); private set => m_WebDriver = value; }
  
        public void Dispose()
        {
            if (m_WebDriver != null)
            {
                WebDriver.Dispose();
                WebDriver = null;
            }          
        }
    }
}
