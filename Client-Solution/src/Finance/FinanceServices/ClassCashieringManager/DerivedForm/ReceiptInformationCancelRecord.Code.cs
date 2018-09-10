using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class ReceiptInformationCancelRecord
    {
        #region Class Properties Declaration
        private Boolean _hasRecorded = false;
        public Boolean HasRecorded
        {
            get { return _hasRecorded; }
        }
        #endregion

        #region Class Constructors
        public ReceiptInformationCancelRecord(CommonExchange.SysAccess userInfo, CashieringLogic cashieringManager,
            CommonExchange.MiscellaneousIncome miscellaneousIncomeInfo)
            :base(userInfo, cashieringManager, miscellaneousIncomeInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _cashieringManager = cashieringManager;
            _miscellaneousIncomeInfo = miscellaneousIncomeInfo;

            this.FormClosing += new FormClosingEventHandler(ClassClossing);
            this.btnCancel.Click += new EventHandler(btnCancelClick);
            this.btnProceed.Click += new EventHandler(btnProceedClick);
        }

        public ReceiptInformationCancelRecord(CommonExchange.SysAccess userInfo, CashieringLogic cashieringManager, 
            CommonExchange.StudentPayments studentPaymentInfo, CommonExchange.Student studentInfo, String dateEnd)
            :base(userInfo, cashieringManager, studentPaymentInfo, studentInfo, dateEnd)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _cashieringManager = cashieringManager;
            _studentPaymentInfo = studentPaymentInfo;
            _studentInfo = studentInfo;

            _dateEnd = dateEnd;

            this.FormClosing += new FormClosingEventHandler(ClassClossing);
            this.btnCancel.Click += new EventHandler(btnCancelClick);
            this.btnProceed.Click += new EventHandler(btnProceedClick);
        }

        public ReceiptInformationCancelRecord(CommonExchange.SysAccess userInfo, CashieringLogic cashieringManager, String receiptNumber, String receiptDate)
            : base(userInfo, cashieringManager, receiptNumber, receiptDate)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _cashieringManager = cashieringManager;

            _receiptNo = receiptNumber;

            this.FormClosing += new FormClosingEventHandler(ClassClossing);
            this.btnCancel.Click += new EventHandler(btnCancelClick);
            this.btnProceed.Click += new EventHandler(btnProceedClick);
        }
        #endregion

        #region Class Event Void Procedures
        //############################################CLASS ReceiptInformationCancelRecord EVENTS#######################################################
        //event is raised when the class is closing
        private void ClassClossing(object sender, FormClosingEventArgs e)
        {
            if (!_hasRecorded)
            {
                String strMsg = "Are you sure you want to cancel the cancelation of the receipt information?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//--------------------------
        //############################################END CLASS ReceiptInformationCancelRecord EVENTS#######################################################

        //##############################################BUTTON btnCancel EVENTS########################################################
        //event is raised when the button is clicked
        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }//-----------------------------
        //##############################################END BUTTON btnCancel EVENTS########################################################

        //###########################################LABEL lblReceiptDate EVENTS#####################################################
        //event is raised when the control is clicked
        protected override void lblReceiptDateClick(object sender, EventArgs e)
        {
            base.lblReceiptDateClick(sender, e);

            this.IsRecordLocked(DateTime.Parse(_canceldReceiptNoInfo.ReceiptDate), DateTime.Parse(_canceldReceiptNoInfo.DateCancelled));
        }//------------------
        //###########################################END LABEL lblReceiptDate EVENTS#####################################################

        //#############################################BUTTON btnProceed EVENTS########################################################
        //event is raised when the button is clicked
        private void btnProceedClick(object sender, EventArgs e)
        {
            if (_isFromReIssued)
            {
                _studentPaymentInfo.ReceiptNo = RemoteClient.ProcStatic.SixDigitZero(CashieringLogic.ReceiptNumber).ToString();
            }
            else if (_isFromMiscellaneousIncome)
            {
                _miscellaneousIncomeInfo.ReceiptNo = RemoteClient.ProcStatic.SixDigitZero(CashieringLogic.ReceiptNumber).ToString();
            }

            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to proceed the cancelation of the receipt number?";

                    if (_isFromReIssued)
                    {
                        strMsg += "\n\nIf you click YES, this will update the receipt number into " + _studentPaymentInfo.ReceiptNo + 
                            " and print a new official receipt.";
                    }
                    else if (_isFromMiscellaneousIncome)
                    {
                        strMsg += "\n\nIf you click YES, this will update the receipt number into " +  _miscellaneousIncomeInfo.ReceiptNo +
                            " and print a new official receipt.";
                    }

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Cancelation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The receipt number has been successfully canceled.";

                        this.Cursor = Cursors.WaitCursor;

                        if (_isFromReIssued)
                        {
                            _cashieringManager.UpdateStudentPayment(_userInfo, _studentPaymentInfo);

                            CashieringLogic.ReceiptNumber += 1;
                        }
                        else if (_isFromMiscellaneousIncome)
                        {
                            _cashieringManager.UpdateMiscellaneouseIncome(_userInfo, _miscellaneousIncomeInfo);

                            CashieringLogic.ReceiptNumber += 1;
                        }
                      
                        _cashieringManager.InsertCancelledReceiptNo(_userInfo, _canceldReceiptNoInfo);

                        if (_isFromReIssued)
                        {
                            long wholeNum = _cashieringManager.GetWholeNumberTenthDecimal(_studentPaymentInfo.Amount, true);
                            int decNum = (int)_cashieringManager.GetWholeNumberTenthDecimal(_studentPaymentInfo.Amount, false);

                            _cashieringManager.PrintReceiptNumberStudentPayments(_userInfo, _studentPaymentInfo, _studentInfo, _dateEnd, 
                                String.Empty, wholeNum, decNum);
                        }
                        else if (_isFromMiscellaneousIncome)
                        {
                            long wholeNum = _cashieringManager.GetWholeNumberTenthDecimal(_miscellaneousIncomeInfo.Amount, true);
                            int decNum = (int)_cashieringManager.GetWholeNumberTenthDecimal(_miscellaneousIncomeInfo.Amount, false);

                            _cashieringManager.PrintReceiptMiscellaneousIncome(_userInfo, _miscellaneousIncomeInfo, wholeNum, decNum);
                        }
                        
                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasRecorded = true;

                        this.Close();
                    }
                    else if (msgResult == DialogResult.Cancel)
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Cancelation");
                }
            }
        }//-------------------------
        //#############################################END BUTTON btnProceed EVENTS########################################################
        #endregion

        #region Programmer's Defined Void Procedures
        //this procedure will set record status
        //Code History: Priviews code calls (_cashieringManager.GetReflectedDate(<parameters>)) to supply the reflected date.
        //reflected date is delete because of the new record locking feature. (can backward payments more than 4 months)
        private void IsRecordLocked(DateTime receiptDate, DateTime dateCancelled)
        {
            if (RemoteClient.ProcStatic.IsRecordLocked((Int32)CommonExchange.SystemRange.ReceivedDateAllowance, receiptDate, dateCancelled,
              DateTime.Parse(_cashieringManager.ServerDateTime)))
            {
                this.btnProceed.Enabled = false;

                this.lblStatusPayment.Text = "This record is LOCKED";

                this.pbxLockedPayment.Visible = true;
                this.pbxUnlockPayment.Visible = false;
            }
            else
            {
                this.btnProceed.Enabled = true;

                this.lblStatusPayment.Text = "This record is OPEN";

                this.pbxLockedPayment.Visible = false;
                this.pbxUnlockPayment.Visible = true;
            }
        }//---------------------
        #endregion

    }
}
