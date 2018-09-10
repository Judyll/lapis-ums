using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteServerLib
{
    public class RemSrvScholarshipManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvScholarshipManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new scholarship information
        public void InsertScholarshipInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.ScholarshipInformation scholarshipInfo) { }

        //this procedure updates a scholarship information
        public void UpdateScholarshipInformation(CommonExchange.SysAccess userInfo, CommonExchange.ScholarshipInformation scholarshipInfo) { }

        //this procedure inserts a new student scholarship
        public void InsertStudentScholarship(CommonExchange.SysAccess userInfo, ref CommonExchange.StudentScholarship studentScholarship) { }

        //this procedure update a student scholarship
        public void UpdateStudentScholarship(CommonExchange.SysAccess userInfo, CommonExchange.StudentScholarship studentScholarship) { }

        //this procedure delete a student scholarship
        public void DeleteStudentScholarship(CommonExchange.SysAccess userInfo, CommonExchange.StudentScholarship studentScholarship) { }

        #endregion

        #region Programmer-Defined Function Procedures

        //this function gets the student scholarship table
        public DataTable SelectStudentScholarship(CommonExchange.SysAccess userInfo, String queryString, String dateStart, String dateEnd,
            String scholarshipSysIdList, String departmentIdList, String yearLevelIdList)
        {
            DataTable dbTable = new DataTable();           

            return dbTable;

        } //------------------------------

        //this procedure returns the discounts of the student with scholarships
        public DataTable SelectBySysIDEnrolmentLevelStudentScholarship(CommonExchange.SysAccess userInfo, String enrolmentLevelSysId, String serverDateTime)
        {
            DataTable dbTable = new DataTable();

            return dbTable;

        } //------------------------------------------    

        //this function is used to determine if the scholarship description already exists
        public Boolean IsExistsScholarshipDescriptionScholarshipInformation(CommonExchange.SysAccess userInfo,
            CommonExchange.ScholarshipInformation scholarshipInfo)
        {
            Boolean isExist = false;

            return isExist;
        } //------------------------------

        //this function is used to determine if the student scholarship already exists
        public Boolean IsExistsSysIDStudentScholarshipEnrolmentLevelStudentScholarship(CommonExchange.SysAccess userInfo,
            CommonExchange.StudentScholarship studentScholarship)
        {
            Boolean isExist = false;

            return isExist;
        } //------------------------------

        //this function is used to get data tables stored in one dataset used for scholarship manager
        public DataSet GetDataSetForScholarship(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            DataSet dbSet = new DataSet();            

            return dbSet;
        } //----------------------------------

        #endregion

    }
}
