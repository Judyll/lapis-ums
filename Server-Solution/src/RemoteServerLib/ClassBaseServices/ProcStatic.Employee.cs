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
        
        //this function returns an employment information table
        public static DataTable GetEmployeeInformationTable(SqlConnection sqlConn, String userId)
        {
            DataTable dbTable = new DataTable("EmployeeInformationTable");

            //get the employment type for the employees
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectEmployeeInformation";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                {
                    sqlAdapter.SelectCommand = sqlComm;
                    sqlAdapter.Fill(dbTable);
                }
            } //---------------------------------

            return dbTable;

        } //-----------------------------

        //this function returns an employment status table
        public static DataTable GetEmploymentStatusTable(SqlConnection sqlConn, String userId)
        {
            DataTable dbTable = new DataTable("EmploymentStatusTable");

            //get the employment type for the employees
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectEmploymentStatus";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                {
                    sqlAdapter.SelectCommand = sqlComm;
                    sqlAdapter.Fill(dbTable);
                }
            } //---------------------------------

            return dbTable;

        } //-----------------------------

        //this function returns the week day table
        public static DataTable GetWeekDayTable(SqlConnection sqlConn, String userId)
        {
            DataTable dbTable = new DataTable("WeekDayTable");

            //get the employment type for the employees
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectWeekDay";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                {
                    sqlAdapter.SelectCommand = sqlComm;
                    sqlAdapter.Fill(dbTable);
                }
            } //---------------------------------

            return dbTable;
        } //--------------------------------

        //this function returns an employment type table
        public static DataTable GetEmploymentTypeTable(SqlConnection sqlConn, String userId)
        {
            DataTable dbTable = new DataTable("EmploymentTypeTable");

            //get the employment type for the employees
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectEmploymentType";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                {
                    sqlAdapter.SelectCommand = sqlComm;
                    sqlAdapter.Fill(dbTable);
                }
            } //---------------------------------

            return dbTable;

        } //------------------------------

        //this function returns the rank level 
        public static DataTable GetRankLevelTable(SqlConnection sqlConn, String userId)
        {
            DataTable dbTable = new DataTable("RankLevelTable");

            //get the current rank level
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectCurrentRankLevel";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                {
                    sqlAdapter.SelectCommand = sqlComm;
                    sqlAdapter.Fill(dbTable);
                }
            } //--------------------------------

            return dbTable;

        } //---------------------------------

        //this function returns the rank category
        public static DataTable GetRankCategoryTable(SqlConnection sqlConn, String userId)
        {
            DataTable dbTable = new DataTable("RankCategoryTable");

            //get the current rank category
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectCurrentRankCategory";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                {
                    sqlAdapter.SelectCommand = sqlComm;
                    sqlAdapter.Fill(dbTable);
                }

            } //--------------------------------

            return dbTable;

        } //-----------------------------------

        //this function returns the rank degree
        public static DataTable GetRankDegreeTable(SqlConnection sqlConn, String userId)
        {
            DataTable dbTable = new DataTable("RankDegreeTable");

            //get the current rank degree
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectCurrentRankDegree";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                {
                    sqlAdapter.SelectCommand = sqlComm;
                    sqlAdapter.Fill(dbTable);
                }

            } //-----------------------------------

            return dbTable;

        } //-----------------------------

        //this function gets all the deduction information
        public static DataTable GetAllDeductionInformation(SqlConnection sqlConn, String userId)
        {
            DataTable dbTable = new DataTable("DeductionInformationTable");

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectDeductionInformation";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                {
                    sqlAdapter.SelectCommand = sqlComm;
                    sqlAdapter.Fill(dbTable);
                }
            }

            return dbTable;
            
        } //--------------------------   
    
        //this function gets the employee deduction by date
        public static DataTable SelectByDateFromDateToSysIDEmployeeEmployeeDeduction(SqlConnection sqlConn, String userId, String employeeSysId,
                String dateFrom, String dateTo, String serverDateTime)
        {
            DataTable dbTable = new DataTable("EmployeeDeductionByDateTable");
            dbTable.Columns.Add("deduction_id", System.Type.GetType("System.Int64"));
            dbTable.Columns.Add("deduction_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("deduction_description", System.Type.GetType("System.String"));
            dbTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectByDateFromDateToSysIDEmployeeEmployeeDeduction";

                sqlComm.Parameters.Add("@sysid_employee", SqlDbType.VarChar).Value = employeeSysId;
                sqlComm.Parameters.Add("@date_from", SqlDbType.DateTime).Value = DateTime.Parse(dateFrom);
                sqlComm.Parameters.Add("@date_to", SqlDbType.DateTime).Value = DateTime.Parse(dateTo);

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                {
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            DataRow newRow = dbTable.NewRow();

                            newRow["deduction_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "deduction_id", Int64.Parse("0"));
                            newRow["deduction_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "deduction_date",
                                DateTime.Parse(serverDateTime)).ToShortDateString();
                            newRow["deduction_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "deduction_description", "");
                            newRow["amount"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "amount", Decimal.Parse("0"));

                            dbTable.Rows.Add(newRow);
                        }
                    }

                    sqlReader.Close();
                }

                dbTable.AcceptChanges();
            }

            return dbTable;
        } //-----------------------------------------

        //this function gets all the earning information
        public static DataTable GetAllEarningInformation(SqlConnection sqlConn, String userId)
        {
            DataTable dbTable = new DataTable("EarningInformationTable");

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectEarningInformation";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                {
                    sqlAdapter.SelectCommand = sqlComm;
                    sqlAdapter.Fill(dbTable);
                }
            }

            return dbTable;

        } //--------------------------   

        //this function gets the employee earning by date
        public static DataTable SelectByDateFromDateToSysIDEmployeeEmployeeEarning(SqlConnection sqlConn, String userId, String employeeSysId,
                String dateFrom, String dateTo, String serverDateTime)
        {
            DataTable dbTable = new DataTable("EmployeeEarningByDateTable");
            dbTable.Columns.Add("earning_id", System.Type.GetType("System.Int64"));
            dbTable.Columns.Add("earning_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("earning_description", System.Type.GetType("System.String"));
            dbTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectByDateFromDateToSysIDEmployeeEmployeeEarning";

                sqlComm.Parameters.Add("@sysid_employee", SqlDbType.VarChar).Value = employeeSysId;
                sqlComm.Parameters.Add("@date_from", SqlDbType.DateTime).Value = DateTime.Parse(dateFrom);
                sqlComm.Parameters.Add("@date_to", SqlDbType.DateTime).Value = DateTime.Parse(dateTo);

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                {
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            DataRow newRow = dbTable.NewRow();

                            newRow["earning_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "earning_id", Int64.Parse("0"));
                            newRow["earning_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "earning_date",
                                DateTime.Parse(serverDateTime)).ToShortDateString();
                            newRow["earning_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "earning_description", "");
                            newRow["amount"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "amount", Decimal.Parse("0"));

                            dbTable.Rows.Add(newRow);
                        }
                    }

                    sqlReader.Close();
                }

                dbTable.AcceptChanges();                
            }

            return dbTable;
        } //-----------------------------------------

        //this function gets all the loan type information
        public static DataTable GetAllLoanTypeInformation(SqlConnection sqlConn, String userId)
        {
            DataTable dbTable = new DataTable("LoanTypeInformationTable");

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectLoanTypeInformation";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                {
                    sqlAdapter.SelectCommand = sqlComm;
                    sqlAdapter.Fill(dbTable);
                }
            }

            return dbTable;

        } //--------------------------   

        //this function returns all employee with their personal and salary information
        public static DataTable GetEmployeeInformationWithActiveLoans(SqlConnection sqlConn, String userId)
        {
            DataTable dbTable = new DataTable("EmployeeWithOutstandingLoansTable");
            dbTable.Columns.Add("sysid_employee", System.Type.GetType("System.String"));
            dbTable.Columns.Add("employee_id", System.Type.GetType("System.String"));
            dbTable.Columns.Add("card_number", System.Type.GetType("System.String"));
            dbTable.Columns.Add("sysid_person", System.Type.GetType("System.String"));
            dbTable.Columns.Add("last_name", System.Type.GetType("System.String"));
            dbTable.Columns.Add("first_name", System.Type.GetType("System.String"));
            dbTable.Columns.Add("middle_name", System.Type.GetType("System.String"));
            dbTable.Columns.Add("outstanding_loans", System.Type.GetType("System.Int16"));
            dbTable.Columns.Add("status_id", System.Type.GetType("System.Byte"));

            //get the employment type for the employees
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectEmployeeInformationLoanRemittance";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                {
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            DataRow newRow = dbTable.NewRow();

                            newRow["sysid_employee"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_employee", String.Empty);
                            newRow["employee_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "employee_id", String.Empty);
                            newRow["card_number"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "card_number", String.Empty);
                            newRow["sysid_person"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_person", String.Empty);
                            newRow["last_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "last_name", String.Empty);
                            newRow["first_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "first_name", String.Empty);
                            newRow["middle_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "middle_name", String.Empty);
                            newRow["outstanding_loans"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "outstanding_loans", Int16.Parse("0"));                            
                            newRow["status_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "status_id", Byte.Parse("0"));

                            dbTable.Rows.Add(newRow);

                        }
                    }

                    sqlReader.Close();
                }

                dbTable.AcceptChanges();

            } //---------------------------------

            return dbTable;

        } //------------------------------        

        #endregion
    }
}
