using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AccountingServices
{
    partial class ChartOfAccountUpdate
    {
        #region Class Data Member Declaration
        CommonExchange.ChartOfAccount _tempChartOfAccountInfo;
        #endregion

        #region Class Properties Declaration
        private Boolean _hasUpdated = false;
        public Boolean HasUpdated
        {
            get { return _hasUpdated; }
        }
        #endregion

        #region Class Constructors
        public ChartOfAccountUpdate(CommonExchange.SysAccess userInfo, CommonExchange.ChartOfAccount chartOfAccountInfo, ChartOfAccountLogic chartOfAccountManager)
            : base(userInfo, chartOfAccountManager)
        {
            this.InitializeComponent();

            _chartOfAccountInfo = chartOfAccountInfo;
            _tempChartOfAccountInfo = (CommonExchange.ChartOfAccount)chartOfAccountInfo;

            this.FormClosing += new FormClosingEventHandler(ClassClossing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);
        }
        #endregion

        #region Class Event Void Procedures
        //###########################################CLASS ChartOfAccountUpdate EVENTS#####################################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            _chartOfAccountManager.InitializeAccountCategoryComboBox(this.cboAccountCategory, _chartOfAccountInfo.AccountingCategoryInfo.AccountingCategoryId);

            this.AssignControlValues();
        }//-----------------------

        //event is raised when the class is clossing
        private void ClassClossing(object sender, FormClosingEventArgs e)
        {
            if ((!_hasUpdated) && (!_chartOfAccountInfo.Equals(_tempChartOfAccountInfo)))
            {
                String strMsg = "There has been changes made in the current chart of account information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//-----------------
        //###########################################END CLASS ChartOfAccountUpdate EVENTS#####################################################

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
                if (this.ValidateControls())
                {
                    String strMsg = "Are you sure you want to update the chart of account information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The chart of account information has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _chartOfAccountManager.UpdateChartOfAccounts(_userInfo, _chartOfAccountInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdated = true;

                        this.Close();
                    }
                    else if (msgResult == DialogResult.Cancel)
                    {
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Updating");
            }
        }//----------------------------
        //##############################################END BUTTON btnUpdate EVENTS########################################################

        #endregion
    }
}
