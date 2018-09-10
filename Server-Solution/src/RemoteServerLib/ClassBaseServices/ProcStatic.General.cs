using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Data.SqlClient;

namespace RemoteServerLib
{
    [Serializable()]
    public partial class ProcStatic
    {
        #region Programmer-Defined Function Procedures

        //this function returns the code reference table
        public static DataTable GetCodeReferenceTable(SqlConnection sqlConn, String userId)
        {
            DataTable dbTable = new DataTable("CodeReferenceTable");

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectCodeReference";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                {
                    sqlAdapter.SelectCommand = sqlComm;
                    sqlAdapter.Fill(dbTable);
                }
            } 

            return dbTable;
        } //--------------------------------

        //this function returns the relationship type table
        public static DataTable GetRelationshipTypeTable(SqlConnection sqlConn, String userId)
        {
            DataTable dbTable = new DataTable("RelationshipTypeTable");

            using (SqlCommand sqlComm = new SqlCommand())
            {
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ums.SelectRelationshipType";

                sqlComm.Parameters.Add("@system_user_id", SqlDbType.VarChar).Value = userId;

                using (SqlDataAdapter sqlAdapter = new SqlDataAdapter())
                {
                    sqlAdapter.SelectCommand = sqlComm;
                    sqlAdapter.Fill(dbTable);
                }
            }

            return dbTable;
        } //--------------------------------

        //this function determines if the access code is admin
        public static Boolean IsSystemAccessAdmin(CommonExchange.SysAccess userInfo)
        {
            foreach (CommonExchange.AccessRightsGranted access in userInfo.AccessRightsGrantedList)
            {
                if (access.AccessRightsInfo.AccessIndex == 0 && userInfo.UserStatus)
                {
                    return true;
                }
            }
                
            return false;
        } //---------------------------

        //this function determines if the access code is payroll administrator
        public static Boolean IsSystemAccessPayrollMaster(CommonExchange.SysAccess userInfo)
        {
            foreach (CommonExchange.AccessRightsGranted access in userInfo.AccessRightsGrantedList)
            {
                if (access.AccessRightsInfo.AccessIndex == 1 && userInfo.UserStatus)
                {
                    return true;
                }
            }

            return false;
        } //--------------------------------

        //this function determines if the access code is an office user
        public static Boolean IsSystemAccessOfficeUser(CommonExchange.SysAccess userInfo)
        {
            foreach (CommonExchange.AccessRightsGranted access in userInfo.AccessRightsGrantedList)
            {
                if (access.AccessRightsInfo.AccessIndex == 2 && userInfo.UserStatus)
                {
                    return true;
                }
            }

            return false;
        } //--------------------------------

        //this function determines if the access code is an office user
        public static Boolean IsSystemAccessOfficeUser(CommonExchange.SysAccess userInfo, String deptId)
        {
            foreach (CommonExchange.AccessRightsGranted access in userInfo.AccessRightsGrantedList)
            {
                if (access.AccessRightsInfo.AccessIndex == 2 && userInfo.UserStatus && String.Equals(access.DepartmentInfo.DepartmentId, deptId))
                {
                    return true;
                }
            }

            return false;
        } //--------------------------------

        //this function determines if the access code is college registrar
        public static Boolean IsSystemAccessCollegeRegistrar(CommonExchange.SysAccess userInfo)
        {
            foreach (CommonExchange.AccessRightsGranted access in userInfo.AccessRightsGrantedList)
            {
                if (access.AccessRightsInfo.AccessIndex == 3 && userInfo.UserStatus)
                {
                    return true;
                }
            }

            return false;
        } //--------------------------------

        //this function determines if the access code is high school and grade school registrar
        public static Boolean IsSystemAccessHighSchoolGradeSchoolRegistrar(CommonExchange.SysAccess userInfo)
        {
            foreach (CommonExchange.AccessRightsGranted access in userInfo.AccessRightsGrantedList)
            {
                if (access.AccessRightsInfo.AccessIndex == 4 && userInfo.UserStatus)
                {
                    return true;
                }
            }

            return false;
        } //--------------------------------

        //this function determines if the access code is a student data controller
        public static Boolean IsSystemAccessStudentDataController(CommonExchange.SysAccess userInfo)
        {
            foreach (CommonExchange.AccessRightsGranted access in userInfo.AccessRightsGrantedList)
            {
                if (access.AccessRightsInfo.AccessIndex == 5 && userInfo.UserStatus)
                {
                    return true;
                }
            }

            return false;
        } //--------------------------------

        //this function determines if the access code is an ID Maker
        public static Boolean IsSystemAccessIDMaker(CommonExchange.SysAccess userInfo)
        {
            foreach (CommonExchange.AccessRightsGranted access in userInfo.AccessRightsGrantedList)
            {
                if (access.AccessRightsInfo.AccessIndex == 6 && userInfo.UserStatus)
                {
                    return true;
                }
            }

            return false;
        } //--------------------------------

        //this function determines if the access code is a gatekeeper
        public static Boolean IsSystemAccessGateKeepers(CommonExchange.SysAccess userInfo)
        {
            foreach (CommonExchange.AccessRightsGranted access in userInfo.AccessRightsGrantedList)
            {
                if (access.AccessRightsInfo.AccessIndex == 7 && userInfo.UserStatus)
                {
                    return true;
                }
            }

            return false;
        } //--------------------------------

        //this function determines if the access code is a cashier
        public static Boolean IsSystemAccessCashier(CommonExchange.SysAccess userInfo)
        {
            foreach (CommonExchange.AccessRightsGranted access in userInfo.AccessRightsGrantedList)
            {
                if (access.AccessRightsInfo.AccessIndex == 8 && userInfo.UserStatus)
                {
                    return true;
                }
            }

            return false;
        } //--------------------------------

        //this function determines if the access code is a bookkeeper
        public static Boolean IsSystemAccessBookkeeper(CommonExchange.SysAccess userInfo)
        {
            foreach (CommonExchange.AccessRightsGranted access in userInfo.AccessRightsGrantedList)
            {
                if (access.AccessRightsInfo.AccessIndex == 9 && userInfo.UserStatus)
                {
                    return true;
                }
            }

            return false;
        } //--------------------------------

        //this function determines if the access code is the VP of Finance
        public static Boolean IsSystemAccessVpOfFinance(CommonExchange.SysAccess userInfo)
        {
            foreach (CommonExchange.AccessRightsGranted access in userInfo.AccessRightsGrantedList)
            {
                if (access.AccessRightsInfo.AccessIndex == 10 && userInfo.UserStatus)
                {
                    return true;
                }
            }

            return false;
        } //--------------------------------  

        //this function determines if the access code is the Secretary of the VP of Academic Affairs
        public static Boolean IsSystemAccessSecretaryOftheVpOfAcademicAffairs(CommonExchange.SysAccess userInfo)
        {
            foreach (CommonExchange.AccessRightsGranted access in userInfo.AccessRightsGrantedList)
            {
                if (access.AccessRightsInfo.AccessIndex == 11 && userInfo.UserStatus)
                {
                    return true;
                }
            }

            return false;
        } //--------------------------------  

        //this function determines if the access code is the VP of Academic Affairs
        public static Boolean IsSystemAccessVpOfAcademicAffairs(CommonExchange.SysAccess userInfo)
        {
            foreach (CommonExchange.AccessRightsGranted access in userInfo.AccessRightsGrantedList)
            {
                if (access.AccessRightsInfo.AccessIndex == 12 && userInfo.UserStatus)
                {
                    return true;
                }
            }

            return false;
        } //-------------------------------- 

        //this function returns a two digit number
        public static String TwoDigitZero(Int32 numBase)
        {
            String strPrefix = "";

            if (numBase <= 9)
            {
                strPrefix = "0";
            }

            return strPrefix + numBase.ToString();
        } //-----------------------------------

        //this function returns a three digit number
        public static String ThreeDigitZero(Int32 numBase)
        {
            String strPrefix = "";

            if (numBase > 99)
            {
                strPrefix = "";
            }
            else if (numBase > 9)
            {
                strPrefix = "0";
            }
            else
            {
                strPrefix = "00";
            }

            return strPrefix + numBase.ToString();

        } //-------------------------------------

        //this function returns a four digit number
        public static String FourDigitZero(Int32 numBase)
        {
            String strPrefix = "";

            if (numBase > 999)
            {
                strPrefix = "";
            }
            else if (numBase > 99)
            {
                strPrefix = "0";
            }
            else if (numBase > 9)
            {
                strPrefix = "00";
            }
            else
            {
                strPrefix = "000";
            }

            return strPrefix + numBase.ToString();

        } //-------------------------------

        //this function return a five digit number
        public static String FiveDigitZero(Int32 numBase)
        {
            String strPrefix = "";

            if (numBase > 9999)
            {
                strPrefix = "";
            }
            else if (numBase > 999)
            {
                strPrefix = "0";
            }
            else if (numBase > 99)
            {
                strPrefix = "00";
            }
            else if (numBase > 9)
            {
                strPrefix = "000";
            }
            else
            {
                strPrefix = "0000";
            }

            return strPrefix + numBase.ToString();
        } //---------------------------------------

        //this function return a six digit number
        public static String SixDigitZero(Int32 numBase)
        {
            String strPrefix = "";

            if (numBase > 99999)
            {
                strPrefix = "";
            }
            else if (numBase > 9999)
            {
                strPrefix = "0";
            }
            else if (numBase > 999)
            {
                strPrefix = "00";
            }
            else if (numBase > 99)
            {
                strPrefix = "000";
            }
            else if (numBase > 9)
            {
                strPrefix = "0000";
            }
            else
            {
                strPrefix = "00000";
            }

            return strPrefix + numBase.ToString();
        } //---------------------------------------

        //this function return a seven digit number
        public static String SevenDigitZero(Int32 numBase)
        {
            String strPrefix = "";

            if (numBase > 999999)
            {
                strPrefix = "";
            }
            else if (numBase > 99999)
            {
                strPrefix = "0";
            }
            else if (numBase > 9999)
            {
                strPrefix = "00";
            }
            else if (numBase > 999)
            {
                strPrefix = "000";
            }
            else if (numBase > 99)
            {
                strPrefix = "0000";
            }
            else if (numBase > 9)
            {
                strPrefix = "00000";
            }
            else
            {
                strPrefix = "000000";
            }

            return strPrefix + numBase.ToString();
        } //---------------------------------------

        //this function return a eight digit number
        public static String EightDigitZero(Int32 numBase)
        {
            String strPrefix = "";

            if (numBase > 9999999)
            {
                strPrefix = "";
            }
            else if (numBase > 999999)
            {
                strPrefix = "0";
            }
            else if (numBase > 99999)
            {
                strPrefix = "00";
            }
            else if (numBase > 9999)
            {
                strPrefix = "000";
            }
            else if (numBase > 999)
            {
                strPrefix = "0000";
            }
            else if (numBase > 99)
            {
                strPrefix = "00000";
            }
            else if (numBase > 9)
            {
                strPrefix = "000000";
            }
            else
            {
                strPrefix = "0000000";
            }

            return strPrefix + numBase.ToString();
        } //---------------------------------------

        //this function return a nine digit number
        public static String NineDigitZero(Int32 numBase)
        {
            String strPrefix = "";

            if (numBase > 99999999)
            {
                strPrefix = "";
            }
            else if (numBase > 9999999)
            {
                strPrefix = "0";
            }
            else if (numBase > 999999)
            {
                strPrefix = "00";
            }
            else if (numBase > 99999)
            {
                strPrefix = "000";
            }
            else if (numBase > 9999)
            {
                strPrefix = "0000";
            }
            else if (numBase > 999)
            {
                strPrefix = "00000";
            }
            else if (numBase > 99)
            {
                strPrefix = "000000";
            }
            else if (numBase > 9)
            {
                strPrefix = "0000000";
            }
            else
            {
                strPrefix = "00000000";
            }

            return strPrefix + numBase.ToString();
        } //---------------------------------------

        //this function return a ten digit number
        public static String TenDigitZero(Int64 numBase)
        {
            String strPrefix = "";

            if (numBase > 999999999)
            {
                strPrefix = "";
            }
            else if (numBase > 99999999)
            {
                strPrefix = "0";
            }
            else if (numBase > 9999999)
            {
                strPrefix = "00";
            }
            else if (numBase > 999999)
            {
                strPrefix = "000";
            }
            else if (numBase > 99999)
            {
                strPrefix = "0000";
            }
            else if (numBase > 9999)
            {
                strPrefix = "00000";
            }
            else if (numBase > 999)
            {
                strPrefix = "000000";
            }
            else if (numBase > 99)
            {
                strPrefix = "0000000";
            }
            else if (numBase > 9)
            {
                strPrefix = "00000000";
            }
            else
            {
                strPrefix = "000000000";
            }

            return strPrefix + numBase.ToString();
        } //---------------------------------------

        //this function return a eleven digit number
        public static String ElevenDigitZero(Int64 numBase)
        {
            String strPrefix = "";

            if (numBase > 9999999999)
            {
                strPrefix = "";
            }
            else if (numBase > 999999999)
            {
                strPrefix = "0";
            }
            else if (numBase > 99999999)
            {
                strPrefix = "00";
            }
            else if (numBase > 9999999)
            {
                strPrefix = "000";
            }
            else if (numBase > 999999)
            {
                strPrefix = "0000";
            }
            else if (numBase > 99999)
            {
                strPrefix = "00000";
            }
            else if (numBase > 9999)
            {
                strPrefix = "000000";
            }
            else if (numBase > 999)
            {
                strPrefix = "0000000";
            }
            else if (numBase > 99)
            {
                strPrefix = "00000000";
            }
            else if (numBase > 9)
            {
                strPrefix = "000000000";
            }
            else
            {
                strPrefix = "0000000000";
            }

            return strPrefix + numBase.ToString();
        } //---------------------------------------

        //this function return a twelve digit number
        public static String TwelveDigitZero(Int64 numBase)
        {
            String strPrefix = "";

            if (numBase > 99999999999)
            {
                strPrefix = "";
            }
            else if (numBase > 9999999999)
            {
                strPrefix = "0";
            }
            else if (numBase > 999999999)
            {
                strPrefix = "00";
            }
            else if (numBase > 99999999)
            {
                strPrefix = "000";
            }
            else if (numBase > 9999999)
            {
                strPrefix = "0000";
            }
            else if (numBase > 999999)
            {
                strPrefix = "00000";
            }
            else if (numBase > 99999)
            {
                strPrefix = "000000";
            }
            else if (numBase > 9999)
            {
                strPrefix = "0000000";
            }
            else if (numBase > 999)
            {
                strPrefix = "00000000";
            }
            else if (numBase > 99)
            {
                strPrefix = "000000000";
            }
            else if (numBase > 9)
            {
                strPrefix = "0000000000";
            }
            else
            {
                strPrefix = "00000000000";
            }

            return strPrefix + numBase.ToString();
        } //---------------------------------------
        
        //this function converts a datarow to strings
        public static String DataRowConvert(DataRow rowName, String columnName, String defaultValue)
        {
            if (!(rowName[columnName] is DBNull) && !(String.IsNullOrEmpty(rowName[columnName].ToString().Trim())))
            {
                return rowName[columnName].ToString();
            }
            else
            {
                return defaultValue;
            }

        } //----------------------------

        //this function converts a datarow to datetime
        public static DateTime DataRowConvert(DataRow rowName, String columnName, DateTime defaultValue)
        {
            DateTime result;

            if (!(rowName[columnName] is DBNull) && !(String.IsNullOrEmpty(rowName[columnName].ToString().Trim())) &&
                DateTime.TryParse(rowName[columnName].ToString(), out result))
            {
                return result;
            }
            else
            {
                return defaultValue;
            }

        } //-----------------------

        //this function converts a datarow to decimal
        public static Decimal DataRowConvert(DataRow rowName, String columnName, Decimal defaultValue)
        {
            Decimal result;

            if (!(rowName[columnName] is DBNull) && !(String.IsNullOrEmpty(rowName[columnName].ToString().Trim())) &&
                Decimal.TryParse(rowName[columnName].ToString(), out result))
            {
                return result;
            }
            else
            {
                return defaultValue;
            }

        } //-----------------------

        //this function converts a datarow to byte
        public static Byte DataRowConvert(DataRow rowName, String columnName, Byte defaultValue)
        {
            Byte result;

            if (!(rowName[columnName] is DBNull) && !(String.IsNullOrEmpty(rowName[columnName].ToString().Trim())) &&
                Byte.TryParse(rowName[columnName].ToString(), out result))
            {
                return result;
            }
            else
            {
                return defaultValue;
            }

        } //-----------------------

        //this function converts a datarow to Int16
        public static Int16 DataRowConvert(DataRow rowName, String columnName, Int16 defaultValue)
        {
            Int16 result;

            if (!(rowName[columnName] is DBNull) && !(String.IsNullOrEmpty(rowName[columnName].ToString().Trim())) &&
                Int16.TryParse(rowName[columnName].ToString(), out result))
            {
                return result;
            }
            else
            {
                return defaultValue;
            }

        } //-----------------------

        //this function converts a datarow to Int64
        public static Int64 DataRowConvert(DataRow rowName, String columnName, Int64 defaultValue)
        {
            Int64 result;

            if (!(rowName[columnName] is DBNull) && !(String.IsNullOrEmpty(rowName[columnName].ToString().Trim())) &&
                Int64.TryParse(rowName[columnName].ToString(), out result))
            {
                return result;
            }
            else
            {
                return defaultValue;
            }

        } //-----------------------


        //this function converts a datarow to boolean
        public static Boolean DataRowConvert(DataRow rowName, String columnName, Boolean defaultValue)
        {
            Boolean result;

            if (!(rowName[columnName] is DBNull) && !(String.IsNullOrEmpty(rowName[columnName].ToString().Trim())) &&
                Boolean.TryParse(rowName[columnName].ToString(), out result))
            {
                return result;
            }
            else
            {
                return defaultValue;
            }

        } //-----------------------

        //this function converts a datarow to Single
        public static Single DataRowConvert(DataRow rowName, String columnName, Single defaultValue)
        {
            Single result;

            if (!(rowName[columnName] is DBNull) && !(String.IsNullOrEmpty(rowName[columnName].ToString().Trim())) &&
                Single.TryParse(rowName[columnName].ToString(), out result))
            {
                return result;
            }
            else
            {
                return defaultValue;
            }

        } //-----------------------

        //this function converts a datarow to Single
        public static Double DataRowConvert(DataRow rowName, String columnName, Double defaultValue)
        {
            Double result;

            if (!(rowName[columnName] is DBNull) && !(String.IsNullOrEmpty(rowName[columnName].ToString().Trim())) &&
                Double.TryParse(rowName[columnName].ToString(), out result))
            {
                return result;
            }
            else
            {
                return defaultValue;
            }

        } //-----------------------

        //this function converts a datareader to string
        public static String DataReaderConvert(SqlDataReader readerName, String columnName, String defaultValue)
        {
            if (!(readerName[columnName] is DBNull) && !(String.IsNullOrEmpty(readerName[columnName].ToString().Trim())))
            {
                return readerName[columnName].ToString();
            }
            else
            {
                return defaultValue;
            }
        } //-----------------------------

        //this function converts a datareader to datetime
        public static DateTime DataReaderConvert(SqlDataReader readerName, String columnName, DateTime defaultValue)
        {
            DateTime result;

            if (!(readerName[columnName] is DBNull) && !(String.IsNullOrEmpty(readerName[columnName].ToString().Trim())) && 
                DateTime.TryParse(readerName[columnName].ToString(), out result))
            {
                return result;
            }
            else
            {
                return defaultValue;
            }

        } //-----------------------------

        //this function converts a datareader to Int64
        public static Int64 DataReaderConvert(SqlDataReader readerName, String columnName, Int64 defaultValue)
        {
            Int64 result;

            if (!(readerName[columnName] is DBNull) && !(String.IsNullOrEmpty(readerName[columnName].ToString().Trim())) && 
                Int64.TryParse(readerName[columnName].ToString(), out result))
            {
                return result;
            }
            else
            {
                return defaultValue;
            }

        } //-----------------------------

        //this function converts a datareader to Int32
        public static Int32 DataReaderConvert(SqlDataReader readerName, String columnName, Int32 defaultValue)
        {
            Int32 result;

            if (!(readerName[columnName] is DBNull) && !(String.IsNullOrEmpty(readerName[columnName].ToString().Trim())) && 
                Int32.TryParse(readerName[columnName].ToString(), out result))
            {
                return result;
            }
            else
            {
                return defaultValue;
            }

        } //-----------------------------

        //this function converts a datareader to Boolean
        public static Boolean DataReaderConvert(SqlDataReader readerName, String columnName, Boolean defaultValue)
        {
            Boolean result;

            if (!(readerName[columnName] is DBNull) && !(String.IsNullOrEmpty(readerName[columnName].ToString().Trim())) && 
                Boolean.TryParse(readerName[columnName].ToString(), out result))
            {
                return result;
            }
            else
            {
                return defaultValue;
            }

        } //-----------------------------

        //this function converts a datareader to Decimal
        public static Decimal DataReaderConvert(SqlDataReader readerName, String columnName, Decimal defaultValue)
        {
            Decimal result;

            if (!(readerName[columnName] is DBNull) && !(String.IsNullOrEmpty(readerName[columnName].ToString().Trim())) &&
                Decimal.TryParse(readerName[columnName].ToString(), out result))
            {
                return result;
            }
            else
            {
                return defaultValue;
            }

        } //-----------------------------

        //this function converts a datareader to Byte
        public static Byte DataReaderConvert(SqlDataReader readerName, String columnName, Byte defaultValue)
        {
            Byte result;

            if (!(readerName[columnName] is DBNull) && !(String.IsNullOrEmpty(readerName[columnName].ToString().Trim())) &&
                Byte.TryParse(readerName[columnName].ToString(), out result))
            {
                return result;
            }
            else
            {
                return defaultValue;
            }

        } //-----------------------------

        //this function converts a datareader to Int16
        public static Int16 DataReaderConvert(SqlDataReader readerName, String columnName, Int16 defaultValue)
        {
            Int16 result;

            if (!(readerName[columnName] is DBNull) && !(String.IsNullOrEmpty(readerName[columnName].ToString().Trim())) &&
                Int16.TryParse(readerName[columnName].ToString(), out result))
            {
                return result;
            }
            else
            {
                return defaultValue;
            }

        } //-----------------------------

        //this function converts a datareader to Single
        public static Single DataReaderConvert(SqlDataReader readerName, String columnName, Single defaultValue)
        {
            Single result;

            if (!(readerName[columnName] is DBNull) && !(String.IsNullOrEmpty(readerName[columnName].ToString().Trim())) &&
                Single.TryParse(readerName[columnName].ToString(), out result))
            {
                return result;
            }
            else
            {
                return defaultValue;
            }

        } //-----------------------------

        //this function converts a datareader to Double
        public static Double DataReaderConvert(SqlDataReader readerName, String columnName, Double defaultValue)
        {
            Double result;

            if (!(readerName[columnName] is DBNull) && !(String.IsNullOrEmpty(readerName[columnName].ToString().Trim())) &&
                Double.TryParse(readerName[columnName].ToString(), out result))
            {
                return result;
            }
            else
            {
                return defaultValue;
            }

        } //-----------------------------


        #endregion
    }
}
