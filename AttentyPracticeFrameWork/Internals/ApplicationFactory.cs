using AttentyPracticeFrameWork.ContainerInitiate;
using Autofac;
using OpenQA.Selenium;
using System.Configuration;
using System.Net.Http;

namespace AttentyPractice.Internals
{
    public class ApplicationFactory : IApplicationFactory
    {
        protected IWebDriver _driver;
        protected HttpClient _client;
        private string _application;

        public ApplicationFactory(IWebDriver driver)
        {
           _driver = driver;         
        }
     
        public ApplicationFactory(){ }

        public void OpenApplication(string application = null)
        {
            var app = ConfigurationManager.AppSettings["converterApplicationPath"].ToLower();
            _application = application ?? app;
            _driver.Navigate().GoToUrl(application);
            _driver.Manage().Window.Maximize();
        }
                
        public T ChangeContext<T>(string application = null) where T : class
        {
            if(!typeof(T).Name.Contains("Api"))
            {
                OpenApplication(application);
            }

            var containerInit = new ContainerInitialized();
            var container = containerInit.ContainerConfigure(_driver);
            var workingClass = (T)container.Resolve(typeof(T));
            return workingClass;
        }
    }
}
