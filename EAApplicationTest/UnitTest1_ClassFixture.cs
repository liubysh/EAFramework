using System;
using EAFramework.Config;
using EAFramework.Driver;
using OpenQA.Selenium;
using Xunit;

namespace EAApplicationTest
{
    public class UnitTest1_ClassFixture : IClassFixture<DriverFixture>
    {
        private IDriverFixture _driverFixture;

        public UnitTest1_ClassFixture()
        {
            var testSettings = new TestSettings()
            {
                BrowserType = BrowserType.Chrome,
                ApplicationUrl = new Uri("http://localhost:8000/"),
                TimeoutInterval = 30
            };

            _driverFixture = new DriverFixture(testSettings);
        }
        
        [Fact]
        public void Test1()
        {
            _driverFixture.Driver.FindElement(By.LinkText("Product")).Click();
            _driverFixture.Driver.FindElement(By.LinkText("Create")).Click();
        }

        public void Dispose()
        {
            _driverFixture.Driver.Quit();
        }
    }
}