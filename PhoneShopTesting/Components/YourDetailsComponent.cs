using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PhoneShopTesting.BaseEntities;

namespace PhoneShopTesting.Components
{
    public class YourDetailsComponent : BaseComponent
    {
        private static readonly By FirstNameFieldBy = By.Name("firstName");
        private static readonly By LastNameFieldBy = By.Name("lastName");
        private static readonly By PhoneFieldBy = By.Name("phone");
        private static readonly By DeliveryDateFieldBy = By.Name("deliveryDate");
        private static readonly By DeliveryAddressFieldBy = By.Name("deliveryAddress");
        private static readonly By PaymentMethodBy = By.Name("paymentMethod");

        public YourDetailsComponent(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement FirstNameField => Driver.FindElement(FirstNameFieldBy);
        public IWebElement LastNameField => Driver.FindElement(LastNameFieldBy);
        public IWebElement PhoneField => Driver.FindElement(PhoneFieldBy);
        public IWebElement DeliveryDateField => Driver.FindElement(DeliveryDateFieldBy);
        public IWebElement DeliveryAddressField => Driver.FindElement(DeliveryAddressFieldBy);
        
        public SelectElement PaymentMethod => new SelectElement(Driver.FindElement(PaymentMethodBy));
    }
}