using System;
using EAFramework.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
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
            Driver = _testSettings.TestRunType == TestRunType.Local ? GetWebDriver() : GetRemoteWebDriver();
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

        private IWebDriver GetRemoteWebDriver()//the same as a Factory Pattern will help to get the driver that we are going to work with
        {
            return _testSettings.BrowserType switch
            {
                BrowserType.Chrome => new RemoteWebDriver(_testSettings.GridUri, new ChromeOptions()),
                BrowserType.Firefox => new RemoteWebDriver(_testSettings.GridUri, new FirefoxOptions()),
                BrowserType.Safari => new RemoteWebDriver(_testSettings.GridUri, new SafariOptions()),
                _ => new RemoteWebDriver(_testSettings.GridUri, new ChromeOptions())
            };
        }
        
        public void Dispose()
        {
            Driver.Quit();
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

