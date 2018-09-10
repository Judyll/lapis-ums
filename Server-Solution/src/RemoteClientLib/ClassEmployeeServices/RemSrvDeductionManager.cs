using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RemoteServerLib
{
    public class RemSrvDeductionManager: MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvDeductionManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure deletes an employee deduction
        public void DeleteEmployeeDeduction(CommonExchange.SysAccess userInfo, CommonExchange.DeductionInformation decInfo) { }

        //this procedure updates an employee deduction
        public void UpdateEmployeeDeduction(CommonExchange.SysAccess userInfo, CommonExchange.DeductionInformation decInfo) { }

        //this procedure inserts an employee deduction
        public void InsertEmployeeDeduction(CommonExchange.SysAccess userInfo, DataTable decTable) { }

        //this procedure updates a deduction information
        public void UpdateDeductionInformation(CommonExchange.SysAccess userInfo, CommonExchange.DeductionInformation decInfo) { }

        //this procedure adds a new deduction information
        public void InsertDeductionInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.DeductionInformation decInfo) { }

        #endregion

        #region Programmer-Defined Function Procedures

        //this function is used to determine if the description exists
        public Boolean IsDeductionDescriptionExist(CommonExchange.SysAccess userInfo, String description, String deductionSysId)
        {
            Boolean isExist = false;

            return isExist;
        } //-----------------------------

        //this function is used to get data tables stored in one dataset used for deduction information
        public DataSet GetDataSetForDeductionInfo(CommonExchange.SysAccess userInfo)
        {
            DataSet dbSet = new DataSet();

            return dbSet;
        } //----------------------------------

        //this function gets the selected employee deduction
        public DataTable GetByDateFromDateToEmployeeDeduction(CommonExchange.SysAccess userInfo, String employeeSysId, String dateFrom,
                   String dateTo, String serverDateTime)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //--------------------------------------------

        
        #endregion
    }
}
