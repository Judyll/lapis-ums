using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RemoteClient
{
    public class RemCntDeductionManager: IDisposable
    {
        #region Class Contructor and Desctructor

        public RemCntDeductionManager() { }

        void IDisposable.Dispose() { }

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure deletes an employee deduction
        public void DeleteEmployeeDeduction(CommonExchange.SysAccess userInfo, CommonExchange.DeductionInformation decInfo)
        {
            RemoteServerLib.RemSrvDeductionManager remServer = (RemoteServerLib.RemSrvDeductionManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvDeductionManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "DeleteEmployeeDeduction");

            remServer.DeleteEmployeeDeduction(userInfo, decInfo);
        } //--------------------------------

        //this procedure updates an employee deduction
        public void UpdateEmployeeDeduction(CommonExchange.SysAccess userInfo, CommonExchange.DeductionInformation decInfo)
        {
            RemoteServerLib.RemSrvDeductionManager remServer = (RemoteServerLib.RemSrvDeductionManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvDeductionManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "UpdateEmployeeDeduction");

            remServer.UpdateEmployeeDeduction(userInfo, decInfo);
        } //------------------------------------

        //this procedure inserts an employee deduction
        public void InsertEmployeeDeduction(CommonExchange.SysAccess userInfo, DataTable decTable)
        {
            RemoteServerLib.RemSrvDeductionManager remServer = (RemoteServerLib.RemSrvDeductionManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvDeductionManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "InsertEmployeeDeduction");

            remServer.InsertEmployeeDeduction(userInfo, decTable);
        } //-----------------------------------

        //this procedure updates a deduction information
        public void UpdateDeductionInformation(CommonExchange.SysAccess userInfo, CommonExchange.DeductionInformation decInfo)
        {
            RemoteServerLib.RemSrvDeductionManager remServer = (RemoteServerLib.RemSrvDeductionManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvDeductionManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "UpdateDeductionInformation");

            remServer.UpdateDeductionInformation(userInfo, decInfo);
        } //------------------------------------

        //this procedure adds a new deduction information
        public void InsertDeductionInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.DeductionInformation decInfo)
        { 
            RemoteServerLib.RemSrvDeductionManager remServer = (RemoteServerLib.RemSrvDeductionManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvDeductionManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "InsertDeductionInformation");

            remServer.InsertDeductionInformation(userInfo, ref decInfo);
        } //------------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function is used to determine if the description exists
        public Boolean IsDeductionDescriptionExist(CommonExchange.SysAccess userInfo, String description, String deductionSysId)
        {
            RemoteServerLib.RemSrvDeductionManager remServer = (RemoteServerLib.RemSrvDeductionManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvDeductionManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "IsDeductionDescriptionExist");

            return remServer.IsDeductionDescriptionExist(userInfo, description, deductionSysId);
        } //--------------------------------

        //this function is used to get data tables stored in one dataset used for deduction information
        public DataSet GetDataSetForDeductionInfo(CommonExchange.SysAccess userInfo)
        {
            RemoteServerLib.RemSrvDeductionManager remServer = (RemoteServerLib.RemSrvDeductionManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvDeductionManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "GetDataSetForDeductionInfo");

            return remServer.GetDataSetForDeductionInfo(userInfo);
        } //----------------------------------

        //this function gets the selected employee deduction
        public DataTable GetByDateFromDateToEmployeeDeduction(CommonExchange.SysAccess userInfo, String employeeSysId, String dateFrom,
                   String dateTo, String serverDateTime)
        {
            RemoteServerLib.RemSrvDeductionManager remServer = (RemoteServerLib.RemSrvDeductionManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvDeductionManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "GetByDateFromDateToEmployeeDeduction");

            return remServer.GetByDateFromDateToEmployeeDeduction(userInfo, employeeSysId, dateFrom, dateTo, serverDateTime);
        } //------------------------------

        #endregion
    }
}
