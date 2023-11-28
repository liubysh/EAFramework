using System;
using EAApplicationTest.Pages;
using EAFramework.Config;
using EAFramework.Driver;
using OpenQA.Selenium;
using Xunit;

namespace EAApplicationTest
{
    public class UnitTest1 : IDisposable
    {
        private IDriverFixture _driverFixture;

        public UnitTest1()
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
            //HomePage
            var homePage = new HomePage(_driverFixture);
            var productPage = new ProductPage(_driverFixture);
            
            //Click and create link
            homePage.ClickProduct();
            
            //Create product
            productPage.ClickCreateButton();
            productPage.CreateProduct("FirstProduct2", "description fro product2", "300", "MONITOR");
            
            //Open products details
            productPage.PerformClickOnSpecialValue("FirstProduct2", "Details");
        }

        public void Dispose()
        {
            _driverFixture.Driver.Quit();
        }
    }
}