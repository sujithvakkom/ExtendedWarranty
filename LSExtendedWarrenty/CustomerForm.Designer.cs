namespace LSExtendedWarrenty
{
    partial class CustomerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerForm));
            this.labelCustomerName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.groupBoxCreateCustomer = new System.Windows.Forms.GroupBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.phoneControlPhone = new PhoneNumberControl.PhoneControl();
            this.labelAddress = new System.Windows.Forms.Label();
            this.groupBoxCustomerLookup = new System.Windows.Forms.GroupBox();
            this.buttonFind = new System.Windows.Forms.Button();
            this.textBoxPhoneLookup = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxEmailLookup = new System.Windows.Forms.TextBox();
            this.labelLokupEmail = new System.Windows.Forms.Label();
            this.textBoxNameLookup = new System.Windows.Forms.TextBox();
            this.labelLookupName = new System.Windows.Forms.Label();
            this.dataGridViewTransactions = new System.Windows.Forms.DataGridView();
            this.labelTransactions = new System.Windows.Forms.Label();
            this.buttonAddReceipt = new System.Windows.Forms.Button();
            this.splitContainerCustomer = new System.Windows.Forms.SplitContainer();
            this.textBoxSelectedAddress = new System.Windows.Forms.TextBox();
            this.textBoxSelectedPhone = new System.Windows.Forms.TextBox();
            this.textBoxSelectedEmail = new System.Windows.Forms.TextBox();
            this.textBoxSelectedName = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonSwitch = new System.Windows.Forms.Button();
            this.textBoxSelectedCountry = new System.Windows.Forms.TextBox();
            this.groupBoxCreateCustomer.SuspendLayout();
            this.groupBoxCustomerLookup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactions)).BeginInit();
            this.splitContainerCustomer.Panel1.SuspendLayout();
            this.splitContainerCustomer.Panel2.SuspendLayout();
            this.splitContainerCustomer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelCustomerName
            // 
            this.labelCustomerName.AutoSize = true;
            this.labelCustomerName.Location = new System.Drawing.Point(6, 25);
            this.labelCustomerName.Name = "labelCustomerName";
            this.labelCustomerName.Size = new System.Drawing.Size(82, 13);
            this.labelCustomerName.TabIndex = 1;
            this.labelCustomerName.Text = "Customer Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(88, 22);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(205, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(56, 51);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(32, 13);
            this.labelEmail.TabIndex = 2;
            this.labelEmail.Text = "Email";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(88, 48);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(205, 20);
            this.textBoxEmail.TabIndex = 2;
            this.textBoxEmail.TextChanged += new System.EventHandler(this.textBoxEmail_TextChanged);
            // 
            // groupBoxCreateCustomer
            // 
            this.groupBoxCreateCustomer.Controls.Add(this.textBoxAddress);
            this.groupBoxCreateCustomer.Controls.Add(this.buttonAdd);
            this.groupBoxCreateCustomer.Controls.Add(this.textBoxName);
            this.groupBoxCreateCustomer.Controls.Add(this.textBoxEmail);
            this.groupBoxCreateCustomer.Controls.Add(this.phoneControlPhone);
            this.groupBoxCreateCustomer.Controls.Add(this.labelEmail);
            this.groupBoxCreateCustomer.Controls.Add(this.labelAddress);
            this.groupBoxCreateCustomer.Controls.Add(this.labelCustomerName);
            this.groupBoxCreateCustomer.Location = new System.Drawing.Point(5, 3);
            this.groupBoxCreateCustomer.Name = "groupBoxCreateCustomer";
            this.groupBoxCreateCustomer.Size = new System.Drawing.Size(571, 148);
            this.groupBoxCreateCustomer.TabIndex = 5;
            this.groupBoxCreateCustomer.TabStop = false;
            this.groupBoxCreateCustomer.Text = "Create New Customer";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(355, 22);
            this.textBoxAddress.Multiline = true;
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(202, 90);
            this.textBoxAddress.TabIndex = 4;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(482, 117);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 5;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // phoneControlPhone
            // 
            this.phoneControlPhone.Location = new System.Drawing.Point(9, 89);
            this.phoneControlPhone.Name = "phoneControlPhone";
            this.phoneControlPhone.Size = new System.Drawing.Size(284, 54);
            this.phoneControlPhone.TabIndex = 3;
            this.phoneControlPhone.ValidationMessage = "Selected Country is Not Valid";
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(304, 61);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(45, 13);
            this.labelAddress.TabIndex = 4;
            this.labelAddress.Text = "Address";
            // 
            // groupBoxCustomerLookup
            // 
            this.groupBoxCustomerLookup.Controls.Add(this.buttonFind);
            this.groupBoxCustomerLookup.Controls.Add(this.textBoxPhoneLookup);
            this.groupBoxCustomerLookup.Controls.Add(this.label3);
            this.groupBoxCustomerLookup.Controls.Add(this.textBoxEmailLookup);
            this.groupBoxCustomerLookup.Controls.Add(this.labelLokupEmail);
            this.groupBoxCustomerLookup.Controls.Add(this.textBoxNameLookup);
            this.groupBoxCustomerLookup.Controls.Add(this.labelLookupName);
            this.groupBoxCustomerLookup.Location = new System.Drawing.Point(12, 194);
            this.groupBoxCustomerLookup.Name = "groupBoxCustomerLookup";
            this.groupBoxCustomerLookup.Size = new System.Drawing.Size(582, 43);
            this.groupBoxCustomerLookup.TabIndex = 6;
            this.groupBoxCustomerLookup.TabStop = false;
            this.groupBoxCustomerLookup.Text = "Customer Lookup";
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(538, 15);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(38, 23);
            this.buttonFind.TabIndex = 9;
            this.buttonFind.Text = "Find";
            this.buttonFind.UseVisualStyleBackColor = true;
            // 
            // textBoxPhoneLookup
            // 
            this.textBoxPhoneLookup.Location = new System.Drawing.Point(394, 16);
            this.textBoxPhoneLookup.Name = "textBoxPhoneLookup";
            this.textBoxPhoneLookup.Size = new System.Drawing.Size(142, 20);
            this.textBoxPhoneLookup.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(318, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Phone Number";
            // 
            // textBoxEmailLookup
            // 
            this.textBoxEmailLookup.Location = new System.Drawing.Point(183, 16);
            this.textBoxEmailLookup.Name = "textBoxEmailLookup";
            this.textBoxEmailLookup.Size = new System.Drawing.Size(135, 20);
            this.textBoxEmailLookup.TabIndex = 7;
            // 
            // labelLokupEmail
            // 
            this.labelLokupEmail.AutoSize = true;
            this.labelLokupEmail.Location = new System.Drawing.Point(153, 20);
            this.labelLokupEmail.Name = "labelLokupEmail";
            this.labelLokupEmail.Size = new System.Drawing.Size(32, 13);
            this.labelLokupEmail.TabIndex = 7;
            this.labelLokupEmail.Text = "Email";
            // 
            // textBoxNameLookup
            // 
            this.textBoxNameLookup.Location = new System.Drawing.Point(37, 17);
            this.textBoxNameLookup.Name = "textBoxNameLookup";
            this.textBoxNameLookup.Size = new System.Drawing.Size(114, 20);
            this.textBoxNameLookup.TabIndex = 6;
            // 
            // labelLookupName
            // 
            this.labelLookupName.AutoSize = true;
            this.labelLookupName.Location = new System.Drawing.Point(2, 20);
            this.labelLookupName.Name = "labelLookupName";
            this.labelLookupName.Size = new System.Drawing.Size(35, 13);
            this.labelLookupName.TabIndex = 6;
            this.labelLookupName.Text = "Name";
            // 
            // dataGridViewTransactions
            // 
            this.dataGridViewTransactions.AllowUserToAddRows = false;
            this.dataGridViewTransactions.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
            this.dataGridViewTransactions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTransactions.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewTransactions.Location = new System.Drawing.Point(12, 267);
            this.dataGridViewTransactions.MultiSelect = false;
            this.dataGridViewTransactions.Name = "dataGridViewTransactions";
            this.dataGridViewTransactions.ReadOnly = true;
            this.dataGridViewTransactions.RowHeadersVisible = false;
            this.dataGridViewTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewTransactions.Size = new System.Drawing.Size(582, 149);
            this.dataGridViewTransactions.TabIndex = 7;
            // 
            // labelTransactions
            // 
            this.labelTransactions.AutoSize = true;
            this.labelTransactions.Location = new System.Drawing.Point(12, 243);
            this.labelTransactions.Name = "labelTransactions";
            this.labelTransactions.Size = new System.Drawing.Size(68, 13);
            this.labelTransactions.TabIndex = 8;
            this.labelTransactions.Text = "Transactions";
            // 
            // buttonAddReceipt
            // 
            this.buttonAddReceipt.Location = new System.Drawing.Point(508, 238);
            this.buttonAddReceipt.Name = "buttonAddReceipt";
            this.buttonAddReceipt.Size = new System.Drawing.Size(75, 23);
            this.buttonAddReceipt.TabIndex = 10;
            this.buttonAddReceipt.Text = "Add Receipt";
            this.buttonAddReceipt.UseVisualStyleBackColor = true;
            // 
            // splitContainerCustomer
            // 
            this.splitContainerCustomer.Location = new System.Drawing.Point(12, 12);
            this.splitContainerCustomer.Name = "splitContainerCustomer";
            this.splitContainerCustomer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerCustomer.Panel1
            // 
            this.splitContainerCustomer.Panel1.Controls.Add(this.groupBoxCreateCustomer);
            // 
            // splitContainerCustomer.Panel2
            // 
            this.splitContainerCustomer.Panel2.Controls.Add(this.textBoxSelectedCountry);
            this.splitContainerCustomer.Panel2.Controls.Add(this.textBoxSelectedAddress);
            this.splitContainerCustomer.Panel2.Controls.Add(this.textBoxSelectedPhone);
            this.splitContainerCustomer.Panel2.Controls.Add(this.textBoxSelectedEmail);
            this.splitContainerCustomer.Panel2.Controls.Add(this.textBoxSelectedName);
            this.splitContainerCustomer.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainerCustomer.Panel2MinSize = 0;
            this.splitContainerCustomer.Size = new System.Drawing.Size(582, 155);
            this.splitContainerCustomer.SplitterDistance = 151;
            this.splitContainerCustomer.TabIndex = 11;
            // 
            // textBoxSelectedAddress
            // 
            this.textBoxSelectedAddress.Location = new System.Drawing.Point(345, 82);
            this.textBoxSelectedAddress.Multiline = true;
            this.textBoxSelectedAddress.Name = "textBoxSelectedAddress";
            this.textBoxSelectedAddress.Size = new System.Drawing.Size(226, 70);
            this.textBoxSelectedAddress.TabIndex = 4;
            this.textBoxSelectedAddress.TabStop = false;
            // 
            // textBoxSelectedPhone
            // 
            this.textBoxSelectedPhone.Location = new System.Drawing.Point(159, 55);
            this.textBoxSelectedPhone.Name = "textBoxSelectedPhone";
            this.textBoxSelectedPhone.Size = new System.Drawing.Size(412, 20);
            this.textBoxSelectedPhone.TabIndex = 3;
            this.textBoxSelectedPhone.TabStop = false;
            // 
            // textBoxSelectedEmail
            // 
            this.textBoxSelectedEmail.Location = new System.Drawing.Point(159, 28);
            this.textBoxSelectedEmail.Name = "textBoxSelectedEmail";
            this.textBoxSelectedEmail.Size = new System.Drawing.Size(412, 20);
            this.textBoxSelectedEmail.TabIndex = 2;
            this.textBoxSelectedEmail.TabStop = false;
            // 
            // textBoxSelectedName
            // 
            this.textBoxSelectedName.Location = new System.Drawing.Point(159, 3);
            this.textBoxSelectedName.Name = "textBoxSelectedName";
            this.textBoxSelectedName.Size = new System.Drawing.Size(412, 20);
            this.textBoxSelectedName.TabIndex = 1;
            this.textBoxSelectedName.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LSExtendedWarrenty.Properties.Resources.customer_avatar;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 149);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // buttonSwitch
            // 
            this.buttonSwitch.Image = global::LSExtendedWarrenty.Properties.Resources._switch;
            this.buttonSwitch.Location = new System.Drawing.Point(560, 173);
            this.buttonSwitch.Name = "buttonSwitch";
            this.buttonSwitch.Size = new System.Drawing.Size(23, 23);
            this.buttonSwitch.TabIndex = 12;
            this.buttonSwitch.UseVisualStyleBackColor = true;
            this.buttonSwitch.Click += new System.EventHandler(this.buttonSwitch_Click);
            // 
            // textBoxSelectedCountry
            // 
            this.textBoxSelectedCountry.Location = new System.Drawing.Point(159, 82);
            this.textBoxSelectedCountry.Name = "textBoxSelectedCountry";
            this.textBoxSelectedCountry.Size = new System.Drawing.Size(180, 20);
            this.textBoxSelectedCountry.TabIndex = 5;
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 428);
            this.Controls.Add(this.buttonSwitch);
            this.Controls.Add(this.splitContainerCustomer);
            this.Controls.Add(this.buttonAddReceipt);
            this.Controls.Add(this.labelTransactions);
            this.Controls.Add(this.dataGridViewTransactions);
            this.Controls.Add(this.groupBoxCustomerLookup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CustomerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customer Form";
            this.groupBoxCreateCustomer.ResumeLayout(false);
            this.groupBoxCreateCustomer.PerformLayout();
            this.groupBoxCustomerLookup.ResumeLayout(false);
            this.groupBoxCustomerLookup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactions)).EndInit();
            this.splitContainerCustomer.Panel1.ResumeLayout(false);
            this.splitContainerCustomer.Panel2.ResumeLayout(false);
            this.splitContainerCustomer.Panel2.PerformLayout();
            this.splitContainerCustomer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PhoneNumberControl.PhoneControl phoneControlPhone;
        private System.Windows.Forms.Label labelCustomerName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.GroupBox groupBoxCreateCustomer;
        private System.Windows.Forms.GroupBox groupBoxCustomerLookup;
        private System.Windows.Forms.TextBox textBoxPhoneLookup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxEmailLookup;
        private System.Windows.Forms.Label labelLokupEmail;
        private System.Windows.Forms.TextBox textBoxNameLookup;
        private System.Windows.Forms.Label labelLookupName;
        private System.Windows.Forms.Button buttonFind;
        private System.Windows.Forms.DataGridView dataGridViewTransactions;
        private System.Windows.Forms.Label labelTransactions;
        private System.Windows.Forms.Button buttonAddReceipt;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.SplitContainer splitContainerCustomer;
        private System.Windows.Forms.Button buttonSwitch;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBoxSelectedAddress;
        private System.Windows.Forms.TextBox textBoxSelectedPhone;
        private System.Windows.Forms.TextBox textBoxSelectedEmail;
        private System.Windows.Forms.TextBox textBoxSelectedName;
        private System.Windows.Forms.TextBox textBoxSelectedCountry;
    }
}