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
    public partial class ConfirmPayment : Form
    {
        public Reciept Reciept { get; set; }
        public ConfirmPayment()
        {
            InitializeComponent();
        }

        private void textBoxPaymentCashmemo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Reciept = null;
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                ((FormExtendedWarrenty)Owner).IsBusy = true;
                Reciept = 
                    LSExtendedWarrenty.AppBase.DataHelper.DataProvider.GetCashMemo(
                    this.textBoxPaymentCashmemo.Text,
                    LSExtendedWarrenty.Properties.Resources.Selection
                    );
                if (Reciept == null)
                    MessageBox.Show(this, "Cash Memo Not Found.", "Not Found");
                ((FormExtendedWarrenty)Owner).IsBusy = false;
            }
            if (Reciept != null)
            {
                this.IsValid = Warranties.IsValid(Reciept);
                if (IsValid)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        }
        

        internal DialogResult ShowDialog(FormExtendedWarrenty Owner, ref Warranty warranty)
        {
            this.Warranties = warranty;
            //this.textBoxPaymentSummary.Text = this.Warranties.GetPayementSummary();
            DataTable table = this.Warranties.GetPayementSummaryTabular();
            this.dataGridView.DataSource = table;
            return ShowDialog(Owner);
        }

        private bool _IsValid;
        public bool IsValid
        {
            get { return _IsValid; }
            set
            {
                _IsValid = value;

                if (_IsValid)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    this.labelValid.Text = "Invalid Cash Memo";
                    this.labelValid.ForeColor = Color.Red;
                }
            }
        }

        internal Warranty Warranties { get; set; }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            textBoxPaymentCashmemo_KeyPress(this.textBoxPaymentCashmemo,new KeyPressEventArgs((char)Keys.Enter));
        }

        private void ConfirmPayment_Load(object sender, EventArgs e)
        {

        }
    }
}
