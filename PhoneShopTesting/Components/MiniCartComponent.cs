using OpenQA.Selenium;
using PhoneShopTesting.BaseEntities;
using PhoneShopTesting.Services;

namespace PhoneShopTesting.Components
{
    public class MiniCartComponent : BaseComponent
    {
        private static readonly By CartButtonBy = By.XPath("//a[@href='/cart']");
        private static readonly By InfoAboutCartBy =
            By.XPath("//div[@class='minicart']");

        private WaitService _waitService;
        public MiniCartComponent(IWebDriver driver) : base(driver)
        {
            _waitService = new WaitService(Driver);
        }

        public IWebElement CartButton => _waitService.GetVisibleElement(CartButtonBy);
        public IWebElement InfoAboutCart => Driver.FindElement(InfoAboutCartBy);
    }
}