using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace RegistrarServices
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
                    ////sets the user information
                    //CommonExchange.SysAccess userInfo = new CommonExchange.SysAccess();
                    ////--------------------------

                    //Int32 userAccess = 1;

                    //if (userAccess == 1)
                    //{
                    //    userInfo.UserName = "Francis";
                    //    userInfo.Password = "1Delfino9";
                    //}


                    //Boolean isExpired = false;

                    //if (remClient.AuthenticateSystemUser(ref userInfo, ref isExpired))
                    //{
                    //    userInfo.NetworkInformation = RemoteClient.ProcStatic.GetNetworkInformation();

                    //    Int32 process = 2;

                    //    if (process == 1)
                    //    {
                    //        Application.Run(new SchoolYearSemesterManager(userInfo));
                    //    }
                    //    else if (process == 2)
                    //    {
                    //        Application.Run(new CourseManager(userInfo));
                    //    }
                    //    else if (process == 3)
                    //    {
                    //        CourseLogic roomSubjectManager = new CourseLogic(userInfo);

                    //        Application.Run(new SubjectCreate(userInfo, roomSubjectManager));
                    //    }
                    //    else if (process == 4)
                    //    {
                    //        Application.Run(new TempNavigator(userInfo));
                    //    }
                    //    else if (process == 5)
                    //    {
                    //        SpecialClassLogic specialManager = new SpecialClassLogic(userInfo);

                    //        Application.Run(new SpecialClassCreate(userInfo, specialManager));
                    //    }
                    //    else if (process == 6)
                    //    {
                    //        Application.Run(new SpecialClassManager(userInfo));
                    //    }
                    //    else if (process == 7)
                    //    {
                    //        Application.Run(new MajorExamScheduleManager(userInfo));
                    //    }
                    //    else if (process == 8)
                    //    {
                    //        try
                    //        {
                    //            Application.Run(new TranscriptManager(userInfo));
                    //        }
                    //        catch (Exception ex)
                    //        {
                    //            RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Transcript Manager\n\n" + ex.Message, "Error Loading");
                    //        }
                    //    }
                    //}
                } //-------------------------
                
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