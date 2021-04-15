using NUnit.Framework;

namespace PhoneShopTesting.Helpers
{
    public class AssertHelper
    {
        public static void AssertDetailsFormFields(string actualData)
        {
            Assert.AreEqual("Value is required",actualData);
        }
        
    }
}