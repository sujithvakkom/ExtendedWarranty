using System;
using System.Windows.Forms;
using LSOne.DataLayer.BusinessObjects;
using LSOne.DataLayer.DataProviders;
using LSOne.Utilities.DataTypes;
using LSOne.ViewCore.Dialogs;
using LSOne.ViewCore.Interfaces;
using LSOne.ViewPlugins.ExtendedWarranty.DataLayer;
using LSOne.ViewPlugins.ExtendedWarranty.DataLayer.DataEntities;

namespace LSOne.ViewPlugins.ExtendedWarranty.Dialogs
{
    public partial class DataObjectLineDialog : DialogBase
    {
        RecordIdentifier objectId;
        RecordIdentifier lineId;
        DataObjectLineClass dataObjectLine;

        // When editing
        public DataObjectLineDialog(RecordIdentifier objectId, RecordIdentifier lineId)
            :this(objectId)
        {
            this.objectId = objectId;
            this.lineId = lineId;

            dataObjectLine = DataProviderFactory.Instance.Get<IDataObjectLineDataAccess, DataObjectLineClass>().
                Get(PluginEntry.DataModel, lineId, objectId);

            tbDescription.Text = dataObjectLine.Description;
        }

        // When adding
        public DataObjectLineDialog(RecordIdentifier objectId)
        {
            InitializeComponent();
        }

        protected override IApplicationCallbacks OnGetFramework()
        {
            return PluginEntry.Framework;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dataObjectLine == null)
            {
                dataObjectLine = new DataObjectLineClass();
                dataObjectLine.ObjectId = objectId;
                dataObjectLine.LineId = "You somehow have to create this Id string";
            }

            dataObjectLine.Description = tbDescription.Text;

            DataProviderFactory.Instance.Get<IDataObjectLineDataAccess, DataObjectLineClass>()
                .Save(PluginEntry.DataModel, dataObjectLine);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        // Check for the Ok btn being enabled
        private void CheckEnabled(object sender, EventArgs e)
        {
            if (dataObjectLine == null)// Creating new
            {
                btnOK.Enabled = tbDescription.Text.Length > 0;
            }
            else // Editing existing
            {
                btnOK.Enabled = tbDescription.Text.Length > 0 && tbDescription.Text != dataObjectLine.Description;
            }
        }
    }
}
