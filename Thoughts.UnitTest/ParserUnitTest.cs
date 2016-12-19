using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThoughtWorks_ConferenceTrackManagment.UtilitiesInterface;
using ThoughtWorks_ConferenceTrackManagment.UtiltiesImplementation;
using ThoughtWorks_ConferenceTrackManagment.Models;
using Thoughts.UnitTest.UnitTestHelpers;
using ThoughtWorks_ConferenceTrackManagment.Models.Sessions;

namespace Thoughts.UnitTest
{
    /// <summary>
    /// Summary description for ParserUnitTest
    /// </summary>
    [TestClass]
    public class ParserUnitTest
    {
        public ParserUnitTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public IParser ParserUnderTest { get; set; }

        #region Additional test attributes

        //Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize() { ParserUnderTest = new Parser(); }

        #endregion

        [TestMethod]
        public void Parser_InputNull_ThrowException()
        {
            //Act
            ExceptionAssert.Throws<ArgumentNullException>(() => ParserUnderTest.ParseToSession(null));
        }

        [TestMethod]
        public void Parser_InvalidInput_ThrowException()
        {
            //Act and Assert
            ExceptionAssert.Throws<FormatException>(() => ParserUnderTest.ParseToSession(new List<string>() { "Test file" }));

        }

        [TestMethod]
        public void Parser_ValidInput_ValidSession()
        {
            //Arrange
            string expectedTitle = "This is my last session 10min";
            int expectedDuration = 10;
            var collection = new List<string> { expectedTitle };

            //Act
            var result = ParserUnderTest.ParseToSession(collection);

            //Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<Session>), "Failed to return expected instance");
            Assert.AreEqual(expectedDuration, result.FirstOrDefault().Duration, "Failed to parse the time");
            Assert.AreEqual(expectedTitle, result.FirstOrDefault().Title, "Failed to parse the title");
        }

        [TestMethod]
        public void Parser_NoOfInput_And_NoOfSession_ShouldBeSame()
        {
            //Arrange
            string expectedTitle = "This is my last session 10min";
            var collection = new List<string> { expectedTitle, expectedTitle };

            //Act
            var result = ParserUnderTest.ParseToSession(collection);

            //Assert
            Assert.AreEqual(2, result.Count(), "Failed to meet the expected no of session after parsing");
        }

        [TestMethod]
        public void Parser_InputIsLightining_ValidDuration()
        {
            //Arrange
            string expectedTitle = "This is my last session lightning";
            int expectedDuration = 5;
            var collection = new List<string> { expectedTitle };

            //Act
            var result = ParserUnderTest.ParseToSession(collection);

            //Assert
            Assert.AreEqual(result.First().Duration, expectedDuration);
        }


    }
}
