using System;
using Cshark.CustomExceptions;
using OpenQA.Selenium;

namespace Cshark.Pages
{
    /// <summary>
    /// The Page object class represents the products list page 
    /// </summary>
    internal class ProductsListPage : BasePage
    {
        internal ProductsListPage(IWebDriver driver) : base(driver) { IsPageLoaded(); }

        #region selectors
        
        /// <summary>
        /// Selector of container that contains products
        /// </summary>
        private static By ElementsContainer => By.CssSelector("div[data-test='component-grid-container']");
        
        /// <summary>
        /// Xpath of specific product. You must replace the containing text with the name of product you are looking for
        /// </summary>
        private  static string ProductXpath => "//h2[contains(text(),'<searchedProductName>')]";
        
        #endregion

        
        #region methods
        
        /// <summary>
        /// Waits for a specific element to be loaded on the page
        /// </summary>
        private void IsPageLoaded()
        {
            try
            {
                Wait.Until(d => d.FindElement(ElementsContainer).Displayed);
            }
            catch (Exception e)
            {
                throw new PageNotLoadedException("ProductListPage did not loaded correctly " , e);
            }
        }

        /// <summary>
        /// Goes to a specific product page
        /// </summary>
        /// <param name="productName">The exact name of the product</param>
        /// <returns>Product page object</returns>
        internal ProductPage GoToProductPage(string productName)
        {
            var productXpath = ProductXpath.Replace("<searchedProductName>", productName);
            Wait.Until(d => d.FindElement(By.XPath(productXpath)).Displayed);
            Actions.MoveToElement(Driver.FindElement(By.XPath(productXpath))).Click().Perform();
            
            return new ProductPage(Driver);
        }
       

        #endregion
    }
}