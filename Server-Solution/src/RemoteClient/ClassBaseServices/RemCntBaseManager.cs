using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Data.SqlClient;
using System.Data;

namespace RemoteClient
{
    public class RemCntBaseManager: IDisposable
    {
        #region Class Constructor and Destructor
        public RemCntBaseManager() { }

        void IDisposable.Dispose() { }

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts or updates a person infomation
        public void InsertUpdatePersonInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.Person personInfo) 
        {
            RemoteServerLib.RemSrvBaseManager remServer = (RemoteServerLib.RemSrvBaseManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvBaseManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "InsertUpdatePersonInformation");

            remServer.InsertUpdatePersonInformation(userInfo, ref personInfo);
        } //------------------------------------------

        //this procedure inserts or updates a person information
        public void InsertUpdatePersonInformationNoAuthenticate(CommonExchange.SysAccess userInfo, SqlConnection sqlConn, ref CommonExchange.Person personInfo) 
        {
            RemoteServerLib.RemSrvBaseManager remServer = (RemoteServerLib.RemSrvBaseManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvBaseManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "InsertUpdatePersonInformationNoAuthenticate");

            remServer.InsertUpdatePersonInformationNoAuthenticate(userInfo, sqlConn, ref personInfo);
        } //------------------------------

        //this procedure inserts a new payroll standard
        public void InsertPayrollStandard(CommonExchange.SysAccess userInfo, ref CommonExchange.PayrollStandard stdPayroll) 
        {
            RemoteServerLib.RemSrvBaseManager remServer = (RemoteServerLib.RemSrvBaseManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvBaseManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "InsertPayrollStandard");

            remServer.InsertPayrollStandard(userInfo, ref stdPayroll);
        }  //-----------------------------------

        //this procedure inserts a new registrar standard
        public void InsertRegistrarStandard(CommonExchange.SysAccess userInfo, ref CommonExchange.RegistrarStandard stdRegistrar) 
        {
            RemoteServerLib.RemSrvBaseManager remServer = (RemoteServerLib.RemSrvBaseManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvBaseManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "InsertRegistrarStandard");

            remServer.InsertRegistrarStandard(userInfo, ref stdRegistrar);
        } //----------------------------------

        //this procedure inserts a new finance standard
        public void InsertFinanceStandard(CommonExchange.SysAccess userInfo, ref CommonExchange.FinanceStandard stdFinance) 
        {
            RemoteServerLib.RemSrvBaseManager remServer = (RemoteServerLib.RemSrvBaseManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvBaseManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "InsertFinanceStandard");

            remServer.InsertFinanceStandard(userInfo, ref stdFinance);
        } //-----------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function determines if the person is an employee or a student
        public Boolean IsExistsSysIDPersonStudentEmployeeInformation(CommonExchange.SysAccess userInfo, String personSysId, ref Boolean isEmployee)
        {
            RemoteServerLib.RemSrvBaseManager remServer = (RemoteServerLib.RemSrvBaseManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvBaseManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "IsExistsSysIDPersonStudentEmployeeInformation");

            return remServer.IsExistsSysIDPersonStudentEmployeeInformation(userInfo, personSysId, ref isEmployee);
        } //----------------------------------

        //this function gets the person information table query
        public DataTable SelectPersonInformation(CommonExchange.SysAccess userInfo, String queryString,
            String lastName, String firstName, String personSysIdExcludeList)
        {
            RemoteServerLib.RemSrvBaseManager remServer = (RemoteServerLib.RemSrvBaseManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvBaseManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectPersonInformation");

            return remServer.SelectPersonInformation(userInfo, queryString, lastName, firstName, personSysIdExcludeList);
        } //----------------------------------

        //this function returns the person information details
        public CommonExchange.Person SelectBySysIDPersonInformation(CommonExchange.SysAccess userInfo, String personSysId)
        {
            RemoteServerLib.RemSrvBaseManager remServer = (RemoteServerLib.RemSrvBaseManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvBaseManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDPersonInformation");

            return remServer.SelectBySysIDPersonInformation(userInfo, personSysId);
        } //-------------------------------------

        //this function returns the person information details
        public CommonExchange.Person SelectBySysIDPersonInformationNoAuthenticate(String userId, SqlConnection sqlConn, String personSysId)
        {
            RemoteServerLib.RemSrvBaseManager remServer = (RemoteServerLib.RemSrvBaseManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvBaseManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDPersonInformationNoAuthenticate");

            return remServer.SelectBySysIDPersonInformationNoAuthenticate(userId, sqlConn, personSysId);
        } //---------------------------------

        //this function gets the person information images by sysid_person list
        public DataTable SelectPersonImagesPersonInformation(CommonExchange.SysAccess userInfo, String personSysIdList)
        {
            RemoteServerLib.RemSrvBaseManager remServer = (RemoteServerLib.RemSrvBaseManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvBaseManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectPersonImagesPersonInformation");

            return remServer.SelectPersonImagesPersonInformation(userInfo, personSysIdList);
        } //--------------------------------------

        //this function returns the payroll standards
        public CommonExchange.PayrollStandard SelectPayrollStandard(CommonExchange.SysAccess userInfo)
        {
            RemoteServerLib.RemSrvBaseManager remServer = (RemoteServerLib.RemSrvBaseManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvBaseManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectPayrollStandard");

            return remServer.SelectPayrollStandard(userInfo);
        } //--------------------------------------

        //this function returns the registrar standards
        public CommonExchange.RegistrarStandard SelectRegistrarStandard(CommonExchange.SysAccess userInfo)
        {
            RemoteServerLib.RemSrvBaseManager remServer = (RemoteServerLib.RemSrvBaseManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvBaseManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectRegistrarStandard");

            return remServer.SelectRegistrarStandard(userInfo);
        } //--------------------------------------

        //this function returns the finance standards
        public CommonExchange.FinanceStandard SelectFinanceStandard(CommonExchange.SysAccess userInfo)
        {
            RemoteServerLib.RemSrvBaseManager remServer = (RemoteServerLib.RemSrvBaseManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvBaseManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectFinanceStandard");

            return remServer.SelectFinanceStandard(userInfo);
        } //-------------------------------------------

        //this function gets the server dates
        public String GetServerDateTime(CommonExchange.SysAccess userInfo)
        {
            RemoteServerLib.RemSrvBaseManager remServer = (RemoteServerLib.RemSrvBaseManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvBaseManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "GetServerDateTime");

            return remServer.GetServerDateTime(userInfo);
        } //-------------------------------------

        //this function return the server date
        public String GetServerDateTimeNoAuthenticate(SqlConnection sqlConn)
        {
            RemoteServerLib.RemSrvBaseManager remServer = (RemoteServerLib.RemSrvBaseManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvBaseManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "GetServerDateTimeNoAuthenticate");

            return remServer.GetServerDateTimeNoAuthenticate(sqlConn);
        } //---------------------------------------

        //this function is used to get data tables stored in one dataset used for administrator services
        public DataSet GetDataSetForBaseServices(CommonExchange.SysAccess userInfo)
        {
            RemoteServerLib.RemSrvBaseManager remServer = (RemoteServerLib.RemSrvBaseManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvBaseManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "GetDataSetForBaseServices");

            return remServer.GetDataSetForBaseServices(userInfo);
        } //----------------------------------

        #endregion

    }
}
