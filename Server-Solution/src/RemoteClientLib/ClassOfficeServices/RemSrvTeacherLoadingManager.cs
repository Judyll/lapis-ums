using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteServerLib
{
    public class RemSrvTeacherLoadingManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvTeacherLoadingManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new teacher load
        public void InsertDeleteTeacherLoad(CommonExchange.SysAccess userInfo, DataTable teacherLoadTable) { }
        
        #endregion

        #region Programmer-Defined Function Procedures

        //this function is used to get the subject details system id that has conflict
        public DataTable SelectByScheduleDetailsListConflictsWithAnotherScheduleTeacherLoad(CommonExchange.SysAccess userInfo, String scheduleDetailsSysIdList,
            String employeeSysId)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //--------------------------------
   
        //this procedure returns the selected teacher load by date start and end for teacher loading
        public DataTable SelectByDateStartEndForTeacherLoadingTeacherLoad(CommonExchange.SysAccess userInfo, String dateStart, 
            String dateEnd, String serverDateTime)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //------------------------------

        //this function is used to get data tables stored in one dataset used for schedule information
        public DataSet GetDataSetForTeacherLoad(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            DataSet dbSet = new DataSet();

            return dbSet;
        } //---------------------------------

        #endregion

    }
}
