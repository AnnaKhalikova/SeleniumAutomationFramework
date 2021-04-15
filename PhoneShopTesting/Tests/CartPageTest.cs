using NUnit.Framework;
using PhoneShopTesting.BaseEntities;
using PhoneShopTesting.Pages;
using PhoneShopTesting.Steps;

namespace PhoneShopTesting.Tests
{
    public class CartPageTest : BaseTest
    {
        private CartPage _cartPage;
        
        [SetUp]
        public void SetUp()
        {
            var productsSteps = new ProductsPageSteps(Driver);
            productsSteps.AddFirstProductToCart();
            productsSteps.GoToTheCart();

            _cartPage = new CartPage(Driver);
        }

        [Test]
        public void DeleteProductFromTheCartSuccess()
        {
            _cartPage.DeleteButton.Click();
            _cartPage.UpdateButton.Click();
            
            Assert.That(_cartPage.ItemsInCart.Count - 1, Is.EqualTo(0));
            Assert.AreEqual("Total quantity: 0", _cartPage.TotalQuantity.Text);
            Assert.AreEqual("Total cost:\n0 USD", _cartPage.TotalPrice.Text);
            Assert.AreEqual("Cart: quantity - 0, cost - 0 USD", _cartPage.MiniCart.InfoAboutCart.Text);
        }
    }
}