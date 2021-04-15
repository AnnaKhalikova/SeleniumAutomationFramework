using System.Linq;
using OpenQA.Selenium;
using PhoneShopTesting.BaseEntities;
using PhoneShopTesting.Pages;

namespace PhoneShopTesting.Steps
{
    public class ProductsPageSteps : BaseStep
    {
        private ProductsPage _productsPage;
        
        public ProductsPageSteps(IWebDriver driver) : base(driver)
        {
            _productsPage = new ProductsPage(Driver, true);
        }
        
        public void AddFirstProductToCart(string quantity = "1")
        {
            _productsPage.FirstQuantityField.Clear();
            _productsPage.FirstQuantityField.SendKeys(quantity);
            _productsPage.FirstAddToCartButton.Click();
        }
        
        public void AddLastProductToCart(string quantity = "1")
        {
            _productsPage.LastQuantityField.Clear();
            _productsPage.LastQuantityField.SendKeys(quantity);
            _productsPage.LastAddToCartButton.Click();
        }

        public void GoToTheCart()
        {
            _productsPage.MiniCart.CartButton.Click();
        }
    }
}