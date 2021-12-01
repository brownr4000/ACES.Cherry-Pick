using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Product.Update
{
    /// <summary>
    /// The UpdateTests class defines unit tests to cover the UpdateModel class
    /// </summary>
    public class UpdateTests
    {
        //
        #region TestSetup
        // Initialize UpdateModel object
        public static UpdateModel pageModel;

        /// <summary>
        /// The TestInitialize method creates the necessary objects for the initialization of the unit tests
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new UpdateModel(TestHelper.ProductService)
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
            pageModel.OnGet("dessert");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Dessert", pageModel.Product.Title);
        }

        /// <summary>
        /// The OnGet_Invalid_Id_Should_Return_Null tests the OnGet method for the DeleteModel object
        /// </summary>
        [Test]
        public void OnGet_Invalid_Id_Should_Return_Null()
        {
            // Arrange

            // Act
            pageModel.OnGet("bogus");

            //Reset

            // Assert
            Assert.AreEqual(null, pageModel.Product);
            Assert.AreEqual(true, pageModel.errorCheck);
        }
        #endregion OnGet

        /// <summary>
        /// The OnPostAsync_Valid_Should_Return_Products checks the functionality of UpdateData method to add an item from the datastore
        /// </summary>
        #region OnPostAsync
        [Test]
        public void OnPostAsync_Valid_Should_Return_Products()
        {
           
            // Arrange
            var data = new ProductModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Title = "Enter Title",
                Description = "Enter Description",
                Url = "http://www.sometestdomain2171.com",
                Image = "",
            };

            // First Create the product to delete
            pageModel.Product = TestHelper.ProductService.CreateData(data);
            pageModel.Product.Title = "Example to update";
            TestHelper.ProductService.UpdateData(pageModel.Product);

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));

            //Clean up
            TestHelper.ProductService.DeleteData(data.Id);
        }

        /// <summary>
        /// The OnPostAsync_InValid_Model_NotValid_Return_Page tests the OnPost method with bogus data to ensure the correct error is given
        /// </summary>
        [Test]
        public void OnPostAsync_InValid_Model_NotValid_Return_Page()
        {
            // Arrange
            pageModel.Product = new ProductModel
            {
                Id = "bogus",
                Title = "bogus",
                Description = "bogus",
                Url = "bogus",
                Image = "bougs"
            };

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }
        #endregion OnPostAsync
    }
}