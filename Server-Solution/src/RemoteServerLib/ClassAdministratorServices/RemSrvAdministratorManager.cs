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
        public void InsertSystemUserInfo(CommonExchange.SysAccess userInfo, ref CommonExchange.SysAccess newUserInfo)
        {
            if (newUserInfo.ObjectState == DataRowState.Added)
            {
                using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
                {
                    using (RemSrvBaseManager remSrv = new RemSrvBaseManager())
                    {
                        newUserInfo.PersonInfo.ForLogin = true;
                        newUserInfo.PersonInfo.ForEmployee = false;
                        newUserInfo.PersonInfo.ForStudent = false;

                        CommonExchange.Person personInfo = newUserInfo.PersonInfo;

                        remSrv.InsertUpdatePersonInformationNoAuthenticate(userInfo, auth.Connection, ref personInfo);

                        newUserInfo.PersonInfo = personInfo;
                    }

                    newUserInfo.UserId = PrimaryKeys.GetNewSystemUserID(userInfo, auth.Connection);

                    using (SqlCommand sqlComm = new SqlCommand())
                    {
                        sqlComm.Connection = auth.Connection;
                        sqlComm.CommandType = CommandType.StoredProcedure;
                        sqlComm.CommandText = "ums.InsertSystemUserInfo";

                        sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = newUserInfo.UserId;
                        sqlComm.Parameters.Add("@system_user_name", SqlDbType.VarChar).Value = newUserInfo.UserName;
                        sqlComm.Parameters.Add("@system_user_password", SqlDbType.VarChar).Value = newUserInfo.Password;
                        sqlComm.Parameters.Add("@system_user_status", SqlDbType.Bit).Value = newUserInfo.UserStatus;
                        sqlComm.Parameters.Add("@sysid_person", SqlDbType.VarChar).Value = newUserInfo.PersonInfo.PersonSysId;

                        sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                        sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                        sqlComm.ExecuteNonQuery();
                    }

                    this.InsertUpdateDeleteAccessRightsGranted(userInfo, auth.Connection, newUserInfo);
                }
            }
        } //-----------------------------------    

        //this procedure updates a system user
        public void UpdateSystemUserInfo(CommonExchange.SysAccess userInfo, CommonExchange.SysAccess editUserInfo)
        {
            if (editUserInfo.ObjectState == DataRowState.Modified)
            {
                using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
                {
                    using (RemSrvBaseManager remSrv = new RemSrvBaseManager())
                    {
                        editUserInfo.PersonInfo.ForLogin = true;
                        editUserInfo.PersonInfo.ForEmployee = false;
                        editUserInfo.PersonInfo.ForStudent = false;

                        CommonExchange.Person personInfo = editUserInfo.PersonInfo;

                        remSrv.InsertUpdatePersonInformationNoAuthenticate(userInfo, auth.Connection, ref personInfo);

                        editUserInfo.PersonInfo = personInfo;
                    }

                    using (SqlCommand sqlComm = new SqlCommand())
                    {
                        sqlComm.Connection = auth.Connection;
                        sqlComm.CommandType = CommandType.StoredProcedure;
                        sqlComm.CommandText = "ums.UpdateSystemUserInfo";

                        sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = editUserInfo.UserId;
                        sqlComm.Parameters.Add("@system_user_name", SqlDbType.VarChar).Value = editUserInfo.UserName;
                        sqlComm.Parameters.Add("@system_user_password", SqlDbType.VarChar).Value = editUserInfo.Password;
                        sqlComm.Parameters.Add("@system_user_status", SqlDbType.Bit).Value = editUserInfo.UserStatus;

                        sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                        sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                        sqlComm.ExecuteNonQuery();
                    }

                    this.InsertUpdateDeleteAccessRightsGranted(userInfo, auth.Connection, editUserInfo);
                }
            }
        } //-----------------------------------   

        //this procedure inserts or updates an access rights granted
        private void InsertUpdateDeleteAccessRightsGranted(CommonExchange.SysAccess userInfo, SqlConnection sqlConn,
            CommonExchange.SysAccess newEditUserInfo)
        {
            //must delete first any instance of the access rights granted before inserting a new one
            foreach (CommonExchange.AccessRightsGranted rightsGranted in newEditUserInfo.AccessRightsGrantedList)
            {
                if (rightsGranted.ObjectState == DataRowState.Deleted)
                {
                    using (SqlCommand sqlComm = new SqlCommand())
                    {
                        sqlComm.Connection = sqlConn;
                        sqlComm.CommandType = CommandType.StoredProcedure;
                        sqlComm.CommandText = "ums.DeleteAccessRightsGranted";

                        sqlComm.Parameters.Add("@rights_granted_id", SqlDbType.BigInt).Value = rightsGranted.RightsGrantedId;
                        sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = newEditUserInfo.UserId;
                        sqlComm.Parameters.Add("@access_rights", SqlDbType.VarChar).Value = rightsGranted.AccessRightsInfo.AccessRights;

                        sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                        sqlComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                        sqlComm.ExecuteNonQuery();
                    }
                }
            }

            foreach (CommonExchange.AccessRightsGranted rightsGranted in newEditUserInfo.AccessRightsGrantedList)
            {
                if (rightsGranted.ObjectState == DataRowState.Added)
                {
                    using (SqlCommand sqlComm = new SqlCommand())
                    {
                        sqlComm.Connection = sqlConn;
                        sqlComm.CommandType = CommandType.StoredProcedure;
                        sqlComm.CommandText = "ums.InsertAccessRightsGranted";

                        sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = newEditUserInfo.UserId;
                        sqlComm.Parameters.Add("@access_rights", SqlDbType.VarChar).Value = rightsGranted.AccessRightsInfo.AccessRights;
                        sqlComm.Parameters.Add("@department_id", SqlDbType.VarChar).Value = rightsGranted.DepartmentInfo.DepartmentId;

                        sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                        sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                        sqlComm.ExecuteNonQuery();
                    }
                }
                else if (rightsGranted.ObjectState == DataRowState.Modified)
                {
                    using (SqlCommand sqlComm = new SqlCommand())
                    {
                        sqlComm.Connection = sqlConn;
                        sqlComm.CommandType = CommandType.StoredProcedure;
                        sqlComm.CommandText = "ums.UpdateAccessRightsGranted";

                        sqlComm.Parameters.Add("@rights_granted_id", SqlDbType.BigInt).Value = rightsGranted.RightsGrantedId;
                        sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = newEditUserInfo.UserId;
                        sqlComm.Parameters.Add("@access_rights", SqlDbType.VarChar).Value = rightsGranted.AccessRightsInfo.AccessRights;
                        sqlComm.Parameters.Add("@department_id", SqlDbType.VarChar).Value = rightsGranted.DepartmentInfo.DepartmentId;

                        sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                        sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                        sqlComm.ExecuteNonQuery();
                    }
                }
            }
        } //-------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function gets the system user information by system user id
        public CommonExchange.SysAccess SelectBySystemUserIDSystemUserInfo(CommonExchange.SysAccess userInfo, String retrieveUserId)
        {
            CommonExchange.SysAccess retrieveUserInfo = new CommonExchange.SysAccess();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                retrieveUserInfo = this.SelectBySystemUserIDSystemUserInfoNoAuthenticate(userInfo, auth.Connection, retrieveUserId);
            }

            return retrieveUserInfo;
        } //--------------------------------------

        //this function returns the system user information by person system id
        public CommonExchange.SysAccess SelectBySysIDPersonSystemUserInfo(CommonExchange.SysAccess userInfo, String personSysId)
        {
            CommonExchange.SysAccess retrieveUserInfo = new CommonExchange.SysAccess();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                String retrieveSystemUserId = String.Empty;

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDPersonSystemUserInfo";

                    sqlComm.Parameters.Add("@sysid_person", SqlDbType.VarChar).Value = personSysId;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                retrieveSystemUserId = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "system_user_id", String.Empty);

                                break;
                            }
                        }

                        sqlReader.Close();
                    }
                }

                if (!String.IsNullOrEmpty(retrieveSystemUserId))
                {
                    retrieveUserInfo = this.SelectBySystemUserIDSystemUserInfoNoAuthenticate(userInfo, auth.Connection, retrieveSystemUserId);
                }
            }

            return retrieveUserInfo;
        } //---------------------------------------   

        //this function gets the system user info table
        public DataTable SelectSystemUserInfo(CommonExchange.SysAccess userInfo, String queryString)
        {
            DataTable dbTable = new DataTable("SystemUserInfoTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectSystemUserInfo";

                    if (String.IsNullOrEmpty(queryString))
                    {
                        sqlComm.Parameters.Add("@query_string", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@query_string", SqlDbType.VarChar).Value = queryString;
                    }

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                    {
                        sqlAdapter.SelectCommand = sqlComm;
                        sqlAdapter.Fill(dbTable);
                    }
                }
            }

            return dbTable;

        } //------------------------------

        //this function authenticates the user
        public Boolean AuthenticateSystemUser(ref CommonExchange.SysAccess userInfo, ref Boolean isExpiredLicense)
        {
            Boolean isValid = false;

            try
            {
                using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, true)))
                {
                    isExpiredLicense = this.IsExpiredSystemLicense(userInfo, auth.Connection);

                    isValid = !isExpiredLicense;
                }
            }
            catch
            {
                isValid = false;
            }

            return isValid;
        } //----------------------------------------

        //this function gets the transaction log table query
        public DataTable SelectTransactionLog(CommonExchange.SysAccess userInfo, String queryString, String userId, String dateStart, String dateEnd)
        {
            DataTable dbTable = new DataTable("TransactionLogTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectTransactionLog";

                    if (String.IsNullOrEmpty(queryString))
                    {
                        sqlComm.Parameters.Add("@query_string", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@query_string", SqlDbType.VarChar).Value = queryString;
                    }

                    if (String.IsNullOrEmpty(userId))
                    {
                        sqlComm.Parameters.Add("@user_id", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@user_id", SqlDbType.VarChar).Value = userId;
                    }

                    DateTime dStart = DateTime.MinValue;
                    DateTime dEnd = DateTime.MinValue;

                    if ((String.IsNullOrEmpty(dateStart) || !DateTime.TryParse(dateStart, out dStart)) ||
                        (String.IsNullOrEmpty(dateEnd) || !DateTime.TryParse(dateEnd, out dEnd)))
                    {
                        sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = DBNull.Value;
                        sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = dStart;
                        sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = dEnd;
                    }

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                    {
                        sqlAdapter.SelectCommand = sqlComm;
                        sqlAdapter.Fill(dbTable);
                    }
                }
            }

            return dbTable;

        } //------------------------------

        //this function is sued to determine if the user name or password already exists
        public Boolean IsExistsNameSystemUserInformation(CommonExchange.SysAccess userInfo, CommonExchange.SysAccess newUserInfo)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsExistsNameSystemUserInformation";

                    sqlComm.Parameters.Add("@check_system_user_id", SqlDbType.VarChar).Value = newUserInfo.UserId;
                    sqlComm.Parameters.Add("@check_system_user_name", SqlDbType.VarChar).Value = newUserInfo.UserName;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;
        } //----------------------------------

        //this function is used to get data tables stored in one dataset used for administrator services
        public DataSet GetDataSetForAdministrator(CommonExchange.SysAccess userInfo)
        {
            DataSet dbSet = new DataSet();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                //gets the department information table
                dbSet.Tables.Add(ProcStatic.GetDepartmentInformationTable(auth.Connection, userInfo.UserId));
                //------------------------------------

                //gets the system access code table
                dbSet.Tables.Add(ProcStatic.GetSystemAccessRightsTable(auth.Connection, userInfo.UserId));
                //--------------------------------

                //gets the code reference table
                dbSet.Tables.Add(ProcStatic.GetCodeReferenceTable(auth.Connection, userInfo.UserId));
                //-----------------------------

                //gets the relationship type table
                dbSet.Tables.Add(ProcStatic.GetRelationshipTypeTable(auth.Connection, userInfo.UserId));
                //-------------------------------------
            }

            return dbSet;
        } //----------------------------------

        //this function gets the system user information by system user id
        private CommonExchange.SysAccess SelectBySystemUserIDSystemUserInfoNoAuthenticate(CommonExchange.SysAccess userInfo, SqlConnection sqlConn,
            String retrieveUserId)
        {
            CommonExchange.SysAccess retrieveUserInfo = new CommonExchange.SysAccess();

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectBySystemUserIDSystemUserInfo";

                sqlComm.Parameters.Add("@retrieve_user_id", SqlDbType.VarChar).Value = retrieveUserId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                {
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {

                            retrieveUserInfo.UserId = ProcStatic.DataReaderConvert(sqlReader, "system_user_id", String.Empty);
                            retrieveUserInfo.UserName = ProcStatic.DataReaderConvert(sqlReader, "system_user_name", String.Empty);
                            retrieveUserInfo.Password = ProcStatic.DataReaderConvert(sqlReader, "system_user_password", String.Empty);
                            retrieveUserInfo.UserStatus = ProcStatic.DataReaderConvert(sqlReader, "system_user_status", false);
                            retrieveUserInfo.PersonInfo.PersonSysId = ProcStatic.DataReaderConvert(sqlReader, "sysid_person", String.Empty);

                            break;
                        }
                    }

                    sqlReader.Close();
                }

                if (!String.IsNullOrEmpty(retrieveUserInfo.PersonInfo.PersonSysId))
                {
                    using (RemSrvBaseManager remSrv = new RemSrvBaseManager())
                    {
                        retrieveUserInfo.PersonInfo = remSrv.SelectBySysIDPersonInformationNoAuthenticate(userInfo.UserId, sqlConn,
                            retrieveUserInfo.PersonInfo.PersonSysId);
                    }
                }
            }

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectForUpdateAccessRightsGranted";

                sqlComm.Parameters.Add("@retrieve_system_user_id", SqlDbType.VarChar).Value = retrieveUserInfo.UserId;

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                {
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            CommonExchange.AccessRightsGranted accessInfo = new CommonExchange.AccessRightsGranted();

                            accessInfo.RightsGrantedId = ProcStatic.DataReaderConvert(sqlReader, "rights_granted_id", Int64.Parse("0"));

                            accessInfo.AccessRightsInfo.AccessIndex = ProcStatic.DataReaderConvert(sqlReader, "access_index", Byte.Parse("0"));
                            accessInfo.AccessRightsInfo.AccessRights = ProcStatic.DataReaderConvert(sqlReader, "access_rights", String.Empty);
                            accessInfo.AccessRightsInfo.AccessDescription = ProcStatic.DataReaderConvert(sqlReader, "access_description", String.Empty);

                            accessInfo.DepartmentInfo.DepartmentId = ProcStatic.DataReaderConvert(sqlReader, "department_id", String.Empty);
                            accessInfo.DepartmentInfo.DepartmentName = ProcStatic.DataReaderConvert(sqlReader, "department_name", String.Empty);
                            accessInfo.DepartmentInfo.Acronym = ProcStatic.DataReaderConvert(sqlReader, "acronym", String.Empty);
                            accessInfo.DepartmentInfo.IdPrefix = ProcStatic.DataReaderConvert(sqlReader, "id_prefix", String.Empty);

                            retrieveUserInfo.AccessRightsGrantedList.Add(accessInfo);
                        }
                    }
                }
            }

            return retrieveUserInfo;
        } //--------------------------------------

        //this function determines if the system usage has already expired
        private Boolean IsExpiredSystemLicense(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            DateTime serverDateTime = DateTime.MinValue;
            DateTime licenseInstalled = DateTime.MinValue;

            if (!DateTime.TryParse(userInfo.InstallationDate, out licenseInstalled))
            {
                using (RemSrvBaseManager remSrv = new RemSrvBaseManager())
                {
                    licenseInstalled = serverDateTime = DateTime.Parse(remSrv.GetServerDateTimeNoAuthenticate(sqlConn));
                }
            }
            else
            {
                using (RemSrvBaseManager remSrv = new RemSrvBaseManager())
                {
                    serverDateTime = DateTime.Parse(remSrv.GetServerDateTimeNoAuthenticate(sqlConn));
                }
            }

            if ((DateTime.Compare(serverDateTime, licenseInstalled) < 0 ||
                DateTime.Compare(serverDateTime, DateTime.Parse(CommonExchange.SchoolInformation.LicenseExpire)) > 0) ||
               (DateTime.Compare(DateTime.Now, licenseInstalled) < 0 ||
                DateTime.Compare(DateTime.Now, DateTime.Parse(CommonExchange.SchoolInformation.LicenseExpire)) > 0))
            {
                return true;
            }

            return false;
        } //------------------------------

        #endregion
    }
}
