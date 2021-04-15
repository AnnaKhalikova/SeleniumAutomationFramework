using System.Collections;
using NUnit.Framework;

namespace PhoneShopTesting.TestData
{
    public class DetailsFormData
    {
        public static IEnumerable DifferentFirstName
        {
            get
            {
                yield return new TestFixtureData("Anna", "Sola", "291111111", "Aranskaiya", "2522021", "By Card");
                yield return new TestFixtureData("", "Sola", "291111111", "Aranskaiya", "2522021", "By Card");
            }
        }
        
        public static IEnumerable DifferentLastName
        {
            get
            {
                yield return new TestFixtureData("Anna", "Sola", "291111111", "Aranskaiya", "2522021", "By Card");
                yield return new TestFixtureData("Anna", "", "291111111", "Aranskaiya", "2522021", "By Card");
            }
        }
        
        public static IEnumerable Phone
        {
            get
            {
                yield return new TestFixtureData("Anna", "Sola", "phone", "Aranskaiya", "2522021", "By Card");
                yield return new TestFixtureData("Anna", "Sola", "123", "Aranskaiya", "2522021", "By Card");
                yield return new TestFixtureData("Anna", "Sola", "1234567890", "Aranskaiya", "2522021", "By Card");
            }
        }
        
    }
}