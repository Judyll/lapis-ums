using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace RemoteServerLib
{
    public class RemSrvBaseManager: MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvBaseManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts or updates a person infomation
        public void InsertUpdatePersonInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.Person personInfo)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                this.InsertUpdatePersonInformationNoAuthenticate(userInfo, auth.Connection, ref personInfo);
            }

        } //-------------------------------------

        //this procedure inserts or updates a person information
        public void InsertUpdatePersonInformationNoAuthenticate(CommonExchange.SysAccess userInfo, SqlConnection sqlConn, ref CommonExchange.Person personInfo)
        {
            if (personInfo.ObjectState == DataRowState.Added || personInfo.ObjectState == DataRowState.Modified)
            {

                if (String.IsNullOrEmpty(personInfo.PersonSysId) ||
                    (!PrimaryKeys.IsExistsSysIDPersonInformation(userInfo.UserId, sqlConn, personInfo.PersonSysId)))
                {
                    personInfo.PersonSysId = PrimaryKeys.GetNewPersonInformationSystemID(userInfo, sqlConn);
                }

                using (SqlCommand personComm = new SqlCommand())
                {
                    personComm.Connection = sqlConn;
                    personComm.CommandType = CommandType.StoredProcedure;
                    personComm.CommandText = "ums.InsertUpdatePersonInformation";

                    personComm.Parameters.Add("@sysid_person", SqlDbType.VarChar).Value = personInfo.PersonSysId;
                    personComm.Parameters.Add("@e_code", SqlDbType.VarChar).Value = personInfo.ECode;
                    personComm.Parameters.Add("@last_name", SqlDbType.VarChar).Value = personInfo.LastName;
                    personComm.Parameters.Add("@first_name", SqlDbType.VarChar).Value = personInfo.FirstName;
                    personComm.Parameters.Add("@middle_name", SqlDbType.VarChar).Value = personInfo.MiddleName;

                    if (String.IsNullOrEmpty(personInfo.LifeStatusCode.CodeReferenceId))
                    {
                        personComm.Parameters.Add("@life_status_code", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        personComm.Parameters.Add("@life_status_code", SqlDbType.VarChar).Value = personInfo.LifeStatusCode.CodeReferenceId;
                    }

                    if (String.IsNullOrEmpty(personInfo.GenderCode.CodeReferenceId))
                    {
                        personComm.Parameters.Add("@gender_code", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        personComm.Parameters.Add("@gender_code", SqlDbType.VarChar).Value = personInfo.GenderCode.CodeReferenceId;
                    }

                    DateTime bDate = DateTime.MinValue;

                    if (DateTime.TryParse(personInfo.BirthDate, out bDate) && DateTime.Compare(bDate, DateTime.MinValue) != 0)
                    {
                        personComm.Parameters.Add("@birthdate", SqlDbType.DateTime).Value = bDate;
                    }
                    else
                    {
                        personComm.Parameters.Add("@birthdate", SqlDbType.DateTime).Value = DBNull.Value;
                    }

                    personComm.Parameters.Add("@place_birth", SqlDbType.VarChar).Value = personInfo.PlaceOfBirth;
                    personComm.Parameters.Add("@email_address", SqlDbType.VarChar).Value = personInfo.EMailAddress;
                    personComm.Parameters.Add("@present_address", SqlDbType.VarChar).Value = personInfo.PresentAddress;
                    personComm.Parameters.Add("@present_phone_nos", SqlDbType.VarChar).Value = personInfo.PresentPhoneNos;
                    personComm.Parameters.Add("@home_address", SqlDbType.VarChar).Value = personInfo.HomeAddress;
                    personComm.Parameters.Add("@home_phone_nos", SqlDbType.VarChar).Value = personInfo.HomePhoneNos;
                    personComm.Parameters.Add("@citizenship", SqlDbType.VarChar).Value = personInfo.Citizenship;
                    personComm.Parameters.Add("@nationality", SqlDbType.VarChar).Value = personInfo.Nationality;
                    personComm.Parameters.Add("@religion", SqlDbType.VarChar).Value = personInfo.Religion;

                    if (String.IsNullOrEmpty(personInfo.MaritalStatusCode.CodeReferenceId))
                    {
                        personComm.Parameters.Add("@marital_status_code", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        personComm.Parameters.Add("@marital_status_code", SqlDbType.VarChar).Value = personInfo.MaritalStatusCode.CodeReferenceId;
                    }

                    DateTime mDate = DateTime.MinValue;

                    if (DateTime.TryParse(personInfo.MarriageDate, out mDate) && DateTime.Compare(mDate, DateTime.MinValue) != 0)
                    {
                        personComm.Parameters.Add("@marriage_date", SqlDbType.DateTime).Value = mDate;
                    }
                    else
                    {
                        personComm.Parameters.Add("@marriage_date", SqlDbType.DateTime).Value = DBNull.Value;
                    }

                    personComm.Parameters.Add("@other_person_information", SqlDbType.VarChar).Value = personInfo.OtherPersonInformation;

                    personComm.Parameters.Add("@for_employee", SqlDbType.Bit).Value = personInfo.ForEmployee;
                    personComm.Parameters.Add("@for_student", SqlDbType.Bit).Value = personInfo.ForStudent;
                    personComm.Parameters.Add("@for_login", SqlDbType.Bit).Value = personInfo.ForLogin;

                    personComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    personComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    personComm.ExecuteNonQuery();
                }

                if (ProcStatic.IsSystemAccessAdmin(userInfo))
                {
                    if (personInfo.FileData != null && !String.IsNullOrEmpty(personInfo.FileName) &&
                        !String.IsNullOrEmpty(personInfo.FileExtension))
                    {
                        using (SqlCommand imageComm = new SqlCommand())
                        {
                            imageComm.Connection = sqlConn;
                            imageComm.CommandType = CommandType.StoredProcedure;
                            imageComm.CommandText = "ums.InsertUpdatePersonImage";

                            imageComm.Parameters.Add("@sysid_person", SqlDbType.VarChar).Value = personInfo.PersonSysId;
                            imageComm.Parameters.Add("@file_data", SqlDbType.VarBinary).Value = personInfo.FileData;
                            imageComm.Parameters.Add("@original_name", SqlDbType.VarChar).Value = personInfo.PersonSysId + personInfo.FileExtension;

                            imageComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                            imageComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                            imageComm.ExecuteNonQuery();
                        }

                    }
                }
            }

            //checks if there is a person relationship that will be deleted
            foreach (CommonExchange.PersonRelationship pRelationship in personInfo.PersonRelationshipList)
            {
                if (pRelationship.ObjectState == DataRowState.Deleted)
                {
                    using (SqlCommand sqlComm = new SqlCommand())
                    {
                        sqlComm.Connection = sqlConn;
                        sqlComm.CommandType = CommandType.StoredProcedure;
                        sqlComm.CommandText = "ums.DeletePersonRelationshipInformation";

                        sqlComm.Parameters.Add("@relationship_id", SqlDbType.BigInt).Value = pRelationship.RelationshipId;

                        sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                        sqlComm.Parameters.Add("@deleted_by", SqlDbType.VarChar).Value = userInfo.UserId;

                        sqlComm.ExecuteNonQuery();
                    }
                }
            }

            foreach (CommonExchange.PersonRelationship pRelationship in personInfo.PersonRelationshipList)
            {
                if (pRelationship.ObjectState == DataRowState.Added)
                {
                    using (SqlCommand sqlComm = new SqlCommand())
                    {
                        sqlComm.Connection = sqlConn;
                        sqlComm.CommandType = CommandType.StoredProcedure;
                        sqlComm.CommandText = "ums.InsertPersonRelationshipInformation";

                        sqlComm.Parameters.Add("@sysid_person", SqlDbType.VarChar).Value = personInfo.PersonSysId;
                        sqlComm.Parameters.Add("@in_relationship_with_sysid_person", SqlDbType.VarChar).Value = pRelationship.PersonInRelationshipWith.PersonSysId;
                        sqlComm.Parameters.Add("@relationship_type_id", SqlDbType.VarChar).Value = pRelationship.RelationshipTypeInfo.RelationshipTypeId;
                        sqlComm.Parameters.Add("@is_emergency_contact", SqlDbType.Bit).Value = pRelationship.IsEmergencyContact;

                        sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                        sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                        sqlComm.ExecuteNonQuery();
                    }
                }
                else if (pRelationship.ObjectState == DataRowState.Modified)
                {
                    using (SqlCommand sqlComm = new SqlCommand())
                    {
                        sqlComm.Connection = sqlConn;
                        sqlComm.CommandType = CommandType.StoredProcedure;
                        sqlComm.CommandText = "ums.UpdatePersonRelationshipInformation";

                        sqlComm.Parameters.Add("@relationship_id", SqlDbType.BigInt).Value = pRelationship.RelationshipId;
                        sqlComm.Parameters.Add("@relationship_type_id", SqlDbType.VarChar).Value = pRelationship.RelationshipTypeInfo.RelationshipTypeId;
                        sqlComm.Parameters.Add("@is_emergency_contact", SqlDbType.Bit).Value = pRelationship.IsEmergencyContact;

                        sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                        sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                        sqlComm.ExecuteNonQuery();
                    }
                }
            }

        } //-------------------------------------------

        //this procedure inserts a new payroll standard
        public void InsertPayrollStandard(CommonExchange.SysAccess userInfo, ref CommonExchange.PayrollStandard stdPayroll)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                stdPayroll.PayrollStandardSysId = PrimaryKeys.GetNewPayrollStandardSystemID(userInfo, auth.Connection);

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertPayrollStandard";

                    sqlComm.Parameters.Add("@sysid_payrollstd", SqlDbType.VarChar).Value = stdPayroll.PayrollStandardSysId;
                    sqlComm.Parameters.Add("@payroll_cuttoff_day", SqlDbType.TinyInt).Value = stdPayroll.PayrollCutOffDay;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }

        } //-------------------------------------

        //this procedure inserts a new registrar standard
        public void InsertRegistrarStandard(CommonExchange.SysAccess userInfo, ref CommonExchange.RegistrarStandard stdRegistrar)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                stdRegistrar.RegistrarStandardSysId = PrimaryKeys.GetNewRegistrarStandardSystemID(userInfo, auth.Connection);

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertRegistrarStandard";

                    sqlComm.Parameters.Add("@sysid_registrarstd", SqlDbType.VarChar).Value = stdRegistrar.RegistrarStandardSysId;
                    sqlComm.Parameters.Add("@school_year_start", SqlDbType.TinyInt).Value = stdRegistrar.SchoolYearStart;
                    sqlComm.Parameters.Add("@semester_months", SqlDbType.TinyInt).Value = stdRegistrar.SemesterMonths;
                    sqlComm.Parameters.Add("@summer_months", SqlDbType.TinyInt).Value = stdRegistrar.SummerMonths;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }

        } //-------------------------------------

        //this procedure inserts a new finance standard
        public void InsertFinanceStandard(CommonExchange.SysAccess userInfo, ref CommonExchange.FinanceStandard stdFinance)
        {
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                stdFinance.FinanceStandardSysId = PrimaryKeys.GetNewFinanceStandardSystemID(userInfo, auth.Connection);

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.InsertFinanceStandard";

                    sqlComm.Parameters.Add("@sysid_financestd", SqlDbType.VarChar).Value = stdFinance.FinanceStandardSysId;
                    sqlComm.Parameters.Add("@international_percentage", SqlDbType.Float).Value = stdFinance.InternationalPercentage;
                    sqlComm.Parameters.Add("@enrolment_cutoff_day", SqlDbType.TinyInt).Value = stdFinance.EnrolmentCutOffDay;

                    sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                    sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                    sqlComm.ExecuteNonQuery();
                }
            }

        } //-------------------------------------
       
        #endregion

        #region Programmer-Defined Function Procedures

        //this function determines if the person is an employee or a student
        public Boolean IsExistsSysIDPersonStudentEmployeeInformation(CommonExchange.SysAccess userInfo, String personSysId, ref Boolean isEmployee)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsExistsSysIDPersonStudentEmployeeInformation";

                    sqlComm.Parameters.Add("@sysid_person", SqlDbType.VarChar).Value = personSysId;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsExistsSysIDPersonEmployeeInformation";

                    sqlComm.Parameters.Add("@sysid_person", SqlDbType.VarChar).Value = personSysId;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isEmployee = (Boolean)sqlComm.ExecuteScalar();
                }
            }

            return isExist;

        } //------------------------------

        //this function gets the person information table query
        public DataTable SelectPersonInformation(CommonExchange.SysAccess userInfo, String queryString,
            String lastName, String firstName, String personSysIdExcludeList)
        {
            DataTable dbTable = new DataTable("PersonInformationTable");
            dbTable.Columns.Add("sysid_person", System.Type.GetType("System.String"));
			dbTable.Columns.Add("last_name", System.Type.GetType("System.String"));
			dbTable.Columns.Add("first_name", System.Type.GetType("System.String"));
			dbTable.Columns.Add("middle_name", System.Type.GetType("System.String"));
			dbTable.Columns.Add("birthdate", System.Type.GetType("System.String"));
			dbTable.Columns.Add("present_address", System.Type.GetType("System.String"));
			dbTable.Columns.Add("present_phone_nos", System.Type.GetType("System.String"));
			dbTable.Columns.Add("life_status_code_code_reference_id", System.Type.GetType("System.String"));
			dbTable.Columns.Add("life_status_code_code_entity_id", System.Type.GetType("System.String"));
			dbTable.Columns.Add("life_status_code_reference_code", System.Type.GetType("System.String"));
			dbTable.Columns.Add("life_status_code_code_description", System.Type.GetType("System.String"));
			dbTable.Columns.Add("gender_code_code_reference_id", System.Type.GetType("System.String"));
			dbTable.Columns.Add("gender_code_code_entity_id", System.Type.GetType("System.String"));
			dbTable.Columns.Add("gender_code_reference_code", System.Type.GetType("System.String"));
            dbTable.Columns.Add("gender_code_code_description", System.Type.GetType("System.String"));

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectPersonInformation";

                    if (String.IsNullOrEmpty(queryString))
                    {
                        sqlComm.Parameters.Add("@query_string", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@query_string", SqlDbType.VarChar).Value = queryString;
                    }

                    if (String.IsNullOrEmpty(lastName))
                    {
                        sqlComm.Parameters.Add("@last_name", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@last_name", SqlDbType.VarChar).Value = lastName;
                    }

                    if (String.IsNullOrEmpty(firstName))
                    {
                        sqlComm.Parameters.Add("@first_name", SqlDbType.VarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@first_name", SqlDbType.VarChar).Value = firstName;
                    }                    

                    if (String.IsNullOrEmpty(personSysIdExcludeList))
                    {
                        sqlComm.Parameters.Add("@sysid_person_exclude_list", SqlDbType.NVarChar).Value = DBNull.Value;
                    }
                    else
                    {
                        sqlComm.Parameters.Add("@sysid_person_exclude_list", SqlDbType.NVarChar).Value = personSysIdExcludeList;
                    }

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                DataRow newRow = dbTable.NewRow();

                                newRow["sysid_person"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_person", String.Empty);
                                newRow["last_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "last_name", String.Empty);
                                newRow["first_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "first_name", String.Empty);
                                newRow["middle_name"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "middle_name", String.Empty);
                                newRow["birthdate"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "birthdate",
                                    DateTime.MinValue).ToString();
                                newRow["present_address"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "present_address", String.Empty);
                                newRow["present_phone_nos"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "present_phone_nos", String.Empty);
                                newRow["life_status_code_code_reference_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, 
                                    "life_status_code_code_reference_id", String.Empty);
                                newRow["life_status_code_code_entity_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, 
                                    "life_status_code_code_entity_id", String.Empty);
                                newRow["life_status_code_reference_code"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, 
                                    "life_status_code_reference_code", String.Empty);
                                newRow["life_status_code_code_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, 
                                    "life_status_code_code_description", String.Empty);
                                newRow["gender_code_code_reference_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, 
                                    "gender_code_code_reference_id", String.Empty);
                                newRow["gender_code_code_entity_id"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, 
                                    "gender_code_code_entity_id", String.Empty);
                                newRow["gender_code_reference_code"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, 
                                    "gender_code_reference_code", String.Empty);
                                newRow["gender_code_code_description"] = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader,
                                    "gender_code_code_description", String.Empty);

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

        //this function returns the person information details
        public CommonExchange.Person SelectBySysIDPersonInformation(CommonExchange.SysAccess userInfo, String personSysId)
        {
            CommonExchange.Person personInfo = new CommonExchange.Person();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                personInfo = this.SelectBySysIDPersonInformationNoAuthenticate(userInfo.UserId, auth.Connection, personSysId);
            }

            return personInfo;
        } //------------------------------------

        //this function returns the person information details
        public CommonExchange.Person SelectBySysIDPersonInformationNoAuthenticate(String userId, SqlConnection sqlConn, String personSysId)
        {
            CommonExchange.Person personInfo = new CommonExchange.Person();

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectBySysIDPersonInformation";

                sqlComm.Parameters.Add("@sysid_person", SqlDbType.VarChar).Value = personSysId;

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                {
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            personInfo.PersonSysId = ProcStatic.DataReaderConvert(sqlReader, "sysid_person", String.Empty);
                            personInfo.ECode = ProcStatic.DataReaderConvert(sqlReader, "e_code", String.Empty);
                            personInfo.LastName = ProcStatic.DataReaderConvert(sqlReader, "last_name", String.Empty);
                            personInfo.FirstName = ProcStatic.DataReaderConvert(sqlReader, "first_name", String.Empty);
                            personInfo.MiddleName = ProcStatic.DataReaderConvert(sqlReader, "middle_name", String.Empty);
	                        personInfo.BirthDate = ProcStatic.DataReaderConvert(sqlReader, "birthdate", DateTime.MinValue).ToString();
                            personInfo.PlaceOfBirth = ProcStatic.DataReaderConvert(sqlReader, "place_birth", String.Empty);
                            personInfo.EMailAddress = ProcStatic.DataReaderConvert(sqlReader, "email_address", String.Empty);
                            personInfo.PresentAddress = ProcStatic.DataReaderConvert(sqlReader, "present_address", String.Empty);
                            personInfo.PresentPhoneNos = ProcStatic.DataReaderConvert(sqlReader, "present_phone_nos", String.Empty);
                            personInfo.HomeAddress = ProcStatic.DataReaderConvert(sqlReader, "home_address", String.Empty);
                            personInfo.HomePhoneNos = ProcStatic.DataReaderConvert(sqlReader, "home_phone_nos", String.Empty);
                            personInfo.Citizenship = ProcStatic.DataReaderConvert(sqlReader, "citizenship", String.Empty);
                            personInfo.Nationality = ProcStatic.DataReaderConvert(sqlReader, "nationality", String.Empty);
                            personInfo.Religion = ProcStatic.DataReaderConvert(sqlReader, "religion", String.Empty);
		                    personInfo.MarriageDate = ProcStatic.DataReaderConvert(sqlReader, "marriage_date", DateTime.MinValue).ToString();
                            personInfo.OtherPersonInformation = ProcStatic.DataReaderConvert(sqlReader, "other_person_information", String.Empty);
                            personInfo.FileName = ProcStatic.DataReaderConvert(sqlReader, "original_name", String.Empty);

                            personInfo.LifeStatusCode.CodeReferenceId = ProcStatic.DataReaderConvert(sqlReader, "life_status_code_code_reference_id", String.Empty);
                            personInfo.LifeStatusCode.CodeEntityId = ProcStatic.DataReaderConvert(sqlReader, "life_status_code_code_entity_id", String.Empty);
                            personInfo.LifeStatusCode.ReferenceCode = ProcStatic.DataReaderConvert(sqlReader, "life_status_code_reference_code", String.Empty);
                            personInfo.LifeStatusCode.CodeDescription = ProcStatic.DataReaderConvert(sqlReader, "life_status_code_code_description", String.Empty);

                            personInfo.GenderCode.CodeReferenceId = ProcStatic.DataReaderConvert(sqlReader, "gender_code_code_reference_id", String.Empty);
                            personInfo.GenderCode.CodeEntityId = ProcStatic.DataReaderConvert(sqlReader, "gender_code_code_entity_id", String.Empty);
                            personInfo.GenderCode.ReferenceCode = ProcStatic.DataReaderConvert(sqlReader, "gender_code_reference_code", String.Empty);
                            personInfo.GenderCode.CodeDescription = ProcStatic.DataReaderConvert(sqlReader, "gender_code_code_description", String.Empty);

                            personInfo.MaritalStatusCode.CodeReferenceId = ProcStatic.DataReaderConvert(sqlReader, "marital_status_code_code_reference_id", 
                                String.Empty);
                            personInfo.MaritalStatusCode.CodeEntityId = ProcStatic.DataReaderConvert(sqlReader, "marital_status_code_code_entity_id", String.Empty);
                            personInfo.MaritalStatusCode.ReferenceCode = ProcStatic.DataReaderConvert(sqlReader, "marital_status_code_reference_code", 
                                String.Empty);
                            personInfo.MaritalStatusCode.CodeDescription = ProcStatic.DataReaderConvert(sqlReader, "marital_status_code_code_description", 
                                String.Empty);

                            personInfo.ForLogin = personInfo.ForEmployee = personInfo.ForStudent = false;

                            break;

                        }
                    }

                    sqlReader.Close();
                }
            }

            //get the person in relationship with
            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectBySysIDPersonRelationshipInformation";

                sqlComm.Parameters.Add("@sysid_person", SqlDbType.VarChar).Value = personSysId;

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                {
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            CommonExchange.PersonRelationship pRelationship = new CommonExchange.PersonRelationship();

                            pRelationship.PersonInRelationshipWith.PersonSysId = ProcStatic.DataReaderConvert(sqlReader, "sysid_person", String.Empty);
                            pRelationship.PersonInRelationshipWith.LastName = ProcStatic.DataReaderConvert(sqlReader, "last_name", String.Empty);
                            pRelationship.PersonInRelationshipWith.FirstName = ProcStatic.DataReaderConvert(sqlReader, "first_name", String.Empty);
                            pRelationship.PersonInRelationshipWith.MiddleName = ProcStatic.DataReaderConvert(sqlReader, "middle_name", String.Empty);
                            pRelationship.PersonInRelationshipWith.BirthDate = ProcStatic.DataReaderConvert(sqlReader, "birthdate", DateTime.MinValue).ToString();
                            pRelationship.PersonInRelationshipWith.PresentAddress = ProcStatic.DataReaderConvert(sqlReader, "present_address", String.Empty);
                            pRelationship.PersonInRelationshipWith.PresentPhoneNos = ProcStatic.DataReaderConvert(sqlReader, "present_phone_nos", String.Empty);

                            pRelationship.PersonInRelationshipWith.LifeStatusCode.CodeReferenceId = ProcStatic.DataReaderConvert(sqlReader, 
                                "life_status_code_code_reference_id", String.Empty);
                            pRelationship.PersonInRelationshipWith.LifeStatusCode.CodeEntityId = ProcStatic.DataReaderConvert(sqlReader, 
                                "life_status_code_code_entity_id", String.Empty);
                            pRelationship.PersonInRelationshipWith.LifeStatusCode.ReferenceCode = ProcStatic.DataReaderConvert(sqlReader,
                                "life_status_code_reference_code", String.Empty);
                            pRelationship.PersonInRelationshipWith.LifeStatusCode.CodeDescription = ProcStatic.DataReaderConvert(sqlReader,
                                "life_status_code_code_description", String.Empty);

                            pRelationship.PersonInRelationshipWith.GenderCode.CodeReferenceId = ProcStatic.DataReaderConvert(sqlReader,
                                "gender_code_code_reference_id", String.Empty);
                            pRelationship.PersonInRelationshipWith.GenderCode.CodeEntityId = ProcStatic.DataReaderConvert(sqlReader, 
                                "gender_code_code_entity_id", String.Empty);
                            pRelationship.PersonInRelationshipWith.GenderCode.ReferenceCode = ProcStatic.DataReaderConvert(sqlReader, 
                                "gender_code_reference_code", String.Empty);
                            pRelationship.PersonInRelationshipWith.GenderCode.CodeDescription = ProcStatic.DataReaderConvert(sqlReader, 
                                "gender_code_code_description", String.Empty);

                            pRelationship.RelationshipId = ProcStatic.DataReaderConvert(sqlReader, "relationship_id", Int64.Parse("0"));
                            pRelationship.IsEmergencyContact = ProcStatic.DataReaderConvert(sqlReader, "is_emergency_contact", false);

                            pRelationship.RelationshipTypeInfo.RelationshipTypeId = ProcStatic.DataReaderConvert(sqlReader, "relationship_type_id", String.Empty);
		                    pRelationship.RelationshipTypeInfo.RelationshipDescription = ProcStatic.DataReaderConvert(sqlReader, 
                                "relationship_description", String.Empty);
		                    pRelationship.RelationshipTypeInfo.IsParent = ProcStatic.DataReaderConvert(sqlReader, "is_parent", false);
		                    pRelationship.RelationshipTypeInfo.IsSpouse = ProcStatic.DataReaderConvert(sqlReader, "is_spouse", false);
		                    pRelationship.RelationshipTypeInfo.IsSibling = ProcStatic.DataReaderConvert(sqlReader, "is_sibling", false);
		                    pRelationship.RelationshipTypeInfo.IsInLaw = ProcStatic.DataReaderConvert(sqlReader, "is_in_law", false);
	                        pRelationship.RelationshipTypeInfo.IsBloodLine = ProcStatic.DataReaderConvert(sqlReader, "is_blood_line", false);
                            pRelationship.RelationshipTypeInfo.IsFriend = ProcStatic.DataReaderConvert(sqlReader, "is_friend", false);

                            personInfo.PersonRelationshipList.Add(pRelationship);

                        }
                    }

                    sqlReader.Close();
                }
            }

            return personInfo;
        } //------------------------------------

        //this function gets the person information images by sysid_person list
        public DataTable SelectPersonImagesPersonInformation(CommonExchange.SysAccess userInfo, String personSysIdList)
        {
            DataTable dbTable = new DataTable("PersonImagesTable");
            dbTable.Columns.Add("sysid_person", System.Type.GetType("System.String"));
            dbTable.Columns.Add("file_data", System.Type.GetType("System.Byte[]"));
            dbTable.Columns.Add("original_name", System.Type.GetType("System.String"));

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectPersonImagesPersonInformation";

                    sqlComm.Parameters.Add("@sysid_person_list", SqlDbType.NVarChar).Value = personSysIdList;
                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader(CommandBehavior.SequentialAccess))
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                DataRow newRow = dbTable.NewRow();

                                newRow["sysid_person"] = sqlReader["sysid_person"];
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

        //this function returns the payroll standards
        public CommonExchange.PayrollStandard SelectPayrollStandard(CommonExchange.SysAccess userInfo)
        {
            CommonExchange.PayrollStandard stdPayroll = new CommonExchange.PayrollStandard();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectPayrollStandard";

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                stdPayroll.PayrollCutOffDay = ProcStatic.DataReaderConvert(sqlReader, "payroll_cutoff_day", Byte.Parse("0"));
                            }
                        }

                        sqlReader.Close();
                    }
                }
            }

            return stdPayroll;

        } //--------------------------

        //this function returns the registrar standards
        public CommonExchange.RegistrarStandard SelectRegistrarStandard(CommonExchange.SysAccess userInfo)
        {
            CommonExchange.RegistrarStandard stdRegistrar = new CommonExchange.RegistrarStandard();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectRegistrarStandard";

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                stdRegistrar.SchoolYearStart = ProcStatic.DataReaderConvert(sqlReader, "school_year_start", Byte.Parse("0"));
                                stdRegistrar.SemesterMonths = ProcStatic.DataReaderConvert(sqlReader, "semester_months", Byte.Parse("0"));
                                stdRegistrar.SummerMonths = ProcStatic.DataReaderConvert(sqlReader, "summer_months", Byte.Parse("0"));
                            }
                        }

                        sqlReader.Close();
                    }
                }
            }

            return stdRegistrar;

        } //--------------------------

        //this function returns the finance standards
        public CommonExchange.FinanceStandard SelectFinanceStandard(CommonExchange.SysAccess userInfo)
        {
            CommonExchange.FinanceStandard stdFinance = new CommonExchange.FinanceStandard();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectFinanceStandard";

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                stdFinance.InternationalPercentage = ProcStatic.DataReaderConvert(sqlReader, "international_percentage", Single.Parse("0"));
                                stdFinance.EnrolmentCutOffDay = ProcStatic.DataReaderConvert(sqlReader, "enrolment_cutoff_day", Byte.Parse("0"));
                            }
                        }

                        sqlReader.Close();
                    }
                }
            }

            return stdFinance;

        } //--------------------------            

        //this function return the server date
        public String GetServerDateTime(CommonExchange.SysAccess userInfo)
        {
            String serverTime;
            
            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                serverTime = this.GetServerDateTimeNoAuthenticate(auth.Connection);
            }

            return serverTime;
                        
        } //--------------------------

        //this function return the server date
        public String GetServerDateTimeNoAuthenticate(SqlConnection sqlConn)
        {
            DateTime serverTime;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.GetServerDateTime";

                serverTime = ((DateTime)sqlComm.ExecuteScalar());
            }

            return serverTime.ToString("o");

        } //--------------------------

        //this function is used to get data tables stored in one dataset used for administrator services
        public DataSet GetDataSetForBaseServices(CommonExchange.SysAccess userInfo)
        {
            DataSet dbSet = new DataSet();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                //gets the code reference table
                dbSet.Tables.Add(ProcStatic.GetCodeReferenceTable(auth.Connection, userInfo.UserId));
                //-----------------------------

                //gets the relationship type table
                dbSet.Tables.Add(ProcStatic.GetRelationshipTypeTable(auth.Connection, userInfo.UserId));
                //-------------------------------------
            }

            return dbSet;
        } //----------------------------------

        #endregion
    }
}
