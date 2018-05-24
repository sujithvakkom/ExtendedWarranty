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
    public partial class WarrentyItemSelction : Form
    {
        public WarrentyItemSelction()
        {
            InitializeComponent();
        }

        private AppBase.RecieptItem _Item;
        internal AppBase.RecieptItem Item
        {
            get { return _Item; }
            set
            {
                _Item = value;
                this.Text = Item.Description;
                ShowItemDetails();
            }
        }


        private void ShowItemDetails()
        {
            this.textBoxItem.Text = this.Item.ItemId + " " + Item.Description;
            this.textBoxSalePrice.Text = Math.Round(this.Item.NetAmount/this.Item.Quantity,2).ToString();
        }

        private void WarrentyItemSelction_Load(object sender, EventArgs e)
        {
            try
            {
                this.WarrentySettingList = DataProvider.GetWarrentySettings(Item);
                int numberOfYears = (int)this.numericUpDown1.Value;
                decimal salePrice = Math.Round(this.Item.NetAmount / this.Item.Quantity, 2);
                /*
                If WarrentyAmount > 0 {
                        txtAmount.Text = Math.Round(Val(txtRetail.Text) * (mPercent / 100), 2)
                        txtAmount.Text = (Int(Val(txtAmount.Text) / 10)) * 10
                }
                 */
                this.WarrentyAmount = GetWarrentyAmount();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occurred While Loading Warranty Settings. "
                        + Environment.NewLine
                        + "Please Check the Error Message." + Environment.NewLine
                        + "Please take a screen shot and send to System Administrator" + Environment.NewLine + Environment.NewLine
                        + ex.Message, "Error Occurred.");
                Close();
            }
        }

        private string[] GetWarrentyYear()
        {
            List<string> Years = new List<string>();
            foreach (var x in this.WarrentySettingList)
            {
                Years.Add(x.NumberOfYears.ToString());
            }
            return Years.ToArray();
        }

        private int GetWarrentyAmount()
        {
            decimal warrentyPercent =10;
            decimal warrentyAmount =0;
            bool flag = false;
            foreach (WarretntySettings temp in WarrentySettingList)
            {
                if (temp.NumberOfYears == (int)this.numericUpDown1.Value)
                {
                    warrentyPercent = temp.WarrentyPercentage;
                    flag = true;
                    break;
                }
            }
            if (!flag)
                throw new NoWarrentySettingFoundException("Invalid Years", "");
            warrentyAmount = (this.Item.NetAmount / this.Item.Quantity) * (warrentyPercent / 100);
            warrentyAmount = warrentyAmount - (warrentyAmount % 10);
            return (int) warrentyAmount;
        }

        public List<WarretntySettings> WarrentySettingList { get; set; }



        private int _WarrentyAmount;
        public int WarrentyAmount
        {
            get { return _WarrentyAmount; }
            set
            {
                _WarrentyAmount = value;
                this.textBoxWarrentyAmount.Text = _WarrentyAmount.ToString();
                this.textBoxWarrentyAmount.ForeColor = Color.Black;
                if (this.textBoxItemSerial.Text.Length > 0)
                    this.buttonOK.Enabled = true;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.WarrentyAmount = GetWarrentyAmount();
            }
            catch (Exception ex)
            {
                //TODO
                this.textBoxWarrentyAmount.Text = ex.Message;
                this.textBoxWarrentyAmount.ForeColor = Color.Red;
                this.buttonOK.Enabled = false;
            }
        }

        private void WarrentyItemSelction_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.textBoxItemSerial.Focus();
            this.textBoxItemSerial.Text = e.KeyChar.ToString();
            this.textBoxItemSerial.Select(1, 0);
        }

        private void numericUpDown1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            this.textBoxItemSerial.Focus();
            this.textBoxItemSerial.Text = e.KeyChar.ToString();
            this.textBoxItemSerial.Select(1, 0);
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            WarrentyItem item = new WarrentyItem();
            item.ItemId = Item.ItemId;
            item.Description = Item.Description;
            item.Barcode = Item.Barcode;
            item.LineNumber = Item.LineNumber;
            item.Quantity = Item.Quantity;
            item.NetAmount = Item.NetAmount;
            item.UnitSalePrice = Item.UnitSalePrice;
            item.NumberOfYears = (int)this.numericUpDown1.Value;
            item.WarrentyAmount = this.WarrentyAmount;
            item.SerialNumber = this.textBoxItemSerial.Text;
            Item.PaymentItem = GetPaymentItem(item);
            this.WarrentyItem = item;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private string GetPaymentItem(WarrentyItem item)
        {
            foreach (var x in this.WarrentySettingList)
            {
                if (item.GetItemBrand() == x.Brand.ToString())
                    return x.PaymentItem;
            }
            return null;
        }

        internal WarrentyItem WarrentyItem { get; set; }

        private void textBoxItemSerial_KeyPress(object sender, KeyPressEventArgs e)
        {
            int len = this.textBoxItemSerial.Text.Length;
            if (e.KeyChar == (char)Keys.Back && len > 0)
            {
                len--;
            }
            else len++;
            if (len == 0) this.buttonOK.Enabled = false;
            else this.buttonOK.Enabled = true;
        }

        private void textBoxItemSerial_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
