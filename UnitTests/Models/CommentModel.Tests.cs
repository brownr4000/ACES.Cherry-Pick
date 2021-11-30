using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ContosoCrafts.WebSite.Models;
using Castle.Core.Internal;

namespace UnitTests.Models
{
    /// <summary>
    /// The CommentModelTests class defines unit tests to cover the CommentModel class
    /// </summary>
    class CommenttModelTests
    {
        #region TestSetup
        // Constant stings to hold values for determining unit test
        static public string TEST_WORDS = "Test";
        static public string CHECK_WORDS = "Check";

        CommentModel wordsModel = new()
        {
            Comment = TEST_WORDS
        };

    /// <summary>
    /// The TestInitialize method creates the necessary objects for the initialization of the unit tests
    /// </summary>
    [SetUp]
        public void TestInitialize()
        {

        }
        #endregion TestSetup

        #region IdSetGet
        /// <summary>
        /// The CommentModel_Valid_Id_Set_And_Get_Should_Return_True checks the functionality of the Id field
        /// </summary>
        [Test]
        public void CommentModel_Valid_Id_Set_And_Get_Should_Return_True()
        {
            // Arrange

            // Act
            var start = wordsModel.Id;
            wordsModel.Id = CHECK_WORDS;
            var result = wordsModel.Id;

            // Assert
            Assert.AreEqual(false, start == result);
        }
        #endregion IdSetGet

        #region CommentSetGet
        /// <summary>
        /// The CommentModel_Valid_Comment_Set_And_Get_Should_Return_True checks the functionality of the Comment field
        /// </summary>
        [Test]
        public void CommentModel_Valid_Comment_Set_And_Get_Should_Return_True()
        {
            // Arrange

            // Act
            wordsModel.Comment = CHECK_WORDS;
            var result = wordsModel.Comment;

            // Assert
            Assert.AreEqual(false, result == TEST_WORDS);
        }
        #endregion TitleSetGet
    }
}