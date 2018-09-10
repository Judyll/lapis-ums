using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteServerLib
{
    public class RemSrvStudentManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvStudentManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new student information
        public void InsertStudentInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.Student studentInfo) { }

        //this procedure updates a student information
        public void UpdateStudentInformation(CommonExchange.SysAccess userInfo, CommonExchange.Student studentInfo) { }
        
        #endregion

        #region Programmer-Defined Function Procedures

        //this function returns the student count for student id
        public Int32 GetCountForStudentIDStudentInformation(CommonExchange.SysAccess userInfo, String schoolFeeSysIdList, String yearLevelId)
        {
            Int32 count = 0;

            return count;

        } //-------------------------------

        //this function returns the student information details
        public CommonExchange.Student SelectByStudentIDStudentInformation(CommonExchange.SysAccess userInfo, String studentId)
        {
            CommonExchange.Student studentInfo = new CommonExchange.Student();

            return studentInfo;
        } //-------------------------------------

        //this function returns the student information details
        public CommonExchange.Student SelectBySysIDPersonStudentInformation(CommonExchange.SysAccess userInfo, String personSysId)
        {
            CommonExchange.Student studentInfo = new CommonExchange.Student();            

            return studentInfo;
        } //-------------------------------------

        //this function gets the student information table query
        public DataTable SelectStudentInformation(CommonExchange.SysAccess userInfo, String queryString, String dateStart, String dateEnd,
            String courseIdList, String yearLevelIdList)
        {
            DataTable dbTable = new DataTable();

            return dbTable;

        } //------------------------------

        //this function is used to determine if the student id exists
        public Boolean IsExistsStudentIdStudentInformation(CommonExchange.SysAccess userInfo, String studentId, String studentSysId)
        {
            Boolean isExist = false;

            return isExist;
        } //-----------------------------   

        //this function is used to get data tables stored in one dataset used for student manager
        public DataSet GetDataSetForStudentInformation(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            DataSet dbSet = new DataSet();

            return dbSet;
        } //----------------------------------

        #endregion
    }
}
