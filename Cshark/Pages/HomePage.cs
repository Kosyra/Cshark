using System;
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
        /// Accept cookies button
        /// </summary>
        private static By CookieAcceptButton => By.CssSelector("button[data-test='allow-all']");
        
        private static By SearchField => By.Id("mobileSearch");
        private static By SubmitButton => By.CssSelector("button[type='submit']");

        #endregion

        #region methods

        /// <summary>
        /// Opens the home page and accepts the cookies
        /// </summary>
        /// <param name="acceptCookie"></param>
        /// <returns>Home page object</returns>
        internal HomePage OpenHomePage(bool acceptCookie)
        {
            Driver.Navigate().GoToUrl(HomeUrl);
            //TODO: dodać tray catch ze zwracanym exception
            Wait.Until(d => d.FindElement(SearchField).Displayed);
            AcceptCookie();
            
            return this;
        }
        
        /// <summary>
        /// Opens the home page
        /// </summary>
        /// <returns>Home page object</returns>
        internal HomePage OpenHomePage()
        {
            Driver.Navigate().GoToUrl(HomeUrl);
            //TODO: doda tray catch ze zwracanym exception
            Wait.Until(d => d.FindElement(SearchField).Displayed);

            return this;
        }

        /// <summary>
        /// Accepts the cookies if it they are displayed
        /// </summary>
        internal HomePage AcceptCookie()
        {
            try
            {
                Wait.Until(d => d.FindElement(CookieAcceptButton).Displayed);
                Driver.FindElement(CookieAcceptButton).Click();
            }
            catch (Exception e)
            {
                // ignored
            }

            return this;
        }

        
        /// <summary>
        /// Presents product based on search keywords 
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        internal ProductsListPage SearchProduct(string productName)
        {
            Driver.FindElement(SearchField).SendKeys(productName);
            Driver.FindElement(SubmitButton).Click();

            return new ProductsListPage(Driver);
        }
        
        #endregion
        
        
    }
}