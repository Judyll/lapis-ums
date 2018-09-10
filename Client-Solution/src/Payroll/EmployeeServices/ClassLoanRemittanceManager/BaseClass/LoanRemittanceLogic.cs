using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace EmployeeServices
{
    internal class LoanRemittanceLogic : BaseServices.BaseServicesLogic
    {
        #region Class General Variable Declarations
        private DataSet _classDataSet;
        private DataTable _loanRemittance;
        private DataTable _employeeRemittance;
        #endregion

        #region Class Properties Declarations
        //private String _serverDateTime;
        //public String ServerDateTime
        //{
        //    get { return _serverDateTime; }
        //}
        #endregion

        #region Class Constructor
        public LoanRemittanceLogic(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);
        }
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure prints the employee remittance
        public void PrintEmployeeRemittance(CommonExchange.SysAccess userInfo, CommonExchange.LoanInformation loanInfo, CommonExchange.Employee empInfo)
        {
            DataTable reportTable = new DataTable("LoanRemittanceReportTable");
            reportTable.Columns.Add("remittance_id", System.Type.GetType("System.Int64"));
            reportTable.Columns.Add("remittance_date", System.Type.GetType("System.String"));
            reportTable.Columns.Add("pay_month", System.Type.GetType("System.Int16"));
            reportTable.Columns.Add("pay_balance", System.Type.GetType("System.Int16"));
            reportTable.Columns.Add("amount_paid", System.Type.GetType("System.Decimal"));
            reportTable.Columns.Add("amount_balance", System.Type.GetType("System.Decimal"));

            foreach (DataRow remRow in _employeeRemittance.Rows)
            {
                if (String.Equals(remRow["sysid_remittance"].ToString(), loanInfo.RemittanceSysId))
                {
                    DataRow newRow = reportTable.NewRow();

                    newRow["remittance_id"] = remRow["remittance_id"];
                    newRow["remittance_date"] = RemoteServerLib.ProcStatic.DataRowConvert(remRow, "remittance_date", DateTime.Parse(_serverDateTime)).ToShortDateString() + " " +
                                        RemoteServerLib.ProcStatic.DataRowConvert(remRow, "remittance_date", DateTime.Parse(_serverDateTime)).ToShortTimeString();
                    newRow["pay_month"] = remRow["pay_month"];
                    newRow["pay_balance"] = remRow["pay_balance"];
                    newRow["amount_paid"] = remRow["amount_paid"];
                    newRow["amount_balance"] = remRow["amount_balance"];

                    reportTable.Rows.Add(newRow);
                }
                
            }

            reportTable.AcceptChanges();

            using (ClassLoanRemittanceManager.CrystalReport.CrystalLoanRemittance rptLoan = 
                new EmployeeServices.ClassLoanRemittanceManager.CrystalReport.CrystalLoanRemittance())
            {   
                rptLoan.Database.Tables["employee_remittance"].SetDataSource(reportTable);

                rptLoan.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                rptLoan.SetParameterValue("@address", CommonExchange.SchoolInformation.Address);
                rptLoan.SetParameterValue("@phone_nos", CommonExchange.SchoolInformation.PhoneNos);
                rptLoan.SetParameterValue("@report_name", "Loan Remittance Summary");
                rptLoan.SetParameterValue("@employee_id", empInfo.EmployeeId);
                rptLoan.SetParameterValue("@employee_name", empInfo.PersonInfo.LastName.ToUpper() + ", " + empInfo.PersonInfo.FirstName + " " + 
                    empInfo.PersonInfo.MiddleName);
                rptLoan.SetParameterValue("@printer_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
                                    DateTime.Parse(_serverDateTime).ToShortTimeString() + "      Printed by: " + 
                                    userInfo.PersonInfo.LastName + ", " + userInfo.PersonInfo.FirstName + " " +
                                    (String.IsNullOrEmpty(userInfo.PersonInfo.MiddleName) ? "" : userInfo.PersonInfo.MiddleName.Substring(0, 1).ToUpper() + "."));
                rptLoan.SetParameterValue("@reference_no", loanInfo.ReferenceNo);
                rptLoan.SetParameterValue("@loan_description", loanInfo.Description);
                rptLoan.SetParameterValue("@release_date", DateTime.Parse(loanInfo.ReleaseDate).ToLongDateString());
                rptLoan.SetParameterValue("@maturity_date", DateTime.Parse(loanInfo.MaturityDate).ToLongDateString());
                rptLoan.SetParameterValue("@principal_interest", loanInfo.PrincipalInterest.ToString("N"));
                rptLoan.SetParameterValue("@total_paid", this.GetTotalPaidLoanRemittance(loanInfo.RemittanceSysId).ToString("N"));
                rptLoan.SetParameterValue("@amount_balance", this.GetAmountBalance(loanInfo, 0).ToString("N"));
                
                using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptLoan))
                {
                    frmViewer.ShowDialog();
                }
            }

        } //----------------------------

        //this procedure updates an employee remittance
        public void UpdateDeleteEmployeeRemittance(CommonExchange.SysAccess userInfo, CommonExchange.LoanInformation loanInfo,
                            CommonExchange.EmployeeLoanRemittance remInfo, Boolean forUpdate)
        {
            Int32 index = 0;
            Int16 payCounter = 1;
            Int32 monthTerm = this.GetTermsInMonth(DateTime.Parse(loanInfo.ReleaseDate), DateTime.Parse(loanInfo.MaturityDate));
            Decimal totalPaid = 0;

            foreach (DataRow remRow in _employeeRemittance.Rows)
            {
                if (String.Equals(remRow["sysid_remittance"].ToString(), loanInfo.RemittanceSysId))
                {
                    if (Int64.Parse(remRow["remittance_id"].ToString()) == remInfo.RemittanceId)
                    {
                        if (forUpdate)
                        {
                            DataRow editRow = _employeeRemittance.Rows[index];

                            editRow.AcceptChanges();

                            editRow.BeginEdit();

                            editRow["remittance_date"] = remInfo.RemittanceDate;
                            editRow["pay_month"] = remInfo.PayMonth;
                            editRow["pay_balance"] = remInfo.PayBalance;
                            editRow["amount_paid"] = remInfo.AmountPaid;
                            editRow["amount_balance"] = remInfo.AmountBalance;

                            editRow.EndEdit();
                        }
                        else
                        {
                            DataRow delRow = _employeeRemittance.Rows[index];

                            delRow.AcceptChanges();

                            delRow.Delete();
                        }
                        
                    }
                    else
                    {
                        CommonExchange.EmployeeLoanRemittance remTemp = new CommonExchange.EmployeeLoanRemittance();

                        remTemp.RemittanceDate = remRow["remittance_date"].ToString();
                        remTemp.PayMonth = Int16.Parse(remRow["pay_month"].ToString());
                        remTemp.PayBalance = Int16.Parse(remRow["pay_balance"].ToString());
                        remTemp.AmountPaid = Decimal.Parse(remRow["amount_paid"].ToString());
                        remTemp.AmountBalance = Decimal.Parse(remRow["amount_balance"].ToString());

                        if ((remTemp.PayMonth != payCounter) || (remTemp.PayBalance != (monthTerm - payCounter)) ||
                            ((remTemp.AmountBalance != (loanInfo.PrincipalInterest - (totalPaid + remTemp.AmountPaid))) &&
                            ((loanInfo.PrincipalInterest - (totalPaid + remTemp.AmountPaid)) >= 0)))
                        {
                            DataRow editRow = _employeeRemittance.Rows[index];

                            editRow.AcceptChanges();

                            editRow.BeginEdit();

                            editRow["pay_month"] = payCounter;
                            editRow["pay_balance"] = (monthTerm - payCounter);
                            editRow["amount_balance"] = (loanInfo.PrincipalInterest - (totalPaid + remTemp.AmountPaid));

                            editRow.EndEdit();
                        }
                        else if ((loanInfo.PrincipalInterest - (totalPaid + remTemp.AmountPaid)) < 0)
                        {
                            DataRow delRow = _employeeRemittance.Rows[index];

                            delRow.AcceptChanges();

                            delRow.Delete();
                        }
                        
                    }
                    
                    if (remRow.RowState != DataRowState.Deleted)
                    {
                        totalPaid += Decimal.Parse(remRow["amount_paid"].ToString());

                        payCounter++;
                    }                    
                }
                
                index++;
            }

            this.UpdateDeleteEmployeeRemittance(userInfo);
        } //----------------------------------        

        //this procedure inserts a new employee remittance
        public void InsertEmployeeRemittance(CommonExchange.SysAccess userInfo, CommonExchange.EmployeeLoanRemittance remInfo,
                                                    CommonExchange.LoanInformation loanInfo, String empSysId)
        {
            using (RemoteClient.RemCntLoanManager remClient = new RemoteClient.RemCntLoanManager())
            {
                Int16 payMonth = 0;
                Int16 payBalance = 0;

                this.GetPayMonthAndBalance(ref payMonth, ref payBalance, loanInfo);

                remInfo.PayMonth = payMonth;
                remInfo.PayBalance = payBalance;

                remClient.InsertEmployeeRemittance(userInfo, remInfo);

                _employeeRemittance = remClient.SelectByEmployeeIDEmployeeRemittance(userInfo, empSysId);

                this.UpdateDeleteEmployeeRemittance(userInfo, loanInfo, remInfo, false);
            }

        } //----------------------------

        //this procedure deletes a loan remittance information
        public void DeleteLoanRemittance(CommonExchange.SysAccess userInfo, String loanSysId)
        {
            using (RemoteClient.RemCntLoanManager remClient = new RemoteClient.RemCntLoanManager())
            {
                remClient.DeleteLoanRemittance(userInfo, loanSysId);
            }

            Int32 index = 0;

            foreach (DataRow loanRow in _loanRemittance.Rows)
            {
                if (String.Equals(loanSysId, loanRow["sysid_remittance"].ToString()))
                {
                    DataRow delRow = _loanRemittance.Rows[index];

                    delRow.Delete();

                    break;
                }

                index++;
            }

            index = 0;

            foreach (DataRow remRow in _employeeRemittance.Rows)
            {
                if (String.Equals(loanSysId, remRow["sysid_remittance"].ToString()))
                {
                    DataRow delRow = _employeeRemittance.Rows[index];

                    delRow.Delete();
                }

                index++;
            }

            _loanRemittance.AcceptChanges();
            _employeeRemittance.AcceptChanges();

        } //-----------------------------

        //this procedure updates a loan remittance information
        public void UpdateLoanRemittance(CommonExchange.SysAccess userInfo, CommonExchange.LoanInformation loanInfo)
        {
            using (RemoteClient.RemCntLoanManager remClient = new RemoteClient.RemCntLoanManager())
            {
                remClient.UpdateLoanRemittance(userInfo, loanInfo);
            }

            Int32 index = 0;

            foreach (DataRow loanRow in _loanRemittance.Rows)
            {
                if (String.Equals(loanInfo.RemittanceSysId, loanRow["sysid_remittance"].ToString()))
                {
                    DataRow editRow = _loanRemittance.Rows[index];

                    editRow.BeginEdit();

                    editRow["sysid_loan"] = loanInfo.LoanSysId;
                    editRow["reference_no"] = loanInfo.ReferenceNo;
                    editRow["loan_description"] = loanInfo.Description;
                    editRow["release_date"] = loanInfo.ReleaseDate;
                    editRow["maturity_date"] = loanInfo.MaturityDate;
                    editRow["principal_interest"] = loanInfo.PrincipalInterest;
                    editRow["monthly_pay"] = loanInfo.MonthlyAmmortization;

                    editRow.EndEdit();

                    break;
                }

                index++;
            }

            _loanRemittance.AcceptChanges();

            index = 0;
            Int16 payCounter = 1;
            Int32 monthTerm = this.GetTermsInMonth(DateTime.Parse(loanInfo.ReleaseDate), DateTime.Parse(loanInfo.MaturityDate));
            Decimal totalPaid = 0;

            foreach (DataRow remRow in _employeeRemittance.Rows)
            {
                if (String.Equals(remRow["sysid_remittance"].ToString(), loanInfo.RemittanceSysId))
                {
                    CommonExchange.EmployeeLoanRemittance remTemp = new CommonExchange.EmployeeLoanRemittance();

                    remTemp.RemittanceDate = remRow["remittance_date"].ToString();
                    remTemp.PayMonth = Int16.Parse(remRow["pay_month"].ToString());
                    remTemp.PayBalance = Int16.Parse(remRow["pay_balance"].ToString());
                    remTemp.AmountPaid = Decimal.Parse(remRow["amount_paid"].ToString());
                    remTemp.AmountBalance = Decimal.Parse(remRow["amount_balance"].ToString());

                    if ((remTemp.PayMonth != payCounter) || (remTemp.PayBalance != (monthTerm - payCounter)) ||
                        ((remTemp.AmountBalance != (loanInfo.PrincipalInterest - (totalPaid + remTemp.AmountPaid))) &&
                        ((loanInfo.PrincipalInterest - (totalPaid + remTemp.AmountPaid)) >= 0)))
                    {
                        DataRow editRow = _employeeRemittance.Rows[index];

                        editRow.AcceptChanges();

                        editRow.BeginEdit();

                        editRow["pay_month"] = payCounter;
                        editRow["pay_balance"] = (monthTerm - payCounter);
                        editRow["amount_balance"] = (loanInfo.PrincipalInterest - (totalPaid + remTemp.AmountPaid));

                        editRow.EndEdit();
                    }
                    else if ((loanInfo.PrincipalInterest - (totalPaid + remTemp.AmountPaid)) < 0)
                    {
                        DataRow delRow = _employeeRemittance.Rows[index];

                        delRow.AcceptChanges();

                        delRow.Delete();
                    }

                    if (remRow.RowState != DataRowState.Deleted)
                    {
                        totalPaid += Decimal.Parse(remRow["amount_paid"].ToString());

                        payCounter++;
                    }   

                }

                index++;
            }

            this.UpdateDeleteEmployeeRemittance(userInfo);
        } //-----------------------------------

        //this procedure inserts a loan remittance information
        public void InsertLoanRemittance(CommonExchange.SysAccess userInfo, CommonExchange.LoanInformation loanInfo)
        {
            using (RemoteClient.RemCntLoanManager remClient = new RemoteClient.RemCntLoanManager())
            {
                remClient.InsertLoanRemittance(userInfo, ref loanInfo);
            }

            DataRow newRow = _loanRemittance.NewRow();

            newRow["sysid_remittance"] = loanInfo.RemittanceSysId;
            newRow["sysid_loan"] = loanInfo.LoanSysId;
            newRow["reference_no"] = loanInfo.ReferenceNo;
            newRow["loan_description"] = loanInfo.Description;
            newRow["release_date"] = loanInfo.ReleaseDate;
            newRow["maturity_date"] = loanInfo.MaturityDate;
            newRow["principal_interest"] = loanInfo.PrincipalInterest;
            newRow["monthly_pay"] = loanInfo.MonthlyAmmortization;

            _loanRemittance.Rows.Add(newRow);
            _loanRemittance.AcceptChanges();            

        } //-----------------------------

        //this procedure updates a loan type information
        public void UpdateLoanTypeInformation(CommonExchange.SysAccess userInfo, CommonExchange.LoanInformation loanInfo)
        {
            using (RemoteClient.RemCntLoanManager remClient = new RemoteClient.RemCntLoanManager())
            {
                remClient.UpdateLoanTypeInformation(userInfo, loanInfo);
            }

            Int32 index = 0;

            foreach (DataRow loanRow in _classDataSet.Tables["LoanTypeInformationTable"].Rows)
            {
                if (String.Equals(loanInfo.LoanSysId, loanRow["sysid_loan"].ToString()))
                {
                    DataRow editRow = _classDataSet.Tables["LoanTypeInformationTable"].Rows[index];

                    editRow.BeginEdit();

                    editRow["loan_description"] = loanInfo.Description;

                    editRow.EndEdit();

                    break;
                }

                index++;
            }

            _classDataSet.Tables["LoanTypeInformationTable"].AcceptChanges();

        } //------------------------------------------

        //this procedure insert a new loan type information
        public void InsertLoanTypeInformation(CommonExchange.SysAccess userInfo, CommonExchange.LoanInformation loanInfo)
        {
            using (RemoteClient.RemCntLoanManager remClient = new RemoteClient.RemCntLoanManager())
            {
                remClient.InsertLoanTypeInformation(userInfo, ref loanInfo);
            }

            DataRow newRow = _classDataSet.Tables["LoanTypeInformationTable"].NewRow();

            newRow["sysid_loan"] = loanInfo.LoanSysId;
            newRow["loan_description"] = loanInfo.Description;

            _classDataSet.Tables["LoanTypeInformationTable"].Rows.Add(newRow);
            _classDataSet.Tables["LoanTypeInformationTable"].AcceptChanges();

        } //-------------------------------------

        //this procedure refreshes the data
        public void RefreshLoanRemittanceData(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);

        } //-----------------------------

        //this procedure initializes the data for remittance summary
        public void InitializeRemittanceSummaryData(CommonExchange.SysAccess userInfo, String empSysId)
        {
            //get the data for remittance summary
            using (RemoteClient.RemCntLoanManager remClient = new RemoteClient.RemCntLoanManager())
            {
                _loanRemittance = remClient.SelectByEmployeeIDLoanRemittance(userInfo, empSysId);
                _employeeRemittance = remClient.SelectByEmployeeIDEmployeeRemittance(userInfo, empSysId);
            } //------------------------------------
        }

        //this procedure initializes the loan type combo
        public void InitializeLoanTypeCombo(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            foreach (DataRow loanRow in _classDataSet.Tables["LoanTypeInformationTable"].Rows)
            {
                cboBase.Items.Add(loanRow["loan_description"].ToString());
            }

        } //-----------------------------

        //this procedure initializes the loan type combo
        public void InitializeLoanTypeCombo(ComboBox cboBase, String loanSysId)
        {
            cboBase.Items.Clear();

            Int32 index = 0;

            foreach (DataRow loanRow in _classDataSet.Tables["LoanTypeInformationTable"].Rows)
            {
                cboBase.Items.Add(loanRow["loan_description"].ToString());

                if (String.Equals(loanRow["sysid_loan"].ToString(), loanSysId))
                {
                    cboBase.SelectedIndex = index;
                }

                index++;
            }

        } //-------------------------------

        //this procedure updates the selected employee information
        public void UpdateSelectedEmployeeInformation(String empId)
        {
            Int16 outstandingLoans = 0;

            foreach (DataRow loanRow in _loanRemittance.Rows)
            {
                String loanSysId = loanRow["sysid_remittance"].ToString();
                Decimal principalInterest = RemoteServerLib.ProcStatic.DataRowConvert(loanRow, "principal_interest", Decimal.Parse("0"));
                Decimal totalPaid = 0;

                String strFilter = "sysid_remittance = '" + loanSysId + "'";
                DataRow[] selectRow = _employeeRemittance.Select(strFilter, "remittance_date ASC");

                foreach (DataRow remRow in selectRow)
                {
                    totalPaid += RemoteServerLib.ProcStatic.DataRowConvert(remRow, "amount_paid", Decimal.Parse("0"));
                }

                if (principalInterest > totalPaid)
                {
                    outstandingLoans++;
                }
            }
            
            Int32 index = 0;

            foreach (DataRow empRow in _classDataSet.Tables["EmployeeWithOutstandingLoansTable"].Rows)
            {
                if (String.Equals(empId, empRow["employee_id"].ToString()))
                {
                    DataRow editRow = _classDataSet.Tables["EmployeeWithOutstandingLoansTable"].Rows[index];

                    editRow.BeginEdit();

                    editRow["outstanding_loans"] = outstandingLoans;

                    editRow.EndEdit();

                    break;
                }

                index++;
            }            

            _classDataSet.Tables["EmployeeWithOutstandingLoansTable"].AcceptChanges();

        } //-------------------------------

        //this procedure updates / delete an employee remittance
        private void UpdateDeleteEmployeeRemittance(CommonExchange.SysAccess userInfo)
        {
            using (RemoteClient.RemCntLoanManager remClient = new RemoteClient.RemCntLoanManager())
            {
                remClient.UpdateDeleteEmployeeRemittance(userInfo, _employeeRemittance);
            }

            _employeeRemittance.AcceptChanges();

        } //---------------------------------

        //this procedure initializes the class
        private void InitializeClass(CommonExchange.SysAccess userInfo)
        {
            //gets the server date and time
            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                _serverDateTime = remClient.GetServerDateTime(userInfo);
            } //----------------------

            //get the dataset for employee information
            using (RemoteClient.RemCntLoanManager remClient = new RemoteClient.RemCntLoanManager())
            {
                _classDataSet = remClient.GetDataSetForLoanTypeInfo(userInfo);
            } //---------------------------------

        } //--------------------------

        //this procedure gets the pay month and the pay balance
        private void GetPayMonthAndBalance(ref Int16 payMonth, ref Int16 payBalance, CommonExchange.LoanInformation loanInfo)
        {
            String strFilter = "sysid_remittance = '" + loanInfo.RemittanceSysId + "'";
            DataRow[] selectRow = _employeeRemittance.Select(strFilter, "remittance_date ASC");

            payMonth = Int16.Parse((selectRow.Length + 1).ToString());
            payBalance = Int16.Parse((this.GetTermsInMonth(DateTime.Parse(loanInfo.ReleaseDate), DateTime.Parse(loanInfo.MaturityDate)) - payMonth).ToString());

        } //------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function determines if the amount paid is valid
        public Boolean IsValidAmountPaid(CommonExchange.LoanInformation loanInfo, Decimal amountPaid)
        {
            Boolean isValid = true;
            Decimal totalPaid = 0;

            String strFilter = "sysid_remittance = '" + loanInfo.RemittanceSysId + "'";
            DataRow[] selectRow = _employeeRemittance.Select(strFilter, "remittance_date ASC");

            foreach (DataRow remRow in selectRow)
            {
                totalPaid += RemoteServerLib.ProcStatic.DataRowConvert(remRow, "amount_paid", Decimal.Parse("0"));
            }

            if ((totalPaid + amountPaid) > loanInfo.PrincipalInterest)
            {
                isValid = false;
            }

            return isValid;

        } //-------------------------
        
        //this function determines if the remittance date is valid
        public Boolean IsValidEmployeeRemittanceDate(CommonExchange.LoanInformation loanInfo, DateTime remDate, Int64 remittanceId)
        {
            Boolean isValid = false;

            DateTime proposedDate = this.GetProposedEmployeeRemittanceDate(loanInfo);
            DateTime compareDate = DateTime.Parse(loanInfo.ReleaseDate);
            Int32 counter = 0;           
            
            DataTable dbTable = this.GetEmployeeRemittanceTable(loanInfo.RemittanceSysId);
            DateTime[] validDates = new DateTime[this.GetNoMonthsInterval(DateTime.Parse(loanInfo.ReleaseDate), proposedDate)];

            //creates a list for the valid dates excluding the existing dates
            do
            {
                Boolean isExist = false;
                DateTime tempDate;            

                compareDate = compareDate.AddMonths(1);

                foreach (DataRow remRow in dbTable.Rows)
                {
                    if (remittanceId != RemoteServerLib.ProcStatic.DataRowConvert(remRow, "remittance_id", Int64.Parse("0")))
                    {
                        tempDate = RemoteServerLib.ProcStatic.DataRowConvert(remRow, "remittance_date", DateTime.Parse(_serverDateTime));

                        if (tempDate.Month == compareDate.Month && tempDate.Year == compareDate.Year)
                        {
                            isExist = true;
                            break;
                        }
                    }
                    
                }

                if (!isExist)
                {
                    validDates[counter++] = compareDate;
                }

            } while (compareDate.Month != proposedDate.Month || compareDate.Year != proposedDate.Year);
            //--------------------------------

            foreach (DateTime lDates in validDates)
            {
                if (lDates.Month == remDate.Month && lDates.Year == remDate.Year)
                {
                    isValid = true;
                    break;
                }
            }

            return isValid;

        } //--------------------------

        //this function determines if the maturity date is valid
        public Boolean IsValidLoanMaturityDate(DateTime releaseDate, DateTime maturityDate)
        {
            if (DateTime.Compare(releaseDate.AddMonths(1), maturityDate) > 0)
            {
                return false;
            }

            return true;

        } //---------------------------

        //this function returns the amount balance
        public Decimal GetAmountBalance(CommonExchange.LoanInformation loanInfo, Int64 remittanceId)
        {
            Decimal totalPaid = 0;

            String strFilter = "sysid_remittance = '" + loanInfo.RemittanceSysId + "'";
            DataRow[] selectRow = _employeeRemittance.Select(strFilter, "pay_month ASC");

            foreach (DataRow remRow in selectRow)
            {
                if (RemoteServerLib.ProcStatic.DataRowConvert(remRow, "remittance_id", Int64.Parse("0")) == remittanceId)
                {
                    break;
                }

                totalPaid += RemoteServerLib.ProcStatic.DataRowConvert(remRow, "amount_paid", Decimal.Parse("0"));
            }

            return loanInfo.PrincipalInterest - totalPaid;

        } //-------------------------

        //this function determines the proposed maturity date
        public DateTime GetProposedMaturityDate(DateTime releaseDate)
        {
            return releaseDate.AddMonths(1);
        } //--------------------------

        //this function determines the proposed remittance date
        public DateTime GetProposedEmployeeRemittanceDate(CommonExchange.LoanInformation loanInfo)
        {
            String strFilter = "sysid_remittance = '" + loanInfo.RemittanceSysId + "'";
            DataRow[] selectRow = _employeeRemittance.Select(strFilter, "remittance_date ASC");

            if (selectRow.Length == 0)
            {
                return DateTime.Parse(loanInfo.ReleaseDate).AddMonths(1);
            }
            else
            {
                Int32 counter = 0;
                DateTime maxDate = DateTime.MinValue;
                DateTime remDate;

                foreach (DataRow remRow in selectRow)
                {
                    remDate = RemoteServerLib.ProcStatic.DataRowConvert(remRow, "remittance_date", DateTime.Parse(_serverDateTime));

                    if ((counter == 0) || (DateTime.Compare(remDate, maxDate) > 0))
                    {
                        maxDate = remDate;
                    }

                    counter++;
                }

                return maxDate.AddMonths(1);
            }
            

        } //----------------------

        //this function gets the loan type id
        public String GetLoanTypeId(Int32 index)
        {
            DataRow loanRow = _classDataSet.Tables["LoanTypeInformationTable"].Rows[index];
            
            return loanRow["sysid_loan"].ToString();
        } //----------------------------

        //this function gets the loan remittance table
        public DataTable GetLoanRemittanceTable()
        {
            DataTable tempTable = new DataTable("LoanRemittanceByEmployeeIDTempTable");
            tempTable.Columns.Add("sysid_remittance", System.Type.GetType("System.String"));
            tempTable.Columns.Add("sysid_loan", System.Type.GetType("System.String"));
            tempTable.Columns.Add("reference_no", System.Type.GetType("System.String"));
            tempTable.Columns.Add("loan_description", System.Type.GetType("System.String"));
            tempTable.Columns.Add("release_date", System.Type.GetType("System.DateTime"));
            tempTable.Columns.Add("maturity_date", System.Type.GetType("System.DateTime"));
            tempTable.Columns.Add("principal_interest", System.Type.GetType("System.Decimal"));
            tempTable.Columns.Add("monthly_pay", System.Type.GetType("System.Decimal"));

            foreach (DataRow loanRow in _loanRemittance.Rows)
            {
                DataRow newRow = tempTable.NewRow();

                newRow["sysid_remittance"] = loanRow["sysid_remittance"];
                newRow["sysid_loan"] = loanRow["sysid_loan"];
                newRow["reference_no"] = loanRow["reference_no"];
                newRow["loan_description"] = loanRow["loan_description"];
                newRow["release_date"] = RemoteServerLib.ProcStatic.DataRowConvert(loanRow, "release_date", DateTime.Parse(_serverDateTime));
                newRow["maturity_date"] = RemoteServerLib.ProcStatic.DataRowConvert(loanRow, "maturity_date", DateTime.Parse(_serverDateTime));
                newRow["principal_interest"] = loanRow["principal_interest"];
                newRow["monthly_pay"] = loanRow["monthly_pay"];

                tempTable.Rows.Add(newRow);
            }

            tempTable.AcceptChanges();

            DataTable dbTable = new DataTable("LoanRemittanceTable");
            dbTable.Columns.Add("sysid_remittance", System.Type.GetType("System.String"));
            dbTable.Columns.Add("reference_no", System.Type.GetType("System.String"));
            dbTable.Columns.Add("loan_description", System.Type.GetType("System.String"));
            dbTable.Columns.Add("loan_status", System.Type.GetType("System.String"));

            DataRow[] selectRow = tempTable.Select("", "maturity_date DESC");

            foreach (DataRow loanRow in selectRow)
            {
                DataRow newRow = dbTable.NewRow();

                newRow["sysid_remittance"] = loanRow["sysid_remittance"];
                newRow["reference_no"] = loanRow["reference_no"];
                newRow["loan_description"] = loanRow["loan_description"];
                newRow["loan_status"] = this.GetLoanStatusString(loanRow["sysid_remittance"].ToString());

                dbTable.Rows.Add(newRow);
            }

            dbTable.AcceptChanges();

            return dbTable;

        } //-------------------------------

        //this function gets the employee remittance table
        public DataTable GetEmployeeRemittanceTable(String loanSysId)
        {
            DataTable tempTable = new DataTable("EmployeeRemittanceByEmployeeIDTempTable");
            tempTable.Columns.Add("remittance_id", System.Type.GetType("System.Int64"));
            tempTable.Columns.Add("sysid_remittance", System.Type.GetType("System.String"));
            tempTable.Columns.Add("remittance_date", System.Type.GetType("System.DateTime"));
            tempTable.Columns.Add("pay_month", System.Type.GetType("System.Int16"));
            tempTable.Columns.Add("pay_balance", System.Type.GetType("System.Int16"));
            tempTable.Columns.Add("amount_paid", System.Type.GetType("System.Decimal"));
            tempTable.Columns.Add("amount_balance", System.Type.GetType("System.Decimal"));

            foreach (DataRow loanRow in _employeeRemittance.Rows)
            {
                DataRow newRow = tempTable.NewRow();

                newRow["remittance_id"] = loanRow["remittance_id"];
                newRow["sysid_remittance"] = loanRow["sysid_remittance"];
                newRow["remittance_date"] = RemoteServerLib.ProcStatic.DataRowConvert(loanRow, "remittance_date", DateTime.Parse(_serverDateTime));
                newRow["pay_month"] = loanRow["pay_month"];
                newRow["pay_balance"] = loanRow["pay_balance"];
                newRow["amount_paid"] = loanRow["amount_paid"];
                newRow["amount_balance"] = loanRow["amount_balance"];

                tempTable.Rows.Add(newRow);
            }

            tempTable.AcceptChanges();

            DataTable dbTable = new DataTable("EmployeeRemittanceByLoanSysIdTable");
            dbTable.Columns.Add("remittance_id", System.Type.GetType("System.Int64"));
            dbTable.Columns.Add("remittance_date", System.Type.GetType("System.String"));
            dbTable.Columns.Add("pay_month", System.Type.GetType("System.Int16"));
            dbTable.Columns.Add("amount_paid", System.Type.GetType("System.String"));
            dbTable.Columns.Add("amount_balance", System.Type.GetType("System.String"));

            String strFilter = "sysid_remittance = '" + loanSysId + "'";
            DataRow[] selectRow = tempTable.Select(strFilter, "remittance_date ASC");

            foreach (DataRow remRow in selectRow)
            {
                DataRow newRow = dbTable.NewRow();

                newRow["remittance_id"] = RemoteServerLib.ProcStatic.DataRowConvert(remRow, "remittance_id", Int64.Parse("0"));
                newRow["remittance_date"] = RemoteServerLib.ProcStatic.DataRowConvert(remRow, "remittance_date", 
                                                DateTime.Parse(_serverDateTime)).ToShortDateString();                
                newRow["pay_month"] = RemoteServerLib.ProcStatic.DataRowConvert(remRow, "pay_month", Int16.Parse("0"));
                newRow["amount_paid"] = RemoteServerLib.ProcStatic.DataRowConvert(remRow, "amount_paid", Decimal.Parse("0")).ToString("N");
                newRow["amount_balance"] = RemoteServerLib.ProcStatic.DataRowConvert(remRow, "amount_balance", Decimal.Parse("0")).ToString("N");

                dbTable.Rows.Add(newRow);
            }

            dbTable.AcceptChanges();

            return dbTable;

        } //-----------------------------

        //this function gets the employee information
        public CommonExchange.Employee GetEmployeeInformationDetails(String empId)
        {
            CommonExchange.Employee empInfo = new CommonExchange.Employee();

            String strFilter = "employee_id = '" + empId + "'";
            DataRow[] selectRow = _classDataSet.Tables["EmployeeWithOutstandingLoansTable"].Select(strFilter, "sysid_employee ASC");

            foreach (DataRow empRow in selectRow)
            {
                empInfo.EmployeeSysId = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "sysid_employee", "");
                empInfo.EmployeeId = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "employee_id", "");
                empInfo.CardNumber = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "card_number", "");
                empInfo.PersonInfo.LastName = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "last_name", "");
                empInfo.PersonInfo.FirstName = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "first_name", "");
                empInfo.PersonInfo.MiddleName = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "middle_name", "");
                empInfo.PersonInfo.PersonSysId = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "sysid_person", "");
                empInfo.SalaryInfo.EmployeeStatusInfo.StatusId = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "status_id", Byte.Parse("0"));
            }

            return empInfo;
        } //-----------------------        

        //this function gets the selected employee
        public DataTable GetSelectedEmployeeInformation(ClientExchange.EmployeeSearchFilter searchFilter)
        {
            DataTable employeeTable = new DataTable("EmployeeWithConcatenateNameTable");
            employeeTable.Columns.Add("employee_id", System.Type.GetType("System.String"));
            employeeTable.Columns.Add("employee_name", System.Type.GetType("System.String"));
            employeeTable.Columns.Add("outstanding_loans", System.Type.GetType("System.Int16"));

            foreach (DataRow empRow in _classDataSet.Tables["EmployeeWithOutstandingLoansTable"].Rows)
            {
                DataRow newRow = employeeTable.NewRow();

                newRow["employee_id"] = empRow["employee_id"];
                newRow["employee_name"] = empRow["last_name"].ToString().ToUpper() + ", " + empRow["first_name"].ToString() + " " + 
                    empRow["middle_name"].ToString();
                newRow["outstanding_loans"] = empRow["outstanding_loans"];

                employeeTable.Rows.Add(newRow);
            }

            employeeTable.AcceptChanges();

            DataTable newTable = new DataTable("EmployeeSearchByEmployeeNameIdTable");
            newTable.Columns.Add("employee_id", System.Type.GetType("System.String"));
            newTable.Columns.Add("employee_name", System.Type.GetType("System.String"));
            newTable.Columns.Add("outstanding_loans", System.Type.GetType("System.String"));

            searchFilter.StringSearch = searchFilter.StringSearch.Replace("*", "").Replace("%", "").Replace("'", "''");

            String strFilter = "(employee_id LIKE '%" + searchFilter.StringSearch + "%' OR " +
                        "employee_name LIKE '%" + searchFilter.StringSearch + "%')";

            DataRow[] selectRow = employeeTable.Select(strFilter.Trim("*".ToCharArray()), "employee_name ASC");

            foreach (DataRow empRow in selectRow)
            {
                DataRow newRow = newTable.NewRow();

                newRow["employee_id"] = empRow["employee_id"].ToString();
                newRow["employee_name"] = empRow["employee_name"].ToString();
                newRow["outstanding_loans"] = (RemoteServerLib.ProcStatic.DataRowConvert(empRow, "outstanding_loans", Int16.Parse("0")) >= 1) ?
                        RemoteServerLib.ProcStatic.DataRowConvert(empRow, "outstanding_loans", Int16.Parse("0")) + "  Outstanding Loan(s)" :
                        "None";
                newTable.Rows.Add(newRow);
            }

            newTable.AcceptChanges();

            return newTable;

        } //-------------------------------

        //this function returns a loan type information
        public CommonExchange.LoanInformation GetLoanTypeInformationDetails(String typeId)
        {
            CommonExchange.LoanInformation loanInfo = new CommonExchange.LoanInformation();

            String strFilter = "sysid_loan = '" + typeId + "'";
            DataRow[] selectRow = _classDataSet.Tables["LoanTypeInformationTable"].Select(strFilter, "sysid_loan ASC");

            foreach (DataRow loanRow in selectRow)
            {
                loanInfo.LoanSysId = loanRow["sysid_loan"].ToString();
                loanInfo.Description = loanRow["loan_description"].ToString();
            }

            return loanInfo;
        } //------------------------------

        //this function returns a loan remittance details
        public CommonExchange.LoanInformation GetDetailsLoanRemittance(String remSysId)
        {
            CommonExchange.LoanInformation loanInfo = new CommonExchange.LoanInformation();

            String strFilter = "sysid_remittance = '" + remSysId + "'";
            DataRow[] selectRow = _loanRemittance.Select(strFilter, "release_date DESC");

            foreach (DataRow loanRow in selectRow)
            {
                loanInfo.RemittanceSysId = remSysId;
                loanInfo.LoanSysId = RemoteServerLib.ProcStatic.DataRowConvert(loanRow, "sysid_loan", "");
                loanInfo.ReferenceNo = RemoteServerLib.ProcStatic.DataRowConvert(loanRow, "reference_no", "");
                loanInfo.Description = RemoteServerLib.ProcStatic.DataRowConvert(loanRow, "loan_description", "");
                loanInfo.ReleaseDate = RemoteServerLib.ProcStatic.DataRowConvert(loanRow, "release_date", DateTime.Parse(_serverDateTime)).ToLongDateString();
                loanInfo.MaturityDate = RemoteServerLib.ProcStatic.DataRowConvert(loanRow, "maturity_date", DateTime.Parse(_serverDateTime)).ToLongDateString();                
                loanInfo.PrincipalInterest = RemoteServerLib.ProcStatic.DataRowConvert(loanRow, "principal_interest", Decimal.Parse("0"));
                loanInfo.MonthlyAmmortization = RemoteServerLib.ProcStatic.DataRowConvert(loanRow, "monthly_pay", Decimal.Parse("0"));
            }

            return loanInfo;
        } //------------------------------------

        //this function gets the employee remittance details
        public CommonExchange.EmployeeLoanRemittance GetDetailsEmployeeRemittance(Int64 remittanceId)
        {
            CommonExchange.EmployeeLoanRemittance remInfo = new CommonExchange.EmployeeLoanRemittance();

            String strFilter = "remittance_id = '" + remittanceId + "'";
            DataRow[] selectRow = _employeeRemittance.Select(strFilter, "remittance_date ASC");

            foreach (DataRow remRow in selectRow)
            {
                remInfo.RemittanceId = remittanceId;
                remInfo.RemittanceDate = RemoteServerLib.ProcStatic.DataRowConvert(remRow, "remittance_date", DateTime.Parse(_serverDateTime)).ToLongDateString();
                remInfo.PayMonth = RemoteServerLib.ProcStatic.DataRowConvert(remRow, "pay_month", Int16.Parse("0"));
                remInfo.PayBalance = RemoteServerLib.ProcStatic.DataRowConvert(remRow, "pay_balance", Int16.Parse("0"));
                remInfo.AmountPaid = RemoteServerLib.ProcStatic.DataRowConvert(remRow, "amount_paid", Decimal.Parse("0"));
                remInfo.AmountBalance = RemoteServerLib.ProcStatic.DataRowConvert(remRow, "amount_balance", Decimal.Parse("0"));
            }

            return remInfo;

        } //----------------------------

        //this function returns the searched loan type information
        public DataTable GetSearchedLoanTypeInformation(String strSearch)
        {
            DataTable newTable = new DataTable("LoanTypeInformationSearchTable");
            newTable.Columns.Add("sysid_loan", System.Type.GetType("System.String"));
            newTable.Columns.Add("loan_description", System.Type.GetType("System.String"));

            strSearch = strSearch.Replace("*", "").Replace("%", "").Replace("'", "''");

            String strFilter = "loan_description LIKE '%" + strSearch + "%'";
            DataRow[] selectRow = _classDataSet.Tables["LoanTypeInformationTable"].Select(strFilter, "sysid_loan ASC");

            foreach (DataRow decRow in selectRow)
            {
                DataRow newRow = newTable.NewRow();

                newRow["sysid_loan"] = decRow["sysid_loan"].ToString();
                newRow["loan_description"] = decRow["loan_description"].ToString();

                newTable.Rows.Add(newRow);
            }

            newTable.AcceptChanges();

            return newTable;
        } //--------------------------------

        //this function is used to determine if the loan type description exists
        public Boolean IsLoanTypeDescriptionExist(CommonExchange.SysAccess userInfo, String description, String loanSysId)
        {
            Boolean isExist = false;

            using (RemoteClient.RemCntLoanManager remClient = new RemoteClient.RemCntLoanManager())
            {
                isExist = remClient.IsLoanTypeDescriptionExist(userInfo, description, loanSysId);
            }

            return isExist;
        } //-------------------------------------

        //this function returns the total paid loan remittance
        public Decimal GetTotalPaidLoanRemittance(String loanSysId)
        {
            Decimal totalRem = 0;

            String strFilter = "sysid_remittance = '" + loanSysId + "'";
            DataRow[] selectRow = _employeeRemittance.Select(strFilter, "remittance_date ASC");

            foreach (DataRow remRow in selectRow)
            {
                Decimal amountPaid = 0;

                if (Decimal.TryParse(remRow["amount_paid"].ToString(), out amountPaid))
                {
                    totalRem += amountPaid;
                }
            }

            return totalRem;

        } //-------------------------------

        //this function returns the loan remittance datasource index
        public Int32 GetLoanDataSourceIndex(String remSysId)
        {
            DataTable tempTable = new DataTable("LoanRemittanceByEmployeeIDTempTable");
            tempTable.Columns.Add("sysid_remittance", System.Type.GetType("System.String"));
            tempTable.Columns.Add("maturity_date", System.Type.GetType("System.DateTime"));

            foreach (DataRow loanRow in _loanRemittance.Rows)
            {
                DataRow newRow = tempTable.NewRow();

                newRow["sysid_remittance"] = loanRow["sysid_remittance"];
                newRow["maturity_date"] = RemoteServerLib.ProcStatic.DataRowConvert(loanRow, "maturity_date", DateTime.Parse(_serverDateTime));

                tempTable.Rows.Add(newRow);
            }

            tempTable.AcceptChanges();

            DataTable dbTable = new DataTable("LoanRemittanceTable");
            dbTable.Columns.Add("sysid_remittance", System.Type.GetType("System.String"));

            DataRow[] selectRow = tempTable.Select("", "maturity_date DESC");

            foreach (DataRow loanRow in selectRow)
            {
                DataRow newRow = dbTable.NewRow();

                newRow["sysid_remittance"] = loanRow["sysid_remittance"];

                dbTable.Rows.Add(newRow);
            }

            dbTable.AcceptChanges();

            Int32 index = 0;

            foreach (DataRow loanRow in dbTable.Rows)
            {
                if (String.Equals(remSysId, loanRow["sysid_remittance"].ToString()))
                {
                    break;
                }

                index++;
            }

            return index;

        } //----------------------------

        //this function returns the number months interval
        private Int32 GetNoMonthsInterval(DateTime start, DateTime end)
        {
            Int32 interval = 0;

            Int32 sMonth = start.Month;
            Int32 eMonth = end.Month;
            Int32 sYear = start.Year;
            Int32 eYear = end.Year;

            if (sYear < eYear)
            {
                interval += 12;
            }

            return interval + (eMonth - sMonth);

        } //---------------------------

        //this function returns the terms in month
        private Int32 GetTermsInMonth(DateTime releaseDate, DateTime maturityDate)
        {
            Int32 noTerms = 0;

            if (DateTime.Compare(releaseDate, maturityDate) < 0)
            {
                Int32 yearRelease = releaseDate.Year;
                Int32 yearMaturity = maturityDate.Year;

                if (yearRelease < yearMaturity)
                {
                    noTerms += ((yearMaturity - yearRelease) * 12);
                }

                Int32 monthRelease = releaseDate.Month;
                Int32 monthMaturity = maturityDate.Month;

                if (monthRelease < monthMaturity)
                {
                    noTerms += (monthMaturity - monthRelease);
                }
                else if (monthRelease > monthMaturity)
                {
                    noTerms -= (monthRelease - monthMaturity);
                }
            }

            return noTerms;

        } //-------------------------

        //this function returns the loan status
        private String GetLoanStatusString(String loanSysId)
        {
            String strStatus;

            Decimal principalInterest = 0;

            String strFilter = "sysid_remittance = '" + loanSysId + "'";
            DataRow[] selectRow = _loanRemittance.Select(strFilter, "release_date DESC");

            foreach (DataRow loanRow in selectRow)
            {
                if (!Decimal.TryParse(loanRow["principal_interest"].ToString(), out principalInterest))
                {
                    principalInterest = 0;
                }
            }
            
            if (this.GetTotalPaidLoanRemittance(loanSysId) < principalInterest)
            {
                strStatus = "Outstanding";
            }
            else
            {
                strStatus = "Fully Paid";
            }

            return strStatus;
        } //-------------------------------        

        #endregion
    }
}
