using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteServerLib
{
    public class RemSrvAccountingManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvAccountingManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        /// <summary>
        /// This procedure inserts a new chart of account
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="chartOfAccount"></param>
        public void InsertChartOfAccounts(CommonExchange.SysAccess userInfo, ref CommonExchange.ChartOfAccount chartOfAccount)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertChartOfAccounts";

                    sqlComm.Parameters.Add("@sysid_account", SqlDbType.VarChar).Value = chartOfAccount.AccountSysId = 
                        PrimaryKeys.GetNewChartOfAccountsSystemID(userInfo, auth.Connection);
                    sqlComm.Parameters.Add("@accounting_category_id", SqlDbType.VarChar).Value = chartOfAccount.AccountingCategoryInfo.AccountingCategoryId;
                    sqlComm.Parameters.Add("@account_code", SqlDbType.VarChar).Value = chartOfAccount.AccountCode;
                    sqlComm.Parameters.Add("@account_name", SqlDbType.VarChar).Value = chartOfAccount.AccountName;
                    sqlComm.Parameters.Add("@account_description", SqlDbType.VarChar).Value = chartOfAccount.AccountDescription;
                    sqlComm.Parameters.Add("@company_policy_procedure", SqlDbType.VarChar).Value = chartOfAccount.CompanyPolicyProcedure;

                    if (String.IsNullOrEmpty(chartOfAccount.SummaryAccount.AccountSysId))
                    {
                        sqlComm.Parameters.Add("@summary_account", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@summary_account", SqlDbType.VarChar).Value = chartOfAccount.SummaryAccount.AccountSysId;
                    }

                    sqlComm.Parameters.Add("@is_debit_side_increase", SqlDbType.VarChar).Value = chartOfAccount.IsDebitSideIncrease;
                    sqlComm.Parameters.Add("@is_active_account", SqlDbType.VarChar).Value = chartOfAccount.IsActiveAccount;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------

        /// <summary>
        /// This procedure updates a chart of account
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="chartOfAccount"></param>
        public void UpdateChartOfAccounts(CommonExchange.SysAccess userInfo, CommonExchange.ChartOfAccount chartOfAccount)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateChartOfAccounts";

                    sqlComm.Parameters.Add("@sysid_account", SqlDbType.VarChar).Value = chartOfAccount.AccountSysId;
                    sqlComm.Parameters.Add("@accounting_category_id", SqlDbType.VarChar).Value = chartOfAccount.AccountingCategoryInfo.AccountingCategoryId;
                    sqlComm.Parameters.Add("@account_code", SqlDbType.VarChar).Value = chartOfAccount.AccountCode;
                    sqlComm.Parameters.Add("@account_name", SqlDbType.VarChar).Value = chartOfAccount.AccountName;
                    sqlComm.Parameters.Add("@account_description", SqlDbType.VarChar).Value = chartOfAccount.AccountDescription;
                    sqlComm.Parameters.Add("@company_policy_procedure", SqlDbType.VarChar).Value = chartOfAccount.CompanyPolicyProcedure;

                    if (String.IsNullOrEmpty(chartOfAccount.SummaryAccount.AccountSysId))
                    {
                        sqlComm.Parameters.Add("@summary_account", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@summary_account", SqlDbType.VarChar).Value = chartOfAccount.SummaryAccount.AccountSysId;
                    }

                    sqlComm.Parameters.Add("@is_debit_side_increase", SqlDbType.VarChar).Value = chartOfAccount.IsDebitSideIncrease;
                    sqlComm.Parameters.Add("@is_active_account", SqlDbType.VarChar).Value = chartOfAccount.IsActiveAccount;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        /// <summary>
        /// This function return the chart of accounts table
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="summaryAccount"></param>
        /// <param name="accountinCategoryIdList"></param>
        /// <returns></returns>
        public DataTable SelectChartOfAccounts(CommonExchange.SysAccess userInfo, String queryString, 
            String summaryAccount, String accountingCategoryIdList, Boolean isActiveAccount)
        {
            DataTable dbTable = new DataTable("ChartOfAccountsTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectChartOfAccounts";

                    if (String.IsNullOrEmpty(queryString))
                    {
                        sqlComm.Parameters.Add("@query_string", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@query_string", SqlDbType.VarChar).Value = queryString;
                    }

                    if (String.IsNullOrEmpty(summaryAccount))
                    {
                        sqlComm.Parameters.Add("@summary_account", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@summary_account", SqlDbType.NVarChar).Value = summaryAccount;
                    }

                    if (String.IsNullOrEmpty(accountingCategoryIdList))
                    {
                        sqlComm.Parameters.Add("@accounting_category_id_list", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@accounting_category_id_list", SqlDbType.NVarChar).Value = accountingCategoryIdList;
                    }

                    sqlComm.Parameters.Add("@is_active_account", SqlDbType.Bit).Value = isActiveAccount;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                    {
                        sqlAdapter.SelectCommand = sqlComm;
                        sqlAdapter.Fill(dbTable);
                    }
                }
            }

            return dbTable;

        } //--------------------------------------------------

        /// <summary>
        /// This function returns a chart of account details
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="sqlConn"></param>
        /// <param name="accountSysId"></param>
        /// <returns></returns>
        public CommonExchange.ChartOfAccount SelectBySysIDAccountChartOfAccounts(CommonExchange.SysAccess userInfo, String accountSysId)
        {
            CommonExchange.ChartOfAccount accountInfo = new CommonExchange.ChartOfAccount();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDAccountChartOfAccounts";

                    sqlComm.Parameters.Add("@sysid_account", SqlDbType.VarChar).Value = accountSysId;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                accountInfo.AccountSysId = ProcStatic.DataReaderConvert(sqlReader, "sysid_account", String.Empty);
                                accountInfo.AccountCode = ProcStatic.DataReaderConvert(sqlReader, "account_code", String.Empty);
                                accountInfo.AccountName = ProcStatic.DataReaderConvert(sqlReader, "account_name", String.Empty);
                                accountInfo.AccountDescription = ProcStatic.DataReaderConvert(sqlReader, "account_description", String.Empty);
                                accountInfo.CompanyPolicyProcedure = ProcStatic.DataReaderConvert(sqlReader, "company_policy_procedure", String.Empty);
                                accountInfo.IsDebitSideIncrease = ProcStatic.DataReaderConvert(sqlReader, "is_debit_side_increase", false);
                                accountInfo.IsActiveAccount = ProcStatic.DataReaderConvert(sqlReader, "is_active_account", false);

                                accountInfo.AccountingCategoryInfo.AccountingCategoryId = ProcStatic.DataReaderConvert(sqlReader,
                                    "accounting_category_id", String.Empty);
                                accountInfo.AccountingCategoryInfo.CategoryDescription = ProcStatic.DataReaderConvert(sqlReader,
                                    "category_description", String.Empty);

                                accountInfo.SummaryAccount.AccountSysId = ProcStatic.DataReaderConvert(sqlReader, "sysid_account_summary", String.Empty);
                                accountInfo.SummaryAccount.AccountCode = ProcStatic.DataReaderConvert(sqlReader, "account_code_summary", String.Empty);
                                accountInfo.SummaryAccount.AccountName = ProcStatic.DataReaderConvert(sqlReader, "account_name_summary", String.Empty);
                                accountInfo.SummaryAccount.AccountDescription = ProcStatic.DataReaderConvert(sqlReader, "account_description_summary", 
                                    String.Empty);
                                accountInfo.SummaryAccount.CompanyPolicyProcedure = ProcStatic.DataReaderConvert(sqlReader,
                                    "company_policy_procedure_summary", String.Empty);
                                accountInfo.SummaryAccount.IsDebitSideIncrease = ProcStatic.DataReaderConvert(sqlReader, "is_debit_side_increase_summary", false);
                                accountInfo.SummaryAccount.IsActiveAccount = ProcStatic.DataReaderConvert(sqlReader, "is_active_account_summary", false);

                                accountInfo.SummaryAccount.AccountingCategoryInfo.AccountingCategoryId = ProcStatic.DataReaderConvert(sqlReader,
                                    "accounting_category_id_summary", String.Empty);
                                accountInfo.SummaryAccount.AccountingCategoryInfo.CategoryDescription = ProcStatic.DataReaderConvert(sqlReader,
                                    "category_description_summary", String.Empty);

                                break;

                            }
                        }

                        sqlReader.Close();
                    }
                }
            }

            return accountInfo;
        } //------------------------------------

        
        /// <summary>
        /// This function determines if the category is valid by summary account
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="accountingCategoryId"></param>
        /// <param name="summaryAccount"></param>
        /// <returns></returns>
        public Boolean IsValidCategoryBySummaryAccountChartOfAccount(CommonExchange.SysAccess userInfo, String accountingCategoryId,
            String summaryAccount)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsValidCategoryBySummaryAccountChartOfAccount";

                    sqlComm.Parameters.Add("@accounting_category_id", SqlDbType.VarChar).Value = accountingCategoryId;
                    sqlComm.Parameters.Add("@summary_account", SqlDbType.VarChar).Value = summaryAccount;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;
        } //------------------------------

        /// <summary>
        /// This function determines if the account code already exists
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="accountSysId"></param>
        /// <param name="accountCode"></param>
        /// <returns></returns>
        public Boolean IsExistsAccountCodeChartOfAccount(CommonExchange.SysAccess userInfo, String accountSysId,
            String accountCode, String summaryAccount)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsExistsAccountCodeChartOfAccount";

                    sqlComm.Parameters.Add("@sysid_account", SqlDbType.VarChar).Value = accountSysId;
                    sqlComm.Parameters.Add("@account_code", SqlDbType.VarChar).Value = accountCode;
                    sqlComm.Parameters.Add("@summary_account", SqlDbType.VarChar).Value = summaryAccount;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;
        } //------------------------------

        /// <summary>
        /// This procedure get the cached data for accounting
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public DataSet GetDataSetForAccounting(CommonExchange.SysAccess userInfo)
        {
            DataSet dbSet = new DataSet();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                //get the accounting category table
                dbSet.Tables.Add(ProcStatic.GetAccountingCategoryTable(auth.Connection, userInfo.UserId));
                //--------------------------------
            }

            return dbSet;
        } //----------------------------------

        #endregion

    }
}
