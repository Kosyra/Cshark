using System;
using System.Linq;
using OpenQA.Selenium;

namespace Cshark.Pages
{
    internal class ProductsListPage : BasePage
    {
        internal ProductsListPage(IWebDriver driver) : base(driver) { IsPageLoaded(); }

        #region selectors
        private static By ElementsContainer => By.CssSelector("div[data-test='component-grid-container']");
        private  static string ProductXpath => "//h2[contains(text(),'<lookingProductName>')]";
        
        #endregion

        
        #region methods
        private void IsPageLoaded()
        {
            Wait.Until(d => d.FindElement(ElementsContainer).Displayed);
        }

        internal ProductPage GoToProductPage(string productName)
        {
            var productXpath = ProductXpath.Replace("<lookingProductName>", productName);
            Wait.Until(d => d.FindElement(By.XPath(productXpath)).Displayed);
            Actions.MoveToElement(Driver.FindElement(By.XPath(productXpath))).Click().Perform();
            
            return new ProductPage(Driver);
        }
       

        #endregion
    }
}