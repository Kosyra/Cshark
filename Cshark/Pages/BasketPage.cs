using System;
using OpenQA.Selenium;

namespace Cshark.Pages
{
    internal class BasketPage : BasePage
    {
        internal BasketPage(IWebDriver driver) : base(driver)
        {
            IsPageLoaded();
        }

        #region selectors

        private static By CheckoutButton => By.Id("link-button--basket-continue-securely");
        
        private static By RemoveItemButton => By.ClassName("remove-basket-item-form-button");
        
        private static By BasketState => By.ClassName("u-centred");
        

        #endregion

        #region methods

        private void IsPageLoaded()
        {
            Wait.Until(d => d.FindElement(CheckoutButton).Displayed);
        }

        internal BasketPage RemoveProductFromBasket()
        {
            Driver.FindElement(RemoveItemButton).Click();

            return this;
        }

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

        #endregion
    }
}