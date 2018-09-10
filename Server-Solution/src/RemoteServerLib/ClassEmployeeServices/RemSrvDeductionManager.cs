using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RemoteServerLib
{
    public class RemSrvDeductionManager: MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvDeductionManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure deletes an employee deduction
        public void DeleteEmployeeDeduction(CommonExchange.SysAccess userInfo, CommonExchange.DeductionInformation decInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.DeleteEmployeeDeduction";

                    sqlComm.Parameters.Add("@deduction_id", SqlDbType.BigInt).Value = decInfo.DeductionId;
                    sqlComm.Parameters.Add("@sysid_employee", SqlDbType.VarChar).Value = decInfo.EmployeeInfo.EmployeeSysId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //--------------------------------------

        //this procedure updates an employee deduction
        public void UpdateEmployeeDeduction(CommonExchange.SysAccess userInfo, CommonExchange.DeductionInformation decInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateEmployeeDeduction";

                    sqlComm.Parameters.Add("@deduction_id", SqlDbType.BigInt).Value = decInfo.DeductionId;
                    sqlComm.Parameters.Add("@deduction_date", SqlDbType.DateTime).Value = DateTime.Parse(decInfo.DeductionDate);
                    sqlComm.Parameters.Add("@sysid_employee", SqlDbType.VarChar).Value = decInfo.EmployeeInfo.EmployeeSysId;
                    sqlComm.Parameters.Add("@amount", SqlDbType.Decimal).Value = decInfo.Amount;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }

        } //--------------------------------

        //this procedure inserts an employee deduction
        public void InsertEmployeeDeduction(CommonExchange.SysAccess userInfo, DataTable decTable)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                decTable.AcceptChanges();

                using (DataTable insertTable = new DataTable("EmployeeDeductionsAppliedForInsert"))
                {
                    insertTable.Columns.Add("deduction_date", System.Type.GetType("System.DateTime"));
                    insertTable.Columns.Add("sysid_deduction", System.Type.GetType("System.String"));
                    insertTable.Columns.Add("sysid_employee", System.Type.GetType("System.String"));
                    insertTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));

                    foreach (DataRow decRow in decTable.Rows)
                    {
                        DataRow newRow = insertTable.NewRow();

                        newRow["deduction_date"] = DateTime.Parse(decRow["deduction_date"].ToString());
                        newRow["sysid_deduction"] = decRow["sysid_deduction"];
                        newRow["sysid_employee"] = decRow["sysid_employee"];
                        newRow["amount"] = decRow["amount"];

                        insertTable.Rows.Add(newRow);
                    }

                    using (SqlCommand sqlComm = new SqlCommand())
                    {
                        sqlComm.Connection = auth.Connection;
                        sqlComm.CommandType = CommandType.StoredProcedure;
                        sqlComm.CommandText = "ums.InsertEmployeeDeduction";

                        sqlComm.Parameters.Add("@deduction_date", SqlDbType.DateTime).SourceColumn = "deduction_date";
                        sqlComm.Parameters.Add("@sysid_deduction", SqlDbType.VarChar).SourceColumn = "sysid_deduction";
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

        //this procedure updates a deduction information
        public void UpdateDeductionInformation(CommonExchange.SysAccess userInfo, CommonExchange.DeductionInformation decInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateDeductionInformation";

                    sqlComm.Parameters.Add("@sysid_deduction", SqlDbType.VarChar).Value = decInfo.DeductionSysId;
                    sqlComm.Parameters.Add("@deduction_description", SqlDbType.VarChar).Value = decInfo.Description;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }

        } //---------------------------------

        //this procedure adds a new deduction information
        public void InsertDeductionInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.DeductionInformation decInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                decInfo.DeductionSysId = PrimaryKeys.GetNewDeductionSystemID(userInfo, auth.Connection);

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertDeductionInformation";

                    sqlComm.Parameters.Add("@sysid_deduction", SqlDbType.VarChar).Value = decInfo.DeductionSysId;
                    sqlComm.Parameters.Add("@deduction_description", SqlDbType.VarChar).Value = decInfo.Description;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }

        } //-------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function is used to determine if the description exists
        public Boolean IsDeductionDescriptionExist(CommonExchange.SysAccess userInfo, String description, String deductionSysId)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsExistsDescriptionDeductionInformation";

                    sqlComm.Parameters.Add("@sysid_deduction", SqlDbType.VarChar).Value = deductionSysId;
                    sqlComm.Parameters.Add("@deduction_description", SqlDbType.VarChar).Value = description;
                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;
        } //-----------------------------

        //this function is used to get data tables stored in one dataset used for deduction information
        public DataSet GetDataSetForDeductionInfo(CommonExchange.SysAccess userInfo)
        {
            DataSet dbSet = new DataSet();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                //gets the employee personal and salary information table
                dbSet.Tables.Add(ProcStatic.GetEmployeeInformationTable(auth.Connection, userInfo.UserId));
                //-----------------------

                //gets all the deduction information
                dbSet.Tables.Add(ProcStatic.GetAllDeductionInformation(auth.Connection, userInfo.UserId));
                //------------------------------------
            }

            return dbSet;
        } //----------------------------------

        //this function gets the selected employee deduction
        public DataTable GetByDateFromDateToEmployeeDeduction(CommonExchange.SysAccess userInfo, String employeeSysId, String dateFrom,
                   String dateTo, String serverDateTime)
        {
            DataTable dbTable;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                dbTable = ProcStatic.SelectByDateFromDateToSysIDEmployeeEmployeeDeduction(auth.Connection, userInfo.UserId, 
                    employeeSysId, dateFrom, dateTo, serverDateTime);
            }

            return dbTable;
        } //--------------------------------------------

        
        #endregion
    }
}
