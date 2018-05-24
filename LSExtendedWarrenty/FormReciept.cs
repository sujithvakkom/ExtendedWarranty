using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using LSExtendedWarrenty.AppBase;

namespace LSExtendedWarrenty
{
    public partial class FormReciept : Form
    {
        ReportViewer Viewer { get; set; }
        public FormReciept()
        {
            InitializeComponent();
        }

        private void FormReciept_Load(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.reportViewerWarrentySlip.RefreshReport();
            this.Cursor = Cursors.Default;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public LocalReport _Report;
        public LocalReport Report
        {
            get { return _Report; }
            set
            {
                _Report = value;
            }
        }

        public ReportParameter[] _ReportParameter;
        public ReportParameter[] ReportParameter
        {
            get { return _ReportParameter; }
            set
            {
                _ReportParameter = value;
                this.reportViewerWarrentySlip.LocalReport.SetParameters(_ReportParameter);
                reportViewerWarrentySlip.RefreshReport();
            }
        }
        public ReportDataSource _DataSource;
        public ReportDataSource DataSource
        {
            get { return _DataSource; }
            set
            {
                _DataSource = value;
                WarrentyItemBindingSource.DataSource = _DataSource;
                this.reportViewerWarrentySlip.LocalReport.DataSources.Clear();
                this.reportViewerWarrentySlip.LocalReport.DataSources.Add(_DataSource);
                
                reportViewerWarrentySlip.RefreshReport();
            }
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this,
                "Do you want to Print\n"
                + ((LSExtendedWarrenty.AppBase.Warranty)DataSource.Value)[0].WarrentyNumber
                + "\nagain?", "Confirm Print",
                MessageBoxButtons.YesNo);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                const string ReportPath = @"LSExtendedWarrenty.WarrentySlip.rdlc";

                String PrinterName = SettingsProvider.GetDefaultPrinter();
                using (ReportPriner Printer = new ReportPriner(ReportPath, DataSource, ReportParameter))
                {
                    Printer.Run(PrinterName);
                }
            }
            this.Close();
        }
    }
}