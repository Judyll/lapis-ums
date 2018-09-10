using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class BreakDownBankDepositCreate
    {
        #region Class Properties Declaration
        private Boolean _hasRecorded = false;
        public Boolean HasRecorded
        {
            get { return _hasRecorded; }
        }
        #endregion  

        #region Class Constructors
        public BreakDownBankDepositCreate(CommonExchange.SysAccess userInfo, CashieringLogic cashieringManager, String dateStart, String dateEnd)
            : base(userInfo, cashieringManager, dateStart, dateEnd)
        {
            this.InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(ClassClossing);
            this.btnCancel.Click += new EventHandler(btnCancelClick);
            this.btnCreate.Click += new EventHandler(btnCreateClick);
        }
        #endregion

        #region Class Event Void Procedures
        //############################################CLASS BreakDownBankDepositCreate EVENTS#######################################################
        //event is raised when the class is closing
        private void ClassClossing(object sender, FormClosingEventArgs e)
        {
            if (!_hasRecorded)
            {
                String strMsg = "Are you sure you want to cancel the break down bank deposit information?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//---------------------
        //############################################END CLASS BreakDownBankDepositCreate EVENTS#######################################################

        //##############################################BUTTON btnCancel EVENTS########################################################
        //event is raised when the button is clicked
        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }//-----------------------------
        //##############################################END BUTTON btnCancel EVENTS########################################################

        //#############################################BUTTON btnCreate EVENTS########################################################
        //event is raised when the button is clicked
        private void btnCreateClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to create break down bank deposit?";
                                     
                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Create", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The break down bank deposit has been successfully created.";

                        this.Cursor = Cursors.WaitCursor;

                        _cashieringManager.InsertBreakdownBankDeposit(_userInfo, _breakDownDepositInfo);
                     
                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasRecorded = true;

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
        }//-------------------------
        //#############################################END BUTTON btnProceed EVENTS########################################################
        #endregion
    }
}
