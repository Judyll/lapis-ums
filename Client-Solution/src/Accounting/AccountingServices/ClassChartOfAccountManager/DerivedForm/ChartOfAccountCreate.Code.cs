using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AccountingServices
{
    partial class ChartOfAccountCreate
    {
        #region Class Properties Declarations
        private Boolean _hasCreated = false;
        public Boolean HasCreated
        {
            get { return _hasCreated; }
        }
        #endregion

        #region Class Constructors
        public ChartOfAccountCreate(CommonExchange.SysAccess userInfo, ChartOfAccountLogic chartOfAccountManager)
            : base(userInfo, chartOfAccountManager)
        {
            this.InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(ClassClossing);
            this.btnCancel.Click += new EventHandler(btnCancelClick);
            this.btnCreate.Click += new EventHandler(btnCreateClick);
        }
        #endregion

        #region Class Event Void Procedures
        //###############################################CLASS ChartOfAccountCreate EVENTS##################################################
        //event is raised when the class is clossing
        private void ClassClossing(object sender, FormClosingEventArgs e)
        {
            if (!_hasCreated)
            {
                String strMsg = "Are you sure you want to cancel the creation of a new chart of account information?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//--------------------
        //###############################################END CLASS ChartOfAccountCreate EVENTS##################################################

        //###############################################BUTTON btnClose EVENTS##################################################
        //event is raised when the control is clicked
        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }//---------------------
        //##############################################END BUTTON btnClose EVENTS##################################################

        //################################################BUTTON btnCreate EVENTS####################################################
        //event is raised when btnCreate is Clicked
        private void btnCreateClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to create the chart of account information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Create", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The new chart of account information has been successfully created.";

                        this.Cursor = Cursors.WaitCursor;

                        _chartOfAccountManager.InsertChartOfAccounts(_userInfo, _chartOfAccountInfo);

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
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }
        }//-----------------
        //################################################END BUTTON btnCreate EVENTS####################################################
        #endregion
    }
}
