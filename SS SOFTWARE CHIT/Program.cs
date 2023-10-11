using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SS_SOFTWARE_CHIT
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool connection = NetworkInterface.GetIsNetworkAvailable();

            if (connection)
            {
                WhatsApp app = new WhatsApp();
                Mutex mutex = new System.Threading.Mutex(false, "SS SOFTWARE");
                try
                {
                    if (mutex.WaitOne(0, false))
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        DateTime dt1 = DateTime.Now;
                        DateTime dt2 = DateTime.Parse("01/04/2024");
                        if (dt1.Date >= dt2.Date)
                        {
                            MessageBox.Show("Application Expiried,Renew The License???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // Run the application

                            Application.Run(new FRM_LOGIN(app));
                        }
                    }
                    else
                    {
                        MessageBox.Show("SS SOFTWARE IS ALREADY RUNNING!!!", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                finally
                {
                    if (mutex != null)
                    {
                        mutex.Close();
                        mutex = null;
                    }
                }
            }
            else
            {
                MessageBox.Show("TURN ON THE INTERNET CONNECTION???", "SS SOFTWARE", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
