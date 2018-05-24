using LSOne.DataLayer.BusinessObjects;
using LSOne.Utilities.DataTypes;

namespace LSOne.ViewPlugins.ExtendedWarranty.DataLayer.DataEntities
{
    public class DataObjectLineClass
    {
        public RecordIdentifier LineId { get; set; }
        public RecordIdentifier ObjectId { get; set; }
        public string Description { get; set; }
    }
}
