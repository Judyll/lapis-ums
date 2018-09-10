using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;

namespace UmsUpdater
{
    public class ProcessInstance
    {
         /// <summary>
        /// Looks for other instance that the app is already running
        /// </summary>
        /// <returns></returns>
        public static Process GetRunningInstance()
        { 
            //get the current proccessa and all the procces with the same name
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);

            //look for the same name to all the processes
            foreach (Process p in processes)
            {
                //Ignore current Process
                if (p.Id != current.Id)
                {
                    if (UserInstance.IsSameUser(p.MainWindowHandle))
                    {
                        //Return the other process instance.
                        return p;
                    }
                }                
            }

            //look for proccess if it has two instance already
            Process[] pTwoInstance = Process.GetProcesses();
            Int32 count = 0;

            foreach (Process p in pTwoInstance)
            {
                if (String.Equals(p.ProcessName, current.ProcessName))
                {
                    count++;

                    if (count > 1)
                    {
                        return p;
                    }
                }
            }           
            
            return null;
        }//-----------------------

         /// <summary>
        /// Bring a running instance to the foreground
        /// </summary>
        /// <param name="instance">the Process</param>
        public static void Show(Process instance)
        {
            
            //Make sure the window is not minimized or maximized
            User32.ShowWindowAsync(instance.MainWindowHandle, (int)W32_WS.WS_SHOWNORMAL);

            //Set the foreground window to be the running instancee 
            User32.SetForegroundWindow(instance.MainWindowHandle);
        }

    }
}
