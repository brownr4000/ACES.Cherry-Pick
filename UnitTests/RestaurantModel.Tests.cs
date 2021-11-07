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
            //pageModel = new CreateModel(TestHelper.ProductService)
            //{

            //};
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
            };

            // Act
            dinertModel.Id = CHECK_WORDS;
            var result = dinertModel.Id;

            // Assert
            Assert.AreEqual(false, result == TEST_WORDS);
        }
        #endregion IdSetGet

        #region TitleSetGet
        [Test]
        public void RestaurantModel_Valid_Title_Set_And_Get_Should_Return_True()
        {
            // Arrange
            RestaurantModel dinertModel = new RestaurantModel()
            {
                Title = TEST_WORDS,
            };

            // Act
            dinertModel.Title = CHECK_WORDS;
            var result = dinertModel.Title;

            // Assert
            Assert.AreEqual(false, result == TEST_WORDS);
        }
        #endregion TitleSetGet

        #region DescriptionSetGet
        [Test]
        public void RestaurantModel_Valid_Description_Set_And_Get_Should_Return_True()
        {
            // Arrange
            RestaurantModel dinertModel = new RestaurantModel()
            {
                Description = TEST_WORDS,
                Url = TEST_WORDS,
                Image = TEST_WORDS,
                Maker = TEST_WORDS,
                Quantity = 1,
                Price = 101.99
            };

            // Act
            dinertModel.Description = CHECK_WORDS;
            var result = dinertModel.Description;

            // Assert
            Assert.AreEqual(false, result == TEST_WORDS);
        }
        #endregion DescriptionSetGet

        #region UrlSetGet
        [Test]
        public void RestaurantModel_Valid_Url_Set_And_Get_Should_Return_True()
        {
            // Arrange
            RestaurantModel dinertModel = new RestaurantModel()
            {
                Url = TEST_WORDS,
                Image = TEST_WORDS,
                Maker = TEST_WORDS,
                Quantity = 1,
                Price = 101.99
            };

            // Act
            dinertModel.Url = CHECK_WORDS;
            var result = dinertModel.Url;

            // Assert
            Assert.AreEqual(false, result == TEST_WORDS);
        }
        #endregion UrlSetGet

        #region ImageSetGet
        [Test]
        public void RestaurantModel_Valid_Image_String_Set_And_Get_Should_Return_True()
        {
            // Arrange
            RestaurantModel dinertModel = new RestaurantModel()
            {
                Url = TEST_WORDS,
                Image = TEST_WORDS,
                Maker = TEST_WORDS,
                Quantity = 1,
                Price = 101.99
            };

            // Act
            dinertModel.Image = CHECK_WORDS;
            var result = dinertModel.Image;

            // Assert
            Assert.AreEqual(false, result == TEST_WORDS);
        }
        #endregion ImageSetGet
    }
}