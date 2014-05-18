using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksViewer.Helpers;

namespace TasksViewer.BusinessLogic
{
    public class TFSFcd
    {
        private ILog _logger;
        private TFSHelper _tfsHelper; 

        public TFSFcd(ILog logger)
        {
            _logger = logger;
            _tfsHelper = new TFSHelper(logger); 
        }

        public void TestLogMessage()
        {
            _logger.Info("Test of ninject in facade"); 
        }
    }
}
