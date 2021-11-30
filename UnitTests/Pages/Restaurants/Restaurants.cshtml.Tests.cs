using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Read
{
    /// <summary>
    /// 
    /// </summary>
    public class ChineseRestaurantsTests
    {
        //
        #region TestSetup
        public static ChineseRestaurantModel pageModel;

        /// <summary>
        /// 
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ChineseRestaurantModel(TestHelper.ProductService)
            {
            };
        }
        #endregion TestSetup

        /// <summary>
        /// 
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
        #endregion OnGet
    }
}