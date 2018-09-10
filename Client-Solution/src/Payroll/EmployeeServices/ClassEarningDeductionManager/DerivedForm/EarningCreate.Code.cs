using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EmployeeServices
{
    partial class EarningCreate
    {
        #region Class Properties Declarations
        private Boolean _hasCreated = false;
        public Boolean HasCreated
        {
            get { return _hasCreated; }
        }
        #endregion

        #region Class Constructor
        public EarningCreate(CommonExchange.SysAccess userInfo, EarningLogic incManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _incManager = incManager;

            this.Load += new EventHandler(ClassLoad);
            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnCancel.Click += new EventHandler(btnCancelClick);
            this.btnCreate.Click += new EventHandler(btnCreateClick);
        }
       
        #endregion

        #region Class Event Void Procedures

        //########################################CLASS DeductionCreate EVENTS##############################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            _earningInfo = new CommonExchange.EarningInformation();
        } //--------------------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasCreated)
            {
                String strMsg = "Are you sure you want to cancel the creation of a new earning information?";
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

        //##################################################BUTTON btnCreate EVENTS##############################################
        //event is raised when the button is clicked
        private void btnCreateClick(object sender, EventArgs e)
        {
            if (this.ValidateEarningControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to create the earning information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Create", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The earning information has been successfully created.";

                        _earningInfo.Description = RemoteClient.ProcStatic.TrimStartEndString(txtDescription.Text);

                        _incManager.InsertEarningInformation(_userInfo, _earningInfo);

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

        } //-------------------------------             
        //################################################END BUTTON btnCreate EVENTS############################################
        #endregion
    }
}
