using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class ReceiptNumberInformation
    {
        #region Class Data Member Declaration
        protected CommonExchange.SysAccess _userInfo;
        protected CommonExchange.CancelledReceiptNo _canceldReceiptNoInfo;
        protected CommonExchange.StudentPayments _studentPaymentInfo;
        protected CommonExchange.Student _studentInfo;
        protected CommonExchange.MiscellaneousIncome _miscellaneousIncomeInfo;
        protected CashieringLogic _cashieringManager;

        protected String _dateEnd;
        protected String _receiptNo;
        protected String _receiptDate;

        private ErrorProvider _errProvider;
        #endregion

        #region Class Properties Declaration
        protected Boolean _isFromReIssued = false;
        public Boolean IsFromReIssued
        {
            set { _isFromReIssued = value; }
        }

        protected Boolean _isFromMiscellaneousIncome = false;
        public Boolean IsFromMiscellaneousIncome
        {
            set { _isFromMiscellaneousIncome = value; }
        }
        #endregion

        #region Class Constructors
        public ReceiptNumberInformation()
        {
            this.InitializeComponent();
        }

        public ReceiptNumberInformation(CommonExchange.SysAccess userInfo, CashieringLogic cashieringManager,
            CommonExchange.MiscellaneousIncome miscellaneousIncomeInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _cashieringManager = cashieringManager;
            _miscellaneousIncomeInfo = miscellaneousIncomeInfo;

            _errProvider = new ErrorProvider();

            this.Load += new EventHandler(ClassLoad);
            this.txtRemarks.Validated += new EventHandler(txtRemarksValidated);
            this.lblReceiptDate.Click += new EventHandler(lblReceiptDateClick);
        }

        public ReceiptNumberInformation(CommonExchange.SysAccess userInfo, CashieringLogic cashieringManager, 
            CommonExchange.StudentPayments studentPaymentInfo, CommonExchange.Student studentInfo, String dateEnd)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _cashieringManager = cashieringManager;
            _studentInfo = studentInfo;
            _studentPaymentInfo = studentPaymentInfo;

            _dateEnd = dateEnd;

            _errProvider = new ErrorProvider();

            this.Load += new EventHandler(ClassLoad);
            this.txtRemarks.Validated += new EventHandler(txtRemarksValidated);
            this.lblReceiptDate.Click += new EventHandler(lblReceiptDateClick);
        }

        public ReceiptNumberInformation(CommonExchange.SysAccess userInfo, CashieringLogic cashieringManager, String receiptNo, String receiptDate)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _cashieringManager = cashieringManager;
            _receiptNo = receiptNo;
            _receiptDate = receiptDate;

            _errProvider = new ErrorProvider();

            _canceldReceiptNoInfo = new CommonExchange.CancelledReceiptNo();

            _canceldReceiptNoInfo.ReceiptNo = _receiptNo;
            _canceldReceiptNoInfo.ReceiptDate = _receiptDate;

            this.Load += new EventHandler(ClassLoad);
            this.txtRemarks.Validated += new EventHandler(txtRemarksValidated);
            this.lblReceiptDate.Click += new EventHandler(lblReceiptDateClick);
        }

        public ReceiptNumberInformation(CommonExchange.SysAccess userInfo, CashieringLogic cashieringManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _cashieringManager = cashieringManager;
        
            _errProvider = new ErrorProvider();

            this.Load += new EventHandler(ClassLoad);
            this.txtRemarks.Validated += new EventHandler(txtRemarksValidated);
            this.lblReceiptDate.Click += new EventHandler(lblReceiptDateClick);
        }
        #endregion

        #region Class Event Void Procedures
        //###########################################CLASS ReceiptNumberInformation EVENTS#####################################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            _canceldReceiptNoInfo = new CommonExchange.CancelledReceiptNo();

            if (_isFromReIssued)
            {
                _canceldReceiptNoInfo.ReceiptNo = _studentPaymentInfo.ReceiptNo;
                _canceldReceiptNoInfo.ReceiptDate = _studentPaymentInfo.ReceiptDate;
            }
            else if (_isFromMiscellaneousIncome)
            {
                _canceldReceiptNoInfo.ReceiptNo = _miscellaneousIncomeInfo.ReceiptNo;
                _canceldReceiptNoInfo.ReceiptDate = _miscellaneousIncomeInfo.ReceiptDate;
            }
            else
            {
                _canceldReceiptNoInfo.ReceiptNo = _receiptNo;
                _canceldReceiptNoInfo.ReceiptDate = _receiptDate;
            }            
                        
            this.lblReceiptNumber.Text = _canceldReceiptNoInfo.ReceiptNo;

            if (!String.IsNullOrEmpty(_canceldReceiptNoInfo.ReceiptDate))
            {
                this.lblReceiptDate.Text = DateTime.Parse(_canceldReceiptNoInfo.ReceiptDate).ToLongDateString();
            }

            if (String.IsNullOrEmpty(_canceldReceiptNoInfo.DateCancelled))
            {
                this.lblDateCancelled.Text = _canceldReceiptNoInfo.DateCancelled = DateTime.Parse(_cashieringManager.ServerDateTime).ToLongDateString();
            }
            else
            {
                this.lblDateCancelled.Text = DateTime.Parse(_canceldReceiptNoInfo.DateCancelled).ToLongDateString();
            }
        }//-----------------------------
        //###########################################END CLASS ReceiptNumberInformation EVENTS#####################################################

        //###########################################TEXTBOX txtRemarks EVENTS#####################################################
        //event is raised when the class is loaded
        private void txtRemarksValidated(object sender, EventArgs e)
        {
            _canceldReceiptNoInfo.Remarks = RemoteClient.ProcStatic.TrimStartEndString(this.txtRemarks.Text);
        }//-----------------------------
        //###########################################END TEXTBOX txtRemarks EVENTS#####################################################

        //###########################################LABEL lblReceiptDate EVENTS#####################################################
        //event is raised when the control is clicked
        protected virtual void lblReceiptDateClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            DateTime receiptDate = DateTime.MinValue;

            if (String.IsNullOrEmpty(_canceldReceiptNoInfo.ReceiptDate))
            {
                receiptDate = DateTime.Parse(CashieringLogic.ReceiptDate);
            }
            else
            {
                receiptDate = DateTime.Parse(_canceldReceiptNoInfo.ReceiptDate);
            }

            using (RemoteClient.DatePicker frmPicker = new RemoteClient.DatePicker(receiptDate))
            {
                frmPicker.ShowDialog(this);

                if (frmPicker.HasSelectedDate)
                {
                    if (DateTime.TryParse(frmPicker.GetSelectedDate.ToLongDateString() + " " +
                            DateTime.Parse(_cashieringManager.ServerDateTime).ToLongTimeString(), out receiptDate))
                    {
                        _canceldReceiptNoInfo.ReceiptDate = receiptDate.ToShortDateString() + " 12:00:00 AM";
                    }

                    this.lblReceiptDate.Text = receiptDate.ToLongDateString();                  
                }
            }

            this.Cursor = Cursors.Arrow;
        }//------------------
        //###########################################END LABEL lblReceiptDate EVENTS#####################################################
        #endregion
       
        #region Programmers-Defined Functions
        //this fucntion will validate controls
        public Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.lblReceiptNumber, String.Empty);
            
            if (String.IsNullOrEmpty(_canceldReceiptNoInfo.ReceiptNo))
            {
                _errProvider.SetError(this.lblReceiptNumber, "You must select a receipt information");
                _errProvider.SetIconAlignment(this.lblReceiptNumber, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            if (_isFromReIssued)
            {
                using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
                {
                    if (remClient.IsExistsReceiptNoStudentPayments(_userInfo, _studentPaymentInfo.PaymentId, _studentPaymentInfo.ReceiptNo))
                    {
                        _errProvider.SetError(this.lblReceiptNumber, "The new receipt number is already exist [" + _studentPaymentInfo.ReceiptNo + "]");
                        _errProvider.SetIconAlignment(this.lblReceiptNumber, ErrorIconAlignment.MiddleRight);

                        isValid = false;
                    }
                }
            }
            else if (_isFromMiscellaneousIncome)
            {
                using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
                {
                    if (remClient.IsExistsReceiptNoStudentPayments(_userInfo, _miscellaneousIncomeInfo.PaymentId, _miscellaneousIncomeInfo.ReceiptNo))
                    {
                        _errProvider.SetError(this.lblReceiptNumber, "The new receipt number is already exist [" + _miscellaneousIncomeInfo.ReceiptNo + "]");
                        _errProvider.SetIconAlignment(this.lblReceiptNumber, ErrorIconAlignment.MiddleRight);

                        isValid = false;
                    }
                }
            }

            return isValid;
        }//----------------------
        #endregion
    }
}
