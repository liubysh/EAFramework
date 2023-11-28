using OpenQA.Selenium;

namespace EAFramework.Driver
{
    public interface IDriverFixture
    {
        IWebDriver Driver { get; }
    }
}