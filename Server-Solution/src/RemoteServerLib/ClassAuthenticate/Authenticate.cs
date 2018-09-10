using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Net.NetworkInformation;

namespace RemoteServerLib
{
    internal class Authenticate: IDisposable
    {
        #region Class Properties Declarations

        private SqlConnection _sqlConn;
        public SqlConnection Connection
        {
            get { return _sqlConn; }
        }

        private CommonExchange.SysAccess _userInfo;
        public CommonExchange.SysAccess UserInfo
        {
            get { return _userInfo; }
        }

        #endregion

        #region Class Constructor and Destructor

        public Authenticate(CommonExchange.SysAccess userInfo, CommonExchange.TransactionSource source)
        {
            if (!IsValidated(userInfo, CommonExchange.ServerCode.PrimaryServer, source))
            {
                throw new Exception("Only authenticated users are allowed to access the system.");
            }
        }

        public Authenticate(CommonExchange.SysAccess userInfo, CommonExchange.ServerCode sCode, CommonExchange.TransactionSource source)
        {
            if (!IsValidated(userInfo, sCode, source))
            {
                throw new Exception("Only authenticated users are allowed to access the system.");
            }
        }
          
        void IDisposable.Dispose()
        {

            if (_sqlConn != null && _sqlConn.State == ConnectionState.Open)
            {
                _sqlConn.Close();
            }
            
        }

        #endregion

        #region Programmer-Defined Function Procedure

