using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.Collections;

namespace LSExtendedWarrenty.AppBase
{
    class WarrentyItem : RecieptItem
    {
        public int NumberOfYears { get; set; }
        public int Percentage { get; set; }
        public int WarrentyAmount { get; set; }
        public String SerialNumber { get; set; }

        public string CustomerName { get; set; }

        public Reciept Reciept { get; set; }


        public string WarrentyNumber { get; set; }

        public AppBase.Reciept PaymentReciept { get; set; }

        internal String GetRtf(Warranty parent)
        {
            const string NewLine = @" \line";
            const string RTF = @"{\rtf1\ansi ";
            String Slip = "";
            Slip += RTF;
            Slip += @"\b Extended Warranty Memo \b0";
            Slip += NewLine;

            //Slip += RTF;
            //Slip += @"Warranty Number :";
            //Slip += this.WarrentyNumber + NewLine;
            //Slip += NewLine;

            //Slip += RTF;
            //Slip += @"\b Customer Details  \b0";
            //Slip += NewLine;
            //Slip += NewLine;

            //Slip += RTF;
            //Slip += parent.CustomerName;
            //Slip += NewLine;
            //Slip += NewLine;

            //Slip += RTF;
            //Slip += parent.Email;
            //Slip += NewLine;
            //Slip += NewLine;

            //Slip += RTF;
            //Slip += parent.Phone;
            //Slip += NewLine;
            //Slip += NewLine;

            //Slip += RTF;
            //Slip += parent.Address;
            //Slip += NewLine;
            //Slip += NewLine;
            //Slip += NewLine;

            Slip += RTF;
            Slip += @"Receipt ID      :";
            Slip += parent.Reciept.RecieptID;
            Slip += NewLine;
            Slip += NewLine;
            Slip += NewLine;

            Slip += RTF;
            Slip += @"Item Code       :";
            Slip += this.ItemId;
            Slip += NewLine;
            Slip += NewLine;

            Slip += RTF;
            Slip += @"Description     :";
            Slip += this.Description.Length > 20 ? this.Description.Substring(0, 20) : this.Description;
            Slip += NewLine;
            Slip += NewLine;

            Slip += RTF;
            Slip += @"Serial Number   :";
            var temp= this.SerialNumber.Split(new char[] { ';' });
            foreach (var x in temp)
            {
                Slip += NewLine;
                Slip += NewLine;
                Slip += RTF;
                Slip += @"                :"+x;
            }
            Slip += NewLine;
            Slip += NewLine;
            Slip += RTF;
            Slip += @"Extended Years  :";
            Slip += this.NumberOfYears;
            Slip += NewLine;
            Slip += NewLine;

            Slip += RTF;
            Slip += //@"\b Warranty Amount : \b0";
            @"{\rtlch\fcs1 \af150\afs19 \ltrch\fcs0 \f160\fs19\insrsid2522039\charrsid6435061 Warranty Amount}{\rtlch\fcs1 \af150\afs19 \ltrch\fcs0 
\f160\fs19\insrsid2522039\charrsid6435061 \tab :}";
            Slip += this.WarrentyAmount;
            Slip += NewLine;
            Slip += NewLine;

            return Slip;
            /*
             **/
        }

        internal string GetFormatedRtf(Warranty parent)
        {
            String RTF = "";
            /*
            Assembly assembly = Assembly.GetExecutingAssembly();
            String ResourceName = @"LSExtendedWarrenty.Properties.Resources.WarrentyFormat";
            var x =
            assembly.GetManifestResourceNames();
            

            using (Stream stream = assembly.GetManifestResourceStream(ResourceName))
                if (stream != null)
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        RTF = reader.ReadToEnd();
                    }
             * */
            RTF = global::LSExtendedWarrenty.Properties.Resources.WarrentyFormat;
            RTF = RTF.Replace(@"WarrentyNumber", this.WarrentyNumber);
            RTF = RTF.Replace(@"CustomerName", parent.CustomerName);
            RTF = RTF.Replace(@"customerEmail", parent.Email);
            RTF = RTF.Replace(@"customerPhone", parent.Phone);
            RTF = RTF.Replace(@"CustoemerAddress", parent.Address);
            RTF = RTF.Replace(@"ItemId", this.ItemId);
            RTF = RTF.Replace(@"ItemDescription", this.Description);
            RTF = RTF.Replace(@"ItemSerialNum", this.SerialNumber);
            RTF = RTF.Replace(@"{8\}", this.NumberOfYears.ToString());
            RTF = RTF.Replace(@"{9\}", DateTime.Now.ToShortDateString());
            RTF = RTF.Replace(@"WarrentyAmt", this.WarrentyAmount.ToString());
            RTF = RTF.Replace(@"RecieptNumber", parent.Reciept.RecieptID);
            return RTF;
        }

        internal String GetPaymentItem()
        {
            var settings = 
            DataHelper.DataProvider.GetWarrentySettings(this);
            foreach (var setting in settings)
            {
                if (this.GetItemBrand() == setting.Brand.ToString()
                    &&
                    this.NumberOfYears == setting.NumberOfYears
                    )
                {
                    return setting.PaymentItem;
                }
            }
            return null;
        }


        public string RecieptID { get; set; }

        public DateTime IssuedDate { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string ErrorMessage { get; set; }
    }
}
