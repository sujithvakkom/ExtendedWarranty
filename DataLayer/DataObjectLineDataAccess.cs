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
    /// A data provider class for a demo DataObjectLine. All methods have the action part commented out and hardcoded sample data instead
    /// </summary>
    public class DataObjectLineDataAccess : SqlServerDataProviderBase, IDataObjectLineDataAccess
    {
        // This method is used by the get methods to populate the DataObjectLine
        private static void PopulateDataObject(IDataReader dr, DataObjectLineClass dataObject)
        {
            dataObject.LineId = (string)dr["Id"];
            dataObject.ObjectId = (string)dr["ObjectId"];
            dataObject.Description = (string)dr["Description"];
        }

        public DataObjectLineClass Get(IConnectionManager entry, RecordIdentifier lineId, RecordIdentifier objectId)
        {
            DataObjectLineClass dataObjectLine = new DataObjectLineClass();

            using (SqlCommand cmd = new SqlCommand())
            {
                // You have to change the SQL here
                cmd.CommandText =
                      @"Select ObjectId, LineId, Description 
                        From YOURLINETABLE 
                        Where ObjectId = @objectId and LineId = @lineId";

                MakeParam(cmd, "objectId", (string)objectId);
                MakeParam(cmd, "lineId", (string)lineId);

                // Here we fetch our data. This is commented out because the table YOURLINETABLE does not exist
                //var result = Execute<DataObjectLineClass>(entry, cmd, CommandType.Text, PopulateDataObject);
                //dataObjectLine = (result.Count > 0) ? result[0] : null;
            }

            // Demo data
            dataObjectLine = new DataObjectLineClass() { LineId = (string)lineId, ObjectId = (string)objectId, Description = "Line " + (string)lineId +  " for object " + (string)objectId };

            return dataObjectLine;
        }

        public List<DataObjectLineClass> GetList(IConnectionManager entry, RecordIdentifier objectId)
        {
            List<DataObjectLineClass> dataObjectLines = new List<DataObjectLineClass>();

            using (SqlCommand cmd = new SqlCommand())
            {
                // You have to change the SQL here
                cmd.CommandText =
                      @"Select ObjectId, LineId, Description 
                        From YOURLINETABLE 
                        Where ObjectId = @objectId ";

                MakeParam(cmd, "objectId", (string)objectId);

                // Here we fetch our data. This is commented out because the table YOURLINETABLE does not exist
                //dataObjectLines = Execute<DataObjectLineClass>(entry, cmd, CommandType.Text, PopulateDataObject);
            }

            // Demo data
            dataObjectLines.Add(new DataObjectLineClass() { ObjectId = (string)objectId, LineId = "0", Description = "Line 0 for object " + (string)objectId});
            dataObjectLines.Add(new DataObjectLineClass() { ObjectId = (string)objectId, LineId = "1", Description = "Line 0 for object " + (string)objectId});
            dataObjectLines.Add(new DataObjectLineClass() { ObjectId = (string)objectId, LineId = "2", Description = "Line 0 for object " + (string)objectId});

            return dataObjectLines;
        }

        /// <summary>
        /// Deletes a DataObjectLine with a given ID
        /// </summary>
        /// <param name="entry">Entry into the database</param>
        /// <param name="lineId">The LineId of the DataObjectLine to delete</param>
        /// <param name="objectId">The ObjectId of the DataObjectLine to delete</param>
        public void Delete(IConnectionManager entry, RecordIdentifier lineId, RecordIdentifier objectId)
        {
            //DeleteRecord(entry, "YOURLINETABLE", new[]{ "LineId", "ObjectId" }, new RecordIdentifier(lineId, objectId), "Your code permission GUID");
        }

        /// <summary>
        /// Checks whether a DataObjectLine with a given ID exists in the database
        /// </summary>
        /// <param name="entry">Entry into the database</param>
        /// <param name="objectId">The ID of the DataObjectLine to check for</param>
        /// <param name="lineId">The lineId of the DataObjectLine to check for</param>
        /// <returns>Whether the DataObjectLine exists or not</returns>
        public bool Exists(IConnectionManager entry, RecordIdentifier objectId, RecordIdentifier lineId)
        {
            //return RecordExists(entry, "YOURLINETABLE", new[] { "LineId", "ObjectId" }, new RecordIdentifier(lineId, objectId));
            return true;
        }

        /// <summary>
        /// Saves a DataObjectLine object to the database
        /// </summary>
        /// <param name="entry">Entry into the database</param>
        /// <param name="dataObjectLine">The DataObjectLine to save</param>
        public void Save(IConnectionManager entry, DataObjectLineClass dataObjectLine)
        {
            SqlCommand cmd = new SqlCommand();
            SqlServerStatement statement = new SqlServerStatement("YOURLINETABLE");

            if (!Exists(entry, dataObjectLine.ObjectId, dataObjectLine.LineId))
            {
                statement.StatementType = StatementType.Insert;

                statement.AddKey("ObjectId", (string)dataObjectLine.ObjectId);
                statement.AddKey("LineId", (string)dataObjectLine.LineId);
            }
            else
            {
                statement.StatementType = StatementType.Update;

                statement.AddCondition("ObjectId", (string)dataObjectLine.ObjectId);
                statement.AddCondition("LineId", (string)dataObjectLine.LineId);
            }

            statement.AddField("Description", dataObjectLine.Description);

            // Here we run the save statement. This is commented out because YOURLINETABLE does not exist with the given fields.
            //entry.Connection.ExecuteStatement(statement);
        }
    }
}
