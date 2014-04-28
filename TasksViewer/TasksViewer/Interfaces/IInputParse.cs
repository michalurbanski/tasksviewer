using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksViewer.Models;

namespace TasksViewer.Interfaces
{
    /// <summary>
    /// Interface for input parser
    /// </summary>
    public interface IInputParse
    {
        InputArguments Parse(); 
    }
}
