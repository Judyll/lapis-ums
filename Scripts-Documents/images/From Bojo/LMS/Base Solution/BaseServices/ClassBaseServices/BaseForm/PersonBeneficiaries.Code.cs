using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace BaseServices
{
    partial class PersonBeneficiaries 
    {

        #region Class Data Member Declaration
        protected CommonExchange.SysAccess _userInfo;
        protected BaseServicesLogic _baseServiceManager;
        
        private String _personSysIdExcludeList;

        private ErrorProvider _errProvider;
        #endregion

        #region Class Properties Decleration
        protected CommonExchange.PersonBeneficiary _personBeneficiaryInfo;
        public CommonExchange.PersonBeneficiary PersonBeneficiaryInfo
        {
            get { return _personBeneficiaryInfo; }
        }
        #endregion

        #region Class Constructors
        public PersonBeneficiaries()
        {
            this.InitializeComponent();
        }

        public PersonBeneficiaries(CommonExchange.SysAccess userInfo, BaseServicesLogic baseServiceManager, String personSysIdExcludeList)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _baseServiceManager = baseServiceManager;
            _personSysIdExcludeList = personSysIdExcludeList;

            _errProvider = new ErrorProvider();
            
            this.Load += new EventHandler(ClassLoad);
            this.cboRelationshipType.SelectedIndexChanged += new EventHandler(cboRelationshipTypeSelectedIndexChanged);
            this.chkPrimaryBeneficiary.CheckedChanged += new EventHandler(chkEmergencyContactCheckedChanged);
            this.btnSearchPerson.Click += new EventHandler(btnSearchPersonClick);
            this.lnkViewFullDetails.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkViewFullDetailsLinkClicked);

        }        
        #endregion

        #region Class Event Void Procedures
        //####################################################CLASS PersonRelationship EVENTS###############################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            _personBeneficiaryInfo = new CommonExchange.PersonBeneficiary();
 
            _baseServiceManager.InitializePersonRelationshipTypeCombo(this.cboRelationshipType);            
        }//--------------------------------
        //####################################################END CLASS PersonRelationship EVENTS###############################################

        //####################################################COMBOX cboRelationship EVENTS###############################################
        //event is raised when the selected index is changed
        private void cboRelationshipTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            _personBeneficiaryInfo.RelationshipTypeInfo = _baseServiceManager.GetPersonRelationshipType(this.cboRelationshipType.SelectedIndex);
        }//--------------------------------
        //####################################################END COMBOX cboRelationship EVENTS###############################################

        //####################################################CHECKEDBOX chkEmergencyContact EVENTS###############################################
        //event is raised when the checked changed
        private void chkEmergencyContactCheckedChanged(object sender, EventArgs e)
        {
            _personBeneficiaryInfo.IsPrimaryBeneficiary = this.chkPrimaryBeneficiary.Checked;
        }//------------------------------
        //####################################################END CHECKEDBOX chkEmergencyContact EVENTS###############################################

        //####################################################BUTTON bntSearchPerson EVENTS###############################################
        //event is raised when the control is clicked
        private void btnSearchPersonClick(object sender, EventArgs e)
        {
            using (PersonSearchOnTextBoxList frmSearch = new PersonSearchOnTextBoxList(_userInfo, _baseServiceManager, _personSysIdExcludeList))
            {
                frmSearch.ShowDialog(this);

                if (frmSearch.HasSelected)
                {
                    this.SetPersonRelationshipControls(_baseServiceManager.GetPersonDetails(_userInfo, frmSearch.PrimaryId));
                }
                else if (frmSearch.HasRecorded)
                {
                    this.SetPersonRelationshipControls(frmSearch.PersonInfo);
                }

                this.lnkViewFullDetails.Enabled = true;
            }
        }//-----------------------------
        //####################################################END BUTTON bntSearchPerson EVENTS###############################################

        //####################################################LINK LABEL lnkViewFullDetails EVENTS###############################################
        //event is raised when the control is clicked
        private void lnkViewFullDetailsLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (PersonInformationUpdate frmUpdate = new PersonInformationUpdate(_userInfo,
                _baseServiceManager.GetPersonDetails(_userInfo, _personBeneficiaryInfo.PersonInRelationshipWith.PersonSysId), 
                _baseServiceManager))
            {
                frmUpdate.PersonArchiveVisible = false;
                frmUpdate.SetPersonInformationControls(true);

                frmUpdate.ShowDialog(this);

                if (frmUpdate.HasUpdated)
                {
                    _personBeneficiaryInfo.PersonInRelationshipWith = frmUpdate.PersonInfo;

                    _baseServiceManager.InitializePersonRelationshipTypeCombo(this.cboRelationshipType, 
                        _personBeneficiaryInfo.RelationshipTypeInfo.RelationshipTypeId);

                    this.SetPersonRelationshipControls(_personBeneficiaryInfo.PersonInRelationshipWith);

                    this.chkPrimaryBeneficiary.Checked = _personBeneficiaryInfo.IsPrimaryBeneficiary;
                }
            }
        }//-----------------------------
        //####################################################END LINK LABEL lnkViewFullDetails EVENTS###############################################
        #endregion

        #region Programmer-Defined Void Procedures
        //this procedure will set Person Relationship controls
        private void SetPersonRelationshipControls(CommonExchange.Person personInfo)
        {
            _personBeneficiaryInfo.PersonInRelationshipWith.PersonSysId = personInfo.PersonSysId;
            _personBeneficiaryInfo.PersonInRelationshipWith.LastName = personInfo.LastName;
            _personBeneficiaryInfo.PersonInRelationshipWith.FirstName = personInfo.FirstName;
            _personBeneficiaryInfo.PersonInRelationshipWith.MiddleName = personInfo.MiddleName;
            _personBeneficiaryInfo.PersonInRelationshipWith.BirthDate = personInfo.BirthDate;
            _personBeneficiaryInfo.PersonInRelationshipWith.PresentAddress = personInfo.PresentAddress;
            _personBeneficiaryInfo.PersonInRelationshipWith.PresentPhoneNos = personInfo.PresentPhoneNos;
            _personBeneficiaryInfo.PersonInRelationshipWith.LifeStatusCode = personInfo.LifeStatusCode;
            _personBeneficiaryInfo.PersonInRelationshipWith.GenderCode = personInfo.GenderCode;

            this.lblPersonLastName.Text = personInfo.LastName;
            this.lblPersonFirstName.Text = personInfo.FirstName;
            this.lblPersonMiddleName.Text = personInfo.MiddleName;
            this.lblPresentAddress.Text = personInfo.PresentAddress;
            this.lblPresentPhoneNo.Text = personInfo.PresentPhoneNos;

        }//-------------------------------
        #endregion

        #region Programmer-Defined Functions
        //this procedure will validate controls
        public Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.btnSearchPerson, "");
            _errProvider.SetError(this.cboRelationshipType, "");

            if (String.IsNullOrEmpty(_personBeneficiaryInfo.PersonInRelationshipWith.PersonSysId))
            {
                _errProvider.SetError(this.btnSearchPerson, "You must select a person information.");
                _errProvider.SetIconAlignment(this.btnSearchPerson, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            if (String.IsNullOrEmpty(_personBeneficiaryInfo.RelationshipTypeInfo.RelationshipTypeId))
            {
                _errProvider.SetError(this.cboRelationshipType, "You must select a person relationship type.");
                _errProvider.SetIconAlignment(this.cboRelationshipType, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            return isValid;
        }//--------------------------
        #endregion
    }
}



