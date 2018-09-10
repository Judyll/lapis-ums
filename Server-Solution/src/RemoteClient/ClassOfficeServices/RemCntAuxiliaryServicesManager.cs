using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RemoteClient
{
    public class RemCntAuxiliaryServicesManager : IDisposable
    {
        #region Constructor and Destructor

        public RemCntAuxiliaryServicesManager() { }

        void IDisposable.Dispose() { }

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new auxiliary service information
        public void InsertAuxiliaryServiceInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.AuxiliaryServiceInformation serviceInfo) 
        {
            RemoteServerLib.RemSrvAuxiliaryServicesManager remServer = (RemoteServerLib.RemSrvAuxiliaryServicesManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvAuxiliaryServicesManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "InsertAuxiliaryServiceInformation");

            remServer.InsertAuxiliaryServiceInformation(userInfo, ref serviceInfo);
        } //--------------------------------------------

        //this procedure updates an auxiliary service information
        public void UpdateAuxiliaryServiceInformation(CommonExchange.SysAccess userInfo, CommonExchange.AuxiliaryServiceInformation serviceInfo) 
        {
            RemoteServerLib.RemSrvAuxiliaryServicesManager remServer = (RemoteServerLib.RemSrvAuxiliaryServicesManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvAuxiliaryServicesManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "UpdateAuxiliaryServiceInformation");

            remServer.UpdateAuxiliaryServiceInformation(userInfo, serviceInfo);
        } //-----------------------------------       

        //this procedure inserts a new auxiliary service schedule
        public void InsertAuxiliaryServiceSchedule(CommonExchange.SysAccess userInfo, ref CommonExchange.AuxiliaryServiceSchedule serviceScheduleInfo) 
        {
            RemoteServerLib.RemSrvAuxiliaryServicesManager remServer = (RemoteServerLib.RemSrvAuxiliaryServicesManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvAuxiliaryServicesManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "InsertAuxiliaryServiceSchedule");

            remServer.InsertAuxiliaryServiceSchedule(userInfo, ref serviceScheduleInfo);
        } //----------------------------------------------

        //this procedure updates an auxiliary service schedule
        public void UpdateAuxiliaryServiceSchedule(CommonExchange.SysAccess userInfo, CommonExchange.AuxiliaryServiceSchedule serviceScheduleInfo) 
        {
            RemoteServerLib.RemSrvAuxiliaryServicesManager remServer = (RemoteServerLib.RemSrvAuxiliaryServicesManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvAuxiliaryServicesManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "UpdateAuxiliaryServiceSchedule");

            remServer.UpdateAuxiliaryServiceSchedule(userInfo, serviceScheduleInfo);
        } //-----------------------------------

        //this procedure deletes an auxiliary service schedule
        public void DeleteAuxiliaryServiceSchedule(CommonExchange.SysAccess userInfo, CommonExchange.AuxiliaryServiceSchedule serviceScheduleInfo) 
        {
            RemoteServerLib.RemSrvAuxiliaryServicesManager remServer = (RemoteServerLib.RemSrvAuxiliaryServicesManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvAuxiliaryServicesManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "DeleteAuxiliaryServiceSchedule");

            remServer.DeleteAuxiliaryServiceSchedule(userInfo, serviceScheduleInfo);
        } //------------------------------------------

        //this procedure inserts a new auxiliary service details
        public void InsertAuxiliaryServiceDetails(CommonExchange.SysAccess userInfo, ref CommonExchange.AuxiliaryServiceDetails serviceDetailsInfo) 
        {
            RemoteServerLib.RemSrvAuxiliaryServicesManager remServer = (RemoteServerLib.RemSrvAuxiliaryServicesManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvAuxiliaryServicesManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "InsertAuxiliaryServiceDetails");

            remServer.InsertAuxiliaryServiceDetails(userInfo, ref serviceDetailsInfo);
        } //----------------------------------------------

        //this procedure updates an auxiliary service details
        public void UpdateAuxiliaryServiceDetails(CommonExchange.SysAccess userInfo, CommonExchange.AuxiliaryServiceDetails serviceDetailsInfo) 
        {
            RemoteServerLib.RemSrvAuxiliaryServicesManager remServer = (RemoteServerLib.RemSrvAuxiliaryServicesManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvAuxiliaryServicesManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "UpdateAuxiliaryServiceDetails");

            remServer.UpdateAuxiliaryServiceDetails(userInfo, serviceDetailsInfo);
        } //-----------------------------------------

        //this procedure deletes an auxiliary service details
        public void DeleteAuxiliaryServiceDetails(CommonExchange.SysAccess userInfo, CommonExchange.AuxiliaryServiceDetails serviceDetailsInfo) 
        {
            RemoteServerLib.RemSrvAuxiliaryServicesManager remServer = (RemoteServerLib.RemSrvAuxiliaryServicesManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvAuxiliaryServicesManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "DeleteAuxiliaryServiceDetails");

            remServer.DeleteAuxiliaryServiceDetails(userInfo, serviceDetailsInfo);
        } //----------------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function is used to get the service information by service code or title
        public DataTable SelectByServiceCodeTitleAuxiliaryServiceInformation(CommonExchange.SysAccess userInfo, String queryString)
        {
            RemoteServerLib.RemSrvAuxiliaryServicesManager remServer = (RemoteServerLib.RemSrvAuxiliaryServicesManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvAuxiliaryServicesManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectByServiceCodeTitleAuxiliaryServiceInformation");

            return remServer.SelectByServiceCodeTitleAuxiliaryServiceInformation(userInfo, queryString);
        } //------------------------------------------

        //this function is used to get the auxiliary service details by date start and date end
        public DataTable SelectByDateStartEndAuxiliaryServiceDetails(CommonExchange.SysAccess userInfo, String queryString,
            String dateStart, String dateEnd, Boolean isMarkedDeleted)
        {
            RemoteServerLib.RemSrvAuxiliaryServicesManager remServer = (RemoteServerLib.RemSrvAuxiliaryServicesManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvAuxiliaryServicesManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectByDateStartEndAuxiliaryServiceDetails");

            return remServer.SelectByDateStartEndAuxiliaryServiceDetails(userInfo, queryString, dateStart, dateEnd, isMarkedDeleted);
        } //-------------------------------------------------

        //this function determines if the auxiliary service code and descriptive title exist
        public Boolean IsExistCodeDescriptionAuxiliaryServiceInformation(CommonExchange.SysAccess userInfo,
            CommonExchange.AuxiliaryServiceInformation serviceInfo)
        {
            RemoteServerLib.RemSrvAuxiliaryServicesManager remServer = (RemoteServerLib.RemSrvAuxiliaryServicesManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvAuxiliaryServicesManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "IsExistCodeDescriptionAuxiliaryServiceInformation");

            return remServer.IsExistCodeDescriptionAuxiliaryServiceInformation(userInfo, serviceInfo);

        } //------------------------------

        //this function is used to get data tables stored in one dataset used for auxiliary service
        public DataSet GetDataSetForAuxiliaryService(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            RemoteServerLib.RemSrvAuxiliaryServicesManager remServer = (RemoteServerLib.RemSrvAuxiliaryServicesManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvAuxiliaryServicesManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "GetDataSetForAuxiliaryService");

            return remServer.GetDataSetForAuxiliaryService(userInfo, serverDateTime);
        } //---------------------------------

        #endregion
    }
}
