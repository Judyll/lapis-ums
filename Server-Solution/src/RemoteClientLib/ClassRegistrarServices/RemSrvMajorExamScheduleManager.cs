using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteServerLib
{
    public class RemSrvMajorExamScheduleManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvMajorExamScheduleManager() { }

        void IDisposable.Dispose() { }

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new major exam schedule
        public void InsertMajorExamSchedule(CommonExchange.SysAccess userInfo, CommonExchange.MajorExamSchedule examSchedule) { }

        //this procedure updates a major exam schedule
        public void UpdateMajorExamSchedule(CommonExchange.SysAccess userInfo, CommonExchange.MajorExamSchedule examSchedule) { }

        //this procedure deletes a major exam schedule
        public void DeleteMajorExamSchedule(CommonExchange.SysAccess userInfo, CommonExchange.MajorExamSchedule examSchedule) { }

        #endregion

        #region Programmer-Defined Function Procedures

        //this function gets the major exam table query
        public DataTable SelectMajorExamSchedule(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd,
            String courseGroupIdList, String examInformationIdList, String serverDateTime)
        {
            DataTable dbTable = new DataTable();

            return dbTable;

        } //------------------------------

        //this function is used to determine if the exam date information exists
        public Boolean IsExistsYearSemesterIDExamDateInformationIDExamSchedule(CommonExchange.SysAccess userInfo,
            CommonExchange.MajorExamSchedule examSchedule)
        {
            Boolean isExist = false;

            return isExist;
        } //-----------------------------  

        //this function is used to get data tables stored in one dataset used for major exam schedule manager
        public DataSet GetDataSetForMajorExamSchedule(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            DataSet dbSet = new DataSet();

            return dbSet;
        } //----------------------------------

        #endregion
    }
}
