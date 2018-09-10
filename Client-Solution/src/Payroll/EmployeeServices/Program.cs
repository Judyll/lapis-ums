using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace EmployeeServices
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

                    //userInfo.UserName = "AdminAccess";
                    //userInfo.Password = "?@ssw0rd";

                    Boolean isExpired = false;

                    if (remClient.AuthenticateSystemUser(ref userInfo, ref isExpired))
                    {
                        userInfo.NetworkInformation = RemoteClient.ProcStatic.GetNetworkInformation();  

                        //Int32 process = 3;

                        //if (process == 1)
                        //{
                        //    //EmployeeLogic empManager = new EmployeeLogic(userInfo);

                        //    //Application.Run(new EmployeeCreate(userInfo, empManager));
                        //}
                        //else if (process == 2)
                        //{
                        //    //EmployeeLogic empManager = new EmployeeLogic(userInfo);

                        //    //Application.Run(new EmployeeUpdate(userInfo, empManager, "44444"));
                        //}
                        //else if (process == 3)
                        //{
                        //    Application.Run(new EmployeeManager(userInfo));
                        //}
                        //else if (process == 4)
                        //{
                        //    DeductionLogic decManager = new DeductionLogic(userInfo);

                        //    //CommonExchange.DeductionInformation deductionInfo = new CommonExchange.DeductionInformation();

                        //    //deductionInfo.SystemId = "SYSDEC002";
                        //    //deductionInfo.Description = "Mortuary Aids";

                        //    ////decManager.InsertDeductionInformation(userInfo, deductionInfo);
                        //    //decManager.UpdateDeductionInformation(userInfo, deductionInfo);

                        //    //MessageBox.Show("Success");

                        //    Application.Run(new DeductionCreate(userInfo, decManager));
                        //}
                        //else if (process == 5)
                        //{
                        //    DeductionLogic decManager = new DeductionLogic(userInfo);

                        //    Application.Run(new DeductionUpdate(userInfo, decManager, "SYSDEC001"));
                        //}
                        //else if (process == 6)
                        //{
                        //    Application.Run(new DeductionManager(userInfo));
                        //}
                        //else if (process == 7)
                        //{
                        //    CommonExchange.DeductionInformation decInfo = new CommonExchange.DeductionInformation();

                        //    decInfo.DeductionSysId = "SYSDEC001";
                        //    decInfo.Description = "Union Dues";

                        //    DeductionLogic decManager = new DeductionLogic(userInfo);

                        //    Application.Run(new ApplyDeduction(userInfo, decInfo, decManager));
                        //}
                        //else if (process == 8)
                        //{
                        //    Application.Run(new TempNavigator(userInfo));
                        //}
                        //else if (process == 9)
                        //{
                        //    DeductionLogic decManager = new DeductionLogic(userInfo);
                        //    CommonExchange.Employee empInfo = new CommonExchange.Employee();
                        //    empInfo.EmployeeSysId = "SYSEMP001";
                        //    empInfo.EmployeeId = "M234234";
                        //    empInfo.PersonInfo.LastName = "Agan";
                        //    empInfo.PersonInfo.FirstName = "Judyll Mark";
                        //    empInfo.PersonInfo.MiddleName = "Tinguha";

                        //    Application.Run(new EmployeeDeductionSummary(userInfo, empInfo, decManager));
                        //    //Application.Run(new EarningManager());
                        //}
                        //else if (process == 10)
                        //{
                        //    Application.Run(new EarningManager(userInfo));
                        //}
                        //else if (process == 11)
                        //{
                        //    LoanRemittanceLogic loanManager = new LoanRemittanceLogic(userInfo);

                        //    Application.Run(new LoanTypeCreate(userInfo, loanManager));
                        //}
                        //else if (process == 12)
                        //{
                        //    LoanRemittanceLogic loanManager = new LoanRemittanceLogic(userInfo);

                        //    Application.Run(new LoanTypeUpdate(userInfo, loanManager, "SYSLON001"));
                        //}
                        //else if (process == 13)
                        //{
                        //    Application.Run(new LoanRemittanceManager(userInfo));
                        //}
                        //else if (process == 14)
                        //{
                        //    LoanRemittanceLogic loanManager = new LoanRemittanceLogic(userInfo);
                        //    CommonExchange.Employee empInfo = new CommonExchange.Employee();
                        //    empInfo.EmployeeSysId = "SYSEMP001";
                        //    empInfo.EmployeeId = "M234234";
                        //    empInfo.PersonInfo.LastName = "Agan";
                        //    empInfo.PersonInfo.FirstName = "Judyll Mark";
                        //    empInfo.PersonInfo.MiddleName = "Tinguha";

                        //    Application.Run(new LoanRemittanceSummary(userInfo, empInfo, loanManager));
                        //}

                    }

                } //-------------------------
                
            }
            catch (Exception err)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(err.Message, "Error");
            }
            finally
            {
                Application.Exit();
            }
            
           
        }
    }
}