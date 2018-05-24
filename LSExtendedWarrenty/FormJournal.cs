using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LSExtendedWarrenty.AppBase;
using LSExtendedWarrenty.AppBase.DataHelper;

namespace LSExtendedWarrenty
{
    public partial class FormJournal : Form
    {


        private Warranty _Warrenties;
        internal Warranty Warranties
        {
            get
            {
                return _Warrenties;
            }
            set
            {
                _Warrenties = value;
                //this.dataGridViewJournel.AutoGenerateColumns = false;
                //this.dataGridViewJournel.DataSource = Warranties;
            }
        }
        public FormJournal()
        {
            InitializeComponent();
            /*
            this.Warranties = DataProvider.GetWarrenties(0, 10, null, null, null, null, null);
            */
            this.dataGridViewJournel.AutoGenerateColumns = false;
            this.dataGridViewJournel.DataSource =
            DataProvider.DownloadWarrenties(0, 10,
                 null, null, null, null, null);
        }

        private void buttonUpdateHQ_Click(object sender, EventArgs e)
        {

            using (HQConnection x = new HQConnection())
            {
                try
                {
                    HQConnection.UpdateWarrenties();
                    MessageBox.Show(this, "Warranties Successfully Updated", "Success");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "Error Occurred While Updating. "
                        + Environment.NewLine
                        + "Please Check the Error Message." + Environment.NewLine
                        + "Please take a screen shot and send to System Administrator" + Environment.NewLine + Environment.NewLine
                        + ex.Message, "Error Occurred");
                }
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            int Selection = this.dataGridViewJournel.CurrentCell.RowIndex;
            Warranties = DataProvider.GetWarrenties(0, 10, null,
                this.dataGridViewJournel.CurrentRow.Cells["WarrentyNumber"].Value.ToString(),
                null, null, null);
            Warranty TempWarrenties = (Warranty)Warranties.Clone();

            var errorMessage = this.dataGridViewJournel.CurrentRow.Cells["ErrorMessage"].Value.ToString();

            if (errorMessage.Length > 0)
            {
                DialogResult result =
                MessageBox.Show(this, "Warranty Slip Has Errors." 
                + Environment.NewLine + errorMessage+
                Environment.NewLine +
                "Still Need the Warranty Slip.", "Cannot Generate",
               MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    result = new Authorize().ShowDialog(this);
                }
                if (result != DialogResult.Yes) return;
            }
            #region PrintExtended
            TempWarrenties.Clear();
            TempWarrenties.Add(Warranties[0]);
            TempWarrenties.Reciept = Warranties[0].Reciept;

            const string ReportPath = @"LSExtendedWarrenty.WarrentySlip.rdlc";
            const string DataSourceName = @"WarrentyItem";
            String PrinterName = SettingsProvider.GetDefaultPrinter();
            try
            {
                Microsoft.Reporting.WinForms.ReportParameter[] ReportParameter =
                    new Microsoft.Reporting.WinForms.ReportParameter[] { 
                                new Microsoft.Reporting.WinForms.ReportParameter(@"PrintDateTime", DateTime.Now.ToString()),
                                new Microsoft.Reporting.WinForms.ReportParameter(@"IssueDateTime", TempWarrenties[0].IssuedDate.ToString()),
                                new Microsoft.Reporting.WinForms.ReportParameter(@"CashMemo",TempWarrenties[0].Reciept.RecieptID),
                                new Microsoft.Reporting.WinForms.ReportParameter(@"CashMemoDate",TempWarrenties[0].Reciept.TransactionDate.ToString()),
                                new Microsoft.Reporting.WinForms.ReportParameter(@"CustomerName",TempWarrenties[0].CustomerName),
                                new Microsoft.Reporting.WinForms.ReportParameter(@"CustomerPhone",TempWarrenties[0].Phone),
                                new Microsoft.Reporting.WinForms.ReportParameter(@"CustomerEmail",TempWarrenties[0].Email),
                                new Microsoft.Reporting.WinForms.ReportParameter(@"StaffCode",TempWarrenties[0].Reciept.Staff),
                                new Microsoft.Reporting.WinForms.ReportParameter(@"StaffName",TempWarrenties[0].Reciept.StaffName)
                            };


                Microsoft.Reporting.WinForms.ReportDataSource DataSource = new Microsoft.Reporting.WinForms.ReportDataSource
                    (DataSourceName, TempWarrenties);
                using (ReportPriner Printer = new ReportPriner(ReportPath, DataSource, ReportParameter))
                {
                    this.Hide();
                    this.Cursor = Cursors.WaitCursor;
                    FormReciept window = new FormReciept();
                    window.Report = Printer.LocalReport;
                    window.ReportParameter = ReportParameter;
                    window.DataSource = DataSource;
                    this.Cursor = Cursors.Default;
                    window.ShowDialog(this);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error Processing the Warranty Slip. "
                + Environment.NewLine
                + "Please Check the Error Message." + Environment.NewLine
                + "Please take a screen shot and send to System Administrator" + Environment.NewLine + Environment.NewLine
                + ex.Message, "Error Occurred");
            }
            #endregion
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonClearFilter_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.textBoxLocationCode.Text = "";
            this.textBoxWarrenty.Text = "";
            this.textBoxReciept.Text = "";
            this.textBoxEmail.Text = "";
            this.checkBoxHasErrors.CheckState = CheckState.Indeterminate;
            /*
            this.Warranties = DataProvider.GetWarrenties(0, 10, null, null, null, null, null);
            */
            this.dataGridViewJournel.AutoGenerateColumns = false;
            this.dataGridViewJournel.DataSource =
            DataProvider.DownloadWarrenties(0, 10,
                 null, null, null, null, null);

            this.Cursor = Cursors.Default;
        }

