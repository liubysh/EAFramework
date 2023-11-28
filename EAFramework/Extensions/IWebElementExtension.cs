using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EAFramework.Extensions
{
    public static class IWebElementExtension
    {
        public static void SelectDropDownByText(this IWebElement element, string text)
        {
            var select = new SelectElement(element);
            select.SelectByText(text);
        }
        
        public static void SelectDropDownByValue(this IWebElement element, string value)
        {
            var select = new SelectElement(element);
            select.SelectByValue(value);
        }
        
        public static void SelectDropDownByIndex(this IWebElement element, int index)
        {
            var select = new SelectElement(element);
            select.SelectByIndex(index);
        }
        
        public static void ClearAndEnterText(this IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }
    }
}