using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteClient
{
    public class RemCntAdministratorManager : IDisposable
    {
        #region Class Constructor and Destructor
        public RemCntAdministratorManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new system user
        public void InsertSystemUserInfo(CommonExchange.SysAccess userInfo, ref CommonExchange.SysAccess newUserInfo) 
        {
            RemoteServerLib.RemSrvAdministratorManager remServer = (RemoteServerLib.RemSrvAdministratorManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvAdministratorManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "InsertSystemUserInfo");

            remServer.InsertSystemUserInfo(userInfo, ref newUserInfo);
        } //-------------------------------------

        //this procedure updates a system user
        public void UpdateSystemUserInfo(CommonExchange.SysAccess userInfo, CommonExchange.SysAccess editUserInfo) 
        {
            RemoteServerLib.RemSrvAdministratorManager remServer = (RemoteServerLib.RemSrvAdministratorManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvAdministratorManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "UpdateSystemUserInfo");

            remServer.UpdateSystemUserInfo(userInfo, editUserInfo);
        } //-----------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function gets the system user information by system user id
        public CommonExchange.SysAccess SelectBySystemUserIDSystemUserInfo(CommonExchange.SysAccess userInfo, String retrieveUserId)
        {
            RemoteServerLib.RemSrvAdministratorManager remServer = (RemoteServerLib.RemSrvAdministratorManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvAdministratorManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectBySystemUserIDSystemUserInfo");

            return remServer.SelectBySystemUserIDSystemUserInfo(userInfo, retrieveUserId);
        } //----------------------------------

        //this function returns the system user information by person system id
        public CommonExchange.SysAccess SelectBySysIDPersonSystemUserInfo(CommonExchange.SysAccess userInfo, String personSysId)
        {
            RemoteServerLib.RemSrvAdministratorManager remServer = (RemoteServerLib.RemSrvAdministratorManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvAdministratorManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDPersonSystemUserInfo");

            return remServer.SelectBySysIDPersonSystemUserInfo(userInfo, personSysId);
        } //----------------------------------

        //this function gets the system user info table
        public DataTable SelectSystemUserInfo(CommonExchange.SysAccess userInfo, String queryString)
        {
            RemoteServerLib.RemSrvAdministratorManager remServer = (RemoteServerLib.RemSrvAdministratorManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvAdministratorManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectSystemUserInfo");

            return remServer.SelectSystemUserInfo(userInfo, queryString);
        } //------------------------------

        //this function authenticates the user
        public Boolean AuthenticateSystemUser(ref CommonExchange.SysAccess userInfo, ref Boolean isExpiredLicense)
        {
            RemoteServerLib.RemSrvAdministratorManager remServer = (RemoteServerLib.RemSrvAdministratorManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvAdministratorManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "AuthenticateSystemUser");

            return remServer.AuthenticateSystemUser(ref userInfo, ref isExpiredLicense);
        } //----------------------------------------

        //this function gets the transaction log table query
        public DataTable SelectTransactionLog(CommonExchange.SysAccess userInfo, String queryString, String userId, String dateStart, String dateEnd)
        {
            RemoteServerLib.RemSrvAdministratorManager remServer = (RemoteServerLib.RemSrvAdministratorManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvAdministratorManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectTransactionLog");

            return remServer.SelectTransactionLog(userInfo, queryString, userId, dateStart, dateEnd);
        } //----------------------------------

        //this function is sued to determine if the user name or password already exists
        public Boolean IsExistsNameSystemUserInformation(CommonExchange.SysAccess userInfo, CommonExchange.SysAccess newUserInfo)
        {
            RemoteServerLib.RemSrvAdministratorManager remServer = (RemoteServerLib.RemSrvAdministratorManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvAdministratorManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "IsExistsNameSystemUserInformation");

            return remServer.IsExistsNameSystemUserInformation(userInfo, newUserInfo);
        } //----------------------------------

        //this function is used to get data tables stored in one dataset used for administrator services
        public DataSet GetDataSetForAdministrator(CommonExchange.SysAccess userInfo)
        {
            RemoteServerLib.RemSrvAdministratorManager remServer = (RemoteServerLib.RemSrvAdministratorManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvAdministratorManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "GetDataSetForAdministrator");

            return remServer.GetDataSetForAdministrator(userInfo);
        } //----------------------------------

        #endregion
    }
}
