using NUnit.Framework;
using ContosoCrafts.WebSite.Models;
using Castle.Core.Internal;

namespace UnitTests.Models
{
    /// <summary>
    /// The ProductModelTests class defines unit tests to cover the ProductModel class
    /// </summary>
    class ProducttModelTests
    {
        #region TestSetup
        // Constant stings to hold values for determining unit test
        public string TEST_WORDS = "Test";
        public string CHECK_WORDS = "Check";

        /// <summary>
        /// The TestInitialize method creates the necessary objects for the initialization of the unit tests
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

        }

        #endregion TestSetup

        #region ToStringTest
        /// <summary>
        /// The ProductModel_Valid_ToString_Should_Return_True tests the functionality of the overridden ToString method
        /// </summary>
        [Test]
        public void ProductModel_Valid_ToString_Should_Return_True()
        {
            // Arrange
            // Creating a ProductModel with test values
            ProductModel thingModel = new ProductModel()
            {
                Id = TEST_WORDS,
                Title = TEST_WORDS,
                Description = TEST_WORDS,
                Url = TEST_WORDS,
                Image = TEST_WORDS
            };

            // Act
            var result = thingModel.ToString();

            // Assert
            Assert.AreEqual(false, result.IsNullOrEmpty());
        }
        #endregion ToStringTest
    }
}