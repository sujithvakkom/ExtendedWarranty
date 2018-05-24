using LSExtendedWarrenty.AppBase.DataHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LSExtendedWarrenty
{
    public partial class VATReceipt : Form
    {
        public VATReceipt()
        {
            InitializeComponent();
        }

        private void VATReceipt_Load(object sender, EventArgs e)
        {
            this.xx_receiptTableAdapter = new ReceiptDataSetTableAdapters.xx_receiptTableAdapter();
            this.xx_receipt_itemTableAdapter = new ReceiptDataSetTableAdapters.xx_receipt_itemTableAdapter();
            this.xx_receipt_tenderTableAdapter = new ReceiptDataSetTableAdapters.xx_receipt_tenderTableAdapter();
            this.receiptDataSet = new ReceiptDataSet();

            xx_receiptTableAdapter.Connection.ConnectionString = Connection.getConnectionString();
            xx_receipt_itemTableAdapter.Connection.ConnectionString = Connection.getConnectionString();
            xx_receipt_tenderTableAdapter.Connection.ConnectionString = Connection.getConnectionString();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Reporting.WinForms.ReportParameter[] ReportParameter =
                    new Microsoft.Reporting.WinForms.ReportParameter[] {
                                new Microsoft.Reporting.WinForms.ReportParameter(@"receipt",this.textBoxReceipt.Text.Trim() )
                                };
                this.reportViewer1.LocalReport.SetParameters(ReportParameter);
                xx_receiptTableAdapter.Fill(receiptDataSet.xx_receipt, this.textBoxReceipt.Text.Trim());
                xx_receipt_itemTableAdapter.Fill(receiptDataSet.xx_receipt_item, this.textBoxReceipt.Text.Trim());
                xx_receipt_tenderTableAdapter.Fill(receiptDataSet.xx_receipt_tender, this.textBoxReceipt.Text.Trim());
                reportViewer1.DataBindings.Clear();

                //reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("LSPOSDataSet", data.AsEnumerable()));

                reportViewer1.LocalReport.DataSources.Clear();

                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ReceiptDataSet", (DataTable)receiptDataSet.xx_receipt));

                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ReceiptItemDataSet", (DataTable)receiptDataSet.xx_receipt_item));

                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("ReceiptTenderDataSet", (DataTable)receiptDataSet.xx_receipt_tender));


                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
