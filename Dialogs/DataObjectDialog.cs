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
    public partial class DataObjectDialog : DialogBase
    {
        RecordIdentifier dataObjectId;
        DataObjectClass dataObject;

        public DataObjectDialog(RecordIdentifier dataObjectId)
            :this()
        {
            this.dataObjectId = dataObjectId;
            dataObject = DataProviderFactory.Instance.Get<IDataObjectDataAccess, DataObjectClass>().Get(PluginEntry.DataModel, dataObjectId);

            tbDescription.Text = dataObject.Description;
            tbExtraInfo.Text = dataObject.ExtraInfo;

        }

        public DataObjectDialog()
        {
            InitializeComponent();
        }

        protected override IApplicationCallbacks OnGetFramework()
        {
            return PluginEntry.Framework;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dataObject == null)
            {
                dataObject = new DataObjectClass();
                dataObject.Id = "You somehow have to create this Id string";
            }

            dataObject.Description = tbDescription.Text;
            dataObject.ExtraInfo = tbExtraInfo.Text;

            DataProviderFactory.Instance.Get<IDataObjectDataAccess, DataObjectClass>().
                Save(PluginEntry.DataModel, dataObject);

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
            if (dataObject == null) // Creating new
            {
                btnOK.Enabled = tbDescription.Text.Length > 0 && tbExtraInfo.Text.Length > 0;
            }
            else // Editing existing
            {
                btnOK.Enabled = (tbDescription.Text.Length > 0 && tbDescription.Text != dataObject.Description) ||
                                (tbExtraInfo.Text.Length > 0 && tbExtraInfo.Text != dataObject.ExtraInfo);
            }
        }
    }
}
