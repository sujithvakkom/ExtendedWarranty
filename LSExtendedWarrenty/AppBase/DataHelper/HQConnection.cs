using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace LSExtendedWarrenty.AppBase.DataHelper
{
    class HQConnection : IDisposable
    {
        private static SqlConnection HQSQLConnection;

        public HQConnection()
        {
            HQSQLConnection = new SqlConnection(CONNECTION_STRING);
        }

        private SqlConnection _DedicatedConnection;
        public SqlConnection DedicatedConnection
        {
            get
            {
                if (_DedicatedConnection == null)
                {
                    _DedicatedConnection = new SqlConnection(CONNECTION_STRING);
                }
                return _DedicatedConnection;
            }
            set
            {
                _DedicatedConnection = value;
            }
        }

        private String CONNECTION_STRING_FORMAT = @"Data Source={0};Initial Catalog={1};User Id={2};Password={3};";

        private String CONNECTION_STRING
        {
            get
            {

                var format =
                new string[] { 
            SettingsProvider.GetHQDataSource().Length == 0 ? "GSLSR" : SettingsProvider.GetHQDataSource(),
            SettingsProvider.GetHQDatabase().Length == 0 ? "Sitemanager" : SettingsProvider.GetHQDatabase(),
            SettingsProvider.GetHQUserName().Length == 0 ?"sa":SettingsProvider.GetHQUserName(),
            SettingsProvider.GetHQPassword().Length == 0?"gstoreshq100":SettingsProvider.GetHQPassword()
};
                return
                    String.Format(CONNECTION_STRING_FORMAT, format);
            }
        }

        internal SqlTransaction BeginTransaction()
        {
            if (this.DedicatedConnection.State == System.Data.ConnectionState.Closed)
                this.DedicatedConnection.Open();
            this.DedicatedConnectionTransaction = this.DedicatedConnection.BeginTransaction();
            return this.DedicatedConnectionTransaction;
        }

        internal void CommitTransaction()
        {
            this.DedicatedConnectionTransaction.Commit();
            //this.DedicatedConnection.Close();
        }

        internal void RollbackTransaction()
        {
            this.DedicatedConnectionTransaction.Rollback();
            //this.DedicatedConnection.Close();
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (HQSQLConnection.State != System.Data.ConnectionState.Closed) HQSQLConnection.Close();

            if (DedicatedConnection != null && DedicatedConnection.State != System.Data.ConnectionState.Closed) DedicatedConnection.Close();

        }

        #endregion

        internal static void UpdateWarrenties()
        {
            List<string> par = new List<string>();
            using (Connection connection = new Connection())
            {
                par = connection.GetReplications();
                using (SqlCommand command = new SqlCommand(XX_EXTENDED_WARRANTY.SQL_INSERT, HQSQLConnection))
                {
                    try
                    {
                        if (HQSQLConnection.State == System.Data.ConnectionState.Closed)
                            HQSQLConnection.Open();
                        command.Transaction = HQSQLConnection.BeginTransaction();
                        foreach (String x in par)
                        {
                            var warrenty =
                                connection.GetWattenty(x);
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@warranty_number", warrenty.warranty_number.ToString().ToString());
                            command.Parameters.AddWithValue("@show_room", warrenty.show_room.ToString());
                            command.Parameters.AddWithValue("@cash_memo", warrenty.cash_memo.ToString());
                            command.Parameters.AddWithValue("@item_code", warrenty.item_code.ToString());
                            command.Parameters.AddWithValue("@item_desc", warrenty.item_desc.ToString());
                            command.Parameters.AddWithValue("@serial_number", warrenty.serial_number.ToString());
                            command.Parameters.AddWithValue("@retail_price", warrenty.retail_price.ToString());
                            command.Parameters.AddWithValue("@warranty_years", warrenty.warranty_years.ToString());
                            command.Parameters.AddWithValue("@bill_total", warrenty.bill_total.ToString());
                            command.Parameters.AddWithValue("@issued_date", warrenty.issued_date.ToString());
                            command.Parameters.AddWithValue("@customer_name", warrenty.customer_name.ToString());
                            command.Parameters.AddWithValue("@customer_email", warrenty.customer_email.ToString());
                            command.Parameters.AddWithValue("@customer_phone", warrenty.customer_phone.ToString());
                            command.Parameters.AddWithValue("@customer_address", warrenty.customer_address.ToString());
                            command.Parameters.AddWithValue("@payment_cash_memo", warrenty.payment_cash_memo.ToString());
                            command.Parameters.AddWithValue("@country", warrenty.country.ToString());

                            command.ExecuteNonQuery();
                        }
                        command.Transaction.Commit();
                        foreach (String x in par)
                        {
                            connection.DeleteReplication(x);
                        }
                    }
                    catch (Exception ex)
                    {
                        command.Transaction.Rollback();
                        throw ex;
                    }
                }
                //XX_EXTENDED_WARRANTY.SQL_INSERT
            }
        }

        internal List<Customer> GetCustomers(string Name, string Email, string PhoneNumber)
        {

            List<Customer> customers = new List<Customer>();
            if (HQSQLConnection.State != System.Data.ConnectionState.Open)
            {
                HQSQLConnection.Open();
                SqlCommand command = new SqlCommand(XX_POS_CUSTOMERS.SELECT, HQSQLConnection);
                command.Parameters.AddWithValue(@"@customer_email", Email);
                command.Parameters.AddWithValue(@"@customer_name", Name);
                command.Parameters.AddWithValue(@"@customer_phone_number", PhoneNumber);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    customers.Add(new
                    Customer()
                    {
                        CustomerId = reader.GetInt32(0),
                        CustomerName = reader.GetString(1),
                        Email = reader.GetString(2),
                        PhoneNumber = reader.GetString(3),
                        Country = reader.GetString(4),
                        Address = reader.GetString(5)
                    }
                        );
                }
                reader.Close();
            }
            return customers;
        }

        public SqlTransaction DedicatedConnectionTransaction { get; set; }

        internal int UpdateCustomer(Customer customer)
        {
            using (SqlCommand command = new SqlCommand(XX_POS_CUSTOMERS.INSERT,
                DedicatedConnection,
                this.DedicatedConnectionTransaction))
            {
                command.Parameters.AddWithValue("@customer_name", customer.CustomerName);
                command.Parameters.AddWithValue("@customer_email", customer.Email);
                command.Parameters.AddWithValue("@customer_phone_number", customer.PhoneNumber);
                command.Parameters.AddWithValue("@customer_country", customer.Country);
                command.Parameters.AddWithValue("@address", customer.Address);
                try
                {
                    int count = command.ExecuteNonQuery();
                    return count;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}