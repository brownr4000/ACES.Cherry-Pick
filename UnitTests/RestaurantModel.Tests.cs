using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
using System.Linq;

namespace UnitTests
{
    class RestaurantModelTests
    {
        #region TestSetup
        public static CreateModel pageModel;
        public string TEST_WORDS = "Test";
        public string CHECK_WORDS = "Check";

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new CreateModel(TestHelper.ProductService)
            {

            };
        }
        #endregion TestSetup

        #region IdSetGet
        [Test]
        public void RestaurantModel_Valid_Id_Set_And_Get_Should_Return_True()
        {
            // Arrange
            RestaurantModel dinertModel = new RestaurantModel()
            {
                Id = TEST_WORDS,
                Title = TEST_WORDS,
                Description = TEST_WORDS,
                Url = TEST_WORDS,
                Image = TEST_WORDS,
                Maker = TEST_WORDS,
                Quantity = 1,
                Price = 101.99
            };

            // Act
            dinertModel.Id = CHECK_WORDS;
            var result = dinertModel.Id;

            // Assert
            Assert.AreEqual(false, result != TEST_WORDS);
        }
        #endregion IdSetGet
    }
}