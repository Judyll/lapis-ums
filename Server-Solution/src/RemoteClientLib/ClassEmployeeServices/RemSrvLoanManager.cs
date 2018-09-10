using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteServerLib
{
    public class RemSrvLoanManager: MarshalByRefObject, IDisposable
    {
        #region Class Constructor
        public RemSrvLoanManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure updates / delete an employee remittance
        public void UpdateDeleteEmployeeRemittance(CommonExchange.SysAccess userInfo, DataTable remTable) { }

        //this procedure inserts a new employee remittance
        public void InsertEmployeeRemittance(CommonExchange.SysAccess userInfo, CommonExchange.EmployeeLoanRemittance remInfo) { }

        //this procedure deletes a loan remittance information
        public void DeleteLoanRemittance(CommonExchange.SysAccess userInfo, String loanSysId) { }

        //this procedure updates a loan remittance information
        public void UpdateLoanRemittance(CommonExchange.SysAccess userInfo, CommonExchange.LoanInformation loanInfo) { }

        //this procedure inserts a loan remittance information
        public void InsertLoanRemittance(CommonExchange.SysAccess userInfo, ref CommonExchange.LoanInformation loanInfo) { }

        //this procedure updates a loan type information
        public void UpdateLoanTypeInformation(CommonExchange.SysAccess userInfo, CommonExchange.LoanInformation loanInfo) { }


        //this procedure inserts a new loan type information
        public void InsertLoanTypeInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.LoanInformation loanInfo) { }

        #endregion

        #region Programmer-Defined Function Procedures

        //this function is used to determine if the description exists
        public Boolean IsLoanTypeDescriptionExist(CommonExchange.SysAccess userInfo, String description, String loanSysId)
        {
            Boolean isExist = false;

            return isExist;
        } //-----------------------------

        //this function is used to get data tables stored in one dataset used for loan type information
        public DataSet GetDataSetForLoanTypeInfo(CommonExchange.SysAccess userInfo)
        {
            DataSet dbSet = new DataSet();

            return dbSet;
        } //----------------------------------

        //this function is sued to get the employee remittance by employee id
        public DataTable SelectByEmployeeIDEmployeeRemittance(CommonExchange.SysAccess userInfo, String empSysId)
        {
            DataTable dbTable = new DataTable();

            return dbTable;

        } //-----------------------------

        //this function is used to get the loan remittance by employee id
        public DataTable SelectByEmployeeIDLoanRemittance(CommonExchange.SysAccess userInfo, String empSysId)
        {
            DataTable dbTable = new DataTable();

            return dbTable;
        } //------------------------------------


        #endregion
    }
}
