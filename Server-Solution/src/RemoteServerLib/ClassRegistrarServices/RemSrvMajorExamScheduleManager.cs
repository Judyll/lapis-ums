using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteServerLib
{
    public class RemSrvMajorExamScheduleManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvMajorExamScheduleManager() { }

        void IDisposable.Dispose() { }

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new major exam schedule
        public void InsertMajorExamSchedule(CommonExchange.SysAccess userInfo, CommonExchange.MajorExamSchedule examSchedule)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertMajorExamSchedule";

                    sqlComm.Parameters.Add("@year_id", SqlDbType.VarChar).Value = examSchedule.YearId;
                    sqlComm.Parameters.Add("@sysid_semester", SqlDbType.VarChar).Value = examSchedule.SemesterSysId;
                    sqlComm.Parameters.Add("@exam_information_id", SqlDbType.VarChar).Value = examSchedule.ExamInformationId;
                    sqlComm.Parameters.Add("@exam_date", SqlDbType.DateTime).Value = DateTime.Parse(examSchedule.ExamDate);

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------

        //this procedure updates a major exam schedule
        public void UpdateMajorExamSchedule(CommonExchange.SysAccess userInfo, CommonExchange.MajorExamSchedule examSchedule)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateMajorExamSchedule";

                    sqlComm.Parameters.Add("@major_exam_id", SqlDbType.BigInt).Value = examSchedule.MajorExamId;
                    sqlComm.Parameters.Add("@year_id", SqlDbType.VarChar).Value = examSchedule.YearId;
                    sqlComm.Parameters.Add("@sysid_semester", SqlDbType.VarChar).Value = examSchedule.SemesterSysId;
                    sqlComm.Parameters.Add("@exam_information_id", SqlDbType.VarChar).Value = examSchedule.ExamInformationId;
                    sqlComm.Parameters.Add("@exam_date", SqlDbType.DateTime).Value = DateTime.Parse(examSchedule.ExamDate);

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------

        //this procedure deletes a major exam schedule
        public void DeleteMajorExamSchedule(CommonExchange.SysAccess userInfo, CommonExchange.MajorExamSchedule examSchedule)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.DeleteMajorExamSchedule";

                    sqlComm.Parameters.Add("@major_exam_id", SqlDbType.BigInt).Value = examSchedule.MajorExamId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function gets the major exam table query
        public DataTable SelectMajorExamSchedule(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd,
            String courseGroupIdList, String examInformationIdList, String serverDateTime)
        {
            DataTable dbTable = new DataTable("MajorExamScheduleTable");
            dbTable.Columns.Add("major_exam_id", System.Type.GetType("System.Int64"));
            dbTable.Columns.Add("year_id", System.Type.GetType("System.String"));
            dbTable.Columns.Add("sysid_semester", System.Type.GetType("System.String"));
			dbTable.Columns.Add("exam_information_id", System.Type.GetType("System.String"));
			dbTable.Columns.Add("exam_date", System.Type.GetType("System.String"));
			dbTable.Columns.Add("exam_description", System.Type.GetType("System.String"));
            dbTable.Columns.Add("is_clearance_included", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("course_group_id", System.Type.GetType("System.String"));
			dbTable.Columns.Add("group_description", System.Type.GetType("System.String"));
            dbTable.Columns.Add("group_no", System.Type.GetType("System.Byte"));
            dbTable.Columns.Add("is_semestral", System.Type.GetType("System.Boolean"));

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectMajorExamSchedule";

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

                    if (String.IsNullOrEmpty(courseGroupIdList))
                    {
                        sqlComm.Parameters.Add("@course_group_id_list", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@course_group_id_list", SqlDbType.NVarChar).Value = courseGroupIdList;
                    }

                    if (String.IsNullOrEmpty(examInformationIdList))
                    {
                        sqlComm.Parameters.Add("@exam_information_id_list", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@exam_information_id_list", SqlDbType.NVarChar).Value = examInformationIdList;
                    }

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                DataRow newRow = dbTable.NewRow();

                                newRow["major_exam_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "major_exam_id", Int64.Parse("0"));
                                newRow["year_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "year_id", "");
                                newRow["sysid_semester"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_semester", "");
                                newRow["exam_information_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "exam_information_id", "");
                                newRow["exam_date"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "exam_date",
                                    DateTime.Parse(serverDateTime)).ToString();
                                newRow["exam_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "exam_description", "");
                                newRow["is_clearance_included"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_clearance_included", false);
                                newRow["course_group_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "course_group_id", "");
                                newRow["group_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "group_description", "");
                                newRow["group_no"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "group_no", Byte.Parse("0"));
                                newRow["is_semestral"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_semestral", false);

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

        //this function is used to determine if the exam date information exists
        public Boolean IsExistsYearSemesterIDExamDateInformationIDExamSchedule(CommonExchange.SysAccess userInfo, 
            CommonExchange.MajorExamSchedule examSchedule)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsExistsYearSemesterIDExamDateInformationIDExamSchedule";

                    sqlComm.Parameters.Add("@major_exam_id", SqlDbType.BigInt).Value = examSchedule.MajorExamId;
                    sqlComm.Parameters.Add("@year_id", SqlDbType.VarChar).Value = examSchedule.YearId;
                    sqlComm.Parameters.Add("@sysid_semester", SqlDbType.VarChar).Value = examSchedule.SemesterSysId;
                    sqlComm.Parameters.Add("@exam_information_id", SqlDbType.VarChar).Value = examSchedule.ExamInformationId;
                    sqlComm.Parameters.Add("@exam_date", SqlDbType.DateTime).Value = DateTime.Parse(examSchedule.ExamDate);

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;
        } //-----------------------------    

        //this function is used to get data tables stored in one dataset used for major exam schedule manager
        public DataSet GetDataSetForMajorExamSchedule(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            DataSet dbSet = new DataSet();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                //get the school year table
                dbSet.Tables.Add(ProcStatic.GetSchoolFeeInformationTable(auth.Connection, userInfo.UserId, serverDateTime));
                //--------------------------------

                //get the school semester table
                dbSet.Tables.Add(ProcStatic.GetSemesterInformationTable(auth.Connection, userInfo.UserId, serverDateTime));
                //--------------------------------

                //get the major exam information table
                dbSet.Tables.Add(ProcStatic.GetMajorExamInformationTable(auth.Connection, userInfo.UserId));
                //------------------------------

                //get the course group table
                dbSet.Tables.Add(ProcStatic.GetCourseGroupTable(auth.Connection, userInfo.UserId));
                //------------------------------

            }

            return dbSet;
        } //----------------------------------

        #endregion
    }
}
