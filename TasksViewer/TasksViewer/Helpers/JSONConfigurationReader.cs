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
    /// <summary>
    /// Reader for configuration stored in json file
    /// </summary>
    /// <remarks>File is stored in Configuration folder</remarks>
    public class JSONConfigurationReader
    {
        private List<ConfigurationModel> _configurationValues = new List<ConfigurationModel>();
        private string _jsonFilePath;

        public JSONConfigurationReader(string jsonFilePath)
        {
            _jsonFilePath = jsonFilePath;
        }

        public void LoadConfiguration()
        {
            using(StreamReader reader = new StreamReader(_jsonFilePath))
            {
                string json = reader.ReadToEnd();
                List<ConfigurationModel> values = JsonConvert.DeserializeObject<List<ConfigurationModel>>(json);

                ValidateConfigurationValues(); 
            }
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
            //return base.ToString();
            string result = string.Empty; 

            foreach(var elem in _configurationValues)
            {
                result += elem.TFSAddress.ToString(); 
            }

            return result;
        }
    }
}
