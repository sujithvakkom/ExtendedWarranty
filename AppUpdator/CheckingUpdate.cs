using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Net;
using AppUpdator.Properties;
using System.IO;

namespace AppUpdator
{
    public partial class CheckingUpdate : Form
    {
        public static bool GetIsConfigured()
        {
            return Properties.Settings.Default.IsConfigured;
        }


        public static void SetIsConfigured(bool isConfigured)
        {
            Properties.Settings.Default.IsConfigured = isConfigured;
            Properties.Settings.Default.Save();
        }

        public CheckingUpdate()
        {
            InitializeComponent();
        }

        public static bool HasUpdate()
        {
            GetUpdate();
            Assembly CurentAssembly = Assembly.LoadFrom("LSExtendedWarrenty.dll");
            Version CurrentVersion = CurentAssembly.GetName().Version;

            Assembly NewAssembly;
            Version NewVersion;
            try
            {
                NewAssembly = Assembly.LoadFrom("Repository\\LSExtendedWarrenty.dll");
                NewVersion = NewAssembly.GetName().Version;
            }
            catch (System.IO.FileNotFoundException)
            {
                return false;
            }
            try
            {
                int CurrentVersionVal =
                Int32.Parse(CurrentVersion.ToString().Replace(".", ""));
                int NewVersionVal =
                Int32.Parse(NewVersion.ToString().Replace(".", ""));
                if (CurrentVersionVal < NewVersionVal)
                {
                    return true;
                }
            }
            catch (Exception) { return false; } return false;
        }

        private static void GetUpdate()
        {

            // Get the object used to communicate with the server.
            String RequestString = "ftp://" + Settings.Default.REPOSITORY + Settings.Default.REPOSITORY_LOCATION + "/LSExtendedWarrenty";
            FtpWebRequest requestFileDownload = (FtpWebRequest)WebRequest.Create(RequestString);
            requestFileDownload.Method = WebRequestMethods.Ftp.DownloadFile; 
            requestFileDownload.UsePassive = false;
            // This example assumes the FTP site uses anonymous logon.
            requestFileDownload.Credentials = new NetworkCredential(Settings.Default.REPOSITORY_USER, Settings.Default.REPOSITORY_PASSWORD);
            try
            {
                FtpWebResponse responseFileDownload = (FtpWebResponse)requestFileDownload.GetResponse();

                Stream responseStream = responseFileDownload.GetResponseStream();
                FileStream writeStream = new FileStream("Repository" + "\\" + "LSExtendedWarrenty.dll", FileMode.Create);

                int Length = 2048;
                Byte[] buffer = new Byte[Length];
                int bytesRead = responseStream.Read(buffer, 0, Length);

                while (bytesRead > 0)
                {
                    writeStream.Write(buffer, 0, bytesRead);
                    bytesRead = responseStream.Read(buffer, 0, Length);
                }
                responseStream.Close();
                writeStream.Close();

                requestFileDownload = null;
                responseFileDownload = null;
            }
            catch (WebException ex)
            { MessageBox.Show(
                "Error Occurred While Downloading. "
                        + Environment.NewLine
                        + "Please Check the Error Message." + Environment.NewLine
                        + "Please take a screen shot and send to System Administrator" + Environment.NewLine + Environment.NewLine
                        + 
                ((FtpWebResponse)ex.Response).StatusDescription,"Error Occurred"); }

        }
    }
}
