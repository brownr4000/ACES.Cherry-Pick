﻿using Bunit;
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
        /// The SelectProduct_Valid_ID_Restaurant_Should_Return_Content() Unit Test verifies the
        /// More Info button works
        /// </summary>
        [Test]
        public void SelectProduct_Valid_ID_Restaurant_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var id = "MoreInfoButton_french";
            var page = RenderComponent<ProductList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            // Act
            button.Click();

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains("MoreInfoButton_french"));
        }
        #endregion SelectProduct

        #region SubmitRating
        /// <summary>
        /// This test verifies that the SubmitRating will change the vote as well as the Star checked
        /// Because the star check is a calculation of the ratings, using a record that has no stars and checking one makes it clear what was changed
        /// The test needs to open the page
        /// Then open the popup on the card
        /// Then record the state of the count and star check status
        /// Then check a star
        /// Then check again the state of the cound and star check status
        /// </summary>
        [Test]
        public void SubmitRating_Valid_ID_Click_Unstared_Should_Increment_Count_And_Check_Star()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var id = "MoreInfoButton_french";

            var page = RenderComponent<ProductList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));
            button.Click();

            // Get the markup of the page post the Click action
            var buttonMarkup = page.Markup;

            // Get the Star Buttons
            var starButtonList = page.FindAll("span");

            // Get the Vote Count
            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var preVoteCountSpan = starButtonList[1];
            var preVoteCountString = preVoteCountSpan.OuterHtml;

            // Get the First star item from the list, it should not be checked
            var starButton = starButtonList.First(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star"));

            // Save the html for it to compare after the click
            var preStarChange = starButton.OuterHtml;

            // Act
            // Click the star button
            starButton.Click();

            // Get the markup to use for the assert
            buttonMarkup = page.Markup;

            // Get the Star Buttons
            starButtonList = page.FindAll("span");

            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var postVoteCountSpan = starButtonList[1];
            var postVoteCountString = postVoteCountSpan.OuterHtml;

            // Get the Last stared item from the list
            starButton = starButtonList.First(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));

            // Save the html for it to compare after the click
            var postStarChange = starButton.OuterHtml;

            // Assert
            // Confirm that the record had no votes to start, and 1 vote after
            Assert.AreEqual(true, preVoteCountString.Contains("Be the first to vote!"));
            Assert.AreEqual(true, postVoteCountString.Contains("1 Vote"));
            Assert.AreEqual(false, preVoteCountString.Equals(postVoteCountString));
        }

        /// <summary>
        /// This test verifies that the SubmitRating will change the vote as well as the Star checked
        /// Because the star check is a calculation of the ratings, using a record that has no stars and checking one makes it clear what was changed
        /// The test needs to open the page
        /// Then open the popup on the card
        /// Then record the state of the count and star check status
        /// Then check a star
        /// Then check again the state of the cound and star check status
        /// </summary>
        [Test]
        public void SubmitRating_Valid_ID_Click_Stared_Should_Increment_Count_And_Leave_Star_Check_Remaining()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);
            var id = "MoreInfoButton_french";

            var page = RenderComponent<ProductList>();

            // Find the Buttons (more info)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));
            button.Click();

            // Get the markup of the page post the Click action
            var buttonMarkup = page.Markup;

            // Get the Star Buttons
            var starButtonList = page.FindAll("span");

            // Get the Vote Count
            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var preVoteCountSpan = starButtonList[1];
            var preVoteCountString = preVoteCountSpan.OuterHtml;

            // Get the Last star item from the list, it should one that is checked
            var starButton = starButtonList.Last(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));

            // Save the html for it to compare after the click
            var preStarChange = starButton.OuterHtml;

            // Act
            // Click the star button
            starButton.Click();

            // Get the markup to use for the assert
            buttonMarkup = page.Markup;

            // Get the Star Buttons
            starButtonList = page.FindAll("span");

            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var postVoteCountSpan = starButtonList[1];
            var postVoteCountString = postVoteCountSpan.OuterHtml;

            // Get the Last stared item from the list
            starButton = starButtonList.Last(m => !string.IsNullOrEmpty(m.ClassName) && m.ClassName.Contains("fa fa-star checked"));

            // Save the html for it to compare after the click
            var postStarChange = starButton.OuterHtml;

            // Assert
            // Confirm that the record had no votes to start, and 1 vote after
            Assert.AreEqual(false, postVoteCountString.Contains("7 Votes"));
            Assert.AreEqual(false, preVoteCountString.Equals(postVoteCountString));
        }
        #endregion SubmitRating

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