using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RemoteServerLib
{
    public class RemSrvSchoolYearSemesterManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor
        public RemSrvSchoolYearSemesterManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure insterst a school semester information
        public void InsertSemesterInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.SemesterInformation semInfo) { }

        //this procedure inserts a school year
        public void InsertSchoolYear(CommonExchange.SysAccess userInfo, ref CommonExchange.SchoolYear yearInfo) { }

        //this procedure inserts a school year (Summer)
        public void InsertSchoolYearSummer(CommonExchange.SysAccess userInfo, CommonExchange.SchoolYear baseYearInfo, ref CommonExchange.SchoolYear yearInfo) { }

        #endregion

        #region Programmer-Defined Function Procedures

        //this function returns the selected school year information
        public DataTable SelectByYearDescriptionSchoolYearTable(CommonExchange.SysAccess userInfo, String queryString, String serverDateTime)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //-----------------------------

        //this function returns the selected semester information
        public DataTable SelectYearSemesterDescriptionSemesterInformationTable(CommonExchange.SysAccess userInfo, String queryString,
            String serverDateTime)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //------------------------------

        //this function returns the last opened semeter information
        public String GetMaxDateEndSemesterInformation(CommonExchange.SysAccess userInfo)
        {
            DateTime maxDate = DateTime.MinValue;

            return maxDate.ToString("o");

        } //----------------------------

        //this function returns the max end date
        public String GetMaxDateEndSchoolYear(CommonExchange.SysAccess userInfo)
        {
            DateTime maxDate = DateTime.MinValue;

            return maxDate.ToString("o");
        } //-------------------------

        //this function is used to get data tables stored in one dataset used for school year semester information
        public DataSet GetDataSetForSchoolYearSemeter(CommonExchange.SysAccess userInfo)
        {
            DataSet dbSet = new DataSet();

            return dbSet;
        } //----------------------------------

        #endregion

    }
}
