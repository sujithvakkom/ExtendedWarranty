using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using LSExtendedWarrenty.Properties;

namespace LSExtendedWarrenty.AppBase
{
    public static class SettingsProvider
    {
        static readonly string PasswordHash = "P@@Sw0rd";
        static readonly string SaltKey = "S@LT&KEY";
        static readonly string VIKey = "@1B2c3D4e5F6g7H8";

        public static String GetDataSource()
        {
            return Decrypt(LSExtendedWarrenty.Properties.Settings.Default.DataSource);
        }
        public static String GetDatabase()
        {
            return Decrypt(LSExtendedWarrenty.Properties.Settings.Default.Database);
        }
        public static String GetUserName()
        {
            return Decrypt(LSExtendedWarrenty.Properties.Settings.Default.UserName);
        }
        public static String GetPassword()
        {
            return Decrypt(LSExtendedWarrenty.Properties.Settings.Default.Password);
        }
        public static String GetDefaultPrinter()
        {
            return Decrypt(LSExtendedWarrenty.Properties.Settings.Default.DefaultPrinterName);
        }

        public static String GetHQDataSource()
        {
            return Decrypt(LSExtendedWarrenty.Properties.Settings.Default.HQDataSource);
        }
        public static String GetHQDatabase()
        {
            return Decrypt(LSExtendedWarrenty.Properties.Settings.Default.HQDatabase);
        }
        public static String GetHQUserName()
        {
            return Decrypt(LSExtendedWarrenty.Properties.Settings.Default.HQUserName);
        }
        public static String GetHQPassword()
        {
            return Decrypt(LSExtendedWarrenty.Properties.Settings.Default.HQPassword);
        }

        public static void SetDataSource(String Key)
        {
            Settings.Default.DataSource = Encrypt(Key);
            Settings.Default.Save();
        }
        public static void SetDatabase(String Key)
        {
            Settings.Default.Database = Encrypt(Key);
            Settings.Default.Save();
        }
        public static void SetUserName(String Key)
        {
            Settings.Default.UserName = Encrypt(Key);
            Settings.Default.Save();
        }
        public static void SetPassword(String Key)
        {
            Settings.Default.Password = Encrypt(Key);
            Settings.Default.Save();
        }
        public static void SetDefaultPrinter(String Key)
        {
            Settings.Default.DefaultPrinterName = Encrypt(Key);
            Settings.Default.Save();
        }

        public static void SetHQDataSource(String Key)
        {
            Settings.Default.HQDataSource = Encrypt(Key);
            Settings.Default.Save();
        }
        public static void SetHQDatabase(String Key)
        {
            Settings.Default.HQDatabase = Encrypt(Key);
            Settings.Default.Save();
        }
        public static void SetHQUserName(String Key)
        {
            Settings.Default.HQUserName = Encrypt(Key);
            Settings.Default.Save();
        }
        public static void SetHQPassword(String Key)
        {
            Settings.Default.HQPassword = Encrypt(Key);
            Settings.Default.Save();
        }

        public static string Encrypt(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }

        public static string Decrypt(string encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }

    }
}