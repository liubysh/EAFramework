using System;
using AutoFixture.Xunit2;
using EAApplicationTest.Models;
using EAApplicationTest.Pages;
using EAFramework.Config;
using EAFramework.Driver;
using Xunit;

namespace EAApplicationTest
{
    public class UnitTest1 : IDisposable
    {
        private IDriverFixture _driverFixture;

        public UnitTest1()
        {
            // var testSettings = new TestSettings()
            // {
            //     BrowserType = BrowserType.Chrome,
            //     ApplicationUrl = new Uri("http://localhost:8000/"),
            //     TimeoutInterval = 30
            // };

            var testSettings = ConfigReader.ReadConfig();
            
            _driverFixture = new DriverFixture(testSettings);
        }
        
        [Theory]
        [AutoData]
        //AutoData will fill all Product model's fields with automatically generated data
        public void Test1(Product product)
        {
            //HomePage
            var homePage = new HomePage(_driverFixture);
            var productPage = new ProductPage(_driverFixture);
            
            //Click and create link
            homePage.ClickProduct();
            
            //Create product
            productPage.ClickCreateButton();
            productPage.CreateProduct(product);
            
            //Open products details
            productPage.PerformClickOnSpecialValue(product.Name, "Details");
        }

        public void Dispose()
        {
            _driverFixture.Driver.Quit();
        }
    }
}