using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RemoteServerLib
{
    public class RemSrvSpecialClassManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvSpecialClassManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new special class information
        public void InsertSpecialClassInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.SpecialClassInformation specialInfo,
                                                        DataTable studentTable) { }

        //this procedure updates a special class information
        public void UpdateSpecialClassInformation(CommonExchange.SysAccess userInfo, CommonExchange.SpecialClassInformation specialInfo,
                                                            DataTable studentTable) { }

        //this procedure deletes a special class information
        public void DeleteSpecialClassInformation(CommonExchange.SysAccess userInfo, String specialSysId) { }

        //this procedure deletes a special class load
        public void DeleteSpecialClassLoad(CommonExchange.SysAccess userInfo, Int64 loadId) { }

        #endregion

        #region Programmer-Defined Function Procedures

        //this function is used to get the special class information by date start and date end
        public DataTable SelectByDateStartEndSpecialClassInformation(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd,
                                                                            Boolean isMarkedDeleted) 
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        }

        //this function is used to get the student loaded in the special class by special class id
        public DataTable SelectBySysIDSpecialSpecialClassLoad(CommonExchange.SysAccess userInfo, String specialSysId, String serverDateTime)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //------------------------------

        //this function is used to get the student loaded in the special class by date start end
        public DataTable SelectBySysIDStudentListDateStartEndSpecialClassInformation(CommonExchange.SysAccess userInfo, String studentSysIdList,
            String dateStart, String dateEnd, String serverDateTime)
        {
            DataTable dbTable = new DataTable();            

            return dbTable;
        } //------------------------------

        //this function is used to get the special class information by date start and date end
        public DataTable SelectBySysIDEmployeeListDateStartEndSpecialClassInformation(CommonExchange.SysAccess userInfo, String employeeSysIdList,
            String dateStart, String dateEnd)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //---------------------------------

        //this function determines if the special class information already exists
        public Boolean IsExistsInformationSpecialClassInformation(CommonExchange.SysAccess userInfo, 
                                                                    CommonExchange.SpecialClassInformation specialInfo)
        {
            Boolean isExist = false;

            return isExist;

        } //------------------------------


        //this function is used to get data tables stored in one dataset used for special class information
        public DataSet GetDataSetForSpecialClassInformation(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            DataSet dbSet = new DataSet();

            return dbSet;
        } //----------------------------------

        #endregion
    }
}
