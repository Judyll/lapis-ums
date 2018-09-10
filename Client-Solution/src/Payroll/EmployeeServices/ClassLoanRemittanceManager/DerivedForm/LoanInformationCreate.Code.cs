using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EmployeeServices
{
    partial class LoanInformationCreate
    {
        #region Class Properties Declarations
        private Boolean _hasCreated = false;
        public Boolean HasCreated
        {
            get { return _hasCreated; }
        }
        #endregion

        #region Class Constructor
        public LoanInformationCreate(CommonExchange.SysAccess userInfo, CommonExchange.Employee empInfo, LoanRemittanceLogic loanManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _empInfo = empInfo;
            _loanManager = loanManager;

            this.Load += new EventHandler(ClassLoad);
            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnCancel.Click += new EventHandler(btnCancelClick);
            this.btnApply.Click += new EventHandler(btnApplyClick);
        }        
        
        #endregion

        #region Class Event Void Procedures
        //#####################################CLASS LoanInformationCreate EVENTS########################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            lblId.Text = _empInfo.EmployeeId;
            lblName.Text = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(_empInfo.PersonInfo.LastName, _empInfo.PersonInfo.FirstName, 
                _empInfo.PersonInfo.MiddleName);

            _loanInfo.EmployeeInfo.EmployeeSysId = _empInfo.EmployeeSysId;
            _loanInfo.ReleaseDate = DateTime.Parse(_loanManager.ServerDateTime).ToString("o");
            _loanInfo.MaturityDate = _loanManager.GetProposedMaturityDate(DateTime.Parse(_loanManager.ServerDateTime)).ToString("o");

            lblReleaseDate.Text = DateTime.Parse(_loanInfo.ReleaseDate).ToLongDateString();
            lblMaturityDate.Text = DateTime.Parse(_loanInfo.MaturityDate).ToLongDateString();

            _loanManager.InitializeLoanTypeCombo(cboLoanType);

        } //----------------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasCreated)
            {
                String strMsg = "Are you sure you want to cancel the creation of a new employee loan?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        } //----------------------------------
        //####################################END CLASS LoanInformationCreate EVENTS######################################

        //#########################################BUTTON btnCancel EVENTS##################################################
        //event is raised when the button is clicked
        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        } //------------------------------------------
        //#######################################END BUTTON btnCancel EVENTS#################################################

        //###########################################BUTTON btnApply EVENTS####################################################
        //event is raised when the button is clicked
        private void btnApplyClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to apply the new employee loan?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Apply", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The employee loan has been successfully applied.";

                        _loanManager.InsertLoanRemittance(_userInfo, _loanInfo);

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
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Applying");
                }               
            }

        } //-------------------------------
        //###########################################END BUTTON btnApply EVENTS################################################
        
        #endregion
    }
}
