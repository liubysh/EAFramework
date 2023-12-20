using EOSpecFlowTest.Models;
using EOSpecFlowTest.Pages;
using FluentAssertions;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace EOSpecFlowTest.Steps
{
    [Binding]
    public sealed class ProductStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly IHomePage _homePage;
        private readonly IProductPage _productPage;

        public ProductStepDefinitions(ScenarioContext scenarioContext, IHomePage homePage, IProductPage productPage)
        {
            _scenarioContext = scenarioContext;
            _homePage = homePage;
            _productPage = productPage;
        }

        [Given(@"I click the product menu")]
        public void GivenIClickTheProductMenu()
        {
            _homePage.ClickProduct();
        }
        
        [Given(@"I click the ""(.*)"" link")]
        public void GivenIClickTheCreateLink(string create)
        {
            _productPage.ClickCreateButton();
        }
        
        [Given(@"I create product with following details")]
        public void GivenICreateProductWithFollowingDetails(Table table)
        {
            var product = table.CreateInstance<Product>();
            _productPage.CreateProduct(product);
            _scenarioContext.Set<Product>(product);
        }
        

        [When(@"I click the Details link of the newly created product")]
        public void WhenIClickTheDetailsLinkOfTheNewlyCreatedProduct()
        {
            var product = _scenarioContext.Get<Product>();
            _productPage.PerformClickOnSpecialValue(product.Name, "Details");
        }

        [Then(@"I see all the product details are created as expected")]
        public void ThenISeeAllTheProductDetailsAreCreatedAsExpected()
        {
            var product = _scenarioContext.Get<Product>();
            _productPage.GetProductName().Should().BeEquivalentTo(product.Name.Trim());
        }
    }
}