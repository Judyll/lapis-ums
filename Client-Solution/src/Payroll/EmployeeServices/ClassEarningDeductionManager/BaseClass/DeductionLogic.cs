using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Globalization;

namespace EmployeeServices
{
    internal class DeductionLogic
    {
        #region Class General Variable Declarations
        private DataSet _classDataSet;
        private DataTable _empTableBySearch;
        private DataTable _decTableByDate;
        private DataTable _decTableBySearch;
        #endregion

        #region Class Properties Declarations
        private String _serverDateTime;
        public String ServerDateTime
        {
            get { return _serverDateTime; }
        }

        public Int32 RowCount
        {
            get { return _decTableBySearch.Rows.Count; }
        }

        #endregion

        #region Class Constructor
        public DeductionLogic(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);
        }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure prints the employee deduction list
        public void PrintEmployeeDeductionList(CommonExchange.SysAccess userInfo, CommonExchange.Employee empInfo, DateTime dateFrom,
            DateTime dateTo)
        {
            DataTable reportTable = new DataTable("EarningDeduction");
            reportTable.Columns.Add("id", System.Type.GetType("System.Int64"));
            reportTable.Columns.Add("date_string", System.Type.GetType("System.String"));
            reportTable.Columns.Add("description", System.Type.GetType("System.String"));
            reportTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));

            foreach (DataRow decRow in _decTableBySearch.Rows)
            {
                DataRow newRow = reportTable.NewRow();

                newRow["id"] = decRow["deduction_id"];
                newRow["date_string"] = DateTime.Parse(decRow["deduction_date"].ToString()).ToShortDateString() + " " + 
                                            DateTime.Parse(decRow["deduction_date"].ToString()).ToShortTimeString();
                newRow["description"] = decRow["deduction_description"];
                newRow["amount"] = decRow["amount"];

                reportTable.Rows.Add(newRow);
            }
            
            reportTable.AcceptChanges();

            using (ClassEarningDeductionManager.CrystalReport.CrystalEmployeeEarningDeductionList rptDeduction =
                new EmployeeServices.ClassEarningDeductionManager.CrystalReport.CrystalEmployeeEarningDeductionList())
            {
                rptDeduction.Database.Tables["earning_deduction"].SetDataSource(reportTable);

                rptDeduction.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                rptDeduction.SetParameterValue("@address", CommonExchange.SchoolInformation.Address);
                rptDeduction.SetParameterValue("@phone_nos", CommonExchange.SchoolInformation.PhoneNos);
                rptDeduction.SetParameterValue("@report_name", "Employee Deduction Summary");
                rptDeduction.SetParameterValue("@date_covered", "as of " + dateFrom.ToLongDateString() + " to " + dateTo.ToLongDateString());
                rptDeduction.SetParameterValue("@employee_id", empInfo.EmployeeId);
                rptDeduction.SetParameterValue("@employee_name", RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(empInfo.PersonInfo.LastName,
                    empInfo.PersonInfo.FirstName, empInfo.PersonInfo.MiddleName));
                rptDeduction.SetParameterValue("@printer_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " + 
                                    DateTime.Parse(_serverDateTime).ToShortTimeString() + "      Printed by: " +
                                    RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName, userInfo.PersonInfo.FirstName, 
                                    userInfo.PersonInfo.MiddleName));
                rptDeduction.SetParameterValue("@total", "Total deductions-to-date:");

                using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptDeduction))
                {
                    frmViewer.ShowDialog();
                }
            }

        } //-----------------------------------------

        //this procedure deletes an employee deduction
        public void DeleteEmployeeDeduction(CommonExchange.SysAccess userInfo, CommonExchange.DeductionInformation decInfo)
        {
            using (RemoteClient.RemCntDeductionManager remClient = new RemoteClient.RemCntDeductionManager())
            {
                remClient.DeleteEmployeeDeduction(userInfo, decInfo);
            }

            Int32 index = 0;

            foreach (DataRow decRow in _decTableByDate.Rows)
            {
                if (decRow.RowState != DataRowState.Deleted)
                {
                    if ((Int64)decRow["deduction_id"] == decInfo.DeductionId)
                    {
                        DataRow delRow = _decTableByDate.Rows[index];

                        delRow.Delete();

                        break;
                    }

                    index++;
                }
            }

            _decTableByDate.AcceptChanges();

        } //---------------------------------

        //this procedure updates an employee deduction
        public void UpdateEmployeeDeduction(CommonExchange.SysAccess userInfo, CommonExchange.DeductionInformation decInfo)
        {
            using (RemoteClient.RemCntDeductionManager remClient = new RemoteClient.RemCntDeductionManager())
            {
                remClient.UpdateEmployeeDeduction(userInfo, decInfo);
            }

            Int32 index = 0;

            foreach (DataRow decRow in _decTableByDate.Rows)
            {
                if (decRow.RowState != DataRowState.Deleted)
                {
                    if ((Int64)decRow["deduction_id"] == decInfo.DeductionId)
                    {
                        DataRow editRow = _decTableByDate.Rows[index];

                        editRow.BeginEdit();

                        editRow["deduction_date"] = DateTime.Parse(decInfo.DeductionDate).ToString();
                        editRow["amount"] = decInfo.Amount;

                        editRow.EndEdit();

                        break;
                    }

                    index++;
                }
                
            }

            _decTableByDate.AcceptChanges();

        } //--------------------------------

        //this procedure insert an employee deduction
        public void InsertEmployeeDeduction(CommonExchange.SysAccess userInfo, CommonExchange.DeductionInformation decInfo, CheckedListBox cbxBase)
        {
            if (cbxBase.CheckedItems.Count != 0)
            {
                DataTable decTable = new DataTable("EmployeeDeductionsApplied");
                decTable.Columns.Add("deduction_date", System.Type.GetType("System.String"));
                decTable.Columns.Add("sysid_deduction", System.Type.GetType("System.String"));
                decTable.Columns.Add("sysid_employee", System.Type.GetType("System.String"));
                decTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));

                IEnumerator myEnum = cbxBase.CheckedIndices.GetEnumerator();
                Int32 i;

                while (myEnum.MoveNext() != false)
                {
                    i = (Int32)myEnum.Current;

                    DataRow empRow = _empTableBySearch.Rows[i];
                    DataRow newRow = decTable.NewRow();

                    newRow["deduction_date"] = decInfo.DeductionDate;
                    newRow["sysid_deduction"] = decInfo.DeductionSysId;
                    newRow["sysid_employee"] = empRow["sysid_employee"].ToString();
                    newRow["amount"] = decInfo.Amount;

                    decTable.Rows.Add(newRow);                    
                }

                using (RemoteClient.RemCntDeductionManager remClient = new RemoteClient.RemCntDeductionManager())
                {
                    remClient.InsertEmployeeDeduction(userInfo, decTable);
                }
            }
        } //-----------------------------

        //this procedure insert a deduction information
        public void InsertDeductionInformation(CommonExchange.SysAccess userInfo, CommonExchange.DeductionInformation deductionInfo)
        {
            using (RemoteClient.RemCntDeductionManager remClient = new RemoteClient.RemCntDeductionManager())
            {
                remClient.InsertDeductionInformation(userInfo, ref deductionInfo);
            }

            DataRow newRow = _classDataSet.Tables["DeductionInformationTable"].NewRow();

            newRow["sysid_deduction"] = deductionInfo.DeductionSysId;
            newRow["deduction_description"] = deductionInfo.Description;

            _classDataSet.Tables["DeductionInformationTable"].Rows.Add(newRow);
            _classDataSet.Tables["DeductionInformationTable"].AcceptChanges();

        } //-------------------------------------

        //this procedure updates a deduction information
        public void UpdateDeductionInformation(CommonExchange.SysAccess userInfo, CommonExchange.DeductionInformation decInfo)
        {
            using (RemoteClient.RemCntDeductionManager remClient = new RemoteClient.RemCntDeductionManager())
            {
                remClient.UpdateDeductionInformation(userInfo, decInfo);
            }

            Int32 index = 0;

            foreach (DataRow decRow in _classDataSet.Tables["DeductionInformationTable"].Rows)
            {
                if (String.Equals(decInfo.DeductionSysId, decRow["sysid_deduction"].ToString()))
                {
                    DataRow editRow = _classDataSet.Tables["DeductionInformationTable"].Rows[index];

                    editRow.BeginEdit();

                    editRow["deduction_description"] = decInfo.Description;

                    editRow.EndEdit();

                    break;
                }

                index++;
            }

            _classDataSet.Tables["DeductionInformationTable"].AcceptChanges();

        } //-------------------------------------   

        //this function gets the selected employee deduction
        public void SetSelectedEmployeeDeductionByDate(CommonExchange.SysAccess userInfo, String employeeSysId, String dateFrom,
                   String dateTo)
        {
            using (RemoteClient.RemCntDeductionManager remClient = new RemoteClient.RemCntDeductionManager())
            {
                _decTableByDate = remClient.GetByDateFromDateToEmployeeDeduction(userInfo, employeeSysId, dateFrom, dateTo, _serverDateTime);
            }

            _decTableBySearch = _decTableByDate;
        } //-----------------------------------
        

        //this procedure refreshes the data
        public void RefreshDeductionData(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);

        } //-----------------------------

        //this procedure initializes the class
        private void InitializeClass(CommonExchange.SysAccess userInfo)
        {
            //gets the server date and time
            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                _serverDateTime = remClient.GetServerDateTime(userInfo); 
                
            } //----------------------

            //get the dataset for employee information
            using (RemoteClient.RemCntDeductionManager remClient = new RemoteClient.RemCntDeductionManager())
            {
                _classDataSet = remClient.GetDataSetForDeductionInfo(userInfo);
            } //---------------------------------

        } //--------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function gets the searched employee deduction
        public DataTable GetSearchedEmployeeDeductionByDescription(String strSearch)
        {
            using (DataTable newTable = new DataTable("EmployeeDeductionByDescriptionTable"))
            {
                newTable.Columns.Add("deduction_id", System.Type.GetType("System.Int64"));
                newTable.Columns.Add("deduction_date", System.Type.GetType("System.String"));
                newTable.Columns.Add("deduction_description", System.Type.GetType("System.String"));
                newTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));

                String strFilter = "deduction_description LIKE '%" + strSearch.Replace("*", "").Replace("%", "").Replace("'", "''") +"%'";
                DataRow[] selectRow = _decTableByDate.Select(strFilter, "deduction_date DESC");

                foreach (DataRow decRow in selectRow)
                {
                    if (decRow.RowState != DataRowState.Deleted)
                    {
                        DataRow newRow = newTable.NewRow();

                        newRow["deduction_id"] = decRow["deduction_id"];
                        newRow["deduction_date"] = decRow["deduction_date"];
                        newRow["deduction_description"] = decRow["deduction_description"];
                        newRow["amount"] = decRow["amount"];

                        newTable.Rows.Add(newRow);
                    }
                    
                }

                newTable.AcceptChanges();

                _decTableBySearch = newTable;
            }

            return _decTableBySearch;

        } //-----------------------------        

        //this procedure gets the selected employee information for deduction
        public DataTable GetSelectedEmployeeForDeduction(ClientExchange.EmployeeSearchFilter searchFilter)
        {
            if (!searchFilter.IncludePartTime && !searchFilter.IncludeProbationary && !searchFilter.IncludeRegular)
            {
                searchFilter.IncludePartTime = true;
                searchFilter.IncludeProbationary = true;
                searchFilter.IncludeRegular = true;
            }

            DataTable employeeTable = RemoteClient.ProcStatic.GetEmployeeInformationFilterStatusAndType(searchFilter,
                                                _classDataSet.Tables["EmployeeInformationTable"]);

            using (DataTable newTable = new DataTable("EmployeeSearchByEmployeeNameIdCardNumberTable"))
            {
                newTable.Columns.Add("sysid_employee", System.Type.GetType("System.String"));
                newTable.Columns.Add("employee_id", System.Type.GetType("System.String"));
                newTable.Columns.Add("employee_name", System.Type.GetType("System.String"));

                searchFilter.StringSearch = searchFilter.StringSearch.Replace("*", "").Replace("%", "").Replace("'", "''");

                String strFilter = "(employee_id LIKE '%" + searchFilter.StringSearch + "%' OR " +
                            "employee_name LIKE '%" + searchFilter.StringSearch + "%')";

                DataRow[] selectRow = employeeTable.Select(strFilter.Trim("*".ToCharArray()), "employee_name ASC");

                foreach (DataRow empRow in selectRow)
                {
                    DataRow newRow = newTable.NewRow();

                    newRow["sysid_employee"] = empRow["sysid_employee"].ToString();
                    newRow["employee_id"] = empRow["employee_id"].ToString();
                    newRow["employee_name"] = empRow["employee_name"].ToString();

                    newTable.Rows.Add(newRow);
                }

                newTable.AcceptChanges();

                _empTableBySearch = newTable;
            }
            
            return _empTableBySearch;

        } //---------------------------
        
        //this function gets the selected employee
        public DataTable GetSelectedEmployeeInformation(ClientExchange.EmployeeSearchFilter searchFilter)
        {
            DataTable employeeTable = RemoteClient.ProcStatic.GetEmployeeInformationFilterStatusAndType(searchFilter,
                                                _classDataSet.Tables["EmployeeInformationTable"]);

            DataTable newTable = new DataTable("EmployeeSearchByEmployeeNameIdCardNumberTable");
            newTable.Columns.Add("employee_id", System.Type.GetType("System.String"));            
            newTable.Columns.Add("employee_name", System.Type.GetType("System.String"));

            searchFilter.StringSearch = searchFilter.StringSearch.Replace("*", "").Replace("%", "").Replace("'", "''");

            String strFilter = "(employee_id LIKE '%" + searchFilter.StringSearch + "%' OR " +
                        "employee_name LIKE '%" + searchFilter.StringSearch + "%')";

            DataRow[] selectRow = employeeTable.Select(strFilter.Trim("*".ToCharArray()), "employee_name ASC");

            foreach (DataRow empRow in selectRow)
            {
                DataRow newRow = newTable.NewRow();

                newRow["employee_id"] = empRow["employee_id"].ToString();                
                newRow["employee_name"] = empRow["employee_name"].ToString();

                newTable.Rows.Add(newRow);
            }

            newTable.AcceptChanges();

            return newTable;

        } //-------------------------------

        //this function returns the searched deduction information
        public DataTable GetSearchedDeductionInformation(String strSearch)
        {
            DataTable newTable = new DataTable("DeductionInformationSearchTable");
            newTable.Columns.Add("sysid_deduction", System.Type.GetType("System.String"));
            newTable.Columns.Add("deduction_description", System.Type.GetType("System.String"));

            strSearch = strSearch.Replace("*", "").Replace("%", "").Replace("'", "''");

            String strFilter = "deduction_description LIKE '%" + strSearch + "%'";
            DataRow[] selectRow = _classDataSet.Tables["DeductionInformationTable"].Select(strFilter, "sysid_deduction ASC");

            foreach (DataRow decRow in selectRow)
            {
                DataRow newRow = newTable.NewRow();

                newRow["sysid_deduction"] = decRow["sysid_deduction"].ToString();
                newRow["deduction_description"] = decRow["deduction_description"].ToString();

                newTable.Rows.Add(newRow);
            }

            newTable.AcceptChanges();            

            return newTable;
        } //--------------------------------
        

        //this function is used to determine if the card number exists
        public Boolean IsDeductionDescriptionExist(CommonExchange.SysAccess userInfo, String description, String deductionSysId)
        {
            Boolean isExist = false;

            using (RemoteClient.RemCntDeductionManager remClient = new RemoteClient.RemCntDeductionManager())
            {
                isExist = remClient.IsDeductionDescriptionExist(userInfo, description, deductionSysId);
            } 

            return isExist;
        } //-------------------------------------

        //this function returns a deduction information
        public CommonExchange.DeductionInformation GetDetailsDeductionInformation(String deductionId)
        {
            CommonExchange.DeductionInformation deductionInfo = new CommonExchange.DeductionInformation();

            String strFilter = "sysid_deduction = '" + deductionId + "'";
            DataRow[] selectRow = _classDataSet.Tables["DeductionInformationTable"].Select(strFilter, "sysid_deduction ASC");

            foreach (DataRow decRow in selectRow)
            {
                deductionInfo.DeductionSysId = decRow["sysid_deduction"].ToString();
                deductionInfo.Description = decRow["deduction_description"].ToString();
            }

            return deductionInfo;
        } //------------------------------

        //this function returns a deduction information
        public CommonExchange.DeductionInformation GetDetailsDeductionInformation(Int64 deductionId)
        {
            CommonExchange.DeductionInformation decInfo = new CommonExchange.DeductionInformation();

            String strFilter = "deduction_id = '" + deductionId + "'";
            DataRow[] selectRow = _decTableByDate.Select(strFilter, "deduction_id ASC");

            foreach (DataRow decRow in selectRow)
            {
                decInfo.DeductionId = (Int64)decRow["deduction_id"];
                decInfo.DeductionDate = decRow["deduction_date"].ToString();
                decInfo.Description = decRow["deduction_description"].ToString();
                decInfo.Amount = (Decimal)decRow["amount"];
            }

            return decInfo;
        } //------------------------------

        //this function gets the employee information
        public CommonExchange.Employee GetDetailsEmployeeInformation(String empId)
        {
            CommonExchange.Employee empInfo = new CommonExchange.Employee();

            String strFilter = "employee_id = '" + empId + "'";
            DataRow[] selectRow = _classDataSet.Tables["EmployeeInformationTable"].Select(strFilter, "sysid_employee ASC");

            foreach (DataRow empRow in selectRow)
            {
                empInfo.EmployeeSysId = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "sysid_employee", "");
                empInfo.EmployeeId = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "employee_id", "");
                empInfo.CardNumber = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "card_number", "");
                empInfo.PersonInfo.LastName = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "last_name", "");
                empInfo.PersonInfo.FirstName = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "first_name", "");
                empInfo.PersonInfo.MiddleName = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "middle_name", "");
                empInfo.SalaryInfo.EmploymentTypeInfo.TypeNo = (CommonExchange.EmploymentTypeNo)RemoteServerLib.ProcStatic.DataRowConvert(empRow, 
                    "type_no", Byte.Parse("0"));
                empInfo.SalaryInfo.EmployeeStatusInfo.StatusId = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "status_id", Byte.Parse("0"));
            }

            return empInfo;
        } //-----------------------
        #endregion
    }
}
