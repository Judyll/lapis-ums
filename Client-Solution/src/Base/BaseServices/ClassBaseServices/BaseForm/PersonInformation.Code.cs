using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace BaseServices
{
    partial class PersonInformation : IDisposable
    {
        #region Class Data Member Declaration
        protected CommonExchange.SysAccess _userInfo;
        protected CommonExchange.Person _personInfo;
        
        protected BaseServicesLogic _baseServiceManager;

        protected ErrorProvider _errProvider; 
        #endregion

        #region Class Properties Declaration
        private Boolean _isVerifiedUpdatedName = false;
        public Boolean IsVerifiedUpdatedName
        {
            get { return _isVerifiedUpdatedName; }
        }

        protected Boolean _isForStudentVerification = false;
        public Boolean IsForStudentVerification
        {
            set { _isForStudentVerification = value; }
        }

        private Boolean _hasSelectedPersonFromVerification = false;
        public Boolean HasSelectedPersonFromVerification
        {
            get { return _hasSelectedPersonFromVerification; }
        }

        protected Boolean _hasSelectedForPersonUpdate = false;
        public Boolean HasSelectedForPersonUpdate
        {
            get { return _hasSelectedForPersonUpdate; }
        }

        private Boolean _isForPersonVerification = false;
        public Boolean IsForPersonVerification
        {
            set { _isForPersonVerification = value; }
        }

        private Boolean _isForNewUserVerification = false;
        public Boolean IsForNewUserVerification
        {
            set { _isForNewUserVerification = value; }
        }

        public Boolean PersonArchiveVisible
        {
            set { this.lnkPersonArchive.Visible = value; }
        }

        public CommonExchange.Person PersonInfo
        {
            get { return _personInfo; }
        }

        private CommonExchange.Employee _empInfo;
        public CommonExchange.Employee EmployeeInformation
        {
            get { return _empInfo; }
        }

        public CommonExchange.SysAccess _newUserInfo;
        public CommonExchange.SysAccess NewUserInfo
        {
            get { return _newUserInfo; }
        }

        private Int32 _rowIndex = -1;
        public Int32 RowIndexForPersonSearch
        {
            get { return _rowIndex; }
        }
        #endregion

        #region Class Constructors
        public PersonInformation()
        {
            this.InitializeComponent();

            _errProvider = new ErrorProvider();
        }

        public PersonInformation(CommonExchange.SysAccess userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            
            _errProvider = new ErrorProvider();

            this.Load += new EventHandler(ClassLoad);
            this.txtLastName.Validating += new System.ComponentModel.CancelEventHandler(txtNameValidating);
            this.txtLastName.Validated += new EventHandler(txtLastNameValidated);
            this.txtLastName.KeyPress += new KeyPressEventHandler(TextBoxKeyPressLettersOnly);
            this.txtFirstName.Validated += new EventHandler(txtFirstNameValidated);
            this.txtFirstName.KeyPress += new KeyPressEventHandler(TextBoxKeyPressLettersOnly);
            this.txtFirstName.Validating += new System.ComponentModel.CancelEventHandler(txtNameValidating);
            this.txtMiddleName.Validated += new EventHandler(txtMiddleNameValidated);
            this.txtMiddleName.KeyPress += new KeyPressEventHandler(TextBoxKeyPressLettersOnly);
            this.txtMiddleName.Validating += new System.ComponentModel.CancelEventHandler(txtNameValidating);
            this.txtECode.Validated += new EventHandler(txtECodeValidated);
            this.txtPlaceOfBirth.Validated += new EventHandler(txtPlaceOfBirthValidated);
            this.txtPressentAddress.Validated += new EventHandler(txtPressentAddressValidated);
            this.txtPressentPhone.Validated += new EventHandler(txtPressentPhoneValidated);
            this.txtHomeAddress.Validated += new EventHandler(txtHomeAddressValidated);
            this.txtHomePhone.Validated += new EventHandler(txtHomePhoneValidated);
            this.txtEMail.Validated += new EventHandler(txtEMailValidated);
            this.txtCitizenship.Validated += new EventHandler(txtCitizenshipValidated);
            this.txtNationality.Validated += new EventHandler(txtNationalityValidated);
            this.txtReligion.Validated += new EventHandler(txtReligionValidated);
            this.txtOtherInformation.Validated += new EventHandler(txtOtherInformationValidated);
            this.cboGender.SelectedIndexChanged += new EventHandler(cboGenderSelectedIndexChanged);
            this.cboLifeStatus.SelectedIndexChanged += new EventHandler(cboLifeStatusSelectedIndexChanged);
            this.cboMaritalStatus.SelectedIndexChanged += new EventHandler(cboMaritalStatusSelectedIndexChanged);
            this.lnkBirthDate.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkBirthDateLinkClicked);
            this.lnkMarriageDate.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkMarriageDateLinkClicked);
            this.lnkVerify.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkVerifyLinkClicked);
            this.lnkPersonArchive.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkPersonArchiveLinkClicked);

            if (RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo))
            {
                this.pbxPerson.Cursor = Cursors.Hand;

                this.pbxPerson.Click += new EventHandler(pbxPersonClick);
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

        #region Class Event Procedures
        //####################################################CLASS PersonalInformation EVENTS###############################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            _baseServiceManager = new BaseServicesLogic(_userInfo);

            _personInfo = new CommonExchange.Person();

            _baseServiceManager.InitializeCodeReferenceCombo(this.cboGender, CommonExchange.CodeEntityId.Gender);
            _baseServiceManager.InitializeCodeReferenceCombo(this.cboLifeStatus, CommonExchange.CodeEntityId.LifeStatus);
            _baseServiceManager.InitializeCodeReferenceCombo(this.cboMaritalStatus, CommonExchange.CodeEntityId.MaritalStatus);       
           
        }//----------------------
        //####################################################END CLASS PersonalInformation EVENTS###############################################

        //##############################################TEXTBOXES EVENTS####################################################################
        //event is raised when the key is pressed
        protected virtual void TextBoxKeyPressLettersOnly(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxLettersOnly(e);

            if (String.IsNullOrEmpty(_personInfo.PersonSysId))
            {
                this.lnkVerify.Enabled = true;

                this.SetPersonInformationControls(false);
            }
        }//------------------------------------
        //#############################################END TEXTBOXES EVENTS##################################################################

        //####################################################TEXTBOX VALIDATION EVENTS###############################################
        //event is raised when the control is validated
        private void txtLastNameValidated(object sender, EventArgs e)
        {
            _personInfo.LastName = RemoteClient.ProcStatic.TrimStartEndString(this.txtLastName.Text);

            if (String.IsNullOrEmpty(_personInfo.PersonSysId))
            {
                if (!String.IsNullOrEmpty(_personInfo.FirstName) && !String.IsNullOrEmpty(_personInfo.LastName))
                {
                    this.lnkVerify.Enabled = true;
                }
                else
                {
                    this.SetPersonInformationControls(false);
                    this.lnkVerify.Enabled = false;
                }
            }
        }//--------------------------

        //event is raised when the control is validated
        private void txtFirstNameValidated(object sender, EventArgs e)
        {
            _personInfo.FirstName = RemoteClient.ProcStatic.TrimStartEndString(this.txtFirstName.Text);

            if (String.IsNullOrEmpty(_personInfo.PersonSysId))
            {
                if (!String.IsNullOrEmpty(_personInfo.FirstName) && !String.IsNullOrEmpty(_personInfo.LastName))
                {
                    this.lnkVerify.Enabled = true;
                }
                else
                {
                    this.SetPersonInformationControls(false);
                    this.lnkVerify.Enabled = false;
                }
            }
        }//-----------------------------

        //event is raised when the control is validated
        private void txtMiddleNameValidated(object sender, EventArgs e)
        {
            _personInfo.MiddleName = RemoteClient.ProcStatic.TrimStartEndString(this.txtMiddleName.Text);
        }//----------------------

        //event is raised when the control is validated
        private void txtECodeValidated(object sender, EventArgs e)
        {
            _personInfo.ECode = RemoteClient.ProcStatic.TrimStartEndString(this.txtECode.Text);
        }//-----------------------

        //event is raised when the control is validated
        private void txtPlaceOfBirthValidated(object sender, EventArgs e)
        {
            _personInfo.PlaceOfBirth = RemoteClient.ProcStatic.TrimStartEndString(this.txtPlaceOfBirth.Text);
        }//------------------------

        //event is raised when the control is validated
        private void txtPressentAddressValidated(object sender, EventArgs e)
        {
            _personInfo.PresentAddress = RemoteClient.ProcStatic.TrimStartEndString(this.txtPressentAddress.Text);
        }//------------------------

        //event is raised when the control is validated
        private void txtPressentPhoneValidated(object sender, EventArgs e)
        {
            _personInfo.PresentPhoneNos = RemoteClient.ProcStatic.TrimStartEndString(this.txtPressentPhone.Text);
        }//-------------------------

        //event is raised when the control is validated
        private void txtHomeAddressValidated(object sender, EventArgs e)
        {
            _personInfo.HomeAddress = RemoteClient.ProcStatic.TrimStartEndString(this.txtHomeAddress.Text);
        }//-----------------------

        //event is raised when the control is validated
        private void txtHomePhoneValidated(object sender, EventArgs e)
        {
            _personInfo.HomePhoneNos = RemoteClient.ProcStatic.TrimStartEndString(this.txtHomePhone.Text);
        }//---------------------------

        //event is raised when the control is validated
        private void txtEMailValidated(object sender, EventArgs e)
        {
            _personInfo.EMailAddress = RemoteClient.ProcStatic.TrimStartEndString(this.txtEMail.Text);
        }//--------------------------

        //event is raised when the control is validated
        private void txtCitizenshipValidated(object sender, EventArgs e)
        {
            _personInfo.Citizenship = RemoteClient.ProcStatic.TrimStartEndString(this.txtCitizenship.Text);
        }//---------------------------

        //event is raised when the control is validated
        private void txtNationalityValidated(object sender, EventArgs e)
        {
            _personInfo.Nationality = RemoteClient.ProcStatic.TrimStartEndString(this.txtNationality.Text);
        }//-------------------------

        //event is raised when the control is validated
        private void txtReligionValidated(object sender, EventArgs e)
        {
            _personInfo.Religion = RemoteClient.ProcStatic.TrimStartEndString(this.txtReligion.Text);
        }//--------------------------

        //event is raised when the control is validated
        private void txtOtherInformationValidated(object sender, EventArgs e)
        {
            _personInfo.OtherPersonInformation = RemoteClient.ProcStatic.TrimStartEndString(this.txtOtherInformation.Text);
        }//---------------------------
        //####################################################END TEXTBOX VALIDATION EVENTS###############################################

        //####################################################TEXTBOX VALIDATING EVENTS###############################################
        //event is raised when the control is validating
        private void txtNameValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox txtBase = (TextBox)sender;

            txtBase.Text = this.SetFirstLetterToUpper(txtBase.Text);
        }//----------------------------
        //####################################################END TEXTBOX VALIDATING EVENTS###############################################

        //####################################################LINKLABEL lblBirthDate EVENTS###############################################
        //event is raised when the control is clicked
        private void lnkBirthDateLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            DateTime bDate = DateTime.MinValue;

            if (String.IsNullOrEmpty(_personInfo.BirthDate))
            {
                bDate = DateTime.Parse(_baseServiceManager.ServerDateTime);
            }
            else
            {
                bDate = DateTime.Parse(_personInfo.BirthDate);
            }

            using (RemoteClient.DatePicker frmPicker = new RemoteClient.DatePicker(bDate))
            {
                frmPicker.ShowDialog(this);

                if (frmPicker.HasSelectedDate)
                {
                    if (DateTime.TryParse(frmPicker.GetSelectedDate.ToLongDateString() + " " +
                            DateTime.Parse(_baseServiceManager.ServerDateTime).ToLongTimeString(), out bDate))
                    {
                        _personInfo.BirthDate = bDate.ToString();
                    }

                    this.txtBirthDate.Text = bDate.ToLongDateString();
                }
            }

            this.Cursor = Cursors.Arrow;
        }//-----------------------
        //####################################################END LINKLABEL lblBirthDate EVENTS###############################################

        //####################################################LINKLABEL lnkMarriageDate EVENTS###############################################
        //event is raised when the control is clicked
        private void lnkMarriageDateLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            DateTime mDate = DateTime.MinValue;

            if (String.IsNullOrEmpty(_personInfo.MarriageDate))
            {
                mDate = DateTime.Parse(_baseServiceManager.ServerDateTime);
            }
            else
            {
                mDate = DateTime.Parse(_personInfo.MarriageDate);
            }

            using (RemoteClient.DatePicker frmPicker = new RemoteClient.DatePicker(mDate))
            {
                frmPicker.ShowDialog(this);

                if (frmPicker.HasSelectedDate)
                {
                    if (DateTime.TryParse(frmPicker.GetSelectedDate.ToLongDateString() + " " +
                            DateTime.Parse(_baseServiceManager.ServerDateTime).ToLongTimeString(), out mDate))
                    {
                        _personInfo.MarriageDate = mDate.ToString();
                    }

                    this.txtMarriageDate.Text = mDate.ToLongDateString();
                }
            }

            this.Cursor = Cursors.Arrow;
        }//------------------------
        //####################################################END LINKLABEL lnkMarriageDate EVENTS###############################################

        //####################################################LINKLABEL lnkVerify EVENTS###############################################
        //event is raised when the control is clicked
        protected virtual void lnkVerifyLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                DataTable resultTable = _baseServiceManager.GetSearchPersonInformation(_userInfo, String.Empty, _personInfo.LastName, 
                    _personInfo.FirstName, String.Empty, true);

                if (resultTable.Rows.Count > 0)
                {
                    using (VerifyPersonExistenceList frmVerify = new VerifyPersonExistenceList(_userInfo, _baseServiceManager,
                        RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(_personInfo.LastName, _personInfo.FirstName, _personInfo.MiddleName), 
                        resultTable, _isForStudentVerification, _isForPersonVerification, ref this.pbxPerson))
                    {
                        frmVerify.ShowDialog(this);

                        if (frmVerify.HasSelected)
                        {
                            _personInfo = _baseServiceManager.GetPersonDetails(_userInfo,
                                _baseServiceManager.GetPersonSysId(frmVerify.RowIndex), Application.StartupPath);                            

                            this.AssingControlsValue();
                            this.SetPersonInformationControls(true);                      
                        }
                        else if (frmVerify.IsVerified && _isForPersonVerification)
                        {                          
                            this.SetPersonInformationControls(true);
                        }

                        _hasSelectedPersonFromVerification = true;
                    }
                }
                else
                {
                    MessageBox.Show("The system has successfully verified that " + RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(
                              _personInfo.LastName, _personInfo.FirstName, _personInfo.MiddleName) + " does NOT currently exist on the database." +
                              "\n\nClick OK to proceed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (_isForPersonVerification)
                    {
                        this.SetPersonInformationControls(true);
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message + "\n Error loading person verify module.", "Error Loading");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//---------------------------        
        //####################################################END LINKLABEL lnkVerify EVENTS###############################################

        //####################################################LINKLABEL lnkPersonArchive EVENTS###############################################
        //event is raised when the control is clicked
        protected virtual void lnkPersonArchiveLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (PersonSearchOnTextBoxList frmSearch = new PersonSearchOnTextBoxList(_userInfo, _baseServiceManager,
                    _isForStudentVerification, _isForNewUserVerification, this.pbxPerson))
                {
                    frmSearch.CreatePersonVisible = false;
                    frmSearch.ShowDialog(this);

                    if (frmSearch.HasSelected)
                    {
                        _rowIndex = frmSearch.RowIndex;
                      
                        _personInfo = _baseServiceManager.GetPersonDetails(_userInfo,
                            _baseServiceManager.GetPersonSysId(frmSearch.RowIndex), Application.StartupPath);

                        if (!_isForStudentVerification && !_isForNewUserVerification)
                            _empInfo = frmSearch.EmployeeInfo;

                        if (_isForNewUserVerification && !_isForStudentVerification)
                            _newUserInfo = frmSearch.NewUserInfo;

                        this.AssingControlsValue();
                        this.SetPersonInformationControls(true);

                        _hasSelectedForPersonUpdate = true;                        
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//--------------------------
        //####################################################END LINKLABEL lnkPersonArchive EVENTS###############################################

        //####################################################COMBOBOX cboMaritalStatus EVENTS###############################################
        //event is raised when the control is selected index changed
        private void cboMaritalStatusSelectedIndexChanged(object sender, EventArgs e)
        {
            _personInfo.MaritalStatusCode = _baseServiceManager.GetCodeReference(CommonExchange.CodeEntityId.MaritalStatus, this.cboMaritalStatus.SelectedIndex);

            if (String.Equals(_personInfo.MaritalStatusCode.CodeDescription, "Single"))
            {
                lnkMarriageDate.Enabled = false;
                this.txtMarriageDate.Clear();
            }
            else
            {
                this.lnkMarriageDate.Enabled = true;
            }
        }//-----------------------
        //####################################################END COMBOBOX cboMaritalStatus EVENTS###############################################

        //####################################################COMBOBOX cboLifeStatus EVENTS###############################################
        //event is raised when the control is selected index changed
        private void cboLifeStatusSelectedIndexChanged(object sender, EventArgs e)
        {
            _personInfo.LifeStatusCode = _baseServiceManager.GetCodeReference(CommonExchange.CodeEntityId.LifeStatus, this.cboLifeStatus.SelectedIndex);
        }//----------------------------
        //####################################################END COMBOBOX cboLifeStatus EVENTS###############################################

        //####################################################COMBOBOX cboGender EVENTS###############################################
        //event is raised when the control is selected index changed
        private void cboGenderSelectedIndexChanged(object sender, EventArgs e)
        {
            _personInfo.GenderCode = _baseServiceManager.GetCodeReference(CommonExchange.CodeEntityId.Gender, this.cboGender.SelectedIndex);
        }//-----------------------------
        //####################################################END COMBOBOX cboGender EVENTS###############################################

        //####################################################PICTUREBOX pbxPerson EVENTS###############################################
        //event is raised when the control is clicked
        protected void pbxPersonClick(object sender, EventArgs e)
        {
            using (OpenFileDialog imageChooser = new OpenFileDialog())
            {
                imageChooser.Title = "Select an image";
                imageChooser.Filter = "All image file (*.jpg, *.jpeg, *.bmp, *.gif) | *.jpg; *.jpeg; *.bmp; *.gif";
                imageChooser.Multiselect = false;
                imageChooser.CheckFileExists = true;
                imageChooser.CheckPathExists = true;

                //determines if an image has been Selected
                if (imageChooser.ShowDialog() == DialogResult.OK)
                {
                    this.Cursor = Cursors.WaitCursor;

                    this.pbxPerson.Image = Image.FromFile(imageChooser.FileName);

                    _personInfo.FilePath = imageChooser.FileName;

                    _personInfo.FileData = RemoteClient.ProcStatic.GetFileArrayBytes(_personInfo.FilePath);
                    _personInfo.FileName = Path.GetFileName(_personInfo.FilePath);
                    _personInfo.FileExtension = _baseServiceManager.GetImageExtensionName(_personInfo.FilePath);

                    this.Cursor = Cursors.Arrow;
                }
            }
        }//---------------------------------
        //####################################################END PICTUREBOX pbxPerson EVENTS###############################################       
        #endregion

        #region Programmer-Defined Void Procedures
        //this procedure will set person information controls enabled property
        public void SetPersonInformationControls(Boolean isEnabled)
        {
            this.txtECode.Enabled = this.cboGender.Enabled = this.cboLifeStatus.Enabled = this.cboMaritalStatus.Enabled = this.txtBirthDate.Enabled =
                this.lnkBirthDate.Enabled = this.lnkMarriageDate.Enabled = this.txtPlaceOfBirth.Enabled =
                this.gbxAddressContact.Enabled = this.tblPersonalDetails.Enabled = _isVerifiedUpdatedName = isEnabled;
        }//-------------------------

        //this procedure will assigne values to personal information controls
        public void AssingControlsValue()
        {
            this.txtLastName.Text = _personInfo.LastName;
            this.txtFirstName.Text = _personInfo.FirstName;
            this.txtMiddleName.Text = _personInfo.MiddleName;
            this.txtECode.Text = _personInfo.ECode;

            Boolean isEmployee = false;

            if (_baseServiceManager.IsExistsSysIDPersonStudentEmployeeInformation(_userInfo, _personInfo.PersonSysId, ref isEmployee) &&
                !(RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) ||
                RemoteServerLib.ProcStatic.IsSystemAccessVpOfFinance(_userInfo) ||
                RemoteServerLib.ProcStatic.IsSystemAccessPayrollMaster(_userInfo) ||
                RemoteServerLib.ProcStatic.IsSystemAccessCashier(_userInfo)))
            {
                this.txtLastName.Enabled = this.txtFirstName.Enabled = this.txtMiddleName.Enabled = false;
            }
            else
            {
                if (((RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) || RemoteServerLib.ProcStatic.IsSystemAccessVpOfFinance(_userInfo)) ||
                    (!isEmployee && RemoteServerLib.ProcStatic.IsSystemAccessCashier(_userInfo)) ||
                    (isEmployee && RemoteServerLib.ProcStatic.IsSystemAccessPayrollMaster(_userInfo))) ||
                    !(_baseServiceManager.IsExistsSysIDPersonStudentEmployeeInformation(_userInfo, _personInfo.PersonSysId, ref isEmployee)))
                {
                    this.txtLastName.Enabled = this.txtFirstName.Enabled = this.txtMiddleName.Enabled = true;
                }
                else
                {
                    this.txtLastName.Enabled = this.txtFirstName.Enabled = this.txtMiddleName.Enabled = false;
                }
            }

            DateTime dBirthDate = DateTime.MinValue;

            this.txtBirthDate.Clear();

            if (DateTime.TryParse(_personInfo.BirthDate, out dBirthDate))
            {
                this.txtBirthDate.Text = DateTime.Compare(dBirthDate, DateTime.MinValue) == 0 ? String.Empty : dBirthDate.ToLongDateString();
            }

            this.txtPlaceOfBirth.Text = _personInfo.PlaceOfBirth;
            this.txtPressentAddress.Text = _personInfo.PresentAddress;
            this.txtPressentPhone.Text = _personInfo.PresentPhoneNos;
            this.txtHomeAddress.Text = _personInfo.HomeAddress;
            this.txtHomePhone.Text = _personInfo.HomePhoneNos;
            this.txtEMail.Text = _personInfo.EMailAddress;
            this.txtCitizenship.Text = _personInfo.Citizenship;
            this.txtNationality.Text = _personInfo.Nationality;
            this.txtReligion.Text = _personInfo.Religion;

            _baseServiceManager.InitializeCodeReferenceCombo(this.cboGender, CommonExchange.CodeEntityId.Gender, _personInfo.GenderCode.CodeReferenceId);
            _baseServiceManager.InitializeCodeReferenceCombo(this.cboLifeStatus, CommonExchange.CodeEntityId.LifeStatus,
                _personInfo.LifeStatusCode.CodeReferenceId);
            _baseServiceManager.InitializeCodeReferenceCombo(this.cboMaritalStatus, CommonExchange.CodeEntityId.MaritalStatus,
                _personInfo.MaritalStatusCode.CodeReferenceId);

            DateTime dMarriageDate = DateTime.MinValue;

            this.txtMarriageDate.Clear();

            if (DateTime.TryParse(_personInfo.MarriageDate, out dMarriageDate))
            {
                this.txtMarriageDate.Text = DateTime.Compare(dMarriageDate, DateTime.MinValue) == 0 ? String.Empty : dMarriageDate.ToLongDateString();
            }

            this.txtOtherInformation.Text = _personInfo.OtherPersonInformation;

            if (!String.IsNullOrEmpty(_personInfo.FilePath) && File.Exists(_personInfo.FilePath))
            {
                this.pbxPerson.Image = Image.FromFile(_personInfo.FilePath);
            }
        }//---------------------------
        #endregion

        #region Programmer-Defined Functions
        //this fucntion will set firt letter to upper case
        private String SetFirstLetterToUpper(String strBase)
        {
            StringBuilder strBlock = new StringBuilder();
            Boolean forUpper = false;
            Boolean isWhiteSpace = false;
            Boolean isLastCharEqualI = false;

            for (Int32 i = 0; i <= strBase.Length - 1; i++)
            {
                if (i == 0 || (forUpper && strBase[i] != ' ') || (isLastCharEqualI && (strBase[i] == 'i' || strBase[i] == 'I')))
                {
                    strBlock.Append(strBase[i].ToString().ToUpper());
                    forUpper = false;
                    isWhiteSpace = false;

                    if (strBase[i] == 'i' || strBase[i] == 'I')
                    {
                        isLastCharEqualI = true;
                    }
                }
                else if (strBase[i] == ' ' && !isWhiteSpace)
                {
                    strBlock.Append(strBase[i]);
                    forUpper = true;
                    isWhiteSpace = true;
                    isLastCharEqualI = false;
                }
                else if (!isWhiteSpace)
                {
                    strBlock.Append(strBase[i].ToString().ToLower());
                    isWhiteSpace = false;
                    isLastCharEqualI = false;
                }
            }

            return strBlock.ToString();
        }//-----------------------

        //this procedure will validate controls
        public Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.txtLastName, "");
            _errProvider.SetError(this.txtFirstName, "");

            if (String.IsNullOrEmpty(_personInfo.LastName))
            {
                _errProvider.SetError(this.txtLastName, "Person's last name is required.");
                _errProvider.SetIconAlignment(this.txtLastName, ErrorIconAlignment.MiddleRight);

                this.TabCntPerson.SelectedIndex = 0;

                isValid = false;
            }

            if (String.IsNullOrEmpty(_personInfo.FirstName))
            {
                _errProvider.SetError(this.txtFirstName, "Person's first name is required.");
                _errProvider.SetIconAlignment(this.txtFirstName, ErrorIconAlignment.MiddleRight);

                this.TabCntPerson.SelectedIndex = 0;

                isValid = false;
            }

            return isValid;
        }//-------------------------
        #endregion
    }
}
