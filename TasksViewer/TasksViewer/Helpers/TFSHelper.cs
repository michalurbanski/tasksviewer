using log4net;
using log4net.Appender;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Framework.Client;
using Microsoft.TeamFoundation.Framework.Common;
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
                }
            }
            catch (Exception ex)
            {
                // custom exception handling
                _logger.Error("Tfs conection error: " + ex.Message); 
                throw;
            }
        }

        public void ListAllProjects()
        {
            throw new NotImplementedException("To be implemented"); 
        }

    }
}
