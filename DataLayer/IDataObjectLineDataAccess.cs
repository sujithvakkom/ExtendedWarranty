using System.Collections.Generic;
using LSOne.DataLayer.DataProviders;
using LSOne.DataLayer.GenericConnector.Interfaces;
using LSOne.Utilities.DataTypes;
using LSOne.ViewPlugins.ExtendedWarranty.DataLayer.DataEntities;

namespace LSOne.ViewPlugins.ExtendedWarranty.DataLayer
{
    public interface IDataObjectLineDataAccess : IDataProviderBase<DataObjectLineClass>
    {
        DataObjectLineClass Get(IConnectionManager entry, RecordIdentifier lineId, RecordIdentifier objectId);
        List<DataObjectLineClass> GetList(IConnectionManager entry, RecordIdentifier objectId);

        /// <summary>
        /// Deletes a DataObjectLine with a given ID
        /// </summary>
        /// <param name="entry">Entry into the database</param>
        /// <param name="lineId">The LineId of the DataObjectLine to delete</param>
        /// <param name="objectId">The ObjectId of the DataObjectLine to delete</param>
        void Delete(IConnectionManager entry, RecordIdentifier lineId, RecordIdentifier objectId);

        /// <summary>
        /// Checks whether a DataObjectLine with a given ID exists in the database
        /// </summary>
        /// <param name="entry">Entry into the database</param>
        /// <param name="objectId">The ID of the DataObjectLine to check for</param>
        /// <param name="lineId">The lineId of the DataObjectLine to check for</param>
        /// <returns>Whether the DataObjectLine exists or not</returns>
        bool Exists(IConnectionManager entry, RecordIdentifier objectId, RecordIdentifier lineId);

        /// <summary>
        /// Saves a DataObjectLine object to the database
        /// </summary>
        /// <param name="entry">Entry into the database</param>
        /// <param name="dataObjectLine">The DataObjectLine to save</param>
        void Save(IConnectionManager entry, DataObjectLineClass dataObjectLine);
    }
}