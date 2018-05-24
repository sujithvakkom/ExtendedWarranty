using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using LSExtendedWarrenty.AppBase.DataHelper;
using LSExtendedWarrenty.AppBase;
using MyExtentions.Controls.MessageBoxExtentions;

namespace LSExtendedWarrenty
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            IsValidEmail = false;
            const string format = @"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?";
            string mail = ((TextBox)sender).Text;
            IsValidEmail = Regex.IsMatch(mail, format);
            if (!IsValidEmail) ((TextBox)sender).ForeColor = Color.Red;
            else ((TextBox)sender).ForeColor = Color.Black;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (this.isCustomerValid())
            {
                List<Customer> Customers = DataProvider.GetCustomer(
                    this.textBoxName.Text,
                    this.textBoxEmail.Text,
                    this.phoneControlPhone.PhoneNumber
                    );
                if (Customers.Count > 0)
                {
                    SelectCustomer frm = new SelectCustomer(Customers);
                    if (frm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        this.ClearUI();
                        this.SelectedCustomer = frm.SelectedCustomer;
                    }
                    //MessageBox.Show(this, "The Customer exists.", "Exists");
                }
                else
                {
                    Customer customer = new Customer()
                    {
                        CustomerName = textBoxName.Text.Trim(),
                        Email = textBoxEmail.Text.Trim(),
                        PhoneNumber = phoneControlPhone.PhoneNumber.Trim(),
                        Address = textBoxAddress.Text.Trim(),
                        Country = phoneControlPhone.Country
                    };
                    try
                    {
                        customer.Commit();
                        this.ClearUI();
                    }
                    catch (Exception ex)
                    {
                        DetailedDialog x = new DetailedDialog(new PropertyGrid());
                        x.Message = "Error Occurred while Inserting Data.";
                        x.Details = ex.Message;
                        x.Text = "Cannot Add Data.";
                        x.ShowDialog(this);
                    }
                }
            }
            else
            {
                string ValidationMessages = "";
                ValidationMessages += (this.textBoxName.Text.Length == 0) ? "Customer name cannot be blank." + Environment.NewLine : "";
                ValidationMessages += (IsValidEmail == false) ? "Invalid Email." + Environment.NewLine : "";
                ValidationMessages += this.phoneControlPhone.ValidationMessage;
                MessageBox.Show(this, ValidationMessages, "Invalid Details");
            }
        }

        private bool isCustomerValid()
        {
            bool valid = (phoneControlPhone.IsControlValid &&
                this.textBoxName.Text.Length > 0 &&
                IsValidEmail);
            return valid;
        }

        private void ClearUI()
        {
            this.textBoxName.Text = "";
            this.textBoxEmail.Text = "";
            this.textBoxAddress.Text = "";
            this.textBoxNameLookup.Text = "";
            this.textBoxEmailLookup.Text = "";
            this.textBoxPhoneLookup.Text = "";
            this.phoneControlPhone.ClearUI();

            this.textBoxSelectedName.Text = "";
            this.textBoxSelectedEmail.Text = "";
            this.textBoxSelectedPhone.Text = "";
            this.textBoxSelectedAddress.Text = "";
            this.textBoxSelectedCountry.Text = "";
        }

        public bool IsValidEmail { get; set; }

        private void buttonSwitch_Click(object sender, EventArgs e)
        {
            this.splitContainerCustomer.Panel1Collapsed = !this.splitContainerCustomer.Panel1Collapsed;
        }

        private Customer _SelectedCustomer;
        public Customer SelectedCustomer
        {
            get { return _SelectedCustomer; }
            set
            {
                _SelectedCustomer = value;
                this.CustomerSelected();
            }
        }

        private void CustomerSelected()
        {
            if (SelectedCustomer == null)
            {
                this.textBoxSelectedName.Text = "";
                this.textBoxSelectedEmail.Text = "";
                this.textBoxSelectedPhone.Text = "";
                this.textBoxSelectedAddress.Text = "";
                this.textBoxSelectedCountry.Text = "";
            }
            else
            {
                this.splitContainerCustomer.Panel1Collapsed = true;
                this.textBoxSelectedName.Text = this.SelectedCustomer.CustomerName;
                this.textBoxSelectedEmail.Text = this.SelectedCustomer.Email;
                this.textBoxSelectedPhone.Text = this.SelectedCustomer.PhoneNumber;
                this.textBoxSelectedAddress.Text = this.SelectedCustomer.Address;
                this.textBoxSelectedCountry.Text = this.SelectedCustomer.Country;
            }
        }
    }
}
