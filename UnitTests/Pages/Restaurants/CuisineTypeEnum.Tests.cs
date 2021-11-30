using System;
using NUnit.Framework;
using ContosoCrafts.WebSite.CuisineType;

namespace UnitTests.Pages.Restaurants
{
    class CuisineTypeEnumTests
    {
        #region TestSetup

        /// <summary>
        /// The TestInitialize method creates the necessary objects for the initialization of the unit tests
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

        }
        #endregion TestSetup

        #region EnumToString

        [Test]
        public void CuisineTypeEnum_Valid_ToString_Should_Return_True()
        {
            // Arrange

            // Act
            var testing = EnumExtensions.convertToString(CuisineType.KOREAN);

            // Assert
            Assert.AreEqual(testing, "korean");
        }

        #endregion EnumToString
    }
}