using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

namespace Test
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            try
            {
                Process.GetProcessById(int.Parse(args[0]))
                     .WaitForExit();
            }
            catch (Exception)
            {
                MessageBox.Show("Updating...","Update");
            }
            try
            {
                System.IO.File.Copy("Repository\\LSExtendedWarrenty.dll", "LSExtendedWarrenty.dll", true);
                //System.IO.File.Copy("Repository\\Log.txt", "Log.txt", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occurred While Updating. "
                        + Environment.NewLine
                        + "Please Check the Error Message." + Environment.NewLine
                        + "Please take a screen shot and send to System Administrator" + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            Application.Exit();
            Process.Start("POSAssistance.exe");
        }
    }
}