        private Boolean IsValidated(CommonExchange.SysAccess userInfo, CommonExchange.ServerCode sCode, CommonExchange.TransactionSource source)
        {
            Boolean isPrimary = false;
            Boolean hasAccess = false;

            SqlConnection sqlConn;
            sqlConn = new SqlConnection();

            if (DataServer.IsLocalHost)
            {
                sqlConn.ConnectionString = "Integrated Security = SSPI; Data Source = Localhost; Initial Catalog = " + 
                    DataServer.InitialCatalog + "; User Id = " + DataServer.UserId + "; Password = " + DataServer.Password + ";";
            }
            else
            {
                if (sCode == CommonExchange.ServerCode.PrimaryServer)
                {
                    using (Ping ping = new Ping())
                    {
                        PingReply reply = ping.Send(DataServer.PrimaryIp, 10);

                        if (reply.Status == IPStatus.Success)
                        {
                            sqlConn.ConnectionString = "Data Source = " + DataServer.PrimaryIp + ", 1433; Network Library = DBMSSOCN; Initial Catalog = " +
                                DataServer.InitialCatalog + "; User Id = " + DataServer.UserId + "; Password = " + DataServer.Password + ";";

                            isPrimary = true;
                        }
                        else
                        {
                            sqlConn.ConnectionString = "Data Source = " + DataServer.FailOverIp + ", 1433; Network Library = DBMSSOCN; Initial Catalog = " +
                                DataServer.InitialCatalog + "; User Id = " + DataServer.UserId + "; Password = " + DataServer.Password + ";";

                            isPrimary = false;
                        }
                    }                    
                }
                else if (sCode == CommonExchange.ServerCode.FailOverServer)
                {
                    using (Ping ping = new Ping())
                    {
                        PingReply reply = ping.Send(DataServer.FailOverIp, 10);

                        if (reply.Status == IPStatus.Success)
                        {
                            sqlConn.ConnectionString = "Data Source = " + DataServer.FailOverIp + ", 1433; Network Library = DBMSSOCN; Initial Catalog = " +
                                DataServer.InitialCatalog + "; User Id = " + DataServer.UserId + "; Password = " + DataServer.Password + ";";

                            isPrimary = false;
                        }
                        else
                        {
                            sqlConn.ConnectionString = "Data Source = " + DataServer.PrimaryIp + ", 1433; Network Library = DBMSSOCN; Initial Catalog = " +
                                DataServer.InitialCatalog + "; User Id = " + DataServer.UserId + "; Password = " + DataServer.Password + ";";

                            isPrimary = true;
                        }
                    }  
                }
            }

            //force reconnection if an exception occurs
            try
            {
                sqlConn.Open();
            }
            catch
            {
                sqlConn = new SqlConnection();

                if (isPrimary)
                {
                    sqlConn.ConnectionString = "Data Source = " + DataServer.FailOverIp + ", 1433; Network Library = DBMSSOCN; Initial Catalog = " +
                                DataServer.InitialCatalog + "; User Id = " + DataServer.UserId + "; Password = " + DataServer.Password + ";";
                }
                else
                {
                    sqlConn.ConnectionString = "Data Source = " + DataServer.PrimaryIp + ", 1433; Network Library = DBMSSOCN; Initial Catalog = " +
                                DataServer.InitialCatalog + "; User Id = " + DataServer.UserId + "; Password = " + DataServer.Password + ";";
                }

                sqlConn.Open();
            } //----------------------------------

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;

                if (source.IsSystemUser)
                {
                    sqlComm.CommandText = "ums.SelectForSystemLogInSystemUserInfo";
                }
                else
                {
                    sqlComm.CommandText = String.Empty;
                }

                if (!String.IsNullOrEmpty(sqlComm.CommandText))
                {

                    sqlComm.Parameters.Add("@system_user_name", SqlDbType.VarChar).Value = userInfo.UserName;
                    sqlComm.Parameters.Add("@system_user_password", SqlDbType.VarChar).Value = userInfo.Password;
                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;

                    sqlComm.Parameters.Add("@is_for_log_in", SqlDbType.Bit).Value = source.IsForLogIn;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            if (source.IsForLogIn)
                            {
                                while (sqlReader.Read())
                                {
                                    userInfo.UserId = ProcStatic.DataReaderConvert(sqlReader, "system_user_id", String.Empty);
                                    userInfo.UserName = ProcStatic.DataReaderConvert(sqlReader, "system_user_name", String.Empty);
                                    userInfo.Password = ProcStatic.DataReaderConvert(sqlReader, "system_user_password", String.Empty);
                                    userInfo.UserStatus = ProcStatic.DataReaderConvert(sqlReader, "system_user_status", false);
                                    userInfo.PersonInfo.LastName = ProcStatic.DataReaderConvert(sqlReader, "last_name", String.Empty);
                                    userInfo.PersonInfo.FirstName = ProcStatic.DataReaderConvert(sqlReader, "first_name", String.Empty);
                                    userInfo.PersonInfo.MiddleName = ProcStatic.DataReaderConvert(sqlReader, "middle_name", String.Empty);
                                    userInfo.InstallationDate = ProcStatic.DataReaderConvert(sqlReader, "installation_date", String.Empty);

                                    break;
                                }
                            }

                            _sqlConn = sqlConn;
                            hasAccess = true;
                        }
                        else
                        {
                            _sqlConn = null;
                            hasAccess = false;
                        }

                        sqlReader.Close();
                    }
                }
                else
                {
                    _sqlConn = null;
                    hasAccess = false;
                }
                

            }

            if (hasAccess && source.IsForLogIn)
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = sqlConn;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySystemUserIdAccessRightsGranted";

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;
                    sqlComm.Parameters.Add("@system_user_name", SqlDbType.VarChar).Value = userInfo.UserName;
                    sqlComm.Parameters.Add("@system_user_password", SqlDbType.VarChar).Value = userInfo.Password;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                CommonExchange.AccessRightsGranted accessInfo = new CommonExchange.AccessRightsGranted();

                                accessInfo.RightsGrantedId = ProcStatic.DataReaderConvert(sqlReader, "rights_granted_id", Int64.Parse("0"));
	                            
                                accessInfo.AccessRightsInfo.AccessIndex = ProcStatic.DataReaderConvert(sqlReader, "access_index", Byte.Parse("0"));
	                            accessInfo.AccessRightsInfo.AccessDescription = ProcStatic.DataReaderConvert(sqlReader, "access_description", String.Empty);

		                        accessInfo.DepartmentInfo.DepartmentId = ProcStatic.DataReaderConvert(sqlReader, "department_id", String.Empty);
	                            accessInfo.DepartmentInfo.DepartmentName = ProcStatic.DataReaderConvert(sqlReader, "department_name", String.Empty);
	                            accessInfo.DepartmentInfo.Acronym = ProcStatic.DataReaderConvert(sqlReader, "acronym", String.Empty);
                                accessInfo.DepartmentInfo.IdPrefix = ProcStatic.DataReaderConvert(sqlReader, "id_prefix", String.Empty);

                                userInfo.AccessRightsGrantedList.Add(accessInfo);
                            }
                        }
                    }
                }

                _userInfo = userInfo;
            }

            return hasAccess;
        }

        #endregion

    }

}
