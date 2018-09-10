using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteServerLib
{
    public class RemSrvSubjectSchedulingManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvSubjectSchedulingManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new schedule information
        public void InsertScheduleInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.ScheduleInformation scheduleInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                scheduleInfo.ScheduleSysId = PrimaryKeys.GetNewScheduleInformationSystemID(userInfo, auth.Connection);

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertScheduleInformation";

                    sqlComm.Parameters.Add("@sysid_schedule", SqlDbType.VarChar).Value = scheduleInfo.ScheduleSysId;
                    sqlComm.Parameters.Add("@sysid_subject", SqlDbType.VarChar).Value = scheduleInfo.SubjectInfo.SubjectSysId;                    

                    if (!scheduleInfo.SubjectInfo.CourseGroupInfo.IsSemestral)
                    {
                        sqlComm.Parameters.Add("@year_id", SqlDbType.VarChar).Value = scheduleInfo.SchoolYearInfo.YearId;
                        sqlComm.Parameters.Add("@sysid_semester", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@year_id", SqlDbType.VarChar).Value = DBNull.Value;
                        sqlComm.Parameters.Add("@sysid_semester", SqlDbType.VarChar).Value = scheduleInfo.SemesterInfo.SemesterSysId;
                    }

                    sqlComm.Parameters.Add("@is_team_teaching", SqlDbType.Bit).Value = scheduleInfo.IsTeamTeaching;
                    sqlComm.Parameters.Add("@is_irregular_modular", SqlDbType.Bit).Value = scheduleInfo.IsIrregularModular;
                    sqlComm.Parameters.Add("@is_fixed_amount", SqlDbType.Bit).Value = scheduleInfo.IsFixedAmount;
                    sqlComm.Parameters.Add("@amount", SqlDbType.Decimal).Value = scheduleInfo.Amount;
                    sqlComm.Parameters.Add("@additional_slots", SqlDbType.SmallInt).Value = scheduleInfo.AdditionalSlots;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
                
            }

        } //-------------------------

        //this procedure inserts a updates schedule information
        public void UpdateScheduleInformation(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformation scheduleInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateScheduleInformation";

                    sqlComm.Parameters.Add("@sysid_schedule", SqlDbType.VarChar).Value = scheduleInfo.ScheduleSysId;
                    sqlComm.Parameters.Add("@is_team_teaching", SqlDbType.Bit).Value = scheduleInfo.IsTeamTeaching;
                    sqlComm.Parameters.Add("@is_irregular_modular", SqlDbType.Bit).Value = scheduleInfo.IsIrregularModular;
                    sqlComm.Parameters.Add("@is_fixed_amount", SqlDbType.Bit).Value = scheduleInfo.IsFixedAmount;
                    sqlComm.Parameters.Add("@amount", SqlDbType.Decimal).Value = scheduleInfo.Amount;
                    sqlComm.Parameters.Add("@additional_slots", SqlDbType.SmallInt).Value = scheduleInfo.AdditionalSlots;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }               
                
            }
        } //----------------------------------

        //this procedure inserts a deletes schedule information
        public void DeleteScheduleInformation(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformation scheduleInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.DeleteScheduleInformation";

                    sqlComm.Parameters.Add("@sysid_schedule", SqlDbType.VarChar).Value = scheduleInfo.ScheduleSysId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //------------------------------------------

        //this procedure inserts a new schedule information details
        public void InsertScheduleInformationDetails(CommonExchange.SysAccess userInfo, ref CommonExchange.ScheduleInformationDetails scheduleDetailsInfo,
            DataTable scheduleTable)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))          
            {
                scheduleDetailsInfo.ScheduleDetailsSysId = PrimaryKeys.GetNewScheduleInformationDetailsSystemID(userInfo, auth.Connection);

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertScheduleInformationDetails";

                    sqlComm.Parameters.Add("@sysid_scheddetails", SqlDbType.VarChar).Value = scheduleDetailsInfo.ScheduleDetailsSysId;
                    sqlComm.Parameters.Add("@sysid_schedule", SqlDbType.VarChar).Value = scheduleDetailsInfo.ScheduleInfo.ScheduleSysId;

                    if (scheduleDetailsInfo.IsClassroom)
                    {
                        sqlComm.Parameters.Add("@sysid_classroom", SqlDbType.VarChar).Value = scheduleDetailsInfo.ClassroomInfo.ClassroomSysId;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@sysid_classroom", SqlDbType.VarChar).Value = DBNull.Value;
                    }

                    sqlComm.Parameters.Add("@field_room", SqlDbType.VarChar).Value = scheduleDetailsInfo.FieldRoom;

                    if (!String.IsNullOrEmpty(scheduleDetailsInfo.ManualSchedule))
                    {
                        sqlComm.Parameters.Add("@manual_schedule", SqlDbType.VarChar).Value = scheduleDetailsInfo.ManualSchedule;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@manual_schedule", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    
                    sqlComm.Parameters.Add("@is_classroom", SqlDbType.Bit).Value = scheduleDetailsInfo.IsClassroom;
                    sqlComm.Parameters.Add("@lecture_units", SqlDbType.Float).Value = scheduleDetailsInfo.LectureUnits;
                    sqlComm.Parameters.Add("@lab_units", SqlDbType.Float).Value = scheduleDetailsInfo.LabUnits;
                    sqlComm.Parameters.Add("@no_hours", SqlDbType.VarChar).Value = scheduleDetailsInfo.NoHours;

                    if (!String.IsNullOrEmpty(scheduleDetailsInfo.Section))
                    {
                        sqlComm.Parameters.Add("@section", SqlDbType.VarChar).Value = scheduleDetailsInfo.Section;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@section", SqlDbType.VarChar).Value = DBNull.Value;
                    }                    

                    if (!String.IsNullOrEmpty(scheduleDetailsInfo.DayTime))
                    {
                        sqlComm.Parameters.Add("@day_time", SqlDbType.VarChar).Value = scheduleDetailsInfo.DayTime;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@day_time", SqlDbType.VarChar).Value = DBNull.Value;
                    }

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }

                if (scheduleTable != null)
                {
                    this.InsertDeleteSubjectSchedule(userInfo, auth.Connection, scheduleTable, scheduleDetailsInfo.ScheduleDetailsSysId);
                }

            }
        } //--------------------------------------------------

        //this procedure updates a schedule information details
        public void UpdateScheduleInformationDetails(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformationDetails scheduleDetailsInfo,
            DataTable scheduleTable)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateScheduleInformationDetails";

                    sqlComm.Parameters.Add("@sysid_scheddetails", SqlDbType.VarChar).Value = scheduleDetailsInfo.ScheduleDetailsSysId;

                    if (scheduleDetailsInfo.IsClassroom)
                    {
                        sqlComm.Parameters.Add("@sysid_classroom", SqlDbType.VarChar).Value = scheduleDetailsInfo.ClassroomInfo.ClassroomSysId;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@sysid_classroom", SqlDbType.VarChar).Value = DBNull.Value;
                    }

                    sqlComm.Parameters.Add("@field_room", SqlDbType.VarChar).Value = scheduleDetailsInfo.FieldRoom;

                    if (!String.IsNullOrEmpty(scheduleDetailsInfo.ManualSchedule))
                    {
                        sqlComm.Parameters.Add("@manual_schedule", SqlDbType.VarChar).Value = scheduleDetailsInfo.ManualSchedule;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@manual_schedule", SqlDbType.VarChar).Value = DBNull.Value;
                    }

                    sqlComm.Parameters.Add("@is_classroom", SqlDbType.Bit).Value = scheduleDetailsInfo.IsClassroom;
                    sqlComm.Parameters.Add("@lecture_units", SqlDbType.Float).Value = scheduleDetailsInfo.LectureUnits;
                    sqlComm.Parameters.Add("@lab_units", SqlDbType.Float).Value = scheduleDetailsInfo.LabUnits;
                    sqlComm.Parameters.Add("@no_hours", SqlDbType.VarChar).Value = scheduleDetailsInfo.NoHours;

                    if (!String.IsNullOrEmpty(scheduleDetailsInfo.Section))
                    {
                        sqlComm.Parameters.Add("@section", SqlDbType.VarChar).Value = scheduleDetailsInfo.Section;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@section", SqlDbType.VarChar).Value = DBNull.Value;
                    }

                    if (!String.IsNullOrEmpty(scheduleDetailsInfo.DayTime))
                    {
                        sqlComm.Parameters.Add("@day_time", SqlDbType.VarChar).Value = scheduleDetailsInfo.DayTime;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@day_time", SqlDbType.VarChar).Value = DBNull.Value;
                    }

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }

                if (scheduleTable != null)
                {
                    this.InsertDeleteSubjectSchedule(userInfo, auth.Connection, scheduleTable, scheduleDetailsInfo.ScheduleDetailsSysId);
                }

            }
        } //------------------------------------------

        //this procedure deletes a schedule information details
        public void DeleteScheduleInformationDetails(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformationDetails scheduleDetailsInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.DeleteScheduleInformationDetails";

                    sqlComm.Parameters.Add("@sysid_scheddetails", SqlDbType.VarChar).Value = scheduleDetailsInfo.ScheduleDetailsSysId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }              

            }
        } //------------------------------------

        //this procedure inserts and delete a subject schedule
        private void InsertDeleteSubjectSchedule(CommonExchange.SysAccess userInfo, SqlConnection sqlConn, DataTable scheduleTable,
                                                    String scheduleDetailsSysId)
        {
            using (SqlCommand insertComm = new SqlCommand())
            {
                insertComm.Connection = sqlConn;
                insertComm.CommandType = CommandType.StoredProcedure;
                insertComm.CommandText = "ums.InsertSubjectSchedule";

                insertComm.Parameters.Add("@sysid_scheddetails", SqlDbType.VarChar).Value = scheduleDetailsSysId;
                insertComm.Parameters.Add("@week_id", SqlDbType.TinyInt).SourceColumn = "week_id";
                insertComm.Parameters.Add("@time_id", SqlDbType.TinyInt).SourceColumn = "time_id";

                insertComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                insertComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                using (SqlCommand deleteComm = new SqlCommand())
                {
                    deleteComm.Connection = sqlConn;
                    deleteComm.CommandType = CommandType.StoredProcedure;
                    deleteComm.CommandText = "ums.DeleteSubjectSchedule";

                    deleteComm.Parameters.Add("@sysid_scheddetails", SqlDbType.VarChar).Value = scheduleDetailsSysId;
                    deleteComm.Parameters.Add("@schedule_id", SqlDbType.BigInt).SourceColumn = "schedule_id";

                    deleteComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    deleteComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                    {
                        sqlAdapter.InsertCommand = insertComm;
                        sqlAdapter.DeleteCommand = deleteComm;

                        sqlAdapter.Update(scheduleTable);
                    }
                }
            }

        } //---------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function is used to get the schedule information by date start and date end
        public DataTable SelectByDateStartEndScheduleInformation(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd, Boolean isMarkedDeleted)
        {
            DataTable dbTable = new DataTable("ScheduleInformationByDateStartEndTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectByDateStartEndScheduleInformation";

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

        } //-----------------------------------

        //this function is used to get the schedule information details by date start and date end
        public DataTable SelectByDateStartEndScheduleInformationDetails(CommonExchange.SysAccess userInfo, String queryString,
            String dateStart, String dateEnd, Boolean isMarkedDeleted)
        {
            DataTable dbTable = new DataTable("ScheduleInformationDetailsByDateStartEndTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;                  
                    sqlComm.CommandText = "ums.SelectByDateStartEndScheduleInformationDetails";

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
        } //-------------------------------------------------

        //this function is used to get the schedule information details by schedule details system id
        public DataTable SelectBySysIDScheduleScheduleInformationDetails(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformation scheduleInfo)
        {
            DataTable dbTable = new DataTable("ScheduleInformationDetailsBySysIdScheduleTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDScheduleScheduleInformationDetails";

                    sqlComm.Parameters.Add("@sysid_schedule", SqlDbType.VarChar).Value = scheduleInfo.ScheduleSysId;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                    {
                        sqlAdapter.SelectCommand = sqlComm;
                        sqlAdapter.Fill(dbTable);
                    }
                }
            }

            return dbTable;
        } //--------------------------------------------------        

        //this function is used to get the subject schedule by classroom code
        public DataTable SelectByClassroomCodeSubjectSchedule(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd,
            String classroomSysId, String scheduleDetailsSysId)
        {
            DataTable dbTable = new DataTable("SubjectScheduleByClassroomCodeTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectByClassroomCodeSubjectSchedule";

                    sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = DateTime.Parse(dateStart);
                    sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = DateTime.Parse(dateEnd);
                    sqlComm.Parameters.Add("@sysid_classroom", SqlDbType.VarChar).Value = classroomSysId;
                    sqlComm.Parameters.Add("@sysid_scheddetails", SqlDbType.VarChar).Value = scheduleDetailsSysId;

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

        //this function is used to get the subject schedule by schedule details system id list
        public DataTable SelectBySysIDScheduleDetailsListSubjectSchedule(CommonExchange.SysAccess userInfo, String scheduleDetailsSysIdList)
        {
            DataTable dbTable = new DataTable("SubjectScheduleBySysIDScheduleDetailsListTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDScheduleDetailsListSubjectSchedule";

                    sqlComm.Parameters.Add("@sysid_scheddetails_list", SqlDbType.NVarChar).Value = scheduleDetailsSysIdList;

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
        

        //this function is used to get data tables stored in one dataset used for schedule information
        public DataSet GetDataSetForScheduleInformation(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            DataSet dbSet = new DataSet();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
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

                //gets the classroom information table
                dbSet.Tables.Add(ProcStatic.GetClassroomInformationTable(auth.Connection, userInfo.UserId));
                //------------------------------------
            }

            return dbSet;
        } //----------------------------------
        #endregion
    }
}
