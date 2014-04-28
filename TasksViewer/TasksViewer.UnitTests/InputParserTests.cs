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
        }

    }
}
