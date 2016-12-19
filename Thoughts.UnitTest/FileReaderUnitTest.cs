using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThoughtWorks_ConferenceTrackManagment.UtilitiesInterface;
using ThoughtWorks_ConferenceTrackManagment.UtilitiesInterface.Fakes;
using System.Collections.Generic;
using ThoughtWorks_ConferenceTrackManagment.Utilties;
using System.IO;
using System.Linq;
using Thoughts.UnitTest.UnitTestHelpers;

namespace Thoughts.UnitTest
{
    [TestClass]
    public class UtiltiesUnitTest
    {
        public FileReader FileReaderUnderTest { get; set; }


        [TestMethod]
        public void FileReader_PathEmpty_ThrowArgumentException()
        {

            //Arrange
            const string filePath = null;

            //Generate mock implementation of the fileReader using stub
            IFile fileMock = new StubIFile
            {
                ReadLinesString = (fileName) =>
                    {
                        return new List<string>();
                    }
            };


            //Act
            var fileReader = new FileReader(fileMock);
            ExceptionAssert.Throws<ArgumentNullException>(() => fileReader.ReadFile(filePath));
            

            //Assert
        }


        [TestMethod]
        public void FileReader_FileNotExist_ThrowNotFoundException()
        {

            //Arrange
            const string filePath = "MyFilePath";

            //Generate mock implementation of the fileReader using stub
            IFile fileMock = new StubIFile
            {
                ExistsString=(fileName)=>
                    {
                        return false;
                    }

            };


            //Act
            var fileReader = new FileReader(fileMock);
            ExceptionAssert.Throws<FileNotFoundException>(() => fileReader.ReadFile(filePath));

            //Assert
        }

        [TestMethod]
        public void FileReader_FileExist_ReadTheFiles()
        {

            //Arrange
            const string filePath = "MyFilePath";
            const int noOfLines = 5;
            const string content = "This is a line";

            //Generate mock implementation of the fileReader using stub
            IFile fileMock = new StubIFile
            {
                ExistsString = (fileName) =>
                {
                    return true;
                },

                ReadLinesString = (filepath) =>
                {
                    var linesMock = Enumerable.Repeat<string>(content, 5);
                    return linesMock;
                },

            };


            //Act
            var fileReader = new FileReader(fileMock);
            var result = fileReader.ReadFile(filePath);

            //Assert
            Assert.AreEqual(noOfLines, result.Count(), "Failed to expected no of lines");
            Assert.IsTrue(result.All(g => g == content), "Failed to match expected content");
            Assert.IsInstanceOfType(result, typeof(IEnumerable<string>), "Failed to match expected type");
        }
    }
}
