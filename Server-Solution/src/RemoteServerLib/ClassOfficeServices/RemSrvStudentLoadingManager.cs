using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteServerLib
{
    public class RemSrvStudentLoadingManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvStudentLoadingManager() { }

        void IDisposable.Dispose() { }

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts or delete a student load
        public void InsertUpdateDeleteStudentLoad(CommonExchange.SysAccess userInfo, DataTable studentLoadTable)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand insertComm = new SqlCommand())
                {
                    insertComm.Connection = auth.Connection;
                    insertComm.CommandType = CommandType.StoredProcedure;
                    insertComm.CommandText = "ums.InsertStudentLoad";

                    insertComm.Parameters.Add("@sysid_enrolmentlevel", SqlDbType.VarChar).SourceColumn = "sysid_enrolmentlevel";
                    insertComm.Parameters.Add("@sysid_schedule", SqlDbType.VarChar).SourceColumn = "sysid_schedule";

                    insertComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    insertComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlCommand updateComm = new SqlCommand())
                    {

                        updateComm.Connection = auth.Connection;
                        updateComm.CommandType = CommandType.StoredProcedure;
                        updateComm.CommandText = "ums.UpdateStudentLoad";

                        updateComm.Parameters.Add("@load_id", SqlDbType.BigInt).SourceColumn = "load_id";
                        updateComm.Parameters.Add("@is_premature_deloaded", SqlDbType.Bit).SourceColumn = "is_premature_deloaded";

                        updateComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                        updateComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                        using (SqlCommand deleteComm = new SqlCommand())
                        {
                            deleteComm.Connection = auth.Connection;
                            deleteComm.CommandType = CommandType.StoredProcedure;
                            deleteComm.CommandText = "ums.DeleteStudentLoad";

                            deleteComm.Parameters.Add("@load_id", SqlDbType.BigInt).SourceColumn = "load_id";

                            deleteComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                            deleteComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                            using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                            {
                                sqlAdapter.InsertCommand = insertComm;
                                sqlAdapter.UpdateCommand = updateComm;
                                sqlAdapter.DeleteCommand = deleteComm;

                                sqlAdapter.Update(studentLoadTable);
                            }
                        }
                    }
                }
            }
        } //----------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this procedure returns the subject schedule load by date start and end of the student by enrolment level
        public DataTable SelectBySysIDEnrolmentLevelDateStartEndSubjectScheduleStudentLoad(CommonExchange.SysAccess userInfo, String studentSysId, 
            String enrolmentLevelSysId, String feeLevelSysId, String semesterSysId, Boolean isGraduateStudent, Boolean isInternational,
            Boolean isEnrolled, Boolean isForStudentTab, String dateStart, String dateEnd, String serverDateTime)
        {
            DataTable dbTable = new DataTable("SubjectScheduleForStudentLoadingByDateStartEndTable");
            dbTable.Columns.Add("sysid_schedule", System.Type.GetType("System.String"));
            dbTable.Columns.Add("sysid_subject", System.Type.GetType("System.String"));
			dbTable.Columns.Add("year_semester_id", System.Type.GetType("System.String"));
			dbTable.Columns.Add("is_team_teaching", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("is_irregular_modular", System.Type.GetType("System.Boolean"));
			dbTable.Columns.Add("is_fixed_amount", System.Type.GetType("System.Boolean"));
			dbTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));
            dbTable.Columns.Add("additional_slots", System.Type.GetType("System.Int16"));
            dbTable.Columns.Add("maximum_capacity", System.Type.GetType("System.Byte"));
			dbTable.Columns.Add("subject_code", System.Type.GetType("System.String"));
			dbTable.Columns.Add("descriptive_title", System.Type.GetType("System.String"));
            dbTable.Columns.Add("subject_lecture_units", System.Type.GetType("System.Byte"));
            dbTable.Columns.Add("subject_lab_units", System.Type.GetType("System.Byte"));
            dbTable.Columns.Add("subject_no_hours", System.Type.GetType("System.String"));
            dbTable.Columns.Add("is_non_academic", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("category_id", System.Type.GetType("System.String"));
            dbTable.Columns.Add("category_name", System.Type.GetType("System.String"));
            dbTable.Columns.Add("category_acronym", System.Type.GetType("System.String"));
            dbTable.Columns.Add("department_name", System.Type.GetType("System.String"));
			dbTable.Columns.Add("is_semestral", System.Type.GetType("System.Boolean"));
			dbTable.Columns.Add("group_no", System.Type.GetType("System.Byte"));
			dbTable.Columns.Add("load_id", System.Type.GetType("System.Int64"));
			dbTable.Columns.Add("load_date", System.Type.GetType("System.String"));
			dbTable.Columns.Add("deload_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("load_lecture_units", System.Type.GetType("System.Byte"));
            dbTable.Columns.Add("load_lab_units", System.Type.GetType("System.Byte"));
            dbTable.Columns.Add("load_no_hours", System.Type.GetType("System.String"));
			dbTable.Columns.Add("is_premature_deloaded", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("is_loaded_to_student", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("slots_available", System.Type.GetType("System.Int16"));
            dbTable.Columns.Add("subject_amount", System.Type.GetType("System.Decimal"));

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDEnrolmentLevelDateStartEndSubjectScheduleStudentLoad";

                    sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = studentSysId;

                    if (!String.IsNullOrEmpty(enrolmentLevelSysId))
                    {
                        sqlComm.Parameters.Add("@sysid_enrolmentlevel", SqlDbType.VarChar).Value = enrolmentLevelSysId;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@sysid_enrolmentlevel", SqlDbType.VarChar).Value = DBNull.Value;
                    }

                    sqlComm.Parameters.Add("@sysid_feelevel", SqlDbType.VarChar).Value = feeLevelSysId;
                    sqlComm.Parameters.Add("@sysid_semester", SqlDbType.VarChar).Value = semesterSysId;
                    sqlComm.Parameters.Add("@is_graduate_student", SqlDbType.Bit).Value = isGraduateStudent;
                    sqlComm.Parameters.Add("@is_international", SqlDbType.Bit).Value = isInternational;
                    sqlComm.Parameters.Add("@is_enrolled", SqlDbType.Bit).Value = isEnrolled;
                    sqlComm.Parameters.Add("@is_for_student_tab", SqlDbType.Bit).Value = isForStudentTab;
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

                                newRow["sysid_schedule"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_schedule", "");
                                newRow["sysid_subject"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_subject", "");
                                newRow["year_semester_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "year_semester_id", "");
                                newRow["is_team_teaching"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_team_teaching", false);
                                newRow["is_irregular_modular"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_irregular_modular", false);
                                newRow["is_fixed_amount"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_fixed_amount", false);
                                newRow["amount"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "amount", Decimal.Parse("0"));
                                newRow["additional_slots"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "additional_slots", Int16.Parse("0"));
                                newRow["maximum_capacity"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "maximum_capacity", Byte.Parse("0"));
                                newRow["subject_code"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "subject_code", "");
                                newRow["descriptive_title"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "descriptive_title", "");
                                newRow["subject_lecture_units"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "subject_lecture_units", Byte.Parse("0"));
                                newRow["subject_lab_units"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "subject_lab_units", Byte.Parse("0"));
                                newRow["subject_no_hours"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "subject_no_hours", "00:00");
                                newRow["is_non_academic"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_non_academic", false);
                                newRow["category_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "category_id", String.Empty);
                                newRow["category_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "category_name", String.Empty);
                                newRow["category_acronym"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "category_acronym", String.Empty);
                                newRow["department_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "department_name", "");
                                newRow["is_semestral"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_semestral", false);
                                newRow["group_no"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "group_no", Byte.Parse("0"));
                                newRow["load_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "load_id", Int64.Parse("0"));
                                newRow["load_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "load_date",
                                    DateTime.Parse(serverDateTime)).ToString();
                                newRow["deload_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "deload_date",
                                    DateTime.Parse(serverDateTime)).ToString();
                                newRow["load_lecture_units"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "load_lecture_units", Byte.Parse("0"));
                                newRow["load_lab_units"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "load_lab_units", Byte.Parse("0"));
                                newRow["load_no_hours"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "load_no_hours", "00:00");
                                newRow["is_premature_deloaded"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_premature_deloaded", false);
                                newRow["is_loaded_to_student"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_loaded_to_student", false);
                                newRow["slots_available"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "slots_available", Int16.Parse("-1"));
                                newRow["subject_amount"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "subject_amount", Decimal.Parse("0"));

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

        //this procedure returns the subject schedule details by date start and end of the student by enrolment level
        public DataTable SelectBySysIDEnrolmentLevelDateStartEndScheduleDetailsStudentLoad(CommonExchange.SysAccess userInfo, String enrolmentLevelSysId,
            String dateStart, String dateEnd)
        {
            DataTable dbTable = new DataTable("ScheduleDetailsForStudentLoadingByDateStartEndTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDEnrolmentLevelDateStartEndScheduleDetailsStudentLoad";

                    sqlComm.Parameters.Add("@sysid_enrolmentlevel", SqlDbType.VarChar).Value = enrolmentLevelSysId;
                    sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = DateTime.Parse(dateStart);
                    sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = DateTime.Parse(dateEnd);

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                    {
                        sqlAdapter.SelectCommand = sqlComm;
                        sqlAdapter.Fill(dbTable);
                    }

                    dbTable.AcceptChanges();

                }
            }

            return dbTable;

        } //---------------------------------------------

        //this procedure returns the subject schedule load by enrolment level list
        public DataTable SelectBySysIDEnrolmentLevelListSubjectScheduleStudentLoad(CommonExchange.SysAccess userInfo, String enrolmentLevelSysIdList,
            String serverDateTime)
        {
            DataTable dbTable = new DataTable("SubjectScheduleForStudentLoadingEnrolmentLevelListTable");
            dbTable.Columns.Add("sysid_schedule", System.Type.GetType("System.String"));
            dbTable.Columns.Add("sysid_subject", System.Type.GetType("System.String"));
            dbTable.Columns.Add("is_team_teaching", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("is_irregular_modular", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("is_fixed_amount", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));
            dbTable.Columns.Add("subject_code", System.Type.GetType("System.String"));
            dbTable.Columns.Add("descriptive_title", System.Type.GetType("System.String"));
            dbTable.Columns.Add("subject_lecture_units", System.Type.GetType("System.Byte"));
            dbTable.Columns.Add("subject_lab_units", System.Type.GetType("System.Byte"));
            dbTable.Columns.Add("subject_no_hours", System.Type.GetType("System.String"));
            dbTable.Columns.Add("department_name", System.Type.GetType("System.String"));
            dbTable.Columns.Add("is_semestral", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("group_no", System.Type.GetType("System.Byte"));
            dbTable.Columns.Add("load_id", System.Type.GetType("System.Int64"));
            dbTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));
            dbTable.Columns.Add("load_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("deload_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("load_lecture_units", System.Type.GetType("System.Byte"));
            dbTable.Columns.Add("load_lab_units", System.Type.GetType("System.Byte"));
            dbTable.Columns.Add("load_no_hours", System.Type.GetType("System.String"));

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDEnrolmentLevelListSubjectScheduleStudentLoad";

                    sqlComm.Parameters.Add("@sysid_enrolmentlevel_list", SqlDbType.NVarChar).Value = enrolmentLevelSysIdList;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                DataRow newRow = dbTable.NewRow();

                                newRow["sysid_schedule"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_schedule", "");
                                newRow["sysid_subject"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_subject", "");
                                newRow["is_team_teaching"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_team_teaching", false);
                                newRow["is_irregular_modular"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_irregular_modular", false);
                                newRow["is_fixed_amount"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_fixed_amount", false);
                                newRow["amount"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "amount", Decimal.Parse("0"));
                                newRow["subject_code"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "subject_code", "");
                                newRow["descriptive_title"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "descriptive_title", "");
                                newRow["subject_lecture_units"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "subject_lecture_units", Byte.Parse("0"));
                                newRow["subject_lab_units"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "subject_lab_units", Byte.Parse("0"));
                                newRow["subject_no_hours"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "subject_no_hours", "00:00");
                                newRow["department_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "department_name", "");
                                newRow["is_semestral"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_semestral", false);
                                newRow["group_no"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "group_no", Byte.Parse("0"));
                                newRow["load_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "load_id", Int64.Parse("0"));
                                newRow["sysid_enrolmentlevel"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_enrolmentlevel", "");
                                newRow["load_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "load_date",
                                    DateTime.Parse(serverDateTime)).ToString();
                                newRow["deload_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "deload_date",
                                    DateTime.Parse(serverDateTime)).ToString();
                                newRow["load_lecture_units"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "load_lecture_units", Byte.Parse("0"));
                                newRow["load_lab_units"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "load_lab_units", Byte.Parse("0"));
                                newRow["load_no_hours"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "load_no_hours", "00:00");

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

        //this procedure returns the subject schedule details by enrolment level list
        public DataTable SelectBySysIDEnrolmentLevelListScheduleDetailsStudentLoad(CommonExchange.SysAccess userInfo, String enrolmentLevelSysIdList)
        {
            DataTable dbTable = new DataTable("ScheduleDetailsForStudentLoadingEnrolmentLevelListTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDEnrolmentLevelListScheduleDetailsStudentLoad";

                    sqlComm.Parameters.Add("@sysid_enrolmentlevel_list", SqlDbType.NVarChar).Value = enrolmentLevelSysIdList;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                    {
                        sqlAdapter.SelectCommand = sqlComm;
                        sqlAdapter.Fill(dbTable);
                    }

                    dbTable.AcceptChanges();

                }
            }

            return dbTable;

        } //---------------------------------------------

        //this procedure returns the school fee details by student system id, fee level system id
        public DataTable SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoad(CommonExchange.SysAccess userInfo, String studentSysId, 
            String enrolmentLevelSysId, String feeLevelSysId, String semesterSysId, Boolean isGraduateStudent, Boolean isInternational,
            Boolean isEnrolled, Boolean isMarkedDeleted, Boolean isPreviousCharge)
        {
            DataTable dbTable = new DataTable("SchoolFeeDetailsBySysIDStudentFeeLevelSemesterTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoad";

                    sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = studentSysId;

                    if (!String.IsNullOrEmpty(enrolmentLevelSysId))
                    {
                        sqlComm.Parameters.Add("@sysid_enrolmentlevel", SqlDbType.VarChar).Value = enrolmentLevelSysId;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@sysid_enrolmentlevel", SqlDbType.VarChar).Value = DBNull.Value;
                    }

                    sqlComm.Parameters.Add("@sysid_feelevel", SqlDbType.VarChar).Value = feeLevelSysId;
                    sqlComm.Parameters.Add("@sysid_semester", SqlDbType.VarChar).Value = semesterSysId;
                    sqlComm.Parameters.Add("@is_graduate_student", SqlDbType.Bit).Value = isGraduateStudent;
                    sqlComm.Parameters.Add("@is_international", SqlDbType.Bit).Value = isInternational;
                    sqlComm.Parameters.Add("@is_enrolled", SqlDbType.Bit).Value = isEnrolled;
                    sqlComm.Parameters.Add("@is_marked_deleted", SqlDbType.Bit).Value = isMarkedDeleted;
                    sqlComm.Parameters.Add("@is_previous_charge", SqlDbType.Bit).Value = isPreviousCharge;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                    {
                        sqlAdapter.SelectCommand = sqlComm;
                        sqlAdapter.Fill(dbTable);
                    }

                    dbTable.AcceptChanges();

                }
            }

            return dbTable;

        } //---------------------------------------------

        //this procedure returns the school fee details by student system id list and enrolment level system id list
        public DataTable SelectBySysIDStudentEnrolmentLevelListSchoolFeeDetailsStudentLoad(CommonExchange.SysAccess userInfo, String studentSysIdList, 
            String enrolmentLevelSysIdList)
        {
            DataTable dbTable = new DataTable("SchoolFeeDetailsBySysIDStudentEnrolmentLevelListTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDStudentEnrolmentLevelListSchoolFeeDetailsStudentLoad";

                    sqlComm.Parameters.Add("@sysid_student_list", SqlDbType.NVarChar).Value = studentSysIdList;
                    sqlComm.Parameters.Add("@sysid_enrolmentlevel_list", SqlDbType.NVarChar).Value = enrolmentLevelSysIdList;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                    {
                        sqlAdapter.SelectCommand = sqlComm;
                        sqlAdapter.Fill(dbTable);
                    }

                    dbTable.AcceptChanges();

                }
            }

            return dbTable;

        } //---------------------------------------------

        //this function gets the student enrolled by schedule system id table query
        public DataTable SelectBySysIDScheduleListStudentLoad(CommonExchange.SysAccess userInfo, String scheduleSysIdList)
        {
            DataTable dbTable = new DataTable("StudentLoadBySysIDScheduleListTable");
            dbTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
			dbTable.Columns.Add("student_id", System.Type.GetType("System.String"));
			dbTable.Columns.Add("card_number", System.Type.GetType("System.String"));
			dbTable.Columns.Add("scholarship", System.Type.GetType("System.String"));
			dbTable.Columns.Add("is_international", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("is_no_downpayment_required", System.Type.GetType("System.Boolean"));
			dbTable.Columns.Add("sysid_person", System.Type.GetType("System.String"));
			dbTable.Columns.Add("last_name", System.Type.GetType("System.String"));
			dbTable.Columns.Add("first_name", System.Type.GetType("System.String"));
			dbTable.Columns.Add("middle_name", System.Type.GetType("System.String"));
			dbTable.Columns.Add("present_address", System.Type.GetType("System.String"));
			dbTable.Columns.Add("present_phone_nos", System.Type.GetType("System.String"));
			dbTable.Columns.Add("home_address", System.Type.GetType("System.String"));
			dbTable.Columns.Add("home_phone_nos", System.Type.GetType("System.String"));

			dbTable.Columns.Add("life_status_code_code_reference_id", System.Type.GetType("System.String"));
			dbTable.Columns.Add("life_status_code_code_entity_id", System.Type.GetType("System.String"));
			dbTable.Columns.Add("life_status_code_reference_code", System.Type.GetType("System.String"));
            dbTable.Columns.Add("life_status_code_code_description", System.Type.GetType("System.String"));
            
            dbTable.Columns.Add("gender_code_code_reference_id", System.Type.GetType("System.String"));
            dbTable.Columns.Add("gender_code_code_entity_id", System.Type.GetType("System.String"));
            dbTable.Columns.Add("gender_code_reference_code", System.Type.GetType("System.String"));
            dbTable.Columns.Add("gender_code_code_description", System.Type.GetType("System.String"));
            dbTable.Columns.Add("gender_code_reference_flag", System.Type.GetType("System.Byte"));

			dbTable.Columns.Add("emer_last_name", System.Type.GetType("System.String"));
			dbTable.Columns.Add("emer_first_name", System.Type.GetType("System.String"));
			dbTable.Columns.Add("emer_middle_name", System.Type.GetType("System.String"));
			dbTable.Columns.Add("emer_present_address", System.Type.GetType("System.String"));
			dbTable.Columns.Add("emer_present_phone_nos", System.Type.GetType("System.String"));
			dbTable.Columns.Add("emer_home_address", System.Type.GetType("System.String"));
			dbTable.Columns.Add("emer_home_phone_nos", System.Type.GetType("System.String"));
			dbTable.Columns.Add("emer_relationship_description", System.Type.GetType("System.String"));

			dbTable.Columns.Add("course_id", System.Type.GetType("System.String"));
			dbTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));
			dbTable.Columns.Add("sysid_feelevel", System.Type.GetType("System.String"));
			dbTable.Columns.Add("sysid_semester", System.Type.GetType("System.String"));
			dbTable.Columns.Add("is_graduate_student", System.Type.GetType("System.Boolean"));
			dbTable.Columns.Add("level_section", System.Type.GetType("System.String"));
			dbTable.Columns.Add("sysid_schedule", System.Type.GetType("System.String"));
            dbTable.Columns.Add("load_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("deload_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("is_premature_deloaded", System.Type.GetType("System.Boolean"));
			dbTable.Columns.Add("enrolled_date", System.Type.GetType("System.String"));
			dbTable.Columns.Add("course_major_title", System.Type.GetType("System.String"));
			dbTable.Columns.Add("course_major_title_acronym", System.Type.GetType("System.String"));
			dbTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
			dbTable.Columns.Add("year_level_acronym", System.Type.GetType("System.String"));
			dbTable.Columns.Add("department_id", System.Type.GetType("System.String"));
			dbTable.Columns.Add("course_title", System.Type.GetType("System.String"));
			dbTable.Columns.Add("course_acronym", System.Type.GetType("System.String"));
			dbTable.Columns.Add("department_name", System.Type.GetType("System.String"));
			dbTable.Columns.Add("department_acronym", System.Type.GetType("System.String"));
			dbTable.Columns.Add("course_group_id", System.Type.GetType("System.String"));
			dbTable.Columns.Add("group_description", System.Type.GetType("System.String"));
			dbTable.Columns.Add("year_description", System.Type.GetType("System.String"));
            dbTable.Columns.Add("semester_description", System.Type.GetType("System.String"));

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDScheduleListStudentLoad";

                    if (String.IsNullOrEmpty(scheduleSysIdList))
                    {
                        sqlComm.Parameters.Add("@sysid_schedule_list", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@sysid_schedule_list", SqlDbType.NVarChar).Value = scheduleSysIdList;
                    }

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                DataRow newRow = dbTable.NewRow();

                                newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_student", String.Empty);
                                newRow["student_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "student_id", String.Empty);
                                newRow["card_number"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "card_number", String.Empty);
                                newRow["scholarship"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "scholarship", String.Empty);
                                newRow["is_international"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_international", false);
                                newRow["is_no_downpayment_required"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_no_downpayment_required", false);
                                newRow["sysid_person"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_person", String.Empty);
                                newRow["last_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "last_name", String.Empty);
                                newRow["first_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "first_name", String.Empty);
                                newRow["middle_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "middle_name", String.Empty);
                                newRow["present_address"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "present_address", String.Empty);
                                newRow["present_phone_nos"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "present_phone_nos", String.Empty);
                                newRow["home_address"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "home_address", String.Empty);
                                newRow["home_phone_nos"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "home_phone_nos", String.Empty);

                                newRow["life_status_code_code_reference_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, 
                                    "life_status_code_code_reference_id", String.Empty);
                                newRow["life_status_code_code_entity_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, 
                                    "life_status_code_code_entity_id", String.Empty);
                                newRow["life_status_code_reference_code"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, 
                                    "life_status_code_reference_code", String.Empty);
                                newRow["life_status_code_code_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, 
                                    "life_status_code_code_description", String.Empty);

                                newRow["gender_code_code_reference_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader,
                                    "gender_code_code_reference_id", String.Empty);
                                newRow["gender_code_code_entity_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader,
                                    "gender_code_code_entity_id", String.Empty);
                                newRow["gender_code_reference_code"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader,
                                    "gender_code_reference_code", String.Empty);
                                newRow["gender_code_code_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader,
                                    "gender_code_code_description", String.Empty);
                                newRow["gender_code_reference_flag"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader,
                                    "gender_code_reference_flag", Byte.Parse("0"));

                                newRow["emer_last_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "emer_last_name", String.Empty);
                                newRow["emer_first_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "emer_first_name", String.Empty);
                                newRow["emer_middle_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "emer_middle_name", String.Empty);
                                newRow["emer_present_address"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "emer_present_address", String.Empty);
                                newRow["emer_present_phone_nos"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "emer_present_phone_nos", String.Empty);
                                newRow["emer_home_address"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "emer_home_address", String.Empty);
                                newRow["emer_home_phone_nos"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "emer_home_phone_nos", String.Empty);
                                newRow["emer_relationship_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, 
                                    "emer_relationship_description", String.Empty);

                                newRow["course_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "course_id", String.Empty);
                                newRow["sysid_enrolmentlevel"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_enrolmentlevel", String.Empty);
                                newRow["sysid_feelevel"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_feelevel", String.Empty);
                                newRow["sysid_semester"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_semester", String.Empty);
                                newRow["is_graduate_student"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_graduate_student", false);
                                newRow["level_section"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "level_section", String.Empty);
                                newRow["sysid_schedule"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_schedule", String.Empty);
                                newRow["load_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "load_date", String.Empty);
                                newRow["deload_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "deload_date", String.Empty);
                                newRow["is_premature_deloaded"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_premature_deloaded", false);
                                newRow["enrolled_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "enrolled_date",
                                    DateTime.MinValue).ToString();
                                newRow["course_major_title"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, 
                                    "course_major_title", String.Empty);
                                newRow["course_major_title_acronym"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, 
                                    "course_major_title_acronym", String.Empty);
                                newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "year_level_description", String.Empty);
                                newRow["year_level_acronym"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "year_level_acronym", String.Empty);
                                newRow["department_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "department_id", String.Empty);
                                newRow["course_title"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "course_title", String.Empty);
                                newRow["course_acronym"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "course_acronym", String.Empty);
                                newRow["department_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "department_name", String.Empty);
                                newRow["department_acronym"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "department_acronym", String.Empty);
                                newRow["course_group_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "course_group_id", String.Empty);
                                newRow["group_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "group_description", String.Empty);
                                newRow["year_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "year_description", String.Empty);
                                newRow["semester_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "semester_description", String.Empty);

                                dbTable.Rows.Add(newRow);
                            }
                        }

                        sqlReader.Close();
                    }

                    dbTable.AcceptChanges();
                }
            }

            return dbTable;

        } //------------------------------

        //this procedure returns the student balance carried forward by student system id list and date ending
        public DataTable SelectBySysIDStudentListDateEndingBalanceCarriedForwardStudentLoad(CommonExchange.SysAccess userInfo, String studentSysIdList,
            String excludeEnrolmentLevelSysIdList, String dateEnding)
        {
            DataTable dbTable = new DataTable("BalanceCarriedForwardByStudentSysIdListDateEndingTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDStudentListDateEndingBalanceCarriedForwardStudentLoad";

                    if (String.IsNullOrEmpty(studentSysIdList))
                    {
                        sqlComm.Parameters.Add("@sysid_student_list", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@sysid_student_list", SqlDbType.NVarChar).Value = studentSysIdList;
                    }

                    if (String.IsNullOrEmpty(excludeEnrolmentLevelSysIdList))
                    {
                        sqlComm.Parameters.Add("@exclude_sysid_enrolmentlevel_list", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@exclude_sysid_enrolmentlevel_list", SqlDbType.NVarChar).Value = excludeEnrolmentLevelSysIdList;
                    }

                    sqlComm.Parameters.Add("@date_ending", SqlDbType.DateTime).Value = DateTime.Parse(dateEnding);

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                    {
                        sqlAdapter.SelectCommand = sqlComm;
                        sqlAdapter.Fill(dbTable);
                    }

                    dbTable.AcceptChanges();

                }
            }

            return dbTable;

        } //---------------------------------------------


        /// <summary>
        /// This function return the table of the student accounts receivable per fiscal year
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="studentSysIdList"></param>
        /// <param name="dateEnding"></param>
        /// <returns></returns>
        public DataTable SelectBySysIDStudentListDateEndingAccountReceivablePerFiscalYearStudentLoad(CommonExchange.SysAccess userInfo, String studentSysIdList,
            String dateEnding)
        {
            DataTable dbTable = new DataTable("SelectBySysIDStudentListDateEndingAccountReceivablePerFiscalYearTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDStudentListDateEndingAccountReceivablePerFiscalYearStudentLoad";

                    if (String.IsNullOrEmpty(studentSysIdList))
                    {
                        sqlComm.Parameters.Add("@sysid_student_list", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@sysid_student_list", SqlDbType.NVarChar).Value = studentSysIdList;
                    }

                    sqlComm.Parameters.Add("@date_ending", SqlDbType.DateTime).Value = DateTime.Parse(dateEnding);

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                    {
                        sqlAdapter.SelectCommand = sqlComm;
                        sqlAdapter.Fill(dbTable);
                    }

                    dbTable.AcceptChanges();

                }
            }

            return dbTable;

        } //---------------------------------------------

        /// <summary>
        /// This function returns the accounts receivable per term
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="studentSysIdList"></param>
        /// <param name="dateStart"></param>
        /// <param name="dateEnd"></param>
        /// <param name="cutOffDate"></param>
        /// <returns></returns>
        public DataTable SelectBySysIDStudentListDateStartEndCutOffDateAccountReceivablePerTermStudentLoad(CommonExchange.SysAccess userInfo, 
            String studentSysIdList, String dateStart, String dateEnd, String cutOffDate)
        {
            DataTable dbTable = new DataTable("SelectBySysIDStudentListCutOffDateAccountReceivablePerTermTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDStudentListDateStartEndCutOffDateAccountReceivablePerTermStudentLoad";

                    if (String.IsNullOrEmpty(studentSysIdList))
                    {
                        sqlComm.Parameters.Add("@sysid_student_list", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@sysid_student_list", SqlDbType.NVarChar).Value = studentSysIdList;
                    }

                    sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = DateTime.Parse(dateStart);
                    sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = DateTime.Parse(dateEnd);
                    sqlComm.Parameters.Add("@cut_off_date", SqlDbType.DateTime).Value = DateTime.Parse(cutOffDate);

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                    {
                        sqlAdapter.SelectCommand = sqlComm;
                        sqlAdapter.Fill(dbTable);
                    }

                    dbTable.AcceptChanges();

                }
            }

            return dbTable;

        } //---------------------------------------------

        /// <summary>
        /// This function returns the student running balance
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="studentSysIdList"></param>
        /// <returns></returns>
        public DataTable SelectBySysIDStudentListForStudentRunningBalanceStudentLoad(CommonExchange.SysAccess userInfo, String studentSysIdList)
        {
            DataTable dbTable = new DataTable("SelectBySysIDStudentListForStudentRunningBalanceTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDStudentListForStudentRunningBalanceStudentLoad";

                    if (String.IsNullOrEmpty(studentSysIdList))
                    {
                        sqlComm.Parameters.Add("@sysid_student_list", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@sysid_student_list", SqlDbType.NVarChar).Value = studentSysIdList;
                    }

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                    {
                        sqlAdapter.SelectCommand = sqlComm;
                        sqlAdapter.Fill(dbTable);
                    }

                    dbTable.AcceptChanges();

                }
            }

            return dbTable;

        } //---------------------------------------------

        //this function is used to get data tables stored in one dataset used for student loading manager
        public DataSet GetDataSetForStudentLoad(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            DataSet dbSet = new DataSet();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                //get the school fee information table
                dbSet.Tables.Add(ProcStatic.GetSchoolFeeInformationTable(auth.Connection, userInfo.UserId, serverDateTime));
                //--------------------------------

                //gets the semester information table
                dbSet.Tables.Add(ProcStatic.GetSemesterInformationTable(auth.Connection, userInfo.UserId, serverDateTime));
                //--------------------------------   

                //get the course information table
                dbSet.Tables.Add(ProcStatic.GetCourseInformationTable(auth.Connection, userInfo.UserId));
                //------------------------------

                //get the year level table
                dbSet.Tables.Add(ProcStatic.GetYearLevelInformationTable(auth.Connection, userInfo.UserId));
                //--------------------------------

                //get the week day table
                dbSet.Tables.Add(ProcStatic.GetWeekDayTable(auth.Connection, userInfo.UserId));
                //--------------------------------

                //gets the week time table
                dbSet.Tables.Add(ProcStatic.GetWeekTimeTable(auth.Connection, userInfo.UserId));
                //----------------------------------------

                //gets the school fee category table
                dbSet.Tables.Add(ProcStatic.GetSchoolFeeCategoryTable(auth.Connection, userInfo.UserId));
                //-------------------------------

                //gets the course group table
                dbSet.Tables.Add(ProcStatic.GetCourseGroupTable(auth.Connection, userInfo.UserId));
                //-------------------------------
            }

            return dbSet;
        } //----------------------------------

        #endregion
    }
}
