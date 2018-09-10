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

        //this function returns school fee category table
        public static DataTable GetSchoolFeeCategoryTable(SqlConnection sqlConn, String userId)
        {
            DataTable dbTable = new DataTable("SchoolFeeCategoryTable");

            //get the employment type for the employees
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectSchoolFeeCategory";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                {
                    sqlAdapter.SelectCommand = sqlComm;
                    sqlAdapter.Fill(dbTable);
                }
            } //---------------------------------

            return dbTable;

        } //-----------------------------

        //this function returns school fee particular table
        public static DataTable GetSchoolFeeParticularTable(SqlConnection sqlConn, String userId)
        {
            DataTable dbTable = new DataTable("SchoolFeeParticularTable");

            //get the employment type for the employees
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectSchoolFeeParticular";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                {
                    sqlAdapter.SelectCommand = sqlComm;
                    sqlAdapter.Fill(dbTable);
                }
            } //---------------------------------

            return dbTable;

        } //-----------------------------

        //this function returns school fee particular for additional fee table
        public static DataTable GetForAdditionalFeeSchoolFeeParticularTable(SqlConnection sqlConn, String userId)
        {
            DataTable dbTable = new DataTable("ForAdditionalFeeSchoolFeeParticularTable");

            //get the employment type for the employees
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectForAdditionalFeeSchoolFeeParticular";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                {
                    sqlAdapter.SelectCommand = sqlComm;
                    sqlAdapter.Fill(dbTable);
                }
            } //---------------------------------

            return dbTable;

        } //-----------------------------

        //this function returns school fee information table
        public static DataTable GetSchoolFeeInformationTable(SqlConnection sqlConn, String userId, String serverDateTime)
        {
            DataTable dbTable = new DataTable("SchoolFeeInformationTable");
            dbTable.Columns.Add("sysid_schoolfee", System.Type.GetType("System.String"));
            dbTable.Columns.Add("year_id", System.Type.GetType("System.String"));
            dbTable.Columns.Add("year_description", System.Type.GetType("System.String"));
            dbTable.Columns.Add("date_start", System.Type.GetType("System.String"));
            dbTable.Columns.Add("date_end", System.Type.GetType("System.String"));
            dbTable.Columns.Add("is_summer", System.Type.GetType("System.Boolean"));

            //get the employment type for the employees
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectSchoolFeeInformation";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                {
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            DataRow newRow = dbTable.NewRow();

                            newRow["sysid_schoolfee"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_schoolfee", "");
                            newRow["year_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "year_id", "");
                            newRow["year_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "year_description", "");
                            newRow["date_start"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "date_start",
                                DateTime.Parse(serverDateTime)).ToString();
                            newRow["date_end"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "date_end",
                                DateTime.Parse(serverDateTime)).ToString();
                            newRow["is_summer"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_summer", false);

                            dbTable.Rows.Add(newRow);
                        }
                    }

                    sqlReader.Close();
                }

                dbTable.AcceptChanges();
            } //---------------------------------

            return dbTable;

        } //-----------------------------        

        #endregion

    }
}
