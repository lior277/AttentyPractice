using AttentyPracticeFrameWork.ContainerInitiate;
using Autofac;
using OpenQA.Selenium;
using System.Configuration;
using System.Net.Http;

namespace AttentyPractice.Internals
{
    public class ApplicationFactory : IApplicationFactory
    {         
        public void OpenApplication(IWebDriver driver = null, string application = null)
        {
            driver.Navigate().GoToUrl(application);
            driver.Manage().Window.Maximize();
        }
                
        public T ChangeContext<T>(IWebDriver driver = null, string application = null) where T : class
        {
            if(!typeof(T).Name.Contains("Api"))
            {
                OpenApplication(driver, application);
            }

            var containerInit = new ContainerInitialized();
            var container = containerInit.ContainerConfigure(driver);
            var workingClass = (T)container.Resolve(typeof(T));
            return workingClass;
        }
    }
}
