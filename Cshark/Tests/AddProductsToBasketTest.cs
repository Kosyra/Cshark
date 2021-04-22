using Cshark.Pages;
using NUnit.Framework;

namespace Cshark.Tests
{
    public class AddProductsToBasketTest : BaseTest
    {
        [Test]
        public void ProductsWithRightAmountShouldBeInBasket()
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
                .GoToBasket();
            
            //Asset
            Assert.AreEqual("3", basketPage.GetProductQuantity());
        }
        
    }
}