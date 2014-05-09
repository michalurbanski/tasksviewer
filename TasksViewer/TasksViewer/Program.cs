using log4net.Appender;
using log4net.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksViewer.Helpers;
using TasksViewer.Models;

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
            // TODO - Requires permission to create file 
            log4net.Config.BasicConfigurator.Configure();
            


            // 1. Parse input - if first arg is filled then assume that SharePoint tasks list should be performed
            InputParser inputParser = new InputParser(args);
            InputArguments inputParseArguments = inputParser.Parse();

            // TODO - if statement can be changed to factory pattern 
            if (inputParseArguments.IsSharePointListInsert) // handling for sharepoint list
            {
                throw new NotImplementedException("To be implemented");
            }
            else // no sharepoint list
            {
                // 1. Prompt for tfs address until valid address is provided
                string tfsAddress; 

                do
                {
                    Console.WriteLine("Please provide TFS address");
                    tfsAddress = Console.ReadLine(); 
                }
                while(URLHelper.IsValidAddress(tfsAddress) == false);

                // 2. Prompt for command - TODO

                // 2. a. For now all projects in collection are listed 
                TFSHelper tfs = new TFSHelper(tfsAddress);
                tfs.ListAllCollections();

                var projects = tfs.GetAllTeamProjects();
                tfs.ListAllProjectsNames(projects);

                tfs.QueryAllWorkItems(projects[0]);
                Console.WriteLine("Closed tasks");
                tfs.QueryClosedTodayWorkItems(projects[0]);
            }

            // TODO - further implementation

            // 2. Read closed tasks, resolved bugs and issues for day of application run 

            // 3. If 1 is applied then insert code review task into SharePoint tasks list
            // #TaskId, #ProjectName, #TFS server address

            // 4. Get reports foreach defined project
            // 4a. Save to csv list of all tasks for specified project


            Console.WriteLine("End of program");
            Console.ReadLine(); 
        }
    }
}
