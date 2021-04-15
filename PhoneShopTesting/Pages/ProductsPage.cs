using System;
using System.Linq;
using OpenQA.Selenium;
using PhoneShopTesting.BaseEntities;
using PhoneShopTesting.Components;

namespace PhoneShopTesting.Pages
{
    public class ProductsPage : BasePage
    {
        private const string EndPoint = "products";

        private static readonly By AddToCartButtonBy = By.XPath("//button[contains(text(), 'Add to cart')]");
        private static readonly By QuantityFieldBy = By.XPath("//input[@class='quantity']");
        private static readonly By DescriptionBy = By.XPath("//tbody/tr/td[2]");
        private static readonly By PriceBy = By.XPath("//tbody/tr/td[4]");
        private static readonly By AscDescriptionSortBy = By.XPath("//td[contains(text(), 'Description')]//a[1]");
        private static readonly By DescDescriptionSortBy = By.XPath("//td[contains(text(), 'Description')]//a[2]");
        private static readonly By ProductAddedMessageBy = By.XPath("//div[@class='success']");
        
        public MiniCartComponent MiniCart;

        public ProductsPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
            MiniCart = new MiniCartComponent(Driver);
        }

        public ProductsPage(IWebDriver driver) : base(driver, false)
        {
            MiniCart = new MiniCartComponent(Driver);
        }

        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + EndPoint);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return FirstAddToCartButton.Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IWebElement ProductAddedMessage => Driver.FindElement(ProductAddedMessageBy);
        public IWebElement FirstAddToCartButton => WaitService.GetVisibleElement(AddToCartButtonBy);
        public IWebElement LastAddToCartButton => Driver.FindElements(AddToCartButtonBy).Last();
        public IWebElement FirstQuantityField => Driver.FindElements(QuantityFieldBy).First();
        public IWebElement LastQuantityField => Driver.FindElements(QuantityFieldBy).Last();
        
    }
}