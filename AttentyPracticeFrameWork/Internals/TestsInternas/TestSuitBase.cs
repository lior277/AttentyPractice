using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Tests
{
    public class TestSuitBase
    {
        public string convectorSiteUrl = "https://www.metric-conversions.org/";
        public string weatherSiteUrl = "https://weather.com/";

        public enum Drivertype { Chrome, FireFox };
        public IWebDriver GetDriver(Drivertype drivertype)
        {
            switch (drivertype)
            {
                case Drivertype.Chrome:
                    return new ChromeDriver();

                case Drivertype.FireFox:
                    return new FirefoxDriver();
                default:
                    return new ChromeDriver();
            }
        }                
    }
}
