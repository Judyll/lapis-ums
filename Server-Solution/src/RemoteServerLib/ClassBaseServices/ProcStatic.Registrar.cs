using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RemoteServerLib
{
    partial class ProcStatic
    {
        #region Programmer-Defined Function Procedures

        //this function gets the school year table
        public static DataTable GetSchoolYearTable(SqlConnection sqlConn, String userId, String serverDateTime)
        {
            DataTable dbTable = new DataTable("SchoolYearTable");
            dbTable.Columns.Add("year_id", System.Type.GetType("System.String"));
            dbTable.Columns.Add("year_description", System.Type.GetType("System.String"));
            dbTable.Columns.Add("date_start", System.Type.GetType("System.String"));
            dbTable.Columns.Add("date_end", System.Type.GetType("System.String"));
            dbTable.Columns.Add("is_summer", System.Type.GetType("System.Boolean"));

            //get the employment type for the employees
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectSchoolYear";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                {
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            DataRow newRow = dbTable.NewRow();

                            newRow["year_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "year_id", "");
                            newRow["year_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "year_description", "");
                            newRow["date_start"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "date_start",
                                DateTime.Parse(serverDateTime)).ToString();
                            newRow["date_end"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "date_end",
                                DateTime.Parse(serverDateTime)).ToString();
                            newRow["is_summer"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_summer", false);

                            dbTable.Rows.Add(newRow);
                        }
                    }

                    sqlReader.Close();                    
                }

            } //---------------------------------

            return dbTable;

        } //-------------------------------

        //this function gets the school year table
        public static DataTable GetByYearDescriptionSchoolYearTable(SqlConnection sqlConn, String userId, String queryString, String serverDateTime)
        {
            DataTable dbTable = new DataTable("SchoolYearTable");
            dbTable.Columns.Add("year_id", System.Type.GetType("System.String"));
            dbTable.Columns.Add("year_description", System.Type.GetType("System.String"));
            dbTable.Columns.Add("date_start", System.Type.GetType("System.String"));
            dbTable.Columns.Add("date_end", System.Type.GetType("System.String"));

            //get the employment type for the employees
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectByYearDescriptionSchoolYear";

                sqlComm.Parameters.Add("@query_string", SqlDbType.VarChar).Value = queryString;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;
                
                using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                {
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            DataRow newRow = dbTable.NewRow();

                            newRow["year_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "year_id", "");
                            newRow["year_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "year_description", "");
                            newRow["date_start"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "date_start",
                                DateTime.Parse(serverDateTime)).ToString();
                            newRow["date_end"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "date_end",
                                DateTime.Parse(serverDateTime)).ToString();

                            dbTable.Rows.Add(newRow);
                        }
                    }

                    sqlReader.Close();
                }

            } //---------------------------------

            return dbTable;

        } //-------------------------------

        //this function gets the school semester table
        public static DataTable GetSchoolSemesterTable(SqlConnection sqlConn, String userId)
        {
            DataTable dbTable = new DataTable("SchoolSemesterTable");

            //get the employment type for the employees
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectSchoolSemester";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                {
                    sqlAdapter.SelectCommand = sqlComm;
                    sqlAdapter.Fill(dbTable);
                }
            } //---------------------------------

            return dbTable;
        } //-------------------------------

        //this function gets the semester information table
        public static DataTable GetSemesterInformationTable(SqlConnection sqlConn, String userId, String serverDateTime)
        {
            DataTable dbTable = new DataTable("SemesterInformationTable");
            dbTable.Columns.Add("sysid_semester", System.Type.GetType("System.String"));
            dbTable.Columns.Add("year_id", System.Type.GetType("System.String"));
            dbTable.Columns.Add("semester_id", System.Type.GetType("System.Byte"));
            dbTable.Columns.Add("date_start", System.Type.GetType("System.String"));
            dbTable.Columns.Add("date_end", System.Type.GetType("System.String"));
            dbTable.Columns.Add("year_description", System.Type.GetType("System.String"));
            dbTable.Columns.Add("is_summer", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("semester_description", System.Type.GetType("System.String"));

            //get the employment type for the employees
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectSemesterInformation";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                {
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            DataRow newRow = dbTable.NewRow();

                            newRow["sysid_semester"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_semester", "");
                            newRow["year_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "year_id", "");
                            newRow["semester_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "semester_id", Byte.Parse("0"));
                            newRow["date_start"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "date_start",
                                DateTime.Parse(serverDateTime)).ToString();
                            newRow["date_end"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "date_end",
                                DateTime.Parse(serverDateTime)).ToString();
                            newRow["year_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "year_description", "");
                            newRow["is_summer"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_summer", false);
                            newRow["semester_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "semester_description", "");

                            dbTable.Rows.Add(newRow);
                        }
                    }

                    sqlReader.Close();
                }
            } //---------------------------------

            return dbTable;
        } //----------------------------

        //this function gets the semester information table
        public static DataTable GetYearSemesterDescriptionSemesterInformationTable(SqlConnection sqlConn, String userId, String queryString,
            String serverDateTime)
        {
            DataTable dbTable = new DataTable("SemesterInformationTable");
            dbTable.Columns.Add("sysid_semester", System.Type.GetType("System.String"));
            dbTable.Columns.Add("year_id", System.Type.GetType("System.String"));
            dbTable.Columns.Add("semester_id", System.Type.GetType("System.Byte"));
            dbTable.Columns.Add("date_start", System.Type.GetType("System.String"));
            dbTable.Columns.Add("date_end", System.Type.GetType("System.String"));
            dbTable.Columns.Add("year_description", System.Type.GetType("System.String"));
            dbTable.Columns.Add("semester_description", System.Type.GetType("System.String"));

            //get the employment type for the employees
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectYearSemesterDescriptionSemesterInformation";

                sqlComm.Parameters.Add("@query_string", SqlDbType.VarChar).Value = queryString;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                {
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            DataRow newRow = dbTable.NewRow();

                            newRow["sysid_semester"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_semester", "");
                            newRow["year_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "year_id", "");
                            newRow["semester_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "semester_id", Byte.Parse("0"));
                            newRow["date_start"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "date_start",
                                DateTime.Parse(serverDateTime)).ToString();
                            newRow["date_end"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "date_end",
                                DateTime.Parse(serverDateTime)).ToString();
                            newRow["year_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "year_description", "");
                            newRow["semester_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "semester_description", "");

                            dbTable.Rows.Add(newRow);
                        }
                    }

                    sqlReader.Close();
                }
            } //---------------------------------

            return dbTable;
        } //----------------------------


        //this function gets the classroom information table
        public static DataTable GetClassroomInformationTable(SqlConnection sqlConn, String userId)
        {
            DataTable dbTable = new DataTable("ClassroomInformationTable");

            //get the classroom information table
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectClassroomInformation";

                sqlComm.Parameters.Add("@query_string", SqlDbType.VarChar).Value = "*";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                {
                    sqlAdapter.SelectCommand = sqlComm;
                    sqlAdapter.Fill(dbTable);
                }
            } //-----------------------

            return dbTable;
        } //-----------------------------------

        //this function gets the subject category table
        public static DataTable GetSubjectCategoryTable(SqlConnection sqlConn, String userId)
        {
            DataTable dbTable = new DataTable("SubjectCategoryTable");

            //get the classroom information table
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectSubjectCategory";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                {
                    sqlAdapter.SelectCommand = sqlComm;
                    sqlAdapter.Fill(dbTable);
                }
            } //-----------------------

            return dbTable;
        } //-----------------------------------

        //this function gets the department information table
        public static DataTable GetDepartmentInformationTable(SqlConnection sqlConn, String userId)
        {
            DataTable dbTable = new DataTable("DepartmentInformationTable");

            //get the classroom information table
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectDepartmentInformation";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                {
                    sqlAdapter.SelectCommand = sqlComm;
                    sqlAdapter.Fill(dbTable);
                }
            } //-----------------------

            return dbTable;
        } //-----------------------------------

        //this function gets the course group table
        public static DataTable GetCourseGroupTable(SqlConnection sqlConn, String userId)
        {
            DataTable dbTable = new DataTable("CourseGroupTable");
            dbTable.Columns.Add("course_group_id", System.Type.GetType("System.String"));
			dbTable.Columns.Add("group_no", System.Type.GetType("System.Byte"));
			dbTable.Columns.Add("group_description", System.Type.GetType("System.String"));
			dbTable.Columns.Add("is_semestral", System.Type.GetType("System.Boolean"));
            dbTable.Columns.Add("is_per_unit", System.Type.GetType("System.Boolean"));

            //get the classroom information table
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectCourseGroup";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                {
                    if (sqlReader.HasRows)
                    {
                        
                        while (sqlReader.Read())
                        {
                            if ((String.Equals(RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "course_group_id", ""), CommonExchange.CourseGroupId.GradeSchoolKinder) &&
                                CommonExchange.EnrolmentComponent.IncludeGradeSchoolKinder) ||
                                (String.Equals(RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "course_group_id", ""), CommonExchange.CourseGroupId.HighSchool) &&
                                CommonExchange.EnrolmentComponent.IncludeHighSchool) ||
                                (String.Equals(RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "course_group_id", ""), CommonExchange.CourseGroupId.College) &&
                                CommonExchange.EnrolmentComponent.IncludeCollege) ||
                                (String.Equals(RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "course_group_id", ""), CommonExchange.CourseGroupId.GraduateSchoolDoctorate) &&
                                CommonExchange.EnrolmentComponent.IncludeGraduateSchoolDoctorate) ||
                                (String.Equals(RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "course_group_id", ""), CommonExchange.CourseGroupId.CrashCourse) &&
                                CommonExchange.EnrolmentComponent.IncludeCrashCourse))
                            {

                                DataRow newRow = dbTable.NewRow();

                                newRow["course_group_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "course_group_id", "");
                                newRow["group_no"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "group_no", Byte.Parse("0"));
                                newRow["group_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "group_description", "");
                                newRow["is_semestral"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_semestral", false);
                                newRow["is_per_unit"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_per_unit", false); 

                                dbTable.Rows.Add(newRow);
                            }
                        }
                    }

                    sqlReader.Close();
                }
            } //-----------------------

            return dbTable;
        } //-----------------------------------

        //this function gets the year level information
        public static DataTable GetYearLevelInformationTable(SqlConnection sqlConn, String userId)
        {
            DataTable dbTable = new DataTable("YearLevelInformationTable");

            //get the classroom information table
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectYearLevelInformation";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                {
                    sqlAdapter.SelectCommand = sqlComm;
                    sqlAdapter.Fill(dbTable);
                }
            } //-----------------------

            return dbTable;
        } //-----------------------------------

        //this function gets the course information table
        public static DataTable GetCourseInformationTable(SqlConnection sqlConn, String userId)
        {
            DataTable dbTable = new DataTable("CourseInformationTable");

            //get the classroom information table
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectCourseInformation";

                sqlComm.Parameters.Add("@query_string", SqlDbType.VarChar).Value = "*";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                {
                    sqlAdapter.SelectCommand = sqlComm;
                    sqlAdapter.Fill(dbTable);
                }
            } //-----------------------

            return dbTable;
        } //-----------------------------------

        //this function gets the course year level table
        public static DataTable GetCourseYearLevelTable(SqlConnection sqlConn, String userId)
        {
            DataTable dbTable = new DataTable("CourseYearLevelTable");

            //get the classroom information table
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectCourseYearLevel";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                {
                    sqlAdapter.SelectCommand = sqlComm;
                    sqlAdapter.Fill(dbTable);
                }
            } //-----------------------

            return dbTable;
        } //-----------------------------------

        //this function gets the major exam information table
        public static DataTable GetMajorExamInformationTable(SqlConnection sqlConn, String userId)
        {
            DataTable dbTable = new DataTable("MajorExamInformationTable");

            //get the classroom information table
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectMajorExamInformation";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                {
                    sqlAdapter.SelectCommand = sqlComm;
                    sqlAdapter.Fill(dbTable);
                }
            } //-----------------------

            return dbTable;
        } //-----------------------------------
        
        #endregion
    }
}
