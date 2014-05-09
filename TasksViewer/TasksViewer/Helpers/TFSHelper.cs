using log4net;
using log4net.Appender;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Framework.Client.Catalog.Objects;
using Microsoft.TeamFoundation.Framework.Common;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksViewer.Helpers
{
    /// <summary>
    /// Helper for tfs handling
    /// </summary>
    public class TFSHelper
    {
        #region private members

        private string _tfsAddress;
        
        // TODO - use dependency injection for logging
        private static readonly ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType); 

        #endregion

        #region ctors

        public TFSHelper(string tfsAddress)
        {
            _tfsAddress = tfsAddress;
            
            SimpleLayout layout = new SimpleLayout();
            FileAppender appender = new FileAppender(layout, System.Environment.SpecialFolder.MyDocuments + "mylogFile.txt", false); 
            
        }

        #endregion

        /// <summary>
        /// Lists all TFS collection, each collection can have project
        /// </summary>
        public void ListAllCollections()
        {
            try
            {
                TfsConfigurationServer server = TfsConfigurationServerFactory.GetConfigurationServer(new Uri(_tfsAddress));

                ReadOnlyCollection<CatalogNode> collectionNodes = server.CatalogNode.QueryChildren(new[] { CatalogResourceTypes.ProjectCollection }, false, CatalogQueryOptions.None);

                foreach (CatalogNode node in collectionNodes)
                {
                    Guid collectionId = new Guid(node.Resource.Properties["InstanceId"]);
                    TfsTeamProjectCollection teamProjectCollection = server.GetTeamProjectCollection(collectionId);
                    Console.WriteLine("Collection: " + teamProjectCollection.Name);

                    // TODO - temporary list all projects also here
                    ReadOnlyCollection<CatalogNode> projectNodes = node.QueryChildren(new[] { CatalogResourceTypes.TeamProject }, false, CatalogQueryOptions.None); 
                    foreach (CatalogNode elem in projectNodes)
                    {
                        Console.WriteLine("Team project name is: " + elem.Resource.DisplayName);
                    }
                }
            }
            catch (Exception ex)
            {
                // custom exception handling - TODO throw custom exception
                _logger.Error("Tfs conection error: " + ex.Message); 
                throw;
            }
        }


        public void ListAllProjects()
        {
            throw new NotImplementedException("To be implemented"); 
        }

        /// <summary>
        /// Gets all team projects
        /// </summary>
        /// <returns></returns>
        public Microsoft.TeamFoundation.WorkItemTracking.Client.ProjectCollection GetAllTeamProjects()
        {
            var tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(_tfsAddress));
            var wiStore = tfs.GetService<WorkItemStore>();

            return wiStore.Projects; 
        }

        public void ListAllProjectsNames(Microsoft.TeamFoundation.WorkItemTracking.Client.ProjectCollection projects)
        {
            Console.WriteLine("List all project names new method");

            foreach (Project elem in projects)
            {
                Console.WriteLine("Project name is: " + elem.Name);
            }
        }

        public void QueryAllWorkItems(Project project)
        {
            string query =   " SELECT [System.Id], [System.WorkItemType],"+
          " [System.State], [System.AssignedTo], [System.Title] "+
          " FROM WorkItems " + 
          " WHERE [System.TeamProject] = '" + project.Name + 
          "' ORDER BY [System.WorkItemType], [System.Id]";

            
            var tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(_tfsAddress));
            var wiStore = tfs.GetService<WorkItemStore>();

            WorkItemCollection workItems = wiStore.Query(query); 

            foreach(WorkItem wi in workItems)
            {
                Console.WriteLine(wi.Title + "[" + wi.Type.Name + "]" + wi.State);
            }
        }

        // TODO - should be parameterized by date
        public void QueryClosedTodayWorkItems(Project project)
        {
            string query = " SELECT [System.Id], [System.WorkItemType]," +
          " [System.State], [System.AssignedTo], [System.Title] " +
          " FROM WorkItems " +
          " WHERE [System.TeamProject] = '" + project.Name + "'" + 
          " AND [System.State] = '" + "done" + "'"  +
          " AND [Microsoft.VSTS.Common.ClosedDate] = " + "@today" + 
          " ORDER BY [System.WorkItemType], [System.Id]";
            
            var tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri(_tfsAddress));
            var wiStore = tfs.GetService<WorkItemStore>();

            WorkItemCollection workItems = wiStore.Query(query);
            if (workItems.Count == 0)
            {
                Console.WriteLine("No closed work items");
                return; 
            }


            foreach (WorkItem wi in workItems)
            {
                Console.WriteLine(wi.Title + "[" + wi.Type.Name + "]" + wi.State);
            }
        }


    }
}
