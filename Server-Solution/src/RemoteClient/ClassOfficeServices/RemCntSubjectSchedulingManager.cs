using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RemoteClient
{
    public class RemCntSubjectSchedulingManager : IDisposable
    {
        #region Class Constructor and Destructor

        public RemCntSubjectSchedulingManager() { }

        void IDisposable.Dispose() { }

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new schedule information
        public void InsertScheduleInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.ScheduleInformation scheduleInfo)
        {
            RemoteServerLib.RemSrvSubjectSchedulingManager remServer = (RemoteServerLib.RemSrvSubjectSchedulingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSubjectSchedulingManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "InsertScheduleInformation");

            remServer.InsertScheduleInformation(userInfo, ref scheduleInfo);
        } //----------------------------------

        //this procedure inserts a updates schedule information
        public void UpdateScheduleInformation(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformation scheduleInfo)
        {
            RemoteServerLib.RemSrvSubjectSchedulingManager remServer = (RemoteServerLib.RemSrvSubjectSchedulingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSubjectSchedulingManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "UpdateScheduleInformation");

            remServer.UpdateScheduleInformation(userInfo, scheduleInfo);
        } //-------------------------------------

        //this procedure inserts a deletes schedule information
        public void DeleteScheduleInformation(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformation scheduleInfo)
        {
            RemoteServerLib.RemSrvSubjectSchedulingManager remServer = (RemoteServerLib.RemSrvSubjectSchedulingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSubjectSchedulingManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "DeleteScheduleInformation");

            remServer.DeleteScheduleInformation(userInfo, scheduleInfo);
        } //-------------------------------------

        //this procedure inserts a new schedule information details
        public void InsertScheduleInformationDetails(CommonExchange.SysAccess userInfo, ref CommonExchange.ScheduleInformationDetails scheduleDetailsInfo,
            DataTable scheduleTable)
        {
            RemoteServerLib.RemSrvSubjectSchedulingManager remServer = (RemoteServerLib.RemSrvSubjectSchedulingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSubjectSchedulingManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "InsertScheduleInformationDetails");

            remServer.InsertScheduleInformationDetails(userInfo, ref scheduleDetailsInfo, scheduleTable);
        } //-------------------------------------------------

        //this procedure updates a schedule information details
        public void UpdateScheduleInformationDetails(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformationDetails scheduleDetailsInfo,
            DataTable scheduleTable)
        {
            RemoteServerLib.RemSrvSubjectSchedulingManager remServer = (RemoteServerLib.RemSrvSubjectSchedulingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSubjectSchedulingManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "UpdateScheduleInformationDetails");

            remServer.UpdateScheduleInformationDetails(userInfo, scheduleDetailsInfo, scheduleTable);
        } //----------------------------------------------

        //this procedure deletes a schedule information details
        public void DeleteScheduleInformationDetails(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformationDetails scheduleDetailsInfo)
        {
            RemoteServerLib.RemSrvSubjectSchedulingManager remServer = (RemoteServerLib.RemSrvSubjectSchedulingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSubjectSchedulingManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "DeleteScheduleInformationDetails");

            remServer.DeleteScheduleInformationDetails(userInfo, scheduleDetailsInfo);
        } //---------------------------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function is used to get the schedule information by date start and date end
        public DataTable SelectByDateStartEndScheduleInformation(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd, Boolean isMarkedDeleted)
        {
            RemoteServerLib.RemSrvSubjectSchedulingManager remServer = (RemoteServerLib.RemSrvSubjectSchedulingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSubjectSchedulingManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectByDateStartEndScheduleInformation");

            return remServer.SelectByDateStartEndScheduleInformation(userInfo, dateStart, dateEnd, isMarkedDeleted);
        } //----------------------------------------------

        //this function is used to get the schedule information details by date start and date end
        public DataTable SelectByDateStartEndScheduleInformationDetails(CommonExchange.SysAccess userInfo, String queryString,
            String dateStart, String dateEnd, Boolean isMarkedDeleted)
        {
            RemoteServerLib.RemSrvSubjectSchedulingManager remServer = (RemoteServerLib.RemSrvSubjectSchedulingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSubjectSchedulingManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectByDateStartEndScheduleInformationDetails");

            return remServer.SelectByDateStartEndScheduleInformationDetails(userInfo, queryString, dateStart, dateEnd, isMarkedDeleted);
        } //---------------------------------

        //this function is used to get the schedule information details by schedule details system id
        public DataTable SelectBySysIDScheduleScheduleInformationDetails(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformation scheduleInfo)
        {
            RemoteServerLib.RemSrvSubjectSchedulingManager remServer = (RemoteServerLib.RemSrvSubjectSchedulingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSubjectSchedulingManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDScheduleScheduleInformationDetails");

            return remServer.SelectBySysIDScheduleScheduleInformationDetails(userInfo, scheduleInfo);
        } //------------------------------

        //this function is used to get the subject schedule by classroom code
        public DataTable SelectByClassroomCodeSubjectSchedule(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd,
            String classroomSysId, String scheduleDetailsSysId)
        {
            RemoteServerLib.RemSrvSubjectSchedulingManager remServer = (RemoteServerLib.RemSrvSubjectSchedulingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSubjectSchedulingManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectByClassroomCodeSubjectSchedule");

            return remServer.SelectByClassroomCodeSubjectSchedule(userInfo, dateStart, dateEnd, classroomSysId, scheduleDetailsSysId);
        } //----------------------------   

        //this function is used to get the subject schedule by schedule details system id
        public DataTable SelectBySysIDScheduleDetailsListSubjectSchedule(CommonExchange.SysAccess userInfo, String scheduleDetailsSysIdList)
        {
            RemoteServerLib.RemSrvSubjectSchedulingManager remServer = (RemoteServerLib.RemSrvSubjectSchedulingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSubjectSchedulingManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDScheduleDetailsListSubjectSchedule");

            return remServer.SelectBySysIDScheduleDetailsListSubjectSchedule(userInfo, scheduleDetailsSysIdList);
        } //-----------------------------------------------

        //this function is used to get data tables stored in one dataset used for schedule information
        public DataSet GetDataSetForScheduleInformation(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            RemoteServerLib.RemSrvSubjectSchedulingManager remServer = (RemoteServerLib.RemSrvSubjectSchedulingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvSubjectSchedulingManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "GetDataSetForScheduleInformation");

            return remServer.GetDataSetForScheduleInformation(userInfo, serverDateTime);
        } //-----------------------------

        #endregion
    }
}
