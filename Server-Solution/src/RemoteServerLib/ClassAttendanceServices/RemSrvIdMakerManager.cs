using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RemoteServerLib
{
    public class RemSrvIdMakerManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor
        public RemSrvIdMakerManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure updates an employee information for ID Maker
        public void UpdateForIdMakerEmployeeInformation(CommonExchange.SysAccess userInfo, CommonExchange.Employee employeeInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateForIDMakerEmployeeInformation";

                    sqlComm.Parameters.Add("@sysid_employee", SqlDbType.VarChar).Value = employeeInfo.EmployeeSysId;
                    sqlComm.Parameters.Add("@card_number", SqlDbType.VarChar).Value = employeeInfo.CardNumber;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }

                if (employeeInfo.PersonInfo.FileData != null && !String.IsNullOrEmpty(employeeInfo.PersonInfo.FileName) &&
                        !String.IsNullOrEmpty(employeeInfo.PersonInfo.FileExtension))
                {
                    using (SqlCommand imageComm = new SqlCommand())
                    {
                        imageComm.Connection = auth.Connection;
                        imageComm.CommandType = CommandType.StoredProcedure;
                        imageComm.CommandText = "ums.InsertUpdatePersonImage";

                        imageComm.Parameters.Add("@sysid_person", SqlDbType.VarChar).Value = employeeInfo.PersonInfo.PersonSysId;
                        imageComm.Parameters.Add("@file_data", SqlDbType.VarBinary).Value = employeeInfo.PersonInfo.FileData;
                        imageComm.Parameters.Add("@original_name", SqlDbType.VarChar).Value = employeeInfo.PersonInfo.PersonSysId + 
                            employeeInfo.PersonInfo.FileExtension;

                        imageComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                        imageComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                        imageComm.ExecuteNonQuery();
                    }

                }

            }

        } //---------------------------------

        //this procedure updates a student information for ID Maker
        public void UpdateForIdMakerStudentInformation(CommonExchange.SysAccess userInfo, CommonExchange.Student studentInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateForIDMakerStudentInformation";

                    sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = studentInfo.StudentSysId;
                    sqlComm.Parameters.Add("@card_number", SqlDbType.VarChar).Value = studentInfo.CardNumber;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }

                if (studentInfo.PersonInfo.FileData != null && !String.IsNullOrEmpty(studentInfo.PersonInfo.FileName) &&
                        !String.IsNullOrEmpty(studentInfo.PersonInfo.FileExtension))
                {
                    using (SqlCommand imageComm = new SqlCommand())
                    {
                        imageComm.Connection = auth.Connection;
                        imageComm.CommandType = CommandType.StoredProcedure;
                        imageComm.CommandText = "ums.InsertUpdatePersonImage";

                        imageComm.Parameters.Add("@sysid_person", SqlDbType.VarChar).Value = studentInfo.PersonInfo.PersonSysId;
                        imageComm.Parameters.Add("@file_data", SqlDbType.VarBinary).Value = studentInfo.PersonInfo.FileData;
                        imageComm.Parameters.Add("@original_name", SqlDbType.VarChar).Value = studentInfo.PersonInfo.PersonSysId +
                            studentInfo.PersonInfo.FileExtension;

                        imageComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                        imageComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                        imageComm.ExecuteNonQuery();
                    }

                }
            }

        } //-------------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function gets the student and employee table query
        public DataTable SelectByQueryStringStudentEmployeeInformation(CommonExchange.SysAccess userInfo, String queryString,
            Boolean includeEmergencyContact)
        {
            DataTable dbTable = new DataTable("StudentEmployeeInformationTable"); ;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectByQueryStringStudentEmployeeInformation";

                    sqlComm.Parameters.Add("@query_string", SqlDbType.VarChar).Value = queryString;
                    sqlComm.Parameters.Add("@include_emergency_contact", SqlDbType.Bit).Value = includeEmergencyContact;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                    {
                        sqlAdapter.SelectCommand = sqlComm;
                        sqlAdapter.Fill(dbTable);
                    }
                }
            }

            return dbTable;
        } //-------------------------------------

        //this function is used to determine if the student card number exists
        public Boolean IsExistsCardNumberStudentInformation(CommonExchange.SysAccess userInfo, String cardNumber, String studentSysId)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsExistsCardNumberStudentInformation";

                    sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = studentSysId;
                    sqlComm.Parameters.Add("@card_number", SqlDbType.VarChar).Value = cardNumber;
                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;
        } //-----------------------------

        //this function is used to determine if the card number exists
        public Boolean IsExistsCardNumberEmployeeInformation(CommonExchange.SysAccess userInfo, String cardNumber, String employeeSysId)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsExistsCardNumberEmployeeInformation";

                    sqlComm.Parameters.Add("@sysid_employee", SqlDbType.VarChar).Value = employeeSysId;
                    sqlComm.Parameters.Add("@card_number", SqlDbType.VarChar).Value = cardNumber;
                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;
        } //-----------------------------
        #endregion
    }
}
