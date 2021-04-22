using System;
using Cshark.CustomExceptions;
using OpenQA.Selenium;

namespace Cshark.Pages
{
    /// <summary>
    /// The Page object class represents the product page 
    /// </summary>
    internal class ProductPage : BasePage
    {
        internal ProductPage(IWebDriver driver) : base(driver) { IsPageLoaded();}

        #region selectors

        /// <summary>
        /// Selector of button to add product to wish list
        /// </summary>
        private static By WishListButton => By.Id("wishListSignIn");
        
        /// <summary>
        /// Selector of button to increase product quantity
        /// </summary>
        private static By QuantityIncreaseButton => By.ClassName("quantity-increase-button");
        
        /// <summary>
        /// Selector of button to add product to basket
        /// </summary>
        private static By AddToBasketButton => By.Id("button--add-to-basket");
        
        /// <summary>
        /// Selector of button to enter the shopping basket
        /// </summary>
        private static By GoToBasketButton => By.ClassName("add-to-basket-view-basket-link");

        #endregion

        #region methods

        /// <summary>
        /// Waits for a specific element to be loaded on the page
        /// </summary>
        private void IsPageLoaded()
        {
            try
            {
                Wait.Until(d => d.FindElement(WishListButton).Displayed);
            }
            catch (Exception e)
            {
                throw new PageNotLoadedException("ProductPage did not loaded correctly " , e);
            }
        }

        /// <summary>
        /// Sets quantity of product
        /// </summary>
        /// <param name="productQuantity">quantity of product</param>
        /// <returns>ProductPage object</returns>
        internal ProductPage SetProductQuantity(int productQuantity)
        {
            for (int i = 0; i < productQuantity - 1; i++) Driver.FindElement(QuantityIncreaseButton).Click();

            return this;
        }

        /// <summary>
        /// Adds product to the basket
        /// </summary>
        /// <returns>Product page object</returns>
        internal ProductPage AddProductToBasket()
        {
            Actions.MoveToElement(Driver.FindElement(AddToBasketButton)).Click().Perform();
            
            return this; 
        }

        /// <summary>
        /// Goes to the basket
        /// </summary>
        /// <returns>Basket page object</returns>
        internal BasketPage GoToBasket()
        {
            Wait.Until(d => d.FindElement(GoToBasketButton).Displayed);
            Driver.FindElement(GoToBasketButton).Click();

            return new BasketPage(Driver);
        }

        #endregion
        
    }
}