using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteServerLib
{
    public class RemSrvSchoolFeeManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvSchoolFeeManager() { }

        void IDisposable.Dispose() { }
        #endregion    

        #region Programmer-Defined Void Procedures

        //this procedure inserts a student additional fee
        public void InsertStudentAdditionalFee(CommonExchange.SysAccess userInfo, CommonExchange.StudentAdditionalFee additionalFee) { }

        //this procedure inserts a student additional fee
        public void InsertStudentAdditionalFeeTable(CommonExchange.SysAccess userInfo, DataTable additionalFeeTable) { }

        //this procedure updates a student additional fee
        public void UpdateStudentAdditionalFee(CommonExchange.SysAccess userInfo, CommonExchange.StudentAdditionalFee additionalFee) { }

        //this procedure deletes a student additional fee
        public void DeleteStudentAdditionalFee(CommonExchange.SysAccess userInfo, CommonExchange.StudentAdditionalFee additionalFee) { }

        //this procedure inserts and delete a student optional fee
        public void InsertDeleteStudentOptionalFee(CommonExchange.SysAccess userInfo, DataTable optionalFeeTable) { }

        //this procedure inserts a new school fee details
        public void InsertSchoolFeeDetails(CommonExchange.SysAccess userInfo, ref CommonExchange.SchoolFeeDetails detailsInfo) { }

        //this procedure update a school fee details
        public void UpdateSchoolFeeDetails(CommonExchange.SysAccess userInfo, CommonExchange.SchoolFeeDetails detailsInfo) { }

        //this procedure delete a school fee details
        public void DeleteSchoolFeeDetails(CommonExchange.SysAccess userInfo, CommonExchange.SchoolFeeDetails detailsInfo) { }

        //this procedure inserts a new school fee particular
        public void InsertSchoolFeeParticular(CommonExchange.SysAccess userInfo, ref CommonExchange.SchoolFeeParticular particularInfo) { }

        //this procedure updates a school fee particular
        public void UpdateSchoolFeeParticular(CommonExchange.SysAccess userInfo, CommonExchange.SchoolFeeParticular particularInfo) { }

        //this procedure deletes a school fee particular
        public void DeleteSchoolFeeParticular(CommonExchange.SysAccess userInfo, CommonExchange.SchoolFeeParticular particularInfo) { }

        //this procedure inserts a new school fee level
        public void InsertSchoolFeeLevel(CommonExchange.SysAccess userInfo, ref CommonExchange.SchoolFeeLevel levelInfo) { }

        //this procedure inserts a new school fee information
        public void InsertSchoolFeeInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.SchoolFeeInformation feeInfo) { }

        #endregion

        #region Programmer-Defined Function Procedures

        //this function gets the additional fee table query
        public DataTable SelectStudentAdditionalFee(CommonExchange.SysAccess userInfo, String queryString, String dateStart, String dateEnd,
            String courseIdList, String yearLevelIdList)
        {
            DataTable dbTable = new DataTable();

            return dbTable;

        } //------------------------------

        //this function gets the additional fee table query by sysid_student date start end
        public DataTable SelectBySysIDStudentDateStartEndStudentAdditionalFee(CommonExchange.SysAccess userInfo, String studentSysId,
            String dateStart, String dateEnd)
        {
            DataTable dbTable = new DataTable();

            return dbTable;

        } //------------------------------

        //this procedure returns the selected school fee details by date start and end 
        public DataTable SelectByDateStartEndSchoolFeeDetails(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //-------------------------------------------  

        //this procedure returns the selected school fee level by date start and end 
        public DataTable SelectBySysIDSchoolFeeSchoolFeeLevel(CommonExchange.SysAccess userInfo, String schoolFeeSysId)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //----------------------------------

        //this procedure returns the optional school fee details by student system id, fee level system id
        public DataTable SelectBySysIDStudentFeeLevelSemesterForOptionalFeeDetailsStudentOptionalFee(CommonExchange.SysAccess userInfo, String studentSysId,
            String feeLevelSysId, String semesterSysId, Boolean isInternational)
        {
            DataTable dbTable = new DataTable();

            return dbTable;

        } //---------------------------------------------

        //this function is used to determine if the school fee information and the year level id already exists
        public Boolean IsExistsSchoolFeeYearLevel(CommonExchange.SysAccess userInfo, CommonExchange.SchoolFeeLevel levelInfo)
        {
            Boolean isExist = false;

            return isExist;
        } //------------------------------

        //this function is used to determine if the year id for the school fee information already exists
        public Boolean IsExistsYearIDSchoolFeeInformation(CommonExchange.SysAccess userInfo, CommonExchange.SchoolFeeInformation feeInfo)
        {
            Boolean isExist = false;

            return isExist;
        } //------------------------------        

        //this function is used to determine if the particular description exists
        public Boolean IsExistsParticularDescriptionSchoolFeeParticular(CommonExchange.SysAccess userInfo, String particularSysId, String particularDescription)
        {
            Boolean isExist = false;

            return isExist;
        } //-----------------------------  

        //this function is sued to determine if the year level and particular already exists
        public Boolean IsExistsLevelParticularSchoolFeeDetails(CommonExchange.SysAccess userInfo, String feeLevelSysId, String particularSysId)
        {
            Boolean isExist = false;

            return isExist;
        } //------------------------------

        //this function is used to get data tables stored in one dataset used for school fee
        public DataSet GetDataSetForSchoolFee(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            DataSet dbSet = new DataSet();

            return dbSet;
        } //----------------------------------

        #endregion
    }
}
