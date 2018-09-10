using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EmployeeServices
{
    partial class EmployeeRemittanceCreate
    {
        #region Class Properties Declarations
        private Boolean _hasCreated = false;
        public Boolean HasCreated
        {
            get { return _hasCreated; }
        }
        #endregion

        #region Class Constructor
        public EmployeeRemittanceCreate(CommonExchange.SysAccess userInfo, CommonExchange.Employee empInfo,
                                        CommonExchange.LoanInformation loanInfo, LoanRemittanceLogic loanManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _empInfo = empInfo;
            _loanInfo = loanInfo;
            _loanManager = loanManager;

            this.Load += new EventHandler(ClassLoad);
            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnCancel.Click += new EventHandler(btnCancelClick);
            this.btnCreate.Click += new EventHandler(btnCreateClick);

        }

        
        #endregion

        #region Class Event Void Procedures
        //############################################CLASS EmployeeRemittanceCreate EVENTS#############################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            lblEmpId.Text = _empInfo.EmployeeId;
            lblName.Text = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(_empInfo.PersonInfo.LastName, _empInfo.PersonInfo.FirstName, 
                _empInfo.PersonInfo.MiddleName);

            lblLoanId.Text = _loanInfo.ReferenceNo;
            lblDescription.Text = _loanInfo.Description;
            txtAmountPaid.Text = _loanInfo.MonthlyAmmortization.ToString("N");

            _remInfo.LoanInfo.RemittanceSysId = _loanInfo.RemittanceSysId;
            _remInfo.RemittanceDate = _loanManager.GetProposedEmployeeRemittanceDate(_loanInfo).ToShortDateString() + " " + 
                DateTime.Parse(_loanManager.ServerDateTime).ToShortTimeString();

            lblRemittanceDate.Text = DateTime.Parse(_remInfo.RemittanceDate).ToLongDateString();

            txtAmountBalance.Text = (_loanManager.GetAmountBalance(_loanInfo, _remInfo.RemittanceId) - _loanInfo.MonthlyAmmortization).ToString("N");

        } //----------------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasCreated)
            {
                String strMsg = "Are you sure you want to cancel the creation of a new employee loan remittance?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        } //----------------------------------
        //#########################################END CLASS EmployeeRemittanceCreate EVENTS############################################

        //#########################################BUTTON btnCancel EVENTS##################################################
        //event is raised when the button is clicked
        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        } //------------------------------------------
        //#######################################END BUTTON btnCancel EVENTS#################################################

        //#####################################################BUTTON btnCreate EVENTS#################################################
        //event is raised when the button is clicked
        private void btnCreateClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to create the new employee loan remittance?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Create", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The employee loan has been successfully created.";

                        this.Cursor = Cursors.WaitCursor;
                        
                        _loanManager.InsertEmployeeRemittance(_userInfo, _remInfo, _loanInfo, _empInfo.EmployeeSysId);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasCreated = true;

                        this.Close();
                    }
                    else if (msgResult == DialogResult.Cancel)
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Creating");
                }
            }
        } //---------------------------------
        //################################################END BUTTON btnCreate EVENTS##################################################
        #endregion
    }
}
