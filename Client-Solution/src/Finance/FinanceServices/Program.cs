using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace FinanceServices
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

                    Int32 userAccess = 2;

                    if (userAccess == 1)
                    {
                        userInfo.UserName = "Francis";
                        userInfo.Password = "1Delfino9";
                    }
                    else if (userAccess == 2)
                    {
                        userInfo.UserName = "earlac";
                        userInfo.Password = "november";
                    }

                    Boolean isExpired = false;

                    if (remClient.AuthenticateSystemUser(ref userInfo, ref isExpired))
                    {
                        userInfo.NetworkInformation = RemoteClient.ProcStatic.GetNetworkInformation();

                        Int32 process = 7;

                        if (process == 1)
                        {
                            Application.Run(new StudentManager(userInfo));
                        }
                        else if (process == 2)
                        {
                            StudentLogic studentManager = new StudentLogic(userInfo);

                            //Application.Run(new FinanceServices.StudentGuidance(userInfo, studentManager));
                        }
                        else if (process == 3)
                        {
                            try
                            {
                                Application.Run(new FinanceServices.SchoolFeeManager(userInfo));
                            }
                            catch (Exception ex)
                            {
                                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading School Fee Manager");
                            }
                        }
                        else if (process == 5)
                        {
                            try
                            {
                                StudentLogic studentManager = new StudentLogic(userInfo);

                                Application.Run(new FinanceServices.StudentIdGenerator(userInfo, studentManager));
                            }
                            catch (Exception ex)
                            {
                                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
                            }
                        }
                        else if (process == 6)
                        {
                            //Application.Run(new StudentTab());
                        }
                        else if (process == 7)
                        {
                            Application.Run(new CashieringManager(userInfo));
                        }
                        else if (process == 8)
                        {
                            CashieringLogic casheiringManager = new CashieringLogic(userInfo);

                            Application.Run(new MultipleAdditionalFeeCreate(userInfo, casheiringManager));
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