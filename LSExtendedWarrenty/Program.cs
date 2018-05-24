using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LSExtendedWarrenty
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //new LSExtendedWarrenty.AppBase.WarrentyItem().GetFormatedRtf(null);
            Application.Run(new FormExtendedWarrenty());
        }
    }
}
