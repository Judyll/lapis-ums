using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace RemoteServerLib
{
    public class RemSrvEmployeeManager: MarshalByRefObject, IDisposable
    {
        #region Class Constructor and Destructor
        public RemSrvEmployeeManager() { }

        void IDisposable.Dispose() { }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure adds a new employee information
        public void InsertEmployeeInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.Employee empInfo)
        {
            if (empInfo.ObjectState == DataRowState.Added)
            {
                using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
                {
                    using (RemSrvBaseManager remSrv = new RemSrvBaseManager())
                    {
                        empInfo.PersonInfo.ForLogin = false;
                        empInfo.PersonInfo.ForEmployee = true;
                        empInfo.PersonInfo.ForStudent = false;

                        CommonExchange.Person personInfo = empInfo.PersonInfo;

                        remSrv.InsertUpdatePersonInformationNoAuthenticate(userInfo, auth.Connection, ref personInfo);

                        empInfo.PersonInfo = personInfo;
                    }

                    empInfo.EmployeeSysId = PrimaryKeys.GetNewEmployeeSystemID(userInfo, auth.Connection);

                    using (SqlCommand sqlComm = new SqlCommand())
                    {
                        sqlComm.Connection = auth.Connection;
                        sqlComm.CommandType = CommandType.StoredProcedure;
                        sqlComm.CommandText = "ums.InsertEmployeeInformation";

                        sqlComm.Parameters.Add("@sysid_employee", SqlDbType.VarChar).Value = empInfo.EmployeeSysId;
                        sqlComm.Parameters.Add("@employee_id", SqlDbType.VarChar).Value = empInfo.EmployeeId;
                        sqlComm.Parameters.Add("@pagibig_memid", SqlDbType.VarChar).Value = empInfo.PagibigMembershipId;
                        sqlComm.Parameters.Add("@sss_memid", SqlDbType.VarChar).Value = empInfo.SssMembershipId;
                        sqlComm.Parameters.Add("@philhealth_memid", SqlDbType.VarChar).Value = empInfo.PhilHealthMembershipId;
                        sqlComm.Parameters.Add("@other_employee_information", SqlDbType.VarChar).Value = empInfo.OtherEmployeeInformation;
                        sqlComm.Parameters.Add("@sysid_person", SqlDbType.VarChar).Value = empInfo.PersonInfo.PersonSysId;

                        sqlComm.Parameters.Add("@employment_id", SqlDbType.VarChar).Value = empInfo.SalaryInfo.EmploymentTypeInfo.EmploymentId;
                        sqlComm.Parameters.Add("@department_id", SqlDbType.VarChar).Value = empInfo.SalaryInfo.DepartmentInfo.DepartmentId;
                        sqlComm.Parameters.Add("@status_id", SqlDbType.VarChar).Value = empInfo.SalaryInfo.EmployeeStatusInfo.StatusId;

                        if (String.IsNullOrEmpty(empInfo.SalaryInfo.RankLevelInfo.LevelId))
                        {
                            sqlComm.Parameters.Add("@level_id", SqlDbType.VarChar).Value = DBNull.Value;
                        }
                        else
                        {
                            sqlComm.Parameters.Add("@level_id", SqlDbType.VarChar).Value = empInfo.SalaryInfo.RankLevelInfo.LevelId;
                        }

                        if (String.IsNullOrEmpty(empInfo.SalaryInfo.RankCategoryInfo.CategoryId))
                        {
                            sqlComm.Parameters.Add("@category_id", SqlDbType.VarChar).Value = DBNull.Value;
                        }
                        else
                        {
                            sqlComm.Parameters.Add("@category_id", SqlDbType.VarChar).Value = empInfo.SalaryInfo.RankCategoryInfo.CategoryId;
                        }

                        if (String.IsNullOrEmpty(empInfo.SalaryInfo.RankDegreeInfo.DegreeId))
                        {
                            sqlComm.Parameters.Add("@degree_id", SqlDbType.VarChar).Value = DBNull.Value;
                        }
                        else
                        {
                            sqlComm.Parameters.Add("@degree_id", SqlDbType.VarChar).Value = empInfo.SalaryInfo.RankDegreeInfo.DegreeId;
                        }

                        if (String.IsNullOrEmpty(empInfo.SalaryInfo.RankDegreeLevelPointsInfo.DegreeId))
                        {
                            sqlComm.Parameters.Add("@degree_id_level_points", SqlDbType.VarChar).Value = DBNull.Value;
                        }
                        else
                        {
                            sqlComm.Parameters.Add("@degree_id_level_points", SqlDbType.VarChar).Value = empInfo.SalaryInfo.RankDegreeLevelPointsInfo.DegreeId;
                        }

                        if (empInfo.SalaryInfo.RankSalaryRateInfo.RateId <= 0)
                        {
                            sqlComm.Parameters.Add("@rate_id", SqlDbType.BigInt).Value = DBNull.Value;
                        }
                        else
                        {
                            sqlComm.Parameters.Add("@rate_id", SqlDbType.BigInt).Value = empInfo.SalaryInfo.RankSalaryRateInfo.RateId;
                        }

                        sqlComm.Parameters.Add("@is_fixed_loginout", SqlDbType.Bit).Value = empInfo.SalaryInfo.IsFixedLogInOut;
                        sqlComm.Parameters.Add("@first_in", SqlDbType.VarChar).Value = empInfo.SalaryInfo.FirstIn;
                        sqlComm.Parameters.Add("@first_out", SqlDbType.VarChar).Value = empInfo.SalaryInfo.FirstOut;
                        sqlComm.Parameters.Add("@second_in", SqlDbType.VarChar).Value = empInfo.SalaryInfo.SecondIn;
                        sqlComm.Parameters.Add("@second_out", SqlDbType.VarChar).Value = empInfo.SalaryInfo.SecondOut;
                        sqlComm.Parameters.Add("@rest_day", SqlDbType.TinyInt).Value = (Byte)empInfo.SalaryInfo.RestDay.WeekId;

                        sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                        sqlComm.Parameters.Add("@created_by", SqlDbType.VarChar).Value = userInfo.UserId;

                        sqlComm.ExecuteNonQuery();
                    }
                }
            }

        } //--------------------------------

        //this procedure updates an employee information
        public void UpdateEmployeeInformation(CommonExchange.SysAccess userInfo, CommonExchange.Employee empInfo)
        {
            if (empInfo.ObjectState == DataRowState.Modified)
            {
                using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
                {
                    using (RemSrvBaseManager remSrv = new RemSrvBaseManager())
                    {
                        empInfo.PersonInfo.ForLogin = false;
                        empInfo.PersonInfo.ForEmployee = true;
                        empInfo.PersonInfo.ForStudent = false;

                        CommonExchange.Person personInfo = empInfo.PersonInfo;

                        remSrv.InsertUpdatePersonInformationNoAuthenticate(userInfo, auth.Connection, ref personInfo);

                        empInfo.PersonInfo = personInfo;
                    }

                    using (SqlCommand sqlComm = new SqlCommand())
                    {
                        sqlComm.Connection = auth.Connection;
                        sqlComm.CommandType = CommandType.StoredProcedure;
                        sqlComm.CommandText = "ums.UpdateEmployeeInformation";

                        sqlComm.Parameters.Add("@sysid_employee", SqlDbType.VarChar).Value = empInfo.EmployeeSysId;
                        sqlComm.Parameters.Add("@employee_id", SqlDbType.VarChar).Value = empInfo.EmployeeId;
                        sqlComm.Parameters.Add("@pagibig_memid", SqlDbType.VarChar).Value = empInfo.PagibigMembershipId;
                        sqlComm.Parameters.Add("@sss_memid", SqlDbType.VarChar).Value = empInfo.SssMembershipId;
                        sqlComm.Parameters.Add("@philhealth_memid", SqlDbType.VarChar).Value = empInfo.PhilHealthMembershipId;
                        sqlComm.Parameters.Add("@other_employee_information", SqlDbType.VarChar).Value = empInfo.OtherEmployeeInformation;

                        sqlComm.Parameters.Add("@employment_id", SqlDbType.VarChar).Value = empInfo.SalaryInfo.EmploymentTypeInfo.EmploymentId;
                        sqlComm.Parameters.Add("@department_id", SqlDbType.VarChar).Value = empInfo.SalaryInfo.DepartmentInfo.DepartmentId;
                        sqlComm.Parameters.Add("@status_id", SqlDbType.VarChar).Value = empInfo.SalaryInfo.EmployeeStatusInfo.StatusId;

                        if (String.IsNullOrEmpty(empInfo.SalaryInfo.RankLevelInfo.LevelId))
                        {
                            sqlComm.Parameters.Add("@level_id", SqlDbType.VarChar).Value = DBNull.Value;
                        }
                        else
                        {
                            sqlComm.Parameters.Add("@level_id", SqlDbType.VarChar).Value = empInfo.SalaryInfo.RankLevelInfo.LevelId;
                        }

                        if (String.IsNullOrEmpty(empInfo.SalaryInfo.RankCategoryInfo.CategoryId))
                        {
                            sqlComm.Parameters.Add("@category_id", SqlDbType.VarChar).Value = DBNull.Value;
                        }
                        else
                        {
                            sqlComm.Parameters.Add("@category_id", SqlDbType.VarChar).Value = empInfo.SalaryInfo.RankCategoryInfo.CategoryId;
                        }

                        if (String.IsNullOrEmpty(empInfo.SalaryInfo.RankDegreeInfo.DegreeId))
                        {
                            sqlComm.Parameters.Add("@degree_id", SqlDbType.VarChar).Value = DBNull.Value;
                        }
                        else
                        {
                            sqlComm.Parameters.Add("@degree_id", SqlDbType.VarChar).Value = empInfo.SalaryInfo.RankDegreeInfo.DegreeId;
                        }

                        if (String.IsNullOrEmpty(empInfo.SalaryInfo.RankDegreeLevelPointsInfo.DegreeId))
                        {
                            sqlComm.Parameters.Add("@degree_id_level_points", SqlDbType.VarChar).Value = DBNull.Value;
                        }
                        else
                        {
                            sqlComm.Parameters.Add("@degree_id_level_points", SqlDbType.VarChar).Value = empInfo.SalaryInfo.RankDegreeLevelPointsInfo.DegreeId;
                        }

                        if (empInfo.SalaryInfo.RankSalaryRateInfo.RateId <= 0)
                        {
                            sqlComm.Parameters.Add("@rate_id", SqlDbType.BigInt).Value = DBNull.Value;
                        }
                        else
                        {
                            sqlComm.Parameters.Add("@rate_id", SqlDbType.BigInt).Value = empInfo.SalaryInfo.RankSalaryRateInfo.RateId;
                        }

                        sqlComm.Parameters.Add("@is_fixed_loginout", SqlDbType.Bit).Value = empInfo.SalaryInfo.IsFixedLogInOut;
                        sqlComm.Parameters.Add("@first_in", SqlDbType.VarChar).Value = empInfo.SalaryInfo.FirstIn;
                        sqlComm.Parameters.Add("@first_out", SqlDbType.VarChar).Value = empInfo.SalaryInfo.FirstOut;
                        sqlComm.Parameters.Add("@second_in", SqlDbType.VarChar).Value = empInfo.SalaryInfo.SecondIn;
                        sqlComm.Parameters.Add("@second_out", SqlDbType.VarChar).Value = empInfo.SalaryInfo.SecondOut;
                        sqlComm.Parameters.Add("@rest_day", SqlDbType.TinyInt).Value = (Byte)empInfo.SalaryInfo.RestDay.WeekId;

                        sqlComm.Parameters.Add("@network_information", SqlDbType.VarChar).Value = userInfo.NetworkInformation;
                        sqlComm.Parameters.Add("@edited_by", SqlDbType.VarChar).Value = userInfo.UserId;

                        sqlComm.ExecuteNonQuery();
                    }
                }
            }

        } //---------------------------------  
        
        #endregion

        #region Programmer-Defined Function Procedures

        //this function returns the employee information details
        public CommonExchange.Employee SelectByEmployeeIDEmployeeInformation(CommonExchange.SysAccess userInfo, String employeeId)
        {
            CommonExchange.Employee employeeInfo = new CommonExchange.Employee();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                employeeInfo = this.SelectByEmployeeIDEmployeeInformationNoAuthenticate(userInfo, auth.Connection, employeeId);
            }

            return employeeInfo;
        } //---------------------------------------        

        //this function returns the employee information details
        public CommonExchange.Employee SelectBySysIDPersonEmployeeInformation(CommonExchange.SysAccess userInfo, String personSysId)
        {
            CommonExchange.Employee employeeInfo = new CommonExchange.Employee();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                String employeeId = String.Empty;

                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.SelectBySysIDPersonEmployeeInformation";

                    sqlComm.Parameters.Add("@sysid_person", SqlDbType.VarChar).Value = personSysId;

                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                    {
                        if (sqlReader.HasRows)
                        {
                            while (sqlReader.Read())
                            {
                                employeeId = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "employee_id", String.Empty);

                                break;

                            }
                        }

                        sqlReader.Close();
                    }
                }

                if (!String.IsNullOrEmpty(employeeId))
                {
                    employeeInfo = this.SelectByEmployeeIDEmployeeInformationNoAuthenticate(userInfo, auth.Connection, employeeId);
                }
            }

            return employeeInfo;
        } //---------------------------------------      

        //this function is used to determine if the employee id exists
        public Boolean IsExistsEmployeeIdEmployeeInformation(CommonExchange.SysAccess userInfo, String empId, String sysId)
        {
            Boolean isExist = false;

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {
                using (SqlCommand sqlComm = new SqlCommand())
                {
                    sqlComm.Connection = auth.Connection;
                    sqlComm.CommandType = CommandType.StoredProcedure;
                    sqlComm.CommandText = "ums.IsExistsEmployeeIDEmployeeInformation";

                    sqlComm.Parameters.Add("@sysid_employee", SqlDbType.VarChar).Value = sysId;
                    sqlComm.Parameters.Add("@employee_id", SqlDbType.VarChar).Value = empId;
                    sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                    isExist = (Boolean)sqlComm.ExecuteScalar();
                }                
            }

            return isExist;
        } //-----------------------------

        //this function is used to get data tables stored in one dataset used for employee information
        public DataSet GetDataSetForEmployeeInfo(CommonExchange.SysAccess userInfo)
        {
            DataSet dbSet = new DataSet();

            using (Authenticate auth = new Authenticate(userInfo, new CommonExchange.TransactionSource(true, false, false, false)))
            {

                //gets the employee personal and salary information table
                dbSet.Tables.Add(ProcStatic.GetEmployeeInformationTable(auth.Connection, userInfo.UserId));
                //-----------------------

                //gets the employment status table
                dbSet.Tables.Add(ProcStatic.GetEmploymentStatusTable(auth.Connection, userInfo.UserId));
                //-----------------------------

                //gets the department table
                dbSet.Tables.Add(ProcStatic.GetDepartmentInformationTable(auth.Connection, userInfo.UserId));
                //----------------------------------

                //gets the rest day table
                dbSet.Tables.Add(ProcStatic.GetWeekDayTable(auth.Connection, userInfo.UserId));
                //-----------------------------

                //gets the employment type table
                dbSet.Tables.Add(ProcStatic.GetEmploymentTypeTable(auth.Connection, userInfo.UserId));
                //-------------------------------

                //gets the rank level table
                dbSet.Tables.Add(ProcStatic.GetRankLevelTable(auth.Connection, userInfo.UserId));
                //------------------------------
                
                //gets the rank category table
                dbSet.Tables.Add(ProcStatic.GetRankCategoryTable(auth.Connection, userInfo.UserId));
                //-------------------------------

                //gets the rank degree table
                dbSet.Tables.Add(ProcStatic.GetRankDegreeTable(auth.Connection, userInfo.UserId));
                //-----------------------------

                //gets the relationship type table
                dbSet.Tables.Add(ProcStatic.GetRelationshipTypeTable(auth.Connection, userInfo.UserId));
                //-------------------------------------
            }

            return dbSet;
        } //----------------------------------

        //this function returns the employee information details
        private CommonExchange.Employee SelectByEmployeeIDEmployeeInformationNoAuthenticate(CommonExchange.SysAccess userInfo, SqlConnection sqlConn,
            String employeeId)
        {
            CommonExchange.Employee empInfo = new CommonExchange.Employee();

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectByEmployeeIDEmployeeInformation";

                sqlComm.Parameters.Add("@employee_id", SqlDbType.VarChar).Value = employeeId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                using (SqlDataReader sqlReader = sqlComm.ExecuteReader())
                {
                    if (sqlReader.HasRows)
                    {
                        while (sqlReader.Read())
                        {
                            empInfo.EmployeeSysId = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_employee", String.Empty);
                            empInfo.EmployeeId = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "employee_id", String.Empty);
                            empInfo.CardNumber = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "card_number", String.Empty);
                            empInfo.PagibigMembershipId = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "pagibig_memid", String.Empty);
                            empInfo.SssMembershipId = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sss_memid", String.Empty);
                            empInfo.PhilHealthMembershipId = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "philhealth_memid", String.Empty);
                            empInfo.OtherEmployeeInformation = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "other_employee_information", String.Empty);
                            empInfo.PersonInfo.PersonSysId = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "sysid_person", String.Empty);

                            empInfo.SalaryInfo.EffectivityDate = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "effectivity_date",
                                DateTime.MinValue).ToString();
                            empInfo.SalaryInfo.EmploymentTypeInfo.EmploymentId = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader,
                                "employment_id", String.Empty);
                            empInfo.SalaryInfo.DepartmentInfo.DepartmentId = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader,
                                "department_id", String.Empty);
                            empInfo.SalaryInfo.EmployeeStatusInfo.StatusId = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader,
                                "status_id", Byte.Parse("0"));
                            empInfo.SalaryInfo.RankLevelInfo.LevelId = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "level_id", String.Empty);
                            empInfo.SalaryInfo.RankCategoryInfo.CategoryId = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "category_id", String.Empty);
                            empInfo.SalaryInfo.RankDegreeInfo.DegreeId = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "degree_id", String.Empty);
                            empInfo.SalaryInfo.RankDegreeLevelPointsInfo.DegreeId = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader,
                                "degree_id_level_points", String.Empty);
                            empInfo.SalaryInfo.RankSalaryRateInfo.RateId = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "rate_id", Int64.Parse("0"));
                            empInfo.SalaryInfo.IsFixedLogInOut = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "is_fixed_loginout", false);
                            empInfo.SalaryInfo.FirstIn = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "first_in", "08:00 AM");
                            empInfo.SalaryInfo.FirstOut = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "first_out", "12:00 PM");
                            empInfo.SalaryInfo.SecondIn = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "second_in", "01:00 PM");
                            empInfo.SalaryInfo.SecondOut = RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "second_out", "05:00 PM");
                            empInfo.SalaryInfo.RestDay.WeekId = (DayOfWeek)RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader, "rest_day", Byte.Parse("0"));

                            empInfo.SalaryInfo.EmploymentTypeInfo.TypeNo = (CommonExchange.EmploymentTypeNo)RemoteServerLib.ProcStatic.DataReaderConvert(sqlReader,
                                "type_no", Byte.Parse("0"));

                            break;

                        }
                    }

                    sqlReader.Close();
                }

                if (!String.IsNullOrEmpty(empInfo.PersonInfo.PersonSysId))
                {
                    using (RemSrvBaseManager remSrv = new RemSrvBaseManager())
                    {
                        empInfo.PersonInfo = remSrv.SelectBySysIDPersonInformationNoAuthenticate(userInfo.UserId, sqlConn,
                            empInfo.PersonInfo.PersonSysId);
                    }
                }
            }

            return empInfo;
        } //---------------------------------------      

        #endregion
    }
}
