using System;
using Cshark.CustomExceptions;
using OpenQA.Selenium;
using static Cshark.Constants.Constants;

namespace Cshark.Pages
{
    /// <summary>
    /// Page object representing a home page
    /// </summary>
    internal class HomePage : BasePage
    {
        internal HomePage(IWebDriver driver) : base(driver) { }

        #region selectors
        
        /// <summary>
        /// Selector of accept cookies button
        /// </summary>
        private static By CookieAcceptButton => By.CssSelector("button[data-test='allow-all']");
        
        /// <summary>
        /// Selector of element for entering keywords of the searched product
        /// </summary>
        private static By SearchField => By.Id("mobileSearch");
        
        /// <summary>
        /// Selector of button to search products
        /// </summary>
        private static By SubmitButton => By.CssSelector("button[type='submit']");

        #endregion

        #region methods

        /// <summary>
        /// Waits for a specific element to be loaded on the page
        /// </summary>
        private void IsPageLoaded()
        {
            try
            {
                Wait.Until(d => d.FindElement(SearchField).Displayed);
            }
            catch (Exception e)
            {
                throw new PageNotLoadedException("ProductListPage did not loaded correctly " , e);
            }
        }
        
        /// <summary>
        /// Opens the home page and accepts the cookies
        /// </summary>
        /// <returns>Home page object</returns>
        internal HomePage OpenHomePage()
        {
            Driver.Navigate().GoToUrl(HomeUrl);
            IsPageLoaded();
            AcceptCookie();
            
            return this;
        }

        /// <summary>
        /// Accepts the cookies if it they are displayed
        /// </summary>
        private void AcceptCookie()
        {
            try
            {
                Wait.Until(d => d.FindElement(CookieAcceptButton).Displayed);
                Driver.FindElement(CookieAcceptButton).Click();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        
        /// <summary>
        /// Presents product based on search keywords 
        /// </summary>
        /// <param name="productKeyword">keyword to search for a product</param>
        /// <returns>Product list page object</returns>
        internal ProductsListPage SearchProduct(string productKeyword)
        {
            Driver.FindElement(SearchField).SendKeys(productKeyword);
            Driver.FindElement(SubmitButton).Click();

            return new ProductsListPage(Driver);
        }
        
        #endregion
        
        
    }
}