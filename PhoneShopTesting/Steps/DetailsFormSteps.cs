using OpenQA.Selenium;
using PhoneShopTesting.BaseEntities;
using PhoneShopTesting.Pages;

namespace PhoneShopTesting.Steps
{
    public class DetailsFormSteps : BaseStep
    {
        private CheckoutPage _checkoutPage;
        
        public DetailsFormSteps(IWebDriver driver) : base(driver)
        {
            _checkoutPage = new CheckoutPage(Driver);
        }

        public void FillInTheFields(string firstName, string lastName, string phone, 
            string address, string date, string paymentType)
        {
            _checkoutPage.YourDetailsComponent.FirstNameField.SendKeys(firstName);
            _checkoutPage.YourDetailsComponent.LastNameField.SendKeys(lastName);
            _checkoutPage.YourDetailsComponent.PhoneField.SendKeys(phone);
            _checkoutPage.YourDetailsComponent.DeliveryAddressField.SendKeys(address);
            _checkoutPage.YourDetailsComponent.DeliveryDateField.SendKeys(date);
            _checkoutPage.YourDetailsComponent.PaymentMethod.SelectByText(paymentType);
        }
    }
}