using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteServerLib
{
    public class RemSrvBaseManager: MarshalByRefObject
    {
        #region Class Constructor and Destructor
        public RemSrvBaseManager() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts or updates a person infomation
        public void InsertUpdatePersonInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.Person personInfo) { }

        //this procedure inserts or updates a person information
        public void InsertUpdatePersonInformationNoAuthenticate(CommonExchange.SysAccess userInfo, SqlConnection sqlConn, ref CommonExchange.Person personInfo) { }

        //this procedure inserts a new payroll standard
        public void InsertPayrollStandard(CommonExchange.SysAccess userInfo, ref CommonExchange.PayrollStandard stdPayroll) { }        

        //this procedure inserts a new registrar standard
        public void InsertRegistrarStandard(CommonExchange.SysAccess userInfo, ref CommonExchange.RegistrarStandard stdRegistrar) { }

        //this procedure inserts a new finance standard
        public void InsertFinanceStandard(CommonExchange.SysAccess userInfo, ref CommonExchange.FinanceStandard stdFinance) { }

        #endregion

        #region Programmer-Defined Function Procedures

        //this function determines if the person is an employee or a student
        public Boolean IsExistsSysIDPersonStudentEmployeeInformation(CommonExchange.SysAccess userInfo, String personSysId, ref Boolean isEmployee)
        {
            Boolean isExist = false;

            return isExist;

        } //------------------------------

        //this function gets the person information table query
        public DataTable SelectPersonInformation(CommonExchange.SysAccess userInfo, String queryString,
            String lastName, String firstName, String personSysIdExcludeList)
        {
            DataTable dbTable = new DataTable();

            return dbTable;

        } //------------------------------

        //this function returns the person information details
        public CommonExchange.Person SelectBySysIDPersonInformation(CommonExchange.SysAccess userInfo, String personSysId)
        {
            CommonExchange.Person personInfo = new CommonExchange.Person();

            return personInfo;
        } //-----------------------------------------------

        //this function returns the person information details
        public CommonExchange.Person SelectBySysIDPersonInformationNoAuthenticate(String userId, SqlConnection sqlConn, String personSysId)
        {
            CommonExchange.Person personInfo = new CommonExchange.Person();

            return personInfo;
        } //---------------------------------

        //this function gets the person information images by sysid_person list
        public DataTable SelectPersonImagesPersonInformation(CommonExchange.SysAccess userInfo, String personSysIdList)
        {
            DataTable dbTable = new DataTable();

            return dbTable;

        } //------------------------------

        //this function returns the payroll standards
        public CommonExchange.PayrollStandard SelectPayrollStandard(CommonExchange.SysAccess userInfo)
        {
            CommonExchange.PayrollStandard stdPayroll = new CommonExchange.PayrollStandard();

            return stdPayroll;

        } //--------------------------

        //this function returns the registrar standards
        public CommonExchange.RegistrarStandard SelectRegistrarStandard(CommonExchange.SysAccess userInfo)
        {
            CommonExchange.RegistrarStandard stdRegistrar = new CommonExchange.RegistrarStandard();

            return stdRegistrar;

        } //--------------------------

        //this function returns the finance standards
        public CommonExchange.FinanceStandard SelectFinanceStandard(CommonExchange.SysAccess userInfo)
        {
            CommonExchange.FinanceStandard stdFinance = new CommonExchange.FinanceStandard();

            return stdFinance;

        } //--------------------------        

        //this function return the server date
        public String GetServerDateTime(CommonExchange.SysAccess userInfo)
        {
            String serverTime = String.Empty;

            return serverTime;
                        
        } //--------------------------

        //this function return the server date
        public String GetServerDateTimeNoAuthenticate(SqlConnection sqlConn)
        {
            DateTime serverTime = DateTime.MinValue;

            return serverTime.ToString("o");
        } //-------------------------------------

        //this function is used to get data tables stored in one dataset used for administrator services
        public DataSet GetDataSetForBaseServices(CommonExchange.SysAccess userInfo)
        {
            DataSet dbSet = new DataSet();

            return dbSet;
        } //----------------------------------

        #endregion
    }
}
