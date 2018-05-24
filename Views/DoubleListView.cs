using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using LSOne.DataLayer.BusinessObjects;
using LSOne.DataLayer.DataProviders;
using LSOne.Utilities.DataTypes;
using LSOne.ViewCore;
using LSOne.ViewCore.Enums;
using LSOne.ViewPlugins.ExtendedWarranty.DataLayer;
using LSOne.ViewPlugins.ExtendedWarranty.DataLayer.DataEntities;

namespace LSOne.ViewPlugins.ExtendedWarranty.Views
{
    public partial class DoubleListView : ViewBase
    {
        private RecordIdentifier selectedId;

        public DoubleListView(RecordIdentifier selectedId)
            : this()
        {
            this.selectedId = selectedId;
        }

        public DoubleListView()
        {
            InitializeComponent();

            Attributes = ViewAttributes.Help |
                         ViewAttributes.Close |
                         ViewAttributes.ContextBar |
                         ViewAttributes.Audit;


            // Optional : Disable the add button when the user does not have the correct permission
            //btnsEditAddRemove.AddButtonEnabled = PluginEntry.DataModel.HasPermission("Your code permission GUID");

            // These four lines allow you to capture right click-ing on the lists. The functions lvGroups_Opening and lvValues_Opening 
            // are run when the right click is performed
            lvObjects.ContextMenuStrip = new ContextMenuStrip();
            lvObjects.ContextMenuStrip.Opening += lvObjects_Opening;
            lvLines.ContextMenuStrip = new ContextMenuStrip();
            lvLines.ContextMenuStrip.Opening += lvLines_Opening;

            HeaderText = "Double list view header text";

        }

        // This code decides what should appear when the user views the audit log for this view (presses F6)
        // If you don't have any audit information then this can be empty.
        public override void GetAuditDescriptors(List<AuditDescriptor> contexts)
        {
            //contexts.Add(new AuditDescriptor("NameOfAuditDescriptor", dataObjectId, description, true));
        }

        protected override string LogicalContextName
        {
            get
            {
                return "Text above context bar";
            }
        }

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

        protected override bool DataIsModified()
        {
           return false;
        }

        protected override bool SaveData()
        {
            return true;
        }

        // Top list view items get loaded
        private void LoadObjects()
        {
            ListViewItem listItem;

            lvObjects.Items.Clear();

            List<DataObjectClass> dataObjects = DataProviderFactory.Instance.Get<DataLayer.IDataObjectDataAccess, DataObjectClass>().
                GetList(PluginEntry.DataModel);

            foreach (var dataObject in dataObjects)
            {
                listItem = new ListViewItem((string)dataObject.Id);
                listItem.SubItems.Add(dataObject.Description);
                listItem.SubItems.Add(dataObject.ExtraInfo);
                listItem.Tag = dataObject.Id;
                listItem.ImageIndex = -1;

                lvObjects.Add(listItem);

                if (selectedId == (RecordIdentifier)listItem.Tag)
                {
                    listItem.Selected = true;
                }
            }

            lvObjects.BestFitColumns();
            lvObjects_SelectedIndexChanged(this, EventArgs.Empty);
        }

        // Bottom list view items get loaded
        private void LoadLines()
        {
            ListViewItem listItem;

            if (lvObjects.SelectedItems.Count == 0) return;

            lvLines.Items.Clear();

            RecordIdentifier selectedObjectId = (RecordIdentifier)lvObjects.SelectedItems[0].Tag;

            List<DataObjectLineClass> lines = DataProviderFactory.Instance.Get<IDataObjectLineDataAccess, DataObjectLineClass>().GetList(
                PluginEntry.DataModel,
                selectedObjectId);

            foreach (var line in lines)
            {
                listItem = new ListViewItem((string)line.LineId);
                listItem.SubItems.Add(line.Description);

                listItem.Tag = line.LineId;
                lvLines.Add(listItem);
            }

            lvLines.BestFitColumns();
            lvLines_SelectedIndexChanged(this, EventArgs.Empty);
        }

        private void lvObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool objectSelected = (lvObjects.SelectedItems.Count != 0);

            RecordIdentifier selectedObjectId = (objectSelected) ? (RecordIdentifier)lvObjects.SelectedItems[0].Tag : "";
            btnsContextButtons.EditButtonEnabled = btnsContextButtons.RemoveButtonEnabled = objectSelected;// && PluginEntry.DataModel.HasPermission(BusinessObjects.Permission.EditSalesTaxSetup);

            if (objectSelected)
            {
                if (!lblGroupHeader.Visible)
                {
                    lblGroupHeader.Visible = true;
                    lvLines.Visible = true;
                    btnsContextButtonsItems.Visible = true;
                    lblNoSelection.Visible = false;
                }

                LoadLines();
            }
            else if (lblGroupHeader.Visible)
            {
                lblGroupHeader.Visible = false;
                lvLines.Visible = false;
                btnsContextButtonsItems.Visible = false;
                lblNoSelection.Visible = true;
            }
        }

        private void lvLines_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool lineSelected = (lvLines.SelectedItems.Count != 0);

