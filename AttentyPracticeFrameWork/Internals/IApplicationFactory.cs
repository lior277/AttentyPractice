using System.Net.Http;
using OpenQA.Selenium;

namespace AttentyPractice.Internals
{
    public interface IApplicationFactory
    {
        T ChangeContext<T>(IWebDriver driver, string application) where T : class;
    }
}