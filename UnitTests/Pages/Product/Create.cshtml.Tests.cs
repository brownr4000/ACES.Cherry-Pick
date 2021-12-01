using System.Linq;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Pages.Product.Create
{
    /// <summary>
    /// The CreateTests class defines unit tests to cover the CreateModel class
    /// </summary>
    public class CreateTests
    {
        #region TestSetup
        // Initialize CreateModel object
        public static CreateModel pageModel;

        /// <summary>
        /// The TestInitialize method creates the necessary objects for the initialization of the unit tests
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new CreateModel(TestHelper.ProductService)
            {
            };
        }
        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// The OnGet_Valid_Should_Return_Products tests the OnGet method for Products
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange
            var oldCount = TestHelper.ProductService.GetAllData().Count();

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(oldCount, TestHelper.ProductService.GetAllData().Count());
        }
        #endregion OnGet

        #region OnGetRestaurants
        /// <summary>
        /// The OnGet_Valid_Should_Return_Restaurants tests the OnGet method for Restaurants
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Restaurants()
        {
            // Arrange

            // Act

            // Assert
        }
        #endregion OnGetRestaurants

        #region OnPost
        /// <summary>
        /// The OnPost_Valid_Should_Save_Created_Data_To_Json tests the OnPost method for updating Id in a product stored in the CreateModel object
        /// </summary>
        [Test]
        public void OnPost_Valid_Should_Save_Created_Data_To_Json()
        {
            // Arrange
            pageModel.OnGet();
            var data = pageModel.Product;

            pageModel.Product.Url = "httP://www.asdfgi.com";

            // Act
            pageModel.OnPost();
            var result = TestHelper.ProductService.GetAllData().First(x => x.Id == data.Id);

            // Assert
            Assert.AreEqual(data.Id, result.Id);

            //Clean up
            TestHelper.ProductService.DeleteData(data.Id);
        }

        /// <summary>
        /// The OnPost_InValid_Model_NotValid_Return_Page tests the OnPost method with bogus data to ensure the correct error is given
        /// </summary>
        [Test]
        public void OnPost_InValid_Model_NotValid_Return_Page()
        {
            // Arrange

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }

        /// <summary>
        /// The OnPost_Duplicate_Should_Show_Error_Message tests the OnPost method validation for duplicate product creation
        /// </summary>
        [Test]
        public void OnPost_Duplicate_Should_Show_Error_Message()
        {
            // Arrange
            pageModel.OnGet();
            var data = pageModel.Product;

            pageModel.Product.Url = "httP://www.qwertyu.com";

            // Act
            pageModel.OnPost();
            //Attempt to create duplicate entry
            pageModel.OnPost();
            
            // Assert
            Assert.AreEqual(1, pageModel.ModelState.ErrorCount);

            //Clean up
            TestHelper.ProductService.DeleteData(data.Id);
        }
        #endregion OnPost
    }
}