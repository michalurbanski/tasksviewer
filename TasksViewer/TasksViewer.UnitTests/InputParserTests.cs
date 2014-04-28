using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksViewer.UnitTests
{
    /// <summary>
    /// Tests for input parser
    /// </summary>
    [TestFixture]
    class InputParserTests
    {
        private InputParser _parser;
        private string _sharepointSite = @"http://test/sites/site";

        [SetUp]
        public void SetUp()
        {
            _parser = null; 
        }
        
        [Test]
        public void Test_EmptyArgs_SharePointListNotUsed()
        {
            // Arrange
            _parser = new InputParser(null);

            // Act 
            var result = _parser.Parse(); 

            // Assert
            Assert.AreEqual(false, result.IsSharePointListInsert);
            Assert.AreEqual(default(string), result.SharePointWebAddress);
            Assert.AreEqual(false, result.IsValidHttpAddress); 
        }

        [Test]
        public void Test_ArgsFilled_First_SharePointListUsed()
        {
            // Arrange
            string[] arguments = new string[]{_sharepointSite};
            _parser = new InputParser(arguments);

            // Act
            var result = _parser.Parse(); 
                
            // Assert
            Assert.AreEqual(true, result.IsSharePointListInsert);
            Assert.AreEqual(_sharepointSite, result.SharePointWebAddress);
            Assert.AreEqual(true, result.IsValidHttpAddress); 
        }

        [Test]
        public void Test_ARgsFilled_FirsT_SharePointListUsed_InvalidAddress()
        {
            // Arrange
            string[] arguments = new string[] { "invalid address" };
            _parser = new InputParser(arguments); 

            // Act
            var result = _parser.Parse(); 

            // Assert
            Assert.AreEqual(true, result.IsSharePointListInsert);
            Assert.AreNotEqual(_sharepointSite, result.SharePointWebAddress);
            Assert.AreEqual(false, result.IsValidHttpAddress); 
        }

    }
}
