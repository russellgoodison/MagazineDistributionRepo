using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Database.Interfaces
{
    interface IController
    {
        /// <summary>
        /// Adds a record to table within the database
        /// </summary>
        /// <param name="ParametersToAdd">The column names and values to add</param>
        /// <returns>If the add was succesfull</returns>
        bool Add(Dictionary<string, object> ParametersToAdd);
        /// <summary>
        /// Removes the record from the table
        /// </summary>
        /// <param name="ID">ID of the record to remove</param>
        /// <returns>If the remove was successful</returns>
        bool Delete(string ID);
        /// <summary>
        /// Used to update a specific record within the database
        /// </summary>
        /// <param name="ID">ID of the record to update</param>
        /// <param name="ParametersToUpdate">Column names and values to update</param>
        /// <returns>If the update was successful</returns>
        bool Update(string ID, Dictionary<string, object> ParametersToUpdate);
    }
}
