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
            if (_arguments != null && _arguments.Count() == 1)
            {
                return new InputArguments
                {
                    IsSharePointListInsert = true, 
                    SharePointWebAddress = _arguments[0], 
                    IsValidHttpAddress = IsValidAddress(_arguments[0])
                }; 
            }

            return new InputArguments(); 
        }

        #endregion

        #region private methods

        /// <summary>
        /// Checks if given address is valid http address
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        private bool IsValidAddress(string address)
        {
            Uri uriResult;
            return Uri.TryCreate(address, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp; 
        }

        #endregion
    }
}
