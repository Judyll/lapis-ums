using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading;

namespace RemoteServerLib
{
    internal class PrimaryKeys
    {
        #region Programmer-Defined Function Procedures

        //this function gets a new person information id
        public static String GetNewPersonInformationSystemID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            Int64 rowCount = 0;
            String personId = "";

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectCountPersonInformation";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                rowCount = Convert.ToInt64(sqlComm.ExecuteScalar());
            }

            do
            {
                personId = "SYSPER" + ProcStatic.TwelveDigitZero(++rowCount);

            } while (IsExistsSysIDPersonInformation(userInfo.UserId, sqlConn, personId));

            return personId;
        }

        public static Boolean IsExistsSysIDPersonInformation(String userId, SqlConnection sqlConn, String personId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistsSysIDPersonInformation";

                sqlComm.Parameters.Add("@sysid_person", SqlDbType.VarChar).Value = personId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------
        
        //this function gets a new employee id
        public static String GetNewEmployeeSystemID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            Int32 rowCount = 0;
            String employeeID = "";

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.GetCountEmployeeInformation";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                rowCount = (Int32)sqlComm.ExecuteScalar();
            }

            do
            {
                employeeID = "SYSEMP" + ProcStatic.ThreeDigitZero(++rowCount);

            } while (IsExistsEmployeeSystemID(userInfo.UserId, sqlConn, employeeID));

            return employeeID;
        }

        private static Boolean IsExistsEmployeeSystemID(String userId, SqlConnection sqlConn, String employeeID)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistsSysIDEmployeeInformation";

                sqlComm.Parameters.Add("@sysid_employee", SqlDbType.VarChar).Value = employeeID;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------

        //this function gets a new deduction id
        public static String GetNewDeductionSystemID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            Int32 rowCount = 0;
            String deductionId = "";

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.GetCountDeductionInformation";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                rowCount = (Int32)sqlComm.ExecuteScalar();
            }

            do
            {
                deductionId = "SYSDEC" + ProcStatic.ThreeDigitZero(++rowCount);

            } while (IsExistsDeductionSystemID(userInfo.UserId, sqlConn, deductionId));

            return deductionId;
        }

        private static Boolean IsExistsDeductionSystemID(String userId, SqlConnection sqlConn, String deductionID)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistsSysIDDeductionInformation";

                sqlComm.Parameters.Add("@sysid_deduction", SqlDbType.VarChar).Value = deductionID;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------

        //this function gets a new earning id
        public static String GetNewEarningSystemID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            Int32 rowCount = 0;
            String earningId = "";

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.GetCountEarningInformation";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                rowCount = (Int32)sqlComm.ExecuteScalar();
            }

            do
            {
                earningId = "SYSINC" + ProcStatic.ThreeDigitZero(++rowCount);

            } while (IsExistsEarningSystemID(userInfo.UserId, sqlConn, earningId));

            return earningId;
        }

        private static Boolean IsExistsEarningSystemID(String userId, SqlConnection sqlConn, String earningId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistsSysIDEarningInformation";

                sqlComm.Parameters.Add("@sysid_earning", SqlDbType.VarChar).Value = earningId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------

        //this function gets a new loan type id
        public static String GetNewLoanTypeSystemID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            Int32 rowCount = 0;
            String typeId = "";

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.GetCountLoanTypeInformation";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                rowCount = (Int32)sqlComm.ExecuteScalar();
            }

            do
            {
                typeId = "SYSLON" + ProcStatic.ThreeDigitZero(++rowCount);

            } while (IsExistsLoanTypeSystemID(userInfo.UserId, sqlConn, typeId));

            return typeId;
        }

        private static Boolean IsExistsLoanTypeSystemID(String userId, SqlConnection sqlConn, String typeId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistsSysIDLoanTypeInformation";

                sqlComm.Parameters.Add("@sysid_loan", SqlDbType.VarChar).Value = typeId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------

        //this function gets a new loan remittance id
        public static String GetNewLoanRemittanceSystemID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            Int32 rowCount = 0;
            String remittanceId = "";

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.GetCountLoanRemittance";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                rowCount = (Int32)sqlComm.ExecuteScalar();
            }

            do
            {
                remittanceId = "SYSLNR" + ProcStatic.SixDigitZero(++rowCount);

            } while (IsExistsLoanRemittanceSystemID(userInfo.UserId, sqlConn, remittanceId));

            return remittanceId;
        }

        private static Boolean IsExistsLoanRemittanceSystemID(String userId, SqlConnection sqlConn, String remittanceId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistsSysIDLoanRemittance";

                sqlComm.Parameters.Add("@sysid_remittance", SqlDbType.VarChar).Value = remittanceId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------

        //this function gets a new school year id
        public static String GetNewSchoolYearID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn, CommonExchange.SchoolYear yearInfo)
        {
            String yearId = "";
            Boolean isExist;

            Int32 yearStart = DateTime.Parse(yearInfo.DateStart).Year;
            Int32 yearEnd = DateTime.Parse(yearInfo.DateEnd).Year;

            do
            {
                isExist = false;

                yearId = "SY" + yearStart.ToString() + yearEnd.ToString();

                if (IsExistsSchoolYearID(userInfo.UserId, sqlConn, yearId))
                {
                    isExist = true;

                    yearStart++;
                    yearEnd++;
                }

            } while (isExist);

            return yearId;
        }

        private static Boolean IsExistsSchoolYearID(String userId, SqlConnection sqlConn, String yearId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistYearIDSchoolYear";

                sqlComm.Parameters.Add("@year_id", SqlDbType.VarChar).Value = yearId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------

        //this function gets a new school year id (SUMMER)
        public static String GetNewSchoolYearIDSummer(CommonExchange.SysAccess userInfo, SqlConnection sqlConn, 
            CommonExchange.SchoolYear baseYearInfo, CommonExchange.SchoolYear yearInfo)
        {
            String yearId = "";
            Boolean isExist;

            Int32 yearStart = DateTime.Parse(baseYearInfo.DateStart).Year;
            Int32 yearEnd = DateTime.Parse(yearInfo.DateEnd).Year;

            do
            {
                isExist = false;

                yearId = "SY" + yearStart.ToString() + yearEnd.ToString() + "SUMMER";

                if (IsExistsSchoolYearIDSummer(userInfo.UserId, sqlConn, yearId))
                {
                    isExist = true;

                    yearStart++;
                    yearEnd++;
                }

            } while (isExist);

            return yearId;
        }

        private static Boolean IsExistsSchoolYearIDSummer(String userId, SqlConnection sqlConn, String yearId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistYearIDSchoolYear";

                sqlComm.Parameters.Add("@year_id", SqlDbType.VarChar).Value = yearId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------

        //this function gets a new semester id
        public static String GetNewSemesterInformationSystemID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            Int32 rowCount = 0;
            String semId = "";

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.GetCountSemesterInformation";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                rowCount = (Int32)sqlComm.ExecuteScalar();
            }

            do
            {
                semId = "SYSSEM" + ProcStatic.FourDigitZero(++rowCount);

            } while (IsExistSemesterInformationSystemID(userInfo.UserId, sqlConn, semId));

            return semId;
        }

        private static Boolean IsExistSemesterInformationSystemID(String userId, SqlConnection sqlConn, String semId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistSysIdSemesterInformation";

                sqlComm.Parameters.Add("@sysid_semester", SqlDbType.VarChar).Value = semId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------

        //this function gets a new classroom id
        public static String GetNewClassroomInformationSystemID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            Int32 rowCount = 0;
            String roomId = "";

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.GetCountClassroomInformation";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                rowCount = (Int32)sqlComm.ExecuteScalar();
            }

            do
            {
                roomId = "SYSCRM" + ProcStatic.FourDigitZero(++rowCount);

            } while (IsExistClassroomInformationSystemID(userInfo.UserId, sqlConn, roomId));

            return roomId;
        }

        private static Boolean IsExistClassroomInformationSystemID(String userId, SqlConnection sqlConn, String roomId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistSysIDClassroomInformation";

                sqlComm.Parameters.Add("@sysid_classroom", SqlDbType.VarChar).Value = roomId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------

        //this function gets a new subject id
        public static String GetNewSubjectInformationSystemID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            Int32 rowCount = 0;
            String subjectId = "";

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.GetCountSubjectInformation";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                rowCount = (Int32)sqlComm.ExecuteScalar();
            }

            do
            {
                subjectId = "SYSSBJ" + ProcStatic.SixDigitZero(++rowCount);

            } while (IsExistSubjectInformationSystemID(userInfo.UserId, sqlConn, subjectId));

            return subjectId;
        }

        private static Boolean IsExistSubjectInformationSystemID(String userId, SqlConnection sqlConn, String subjectId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistSysIDSubjectInformation";

                sqlComm.Parameters.Add("@sysid_subject", SqlDbType.VarChar).Value = subjectId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------

        //this function gets a new student id
        public static String GetNewStudentInformationSystemID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            Int32 rowCount = 0;
            String studentId = "";

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.GetCountStudentInformation";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                rowCount = (Int32)sqlComm.ExecuteScalar();
            }

            do
            {
                studentId = "SYSSTD" + ProcStatic.NineDigitZero(++rowCount);

            } while (IsExistStudentInformationSystemID(userInfo.UserId, sqlConn, studentId));

            return studentId;
        }

        private static Boolean IsExistStudentInformationSystemID(String userId, SqlConnection sqlConn, String studentId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistSysIDStudentInformation";

                sqlComm.Parameters.Add("@sysid_student", SqlDbType.VarChar).Value = studentId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------

        //this function gets a new special class system id
        public static String GetNewSpecialClassInformationSystemID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            Int32 rowCount = 0;
            String classId = "";

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.GetCountSpecialClassInformation";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                rowCount = (Int32)sqlComm.ExecuteScalar();
            }

            do
            {
                classId = "SYSSPC" + ProcStatic.SixDigitZero(++rowCount);

            } while (IsExistSpecialClassInformationSystemID(userInfo.UserId, sqlConn, classId));

            return classId;
        }

        private static Boolean IsExistSpecialClassInformationSystemID(String userId, SqlConnection sqlConn, String classId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistsSysIDSpecialClassInformation";

                sqlComm.Parameters.Add("@sysid_special", SqlDbType.VarChar).Value = classId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------

        //this function gets a new schedule information system id
        public static String GetNewScheduleInformationSystemID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            Int32 rowCount = 0;
            String scheduleId = "";

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.GetCountScheduleInformation";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                rowCount = (Int32)sqlComm.ExecuteScalar();
            }

            do
            {
                scheduleId = "SYSSCH" + ProcStatic.NineDigitZero(++rowCount);

            } while (IsExistScheduleInformationSystemID(userInfo.UserId, sqlConn, scheduleId));

            return scheduleId;
        }

        private static Boolean IsExistScheduleInformationSystemID(String userId, SqlConnection sqlConn, String scheduleId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistsSysIDScheduleInformation";

                sqlComm.Parameters.Add("@sysid_schedule", SqlDbType.VarChar).Value = scheduleId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------

        //this function gets a new schedule information details system id
        public static String GetNewScheduleInformationDetailsSystemID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            Int32 rowCount = 0;
            String scheduleDetailsId = "";

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.GetCountScheduleInformationDetails";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                rowCount = (Int32)sqlComm.ExecuteScalar();
            }

            do
            {
                scheduleDetailsId = "SYSSDL" + ProcStatic.NineDigitZero(++rowCount);

            } while (IsExistScheduleInformationDetailsSystemID(userInfo.UserId, sqlConn, scheduleDetailsId));

            return scheduleDetailsId;
        }

        private static Boolean IsExistScheduleInformationDetailsSystemID(String userId, SqlConnection sqlConn, String scheduleDetailsId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistsSysIDScheduleInformationDetails";

                sqlComm.Parameters.Add("@sysid_scheddetails", SqlDbType.VarChar).Value = scheduleDetailsId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------

        //this function gets a new auxiliary service information system id
        public static String GetNewAuxiliaryServiceInformationSystemID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            Int32 rowCount = 0;
            String serviceId = "";

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.GetCountAuxiliaryServiceInformation";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                rowCount = (Int32)sqlComm.ExecuteScalar();
            }

            do
            {
                serviceId = "SYSSRV" + ProcStatic.SixDigitZero(++rowCount);

            } while (IsExistAuxiliaryServiceInformationSystemID(userInfo.UserId, sqlConn, serviceId));

            return serviceId;
        }

        private static Boolean IsExistAuxiliaryServiceInformationSystemID(String userId, SqlConnection sqlConn, String serviceId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistSysIDAuxiliaryServiceInformation";

                sqlComm.Parameters.Add("@sysid_auxservice", SqlDbType.VarChar).Value = serviceId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------

        //this function gets a new auxiliary service schedule system id
        public static String GetNewAuxiliaryServiceScheduleSystemID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            Int32 rowCount = 0;
            String serviceId = "";

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.GetCountAuxiliaryServiceSchedule";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                rowCount = (Int32)sqlComm.ExecuteScalar();
            }

            do
            {
                serviceId = "SYSASC" + ProcStatic.NineDigitZero(++rowCount);

            } while (IsExistAuxiliaryServiceScheduleSystemID(userInfo.UserId, sqlConn, serviceId));

            return serviceId;
        }

        private static Boolean IsExistAuxiliaryServiceScheduleSystemID(String userId, SqlConnection sqlConn, String serviceId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistsSysIDAuxiliaryServiceSchedule";

                sqlComm.Parameters.Add("@sysid_auxserviceschedule", SqlDbType.VarChar).Value = serviceId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------

        //this function gets a new auxiliary service details system id
        public static String GetNewAuxiliaryServiceDetailsSystemID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            Int32 rowCount = 0;
            String detailsId = "";

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.GetCountAuxiliaryServiceDetails";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                rowCount = (Int32)sqlComm.ExecuteScalar();
            }

            do
            {
                detailsId = "SYSADL" + ProcStatic.NineDigitZero(++rowCount);

            } while (IsExistAuxiliaryServiceDetailsSystemID(userInfo.UserId, sqlConn, detailsId));

            return detailsId;
        }

        private static Boolean IsExistAuxiliaryServiceDetailsSystemID(String userId, SqlConnection sqlConn, String detailsId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistsSysIDAuxiliaryServiceDetails";

                sqlComm.Parameters.Add("@sysid_auxdetails", SqlDbType.VarChar).Value = detailsId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------

        //this function gets a new school fee particular system id
        public static String GetNewSchoolFeeParticularSystemID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            Int32 rowCount = 0;
            String feeId = "";

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.GetCountSchoolFeeParticular";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                rowCount = (Int32)sqlComm.ExecuteScalar();
            }

            do
            {
                feeId = "SYSFPR" + ProcStatic.ThreeDigitZero(++rowCount);

            } while (IsExistSchoolFeeParticularSystemID(userInfo.UserId, sqlConn, feeId));

            return feeId;
        }

        private static Boolean IsExistSchoolFeeParticularSystemID(String userId, SqlConnection sqlConn, String feeId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistsSysIDSchoolFeeParticular";

                sqlComm.Parameters.Add("@sysid_feeparticular", SqlDbType.VarChar).Value = feeId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------

        //this function gets a new school fee information system id
        public static String GetNewSchoolFeeInformationSystemID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            Int32 rowCount = 0;
            String feeId = "";

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.GetCountSchoolFeeInformation";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                rowCount = (Int32)sqlComm.ExecuteScalar();
            }

            do
            {
                feeId = "SYSSCF" + ProcStatic.ThreeDigitZero(++rowCount);

            } while (IsExistSchoolFeeInformationSystemID(userInfo.UserId, sqlConn, feeId));

            return feeId;
        }

        private static Boolean IsExistSchoolFeeInformationSystemID(String userId, SqlConnection sqlConn, String feeId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistsSysIDSchoolFeeInformation";

                sqlComm.Parameters.Add("@sysid_schoolfee", SqlDbType.VarChar).Value = feeId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------

        //this function gets a new school fee level system id
        public static String GetNewSchoolFeeLevelSystemID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            Int32 rowCount = 0;
            String levelId = "";

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.GetCountSchoolFeeLevel";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                rowCount = (Int32)sqlComm.ExecuteScalar();
            }

            do
            {
                levelId = "SYSFLV" + ProcStatic.SixDigitZero(++rowCount);

            } while (IsExistSchoolFeeLevelSystemID(userInfo.UserId, sqlConn, levelId));

            return levelId;
        }

        private static Boolean IsExistSchoolFeeLevelSystemID(String userId, SqlConnection sqlConn, String levelId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistsSysIDSchoolFeeLevel";

                sqlComm.Parameters.Add("@sysid_feelevel", SqlDbType.VarChar).Value = levelId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------

        //this function gets a new student enrolment course system id
        public static String GetNewStudentEnrolmentCourseSystemID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            Int32 rowCount = 0;
            String enrolmentId = "";

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.GetCountStudentEnrolmentCourse";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                rowCount = (Int32)sqlComm.ExecuteScalar();
            }

            do
            {
                enrolmentId = "SYSECR" + ProcStatic.NineDigitZero(++rowCount);

            } while (IsExistStudentEnrolmentCourseSystemID(userInfo.UserId, sqlConn, enrolmentId));

            return enrolmentId;
        }

        private static Boolean IsExistStudentEnrolmentCourseSystemID(String userId, SqlConnection sqlConn, String enrolmentId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistsSysIDStudentEnrolmentCourse";

                sqlComm.Parameters.Add("@sysid_enrolmentcourse", SqlDbType.VarChar).Value = enrolmentId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //------------------------------------------------

        //this function gets a new student enrolment level system id
        public static String GetNewStudentEnrolmentLevelSystemID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            Int32 rowCount = 0;
            String levelId = "";

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.GetCountStudentEnrolmentLevel";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                rowCount = (Int32)sqlComm.ExecuteScalar();
            }

            do
            {
                levelId = "SYSELV" + ProcStatic.NineDigitZero(++rowCount);

            } while (IsExistStudentEnrolmentLevelSystemID(userInfo.UserId, sqlConn, levelId));

            return levelId;
        }

        private static Boolean IsExistStudentEnrolmentLevelSystemID(String userId, SqlConnection sqlConn, String levelId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistsSysIDStudentEnrolmentLevel";

                sqlComm.Parameters.Add("@sysid_enrolmentlevel", SqlDbType.VarChar).Value = levelId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //------------------------------------------------

        //this function gets a new school fee details system id
        public static String GetNewSchoolFeeDetailsSystemID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            Int32 rowCount = 0;
            String detailsId = "";

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.GetCountSchoolFeeDetails";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                rowCount = (Int32)sqlComm.ExecuteScalar();
            }

            do
            {
                detailsId = "SYSFDL" + ProcStatic.NineDigitZero(++rowCount);

            } while (IsExistSchoolFeeDetailsSystemID(userInfo.UserId, sqlConn, detailsId));

            return detailsId;
        }

        private static Boolean IsExistSchoolFeeDetailsSystemID(String userId, SqlConnection sqlConn, String detailsId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistsSysIDSchoolFeeDetails";

                sqlComm.Parameters.Add("@sysid_feedetails", SqlDbType.VarChar).Value = detailsId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------

        //this function gets a new payroll standard system id
        public static String GetNewPayrollStandardSystemID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            Int32 rowCount = 0;
            String payrollId = "";

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.GetCountPayrollStandard";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                rowCount = (Int32)sqlComm.ExecuteScalar();
            }

            do
            {
                payrollId = "SYSPSD" + ProcStatic.FourDigitZero(++rowCount);

            } while (IsExistPayrollStandardSystemID(userInfo.UserId, sqlConn, payrollId));

            return payrollId;
        }

        private static Boolean IsExistPayrollStandardSystemID(String userId, SqlConnection sqlConn, String payrollId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistsSysIDPayrollStandard";

                sqlComm.Parameters.Add("@sysid_payrollstd", SqlDbType.VarChar).Value = payrollId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------

        //this function gets a new registrar standard system id
        public static String GetNewRegistrarStandardSystemID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            Int32 rowCount = 0;
            String registrarId = "";

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.GetCountRegistarStandard";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                rowCount = (Int32)sqlComm.ExecuteScalar();
            }

            do
            {
                registrarId = "SYSRSD" + ProcStatic.FourDigitZero(++rowCount);

            } while (IsExistRegistrarStandardSystemID(userInfo.UserId, sqlConn, registrarId));

            return registrarId;
        }

        private static Boolean IsExistRegistrarStandardSystemID(String userId, SqlConnection sqlConn, String registrarId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistsSysIDRegistrarStandard";

                sqlComm.Parameters.Add("@sysid_registrarstd", SqlDbType.VarChar).Value = registrarId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------

        //this function gets a new finance standard system id
        public static String GetNewFinanceStandardSystemID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            Int32 rowCount = 0;
            String financeId = "";

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.GetCountFinanceStandard";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                rowCount = (Int32)sqlComm.ExecuteScalar();
            }

            do
            {
                financeId = "SYSFSD" + ProcStatic.FourDigitZero(++rowCount);

            } while (IsExistFinanceStandardSystemID(userInfo.UserId, sqlConn, financeId));

            return financeId;
        }

        private static Boolean IsExistFinanceStandardSystemID(String userId, SqlConnection sqlConn, String financeId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistsSysIDFinanceStandard";

                sqlComm.Parameters.Add("@sysid_financestd", SqlDbType.VarChar).Value = financeId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------

        //this function gets a new scholarship information system id
        public static String GetNewScholarshipInformationSystemID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            Int32 rowCount = 0;
            String scholarshipId = "";

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.GetCountScholarshipInformation";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                rowCount = (Int32)sqlComm.ExecuteScalar();
            }

            do
            {
                scholarshipId = "SYSSPI" + ProcStatic.ThreeDigitZero(++rowCount);

            } while (IsExistScholarshipInformationSystemID(userInfo.UserId, sqlConn, scholarshipId));

            return scholarshipId;
        }

        private static Boolean IsExistScholarshipInformationSystemID(String userId, SqlConnection sqlConn, String scholarshipId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistsSysIDScholarshipInformation";

                sqlComm.Parameters.Add("@sysid_scholarship", SqlDbType.VarChar).Value = scholarshipId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------

        //this function gets a new student scholarship system id
        public static String GetNewStudentScholarshipSystemID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            Int32 rowCount = 0;
            String studentScholarshipId = "";

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.GetCountStudentScholarship";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                rowCount = (Int32)sqlComm.ExecuteScalar();
            }

            do
            {
                studentScholarshipId = "SYSSSC" + ProcStatic.NineDigitZero(++rowCount);

            } while (IsExistStudentScholarshipSystemID(userInfo.UserId, sqlConn, studentScholarshipId));

            return studentScholarshipId;
        }

        private static Boolean IsExistStudentScholarshipSystemID(String userId, SqlConnection sqlConn, String studentScholarshipId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistsSysIDStudentScholarshipStudentScholarship";

                sqlComm.Parameters.Add("@sysid_studentscholarship", SqlDbType.VarChar).Value = studentScholarshipId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------

        //this function gets a new student transcript information system id
        public static String GetNewTranscriptInformationSystemID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            Int32 rowCount = 0;
            String transcriptId = "";

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.GetCountTranscriptInformation";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                rowCount = (Int32)sqlComm.ExecuteScalar();
            }

            do
            {
                transcriptId = "SYSTOR" + ProcStatic.NineDigitZero(++rowCount);

            } while (IsExistTranscriptInformationSystemID(userInfo.UserId, sqlConn, transcriptId));

            return transcriptId;
        }

        private static Boolean IsExistTranscriptInformationSystemID(String userId, SqlConnection sqlConn, String transcriptId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistSysIDTranscriptInformation";

                sqlComm.Parameters.Add("@sysid_transcript", SqlDbType.VarChar).Value = transcriptId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------

        //this function gets a new chart of accounts system id
        public static String GetNewChartOfAccountsSystemID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            Int32 rowCount = 0;
            String accountId = "";

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.GetCountChartOfAccounts";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userInfo.UserId;

                rowCount = (Int32)sqlComm.ExecuteScalar();
            }

            do
            {
                accountId = "SYSCOA" + ProcStatic.FiveDigitZero(++rowCount);

            } while (IsExistsSysIDChartOfAccount(userInfo.UserId, sqlConn, accountId));

            return accountId;
        }

        private static Boolean IsExistsSysIDChartOfAccount(String userId, SqlConnection sqlConn, String accountId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistsSysIDChartOfAccount";

                sqlComm.Parameters.Add("@sysid_account", SqlDbType.VarChar).Value = accountId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------
        
        //this function gets a new system user id
        public static String GetNewSystemUserID(CommonExchange.SysAccess userInfo, SqlConnection sqlConn)
        {
            StringBuilder newUserId;

            do
            {
                newUserId = new StringBuilder();

                Int32 sSpecial, eSpecial, sUChar, eUChar, sLChar, eLChar, delimeter, oSqBracket, cSqBracket;

                sSpecial = Convert.ToInt32('!');
                eSpecial = Convert.ToInt32('?');
                sUChar = Convert.ToInt32('@');
                eUChar = Convert.ToInt32('_');
                sLChar = Convert.ToInt32('`');
                eLChar = Convert.ToInt32('~');
                delimeter = Convert.ToInt32('#');
                oSqBracket = Convert.ToInt32('[');
                cSqBracket = Convert.ToInt32(']');

                newUserId.Append(Convert.ToChar(delimeter).ToString());

                for (Int32 i = 1; i <= 26; i++)
                {
                    Boolean isValid = false;
                    Int32 iRandom = 0;

                    Thread.Sleep(15);

                    Random randObj = new Random(DateTime.Now.Millisecond);

                    do
                    {
                        iRandom = randObj.Next(sSpecial, eLChar);

                        if ((((iRandom >= sSpecial) && (iRandom <= eSpecial)) ||
                            ((iRandom >= sUChar) && (iRandom <= eUChar)) ||
                            ((iRandom >= sLChar) && (iRandom <= eLChar))) &&
                            (iRandom != delimeter) && (iRandom != oSqBracket) && (iRandom != cSqBracket))
                        {
                            newUserId.Append(Convert.ToChar(iRandom).ToString());
                            isValid = true;
                        }

                    } while (!isValid);
                }

                newUserId.Append(Convert.ToChar(delimeter).ToString());

            } while (IsExistsIDSystemUserInfo(userInfo.UserId, sqlConn, newUserId.ToString()));

            return newUserId.ToString();
        }

        private static Boolean IsExistsIDSystemUserInfo(String userId, SqlConnection sqlConn, String newUserId)
        {
            Boolean isExist = false;

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.IsExistsIDSystemUserInformation";

                sqlComm.Parameters.Add("@new_user_id", SqlDbType.VarChar).Value = newUserId;
                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                isExist = (Boolean)sqlComm.ExecuteScalar();
            }

            return isExist;

        } //-----------------------------


        #endregion
    }
}
