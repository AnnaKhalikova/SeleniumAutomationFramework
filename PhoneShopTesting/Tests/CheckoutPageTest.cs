using NUnit.Framework;
using PhoneShopTesting.BaseEntities;
using PhoneShopTesting.Helpers;
using PhoneShopTesting.Pages;
using PhoneShopTesting.Services;
using PhoneShopTesting.Steps;
using PhoneShopTesting.TestData;

namespace PhoneShopTesting.Tests
{
    public class CheckoutPageTest : BaseTest
    {
        private CheckoutPage _checkoutPage;
        private DetailsFormSteps _detailsFormSteps;
        private WaitService _wait;

        [SetUp]
        public void SetUp()
        {
            var productsPageSteps = new ProductsPageSteps(Driver);
            productsPageSteps.AddFirstProductToCart();

            var cartPage = new CartPage(Driver, true);
            cartPage.CheckoutButton.Click();
            
            _checkoutPage = new CheckoutPage(Driver);
            _detailsFormSteps = new DetailsFormSteps(Driver);
            
            _wait = new WaitService(Driver);

        }

        [Test]
        public void CheckoutWithBlankFields()
        {
            _checkoutPage.PlaceOrderButton.Click();
            
            Assert.AreEqual("Error occurred while placing order",_checkoutPage.ErrorMessage.Text);

            AssertHelper.AssertDetailsFormFields(_checkoutPage.FirstNameErrorMessage.Text);
            AssertHelper.AssertDetailsFormFields(_checkoutPage.LastNameErrorMessage.Text);
            AssertHelper.AssertDetailsFormFields(_checkoutPage.PhoneErrorMessage.Text);
            AssertHelper.AssertDetailsFormFields(_checkoutPage.DeliveryAddressErrorMessage.Text);
            AssertHelper.AssertDetailsFormFields(_checkoutPage.DeliveryDateErrorMessage.Text);
            AssertHelper.AssertDetailsFormFields(_checkoutPage.PaymentTypeErrorMessage.Text);
        }
        
        [Test]
      //  [TestCaseSource(typeof(DetailsFormData), nameof(DetailsFormData.DifferentFirstName))]
        public void InvalidPhoneNumber()
        {
           
            _detailsFormSteps.FillInTheFields("Anna", "Sola", 
                "12", "Aranskaiya", "10-10-10", "CREDIT_CARD");
            _checkoutPage.PlaceOrderButton.Click();
            
            Assert.AreEqual("Invalid phone number", _checkoutPage.PhoneErrorMessage.Text);
        }
        
        [Test]
        public void InvalidPhoneNumber1()
        {
           
            _detailsFormSteps.FillInTheFields("Anna", "Sola", 
                "+375293908300", "Aranskaiya", "24-22-2021", "CREDIT_CARD");
            _checkoutPage.PlaceOrderButton.Click();
            
            Assert.IsTrue(_checkoutPage.PhoneErrorMessage.Displayed);
            Assert.AreEqual("Invalid phone number", _checkoutPage.PhoneErrorMessage.Text);
        }
        
        [Test]
        public void InvalidDate()
        {
            _detailsFormSteps.FillInTheFields("Anna", "Sola", 
                "375293908300", "Aranskaiya", "10102020", "CREDIT_CARD");
            _checkoutPage.PlaceOrderButton.Click();
            
            Assert.IsTrue(_checkoutPage.DeliveryDateErrorMessage.Displayed);
            Assert.AreEqual("Wrong format, should be: dd-MM-yyyy", _checkoutPage.DeliveryDateErrorMessage.Text);
        }
        
        [Test]
        public void InvalidAddress()
        {
            _detailsFormSteps.FillInTheFields("Anna", "Sola", 
                "375293908300", "Ara", "24-22-2021", "CREDIT_CARD");
            _checkoutPage.PlaceOrderButton.Click();
            
            Assert.IsTrue(_checkoutPage.DeliveryAddressErrorMessage.Displayed);
            Assert.AreEqual("Wrong format, should be: dd-MM-yyyy", _checkoutPage.DeliveryDateErrorMessage.Text);
        }
        
        [Test]
        public void OrderCompletedSuccessfully()
        {
           
            _detailsFormSteps.FillInTheFields("Anna", "Sola", 
                "+375293908300", "Aranskaiya", "10-10-10", "CREDIT_CARD");
            _checkoutPage.PlaceOrderButton.Click();
            
            Assert.AreEqual("Order overview", Driver.Title);
        }
        
    }
}