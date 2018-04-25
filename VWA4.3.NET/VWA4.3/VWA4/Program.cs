using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Windows.Forms;

namespace VWA4
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
            //Application.Run(new VWAMain());
            VWA4.SingleApplication.Run(new VWAMain());
        }
    }
}
