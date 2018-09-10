using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace CampusAccessServices
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

                    Int32 userAccess = 1;

                    if (userAccess == 1)
                    {
                        userInfo.UserName = "Francis";
                        userInfo.Password = "1Delfino9";
                    }

                    Boolean isExpired = false;

                    if (remClient.AuthenticateSystemUser(ref userInfo, ref isExpired))
                    {
                        userInfo.NetworkInformation = RemoteClient.ProcStatic.GetNetworkInformation();

                        Int32 process = 3;

                        if (process == 1)
                        {
                            try
                            {
                                CampusAccessLogic campusAccessManager = new CampusAccessLogic(userInfo);

                                Application.Run(new CampusAccessManager(userInfo, campusAccessManager, String.Empty));
                            }
                            catch (Exception ex)
                            {
                                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
                            }
                        }
                        else if (process == 2)
                        {
                            try
                            {
                                Application.Run(new AccessPointInformation(userInfo));
                            }
                            catch (Exception ex)
                            {
                                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
                            }
                        }
                        else if (process == 3)
                        {
                            Boolean hasAccess = false;

                            using (SystemLogIn frmLogIn = new SystemLogIn())
                            {
                                frmLogIn.ShowDialog();

                                if (frmLogIn.HasAccess)
                                {
                                    hasAccess = true;
                                    userInfo = frmLogIn.UserInformation;
                                }
                            }

                            if (hasAccess)
                            {
                                Application.Run(new AccessPointInformation(userInfo));
                            }
                        }
                    }
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