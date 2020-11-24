using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SignalR_Client
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
            if (Properties.Settings.Default.access_token != "")
            {
                Application.Run(new Form1());
            }
            else
            {
                Application.Run(new LoginForm());
            }
        }
    }
}
