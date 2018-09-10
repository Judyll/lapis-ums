using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteServerLib
{
    public class RemSrvStudentEnrolmentManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvStudentEnrolmentManager() { }

        void IDisposable.Dispose() { }

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new student enrolment level
        public void InsertStudentEnrolmentLevel(CommonExchange.SysAccess userInfo, ref CommonExchange.StudentEnrolmentLevel enrolmentLevelInfo) { }

        //this procedure updates a student enrolment level
        public void UpdateStudentEnrolmentLevel(CommonExchange.SysAccess userInfo, CommonExchange.StudentEnrolmentLevel enrolmentLevelInfo) { }

        //this procedure deletes a student enrolment level
        public void DeleteStudentEnrolmentLevel(CommonExchange.SysAccess userInfo, CommonExchange.StudentEnrolmentLevel enrolmentLevelInfo) { }

        //this procedure inserts a new student enrolment course
        public void InsertStudentEnrolmentCourse(CommonExchange.SysAccess userInfo, ref CommonExchange.StudentEnrolmentCourse enrolmentCourseInfo) { }

        //this procedure updates student enrolment course
        public void UpdateStudentEnrolmentCourse(CommonExchange.SysAccess userInfo, CommonExchange.StudentEnrolmentCourse enrolmentCourseInfo) { }

        #endregion

        #region Programmer-Defined Function Procedures

        //this procedure returns the student enrolment course
        public DataTable SelectBySysIDStudentDateStartEndStudentEnrolmentCourse(CommonExchange.SysAccess userInfo, String studentSysId, 
            String dateStart, String dateEnd)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //-------------------------------------------  

        //this procedure returns the student enrolment course
        public DataTable SelectBySysIDStudentStudentEnrolmentCourse(CommonExchange.SysAccess userInfo, String studentSysId)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //-------------------------------------------  

        //this procedure returns the student enrolment level
        public DataTable SelectBySysIDStudentYearIDSemesterStudentEnrolmentLevel(CommonExchange.SysAccess userInfo, String studentSysId,
            String yearId, String semesterSysId, String enrolmentCourseSysId, Boolean includeNotEnrolled, Boolean includeMarkedDeleted,
            String enrolmentLevelSysIdExcludeList)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //-------------------------------------------  

        //this procedure returns the student enrolment course
        public DataTable SelectBySysIDStudentStudentEnrolmentLevel(CommonExchange.SysAccess userInfo, String studentSysId)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //-------------------------------------------  

        //this procedure returns the student enrolment course for enrolment history
        public DataTable SelectBySysIDStudentForEnrolmentHistoryEnrolmentCourse(CommonExchange.SysAccess userInfo, String studentSysId)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //-------------------------------------------  

        //this procedure returns the student enrolment level for enrolment history
        public DataTable SelectBySysIDStudentForEnrolmentHistoryEnrolmentLevel(CommonExchange.SysAccess userInfo, String studentSysId)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //-------------------------------------------  

        //this procedure returns the student enrolment course major
        public DataTable SelectByCourseIDSysIDEnrolmentLevelEnrolmentCourseMajor(CommonExchange.SysAccess userInfo, String studentSysId,
            String courseId, String enrolmentLevelSysId)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //-------------------------------------------  

        //this function is used to determine the student with a certain course already exists
        public Boolean IsExistsStudentCourseStudentEnrolmentCourse(CommonExchange.SysAccess userInfo, String studentSysId, String courseId)
        {
            Boolean isExist = false;

            return isExist;
        } //----------------------------------

        //this function is used to determine the paramaters passed are valid based on a given course
        public Boolean IsValidByCourseInformationSchoolFeeSysIDSemesterStudentEnrolmentCourse(CommonExchange.SysAccess userInfo,
            String enrolmentCourseSysId, String schoolFeeSysId, String semesterSysId)
        {
            Boolean isExist = false;

            return isExist;
        } //----------------------------------

        //this function is used to determine if the year level no is lesser in the existing year level in a certain course
        public Boolean IsCourseYearLevelNoLesserStudentEnrolmentLevel(CommonExchange.SysAccess userInfo, String studentSysId,
            String courseId, String yearLevelId, String enrolmentLevelSysIdExcludeList)
        {
            Boolean isExist = false;

            return isExist;
        } //----------------------------------

        //this function is used to determine if the year level is valid for changes
        public Boolean IsValidForYearLevelChangeEnrolmentLevel(CommonExchange.SysAccess userInfo, String studentSysId, String enrolmentLevelSysId)
        {
            Boolean isExist = false;

            return isExist;
        } //----------------------------------

        //this function is used to determine if the year level and its course group has an entry level
        public Boolean IsLevelCourseGroupWithEntryLevelEnrolmentLevel(CommonExchange.SysAccess userInfo, String studentSysId, String feeLevelSysId)
        {
            Boolean isExist = false;

            return isExist;
        } //----------------------------------

        //this function is used to determine the year level per student per course per semester already exists
        public Boolean IsExistSysIDStudentCourseLevelSemesterEnrolmentLevel(CommonExchange.SysAccess userInfo, String studentSysId, String enrolmentCourseSysId,
            String feeLevelSysId, String semesterSysId)
        {
            Boolean isExist = false;

            return isExist;
        } //----------------------------------

        //this function is used to determine if the course information is valid 
        public Boolean IsNotValidForCourseSchoolFeeSysIDSemesterStudentEnrolmentLevel(CommonExchange.SysAccess userInfo,
            String enrolmentCourseSysId, String schoolFeeSysId, String semesterSysId)
        {
            Boolean isExist = false;

            return isExist;
        } //----------------------------------

        /// <summary>
        /// This function determines if the shift to another course if valid
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="enrolmentLevelSysId"></param>
        /// <param name="toShiftEnrolmentCourseSysId"></param>
        /// <returns></returns>
        public Boolean IsValidForShiftToCurrentCourseStudentEnrolmentLevel(CommonExchange.SysAccess userInfo, String enrolmentLevelSysId,
            String toShiftEnrolmentCourseSysId)
        {
            Boolean isExist = false;

            return isExist;
        } //----------------------------------

        #endregion
    }
}
