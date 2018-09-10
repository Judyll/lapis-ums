using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RemoteClient
{
    public class RemCntStudentLoadingManager : IDisposable
    {
        #region Class Constructor and Destructor

        public RemCntStudentLoadingManager() { }

        void IDisposable.Dispose() { }

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts or delete a student load
        public void InsertUpdateDeleteStudentLoad(CommonExchange.SysAccess userInfo, DataTable studentLoadTable) 
        {
            RemoteServerLib.RemSrvStudentLoadingManager remServer = 
                (RemoteServerLib.RemSrvStudentLoadingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentLoadingManager),
                TcpRemoteServer.GetRemoteServerTcp() + "InsertUpdateDeleteStudentLoad");

            remServer.InsertUpdateDeleteStudentLoad(userInfo, studentLoadTable);
        } //------------------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this procedure returns the subject schedule load by date start and end of the student by enrolment level
        public DataTable SelectBySysIDEnrolmentLevelDateStartEndSubjectScheduleStudentLoad(CommonExchange.SysAccess userInfo, String studentSysId,
            String enrolmentLevelSysId, String feeLevelSysId, String semesterSysId, Boolean isGraduateStudent, Boolean isInternational,
            Boolean isEnrolled, Boolean isForStudentTab, String dateStart, String dateEnd, String serverDateTime)
        {
            RemoteServerLib.RemSrvStudentLoadingManager remServer = 
                (RemoteServerLib.RemSrvStudentLoadingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentLoadingManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDEnrolmentLevelDateStartEndSubjectScheduleStudentLoad");

            return remServer.SelectBySysIDEnrolmentLevelDateStartEndSubjectScheduleStudentLoad(userInfo, studentSysId, enrolmentLevelSysId, 
                feeLevelSysId, semesterSysId, isGraduateStudent, isInternational, isEnrolled, isForStudentTab, dateStart, dateEnd, serverDateTime);

        } //------------------------------------------

        //this procedure returns the subject schedule details by date start and end of the student by enrolment level
        public DataTable SelectBySysIDEnrolmentLevelDateStartEndScheduleDetailsStudentLoad(CommonExchange.SysAccess userInfo, String enrolmentLevelSysId,
            String dateStart, String dateEnd)
        {
            RemoteServerLib.RemSrvStudentLoadingManager remServer = 
                (RemoteServerLib.RemSrvStudentLoadingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentLoadingManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDEnrolmentLevelDateStartEndScheduleDetailsStudentLoad");

            return remServer.SelectBySysIDEnrolmentLevelDateStartEndScheduleDetailsStudentLoad(userInfo, enrolmentLevelSysId, dateStart, dateEnd);

        } //---------------------------------------------

        //this procedure returns the subject schedule load by enrolment level list
        public DataTable SelectBySysIDEnrolmentLevelListSubjectScheduleStudentLoad(CommonExchange.SysAccess userInfo, String enrolmentLevelSysIdList,
            String serverDateTime)
        {
            RemoteServerLib.RemSrvStudentLoadingManager remServer = 
                (RemoteServerLib.RemSrvStudentLoadingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentLoadingManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDEnrolmentLevelListSubjectScheduleStudentLoad");

            return remServer.SelectBySysIDEnrolmentLevelListSubjectScheduleStudentLoad(userInfo, enrolmentLevelSysIdList, serverDateTime);
        } //-----------------------------------------------

        //this procedure returns the subject schedule details by enrolment level list
        public DataTable SelectBySysIDEnrolmentLevelListScheduleDetailsStudentLoad(CommonExchange.SysAccess userInfo, String enrolmentLevelSysIdList)
        {
            RemoteServerLib.RemSrvStudentLoadingManager remServer = 
                (RemoteServerLib.RemSrvStudentLoadingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentLoadingManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDEnrolmentLevelListScheduleDetailsStudentLoad");

            return remServer.SelectBySysIDEnrolmentLevelListScheduleDetailsStudentLoad(userInfo, enrolmentLevelSysIdList);
        } //--------------------------------------------

        //this procedure returns the school fee details by student system id, fee level system id
        public DataTable SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoad(CommonExchange.SysAccess userInfo, String studentSysId,
            String enrolmentLevelSysId, String feeLevelSysId, String semesterSysId, Boolean isGraduateStudent, Boolean isInternational,
            Boolean isEnrolled, Boolean isMarkedDeleted, Boolean isPreviousCharge)
        {
            RemoteServerLib.RemSrvStudentLoadingManager remServer = 
                (RemoteServerLib.RemSrvStudentLoadingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentLoadingManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoad");

            return remServer.SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoad(userInfo, studentSysId, 
                enrolmentLevelSysId, feeLevelSysId, semesterSysId, isGraduateStudent, isInternational, 
                isEnrolled, isMarkedDeleted, isPreviousCharge);
        } //--------------------------------------

        //this procedure returns the school fee details by student system id list and enrolment level system id list
        public DataTable SelectBySysIDStudentEnrolmentLevelListSchoolFeeDetailsStudentLoad(CommonExchange.SysAccess userInfo, String studentSysIdList,
            String enrolmentLevelSysIdList)
        {
            RemoteServerLib.RemSrvStudentLoadingManager remServer = 
                (RemoteServerLib.RemSrvStudentLoadingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentLoadingManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDStudentEnrolmentLevelListSchoolFeeDetailsStudentLoad");

            return remServer.SelectBySysIDStudentEnrolmentLevelListSchoolFeeDetailsStudentLoad(userInfo, studentSysIdList, enrolmentLevelSysIdList);
        } //-----------------------------------------

        //this function gets the student enrolled by schedule system id table query
        public DataTable SelectBySysIDScheduleListStudentLoad(CommonExchange.SysAccess userInfo, String scheduleSysIdList)
        {
            RemoteServerLib.RemSrvStudentLoadingManager remServer = 
                (RemoteServerLib.RemSrvStudentLoadingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentLoadingManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDScheduleListStudentLoad");

            return remServer.SelectBySysIDScheduleListStudentLoad(userInfo, scheduleSysIdList);
        } //-----------------------------------------

        //this procedure returns the student balance carried forward by student system id list and date ending
        public DataTable SelectBySysIDStudentListDateEndingBalanceCarriedForwardStudentLoad(CommonExchange.SysAccess userInfo, String studentSysIdList,
            String excludeEnrolmentLevelSysIdList, String dateEnding)
        {
            RemoteServerLib.RemSrvStudentLoadingManager remServer = 
                (RemoteServerLib.RemSrvStudentLoadingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentLoadingManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDStudentListDateEndingBalanceCarriedForwardStudentLoad");

            return remServer.SelectBySysIDStudentListDateEndingBalanceCarriedForwardStudentLoad(userInfo, studentSysIdList,
                excludeEnrolmentLevelSysIdList, dateEnding);
        } //----------------------------------------------

        /// <summary>
        /// This function return the table of the student accounts receivable per fiscal year
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="studentSysIdList"></param>
        /// <param name="dateEnding"></param>
        /// <returns></returns>
        public DataTable SelectBySysIDStudentListDateEndingAccountReceivablePerFiscalYearStudentLoad(CommonExchange.SysAccess userInfo, String studentSysIdList,
            String dateEnding)
        {
            RemoteServerLib.RemSrvStudentLoadingManager remServer =
                (RemoteServerLib.RemSrvStudentLoadingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentLoadingManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDStudentListDateEndingAccountReceivablePerFiscalYearStudentLoad");

            return remServer.SelectBySysIDStudentListDateEndingAccountReceivablePerFiscalYearStudentLoad(userInfo, studentSysIdList,
                dateEnding);

        } //---------------------------------------------

        /// <summary>
        /// This function returns the accounts receivable per term
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="studentSysIdList"></param>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        /// <param name="cutOffDate"></param>
        /// <returns></returns>
        public DataTable SelectBySysIDStudentListDateStartEndCutOffDateAccountReceivablePerTermStudentLoad(CommonExchange.SysAccess userInfo,
            String studentSysIdList, String dateStart, String dateEnd, String cutOffDate)
        {
            RemoteServerLib.RemSrvStudentLoadingManager remServer =
                (RemoteServerLib.RemSrvStudentLoadingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentLoadingManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDStudentListDateStartEndCutOffDateAccountReceivablePerTermStudentLoad");

            return remServer.SelectBySysIDStudentListDateStartEndCutOffDateAccountReceivablePerTermStudentLoad(userInfo,
                studentSysIdList, dateStart, dateEnd, cutOffDate);

        } //---------------------------------------------

        /// <summary>
        /// This function returns the student running balance
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="studentSysIdList"></param>
        /// <returns></returns>
        public DataTable SelectBySysIDStudentListForStudentRunningBalanceStudentLoad(CommonExchange.SysAccess userInfo, String studentSysIdList)
        {
            RemoteServerLib.RemSrvStudentLoadingManager remServer =
                (RemoteServerLib.RemSrvStudentLoadingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentLoadingManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDStudentListForStudentRunningBalanceStudentLoad");

            return remServer.SelectBySysIDStudentListForStudentRunningBalanceStudentLoad(userInfo, studentSysIdList);

        } //---------------------------------------------

        //this function is used to get data tables stored in one dataset used for student loading manager
        public DataSet GetDataSetForStudentLoad(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            RemoteServerLib.RemSrvStudentLoadingManager remServer = 
                (RemoteServerLib.RemSrvStudentLoadingManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentLoadingManager),
                TcpRemoteServer.GetRemoteServerTcp() + "GetDataSetForStudentLoad");

            return remServer.GetDataSetForStudentLoad(userInfo, serverDateTime);
        } //----------------------------------

        #endregion
    }
}
