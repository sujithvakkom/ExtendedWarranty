using System.Collections.Generic;
using LSOne.DataLayer.BusinessObjects;
using LSOne.DataLayer.DataProviders;
using LSOne.Utilities.DataTypes;
using LSOne.ViewCore;
using LSOne.ViewCore.Enums;
using LSOne.ViewPlugins.ExtendedWarranty.DataLayer;
using LSOne.ViewPlugins.ExtendedWarranty.DataLayer.DataEntities;

namespace LSOne.ViewPlugins.ExtendedWarranty.Views
{
    public partial class SimpleView : ViewBase
    {
        private RecordIdentifier dataObjectId;
        private DataObjectClass dataObject;

        // Constructor for when using this view to edit.
        public SimpleView(RecordIdentifier objectId)
            : this()
        {
            this.dataObjectId = objectId;
            dataObject = DataProviderFactory.Instance.Get<IDataObjectDataAccess, DataObjectClass>().Get(PluginEntry.DataModel, dataObjectId);

            tbDescription.Text = dataObject.Description;
        }

        // Constructor for when using this view to add
        public SimpleView()
        {
            InitializeComponent();

            // These are the attributes that the view should support.
            Attributes = ViewAttributes.Revert |
                ViewAttributes.Save |
                ViewAttributes.Delete |
                ViewAttributes.Audit |
                ViewAttributes.Help |
                ViewAttributes.Close |
                ViewAttributes.ContextBar;

            // Optional: if ReadOnly is true then the view will not attempt to save
            // ReadOnly = !PluginEntry.DataModel.HasPermission("Your code permission GUID");

            dataObject = new DataObjectClass();
            
        }

        // This code decides what should appear when the user views the audit log for this view (presses F6)
        // If you don't have any audit information then this can be empty.
        public override void GetAuditDescriptors(List<AuditDescriptor> contexts)
        {
            //contexts.Add(new AuditDescriptor("NameOfAuditDescriptor", dataObjectId, description, true));
        }

        // The text that appears above the ContextBar
        protected override string LogicalContextName
        {
            get
            {
                return "Text above context bar";
            }
        }

        public override RecordIdentifier ID
        {
            get { return (dataObjectId != null) ? dataObjectId : ""; }
        }

        protected override void LoadData(bool isRevert)
        {
            HeaderText = "Description on the top of the simple view";
        }

        // Here we check if any of our data has changed. If it has changed then we return True and the SaveData() function is called
        protected override bool DataIsModified()
        {

            if (tbDescription.Text != dataObject.Description) return true;
            if (tbExtraInfo.Text != dataObject.ExtraInfo) return true;
      
            return false;
        }

        // This function only gets called if DataIsModified() returned True.
        protected override bool SaveData()
        {
            // Populate your dataObject with the correct fields from the view.
            dataObject.Description = tbDescription.Text;
            dataObject.ExtraInfo = tbExtraInfo.Text;

            // Now we call the save function of our data access class
            DataProviderFactory.Instance.Get<DataLayer.IDataObjectDataAccess, DataObjectClass>().
                Save(PluginEntry.DataModel, dataObject);

            return true;
        }

        // This function is called when the user presses the delete button in the top right part of the view. This button is
        // only visible if you set the Attributes flag to include ViewAttributes.Delete
        protected override void OnDelete()
        {
            // Call the delete funciton of your data access class
        }
    }
}
