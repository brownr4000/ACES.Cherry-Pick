using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
using System.Linq;
using Castle.Core.Internal;

namespace UnitTests
{
    class RestaurantModelTests
    {
        #region TestSetup
        public string TEST_WORDS = "Test";
        public string CHECK_WORDS = "Check";

        [SetUp]
        public void TestInitialize()
        {

        }

        #endregion TestSetup

        #region IdSetGet
        [Test]
        public void RestaurantModel_Valid_Id_Set_And_Get_Should_Return_True()
        {
            // Arrange
            RestaurantModel dinertModel = new RestaurantModel()
            {
                Id = TEST_WORDS
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
                Title = TEST_WORDS
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
                Description = TEST_WORDS
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
                Url = TEST_WORDS
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
                Image = TEST_WORDS
            };

            // Act
            dinertModel.Image = CHECK_WORDS;
            var result = dinertModel.Image;

            // Assert
            Assert.AreEqual(false, result == TEST_WORDS);
        }
        #endregion ImageSetGet

        #region MakerSetGet
        [Test]
        public void RestaurantModel_Valid_Maker_Set_And_Get_Should_Return_True()
        {
            // Arrange
            RestaurantModel dinertModel = new RestaurantModel()
            {
                Maker = TEST_WORDS
            };

            // Act
            dinertModel.Maker = CHECK_WORDS;
            var result = dinertModel.Maker;

            // Assert
            Assert.AreEqual(false, result == TEST_WORDS);
        }
        #endregion MakerSetGet

        #region QtySetGet
        [Test]
        public void RestaurantModel_Valid_Quantity_Set_And_Get_Should_Return_True()
        {
            // Arrange
            RestaurantModel dinertModel = new RestaurantModel()
            {
                Quantity = 1
            };

            // Act
            dinertModel.Quantity = 3;
            var result = dinertModel.Quantity;

            // Assert
            Assert.AreEqual(false, result == 1);
        }
        #endregion QtySetGet

        #region PriceSetGet
        [Test]
        public void RestaurantModel_Valid_Price_Set_And_Get_Should_Return_True()
        {
            // Arrange
            RestaurantModel dinertModel = new RestaurantModel()
            {
                Price = 101.99
            };

            // Act
            dinertModel.Price= 250.99;
            var result = dinertModel.Price;

            // Assert
            Assert.AreEqual(false, result == 101.99);
        }
        #endregion PriceSetGet

        #region ToStringTest
        [Test]
        public void RestaurantModel_Valid_ToString_Should_Return_True()
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
            var result = dinertModel.ToString();

            // Assert
            Assert.AreEqual(false, result.IsNullOrEmpty());
        }
        #endregion ToStringTest
    }
}