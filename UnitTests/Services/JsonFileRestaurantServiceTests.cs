using NUnit.Framework;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using System.Linq;

namespace UnitTests.Services
{
    /// <summary>
    /// The JsonFileProductServiceTests defines unit tests to cover the JsonFileProductService class
    public class JsonFileRestaurantServiceTests
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

        #region AddRating
        /// <summary>
        /// The AddRating_InValid_Product_Null_Should_Return_False unit test
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Null_Should_Return_False()
        {
            // Arrange
            JsonFileRestaurantService RestaurantService = new JsonFileRestaurantService(TestHelper.MockWebHostEnvironment.Object);

            // Act
            var result = RestaurantService.AddRating(null, 1);

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
            JsonFileRestaurantService RestaurantService = new JsonFileRestaurantService(TestHelper.MockWebHostEnvironment.Object);

            // Get the First data item
            var data = RestaurantService.GetAllData().First();
            var countOriginal = data.Ratings.Length;

            // Act
            var result = RestaurantService.AddRating(data.Id, 5);
            var dataNewList = RestaurantService.GetAllData().First();

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
            JsonFileRestaurantService RestaurantService = new JsonFileRestaurantService(TestHelper.MockWebHostEnvironment.Object);

            // Act
            var result = RestaurantService.AddRating("invalid_productid", 1);

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
            JsonFileRestaurantService RestaurantService = new JsonFileRestaurantService(TestHelper.MockWebHostEnvironment.Object);

            var data = RestaurantService.GetAllData().First();

            // Act
            var result = RestaurantService.AddRating(data.Id, -1);

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
            JsonFileRestaurantService RestaurantService = new JsonFileRestaurantService(TestHelper.MockWebHostEnvironment.Object);

            var data = RestaurantService.GetAllData().First();

            // Act
            var result = RestaurantService.AddRating(data.Id, 6);

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
            JsonFileRestaurantService RestaurantService = new JsonFileRestaurantService(TestHelper.MockWebHostEnvironment.Object);
            var data = new RestaurantModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Title = "Enter Title",
                Description = "Enter Description",
                Url = "Enter URL",
                Image = " ",
            };

            var newProduct = RestaurantService.CreateData(data);

            // Act
            var newRating = RestaurantService.AddRating(newProduct.Id, 2);
            var dataNewList = RestaurantService.GetAllData().ToList();
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
        }
        #endregion AddRating

        #region CRUDi
        /// <summary>
        /// Passing Invalid product to UpdateData should return Null
        /// </summary>
        [Test]
        public void UpdateData_Invalid_Product_Should_Return_Null()
        {
            // Arrange
            JsonFileRestaurantService RestaurantService = new JsonFileRestaurantService(TestHelper.MockWebHostEnvironment.Object);

            // Act
            var invalidProduct = new RestaurantModel();
            invalidProduct.Id = "invalid product";
            var resultNew = RestaurantService.UpdateData(invalidProduct);

            // Assert
            Assert.IsNull(resultNew);

        }

        /// <summary>
        /// DeleteData unit test for JsonFileRestaurantService
        /// </summary>
        [Test]
        public void DeleteData_Invalid_Product_Should_Return_Null()
        {
            // Arrange
            JsonFileRestaurantService RestaurantService = new JsonFileRestaurantService(TestHelper.MockWebHostEnvironment.Object);

            // Act
            var invalidProduct = new RestaurantModel();
            invalidProduct.Id = "invalid product";
            var resultNew = RestaurantService.UpdateData(invalidProduct);

            // Assert
            Assert.IsNull(resultNew);

        }

        /// <summary>
        /// The UpdateData_Valid_Restaurant_Should_Return_True() validates that the UpdateData method
        /// functions as expected, and makes changes to the data stored within the restaurant datastore
        /// </summary>
        [Test]
        public void UpdateData_Valid_Restaurant_Should_Return_True()
        {
            // Arrange
            JsonFileRestaurantService RestaurantService = new JsonFileRestaurantService(TestHelper.MockWebHostEnvironment.Object);
            var dataName = "og-lynnwood";
            var products = RestaurantService.GetAllData();
            var productData = products.FirstOrDefault(x => x.Id.Equals(dataName));

            var initialDesc = productData.Description;

            productData.Description = "When you're here, you're family!";
            
            // Act
            var resultNew = RestaurantService.UpdateData(productData);
            var checkData = RestaurantService.GetAllData().FirstOrDefault(m => m.Id.Equals(dataName));

            // Assert
            Assert.AreEqual(resultNew.Description, checkData.Description);
            //Assert.IsNull(resultNew);

        }
        #endregion CRUDi
    }
}