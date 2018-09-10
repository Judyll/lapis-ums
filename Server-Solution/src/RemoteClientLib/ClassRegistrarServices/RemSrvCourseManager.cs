using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteServerLib
{
    public class RemSrvCourseManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvCourseManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new subject information
        public void InsertSubjectInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.SubjectInformation subjectInfo,
                                                    DataTable requisiteTable) { }

        //this procedure updates a subject information
        public void UpdateSubjectInformation(CommonExchange.SysAccess userInfo, CommonExchange.SubjectInformation subjectInfo,
                                                    DataTable requisiteTable) { }

        //this procedure inserts a new classroom information
        public void InsertClassroomInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.ClassroomInformation roomInfo) { }

        //this procedure updates a classroom information
        public void UpdateClassroomInformation(CommonExchange.SysAccess userInfo, CommonExchange.ClassroomInformation roomInfo) { }

        //this procedure inserts and delete a pre-requisite subject
        private void InsertDeletePrerequisite(CommonExchange.SysAccess userInfo, SqlConnection sqlConn, DataTable requisiteTable,
                                                    String subjectSysId) { }

        #endregion

        #region Programmer-Defined Function Procedures

        //this function is used to get the subject prerequisite by subject id
        public DataTable SelectBySubjectIDSubjectPrerequisite(CommonExchange.SysAccess userInfo, String subjectSysId)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //------------------------------

        //this function is used to get the subject information by subject code or title
        public DataTable SelectSubjectInformation(CommonExchange.SysAccess userInfo, String queryString)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //------------------------------------------

        //this function is used to get the classroom information by classroom code or description
        public DataTable SelectClassroomInformation(CommonExchange.SysAccess userInfo, String queryString)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //------------------------------------------

        //this function is used to get the course information by course title or acronym
        public DataTable SelectCourseInformation(CommonExchange.SysAccess userInfo, String queryString)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //------------------------------------------

        //this function determines if the subject code and descriptive title exist
        public Boolean IsExistCodeDescriptionSubjectInformation(CommonExchange.SysAccess userInfo, CommonExchange.SubjectInformation subjectInfo)
        {
            Boolean isExist = false;

            return isExist;

        } //------------------------------

        //this function determines if the classroom code exist
        public Boolean IsExistCodeClassroomInformation(CommonExchange.SysAccess userInfo, String roomCode, String roomSysId)
        {
            Boolean isExist = false;

            return isExist;

        } //------------------------------

        //this function determines if the course title and acronym exist
        public Boolean IsExistTitleAcronymCourseInformation(CommonExchange.SysAccess userInfo, CommonExchange.CourseInformation courseInfo)
        {
            Boolean isExist = false;

            return isExist;

        } //------------------------------

        //this function is used to get data tables stored in one dataset used for classroom subject information
        public DataSet GetDataSetForClassroomSubject(CommonExchange.SysAccess userInfo)
        {
            DataSet dbSet = new DataSet();

            return dbSet;
        } //----------------------------------
        

        #endregion
    }
}
