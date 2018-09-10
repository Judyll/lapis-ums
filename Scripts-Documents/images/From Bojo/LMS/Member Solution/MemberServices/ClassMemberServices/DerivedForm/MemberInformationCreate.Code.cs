using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace MemberServices
{
    partial class MemberInformationCreate
    {

        #region Class Properties Declarations
        private Boolean _hasCreated = false;
        public Boolean HasCreated
        {
            get { return _hasCreated; }
        }
        #endregion

        #region Class Constructors
        public MemberInformationCreate(CommonExchange.SysAccess userInfo, MemberLogic memberManager)
            : base(userInfo, memberManager)
        {
            this.InitializeComponent();

            this.btnCancel.Click += new EventHandler(btnCancelClick);
            this.btnCreate.Click += new EventHandler(btnCreateClick);            
        }
        #endregion

        #region Class Event Void Procedures
        //####################################################CLASS MemberInformationCreate EVENTS###############################################
        //event is raised when the class is clossing
        protected override void ClassClossing(object sender, FormClosingEventArgs e)
        {
            if (!_hasCreated)
            {
                String strMsg = "Are you sure you want to cancel the creation of a new member information?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
          
            base.ClassClossing(sender, e);
        }//---------------------------
        //####################################################END CLASS MemberInformationCreate EVENTS###############################################

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

        //##############################################BUTTON btnCancel EVENTS########################################################
        //event is raised when the button is clicked
        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }//-----------------------
        //##############################################END BUTTON btnCancel EVENTS########################################################

        //#############################################BUTTON btnCreate EVENTS########################################################
        //event is raised when the button is clicked
        private void btnCreateClick(object sender, EventArgs e)
        {
            if (this.MemberValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to create the new member information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Create", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The member information has been successfully created.";

                        this.Cursor = Cursors.WaitCursor;

                        _memberInfo.PersonInfo = _personInfo;
                        _memberInfo.PersonInfo.ObjectState = DataRowState.Added;
                        _memberInfo.ObjectState = DataRowState.Added;

                        _memberManager.InsertMemberInformation(_userInfo, _memberInfo);

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
                    BaseServices.ProcStatic.ShowErrorDialog(ex.Message, "Error in Creating");
                }
            }
        }//----------------------
        //#############################################END BUTTON btnCreate EVENTS########################################################
        #endregion
    }
}
