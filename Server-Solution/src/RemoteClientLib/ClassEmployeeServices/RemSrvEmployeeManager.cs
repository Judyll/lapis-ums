using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RemoteServerLib
{
    public class RemSrvEmployeeManager: MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvEmployeeManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure adds a new employee information
        public void InsertEmployeeInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.Employee empInfo) { }

        //this procedure updates an employee information
        public void UpdateEmployeeInformation(CommonExchange.SysAccess userInfo, CommonExchange.Employee empInfo) { }
        
        #endregion

        #region Programmer-Defined Function Procedures

        //this function returns the employee information details
        public CommonExchange.Employee SelectByEmployeeIDEmployeeInformation(CommonExchange.SysAccess userInfo, String employeeId)
        {
            CommonExchange.Employee employeeInfo = new CommonExchange.Employee();

            return employeeInfo;
        } //--------------------------------------- 

        //this function returns the employee information details
        public CommonExchange.Employee SelectBySysIDPersonEmployeeInformation(CommonExchange.SysAccess userInfo, String personSysId)
        {
            CommonExchange.Employee employeeInfo = new CommonExchange.Employee();

            return employeeInfo;
        } //---------------------------------------  

        //this function is used to determine if the employee id exists
        public Boolean IsExistsEmployeeIdEmployeeInformation(CommonExchange.SysAccess userInfo, String empId, String sysId)
        {
            Boolean isExist = false;

            return isExist;
        } //-----------------------------

        //this function is used to get data tables stored in one dataset used for employee information
        public DataSet GetDataSetForEmployeeInfo(CommonExchange.SysAccess userInfo)
        {
            DataSet dbSet = new DataSet();

            return dbSet;
        } //----------------------------------

        #endregion
    }
}
