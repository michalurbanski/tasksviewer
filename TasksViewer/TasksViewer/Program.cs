using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksViewer
{
    /// <summary>
    /// Main class in application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entry point in application
        /// </summary>
        /// <param name="args">First arg - SharePoint site for which code review tasks should be inserted - not required</param>
        static void Main(string[] args)
        {
            // 1. Parse input - if first arg is filled then assume that SharePoint tasks list should be performed
            InputParser inputParser = new InputParser(args); 

            // 2. Read closed tasks, resolved bugs and issues for day of application run 

            // 3. If 1 is applied then insert code review task into SharePoint tasks list
            // #TaskId, #ProjectName, #TFS server address

            // 4. Get reports foreach defined project
            // 4a. Save to csv list of all tasks for specified project
        }
    }
}
