using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteServerLib
{
    public class RemSrvLoanManager: MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvLoanManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure updates / delete an employee remittance
        public void UpdateDeleteEmployeeRemittance(CommonExchange.SysAccess userInfo, DataTable remTable)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand updateComm = new SqlCommand())
                {
                    updateComm.Connection = auth.Connection;
                    updateComm.CommandType = CommandType.StoredProcedure;
                    updateComm.CommandText = "ums.UpdateEmployeeRemittance";

                    updateComm.Parameters.Add("@remittance_id", SqlDbType.BigInt).SourceColumn = "remittance_id";
                    updateComm.Parameters.Add("@remittance_date", SqlDbType.DateTime).SourceColumn = "remittance_date";
                    updateComm.Parameters.Add("@pay_month", SqlDbType.SmallInt).SourceColumn = "pay_month";
                    updateComm.Parameters.Add("@pay_balance", SqlDbType.SmallInt).SourceColumn = "pay_balance";
                    updateComm.Parameters.Add("@amount_paid", SqlDbType.Decimal).SourceColumn = "amount_paid";
                    updateComm.Parameters.Add("@amount_balance", SqlDbType.Decimal).SourceColumn = "amount_balance";

                    updateComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    updateComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlCommand deleteComm = new SqlCommand())
                    {
                        deleteComm.Connection = auth.Connection;
                        deleteComm.CommandType = CommandType.StoredProcedure;
                        deleteComm.CommandText = "ums.DeleteByRemittanceEmployeeRemittance";

                        deleteComm.Parameters.Add("@remittance_id", SqlDbType.BigInt).SourceColumn = "remittance_id";

                        deleteComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                        deleteComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                        using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                        {
                            sqlAdapter.UpdateCommand = updateComm;
                            sqlAdapter.DeleteCommand = deleteComm;
                            sqlAdapter.Update(remTable);
                        }
                    }
                    
                }
            }

        } //-------------------------

        //this procedure inserts a new employee remittance
        public void InsertEmployeeRemittance(CommonExchange.SysAccess userInfo, CommonExchange.EmployeeLoanRemittance remInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertEmployeeRemittance";

                    sqlComm.Parameters.Add("@sysid_remittance", SqlDbType.VarChar).Value = remInfo.LoanInfo.RemittanceSysId;
                    sqlComm.Parameters.Add("@remittance_date", SqlDbType.DateTime).Value = DateTime.Parse(remInfo.RemittanceDate);
                    sqlComm.Parameters.Add("@pay_month", SqlDbType.SmallInt).Value = remInfo.PayMonth;
                    sqlComm.Parameters.Add("@pay_balance", SqlDbType.SmallInt).Value = remInfo.PayBalance;
                    sqlComm.Parameters.Add("@amount_paid", SqlDbType.Decimal).Value = remInfo.AmountPaid;
                    sqlComm.Parameters.Add("@amount_balance", SqlDbType.Decimal).Value = remInfo.AmountBalance;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }

        } //-----------------------------

        //this procedure deletes a loan remittance information
        public void DeleteLoanRemittance(CommonExchange.SysAccess userInfo, String loanSysId)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.DeleteLoanRemittance";

                    sqlComm.Parameters.Add("@sysid_remittance", SqlDbType.VarChar).Value = loanSysId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //------------------------------

        //this procedure updates a loan remittance information
        public void UpdateLoanRemittance(CommonExchange.SysAccess userInfo, CommonExchange.LoanInformation loanInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateLoanRemittance";

                    sqlComm.Parameters.Add("@sysid_remittance", SqlDbType.VarChar).Value = loanInfo.RemittanceSysId;
                    sqlComm.Parameters.Add("@sysid_loan", SqlDbType.VarChar).Value = loanInfo.LoanSysId;
                    sqlComm.Parameters.Add("@reference_no", SqlDbType.VarChar).Value = loanInfo.ReferenceNo;
                    sqlComm.Parameters.Add("@release_date", SqlDbType.DateTime).Value = DateTime.Parse(loanInfo.ReleaseDate);
                    sqlComm.Parameters.Add("@maturity_date", SqlDbType.DateTime).Value = DateTime.Parse(loanInfo.MaturityDate);
                    sqlComm.Parameters.Add("@principal_interest", SqlDbType.Decimal).Value = loanInfo.PrincipalInterest;
                    sqlComm.Parameters.Add("@monthly_pay", SqlDbType.Decimal).Value = loanInfo.MonthlyAmmortization;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }

        } //--------------------------------

        //this procedure inserts a loan remittance information
        public void InsertLoanRemittance(CommonExchange.SysAccess userInfo, ref CommonExchange.LoanInformation loanInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                loanInfo.RemittanceSysId = PrimaryKeys.GetNewLoanRemittanceSystemID(userInfo, auth.Connection);

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertLoanRemittance";

                    sqlComm.Parameters.Add("@sysid_remittance", SqlDbType.VarChar).Value = loanInfo.RemittanceSysId;
                    sqlComm.Parameters.Add("@sysid_employee", SqlDbType.VarChar).Value = loanInfo.EmployeeInfo.EmployeeSysId;
                    sqlComm.Parameters.Add("@sysid_loan", SqlDbType.VarChar).Value = loanInfo.LoanSysId;
                    sqlComm.Parameters.Add("@reference_no", SqlDbType.VarChar).Value = loanInfo.ReferenceNo;
                    sqlComm.Parameters.Add("@release_date", SqlDbType.DateTime).Value = DateTime.Parse(loanInfo.ReleaseDate);
                    sqlComm.Parameters.Add("@maturity_date", SqlDbType.DateTime).Value = DateTime.Parse(loanInfo.MaturityDate);
                    sqlComm.Parameters.Add("@principal_interest", SqlDbType.Decimal).Value = loanInfo.PrincipalInterest;
                    sqlComm.Parameters.Add("@monthly_pay", SqlDbType.Decimal).Value = loanInfo.MonthlyAmmortization;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }

        } //----------------------------------

        //this procedure updates a loan type information
        public void UpdateLoanTypeInformation(CommonExchange.SysAccess userInfo, CommonExchange.LoanInformation loanInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateLoanTypeInformation";

                    sqlComm.Parameters.Add("@sysid_loan", SqlDbType.VarChar).Value = loanInfo.LoanSysId;
                    sqlComm.Parameters.Add("@loan_description", SqlDbType.VarChar).Value = loanInfo.Description;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }

        } //---------------------------------


        //this procedure inserts a new loan type information
        public void InsertLoanTypeInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.LoanInformation loanInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                loanInfo.LoanSysId = PrimaryKeys.GetNewLoanTypeSystemID(userInfo, auth.Connection);

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertLoanTypeInformation";

                    sqlComm.Parameters.Add("@sysid_loan", SqlDbType.VarChar).Value = loanInfo.LoanSysId;
                    sqlComm.Parameters.Add("@loan_description", SqlDbType.VarChar).Value = loanInfo.Description;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }

        } //-------------------------------
        #endregion

        #region Programmer-Defined Function Procedures

        //this function is used to determine if the description exists
        public Boolean IsLoanTypeDescriptionExist(CommonExchange.SysAccess userInfo, String description, String loanSysId)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsExistsDescriptionLoanTypeInformation";

                    sqlComm.Parameters.Add("@sysid_loan", SqlDbType.VarChar).Value = loanSysId;
                    sqlComm.Parameters.Add("@loan_description", SqlDbType.VarChar).Value = description;
                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;
        } //-----------------------------

        //this function is used to get data tables stored in one dataset used for loan type information
        public DataSet GetDataSetForLoanTypeInfo(CommonExchange.SysAccess userInfo)
        {
            DataSet dbSet = new DataSet();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                //gets the employee personal and salary information table
                dbSet.Tables.Add(ProcStatic.GetEmployeeInformationWithActiveLoans(auth.Connection, userInfo.UserId));
                //-----------------------

                //gets all the loan type information
                dbSet.Tables.Add(ProcStatic.GetAllLoanTypeInformation(auth.Connection, userInfo.UserId));
                //------------------------------------
            }

            return dbSet;
        } //----------------------------------

        //this function is sued to get the employee remittance by employee id
        public DataTable SelectByEmployeeIDEmployeeRemittance(CommonExchange.SysAccess userInfo, String empSysId)
        {
            DataTable dbTable = new DataTable("EmployeeRemittanceByEmployeeIDTable");
            dbTable.Columns.Add("remittance_id", System.Type.GetType("System.Int64"));
            dbTable.Columns.Add("sysid_remittance", System.Type.GetType("System.String"));
            dbTable.Columns.Add("remittance_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("pay_month", System.Type.GetType("System.Int16"));
            dbTable.Columns.Add("pay_balance", System.Type.GetType("System.Int16"));
            dbTable.Columns.Add("amount_paid", System.Type.GetType("System.Decimal"));
            dbTable.Columns.Add("amount_balance", System.Type.GetType("System.Decimal"));

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectByEmployeeIDEmployeeRemittance";

                    sqlComm.Parameters.Add("@sysid_employee", SqlDbType.VarChar).Value = empSysId;
                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                DataRow newRow = dbTable.NewRow();

                                newRow["remittance_id"] = ProcStatic.DataReaderConvert(sqlReader, "remittance_id", Int64.Parse("0"));
                                newRow["sysid_remittance"] = ProcStatic.DataReaderConvert(sqlReader, "sysid_remittance", "");
                                newRow["remittance_date"] = ProcStatic.DataReaderConvert(sqlReader, "remittance_date", "");
                                newRow["pay_month"] = ProcStatic.DataReaderConvert(sqlReader, "pay_month", Int16.Parse("0"));
                                newRow["pay_balance"] = ProcStatic.DataReaderConvert(sqlReader, "pay_balance", Int16.Parse("0"));
                                newRow["amount_paid"] = ProcStatic.DataReaderConvert(sqlReader, "amount_paid", Decimal.Parse("0"));
                                newRow["amount_balance"] = ProcStatic.DataReaderConvert(sqlReader, "amount_balance", Decimal.Parse("0"));

                                dbTable.Rows.Add(newRow);
                                
                            }
                        }

                        sqlReader.Close();
                    }
                }
            }

            dbTable.AcceptChanges();

            return dbTable;

        } //-----------------------------

        //this function is used to get the loan remittance by employee id
        public DataTable SelectByEmployeeIDLoanRemittance(CommonExchange.SysAccess userInfo, String empSysId)
        {
            DataTable dbTable = new DataTable("LoanRemittanceByEmployeeIDTable");
            dbTable.Columns.Add("sysid_remittance", System.Type.GetType("System.String"));
            dbTable.Columns.Add("sysid_loan", System.Type.GetType("System.String"));
            dbTable.Columns.Add("reference_no", System.Type.GetType("System.String"));
            dbTable.Columns.Add("loan_description", System.Type.GetType("System.String"));
            dbTable.Columns.Add("release_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("maturity_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("principal_interest", System.Type.GetType("System.Decimal"));
            dbTable.Columns.Add("monthly_pay", System.Type.GetType("System.Decimal"));

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectByEmployeeIDLoanRemittance";

                    sqlComm.Parameters.Add("@sysid_employee", SqlDbType.VarChar).Value = empSysId;
                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                DataRow newRow = dbTable.NewRow();

                                newRow["sysid_remittance"] = ProcStatic.DataReaderConvert(sqlReader, "sysid_remittance", "");
                                newRow["sysid_loan"] = ProcStatic.DataReaderConvert(sqlReader, "sysid_loan", "");
                                newRow["reference_no"] = ProcStatic.DataReaderConvert(sqlReader, "reference_no", "");
                                newRow["loan_description"] = ProcStatic.DataReaderConvert(sqlReader, "loan_description", "");
                                newRow["release_date"] = ProcStatic.DataReaderConvert(sqlReader, "release_date", "");
                                newRow["maturity_date"] = ProcStatic.DataReaderConvert(sqlReader, "maturity_date", "");
                                newRow["principal_interest"] = ProcStatic.DataReaderConvert(sqlReader, "principal_interest", Decimal.Parse("0"));
                                newRow["monthly_pay"] = ProcStatic.DataReaderConvert(sqlReader, "monthly_pay", Decimal.Parse("0"));

                                dbTable.Rows.Add(newRow);
                            }
                        }

                        sqlReader.Close();
                    }
                }
            }

            dbTable.AcceptChanges();

            return dbTable;
        } //------------------------------------


        #endregion
    }
}
