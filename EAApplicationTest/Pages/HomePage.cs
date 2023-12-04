using EAFramework.Driver;
using OpenQA.Selenium;

namespace EAApplicationTest.Pages
{
    public class HomePage
    {
        private readonly IDriverWait _driver;

        public HomePage(IDriverWait driver)
        {
            _driver = driver;
        }
        
        private IWebElement lnkHome => _driver.FindElement(By.LinkText("Home"));
        private IWebElement lnkPrivacy => _driver.FindElement(By.LinkText("Privacy"));
        private IWebElement lnkProduct => _driver.FindElement(By.LinkText("Product"));
        
        public void ClickProduct() => lnkProduct.Click();
    }
}