using AttentyPracticeFrameWork.ContainerInitiate;
using Autofac;
using OpenQA.Selenium;
using System.Configuration;
using System.Net.Http;


namespace AttentyPractice.Internals
{
    public class ApiFactory : IApiFactory
    {
        protected IWebDriver driver;
        private HttpClient httpClient;
        private string application;

        public ApiFactory(IWebDriver driver)
        {
           this.driver = driver;
            this.application = application ?.ToLower();
            OpenApplication();
        }

        public ApiFactory(){}

        public void OpenApplication()
        {
            var app = ConfigurationManager.AppSettings["converterApplicationPath"].ToLower();
            this.application = application ?? app;
            driver.Navigate().GoToUrl(application);
            driver.Manage().Window.Maximize();
        }
       
        public IApiFactory InitializeHttpClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            return this;
        }
   
        public T ChangeContext<T>() where T : class
        {
            var containerInit = new ContainerInitialized();
            var container = containerInit.ContainerConfigure(driver);
            var workingClass = (T)container.Resolve(typeof(T));
            return workingClass;
        }
    }
}
