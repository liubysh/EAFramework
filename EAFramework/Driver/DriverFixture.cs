using System;
using EAFramework.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;

namespace EAFramework.Driver
{
    public class DriverFixture : IDriverFixture, IDisposable
    {
        private readonly TestSettings _testSettings;
        public IWebDriver Driver { get; }

        public DriverFixture(TestSettings testSettings)
        {
            _testSettings = testSettings;
            Driver = GetWebDriver();
            Driver.Navigate().GoToUrl(_testSettings.ApplicationUrl);
        }
        private IWebDriver GetWebDriver()//the same as a Factory Pattern will help to get the driver that we are going to work with
        {
            return _testSettings.BrowserType switch
            {
                BrowserType.Chrome => new ChromeDriver(),
                BrowserType.Firefox => new FirefoxDriver(),
                BrowserType.Safari => new SafariDriver(),
                _ => new ChromeDriver()
            };
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

public enum BrowserType
{
    Chrome,
    Firefox,
    Safari,
    EdgeChromium
}

