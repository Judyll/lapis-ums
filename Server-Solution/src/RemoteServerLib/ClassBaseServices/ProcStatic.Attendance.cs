using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RemoteServerLib
{
    partial class ProcStatic
    {
        //this function returns access point information table
        public static DataTable GetAccessPointInformationTable(SqlConnection sqlConn, String userId)
        {
            DataTable dbTable = new DataTable("AccessPointInformationTable");

            //get the employment type for the employees
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectAccessPointInformation";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                {
                    sqlAdapter.SelectCommand = sqlComm;
                    sqlAdapter.Fill(dbTable);
                }
            } //---------------------------------

            return dbTable;

        } //-----------------------------
    }
}
