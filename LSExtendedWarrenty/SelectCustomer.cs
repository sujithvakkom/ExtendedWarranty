using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LSExtendedWarrenty.AppBase;

namespace LSExtendedWarrenty
{
    public partial class SelectCustomer : Form
    {
        private List<Customer> Customers;

        public SelectCustomer()
        {
            InitializeComponent();
        }

        public SelectCustomer(List<Customer> Customers)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.Customers = Customers;
            this.dataGridViewCustomers.DataSource = this.Customers;
        }

        private void dataGridViewCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelectedIndex = e.RowIndex;
        }

        private int SelectedIndex { get; set; }

        public Customer SelectedCustomer
        {
            get
            {
                return Customers[SelectedIndex];
            }
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