            btnsContextButtonsItems.EditButtonEnabled = btnsContextButtonsItems.RemoveButtonEnabled = lineSelected; //&& PluginEntry.DataModel.HasPermission(BusinessObjects.Permission.EditSalesTaxSetup);
        }

        void lvObjects_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip menu = lvObjects.ContextMenuStrip;
            ExtendedMenuitem item;
            menu.Items.Clear();

            // We can optionally add our own items right here
            item = new ExtendedMenuitem(
                    Properties.Resources.Edit + "...",
                    100,
                    new EventHandler(btnEdit_Click))
                           {
                               Enabled = btnsContextButtons.EditButtonEnabled,
                               Image = btnsContextButtons.EditButtonImage,
                               Default = true
                           };

            menu.Items.Add(item);

            item = new ExtendedMenuitem(
                    Properties.Resources.Add + "...",
                    200,
                    new EventHandler(btnAdd_Click))
                       {
                           Enabled = btnsContextButtons.AddButtonEnabled,
                           Image = btnsContextButtons.AddButtonImage
                       };

            menu.Items.Add(item);

            item = new ExtendedMenuitem(
                    Properties.Resources.Delete + "...",
                    300,
                    new EventHandler(btnRemove_Click))
                       {
                           Enabled = btnsContextButtons.RemoveButtonEnabled,
                           Image = btnsContextButtons.RemoveButtonImage
                       };

            menu.Items.Add(item);

            e.Cancel = (menu.Items.Count == 0);
        }

        void lvLines_Opening(object sender, CancelEventArgs e)
        {
            ContextMenuStrip menu = lvLines.ContextMenuStrip;

            menu.Items.Clear();

            // We can optionally add our own items right here
            var item = new ExtendedMenuitem(
                    Properties.Resources.Add + "...",
                    200,
                    new EventHandler(btnAddLine_Click))
                       {
                           Enabled = btnsContextButtonsItems.AddButtonEnabled,
                           Image = btnsContextButtonsItems.AddButtonImage
                       };

            menu.Items.Add(item);

            item = new ExtendedMenuitem(
                    Properties.Resources.Delete + "...",
                    300,
                    new EventHandler(btnRemoveLine_Click))
                       {
                           Enabled = btnsContextButtonsItems.RemoveButtonEnabled,
                           Image = btnsContextButtonsItems.RemoveButtonImage
                       };

            menu.Items.Add(item);

            e.Cancel = (menu.Items.Count == 0);
        }

        private void lvObjects_DoubleClick(object sender, EventArgs e)
        {
            if (btnsContextButtons.EditButtonEnabled)
            {
                btnEdit_Click(this, EventArgs.Empty);
            }
        }

        private void lvLines_DoubleClick(object sender, EventArgs e)
        {
            if (btnsContextButtonsItems.EditButtonEnabled)
            {
                btnEditLine_Click(this, EventArgs.Empty);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            RecordIdentifier selectedObjectId = (RecordIdentifier)lvObjects.SelectedItems[0].Tag;
            var dlg = new Dialogs.DataObjectDialog(selectedObjectId);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LoadObjects();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var dlg = new Dialogs.DataObjectDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LoadObjects();
            } 
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            // Maybe you want to ask the user for a confirmation first ?
            if (lvObjects.SelectedItems.Count > 0)
            {
                RecordIdentifier selectedId = (RecordIdentifier)lvObjects.SelectedItems[0].Tag;
                DataProviderFactory.Instance.Get<IDataObjectDataAccess, DataObjectClass>().
                    Delete(PluginEntry.DataModel, selectedId);
                LoadObjects();
            }
        }

        private void btnEditLine_Click(object sender, EventArgs e)
        {
            RecordIdentifier selectedObjectId = (RecordIdentifier)lvObjects.SelectedItems[0].Tag;
            RecordIdentifier selectedLineId = (RecordIdentifier)lvLines.SelectedItems[0].Tag;
            var dlg = new Dialogs.DataObjectLineDialog(selectedObjectId, selectedLineId);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LoadObjects();
            }
        }

        private void btnAddLine_Click(object sender, EventArgs e)
        {
            RecordIdentifier selectedObjectId = (RecordIdentifier)lvObjects.SelectedItems[0].Tag;
            var dlg = new Dialogs.DataObjectLineDialog(selectedObjectId);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                LoadObjects();
            }
        }

        private void btnRemoveLine_Click(object sender, EventArgs e)
        {
            // Maybe you want to ask the user for a confirmation first ?
            if (lvObjects.SelectedItems.Count > 0)
            {
                RecordIdentifier selectedObjectId = (RecordIdentifier)lvObjects.SelectedItems[0].Tag;
                RecordIdentifier selectedLineId = (RecordIdentifier)lvLines.SelectedItems[0].Tag;
                DataProviderFactory.Instance.Get<IDataObjectLineDataAccess, DataObjectLineClass>().
                    Delete(PluginEntry.DataModel, selectedLineId, selectedObjectId);
                LoadObjects();
            }
        }

    }
}
