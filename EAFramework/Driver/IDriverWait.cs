using System.Collections.Generic;
using OpenQA.Selenium;

namespace EAFramework.Driver
{
    public interface IDriverWait
    {
        IWebElement FindElement(By elementLocator);
        IEnumerable<IWebElement> FindElements(By elementLocator);
    }
}