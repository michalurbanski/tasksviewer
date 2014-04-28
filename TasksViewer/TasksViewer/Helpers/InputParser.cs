using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TasksViewer.Interfaces;
using TasksViewer.Models;

namespace TasksViewer
{
    /// <summary>
    /// Parser for application input
    /// </summary>
    public class InputParser : IInputParse
    {
        private string[] _arguments; 

        public InputParser(string[] args)
        {
            _arguments = args; 
        }

        #region IInputParse

        /// <summary>
        /// Parses arguments passed in constructor
        /// </summary>
        /// <returns>InputArguments object</returns>
        public InputArguments Parse()
        {
            return new InputArguments(); 
        }

        #endregion
    }
}
