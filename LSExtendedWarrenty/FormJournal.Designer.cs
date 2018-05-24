namespace LSExtendedWarrenty
{
    partial class FormJournal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormJournal));
            this.dataGridViewJournel = new System.Windows.Forms.DataGridView();
            this.buttonUpdateHQ = new System.Windows.Forms.Button();
            this.buttonWarrentySlip = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBoxFilters = new System.Windows.Forms.GroupBox();
            this.buttonDownLoadCSV = new System.Windows.Forms.Button();
            this.buttonClearFilter = new System.Windows.Forms.Button();
            this.buttonApplyFilter = new System.Windows.Forms.Button();
            this.checkBoxHasErrors = new System.Windows.Forms.CheckBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelCustomerEmail = new System.Windows.Forms.Label();
            this.textBoxReciept = new System.Windows.Forms.TextBox();
            this.labelReciept = new System.Windows.Forms.Label();
            this.textBoxWarrenty = new System.Windows.Forms.TextBox();
            this.labelWarrentyNumber = new System.Windows.Forms.Label();
            this.textBoxLocationCode = new System.Windows.Forms.TextBox();
            this.labelLocationCode = new System.Windows.Forms.Label();
            this.WarrentyNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reciept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfYears = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJournel)).BeginInit();
            this.groupBoxFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewJournel
            // 
            this.dataGridViewJournel.AllowUserToAddRows = false;
            this.dataGridViewJournel.AllowUserToDeleteRows = false;
            this.dataGridViewJournel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewJournel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewJournel.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewJournel.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewJournel.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewJournel.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewJournel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewJournel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WarrentyNumber,
            this.Reciept,
            this.ItemId,
            this.Description,
            this.CustomerName,
            this.NumberOfYears,
            this.ErrorMessage});
            this.dataGridViewJournel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridViewJournel.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewJournel.Location = new System.Drawing.Point(12, 89);
            this.dataGridViewJournel.Name = "dataGridViewJournel";
            this.dataGridViewJournel.ReadOnly = true;
            this.dataGridViewJournel.RowHeadersVisible = false;
            this.dataGridViewJournel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewJournel.Size = new System.Drawing.Size(689, 325);
            this.dataGridViewJournel.TabIndex = 0;
            // 
            // buttonUpdateHQ
            // 
            this.buttonUpdateHQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdateHQ.Location = new System.Drawing.Point(626, 421);
            this.buttonUpdateHQ.Name = "buttonUpdateHQ";
            this.buttonUpdateHQ.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdateHQ.TabIndex = 1;
            this.buttonUpdateHQ.Text = "Update HQ";
            this.buttonUpdateHQ.UseVisualStyleBackColor = true;
            this.buttonUpdateHQ.Click += new System.EventHandler(this.buttonUpdateHQ_Click);
            // 
            // buttonWarrentySlip
            // 
            this.buttonWarrentySlip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonWarrentySlip.Location = new System.Drawing.Point(526, 421);
            this.buttonWarrentySlip.Name = "buttonWarrentySlip";
            this.buttonWarrentySlip.Size = new System.Drawing.Size(94, 23);
            this.buttonWarrentySlip.TabIndex = 2;
            this.buttonWarrentySlip.Text = "Warranty Slip";
            this.buttonWarrentySlip.UseVisualStyleBackColor = true;
            this.buttonWarrentySlip.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(445, 421);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // groupBoxFilters
            // 
            this.groupBoxFilters.Controls.Add(this.buttonDownLoadCSV);
            this.groupBoxFilters.Controls.Add(this.buttonClearFilter);
            this.groupBoxFilters.Controls.Add(this.buttonApplyFilter);
            this.groupBoxFilters.Controls.Add(this.checkBoxHasErrors);
            this.groupBoxFilters.Controls.Add(this.textBoxEmail);
            this.groupBoxFilters.Controls.Add(this.labelCustomerEmail);
            this.groupBoxFilters.Controls.Add(this.textBoxReciept);
            this.groupBoxFilters.Controls.Add(this.labelReciept);
            this.groupBoxFilters.Controls.Add(this.textBoxWarrenty);
            this.groupBoxFilters.Controls.Add(this.labelWarrentyNumber);
            this.groupBoxFilters.Controls.Add(this.textBoxLocationCode);
            this.groupBoxFilters.Controls.Add(this.labelLocationCode);
            this.groupBoxFilters.Location = new System.Drawing.Point(12, 12);
            this.groupBoxFilters.Name = "groupBoxFilters";
            this.groupBoxFilters.Size = new System.Drawing.Size(689, 71);
            this.groupBoxFilters.TabIndex = 4;
            this.groupBoxFilters.TabStop = false;
            this.groupBoxFilters.Text = "Filter";
            // 
            // buttonDownLoadCSV
            // 
            this.buttonDownLoadCSV.Location = new System.Drawing.Point(6, 42);
            this.buttonDownLoadCSV.Name = "buttonDownLoadCSV";
            this.buttonDownLoadCSV.Size = new System.Drawing.Size(113, 23);
            this.buttonDownLoadCSV.TabIndex = 5;
            this.buttonDownLoadCSV.Text = "Download Report";
            this.buttonDownLoadCSV.UseVisualStyleBackColor = true;
            this.buttonDownLoadCSV.Click += new System.EventHandler(this.buttonDownLoadCSV_Click);
            // 
            // buttonClearFilter
            // 
            this.buttonClearFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearFilter.Location = new System.Drawing.Point(524, 42);
            this.buttonClearFilter.Name = "buttonClearFilter";
            this.buttonClearFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonClearFilter.TabIndex = 4;
            this.buttonClearFilter.Text = "&Clear Filter";
            this.buttonClearFilter.UseVisualStyleBackColor = true;
            this.buttonClearFilter.Click += new System.EventHandler(this.buttonClearFilter_Click);
            // 
            // buttonApplyFilter
            // 
            this.buttonApplyFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonApplyFilter.Location = new System.Drawing.Point(605, 42);
            this.buttonApplyFilter.Name = "buttonApplyFilter";
            this.buttonApplyFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonApplyFilter.TabIndex = 3;
            this.buttonApplyFilter.Text = "&Apply Filter";
            this.buttonApplyFilter.UseVisualStyleBackColor = true;
            this.buttonApplyFilter.Click += new System.EventHandler(this.buttonApplyFilter_Click);
            // 
            // checkBoxHasErrors
            // 
            this.checkBoxHasErrors.AutoSize = true;
            this.checkBoxHasErrors.Checked = true;
            this.checkBoxHasErrors.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.checkBoxHasErrors.Location = new System.Drawing.Point(581, 19);
            this.checkBoxHasErrors.Name = "checkBoxHasErrors";
            this.checkBoxHasErrors.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxHasErrors.Size = new System.Drawing.Size(75, 17);
            this.checkBoxHasErrors.TabIndex = 2;
            this.checkBoxHasErrors.Text = "Has Errors";
            this.checkBoxHasErrors.ThreeState = true;
            this.checkBoxHasErrors.UseVisualStyleBackColor = true;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(479, 17);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(100, 20);
            this.textBoxEmail.TabIndex = 1;
            // 
            // labelCustomerEmail
            // 
            this.labelCustomerEmail.AutoSize = true;
            this.labelCustomerEmail.Location = new System.Drawing.Point(400, 21);
            this.labelCustomerEmail.Name = "labelCustomerEmail";
            this.labelCustomerEmail.Size = new System.Drawing.Size(79, 13);
            this.labelCustomerEmail.TabIndex = 0;
            this.labelCustomerEmail.Text = "Customer Email";
            // 
            // textBoxReciept
            // 
            this.textBoxReciept.Location = new System.Drawing.Point(298, 17);
            this.textBoxReciept.Name = "textBoxReciept";
            this.textBoxReciept.Size = new System.Drawing.Size(100, 20);
            this.textBoxReciept.TabIndex = 1;
            // 
            // labelReciept
            // 
            this.labelReciept.AutoSize = true;
            this.labelReciept.Location = new System.Drawing.Point(254, 21);
            this.labelReciept.Name = "labelReciept";
            this.labelReciept.Size = new System.Drawing.Size(44, 13);
            this.labelReciept.TabIndex = 0;
            this.labelReciept.Text = "Receipt";
            // 
            // textBoxWarrenty
            // 
            this.textBoxWarrenty.Location = new System.Drawing.Point(152, 17);
            this.textBoxWarrenty.Name = "textBoxWarrenty";
            this.textBoxWarrenty.Size = new System.Drawing.Size(100, 20);
            this.textBoxWarrenty.TabIndex = 1;
            // 
            // labelWarrentyNumber
            // 
            this.labelWarrentyNumber.AutoSize = true;
            this.labelWarrentyNumber.Location = new System.Drawing.Point(102, 21);
            this.labelWarrentyNumber.Name = "labelWarrentyNumber";
            this.labelWarrentyNumber.Size = new System.Drawing.Size(50, 13);
            this.labelWarrentyNumber.TabIndex = 0;
            this.labelWarrentyNumber.Text = "Warranty";
            // 
            // textBoxLocationCode
            // 
            this.textBoxLocationCode.Location = new System.Drawing.Point(54, 17);
            this.textBoxLocationCode.Name = "textBoxLocationCode";
            this.textBoxLocationCode.Size = new System.Drawing.Size(46, 20);
            this.textBoxLocationCode.TabIndex = 1;
            // 
            // labelLocationCode
            // 
            this.labelLocationCode.AutoSize = true;
            this.labelLocationCode.Location = new System.Drawing.Point(6, 21);
            this.labelLocationCode.Name = "labelLocationCode";
            this.labelLocationCode.Size = new System.Drawing.Size(48, 13);
            this.labelLocationCode.TabIndex = 0;
            this.labelLocationCode.Text = "Location";
            // 
            // WarrentyNumber
            // 
            this.WarrentyNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.WarrentyNumber.DataPropertyName = "warranty_number";
            this.WarrentyNumber.FillWeight = 30F;
            this.WarrentyNumber.HeaderText = "Warranty Number";
            this.WarrentyNumber.Name = "WarrentyNumber";
            this.WarrentyNumber.ReadOnly = true;
            // 
            // Reciept
            // 
            this.Reciept.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Reciept.DataPropertyName = "cash_memo";
            this.Reciept.FillWeight = 20F;
            this.Reciept.HeaderText = "Receipt";
            this.Reciept.Name = "Reciept";
            this.Reciept.ReadOnly = true;
            // 
            // ItemId
            // 
            this.ItemId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ItemId.DataPropertyName = "item_code";
            this.ItemId.FillWeight = 20F;
            this.ItemId.HeaderText = "Item";
            this.ItemId.Name = "ItemId";
            this.ItemId.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "item_desc";
            this.Description.FillWeight = 30F;
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // CustomerName
            // 
            this.CustomerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CustomerName.DataPropertyName = "customer_name";
            this.CustomerName.FillWeight = 15F;
            this.CustomerName.HeaderText = "Customer Name";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // NumberOfYears
            // 
            this.NumberOfYears.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NumberOfYears.DataPropertyName = "warranty_years";
            this.NumberOfYears.FillWeight = 10F;
            this.NumberOfYears.HeaderText = "Years of Warranty";
            this.NumberOfYears.Name = "NumberOfYears";
            this.NumberOfYears.ReadOnly = true;
            // 
            // ErrorMessage
            // 
            this.ErrorMessage.DataPropertyName = "error_message";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.MistyRose;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Red;
            this.ErrorMessage.DefaultCellStyle = dataGridViewCellStyle2;
            this.ErrorMessage.FillWeight = 10F;
            this.ErrorMessage.HeaderText = "Error Message";
            this.ErrorMessage.Name = "ErrorMessage";
            this.ErrorMessage.ReadOnly = true;
            // 
            // FormJournal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(713, 456);
            this.Controls.Add(this.groupBoxFilters);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonWarrentySlip);
            this.Controls.Add(this.buttonUpdateHQ);
            this.Controls.Add(this.dataGridViewJournel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormJournal";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Daily Journal";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewJournel)).EndInit();
            this.groupBoxFilters.ResumeLayout(false);
            this.groupBoxFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewJournel;
        private System.Windows.Forms.Button buttonUpdateHQ;
        private System.Windows.Forms.Button buttonWarrentySlip;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.GroupBox groupBoxFilters;
        private System.Windows.Forms.Button buttonClearFilter;
        private System.Windows.Forms.Button buttonApplyFilter;
        private System.Windows.Forms.CheckBox checkBoxHasErrors;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelCustomerEmail;
        private System.Windows.Forms.TextBox textBoxReciept;
        private System.Windows.Forms.Label labelReciept;
        private System.Windows.Forms.TextBox textBoxWarrenty;
        private System.Windows.Forms.Label labelWarrentyNumber;
        private System.Windows.Forms.TextBox textBoxLocationCode;
        private System.Windows.Forms.Label labelLocationCode;
        private System.Windows.Forms.Button buttonDownLoadCSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn WarrentyNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reciept;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberOfYears;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorMessage;
    }
}