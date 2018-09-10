using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RemoteClient
{
    public class RemCntStudentEnrolmentManager : IDisposable
    {
        #region Constructor and Destructor

        public RemCntStudentEnrolmentManager() { }

        void IDisposable.Dispose() { }

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new student enrolment level
        public void InsertStudentEnrolmentLevel(CommonExchange.SysAccess userInfo, ref CommonExchange.StudentEnrolmentLevel enrolmentLevelInfo) 
        {
            RemoteServerLib.RemSrvStudentEnrolmentManager remServer = 
                (RemoteServerLib.RemSrvStudentEnrolmentManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager),
                TcpRemoteServer.GetRemoteServerTcp() + "InsertStudentEnrolmentLevel");

            remServer.InsertStudentEnrolmentLevel(userInfo, ref enrolmentLevelInfo);
        } //--------------------------------------

        //this procedure updates a student enrolment level
        public void UpdateStudentEnrolmentLevel(CommonExchange.SysAccess userInfo, CommonExchange.StudentEnrolmentLevel enrolmentLevelInfo) 
        {
            RemoteServerLib.RemSrvStudentEnrolmentManager remServer = 
                (RemoteServerLib.RemSrvStudentEnrolmentManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager),
                TcpRemoteServer.GetRemoteServerTcp() + "UpdateStudentEnrolmentLevel");

            remServer.UpdateStudentEnrolmentLevel(userInfo, enrolmentLevelInfo);
        } //---------------------------------

        //this procedure deletes a student enrolment level
        public void DeleteStudentEnrolmentLevel(CommonExchange.SysAccess userInfo, CommonExchange.StudentEnrolmentLevel enrolmentLevelInfo) 
        {
            RemoteServerLib.RemSrvStudentEnrolmentManager remServer = 
                (RemoteServerLib.RemSrvStudentEnrolmentManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager),
                TcpRemoteServer.GetRemoteServerTcp() + "DeleteStudentEnrolmentLevel");

            remServer.DeleteStudentEnrolmentLevel(userInfo, enrolmentLevelInfo);
        } //-------------------------------------------

        //this procedure inserts a new student enrolment course
        public void InsertStudentEnrolmentCourse(CommonExchange.SysAccess userInfo, ref CommonExchange.StudentEnrolmentCourse enrolmentCourseInfo) 
        {
            RemoteServerLib.RemSrvStudentEnrolmentManager remServer = 
                (RemoteServerLib.RemSrvStudentEnrolmentManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager),
                TcpRemoteServer.GetRemoteServerTcp() + "InsertStudentEnrolmentCourse");

            remServer.InsertStudentEnrolmentCourse(userInfo, ref enrolmentCourseInfo);
        } //---------------------------------

        //this procedure updates student enrolment course
        public void UpdateStudentEnrolmentCourse(CommonExchange.SysAccess userInfo, CommonExchange.StudentEnrolmentCourse enrolmentCourseInfo) 
        {
            RemoteServerLib.RemSrvStudentEnrolmentManager remServer = 
                (RemoteServerLib.RemSrvStudentEnrolmentManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager),
                TcpRemoteServer.GetRemoteServerTcp() + "UpdateStudentEnrolmentCourse");

            remServer.UpdateStudentEnrolmentCourse(userInfo, enrolmentCourseInfo);
        } //--------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this procedure returns the student enrolment course
        public DataTable SelectBySysIDStudentDateStartEndStudentEnrolmentCourse(CommonExchange.SysAccess userInfo, String studentSysId,
            String dateStart, String dateEnd)
        {
            RemoteServerLib.RemSrvStudentEnrolmentManager remServer = 
                (RemoteServerLib.RemSrvStudentEnrolmentManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDStudentDateStartEndStudentEnrolmentCourse");

            return remServer.SelectBySysIDStudentDateStartEndStudentEnrolmentCourse(userInfo, studentSysId, dateStart, dateEnd);
        } //-------------------------------------------  

        //this procedure returns the student enrolment course
        public DataTable SelectBySysIDStudentStudentEnrolmentCourse(CommonExchange.SysAccess userInfo, String studentSysId)
        {
            RemoteServerLib.RemSrvStudentEnrolmentManager remServer = 
                (RemoteServerLib.RemSrvStudentEnrolmentManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDStudentStudentEnrolmentCourse");

            return remServer.SelectBySysIDStudentStudentEnrolmentCourse(userInfo, studentSysId);
        } //--------------------------------------

        //this procedure returns the student enrolment level
        public DataTable SelectBySysIDStudentYearIDSemesterStudentEnrolmentLevel(CommonExchange.SysAccess userInfo, String studentSysId,
            String yearId, String semesterSysId, String enrolmentCourseSysId, Boolean includeNotEnrolled, Boolean includeMarkedDeleted,
            String enrolmentLevelSysIdExcludeList)
        {
            RemoteServerLib.RemSrvStudentEnrolmentManager remServer = 
                (RemoteServerLib.RemSrvStudentEnrolmentManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDStudentYearIDSemesterStudentEnrolmentLevel");

            return remServer.SelectBySysIDStudentYearIDSemesterStudentEnrolmentLevel(userInfo, studentSysId, yearId, semesterSysId, enrolmentCourseSysId,
                includeNotEnrolled, includeMarkedDeleted, enrolmentLevelSysIdExcludeList);
        } //------------------------------------------

        //this procedure returns the student enrolment course
        public DataTable SelectBySysIDStudentStudentEnrolmentLevel(CommonExchange.SysAccess userInfo, String studentSysId)
        {
            RemoteServerLib.RemSrvStudentEnrolmentManager remServer = 
                (RemoteServerLib.RemSrvStudentEnrolmentManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDStudentStudentEnrolmentLevel");

            return remServer.SelectBySysIDStudentStudentEnrolmentLevel(userInfo, studentSysId);
        } //---------------------------------

        //this procedure returns the student enrolment course for enrolment history
        public DataTable SelectBySysIDStudentForEnrolmentHistoryEnrolmentCourse(CommonExchange.SysAccess userInfo, String studentSysId)
        {
            RemoteServerLib.RemSrvStudentEnrolmentManager remServer = 
                (RemoteServerLib.RemSrvStudentEnrolmentManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDStudentForEnrolmentHistoryEnrolmentCourse");

            return remServer.SelectBySysIDStudentForEnrolmentHistoryEnrolmentCourse(userInfo, studentSysId);
        } //------------------------------------

        //this procedure returns the student enrolment level for enrolment history
        public DataTable SelectBySysIDStudentForEnrolmentHistoryEnrolmentLevel(CommonExchange.SysAccess userInfo, String studentSysId)
        {
            RemoteServerLib.RemSrvStudentEnrolmentManager remServer = 
                (RemoteServerLib.RemSrvStudentEnrolmentManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectBySysIDStudentForEnrolmentHistoryEnrolmentLevel");

            return remServer.SelectBySysIDStudentForEnrolmentHistoryEnrolmentLevel(userInfo, studentSysId);
        } //------------------------------------

        //this procedure returns the student enrolment course major
        public DataTable SelectByCourseIDSysIDEnrolmentLevelEnrolmentCourseMajor(CommonExchange.SysAccess userInfo, String studentSysId,
            String courseId, String enrolmentLevelSysId)
        {
            RemoteServerLib.RemSrvStudentEnrolmentManager remServer = 
                (RemoteServerLib.RemSrvStudentEnrolmentManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager),
                TcpRemoteServer.GetRemoteServerTcp() + "SelectByCourseIDSysIDEnrolmentLevelEnrolmentCourseMajor");

            return remServer.SelectByCourseIDSysIDEnrolmentLevelEnrolmentCourseMajor(userInfo, studentSysId, courseId, enrolmentLevelSysId);
        } //----------------------------------------

        //this function is used to determine the student with a certain course already exists
        public Boolean IsExistsStudentCourseStudentEnrolmentCourse(CommonExchange.SysAccess userInfo, String studentSysId, String courseId)
        {
            RemoteServerLib.RemSrvStudentEnrolmentManager remServer = 
                (RemoteServerLib.RemSrvStudentEnrolmentManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager),
                TcpRemoteServer.GetRemoteServerTcp() + "IsExistsStudentCourseStudentEnrolmentCourse");

            return remServer.IsExistsStudentCourseStudentEnrolmentCourse(userInfo, studentSysId, courseId);
        } //-------------------------------------

        //this function is used to determine the paramaters passed are valid based on a given course
        public Boolean IsValidByCourseInformationSchoolFeeSysIDSemesterStudentEnrolmentCourse(CommonExchange.SysAccess userInfo,
            String enrolmentCourseSysId, String schoolFeeSysId, String semesterSysId)
        {
            RemoteServerLib.RemSrvStudentEnrolmentManager remServer = 
                (RemoteServerLib.RemSrvStudentEnrolmentManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager),
                TcpRemoteServer.GetRemoteServerTcp() + "IsValidByCourseInformationSchoolFeeSysIDSemesterStudentEnrolmentCourse");

            return remServer.IsValidByCourseInformationSchoolFeeSysIDSemesterStudentEnrolmentCourse(userInfo, enrolmentCourseSysId, schoolFeeSysId, semesterSysId);
        } //-------------------------------------

        //this function is used to determine if the year level no is lesser in the existing year level in a certain course
        public Boolean IsCourseYearLevelNoLesserStudentEnrolmentLevel(CommonExchange.SysAccess userInfo, String studentSysId,
            String courseId, String yearLevelId, String enrolmentLevelSysIdExcludeList)
        {
            RemoteServerLib.RemSrvStudentEnrolmentManager remServer = 
                (RemoteServerLib.RemSrvStudentEnrolmentManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager),
                TcpRemoteServer.GetRemoteServerTcp() + "IsCourseYearLevelNoLesserStudentEnrolmentLevel");

            return remServer.IsCourseYearLevelNoLesserStudentEnrolmentLevel(userInfo, studentSysId, courseId, yearLevelId, enrolmentLevelSysIdExcludeList);
        } //------------------------------------------------

        //this function is used to determine if the year level is valid for changes
        public Boolean IsValidForYearLevelChangeEnrolmentLevel(CommonExchange.SysAccess userInfo, String studentSysId, String enrolmentLevelSysId)
        {
            RemoteServerLib.RemSrvStudentEnrolmentManager remServer =
                (RemoteServerLib.RemSrvStudentEnrolmentManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager),
                TcpRemoteServer.GetRemoteServerTcp() + "IsValidForYearLevelChangeEnrolmentLevel");

            return remServer.IsValidForYearLevelChangeEnrolmentLevel(userInfo, studentSysId, enrolmentLevelSysId);
        } //----------------------------------

        //this function is used to determine if the year level and its course group has an entry level
        public Boolean IsLevelCourseGroupWithEntryLevelEnrolmentLevel(CommonExchange.SysAccess userInfo, String studentSysId, String feeLevelSysId)
        {
            RemoteServerLib.RemSrvStudentEnrolmentManager remServer = 
                (RemoteServerLib.RemSrvStudentEnrolmentManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager),
                TcpRemoteServer.GetRemoteServerTcp() + "IsLevelCourseGroupWithEntryLevelEnrolmentLevel");

            return remServer.IsLevelCourseGroupWithEntryLevelEnrolmentLevel(userInfo, studentSysId, feeLevelSysId);
        } //--------------------------------------------

        //this function is used to determine the year level per student per course per semester already exists
        public Boolean IsExistSysIDStudentCourseLevelSemesterEnrolmentLevel(CommonExchange.SysAccess userInfo, String studentSysId, String enrolmentCourseSysId,
            String feeLevelSysId, String semesterSysId)
        {
            RemoteServerLib.RemSrvStudentEnrolmentManager remServer = 
                (RemoteServerLib.RemSrvStudentEnrolmentManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager),
                TcpRemoteServer.GetRemoteServerTcp() + "IsExistSysIDStudentCourseLevelSemesterEnrolmentLevel");

            return remServer.IsExistSysIDStudentCourseLevelSemesterEnrolmentLevel(userInfo, studentSysId, enrolmentCourseSysId, feeLevelSysId, semesterSysId);
        } //---------------------------------------

        //this function is used to determine if the course information is valid 
        public Boolean IsNotValidForCourseSchoolFeeSysIDSemesterStudentEnrolmentLevel(CommonExchange.SysAccess userInfo,
            String enrolmentCourseSysId, String schoolFeeSysId, String semesterSysId)
        {
            RemoteServerLib.RemSrvStudentEnrolmentManager remServer = 
                (RemoteServerLib.RemSrvStudentEnrolmentManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager),
                TcpRemoteServer.GetRemoteServerTcp() + "IsNotValidForCourseSchoolFeeSysIDSemesterStudentEnrolmentLevel");

            return remServer.IsNotValidForCourseSchoolFeeSysIDSemesterStudentEnrolmentLevel(userInfo, enrolmentCourseSysId, schoolFeeSysId, semesterSysId);
        } //---------------------------------------

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
            RemoteServerLib.RemSrvStudentEnrolmentManager remServer =
                (RemoteServerLib.RemSrvStudentEnrolmentManager)Activator.GetObject(typeof(RemoteServerLib.RemSrvStudentEnrolmentManager),
                TcpRemoteServer.GetRemoteServerTcp() + "IsValidForShiftToCurrentCourseStudentEnrolmentLevel");

            return remServer.IsValidForShiftToCurrentCourseStudentEnrolmentLevel(userInfo, enrolmentLevelSysId, toShiftEnrolmentCourseSysId);
        } //----------------------------------

        #endregion
    }
}
