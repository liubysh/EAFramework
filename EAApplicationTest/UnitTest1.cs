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
        private IDriverWait _driverWait;

        //We using only interfaces instead of classes, dependency injection
        //is used to define classes realization in the startup class
        public UnitTest1(IDriverFixture driverFixture, IDriverWait driverWait)
        {
            _driverFixture = driverFixture;
            _driverWait = driverWait;
        }
        
        [Theory]
        [AutoData]
        //AutoData will fill all Product model's fields with automatically generated data
        public void Test1(Product product)
        {
            //HomePage
            var homePage = new HomePage(_driverWait);
            var productPage = new ProductPage(_driverWait);
            
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