using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using LSOne.DataLayer.BusinessObjects;
using LSOne.DataLayer.GenericConnector.Interfaces;
using LSOne.DataLayer.SqlConnector;
using LSOne.DataLayer.SqlConnector.DataProviders;
using LSOne.Utilities.DataTypes;
using LSOne.ViewPlugins.ExtendedWarranty.DataLayer.DataEntities;

namespace LSOne.ViewPlugins.ExtendedWarranty.DataLayer
{
    /// <summary>
    /// A data provider class for a demo DataObject. All methods have the action part commented out and hardcoded sample data instead
    /// </summary>
    public class DataObjectDataAccess : SqlServerDataProviderBase, IDataObjectDataAccess
    {
        // This method is used by the get methods to populate the DataObject
        private static void PopulateDataObject(IDataReader dr, DataObjectClass dataObject)
        {
            dataObject.Id = (string)dr["Id"];
            dataObject.Description = (string)dr["Description"];
            dataObject.ExtraInfo = (string)dr["ExtraInfo"];
        }

        public DataObjectClass Get(IConnectionManager entry, RecordIdentifier Id)
        {
            DataObjectClass dataObject = new DataObjectClass();

            using (SqlCommand cmd = new SqlCommand())
            {
                // You have to change the SQL here
                cmd.CommandText =
                      @"Select Id, Description, ExtraInfo 
                        From YOURTABLE 
                        Where id = @suppliedId ";

                MakeParam(cmd, "suppliedId", (string)Id);

                // Here we fetch our data. This is commented out because the table YOURTABLE does not exist
                //var result = Execute<DataObjectClass>(entry, cmd, CommandType.Text, PopulateDataObject);
                //dataObject = (result.Count > 0) ? result[0] : null;
            }

            // Demo data
            dataObject = new DataObjectClass() { Id = (string)Id, Description = "Description " + (string)Id, ExtraInfo = "Extra info " + (string)Id };

            return dataObject;
        }

        public List<DataObjectClass> GetList(IConnectionManager entry)
        {
            List<DataObjectClass> dataObjects = new List<DataObjectClass>();

            using (SqlCommand cmd = new SqlCommand())
            {
                // You have to change the SQL here
                cmd.CommandText =
                      @"Select Id, Description, ExtraInfo 
                        From YOURTABLE ";

                // Here we fetch our data. This is commented out because the table YOURTABLE does not exist
                //dataObjects = Execute<DataObjectClass>(entry, cmd, CommandType.Text, PopulateDataObject);
            }

            // Demo data
            dataObjects.Add(new DataObjectClass() { Id = "1", Description = "Description 1", ExtraInfo = "Extra info 1" });
            dataObjects.Add(new DataObjectClass() { Id = "2", Description = "Description 2", ExtraInfo = "Extra info 2" });
            dataObjects.Add(new DataObjectClass() { Id = "3", Description = "Description 3", ExtraInfo = "Extra info 3" });

            return dataObjects;
        }

        /// <summary>
        /// Deletes a DataObject with a given ID
        /// </summary>
        /// <param name="entry">Entry into the database</param>
        /// <param name="DataObjectId">The ID of the DataObject to delete</param>
        public void Delete(IConnectionManager entry, RecordIdentifier dataObjectId)
        {
            //DeleteRecord(entry, "YOURTABLE", "Id", dataObjectId, "Your code permission GUID");
        }

        /// <summary>
        /// Checks whether a DataObject with a given ID exists in the database
        /// </summary>
        /// <param name="entry">Entry into the database</param>
        /// <param name="dataObjectId">The ID of the DataObject to check for</param>
        /// <returns>Whether the DataObject exists or not</returns>
        public bool Exists(IConnectionManager entry, RecordIdentifier dataObjectId)
        {
            //return RecordExists(entry, "YOURTABLE", "Id", dataObjectId);
            return true;
        }

        /// <summary>
        /// Saves a DataObject object to the database
        /// </summary>
        /// <param name="entry">Entry into the database</param>
        /// <param name="dataObject">The DataObject to save</param>
        public void Save(IConnectionManager entry, DataObjectClass dataObject)
        {
            SqlCommand cmd = new SqlCommand();
            SqlServerStatement statement = new SqlServerStatement("YOURTABLE");

            if (!Exists(entry, dataObject.Id))
            {
                statement.StatementType = StatementType.Insert;

                statement.AddKey("Id", (string)dataObject.Id);
            }
            else
            {
                statement.StatementType = StatementType.Update;

                statement.AddCondition("Id", (string)dataObject.Id);
            }

            statement.AddField("Description", dataObject.Description);
            statement.AddField("ExtraInfo", dataObject.ExtraInfo);

            // Here we run the save statement. This is commented out because YOURTABLE does not exist with the given fields.
            //entry.Connection.ExecuteStatement(statement);
        }
    }
}
