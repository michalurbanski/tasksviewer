using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksViewer.Helpers
{
    /// <summary>
    /// Helper class for url parsing
    /// </summary>
    public static class URLHelper
    {
        /// <summary>
        /// Checks if given address is valid http address
        /// </summary>
        /// <param name="address">Address to verify if correct http address</param>
        /// <returns></returns>
        public static bool IsValidAddress(string address)
        {
            Uri uriResult;
            return Uri.TryCreate(address, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
        }
    }
}
