using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteServerLib
{
    public class RemSrvSchoolFeeManager : MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvSchoolFeeManager() { }

        void IDisposable.Dispose() { }
        #endregion    

        #region Programmer-Defined Void Procedures

        //this procedure inserts a student additional fee
        public void InsertStudentAdditionalFee(CommonExchange.SysAccess userInfo, CommonExchange.StudentAdditionalFee additionalFee)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertStudentAdditionalFee";

                    sqlComm.Parameters.Add("@sysid_enrolmentlevel", SqlDbType.VarChar).Value = additionalFee.StudentEnrolmentLevelInfo.EnrolmentLevelSysId;
                    sqlComm.Parameters.Add("@sysid_feeparticular", SqlDbType.VarChar).Value = additionalFee.SchoolFeeParticularInfo.FeeParticularSysId;
                    sqlComm.Parameters.Add("@amount", SqlDbType.Decimal).Value = additionalFee.Amount;
                    sqlComm.Parameters.Add("@remarks", SqlDbType.VarChar).Value = additionalFee.Remarks;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------

        //this procedure inserts a student additional fee
        public void InsertStudentAdditionalFeeTable(CommonExchange.SysAccess userInfo, DataTable additionalFeeTable)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand insertComm = new SqlCommand())
                {
                    insertComm.Connection = auth.Connection;
                    insertComm.CommandType = CommandType.StoredProcedure;
                    insertComm.CommandText = "ums.InsertStudentAdditionalFee";

                    insertComm.Parameters.Add("@sysid_enrolmentlevel", SqlDbType.VarChar).SourceColumn = "sysid_enrolmentlevel";
                    insertComm.Parameters.Add("@sysid_feeparticular", SqlDbType.VarChar).SourceColumn = "sysid_feeparticular";
                    insertComm.Parameters.Add("@amount", SqlDbType.Decimal).SourceColumn = "amount";
                    insertComm.Parameters.Add("@remarks", SqlDbType.VarChar).SourceColumn = "remarks";

                    insertComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    insertComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                    {
                        sqlAdapter.InsertCommand = insertComm;

                        sqlAdapter.Update(additionalFeeTable);
                    }
                }
            }
        } //-----------------------------------

        //this procedure updates a student additional fee
        public void UpdateStudentAdditionalFee(CommonExchange.SysAccess userInfo, CommonExchange.StudentAdditionalFee additionalFee)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateStudentAdditionalFee";

                    sqlComm.Parameters.Add("@additional_fee_id", SqlDbType.BigInt).Value = additionalFee.AdditionalFeeId;
                    sqlComm.Parameters.Add("@sysid_feeparticular", SqlDbType.VarChar).Value = additionalFee.SchoolFeeParticularInfo.FeeParticularSysId;
                    sqlComm.Parameters.Add("@amount", SqlDbType.Decimal).Value = additionalFee.Amount;
                    sqlComm.Parameters.Add("@remarks", SqlDbType.VarChar).Value = additionalFee.Remarks;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------

        //this procedure deletes a student additional fee
        public void DeleteStudentAdditionalFee(CommonExchange.SysAccess userInfo, CommonExchange.StudentAdditionalFee additionalFee)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.DeleteStudentAdditionalFee";

                    sqlComm.Parameters.Add("@additional_fee_id", SqlDbType.BigInt).Value = additionalFee.AdditionalFeeId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-----------------------------------

        //this procedure inserts and delete a student optional fee
        public void InsertDeleteStudentOptionalFee(CommonExchange.SysAccess userInfo, DataTable optionalFeeTable)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand insertComm = new SqlCommand())
                {
                    insertComm.Connection = auth.Connection;
                    insertComm.CommandType = CommandType.StoredProcedure;
                    insertComm.CommandText = "ums.InsertStudentOptionalFee";

                    insertComm.Parameters.Add("@sysid_enrolmentlevel", SqlDbType.VarChar).SourceColumn = "sysid_enrolmentlevel";
                    insertComm.Parameters.Add("@sysid_feedetails", SqlDbType.VarChar).SourceColumn = "sysid_feedetails";

                    insertComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    insertComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlCommand deleteComm = new SqlCommand())
                    {
                        deleteComm.Connection = auth.Connection;
                        deleteComm.CommandType = CommandType.StoredProcedure;
                        deleteComm.CommandText = "ums.DeleteStudentOptionalFee";

                        deleteComm.Parameters.Add("@optional_fee_id", SqlDbType.BigInt).SourceColumn = "optional_fee_id";

                        deleteComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                        deleteComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                        using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                        {
                            sqlAdapter.InsertCommand = insertComm;
                            sqlAdapter.DeleteCommand = deleteComm;

                            sqlAdapter.Update(optionalFeeTable);
                        }
                    }
                }
            }

        } //-----------------------------------

        //this procedure inserts a new school fee details
        public void InsertSchoolFeeDetails(CommonExchange.SysAccess userInfo, ref CommonExchange.SchoolFeeDetails detailsInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                detailsInfo.FeeDetailsSysId = PrimaryKeys.GetNewSchoolFeeDetailsSystemID(userInfo, auth.Connection);

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertSchoolFeeDetails";

                    sqlComm.Parameters.Add("@sysid_feedetails", SqlDbType.VarChar).Value = detailsInfo.FeeDetailsSysId;
                    sqlComm.Parameters.Add("@sysid_feelevel", SqlDbType.VarChar).Value = detailsInfo.SchoolFeeLevelInfo.FeeLevelSysId;
                    sqlComm.Parameters.Add("@sysid_feeparticular", SqlDbType.VarChar).Value = detailsInfo.SchoolFeeParticularInfo.FeeParticularSysId;
                    sqlComm.Parameters.Add("@is_level_increase", SqlDbType.Bit).Value = detailsInfo.IsLevelIncrease;
                    sqlComm.Parameters.Add("@amount", SqlDbType.Decimal).Value = detailsInfo.Amount;
                    sqlComm.Parameters.Add("@is_optional", SqlDbType.Bit).Value = detailsInfo.IsOptional;
                    sqlComm.Parameters.Add("@is_office_access", SqlDbType.Bit).Value = detailsInfo.IsOfficeAccess;
                    sqlComm.Parameters.Add("@is_entry_level_included", SqlDbType.Bit).Value = detailsInfo.IsEntryLevelIncluded;
                    sqlComm.Parameters.Add("@is_graduation_fee", SqlDbType.Bit).Value = detailsInfo.IsGraduationFee;
                    sqlComm.Parameters.Add("@include_first_semester", SqlDbType.Bit).Value = detailsInfo.IncludeFirstSemester;
                    sqlComm.Parameters.Add("@include_second_semester", SqlDbType.Bit).Value = detailsInfo.IncludeSecondSemester;
                    sqlComm.Parameters.Add("@include_summer", SqlDbType.Bit).Value = detailsInfo.IncludeSummer;
                    sqlComm.Parameters.Add("@include_male", SqlDbType.Bit).Value = detailsInfo.IncludeMale;
                    sqlComm.Parameters.Add("@include_female", SqlDbType.Bit).Value = detailsInfo.IncludeFemale;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //--------------------------------------

        //this procedure update a school fee details
        public void UpdateSchoolFeeDetails(CommonExchange.SysAccess userInfo, CommonExchange.SchoolFeeDetails detailsInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateSchoolFeeDetails";

                    sqlComm.Parameters.Add("@sysid_feedetails", SqlDbType.VarChar).Value = detailsInfo.FeeDetailsSysId;
                    sqlComm.Parameters.Add("@sysid_feeparticular", SqlDbType.VarChar).Value = detailsInfo.SchoolFeeParticularInfo.FeeParticularSysId;
                    sqlComm.Parameters.Add("@is_level_increase", SqlDbType.Bit).Value = detailsInfo.IsLevelIncrease;
                    sqlComm.Parameters.Add("@amount", SqlDbType.Decimal).Value = detailsInfo.Amount;
                    sqlComm.Parameters.Add("@is_optional", SqlDbType.Bit).Value = detailsInfo.IsOptional;
                    sqlComm.Parameters.Add("@is_office_access", SqlDbType.Bit).Value = detailsInfo.IsOfficeAccess;
                    sqlComm.Parameters.Add("@is_entry_level_included", SqlDbType.Bit).Value = detailsInfo.IsEntryLevelIncluded;
                    sqlComm.Parameters.Add("@is_graduation_fee", SqlDbType.Bit).Value = detailsInfo.IsGraduationFee;
                    sqlComm.Parameters.Add("@include_first_semester", SqlDbType.Bit).Value = detailsInfo.IncludeFirstSemester;
                    sqlComm.Parameters.Add("@include_second_semester", SqlDbType.Bit).Value = detailsInfo.IncludeSecondSemester;
                    sqlComm.Parameters.Add("@include_summer", SqlDbType.Bit).Value = detailsInfo.IncludeSummer;
                    sqlComm.Parameters.Add("@include_male", SqlDbType.Bit).Value = detailsInfo.IncludeMale;
                    sqlComm.Parameters.Add("@include_female", SqlDbType.Bit).Value = detailsInfo.IncludeFemale;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //--------------------------------------

        //this procedure delete a school fee details
        public void DeleteSchoolFeeDetails(CommonExchange.SysAccess userInfo, CommonExchange.SchoolFeeDetails detailsInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.DeleteSchoolFeeDetails";

                    sqlComm.Parameters.Add("@sysid_feedetails", SqlDbType.VarChar).Value = detailsInfo.FeeDetailsSysId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //--------------------------------------

        //this procedure inserts a new school fee particular
        public void InsertSchoolFeeParticular(CommonExchange.SysAccess userInfo, ref CommonExchange.SchoolFeeParticular particularInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                particularInfo.FeeParticularSysId = PrimaryKeys.GetNewSchoolFeeParticularSystemID(userInfo, auth.Connection);

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertSchoolFeeParticular";

                    sqlComm.Parameters.Add("@sysid_feeparticular", SqlDbType.VarChar).Value = particularInfo.FeeParticularSysId;
                    sqlComm.Parameters.Add("@fee_category_id", SqlDbType.VarChar).Value = particularInfo.SchoolFeeCategoryInfo.FeeCategoryId;
                    sqlComm.Parameters.Add("@particular_description", SqlDbType.VarChar).Value = particularInfo.ParticularDescription;
                    sqlComm.Parameters.Add("@is_optional", SqlDbType.Bit).Value = particularInfo.IsOptional;
                    sqlComm.Parameters.Add("@is_office_access", SqlDbType.Bit).Value = particularInfo.IsOfficeAccess;
                    sqlComm.Parameters.Add("@is_entry_level_included", SqlDbType.Bit).Value = particularInfo.IsEntryLevelIncluded;
                    sqlComm.Parameters.Add("@is_graduation_fee", SqlDbType.Bit).Value = particularInfo.IsGraduationFee;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //-------------------------------------

        //this procedure updates a school fee particular
        public void UpdateSchoolFeeParticular(CommonExchange.SysAccess userInfo, CommonExchange.SchoolFeeParticular particularInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.UpdateSchoolFeeParticular";

                    sqlComm.Parameters.Add("@sysid_feeparticular", SqlDbType.VarChar).Value = particularInfo.FeeParticularSysId;
                    sqlComm.Parameters.Add("@particular_description", SqlDbType.VarChar).Value = particularInfo.ParticularDescription;
                    sqlComm.Parameters.Add("@is_office_access", SqlDbType.Bit).Value = particularInfo.IsOfficeAccess;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }

        } //-------------------------------------

        //this procedure deletes a school fee particular
        public void DeleteSchoolFeeParticular(CommonExchange.SysAccess userInfo, CommonExchange.SchoolFeeParticular particularInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.DeleteSchoolFeeParticular";

                    sqlComm.Parameters.Add("@sysid_feeparticular", SqlDbType.VarChar).Value = particularInfo.FeeParticularSysId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }

        } //-------------------------------------

        //this procedure inserts a new school fee level
        public void InsertSchoolFeeLevel(CommonExchange.SysAccess userInfo, ref CommonExchange.SchoolFeeLevel levelInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                levelInfo.FeeLevelSysId = PrimaryKeys.GetNewSchoolFeeLevelSystemID(userInfo, auth.Connection);

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertSchoolFeeLevel";

                    sqlComm.Parameters.Add("@sysid_feelevel", SqlDbType.VarChar).Value = levelInfo.FeeLevelSysId;
                    sqlComm.Parameters.Add("@sysid_schoolfee", SqlDbType.VarChar).Value = levelInfo.SchoolFeeInfo.FeeInformationSysId;
                    sqlComm.Parameters.Add("@year_level_id", SqlDbType.VarChar).Value = levelInfo.YearLevelInfo.YearLevelId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //----------------------------------------------

        //this procedure inserts a new school fee information
        public void InsertSchoolFeeInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.SchoolFeeInformation feeInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                feeInfo.FeeInformationSysId = PrimaryKeys.GetNewSchoolFeeInformationSystemID(userInfo, auth.Connection);

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertSchoolFeeInformation";

                    sqlComm.Parameters.Add("@sysid_schoolfee", SqlDbType.VarChar).Value = feeInfo.FeeInformationSysId;
                    sqlComm.Parameters.Add("@year_id", SqlDbType.VarChar).Value = feeInfo.SchoolYearInfo.YearId;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }
        } //----------------------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function gets the additional fee table query
        public DataTable SelectStudentAdditionalFee(CommonExchange.SysAccess userInfo, String queryString, String dateStart, String dateEnd,
            String courseIdList, String yearLevelIdList)
        {
            DataTable dbTable = new DataTable("StudentAdditionalFeeTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectStudentAdditionalFee";

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

        //this function gets the additional fee table query by sysid_student date start end
        public DataTable SelectBySysIDStudentDateStartEndStudentAdditionalFee(CommonExchange.SysAccess userInfo, String studentSysId, 
            String dateStart, String dateEnd)
        {
            DataTable dbTable = new DataTable("StudentAdditionalFeeByDateStartEndTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDStudentDateStartEndStudentAdditionalFee";

                    sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = studentSysId;
                    sqlComm.Parameters.Add("@date_start", SqlDbType.DateTime).Value = DateTime.Parse(dateStart);
                    sqlComm.Parameters.Add("@date_end", SqlDbType.DateTime).Value = DateTime.Parse(dateEnd);

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

        //this procedure returns the selected school fee details by date start and end 
        public DataTable SelectByDateStartEndSchoolFeeDetails(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd)
        {
            DataTable dbTable = new DataTable("SchoolFeeDetailsByDateStartEndTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectByDateStartEndSchoolFeeDetails";

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

        //this procedure returns the selected school fee level by date start and end 
        public DataTable SelectBySysIDSchoolFeeSchoolFeeLevel(CommonExchange.SysAccess userInfo, String schoolFeeSysId)
        {
            DataTable dbTable = new DataTable("SchoolFeeLevelBySysIdSchoolFeeTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDSchoolFeeSchoolFeeLevel";

                    sqlComm.Parameters.Add("@sysid_schoolfee", SqlDbType.VarChar).Value = schoolFeeSysId;

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

        //this procedure returns the optional school fee details by student system id, fee level system id
        public DataTable SelectBySysIDStudentFeeLevelSemesterForOptionalFeeDetailsStudentOptionalFee(CommonExchange.SysAccess userInfo, String studentSysId,
            String feeLevelSysId, String semesterSysId, Boolean isInternational)
        {
            DataTable dbTable = new DataTable("OptionalSchoolFeeDetailsBySysIDStudentFeeLevelSemesterTable");

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandTimeout = 500000;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDStudentFeeLevelSemesterForOptionalFeeDetailsStudentOptionalFee";

                    sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = studentSysId;
                    sqlComm.Parameters.Add("@sysid_feelevel", SqlDbType.VarChar).Value = feeLevelSysId;
                    sqlComm.Parameters.Add("@sysid_semester", SqlDbType.VarChar).Value = semesterSysId;
                    sqlComm.Parameters.Add("@is_international", SqlDbType.Bit).Value = isInternational;

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

        //this function is used to determine if the school fee information and the year level id already exists
        public Boolean IsExistsSchoolFeeYearLevel(CommonExchange.SysAccess userInfo, CommonExchange.SchoolFeeLevel levelInfo)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsExistsSchoolFeeYearLevel";

                    sqlComm.Parameters.Add("@sysid_schoolfee", SqlDbType.VarChar).Value = levelInfo.SchoolFeeInfo.FeeInformationSysId;
                    sqlComm.Parameters.Add("@year_level_id", SqlDbType.VarChar).Value = levelInfo.YearLevelInfo.YearLevelId;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;
        } //------------------------------

        //this function is used to determine if the year id for the school fee information already exists
        public Boolean IsExistsYearIDSchoolFeeInformation(CommonExchange.SysAccess userInfo, CommonExchange.SchoolFeeInformation feeInfo)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsExistsYearIDSchoolFeeInformation";

                    sqlComm.Parameters.Add("@year_id", SqlDbType.VarChar).Value = feeInfo.SchoolYearInfo.YearId;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;
        } //------------------------------
        

        //this function is used to determine if the particular description exists
        public Boolean IsExistsParticularDescriptionSchoolFeeParticular(CommonExchange.SysAccess userInfo, String particularSysId, String particularDescription)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsExistsParticularDescriptionSchoolFeeParticular";

                    sqlComm.Parameters.Add("@sysid_feeparticular", SqlDbType.VarChar).Value = particularSysId;
                    sqlComm.Parameters.Add("@particular_description", SqlDbType.VarChar).Value = particularDescription;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;
        } //-----------------------------  

        //this function is sued to determine if the year level and particular already exists
        public Boolean IsExistsLevelParticularSchoolFeeDetails(CommonExchange.SysAccess userInfo, String feeLevelSysId, String particularSysId)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsExistsLevelParticularSchoolFeeDetails";

                    sqlComm.Parameters.Add("@sysid_feelevel", SqlDbType.VarChar).Value = feeLevelSysId;
                    sqlComm.Parameters.Add("@sysid_feeparticular", SqlDbType.VarChar).Value = particularSysId;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;
        } //----------------------------------

        //this function is used to get data tables stored in one dataset used for school fee
        public DataSet GetDataSetForSchoolFee(CommonExchange.SysAccess userInfo, String serverDateTime)
        {
            DataSet dbSet = new DataSet();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                //gets the school year table
                dbSet.Tables.Add(ProcStatic.GetSchoolYearTable(auth.Connection, userInfo.UserId, serverDateTime));
                //------------------------------------

                //gets the school fee category table
                dbSet.Tables.Add(ProcStatic.GetSchoolFeeCategoryTable(auth.Connection, userInfo.UserId));
                //--------------------------------

                //get the school fee particular table
                dbSet.Tables.Add(ProcStatic.GetSchoolFeeParticularTable(auth.Connection, userInfo.UserId));
                //--------------------------------

                //get the school fee information table
                dbSet.Tables.Add(ProcStatic.GetSchoolFeeInformationTable(auth.Connection, userInfo.UserId, serverDateTime));
                //--------------------------------
               
                //get the course group table
                dbSet.Tables.Add(ProcStatic.GetCourseGroupTable(auth.Connection, userInfo.UserId));
                //--------------------------------

                //get the year level table
                dbSet.Tables.Add(ProcStatic.GetYearLevelInformationTable(auth.Connection, userInfo.UserId));
                //--------------------------------
                
            }

            return dbSet;
        } //----------------------------------

        #endregion
    }
}
