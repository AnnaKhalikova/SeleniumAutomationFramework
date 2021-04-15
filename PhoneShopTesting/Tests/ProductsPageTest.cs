using NUnit.Framework;
using PhoneShopTesting.BaseEntities;
using PhoneShopTesting.Pages;
using PhoneShopTesting.Steps;

namespace PhoneShopTesting.Tests
{
    public class ProductsPageTest : BaseTest
    {
        private ProductsPage _productsPage;
        private ProductsPageSteps _productsPageSteps;
        
        [SetUp]
        public void Setup()
        {
            _productsPageSteps = new ProductsPageSteps(Driver);
            _productsPage = new ProductsPage(Driver);
        }

        [Test]
        public void AddOneProductToCart()
        {
            _productsPageSteps.AddFirstProductToCart();
            Assert.That(_productsPage.ProductAddedMessage.Text, Is.EqualTo("Product 1 added to cart"));
            
            _productsPage.MiniCart.CartButton.Click();
            
            var cartPage = new CartPage(Driver);
            var actualCountOfItemsInCart = cartPage.ItemsInCart.Count - 1;
            
            Assert.AreEqual("Cart: quantity - 1, cost - 100 USD", _productsPage.MiniCart.InfoAboutCart.Text);
            Assert.AreEqual(1, actualCountOfItemsInCart);
        }

        [Test]
        public void AddMoreThanOneProductToCart()
        {
            _productsPageSteps.AddFirstProductToCart();
            Assert.That(_productsPage.ProductAddedMessage.Text, Is.EqualTo("Product 1 added to cart"));
            
            _productsPageSteps.AddLastProductToCart();
            Assert.That(_productsPage.ProductAddedMessage.Text, Is.EqualTo("Product 1 added to cart"));
            
            _productsPage.MiniCart.CartButton.Click();

            var cartPage = new CartPage(Driver);
            var actualCountOfItemsInCart = cartPage.ItemsInCart.Count - 1;
            
            Assert.AreEqual("Cart: quantity - 2, cost - 250 USD", _productsPage.MiniCart.InfoAboutCart.Text);
            Assert.AreEqual(2, actualCountOfItemsInCart);
        }

        [Test]
        public void AddTheSelectedProductQuantityToTheCart()
        {
            _productsPageSteps.AddFirstProductToCart("8");
            
            _productsPage.MiniCart.CartButton.Click();
         
            var cartPage = new CartPage(Driver);

            Assert.AreEqual("Cart: quantity - 8, cost - 800 USD", _productsPage.MiniCart.InfoAboutCart.Text);
            Assert.AreEqual("Total quantity: 8", cartPage.TotalQuantity.Text);
            Assert.AreEqual("Total cost:\n800 USD", cartPage.TotalPrice.Text);
            Assert.AreEqual(1, cartPage.ItemsInCart.Count - 1); //обрати внимание на то, как я посчитываю количество элементов в корзине
        }
        
    }
}