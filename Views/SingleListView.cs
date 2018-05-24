using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using LSOne.DataLayer.BusinessObjects;
using LSOne.DataLayer.DataProviders;
using LSOne.Utilities.DataTypes;
using LSOne.ViewCore;
using LSOne.ViewCore.Enums;
using LSOne.ViewPlugins.ExtendedWarranty.DataLayer.DataEntities;

namespace LSOne.ViewPlugins.ExtendedWarranty.Views
{
    public partial class SingleListView : ViewBase
    {
        RecordIdentifier selectedId;

        // Constructor that opens the view with a line with Id == selectedId choosen
        public SingleListView(RecordIdentifier selectedId)
            :base()
        {
            this.selectedId = selectedId;
        }

        // Constructor that opens the view without a line selected
        public SingleListView()
        {
            InitializeComponent();

            Attributes = ViewAttributes.Audit |
                ViewAttributes.Close |
                ViewAttributes.ContextBar |
                ViewAttributes.Help;

            HeaderText = "Single list view header text";

            // Optional : Disable the add button when the user does not have the correct permission
            //btnsEditAddRemove.AddButtonEnabled = PluginEntry.DataModel.HasPermission("Your code permission GUID");

            // These two lines allow you to capture right click-ing on the list. The function ContextMenuStrip_Opening is run when the right 
            // click is performed
            lvDataObjects.ContextMenuStrip = new ContextMenuStrip();
            lvDataObjects.ContextMenuStrip.Opening += ContextMenuStrip_Opening;
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

        // Dont change
        public override RecordIdentifier ID
        {
            get
            {
                return RecordIdentifier.Empty;
            }
        }

        protected override void LoadData(bool isRevert)
        {
            LoadObjects();
        }

        // Here we load all of our items into the list 
        private void LoadObjects()
        {
            // Replace the DataObject class with the class you are working with in this list view 

            ListViewItem listItem;
            lvDataObjects.Items.Clear();
            List<DataObjectClass> dataObjects =

            DataProviderFactory.Instance.Get<DataLayer.IDataObjectDataAccess, DataObjectClass>().
                GetList(PluginEntry.DataModel);

            foreach (DataObjectClass dataObject in dataObjects)
            {
                listItem = new ListViewItem((string)dataObject.Id);
                listItem.SubItems.Add(dataObject.Description);
                listItem.SubItems.Add(dataObject.ExtraInfo);

                listItem.Tag = dataObject.Id;
                lvDataObjects.Add(listItem);

                if (selectedId == (RecordIdentifier)listItem.Tag)
                {
                    listItem.Selected = true;
                }
            }

            lvDataObjects_SelectedIndexChanged(this, EventArgs.Empty);
            lvDataObjects.BestFitColumns();
        }

        private void lvDataObjects_SelectedIndexChanged(object sender, EventArgs e)
        {            
            // Check if edit and remove buttons should be enabled based on the line selections and permission (remove the permission part if you have no permissions)
            btnsEditAddRemove.EditButtonEnabled = lvDataObjects.SelectedItems.Count > 0; // && PluginEntry.DataModel.HasPermission("Your code permission GUID");
            btnsEditAddRemove.RemoveButtonEnabled = lvDataObjects.SelectedItems.Count > 0; // && PluginEntry.DataModel.HasPermission("Your code permission GUID");
        }

        // Open a edit dialog and if the user pressed Ok we reload our items
        private void btnsEditAddRemove_EditButtonClicked(object sender, EventArgs e)
        {
            RecordIdentifier selectedId = (RecordIdentifier)lvDataObjects.SelectedItems[0].Tag;
            var dlg = new Dialogs.DataObjectDialog(selectedId);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LoadObjects();
            }
        }

        // Open a add dialog and if the user pressed Ok we reload our items
        private void btnsEditAddRemove_AddButtonClicked(object sender, EventArgs e)
        {
            var dlg = new Dialogs.DataObjectDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LoadObjects();
            }          
        }

        private void btnsEditAddRemove_RemoveButtonClicked(object sender, EventArgs e)
        {
            // Maybe you want to ask the user for a confirmation first ?
            if (lvDataObjects.SelectedItems.Count > 0)
            {
                RecordIdentifier selectedId = (RecordIdentifier)lvDataObjects.SelectedItems[0].Tag;
                DataProviderFactory.Instance.Get<DataLayer.IDataObjectDataAccess, DataObjectClass>().Delete(PluginEntry.DataModel, selectedId);
                
                LoadObjects();
            }
        }

        // This function is run when the user right clicks the list
        void ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip menu = lvDataObjects.ContextMenuStrip;
            menu.Items.Clear();

            // Each item is a line in the right click menu. 
            // Usually there is not much that needs to be changed here

            var item = new ExtendedMenuitem(
                    Properties.Resources.Edit,
                    100,
                    btnsEditAddRemove_EditButtonClicked);
            item.Image = btnsEditAddRemove.EditButtonImage;
            item.Enabled = btnsEditAddRemove.EditButtonEnabled;
            item.Default = true; // The default item has a bold font
            menu.Items.Add(item);

            item = new ExtendedMenuitem(
                   Properties.Resources.Add,
                   200,
                   new EventHandler(btnsEditAddRemove_AddButtonClicked));

            item.Enabled = btnsEditAddRemove.AddButtonEnabled;
            item.Image = btnsEditAddRemove.AddButtonImage;
            menu.Items.Add(item);

            item = new ExtendedMenuitem(
                    Properties.Resources.Delete,
                    300,
                    new EventHandler(btnsEditAddRemove_RemoveButtonClicked));

            item.Image = btnsEditAddRemove.RemoveButtonImage;
            item.Enabled = btnsEditAddRemove.RemoveButtonEnabled;
            menu.Items.Add(item);

            e.Cancel = (menu.Items.Count == 0);
        }

        private void lvDataObjects_DoubleClick(object sender, EventArgs e)
        {
            // If the edit button is enabled when run the edit button operation. No need to change anything here
            if (btnsEditAddRemove.EditButtonEnabled)
            {
                btnsEditAddRemove_EditButtonClicked(this, EventArgs.Empty);
            }
        }

    }
}
