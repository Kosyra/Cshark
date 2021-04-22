using System;
using Cshark.CustomExceptions;
using OpenQA.Selenium;

namespace Cshark.Pages
{
    /// <summary>
    /// The Page object class represents the cart page 
    /// </summary>
    internal class BasketPage : BasePage
    {
        internal BasketPage(IWebDriver driver) : base(driver) { IsPageLoaded(); }

        #region selectors

        /// <summary>
        /// Selector to checkout products in basket
        /// </summary>
        private static By CheckoutButton => By.Id("link-button--basket-continue-securely");
        
        /// <summary>
        /// Selector to remove products from the basket
        /// </summary>
        private static By RemoveItemButton => By.ClassName("remove-basket-item-form-button");
        
        /// <summary>
        /// Selector to check if the products have been removed from the basket
        /// </summary>
        private static By BasketState => By.ClassName("u-centred");
        
        /// <summary>
        /// Selector of input to get quantity of product
        /// </summary>
        private static By ProductQuantity => By.ClassName("quantity-input");
        

        #endregion

        #region methods

        /// <summary>
        /// Waits for a specific element to be loaded on the page
        /// </summary>
        private void IsPageLoaded()
        {
            try
            {
                Wait.Until(d => d.FindElement(CheckoutButton).Displayed);
            }
            catch (Exception e)
            {
                throw new PageNotLoadedException("BasketPage did not loaded correctly " , e);
            }
        }

        /// <summary>
        /// Removes all products from basket
        /// </summary>
        /// <returns>Basket page object</returns>
        internal BasketPage RemoveProductFromBasket()
        {
            Driver.FindElement(RemoveItemButton).Click();

            return this;
        }

        /// <summary>
        /// Verifies if the basket is empty
        /// </summary>
        /// <returns>true or false</returns>
        internal bool IsBasketEmpty()
        {
            try
            {
                Wait.Until(d => d.FindElement(BasketState).Displayed);
                return true;

            }
            catch (Exception)
            {
                return false;
            }
            
        }

        /// <summary>
        /// Returns product quantity
        /// </summary>
        /// <returns>product quantity as string</returns>
        internal string GetProductQuantity()
        {
            return Driver.FindElement(ProductQuantity).GetAttribute("value");
        }

        #endregion
    }
}