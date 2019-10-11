using System.Net.Http;
using OpenQA.Selenium;

namespace AttentyPractice.Internals
{
    public interface IApiFactory
    {
        T ChangeContext<T>() where T : class;
    }
}