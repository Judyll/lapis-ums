using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteServerLib
{
    public class RemSrvScholarshipManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvScholarshipManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new scholarship information
        public void InsertScholarshipInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.ScholarshipInformation scholarshipInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                scholarshipInfo.ScholarshipSysId = PrimaryKeys.GetNewScholarshipInformationSystemID(userInfo, auth.Connection);

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertScholarshipInformation";

                    sqlComm.Parameters.Add("@sysid_scholarship", SqlDbType.VarChar).Value = scholarshipInfo.ScholarshipSysId;
                    sqlComm.Parameters.Add("@course_group_id", SqlDbType.VarChar).Value = scholarshipInfo.CourseGroupInfo.CourseGroupId;
                    sqlComm.Parameters.Add("@department_id", SqlDbType.VarChar).Value = scholarshipInfo.DepartmentInfo.DepartmentId;
                    sqlComm.Parameters.Add("@scholarship_description", SqlDbType.VarChar).Value = scholarshipInfo.ScholarshipDescription;
                    sqlComm.Parameters.Add("@is_non_academic", SqlDbType.Bit).Value = scholarshipInfo.IsNonAcademic;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //--------------------------------------

        //this procedure updates a scholarship information
        public void UpdateScholarshipInformation(CommonExchange.SysAccess userInfo, CommonExchange.ScholarshipInformation scholarshipInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateScholarshipInformation";

                    sqlComm.Parameters.Add("@sysid_scholarship", SqlDbType.VarChar).Value = scholarshipInfo.ScholarshipSysId;
                    sqlComm.Parameters.Add("@department_id", SqlDbType.VarChar).Value = scholarshipInfo.DepartmentInfo.DepartmentId;
                    sqlComm.Parameters.Add("@scholarship_description", SqlDbType.VarChar).Value = scholarshipInfo.ScholarshipDescription;
                    sqlComm.Parameters.Add("@is_non_academic", SqlDbType.Bit).Value = scholarshipInfo.IsNonAcademic;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //--------------------------------------

        //this procedure inserts a new student scholarship
        public void InsertStudentScholarship(CommonExchange.SysAccess userInfo, ref CommonExchange.StudentScholarship studentScholarship)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                studentScholarship.StudentScholarshipSysId = PrimaryKeys.GetNewStudentScholarshipSystemID(userInfo, auth.Connection);

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertStudentScholarship";

                    sqlComm.Parameters.Add("@sysid_studentscholarship", SqlDbType.VarChar).Value = studentScholarship.StudentScholarshipSysId;
                    sqlComm.Parameters.Add("@sysid_scholarship", SqlDbType.VarChar).Value = studentScholarship.ScholarshipInfo.ScholarshipSysId;
                    sqlComm.Parameters.Add("@sysid_enrolmentlevel", SqlDbType.VarChar).Value = studentScholarship.StudentEnrolmentLevelInfo.EnrolmentLevelSysId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //--------------------------------------

        //this procedure update a student scholarship
        public void UpdateStudentScholarship(CommonExchange.SysAccess userInfo, CommonExchange.StudentScholarship studentScholarship)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateStudentScholarship";

                    sqlComm.Parameters.Add("@sysid_studentscholarship", SqlDbType.VarChar).Value = studentScholarship.StudentScholarshipSysId;
                    sqlComm.Parameters.Add("@sysid_scholarship", SqlDbType.VarChar).Value = studentScholarship.ScholarshipInfo.ScholarshipSysId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //--------------------------------------

        //this procedure delete a student scholarship
        public void DeleteStudentScholarship(CommonExchange.SysAccess userInfo, CommonExchange.StudentScholarship studentScholarship)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.DeleteStudentScholarship";

                    sqlComm.Parameters.Add("@sysid_studentscholarship", SqlDbType.VarChar).Value = studentScholarship.StudentScholarshipSysId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //--------------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function gets the student scholarship table
        public DataTable SelectStudentScholarship(CommonExchange.SysAccess userInfo, String queryString, String dateStart, String dateEnd,
            String scholarshipSysIdList, String departmentIdList, String yearLevelIdList)
        {
            DataTable dbTable = new DataTable("StudentScholarshipTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectStudentScholarship";

                    if (String.IsNullOrEmpty(queryString))
                    {
                        sqlComm.Parameters.Add("@query_string", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@query_string", SqlDbType.VarChar).Value = queryString;
                    }

                    DateTime dStart = DateTime.MinValue;
                    DateTime dEnd = DateTime.MinValue;

                    if ((String.IsNullOrEmpty(dateStart) || !DateTime.TryParse(dateStart, out dStart)) ||
                        (String.IsNullOrEmpty(dateEnd) || !DateTime.TryParse(dateEnd, out dEnd)))
                    {
                        sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = DBNull.Value;
                        sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = dStart;
                        sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = dEnd;
                    }

                    if (String.IsNullOrEmpty(scholarshipSysIdList))
                    {
                        sqlComm.Parameters.Add("@sysid_scholarship_list", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@sysid_scholarship_list", SqlDbType.NVarChar).Value = scholarshipSysIdList;
                    }

                    if (String.IsNullOrEmpty(departmentIdList))
                    {
                        sqlComm.Parameters.Add("@department_id_list", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@department_id_list", SqlDbType.NVarChar).Value = departmentIdList;
                    }

                    if (String.IsNullOrEmpty(yearLevelIdList))
                    {
                        sqlComm.Parameters.Add("@year_level_id_list", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@year_level_id_list", SqlDbType.NVarChar).Value = yearLevelIdList;
                    }

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                    {
                        sqlAdapter.SelectCommand = sqlComm;
                        sqlAdapter.Fill(dbTable);
                    }
                }
            }

            return dbTable;

        } //------------------------------

        //this procedure returns the discounts of the student with scholarships
        public DataTable SelectBySysIDEnrolmentLevelStudentScholarship(CommonExchange.SysAccess userInfo, String enrolmentLevelSysId, String serverDateTime)
        {
            DataTable dbTable = new DataTable("StudentScholarshipWithDiscountsTable");
            dbTable.Columns.Add("sysid_studentscholarship", System.Type.GetType("System.String"));
            dbTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            dbTable.Columns.Add("sysid_scholarship", System.Type.GetType("System.String"));
            dbTable.Columns.Add("scholarship_description", System.Type.GetType("System.String"));
            dbTable.Columns.Add("is_non_academic", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("department_name", System.Type.GetType("System.String"));
            dbTable.Columns.Add("department_acronym", System.Type.GetType("System.String"));
            dbTable.Columns.Add("discount_id", System.Type.GetType("System.Int64"));
            dbTable.Columns.Add("reflected_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("received_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("remarks", System.Type.GetType("System.String"));
            dbTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));
            dbTable.Columns.Add("is_downpayment", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("is_included_in_post", System.Type.GetType("System.Boolean"));

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDEnrolmentLevelStudentScholarship";

                    sqlComm.Parameters.Add("@sysid_enrolmentlevel", SqlDbType.VarChar).Value = enrolmentLevelSysId;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                DataRow newRow = dbTable.NewRow();

                                newRow["sysid_studentscholarship"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_studentscholarship", "");
                                newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_student", "");
                                newRow["sysid_scholarship"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_scholarship", "");
                                newRow["scholarship_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "scholarship_description", "");
                                newRow["is_non_academic"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_non_academic", false);
                                newRow["department_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "department_name", "");
                                newRow["department_acronym"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "department_acronym", "");
                                newRow["discount_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "discount_id", Int64.Parse("0"));
                                newRow["reflected_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "reflected_date",
                                    DateTime.Parse(serverDateTime)).ToShortDateString();
                                newRow["received_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "received_date",
                                    DateTime.Parse(serverDateTime)).ToShortDateString();
                                newRow["remarks"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "remarks", "");
                                newRow["amount"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "amount", Decimal.Parse("0"));
                                newRow["is_downpayment"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_downpayment", false);
                                newRow["is_included_in_post"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_included_in_post", false);

                                dbTable.Rows.Add(newRow);
                            }
                        }

                        sqlReader.Close();
                    }

                    dbTable.AcceptChanges();

                }
            }

            return dbTable;

        } //------------------------------------------     

        //this function is used to determine if the scholarship description already exists
        public Boolean IsExistsScholarshipDescriptionScholarshipInformation(CommonExchange.SysAccess userInfo,
            CommonExchange.ScholarshipInformation scholarshipInfo)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsExistsScholarshipDescriptionScholarshipInformation";

                    sqlComm.Parameters.Add("@sysid_scholarship", SqlDbType.VarChar).Value = scholarshipInfo.ScholarshipSysId;
                    sqlComm.Parameters.Add("@course_group_id", SqlDbType.VarChar).Value = scholarshipInfo.CourseGroupInfo.CourseGroupId;
                    sqlComm.Parameters.Add("@department_id", SqlDbType.VarChar).Value = scholarshipInfo.DepartmentInfo.DepartmentId;
                    sqlComm.Parameters.Add("@scholarship_description", SqlDbType.VarChar).Value = scholarshipInfo.ScholarshipDescription;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;
        } //------------------------------

        //this function is used to determine if the student scholarship already exists
        public Boolean IsExistsSysIDStudentScholarshipEnrolmentLevelStudentScholarship(CommonExchange.SysAccess userInfo,
            CommonExchange.StudentScholarship studentScholarship)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsExistsSysIDStudentScholarshipEnrolmentLevelStudentScholarship";

                    sqlComm.Parameters.Add("@sysid_studentscholarship", SqlDbType.VarChar).Value = studentScholarship.StudentScholarshipSysId;
                    sqlComm.Parameters.Add("@sysid_scholarship", SqlDbType.VarChar).Value = studentScholarship.ScholarshipInfo.ScholarshipSysId;
                    sqlComm.Parameters.Add("@sysid_enrolmentlevel", SqlDbType.VarChar).Value = studentScholarship.StudentEnrolmentLevelInfo.EnrolmentLevelSysId;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;
        } //------------------------------

        //this function is used to get data tables stored in one dataset used for scholarship manager
        public DataSet GetDataSetForScholarship(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            DataSet dbSet = new DataSet();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                //gets the school fee information table
                dbSet.Tables.Add(ProcStatic.GetSchoolFeeInformationTable(auth.Connection, userInfo.UserId, serverDateTime));
                //----------------------------

                //gets the semester information table
                dbSet.Tables.Add(ProcStatic.GetSemesterInformationTable(auth.Connection, userInfo.UserId, serverDateTime));
                //------------------------

                //get the course group table
                dbSet.Tables.Add(ProcStatic.GetCourseGroupTable(auth.Connection, userInfo.UserId));
                //-----------------------------

                //get the course information table
                dbSet.Tables.Add(ProcStatic.GetCourseInformationTable(auth.Connection, userInfo.UserId));
                //--------------------------------------

                //get the department information table
                dbSet.Tables.Add(ProcStatic.GetDepartmentInformationTable(auth.Connection, userInfo.UserId));
                //--------------------

                //get the scholarship information table
                dbSet.Tables.Add(ProcStatic.GetScholarshipInformationTable(auth.Connection, userInfo.UserId));
                //--------------------------------

                //get the year level information table
                dbSet.Tables.Add(ProcStatic.GetYearLevelInformationTable(auth.Connection, userInfo.UserId));
                //-------------------------------------
            }

            return dbSet;
        } //----------------------------------

        #endregion

    }
}
