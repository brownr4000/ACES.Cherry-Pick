﻿
using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
using System.Linq;

namespace UnitTests.Pages.Product.AddRating
{
    public class JsonFileProductServiceTests
    {
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        #region AddRating
        [Test]
        public void AddRating_InValid_Product_Null_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating(null, 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_InValid_()
        {
            // Arrange

            // Act
            //var result = TestHelper.ProductService.AddRating(null, 1);

            // Assert
            //Assert.AreEqual(false, result);
        }

        // ....

        [Test]
        public void AddRating_Valid_Product_Valid_Rating_Valid_Should_Return_True()
        {
            // Arrange

            // Get the First data item
            var data = TestHelper.ProductService.GetAllData().First();
            var countOriginal = data.Ratings.Length;

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 5);
            var dataNewList = TestHelper.ProductService.GetAllData().First();

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
        }

        // Look up the product, if it does not exist, it should return false
        [Test]
        public void AddRating_InValid_ProductID_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating("invalid_productid", 1);

            // Assert
            Assert.AreEqual(false, result);
        }

       
        // Check Rating for boundries, it should not allow ratings below 0

        [Test]
        public void AddRating_InValid_Rating_Negative_Should_Return_False()
        {
            // Arrange

            var data = TestHelper.ProductService.GetAllData().First();

            // Act

            var result = TestHelper.ProductService.AddRating(data.Id, -1);

            // Assert
            Assert.AreEqual(false, result);
        }

        // Check Rating for boundries, it should not allow ratings above 5
        [Test]
        public void AddRating_InValid_Rating_Above_5_Should_Return_False()
        {
            // Arrange

            var data = TestHelper.ProductService.GetAllData().First();

            // Act

            var result = TestHelper.ProductService.AddRating(data.Id, 6);

            // Assert
            Assert.AreEqual(false, result);
        }

        // Check to see if the rating exist, if there are none, then create the array
        [Test]
        public void AddRating_No_Existing_Ratings_Should_Return_True()
        {
            // Arrange
            // Get the Second data item
            var data = TestHelper.ProductService.GetAllData().Skip(1).First();

            // Act

            var result = TestHelper.ProductService.AddRating(data.Id, 5);
            var dataNewList = TestHelper.ProductService.GetAllData().Skip(1).First();

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.First());
        }
        #endregion AddRating
    }
}