using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteServerLib
{
    public class RemSrvCourseManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvCourseManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new subject information
        public void InsertSubjectInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.SubjectInformation subjectInfo,
                                                    DataTable requisiteTable)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertSubjectInformation";

                    sqlComm.Parameters.Add("@sysid_subject", SqlDbType.VarChar).Value = subjectInfo.SubjectSysId =
                        PrimaryKeys.GetNewSubjectInformationSystemID(userInfo, auth.Connection);
                    sqlComm.Parameters.Add("@course_group_id", SqlDbType.VarChar).Value = subjectInfo.CourseGroupInfo.CourseGroupId;
                    sqlComm.Parameters.Add("@department_id", SqlDbType.VarChar).Value = subjectInfo.DepartmentInfo.DepartmentId;

                    if (String.IsNullOrEmpty(subjectInfo.CategoryInfo.CategoryId))
                    {
                        sqlComm.Parameters.Add("@category_id", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@category_id", SqlDbType.VarChar).Value = subjectInfo.CategoryInfo.CategoryId;
                    }

                    sqlComm.Parameters.Add("@subject_code", SqlDbType.VarChar).Value = subjectInfo.SubjectCode;
                    sqlComm.Parameters.Add("@descriptive_title", SqlDbType.VarChar).Value = subjectInfo.DescriptiveTitle;
                    sqlComm.Parameters.Add("@lecture_units", SqlDbType.TinyInt).Value = subjectInfo.LectureUnits;
                    sqlComm.Parameters.Add("@lab_units", SqlDbType.TinyInt).Value = subjectInfo.LabUnits;
                    sqlComm.Parameters.Add("@no_hours", SqlDbType.VarChar).Value = subjectInfo.NoHours;
                    sqlComm.Parameters.Add("@other_information", SqlDbType.VarChar).Value = subjectInfo.OtherInformation;
                    sqlComm.Parameters.Add("@is_non_academic", SqlDbType.Bit).Value = subjectInfo.IsNonAcademic;
                    sqlComm.Parameters.Add("@is_open_access", SqlDbType.Bit).Value = subjectInfo.IsOpenAccess;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }

                this.InsertDeletePrerequisite(userInfo, auth.Connection, requisiteTable, subjectInfo.SubjectSysId);
            }

        } //---------------------------------

        //this procedure updates a subject information
        public void UpdateSubjectInformation(CommonExchange.SysAccess userInfo, CommonExchange.SubjectInformation subjectInfo, 
                                                    DataTable requisiteTable)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateSubjectInformation";

                    sqlComm.Parameters.Add("@sysid_subject", SqlDbType.VarChar).Value = subjectInfo.SubjectSysId;
                    sqlComm.Parameters.Add("@department_id", SqlDbType.VarChar).Value = subjectInfo.DepartmentInfo.DepartmentId;

                    if (String.IsNullOrEmpty(subjectInfo.CategoryInfo.CategoryId))
                    {
                        sqlComm.Parameters.Add("@category_id", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@category_id", SqlDbType.VarChar).Value = subjectInfo.CategoryInfo.CategoryId;
                    }

                    sqlComm.Parameters.Add("@subject_code", SqlDbType.VarChar).Value = subjectInfo.SubjectCode;
                    sqlComm.Parameters.Add("@descriptive_title", SqlDbType.VarChar).Value = subjectInfo.DescriptiveTitle;
                    sqlComm.Parameters.Add("@lecture_units", SqlDbType.TinyInt).Value = subjectInfo.LectureUnits;
                    sqlComm.Parameters.Add("@lab_units", SqlDbType.TinyInt).Value = subjectInfo.LabUnits;
                    sqlComm.Parameters.Add("@no_hours", SqlDbType.VarChar).Value = subjectInfo.NoHours;
                    sqlComm.Parameters.Add("@other_information", SqlDbType.VarChar).Value = subjectInfo.OtherInformation;
                    sqlComm.Parameters.Add("@is_non_academic", SqlDbType.Bit).Value = subjectInfo.IsNonAcademic;
                    sqlComm.Parameters.Add("@is_open_access", SqlDbType.Bit).Value = subjectInfo.IsOpenAccess;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }

                this.InsertDeletePrerequisite(userInfo, auth.Connection, requisiteTable, subjectInfo.SubjectSysId);
            }
        } //----------------------------------

        //this procedure inserts a new classroom information
        public void InsertClassroomInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.ClassroomInformation roomInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                roomInfo.ClassroomSysId = PrimaryKeys.GetNewClassroomInformationSystemID(userInfo, auth.Connection);

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertClassroomInformation";

                    sqlComm.Parameters.Add("@sysid_classroom", SqlDbType.VarChar).Value = roomInfo.ClassroomSysId;
                    sqlComm.Parameters.Add("@classroom_code", SqlDbType.VarChar).Value = roomInfo.ClassroomCode;
                    sqlComm.Parameters.Add("@classroom_description", SqlDbType.VarChar).Value = roomInfo.Description;
                    sqlComm.Parameters.Add("@maximum_capacity", SqlDbType.TinyInt).Value = roomInfo.MaximumCapacity;
                    sqlComm.Parameters.Add("@other_information", SqlDbType.VarChar).Value = roomInfo.OtherInformation;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }

        } //-----------------------------

        //this procedure updates a classroom information
        public void UpdateClassroomInformation(CommonExchange.SysAccess userInfo, CommonExchange.ClassroomInformation roomInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateClassroomInformation";

                    sqlComm.Parameters.Add("@sysid_classroom", SqlDbType.VarChar).Value = roomInfo.ClassroomSysId;
                    sqlComm.Parameters.Add("@classroom_code", SqlDbType.VarChar).Value = roomInfo.ClassroomCode;
                    sqlComm.Parameters.Add("@classroom_description", SqlDbType.VarChar).Value = roomInfo.Description;
                    sqlComm.Parameters.Add("@maximum_capacity", SqlDbType.TinyInt).Value = roomInfo.MaximumCapacity;
                    sqlComm.Parameters.Add("@other_information", SqlDbType.VarChar).Value = roomInfo.OtherInformation;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //------------------------------

        //this procedure inserts and delete a pre-requisite subject
        private void InsertDeletePrerequisite(CommonExchange.SysAccess userInfo, SqlConnection sqlConn, DataTable requisiteTable,
                                                    String subjectSysId)
        {
            using (SqlCommand insertComm = new SqlCommand())
            {
                insertComm.Connection = sqlConn;
                insertComm.CommandType = CommandType.StoredProcedure;
                insertComm.CommandText = "ums.InsertSubjectPrerequisite";

                insertComm.Parameters.Add("@sysid_subject", SqlDbType.VarChar).Value = subjectSysId;
                insertComm.Parameters.Add("@prerequisite_subject", SqlDbType.VarChar).SourceColumn = "prerequisite_subject";

                insertComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                insertComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                using (SqlCommand deleteComm = new SqlCommand())
                {
                    deleteComm.Connection = sqlConn;
                    deleteComm.CommandType = CommandType.StoredProcedure;
                    deleteComm.CommandText = "ums.DeleteSubjectPrerequisite";

                    deleteComm.Parameters.Add("@prerequisite_id", SqlDbType.BigInt).SourceColumn = "prerequisite_id";

                    deleteComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    deleteComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                    {
                        sqlAdapter.InsertCommand = insertComm;
                        sqlAdapter.DeleteCommand = deleteComm;

                        sqlAdapter.Update(requisiteTable);
                    }
                }
            }
        
        } //-------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function is used to get the subject prerequisite by subject id
        public DataTable SelectBySubjectIDSubjectPrerequisite(CommonExchange.SysAccess userInfo, String subjectSysId)
        {
            DataTable dbTable = new DataTable("SubjectPreRequisiteBySubjectIdTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySubjectIDSubjectPrerequisite";

                    sqlComm.Parameters.Add("@sysid_subject", SqlDbType.VarChar).Value = subjectSysId;
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

        //this function is used to get the subject information by subject code or title
        public DataTable SelectSubjectInformation(CommonExchange.SysAccess userInfo, String queryString)
        {
            DataTable dbTable = new DataTable("SubjectInformationTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectSubjectInformation";

                    sqlComm.Parameters.Add("@query_string", SqlDbType.VarChar).Value = queryString;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                    {
                        sqlAdapter.SelectCommand = sqlComm;
                        sqlAdapter.Fill(dbTable);
                    }
                } 
            }

            return dbTable;
        } //------------------------------------------

        //this function is used to get the classroom information by classroom code or description
        public DataTable SelectClassroomInformation(CommonExchange.SysAccess userInfo, String queryString)
        {
            DataTable dbTable = new DataTable("ClassroomInformationTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectClassroomInformation";

                    sqlComm.Parameters.Add("@query_string", SqlDbType.VarChar).Value = queryString;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                    {
                        sqlAdapter.SelectCommand = sqlComm;
                        sqlAdapter.Fill(dbTable);
                    }
                } 
            }

            return dbTable;
        } //------------------------------------------

        //this function is used to get the course information by course title or acronym
        public DataTable SelectCourseInformation(CommonExchange.SysAccess userInfo, String queryString)
        {
            DataTable dbTable = new DataTable("CourseInformationTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectCourseInformation";

                    sqlComm.Parameters.Add("@query_string", SqlDbType.VarChar).Value = queryString;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                    {
                        sqlAdapter.SelectCommand = sqlComm;
                        sqlAdapter.Fill(dbTable);
                    }
                } 
            }

            return dbTable;
        } //------------------------------------------

        //this function determines if the subject code and descriptive title exist
        public Boolean IsExistCodeDescriptionSubjectInformation(CommonExchange.SysAccess userInfo, CommonExchange.SubjectInformation subjectInfo)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsExistCodeDescriptionSubjectInformation";

                    sqlComm.Parameters.Add("@sysid_subject", SqlDbType.VarChar).Value = subjectInfo.SubjectSysId;
                    sqlComm.Parameters.Add("@subject_code", SqlDbType.VarChar).Value = subjectInfo.SubjectCode;
                    sqlComm.Parameters.Add("@descriptive_title", SqlDbType.VarChar).Value = subjectInfo.DescriptiveTitle;
                    sqlComm.Parameters.Add("@department_id", SqlDbType.VarChar).Value = subjectInfo.DepartmentInfo.DepartmentId;
                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;

        } //------------------------------

        //this function determines if the classroom code exist
        public Boolean IsExistCodeClassroomInformation(CommonExchange.SysAccess userInfo, String roomCode, String roomSysId)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsExistCodeClassroomInformation";

                    sqlComm.Parameters.Add("@sysid_classroom", SqlDbType.VarChar).Value = roomSysId;
                    sqlComm.Parameters.Add("@classroom_code", SqlDbType.VarChar).Value = roomCode;
                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;

        } //------------------------------

        //this function determines if the course title and acronym exist
        public Boolean IsExistTitleAcronymCourseInformation(CommonExchange.SysAccess userInfo, CommonExchange.CourseInformation courseInfo)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsExistTitleAcronymCourseInformation";

                    sqlComm.Parameters.Add("@course_id", SqlDbType.VarChar).Value = courseInfo.CourseId;
                    sqlComm.Parameters.Add("@course_title", SqlDbType.VarChar).Value = courseInfo.CourseTitle;
                    sqlComm.Parameters.Add("@acronym", SqlDbType.VarChar).Value = courseInfo.Acronym;
                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;

        } //------------------------------

        //this function is used to get data tables stored in one dataset used for classroom subject information
        public DataSet GetDataSetForClassroomSubject(CommonExchange.SysAccess userInfo)
        {
            DataSet dbSet = new DataSet();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {                            
                //gets the department information table
                dbSet.Tables.Add(ProcStatic.GetDepartmentInformationTable(auth.Connection, userInfo.UserId));
                //------------------------------------
                
                //gets the course group table
                dbSet.Tables.Add(ProcStatic.GetCourseGroupTable(auth.Connection, userInfo.UserId));
                //--------------------------------------

                //gets the year level information table
                dbSet.Tables.Add(ProcStatic.GetYearLevelInformationTable(auth.Connection, userInfo.UserId));
                //---------------------------------------

                //gets the subject category table
                dbSet.Tables.Add(ProcStatic.GetSubjectCategoryTable(auth.Connection, userInfo.UserId));
                //-------------------------------------
            }

            return dbSet;
        } //----------------------------------
        

        #endregion
    }
}
