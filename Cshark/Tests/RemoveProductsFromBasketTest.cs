using Cshark.Pages;
using NUnit.Framework;

namespace Cshark.Tests
{
    public class RemoveProductsFromBasketTest : BaseTest
    {
        [Test]
        public void ProductsShouldBeRemovedFromBasket()
        {
            //Arrange
            const string productTypeToSearched = "floor lamp";
            const string productName = "John Lewis & Partners Harmony Ribbon Floor Lamp";
            const int productQuantity = 3;
            
            var homePage = new HomePage(Driver);
            
            //Act
            var basketPage = homePage
                .OpenHomePage()
                .SearchProduct(productTypeToSearched)
                .GoToProductPage(productName)
                .SetProductQuantity(productQuantity)
                .AddProductToBasket()
                .GoToBasket()
                .RemoveProductFromBasket();
            
            //Assert
            Assert.True(basketPage.IsBasketEmpty(), "The basket isn't empty");
        }
    }
}