        private void buttonApplyFilter_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            String LocationFilter = (this.textBoxLocationCode.Text.Trim().Length == 0) ? null : this.textBoxLocationCode.Text.Trim();
            String WarrentyFilter = (this.textBoxWarrenty.Text.Trim().Length == 0) ? null : this.textBoxWarrenty.Text.Trim();
            String RecieptFilter = (this.textBoxReciept.Text.Trim().Length == 0) ? null : this.textBoxReciept.Text.Trim();
            String EmailFilter = (this.textBoxEmail.Text.Trim().Length == 0) ? null : this.textBoxEmail.Text.Trim();
            String HassErrorsFilter = (this.checkBoxHasErrors.CheckState == CheckState.Indeterminate) ? null : this.checkBoxHasErrors.CheckState.ToString();
            /*
            this.Warranties = DataProvider.GetWarrenties(0, 10,
                LocationFilter,
                WarrentyFilter,
                RecieptFilter,
                EmailFilter,
                HassErrorsFilter);
            */
            this.dataGridViewJournel.AutoGenerateColumns = false;
            this.dataGridViewJournel.DataSource = 
            DataProvider.DownloadWarrenties(0, 10,
                LocationFilter,
                WarrentyFilter,
                RecieptFilter,
                EmailFilter,
                HassErrorsFilter);

            this.Cursor = Cursors.Default;
        }

        private void buttonDownLoadCSV_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;
            String LocationFilter = (this.textBoxLocationCode.Text.Trim().Length == 0) ? null : this.textBoxLocationCode.Text.Trim();
            String WarrentyFilter = (this.textBoxWarrenty.Text.Trim().Length == 0) ? null : this.textBoxWarrenty.Text.Trim();
            String RecieptFilter = (this.textBoxReciept.Text.Trim().Length == 0) ? null : this.textBoxReciept.Text.Trim();
            String EmailFilter = (this.textBoxEmail.Text.Trim().Length == 0) ? null : this.textBoxEmail.Text.Trim();
            String HassErrorsFilter = (this.checkBoxHasErrors.CheckState == CheckState.Indeterminate) ? null : this.checkBoxHasErrors.CheckState.ToString();

            DataTable DownloadWarranties = DataProvider.DownloadWarrenties(0, 10,
                LocationFilter,
                WarrentyFilter,
                RecieptFilter,
                EmailFilter,
                HassErrorsFilter);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel CSV | *.csv";
            dialog.DefaultExt = "csv";

            if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                if (dialog.CheckFileExists)
                {
                    if (MessageBox.Show("Do You Want to Overwrite the File"
                        + Environment.NewLine + dialog.FileName + "?"
                        , "File Overwrite", MessageBoxButtons.YesNo) ==
                        System.Windows.Forms.DialogResult.Yes)
                    {
                        AppBase.ExcelExport.ExcelCSVExport.ExportTableXLS(DownloadWarranties, dialog.FileName, null);
                    }
                }
                else
                {
                    AppBase.ExcelExport.ExcelCSVExport.ExportTableXLS(DownloadWarranties, dialog.FileName, null);
                }
            }

            this.Cursor = Cursors.Default;
        }
    }
}
