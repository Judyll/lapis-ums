using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class StudentTab : IDisposable
    {
        #region Class Struct Declaration
        struct ClassHotKeys
        {
            private Int16 _f4Key;
            public Int16 F4Key
            {
                get { return _f4Key; }
                set { _f4Key = value; }
            }

            private Int16 _f5Key;
            public Int16 F5Key
            {
                get { return _f5Key; }
                set { _f5Key = value; }
            }

            private Int16 _f6Key;
            public Int16 F6Key
            {
                get { return _f6Key; }
                set { _f6Key = value; }
            }

            private Int16 _f7Key;
            public Int16 F7Key
            {
                get { return _f7Key; }
                set { _f7Key = value; }
            }

            private Int16 _f8Key;
            public Int16 F8Key
            {
                get { return _f8Key; }
                set { _f8Key = value; }
            }

            private Int16 _f9Key;
            public Int16 F9Key
            {
                get { return _f9Key; }
                set { _f9Key = value; }
            }

            private Int16 _f10Key;
            public Int16 F10Key
            {
                get { return _f10Key; }
                set { _f10Key = value; }
            }

            private Int16 _f11Key;
            public Int16 F11Key
            {
                get { return _f11Key; }
                set { _f11Key = value; }
            }
        }
        #endregion
               
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private CommonExchange.Student _studentInfo;
        private CommonExchange.StudentPayments _studentPaymentInfo;
        private CommonExchange.StudentReimbursements _studentReimbursementInfo;
        private CommonExchange.StudentAdditionalFee _studentAdditionalFeeInfo;
        private CommonExchange.StudentDiscounts _studentDiscountInfo;
        private CommonExchange.StudentEnrolmentLevel _studentEnrolmentLevelInfo;
        private CommonExchange.StudentBalanceForwarded _studentBalanceForwardedInfo;
        private CommonExchange.StudentPromissoryNote _studentPromissoryNoteInfo;
        private CommonExchange.StudentCreditMemo _studentCreditMemo;
        private CommonExchange.StudentScholarship _studentScholarshipInfo;
        private CashieringLogic _cashieringManager;

        private String _strEnrolmentCourseSysId = String.Empty;
        private String _sysIdFeeDetails = String.Empty;
        private String _dateStart = String.Empty;
        private String _dateEnd = String.Empty;
        private String _receiptDate = String.Empty;
        private String _oldSemesterId = String.Empty;
        private String _oldYearId = String.Empty;
        private String _courseTitle;
        private String _sysIdSubjectSchedule;
        private String _sysIdSpecialClass;
        private String _studentPaymentId;
        private String _strForReceiptDescription = String.Empty;
        
        private ClassHotKeys _tabStruct;

        private Int64 _optionalFeeId = 0;
        private Int32 _oldIndexChargesTab = 0;
        private Int32 _oldIndexPayment = 0;
        private Int32 _oldIndexCourseCombo = 0 - 1;
        private Int32 _oldIndexYearLevelCombo = -1;
        private Int32 _oldIndexYearCombo = -1;
        private Int32 _oldIndexSemeberCombo = -1;

        private Boolean _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = false;
        private Boolean _hasUpdatedDiscount = false;
        private Boolean _hasUpdatedAdditionalFee = false;
        private Boolean _hasUpdatedOptionalFee = false;
        private Boolean _askConfirmationCharges = true;
        private Boolean _askConfirmationPayment = true;
        private Boolean _isPaymentReimbursementCreditMemoRecordOpen = false;
        private Boolean _isReimbursementRecordOpen = false;
        private Boolean _isAdditionalFeeRecordOpen = false;
        private Boolean _isDiscountRecordOpen = false;
        private Boolean _isWithdrawnSubjectSpecialClassOpen = false;
        private Boolean _hasSelectedNoInYearLevelConfermation = false;
        private Boolean _hasSelectedNoYearSemsterConfermation = false;
        private Boolean _hasSelectedNoCourseConfermation = false;

        private ErrorProvider _errProvider;
        private ToolTip ttpTool;
        #endregion

        #region Class Constructors
        public StudentTab(CommonExchange.SysAccess userInfo, CommonExchange.Student studentInfo, CashieringLogic cashieringManager, String receiptDate)
        {            
            this.InitializeComponent();

            _userInfo = userInfo;
            _studentInfo = studentInfo;
            _cashieringManager = cashieringManager;

            _receiptDate = receiptDate;

            _tabStruct = new ClassHotKeys();
            
            this.Load += new EventHandler(ClassLoad);
            this.FormClosing += new FormClosingEventHandler(ClassClossing);
            this.KeyUp += new KeyEventHandler(StudentTabKeyUp);
            this.cboYear.SelectedIndexChanged += new EventHandler(cboYearSelectedIndexChanged);
            this.cboSemester.SelectedIndexChanged += new EventHandler(cboSemesterSelectedIndexChanged);
            this.cboCourse.SelectedIndexChanged += new EventHandler(cboCourseSelectedIndexChanged);
            this.cboYearLevel.SelectedIndexChanged += new EventHandler(cboYearLevelSelectedIndexChanged);
            this.tblTransanctions.SelectedIndexChanged += new EventHandler(tblTransanctionsSelectedIndexChanged);
            this.tblCharges.SelectedIndexChanged += new EventHandler(tblChargesSelectedIndexChanged);
            this.txtPaymentAmount.KeyPress += new KeyPressEventHandler(txtPaymentAmountKeyPress);
            this.txtPaymentAmount.Validating += new System.ComponentModel.CancelEventHandler(txtAmountValidating);
            this.txtPaymentAmount.Validated += new EventHandler(txtPaymentAmountValidated);
            this.txtPaymentAmount.KeyUp += new KeyEventHandler(txtPaymentAmountKeyUp);
            this.txtDiscountedAmount.KeyPress += new KeyPressEventHandler(txtDiscountedAmountKeyPress);
            this.txtDiscountedAmount.Validating += new System.ComponentModel.CancelEventHandler(txtAmountValidating);
            this.txtDiscountedAmount.Validated += new EventHandler(txtDiscountedAmountValidated);
            this.txtAmountTendered.Validating += new System.ComponentModel.CancelEventHandler(txtAmountValidating);
            this.txtAmountTendered.KeyPress += new KeyPressEventHandler(txtAmountTenderedKeyPress);
            this.txtAmountTendered.Validated += new EventHandler(txtAmountTenderedValidated);
            this.txtAmountTendered.KeyUp += new KeyEventHandler(txtAmountTenderedKeyUp);
            this.txtBank.KeyPress += new KeyPressEventHandler(txtBankKeyPress);
            this.txtBank.Validated += new EventHandler(txtBankValidated);
            this.txtCheckNo.Validated += new EventHandler(txtCheckNoValidated);
            this.txtReceipNo.KeyPress += new KeyPressEventHandler(txtReceipNoKeyPress);
            this.txtReceipNo.Validated += new EventHandler(txtReceipNoValidated);
            this.txtPaymentRemarks.KeyPress += new KeyPressEventHandler(txtPaymentRemarksKeyPress);
            this.txtPaymentRemarks.Validated += new EventHandler(txtPaymentRemarksValidated);
            this.txtReimbursementAmount.KeyPress += new KeyPressEventHandler(txtReimbursementAmountKeyPress);
            this.txtReimbursementAmount.Validating += new System.ComponentModel.CancelEventHandler(txtAmountValidating);
            this.txtReimbursementAmount.Validated += new EventHandler(txtReimbursementAmountValidated);
            this.txtReimbursementRemarks.KeyPress += new KeyPressEventHandler(txtReimbursementRemarksKeyPress);
            this.txtReimbursementRemarks.Validated += new EventHandler(txtReimbursementRemarksValidated);
            this.txtCreditMemoAmount.KeyPress += new KeyPressEventHandler(txtCreditMemoAmountKeyPress);
            this.txtCreditMemoAmount.Validating += new System.ComponentModel.CancelEventHandler(txtAmountValidating);            
            this.txtCreditMemoAmount.Validated += new EventHandler(txtCreditMemoAmountValidated);
            this.txtCreditMemoRemarks.Validated += new EventHandler(txtCreditMemoRemarksValidated);
            this.txtCreditMemoRemarks.KeyPress += new KeyPressEventHandler(txtCreditMemoRemarksKeyPress);
            this.txtAdditionalPaymentAmount.KeyPress += new KeyPressEventHandler(txtAdditionalPaymentAmountKeyPress);
            this.txtAdditionalPaymentAmount.Validating += new System.ComponentModel.CancelEventHandler(txtAmountValidating);
            this.txtAdditionalPaymentAmount.Validated += new EventHandler(txtAdditionalPaymentAmountValidated);
            this.txtAdditionalFeeRemarks.KeyPress += new KeyPressEventHandler(txtAdditionalFeeRemarksKeyPress);
            this.txtAdditionalFeeRemarks.Validated += new EventHandler(txtAdditionalFeeRemarksValidated);
            this.txtDiscountAmount.KeyPress += new KeyPressEventHandler(txtDiscountAmountKeyPress);
            this.txtDiscountAmount.Validating += new System.ComponentModel.CancelEventHandler(txtAmountValidating);
            this.txtDiscountAmount.Validated += new EventHandler(txtDiscountAmountValidated);
            this.txtBalanceForwardedAmount.KeyPress += new KeyPressEventHandler(txtBalanceForwardedAmountKeyPress);
            this.txtBalanceForwardedAmount.Validating += new System.ComponentModel.CancelEventHandler(txtAmountValidating);
            this.txtBalanceForwardedAmount.Validated += new EventHandler(txtBalanceForwardedAmountValidated);
            this.txtDiscountRemarks.KeyPress += new KeyPressEventHandler(txtDiscountRemarksKeyPress);
            this.txtDiscountRemarks.Validated += new EventHandler(txtDiscountRemarksValidated);
            this.chkIsDownPaymentPayment.CheckedChanged += new EventHandler(chkIsDownPaymentCheckedChanged);
            this.chkIsDownPaymentReimbursements.CheckedChanged += new EventHandler(chkIsDownPaymentReimbursementsCheckedChanged);
            this.chkIsDownpaymentCreditMemo.CheckedChanged += new EventHandler(chkIsDownpaymentCreditMemoCheckedChanged);
            this.chkIsDownPaymentPromissoryNote.CheckedChanged += new EventHandler(chkIsDownPaymentPromissoryNoteCheckedChanged);
            this.chkIsDownpaymentDiscount.CheckedChanged += new EventHandler(chkIsDownpaymentDiscountCheckedChanged);
            this.chkIsMiscellaneousIncome.CheckedChanged += new EventHandler(chkIsMiscellaneousIncomeCheckedChanged);
            this.lsvPaymentHistory.MouseDoubleClick += new MouseEventHandler(lsvPaymentHistoryMouseDoubleClick);
            this.lsvPaymentHistory.MouseDown += new MouseEventHandler(lsvPaymentHistoryMouseDown);
            this.lsvReimbursementHistory.MouseDoubleClick += new MouseEventHandler(lsvReimbursementHistoryMouseDoubleClick);
            this.lsvCreditMemo.MouseDoubleClick += new MouseEventHandler(lsvCreditMemoMouseDoubleClick);
            this.lsvPromissoryNote.MouseDoubleClick += new MouseEventHandler(lsvPromissoryNoteMouseDoubleClick);
            this.lsvAdditionalPayment.MouseDoubleClick += new MouseEventHandler(lsvAdditionalPaymentMouseDoubleClick);
            this.lsvDiscount.MouseDoubleClick += new MouseEventHandler(lsvDiscountMouseDoubleClick);
            this.lsvWithdrawnSubjects.MouseDown += new MouseEventHandler(lsvWithdrawnSubjectsMouseDown);
            this.lsvWithdrawnSpecialClass.MouseDown += new MouseEventHandler(lsvWithdrawnSpecialClassMouseDown);
            this.lsvCurrentCharges.MouseDown += new MouseEventHandler(lsvCurrentChargesMouseDown);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnSearchAdditionalFee.Click += new EventHandler(btnSearchAdditionalFeeClick);
            this.btnSearchDiscount.Click += new EventHandler(btnSearchDiscountClick);
            this.btnSearchedAccountTitle.Click += new EventHandler(btnSearchedAccountTitleClick);
            this.btnPayment.Click += new EventHandler(btnPaymentClick);
            this.btnUpdatePayment.Click += new EventHandler(btnUpdatePaymentClick);
            this.btnDeletePayment.Click += new EventHandler(btnDeletePaymentClick);
            this.btnUpdateReimbursment.Click += new EventHandler(btnUpdateReimbursmentClick);
            this.btnRecordReimbursement.Click += new EventHandler(btnRecordReimbursementClick);
            this.btnDeleteReimbursement.Click += new EventHandler(btnDeleteReimbursementClick);
            this.btnUpdateCreditMemo.Click += new EventHandler(btnUpdateCreditMemoClick);
            this.btnDeleteCreditMemo.Click += new EventHandler(btnDeleteCreditMemoClick);
            this.btnRecordCreditMemo.Click += new EventHandler(btnRecordCreditMemoClick);
            this.btnAdditionalPayment.Click += new EventHandler(btnAdditionalPaymentClick);
            this.btnDeleteDiscount.Click += new EventHandler(btnDeleteDiscountClick);
            this.btnUpdateDiscount.Click += new EventHandler(btnUpdateDiscountClick);
            this.btnRecordDiscount.Click += new EventHandler(btnRecordDiscountClick);
            this.btnDeleteAdditionalPayment.Click += new EventHandler(btnDeleteAdditionalPaymentClick);
            this.btnUpdateAdditionalPayment.Click += new EventHandler(btnUpdateAdditionalPaymentClick);
            this.btnRecordBalanceForwarded.Click += new EventHandler(btnRecordBalanceForwardedClick);
            this.btnDeleteBalanceForwarded.Click += new EventHandler(btnDeleteBalanceForwardedClick);
            this.btnMarkedEntryLevel.Click += new EventHandler(btnMarkedEntryLevelClick);
            this.pbxOptionalFee.Click += new EventHandler(pbxOptionalFeeClick);
            this.lnkDeleteOptionalFee.Click += new EventHandler(lnkDeleteOptionalFeeClick);
            this.btnRecordOptionalFee.Click += new EventHandler(btnRecordOptionalFeeClick);
            this.pbxEnrolmentLevel.Click += new EventHandler(pbxEnrolmentLevelClick);
            this.pbxLegend.Click += new EventHandler(pbxLegendClick);
            this.pbxWithdrawnLegend.Click += new EventHandler(pbxLegendClick);
            this.pbxPrintStatementOfAccount.Click += new EventHandler(pbxPrintStatementOfAccountClick);
            this.pbxPrintStatementOfAccountSummary.Click += new EventHandler(pbxPrintStatementOfAccountSummaryClick);
            this.lnkReceivedDate.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkReceivedDateLinkClicked);
            this.txtReferenceNo.Validated += new EventHandler(txtReferenceNoValidated);
            this.txtPromissoryNote.Validated += new EventHandler(txtPromissoryNoteValidated);
            this.btnDeletePromissoryNote.Click += new EventHandler(btnDeletePromissoryNoteClick);
            this.btnUpdatePromissoryNote.Click += new EventHandler(btnUpdatePromissoryNoteClick);
            this.btnRecordPromissoryNote.Click += new EventHandler(btnRecordPromissoryNoteClick);
            this.lblPaymentReflectedDate.Click += new EventHandler(lblPaymentReflectedDateClick);
            this.lblReceiptDate.Click += new EventHandler(lblReceiptDateClick);
            this.lblReimbursmentReflectedDate.Click += new EventHandler(lblReimbursmentReflectedDateClick);
            this.lblCreditMemoReflectedDate.Click += new EventHandler(lblCreditMemoReflectedDateClick);
            this.lblDiscountReflectedDate.Click += new EventHandler(lblDiscountReflectedDateClick);
            this.lnkWithdrawSubject.Click += new EventHandler(lnkWithdrawSubjectClick);
            this.lnkWithdrawSpecialClass.Click += new EventHandler(lnkWithdrawSpecialClassClick);
            this.lnkReIssue.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkReIssueLinkClicked);
            this.lnkRePrint.Click += new EventHandler(lnkRePrintClick);
        }

        void IDisposable.Dispose()
        {
            if (pbxStudent.Image != null)
            {
                pbxStudent.Image.Dispose();
                pbxStudent.Image = null;

                pbxStudent.Dispose();
                pbxStudent = null;
            }

            GC.SuppressFinalize(this);
            GC.Collect();
        }

        #endregion

        #region Class Event Void Procedures
        //###########################################CLASS StudentTab EVENTS#####################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            try
            {
                if (!(RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessVpOfFinance(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessCashier(_userInfo)))
                {
                    throw new Exception("You are not authorized to access this module.");
                }

                _studentPaymentInfo = new CommonExchange.StudentPayments();
                _studentAdditionalFeeInfo = new CommonExchange.StudentAdditionalFee();
                _studentDiscountInfo = new CommonExchange.StudentDiscounts();
                _studentEnrolmentLevelInfo = new CommonExchange.StudentEnrolmentLevel();
                _studentReimbursementInfo = new CommonExchange.StudentReimbursements();
                _studentBalanceForwardedInfo = new CommonExchange.StudentBalanceForwarded();
                _studentPromissoryNoteInfo = new CommonExchange.StudentPromissoryNote();
                _studentCreditMemo = new CommonExchange.StudentCreditMemo();

                _studentPaymentInfo.ReceivedDate = _studentReimbursementInfo.ReceivedDate = _studentDiscountInfo.ReceivedDate =
                    _studentCreditMemo.ReceivedDate  = _cashieringManager.ServerDateTime;

                _studentPaymentInfo.ReceiptDate = _receiptDate;

                this.lblReceiptDate.Text = DateTime.Parse(_studentPaymentInfo.ReceiptDate).ToLongDateString();

                this.txtReceipNo.Text = _studentPaymentInfo.ReceiptNo = RemoteClient.ProcStatic.SixDigitZero(CashieringLogic.ReceiptNumber).ToString();

                this.lblPaymentReceivedDate.Text = DateTime.Parse(_studentPaymentInfo.ReceivedDate).ToLongDateString();
                this.lblReimbursementsReceivedDate.Text = DateTime.Parse(_studentReimbursementInfo.ReceivedDate).ToLongDateString();
                this.lblCreditMemoReceivedDate.Text = DateTime.Parse(_studentCreditMemo.ReceivedDate).ToLongDateString();

                _studentPaymentInfo.AccountCreditInfo = CashieringLogic.ChartOfAccountInformation;// _cashieringManager.ChartOfAccountInformation;

                this.txtCreditEntry.Text = !String.IsNullOrEmpty(_studentPaymentInfo.AccountCreditInfo.AccountSysId) ?
                    _studentPaymentInfo.AccountCreditInfo.AccountCode + " - " + _studentPaymentInfo.AccountCreditInfo.AccountName : String.Empty;

                this.chkIsMiscellaneousIncome.Enabled = !String.IsNullOrEmpty(_studentPaymentInfo.AccountCreditInfo.AccountSysId) ? true : false;

                _studentPromissoryNoteInfo.StudentInfo =  _studentCreditMemo.StudentInfo = _studentInfo;

                _errProvider = new ErrorProvider();

                _cashieringManager.InitializeSchoolYearCombo(this.cboYear);

                _studentPaymentInfo.StudentInfo.StudentSysId = _studentReimbursementInfo.StudentInfo.StudentSysId =
                    _studentBalanceForwardedInfo.StudentInfo.StudentSysId = _studentInfo.StudentSysId;

                this.lblStdStudentId.Text = _studentInfo.StudentId;
                this.lblStdLastName.Text = _studentInfo.PersonInfo.LastName;
                this.lblStdFirstName.Text = _studentInfo.PersonInfo.FirstName;
                this.lblMiddleName.Text = _studentInfo.PersonInfo.MiddleName;
                this.lblScholarship.Text = _studentInfo.Scholarship;
                this.chkIsInternational.Checked = _studentInfo.IsInternational;
                this.chkNoDownpayment.Checked = _studentInfo.IsNoDownpaymentRequired;

                if (!String.IsNullOrEmpty(_studentInfo.PersonInfo.FilePath))
                {
                    this.pbxStudent.Image = Image.FromFile(_studentInfo.PersonInfo.FilePath);
                }

                this.txtPaymentAmount.Select();
                this.txtPaymentAmount.Focus();

                if (String.IsNullOrEmpty(_dateStart) && String.IsNullOrEmpty(_dateEnd))
                {
                    this.gbxPayment.Enabled = this.gbxReimbursement.Enabled = this.gbxBalanceForwarded.Enabled = this.cboYearLevel.Enabled = false;
                }

                ttpTool = new ToolTip();

                ttpTool.SetToolTip(this.pbxOptionalFee, "Add optional fee(s)");
                ttpTool.SetToolTip(this.pbxEnrolmentLevel, "Student enrolment level");
                ttpTool.SetToolTip(this.pbxPrintStatementOfAccount, "Print statement of account");

                _cashieringManager.SelectBySysIDStudentForEnrolmentHistoryEnrolmentCourseLevel(_userInfo, _studentInfo.StudentSysId);

                this.lblRunningBalance.Text = "Running Balance: " + _cashieringManager.GetStudentRunningBalance(_userInfo, _studentInfo.StudentSysId);
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error");
            }
        }//------------------------------    
    
        //event is raised when the class is closing
        private void ClassClossing(object sender, FormClosingEventArgs e)
        {
            if (_hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded || _hasUpdatedDiscount || _hasUpdatedAdditionalFee || _hasUpdatedOptionalFee)
            {
                String strMsg = "There has been changes made in the current student tab module. \nExiting will not save this changes." +
                              "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//---------------------------

        //event is raised when the key is up
        private void StudentTabKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                this.tblTransanctions.SelectedIndex = 0;
            }
            else if (e.KeyCode == Keys.F3)
            {
                this.tblTransanctions.SelectedIndex = 1;
            }
            else if (e.KeyCode == Keys.F4 && _tabStruct.F4Key != -1)
            {
                this.tblCharges.SelectedIndex = _tabStruct.F4Key;   
            }
            else if (e.KeyCode == Keys.F5 && _tabStruct.F5Key != -1)
            {
                this.tblCharges.SelectedIndex = _tabStruct.F5Key;        
            }
            else if (e.KeyCode == Keys.F6 && _tabStruct.F6Key != -1)
            {
                this.tblCharges.SelectedIndex = _tabStruct.F6Key;               
            }
            else if (e.KeyCode == Keys.F7 && _tabStruct.F7Key != -1)
            {
                this.tblCharges.SelectedIndex = _tabStruct.F7Key;
            }
            else if (e.KeyCode == Keys.F8 && _tabStruct.F8Key != -1)
            {
                this.tblCharges.SelectedIndex = _tabStruct.F8Key;
            }
            else if (e.KeyCode == Keys.F9 && _tabStruct.F9Key != -1)
            {
                this.tblCharges.SelectedIndex = _tabStruct.F9Key;
            }
            else if (e.KeyCode == Keys.F10 && _tabStruct.F10Key != -1)
            {
                this.tblCharges.SelectedIndex = _tabStruct.F10Key;
                this.tblCharges.Focus();
            }
            else if (e.KeyCode == Keys.F11 && _tabStruct.F11Key != -1)
            {
                this.tblCharges.SelectedIndex = _tabStruct.F11Key;
            }
        }//-------------------------    
        //###########################################END CLASS StudentTab EVENTS#####################################################

        //###########################################COMBOBOX cboYear EVENTS#####################################################
        //event is raised when selected index is changed
        private void cboYearSelectedIndexChanged(object sender, EventArgs e)
        {
            _cashieringManager.ClearAmountDueListTableForPrinting();

            this.pbxPrintStatementOfAccountSummary.Enabled = false;

            if (this.SetTabChargesSelectedTabChange(false, false, false, true, false, true, true))
            {
                this.tblTransanctions.Enabled = true;

                 _dateStart = _cashieringManager.GetSchoolYearDateStart(_cashieringManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)).ToShortDateString()
                    + " 12:00:00 AM";
                _dateEnd = _cashieringManager.GetSchoolYearDateEnd(_cashieringManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)).ToShortDateString()
                    + " 11:59:59 PM";
                
                _cashieringManager.SelectBySysIDStudentListDateStartEndStudentPromissoryNote(_userInfo, _studentInfo.StudentSysId, _dateStart, _dateEnd);
                _cashieringManager.SelectBySysIDStudentDateStartEndStudentEnrolmentCourse(_userInfo, _studentInfo.StudentSysId, _dateStart, _dateEnd);

                _cashieringManager.InitializeStudentPromissoryNoteListView(this.lsvPromissoryNote,
                    _studentPromissoryNoteInfo.StudentInfo.StudentSysId, this.tabPromissory);

                this.InitializeStudentPaymentDiscountReimbursementTable();

                _cashieringManager.ClearMajorExamTable();

                if (!String.Equals(_oldYearId, _cashieringManager.GetYearLevelId(this.cboYear.SelectedIndex)))
                {
                    this.InitializeStudentControls(true);

                    _oldYearId = _cashieringManager.GetYearLevelId(this.cboYear.SelectedIndex);

                    _cashieringManager.InitializeSemesterCombo(this.cboSemester, this.cboYear.SelectedIndex);

                    _oldSemesterId = String.Empty;

                    if (_cashieringManager.IsSemestral())
                    {
                        this.cboSemester.Enabled = true;
                    }
                    else
                    {
                        this.cboSemester.Enabled = false;                       
                    }

                    this.cboYearLevel.Items.Clear();

                    _studentPaymentInfo.ReceivedDate = _studentReimbursementInfo.ReceivedDate =
                        _studentCreditMemo.ReceivedDate = DateTime.Parse(_cashieringManager.ServerDateTime).ToLongDateString();

                    this.lblPaymentReceivedDate.Text = this.lblReimbursementsReceivedDate.Text =
                        this.lblCreditMemoReceivedDate.Text = DateTime.Parse(_cashieringManager.ServerDateTime).ToLongDateString();


                    DateTime dateStart = DateTime.MinValue;
                    DateTime dateEnd = DateTime.MinValue;

                    if (DateTime.TryParse(_dateStart, out dateStart) && DateTime.TryParse(_dateEnd, out dateEnd))
                    {
                        _studentPaymentInfo.ReflectedDate = _studentCreditMemo.ReflectedDate =
                            _studentReimbursementInfo.ReflectedDate = _studentDiscountInfo.ReflectedDate =
                            _cashieringManager.GetReflectedDate(dateStart, dateEnd).ToShortDateString() + " 12:00:00 AM";

                        this.lblPaymentReflectedDate.Text = this.lblReimbursmentReflectedDate.Text =
                            this.lblCreditMemoReflectedDate.Text = this.lblDiscountReflectedDate.Text =
                            _cashieringManager.GetReflectedDate(dateStart, dateEnd).ToLongDateString();
                    }

                    _cashieringManager.InitializedCourseCombo(this.cboCourse, String.Empty, false);                   
                }

                _studentPaymentInfo.PaymentId = 0;
                _studentPaymentInfo.Amount = 0;
                _studentPaymentInfo.AmountTendered = 0;
                _studentPaymentInfo.DiscountAmount = 0;
                _studentPaymentInfo.IsDownpayment = false;
                _studentPaymentInfo.IsMiscellaneousIncome = false;
                _studentPaymentInfo.ObjectState = System.Data.DataRowState.Unchanged;
                _studentPaymentInfo.Remarks = String.Empty;

                this.txtPaymentAmount.ReadOnly = this.txtReceipNo.ReadOnly = this.txtPaymentRemarks.ReadOnly =
                    this.txtDiscountedAmount.ReadOnly = false;

                this.btnUpdatePayment.Enabled = false;

                this.btnPayment.Enabled = true;
                this.btnUpdatePayment.Enabled = this.lnkReIssue.Enabled = false;

                this.lblPaymentReceivedDate.Text = _studentPaymentInfo.ReceivedDate = DateTime.Parse(_cashieringManager.ServerDateTime).ToLongDateString();

                _cashieringManager.InitializePaymentHistroyListView(this.lsvPaymentHistory, this.tabPaymentHistory);
                _cashieringManager.InitializeReimbursementHistoryListView(this.lsvReimbursementHistory, this.tabReimbursement);
                _cashieringManager.InitializeCrediMemoHistoryListView(this.lsvCreditMemo, this.tblCreaditMemo);

                if (_cashieringManager.IsExistsSysIDStudentStudentBalanceForwarded(_userInfo, _studentInfo.StudentSysId))
                {
                    this.InitializeStudentBalanceForwardedControls();
                }

                if (!_hasSelectedNoYearSemsterConfermation)
                {
                    this.IsRecordLocked();
                }
                else
                {
                    _hasSelectedNoYearSemsterConfermation = false;
                }
            }
            else
            {
                _oldIndexYearCombo = this.cboYear.SelectedIndex;

                _askConfirmationCharges = true;
            }

            this.IsRecordLocked(DateTime.Parse(_studentPaymentInfo.ReceiptDate), DateTime.Parse(_studentPaymentInfo.ReceivedDate));
        }//---------------------------
        //###########################################END COMBOBOX cboYear EVENTS#####################################################      

        //###########################################COMBOBOX cboSemester EVENTS#####################################################
        //event is raised when selected index is changed
        private void cboSemesterSelectedIndexChanged(object sender, EventArgs e)
        {
            _cashieringManager.ClearAmountDueListTableForPrinting();

            this.pbxPrintStatementOfAccountSummary.Enabled = false;

            if (this.SetTabChargesSelectedTabChange(false, false, false, false, true, true, true))
            {
                _dateStart = _cashieringManager.GetSemesterDateStart(_cashieringManager.GetSemesterSystemId(this.cboYear.SelectedIndex,
                    this.cboSemester.SelectedIndex)).ToLongDateString() + " 12:00:00 AM";
                _dateEnd = _cashieringManager.GetSemesterDateEnd(_cashieringManager.GetSemesterSystemId(this.cboYear.SelectedIndex,
                    this.cboSemester.SelectedIndex)).ToLongDateString() + " 11:59:59 PM";

                _cashieringManager.SelectBySysIDStudentDateStartEndStudentEnrolmentCourse(_userInfo, _studentInfo.StudentSysId, _dateStart, _dateEnd);

                this.InitializeStudentPaymentDiscountReimbursementTable();
                
                _cashieringManager.ClearMajorExamTable();

                if (String.IsNullOrEmpty(_oldSemesterId) ||
                    !String.Equals(_oldSemesterId, _cashieringManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex)))
                {
                    if (!String.IsNullOrEmpty(_oldSemesterId))
                        this.InitializeStudentControls(true);

                    _oldSemesterId = _cashieringManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex);
                                        
                    this.cboYearLevel.Items.Clear();

                    _cashieringManager.InitializedCourseCombo(this.cboCourse, 
                            _cashieringManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex), true);
                }

                _studentPaymentInfo.ReceivedDate = _studentReimbursementInfo.ReceivedDate = _studentDiscountInfo.ReceivedDate =
                    _studentCreditMemo.ReceivedDate = DateTime.Parse(_cashieringManager.ServerDateTime).ToLongDateString();

                this.lblPaymentReceivedDate.Text = this.lblReimbursementsReceivedDate.Text =
                    this.lblCreditMemoReceivedDate.Text = DateTime.Parse(_cashieringManager.ServerDateTime).ToLongDateString();

                DateTime dateStart = DateTime.MinValue; 
                DateTime dateEnd = DateTime.MinValue;

                if (DateTime.TryParse(_dateStart, out dateStart) && DateTime.TryParse(_dateEnd, out dateEnd))
                {
                    _studentPaymentInfo.ReflectedDate = _studentCreditMemo.ReflectedDate = 
                        _studentReimbursementInfo.ReflectedDate = _studentDiscountInfo.ReflectedDate =
                        _cashieringManager.GetReflectedDate(dateStart, dateEnd).ToShortDateString() + " 12:00:00 AM";

                    this.lblPaymentReflectedDate.Text = this.lblReimbursmentReflectedDate.Text = 
                        this.lblCreditMemoReflectedDate.Text = this.lblDiscountReflectedDate.Text =
                        _cashieringManager.GetReflectedDate(dateStart, dateEnd).ToLongDateString();
                }

                _studentPaymentInfo.PaymentId = 0;
                _studentPaymentInfo.Amount = 0;
                _studentPaymentInfo.AmountTendered = 0;
                _studentPaymentInfo.DiscountAmount = 0;
                _studentPaymentInfo.IsDownpayment = false;
                _studentPaymentInfo.IsMiscellaneousIncome = false;
                _studentPaymentInfo.ObjectState = System.Data.DataRowState.Unchanged;
                _studentPaymentInfo.Remarks = String.Empty;

                this.txtPaymentAmount.ReadOnly = this.txtReceipNo.ReadOnly = this.txtPaymentRemarks.ReadOnly =
                    this.txtDiscountedAmount.ReadOnly = false;

                this.btnUpdatePayment.Enabled = false;

                this.btnPayment.Enabled = true;
                this.btnUpdatePayment.Enabled = this.lnkReIssue.Enabled = false;

                this.lblPaymentReceivedDate.Text = _studentPaymentInfo.ReceivedDate = DateTime.Parse(_cashieringManager.ServerDateTime).ToLongDateString();

                _cashieringManager.InitializePaymentHistroyListView(this.lsvPaymentHistory, tabPaymentHistory);
                _cashieringManager.InitializeReimbursementHistoryListView(this.lsvReimbursementHistory, this.tabReimbursement);
                _cashieringManager.InitializeCrediMemoHistoryListView(this.lsvCreditMemo, this.tblCreaditMemo);

                this.tblCharges.SelectedIndex = _oldIndexChargesTab;
                this.tblTransanctions.SelectedIndex = _oldIndexPayment;

                if (!_hasSelectedNoYearSemsterConfermation)
                {
                    this.IsRecordLocked();
                }
                else
                {
                    _hasSelectedNoYearSemsterConfermation = false;
                }
            }
            else
            {
                _oldIndexSemeberCombo = this.cboSemester.SelectedIndex;

                _askConfirmationCharges = _askConfirmationPayment = true;
            }

            this.IsRecordLocked(DateTime.Parse(_studentPaymentInfo.ReceiptDate), DateTime.Parse(_studentPaymentInfo.ReceivedDate));
        }//-------------------------
        //###########################################END COMBOBOX cboSemester EVENTS#####################################################

        //###########################################COMBOBOX cboCourse EVENTS#####################################################
        //event is raised when selected index is changed
        private void cboCourseSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.SetTabChargesSelectedTabChange(false, true, false, false, false, false, false))
            {
                if (this.cboSemester.SelectedIndex <= -1)
                {                   
                    if (!_hasSelectedNoCourseConfermation)
                    {
                        this.InitializeStudentControls(false);

                        _strEnrolmentCourseSysId = _cashieringManager.GetEnrolmentCourseSysId(this.cboCourse.SelectedIndex, String.Empty, false, ref _courseTitle);

                        this.InitializeStudentEnrolmentLevelTable(String.Empty);

                        _cashieringManager.InitializedYearLevelCombo(this.cboYearLevel, String.Empty, false);
                    }
                    else
                    {
                        _hasSelectedNoCourseConfermation = false;
                    }
                }
                else
                {
                    if (!_hasSelectedNoCourseConfermation)
                    {
                        this.InitializeStudentControls(false);

                        _strEnrolmentCourseSysId = _cashieringManager.GetEnrolmentCourseSysId(this.cboCourse.SelectedIndex,
                             _cashieringManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex), true, ref _courseTitle);

                        this.InitializeStudentEnrolmentLevelTable(_cashieringManager.GetSemesterSystemId(this.cboYear.SelectedIndex, 
                            this.cboSemester.SelectedIndex));

                        _cashieringManager.InitializedYearLevelCombo(this.cboYearLevel,
                            _cashieringManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex), true);
                    }
                    else
                    {
                        _hasSelectedNoCourseConfermation = false;
                    }
                }
            }
            else
            {
                _oldIndexCourseCombo = this.cboCourse.SelectedIndex;

                _askConfirmationCharges = true;
            }
        }//------------------------------
        //###########################################END COMBOBOX cboCourse EVENTS#####################################################
        
        //###########################################COMBOBOX cboYearLevel EVENTS#####################################################
        //event is raised when selected index is changed
        private void cboYearLevelSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.SetTabChargesSelectedTabChange(false, false, true, false, false, false, false))
            {
                this.Cursor = Cursors.WaitCursor;

                _cashieringManager.ClearCachedData();

                this.InitializeStudentChargesTab();

                _strForReceiptDescription = String.Empty;
                this.lsvCurrentCharges.Items.Clear();
                this.lsvWithdrawCharges.Items.Clear();
                this.lsvSubjectLoad.Items.Clear();
                this.lsvWithdrawnSubjects.Items.Clear();
                this.lsvSpecialClass.Items.Clear();
                this.lsvWithdrawnSpecialClass.Items.Clear();
                this.lsvAdditionalPayment.Items.Clear();
                this.lsvDiscount.Items.Clear();

                this.tblCharges.Enabled = cboYearLevel.SelectedIndex != 0 ? true : false;

                _studentEnrolmentLevelInfo = _cashieringManager.GetStudentEnrolmentLevelInfo(this.cboYearLevel.SelectedIndex);

                if (!String.IsNullOrEmpty(_studentEnrolmentLevelInfo.EnrolmentLevelSysId))
                {
                    _studentAdditionalFeeInfo.StudentEnrolmentLevelInfo.EnrolmentLevelSysId = _studentEnrolmentLevelInfo.EnrolmentLevelSysId;

                    _studentEnrolmentLevelInfo.SemesterInfo.SemesterSysId = _cashieringManager.GetSemesterSystemId(this.cboYear.SelectedIndex, 
                        this.cboSemester.SelectedIndex);

                    Int32 tempTabIndex = _oldIndexChargesTab;

                    this.tblCharges.SelectedIndexChanged -= new EventHandler(tblChargesSelectedIndexChanged);

                    //Get Date Ending
                    DateTime dateEnding;

                    if (_cashieringManager.IsSemestral(_studentEnrolmentLevelInfo.EnrolmentLevelSysId))
                    {
                        dateEnding = _cashieringManager.GetSemesterDateStart(_cashieringManager.GetSemesterSystemId(this.cboYear.SelectedIndex,
                            this.cboSemester.SelectedIndex));
                    }
                    else
                    {
                        dateEnding = _cashieringManager.GetSchoolYearDateStart(_cashieringManager.GetSchoolYearYearId(this.cboYear.SelectedIndex));
                    }

                    _cashieringManager.SelectBySysIDStudentListDateEndingBalanceCarriedForwardStudentLoad(_userInfo, _studentInfo.StudentSysId,
                        _studentEnrolmentLevelInfo.EnrolmentLevelSysId, dateEnding.AddDays(-1).ToShortDateString() + " 11:59:59 PM");
                    //----------------------------

                    if (!_studentEnrolmentLevelInfo.IsMarkedDeleted)
                    {
                        this.tblCharges.TabPages.Remove(tabWithdrawCharges);

                        _tabStruct.F5Key = -1;
                        _tabStruct.F6Key = 1;
                        _tabStruct.F7Key = 2;
                        _tabStruct.F8Key = 3;
                        _tabStruct.F9Key = 4;
                        _tabStruct.F10Key = 5;
                        _tabStruct.F11Key = 6;
                    }
                    else
                    {
                        this.tblCharges.TabPages.Remove(tabWithdrawCharges);
                        this.tblCharges.TabPages.Remove(tabSubjectTaken);
                        this.tblCharges.TabPages.Remove(tabWithdrawnSubjects);
                        this.tblCharges.TabPages.Remove(tabAdditionalFee);
                        this.tblCharges.TabPages.Remove(tabDiscounts);
                        this.tblCharges.TabPages.Remove(tabSpecialClass);
                        this.tblCharges.TabPages.Remove(tabWithdrawnSpecialClass);

                        this.tblCharges.TabPages.Add(tabWithdrawCharges);
                        this.tblCharges.TabPages.Add(tabSubjectTaken);
                        this.tblCharges.TabPages.Add(tabWithdrawnSubjects);
                        this.tblCharges.TabPages.Add(tabAdditionalFee);
                        this.tblCharges.TabPages.Add(tabDiscounts);
                        this.tblCharges.TabPages.Add(tabSpecialClass);
                        this.tblCharges.TabPages.Add(tabWithdrawnSpecialClass);

                        _tabStruct.F5Key = 1;
                        _tabStruct.F6Key = 2;
                        _tabStruct.F7Key = 3;
                        _tabStruct.F8Key = 4;
                        _tabStruct.F9Key = 5;
                        _tabStruct.F10Key = 6;
                        _tabStruct.F11Key = 7;

                        _cashieringManager.SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoadCharges(_userInfo, _studentInfo.StudentSysId,
                            _studentEnrolmentLevelInfo.EnrolmentLevelSysId, _studentEnrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId,
                            _cashieringManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex),
                            _studentEnrolmentLevelInfo.IsGraduateStudent, _studentEnrolmentLevelInfo.IsInternational,
                             true, false, true, false);

                        _cashieringManager.InitializeStudentChargesListView(this.lsvWithdrawCharges, this.lblWithdrawCharges, _studentInfo.StudentSysId, false);

                        this.btnRecordOptionalFee.Enabled = this.pbxOptionalFee.Enabled = false;
                    }

                    this.tblCharges.SelectedIndex = tempTabIndex;

                    this.tblCharges.SelectedIndexChanged += new EventHandler(tblChargesSelectedIndexChanged);

                    _cashieringManager.SelectBySysIDEnrolmentLevelDateStartEndSubjectScheduleStudentLoad(_userInfo, _studentInfo.StudentSysId,
                        _studentEnrolmentLevelInfo.EnrolmentLevelSysId, _studentEnrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId,
                        _cashieringManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex),
                       _studentEnrolmentLevelInfo.IsGraduateStudent, _studentEnrolmentLevelInfo.IsInternational,
                       _cashieringManager.IsEnrolled(this.cboYearLevel.SelectedIndex), _dateStart, _dateEnd);

                    _cashieringManager.SelectBySysIDStudentListDateStartEndSpecialClassInformation(_userInfo, _studentInfo.StudentSysId, _dateStart, _dateEnd);

                    _cashieringManager.SelectBySysIDStudentFeeLevelSemesterForOptionalFeeDetailsStudentOptionalFee(_userInfo, _studentInfo.StudentSysId,
                        _studentEnrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId,
                        _cashieringManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex), _studentEnrolmentLevelInfo.
                        IsInternational);
                    
                    _cashieringManager.SelectMajorExamScheduleTable(_userInfo, _dateStart, _dateEnd, 
                        _studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.CourseInfo.CourseGroupInfo.CourseGroupId);

                    this.InitializeScholarshipTable();

                    if (!_hasSelectedNoInYearLevelConfermation)
                    {
                        this.InitializeSchoolFeeDetailsTable();
                    }
                    else
                    {
                        _hasSelectedNoInYearLevelConfermation = false;
                    }                    

                    _cashieringManager.InitializeStudentChargesListView(this.lsvCurrentCharges, this.lblMenuCurrentCharges, _studentInfo.StudentSysId, true);
                    _cashieringManager.InitializeSubjectLoadListView(this.lsvSubjectLoad, this.lblSubjectTaken, this.tabSubjectTaken);
                    _cashieringManager.InitializeWithdrawSubjectLoadListView(this.lsvWithdrawnSubjects, this.lblWithdrawSubjects, this.tabWithdrawnSubjects);
                    _cashieringManager.InitializeSpecialClassLoadedWithdrawnListView(this.lsvSpecialClass, this.lblSpeicalClass, this.tabSpecialClass, false);
                    _cashieringManager.InitializeSpecialClassLoadedWithdrawnListView(this.lsvWithdrawnSpecialClass, 
                        this.lblWithdrawnSpecialClass, this.tabWithdrawnSpecialClass, true);
                    _cashieringManager.InitializeAdditionalFeeListView(this.lsvAdditionalPayment, this.tabAdditionalFee);
                    _cashieringManager.InitializeStudentDiscountListView(this.lsvDiscount, this.tabDiscounts);
                    _cashieringManager.InitializeAmountDueList(this.lsvAmountDueList, 
                        _studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.CourseInfo.CourseId, DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd),
                        _cashieringManager.IsSchoolYearForSummer(_cashieringManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)));

                    if (this.lsvAmountDueList.Items.Count > 0)
                    {
                        this.pbxPrintStatementOfAccountSummary.Enabled = true;
                    }
                    else
                    {
                        this.pbxPrintStatementOfAccountSummary.Enabled = true;
                    }

                    this.chkIsGraduating.Checked = _studentEnrolmentLevelInfo.IsGraduateStudent;
                    this.chkIsInternational.Checked = _studentEnrolmentLevelInfo.IsInternational;

                    this.IsRecordLocked();

                    //AD update student enrolment level
                    this.btnMarkedEntryLevel.Text = _studentEnrolmentLevelInfo.IsEntryLevel ? "Unmarked as entry level" : "Marked as entry level";

                    _studentEnrolmentLevelInfo.IsEntryLevel = _studentEnrolmentLevelInfo.IsEntryLevel ? false : true;
                    //--------------------------
                }
                else
                {
                    this.InitializeStudentControls(false);

                    this.btnMarkedEntryLevel.Enabled = false;
                }

                this.Cursor = Cursors.Arrow;
            }
            else
            {
                _oldIndexYearLevelCombo = this.cboYearLevel.SelectedIndex;

                _askConfirmationCharges = true;
            }
        }//-----------------------
        //###########################################END COMBOBOX cboYearLevel EVENTS#####################################################

        //###########################################TABCONTROL tblTransactions EVENTS#####################################################
        //event is raised when tab index is changed
        private void tblTransanctionsSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.SetTabPaymentSelectedTabChange(true, false, false))
            {
                _oldIndexPayment = this.tblTransanctions.SelectedIndex;

                if (_askConfirmationPayment)
                {
                    if (this.tblTransanctions.SelectedIndex == 0)
                    {
                        _studentPaymentInfo.PaymentId = 0;

                        this.txtPaymentAmount.Clear();
                        this.txtPaymentAmount.Focus();
                        this.txtPaymentRemarks.Clear();
                        this.txtDiscountedAmount.Clear();
                        this.chkIsDownPaymentPayment.Checked = false;
                        this.chkIsMiscellaneousIncome.Checked = false;

                        this.txtReceipNo.Text = RemoteClient.ProcStatic.SixDigitZero(CashieringLogic.ReceiptNumber);
                        this.txtAmountTendered.Clear();
                        this.lblChange.Text = "-";

                        _studentPaymentInfo.PaymentId = 0;
                        _studentPaymentInfo.Amount = 0;
                        _studentPaymentInfo.AmountTendered = 0;
                        _studentPaymentInfo.DiscountAmount = 0;
                        _studentPaymentInfo.IsDownpayment = false;
                        _studentPaymentInfo.IsMiscellaneousIncome = false;
                        _studentPaymentInfo.ObjectState = System.Data.DataRowState.Unchanged;
                        _studentPaymentInfo.Remarks = String.Empty;

                        this.txtPaymentAmount.ReadOnly = this.txtReceipNo.ReadOnly = this.txtPaymentRemarks.ReadOnly =
                            this.txtDiscountedAmount.ReadOnly = false;

                        this.btnUpdatePayment.Enabled = false;

                        this.btnPayment.Enabled = true;
                        this.btnUpdatePayment.Enabled = this.lnkReIssue.Enabled = false;

                        DateTime dateStart = DateTime.MinValue;
                        DateTime dateEnd = DateTime.MinValue;

                        if (DateTime.TryParse(_dateStart, out dateStart) && DateTime.TryParse(_dateEnd, out dateEnd))
                        {
                            _studentPaymentInfo.ReflectedDate = _cashieringManager.GetReflectedDate(dateStart, dateEnd).ToShortDateString() + " 12:00:00 AM";

                            this.lblPaymentReflectedDate.Text = _cashieringManager.GetReflectedDate(dateStart, dateEnd).ToLongDateString();
                        }

                        this.lblPaymentReceivedDate.Text = _studentPaymentInfo.ReceivedDate = DateTime.Parse(_cashieringManager.ServerDateTime).ToLongDateString();

                        //Code History: Priviews code calls (_cashieringManager.GetReflectedDate(<parameters>)) to supply the reflected date.
                        //reflected date is delete because of the new record locking feature. (can backward payments more than 4 months)
                        this.IsRecordLocked(DateTime.Parse(_cashieringManager.ServerDateTime), true, false, false, false, false);

                        this.IsRecordLocked(DateTime.Parse(_studentPaymentInfo.ReceiptDate), DateTime.Parse(_studentPaymentInfo.ReceivedDate));
                    }
                    else if (this.tblTransanctions.SelectedIndex == 1)
                    {
                        _studentReimbursementInfo.ReimbursementId = 0;

                        this.btnRecordReimbursement.Enabled = true;
                        this.btnUpdateReimbursment.Enabled = false;

                        this.txtReimbursementAmount.Clear();
                        this.txtReimbursementRemarks.Clear();

                        _studentReimbursementInfo.Amount = 0;
                        _studentReimbursementInfo.Remarks = String.Empty;

                        this.txtReimbursementAmount.ReadOnly = this.txtReimbursementRemarks.ReadOnly = false;

                        DateTime dateStart = DateTime.MinValue;
                        DateTime dateEnd = DateTime.MinValue;

                        if (DateTime.TryParse(_dateStart, out dateStart) && DateTime.TryParse(_dateEnd, out dateEnd))
                        {
                            _studentReimbursementInfo.ReflectedDate = _cashieringManager.GetReflectedDate(dateStart, dateEnd).ToShortDateString() + " 12:00:00 AM";

                            this.lblReimbursmentReflectedDate.Text = _cashieringManager.GetReflectedDate(dateStart, dateEnd).ToLongDateString();
                        }

                        this.lblReimbursementsReceivedDate.Text = _studentReimbursementInfo.ReceivedDate =
                                 DateTime.Parse(_cashieringManager.ServerDateTime).ToLongDateString();

                        this.IsRecordLocked(DateTime.Parse(_cashieringManager.ServerDateTime), false, true, false, false, false);
                    }
                    else if (this.tblTransanctions.SelectedIndex == 2)
                    {
                        _studentPromissoryNoteInfo.PromissoryNoteId = 0;

                        this.InitializeStudentPromissoryNoteControls();

                        this.IsRecordLocked(DateTime.Parse(_cashieringManager.ServerDateTime), false, false, false, true, false);

                        _studentPromissoryNoteInfo.ReceivedDate = DateTime.Parse(_cashieringManager.ServerDateTime).ToLongDateString();
                    }
                    else if (tblTransanctions.SelectedIndex == 3)
                    {
                        this.InitializeStudentBalanceForwardedControls();
                    }
                    else if (this.tblTransanctions.SelectedIndex == 4)
                    {
                        _studentCreditMemo.MemoId = 0;

                        this.txtCreditMemoAmount.Clear();
                        this.txtCreditMemoRemarks.Clear();

                        this.btnRecordCreditMemo.Enabled = true;
                        this.btnUpdateCreditMemo.Enabled = false;

                        _studentCreditMemo.Amount = 0;
                        _studentCreditMemo.Remarks = String.Empty;

                        this.txtCreditMemoAmount.ReadOnly = this.txtCreditMemoRemarks.ReadOnly = false;

                        DateTime dateStart = DateTime.MinValue;
                        DateTime dateEnd = DateTime.MinValue;

                        if (DateTime.TryParse(_dateStart, out dateStart) && DateTime.TryParse(_dateEnd, out dateEnd))
                        {
                            _studentCreditMemo.ReflectedDate = _cashieringManager.GetReflectedDate(dateStart, dateEnd).ToShortDateString() + " 12:00:00 AM";

                            this.lblCreditMemoReflectedDate.Text = _cashieringManager.GetReflectedDate(dateStart, dateEnd).ToLongDateString();
                        }

                        this.lblCreditMemoReceivedDate.Text = _studentCreditMemo.ReceivedDate =
                                 DateTime.Parse(_cashieringManager.ServerDateTime).ToLongDateString();

                        this.IsRecordLocked(DateTime.Parse(_cashieringManager.ServerDateTime), false, false, true, false, false);
                    }
                }

                this.ClearErrors();

                _askConfirmationPayment = true;            
            }
        }//----------------------
        //###########################################END TABCONTROL tblTransactions EVENTS#####################################################

        //###########################################TABCONTROL tblCharges EVENTS#####################################################
        //event is raised when tab index is changed
        private void tblChargesSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.SetTabChargesSelectedTabChange(true, false, false, false, false, false, false))
            {
                _oldIndexChargesTab = this.tblCharges.SelectedIndex;

                this.tblCharges.Focus();

                _askConfirmationCharges = true;
            }
        }//-------------------
        //###########################################END TABCONTROL tblCharges EVENTS#####################################################
        
        //###########################################TEXTBOX txtAmount EVENTS#####################################################
        //event is raised when the control is validating
        private void txtAmountValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxValidateAmount((TextBox)sender);
        }//---------------------        
        //###########################################END TEXTBOX txtAmount EVENTS#####################################################

        //###########################################TEXTBOX txtPaymentAmount EVENTS#####################################################
        //event is raised when the key is pressed
        private void txtPaymentAmountKeyPress(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxAmountOnly(e);

            if (e.KeyChar == '\r')
            {
                this.txtDiscountedAmount.Focus();
            }
        }//-------------------

        //event is raised when the control is validated
        private void txtPaymentAmountValidated(object sender, EventArgs e)
        {
            Decimal amount;

            if (Decimal.TryParse(txtPaymentAmount.Text, out amount))
            {
                if (amount != 0 && _studentPaymentInfo.Amount != amount)
                {
                    _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = true;
                }

                _studentPaymentInfo.Amount = amount;                
            }
        }//------------------
       
        //event is raised when the key is up
        private void txtPaymentAmountKeyUp(object sender, KeyEventArgs e)
        {
            Decimal amountTendered = 0;
            Decimal paymentAmount = 0;

            if (Decimal.TryParse(this.txtAmountTendered.Text, out amountTendered)) { }

            if (Decimal.TryParse(this.txtPaymentAmount.Text, out paymentAmount)) { }

            this.lblChange.Text = String.Format("{0:#,##0.00;(#,##0.00)}", (amountTendered - paymentAmount));
        }//----------------------------------
        //###########################################END TEXTBOX txtPaymentAmount EVENTS#####################################################

        //###########################################TEXTBOX txtDiscountedAmount EVENTS#####################################################
        //event is raised when the key is pressed
        private void txtDiscountedAmountKeyPress(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxAmountOnly(e);

            if (e.KeyChar == '\r')
            {
                this.txtAmountTendered.Focus();
            }
        }//-------------------------

        //event is raised when the control is validated
        private void txtDiscountedAmountValidated(object sender, EventArgs e)
        {
            Decimal amount;

            if (Decimal.TryParse(this.txtDiscountedAmount.Text, out amount))
            {
                if (amount != 0 && _studentPaymentInfo.DiscountAmount != amount)
                {
                    _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = true;
                }

                _studentPaymentInfo.DiscountAmount = amount;
            }
        }//------------------
        //##########################################END TEXTBOX txtDiscountedAmount EVENTS#####################################################

        //###########################################TEXTBOX txtAmountTendered EVENTS#####################################################
        //event is raised whent the control is validated
        private void txtAmountTenderedValidated(object sender, EventArgs e)
        {
            Decimal amountTendered;

            if (Decimal.TryParse(this.txtAmountTendered.Text, out amountTendered))
            {
                if (amountTendered != 0 && _studentPaymentInfo.AmountTendered != amountTendered)
                {
                    _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = true;
                }

                _studentPaymentInfo.AmountTendered = amountTendered;
            }
        }//------------------

        //event is raised when the key is pressed
        private void txtAmountTenderedKeyPress(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxAmountOnly(e);

            if (e.KeyChar == '\r')
            {
                this.txtReceipNo.Focus();
            }
        }//----------------------

        //event is raised when the key is up
        private void txtAmountTenderedKeyUp(object sender, KeyEventArgs e)
        {
            Decimal amountTendered = 0;
            Decimal paymentAmount = 0;

            if (Decimal.TryParse(this.txtAmountTendered.Text, out amountTendered)){} 
            
            if (Decimal.TryParse(this.txtPaymentAmount.Text, out paymentAmount)) { }

            this.lblChange.Text = String.Format("{0:#,##0.00;(#,##0.00)}", (amountTendered - paymentAmount));
        }//---------------------------
        //###########################################END TEXTBOX txtAmountTendered EVENTS#####################################################

        //###########################################TEXTBOX txtBank EVENTS#####################################################
        //event is raised when the control is validated
        private void txtBankValidated(object sender, EventArgs e)
        {
            _studentPaymentInfo.Bank = RemoteClient.ProcStatic.TrimStartEndString(this.txtBank.Text);
        }//----------------

        //event is raised when the key is pressed
        private void txtBankKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.txtCheckNo.Focus();
            }
        }//-------------------
        //###########################################END TEXTBOX txtBank EVENTS#####################################################

        //###########################################TEXTBOX txtCheckNo EVENTS#####################################################
        //event is raised when the control is validated
        private void txtCheckNoValidated(object sender, EventArgs e)
        {
            _studentPaymentInfo.CheckNo = RemoteClient.ProcStatic.TrimStartEndString(this.txtCheckNo.Text);
        }//------------------------
        //###########################################END TEXTBOX txtCheckNo EVENTS#####################################################

        //###########################################TEXTBOX txtReimbursementAmount EVENTS#####################################################
        //event is raised when the key is pressed
        private void txtReimbursementAmountKeyPress(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxAmountOnly(e);

            if (e.KeyChar == '\r')
            {
                this.txtReimbursementRemarks.Focus();
            }
        }//--------------------

        //event is raised when the control is validated
        private void txtReimbursementAmountValidated(object sender, EventArgs e)
        {
            Decimal amount;

            if (Decimal.TryParse(txtReimbursementAmount.Text, out amount))
            {
                if (amount != 0 && _studentReimbursementInfo.Amount != amount)
                    _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = true;

                _studentReimbursementInfo.Amount = amount;
            }
        }//-----------------------
        //###########################################END TEXTBOX txtReimbursementAmount EVENTS#####################################################

        //###########################################TEXTBOX txtCreditMemo EVENTS#####################################################
        //event is raised when the control is validated
        private void txtCreditMemoAmountValidated(object sender, EventArgs e)
        {
            Decimal amount;

            if (Decimal.TryParse(this.txtCreditMemoAmount.Text, out amount))
            {
                if (amount != 0 && _studentCreditMemo.Amount != amount)
                    _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = true;

                _studentCreditMemo.Amount = amount;
            }
        }//---------------------

        //event is raised when the key is pressed
        private void txtCreditMemoAmountKeyPress(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxAmountOnly(e);

            if (e.KeyChar == '\r')
            {
                this.txtCreditMemoRemarks.Focus();
            }
        }//-------------------------
        //###########################################END TEXTBOX txtCreditMemo EVENTS#####################################################

        //###########################################TEXTBOX txtCreditMemoRemarks EVENTS#####################################################
        //event is raised when the key is pressed
        private void txtCreditMemoRemarksKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.btnRecordCreditMemo.Focus();
            }
        }//--------------------------

        //event is raised when the control is validated
        private void txtCreditMemoRemarksValidated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(RemoteClient.ProcStatic.TrimStartEndString(this.txtCreditMemoRemarks.Text)) &&
                !String.Equals(_studentCreditMemo.Remarks, RemoteClient.ProcStatic.TrimStartEndString(this.txtCreditMemoRemarks.Text)))
                _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = true;

            _studentCreditMemo.Remarks = RemoteClient.ProcStatic.TrimStartEndString(this.txtCreditMemoRemarks.Text);
        }//-------------------
        //###########################################END TEXTBOX txtCreditMemoRemarks EVENTS#####################################################

        //###########################################TEXTBOX txtReimbursementRemarks EVENTS#####################################################
        //event is rasied when the key is pressed
        private void txtReimbursementRemarksKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.btnRecordReimbursement.Focus();
            }
        }//------------------

        //event is raised when the control is validated
        private void txtReimbursementRemarksValidated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(RemoteClient.ProcStatic.TrimStartEndString(this.txtReimbursementRemarks.Text)) &&
                !String.Equals(_studentReimbursementInfo.Remarks, RemoteClient.ProcStatic.TrimStartEndString(this.txtReimbursementRemarks.Text)))
                _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = true;

            _studentReimbursementInfo.Remarks = RemoteClient.ProcStatic.TrimStartEndString(this.txtReimbursementRemarks.Text);
        }//---------------------
        //###########################################END TEXTBOX txtReimbursementRemarks EVENTS#####################################################

        //###########################################TEXTBOX txtAdditionalPaymentAmount EVENTS#####################################################
        //event is raised when the key is pressed
        private void txtAdditionalPaymentAmountKeyPress(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxAmountOnly(e);

            if (e.KeyChar == '\r')
            {
                this.txtAdditionalFeeRemarks.Focus();
            }
        }//-------------------

        //event is raised when the control is validated
        private void txtAdditionalPaymentAmountValidated(object sender, EventArgs e)
        {
            Decimal amount;

            if (Decimal.TryParse(txtAdditionalPaymentAmount.Text, out amount))
            {
                if (amount != 0 && _studentAdditionalFeeInfo.Amount != amount)
                    _hasUpdatedAdditionalFee = true;

                 _studentAdditionalFeeInfo.Amount = amount;
            }
        }//---------------------
        //###########################################END TEXTBOX txtAdditionalPaymentAmount EVENTS#####################################################

        //###########################################TEXTBOX txtAdditionalPaymentRemarks EVENTS#####################################################
        //event is raised when the control is validated
        private void txtAdditionalFeeRemarksValidated(object sender, EventArgs e)
        {
            _studentAdditionalFeeInfo.Remarks = RemoteClient.ProcStatic.TrimStartEndString(this.txtAdditionalFeeRemarks.Text);
        }//--------------------------

        //event is raised when the key is pressed
        private void txtAdditionalFeeRemarksKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (this.btnAdditionalPayment.Enabled)
                {
                    this.btnAdditionalPayment.Focus();
                }
                else
                {
                    this.btnUpdateAdditionalPayment.Focus();
                }
            }
        }//--------------------------
        //###########################################END TEXTBOX txtAdditionalPaymentRemarks EVENTS#####################################################

        //###########################################TEXTBOX txtDiscountRemarks EVENTS#####################################################
        //event is raised when the key is pressed
        private void txtDiscountRemarksKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (this.btnRecordDiscount.Enabled)
                {
                    this.btnRecordDiscount.Focus();
                }
                else
                {
                    this.btnUpdateDiscount.Focus();
                }
            }
        }//--------------------------

        //event is raised when the control is validated
        private void txtDiscountRemarksValidated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(RemoteClient.ProcStatic.TrimStartEndString(this.txtDiscountRemarks.Text)) &&
                !String.Equals(_studentDiscountInfo.Remarks, RemoteClient.ProcStatic.TrimStartEndString(this.txtDiscountRemarks.Text)))
                _hasUpdatedDiscount = true;

            _studentDiscountInfo.Remarks = RemoteClient.ProcStatic.TrimStartEndString(this.txtDiscountRemarks.Text);
        }//---------------------------
        //###########################################END TEXTBOX txtDiscountRemarks EVENTS#####################################################

        //###########################################TEXTBOX txtDiscountAmount EVENTS#####################################################
        //event is raised when the key is pressed
        private void txtDiscountAmountKeyPress(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxAmountOnly(e);

            if (e.KeyChar == '\r')
            {
                this.txtDiscountRemarks.Focus();
            }
        }//---------------------

        //event is raised when the control is validated
        private void txtDiscountAmountValidated(object sender, EventArgs e)
        {
            Decimal amount;

            if (Decimal.TryParse(txtDiscountAmount.Text, out amount))
            {
                if (amount != 0 && _studentDiscountInfo.Amount != amount)
                    _hasUpdatedDiscount = true;

                _studentDiscountInfo.Amount = amount;
            }
        }//----------------------
        //###########################################TEXTBOX txtDiscountAmount EVENTS#####################################################

        //###########################################TEXTBOX txtBalanceForwardedAmount EVENTS#####################################################
        //event is raised when the key is pressed
        private void txtBalanceForwardedAmountKeyPress(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxAmountOnly(e);

            if (e.KeyChar == '\r')
            {
                this.btnRecordBalanceForwarded.Focus();
            }
        }//------------------------

        //event is raised when the control is validated
        private void txtBalanceForwardedAmountValidated(object sender, EventArgs e)
        {
            Decimal amount;

            if (Decimal.TryParse(txtBalanceForwardedAmount.Text, out amount))
            {
                if (amount != 0 && _studentBalanceForwardedInfo.Amount != amount)
                {
                    _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = true;
                }

                _studentBalanceForwardedInfo.Amount = amount;
            }
        }//--------------------------
        //###########################################END TEXTBOX txtBalanceForwardedAmount EVENTS#####################################################

        //###########################################TEXTBOX txtReceipNo EVENTS#####################################################
        //event is raised whent the key is pressed
        private void txtReceipNoKeyPress(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxIntegersOnly(e);

            if (e.KeyChar == '\r')
            {
                this.txtPaymentRemarks.Focus();
            }
        }//-----------------
        
        //event is raised when the control is validated
        private void txtReceipNoValidated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(RemoteClient.ProcStatic.TrimStartEndString(this.txtReceipNo.Text)) &&
                !String.Equals(_studentPaymentInfo.ReceiptNo, RemoteClient.ProcStatic.TrimStartEndString(this.txtReceipNo.Text)))
                _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = true;

            _studentPaymentInfo.ReceiptNo = this.txtReceipNo.Text = RemoteClient.ProcStatic.TrimStartEndString(this.txtReceipNo.Text);
        }//--------------------
        //###########################################TEXTBOX txtReceipNo EVENTS#####################################################

        //###########################################TEXTBOX txtRemarks EVENTS#####################################################
        //event is raised when the key is pressed
        private void txtPaymentRemarksKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.txtBank.Focus();
            }
        }//---------------------------

        //event is raised when the control is validated
        private void txtPaymentRemarksValidated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(RemoteClient.ProcStatic.TrimStartEndString(this.txtPaymentRemarks.Text)) &&
                !String.Equals(_studentPaymentInfo.Remarks, RemoteClient.ProcStatic.TrimStartEndString(this.txtPaymentRemarks.Text)))
                _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = true;

            _studentPaymentInfo.Remarks = RemoteClient.ProcStatic.TrimStartEndString(this.txtPaymentRemarks.Text);
        }//--------------------
        //###########################################END TEXTBOX txtRemarks EVENTS#####################################################

        //###########################################CHECKBOX chkIsDownpayment EVENTS#####################################################
        //event is raised when the checked is changed
        private void chkIsDownPaymentCheckedChanged(object sender, EventArgs e)
        {
            _studentPaymentInfo.IsDownpayment = this.chkIsDownPaymentPayment.Checked;
        }//----------------------
        //###########################################END CHECKBOX chkIsDownpayment EVENTS#####################################################

        //###########################################CHECKBOX chkIsDownpaymentDiscount EVENTS#####################################################
        //event is raised when the checked is changed
        private void chkIsDownpaymentDiscountCheckedChanged(object sender, EventArgs e)
        {
            _studentDiscountInfo.IsDownpayment = this.chkIsDownpaymentDiscount.Checked;
        }//-------------------------
        //###########################################END CHECKBOX chkIsDownpaymentDiscount EVENTS#####################################################

        //###########################################CHECKBOX chkIsMiscellaneousIncome EVENTS#####################################################
        //event is raised when the checked is changed
        private void chkIsMiscellaneousIncomeCheckedChanged(object sender, EventArgs e)
        {
            _studentPaymentInfo.IsMiscellaneousIncome = this.chkIsMiscellaneousIncome.Checked;

            if (_studentPaymentInfo.IsMiscellaneousIncome)
            {
                _studentPaymentInfo.Remarks = this.txtPaymentRemarks.Text = _studentPaymentInfo.AccountCreditInfo.AccountName;
            }
            else
            {
                _studentPaymentInfo.Remarks = this.txtPaymentRemarks.Text = String.Empty;
            }
        }//-------------------------
        //###########################################END CHECKBOX chkIsMiscellaneousIncome EVENTS#####################################################

        //###########################################CHECKBOX chkIsDownpaymentPromissoryNote EVENTS#####################################################
        //event is raised when the checked is changed
        private void chkIsDownPaymentPromissoryNoteCheckedChanged(object sender, EventArgs e)
        {
            _studentPromissoryNoteInfo.IsDownpayment = this.chkIsDownPaymentPromissoryNote.Checked;
        }//----------------------
        //###########################################END CHECKBOX chkIsDownpaymentPromissoryNote EVENTS#####################################################

        //###########################################CHECKBOX chkIsDownpaymentCreditMemo EVENTS#####################################################
        //event is raised when the checked is changed
        private void chkIsDownpaymentCreditMemoCheckedChanged(object sender, EventArgs e)
        {
            _studentCreditMemo.IsDownpayment = this.chkIsDownpaymentCreditMemo.Checked;
        }//------------------------
        //###########################################END CHECKBOX chkIsDownpaymentCreditMemo EVENTS#####################################################

        //###########################################CHECKBOX chkIsDownpaymentReimbursements EVENTS#####################################################
        //event is raised when the checked is changed
        private void chkIsDownPaymentReimbursementsCheckedChanged(object sender, EventArgs e)
        {
            _studentReimbursementInfo.IsDownpayment = this.chkIsDownPaymentReimbursements.Checked;
        }//---------------------------
        //###########################################END CHECKBOX chkIsDownpaymentReimbursements EVENTS#####################################################

        //###########################################LISTVIEW lsvPaymentHistory EVENTS#####################################################
        //event is raised when the mouse double clicked
        private void lsvPaymentHistoryMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if ((lsvPaymentHistory.Items.Count > 0 && lsvPaymentHistory.FocusedItem != null) && lsvPaymentHistory.GetItemAt(e.X, e.Y) != null)
                {
                    _studentPaymentInfo = _cashieringManager.GetDetailsStudentPayment(lsvPaymentHistory.GetItemAt(e.X, e.Y).SubItems[8].Text);

                    this.txtPaymentAmount.Text = _studentPaymentInfo.Amount.ToString("N");
                    this.txtDiscountedAmount.Text = _studentPaymentInfo.DiscountAmount.ToString("N");
                    this.txtReceipNo.Text = _studentPaymentInfo.ReceiptNo;
                    this.txtPaymentRemarks.Text = _studentPaymentInfo.Remarks;
                    this.chkIsDownPaymentPayment.Checked = _studentPaymentInfo.IsDownpayment;
                    this.chkIsMiscellaneousIncome.Checked = _studentPaymentInfo.IsMiscellaneousIncome;
                    this.lblPaymentReceivedDate.Text = DateTime.Parse(_studentPaymentInfo.ReceivedDate).ToLongDateString();
                    this.lblReceiptDate.Text = DateTime.Parse(_studentPaymentInfo.ReceiptDate).ToLongDateString();
                    this.txtAmountTendered.Text = _studentPaymentInfo.AmountTendered.ToString("N");
                    this.txtBank.Text = _studentPaymentInfo.Bank;
                    this.txtCheckNo.Text = _studentPaymentInfo.CheckNo;
                    this.txtCreditEntry.Text = !String.IsNullOrEmpty(_studentPaymentInfo.AccountCreditInfo.AccountSysId) ?
                        _studentPaymentInfo.AccountCreditInfo.AccountCode + " - " + _studentPaymentInfo.AccountCreditInfo.AccountName : String.Empty;

                    this.lblChange.Text = String.Format("{0:#,##0.00;(#,##0.00)}", (_studentPaymentInfo.AmountTendered - _studentPaymentInfo.Amount));

                    //if (_isPaymentReimbursementCreditMemoRecordOpen)
                    //{
                    _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = true;

                    if (_studentPaymentInfo.PaymentId <= 0)
                    {
                        this.btnUpdatePayment.Enabled = this.btnDeletePayment.Enabled = this.lnkReIssue.Enabled = false;
                        this.btnPayment.Enabled = true;

                    }
                    else
                    {
                        this.btnUpdatePayment.Enabled = this.btnDeletePayment.Enabled = this.lnkReIssue.Enabled = true;
                        this.btnPayment.Enabled = false;

                        this.lblPaymentReflectedDate.Text = DateTime.Parse(_studentPaymentInfo.ReflectedDate.ToString()).ToLongDateString();
                    }
                    //}

                    this.IsRecordLocked(DateTime.Parse(_studentPaymentInfo.ReceivedDate), true, false, false, false, false);
                    this.IsRecordLocked(DateTime.Parse(_studentPaymentInfo.ReceiptDate), DateTime.Parse(_studentPaymentInfo.ReceivedDate));
                }
            }
        }//------------------------------

        //event is raised when the mouse is down
        private void lsvPaymentHistoryMouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Right || e.Button == MouseButtons.Left) &&
              (this.lsvPaymentHistory.Items.Count > 0 && this.lsvPaymentHistory.FocusedItem != null))
            {
                if (this.lsvPaymentHistory.SelectedItems.Count > 0)
                {
                    if (this.lsvPaymentHistory.GetItemAt(e.X, e.Y) != null && e.Button == MouseButtons.Right)
                    {
                        String strMsg = "Print - [" + this.lsvPaymentHistory.GetItemAt(e.X, e.Y).Text + "].";

                        _studentPaymentId = this.lsvPaymentHistory.GetItemAt(e.X, e.Y).SubItems[8].Text;

                        this.cmsRePrint.Items[0].Text = strMsg;
                        this.cmsRePrint.Show(this.lsvPaymentHistory, new Point(e.X, e.Y));                        
                    }
                }
            }
        }//-------------------------
        //###########################################END LISTVIEW lsvPaymentHistory EVENTS#####################################################

        //###########################################LISTVIEW lvbCreditMemo EVENTS#####################################################
        //event is raised when the mouse double clicked
        private void lsvCreditMemoMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((this.lsvCreditMemo.Items.Count > 0 && this.lsvCreditMemo.FocusedItem != null) && this.lsvCreditMemo.GetItemAt(e.X, e.Y) != null)
            {
                _studentCreditMemo = _cashieringManager.GetDetailsStudentCreditMemo(this.lsvCreditMemo.GetItemAt(e.X, e.Y).Text);

                this.txtCreditMemoAmount.Text = _studentCreditMemo.Amount.ToString("N");
                this.txtCreditMemoRemarks.Text = _studentCreditMemo.Remarks;
                this.lblCreditMemoReceivedDate.Text = DateTime.Parse(_studentCreditMemo.ReceivedDate).ToLongDateString();
                this.chkIsDownpaymentCreditMemo.Checked = _studentCreditMemo.IsDownpayment;

                this.lblCreditMemoReflectedDate.Text = DateTime.Parse(_studentCreditMemo.ReflectedDate).ToLongDateString();

                //if (_isPaymentReimbursementCreditMemoRecordOpen)
                //{
                    _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = true;

                    if (_studentCreditMemo.MemoId <= 0)
                    {
                        this.btnUpdateCreditMemo.Enabled = this.btnDeleteCreditMemo.Enabled = false;
                        this.btnRecordCreditMemo.Enabled = true;
                    }
                    else
                    {
                        this.btnUpdateCreditMemo.Enabled = this.btnDeleteCreditMemo.Enabled = true;
                        this.btnRecordCreditMemo.Enabled = false;
                    }

                    this.txtCreditMemoAmount.ReadOnly = this.txtCreditMemoRemarks.ReadOnly = false;
                //}
                //else
                //{
                    //this.txtCreditMemoAmount.ReadOnly = this.txtCreditMemoRemarks.ReadOnly = true;
                //}

                    this.IsRecordLocked(DateTime.Parse(_studentCreditMemo.ReceivedDate), false, false, true, false, false);
            }
        }//--------------------------
        //###########################################END LISTVIEW lvbCreditMemo EVENTS#####################################################

        //###########################################LISTVIEW lsvReimbursement EVENTS#####################################################
        //event is raised when the mouse double clicked
        private void lsvReimbursementHistoryMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((this.lsvReimbursementHistory.Items.Count > 0 && this.lsvReimbursementHistory.FocusedItem != null) &&
                this.lsvReimbursementHistory.GetItemAt(e.X, e.Y) != null)
            {
                _studentReimbursementInfo = _cashieringManager.GetDetailsStudentReimbursements(this.lsvReimbursementHistory.GetItemAt(e.X, e.Y).Text);

                this.txtReimbursementAmount.Text = _studentReimbursementInfo.Amount.ToString("N");
                this.txtReimbursementRemarks.Text = _studentReimbursementInfo.Remarks;
                this.lblReimbursementsReceivedDate.Text = DateTime.Parse(_studentReimbursementInfo.ReceivedDate).ToLongDateString();
                this.chkIsDownPaymentReimbursements.Checked = _studentReimbursementInfo.IsDownpayment;

                this.lblReimbursmentReflectedDate.Text = DateTime.Parse(_studentReimbursementInfo.ReflectedDate).ToLongDateString();

                //if (_isPaymentReimbursementCreditMemoRecordOpen)
                //{
                    _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = true;

                    if (_studentReimbursementInfo.ReimbursementId <= 0)
                    {
                        this.btnUpdateReimbursment.Enabled = this.btnDeleteReimbursement.Enabled = false;
                        this.btnRecordReimbursement.Enabled = true;
                    }
                    else
                    {
                        this.btnUpdateReimbursment.Enabled = this.btnDeleteReimbursement.Enabled = true;
                        this.btnRecordReimbursement.Enabled = false;
                    }


                    this.txtReimbursementAmount.ReadOnly = this.txtReimbursementRemarks.ReadOnly = false;
                //}
                //else
                //{
                //    this.txtReimbursementAmount.ReadOnly = this.txtReimbursementRemarks.ReadOnly = true;
                //}

                    this.IsRecordLocked(DateTime.Parse(_studentReimbursementInfo.ReceivedDate), false, true, false, false, false);
            }
        }//---------------------------
        //###########################################END LISTVIEW lsvReimbursement EVENTS#####################################################

        //###########################################LISTVIEW lsvAdditionalPayment EVENTS#####################################################
        //event is raised when the mouse double clicked
        private void lsvAdditionalPaymentMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((lsvAdditionalPayment.Items.Count > 0 && lsvAdditionalPayment.FocusedItem != null) && lsvAdditionalPayment.GetItemAt(e.X, e.Y) != null)
            {
                this.gbxAdditionalPayment.Enabled = true;

                _studentAdditionalFeeInfo = _cashieringManager.GetDetailsStudentAdditionalFee(lsvAdditionalPayment.GetItemAt(e.X, e.Y).Text);

                _studentAdditionalFeeInfo.StudentEnrolmentLevelInfo.EnrolmentLevelSysId = _studentEnrolmentLevelInfo.EnrolmentLevelSysId;

                this.lblParticularDescription.Text = _studentAdditionalFeeInfo.SchoolFeeParticularInfo.ParticularDescription;
                this.txtAdditionalPaymentAmount.Text = _studentAdditionalFeeInfo.Amount.ToString("N");
                this.txtAdditionalFeeRemarks.Text = _studentAdditionalFeeInfo.Remarks;

                if (_isAdditionalFeeRecordOpen)
                {
                    if (_studentAdditionalFeeInfo.AdditionalFeeId <= 0)
                    {
                        this.btnAdditionalPayment.Enabled = true;
                        this.btnUpdateAdditionalPayment.Enabled = this.btnDeleteAdditionalPayment.Enabled = false;
                    }
                    else
                    {
                        this.btnAdditionalPayment.Enabled = false;
                        this.btnUpdateAdditionalPayment.Enabled = this.btnDeleteAdditionalPayment.Enabled = true;
                    }

                    _hasUpdatedAdditionalFee = true;
                }

                this.txtAdditionalPaymentAmount.Focus();
            }
        }//---------------------
        //###########################################END LISTVIEW lsvAdditionalPayment EVENTS#####################################################

         //###########################################LISTVIEW lsvDiscount EVENTS#####################################################
        //event is raised when the mouse double clicked
        private void lsvDiscountMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((lsvDiscount.Items.Count > 0 && lsvDiscount.FocusedItem != null) && lsvDiscount.GetItemAt(e.X, e.Y) != null)
            {
                this.gbxDiscount.Enabled = true;

                _studentDiscountInfo = _cashieringManager.GetDetailsStudentDiscount(lsvDiscount.GetItemAt(e.X, e.Y).Text);

                this.lblScholarshipDescription.Text = _studentDiscountInfo.StudentScholarshipInfo.ScholarshipInfo.ScholarshipDescription;
                this.txtDiscountAmount.Text = _studentDiscountInfo.Amount.ToString("N");
                this.txtDiscountRemarks.Text = _studentDiscountInfo.Remarks;
                this.chkIsDownpaymentDiscount.Checked = _studentDiscountInfo.IsDownpayment;

                this.lblDiscountReflectedDate.Text = DateTime.Parse(_studentDiscountInfo.ReflectedDate).ToLongDateString();
                
                if (_isDiscountRecordOpen)
                {
                    if (_studentDiscountInfo.DiscountId <= 0)
                    {
                        this.btnRecordDiscount.Enabled = true;
                        this.btnUpdateDiscount.Enabled = this.btnDeleteDiscount.Enabled = false;
                    }
                    else
                    {
                        this.btnRecordDiscount.Enabled = false;
                        this.btnUpdateDiscount.Enabled = this.btnDeleteDiscount.Enabled = true;
                    } 
                    
                    _hasUpdatedDiscount = true;
                }

                this.txtDiscountAmount.ReadOnly = this.txtDiscountRemarks.ReadOnly = false;

                this.txtDiscountAmount.Focus();

                this.btnSearchDiscount.Enabled = false;

                this.IsRecordLocked(DateTime.Parse(_studentDiscountInfo.ReceivedDate), false, false, false, false, true);
            }
            else
            {
                this.txtDiscountAmount.ReadOnly = this.txtDiscountRemarks.ReadOnly = true;
            }
        }//----------------------
        //###########################################END LISTVIEW lsvDiscount EVENTS#####################################################

        //###########################################LISTVIEW lsvWithdrawnSubject EVENTS#####################################################
        //event is raised when the mouse is down
        private void lsvWithdrawnSubjectsMouseDown(object sender, MouseEventArgs e)
        {
            if (_isWithdrawnSubjectSpecialClassOpen)
            {
                if ((e.Button == MouseButtons.Right || e.Button == MouseButtons.Left) &&
                     (this.lsvWithdrawnSubjects.Items.Count > 0 && this.lsvWithdrawnSubjects.FocusedItem != null))
                {
                    if (this.lsvWithdrawnSubjects.SelectedItems.Count > 0)
                    {
                        if (this.lsvWithdrawnSubjects.GetItemAt(e.X, e.Y) != null && e.Button == MouseButtons.Right)
                        {
                            String strMsg = "Permanently withdraw subject schedule - [" + this.lsvWithdrawnSubjects.GetItemAt(e.X, e.Y).Text + "].";

                            _sysIdSubjectSchedule = this.lsvWithdrawnSubjects.GetItemAt(e.X, e.Y).Text;

                            this.cmsWithdrawSubject.Items[0].Text = strMsg;
                            this.cmsWithdrawSubject.Show(this.lsvWithdrawnSubjects, new Point(e.X, e.Y));
                        }
                    }
                }
            }
        }//------------------------
        //###########################################END LISTVIEW lsvWithdrawnSubject EVENTS#####################################################

        //###########################################LISTVIEW lsvWithdrawnSpecialClass EVENTS#####################################################
        //event is raised when the mouse is down
        private void lsvWithdrawnSpecialClassMouseDown(object sender, MouseEventArgs e)
        {
            if (_isWithdrawnSubjectSpecialClassOpen)
            {
                if ((e.Button == MouseButtons.Right || e.Button == MouseButtons.Left) &&
                    (this.lsvWithdrawnSpecialClass.Items.Count > 0 && this.lsvWithdrawnSpecialClass.FocusedItem != null))
                {
                    if (this.lsvWithdrawnSpecialClass.SelectedItems.Count > 0)
                    {
                        if (this.lsvWithdrawnSpecialClass.GetItemAt(e.X, e.Y) != null && e.Button == MouseButtons.Right)
                        {
                            String strMsg = "Permanently withdraw special class load - [" + this.lsvWithdrawnSpecialClass.GetItemAt(e.X, e.Y).Text + "].";

                            _sysIdSpecialClass = this.lsvWithdrawnSpecialClass.GetItemAt(e.X, e.Y).Text;

                            this.cmsWithdrawSpecialClass.Items[0].Text = strMsg;
                            this.cmsWithdrawSpecialClass.Show(this.lsvWithdrawnSpecialClass, new Point(e.X, e.Y));
                        }
                    }
                }
            }
        }//-------------------------
        //###########################################END LISTVIEW lsvWithdrawnSpecialClass EVENTS#####################################################

        //###########################################LISTVIEW lsvCurrentCharges EVENTS#####################################################
        //event is raised when the mouse is down
        private void lsvCurrentChargesMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if ((this.lsvCurrentCharges.Items.Count > 0 && this.lsvCurrentCharges.FocusedItem != null) && this.lsvCurrentCharges.GetItemAt(e.X, e.Y) != null)
                {
                    if (Int64.TryParse(this.lsvCurrentCharges.GetItemAt(e.X, e.Y).SubItems[2].Text, out _optionalFeeId))
                    {
                        if (_cashieringManager.IsOptionalFeeAndIsOfficeAccess(_optionalFeeId))
                        {
                            String strMsg = "Delete optional fee - [" +
                                this.lsvCurrentCharges.GetItemAt(e.X, e.Y).Text.Substring(19) + "].";

                            _sysIdFeeDetails = this.lsvCurrentCharges.GetItemAt(e.X, e.Y).SubItems[3].Text;

                            this.cmsDelete.Items[0].Text = strMsg;
                            this.cmsDelete.Show(this.lsvCurrentCharges, new Point(e.X, e.Y));
                        }
                    }
                }
            }
        }//------------------------
        //###########################################END LISTVIEW lsvCurrentCharges EVENTS#####################################################

        //###########################################BUTTON btnClose EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//-----------------------
        //###########################################END BUTTON btnClose EVENTS#####################################################

        //###########################################BUTTON btnSearchedAdditionalFee EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnSearchAdditionalFeeClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
           
            try
            {
                using (AdditionalFeeSearchOnTextBoxList frmSearch = new AdditionalFeeSearchOnTextBoxList(_cashieringManager))
                {
                    frmSearch.AdoptGridSize = false;
                    frmSearch.ShowDialog(this);

                    if (frmSearch.HasSelected)
                    {
                        CommonExchange.StudentAdditionalFee studentAdditionalFeeTemp = _cashieringManager.GetDetailsAdditionalFee(frmSearch.PrimaryId);

                        _studentAdditionalFeeInfo.SchoolFeeParticularInfo.FeeParticularSysId = 
                            studentAdditionalFeeTemp.SchoolFeeParticularInfo.FeeParticularSysId;
                        _studentAdditionalFeeInfo.SchoolFeeParticularInfo.ParticularDescription = 
                            studentAdditionalFeeTemp.SchoolFeeParticularInfo.ParticularDescription;

                        _studentAdditionalFeeInfo.StudentEnrolmentLevelInfo.EnrolmentLevelSysId = _studentEnrolmentLevelInfo.EnrolmentLevelSysId;

                        this.lblParticularDescription.Text = _studentAdditionalFeeInfo.SchoolFeeParticularInfo.ParticularDescription;
                        this.txtAdditionalPaymentAmount.Text = _studentAdditionalFeeInfo.Amount.ToString("N");

                        this.txtAdditionalPaymentAmount.Focus();
                        this.txtAdditionalPaymentAmount.Select();

                        this.btnAdditionalPayment.Enabled = true;

                        _hasUpdatedAdditionalFee = true;
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }

            this.Cursor = Cursors.Arrow;
        }//------------------------
        //###########################################END BUTTON btnSearchedAdditionalFee EVENTS#####################################################

        //###########################################BUTTON btnSearchDiscount EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnSearchDiscountClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (StudentScholarshipSearchOnTextBoxList frmSearch = new StudentScholarshipSearchOnTextBoxList(_userInfo, _cashieringManager))
                {
                    frmSearch.AdoptGridSize = true;
                    frmSearch.ShowDialog(this);

                    if (frmSearch.HasSelected)
                    {
                        CommonExchange.ScholarshipInformation scholarshipInfo = _cashieringManager.GetDetailsScholarshipInformation(frmSearch.PrimaryId);

                        _studentScholarshipInfo = new CommonExchange.StudentScholarship();

                        _studentScholarshipInfo.ScholarshipInfo = scholarshipInfo;

                        this.lblScholarshipDescription.Text = scholarshipInfo.ScholarshipDescription;

                        _hasUpdatedDiscount = true;

                        this.txtDiscountAmount.Focus();

                        this.btnRecordDiscount.Enabled = true;
                    }
                }

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }
        }//------------------------
        //###########################################END BUTTON btnSearchDiscount EVENTS#####################################################

        //###########################################BUTTON bthSearchedAccountTitle EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnSearchedAccountTitleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (ChartOfAccountSearchedOnTextBoxList frmSearch = new ChartOfAccountSearchedOnTextBoxList(_userInfo, _cashieringManager))
                {
                    frmSearch.PrimaryIndex = 4;
                    frmSearch.AdoptGridSize = false;
                    frmSearch.ShowDialog(this);

                    if (frmSearch.HasSelected)
                    {
                        this.chkIsMiscellaneousIncome.Checked = false;
                        this.txtPaymentRemarks.Text = _studentPaymentInfo.Remarks = String.Empty;

                        //_studentPaymentInfo.AccountCreditInfo = _cashieringManager.ChartOfAccountInformation =
                        //    _cashieringManager.GetChartOfAccountInformation(frmSearch.PrimaryId);

                        _studentPaymentInfo.AccountCreditInfo = CashieringLogic.ChartOfAccountInformation =
                           _cashieringManager.GetChartOfAccountInformation(frmSearch.PrimaryId);

                        this.txtCreditEntry.Text = !String.IsNullOrEmpty(_studentPaymentInfo.AccountCreditInfo.AccountSysId) ?
                            _studentPaymentInfo.AccountCreditInfo.AccountCode + " - " + _studentPaymentInfo.AccountCreditInfo.AccountName : String.Empty;

                        this.chkIsMiscellaneousIncome.Enabled = true;
                    }
                    else
                    {
                        this.chkIsMiscellaneousIncome.Enabled = !String.IsNullOrEmpty(_studentPaymentInfo.AccountCreditInfo.AccountSysId) ? true : false;
                    }
                }

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }
        }//-------------------------
        //###########################################END BUTTON bthSearchedAccountTitle EVENTS#####################################################

        //###########################################BUTTON btnPayment EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnPaymentClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateControlsPaymentReimbursement(true, false))
                {
                    String strMsg = "Are you sure you want to record the new student payment?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question, 
                        MessageBoxDefaultButton.Button1);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student payment has been successfully recorded.";

                        this.Cursor = Cursors.WaitCursor;

                        _cashieringManager.InsertStudentPayment(_userInfo, _studentPaymentInfo);
                        
                        _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = false;

                        this.txtPaymentAmount.Clear();
                        this.txtPaymentAmount.Focus();
                        this.txtReceipNo.Text = RemoteClient.ProcStatic.SixDigitZero(CashieringLogic.ReceiptNumber);
                        this.txtPaymentRemarks.Clear();
                        this.txtDiscountedAmount.Clear();
                        this.txtAmountTendered.Clear();
                        this.txtBank.Clear();
                        this.txtCheckNo.Clear();
                        this.lblChange.Text = "-";
                        this.chkIsDownPaymentPayment.Checked = false;
                        this.chkIsMiscellaneousIncome.Checked = false;

                        this.InitializeStudentPaymentDiscountReimbursementTable();
                                              
                        _cashieringManager.InitializePaymentHistroyListView(this.lsvPaymentHistory, tabPaymentHistory);
                        _cashieringManager.InitializeAmountDueList(this.lsvAmountDueList,
                            _studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.CourseInfo.CourseId, DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd),
                            _cashieringManager.IsSchoolYearForSummer(_cashieringManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)));

                        if (cboYearLevel.SelectedIndex > 0)
                        {
                            _cashieringManager.InitializeStudentChargesListView(this.lsvCurrentCharges,
                                this.lblMenuCurrentCharges, _studentInfo.StudentSysId, true);
                        }

                        DateTime dateStart = DateTime.MinValue;
                        DateTime dateEnd = DateTime.MinValue;

                        if (DateTime.TryParse(_dateStart, out dateStart) && DateTime.TryParse(_dateEnd, out dateEnd))
                        {
                            _studentPaymentInfo.ReflectedDate = _cashieringManager.GetReflectedDate(dateStart, dateEnd).ToShortDateString() + " 12:00:00 AM";

                            this.lblPaymentReflectedDate.Text = DateTime.Parse(_studentPaymentInfo.ReflectedDate).ToLongDateString();
                        }

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        if (!this.chkDisableAutomaticPrint.Checked)
                        {
                            _studentPaymentInfo.PaymentId = _cashieringManager.GetLatestPaymentId();

                            long wholeNum = _cashieringManager.GetWholeNumberTenthDecimal(_studentPaymentInfo.Amount, true);
                            int decNum = (int)_cashieringManager.GetWholeNumberTenthDecimal(_studentPaymentInfo.Amount, false);

                            _cashieringManager.PrintReceiptNumberStudentPayments(_userInfo, _studentPaymentInfo, _studentInfo, _dateEnd,
                                _cashieringManager.GetEnrolmentCourseAcronym(_strEnrolmentCourseSysId), wholeNum, decNum);
                        }

                        CashieringLogic.ReceiptNumber = int.Parse(_studentPaymentInfo.ReceiptNo) + 1;

                        _studentPaymentInfo.AmountTendered = 0;
                        _studentPaymentInfo.Amount = 0;
                        _studentPaymentInfo.PaymentId = 0;

                        _studentPaymentInfo.ReceiptNo = this.txtReceipNo.Text = RemoteClient.ProcStatic.SixDigitZero(CashieringLogic.ReceiptNumber);

                        _studentPaymentInfo.ReceiptDate = CashieringLogic.ReceiptDate;

                        this.lblReceiptDate.Text = DateTime.Parse(_studentPaymentInfo.ReceiptDate).ToLongDateString();

                        this.lblRunningBalance.Text = "Running Balance: " + _cashieringManager.GetStudentRunningBalance(_userInfo, _studentInfo.StudentSysId);
                    }
                    else
                    {
                        CashieringLogic.ReceiptNumber -= 1;
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Recording");
            }
        }//--------------------
        //###########################################END BUTTON btnPayment EVENTS#####################################################

        //###########################################BUTTON btnUpdatePayment EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnUpdatePaymentClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateControlsPaymentReimbursement(true, false))
                {
                    String strMsg = "Are you sure you want to update the student payment?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student payment has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _cashieringManager.UpdateStudentPayment(_userInfo, _studentPaymentInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = false;

                        this.txtPaymentAmount.Clear();
                        this.txtReceipNo.Text = _studentPaymentInfo.ReceiptNo = RemoteClient.ProcStatic.SixDigitZero(CashieringLogic.ReceiptNumber);
                        this.txtPaymentAmount.Focus();
                        this.txtPaymentRemarks.Clear();
                        this.txtDiscountedAmount.Clear();
                        this.txtAmountTendered.Clear();
                        this.txtBank.Clear();
                        this.txtCheckNo.Clear();
                        this.lblChange.Text = "-";
                        this.chkIsDownPaymentPayment.Checked = false;
                        this.chkIsMiscellaneousIncome.Checked = false;

                        _studentPaymentInfo.Amount = 0;
                        _studentPaymentInfo.AmountTendered = 0;

                        this.btnPayment.Enabled = true;
                        this.btnUpdatePayment.Enabled = this.btnDeletePayment.Enabled = this.lnkReIssue.Enabled = false;                        
                        this.txtPaymentAmount.ReadOnly = this.txtReceipNo.ReadOnly = this.txtPaymentRemarks.ReadOnly =
                            this.txtDiscountedAmount.ReadOnly = false;

                        this.InitializeStudentPaymentDiscountReimbursementTable();

                        _cashieringManager.InitializePaymentHistroyListView(this.lsvPaymentHistory, this.tabPaymentHistory);
                        _cashieringManager.InitializeAmountDueList(this.lsvAmountDueList,
                            _studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.CourseInfo.CourseId, DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd),
                            _cashieringManager.IsSchoolYearForSummer(_cashieringManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)));

                        if (cboYearLevel.SelectedIndex > 0)
                        {
                            _cashieringManager.InitializeStudentChargesListView(this.lsvCurrentCharges, 
                                this.lblMenuCurrentCharges, _studentInfo.StudentSysId, true);
                        }

                        DateTime dateStart = DateTime.MinValue;
                        DateTime dateEnd = DateTime.MinValue;

                        if (DateTime.TryParse(_dateStart, out dateStart) && DateTime.TryParse(_dateEnd, out dateEnd))
                        {
                            _studentPaymentInfo.ReflectedDate = _cashieringManager.GetReflectedDate(dateStart, dateEnd).ToShortDateString() + " 12:00:00 AM";

                            this.lblPaymentReflectedDate.Text = DateTime.Parse(_studentPaymentInfo.ReflectedDate).ToLongDateString();
                        }

                        _studentPaymentInfo.ReceiptDate = CashieringLogic.ReceiptDate;

                        this.lblReceiptDate.Text = DateTime.Parse(_studentPaymentInfo.ReceiptDate).ToLongDateString();

                        this.lblRunningBalance.Text = "Running Balance: " + _cashieringManager.GetStudentRunningBalance(_userInfo, _studentInfo.StudentSysId);
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Updating");
            }
        }//---------------------
        //###########################################END BUTTON btnUpdatePayment EVENTS#####################################################        

        //###########################################BUTTON btnDeletePayment EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnDeletePaymentClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateControlsPaymentReimbursement(true, false))
                {
                    String strMsg = "Are you sure you want to delete the student payment?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student payment has been successfully deleted.";

                        this.Cursor = Cursors.WaitCursor;

                         Boolean hasProcedded = false;

                        //cancel receipt number
                        try
                        {
                            this.Cursor = Cursors.WaitCursor;                           

                            using (ReceiptInformationCancelRecord frmRecord =
                                new ReceiptInformationCancelRecord(_userInfo, _cashieringManager, _studentPaymentInfo.ReceiptNo, _studentPaymentInfo.ReceiptDate))
                            {
                                frmRecord.IsFromReIssued = false;

                                frmRecord.ShowDialog(this);

                                if (frmRecord.HasRecorded)
                                {
                                    _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = false;

                                    this.txtPaymentAmount.Clear();
                                    this.txtPaymentAmount.Focus();
                                    this.txtReceipNo.Text = RemoteClient.ProcStatic.SixDigitZero(CashieringLogic.ReceiptNumber);
                                    this.txtPaymentRemarks.Clear();
                                    this.txtDiscountedAmount.Clear();
                                    this.txtAmountTendered.Clear();
                                    this.txtBank.Clear();
                                    this.txtCheckNo.Clear();
                                    this.lblChange.Text = "-";
                                    this.chkIsDownPaymentPayment.Checked = false;
                                    this.chkIsMiscellaneousIncome.Checked = false;

                                    this.btnDeletePayment.Enabled = this.btnUpdatePayment.Enabled = this.lnkReIssue.Enabled = false;
                                    this.btnPayment.Enabled = true;

                                    this.InitializeStudentPaymentDiscountReimbursementTable();

                                    _cashieringManager.DeleteStudentPayment(_userInfo, _studentPaymentInfo);

                                    hasProcedded = true;

                                    _cashieringManager.InitializePaymentHistroyListView(this.lsvPaymentHistory, tabPaymentHistory);

                                    _studentPaymentInfo.ReceiptDate = CashieringLogic.ReceiptDate;

                                    this.lblReceiptDate.Text = DateTime.Parse(_studentPaymentInfo.ReceiptDate).ToLongDateString();

                                    this.lblRunningBalance.Text = "Running Balance: " + _cashieringManager.GetStudentRunningBalance(_userInfo, _studentInfo.StudentSysId);
                                }
                            }

                            this.Cursor = Cursors.Arrow;
                        }
                        catch (Exception ex)
                        {
                            RemoteClient.ProcStatic.ShowErrorDialog("Error loading receipt information module./n/n" + ex.Message, "Error Loading");
                        }
                        //----------------------------------------

                        this.Cursor = Cursors.Arrow;

                        if (hasProcedded)
                        {
                            MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }

                        _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = false;

                        this.txtPaymentAmount.Clear();
                        this.txtPaymentAmount.Focus();
                        this.txtReceipNo.Text = RemoteClient.ProcStatic.SixDigitZero(CashieringLogic.ReceiptNumber);
                        this.txtPaymentRemarks.Clear();
                        this.txtDiscountedAmount.Clear();
                        this.txtAmountTendered.Clear();
                        this.chkIsDownPaymentPayment.Checked = false;
                        this.chkIsMiscellaneousIncome.Checked = false;
                        this.lblChange.Text = "-";

                        this.btnPayment.Enabled = true;
                        this.btnUpdatePayment.Enabled = false;
                        this.txtPaymentAmount.ReadOnly = this.txtReceipNo.ReadOnly = this.txtPaymentRemarks.ReadOnly =
                            this.txtDiscountedAmount.ReadOnly = false;

                        this.InitializeStudentPaymentDiscountReimbursementTable();

                        _cashieringManager.InitializePaymentHistroyListView(this.lsvPaymentHistory, this.tabPaymentHistory);
                        _cashieringManager.InitializeAmountDueList(this.lsvAmountDueList,
                            _studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.CourseInfo.CourseId, DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd),
                            _cashieringManager.IsSchoolYearForSummer(_cashieringManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)));

                        if (cboYearLevel.SelectedIndex > 0)
                        {
                            _cashieringManager.InitializeStudentChargesListView(this.lsvCurrentCharges,
                                this.lblMenuCurrentCharges, _studentInfo.StudentSysId, true);
                        }

                        DateTime dateStart = DateTime.MinValue;
                        DateTime dateEnd = DateTime.MinValue;

                        if (DateTime.TryParse(_dateStart, out dateStart) && DateTime.TryParse(_dateEnd, out dateEnd))
                        {
                            _studentPaymentInfo.ReflectedDate = _cashieringManager.GetReflectedDate(dateStart, dateEnd).ToShortDateString() + " 12:00:00 AM";

                            this.lblPaymentReflectedDate.Text = DateTime.Parse(_studentPaymentInfo.ReflectedDate).ToLongDateString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Deleting");
            }
        }//-------------------------
        //###########################################END BUTTON btnDeletePayment EVENTS#####################################################

        //###########################################BUTTON btnUpdateReimbursement EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnUpdateReimbursmentClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateControlsPaymentReimbursement(false, false))
                {
                    String strMsg = "Are you sure you want to update the student reimbursement?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student reimbursement has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _cashieringManager.UpdateStudentReimbursements(_userInfo, _studentReimbursementInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = false;

                        this.txtReimbursementAmount.Clear();
                        this.txtReimbursementAmount.Focus();
                        this.txtReimbursementRemarks.Clear();
                        this.chkIsDownPaymentReimbursements.Checked = false;

                        this.InitializeStudentPaymentDiscountReimbursementTable();

                        _cashieringManager.InitializeReimbursementHistoryListView(this.lsvReimbursementHistory, this.tabReimbursement);
                        _cashieringManager.InitializeAmountDueList(this.lsvAmountDueList,
                            _studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.CourseInfo.CourseId, DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd),
                            _cashieringManager.IsSchoolYearForSummer(_cashieringManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)));

                        this.lblRunningBalance.Text = "Running Balance: " + _cashieringManager.GetStudentRunningBalance(_userInfo, _studentInfo.StudentSysId);

                        if (cboYearLevel.SelectedIndex > 0)
                        {
                            _cashieringManager.InitializeStudentChargesListView(this.lsvCurrentCharges, 
                                this.lblMenuCurrentCharges, _studentInfo.StudentSysId, true);
                        }

                        DateTime dateStart = DateTime.MinValue;
                        DateTime dateEnd = DateTime.MinValue;

                        if (DateTime.TryParse(_dateStart, out dateStart) && DateTime.TryParse(_dateEnd, out dateEnd))
                        {
                            _studentReimbursementInfo.ReflectedDate = _cashieringManager.GetReflectedDate(dateStart, dateEnd).ToShortDateString() + 
                                " 12:00:00 AM";

                            this.lblReimbursmentReflectedDate.Text = DateTime.Parse(_studentReimbursementInfo.ReflectedDate).ToLongDateString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Updating");
            }
        }//-----------------------
        //###########################################END BUTTON btnUpdateReimbursement EVENTS#####################################################

        //###########################################BUTTON btnReimbursement EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnRecordReimbursementClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateControlsPaymentReimbursement(false, false))
                {
                    String strMsg = "Are you sure you want to record the new student reimbursement?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student reimbursement has been successfully recorded.";

                        this.Cursor = Cursors.WaitCursor;

                        _cashieringManager.InsertStudentReimbursement(_userInfo, _studentReimbursementInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = false;

                        this.txtReimbursementAmount.Clear();
                        this.txtReimbursementAmount.Focus();
                        this.txtReimbursementRemarks.Clear();
                        this.chkIsDownPaymentReimbursements.Checked = false;

                        this.InitializeStudentPaymentDiscountReimbursementTable();

                        _cashieringManager.InitializeReimbursementHistoryListView(this.lsvReimbursementHistory, this.tabReimbursement);
                        _cashieringManager.InitializeAmountDueList(this.lsvAmountDueList,
                            _studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.CourseInfo.CourseId, DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd),
                            _cashieringManager.IsSchoolYearForSummer(_cashieringManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)));

                        this.lblRunningBalance.Text = "Running Balance: " + _cashieringManager.GetStudentRunningBalance(_userInfo, _studentInfo.StudentSysId);

                        if (cboYearLevel.SelectedIndex > 0)
                        {
                            _cashieringManager.InitializeStudentChargesListView(this.lsvCurrentCharges, 
                                this.lblMenuCurrentCharges, _studentInfo.StudentSysId, true);
                        }

                        DateTime dateStart = DateTime.MinValue;
                        DateTime dateEnd = DateTime.MinValue;

                        if (DateTime.TryParse(_dateStart, out dateStart) && DateTime.TryParse(_dateEnd, out dateEnd))
                        {
                            _studentReimbursementInfo.ReflectedDate = _cashieringManager.GetReflectedDate(dateStart, dateEnd).ToShortDateString() +
                                " 12:00:00 AM";

                            this.lblReimbursmentReflectedDate.Text = DateTime.Parse(_studentReimbursementInfo.ReflectedDate).ToLongDateString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Recording");
            }
        }//-------------------
        //###########################################END BUTTON btnReimbursement EVENTS#####################################################              

        //###########################################BUTTON btnDeleteReimbursement EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnDeleteReimbursementClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateControlsPaymentReimbursement(false, false))
                {
                    String strMsg = "Are you sure you want to delete the student reimbursements?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student reimbursement has been successfully deleted.";

                        this.Cursor = Cursors.WaitCursor;

                        _cashieringManager.DeleteStudentReimbursements(_userInfo, _studentReimbursementInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = false;

                        this.txtReimbursementAmount.Clear();
                        this.txtReimbursementAmount.Focus();
                        this.txtReimbursementRemarks.Clear();
                        this.chkIsDownPaymentReimbursements.Checked = false;

                        this.InitializeStudentPaymentDiscountReimbursementTable();

                        _cashieringManager.InitializeReimbursementHistoryListView(this.lsvReimbursementHistory, this.tabReimbursement);
                        _cashieringManager.InitializeAmountDueList(this.lsvAmountDueList,
                            _studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.CourseInfo.CourseId, DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd),
                            _cashieringManager.IsSchoolYearForSummer(_cashieringManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)));

                        this.lblRunningBalance.Text = "Running Balance: " + _cashieringManager.GetStudentRunningBalance(_userInfo, _studentInfo.StudentSysId);

                        if (cboYearLevel.SelectedIndex > 0)
                        {
                            _cashieringManager.InitializeStudentChargesListView(this.lsvCurrentCharges,
                                this.lblMenuCurrentCharges, _studentInfo.StudentSysId, true);
                        }

                        DateTime dateStart = DateTime.MinValue;
                        DateTime dateEnd = DateTime.MinValue;

                        if (DateTime.TryParse(_dateStart, out dateStart) && DateTime.TryParse(_dateEnd, out dateEnd))
                        {
                            _studentReimbursementInfo.ReflectedDate = _cashieringManager.GetReflectedDate(dateStart, dateEnd).ToShortDateString() +
                                " 12:00:00 AM";

                            this.lblReimbursmentReflectedDate.Text = DateTime.Parse(_studentReimbursementInfo.ReflectedDate).ToLongDateString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Deleting");
            }
        }//------------------------------
        //###########################################END BUTTON btnDeleteReimbursement EVENTS#####################################################

        //###########################################BUTTON btnUpdateCreditMemo EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnUpdateCreditMemoClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateControlsCreditMemo())
                {
                    String strMsg = "Are you sure you want to update the student credit memo?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student credit memo has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _cashieringManager.UpdateStudentCreditMemo(_userInfo, _studentCreditMemo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = false;

                        this.txtCreditMemoAmount.Clear();
                        this.txtCreditMemoAmount.Focus();
                        this.txtCreditMemoRemarks.Clear();
                        this.chkIsDownpaymentCreditMemo.Checked = false;

                        this.InitializeStudentPaymentDiscountReimbursementTable();

                        _cashieringManager.InitializeCrediMemoHistoryListView(this.lsvCreditMemo, this.tblCreaditMemo);
                        _cashieringManager.InitializeAmountDueList(this.lsvAmountDueList,
                            _studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.CourseInfo.CourseId, DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd),
                            _cashieringManager.IsSchoolYearForSummer(_cashieringManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)));

                        this.lblRunningBalance.Text = "Running Balance: " + _cashieringManager.GetStudentRunningBalance(_userInfo, _studentInfo.StudentSysId);

                        if (cboYearLevel.SelectedIndex > 0)
                        {
                            _cashieringManager.InitializeStudentChargesListView(this.lsvCurrentCharges, 
                                this.lblMenuCurrentCharges, _studentInfo.StudentSysId, true);
                        }

                        DateTime dateStart = DateTime.MinValue;
                        DateTime dateEnd = DateTime.MinValue;

                        if (DateTime.TryParse(_dateStart, out dateStart) && DateTime.TryParse(_dateEnd, out dateEnd))
                        {
                            _studentCreditMemo.ReflectedDate = _cashieringManager.GetReflectedDate(dateStart, dateEnd).ToShortDateString() + " 12:00:00 AM";

                            this.lblCreditMemoReflectedDate.Text = DateTime.Parse(_studentCreditMemo.ReflectedDate).ToLongDateString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Updating");
            }
        }//--------------------
        //###########################################END BUTTON btnUpdateCreditMemo EVENTS#####################################################

        //###########################################BUTTON btnDeleteCreditMemo EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnDeleteCreditMemoClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateControlsCreditMemo())
                {
                    String strMsg = "Are you sure you want to delete the student credit memo?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student credit memo has been successfully Deleted.";

                        this.Cursor = Cursors.WaitCursor;

                        _cashieringManager.DeleteStudentCreditMemo(_userInfo, _studentCreditMemo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = false;

                        this.txtCreditMemoAmount.Clear();
                        this.txtCreditMemoAmount.Focus();
                        this.txtCreditMemoRemarks.Clear();
                        this.chkIsDownpaymentCreditMemo.Checked = false;

                        this.InitializeStudentPaymentDiscountReimbursementTable();

                        _cashieringManager.InitializeCrediMemoHistoryListView(this.lsvCreditMemo, this.tblCreaditMemo);
                        _cashieringManager.InitializeAmountDueList(this.lsvAmountDueList,
                            _studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.CourseInfo.CourseId, DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd),
                            _cashieringManager.IsSchoolYearForSummer(_cashieringManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)));

                        this.lblRunningBalance.Text = "Running Balance: " + _cashieringManager.GetStudentRunningBalance(_userInfo, _studentInfo.StudentSysId);

                        if (cboYearLevel.SelectedIndex > 0)
                        {
                            _cashieringManager.InitializeStudentChargesListView(this.lsvCurrentCharges,
                                this.lblMenuCurrentCharges, _studentInfo.StudentSysId, true);
                        }

                        DateTime dateStart = DateTime.MinValue;
                        DateTime dateEnd = DateTime.MinValue;

                        if (DateTime.TryParse(_dateStart, out dateStart) && DateTime.TryParse(_dateEnd, out dateEnd))
                        {
                            _studentCreditMemo.ReflectedDate = _cashieringManager.GetReflectedDate(dateStart, dateEnd).ToShortDateString() + " 12:00:00 AM";

                            this.lblCreditMemoReflectedDate.Text = DateTime.Parse(_studentCreditMemo.ReflectedDate).ToLongDateString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Deleting");
            }
        }//---------------------------
        //###########################################END BUTTON btnDeleteCreditMemo EVENTS#####################################################

        //###########################################BUTTON btnCreditMemo EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnRecordCreditMemoClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateControlsCreditMemo())
                {
                    String strMsg = "Are you sure you want to record the new student credit memo?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student credit memo has been successfully recorded.";

                        this.Cursor = Cursors.WaitCursor;

                        _cashieringManager.InsertStudentCreditMemo(_userInfo, _studentCreditMemo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = false;

                        this.txtCreditMemoAmount.Clear();
                        this.txtCreditMemoAmount.Focus();
                        this.txtCreditMemoRemarks.Clear();
                        this.chkIsDownpaymentCreditMemo.Checked = false;

                        this.InitializeStudentPaymentDiscountReimbursementTable();

                        _cashieringManager.InitializeCrediMemoHistoryListView(this.lsvCreditMemo, this.tblCreaditMemo);
                        _cashieringManager.InitializeAmountDueList(this.lsvAmountDueList,
                            _studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.CourseInfo.CourseId, DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd),
                            _cashieringManager.IsSchoolYearForSummer(_cashieringManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)));

                        this.lblRunningBalance.Text = "Running Balance: " + _cashieringManager.GetStudentRunningBalance(_userInfo, _studentInfo.StudentSysId);

                        if (cboYearLevel.SelectedIndex > 0)
                        {
                            _cashieringManager.InitializeStudentChargesListView(this.lsvCurrentCharges, 
                                this.lblMenuCurrentCharges, _studentInfo.StudentSysId, true);
                        }

                        DateTime dateStart = DateTime.MinValue;
                        DateTime dateEnd = DateTime.MinValue;

                        if (DateTime.TryParse(_dateStart, out dateStart) && DateTime.TryParse(_dateEnd, out dateEnd))
                        {
                            _studentCreditMemo.ReflectedDate = _cashieringManager.GetReflectedDate(dateStart, dateEnd).ToShortDateString() + " 12:00:00 AM";

                            this.lblCreditMemoReflectedDate.Text = DateTime.Parse(_studentCreditMemo.ReflectedDate).ToLongDateString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Recording");
            }
        }//-----------------
        //###########################################END BUTTON btnCreditMemo EVENTS#####################################################

        //###########################################BUTTON btnRecord EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnRecordDiscountClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateControlsDiscount())
                {
                    String strMsg = "Are you sure you want to record the new student discount?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student discount has been successfully recorded.";

                        this.Cursor = Cursors.WaitCursor;

                        if (_studentScholarshipInfo == null)
                        {
                            _cashieringManager.InsertStudentDiscount(_userInfo, _studentDiscountInfo);
                        }
                        else
                        {
                            _studentScholarshipInfo.StudentEnrolmentLevelInfo = _studentEnrolmentLevelInfo;

                            _cashieringManager.InsertStudentScholarshipInformationStudentDiscount(_userInfo, _studentScholarshipInfo, _studentDiscountInfo);

                            _studentScholarshipInfo = null;
                        }
                        
                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        this.InitializeScholarshipTable();

                        this.InitializeDiscountControl();

                        this.lblRunningBalance.Text = "Running Balance: " + _cashieringManager.GetStudentRunningBalance(_userInfo, _studentInfo.StudentSysId);

                        if (cboYearLevel.SelectedIndex > 0)
                        {
                            _cashieringManager.InitializeStudentChargesListView(this.lsvCurrentCharges, this.lblMenuCurrentCharges,
                                _studentInfo.StudentSysId, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Recording");
            }
        }//---------------------
        //###########################################END BUTTON btnRecord EVENTS#####################################################

        //###########################################BUTTON btnUpdateDiscount EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnUpdateDiscountClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateControlsDiscount())
                {
                    String strMsg = "Are you sure you want to update the student discount?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student discount has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _cashieringManager.UpdateStudentDiscount(_userInfo, _studentDiscountInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        this.InitializeScholarshipTable();

                        this.InitializeDiscountControl();

                        this.InitializeStudentPaymentDiscountReimbursementTable();

                        this.lblRunningBalance.Text = "Running Balance: " + _cashieringManager.GetStudentRunningBalance(_userInfo, _studentInfo.StudentSysId);

                        if (cboYearLevel.SelectedIndex > 0)
                        {
                            _cashieringManager.InitializeStudentChargesListView(this.lsvCurrentCharges, this.lblMenuCurrentCharges, 
                                _studentInfo.StudentSysId, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Recording");
            }
        }//--------------------
        //###########################################BUTTON btnUpdateDiscount EVENTS#####################################################

        //###########################################BUTTON btnDelete EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnDeleteDiscountClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateControlsDiscount())
                {
                    String strMsg = "Are you sure you want to delete the student discount?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student discount has been successfully deleted.";

                        this.Cursor = Cursors.WaitCursor;

                        _cashieringManager.DeleteStudentDiscount(_userInfo, _studentDiscountInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        this.InitializeScholarshipTable();

                        this.InitializeDiscountControl();

                        this.InitializeStudentPaymentDiscountReimbursementTable();

                        this.lblRunningBalance.Text = "Running Balance: " + _cashieringManager.GetStudentRunningBalance(_userInfo, _studentInfo.StudentSysId);

                        if (cboYearLevel.SelectedIndex > 0)
                        {
                            _cashieringManager.InitializeStudentChargesListView(this.lsvCurrentCharges, this.lblMenuCurrentCharges,
                                _studentInfo.StudentSysId, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Recording");
            }
        }//------------------
        ////###########################################END BUTTON btnDelete EVENTS#####################################################

        //###########################################BUTTON btnAdditionalPayment EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnAdditionalPaymentClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateControlsAdditionalFee())
                {
                    String strMsg = "Are you sure you want to record the new student additional fee?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student additional payment has been successfully recorded.";

                        this.Cursor = Cursors.WaitCursor;

                        _cashieringManager.InsertStudentAdditionalFee(_userInfo, _studentAdditionalFeeInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        this.btnAdditionalPayment.Enabled = false;

                        this.InitializeSchoolFeeDetailsTable();

                        this.InitializeAdditionalPaymentControls();

                        this.lblRunningBalance.Text = "Running Balance: " + _cashieringManager.GetStudentRunningBalance(_userInfo, _studentInfo.StudentSysId);
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Recording");
            }
        }//-----------------
        //###########################################END BUTTON btnAdditionalPayment EVENTS#####################################################  

        //###########################################BUTTON btnAdditionalPayment EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnUpdateAdditionalPaymentClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateControlsAdditionalFee())
                {
                    String strMsg = "Are you sure you want to update the student additional payment?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student additional payment has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _cashieringManager.UpdateStudentAdditionalFee(_userInfo, _studentAdditionalFeeInfo, false);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        this.InitializeAdditionalPaymentControls();

                        this.lblRunningBalance.Text = "Running Balance: " + _cashieringManager.GetStudentRunningBalance(_userInfo, _studentInfo.StudentSysId);
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Recording");
            }
        }//------------------------------
        //###########################################END BUTTON btnAdditionalPayment EVENTS#####################################################

        //###########################################BUTTON btnDeleteAdditionalPayment EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnDeleteAdditionalPaymentClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateControlsAdditionalFee())
                {
                    String strMsg = "Are you sure you want to delete the student additional payment?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student additional payment has been successfully deleted.";

                        this.Cursor = Cursors.WaitCursor;

                        _cashieringManager.DeleteStudentAdditionalFee(_userInfo, _studentAdditionalFeeInfo, false);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        this.InitializeAdditionalPaymentControls();

                        this.lblRunningBalance.Text = "Running Balance: " + _cashieringManager.GetStudentRunningBalance(_userInfo, _studentInfo.StudentSysId);
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Recording");
            }
        }//------------------------------
        //###########################################END BUTTON btnDeleteAdditionalPayment EVENTS#####################################################       

        //###########################################BUTTON btnBalanceForwarded EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnRecordBalanceForwardedClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateControlsBalanceForwarded())
                {
                    String strMsg = "Are you sure you want to record the student balance forwarded?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student balance forwarded has been successfully recorded.";

                        this.Cursor = Cursors.WaitCursor;

                        _cashieringManager.InsertStudentBalanceForwarded(_userInfo, _studentBalanceForwardedInfo);

                        _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = false;

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        this.InitializeStudentPaymentDiscountReimbursementTable();

                        this.InitializeStudentBalanceForwardedControls();

                        if (cboYearLevel.SelectedIndex > 0)
                        {
                            _cashieringManager.InitializeStudentChargesListView(this.lsvCurrentCharges, this.lblMenuCurrentCharges,
                                _studentInfo.StudentSysId, true);
                        }

                        this.lblRunningBalance.Text = "Running Balance: " + _cashieringManager.GetStudentRunningBalance(_userInfo, _studentInfo.StudentSysId);
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Recording");
            }
        }//-------------------------------
        //###########################################END BUTTON btnBalanceForwarded EVENTS#####################################################

        //###########################################BUTTON btnDeleteBalanceForwarded EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnDeleteBalanceForwardedClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateControlsBalanceForwarded())
                {
                    String strMsg = "Are you sure you want to delete the student balance forwarded?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student balance forwarded has been successfully deleted.";

                        this.Cursor = Cursors.WaitCursor;

                        _cashieringManager.DeleteStudentBalanceForwarded(_userInfo, _studentBalanceForwardedInfo);

                        _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = false;

                        _studentBalanceForwardedInfo = new CommonExchange.StudentBalanceForwarded();
                        _studentBalanceForwardedInfo.StudentInfo = _studentInfo;

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        this.InitializeStudentPaymentDiscountReimbursementTable();

                        this.txtBalanceForwardedAmount.Clear();
                        this.lblReceivedDateBalanceForwarded.Text = "-";

                        if (cboYearLevel.SelectedIndex > 0)
                        {
                            _cashieringManager.InitializeStudentChargesListView(this.lsvCurrentCharges, this.lblMenuCurrentCharges,
                                _studentInfo.StudentSysId, true);
                        }

                        this.lblRunningBalance.Text = "Running Balance: " + _cashieringManager.GetStudentRunningBalance(_userInfo, _studentInfo.StudentSysId);
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Deleting");
            }
        }//------------------------------
        //###########################################END BUTTON btnDeleteBalanceForwarded EVENTS#####################################################

        //###########################################BUTTON btnMarkedEntryLevel EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnMarkedEntryLevelClick(object sender, EventArgs e)
        {
            try
            {
                String strMsg = "Are you sure you want to update the student enrolment level?";

                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (msgResult == DialogResult.Yes)
                {
                    strMsg = "The student enrollment level is successfully updated.";

                    this.Cursor = Cursors.WaitCursor;

                    _cashieringManager.UpdateStudentEnrollmentLevel(_userInfo, _studentEnrolmentLevelInfo);

                    this.Cursor = Cursors.Arrow;

                    MessageBox.Show(strMsg, "Success");

                    this.Cursor = Cursors.WaitCursor;

                    this.cboYearLevel.Items.Clear();
                    _cashieringManager.InitializedCourseCombo(this.cboCourse,
                        _cashieringManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex), true);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Updating Student Enrolment Level", "Error Deleting");
            }
        }//---------------------------
        //###########################################END BUTTON btnMarkedEntryLevel EVENTS#####################################################

        //###########################################PICTUREBOX pbxOptionalFee EVENTS#####################################################
        //event is raised when the control is clicked
        private void pbxOptionalFeeClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (OptinalFeeSearchOnTextBoxList frmSearch = new OptinalFeeSearchOnTextBoxList(_cashieringManager))
                {
                    frmSearch.AdoptGridSize = true;
                    frmSearch.ShowDialog(this);

                    if (frmSearch.HasSelected)
                    {
                        _cashieringManager.InsertOptionalFee(frmSearch.PrimaryId, _studentEnrolmentLevelInfo.EnrolmentLevelSysId);

                        _hasUpdatedOptionalFee = true;
                        
                        _cashieringManager.InitializeStudentChargesListView(this.lsvCurrentCharges, this.lblMenuCurrentCharges, _studentInfo.StudentSysId, true);
                        _cashieringManager.InitializeAmountDueList(this.lsvAmountDueList,
                            _studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.CourseInfo.CourseId, DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd),
                            _cashieringManager.IsSchoolYearForSummer(_cashieringManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)));
                    }
                }

                this.Cursor = Cursors.Arrow;
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Optional Fee Search Module.", "Error Loading");
            }
        }//------------------------
        //###########################################END PICTUREBOX pbxOptionalFee EVENTS#####################################################

        //###########################################LINKLABEL lnkDeleteOptionalFee EVENTS#####################################################
        //event is raised when the control is clicked
        private void lnkDeleteOptionalFeeClick(object sender, EventArgs e)
        {
            try
            {
                String strMsg = "Are you sure you whant to delete [" + _cashieringManager.GetParticularDescription(_sysIdFeeDetails) + "]";

                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.Yes)
                {
                    _cashieringManager.DeleteOptionalFee(_optionalFeeId);

                    _hasUpdatedOptionalFee = true;
                   
                    _cashieringManager.InitializeStudentChargesListView(this.lsvCurrentCharges, this.lblMenuCurrentCharges, _studentInfo.StudentSysId, true);
                    _cashieringManager.InitializeAmountDueList(this.lsvAmountDueList,
                        _studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.CourseInfo.CourseId, DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd),
                        _cashieringManager.IsSchoolYearForSummer(_cashieringManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)));
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Deleting");
            }
        }//-------------------------
        //###########################################END BUTTON lnkDeleteOptionalFee EVENTS#####################################################
        
        //###########################################BUTTON btnRecordOptionalFee EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnRecordOptionalFeeClick(object sender, EventArgs e)
        {
            try
            {
                String strMsg = "Are you sure you want to record the new student optional fee?";

                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);

                if (msgResult == DialogResult.Yes)
                {
                    strMsg = "The student optional fee has been successfully recorded.";

                    this.Cursor = Cursors.WaitCursor;

                    _cashieringManager.InsertDeleteOptionalFee(_userInfo);

                    _hasUpdatedOptionalFee = false;

                    this.Cursor = Cursors.Arrow;

                    MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    this.lblRunningBalance.Text = "Running Balance: " + _cashieringManager.GetStudentRunningBalance(_userInfo, _studentInfo.StudentSysId);
                }  
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Recording");
            }
        }//----------------------------
        //###########################################END BUTTON btnRecordOptionalFee EVENTS#####################################################

        //###########################################BUTTON btnEnrolmentHistroy EVENTS#####################################################
        //event is raised when the control is clicked
        private void pbxEnrolmentLevelClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (StudentEnrolmentHistoryView frmHistory = new StudentEnrolmentHistoryView(_cashieringManager))
                {
                    frmHistory.ShowDialog();
                }

                this.Cursor = Cursors.Arrow;
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Enrolment History Module.", "Error Loading");
            }
        }//------------------------
        //###########################################END BUTTON btnEnrolmentHistroy EVENTS#####################################################

        //###########################################BUTTON pbxLegend EVENTS#####################################################
        //event is raised when the control is clicked
        private void pbxLegendClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (BaseServices.SubjectLegend frmShow = new BaseServices.SubjectLegend())
                {
                    frmShow.ShowDialog(this);
                }

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Subject Schedule Type Module.\n\n" + ex.Message, "Error Loading");
            }
        }//----------------------
        //###########################################END BUTTON pbxLegend EVENTS#####################################################

        //###########################################BUTTON pbxPrintStatementOfAccount EVENTS#####################################################
        //event is raised when the control is clicked
        private void pbxPrintStatementOfAccountClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _cashieringManager.SelectMajorExamScheduleTableForPrinting(_userInfo, _dateStart, _dateEnd,
                    _studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.CourseInfo.CourseGroupInfo.CourseGroupId);

                using (MajorExamSchedule frmPrint = new MajorExamSchedule(_userInfo, _cashieringManager))
                {
                    frmPrint.ShowDialog(this);

                    if (frmPrint.HasClickedPrint)
                    {
                        String sem = String.IsNullOrEmpty(this.cboSemester.Text) ? String.Empty : " - " + this.cboSemester.Text;

                        _cashieringManager.PrintStudentStatementOfAccount(_userInfo, _studentInfo.StudentSysId, this.cboYear.Text + sem,
                            _studentEnrolmentLevelInfo.EnrolmentLevelSysId, _studentEnrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId, 
                            _strEnrolmentCourseSysId, DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd),
                            _cashieringManager.IsSchoolYearForSummer(_cashieringManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)));
                    }
                }

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }
        }//-----------------------
        //###########################################END BUTTON pbxPrintStatementOfAccount EVENTS#####################################################

        //###########################################BUTTON pbxPrintStatementOfAccountSummary EVENTS#####################################################
        //event is raised when the control is clicked
        private void pbxPrintStatementOfAccountSummaryClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                String sem = this.cboSemester.SelectedIndex != - 1 ? " - " + this.cboSemester.Text : String.Empty;

                _cashieringManager.PrintStudentPaymentSummary(RemoteClient.ProcStatic.GetCompleteNameFullMiddleName(_studentInfo.PersonInfo.LastName,
                    _studentInfo.PersonInfo.FirstName, _studentInfo.PersonInfo.MiddleName), _studentInfo.StudentId,
                    _courseTitle,
                    _studentEnrolmentLevelInfo.SchoolFeeLevelInfo.YearLevelInfo.YearLevelDescription, this.cboYear.Text + sem);

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }
        }//-----------------------
        //###########################################END BUTTON pbxPrintStatementOfAccountSummary EVENTS#####################################################

        //###########################################LINKLABEL lnkReceivedDate EVENTS#####################################################
        //event is raised when the control is clicked
        private void lnkReceivedDateLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            DateTime rDate = DateTime.MinValue;

            if (String.IsNullOrEmpty(_studentPromissoryNoteInfo.ReflectedDate))
            {
                rDate = DateTime.Parse(_cashieringManager.ServerDateTime);
            }
            else
            {
                rDate = DateTime.Parse(_studentPromissoryNoteInfo.ReflectedDate);
            }

            using (RemoteClient.DatePicker frmPicker = new RemoteClient.DatePicker(rDate))
            {
                frmPicker.ShowDialog(this);

                if (frmPicker.HasSelectedDate)
                {
                    if (DateTime.TryParse(frmPicker.GetSelectedDate.ToLongDateString() + " " +
                            DateTime.Parse(_cashieringManager.ServerDateTime).ToLongTimeString(), out rDate))
                    {
                        _studentPromissoryNoteInfo.ReflectedDate = rDate.ToShortDateString() + " 12:00:00 AM";

                        _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = true;                        
                    }

                    this.txtReceivedDate.Text = rDate.ToLongDateString();

                    this.IsRecordLocked(DateTime.Parse(_studentPromissoryNoteInfo.ReceivedDate), false, false, false, true, false);
                }
            }

            this.Cursor = Cursors.Arrow;
        }//----------------------
        //###########################################END LINKLABEL lnkReceivedDate EVENTS#####################################################          

        //###########################################TEXTBOX txtPromissoryNote EVENTS#####################################################
        //event is raised when the control is clicked
        private void txtPromissoryNoteValidated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(RemoteClient.ProcStatic.TrimStartEndString(this.txtPromissoryNote.Text)) &&
                !String.Equals(_studentPromissoryNoteInfo.PromissoryNote, RemoteClient.ProcStatic.TrimStartEndString(this.txtPromissoryNote.Text)))
                _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = true;

            _studentPromissoryNoteInfo.PromissoryNote = RemoteClient.ProcStatic.TrimStartEndString(this.txtPromissoryNote.Text);
        }//----------------------
        //###########################################END TEXTBOX txtPromissoryNote EVENTS#####################################################

        //###########################################TEXTBOX txtReferenceNo EVENTS#####################################################
        //event is raised when the control is clicked
        private void txtReferenceNoValidated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(RemoteClient.ProcStatic.TrimStartEndString(this.txtReferenceNo.Text)) &&
                !String.Equals(_studentPromissoryNoteInfo.ReferenceNo, RemoteClient.ProcStatic.TrimStartEndString(this.txtReferenceNo.Text)))
                _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = true;

            _studentPromissoryNoteInfo.ReferenceNo = RemoteClient.ProcStatic.TrimStartEndString(this.txtReferenceNo.Text);
        }//------------------------
        //###########################################END TEXTBOX txtReferenceNo EVENTS#####################################################

        //###########################################BUTTON btnRecordPromissoryNote EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnRecordPromissoryNoteClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateControlsStudentPromissoryNote())
                {
                    String strMsg = "Are you sure you want to record the new student promissory note?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student promissory note has been successfully recorded.";

                        this.Cursor = Cursors.WaitCursor;

                        _cashieringManager.InsertStudentPromissoryNote(_userInfo, _studentPromissoryNoteInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = false;

                        _cashieringManager.SelectBySysIDStudentListDateStartEndStudentPromissoryNote(_userInfo, _studentInfo.StudentSysId, _dateStart, _dateEnd);

                        _cashieringManager.InitializeStudentPromissoryNoteListView(this.lsvPromissoryNote,
                            _studentPromissoryNoteInfo.StudentInfo.StudentSysId, this.tabPromissory);

                        this.InitializeStudentPromissoryNoteControls();

                        this.lblRunningBalance.Text = "Running Balance: " + _cashieringManager.GetStudentRunningBalance(_userInfo, _studentInfo.StudentSysId);
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Recording");
            }
        }//-----------------
        //###########################################END BUTTON btnRecordPromissoryNote EVENTS#####################################################

        //###########################################BUTTON btnUpdatePromissoryNote EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnUpdatePromissoryNoteClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateControlsStudentPromissoryNote())
                {
                    String strMsg = "Are you sure you want to update the student promissory note?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student promissory note has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _cashieringManager.UpdateStudentPromissoryNote(_userInfo, _studentPromissoryNoteInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = false;

                        _cashieringManager.SelectBySysIDStudentListDateStartEndStudentPromissoryNote(_userInfo, _studentInfo.StudentSysId, _dateStart, _dateEnd);

                        _cashieringManager.InitializeStudentPromissoryNoteListView(this.lsvPromissoryNote,
                            _studentPromissoryNoteInfo.StudentInfo.StudentSysId, this.tabPromissory);

      
                        this.InitializeStudentPromissoryNoteControls();

                        this.lblRunningBalance.Text = "Running Balance: " + _cashieringManager.GetStudentRunningBalance(_userInfo, _studentInfo.StudentSysId);
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Updating");
            }
        }//----------------------
        //###########################################END BUTTON btnUpdatePromissoryNote EVENTS#####################################################

        //###########################################BUTTON btnDeletePromissoryNote EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnDeletePromissoryNoteClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateControlsStudentPromissoryNote())
                {
                    String strMsg = "Are you sure you want to delete the student promissory note?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student promissory note has been successfully deleted.";

                        this.Cursor = Cursors.WaitCursor;

                        _cashieringManager.DeleteStudentPromissoryNote(_userInfo, _studentPromissoryNoteInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = false;

                        _cashieringManager.SelectBySysIDStudentListDateStartEndStudentPromissoryNote(_userInfo, _studentInfo.StudentSysId, _dateStart, _dateEnd);

                        _cashieringManager.InitializeStudentPromissoryNoteListView(this.lsvPromissoryNote,
                            _studentPromissoryNoteInfo.StudentInfo.StudentSysId, this.tabPromissory);

                        this.InitializeStudentPromissoryNoteControls();

                        this.lblRunningBalance.Text = "Running Balance: " + _cashieringManager.GetStudentRunningBalance(_userInfo, _studentInfo.StudentSysId);
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Deleting");
            }
        }//------------------------
        //###########################################END BUTTON btnDeletePromissoryNote EVENTS#####################################################

        //###########################################LISTVIEW lsvPromissoryNote EVENTS#####################################################
        //event is raised when the control is double clicked
        private void lsvPromissoryNoteMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((this.lsvPromissoryNote.Items.Count > 0 && this.lsvPromissoryNote.FocusedItem != null) && this.lsvPromissoryNote.GetItemAt(e.X, e.Y) != null)
            {
                _studentPromissoryNoteInfo = _cashieringManager.GetStudentPromissoryNote(this.lsvPromissoryNote.GetItemAt(e.X, e.Y).Text);

                this.txtReceivedDate.Text = DateTime.Parse(_studentPromissoryNoteInfo.ReflectedDate).ToLongDateString();
                this.txtReferenceNo.Text = _studentPromissoryNoteInfo.ReferenceNo;
                this.txtPromissoryNote.Text = _studentPromissoryNoteInfo.PromissoryNote;
                this.chkIsDownPaymentPromissoryNote.Checked = _studentPromissoryNoteInfo.IsDownpayment;

                this.btnRecordPromissoryNote.Enabled = false;
                this.btnUpdatePromissoryNote.Enabled = this.btnDeletePromissoryNote.Enabled = true;

                this.IsRecordLocked(DateTime.Parse(_studentPromissoryNoteInfo.ReceivedDate), false, false, false, true, false);

                _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = true;
            }
        }//----------------------
        //###########################################END LISTVIEW lsvPromissoryNote EVENTS#####################################################

        //###########################################LABEL lblCreditMemo EVENTS###############################################################
        //event is raised when the control is clicked
        private void lblCreditMemoReflectedDateClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            DateTime memoDate = DateTime.MinValue;

            if (String.IsNullOrEmpty(_studentCreditMemo.ReflectedDate))
            {
                memoDate = DateTime.Parse(_cashieringManager.ServerDateTime);
            }
            else
            {
                memoDate = DateTime.Parse(_studentCreditMemo.ReflectedDate);
            }

            using (RemoteClient.DatePicker frmPicker = new RemoteClient.DatePicker(memoDate))
            {
                frmPicker.ShowDialog(this);

                if (frmPicker.HasSelectedDate)
                {
                    if (DateTime.TryParse(frmPicker.GetSelectedDate.ToLongDateString() + " " +
                            DateTime.Parse(_cashieringManager.ServerDateTime).ToLongTimeString(), out memoDate))
                    {
                        _studentCreditMemo.ReflectedDate = memoDate.ToShortDateString() + " 12:00:00 AM";

                        _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = true;
                    }

                    this.lblCreditMemoReflectedDate.Text = memoDate.ToLongDateString();

                    this.IsRecordLocked(DateTime.Parse(_studentCreditMemo.ReceivedDate), false, false, true, false, false);
                }
            }

            this.Cursor = Cursors.Arrow;
        }//----------------------
        //###########################################LABEL lblCreditMemo EVENTS#####################################################

        //###########################################LABEL lblDiscountReflectedDate EVENTS#####################################################
        //event is raised when the control is clicked
        private void lblDiscountReflectedDateClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            DateTime discountReflectedDate = DateTime.MinValue;

            if (String.IsNullOrEmpty(_studentDiscountInfo.ReflectedDate))
            {
                discountReflectedDate = DateTime.Parse(_cashieringManager.ServerDateTime);
            }
            else
            {
                discountReflectedDate = DateTime.Parse(_studentDiscountInfo.ReflectedDate);
            }

            using (RemoteClient.DatePicker frmPicker = new RemoteClient.DatePicker(discountReflectedDate))
            {
                frmPicker.ShowDialog(this);

                if (frmPicker.HasSelectedDate)
                {
                    if (DateTime.TryParse(frmPicker.GetSelectedDate.ToLongDateString() + " " +
                            DateTime.Parse(_cashieringManager.ServerDateTime).ToLongTimeString(), out discountReflectedDate))
                    {
                        _studentDiscountInfo.ReflectedDate = discountReflectedDate.ToShortDateString() + " 12:00:00 AM";

                        _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = true;
                    }

                    this.lblDiscountReflectedDate.Text = discountReflectedDate.ToLongDateString();

                    this.IsRecordLocked(DateTime.Parse(_studentDiscountInfo.ReceivedDate), false, false, false, false, true);

                    if (!_cashieringManager.IsWithInTheRangeOfSchoolYearSemeterDefined(discountReflectedDate))
                    {
                        this.btnRecordDiscount.Enabled = this.btnUpdateDiscount.Enabled =
                                this.btnDeleteDiscount.Enabled = _isDiscountRecordOpen = false;

                        this.lblStatusDiscount.Text = "This record is LOCKED";

                        this.txtDiscountAmount.ReadOnly = true;

                        this.pbxLockedDiscount.Visible = true;
                        this.pbxUnlockDiscount.Visible = false;

                        this.lsvDiscount.MouseDoubleClick -= new MouseEventHandler(lsvDiscountMouseDoubleClick);
                    }
                }
            }

            this.Cursor = Cursors.Arrow;
        }//------------------------
        //###########################################END LABEL lblDiscountReflectedDate EVENTS#####################################################

        //###########################################LABEL lblReimbursment EVENTS#####################################################
        //event is raised when the control is clicked
        private void lblReimbursmentReflectedDateClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            DateTime reimDate = DateTime.MinValue;

            if (String.IsNullOrEmpty(_studentReimbursementInfo.ReflectedDate))
            {
                reimDate = DateTime.Parse(_cashieringManager.ServerDateTime);
            }
            else
            {
                reimDate = DateTime.Parse(_studentReimbursementInfo.ReflectedDate);
            }

            using (RemoteClient.DatePicker frmPicker = new RemoteClient.DatePicker(reimDate))
            {
                frmPicker.ShowDialog(this);

                if (frmPicker.HasSelectedDate)
                {
                    if (DateTime.TryParse(frmPicker.GetSelectedDate.ToLongDateString() + " " +
                            DateTime.Parse(_cashieringManager.ServerDateTime).ToLongTimeString(), out reimDate))
                    {
                        _studentReimbursementInfo.ReflectedDate = reimDate.ToShortDateString() + " 12:00:00 AM";

                        _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = true;
                    }

                    this.lblReimbursmentReflectedDate.Text = reimDate.ToLongDateString();

                    this.IsRecordLocked(DateTime.Parse(_studentReimbursementInfo.ReceivedDate), false, true, false, false, false);
                }
            }

            this.Cursor = Cursors.Arrow;
        }//----------------------
        //###########################################END LABEL lblReimbursment EVENTS#####################################################

        //###########################################LABEL lblPaymentReflectedDate EVENTS#####################################################
        //event is raised when the control is clicked
        private void lblPaymentReflectedDateClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            DateTime paymentDate = DateTime.MinValue;

            if (String.IsNullOrEmpty(_studentPaymentInfo.ReflectedDate))
            {
                paymentDate = DateTime.Parse(_cashieringManager.ServerDateTime);
            }
            else
            {
                paymentDate = DateTime.Parse(_studentPaymentInfo.ReflectedDate);
            }

            using (RemoteClient.DatePicker frmPicker = new RemoteClient.DatePicker(paymentDate))
            {
                frmPicker.ShowDialog(this);

                if (frmPicker.HasSelectedDate)
                {
                    if (DateTime.TryParse(frmPicker.GetSelectedDate.ToLongDateString() + " " +
                            DateTime.Parse(_cashieringManager.ServerDateTime).ToLongTimeString(), out paymentDate))
                    {
                        _studentPaymentInfo.ReflectedDate = paymentDate.ToShortDateString() + " 12:00:00 AM";

                        _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = true;

                        if (DateTime.Compare(paymentDate, DateTime.Parse(_studentPaymentInfo.ReceivedDate)) != 0)
                        {
                            _studentPaymentInfo.AccountCreditInfo.AccountSysId = String.Empty;

                            this.txtCreditEntry.Text = String.Empty;
                        }
                    }
                    
                    this.lblPaymentReflectedDate.Text = paymentDate.ToLongDateString();

                    this.IsRecordLocked(DateTime.Parse(_studentPaymentInfo.ReceivedDate), true, false, false, false, false);
                }
            }
            
            this.Cursor = Cursors.Arrow;
        }//--------------------
        //###########################################END LABEL lblPaymentReflectedDate EVENTS#####################################################

        //###########################################LABEL lblReceiptDate EVENTS#####################################################
        //event is raised when the control is clicked
        private void lblReceiptDateClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            DateTime receiptDate = DateTime.MinValue;

            if (String.IsNullOrEmpty(_studentPaymentInfo.ReceiptDate))
            {
                receiptDate = DateTime.Parse(CashieringLogic.ReceiptDate);
            }
            else
            {
                receiptDate = DateTime.Parse(_studentPaymentInfo.ReceiptDate);
            }

            using (RemoteClient.DatePicker frmPicker = new RemoteClient.DatePicker(receiptDate))
            {
                frmPicker.ShowDialog(this);

                if (frmPicker.HasSelectedDate)
                {
                    if (DateTime.TryParse(frmPicker.GetSelectedDate.ToLongDateString() + " " +
                            DateTime.Parse(_cashieringManager.ServerDateTime).ToLongTimeString(), out receiptDate))
                    {
                        _studentPaymentInfo.ReceiptDate = receiptDate.ToShortDateString() + " 12:00:00 AM";

                        _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = true;
                    }

                    this.lblReceiptDate.Text = receiptDate.ToLongDateString();

                    this.IsRecordLocked(DateTime.Parse(_studentPaymentInfo.ReceiptDate), DateTime.Parse(_studentPaymentInfo.ReceivedDate));
                }
            }

            this.Cursor = Cursors.Arrow;
        }//------------------
        //###########################################END LABEL lblReceiptDate EVENTS#####################################################

        //###########################################LINK LABEL lnkWithdrawSubject EVENTS#####################################################
        //event is raised when the control is clicked
        private void lnkWithdrawSubjectClick(object sender, EventArgs e)
        {
            try
            {
                String strMsg = "Are you sure you want to permanently withdraw " + _cashieringManager.GetSubjectCodeTitle(_sysIdSubjectSchedule) + " ?";

                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Withdraw", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.Yes)
                {
                    _cashieringManager.DeleteSubjectSchedulePermanetly(_userInfo, _studentEnrolmentLevelInfo, _sysIdSubjectSchedule);

                    MessageBox.Show("You have successfully withdrawn the subject.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _cashieringManager.SelectBySysIDEnrolmentLevelDateStartEndSubjectScheduleStudentLoad(_userInfo, _studentInfo.StudentSysId,
                        _studentEnrolmentLevelInfo.EnrolmentLevelSysId, _studentEnrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId,
                        _cashieringManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex),
                       _studentEnrolmentLevelInfo.IsGraduateStudent, _studentEnrolmentLevelInfo.IsInternational,
                       _cashieringManager.IsEnrolled(this.cboYearLevel.SelectedIndex), _dateStart, _dateEnd);

                    _cashieringManager.InitializeStudentChargesListView(this.lsvCurrentCharges, this.lblMenuCurrentCharges, _studentInfo.StudentSysId, true);
                    _cashieringManager.InitializeSubjectLoadListView(this.lsvSubjectLoad, this.lblSubjectTaken, this.tabSubjectTaken);
                    _cashieringManager.InitializeWithdrawSubjectLoadListView(this.lsvWithdrawnSubjects, this.lblWithdrawSubjects, this.tabWithdrawnSubjects);
                }
            }
            catch (Exception ex)
            { 
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Deloading");
            }
        }//-----------------------
        //###########################################END LINK LABEL lnkWithdrawSubject EVENTS#####################################################

        //###########################################LINK LABEL lnkWithdrawSpecialClass EVENTS#####################################################
        //event is raised when the control is clicked
        private void lnkWithdrawSpecialClassClick(object sender, EventArgs e)
        {
            try
            {
                String strMsg = "Are you sure you want to permanently withdraw " + _cashieringManager.GetSpecialClassCodeTitle(_sysIdSpecialClass) + " ?";

                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Withdraw", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.Yes)
                {
                    _cashieringManager.DeleteSpecialClassInformation(_userInfo, _cashieringManager.GetSpecialClassLoadId(_sysIdSpecialClass));

                    MessageBox.Show("You have successfully withdrawn the special class.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _cashieringManager.SelectBySysIDStudentListDateStartEndSpecialClassInformation(_userInfo, _studentInfo.StudentSysId,
                        _dateStart, _dateEnd);

                    _cashieringManager.SelectBySysIDEnrolmentLevelDateStartEndSubjectScheduleStudentLoad(_userInfo, _studentInfo.StudentSysId,
                        _studentEnrolmentLevelInfo.EnrolmentLevelSysId, _studentEnrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId,
                        _cashieringManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex),
                       _studentEnrolmentLevelInfo.IsGraduateStudent, _studentEnrolmentLevelInfo.IsInternational,
                       _cashieringManager.IsEnrolled(this.cboYearLevel.SelectedIndex), _dateStart, _dateEnd);                    

                    _cashieringManager.InitializeStudentChargesListView(this.lsvCurrentCharges, this.lblMenuCurrentCharges, _studentInfo.StudentSysId, true);
                    _cashieringManager.InitializeSpecialClassLoadedWithdrawnListView(this.lsvSpecialClass, this.lblSpeicalClass, this.tabSpecialClass, false);
                    _cashieringManager.InitializeSpecialClassLoadedWithdrawnListView(this.lsvWithdrawnSpecialClass,
                        this.lblWithdrawnSpecialClass, this.tabWithdrawnSpecialClass, true);
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Deloading");
            }
        }//----------------------
        //###########################################END LINK LABEL lnkWithdrawSpecialClass EVENTS#####################################################

        //###########################################LINK LABEL lnkReIssueLink EVENTS#####################################################
        //event is raised when the control is clicked
        private void lnkReIssueLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (this.ValidateControlsPaymentReimbursement(true, true))
                {
                    this.Cursor = Cursors.WaitCursor;

                    String strMsg = "Re-Issue/Re-Printing this receipt will automatically cancel this receipt number and update" +
                        " this payment with the new receipt number [" + RemoteClient.ProcStatic.SixDigitZero(CashieringLogic.ReceiptNumber).ToString() +
                        "]\n\nAre you sure you whant to Re-Issue/Re-Print?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Re-Issue/Re-Print", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        using (ReceiptInformationCancelRecord frmRecord =
                            new ReceiptInformationCancelRecord(_userInfo, _cashieringManager, _studentPaymentInfo, _studentInfo, _dateEnd))
                        {
                            frmRecord.IsFromReIssued = true;

                            frmRecord.ShowDialog(this);

                            if (frmRecord.HasRecorded)
                            {
                                _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = false;

                                this.txtPaymentAmount.Clear();
                                this.txtPaymentAmount.Focus();
                                this.txtReceipNo.Text = RemoteClient.ProcStatic.SixDigitZero(CashieringLogic.ReceiptNumber);
                                this.txtPaymentRemarks.Clear();
                                this.txtDiscountedAmount.Clear();
                                this.chkIsDownPaymentPayment.Checked = false;
                                this.chkIsMiscellaneousIncome.Checked = false;

                                this.btnDeletePayment.Enabled = this.btnUpdatePayment.Enabled = this.lnkReIssue.Enabled = false;
                                this.btnPayment.Enabled = true;

                                this.InitializeStudentPaymentDiscountReimbursementTable();

                                _cashieringManager.InitializePaymentHistroyListView(this.lsvPaymentHistory, tabPaymentHistory);
                            }
                        }
                    }

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error loading receipt information module./n/n" + ex.Message, "Error Loading");
            }
        }//------------------------
        //###########################################END LINK LABEL lnkReIssueLink EVENTS#####################################################

        //###########################################LINK LABEL lnkRePrint EVENTS#####################################################
        //event is raised when the control is clicked
        private void lnkRePrintClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CommonExchange.StudentPayments tempStudentPaymentInfo = new CommonExchange.StudentPayments();

                tempStudentPaymentInfo = _cashieringManager.GetDetailsStudentPayment(_studentPaymentId);

                long wholeNum = _cashieringManager.GetWholeNumberTenthDecimal(tempStudentPaymentInfo.Amount, true);
                int decNum = (int)_cashieringManager.GetWholeNumberTenthDecimal(tempStudentPaymentInfo.Amount, false);

                _cashieringManager.PrintReceiptNumberStudentPayments(_userInfo, tempStudentPaymentInfo, _studentInfo, _dateEnd,
                    _cashieringManager.GetEnrolmentCourseAcronym(_strEnrolmentCourseSysId) , wholeNum, decNum);

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Printing");
            }
        }//-------------------------
        //###########################################END LINK LABEL lnkRePrint EVENTS#####################################################
        #endregion

        #region Programer-Defined Procedures
        //this procedure will initialize stuent charges tab
        private void InitializeStudentChargesTab()
        {
            this.tabCurrentCharges.Text = "Current Charges  (F4) ";
            this.tabWithdrawCharges.Text = "Charges Before Withdrawal  (F5)";
            this.tabSubjectTaken.Text = "Subject Taken  (F6)";
            this.tabWithdrawnSubjects.Text = "Withdrawn Subject  (F7)";
            this.tabAdditionalFee.Text = "Additional Fee  (F8)";
            this.tabDiscounts.Text = "Discounts  (F9)";
            this.tabSpecialClass.Text = "Special Class   (F10)";
            this.tabWithdrawnSpecialClass.Text = "Withdrawn Special Class   (F11)";
        }//-------------------------

        //this procedure initialize student enrolment level
        private void InitializeStudentEnrolmentLevelTable(String sysIdSemester)
        {
            //String enrolmentLevelSysIdExcludeList = (RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) &&
            //    !String.IsNullOrEmpty(_studentEnrolmentLevelInfo.EnrolmentLevelSysId)) ? _studentEnrolmentLevelInfo.EnrolmentLevelSysId : String.Empty;

            _cashieringManager.SelectBySysIDStudentYearIDSemesterStudentEnrolmentLevel(_userInfo, _studentInfo.StudentSysId,
              _cashieringManager.GetSchoolYearYearId(this.cboYear.SelectedIndex), sysIdSemester, _strEnrolmentCourseSysId, String.Empty);
        }//----------------------------

        //this procedure will initialized student payment discount reimbursement
        private void InitializeStudentPaymentDiscountReimbursementTable()
        {
            if (!String.IsNullOrEmpty(_dateStart) && !String.IsNullOrEmpty(_dateEnd))
            {
                _cashieringManager.SelectBySysIDStudentListDateStartEndStudentPaymentsDiscountsReimbursement(_userInfo, _studentInfo.StudentSysId,
                  _dateStart, _dateEnd);
            }
        }//---------------------------

        //this procedure will initialize school fee details
        private void InitializeSchoolFeeDetailsTable()
        {
            if (!String.IsNullOrEmpty(_dateStart) && !String.IsNullOrEmpty(_dateEnd))
            {
                _cashieringManager.SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoadCharges(_userInfo, _studentInfo.StudentSysId,
                   _studentEnrolmentLevelInfo.EnrolmentLevelSysId, _studentEnrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId,
                   _cashieringManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex),
                  _studentEnrolmentLevelInfo.IsGraduateStudent, _studentEnrolmentLevelInfo.IsInternational,
                  true, _studentEnrolmentLevelInfo.IsMarkedDeleted, false, true);

                if (_studentEnrolmentLevelInfo.IsMarkedDeleted)
                {
                    _cashieringManager.SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoadCharges(_userInfo, _studentInfo.StudentSysId,
                         _studentEnrolmentLevelInfo.EnrolmentLevelSysId, _studentEnrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId,
                         _cashieringManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex),
                         _studentEnrolmentLevelInfo.IsGraduateStudent, _studentEnrolmentLevelInfo.IsInternational,
                          true, false, true, false);
                }
            }
        }//-------------------------

        //this procedure will initialize student promissory note controls
        private void InitializeStudentPromissoryNoteControls()
        {
            this.btnUpdatePromissoryNote.Enabled = this.btnDeletePromissoryNote.Enabled = false;
            this.btnRecordPromissoryNote.Enabled = true;

            this.txtReceivedDate.Clear();
            this.txtReferenceNo.Clear();
            this.txtPromissoryNote.Clear();
            this.chkIsDownPaymentPromissoryNote.Checked = false;

            this.txtReferenceNo.ReadOnly = this.txtPromissoryNote.ReadOnly = false;

            _studentPromissoryNoteInfo.ReflectedDate = String.Empty;
            _studentPromissoryNoteInfo.PromissoryNote = String.Empty;
            _studentPromissoryNoteInfo.ReferenceNo = String.Empty;
        }//------------------------

        //this procedure will initialize additional payment controls
        private void InitializeAdditionalPaymentControls()
        {
            this.lblParticularDescription.Text = "-";
            this.txtAdditionalPaymentAmount.Clear();
            this.txtAdditionalFeeRemarks.Clear();
            this.txtAdditionalPaymentAmount.Focus();

            this.btnUpdateAdditionalPayment.Enabled = this.btnDeleteAdditionalPayment.Enabled = false;

            this.btnSearchAdditionalFee.Visible = true;

            _studentAdditionalFeeInfo = new CommonExchange.StudentAdditionalFee();

            _studentAdditionalFeeInfo.StudentEnrolmentLevelInfo.EnrolmentLevelSysId = _studentEnrolmentLevelInfo.EnrolmentLevelSysId;

            this.InitializeStudentPaymentDiscountReimbursementTable();

            _cashieringManager.InitializeStudentChargesListView(this.lsvCurrentCharges, this.lblMenuCurrentCharges, _studentInfo.StudentSysId, true);

            if (_studentEnrolmentLevelInfo.IsMarkedDeleted)
                _cashieringManager.InitializeStudentChargesListView(this.lsvWithdrawCharges, this.lblWithdrawCharges, _studentInfo.StudentSysId, false);

            _cashieringManager.InitializeAdditionalFeeListView(this.lsvAdditionalPayment, this.tabAdditionalFee);
            _cashieringManager.InitializeAmountDueList(this.lsvAmountDueList,
                _studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.CourseInfo.CourseId, DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd),
                _cashieringManager.IsSchoolYearForSummer(_cashieringManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)));

            _hasUpdatedAdditionalFee = false;
        }//--------------------------

        //this procedure will initialize scholarship table
        private void InitializeScholarshipTable()
        {
            _cashieringManager.SelectBySysIDEnrolmentLevelStudentScholarship(_userInfo, _studentEnrolmentLevelInfo.EnrolmentLevelSysId);
        }//------------------------

        //this procedure initialize student loading controls
        private void InitializeStudentControls(Boolean isForYearSemester)
        {
            _strForReceiptDescription = String.Empty;
            this.lsvCurrentCharges.Items.Clear();
            this.lsvWithdrawCharges.Items.Clear();
            this.lsvAdditionalPayment.Items.Clear();

            if (isForYearSemester)
            {
                this.lsvPaymentHistory.Items.Clear();
                this.lsvReimbursementHistory.Items.Clear();
                this.lsvCreditMemo.Items.Clear();
            }

            this.lsvSubjectLoad.Items.Clear();
            this.lsvWithdrawnSubjects.Items.Clear();
            this.lsvDiscount.Items.Clear();
            this.lsvAmountDueList.Items.Clear();

            this.txtPaymentAmount.Clear();
            this.txtDiscountedAmount.Clear();
            this.txtReimbursementAmount.Clear();
            this.txtAdditionalPaymentAmount.Clear();
            this.txtPaymentRemarks.Clear();
            this.txtReimbursementRemarks.Clear();

            this.lblParticularDescription.Text = this.lblMenuCurrentCharges.Text = this.lblWithdrawCharges.Text = "-";
            this.chkIsGraduating.Checked = this.chkIsInternational.Checked = this.tblCharges.Enabled = false;
        }//-------------------------

        //this procedure will initialize student balance forwarded
        private void InitializeStudentBalanceForwardedControls()
        {
            DateTime balanceForwardedReceivedDate = DateTime.MinValue;

            _studentBalanceForwardedInfo = _cashieringManager.GetDetailsStudentBalanceForwarded(ref balanceForwardedReceivedDate);
            _studentBalanceForwardedInfo.StudentInfo = _studentInfo;

            this.txtBalanceForwardedAmount.Clear();

            this.tblBalanceForwarded.Text = "Balance Forwarded";

            if (_studentBalanceForwardedInfo.Amount > 0)
            {
                this.txtBalanceForwardedAmount.Text = _studentBalanceForwardedInfo.Amount.ToString("N");

                this.btnDeleteBalanceForwarded.Enabled = this.btnRecordBalanceForwarded.Enabled = true;

                this.lblReceivedDateBalanceForwarded.Text = balanceForwardedReceivedDate.ToLongDateString();

                this.tblBalanceForwarded.Text = "** Balance Forwarded";
            }            
          
            if ((DateTime.Compare(balanceForwardedReceivedDate, DateTime.MinValue) != 0) && 
                RemoteClient.ProcStatic.IsRecordLocked((Int32)CommonExchange.SystemRange.ReceivedDateAllowance, balanceForwardedReceivedDate,
                DateTime.Parse(_cashieringManager.ServerDateTime)))
            {
                this.lblStatusBalanceForwarded.Text = "This record is LOCKED";

                this.btnRecordBalanceForwarded.Enabled = this.btnDeleteBalanceForwarded.Enabled = this.txtBalanceForwardedAmount.Enabled = false;

                this.pbxLockBalanceForwarded.Visible = true;
                this.pbxUnLockBalanceForwarded.Visible = false;
            }
            else
            {
                this.lblStatusBalanceForwarded.Text = "This record is OPEN";

                this.btnRecordBalanceForwarded.Enabled = this.btnDeleteBalanceForwarded.Enabled = this.txtBalanceForwardedAmount.Enabled = true;

                this.pbxLockBalanceForwarded.Visible = false;
                this.pbxUnLockBalanceForwarded.Visible = true;
            }
        }//-------------------------

        //this procedure will initialize discount control
        private void InitializeDiscountControl()
        {
            this.lblScholarshipDescription.Text = "-";
            this.txtDiscountAmount.Clear();
            this.txtDiscountRemarks.Clear();
            this.chkIsDownpaymentDiscount.Checked = false;
            this.btnSearchDiscount.Enabled = true;
            this.btnRecordDiscount.Enabled = this.btnUpdateDiscount.Enabled = this.btnDeleteDiscount.Enabled = false;

            this.btnUpdateDiscount.Enabled = this.btnDeleteDiscount.Enabled = false;

            _hasUpdatedDiscount = false;

            _studentDiscountInfo.Amount = 0;
                        
            this.InitializeStudentPaymentDiscountReimbursementTable();

            _cashieringManager.InitializePaymentHistroyListView(this.lsvPaymentHistory, this.tabPaymentHistory);
            _cashieringManager.InitializeAmountDueList(this.lsvAmountDueList,
                _studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.CourseInfo.CourseId, DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd),
                _cashieringManager.IsSchoolYearForSummer(_cashieringManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)));

            _cashieringManager.InitializeStudentDiscountListView(this.lsvDiscount, this.tabDiscounts);
        }//----------------

        //this procedure will set record locking for receipt date
        //Code Added: September 2, 2010
        private void IsRecordLocked(DateTime receiptDate, DateTime receiveDate)
        {
            if (RemoteClient.ProcStatic.IsRecordLocked((Int32)CommonExchange.SystemRange.ReceivedDateAllowance, receiptDate, receiveDate,
                DateTime.Parse(_cashieringManager.ServerDateTime)))
            {
                this.btnPayment.Enabled = this.btnUpdatePayment.Enabled = this.btnDeletePayment.Enabled = this.btnSearchedAccountTitle.Enabled =
                       this.chkIsDownPaymentPayment.Enabled = this.chkIsMiscellaneousIncome.Enabled = false;

                this.lblStatusPayment.Text = "This record is LOCKED";

                this.txtPaymentAmount.ReadOnly = this.txtDiscountedAmount.ReadOnly = this.txtReceipNo.ReadOnly = this.txtPaymentRemarks.ReadOnly = true;

                this.pbxLockedPayment.Visible = true;
                this.pbxUnlockPayment.Visible = false;

                this.lblReceiptDate.Cursor = Cursors.Hand;
            }
            else
            {

                this.btnPayment.Enabled = _studentPaymentInfo.PaymentId > 0 ? false : true;
                this.btnUpdatePayment.Enabled = this.btnDeletePayment.Enabled = _studentPaymentInfo.PaymentId > 0 ? true : false;
                this.chkIsDownPaymentPayment.Enabled = this.btnSearchedAccountTitle.Enabled = true;

                this.chkIsMiscellaneousIncome.Enabled = !String.IsNullOrEmpty(_studentPaymentInfo.AccountCreditInfo.AccountSysId) ? true : false;

                this.lblStatusPayment.Text = "This record is OPEN";

                this.txtPaymentAmount.ReadOnly = this.txtDiscountedAmount.ReadOnly = this.txtReceipNo.ReadOnly = this.txtPaymentRemarks.ReadOnly = false;

                this.pbxLockedPayment.Visible = false;
                this.pbxUnlockPayment.Visible = true;

                //this.lblReceiptDate.Click -= new EventHandler(lblPaymentReflectedDateClick);
                //this.lblReceiptDate.Click += new EventHandler(lblPaymentReflectedDateClick);

                this.lblReceiptDate.Cursor = Cursors.Hand;
            }
        }//---------------------

        //this procedure will set record status
        //Code History: Priviews code calls (_cashieringManager.GetReflectedDate(<parameters>)) to supply the reflected date.
        //reflected date is delete because of the new record locking feature. (can backward payments more than 4 months)
        private void IsRecordLocked(DateTime receiveDate, Boolean isPayment, Boolean isReimbursment, Boolean isCreditMemo, Boolean isPromisoryNote, Boolean isDiscount)
        {
            if (RemoteClient.ProcStatic.IsRecordLocked((Int32)CommonExchange.SystemRange.ReceivedDateAllowance, receiveDate, DateTime.Parse(_cashieringManager.ServerDateTime)))
            {
                _isPaymentReimbursementCreditMemoRecordOpen = false;

                if (isPayment)
                {
                    this.btnPayment.Enabled = this.btnUpdatePayment.Enabled = this.btnDeletePayment.Enabled = this.btnSearchedAccountTitle.Enabled =
                        this.chkIsDownPaymentPayment.Enabled = this.chkIsMiscellaneousIncome.Enabled = false;

                    this.lblStatusPayment.Text = "This record is LOCKED";

                    this.txtPaymentAmount.ReadOnly = this.txtDiscountedAmount.ReadOnly = this.txtReceipNo.ReadOnly = this.txtPaymentRemarks.ReadOnly = true;

                    this.pbxLockedPayment.Visible = true;
                    this.pbxUnlockPayment.Visible = false;
                }
                else if (isReimbursment)
                {
                    this.btnRecordReimbursement.Enabled = false;

                    this.txtReimbursementAmount.ReadOnly = this.txtReimbursementRemarks.ReadOnly = true;

                    this.lblStatusReimbursement.Text = "This record is LOCKED";

                    this.pbxLockedReimbursement.Visible = true;
                    this.pbxUnLockedReimbursement.Visible = false;

                    this.btnRecordReimbursement.Enabled = this.btnUpdateReimbursment.Enabled = this.btnDeleteReimbursement.Enabled =false;
                }
                else if (isCreditMemo)
                {
                    this.lblStatusCreditMemo.Text = "This record is LOCKED";

                    this.pbxLockedCm.Visible = true;
                    this.pbxUnLockedCm.Visible = false;

                    this.btnRecordCreditMemo.Enabled = false;

                    this.txtCreditMemoAmount.ReadOnly = this.txtCreditMemoRemarks.ReadOnly = true;

                    this.btnRecordCreditMemo.Enabled = this.btnUpdateCreditMemo.Enabled = this.btnDeleteCreditMemo.Enabled = false;
                }
                else if (isPromisoryNote)
                {
                    this.lblStatusPromissoryNote.Text = "This record is LOCKED";

                    this.pbxLockPromissoryNote.Visible = true;
                    this.pbxUnlockPromissoryNote.Visible = false;

                    this.btnDeletePromissoryNote.Enabled = this.btnUpdatePromissoryNote.Enabled =
                        this.btnRecordPromissoryNote.Enabled = false;

                    this.txtReceivedDate.ReadOnly = this.txtReferenceNo.ReadOnly = this.txtPromissoryNote.ReadOnly = true;
                }
                else if (isDiscount)
                {
                    if (!RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo))//Code Added Feb. 9, 2011..Code Purpose: Remove record locking for administrator
                    {
                        if (RemoteClient.ProcStatic.IsRecordLockForOptionalAdditionalDiscountFee(DateTime.Parse(_dateStart),
                            DateTime.Parse(_dateEnd), DateTime.Parse(_cashieringManager.ServerDateTime),
                            (Int32)CommonExchange.SystemRange.MonthAllowance, _studentEnrolmentLevelInfo.IsMarkedDeleted,
                            _cashieringManager.IsCurrentCourse(_strEnrolmentCourseSysId), false, false, true))
                        {
                            this.btnRecordDiscount.Enabled = this.btnUpdateDiscount.Enabled =
                                this.btnDeleteDiscount.Enabled = _isDiscountRecordOpen = false;

                            this.lblStatusDiscount.Text = "This record is LOCKED";

                            this.txtDiscountAmount.ReadOnly = true;

                            this.pbxLockedDiscount.Visible = true;
                            this.pbxUnlockDiscount.Visible = false;

                            this.lsvDiscount.MouseDoubleClick -= new MouseEventHandler(lsvDiscountMouseDoubleClick);
                        }
                    }
                    else
                    {
                        _isDiscountRecordOpen = true;
                    }
                }
            }
            else
            {
                _isPaymentReimbursementCreditMemoRecordOpen = true;

                if (isPayment)
                {
                    this.btnPayment.Enabled = _studentPaymentInfo.PaymentId > 0 ? false : true;
                    this.btnUpdatePayment.Enabled = this.btnDeletePayment.Enabled = _studentPaymentInfo.PaymentId > 0 ? true : false;
                    this.chkIsDownPaymentPayment.Enabled = this.btnSearchedAccountTitle.Enabled = true;

                    this.chkIsMiscellaneousIncome.Enabled = !String.IsNullOrEmpty(_studentPaymentInfo.AccountCreditInfo.AccountSysId) ? true : false;

                    this.lblStatusPayment.Text = "This record is OPEN";

                    this.txtPaymentAmount.ReadOnly = this.txtDiscountedAmount.ReadOnly = this.txtReceipNo.ReadOnly = this.txtPaymentRemarks.ReadOnly = false;

                    this.pbxLockedPayment.Visible = false;
                    this.pbxUnlockPayment.Visible = true;

                    this.lblPaymentReflectedDate.Click -= new EventHandler(lblPaymentReflectedDateClick);
                    this.lblPaymentReflectedDate.Click += new EventHandler(lblPaymentReflectedDateClick);

                    this.lblPaymentReflectedDate.Cursor = Cursors.Hand;
                }
                else if (isReimbursment)
                {
                    this.btnRecordReimbursement.Enabled = _studentReimbursementInfo.ReimbursementId > 0 ? false : true;
                    this.btnUpdateReimbursment.Enabled = this.btnDeleteReimbursement.Enabled = _studentReimbursementInfo.ReimbursementId > 0 ? true : false;

                    this.txtReimbursementAmount.ReadOnly = this.txtReimbursementRemarks.ReadOnly = false;

                    this.lblStatusReimbursement.Text = "This record is OPEN";

                    this.pbxLockedReimbursement.Visible = false;
                    this.pbxUnLockedReimbursement.Visible = true;

                    this.lblReimbursmentReflectedDate.Click -= new EventHandler(lblReimbursmentReflectedDateClick);
                    this.lblReimbursmentReflectedDate.Click += new EventHandler(lblReimbursmentReflectedDateClick);

                    this.lblReimbursmentReflectedDate.Cursor = Cursors.Hand;
                }
                else if (isCreditMemo)
                {
                    this.pbxLockedCm.Visible = false;
                    this.pbxUnLockedCm.Visible = true;

                    this.btnRecordCreditMemo.Enabled = _studentCreditMemo.MemoId > 0 ? false : true;
                    this.btnUpdateCreditMemo.Enabled = this.btnDeleteCreditMemo.Enabled = _studentCreditMemo.MemoId > 0 ? true : false;

                    this.lblStatusCreditMemo.Text = "This record is OPEN";

                    this.txtCreditMemoAmount.ReadOnly = this.txtCreditMemoRemarks.ReadOnly = false;

                    this.lblCreditMemoReflectedDate.Click -= new EventHandler(lblCreditMemoReflectedDateClick);
                    this.lblCreditMemoReflectedDate.Click += new EventHandler(lblCreditMemoReflectedDateClick);

                    this.lblCreditMemoReflectedDate.Cursor = Cursors.Hand;
                }
                else if (isPromisoryNote)
                {
                    this.lblStatusPromissoryNote.Text = "This record is OPEN";

                    this.pbxLockPromissoryNote.Visible = false;
                    this.pbxUnlockPromissoryNote.Visible = true;

                    this.btnRecordPromissoryNote.Enabled = _studentPromissoryNoteInfo.PromissoryNoteId > 0 ? false : true;
                    this.btnUpdatePromissoryNote.Enabled = _studentPromissoryNoteInfo.PromissoryNoteId > 0 ? true : false;

                    this.txtReferenceNo.ReadOnly = this.txtPromissoryNote.ReadOnly = false;
                }
                else if (isDiscount)
                {
                    if (!RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo))//Code Added Feb. 9, 2011..Code Purpose: Remove record locking for administrator
                    {
                        if (!RemoteClient.ProcStatic.IsRecordLockForOptionalAdditionalDiscountFee(DateTime.Parse(_dateStart),
                            DateTime.Parse(_dateEnd), DateTime.Parse(_cashieringManager.ServerDateTime),
                            (Int32)CommonExchange.SystemRange.MonthAllowance, _studentEnrolmentLevelInfo.IsMarkedDeleted,
                            _cashieringManager.IsCurrentCourse(_strEnrolmentCourseSysId), false, false, true))
                        {
                            _isDiscountRecordOpen = true;

                            this.lblStatusDiscount.Text = "This record is OPEN";

                            this.txtDiscountAmount.ReadOnly = false;

                            this.pbxLockedDiscount.Visible = false;
                            this.pbxUnlockDiscount.Visible = true;

                            this.lsvDiscount.MouseDoubleClick -= new MouseEventHandler(lsvDiscountMouseDoubleClick);
                            this.lsvDiscount.MouseDoubleClick += new MouseEventHandler(lsvDiscountMouseDoubleClick);

                            this.lblDiscountReflectedDate.Cursor = Cursors.Hand;
                        }
                    }
                    else
                    {
                        _isDiscountRecordOpen = true;
                    }
                }
            }
        }//---------------------

        //this procedure will set record status
        //Code History: Priviews code calls (_cashieringManager.GetReflectedDate(<parameters>)) to supply the reflected date.
        //reflected date is delete because of the new record locking feature. (can backward payments more than 4 months)
        private void IsRecordLocked()
        {
            //record locking for payment //record locking for reimbursement //credit memo //record locking for student promissory note
            if (RemoteClient.ProcStatic.IsRecordLocked((Int32)CommonExchange.SystemRange.ReceivedDateAllowance, 
                DateTime.Parse(_cashieringManager.ServerDateTime), DateTime.Parse(_cashieringManager.ServerDateTime)))
            {
                _isPaymentReimbursementCreditMemoRecordOpen = false;

                this.btnPayment.Enabled = this.btnUpdatePayment.Enabled = this.btnDeletePayment.Enabled = 
                    this.chkIsDownPaymentPayment.Enabled = this.chkIsMiscellaneousIncome.Enabled = _isPaymentReimbursementCreditMemoRecordOpen;

                this.lblStatusPayment.Text = this.lblStatusPromissoryNote.Text =
                    this.lblStatusReimbursement.Text = this.lblStatusCreditMemo.Text = "This record is LOCKED";
                this.lblPaymentReflectedDate.Text = this.lblReimbursmentReflectedDate.Text = this.lblCreditMemoReflectedDate.Text = "-";

                this.pbxLockedPayment.Visible = true;
                this.pbxUnlockPayment.Visible = false;

                _isReimbursementRecordOpen = false;

                this.btnRecordReimbursement.Enabled = this.btnUpdateReimbursment.Enabled = this.btnDeleteReimbursement.Enabled =
                    this.txtReimbursementAmount.ReadOnly = this.txtReimbursementRemarks.ReadOnly = _isReimbursementRecordOpen;

                this.pbxLockedReimbursement.Visible = true;
                this.pbxUnLockedReimbursement.Visible = false;

                this.InitializePaymentReimbursementControl();

                this.pbxLockPromissoryNote.Visible = true;
                this.pbxUnlockPromissoryNote.Visible = false;

                this.lnkReceivedDate.Enabled = this.btnDeletePromissoryNote.Enabled = this.btnUpdatePromissoryNote.Enabled =
                    this.btnRecordPromissoryNote.Enabled = false;

                this.txtReceivedDate.ReadOnly = this.txtReferenceNo.ReadOnly = this.txtPromissoryNote.ReadOnly = true;

                this.pbxLockedCm.Visible = true;
                this.pbxUnLockedCm.Visible = false;

                this.btnRecordCreditMemo.Enabled = this.btnUpdateCreditMemo.Enabled = this.btnDeleteCreditMemo.Enabled = false;

                this.txtCreditMemoAmount.ReadOnly = this.txtCreditMemoRemarks.ReadOnly = true;

                this.lblPaymentReflectedDate.Click -= new EventHandler(lblPaymentReflectedDateClick);
                this.lblReimbursmentReflectedDate.Click -= new EventHandler(lblReimbursmentReflectedDateClick);
                this.lblCreditMemoReflectedDate.Click -= new EventHandler(lblCreditMemoReflectedDateClick);
            }
            else
            {
                _isPaymentReimbursementCreditMemoRecordOpen = true;

                this.btnPayment.Enabled = this.chkIsDownPaymentPayment.Enabled =  _isPaymentReimbursementCreditMemoRecordOpen;

                this.chkIsMiscellaneousIncome.Enabled = !String.IsNullOrEmpty(_studentPaymentInfo.AccountCreditInfo.AccountSysId) ? true : false;

                this.lblStatusPayment.Text = this.lblStatusReimbursement.Text = this.lblStatusPromissoryNote.Text =
                    this.lblStatusCreditMemo.Text = "This record is OPEN";

                this.pbxLockedPayment.Visible = false;
                this.pbxUnlockPayment.Visible = true;

                _isReimbursementRecordOpen = true;

                this.btnRecordReimbursement.Enabled = this.txtReimbursementAmount.Enabled = this.txtReimbursementRemarks.Enabled = _isReimbursementRecordOpen;

                this.pbxLockedReimbursement.Visible = false;
                this.pbxUnLockedReimbursement.Visible = true;

                this.InitializePaymentReimbursementControl();

                this.pbxLockPromissoryNote.Visible = false;
                this.pbxUnlockPromissoryNote.Visible = true;

                this.lnkReceivedDate.Enabled = this.btnRecordPromissoryNote.Enabled = true;

                this.txtReferenceNo.ReadOnly = this.txtPromissoryNote.ReadOnly = false;

                this.pbxLockedCm.Visible = false;
                this.pbxUnLockedCm.Visible = true;

                this.btnRecordCreditMemo.Enabled = true;

                this.txtCreditMemoAmount.ReadOnly = this.txtCreditMemoRemarks.ReadOnly = false;

                this.lblPaymentReflectedDate.Click -= new EventHandler(lblPaymentReflectedDateClick);
                this.lblReimbursmentReflectedDate.Click -= new EventHandler(lblReimbursmentReflectedDateClick);
                this.lblCreditMemoReflectedDate.Click -= new EventHandler(lblCreditMemoReflectedDateClick);
                this.lblPaymentReflectedDate.Click += new EventHandler(lblPaymentReflectedDateClick);
                this.lblReimbursmentReflectedDate.Click += new EventHandler(lblReimbursmentReflectedDateClick);
                this.lblCreditMemoReflectedDate.Click += new EventHandler(lblCreditMemoReflectedDateClick);

                this.lblPaymentReflectedDate.Cursor = this.lblReimbursmentReflectedDate.Cursor = this.lblCreditMemoReflectedDate.Cursor = Cursors.Hand;
            }//--------------------

            //record locking for optional fee
            if (!RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo))//Code Added Feb. 9, 2011. Code Purpose: Remove record locking for the administrator
            {
                if (RemoteClient.ProcStatic.IsRecordLockForOptionalAdditionalDiscountFee(DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd),
                    DateTime.Parse(_cashieringManager.ServerDateTime), (Int32)CommonExchange.SystemRange.MonthAllowance, _studentEnrolmentLevelInfo.IsMarkedDeleted,
                    _cashieringManager.IsCurrentCourse(_strEnrolmentCourseSysId), true, false, false))
                {
                    this.pbxOptionalFee.Enabled = this.btnRecordOptionalFee.Enabled = false;

                    this.lblStatusOptionalFee.Text = "This record is LOCKED";

                    this.pbxLockedOptionalFee.Visible = true;
                    this.pbxUnlockedOptionalFee.Visible = false;

                    if (!RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo))
                    {
                        this.btnMarkedEntryLevel.Enabled = false;
                    }
                }
                else
                {
                    this.pbxOptionalFee.Enabled = this.btnRecordOptionalFee.Enabled = true;

                    this.lblStatusOptionalFee.Text = "This record is OPEN";

                    this.pbxLockedOptionalFee.Visible = false;
                    this.pbxUnlockedOptionalFee.Visible = true;
                    this.btnMarkedEntryLevel.Enabled = true;
                }
            }
            else
            {
                this.btnMarkedEntryLevel.Enabled = true;
            }
            //---------------------

            //record locking for additional fee
            if (!RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo))//Code Added Feb. 9, 2011..Code Purpose: Remove record locking for administrator
            {
                if (RemoteClient.ProcStatic.IsRecordLockForOptionalAdditionalDiscountFee(DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd),
                    DateTime.Parse(_cashieringManager.ServerDateTime), (Int32)CommonExchange.SystemRange.MonthAllowance, _studentEnrolmentLevelInfo.IsMarkedDeleted,
                    _cashieringManager.IsCurrentCourse(_strEnrolmentCourseSysId), false, true, false))
                {
                    this.btnAdditionalPayment.Enabled = this.btnUpdateAdditionalPayment.Enabled =
                        this.btnDeleteAdditionalPayment.Enabled = this.btnSearchAdditionalFee.Enabled = _isAdditionalFeeRecordOpen = false;

                    this.lblStatusAdditionalPayment.Text = "This record is LOCKED";

                    this.txtAdditionalPaymentAmount.ReadOnly = this.txtAdditionalFeeRemarks.ReadOnly = true;

                    this.pbxLockedAdditionalFee.Visible = true;
                    this.pbxUnlockAdditionalFee.Visible = false;

                    this.lsvAdditionalPayment.MouseDoubleClick -= new MouseEventHandler(lsvAdditionalPaymentMouseDoubleClick);
                }
                else
                {
                    this.btnAdditionalPayment.Enabled = this.btnSearchAdditionalFee.Enabled = _isAdditionalFeeRecordOpen = true;

                    this.lblStatusAdditionalPayment.Text = "This record is OPEN";

                    this.txtAdditionalPaymentAmount.ReadOnly = this.txtAdditionalFeeRemarks.ReadOnly = false;

                    this.pbxLockedAdditionalFee.Visible = false;
                    this.pbxUnlockAdditionalFee.Visible = true;

                    this.lsvAdditionalPayment.MouseDoubleClick -= new MouseEventHandler(lsvAdditionalPaymentMouseDoubleClick);
                    this.lsvAdditionalPayment.MouseDoubleClick += new MouseEventHandler(lsvAdditionalPaymentMouseDoubleClick);

                    this.lblDiscountReflectedDate.Cursor = Cursors.Hand;
                }
            }
            else
            {
                this.txtAdditionalPaymentAmount.ReadOnly = this.txtAdditionalFeeRemarks.ReadOnly = false;

                _isAdditionalFeeRecordOpen = true;
            }
            //----------------------

            //record locking for discount
            if (!RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo))//Code Added Feb. 9, 2011..Code Purpose: Remove record locking for administrator
            {
                if (RemoteClient.ProcStatic.IsRecordLockForOptionalAdditionalDiscountFee(DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd),
                    DateTime.Parse(_cashieringManager.ServerDateTime), (Int32)CommonExchange.SystemRange.MonthAllowance, _studentEnrolmentLevelInfo.IsMarkedDeleted,
                    _cashieringManager.IsCurrentCourse(_strEnrolmentCourseSysId), false, false, true))
                {
                    this.btnRecordDiscount.Enabled = this.btnUpdateDiscount.Enabled =
                        this.btnDeleteDiscount.Enabled = this.lblDiscountReflectedDate.Enabled =
                        this.btnSearchDiscount.Enabled = this.chkIsDownpaymentDiscount.Enabled = _isDiscountRecordOpen = false;

                    this.lblStatusDiscount.Text = "This record is LOCKED";

                    this.txtDiscountAmount.ReadOnly = this.txtDiscountRemarks.ReadOnly = true;

                    this.pbxLockedDiscount.Visible = true;
                    this.pbxUnlockDiscount.Visible = false;

                    this.lsvDiscount.MouseDoubleClick -= new MouseEventHandler(lsvDiscountMouseDoubleClick);
                }
                else
                {
                    _isDiscountRecordOpen = true;

                    this.lblStatusDiscount.Text = "This record is OPEN";

                    this.txtDiscountAmount.ReadOnly = this.txtDiscountRemarks.ReadOnly = false;

                    this.lblDiscountReflectedDate.Enabled = this.btnSearchDiscount.Enabled = this.chkIsDownpaymentDiscount.Enabled = true;

                    this.pbxLockedDiscount.Visible = false;
                    this.pbxUnlockDiscount.Visible = true;

                    this.lsvDiscount.MouseDoubleClick += new MouseEventHandler(lsvDiscountMouseDoubleClick);
                }//----------------------
            }
            else
            {
                this.txtDiscountAmount.ReadOnly = this.txtDiscountRemarks.ReadOnly = false;

                _isDiscountRecordOpen = true;
            }//--------------------------------

            //record lock for withdrawn subjects and withdrawn speical class
            if (!RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo))//Code Added Feb. 9, 2011..Code Purpose: Remove record locking for administrator
            {
                if (RemoteClient.ProcStatic.IsRecordLocked(DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd),
                       DateTime.Parse(_cashieringManager.ServerDateTime), (Int32)CommonExchange.SystemRange.MonthAllowance))
                {
                    _isWithdrawnSubjectSpecialClassOpen = false;

                    this.lblStatusWithdrawnSpecial.Text = this.lblWithdrawnSubjectStatus.Text = "This record is LOCKED";

                    this.pbxLockWithdrawnSpecial.Visible = this.pbxLockWithdrawnSubject.Visible = true;
                    this.pbxUnLockWithdrawnSpecial.Visible = this.pbxUnLockWithdrawnSubject.Visible = false;
                }
                else
                {
                    _isWithdrawnSubjectSpecialClassOpen = true;

                    this.lblStatusWithdrawnSpecial.Text = this.lblWithdrawnSubjectStatus.Text = "This record is OPEN";

                    this.pbxLockWithdrawnSpecial.Visible = this.pbxLockWithdrawnSubject.Visible = false;
                    this.pbxUnLockWithdrawnSpecial.Visible = this.pbxUnLockWithdrawnSubject.Visible = true;
                }
            }
            else
            {
                _isWithdrawnSubjectSpecialClassOpen = true;
            }
        }//-------------------------

        //this procedure will initialize student payment reimbursement control
        private void InitializePaymentReimbursementControl()
        {
            _askConfirmationPayment = true;

            this.txtPaymentAmount.Clear();
            this.txtPaymentAmount.Focus();
            this.txtReceipNo.Text = RemoteClient.ProcStatic.SixDigitZero(CashieringLogic.ReceiptNumber);
            this.txtPaymentRemarks.Clear();
            this.txtDiscountedAmount.Clear();
            this.txtAmountTendered.Clear();
            this.lblChange.Text = "-";
            this.chkIsDownPaymentPayment.Checked = false;
            this.chkIsMiscellaneousIncome.Checked = false;

            _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = false;

            this.btnPayment.Enabled = _isPaymentReimbursementCreditMemoRecordOpen;
            this.btnRecordReimbursement.Enabled = _isReimbursementRecordOpen;

            this.btnUpdatePayment.Enabled = false;
            this.txtPaymentAmount.ReadOnly = this.txtReceipNo.ReadOnly = this.txtPaymentRemarks.ReadOnly = 
                this.txtDiscountedAmount.ReadOnly = !_isPaymentReimbursementCreditMemoRecordOpen;

            _studentPaymentInfo.Amount = 0;
            _studentPaymentInfo.IsDownpayment = false;
            _studentPaymentInfo.IsMiscellaneousIncome = false;
            _studentPaymentInfo.ObjectState = System.Data.DataRowState.Unchanged;
            _studentPaymentInfo.Remarks = String.Empty;

            this.txtReimbursementAmount.Clear();
            this.txtReimbursementRemarks.Clear();

            _studentReimbursementInfo.Amount = 0;
            _studentReimbursementInfo.Remarks = String.Empty;

            if (!String.IsNullOrEmpty(_dateStart) && !String.IsNullOrEmpty(_dateEnd))
            {
                this.gbxPayment.Enabled = this.gbxReimbursement.Enabled = this.gbxBalanceForwarded.Enabled = this.cboYearLevel.Enabled = true;
            }
        }//--------------------------------    

        //this procedure will clear all errors
        private void ClearErrors()
        {
            _errProvider.SetError(this.txtPaymentAmount, "");
            _errProvider.SetError(this.txtReceipNo, "");
            _errProvider.SetError(this.txtReimbursementAmount, "");

            _errProvider.SetError(this.lblParticularDescription, "");
            _errProvider.SetError(this.cboYearLevel, "");
            _errProvider.SetError(this.txtAdditionalPaymentAmount, "");

            _errProvider.SetError(this.lblStdStudentId, "");
            _errProvider.SetError(this.txtBalanceForwardedAmount, "");

            _errProvider.SetError(this.lblScholarshipDescription, "");
            _errProvider.SetError(this.txtDiscountAmount, "");

            _errProvider.SetError(this.lnkReceivedDate, "");

            _errProvider.SetError(this.txtCreditMemoAmount, "");
        }//-----------------------

        #endregion

        #region Programer-Defined Functions
        //this fucntion will validate controls
        private Boolean ValidateControlsPaymentReimbursement(Boolean isPayment, Boolean isForReIssue)
        {
            Boolean isValid = true;

            _errProvider.SetError(this.txtPaymentAmount, "");
            _errProvider.SetError(this.txtReceipNo, "");
            _errProvider.SetError(this.txtReimbursementAmount, "");
            _errProvider.SetError(this.lblPayment, "");
            _errProvider.SetError(this.lblReimbursement, "");
            _errProvider.SetError(this.txtCreditEntry, "");

            if (isPayment)
            {
                if (_studentPaymentInfo.Amount <= 0)
                {
                    _errProvider.SetError(this.txtPaymentAmount, "Amount must be greater than zero.");
                    _errProvider.SetIconAlignment(this.txtPaymentAmount, ErrorIconAlignment.MiddleLeft);

                    this.txtPaymentAmount.Focus();

                    isValid = false;
                }

                if (String.IsNullOrEmpty(_studentPaymentInfo.ReceiptNo))
                {
                    _errProvider.SetError(this.txtReceipNo, "You must input a receipt number.");
                    _errProvider.SetIconAlignment(this.txtReceipNo, ErrorIconAlignment.MiddleLeft);

                    this.txtReceipNo.Focus();

                    isValid = false;
                }

                if (String.IsNullOrEmpty(_studentPaymentInfo.AccountCreditInfo.AccountSysId))
                {
                    _errProvider.SetError(this.txtCreditEntry, "You must select a credit entry information.");
                    _errProvider.SetIconAlignment(this.txtCreditEntry, ErrorIconAlignment.MiddleLeft);

                    this.txtCreditEntry.Focus();

                    isValid = false;
                }

                if (isForReIssue)
                {
                    using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
                    {
                        if (remClient.IsExistsReceiptNoStudentPayments(_userInfo, _studentPaymentInfo.PaymentId,
                            RemoteClient.ProcStatic.SixDigitZero(CashieringLogic.ReceiptNumber).ToString()))
                        {
                            _errProvider.SetError(this.txtReceipNo, "The new receipt number is already exist [" +
                                RemoteClient.ProcStatic.SixDigitZero(CashieringLogic.ReceiptNumber).ToString() + "].");
                            _errProvider.SetIconAlignment(this.txtReceipNo, ErrorIconAlignment.MiddleLeft);

                            this.txtReceipNo.Focus();

                            isValid = false;
                        }
                    }
                }
                else
                {
                    using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
                    {
                        if (remClient.IsExistsReceiptNoStudentPayments(_userInfo, _studentPaymentInfo.PaymentId, _studentPaymentInfo.ReceiptNo))
                        {
                            _errProvider.SetError(this.txtReceipNo, "Receipt number is already exist.");
                            _errProvider.SetIconAlignment(this.txtReceipNo, ErrorIconAlignment.MiddleLeft);

                            this.txtReceipNo.Focus();
                            
                            isValid = false;
                        }
                    }
                }

                if (String.IsNullOrEmpty(_studentPaymentInfo.StudentInfo.StudentSysId))
                {
                    _errProvider.SetError(this.lblStdStudentId, "You must select a student.");
                    _errProvider.SetIconAlignment(this.lblStdStudentId, ErrorIconAlignment.MiddleLeft);

                    isValid = false;
                }

                if (_studentPaymentInfo.PaymentId < 0)
                {
                    _errProvider.SetError(this.lblPayment, "You must select a payment information.");
                    _errProvider.SetIconAlignment(this.lblPayment, ErrorIconAlignment.MiddleLeft);

                    isValid = false;
                }
            }
            else
            {
                if (_studentReimbursementInfo.Amount <= 0)
                {
                    _errProvider.SetError(this.txtReimbursementAmount, "Amount must be greater than zero.");
                    _errProvider.SetIconAlignment(this.txtReimbursementAmount, ErrorIconAlignment.MiddleRight);

                    this.txtReimbursementAmount.Focus();

                    isValid = false;
                }

                if (String.IsNullOrEmpty(_studentReimbursementInfo.StudentInfo.StudentSysId))
                {
                    _errProvider.SetError(this.lblStdStudentId, "You must select a student.");
                    _errProvider.SetIconAlignment(this.lblStdStudentId, ErrorIconAlignment.MiddleRight);

                    isValid = false;
                }

                if (_studentReimbursementInfo.ReimbursementId < 0)
                {
                    _errProvider.SetError(this.lblReimbursement, "You must select a reimbursement information.");
                    _errProvider.SetIconAlignment(this.lblReimbursement, ErrorIconAlignment.MiddleRight);

                    isValid = false;
                }
            }

            return isValid;
        }//--------------------------

        //this fucntion will validate controls student credit memo
        private Boolean ValidateControlsCreditMemo()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.txtCreditMemoAmount, "");
            _errProvider.SetError(this.lblCreditMemo, "");

            if (_studentCreditMemo.Amount <= 0)
            {
                _errProvider.SetError(this.txtCreditMemoAmount, "Amount must be greater than zero.");
                _errProvider.SetIconAlignment(this.txtCreditMemoAmount, ErrorIconAlignment.MiddleRight);
                isValid = false;
            }

            if (_studentCreditMemo.MemoId < 0)
            {
                _errProvider.SetError(this.lblCreditMemo, "You must select a credit memo information");
                _errProvider.SetIconAlignment(this.lblCreditMemo, ErrorIconAlignment.MiddleRight);
                isValid = false;
            }

            return isValid;
        }//------------------------

        //this fucntion will validate controls student additional fee
        private Boolean ValidateControlsAdditionalFee()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.lblParticularDescription, "");
            _errProvider.SetError(this.cboYearLevel, "");
            _errProvider.SetError(this.txtAdditionalPaymentAmount, "");

            if (String.IsNullOrEmpty(_studentAdditionalFeeInfo.SchoolFeeParticularInfo.FeeParticularSysId))
            {
                _errProvider.SetError(this.lblParticularDescription, "You must select an additional fee.");
                _errProvider.SetIconAlignment(this.lblParticularDescription, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            if (String.IsNullOrEmpty(_studentAdditionalFeeInfo.StudentEnrolmentLevelInfo.EnrolmentLevelSysId))
            {
                _errProvider.SetError(this.cboYearLevel, "You must select an year level.");
                _errProvider.SetIconAlignment(this.cboYearLevel, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }


            if (_studentAdditionalFeeInfo.Amount <= 0)
            {
                _errProvider.SetError(this.txtAdditionalPaymentAmount, "Amount must be greater than zero.");
                _errProvider.SetIconAlignment(this.txtAdditionalPaymentAmount, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            return isValid;
        }//---------------------

        //this function will validate controls student balance forwarded
        private Boolean ValidateControlsBalanceForwarded()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.lblStdStudentId, "");
            _errProvider.SetError(this.txtBalanceForwardedAmount, "");

            if (String.IsNullOrEmpty(_studentBalanceForwardedInfo.StudentInfo.StudentSysId))
            {
                _errProvider.SetError(this.lblStdStudentId, "You must select a student.");
                _errProvider.SetIconAlignment(this.lblStdStudentId, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            if (_studentBalanceForwardedInfo.Amount <= 0)
            {
                _errProvider.SetError(this.txtBalanceForwardedAmount, "Amount must be greater than zero.");
                _errProvider.SetIconAlignment(this.txtBalanceForwardedAmount, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            return isValid;
        }

        //this fucntion will validate controls student discount
        private Boolean ValidateControlsDiscount()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.lblScholarshipDescription, "");
            _errProvider.SetError(this.txtDiscountAmount, "");

            if (String.IsNullOrEmpty(_studentDiscountInfo.StudentScholarshipInfo.StudentScholarshipSysId) &&
                _studentScholarshipInfo == null)
            {
                _errProvider.SetError(this.lblScholarshipDescription, "You must select a scholarship.");
                _errProvider.SetIconAlignment(this.lblScholarshipDescription, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            if (_studentDiscountInfo.Amount <= 0)
            {
                _errProvider.SetError(this.txtDiscountAmount, "Amount must be greater than zero.");
                _errProvider.SetIconAlignment(this.txtDiscountAmount, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            if (_studentScholarshipInfo != null)
            {
                _studentScholarshipInfo.StudentEnrolmentLevelInfo = _studentEnrolmentLevelInfo;

                if (_cashieringManager.IsExistsSysIDStudentScholarshipEnrolmentLevelStudentScholarship(_userInfo, _studentScholarshipInfo))
                {
                    _errProvider.SetError(this.lblScholarshipDescription, "Student scholarship already exist.");
                    _errProvider.SetIconAlignment(this.lblScholarshipDescription, ErrorIconAlignment.MiddleRight);

                    isValid = false;
                }
            }

            return isValid;
        }//------------------

        //this fucntion will validate controls for student promissory note
        private Boolean ValidateControlsStudentPromissoryNote()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.lnkReceivedDate, "");

            if (String.IsNullOrEmpty(_studentPromissoryNoteInfo.ReflectedDate))
            {
                _errProvider.SetError(this.lnkReceivedDate, "Received Date is required.");
                _errProvider.SetIconAlignment(this.lnkReceivedDate, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            return isValid;
        }//-----------------------
     
        //this fucntion returns has changes payment tab
        private Boolean SetTabPaymentSelectedTabChange(Boolean isTabPayment, Boolean isYear, Boolean isSemester)
        {
            Boolean hasEnter = false;

            this.txtPaymentAmount.Focus();

            if (isTabPayment && _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded && _askConfirmationPayment)
            {
                String strMsg = "There are unrecorded student payment/reimbursement/promissory note/credit memo/balance forwarded, changing tab" +
                    "without recording it causes data loss.\n\n Are you sure you want to continue?";

                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    _askConfirmationPayment = false;

                    this.tblTransanctions.SelectedIndex = _oldIndexPayment;

                    hasEnter = true;
                }
                else
                {
                    _oldIndexPayment = this.tblTransanctions.SelectedIndex;

                    _askConfirmationPayment = true;

                    _hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded = false;

                    if (_oldIndexPayment == 0)
                    {
                        this.txtPaymentAmount.Clear();
                        this.txtPaymentAmount.Focus();
                        this.txtPaymentRemarks.Clear();
                        this.txtDiscountedAmount.Clear();
                        this.chkIsDownPaymentPayment.Checked = false;
                        this.chkIsMiscellaneousIncome.Checked = false;

                        this.txtReceipNo.Text = RemoteClient.ProcStatic.SixDigitZero(CashieringLogic.ReceiptNumber);
                        this.txtAmountTendered.Clear();
                        this.lblChange.Text = "-";

                        _studentPaymentInfo.Amount = 0;
                        _studentPaymentInfo.AmountTendered = 0;
                        _studentPaymentInfo.DiscountAmount = 0;
                        _studentPaymentInfo.IsDownpayment = false;
                        _studentPaymentInfo.IsMiscellaneousIncome = false;
                        _studentPaymentInfo.ObjectState = System.Data.DataRowState.Unchanged;
                        _studentPaymentInfo.Remarks = String.Empty;
                        _studentPaymentInfo.ReceiptDate = CashieringLogic.ReceiptDate;

                        this.lblReceiptDate.Text = DateTime.Parse(_studentPaymentInfo.ReceiptDate).ToLongDateString();

                        this.txtPaymentAmount.ReadOnly = this.txtReceipNo.ReadOnly = this.txtPaymentRemarks.ReadOnly =
                            this.txtDiscountedAmount.ReadOnly = !_isPaymentReimbursementCreditMemoRecordOpen;

                        this.btnUpdatePayment.Enabled = false;

                        this.btnPayment.Enabled = _isPaymentReimbursementCreditMemoRecordOpen;
                    }
                    else if (_oldIndexPayment == 1)
                    {
                        this.btnRecordReimbursement.Enabled = _isReimbursementRecordOpen;

                        this.txtReimbursementAmount.Clear();
                        this.txtReimbursementRemarks.Clear();

                        _studentReimbursementInfo.Amount = 0;
                        _studentReimbursementInfo.Remarks = String.Empty;
                    }
                    else if (_oldIndexChargesTab == 2)
                    {
                        this.InitializeStudentPromissoryNoteControls();
                    }
                    else if (_oldIndexChargesTab == 3)
                    {
                        this.InitializeStudentBalanceForwardedControls();
                    }
                    else if (_oldIndexChargesTab == 4)
                    {
                        this.txtCreditMemoAmount.Clear();
                        this.txtCreditMemoRemarks.Clear();

                        _studentCreditMemo.Amount = 0;
                        _studentCreditMemo.Remarks = String.Empty;
                    }

                    this.ClearErrors();

                    DateTime dateStart = DateTime.MinValue;
                    DateTime dateEnd = DateTime.MinValue;

                    if (DateTime.TryParse(_dateStart, out dateStart) && DateTime.TryParse(_dateEnd, out dateEnd))
                    {
                        _studentPaymentInfo.ReflectedDate = _studentCreditMemo.ReflectedDate = 
                            _studentReimbursementInfo.ReflectedDate = _studentDiscountInfo.ReflectedDate =
                            _cashieringManager.GetReflectedDate(dateStart, dateEnd).ToShortDateString() + " 12:00:00 AM";

                        this.lblPaymentReflectedDate.Text = this.lblReimbursmentReflectedDate.Text = 
                            this.lblCreditMemoReflectedDate.Text = this.lblDiscountReflectedDate.Text =
                            _cashieringManager.GetReflectedDate(dateStart, dateEnd).ToLongDateString();
                    }

                    _studentPaymentInfo.ReceiptDate = CashieringLogic.ReceiptDate;

                    this.lblReceiptDate.Text = DateTime.Parse(_studentPaymentInfo.ReceiptDate).ToLongDateString();
                }
            }            
           
            return !hasEnter;

        }//----------------------

        //this fucntion returns has changes charges tab
        private Boolean SetTabChargesSelectedTabChange(Boolean isTabCharges, Boolean isCourse, Boolean isYearLevel, 
            Boolean isYear, Boolean isSemster, Boolean isForCharges, Boolean isForPayment)
        {
            Boolean hasEnter = false;

            if (isTabCharges && _oldIndexChargesTab == _tabStruct.F9Key)
            {
                if (isTabCharges && _hasUpdatedDiscount && _askConfirmationCharges)
                {
                    String strMsg = "There are unrecorded student additional fee, changing the tab without recording it causes data loss.\n\n" +
                        "Are you sure you want to continue?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.No)
                    {
                        _askConfirmationCharges = false;

                        this.tblCharges.SelectedIndex = _oldIndexChargesTab;

                        hasEnter = true;
                    }
                    else
                    {
                        _oldIndexChargesTab = this.tblCharges.SelectedIndex;

                        _askConfirmationCharges = true;

                        this.InitializeDiscountControl();

                        this.ClearErrors();
                    }
                }
                else if (isTabCharges)
                {
                    _oldIndexChargesTab = this.tblCharges.SelectedIndex;

                    _askConfirmationCharges = true;
                }
            }
            else if (isTabCharges && _oldIndexChargesTab == _tabStruct.F8Key)
            {
                if (_hasUpdatedAdditionalFee && _askConfirmationCharges)
                {
                    String strMsg = "There are unrecorded student additional fee, changing the tab without recording it causes data loss.\n\n" +
                        "Are you sure you want to continue?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.No)
                    {
                        _askConfirmationCharges = false;

                        this.txtAdditionalPaymentAmount.Focus();

                        this.tblCharges.SelectedIndex = _oldIndexChargesTab;

                        hasEnter = true;
                    }
                    else
                    {
                        _oldIndexChargesTab = this.tblCharges.SelectedIndex;

                        _askConfirmationCharges = true;

                        this.InitializeAdditionalPaymentControls();

                        this.ClearErrors();
                    }
                }
                else
                {
                    _oldIndexChargesTab = this.tblCharges.SelectedIndex;

                    _askConfirmationCharges = true;
                }
            }
            else if (isTabCharges && _oldIndexChargesTab == _tabStruct.F4Key)
            {
                if (_hasUpdatedOptionalFee && _askConfirmationCharges)
                {
                    String strMsg = "There are unrecorded student optional fee, changing the tab without recording it causes data loss.\n\n" +
                        "Are you sure you want to continue?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.No)
                    {
                        _askConfirmationCharges = false;

                        this.tblCharges.SelectedIndex = _oldIndexChargesTab;

                        hasEnter = true;
                    }
                    else
                    {
                        _oldIndexChargesTab = this.tblCharges.SelectedIndex;

                        _hasUpdatedOptionalFee = false;

                        _askConfirmationCharges = true;

                        _cashieringManager.ClearOptionalFeeTable();

                        this.InitializeSchoolFeeDetailsTable();

                        _cashieringManager.InitializeStudentChargesListView(this.lsvCurrentCharges, this.lblMenuCurrentCharges, _studentInfo.StudentSysId, true);

                        this.ClearErrors();
                    }
                }
                else
                {
                    _oldIndexChargesTab = this.tblCharges.SelectedIndex;

                    _askConfirmationCharges = true;
                }
            }

            if ((isCourse && !isYearLevel) && (!isYear && !isSemster))
            {
                if ((_hasUpdatedAdditionalFee || _hasUpdatedDiscount || _hasUpdatedOptionalFee) && _askConfirmationCharges)
                {
                    String strMsg = "There are unrecorded student optional fee/additional fee/discount, changing the course without" +
                        " recording it causes data loss.\n\n Are you sure you want to continue?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.No)
                    {
                        _askConfirmationCharges = false;

                        _hasSelectedNoCourseConfermation = true;

                        this.cboCourse.SelectedIndex = _oldIndexCourseCombo;

                        hasEnter = true;
                    }
                    else
                    {
                        _oldIndexCourseCombo = this.cboCourse.SelectedIndex;

                        _askConfirmationCharges = true;

                        if (_hasUpdatedDiscount)
                        {
                            this.InitializeDiscountControl();
                        }

                        _hasUpdatedAdditionalFee = _hasUpdatedDiscount = _hasUpdatedOptionalFee = false;

                        _hasSelectedNoCourseConfermation = false;

                        this.ClearErrors();
                    }
                }
                else
                {
                    _oldIndexCourseCombo = this.cboCourse.SelectedIndex;

                    _askConfirmationCharges = true;
                }
            }
            else if ((isYearLevel && !isCourse) && (!isYear && !isSemster))
            {
                if ((_hasUpdatedAdditionalFee || _hasUpdatedDiscount || _hasUpdatedOptionalFee) && _askConfirmationCharges)
                {
                    String strMsg = "There are unrecorded student optional fee/additional fee/discount, changing the year level" +
                        " without recording it causes data loss.\n\n Are you sure you want to continue?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.No)
                    {
                        _askConfirmationCharges = false;

                        _hasSelectedNoInYearLevelConfermation = true;

                        this.cboYearLevel.SelectedIndex = _oldIndexYearLevelCombo;

                        hasEnter = true;
                    }
                    else
                    {
                        _oldIndexYearLevelCombo = this.cboYearLevel.SelectedIndex;

                        _askConfirmationCharges = true;

                        if (_hasUpdatedDiscount)
                        {
                            this.InitializeDiscountControl();
                        }

                        _hasUpdatedAdditionalFee = _hasUpdatedDiscount = _hasUpdatedOptionalFee = false;

                        _hasSelectedNoInYearLevelConfermation = false;

                        this.InitializeAdditionalPaymentControls();

                        this.ClearErrors();
                    }
                }
                else
                {
                    _oldIndexYearLevelCombo = this.cboYearLevel.SelectedIndex;

                    _askConfirmationCharges = true;
                }
            }
            else if (isYear && (!isYearLevel && !isSemster))
            {
                if (isForCharges)
                {
                    if ((_hasUpdatedAdditionalFee || _hasUpdatedDiscount || _hasUpdatedOptionalFee) && _askConfirmationCharges)
                    {
                        String strMsg = "There are unrecorded student optional fee/additional fee/discount, changing the school year without" +
                            " recording it causes data loss.\n\n Are you sure you want to continue?";

                        DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (msgResult == DialogResult.No)
                        {
                            _askConfirmationCharges = false;

                            this.cboYear.SelectedIndex = _oldIndexYearCombo;

                            hasEnter = true;
                        }
                        else
                        {
                            _oldIndexYearCombo = this.cboYear.SelectedIndex;

                            _askConfirmationCharges = true;

                            _hasUpdatedOptionalFee = false;

                            this.InitializeAdditionalPaymentControls();
                            this.InitializeDiscountControl();

                            this.ClearErrors();
                        }
                    }
                    else if (!isForPayment)
                    {
                        _oldIndexYearCombo = this.cboYear.SelectedIndex;

                        _askConfirmationCharges = true;
                    }
                }

                if (isForPayment)
                {
                    if (_hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded && _askConfirmationPayment)
                    {
                        String strMsg = "There are unrecorded student payment/reimbursement/promissory note/credit memo/balance forwarded, changing tab without" +
                            " recording it causes data loss.\n\n Are you sure you want to continue?";

                        DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (msgResult == DialogResult.No)
                        {
                            _askConfirmationPayment = false;

                            _hasSelectedNoYearSemsterConfermation = true;

                            this.cboYear.SelectedIndex = _oldIndexYearCombo;

                            hasEnter = true;
                        }
                        else
                        {
                            _oldIndexYearCombo = this.cboYear.SelectedIndex;

                            _studentPaymentInfo.ReceiptDate = CashieringLogic.ReceiptDate;

                            this.lblReceiptDate.Text = DateTime.Parse(_studentPaymentInfo.ReceiptDate).ToLongDateString();

                            _hasSelectedNoYearSemsterConfermation = false;


                            this.InitializeStudentBalanceForwardedControls();

                            this.ClearErrors();
                        }
                    }
                    else
                    {
                        _oldIndexYearCombo = this.cboYear.SelectedIndex;

                        this.InitializeStudentPromissoryNoteControls();

                        _askConfirmationCharges = _askConfirmationPayment = true;
                    }
                }
            }
            else if (isSemster && (!isYearLevel && !isYear))
            {

                if (isForCharges)
                {
                    if ((_hasUpdatedAdditionalFee || _hasUpdatedDiscount || _hasUpdatedOptionalFee) && _askConfirmationCharges)
                    {
                        String strMsg = "There are unrecorded student additional fee/discount, changing the semester without recording it causes data loss.\n\n" +
                            "Are you sure you want to continue?";

                        DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (msgResult == DialogResult.No)
                        {
                            _askConfirmationCharges = false;
                          
                            this.cboSemester.SelectedIndex = _oldIndexSemeberCombo;

                            hasEnter = true;
                        }
                        else
                        {
                            _oldIndexSemeberCombo = this.cboSemester.SelectedIndex;

                            _askConfirmationCharges = true;

                            _hasUpdatedOptionalFee = false;

                            this.InitializeAdditionalPaymentControls();
                            this.InitializeDiscountControl();

                            this.ClearErrors();
                        }
                    }
                    else if (!isForPayment)
                    {
                        _oldIndexSemeberCombo = this.cboSemester.SelectedIndex;

                        _askConfirmationCharges = true;
                    }
                }

                if (isForPayment)
                {
                    if (_hasUpdatedPaymentReimbursementPromissoryNoteCreditMemoBalanceForwarded && _askConfirmationPayment)
                    {
                        String strMsg = "There are unrecorded student payment/reimbursement/promissory note/credit memo/balance forwarded, changing tab without" +
                            " recording it causes data loss.\n\n Are you sure you want to continue?";

                        DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (msgResult == DialogResult.No)
                        {
                            _askConfirmationPayment = false;

                            _hasSelectedNoYearSemsterConfermation = true;

                            this.cboSemester.SelectedIndex = _oldIndexSemeberCombo;

                            hasEnter = true;
                        }
                        else
                        {
                            _oldIndexSemeberCombo = this.cboSemester.SelectedIndex;

                            _studentPaymentInfo.ReceiptDate = CashieringLogic.ReceiptDate;

                            this.lblReceiptDate.Text = DateTime.Parse(_studentPaymentInfo.ReceiptDate).ToLongDateString();


                            _hasSelectedNoYearSemsterConfermation = false;

                            this.InitializeStudentPromissoryNoteControls();

                            this.InitializeStudentBalanceForwardedControls();

                            this.ClearErrors();
                        }
                    }
                    else
                    {
                        _oldIndexSemeberCombo = this.cboSemester.SelectedIndex;

                        _askConfirmationCharges = _askConfirmationPayment = true;
                    }
                }
            }

            if (!hasEnter)
                _askConfirmationCharges = true;
           
            return !hasEnter;
        }//-----------------------------
        #endregion
    }
}
