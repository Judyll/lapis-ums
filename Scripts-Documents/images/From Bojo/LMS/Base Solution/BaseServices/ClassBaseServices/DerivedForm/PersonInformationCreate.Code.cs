using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BaseServices
{
    partial class PersonInformationCreate
    {
        #region Class Properties Declaration
        private Boolean _hasRecorded = false;
        public Boolean HasRecorded
        {
            get { return _hasRecorded; }
        }
        #endregion

        #region Class Class Constructors
        public PersonInformationCreate(CommonExchange.SysAccess userInfo, BaseServices.BaseServicesLogic baseServiceManager)
            : base(userInfo)
        {
            this.InitializeComponent();

            _personInfo = new CommonExchange.Person();
            _baseServiceManager = baseServiceManager;

            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnCreate.Click += new EventHandler(btnRecordClick);
        }
        #endregion

        #region Class Event Void Procedures
        //##################################CLASS PersonInformationCreate EVENTS########################################
        //event is raised when the colass is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            //base.AssingControlsValue();
        }//------------------------------

        //event is raised when the class is closing
        protected override void ClassClossing(object sender, FormClosingEventArgs e)
        {
            base.ClassClossing(sender, e);

            if (!_hasRecorded && !_isForUpdatePerson)
            {
                String strMsg = "Are you sure you want to cancel the creation of a new person?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//--------------------
        //##################################END CLASS PersonInformationCreate EVENTS########################################

        //#####################################TEXTBOX txtLastName EVENTS########################################
        //event is raised when the control is validated
        protected override void txtLastNameValidated(object sender, EventArgs e)
        {
            base.txtLastNameValidated(sender, e);

            this.btnCreate.Enabled = false;
        }//-------------------------
        //#####################################END TEXTBOX txtLastName EVENTS########################################

        //#####################################TEXTBOX txtFirstName EVENTS########################################
        //event is raised when the control is validated
        protected override void txtFirstNameValidated(object sender, EventArgs e)
        {
            base.txtFirstNameValidated(sender, e);

            this.btnCreate.Enabled = false;
        }//----------------------
        //#####################################END TEXTBOX txtFirstName EVENTS########################################

        //####################################################LINKLABEL lnkVerify EVENTS###############################################
        //event is raised when the control is clicked
        protected override void lnkVerifyLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            base.lnkVerifyLinkClicked(sender, e);

            this.btnCreate.Enabled = this.IsVerifiedUpdatedName;
        }//---------------------
        //####################################################END LINKLABEL lnkVerify EVENTS###############################################

        //##################################BUTTON btnClose EVENTS########################################
        //event is raised whent the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//--------------------
        //##################################END BUTTON btnClose EVENTS########################################

        //##################################BUTTON btnRecord EVENTS########################################
        //event is raised whent the control is clicked
        private void btnRecordClick(object sender, EventArgs e)
        {
            if (this.BaseValidateControls())
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    String strMsg = "Are you sure you whant to create a new person information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Create", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The person information has been successfully created.";

                        this.Cursor = Cursors.WaitCursor;

                        _personInfo.ObjectState = System.Data.DataRowState.Added;

                        _baseServiceManager.InsertUpdatePersonInformation(_userInfo, ref _personInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasRecorded = true;

                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    ProcStatic.ShowErrorDialog(ex.Message + "\n\nError Creating Person Information", "Error Creating");
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }
        }//--------------------
        //##################################END BUTTON btnRecord EVENTS########################################
        #endregion
    }
}
