using NUnit.Framework;

using ContosoCrafts.WebSite.Models;
using Castle.Core.Internal;

namespace UnitTests.Models
{
    class ProducttModelTests
    {
        #region TestSetup
        public string TEST_WORDS = "Test";
        public string CHECK_WORDS = "Check";

        [SetUp]
        public void TestInitialize()
        {

        }

        #endregion TestSetup

        #region ToStringTest
        [Test]
        public void ProductModel_Valid_ToString_Should_Return_True()
        {
            // Arrange
            ProductModel thingModel = new ProductModel()
            {
                Id = TEST_WORDS,
                Title = TEST_WORDS,
                Description = TEST_WORDS,
                Url = TEST_WORDS,
                Image = TEST_WORDS,
                Maker = TEST_WORDS,
            };

            // Act
            var result = thingModel.ToString();

            // Assert
            Assert.AreEqual(false, result.IsNullOrEmpty());
        }
        #endregion ToStringTest
    }
}