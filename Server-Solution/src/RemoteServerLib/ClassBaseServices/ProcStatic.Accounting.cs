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

        //this function returns accounting category table
        public static DataTable GetAccountingCategoryTable(SqlConnection sqlConn, String userId)
        {
            DataTable dbTable = new DataTable("AccountingCategoryTable");

            //get the accounting category
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectAccountingCategory";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                {
                    sqlAdapter.SelectCommand = sqlComm;
                    sqlAdapter.Fill(dbTable);
                }
            } //---------------------------------

            return dbTable;

        } //-----------------------------

        #endregion
    }
}
