using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RemoteServerLib
{
    public class RemSrvCampusAccessManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor
        public RemSrvCampusAccessManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a campus access details
        public void InsertCampusAccessDetails(CommonExchange.SysAccess userInfo, DataTable campusAccessDetailsTable) { }

        #endregion

        #region Programmer-Defined Function Procedures

        //this function gets the student and employee table query
        public DataTable SelectForCampusAccessStudentEmployeeInformation(CommonExchange.SysAccess userInfo, String queryString)
        {
            DataTable dbTable = new DataTable(); 

            return dbTable;
        } //-------------------------------------

        //this function gets the campus access by sysid_person list
        public DataTable SelectByPersonSysIDListDateStartEndCampusAccessDetails(CommonExchange.SysAccess userInfo, String personSysIdList,
            String dateStart, String dateEnd)
        {
            DataTable dbTable = new DataTable();

            return dbTable;

        } //------------------------------

        //this function is used to get data tables stored in one dataset used for campus access
        public DataSet GetDataSetForCampusAccess(CommonExchange.SysAccess userInfo)
        {
            DataSet dbSet = new DataSet();

            return dbSet;
        } //----------------------------------

        #endregion
    }
}
