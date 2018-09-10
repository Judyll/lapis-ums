using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RemoteClient
{
    public class RemCntLoanManager: IDisposable
    {
        #region Class Constructor and Destructor

        public RemCntLoanManager() { }

        void IDisposable.Dispose() { }

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure updates / delete an employee remittance
        public void UpdateDeleteEmployeeRemittance(CommonExchange.SysAccess userInfo, DataTable remTable)
        {
            RemoteServerLib.RemSrvLoanManager remServer = (RemoteServerLib.RemSrvLoanManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvLoanManager),
                                                       TcpRemoteServer.GetRemoteServerTcp() + "UpdateDeleteEmployeeRemittance");

            remServer.UpdateDeleteEmployeeRemittance(userInfo, remTable);
        } //-----------------------------------

        //this procedure inserts a new employee remittance
        public void InsertEmployeeRemittance(CommonExchange.SysAccess userInfo, CommonExchange.EmployeeLoanRemittance remInfo)
        {
            RemoteServerLib.RemSrvLoanManager remServer = (RemoteServerLib.RemSrvLoanManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvLoanManager),
                                                       TcpRemoteServer.GetRemoteServerTcp() + "InsertEmployeeRemittance");

            remServer.InsertEmployeeRemittance(userInfo, remInfo);
        } //---------------------------

        //this procedure deletes a loan remittance information
        public void DeleteLoanRemittance(CommonExchange.SysAccess userInfo, String loanSysId)
        {
            RemoteServerLib.RemSrvLoanManager remServer = (RemoteServerLib.RemSrvLoanManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvLoanManager),
                                                       TcpRemoteServer.GetRemoteServerTcp() + "DeleteLoanRemittance");

            remServer.DeleteLoanRemittance(userInfo, loanSysId);
        } //-----------------------------

        //this procedure updates a loan remittance information
        public void UpdateLoanRemittance(CommonExchange.SysAccess userInfo, CommonExchange.LoanInformation loanInfo)
        {
            RemoteServerLib.RemSrvLoanManager remServer = (RemoteServerLib.RemSrvLoanManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvLoanManager),
                                                       TcpRemoteServer.GetRemoteServerTcp() + "UpdateLoanRemittance");

            remServer.UpdateLoanRemittance(userInfo, loanInfo);
        } //---------------------------------

        //this procedure inserts a loan remittance information
        public void InsertLoanRemittance(CommonExchange.SysAccess userInfo, ref CommonExchange.LoanInformation loanInfo)
        {
            RemoteServerLib.RemSrvLoanManager remServer = (RemoteServerLib.RemSrvLoanManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvLoanManager),
                                                       TcpRemoteServer.GetRemoteServerTcp() + "InsertLoanRemittance");

            remServer.InsertLoanRemittance(userInfo, ref loanInfo);
        } //---------------------------------------

        //this procedure updates a loan type information
        public void UpdateLoanTypeInformation(CommonExchange.SysAccess userInfo, CommonExchange.LoanInformation loanInfo)
        {
            RemoteServerLib.RemSrvLoanManager remServer = (RemoteServerLib.RemSrvLoanManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvLoanManager),
                                                       TcpRemoteServer.GetRemoteServerTcp() + "UpdateLoanTypeInformation");

            remServer.UpdateLoanTypeInformation(userInfo, loanInfo);
        } //----------------------------------

        //this procedure inserts a new loan type information
        public void InsertLoanTypeInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.LoanInformation loanInfo)
        {
            RemoteServerLib.RemSrvLoanManager remServer = (RemoteServerLib.RemSrvLoanManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvLoanManager),
                                                       TcpRemoteServer.GetRemoteServerTcp() + "InsertLoanTypeInformation");

            remServer.InsertLoanTypeInformation(userInfo, ref loanInfo);
        } //---------------------------------
        #endregion
        
        #region Programmer-Defined Function Procedures

        //this function is used to determine if the description exists
        public Boolean IsLoanTypeDescriptionExist(CommonExchange.SysAccess userInfo, String description, String loanSysId)
        {
            RemoteServerLib.RemSrvLoanManager remServer = (RemoteServerLib.RemSrvLoanManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvLoanManager),
                                                       TcpRemoteServer.GetRemoteServerTcp() + "IsLoanTypeDescriptionExist");

            return remServer.IsLoanTypeDescriptionExist(userInfo, description, loanSysId);
        } //---------------------------

        //this function is used to get data tables stored in one dataset used for loan type information
        public DataSet GetDataSetForLoanTypeInfo(CommonExchange.SysAccess userInfo)
        {
            RemoteServerLib.RemSrvLoanManager remServer = (RemoteServerLib.RemSrvLoanManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvLoanManager),
                                                       TcpRemoteServer.GetRemoteServerTcp() + "GetDataSetForLoanTypeInfo");

            return remServer.GetDataSetForLoanTypeInfo(userInfo);
        } //--------------------------------

        //this function is sued to get the employee remittance by employee id
        public DataTable SelectByEmployeeIDEmployeeRemittance(CommonExchange.SysAccess userInfo, String empSysId)
        {
            RemoteServerLib.RemSrvLoanManager remServer = (RemoteServerLib.RemSrvLoanManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvLoanManager),
                                                       TcpRemoteServer.GetRemoteServerTcp() + "SelectByEmployeeIDEmployeeRemittance");

            return remServer.SelectByEmployeeIDEmployeeRemittance(userInfo, empSysId);
        } //----------------------------------

        //this function is used to get the loan remittance by employee id
        public DataTable SelectByEmployeeIDLoanRemittance(CommonExchange.SysAccess userInfo, String empSysId)
        {
            RemoteServerLib.RemSrvLoanManager remServer = (RemoteServerLib.RemSrvLoanManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvLoanManager),
                                                       TcpRemoteServer.GetRemoteServerTcp() + "SelectByEmployeeIDLoanRemittance");

            return remServer.SelectByEmployeeIDLoanRemittance(userInfo, empSysId);
        } //----------------------------------

        #endregion
    }
}
