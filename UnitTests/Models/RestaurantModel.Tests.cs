using NUnit.Framework;
using ContosoCrafts.WebSite.Models;
using Castle.Core.Internal;

namespace UnitTests.Models
{
    /// <summary>
    /// The RestauranttModelTests class defines unit tests to cover the RestaurantModel class
    /// </summary>
    class RestaurantModelTests
    {
        #region TestSetup
        // Constant stings to hold values for determining unit test
        public string TEST_WORDS = "Test";
        public string CHECK_WORDS = "Check";
        public int[] STARS = { 5, 5, 5 };

        /// <summary>
        /// The TestInitialize method creates the necessary objects for the initialization of the unit tests
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

        }
        #endregion TestSetup

        #region IdSetGet
        /// <summary>
        /// The RestaurantModel_Valid_Id_Set_And_Get_Should_Return_True checks the functionality of the Id field
        /// </summary>
        [Test]
        public void RestaurantModel_Valid_Id_Set_And_Get_Should_Return_True()
        {
            // Arrange
            RestaurantModel dinerModel = new RestaurantModel()
            {
                Id = TEST_WORDS
            };

            // Act
            dinerModel.Id = CHECK_WORDS;
            var result = dinerModel.Id;

            // Assert
            Assert.AreEqual(false, result == TEST_WORDS);
        }
        #endregion IdSetGet

        #region TitleSetGet
        /// <summary>
        /// The RestaurantModel_Valid_Title_Set_And_Get_Should_Return_True checks the functionality of the Title field
        /// </summary>
        [Test]
        public void RestaurantModel_Valid_Title_Set_And_Get_Should_Return_True()
        {
            // Arrange
            RestaurantModel dinerModel = new RestaurantModel()
            {
                Title = TEST_WORDS
            };

            // Act
            dinerModel.Title = CHECK_WORDS;
            var result = dinerModel.Title;

            // Assert
            Assert.AreEqual(false, result == TEST_WORDS);
        }
        #endregion TitleSetGet

        #region DescriptionSetGet
        /// <summary>
        /// The RestaurantModel_Valid_Description_Set_And_Get_Should_Return_True checks the functionality of the Description field
        /// </summary>
        [Test]
        public void RestaurantModel_Valid_Description_Set_And_Get_Should_Return_True()
        {
            // Arrange
            //
            RestaurantModel dinerModel = new RestaurantModel()
            {
                Description = TEST_WORDS
            };

            // Act
            dinerModel.Description = CHECK_WORDS;
            var result = dinerModel.Description;

            // Assert
            Assert.AreEqual(false, result == TEST_WORDS);
        }
        #endregion DescriptionSetGet

        #region UrlSetGet
        /// <summary>
        /// The RestaurantModel_Valid_Url_Set_And_Get_Should_Return_True checks the functionality of the Url field
        /// </summary>
        [Test]
        public void RestaurantModel_Valid_Url_Set_And_Get_Should_Return_True()
        {
            // Arrange
            RestaurantModel dinerModel = new RestaurantModel()
            {
                Url = TEST_WORDS
            };

            // Act
            dinerModel.Url = CHECK_WORDS;
            var result = dinerModel.Url;

            // Assert
            Assert.AreEqual(false, result == TEST_WORDS);
        }
        #endregion UrlSetGet

        #region ImageSetGet
        /// <summary>
        /// The RestaurantModel_Valid_Image_Set_And_Get_Should_Return_True checks the functionality of the Image field
        /// </summary>
        [Test]
        public void RestaurantModel_Valid_Image_String_Set_And_Get_Should_Return_True()
        {
            // Arrange
            RestaurantModel dinerModel = new RestaurantModel()
            {
                Image = TEST_WORDS
            };

            // Act
            dinerModel.Image = CHECK_WORDS;
            var result = dinerModel.Image;

            // Assert
            Assert.AreEqual(false, result == TEST_WORDS);
        }
        #endregion ImageSetGet

        #region QtySetGet
        /// <summary>
        /// The RestaurantModel_Valid_Quantity_Set_And_Get_Should_Return_True checks the functionality of the Quantity field
        /// </summary>
        [Test]
        public void RestaurantModel_Valid_Quantity_Set_And_Get_Should_Return_True()
        {
            // Arrange
            RestaurantModel dinerModel = new RestaurantModel()
            {
                Quantity = 1
            };

            // Act
            dinerModel.Quantity = 3;
            var result = dinerModel.Quantity;

            // Assert
            Assert.AreEqual(false, result == 1);
        }
        #endregion QtySetGet

        #region PriceSetGet
        /// <summary>
        /// The RestaurantModel_Valid_Price_Set_And_Get_Should_Return_True checks the functionality of the Price field
        /// </summary>
        [Test]
        public void RestaurantModel_Valid_Price_Set_And_Get_Should_Return_True()
        {
            // Arrange
            RestaurantModel dinerModel = new RestaurantModel()
            {
                Price = 101.99
            };

            // Act
            dinerModel.Price= 250.99;
            var result = dinerModel.Price;

            // Assert
            Assert.AreEqual(false, result == 101.99);
        }
        #endregion PriceSetGet

        #region RatingSetGet
        /// <summary>
        /// The RestaurantModel_Valid_Rating_Set_And_Get_Should_Return_True checks the functionality of the Rating field
        /// </summary>
        [Test]
        public void RestaurantModel_Valid_Rating_Set_And_Get_Should_Return_True()
        {
            // Arrange
            RestaurantModel dinerModel = new RestaurantModel()
            {
                Ratings = STARS
            };

            // Act
            int[] badScores = { 1, 1, 1 };
            dinerModel.Ratings = badScores;
            var result = dinerModel.Ratings;

            // Assert
            Assert.AreEqual(false, result == STARS);
        }
        #endregion RatingSetGet

        #region ToStringTest
        /// <summary>
        /// The RestaurantModel_Valid_ToString_Should_Return_True tests the functionality of the overridden ToString method
        /// </summary>
        [Test]
        public void RestaurantModel_Valid_ToString_Should_Return_True()
        {
            // Arrange
            //
            RestaurantModel dinerModel = new RestaurantModel()
            {
                Id = TEST_WORDS,
                Title = TEST_WORDS,
                Description = TEST_WORDS,
                Url = TEST_WORDS,
                Image = TEST_WORDS,
                Quantity = 1,
                Price = 101.99
            };

            // Act
            var result = dinerModel.ToString();

            // Assert
            Assert.AreEqual(false, result.IsNullOrEmpty());
        }
        #endregion ToStringTest
    }
}