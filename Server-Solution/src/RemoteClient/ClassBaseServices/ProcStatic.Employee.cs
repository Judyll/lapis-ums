using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace RemoteClient
{
    partial class ProcStatic
    {
        #region Programmer-Defined Function Procedures

        //this function gets the selected employee
        public static DataTable GetEmployeeInformationFilterStatusAndType(ClientExchange.EmployeeSearchFilter searchFilter, DataTable employeeTable)
        {
            DataTable newTable = new DataTable("EmployeeSearchByStatusAndTypeTable");
            newTable.Columns.Add("sysid_employee", System.Type.GetType("System.String"));
            newTable.Columns.Add("employee_id", System.Type.GetType("System.String"));
            newTable.Columns.Add("card_number", System.Type.GetType("System.String"));
            newTable.Columns.Add("employee_name", System.Type.GetType("System.String"));

            String strStatus = "(";

            if (searchFilter.IncludePartTime)
            {
                strStatus += "status_id = '" + (Byte)CommonExchange.EmploymentStatusNo.TemporaryPartTime + "' OR ";
            }

            if (searchFilter.IncludeProbationary)
            {
                strStatus += "status_id = '" + (Byte)CommonExchange.EmploymentStatusNo.Probationary + "' OR ";
            }

            if (searchFilter.IncludeRegular)
            {
                strStatus += "status_id = '" + (Byte)CommonExchange.EmploymentStatusNo.Regular + "' OR ";
            }

            if (searchFilter.IncludeLayOff)
            {
                strStatus += "status_id = '" + (Byte)CommonExchange.EmploymentStatusNo.LayOff + "' OR ";
            }

            if (!String.IsNullOrEmpty(strStatus.Trim("()".ToCharArray())))
            {
                strStatus = strStatus.Substring(0, strStatus.Length - 4);
                strStatus += ")";
            }
            else
            {
                strStatus = strStatus.Trim("()".ToCharArray());
            }

            String strType = "(";

            if (searchFilter.IncludeGraduateSchoolFaculty)
            {
                strType += "type_no = '" + (Byte)CommonExchange.EmploymentTypeNo.GraduateSchoolFaculty + "' OR ";
            }

            if (searchFilter.IncludeGraduateSchoolCollegeFaculty)
            {
                strType += "type_no = '" + (Byte)CommonExchange.EmploymentTypeNo.GraduateSchoolCollegeFaculty + "' OR ";
            }

            if (searchFilter.IncludeGraduateSchoolHighSchoolFaculty)
            {
                strType += "type_no = '" + (Byte)CommonExchange.EmploymentTypeNo.GraduateSchoolHighSchoolFaculty + "' OR ";
            }

            if (searchFilter.IncludeGraduateSchoolGradeKinderFaculty)
            {
                strType += "type_no = '" + (Byte)CommonExchange.EmploymentTypeNo.GraduateSchoolGradeKinderFaculty + "' OR ";
            }

            if (searchFilter.IncludeCollegeFaculty)
            {
                strType += "type_no = '" + (Byte)CommonExchange.EmploymentTypeNo.CollegeFaculty + "' OR ";
            }

            if (searchFilter.IncludeHighSchoolFaculty)
            {
                strType += "type_no = '" + (Byte)CommonExchange.EmploymentTypeNo.HighSchoolFaculty + "' OR ";
            }

            if (searchFilter.IncludeGradeKinderFaculty)
            {
                strType += "type_no = '" + (Byte)CommonExchange.EmploymentTypeNo.GradeKinderFaculty + "' OR ";
            }

            if (searchFilter.IncludeStaff)
            {
                strType += "type_no = '" + (Byte)CommonExchange.EmploymentTypeNo.NonTeachingStaff + "' OR ";
            }

            if (searchFilter.IncludeAcademic)
            {
                strType += "type_no = '" + (Byte)CommonExchange.EmploymentTypeNo.AcademicNonTeaching + "' OR ";
            }

            if (searchFilter.IncludeMaintenance)
            {
                strType += "type_no = '" + (Byte)CommonExchange.EmploymentTypeNo.Maintenance + "' OR ";
            }

            if (!String.IsNullOrEmpty(strType.Trim("()".ToCharArray())))
            {
                strType = strType.Substring(0, strType.Length - 4);
                strType += ")";
            }
            else
            {
                strType = strType.Trim("()".ToCharArray());
            }

            String strAdvance = "";

            if (!String.IsNullOrEmpty(strStatus) && !String.IsNullOrEmpty(strType))
            {
                strAdvance += strStatus + " AND " + strType;
            }
            else
            {
                strAdvance += (!String.IsNullOrEmpty(strStatus)) ? strStatus : strType;
            }

            DataRow[] selectTemp = employeeTable.Select(strAdvance, "last_name ASC");

            foreach (DataRow empRow in selectTemp)
            {
                DataRow newRow = newTable.NewRow();

                newRow["sysid_employee"] = empRow["sysid_employee"].ToString();
                newRow["employee_id"] = empRow["employee_id"].ToString();
                newRow["card_number"] = empRow["card_number"].ToString();
                newRow["employee_name"] = empRow["last_name"].ToString().ToUpper() + ", " + empRow["first_name"].ToString() + 
                    " " + empRow["middle_name"].ToString();

                newTable.Rows.Add(newRow);
            }

            newTable.AcceptChanges();

            return newTable;

        } //-------------------------------

        #endregion

    }
}
