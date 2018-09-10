using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace BaseServices
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
                        userInfo.UserName = "AdminAccess";
                        userInfo.Password = "?@ssw0rd";
                    }
                    else if (userAccess == 2)
                    {
                       
                    }

                    Boolean isExpired = false;

                    if (remClient.AuthenticateSystemUser(ref userInfo, ref isExpired))
                    {
                        userInfo.NetworkInformation = ProcStatic.GetNetworkInformation();

                        Int32 process = 2;

                        if (process == 1)
                        {
                            try
                            {
                                  BaseServicesLogic baseServiceManager = new BaseServicesLogic(userInfo);

                                Application.Run(new PersonInformationCreate(userInfo, baseServiceManager));
                            }
                            catch (Exception ex)
                            {
                                ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
                            }
                        }
                        else if (process == 2)
                        {
                            try
                            {
                                BaseServicesLogic baseServiceManager = new BaseServicesLogic(userInfo);

                                Application.Run(new PersonInformationWithBeneficiaryReference(userInfo));
                            }
                            catch (Exception ex)
                            {
                                ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
                            }
                        }
                        else if (process == 3)
                        {
                            try
                            {
                                BaseServicesLogic baseServiceManager = new BaseServicesLogic(userInfo);

                                Application.Run(new PersonInformationCreate(userInfo, baseServiceManager));
                            }
                            catch (Exception ex)
                            {
                                ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
                            }
                        }
                        else if (process == 4)
                        {
                            try
                            {
                                BaseServicesLogic baseServiceManager = new BaseServicesLogic(userInfo);

                                CommonExchange.Person personInfo = new CommonExchange.Person();

                                Application.Run(new PersonInformationUpdate(userInfo, personInfo, baseServiceManager));
                            }
                            catch (Exception ex)
                            {
                                ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
                            }
                        }
                    }
                }//-------------------------
            }
            catch (Exception err)
            {
                ProcStatic.ShowErrorDialog(err.Message, "System Error");
            }
            finally
            {
                Application.Exit();
            }
        }
    }
}