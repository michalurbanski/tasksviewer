using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksViewer.Models
{
    /// <summary>
    /// Model for configuration variables read from json file
    /// </summary>
    public class ConfigurationModel
    {
        // TODO - is this variable case-sensitive in context of json file ? 
        public string TFSAddress { get; set; }
    }
}
