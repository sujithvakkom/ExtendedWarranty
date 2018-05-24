using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;

namespace POSAssistance
{
    static class Program
    {/// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Assembly assembly = Assembly.LoadFrom("LSExtendedWarrenty.dll");
            Version ver = assembly.GetName().Version;
    

        /*
            bool x = false;
            try
            {
                x = AppUpdator.CheckingUpdate.GetIsConfigured();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (!x)
            {
                try
                {
                    var window = new AppUpdator.Initializer();
                    window.EnableManualConfig = false;
                    window.ShowDialog();
                    if (window.DialogResult == DialogResult.OK)
                    {
                        if (window.SettingsLocationSettings != null && window.SettingsServerSettings != null)
                        {
                            LSExtendedWarrenty.AppBase.SettingsProvider.SetDataSource(window.SettingsLocationSettings.ServerAddress);
                            LSExtendedWarrenty.AppBase.SettingsProvider.SetDatabase(window.SettingsLocationSettings.Database);
                            LSExtendedWarrenty.AppBase.SettingsProvider.SetUserName(window.SettingsLocationSettings.User);
                            LSExtendedWarrenty.AppBase.SettingsProvider.SetPassword(window.SettingsLocationSettings.Password);
                            LSExtendedWarrenty.AppBase.SettingsProvider.SetHQDataSource(window.SettingsServerSettings.ServerAddress);
                            LSExtendedWarrenty.AppBase.SettingsProvider.SetHQDatabase(window.SettingsServerSettings.Database);
                            LSExtendedWarrenty.AppBase.SettingsProvider.SetHQUserName(window.SettingsServerSettings.User);
                            LSExtendedWarrenty.AppBase.SettingsProvider.SetHQPassword(window.SettingsServerSettings.Password);

                            AppUpdator.CheckingUpdate.SetIsConfigured(true);
                        }
                    }
                    if (window.EnableManualConfig)
                    {
                        Application.Run(new LSExtendedWarrenty.FormMaintance());
                        AppUpdator.CheckingUpdate.SetIsConfigured(true);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                  
                Application.Run(window);
            }
            MessageBox.Show("I am here." + x.ToString());
            try{
                x = AppUpdator.CheckingUpdate.HasUpdate();
            }
            catch(Exception ex){
                x=false;
                MessageBox.Show(ex.Message);
            }
            if (!x)
            {

            }
            else
            {
                UpdateFile();
            }

            AppUpdator.CheckingUpdate.SetIsConfigured(true);

            //Application.Run(new LSExtendedWarrenty.FormMaintance());


        */

            if (args.Length == 0)
            {
                var window = new LSExtendedWarrenty.FormExtendedWarrenty();
                window.Text = "Extended Warranty Version: " + ver.ToString();
                Application.Run(window);
            }
            else
            {
                String Arg = args[0];
                if (Arg == "MAINTANCE")
                {
                    Application.Run(new LSExtendedWarrenty.FormMaintance());
                }
            }
        }

        static void UpdateFile()
        {

            if (AppUpdator.CheckingUpdate.HasUpdate())
            {
                var x = Process.GetCurrentProcess().Id.ToString();
                System.Diagnostics.Process.Start("Test.exe", x);
            }
        }
    }
}
