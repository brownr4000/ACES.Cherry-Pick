using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Pages.Product.Read
{
    public class ChineseRestaurantsTests
    {
        #region TestSetup
        public static ChineseRestaurantModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ChineseRestaurantModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("jenlooper-cactus");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Chinese Cuisine", pageModel.Product.Title);
        }
        #endregion OnGet
    }
}