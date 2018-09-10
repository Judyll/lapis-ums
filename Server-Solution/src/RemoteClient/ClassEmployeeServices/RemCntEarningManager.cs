using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RemoteClient
{
    public class RemCntEarningManager: IDisposable
    {
        #region Class Constructor and Destructor

        public RemCntEarningManager() { }

        void IDisposable.Dispose() { }

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure deletes an employee earning
        public void DeleteEmployeeEarning(CommonExchange.SysAccess userInfo, CommonExchange.EarningInformation incInfo)
        {
            RemoteServerLib.RemSrvEarningManager remServer = (RemoteServerLib.RemSrvEarningManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvEarningManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "DeleteEmployeeEarning");

            remServer.DeleteEmployeeEarning(userInfo, incInfo);
        } //--------------------------------

        //this procedure updates an employee earning
        public void UpdateEmployeeEarning(CommonExchange.SysAccess userInfo, CommonExchange.EarningInformation incInfo)
        {
            RemoteServerLib.RemSrvEarningManager remServer = (RemoteServerLib.RemSrvEarningManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvEarningManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "UpdateEmployeeEarning");

            remServer.UpdateEmployeeEarning(userInfo, incInfo);
        } //------------------------------------

        //this procedure inserts an employee earning
        public void InsertEmployeeEarning(CommonExchange.SysAccess userInfo, DataTable incTable)
        {
            RemoteServerLib.RemSrvEarningManager remServer = (RemoteServerLib.RemSrvEarningManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvEarningManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "InsertEmployeeEarning");

            remServer.InsertEmployeeEarning(userInfo, incTable);
        } //-----------------------------------

        //this procedure updates a earning information
        public void UpdateEarningInformation(CommonExchange.SysAccess userInfo, CommonExchange.EarningInformation incInfo)
        {
            RemoteServerLib.RemSrvEarningManager remServer = (RemoteServerLib.RemSrvEarningManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvEarningManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "UpdateEarningInformation");

            remServer.UpdateEarningInformation(userInfo, incInfo);
        } //------------------------------------

        //this procedure adds a new earning information
        public void InsertEarningInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.EarningInformation incInfo)
        {
            RemoteServerLib.RemSrvEarningManager remServer = (RemoteServerLib.RemSrvEarningManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvEarningManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "InsertEarningInformation");

            remServer.InsertEarningInformation(userInfo, ref incInfo);
        } //------------------------------------
        #endregion

        #region Programmer-Defined Function Procedures

        //this function is used to determine if the description exists
        public Boolean IsEarningDescriptionExist(CommonExchange.SysAccess userInfo, String description, String earningSysId)
        {
            RemoteServerLib.RemSrvEarningManager remServer = (RemoteServerLib.RemSrvEarningManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvEarningManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "IsEarningDescriptionExist");

            return remServer.IsEarningDescriptionExist(userInfo, description, earningSysId);
        } //--------------------------------

        //this function is used to get data tables stored in one dataset used for earning information
        public DataSet GetDataSetForEarningInfo(CommonExchange.SysAccess userInfo)
        {
            RemoteServerLib.RemSrvEarningManager remServer = (RemoteServerLib.RemSrvEarningManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvEarningManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "GetDataSetForEarningInfo");

            return remServer.GetDataSetForEarningInfo(userInfo);
        } //----------------------------------

        //this function gets the selected employee earning
        public DataTable GetByDateFromDateToEmployeeEarning(CommonExchange.SysAccess userInfo, String employeeSysId, String dateFrom,
                   String dateTo, String serverDateTime)
        {
            RemoteServerLib.RemSrvEarningManager remServer = (RemoteServerLib.RemSrvEarningManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvEarningManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "GetByDateFromDateToEmployeeEarning");

            return remServer.GetByDateFromDateToEmployeeEarning(userInfo, employeeSysId, dateFrom, dateTo, serverDateTime);
        } //------------------------------
        #endregion
    }
}
