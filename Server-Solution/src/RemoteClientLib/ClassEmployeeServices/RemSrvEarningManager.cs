using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RemoteServerLib
{
    public class RemSrvEarningManager: MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvEarningManager() { }

        void IDisposable.Dispose() { }
        #endregion
        
        #region Programmer-Defined Void Procedures

        //this procedure deletes an employee earning
        public void DeleteEmployeeEarning(CommonExchange.SysAccess userInfo, CommonExchange.EarningInformation incInfo) { }

        //this procedure updates an employee earning
        public void UpdateEmployeeEarning(CommonExchange.SysAccess userInfo, CommonExchange.EarningInformation incInfo) { }

        //this procedure inserts an employee earning
        public void InsertEmployeeEarning(CommonExchange.SysAccess userInfo, DataTable incTable) { }

        //this procedure updates a earning information
        public void UpdateEarningInformation(CommonExchange.SysAccess userInfo, CommonExchange.EarningInformation incInfo) { }

        //this procedure adds a new earning information
        public void InsertEarningInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.EarningInformation incInfo) { }

        #endregion

        #region Programmer-Defined Function Procedures

        //this function is used to determine if the description exists
        public Boolean IsEarningDescriptionExist(CommonExchange.SysAccess userInfo, String description, String earningSysId)
        {
            Boolean isExist = false;

            return isExist;
        } //-----------------------------

        //this function is used to get data tables stored in one dataset used for earning information
        public DataSet GetDataSetForEarningInfo(CommonExchange.SysAccess userInfo)
        {
            DataSet dbSet = new DataSet();

            return dbSet;
        } //----------------------------------

        //this function gets the selected employee earning
        public DataTable GetByDateFromDateToEmployeeEarning(CommonExchange.SysAccess userInfo, String employeeSysId, String dateFrom,
                   String dateTo, String serverDateTime)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //--------------------------------------------

        #endregion
    }
}
