using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RemoteServerLib
{
    public class RemSrvSchoolYearSemesterManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvSchoolYearSemesterManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure insterst a school semester information
        public void InsertSemesterInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.SemesterInformation semInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                semInfo.SemesterSysId = PrimaryKeys.GetNewSemesterInformationSystemID(userInfo, auth.Connection);

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertSemesterInformation";

                    sqlComm.Parameters.Add("@sysid_semester", SqlDbType.VarChar).Value = semInfo.SemesterSysId;
                    sqlComm.Parameters.Add("@year_id", SqlDbType.VarChar).Value = semInfo.SchoolYearInfo.YearId;
                    sqlComm.Parameters.Add("@semester_id", SqlDbType.VarChar).Value = semInfo.SemesterId;
                    sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = DateTime.Parse(semInfo.DateStart);
                    sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = DateTime.Parse(semInfo.DateEnd);

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }

        } //--------------------------------------

        //this procedure inserts a school year
        public void InsertSchoolYear(CommonExchange.SysAccess userInfo, ref CommonExchange.SchoolYear yearInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                yearInfo.YearId = PrimaryKeys.GetNewSchoolYearID(userInfo, auth.Connection, yearInfo);

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertSchoolYear";

                    sqlComm.Parameters.Add("@year_id", SqlDbType.VarChar).Value = yearInfo.YearId;
                    sqlComm.Parameters.Add("@year_description", SqlDbType.VarChar).Value = yearInfo.Description;
                    sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = DateTime.Parse(yearInfo.DateStart);
                    sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = DateTime.Parse(yearInfo.DateEnd);
                    sqlComm.Parameters.Add("@is_summer", SqlDbType.Bit).Value = false;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //--------------------------------

        //this procedure inserts a school year (Summer)
        public void InsertSchoolYearSummer(CommonExchange.SysAccess userInfo, CommonExchange.SchoolYear baseYearInfo, ref CommonExchange.SchoolYear yearInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                yearInfo.YearId = PrimaryKeys.GetNewSchoolYearIDSummer(userInfo, auth.Connection, baseYearInfo, yearInfo);

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertSchoolYear";

                    sqlComm.Parameters.Add("@year_id", SqlDbType.VarChar).Value = yearInfo.YearId;
                    sqlComm.Parameters.Add("@year_description", SqlDbType.VarChar).Value = yearInfo.Description;
                    sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = DateTime.Parse(yearInfo.DateStart);
                    sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = DateTime.Parse(yearInfo.DateEnd);
                    sqlComm.Parameters.Add("@is_summer", SqlDbType.Bit).Value = true;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //--------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function returns the selected school year information
        public DataTable SelectByYearDescriptionSchoolYearTable(CommonExchange.SysAccess userInfo, String queryString, String serverDateTime)
        {
            DataTable dbTable;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                if (String.Equals(queryString, "*"))
                {
                    dbTable = ProcStatic.GetSchoolYearTable(auth.Connection, userInfo.UserId, serverDateTime);
                }
                else
                {
                    dbTable = ProcStatic.GetByYearDescriptionSchoolYearTable(auth.Connection, userInfo.UserId, queryString, serverDateTime);
                }
            }

            return dbTable;
        } //-----------------------------

        //this function returns the selected semester information
        public DataTable SelectYearSemesterDescriptionSemesterInformationTable(CommonExchange.SysAccess userInfo, String queryString,
            String serverDateTime)
        {
            DataTable dbTable;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                if (String.Equals(queryString, "*"))
                {
                    dbTable = ProcStatic.GetSemesterInformationTable(auth.Connection, userInfo.UserId, serverDateTime);
                }
                else
                {
                    dbTable = ProcStatic.GetYearSemesterDescriptionSemesterInformationTable(auth.Connection, userInfo.UserId, queryString, serverDateTime);
                }
            }

            return dbTable;
        } //------------------------------

        //this function returns the last opened semeter information
        public String GetMaxDateEndSemesterInformation(CommonExchange.SysAccess userInfo)
        {
            DateTime maxDate;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.GetMaxDateEndSemesterInformation";

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    maxDate = (DateTime)sqlComm.ExecuteScalar();
                }
            }

            return maxDate.ToString("o");

        } //----------------------------        

        //this function returns the max end date
        public String GetMaxDateEndSchoolYear(CommonExchange.SysAccess userInfo)
        {
            DateTime maxDate;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.GetMaxDateEndSchoolYear";

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    maxDate = (DateTime)sqlComm.ExecuteScalar();
                }
            }

            return maxDate.ToString("o");
        } //-------------------------

        //this function is used to get data tables stored in one dataset used for school year semester information
        public DataSet GetDataSetForSchoolYearSemeter(CommonExchange.SysAccess userInfo)
        {
            DataSet dbSet = new DataSet();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                //gets the school semester table
                dbSet.Tables.Add(ProcStatic.GetSchoolSemesterTable(auth.Connection, userInfo.UserId));
                //-----------------------
            }

            return dbSet;
        } //----------------------------------

        #endregion

    }
}
