using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BaseServices
{
    partial class PersonReference
    {
        #region Class Data Member Declaration
        protected CommonExchange.SysAccess _userInfo;
        protected BaseServicesLogic _baseServiceManager;

        private String _personSysIdExcludeList;

        private ErrorProvider _errProvider;
        #endregion

        #region Class Properties Decleration
        protected CommonExchange.PersonReference _personReferenceInfo;
        public CommonExchange.PersonReference PersonReferenceInfo
        {
            get { return _personReferenceInfo; }
        }
        #endregion

        #region Class Constructors
        public PersonReference()
        {
            this.InitializeComponent();
        }

        public PersonReference(CommonExchange.SysAccess userInfo, BaseServicesLogic baseServiceManager, String personSysIdExcludeList)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _baseServiceManager = baseServiceManager;
            _personSysIdExcludeList = personSysIdExcludeList;

            _errProvider = new ErrorProvider();

            this.Load += new EventHandler(ClassLoad);
            this.btnSearchPerson.Click += new EventHandler(btnSearchPersonClick);
            this.lnkViewFullDetails.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkViewFullDetailsLinkClicked);
        }
        #endregion

        #region Class Event Void Procedures
        //####################################################CLASS PersonReference EVENTS###############################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            _personReferenceInfo = new CommonExchange.PersonReference();
        }//-----------------------
        //####################################################END CLASS PersonReference EVENTS###############################################

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
                 _baseServiceManager.GetPersonDetails(_userInfo, _personReferenceInfo.PersonInReferenceWith.PersonSysId),
                 _baseServiceManager))
            {
                frmUpdate.PersonArchiveVisible = false;
                frmUpdate.SetPersonInformationControls(true);

                frmUpdate.ShowDialog(this);

                if (frmUpdate.HasUpdated)
                {
                    _personReferenceInfo.PersonInReferenceWith = frmUpdate.PersonInfo;

                    this.SetPersonRelationshipControls(_personReferenceInfo.PersonInReferenceWith);
                }
            }
        }//-----------------------------
        //####################################################END LINK LABEL lnkViewFullDetails EVENTS###############################################
        #endregion

        #region Programmer-Defined Void Procedures
        //this procedure will set Person Relationship controls
        private void SetPersonRelationshipControls(CommonExchange.Person personInfo)
        {
            _personReferenceInfo.PersonInReferenceWith.PersonSysId = personInfo.PersonSysId;
            _personReferenceInfo.PersonInReferenceWith.LastName = personInfo.LastName;
            _personReferenceInfo.PersonInReferenceWith.FirstName = personInfo.FirstName;
            _personReferenceInfo.PersonInReferenceWith.MiddleName = personInfo.MiddleName;
            _personReferenceInfo.PersonInReferenceWith.BirthDate = personInfo.BirthDate;
            _personReferenceInfo.PersonInReferenceWith.PresentAddress = personInfo.PresentAddress;
            _personReferenceInfo.PersonInReferenceWith.PresentPhoneNos = personInfo.PresentPhoneNos;
            _personReferenceInfo.PersonInReferenceWith.LifeStatusCode = personInfo.LifeStatusCode;
            _personReferenceInfo.PersonInReferenceWith.GenderCode = personInfo.GenderCode;

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

            if (String.IsNullOrEmpty(_personReferenceInfo.PersonInReferenceWith.PersonSysId))
            {
                _errProvider.SetError(this.btnSearchPerson, "You must select a person information.");
                _errProvider.SetIconAlignment(this.btnSearchPerson, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            return isValid;
        }//--------------------------
        #endregion
    }
}
