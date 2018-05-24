using System;
using System.Collections.Generic;
using System.Text;

namespace LSExtendedWarrenty.AppBase
{
    public class Customer
    {
        public string CustomerName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Country { get; set; }

        public string Address { get; set; }

        public int CustomerId { get; set; }

        internal void Commit()
        {
            try
            {
                DataHelper.DataProvider.CommitCustomer(this);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
