using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace LSExtendedWarrenty.AppBase
{
    public class RecieptItem
    {
        public String ItemId { get; set; }

        public String Description { get; set; }

        public String UnitSalePrice { get; set; }

        public int LineNumber { get; set; }

        private decimal _NetAmount;
        public decimal NetAmount { get { return Math.Abs(_NetAmount); } set { _NetAmount = value; } }

        private int _Quantity;
        public int Quantity { get { return Math.Abs(_Quantity); } set { _Quantity = value; this.PaymentUsage = Quantity; } }

        public string Barcode { get; set; }


        public String GetItemBrand()
        {
            return
            this.ItemId.Substring(4, 4);
        }

        private string _PaymentItem;
        public string PaymentItem
        {
            get
            {
                return _PaymentItem;
            }
            set
            {
                _PaymentItem = value;
            }
        }

        internal void UpdateUsage()
        {
            PaymentUsage--;
        }

        public int PaymentUsage { get; set; }
    }
}
