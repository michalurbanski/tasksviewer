using log4net;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksViewer.Ninject
{
    /// <summary>
    /// Module with logging functionality registration
    /// </summary>
    public class LoggerModule : NinjectModule
    {
        public override void Load()
        {
            // Injection of log4net
            Bind<ILog>().ToMethod(context => LogManager.GetLogger(context.Request.Target.Member.ReflectedType)).InTransientScope();       
        }
    }
}
