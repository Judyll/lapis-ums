using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace AccountingServices
{
    partial class ChartOfAccount
    {
        #region Class Data Member Declaration
        protected CommonExchange.SysAccess _userInfo;
        protected CommonExchange.ChartOfAccount _chartOfAccountInfo;

        protected ChartOfAccountLogic _chartOfAccountManager;

        private ErrorProvider _errProvider;

        private ToolTip _toolTip;
        #endregion

        #region Class Constructors
        public ChartOfAccount()
        {
            this.InitializeComponent();
        }

        public ChartOfAccount(CommonExchange.SysAccess userInfo, ChartOfAccountLogic chartOfAccountManager)
        {

            this.InitializeComponent();

            _userInfo = userInfo;
            _chartOfAccountManager = chartOfAccountManager;

            _errProvider = new ErrorProvider();

            _toolTip = new ToolTip();

            _toolTip.SetToolTip(this.btnSearchSummaryAccount, "Search summary account");
            _toolTip.SetToolTip(this.btnClearSummaryAccount, "Delete summary account");

            this.Load += new EventHandler(ClassLoad);
            this.cboAccountCategory.SelectedIndexChanged += new EventHandler(cboAccountCategorySelectedIndexChanged);
            this.txtAccountCode.Validated += new EventHandler(txtAccountCodeValidated);
            this.txtAccountName.Validated += new EventHandler(txtAccountNameValidated);
            this.txtAccountDescription.Validated += new EventHandler(txtAccountDescriptionValidated);
            this.txtCompanyPolicy.Validated += new EventHandler(txtCompanyPolicyValidated);
            this.rdbYesDebitSide.CheckedChanged += new EventHandler(rdbIsDebitIncreaseCheckedChanged);
            this.rdbNoDebitSide.CheckedChanged += new EventHandler(rdbNoDebitSideCheckedChanged);
            this.rdbYesActiveAccount.CheckedChanged += new EventHandler(rdbYesActiveAccountCheckedChanged);
            this.rdbNoActiveAccount.CheckedChanged += new EventHandler(rdbNoActiveAccountCheckedChanged);
            this.btnSearchSummaryAccount.Click += new EventHandler(btnSearchSummaryAccountClick);
            this.btnClearSummaryAccount.Click += new EventHandler(btnClearSummaryAccountClick);
        }
        #endregion

        #region Class Event Void Procedures
        //###############################################CLASS ChartOfAccount EVENTS##################################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            _chartOfAccountInfo = new CommonExchange.ChartOfAccount();

            _chartOfAccountManager.InitializeAccountCategoryComboBox(this.cboAccountCategory);

            _chartOfAccountInfo.IsActiveAccount = true;
        }//--------------------
        //###############################################END CLASS ChartOfAccount EVENTS##################################################

        //##################################COMBOBOX cboAccountCategory EVENTS##########################################################
        //event is raised when the selected index is changed
        private void cboAccountCategorySelectedIndexChanged(object sender, EventArgs e)
        {
            _chartOfAccountInfo.AccountingCategoryInfo = _chartOfAccountManager.GetDetailsAccountingCategory(this.cboAccountCategory.SelectedIndex);
        }//---------------------
        //##################################END COMBOBOX cboAccountCategory EVENTS##########################################################

        //##################################TEXTBOX txtCompanyPolicy EVENTS##########################################################
        //event is raised when the control is validated
        private void txtCompanyPolicyValidated(object sender, EventArgs e)
        {
            _chartOfAccountInfo.CompanyPolicyProcedure = RemoteClient.ProcStatic.TrimStartEndString(this.txtCompanyPolicy.Text);
        }//---------------------
        //##################################END TEXTBOX txtCompanyPolicy EVENTS##########################################################

        //##################################TEXTBOX txtAccountDescription EVENTS##########################################################
        //event is raised when the control is validated
        private void txtAccountDescriptionValidated(object sender, EventArgs e)
        {
            _chartOfAccountInfo.AccountDescription = RemoteClient.ProcStatic.TrimStartEndString(this.txtAccountDescription.Text);
        }//---------------------
        //##################################END TEXTBOX txtAccountDescription EVENTS##########################################################

        //##################################TEXTBOX txtAccountName EVENTS##########################################################
        //event is raised when the control is validated
        private void txtAccountNameValidated(object sender, EventArgs e)
        {
            _chartOfAccountInfo.AccountName = RemoteClient.ProcStatic.TrimStartEndString(this.txtAccountName.Text);
        }//-------------------
        //##################################END TEXTBOX txtAccountName EVENTS##########################################################

        //##################################TEXTBOX txtAccountCode EVENTS##########################################################
        //event is raised when the control is validated
        private void txtAccountCodeValidated(object sender, EventArgs e)
        {
            _chartOfAccountInfo.AccountCode = RemoteClient.ProcStatic.TrimStartEndString(this.txtAccountCode.Text);
        }//-------------------
        //##################################END TEXTBOX txtAccountCode EVENTS##########################################################

        //##################################RADIOBUTTON rdbIsDebitSideIncrease EVENTS##########################################################
        //event is raised when the control checked state is changed
        private void rdbIsDebitIncreaseCheckedChanged(object sender, EventArgs e)
        {
            _chartOfAccountInfo.IsDebitSideIncrease = this.rdbYesDebitSide.Checked ? true : false;
        }//-------------------
        //##################################END RADIOBUTTON rdbIsDebitSideIncrease EVENTS##########################################################

        //##################################RADIOBUTTON rdbNoDebitSideChecked EVENTS##########################################################
        //event is raised when the control checked state is changed
        private void rdbNoDebitSideCheckedChanged(object sender, EventArgs e)
        {
            _chartOfAccountInfo.IsDebitSideIncrease = this.rdbNoDebitSide.Checked ? false : true;
        }//-----------------
        //##################################END RADIOBUTTON rdbNoDebitSideChecked EVENTS##########################################################

        //##################################RADIOBUTTON rdbYesActiveAccount EVENTS##########################################################
        //event is raised when the control checked state is changed
        private void rdbYesActiveAccountCheckedChanged(object sender, EventArgs e)
        {
            _chartOfAccountInfo.IsActiveAccount = this.rdbYesActiveAccount.Checked ? true : false;
        }//---------------
        //##################################END RADIOBUTTON rdbYesActiveAccount EVENTS##########################################################

        //##################################RADIOBUTTON rdbNoActiveAccount EVENTS##########################################################
        //event is raised when the control checked state is changed
        private void rdbNoActiveAccountCheckedChanged(object sender, EventArgs e)
        {
            _chartOfAccountInfo.IsActiveAccount = this.rdbNoActiveAccount.Checked ? false : true;
        }//--------------
        //##################################END RADIOBUTTON rdbNoActiveAccount EVENTS##########################################################

        //##################################BUTTON btnSearchSummaryAccount EVENTS##########################################################
        //event is raised when the control is clicked
        private void btnSearchSummaryAccountClick(object sender, EventArgs e)
        {
            using (ChartOfAccountsSearchedOnTextBoxList frmSearch = new ChartOfAccountsSearchedOnTextBoxList(_userInfo, _chartOfAccountManager, false))
            {
                frmSearch.AdoptGridSize = false;
                frmSearch.ShowDialog(this);

                if (frmSearch.HasSelected)
                {
                    _chartOfAccountInfo.SummaryAccount = _chartOfAccountManager.GetDetailsSummaryOfAccount(frmSearch.PrimaryId);

                    this.txtSummaryAccount.Text = _chartOfAccountInfo.SummaryAccount.AccountCode + "  (" + _chartOfAccountInfo.SummaryAccount.AccountName + ")";

                    this.AssignControlValues();
                }
            }
        }//-------------------
        //##################################END BUTTON btnSearchSummaryAccount EVENTS##########################################################

        //##################################BUTTON btnClearSummaryAccount EVENTS##########################################################
        //event is raised when the control is clicked
        private void btnClearSummaryAccountClick(object sender, EventArgs e)
        {
            String strMsg = "Are you sure you want to delete the summary account information?";

            DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msgResult == DialogResult.Yes)
            {
                strMsg = "The summary account information has been successfully deleted.";

                CommonExchange.SummaryAccount summaryAccountInfo = new CommonExchange.SummaryAccount();

                _chartOfAccountInfo.SummaryAccount = summaryAccountInfo;

                this.AssignControlValues();

                MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }            
        }//-------------------
        //##################################END BUTTON btnClearSummaryAccount EVENTS##########################################################
        #endregion

        #region Programmer's Defined Void Procedures
        //this procedure will assigned controls values
        public void AssignControlValues()
        {
            if (!String.IsNullOrEmpty(_chartOfAccountInfo.SummaryAccount.AccountSysId))
            {
                this.txtSummaryAccount.Text = _chartOfAccountInfo.SummaryAccount.AccountCode + "  (" + _chartOfAccountInfo.SummaryAccount.AccountName + ")";

                this.pnlDebitSide.Enabled = false;
            }
            else
            {
                this.txtSummaryAccount.Clear();

                this.pnlDebitSide.Enabled = true;
            }

            this.txtAccountCode.Text = _chartOfAccountInfo.AccountCode;
            this.txtAccountName.Text = _chartOfAccountInfo.AccountName;
            this.txtAccountDescription.Text = _chartOfAccountInfo.AccountDescription;
            this.txtCompanyPolicy.Text = _chartOfAccountInfo.CompanyPolicyProcedure;

            this.rdbYesDebitSide.Checked = _chartOfAccountInfo.IsDebitSideIncrease ? true : false;
            this.rdbNoDebitSide.Checked = _chartOfAccountInfo.IsDebitSideIncrease ? false : true;

            this.rdbYesActiveAccount.Checked = _chartOfAccountInfo.IsActiveAccount ? true : false;
            this.rdbNoActiveAccount.Checked = _chartOfAccountInfo.IsActiveAccount ? false : true;
        }//----------------------
        #endregion

        #region Programmer's Defined Functions
        //this function will validate controls
        public Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.cboAccountCategory, String.Empty);
            _errProvider.SetError(this.txtAccountCode, String.Empty);
            _errProvider.SetError(this.txtAccountName, String.Empty);
            _errProvider.SetError(this.btnSearchSummaryAccount, String.Empty);

            if (String.IsNullOrEmpty(_chartOfAccountInfo.AccountingCategoryInfo.AccountingCategoryId))
            {
                _errProvider.SetError(this.cboAccountCategory, "You must select a account category information.");
                _errProvider.SetIconAlignment(this.cboAccountCategory, ErrorIconAlignment.MiddleLeft);

                isValid = false;
            }

            if (String.IsNullOrEmpty(_chartOfAccountInfo.AccountCode))
            {
                _errProvider.SetError(this.txtAccountCode, "Account Code is required.");
                _errProvider.SetIconAlignment(this.txtAccountCode, ErrorIconAlignment.MiddleLeft);

                isValid = false;
            }
            else if (_chartOfAccountManager.IsExistsAccountCodeChartOfAccount(_userInfo, _chartOfAccountInfo.AccountSysId, _chartOfAccountInfo.AccountCode, 
                _chartOfAccountInfo.SummaryAccount.AccountSysId))
            {
                _errProvider.SetError(this.txtAccountCode, "Account Code already exist.");
                _errProvider.SetIconAlignment(this.txtAccountCode, ErrorIconAlignment.MiddleLeft);

                isValid = false;
            }

            if (String.IsNullOrEmpty(_chartOfAccountInfo.AccountName))
            {
                _errProvider.SetError(this.txtAccountName, "Account Name is required.");
                _errProvider.SetIconAlignment(this.txtAccountName, ErrorIconAlignment.MiddleLeft);

                isValid = false;
            }
           
            if (!String.IsNullOrEmpty(_chartOfAccountInfo.SummaryAccount.AccountSysId) &&
                !_chartOfAccountManager.IsValidCategoryBySummaryAccountChartOfAccount(_userInfo, _chartOfAccountInfo.AccountingCategoryInfo.AccountingCategoryId,
                _chartOfAccountInfo.SummaryAccount.AccountSysId))
            {
                _errProvider.SetError(this.btnSearchSummaryAccount, "Summary of Account is not valid.");
                _errProvider.SetIconAlignment(this.btnSearchSummaryAccount, ErrorIconAlignment.MiddleLeft);

                isValid = false;
            }

            return isValid;
        }//--------------------
        #endregion


    }
}
