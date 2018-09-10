using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteServerLib
{
    public class RemSrvStudentManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvStudentManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new student information
        public void InsertStudentInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.Student studentInfo)
        {
            if (studentInfo.ObjectState == DataRowState.Added)
            {
                using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
                {
                    using (RemSrvBaseManager remSrv = new RemSrvBaseManager())
                    {
                        studentInfo.PersonInfo.ForLogin = false;
                        studentInfo.PersonInfo.ForEmployee = false;
                        studentInfo.PersonInfo.ForStudent = true;

                        CommonExchange.Person personInfo = studentInfo.PersonInfo;

                        remSrv.InsertUpdatePersonInformationNoAuthenticate(userInfo, auth.Connection, ref personInfo);

                        studentInfo.PersonInfo = personInfo;
                    }

                    studentInfo.StudentSysId = PrimaryKeys.GetNewStudentInformationSystemID(userInfo, auth.Connection);

                    using (SqlCommand sqlComm = new SqlCommand())
                    {
                        sqlComm.Connection = auth.Connection;
                        sqlComm.CommandType = CommandType.StoredProcedure;
                        sqlComm.CommandText = "ums.InsertStudentInformation";

                        sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = studentInfo.StudentSysId;
	                    sqlComm.Parameters.Add("@student_id", SqlDbType.VarChar).Value = studentInfo.StudentId;
                    	sqlComm.Parameters.Add("@scholarship", SqlDbType.VarChar).Value = studentInfo.Scholarship;
	                    sqlComm.Parameters.Add("@is_international", SqlDbType.Bit).Value = studentInfo.IsInternational;
                        sqlComm.Parameters.Add("@is_no_downpayment_required", SqlDbType.Bit).Value = studentInfo.IsNoDownpaymentRequired;
                        sqlComm.Parameters.Add("@other_student_information", SqlDbType.VarChar).Value = studentInfo.OtherStudentInformation;

                        sqlComm.Parameters.Add("@sysid_person", SqlDbType.VarChar).Value = studentInfo.PersonInfo.PersonSysId;

                        sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                        sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                        sqlComm.ExecuteNonQuery();
                    }
                }
            }

        } //-------------------------------------

        //this procedure updates a student information
        public void UpdateStudentInformation(CommonExchange.SysAccess userInfo, CommonExchange.Student studentInfo)
        {
            if (studentInfo.ObjectState == DataRowState.Modified)
            {
                using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
                {
                    using (RemSrvBaseManager remSrv = new RemSrvBaseManager())
                    {
                        studentInfo.PersonInfo.ForLogin = false;
                        studentInfo.PersonInfo.ForEmployee = false;
                        studentInfo.PersonInfo.ForStudent = true;

                        CommonExchange.Person personInfo = studentInfo.PersonInfo;

                        remSrv.InsertUpdatePersonInformationNoAuthenticate(userInfo, auth.Connection, ref personInfo);

                        studentInfo.PersonInfo = personInfo;
                    }

                    using (SqlCommand sqlComm = new SqlCommand())
                    {
                        sqlComm.Connection = auth.Connection;
                        sqlComm.CommandType = CommandType.StoredProcedure;
                        sqlComm.CommandText = "ums.UpdateStudentInformation";

                        sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = studentInfo.StudentSysId;
                        sqlComm.Parameters.Add("@student_id", SqlDbType.VarChar).Value = studentInfo.StudentId;
                        sqlComm.Parameters.Add("@scholarship", SqlDbType.VarChar).Value = studentInfo.Scholarship;
                        sqlComm.Parameters.Add("@is_international", SqlDbType.Bit).Value = studentInfo.IsInternational;
                        sqlComm.Parameters.Add("@is_no_downpayment_required", SqlDbType.Bit).Value = studentInfo.IsNoDownpaymentRequired;
                        sqlComm.Parameters.Add("@other_student_information", SqlDbType.VarChar).Value = studentInfo.OtherStudentInformation;

                        sqlComm.Parameters.Add("@has_hs_card", SqlDbType.Bit).Value = studentInfo.HasHsCard;
                        sqlComm.Parameters.Add("@has_hon_dismissal", SqlDbType.Bit).Value = studentInfo.HasHonDismissal;
                        sqlComm.Parameters.Add("@has_tor", SqlDbType.Bit).Value = studentInfo.HasTor;
                        sqlComm.Parameters.Add("@has_good_moral", SqlDbType.Bit).Value = studentInfo.HasGoodMoral;
                        sqlComm.Parameters.Add("@has_birth_cert", SqlDbType.Bit).Value = studentInfo.HasBirthCert;
                        sqlComm.Parameters.Add("@has_marriage_contract", SqlDbType.Bit).Value = studentInfo.HasMarriageContract; 
                        sqlComm.Parameters.Add("@has_latest_photo", SqlDbType.Bit).Value = studentInfo.HasLatestPhoto;
                        sqlComm.Parameters.Add("@has_ncae_result", SqlDbType.Bit).Value = studentInfo.HasNcaeResult;

                        sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                        sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                        sqlComm.ExecuteNonQuery();
                    }

                }
            }

        } //-------------------------------------
        
        #endregion

        #region Programmer-Defined Function Procedures

        //this function returns the student count for student id
        public Int32 GetCountForStudentIDStudentInformation(CommonExchange.SysAccess userInfo, String schoolFeeSysIdList, String yearLevelId)
        {
            Int32 count = 0;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.GetCountForStudentIDStudentInformation";

                    if (String.IsNullOrEmpty(schoolFeeSysIdList))
                    {
                        sqlComm.Parameters.Add("@sysid_schoolfee_list", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@sysid_schoolfee_list", SqlDbType.VarChar).Value = schoolFeeSysIdList;
                    }
                    
                    sqlComm.Parameters.Add("@year_level_id", SqlDbType.VarChar).Value = yearLevelId;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    count = (Int32)sqlComm.ExecuteScalar();
                }
            }

            return count;

        } //-------------------------------

        //this function returns the student information details
        public CommonExchange.Student SelectByStudentIDStudentInformation(CommonExchange.SysAccess userInfo, String studentId)
        {
            CommonExchange.Student studentInfo = new CommonExchange.Student();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                studentInfo = this.SelectByStudentIDStudentInformationNoAuthenticate(userInfo, auth.Connection, studentId);
            }

            return studentInfo;
        } //-------------------------------------

        //this function returns the student information details
        public CommonExchange.Student SelectBySysIDPersonStudentInformation(CommonExchange.SysAccess userInfo, String personSysId)
        {
            CommonExchange.Student studentInfo = new CommonExchange.Student();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                String studentId = String.Empty;

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDPersonStudentInformation";

                    sqlComm.Parameters.Add("@sysid_person", SqlDbType.VarChar).Value = personSysId;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                studentId = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "student_id", String.Empty);

                                break;

                            }
                        }

                        sqlReader.Close();
                    }
                }

                if (!String.IsNullOrEmpty(studentId))
                {
                    studentInfo = this.SelectByStudentIDStudentInformationNoAuthenticate(userInfo, auth.Connection, studentId);
                }
            }

            return studentInfo;
        } //-------------------------------------

        //this function gets the student information table query
        public DataTable SelectStudentInformation(CommonExchange.SysAccess userInfo, String queryString, String dateStart, String dateEnd, 
            String courseIdList, String yearLevelIdList)
        {
            DataTable dbTable = new DataTable("StudentInformationTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectStudentInformation";

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

                    if (String.IsNullOrEmpty(courseIdList))
                    {
                        sqlComm.Parameters.Add("@course_id_list", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@course_id_list", SqlDbType.NVarChar).Value = courseIdList;
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

        //this function is used to determine if the student id exists
        public Boolean IsExistsStudentIdStudentInformation(CommonExchange.SysAccess userInfo, String studentId, String studentSysId)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsExistStudentIDStudentInformation";

                    sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = studentSysId;
                    sqlComm.Parameters.Add("@student_id", SqlDbType.VarChar).Value = studentId;
                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;
        } //-----------------------------   

        //this function is used to get data tables stored in one dataset used for student manager
        public DataSet GetDataSetForStudentInformation(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            DataSet dbSet = new DataSet();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                //get the course information table
                dbSet.Tables.Add(ProcStatic.GetCourseInformationTable(auth.Connection, userInfo.UserId));
                //------------------------------

                //get the course year level table
                dbSet.Tables.Add(ProcStatic.GetCourseYearLevelTable(auth.Connection, userInfo.UserId));
                //------------------------------------

                //get the school fee information table
                dbSet.Tables.Add(ProcStatic.GetSchoolFeeInformationTable(auth.Connection, userInfo.UserId, serverDateTime));
                //--------------------------------

                //gets the semester information table
                dbSet.Tables.Add(ProcStatic.GetSemesterInformationTable(auth.Connection, userInfo.UserId, serverDateTime));
                //-------------------------------- 

                //get the year level table
                dbSet.Tables.Add(ProcStatic.GetYearLevelInformationTable(auth.Connection, userInfo.UserId));
                //--------------------------------

                //get the course group table
                dbSet.Tables.Add(ProcStatic.GetCourseGroupTable(auth.Connection, userInfo.UserId));
                //-------------------------------------

                //gets the relationship type table
                dbSet.Tables.Add(ProcStatic.GetRelationshipTypeTable(auth.Connection, userInfo.UserId));
                //-------------------------------------
            }

            return dbSet;
        } //----------------------------------

        //this function returns the student information details
        private CommonExchange.Student SelectByStudentIDStudentInformationNoAuthenticate(CommonExchange.SysAccess userInfo, SqlConnection sqlConn, 
            String studentId)
        {
            CommonExchange.Student studentInfo = new CommonExchange.Student();

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectByStudentIDStudentInformation";

                sqlComm.Parameters.Add("@student_id", SqlDbType.VarChar).Value = studentId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                {
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            studentInfo.StudentSysId = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_student", String.Empty);
                            studentInfo.StudentId = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "student_id", String.Empty);
                            studentInfo.CardNumber = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "card_number", String.Empty);
                            studentInfo.Scholarship = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "scholarship", String.Empty);
                            studentInfo.IsInternational = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_international", false);
                            studentInfo.IsNoDownpaymentRequired = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_no_downpayment_required", false);
                            studentInfo.OtherStudentInformation = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "other_student_information", 
                                String.Empty);
                            studentInfo.HasHsCard = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "has_hs_card", false);
                            studentInfo.HasHonDismissal = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "has_hon_dismissal", false);
		                    studentInfo.HasTor = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "has_tor", false);
		                    studentInfo.HasGoodMoral = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "has_good_moral", false);
	                        studentInfo.HasBirthCert = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "has_birth_cert", false);
		                    studentInfo.HasMarriageContract = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "has_marriage_contract", false);
		                    studentInfo.HasLatestPhoto = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "has_latest_photo", false);
                            studentInfo.HasNcaeResult = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "has_ncae_result", false);

                            studentInfo.PersonInfo.PersonSysId = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_person", String.Empty);

                            studentInfo.CourseInfo.CourseId = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "course_id", String.Empty);
                            studentInfo.CourseInfo.CourseTitle = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "course_title", String.Empty);
                            studentInfo.CourseInfo.Acronym = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "course_acronym", String.Empty);

                            studentInfo.CourseInfo.DepartmentInfo.DepartmentId = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "department_id", 
                                String.Empty);
			                studentInfo.CourseInfo.DepartmentInfo.DepartmentName = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "department_name",
                                String.Empty);
                            studentInfo.CourseInfo.DepartmentInfo.Acronym = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "department_acronym",
                                String.Empty);

                            break;

                        }
                    }

                    sqlReader.Close();
                }

                if (!String.IsNullOrEmpty(studentInfo.PersonInfo.PersonSysId))
                {
                    using (RemSrvBaseManager remSrv = new RemSrvBaseManager())
                    {
                        studentInfo.PersonInfo = remSrv.SelectBySysIDPersonInformationNoAuthenticate(userInfo.UserId, sqlConn,
                            studentInfo.PersonInfo.PersonSysId);
                    }
                }

            }

            return studentInfo;
        } //-------------------------------------

        #endregion
    }
}
