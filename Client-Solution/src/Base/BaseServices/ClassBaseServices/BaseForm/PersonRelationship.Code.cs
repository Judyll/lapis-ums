using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace BaseServices
{
    partial class PersonRelationship : IDisposable
    {

        #region Class Data Member Declaration
        protected CommonExchange.SysAccess _userInfo;
        protected BaseServicesLogic _baseServiceManager;

        private String _personSysIdExcludeList;

        private ErrorProvider _errProvider;
        #endregion

        #region Class Properties Declaration
        protected CommonExchange.PersonRelationship _personRelationshipInfo;
        public CommonExchange.PersonRelationship PersonRelationshipInfo
        {
            get { return _personRelationshipInfo; }
        }
        #endregion

        #region Class Constructors
        public PersonRelationship()
        {
            this.InitializeComponent();
        }

        public PersonRelationship(CommonExchange.SysAccess userInfo, BaseServicesLogic baseServiceManager, String personSysIdExcludeList)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _baseServiceManager = baseServiceManager;
            _personSysIdExcludeList = personSysIdExcludeList;

            _errProvider = new ErrorProvider();
            
            this.Load += new EventHandler(ClassLoad);
            this.cboRelationshipType.SelectedIndexChanged += new EventHandler(cboRelationshipTypeSelectedIndexChanged);
            this.chkEmergencyContact.CheckedChanged += new EventHandler(chkEmergencyContactCheckedChanged);
            this.btnSearchPerson.Click += new EventHandler(btnSearchPersonClick);

            if (RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) || RemoteServerLib.ProcStatic.IsSystemAccessPayrollMaster(_userInfo) ||
                RemoteServerLib.ProcStatic.IsSystemAccessStudentDataController(_userInfo))
            {
                this.lnkViewFullDetails.Visible = true;

                this.lnkViewFullDetails.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkViewFullDetailsLinkClicked);
            }
            else
            {
                this.lnkViewFullDetails.Visible = false;
            }
        }        
        #endregion

        #region IDisposable Members
        void IDisposable.Dispose()
        {
            if (this.pbxPerson.Image != null)
            {
                this.pbxPerson.Image.Dispose();
                this.pbxPerson.Image = null;

                this.pbxPerson.Dispose();
                this.pbxPerson = null;
            }

            GC.SuppressFinalize(this);
            GC.Collect();
        }
        #endregion

        #region Class Event Void Procedures
        //####################################################CLASS PersonRelationship EVENTS###############################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            _personRelationshipInfo = new CommonExchange.PersonRelationship();
 
            _baseServiceManager.InitializePersonRelationshipTypeCombo(this.cboRelationshipType);            
        }//--------------------------------
        //####################################################END CLASS PersonRelationship EVENTS###############################################

        //####################################################COMBOX cboRelationship EVENTS###############################################
        //event is raised when the selected index is changed
        private void cboRelationshipTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            _personRelationshipInfo.RelationshipTypeInfo = _baseServiceManager.GetPersonRelationshipType(this.cboRelationshipType.SelectedIndex); 
        }//--------------------------------
        //####################################################END COMBOX cboRelationship EVENTS###############################################

        //####################################################CHECKEDBOX chkEmergencyContact EVENTS###############################################
        //event is raised when the checked changed
        private void chkEmergencyContactCheckedChanged(object sender, EventArgs e)
        {
            _personRelationshipInfo.IsEmergencyContact = this.chkEmergencyContact.Checked;
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
                    this.SetPersonRelationshipControls(_baseServiceManager.GetPersonDetails(_userInfo,
                        _baseServiceManager.GetPersonSysId(frmSearch.RowIndex), Application.StartupPath));
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
            if (this.pbxPerson.Image != null)
            {
                this.pbxPerson.Image.Dispose();
                this.pbxPerson.Image = null;
            }

            GC.SuppressFinalize(this);
            GC.Collect();

            using (PersonInformationCreateUpdate frmUpdate = new PersonInformationCreateUpdate(_userInfo,
                _baseServiceManager.GetPersonDetails(_userInfo, _personRelationshipInfo.PersonInRelationshipWith.PersonSysId, Application.StartupPath),
                _baseServiceManager))
            {
                frmUpdate.PersonArchiveVisible = false;
                frmUpdate.SetPersonInformationControls(true);
                frmUpdate.SetRecordButtonEnable = true;
                frmUpdate.ShowDialog(this);

                if (frmUpdate.HasRecorded)
                {
                    _personRelationshipInfo.PersonInRelationshipWith = frmUpdate.PersonInfo;

                    _baseServiceManager.InitializePersonRelationshipTypeCombo(this.cboRelationshipType,
                        _personRelationshipInfo.RelationshipTypeInfo.RelationshipTypeId);

                    this.SetPersonRelationshipControls(_personRelationshipInfo.PersonInRelationshipWith);


                    this.chkEmergencyContact.Checked = _personRelationshipInfo.IsEmergencyContact;
                }
            }

            this.SetPersonRelationshipControls(_personRelationshipInfo.PersonInRelationshipWith);
        }//-----------------------------
        //####################################################END LINK LABEL lnkViewFullDetails EVENTS###############################################
        #endregion

        #region Programmer-Defined Void Procedures
        //this procedure will set Person Relationship controls
        private void SetPersonRelationshipControls(CommonExchange.Person personInfo)
        {
            _personRelationshipInfo.PersonInRelationshipWith.PersonSysId = personInfo.PersonSysId;
            _personRelationshipInfo.PersonInRelationshipWith.LastName = personInfo.LastName;
            _personRelationshipInfo.PersonInRelationshipWith.FirstName = personInfo.FirstName;
            _personRelationshipInfo.PersonInRelationshipWith.MiddleName = personInfo.MiddleName;
            _personRelationshipInfo.PersonInRelationshipWith.BirthDate = personInfo.BirthDate;
            _personRelationshipInfo.PersonInRelationshipWith.PresentAddress = personInfo.PresentAddress;
            _personRelationshipInfo.PersonInRelationshipWith.PresentPhoneNos = personInfo.PresentPhoneNos;
            _personRelationshipInfo.PersonInRelationshipWith.LifeStatusCode = personInfo.LifeStatusCode;
            _personRelationshipInfo.PersonInRelationshipWith.GenderCode = personInfo.GenderCode;
            _personRelationshipInfo.PersonInRelationshipWith.FilePath = personInfo.FilePath;

            this.lblPersonLastName.Text = personInfo.LastName;
            this.lblPersonFirstName.Text = personInfo.FirstName;
            this.lblPersonMiddleName.Text = personInfo.MiddleName;
            this.lblPresentAddress.Text = personInfo.PresentAddress;
            this.lblPresentPhoneNo.Text = personInfo.PresentPhoneNos;

            if (!String.IsNullOrEmpty(personInfo.FilePath) && File.Exists(personInfo.FilePath))
            {
                this.pbxPerson.Image = Image.FromFile(personInfo.FilePath);
            }
            else
            {
                this.pbxPerson.Image = null;
            }
        }//-------------------------------
        #endregion

        #region Programmer-Defined Functions
        //this procedure will validate controls
        public Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.btnSearchPerson, "");
            _errProvider.SetError(this.cboRelationshipType, "");

            if (String.IsNullOrEmpty(_personRelationshipInfo.PersonInRelationshipWith.PersonSysId))
            {
                _errProvider.SetError(this.btnSearchPerson, "You must select a person information.");
                _errProvider.SetIconAlignment(this.btnSearchPerson, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            if (String.IsNullOrEmpty(_personRelationshipInfo.RelationshipTypeInfo.RelationshipTypeId))
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



