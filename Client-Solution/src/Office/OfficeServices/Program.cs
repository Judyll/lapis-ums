using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace OfficeServices
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {                
                //registers the tcp channel
                TcpChannel channel = new TcpChannel();
                ChannelServices.RegisterChannel(channel, false);
                //--------------------------               

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                //gets the user information
                using (RemoteClient.RemCntAdministratorManager remClient = new RemoteClient.RemCntAdministratorManager())
                {
                    //sets the user information
                    CommonExchange.SysAccess userInfo = new CommonExchange.SysAccess();
                    //--------------------------

                    //Int32 userAccess = 1;

                    //if (userAccess == 1)
                    //{
                    //    userInfo.UserName = "Francis";
                    //    userInfo.Password = "1Delfino9";
                    //}
                    //else if (userAccess == 2)
                    //{
                    //    userInfo.UserName = "angiezam";
                    //    userInfo.Password = "angiezam";
                    //}
                    //else if (userAccess == 3)
                    //{
                    //    userInfo.UserName = "Machitar";
                    //    userInfo.Password = "Machitar";
                    //}

                    //Boolean isExpired = false;

                    //if (remClient.AuthenticateSystemUser(ref userInfo, ref isExpired))
                    //{
                    //    userInfo.NetworkInformation = RemoteClient.ProcStatic.GetNetworkInformation();

                    //    Int32 process = 8;

                    //    if (process == 1)
                    //    {
                    //        SubjectSchedulingLogic scheduleManager = new SubjectSchedulingLogic(userInfo);

                    //        Application.Run(new SubjectSchedule(userInfo, scheduleManager));
                    //    }
                    //    else if (process == 2)
                    //    {
                    //        //SubjectSchedulingLogic scheduleManager = new SubjectSchedulingLogic(userInfo);

                    //        //Application.Run(new SubjectScheduleCreate(userInfo, scheduleManager));
                    //    }
                    //    else if (process == 3)
                    //    {
                    //        SubjectSchedulingLogic scheduleManager = new SubjectSchedulingLogic(userInfo);
                    //        //scheduleManager.SelectByDateStartEndScheduleInformationDetails(userInfo, "01/01/2008", "12/01/2008", false);

                    //        //Application.Run(new SubjectScheduleUpdate(userInfo, scheduleManager.GetDetailsScheduleInformation("SYSSCH000000001"),
                    //        //    scheduleManager));
                    //    }
                    //    else if (process == 4)
                    //    {
                    //        Application.Run(new SubjectSchedulingManager(userInfo));
                    //    }
                    //    else if (process == 5)
                    //    {
                    //        try
                    //        {
                    //            Application.Run(new TeacherLoadingManager(userInfo));
                    //        }
                    //        catch (Exception ex)
                    //        {
                    //            RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Teacher Loading Manager");
                    //        }
                    //    }
                    //    else if (process == 6)
                    //    {
                    //        try
                    //        {
                    //            Application.Run(new AuxiliaryInformationManager(userInfo));
                    //        }
                    //        catch (Exception ex)
                    //        {
                    //            RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Auxiliary Service Information Manager");
                    //        }
                    //    }
                    //    else if (process == 7)
                    //    {
                    //        try
                    //        {
                    //            Application.Run(new AuxiliarySchedulingManager(userInfo));
                    //        }
                    //        catch (Exception ex)
                    //        {
                    //            RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Auxiliary Service Information Manager");
                    //        }
                    //    }
                    //    else if (process == 8)
                    //    {
                    //        try
                    //        {
                    //            Application.Run(new StudentLoadingManager(userInfo));
                    //        }
                    //        catch (Exception ex)
                    //        {
                    //            RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Student Loading Manager\n\n" + ex.Message, "Error Loading");
                    //        }
                    //    }
                    //    else if (process == 9)
                    //    {
                    //        try
                    //        {
                    //            Application.Run(new ScholarshipManager(userInfo));
                    //        }
                    //        catch (Exception ex)
                    //        {
                    //            RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Scholarship Manager\n\n" + ex.Message, "Error Loading");
                    //        }
                    //    }
                    //}
                }//-------------------------                
            }
            catch (Exception err)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(err.Message, "System Error");
            }
            finally
            {
                Application.Exit();
            }
           
        }
    }
}