namespace LSExtendedWarrenty
{
    partial class VATReceipt
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.xxreceiptBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.xxreceiptitemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.xxreceipttenderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxReceipt = new System.Windows.Forms.TextBox();
            this.labelReceipt = new System.Windows.Forms.Label();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.xxreceiptBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xxreceiptitemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xxreceipttenderBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // xxreceiptBindingSource
            // 
            this.xxreceiptBindingSource.DataMember = "xx_receipt";
            // 
            // xxreceiptitemBindingSource
            // 
            this.xxreceiptitemBindingSource.DataMember = "xx_receipt_item";
            // 
            // xxreceipttenderBindingSource
            // 
            this.xxreceipttenderBindingSource.DataMember = "xx_receipt_tender";
            // 
            // textBoxReceipt
            // 
            this.textBoxReceipt.Location = new System.Drawing.Point(62, 22);
            this.textBoxReceipt.Name = "textBoxReceipt";
            this.textBoxReceipt.Size = new System.Drawing.Size(100, 20);
            this.textBoxReceipt.TabIndex = 0;
            // 
            // labelReceipt
            // 
            this.labelReceipt.AutoSize = true;
            this.labelReceipt.Location = new System.Drawing.Point(12, 25);
            this.labelReceipt.Name = "labelReceipt";
            this.labelReceipt.Size = new System.Drawing.Size(44, 13);
            this.labelReceipt.TabIndex = 1;
            this.labelReceipt.Text = "Receipt";
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(168, 20);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Print";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "ReceiptDataSet";
            reportDataSource1.Value = this.xxreceiptBindingSource;
            reportDataSource2.Name = "ReceiptItemDataSet";
            reportDataSource2.Value = this.xxreceiptitemBindingSource;
            reportDataSource3.Name = "ReceiptTenderDataSet";
            reportDataSource3.Value = this.xxreceipttenderBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LSExtendedWarrenty.VATReceipt.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 49);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(708, 499);
            this.reportViewer1.TabIndex = 3;
            // 
            // VATReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 560);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.labelReceipt);
            this.Controls.Add(this.textBoxReceipt);
            this.Name = "VATReceipt";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "VAT Receipt";
            this.Load += new System.EventHandler(this.VATReceipt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xxreceiptBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xxreceiptitemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xxreceipttenderBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxReceipt;
        private System.Windows.Forms.Label labelReceipt;
        private System.Windows.Forms.Button buttonLoad;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource xxreceiptBindingSource;
        private ReceiptDataSet siteManagerDataSet3;
        private System.Windows.Forms.BindingSource xxreceiptitemBindingSource;
        private ReceiptDataSet receiptDataSet;
        private System.Windows.Forms.BindingSource xxreceipttenderBindingSource;
        private ReceiptDataSetTableAdapters.xx_receiptTableAdapter xx_receiptTableAdapter;
        private ReceiptDataSetTableAdapters.xx_receipt_itemTableAdapter xx_receipt_itemTableAdapter;
        private ReceiptDataSetTableAdapters.xx_receipt_tenderTableAdapter xx_receipt_tenderTableAdapter;
    }
}