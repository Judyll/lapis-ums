using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class BreakDownBankDepositUpdate
    {
        #region Class Data Member Declaration
        private CommonExchange.BreakdownBankDeposit _tempBreakDownBankDeposit;
        #endregion

        #region Class Properties Declaration
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

        #region Class Constructors
        public BreakDownBankDepositUpdate(CommonExchange.SysAccess userInfo, CommonExchange.BreakdownBankDeposit breakDownBanckDepositInfo, 
            CashieringLogic cashieringManager, String dateStart, String dateEnd)
            : base(userInfo, cashieringManager, dateStart, dateEnd)
        {
            this.InitializeComponent();

            _breakDownDepositInfo = breakDownBanckDepositInfo;
            _tempBreakDownBankDeposit = (CommonExchange.BreakdownBankDeposit)breakDownBanckDepositInfo.Clone();

            this.FormClosing += new FormClosingEventHandler(ClassClossing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);
            this.btnDelete.Click += new EventHandler(btnDeleteClick);
        }
        #endregion

        #region Class Event Void Procedures
        //############################################CLASS BreakDownBankDepositUpdate EVENTS#######################################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.dtpStart.Value = DateTime.Parse(_breakDownDepositInfo.DateStart);
            this.dtpEnd.Value = DateTime.Parse(_breakDownDepositInfo.DateEnd);

            this.txtAmount.Text = _breakDownDepositInfo.Amount.ToString("N");
            this.txtCreditEntry.Text = !String.IsNullOrEmpty(_breakDownDepositInfo.AccountInfo.AccountSysId) ?
                _breakDownDepositInfo.AccountInfo.AccountCode + " - " + _breakDownDepositInfo.AccountInfo.AccountName : String.Empty;
        }//--------------------

        //event is raised when the class is clossing
        private void ClassClossing(object sender, FormClosingEventArgs e)
        {
            if ((!_hasUpdated || !_hasDeleted) && (!_breakDownDepositInfo.Equals(_tempBreakDownBankDeposit)))
            {
                String strMsg = "There has been changes made in the current break down back deposit information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//-----------------------
        //############################################END CLASS BreakDownBankDepositUpdate EVENTS#######################################################

        //##############################################BUTTON btnClose EVENTS########################################################
        //event is raised when the button is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//--------------------------
        //##############################################END BUTTON btnClose EVENTS########################################################

        //##############################################BUTTON btnUpdate EVENTS########################################################
        //event is raised when the button is clicked
        private void btnUpdateClick(object sender, EventArgs e)
        {
            try
            {
                String strMsg = "Are you sure you want to update the break down back deposit information?";

                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.Yes)
                {
                    strMsg = "The break down back deposit has been successfully updated.";

                    this.Cursor = Cursors.WaitCursor;

                    _cashieringManager.UpdateBreakdownBankDeposit(_userInfo, _breakDownDepositInfo);

                    this.Cursor = Cursors.Arrow;

                    MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    _hasUpdated = _hasDeleted = true;

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
        }//----------------------------
        //##############################################END BUTTON btnUpdate EVENTS########################################################

        //##############################################BUTTON btnDelete EVENTS########################################################
        //event is raised when the button is clicked
        private void btnDeleteClick(object sender, EventArgs e)
        {
            try
            {
                String strMsg = "Are you sure you want to delete the break down back deposit information?";

                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.Yes)
                {
                    strMsg = "The break down bank deposit has been successfully Deleted.";

                    this.Cursor = Cursors.WaitCursor;

                    _cashieringManager.DeleteBreakdownBankDeposit(_userInfo, _breakDownDepositInfo);

                    this.Cursor = Cursors.Arrow;

                    MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    _hasUpdated = _hasDeleted = true;

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
        }//---------------------------
        //##############################################END BUTTON btnDelete EVENTS########################################################
        #endregion
    }
}
