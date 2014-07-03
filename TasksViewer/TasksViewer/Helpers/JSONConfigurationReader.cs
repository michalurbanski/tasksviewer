using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksViewer.Models;

namespace TasksViewer.Helpers
{
    // TODO - in context of unit tests think about inheritance instead of adding new methods 
    /// <summary>
    /// Reader for configuration stored in json file
    /// </summary>
    /// <remarks>File is stored in Configuration folder</remarks>
    public class JSONConfigurationReader
    {
        private List<ConfigurationModel> _configurationValues = new List<ConfigurationModel>();
        private string _jsonFilePath;

        public ConfigurationModel ConfigurationValuesModel
        {
            get { return _configurationValues.FirstOrDefault(); }
        }

        public JSONConfigurationReader()
        {
            // empty
        }

        public JSONConfigurationReader(string jsonFilePath)
        {
            _jsonFilePath = jsonFilePath;
        }

        /// <summary>
        /// Reads configuration values from file on disk in specified path by constructor
        /// </summary>
        public void LoadConfiguration()
        {
            using(StreamReader reader = new StreamReader(_jsonFilePath))
            {
                string json = reader.ReadToEnd();
                DeserializeContent(json);

                ValidateConfigurationValues(); 
            }
        }

        public void DeserializeContent(string text)
        {
            _configurationValues = JsonConvert.DeserializeObject<List<ConfigurationModel>>(text);
        }

        private void ValidateConfigurationValues()
        {
            if (!_configurationValues.Any())
            {
                throw new ArgumentException("Configuration file is empty");
            }

            if(_configurationValues.Count > 1)
            {
                throw new ArgumentException("Too many configuration settings in file");
            }
        }

        public override string ToString()
        {
            string result = string.Empty; 

            foreach(var elem in _configurationValues)
            {
                result += elem.TFSAddress.ToString(); 
            }

            return result;
        }
    }
}
