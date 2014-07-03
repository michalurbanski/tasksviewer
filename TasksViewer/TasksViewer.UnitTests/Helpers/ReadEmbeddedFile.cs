using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TasksViewer.UnitTests.Helpers
{
    public static class ReadEmbeddedFile
    {
        public static string ReadEmbeddedConfigurationFile()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "TasksViewer.UnitTests.Files.Configuration.json";
            string result; 

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }
    }
}
