using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EmployeeServices
{
    partial class LoanInformationUpdate
    {
        #region Class General Variable Declarations
        private CommonExchange.LoanInformation _loanInfoTemp;
        #endregion

        #region Class Properties Declarations
        private Boolean _hasUpdated = false;
        public Boolean HasUpdated
        {
            get { return _hasUpdated; }
        }

        private Boolean _hasDeleted = false;
        public Boolean HasDeleted
        {
            get { return _hasDeleted; }
        }
        #endregion

        #region Class Constructor
        public LoanInformationUpdate(CommonExchange.SysAccess userInfo, CommonExchange.Employee empInfo, CommonExchange.LoanInformation loanInfo,
                                        LoanRemittanceLogic loanManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _empInfo = empInfo;
            _loanManager = loanManager;
            _loanInfo = loanInfo;
            _loanInfoTemp = (CommonExchange.LoanInformation)loanInfo.Clone();

            this.Load += new EventHandler(ClassLoad);
            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnDelete.Click += new EventHandler(btnDeleteClick);
            
        }       
        
        #endregion

        #region Class Event Void Procedures
        //#####################################CLASS LoanInformationCreate EVENTS########################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            lblId.Text = _empInfo.EmployeeId;
            lblName.Text = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(_empInfo.PersonInfo.LastName, 
                _empInfo.PersonInfo.FirstName, _empInfo.PersonInfo.MiddleName);

            lblSysID.Text = _loanInfo.RemittanceSysId;
            txtReferenceNo.Text = _loanInfo.ReferenceNo;
            lblReleaseDate.Text = DateTime.Parse(_loanInfo.ReleaseDate).ToLongDateString();
            lblMaturityDate.Text = DateTime.Parse(_loanInfo.MaturityDate).ToLongDateString();

            _loanManager.InitializeLoanTypeCombo(cboLoanType, _loanInfo.LoanSysId);

            txtPrincipal.Text = _loanInfo.PrincipalInterest.ToString("N");
            txtMonthlyAmmortization.Text = _loanInfo.MonthlyAmmortization.ToString("N");

        } //----------------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasUpdated && !_loanInfo.Equals(_loanInfoTemp))
            {
                String strMsg = "There has been changes made in the current employee loan information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        } //----------------------------------
        //####################################END CLASS LoanInformationCreate EVENTS######################################

        //#########################################BUTTON btnClose EVENTS##################################################
        //event is raised when the button is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        } //------------------------------------------
        //#######################################END BUTTON btnClose EVENTS#################################################

        //##############################################BUTTON btnUpdate EVENTS##############################################
        //event is raised when the button is clicked
        private void btnUpdateClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Updating an employee loan information might affect the following:" +
                                    "\n\n1.) The system inventory." +
                                    "\n2.) The employee remittances." +
                                    "\n\nAre you sure you want to update the employee loan information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The employee loan information has been successfully updated.";

                        _loanManager.UpdateLoanRemittance(_userInfo, _loanInfo);

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdated = true;

                        this.Close();
                    }
                    else if (msgResult == DialogResult.Cancel)
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Updating");
                }
            }
        } //---------------------------------------
        //############################################END BUTTON btnUpdate EVENTS############################################

        //###############################################BUTTON btnDelete EVENTS################################################
        //event is raised when the button is clicked
        private void btnDeleteClick(object sender, EventArgs e)
        {
            try
            {
                String strMsg = "Deleting an employee loan information might affect the following:" +
                                "\n\n1.) The system inventory." +
                                "\n2.) The employee remittances." +
                                "\n\nAre you sure you want to delete the employee loan information?";

                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

                if (msgResult == DialogResult.Yes)
                {
                    strMsg = "Are you really sure you want to delete the employee loan information?";

                    msgResult = MessageBox.Show(strMsg, "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);                    

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The employee loan information has been successfully deleted.";

                        _loanManager.DeleteLoanRemittance(_userInfo, _loanInfo.RemittanceSysId);

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasDeleted = true;

                        this.Close();
                    }
                    else if (msgResult == DialogResult.Cancel)
                    {
                        this.Close();
                    }                    
                }
                else if (msgResult == DialogResult.Cancel)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Deleting");
            }
           
        } //------------------------------
        //#############################################END BUTTON btnDelete EVENTS##############################################
        #endregion
    }
}
