using System;
using OpenQA.Selenium;
using PhoneShopTesting.BaseEntities;
using PhoneShopTesting.Components;

namespace PhoneShopTesting.Pages
{
    public class CheckoutPage : BasePage
    {
        private const string EndPoint = "checkout?";
        
        private static readonly By PlaceOrderButtonBy = By.CssSelector("button");
        private static readonly By ErrorMessageBy = By.XPath("//main/div[@class='error']");
        private static readonly By FirstNameErrorMessageBy = By.XPath("//input[@name='firstName']/following-sibling::div");
        private static readonly By LastNameErrorMessageBy = By.XPath("//input[@name='lastName']/following-sibling::div");
        private static readonly By PhoneErrorMessageBy = By.XPath("//input[@name='phone']/following-sibling::div");
        private static readonly By DeliveryDateErrorMessageBy = By.XPath("//input[@name='deliveryDate']/following-sibling::div");
        private static readonly By DeliveryAddressErrorMessageBy = By.XPath("//input[@name='deliveryAddress']/following-sibling::div");
        private static readonly By PaymentTypeErrorMessageBy = By.XPath("//label/following-sibling::div");

        
        public YourDetailsComponent YourDetailsComponent;
        
        public CheckoutPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
            YourDetailsComponent = new YourDetailsComponent(Driver);
        }

        public CheckoutPage(IWebDriver driver) : base(driver, false)
        {
            YourDetailsComponent = new YourDetailsComponent(Driver);
        }

        protected override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + EndPoint);
        }

        public override bool IsPageOpened()
        {
            try
            {
                return PlaceOrderButton.Displayed;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IWebElement PlaceOrderButton => WaitService.GetVisibleElement(PlaceOrderButtonBy);
        public IWebElement ErrorMessage => Driver.FindElement(ErrorMessageBy);
        public IWebElement FirstNameErrorMessage => Driver.FindElement(FirstNameErrorMessageBy);
        public IWebElement LastNameErrorMessage => Driver.FindElement(LastNameErrorMessageBy);
        public IWebElement PhoneErrorMessage => WaitService.GetVisibleElement(PhoneErrorMessageBy);
        public IWebElement DeliveryAddressErrorMessage => Driver.FindElement(DeliveryAddressErrorMessageBy);
        public IWebElement DeliveryDateErrorMessage => Driver.FindElement(DeliveryDateErrorMessageBy);
        public IWebElement PaymentTypeErrorMessage => Driver.FindElement(PaymentTypeErrorMessageBy);
    }
}