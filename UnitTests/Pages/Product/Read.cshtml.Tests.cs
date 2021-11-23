using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Pages.Product.Read
{
    /// <summary>
    /// The ReadTests class defines unit tests to cover the ReadModel class
    /// </summary>
    public class ReadTests
    {
        // Initialize ReadModel object
        #region TestSetup
        public static ReadModel pageModel;

        /// <summary>
        /// The TestInitialize method creates the necessary objects for the initialization of the unit tests
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ReadModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        /// <summary>
        /// The OnGet_Valid_Should_Return_Products tests the OnGet method for Products
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("chinese");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Chinese Cuisine", pageModel.Product.Title);
        }

        /// <summary>
        /// The OnGet_InValid_Id_Bougs_Should_Return_Products tests the ReadModel object to determine if bogus data is returned
        /// </summary>
        [Test]
        public void OnGet_InValid_Id_Bougs_Should_Return_Products()
        {
            // Arrange

            // Act
            var result = pageModel.OnGet("Bogus") as RedirectToPageResult;

            // Assert
            Assert.AreEqual("./Index", result.PageName);
        }
        #endregion OnGet
    }
}