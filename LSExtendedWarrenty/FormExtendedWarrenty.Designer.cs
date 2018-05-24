namespace LSExtendedWarrenty
{
    partial class FormExtendedWarrenty
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExtendedWarrenty));
            this.labelCashMemo = new System.Windows.Forms.Label();
            this.textBoxCashMemo = new System.Windows.Forms.TextBox();
            this.labelPhoneNumber = new System.Windows.Forms.Label();
            this.textBoxPhoneNumber = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxCustomerName = new System.Windows.Forms.TextBox();
            this.labelCity = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.groupBoxCustomerDetails = new System.Windows.Forms.GroupBox();
            this.comboBoxCountry = new System.Windows.Forms.ComboBox();
            this.labelCountry = new System.Windows.Forms.Label();
            this.comboBoxWarrenties = new System.Windows.Forms.ComboBox();
            this.groupBoxWarrentySlip = new System.Windows.Forms.GroupBox();
            this.buttonAddSerial = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.richTextBoxWarretySlip = new System.Windows.Forms.RichTextBox();
            this.groupBoxReciept = new System.Windows.Forms.GroupBox();
            this.addWarrentyButton1 = new LSExtendedWarrenty.AppBase.Controls.AddWarrentyButton();
            this.dataGridViewRecieptItems = new System.Windows.Forms.DataGridView();
            this.ItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitSalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LineNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxRecieptId = new System.Windows.Forms.TextBox();
            this.textBoxItem = new System.Windows.Forms.TextBox();
            this.labelItem = new System.Windows.Forms.Label();
            this.buttonPay = new System.Windows.Forms.Button();
            this.groupBoxPriceCheck = new System.Windows.Forms.GroupBox();
            this.buttonWarrentyPriceCheck = new System.Windows.Forms.Button();
            this.textBoxItemSearch = new System.Windows.Forms.TextBox();
            this.buttonJournel = new System.Windows.Forms.Button();
            this.linkLabelSettings = new System.Windows.Forms.LinkLabel();
            this.statusStripExtendedWarranty = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelLocation = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripButtonCustomerDetails = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.customerFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonCustmerForm = new System.Windows.Forms.Button();
            this.buttonVATReceipt = new System.Windows.Forms.Button();
            this.groupBoxCustomerDetails.SuspendLayout();
            this.groupBoxWarrentySlip.SuspendLayout();
            this.groupBoxReciept.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecieptItems)).BeginInit();
            this.groupBoxPriceCheck.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelCashMemo
            // 
            this.labelCashMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCashMemo.AutoSize = true;
            this.labelCashMemo.Location = new System.Drawing.Point(341, 27);
            this.labelCashMemo.Name = "labelCashMemo";
            this.labelCashMemo.Size = new System.Drawing.Size(63, 13);
            this.labelCashMemo.TabIndex = 0;
            this.labelCashMemo.Text = "&Cash Memo";
            // 
            // textBoxCashMemo
            // 
            this.textBoxCashMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCashMemo.Location = new System.Drawing.Point(408, 24);
            this.textBoxCashMemo.Name = "textBoxCashMemo";
            this.textBoxCashMemo.Size = new System.Drawing.Size(147, 20);
            this.textBoxCashMemo.TabIndex = 1;
            this.textBoxCashMemo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCashMemo_KeyPress);
            // 
            // labelPhoneNumber
            // 
            this.labelPhoneNumber.AutoSize = true;
            this.labelPhoneNumber.Location = new System.Drawing.Point(7, 49);
            this.labelPhoneNumber.Name = "labelPhoneNumber";
            this.labelPhoneNumber.Size = new System.Drawing.Size(78, 13);
            this.labelPhoneNumber.TabIndex = 3;
            this.labelPhoneNumber.Text = "&Phone Number";
            // 
            // textBoxPhoneNumber
            // 
            this.textBoxPhoneNumber.Location = new System.Drawing.Point(94, 45);
            this.textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            this.textBoxPhoneNumber.Size = new System.Drawing.Size(150, 20);
            this.textBoxPhoneNumber.TabIndex = 4;
            this.textBoxPhoneNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPhoneNumber_KeyPress);
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(53, 75);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(32, 13);
            this.labelEmail.TabIndex = 3;
            this.labelEmail.Text = "&Email";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(94, 71);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(150, 20);
            this.textBoxEmail.TabIndex = 4;
            this.textBoxEmail.TextChanged += new System.EventHandler(this.textBoxEmail_TextChanged);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(50, 22);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(35, 13);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "&Name";
            // 
            // textBoxCustomerName
            // 
            this.textBoxCustomerName.Location = new System.Drawing.Point(94, 19);
            this.textBoxCustomerName.Name = "textBoxCustomerName";
            this.textBoxCustomerName.Size = new System.Drawing.Size(150, 20);
            this.textBoxCustomerName.TabIndex = 4;
            // 
            // labelCity
            // 
            this.labelCity.AutoSize = true;
            this.labelCity.Location = new System.Drawing.Point(61, 128);
            this.labelCity.Name = "labelCity";
            this.labelCity.Size = new System.Drawing.Size(24, 13);
            this.labelCity.TabIndex = 3;
            this.labelCity.Text = "&City";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(94, 125);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(150, 20);
            this.textBoxAddress.TabIndex = 6;
            // 
            // groupBoxCustomerDetails
            // 
            this.groupBoxCustomerDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCustomerDetails.Controls.Add(this.comboBoxCountry);
            this.groupBoxCustomerDetails.Controls.Add(this.labelCountry);
            this.groupBoxCustomerDetails.Controls.Add(this.textBoxCustomerName);
            this.groupBoxCustomerDetails.Controls.Add(this.textBoxAddress);
            this.groupBoxCustomerDetails.Controls.Add(this.labelPhoneNumber);
            this.groupBoxCustomerDetails.Controls.Add(this.labelCity);
            this.groupBoxCustomerDetails.Controls.Add(this.textBoxPhoneNumber);
            this.groupBoxCustomerDetails.Controls.Add(this.labelEmail);
            this.groupBoxCustomerDetails.Controls.Add(this.labelName);
            this.groupBoxCustomerDetails.Controls.Add(this.textBoxEmail);
            this.groupBoxCustomerDetails.Location = new System.Drawing.Point(317, 55);
            this.groupBoxCustomerDetails.Name = "groupBoxCustomerDetails";
            this.groupBoxCustomerDetails.Size = new System.Drawing.Size(250, 154);
            this.groupBoxCustomerDetails.TabIndex = 7;
            this.groupBoxCustomerDetails.TabStop = false;
            this.groupBoxCustomerDetails.Text = "Customer Details";
            // 
            // comboBoxCountry
            // 
            this.comboBoxCountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxCountry.FormattingEnabled = true;
            this.comboBoxCountry.Location = new System.Drawing.Point(94, 98);
            this.comboBoxCountry.Name = "comboBoxCountry";
            this.comboBoxCountry.Size = new System.Drawing.Size(150, 21);
            this.comboBoxCountry.TabIndex = 5;
            // 
            // labelCountry
            // 
            this.labelCountry.AutoSize = true;
            this.labelCountry.Location = new System.Drawing.Point(42, 101);
            this.labelCountry.Name = "labelCountry";
            this.labelCountry.Size = new System.Drawing.Size(43, 13);
            this.labelCountry.TabIndex = 6;
            this.labelCountry.Text = "Country";
            // 
            // comboBoxWarrenties
            // 
            this.comboBoxWarrenties.FormattingEnabled = true;
            this.comboBoxWarrenties.Location = new System.Drawing.Point(6, 19);
            this.comboBoxWarrenties.Name = "comboBoxWarrenties";
            this.comboBoxWarrenties.Size = new System.Drawing.Size(329, 21);
            this.comboBoxWarrenties.TabIndex = 8;
            this.comboBoxWarrenties.SelectedIndexChanged += new System.EventHandler(this.comboBoxWarrenties_SelectedIndexChanged);
            // 
            // groupBoxWarrentySlip
            // 
            this.groupBoxWarrentySlip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxWarrentySlip.BackColor = System.Drawing.Color.White;
            this.groupBoxWarrentySlip.Controls.Add(this.buttonAddSerial);
            this.groupBoxWarrentySlip.Controls.Add(this.buttonRemove);
            this.groupBoxWarrentySlip.Controls.Add(this.richTextBoxWarretySlip);
            this.groupBoxWarrentySlip.Controls.Add(this.comboBoxWarrenties);
            this.groupBoxWarrentySlip.Location = new System.Drawing.Point(573, 29);
            this.groupBoxWarrentySlip.Name = "groupBoxWarrentySlip";
            this.groupBoxWarrentySlip.Size = new System.Drawing.Size(341, 480);
            this.groupBoxWarrentySlip.TabIndex = 9;
            this.groupBoxWarrentySlip.TabStop = false;
            this.groupBoxWarrentySlip.Text = "Warranty Slip";
            // 
            // buttonAddSerial
            // 
            this.buttonAddSerial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.buttonAddSerial.Location = new System.Drawing.Point(189, 416);
            this.buttonAddSerial.Name = "buttonAddSerial";
            this.buttonAddSerial.Size = new System.Drawing.Size(146, 56);
            this.buttonAddSerial.TabIndex = 11;
            this.buttonAddSerial.Text = "Add Serial";
            this.buttonAddSerial.UseVisualStyleBackColor = true;
            this.buttonAddSerial.Click += new System.EventHandler(this.buttonAddSerial_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRemove.Location = new System.Drawing.Point(6, 416);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(177, 56);
            this.buttonRemove.TabIndex = 10;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // richTextBoxWarretySlip
            // 
            this.richTextBoxWarretySlip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxWarretySlip.BackColor = System.Drawing.Color.White;
            this.richTextBoxWarretySlip.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxWarretySlip.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxWarretySlip.Location = new System.Drawing.Point(6, 46);
            this.richTextBoxWarretySlip.Name = "richTextBoxWarretySlip";
            this.richTextBoxWarretySlip.ReadOnly = true;
            this.richTextBoxWarretySlip.Size = new System.Drawing.Size(329, 364);
            this.richTextBoxWarretySlip.TabIndex = 9;
            this.richTextBoxWarretySlip.Text = " ";
            // 
            // groupBoxReciept
            // 
            this.groupBoxReciept.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxReciept.Controls.Add(this.addWarrentyButton1);
            this.groupBoxReciept.Controls.Add(this.dataGridViewRecieptItems);
            this.groupBoxReciept.Controls.Add(this.textBoxRecieptId);
            this.groupBoxReciept.Controls.Add(this.textBoxItem);
            this.groupBoxReciept.Controls.Add(this.labelItem);
            this.groupBoxReciept.Location = new System.Drawing.Point(8, 12);
            this.groupBoxReciept.Name = "groupBoxReciept";
            this.groupBoxReciept.Size = new System.Drawing.Size(300, 497);
            this.groupBoxReciept.TabIndex = 10;
            this.groupBoxReciept.TabStop = false;
            this.groupBoxReciept.Text = "Receipt";
            // 
            // addWarrentyButton1
            // 
            this.addWarrentyButton1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addWarrentyButton1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.addWarrentyButton1.Enabled = false;
            this.addWarrentyButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addWarrentyButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addWarrentyButton1.ForeColor = System.Drawing.Color.White;
            this.addWarrentyButton1.Item = null;
            this.addWarrentyButton1.Location = new System.Drawing.Point(6, 432);
            this.addWarrentyButton1.Name = "addWarrentyButton1";
            this.addWarrentyButton1.Size = new System.Drawing.Size(288, 58);
            this.addWarrentyButton1.TabIndex = 10;
            this.addWarrentyButton1.Text = "Add Warranty";
            this.addWarrentyButton1.UseVisualStyleBackColor = false;
            this.addWarrentyButton1.Click += new System.EventHandler(this.addWarrentyButton1_Click);
            // 
            // dataGridViewRecieptItems
            // 
            this.dataGridViewRecieptItems.AllowUserToAddRows = false;
            this.dataGridViewRecieptItems.AllowUserToDeleteRows = false;
            this.dataGridViewRecieptItems.AllowUserToResizeColumns = false;
            this.dataGridViewRecieptItems.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewRecieptItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewRecieptItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewRecieptItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewRecieptItems.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewRecieptItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRecieptItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewRecieptItems.ColumnHeadersHeight = 30;
            this.dataGridViewRecieptItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemId,
            this.Description,
            this.UnitSalePrice,
            this.LineNumber,
            this.NetAmount,
            this.Quantity,
            this.Barcode});
            this.dataGridViewRecieptItems.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewRecieptItems.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewRecieptItems.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewRecieptItems.Location = new System.Drawing.Point(6, 43);
            this.dataGridViewRecieptItems.MultiSelect = false;
            this.dataGridViewRecieptItems.Name = "dataGridViewRecieptItems";
            this.dataGridViewRecieptItems.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRecieptItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewRecieptItems.RowHeadersVisible = false;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(5);
            this.dataGridViewRecieptItems.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewRecieptItems.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataGridViewRecieptItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRecieptItems.Size = new System.Drawing.Size(288, 383);
            this.dataGridViewRecieptItems.TabIndex = 11;
            this.dataGridViewRecieptItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRecieptItems_CellClick);
            // 
            // ItemId
            // 
            this.ItemId.DataPropertyName = "ItemId";
            this.ItemId.HeaderText = "Item Code";
            this.ItemId.Name = "ItemId";
            this.ItemId.ReadOnly = true;
            this.ItemId.Width = 74;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // UnitSalePrice
            // 
            this.UnitSalePrice.DataPropertyName = "UnitSalePrice";
            this.UnitSalePrice.HeaderText = "Unit Retail Price";
            this.UnitSalePrice.Name = "UnitSalePrice";
            this.UnitSalePrice.ReadOnly = true;
            this.UnitSalePrice.Visible = false;
            this.UnitSalePrice.Width = 99;
            // 
            // LineNumber
            // 
            this.LineNumber.DataPropertyName = "LineNumber";
            this.LineNumber.HeaderText = "LineNumber";
            this.LineNumber.Name = "LineNumber";
            this.LineNumber.ReadOnly = true;
            this.LineNumber.Visible = false;
            this.LineNumber.Width = 89;
            // 
            // NetAmount
            // 
            this.NetAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.NetAmount.DataPropertyName = "NetAmount";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "0.00";
            dataGridViewCellStyle3.NullValue = null;
            this.NetAmount.DefaultCellStyle = dataGridViewCellStyle3;
            this.NetAmount.HeaderText = "Net Amount";
            this.NetAmount.Name = "NetAmount";
            this.NetAmount.ReadOnly = true;
            this.NetAmount.Width = 81;
            // 
            // Quantity
            // 
            this.Quantity.DataPropertyName = "Quantity";
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            this.Quantity.ReadOnly = true;
            this.Quantity.Width = 71;
            // 
            // Barcode
            // 
            this.Barcode.DataPropertyName = "Barcode";
            this.Barcode.HeaderText = "Barcode";
            this.Barcode.Name = "Barcode";
            this.Barcode.ReadOnly = true;
            this.Barcode.Visible = false;
            this.Barcode.Width = 72;
            // 
            // textBoxRecieptId
            // 
            this.textBoxRecieptId.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxRecieptId.ForeColor = System.Drawing.Color.DarkRed;
            this.textBoxRecieptId.Location = new System.Drawing.Point(6, 21);
            this.textBoxRecieptId.Name = "textBoxRecieptId";
            this.textBoxRecieptId.ReadOnly = true;
            this.textBoxRecieptId.Size = new System.Drawing.Size(102, 13);
            this.textBoxRecieptId.TabIndex = 8;
            // 
            // textBoxItem
            // 
            this.textBoxItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxItem.Location = new System.Drawing.Point(147, 17);
            this.textBoxItem.Name = "textBoxItem";
            this.textBoxItem.Size = new System.Drawing.Size(147, 20);
            this.textBoxItem.TabIndex = 1;
            this.textBoxItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxItem_KeyPress);
            // 
            // labelItem
            // 
            this.labelItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelItem.AutoSize = true;
            this.labelItem.Location = new System.Drawing.Point(114, 21);
            this.labelItem.Name = "labelItem";
            this.labelItem.Size = new System.Drawing.Size(27, 13);
            this.labelItem.TabIndex = 0;
            this.labelItem.Text = "&Item";
            // 
            // buttonPay
            // 
            this.buttonPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPay.BackColor = System.Drawing.Color.YellowGreen;
            this.buttonPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPay.ForeColor = System.Drawing.Color.White;
            this.buttonPay.Location = new System.Drawing.Point(317, 465);
            this.buttonPay.Name = "buttonPay";
            this.buttonPay.Size = new System.Drawing.Size(250, 44);
            this.buttonPay.TabIndex = 11;
            this.buttonPay.Text = "Tender";
            this.buttonPay.UseVisualStyleBackColor = false;
            this.buttonPay.Click += new System.EventHandler(this.buttonPay_Click);
            // 
            // groupBoxPriceCheck
            // 
            this.groupBoxPriceCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPriceCheck.Controls.Add(this.buttonWarrentyPriceCheck);
            this.groupBoxPriceCheck.Controls.Add(this.textBoxItemSearch);
            this.groupBoxPriceCheck.Location = new System.Drawing.Point(314, 215);
            this.groupBoxPriceCheck.Name = "groupBoxPriceCheck";
            this.groupBoxPriceCheck.Size = new System.Drawing.Size(253, 100);
            this.groupBoxPriceCheck.TabIndex = 12;
            this.groupBoxPriceCheck.TabStop = false;
            this.groupBoxPriceCheck.Text = "Price Check";
            // 
            // buttonWarrentyPriceCheck
            // 
            this.buttonWarrentyPriceCheck.Location = new System.Drawing.Point(6, 49);
            this.buttonWarrentyPriceCheck.Name = "buttonWarrentyPriceCheck";
            this.buttonWarrentyPriceCheck.Size = new System.Drawing.Size(241, 45);
            this.buttonWarrentyPriceCheck.TabIndex = 1;
            this.buttonWarrentyPriceCheck.Text = "Warranty &Price Check";
            this.buttonWarrentyPriceCheck.UseVisualStyleBackColor = true;
            this.buttonWarrentyPriceCheck.Click += new System.EventHandler(this.buttonWarrentyPriceCheck_Click);
            // 
            // textBoxItemSearch
            // 
            this.textBoxItemSearch.Location = new System.Drawing.Point(6, 23);
            this.textBoxItemSearch.Name = "textBoxItemSearch";
            this.textBoxItemSearch.Size = new System.Drawing.Size(241, 20);
            this.textBoxItemSearch.TabIndex = 0;
            this.textBoxItemSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxItemSearch_KeyPress);
            // 
            // buttonJournel
            // 
            this.buttonJournel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonJournel.Location = new System.Drawing.Point(320, 322);
            this.buttonJournel.Name = "buttonJournel";
            this.buttonJournel.Size = new System.Drawing.Size(241, 41);
            this.buttonJournel.TabIndex = 13;
            this.buttonJournel.Text = "&Journal";
            this.buttonJournel.UseVisualStyleBackColor = true;
            this.buttonJournel.Click += new System.EventHandler(this.buttonJournel_Click);
            // 
            // linkLabelSettings
            // 
            this.linkLabelSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelSettings.AutoSize = true;
            this.linkLabelSettings.Location = new System.Drawing.Point(863, 9);
            this.linkLabelSettings.Name = "linkLabelSettings";
            this.linkLabelSettings.Size = new System.Drawing.Size(45, 13);
            this.linkLabelSettings.TabIndex = 14;
            this.linkLabelSettings.TabStop = true;
            this.linkLabelSettings.Text = "Settings";
            this.linkLabelSettings.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelSettings_LinkClicked);
            // 
            // statusStripExtendedWarranty
            // 
            this.statusStripExtendedWarranty.Location = new System.Drawing.Point(0, 512);
            this.statusStripExtendedWarranty.Name = "statusStripExtendedWarranty";
            this.statusStripExtendedWarranty.Size = new System.Drawing.Size(921, 22);
            this.statusStripExtendedWarranty.TabIndex = 15;
            this.statusStripExtendedWarranty.Text = "statusStrip1";
            // 
            // toolStripStatusLabelLocation
            // 
            this.toolStripStatusLabelLocation.Name = "toolStripStatusLabelLocation";
            this.toolStripStatusLabelLocation.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabelLocation.Text = "Location: ";
            // 
            // toolStripButtonCustomerDetails
            // 
            this.toolStripButtonCustomerDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCustomerDetails.Image = global::LSExtendedWarrenty.Properties.Resources.customer_png_32X32;
            this.toolStripButtonCustomerDetails.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCustomerDetails.Name = "toolStripButtonCustomerDetails";
            this.toolStripButtonCustomerDetails.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCustomerDetails.Text = "Customer";
            // 
            // toolStripButtonSettings
            // 
            this.toolStripButtonSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSettings.Image = global::LSExtendedWarrenty.Properties.Resources.settings_png_32X32;
            this.toolStripButtonSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSettings.Name = "toolStripButtonSettings";
            this.toolStripButtonSettings.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSettings.Text = "Settings";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // customerFormToolStripMenuItem
            // 
            this.customerFormToolStripMenuItem.Image = global::LSExtendedWarrenty.Properties.Resources.customer_png_32X32;
            this.customerFormToolStripMenuItem.Name = "customerFormToolStripMenuItem";
            this.customerFormToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.customerFormToolStripMenuItem.Text = "Customer Form";
            this.customerFormToolStripMenuItem.Click += new System.EventHandler(this.customerFormToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Image = global::LSExtendedWarrenty.Properties.Resources.settings_png_32X32;
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // buttonCustmerForm
            // 
            this.buttonCustmerForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCustmerForm.Image = global::LSExtendedWarrenty.Properties.Resources.customer_png_32X32;
            this.buttonCustmerForm.Location = new System.Drawing.Point(317, 410);
            this.buttonCustmerForm.Name = "buttonCustmerForm";
            this.buttonCustmerForm.Size = new System.Drawing.Size(244, 49);
            this.buttonCustmerForm.TabIndex = 16;
            this.buttonCustmerForm.Text = "Custmer Form";
            this.buttonCustmerForm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.buttonCustmerForm.UseVisualStyleBackColor = true;
            this.buttonCustmerForm.Click += new System.EventHandler(this.buttonCustmerForm_Click);
            // 
            // buttonVATReceipt
            // 
            this.buttonVATReceipt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonVATReceipt.Location = new System.Drawing.Point(320, 370);
            this.buttonVATReceipt.Name = "buttonVATReceipt";
            this.buttonVATReceipt.Size = new System.Drawing.Size(241, 34);
            this.buttonVATReceipt.TabIndex = 17;
            this.buttonVATReceipt.Text = "VAT Receipt";
            this.buttonVATReceipt.UseVisualStyleBackColor = true;
            this.buttonVATReceipt.Click += new System.EventHandler(this.buttonVATReceipt_Click);
            // 
            // FormExtendedWarrenty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 534);
            this.Controls.Add(this.buttonVATReceipt);
            this.Controls.Add(this.buttonCustmerForm);
            this.Controls.Add(this.statusStripExtendedWarranty);
            this.Controls.Add(this.linkLabelSettings);
            this.Controls.Add(this.buttonJournel);
            this.Controls.Add(this.groupBoxPriceCheck);
            this.Controls.Add(this.buttonPay);
            this.Controls.Add(this.groupBoxReciept);
            this.Controls.Add(this.groupBoxWarrentySlip);
            this.Controls.Add(this.groupBoxCustomerDetails);
            this.Controls.Add(this.textBoxCashMemo);
            this.Controls.Add(this.labelCashMemo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormExtendedWarrenty";
            this.Text = "Extended Warranty";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormExtendedWarrenty_Load);
            this.groupBoxCustomerDetails.ResumeLayout(false);
            this.groupBoxCustomerDetails.PerformLayout();
            this.groupBoxWarrentySlip.ResumeLayout(false);
            this.groupBoxReciept.ResumeLayout(false);
            this.groupBoxReciept.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecieptItems)).EndInit();
            this.groupBoxPriceCheck.ResumeLayout(false);
            this.groupBoxPriceCheck.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCashMemo;
        private System.Windows.Forms.TextBox textBoxCashMemo;
        private System.Windows.Forms.Label labelPhoneNumber;
        private System.Windows.Forms.TextBox textBoxPhoneNumber;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxCustomerName;
        private System.Windows.Forms.Label labelCity;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.GroupBox groupBoxCustomerDetails;
        private System.Windows.Forms.ComboBox comboBoxWarrenties;
        private System.Windows.Forms.GroupBox groupBoxWarrentySlip;
        private System.Windows.Forms.GroupBox groupBoxReciept;
        private System.Windows.Forms.TextBox textBoxRecieptId;
        private System.Windows.Forms.DataGridView dataGridViewRecieptItems;
        private System.Windows.Forms.Label labelItem;
        private System.Windows.Forms.TextBox textBoxItem;
        private AppBase.Controls.AddWarrentyButton addWarrentyButton1;
        private System.Windows.Forms.RichTextBox richTextBoxWarretySlip;
        private System.Windows.Forms.Button buttonPay;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonAddSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitSalePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Barcode;
        private System.Windows.Forms.ComboBox comboBoxCountry;
        private System.Windows.Forms.Label labelCountry;
        private System.Windows.Forms.GroupBox groupBoxPriceCheck;
        private System.Windows.Forms.Button buttonWarrentyPriceCheck;
        private System.Windows.Forms.TextBox textBoxItemSearch;
        private System.Windows.Forms.Button buttonJournel;
        private System.Windows.Forms.LinkLabel linkLabelSettings;
        private System.Windows.Forms.StatusStrip statusStripExtendedWarranty;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelLocation;
        private System.Windows.Forms.ToolStripButton toolStripButtonCustomerDetails;
        private System.Windows.Forms.ToolStripButton toolStripButtonSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem customerFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Button buttonCustmerForm;
        private System.Windows.Forms.Button buttonVATReceipt;
    }
}

