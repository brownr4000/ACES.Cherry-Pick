using ContosoCrafts.WebSite.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Controllers
{
    class ProductsControllerTests
    {

        #region TestSetup
        public static ProductsController pController;

        [SetUp]
        public void TestInitialize()
        {
            pController = new ProductsController(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
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
    }
}
