using System.Linq;
using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;
namespace UnitTests.Pages.Product.Create
{
    public class CreateTests
    {
        #region TestSetup
        public static CreateModel pageModel;
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new CreateModel(TestHelper.ProductService)
            {
            };
        }
        #endregion TestSetup
        #region OnGet
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
        [Test]
        public void OnGet_Valid_Should_Return_Restaurants()
        {
            // Arrange

            // Act

            // Assert
        }
        #endregion OnGetRestaurants

        public void OnPost_Valid_Should_Save_Created_Data_To_Json()
        {
            // Arrange
            pageModel.OnGet();
            var data = pageModel.Product;

            // Act
            pageModel.OnPost();
            var result = TestHelper.ProductService.GetAllData().First(x => x.Id == data.Id);

            // Assert
            Assert.AreEqual(data.Id, result.Id);
        }
    }
}