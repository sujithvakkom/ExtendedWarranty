using System;
using System.Collections.Generic;
using System.Text;

namespace LSExtendedWarrenty.AppBase
{
    public class Reciept:List<RecieptItem>
    {
        public String Temp { get; set; }
        public String TransactionID { get; set; }
        public String RecieptID { get; set; }

        public string Store { get; set; }

        public DateTime TransactionDate { get; set; }

        internal int GetCount(RecieptItem recieptItem)
        {
            int count =0;
            foreach (var item in this)
            {
                if (item.ItemId == recieptItem.ItemId)
                    count += item.Quantity;
            }
            return count;
        }

        internal decimal GetTotalPayment()
        {
            decimal Total = (decimal)0;
            foreach (var x in this)
            {
                Total += x.NetAmount;
            }
            return Total;
        }

        public string Staff { get; set; }

        public string StaffName { get; set; }

        public override string ToString()
        {
            return RecieptID;
        }
    }
}
