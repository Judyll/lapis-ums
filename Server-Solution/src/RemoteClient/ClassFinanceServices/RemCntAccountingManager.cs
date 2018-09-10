using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RemoteClient
{
    public class RemCntAccountingManager : IDisposable
    {
        #region Constructor and Destructor
        public RemCntAccountingManager() { }

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
            RemoteServerLib.RemSrvAccountingManager remServer =
                (RemoteServerLib.RemSrvAccountingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvAccountingManager),
                TcpRemoteServer.GetRemoteServerTcp() + "InsertChartOfAccounts");

            remServer.InsertChartOfAccounts(userInfo, ref chartOfAccount);
        } //--------------------------------------------

        /// <summary>
        /// This procedure updates a chart of account
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="chartOfAccount"></param>
        public void UpdateChartOfAccounts(CommonExchange.SysAccess userInfo, CommonExchange.ChartOfAccount chartOfAccount) 
        {
            RemoteServerLib.RemSrvAccountingManager remServer =
                (RemoteServerLib.RemSrvAccountingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvAccountingManager),
                TcpRemoteServer.GetRemoteServerTcp() + "UpdateChartOfAccounts");

            remServer.UpdateChartOfAccounts(userInfo, chartOfAccount);
        } //------------------------------------------------

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
            RemoteServerLib.RemSrvAccountingManager remServer =
                (RemoteServerLib.RemSrvAccountingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvAccountingManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectChartOfAccounts");

            return remServer.SelectChartOfAccounts(userInfo, queryString, summaryAccount, accountingCategoryIdList, isActiveAccount);

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
            RemoteServerLib.RemSrvAccountingManager remServer =
                (RemoteServerLib.RemSrvAccountingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvAccountingManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDAccountChartOfAccounts");

            return remServer.SelectBySysIDAccountChartOfAccounts(userInfo, accountSysId);
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
            RemoteServerLib.RemSrvAccountingManager remServer =
                (RemoteServerLib.RemSrvAccountingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvAccountingManager),
                TcpRemoteServer.GetRemoteServerTcp() + "IsValidCategoryBySummaryAccountChartOfAccount");

            return remServer.IsValidCategoryBySummaryAccountChartOfAccount(userInfo, accountingCategoryId, summaryAccount);
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
            RemoteServerLib.RemSrvAccountingManager remServer =
                (RemoteServerLib.RemSrvAccountingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvAccountingManager),
                TcpRemoteServer.GetRemoteServerTcp() + "IsExistsAccountCodeChartOfAccount");

            return remServer.IsExistsAccountCodeChartOfAccount(userInfo, accountSysId, accountCode, summaryAccount);
        } //------------------------------

        /// <summary>
        /// This procedure get the cached data for accounting
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public DataSet GetDataSetForAccounting(CommonExchange.SysAccess userInfo)
        {
            RemoteServerLib.RemSrvAccountingManager remServer =
                (RemoteServerLib.RemSrvAccountingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvAccountingManager),
                TcpRemoteServer.GetRemoteServerTcp() + "GetDataSetForAccounting");

            return remServer.GetDataSetForAccounting(userInfo);
        } //----------------------------------

        #endregion
    }
}
