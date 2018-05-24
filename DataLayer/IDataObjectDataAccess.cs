using System.Collections.Generic;
using LSOne.DataLayer.DataProviders;
using LSOne.DataLayer.GenericConnector.Interfaces;
using LSOne.Utilities.DataTypes;
using LSOne.ViewPlugins.ExtendedWarranty.DataLayer.DataEntities;

namespace LSOne.ViewPlugins.ExtendedWarranty.DataLayer
{
    public interface IDataObjectDataAccess : IDataProviderBase<DataObjectClass>
    {
        DataObjectClass Get(IConnectionManager entry, RecordIdentifier Id);
        List<DataObjectClass> GetList(IConnectionManager entry);

        /// <summary>
        /// Deletes a DataObject with a given ID
        /// </summary>
        /// <param name="entry">Entry into the database</param>
        /// <param name="dataObjectId">The ID of the DataObject to delete</param>
        void Delete(IConnectionManager entry, RecordIdentifier dataObjectId);

        /// <summary>
        /// Checks whether a DataObject with a given ID exists in the database
        /// </summary>
        /// <param name="entry">Entry into the database</param>
        /// <param name="dataObjectId">The ID of the DataObject to check for</param>
        /// <returns>Whether the DataObject exists or not</returns>
        bool Exists(IConnectionManager entry, RecordIdentifier dataObjectId);

        /// <summary>
        /// Saves a DataObject object to the database
        /// </summary>
        /// <param name="entry">Entry into the database</param>
        /// <param name="dataObject">The DataObject to save</param>
        void Save(IConnectionManager entry, DataObjectClass dataObject);
    }
}