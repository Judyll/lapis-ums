using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace BaseServices
{
    partial class PersonInformationUpdate
    {
        #region Class Data Member Decliration
        private CommonExchange.Person _tempPersonInfo;
        #endregion

        #region Class Properties Declaration
        private Boolean _hasUpdated = false;
        public Boolean HasUpdated
        {
            get { return _hasUpdated; }
        }
        #endregion

        #region Class Constructors
        public PersonInformationUpdate(CommonExchange.SysAccess userInfo, CommonExchange.Person personInfo, BaseServicesLogic basServicesManager)
            : base(userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _baseServiceManager = basServicesManager;
            _personInfo = personInfo;
            _tempPersonInfo = (CommonExchange.Person)personInfo.Clone();

            //this.FormClosing += new FormClosingEventHandler(ClassClossing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);

        }        
        #endregion

        #region Class Event Void Procedures
        //##################################CLASS PersonInformationUpdate EVENTS########################################
        //event is raised when the colass is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.AssingControlsValue();

            this.SetPersonInformationControls(true);

            this.btnUpdate.Enabled = true;

            this.lnkPersonArchive.Visible = false;
        }//-------------------------

        //event is raised when the class is clossing
        protected override void ClassClossing(object sender, FormClosingEventArgs e)
        {
            base.ClassClossing(sender, e);

            if (!_hasUpdated && !_personInfo.Equals(_tempPersonInfo))
            {
                String strMsg = "There has been changes made in the current person information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//--------------------------
        //##################################END CLASS PersonInformationUpdate EVENTS########################################

        //#####################################BUTTON btnClose EVENTS########################################
        //event is raised when the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//-----------------------------
        //#####################################END BUTTON btnClose EVENTS########################################

        //#####################################TEXTBOX txtLastName EVENTS########################################
        //event is raised when the control is validated
        protected override void txtLastNameValidated(object sender, EventArgs e)
        {
            base.txtLastNameValidated(sender, e);

            this.btnUpdate.Enabled = false;
        }//-------------------------
        //#####################################END TEXTBOX txtLastName EVENTS########################################

        //#####################################TEXTBOX txtFirstName EVENTS########################################
        //event is raised when the control is validated
        protected override void txtFirstNameValidated(object sender, EventArgs e)
        {
            base.txtFirstNameValidated(sender, e);

            this.btnUpdate.Enabled = false;
        }//----------------------
        //#####################################END TEXTBOX txtFirstName EVENTS########################################

        //####################################################LINKLABEL lnkVerify EVENTS###############################################
        //event is raised when the control is clicked
        protected override void lnkVerifyLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            base.lnkVerifyLinkClicked(sender, e);

            this.btnUpdate.Enabled = this.IsVerifiedUpdatedName;
        }//---------------------
        //####################################################END LINKLABEL lnkVerify EVENTS###############################################
            
        //##################################BUTTON btnUpdate EVENTS########################################
        //event is raised whent the control is clicked
        private void btnUpdateClick(object sender, EventArgs e)
        {
            if (this.BaseValidateControls())
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    String strMsg = "Are you sure you whant to update a new person information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The person information has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _personInfo.ObjectState = DataRowState.Modified;

                        _baseServiceManager.InsertUpdatePersonInformation(_userInfo, ref _personInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdated = true;

                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    ProcStatic.ShowErrorDialog(ex.Message + "\n\nError Updating Person Information", "Error Updating");
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }
        }//------------------------
        //##################################END BUTTON btnUpdate EVENTS########################################
        #endregion
    }
}
