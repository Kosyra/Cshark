using Cshark.Pages;
using NUnit.Framework;

namespace Cshark.Tests
{
    public class RemoveItemsFromBasket : BaseTest
    {
        [Test]
        public void ProductsShouldBeRemovedFromBasket()
        {
            //Arrange
            const string productName = "John Lewis & Partners Harmony Ribbon Floor Lamp";
            var homePage = new HomePage(Driver);
            
            //Act
            var basketPage = homePage
                .OpenHomePage(true)
                .SearchProduct("floor lamp")
                .GoToProductPage(productName)
                .SetProductQuantity(3)
                .AddProductToBasket()
                .GoToBasket()
                .RemoveProductFromBasket();
            
            //Assert
            Assert.True(basketPage.IsBasketEmpty(), "The basket isn't empty");
        }
        
    }
}