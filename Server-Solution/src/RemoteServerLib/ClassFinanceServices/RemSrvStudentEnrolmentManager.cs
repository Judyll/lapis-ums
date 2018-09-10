using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteServerLib
{
    public class RemSrvStudentEnrolmentManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvStudentEnrolmentManager() { }

        void IDisposable.Dispose() { }

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new student enrolment level
        public void InsertStudentEnrolmentLevel(CommonExchange.SysAccess userInfo, ref CommonExchange.StudentEnrolmentLevel enrolmentLevelInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                enrolmentLevelInfo.EnrolmentLevelSysId = PrimaryKeys.GetNewStudentEnrolmentLevelSystemID(userInfo, auth.Connection);

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertStudentEnrolmentLevel";

                    sqlComm.Parameters.Add("@sysid_enrolmentlevel", SqlDbType.VarChar).Value = enrolmentLevelInfo.EnrolmentLevelSysId;
                    sqlComm.Parameters.Add("@sysid_enrolmentcourse", SqlDbType.VarChar).Value = enrolmentLevelInfo.StudentEnrolmentCourseInfo.EnrolmentCourseSysId;
                    sqlComm.Parameters.Add("@sysid_feelevel", SqlDbType.VarChar).Value = enrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId;

                    if (String.IsNullOrEmpty(enrolmentLevelInfo.SemesterInfo.SemesterSysId))
                    {
                        sqlComm.Parameters.Add("@sysid_semester", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@sysid_semester", SqlDbType.VarChar).Value = enrolmentLevelInfo.SemesterInfo.SemesterSysId;
                    }

                    sqlComm.Parameters.Add("@level_section", SqlDbType.VarChar).Value = enrolmentLevelInfo.LevelSection;
                    sqlComm.Parameters.Add("@is_entry_level", SqlDbType.Bit).Value = enrolmentLevelInfo.IsEntryLevel;
                    sqlComm.Parameters.Add("@is_graduate_student", SqlDbType.Bit).Value = enrolmentLevelInfo.IsGraduateStudent;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }

                this.InsertDeleteEnrolmentCourseMajor(userInfo, auth.Connection, enrolmentLevelInfo);
            }
        } //-----------------------------------

        //this procedure updates a student enrolment level
        public void UpdateStudentEnrolmentLevel(CommonExchange.SysAccess userInfo, CommonExchange.StudentEnrolmentLevel enrolmentLevelInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateStudentEnrolmentLevel";

                    sqlComm.Parameters.Add("@sysid_enrolmentlevel", SqlDbType.VarChar).Value = enrolmentLevelInfo.EnrolmentLevelSysId;
                    sqlComm.Parameters.Add("@sysid_enrolmentcourse", SqlDbType.VarChar).Value = enrolmentLevelInfo.StudentEnrolmentCourseInfo.EnrolmentCourseSysId;
                    sqlComm.Parameters.Add("@sysid_feelevel", SqlDbType.VarChar).Value = enrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId;
                    sqlComm.Parameters.Add("@level_section", SqlDbType.VarChar).Value = enrolmentLevelInfo.LevelSection;
                    sqlComm.Parameters.Add("@is_entry_level", SqlDbType.Bit).Value = enrolmentLevelInfo.IsEntryLevel;
                    sqlComm.Parameters.Add("@is_graduate_student", SqlDbType.Bit).Value = enrolmentLevelInfo.IsGraduateStudent;
                    sqlComm.Parameters.Add("@is_international", SqlDbType.Bit).Value = enrolmentLevelInfo.IsInternational;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }

                this.InsertDeleteEnrolmentCourseMajor(userInfo, auth.Connection, enrolmentLevelInfo);
            }
        } //-----------------------------------

        //this procedure deletes a student enrolment level
        public void DeleteStudentEnrolmentLevel(CommonExchange.SysAccess userInfo, CommonExchange.StudentEnrolmentLevel enrolmentLevelInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.DeleteStudentEnrolmentLevel";

                    sqlComm.Parameters.Add("@sysid_enrolmentlevel", SqlDbType.VarChar).Value = enrolmentLevelInfo.EnrolmentLevelSysId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------

        //this procedure inserts a new student enrolment course
        public void InsertStudentEnrolmentCourse(CommonExchange.SysAccess userInfo, ref CommonExchange.StudentEnrolmentCourse enrolmentCourseInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                enrolmentCourseInfo.EnrolmentCourseSysId = PrimaryKeys.GetNewStudentEnrolmentCourseSystemID(userInfo, auth.Connection);

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertStudentEnrolmentCourse";

                    sqlComm.Parameters.Add("@sysid_enrolmentcourse", SqlDbType.VarChar).Value = enrolmentCourseInfo.EnrolmentCourseSysId;
                    sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = enrolmentCourseInfo.StudentInfo.StudentSysId;
                    sqlComm.Parameters.Add("@course_id", SqlDbType.VarChar).Value = enrolmentCourseInfo.CourseInfo.CourseId;
                    sqlComm.Parameters.Add("@sysid_schoolfee", SqlDbType.VarChar).Value = enrolmentCourseInfo.SchoolFeeInfo.FeeInformationSysId;

                    if (String.IsNullOrEmpty(enrolmentCourseInfo.SemesterInfo.SemesterSysId))
                    {
                        sqlComm.Parameters.Add("@sysid_semester", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@sysid_semester", SqlDbType.VarChar).Value = enrolmentCourseInfo.SemesterInfo.SemesterSysId;
                    }

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------

        //this procedure updates student enrolment course
        public void UpdateStudentEnrolmentCourse(CommonExchange.SysAccess userInfo, CommonExchange.StudentEnrolmentCourse enrolmentCourseInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateStudentEnrolmentCourse";

                    sqlComm.Parameters.Add("@sysid_enrolmentcourse", SqlDbType.VarChar).Value = enrolmentCourseInfo.EnrolmentCourseSysId;
                    sqlComm.Parameters.Add("@is_current_course", SqlDbType.Bit).Value = enrolmentCourseInfo.IsCurrentCourse;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------

        //this procedure inserts or deletes a student enrolment course major
        private void InsertDeleteEnrolmentCourseMajor(CommonExchange.SysAccess userInfo, SqlConnection sqlConn,
            CommonExchange.StudentEnrolmentLevel enrolmentLevelInfo)
        {
            //must delete first any instance of the enrolment course major before inserting a new one
            foreach (CommonExchange.EnrolmentCourseMajor courseMajor in enrolmentLevelInfo.EnrolmentCourseMajorList)
            {
                if (courseMajor.ObjectState == DataRowState.Deleted)
                {
                    using (SqlCommand sqlComm = new SqlCommand())
                    {
                        sqlComm.Connection = sqlConn;
                        sqlComm.CommandType = CommandType.StoredProcedure;
                        sqlComm.CommandText = "ums.DeleteEnrolmentCourseMajor";

                        sqlComm.Parameters.Add("@course_major_id", SqlDbType.BigInt).Value = courseMajor.CourseMajorId;

                        sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                        sqlComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                        sqlComm.ExecuteNonQuery();
                    }
                }
            }

            foreach (CommonExchange.EnrolmentCourseMajor courseMajor in enrolmentLevelInfo.EnrolmentCourseMajorList)
            {
                if (courseMajor.ObjectState == DataRowState.Added)
                {
                    using (SqlCommand sqlComm = new SqlCommand())
                    {
                        sqlComm.Connection = sqlConn;
                        sqlComm.CommandType = CommandType.StoredProcedure;
                        sqlComm.CommandText = "ums.InsertEnrolmentCourseMajor";

                        sqlComm.Parameters.Add("@sysid_enrolmentlevel", SqlDbType.VarChar).Value = enrolmentLevelInfo.EnrolmentLevelSysId;
                        sqlComm.Parameters.Add("@major_information_id", SqlDbType.VarChar).Value = courseMajor.CourseMajorInfo.MajorInformationId;

                        sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                        sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                        sqlComm.ExecuteNonQuery();
                    }
                }
            }
        } //----------------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this procedure returns the student enrolment course
        public DataTable SelectBySysIDStudentDateStartEndStudentEnrolmentCourse(CommonExchange.SysAccess userInfo, String studentSysId, 
            String dateStart, String dateEnd)
        {
            DataTable dbTable = new DataTable("StudentEnrolmentCourseBySysIDStudentDateStartEndTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDStudentDateStartEndStudentEnrolmentCourse";

                    sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = studentSysId;
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
        } //-------------------------------------------  

        //this procedure returns the student enrolment course
        public DataTable SelectBySysIDStudentStudentEnrolmentCourse(CommonExchange.SysAccess userInfo, String studentSysId)
        {
            DataTable dbTable = new DataTable("StudentEnrolmentCourseBySysIDStudentTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDStudentStudentEnrolmentCourse";

                    sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = studentSysId;

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
        } //-------------------------------------------  

        //this procedure returns the student enrolment level
        public DataTable SelectBySysIDStudentYearIDSemesterStudentEnrolmentLevel(CommonExchange.SysAccess userInfo, String studentSysId, 
            String yearId, String semesterSysId, String enrolmentCourseSysId, Boolean includeNotEnrolled, Boolean includeMarkedDeleted,
            String enrolmentLevelSysIdExcludeList)
        {
            DataTable dbTable = new DataTable("StudentEnrolmentLevelBySysIDStudentYearIDSemesterTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDStudentYearIDSemesterStudentEnrolmentLevel";

                    sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = studentSysId;

                    if (String.IsNullOrEmpty(yearId))
                    {
                        sqlComm.Parameters.Add("@year_id", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@year_id", SqlDbType.VarChar).Value = yearId;
                    }

                    if (String.IsNullOrEmpty(semesterSysId))
                    {
                        sqlComm.Parameters.Add("@sysid_semester", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@sysid_semester", SqlDbType.VarChar).Value = semesterSysId;
                    }

                    sqlComm.Parameters.Add("@sysid_enrolmentcourse", SqlDbType.VarChar).Value = enrolmentCourseSysId;
                    sqlComm.Parameters.Add("@include_not_enrolled", SqlDbType.Bit).Value = includeNotEnrolled;
                    sqlComm.Parameters.Add("@include_marked_deleted", SqlDbType.Bit).Value = includeMarkedDeleted;

                    if (String.IsNullOrEmpty(enrolmentLevelSysIdExcludeList))
                    {
                        sqlComm.Parameters.Add("@sysid_enrolmentlevel_exclude_list", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@sysid_enrolmentlevel_exclude_list", SqlDbType.NVarChar).Value = enrolmentLevelSysIdExcludeList;
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
        } //-------------------------------------------  

        //this procedure returns the student enrolment level
        public DataTable SelectBySysIDStudentStudentEnrolmentLevel(CommonExchange.SysAccess userInfo, String studentSysId)
        {
            DataTable dbTable = new DataTable("StudentEnrolmentLevelBySysIDStudentTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDStudentStudentEnrolmentLevel";

                    sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = studentSysId;

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
        } //-------------------------------------------  

        //this procedure returns the student enrolment course for enrolment history
        public DataTable SelectBySysIDStudentForEnrolmentHistoryEnrolmentCourse(CommonExchange.SysAccess userInfo, String studentSysId)
        {
            DataTable dbTable = new DataTable("StudentEnrolmentCourseForEnrolmentHistoryBySysIDStudentTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDStudentForEnrolmentHistoryEnrolmentCourse";

                    sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = studentSysId;

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
        } //-------------------------------------------  

        //this procedure returns the student enrolment level for enrolment history
        public DataTable SelectBySysIDStudentForEnrolmentHistoryEnrolmentLevel(CommonExchange.SysAccess userInfo, String studentSysId)
        {
            DataTable dbTable = new DataTable("StudentEnrolmentLevelForEnrolmentHistoryBySysIDStudentTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDStudentForEnrolmentHistoryEnrolmentLevel";

                    sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = studentSysId;

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
        } //-------------------------------------------  

        //this procedure returns the student enrolment course major
        public DataTable SelectByCourseIDSysIDEnrolmentLevelEnrolmentCourseMajor(CommonExchange.SysAccess userInfo, String studentSysId,
            String courseId, String enrolmentLevelSysId)
        {
            DataTable dbTable = new DataTable("StudentEnrolmentCourseMajorByCourseIDSysIDEnrolmentLevelTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectByCourseIDSysIDEnrolmentLevelEnrolmentCourseMajor";

                    sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = studentSysId;

                    if (String.IsNullOrEmpty(courseId))
                    {
                        sqlComm.Parameters.Add("@course_id", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@course_id", SqlDbType.VarChar).Value = courseId;
                    }

                    if (String.IsNullOrEmpty(enrolmentLevelSysId))
                    {
                        sqlComm.Parameters.Add("@sysid_enrolmentlevel", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@sysid_enrolmentlevel", SqlDbType.VarChar).Value = enrolmentLevelSysId;
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
        } //-------------------------------------------  

        //this function is used to determine the student with a certain course already exists
        public Boolean IsExistsStudentCourseStudentEnrolmentCourse(CommonExchange.SysAccess userInfo, String studentSysId, String courseId)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsExistsStudentCourseStudentEnrolmentCourse";

                    sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = studentSysId;
                    sqlComm.Parameters.Add("@course_id", SqlDbType.VarChar).Value = courseId;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;
        } //----------------------------------

        //this function is used to determine the paramaters passed are valid based on a given course
        public Boolean IsValidByCourseInformationSchoolFeeSysIDSemesterStudentEnrolmentCourse(CommonExchange.SysAccess userInfo, 
            String enrolmentCourseSysId, String schoolFeeSysId, String semesterSysId)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsValidByCourseInformationSchoolFeeSysIDSemesterStudentEnrolmentCourse";

                    sqlComm.Parameters.Add("@sysid_enrolmentcourse", SqlDbType.VarChar).Value = enrolmentCourseSysId;
                    sqlComm.Parameters.Add("@sysid_schoolfee", SqlDbType.VarChar).Value = schoolFeeSysId;
                    sqlComm.Parameters.Add("@sysid_semester", SqlDbType.VarChar).Value = semesterSysId;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;
        } //----------------------------------

        //this function is used to determine if the year level no is lesser in the existing year level in a certain course
        public Boolean IsCourseYearLevelNoLesserStudentEnrolmentLevel(CommonExchange.SysAccess userInfo, String studentSysId,
            String courseId, String yearLevelId, String enrolmentLevelSysIdExcludeList)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsCourseYearLevelNoLesserStudentEnrolmentLevel";

                    sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = studentSysId;
                    sqlComm.Parameters.Add("@course_id", SqlDbType.VarChar).Value = courseId;
                    sqlComm.Parameters.Add("@year_level_id", SqlDbType.VarChar).Value = yearLevelId;

                    if (String.IsNullOrEmpty(enrolmentLevelSysIdExcludeList))
                    {
                        sqlComm.Parameters.Add("@sysid_enrolmentlevel_exclude_list", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@sysid_enrolmentlevel_exclude_list", SqlDbType.NVarChar).Value = enrolmentLevelSysIdExcludeList;
                    }

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;
        } //----------------------------------

        //this function is used to determine if the year level is valid for changes
        public Boolean IsValidForYearLevelChangeEnrolmentLevel(CommonExchange.SysAccess userInfo, String studentSysId, String enrolmentLevelSysId)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsValidForYearLevelChangeEnrolmentLevel";

                    sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = studentSysId;
                    sqlComm.Parameters.Add("@sysid_enrolmentlevel", SqlDbType.NVarChar).Value = enrolmentLevelSysId;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;
        } //----------------------------------

        //this function is used to determine if the year level and its course group has an entry level
        public Boolean IsLevelCourseGroupWithEntryLevelEnrolmentLevel(CommonExchange.SysAccess userInfo, String studentSysId, String feeLevelSysId)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsLevelCourseGroupWithEntryLevelEnrolmentLevel";

                    sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = studentSysId;
                    sqlComm.Parameters.Add("@sysid_feelevel", SqlDbType.VarChar).Value = feeLevelSysId;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;
        } //----------------------------------

        //this function is used to determine the year level per student per course per semester already exists
        public Boolean IsExistSysIDStudentCourseLevelSemesterEnrolmentLevel(CommonExchange.SysAccess userInfo, String studentSysId, String enrolmentCourseSysId,
            String feeLevelSysId, String semesterSysId)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsExistSysIDStudentCourseLevelSemesterEnrolmentLevel";

                    sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = studentSysId;
                    sqlComm.Parameters.Add("@sysid_enrolmentcourse", SqlDbType.VarChar).Value = enrolmentCourseSysId;
                    sqlComm.Parameters.Add("@sysid_feelevel", SqlDbType.VarChar).Value = feeLevelSysId;
                    sqlComm.Parameters.Add("@sysid_semester", SqlDbType.VarChar).Value = semesterSysId;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;
        } //----------------------------------

        //this function is used to determine if the course information is valid 
        public Boolean IsNotValidForCourseSchoolFeeSysIDSemesterStudentEnrolmentLevel(CommonExchange.SysAccess userInfo,
            String enrolmentCourseSysId, String schoolFeeSysId, String semesterSysId)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsNotValidForCourseSchoolFeeSysIDSemesterStudentEnrolmentLevel";

                    sqlComm.Parameters.Add("@sysid_enrolmentcourse", SqlDbType.VarChar).Value = enrolmentCourseSysId;
                    sqlComm.Parameters.Add("@sysid_schoolfee", SqlDbType.VarChar).Value = schoolFeeSysId;
                    sqlComm.Parameters.Add("@sysid_semester", SqlDbType.VarChar).Value = semesterSysId;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;
        } //----------------------------------


        /// <summary>
        /// This function determines if the shift to another course if valid
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="enrolmentLevelSysId"></param>
        /// <param name="toShiftEnrolmentCourseSysId"></param>
        /// <returns></returns>
        public Boolean IsValidForShiftToCurrentCourseStudentEnrolmentLevel(CommonExchange.SysAccess userInfo, String enrolmentLevelSysId,
            String toShiftEnrolmentCourseSysId)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsValidForShiftToCurrentCourseStudentEnrolmentLevel";

                    sqlComm.Parameters.Add("@sysid_enrolmentlevel", SqlDbType.VarChar).Value = enrolmentLevelSysId;
                    sqlComm.Parameters.Add("@to_shift_sysid_enrolmentcourse", SqlDbType.VarChar).Value = toShiftEnrolmentCourseSysId;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;
        } //----------------------------------

        #endregion
    }
}
