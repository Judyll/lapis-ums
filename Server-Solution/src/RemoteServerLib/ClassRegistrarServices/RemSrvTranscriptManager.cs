using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteServerLib
{
    public class RemSrvTranscriptManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvTranscriptManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new transcript information
        public void InsertTranscriptInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.TranscriptInformation transcriptInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                transcriptInfo.TranscriptSysId = PrimaryKeys.GetNewTranscriptInformationSystemID(userInfo, auth.Connection);

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertTranscriptInformation";

                    sqlComm.Parameters.Add("@sysid_transcript", SqlDbType.VarChar).Value = transcriptInfo.TranscriptSysId;
                    sqlComm.Parameters.Add("@student_id", SqlDbType.VarChar).Value = transcriptInfo.StudentId;
                    sqlComm.Parameters.Add("@last_name", SqlDbType.VarChar).Value = transcriptInfo.LastName;
                    sqlComm.Parameters.Add("@first_name", SqlDbType.VarChar).Value = transcriptInfo.FirstName;
                    sqlComm.Parameters.Add("@middle_name", SqlDbType.VarChar).Value = transcriptInfo.MiddleName;
                    sqlComm.Parameters.Add("@department_name", SqlDbType.VarChar).Value = transcriptInfo.DepartmentName;
                    sqlComm.Parameters.Add("@course_title", SqlDbType.VarChar).Value = transcriptInfo.CourseTitle;
                    sqlComm.Parameters.Add("@entrance_data", SqlDbType.VarChar).Value = transcriptInfo.EntranceData;
                    sqlComm.Parameters.Add("@records_of_graduation", SqlDbType.VarChar).Value = transcriptInfo.RecordsOfGraduation;
                    sqlComm.Parameters.Add("@purpose_of_request", SqlDbType.VarChar).Value = transcriptInfo.PurposeOfRequest;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }

                if (transcriptInfo.FileData != null && !String.IsNullOrEmpty(transcriptInfo.FileName) &&
                        !String.IsNullOrEmpty(transcriptInfo.FileExtension))
                {
                    using (SqlCommand imageComm = new SqlCommand())
                    {
                        imageComm.Connection = auth.Connection;
                        imageComm.CommandType = CommandType.StoredProcedure;
                        imageComm.CommandText = "ums.InsertUpdateTranscriptImage";

                        imageComm.Parameters.Add("@sysid_transcript", SqlDbType.VarChar).Value = transcriptInfo.TranscriptSysId;
                        imageComm.Parameters.Add("@file_data", SqlDbType.VarBinary).Value = transcriptInfo.FileData;
                        imageComm.Parameters.Add("@original_name", SqlDbType.VarChar).Value = transcriptInfo.TranscriptSysId + 
                            transcriptInfo.FileExtension;

                        imageComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                        imageComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                        imageComm.ExecuteNonQuery();
                    }

                }
            }

        } //---------------------------------

        //this procedure inserts a new transcript information
        public void UpdateTranscriptInformation(CommonExchange.SysAccess userInfo, CommonExchange.TranscriptInformation transcriptInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateTranscriptInformation";

                    sqlComm.Parameters.Add("@sysid_transcript", SqlDbType.VarChar).Value = transcriptInfo.TranscriptSysId;
                    sqlComm.Parameters.Add("@student_id", SqlDbType.VarChar).Value = transcriptInfo.StudentId;
                    sqlComm.Parameters.Add("@last_name", SqlDbType.VarChar).Value = transcriptInfo.LastName;
                    sqlComm.Parameters.Add("@first_name", SqlDbType.VarChar).Value = transcriptInfo.FirstName;
                    sqlComm.Parameters.Add("@middle_name", SqlDbType.VarChar).Value = transcriptInfo.MiddleName;
                    sqlComm.Parameters.Add("@department_name", SqlDbType.VarChar).Value = transcriptInfo.DepartmentName;
                    sqlComm.Parameters.Add("@course_title", SqlDbType.VarChar).Value = transcriptInfo.CourseTitle;
                    sqlComm.Parameters.Add("@entrance_data", SqlDbType.VarChar).Value = transcriptInfo.EntranceData;
                    sqlComm.Parameters.Add("@records_of_graduation", SqlDbType.VarChar).Value = transcriptInfo.RecordsOfGraduation;
                    sqlComm.Parameters.Add("@purpose_of_request", SqlDbType.VarChar).Value = transcriptInfo.PurposeOfRequest;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }

                if (transcriptInfo.FileData != null && !String.IsNullOrEmpty(transcriptInfo.FileName) &&
                        !String.IsNullOrEmpty(transcriptInfo.FileExtension))
                {
                    using (SqlCommand imageComm = new SqlCommand())
                    {
                        imageComm.Connection = auth.Connection;
                        imageComm.CommandType = CommandType.StoredProcedure;
                        imageComm.CommandText = "ums.InsertUpdateTranscriptImage";

                        imageComm.Parameters.Add("@sysid_transcript", SqlDbType.VarChar).Value = transcriptInfo.TranscriptSysId;
                        imageComm.Parameters.Add("@file_data", SqlDbType.VarBinary).Value = transcriptInfo.FileData;
                        imageComm.Parameters.Add("@original_name", SqlDbType.VarChar).Value = transcriptInfo.TranscriptSysId +
                            transcriptInfo.FileExtension;

                        imageComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                        imageComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                        imageComm.ExecuteNonQuery();
                    }

                }
            }

        } //---------------------------------

        //this procedure insert, update or delete a transcript details
        public void InsertUpdateDeleteTranscriptDetails(CommonExchange.SysAccess userInfo, String transcriptSysId, DataTable transcriptDetailsTable)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand insertComm = new SqlCommand())
                {
                    insertComm.Connection = auth.Connection;
                    insertComm.CommandType = CommandType.StoredProcedure;
                    insertComm.CommandText = "ums.InsertTranscriptDetails";

                    insertComm.Parameters.Add("@sysid_transcript", SqlDbType.VarChar).Value = transcriptSysId;
                    insertComm.Parameters.Add("@term_session", SqlDbType.VarChar).SourceColumn = "term_session";
                    insertComm.Parameters.Add("@subject_code", SqlDbType.VarChar).SourceColumn = "subject_code";
                    insertComm.Parameters.Add("@subject_no", SqlDbType.VarChar).SourceColumn = "subject_no";
                    insertComm.Parameters.Add("@descriptive_title", SqlDbType.VarChar).SourceColumn = "descriptive_title";
                    insertComm.Parameters.Add("@credit_units", SqlDbType.VarChar).SourceColumn = "credit_units";
                    insertComm.Parameters.Add("@final_grade", SqlDbType.VarChar).SourceColumn = "final_grade";
                    insertComm.Parameters.Add("@re_exam", SqlDbType.VarChar).SourceColumn = "re_exam";
                    insertComm.Parameters.Add("@no_of_hours", SqlDbType.VarChar).SourceColumn = "no_of_hours";
                    insertComm.Parameters.Add("@sequence_no", SqlDbType.SmallInt).SourceColumn = "sequence_no";
                    insertComm.Parameters.Add("@sysid_schedule", SqlDbType.VarChar).SourceColumn = "sysid_schedule_no_freeze";
                    insertComm.Parameters.Add("@sysid_special", SqlDbType.VarChar).SourceColumn = "sysid_special_no_freeze";
                    insertComm.Parameters.Add("@category_id", SqlDbType.VarChar).SourceColumn = "category_id";

                    insertComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    insertComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlCommand updateComm = new SqlCommand())
                    {

                        updateComm.Connection = auth.Connection;
                        updateComm.CommandType = CommandType.StoredProcedure;
                        updateComm.CommandText = "ums.UpdateTranscriptDetails";

                        updateComm.Parameters.Add("@transcript_id", SqlDbType.BigInt).SourceColumn = "transcript_id";
                        updateComm.Parameters.Add("@term_session", SqlDbType.VarChar).SourceColumn = "term_session";
                        updateComm.Parameters.Add("@subject_code", SqlDbType.VarChar).SourceColumn = "subject_code";
                        updateComm.Parameters.Add("@subject_no", SqlDbType.VarChar).SourceColumn = "subject_no";
                        updateComm.Parameters.Add("@descriptive_title", SqlDbType.VarChar).SourceColumn = "descriptive_title";
                        updateComm.Parameters.Add("@credit_units", SqlDbType.VarChar).SourceColumn = "credit_units";
                        updateComm.Parameters.Add("@final_grade", SqlDbType.VarChar).SourceColumn = "final_grade";
                        updateComm.Parameters.Add("@re_exam", SqlDbType.VarChar).SourceColumn = "re_exam";
                        updateComm.Parameters.Add("@no_of_hours", SqlDbType.VarChar).SourceColumn = "no_of_hours";
                        updateComm.Parameters.Add("@sequence_no", SqlDbType.SmallInt).SourceColumn = "sequence_no";
                        updateComm.Parameters.Add("@sysid_schedule", SqlDbType.VarChar).SourceColumn = "sysid_schedule_no_freeze";
                        updateComm.Parameters.Add("@sysid_special", SqlDbType.VarChar).SourceColumn = "sysid_special_no_freeze";
                        updateComm.Parameters.Add("@category_id", SqlDbType.VarChar).SourceColumn = "category_id";

                        updateComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                        updateComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                        using (SqlCommand deleteComm = new SqlCommand())
                        {
                            deleteComm.Connection = auth.Connection;
                            deleteComm.CommandType = CommandType.StoredProcedure;
                            deleteComm.CommandText = "ums.DeleteTranscriptDetails";

                            deleteComm.Parameters.Add("@transcript_id", SqlDbType.BigInt).SourceColumn = "transcript_id";

                            deleteComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                            deleteComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                            using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                            {
                                sqlAdapter.InsertCommand = insertComm;
                                sqlAdapter.UpdateCommand = updateComm;
                                sqlAdapter.DeleteCommand = deleteComm;

                                sqlAdapter.Update(transcriptDetailsTable);
                            }
                        }
                    }
                }
            }
        } //-----------------------------------

        
        #endregion

        #region Programmer-Defined Function Procedures

        //this function gets the transcript information table query
        public DataTable SelectTranscriptInformation(CommonExchange.SysAccess userInfo, String queryString)
        {
            DataTable dbTable = new DataTable("TranscriptInformationTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectTranscriptInformation";

                    if (String.IsNullOrEmpty(queryString))
                    {
                        sqlComm.Parameters.Add("@query_string", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@query_string", SqlDbType.VarChar).Value = queryString;
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

        //this function gets the transcript details table query
        public DataTable SelectBySysIDTranscriptDetails(CommonExchange.SysAccess userInfo, String transcriptSysId)
        {
            DataTable dbTable = new DataTable("TranscriptDetailsTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDTranscriptDetails";

                    sqlComm.Parameters.Add("@sysid_transcript", SqlDbType.VarChar).Value = transcriptSysId;

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

        /// <summary>
        /// This function returns the transcript information details
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public DataTable SelectByStudentIDTranscriptDetails(CommonExchange.SysAccess userInfo, String studentId)
        {
            DataTable dbTable = new DataTable("TranscriptDetailsTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectByStudentIDTranscriptDetails";

                    sqlComm.Parameters.Add("@student_id", SqlDbType.VarChar).Value = studentId;

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

        /// <summary>
        /// This function returns the transcript details by student id list and semester sysid
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="studentIdList"></param>
        /// <param name="semesterSysId"></param>
        /// <returns></returns>
        public DataTable SelectBySysIDScheduleSpecialListTranscriptDetails(CommonExchange.SysAccess userInfo, String studentIdList, String semesterSysId)
        {
            DataTable dbTable = new DataTable("TranscriptDetailsByStudentListTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDScheduleSpecialListTranscriptDetails";

                    sqlComm.Parameters.Add("@student_id_list", SqlDbType.NVarChar).Value = studentIdList;
                    sqlComm.Parameters.Add("@sysid_semester", SqlDbType.VarChar).Value = semesterSysId;

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

        //this function gets the transcript information images by sysid_transcript list
        public DataTable SelectTranscriptImagesTranscriptInformation(CommonExchange.SysAccess userInfo, String transcriptSysIdList)
        {
            DataTable dbTable = new DataTable("PersonImagesTable");
            dbTable.Columns.Add("sysid_transcript", System.Type.GetType("System.String"));
            dbTable.Columns.Add("file_data", System.Type.GetType("System.Byte[]"));
            dbTable.Columns.Add("original_name", System.Type.GetType("System.String"));

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectTranscriptImagesTranscriptInformation";

                    sqlComm.Parameters.Add("@sysid_transcript_list", SqlDbType.NVarChar).Value = transcriptSysIdList;
                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                DataRow newRow = dbTable.NewRow();

                                newRow["sysid_transcript"] = sqlReader["sysid_transcript"];
                                newRow["file_data"] = sqlReader["file_data"];
                                newRow["original_name"] = sqlReader["original_name"];

                                dbTable.Rows.Add(newRow);
                            }
                        }

                        sqlReader.Close();
                    }
                }

                dbTable.AcceptChanges();
            }

            return dbTable;

        } //------------------------------

        //this function is used to determine if the student id exists
        public Boolean IsExistStudentIDTranscriptInformation(CommonExchange.SysAccess userInfo, String studentId, String transcriptSysId)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsExistStudentIDTranscriptInformation";

                    sqlComm.Parameters.Add("@sysid_transcript", SqlDbType.VarChar).Value = transcriptSysId;
                    sqlComm.Parameters.Add("@student_id", SqlDbType.VarChar).Value = studentId;
                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;
        } //-----------------------------   

        //this function is used to get data tables stored in one dataset used for transcript information
        public DataSet GetDataSetForTranscriptInfo(CommonExchange.SysAccess userInfo)
        {
            DataSet dbSet = new DataSet();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                //gets the subject category table
                dbSet.Tables.Add(ProcStatic.GetSubjectCategoryTable(auth.Connection, userInfo.UserId));
                //-------------------------------------
            }

            return dbSet;
        } //----------------------------------

        #endregion
    }
}
