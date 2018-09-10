using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;

namespace DentalSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //sets the user information
            CommonExchange.SysAccess userInfo = new CommonExchange.SysAccess();
            //--------------------------

            try
            {                               
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Int32 startIndex = 1;

                if (startIndex == 1)
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
                        //gets the user information
                        using (DatabaseLib.DbLibGeneral dbLib = new DatabaseLib.DbLibGeneral())
                        {
                            //fail safe block
                            DateTime serverDateTime;

                            serverDateTime = DateTime.Parse(dbLib.GetServerDateTime(userInfo.Connection));

                            if (DateTime.Compare(serverDateTime, DateTime.Parse("06/30/2008")) >= 0)
                            {
                                throw new Exception("The program has encountered a critical error. Please contact the system administrator.");
                            }
                            //------------------------------------

                        } //--------------------------------

                        Application.Run(new DentalSystemManager(userInfo));
                    }
                    
                }
                else if (startIndex == 2)
                {
                    //gets the user information
                    using (DatabaseLib.DbLibGeneral dbLib = new DatabaseLib.DbLibGeneral())
                    {

                        if (dbLib.AuthenticateUser(ref userInfo))
                        {                            

                            Int32 process = 1;

                            if (process == 1)
                            {
                                Application.Run(new DentalSystemManager(userInfo));
                            }
                            else if (process == 2)
                            {
                                Application.Run(new DentalLib.ProcedureSearchOnTextboxList(userInfo, true));
                            }
                            else if (process == 3)
                            {
                                Application.Run(new DentalLib.PatientInformationCreate(userInfo));
                            }
                            else if (process == 4)
                            {
                                Application.Run(new DentalLib.PatientInformationUpdate(userInfo, "SYSPNT000000026"));
                            }
                            else if (process == 5)
                            {
                                DentalLib.ChargesLogic chargesManager = new DentalLib.ChargesLogic(userInfo);

                                CommonExchange.Patient patientInfo = chargesManager.SelectByPatientSystemIdPatientInformation(userInfo,
                                    "SYSPNT000000026", Application.StartupPath);

                                CommonExchange.Registration regInfo = new CommonExchange.Registration();
                                regInfo.RegistrationSystemId = "SYSREG00000001";
                                regInfo.RegistrationDate = DateTime.Now.ToLongDateString();

                                Application.Run(new DentalLib.PatientChargesSummary(userInfo, patientInfo, regInfo));
                            }
                            else if (process == 6)
                            {
                                Application.Run(new DentalLib.ReportsCashReport(userInfo, DateTime.Parse("12/01/2007"), DateTime.Parse("12/31/2007")));
                            }
                            else if (process == 7)
                            {
                                Application.Run(new DentalLib.ReportsAccountsReceivable(userInfo));
                            }
                            else if (process == 8)
                            {
                                Application.Run(new DentalLib.UserSearchOnTextboxList(userInfo));
                            }

                        }

                    } //-------------------------
                }                
                
            }
            catch (Exception err)
            {
                DentalLib.ProcStatic.ShowErrorDialog(err.Message, "System Error");
            }
            finally
            {
                if (userInfo.Connection != null && userInfo.Connection.State == System.Data.ConnectionState.Open)
                {
                    userInfo.Connection.Close();
                }

                Application.Exit();
            }
            
           
        }
    }
}