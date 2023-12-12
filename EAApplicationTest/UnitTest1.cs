using AutoFixture.Xunit2;
using EAApplicationTest.Models;
using EAApplicationTest.Pages;
using Xunit;

namespace EAApplicationTest
{
    public class UnitTest1
    {
        private IHomePage _homePage;
        private IProductPage _productPage;

        //We using only interfaces instead of classes, dependency injection
        //is used to define classes realization in the startup class
        public UnitTest1(IProductPage productPage, IHomePage homePage)
        {
            _homePage = homePage;
            _productPage = productPage;
        }
        
        [Theory]
        [AutoData]
        //AutoData will fill all Product model's fields with automatically generated data
        public void CreateProductTest(Product product)
        {
            //Click and create link
            _homePage.ClickProduct();
            
            //Create product
            _productPage.ClickCreateButton();
            _productPage.CreateProduct(product);
            
            //Open products details
            _productPage.PerformClickOnSpecialValue(product.Name, "Details");
        }
    }
}