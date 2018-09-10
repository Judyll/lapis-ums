using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RemoteServerLib
{
    public class RemSrvEarningManager: MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvEarningManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure deletes an employee earning
        public void DeleteEmployeeEarning(CommonExchange.SysAccess userInfo, CommonExchange.EarningInformation incInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.DeleteEmployeeEarning";

                    sqlComm.Parameters.Add("@earning_id", SqlDbType.BigInt).Value = incInfo.EarningId;
                    sqlComm.Parameters.Add("@sysid_employee", SqlDbType.VarChar).Value = incInfo.EmployeeInfo.EmployeeSysId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //--------------------------------------

        //this procedure updates an employee earning
        public void UpdateEmployeeEarning(CommonExchange.SysAccess userInfo, CommonExchange.EarningInformation incInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateEmployeeEarning";

                    sqlComm.Parameters.Add("@earning_id", SqlDbType.BigInt).Value = incInfo.EarningId;
                    sqlComm.Parameters.Add("@earning_date", SqlDbType.DateTime).Value = DateTime.Parse(incInfo.EarningDate);
                    sqlComm.Parameters.Add("@sysid_employee", SqlDbType.VarChar).Value = incInfo.EmployeeInfo.EmployeeSysId;
                    sqlComm.Parameters.Add("@amount", SqlDbType.Decimal).Value = incInfo.Amount;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }

        } //--------------------------------

        //this procedure inserts an employee earning
        public void InsertEmployeeEarning(CommonExchange.SysAccess userInfo, DataTable incTable)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                incTable.AcceptChanges();

                using (DataTable insertTable = new DataTable("EmployeeEarningAppliedForInsert"))
                {
                    insertTable.Columns.Add("earning_date", System.Type.GetType("System.DateTime"));
                    insertTable.Columns.Add("sysid_earning", System.Type.GetType("System.String"));
                    insertTable.Columns.Add("sysid_employee", System.Type.GetType("System.String"));
                    insertTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));

                    foreach (DataRow incRow in incTable.Rows)
                    {
                        DataRow newRow = insertTable.NewRow();

                        newRow["earning_date"] = DateTime.Parse(incRow["earning_date"].ToString());
                        newRow["sysid_earning"] = incRow["sysid_earning"];
                        newRow["sysid_employee"] = incRow["sysid_employee"];
                        newRow["amount"] = incRow["amount"];

                        insertTable.Rows.Add(newRow);
                    }

                    using (SqlCommand sqlComm = new SqlCommand())
                    {
                        sqlComm.Connection = auth.Connection;
                        sqlComm.CommandType = CommandType.StoredProcedure;
                        sqlComm.CommandText = "ums.InsertEmployeeEarning";

                        sqlComm.Parameters.Add("@earning_date", SqlDbType.DateTime).SourceColumn = "earning_date";
                        sqlComm.Parameters.Add("@sysid_earning", SqlDbType.VarChar).SourceColumn = "sysid_earning";
                        sqlComm.Parameters.Add("@sysid_employee", SqlDbType.VarChar).SourceColumn = "sysid_employee";
                        sqlComm.Parameters.Add("@amount", SqlDbType.VarChar).SourceColumn = "amount";

                        sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                        sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                        using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                        {
                            sqlAdapter.InsertCommand = sqlComm;
                            sqlAdapter.Update(insertTable);
                        }
                    }
                }
                
            }

        } //---------------------------

        //this procedure updates a earning information
        public void UpdateEarningInformation(CommonExchange.SysAccess userInfo, CommonExchange.EarningInformation incInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateEarningInformation";

                    sqlComm.Parameters.Add("@sysid_earning", SqlDbType.VarChar).Value = incInfo.EarningSysId;
                    sqlComm.Parameters.Add("@earning_description", SqlDbType.VarChar).Value = incInfo.Description;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }

        } //---------------------------------

        //this procedure adds a new earning information
        public void InsertEarningInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.EarningInformation incInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                incInfo.EarningSysId = PrimaryKeys.GetNewEarningSystemID(userInfo, auth.Connection);

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertEarningInformation";

                    sqlComm.Parameters.Add("@sysid_earning", SqlDbType.VarChar).Value = incInfo.EarningSysId;
                    sqlComm.Parameters.Add("@earning_description", SqlDbType.VarChar).Value = incInfo.Description;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }

        } //-------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function is used to determine if the description exists
        public Boolean IsEarningDescriptionExist(CommonExchange.SysAccess userInfo, String description, String earningSysId)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsExistsDescriptionEarningInformation";

                    sqlComm.Parameters.Add("@sysid_earning", SqlDbType.VarChar).Value = earningSysId;
                    sqlComm.Parameters.Add("@earning_description", SqlDbType.VarChar).Value = description;
                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;
        } //-----------------------------

        //this function is used to get data tables stored in one dataset used for earning information
        public DataSet GetDataSetForEarningInfo(CommonExchange.SysAccess userInfo)
        {
            DataSet dbSet = new DataSet();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                //gets the employee personal and salary information table
                dbSet.Tables.Add(ProcStatic.GetEmployeeInformationTable(auth.Connection, userInfo.UserId));
                //-----------------------

                //gets all the earning information
                dbSet.Tables.Add(ProcStatic.GetAllEarningInformation(auth.Connection, userInfo.UserId));
                //------------------------------------
            }

            return dbSet;
        } //----------------------------------

        //this function gets the selected employee earning
        public DataTable GetByDateFromDateToEmployeeEarning(CommonExchange.SysAccess userInfo, String employeeSysId, String dateFrom,
                   String dateTo, String serverDateTime)
        {
            DataTable dbTable;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                dbTable = ProcStatic.SelectByDateFromDateToSysIDEmployeeEmployeeEarning(auth.Connection, userInfo.UserId, 
                    employeeSysId, dateFrom, dateTo, serverDateTime);
            }

            return dbTable;
        } //--------------------------------------------

        #endregion
    }
}
