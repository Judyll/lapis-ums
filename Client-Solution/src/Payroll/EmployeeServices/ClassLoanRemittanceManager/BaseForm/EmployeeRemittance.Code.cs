using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EmployeeServices
{
    partial class EmployeeRemittance
    {
        #region Class General Variable Declarations
        protected CommonExchange.SysAccess _userInfo;
        protected CommonExchange.Employee _empInfo;
        protected CommonExchange.LoanInformation _loanInfo;
        protected CommonExchange.EmployeeLoanRemittance _remInfo;
        protected LoanRemittanceLogic _loanManager;

        private ErrorProvider _errProvider;
        #endregion        

        #region Class Constructor
        public EmployeeRemittance()
        {
            InitializeComponent();

            _userInfo = new CommonExchange.SysAccess();
            _empInfo = new CommonExchange.Employee();
            _loanInfo = new CommonExchange.LoanInformation();
            _remInfo = new CommonExchange.EmployeeLoanRemittance();

            _errProvider = new ErrorProvider();

            this.lnkChangeDate.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkChangeDateLinkClicked);
            this.txtAmountPaid.KeyPress += new KeyPressEventHandler(txtAmountPaidKeyPress);
            this.txtAmountPaid.KeyUp += new KeyEventHandler(txtAmountPaidKeyUp);
            this.txtAmountPaid.Validating += new System.ComponentModel.CancelEventHandler(txtAmountPaidValidating);

        }
        
        #endregion

        #region Class Event Void Procedures
        //#####################################LINKLABEL lnkChangeDate EVENTS###############################################
        //event is raised when the link is clicked
        private void lnkChangeDateLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            DateTime bDate = DateTime.Parse(_remInfo.RemittanceDate);

            using (RemoteClient.DatePicker frmPicker = new RemoteClient.DatePicker(bDate))
            {
                frmPicker.ShowDialog(this);

                if (frmPicker.HasSelectedDate)
                {
                    if (DateTime.TryParse(frmPicker.GetSelectedDate.ToShortDateString() + " " +
                        DateTime.Parse(_loanManager.ServerDateTime).ToLongTimeString(), out bDate))
                    {
                        _remInfo.RemittanceDate = bDate.ToString("o");
                    }

                    lblRemittanceDate.Text = DateTime.Parse(_remInfo.RemittanceDate).ToLongDateString();
                }
            }

            this.Cursor = Cursors.Arrow;
        } //-----------------------------------
        //###################################END LINKLABEL lnkChangeDate EVENTS#############################################

        //#########################################TEXTBOX txtAmountPaid EVENTS#################################################
        //event is raised when the key is pressed
        private void txtAmountPaidKeyPress(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxAmountOnly(e);
        } //---------------------------------------

        //event is raised when the key is up
        private void txtAmountPaidKeyUp(object sender, KeyEventArgs e)
        {
            Decimal decTemp = 0;

            if (Decimal.TryParse(txtAmountPaid.Text, out decTemp) || String.IsNullOrEmpty(txtAmountPaid.Text))
            {
                _remInfo.AmountPaid = decTemp;
                _remInfo.AmountBalance = _loanManager.GetAmountBalance(_loanInfo, _remInfo.RemittanceId) - decTemp;

                txtAmountBalance.Text = _remInfo.AmountBalance.ToString("N");
            }

        } //------------------------------

        //event is raised when the control is validating
        private void txtAmountPaidValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxValidateAmount((TextBox)sender);

            Decimal decTemp = 0;

            if (Decimal.TryParse(txtAmountPaid.Text, out decTemp) || String.IsNullOrEmpty(txtAmountPaid.Text))
            {
                _remInfo.AmountPaid = decTemp;
                _remInfo.AmountBalance = _loanManager.GetAmountBalance(_loanInfo, _remInfo.RemittanceId) - decTemp;

                txtAmountBalance.Text = _remInfo.AmountBalance.ToString("N");
            }

        } //-------------------------------
        //########################################END TEXTBOX txtAmountPaid EVENTS##############################################

        #endregion

        #region Programmer-Defined Function Procedures
        //this function validates the controls
        protected Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(lnkChangeDate, "");
            _errProvider.SetError(txtAmountPaid, "");
            _errProvider.SetIconAlignment(txtAmountPaid, ErrorIconAlignment.MiddleLeft);
            _errProvider.SetError(txtAmountBalance, "");
            _errProvider.SetIconAlignment(txtAmountBalance, ErrorIconAlignment.MiddleLeft);

            if (!_loanManager.IsValidEmployeeRemittanceDate(_loanInfo, DateTime.Parse(_remInfo.RemittanceDate), _remInfo.RemittanceId))
            {
                _errProvider.SetError(lnkChangeDate, "The remittance date is invalid. Please check the existing employee remittance dates.");
                isValid = false;
            }

            Decimal decTemp = 0;

            if (Decimal.TryParse(txtAmountPaid.Text, out decTemp) && decTemp <= 0)
            {
                _errProvider.SetError(txtAmountPaid, "The amount paid must not be equal or lesser than zero.");
                isValid = false;
            }

            decTemp = 0;

            if (Decimal.TryParse(txtAmountBalance.Text, out decTemp) && decTemp < 0)
            {
                _errProvider.SetError(txtAmountBalance, "The amount balance must be greater or equal to zero.");
                isValid = false;
            }

            return isValid;
        } //---------------------------------
        #endregion
    }
}
