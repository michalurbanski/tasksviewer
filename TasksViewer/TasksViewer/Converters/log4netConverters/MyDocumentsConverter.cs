using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksViewer.Converters.log4netConverters
{
    /// <summary>
    /// log4net converter
    /// </summary>
    public class MyDocumentsConverter : log4net.Util.PatternConverter
    {
        protected override void Convert(System.IO.TextWriter writer, object state)
        {
            Environment.SpecialFolder specialFolder = (Environment.SpecialFolder)Enum.Parse(typeof(Environment.SpecialFolder), base.Option, true);
            writer.Write(Environment.GetFolderPath(specialFolder));
        }
    }
}
