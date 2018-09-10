using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EmployeeServices
{
    partial class LoanInformation
    {
        #region Class General Variable Declarations
        protected CommonExchange.SysAccess _userInfo;
        protected CommonExchange.Employee _empInfo;
        protected CommonExchange.LoanInformation _loanInfo;
        protected LoanRemittanceLogic _loanManager;

        private ErrorProvider _errProvider;
        #endregion        

        #region Class Constructor
        public LoanInformation()
        {
            InitializeComponent();

            _userInfo = new CommonExchange.SysAccess();
            _empInfo = new CommonExchange.Employee();
            _loanInfo = new CommonExchange.LoanInformation();

            _errProvider = new ErrorProvider();

            this.txtReferenceNo.Validated += new EventHandler(txtReferenceNoValidated);
            this.txtPrincipal.KeyPress += new KeyPressEventHandler(txtPrincipalKeyPress);
            this.txtPrincipal.Validating += new System.ComponentModel.CancelEventHandler(txtPrincipalValidating);            
            this.txtPrincipal.Validated += new EventHandler(txtPrincipalValidated);
            this.txtMonthlyAmmortization.KeyPress += new KeyPressEventHandler(txtMonthlyAmmortizationKeyPress);
            this.txtMonthlyAmmortization.Validating += new System.ComponentModel.CancelEventHandler(txtMonthlyAmmortizationValidating);
            this.txtMonthlyAmmortization.Validated += new EventHandler(txtMonthlyAmmortizationValidated);
            this.lnkReleaseDate.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkReleaseDateLinkClicked);
            this.lnkMaturityDate.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkMaturityDateLinkClicked);
            this.cboLoanType.SelectedIndexChanged += new EventHandler(cboLoanTypeSelectedIndexChanged);            
        }
                
        #endregion

        #region Class Event Void Procedures

        //########################################TEXTBOX txtReferenceNo EVENTS###########################################
        //event is raised when the control is validated
        private void txtReferenceNoValidated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtReferenceNo.Text))
            {
                _loanInfo.ReferenceNo = RemoteClient.ProcStatic.TrimStartEndString(txtReferenceNo.Text);
            }
        } //----------------------------      
        //######################################END TEXTBOX txtReferenceNo EVENTS##########################################

        //####################################TEXTBOX txtPrincipal EVENTS###############################################
        //event is raised when the key is pressed
        private void txtPrincipalKeyPress(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxAmountOnly(e);
        } //-------------------------------

        //event is raised when the textbox is validating
        private void txtPrincipalValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxValidateAmount((TextBox)sender);
        } //-------------------------------

        //event is raised when the textbox is validated
        private void txtPrincipalValidated(object sender, EventArgs e)
        {
            Decimal decTemp = 0;

            if (Decimal.TryParse(txtPrincipal.Text, out decTemp))
            {
                _loanInfo.PrincipalInterest = decTemp;
            }
        } //-----------------------------

        //###################################END TEXTBOX txtPrincipal EVENTS############################################

        //###########################################TEXTBOX txtMonthlyAmmortization EVENTS##################################
        //event is raised when the control is validated
        private void txtMonthlyAmmortizationValidated(object sender, EventArgs e)
        {
            Decimal decTemp = 0;

            if (Decimal.TryParse(txtMonthlyAmmortization.Text, out decTemp))
            {
                _loanInfo.MonthlyAmmortization = decTemp;
            }
        } //--------------------------------

        //event is raised when the control is validating
        private void txtMonthlyAmmortizationValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxValidateAmount((TextBox)sender);   
        } //----------------------------

        //event is raised when the key is pressed
        private void txtMonthlyAmmortizationKeyPress(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxAmountOnly(e);
        } //-----------------------------------
        //########################################END TEXTBOX txtMonthlyAmmortization EVENTS###################################

        //######################################LINKLABEL lnkReleaseDate EVENTS#############################################
        //event is raised when the link is clicked
        private void lnkReleaseDateLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            DateTime bDate = DateTime.Parse(_loanInfo.ReleaseDate);

            using (RemoteClient.DatePicker frmPicker = new RemoteClient.DatePicker(bDate))
            {
                frmPicker.ShowDialog(this);

                if (frmPicker.HasSelectedDate)
                {
                    if (DateTime.TryParse(frmPicker.GetSelectedDate.ToShortDateString() + " " +
                        DateTime.Parse(_loanManager.ServerDateTime).ToLongTimeString(), out bDate))
                    {
                        _loanInfo.ReleaseDate = bDate.ToString("o");
                        _loanInfo.MaturityDate = _loanManager.GetProposedMaturityDate(bDate).ToString("o");
                    }

                    lblReleaseDate.Text = DateTime.Parse(_loanInfo.ReleaseDate).ToLongDateString();
                    lblMaturityDate.Text = DateTime.Parse(_loanInfo.MaturityDate).ToLongDateString();
                }
            }

            this.Cursor = Cursors.Arrow;

        } //-------------------------------
        //#####################################END LINKLABEL lnkReleaseDate EVENTS###########################################

        //#########################################LINKLABEL lnkMaturityDate EVENTS###########################################
        //event is raised when the link is clicked
        private void lnkMaturityDateLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            DateTime bDate = DateTime.Parse(_loanInfo.MaturityDate);

            using (RemoteClient.DatePicker frmPicker = new RemoteClient.DatePicker(bDate))
            {
                frmPicker.ShowDialog(this);

                if (frmPicker.HasSelectedDate)
                {
                    if (DateTime.TryParse(frmPicker.GetSelectedDate.ToShortDateString() + " " +
                        DateTime.Parse(_loanManager.ServerDateTime).ToLongTimeString(), out bDate))
                    {
                        if (DateTime.Compare(bDate, DateTime.Parse(_loanInfo.ReleaseDate)) > 0)
                        {
                            _loanInfo.MaturityDate = bDate.ToString("o");
                        }
                    }

                    lblMaturityDate.Text = DateTime.Parse(_loanInfo.MaturityDate).ToLongDateString();
                }
            }

            this.Cursor = Cursors.Arrow;

        } //----------------------------------
        //#######################################END LINKLABEL lnkMaturityDate EVENTS##########################################

        //###########################################COMBOBOX cboLoanType EVENTS##################################################
        //event is raised when the selected index is changed
        private void cboLoanTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            _loanInfo.LoanSysId = _loanManager.GetLoanTypeId(cboLoanType.SelectedIndex);
            _loanInfo.Description = cboLoanType.Items[cboLoanType.SelectedIndex].ToString();
        } //---------------------------------------
        //##########################################END COMBOBOX cboLoanType EVENTS################################################
        
        #endregion

        #region Programmer-Defined Function Procedures
        //this function validates the controls
        protected Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(lnkMaturityDate, "");
            _errProvider.SetError(cboLoanType, "");
            _errProvider.SetError(txtPrincipal, "");
            _errProvider.SetError(txtMonthlyAmmortization, "");

            if (!_loanManager.IsValidLoanMaturityDate(DateTime.Parse(_loanInfo.ReleaseDate), DateTime.Parse(_loanInfo.MaturityDate)))
            {
                _errProvider.SetError(lnkMaturityDate, "The maturity date is not valid.");
                isValid = false;   
            }

            if (cboLoanType.SelectedIndex < 0)
            {
                _errProvider.SetError(cboLoanType, "Please select a loan type.");
                isValid = false;
            }

            Decimal principalTemp = 0;

            if (Decimal.TryParse(txtPrincipal.Text, out principalTemp) && principalTemp <= 0)
            {
                _errProvider.SetError(txtPrincipal, "The principal amount with interest must not be equal or lesser than zero.");
                isValid = false;
            }

            Decimal monthTemp = 0;

            if (Decimal.TryParse(txtPrincipal.Text, out principalTemp) && Decimal.TryParse(txtMonthlyAmmortization.Text, out monthTemp) && 
                ((principalTemp - monthTemp) < 0))
            {
                _errProvider.SetError(txtMonthlyAmmortization, "The monthly ammortization amount must be lesser or equal to the principal with interest amount.");
                isValid = false;
            }

            return isValid;
        } //------------------------
        #endregion
    }
}
