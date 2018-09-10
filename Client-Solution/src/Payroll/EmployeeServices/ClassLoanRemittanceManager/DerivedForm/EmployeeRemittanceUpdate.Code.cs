using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EmployeeServices
{
    partial class EmployeeRemittanceUpdate
    {
        #region Class General Variable Declarations
        private CommonExchange.EmployeeLoanRemittance _remInfoTemp;
        #endregion

        #region Class Properties Declarations
        private Boolean _hasUpdated = false;
        public Boolean HasUpdated
        {
            get { return _hasUpdated; }
        }
        #endregion

        #region Class Constructor
        public EmployeeRemittanceUpdate(CommonExchange.SysAccess userInfo, CommonExchange.Employee empInfo,
                                        CommonExchange.LoanInformation loanInfo, CommonExchange.EmployeeLoanRemittance remInfo,
                                        LoanRemittanceLogic loanManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _empInfo = empInfo;
            _loanInfo = loanInfo;
            _remInfo = remInfo;
            _remInfoTemp = (CommonExchange.EmployeeLoanRemittance)remInfo.Clone();
            _loanManager = loanManager;

            this.Load += new EventHandler(ClassLoad);
            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);
            this.btnDelete.Click += new EventHandler(btnDeleteClick);
        }
        
        #endregion

        #region Class Event Void Procedures
        //############################################CLASS EmployeeRemittanceUpdate EVENTS#############################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            lblEmpId.Text = _empInfo.EmployeeId;
            lblName.Text = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(_empInfo.PersonInfo.LastName, _empInfo.PersonInfo.FirstName,
                _empInfo.PersonInfo.MiddleName);

            lblLoanId.Text = _loanInfo.ReferenceNo;
            lblDescription.Text = _loanInfo.Description;

            lblSysID.Text = _remInfo.RemittanceId.ToString();
            lblRemittanceDate.Text = DateTime.Parse(_remInfo.RemittanceDate).ToLongDateString();

            txtAmountPaid.Text = _remInfo.AmountPaid.ToString("N");
            txtAmountBalance.Text = _remInfo.AmountBalance.ToString("N");

        } //----------------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasUpdated && !_remInfo.Equals(_remInfoTemp))
            {
                String strMsg = "There has been changes made in the current employee remittance information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        } //----------------------------------
        //#########################################END CLASS EmployeeRemittanceUpdate EVENTS############################################

        //#########################################BUTTON btnClose EVENTS##################################################
        //event is raised when the button is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        } //------------------------------------------
        //#######################################END BUTTON btnClose EVENTS#################################################

        //#################################################BUTTON btnUpdate EVENTS######################################################
        //event is raised when the button is clicked
        private void btnUpdateClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Updating an employee loan remittance might affect the following:" +
                                    "\n\n1.) The system inventory." +
                                    "\n2.) The employee remittances." +
                                    "\n\nAre you sure you want to update the employee loan remittance?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The employee loan remittance has been successfully updated.";

                        _loanManager.UpdateDeleteEmployeeRemittance(_userInfo, _loanInfo, _remInfo, true);

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
        } //----------------------------------
        //###############################################END BUTTON btnUpdate EVENTS####################################################

        //###################################################BUTTON btnDelete EVENTS######################################################
        //event is raised when the button is clicked
        private void btnDeleteClick(object sender, EventArgs e)
        {
            try
            {
                String strMsg = "Deleting an employee loan remittance might affect the following:" +
                                "\n\n1.) The system inventory." +
                                "\n2.) The employee remittances." +
                                "\n\nAre you sure you want to delete the employee loan remittance?";

                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (msgResult == DialogResult.Yes)
                {
                    strMsg = "The employee loan remittance has been successfully deleted.";

                    _loanManager.UpdateDeleteEmployeeRemittance(_userInfo, _loanInfo, _remInfo, false);

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
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Deleting");
            }
            
        } //-------------------------------------
        //##############################################END BUTTON btnDelete EVENTS#######################################################

        #endregion
    }
}
