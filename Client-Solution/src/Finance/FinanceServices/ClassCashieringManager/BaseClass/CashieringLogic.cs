using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

namespace FinanceServices
{
    internal class CashieringLogic : BaseServices.BaseServicesLogic
    {
        #region Class Data Member Declaration
        private const Int32 c_studentCountStudent = 100;
        private DataSet _classDataSet;
        private DataTable _studentTable;
        private DataTable _studentTableMultiple;
        private DataTable _studentEmployeeTable;
        private DataTable _studentCourseTable;
        private DataTable _studentLevelTable;
        private DataTable _subjectScheduleTable;
        private DataTable _studentLoadTable;
        private DataTable _studentScholarshipTable;
        private DataTable _prematureDeloadedSubjectTable;
        private DataTable _schoolFeeDetailsTableCurrentCharge;
        private DataTable _schoolFeeDetailsTableWithdrawCharge;
        private DataTable _optionalFeeTable;
        private DataTable _additionalFeeTable;
        private DataTable _balanceForwardedTable;
        private DataTable _paymentReimbursementTable;
        private DataTable _majorExamScheduleTable;
        private DataTable _majorExamScheduleTableForPrinting;
        private DataTable _optionalSchoolFeeDetailsTable;
        private DataTable _paymentReimbursementTableTemp;
        private DataTable _studentCourseHistoryTable;
        private DataTable _studentLevelHistroyTable;
        private DataTable _studentPromissoryNoteTable;
        private DataTable _specialClassTable;
        private DataTable _stementOfAccountSummaryTable;
        private DataTable _cancelledReceiptTable;
        private DataTable _chartOfAccountsTable;
        private DataTable _miscellaneouseIncomeTable;
        private DataTable _cashReceiptQueryTable;
        private DataTable _cashReceiptDetailsTable;
        private DataTable _cashDiscountsTable;
        private DataTable _printingCashDiscountsTable;
        private DataTable _printingCashReceiptsDetailsTable;
        private DataTable _printingCashReceiptsQueryTable;
        private DataTable _summariezedCashReceiptTable;
        private DataTable _printingSummariezedCashReceiptTable;
        private DataTable _breakDownBankDepositDetailsTable;
        private DataTable _printingBreakDownBankDepositDetailsTable;
        private DataTable _breakDownBackDepositeSummarizedTable;
        private DataTable _printingBreakDownBankDepositeSummarizedTable;
       

        private Int64 _countOptionalFeeId;
        #endregion

        #region Class Properties Declaration
      
        public DataTable AdditionalFeeTable
        {
            get
            {
                DataTable newTable = new DataTable("AdditionalFeeTable");
                newTable.Columns.Add("sysid_feeparticular", System.Type.GetType("System.String"));
                newTable.Columns.Add("particular_description", System.Type.GetType("System.String"));
                newTable.Columns.Add("category_description", System.Type.GetType("System.String"));
                newTable.Columns.Add("is_optional", System.Type.GetType("System.String"));
                newTable.Columns.Add("is_office_access", System.Type.GetType("System.String"));
                newTable.Columns.Add("is_entry_level_included", System.Type.GetType("System.String"));
                newTable.Columns.Add("is_graduation_fee", System.Type.GetType("System.String"));

                return newTable;
            }
        }

        public DataTable StudentTableFormatIsForApply
        {
            get
            {
                DataTable newTable = new DataTable("StudentSearchByStudentNameIdCardNumberTableForApply");
                newTable.Columns.Add("checkbox_column", System.Type.GetType("System.Boolean"));
                newTable.Columns.Add("student_id", System.Type.GetType("System.String"));
                newTable.Columns.Add("student_name", System.Type.GetType("System.String"));
                newTable.Columns.Add("course_title", System.Type.GetType("System.String"));
                newTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
                newTable.Columns.Add("department_name", System.Type.GetType("System.String"));
                newTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));

                return newTable;
            }
        }

        public DataTable StudentTableFormatIsForViewing
        {
            get
            {
                DataTable newTable = new DataTable("StudentSearchByStudentNameIdCardNumberTable");               
                newTable.Columns.Add("student_id", System.Type.GetType("System.String"));
                newTable.Columns.Add("student_name", System.Type.GetType("System.String"));
                newTable.Columns.Add("particular_description_for_multiple", System.Type.GetType("System.String"));
                newTable.Columns.Add("remarks", System.Type.GetType("System.String"));
                newTable.Columns.Add("amount", System.Type.GetType("System.String"));
                newTable.Columns.Add("course_title", System.Type.GetType("System.String"));
                newTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
                newTable.Columns.Add("department_name", System.Type.GetType("System.String"));

                return newTable;
            }
        }

        public DataTable StudentEmployeeTableFormat
        {
            get
            {
                DataTable newTable = new DataTable("EmployeeStudentSearchByNameID");
                newTable.Columns.Add("student_employee_id", System.Type.GetType("System.String"));
                newTable.Columns.Add("student_employee_name", System.Type.GetType("System.String"));
                newTable.Columns.Add("card_number", System.Type.GetType("System.String"));
                newTable.Columns.Add("acronym", System.Type.GetType("System.String"));
                newTable.Columns.Add("course_title_department_name", System.Type.GetType("System.String"));
                newTable.Columns.Add("present_address", System.Type.GetType("System.String"));
                newTable.Columns.Add("present_phone_nos", System.Type.GetType("System.String"));

                return newTable;
            }
        }

        public DataTable OptinalFeeTableFormat
        {
            get
            {
                DataTable optionalFeeTable = new DataTable("OptionalFeeTableFormat");
                optionalFeeTable.Columns.Add("sysid_feedetails", System.Type.GetType("System.String"));
                optionalFeeTable.Columns.Add("particular_description", System.Type.GetType("System.String"));
                optionalFeeTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));

                return optionalFeeTable;
            }
        }

        public DataTable ScholarshpTableFormat
        {
            get
            {

                DataTable scholarTable = new DataTable("ScholarshipTableFormat");
                scholarTable.Columns.Add("sysid_scholarship", System.Type.GetType("System.String"));
                scholarTable.Columns.Add("scholarship_description", System.Type.GetType("System.String"));
                scholarTable.Columns.Add("department_name", System.Type.GetType("System.String"));
                scholarTable.Columns.Add("group_description", System.Type.GetType("System.String"));

                return scholarTable;
            }
        }

        public DataTable ChartOfAccountTableFormat
        {
            get
            {
                DataTable chartOfAccountTable = new DataTable("ChartOfAccountTable");
                chartOfAccountTable.Columns.Add("account_code_name", System.Type.GetType("System.String"));
                chartOfAccountTable.Columns.Add("category_description", System.Type.GetType("System.String"));
                chartOfAccountTable.Columns.Add("account_code_name_summary", System.Type.GetType("System.String"));
                chartOfAccountTable.Columns.Add("category_description_summary", System.Type.GetType("System.String"));
                chartOfAccountTable.Columns.Add("sysid_account", System.Type.GetType("System.String"));

                return chartOfAccountTable;
            }
        }

        //AD
        public DataTable StudentTable
        {
            get { return _studentTable; }
            set { _studentTable = value; }
        }
        //-------------------
        #endregion

        #region Class Constructors
        public CashieringLogic(CommonExchange.SysAccess userInfo)
            : base(userInfo)
        {
            this.InitializeClass(userInfo);      
        }
        #endregion

        #region Programer-Defined Procedures
         //this procedure will initialize class
        private void InitializeClass(CommonExchange.SysAccess userInfo)
        {
            //get the server date and time
            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                _serverDateTime = remClient.GetServerDateTime(userInfo);
            }//---------------------

            //get class dataset cashiering manager
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                _classDataSet = remClient.GetDataSetForCashiering(userInfo, _serverDateTime);
            }

            //insert temporary columns on Class DataSet[SchoolFeeParticularTable]
            DataRow newRowFixedRow = _classDataSet.Tables["SchoolFeeParticularTable"].NewRow();

            newRowFixedRow["sysid_feeparticular"] = "tempFixedSub01";
            newRowFixedRow["particular_description"] = "Fixed Amount";
            newRowFixedRow["category_no"] = 1;
            newRowFixedRow["fee_category_id"] = "FCID01";

            _classDataSet.Tables["SchoolFeeParticularTable"].Rows.Add(newRowFixedRow);

            DataRow newRowSpecialClass = _classDataSet.Tables["SchoolFeeParticularTable"].NewRow();

            newRowSpecialClass["sysid_feeparticular"] = "tempSpecialClass01";
            newRowSpecialClass["particular_description"] = "Special Class";
        	newRowSpecialClass["category_no"] = 1;
            newRowSpecialClass["fee_category_id"] = "FCID01";

            _classDataSet.Tables["SchoolFeeParticularTable"].Rows.Add(newRowSpecialClass);          
            //-----------------------end insert

            //initialized premature deloaded table
            _prematureDeloadedSubjectTable = new DataTable("PrematureDeloadedTable");
            _prematureDeloadedSubjectTable.Columns.Add("load_id", System.Type.GetType("System.Int64"));
            _prematureDeloadedSubjectTable.Columns.Add("sysid_schedule", System.Type.GetType("System.String"));
            _prematureDeloadedSubjectTable.Columns.Add("sysid_subject", System.Type.GetType("System.String"));
            _prematureDeloadedSubjectTable.Columns.Add("is_loaded_to_student", System.Type.GetType("System.Boolean"));
            //--------------------------------

            //initialize student load table
            _studentLoadTable = new DataTable("StudentLoadTable");
            _studentLoadTable.Columns.Add("load_id", System.Type.GetType("System.Int64"));
            _studentLoadTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));
            _studentLoadTable.Columns.Add("sysid_schedule", System.Type.GetType("System.String"));
            _studentLoadTable.Columns.Add("is_loaded", System.Type.GetType("System.Boolean"));
            _studentLoadTable.Columns.Add("is_premature_deloaded", System.Type.GetType("System.Boolean"));
            //----------------------------------

            //initialize optional fee table
            _optionalFeeTable = new DataTable("OptionalFeeTable");
            _optionalFeeTable.Columns.Add("optional_fee_id", System.Type.GetType("System.Int64"));
            _optionalFeeTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));
            _optionalFeeTable.Columns.Add("sysid_feedetails", System.Type.GetType("System.String"));
            _optionalFeeTable.Columns.Add("fee_category_id", System.Type.GetType("System.String"));
            _optionalFeeTable.Columns.Add("particular_description", System.Type.GetType("System.String"));
            _optionalFeeTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));
            _optionalFeeTable.Columns.Add("is_level_increase", System.Type.GetType("System.Boolean"));
            _optionalFeeTable.Columns.Add("is_optional_fee", System.Type.GetType("System.Boolean"));
            _optionalFeeTable.Columns.Add("is_office_access", System.Type.GetType("System.Boolean"));
            //------------------------------- 

            //initialize additional fee table
            _additionalFeeTable = new DataTable("AdditionalFeeTable");
            _additionalFeeTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));
            _additionalFeeTable.Columns.Add("sysid_feeparticular", System.Type.GetType("System.String"));
            _additionalFeeTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));
            _additionalFeeTable.Columns.Add("remarks", System.Type.GetType("System.String"));
            //-----------------

            //initialize the temporary payment discount reimbursementa table
            _paymentReimbursementTableTemp = new DataTable("TempPaymentDiscountReimbursmenTable");
            _paymentReimbursementTableTemp.Columns.Add("payment_discount_reimbursement_id", System.Type.GetType("System.Int64"));
            _paymentReimbursementTableTemp.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            _paymentReimbursementTableTemp.Columns.Add("received_date", System.Type.GetType("System.String"));
            _paymentReimbursementTableTemp.Columns.Add("reflected_date", System.Type.GetType("System.String"));
            _paymentReimbursementTableTemp.Columns.Add("receipt_no", System.Type.GetType("System.String"));
            _paymentReimbursementTableTemp.Columns.Add("remarks_discount_reimbursement_description", System.Type.GetType("System.String"));
            _paymentReimbursementTableTemp.Columns.Add("is_downpayment", System.Type.GetType("System.Boolean"));
            _paymentReimbursementTableTemp.Columns.Add("amount", System.Type.GetType("System.Decimal"));
            _paymentReimbursementTableTemp.Columns.Add("discount_amount", System.Type.GetType("System.Decimal"));
            _paymentReimbursementTableTemp.Columns.Add("is_payment", System.Type.GetType("System.Boolean"));
            _paymentReimbursementTableTemp.Columns.Add("is_discount", System.Type.GetType("System.Boolean"));
            _paymentReimbursementTableTemp.Columns.Add("is_reimbursement", System.Type.GetType("System.Boolean"));
            _paymentReimbursementTableTemp.Columns.Add("is_balance_forwarded", System.Type.GetType("System.Boolean"));
            _paymentReimbursementTableTemp.Columns.Add("is_credit_memo", System.Type.GetType("System.Boolean"));
            _paymentReimbursementTableTemp.Columns.Add("is_included_in_post", System.Type.GetType("System.Boolean"));
            //------------------------           

            //initialize major exam table
            _majorExamScheduleTableForPrinting = new DataTable("MajorExamScheduleTable");
            _majorExamScheduleTableForPrinting.Columns.Add("major_exam_id", System.Type.GetType("System.String"));
            _majorExamScheduleTableForPrinting.Columns.Add("exam_date", System.Type.GetType("System.String"));
            _majorExamScheduleTableForPrinting.Columns.Add("exam_description", System.Type.GetType("System.String"));
            _majorExamScheduleTableForPrinting.Columns.Add("is_for_print", System.Type.GetType("System.Boolean"));
            _majorExamScheduleTableForPrinting.Columns.Add("is_clearance_included", System.Type.GetType("System.Boolean"));
            _majorExamScheduleTableForPrinting.Columns.Add("course_group_id", System.Type.GetType("System.String"));
            //-------------------------

            _studentTableMultiple = new DataTable("DataTableMultipleAdditionalFee");

            //initialize account summary table
            _stementOfAccountSummaryTable = new DataTable("StatementOfAccountTable");
            _stementOfAccountSummaryTable.Columns.Add("description", System.Type.GetType("System.String"));
            _stementOfAccountSummaryTable.Columns.Add("text_balance", System.Type.GetType("System.String"));
            _stementOfAccountSummaryTable.Columns.Add("amount", System.Type.GetType("System.String"));
            _stementOfAccountSummaryTable.Columns.Add("total_amount", System.Type.GetType("System.String"));
            //------------------------

            //initialize table for printing cash receipts details
            _printingCashReceiptsDetailsTable = new DataTable("PrintingCashReceiptsTable");
            _printingCashReceiptsDetailsTable.Columns.Add("receipt_no", System.Type.GetType("System.String"));
            _printingCashReceiptsDetailsTable.Columns.Add("received_date", System.Type.GetType("System.String"));
            _printingCashReceiptsDetailsTable.Columns.Add("received_from", System.Type.GetType("System.String"));
            _printingCashReceiptsDetailsTable.Columns.Add("acronym", System.Type.GetType("System.String"));
            _printingCashReceiptsDetailsTable.Columns.Add("account_code", System.Type.GetType("System.String"));          
            _printingCashReceiptsDetailsTable.Columns.Add("account_name", System.Type.GetType("System.String"));
            _printingCashReceiptsDetailsTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));
            _printingCashReceiptsDetailsTable.Columns.Add("total", System.Type.GetType("System.Decimal"));
            //-----------------------

            //initialize table for printing cash receipts query
            _printingCashReceiptsQueryTable = new DataTable("PrintingCashReceiptsQueryTable");
            _printingCashReceiptsQueryTable.Columns.Add("receipt_no", System.Type.GetType("System.String"));
            _printingCashReceiptsQueryTable.Columns.Add("received_date", System.Type.GetType("System.String"));
            _printingCashReceiptsQueryTable.Columns.Add("received_from", System.Type.GetType("System.String"));
            _printingCashReceiptsQueryTable.Columns.Add("acronym", System.Type.GetType("System.String"));
            _printingCashReceiptsQueryTable.Columns.Add("account_code", System.Type.GetType("System.String"));
            _printingCashReceiptsQueryTable.Columns.Add("account_name", System.Type.GetType("System.String"));
            _printingCashReceiptsQueryTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));
            _printingCashReceiptsQueryTable.Columns.Add("total", System.Type.GetType("System.Decimal"));
            //-----------------------

            //initialize table for printing summariezed cash receipts
            _printingSummariezedCashReceiptTable = new DataTable("SummariezedCashReceipts");
            _printingSummariezedCashReceiptTable.Columns.Add("group_title", System.Type.GetType("System.String"));
            _printingSummariezedCashReceiptTable.Columns.Add("account_code_summary", System.Type.GetType("System.String"));
            _printingSummariezedCashReceiptTable.Columns.Add("account_name_summary", System.Type.GetType("System.String"));
            _printingSummariezedCashReceiptTable.Columns.Add("acronym", System.Type.GetType("System.String"));
            _printingSummariezedCashReceiptTable.Columns.Add("account_code_subsidiary", System.Type.GetType("System.String"));
            _printingSummariezedCashReceiptTable.Columns.Add("account_name_subsidiary", System.Type.GetType("System.String"));
            _printingSummariezedCashReceiptTable.Columns.Add("total_amount", System.Type.GetType("System.Decimal"));
            _printingSummariezedCashReceiptTable.Columns.Add("total", System.Type.GetType("System.Decimal"));

            //initialize table for printing break down bank deposit details
            _printingBreakDownBankDepositDetailsTable = new DataTable("PrintingBreakDownDetails");
            _printingBreakDownBankDepositDetailsTable.Columns.Add("account_code_summary", System.Type.GetType("System.String"));
            _printingBreakDownBankDepositDetailsTable.Columns.Add("account_name_summary", System.Type.GetType("System.String"));
            _printingBreakDownBankDepositDetailsTable.Columns.Add("account_code", System.Type.GetType("System.String"));
            _printingBreakDownBankDepositDetailsTable.Columns.Add("account_name", System.Type.GetType("System.String"));
            _printingBreakDownBankDepositDetailsTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));
            //-------------------------

            //initialize table for printing break down bank deposit summarized
            _printingBreakDownBankDepositeSummarizedTable = new DataTable("PrintingBreakDownSummarized");
            _printingBreakDownBankDepositeSummarizedTable.Columns.Add("account_code_summary", System.Type.GetType("System.String"));
            _printingBreakDownBankDepositeSummarizedTable.Columns.Add("account_name_summary", System.Type.GetType("System.String"));
            _printingBreakDownBankDepositeSummarizedTable.Columns.Add("account_code_subsidiary", System.Type.GetType("System.String"));
            _printingBreakDownBankDepositeSummarizedTable.Columns.Add("account_name_subsidiary", System.Type.GetType("System.String"));
            _printingBreakDownBankDepositeSummarizedTable.Columns.Add("total_amount", System.Type.GetType("System.Decimal"));

            //initialize table for printing cash discounts
            _printingCashDiscountsTable = new DataTable("PrintingCashDiscountTable");
            _printingCashDiscountsTable.Columns.Add("receipt_no", System.Type.GetType("System.String"));
            _printingCashDiscountsTable.Columns.Add("received_date", System.Type.GetType("System.String"));
            _printingCashDiscountsTable.Columns.Add("received_from", System.Type.GetType("System.String"));
            _printingCashDiscountsTable.Columns.Add("acronym", System.Type.GetType("System.String"));
            _printingCashDiscountsTable.Columns.Add("account_code", System.Type.GetType("System.String"));
            _printingCashDiscountsTable.Columns.Add("account_name", System.Type.GetType("System.String"));
            _printingCashDiscountsTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));
            _printingCashDiscountsTable.Columns.Add("total", System.Type.GetType("System.Decimal"));
            //-----------------------
        }//---------------------------

        //this procedure will initialize server date and time
        public void SetServerDateTime(CommonExchange.SysAccess userInfo)
        {
            //get the server date and time
            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                _serverDateTime = remClient.GetServerDateTime(userInfo);
            }//---------------------
        }//---------------------

        //this procedure refreshes the data
        public void RefreshData(CommonExchange.SysAccess userInfo)
        {
            //get the server date and time
            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                _serverDateTime = remClient.GetServerDateTime(userInfo);
            }//---------------------

            //get class dataset cashiering manager
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                _classDataSet = remClient.GetDataSetForCashiering(userInfo, _serverDateTime);
            }
        }//-------------------------------

        //this procedure will print cash receipt details report
        public void PrintCashReceiptQueryReport(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd, Boolean includeDate)
        {
            String strCashierConsolidated = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName);
            String strRange = includeDate ? DateTime.Parse(dateStart).ToLongDateString() + " - " + DateTime.Parse(dateEnd).ToLongDateString() : String.Empty;

            using (ClassCashieringManager.CrystalReport.CrystalCashReceiptQueryReport rptCashReceiptQuery = new
                FinanceServices.ClassCashieringManager.CrystalReport.CrystalCashReceiptQueryReport())
            {
                rptCashReceiptQuery.Database.Tables["cash_receipt_details"].SetDataSource(_printingCashReceiptsQueryTable);

                rptCashReceiptQuery.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                rptCashReceiptQuery.SetParameterValue("@form_name", "Cash Receipt (Query)");
                rptCashReceiptQuery.SetParameterValue("@cashier_consolidated", strCashierConsolidated);
                rptCashReceiptQuery.SetParameterValue("@date_range", strRange);
                rptCashReceiptQuery.SetParameterValue("@user_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
                    DateTime.Parse(_serverDateTime).ToShortTimeString() + "         Printed by: " +
                    RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                    userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));
             
                using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptCashReceiptQuery))
                {
                    frmViewer.Text = "   Cash Receipt Query";
                    frmViewer.ShowDialog();
                }
            }
        }//------------------------------

        //this procedure will print cash receipt summarized report
        public void PrintCashReceiptSummarizedReport(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd, Boolean isConsolidated)
        {
            String strCashierConsolidated = isConsolidated ? "Consolidated" : RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                       userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName);

            Decimal totalCollection = 0, totalDeposits = 0;

            if (_printingSummariezedCashReceiptTable != null)
            {
                foreach (DataRow detailsRow in _printingSummariezedCashReceiptTable.Rows)
                {
                    totalCollection += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "total_amount", Decimal.Parse("0"));
                }
            }

            if (_printingBreakDownBankDepositeSummarizedTable != null)
            {
                foreach (DataRow depositRow in _printingBreakDownBankDepositeSummarizedTable.Rows)
                {
                    totalDeposits += RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "total_amount", Decimal.Parse("0"));
                }
            }

            using (ClassCashieringManager.CrystalReport.CrystalCashReceiptSummarized rptCashReceiptSummarized = new
                FinanceServices.ClassCashieringManager.CrystalReport.CrystalCashReceiptSummarized())
            {
                rptCashReceiptSummarized.Database.Tables["cash_receipt_summarized"].SetDataSource(_printingSummariezedCashReceiptTable);
                rptCashReceiptSummarized.Database.Tables["break_down_summarized"].SetDataSource(_printingBreakDownBankDepositeSummarizedTable);

                rptCashReceiptSummarized.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                rptCashReceiptSummarized.SetParameterValue("@form_name", "Cash Receipt (Summarized)");
                rptCashReceiptSummarized.SetParameterValue("@cashier_consolidated", strCashierConsolidated);
                rptCashReceiptSummarized.SetParameterValue("@date_range", DateTime.Parse(dateStart).ToLongDateString() + " - " +
                    DateTime.Parse(dateEnd).ToLongDateString());
                rptCashReceiptSummarized.SetParameterValue("@print_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
                    DateTime.Parse(_serverDateTime).ToShortTimeString() + "         Printed by: " +
                    RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                    userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));
                rptCashReceiptSummarized.SetParameterValue("@total_collection", totalCollection);
                rptCashReceiptSummarized.SetParameterValue("@total_diposit", totalDeposits);
                rptCashReceiptSummarized.SetParameterValue("@overage_shortage", (totalDeposits - totalCollection));
                rptCashReceiptSummarized.SetParameterValue("@prepared_by", RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                    userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));
                rptCashReceiptSummarized.SetParameterValue("@verified_by", CommonExchange.SchoolInformation.BookKeeper);
                rptCashReceiptSummarized.SetParameterValue("@approved_by", CommonExchange.SchoolInformation.VPOfFinanceAffairs);

                using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptCashReceiptSummarized))
                {
                    frmViewer.Text = "   Cash Receipt Summarized";
                    frmViewer.ShowDialog();
                }
            }
        }//------------------------------

        //this procedure will print cash receipt details report
        public void PrintCashReceiptDetailReport(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd, Boolean isConsolidated)
        {
            String strCashierConsolidated = isConsolidated ? "Consolidated" : RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                        userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName);

            Decimal totalCollection = 0, totalDeposits = 0;

            if (_printingCashReceiptsDetailsTable != null)
            {
                foreach (DataRow detailsRow in _printingCashReceiptsDetailsTable.Rows)
                {
                    totalCollection += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                }
            }

            if (_printingBreakDownBankDepositDetailsTable != null)
            {
                foreach (DataRow depositRow in _printingBreakDownBankDepositDetailsTable.Rows)
                {
                    totalDeposits += RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "amount", Decimal.Parse("0"));
                }
            }

            Int32 max = 0, min = 0, count = 1, receiptNo = 0;

            if (_printingCashReceiptsDetailsTable != null)
            {
                foreach (DataRow rRow in _printingCashReceiptsDetailsTable.Rows)
                {
                    if (Int32.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(rRow, "receipt_no", String.Empty), out receiptNo))
                    {
                        if (count == 1)
                        {
                            max = min = receiptNo;
                        }
                        else
                        {
                            if (max < receiptNo)
                            {
                                max = receiptNo;
                            }

                            if (min > receiptNo)
                            {
                                min = receiptNo;
                            }
                        }

                        count++;
                    }
                }
            }

            using (ClassCashieringManager.CrystalReport.CrystalCashReceiptDetailsReport rptCashReceiptDetails = new
                FinanceServices.ClassCashieringManager.CrystalReport.CrystalCashReceiptDetailsReport())
            {
                rptCashReceiptDetails.Database.Tables["cash_receipt_details"].SetDataSource(_printingCashReceiptsDetailsTable);
                rptCashReceiptDetails.Database.Tables["break_down_detals"].SetDataSource(_printingBreakDownBankDepositDetailsTable);

                rptCashReceiptDetails.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                rptCashReceiptDetails.SetParameterValue("@form_name", "Cash Receipt (Detailed)");
                rptCashReceiptDetails.SetParameterValue("@cashier_consolidated", strCashierConsolidated);
                rptCashReceiptDetails.SetParameterValue("@date_range", DateTime.Parse(dateStart).ToLongDateString() + " - " +
                    DateTime.Parse(dateEnd).ToLongDateString());
                rptCashReceiptDetails.SetParameterValue("@cash_receipts_range", min.ToString() + " - " + max.ToString());
                rptCashReceiptDetails.SetParameterValue("@user_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
                    DateTime.Parse(_serverDateTime).ToShortTimeString() + "         Printed by: " +
                    RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                    userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));
                rptCashReceiptDetails.SetParameterValue("@total_collection",  totalCollection);
                rptCashReceiptDetails.SetParameterValue("@total_diposit", totalDeposits);
                rptCashReceiptDetails.SetParameterValue("@overage_shortage", (totalDeposits - totalCollection));
                rptCashReceiptDetails.SetParameterValue("@prepared_by", RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                    userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));
                rptCashReceiptDetails.SetParameterValue("@verified_by", CommonExchange.SchoolInformation.BookKeeper);
                rptCashReceiptDetails.SetParameterValue("@approved_by", CommonExchange.SchoolInformation.VPOfFinanceAffairs);

                using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptCashReceiptDetails))
                {
                    frmViewer.Text = "   Cash Receipt Detailed";
                    frmViewer.ShowDialog();
                }
            }
        }//------------------------------

        //this procedure will print cash receipt details report
        public void PrintCashDiscountsReport(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd, Boolean isConsolidated)
        {
            String strCashierConsolidated = isConsolidated ? "Consolidated" : RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                        userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName);

            using (ClassCashieringManager.CrystalReport.CrystalCashDiscountReport rptCashDiscountsReport = new
                FinanceServices.ClassCashieringManager.CrystalReport.CrystalCashDiscountReport())
            {
                rptCashDiscountsReport.Database.Tables["cash_receipt_details"].SetDataSource(_printingCashDiscountsTable);

                rptCashDiscountsReport.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                rptCashDiscountsReport.SetParameterValue("@form_name", "Cash Discounts");
                rptCashDiscountsReport.SetParameterValue("@cashier_consolidated", strCashierConsolidated);
                rptCashDiscountsReport.SetParameterValue("@date_range", DateTime.Parse(dateStart).ToLongDateString() + " - " +
                    DateTime.Parse(dateEnd).ToLongDateString());
                rptCashDiscountsReport.SetParameterValue("@user_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
                    DateTime.Parse(_serverDateTime).ToShortTimeString() + "         Printed by: " +
                    RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                    userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));
                rptCashDiscountsReport.SetParameterValue("@prepared_by", RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                    userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));
                rptCashDiscountsReport.SetParameterValue("@verified_by", CommonExchange.SchoolInformation.BookKeeper);
                rptCashDiscountsReport.SetParameterValue("@approved_by", CommonExchange.SchoolInformation.VPOfFinanceAffairs);

                using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptCashDiscountsReport))
                {
                    frmViewer.Text = "   Cash Discounts";
                    frmViewer.ShowDialog();
                }
            }
        }//------------------------------

        //this procedure will print receipt number
        public void PrintReceiptNumberStudentPayments(CommonExchange.SysAccess userInfo, CommonExchange.StudentPayments studentPaymentInfo,
            CommonExchange.Student studentInfo, String dateEnd, String courseTitleAcronym, long wholeNum, int decNum)
        {
            ConvertNumberWords numberToWordsManager = new ConvertNumberWords();

            numberToWordsManager.ProcessNumber(wholeNum, decNum);

            DataTable balanceTable;

            using (RemoteClient.RemCntStudentLoadingManager remClient = new RemoteClient.RemCntStudentLoadingManager())
            {
                balanceTable = remClient.SelectBySysIDStudentListForStudentRunningBalanceStudentLoad(userInfo, studentInfo.StudentSysId);
            }

            DataRow balRow = balanceTable.Rows[0];

            Decimal balanceAmount = RemoteServerLib.ProcStatic.DataRowConvert(balRow, "amount", Decimal.Parse("0"));


            using (ClassCashieringManager.CrystalReport.CrystalReceipt rptReceipt = new
                    FinanceServices.ClassCashieringManager.CrystalReport.CrystalReceipt())
            {
                rptReceipt.SetParameterValue("@receipt", studentPaymentInfo.ReceiptNo);
                rptReceipt.SetParameterValue("@date", DateTime.Parse(studentPaymentInfo.ReceiptDate).ToShortDateString());
                rptReceipt.SetParameterValue("@receiveFrom", "Received from: " +
                    RemoteClient.ProcStatic.GetCompleteNameFullMiddleName(studentInfo.PersonInfo.LastName,
                    studentInfo.PersonInfo.FirstName, studentInfo.PersonInfo.MiddleName) + "   (" + studentInfo.StudentId + ")  " + courseTitleAcronym);
                rptReceipt.SetParameterValue("@theSumOf", numberToWordsManager.NumberString + " Only");
                rptReceipt.SetParameterValue("@amountFigure", "(Php " + studentPaymentInfo.Amount.ToString("N") + ")");

                //String description = !String.IsNullOrEmpty(studentPaymentInfo.Remarks) ? studentPaymentInfo.Remarks :
                //    this.GetReceiptPaymentDescription(studentPaymentInfo.Amount, studentPaymentInfo.PaymentId);

                //String description = this.GetReceiptPaymentDescription(studentPaymentInfo.Amount, studentPaymentInfo.PaymentId);

                //description += !String.IsNullOrEmpty(studentPaymentInfo.Remarks) ? "**" + studentPaymentInfo.Remarks : String.Empty;

                rptReceipt.SetParameterValue("@description", this.GetReceiptPaymentDescription(studentPaymentInfo.Amount, studentPaymentInfo.PaymentId));
                rptReceipt.SetParameterValue("@remarks", studentPaymentInfo.Remarks);
                rptReceipt.SetParameterValue("@runningBalance", "Running Balance: " + balanceAmount.ToString("N"));
                rptReceipt.SetParameterValue("@cash", "Cash   : ".PadRight(10) + studentPaymentInfo.AmountTendered.ToString("N").PadLeft(15));
                rptReceipt.SetParameterValue("@change", "Change : ".PadRight(10) + 
                    (studentPaymentInfo.AmountTendered - studentPaymentInfo.Amount).ToString("N").PadLeft(15));
                rptReceipt.SetParameterValue("@bank", studentPaymentInfo.Bank);
                rptReceipt.SetParameterValue("@checkNo", studentPaymentInfo.CheckNo);
                rptReceipt.SetParameterValue("@cashier", userInfo.PersonInfo.LastName);

                rptReceipt.PrintToPrinter(1, false, 0, 0);

                //using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptReceipt))
                //{
                //    frmViewer.Text = "   Student Receipt";
                //    frmViewer.ShowDialog();
                //}
            }
        }//-----------------------

        //this procedure will print receipt number
        public void PrintReceiptMiscellaneousIncome(CommonExchange.SysAccess userInfo, CommonExchange.MiscellaneousIncome miscellaneousIncomeInfo,
            long wholeNum, int decNum)
        {
            ConvertNumberWords numberToWordsManager = new ConvertNumberWords();

            numberToWordsManager.ProcessNumber(wholeNum, decNum);

            //String remarks = !String.IsNullOrEmpty(miscellaneousIncomeInfo.Remarks) ? " (" + miscellaneousIncomeInfo.Remarks + ")" : String.Empty;

            using (ClassCashieringManager.CrystalReport.CrystalReceipt rptReceipt = new
                    FinanceServices.ClassCashieringManager.CrystalReport.CrystalReceipt())
            {
                rptReceipt.SetParameterValue("@receipt", miscellaneousIncomeInfo.ReceiptNo);
                rptReceipt.SetParameterValue("@date", DateTime.Parse(miscellaneousIncomeInfo.ReceiptDate).ToShortDateString());
                rptReceipt.SetParameterValue("@receiveFrom", "Received from: " + miscellaneousIncomeInfo.ReceivedFrom);
                rptReceipt.SetParameterValue("@theSumOf", numberToWordsManager.NumberString + " Only");
                rptReceipt.SetParameterValue("@amountFigure", "(Php " + miscellaneousIncomeInfo.Amount.ToString("N") + ")");
                rptReceipt.SetParameterValue("@description", miscellaneousIncomeInfo.AccountCreditInfo.AccountName);
                rptReceipt.SetParameterValue("@remarks", miscellaneousIncomeInfo.Remarks);
                rptReceipt.SetParameterValue("@runningBalance", String.Empty);
                rptReceipt.SetParameterValue("@cash", "Cash   : ".PadRight(10) + miscellaneousIncomeInfo.AmountTendered.ToString("N").PadLeft(15));
                rptReceipt.SetParameterValue("@change", "Change : ".PadRight(10) +
                    (miscellaneousIncomeInfo.AmountTendered - miscellaneousIncomeInfo.Amount).ToString("N").PadLeft(15));
                rptReceipt.SetParameterValue("@bank", miscellaneousIncomeInfo.Bank);
                rptReceipt.SetParameterValue("@checkNo", miscellaneousIncomeInfo.CheckNo);
                rptReceipt.SetParameterValue("@cashier", userInfo.PersonInfo.LastName);

                rptReceipt.PrintToPrinter(1, false, 0, 0);

                //using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptReceipt))
                //{
                //    frmViewer.Text = "   Student Receipt";
                //    frmViewer.ShowDialog();
                //}
            }
        }//-----------------------

        //this procedure will print student accounts receivable per (FISCAL YEAR)
        public void PrintStudentAccountsReceivablePerFiscalYear(CommonExchange.SysAccess userInfo, String yearId, String strFiscalYear, ProgressBar pgbBase)
        {
            DataTable studentTable = new DataTable("StudentTableList");
            studentTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            studentTable.Columns.Add("student_id", System.Type.GetType("System.String"));
            studentTable.Columns.Add("last_name", System.Type.GetType("System.String"));
            studentTable.Columns.Add("first_name", System.Type.GetType("System.String"));
            studentTable.Columns.Add("middle_name", System.Type.GetType("System.String"));
            studentTable.Columns.Add("course_acronym", System.Type.GetType("System.String"));
            studentTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));

            DataTable studentBalanceTable = new DataTable("StudentBalancesTable");
            studentBalanceTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            studentBalanceTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));

            DataTable reportTable = new DataTable("CreditMemoReportTable");
            reportTable.Columns.Add("student_id", System.Type.GetType("System.String"));
            reportTable.Columns.Add("name", System.Type.GetType("System.String"));
            reportTable.Columns.Add("course_level", System.Type.GetType("System.String"));
            reportTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));

            pgbBase.PerformStep();

            String dateStart = String.Empty;
            String dateEnd = String.Empty;

            //---------------- query for yearly (High School and Grade School)
            String strFilterYearId = "year_id = '" + yearId + "'";
            DataRow[] selectRowYear = _classDataSet.Tables["SchoolFeeInformationTable"].Select(strFilterYearId);

            foreach (DataRow yearRow in selectRowYear)
            {
                dateStart = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "date_start", String.Empty)).ToShortDateString() + " 12:00:00 AM";
                dateEnd = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "date_end", String.Empty)).ToShortDateString() + " 11:59:59 PM";

                break;
            }

            using (RemoteClient.RemCntStudentManager remClient = new RemoteClient.RemCntStudentManager())
            {
                DataTable tempStudTable;
                tempStudTable = remClient.SelectStudentInformation(userInfo, "*", dateStart, dateEnd, String.Empty, String.Empty);

                if (tempStudTable != null)
                {
                    foreach (DataRow studRow in tempStudTable.Rows)
                    {
                        String strFilterDistinct = "sysid_student = '" + RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", String.Empty) + "'";
                        DataRow[] selectRow = studentTable.Select(strFilterDistinct);

                        if (selectRow.Length == 0)
                        {
                            DataRow newRow = studentTable.NewRow();

                            newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", String.Empty);
                            newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", String.Empty);
                            newRow["last_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", String.Empty);
                            newRow["first_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", String.Empty);
                            newRow["middle_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", String.Empty);
                            newRow["course_acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_acronym", String.Empty);
                            newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_description", String.Empty);

                            studentTable.Rows.Add(newRow);
                        }
                    }
                }
            }
            //------------------- end -----------------

            //---------------- query for 1st semester
            strFilterYearId = "year_id = '" + yearId + "' AND semester_id = 1";
            DataRow[] selectRowSemesterFirst = _classDataSet.Tables["SemesterInformationTable"].Select(strFilterYearId);

            foreach (DataRow yearRow in selectRowSemesterFirst)
            {
                dateStart = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "date_start", String.Empty)).ToShortDateString() + " 12:00:00 AM";
                dateEnd = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "date_end", String.Empty)).ToShortDateString() + " 11:59:59 PM";

                break;
            }

            using (RemoteClient.RemCntStudentManager remClient = new RemoteClient.RemCntStudentManager())
            {
                DataTable tempStudTable;
                tempStudTable = remClient.SelectStudentInformation(userInfo, "*", dateStart, dateEnd, String.Empty, String.Empty);

                if (tempStudTable != null)
                {
                    foreach (DataRow studRow in tempStudTable.Rows)
                    {
                        String strFilterDistinct = "sysid_student = '" + RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", String.Empty) + "'";
                        DataRow[] selectRow = studentTable.Select(strFilterDistinct);

                        if (selectRow.Length == 0)
                        {
                            DataRow newRow = studentTable.NewRow();

                            newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", String.Empty);
                            newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", String.Empty);
                            newRow["last_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", String.Empty);
                            newRow["first_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", String.Empty);
                            newRow["middle_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", String.Empty);
                            newRow["course_acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_acronym", String.Empty);
                            newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_description", String.Empty);

                            studentTable.Rows.Add(newRow);
                        }
                    }
                }
            }
            //------------------- end -----------------

            //---------------- query for 2st semester
            strFilterYearId = "year_id = '" + yearId + "' AND semester_id = 2";
            DataRow[] selectRowSemesterSecond = _classDataSet.Tables["SemesterInformationTable"].Select(strFilterYearId);

            foreach (DataRow yearRow in selectRowSemesterSecond)
            {
                dateStart = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "date_start", String.Empty)).ToShortDateString() + " 12:00:00 AM";
                dateEnd = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "date_end", String.Empty)).ToShortDateString() + " 11:59:59 PM";

                break;
            }

            using (RemoteClient.RemCntStudentManager remClient = new RemoteClient.RemCntStudentManager())
            {
                DataTable tempStudTable;
                tempStudTable = remClient.SelectStudentInformation(userInfo, "*", dateStart, dateEnd, String.Empty, String.Empty);

                if (tempStudTable != null)
                {
                    foreach (DataRow studRow in tempStudTable.Rows)
                    {
                        String strFilterDistinct = "sysid_student = '" + RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", String.Empty) + "'";
                        DataRow[] selectRow = studentTable.Select(strFilterDistinct);

                        if (selectRow.Length == 0)
                        {
                            DataRow newRow = studentTable.NewRow();

                            newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", String.Empty);
                            newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", String.Empty);
                            newRow["last_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", String.Empty);
                            newRow["first_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", String.Empty);
                            newRow["middle_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", String.Empty);
                            newRow["course_acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_acronym", String.Empty);
                            newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_description", String.Empty);

                            studentTable.Rows.Add(newRow);
                        }
                    }
                }
            }
            //------------------- end -----------------

            //---------------- query for summer
            dateStart = DateTime.Parse(dateEnd).AddDays(1).ToShortDateString() + " 12:00:00 AM";
            dateEnd = DateTime.Parse("05/31/" + DateTime.Parse(dateStart).Year).ToShortDateString() + " 11:59:59 PM";

            using (RemoteClient.RemCntStudentManager remClient = new RemoteClient.RemCntStudentManager())
            {
                DataTable tempStudTable;
                tempStudTable = remClient.SelectStudentInformation(userInfo, "*", dateStart, dateEnd, String.Empty, String.Empty);

                if (tempStudTable != null)
                {
                    foreach (DataRow studRow in tempStudTable.Rows)
                    {
                        String strFilterDistinct = "sysid_student = '" + RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", String.Empty) + "'";
                        DataRow[] selectRow = studentTable.Select(strFilterDistinct);

                        if (selectRow.Length == 0)
                        {
                            DataRow newRow = studentTable.NewRow();

                            newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", String.Empty);
                            newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", String.Empty);
                            newRow["last_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", String.Empty);
                            newRow["first_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", String.Empty);
                            newRow["middle_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", String.Empty);
                            newRow["course_acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_acronym", String.Empty);
                            newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_description", String.Empty);

                            studentTable.Rows.Add(newRow);
                        }
                    }
                }
            }
            //------------------- end -----------------


            pgbBase.PerformStep();

            pgbBase.Maximum = studentTable.Rows.Count;

            using (RemoteClient.RemCntStudentLoadingManager remClient = new RemoteClient.RemCntStudentLoadingManager())
            {
                Int32 studentCount = 1;
                String studentSysIdList = String.Empty;

                foreach (DataRow studRow in studentTable.Rows)
                {
                    if (studentCount < c_studentCountStudent)
                    {
                        studentSysIdList += RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", String.Empty) + ",";
                    }
                    else if (studentCount == c_studentCountStudent)
                    {
                        studentSysIdList += RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", String.Empty) + ",";

                        if (studentSysIdList.Length > 2)
                        {
                            DataTable tempTable = null;
                            tempTable = remClient.SelectBySysIDStudentListDateEndingAccountReceivablePerFiscalYearStudentLoad(userInfo,
                                studentSysIdList.Remove(studentSysIdList.Length - 1, 1), dateEnd);

                            foreach (DataRow bRow in tempTable.Rows)
                            {
                                if (RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0")) > 0)
                                {
                                    DataRow newRow = studentBalanceTable.NewRow();

                                    newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "sysid_student", String.Empty);
                                    newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0"));

                                    studentBalanceTable.Rows.Add(newRow);
                                }
                            }

                            studentCount = 0;
                            studentSysIdList = String.Empty;
                        }
                    }


                    studentCount++;

                    pgbBase.PerformStep();
                }

                if (!String.IsNullOrEmpty(studentSysIdList))
                {
                    if (studentSysIdList.Length > 2)
                    {
                        DataTable tempTable;
                        tempTable = remClient.SelectBySysIDStudentListDateEndingAccountReceivablePerFiscalYearStudentLoad(userInfo,
                                studentSysIdList.Remove(studentSysIdList.Length - 1, 1), dateEnd);

                        foreach (DataRow bRow in tempTable.Rows)
                        {
                            DataRow newRow = studentBalanceTable.NewRow();

                            newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "sysid_student", String.Empty);
                            newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0"));

                            studentBalanceTable.Rows.Add(newRow);
                        }

                        studentCount = 0;
                        studentSysIdList = String.Empty;
                    }
                }
            }

            pgbBase.PerformStep();

            pgbBase.Value = 0;

            pgbBase.Maximum = studentBalanceTable.Rows.Count;

            if (studentBalanceTable != null)
            {
                foreach (DataRow balanceRow in studentBalanceTable.Rows)
                {
                    String strFilter = "sysid_student = '" + RemoteServerLib.ProcStatic.DataRowConvert(balanceRow, "sysid_student", String.Empty) + "'";
                    DataRow[] selectRow = studentTable.Select(strFilter);

                    foreach (DataRow studRow in selectRow)
                    {
                        if (RemoteServerLib.ProcStatic.DataRowConvert(balanceRow, "amount", Decimal.Parse("0")) > 0)
                        {
                            DataRow newRow = reportTable.NewRow();

                            newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", String.Empty);
                            newRow["name"] = RemoteClient.ProcStatic.GetCompleteNameFullMiddleName(studRow, "last_name", "first_name", "middle_name");
                            newRow["course_level"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_acronym", String.Empty) + " - " +
                                RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_description", String.Empty);
                            newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(balanceRow, "amount", Decimal.Parse("0"));

                            reportTable.Rows.Add(newRow);
                        }
                    }

                    pgbBase.PerformStep();
                }
            }

            if (reportTable.Rows.Count > 0)
            {

                using (ClassCashieringManager.CrystalReport.CrystalStudentBalanceProoflist rptStudentAccountReceivalbe = new
                    FinanceServices.ClassCashieringManager.CrystalReport.CrystalStudentBalanceProoflist())
                {
                    rptStudentAccountReceivalbe.Database.Tables["student_balances_table"].SetDataSource(reportTable);

                    rptStudentAccountReceivalbe.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                    rptStudentAccountReceivalbe.SetParameterValue("@form_name", "Account Receivable - Student Report");
                    rptStudentAccountReceivalbe.SetParameterValue("@school_year_semester", "Fiscal Year " + strFiscalYear);
                    rptStudentAccountReceivalbe.SetParameterValue("@date_printed", "As of " + DateTime.Parse(_serverDateTime).ToLongDateString());
                    rptStudentAccountReceivalbe.SetParameterValue("@print_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
                        DateTime.Parse(_serverDateTime).ToShortTimeString() + "         Printed by: " +
                        RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                        userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));

                    using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptStudentAccountReceivalbe))
                    {
                        frmViewer.Text = "   Account Receivable - Student Per Fiscal Year Report";
                        frmViewer.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("The report is empty.", "Empty Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }//------------------------

        //this procedure will print student accounts receivable per (TERM)
        public void PrintPerTermStudentAccountsReceivable(CommonExchange.SysAccess userInfo, CheckedListBox cbxCourse, CheckedListBox cbxYearlevel,
            ProgressBar pgbBase, String schoolYearSemesterDescription, String dateStart, String dateEnd, String cutOffDate, Boolean isSemestral)
        {
            DataTable studentTable = null;

            DataTable balancesTable = new DataTable("BalancesTable");
            balancesTable.Columns.Add("table_id", System.Type.GetType("System.Int32"));
            balancesTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
			balancesTable.Columns.Add("total_beginning_balance", System.Type.GetType("System.Decimal"));
			balancesTable.Columns.Add("total_tuition", System.Type.GetType("System.Decimal"));
			balancesTable.Columns.Add("total_reimbursement", System.Type.GetType("System.Decimal"));
			balancesTable.Columns.Add("total_discount", System.Type.GetType("System.Decimal"));
			balancesTable.Columns.Add("total_payment", System.Type.GetType("System.Decimal"));
			balancesTable.Columns.Add("total_credit_memo", System.Type.GetType("System.Decimal"));
            balancesTable.Columns.Add("total_ending_balance", System.Type.GetType("System.Decimal"));

            DataTable courseTable = new DataTable("CourseTable");
            courseTable.Columns.Add("course_id", System.Type.GetType("System.String"));
            courseTable.Columns.Add("course_title", System.Type.GetType("System.String"));
            courseTable.Columns.Add("course_acronym", System.Type.GetType("System.String"));
            courseTable.Columns.Add("department_name", System.Type.GetType("System.String"));
            courseTable.Columns.Add("department_acronym", System.Type.GetType("System.String"));

            DataTable yearLevelTable = new DataTable("YearLevelTable");
            yearLevelTable.Columns.Add("year_level_id", System.Type.GetType("System.String"));
            yearLevelTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
            yearLevelTable.Columns.Add("acronym", System.Type.GetType("System.String"));

            DataTable courseLevelTable = new DataTable("CourseLevelTable");
            courseLevelTable.Columns.Add("course_id", System.Type.GetType("System.String"));
            courseLevelTable.Columns.Add("course_title", System.Type.GetType("System.String"));
            courseLevelTable.Columns.Add("year_level_id", System.Type.GetType("System.String"));
            courseLevelTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));

            DataTable printBalancesTable = new DataTable("PrintingBalancesTable");
            printBalancesTable.Columns.Add("no", System.Type.GetType("System.String"));
            printBalancesTable.Columns.Add("student_id", System.Type.GetType("System.String"));
            printBalancesTable.Columns.Add("student_name", System.Type.GetType("System.String"));
            printBalancesTable.Columns.Add("section", System.Type.GetType("System.String"));
            printBalancesTable.Columns.Add("total_beginning_balance", System.Type.GetType("System.Decimal"));
			printBalancesTable.Columns.Add("total_tuition", System.Type.GetType("System.Decimal"));
            printBalancesTable.Columns.Add("total_reimbursement", System.Type.GetType("System.Decimal"));
		    printBalancesTable.Columns.Add("total_discount", System.Type.GetType("System.Decimal"));
		    printBalancesTable.Columns.Add("total_payment", System.Type.GetType("System.Decimal"));
		    printBalancesTable.Columns.Add("total_credit_memo", System.Type.GetType("System.Decimal"));
            printBalancesTable.Columns.Add("total_ending_balance", System.Type.GetType("System.Decimal"));
            printBalancesTable.Columns.Add("course_id", System.Type.GetType("System.String"));
            printBalancesTable.Columns.Add("year_level_id", System.Type.GetType("System.String"));
            
            String courseIdStringFormat = String.Empty;

            if (_classDataSet.Tables["CourseInformationTable"] != null && cbxCourse.CheckedIndices.Count >= 1)
            {
                String strFilterCourse = "is_semestral = " + isSemestral;
                DataRow[] selectRowCourse = _classDataSet.Tables["CourseInformationTable"].Select(strFilterCourse);

                IEnumerator myEnum = cbxCourse.CheckedIndices.GetEnumerator();
                Int32 x;

                while (myEnum.MoveNext() != false)
                {
                    x = (Int32)myEnum.Current;

                    DataRow courseRow = selectRowCourse[x];

                    DataRow newRow = courseTable.NewRow();

                    newRow["course_id"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", "");
                    newRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_title", "");
                    newRow["course_acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_acronym", "");
                    newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "department_name", "");
                    newRow["department_acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "department_acronym", "");

                    courseTable.Rows.Add(newRow);

                    courseIdStringFormat += RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", String.Empty) + ", ";                 
                }

                if (courseIdStringFormat.Length >= 2)
                {
                    courseIdStringFormat = courseIdStringFormat.ToString().Substring(0, courseIdStringFormat.Length - 2);
                }
                else
                {
                    courseIdStringFormat = String.Empty;
                }
            }

            String yearLevelIdStringFormat = String.Empty;

            if (_classDataSet.Tables["YearLevelInformationTable"] != null && cbxYearlevel.CheckedIndices.Count >= 1)
            {
                String strFilterYearLevel = "is_semestral = " + isSemestral;
                DataRow[] selectRowLevel = _classDataSet.Tables["YearLevelInformationTable"].Select(strFilterYearLevel);

                IEnumerator myEnum = cbxYearlevel.CheckedIndices.GetEnumerator();
                Int32 x;

                while (myEnum.MoveNext() != false)
                {
                    x = (Int32)myEnum.Current;

                    DataRow levelRow = selectRowLevel[x];

                    DataRow newRow = yearLevelTable.NewRow();

                    newRow["year_level_id"] = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_id", "");
                    newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_description", "");
                    newRow["acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "acronym", "");

                    yearLevelTable.Rows.Add(newRow);

                    yearLevelIdStringFormat += RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_id", String.Empty) + ", ";
                }

                if (yearLevelIdStringFormat.Length >= 2)
                {
                    yearLevelIdStringFormat = yearLevelIdStringFormat.ToString().Substring(0, yearLevelIdStringFormat.Length - 2);
                }
                else
                {
                    yearLevelIdStringFormat = String.Empty;
                }
            }

            using (RemoteClient.RemCntStudentManager remClient = new RemoteClient.RemCntStudentManager())
            {
                pgbBase.PerformStep();

                studentTable = remClient.SelectStudentInformation(userInfo, "*", dateStart, dateEnd, courseIdStringFormat, yearLevelIdStringFormat);
            }

            pgbBase.Maximum = studentTable.Rows.Count;

            using (RemoteClient.RemCntStudentLoadingManager remClient = new RemoteClient.RemCntStudentLoadingManager())
            {
                if (studentTable != null)
                {
                    Int32 studentCount = 1;
                    String studentSysIdList = String.Empty;

                    foreach (DataRow studRow in studentTable.Rows)
                    {
                        if (studentCount < c_studentCountStudent)
                        {
                            studentSysIdList += RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", String.Empty) + ",";
                        }
                        else
                        {
                            studentSysIdList += RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", String.Empty) + ",";

                            if (studentSysIdList.Length > 2)
                            {
                                DataTable tempTable = null;
                                tempTable =  remClient.SelectBySysIDStudentListDateStartEndCutOffDateAccountReceivablePerTermStudentLoad(userInfo, 
                                    studentSysIdList, dateStart, dateEnd, cutOffDate);

                                foreach (DataRow bRow in tempTable.Rows)
                                {
                                    DataRow newRow = balancesTable.NewRow();

                                    newRow["table_id"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "table_id", Int32.Parse("0"));
                                    newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "sysid_student", String.Empty);
                                    newRow["total_beginning_balance"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "total_beginning_balance", Decimal.Parse("0"));
                                    newRow["total_tuition"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "total_tuition", Decimal.Parse("0"));
                                    newRow["total_reimbursement"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "total_reimbursement", Decimal.Parse("0"));
                                    newRow["total_discount"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "total_discount", Decimal.Parse("0"));
                                    newRow["total_payment"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "total_payment", Decimal.Parse("0"));
                                    newRow["total_credit_memo"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "total_credit_memo", Decimal.Parse("0"));
                                    newRow["total_ending_balance"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "total_ending_balance", Decimal.Parse("0"));

                                    balancesTable.Rows.Add(newRow);
                                    
                                }

                                studentCount = 0;
                                studentSysIdList = String.Empty;
                            }
                        }

                        studentCount++;

                        pgbBase.PerformStep();
                    }

                    if (!String.IsNullOrEmpty(studentSysIdList))
                    {
                        if (studentSysIdList.Length > 2)
                        {
                            DataTable tempTable = null;
                            tempTable = remClient.SelectBySysIDStudentListDateStartEndCutOffDateAccountReceivablePerTermStudentLoad(userInfo,
                                studentSysIdList, dateStart, dateEnd, cutOffDate);

                            foreach (DataRow bRow in tempTable.Rows)
                            {
                                DataRow newRow = balancesTable.NewRow();

                                newRow["table_id"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "table_id", Int32.Parse("0"));
                                newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "sysid_student", String.Empty);
                                newRow["total_beginning_balance"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "total_beginning_balance", Decimal.Parse("0"));
                                newRow["total_tuition"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "total_tuition", Decimal.Parse("0"));
                                newRow["total_reimbursement"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "total_reimbursement", Decimal.Parse("0"));
                                newRow["total_discount"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "total_discount", Decimal.Parse("0"));
                                newRow["total_payment"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "total_payment", Decimal.Parse("0"));
                                newRow["total_credit_memo"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "total_credit_memo", Decimal.Parse("0"));
                                newRow["total_ending_balance"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "total_ending_balance", Decimal.Parse("0"));

                                balancesTable.Rows.Add(newRow);

                            }

                            studentCount = 0;
                            studentSysIdList = String.Empty;
                        }
                    }
                }
            }

            pgbBase.Value = pgbBase.Maximum;

            if (balancesTable != null)
            {
                pgbBase.Value = 0;
                pgbBase.Maximum = studentTable.Rows.Count;

                foreach (DataRow courseRow in courseTable.Rows)
                {
                    foreach (DataRow levelRow in yearLevelTable.Rows)
                    {
                        String strFilter = "course_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", String.Empty) + "' " +
                            "AND year_level_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_id", String.Empty) + "'";
                        DataRow[] selectRow = studentTable.Select(strFilter);

                        if (selectRow.Length > 0)
                        {  
                            Int16 count = 1;

                            foreach (DataRow studRow in selectRow)
                            {
                                String strBalFilter = "sysid_student = '" + RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", String.Empty) + "'";
                                DataRow[] selectStudentBalances = balancesTable.Select(strBalFilter);

                                foreach (DataRow studBalanceRow in selectStudentBalances)
                                {
                                    DataRow newRow = printBalancesTable.NewRow();

                                    newRow["no"] = count.ToString();
                                    newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", String.Empty);
                                    newRow["student_name"] = RemoteClient.ProcStatic.GetCompleteNameFullMiddleName(studRow, "last_name", "first_name", "middle_name");
                                    newRow["section"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "level_section", String.Empty);
                                    newRow["total_beginning_balance"] = RemoteServerLib.ProcStatic.DataRowConvert(studBalanceRow, "total_beginning_balance", Decimal.Parse("0"));
                                    newRow["total_tuition"] = RemoteServerLib.ProcStatic.DataRowConvert(studBalanceRow, "total_tuition", Decimal.Parse("0"));
                                    newRow["total_reimbursement"] = RemoteServerLib.ProcStatic.DataRowConvert(studBalanceRow, "total_reimbursement", Decimal.Parse("0"));
                                    newRow["total_discount"] = RemoteServerLib.ProcStatic.DataRowConvert(studBalanceRow, "total_discount", Decimal.Parse("0"));
                                    newRow["total_payment"] = RemoteServerLib.ProcStatic.DataRowConvert(studBalanceRow, "total_payment", Decimal.Parse("0"));
                                    newRow["total_credit_memo"] = RemoteServerLib.ProcStatic.DataRowConvert(studBalanceRow, "total_credit_memo", Decimal.Parse("0"));
                                    newRow["total_ending_balance"] = RemoteServerLib.ProcStatic.DataRowConvert(studBalanceRow, "total_ending_balance", Decimal.Parse("0"));
                                    newRow["course_id"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", String.Empty);
                                    newRow["year_level_id"] = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_id", String.Empty);

                                    printBalancesTable.Rows.Add(newRow);

                                    count++;
                                }


                                pgbBase.PerformStep();
                            }

                            DataRow newCourseLevelRow = courseLevelTable.NewRow();

                            newCourseLevelRow["course_id"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", String.Empty);
                            newCourseLevelRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_title", String.Empty);
                            newCourseLevelRow["year_level_id"] = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_id", String.Empty);
                            newCourseLevelRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_description", String.Empty);

                            courseLevelTable.Rows.Add(newCourseLevelRow);
                        }
                    }
                }
            }

            if (printBalancesTable.Rows.Count > 0)
            {

                using (ClassCashieringManager.CrystalReport.CrystalStudentAccountsReceivablePerTerm rptStudentAccountReceivalbe = new
                    FinanceServices.ClassCashieringManager.CrystalReport.CrystalStudentAccountsReceivablePerTerm())
                {
                    rptStudentAccountReceivalbe.Database.Tables["course_level_table"].SetDataSource(courseLevelTable);
                    rptStudentAccountReceivalbe.Database.Tables["balances_table"].SetDataSource(printBalancesTable);

                    rptStudentAccountReceivalbe.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                    rptStudentAccountReceivalbe.SetParameterValue("@form_name", "Account Receivable - Student Report");
                    rptStudentAccountReceivalbe.SetParameterValue("@school_year_semester", schoolYearSemesterDescription);
                    rptStudentAccountReceivalbe.SetParameterValue("@cut_off_date", DateTime.Parse(cutOffDate).ToShortDateString());
                    rptStudentAccountReceivalbe.SetParameterValue("@user_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
                        DateTime.Parse(_serverDateTime).ToShortTimeString() + "         Printed by: " +
                        RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                        userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));

                    using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptStudentAccountReceivalbe))
                    {
                        frmViewer.Text = "   Account Receivable - Student Per Term Report";
                        frmViewer.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("The report is empty.", "Empty Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }//------------------------

        //this procedure will print student balances prooflist
        public void PrintStudetBalanceProoflist(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd, String dateEnding, 
            String strSchoolYearSemester, Boolean isQueryAll, ProgressBar pgbBase)
        {
            DataTable studentTable;
            DataTable studentBalanceTable = new DataTable("StudentBalancesTable");
            studentBalanceTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            studentBalanceTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));

            DataTable reportTable = new DataTable("CreditMemoReportTable");
            reportTable.Columns.Add("student_id", System.Type.GetType("System.String"));
            reportTable.Columns.Add("name", System.Type.GetType("System.String"));
            reportTable.Columns.Add("course_level", System.Type.GetType("System.String"));
            reportTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));

            pgbBase.PerformStep();

            using (RemoteClient.RemCntStudentManager remClient = new RemoteClient.RemCntStudentManager())
            {
                if (!isQueryAll)
                {
                    studentTable = remClient.SelectStudentInformation(userInfo, "*", dateStart, dateEnd, String.Empty, String.Empty);
                }
                else
                {
                    studentTable = remClient.SelectStudentInformation(userInfo, "*", String.Empty, String.Empty, String.Empty, String.Empty);
                }

            }

            pgbBase.PerformStep();

            pgbBase.Maximum = studentTable.Rows.Count;

            using (RemoteClient.RemCntStudentLoadingManager remClient = new RemoteClient.RemCntStudentLoadingManager())
            {
                Int32 studentCount = 1;
                String studentSysIdList = String.Empty;

                foreach (DataRow studRow in studentTable.Rows)
                {
                    if (studentCount < c_studentCountStudent)
                    {
                        studentSysIdList += RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", String.Empty) + ",";
                    }
                    else if (studentCount == c_studentCountStudent)
                    {
                        studentSysIdList += RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", String.Empty) + ",";

                        if (studentSysIdList.Length > 2)
                        {
                            DataTable tempTable;
                            tempTable = remClient.SelectBySysIDStudentListDateEndingBalanceCarriedForwardStudentLoad(userInfo,
                                studentSysIdList.Remove(studentSysIdList.Length - 1, 1), String.Empty, dateEnding);

                            foreach (DataRow bRow in tempTable.Rows)
                            {
                                if (RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0")) > 0)
                                {
                                    DataRow newRow = studentBalanceTable.NewRow();

                                    newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "sysid_student", String.Empty);
                                    newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0"));

                                    studentBalanceTable.Rows.Add(newRow);
                                }
                            }

                            studentCount = 0;
                            studentSysIdList = String.Empty;
                        }
                    }


                    studentCount++;

                    pgbBase.PerformStep();
                }

                if (!String.IsNullOrEmpty(studentSysIdList))
                {
                    if (studentSysIdList.Length > 2)
                    {
                        DataTable tempTable;
                        tempTable = remClient.SelectBySysIDStudentListDateEndingBalanceCarriedForwardStudentLoad(userInfo,
                            studentSysIdList.Remove(studentSysIdList.Length - 1, 1), String.Empty, dateEnding);

                        foreach (DataRow bRow in tempTable.Rows)
                        {
                            DataRow newRow = studentBalanceTable.NewRow();

                            newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "sysid_student", String.Empty);
                            newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0"));

                            studentBalanceTable.Rows.Add(newRow);
                        }

                        studentCount = 0;
                        studentSysIdList = String.Empty;
                    }
                }
            }

            pgbBase.PerformStep();

            pgbBase.Value = 0;

            pgbBase.Maximum = studentBalanceTable.Rows.Count;

            if (studentBalanceTable != null)
            {
                foreach (DataRow balanceRow in studentBalanceTable.Rows)
                {
                    String strFilter = "sysid_student = '" + RemoteServerLib.ProcStatic.DataRowConvert(balanceRow, "sysid_student", String.Empty) + "'";
                    DataRow[] selectRow = studentTable.Select(strFilter);

                    foreach (DataRow studRow in selectRow)
                    {
                        if (RemoteServerLib.ProcStatic.DataRowConvert(balanceRow, "amount", Decimal.Parse("0")) > 0)
                        {
                            DataRow newRow = reportTable.NewRow();

                            newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", String.Empty);
                            newRow["name"] = RemoteClient.ProcStatic.GetCompleteNameFullMiddleName(studRow, "last_name", "first_name", "middle_name");
                            newRow["course_level"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_acronym", String.Empty) + " - " +
                                RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_description", String.Empty);
                            newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(balanceRow, "amount", Decimal.Parse("0"));

                            reportTable.Rows.Add(newRow);
                        }
                    }

                    pgbBase.PerformStep();
                }
            }

            if (reportTable.Rows.Count > 0)
            {

                using (ClassCashieringManager.CrystalReport.CrystalStudentBalanceProoflist rptStudentBalanceProoflist = new
                    FinanceServices.ClassCashieringManager.CrystalReport.CrystalStudentBalanceProoflist())
                {
                    rptStudentBalanceProoflist.Database.Tables["student_balances_table"].SetDataSource(reportTable);

                    rptStudentBalanceProoflist.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                    rptStudentBalanceProoflist.SetParameterValue("@form_name", "Student Balances Prooflist");
                    rptStudentBalanceProoflist.SetParameterValue("@school_year_semester", strSchoolYearSemester);
                    rptStudentBalanceProoflist.SetParameterValue("@date_printed", String.Empty);
                    rptStudentBalanceProoflist.SetParameterValue("@print_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
                        DateTime.Parse(_serverDateTime).ToShortTimeString() + "         Printed by: " +
                        RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                        userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));

                    using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptStudentBalanceProoflist))
                    {
                        frmViewer.Text = "   Student Balances Prooflist";
                        frmViewer.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("The report is empty.", "Empty Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }//------------------------

        //this procedure will print Fees Register (Detailed)
        public void PrintFeesRegisterDetailed(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd, String strSchoolYearSemester,
            Boolean isSemestral, CheckedListBox cbxCourse, CheckedListBox cbxYearlevel, ProgressBar pgbBase)
        {
            DataTable studentTable;
            DataTable schoolFeeDetailTable;

            DataTable courseTable = new DataTable("CourseTable");
            courseTable.Columns.Add("course_id", System.Type.GetType("System.String"));
            courseTable.Columns.Add("course_title", System.Type.GetType("System.String"));
            courseTable.Columns.Add("course_acronym", System.Type.GetType("System.String"));
            courseTable.Columns.Add("department_name", System.Type.GetType("System.String"));
            courseTable.Columns.Add("department_acronym", System.Type.GetType("System.String"));

            DataTable yearLevelTable = new DataTable("YearLevelTable");
            yearLevelTable.Columns.Add("year_level_id", System.Type.GetType("System.String"));
            yearLevelTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
            yearLevelTable.Columns.Add("acronym", System.Type.GetType("System.String"));
            yearLevelTable.Columns.Add("sysid_no_of_students", System.Type.GetType("System.String"));

            DataTable feeRegisterTable = new DataTable("SchoolFeeTable");
            feeRegisterTable.Columns.Add("page_id", System.Type.GetType("System.Int32"));
            feeRegisterTable.Columns.Add("no", System.Type.GetType("System.String"));
            feeRegisterTable.Columns.Add("student_id", System.Type.GetType("System.String"));
            feeRegisterTable.Columns.Add("student_name", System.Type.GetType("System.String"));
            feeRegisterTable.Columns.Add("total", System.Type.GetType("System.Decimal"));
            feeRegisterTable.Columns.Add("col_1", System.Type.GetType("System.Decimal"));
            feeRegisterTable.Columns.Add("col_2", System.Type.GetType("System.Decimal"));
            feeRegisterTable.Columns.Add("col_3", System.Type.GetType("System.Decimal"));
            feeRegisterTable.Columns.Add("col_4", System.Type.GetType("System.Decimal"));
            feeRegisterTable.Columns.Add("col_5", System.Type.GetType("System.Decimal"));
            feeRegisterTable.Columns.Add("col_6", System.Type.GetType("System.Decimal"));
            feeRegisterTable.Columns.Add("col_7", System.Type.GetType("System.Decimal"));
            feeRegisterTable.Columns.Add("col_8", System.Type.GetType("System.Decimal"));
            feeRegisterTable.Columns.Add("col_9", System.Type.GetType("System.Decimal"));
            feeRegisterTable.Columns.Add("col_10", System.Type.GetType("System.Decimal"));

            DataTable pageTable = new DataTable("PageTable");
            pageTable.Columns.Add("page_id", System.Type.GetType("System.Int32"));
            pageTable.Columns.Add("page_description", System.Type.GetType("System.String"));
            pageTable.Columns.Add("course_title", System.Type.GetType("System.String"));
            pageTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
            pageTable.Columns.Add("student_id", System.Type.GetType("System.String"));
            pageTable.Columns.Add("student_name", System.Type.GetType("System.String"));
            pageTable.Columns.Add("total", System.Type.GetType("System.String"));
            pageTable.Columns.Add("col_1", System.Type.GetType("System.String"));
            pageTable.Columns.Add("col_2", System.Type.GetType("System.String"));
            pageTable.Columns.Add("col_3", System.Type.GetType("System.String"));
            pageTable.Columns.Add("col_4", System.Type.GetType("System.String"));
            pageTable.Columns.Add("col_5", System.Type.GetType("System.String"));
            pageTable.Columns.Add("col_6", System.Type.GetType("System.String"));
            pageTable.Columns.Add("col_7", System.Type.GetType("System.String"));
            pageTable.Columns.Add("col_8", System.Type.GetType("System.String"));
            pageTable.Columns.Add("col_9", System.Type.GetType("System.String"));
            pageTable.Columns.Add("col_10", System.Type.GetType("System.String"));

            String courseIdStringFormat = String.Empty;

            if (_classDataSet.Tables["CourseInformationTable"] != null && cbxCourse.CheckedIndices.Count >= 1)
            {
                String strFilterCourse = "is_semestral = " + isSemestral;
                DataRow[] selectRowCourse = _classDataSet.Tables["CourseInformationTable"].Select(strFilterCourse);

                IEnumerator myEnum = cbxCourse.CheckedIndices.GetEnumerator();
                Int32 x;

                while (myEnum.MoveNext() != false)
                {
                    x = (Int32)myEnum.Current;

                    DataRow courseRow = selectRowCourse[x];

                    DataRow newRow = courseTable.NewRow();

                    newRow["course_id"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", "");
                    newRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_title", "");
                    newRow["course_acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_acronym", "");
                    newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "department_name", "");
                    newRow["department_acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "department_acronym", "");

                    courseTable.Rows.Add(newRow);

                    courseIdStringFormat += RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", String.Empty) + ", ";

                    pgbBase.PerformStep();
                }

                if (courseIdStringFormat.Length >= 2)
                {
                    courseIdStringFormat = courseIdStringFormat.ToString().Substring(0, courseIdStringFormat.Length - 2);
                }
                else
                {
                    courseIdStringFormat = String.Empty;
                }
            }

            String yearLevelIdStringFormat = String.Empty;

            if (_classDataSet.Tables["YearLevelInformationTable"] != null && cbxYearlevel.CheckedIndices.Count >= 1)
            {
                String strFilterYearLevel = "is_semestral = " + isSemestral;
                DataRow[] selectRowLevel = _classDataSet.Tables["YearLevelInformationTable"].Select(strFilterYearLevel);

                IEnumerator myEnum = cbxYearlevel.CheckedIndices.GetEnumerator();
                Int32 x;

                while (myEnum.MoveNext() != false)
                {
                    x = (Int32)myEnum.Current;

                    DataRow levelRow = selectRowLevel[x];

                    DataRow newRow = yearLevelTable.NewRow();

                    newRow["year_level_id"] = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_id", "");
                    newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_description", "");
                    newRow["acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "acronym", "");

                    yearLevelTable.Rows.Add(newRow);

                    yearLevelIdStringFormat += RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_id", String.Empty) + ", ";

                    pgbBase.PerformStep();
                }

                if (yearLevelIdStringFormat.Length >= 2)
                {
                    yearLevelIdStringFormat = yearLevelIdStringFormat.ToString().Substring(0, yearLevelIdStringFormat.Length - 2);
                }
                else
                {
                    yearLevelIdStringFormat = String.Empty;
                }
            }

            using (RemoteClient.RemCntStudentManager remClient = new RemoteClient.RemCntStudentManager())
            {
                pgbBase.PerformStep();

                studentTable = remClient.SelectStudentInformation(userInfo, "*", dateStart, dateEnd, courseIdStringFormat, yearLevelIdStringFormat);

                pgbBase.PerformStep();
            }

            using (RemoteClient.RemCntStudentLoadingManager remClient = new RemoteClient.RemCntStudentLoadingManager())
            {
                pgbBase.PerformStep();

                schoolFeeDetailTable = remClient.SelectBySysIDStudentEnrolmentLevelListSchoolFeeDetailsStudentLoad(userInfo,
                    this.GetStudentEnrolmentLevelSystemIdFormat(studentTable, true),
                    this.GetStudentEnrolmentLevelSystemIdFormat(studentTable, false));

                pgbBase.PerformStep();
            }

            pgbBase.PerformStep();

            this.EditSchoolFeeDetailsTable(ref schoolFeeDetailTable, studentTable, true);

            pgbBase.PerformStep();

            pgbBase.Maximum = _classDataSet.Tables["SchoolFeeParticularTable"].Rows.Count;

            Int32 pageId = 1;

            if (courseTable != null && yearLevelTable != null)
            {
                foreach (DataRow courseRow in courseTable.Rows)
                {   
                    foreach (DataRow yearLevelRow in yearLevelTable.Rows)
                    {
                        String col1 = String.Empty, col2 = String.Empty, col3 = String.Empty, col4 = String.Empty, col5 = String.Empty,
                            col6 = String.Empty, col7 = String.Empty, col8 = String.Empty, col9 = String.Empty, col10 = String.Empty;

                        Int32 pageNumber = 1, partNumber = 1, studentCount = 1;

                        String strFilterNoOfStudent = "course_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", String.Empty) +
                            "' AND year_level_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(yearLevelRow, "year_level_id", String.Empty) + "'";

                        //DataTable tempFeeDetailsTable = schoolFeeDetailTable.DefaultView.ToTable(true, 
                        //    new String[3] { "sysid_student", "course_id", "year_level_id" });
                        //DataRow[] selectStudentCourseYearLevel = tempFeeDetailsTable.Select(strFilterNoOfStudent);

                        DataRow[] selectStudentCourseYearLevel = studentTable.Select(strFilterNoOfStudent);

                        Int32 countParticular = 1;

                        DataRow[] sortParticularTable = _classDataSet.Tables["SchoolFeeParticularTable"].Select(String.Empty, "category_no ASC");

                        foreach (DataRow feeParticularRow in sortParticularTable)
                        {
                            pgbBase.PerformStep();

                            String strFilterParticularExist = "course_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", String.Empty) +
                                "' AND year_level_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(yearLevelRow, "year_level_id", String.Empty) + 
                                "' AND sysid_feeparticular = '" + RemoteServerLib.ProcStatic.DataRowConvert(feeParticularRow, "sysid_feeparticular", String.Empty) + "'";
                            DataRow[] selectParticularExist = schoolFeeDetailTable.Select(strFilterParticularExist);

                            if (selectParticularExist.Length > 0)
                            {
                                if (countParticular == 1)
                                {
                                    col1 = RemoteServerLib.ProcStatic.DataRowConvert(feeParticularRow, "sysid_feeparticular", String.Empty);
                                }
                                else if (countParticular == 2)
                                {
                                    col2 = RemoteServerLib.ProcStatic.DataRowConvert(feeParticularRow, "sysid_feeparticular", String.Empty);
                                }
                                else if (countParticular == 3)
                                {
                                    col3 = RemoteServerLib.ProcStatic.DataRowConvert(feeParticularRow, "sysid_feeparticular", String.Empty);
                                }
                                else if (countParticular == 4)
                                {
                                    col4 = RemoteServerLib.ProcStatic.DataRowConvert(feeParticularRow, "sysid_feeparticular", String.Empty);
                                }
                                else if (countParticular == 5)
                                {
                                    col5 = RemoteServerLib.ProcStatic.DataRowConvert(feeParticularRow, "sysid_feeparticular", String.Empty);
                                }
                                else if (countParticular == 6)
                                {
                                    col6 = RemoteServerLib.ProcStatic.DataRowConvert(feeParticularRow, "sysid_feeparticular", String.Empty);
                                }
                                else if (countParticular == 7)
                                {
                                    col7 = RemoteServerLib.ProcStatic.DataRowConvert(feeParticularRow, "sysid_feeparticular", String.Empty);
                                }
                                else if (countParticular == 8)
                                {
                                    col8 = RemoteServerLib.ProcStatic.DataRowConvert(feeParticularRow, "sysid_feeparticular", String.Empty);
                                }
                                else if (countParticular == 9)
                                {
                                    col9 = RemoteServerLib.ProcStatic.DataRowConvert(feeParticularRow, "sysid_feeparticular", String.Empty);
                                }
                                else if (countParticular == 10)
                                {
                                    col10 = RemoteServerLib.ProcStatic.DataRowConvert(feeParticularRow, "sysid_feeparticular", String.Empty);

                                    pageNumber = 1;

                                    this.GenerateTableForFeeRegisterDetaild(ref pageTable, ref feeRegisterTable, studentTable, schoolFeeDetailTable,
                                        selectStudentCourseYearLevel, courseRow, yearLevelRow, ref pageId, ref pageNumber, ref partNumber, ref studentCount,
                                        ref col1, ref col2, ref col3, ref col4, ref col5, ref col6, ref col7, ref col8, ref col9, ref col10, isSemestral);

                                    col1 = col2 = col3 = col4 = col5 = col6 = col7 = col8 = col9 = col10 = String.Empty;

                                    pageId++;
                                    countParticular = 0;
                                    studentCount = 1;
                                    partNumber++;
                                }

                                countParticular++;
                            }
                        }// end loop school fee particular

                        if (!String.IsNullOrEmpty(col1) || !String.IsNullOrEmpty(col2) || !String.IsNullOrEmpty(col3) || !String.IsNullOrEmpty(col4) ||
                            !String.IsNullOrEmpty(col5) || !String.IsNullOrEmpty(col6) || !String.IsNullOrEmpty(col7) || !String.IsNullOrEmpty(col8) ||
                            !String.IsNullOrEmpty(col9) ||!String.IsNullOrEmpty(col1))
                        {
                            pageNumber = 1;

                            this.GenerateTableForFeeRegisterDetaild(ref pageTable, ref feeRegisterTable, studentTable, schoolFeeDetailTable,
                                        selectStudentCourseYearLevel, courseRow, yearLevelRow, ref pageId, ref pageNumber, ref partNumber, ref studentCount,
                                        ref col1, ref col2, ref col3, ref col4, ref col5, ref col6, ref col7, ref col8, ref col9, ref col10, isSemestral);

                            col1 = col2 = col3 = col4 = col5 = col6 = col7 = col8 = col9 = col10 = String.Empty;

                            pageId++;
                        }                       
                    }
                }
            }

            if (pageTable.Rows.Count > 0)
            {

                using (ClassCashieringManager.CrystalReport.CrystalFeeRegisterDetailed rptFeeRegisterDetailed = new
                    FinanceServices.ClassCashieringManager.CrystalReport.CrystalFeeRegisterDetailed())
                {
                    rptFeeRegisterDetailed.Database.Tables["fee_register_table_details"].SetDataSource(feeRegisterTable);
                    rptFeeRegisterDetailed.Database.Tables["page_table"].SetDataSource(pageTable);

                    rptFeeRegisterDetailed.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                    rptFeeRegisterDetailed.SetParameterValue("@form_name", "Fee Register (Detailed)");
                    rptFeeRegisterDetailed.SetParameterValue("@school_year_semester", strSchoolYearSemester);
                    rptFeeRegisterDetailed.SetParameterValue("@print_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
                        DateTime.Parse(_serverDateTime).ToShortTimeString() + "         Printed by: " +
                        RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                        userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));

                    using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptFeeRegisterDetailed))
                    {
                        frmViewer.Text = "   Fee Register (Detailed)";
                        frmViewer.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("The report is empty.", "Empty Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }//---------------------------

        //this procedure will generate report of fee register detaild
        private void GenerateTableForFeeRegisterDetaild(ref DataTable pageTable, ref DataTable feeRegisterTable, DataTable studentTable,
            DataTable schoolFeeDetailTable, DataRow[] selectStudentCourseYearLevel, DataRow courseRow, DataRow yearLevelRow,
            ref Int32 pageId, ref Int32 pageNumber, ref Int32 partNumber, ref Int32 studentCount, 
            ref String col1, ref String col2, ref String col3, ref String col4, ref String col5, ref String col6, ref String col7, ref String
            col8, ref String col9, ref String col10, Boolean isSemestral)
        {
            DataRow newPageRow = pageTable.NewRow();

            newPageRow["page_id"] = pageId;
            newPageRow["page_description"] = "Page " + pageNumber.ToString() + "    Part " + partNumber.ToString();
            newPageRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_title", String.Empty);
            newPageRow["year_level_description"] =
                RemoteServerLib.ProcStatic.DataRowConvert(yearLevelRow, "year_level_description", String.Empty);
            newPageRow["student_id"] = "ID";
            newPageRow["student_name"] = "Student's Name";
            newPageRow["total"] = "Total A/R";
            newPageRow["col_1"] = this.GetFeeParticularDescription(col1);
            newPageRow["col_2"] = this.GetFeeParticularDescription(col2);
            newPageRow["col_3"] = this.GetFeeParticularDescription(col3);
            newPageRow["col_4"] = this.GetFeeParticularDescription(col4);
            newPageRow["col_5"] = this.GetFeeParticularDescription(col5);
            newPageRow["col_6"] = this.GetFeeParticularDescription(col6);
            newPageRow["col_7"] = this.GetFeeParticularDescription(col7);
            newPageRow["col_8"] = this.GetFeeParticularDescription(col8);
            newPageRow["col_9"] = this.GetFeeParticularDescription(col9);
            newPageRow["col_10"] = this.GetFeeParticularDescription(col10);

            pageTable.Rows.Add(newPageRow);

            Int32 addStudent = 1;

            foreach (DataRow studentFeeRow in selectStudentCourseYearLevel)
            {
                if (addStudent <= 40)
                {
                    DataRow newDetailsRow = feeRegisterTable.NewRow();

                    newDetailsRow["page_id"] = pageId;
                    newDetailsRow["no"] = studentCount.ToString();
                    newDetailsRow["student_id"] = this.GetStudentCompleteNameID(studentTable,
                        RemoteServerLib.ProcStatic.DataRowConvert(studentFeeRow, "sysid_student", String.Empty), false);
                    newDetailsRow["student_name"] = this.GetStudentCompleteNameID(studentTable,
                        RemoteServerLib.ProcStatic.DataRowConvert(studentFeeRow, "sysid_student", String.Empty), true);
                    newDetailsRow["col_1"] = this.GetStudentFeePraticularAmount(schoolFeeDetailTable,
                        RemoteServerLib.ProcStatic.DataRowConvert(studentFeeRow, "sysid_student", String.Empty), col1, isSemestral);
                    newDetailsRow["col_2"] = this.GetStudentFeePraticularAmount(schoolFeeDetailTable,
                        RemoteServerLib.ProcStatic.DataRowConvert(studentFeeRow, "sysid_student", String.Empty), col2, isSemestral);
                    newDetailsRow["col_3"] = this.GetStudentFeePraticularAmount(schoolFeeDetailTable,
                        RemoteServerLib.ProcStatic.DataRowConvert(studentFeeRow, "sysid_student", String.Empty), col3, isSemestral);
                    newDetailsRow["col_4"] = this.GetStudentFeePraticularAmount(schoolFeeDetailTable,
                        RemoteServerLib.ProcStatic.DataRowConvert(studentFeeRow, "sysid_student", String.Empty), col4, isSemestral);
                    newDetailsRow["col_5"] = this.GetStudentFeePraticularAmount(schoolFeeDetailTable,
                        RemoteServerLib.ProcStatic.DataRowConvert(studentFeeRow, "sysid_student", String.Empty), col5, isSemestral);
                    newDetailsRow["col_6"] = this.GetStudentFeePraticularAmount(schoolFeeDetailTable,
                        RemoteServerLib.ProcStatic.DataRowConvert(studentFeeRow, "sysid_student", String.Empty), col6, isSemestral);
                    newDetailsRow["col_7"] = this.GetStudentFeePraticularAmount(schoolFeeDetailTable,
                        RemoteServerLib.ProcStatic.DataRowConvert(studentFeeRow, "sysid_student", String.Empty), col7, isSemestral);
                    newDetailsRow["col_8"] = this.GetStudentFeePraticularAmount(schoolFeeDetailTable,
                        RemoteServerLib.ProcStatic.DataRowConvert(studentFeeRow, "sysid_student", String.Empty), col8, isSemestral);
                    newDetailsRow["col_9"] = this.GetStudentFeePraticularAmount(schoolFeeDetailTable,
                        RemoteServerLib.ProcStatic.DataRowConvert(studentFeeRow, "sysid_student", String.Empty), col9, isSemestral);
                    newDetailsRow["col_10"] = this.GetStudentFeePraticularAmount(schoolFeeDetailTable,
                        RemoteServerLib.ProcStatic.DataRowConvert(studentFeeRow, "sysid_student", String.Empty), col10, isSemestral);
                    newDetailsRow["total"] = ((Decimal)newDetailsRow["col_1"] + (Decimal)newDetailsRow["col_2"] +
                        (Decimal)newDetailsRow["col_3"] + (Decimal)newDetailsRow["col_4"] + (Decimal)newDetailsRow["col_5"] +
                        (Decimal)newDetailsRow["col_6"] + (Decimal)newDetailsRow["col_7"] + (Decimal)newDetailsRow["col_8"] +
                        (Decimal)newDetailsRow["col_9"] + (Decimal)newDetailsRow["col_10"]).ToString();

                    feeRegisterTable.Rows.Add(newDetailsRow);

                    if (addStudent == 40)
                    {
                        pageId++;
                        pageNumber++;

                        DataRow pageRow = pageTable.NewRow();

                        pageRow["page_id"] = pageId;
                        pageRow["page_description"] = "Page " + pageNumber.ToString() + "    Part " + partNumber.ToString();
                        pageRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_title", String.Empty);
                        pageRow["year_level_description"] =
                            RemoteServerLib.ProcStatic.DataRowConvert(yearLevelRow, "year_level_description", String.Empty);
                        pageRow["student_id"] = "ID";
                        pageRow["student_name"] = "Student's Name";
                        pageRow["total"] = "Total A/R";
                        pageRow["col_1"] = this.GetFeeParticularDescription(col1);
                        pageRow["col_2"] = this.GetFeeParticularDescription(col2);
                        pageRow["col_3"] = this.GetFeeParticularDescription(col3);
                        pageRow["col_4"] = this.GetFeeParticularDescription(col4);
                        pageRow["col_5"] = this.GetFeeParticularDescription(col5);
                        pageRow["col_6"] = this.GetFeeParticularDescription(col6);
                        pageRow["col_7"] = this.GetFeeParticularDescription(col7);
                        pageRow["col_8"] = this.GetFeeParticularDescription(col8);
                        pageRow["col_9"] = this.GetFeeParticularDescription(col9);
                        pageRow["col_10"] = this.GetFeeParticularDescription(col10);

                        pageTable.Rows.Add(pageRow);

                        addStudent = 1;
                    }
                }

                addStudent++;
                studentCount++;
            }
        }//---------------------------

        //this procedure will print Fees Register (Summarized)
        public void PrintFeeRegisterSummarized(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd, String strSchoolYearSemester,
            Boolean isSemestral, CheckedListBox cbxCourseGroup, ProgressBar pgbBase)
        {
            DataTable studentTable;

            DataTable schoolFeeDetailTable = new DataTable("SchoolFeeDetailsTable");
            schoolFeeDetailTable.Columns.Add("table_id", System.Type.GetType("System.Int32"));
            schoolFeeDetailTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            schoolFeeDetailTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));
            schoolFeeDetailTable.Columns.Add("sysid_feedetails", System.Type.GetType("System.String"));
            schoolFeeDetailTable.Columns.Add("sysid_feeparticular", System.Type.GetType("System.String"));
            schoolFeeDetailTable.Columns.Add("is_level_increase", System.Type.GetType("System.Boolean"));
            schoolFeeDetailTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));
            schoolFeeDetailTable.Columns.Add("fee_category_id", System.Type.GetType("System.String"));
            schoolFeeDetailTable.Columns.Add("category_description", System.Type.GetType("System.String"));
            schoolFeeDetailTable.Columns.Add("particular_description", System.Type.GetType("System.String"));
            schoolFeeDetailTable.Columns.Add("is_office_access", System.Type.GetType("System.Boolean"));
            schoolFeeDetailTable.Columns.Add("category_no", System.Type.GetType("System.String"));
            schoolFeeDetailTable.Columns.Add("additional_fee_id", System.Type.GetType("System.Int64"));
            schoolFeeDetailTable.Columns.Add("optional_fee_id", System.Type.GetType("System.Int64"));
            schoolFeeDetailTable.Columns.Add("is_additional_fee", System.Type.GetType("System.Boolean"));
            schoolFeeDetailTable.Columns.Add("is_optional_fee", System.Type.GetType("System.Boolean"));
            schoolFeeDetailTable.Columns.Add("is_per_year_tuition_fee", System.Type.GetType("System.Boolean"));
            schoolFeeDetailTable.Columns.Add("is_per_unit_tuition_fee", System.Type.GetType("System.Boolean"));
            schoolFeeDetailTable.Columns.Add("is_fixed_amount_tuition_fee", System.Type.GetType("System.Boolean"));
            schoolFeeDetailTable.Columns.Add("is_special_class_tuition_fee", System.Type.GetType("System.Boolean"));
            schoolFeeDetailTable.Columns.Add("international_percentage", System.Type.GetType("System.Single"));

            DataTable courseGroupTable = new DataTable("CourseGroupTable");
            courseGroupTable.Columns.Add("group_no", System.Type.GetType("System.String"));
            courseGroupTable.Columns.Add("group_description", System.Type.GetType("System.String"));

            DataTable schoolFeeTable = new DataTable("SchoolFeeTable");
            schoolFeeTable.Columns.Add("group_no", System.Type.GetType("System.String"));
            schoolFeeTable.Columns.Add("particular_description", System.Type.GetType("System.String"));
            schoolFeeTable.Columns.Add("total", System.Type.GetType("System.Decimal"));
            schoolFeeTable.Columns.Add("col_1", System.Type.GetType("System.Decimal"));
            schoolFeeTable.Columns.Add("col_2", System.Type.GetType("System.Decimal"));
            schoolFeeTable.Columns.Add("col_3", System.Type.GetType("System.Decimal"));
            schoolFeeTable.Columns.Add("col_4", System.Type.GetType("System.Decimal"));
            schoolFeeTable.Columns.Add("col_5", System.Type.GetType("System.Decimal"));
            schoolFeeTable.Columns.Add("col_6", System.Type.GetType("System.Decimal"));
            schoolFeeTable.Columns.Add("col_7", System.Type.GetType("System.Decimal"));
            schoolFeeTable.Columns.Add("col_8", System.Type.GetType("System.Decimal"));
            schoolFeeTable.Columns.Add("col_9", System.Type.GetType("System.Decimal"));

            using (RemoteClient.RemCntStudentManager remClient = new RemoteClient.RemCntStudentManager())
            {
                pgbBase.PerformStep();

                studentTable = remClient.SelectStudentInformation(userInfo, "*", dateStart, dateEnd, String.Empty, String.Empty);

                pgbBase.PerformStep();
            }

            pgbBase.Maximum = studentTable.Rows.Count + _classDataSet.Tables["CourseGroupTable"].Rows.Count;            

            using (RemoteClient.RemCntStudentLoadingManager remClient = new RemoteClient.RemCntStudentLoadingManager())
            {
                if (studentTable != null)
                {
                    Int32 studentCount = 1;
                    String studentSysIdList = String.Empty;
                    String enrolmentLevelSysIdList = String.Empty;

                    foreach (DataRow studRow in studentTable.Rows)
                    {
                        if (studentCount < c_studentCountStudent)
                        {
                            studentSysIdList += RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", String.Empty) + ",";
                            enrolmentLevelSysIdList += RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", String.Empty) + ",";
                        }
                        else
                        {
                            studentSysIdList += RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", String.Empty) + ",";
                            enrolmentLevelSysIdList += RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", String.Empty) + ",";

                            if (studentSysIdList.Length > 2 && enrolmentLevelSysIdList.Length > 2)
                            {
                                DataTable tempTable = null;
                                tempTable = remClient.SelectBySysIDStudentEnrolmentLevelListSchoolFeeDetailsStudentLoad(userInfo, studentSysIdList, enrolmentLevelSysIdList);

                                foreach (DataRow bRow in tempTable.Rows)
                                {
                                    DataRow newRow = schoolFeeDetailTable.NewRow();

                                    newRow["table_id"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "table_id", Int32.Parse("0"));
                                    newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "sysid_student", String.Empty);
                                    newRow["sysid_enrolmentlevel"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "sysid_enrolmentlevel", String.Empty);
                                    newRow["sysid_feedetails"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "sysid_feedetails", String.Empty);
                                    newRow["sysid_feeparticular"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "sysid_feeparticular", String.Empty);
                                    newRow["is_level_increase"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "is_level_increase", false);
                                    newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0"));
                                    newRow["fee_category_id"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "fee_category_id", String.Empty);
                                    newRow["category_description"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "category_description", String.Empty);
                                    newRow["particular_description"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "particular_description", String.Empty);
                                    newRow["is_office_access"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "is_office_access", false);
                                    newRow["category_no"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "category_no", String.Empty);
                                    newRow["additional_fee_id"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "additional_fee_id", Int64.Parse("0"));
                                    newRow["optional_fee_id"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "optional_fee_id", Int64.Parse("0"));
                                    newRow["is_additional_fee"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "is_additional_fee", false);
                                    newRow["is_optional_fee"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "is_optional_fee", false);
                                    newRow["is_per_year_tuition_fee"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "is_per_year_tuition_fee", false);
                                    newRow["is_per_unit_tuition_fee"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "is_per_unit_tuition_fee", false);
                                    newRow["is_fixed_amount_tuition_fee"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "is_fixed_amount_tuition_fee", false);
                                    newRow["is_special_class_tuition_fee"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "is_special_class_tuition_fee", false);
                                    newRow["international_percentage"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "international_percentage", Single.Parse("0"));

                                    schoolFeeDetailTable.Rows.Add(newRow);

                                }

                                studentCount = 0;
                                studentSysIdList = String.Empty;
                                enrolmentLevelSysIdList = String.Empty;
                            }
                        }

                        studentCount++;

                        pgbBase.PerformStep();
                    }

                    if (!String.IsNullOrEmpty(studentSysIdList) && !String.IsNullOrEmpty(enrolmentLevelSysIdList))
                    {
                        if (studentSysIdList.Length > 2 && enrolmentLevelSysIdList.Length > 2)
                        {
                            DataTable tempTable = null;
                            tempTable = remClient.SelectBySysIDStudentEnrolmentLevelListSchoolFeeDetailsStudentLoad(userInfo, studentSysIdList, enrolmentLevelSysIdList);

                            foreach (DataRow bRow in tempTable.Rows)
                            {
                                DataRow newRow = schoolFeeDetailTable.NewRow();

                                newRow["table_id"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "table_id", Int32.Parse("0"));
                                newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "sysid_student", String.Empty);
                                newRow["sysid_enrolmentlevel"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "sysid_enrolmentlevel", String.Empty);
                                newRow["sysid_feedetails"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "sysid_feedetails", String.Empty);
                                newRow["sysid_feeparticular"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "sysid_feeparticular", String.Empty);
                                newRow["is_level_increase"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "is_level_increase", false);
                                newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0"));
                                newRow["fee_category_id"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "fee_category_id", String.Empty);
                                newRow["category_description"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "category_description", String.Empty);
                                newRow["particular_description"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "particular_description", String.Empty);
                                newRow["is_office_access"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "is_office_access", false);
                                newRow["category_no"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "category_no", String.Empty);
                                newRow["additional_fee_id"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "additional_fee_id", Int64.Parse("0"));
                                newRow["optional_fee_id"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "optional_fee_id", Int64.Parse("0"));
                                newRow["is_additional_fee"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "is_additional_fee", false);
                                newRow["is_optional_fee"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "is_optional_fee", false);
                                newRow["is_per_year_tuition_fee"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "is_per_year_tuition_fee", false);
                                newRow["is_per_unit_tuition_fee"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "is_per_unit_tuition_fee", false);
                                newRow["is_fixed_amount_tuition_fee"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "is_fixed_amount_tuition_fee", false);
                                newRow["is_special_class_tuition_fee"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "is_special_class_tuition_fee", false);
                                newRow["international_percentage"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "international_percentage", Single.Parse("0"));

                                schoolFeeDetailTable.Rows.Add(newRow);
                            }

                            studentCount = 0;
                            studentSysIdList = String.Empty;
                            enrolmentLevelSysIdList = String.Empty;
                        }
                    }
                }
           }

            this.EditSchoolFeeDetailsTable(ref schoolFeeDetailTable, studentTable, false);        

            if (_classDataSet.Tables["CourseGroupTable"] != null && cbxCourseGroup.CheckedIndices.Count >= 1)
            {
                String strFilterCourseGroup = "is_semestral = " + isSemestral;
                DataRow[] selectCourseGroupTable = _classDataSet.Tables["CourseGroupTable"].Select(strFilterCourseGroup);

                IEnumerator myEnum = cbxCourseGroup.CheckedIndices.GetEnumerator();
                Int32 x;

                while (myEnum.MoveNext() != false)
                {
                    x = (Int32)myEnum.Current;

                    DataRow courseGoupRow = selectCourseGroupTable[x];

                    DataRow newCourseGroupRow = courseGroupTable.NewRow();

                    newCourseGroupRow["group_no"] = RemoteServerLib.ProcStatic.DataRowConvert(courseGoupRow, "group_no", String.Empty);
                    newCourseGroupRow["group_description"] = RemoteServerLib.ProcStatic.DataRowConvert(courseGoupRow, "group_description", String.Empty);

                    courseGroupTable.Rows.Add(newCourseGroupRow);

                    foreach (DataRow categoryRow in _classDataSet.Tables["SchoolFeeCategoryTable"].Rows)
                    {
                        String strFilterSchoolFeeParticular = "fee_category_id = '" + 
                            RemoteServerLib.ProcStatic.DataRowConvert(categoryRow, "fee_category_id", String.Empty) + "'";
                        DataRow[] selectSchoolFeeParticularTable = _classDataSet.Tables["SchoolFeeParticularTable"].Select(strFilterSchoolFeeParticular);

                        Boolean isFirstEnterParticular = true;//for grouping:: if true add category header

                        foreach (DataRow particularRow in selectSchoolFeeParticularTable)
                        {
                            Decimal col1 = 0, col2 = 0, col3 = 0, col4 = 0, col5 = 0, col6 = 0, col7 = 0, col8 = 0, col9 = 0;

                            Int32 countYearLevel = 1;

                            String strFilterYearLevel = "course_group_id = '" +
                                RemoteServerLib.ProcStatic.DataRowConvert(courseGoupRow, "course_group_id", String.Empty) + "'";
                            DataRow[] selectYearLevelTable = _classDataSet.Tables["YearLevelInformationTable"].Select(strFilterYearLevel);

                            foreach (DataRow yearLevelRow in selectYearLevelTable)
                            {
                                if (countYearLevel == 1)
                                {
                                    col1 = this.GetTotalAmountSchoolFeeParticular(schoolFeeDetailTable,
                                        RemoteServerLib.ProcStatic.DataRowConvert(particularRow, "sysid_feeparticular", String.Empty),
                                        RemoteServerLib.ProcStatic.DataRowConvert(yearLevelRow, "year_level_id", String.Empty),
                                        RemoteServerLib.ProcStatic.DataRowConvert(courseGoupRow, "is_semestral", false));
                                }
                                else if (countYearLevel == 2)
                                {
                                    col2 = this.GetTotalAmountSchoolFeeParticular(schoolFeeDetailTable,
                                        RemoteServerLib.ProcStatic.DataRowConvert(particularRow, "sysid_feeparticular", String.Empty),
                                        RemoteServerLib.ProcStatic.DataRowConvert(yearLevelRow, "year_level_id", String.Empty),
                                        RemoteServerLib.ProcStatic.DataRowConvert(courseGoupRow, "is_semestral", false));
                                }
                                else if (countYearLevel == 3)
                                {
                                    col3 = this.GetTotalAmountSchoolFeeParticular(schoolFeeDetailTable,
                                        RemoteServerLib.ProcStatic.DataRowConvert(particularRow, "sysid_feeparticular", String.Empty),
                                        RemoteServerLib.ProcStatic.DataRowConvert(yearLevelRow, "year_level_id", String.Empty),
                                        RemoteServerLib.ProcStatic.DataRowConvert(courseGoupRow, "is_semestral", false));
                                }
                                else if (countYearLevel == 4)
                                {
                                    col4 = this.GetTotalAmountSchoolFeeParticular(schoolFeeDetailTable,
                                        RemoteServerLib.ProcStatic.DataRowConvert(particularRow, "sysid_feeparticular", String.Empty),
                                        RemoteServerLib.ProcStatic.DataRowConvert(yearLevelRow, "year_level_id", String.Empty),
                                        RemoteServerLib.ProcStatic.DataRowConvert(courseGoupRow, "is_semestral", false));
                                }
                                else if (countYearLevel == 5)
                                {
                                    col5 = this.GetTotalAmountSchoolFeeParticular(schoolFeeDetailTable,
                                        RemoteServerLib.ProcStatic.DataRowConvert(particularRow, "sysid_feeparticular", String.Empty),
                                        RemoteServerLib.ProcStatic.DataRowConvert(yearLevelRow, "year_level_id", String.Empty),
                                        RemoteServerLib.ProcStatic.DataRowConvert(courseGoupRow, "is_semestral", false));
                                }
                                else if (countYearLevel == 6)
                                {
                                    col6 = this.GetTotalAmountSchoolFeeParticular(schoolFeeDetailTable,
                                        RemoteServerLib.ProcStatic.DataRowConvert(particularRow, "sysid_feeparticular", String.Empty),
                                        RemoteServerLib.ProcStatic.DataRowConvert(yearLevelRow, "year_level_id", String.Empty),
                                        RemoteServerLib.ProcStatic.DataRowConvert(courseGoupRow, "is_semestral", false));
                                }
                                else if (countYearLevel == 7)
                                {
                                    col7 = this.GetTotalAmountSchoolFeeParticular(schoolFeeDetailTable,
                                        RemoteServerLib.ProcStatic.DataRowConvert(particularRow, "sysid_feeparticular", String.Empty),
                                        RemoteServerLib.ProcStatic.DataRowConvert(yearLevelRow, "year_level_id", String.Empty),
                                        RemoteServerLib.ProcStatic.DataRowConvert(courseGoupRow, "is_semestral", false));
                                }
                                else if (countYearLevel == 8)
                                {
                                    col8 = this.GetTotalAmountSchoolFeeParticular(schoolFeeDetailTable,
                                        RemoteServerLib.ProcStatic.DataRowConvert(particularRow, "sysid_feeparticular", String.Empty),
                                        RemoteServerLib.ProcStatic.DataRowConvert(yearLevelRow, "year_level_id", String.Empty),
                                        RemoteServerLib.ProcStatic.DataRowConvert(courseGoupRow, "is_semestral", false));
                                }
                                else if (countYearLevel == 9)
                                {
                                    col9 = this.GetTotalAmountSchoolFeeParticular(schoolFeeDetailTable,
                                        RemoteServerLib.ProcStatic.DataRowConvert(particularRow, "sysid_feeparticular", String.Empty),
                                        RemoteServerLib.ProcStatic.DataRowConvert(yearLevelRow, "year_level_id", String.Empty),
                                        RemoteServerLib.ProcStatic.DataRowConvert(courseGoupRow, "is_semestral", false));
                                }

                                countYearLevel++;

                                pgbBase.PerformStep();
                            }
             
                            if (col1 > 0 || col2 > 0 || col3 > 0 || col4 > 0 || col5 > 0 || col6 > 0 || col7 > 0 || col8 > 0 || col9 > 0)
                            {
                                if (isFirstEnterParticular)
                                {
                                    DataRow newFirstRow = schoolFeeTable.NewRow();

                                    newFirstRow["group_no"] = RemoteServerLib.ProcStatic.DataRowConvert(courseGoupRow, "group_no", String.Empty);
                                    newFirstRow["particular_description"] = RemoteServerLib.ProcStatic.DataRowConvert(categoryRow, "category_description", String.Empty);

                                    schoolFeeTable.Rows.Add(newFirstRow);

                                    isFirstEnterParticular = false;

                                    pgbBase.Maximum = (selectSchoolFeeParticularTable.Length + cbxCourseGroup.CheckedIndices.Count);
                                }

                                DataRow newRow = schoolFeeTable.NewRow();

                                newRow["group_no"] = RemoteServerLib.ProcStatic.DataRowConvert(courseGoupRow, "group_no", String.Empty);
                                newRow["particular_description"] = "     " +
                                    RemoteServerLib.ProcStatic.DataRowConvert(particularRow, "particular_description", String.Empty);
                                newRow["total"] = col1 + col2 + col3 + col4 + col5 + col6 + col7 + col8 + col9;
                                newRow["col_1"] = col1;
                                newRow["col_2"] = col2;
                                newRow["col_3"] = col3;
                                newRow["col_4"] = col4;
                                newRow["col_5"] = col5;
                                newRow["col_6"] = col6;
                                newRow["col_7"] = col7;
                                newRow["col_8"] = col8;
                                newRow["col_9"] = col9;

                                schoolFeeTable.Rows.Add(newRow);

                                pgbBase.PerformStep();
                            }
                        }
                    }

                    pgbBase.PerformStep();
                }
            }

            if (schoolFeeTable.Rows.Count > 0)
            {

                using (ClassCashieringManager.CrystalReport.CrystalFeeRegisterSummarized rptFeeRegisterSummarized = new
                    FinanceServices.ClassCashieringManager.CrystalReport.CrystalFeeRegisterSummarized())
                {
                    rptFeeRegisterSummarized.Database.Tables["course_group_table"].SetDataSource(courseGroupTable);
                    rptFeeRegisterSummarized.Database.Tables["school_fee_table"].SetDataSource(schoolFeeTable);

                    rptFeeRegisterSummarized.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                    rptFeeRegisterSummarized.SetParameterValue("@form_name", "Fee Register (Summarized)");
                    rptFeeRegisterSummarized.SetParameterValue("@school_year_semester", strSchoolYearSemester);
                    rptFeeRegisterSummarized.SetParameterValue("@print_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
                        DateTime.Parse(_serverDateTime).ToShortTimeString() + "         Printed by: " +
                        RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                        userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));

                    using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptFeeRegisterSummarized))
                    {
                        frmViewer.Text = "   Fee Register (Summarized)";
                        frmViewer.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("The report is empty.", "Empty Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           
        }//---------------------------

        //this procedure will print credit memo prooflist
        public void PrintCreditMemoProoflist(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd, 
            Boolean isConsolidated, ProgressBar pgbBase)
        {
            DataTable creditMemoTable;

            DataTable reportTable = new DataTable("CreditMemoReportTable");
            reportTable.Columns.Add("student_id", System.Type.GetType("System.String"));
            reportTable.Columns.Add("name", System.Type.GetType("System.String"));
            reportTable.Columns.Add("course_level", System.Type.GetType("System.String"));
            reportTable.Columns.Add("cm_no", System.Type.GetType("System.String"));
            reportTable.Columns.Add("remakrs", System.Type.GetType("System.String"));
            reportTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));

            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                creditMemoTable = remClient.SelectByDateStartEndStudentCreditMemo(userInfo, dateStart, dateEnd, isConsolidated, this.ServerDateTime);
            }

            pgbBase.Maximum = creditMemoTable.Rows.Count;

            if (creditMemoTable != null)
            {
                foreach (DataRow cmRow in creditMemoTable.Rows)
                {
                    DataRow newRow = reportTable.NewRow();

                    newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(cmRow, "student_id", String.Empty);
                    newRow["name"] = RemoteClient.ProcStatic.GetCompleteNameFullMiddleName(cmRow, "last_name", "first_name", "middle_name");
                    newRow["course_level"] = RemoteServerLib.ProcStatic.DataRowConvert(cmRow, "course_acronym", String.Empty) + " - " +
                        RemoteServerLib.ProcStatic.DataRowConvert(cmRow, "year_level_description", String.Empty);
                    newRow["cm_no"] = RemoteServerLib.ProcStatic.DataRowConvert(cmRow, "memo_id", Int64.Parse("0")).ToString();
                    newRow["remakrs"] = RemoteServerLib.ProcStatic.DataRowConvert(cmRow, "remarks", String.Empty);
                    newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(cmRow, "amount", Decimal.Parse("0"));

                    reportTable.Rows.Add(newRow);

                    pgbBase.PerformStep();
                }
            }

            if (reportTable.Rows.Count > 0)
            {
                String strCashierConsolidated = isConsolidated ? "Consolidated" : RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                        userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName);

                using (ClassCashieringManager.CrystalReport.CrystalCreditMemoProoflist rptCreditMemoReport = new
                    FinanceServices.ClassCashieringManager.CrystalReport.CrystalCreditMemoProoflist())
                {
                    rptCreditMemoReport.Database.Tables["credit_memo_table"].SetDataSource(reportTable);

                    rptCreditMemoReport.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                    rptCreditMemoReport.SetParameterValue("@form_name", "Credit Memo Prooflist");
                    rptCreditMemoReport.SetParameterValue("@cashier_consolidated", strCashierConsolidated);
                    rptCreditMemoReport.SetParameterValue("@date_range", DateTime.Parse(dateStart).ToLongDateString() + " - " +
                        DateTime.Parse(dateEnd).ToLongDateString());
                    rptCreditMemoReport.SetParameterValue("@print_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
                        DateTime.Parse(_serverDateTime).ToShortTimeString() + "         Printed by: " +
                        RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                        userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));

                    using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptCreditMemoReport))
                    {
                        frmViewer.Text = "   Credit Memo Prooflist";
                        frmViewer.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("The report is empty.", "Empty Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }//-------------------------------

        //this procedure will print discount report
        public void PrintDiscountReport(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd,
            CheckedListBox cbkCourse, CheckedListBox cbkScholarship, String strYearSemesterDescription, ProgressBar pgbBase)
        {
            DataTable discountTable;

            DataTable courseTable = new DataTable("CourseTable");
            courseTable.Columns.Add("course_id", System.Type.GetType("System.String"));
            courseTable.Columns.Add("course_title", System.Type.GetType("System.String"));
            courseTable.Columns.Add("course_acronym", System.Type.GetType("System.String"));
            courseTable.Columns.Add("department_name", System.Type.GetType("System.String"));
            courseTable.Columns.Add("department_acronym", System.Type.GetType("System.String"));
            courseTable.Columns.Add("scholarship_description", System.Type.GetType("System.String"));
            courseTable.Columns.Add("sysid_scholarship", System.Type.GetType("System.String"));

            DataTable studentDiscountTable = new DataTable("StudentDiscountTable");
            studentDiscountTable.Columns.Add("course_id", System.Type.GetType("System.String"));
            studentDiscountTable.Columns.Add("sysid_scholarship", System.Type.GetType("System.String"));
            studentDiscountTable.Columns.Add("student_id", System.Type.GetType("System.String"));
            studentDiscountTable.Columns.Add("student_name", System.Type.GetType("System.String"));
            studentDiscountTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
            studentDiscountTable.Columns.Add("received_date", System.Type.GetType("System.String"));
            studentDiscountTable.Columns.Add("reflected_date", System.Type.GetType("System.String"));
            studentDiscountTable.Columns.Add("remarks", System.Type.GetType("System.String"));
            studentDiscountTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));

            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                discountTable = remClient.SelectByDateStartEndCourseScholarshipListStudentDiscounts(userInfo, dateStart, dateEnd,
                    this.GetCourseYearLevelStringFormat(cbkCourse, true), this.GetScholarshipStringFormat(cbkScholarship), this.ServerDateTime);
            }

            pgbBase.Maximum = discountTable.Rows.Count + cbkCourse.CheckedIndices.Count;

            if (_classDataSet.Tables["CourseInformationTable"] != null && cbkCourse.CheckedIndices.Count >= 1)
            {
                IEnumerator myEnum = cbkCourse.CheckedIndices.GetEnumerator();
                Int32 x;

                while (myEnum.MoveNext() != false)
                {
                    x = (Int32)myEnum.Current;

                    DataRow courseRow = _classDataSet.Tables["CourseInformationTable"].Rows[x];

                    String strFilter = "course_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", "") + "'";
                    DataRow[] selectRow = discountTable.Select(strFilter);

                    if (selectRow.Length > 0)
                    {   
                        if (_classDataSet.Tables["ScholarshipInformationTable"] != null && cbkScholarship.CheckedIndices.Count >= 1)
                        {
                            IEnumerator myEnumScholar = cbkScholarship.CheckedIndices.GetEnumerator();
                            Int32 xScholar;

                            while (myEnumScholar.MoveNext() != false)
                            {
                                xScholar = (Int32)myEnumScholar.Current;

                                DataRow scholarRow = _classDataSet.Tables["ScholarshipInformationTable"].Rows[xScholar];
                               
                                String strFilterScholarship = "course_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", "") + "'" +
                                    "AND sysid_scholarship = '" + RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "sysid_scholarship", "") + "'";
                                DataRow[] selectRowScholarship = discountTable.Select(strFilterScholarship);
                                
                                if (selectRowScholarship.Length > 0)
                                {
                                    DataRow newRow = courseTable.NewRow();

                                    newRow["course_id"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", "");
                                    newRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_title", "");
                                    newRow["course_acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_acronym", "");
                                    newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "department_name", "");
                                    newRow["department_acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "department_acronym", "");
                                    newRow["scholarship_description"] = RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "scholarship_description", "");
                                    newRow["sysid_scholarship"] = RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "sysid_scholarship", String.Empty);

                                    courseTable.Rows.Add(newRow);
                                }
                            }
                        }                        
                    }

                    pgbBase.PerformStep();
                }
            }

            if (discountTable != null)
            {
                foreach (DataRow disRow in discountTable.Rows)
                {
                    DataRow newRow = studentDiscountTable.NewRow();

                    newRow["course_id"] = RemoteServerLib.ProcStatic.DataRowConvert(disRow, "course_id", String.Empty);
                    newRow["sysid_scholarship"] = RemoteServerLib.ProcStatic.DataRowConvert(disRow, "sysid_scholarship", String.Empty);
                    newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(disRow, "student_id", String.Empty);
                    newRow["student_name"] = RemoteClient.ProcStatic.GetCompleteNameFullMiddleName(disRow, "last_name", "first_name", "middle_name");
                    newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(disRow, "year_level_description", String.Empty);
                    newRow["received_date"] = RemoteServerLib.ProcStatic.DataRowConvert(disRow, "received_date", String.Empty);
                    newRow["reflected_date"] = RemoteServerLib.ProcStatic.DataRowConvert(disRow, "reflected_date", String.Empty);
                    newRow["remarks"] = RemoteServerLib.ProcStatic.DataRowConvert(disRow, "remarks", String.Empty);
                    newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(disRow, "amount", Decimal.Parse("0"));

                    studentDiscountTable.Rows.Add(newRow);

                    pgbBase.PerformStep();
                }
            }

            if (courseTable.Rows.Count > 0)
            {
                using (ClassCashieringManager.CrystalReport.CrystalStudentDiscountReport rptDiscountReport = new
                    FinanceServices.ClassCashieringManager.CrystalReport.CrystalStudentDiscountReport())
                {
                    rptDiscountReport.Database.Tables["course_table"].SetDataSource(courseTable);
                    rptDiscountReport.Database.Tables["student_discount_table"].SetDataSource(studentDiscountTable);

                    rptDiscountReport.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                    rptDiscountReport.SetParameterValue("@year_semester_description", strYearSemesterDescription);
                    rptDiscountReport.SetParameterValue("@form_name", "Scholarship Discount Report");
                    rptDiscountReport.SetParameterValue("@print_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
                        DateTime.Parse(_serverDateTime).ToShortTimeString() + "         Printed by: " +
                        RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                        userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));

                    using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptDiscountReport))
                    {
                        frmViewer.Text = "   Scholarship Discount Report";
                        frmViewer.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("The report is empty.", "Empty Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }//-----------------------------

        //this procedure will print student payment summary
        public void PrintStudentPaymentSummary(String studentName, String studentId, String courseTitle, String yearLevelDescription, String schoolYear)
        {
            DataTable pChargesTable = new DataTable("ChargesTable");
            pChargesTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            pChargesTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));
            pChargesTable.Columns.Add("sysid_feedetails", System.Type.GetType("System.String"));
            pChargesTable.Columns.Add("particular_description", System.Type.GetType("System.String"));
            pChargesTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));
            pChargesTable.Columns.Add("fee_category_id", System.Type.GetType("System.String"));
            pChargesTable.Columns.Add("category_description", System.Type.GetType("System.String"));
            pChargesTable.Columns.Add("is_level_increase", System.Type.GetType("System.Boolean"));


            if (_schoolFeeDetailsTableCurrentCharge != null)
            {
                foreach (DataRow detailsRow in _schoolFeeDetailsTableCurrentCharge.Rows)
                {
                    if (detailsRow.RowState != DataRowState.Deleted &&
                         ((CommonExchange.SchoolFeeCategoryId.TuitionFee == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "") &&
                        (RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_per_year_tuition_fee", false) ||
                         RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_per_unit_tuition_fee", false) ||
                         RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_fixed_amount_tuition_fee", false) ||
                         RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_special_class_tuition_fee", false))) ||
                        CommonExchange.SchoolFeeCategoryId.MiscellaneousFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "") ||
                        CommonExchange.SchoolFeeCategoryId.OtherFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "") ||
                        CommonExchange.SchoolFeeCategoryId.LaboratoryFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "")))
                    {
                        if (RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0")) > 0)
                        {
                            DataRow newRow = pChargesTable.NewRow();

                            newRow["sysid_student"] = String.Empty;
                            newRow["sysid_enrolmentlevel"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sysid_enrolmentlevel", "");
                            newRow["sysid_feedetails"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sysid_feedetails", "");
                            newRow["particular_description"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "particular_description", "");
                            newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                            newRow["fee_category_id"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "");
                            newRow["category_description"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "category_description", "");
                            newRow["is_level_increase"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_level_increase", false);

                            pChargesTable.Rows.Add(newRow);
                        }
                    }
                }
            }

            using (ClassCashieringManager.CrystalReport.CrystalStatementOfAccountSummaryDetails rptActSummary = new 
                FinanceServices.ClassCashieringManager.CrystalReport.CrystalStatementOfAccountSummaryDetails())
            {
                rptActSummary.Database.Tables["statement_of_account_table"].SetDataSource(_stementOfAccountSummaryTable);
                rptActSummary.Database.Tables["charges_table"].SetDataSource(pChargesTable);

                rptActSummary.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                rptActSummary.SetParameterValue("@student_name", studentName);
                rptActSummary.SetParameterValue("@student_id", studentId);
                rptActSummary.SetParameterValue("@course_title", courseTitle);
                rptActSummary.SetParameterValue("@year_level_description", yearLevelDescription);
                rptActSummary.SetParameterValue("@statement_date", DateTime.Parse(_serverDateTime).ToLongDateString());
                rptActSummary.SetParameterValue("@school_year_semester", schoolYear);
                rptActSummary.SetParameterValue("@form_name", "Statement of Account Summary");

                using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptActSummary))
                {
                    frmViewer.Text = "   Statement of Account Summary";
                    frmViewer.ShowDialog();
                }
            }
            
        }//------------------------------

        //this procedure will print student statement of account
        public void PrintStudentStatementOfAccount(CommonExchange.SysAccess userInfo, String studentSysId, String schoolYear,
            String sysIdEnrolmentLevel, String sysIdFeeLevel, String enrolmentCourseSysId, DateTime dateStart, DateTime dateEnd, Boolean isSummer)
        {
            //tables of printing
            DataTable pStudentTable = new DataTable("StudentTable");
            pStudentTable.Columns.Add("student_name", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("student_id", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("course_title", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("year_Semester_description", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("notes", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("course_group_id", System.Type.GetType("System.String"));

            DataTable pSubjecScheduleTable = new DataTable("ScheduleDetailsTable");
            pSubjecScheduleTable.Columns.Add("day_time", System.Type.GetType("System.String"));
            pSubjecScheduleTable.Columns.Add("room", System.Type.GetType("System.String"));
            pSubjecScheduleTable.Columns.Add("section", System.Type.GetType("System.String"));
            pSubjecScheduleTable.Columns.Add("instructor", System.Type.GetType("System.String"));
            pSubjecScheduleTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));
            pSubjecScheduleTable.Columns.Add("subject_code_title", System.Type.GetType("System.String"));
            pSubjecScheduleTable.Columns.Add("subject_lecture_units", System.Type.GetType("System.String"));
            pSubjecScheduleTable.Columns.Add("subject_lab_units", System.Type.GetType("System.String"));
            pSubjecScheduleTable.Columns.Add("subject_no_hours", System.Type.GetType("System.String"));

            DataTable chargesSummaryTable = new DataTable("ChargesSummaryTable");
            chargesSummaryTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            chargesSummaryTable.Columns.Add("charges_description", System.Type.GetType("System.String"));
            chargesSummaryTable.Columns.Add("text_balance", System.Type.GetType("System.String"));
            chargesSummaryTable.Columns.Add("amount", System.Type.GetType("System.String"));
            chargesSummaryTable.Columns.Add("total_amount", System.Type.GetType("System.String"));

            DataTable examTable = new DataTable("ExamTable");
            examTable.Columns.Add("exam_id", System.Type.GetType("System.Int64"));
            examTable.Columns.Add("exam_date", System.Type.GetType("System.String"));
            examTable.Columns.Add("exam_description", System.Type.GetType("System.String"));
            examTable.Columns.Add("course_group_id", System.Type.GetType("System.String"));

            DataTable amountDueTable = new DataTable("AmountDueTable");
            amountDueTable.Columns.Add("exam_id", System.Type.GetType("System.Int64"));
            amountDueTable.Columns.Add("amount_due", System.Type.GetType("System.Decimal"));
            amountDueTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            //------------------------

            chargesSummaryTable.Clear();

            String strCourseId = String.Empty;

            if (_studentTable != null)
            {
                String strFilter = "sysid_student = '" + studentSysId + "'";
                DataRow[] selectRow = _studentTable.Select(strFilter);

                foreach (DataRow studRow in selectRow)
                {
                    DataRow newRow = pStudentTable.NewRow();

                    newRow["student_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(
                        RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", ""),
                        RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", ""),
                        RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", ""));
                    newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", "");
                    newRow["course_title"] = this.GetCourseTitleCourseGroup(enrolmentCourseSysId);
                    newRow["year_level_description"] = this.GetYearLevelDescriptionCourseGroup(sysIdFeeLevel, true) + "  " +
                        RemoteServerLib.ProcStatic.DataRowConvert(studRow, "level_section", String.Empty);
                    newRow["sysid_enrolmentlevel"] = sysIdEnrolmentLevel;
                    newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                    newRow["year_semester_description"] = schoolYear;
                    newRow["notes"] = "This is to certify that " + RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(
                           RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", ""),
                           RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", ""),
                           RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", "")) +
                           " is cleared of property and financial obligations in this institution.";
                    newRow["course_group_id"] = this.GetYearLevelDescriptionCourseGroup(sysIdFeeLevel, false);

                    pStudentTable.Rows.Add(newRow);

                    strCourseId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_id", String.Empty);

                    break;
                }
            }

            if (_studentLoadTable != null)
            {
                foreach (DataRow loadRow in _studentLoadTable.Rows)
                {
                    if (loadRow.RowState != DataRowState.Deleted)
                    {
                        String strFilter = "sysid_schedule = '" + RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "sysid_schedule", "") + "'";
                        DataRow[] selectScheduleDetails = _subjectScheduleTable.Select(strFilter);

                        foreach (DataRow schedRow in selectScheduleDetails)
                        {
                            DataRow newRow = pSubjecScheduleTable.NewRow();

                            newRow["sysid_enrolmentlevel"] = sysIdEnrolmentLevel;

                            String strFilterSched = "sysid_schedule = '" + RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "sysid_schedule", "") + "'";
                            DataRow[] selectSubjectSchedule = _subjectScheduleTable.Select(strFilter);

                            foreach (DataRow subRow in selectSubjectSchedule)
                            {
                                if (subRow.RowState != DataRowState.Deleted)
                                {
                                    newRow["subject_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_code", "") + " - " +
                                        RemoteServerLib.ProcStatic.DataRowConvert(subRow, "descriptive_title", "");

                                    break;
                                }
                            }

                            pSubjecScheduleTable.Rows.Add(newRow);
                        }
                    }
                }
            }

            if (_specialClassTable != null)
            {
                foreach (DataRow specialRow in _specialClassTable.Rows)
                {
                    if (specialRow.RowState != DataRowState.Deleted)
                    {
                        DataRow newRow = pSubjecScheduleTable.NewRow();

                        newRow["sysid_enrolmentlevel"] = sysIdEnrolmentLevel;
                        newRow["subject_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_code", "") + " - " +
                                       RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "descriptive_title", "");

                        pSubjecScheduleTable.Rows.Add(newRow);
                    }
                }
            }

            pStudentTable.AcceptChanges();
            pSubjecScheduleTable.AcceptChanges();

            Decimal totalTutionFee = 0;
            Decimal totalMiscellaneousFee = 0;
            Decimal totalOtherFee = 0;
            Decimal totalLaboratoryFee = 0;
            Decimal downpayment = 0;
            Decimal totalCharges = 0;
            Decimal totalDiscountPayments = 0;
            Decimal totalBalanceForwarded = 0;
            Decimal totalReimbursement = 0;

            foreach (DataRow bRow in _balanceForwardedTable.Rows)
            {
                //if (RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0")) > 0)
                //{
                if (RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0")) != 0)
                {
                    DataRow newRow = chargesSummaryTable.NewRow();

                    newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "sysid_student", "");
                    newRow["charges_description"] = "Balance Forwarded";
                    newRow["text_balance"] = String.Empty;
                    newRow["amount"] = this.GetStringAmount(RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0")));
                    newRow["total_amount"] = String.Empty;

                    chargesSummaryTable.Rows.Add(newRow);

                    totalBalanceForwarded = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0"));
                    totalCharges += RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0"));
                }
                //}

                break;
            }

            if (_schoolFeeDetailsTableCurrentCharge != null)
            {

                foreach (DataRow detailsRow in _schoolFeeDetailsTableCurrentCharge.Rows)
                {
                    if (detailsRow.RowState != DataRowState.Deleted)
                    {
                        if (CommonExchange.SchoolFeeCategoryId.TuitionFee == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "") &&
                        (RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_per_year_tuition_fee", false) ||
                         RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_per_unit_tuition_fee", false) ||
                         RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_fixed_amount_tuition_fee", false) ||
                         RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_special_class_tuition_fee", false)))
                        {
                            totalTutionFee += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                        }
                        else if (CommonExchange.SchoolFeeCategoryId.MiscellaneousFees == 
                            RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", ""))
                        {
                            totalMiscellaneousFee += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                        }
                        else if (CommonExchange.SchoolFeeCategoryId.OtherFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", ""))
                        {
                            totalOtherFee += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                        }
                        else if (CommonExchange.SchoolFeeCategoryId.LaboratoryFees == 
                            RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", ""))
                        {
                            totalLaboratoryFee += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                        }
                    }
                }
            }

            if (totalTutionFee > 0)
            {
                DataRow newRow = chargesSummaryTable.NewRow();

                newRow["sysid_student"] = studentSysId;
                newRow["charges_description"] = "Tuition Fee";
                newRow["text_balance"] = String.Empty;
                newRow["amount"] = this.GetStringAmount(totalTutionFee);
                newRow["total_amount"] = String.Empty;

                chargesSummaryTable.Rows.Add(newRow);

                totalCharges += totalTutionFee;
            }

            if (totalMiscellaneousFee > 0)
            {
                DataRow newRow = chargesSummaryTable.NewRow();

                newRow["sysid_student"] = studentSysId;
                newRow["charges_description"] = "Miscellaneous Fee";
                newRow["text_balance"] = String.Empty;
                newRow["amount"] = this.GetStringAmount(totalMiscellaneousFee);
                newRow["total_amount"] = String.Empty;

                chargesSummaryTable.Rows.Add(newRow);

                totalCharges += totalMiscellaneousFee;
            }

            if (totalOtherFee > 0)
            {
                DataRow newRow = chargesSummaryTable.NewRow();

                newRow["sysid_student"] = studentSysId;
                newRow["charges_description"] = "Other Fee";
                newRow["text_balance"] = String.Empty;
                newRow["amount"] = this.GetStringAmount(totalOtherFee);
                newRow["total_amount"] = String.Empty;

                chargesSummaryTable.Rows.Add(newRow);

                totalCharges += totalOtherFee;
            }

            if (totalLaboratoryFee > 0)
            {
                DataRow newRow = chargesSummaryTable.NewRow();

                newRow["sysid_student"] = studentSysId;
                newRow["charges_description"] = "Laboratory Fee";
                newRow["text_balance"] = String.Empty;
                newRow["amount"] = this.GetStringAmount(totalLaboratoryFee);
                newRow["total_amount"] = String.Empty;

                chargesSummaryTable.Rows.Add(newRow);

                totalCharges += totalLaboratoryFee;
            }

            DataRow[] selectPaymentReimbursement = _paymentReimbursementTable.Select(String.Empty, "is_reimbursement DESC");

            Boolean isFirstEntry = true;
            foreach (DataRow paymentRow in selectPaymentReimbursement)
            {
                //Code added:: include only if (is_included_in_post == true) :: April 7, 2010
                if (!RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_balance_forwarded", false) &&
                    RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_included_in_post", false))
                {
                    String remarksDescription = String.Empty;
                    String paymentDiscountReimbursementDate = !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "receipt_no", String.Empty)) ?
                        "(" + RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "receipt_no", String.Empty) + ") :: " : String.Empty;

                    if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                        (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_payment", false) &&
                        !RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false)))
                    {
                        remarksDescription = "Payment";
                    }
                    else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false))
                    {
                        remarksDescription = "Downpayment";

                        downpayment += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) +
                            RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0"));
                    }
                    else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                       RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false)) 
                    {
                        remarksDescription = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "");

                        downpayment += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) +
                            RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0"));
                    }
                    else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_reimbursement", false))
                    {
                        remarksDescription = "Reimbursement";
                    }
                    else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                           RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_credit_memo", false))
                    {
                        remarksDescription = "Credit Memo";
                    }
                    else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")))
                    {
                        remarksDescription = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "");
                    }

                    DateTime pDate;

                    if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "received_date", ""), out pDate))
                    {
                        paymentDiscountReimbursementDate += pDate.ToShortDateString();
                    }

                    if (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_reimbursement", false))
                    {
                        DataRow newRow = chargesSummaryTable.NewRow();

                        newRow["sysid_student"] = studentSysId;
                        newRow["charges_description"] = remarksDescription + " - " + paymentDiscountReimbursementDate;
                        newRow["text_balance"] = String.Empty;
                        newRow["amount"] = this.GetStringAmount(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")));
                        newRow["total_amount"] = String.Empty;

                        chargesSummaryTable.Rows.Add(newRow);

                        totalReimbursement += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));
                        totalCharges += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));
                    }
                    else
                    {
                        if (isFirstEntry)
                        {
                            DataRow newRow = chargesSummaryTable.NewRow();

                            newRow["sysid_student"] = studentSysId;
                            newRow["charges_description"] = "       Sub Total";
                            newRow["text_balance"] = String.Empty;
                            newRow["amount"] = String.Empty;
                            newRow["total_amount"] = this.GetStringAmount(totalCharges);

                            chargesSummaryTable.Rows.Add(newRow);

                            DataRow newLessRow = chargesSummaryTable.NewRow();

                            newLessRow["sysid_student"] = studentSysId;
                            newLessRow["charges_description"] = "Less:";
                            newLessRow["text_balance"] = String.Empty;
                            newLessRow["amount"] = String.Empty;
                            newLessRow["total_amount"] = String.Empty;

                            chargesSummaryTable.Rows.Add(newLessRow);

                            isFirstEntry = false;
                        }

                        DataRow newDiscountPaymentRow = chargesSummaryTable.NewRow();

                        newDiscountPaymentRow["sysid_student"] = studentSysId;
                        newDiscountPaymentRow["charges_description"] = "   " + remarksDescription + " - " + paymentDiscountReimbursementDate;
                        newDiscountPaymentRow["text_balance"] = String.Empty;
                        newDiscountPaymentRow["amount"] = "(" + 
                            RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")).ToString("N") + ")";
                        newDiscountPaymentRow["total_amount"] = String.Empty;

                        chargesSummaryTable.Rows.Add(newDiscountPaymentRow);

                        if (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0")) > 0)
                        {
                            DataRow newDiscountedAmountRow = chargesSummaryTable.NewRow();

                            newDiscountedAmountRow["sysid_student"] = studentSysId;
                            newDiscountedAmountRow["charges_description"] = "   Cash Discount - " + paymentDiscountReimbursementDate;
                            newDiscountedAmountRow["text_balance"] = String.Empty;
                            newDiscountedAmountRow["amount"] = "(" +
                                RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0")).ToString("N") + ")";
                            newDiscountedAmountRow["total_amount"] = String.Empty;

                            chargesSummaryTable.Rows.Add(newDiscountedAmountRow);
                        }

                        totalDiscountPayments += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) +
                            RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0"));
                    }
                }
            }

            if (isFirstEntry)
            {
                DataRow newRowPaymentDiscount = chargesSummaryTable.NewRow();

                newRowPaymentDiscount["sysid_student"] = studentSysId;
                newRowPaymentDiscount["charges_description"] = "       Sub Total";
                newRowPaymentDiscount["text_balance"] = String.Empty;
                newRowPaymentDiscount["amount"] = String.Empty;
                newRowPaymentDiscount["total_amount"] = this.GetStringAmount(totalCharges);

                chargesSummaryTable.Rows.Add(newRowPaymentDiscount);
            }
            else
            {
                DataRow newTotalDiscountPaymentRow = chargesSummaryTable.NewRow();

                newTotalDiscountPaymentRow["sysid_student"] = studentSysId;
                newTotalDiscountPaymentRow["charges_description"] = "       Sub Total";
                newTotalDiscountPaymentRow["text_balance"] = String.Empty;
                newTotalDiscountPaymentRow["amount"] = String.Empty;
                newTotalDiscountPaymentRow["total_amount"] = "(" + totalDiscountPayments.ToString("N") + ")";

                chargesSummaryTable.Rows.Add(newTotalDiscountPaymentRow);
            }

            DataRow lineRow = chargesSummaryTable.NewRow();

            lineRow["sysid_student"] = studentSysId;
            lineRow["charges_description"] = String.Empty;
            lineRow["text_balance"] = String.Empty;
            lineRow["amount"] = String.Empty;
            lineRow["total_amount"] = "_________";

            chargesSummaryTable.Rows.Add(lineRow);

            DataRow balanceRow = chargesSummaryTable.NewRow();

            balanceRow["sysid_student"] = studentSysId;
            balanceRow["charges_description"] = String.Empty;
            balanceRow["text_balance"] = "Balance";
            balanceRow["amount"] = String.Empty;
            balanceRow["total_amount"] = (totalCharges - totalDiscountPayments).ToString("N");

            chargesSummaryTable.Rows.Add(balanceRow);

            Boolean isClearanceIncluded = false;

            if (_majorExamScheduleTableForPrinting != null)
            {
                //create temporary table for payment reimbursement table
                DataTable paymentReimbursementTableTemp = new DataTable("TemporaryTable");
                paymentReimbursementTableTemp.Columns.Add("payment_discount_reimbursement_id", System.Type.GetType("System.String"));
                paymentReimbursementTableTemp.Columns.Add("reflected_date", System.Type.GetType("System.DateTime"));
                paymentReimbursementTableTemp.Columns.Add("amount", System.Type.GetType("System.Decimal"));
                paymentReimbursementTableTemp.Columns.Add("discount_amount", System.Type.GetType("System.Decimal"));
                paymentReimbursementTableTemp.Columns.Add("is_payment", System.Type.GetType("System.Boolean"));
                paymentReimbursementTableTemp.Columns.Add("is_discount", System.Type.GetType("System.Boolean"));
                paymentReimbursementTableTemp.Columns.Add("is_downpayment", System.Type.GetType("System.Boolean"));
                paymentReimbursementTableTemp.Columns.Add("is_credit_memo", System.Type.GetType("System.Boolean"));
                paymentReimbursementTableTemp.Columns.Add("is_included_in_post", System.Type.GetType("System.Boolean"));

                foreach (DataRow payRow in _paymentReimbursementTable.Rows)
                {
                    DataRow newRow = paymentReimbursementTableTemp.NewRow();

                    newRow["payment_discount_reimbursement_id"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "payment_discount_reimbursement_id", "");

                    DateTime pDate = DateTime.Parse(this.ServerDateTime);

                    if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(payRow, "reflected_date", ""), out pDate))
                    {
                        newRow["reflected_date"] = pDate;
                    }

                    newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "amount", Decimal.Parse("0"));
                    newRow["discount_amount"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "discount_amount", Decimal.Parse("0"));
                    newRow["is_payment"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_payment", false);
                    newRow["is_discount"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_discount", false);
                    newRow["is_downpayment"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_downpayment", false);
                    newRow["is_credit_memo"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_credit_memo", false);
                    newRow["is_included_in_post"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_included_in_post", false);

                    paymentReimbursementTableTemp.Rows.Add(newRow);
                }
                //------------------------

                StringBuilder strCourseGroup = new StringBuilder();

                Boolean hasEnter = false;
                foreach (DataRow groupRow in _majorExamScheduleTableForPrinting.Rows)
                {
                    if (!hasEnter && RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "is_for_print", false))
                    {
                        strCourseGroup.Append("course_group_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "") + "'");

                        hasEnter = true;
                    }
                    else if (hasEnter && RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "is_for_print", false))
                    {
                        strCourseGroup.Append(" OR course_group_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "") + "'");
                    }
                }

                DataRow[] selectMajorExam = _majorExamScheduleTableForPrinting.Select(strCourseGroup.ToString());

                Decimal amountToBeAdded = 0;
                Decimal minimunDownpayment = 0;

                if (!isSummer)
                {
                    if (String.Equals(strCourseId, "CRSE014"))
                    {
                        amountToBeAdded = this.GetToBeAddedAmount(5000, ref downpayment);
                        minimunDownpayment = 5000;
                    }
                    else if (String.Equals(strCourseId, "CRSE012") || String.Equals(strCourseId, "CRSE011"))
                    {
                        amountToBeAdded = this.GetToBeAddedAmount(3500, ref downpayment);
                        minimunDownpayment = 3500;
                    }
                    else
                    {
                        amountToBeAdded = this.GetToBeAddedAmount(2500, ref downpayment);
                        minimunDownpayment = 2500;
                    }
                }
                else
                {
                    if (String.Equals(strCourseId, "CRSE014"))
                    {
                        amountToBeAdded = this.GetToBeAddedAmount(2000, ref downpayment);
                        minimunDownpayment = 2000;
                    }
                    else
                    {
                        amountToBeAdded = this.GetToBeAddedAmount(1500, ref downpayment);
                        minimunDownpayment = 1500;
                    }
                }

                amountToBeAdded += totalBalanceForwarded;

                Decimal acctualAmountDue = 0;

                if (selectMajorExam.Length > 1)
                {
                    acctualAmountDue = ((totalTutionFee + totalMiscellaneousFee + totalOtherFee +
                       totalLaboratoryFee + totalReimbursement) - downpayment) / selectMajorExam.Length;
                }
                else if (selectMajorExam.Length == 1)
                {
                    acctualAmountDue = (totalTutionFee + totalMiscellaneousFee + totalOtherFee + totalLaboratoryFee + totalReimbursement + totalBalanceForwarded);
                }

                Decimal totalPayment = 0;

                String strFilter = "is_downpayment = 0";
                DataRow[] selectRow = paymentReimbursementTableTemp.Select(strFilter);

                foreach (DataRow payRow in selectRow)
                {
                    DateTime paymentDate = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(payRow, "reflected_date", String.Empty));

                    //Code added:: include only if (is_included_in_post == true) :: July 6, 2010
                    if (RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_included_in_post", false))
                    {
                        if (RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_payment", false) ||
                            RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_discount", false) ||
                            RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_credit_memo", false))
                        {
                            totalPayment += RemoteServerLib.ProcStatic.DataRowConvert(payRow, "amount", Decimal.Parse("0")) +
                                RemoteServerLib.ProcStatic.DataRowConvert(payRow, "discount_amount", Decimal.Parse("0"));
                        }
                    }
                }

                DateTime previousDateTime = DateTime.MinValue;
                Decimal amountDuePrevious = 0;
                Decimal computedAcctualAmountDue = 0;
                Boolean isFirstEnter = true;

                foreach (DataRow examRow in selectMajorExam)
                {
                    Decimal amountDue = 0;

                    DataRow newRowExam = examTable.NewRow();
                    DataRow newRowAmountDue = amountDueTable.NewRow();

                    newRowExam["exam_id"] = newRowAmountDue["exam_id"] = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "major_exam_id", Int64.Parse("0"));

                    DateTime dueDate = DateTime.Parse(this.ServerDateTime);

                    if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_date", ""), out dueDate))
                    {
                        TimeSpan oneDay = new TimeSpan(24, 0, 0);

                        newRowExam["exam_date"] = dueDate.Subtract(oneDay).ToLongDateString();

                        Decimal totalPaymentByTerm = 0;

                        if (!RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_clearance_included", false))
                        {
                            totalPaymentByTerm = previousDateTime == DateTime.MinValue ?
                                    this.GetTotalPaymentByDateStartEnd(dateStart, dueDate, paymentReimbursementTableTemp, isFirstEnter) :
                                    this.GetTotalPaymentByDateStartEnd(previousDateTime, dueDate, paymentReimbursementTableTemp, isFirstEnter);
                        }
                        else
                        {

                            totalPaymentByTerm = previousDateTime == DateTime.MinValue ?
                                    this.GetTotalPaymentByDateStartEnd(dateStart, dateEnd, paymentReimbursementTableTemp, isFirstEnter) :
                                    this.GetTotalPaymentByDateStartEnd(previousDateTime, dateEnd, paymentReimbursementTableTemp, isFirstEnter);
                        }

                        //AD----------------------------
                        if (!RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_clearance_included", false))
                        {
                            if (isFirstEnter)
                            {
                                amountDue = (acctualAmountDue + minimunDownpayment + totalBalanceForwarded) - totalPaymentByTerm;

                                amountDuePrevious = (acctualAmountDue + minimunDownpayment + totalBalanceForwarded) - totalPaymentByTerm;

                                isFirstEnter = false;
                            }
                            else
                            {
                                amountDue = (acctualAmountDue + amountDuePrevious) - totalPaymentByTerm;

                                amountDuePrevious = (acctualAmountDue + amountDuePrevious) - totalPaymentByTerm;
                            }
                        }
                        else
                        {
                            amountDue = (acctualAmountDue + amountDuePrevious) - totalPaymentByTerm;
                        }
                        //--------------------------------
                
                        previousDateTime = dueDate;
                    }

                    computedAcctualAmountDue += acctualAmountDue;

                    if (RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_for_print", false))
                    {
                        isClearanceIncluded = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_clearance_included", false);

                        if (!RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_clearance_included", false))
                        {
                            amountDue = ((amountDue < 0) || (totalPayment > computedAcctualAmountDue + amountToBeAdded)) ? 0 :
                                (((computedAcctualAmountDue - totalPayment) + amountToBeAdded) < 0 ? 0 :
                                ((computedAcctualAmountDue - totalPayment) + amountToBeAdded));
                        }

                        newRowExam["exam_description"] = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_description", "");
                        newRowExam["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "course_group_id", "");

                        newRowAmountDue["amount_due"] = amountDue;
                        newRowAmountDue["sysid_student"] = studentSysId;

                        examTable.Rows.Add(newRowExam);
                        amountDueTable.Rows.Add(newRowAmountDue);
                    }
                }
            }

            if (!isClearanceIncluded)
            {
                using (ClassCashieringManager.CrystalReport.CrystalStudentStatementOfAccount rptStudentStatementOfAccount =
                    new FinanceServices.ClassCashieringManager.CrystalReport.CrystalStudentStatementOfAccount())
                {
                    rptStudentStatementOfAccount.Database.Tables["student_table"].SetDataSource(pStudentTable);
                    rptStudentStatementOfAccount.Database.Tables["subject_schedule_details_table"].SetDataSource(pSubjecScheduleTable);
                    rptStudentStatementOfAccount.Database.Tables["charges_summary_table"].SetDataSource(chargesSummaryTable);
                    rptStudentStatementOfAccount.Database.Tables["amount_due_table"].SetDataSource(amountDueTable);
                    rptStudentStatementOfAccount.Database.Tables["exam_table"].SetDataSource(examTable);

                    rptStudentStatementOfAccount.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                    rptStudentStatementOfAccount.SetParameterValue("@school_year", schoolYear);
                    rptStudentStatementOfAccount.SetParameterValue("@form_name", "Student Statement of Account");
                    rptStudentStatementOfAccount.SetParameterValue("@print_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
                        DateTime.Parse(_serverDateTime).ToShortTimeString() + "         Printed by: " +
                        RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                        userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));

                    using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptStudentStatementOfAccount))
                    {
                        frmViewer.Text = "   Student Statement of Account";
                        frmViewer.ShowDialog();
                    }
                }
            }
            else
            {
                //create tables 
                DataTable lineTable = new DataTable("LineTable");
                lineTable.Columns.Add("line_id", System.Type.GetType("System.Byte"));
                lineTable.Columns.Add("col_1", System.Type.GetType("System.String"));
                lineTable.Columns.Add("col_2", System.Type.GetType("System.String"));
                lineTable.Columns.Add("col_3", System.Type.GetType("System.String"));
                lineTable.Columns.Add("col_4", System.Type.GetType("System.String"));
                lineTable.Columns.Add("col_5", System.Type.GetType("System.String"));

                DataRow col1 = lineTable.NewRow();

                col1["line_id"] = 1;
                col1["col_1"] = "_________________________";
                col1["col_2"] = "_________________________";
                col1["col_3"] = "_________________________";
                col1["col_4"] = "_________________________";
                col1["col_5"] = "_________________________";

                lineTable.Rows.Add(col1);

                DataRow col2 = lineTable.NewRow();

                col2["line_id"] = 2;
                col2["col_1"] = "_________________________";
                col2["col_2"] = "_________________________";
                col2["col_3"] = "_________________________";
                col2["col_4"] = String.Empty;
                col2["col_5"] = String.Empty;

                lineTable.Rows.Add(col2);

                DataRow col3 = lineTable.NewRow();

                col3["line_id"] = 3;
                col3["col_1"] = "_________________________";
                col3["col_2"] = "_________________________";
                col3["col_3"] = String.Empty;
                col3["col_4"] = String.Empty;
                col3["col_5"] = String.Empty;

                lineTable.Rows.Add(col3);

                DataRow col4 = lineTable.NewRow();

                col4["line_id"] = 4;
                col4["col_1"] = "_________________________";
                col4["col_2"] = String.Empty;
                col4["col_3"] = String.Empty;
                col4["col_4"] = String.Empty;
                col4["col_5"] = String.Empty;

                lineTable.Rows.Add(col4);

                DataRow col5 = lineTable.NewRow();

                col5["line_id"] = 5;
                col5["col_1"] = String.Empty;
                col5["col_2"] = String.Empty;
                col5["col_3"] = "_________________________";
                col5["col_4"] = String.Empty;
                col5["col_5"] = String.Empty;

                lineTable.Rows.Add(col5);
                //-------------------------

                DataTable clearanceTable = new DataTable("ClearanceTable");
                clearanceTable.Columns.Add("course_group_id", System.Type.GetType("System.String"));
                clearanceTable.Columns.Add("line_id", System.Type.GetType("System.Byte"));
                clearanceTable.Columns.Add("col_1", System.Type.GetType("System.String"));
                clearanceTable.Columns.Add("col_2", System.Type.GetType("System.String"));
                clearanceTable.Columns.Add("col_3", System.Type.GetType("System.String"));
                clearanceTable.Columns.Add("col_4", System.Type.GetType("System.String"));
                clearanceTable.Columns.Add("col_5", System.Type.GetType("System.String"));
                //--------------------------

                foreach (DataRow groupRow in _classDataSet.Tables["CourseGroupTable"].Rows)
                {
                    if (CommonExchange.CourseGroupId.College == RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "") ||
                        CommonExchange.CourseGroupId.GraduateSchoolDoctorate == RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", ""))
                    {
                        DataRow row2 = clearanceTable.NewRow();

                        row2["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                        row2["line_id"] = 1;
                        row2["col_1"] = "Library";
                        row2["col_2"] = "Registrar";
                        row2["col_3"] = "Athletic & Prop. Custodian";
                        row2["col_4"] = "Student Affairs Chairperson";
                        row2["col_5"] = "Clinic";

                        clearanceTable.Rows.Add(row2);

                        DataRow row3 = clearanceTable.NewRow();

                        row3["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                        row3["line_id"] = 1;
                        row3["col_1"] = "Adviser / Coordinator";
                        row3["col_2"] = "Guidance";
                        row3["col_3"] = "Christian Formation Office";
                        row3["col_4"] = "Dean";
                        row3["col_5"] = "Finance Officer";

                        clearanceTable.Rows.Add(row3);

                        DataRow row4 = clearanceTable.NewRow();

                        row4["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                        row4["line_id"] = 4;
                        row4["col_1"] = "Alumni Director";
                        row4["col_2"] = String.Empty;
                        row4["col_3"] = String.Empty;
                        row4["col_4"] = String.Empty;
                        row4["col_5"] = String.Empty;

                        clearanceTable.Rows.Add(row4);

                        DataRow row6 = clearanceTable.NewRow();

                        row6["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                        row6["line_id"] = 5;
                        row6["col_1"] = String.Empty;
                        row6["col_2"] = String.Empty;
                        row6["col_3"] = "President";
                        row6["col_4"] = String.Empty;
                        row6["col_5"] = String.Empty;

                        clearanceTable.Rows.Add(row6);
                    }
                    else if (CommonExchange.CourseGroupId.HighSchool == RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", ""))
                    {
                        DataRow row2 = clearanceTable.NewRow();

                        row2["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                        row2["line_id"] = 1;
                        row2["col_1"] = "Religion";
                        row2["col_2"] = "Filipino";
                        row2["col_3"] = "Aral. Pan.";
                        row2["col_4"] = "English";
                        row2["col_5"] = "Science";

                        clearanceTable.Rows.Add(row2);

                        DataRow row4 = clearanceTable.NewRow();

                        row4["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                        row4["line_id"] = 1;
                        row4["col_1"] = "Math";
                        row4["col_2"] = "T.L.E";
                        row4["col_3"] = "MAPEH/CAT";
                        row4["col_4"] = "Club Mederator";
                        row4["col_5"] = "HS Librarian";

                        clearanceTable.Rows.Add(row4);

                        DataRow row6 = clearanceTable.NewRow();

                        row6["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                        row6["line_id"] = 1;
                        row6["col_1"] = "Guidance Counselor";
                        row6["col_2"] = "Club & Orgs. In-Charge";
                        row6["col_3"] = "Class Treasurer";
                        row6["col_4"] = "Class Adviser";
                        row6["col_5"] = "Homeroom In-Charge";

                        clearanceTable.Rows.Add(row6);

                        DataRow row8 = clearanceTable.NewRow();

                        row8["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                        row8["line_id"] = 2;
                        row8["col_1"] = "Science Lab. In-Charge";
                        row8["col_2"] = "Finance Officer";
                        row8["col_3"] = "Alumni Director";
                        row8["col_4"] = String.Empty;
                        row8["col_5"] = String.Empty;

                        clearanceTable.Rows.Add(row8);

                        DataRow row10 = clearanceTable.NewRow();

                        row10["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                        row10["line_id"] = 5;
                        row10["col_1"] = String.Empty;
                        row10["col_2"] = String.Empty;
                        row10["col_3"] = "High School Principal";
                        row10["col_4"] = String.Empty;
                        row10["col_5"] = String.Empty;

                        clearanceTable.Rows.Add(row10);
                    }
                    else if (CommonExchange.CourseGroupId.GradeSchoolKinder == RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", ""))
                    {
                        DataRow row2 = clearanceTable.NewRow();

                        row2["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                        row2["line_id"] = 1;
                        row2["col_1"] = "Religion";
                        row2["col_2"] = "English";
                        row2["col_3"] = "Math";
                        row2["col_4"] = "Filipino";
                        row2["col_5"] = "Science";

                        clearanceTable.Rows.Add(row2);

                        DataRow row4 = clearanceTable.NewRow();

                        row4["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                        row4["line_id"] = 1;
                        row4["col_1"] = "Sibika/HEKASI";
                        row4["col_2"] = "Computer";
                        row4["col_3"] = "MAPE";
                        row4["col_4"] = "HELE";
                        row4["col_5"] = "Class Treasurer";

                        clearanceTable.Rows.Add(row4);

                        DataRow row6 = clearanceTable.NewRow();

                        row6["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                        row6["line_id"] = 1;
                        row6["col_1"] = "AVR In-Charge";
                        row6["col_2"] = "H.E In-Charge";
                        row6["col_3"] = "Guidance In-Charge";
                        row6["col_4"] = "Secretary";
                        row6["col_5"] = "Librarian";

                        clearanceTable.Rows.Add(row6);

                        DataRow row8 = clearanceTable.NewRow();

                        row8["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                        row8["line_id"] = 2;
                        row8["col_1"] = "Class Adviser";
                        row8["col_2"] = "Finance Officer";
                        row8["col_3"] = "Alumni Director";
                        row8["col_4"] = String.Empty;
                        row8["col_5"] = String.Empty;

                        clearanceTable.Rows.Add(row8);

                        DataRow row10 = clearanceTable.NewRow();

                        row10["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                        row10["line_id"] = 5;
                        row10["col_1"] = String.Empty;
                        row10["col_2"] = String.Empty;
                        row10["col_3"] = "Grade School Principal";
                        row10["col_4"] = String.Empty;
                        row10["col_5"] = String.Empty;

                        clearanceTable.Rows.Add(row10);
                    }
                }

                using (ClassCashieringManager.CrystalReport.CrystalStudentStatementOfAccountForFinals rptStudentStatementOfAccountForFinals =
                    new FinanceServices.ClassCashieringManager.CrystalReport.CrystalStudentStatementOfAccountForFinals())
                {
                    rptStudentStatementOfAccountForFinals.Database.Tables["student_table"].SetDataSource(pStudentTable);
                    rptStudentStatementOfAccountForFinals.Database.Tables["subject_schedule_details_table"].SetDataSource(pSubjecScheduleTable);
                    rptStudentStatementOfAccountForFinals.Database.Tables["charges_summary_table"].SetDataSource(chargesSummaryTable);
                    rptStudentStatementOfAccountForFinals.Database.Tables["exam_table"].SetDataSource(examTable);
                    rptStudentStatementOfAccountForFinals.Database.Tables["amount_due_table"].SetDataSource(amountDueTable);
                    rptStudentStatementOfAccountForFinals.Database.Tables["clearance_table"].SetDataSource(clearanceTable);
                    rptStudentStatementOfAccountForFinals.Database.Tables["line_table"].SetDataSource(lineTable);

                    rptStudentStatementOfAccountForFinals.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                    rptStudentStatementOfAccountForFinals.SetParameterValue("@form_name", "Student Statement of Account");
                    rptStudentStatementOfAccountForFinals.SetParameterValue("@print_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
                        DateTime.Parse(_serverDateTime).ToShortTimeString() + "         Printed by: " +
                        RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                        userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));

                    using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptStudentStatementOfAccountForFinals))
                    {
                        frmViewer.Text = "   Student Statement of Account";
                        frmViewer.ShowDialog();
                    }
                }
            }
        }//--------------------------

        //this procedure will insert miscellaneouse income
        public void InsertMiscellaneouseIncome(CommonExchange.SysAccess userInfo, CommonExchange.MiscellaneousIncome miscellaneousIncomeInfo)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                remClient.InsertMiscellaneousIncome(userInfo, miscellaneousIncomeInfo);
            }
        }//-------------------------

        //this procedure will update miscellaneouse income
        public void UpdateMiscellaneouseIncome(CommonExchange.SysAccess userInfo, CommonExchange.MiscellaneousIncome miscellaneousIncomeInfo)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                remClient.UpdateMiscellaneousIncome(userInfo, miscellaneousIncomeInfo);
            }
        }//-----------------------------

        //this procedure will delete miscellaneouse income
        public void DeleteMiscellaneouseIncome(CommonExchange.SysAccess userInfo, CommonExchange.MiscellaneousIncome miscellaneouseIncomeInfo)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                remClient.DeleteMiscellaneousIncome(userInfo, miscellaneouseIncomeInfo);
            }
        }//----------------------------

        //this procedure will insert canceled recept
        public void InsertCancelledReceiptNo(CommonExchange.SysAccess userInfo, CommonExchange.CancelledReceiptNo receiptNoInfo)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                remClient.InsertCancelledReceiptNo(userInfo, receiptNoInfo);
            }
        }//-----------------------------

        //this procedure will update canceled recept
        public void UpdateCancelledReceiptNo(CommonExchange.SysAccess userInfo, CommonExchange.CancelledReceiptNo receiptNoInfo)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                remClient.UpdateCancelledReceiptNo(userInfo, receiptNoInfo);
            }
        }//-----------------------------

        //this procedure will delete canceled recept
        public void DeleteCancelledReceiptNo(CommonExchange.SysAccess userInfo, CommonExchange.CancelledReceiptNo receiptNoInfo)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                remClient.DeleteCancelledReceiptNo(userInfo, receiptNoInfo);
            }
        }//-----------------------------

        //this procedure will delete subject schedule permanently
        public void DeleteSubjectSchedulePermanetly(CommonExchange.SysAccess userInfo, CommonExchange.StudentEnrolmentLevel enrolmentLevelInfo, String sysIdSchedule)
        {
            Int32 indexDel = 0;

            foreach (DataRow loadRow in _prematureDeloadedSubjectTable.Rows)
            {
                if (loadRow.RowState != DataRowState.Deleted &&
                    String.Equals(sysIdSchedule, RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "sysid_schedule", "")))
                {
                    DataRow delRow = _prematureDeloadedSubjectTable.Rows[indexDel];

                    if (delRow.RowState == DataRowState.Modified || delRow.RowState == DataRowState.Added)
                    {
                        delRow.AcceptChanges();
                    }

                    delRow.Delete();

                    break;
                }

                indexDel++;
            }

            using (RemoteClient.RemCntStudentEnrolmentManager remClient = new RemoteClient.RemCntStudentEnrolmentManager())
            {              
                //CREATE temporary student load table for inserting and deleting
                DataTable tempStudentLoadTable = new DataTable("TempStudentLoadTable");
                tempStudentLoadTable.Columns.Add("load_id", System.Type.GetType("System.Int64"));
                tempStudentLoadTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));
                tempStudentLoadTable.Columns.Add("sysid_schedule", System.Type.GetType("System.String"));
                tempStudentLoadTable.Columns.Add("is_loaded", System.Type.GetType("System.String"));
                //END CREATE---------------------------

                Int32 index = 0;

                foreach (DataRow loadRow in _prematureDeloadedSubjectTable.Rows)
                {
                    if (loadRow.RowState == DataRowState.Deleted)
                    {
                        DataRow newRow = tempStudentLoadTable.NewRow();

                        newRow["load_id"] = Int64.Parse(loadRow["load_id", DataRowVersion.Original].ToString());
                        newRow["sysid_enrolmentlevel"] = enrolmentLevelInfo.EnrolmentLevelSysId;
                        newRow["sysid_schedule"] = loadRow["sysid_schedule", DataRowVersion.Original].ToString();
                        newRow["is_loaded"] = false;

                        tempStudentLoadTable.Rows.Add(newRow);

                        DataRow delRow = tempStudentLoadTable.Rows[index];

                        delRow.AcceptChanges();

                        delRow.Delete();

                        index++;
                    }
                }

                using (RemoteClient.RemCntStudentLoadingManager remLoading = new RemoteClient.RemCntStudentLoadingManager())
                {
                    remLoading.InsertUpdateDeleteStudentLoad(userInfo, tempStudentLoadTable);
                }

                _studentLoadTable.Rows.Clear();
                _prematureDeloadedSubjectTable.Rows.Clear();
            }
        }//--------------------------------

        //this procedure will insert student payment
        public void InsertStudentPayment(CommonExchange.SysAccess userInfo, CommonExchange.StudentPayments studentPaymentInfo)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                remClient.InsertStudentPayments(userInfo, studentPaymentInfo);
            }
        }//-----------------------

        //this procedure will update student payment
        public void UpdateStudentPayment(CommonExchange.SysAccess userInfo, CommonExchange.StudentPayments studentPaymentInfo)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                remClient.UpdateStudentPayments(userInfo, studentPaymentInfo);
            }
        }//---------------------------

        //this procedure will delete student payment
        public void DeleteStudentPayment(CommonExchange.SysAccess userInfo, CommonExchange.StudentPayments studentPaymentInfo)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                remClient.DeleteStudentPayments(userInfo, studentPaymentInfo);
            }
        }//-------------------------

        //this procedure will insert student reimbursement
        public void InsertStudentReimbursement(CommonExchange.SysAccess userInfo, CommonExchange.StudentReimbursements studentReimbursementInfo)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                remClient.InsertStudentReimbursements(userInfo, studentReimbursementInfo);
            }

        }//-------------------

        //this procedure will update student reimbursement
        public void UpdateStudentReimbursements(CommonExchange.SysAccess userInfo, CommonExchange.StudentReimbursements studentReimbursements)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                remClient.UpdateStudentReimbursements(userInfo, studentReimbursements);
            }
        }//--------------------------

        //this procedure will delete student reimbursement
        public void DeleteStudentReimbursements(CommonExchange.SysAccess userInfo, CommonExchange.StudentReimbursements studentReimbursements)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                remClient.DeleteStudentReimbursements(userInfo, studentReimbursements);
            }
        }//--------------------------


        //this procedure will insert student credit memo
        public void InsertStudentCreditMemo(CommonExchange.SysAccess userInfo, CommonExchange.StudentCreditMemo studentCreditMemo)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                remClient.InsertStudentCreditMemo(userInfo, studentCreditMemo);
            }
        }//----------------------------

        //this procedure will update student credit memo
        public void UpdateStudentCreditMemo(CommonExchange.SysAccess userInfo, CommonExchange.StudentCreditMemo studentCreditMemo)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                remClient.UpdateStudentCreditMemo(userInfo, studentCreditMemo);
            }
        }//-------------------------

        //this procedure will delete student credit memo
        public void DeleteStudentCreditMemo(CommonExchange.SysAccess userInfo, CommonExchange.StudentCreditMemo studentCreditMemo)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                remClient.DeleteStudentCreditMemo(userInfo, studentCreditMemo);
            }
        }//-------------------------

        //this procedure will insert student discount
        public void InsertStudentDiscount(CommonExchange.SysAccess userInfo, CommonExchange.StudentDiscounts studentDiscountInfo)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                remClient.InsertStudentDiscounts(userInfo, studentDiscountInfo);
            }           
        }//-------------------

        //this procedure will insert student scholarship information and student discount
        public void InsertStudentScholarshipInformationStudentDiscount(CommonExchange.SysAccess userInfo,
            CommonExchange.StudentScholarship studentScholarshipInfo, CommonExchange.StudentDiscounts studentDiscountInfo)
        {

            using (RemoteClient.RemCntScholarshipManager remClient = new RemoteClient.RemCntScholarshipManager())
            {
                remClient.InsertStudentScholarship(userInfo, ref studentScholarshipInfo);

                using (RemoteClient.RemCntCashieringManager remClientCashiering = new RemoteClient.RemCntCashieringManager())
                {
                    studentDiscountInfo.StudentScholarshipInfo = studentScholarshipInfo;

                    remClientCashiering.InsertStudentDiscounts(userInfo, studentDiscountInfo);
                }  
            }
        }//---------------------

        //this procedure will insert student additional fee
        public void InsertStudentAdditionalFee(CommonExchange.SysAccess userInfo, CommonExchange.StudentAdditionalFee studentAdditionalFeeInfo)
        {
            using (RemoteClient.RemCntSchoolFeeManager remClient = new RemoteClient.RemCntSchoolFeeManager())
            {
                remClient.InsertStudentAdditionalFee(userInfo, studentAdditionalFeeInfo);
            }
        }//-----------------------------        

        //this procedure will insert multiple student additional fee
        public void InsertStudentAdditionalFee(CommonExchange.SysAccess userInfo)
        {
            using (RemoteClient.RemCntSchoolFeeManager remClient = new RemoteClient.RemCntSchoolFeeManager())
            {
                remClient.InsertStudentAdditionalFeeTable(userInfo, _additionalFeeTable);
            }
        }//-----------------------

        //this procedure will Insert additional fee to data table
        public void InsertAdditionalFeeCached(String enrolmentLevelSysId, String sysIdFeeParticular, Decimal amount, String remarks)
        {
            if (_studentTableMultiple != null)
            {
                String strFilter = "sysid_enrolmentlevel = '" + enrolmentLevelSysId + "'";
                DataRow[] selectRow = _studentTableMultiple.Select(strFilter);

                foreach (DataRow studRow in selectRow)
                {
                    if (studRow.RowState != DataRowState.Deleted)
                    {
                        DataRow newRow = _additionalFeeTable.NewRow();

                        newRow["sysid_enrolmentlevel"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", "");
                        newRow["sysid_feeparticular"] = sysIdFeeParticular;
                        newRow["amount"] = amount;
                        newRow["remarks"] = remarks;

                        _additionalFeeTable.Rows.Add(newRow);

                        break;
                    }
                }
            }
        }//-------------------

        //this procedure will Insert student Balance Forwarded
        public void InsertStudentBalanceForwarded(CommonExchange.SysAccess userInfo, CommonExchange.StudentBalanceForwarded studentBalanceForwardedInfo)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                remClient.InsertUpdateStudentBalanceForwarded(userInfo, studentBalanceForwardedInfo);
            }

            if (_balanceForwardedTable != null && _balanceForwardedTable.Rows.Count >= 1)
            {
                DataRow editRow = _balanceForwardedTable.Rows[0];

                editRow.BeginEdit();

                editRow["amount"] = studentBalanceForwardedInfo.Amount;

                editRow.EndEdit();

                _balanceForwardedTable.AcceptChanges();
            }
        }//-------------------------

        //this procedure will Delete student Balance Forwarded
        public void DeleteStudentBalanceForwarded(CommonExchange.SysAccess userInfo, CommonExchange.StudentBalanceForwarded studentBalanceForwardedInfo)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                remClient.DeleteStudentBalanceForwarded(userInfo, studentBalanceForwardedInfo);
            }

            if (_balanceForwardedTable != null && _balanceForwardedTable.Rows.Count >= 1)
            {
                DataRow editRow = _balanceForwardedTable.Rows[0];

                editRow.BeginEdit();

                editRow["amount"] = 0;

                editRow.EndEdit();

                _balanceForwardedTable.AcceptChanges();
            }
        }//-------------------------
        
        //this procedure will update student additional fee
        public void UpdateStudentAdditionalFee(CommonExchange.SysAccess userInfo, CommonExchange.StudentAdditionalFee studentAdditionalFeeInfo, 
            Boolean isForMultipleUpdate)
        {
            using (RemoteClient.RemCntSchoolFeeManager remClient = new RemoteClient.RemCntSchoolFeeManager())
            {
                remClient.UpdateStudentAdditionalFee(userInfo, studentAdditionalFeeInfo);
            }

            if (!isForMultipleUpdate)
            {
                Int32 index = 0;
                foreach (DataRow feeRow in _schoolFeeDetailsTableCurrentCharge.Rows)
                {
                    if (feeRow.RowState != DataRowState.Deleted && (studentAdditionalFeeInfo.AdditionalFeeId ==
                        RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "additional_fee_id", Int64.Parse("0"))))
                    {
                        DataRow editRow = _schoolFeeDetailsTableCurrentCharge.Rows[index];

                        editRow.BeginEdit();

                        editRow["amount"] = studentAdditionalFeeInfo.Amount;
                        editRow["sysid_feeparticular"] = studentAdditionalFeeInfo.SchoolFeeParticularInfo.FeeParticularSysId;
                        editRow["particular_description"] = studentAdditionalFeeInfo.SchoolFeeParticularInfo.ParticularDescription;
                        editRow["remarks"] = studentAdditionalFeeInfo.Remarks;

                        editRow.EndEdit();

                        break;
                    }

                    index++;
                }
            }
        }//----------------------------   

        //this procedure will Insert Optional Fee
        public void InsertOptionalFee(String sysIdFeeDetails, String sysIdEnrolmentLevel)
        {
            if (_optionalSchoolFeeDetailsTable != null)
            {
                String strFilter = "sysid_feedetails = '" + sysIdFeeDetails + "'";
                DataRow[] selectRow = _optionalSchoolFeeDetailsTable.Select(strFilter);

                foreach (DataRow feeRow in selectRow)
                {
                    DataRow newRowOptional = _optionalFeeTable.NewRow();
                    DataRow newRowDetails = _schoolFeeDetailsTableCurrentCharge.NewRow();

                    newRowOptional["optional_fee_id"] = newRowDetails["optional_fee_id"] = _countOptionalFeeId--;
                    newRowOptional["sysid_enrolmentlevel"] = newRowDetails["sysid_enrolmentlevel"] = sysIdEnrolmentLevel;
                    newRowOptional["sysid_feedetails"] = newRowDetails["sysid_feedetails"] =
                        RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "sysid_feedetails", "");
                    newRowOptional["is_level_increase"] = newRowDetails["is_level_increase"] =
                        RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_level_increase", false);
                    newRowOptional["amount"] = newRowDetails["amount"] =
                        RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "amount", Decimal.Parse("0"));
                    newRowOptional["fee_category_id"] = newRowDetails["fee_category_id"] =
                        RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "fee_category_id", "");
                    newRowOptional["particular_description"] = newRowDetails["particular_description"] =
                        RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "particular_description", "");
                    newRowOptional["is_office_access"] = newRowDetails["is_office_access"] =
                        RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_office_access", false);
                    newRowOptional["is_optional_fee"] = newRowDetails["is_optional_fee"] = true;

                    _optionalFeeTable.Rows.Add(newRowOptional);
                    _schoolFeeDetailsTableCurrentCharge.Rows.Add(newRowDetails);

                    break;
                }
            }
        }//--------------------------------

        //this procedure will insert delete optional fee
        public void InsertDeleteOptionalFee(CommonExchange.SysAccess userInfo)
        {
            if (_optionalFeeTable != null)
            {
                using (RemoteClient.RemCntSchoolFeeManager remClient = new RemoteClient.RemCntSchoolFeeManager())
                {
                    remClient.InsertDeleteStudentOptionalFee(userInfo, _optionalFeeTable);

                    _optionalFeeTable.Rows.Clear();
                }
            }
        }//--------------------------
 
        //this procedure will upadate student discount
        public void UpdateStudentDiscount(CommonExchange.SysAccess userInfo, CommonExchange.StudentDiscounts studentDiscountInfo)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                remClient.UpdateStudentDiscounts(userInfo, studentDiscountInfo);
            }
        }//------------------------

        //this procedure will delete student Additional fee
        public void DeleteStudentAdditionalFee(CommonExchange.SysAccess userInfo, CommonExchange.StudentAdditionalFee studentAdditionalFeeInfo, 
            Boolean isForMulpleUpdate)
        {
            using (RemoteClient.RemCntSchoolFeeManager remClient = new RemoteClient.RemCntSchoolFeeManager())
            {
                remClient.DeleteStudentAdditionalFee(userInfo, studentAdditionalFeeInfo);
            }

            if (!isForMulpleUpdate)
            {
                Int32 index = 0;
                foreach (DataRow feeRow in _schoolFeeDetailsTableCurrentCharge.Rows)
                {
                    if (feeRow.RowState != DataRowState.Deleted && (studentAdditionalFeeInfo.AdditionalFeeId ==
                        RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "additional_fee_id", Int64.Parse("0"))))
                    {
                        DataRow delRow = _schoolFeeDetailsTableCurrentCharge.Rows[index];

                        delRow.Delete();

                        break;
                    }

                    index++;
                }
            }
        }//-------------------------

        //this procedure will insert student promissory note
        public void InsertStudentPromissoryNote(CommonExchange.SysAccess userInfo, CommonExchange.StudentPromissoryNote studentPromissoryNoteInfo)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                remClient.InsertStudentPromissoryNote(userInfo, studentPromissoryNoteInfo);
            }            
        }//-------------------------

        //this procedure will update student promissory note
        public void UpdateStudentPromissoryNote(CommonExchange.SysAccess userInfo, CommonExchange.StudentPromissoryNote studentPromissoryNoteInfo)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                remClient.UpdateStudentPromissoryNote(userInfo, studentPromissoryNoteInfo);
            }
        }//-------------------------

        //this procedure will delete student promissory note
        public void DeleteStudentPromissoryNote(CommonExchange.SysAccess userInfo, CommonExchange.StudentPromissoryNote studentPromissoryNoteInfo)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                remClient.DeleteStudentPromissoryNote(userInfo, studentPromissoryNoteInfo);
            }
        }//--------------------------

        //this procedure will delete student discount 
        public void DeleteStudentDiscount(CommonExchange.SysAccess userInfo, CommonExchange.StudentDiscounts studentDiscountInfo)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                remClient.DeleteStudentDiscounts(userInfo, studentDiscountInfo);
            }
        }//------------------------

        //this procedure deletes a special class information
        public void DeleteSpecialClassInformation(CommonExchange.SysAccess userInfo, Int64 loadId)
        {
            //gets the special class by date start and date end
            using (RemoteClient.RemCntSpecialClassManager remClient = new RemoteClient.RemCntSpecialClassManager())
            {
                remClient.DeleteSpecialClassLoad(userInfo, loadId);
            } //-----------------------           
        } //----------------------------

        //this procedure will update student enrollment record
        public void UpdateStudentEnrollmentLevel(CommonExchange.SysAccess userInfo, CommonExchange.StudentEnrolmentLevel enrolmentLevelInfo)
        {
            using (RemoteClient.RemCntStudentEnrolmentManager remClient = new RemoteClient.RemCntStudentEnrolmentManager())
            {
                remClient.UpdateStudentEnrolmentLevel(userInfo, enrolmentLevelInfo);
            }
        }//----------------------------

        //this procedure will insert break down banck deposit
        public void InsertBreakdownBankDeposit(CommonExchange.SysAccess userInfo, CommonExchange.BreakdownBankDeposit breakdownDeposit)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                remClient.InsertBreakdownBankDeposit(userInfo, breakdownDeposit);
            }
        }//--------------------------

        //this procedure will update break down deposit
        public void UpdateBreakdownBankDeposit(CommonExchange.SysAccess userInfo, CommonExchange.BreakdownBankDeposit breakdownDeposit)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                remClient.UpdateBreakdownBankDeposit(userInfo, breakdownDeposit);
            }
        }//--------------------------

        //this procedure will delete break down deposit
        public void DeleteBreakdownBankDeposit(CommonExchange.SysAccess userInfo, CommonExchange.BreakdownBankDeposit breakdownDeposit)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                remClient.DeleteBreakdownBankDeposit(userInfo, breakdownDeposit);
            }
        }//--------------------------


        //this procedure refreshes the data
        public void RefreshStudentData(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);
        }//-------------------------------

        //this procedure get the student promissory notes
        public void SelectBySysIDStudentListDateStartEndStudentPromissoryNote(CommonExchange.SysAccess userInfo, String studentSysIdList,
            String dateStart, String dateEnd)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                _studentPromissoryNoteTable = remClient.SelectBySysIDStudentListDateStartEndStudentPromissoryNote(userInfo, studentSysIdList,
                    DateTime.Parse(dateStart).AddMonths( - (Int32)CommonExchange.SystemRange.MonthAllowance).ToString(), dateEnd, _serverDateTime);
            }
        }//----------------------------

        //this procedure gets the student enrolment course by student system id date start and date end
        public void SelectBySysIDStudentDateStartEndStudentEnrolmentCourse(CommonExchange.SysAccess userInfo,
            String studentSysId, String dateStart, String dateEnd)
        {
            using (RemoteClient.RemCntStudentEnrolmentManager remClient = new RemoteClient.RemCntStudentEnrolmentManager())
            {
                _studentCourseTable = remClient.SelectBySysIDStudentDateStartEndStudentEnrolmentCourse(userInfo, studentSysId, dateStart, dateEnd);
            }
        }//--------------------------

        //this procedure gets the student enrolment level by student system id, year id, semester id, ismarked deleted level
        public void SelectBySysIDStudentYearIDSemesterStudentEnrolmentLevel(CommonExchange.SysAccess userInfo, String studentSysId,
            String yearId, String sysIdSemester, String sysIdEnrolmentCourse, String enrolmentLevelSysIdExcludeList)
        {
            using (RemoteClient.RemCntStudentEnrolmentManager remClient = new RemoteClient.RemCntStudentEnrolmentManager())
            {
                _studentLevelTable = remClient.SelectBySysIDStudentYearIDSemesterStudentEnrolmentLevel(userInfo, studentSysId, yearId,
                    sysIdSemester, sysIdEnrolmentCourse, false, true, enrolmentLevelSysIdExcludeList);
            }
        }//----------------------------

        //this procedure will get student payment, discount and reimbursement table by studentlist, dataStart, dateEnd, serverDateTime
        public void SelectBySysIDStudentListDateStartEndStudentPaymentsDiscountsReimbursement(CommonExchange.SysAccess userInfo, String studentSysIdList,
            String dateStart, String dateEnd)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                _paymentReimbursementTable = remClient.SelectBySysIDStudentListDateStartEndStudentPaymentsDiscountsReimbursement(userInfo, 
                    studentSysIdList, dateStart, dateEnd, _serverDateTime);
            }
        }//---------------------------------

        //this procedure get the special class by student by date start date end
        public void SelectBySysIDStudentListDateStartEndSpecialClassInformation(CommonExchange.SysAccess userInfo, String studentSysIdList,
            String dateStart, String dateEnd)
        {
            using (RemoteClient.RemCntSpecialClassManager remClient = new RemoteClient.RemCntSpecialClassManager())
            {
                _specialClassTable = remClient.SelectBySysIDStudentListDateStartEndSpecialClassInformation(userInfo, studentSysIdList, dateStart,
                    dateEnd, _serverDateTime);
            }
        }//----------------------------------

        //this procedure will select cash receipts details information
        public void SelectByDateStartEndCashReceiptsDetailedStudentPaymentMiscellaneousIncome(CommonExchange.SysAccess userInfo,
            String dateStart, String dateEnd, Boolean isConsolidated)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                _cashReceiptDetailsTable = remClient.SelectByDateStartEndCashReceiptsDetailedStudentPaymentMiscellaneousIncome(userInfo, dateStart, dateEnd,
                    isConsolidated, this.ServerDateTime);
            }
        }//--------------------------

        //this procedure will select cash receipts details information
        public void SelectByDateStartEndCashDiscountsStudentPaymentMiscellaneousIncome(CommonExchange.SysAccess userInfo,
            String dateStart, String dateEnd, Boolean isConsolidated)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                _cashDiscountsTable = remClient.SelectByDateStartEndCashDiscountsStudentPaymentMiscellaneousIncome(userInfo, dateStart, dateEnd,
                    isConsolidated, this.ServerDateTime);
            }
        }//--------------------------

        //this procedure will select break down bank deposit details
        public void SelectByDateStartEndCashReceiptsDetailedBreakdownBankDeposit(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd, Boolean isConsolidated)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                _breakDownBankDepositDetailsTable = remClient.SelectByDateStartEndCashReceiptsDetailedBreakdownBankDeposit(userInfo, dateStart, dateEnd, 
                    isConsolidated, this.ServerDateTime);
            }
        }//------------------

        //this procedure will select summariezed cash recepts information
        public void SelectByDateStartEndCashReceiptsSummarizedStudentPaymentMiscellaneousIncome(CommonExchange.SysAccess userInfo,
            String dateStart, String dateEnd, Boolean isConsolidated)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                _summariezedCashReceiptTable = remClient.SelectByDateStartEndCashReceiptsSummarizedStudentPaymentMiscellaneousIncome(userInfo,
                    dateStart, dateEnd, isConsolidated);
            }
        }//-------------------------

        //this procedure will select break down bank deposit summarized
        public void SelectByDateStartEndCashReceiptsSummarizedBreakdownBankDeposit(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd, Boolean isConsolidated)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                _breakDownBackDepositeSummarizedTable = remClient.SelectByDateStartEndCashReceiptsSummarizedBreakdownBankDeposit(userInfo, dateStart, dateEnd, isConsolidated);
            }
        }//-----------------------

        //this procedure gets the subject schedule student load by date start end
        public void SelectBySysIDEnrolmentLevelDateStartEndSubjectScheduleStudentLoad(CommonExchange.SysAccess userInfo, String studentSysId,
            String enrolmentLevelSysId, String feelevelSysId, String semesterSysId, Boolean isGraduateStudent, Boolean isInternational,
            Boolean isEnrolled, String dateStart, String dateEnd)
        {
            using (RemoteClient.RemCntStudentLoadingManager remClient = new RemoteClient.RemCntStudentLoadingManager())
            {
                _subjectScheduleTable = remClient.SelectBySysIDEnrolmentLevelDateStartEndSubjectScheduleStudentLoad(userInfo, studentSysId, enrolmentLevelSysId,
                    feelevelSysId, semesterSysId, isGraduateStudent, isInternational, isEnrolled, true, dateStart, dateEnd, _serverDateTime);
            }

            foreach (DataRow schedRow in _subjectScheduleTable.Rows)
            {
                Boolean isLoadedToStudent = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "is_loaded_to_student", false);
                Boolean isPrematureDeloaded = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "is_premature_deloaded", false);

                if (isLoadedToStudent && !isPrematureDeloaded)
                {
                    DataRow newRowStudentLoad = _studentLoadTable.NewRow();

                    newRowStudentLoad["load_id"] = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "load_id", Int64.Parse("0"));
                    newRowStudentLoad["sysid_schedule"] = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_schedule", "");
                    newRowStudentLoad["is_loaded"] = true;
                    newRowStudentLoad["is_premature_deloaded"] = isPrematureDeloaded;

                    foreach (DataRow levelRow in _studentLevelTable.Rows)
                    {
                        if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "sysid_enrolmentlevel", "")))
                        {
                            newRowStudentLoad["sysid_enrolmentlevel"] = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "sysid_enrolmentlevel", "");

                            break;
                        }
                    }

                    _studentLoadTable.Rows.Add(newRowStudentLoad);
                }
                else if (isLoadedToStudent && isPrematureDeloaded)
                {
                    DataRow newRow = _prematureDeloadedSubjectTable.NewRow();

                    newRow["load_id"] = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "load_id", Int64.Parse("0"));
                    newRow["sysid_schedule"] = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_schedule", "");
                    newRow["sysid_subject"] = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_subject", "");
                    newRow["is_loaded_to_student"] = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "is_loaded_to_student", false);

                    _prematureDeloadedSubjectTable.Rows.Add(newRow);
                }
            }
        }//-----------------------------

        //this procedure get the school fee details by student, fee level, semester and is graduating student
        public void SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoadCharges(CommonExchange.SysAccess userInfo, String studentSysId,
            String enrolmentLevelSysId, String feelevelSysId, String semesterSysId, Boolean isGraduateStudent, Boolean isInternational,
            Boolean isEnrolled, Boolean isMarkedDeleted, Boolean isPreviousCharge, Boolean forCurrentCharge)
        {
            using (RemoteClient.RemCntStudentLoadingManager remClient = new RemoteClient.RemCntStudentLoadingManager())
            {
                if (forCurrentCharge)
                {
                    _schoolFeeDetailsTableCurrentCharge = remClient.SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoad(userInfo, 
                        studentSysId, enrolmentLevelSysId,
                        feelevelSysId, semesterSysId, isGraduateStudent, isInternational, isEnrolled, isMarkedDeleted, isPreviousCharge);

                    foreach (DataRow feeRow in _schoolFeeDetailsTableCurrentCharge.Rows)
                    {
                        if (feeRow.RowState != DataRowState.Deleted)
                        {
                            String strFilter = "optional_fee_id = " + RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "optional_fee_id", Int64.Parse("0"));
                            DataRow[] selectRow = _optionalFeeTable.Select(strFilter);

                            if (RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_optional_fee", false) && selectRow.Length == 0)
                            {
                                DataRow newRow = _optionalFeeTable.NewRow();

                                newRow["optional_fee_id"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "optional_fee_id", Int64.Parse("0"));
                                newRow["sysid_enrolmentlevel"] = enrolmentLevelSysId;
                                newRow["sysid_feedetails"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "sysid_feedetails", "");
                                newRow["is_level_increase"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_level_increase", false);
                                newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "amount", Decimal.Parse("0"));
                                newRow["fee_category_id"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "fee_category_id", "");
                                newRow["particular_description"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "particular_description", "");
                                newRow["is_office_access"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_office_access", false);
                                newRow["is_optional_fee"] = true;

                                _optionalFeeTable.Rows.Add(newRow);
                            }
                        }
                    }

                    Int32 index = 0;

                    foreach (DataRow optionalFeeRow in _optionalFeeTable.Rows)
                    {
                        if (optionalFeeRow.RowState != DataRowState.Deleted &&
                            RemoteServerLib.ProcStatic.DataRowConvert(optionalFeeRow, "optional_fee_id", Int64.Parse("0")) <= 0)
                        {
                            DataRow newRowDetails = _schoolFeeDetailsTableCurrentCharge.NewRow();

                            newRowDetails["optional_fee_id"] = RemoteServerLib.ProcStatic.DataRowConvert(optionalFeeRow, "optional_fee_id", Int64.Parse("0"));
                            newRowDetails["sysid_enrolmentlevel"] = RemoteServerLib.ProcStatic.DataRowConvert(optionalFeeRow, "sysid_enrolmentlevel", "");
                            newRowDetails["sysid_feedetails"] = RemoteServerLib.ProcStatic.DataRowConvert(optionalFeeRow, "sysid_feedetails", "");
                            newRowDetails["is_level_increase"] = RemoteServerLib.ProcStatic.DataRowConvert(optionalFeeRow, "is_level_increase", false);
                            newRowDetails["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(optionalFeeRow, "amount", Decimal.Parse("0"));
                            newRowDetails["fee_category_id"] = RemoteServerLib.ProcStatic.DataRowConvert(optionalFeeRow, "fee_category_id", "");
                            newRowDetails["particular_description"] = RemoteServerLib.ProcStatic.DataRowConvert(optionalFeeRow, "particular_description", "");
                            newRowDetails["is_office_access"] = RemoteServerLib.ProcStatic.DataRowConvert(optionalFeeRow, "is_office_access", false);
                            newRowDetails["is_optional_fee"] = true;

                            _schoolFeeDetailsTableCurrentCharge.Rows.Add(newRowDetails);
                        }
                        else if (optionalFeeRow.RowState != DataRowState.Deleted)
                        {
                            DataRow accptRow = _optionalFeeTable.Rows[index];

                            accptRow.AcceptChanges();
                        }

                        index++;
                    }
                }
                else
                {
                    _schoolFeeDetailsTableWithdrawCharge = remClient.SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoad(userInfo, 
                        studentSysId, enrolmentLevelSysId,
                       feelevelSysId, semesterSysId, isGraduateStudent, isInternational, isEnrolled, isMarkedDeleted, isPreviousCharge);
                }
            }
        }//---------------------------------
      
        //this procedure gets the balance carried forward by student list and date ending
        public void SelectBySysIDStudentListDateEndingBalanceCarriedForwardStudentLoad(CommonExchange.SysAccess userInfo, String studentSysIdList,
            String enrolmentLevelSysIdList, String dateEnding)
        {
            using (RemoteClient.RemCntStudentLoadingManager remClient = new RemoteClient.RemCntStudentLoadingManager())
            {
                _balanceForwardedTable = remClient.SelectBySysIDStudentListDateEndingBalanceCarriedForwardStudentLoad(userInfo, studentSysIdList,
                    enrolmentLevelSysIdList, dateEnding);
            }
        }//-------------------------

        //this procedure gets the student scholarship and discount table by enrolment level and serverdatetime
        public void SelectBySysIDEnrolmentLevelStudentScholarship(CommonExchange.SysAccess userInfo, String enrolmentLevelSysID)
        {
            using (RemoteClient.RemCntScholarshipManager remClient = new RemoteClient.RemCntScholarshipManager())
            {
                _studentScholarshipTable = remClient.SelectBySysIDEnrolmentLevelStudentScholarship(userInfo, enrolmentLevelSysID, _serverDateTime);
            }
        }//--------------------------

        //this procedure will get optional school fees
        public void SelectBySysIDStudentFeeLevelSemesterForOptionalFeeDetailsStudentOptionalFee(CommonExchange.SysAccess userInfo, String studentSysId,
            String feeLevelSysId, String semesterSysId, Boolean isInternational)
        {
            using (RemoteClient.RemCntSchoolFeeManager remClient = new RemoteClient.RemCntSchoolFeeManager())
            {
                _optionalSchoolFeeDetailsTable = remClient.SelectBySysIDStudentFeeLevelSemesterForOptionalFeeDetailsStudentOptionalFee(userInfo,
                    studentSysId, feeLevelSysId, semesterSysId, isInternational);
            }
        }//---------------------------

        //this procedure will intialize major exam schedule table
        public void SelectMajorExamScheduleTableForPrinting(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd,
            String courseGroupId)
        {
            DataTable tempTable = new DataTable("TempTable");

            if (courseGroupId != null)
            {
                using (RemoteClient.RemCntMajorExamScheduleManager remClient = new RemoteClient.RemCntMajorExamScheduleManager())
                {
                    tempTable = remClient.SelectMajorExamSchedule(userInfo, dateStart, dateEnd, courseGroupId, String.Empty, _serverDateTime);
                }

                _majorExamScheduleTableForPrinting.Clear();

                foreach (DataRow examRow in tempTable.Rows)
                {
                    DataRow newRow = _majorExamScheduleTableForPrinting.NewRow();

                    newRow["major_exam_id"] = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "major_exam_id", Int64.Parse("0")).ToString();

                    DateTime eDate;

                    if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_date", ""), out eDate))
                    {
                        newRow["exam_date"] = eDate.ToLongDateString();
                    }

                    newRow["exam_description"] = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_description", "") + " - " +
                        RemoteServerLib.ProcStatic.DataRowConvert(examRow, "group_description", "");
                    newRow["is_for_print"] = false;
                    newRow["is_clearance_included"] = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_clearance_included", false);
                    newRow["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "course_group_id", "");

                    _majorExamScheduleTableForPrinting.Rows.Add(newRow);
                }
            }
        }//----------------------------

         //this procedure will intialize major exam schedule table
        public void SelectMajorExamScheduleTable(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd, String courseGroupId)
        {
            if (courseGroupId != null)
            {
                using (RemoteClient.RemCntMajorExamScheduleManager remClient = new RemoteClient.RemCntMajorExamScheduleManager())
                {
                    _majorExamScheduleTable = remClient.SelectMajorExamSchedule(userInfo, dateStart, dateEnd, courseGroupId, String.Empty, _serverDateTime);
                }

                Int32 index = 0;

                foreach (DataRow examRow in _majorExamScheduleTable.Rows)
                {
                    DataRow editRow = _majorExamScheduleTable.Rows[index];

                    editRow.BeginEdit();

                    DateTime eDate;

                    if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_date", ""), out eDate))
                    {
                        editRow["exam_date"] = eDate.ToLongDateString();
                    }

                    editRow.EndEdit();

                    index++;
                }
            }
        }//----------------------------

        //this procedure gets the student enrolment course / level histroy by student system id 
        public void SelectBySysIDStudentForEnrolmentHistoryEnrolmentCourseLevel(CommonExchange.SysAccess userInfo, String studentSysId)
        {
            using (RemoteClient.RemCntStudentEnrolmentManager remClient = new RemoteClient.RemCntStudentEnrolmentManager())
            {
                _studentCourseHistoryTable = remClient.SelectBySysIDStudentForEnrolmentHistoryEnrolmentCourse(userInfo, studentSysId);

                _studentLevelHistroyTable = remClient.SelectBySysIDStudentForEnrolmentHistoryEnrolmentLevel(userInfo, studentSysId);
            }
        }//----------------------------

        //this procedure initialized the treeview control
        public void InitializeTreeViewControl(TreeView trvBase)
        {
            trvBase.Nodes.Clear();

            TreeNode courseGroupNode;
            TreeNode createdCourses;
            TreeNode createdLevel;

            Int32 x = 0;
            Int32 y = 0;

            Boolean hasCurrentCourse = false;

            foreach (DataRow groupRow in _classDataSet.Tables["CourseGroupTable"].Rows)
            {
                courseGroupNode = new TreeNode(RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "group_description", ""));

                String strFilterCourse = "course_group_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "") + "'";
                DataRow[] selectCourse = _studentCourseHistoryTable.Select(strFilterCourse);

                foreach (DataRow courseRow in selectCourse)
                {
                    createdCourses = new TreeNode(RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_title", "") + " [" +
                        this.GetSemesterDescription(RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "sysid_semester", "")) + "  " +
                        this.GetYearLevelDescription(RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "sysid_schoolfee", "")) + " ]");

                    if (RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "is_current_course", false))
                    {
                        createdCourses.ForeColor = courseGroupNode.ForeColor = Color.Red;

                        y = x;

                        hasCurrentCourse = true;
                    }

                    courseGroupNode.Nodes.Add(createdCourses);

                    String strFilterLevel = "sysid_enrolmentcourse = '" + RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "sysid_enrolmentcourse", "") + "'";
                    DataRow[] selectLevel = _studentLevelHistroyTable.Select(strFilterLevel);

                    foreach (DataRow levelRow in selectLevel)
                    {
                        String levelInfo = this.GetSemesterDescription(RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "sysid_semester", "")) + " " +
                                this.GetYearLevelDescription(RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "sysid_schoolfee", "")) + "   " +
                                RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "group_description", "") + " - " +
                                RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_description", "");

                        if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "sysid_enrolmentlevel", "")))
                        {
                            Boolean isEntryLevel = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "is_entry_level", false);
                            Boolean isMarkedDeleted = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "is_marked_deleted", false);

                            String strCon = String.Empty;

                            if (isEntryLevel && !isMarkedDeleted)
                            {
                                strCon = " [Enrolled as Entry Level]";
                            }
                            else if (!isEntryLevel && isMarkedDeleted)
                            {
                                strCon = " [Withdrawn]";
                            }
                            else if (isEntryLevel && isMarkedDeleted)
                            {
                                strCon = " [Withdrawn by Finance Cashier]";
                            }
                            else if (!isEntryLevel && !isMarkedDeleted)
                            {
                                strCon = " [Enrolled]";
                            }

                            createdLevel = new TreeNode(levelInfo + strCon);

                            createdCourses.Nodes.Add(createdLevel);
                        }
                    }
                }

                if (courseGroupNode.ForeColor != Color.Red && courseGroupNode.Nodes.Count >= 1)
                {
                    courseGroupNode.ForeColor = Color.Orange;
                }

                trvBase.Nodes.Add(courseGroupNode);

                x++;
            }

            if (hasCurrentCourse)
            {
                trvBase.Nodes[y].Expand();
            }
        }//---------------------------

        //this procedure will initialize student promissory note list view
        public void InitializeStudentPromissoryNoteListView(ListView lsvBase, String sysIdStudent, TabPage tblbase)
        {
            lsvBase.Items.Clear();

            if (_studentPromissoryNoteTable != null)
            {
                String strFilter = "sysid_student = '" + sysIdStudent + "'";
                DataRow[] selectRow = _studentPromissoryNoteTable.Select(strFilter);

                foreach (DataRow noteRow in selectRow)
                {
                    if (noteRow.RowState != DataRowState.Deleted)
                    {
                        ListViewItem noteItem = new ListViewItem(new String[] {
                            RemoteServerLib.ProcStatic.DataRowConvert(noteRow, "promissory_note_id", Int64.Parse("0")).ToString(),
                            DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(noteRow, "received_date", String.Empty)).ToShortDateString(),
                            DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(noteRow, "reflected_date", String.Empty)).ToShortDateString(),
                            RemoteServerLib.ProcStatic.DataRowConvert(noteRow, "reference_no", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(noteRow, "promissory_note", String.Empty),
                            this.SetDownpaymentText(RemoteServerLib.ProcStatic.DataRowConvert(noteRow, "is_downpayment", false))});

                        this.SetListViewItemColorForIsDownpaymentIncludeInPost(RemoteServerLib.ProcStatic.DataRowConvert(noteRow, "is_downpayment", false),
                            RemoteServerLib.ProcStatic.DataRowConvert(noteRow, "is_included_in_post", false), ref noteItem);

                        lsvBase.Items.Add(noteItem);
                    }
                }
            }

            tblbase.Text = lsvBase.Items.Count > 0 ? "** Promissory Note" : "Promissory Note";
        }//-------------------------

        //this procedure initializes the school year combo box
        public void InitializeSchoolYearCombo(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            Int32 index = 0;
            Boolean isIndexed = false;

            foreach (DataRow yearRow in _classDataSet.Tables["SchoolFeeInformationTable"].Rows)
            {
                cboBase.Items.Add(yearRow["year_description"].ToString());

                if (!isIndexed)
                {
                    DateTime serverDateTime = DateTime.Parse(_serverDateTime);
                    DateTime dateStart = serverDateTime;
                    DateTime dateEnd = serverDateTime;

                    DateTime.TryParse(yearRow["date_start"].ToString(), out dateStart);
                    DateTime.TryParse(yearRow["date_end"].ToString(), out dateEnd);

                    //if ((DateTime.Compare(serverDateTime, dateStart) >= 0 && DateTime.Compare(serverDateTime, dateEnd) <= 0) ||
                    //    (DateTime.Compare(serverDateTime.AddMonths((Int32)CommonExchange.SystemRange.MonthAllowance), dateStart) >= 0 &&
                    //     DateTime.Compare(serverDateTime.AddMonths((Int32)CommonExchange.SystemRange.MonthAllowance), dateEnd) <= 0))
                    //{
                    //    cboBase.SelectedIndex = index;
                    //    isIndexed = true;
                    //}

                    if (DateTime.Compare(serverDateTime, dateStart) >= 0 && DateTime.Compare(serverDateTime, dateEnd) <= 0)
                    {
                        cboBase.SelectedIndex = index;
                        isIndexed = true;
                    }

                    index++;
                }
            }
        }//---------------------------

        //this procedure initializes the school year combo box
        public void InitializeSchoolYearComboNoSummer(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            Int32 index = 0;
            Boolean isIndexed = false;

            foreach (DataRow yearRow in _classDataSet.Tables["SchoolFeeInformationTable"].Rows)
            {
                if (!RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "is_summer", false))
                {
                    cboBase.Items.Add(yearRow["year_description"].ToString());

                    if (!isIndexed)
                    {
                        DateTime serverDateTime = DateTime.Parse(_serverDateTime);
                        DateTime dateStart = serverDateTime;
                        DateTime dateEnd = serverDateTime;

                        DateTime.TryParse(yearRow["date_start"].ToString(), out dateStart);
                        DateTime.TryParse(yearRow["date_end"].ToString(), out dateEnd);

                        if (DateTime.Compare(serverDateTime, dateStart) >= 0 && DateTime.Compare(serverDateTime, dateEnd) <= 0)
                        {
                            cboBase.SelectedIndex = index;
                            isIndexed = true;
                        }

                        index++;
                    }
                }
            }
        }//---------------------------

        //this procedure initializes the semester combo box
        public void InitializeSemesterCombo(ComboBox cboBase, Int32 yearIndex)
        {
            cboBase.Items.Clear();

            DataRow yearRow = _classDataSet.Tables["SchoolFeeInformationTable"].Rows[yearIndex];

            String strFilter = "year_id = '" + yearRow["year_id"].ToString() + "'";
            DataRow[] selectRow = _classDataSet.Tables["SemesterInformationTable"].Select(strFilter);

            foreach (DataRow semRow in selectRow)
            {
                cboBase.Items.Add(semRow["semester_description"].ToString());
            }

            cboBase.SelectedIndex = -1;
        }//-----------------------------        

        //AD Code
        //this procedure initialized the student course combo
        public void InitializedCourseCombo(ComboBox cboBaseCourse, String sysIdSemester, Boolean isSemestral)
        {
            cboBaseCourse.Items.Clear();
                               
            Boolean hasEnter = false;

            Int32 index = 0;

            if (!this.HasCurrentCourse() && _studentCourseTable.Rows.Count != 0)
            {
                cboBaseCourse.Items.Add("-- Select a Course --");
                cboBaseCourse.SelectedIndex = 0;
            }
            else if (_studentCourseTable.Rows.Count == 0)
            {
                cboBaseCourse.Items.Add("-- No course enrolled in the current school year / semester --");
                cboBaseCourse.SelectedIndex = 0;
            }
            else
            {
                cboBaseCourse.Items.Add("-- Select a Course --");
                index++;
            }

            foreach (DataRow courseRow in _studentCourseTable.Rows)
            {
                if (RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "is_current_course", false) && !hasEnter)
                {
                    cboBaseCourse.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_title", "") + "  [" +
                        RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_acronym", "") + "] - Current Course");

                    hasEnter = true;

                    cboBaseCourse.SelectedIndex = index;
                }
                else
                {
                    cboBaseCourse.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_title", "") + "  [" +
                        RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_acronym", "") + "]");
                }

                index++;
            }

            if (!hasEnter && _studentCourseTable.Rows.Count == 1)
            {
                cboBaseCourse.SelectedIndex = 1;
            }
        }//---------------------------      
        //-----------------------

        //this procedure initialized the year level combo
        public void InitializedYearLevelCombo(ComboBox cboBase, String sysIdSemester, Boolean isSemestral)
        {
            cboBase.Items.Clear();

            String enrolStatus = String.Empty;

            if (_studentLevelTable.Rows.Count >= 1)
            {
                cboBase.Items.Add("-- Select a Year Level --");
            }
            else
            {
                cboBase.Items.Add("-- No year level enabled for this course --");
            }

            foreach (DataRow levelRow in _studentLevelTable.Rows)
            {
                Boolean isEntryLevel = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "is_entry_level", false);
                Boolean isEnrolled = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "is_enrolled", false);
                Boolean isMarkedDeleted = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "is_marked_deleted", false);

                if ((!isEntryLevel && !isEnrolled) || (isMarkedDeleted && !isMarkedDeleted))
                {
                    enrolStatus = " [Open for Enrolment]";
                }
                else if (!isEntryLevel && isEnrolled && !isMarkedDeleted)
                {
                    enrolStatus = " [Enrolled]";
                }
                else if (!isEntryLevel && isEnrolled && isMarkedDeleted)
                {
                    enrolStatus = " [Withdrawn - " + RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "last_transaction_date_string", String.Empty) + "]";
                }
                else if (isEntryLevel && isEnrolled && !isMarkedDeleted)
                {
                    enrolStatus = " [Enrolled as Entry Level]";
                }
                else if (isEntryLevel && isEnrolled && isMarkedDeleted)
                {
                    enrolStatus = " [Withdrawn by Finance Cashier]";
                }

                cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_description", "") + enrolStatus);
            }

            if (_studentLevelTable.Rows.Count == 1)
            {
                cboBase.SelectedIndex = 1;
            }
            else
            {
                cboBase.SelectedIndex = 0;
            }
        }//---------------------------------

        //this procedure initialized the student current charges list view
        //disable payment iteration if it is for charges before withdrawn
        public void InitializeStudentChargesListView(ListView lsvBase, Label lblBase, String sysIdStudent, Boolean isCurrentCharge)
        {
            lsvBase.Items.Clear();

            _paymentReimbursementTableTemp.Rows.Clear();

            Decimal balanceForwarded = 0;
            Decimal balanceForwardedForSummary = 0;

            if (_balanceForwardedTable != null && _balanceForwardedTable.Rows.Count > 0 && isCurrentCharge)
            {
                DataRow balRow = _balanceForwardedTable.Rows[0];

                balanceForwarded = balanceForwardedForSummary = RemoteServerLib.ProcStatic.DataRowConvert(balRow, "amount", Decimal.Parse("0"));
            }

            if (balanceForwarded < 0)
            {
                DataRow newRow = _paymentReimbursementTableTemp.NewRow();

                newRow["remarks_discount_reimbursement_description"] = "Forwarded Balance";
                newRow["amount"] = balanceForwarded * (-1);
                newRow["is_payment"] = true;
                //newRow["is_discount"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_discount", false);
                //newRow["is_reimbursement"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_discount", false);
                //newRow["is_balance_forwarded"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_balance_forwarded", false);
                //newRow["is_credit_memo"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_credit_memo", false);
                newRow["is_included_in_post"] = true;

                _paymentReimbursementTableTemp.Rows.Add(newRow);
            }

            foreach (DataRow payDiscountRem in _paymentReimbursementTable.Rows)
            {
                DataRow newRow = _paymentReimbursementTableTemp.NewRow();

                newRow["payment_discount_reimbursement_id"] =
                    RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "payment_discount_reimbursement_id", Int64.Parse("0"));
                newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "sysid_student", String.Empty);
                newRow["received_date"] =
                    RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "received_date", String.Empty);
                newRow["receipt_no"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "receipt_no", String.Empty);
                newRow["remarks_discount_reimbursement_description"] =
                    RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "remarks_discount_reimbursement_description", String.Empty);
                newRow["is_downpayment"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_downpayment", false);
                newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "amount", Decimal.Parse("0"));
                newRow["discount_amount"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "discount_amount", Decimal.Parse("0"));
                newRow["is_payment"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_payment", false);
                newRow["is_discount"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_discount", false);
                newRow["is_reimbursement"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_discount", false);
                newRow["is_balance_forwarded"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_balance_forwarded", false);
                newRow["is_credit_memo"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_credit_memo", false);
                newRow["is_included_in_post"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_included_in_post", false);
               
                _paymentReimbursementTableTemp.Rows.Add(newRow);

                if (RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "discount_amount", Decimal.Parse("0")) > 0)
                {
                    DataRow newRowDiscountedAmount = _paymentReimbursementTableTemp.NewRow();

                    newRowDiscountedAmount["payment_discount_reimbursement_id"] =
                        RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "payment_discount_reimbursement_id", Int64.Parse("0"));
                    newRowDiscountedAmount["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "sysid_student", String.Empty);
                    newRowDiscountedAmount["received_date"] =
                        RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "received_date", String.Empty);
                    newRowDiscountedAmount["receipt_no"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "receipt_no", String.Empty);
                    newRowDiscountedAmount["remarks_discount_reimbursement_description"] = "Cash Discount";
                    newRowDiscountedAmount["is_downpayment"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_downpayment", false);
                    newRowDiscountedAmount["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "discount_amount", Decimal.Parse("0"));
                    newRowDiscountedAmount["discount_amount"] = 0;
                    newRowDiscountedAmount["is_payment"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_payment", false);
                    newRowDiscountedAmount["is_discount"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_discount", false);
                    newRowDiscountedAmount["is_discount"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_discount", false);
                    newRowDiscountedAmount["is_reimbursement"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_discount", false);
                    newRowDiscountedAmount["is_balance_forwarded"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_balance_forwarded", false);
                    newRowDiscountedAmount["is_credit_memo"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_credit_memo", false);

                    _paymentReimbursementTableTemp.Rows.Add(newRowDiscountedAmount);
                }
            }

            if (balanceForwarded != 0)
            {   
                ListViewItem categoryItem = new ListViewItem(new String[] { "      " + "Back Accounts", String.Empty, String.Empty }, lsvBase.Groups[1]);
                categoryItem.ForeColor = Color.Red;
                lsvBase.Items.Add(categoryItem);

                ListViewItem forwardedItem = new ListViewItem(new String[] { "                   Balance Carried Forward ",
                    balanceForwarded.ToString("N"), String.Empty}, lsvBase.Groups[1]);
                lsvBase.Items.Add(forwardedItem);

                Boolean hasPayments = false;

                ListViewItem lessItem = new ListViewItem(new String[] { "                   Less:", String.Empty, String.Empty }, lsvBase.Groups[1]);
                lessItem.ForeColor = Color.Orange;
                lsvBase.Items.Add(lessItem); 

                Int32 paymentIndex = 0;

                foreach (DataRow paymentRow in _paymentReimbursementTableTemp.Rows)
                {
                    //Code added:: include only if (is_included_in_post == true) :: April 7, 2010
                    if (paymentRow.RowState != DataRowState.Deleted &&
                        (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) > 0 &&
                        ((RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_payment", false) ||
                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_discount", false) ||
                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_credit_memo", false)) && 
                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_included_in_post", false))))
                    {
                        if (balanceForwarded > 0 && isCurrentCharge)
                        {
                            ListViewItem paymentItem;

                            Decimal addedAmount = 0;
                            Decimal deductedAmount = 0;

                            if (balanceForwarded >= RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")))
                            {
                                balanceForwarded -= RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));

                                addedAmount = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));

                                deductedAmount = 0;
                            }
                            else
                            {
                                addedAmount = balanceForwarded;

                                deductedAmount = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) - balanceForwarded;

                                balanceForwarded = 0;
                            }

                            String remarksDescription = String.Empty;
                            String paymentDiscountReimbursementDate = String.Empty;

                            if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
                                "remarks_discount_reimbursement_description", "")) &&
                                (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_payment", false) &&
                                !RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false)))
                            {
                                remarksDescription = "Payment";
                            }
                            else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
                                "remarks_discount_reimbursement_description", "")) &&
                                RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false))
                            {
                                remarksDescription = "Downpayment";
                            }
                            else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
                                "remarks_discount_reimbursement_description", "")) &&
                                RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_reimbursement", false))
                            {
                                remarksDescription = "Reimbursement";
                            }
                            else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
                                "remarks_discount_reimbursement_description", "")) &&
                                RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_credit_memo", false))
                            {
                                remarksDescription = "Credit Memo";
                            }
                            else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
                                "remarks_discount_reimbursement_description", "")))
                            {
                                remarksDescription = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "");
                            }

                            DateTime pDate;

                            if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
                                "received_date", ""), out pDate))
                            {
                                paymentDiscountReimbursementDate = pDate.ToShortDateString();
                            }

                            //AD remove iteration for charges before withdrawn...
                            if (isCurrentCharge)
                            {
                                paymentItem = new ListViewItem(new String[] { "                         " + remarksDescription + " - " 
                                + paymentDiscountReimbursementDate, "(" + addedAmount.ToString("N") + ")", String.Empty}, lsvBase.Groups[1]);

                                lsvBase.Items.Add(paymentItem);

                            }
                            //End Added Code

                            DataRow editRow = _paymentReimbursementTableTemp.Rows[paymentIndex];

                            editRow.BeginEdit();

                            editRow["amount"] = deductedAmount;

                            editRow.EndEdit();

                            hasPayments = true;
                        }
                        else
                            break;
                    }

                    paymentIndex++;
                }

                _paymentReimbursementTable.AcceptChanges();
              

                if (!hasPayments || !isCurrentCharge)
                {
                    lsvBase.Items.Remove(lessItem);

                    ListViewItem totalItem = new ListViewItem(new String[] {"                                       Sub Total" ,
                        balanceForwarded.ToString("N"), String.Empty}, lsvBase.Groups[1]);

                    totalItem.ForeColor = Color.LightCoral;

                    lsvBase.Items.Add(totalItem);

                    ListViewItem emptyItem = new ListViewItem(new String[] { String.Empty, String.Empty, String.Empty },
                        lsvBase.Groups[1]);

                    lsvBase.Items.Add(emptyItem);
                }
                else
                {
                    ListViewItem totalItem = new ListViewItem(new String[] {"                                       Sub Total" ,
                        balanceForwarded.ToString("N"), String.Empty}, lsvBase.Groups[1]);

                    totalItem.ForeColor = Color.LightCoral;

                    lsvBase.Items.Add(totalItem);

                    ListViewItem emptyItem = new ListViewItem(new String[] { String.Empty, String.Empty, String.Empty },
                        lsvBase.Groups[1]);

                    lsvBase.Items.Add(emptyItem);
                }
            }

            Decimal totalCharges = 0;

            //-------------Populate School Fee Details
            foreach (DataRow categoryRow in _classDataSet.Tables["SchoolFeeCategoryTable"].Rows)
            {
                Int32 categoryItemCount = 0;

                ListViewItem categoryItem = new ListViewItem(new String[] {"      " + 
                    RemoteServerLib.ProcStatic.DataRowConvert(categoryRow, "category_description", ""), 
                String.Empty, String.Empty}, lsvBase.Groups[1]);

                categoryItem.ForeColor = Color.Red;

                lsvBase.Items.Add(categoryItem);

                String strFilter = "fee_category_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(categoryRow, "fee_category_id", "") + "'";
                DataRow[] selectRow;

                if (isCurrentCharge)
                    selectRow = _schoolFeeDetailsTableCurrentCharge.Select(strFilter);
                else
                    selectRow = _schoolFeeDetailsTableWithdrawCharge.Select(strFilter);

                Decimal subTotal = 0;
                Int16 index = 0;

                foreach (DataRow detailsRow in selectRow)
                {
                    if (detailsRow.RowState != DataRowState.Deleted &&
                        ((CommonExchange.SchoolFeeCategoryId.TuitionFee == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "") &&
                       (RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_per_year_tuition_fee", false) ||
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_per_unit_tuition_fee", false) ||
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_fixed_amount_tuition_fee", false) ||
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_special_class_tuition_fee", false))) ||
                        CommonExchange.SchoolFeeCategoryId.MiscellaneousFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "") ||
                        CommonExchange.SchoolFeeCategoryId.OtherFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "") ||
                        CommonExchange.SchoolFeeCategoryId.LaboratoryFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "")))
                    {
                        if (RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0")) > 0)
                        {
                            
                                ListViewItem item = new ListViewItem(new String[] { "                   " + 
                                RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "particular_description", ""),
                                RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0")).ToString("N"), 
                                RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "optional_fee_id", ""),
                                RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sysid_feedetails", "")}, lsvBase.Groups[1]);

                                if (RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_level_increase", false))
                                {
                                    item.ForeColor = Color.Orange;
                                }
                                else if (RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_added_level_fee", false))
                                {
                                    item.ForeColor = Color.Olive;
                                }
                                else if (RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_additional_fee", false))
                                {
                                    item.ForeColor = Color.Brown;
                                }
                                else if (RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_optional_fee", false))
                                {
                                    item.ForeColor = Color.CadetBlue;
                                }

                                lsvBase.Items.Add(item);

                                categoryItemCount++;
                                subTotal += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                            }
                        }                    

                    index++;
                }

                totalCharges += subTotal;

                if (index != 0)
                {
                    ListViewItem lessItem = new ListViewItem(new String[] { "                   Less:", String.Empty, String.Empty }, lsvBase.Groups[1]);
                    lessItem.ForeColor = Color.Orange;
                    lsvBase.Items.Add(lessItem);

                    Boolean hasPayments = false;

                    Int32 paymentIndex = 0;

                    //remove iteration for charges before withdrawn
                    if (isCurrentCharge)
                    {
                        foreach (DataRow paymentRow in _paymentReimbursementTableTemp.Rows)
                        {
                            //Code added:: include only if (is_included_in_post == true) :: April 7, 2010
                            if (paymentRow.RowState != DataRowState.Deleted &&
                                (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) > 0 &&
                                ((RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_payment", false) ||
                                RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_discount", false) ||
                                RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_credit_memo", false)) &&
                                RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_included_in_post",false))))
                            {
                                if (subTotal > 0)
                                {
                                    ListViewItem paymentItem;

                                    Decimal addedAmount = 0;
                                    Decimal deductedAmount = 0;

                                    if (subTotal >= RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")))
                                    {
                                        subTotal -= RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));

                                        addedAmount = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));

                                        deductedAmount = 0;
                                    }
                                    else
                                    {
                                        addedAmount = subTotal;

                                        deductedAmount = (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"))) - subTotal;

                                        subTotal = 0;
                                    }

                                    String remarksDescription = String.Empty;
                                    String paymentDiscountReimbursementDate = String.Empty;

                                    if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
                                        "remarks_discount_reimbursement_description", "")) &&
                                        (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_payment", false) &&
                                        !RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false)))
                                    {
                                        remarksDescription = "Payment";
                                    }
                                    else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
                                        "remarks_discount_reimbursement_description", "")) &&
                                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false))
                                    {
                                        remarksDescription = "Downpayment";
                                    }
                                    else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
                                        "remarks_discount_reimbursement_description", "")) &&
                                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_reimbursement", false))
                                    {
                                        remarksDescription = "Reimbursement";
                                    }
                                    else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
                                        "remarks_discount_reimbursement_description", "")) &&
                                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_credit_memo", false))
                                    {
                                        remarksDescription = "Credit Memo";
                                    }
                                    else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
                                        "remarks_discount_reimbursement_description", "")))
                                    {
                                        remarksDescription = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
                                            "remarks_discount_reimbursement_description", "");
                                    }

                                    DateTime pDate;

                                    if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
                                        "received_date", ""), out pDate))
                                    {
                                        paymentDiscountReimbursementDate = pDate.ToShortDateString();
                                    }


                                    paymentItem = new ListViewItem(new String[] { "                         " + remarksDescription + " - " 
                                    + paymentDiscountReimbursementDate, "(" + addedAmount.ToString("N") + ")", String.Empty}, lsvBase.Groups[1]);

                                    lsvBase.Items.Add(paymentItem);


                                    DataRow editRow = _paymentReimbursementTableTemp.Rows[paymentIndex];

                                    editRow.BeginEdit();

                                    editRow["amount"] = deductedAmount;

                                    editRow.EndEdit();

                                    hasPayments = true;
                                }
                                else
                                {
                                    break;
                                }
                            }

                            paymentIndex++;
                        }
                    }//END Added Code

                    _paymentReimbursementTable.AcceptChanges();

                    if (!hasPayments || !isCurrentCharge)
                    {
                        lsvBase.Items.Remove(lessItem);
                    }

                    if (categoryItemCount > 0)
                    {
                        ListViewItem totalItem = new ListViewItem(new String[] {"                                       Sub Total" ,
                            subTotal.ToString("N"), String.Empty}, lsvBase.Groups[1]);

                        totalItem.ForeColor = Color.LightCoral;

                        lsvBase.Items.Add(totalItem);

                        ListViewItem emptyItem = new ListViewItem(new String[] { String.Empty, String.Empty, String.Empty },
                            lsvBase.Groups[1]);

                        lsvBase.Items.Add(emptyItem);
                    }
                    else
                    {
                        lsvBase.Items.Remove(categoryItem);
                    }
                }
                else
                {
                    lsvBase.Items.Remove(categoryItem);
                }
            }
            //------------End Populate School Fee Details

            //-------------Populate Charges Summary 
            Decimal totalReimbursement = 0;
            Decimal discountAmount = 0;

            if (balanceForwardedForSummary != 0)
            {
                ListViewItem forwardedItem = new ListViewItem(new String[] { "                   Balance Carried Forward: ",
                balanceForwardedForSummary.ToString("N"), String.Empty}, lsvBase.Groups[0]);
                lsvBase.Items.Add(forwardedItem);
            }

            ListViewItem balanceItem = new ListViewItem(new String[] { "                   Total Charges: ", totalCharges.ToString("N"), String.Empty },
                lsvBase.Groups[0]);
            lsvBase.Items.Add(balanceItem);

            foreach (DataRow paymentRow in _paymentReimbursementTable.Rows)
            {
                //Code added:: include only if (is_included_in_post == true) :: April 7, 2010
                if (paymentRow.RowState != DataRowState.Deleted && 
                    (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_reimbursement", false) &&
                    RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_included_in_post", false)))
                {
                    String remarksDescription = String.Empty;
                    String paymentDiscountReimbursementDate = String.Empty;

                    if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                        (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_payment", false) &&
                        !RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false)))
                    {
                        remarksDescription = "Payment";
                    }
                    else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false))
                    {
                        remarksDescription = "Downpayment";
                    }
                    else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_reimbursement", false))
                    {
                        remarksDescription = "Reimbursement";
                    }
                    else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                           RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_credit_memo", false))
                    {
                        remarksDescription = "Credit Memo";
                    }
                    else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")))
                    {
                        remarksDescription = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "");
                    }

                    DateTime pDate;

                    if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "received_date", ""), out pDate))
                    {
                        paymentDiscountReimbursementDate = pDate.ToShortDateString();
                    }

                    ListViewItem rItem = new ListViewItem(new String[] {"                   " + remarksDescription + " - " + paymentDiscountReimbursementDate,
                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")).ToString("N"), String.Empty}, lsvBase.Groups[0]);

                    lsvBase.Items.Add(rItem);

                    totalReimbursement += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));
                }
            }

            ListViewItem lessPaymentItem = new ListViewItem(new String[] { "                   Less:", String.Empty, String.Empty }, lsvBase.Groups[0]);
            lessPaymentItem.ForeColor = Color.Orange;
            lsvBase.Items.Add(lessPaymentItem);

            Boolean hasPaymentSummary = false;

            foreach (DataRow paymentRow in _paymentReimbursementTable.Rows)
            {
                //Code added:: include only if (is_included_in_post == true) :: April 7, 2010
                if (paymentRow.RowState != DataRowState.Deleted && (!RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_reimbursement", false) &&
                    !RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_balance_forwarded", false) &&
                    RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_included_in_post", false)))
                {
                    String remarksDescription = String.Empty;
                    String paymentDiscountReimbursementDate = String.Empty;

                    if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                        (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_payment", false) &&
                        !RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false)))
                    {
                        remarksDescription = "Payment";
                    }
                    else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false))
                    {
                        remarksDescription = "Downpayment";
                    }
                    else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_reimbursement", false))
                    {
                        remarksDescription = "Reimbursement";
                    }
                    else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                           RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_credit_memo", false))
                    {
                        remarksDescription = "Credit Memo";
                    }
                    else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")))
                    {
                        remarksDescription = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "");
                    }

                    DateTime pDate;

                    if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "received_date", ""), out pDate))
                    {
                        paymentDiscountReimbursementDate = pDate.ToShortDateString();
                    }

                    //AD remove iteration for charges before withdrawn...
                    if (isCurrentCharge)
                    {
                        ListViewItem discountItem = new ListViewItem(new String[] { "                         " + remarksDescription + " - " + 
                        paymentDiscountReimbursementDate, 
                        "(" + RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")).ToString("N") + ")", String.Empty},
                                lsvBase.Groups[0]);

                        lsvBase.Items.Add(discountItem);                   

                        discountItem = null;

                        if (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0")) > 0)
                        {
                            discountItem = new ListViewItem(new String[] { "                         Cash Discount - " + 
                                paymentDiscountReimbursementDate, "(" + 
                                RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0")).ToString("N") + ")", String.Empty},
                                lsvBase.Groups[0]);

                            lsvBase.Items.Add(discountItem);
                        }
                    }
                    //End Added Code

                    discountAmount += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) +
                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0"));

                    hasPaymentSummary = true;
                }
            }

            if (!hasPaymentSummary || !isCurrentCharge)
            {
                lsvBase.Items.Remove(lessPaymentItem);
            }
            //-------------End

            String strText = isCurrentCharge ? "Per Year Level Balance : " +
                (String.Format("{0:#,##0.00;(#,##0.00)}", ((balanceForwardedForSummary + totalCharges + totalReimbursement) - (discountAmount)))) : 
                "Total : " + String.Format("{0:#,##0.00;(#,##0.00)}", (balanceForwardedForSummary + totalCharges + totalReimbursement));

            lblBase.Text = strText;
            
        }//-------------------------

        //this procedure initialized the student additional fee list view
        public void InitializeAdditionalFeeListView(ListView lsvBase, TabPage tblBase)
        {
            lsvBase.Items.Clear();

            if (_schoolFeeDetailsTableCurrentCharge != null)
            {
                foreach (DataRow feeRow in _schoolFeeDetailsTableCurrentCharge.Rows)
                {
                    if (feeRow.RowState != DataRowState.Deleted && RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_additional_fee", false))
                    {
                        ListViewItem addItem = new ListViewItem(new String[] {
                            RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "additional_fee_id", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "particular_description", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "amount", Decimal.Parse("0")).ToString("N"),
                            RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "remarks", String.Empty)});
                        
                        lsvBase.Items.Add(addItem);
                    }
                }
            }

            tblBase.Text = lsvBase.Items.Count > 0 ? "** Additional Fee  (F8)" : "Additional Fee  (F8)";
        }//------------------------

        //this procedure initialized the subject load list view
        public void InitializeSubjectLoadListView(ListView lsvBase, Label lblTotalStudentLoad, TabPage tblBase)
        {
            lsvBase.Items.Clear();

            Int32 totalLab = 0, totalLec = 0, totalHours = 0, totalMin = 0, totalNonAcad = 0;

            DateTime noHoursLoaded = DateTime.MinValue;

            foreach (DataRow schedRow in _studentLoadTable.Rows)
            {
                if (schedRow.RowState != DataRowState.Deleted)
                {
                    String strFilter = "sysid_schedule = '" + RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_schedule", "") + "'" +
                         " AND (is_loaded_to_student = 1 AND is_premature_deloaded = 0)";
                    DataRow[] selectRow = _subjectScheduleTable.Select(strFilter);

                    foreach (DataRow subRow in selectRow)
                    {
                        String amount = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "is_fixed_amount", false) ?
                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "amount", Decimal.Parse("0")).ToString("N") :
                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_amount", Decimal.Parse("0")).ToString("N");

                        ListViewItem addItem = new ListViewItem(new String[] {RemoteServerLib.ProcStatic.DataRowConvert(subRow, "sysid_schedule", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_code", "") + " - " +
                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "descriptive_title", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "load_lecture_units", Byte.Parse("0")).ToString(),
                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "load_lab_units", Byte.Parse("0")).ToString(),
                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "load_no_hours", ""), amount,
                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "department_name", "")});

                        Boolean isFixedAmount = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "is_fixed_amount", false);
                        Boolean isTeamTeaching = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "is_team_teaching", false);
                        Boolean isIrregularModular = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "is_irregular_modular", false);

                        if (!isFixedAmount && !isTeamTeaching && isIrregularModular)
                        {
                            addItem.ForeColor = Color.Peru;
                        }
                        else if (!isFixedAmount && isTeamTeaching && !isIrregularModular)
                        {
                            addItem.ForeColor = Color.Tomato;
                        }
                        else if (!isFixedAmount && isTeamTeaching && isIrregularModular)
                        {
                            addItem.ForeColor = Color.DarkSlateBlue;
                        }
                        else if (isFixedAmount && !isTeamTeaching && !isIrregularModular)
                        {
                            addItem.ForeColor = Color.RosyBrown;
                        }
                        else if (isFixedAmount && !isTeamTeaching && isIrregularModular)
                        {
                            addItem.ForeColor = Color.Olive;
                        }
                        else if (isFixedAmount && isTeamTeaching && !isIrregularModular)
                        {
                            addItem.ForeColor = Color.LimeGreen;
                        }
                        else if (isFixedAmount && isTeamTeaching && isIrregularModular)
                        {
                            addItem.ForeColor = Color.Plum;
                        }
                        //else for white which is a default color

                        lsvBase.Items.Add(addItem);
                       
                        totalLab += RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_lab_units", Byte.Parse("0"));

                        if (RemoteServerLib.ProcStatic.DataRowConvert(subRow, "is_non_academic", false))
                        {
                            totalNonAcad += RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_lecture_units", Byte.Parse("0"));
                        }
                        else
                        {
                            totalLec += RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_lecture_units", Byte.Parse("0"));
                        }

                        if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_no_hours", ""), out noHoursLoaded))
                        {
                            totalHours += noHoursLoaded.Minute + (noHoursLoaded.Hour * 60);
                        }
                    }
                }
            }

            totalMin = totalHours % 60;
            totalHours /= 60;

            lblTotalStudentLoad.Text = "  " + this.GetSubjectUnitsHours(totalLec, totalNonAcad, totalLab,
                RemoteServerLib.ProcStatic.TwoDigitZero(totalHours) + ":" + RemoteServerLib.ProcStatic.TwoDigitZero(totalMin));

            tblBase.Text = lsvBase.Items.Count > 0 ? "** Subject Taken  (F6)" : "Subject Taken  (F6)";
        }//-----------------------------

        //this procedure will initialize the speical class list view
        public void InitializeSpecialClassLoadedWithdrawnListView(ListView lsvBase, Label lblBase, TabPage tblBase, Boolean isPrematureDeloaded)
        {
            lsvBase.Items.Clear();

            Int32 totalLab = 0, totalLec = 0, totalHours = 0, totalMin = 0, totalNonAcad = 0;

            DateTime noHoursLoaded = DateTime.MinValue;

            String strFilter = "is_premature_deloaded = " + isPrematureDeloaded;
            DataRow[] selectRow = _specialClassTable.Select(strFilter);

            if (_specialClassTable != null)
            {
                if (!isPrematureDeloaded)
                {
                    foreach (DataRow specialRow in selectRow)
                    {
                        ListViewItem lstItem = new ListViewItem(new String[] { RemoteServerLib.ProcStatic.DataRowConvert(specialRow, 
                            "sysid_special", String.Empty),
                        RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_code", String.Empty) + " - " +
                        RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "descriptive_title", String.Empty),
                        RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lecture_units", Byte.Parse("0")).ToString(),
                        RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lab_units", Byte.Parse("0")).ToString(),
                        RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_no_hours", String.Empty),
                        RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "amount", Decimal.Parse("0")).ToString("N"),
                        RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_department_name", String.Empty)});

                        lsvBase.Items.Add(lstItem);

                        totalLab += RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lab_units", Byte.Parse("0"));

                        if (RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "is_non_academic", false))
                        {
                            totalNonAcad += RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lecture_units", Byte.Parse("0"));
                        }
                        else
                        {
                            totalLec += RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lecture_units", Byte.Parse("0"));
                        }

                        if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_no_hours", ""), out noHoursLoaded))
                        {
                            totalHours += noHoursLoaded.Minute + (noHoursLoaded.Hour * 60);
                        }
                    }

                    totalMin = totalHours % 60;
                    totalHours /= 60;

                    lblBase.Text = "  " + this.GetSubjectUnitsHours(totalLec, totalNonAcad, totalLab,
                        RemoteServerLib.ProcStatic.TwoDigitZero(totalHours) + ":" + RemoteServerLib.ProcStatic.TwoDigitZero(totalMin));

                    tblBase.Text = lsvBase.Items.Count > 0 ? "** Special Class  (F10)" : "Special Class  (F10)";
                }
                else
                {
                    foreach (DataRow specialRow in selectRow)
                    {
                        String loadDate = !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "load_date", "")) ?
                                   DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "load_date", "").ToString()).ToShortDateString() :
                                   String.Empty;
                        String deloadDate = !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "deload_date", "")) ?
                            DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "deload_date", "").ToString()).ToShortDateString() :
                            String.Empty;

                        ListViewItem lstItem = new ListViewItem(new String[] { RemoteServerLib.ProcStatic.DataRowConvert(specialRow, 
                            "sysid_special", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_code", String.Empty) + " - " +
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "descriptive_title", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lecture_units", Byte.Parse("0")).ToString(),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lab_units", Byte.Parse("0")).ToString(),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_no_hours", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "amount", Decimal.Parse("0")).ToString("N"),
                            loadDate, deloadDate,
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_department_name", String.Empty)});

                        lsvBase.Items.Add(lstItem);

                        totalLab += RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lab_units", Byte.Parse("0"));

                        if (RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "is_non_academic", false))
                        {
                            totalNonAcad += RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lecture_units", Byte.Parse("0"));
                        }
                        else
                        {
                            totalLec += RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lecture_units", Byte.Parse("0"));
                        }

                        if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_no_hours", ""), out noHoursLoaded))
                        {
                            totalHours += noHoursLoaded.Minute + (noHoursLoaded.Hour * 60);
                        }
                    }

                    totalMin = totalHours % 60;
                    totalHours /= 60;

                    lblBase.Text = "  " + this.GetSubjectUnitsHours(totalLec, totalNonAcad, totalLab,
                        RemoteServerLib.ProcStatic.TwoDigitZero(totalHours) + ":" + RemoteServerLib.ProcStatic.TwoDigitZero(totalMin));

                    tblBase.Text = lsvBase.Items.Count > 0 ? "** Withdrawn Special Class   (F11)" : "Withdrawn Special Class   (F11)";
                }
            }
        }//-------------------------------

        //this procedure initialized the withdrawn subject list view
        public void InitializeWithdrawSubjectLoadListView(ListView lsvBase, Label lblWithdrawnSubjects, TabPage tblBase)
        {
            lsvBase.Items.Clear();

            Int32 totalLab = 0, totalLec = 0, totalHours = 0, totalMin = 0, totalNonAcad = 0;

            DateTime noHoursLoaded = DateTime.MinValue;

            foreach (DataRow schedRow in _prematureDeloadedSubjectTable.Rows)
            {
                if (schedRow.RowState != DataRowState.Deleted)
                {
                    String strFilter = "sysid_schedule = '" + RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_schedule", "") +
                        "' AND (is_premature_deloaded = 1 AND is_loaded_to_student = 1)";
                    DataRow[] selectRow = _subjectScheduleTable.Select(strFilter);

                    foreach (DataRow subRow in selectRow)
                    {
                        if (subRow.RowState != DataRowState.Deleted)
                        {
                            String amount = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "is_fixed_amount", false) ?
                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "amount", Decimal.Parse("0")).ToString("N") :
                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_amount", Decimal.Parse("0")).ToString("N");

                            String loadDate = !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(subRow, "load_date", "")) ?
                                DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(subRow, "load_date", "").ToString()).ToShortDateString() :
                                String.Empty;
                            String deloadDate = !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(subRow, "deload_date", "")) ?
                                DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(subRow, "deload_date", "").ToString()).ToShortDateString() :
                                String.Empty;

                            ListViewItem addItem = new ListViewItem(new String[] {RemoteServerLib.ProcStatic.DataRowConvert(subRow, "sysid_schedule", ""),
                                RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_code", "") + " - " +
                                RemoteServerLib.ProcStatic.DataRowConvert(subRow, "descriptive_title", ""),
                                RemoteServerLib.ProcStatic.DataRowConvert(subRow, "load_lecture_units", Byte.Parse("0")).ToString(),
                                RemoteServerLib.ProcStatic.DataRowConvert(subRow, "load_lab_units", Byte.Parse("0")).ToString(),
                                RemoteServerLib.ProcStatic.DataRowConvert(subRow, "load_no_hours", ""), amount,
                                loadDate, deloadDate, 
                                RemoteServerLib.ProcStatic.DataRowConvert(subRow, "department_name", "")});

                            Boolean isFixedAmount = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "is_fixed_amount", false);
                            Boolean isTeamTeaching = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "is_team_teaching", false);
                            Boolean isIrregularModular = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "is_irregular_modular", false);

                            if (!isFixedAmount && !isTeamTeaching && isIrregularModular)
                            {
                                addItem.ForeColor = Color.Peru;
                            }
                            else if (!isFixedAmount && isTeamTeaching && !isIrregularModular)
                            {
                                addItem.ForeColor = Color.Tomato;
                            }
                            else if (!isFixedAmount && isTeamTeaching && isIrregularModular)
                            {
                                addItem.ForeColor = Color.DarkSlateBlue;
                            }
                            else if (isFixedAmount && !isTeamTeaching && !isIrregularModular)
                            {
                                addItem.ForeColor = Color.RosyBrown;
                            }
                            else if (isFixedAmount && !isTeamTeaching && isIrregularModular)
                            {
                                addItem.ForeColor = Color.Olive;
                            }
                            else if (isFixedAmount && isTeamTeaching && !isIrregularModular)
                            {
                                addItem.ForeColor = Color.LimeGreen;
                            }
                            else if (isFixedAmount && isTeamTeaching && isIrregularModular)
                            {
                                addItem.ForeColor = Color.Plum;
                            }
                            //else for white which is a default color

                            lsvBase.Items.Add(addItem);
                           
                            totalLab += RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_lab_units", Byte.Parse("0"));

                            if (RemoteServerLib.ProcStatic.DataRowConvert(subRow, "is_non_academic", false))
                            {
                                totalNonAcad += RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_lecture_units", Byte.Parse("0"));
                            }
                            else
                            {
                                totalLec += RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_lecture_units", Byte.Parse("0"));
                            }

                            if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_no_hours", ""), out noHoursLoaded))
                            {
                                totalHours += noHoursLoaded.Minute + (noHoursLoaded.Hour * 60);
                            }
                        }
                    }
                }
            }

            totalMin = totalHours % 60;
            totalHours /= 60;

            lblWithdrawnSubjects.Text = "  " + this.GetSubjectUnitsHours(totalLec, totalNonAcad, totalLab,
                RemoteServerLib.ProcStatic.TwoDigitZero(totalHours) + ":" + RemoteServerLib.ProcStatic.TwoDigitZero(totalMin));

            tblBase.Text = lsvBase.Items.Count > 0 ? "** Withdrawn Subject  (F7)" : "Withdrawn Subject  (F7)";
        }//---------------------------

        //this procedure will initialize payment history table
        public void InitializePaymentHistroyListView(ListView lsvBase, TabPage tblBase)
        {
            lsvBase.Items.Clear();

            if (_paymentReimbursementTable != null)
            {
                foreach (DataRow trRow in _paymentReimbursementTable.Rows)
                {
                    if (trRow.RowState != DataRowState.Deleted &&
                        RemoteServerLib.ProcStatic.DataRowConvert(trRow, "is_payment", false))
                    {
                        String remarksDescription = String.Empty;

                        if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(trRow, "remarks_discount_reimbursement_description", "")) &&
                            (RemoteServerLib.ProcStatic.DataRowConvert(trRow, "is_payment", false) &&
                            !RemoteServerLib.ProcStatic.DataRowConvert(trRow, "is_downpayment", false)))
                        {
                            remarksDescription = "Payment";
                        }
                        else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(trRow, "remarks_discount_reimbursement_description", "")) &&
                            RemoteServerLib.ProcStatic.DataRowConvert(trRow, "is_downpayment", false))
                        {
                            remarksDescription = "Downpayment";
                        }
                        else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(trRow, "remarks_discount_reimbursement_description", "")) &&
                            RemoteServerLib.ProcStatic.DataRowConvert(trRow, "is_reimbursement", false))
                        {
                            remarksDescription = "Reimbursement";
                        }
                        else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(trRow, "remarks_discount_reimbursement_description", "")))
                        {
                            remarksDescription = RemoteServerLib.ProcStatic.DataRowConvert(trRow, "remarks_discount_reimbursement_description", "");
                        }

                        String discountAmount = RemoteServerLib.ProcStatic.DataRowConvert(trRow, "discount_amount", Decimal.Parse("0")) > 0 ?
                            RemoteServerLib.ProcStatic.DataRowConvert(trRow, "discount_amount", Decimal.Parse("0")).ToString("N") : String.Empty;

                        ListViewItem addItem = new ListViewItem(new String[] {RemoteServerLib.ProcStatic.DataRowConvert(trRow, "receipt_no", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(trRow, "received_date", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(trRow, "reflected_date", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(trRow, "receipt_date", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(trRow, "amount", Decimal.Parse("0")).ToString("N"),
                            discountAmount, remarksDescription,
                            this.SetDownpaymentText(RemoteServerLib.ProcStatic.DataRowConvert(trRow, "is_downpayment", false)),
                            RemoteServerLib.ProcStatic.DataRowConvert(trRow, "payment_discount_reimbursement_id", Int64.Parse("0")).ToString()});

                        this.SetListViewItemColorForIsDownpaymentIncludeInPost(RemoteServerLib.ProcStatic.DataRowConvert(trRow, "is_downpayment", false),
                            RemoteServerLib.ProcStatic.DataRowConvert(trRow, "is_included_in_post", false), ref addItem);

                        lsvBase.Items.Add(addItem);
                    }
                }
            }

            tblBase.Text = lsvBase.Items.Count > 0 ? "** Payment History" : "Payment History";
        }//-----------------------

        //this procedure will initialize amount due list datagridview
        public void InitializeAmountDueList(ListView lsvBase, String strCourseId, DateTime dateStart, DateTime dateEnd, Boolean isSummer)
        {
            lsvBase.Items.Clear();

            _stementOfAccountSummaryTable.Rows.Clear();

            Decimal totalTutionFee = 0;
            Decimal totalMiscellaneousFee = 0;
            Decimal totalOtherFee = 0;
            Decimal totalLaboratoryFee = 0;
            Decimal downpayment = 0;
            Decimal totalDiscountPayment = 0;
            Decimal totalBalanceForwarded = 0;
            Decimal totalReimbursement = 0;

            if (_majorExamScheduleTable != null)
            {
                //create temporary table for payment reimbursement table
                DataTable paymentReimbursementTableTemp = new DataTable("TemporaryTable");
                paymentReimbursementTableTemp.Columns.Add("payment_discount_reimbursement_id", System.Type.GetType("System.String"));
                paymentReimbursementTableTemp.Columns.Add("reflected_date", System.Type.GetType("System.DateTime"));
                paymentReimbursementTableTemp.Columns.Add("received_date", System.Type.GetType("System.DateTime"));
                paymentReimbursementTableTemp.Columns.Add("remarks_discount_reimbursement_description", System.Type.GetType("System.String"));
                paymentReimbursementTableTemp.Columns.Add("amount", System.Type.GetType("System.Decimal"));
                paymentReimbursementTableTemp.Columns.Add("discount_amount", System.Type.GetType("System.Decimal"));
                paymentReimbursementTableTemp.Columns.Add("is_payment", System.Type.GetType("System.Boolean"));
                paymentReimbursementTableTemp.Columns.Add("is_discount", System.Type.GetType("System.Boolean"));
                paymentReimbursementTableTemp.Columns.Add("is_downpayment", System.Type.GetType("System.Boolean"));
                paymentReimbursementTableTemp.Columns.Add("is_credit_memo", System.Type.GetType("System.Boolean"));
                paymentReimbursementTableTemp.Columns.Add("is_reimbursement", System.Type.GetType("System.Boolean"));
                paymentReimbursementTableTemp.Columns.Add("is_included_in_post", System.Type.GetType("System.Boolean"));

                foreach (DataRow payRow in _paymentReimbursementTable.Rows)
                {
                    DataRow newRow = paymentReimbursementTableTemp.NewRow();

                    newRow["payment_discount_reimbursement_id"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "payment_discount_reimbursement_id", "");

                    DateTime rfDate = DateTime.Parse(this.ServerDateTime);

                    if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(payRow, "reflected_date", ""), out rfDate))
                    {
                        newRow["reflected_date"] = rfDate;
                    }

                    DateTime rcDate = DateTime.Parse(this.ServerDateTime);

                    if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(payRow, "received_date", ""), out rcDate))
                    {
                        newRow["received_date"] = rcDate;
                    }

                    newRow["remarks_discount_reimbursement_description"] =
                        RemoteServerLib.ProcStatic.DataRowConvert(payRow, "remarks_discount_reimbursement_description", String.Empty);
                    newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "amount", Decimal.Parse("0"));
                    newRow["discount_amount"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "discount_amount", Decimal.Parse("0"));
                    newRow["is_payment"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_payment", false);
                    newRow["is_discount"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_discount", false);
                    newRow["is_downpayment"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_downpayment", false);
                    newRow["is_credit_memo"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_credit_memo", false);
                    newRow["is_reimbursement"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_reimbursement", false);
                    newRow["is_included_in_post"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_included_in_post", false);

                    paymentReimbursementTableTemp.Rows.Add(newRow);
                }

                foreach (DataRow bRow in _balanceForwardedTable.Rows)
                {
                    //if (RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0")) > 0)
                    //{
                        totalBalanceForwarded = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0"));
                    //}

                    break;
                }

                if (totalBalanceForwarded < 0)
                {
                    DataRow newRow = _paymentReimbursementTableTemp.NewRow();

                    newRow["remarks_discount_reimbursement_description"] = "Forwarded Balance";
                    newRow["amount"] = totalBalanceForwarded * (-1);
                    newRow["is_payment"] = true;
                    //newRow["is_discount"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_discount", false);
                    //newRow["is_reimbursement"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_discount", false);
                    //newRow["is_balance_forwarded"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_balance_forwarded", false);
                    //newRow["is_credit_memo"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_credit_memo", false);
                    newRow["is_included_in_post"] = true;

                    _paymentReimbursementTableTemp.Rows.Add(newRow);
                }

                if (_schoolFeeDetailsTableCurrentCharge != null)
                {

                    foreach (DataRow detailsRow in _schoolFeeDetailsTableCurrentCharge.Rows)
                    {
                        if (detailsRow.RowState != DataRowState.Deleted)
                        {
                            if (CommonExchange.SchoolFeeCategoryId.TuitionFee == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "") &&
                            (RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_per_year_tuition_fee", false) ||
                             RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_per_unit_tuition_fee", false) ||
                             RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_fixed_amount_tuition_fee", false) ||
                             RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_special_class_tuition_fee", false)))
                            {
                                totalTutionFee += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                            }
                            else if (CommonExchange.SchoolFeeCategoryId.MiscellaneousFees ==
                                RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", ""))
                            {
                                totalMiscellaneousFee += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                            }
                            else if (CommonExchange.SchoolFeeCategoryId.OtherFees == 
                                RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", ""))
                            {
                                totalOtherFee += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                            }
                            else if (CommonExchange.SchoolFeeCategoryId.LaboratoryFees ==
                                RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", ""))
                            {
                                totalLaboratoryFee += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                            }
                        }
                    }
                }

                DataRow[] selectPaymentReimbursement = _paymentReimbursementTable.Select(String.Empty, "is_reimbursement DESC");

                foreach (DataRow paymentRow in selectPaymentReimbursement)
                {
                    //Code added:: include only if (is_included_in_post == true) :: April 7, 2010
                    if (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_included_in_post", false))
                    {
                        if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                            RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false))
                        {
                            downpayment += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) +
                                RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0"));
                        }
                        else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                           RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false))
                        {
                            downpayment += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) +
                                RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0"));
                        }

                        if (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_reimbursement", false))
                        {
                            totalReimbursement += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));
                        }
                        else
                        {
                            totalDiscountPayment += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0"));
                        }
                    }
                }

                Decimal amountToBeAdded;
                Decimal minimunDownpayment = 0;

                if (!isSummer)
                {
                    if (String.Equals(strCourseId, "CRSE014"))
                    {
                        amountToBeAdded = this.GetToBeAddedAmount(5000, ref downpayment);
                        minimunDownpayment = 5000;
                    }
                    else if (String.Equals(strCourseId, "CRSE012") || String.Equals(strCourseId, "CRSE011"))
                    {
                        amountToBeAdded = this.GetToBeAddedAmount(3500, ref downpayment);
                        minimunDownpayment = 3500;
                    }
                    else
                    {
                        amountToBeAdded = this.GetToBeAddedAmount(2500, ref downpayment);
                        minimunDownpayment = 2500;
                    }
                }
                else
                {
                    if (String.Equals(strCourseId, "CRSE014"))
                    {
                        amountToBeAdded = this.GetToBeAddedAmount(2000, ref downpayment);
                        minimunDownpayment = 2000;
                    }
                    else
                    {
                        amountToBeAdded = this.GetToBeAddedAmount(1500, ref downpayment);
                        minimunDownpayment = 1500;
                    }
                }

                amountToBeAdded += totalBalanceForwarded;

                Decimal acctualAmountDue = 0;

                if (_majorExamScheduleTable.Rows.Count > 0)
                {
                    acctualAmountDue =((totalTutionFee + totalMiscellaneousFee + totalOtherFee +
                       totalLaboratoryFee + totalReimbursement) - downpayment) / _majorExamScheduleTable.Rows.Count;

                }

                Decimal totalPayment = 0;
                String strFilter = "is_downpayment = 0";
                DataRow[] selectRow = paymentReimbursementTableTemp.Select(strFilter);

                foreach (DataRow payRow in selectRow)
                {
                    //Code added:: include only if (is_included_in_post == true) :: April 7, 2010
                    if (RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_included_in_post", false))
                    {
                        DateTime paymentDate = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(payRow, "reflected_date", String.Empty));

                        if (RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_payment", false) ||
                            RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_discount", false) ||
                            RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_credit_memo", false))
                        {
                            totalPayment += RemoteServerLib.ProcStatic.DataRowConvert(payRow, "amount", Decimal.Parse("0")) +
                                RemoteServerLib.ProcStatic.DataRowConvert(payRow, "discount_amount", Decimal.Parse("0"));
                        }
                    }
                }

                DateTime previousDateTime = DateTime.MinValue;
                Decimal amountDuePreviousForPrinting = 0;
                Decimal computedAcctualAmountDue = 0;
                Boolean isFirstEnter = true;

                DateTime serverDateTime = DateTime.Parse(_serverDateTime);
                Boolean hasEnterColor = false;
                Int32 index = 1;

                String previousExam = "(Previous SY/SEM)";

                foreach (DataRow examRow in _majorExamScheduleTable.Rows)
                {
                    Decimal amountDue = 0;

                    DateTime dueDate = DateTime.Parse(this.ServerDateTime);
                    String dDate = String.Empty;

                    if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_date", ""), out dueDate))
                    {
                        TimeSpan oneDay = new TimeSpan(24, 0, 0);

                        dDate = dueDate.Subtract(oneDay).ToShortDateString();
                    }


                    Decimal totalPaymentByTerm = 0;
                    Decimal totalPaymentByTermForPrinting = 0;
                    DataTable termPaymentTable = new DataTable("TermTempTable");

                    if (!RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_clearance_included", false))
                    {
                        totalPaymentByTerm = previousDateTime == DateTime.MinValue ?
                                this.GetTotalPaymentByDateStartEnd(dateStart, dueDate, paymentReimbursementTableTemp, isFirstEnter) :
                                this.GetTotalPaymentByDateStartEnd(previousDateTime, dueDate, paymentReimbursementTableTemp, isFirstEnter);

                        termPaymentTable = previousDateTime == DateTime.MinValue ?
                            this.GetTotalPaymentByDateStartEnd(dateStart, dueDate, paymentReimbursementTableTemp, 
                            termPaymentTable, ref totalPaymentByTermForPrinting, isFirstEnter) :
                            this.GetTotalPaymentByDateStartEnd(previousDateTime, dueDate,
                            paymentReimbursementTableTemp, termPaymentTable, ref totalPaymentByTermForPrinting, isFirstEnter);
                    }
                    else
                    {
                        totalPaymentByTerm = this.GetTotalPaymentByDateStartEnd(previousDateTime, dateEnd, paymentReimbursementTableTemp, isFirstEnter);

                        termPaymentTable = this.GetTotalPaymentByDateStartEnd(previousDateTime, dateEnd, paymentReimbursementTableTemp,
                            termPaymentTable, ref totalPaymentByTermForPrinting, isFirstEnter);
                    }
                    

                    DataRow newRowTerm = _stementOfAccountSummaryTable.NewRow();

                    newRowTerm["description"] = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_description", "");
                    newRowTerm["text_balance"] = String.Empty;
                    newRowTerm["amount"] = this.GetStringAmount(acctualAmountDue);
                    newRowTerm["total_amount"] = String.Empty;

                    _stementOfAccountSummaryTable.Rows.Add(newRowTerm);                  
                    

                    if (isFirstEnter)
                    {
                        DataRow newRowBackAccount = _stementOfAccountSummaryTable.NewRow();

                        newRowBackAccount["description"] = "Minimum Downpayment";
                        newRowBackAccount["text_balance"] = String.Empty;
                        newRowBackAccount["amount"] = this.GetStringAmount(minimunDownpayment);
                        newRowBackAccount["total_amount"] = String.Empty;

                        _stementOfAccountSummaryTable.Rows.Add(newRowBackAccount);

                        DataRow newRowSemBackAccount = _stementOfAccountSummaryTable.NewRow();

                        newRowSemBackAccount["description"] = "Back Accounts " + previousExam;
                        newRowSemBackAccount["text_balance"] = String.Empty;
                        newRowSemBackAccount["amount"] = this.GetStringAmount(totalBalanceForwarded);
                        newRowSemBackAccount["total_amount"] = String.Empty;

                        _stementOfAccountSummaryTable.Rows.Add(newRowSemBackAccount);

                        previousExam = "(" + RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_description", "") + ")";

                       
                    }
                    else
                    {
                        DataRow newRowSemBackAccount = _stementOfAccountSummaryTable.NewRow();

                        newRowSemBackAccount["description"] = "Back Accounts " + previousExam;
                        newRowSemBackAccount["text_balance"] = String.Empty;
                        newRowSemBackAccount["amount"] = this.GetStringAmount(amountDuePreviousForPrinting);
                        newRowSemBackAccount["total_amount"] = String.Empty;

                        _stementOfAccountSummaryTable.Rows.Add(newRowSemBackAccount);

                        previousExam = "(" + RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_description", "") + ")";
                    }

                    if (isFirstEnter)
                    {
                        if (amountDue + minimunDownpayment + totalBalanceForwarded != 0)
                        {
                            DataRow newRowTotalCredit = _stementOfAccountSummaryTable.NewRow();

                            newRowTotalCredit["description"] = "       Sub Total";
                            newRowTotalCredit["text_balance"] = String.Empty;
                            newRowTotalCredit["amount"] = String.Empty;
                            newRowTotalCredit["total_amount"] = this.GetStringAmount(acctualAmountDue + minimunDownpayment + totalBalanceForwarded);

                            _stementOfAccountSummaryTable.Rows.Add(newRowTotalCredit);
                        }
                    }
                    else
                    {
                        if (amountDue + amountDuePreviousForPrinting != 0)
                        {
                            DataRow newRowTotalCredit = _stementOfAccountSummaryTable.NewRow();

                            newRowTotalCredit["description"] = "       Sub Total";
                            newRowTotalCredit["text_balance"] = String.Empty;
                            newRowTotalCredit["amount"] = String.Empty;
                            newRowTotalCredit["total_amount"] = this.GetStringAmount(acctualAmountDue + amountDuePreviousForPrinting);

                            _stementOfAccountSummaryTable.Rows.Add(newRowTotalCredit);
                        }
                    }

                    DataRow newRowLess = _stementOfAccountSummaryTable.NewRow();

                    newRowLess["description"] = "Less:";
                    newRowLess["text_balance"] = String.Empty;
                    newRowLess["amount"] = String.Empty;
                    newRowLess["total_amount"] = String.Empty;

                    _stementOfAccountSummaryTable.Rows.Add(newRowLess);

                    foreach (DataRow paymentRow in termPaymentTable.Rows)
                    {
                        DataRow newRowPayment = _stementOfAccountSummaryTable.NewRow();

                        newRowPayment["description"] = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "description", String.Empty);
                        newRowPayment["text_balance"] = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "text_balance", String.Empty);
                        newRowPayment["amount"] = "(" + RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", String.Empty) + ")";
                        newRowPayment["total_amount"] = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "total_amount", String.Empty);

                        _stementOfAccountSummaryTable.Rows.Add(newRowPayment);
                    }

                    if (totalPaymentByTermForPrinting != 0)
                    {
                        DataRow newRowTotalDebit = _stementOfAccountSummaryTable.NewRow();

                        newRowTotalDebit["description"] = "       Sub Total";
                        newRowTotalDebit["text_balance"] = String.Empty;
                        newRowTotalDebit["amount"] = String.Empty;
                        newRowTotalDebit["total_amount"] = "(" + this.GetStringAmount(totalPaymentByTermForPrinting) + ")";

                        _stementOfAccountSummaryTable.Rows.Add(newRowTotalDebit);
                    }

                    DataRow lineRow = _stementOfAccountSummaryTable.NewRow();

                    lineRow["description"] = String.Empty;
                    lineRow["text_balance"] = String.Empty;
                    lineRow["amount"] = String.Empty;
                    lineRow["total_amount"] = "_________";

                    _stementOfAccountSummaryTable.Rows.Add(lineRow);

                    if (!RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_clearance_included", false))
                    {
                        if (isFirstEnter)
                        {
                            DataRow newRowGrandTotal = _stementOfAccountSummaryTable.NewRow();

                            newRowGrandTotal["description"] = String.Empty;
                            newRowGrandTotal["text_balance"] = "Amount Due";
                            newRowGrandTotal["amount"] = DateTime.Parse(dDate).ToShortDateString();
                            newRowGrandTotal["total_amount"] =
                                this.GetStringAmount((acctualAmountDue + minimunDownpayment + totalBalanceForwarded) - totalPaymentByTermForPrinting);

                            amountDue = (acctualAmountDue + minimunDownpayment + totalBalanceForwarded) - totalPaymentByTermForPrinting;

                            _stementOfAccountSummaryTable.Rows.Add(newRowGrandTotal);

                            isFirstEnter = false;

                            amountDuePreviousForPrinting = (acctualAmountDue + minimunDownpayment + totalBalanceForwarded) - totalPaymentByTermForPrinting;
                        }
                        else
                        {
                            DataRow newRowGrandTotal = _stementOfAccountSummaryTable.NewRow();

                            newRowGrandTotal["description"] = String.Empty;
                            newRowGrandTotal["text_balance"] = "Amount Due";
                            newRowGrandTotal["amount"] = DateTime.Parse(dDate).ToShortDateString();
                            newRowGrandTotal["total_amount"] =
                                this.GetStringAmount((acctualAmountDue +  amountDuePreviousForPrinting) - totalPaymentByTermForPrinting);

                            amountDue = (acctualAmountDue + amountDuePreviousForPrinting) - totalPaymentByTermForPrinting;

                            _stementOfAccountSummaryTable.Rows.Add(newRowGrandTotal);

                            amountDuePreviousForPrinting = (acctualAmountDue + amountDuePreviousForPrinting) - totalPaymentByTermForPrinting;
                        }
                        
                    }
                    else
                    {
                        amountDue = (acctualAmountDue + amountDuePreviousForPrinting) - totalPaymentByTermForPrinting;

                        DataRow newRowGrandTotal = _stementOfAccountSummaryTable.NewRow();

                        newRowGrandTotal["description"] = String.Empty;
                        newRowGrandTotal["text_balance"] = "Amount Due";
                        newRowGrandTotal["amount"] = DateTime.Parse(dDate).ToShortDateString();
                        newRowGrandTotal["total_amount"] = this.GetStringAmount(amountDue);

                        _stementOfAccountSummaryTable.Rows.Add(newRowGrandTotal);
                    }

                    DataRow newRowSeparate = _stementOfAccountSummaryTable.NewRow();

                    newRowSeparate["description"] = "............................................................";

                    _stementOfAccountSummaryTable.Rows.Add(newRowSeparate);
                    //---------------------------------------------------------------

                    previousDateTime = dueDate;

                    computedAcctualAmountDue += acctualAmountDue;

                    if (!RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_clearance_included", false))
                    {
                        amountDue = ((amountDue < 0) || (totalPayment > computedAcctualAmountDue + amountToBeAdded)) ? 0 :
                            (((computedAcctualAmountDue - totalPayment) + amountToBeAdded) < 0 ? 0 :
                            ((computedAcctualAmountDue - totalPayment) + amountToBeAdded));                        
                    }
                    else
                    {
                        amountDue = amountDue < 0 ? 0 : amountDue;
                    }

                    ListViewItem addItem = new ListViewItem(new String[] { dDate,
                        RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_description", String.Empty), amountDue.ToString("N")});
                                    
                    lsvBase.Items.Add(addItem);

                    if (!hasEnterColor && DateTime.Compare(dueDate, serverDateTime) > 0)
                    {
                        lsvBase.Items[index - 1].BackColor = Color.Orange;
                        hasEnterColor = true;
                    }
                    
                    index++;
                }
            }
        }//---------------------

        //this procedure will initialized reimbursement history list view
        public void InitializeReimbursementHistoryListView(ListView lsvBase, TabPage tblBase)
        {
            lsvBase.Items.Clear();

            if (_paymentReimbursementTable != null)
            {
                foreach (DataRow trRow in _paymentReimbursementTable.Rows)
                {
                    if (trRow.RowState != DataRowState.Deleted &&
                        RemoteServerLib.ProcStatic.DataRowConvert(trRow, "is_reimbursement", false))
                    {
                        ListViewItem addItem = new ListViewItem(new String[] { 
                            RemoteServerLib.ProcStatic.DataRowConvert(trRow, "payment_discount_reimbursement_id", Int64.Parse("0")).ToString(),
                            RemoteServerLib.ProcStatic.DataRowConvert(trRow, "received_date", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(trRow, "reflected_date", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(trRow, "amount", Decimal.Parse("0")).ToString("N"),
                            RemoteServerLib.ProcStatic.DataRowConvert(trRow, "remarks_discount_reimbursement_description", ""),
                            this.SetDownpaymentText(RemoteServerLib.ProcStatic.DataRowConvert(trRow, "is_downpayment", false))});

                        this.SetListViewItemColorForIsDownpaymentIncludeInPost(RemoteServerLib.ProcStatic.DataRowConvert(trRow, "is_downpayment", false),
                            RemoteServerLib.ProcStatic.DataRowConvert(trRow, "is_included_in_post", false), ref addItem);

                        lsvBase.Items.Add(addItem);
                    }
                }
            }

            tblBase.Text = lsvBase.Items.Count > 0 ? "** Reimbursements  (F3)" : "Reimbursements  (F3)";
        }//--------------------  

        //this procedure will initialized credit meme history list view
        public void InitializeCrediMemoHistoryListView(ListView lsvBase, TabPage tblBase)
        {
            lsvBase.Items.Clear();

            if (_paymentReimbursementTable != null)
            {
                foreach (DataRow trRow in _paymentReimbursementTable.Rows)
                {
                    if (trRow.RowState != DataRowState.Deleted &&
                        RemoteServerLib.ProcStatic.DataRowConvert(trRow, "is_credit_memo", false))
                    {
                        ListViewItem addItem = new ListViewItem(new String[] { 
                            RemoteServerLib.ProcStatic.DataRowConvert(trRow, "payment_discount_reimbursement_id", Int64.Parse("0")).ToString(),
                            RemoteServerLib.ProcStatic.DataRowConvert(trRow, "received_date", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(trRow, "reflected_date", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(trRow, "amount", Decimal.Parse("0")).ToString("N"),
                            RemoteServerLib.ProcStatic.DataRowConvert(trRow, "remarks_discount_reimbursement_description", ""),
                            this.SetDownpaymentText(RemoteServerLib.ProcStatic.DataRowConvert(trRow, "is_downpayment", false))});

                        this.SetListViewItemColorForIsDownpaymentIncludeInPost(RemoteServerLib.ProcStatic.DataRowConvert(trRow, "is_downpayment", false),
                            RemoteServerLib.ProcStatic.DataRowConvert(trRow, "is_included_in_post", false), ref addItem);

                        lsvBase.Items.Add(addItem);
                    }
                }
            }

            tblBase.Text = lsvBase.Items.Count > 0 ? "** Credit Memo" : "Credit Memo";
        }//--------------------  
      
        //this procedure will initialize student discount list view
        public void InitializeStudentDiscountListView(ListView lsvBase, TabPage tblBase)
        {
            lsvBase.Items.Clear();

            if (_studentScholarshipTable != null)
            {
                foreach (DataRow scholarRow in _studentScholarshipTable.Rows)
                {
                    if (scholarRow.RowState != DataRowState.Deleted)
                    {
                        String reflectedDate = RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "amount", Decimal.Parse("0")) == 0 ?
                            String.Empty : RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "reflected_date", "");

                        String recieveDate =  RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "amount", Decimal.Parse("0")) == 0 ?
                            String.Empty : RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "received_date", "");

                        ListViewItem addItem = new ListViewItem(new String[] { 
                            RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "sysid_studentscholarship", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "scholarship_description", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "amount", Decimal.Parse("0")).ToString("N"),
                            recieveDate, reflectedDate,
                            RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "remarks", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "department_name", "") + " [" +
                            RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "department_acronym", "") + "]",
                            this.SetDownpaymentText(RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "is_downpayment", false))});

                        this.SetListViewItemColorForIsDownpaymentIncludeInPost(RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "is_downpayment", false),
                            RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "is_included_in_post", false), ref addItem);

                        lsvBase.Items.Add(addItem);
                    }
                }
            }

            tblBase.Text = lsvBase.Items.Count > 0 ? "** Discounts  (F9)" : "Discounts  (F9)";
        }//------------------------

        //this procedure will initialize the major exam schedule list view
        public void InitializeMajorExamListView(ListView lsvBase)
        {
            lsvBase.Items.Clear();

            if (_majorExamScheduleTableForPrinting != null)
            {
                foreach (DataRow examRow in _majorExamScheduleTableForPrinting.Rows)
                {
                    ListViewItem addItem = new ListViewItem(new String[] {"",
                        RemoteServerLib.ProcStatic.DataRowConvert(examRow, "major_exam_id", Int64.Parse("0")).ToString(),
                        RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_date", ""),
                        RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_description", "")});

                    lsvBase.Items.Add(addItem);
                }
            }
        }//---------------------------

        //this procedure will edit major exam table
        public void EditMajorExamTable(String majorExamId, String date)
        {
            if (_majorExamScheduleTableForPrinting != null)
            {
                Int32 index = 0;

                foreach (DataRow examRow in _majorExamScheduleTableForPrinting.Rows)
                {
                    if (String.Equals(majorExamId, RemoteServerLib.ProcStatic.DataRowConvert(examRow, "major_exam_id", Int64.Parse("0")).ToString()))
                    {
                        DataRow editRow = _majorExamScheduleTableForPrinting.Rows[index];

                        editRow.BeginEdit();

                        editRow["exam_date"] = date;

                        editRow.EndEdit();

                        break;
                    }

                    index++;
                }
            }
        }//--------------------------


        //this procedure will initialize inserted exam schedule
        public void InitializeInsertedExamSchedule(String majorExamId, Boolean printValue)
        {
            if (_majorExamScheduleTableForPrinting != null)
            {
                Int32 index = 0;

                foreach (DataRow examRow in _majorExamScheduleTableForPrinting.Rows)
                {
                    if (String.Equals(majorExamId, RemoteServerLib.ProcStatic.DataRowConvert(examRow, "major_exam_id", "")))
                    {
                        DataRow editRow = _majorExamScheduleTableForPrinting.Rows[index];

                        editRow.BeginEdit();

                        editRow["is_for_print"] = printValue;

                        editRow.EndEdit();

                        break;
                    }

                    index++;
                }
            }
        }//----------------------------

        //this procedure initialize the year level list box
        public void InitializeYearLevelCheckedListBox(CheckedListBox cbxBase)
        {
            cbxBase.Items.Clear();

            if (_classDataSet.Tables["YearLevelInformationTable"] != null)
            {
                foreach (DataRow levelRow in _classDataSet.Tables["YearLevelInformationTable"].Rows)
                {
                    cbxBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "group_description", "") + " - " +
                        RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_description", ""));
                }
            }
        }//-----------------------------

        //this procedure initialize the year level list box
        public void InitializeYearLevelCheckedListBox(CheckedListBox cbxBase, Boolean isSemestral)
        {
            cbxBase.Items.Clear();

            if (_classDataSet.Tables["YearLevelInformationTable"] != null)
            {
                String strFilter = "is_semestral = " + isSemestral;
                DataRow[] selectRow = _classDataSet.Tables["YearLevelInformationTable"].Select(strFilter);

                foreach (DataRow levelRow in selectRow)
                {
                    cbxBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "group_description", "") + " - " +
                        RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_description", ""));
                }
            }
        }//-----------------------------

        //this procedure initialized the course checked list box
        public void InitializeCourseCheckedListBox(CheckedListBox cbxBase)
        {
            cbxBase.Items.Clear();

            if (_classDataSet.Tables["CourseInformationTable"] != null)
            {
                foreach (DataRow courseRow in _classDataSet.Tables["CourseInformationTable"].Rows)
                {
                    cbxBase.Items.Add(courseRow["course_title"].ToString() + " [" + courseRow["course_acronym"].ToString() + "]");
                }
            }
        }//-----------------------------------

        //this procedure initialized the course checked list box
        public void InitializeCourseCheckedListBox(CheckedListBox cbxBase, Boolean isSemestral)
        {
            cbxBase.Items.Clear();

            if (_classDataSet.Tables["CourseInformationTable"] != null)
            {
                String strFilter = "is_semestral = " + isSemestral;
                DataRow[] selectRow = _classDataSet.Tables["CourseInformationTable"].Select(strFilter);

                foreach (DataRow courseRow in selectRow)
                {
                    cbxBase.Items.Add(courseRow["course_title"].ToString() + " [" + courseRow["course_acronym"].ToString() + "]");
                }
            }
        }//-----------------------------------

        //this procedure initialize the scholarship list box
        public void InitializeScholarshipListBox(CheckedListBox cbxBase)
        {
            cbxBase.Items.Clear();

            if (_classDataSet.Tables["ScholarshipInformationTable"] != null)
            {
                foreach (DataRow scholarRow in _classDataSet.Tables["ScholarshipInformationTable"].Rows)
                {
                    cbxBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "scholarship_description", "") + " [" +
                        RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "department_acronym", "") + "]");
                }
            }
        }//---------------------

        //this procedure initialize the course group list box
        public void InitializeCourseGroupListBox(CheckedListBox cbxBase, Boolean isSemestral)
        {
            cbxBase.Items.Clear();

            if (_classDataSet.Tables["CourseGroupTable"] != null)
            {
                String strFilter = "is_semestral = " + isSemestral;
                DataRow[] selectRow = _classDataSet.Tables["CourseGroupTable"].Select(strFilter);

                foreach (DataRow groupRow in selectRow)
                {
                    cbxBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "group_description", ""));
                }
            }
        }//---------------------------

        //this procedure will initialize Cash receipt query listview
        public void InitializeCashReceiptQueryListView(ListView lsvBase, CommonExchange.SysAccess userinfo, String queryString,
            String dateStart, String dateEnd, String accountCreditSysIdList)
        {
            lsvBase.Items.Clear();
            _printingCashReceiptsQueryTable.Rows.Clear();

            using (RemoteClient.RemCntCashieringManager remCleint = new RemoteClient.RemCntCashieringManager())
            {
                _cashReceiptQueryTable = remCleint.SelectByQueryStringDateStartEndCashReceiptsQueryStudentPaymentMiscellaneousIncome(userinfo, queryString, dateStart,
                    dateEnd, accountCreditSysIdList, this.ServerDateTime);
            }

            if (_cashReceiptQueryTable != null)
            {
                foreach (DataRow detailsRow in _cashReceiptQueryTable.Rows)
                {
                    ListViewItem addItem = new ListViewItem(new String[] { "      " + 
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "receipt_no", String.Empty),
                        DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "received_date", String.Empty)).ToShortDateString(),
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "received_from", String.Empty),
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "acronym", String.Empty),
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "account_code", String.Empty),
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "account_name", String.Empty),
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0")).ToString("N")});

                    DataRow newRow = _printingCashReceiptsQueryTable.NewRow();

                    newRow["receipt_no"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "receipt_no", String.Empty);
                    newRow["received_date"] = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "received_date", String.Empty)).ToShortDateString();
                    newRow["received_from"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "received_from", String.Empty);
                    newRow["acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "acronym", String.Empty);
                    newRow["account_code"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "account_code", String.Empty);
                    newRow["account_name"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "account_name", string.Empty);
                    newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                    newRow["total"] = 0;

                    _printingCashReceiptsQueryTable.Rows.Add(newRow);

                    lsvBase.Items.Add(addItem);
                }
            }
        }//-------------------------

        //this procedure will initialize miscellaneouse payment listview
        public void InitializeMiscellaneousePaymentListView(ListView lsvBase, CommonExchange.SysAccess userInfo, String queryString,
            String dateStart, String dateEnd)
        {
            lsvBase.Items.Clear();

            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                _miscellaneouseIncomeTable = remClient.SelectByQueryStringDateStartEndMiscellaneousIncome(userInfo, queryString,
                    dateStart, dateEnd, this.ServerDateTime);
            }

            if (_miscellaneouseIncomeTable != null)
            {
                foreach (DataRow miscRow in _miscellaneouseIncomeTable.Rows)
                {
                    ListViewItem addItem = new ListViewItem(new String[] {
                        RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "receipt_no", String.Empty),
                        RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "received_date", String.Empty),
                        RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "reflected_date", String.Empty),
                        RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "receipt_date", String.Empty),
                        RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "received_from", String.Empty),
                        RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "amount", Decimal.Parse("0")).ToString("N"),
                        RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "discount_amount", Decimal.Parse("0")).ToString("N"),
                        RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "remarks", String.Empty),
                        RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "account_code", String.Empty) + " - " +
                        RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "account_name", String.Empty), 
                        RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "payment_id", Int64.Parse("0")).ToString()});

                    lsvBase.Items.Add(addItem);
                }
            }
        }//-----------------------------

        //this procedure will initialize the summariezed cash receipts listview and prepare also the table for printing the report
        public void InitializeSummariedCashReceiptListView(ListView lsvBase, Label lblCollection, Label lblDeposits, Label lblOverage)
        {
            lsvBase.Items.Clear();
            _printingSummariezedCashReceiptTable.Rows.Clear();

            if (_summariezedCashReceiptTable != null)
            {
                Boolean isMiscellaneousIncome = false;
                Boolean hasStudentPayment = false;
                Boolean hasMiscellaneousIncome = false;

                Decimal studentPaymentIncome = 0;
                Decimal miscellaneousIncome = 0;

                DataRow groupTitleRowStudentPayment = _printingSummariezedCashReceiptTable.NewRow();

                groupTitleRowStudentPayment["group_title"] = "TUITION FEE, MISCELLANEOUS, OTHER FEES, LABORATORY FEES";
                groupTitleRowStudentPayment["account_code_summary"] = String.Empty;
                groupTitleRowStudentPayment["account_name_summary"] = String.Empty;
                groupTitleRowStudentPayment["acronym"] = String.Empty;
                groupTitleRowStudentPayment["account_code_subsidiary"] = String.Empty;
                groupTitleRowStudentPayment["account_name_subsidiary"] = String.Empty;
                groupTitleRowStudentPayment["total_amount"] = 0;
                groupTitleRowStudentPayment["total"] = 0;

                _printingSummariezedCashReceiptTable.Rows.Add(groupTitleRowStudentPayment);

                foreach (DataRow summarizedRow in _summariezedCashReceiptTable.Rows)
                {
                    ListViewItem addItem;

                    if (!RemoteServerLib.ProcStatic.DataRowConvert(summarizedRow, "is_miscellaneous_income", false))
                    {
                        addItem = new ListViewItem(new String[] { "      " + 
                            RemoteServerLib.ProcStatic.DataRowConvert(summarizedRow, "account_code_summary", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(summarizedRow, "account_name_summary", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(summarizedRow, "acronym", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(summarizedRow, "account_code_subsidiary", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(summarizedRow, "account_name_subsidiary", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(summarizedRow, "total_amount", Decimal.Parse("0")).ToString("N"), 
                            String.Empty}, lsvBase.Groups[0]);

                        DataRow newRow = _printingSummariezedCashReceiptTable.NewRow();

                        newRow["group_title"] = String.Empty;
                        newRow["account_code_summary"] = RemoteServerLib.ProcStatic.DataRowConvert(summarizedRow, "account_code_summary", String.Empty);
                        newRow["account_name_summary"] = RemoteServerLib.ProcStatic.DataRowConvert(summarizedRow, "account_name_summary", string.Empty);
                        newRow["acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(summarizedRow, "acronym", String.Empty);
                        newRow["account_code_subsidiary"] = RemoteServerLib.ProcStatic.DataRowConvert(summarizedRow, "account_code_subsidiary", String.Empty);
                        newRow["account_name_subsidiary"] = RemoteServerLib.ProcStatic.DataRowConvert(summarizedRow, "account_name_subsidiary", String.Empty);
                        newRow["total_amount"] = RemoteServerLib.ProcStatic.DataRowConvert(summarizedRow, "total_amount", Decimal.Parse("0"));
                        newRow["total"] = 0;

                        _printingSummariezedCashReceiptTable.Rows.Add(newRow);

                        studentPaymentIncome += RemoteServerLib.ProcStatic.DataRowConvert(summarizedRow, "total_amount", Decimal.Parse("0"));

                        hasStudentPayment = true;
                    }
                    else
                    {
                        if ((isMiscellaneousIncome != RemoteServerLib.ProcStatic.DataRowConvert(summarizedRow, "is_miscellaneous_income", false)) && hasStudentPayment)
                        {
                            ListViewItem subItemStudentPayment = new ListViewItem(new String[] { "      " + String.Empty,
                                "       Sub Total", String.Empty, String.Empty, String.Empty, String.Empty, 
                                studentPaymentIncome.ToString("N")}, lsvBase.Groups[0]);

                            subItemStudentPayment.ForeColor = Color.LightCoral;

                            lsvBase.Items.Add(subItemStudentPayment);

                            DataRow subTotalStudentPaymentNewRow = _printingSummariezedCashReceiptTable.NewRow();

                            subTotalStudentPaymentNewRow["group_title"] = String.Empty;
                            subTotalStudentPaymentNewRow["account_code_summary"] = String.Empty;
                            subTotalStudentPaymentNewRow["account_name_summary"] = "       Sub Total";
                            subTotalStudentPaymentNewRow["acronym"] = String.Empty;
                            subTotalStudentPaymentNewRow["account_code_subsidiary"] = String.Empty;
                            subTotalStudentPaymentNewRow["account_name_subsidiary"] = String.Empty;
                            subTotalStudentPaymentNewRow["total_amount"] = 0;
                            subTotalStudentPaymentNewRow["total"] = studentPaymentIncome;

                            _printingSummariezedCashReceiptTable.Rows.Add(subTotalStudentPaymentNewRow);

                            DataRow groupTitleRowMiscellaneousIncome = _printingSummariezedCashReceiptTable.NewRow();

                            groupTitleRowMiscellaneousIncome["group_title"] = "MISCELLANEOUS INCOME";
                            groupTitleRowMiscellaneousIncome["account_code_summary"] = String.Empty;
                            groupTitleRowMiscellaneousIncome["account_name_summary"] = String.Empty;
                            groupTitleRowMiscellaneousIncome["acronym"] = String.Empty;
                            groupTitleRowMiscellaneousIncome["account_code_subsidiary"] = String.Empty;
                            groupTitleRowMiscellaneousIncome["account_name_subsidiary"] = String.Empty;
                            groupTitleRowMiscellaneousIncome["total_amount"] = 0;
                            groupTitleRowMiscellaneousIncome["total"] = 0;

                            _printingSummariezedCashReceiptTable.Rows.Add(groupTitleRowMiscellaneousIncome);
                        }

                        addItem = new ListViewItem(new String[] { "      " + 
                            RemoteServerLib.ProcStatic.DataRowConvert(summarizedRow, "account_code_summary", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(summarizedRow, "account_name_summary", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(summarizedRow, "acronym", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(summarizedRow, "account_code_subsidiary", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(summarizedRow, "account_name_subsidiary", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(summarizedRow, "total_amount", Decimal.Parse("0")).ToString("N"), 
                            String.Empty}, lsvBase.Groups[1]);

                        DataRow newRow = _printingSummariezedCashReceiptTable.NewRow();

                        newRow["group_title"] = String.Empty;
                        newRow["account_code_summary"] = RemoteServerLib.ProcStatic.DataRowConvert(summarizedRow, "account_code_summary", String.Empty);
                        newRow["account_name_summary"] = RemoteServerLib.ProcStatic.DataRowConvert(summarizedRow, "account_name_summary", string.Empty);
                        newRow["acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(summarizedRow, "acronym", String.Empty);
                        newRow["account_code_subsidiary"] = RemoteServerLib.ProcStatic.DataRowConvert(summarizedRow, "account_code_subsidiary", String.Empty);
                        newRow["account_name_subsidiary"] = RemoteServerLib.ProcStatic.DataRowConvert(summarizedRow, "account_name_subsidiary", String.Empty);
                        newRow["total_amount"] = RemoteServerLib.ProcStatic.DataRowConvert(summarizedRow, "total_amount", Decimal.Parse("0"));
                        newRow["total"] = 0;

                        _printingSummariezedCashReceiptTable.Rows.Add(newRow);

                        miscellaneousIncome += RemoteServerLib.ProcStatic.DataRowConvert(summarizedRow, "total_amount", Decimal.Parse("0"));

                        hasMiscellaneousIncome = true;
                    }

                    isMiscellaneousIncome = RemoteServerLib.ProcStatic.DataRowConvert(summarizedRow, "is_miscellaneous_income", false);

                    lsvBase.Items.Add(addItem);
                }

                if (!hasMiscellaneousIncome)
                {
                    ListViewItem subItemStudentPayment = new ListViewItem(new String[] { String.Empty, "       Sub Total", String.Empty, String.Empty, 
                            String.Empty, String.Empty,  studentPaymentIncome.ToString("N")}, lsvBase.Groups[0]);

                    subItemStudentPayment.ForeColor = Color.LightCoral;

                    lsvBase.Items.Add(subItemStudentPayment);

                    DataRow subTotalStudentPaymentNewRow = _printingSummariezedCashReceiptTable.NewRow();

                    subTotalStudentPaymentNewRow["group_title"] = String.Empty;
                    subTotalStudentPaymentNewRow["account_code_summary"] = String.Empty;
                    subTotalStudentPaymentNewRow["account_name_summary"] = "       Sub Total";
                    subTotalStudentPaymentNewRow["acronym"] = String.Empty;
                    subTotalStudentPaymentNewRow["account_code_subsidiary"] = String.Empty;
                    subTotalStudentPaymentNewRow["account_name_subsidiary"] = String.Empty;
                    subTotalStudentPaymentNewRow["total_amount"] = 0;
                    subTotalStudentPaymentNewRow["total"] = studentPaymentIncome;

                    _printingSummariezedCashReceiptTable.Rows.Add(subTotalStudentPaymentNewRow);
                }
                else
                {
                    ListViewItem subItemMiscellaneousIncome = new ListViewItem(new String[] { String.Empty, "       Sub Total", String.Empty, String.Empty, 
                            String.Empty, String.Empty, miscellaneousIncome.ToString("N")}, lsvBase.Groups[1]);

                    subItemMiscellaneousIncome.ForeColor = Color.LightCoral;

                    lsvBase.Items.Add(subItemMiscellaneousIncome);

                    DataRow subTotalMiscellaneousIncomeNewRow = _printingSummariezedCashReceiptTable.NewRow();

                    subTotalMiscellaneousIncomeNewRow["group_title"] = String.Empty;
                    subTotalMiscellaneousIncomeNewRow["account_code_summary"] = String.Empty;
                    subTotalMiscellaneousIncomeNewRow["account_name_summary"] = "       Sub Total";
                    subTotalMiscellaneousIncomeNewRow["acronym"] = String.Empty;
                    subTotalMiscellaneousIncomeNewRow["account_code_subsidiary"] = String.Empty;
                    subTotalMiscellaneousIncomeNewRow["account_name_subsidiary"] = String.Empty;
                    subTotalMiscellaneousIncomeNewRow["total_amount"] = 0;
                    subTotalMiscellaneousIncomeNewRow["total"] = miscellaneousIncome;
                                     
                    _printingSummariezedCashReceiptTable.Rows.Add(subTotalMiscellaneousIncomeNewRow);
                }

                Decimal totalCollection = 0, totalDeposits = 0;

                if (_printingSummariezedCashReceiptTable != null)
                {
                    foreach (DataRow detailsRow in _printingSummariezedCashReceiptTable.Rows)
                    {
                        totalCollection += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "total_amount", Decimal.Parse("0"));
                    }
                }

                if (_printingBreakDownBankDepositeSummarizedTable != null)
                {
                    foreach (DataRow depositRow in _printingBreakDownBankDepositeSummarizedTable.Rows)
                    {
                        totalDeposits += RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "total_amount", Decimal.Parse("0"));
                    }
                }

                lblCollection.Text = totalCollection.ToString("N");
                lblDeposits.Text = totalDeposits.ToString("N");
                lblOverage.Text = String.Format("{0:#,##0.00;(#,##0.00)}", (totalDeposits - totalCollection)); 

            }
        }//--------------------------

        //this procedure will initialize the cash receipts details listview and prepare also the table for printing the report
        public void InitializeCashReceiptsDetailsListView(ListView lsvBase, Label lblCollection, Label lblDeposits, Label lblOverage)
        {
            lsvBase.Items.Clear();
            _printingCashReceiptsDetailsTable.Rows.Clear();

            if (_cashReceiptDetailsTable != null)
            {
                Decimal totalAmount = 0;

                foreach (DataRow detailsRow in _cashReceiptDetailsTable.Rows)
                {
                    ListViewItem addItem = new ListViewItem(new String[] { "      " + 
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "receipt_no", String.Empty),
                        DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "received_date", String.Empty)).ToShortDateString(),
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "received_from", String.Empty),
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "acronym", String.Empty),
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "account_code", String.Empty),
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "account_name", String.Empty),
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0")).ToString("N")});

                    DataRow newRow = _printingCashReceiptsDetailsTable.NewRow();

                    newRow["receipt_no"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "receipt_no", String.Empty);
                    newRow["received_date"] = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "received_date", String.Empty)).ToShortDateString();
                    newRow["received_from"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "received_from", String.Empty);
                    newRow["acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "acronym", String.Empty);
                    newRow["account_code"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "account_code", String.Empty);
                    newRow["account_name"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "account_name", string.Empty);
                    newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                    newRow["total"] = 0;

                    _printingCashReceiptsDetailsTable.Rows.Add(newRow);

                    totalAmount += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));

                    lsvBase.Items.Add(addItem);
                }

                ListViewItem totalIncomeItem = new ListViewItem(new String[] { String.Empty, String.Empty, "    Total cash receipts for the period:", 
                    String.Empty, String.Empty, String.Empty, totalAmount.ToString("N")});

                totalIncomeItem.ForeColor = Color.LightCoral;

                lsvBase.Items.Add(totalIncomeItem);

                DataRow newRowTotalAmount = _printingCashReceiptsDetailsTable.NewRow();

                newRowTotalAmount["receipt_no"] = String.Empty;
                newRowTotalAmount["received_date"] = String.Empty;
                newRowTotalAmount["received_from"] = String.Empty;
                newRowTotalAmount["acronym"] = String.Empty;
                newRowTotalAmount["account_code"] = String.Empty;
                newRowTotalAmount["account_name"] = String.Empty;
                newRowTotalAmount["amount"] = 0;
                newRowTotalAmount["total"] = totalAmount;

                _printingCashReceiptsDetailsTable.Rows.Add(newRowTotalAmount);
                
                Decimal totalCollection = 0, totalDeposits = 0;

                if (_printingCashReceiptsDetailsTable != null)
                {
                    foreach (DataRow detailsRow in _printingCashReceiptsDetailsTable.Rows)
                    {
                        totalCollection += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                    }
                }

                if (_printingBreakDownBankDepositDetailsTable != null)
                {
                    foreach (DataRow depositRow in _printingBreakDownBankDepositDetailsTable.Rows)
                    {
                        totalDeposits += RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "amount", Decimal.Parse("0"));
                    }
                }

                lblCollection.Text = totalCollection.ToString("N");
                lblDeposits.Text = totalDeposits.ToString("N");
                lblOverage.Text = String.Format("{0:#,##0.00;(#,##0.00)}", (totalDeposits - totalCollection)); 
            }
        }//------------------------

        //this procedure will initialize the cash receipts details listview and prepare also the table for printing the report
        public void InitializeDiscountListView(ListView lsvBase)
        {
            lsvBase.Items.Clear();
            _printingCashDiscountsTable.Rows.Clear();

            if (_cashDiscountsTable != null)
            {
                Decimal totalAmount = 0;

                foreach (DataRow detailsRow in _cashDiscountsTable.Rows)
                {
                    ListViewItem addItem = new ListViewItem(new String[] { "      " + 
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "receipt_no", String.Empty),
                        DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "received_date", String.Empty)).ToShortDateString(),
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "received_from", String.Empty),
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "acronym", String.Empty),
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "account_code", String.Empty),
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "account_name", String.Empty),
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "discount_amount", Decimal.Parse("0")).ToString("N")});

                    DataRow newRow = _printingCashDiscountsTable.NewRow();

                    newRow["receipt_no"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "receipt_no", String.Empty);
                    newRow["received_date"] = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "received_date", String.Empty)).ToShortDateString();
                    newRow["received_from"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "received_from", String.Empty);
                    newRow["acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "acronym", String.Empty);
                    newRow["account_code"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "account_code", String.Empty);
                    newRow["account_name"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "account_name", string.Empty);
                    newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "discount_amount", Decimal.Parse("0"));
                    newRow["total"] = 0;

                    _printingCashDiscountsTable.Rows.Add(newRow);

                    totalAmount += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "discount_amount", Decimal.Parse("0"));

                    lsvBase.Items.Add(addItem);
                }

                ListViewItem totalIncomeItem = new ListViewItem(new String[] { String.Empty, String.Empty, "    Total cash discounts for the period:", 
                    String.Empty, String.Empty, String.Empty, totalAmount.ToString("N")});

                totalIncomeItem.ForeColor = Color.LightCoral;

                lsvBase.Items.Add(totalIncomeItem);
            }
        }//------------------------
       
        //this procedure will initialize break down bank deposit details list view
        public void InitializeBreakDownBankDepositDetailsSummarizedListView(ListView lsvBase, Boolean isDetails)
        {
            lsvBase.Items.Clear();

            DataTable tempTable = null;

            if (isDetails)
            {
                _printingBreakDownBankDepositDetailsTable.Rows.Clear();

                tempTable = _breakDownBankDepositDetailsTable;
            }
            else
            {
                _printingBreakDownBankDepositeSummarizedTable.Rows.Clear();

                tempTable = _breakDownBackDepositeSummarizedTable;
            }

            if (tempTable != null)
            {
                Decimal total = 0;

                foreach (DataRow depositRow in tempTable.Rows)
                {
                    if (isDetails)
                    {
                        ListViewItem addItem = new ListViewItem(new String[] { RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "account_code_summary", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "account_name_summary", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "account_code", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "account_name", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "amount", Decimal.Parse("0")).ToString("N"),
                            RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "sysid_account", String.Empty)});

                        lsvBase.Items.Add(addItem);

                        total += RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "amount", Decimal.Parse("0"));

                        DataRow newRow = _printingBreakDownBankDepositDetailsTable.NewRow();

                        newRow["account_code_summary"] = RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "account_code_summary", String.Empty);
                        newRow["account_name_summary"] = RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "account_name_summary", String.Empty);
                        newRow["account_code"] = RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "account_code", String.Empty);
                        newRow["account_name"] = RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "account_name", String.Empty);
                        newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "amount", Decimal.Parse("0"));

                        _printingBreakDownBankDepositDetailsTable.Rows.Add(newRow);
                    }
                    else
                    {
                        ListViewItem addItem = new ListViewItem(new String[] { RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "account_code_summary", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "account_name_summary", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "account_code_subsidiary", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "account_name_subsidiary", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "total_amount", Decimal.Parse("0")).ToString("N"), String.Empty});

                        DataRow newRow = _printingBreakDownBankDepositeSummarizedTable.NewRow();

                        newRow["account_code_summary"] = RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "account_code_summary", String.Empty);
                        newRow["account_name_summary"] = RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "account_name_summary", String.Empty);
                        newRow["account_code_subsidiary"] = RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "account_code_subsidiary", String.Empty);
                        newRow["account_name_subsidiary"] = RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "account_name_subsidiary", String.Empty);
                        newRow["total_amount"] = RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "total_amount", Decimal.Parse("0"));

                        _printingBreakDownBankDepositeSummarizedTable.Rows.Add(newRow);

                        total += RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "total_amount", Decimal.Parse("0"));

                        lsvBase.Items.Add(addItem);
                    }
                }

                ListViewItem totalIncomeItem = new ListViewItem(new String[] { String.Empty, "    Total bank deposits for the period:", 
                    String.Empty, String.Empty, total.ToString("N"), String.Empty});

                totalIncomeItem.ForeColor = Color.LightCoral;

                lsvBase.Items.Add(totalIncomeItem);
            }
        }//-----------------------

        //this procedure will clear optional fee table
        public void ClearOptionalFeeTable()
        {
            if (_optionalFeeTable != null)
            {
                _optionalFeeTable.Rows.Clear();
            }
        }//------------------------------

        //this procedure will clear cached data
        public void ClearCachedData()
        {
            if (_studentLoadTable != null)
            {
                _studentLoadTable.Clear();
                _prematureDeloadedSubjectTable.Clear();
                _additionalFeeTable.Clear();

                if (_balanceForwardedTable != null)
                {
                    _balanceForwardedTable.Rows.Clear();
                }

                if (_schoolFeeDetailsTableCurrentCharge != null)
                {
                    _schoolFeeDetailsTableCurrentCharge.Rows.Clear();
                }
            }
        }//--------------------------------

        //this procedure will clear amount due list table
        public void ClearAmountDueListTableForPrinting()
        {
            _stementOfAccountSummaryTable.Rows.Clear();
        }//-------------------------------

        //this procedure will clear cash receipt query table
        public void ClearCashReceiptQueryTable()
        {
            _printingCashReceiptsQueryTable.Rows.Clear();
        }//-------------------------

        //this procedure will clear major exam table
        public void ClearMajorExamTable()
        {
            if (_majorExamScheduleTable != null)
            {
                _majorExamScheduleTable.Rows.Clear();
            }
        }//-------------------------

        //this functio will set listviewitem color
        private void SetListViewItemColorForIsDownpaymentIncludeInPost(Boolean isDownPayment, Boolean isIncludeInPost, ref ListViewItem item)
        {
            if (!isDownPayment && !isIncludeInPost)
            {
                item.BackColor = Color.LightGray;
            }
            else if (isDownPayment && !isIncludeInPost)
            {
                item.ForeColor = Color.Red;
                item.BackColor = Color.LightGray;
            }
            else if (isDownPayment && isIncludeInPost)
            {
                item.ForeColor = Color.Red;
            }
        }//-------------------

        //this procedure will edit school fee details table
        private void EditSchoolFeeDetailsTable(ref DataTable schoolFeeDetailsTableTemp, DataTable studentTable, Boolean isIncludeCourse)
        {
            schoolFeeDetailsTableTemp.Columns.Add("year_level_id", System.Type.GetType("System.String"));

            if (isIncludeCourse)
            {
                schoolFeeDetailsTableTemp.Columns.Add("course_id", System.Type.GetType("System.String"));
            }

            schoolFeeDetailsTableTemp.AcceptChanges();

            Int32 index = 0;

            foreach (DataRow feeRow in schoolFeeDetailsTableTemp.Rows)
            {
                DataRow editRow = schoolFeeDetailsTableTemp.Rows[index];

                editRow.BeginEdit();

                editRow["year_level_id"] = this.GetYearLevelId(studentTable, RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "sysid_student", String.Empty), false);

                if (isIncludeCourse)
                {
                    editRow["course_id"] = this.GetYearLevelId(studentTable, RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "sysid_student", String.Empty), true);
                }

                if (RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_fixed_amount_tuition_fee", false) &&
                    RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "amount", Decimal.Parse("0")) > 0)
                {
                    editRow["sysid_feeparticular"] = "tempFixedSub01";
                }
                else if (RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_special_class_tuition_fee", false) &&
                    RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "amount", Decimal.Parse("0")) > 0)
                {
                    editRow["sysid_feeparticular"] = "tempSpecialClass01";
                }

                editRow.EndEdit();

                index++;
            }
        }//--------------------------
        #endregion

        #region Programer-Defined Functions
        //this function populates Searched student
        public DataTable PopulateStudentSearchedList()
        {
            DataTable newTable = new DataTable("StudentSearchByStudentNameIdCardNumberTable");
            newTable.Columns.Add("student_id", System.Type.GetType("System.String"));
            newTable.Columns.Add("student_name", System.Type.GetType("System.String"));
            newTable.Columns.Add("card_number", System.Type.GetType("System.String"));
            newTable.Columns.Add("course_title", System.Type.GetType("System.String"));
            newTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
            newTable.Columns.Add("section", System.Type.GetType("System.String"));
            newTable.Columns.Add("department_name", System.Type.GetType("System.String"));
            newTable.Columns.Add("present_address", System.Type.GetType("System.String"));
            newTable.Columns.Add("present_phone_nos", System.Type.GetType("System.String"));
            newTable.Columns.Add("home_address", System.Type.GetType("System.String"));
            newTable.Columns.Add("home_phone_nos", System.Type.GetType("System.String"));
            newTable.Columns.Add("emer_contact_name", System.Type.GetType("System.String"));
            newTable.Columns.Add("emer_relationship_description", System.Type.GetType("System.String"));
            newTable.Columns.Add("emer_present_address", System.Type.GetType("System.String"));
            newTable.Columns.Add("emer_present_phone_nos", System.Type.GetType("System.String"));
            newTable.Columns.Add("emer_home_address", System.Type.GetType("System.String"));
            newTable.Columns.Add("emer_home_phone_nos", System.Type.GetType("System.String"));

            foreach (DataRow studentRow in _studentTable.Rows)
            {
                DataRow newRow = newTable.NewRow();

                newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "student_id", "");
                newRow["student_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(studentRow, "last_name", "first_name", "middle_name");
                newRow["card_number"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "card_number", "");
                newRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "course_title", "") + " - " +
                    RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "course_acronym", "");
                newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "year_level_description", "");
                newRow["section"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "level_section", "");
                newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "department_name", "") + " - " +
                    RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "department_acronym", "");
                newRow["present_address"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "present_address", "");
                newRow["present_phone_nos"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "present_phone_nos", "");
                newRow["home_address"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "home_address", "");
                newRow["home_phone_nos"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "home_phone_nos", "");
                newRow["emer_contact_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(studentRow, "emer_last_name", "emer_first_name",
                   "emer_middle_name");
                newRow["emer_relationship_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_relationship_description", String.Empty);
                newRow["emer_present_address"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_present_address", String.Empty);
                newRow["emer_present_phone_nos"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_present_phone_nos", String.Empty);
                newRow["emer_home_address"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_home_address", String.Empty);
                newRow["emer_home_phone_nos"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_home_phone_nos", String.Empty);

                newTable.Rows.Add(newRow);
            }

            newTable.AcceptChanges();

            return newTable;
        }//-----------------------------  

        //this function gets the selected student
        public DataTable GetSearchedStudentInformation(CommonExchange.SysAccess userInfo,
            String queryString, String dateStart, String dateEnd, String yearLevelIdList, String courseIdList, Boolean isForApply)
        {
            DataTable newTable = new DataTable("StudentSearchByStudentNameIdCardNumberTable");

            if (isForApply)
            {
                newTable.Columns.Add("checkbox_column", System.Type.GetType("System.Boolean"));
            }

            newTable.Columns.Add("student_id", System.Type.GetType("System.String"));
            newTable.Columns.Add("student_name", System.Type.GetType("System.String"));

            if (!isForApply)
            {
                newTable.Columns.Add("particular_description_for_multiple", System.Type.GetType("System.String"));
                newTable.Columns.Add("remarks", System.Type.GetType("System.String"));
                newTable.Columns.Add("amount", System.Type.GetType("System.String"));
            }

            newTable.Columns.Add("course_title", System.Type.GetType("System.String"));
            newTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
            newTable.Columns.Add("department_name", System.Type.GetType("System.String"));

            if (isForApply)
            {
                newTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));
            }

            if (isForApply)
            {
                using (RemoteClient.RemCntStudentManager remClient = new RemoteClient.RemCntStudentManager())
                {
                    _studentTableMultiple = remClient.SelectStudentInformation(userInfo, queryString, dateStart, dateEnd, courseIdList, yearLevelIdList);
                }
            }
            else
            {
                using (RemoteClient.RemCntSchoolFeeManager remClient = new RemoteClient.RemCntSchoolFeeManager())
                {
                    _studentTableMultiple = remClient.SelectStudentAdditionalFee(userInfo, queryString, dateStart, dateEnd, courseIdList, yearLevelIdList);
                }
            }

            foreach (DataRow studentRow in _studentTableMultiple.Rows)
            {
                if ((isForApply && RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "is_current_course", false)) || !isForApply)
                {
                    DataRow newRow = newTable.NewRow();

                    if (isForApply)
                    {
                        newRow["checkbox_column"] = false;
                    }

                    newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "student_id", "");
                    newRow["student_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(studentRow, "last_name", "first_name", "middle_name");

                    if (!isForApply)
                    {
                        newRow["particular_description_for_multiple"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "particular_description", "") + " (" +
                            RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "category_description", "") + ")";
                        newRow["remarks"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "remarks", String.Empty);
                        newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "amount", Decimal.Parse("0")).ToString("N");
                    }

                    String strCurrentCourse = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "is_current_course", false) ?
                        " (Current Course)" : String.Empty;

                    newRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "course_title", "") + " - " +
                        RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "course_acronym", "") + strCurrentCourse;
                    newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "year_level_description", "");
                    newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "department_name", "") + " - " +
                        RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "department_acronym", "");

                    if (isForApply)
                    {
                        newRow["sysid_enrolmentlevel"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "sysid_enrolmentlevel", "");
                    }

                    newTable.Rows.Add(newRow);
                }
            }

            newTable.AcceptChanges();
            
            return newTable;
        }//-----------------------------        

        //this fucntion returns searched Additional Fee
        public DataTable GetSearchedOptinalFee(String queryString)
        {
            DataTable newTable = new DataTable("OptionalFeeTable");
            newTable.Columns.Add("sysid_feedetails", System.Type.GetType("System.String"));
            newTable.Columns.Add("particular_description", System.Type.GetType("System.String"));
            newTable.Columns.Add("amount", System.Type.GetType("System.String"));

            if (_optionalSchoolFeeDetailsTable != null)
            {
                queryString = queryString.Replace("*", "").Replace("%", "").Replace("'", "''");

                String strFilter = "particular_description LIKE '%" + queryString + "%'";
                DataRow[] selectRow = _optionalSchoolFeeDetailsTable.Select(strFilter);

                foreach (DataRow feeRow in selectRow)
                {
                    if (feeRow.RowState != DataRowState.Deleted &&
                        !this.IsOptionalFeeExistCharge(RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "sysid_feedetails", "")))
                    {
                        DataRow newRow = newTable.NewRow();

                        newRow["sysid_feedetails"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "sysid_feedetails", "");
                        newRow["particular_description"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "particular_description", "");
                        newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "amount", Decimal.Parse("0")).ToString("N");

                        newTable.Rows.Add(newRow);
                    }
                }

                newTable.AcceptChanges();
            }

            return newTable;
        }//-----------------------------

        //this rucntion will determines if opetional fee already exist in student charges
        private Boolean IsOptionalFeeExistCharge(String sysIdFeeDetails)
        {
            Boolean isExist = false;
            
            String strFilter = "sysid_feedetails = '" + sysIdFeeDetails + "'";
            DataRow[] selectRow = _schoolFeeDetailsTableCurrentCharge.Select(strFilter);
            
            if (selectRow.Length >= 1)
            {
                isExist = true;
            }

            return isExist;
        }//--------------------------

        //this fucntion determines if the school fee details is optional and is office access
        public Boolean IsOptionalFeeAndIsOfficeAccess(Int64 optionalFeeId)
        {
            Boolean isValid = false;

            String strFilter = "optional_fee_id = " + optionalFeeId;
            DataRow[] selectRow = _optionalFeeTable.Select(strFilter);

            foreach (DataRow feeRow in selectRow)
            {
                if (feeRow.RowState != DataRowState.Deleted && (RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_optional_fee", false) ||
                    RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_office_access", false)))
                {
                    isValid = true;
                }

                break;
            }

            DataRow[] selectSchoolFeeDetails = _schoolFeeDetailsTableCurrentCharge.Select(strFilter);

            foreach (DataRow feeRow in selectSchoolFeeDetails)
            {
                if (feeRow.RowState != DataRowState.Deleted && (RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_optional_fee", false) ||
                    RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_office_access", false)))
                {
                    isValid = true;
                }

                break;
            }

            return isValid;
        }//--------------------------

        //this function will determine if the selected date is with in the range of the date difined by the system
        public Boolean IsWithInTheRangeOfSchoolYearSemeterDefined(DateTime baseDate)
        {
            Boolean inTheRange = false;

            if (_classDataSet.Tables["SchoolFeeInformationTable"] != null)
            {
                DateTime dateStart = DateTime.MinValue;
                DateTime dateEnd = DateTime.MinValue;

                Boolean firstEnter = true;

                foreach (DataRow dRow in _classDataSet.Tables["SchoolFeeInformationTable"].Rows)
                {
                    if (firstEnter)
                    {
                        dateStart = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "date_start", String.Empty));
                        dateEnd = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "date_end", String.Empty));

                        firstEnter = false;
                    }
                    else
                    {
                        if (DateTime.Compare(dateStart, DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "date_start", String.Empty))) > 0)
                        {
                            dateStart = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "date_start", String.Empty));
                        }

                        if (DateTime.Compare(dateEnd, DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "date_end", String.Empty))) < 0)
                        {
                            dateEnd = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "date_end", String.Empty));
                        }
                    }
                }

                if (DateTime.Compare(dateStart, baseDate) <= 0 && DateTime.Compare(dateEnd, baseDate) >= 0)
                {
                    inTheRange = true;
                }
            }

            return inTheRange;
        }//----------------------------

        //this procedure will delete optional fee
        public void DeleteOptionalFee(Int64 optionalFeeId)
        {
            if (_optionalFeeTable != null)
            {
                Int32 index = 0;

                foreach (DataRow optionalRow in _optionalFeeTable.Rows)
                {
                    if (optionalRow.RowState != DataRowState.Deleted &&
                        optionalFeeId == RemoteServerLib.ProcStatic.DataRowConvert(optionalRow, "optional_fee_id", Int64.Parse("0")))
                    {
                        DataRow delRow = _optionalFeeTable.Rows[index];

                        if (delRow.RowState == DataRowState.Modified || delRow.RowState == DataRowState.Added)
                        {
                            delRow.AcceptChanges();
                        }

                        delRow.Delete();

                        break;
                    }

                    index++;
                }

                index = 0;

                foreach (DataRow optionalRow in _schoolFeeDetailsTableCurrentCharge.Rows)
                {
                    if (optionalRow.RowState != DataRowState.Deleted &&
                     optionalFeeId == RemoteServerLib.ProcStatic.DataRowConvert(optionalRow, "optional_fee_id", Int64.Parse("0")))
                    {
                        DataRow delRow = _schoolFeeDetailsTableCurrentCharge.Rows[index];

                        if (delRow.RowState == DataRowState.Modified || delRow.RowState == DataRowState.Added)
                        {
                            delRow.AcceptChanges();
                        }

                        delRow.Delete();

                        break;
                    }

                    index++;
                }
            }
        }//-------------------------------

        //this function gets searched student and return count...(used to hide searched list when single result)
        public Int32 GetSearchedStudentDetails(CommonExchange.SysAccess userInfo, String queryString)
        {
            using (RemoteClient.RemCntStudentManager remClient = new RemoteClient.RemCntStudentManager())
            {
                _studentTable = remClient.SelectStudentInformation(userInfo, queryString, null, null, null, null);
            }

            return _studentTable.Rows.Count;
        }//---------------------------------

        //this fucntion get the searched scholarship information
        public DataTable GetSearchedScholarshipInformation(String queryString)
        {
            DataTable newTable = new DataTable("NewTable");
            newTable.Columns.Add("sysid_scholarship", System.Type.GetType("System.String"));
            newTable.Columns.Add("scholarship_description", System.Type.GetType("System.String"));
            newTable.Columns.Add("department_name", System.Type.GetType("System.String"));
            newTable.Columns.Add("group_description", System.Type.GetType("System.String"));

            queryString = queryString.Replace("*", "").Replace("%", "").Replace("'", "''");

            String strFilter = "scholarship_description LIKE '%" + queryString + "%' OR department_name LIKE '%" + queryString + "%'";
            DataRow[] selectRow = _classDataSet.Tables["ScholarshipInformationTable"].Select(strFilter, "scholarship_description ASC");

            foreach (DataRow scholarRow in selectRow)
            {
                DataRow newRow = newTable.NewRow();

                newRow["sysid_scholarship"] = RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "sysid_scholarship", "");
                newRow["scholarship_description"] = RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "scholarship_description", "");
                newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "department_name", "") + " [" +
                    RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "department_acronym", "") + "]";
                newRow["group_description"] = RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "group_description", String.Empty);

                newTable.Rows.Add(newRow);
            }

            return newTable;
        }//----------------------------

        //this fucntion get student id for single instance
        public String GetStudentIdForSingleInstance()
        {
            String value = String.Empty;

            if (_studentTable != null && _studentTable.Rows.Count == 1)
            {
                DataRow studRow = _studentTable.Rows[0];

                value = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", "");
            }

            return value;
        }//-------------------

        //this fucntion returns searched additional fee
        public DataTable GetSearchedAdditionalFee(String queryString)
        {
            DataTable newTable = new DataTable("AdditionalFeeTable");
            newTable.Columns.Add("sysid_feeparticular", System.Type.GetType("System.String"));
            newTable.Columns.Add("particular_description", System.Type.GetType("System.String"));
            newTable.Columns.Add("category_description", System.Type.GetType("System.String"));
            newTable.Columns.Add("is_optional", System.Type.GetType("System.String"));
            newTable.Columns.Add("is_office_access", System.Type.GetType("System.String"));
            newTable.Columns.Add("is_entry_level_included", System.Type.GetType("System.String"));
            newTable.Columns.Add("is_graduation_fee", System.Type.GetType("System.String"));

            queryString = queryString.Replace("*", "").Replace("%", "").Replace("'", "''");

            String strFilter = "particular_description LIKE '%" + queryString + "%'";
            DataRow[] selectRow = _classDataSet.Tables["ForAdditionalFeeSchoolFeeParticularTable"].Select(strFilter);

            foreach (DataRow feeRow in selectRow)
            {
                if (feeRow.RowState != DataRowState.Deleted && !RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_marked_deleted", false)) 
                {
                    DataRow newRow = newTable.NewRow();

                    newRow["sysid_feeparticular"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "sysid_feeparticular", "");
                    newRow["particular_description"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "particular_description", "");
                    newRow["category_description"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "category_description", "");
                    newRow["is_optional"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_optional", "");
                    newRow["is_office_access"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_office_access", "");
                    newRow["is_entry_level_included"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_entry_level_included", "");
                    newRow["is_graduation_fee"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_graduation_fee", "");

                    newTable.Rows.Add(newRow);
                }
            }
            
            return newTable;
        }//-------------------------

        //this function will get searched chart of accounts
        public DataTable GetSearchedChartOfAccount(CommonExchange.SysAccess userInfo, String queryString,
            String summaryAccount, String accountingCategoryIdList, Boolean isActiveAccount)
        {
            DataTable newTable = new DataTable("ChartOfAccountTable");
            newTable.Columns.Add("account_code_name", System.Type.GetType("System.String"));
            newTable.Columns.Add("category_description", System.Type.GetType("System.String"));
            newTable.Columns.Add("account_code_name_summary", System.Type.GetType("System.String"));
            newTable.Columns.Add("category_description_summary", System.Type.GetType("System.String"));
            newTable.Columns.Add("sysid_account", System.Type.GetType("System.String"));

            using (RemoteClient.RemCntAccountingManager remClient = new RemoteClient.RemCntAccountingManager())
            {
                _chartOfAccountsTable = remClient.SelectChartOfAccounts(userInfo, queryString, summaryAccount, accountingCategoryIdList, isActiveAccount);
            }

            if (_chartOfAccountsTable != null)
            {
                foreach (DataRow accoutRow in _chartOfAccountsTable.Rows)
                {
                    DataRow newRow = newTable.NewRow();

                    newRow["account_code_name"] = RemoteServerLib.ProcStatic.DataRowConvert(accoutRow, "account_code", String.Empty) + " - " +
                        RemoteServerLib.ProcStatic.DataRowConvert(accoutRow, "account_name", String.Empty);                        
                    newRow["category_description"] = RemoteServerLib.ProcStatic.DataRowConvert(accoutRow, "category_description", String.Empty);
                    newRow["account_code_name_summary"] = RemoteServerLib.ProcStatic.DataRowConvert(accoutRow, "account_code_summary", String.Empty) + " - " +
                        RemoteServerLib.ProcStatic.DataRowConvert(accoutRow, "account_name_summary", String.Empty);                        
                    newRow["category_description_summary"] = RemoteServerLib.ProcStatic.DataRowConvert(accoutRow, "category_description_summary", String.Empty);
                    newRow["sysid_account"] = RemoteServerLib.ProcStatic.DataRowConvert(accoutRow, "sysid_account", String.Empty);

                    newTable.Rows.Add(newRow);
                }
            }

            return newTable;
        }//------------------------------

        //this function will get searched student employee information
        public DataTable GetSearchedStudentEmployeeInformation(CommonExchange.SysAccess userInfo, String queryString, Boolean includeEmergencyContact)
        {
            DataTable newTable = this.StudentEmployeeTableFormat;

            using (RemoteClient.RemCntIdMakerManager remClient = new RemoteClient.RemCntIdMakerManager())
            {
                _studentEmployeeTable = remClient.SelectByQueryStringStudentEmployeeInformation(userInfo, queryString, includeEmergencyContact);
            }

            if (_studentEmployeeTable != null)
            {
                foreach (DataRow row in _studentEmployeeTable.Rows)
                {
                    DataRow newRow = newTable.NewRow();

                    newRow["student_employee_id"] = RemoteServerLib.ProcStatic.DataRowConvert(row, "student_employee_id", "");
                    newRow["student_employee_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(row, "last_name", "first_name", "middle_name");
                    newRow["card_number"] = RemoteServerLib.ProcStatic.DataRowConvert(row, "card_number", "");
                    newRow["acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(row, "acronym_employment_type", "");
                    newRow["course_title_department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(row, "course_title_department_name", String.Empty);
                    newRow["present_address"] = RemoteServerLib.ProcStatic.DataRowConvert(row, "present_address", String.Empty);
                    newRow["present_phone_nos"] = RemoteServerLib.ProcStatic.DataRowConvert(row, "present_phone_nos", String.Empty);

                    newTable.Rows.Add(newRow);
                }

            }

            return newTable;
        }//---------------------------
        
        //this function will get get searched cancelled receipt
        public DataTable GetSearchedCancelledReceiptNo(CommonExchange.SysAccess userInfo)
        {   
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                _cancelledReceiptTable = remClient.SelectCancelledReceiptNo(userInfo, this.ServerDateTime);
            }

            return _cancelledReceiptTable;
        }//----------------------

        //this fucntion will returns Student Detailss
        public CommonExchange.Student GetDetailsStudentInformation(String studentEmployeeId)
        {
            CommonExchange.Student studentInfo = new CommonExchange.Student();

            String strFilter = "student_employee_id = '" + studentEmployeeId + "'";
            DataRow[] selectRow = _studentEmployeeTable.Select(strFilter, "student_employee_id ASC");

            foreach (DataRow row in selectRow)
            {
                studentInfo.StudentSysId = RemoteServerLib.ProcStatic.DataRowConvert(row, "sysid_student_employee", "");
                studentInfo.StudentId = RemoteServerLib.ProcStatic.DataRowConvert(row, "student_employee_id", "");
                studentInfo.CardNumber = RemoteServerLib.ProcStatic.DataRowConvert(row, "card_number", "");
                studentInfo.PersonInfo.LastName = RemoteServerLib.ProcStatic.DataRowConvert(row, "last_name", "");
                studentInfo.PersonInfo.FirstName = RemoteServerLib.ProcStatic.DataRowConvert(row, "first_name", "");
                studentInfo.PersonInfo.MiddleName = RemoteServerLib.ProcStatic.DataRowConvert(row, "middle_name", "");
                studentInfo.PersonInfo.PresentAddress = RemoteServerLib.ProcStatic.DataRowConvert(row, "present_address", "");
                studentInfo.CourseInfo.CourseTitle = RemoteServerLib.ProcStatic.DataRowConvert(row, "course_title_department_name", "");
                studentInfo.CourseInfo.Acronym = RemoteServerLib.ProcStatic.DataRowConvert(row, "acronym_employment_type", "");
                studentInfo.PersonInfo.PersonSysId = RemoteServerLib.ProcStatic.DataRowConvert(row, "sysid_person", "");

                break;
            }

            return studentInfo;
        }//------------------------

        //this fucntion will returns Employee Details
        public CommonExchange.Employee GetDetailsEmployeeInformation(String studentEmployeeId)
        {

            CommonExchange.Employee employeeInfo = new CommonExchange.Employee();

            String strFilter = "student_employee_id = '" + studentEmployeeId + "'";
            DataRow[] selectRow = _studentEmployeeTable.Select(strFilter, "student_employee_id ASC");

            foreach (DataRow row in selectRow)
            {
                employeeInfo.EmployeeSysId = RemoteServerLib.ProcStatic.DataRowConvert(row, "sysid_student_employee", "");
                employeeInfo.EmployeeId = RemoteServerLib.ProcStatic.DataRowConvert(row, "student_employee_id", "");
                employeeInfo.CardNumber = RemoteServerLib.ProcStatic.DataRowConvert(row, "card_number", "");
                employeeInfo.PersonInfo.LastName = RemoteServerLib.ProcStatic.DataRowConvert(row, "last_name", "");
                employeeInfo.PersonInfo.FirstName = RemoteServerLib.ProcStatic.DataRowConvert(row, "first_name", "");
                employeeInfo.PersonInfo.MiddleName = RemoteServerLib.ProcStatic.DataRowConvert(row, "middle_name", "");
                employeeInfo.PersonInfo.PresentAddress = RemoteServerLib.ProcStatic.DataRowConvert(row, "present_address", "");
                employeeInfo.SalaryInfo.DepartmentInfo.DepartmentName = RemoteServerLib.ProcStatic.DataRowConvert(row, "course_title_department_name", "");
                employeeInfo.SalaryInfo.DepartmentInfo.Acronym = RemoteServerLib.ProcStatic.DataRowConvert(row, "acronym_employment_type", "");
                employeeInfo.PersonInfo.PersonSysId = RemoteServerLib.ProcStatic.DataRowConvert(row, "sysid_person", "");

                break;
            }

            return employeeInfo;
        }//------------------------

        //this fucntion will determine if the person is student or employee
        public Boolean IsStudent(String studentEmployeeId)
        {
            Boolean value = false;

            if (_studentEmployeeTable != null)
            {
                String strFilter = "student_employee_id = '" + studentEmployeeId + "'";
                DataRow[] selectRow = _studentEmployeeTable.Select(strFilter, "student_employee_id ASC");

                foreach (DataRow row in selectRow)
                {
                    value = RemoteServerLib.ProcStatic.DataRowConvert(row, "is_student", true);

                    break;
                }
            }

            return value;
        }//--------------------------

        //this function will get chart of account information
        public CommonExchange.ChartOfAccount GetChartOfAccountInformation(String accountSysId)
        {
            CommonExchange.ChartOfAccount chartOfAccountInfo = new CommonExchange.ChartOfAccount();

            if (_chartOfAccountsTable != null)
            {
                String strFilter = "sysid_account = '" + accountSysId + "'";
                DataRow[] selectRow = _chartOfAccountsTable.Select(strFilter);

                foreach (DataRow accountRow in selectRow)
                {
                    chartOfAccountInfo.AccountCode = RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "account_code", String.Empty);
                    chartOfAccountInfo.AccountName = RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "account_name", String.Empty);
                    chartOfAccountInfo.AccountSysId = RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "sysid_account", String.Empty);
                    chartOfAccountInfo.IsActiveAccount = RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "is_active_account", false);
                    chartOfAccountInfo.AccountingCategoryInfo.AccountingCategoryId =
                        RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "accounting_category_id", String.Empty);
                    chartOfAccountInfo.AccountingCategoryInfo.CategoryDescription =
                        RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "category_description", String.Empty);
                    chartOfAccountInfo.SummaryAccount.AccountSysId = RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "sysid_account_summary", String.Empty);
                    chartOfAccountInfo.SummaryAccount.AccountCode = RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "account_code_summary", String.Empty);
                    chartOfAccountInfo.SummaryAccount.AccountName = RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "account_name_summary", String.Empty);
                    chartOfAccountInfo.SummaryAccount.IsActiveAccount = 
                        RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "is_active_account_summary", false);
                    chartOfAccountInfo.SummaryAccount.AccountingCategoryInfo.AccountingCategoryId =
                        RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "accounting_category_id_summary", String.Empty);
                    chartOfAccountInfo.SummaryAccount.AccountingCategoryInfo.CategoryDescription =
                       RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "category_description_summary", String.Empty);

                    break;
                }
            }

            return chartOfAccountInfo;
        }//---------------------------

        //this function will get cancelled receipt information details
        public CommonExchange.CancelledReceiptNo GetCancelledReceiptInformationDetails(String receiptNo)
        {
            CommonExchange.CancelledReceiptNo receiptInfo = new CommonExchange.CancelledReceiptNo();

            if (_cancelledReceiptTable != null)
            {
                String strFilter = "receipt_no = '" + receiptNo + "'";
                DataRow[] selectRow = _cancelledReceiptTable.Select(strFilter);

                foreach (DataRow canclRow in selectRow)
                {
                    receiptInfo.ReceiptNo = RemoteServerLib.ProcStatic.DataRowConvert(canclRow, "receipt_no", String.Empty);
                    receiptInfo.Remarks = RemoteServerLib.ProcStatic.DataRowConvert(canclRow, "remarks", String.Empty);
                    receiptInfo.ReceiptDate = RemoteServerLib.ProcStatic.DataRowConvert(canclRow, "receipt_date", String.Empty);
                    receiptInfo.DateCancelled = RemoteServerLib.ProcStatic.DataRowConvert(canclRow, "date_cancelled", String.Empty);

                    break;
                }
            }

            return receiptInfo;
        }//---------------------

        //this function returns the additional fee details
        public CommonExchange.StudentAdditionalFee GetDetailsAdditionalFee(String sysidFeeParticular)
        {
            CommonExchange.StudentAdditionalFee studentAdditionalFeeInfo = new CommonExchange.StudentAdditionalFee();

            String strFilter = "sysid_feeparticular = '" + sysidFeeParticular + "'";
            DataRow[] selectRow = _classDataSet.Tables["ForAdditionalFeeSchoolFeeParticularTable"].Select(strFilter);

            foreach (DataRow feeRow in selectRow)
            {
                if (feeRow.RowState != DataRowState.Deleted)
                {
                    studentAdditionalFeeInfo.SchoolFeeParticularInfo.FeeParticularSysId =
                        RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "sysid_feeparticular", "");
                    studentAdditionalFeeInfo.SchoolFeeParticularInfo.ParticularDescription = 
                        RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "particular_description", "");

                    break;
                }
            }
            
            return studentAdditionalFeeInfo;
        }//--------------------------        
        
        //this function returns the additional fee details
        public CommonExchange.StudentAdditionalFee GetDetailsStudentAdditionalFee(String additionalFeeId)
        {
            CommonExchange.StudentAdditionalFee studentAdditionalFeeInfo = new CommonExchange.StudentAdditionalFee();

            String strFilter = "additional_fee_id = '" + additionalFeeId + "'";
            DataRow[] selectRow = _schoolFeeDetailsTableCurrentCharge.Select(strFilter);

            foreach (DataRow feeRow in selectRow)
            {
                if (feeRow.RowState != DataRowState.Deleted)
                {
                    studentAdditionalFeeInfo.AdditionalFeeId = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "additional_fee_id", Int64.Parse("0"));
                    studentAdditionalFeeInfo.SchoolFeeParticularInfo.FeeParticularSysId = 
                        RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "sysid_feeparticular", "");
                    studentAdditionalFeeInfo.SchoolFeeParticularInfo.ParticularDescription =
                        RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "particular_description", "");
                    studentAdditionalFeeInfo.Amount = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "amount", Decimal.Parse("0"));
                    studentAdditionalFeeInfo.Remarks = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "remarks", String.Empty);

                    break;
                }
            }

            return studentAdditionalFeeInfo;
        }//--------------------------

        //this function returns the additional fee details
        public CommonExchange.StudentAdditionalFee GetDetailsStudentAdditionalFeeByStudent(Int32 index)
        {
            CommonExchange.StudentAdditionalFee studentAdditionalFeeInfo = new CommonExchange.StudentAdditionalFee();

            if (_studentTableMultiple != null)
            {
                DataRow feeRow = _studentTableMultiple.Rows[index];

                studentAdditionalFeeInfo.AdditionalFeeId = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "additional_fee_id", Int64.Parse("0"));
                studentAdditionalFeeInfo.SchoolFeeParticularInfo.FeeParticularSysId =
                    RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "sysid_feeparticular", "");
                studentAdditionalFeeInfo.SchoolFeeParticularInfo.ParticularDescription =
                    RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "particular_description", "");
                studentAdditionalFeeInfo.Amount = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "amount", Decimal.Parse("0"));
                studentAdditionalFeeInfo.StudentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.IsCurrentCourse =
                    RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_current_course", false);
                studentAdditionalFeeInfo.Remarks = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "remarks", String.Empty);
            }          

            return studentAdditionalFeeInfo;
        }//--------------------------

        //this function returns the student details
        public CommonExchange.Student GetDetailsStudentInformation(CommonExchange.SysAccess userInfo, String studentId, String startUp)
        {
            CommonExchange.Student studentInfo = new CommonExchange.Student();

            if (!String.IsNullOrEmpty(studentId))
            {
                String strFilter = "student_id = '" + studentId + "'";
                DataRow[] selectRow = _studentTable.Select(strFilter);

                foreach (DataRow studRow in selectRow)
                {
                    studentInfo.StudentSysId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", String.Empty);
                    studentInfo.StudentId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", String.Empty);
                    studentInfo.CardNumber = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "card_number", String.Empty);
                    studentInfo.PersonInfo.LastName = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", String.Empty);
                    studentInfo.PersonInfo.FirstName = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", String.Empty);
                    studentInfo.PersonInfo.MiddleName = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", String.Empty);
                    studentInfo.IsInternational = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "is_international", false);
                    studentInfo.CourseInfo.CourseId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_id", String.Empty);
                    studentInfo.PersonInfo.PersonSysId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_person", String.Empty);
                    studentInfo.CourseInfo.CourseGroupInfo.CourseGroupId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_group_id", String.Empty);
                    studentInfo.Scholarship = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "scholarship", String.Empty);
                    studentInfo.CourseInfo.CourseGroupInfo.CourseGroupId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_group_id", String.Empty);
                    studentInfo.IsNoDownpaymentRequired = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "is_no_downpayment_required", false);

                    break;
                }

                studentInfo.PersonInfo.FilePath = base.GetPersonImagePath(userInfo, studentInfo.PersonInfo.PersonSysId, 
                    studentInfo.PersonInfo.PersonImagesFolder(startUp));
            }

            return studentInfo;
        }//----------------------------

        //this function returns the student details
        public CommonExchange.Student GetDetailsStudentInformation(CommonExchange.SysAccess userInfo, Int32 index, String startUp)
        {
            CommonExchange.Student studentInfo = new CommonExchange.Student();

            if (_studentTableMultiple != null)
            {
                DataRow studRow = _studentTableMultiple.Rows[index];

                studentInfo.StudentSysId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", String.Empty);
                studentInfo.StudentId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", String.Empty);
                studentInfo.CardNumber = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "card_number", String.Empty);
                studentInfo.PersonInfo.LastName = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", String.Empty);
                studentInfo.PersonInfo.FirstName = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", String.Empty);
                studentInfo.PersonInfo.MiddleName = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", String.Empty);
                studentInfo.IsInternational = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "is_international", false);
                studentInfo.CourseInfo.CourseId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_id", String.Empty);
                studentInfo.PersonInfo.PersonSysId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_person", String.Empty);
            }

            return studentInfo;
        }//----------------------------

        //this function returns student payment details
        public CommonExchange.StudentPayments GetDetailsStudentPayment(String paymentId)
        {
            CommonExchange.StudentPayments studentPaymentInfo = new CommonExchange.StudentPayments();

            String strFilter = "payment_discount_reimbursement_id = '" + paymentId + "' AND is_payment = 1";
            DataRow[] selectRow = _paymentReimbursementTable.Select(strFilter);

            foreach (DataRow paymentRow in selectRow)
            {
                studentPaymentInfo.PaymentId = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "payment_discount_reimbursement_id", Int64.Parse("0"));
                studentPaymentInfo.StudentInfo.StudentSysId = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "sysid_student", "");
                studentPaymentInfo.ReceivedDate = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
                    "received_date", "").ToString()).ToLongDateString() + " 12:00:00 AM";
                studentPaymentInfo.ReflectedDate = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, 
                    "reflected_date", "").ToString()).ToShortDateString() + " 12:00:00 AM";
                studentPaymentInfo.ReceiptDate = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
                    "receipt_date", "").ToString()).ToShortDateString() + " 12:00:00 AM";
                studentPaymentInfo.ReceiptNo = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "receipt_no", "");
                studentPaymentInfo.Remarks = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "");
                studentPaymentInfo.Amount = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));
                studentPaymentInfo.DiscountAmount = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0"));
                studentPaymentInfo.IsDownpayment = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false);
                studentPaymentInfo.IsMiscellaneousIncome = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_miscellaneous_income", false);
                studentPaymentInfo.AmountTendered = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount_tendered", Decimal.Parse("0"));
                studentPaymentInfo.Bank = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "bank", String.Empty);
                studentPaymentInfo.CheckNo = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "check_no", String.Empty);
                studentPaymentInfo.AccountCreditInfo.AccountSysId = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "sysid_account_credit", String.Empty);
                studentPaymentInfo.AccountCreditInfo.AccountCode = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "account_code", String.Empty);
                studentPaymentInfo.AccountCreditInfo.AccountName = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "account_name", String.Empty);
               
                break;
            }         

            return studentPaymentInfo;
        }//-------------------------

        //this fucntion get the student reimbursements
        public CommonExchange.StudentReimbursements GetDetailsStudentReimbursements(String reimbursementId)
        {
            CommonExchange.StudentReimbursements studentReimbursementInfo = new CommonExchange.StudentReimbursements();

            String strFilter = "payment_discount_reimbursement_id = '" + reimbursementId + "' AND is_reimbursement = 1";
            DataRow[] selectRow = _paymentReimbursementTable.Select(strFilter);

            foreach (DataRow reimRow in selectRow)
            {
                studentReimbursementInfo.ReimbursementId = RemoteServerLib.ProcStatic.DataRowConvert(reimRow, 
                    "payment_discount_reimbursement_id", Int64.Parse("0"));
                studentReimbursementInfo.StudentInfo.StudentSysId = RemoteServerLib.ProcStatic.DataRowConvert(reimRow, "sysid_student", "");
                studentReimbursementInfo.ReceivedDate = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(reimRow, 
                    "received_date", "").ToString()).ToLongDateString() + " 12:00:00 AM";
                studentReimbursementInfo.ReflectedDate = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(reimRow,
                    "reflected_date", "").ToString()).ToShortDateString() + " 12:00:00 AM";
                studentReimbursementInfo.Remarks = RemoteServerLib.ProcStatic.DataRowConvert(reimRow, "remarks_discount_reimbursement_description", "");
                studentReimbursementInfo.Amount = RemoteServerLib.ProcStatic.DataRowConvert(reimRow, "amount", Decimal.Parse("0"));
                studentReimbursementInfo.IsDownpayment = RemoteServerLib.ProcStatic.DataRowConvert(reimRow, "is_downpayment", false); 

                break;
            }

            return studentReimbursementInfo;
        }//-------------------------

        //this fucntion get the student credit memo
        public CommonExchange.StudentCreditMemo GetDetailsStudentCreditMemo(String creditMemoId)
        {
            CommonExchange.StudentCreditMemo studentCreditMemo = new CommonExchange.StudentCreditMemo();

            String strFilter = "payment_discount_reimbursement_id = '" + creditMemoId + "' AND is_credit_memo = 1";
            DataRow[] selectRow = _paymentReimbursementTable.Select(strFilter);

            foreach (DataRow creditRow in selectRow)
            {
                studentCreditMemo.MemoId = RemoteServerLib.ProcStatic.DataRowConvert(creditRow, "payment_discount_reimbursement_id", Int64.Parse("0"));
                studentCreditMemo.StudentInfo.StudentSysId = RemoteServerLib.ProcStatic.DataRowConvert(creditRow, "sysid_student", "");
                studentCreditMemo.ReceivedDate = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(creditRow, 
                    "received_date", "").ToString()).ToLongDateString() + " 12:00:00 AM";
                studentCreditMemo.ReflectedDate = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(creditRow,
                    "reflected_date", "").ToString()).ToShortDateString() + " 12:00:00 AM";
                studentCreditMemo.Remarks = RemoteServerLib.ProcStatic.DataRowConvert(creditRow, "remarks_discount_reimbursement_description", "");
                studentCreditMemo.Amount = RemoteServerLib.ProcStatic.DataRowConvert(creditRow, "amount", Decimal.Parse("0"));
                studentCreditMemo.IsDownpayment = RemoteServerLib.ProcStatic.DataRowConvert(creditRow, "is_downpayment", false);

                break;
            }

            return studentCreditMemo;
        }//-------------------------

        //this fucntion get student discount details
        public CommonExchange.StudentDiscounts GetDetailsStudentDiscount(String sysidStudentScholarship)
        {
            CommonExchange.StudentDiscounts studentDiscountInfo = new CommonExchange.StudentDiscounts();
            
            String strFilter = "sysid_studentscholarship = '" + sysidStudentScholarship + "'";
            DataRow[] selectRow = _studentScholarshipTable.Select(strFilter);

            foreach (DataRow scholarRow in selectRow)
            {
                studentDiscountInfo.Amount = RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "amount", Decimal.Parse("0"));
                studentDiscountInfo.ReflectedDate = RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "reflected_date", "");
                studentDiscountInfo.DiscountId = RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "discount_id", Int64.Parse("0"));
                studentDiscountInfo.Remarks = RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "remarks", "");
                studentDiscountInfo.StudentScholarshipInfo.ScholarshipInfo.ScholarshipDescription = 
                    RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "scholarship_description", "");
                studentDiscountInfo.StudentScholarshipInfo.StudentScholarshipSysId = 
                    RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "sysid_studentscholarship", "");            
                studentDiscountInfo.ReceivedDate = RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "received_date", String.Empty);
                studentDiscountInfo.IsDownpayment = RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "is_downpayment", false);

                break;
            }
                 
            return studentDiscountInfo;
        }//--------------------     

        //this fucntion get scholarship details
        public CommonExchange.ScholarshipInformation GetDetailsScholarshipInformation(String sysidScolarship)
        {
            CommonExchange.ScholarshipInformation scholarshipInfo = new CommonExchange.ScholarshipInformation();

            String strFilter = "sysid_scholarship = '" + sysidScolarship + "'";
            DataRow[] selectRow = _classDataSet.Tables["ScholarshipInformationTable"].Select(strFilter);

            foreach (DataRow scholarRow in selectRow)
            {
                scholarshipInfo.CourseGroupInfo.CourseGroupId = RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "course_group_id", "");
                scholarshipInfo.DepartmentInfo.DepartmentId = RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "department_id", "");
                scholarshipInfo.IsNonAcademic = RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "is_non_academic", false);
                scholarshipInfo.ScholarshipDescription = RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "scholarship_description", "");
                scholarshipInfo.ScholarshipSysId = RemoteServerLib.ProcStatic.DataRowConvert(scholarRow, "sysid_scholarship", "");

                break;
            }

            return scholarshipInfo;
        }//------------------------

        //this function get student enrolment level information
        public CommonExchange.StudentEnrolmentLevel GetStudentEnrolmentLevelInfo(Int32 index)
        {
            CommonExchange.StudentEnrolmentLevel enrolmentLevelInfo = new CommonExchange.StudentEnrolmentLevel();

            if (index != 0)
            {
                DataRow studRow = _studentLevelTable.Rows[index - 1];

                enrolmentLevelInfo.EnrolmentLevelSysId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", "");
                enrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_feelevel", "");
                enrolmentLevelInfo.IsGraduateStudent = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "is_graduate_student", false);
                enrolmentLevelInfo.IsInternational = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "is_international", false);
                enrolmentLevelInfo.IsMarkedDeleted = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "is_marked_deleted", false);
                enrolmentLevelInfo.IsEntryLevel = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "is_entry_level", false);
                enrolmentLevelInfo.StudentEnrolmentCourseInfo.EnrolmentCourseSysId =
                    RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentcourse", String.Empty);
                enrolmentLevelInfo.StudentEnrolmentCourseInfo.CourseInfo.CourseGroupInfo.CourseGroupId =
                    RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_group_id", String.Empty);
                enrolmentLevelInfo.StudentEnrolmentCourseInfo.CourseInfo.CourseId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_id", String.Empty);
                enrolmentLevelInfo.SchoolFeeLevelInfo.YearLevelInfo.YearLevelDescription =
                    RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_description", String.Empty);
                enrolmentLevelInfo.LevelSection = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "level_section", String.Empty);
                enrolmentLevelInfo.IsInternational = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "is_international", false);
            }
   
            return enrolmentLevelInfo;
        }//------------------------     
 
        //this fucntion get student promissory note
        public CommonExchange.StudentPromissoryNote GetStudentPromissoryNote(String promissoryNoteId)
        {
            CommonExchange.StudentPromissoryNote studentPromissoryNoteInfo = new CommonExchange.StudentPromissoryNote();

            String strFilter = "promissory_note_id = '" + promissoryNoteId + "'";
            DataRow[] selectRow = _studentPromissoryNoteTable.Select(strFilter);

            foreach (DataRow noteRow in selectRow)
            {
                studentPromissoryNoteInfo.PromissoryNoteId = RemoteServerLib.ProcStatic.DataRowConvert(noteRow, "promissory_note_id", Int64.Parse("0"));
                studentPromissoryNoteInfo.StudentInfo.StudentSysId = RemoteServerLib.ProcStatic.DataRowConvert(noteRow, "sysid_student", String.Empty);
                studentPromissoryNoteInfo.ReflectedDate = RemoteServerLib.ProcStatic.DataRowConvert(noteRow, "reflected_date", String.Empty);
                studentPromissoryNoteInfo.ReceivedDate = RemoteServerLib.ProcStatic.DataRowConvert(noteRow, "received_date", String.Empty);
                studentPromissoryNoteInfo.ReferenceNo = RemoteServerLib.ProcStatic.DataRowConvert(noteRow, "reference_no", String.Empty);
                studentPromissoryNoteInfo.PromissoryNote = RemoteServerLib.ProcStatic.DataRowConvert(noteRow, "promissory_note", String.Empty);
                studentPromissoryNoteInfo.IsDownpayment = RemoteServerLib.ProcStatic.DataRowConvert(noteRow, "is_downpayment", false);
            }

            return studentPromissoryNoteInfo;
        }//-------------------------

        //this function will get miscellaneous income information
        public CommonExchange.MiscellaneousIncome GetDetailsMiscellaneousIncomeInformation(String paymentId)
        {
            CommonExchange.MiscellaneousIncome miscellaneouseIncomeInfo = new CommonExchange.MiscellaneousIncome();

            if (_miscellaneouseIncomeTable != null)
            {
                String strFilter = "payment_id = " + paymentId;
                DataRow[] selectRow = _miscellaneouseIncomeTable.Select(strFilter);

                foreach(DataRow miscRow in selectRow)
                {
                    miscellaneouseIncomeInfo.PaymentId = RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "payment_id", Int64.Parse("0"));
                    miscellaneouseIncomeInfo.ReceivedFrom = RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "received_from", String.Empty);
                    miscellaneouseIncomeInfo.ReflectedDate = RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "reflected_date", String.Empty);
                    miscellaneouseIncomeInfo.ReceivedDate = RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "received_date", String.Empty);
                    miscellaneouseIncomeInfo.ReceiptDate = RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "receipt_date", String.Empty);
                    miscellaneouseIncomeInfo.ReceiptNo = RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "receipt_no", String.Empty);
                    miscellaneouseIncomeInfo.Remarks = RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "remarks", String.Empty);
                    miscellaneouseIncomeInfo.Amount = RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "amount", Decimal.Parse("0"));
                    miscellaneouseIncomeInfo.DiscountAmount = RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "discount_amount", Decimal.Parse("0"));
                    miscellaneouseIncomeInfo.AmountTendered = RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "amount_tendered", Decimal.Parse("0"));
                    miscellaneouseIncomeInfo.Bank = RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "bank", String.Empty);
                    miscellaneouseIncomeInfo.CheckNo = RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "check_no", String.Empty);
                    miscellaneouseIncomeInfo.AccountCreditInfo.AccountSysId =
                        RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "sysid_account_credit", String.Empty);
                    miscellaneouseIncomeInfo.AccountCreditInfo.AccountCode = RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "account_code", String.Empty);
                    miscellaneouseIncomeInfo.AccountCreditInfo.AccountName = RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "account_name", String.Empty);

                    if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "sysid_student", String.Empty)))
                    {
                        miscellaneouseIncomeInfo.StudentInfo.StudentSysId = RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "sysid_student", String.Empty);
                    }
                    else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "sysid_employee", String.Empty)))
                    {
                        miscellaneouseIncomeInfo.EmployeeInfo.EmployeeSysId = RemoteServerLib.ProcStatic.DataRowConvert(miscRow, "sysid_employee", String.Empty);
                    }

                    break;
                }
            }

            return miscellaneouseIncomeInfo;
        }//----------------------

        //this function will get break down bank deposite information
        public CommonExchange.BreakdownBankDeposit GetDetailsBreakDownBankDepositInformation(String accountSysId)
        {
            CommonExchange.BreakdownBankDeposit breakDownDepositInfo = new CommonExchange.BreakdownBankDeposit();

            if (_breakDownBankDepositDetailsTable != null)
            {
                String strFilter = "sysid_account = '" + accountSysId + "'";
                DataRow[] selectRow = _breakDownBankDepositDetailsTable.Select(strFilter);

                foreach (DataRow depositRow in selectRow)
                {
                    breakDownDepositInfo.AccountInfo.AccountSysId = RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "sysid_account", String.Empty);
                    breakDownDepositInfo.AccountInfo.AccountCode = RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "account_code", String.Empty);
                    breakDownDepositInfo.AccountInfo.AccountName = RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "account_name", String.Empty);
                    breakDownDepositInfo.AccountInfo.SummaryAccount.AccountSysId = RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "sysid_account_summary", String.Empty);
                    breakDownDepositInfo.AccountInfo.SummaryAccount.AccountCode = RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "account_code_summary", String.Empty);
                    breakDownDepositInfo.AccountInfo.SummaryAccount.AccountName = RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "account_name_summary", String.Empty);
                    breakDownDepositInfo.BreakdownId = RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "breakdown_id", Int64.Parse("0"));
                    breakDownDepositInfo.DateStart = RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "date_start", String.Empty);
                    breakDownDepositInfo.DateEnd = RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "date_end", String.Empty);
                    breakDownDepositInfo.Amount = RemoteServerLib.ProcStatic.DataRowConvert(depositRow, "amount", Decimal.Parse("0"));

                    break;
                }
            }

            return breakDownDepositInfo;
        }//-----------------------

        //this function will get details student balance forwarded
        public CommonExchange.StudentBalanceForwarded GetDetailsStudentBalanceForwarded(ref DateTime receivedDate)
        {
            CommonExchange.StudentBalanceForwarded studentBalanceForwardedInfo = new CommonExchange.StudentBalanceForwarded();

            if (_paymentReimbursementTable != null)
            {
                foreach (DataRow payRow in _paymentReimbursementTable.Rows)
                {
                    if (RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_balance_forwarded", false))
                    {
                        studentBalanceForwardedInfo.Amount = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "amount", Decimal.Parse("0"));
                        studentBalanceForwardedInfo.BalanceId = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "payment_discount_reimbursement_id", Int64.Parse("0"));

                        receivedDate = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(payRow, "received_date", String.Empty));
                    }
                }
            }

            return studentBalanceForwardedInfo;
        }//----------------------------------

        //this fucntion will determine if a student balance forwarded exist
        public Boolean IsExistsSysIDStudentStudentBalanceForwarded(CommonExchange.SysAccess userInfo, String studentSysId)
        {
            Boolean value = false;

            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                value = remClient.IsExistsSysIDStudentStudentBalanceForwarded(userInfo, studentSysId);
            }

            return value;
        }//------------------------

        //this function determines if student scholarship already exsits
        public Boolean IsExistsSysIDStudentScholarshipEnrolmentLevelStudentScholarship(CommonExchange.SysAccess userInfo,
            CommonExchange.StudentScholarship studentScholarship)
        {
            Boolean value;

            using (RemoteClient.RemCntScholarshipManager remClient = new RemoteClient.RemCntScholarshipManager())
            {
                value = remClient.IsExistsSysIDStudentScholarshipEnrolmentLevelStudentScholarship(userInfo, studentScholarship);
            }

            return value;
        }//--------------------------

        //this function determines if is semestral
        public Boolean IsSemestral()
        {
            Boolean isSemestral = true;

            if (_studentCourseTable != null)
            {
                foreach (DataRow semRow in _studentCourseTable.Rows)
                {
                    if (RemoteServerLib.ProcStatic.DataRowConvert(semRow, "is_current_course", false))
                    {
                        isSemestral = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "is_semestral", false);

                        break;
                    }
                }
            }

            return isSemestral;
        }//------------------------ 

        //this function determines if is semestral
        public Boolean IsSemestral(String enrolmentLevelSysId)
        {
            Boolean isSemestral = true;

            if (_studentLevelTable != null)
            {
                String strFilter = "sysid_enrolmentlevel = '" + enrolmentLevelSysId + "'";
                DataRow[] selectRow = _studentLevelTable.Select(strFilter);

                foreach (DataRow levelRow in selectRow)
                {
                    isSemestral = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "is_semestral", false);
                }
            }

            return isSemestral;
        }//------------------------ 
          
        //this fucntion determines if year level is enrolled
        public Boolean IsEnrolled(Int32 index)
        {
            Boolean isEnrolled = false;

            if (index != 0)
            {
                DataRow studRow = _studentLevelTable.Rows[index - 1];

                isEnrolled = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "is_enrolled", false);
            }

            return isEnrolled;
        }//--------------------------      

        //this function will determine if the school year is for summer
        public Boolean IsSchoolYearForSummer(String yearId)
        {
            Boolean isSummer = false;

            String strFilter = "year_id = '" + yearId + "'";
            DataRow[] selectRow = _classDataSet.Tables["SchoolFeeInformationTable"].Select(strFilter);

            foreach (DataRow yearRow in selectRow)
            {
                isSummer = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "is_summer", false);
            }

            return isSummer;
        }//------------------------

        //this function gets the school year date start
        public DateTime GetSchoolYearDateStart(String yearId)
        {
            DateTime dateStart = DateTime.Parse(_serverDateTime);

            foreach (DataRow yearRow in _classDataSet.Tables["SchoolFeeInformationTable"].Rows)
            {
                if (String.Equals(yearId, yearRow["year_id"].ToString()) && DateTime.TryParse(yearRow["date_start"].ToString(), out dateStart))
                {
                    break;
                }
            }

            return dateStart;
        }//----------------------------------------

        //this function gets the school year date end
        public DateTime GetSchoolYearDateEnd(String yearId)
        {
            DateTime dateEnd = DateTime.Parse(_serverDateTime);

            foreach (DataRow yearRow in _classDataSet.Tables["SchoolFeeInformationTable"].Rows)
            {
                if (String.Equals(yearId, yearRow["year_id"].ToString()) &&
                    DateTime.TryParse(yearRow["date_end"].ToString(), out dateEnd))
                {
                    break;
                }
            }

            return dateEnd;
        }//------------------------------     

        //this function gets the semester date start
        public DateTime GetSemesterDateStart(String sysIdSemester)
        {
            DateTime dateStart = DateTime.Parse(_serverDateTime);

            foreach (DataRow semRow in _classDataSet.Tables["SemesterInformationTable"].Rows)
            {
                if (String.Equals(sysIdSemester, semRow["sysid_semester"].ToString()) &&
                    DateTime.TryParse(semRow["date_start"].ToString(), out dateStart))
                {
                    break;
                }
            }

            return dateStart;
        }//----------------------------------------    

        //this function gets the semester date end
        public DateTime GetSemesterDateEnd(String sysIdSemester)
        {
            DateTime dateEnd = DateTime.Parse(_serverDateTime);

            foreach (DataRow yearRow in _classDataSet.Tables["SemesterInformationTable"].Rows)
            {
                if (String.Equals(sysIdSemester, yearRow["sysid_semester"].ToString()) &&
                    DateTime.TryParse(yearRow["date_end"].ToString(), out dateEnd))
                {
                    break;
                }
            }

            return dateEnd;
        }//------------------------------

        //this function gets the school year year id
        public String GetSchoolYearYearId(Int32 index)
        {
            DataRow yearRow = _classDataSet.Tables["SchoolFeeInformationTable"].Rows[index];

            return yearRow["year_id"].ToString();
        }//----------------------------

        //this function gets the school year year id
        public String GetSchoolYearYearIdNoSummer(Int32 index)
        {
            DataTable yearTable = _classDataSet.Tables["SchoolFeeInformationTable"];

            DataRow[] selectRow = yearTable.Select("is_summer = 0");
            DataRow yearRow = selectRow[index];

            return yearRow["year_id"].ToString();
        }//----------------------------

        //this function gets the course id
        public String GetCourseId(Int32 index)
        {
            if (_classDataSet.Tables["CourseInformationTable"] != null)
            {
                DataRow courseRow = _classDataSet.Tables["CourseInformationTable"].Rows[index];

                return RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", "");
            }
            else
            {
                return String.Empty;
            }
        } //---------------------------- 

        //this function gets the course id
        public String GetScholarshipId(Int32 index)
        {
            if (_classDataSet.Tables["ScholarshipInformationTable"] != null)
            {
                DataRow courseRow = _classDataSet.Tables["ScholarshipInformationTable"].Rows[index];

                return RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "sysid_scholarship", "");
            }
            else
            {
                return String.Empty;
            }
        } //---------------------------- 

        //this function gets the particula description
        public String GetParticularDescription(String sysIdFeeDetails)
        {
            String value = String.Empty;

            String strFilter = "sysid_feedetails = '" + sysIdFeeDetails + "'";
            DataRow[] selectRow = _optionalSchoolFeeDetailsTable.Select(strFilter);

            foreach (DataRow feeRow in selectRow)
            {
                if (feeRow.RowState != DataRowState.Deleted)
                {
                    value = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "particular_description", "") + " - " +
                        RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "amount", Decimal.Parse("0")).ToString("N");

                    break;
                }
            }

            return value;
        }//---------------------------

        //this function gets year level id
        public String GetYearLevelId(Int32 index)
        {
            DataRow levelRow = _classDataSet.Tables["YearLevelInformationTable"].Rows[index];

            return levelRow["year_level_id"].ToString();
        }//-------------------------------


        //this function gets the enrolemt course sysmtem id
        public String GetEnrolmentCourseSysId(String sysIdSemester, Boolean isSemestral)
        {
            String value = String.Empty;

            String strFilter = String.Empty;

            if (isSemestral)
            {
                strFilter = "last_semester_enrolled = '" + sysIdSemester + "'";
            }

            DataRow[] selectRow = _studentCourseTable.Select(strFilter);

            if (selectRow.Length == 0 && isSemestral)
            {
                strFilter = "is_current_course = 1";

                selectRow = _studentCourseTable.Select(strFilter);

                if (selectRow.Length == 0)
                {
                    strFilter = "is_current_course = 0";

                    selectRow = _studentCourseTable.Select(strFilter);
                }
            }

            foreach (DataRow courseRow in selectRow)
            {
                if (RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "is_current_course", false))
                {
                    value = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "sysid_enrolmentcourse", "");

                    break;
                }
            }

            return value;
        }//---------------------------

        //AC
        //this function gets the enrolemt course sysmtem id
        public String GetEnrolmentCourseSysId(Int32 index, String sysIdSemester, Boolean isSemestral, ref String courseTitle)
        {
            String value = String.Empty;
            
            if (index != 0)
            {
                DataRow resultrow = _studentCourseTable.Rows[index - 1];

                value = RemoteServerLib.ProcStatic.DataRowConvert(resultrow, "sysid_enrolmentcourse", "");

                courseTitle = RemoteServerLib.ProcStatic.DataRowConvert(resultrow, "course_title", "");
            }
         
            return value;
        }//---------------------------
        //--------------------------

        //this function get the enrolment course acronym
        public String GetEnrolmentCourseAcronym(String enrolmentCourseSysId)
        {
            String acronym = String.Empty;

            if (_studentCourseTable != null)
            {
                String strFilter = "sysid_enrolmentcourse = '" + enrolmentCourseSysId + "'";
                DataRow[] selectRow = _studentCourseTable.Select(strFilter);

                foreach (DataRow courseRow in selectRow)
                {
                    acronym = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_acronym", String.Empty);

                    break;
                }
            }

            return acronym;
        }//---------------------

        //this function will determine the current course
        public Boolean IsCurrentCourse(String sysIdEnrolmentCourse)
        {
            Boolean value = false;

            String strFilter = "sysid_enrolmentcourse = '" + sysIdEnrolmentCourse + "'";
            DataRow[] selectRow = _studentCourseTable.Select(strFilter);

            foreach (DataRow courseRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "is_current_course", false);
            }

            return value;
        }//---------------------

        //this procedure will determine if the examination schedule is clearance included
        public Boolean IsClearanceIncluded(String majorExamId)
        {
            Boolean value = false;

            if (_majorExamScheduleTable != null)
            {
                String strFilter = "major_exam_id = '" + majorExamId + "'";
                DataRow[] selectRow = _majorExamScheduleTable.Select(strFilter);

                foreach (DataRow examRow in selectRow)
                {
                    value = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_clearance_included", false);
                }
            }

            return value;

        }//----------------------------

        //this function gets the semester system id
        public String GetSemesterSystemId(Int32 yearIndex, Int32 semIndex)
        {
            DataRow yearRow = _classDataSet.Tables["SchoolFeeInformationTable"].Rows[yearIndex];

            String strFilter = "year_id = '" + yearRow["year_id"].ToString() + "'";
            DataRow[] selectRow = _classDataSet.Tables["SemesterInformationTable"].Select(strFilter);

            if (semIndex >= 0)
            {
                DataRow semRow = selectRow[semIndex];

                return RemoteServerLib.ProcStatic.DataRowConvert(semRow, "sysid_semester", "");
            }
            else
            {
                return String.Empty;
            }
        }//-----------------------------------------
       
        //this procedure will gets payment reflected date
        public DateTime GetReflectedDate(DateTime dateStart, DateTime dateEnd)
        {
            if (((DateTime.Compare(dateStart, DateTime.Parse(_serverDateTime)) <= 0) &&
                DateTime.Compare(dateEnd, DateTime.Parse(_serverDateTime)) >= 0) ||
                DateTime.Compare(dateEnd, DateTime.Parse(_serverDateTime)) < 0)
            {
                return DateTime.Parse(_serverDateTime);
            }
            else
            {
                return dateStart;
            }
        }//---------------------------------

        //this function gets the units hours string
        private String GetSubjectUnitsHours(Int32 lectUnits, Int32 nonAcad, Int32 labUnits, String noHours)
        {
            return "Lecture: " + lectUnits.ToString() + (nonAcad > 0 ? " (" + nonAcad + ")  " : String.Empty + "  ") +
                ((lectUnits > 1) ? "units" : "unit") + "     " +
                "Laboratory / RLE: " + labUnits.ToString() + " " + ((labUnits > 1) ? "units" : "unit") + "     " +
                "No. of Hours: " + noHours;
        }//-----------------------------------            

        //this fucntion gets the course yearlevel string format
        public String GetCourseYearLevelStringFormat(CheckedListBox cbXBase, Boolean isCourse)
        {
            StringBuilder strValue = new StringBuilder();

            if (cbXBase.CheckedIndices.Count >= 1)
            {
                IEnumerator myEnum = cbXBase.CheckedIndices.GetEnumerator();
                Int32 x;

                while (myEnum.MoveNext() != false)
                {
                    x = (Int32)myEnum.Current;

                    if (isCourse)
                    {
                        strValue.Append(this.GetCourseId(x) + ", ");
                    }
                    else
                    {
                        strValue.Append(this.GetYearLevelId(x) + ", ");
                    }
                }
            }

            if (strValue.Length >= 2)
            {
                return strValue.ToString().Substring(0, strValue.Length - 2);
            }
            else
            {
                return String.Empty;
            }
        }//-------------------------

        //this fucntion gets the course yearlevel string format
        public String GetScholarshipStringFormat(CheckedListBox cbXBase)
        {
            StringBuilder strValue = new StringBuilder();

            if (cbXBase.CheckedIndices.Count >= 1)
            {
                IEnumerator myEnum = cbXBase.CheckedIndices.GetEnumerator();
                Int32 x;

                while (myEnum.MoveNext() != false)
                {
                    x = (Int32)myEnum.Current;

                    strValue.Append(this.GetScholarshipId(x) + ", ");                   
                }
            }

            if (strValue.Length >= 2)
            {
                return strValue.ToString().Substring(0, strValue.Length - 2);
            }
            else
            {
                return String.Empty;
            }
        }//-------------------------


        //this function determines if the student has current couse
        private Boolean HasCurrentCourse()
        {
            Boolean hasCurrentCourse = false;

            if (_studentCourseTable != null)
            {
                foreach (DataRow courseRow in _studentCourseTable.Rows)
                {
                    if (RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "is_current_course", true))
                    {
                        hasCurrentCourse = true;

                        break;
                    }
                }
            }

            return hasCurrentCourse;
        }//---------------------------

        //this function gets the semester description
        private String GetSemesterDescription(String sysIdSemester)
        {
            String value = String.Empty;

            String strFilter = "sysid_semester = '" + sysIdSemester + "'";
            DataRow[] selectRow = _classDataSet.Tables["SemesterInformationTable"].Select(strFilter);

            foreach (DataRow semRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "semester_description", "");
            }

            return value;
        }//------------------------------------

        //this function gets the year level description
        private String GetYearLevelDescription(String sysIdSchoolFee)
        {
            String value = String.Empty;

            String strFilter = "sysid_schoolfee = '" + sysIdSchoolFee + "'";
            DataRow[] selectRow = _classDataSet.Tables["SchoolFeeInformationTable"].Select(strFilter);

            foreach (DataRow yearRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "year_description", "");
            }

            return value;
        }//----------------------------

        //this function will get course title
        public String GetCourseTitleCourseGroup(String sysIdEnrolmentCourse)
        {
            String value = String.Empty;

            String strFilter = "sysid_enrolmentcourse = '" + sysIdEnrolmentCourse + "'";
            DataRow[] selectRow = _studentCourseTable.Select(strFilter);

            foreach (DataRow courseRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_title", String.Empty);

                break;
            }

            return value;
        }//--------------------

        //this fucntion gets the subject code title
        public String GetSubjectCodeTitle(String sysIdSchedule)
        {
            String value = String.Empty;

            String strFilter = "sysid_schedule = '" + sysIdSchedule + "'";
            DataRow[] selectRow = _subjectScheduleTable.Select(strFilter);

            foreach (DataRow subRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_code", "") + " - " +
                    RemoteServerLib.ProcStatic.DataRowConvert(subRow, "descriptive_title", "");

                break;
            }

            return value;
        }//-------------------------        

        //this function get the special class subject code title
        public String GetSpecialClassCodeTitle(String sysidSpecialClass)
        {
            String value = String.Empty;

            String strFilter = "sysid_special = '" + sysidSpecialClass + "'";
            DataRow[] selectRow = _specialClassTable.Select(strFilter);

            foreach (DataRow specialRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_code", "") + " - " +
                    RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "descriptive_title", "");

                break;
            }

            return value;
        }//-------------------------

        //this function get the special class load id
        public Int64 GetSpecialClassLoadId(String sysidSpecialClass)
        {
            Int64 value = 0;

            String strFilter = "sysid_special = '" + sysidSpecialClass + "'";
            DataRow[] selectRow = _specialClassTable.Select(strFilter);

            foreach (DataRow specialRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "load_id", Int64.Parse("0"));
                   
                break;
            }

            return value;
        }//-------------------------

        //this function will  year level description and course group
        private String GetYearLevelDescriptionCourseGroup(String sysiFeeLevel, Boolean isYearLevel)
        {
            String value = String.Empty;

            String strFilter = "sysid_feelevel = '" + sysiFeeLevel + "'";
            DataRow[] selectRow = _studentLevelTable.Select(strFilter);

            foreach (DataRow courseRow in selectRow)
            {
                if (isYearLevel)
                {
                    value = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "year_level_description", String.Empty);
                }
                else
                {
                    value = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_group_id", String.Empty);
                }

                break;
            }

            return value;
        }//-----------------------

        //this fucntion will return String amount
        private String GetStringAmount(Decimal amount)
        {
            return amount > 0 ? amount.ToString("N") : "(" + amount.ToString("N").Remove(0,1) + ")";
        }//-----------------------------

        //this fucntion will set is downpayment text
        private String SetDownpaymentText(Boolean isDownPayment)
        {
            return isDownPayment ? "Yes" : "No";
        }//-----------------------

        //this function will get amount to be added
        private Decimal GetToBeAddedAmount(Decimal amountBase, ref Decimal downpayment)
        {
            Decimal amountToBeAdded = 0;
          
            amountToBeAdded = amountBase - downpayment;
            downpayment = amountBase;           

            return amountToBeAdded;
        }//-----------------------------

        //this function will get total payment between the date start and ende
        private Decimal GetTotalPaymentByDateStartEnd(DateTime dateStart, DateTime dateEnd, DataTable paymentReimbursemenTableTemp, Boolean isFirstEnter)
        {
            Decimal totalPayment = 0;

            foreach (DataRow payRow in paymentReimbursemenTableTemp.Rows)
            {
                DateTime paymentDate = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(payRow, "reflected_date", String.Empty));

                if (RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_payment", false) ||
                    RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_discount", false) ||
                    RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_credit_memo", false))
                {
                    if (!isFirstEnter)
                    {
                        if (DateTime.Compare(paymentDate, dateStart) > 0 && DateTime.Compare(paymentDate, dateEnd) <= 0)
                        {
                            totalPayment += RemoteServerLib.ProcStatic.DataRowConvert(payRow, "amount", Decimal.Parse("0")) +
                                RemoteServerLib.ProcStatic.DataRowConvert(payRow, "discount_amount", Decimal.Parse("0"));
                        }
                    }
                    else
                    {
                        if (DateTime.Compare(paymentDate, dateStart) >= 0 && DateTime.Compare(paymentDate, dateEnd) <= 0)
                        {
                            totalPayment += RemoteServerLib.ProcStatic.DataRowConvert(payRow, "amount", Decimal.Parse("0")) +
                                RemoteServerLib.ProcStatic.DataRowConvert(payRow, "discount_amount", Decimal.Parse("0"));
                        }
                    }
                }
            }

            return totalPayment;
        }//----------------------       

        //this function will get total payment between the date start and ende
        private DataTable GetTotalPaymentByDateStartEnd(DateTime dateStart, DateTime dateEnd,
            DataTable paymentReimbursemenTableTemp, DataTable termPaymentTable, ref Decimal totalPaymentByTermForPrinting, Boolean isFirstEnter)
        {
            termPaymentTable.Columns.Add("description", System.Type.GetType("System.String"));
            termPaymentTable.Columns.Add("text_balance", System.Type.GetType("System.String"));
            termPaymentTable.Columns.Add("amount", System.Type.GetType("System.String"));
            termPaymentTable.Columns.Add("total_amount", System.Type.GetType("System.String"));
      
            foreach (DataRow paymentRow in paymentReimbursemenTableTemp.Rows)
            {
                DateTime paymentDate = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "reflected_date", String.Empty));

                if (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_payment", false) ||
                    RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_discount", false) ||
                    RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_credit_memo", false))
                {

                    if (!isFirstEnter)
                    {
                        if (DateTime.Compare(paymentDate, dateStart) > 0 && DateTime.Compare(paymentDate, dateEnd) <= 0)
                        {
                            totalPaymentByTermForPrinting += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) +
                                RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0"));

                            String remarksDescription = String.Empty;
                            String paymentDiscountReimbursementDate = String.Empty;

                            if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                                (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_payment", false) &&
                                !RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false)))
                            {
                                remarksDescription = "Payment";
                            }
                            else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                                RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false))
                            {
                                remarksDescription = "Downpayment";
                            }
                            else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                               RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false))
                            {
                                remarksDescription = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "");
                            }
                            else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                                RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_reimbursement", false))
                            {
                                remarksDescription = "Reimbursement";
                            }
                            else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                                   RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_credit_memo", false))
                            {
                                remarksDescription = "Credit Memo";
                            }
                            else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")))
                            {
                                remarksDescription = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "");
                            }

                            DateTime pDate;

                            if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "received_date", ""), out pDate))
                            {
                                paymentDiscountReimbursementDate = pDate.ToShortDateString();
                            }

                            if (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) > 0)
                            {
                                DataRow newRowTerm = termPaymentTable.NewRow();

                                newRowTerm["description"] = "   " + remarksDescription + " - " + paymentDiscountReimbursementDate;
                                newRowTerm["text_balance"] = String.Empty;
                                newRowTerm["amount"] = this.GetStringAmount(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")));
                                newRowTerm["total_amount"] = String.Empty;

                                termPaymentTable.Rows.Add(newRowTerm);
                            }

                            if (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0")) > 0)
                            {
                                DataRow newRowDis = termPaymentTable.NewRow();

                                newRowDis["description"] = "   Cash Discount - " + paymentDiscountReimbursementDate;
                                newRowDis["text_balance"] = String.Empty;
                                newRowDis["amount"] =
                                    this.GetStringAmount(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0")));
                                newRowDis["total_amount"] = String.Empty;

                                termPaymentTable.Rows.Add(newRowDis);
                            }
                        }
                    }
                    else
                    {
                        if (DateTime.Compare(paymentDate, dateStart) >= 0 && DateTime.Compare(paymentDate, dateEnd) <= 0)
                        {
                            totalPaymentByTermForPrinting += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) +
                                RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0"));

                            String remarksDescription = String.Empty;
                            String paymentDiscountReimbursementDate = String.Empty;

                            if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                                (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_payment", false) &&
                                !RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false)))
                            {
                                remarksDescription = "Payment";
                            }
                            else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                                RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false))
                            {
                                remarksDescription = "Downpayment";
                            }
                            else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                               RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false))
                            {
                                remarksDescription = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "");
                            }
                            else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                                RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_reimbursement", false))
                            {
                                remarksDescription = "Reimbursement";
                            }
                            else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                                   RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_credit_memo", false))
                            {
                                remarksDescription = "Credit Memo";
                            }
                            else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")))
                            {
                                remarksDescription = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "");
                            }

                            DateTime pDate;

                            if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "received_date", ""), out pDate))
                            {
                                paymentDiscountReimbursementDate = pDate.ToShortDateString();
                            }

                            if (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) > 0)
                            {
                                DataRow newRowTerm = termPaymentTable.NewRow();

                                newRowTerm["description"] = "   " + remarksDescription + " - " + paymentDiscountReimbursementDate;
                                newRowTerm["text_balance"] = String.Empty;
                                newRowTerm["amount"] = this.GetStringAmount(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")));
                                newRowTerm["total_amount"] = String.Empty;

                                termPaymentTable.Rows.Add(newRowTerm);
                            }

                            if (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0")) > 0)
                            {
                                DataRow newRowDis = termPaymentTable.NewRow();

                                newRowDis["description"] = "   Cash Discount - " + paymentDiscountReimbursementDate;
                                newRowDis["text_balance"] = String.Empty;
                                newRowDis["amount"] =
                                    this.GetStringAmount(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0")));
                                newRowDis["total_amount"] = String.Empty;

                                termPaymentTable.Rows.Add(newRowDis);
                            }
                        }
                    }
                }
            }

            return termPaymentTable;
        }//----------------------

        //this procedure get the student, enrolment level system id list format
        private String GetStudentEnrolmentLevelSystemIdFormat(DataTable studentTable, Boolean isStudent)
        {
            StringBuilder strValue = new StringBuilder();

            if (studentTable != null)
            {
                foreach (DataRow studRow in studentTable.Rows)
                {
                    if (isStudent)
                    {
                        if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "")))
                        {
                            strValue.Append(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "") + ", ");
                        }
                    }
                    else 
                    {
                        if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "")))
                        {
                            strValue.Append(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", "") + ", ");
                        }
                    }                  
                }
            }

            if (strValue.Length >= 2)
            {
                return strValue.ToString().Substring(0, strValue.Length - 2);
            }
            else
            {
                return String.Empty;
            }
        }//------------------------------

        //this function will get year leve id by enrolment leve system id
        private String GetYearLevelId(DataTable studentTable, String studentSysId, Boolean isCourse)
        {
            String courseYearLevelId = String.Empty;

            String strFilter = "sysid_student = '" + studentSysId + "'";
            DataRow[] selectRow = studentTable.Select(strFilter);

            foreach (DataRow studRow in selectRow)
            {
                if (!isCourse)
                {
                    courseYearLevelId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_id", String.Empty);
                }
                else
                {
                    courseYearLevelId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_id", String.Empty);
                }

                break;
            }

            return courseYearLevelId;
        }//-------------------------

        //this fucntion will get total amount of each school fee particular 
        private Decimal GetTotalAmountSchoolFeeParticular(DataTable schoolFeeDetailsTable, String feeParticularSysId, String yearLevelId, Boolean isSemestral)
        {
            Decimal amount = 0;

            String strFilter = "sysid_feeparticular = '" + feeParticularSysId + "' AND year_level_id = '" + yearLevelId + "'";
            DataRow[] selectRow = schoolFeeDetailsTable.Select(strFilter);

            foreach (DataRow feeRow in selectRow)
            {
                if (RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "category_no", Byte.Parse("0")) == (Byte)CommonExchange.SchoolFeeCategoryNo.TuitionFee)
                {
                    if (isSemestral && RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_per_unit_tuition_fee", false))
                    {
                        amount += RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "amount", Decimal.Parse("0"));
                    }
                    else if (!isSemestral && RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_per_year_tuition_fee", false))
                    {
                        amount += RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "amount", Decimal.Parse("0"));
                    }
                    else if (isSemestral && (RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_fixed_amount_tuition_fee", false) ||
                        RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_special_class_tuition_fee", false)))
                    {
                        amount += RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "amount", Decimal.Parse("0"));
                    }
                }
                else
                {
                    amount += RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "amount", Decimal.Parse("0"));
                }
            }

            return amount;
        }//--------------------

        //this function will get fee particular description
        private String GetFeeParticularDescription(String feeParticularSysId)
        {
            String particularDescription = String.Empty;

            String strFilter = "sysid_feeparticular = '" + feeParticularSysId + "'";
            DataRow[] selectRow = _classDataSet.Tables["SchoolFeeParticularTable"].Select(strFilter);

            foreach (DataRow feeRow in selectRow)
            {
                particularDescription = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "particular_description", String.Empty);
            }

            return particularDescription;
        }//-------------------------

         //this fucntion will get student fee particulat amount by student id and particular system id
        private Decimal GetStudentFeePraticularAmount(DataTable studentFeeDetailsTable, String studentSysId, String feeParticularSysId, Boolean isSemestral)
        {
            Decimal amount = 0;

            String strFilter = "sysid_feeparticular = '" + feeParticularSysId + "' AND sysid_student = '" + studentSysId + "'";
            DataRow[] selectRow = studentFeeDetailsTable.Select(strFilter);

            foreach (DataRow feeRow in selectRow)
            {
                if (RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "category_no", Byte.Parse("0")) == (Byte)CommonExchange.SchoolFeeCategoryNo.TuitionFee)
                {
                    if (isSemestral && RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_per_unit_tuition_fee", false))
                    {
                        amount += RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "amount", Decimal.Parse("0"));

                        //if (amount > 0)
                        //{
                        //    break;
                        //}
                    }
                    else if (isSemestral && (RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_fixed_amount_tuition_fee", false) ||
                        RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_special_class_tuition_fee", false)))
                    {
                        amount += RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "amount", Decimal.Parse("0"));

                        //if (amount > 0)
                        //{
                        //    break;
                        //}
                    }
                    else if (!isSemestral && RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_per_year_tuition_fee", false))
                    {
                        amount += RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "amount", Decimal.Parse("0"));

                        //if (amount > 0)
                        //{
                        //    break;
                        //}
                    }
                }
                else
                {
                    amount += RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "amount", Decimal.Parse("0"));

                    //if (amount > 0)
                    //{
                    //    break;
                    //}
                }
            }

            return amount;
        }//--------------------------

        //this function will get student complete namb (for fee register details report)
        private String GetStudentCompleteNameID(DataTable studentTable, String studentSysId, Boolean isName)
        {
            String value = String.Empty;

            String strFilter = "sysid_student = '" + studentSysId + "'";
            DataRow[] selectRow = studentTable.Select(strFilter);

            foreach (DataRow feeRow in selectRow)
            {
                if (isName)
                {
                    value = RemoteClient.ProcStatic.GetCompleteNameFullMiddleName(feeRow, "last_name", "first_name", "middle_name");
                }
                else
                {
                    value = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "student_id", String.Empty);
                }
            }

            return value;
        }//------------------

        //this function gets the whole number and return the decimal number
        public long GetWholeNumberTenthDecimal(Decimal numInput, Boolean isWholeNumber)
        {
            String[] strInput = numInput.ToString().Split('.');

            return isWholeNumber ? long.Parse(strInput[0]) : long.Parse(strInput[1]);
        }//-------------------------    

        //this function will get receipt description
        private String GetReceiptPaymentDescription(Decimal paymentAmount, Int64 paymentId)
        {
            String strDescription = String.Empty;

            if (_schoolFeeDetailsTableCurrentCharge != null && _paymentReimbursementTable != null)
            {
                DataTable tempPaymentTable = _paymentReimbursementTable.Clone();

                foreach (DataRow payDiscountRem in _paymentReimbursementTable.Rows)
                {
                    DataRow newRow = tempPaymentTable.NewRow();

                    newRow["payment_discount_reimbursement_id"] =
                        RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "payment_discount_reimbursement_id", Int64.Parse("0"));
                    newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "sysid_student", String.Empty);
                    newRow["received_date"] =
                        RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "received_date", String.Empty);
                    newRow["receipt_no"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "receipt_no", String.Empty);
                    newRow["remarks_discount_reimbursement_description"] =
                        RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "remarks_discount_reimbursement_description", String.Empty);
                    newRow["is_downpayment"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_downpayment", false);
                    newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "amount", Decimal.Parse("0"));
                    newRow["discount_amount"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "discount_amount", Decimal.Parse("0"));
                    newRow["is_payment"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_payment", false);
                    newRow["is_discount"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_discount", false);
                    newRow["is_reimbursement"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_reimbursement", false);
                    newRow["is_balance_forwarded"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_balance_forwarded", false);
                    newRow["is_credit_memo"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_credit_memo", false);
                    newRow["is_included_in_post"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_included_in_post", false);

                    tempPaymentTable.Rows.Add(newRow);
                }

                Decimal balanceForwarded = 0;
                Decimal totalPayment = 0;
                Decimal totalReimbursements = 0;

                foreach (DataRow paymentRow in tempPaymentTable.Rows)
                {
                    if (paymentRow.RowState != DataRowState.Deleted &&
                            (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) > 0 &&
                            ((RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_payment", false) ||                            
                            RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_discount", false) ||
                            RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_credit_memo", false)) &&
                            RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_included_in_post", false))))
                    {
                        totalPayment += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) +
                            RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0"));
                    }
                    else if (paymentRow.RowState != DataRowState.Deleted && RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_reimbursement", false))
                    {
                        totalReimbursements += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) +
                            RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0"));
                    }
                }

                if (_balanceForwardedTable != null && _balanceForwardedTable.Rows.Count > 0)
                {
                    DataRow balRow = _balanceForwardedTable.Rows[0];

                    balanceForwarded = RemoteServerLib.ProcStatic.DataRowConvert(balRow, "amount", Decimal.Parse("0"));

                    Int32 index = 0;

                    foreach (DataRow paymentRow in tempPaymentTable.Rows)
                    {   
                        if (balanceForwarded > 0)
                        {
                            Decimal tempAmount = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));

                            if (tempAmount >= balanceForwarded)
                            {
                                tempAmount -= balanceForwarded;

                                if (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "payment_discount_reimbursement_id", Int64.Parse("0")) == paymentId)
                                {
                                    strDescription += "Back Accounts".PadRight(20) + balanceForwarded.ToString("N").PadLeft(20) + "\n";
                                }

                                balanceForwarded = 0;
                            }
                            else 
                            {
                                if (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "payment_discount_reimbursement_id", Int64.Parse("0")) == paymentId)
                                {
                                    strDescription += "Back Accounts".PadRight(20) + tempAmount.ToString("N").PadLeft(20) + "\n";
                                    paymentAmount -= tempAmount;
                                }

                                balanceForwarded -= tempAmount;
                                tempAmount = 0;
                            }

                            DataRow editRow = tempPaymentTable.Rows[index];

                            editRow.BeginEdit();

                            editRow["amount"] = tempAmount;

                            editRow.EndEdit();
                        }
                        
                        index++;
                    }
                }

                if (paymentAmount > 0)
                {
                    foreach (DataRow categoryRow in _classDataSet.Tables["SchoolFeeCategoryTable"].Rows)
                    {
                        String strFilter = "fee_category_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(categoryRow, "fee_category_id", "") + "'";
                        DataRow[] selectRow;

                        selectRow = _schoolFeeDetailsTableCurrentCharge.Select(strFilter);

                        Decimal subTotal = 0;
                        foreach (DataRow detailsRow in selectRow)
                        {
                            if (detailsRow.RowState != DataRowState.Deleted &&
                                ((CommonExchange.SchoolFeeCategoryId.TuitionFee == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "") &&
                                (RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_per_year_tuition_fee", false) ||
                                RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_per_unit_tuition_fee", false) ||
                                RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_fixed_amount_tuition_fee", false) ||
                                RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_special_class_tuition_fee", false))) ||
                                CommonExchange.SchoolFeeCategoryId.MiscellaneousFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "") ||
                                CommonExchange.SchoolFeeCategoryId.OtherFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "") ||
                                CommonExchange.SchoolFeeCategoryId.LaboratoryFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "")))
                            {
                                if (RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0")) > 0)
                                {
                                    subTotal += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                                    subTotal += totalReimbursements;
                                    totalReimbursements = 0;
                                }
                            }
                        }

                        Int32 paymentIndex = 0;
                        foreach (DataRow paymentRow in tempPaymentTable.Rows)
                        {
                            if (paymentRow.RowState != DataRowState.Deleted &&
                                (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) > 0 &&
                                ((RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_payment", false) ||
                                RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_discount", false) ||
                                RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_credit_memo", false)) &&
                                RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_included_in_post", false))))
                            {
                                if (subTotal > 0)
                                {
                                    Decimal addedAmount = 0;
                                    Decimal deductedAmount = 0;

                                    if (subTotal >= RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")))
                                    {
                                        subTotal -= RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));

                                        addedAmount = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));

                                        deductedAmount = 0;
                                    }
                                    else
                                    {
                                        addedAmount = subTotal;

                                        deductedAmount = (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"))) - subTotal;

                                        subTotal = 0;
                                    }

                                    if (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "payment_discount_reimbursement_id", Int64.Parse("0")) == paymentId)
                                    {
                                        strDescription += RemoteServerLib.ProcStatic.DataRowConvert(categoryRow, "category_description", "").PadRight(20) +
                                            addedAmount.ToString("N").PadLeft(20) + "\n";
                                    }

                                    DataRow editRow = tempPaymentTable.Rows[paymentIndex];

                                    editRow.BeginEdit();

                                    editRow["amount"] = deductedAmount;

                                    editRow.EndEdit();
                                }
                            }

                            paymentIndex++;
                        }
                    }
                }
            }
            else
            {
                strDescription += "Tuition Fee".PadRight(20) +  paymentAmount.ToString("N").PadLeft(20) + "\n";
            }
         
            return String.IsNullOrEmpty(strDescription) ? strDescription += "Tuition Fee".PadRight(20) +  paymentAmount.ToString("N").PadLeft(20) + "\n" : 
                strDescription;            
        }//-------------------------

        //this function will get latest payment id
        public Int64 GetLatestPaymentId()
        {
            Int64 paymentId = 0;

            if (_paymentReimbursementTable != null)
            {
                foreach (DataRow paymentRow in _paymentReimbursementTable.Rows)
                {
                    if (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "payment_discount_reimbursement_id", Int64.Parse("0")) > paymentId)
                    {
                        paymentId = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "payment_discount_reimbursement_id", Int64.Parse("0"));
                    }
                }
            }

            return paymentId;
        }//--------------------

        //this function will get student running balance
        public String GetStudentRunningBalance(CommonExchange.SysAccess userInfo, String studentSysId)
        {
            DataTable balanceTable;

            using (RemoteClient.RemCntStudentLoadingManager remClient = new RemoteClient.RemCntStudentLoadingManager())
            {
                balanceTable = remClient.SelectBySysIDStudentListForStudentRunningBalanceStudentLoad(userInfo, studentSysId);
            }

            DataRow balRow = balanceTable.Rows[0];

            return String.Format("{0:#,##0.00;(#,##0.00)}", RemoteServerLib.ProcStatic.DataRowConvert(balRow, "amount", Decimal.Parse("0")));
        }//-------------------------
        #endregion
    }
}
