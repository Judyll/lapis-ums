using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RemoteServerLib
{
    partial class ProcStatic
    {
        #region Programmer-Defined Function Procedures

        //this function returns the week time table
        public static DataTable GetWeekTimeTable(SqlConnection sqlConn, String userId)
        {
            DataTable dbTable = new DataTable("WeekTimeTable");

            //get the employment type for the employees
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectWeekTime";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                {
                    sqlAdapter.SelectCommand = sqlComm;
                    sqlAdapter.Fill(dbTable);
                }
            } //---------------------------------

            return dbTable;
        } //--------------------------------

        //this function returns the scholarship information table
        public static DataTable GetScholarshipInformationTable(SqlConnection sqlConn, String userId)
        {
            DataTable dbTable = new DataTable("ScholarshipInformationTable");

            //get the employment type for the employees
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectScholarshipInformation";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                {
                    sqlAdapter.SelectCommand = sqlComm;
                    sqlAdapter.Fill(dbTable);
                }
            } //---------------------------------

            return dbTable;
        } //--------------------------------

        
        #endregion
    }
}
