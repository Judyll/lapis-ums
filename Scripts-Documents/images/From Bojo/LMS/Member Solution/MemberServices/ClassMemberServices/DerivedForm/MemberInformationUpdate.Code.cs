using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace MemberServices
{
    partial class MemberInformationUpdate
    {
        #region Class Data Member Decleration
        private CommonExchange.Member _tempMemberInfo;
        #endregion

        #region Class Properties Declaration
        private Boolean _hasUpDated = false;
        public Boolean HasUpDated
        {
            get { return _hasUpDated; }
        }
        #endregion

        #region Class Constructors
        public MemberInformationUpdate(CommonExchange.SysAccess userInfo, BaseServices.BaseServicesLogic baseServicesManager,
            CommonExchange.Member memberInfo, MemberLogic memberManager)
            : base(userInfo, memberManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _memberManager = memberManager;
            _baseServiceManager = baseServicesManager;
            _memberInfo = memberInfo;
            _tempMemberInfo = (CommonExchange.Member)memberInfo.Clone();

            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);

            
        }
        #endregion

        #region Class Event Void Procedures
        //####################################################CLASS MemberInformationUpdate EVENTS###############################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            _personInfo = _memberInfo.PersonInfo;

            this.AssingControlsValue();

            this.SetPersonInformationControls(true);

            this.btnUpdate.Enabled = true;

            _baseServiceManager.InitializePersonBeneficiaryDataGridView(this.dgvPersonBenificiaries,
               _personInfo.PersonBeneficiaryList, this.lblBeneficiariesStatus);
            _baseServiceManager.InitializePersonReferenceDataGridView(this.dgvPersonReference, _personInfo.PersonReferenceList);

            BaseServices.ProcStatic.SetDataGridViewColumns(this.dgvPersonBenificiaries, false);
            BaseServices.ProcStatic.SetDataGridViewColumns(this.dgvPersonReference, false);

            this.txtMemberId.Text = _memberInfo.MemberId;

            DateTime dMemDate = DateTime.MinValue;

            this.txtMembershipDate.Clear();

            if (DateTime.TryParse(_memberInfo.MembershipDate, out dMemDate))
            {
                this.txtMembershipDate.Text = DateTime.Compare(dMemDate, DateTime.MinValue) == 0 ? String.Empty : dMemDate.ToLongDateString();
            }

            _memberManager.InitializeClassificationCombo(this.cboMemberClassification, _memberInfo.ClassificationInfo.ClassificationId);
            _memberManager.InitializeMemberTypeComboBox(this.cboMemberType, _memberInfo.MemberTypeInfo.MemberTypeId);

            this.txtReasonOfMembership.Text = _memberInfo.ReasonForMembership;
            this.txtCertificationInformation.Text = _memberInfo.CertificationInformation;
            this.txtOtherCooperativeMembership.Text = _memberInfo.OtherCoopMembership;
            this.txtOtherMemberInformation.Text = _memberInfo.OtherMemberInformation;

            if (_memberInfo.IsActive)
            {
                this.lblStatus.Text = "ACTIVE";
                this.lblStatus.ForeColor = Color.Green;
            }
            else
            {
                this.lblStatus.Text = "DEACTIVATED";
                this.lblStatus.ForeColor = Color.Red;
            }

        }//----------------------------------

        //event is raised when the class is clossing
        protected override void ClassClossing(object sender, FormClosingEventArgs e)
        {
            if (!_hasUpDated && !_memberInfo.Equals(_tempMemberInfo))
            {
                String strMsg = "There has been changes made in the current member information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";

                DialogResult msgResutl = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResutl == DialogResult.No)
                {
                    e.Cancel = true;
                }               
            }

            base.ClassClossing(sender, e);
        }//--------------------------
        //####################################################END CLASS MemberInformationUpdate EVENTS###############################################

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

        //#########################################BUTTON btnClose EVENTS##################################################
        //event is raised when the button is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//-------------------
        //#########################################END BUTTON btnClose EVENTS##################################################

        //#########################################BUTTON btnUpdate EVENTS#####################################################
        //event is raised when the button is clicked
        private void btnUpdateClick(object sender, EventArgs e)
        {
            if (this.MemberValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to update the member information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The member information has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _personInfo.ObjectState = DataRowState.Modified;
                        _memberInfo.PersonInfo = _personInfo;
                        _memberInfo.ObjectState = DataRowState.Modified;

                        _memberManager.UpdateMemberInformation(_userInfo, _memberInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpDated = true;
  
                        this.Close();
                    }
                    else if (msgResult == DialogResult.Cancel)
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    BaseServices.ProcStatic.ShowErrorDialog(ex.Message, "Error in Updating");
                }
            }
        }//----------------------
        //###########################################END BUTTON btnUpdate EVENTS#####################################################
        #endregion
    }
}
