using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteServerLib
{
    public class RemSrvStudentLoadingManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor

        public RemSrvStudentLoadingManager() { }

        void IDisposable.Dispose() { }

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts or delete a student load
        public void InsertUpdateDeleteStudentLoad(CommonExchange.SysAccess userInfo, DataTable studentLoadTable) { }

        #endregion

        #region Programmer-Defined Function Procedures

        //this procedure returns the subject schedule load by date start and end of the student by enrolment level
        public DataTable SelectBySysIDEnrolmentLevelDateStartEndSubjectScheduleStudentLoad(CommonExchange.SysAccess userInfo, String studentSysId,
            String enrolmentLevelSysId, String feeLevelSysId, String semesterSysId, Boolean isGraduateStudent, Boolean isInternational,
            Boolean isEnrolled, Boolean isForStudentTab, String dateStart, String dateEnd, String serverDateTime)
        {
            DataTable dbTable = new DataTable();

            return dbTable;

        } //------------------------------------------

        //this procedure returns the subject schedule details by date start and end of the student by enrolment level
        public DataTable SelectBySysIDEnrolmentLevelDateStartEndScheduleDetailsStudentLoad(CommonExchange.SysAccess userInfo, String enrolmentLevelSysId,
            String dateStart, String dateEnd)
        {
            DataTable dbTable = new DataTable();

            return dbTable;

        } //---------------------------------------------

        //this procedure returns the subject schedule load by enrolment level list
        public DataTable SelectBySysIDEnrolmentLevelListSubjectScheduleStudentLoad(CommonExchange.SysAccess userInfo, String enrolmentLevelSysIdList,
            String serverDateTime)
        {
            DataTable dbTable = new DataTable();

            return dbTable;

        } //------------------------------------------

        //this procedure returns the subject schedule details by enrolment level list
        public DataTable SelectBySysIDEnrolmentLevelListScheduleDetailsStudentLoad(CommonExchange.SysAccess userInfo, String enrolmentLevelSysIdList)
        {
            DataTable dbTable = new DataTable();

            return dbTable;

        } //---------------------------------------------

        //this procedure returns the school fee details by student system id, fee level system id
        public DataTable SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoad(CommonExchange.SysAccess userInfo, String studentSysId,
            String enrolmentLevelSysId, String feeLevelSysId, String semesterSysId, Boolean isGraduateStudent, Boolean isInternational,
            Boolean isEnrolled, Boolean isMarkedDeleted, Boolean isPreviousCharge)
        {
            DataTable dbTable = new DataTable();

            return dbTable;

        } //---------------------------------------------

        //this procedure returns the school fee details by student system id list and enrolment level system id list
        public DataTable SelectBySysIDStudentEnrolmentLevelListSchoolFeeDetailsStudentLoad(CommonExchange.SysAccess userInfo, String studentSysIdList,
            String enrolmentLevelSysIdList)
        {
            DataTable dbTable = new DataTable();

            return dbTable;

        } //---------------------------------------------

        //this function gets the student enrolled by schedule system id table query
        public DataTable SelectBySysIDScheduleListStudentLoad(CommonExchange.SysAccess userInfo, String scheduleSysIdList)
        {
            DataTable dbTable = new DataTable();

            return dbTable;

        } //------------------------------

        //this procedure returns the student balance carried forward by student system id list and date ending
        public DataTable SelectBySysIDStudentListDateEndingBalanceCarriedForwardStudentLoad(CommonExchange.SysAccess userInfo, String studentSysIdList,
            String excludeEnrolmentLevelSysIdList, String dateEnding)
        {
            DataTable dbTable = new DataTable();

            return dbTable;

        } //---------------------------------------------

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
            DataTable dbTable = new DataTable();

            return dbTable;

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
            DataTable dbTable = new DataTable();

            return dbTable;

        } //---------------------------------------------

        /// <summary>
        /// This function returns the student running balance
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="studentSysIdList"></param>
        /// <returns></returns>
        public DataTable SelectBySysIDStudentListForStudentRunningBalanceStudentLoad(CommonExchange.SysAccess userInfo, String studentSysIdList)
        {
            DataTable dbTable = new DataTable();

            return dbTable;

        } //---------------------------------------------

        //this function is used to get data tables stored in one dataset used for student loading manager
        public DataSet GetDataSetForStudentLoad(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            DataSet dbSet = new DataSet();

            return dbSet;
        } //----------------------------------

        #endregion
    }
}
