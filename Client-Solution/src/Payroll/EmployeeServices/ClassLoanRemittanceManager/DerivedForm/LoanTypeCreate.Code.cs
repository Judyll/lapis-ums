using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EmployeeServices
{
    partial class LoanTypeCreate
    {
        #region Class Properties Declarations
        private Boolean _hasCreated = false;
        public Boolean HasCreated
        {
            get { return _hasCreated; }
        }
        #endregion

        #region Class Constructor

        public LoanTypeCreate(CommonExchange.SysAccess userInfo, LoanRemittanceLogic loanManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _loanManager = loanManager;

            this.Load += new EventHandler(ClassLoad);
            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.txtDescription.KeyPress += new KeyPressEventHandler(txtDescriptionKeyPress);
            this.btnCancel.Click += new EventHandler(btnCancelClick);
            this.btnCreate.Click += new EventHandler(btnCreateClick);
        }

        
       
        #endregion

        #region Class Event Void Procedures

        //########################################CLASS DeductionCreate EVENTS##############################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            _loanInfo = new CommonExchange.LoanInformation();

        } //--------------------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasCreated)
            {
                String strMsg = "Are you sure you want to cancel the creation of a new loan type information?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }

        } //---------------------------
        //######################################END CLASS DeductionCreate EVENTS############################################

        //###############################################BUTTON btnCancel EVENTS################################################
        //event is raised when the button is clicked
        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        } //---------------------------------
        //##############################################END BUTTON btnCancel EVENTS#############################################

        //#################################################TEXTBOX txtDescription EVENTS###########################################
        //event is raised when the key is pressed
        private void txtDescriptionKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                this.InsertLoanTypeInformation();
            }
        } //-----------------------------------------
        //##############################################END TEXTBOX txtDescription EVENTS###########################################

        //##################################################BUTTON btnCreate EVENTS##############################################
        //event is raised when the button is clicked
        private void btnCreateClick(object sender, EventArgs e)
        {
            this.InsertLoanTypeInformation();
        } //-------------------------------             
        //################################################END BUTTON btnCreate EVENTS############################################

        #endregion

        #region Programmer-Defined Void Procedures
        //this procedure creates a new loan type information
        private void InsertLoanTypeInformation()
        {
            if (this.ValidateLoanControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to create the new loan type information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Create", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The loan type information has been successfully created.";

                        _loanInfo.Description = RemoteClient.ProcStatic.TrimStartEndString(txtDescription.Text);

                        _loanManager.InsertLoanTypeInformation(_userInfo, _loanInfo);

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
        #endregion
    }
}
