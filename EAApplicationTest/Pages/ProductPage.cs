using EAApplicationTest.Models;
using EAFramework.Driver;
using EAFramework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V85.Browser;

namespace EAApplicationTest.Pages
{
    public class ProductPage
    {
        private readonly IDriverWait _driver;

        public ProductPage(IDriverWait driver)
        {
            _driver = driver;
        }

        private IWebElement txtName => _driver.FindElement(By.Id("Name"));
        private IWebElement txtDescription => _driver.FindElement(By.Id("Description"));
        private IWebElement txtPrice => _driver.FindElement(By.Id("Price"));
        private IWebElement ddlProductType => _driver.FindElement(By.Id("ProductType"));// ddl for dropdown line
        private IWebElement lnkCreate => _driver.FindElement(By.LinkText("Create"));
        private IWebElement btnCreate => _driver.FindElement(By.Id("Create"));
        private IWebElement tblList => _driver.FindElement(By.CssSelector(".table"));

        public void ClickCreateButton() => lnkCreate.Click();
        
        public void CreateProduct(Product product)
        {
            txtName.SendKeys(product.Name);
            txtDescription.SendKeys(product.Description);
            txtPrice.SendKeys(product.Price.ToString());
            ddlProductType.SelectDropDownByText(product.ProductType.ToString());
            btnCreate.Click();
        }

        public void PerformClickOnSpecialValue(string name, string operation)
        {
            tblList.PerformActionOnCell("5", "Name", name, operation);
        }
    }
}