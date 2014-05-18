using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksViewer.Helpers;

namespace TasksViewer.Ninject
{
    /// <summary>
    /// Manager for objects using ninject modules
    /// </summary>
    public class KernelManager
    {
        private StandardKernel _kernel;
        public TFSHelper TfsHelper { get; private set; }

        public KernelManager()
        {
            // Register modules
            _kernel = new StandardKernel(new LoggerModule());

            // Fill properties
            FillProperties(); 
        }

        private void FillProperties()
        {
            TfsHelper = _kernel.Get<TFSHelper>(); 
        }

    }
}
