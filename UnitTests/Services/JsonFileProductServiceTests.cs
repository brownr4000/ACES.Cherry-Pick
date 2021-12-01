using NUnit.Framework;
using ContosoCrafts.WebSite.Models;
using System.Linq;

namespace UnitTests.Services
{
    /// <summary>
    /// The JsonFileProductServiceTests defines unit tests to cover the JsonFileProductService class
    public class JsonFileProductServiceTests
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

        #region AddRating
        /// <summary>
        /// The AddRating_InValid_Product_Null_Should_Return_False unit test
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Null_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating(null, 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// The AddRating_Valid_Product_Valid_Rating_Valid_Should_Return_True unit test
        /// </summary>
        [Test]
        public void AddRating_Valid_Product_Valid_Rating_Valid_Should_Return_True()
        {
            // Arrange

            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();
            var countOriginal = data.Ratings.Length;

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 5);
            var dataNewList = TestHelper.ProductService.GetAllData().First();

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
        }

        /// <summary>
        /// The AddRating_InValid_ProductID_Should_Return_False Looks up the product, if it does not exist, it should return false
        /// </summary>
        [Test]
        public void AddRating_InValid_ProductID_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating("invalid_productid", 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// The AddRating_InValid_Rating_Negative_Should_Return_False unit tests Check Rating for boundries, it should not allow ratings below 0
        /// </summary>
        [Test]
        public void AddRating_InValid_Rating_Negative_Should_Return_False()
        {
            // Arrange

            var data = TestHelper.ProductService.GetAllData().First();

            // Act

            var result = TestHelper.ProductService.AddRating(data.Id, -1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Check Rating for boundries, it should not allow ratings above 5
        /// </summary>
        [Test]
        public void AddRating_InValid_Rating_Above_5_Should_Return_False()
        {
            // Arrange

            var data = TestHelper.ProductService.GetAllData().First();

            // Act

            var result = TestHelper.ProductService.AddRating(data.Id, 6);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Check to see if the rating exist, if there are none, then create the array
        /// </summary>
        [Test]
        public void AddRating_No_Existing_Ratings_Should_Return_True()
        {
            // Arrange
            var data = new ProductModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Title = "Test Title",
                Description = "Test Description",
                Url = "http://www.asdfghii.com",
                Image = "",
            };

            var newProduct = TestHelper.ProductService.CreateData(data);

            // Act
            var newRating = TestHelper.ProductService.AddRating(newProduct.Id, 2);
            var dataNewList = TestHelper.ProductService.GetAllData().ToList();
            int newRatingLength = 0;
            foreach (var p in dataNewList) {
                if (p.Id == newProduct.Id) {
                    newRatingLength = p.Ratings.Length;
                    break;
                }
            }

            // Assert
            Assert.AreEqual(true, newRating);
            Assert.AreEqual(1, newRatingLength);

            //Clean up
            TestHelper.ProductService.DeleteData(newProduct.Id);
        }

        /// <summary>
        /// Invalid ratings with Null in AddRating should set Ratings to not null
        /// </summary>
        [Test]
        public void AddRating_InValid_Ratings_Null_Should_Set_Ratings_Not_Null()
        {
            // Arrange

            // Act
            // Get a data whose rating is null
            var nullRatingData = TestHelper.ProductService.GetAllData().First(x => x.Ratings == null);
            // This data's rating should become not null after executing the following statement
            var result = TestHelper.ProductService.AddRating(nullRatingData.Id, 4);
            // Re-read the data
            var data = TestHelper.ProductService.GetAllData().First(x => x.Id == nullRatingData.Id);

            // Assert
            Assert.AreEqual(false, data.Ratings == null);
        }

        /// <summary>
        /// Passing Invalid product to UpdateData should return Null
        /// </summary>
        [Test]
        public void UpdateData_Invalid_Product_Should_Return_Null()
        {
            // Arrange

            // Act
            var invalidProduct = new ProductModel();
            invalidProduct.Id = "invalid product";
            var resultNew = TestHelper.ProductService.UpdateData(invalidProduct);

            // Assert
            Assert.IsNull(resultNew);

        }
        #endregion AddRating
    }
}