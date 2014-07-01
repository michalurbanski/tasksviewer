using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksViewer.Configuration;

namespace TasksViewer.UnitTests
{
    [TestFixture]
    public class ConfigurationTests
    {
        [Test]
        public void Get_ConfigurationPath_ShouldReturnCorrectPath()
        {
            string path = ConfigurationVariables.ConfigurationFileFullPath;

            Console.WriteLine("Current configuration file path is " + path);

            Assert.IsNotNullOrEmpty(path); 
        }
    }
}
