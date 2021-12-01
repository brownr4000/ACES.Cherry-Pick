using Bunit;
using NUnit.Framework;
using ContosoCrafts.WebSite.Components;
using Microsoft.Extensions.DependencyInjection;
using ContosoCrafts.WebSite.Services;
using System.Linq;

namespace UnitTests.Components
{
    /// <summary>
    /// The ProductListsTest class defines Unit Tests for ProductList.razor
    /// </summary>
    public class ProductListTests : BunitTestContext
    {
        #region TestSetup
        /// <summary>
        /// The TestInitialize method creates the necessary objects for the initialization of the unit tests
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }
        #endregion TestSetup

        #region DefaultList
        /// <summary>
        /// The ProductList_Default_Should_Return_Content() Unit Test verifies that
        /// the Product List should return content
        /// </summary>
        [Test]
        public void ProductList_Default_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act
            var page = RenderComponent<ProductList>();

            // Get the Cards returned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(true, result.Contains("Chinese Cuisine"));
        }
        #endregion DefaultList

        #region SelectProduct
        /// <summary>
        /// The SelectProduct_Valid_ID_Should_Contain_Link_To_Product_Page() Unit Test verifies the
        /// More Info button works
        /// </summary>
        [Test]
        public void SelectProduct_Valid_ID_Should_Contain_Link_To_Product_Page()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var id = "Korean Cuisine";
            var page = RenderComponent<ProductList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            // Act
            var link = button.GetAttribute("onclick");

            // Assert
            Assert.AreEqual(true, link.Contains("/Restaurants/"));
        }
        #endregion SelectProduct

        #region Filter
        /// <summary>
        /// The Filter_InValid_Empty_Should_Return_All_Content Unit Test demonstrates 
        /// that an Empty Filter returns all content
        /// </summary>
        [Test]
        public void Filter_InValid_Empty_Should_Return_All_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var filter = "Filter";
            var page = RenderComponent<ProductList>();

            // Generate list of all buttons
            var buttonList = page.FindAll("button");

            // Find the button that matches the given string
            var button = buttonList.First(m => m.OuterHtml.Contains(filter));

            // Act
            button.Click();

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("chinese"));
        }

        /// <summary>
        /// The Filter_Valid_Cuisine_Should_Return_Matching_Content() validates that the filter returns
        /// the cuisine matching the passed in text
        /// </summary>
        [Test]
        public void Filter_Valid_Cuisine_Should_Return_Matching_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var filter = "Filter";
            var text = " ";
            var page = RenderComponent<ProductList>();

            // Generate list of all buttons
            var buttonList = page.FindAll("Button");
            var inputList = page.FindAll("input");

            // Find the button that matches the given string
            var button = buttonList.First(m => m.OuterHtml.Contains(filter));
            var search = inputList.First(m => m.OuterHtml.Contains(text));

            // Act
            search.Change("korean");
            button.Click();

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("korean"));
        }

        /// <summary>
        /// The Filter_Clear_Valid_Search_Should_Return_All_Content() validates that the clear button
        /// functions as expected and returns all cuisines after completing a valid filter
        /// </summary>
        [Test]
        public void Filter_Clear_Valid_Search_Should_Return_All_Content()
        {
            
            // Arrange
            // Filter for valid content
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var filter = "Filter";
            var text = " ";
            var page = RenderComponent<ProductList>();

            // Generate list of all buttons
            var buttonList = page.FindAll("Button");
            var inputList = page.FindAll("input");

            // Find the button that matches the given string
            var button = buttonList.First(m => m.OuterHtml.Contains(filter));
            var search = inputList.First(m => m.OuterHtml.Contains(text));

            // Act
            search.Change("korean");
            button.Click();

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("korean"));

            // Clear and search different content
            // Arrange
            var clear = "Clear";

            // Find the button that matches the given string
            button = buttonList.First(m => m.OuterHtml.Contains(clear));

            // Act
            button.Click();

            // Get the markup to use for the assert
            pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("chinese"));
        }
        #endregion Filter
    }
}