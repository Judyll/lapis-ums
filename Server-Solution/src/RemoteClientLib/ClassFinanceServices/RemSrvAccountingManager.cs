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
        public void InsertChartOfAccounts(CommonExchange.SysAccess userInfo, ref CommonExchange.ChartOfAccount chartOfAccount) { }

        /// <summary>
        /// This procedure updates a chart of account
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="chartOfAccount"></param>
        public void UpdateChartOfAccounts(CommonExchange.SysAccess userInfo, CommonExchange.ChartOfAccount chartOfAccount) { }

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
            DataTable dbTable = new DataTable();

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

            return dbSet;
        } //----------------------------------

        #endregion

    }
}
