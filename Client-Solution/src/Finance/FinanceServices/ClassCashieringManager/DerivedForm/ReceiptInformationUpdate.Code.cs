using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class ReceiptInformationUpdate
    {
        #region Class Data Member Declaration
        private CommonExchange.CancelledReceiptNo _tempCancelReceiptNumberInfo;
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
        public ReceiptInformationUpdate(CommonExchange.SysAccess userInfo, 
            CommonExchange.CancelledReceiptNo canceldReceiptNoInfo, CashieringLogic cashieringManager)
            : base(userInfo, cashieringManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _cashieringManager = cashieringManager;
         
            _canceldReceiptNoInfo = canceldReceiptNoInfo;
            _tempCancelReceiptNumberInfo = (CommonExchange.CancelledReceiptNo)canceldReceiptNoInfo.Clone();
        
            this.FormClosing += new FormClosingEventHandler(ClassClossing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);
            this.btnDelete.Click += new EventHandler(btnDeleteClick);
        }
        #endregion

        #region Class Event Void Procedures
        //###########################################CLASS ReceiptInformationUpdate EVENTS#####################################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.lblReceiptNumber.Text = _canceldReceiptNoInfo.ReceiptNo;
            this.txtRemarks.Text = _canceldReceiptNoInfo.Remarks;

            if (!String.IsNullOrEmpty(_canceldReceiptNoInfo.ReceiptDate))
            {
                this.lblReceiptDate.Text = DateTime.Parse(_canceldReceiptNoInfo.ReceiptDate).ToLongDateString();
            }

            if (String.IsNullOrEmpty(_canceldReceiptNoInfo.DateCancelled))
            {
                this.lblDateCancelled.Text = DateTime.Parse(_cashieringManager.ServerDateTime).ToLongDateString();
            }
            else
            {
                this.lblDateCancelled.Text = DateTime.Parse(_canceldReceiptNoInfo.DateCancelled).ToLongDateString();
            }
        }//-------------------------

        //event is raised when the class is clossing
        private void ClassClossing(object sender, FormClosingEventArgs e)
        {
            if ((!_hasUpdated || !_hasDeleted) && (!_canceldReceiptNoInfo.Equals(_tempCancelReceiptNumberInfo)))
            {
                String strMsg = "There has been changes made in the current receipt number information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//--------------------------
        //###########################################END CLASS ReceiptInformationUpdate EVENTS#####################################################

        //##############################################BUTTON btnClose EVENTS########################################################
        //event is raised when the button is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//--------------------------
        //##############################################END BUTTON btnClose EVENTS########################################################

        //###########################################LABEL lblReceiptDate EVENTS#####################################################
        //event is raised when the control is clicked
        protected override void lblReceiptDateClick(object sender, EventArgs e)
        {
            base.lblReceiptDateClick(sender, e);

            this.IsRecordLocked(DateTime.Parse(_canceldReceiptNoInfo.ReceiptDate), DateTime.Parse(_canceldReceiptNoInfo.DateCancelled));
        }//------------------
        //###########################################END LABEL lblReceiptDate EVENTS#####################################################

        //##############################################BUTTON btnUpdate EVENTS########################################################
        //event is raised when the button is clicked
        private void btnUpdateClick(object sender, EventArgs e)
        {           
            try
            {
                String strMsg = "Are you sure you want to update the cancelled receipt?";

                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.Yes)
                {
                    strMsg = "The cancelled receipt has been successfully updated.";

                    this.Cursor = Cursors.WaitCursor;

                    _cashieringManager.UpdateCancelledReceiptNo(_userInfo, _canceldReceiptNoInfo);

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
                String strMsg = "Are you sure you want to delete the cancelled receipt?";

                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.Yes)
                {
                    strMsg = "The cancelled receipt has been successfully Deleted.";

                    this.Cursor = Cursors.WaitCursor;

                    _cashieringManager.DeleteCancelledReceiptNo(_userInfo, _canceldReceiptNoInfo);

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

        #region Programmer's Defined Void Procedures
        //this procedure will set record status
        //Code History: Priviews code calls (_cashieringManager.GetReflectedDate(<parameters>)) to supply the reflected date.
        //reflected date is delete because of the new record locking feature. (can backward payments more than 4 months)
        private void IsRecordLocked(DateTime receiptDate, DateTime dateCancelled)
        {
            if (RemoteClient.ProcStatic.IsRecordLocked((Int32)CommonExchange.SystemRange.ReceivedDateAllowance, receiptDate, dateCancelled,
                DateTime.Parse(_cashieringManager.ServerDateTime)))
            {
                this.btnUpdate.Enabled = this.btnDelete.Enabled = false;

                this.lblStatusPayment.Text = "This record is LOCKED";

                this.pbxLockedPayment.Visible = true;
                this.pbxUnlockPayment.Visible = false;
            }
            else
            {
                this.btnUpdate.Enabled = this.btnDelete.Enabled = true;

                this.lblStatusPayment.Text = "This record is OPEN";

                this.pbxLockedPayment.Visible = false;
                this.pbxUnlockPayment.Visible = true;
            }
        }//---------------------
        #endregion
    }    
}
