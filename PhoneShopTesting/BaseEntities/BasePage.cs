using System;
using NUnit.Framework;
using OpenQA.Selenium;
using PhoneShopTesting.Services;

namespace PhoneShopTesting.BaseEntities
{
    public abstract class BasePage
    {
        [ThreadStatic] protected static IWebDriver Driver;
        protected WaitService WaitService;
        
        protected const int WaitForPageLoadingTime = 60;

        protected abstract void OpenPage();
        public abstract bool IsPageOpened();

        public BasePage(IWebDriver driver, bool openPageByUrl)
        {
            Driver = driver;
            WaitService = new WaitService(Driver);

            if (openPageByUrl)
            {
                OpenPage();
            }

            WaitForOpen();
        }
        
        protected void WaitForOpen()
        {
            
            var isPageOpenedIndicator = IsPageOpened();

            if (!isPageOpenedIndicator)
            {
                throw new AssertionException("Page was not opened.");
            }
        }
    }
}