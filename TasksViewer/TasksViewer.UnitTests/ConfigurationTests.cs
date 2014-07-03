﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksViewer.Configuration;
using TasksViewer.Helpers;

namespace TasksViewer.UnitTests
{
    /// <summary>
    /// Tests for configuration class
    /// </summary>
    [TestFixture]
    public class ConfigurationTests
    {
        ConfigurationVariables _configuration; 

        [SetUp]
        public void Initialize()
        {
            _configuration = new ConfigurationVariables(); 
        }

        [Test]
        public void Get_DefaultConfigurationPath_ShouldReturnCorrectPath()
        {
            string path = _configuration.ConfigurationFileFullPath;

            Console.WriteLine("Current configuration file path is " + path);

            Assert.IsNotNullOrEmpty(path); 
        }

        [Test]
        public void Get_ConfigurationPath_EmptyPath_ShouldReturnStringEmpty()
        {
            // set empty string as configuration file path
            string configurationFilePath = string.Empty;
            _configuration.ConfigurationFileFullPath = configurationFilePath; 

            string result = _configuration.ConfigurationFileFullPath;

            Assert.IsEmpty(result);
        }

        [Test]
        public void Set_ConfigurationFilePath_FullPathShouldBeValid()
        {
            string fileName = "custompath";

            _configuration.ConfigurationFileFullPath = fileName;

            string result = _configuration.ConfigurationFileFullPath;

            Assert.True(result.Contains(fileName));
        }

        [Test]
        public void ReadJsonConfiguration_ValidConfiguration_ShouldSuccess()
        {
            string fullPath = "\\Files\\configuration.json";

            JSONConfigurationReader reader = new JSONConfigurationReader(fullPath);
            reader.LoadConfiguration(); 
            
            string result = reader.ToString(); 

            Assert.IsNotNullOrEmpty(result);
        }
    }
}
