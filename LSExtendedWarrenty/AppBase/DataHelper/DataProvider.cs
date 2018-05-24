using System;
using System.Collections.Generic;
using System.Text;

namespace LSExtendedWarrenty.AppBase.DataHelper
{
    partial class DataProvider
    {
        internal static Reciept GetCashMemo(string RecieptNumber,String Selection)
        {
            Reciept Reciept;
            using (Connection Connection = new Connection())
            {
                Reciept = Connection.Reciept(RecieptNumber,Selection);
            }
            return Reciept;
        }

        internal static String GetItemId(string Barcode,String TransactionId)
        {
            String ItemId;
            using (Connection Connection = new Connection())
            {
                ItemId = Connection.ItemId(Barcode, TransactionId);
            }
            return ItemId;
        }

        internal static List<WarretntySettings> GetWarrentySettings(RecieptItem Item)
        {
            List<WarretntySettings> WarrentySettingsList = new List<WarretntySettings>();
            using (Connection Connection = new Connection())
            {
                WarrentySettingsList = Connection.WarrentySettings(Item);
            }
            if (WarrentySettingsList.Count == 0)
                throw new NoWarrentySettingFoundException("No Warranty Settings Found for the Item: " + Item.ItemId+".","Cannot Add Warranty for Item.");
            return WarrentySettingsList;
        }

        internal static int GetWarrentyCount(Reciept Reciept, WarrentyItem Item)
        {
            int count =0;
            using (Connection Connection = new Connection())
            {
                count = Connection.WarrentyCount(Reciept.RecieptID, Item.ItemId);
            }
            return count;
        }

        internal static void CommitWarrenty(Warranty warranty)
        {
            using (Connection Connection = new Connection())
            {
                Connection.BeginTransaction();
                try
                {
                    foreach (var x in warranty)
                    {
                        try
                        {
                            x.WarrentyNumber =
                                Connection.Insert(x, warranty.Reciept.RecieptID, warranty.CustomerName, warranty.Email, warranty.Phone, warranty.Address, warranty.Country);
                        }
                        catch (Exception ex) { throw ex; }
                    }
                    try
                    {
                        using (HQConnection x = new HQConnection())
                        {
                            HQConnection.UpdateWarrenties();
                        }
                    }
                    catch (Exception)
                    {

                    }
                    Connection.CommitTransaction();
                }
                catch (Exception ex)
                {
                    Connection.RollbackTransaction();
                    throw ex;
                }
            }
        }



        internal static void RollbackWarrenth(Warranty warranty)
        {

            using (Connection Connection = new Connection())
            {
                Connection.BeginTransaction();
                try
                {
                    foreach (var x in warranty)
                    {
                        try
                        {
                            Connection.Delete(x.WarrentyNumber);
                        }
                        catch (Exception ex) { throw ex; }
                    }
                    Connection.CommitTransaction();
                }
                catch (Exception ex)
                {
                    Connection.RollbackTransaction();
                    throw ex;
                }
            }
        }

        internal static bool GetPaymentIsUsed(AppBase.Reciept PaymentReciept)
        {
            bool valid = false;
            using (Connection Connection = new Connection())
            {
                int count = Connection.WarretyPaymentCount(PaymentReciept);
                valid = (count == 0);
            }
            return valid;
        }

        internal static List<string> GetCountries()
        {
            using (Connection Connection = new Connection())
            {
                return Connection.Countries();
            }
        }

        internal static RecieptItem GetItem(string ItemSearch)
        {

            using (Connection Connection = new Connection())
            {
                return Connection.Item(ItemSearch);
            }
        }

        internal static Warranty GetWarrenties(int Start, 
            int End,
            string Location,
            String Warrenty,
            String Reciept,
            String Email,
            String HasErrors)
        {
            using (Connection Connection = new Connection())
            {
                return Connection.Warrenties(Start,
             End,
             Location,
             Warrenty,
             Reciept,
             Email,
             HasErrors);
            }
        }

        internal static Warranty GetWarrenties(int Start, int End,bool Updated)
        {
            using (Connection Connection = new Connection())
            {
                return Connection.Warrenties(Updated);
            }
        }

        internal static System.Data.DataTable DownloadWarrenties(int Start,
            int End,
            string Location,
            String Warrenty,
            String Reciept,
            String Email,
            String HasErrors)
        {
            using (Connection Connection = new Connection())
            {
                return Connection.DownloadWarrienties(Start,
             End,
             Location,
             Warrenty,
             Reciept,
             Email,
             HasErrors);
            }
        }
        
        internal static List<Customer> GetCustomer(string Name, string Email, string PhoneNumber)
        {
            using (HQConnection Connection = new HQConnection())
            {
                return Connection.GetCustomers(Name,Email,PhoneNumber);
            }
        }

        internal static void CommitCustomer(Customer customer)
        {
            using (HQConnection Connection = new HQConnection())
            {
                Connection.BeginTransaction();
                try
                {
                    Connection.UpdateCustomer(customer);
                    Connection.CommitTransaction();
                }
                catch (Exception ex)
                {
                    Connection.RollbackTransaction();
                    throw ex;
                }
            }
        }
    }
}
