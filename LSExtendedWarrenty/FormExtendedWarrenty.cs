using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LSExtendedWarrenty.AppBase;
using System.Reflection;
using System.IO;
using System.Drawing.Printing;
using System.Text.RegularExpressions;
using LSExtendedWarrenty.AppBase.DataHelper;
using MyExtentions.Controls.MessageBoxExtentions;

namespace LSExtendedWarrenty
{
    public partial class FormExtendedWarrenty : Form
    {
        private Reciept _Reciept;
        Reciept Reciept
        {
            get { return _Reciept; }
            set
            {
                _Reciept = value;
                if (_Reciept == null)
                {
                    ClearUI();
                    this.Warranties = null;
                }
                else
                {
                    this.ShowReciept();
                }
            }
        }

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
                if (_Warrenties != null)
                {
                    _Warrenties.Reciept = this.Reciept;
                    Warranties.WarrentyItemAddedEvent += new Warranty.WarrentyItemAddedEventHandeler(Warrenties_WarrentyItemAddedEvent);
                }
                else
                {
                    ClearUI();
                }
            }
        }

        private RecieptItem _SelectedItem { get; set; }
        internal RecieptItem SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                _SelectedItem = value;
                this.addWarrentyButton1.Item = _SelectedItem;
            }
        }

        public FormExtendedWarrenty()
        {
            InitializeComponent();
            this.toolStripStatusLabelLocation.Text = "Location: "
                + SettingsProvider.GetDatabase().Replace("GS", "");
        }

        protected void ClearUI()
        {

            this.textBoxItem.Text = "";
            this.addWarrentyButton1.Item = null;
            this.textBoxCustomerName.Text = "";
            this.textBoxPhoneNumber.Text = "";
            this.textBoxEmail.Text = "";
            this.textBoxAddress.Text = "";
            this.comboBoxCountry.SelectedIndex = -1;
            try
            {
                this.comboBoxWarrenties.Items.Clear();
                this.comboBoxWarrenties.Text = "";
                buttonPay.Text = "Tender";
            }
            catch (Exception) { }
            this.richTextBoxWarretySlip.Rtf = "";
            ShowReciept();
        }

        private void textBoxCashMemo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Reciept = null;
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                this.IsBusy = true;
                Reciept = 
                    LSExtendedWarrenty.AppBase.DataHelper.DataProvider.GetCashMemo(this.textBoxCashMemo.Text, 
                    LSExtendedWarrenty.Properties.Resources.Selection
                    );
                if (Reciept == null)
                    MessageBox.Show(this, "Cash Memo Not Found.", "Not Found");
                this.IsBusy = false;
            }
        }

        private void ShowReciept()
        {
            this.IsBusy = true;
            //initRecieptGrid();
            //BindingSource source = new BindingSource();
            //source.DataSource = Reciept;
            this.dataGridViewRecieptItems.DataSource = Reciept;
            dataGridViewRecieptItems.AutoGenerateColumns = false;
            if (Reciept != null)
                this.textBoxRecieptId.Text = Reciept.RecieptID;
            else this.textBoxRecieptId.Text = "";
            this.IsBusy = false;
        }

        private void dataGridViewRecieptItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String selectedItemId = dataGridViewRecieptItems.Rows[e.RowIndex].Cells["ItemId"].Value.ToString();
                foreach (RecieptItem item in Reciept)
                    if (item.ItemId == selectedItemId)
                    {
                        this.SelectedItem = item;
                        this.textBoxItem.Text = item.ItemId;
                    }
            }
            catch (Exception) { }
        }

        private void textBoxItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.SelectedItem = null;
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (Reciept != null)
                {
                    foreach (RecieptItem item in Reciept)
                        if ((item.Barcode == this.textBoxItem.Text) || (item.ItemId == this.textBoxItem.Text))
                        {
                            this.SelectedItem = item;
                            this.textBoxItem.Text = item.ItemId;
                        }

                    if (SelectedItem == null)
                    {
                        String ItemId =
                        LSExtendedWarrenty.AppBase.DataHelper.DataProvider.GetItemId(textBoxItem.Text, Reciept.TransactionID);
                        foreach (RecieptItem item in Reciept)
                            if (item.ItemId == ItemId)
                            {
                                this.SelectedItem = item;
                                this.textBoxItem.Text = item.ItemId;
                            }
                    }
                    if (SelectedItem == null)
                        MessageBox.Show(this, "Item not found in the selected Receipt", "Item Not Found");
                }
                else
                    MessageBox.Show(this, "No Receipt selected.", "No Receipt");
            }
        }

        private void addWarrentyButton1_Click(object sender, EventArgs e)
        {
            try
            {
                WarrentyItemSelction WarrentyItemSelction = new WarrentyItemSelction();
                WarrentyItemSelction.Item = addWarrentyButton1.Item;
                var result =
                WarrentyItemSelction.ShowDialog(this);
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    if (Warranties == null)
                        Warranties = new Warranty();
                    try
                    {
                        Warranties.AddWarrenty(WarrentyItemSelction.WarrentyItem);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, "Error Occurred While Adding Warranty. "
                        + Environment.NewLine
                        + "Please Check the Error Message." + Environment.NewLine
                        + "Please take a screen shot and send to System Administrator" + Environment.NewLine + Environment.NewLine
                        + ex.Message, "Error Occurred");
                    }
                }
            }
            catch (LSExtendedWarrenty.AppBase.DataHelper.NoWarrentySettingFoundException ex)
            {
                MessageBox.Show(ex.InnerException.Message, ex.Message);
            }
        }

        void Warrenties_WarrentyItemAddedEvent()
        {
            BindingSource source = new BindingSource();
            source.DataSource = Warranties;
            this.comboBoxWarrenties.Text = "";
            this.comboBoxWarrenties.DataSource = source;
            this.comboBoxWarrenties.DisplayMember = "ItemId";
            //Tender
            var netAmount = Warranties.GetNetAmount();
            this.buttonPay.Text = "Tender ( " + netAmount + " )";
            this.comboBoxWarrenties.SelectedIndex = this.comboBoxWarrenties.Items.Count - 1;
            comboBoxWarrenties_SelectedIndexChanged(this.comboBoxWarrenties.SelectedIndex, new EventArgs());
        }

        private void comboBoxWarrenties_SelectedIndexChanged(object sender, EventArgs e)
        {
            String Slip = "";
            //Change to Control 
            //TODO
            richTextBoxWarretySlip.Rtf = Slip;
            foreach (var warranty in Warranties)
                if (warranty.ItemId == this.comboBoxWarrenties.Text)
                {
                    Slip = warranty.GetRtf(Warranties);
                    richTextBoxWarretySlip.Rtf = Slip;
                }
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            if (Warranties != null)
            {
                if (this.ValidateForPrint())
                {
                    ConfirmPayment ConfirmPayment = new ConfirmPayment();
                    var temp = this.Warranties;
                    DialogResult Result = ConfirmPayment.ShowDialog(this, ref temp);
                    this.Warranties = temp;
                    if (Result == DialogResult.OK && ConfirmPayment.IsValid == true)
                    {
                        this.IsBusy = true;
                        this.Warranties.CustomerName = this.textBoxCustomerName.Text;
                        this.Warranties.Email = this.textBoxEmail.Text;
                        this.Warranties.Phone = this.textBoxPhoneNumber.Text;
                        this.Warranties.Country = this.comboBoxCountry.Text;
                        this.Warranties.Address = this.textBoxAddress.Text;
                        bool succesCommit = false;
                        try
                        {
                            this.Warranties.Commit();
                            succesCommit = true;
                        }
                        catch (Exception ex)
                        {

                            this.Warranties.RollBack();

                            MessageBox.Show("Error Occurred While Committing Warranty. "
                        + Environment.NewLine
                        + "Please Check the Error Message." + Environment.NewLine
                        + "Please take a screen shot and send to System Administrator" + Environment.NewLine + Environment.NewLine
                        + ex.Message, "Error Occurred.");
                            succesCommit = false;
                        }
                        if (succesCommit)
                        {
                            const string ReportPath = @"LSExtendedWarrenty.WarrentySlip.rdlc";
                            const string DataSourceName = @"WarrentyItem";
                            String PrinterName = SettingsProvider.GetDefaultPrinter();
                            Microsoft.Reporting.WinForms.ReportParameter[] ReportParameter =
                                new Microsoft.Reporting.WinForms.ReportParameter[] { 
                                new Microsoft.Reporting.WinForms.ReportParameter(@"PrintDateTime", DateTime.Now.ToString()),
                                new Microsoft.Reporting.WinForms.ReportParameter(@"IssueDateTime", DateTime.Now.ToString()),
                                new Microsoft.Reporting.WinForms.ReportParameter(@"CashMemo",Warranties.Reciept.RecieptID),
                                new Microsoft.Reporting.WinForms.ReportParameter(@"CashMemoDate",Warranties.Reciept.TransactionDate.ToString()),
                                new Microsoft.Reporting.WinForms.ReportParameter(@"CustomerName",Warranties.CustomerName),
                                new Microsoft.Reporting.WinForms.ReportParameter(@"CustomerPhone",Warranties.Phone),
                                new Microsoft.Reporting.WinForms.ReportParameter(@"CustomerEmail",Warranties.Email),
                                new Microsoft.Reporting.WinForms.ReportParameter(@"StaffCode",Warranties.Reciept.Staff),
                                new Microsoft.Reporting.WinForms.ReportParameter(@"StaffName",Warranties.Reciept.StaffName)
                            };
                            Warranty TempWarrenties = (Warranty)Warranties.Clone();
                            try
                            {
                                foreach (var warranty in Warranties)
                                {
                                    TempWarrenties.Clear();
                                    TempWarrenties.Add(warranty);
                                    Microsoft.Reporting.WinForms.ReportDataSource DataSource = new Microsoft.Reporting.WinForms.ReportDataSource
                                        (DataSourceName, TempWarrenties);
                                    using (ReportPriner Printer = new ReportPriner(ReportPath, DataSource, ReportParameter))
                                    {
                                        Printer.Run(PrinterName);
                                        Printer.Run(PrinterName);
                                    }
                                }
                                this.Warranties = null;
                                this.Reciept = null;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Problem Printing Warranty Certificate.\nPlease Try again."
                                    + Environment.NewLine
                                    + "Please Check the Error Message." + Environment.NewLine
                                    + "Please take a screen shot and send to System Administrator" + Environment.NewLine + Environment.NewLine
                                    + ex.Message
                                    , "Cannot Print.");
                                this.Warranties.RollBack();
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "Problem saving Warranty.", "Cannot Save.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (ConfirmPayment.IsValid)

                            MessageBox.Show(this, "Invalid Payment", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show(this, "Please Enter All the user Fields.", "Complete the form.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.IsBusy = false;
            }
        }

        private bool ValidateForPrint()
        {
            bool validEmail = false;
            bool validWarrenty = false;
            try
            {
                System.Net.Mail.MailAddress x = new System.Net.Mail.MailAddress(this.textBoxEmail.Text);
                validEmail = true;
            }
            catch (Exception)
            {
                validEmail = true;
            }
            if (Warranties == null || Reciept == null) validWarrenty = false;
            else validWarrenty = true;

            if (!validEmail) textBoxEmail.ForeColor = Color.Red;

            return (((textBoxCustomerName.Text.Length == 0 ||
                textBoxPhoneNumber.Text.Length == 0 ||
                textBoxEmail.Text.Length == 0 ||
                comboBoxCountry.Text.Length == 0)) && validEmail && validWarrenty)

                == false;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (Warranties != null)
                foreach (var warranty in Warranties)
                {
                    if (warranty.ItemId == this.comboBoxWarrenties.Text)
                    {
                        Warranties.RemoveWarrenty(warranty);
                        break;
                    }
                }
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            bool validEmail = false;
            const string format = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
            string mail = ((TextBox)sender).Text;
            validEmail = Regex.IsMatch(mail, format);
            if (!validEmail) ((TextBox)sender).ForeColor = Color.Red;
            else ((TextBox)sender).ForeColor = Color.Black;
        }

        private void textBoxPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))) e.Handled = true;
        }

        private void initRecieptGrid()
        {

        }

        private void buttonAddSerial_Click(object sender, EventArgs e)
        {
            WarrentyItem Slip = null;
            foreach (var warranty in Warranties)
                if (warranty.ItemId == this.comboBoxWarrenties.Text)
                {
                    Slip = warranty;
                }
            if (Slip != null)
            {

                WarrentyItemSelction WarrentyItemSelction = new WarrentyItemSelction();
                WarrentyItemSelction.Item = Slip;
                var result =
                WarrentyItemSelction.ShowDialog(this);
                /*
                if (result == System.Windows.Forms.DialogResult.Cancel)
                {
                    MessageBox.Show("Canceled");
                }*/
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    try
                    {
                        Slip.SerialNumber = Slip.SerialNumber + ";" + WarrentyItemSelction.WarrentyItem.SerialNumber;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            comboBoxWarrenties_SelectedIndexChanged(this.comboBoxWarrenties.SelectedIndex, new EventArgs());
        }

        private bool _IsBusy;
        public bool IsBusy
        {
            set
            {
                this._IsBusy = value;
                if (this._IsBusy == true)
                    this.Cursor = Cursors.WaitCursor;
                else
                    this.Cursor = Cursors.Default;
            }
        }

        private void textBoxItemSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                this.IsBusy = true;
                if (this.buttonWarrentyPriceCheck.Enabled)
                {
                    RecieptItem RecieptItem = LSExtendedWarrenty.AppBase.DataHelper.DataProvider.GetItem(this.textBoxItemSearch.Text);
                    if (RecieptItem == null)
                        MessageBox.Show(this, "Item not found.", "Not Found");
                    else
                    {
                        WarrentyItemSelction WarrentyItemSelction = new WarrentyItemSelction();
                        WarrentyItemSelction.Item = RecieptItem;
                        var result =
                        WarrentyItemSelction.ShowDialog(this);
                    }
                }
                this.IsBusy = false;
            }
        }

        private void buttonWarrentyPriceCheck_Click(object sender, EventArgs e)
        {
            this.IsBusy = true;
            if (this.textBoxItemSearch.Text.Trim().Length >= 13)
            {
                if (this.buttonWarrentyPriceCheck.Enabled)
                {
                    RecieptItem RecieptItem = LSExtendedWarrenty.AppBase.DataHelper.DataProvider.GetItem(this.textBoxItemSearch.Text);
                    if (RecieptItem == null)
                        MessageBox.Show(this, "Item not found.", "Not Found");
                    else
                    {
                        WarrentyItemSelction WarrentyItemSelction = new WarrentyItemSelction();
                        WarrentyItemSelction.Item = RecieptItem;
                        var result =
                        WarrentyItemSelction.ShowDialog(this);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter an Item Code or Barcode.", "Not Found");
            }
            this.IsBusy = false;
        }

        private void buttonJournel_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            FormJournal journel = new FormJournal();
            this.Cursor = Cursors.Default;
            journel.ShowDialog(this);
        }

        private void FormExtendedWarrenty_Load(object sender, EventArgs e)
        {

            if (SettingsProvider.GetDataSource().Length == 0)
            {
                var window = new FormMaintance();
                window.ShowDialog(this);
            }
            try
            {
                List<String> Countries = AppBase.DataHelper.DataProvider.GetCountries();
                this.comboBoxCountry.DataSource = Countries;
                this.comboBoxCountry.SelectedIndex = -1;
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                DialogResult result =
                MessageBox.Show(this, ex.Message
                + Environment.NewLine
                + "Do you want to change the Settings?"
                , "Error Occurred Exiting.",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    var window = new FormMaintance();
                    if (window.Authorize())
                        window.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Error Occurred Exiting.");
                this.Close();
            }
        }

        private void linkLabelSettings_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var window = new FormMaintance();
            if (window.Authorize())
                window.ShowDialog(this);
            this.toolStripStatusLabelLocation.Text = "Location: "
                + SettingsProvider.GetDatabase().Replace("GS", "");
        }

        private void customerFormToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var window = new FormMaintance();
            if (window.Authorize())
                window.ShowDialog(this);
            this.toolStripStatusLabelLocation.Text = "Location: "
                + SettingsProvider.GetDatabase().Replace("GS", "");
        }

        private void buttonCustmerForm_Click(object sender, EventArgs e)
        {
            using (HQConnection hqConnection = new HQConnection())
            {
                try
                {
                    hqConnection.DedicatedConnection.Open();

                    hqConnection.DedicatedConnection.Close();
                    CustomerForm CustomerForm = new CustomerForm();
                    CustomerForm.ShowDialog(this);
                }
                catch (Exception ex)
                {
                    DetailedDialog x = new DetailedDialog(new PropertyGrid());
                    x.Message = "Error Occurred while connecting to server.";
                    x.Details = ex.Message;
                    x.Text = "Connection Error.";
                    x.ShowDialog(this);
                }
            }
        }

        private void buttonVATReceipt_Click(object sender, EventArgs e)
        {
            VATReceipt form = new VATReceipt();
            form.ShowDialog(this);
        }
    }
}
