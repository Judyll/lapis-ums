using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

namespace EmployeeServices
{
    internal class EarningLogic
    {
        #region Class General Variable Declarations
        private DataSet _classDataSet;
        private DataTable _empTableBySearch;
        private DataTable _incTableByDate;
        private DataTable _incTableBySearch;
        #endregion

        #region Class Properties Declarations
        private String _serverDateTime;
        public String ServerDateTime
        {
            get { return _serverDateTime; }
        }

        public Int32 RowCount
        {
            get { return _incTableBySearch.Rows.Count; }
        }

        #endregion

        #region Class Constructor
        public EarningLogic(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);
        }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure prints the employee earning list
        public void PrintEmployeeEarningList(CommonExchange.SysAccess userInfo, CommonExchange.Employee empInfo, DateTime dateFrom,
            DateTime dateTo)
        {
            DataTable reportTable = new DataTable("EarningDeduction");
            reportTable.Columns.Add("id", System.Type.GetType("System.Int64"));
            reportTable.Columns.Add("date_string", System.Type.GetType("System.String"));
            reportTable.Columns.Add("description", System.Type.GetType("System.String"));
            reportTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));

            foreach (DataRow incRow in _incTableBySearch.Rows)
            {
                DataRow newRow = reportTable.NewRow();

                newRow["id"] = incRow["earning_id"];
                newRow["date_string"] = DateTime.Parse(incRow["earning_date"].ToString()).ToShortDateString() + " " +
                                            DateTime.Parse(incRow["earning_date"].ToString()).ToShortTimeString();
                newRow["description"] = incRow["earning_description"];
                newRow["amount"] = incRow["amount"];

                reportTable.Rows.Add(newRow);
            }

            reportTable.AcceptChanges();

            using (ClassEarningDeductionManager.CrystalReport.CrystalEmployeeEarningDeductionList rptEarning =
                new EmployeeServices.ClassEarningDeductionManager.CrystalReport.CrystalEmployeeEarningDeductionList())
            {
                rptEarning.Database.Tables["earning_deduction"].SetDataSource(reportTable);
                
                rptEarning.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                rptEarning.SetParameterValue("@address", CommonExchange.SchoolInformation.Address);
                rptEarning.SetParameterValue("@phone_nos", CommonExchange.SchoolInformation.PhoneNos);
                rptEarning.SetParameterValue("@report_name", "Employee Earning Summary");
                rptEarning.SetParameterValue("@date_covered", "as of " + dateFrom.ToLongDateString() + " to " + dateTo.ToLongDateString());
                rptEarning.SetParameterValue("@employee_id", empInfo.EmployeeId);
                rptEarning.SetParameterValue("@employee_name", RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(empInfo.PersonInfo.LastName, 
                    empInfo.PersonInfo.FirstName, empInfo.PersonInfo.MiddleName));
                rptEarning.SetParameterValue("@printer_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
                                    DateTime.Parse(_serverDateTime).ToShortTimeString() + "      Printed by: " +
                                    userInfo.PersonInfo.LastName + ", " + userInfo.PersonInfo.FirstName + " " +
                                    (String.IsNullOrEmpty(userInfo.PersonInfo.MiddleName) ? "" : userInfo.PersonInfo.MiddleName.Substring(0, 1).ToUpper() + "."));
                rptEarning.SetParameterValue("@total", "Total earnings-to-date:");

                using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptEarning))
                {
                    frmViewer.ShowDialog();
                }
            }
        } //-----------------------------------------

        //this procedure deletes an employee earning
        public void DeleteEmployeeEarning(CommonExchange.SysAccess userInfo, CommonExchange.EarningInformation incInfo)
        {
            using (RemoteClient.RemCntEarningManager remClient = new RemoteClient.RemCntEarningManager())
            {
                remClient.DeleteEmployeeEarning(userInfo, incInfo);
            }

            Int32 index = 0;

            foreach (DataRow incRow in _incTableByDate.Rows)
            {
                if (incRow.RowState != DataRowState.Deleted)
                {
                    if ((Int64)incRow["earning_id"] == incInfo.EarningId)
                    {
                        DataRow delRow = _incTableByDate.Rows[index];

                        delRow.Delete();

                        break;
                    }

                    index++;
                }
            }

            _incTableByDate.AcceptChanges();

        } //---------------------------------

        //this procedure updates an employee earning
        public void UpdateEmployeeEarning(CommonExchange.SysAccess userInfo, CommonExchange.EarningInformation incInfo)
        {
            using (RemoteClient.RemCntEarningManager remClient = new RemoteClient.RemCntEarningManager())
            {
                remClient.UpdateEmployeeEarning(userInfo, incInfo);
            }

            Int32 index = 0;

            foreach (DataRow incRow in _incTableByDate.Rows)
            {
                if (incRow.RowState != DataRowState.Deleted)
                {
                    if ((Int64)incRow["earning_id"] == incInfo.EarningId)
                    {
                        DataRow editRow = _incTableByDate.Rows[index];

                        editRow.BeginEdit();

                        editRow["earning_date"] = DateTime.Parse(incInfo.EarningDate).ToString();
                        editRow["amount"] = incInfo.Amount;

                        editRow.EndEdit();

                        break;
                    }

                    index++;
                }

            }

            _incTableByDate.AcceptChanges();

        } //--------------------------------

        //this procedure insert an employee earning
        public void InsertEmployeeEarning(CommonExchange.SysAccess userInfo, CommonExchange.EarningInformation incInfo, CheckedListBox cbxBase)
        {
            if (cbxBase.CheckedItems.Count != 0)
            {
                DataTable incTable = new DataTable("EmployeeEarningsApplied");
                incTable.Columns.Add("earning_date", System.Type.GetType("System.String"));
                incTable.Columns.Add("sysid_earning", System.Type.GetType("System.String"));
                incTable.Columns.Add("sysid_employee", System.Type.GetType("System.String"));
                incTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));

                IEnumerator myEnum = cbxBase.CheckedIndices.GetEnumerator();
                Int32 i;

                while (myEnum.MoveNext() != false)
                {
                    i = (Int32)myEnum.Current;

                    DataRow empRow = _empTableBySearch.Rows[i];
                    DataRow newRow = incTable.NewRow();

                    newRow["earning_date"] = incInfo.EarningDate;
                    newRow["sysid_earning"] = incInfo.EarningSysId;
                    newRow["sysid_employee"] = empRow["sysid_employee"].ToString();
                    newRow["amount"] = incInfo.Amount;

                    incTable.Rows.Add(newRow);
                }

                using (RemoteClient.RemCntEarningManager remClient = new RemoteClient.RemCntEarningManager())
                {
                    remClient.InsertEmployeeEarning(userInfo, incTable);
                }
            }
        } //-----------------------------

        //this procedure insert a earning information
        public void InsertEarningInformation(CommonExchange.SysAccess userInfo, CommonExchange.EarningInformation incInfo)
        {
            using (RemoteClient.RemCntEarningManager remClient = new RemoteClient.RemCntEarningManager())
            {
                remClient.InsertEarningInformation(userInfo, ref incInfo);
            }

            DataRow newRow = _classDataSet.Tables["EarningInformationTable"].NewRow();

            newRow["sysid_earning"] = incInfo.EarningSysId;
            newRow["earning_description"] = incInfo.Description;

            _classDataSet.Tables["EarningInformationTable"].Rows.Add(newRow);
            _classDataSet.Tables["EarningInformationTable"].AcceptChanges();

        } //-------------------------------------

        //this procedure updates a earning information
        public void UpdateEarningInformation(CommonExchange.SysAccess userInfo, CommonExchange.EarningInformation incInfo)
        {
            using (RemoteClient.RemCntEarningManager remClient = new RemoteClient.RemCntEarningManager())
            {
                remClient.UpdateEarningInformation(userInfo, incInfo);
            }

            Int32 index = 0;

            foreach (DataRow incRow in _classDataSet.Tables["EarningInformationTable"].Rows)
            {
                if (String.Equals(incInfo.EarningSysId, incRow["sysid_earning"].ToString()))
                {
                    DataRow editRow = _classDataSet.Tables["EarningInformationTable"].Rows[index];

                    editRow.BeginEdit();

                    editRow["earning_description"] = incInfo.Description;

                    editRow.EndEdit();

                    break;
                }

                index++;
            }

            _classDataSet.Tables["EarningInformationTable"].AcceptChanges();

        } //-------------------------------------   

        //this function gets the selected employee earning
        public void SetSelectedEmployeeEarningByDate(CommonExchange.SysAccess userInfo, String employeeSysId, String dateFrom,
                   String dateTo)
        {
            using (RemoteClient.RemCntEarningManager remClient = new RemoteClient.RemCntEarningManager())
            {
                _incTableByDate = remClient.GetByDateFromDateToEmployeeEarning(userInfo, employeeSysId, dateFrom, dateTo, _serverDateTime);
            }

            _incTableBySearch = _incTableByDate;
        } //-----------------------------------

        //this procedure refreshes the data
        public void RefreshEarningData(CommonExchange.SysAccess userInfo)
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
            using (RemoteClient.RemCntEarningManager remClient = new RemoteClient.RemCntEarningManager())
            {
                _classDataSet = remClient.GetDataSetForEarningInfo(userInfo);
            } //---------------------------------

        } //--------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function gets the searched employee earning
        public DataTable GetSearchedEmployeeEarningByDescription(String strSearch)
        {
            using (DataTable newTable = new DataTable("EmployeeEarningByDescriptionTable"))
            {
                newTable.Columns.Add("earning_id", System.Type.GetType("System.Int64"));
                newTable.Columns.Add("earning_date", System.Type.GetType("System.String"));
                newTable.Columns.Add("earning_description", System.Type.GetType("System.String"));
                newTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));

                String strFilter = "earning_description LIKE '%" + strSearch.Replace("*", "").Replace("%", "").Replace("'", "''") +"%'";
                DataRow[] selectRow = _incTableByDate.Select(strFilter, "earning_date DESC");

                foreach (DataRow incRow in selectRow)
                {
                    if (incRow.RowState != DataRowState.Deleted)
                    {
                        DataRow newRow = newTable.NewRow();

                        newRow["earning_id"] = incRow["earning_id"];
                        newRow["earning_date"] = incRow["earning_date"];
                        newRow["earning_description"] = incRow["earning_description"];
                        newRow["amount"] = incRow["amount"];

                        newTable.Rows.Add(newRow);
                    }

                }

                newTable.AcceptChanges();

                _incTableBySearch = newTable;
            }

            return _incTableBySearch;

        } //-----------------------------    

        //this procedure gets the selected employee information for earning
        public DataTable GetSelectedEmployeeForEarning(ClientExchange.EmployeeSearchFilter searchFilter)
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

        //this function returns the searched earning information
        public DataTable GetSearchedEarningInformation(String strSearch)
        {
            DataTable newTable = new DataTable("EarningInformationSearchTable");
            newTable.Columns.Add("sysid_earning", System.Type.GetType("System.String"));
            newTable.Columns.Add("earning_description", System.Type.GetType("System.String"));

            strSearch = strSearch.Replace("*", "").Replace("%", "").Replace("'", "''");

            String strFilter = "earning_description LIKE '%" + strSearch + "%'";
            DataRow[] selectRow = _classDataSet.Tables["EarningInformationTable"].Select(strFilter, "sysid_earning ASC");

            foreach (DataRow incRow in selectRow)
            {
                DataRow newRow = newTable.NewRow();

                newRow["sysid_earning"] = incRow["sysid_earning"].ToString();
                newRow["earning_description"] = incRow["earning_description"].ToString();

                newTable.Rows.Add(newRow);
            }

            newTable.AcceptChanges();

            return newTable;
        } //--------------------------------

        //this function is used to determine if the card number exists
        public Boolean IsEarningDescriptionExist(CommonExchange.SysAccess userInfo, String description, String earningSysId)
        {
            Boolean isExist = false;

            using (RemoteClient.RemCntEarningManager remClient = new RemoteClient.RemCntEarningManager())
            {
                isExist = remClient.IsEarningDescriptionExist(userInfo, description, earningSysId);
            }

            return isExist;
        } //-------------------------------------

        //this function returns a earning information
        public CommonExchange.EarningInformation GetDetailsEarningInformation(String earningId)
        {
            CommonExchange.EarningInformation incInfo = new CommonExchange.EarningInformation();

            String strFilter = "sysid_earning = '" + earningId + "'";
            DataRow[] selectRow = _classDataSet.Tables["EarningInformationTable"].Select(strFilter, "sysid_earning ASC");

            foreach (DataRow decRow in selectRow)
            {
                incInfo.EarningSysId = decRow["sysid_earning"].ToString();
                incInfo.Description = decRow["earning_description"].ToString();
            }

            return incInfo;
        } //------------------------------

        //this function returns a earning information
        public CommonExchange.EarningInformation GetDetailsEarningInformation(Int64 earningId)
        {
            CommonExchange.EarningInformation incInfo = new CommonExchange.EarningInformation();

            String strFilter = "earning_id = '" + earningId + "'";
            DataRow[] selectRow = _incTableByDate.Select(strFilter, "earning_id ASC");

            foreach (DataRow incRow in selectRow)
            {
                incInfo.EarningId = (Int64)incRow["earning_id"];
                incInfo.EarningDate = incRow["earning_date"].ToString();
                incInfo.Description = incRow["earning_description"].ToString();
                incInfo.Amount = (Decimal)incRow["amount"];
            }

            return incInfo;
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
