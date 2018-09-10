using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class BreakDownBankDeposit
    {
        #region Class Data Member Decleration
        protected CommonExchange.SysAccess _userInfo;
        protected CommonExchange.BreakdownBankDeposit _breakDownDepositInfo;
        protected CashieringLogic _cashieringManager;

        private ErrorProvider _errProvider;

        private String _dateStart = String.Empty;
        private String _dateEnd = String.Empty;
        #endregion

        #region Class Constructors
        public BreakDownBankDeposit()
        {
            this.InitializeComponent();
        }

        public BreakDownBankDeposit(CommonExchange.SysAccess userInfo, CashieringLogic cashieringManager, String dateStart, String dateEnd)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _cashieringManager = cashieringManager;

            _dateStart = dateStart;
            _dateEnd = dateEnd;

            _errProvider = new ErrorProvider();

            this.Load += new EventHandler(ClassLoad);
            this.txtAmount.KeyPress += new KeyPressEventHandler(txtAmountKeyPress);
            this.txtAmount.Validating += new System.ComponentModel.CancelEventHandler(txtAmountValidating);
            this.txtAmount.Validated += new EventHandler(txtAmountValidated);
            this.btnSearchedAccountTitle.Click += new EventHandler(btnSearchedAccountTitleClick);
        }
        #endregion

        #region Class Event Void Procedures
        //###########################################CLASS BreakDownBankDeposit EVENTS#####################################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            _breakDownDepositInfo = new CommonExchange.BreakdownBankDeposit();

            this.dtpStart.Value = DateTime.Parse(_dateStart);
            this.dtpEnd.Value = DateTime.Parse(_dateEnd);

            _breakDownDepositInfo.DateStart = this.dtpStart.Value.ToShortDateString() + " 12:00:00 AM";
            _breakDownDepositInfo.DateEnd = this.dtpEnd.Value.ToShortDateString() + " 11:59:59 PM";
        }//----------------------
        //###########################################END CLASS BreakDownBankDeposit EVENTS#####################################################

        //###########################################TEXTBOX txtAmount EVENTS#####################################################
        //event is raised when the control is validated
        private void txtAmountValidated(object sender, EventArgs e)
        {
            Decimal amount = 0;

            if (Decimal.TryParse(this.txtAmount.Text, out amount))
            {
                _breakDownDepositInfo.Amount = amount;
            }
        }//---------------------

        //event is raised when the control is validating
        private void txtAmountValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxValidateAmount((TextBox)sender);
        }//------------------

        //event is raised when the control key is pressed
        private void txtAmountKeyPress(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxAmountOnly(e);
        }//------------------
        //###########################################END TEXTBOX txtAmount EVENTS#####################################################

        //###########################################BUTTON btnSearchedAccountTitle EVENTS#####################################################
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
                        _breakDownDepositInfo.AccountInfo  = _cashieringManager.MiscellaneousChartOfAccountInfo =
                            _cashieringManager.GetChartOfAccountInformation(frmSearch.PrimaryId);

                        this.txtCreditEntry.Text = !String.IsNullOrEmpty(_breakDownDepositInfo.AccountInfo.AccountSysId) ?
                            _breakDownDepositInfo.AccountInfo.AccountCode + " - " + _breakDownDepositInfo.AccountInfo.AccountName : String.Empty;
                    }
                }

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }
        }//----------------------
        //###########################################END BUTTON btnSearchedAccountTitle EVENTS#####################################################
        #endregion

        #region Programmer's Defined Functions
        //this function will validate controls
        public Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.gbxDateRage, String.Empty);
            _errProvider.SetError(this.txtAmount, String.Empty);
            _errProvider.SetError(this.txtCreditEntry, String.Empty);

            if (DateTime.Compare(DateTime.Parse(_breakDownDepositInfo.DateStart), DateTime.Parse(_breakDownDepositInfo.DateEnd)) > 0)
            {
                _errProvider.SetError(this.gbxDateRage, "Date start must me greater than date end.");
                _errProvider.SetIconAlignment(this.gbxDateRage, ErrorIconAlignment.MiddleLeft);

                isValid = false;
            }

            if (_breakDownDepositInfo.Amount <= 0)
            {
                _errProvider.SetError(this.txtAmount, "Amout must be greater than zero.");
                _errProvider.SetIconAlignment(this.txtAmount, ErrorIconAlignment.MiddleLeft);

                isValid = false;
            }

            if (String.IsNullOrEmpty(_breakDownDepositInfo.AccountInfo.AccountSysId))
            {
                _errProvider.SetError(this.txtCreditEntry, "Account entry is required.");
                _errProvider.SetIconAlignment(this.txtCreditEntry, ErrorIconAlignment.MiddleLeft);

                isValid = false;
            }
          
            return isValid;
        }//---------------------
        #endregion
    }
}
