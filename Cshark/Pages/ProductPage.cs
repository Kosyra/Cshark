using OpenQA.Selenium;

namespace Cshark.Pages
{
    internal class ProductPage : BasePage
    {
        internal ProductPage(IWebDriver driver) : base(driver) { IsPageLoaded();}

        #region selectors

        private static By WishListButton => By.Id("wishListSignIn");
        private static By QuantityIncreaseButton => By.ClassName("quantity-increase-button");
        private static By AddToBasketButton => By.Id("button--add-to-basket");
        private static By GoToBasketButton => By.ClassName("add-to-basket-view-basket-link");

        #endregion

        #region methods

        private void IsPageLoaded()
        {
            Wait.Until(d => d.FindElement(WishListButton).Displayed);
        }

        internal ProductPage SetProductQuantity(int productQuantity)
        {
            for (int i = 1; i < productQuantity; i++) Driver.FindElement(QuantityIncreaseButton).Click();

            return this;
        }

        internal ProductPage AddProductToBasket()
        {
            Actions.MoveToElement(Driver.FindElement(AddToBasketButton)).Click().Perform();
            
            return this; 
        }

        internal BasketPage GoToBasket()
        {
            Wait.Until(d => d.FindElement(GoToBasketButton).Displayed);
            Driver.FindElement(GoToBasketButton).Click();

            return new BasketPage(Driver);
        }

        #endregion
        
    }
}