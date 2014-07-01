using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksViewer.Configuration
{
    /// <summary>
    /// Configuration variables used in application
    /// </summary>
    /// <remarks>Not made as static class due to required unit testing</remarks>
    public class ConfigurationVariables
    {
        private string _configurationFilePath = @"Configuration\configuration.json";

        public string ConfigurationFileFullPath 
        {
            get
            {
                if (string.IsNullOrEmpty(_configurationFilePath))
                {
                    return string.Empty; 
                }

                // TODO: 2014-07-01 for now simple assumption that program is in \bin\Debug
                string currentDirectory = Directory.GetCurrentDirectory();
                currentDirectory = currentDirectory.Replace(@"\bin\Debug", "");

                return Path.Combine(currentDirectory, _configurationFilePath);
            }
            set // setter allows to test various test cases regarding file presence and correctness
            {
                _configurationFilePath = value; 
            }
        }

    }
}
