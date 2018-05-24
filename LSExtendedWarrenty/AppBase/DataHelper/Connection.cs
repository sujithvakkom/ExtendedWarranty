using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace LSExtendedWarrenty.AppBase.DataHelper
{
    class Connection:IDisposable
    {
        private static SqlConnection POSConnection;
        private static String CONNECTION_STRING_FORMAT = @"Data Source={0};Initial Catalog={1};User Id={2};Password={3};";

        private static String CONNECTION_STRING
        {
            get
            {

                var format =
                new string[] { SettingsProvider.GetDataSource(),
                SettingsProvider.GetDatabase(),
                SettingsProvider.GetUserName(),
                SettingsProvider.GetPassword()};
                return
                    String.Format(CONNECTION_STRING_FORMAT, format);
            }
        }

        internal static string getConnectionString() { return CONNECTION_STRING; }

        #region XX_REPLICATIONACTIONS
        const String XX_REPLICATIONACTIONS = @"/****** Object:  Table [dbo].[XX_REPLICATIONACTIONS]    Script Date: 12/17/2015 09:08:29 ******/
IF NOT EXISTS (
		SELECT *
		FROM sys.objects
		WHERE object_id = OBJECT_ID(N'[XX_REPLICATIONACTIONS]')
			AND type IN (N'U')
		)
BEGIN
	CREATE TABLE [XX_REPLICATIONACTIONS] (
		[ActionID] [int] IDENTITY(1, 1) NOT NULL
		,[Action] [int] NOT NULL
		,[ObjectName] [nvarchar](50) NOT NULL
		,[AuditContext] [uniqueidentifier] NOT NULL
		,[Parameters] [nvarchar](max) NULL
		,[DateCreated] [datetime] NULL
		,[DATAAREAID] [nvarchar](4) NOT NULL
		,CONSTRAINT [PK_XX_REPLICATIONACTIONS] PRIMARY KEY CLUSTERED (
			[ActionID] ASC
			,[DATAAREAID] ASC
			) WITH (
			PAD_INDEX = OFF
			,STATISTICS_NORECOMPUTE = OFF
			,IGNORE_DUP_KEY = OFF
			,ALLOW_ROW_LOCKS = ON
			,ALLOW_PAGE_LOCKS = ON
			) ON [PRIMARY]
		) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END

IF NOT EXISTS (
		SELECT *
		FROM sys.indexes
		WHERE object_id = OBJECT_ID(N'[XX_REPLICATIONACTIONS]')
			AND NAME = N'INDEX_XX_DateCreated'
		)
BEGIN
	CREATE NONCLUSTERED INDEX [INDEX_XX_DateCreated] ON [XX_REPLICATIONACTIONS] ([DateCreated] ASC)
		WITH (
				PAD_INDEX = OFF
				,STATISTICS_NORECOMPUTE = OFF
				,SORT_IN_TEMPDB = OFF
				,IGNORE_DUP_KEY = OFF
				,DROP_EXISTING = OFF
				,ONLINE = OFF
				,ALLOW_ROW_LOCKS = ON
				,ALLOW_PAGE_LOCKS = ON
				) ON [PRIMARY]
END

IF NOT EXISTS (
		SELECT *
		FROM sys.indexes
		WHERE object_id = OBJECT_ID(N'[XX_REPLICATIONACTIONS]')
			AND NAME = N'INDEX_XX_ObjectName'
		)
BEGIN
	CREATE NONCLUSTERED INDEX [INDEX_XX_ObjectName] ON [XX_REPLICATIONACTIONS] ([ObjectName] ASC)
		WITH (
				PAD_INDEX = OFF
				,STATISTICS_NORECOMPUTE = OFF
				,SORT_IN_TEMPDB = OFF
				,IGNORE_DUP_KEY = OFF
				,DROP_EXISTING = OFF
				,ONLINE = OFF
				,ALLOW_ROW_LOCKS = ON
				,ALLOW_PAGE_LOCKS = ON
				) ON [PRIMARY]
END";
#endregion

        public const string SQL_SELECT_WARRENTY = @"SELECT warranty_id
      ,warranty_number
      ,show_room
      ,cash_memo
      ,item_code
      ,item_desc
      ,serial_number
      ,retail_price
      ,warranty_years
      ,bill_total
      ,issued_date
      ,customer_name
      ,customer_email
      ,customer_phone
      ,customer_address
      ,payment_cash_memo
      ,country
      ,[dbo].[EXTENDED_WARRENTY_ERROR](cash_memo,payment_cash_memo) error_message
  FROM XX_EXTENDED_WARRANTY ";
        public const string SQL_SELECT_WARRENTY_UPDATED = @"SELECT warranty_id
      ,warranty_number
      ,show_room
      ,cash_memo
      ,item_code
      ,item_desc
      ,serial_number
      ,retail_price
      ,warranty_years
      ,bill_total
      ,issued_date
      ,customer_name
      ,customer_email
      ,customer_phone
      ,customer_address
      ,payment_cash_memo
      ,country
  FROM XX_EXTENDED_WARRANTY";
        private const String SQL_RECIEPT_DETAILS =
            @"SELECT TRA.TRANSACTIONID
	,TRA.RECEIPTID
	,TRA.STORE
	,TRA.STAFF
	,STAFF.NamePrefix + ' ' + STAFF.FirstName + ' ' + STAFF.MiddleName + ' ' + STAFF.LastName AS NAME
	,TRA.TRANSDATE
	,SALES.LINENUM
	,SALES.ITEMID
	,SALES.QTY
	,SALES.QTY * CASE 
		WHEN ITEM.PRICE = 0
			THEN abs(SALES.NETAMOUNT / SALES.QTY)
		ELSE ITEM.PRICE
		END AS NETAMOUNT
	,SALES.DESCRIPTION
	,SALES.BARCODE
FROM RBOTRANSACTIONSALESTRANS AS SALES
INNER JOIN (
	SELECT ITEMID
		,Min(PRICE) AS PRICE
	FROM [INVENTTABLEMODULE]
	WHERE MODULETYPE = 2
	GROUP BY ITEMID
	) AS ITEM ON SALES.ITEMID = ITEM.ITEMID
INNER JOIN RBOTRANSACTIONTABLE AS TRA ON SALES.TRANSACTIONID = TRA.TRANSACTIONID
INNER JOIN USERS STAFF ON TRA.STAFF = STAFF.STAFFID
WHERE (TRA.DATAAREAID = 'LSR')
	AND (SALES.DATAAREAID = 'LSR')
	AND (TRA.TYPE = 2)
	AND (TRA.ENTRYSTATUS NOT IN (1))
	AND (SALES.TRANSACTIONSTATUS = 0)
	AND TRA.SALEISRETURNSALE = 0
	AND (
		DATEDIFF(HOUR, tra.TRANSDATE, getdate()) < 24
		OR 'ALL' = @SELECTION
		)
	AND TRA.RECEIPTID = @RECEIPTID
";
        private const String SQL_ITEM_ID = @"SELECT SALES.ITEMID
FROM INVENTITEMBARCODE REF
INNER JOIN RBOTRANSACTIONSALESTRANS SALES ON SALES.ITEMID = REF.ITEMID
WHERE SALES.DATAAREAID = 'LSR' 
	AND SALES.TRANSACTIONSTATUS = 0
	AND ITEMBARCODE = @ITEMBARCODE
	AND SALES.TRANSACTIONID = @TRANSACTIONID";
        private const String SQL_WARRENTY_SETTINGS = @"GET_WARRENTY_SETTINGS";
        private const String SQL_WARRENTY_COUNT = 
        @"SELECT COUNT(warranty_id)
FROM dbo.XX_EXTENDED_WARRANTY
WHERE cash_memo = @cash_memo
	AND item_code = @item_code";
        private const String SQL_MAX_WARRENTY =
        @"SELECT ISNULL( max(warranty_id),IDENT_CURRENT( 'XX_EXTENDED_WARRANTY' )) as warranty_number
FROM dbo.XX_EXTENDED_WARRANTY";
        private const String SQL_COUNT_PAID_WARRENTY =
        @"select COUNT (warranty_id) from dbo.XX_EXTENDED_WARRANTY
where payment_cash_memo = @payment_cash_memo";
        private const String SQL_DELETE_WARRENTY =@"delete XX_EXTENDED_WARRANTY
where warranty_number = @warranty_number";
        private const String SQL_COUNTRIES =
        @"select distinct NAME from COUNTRY order by NAME";
        private const String SQL_ITEM =
        @"SELECT ITEMBARCODE,MST.NAMEALIAS,RTL.ITEMID,PRICE
FROM (
	SELECT DATAAREAID
		,ITEMID
		,MIN(PRICE) PRICE
	FROM INVENTTABLEMODULE
    WHERE MODULETYPE = 2
	GROUP BY DATAAREAID
		,ITEMID
	) AS RTL
INNER JOIN INVENTTABLE MST ON RTL.ITEMID = MST.ITEMID
	AND RTL.DATAAREAID = MST.DATAAREAID
INNER JOIN INVENTITEMBARCODE BAR ON RTL.ITEMID = BAR.ITEMID
	AND RTL.DATAAREAID = BAR.DATAAREAID
WHERE RTL.ITEMID = @ITEMID
	OR BAR.ITEMBARCODE = @ITEMBARCODE
";
        private const String SQL_INSERT_WARRENTY =
        @"INSERT INTO XX_EXTENDED_WARRANTY (
	warranty_number
	,show_room
	,cash_memo
	,item_code
	,item_desc
	,serial_number
	,retail_price
	,warranty_years
	,bill_total
	,customer_name
	,customer_email
	,customer_phone
	,customer_address
    ,payment_cash_memo
    ,country
	)
VALUES (
	@warranty_number
	,@show_room
	,@cash_memo
	,@item_code
	,@item_desc
	,@serial_number
	,@retail_price
	,@warranty_years
	,@bill_total
	,@customer_name
	,@customer_email
	,@customer_phone
	,@customer_address
	,@payment_cash_memo
    ,@country
	)";
        public Connection()
        {
            POSConnection = new SqlConnection(CONNECTION_STRING);
        }
        
        internal Reciept Reciept(string RecieptNumber,string Selection)
        {
            Reciept Reciept = null;
            if (POSConnection.State != System.Data.ConnectionState.Open)
            {
                POSConnection.Open();
                SqlCommand command = new SqlCommand(SQL_RECIEPT_DETAILS, POSConnection);
                command.Parameters.AddWithValue("@RECEIPTID", RecieptNumber);
                command.Parameters.AddWithValue("@SELECTION", Selection);
                SqlDataReader reader = command.ExecuteReader();
                RecieptItem tempItem = null;
                int i = 0;
                while (reader.Read())
                {
                    i++;
                    if (i == 1)
                    {
                        Reciept = new Reciept();
                        Reciept.TransactionID = reader.GetString(0);
                        Reciept.RecieptID = reader.GetString(1);
                        Reciept.Store = reader.GetString(2);
                        Reciept.Staff = reader.GetString(3);
                        Reciept.StaffName = reader.GetString(4);
                        Reciept.TransactionDate = reader.GetDateTime(5);
                    }
                    try
                    {
                        tempItem = new RecieptItem();
                        tempItem.LineNumber = (int)reader.GetDecimal(6);
                        tempItem.ItemId = reader.GetString(7);
                        tempItem.Quantity = (int)reader.GetDecimal(8);
                        tempItem.NetAmount = reader.GetDecimal(9);
                        tempItem.Description = reader.GetString(10);
                        tempItem.Barcode = reader.GetString(11);
                        Reciept.Add(tempItem);
                    }
                    catch (Exception ex) { throw ex; }
                }
                reader.Close();
            }
            return Reciept;
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (POSConnection.State != System.Data.ConnectionState.Closed) POSConnection.Close();

            if (DedicatedConnection!=null && DedicatedConnection.State != System.Data.ConnectionState.Closed) DedicatedConnection.Close();
        }

        #endregion

        internal string ItemId(string Barcode,string TransactionID)
        {
            String ItemId = null;
            if (POSConnection.State != System.Data.ConnectionState.Open)
            {
                POSConnection.Open();
                SqlCommand command = new SqlCommand(SQL_ITEM_ID, POSConnection);
                command.Parameters.AddWithValue("@ITEMBARCODE", Barcode);
                command.Parameters.AddWithValue("@TRANSACTIONID", TransactionID);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ItemId = reader.GetString(0);
                }
                reader.Close();
            }
            return ItemId;
        }

        internal static List<WarretntySettings> WarrentySettings(RecieptItem Item)
        {
            List<WarretntySettings> WarrentySettingsList = new List<WarretntySettings>();
            if (POSConnection.State != System.Data.ConnectionState.Open)
            {
                POSConnection.Open();
                SqlCommand command = new SqlCommand(SQL_WARRENTY_SETTINGS, POSConnection);
                command.Parameters.AddWithValue(@"@ITEMID", Item.ItemId);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    WarrentySettingsList.Add(new
                    WarretntySettings(){NumberOfYears = reader.GetInt32(0),
                        WarrentyPercentage=reader.GetInt32(1),
                        Brand = reader.GetInt32(2),
                        PaymentItem = reader.GetString(3)
                    }   
                        );
                }
                reader.Close();
            }
            return WarrentySettingsList;
        }

        internal static int WarrentyCount(string RecieptId, string ItemId)
        {
            int count = 0;
            if (POSConnection.State != System.Data.ConnectionState.Open)
            {
                POSConnection.Open();
                SqlCommand command = new SqlCommand(SQL_WARRENTY_COUNT, POSConnection);
                command.Parameters.AddWithValue("@cash_memo", RecieptId);
                command.Parameters.AddWithValue("@item_code", ItemId);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    count = reader.GetInt32(0);
                }
                reader.Close();
            }
            return count;
        }

        internal void BeginTransaction()
        {
            this.DedicatedConnection = new SqlConnection(CONNECTION_STRING);
            this.DedicatedConnection.Open();
            this.DedicatedConnectionTransaction = this.DedicatedConnection.BeginTransaction();
        }

        public SqlConnection DedicatedConnection { get; set; }

        public SqlTransaction DedicatedConnectionTransaction { get; set; }

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

        internal void Delete(string WarrentyNumber)
        {
            SqlCommand command = new SqlCommand(SQL_DELETE_WARRENTY, this.DedicatedConnection);
            command.Parameters.AddWithValue(@"@warranty_number", WarrentyNumber);
            try
            {
                command.Transaction = DedicatedConnectionTransaction;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal string Insert(WarrentyItem x, string CashMemo, string CustomerName, string Email, string Phone, string Address, String Country)
        {
            int nextWarrenty = GetNextWarrenty(this.DedicatedConnection,this.DedicatedConnectionTransaction);
            string nextWarrentyNumber = CashMemo + "-" + nextWarrenty.ToString("0000000");
            SqlCommand command = new SqlCommand(SQL_INSERT_WARRENTY, DedicatedConnection);
            command.Parameters.Clear();
            command.Parameters.AddWithValue(@"@warranty_number", nextWarrentyNumber);
            command.Parameters.AddWithValue(@"@show_room", x.PaymentReciept.Store);
            command.Parameters.AddWithValue(@"@cash_memo", CashMemo);
            command.Parameters.AddWithValue(@"@item_code", x.ItemId);
            command.Parameters.AddWithValue(@"@item_desc", x.Description);
            command.Parameters.AddWithValue(@"@serial_number", x.SerialNumber);
            command.Parameters.AddWithValue(@"@retail_price", x.NetAmount/x.Quantity);
            command.Parameters.AddWithValue(@"@warranty_years", x.NumberOfYears);
            command.Parameters.AddWithValue(@"@bill_total", x.WarrentyAmount);
            command.Parameters.AddWithValue(@"@customer_name", CustomerName);
            command.Parameters.AddWithValue(@"@customer_email", Email);
            command.Parameters.AddWithValue(@"@customer_phone", Phone);
            command.Parameters.AddWithValue(@"@customer_address", Address);
            command.Parameters.AddWithValue(@"@payment_cash_memo", x.PaymentReciept.RecieptID);
            command.Parameters.AddWithValue(@"@country", Country);
            command.Transaction = DedicatedConnectionTransaction;
            command.ExecuteNonQuery();
            command.CommandText = SQL_INSERT_REPLICATION;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Parameters", @"warranty_number='" +nextWarrentyNumber+ "'");
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
            x.WarrentyNumber = nextWarrentyNumber;
            return nextWarrentyNumber;
        }

        private static int GetNextWarrenty(SqlConnection Connection, SqlTransaction Transaction)
        {

            int maxWarrenty = 0;
            if (Connection.State != System.Data.ConnectionState.Open)
            {
                Connection.Open();
            }
            SqlCommand command = new SqlCommand(SQL_MAX_WARRENTY, Connection);
            command.Transaction = Transaction;
            try
            {
                maxWarrenty = (int)command.ExecuteScalar();
            }
            catch (Exception)
            {
            }
            return maxWarrenty + 1;
        }

        internal static int WarretyPaymentCount(Reciept PaymentReciept)
        {

            int count = 0;
            if (POSConnection.State != System.Data.ConnectionState.Open)
            {
                POSConnection.Open();
                SqlCommand command = new SqlCommand(SQL_COUNT_PAID_WARRENTY, POSConnection);
                command.Parameters.AddWithValue("@payment_cash_memo", PaymentReciept.RecieptID);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    count = reader.GetInt32(0);
                }
                reader.Close();
            }
            return count;
        }

        internal static List<string> Countries()
        {
            try
            {
                List<string> countries = new List<string>();
                if (POSConnection.State != System.Data.ConnectionState.Open)
                {
                    POSConnection.Open();
                    SqlCommand command = new SqlCommand(SQL_COUNTRIES, POSConnection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        countries.Add(reader.GetString(0));
                    }
                    reader.Close();
                }
            return countries;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal static RecieptItem Item(string ItemSearch)
        {
            RecieptItem Item = null;
            if (POSConnection.State != System.Data.ConnectionState.Open)
            {
                POSConnection.Open();
                SqlCommand command = new SqlCommand(SQL_ITEM, POSConnection);
                command.Parameters.AddWithValue("@ITEMID",ItemSearch.Trim());
                command.Parameters.AddWithValue("@ITEMBARCODE",ItemSearch.Trim());
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Item = new RecieptItem() { Barcode=reader.GetString(0),
                    Description=reader.GetString(1),
                    ItemId=reader.GetString(2),
                    LineNumber=1,
                    NetAmount=reader.GetDecimal(3),
                    PaymentItem="",
                    PaymentUsage=0,
                    Quantity=1};
                }
                reader.Close();
            }
            return Item;
        }

        internal static Warranty Warrenties(int Start,
            int End,
            string LocationFilter,
            String WarrentyFilter,
            String RecieptFilter,
            String EmailFilter,
            String HasErrorsFilter)
        {
            String SQLQuery = SQL_SELECT_WARRENTY;
            const String WHERE = " WHERE ";
            const String AND = " AND ";
            bool andFlag = false;
            if (LocationFilter != null || 
                WarrentyFilter != null || 
                RecieptFilter != null || 
                EmailFilter != null || 
                HasErrorsFilter != null)
            {
                SQLQuery = String.Concat(SQLQuery, WHERE);
            }

            if (LocationFilter != null)
            {
                SQLQuery = String.Concat(SQLQuery,
                    andFlag ?
                     AND + " show_room = '" + LocationFilter+"'" :
                     " show_room = '" + LocationFilter + "'");
                andFlag = true;
            }

            if (WarrentyFilter != null)
            {
                SQLQuery = String.Concat(SQLQuery,
                    andFlag ?
                     AND + " warranty_number = '" + WarrentyFilter + "'" :
                     " warranty_number = '" + WarrentyFilter + "'");
                andFlag = true;
            }

            if (RecieptFilter != null)
            {
                SQLQuery = String.Concat(SQLQuery,
                    andFlag ?
                     AND + " cash_memo = '" + RecieptFilter + "'" :
                     " cash_memo = '" + RecieptFilter + "'");
            }

            if (EmailFilter != null)
            {
                SQLQuery = String.Concat(SQLQuery,
                    andFlag ?
                     AND + " customer_email = '" + EmailFilter :
                     " customer_email = '" + EmailFilter);
                andFlag = true;
            }

            if (HasErrorsFilter != null)
            {
                SQLQuery = String.Concat(SQLQuery,
                    andFlag ?
                     AND + " LEN([dbo].[EXTENDED_WARRENTY_ERROR](cash_memo,payment_cash_memo))>0 " :
                     " LEN([dbo].[EXTENDED_WARRENTY_ERROR](cash_memo,payment_cash_memo))>0 ");
                andFlag = true;
            }

            Warranty warrenty = null;
            if (POSConnection.State != System.Data.ConnectionState.Open)
            {
                POSConnection.Open();
                SqlCommand command = new SqlCommand(SQLQuery, POSConnection);
                WarrentyItem temp = new WarrentyItem();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var warranty_id = reader.GetValue(0);
                    var warranty_number = reader.GetValue(1);
                    var show_room = reader.GetValue(2);
                    var cash_memo = reader.GetValue(3);
                    var item_code = reader.GetValue(4);
                    var item_desc = reader.GetValue(5);
                    var serial_number = reader.GetValue(6);
                    var retail_price = reader.GetValue(7);
                    var warranty_years = reader.GetValue(8);
                    var bill_total = reader.GetValue(9);
                    var issued_date = reader.GetValue(10);
                    var customer_name = reader.GetValue(11);
                    var customer_email = reader.GetValue(12);
                    var customer_phone = reader.GetValue(13);
                    var customer_address = reader.GetValue(14);
                    var payment_cash_memo = reader.GetValue(15);
                    var country = reader.GetValue(16);
                    var error_message = reader.GetValue(17);
                    if (warrenty == null)
                        warrenty = new Warranty()
                        {
                        };

                    temp = new WarrentyItem()
                    {
                        WarrentyNumber = warranty_number.ToString(),
                        CustomerName = customer_name.ToString(),
                        ItemId = item_code.ToString(),
                        Description = item_desc.ToString(),
                        IssuedDate = DateTime.Parse(issued_date.ToString()),
                        SerialNumber = serial_number.ToString(),
                        Email = customer_email.ToString(),
                        Phone = customer_phone.ToString(),
                        Address = customer_address.ToString(),
                        WarrentyAmount = Int32.Parse(bill_total.ToString()),
                        PaymentReciept = DataProvider.GetCashMemo(payment_cash_memo.ToString(), "ALL"),
                        Reciept = DataProvider.GetCashMemo(cash_memo.ToString(), "ALL"),
                        RecieptID = cash_memo.ToString(),
                        NumberOfYears = Int32.Parse(warranty_years.ToString()),
                        ErrorMessage=error_message.ToString()
                    };
                    warrenty.Add(temp);
                }
                reader.Close();
            }
            return warrenty;
        }

        internal static Warranty Warrenties(bool Updated)
        {
            Warranty warrenty = new Warranty();
            if (POSConnection.State != System.Data.ConnectionState.Open)
            {
                POSConnection.Open();
                SqlCommand command = new SqlCommand(SQL_SELECT_WARRENTY, POSConnection);
                WarrentyItem temp = new WarrentyItem();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var warranty_id = reader.GetValue(0);
                    var warranty_number = reader.GetValue(1);
                    var show_room = reader.GetValue(2);
                    var cash_memo = reader.GetValue(3);
                    var item_code = reader.GetValue(4);
                    var item_desc = reader.GetValue(5);
                    var serial_number = reader.GetValue(6);
                    var retail_price = reader.GetValue(7);
                    var warranty_years = reader.GetValue(8);
                    var bill_total = reader.GetValue(9);
                    var issued_date = reader.GetValue(10);
                    var customer_name = reader.GetValue(11);
                    var customer_email = reader.GetValue(12);
                    var customer_phone = reader.GetValue(13);
                    var customer_address = reader.GetValue(14);
                    var payment_cash_memo = reader.GetValue(15);
                    var country = reader.GetValue(16);
                    temp = new WarrentyItem()
                    {
                        WarrentyNumber = warranty_number.ToString(),
                        ItemId = item_code.ToString(),
                        Description = item_desc.ToString(),
                        CustomerName = customer_name.ToString(),
                        PaymentReciept = DataProvider.GetCashMemo(payment_cash_memo.ToString(), "ALL"),
                        Reciept = DataProvider.GetCashMemo(cash_memo.ToString(), "ALL")

                    };
                    warrenty.Add(temp);
                }
                reader.Close();
            }
            return warrenty;
        }

        public const string SQL_INSERT_REPLICATION = @"INSERT INTO [XX_REPLICATIONACTIONS]
           ([Action]
           ,[ObjectName]
           ,[AuditContext]
           ,[Parameters]
           ,[DateCreated]
           ,[DATAAREAID])
     VALUES
           (1
           ,'XX_EXTENDED_WARRANTY'
           ,NEWID()
           ,@Parameters
           ,GETDATE()
           ,'LSR')";

        internal List<string> GetReplications()
        {
            List<string> result = new List<string>();
            if (POSConnection.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    POSConnection.Open();
                    SqlCommand command = new SqlCommand(SQL_SELECT_REPLICATIONS, POSConnection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0));
                    }
                    reader.Close();
                }
                catch (Exception ex)
                { throw ex; }
            }
            return result;
        }

        internal XX_EXTENDED_WARRANTY GetWattenty(String Parameter)
        {
            XX_EXTENDED_WARRANTY warrenty = new XX_EXTENDED_WARRANTY();
            if (POSConnection.State != System.Data.ConnectionState.Open)
            {
                POSConnection.Open();
            }
                SqlCommand command = new SqlCommand(SQL_SELECT_WARRENTY +" where "+Parameter, POSConnection);
                WarrentyItem temp = new WarrentyItem();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    warrenty.warranty_id = reader.GetValue(0);
                    warrenty.warranty_number = reader.GetValue(1);
                    warrenty.show_room = reader.GetValue(2);
                    warrenty.cash_memo = reader.GetValue(3);
                    warrenty.item_code = reader.GetValue(4);
                    warrenty.item_desc = reader.GetValue(5);
                    warrenty.serial_number = reader.GetValue(6);
                    warrenty.retail_price = reader.GetValue(7);
                    warrenty.warranty_years = reader.GetValue(8);
                    warrenty.bill_total = reader.GetValue(9);
                    warrenty.issued_date = reader.GetValue(10);
                    warrenty.customer_name = reader.GetValue(11);
                    warrenty.customer_email = reader.GetValue(12);
                    warrenty.customer_phone = reader.GetValue(13);
                    warrenty.customer_address = reader.GetValue(14);
                    warrenty.payment_cash_memo = reader.GetValue(15);
                    warrenty.country = reader.GetValue(16);
                }
                else { throw new Exception(); }
                reader.Close();
            return warrenty;
        }

        public string SQL_SELECT_REPLICATIONS = "select Parameters from XX_REPLICATIONACTIONS";

        internal void DeleteReplication(string x)
        {
            SqlCommand command = new SqlCommand(SQL_DELETE_REPLICATION, DedicatedConnection);
            command.Parameters.AddWithValue("@Parameters", x);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }
        }


        internal static DataTable DownloadWarrienties(int Start,
            int End,
            string LocationFilter,
            String WarrentyFilter,
            String RecieptFilter,
            String EmailFilter,
            String HasErrorsFilter)
        {
            String SQLQuery = SQL_SELECT_WARRENTY;
            const String WHERE = " WHERE ";
            const String AND = " AND ";
            bool andFlag = false;
            if (LocationFilter != null ||
                WarrentyFilter != null ||
                RecieptFilter != null ||
                EmailFilter != null ||
                HasErrorsFilter != null)
            {
                SQLQuery = String.Concat(SQLQuery, WHERE);
            }

            if (LocationFilter != null)
            {
                SQLQuery = String.Concat(SQLQuery,
                    andFlag ?
                     AND + " show_room = '" + LocationFilter + "'" :
                     " show_room = '" + LocationFilter + "'");
                andFlag = true;
            }

            if (WarrentyFilter != null)
            {
                SQLQuery = String.Concat(SQLQuery,
                    andFlag ?
                     AND + " warranty_number = '" + WarrentyFilter + "'" :
                     " warranty_number = '" + WarrentyFilter + "'");
                andFlag = true;
            }

            if (RecieptFilter != null)
            {
                SQLQuery = String.Concat(SQLQuery,
                    andFlag ?
                     AND + " cash_memo = '" + RecieptFilter + "'" :
                     " cash_memo = '" + RecieptFilter + "'");
            }

            if (EmailFilter != null)
            {
                SQLQuery = String.Concat(SQLQuery,
                    andFlag ?
                     AND + " customer_email = '" + EmailFilter :
                     " customer_email = '" + EmailFilter);
                andFlag = true;
            }

            if (HasErrorsFilter != null)
            {
                SQLQuery = String.Concat(SQLQuery,
                    andFlag ?
                     AND + " LEN([dbo].[EXTENDED_WARRENTY_ERROR](cash_memo,payment_cash_memo))>0 " :
                     " LEN([dbo].[EXTENDED_WARRENTY_ERROR](cash_memo,payment_cash_memo))>0 ");
                andFlag = true;
            }

            DataTable warrenty = new DataTable();
            if (POSConnection.State != System.Data.ConnectionState.Open)
            {
                POSConnection.Open();
                SqlCommand command = new SqlCommand(SQLQuery, POSConnection);
                WarrentyItem temp = new WarrentyItem();
                using(SqlDataAdapter adaptor = new SqlDataAdapter(command))
                {
                    adaptor.Fill(warrenty);
                }

            }
            return warrenty;
        }

        public const string SQL_DELETE_REPLICATION = "DELETE FROM XX_REPLICATIONACTIONS WHERE Parameters = @Parameters";
   }

    struct XX_EXTENDED_WARRANTY
    {
        public Object warranty_id;// reader.GetValue(0);
        public Object warranty_number;// reader.GetValue(1);
        public Object show_room;// reader.GetValue(2);
        public Object cash_memo;// reader.GetValue(3);
        public Object item_code;// reader.GetValue(4);
        public Object item_desc;// reader.GetValue(5);
        public Object serial_number;// reader.GetValue(6);
        public Object retail_price;// reader.GetValue(7);
        public Object warranty_years;// reader.GetValue(8);
        public Object bill_total;// reader.GetValue(9);
        public Object issued_date;// reader.GetValue(10);
        public Object customer_name;// reader.GetValue(11);
        public Object customer_email;// reader.GetValue(12);
        public Object customer_phone;// reader.GetValue(13);
        public Object customer_address;// reader.GetValue(14);
        public Object payment_cash_memo;// reader.GetValue(15);
        public Object country;// reader.GetValue(16);

        public const String SQL_INSERT = @"INSERT INTO XX_EXTENDED_WARRANTY
           (warranty_number
           ,show_room
           ,cash_memo
           ,item_code
           ,item_desc
           ,serial_number
           ,retail_price
           ,warranty_years
           ,bill_total
           ,issued_date
           ,customer_name
           ,customer_email
           ,customer_phone
           ,customer_address
           ,payment_cash_memo
           ,country)
     VALUES
           (@warranty_number
           ,@show_room
           ,@cash_memo
           ,@item_code
           ,@item_desc
           ,@serial_number
           ,@retail_price
           ,@warranty_years
           ,@bill_total
           ,@issued_date
           ,@customer_name
           ,@customer_email
           ,@customer_phone
           ,@customer_address
           ,@payment_cash_memo
           ,@country)";
    }

    struct XX_POS_CUSTOMERS
    {
        public object customer_id { get; set; }

        public object customer_name { get; set; }

        public object customer_email { get; set; }

        public object customer_phone_number { get; set; }

        public object customer_country { get; set; }

        public const string DLL =
@"IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[XX_POS_CUSTOMERS]') AND type in (N'U'))
BEGIN
CREATE TABLE [XX_POS_CUSTOMERS](
	[customer_id] [int] IDENTITY(1,1) NOT NULL,
	[customer_name] [nvarchar](25) NOT NULL,
	[customer_email] [nvarchar](50) NULL,
	[customer_phone_number] [nvarchar](15) NULL,
	[customer_country] [nvarchar](25) NOT NULL,
    [address] text
 CONSTRAINT [PK_XX_POS_CUSTOMERS] PRIMARY KEY CLUSTERED 
(
	[customer_id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END";
        
        public const string SELECT =
@"SELECT [customer_id]
	,[customer_name]
	,[customer_email]
	,[customer_phone_number]
	,[customer_country]
    ,[address]
FROM [XX_POS_CUSTOMERS]
WHERE [customer_email] LIKE @customer_email
	OR [customer_name] LIKE @customer_name
	OR [customer_phone_number] LIKE @customer_phone_number";
        
        public const string INSERT =
@"INSERT INTO [XX_POS_CUSTOMERS] (
	[customer_name]
	,[customer_email]
	,[customer_phone_number]
	,[customer_country]
    ,[address]
	)
VALUES (
	@customer_name
	,@customer_email
	,@customer_phone_number
	,@customer_country
    ,@address
	)";
    }
}
