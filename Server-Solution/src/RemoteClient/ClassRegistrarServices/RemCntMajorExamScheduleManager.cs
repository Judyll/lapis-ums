using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RemoteClient
{
    public class RemCntMajorExamScheduleManager : IDisposable
    {
        #region Constructor and Destructor
        public RemCntMajorExamScheduleManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new major exam schedule
        public void InsertMajorExamSchedule(CommonExchange.SysAccess userInfo, CommonExchange.MajorExamSchedule examSchedule)
        {
            RemoteServerLib.RemSrvMajorExamScheduleManager remServer = (RemoteServerLib.RemSrvMajorExamScheduleManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvMajorExamScheduleManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "InsertMajorExamSchedule");

            remServer.InsertMajorExamSchedule(userInfo, examSchedule);
        } //---------------------------------------

        //this procedure updates a major exam schedule
        public void UpdateMajorExamSchedule(CommonExchange.SysAccess userInfo, CommonExchange.MajorExamSchedule examSchedule)
        {
            RemoteServerLib.RemSrvMajorExamScheduleManager remServer = (RemoteServerLib.RemSrvMajorExamScheduleManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvMajorExamScheduleManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "UpdateMajorExamSchedule");

            remServer.UpdateMajorExamSchedule(userInfo, examSchedule);
        } //---------------------------------

        //this procedure deletes a major exam schedule
        public void DeleteMajorExamSchedule(CommonExchange.SysAccess userInfo, CommonExchange.MajorExamSchedule examSchedule)
        {
            RemoteServerLib.RemSrvMajorExamScheduleManager remServer = (RemoteServerLib.RemSrvMajorExamScheduleManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvMajorExamScheduleManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "DeleteMajorExamSchedule");

            remServer.DeleteMajorExamSchedule(userInfo, examSchedule);
        } //--------------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function gets the major exam table query
        public DataTable SelectMajorExamSchedule(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd,
            String courseGroupIdList, String examInformationIdList, String serverDateTime)
        {
            RemoteServerLib.RemSrvMajorExamScheduleManager remServer = (RemoteServerLib.RemSrvMajorExamScheduleManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvMajorExamScheduleManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "SelectMajorExamSchedule");

            return remServer.SelectMajorExamSchedule(userInfo, dateStart, dateEnd, courseGroupIdList, examInformationIdList, serverDateTime);
        } //----------------------------------

        //this function is used to determine if the exam date information exists
        public Boolean IsExistsYearSemesterIDExamDateInformationIDExamSchedule(CommonExchange.SysAccess userInfo,
            CommonExchange.MajorExamSchedule examSchedule)
        {
            RemoteServerLib.RemSrvMajorExamScheduleManager remServer = (RemoteServerLib.RemSrvMajorExamScheduleManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvMajorExamScheduleManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "IsExistsYearSemesterIDExamDateInformationIDExamSchedule");

            return remServer.IsExistsYearSemesterIDExamDateInformationIDExamSchedule(userInfo, examSchedule);
        } //--------------------------------------

        //this function is used to get data tables stored in one dataset used for major exam schedule manager
        public DataSet GetDataSetForMajorExamSchedule(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            RemoteServerLib.RemSrvMajorExamScheduleManager remServer = (RemoteServerLib.RemSrvMajorExamScheduleManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvMajorExamScheduleManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "GetDataSetForMajorExamSchedule");

            return remServer.GetDataSetForMajorExamSchedule(userInfo, serverDateTime);
        } //----------------------------------

        #endregion
    }
}
