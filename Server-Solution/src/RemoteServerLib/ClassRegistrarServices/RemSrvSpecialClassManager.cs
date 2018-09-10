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
                                                        DataTable studentTable)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                specialInfo.SpecialClassSysId = PrimaryKeys.GetNewSpecialClassInformationSystemID(userInfo, auth.Connection);

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertSpecialClassInformation";

                    sqlComm.Parameters.Add("@sysid_special", SqlDbType.VarChar).Value = specialInfo.SpecialClassSysId;
                    sqlComm.Parameters.Add("@sysid_subject", SqlDbType.VarChar).Value = specialInfo.SubjectSysId;
                    sqlComm.Parameters.Add("@sysid_employee", SqlDbType.VarChar).Value = specialInfo.EmployeeSysId;

                    if (!specialInfo.IsSemestral)
                    {
                        sqlComm.Parameters.Add("@year_id", SqlDbType.VarChar).Value = specialInfo.YearId;
                        sqlComm.Parameters.Add("@sysid_semester", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@year_id", SqlDbType.VarChar).Value = DBNull.Value;
                        sqlComm.Parameters.Add("@sysid_semester", SqlDbType.VarChar).Value = specialInfo.SemesterSysId;
                    }
                    
                    sqlComm.Parameters.Add("@amount", SqlDbType.Decimal).Value = specialInfo.Amount;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }

                if (studentTable != null)
                {
                    this.InsertUpdateDeleteSpecialClassStudents(userInfo, auth.Connection, studentTable, specialInfo.SpecialClassSysId);
                }
            }

            
        } //------------------------------------

        //this procedure updates a special class information
        public void UpdateSpecialClassInformation(CommonExchange.SysAccess userInfo, CommonExchange.SpecialClassInformation specialInfo,
                                                            DataTable studentTable)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateSpecialClassInformation";

                    sqlComm.Parameters.Add("@sysid_special", SqlDbType.VarChar).Value = specialInfo.SpecialClassSysId;
                    sqlComm.Parameters.Add("@amount", SqlDbType.Decimal).Value = specialInfo.Amount;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }

                if (studentTable != null)
                {
                    this.InsertUpdateDeleteSpecialClassStudents(userInfo, auth.Connection, studentTable, specialInfo.SpecialClassSysId);
                }
                
            }
        } //------------------------------------

        //this procedure deletes a special class information
        public void DeleteSpecialClassInformation(CommonExchange.SysAccess userInfo, String specialSysId)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.DeleteSpecialClassInformation";

                    sqlComm.Parameters.Add("@sysid_special", SqlDbType.VarChar).Value = specialSysId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
                
            }
        } //----------------------------------------

        //this procedure deletes a special class load
        public void DeleteSpecialClassLoad(CommonExchange.SysAccess userInfo, Int64 loadId)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.DeleteSpecialClassLoad";

                    sqlComm.Parameters.Add("@load_id", SqlDbType.BigInt).Value = loadId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }

            }
        } //------------------------------------

        //this procedure inserts and delete a student with special class
        private void InsertUpdateDeleteSpecialClassStudents(CommonExchange.SysAccess userInfo, SqlConnection sqlConn, DataTable studentTable,
                                                    String specialSysId)
        {
            using (SqlCommand insertComm = new SqlCommand())
            {
                insertComm.Connection = sqlConn;
                insertComm.CommandType = CommandType.StoredProcedure;
                insertComm.CommandText = "ums.InsertSpecialClassLoad";

                insertComm.Parameters.Add("@sysid_special", SqlDbType.VarChar).Value = specialSysId;
                insertComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).SourceColumn = "sysid_student";

                insertComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                insertComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                using (SqlCommand updateComm = new SqlCommand())
                {
                    updateComm.Connection = sqlConn;
                    updateComm.CommandType = CommandType.StoredProcedure;
                    updateComm.CommandText = "ums.UpdateSpecialClassLoad";

                    updateComm.Parameters.Add("@load_id", SqlDbType.BigInt).SourceColumn = "load_id";
                    updateComm.Parameters.Add("@is_premature_deloaded", SqlDbType.Bit).SourceColumn = "is_premature_deloaded";

                    updateComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    updateComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlCommand deleteComm = new SqlCommand())
                    {
                        deleteComm.Connection = sqlConn;
                        deleteComm.CommandType = CommandType.StoredProcedure;
                        deleteComm.CommandText = "ums.DeleteSpecialClassLoad";

                        deleteComm.Parameters.Add("@load_id", SqlDbType.BigInt).SourceColumn = "load_id";

                        deleteComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                        deleteComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                        using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                        {
                            sqlAdapter.InsertCommand = insertComm;
                            sqlAdapter.UpdateCommand = updateComm;
                            sqlAdapter.DeleteCommand = deleteComm;

                            sqlAdapter.Update(studentTable);
                        }
                    }
                }
            }

        } //-------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function is used to get the special class information by date start and date end
        public DataTable SelectByDateStartEndSpecialClassInformation(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd,
                                                                            Boolean isMarkedDeleted)
        {
            DataTable dbTable = new DataTable("SpecialClassInformationByDateStartEndTable");
            
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectByDateStartEndSpecialClassInformation";

                    sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = DateTime.Parse(dateStart);
                    sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = DateTime.Parse(dateEnd);
                    sqlComm.Parameters.Add("@is_marked_deleted", SqlDbType.Bit).Value = isMarkedDeleted;
                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                    {
                        sqlAdapter.SelectCommand = sqlComm;
                        sqlAdapter.Fill(dbTable);
                    }
                } 

            }

            return dbTable;
        } //---------------------------------

        //this function is used to get the student loaded in the special class by special class id
        public DataTable SelectBySysIDSpecialSpecialClassLoad(CommonExchange.SysAccess userInfo, String specialSysId, String serverDateTime)
        {
            DataTable dbTable = new DataTable("SpecialClassLoadBySpecialClassIdTable");
            dbTable.Columns.Add("load_id", System.Type.GetType("System.Int64"));
            dbTable.Columns.Add("load_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("deload_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            dbTable.Columns.Add("is_premature_deloaded", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("student_id", System.Type.GetType("System.String"));
            dbTable.Columns.Add("last_name", System.Type.GetType("System.String"));
            dbTable.Columns.Add("first_name", System.Type.GetType("System.String"));
            dbTable.Columns.Add("middle_name", System.Type.GetType("System.String"));
            dbTable.Columns.Add("course_id", System.Type.GetType("System.String"));
			dbTable.Columns.Add("is_current_course", System.Type.GetType("System.Boolean"));
			dbTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));
			dbTable.Columns.Add("sysid_feelevel", System.Type.GetType("System.String"));
			dbTable.Columns.Add("sysid_semester", System.Type.GetType("System.String"));
			dbTable.Columns.Add("is_graduate_student", System.Type.GetType("System.Boolean"));
			dbTable.Columns.Add("level_section", System.Type.GetType("System.String"));
			dbTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
			dbTable.Columns.Add("year_level_acronym", System.Type.GetType("System.String"));
			dbTable.Columns.Add("department_id", System.Type.GetType("System.String"));
			dbTable.Columns.Add("course_title", System.Type.GetType("System.String"));
			dbTable.Columns.Add("course_acronym", System.Type.GetType("System.String"));
			dbTable.Columns.Add("department_name", System.Type.GetType("System.String"));
			dbTable.Columns.Add("department_acronym", System.Type.GetType("System.String"));
			dbTable.Columns.Add("course_group_id", System.Type.GetType("System.String"));
            dbTable.Columns.Add("group_description", System.Type.GetType("System.String"));

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDSpecialSpecialClassLoad";

                    sqlComm.Parameters.Add("@sysid_special", SqlDbType.VarChar).Value = specialSysId;
                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                DataRow newRow = dbTable.NewRow();

                                newRow["load_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "load_id", Int64.Parse("0"));
                                newRow["load_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "load_date", 
                                    DateTime.Parse(serverDateTime)).ToString();
                                newRow["deload_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "deload_date", 
                                    DateTime.Parse(serverDateTime)).ToString();
                                newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_student", String.Empty);
                                newRow["is_premature_deloaded"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_premature_deloaded", false);
                                newRow["student_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "student_id", String.Empty);
                                newRow["last_name"] = ProcStatic.DataReaderConvert(sqlReader, "last_name", String.Empty);
                                newRow["first_name"] = ProcStatic.DataReaderConvert(sqlReader, "first_name", String.Empty);
                                newRow["middle_name"] = ProcStatic.DataReaderConvert(sqlReader, "middle_name", String.Empty);
                                newRow["course_id"] = ProcStatic.DataReaderConvert(sqlReader, "course_id", String.Empty);
                                newRow["is_current_course"] = ProcStatic.DataReaderConvert(sqlReader, "is_current_course", false);
                                newRow["sysid_enrolmentlevel"] = ProcStatic.DataReaderConvert(sqlReader, "sysid_enrolmentlevel", String.Empty);
                                newRow["sysid_feelevel"] = ProcStatic.DataReaderConvert(sqlReader, "sysid_feelevel", String.Empty);
                                newRow["sysid_semester"] = ProcStatic.DataReaderConvert(sqlReader, "sysid_semester", String.Empty);
                                newRow["is_graduate_student"] = ProcStatic.DataReaderConvert(sqlReader, "is_graduate_student", false);
                                newRow["level_section"] = ProcStatic.DataReaderConvert(sqlReader, "level_section", String.Empty);
                                newRow["year_level_description"] = ProcStatic.DataReaderConvert(sqlReader, "year_level_description", String.Empty);
                                newRow["year_level_acronym"] = ProcStatic.DataReaderConvert(sqlReader, "year_level_acronym", String.Empty);
                                newRow["department_id"] = ProcStatic.DataReaderConvert(sqlReader, "department_id", String.Empty);
                                newRow["course_title"] = ProcStatic.DataReaderConvert(sqlReader, "course_title", String.Empty);
                                newRow["course_acronym"] = ProcStatic.DataReaderConvert(sqlReader, "course_acronym", String.Empty);
                                newRow["department_name"] = ProcStatic.DataReaderConvert(sqlReader, "department_name", String.Empty);
                                newRow["department_acronym"] = ProcStatic.DataReaderConvert(sqlReader, "department_acronym", String.Empty);
                                newRow["course_group_id"] = ProcStatic.DataReaderConvert(sqlReader, "course_group_id", String.Empty);
                                newRow["group_description"] = ProcStatic.DataReaderConvert(sqlReader, "group_description", String.Empty);

                                dbTable.Rows.Add(newRow);
                            }
                        }

                        sqlReader.Close();
                    }
                } 

            }

            dbTable.AcceptChanges();

            return dbTable;
        } //------------------------------

        //this function is used to get the student loaded in the special class by date start end
        public DataTable SelectBySysIDStudentListDateStartEndSpecialClassInformation(CommonExchange.SysAccess userInfo, String studentSysIdList,
            String dateStart, String dateEnd, String serverDateTime)
        {
            DataTable dbTable = new DataTable("SpecialClassLoadByStudentListDateStartEndTable");
            dbTable.Columns.Add("load_id", System.Type.GetType("System.Int64"));
			dbTable.Columns.Add("sysid_special", System.Type.GetType("System.String"));
            dbTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
			dbTable.Columns.Add("load_date", System.Type.GetType("System.String"));
			dbTable.Columns.Add("deload_date", System.Type.GetType("System.String"));
			dbTable.Columns.Add("is_premature_deloaded", System.Type.GetType("System.Boolean"));
			dbTable.Columns.Add("sysid_subject", System.Type.GetType("System.String"));
			dbTable.Columns.Add("sysid_employee", System.Type.GetType("System.String"));
			dbTable.Columns.Add("year_semester_id", System.Type.GetType("System.String"));
			dbTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));
			dbTable.Columns.Add("department_id", System.Type.GetType("System.String"));
			dbTable.Columns.Add("subject_code", System.Type.GetType("System.String"));
			dbTable.Columns.Add("descriptive_title", System.Type.GetType("System.String"));
			dbTable.Columns.Add("subject_lecture_units", System.Type.GetType("System.Byte"));
			dbTable.Columns.Add("subject_lab_units", System.Type.GetType("System.Byte"));
			dbTable.Columns.Add("subject_no_hours", System.Type.GetType("System.String"));
            dbTable.Columns.Add("is_non_academic", System.Type.GetType("System.Boolean"));
		    dbTable.Columns.Add("category_id", System.Type.GetType("System.String"));
		    dbTable.Columns.Add("category_name", System.Type.GetType("System.String"));
            dbTable.Columns.Add("category_acronym", System.Type.GetType("System.String"));
			dbTable.Columns.Add("is_semestral", System.Type.GetType("System.Boolean"));
			dbTable.Columns.Add("employee_id", System.Type.GetType("System.String"));
			dbTable.Columns.Add("last_name", System.Type.GetType("System.String"));
			dbTable.Columns.Add("first_name", System.Type.GetType("System.String"));
			dbTable.Columns.Add("middle_name", System.Type.GetType("System.String"));
			dbTable.Columns.Add("status_id", System.Type.GetType("System.Byte"));
			dbTable.Columns.Add("type_description", System.Type.GetType("System.String"));
			dbTable.Columns.Add("status_description", System.Type.GetType("System.String"));
			dbTable.Columns.Add("subject_department_name", System.Type.GetType("System.String"));
            dbTable.Columns.Add("employee_department_name", System.Type.GetType("System.String"));

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDStudentListDateStartEndSpecialClassInformation";

                    sqlComm.Parameters.Add("@sysid_student_list", SqlDbType.NVarChar).Value = studentSysIdList;
                    sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = DateTime.Parse(dateStart);
                    sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = DateTime.Parse(dateEnd);

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                DataRow newRow = dbTable.NewRow();

                                newRow["load_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "load_id", Int64.Parse("0"));
                                newRow["sysid_special"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_special", String.Empty);
                                newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_student", String.Empty);
                                newRow["load_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "load_date",
                                    DateTime.Parse(serverDateTime)).ToString();
                                newRow["deload_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "deload_date",
                                    DateTime.Parse(serverDateTime)).ToString();
                                newRow["is_premature_deloaded"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_premature_deloaded", false);
                                newRow["sysid_subject"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_subject", String.Empty);
                                newRow["sysid_employee"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_employee", String.Empty);
                                newRow["year_semester_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "year_semester_id", String.Empty);
                                newRow["amount"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "amount", Decimal.Parse("0"));
                                newRow["department_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "department_id", String.Empty);
                                newRow["subject_code"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "subject_code", String.Empty);
                                newRow["descriptive_title"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "descriptive_title", String.Empty);
                                newRow["subject_lecture_units"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "subject_lecture_units", Byte.Parse("0"));
                                newRow["subject_lab_units"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "subject_lab_units", Byte.Parse("0"));
                                newRow["subject_no_hours"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "subject_no_hours", String.Empty);
                                newRow["is_non_academic"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_non_academic", false);
                                newRow["category_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "category_id", String.Empty);
                                newRow["category_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "category_name", String.Empty);
                                newRow["category_acronym"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "category_acronym", String.Empty);
                                newRow["is_semestral"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_semestral", false);
                                newRow["employee_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "employee_id", String.Empty);
                                newRow["last_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "last_name", String.Empty);
                                newRow["first_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "first_name", String.Empty);
                                newRow["middle_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "middle_name", String.Empty);
                                newRow["status_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "status_id", Byte.Parse("0"));
                                newRow["type_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "type_description", String.Empty);
                                newRow["status_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "status_description", String.Empty);
                                newRow["subject_department_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "subject_department_name", 
                                    String.Empty);
                                newRow["employee_department_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "employee_department_name", 
                                    String.Empty);

                                dbTable.Rows.Add(newRow);
                            }
                        }

                        sqlReader.Close();
                    }
                }

            }

            dbTable.AcceptChanges();

            return dbTable;
        } //------------------------------

        //this function is used to get the special class information by date start and date end
        public DataTable SelectBySysIDEmployeeListDateStartEndSpecialClassInformation(CommonExchange.SysAccess userInfo, String employeeSysIdList, 
            String dateStart, String dateEnd)
        {
            DataTable dbTable = new DataTable("SpecialClassInformationByDateStartEndEmployeeSysIDTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDEmployeeListDateStartEndSpecialClassInformation";

                    sqlComm.Parameters.Add("@sysid_employee_list", SqlDbType.NVarChar).Value = employeeSysIdList;
                    sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = DateTime.Parse(dateStart);
                    sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = DateTime.Parse(dateEnd);

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                    {
                        sqlAdapter.SelectCommand = sqlComm;
                        sqlAdapter.Fill(dbTable);
                    }
                }

            }

            return dbTable;
        } //---------------------------------

        //this function determines if the special class information already exists
        public Boolean IsExistsInformationSpecialClassInformation(CommonExchange.SysAccess userInfo, 
                                                                    CommonExchange.SpecialClassInformation specialInfo)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsExistsInformationSpecialClassInformation";

                    sqlComm.Parameters.Add("@sysid_subject", SqlDbType.VarChar).Value = specialInfo.SubjectSysId;
                    sqlComm.Parameters.Add("@sysid_employee", SqlDbType.VarChar).Value = specialInfo.EmployeeSysId;

                    if (!specialInfo.IsSemestral)
                    {
                        sqlComm.Parameters.Add("@year_semester_id", SqlDbType.VarChar).Value = specialInfo.YearId;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@year_semester_id", SqlDbType.VarChar).Value = specialInfo.SemesterSysId;
                    }                    
                    
                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;

        } //------------------------------

        //this function is used to get data tables stored in one dataset used for special class information
        public DataSet GetDataSetForSpecialClassInformation(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            DataSet dbSet = new DataSet();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                //gets the school year table
                dbSet.Tables.Add(ProcStatic.GetSchoolFeeInformationTable(auth.Connection, userInfo.UserId, serverDateTime));
                //------------------------------------

                //gets the employee table
                dbSet.Tables.Add(ProcStatic.GetEmployeeInformationTable(auth.Connection, userInfo.UserId));
                //---------------------------------

                //gets the semester information table
                dbSet.Tables.Add(ProcStatic.GetSemesterInformationTable(auth.Connection, userInfo.UserId, serverDateTime));
                //--------------------------------                
            }

            return dbSet;
        } //----------------------------------

        #endregion
    }
}
