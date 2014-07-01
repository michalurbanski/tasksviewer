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
    public static class ConfigurationVariables
    {
        private static readonly string _configurationFilePath = @"Configuration\configuration.json";

        public static string ConfigurationFileFullPath 
        {
            get
            {
                // TODO: 2014-07-01 for now simple assumption that program is in \bin\Debug
                string currentDirectory = Directory.GetCurrentDirectory();
                currentDirectory = currentDirectory.Replace(@"\bin\Debug", "");

                return Path.Combine(currentDirectory, _configurationFilePath);
            }        
        }

    }
}
