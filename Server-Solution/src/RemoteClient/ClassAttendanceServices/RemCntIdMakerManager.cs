using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RemoteClient
{
    public class RemCntIdMakerManager : IDisposable
    {
        #region Class Constructor and Destructor

        public RemCntIdMakerManager() { }

        void IDisposable.Dispose() { }

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure updates an employee information for ID Maker
        public void UpdateForIdMakerEmployeeInformation(CommonExchange.SysAccess userInfo, CommonExchange.Employee employeeInfo)
        {
            RemoteServerLib.RemSrvIdMakerManager remServer = (RemoteServerLib.RemSrvIdMakerManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvIdMakerManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "UpdateForIdMakerEmployeeInformation");

            remServer.UpdateForIdMakerEmployeeInformation(userInfo, employeeInfo);
        } //-------------------------------------

        //this procedure updates a student information for ID Maker
        public void UpdateForIdMakerStudentInformation(CommonExchange.SysAccess userInfo, CommonExchange.Student studentInfo)
        {
            RemoteServerLib.RemSrvIdMakerManager remServer = (RemoteServerLib.RemSrvIdMakerManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvIdMakerManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "UpdateForIdMakerStudentInformation");

            remServer.UpdateForIdMakerStudentInformation(userInfo, studentInfo);
        } //---------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function gets the student and employee table query
        public DataTable SelectByQueryStringStudentEmployeeInformation(CommonExchange.SysAccess userInfo, String queryString,
            Boolean includeEmergencyContact)
        {
            RemoteServerLib.RemSrvIdMakerManager remServer = (RemoteServerLib.RemSrvIdMakerManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvIdMakerManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectByQueryStringStudentEmployeeInformation");

            return remServer.SelectByQueryStringStudentEmployeeInformation(userInfo, queryString, includeEmergencyContact);
        } //------------------------------

        //this function is used to determine if the student card number exists
        public Boolean IsExistsCardNumberStudentInformation(CommonExchange.SysAccess userInfo, String cardNumber, String studentSysId)
        {
            RemoteServerLib.RemSrvIdMakerManager remServer = (RemoteServerLib.RemSrvIdMakerManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvIdMakerManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "IsExistsCardNumberStudentInformation");

            return remServer.IsExistsCardNumberStudentInformation(userInfo, cardNumber, studentSysId);
        } //-------------------------------------

        //this function is used to determine if the card number exists
        public Boolean IsExistsCardNumberEmployeeInformation(CommonExchange.SysAccess userInfo, String cardNumber, String employeeSysId)
        {
            RemoteServerLib.RemSrvIdMakerManager remServer = (RemoteServerLib.RemSrvIdMakerManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvIdMakerManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "IsExistsCardNumberEmployeeInformation");

            return remServer.IsExistsCardNumberEmployeeInformation(userInfo, cardNumber, employeeSysId);
        } //---------------------------------------

        #endregion
    }
}
