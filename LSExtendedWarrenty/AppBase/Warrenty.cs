using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace LSExtendedWarrenty.AppBase
{
    class Warranty:List<WarrentyItem>,ICloneable
    {
        public delegate void WarrentyItemAddedEventHandeler();
        public event WarrentyItemAddedEventHandeler WarrentyItemAddedEvent;
        
        public Reciept Reciept { get; set; }

        public string CustomerName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public void AddWarrenty(WarrentyItem Item)
        {
            int itemQuantity =
                this.Reciept.GetCount((RecieptItem)  Item);
            int warrentyCount = this.GetWarrentyCount(Item);
            int balance = itemQuantity - warrentyCount;
            if (balance > 0)
            {
                this.Add(Item);
                if (WarrentyItemAddedEvent != null)
                {
                    WarrentyItemAddedEvent();
                }
            }
            else
            {
                throw new Exception("No More Item.");
            }
        }

        private int GetWarrentyCount(WarrentyItem Item)
        {
            int count =0;
            foreach (var item in this)
            {
                if (item.ItemId == Item.ItemId)
                    count++;
            }
            count+=
            DataHelper.DataProvider.GetWarrentyCount(Reciept, Item);
            return count;
        }

        internal void Commit()
        {
            try
            {
                DataHelper.DataProvider.CommitWarrenty(this);
            }
            catch (Exception ex) { throw ex; }
        }

        internal decimal GetNetAmount()
        {
            decimal netAmount = (decimal)0;
            foreach (var x in this)
            {
                netAmount+=(decimal) x.WarrentyAmount;
            }
            return netAmount;
        }

        internal void RemoveWarrenty(WarrentyItem warranty)
        {
            this.Remove(warranty);
            if (WarrentyItemAddedEvent != null)
            {
                WarrentyItemAddedEvent();
            }
        }

        #region ICloneable Members

        public object Clone()
        {
            object new_obj = Activator.CreateInstance(this.GetType());
            foreach (PropertyInfo pi in this.GetType().GetProperties())
            {
                if (pi.CanRead && pi.CanWrite && pi.PropertyType.IsSerializable)
                {
                    pi.SetValue(new_obj, pi.GetValue(this, null), null);
                }
            }
            return new_obj;
        }

        #endregion

        internal bool IsValid(AppBase.Reciept PaymentReciept)
        {
            bool valid = false;
            valid = DataHelper.DataProvider.GetPaymentIsUsed(PaymentReciept);
            if (!valid) return valid;
            decimal totalWarretyPayment = this.GetTotalWarretnyPayment();
            decimal TotalPayment = PaymentReciept.GetTotalPayment();
            //Check 1 is Payment values same
            valid = totalWarretyPayment == TotalPayment;
            if (!valid) return valid;
            //Check 2 is the Payment item Selected
            foreach (var item in this)
            {
                if (!valid) return valid;
                item.PaymentItem = item.GetPaymentItem();
                if (item.PaymentItem == null)
                {
                    throw new DataHelper.NoWarrentySettingFoundException("No Warranty Settings Found", "Cannot Proceed");
                }
                foreach (var payment in PaymentReciept)
                {
                    if (item.PaymentItem == payment.ItemId && payment.PaymentUsage > 0)
                    {
                        payment.UpdateUsage();
                        item.PaymentReciept = PaymentReciept;
                        valid = true;
                        break;
                    }
                    else valid = false;
                }
                if (!valid) return valid;
            }
            foreach (var payment in PaymentReciept)
            {
                if (payment.PaymentUsage != 0)
                {
                    valid = false;
                    if (!valid) return valid;
                }
            }
            if (totalWarretyPayment == TotalPayment) return true;

            else valid = false;
            return valid;
        }

        private decimal GetTotalWarretnyPayment()
        {
            decimal TotalWarrentyPaymet = 0;
            foreach (var x in this)
            {
                TotalWarrentyPaymet += x.WarrentyAmount;
            }
            return TotalWarrentyPaymet;
        }

        private decimal GetTotalPayment()
        {
            decimal Total = (decimal)0;
            foreach (var x in this)
            {
                Total += x.NetAmount;
            }
            return Total;
        }

        public string Country { get; set; }

        internal void RollBack()
        {
            DataHelper.DataProvider.RollbackWarrenth(this);
        }

        internal string GetPayementSummary()
        {
            String Report = "";
            foreach (var x in this)
            {
                var payItem = (x.PaymentItem == null) ? x.GetPaymentItem() : x.PaymentItem;
                var amount = x.WarrentyAmount.ToString("F", System.Globalization.CultureInfo.InvariantCulture);
                Report += payItem +"     Amount: "+amount+"AED";
            }
            return Report;
        }

        internal System.Data.DataTable GetPayementSummaryTabular()
        {
            System.Data.DataTable Report = new System.Data.DataTable();
            Report.Columns.Add(new System.Data.DataColumn("Payment Item"));
            Report.Columns.Add(new System.Data.DataColumn("Amount"));
            foreach (var x in this)
            {
                var payItem = (x.PaymentItem == null) ? x.GetPaymentItem() : x.PaymentItem;
                var amount = x.WarrentyAmount.ToString("F", System.Globalization.CultureInfo.InvariantCulture);
                //Report += payItem + "     Amount: " + amount + "AED";
                Report.Rows.Add(new object[]{payItem, amount});
            }
            return Report;
        }
    }
}
