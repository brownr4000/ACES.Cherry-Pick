using ContosoCrafts.WebSite.Controllers;
using System.Linq;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Controllers
{
    /// <summary>
    /// The ProductsControllerTests class defines unit tests to cover the ProductsConroller class
    /// </summary>
    class ProductsControllerTests
    {
        // Creating ProductsContoller object
        #region TestSetup
        public static ProductsController pController;
        
        /// <summary>
        /// The TestInitialize method creates the necessary objects for the initialization of the unit tests
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pController = new ProductsController(TestHelper.ProductService)
            {
            };
        }
        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// The OnGet_Valid_Should_Return_Products method tests the functionality of the OnGet method in the ProductsConroller class
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange
            var prodCount = TestHelper.ProductService.GetAllData().Count();

            // Act 
            var products = pController.Get();

            // Assert
            Assert.AreEqual(prodCount, products.Count());

        }
        #endregion OnGet

        #region Patch
        /// <summary>
        /// The Patch_Valid_Should_Add_Ratings method tests the functionality of the Patch method in the ProductsController class
        /// </summary>
        [Test]
        public void Patch_Valid_Should_Add_Ratings()
        {
            // Arrange

            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();
            var countOriginal = data.Ratings.Length;

            var ratingReq = new ProductsController.RatingRequest();
            ratingReq.ProductId = data.Id;
            ratingReq.Rating = 5;

            // Act 
            var actionRes = pController.Patch(ratingReq);
            var dataNewList = TestHelper.ProductService.GetAllData().First();

            // Assert
            Assert.IsTrue(actionRes.GetType().Equals(typeof(OkResult)));
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());

        }
        #endregion Patch
    }
}