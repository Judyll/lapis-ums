using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RemoteClient
{
    public class RemCntEmployeeManager: IDisposable
    {
        #region Class Constructor and Destructor

        public RemCntEmployeeManager() { }

        void IDisposable.Dispose() { }

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure adds a new employee information
        public void InsertEmployeeInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.Employee empInfo)
        {
            RemoteServerLib.RemSrvEmployeeManager remServer = (RemoteServerLib.RemSrvEmployeeManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvEmployeeManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "InsertEmployeeInformation");

            remServer.InsertEmployeeInformation(userInfo, ref empInfo);
        } //--------------------------------------

        //this procedure updates an employee information
        public void UpdateEmployeeInformation(CommonExchange.SysAccess userInfo, CommonExchange.Employee empInfo)
        {
            RemoteServerLib.RemSrvEmployeeManager remServer = (RemoteServerLib.RemSrvEmployeeManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvEmployeeManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "UpdateEmployeeInformation");

            remServer.UpdateEmployeeInformation(userInfo, empInfo);
        } //--------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function returns the selected employee information table
        public CommonExchange.Employee SelectByEmployeeIDEmployeeInformation(CommonExchange.SysAccess userInfo, String employeeId)
        {
            RemoteServerLib.RemSrvEmployeeManager remServer = (RemoteServerLib.RemSrvEmployeeManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvEmployeeManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectByEmployeeIDEmployeeInformation");

            return remServer.SelectByEmployeeIDEmployeeInformation(userInfo, employeeId);
        } //------------------------------------------

        //this function returns the selected employee information table
        public CommonExchange.Employee SelectBySysIDPersonEmployeeInformation(CommonExchange.SysAccess userInfo, String personSysId)
        {
            RemoteServerLib.RemSrvEmployeeManager remServer = (RemoteServerLib.RemSrvEmployeeManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvEmployeeManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDPersonEmployeeInformation");

            return remServer.SelectBySysIDPersonEmployeeInformation(userInfo, personSysId);
        } //------------------------------------------

        //this function is used to determine if the employee id exists
        public Boolean IsExistsEmployeeIdEmployeeInformation(CommonExchange.SysAccess userInfo, String empId, String sysId)
        {
            RemoteServerLib.RemSrvEmployeeManager remServer = (RemoteServerLib.RemSrvEmployeeManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvEmployeeManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "IsExistsEmployeeIdEmployeeInformation");

            return remServer.IsExistsEmployeeIdEmployeeInformation(userInfo, empId, sysId);
        } //---------------------------

        //this function is used to get data tables stored in one dataset used for employee information
        public DataSet GetDataSetForEmployeeInfo(CommonExchange.SysAccess userInfo)
        {
            RemoteServerLib.RemSrvEmployeeManager remServer = (RemoteServerLib.RemSrvEmployeeManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvEmployeeManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "GetDataSetForEmployeeInfo");

            return remServer.GetDataSetForEmployeeInfo(userInfo);
                        
        } //----------------------------------

        #endregion
    }
}
