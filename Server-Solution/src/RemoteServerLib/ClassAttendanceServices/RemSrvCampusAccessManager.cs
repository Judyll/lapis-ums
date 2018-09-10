using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RemoteServerLib
{
    public class RemSrvCampusAccessManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor
        public RemSrvCampusAccessManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a campus access details
        public void InsertCampusAccessDetails(CommonExchange.SysAccess userInfo, DataTable campusAccessDetailsTable)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand insertComm = new SqlCommand())
                {
                    insertComm.Connection = auth.Connection;
                    insertComm.CommandType = CommandType.StoredProcedure;
                    insertComm.CommandText = "ums.InsertCampusAccessDetails";

                    insertComm.Parameters.Add("@sysid_person", SqlDbType.VarChar).SourceColumn = "sysid_person";
                    insertComm.Parameters.Add("@access_date_time", SqlDbType.DateTime).SourceColumn = "access_date_time";
                    insertComm.Parameters.Add("@access_point_id", SqlDbType.VarChar).SourceColumn = "access_point_id";

                    insertComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    insertComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                    {
                        sqlAdapter.InsertCommand = insertComm;

                        sqlAdapter.Update(campusAccessDetailsTable);
                    }
                }
            }
        } //----------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function gets the student and employee table query
        public DataTable SelectForCampusAccessStudentEmployeeInformation(CommonExchange.SysAccess userInfo, String queryString)
        {
            DataTable dbTable = new DataTable("StudentEmployeeForCampusAccessInformationTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectForCampusAccessStudentEmployeeInformation";

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
        } //-------------------------------------

        //this function gets the campus access by sysid_person list
        public DataTable SelectByPersonSysIDListDateStartEndCampusAccessDetails(CommonExchange.SysAccess userInfo, String personSysIdList,
            String dateStart, String dateEnd)
        {
            DataTable dbTable = new DataTable("CampusAccessDetailsTable");
            dbTable.Columns.Add("details_id", System.Type.GetType("System.Int64"));
		    dbTable.Columns.Add("access_date_time", System.Type.GetType("System.String"));
            dbTable.Columns.Add("access_description", System.Type.GetType("System.String"));

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectByPersonSysIDListDateStartEndCampusAccessDetails";

                    if (String.IsNullOrEmpty(personSysIdList))
                    {
                        sqlComm.Parameters.Add("@sysid_person_list", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@sysid_person_list", SqlDbType.NVarChar).Value = personSysIdList;
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

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                DataRow newRow = dbTable.NewRow();

                                newRow["details_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "details_id", Int64.Parse("0"));
                                newRow["access_date_time"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "access_date_time", 
                                    DateTime.MinValue).ToString();
                                newRow["access_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "access_description", String.Empty);

                                dbTable.Rows.Add(newRow);
                            }
                        }

                        sqlReader.Close();
                    }
                }

                dbTable.AcceptChanges();
            }

            return dbTable;

        } //------------------------------

        //this function is used to get data tables stored in one dataset used for campus access
        public DataSet GetDataSetForCampusAccess(CommonExchange.SysAccess userInfo)
        {
            DataSet dbSet = new DataSet();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                //gets the campus access point information table
                dbSet.Tables.Add(ProcStatic.GetAccessPointInformationTable(auth.Connection, userInfo.UserId));
                //------------------------------------
            }

            return dbSet;
        } //----------------------------------

        #endregion
    }
}
