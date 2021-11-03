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

             //var AllData = pController.Get("");
            //var oldCount = TestHelper.ProductService.GetAllData().Count();

            // Act 
            //pController.OnGet(" ");

            // Assert
            //Assert.AreEqual(true, actual: allData.Length > 0);
            //Assert.AreEqual(true, pController.ModelState.IsValid);
            //Assert.AreEqual(true, actual: pController.ProductService.ToList().Any());
        }
        #endregion OnGet
    }
}
