using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RemoteClient
{
    public class RemCntTeacherLoadingManager : IDisposable
    {
        #region Constructor and Destructor

        public RemCntTeacherLoadingManager() { }

        void IDisposable.Dispose() { }

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new teacher load
        public void InsertDeleteTeacherLoad(CommonExchange.SysAccess userInfo, DataTable teacherLoadTable)
        {
            RemoteServerLib.RemSrvTeacherLoadingManager remServer = (RemoteServerLib.RemSrvTeacherLoadingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvTeacherLoadingManager),
                                                        TcpRemoteServer.GetRemoteServerTcp() + "InsertDeleteTeacherLoad");

            remServer.InsertDeleteTeacherLoad(userInfo, teacherLoadTable);
        } //-----------------------------------------
        
        #endregion

        #region Programmer-Defined Function Procedures

        //this function is used to get the subject details system id that has conflict
        public DataTable SelectByScheduleDetailsListConflictsWithAnotherScheduleTeacherLoad(CommonExchange.SysAccess userInfo, String scheduleDetailsSysIdList,
            String employeeSysId)
        {
            RemoteServerLib.RemSrvTeacherLoadingManager remServer =
                (RemoteServerLib.RemSrvTeacherLoadingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvTeacherLoadingManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectByScheduleDetailsListConflictsWithAnotherScheduleTeacherLoad");

            return remServer.SelectByScheduleDetailsListConflictsWithAnotherScheduleTeacherLoad(userInfo, scheduleDetailsSysIdList, employeeSysId);
        } //--------------------------------

        //this procedure returns the selected teacher load by date start and end for teacher loading
        public DataTable SelectByDateStartEndForTeacherLoadingTeacherLoad(CommonExchange.SysAccess userInfo, String dateStart,
            String dateEnd, String serverDateTime)
        {
            RemoteServerLib.RemSrvTeacherLoadingManager remServer = 
                (RemoteServerLib.RemSrvTeacherLoadingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvTeacherLoadingManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectByDateStartEndForTeacherLoadingTeacherLoad");

            return remServer.SelectByDateStartEndForTeacherLoadingTeacherLoad(userInfo, dateStart, dateEnd, serverDateTime);
        } //----------------------------------

        //this function is used to get data tables stored in one dataset used for schedule information
        public DataSet GetDataSetForTeacherLoad(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            RemoteServerLib.RemSrvTeacherLoadingManager remServer = 
                (RemoteServerLib.RemSrvTeacherLoadingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvTeacherLoadingManager),
                TcpRemoteServer.GetRemoteServerTcp() + "GetDataSetForTeacherLoad");

            return remServer.GetDataSetForTeacherLoad(userInfo, serverDateTime);
        } //---------------------------------
        #endregion
    }
}
