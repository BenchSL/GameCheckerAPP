using GameCheckerAPI.Helper;
using NUnit.Framework;

namespace GameCheckerAPI.Tests
{
    public class UnitTests
    {
        [Test]
        public void TestGenerateGuid()
        {
            int expectedGuidLength = 10; 

            string guid = MethodHelper.generateGuid(10);

            Assert.AreEqual(expectedGuidLength, guid.Length, "Generated GUID length is not as expected.");
        }
    }
}
