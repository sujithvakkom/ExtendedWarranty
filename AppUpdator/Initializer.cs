using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AppUpdator
{
    public partial class Initializer : Form
    {
        public Initializer()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                this.SettingsLocationSettings =
                AppUpdator.DataProiver.GetLocationSettings(this.textBoxSettingsServer.Text.Trim(),
                    this.textBoxDatabase.Text.Trim(),
                    this.textBoxUser.Text.Trim(),
                    this.textBoxPassword.Text.Trim(),
                    this.textBoxLoction.Text.Trim());
                this.SettingsLocationSettings.Init();
                List<XX_EXTENDED_SETTINGS> ExtendedWarrentySettings = DataProiver.GetWarrentySettings(this.textBoxSettingsServer.Text.Trim(),
                    this.textBoxDatabase.Text.Trim(),
                    this.textBoxUser.Text.Trim(),
                    this.textBoxPassword.Text.Trim(),
                    this.textBoxLoction.Text.Trim());
                SettingsLocationSettings.UpdateWarrentySettings(ExtendedWarrentySettings);
                this.SettingsServerSettings = new SettingServerSettings()
                {
                    ServerAddress = this.textBoxSettingsServer.Text.Trim(),
                    Database = this.textBoxDatabase.Text.Trim(),
                    User = this.textBoxUser.Text.Trim(),
                    Password = this.textBoxPassword.Text.Trim()
                };
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    ("Error Occurred while Initializing. "
                        + Environment.NewLine
                        + "Please Check the Error Message." + Environment.NewLine
                        + "Please take a screen shot and send to System Administrator" + Environment.NewLine + Environment.NewLine
                        + ex.Message, "Error Occurred.");
            }
            this.Cursor = Cursors.Default;
        }

        public SettingServerSettings SettingsServerSettings { get; set; }

        public LocationSettings SettingsLocationSettings { get; set; }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.SettingsLocationSettings = null;
            this.SettingsServerSettings = null;
            this.Close();
        }

        private void buttonManualConfigure_Click(object sender, EventArgs e)
        {
            this.SettingsLocationSettings = null;
            this.SettingsServerSettings = null;
            EnableManualConfig = true;
            this.Close();
        }

        public bool EnableManualConfig { get; set; }
    }



    public class SettingServerSettings
    {
        public string ServerAddress { get; set; }

        public string Database { get; set; }

        public string User { get; set; }

        public string Password { get; set; }
    }

    public class LocationSettings
    {
        public string ServerAddress { get; set; }

        public string Database { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public void Init()
        {
            
            LocationSettings Settings = new LocationSettings();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = this.ServerAddress;
            builder.InitialCatalog = this.Database;
            builder.UserID = this.User;
            builder.Password = this.Password;
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                SqlCommand Command = new SqlCommand(AppUpdator.Properties.Resources.INIT_SCRIPTS,connection);
                try
                {
                    connection.Open();
                    Command.Transaction = connection.BeginTransaction();
                    Command.ExecuteNonQuery();
                    Command.Transaction.Commit();
                }
                catch (Exception ex) {
                    Command.Transaction.Rollback();
                    MessageBox.Show("Error in Connection. "
                        + Environment.NewLine
                        + "Please Check the Error Message." + Environment.NewLine
                        + "Please take a screen shot and send to System Administrator" + Environment.NewLine + Environment.NewLine
                        + ex.Message,"Error Occurred");
                }
                connection.Close();
            }

        }

        public void UpdateWarrentySettings(List<XX_EXTENDED_SETTINGS> ExtendedWarrentySettings)
        {
            
            LocationSettings Settings = new LocationSettings();
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = this.ServerAddress;
            builder.InitialCatalog = this.Database;
            builder.UserID = this.User;
            builder.Password = this.Password;
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                SqlCommand Command = new SqlCommand(AppUpdator.Properties.Resources.REMOVE_WARRENTY_SETTINGS, connection);
                try
                {
                    connection.Open();
                    Command.Transaction = connection.BeginTransaction();
                    Command.ExecuteNonQuery();
                    Command = new SqlCommand ( INSERT_WARRENTY_SETTINGS, connection,Command.Transaction);
                    foreach (var wSetting in ExtendedWarrentySettings)
                    {
                        Command.Parameters.Clear();
                        Command.Parameters.AddWithValue("@WARRANTY_YEAR", wSetting.WARRANTY_YEAR.ToString());
                        Command.Parameters.AddWithValue("@DISCOUNT_PERCENTATE", wSetting.DISCOUNT_PERCENTATE.ToString());
                        Command.Parameters.AddWithValue("@BRAND", wSetting.BRAND.ToString());
                        //Command.Parameters.AddWithValue("@BRAND_NAME", wSetting.BRAND_NAME.ToString());
                        Command.Parameters.AddWithValue("@ITEMID", wSetting.ITEMID.ToString());
                        Command.ExecuteNonQuery();
                    }
                    Command.Transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (Command.Transaction != null) Command.Transaction.Rollback();
                    throw ex;
                }
            }
        }

        private const string INSERT_WARRENTY_SETTINGS = @"INSERT INTO XX_EXTENDED_SETTINGS (WARRANTY_YEAR ,DISCOUNT_PERCENTATE ,BRAND ,ITEMID) VALUES (@WARRANTY_YEAR ,@DISCOUNT_PERCENTATE ,@BRAND ,@ITEMID)";
    }

    public class DataProiver
    {
        public static LocationSettings GetLocationSettings(string DataSource, string Database, string User, string Password, string Location)
        {
            LocationSettings Settings = null;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = DataSource;
            builder.InitialCatalog = Database;
            builder.UserID = User;
            builder.Password = Password;
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString)){
                SqlCommand Command = new SqlCommand(GET_LOCATION_SETTINGS, connection);
                Command.Parameters.AddWithValue("@loc_code",Location);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = Command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Settings = new LocationSettings();
                            Settings.ServerAddress = reader.GetString(0);
                            Settings.Database = reader.GetString(1);
                            Settings.User = reader.GetString(2);
                            Settings.Password = reader.GetString(3);
                        }
                    }
                }
                catch (Exception ex) { throw ex; }
                finally
                {
                    connection.Close();
                }
                return Settings;
            }
        }

        public static List<XX_EXTENDED_SETTINGS> GetWarrentySettings(string DataSource, string Database, string User, string Password, string Location)
        {
            List<XX_EXTENDED_SETTINGS> Settings = null;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = DataSource;
            builder.InitialCatalog = Database;
            builder.UserID = User;
            builder.Password = Password;
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                SqlCommand Command = new SqlCommand(GET_WARRENTY_SETTINGS, connection);
                //Command.Parameters.AddWithValue("@loc_code", Location);
                try
                {
                    connection.Open();
                    using (SqlDataReader reader = Command.ExecuteReader())
                    {
                        XX_EXTENDED_SETTINGS temp;
                        if (reader.Read()) Settings = new List<XX_EXTENDED_SETTINGS>();
                        do
                        {
                            temp = new XX_EXTENDED_SETTINGS();
                            temp.WARRANTY_YEAR = reader.GetInt32(0);
                            temp.DISCOUNT_PERCENTATE = reader.GetInt32(1);
                            temp.BRAND = reader.GetInt32(2);
                            try
                            {
                                temp.BRAND_NAME = reader.GetString(3);
                            }
                            catch (Exception) { temp.BRAND_NAME = null; }
                            try
                            {
                            temp.ITEMID=reader.GetString(4);
                            }
                            catch (Exception) { temp.ITEMID = null; }
                            Settings.Add(temp);
                        } while
                        (reader.Read());
                    }
                }
                catch (Exception ex) { throw ex; }
                connection.Close();
            }
            return Settings;
        }

        public const string GET_LOCATION_SETTINGS = @"select server_address,db_name,db_user,db_password from XX_LOCATIONS where loc_code = @loc_code";

        public const string GET_WARRENTY_SETTINGS = @"select WARRANTY_YEAR,DISCOUNT_PERCENTATE,BRAND,BRAND_NAME,ITEMID from XX_EXTENDED_SETTINGS";
    }

    public class XX_EXTENDED_SETTINGS
    {
        public int WARRANTY_YEAR { get; set; }

        public int DISCOUNT_PERCENTATE { get; set; }

        public int BRAND { get; set; }

        public string BRAND_NAME { get; set; }

        public string ITEMID { get; set; }
    }
}
