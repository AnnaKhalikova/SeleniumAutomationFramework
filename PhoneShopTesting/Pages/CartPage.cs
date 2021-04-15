using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using PhoneShopTesting.BaseEntities;
using PhoneShopTesting.Components;

namespace PhoneShopTesting.Pages
{
    public class CartPage : BasePage
    {
        private const string EndPoint = "cart";
        
        private static readonly By UpdateButtonBy = By.XPath("//button[contains(text(), 'Update')]");
        private static readonly By CheckoutButtonBy = By.XPath("//button[contains(text(), 'Checkout')]");
        private static readonly By ItemsInCartBy = By.CssSelector("tbody>tr");
        private static readonly By TotalQuantityBy = By.XPath("//td[@class='quantity'][contains(text(), 'Total')]");
        private static readonly By TotalPriceBy = By.XPath("//td[@class='price'][contains(text(), 'Total')]");
        private static readonly By DeleteButtonBy = By.XPath("//button[@form='deleteCartItem']");

        public MiniCartComponent MiniCart;
        
        public CartPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
            MiniCart = new MiniCartComponent(Driver);
        }

        public CartPage(IWebDriver driver) : base(driver, false)
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
                return CheckoutButton.Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        

        public IWebElement UpdateButton => Driver.FindElement(UpdateButtonBy);
        public IWebElement CheckoutButton => WaitService.GetVisibleElement(CheckoutButtonBy);
        public ReadOnlyCollection<IWebElement> ItemsInCart => Driver.FindElements(ItemsInCartBy);
        public IWebElement TotalQuantity => Driver.FindElement(TotalQuantityBy);
        public IWebElement TotalPrice => Driver.FindElement(TotalPriceBy);
        public IWebElement DeleteButton => Driver.FindElement(DeleteButtonBy);

    }
}