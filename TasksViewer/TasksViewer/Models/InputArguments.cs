using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksViewer.Models
{
    /// <summary>
    /// Model for input arguments
    /// </summary>
    public class InputArguments
    {
        public bool IsSharePointListInsert { get; set; }
        public string SharePointWebAddress { get; set; }
        public bool IsValidHttpAddress { get; set; }
    }
}
