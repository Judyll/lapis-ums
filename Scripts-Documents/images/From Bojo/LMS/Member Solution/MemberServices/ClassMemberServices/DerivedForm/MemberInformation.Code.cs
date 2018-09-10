using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MemberServices
{
    partial class MemberInformation
    {
        #region Class Data Member Decleration
        protected CommonExchange.Member _memberInfo;
        protected MemberLogic _memberManager;

        #endregion

        #region Class Constructors
        public MemberInformation()
        {
            this.InitializeComponent();
        }

        public MemberInformation(CommonExchange.SysAccess userInfo, MemberLogic memberManager)
            : base(userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _memberManager = memberManager;

            this.txtMemberId.Validated += new EventHandler(txtMemberIdValidated);
            this.lnkMembershipDate.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkMembershipDateLinkClicked);
            this.cboMemberClassification.SelectedIndexChanged += new EventHandler(cboClassificationSelectedIndexChanged);
            this.cboMemberType.SelectedIndexChanged += new EventHandler(cboMemberTypeSelectedIndexChanged);
            this.txtReasonOfMembership.Validated += new EventHandler(txtReasonOfMembershipValidated);
            this.txtCertificationInformation.Validated += new EventHandler(txtCertificationInformationValidated);
            this.txtOtherCooperativeMembership.Validated += new EventHandler(txtOtherCooperativeMembershipValidated);
            this.txtOtherMemberInformation.Validated += new EventHandler(txtOtherMemberInformationValidated);
            this.lblStatus.Click += new EventHandler(lblStatusClick);
            this.pbxMemberInformation.Click += new EventHandler(pbxMemberInformationClick);
        }       
        #endregion

        #region Class Event Void Procedures
        //####################################################CLASS PersonInformationCreateUpdate EVENTS###############################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            base.ClassLoad(sender, e);

            _memberInfo = new CommonExchange.Member();

            _memberInfo.IsActive = true;

            this.SetUserStatusControl();

            _memberManager.InitializeClassificationCombo(this.cboMemberClassification);
            _memberManager.InitializeMemberTypeComboBox(this.cboMemberType);
        }//----------------------
        //####################################################END CLASS PersonInformationCreateUpdate EVENTS###############################################

        //####################################################TEXTBOX txtMemberId EVENTS###############################################
        //event is raised when the control is validated
        private void txtMemberIdValidated(object sender, EventArgs e)
        {
            _memberInfo.MemberId = BaseServices.ProcStatic.TrimStartEndString(this.txtMemberId.Text);
        }//------------------------
        //####################################################END TEXTBOX txtMemberId EVENTS###############################################

        //####################################################LINKLABEL lnkMembershipDate EVENTS###############################################
        //event is raised when the control is clicked
        private void lnkMembershipDateLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            DateTime mDate = DateTime.MinValue;

            if (String.IsNullOrEmpty(_memberInfo.MembershipDate))
            {
                mDate = DateTime.Parse(_baseServiceManager.ServerDateTime);
            }
            else
            {
                mDate = DateTime.Parse(_memberInfo.MembershipDate);
            }

            using (BaseServices.Control.DatePicker frmPicker = new BaseServices.Control.DatePicker(mDate))
            {
                frmPicker.ShowDialog(this);

                if (frmPicker.HasSelectedDate)
                {
                    if (DateTime.TryParse(frmPicker.GetSelectedDate.ToLongDateString() + " " +
                            DateTime.Parse(_baseServiceManager.ServerDateTime).ToLongTimeString(), out mDate))
                    {
                        _memberInfo.MembershipDate = mDate.ToString();
                    }

                    this.txtMembershipDate.Text = mDate.ToLongDateString();
                }
            }

            this.Cursor = Cursors.Arrow;
        }//---------------------
        //####################################################END LINKLABEL lnkMembershipDate EVENTS###############################################

        //####################################################COMBOBOX cboClassification EVENTS###############################################
        //event is raised when the control is selected index changed
        private void cboClassificationSelectedIndexChanged(object sender, EventArgs e)
        {
            _memberInfo.ClassificationInfo = _memberManager.GetMemberClassificationInformation(this.cboMemberClassification.SelectedIndex);
        }//-----------------------
        //####################################################END COMBOBOX cboClassification EVENTS###############################################

        //####################################################COMBOBOX cboMemberType EVENTS###############################################
        //event is raised when the control is selected index changed
        private void cboMemberTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            _memberInfo.MemberTypeInfo = _memberManager.GetMemberTypeInformation(this.cboMemberType.SelectedIndex);
        }//--------------------------
        //####################################################END COMBOBOX cboMemberType EVENTS###############################################

        //####################################################TEXTBOX txtOtherMemberInformation EVENTS###############################################
        //event is raised when the control is validated
        private void txtOtherMemberInformationValidated(object sender, EventArgs e)
        {
            _memberInfo.OtherMemberInformation = BaseServices.ProcStatic.TrimStartEndString(this.txtOtherMemberInformation.Text);
        }//------------------------
        //####################################################END TEXTBOX txtOtherMemberInformation EVENTS###############################################

        //####################################################TEXTBOX txtOtherCooperativeMembership EVENTS###############################################
        //event is raised when the control is validated
        private void txtOtherCooperativeMembershipValidated(object sender, EventArgs e)
        {
            _memberInfo.OtherCoopMembership = BaseServices.ProcStatic.TrimStartEndString(this.txtOtherCooperativeMembership.Text);
        }//-----------------------
        //####################################################END TEXTBOX txtOtherCooperativeMembership EVENTS###############################################

        //####################################################TEXTBOX txtCertificationInformation EVENTS###############################################
        //event is raised when the control is validated
        private void txtCertificationInformationValidated(object sender, EventArgs e)
        {
            _memberInfo.CertificationInformation = BaseServices.ProcStatic.TrimStartEndString(this.txtCertificationInformation.Text);
        }//------------------------
        //####################################################END TEXTBOX txtCertificationInformation EVENTS###############################################

        //####################################################TEXTBOX txtReasonOfMembership EVENTS###############################################
        //event is raised when the control is validated
        private void txtReasonOfMembershipValidated(object sender, EventArgs e)
        {
            _memberInfo.ReasonForMembership = BaseServices.ProcStatic.TrimStartEndString(this.txtReasonOfMembership.Text);
        }//-------------------------
        //####################################################END TEXTBOX txtReasonOfMembership EVENTS###############################################

        //####################################################LABEL lblStatus EVENTS###############################################
        //event is raised when the control is clicked
        private void lblStatusClick(object sender, EventArgs e)
        {
            this.SetUserStatusControl();
        }//------------------------
        //####################################################END LABEL lblStatus EVENTS###############################################

        //####################################################PICTUREBOX pbxMemberInformation EVENTS###############################################
        //event is raised when the control is clicked
        private void pbxMemberInformationClick(object sender, EventArgs e)
        {
            this.tabCntPerson.SelectedIndex = 4;
        }//------------------------
        //####################################################END PICTUREBOX pbxMemberInformation EVENTS###############################################


        protected override void btnShowDocumentClick(object sender, EventArgs e)
        {
            base.btnShowDocumentClick(sender, e);
        }
        #endregion

        #region Programmers-Defined Void Procedures
        //this procedure will set user status control
        public void SetUserStatusControl()
        {
            _memberInfo.IsActive = !_memberInfo.IsActive;

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
        }//-----------------------
        #endregion

        #region Programmers-Defined Function
        //this fucntion will validate controls                       
        public Boolean MemberValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.txtMemberId, String.Empty);
            _errProvider.SetError(this.txtMembershipDate, String.Empty);
            _errProvider.SetError(this.cboMemberClassification, String.Empty);
            _errProvider.SetError(this.cboMemberType, String.Empty);

            if (String.IsNullOrEmpty(_memberInfo.MemberId))
            {
                _errProvider.SetError(this.txtMemberId, "Membership id is required.");
                _errProvider.SetIconAlignment(this.txtMemberId, ErrorIconAlignment.MiddleRight);

                this.tabCntPerson.SelectedIndex = 4;

                isValid = false;
            }

            if (String.IsNullOrEmpty(_memberInfo.MembershipDate))
            {
                _errProvider.SetError(this.txtMembershipDate, "Membership date is required.");
                _errProvider.SetIconAlignment(this.txtMembershipDate, ErrorIconAlignment.MiddleRight);

                this.tabCntPerson.SelectedIndex = 4;

                isValid = false;
            }

            if (String.IsNullOrEmpty(_memberInfo.ClassificationInfo.ClassificationId))
            {
                _errProvider.SetError(this.cboMemberClassification, "Membership clasification is required.");
                _errProvider.SetIconAlignment(this.cboMemberClassification, ErrorIconAlignment.MiddleRight);

                this.tabCntPerson.SelectedIndex = 4;

                isValid = false;
            }

            if (String.IsNullOrEmpty(_memberInfo.MemberTypeInfo.MemberTypeId))
            {
                _errProvider.SetError(this.cboMemberType, "Membership type is required.");
                _errProvider.SetIconAlignment(this.cboMemberType, ErrorIconAlignment.MiddleRight);

                this.tabCntPerson.SelectedIndex = 4;

                isValid = false;
            }

            if (_memberManager.IsExistsMemberIDMemberInformation(_userInfo, _memberInfo.MemberId, _memberInfo.MemberSysId))
            {
                _errProvider.SetError(this.txtMemberId, "Membership information already exist.");
                _errProvider.SetIconAlignment(this.txtMemberId, ErrorIconAlignment.MiddleLeft);

                this.tabCntPerson.SelectedIndex = 4;

                isValid = false;
            }

            return isValid;
        }//------------------------
        #endregion
    }
}

