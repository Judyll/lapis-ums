using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteServerLib
{
    public class RemSrvTeacherLoadingManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvTeacherLoadingManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new teacher load
        public void InsertDeleteTeacherLoad(CommonExchange.SysAccess userInfo, DataTable teacherLoadTable)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand insertComm = new SqlCommand())
                {
                    insertComm.Connection = auth.Connection;
                    insertComm.CommandType = CommandType.StoredProcedure;
                    insertComm.CommandText = "ums.InsertTeacherLoad";

                    insertComm.Parameters.Add("@sysid_scheddetails", SqlDbType.VarChar).SourceColumn = "sysid_scheddetails";
                    insertComm.Parameters.Add("@sysid_auxdetails", SqlDbType.VarChar).SourceColumn = "sysid_auxdetails";
                    insertComm.Parameters.Add("@sysid_employee", SqlDbType.VarChar).SourceColumn = "sysid_employee";
                    insertComm.Parameters.Add("@is_auxiliary", SqlDbType.Bit).SourceColumn = "is_auxiliary";

                    insertComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    insertComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlCommand deleteComm = new SqlCommand())
                    {
                        deleteComm.Connection = auth.Connection;
                        deleteComm.CommandType = CommandType.StoredProcedure;
                        deleteComm.CommandText = "ums.DeleteTeacherLoad";

                        deleteComm.Parameters.Add("@load_id", SqlDbType.BigInt).SourceColumn = "load_id";

                        deleteComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                        deleteComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                        using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                        {
                            sqlAdapter.InsertCommand = insertComm;
                            sqlAdapter.DeleteCommand = deleteComm;

                            sqlAdapter.Update(teacherLoadTable);
                        }
                    }
                }
            }
        } //----------------------------------
        
        #endregion

        #region Programmer-Defined Function Procedures

        //this function is used to get the subject details system id that has conflict
        public DataTable SelectByScheduleDetailsListConflictsWithAnotherScheduleTeacherLoad(CommonExchange.SysAccess userInfo, String scheduleDetailsSysIdList,
            String employeeSysId)
        {
            DataTable dbTable = new DataTable("SubjectScheduleWithConflictsBySysIDScheduleDetailsListTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectByScheduleDetailsListConflictsWithAnotherScheduleTeacherLoad";

                    sqlComm.Parameters.Add("@sysid_scheddetails_list", SqlDbType.NVarChar).Value = scheduleDetailsSysIdList;
                    sqlComm.Parameters.Add("@sysid_employee", SqlDbType.VarChar).Value = employeeSysId;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                    {
                        sqlAdapter.SelectCommand = sqlComm;
                        sqlAdapter.Fill(dbTable);
                    }
                }
            }

            return dbTable;
        } //--------------------------------
   
        //this procedure returns the selected teacher load by date start and end for teacher loading
        public DataTable SelectByDateStartEndForTeacherLoadingTeacherLoad(CommonExchange.SysAccess userInfo, String dateStart, 
            String dateEnd, String serverDateTime)
        {
            DataTable dbTable = new DataTable("TeacherLoadForTeacherLoadingByDateStartEndTable");
            dbTable.Columns.Add("sysid_scheddetails_auxdetails", System.Type.GetType("System.String"));
            dbTable.Columns.Add("sysid_classroom", System.Type.GetType("System.String"));
            dbTable.Columns.Add("field_room", System.Type.GetType("System.String"));
            dbTable.Columns.Add("manual_schedule", System.Type.GetType("System.String"));
			dbTable.Columns.Add("is_classroom", System.Type.GetType("System.Boolean"));
			dbTable.Columns.Add("section", System.Type.GetType("System.String"));
            dbTable.Columns.Add("sysid_schedule_auxserviceschedule", System.Type.GetType("System.String"));
			dbTable.Columns.Add("is_team_teaching", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("is_irregular_modular", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("is_fixed_amount", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));
			dbTable.Columns.Add("year_semester_id", System.Type.GetType("System.String"));
            dbTable.Columns.Add("sysid_subject_auxservice", System.Type.GetType("System.String"));
			dbTable.Columns.Add("department_id", System.Type.GetType("System.String"));
            dbTable.Columns.Add("subject_service_code", System.Type.GetType("System.String"));
			dbTable.Columns.Add("descriptive_title", System.Type.GetType("System.String"));
            dbTable.Columns.Add("lecture_units_schedule", System.Type.GetType("System.Byte"));
            dbTable.Columns.Add("lab_units_schedule", System.Type.GetType("System.Byte"));
            dbTable.Columns.Add("no_hours_schedule", System.Type.GetType("System.String"));
            dbTable.Columns.Add("subject_auxiliary_department_name", System.Type.GetType("System.String"));
			dbTable.Columns.Add("is_semestral", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("group_no", System.Type.GetType("System.Byte"));
            dbTable.Columns.Add("classroom_code", System.Type.GetType("System.String"));
            dbTable.Columns.Add("load_id", System.Type.GetType("System.Int64"));
            dbTable.Columns.Add("sysid_employee", System.Type.GetType("System.String"));
            dbTable.Columns.Add("load_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("deload_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("lecture_units", System.Type.GetType("System.Byte"));
            dbTable.Columns.Add("lab_units", System.Type.GetType("System.Byte"));
            dbTable.Columns.Add("no_hours", System.Type.GetType("System.String"));
            dbTable.Columns.Add("is_auxiliary", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("is_premature_deloaded", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("day_time", System.Type.GetType("System.String"));

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectByDateStartEndForTeacherLoadingTeacherLoad";

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

                                newRow["sysid_scheddetails_auxdetails"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, 
                                    "sysid_scheddetails_auxdetails", String.Empty);
                                newRow["sysid_classroom"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_classroom", String.Empty);
                                newRow["field_room"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "field_room", String.Empty);
                                newRow["manual_schedule"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "manual_schedule", String.Empty);
                                newRow["is_classroom"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_classroom", false);
                                newRow["section"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "section", String.Empty);
                                newRow["sysid_schedule_auxserviceschedule"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, 
                                    "sysid_schedule_auxserviceschedule", String.Empty);
                                newRow["is_team_teaching"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_team_teaching", false);
                                newRow["is_irregular_modular"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_irregular_modular", false);
                                newRow["is_fixed_amount"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_fixed_amount", false);
                                newRow["amount"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "amount", Decimal.Parse("0"));
                                newRow["year_semester_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "year_semester_id", String.Empty);
                                newRow["sysid_subject_auxservice"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_subject_auxservice", 
                                    String.Empty);
                                newRow["department_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "department_id", String.Empty);
                                newRow["subject_service_code"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "subject_service_code", String.Empty);
                                newRow["descriptive_title"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "descriptive_title", String.Empty);
                                newRow["lecture_units_schedule"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "lecture_units_schedule", 
                                    Byte.Parse("0"));
                                newRow["lab_units_schedule"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "lab_units_schedule", Byte.Parse("0"));
                                newRow["no_hours_schedule"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "no_hours_schedule", String.Empty);
                                newRow["subject_auxiliary_department_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, 
                                    "subject_auxiliary_department_name", String.Empty);
                                newRow["is_semestral"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_semestral", false);
                                newRow["group_no"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "group_no", Byte.Parse("0"));
                                newRow["classroom_code"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "classroom_code", String.Empty);
                                newRow["load_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "load_id", Int64.Parse("0"));
                                newRow["sysid_employee"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_employee", String.Empty);
                                newRow["load_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "load_date", 
                                    DateTime.Parse(serverDateTime)).ToString();
                                newRow["deload_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "deload_date",
                                    DateTime.Parse(serverDateTime)).ToString();
                                newRow["lecture_units"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "lecture_units", Byte.Parse("0"));
                                newRow["lab_units"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "lab_units", Byte.Parse("0"));
                                newRow["no_hours"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "no_hours", "00:00");
                                newRow["is_auxiliary"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_auxiliary", false);
                                newRow["is_premature_deloaded"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_premature_deloaded", false);
                                newRow["day_time"] = String.Empty;

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

        //this function is used to get data tables stored in one dataset used for schedule information
        public DataSet GetDataSetForTeacherLoad(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            DataSet dbSet = new DataSet();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                //gets the employee personal and salary information table
                dbSet.Tables.Add(ProcStatic.GetEmployeeInformationTable(auth.Connection, userInfo.UserId));
                //-----------------------

                //gets the school fee information table
                dbSet.Tables.Add(ProcStatic.GetSchoolFeeInformationTable(auth.Connection, userInfo.UserId, serverDateTime));
                //------------------------------------

                //gets the semester information table
                dbSet.Tables.Add(ProcStatic.GetSemesterInformationTable(auth.Connection, userInfo.UserId, serverDateTime));
                //--------------------------------   

                //get the week day table
                dbSet.Tables.Add(ProcStatic.GetWeekDayTable(auth.Connection, userInfo.UserId));
                //--------------------------------

                //gets the week time table
                dbSet.Tables.Add(ProcStatic.GetWeekTimeTable(auth.Connection, userInfo.UserId));
                //----------------------------------------                
            }

            return dbSet;
        } //---------------------------------

        #endregion

    }
}
