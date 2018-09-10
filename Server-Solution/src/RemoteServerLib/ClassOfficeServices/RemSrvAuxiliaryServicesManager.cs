using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteServerLib
{
    public class RemSrvAuxiliaryServicesManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvAuxiliaryServicesManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new auxiliary service information
        public void InsertAuxiliaryServiceInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.AuxiliaryServiceInformation serviceInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                serviceInfo.AuxServiceSysId = PrimaryKeys.GetNewAuxiliaryServiceInformationSystemID(userInfo, auth.Connection);

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertAuxiliaryServiceInformation";

                    sqlComm.Parameters.Add("@sysid_auxservice", SqlDbType.VarChar).Value = serviceInfo.AuxServiceSysId;
                    sqlComm.Parameters.Add("@course_group_id", SqlDbType.VarChar).Value = serviceInfo.CourseGroupInfo.CourseGroupId;
                    sqlComm.Parameters.Add("@department_id", SqlDbType.VarChar).Value = serviceInfo.DepartmentInfo.DepartmentId;
                    sqlComm.Parameters.Add("@service_code", SqlDbType.VarChar).Value = serviceInfo.ServiceCode;
                    sqlComm.Parameters.Add("@descriptive_title", SqlDbType.VarChar).Value = serviceInfo.DescriptiveTitle;
                    sqlComm.Parameters.Add("@lecture_units", SqlDbType.TinyInt).Value = serviceInfo.LectureUnits;
                    sqlComm.Parameters.Add("@lab_units", SqlDbType.TinyInt).Value = serviceInfo.LabUnits;
                    sqlComm.Parameters.Add("@no_hours", SqlDbType.VarChar).Value = serviceInfo.NoHours;
                    sqlComm.Parameters.Add("@other_information", SqlDbType.VarChar).Value = serviceInfo.OtherInformation;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
                
            }

        } //---------------------------------

        //this procedure updates an auxiliary service information
        public void UpdateAuxiliaryServiceInformation(CommonExchange.SysAccess userInfo, CommonExchange.AuxiliaryServiceInformation serviceInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateAuxiliaryServiceInformation";

                    sqlComm.Parameters.Add("@sysid_auxservice", SqlDbType.VarChar).Value = serviceInfo.AuxServiceSysId;
                    sqlComm.Parameters.Add("@department_id", SqlDbType.VarChar).Value = serviceInfo.DepartmentInfo.DepartmentId;
                    sqlComm.Parameters.Add("@service_code", SqlDbType.VarChar).Value = serviceInfo.ServiceCode;
                    sqlComm.Parameters.Add("@descriptive_title", SqlDbType.VarChar).Value = serviceInfo.DescriptiveTitle;
                    sqlComm.Parameters.Add("@lecture_units", SqlDbType.TinyInt).Value = serviceInfo.LectureUnits;
                    sqlComm.Parameters.Add("@lab_units", SqlDbType.TinyInt).Value = serviceInfo.LabUnits;
                    sqlComm.Parameters.Add("@no_hours", SqlDbType.VarChar).Value = serviceInfo.NoHours;
                    sqlComm.Parameters.Add("@other_information", SqlDbType.VarChar).Value = serviceInfo.OtherInformation;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }

            }

        } //---------------------------------

        //this procedure inserts a new auxiliary service schedule
        public void InsertAuxiliaryServiceSchedule(CommonExchange.SysAccess userInfo, ref CommonExchange.AuxiliaryServiceSchedule serviceScheduleInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                serviceScheduleInfo.AuxServiceScheduleSysId = PrimaryKeys.GetNewAuxiliaryServiceScheduleSystemID(userInfo, auth.Connection);

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertAuxiliaryServiceSchedule";

                    sqlComm.Parameters.Add("@sysid_auxserviceschedule", SqlDbType.VarChar).Value = serviceScheduleInfo.AuxServiceScheduleSysId;
                    sqlComm.Parameters.Add("@sysid_auxservice", SqlDbType.VarChar).Value = serviceScheduleInfo.AuxiliaryServiceInfo.AuxServiceSysId;
                    sqlComm.Parameters.Add("@year_id", SqlDbType.VarChar).Value = serviceScheduleInfo.SchoolYearInfo.YearId;
                    sqlComm.Parameters.Add("@sysid_semester", SqlDbType.VarChar).Value = serviceScheduleInfo.SemesterInfo.SemesterSysId;
                    sqlComm.Parameters.Add("@is_fixed_amount", SqlDbType.Bit).Value = serviceScheduleInfo.IsFixedAmount;
                    sqlComm.Parameters.Add("@amount", SqlDbType.Decimal).Value = serviceScheduleInfo.Amount;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }

            }

        } //----------------------------------------

        //this procedure updates an auxiliary service schedule
        public void UpdateAuxiliaryServiceSchedule(CommonExchange.SysAccess userInfo, CommonExchange.AuxiliaryServiceSchedule serviceScheduleInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateAuxiliaryServiceSchedule";

                    sqlComm.Parameters.Add("@sysid_auxserviceschedule", SqlDbType.VarChar).Value = serviceScheduleInfo.AuxServiceScheduleSysId;
                    sqlComm.Parameters.Add("@is_fixed_amount", SqlDbType.Bit).Value = serviceScheduleInfo.IsFixedAmount;
                    sqlComm.Parameters.Add("@amount", SqlDbType.Decimal).Value = serviceScheduleInfo.Amount;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }

            }

        } //----------------------------------------

        //this procedure deletes an auxiliary service schedule
        public void DeleteAuxiliaryServiceSchedule(CommonExchange.SysAccess userInfo, CommonExchange.AuxiliaryServiceSchedule serviceScheduleInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.DeleteAuxiliaryServiceSchedule";

                    sqlComm.Parameters.Add("@sysid_auxserviceschedule", SqlDbType.VarChar).Value = serviceScheduleInfo.AuxServiceScheduleSysId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }

        } //----------------------------------------


        //this procedure inserts a new auxiliary service details
        public void InsertAuxiliaryServiceDetails(CommonExchange.SysAccess userInfo, ref CommonExchange.AuxiliaryServiceDetails serviceDetailsInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                serviceDetailsInfo.AuxServiceDetailsSysId = PrimaryKeys.GetNewAuxiliaryServiceDetailsSystemID(userInfo, auth.Connection);

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertAuxiliaryServiceDetails";

                    sqlComm.Parameters.Add("@sysid_auxdetails", SqlDbType.VarChar).Value = serviceDetailsInfo.AuxServiceDetailsSysId;
                    sqlComm.Parameters.Add("@sysid_auxserviceschedule", SqlDbType.VarChar).Value = 
                        serviceDetailsInfo.AuxiliaryServiceScheduleInfo.AuxServiceScheduleSysId;
                    sqlComm.Parameters.Add("@lecture_units", SqlDbType.Float).Value = serviceDetailsInfo.LectureUnits;
                    sqlComm.Parameters.Add("@lab_units", SqlDbType.Float).Value = serviceDetailsInfo.LabUnits;
                    sqlComm.Parameters.Add("@no_hours", SqlDbType.VarChar).Value = serviceDetailsInfo.NoHours;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }

        } //-------------------------------------------------

        //this procedure updates an auxiliary service details
        public void UpdateAuxiliaryServiceDetails(CommonExchange.SysAccess userInfo, CommonExchange.AuxiliaryServiceDetails serviceDetailsInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateAuxiliaryServiceDetails";

                    sqlComm.Parameters.Add("@sysid_auxdetails", SqlDbType.VarChar).Value = serviceDetailsInfo.AuxServiceDetailsSysId;
                    sqlComm.Parameters.Add("@lecture_units", SqlDbType.Float).Value = serviceDetailsInfo.LectureUnits;
                    sqlComm.Parameters.Add("@lab_units", SqlDbType.Float).Value = serviceDetailsInfo.LabUnits;
                    sqlComm.Parameters.Add("@no_hours", SqlDbType.VarChar).Value = serviceDetailsInfo.NoHours;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //------------------------------------------

        
        //this procedure deletes an auxiliary service details
        public void DeleteAuxiliaryServiceDetails(CommonExchange.SysAccess userInfo, CommonExchange.AuxiliaryServiceDetails serviceDetailsInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.DeleteAuxiliaryServiceDetails";

                    sqlComm.Parameters.Add("@sysid_auxdetails", SqlDbType.VarChar).Value = serviceDetailsInfo.AuxServiceDetailsSysId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------------------


        #endregion

        #region Programmer-Defined Function Procedures

        //this function is used to get the service information by service code or title
        public DataTable SelectByServiceCodeTitleAuxiliaryServiceInformation(CommonExchange.SysAccess userInfo, String queryString)
        {
            DataTable dbTable = new DataTable("ServiceInformationTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                if (String.Equals(queryString, "*"))
                {
                    using (SqlCommand sqlComm = new SqlCommand())
                    {
                        sqlComm.Connection = auth.Connection;
                        sqlComm.CommandType = CommandType.StoredProcedure;
                        sqlComm.CommandText = "ums.SelectAuxiliaryServiceInformation";

                        sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                        using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                        {
                            sqlAdapter.SelectCommand = sqlComm;
                            sqlAdapter.Fill(dbTable);
                        }
                    } 
                }
                else
                {
                    using (SqlCommand sqlComm = new SqlCommand())
                    {
                        sqlComm.Connection = auth.Connection;
                        sqlComm.CommandType = CommandType.StoredProcedure;
                        sqlComm.CommandText = "ums.SelectByServiceCodeTitleAuxiliaryServiceInformation";

                        sqlComm.Parameters.Add("@query_string", SqlDbType.VarChar).Value = queryString;
                        sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                        using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                        {
                            sqlAdapter.SelectCommand = sqlComm;
                            sqlAdapter.Fill(dbTable);
                        }
                    } 

                }
            }

            return dbTable;
        } //------------------------------------------

        //this function is used to get the auxiliary service details by date start and date end
        public DataTable SelectByDateStartEndAuxiliaryServiceDetails(CommonExchange.SysAccess userInfo, String queryString,
            String dateStart, String dateEnd, Boolean isMarkedDeleted)
        {
            DataTable dbTable = new DataTable("AuxiliaryServiceDetailsByDateStartEndTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectByDateStartEndAuxiliaryServiceDetails";

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

        //this function determines if the auxiliary service code and descriptive title exist
        public Boolean IsExistCodeDescriptionAuxiliaryServiceInformation(CommonExchange.SysAccess userInfo, 
            CommonExchange.AuxiliaryServiceInformation serviceInfo)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsExistCodeDescriptionAuxiliaryServiceInformation";

                    sqlComm.Parameters.Add("@sysid_auxservice", SqlDbType.VarChar).Value = serviceInfo.AuxServiceSysId;
                    sqlComm.Parameters.Add("@service_code", SqlDbType.VarChar).Value = serviceInfo.ServiceCode;
                    sqlComm.Parameters.Add("@descriptive_title", SqlDbType.VarChar).Value = serviceInfo.DescriptiveTitle;
                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;

        } //------------------------------

        //this function is used to get data tables stored in one dataset used for auxiliary service
        public DataSet GetDataSetForAuxiliaryService(CommonExchange.SysAccess userInfo, String serverDateTime)
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

                //gets the course group table
                dbSet.Tables.Add(ProcStatic.GetCourseGroupTable(auth.Connection, userInfo.UserId));
                //-----------------------------

                //gets the department information table
                dbSet.Tables.Add(ProcStatic.GetDepartmentInformationTable(auth.Connection, userInfo.UserId));
                //-------------------------------------
                            
            }

            return dbSet;
        } //---------------------------------

        #endregion
    }
}
