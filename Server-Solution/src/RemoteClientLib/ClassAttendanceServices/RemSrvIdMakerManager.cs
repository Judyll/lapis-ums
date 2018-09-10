using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RemoteServerLib
{
    public class RemSrvIdMakerManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvIdMakerManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure updates an employee information for ID Maker
        public void UpdateForIdMakerEmployeeInformation(CommonExchange.SysAccess userInfo, CommonExchange.Employee employeeInfo) { }

        //this procedure updates a student information for ID Maker
        public void UpdateForIdMakerStudentInformation(CommonExchange.SysAccess userInfo, CommonExchange.Student studentInfo) { }

        #endregion

        #region Programmer-Defined Function Procedures

        //this function gets the student and employee table query
        public DataTable SelectByQueryStringStudentEmployeeInformation(CommonExchange.SysAccess userInfo, String queryString,
            Boolean includeEmergencyContact)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //-------------------------------------

        //this function is used to determine if the student card number exists
        public Boolean IsExistsCardNumberStudentInformation(CommonExchange.SysAccess userInfo, String cardNumber, String studentSysId)
        {
            Boolean isExist = false;

            return isExist;
        } //-----------------------------

        //this function is used to determine if the card number exists
        public Boolean IsExistsCardNumberEmployeeInformation(CommonExchange.SysAccess userInfo, String cardNumber, String employeeSysId)
        {
            Boolean isExist = false;

            return isExist;
        } //-----------------------------
        #endregion
    }
}
