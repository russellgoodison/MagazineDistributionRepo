using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Database.Enums;

namespace DataAccessLayer.Database.Controllers.Base
{
    /// <summary>
    /// This class is used to directly communicate with the SQL Server. It is the only class with a direct connection.
    /// </summary>
    public class BaseController
    {
        #region Fields

        /// <summary>
        /// The connection string used to communicate with the database
        /// </summary>
        private string connectionString;
        /// <summary>
        /// Variable used to execute sql commands to the database
        /// </summary>
        private SqlCommand cmd;
        /// <summary>
        /// Virtual implementation of the connection to the database
        /// </summary>
        private SqlConnection connection;
        /// <summary>
        /// Used to allow the fill the datatables and datasets
        /// </summary>
        private SqlDataAdapter adapter;
        /// <summary>
        /// Used to store the data retrieved from the database
        /// </summary>
        private DataTable dt;

        #endregion

        #region Constructors

        /// <summary>
        /// Instantiates the BaseDatabase connection
        /// </summary>
        /// <param name="ConnectionStringParam">Connection String Name to use</param>
        public BaseController(string ConnectionStringParam = "MagazineDistribution")
        {
            // set the connection string
            connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[ConnectionStringParam].ConnectionString;
        }

        #endregion

        #region Properties

        #endregion

        #region Methods

        #region Internal

        #region Select

        /// <summary>
        /// Retrieves all data from a view
        /// </summary>
        /// <param name="viewToSelect">View from which the data must be selected</param>
        /// <returns>A datatable containing all the data returned</returns>
        internal DataTable Select(DatabaseViews viewToSelect)
        {
            if (TestConnection())
            {
                try
                {
                    string viewName = GetViewName(viewToSelect);
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    cmd = new SqlCommand("Select * from " + viewName, connection);
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    dt = new DataTable();
                    adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(dt);
                    return dt;
                }
                catch (Exception)
                {
                    throw;
                }
            }
            else
            {
                throw new Exception("Unable to connect to the database. Please contact the System Administrator.");
            }
        }

        #endregion

        #region Insert

        internal bool Insert(DatabaseInsertableTables tableToInsertInto)
        {
            throw new NotImplementedException("The insert feature has not been implemented yet");
        }

        #endregion

        #region Update

        internal bool Update(DatabaseUpdateableTables tableToUpdateValues)
        {
            throw new NotImplementedException("The update feature has not been implemented yet");
        }

        #endregion

        #region Delete

        internal bool Delete(DatabaseDeleteableTables tableToDeleteValueFrom, string IDToDelete)
        {
            throw new NotImplementedException("The delete feature has not been implemented yet");
        }

        #endregion

        #endregion

        #region Test

        /// <summary>
        /// Tests if a successful connection to the database specified can be made
        /// </summary>
        /// <returns>True if the connection was successfully made</returns>
        internal bool TestConnection()
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

        #region Get Procedure and View Names

        #region Get View Names

        /// <summary>
        /// Gets the view name to be used to read data from the database
        /// </summary>
        /// <param name="viewToSelect">Table to get information from</param>
        /// <returns>The view name to be called</returns>
        private string GetViewName(DatabaseViews viewToSelect)
        {
            string temp = "view_";

            switch (viewToSelect)
            {
                case DatabaseViews.ActiveSessions:
                    return temp + "ActiveSessions";
                case DatabaseViews.AllAddresses:
                    return temp + "AllAddresses";
                case DatabaseViews.AllMagazineIssueDownloads:
                    return temp + "AllMagazineIssueDownloads";
                case DatabaseViews.AllMagazines:
                    return temp + "AllMagazines";
                case DatabaseViews.AllSubscriptions:
                    return temp + "AllSubscriptions";
                case DatabaseViews.AllUsers:
                    return temp + "AllUsers";
                default:
                    return null;
            }
        }

        #endregion

        #region Get ProcedureNames

        /// <summary>
        /// Used to get the procedure name associated with any table that can have values deleted.
        /// </summary>
        /// <param name="tableToAlter">Enum of the table that is to be deleted from</param>
        /// <returns>The Procedure name for the delete method</returns>
        private string GetProcedureName(DatabaseDeleteableTables tableToAlter)
        {
            string temp = "sp_Delete";

            switch (tableToAlter)
            {
                case DatabaseDeleteableTables.Address:
                    return temp + "Address";
                case DatabaseDeleteableTables.Magazine:
                    return temp + "Magazine";
                case DatabaseDeleteableTables.MagazineIssue:
                    return temp + "MagazineIssue";
                case DatabaseDeleteableTables.Session:
                    return temp + "Session";
                case DatabaseDeleteableTables.Subscription:
                    return temp + "Subscription";
                case DatabaseDeleteableTables.User:
                    return temp + "User";
                default:
                    return null;
            }
        }

        /// <summary>
        /// Gets the procedure name for the table that is to be inserted into.
        /// </summary>
        /// <param name="tableToAlter">Table to have values inserted</param>
        /// <returns>The procedure name for the insert</returns>
        private string GetProcedureName(DatabaseInsertableTables tableToAlter)
        {
            string temp = "sp_Insert";

            switch (tableToAlter)
            {
                case DatabaseInsertableTables.Address:
                    return temp + "Address";
                case DatabaseInsertableTables.Magazine:
                    return temp + "Magazine";
                case DatabaseInsertableTables.MagazineIssue:
                    return temp + "MagazineIssue";
                case DatabaseInsertableTables.MagazineIssueDownload:
                    return temp + "MagazineIssueDownload";
                case DatabaseInsertableTables.Session:
                    return temp + "Session";
                case DatabaseInsertableTables.Subscription:
                    return temp + "Subscription";
                case DatabaseInsertableTables.User:
                    return temp + "User";
                default:
                    return null;
            }
        }

        /// <summary>
        /// Gets the procedure name for the table that is to be updated
        /// </summary>
        /// <param name="tableToAlter">Table to apply the update to</param>
        /// <returns>The procedure name for the update</returns>
        private string GetProcedureName(DatabaseUpdateableTables tableToAlter)
        {
            string temp = "sp_Update";

            switch (tableToAlter)
            {
                case DatabaseUpdateableTables.Address:
                    return temp + "Address";
                case DatabaseUpdateableTables.Magazine:
                    return temp + "Magazine";
                case DatabaseUpdateableTables.MagazineIssue:
                    return temp + "MagazineIssue";
                case DatabaseUpdateableTables.Subscription:
                    return temp + "Subscription";
                case DatabaseUpdateableTables.User:
                    return temp + "User";
                default:
                    return null;
            }
        }

        #endregion

        #endregion

        #endregion
    }
}
