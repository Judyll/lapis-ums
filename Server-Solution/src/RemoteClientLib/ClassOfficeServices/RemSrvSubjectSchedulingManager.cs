using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteServerLib
{
    public class RemSrvSubjectSchedulingManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor
        public RemSrvSubjectSchedulingManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new schedule information
        public void InsertScheduleInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.ScheduleInformation scheduleInfo) { }

        //this procedure inserts a updates schedule information
        public void UpdateScheduleInformation(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformation scheduleInfo) { }

        //this procedure inserts a deletes schedule information
        public void DeleteScheduleInformation(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformation scheduleInfo) { }

        //this procedure inserts a new schedule information details
        public void InsertScheduleInformationDetails(CommonExchange.SysAccess userInfo, ref CommonExchange.ScheduleInformationDetails scheduleDetailsInfo,
            DataTable scheduleTable) { }

        //this procedure updates a schedule information details
        public void UpdateScheduleInformationDetails(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformationDetails scheduleDetailsInfo,
            DataTable scheduleTable) { }

        //this procedure deletes a schedule information details
        public void DeleteScheduleInformationDetails(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformationDetails scheduleDetailsInfo) { }

        //this procedure inserts and delete a subject schedule
        private void InsertDeleteSubjectSchedule(CommonExchange.SysAccess userInfo, SqlConnection sqlConn, DataTable scheduleTable,
                                                    String scheduleDetailsSysId) { }

        #endregion

        #region Programmer-Defined Function Procedures

        //this function is used to get the schedule information by date start and date end
        public DataTable SelectByDateStartEndScheduleInformation(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd, Boolean isMarkedDeleted)
        {
            DataTable dbTable = new DataTable();

            return dbTable;

        } //-----------------------------------

        //this function is used to get the schedule information details by date start and date end
        public DataTable SelectByDateStartEndScheduleInformationDetails(CommonExchange.SysAccess userInfo, String queryString,
            String dateStart, String dateEnd, Boolean isMarkedDeleted)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //-------------------------------------------------

        //this function is used to get the schedule information details by schedule details system id
        public DataTable SelectBySysIDScheduleScheduleInformationDetails(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformation scheduleInfo)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //--------------------------------------------------        

        //this function is used to get the subject schedule by classroom code
        public DataTable SelectByClassroomCodeSubjectSchedule(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd,
            String classroomSysId, String scheduleDetailsSysId)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //--------------------------------

        //this function is used to get the subject schedule by schedule details system id
        public DataTable SelectBySysIDScheduleDetailsListSubjectSchedule(CommonExchange.SysAccess userInfo, String scheduleDetailsSysIdList)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //--------------------------------


        //this function is used to get data tables stored in one dataset used for schedule information
        public DataSet GetDataSetForScheduleInformation(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            DataSet dbSet = new DataSet();

            return dbSet;
        } //----------------------------------
        #endregion
    }
}
