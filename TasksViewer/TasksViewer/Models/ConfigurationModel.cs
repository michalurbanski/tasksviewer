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
        public string TFSAddress { get; set; } // not case-aware - it's good in context of variables naming
    }
}
