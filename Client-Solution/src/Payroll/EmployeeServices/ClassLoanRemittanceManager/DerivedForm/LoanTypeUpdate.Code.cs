using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EmployeeServices
{
    partial class LoanTypeUpdate
    {
        #region Class General Variable Declarations
        private CommonExchange.LoanInformation _loanTemp;
        private String _loanId;
        #endregion

        #region Class Properties Declarations
        private Boolean _hasUpdated = false;
        public Boolean HasUpdated
        {
            get { return _hasUpdated; }
        }
        #endregion

        #region Class Constructor

        public LoanTypeUpdate(CommonExchange.SysAccess userInfo, LoanRemittanceLogic loanManager, String loanId)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _loanManager = loanManager;
            _loanId = loanId;

            this.Load += new EventHandler(ClassLoad);
            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnDone.Click += new EventHandler(btnDoneClick);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);
            this.txtDescription.KeyPress += new KeyPressEventHandler(txtDescriptionKeyPress);
        }
              
        #endregion

        #region Class Event Void Procedures

        //###########################################CLASS DeductionUpdate EVENTS###########################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            _loanInfo = new CommonExchange.LoanInformation();
            _loanTemp = new CommonExchange.LoanInformation();

            this.InitializeControls();
        } //-----------------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasUpdated)
            {
                _loanInfo.Description = RemoteClient.ProcStatic.TrimStartEndString(txtDescription.Text);

                if (!_loanInfo.Equals(_loanTemp))
                {
                    String strMsg = "There has been changes made in the current loan type information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                }
            }
        } //---------------------------------
        //########################################END CLASS Deduction EVENTS#################################################################

        //#################################################BUTTON btnDone EVENTS###############################################################
        //event is raised when the button is clicked
        private void btnDoneClick(object sender, EventArgs e)
        {
            this.Close();
        } //--------------------------------
        //##############################################END BUTTON btnDone EVENTS##############################################################

        //################################################TEXTBOX txtDescription EVENTS##########################################################
        //event is raised when the key is pressed
        private void txtDescriptionKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.UpdateLoanTypeInformation();
            }
            
        } //-------------------------------
        //##############################################END TEXTBOX txtDescription EVENTS#########################################################

        //###############################################BUTTON btnUpdate EVENTS################################################################
        //event is raised when the button is clicked
        private void btnUpdateClick(object sender, EventArgs e)
        {
            this.UpdateLoanTypeInformation();
        } //-------------------------------
        //##############################################END BUTTON btnUpdate EVENTS#############################################################

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure initializes the controls
        private void InitializeControls()
        {
            _loanInfo = _loanManager.GetLoanTypeInformationDetails(_loanId);
            _loanTemp = (CommonExchange.LoanInformation)_loanInfo.Clone();

            lblId.Text = _loanInfo.LoanSysId;
            txtDescription.Text = _loanInfo.Description;
        }

        //this procedure update the loan type information
        private void UpdateLoanTypeInformation()
        {
            if (this.ValidateLoanControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to update the loan type information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The loan type information has been successfully updated.";

                        _loanInfo.Description = RemoteClient.ProcStatic.TrimStartEndString(txtDescription.Text);

                        _loanManager.UpdateLoanTypeInformation(_userInfo, _loanInfo);

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

        } //----------------------------

        #endregion
    }
}
