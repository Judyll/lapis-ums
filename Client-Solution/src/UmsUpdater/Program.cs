using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

namespace UmsUpdater
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Looking for running instance
            Process runningInstance = ProcessInstance.GetRunningInstance();

            if (runningInstance != null)
            {
                MessageBox.Show("University Management Updater is already running.", "Error");
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
        }
    }
}