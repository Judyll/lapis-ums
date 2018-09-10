using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteServerLib
{
    public class RemSrvAdministratorManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvAdministratorManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new system user
        public void InsertSystemUserInfo(CommonExchange.SysAccess userInfo, ref CommonExchange.SysAccess newUserInfo) { }

        //this procedure updates a system user
        public void UpdateSystemUserInfo(CommonExchange.SysAccess userInfo, CommonExchange.SysAccess editUserInfo) { }

        #endregion

        #region Programmer-Defined Function Procedures

        //this function gets the system user information by system user id
        public CommonExchange.SysAccess SelectBySystemUserIDSystemUserInfo(CommonExchange.SysAccess userInfo, String retrieveUserId)
        {
            CommonExchange.SysAccess retrieveUserInfo = new CommonExchange.SysAccess();

            return retrieveUserInfo;
        } //----------------------------------

        //this function returns the system user information by person system id
        public CommonExchange.SysAccess SelectBySysIDPersonSystemUserInfo(CommonExchange.SysAccess userInfo, String personSysId)
        {
            CommonExchange.SysAccess retrieveUserInfo = new CommonExchange.SysAccess();

            return retrieveUserInfo;
        } //---------------------------------------   

        //this function gets the system user info table
        public DataTable SelectSystemUserInfo(CommonExchange.SysAccess userInfo, String queryString)
        {
            DataTable dbTable = new DataTable();

            return dbTable;

        } //------------------------------

        //this function authenticates the user
        public Boolean AuthenticateSystemUser(ref CommonExchange.SysAccess userInfo, ref Boolean isExpiredLicense)
        {
            Boolean isValid = false;

            return isValid;
        } //----------------------------------------

        //this function gets the transaction log table query
        public DataTable SelectTransactionLog(CommonExchange.SysAccess userInfo, String queryString, String userId, String dateStart, String dateEnd)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //---------------------------------------

        //this function is sued to determine if the user name or password already exists
        public Boolean IsExistsNameSystemUserInformation(CommonExchange.SysAccess userInfo, CommonExchange.SysAccess newUserInfo)
        {
            Boolean isExist = false;

            return isExist;
        } //----------------------------------

        //this function is used to get data tables stored in one dataset used for administrator services
        public DataSet GetDataSetForAdministrator(CommonExchange.SysAccess userInfo)
        {
            DataSet dbSet = new DataSet();

            return dbSet;
        } //----------------------------------

        #endregion
    }
}
