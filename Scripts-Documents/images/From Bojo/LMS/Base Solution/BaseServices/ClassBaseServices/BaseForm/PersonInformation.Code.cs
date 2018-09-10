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
        public CommonExchange.Person PersonInfo
        {
            get { return _personInfo; }
        }

        protected Boolean _isVerifiedUpdatedName = false;
        public Boolean IsVerifiedUpdatedName
        {
            get { return _isVerifiedUpdatedName; }
        }

        protected Boolean _isForUpdatePerson = false;
        public Boolean IsForUpdatePerson
        {
            get { return _isForUpdatePerson; }
        }

        public Boolean PersonArchiveVisible
        {
            set { this.lnkPersonArchive.Visible = value; }
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
            this.FormClosing += new FormClosingEventHandler(ClassClossing);
            this.txtLastName.Validating += new System.ComponentModel.CancelEventHandler(txtNameValidating);
            this.txtLastName.Validated += new EventHandler(txtLastNameValidated);
            this.txtLastName.KeyPress += new KeyPressEventHandler(TextBoxKeyPressLettersOnly);
            this.txtFirstName.Validated += new EventHandler(txtFirstNameValidated);
            this.txtFirstName.KeyPress += new KeyPressEventHandler(TextBoxKeyPressLettersOnly);
            this.txtFirstName.Validating += new System.ComponentModel.CancelEventHandler(txtNameValidating);
            this.txtMiddleName.Validated += new EventHandler(txtMiddleNameValidated);
            this.txtMiddleName.KeyPress += new KeyPressEventHandler(TextBoxKeyPressLettersOnly);
            this.txtMiddleName.Validating += new System.ComponentModel.CancelEventHandler(txtNameValidating);
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
            this.txtNoOfDependents.Validated += new EventHandler(txtNoOfDependentsValidated);
            this.txtNoOfDependents.KeyPress += new KeyPressEventHandler(txtIntegerKeyPress);
            this.txtNoOfDependents.Validating += new System.ComponentModel.CancelEventHandler(txtIntegerValidating);
            this.txtHouseOwnershipInformation.Validated += new EventHandler(txtHouseOwnershipInformationValidated);
            this.txtEducationalAttainment.Validated += new EventHandler(txtEducationalAttainmentValidated);
            this.txtSpecialSkills.Validated += new EventHandler(txtSpecialSkillsValidated);
            this.txtOccupation.Validated += new EventHandler(txtOccupationValidated);
            this.txtYearOfService.Validating +=new System.ComponentModel.CancelEventHandler(txtIntegerValidating);
            this.txtYearOfService.KeyPress += new KeyPressEventHandler(txtIntegerKeyPress);
            this.txtYearOfService.Validated += new EventHandler(txtYearOfServiceValidated);
            this.txtSalaryIncome.KeyPress += new KeyPressEventHandler(txtDecimalKeyPress);
            this.txtSalaryIncome.Validating += new System.ComponentModel.CancelEventHandler(txtDecimalValidating);
            this.txtSalaryIncome.Validated += new EventHandler(txtSalaryIncomeValidated);
            this.txtTotalMonthlyExpense.KeyPress += new KeyPressEventHandler(txtDecimalKeyPress);
            this.txtTotalMonthlyExpense.Validating += new System.ComponentModel.CancelEventHandler(txtDecimalValidating);
            this.txtTotalMonthlyExpense.Validated += new EventHandler(txtTotalMonthlyExpenseValidated);
            this.txtNetDisposableIncome.KeyPress += new KeyPressEventHandler(txtDecimalKeyPress);
            this.txtNetDisposableIncome.Validating += new System.ComponentModel.CancelEventHandler(txtDecimalValidating);
            this.txtNetDisposableIncome.Validated += new EventHandler(txtNetDisposableIncomeValidated);
            this.cboGender.SelectedIndexChanged += new EventHandler(cboGenderSelectedIndexChanged);
            this.cboLifeStatus.SelectedIndexChanged += new EventHandler(cboLifeStatusSelectedIndexChanged);
            this.cboMaritalStatus.SelectedIndexChanged += new EventHandler(cboMaritalStatusSelectedIndexChanged);
            this.cboAppointmentStatus.SelectedIndexChanged += new EventHandler(cboAppointmentStatusSelectedIndexChanged);
            this.lnkBirthDate.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkBirthDateLinkClicked);
            this.lnkMarriageDate.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkMarriageDateLinkClicked);
            this.lnkEmploymentDate.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkEmploymentDateLinkClicked);
            this.lnkVerify.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkVerifyLinkClicked);
            this.lnkPersonArchive.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkPersonArchiveLinkClicked);
            this.btnSearchOfficeInformation.Click += new EventHandler(btnSearchOfficeInformationClick);
            this.pbxGeneralInformation.Click += new EventHandler(pbxGeneralInformationClick);
            this.pbxPersonImage.Click += new EventHandler(pbxPersonImageClick);
        }
        #endregion

        #region IDisposable Members
        void IDisposable.Dispose()
        {
            if (this.pbxPersonImage.Image != null)
            {
                this.pbxPersonImage.Image.Dispose();
                this.pbxPersonImage.Image = null;

                this.pbxPersonImage.Dispose();
                this.pbxPersonImage = null;
            }

            GC.SuppressFinalize(this);
            GC.Collect();
        }
        #endregion

        #region Class Event Void Procedures
        //####################################################CLASS PersonalInformation EVENTS###############################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            _baseServiceManager = new BaseServicesLogic(_userInfo);

            _personInfo = new CommonExchange.Person();

            _baseServiceManager.InitializeCodeReferenceCombo(this.cboGender, CommonExchange.CodeEntityId.Gender);
            _baseServiceManager.InitializeCodeReferenceCombo(this.cboLifeStatus, CommonExchange.CodeEntityId.LifeStatus);
            _baseServiceManager.InitializeCodeReferenceCombo(this.cboMaritalStatus, CommonExchange.CodeEntityId.MaritalStatus);
            _baseServiceManager.InitializeCodeReferenceCombo(this.cboAppointmentStatus, CommonExchange.CodeEntityId.AppointmentStatus);
           
        }//----------------------

        //event is raised when the class is clossing
        protected virtual void ClassClossing(object sender, FormClosingEventArgs e)
        {
            //_baseServiceManager.DeletePersonDocumentDirecotry(_personInfo);
            _baseServiceManager.ClearPersonDocumentTable();
        }
        //####################################################END CLASS PersonalInformation EVENTS###############################################

        //##############################################TEXTBOXES EVENTS####################################################################
        //event is raised when the key is pressed
        protected virtual void TextBoxKeyPressLettersOnly(object sender, KeyPressEventArgs e)
        {
            ProcStatic.TextBoxLettersOnly(e);
            
            this.lnkVerify.Enabled = true;

            this.SetPersonInformationControls(false);
        }//------------------------------------
        //#############################################END TEXTBOXES EVENTS##################################################################

        //####################################################TEXTBOX VALIDATION EVENTS###############################################
        //event is raised when the control is validated
        protected virtual void txtLastNameValidated(object sender, EventArgs e)
        {
            _personInfo.LastName = ProcStatic.TrimStartEndString(this.txtLastName.Text);

            if (!String.IsNullOrEmpty(_personInfo.FirstName) && !String.IsNullOrEmpty(_personInfo.LastName))
            {
                this.lnkVerify.Enabled = true;
            }
            else
            {
                this.SetPersonInformationControls(false);
                this.lnkVerify.Enabled = false;
            }

            this.SetPersonNameInformation();
        }//--------------------------

        //event is raised when the control is validated
        protected virtual void txtFirstNameValidated(object sender, EventArgs e)
        {
            _personInfo.FirstName = ProcStatic.TrimStartEndString(this.txtFirstName.Text);

            if (!String.IsNullOrEmpty(_personInfo.FirstName) && !String.IsNullOrEmpty(_personInfo.LastName))
            {
                this.lnkVerify.Enabled = true;
            }
            else
            {
                this.SetPersonInformationControls(false);
                this.lnkVerify.Enabled = false;
            }

            this.SetPersonNameInformation();
        }//-----------------------------

        //event is raised when the control is validated
        private void txtMiddleNameValidated(object sender, EventArgs e)
        {
            _personInfo.MiddleName = ProcStatic.TrimStartEndString(this.txtMiddleName.Text);

            this.SetPersonNameInformation();
        }//----------------------

        //event is raised when the control is validated
        private void txtPlaceOfBirthValidated(object sender, EventArgs e)
        {
            _personInfo.PlaceOfBirth = ProcStatic.TrimStartEndString(this.txtPlaceOfBirth.Text);
        }//------------------------

        //event is raised when the control is validated
        private void txtPressentAddressValidated(object sender, EventArgs e)
        {
            _personInfo.PresentAddress = ProcStatic.TrimStartEndString(this.txtPressentAddress.Text);
        }//------------------------

        //event is raised when the control is validated
        private void txtPressentPhoneValidated(object sender, EventArgs e)
        {
            _personInfo.PresentPhoneNos = ProcStatic.TrimStartEndString(this.txtPressentPhone.Text);
        }//-------------------------

        //event is raised when the control is validated
        private void txtHomeAddressValidated(object sender, EventArgs e)
        {
            _personInfo.HomeAddress = ProcStatic.TrimStartEndString(this.txtHomeAddress.Text);
        }//-----------------------

        //event is raised when the control is validated
        private void txtHomePhoneValidated(object sender, EventArgs e)
        {
            _personInfo.HomePhoneNos = ProcStatic.TrimStartEndString(this.txtHomePhone.Text);
        }//---------------------------

        //event is raised when the control is validated
        private void txtEMailValidated(object sender, EventArgs e)
        {
            _personInfo.EMailAddress = ProcStatic.TrimStartEndString(this.txtEMail.Text);
        }//--------------------------

        //event is raised when the control is validated
        private void txtCitizenshipValidated(object sender, EventArgs e)
        {
            _personInfo.Citizenship = ProcStatic.TrimStartEndString(this.txtCitizenship.Text);
        }//---------------------------

        //event is raised when the control is validated
        private void txtNationalityValidated(object sender, EventArgs e)
        {
            _personInfo.Nationality = ProcStatic.TrimStartEndString(this.txtNationality.Text);
        }//-------------------------

        //event is raised when the control is validated
        private void txtReligionValidated(object sender, EventArgs e)
        {
            _personInfo.Religion = ProcStatic.TrimStartEndString(this.txtReligion.Text);
        }//--------------------------

        //event is raised when the control is validated
        private void txtOtherInformationValidated(object sender, EventArgs e)
        {
            _personInfo.OtherPersonInformation = ProcStatic.TrimStartEndString(this.txtOtherInformation.Text);
        }//---------------------------

        //event is raised when the control is validated
        private void txtOccupationValidated(object sender, EventArgs e)
        {
            _personInfo.Occupation = ProcStatic.TrimStartEndString(this.txtOccupation.Text);
        }//-----------------------

        //event is raised when the control is validated
        private void txtSpecialSkillsValidated(object sender, EventArgs e)
        {
            _personInfo.SpecialSkills = ProcStatic.TrimStartEndString(this.txtSpecialSkills.Text);
        }//--------------------------

        //event is raised when the control is validated
        private void txtEducationalAttainmentValidated(object sender, EventArgs e)
        {
            _personInfo.EducationalAttainment = ProcStatic.TrimStartEndString(this.txtEducationalAttainment.Text);
        }//------------------------

        //--------------------------
        private void txtHouseOwnershipInformationValidated(object sender, EventArgs e)
        {
            _personInfo.HouseOwnershipInformation = ProcStatic.TrimStartEndString(this.txtHouseOwnershipInformation.Text);
        }//--------------------------

        //event is raised when the control is validated
        private void txtNoOfDependentsValidated(object sender, EventArgs e)
        {
            Byte d = 0;

            if (Byte.TryParse(this.txtNoOfDependents.Text, out d))
            {
                _personInfo.NoOfDependents = d;
            }
        }//-----------------------------

        //event is raised when the control is validated
        private void txtYearOfServiceValidated(object sender, EventArgs e)
        {
            Byte b = 0;

            if (Byte.TryParse(this.txtYearOfService.Text, out b))
            {
                _personInfo.YearsOfService = b;
            }
        }//-------------------------

        //event is raised when the control is validated
        private void txtNetDisposableIncomeValidated(object sender, EventArgs e)
        {
            Decimal income = 0;

            if (Decimal.TryParse(this.txtNetDisposableIncome.Text, out income))
            {
                _personInfo.NetDisposableIncome = income;
            }
        }//-------------------------

        //event is raised when the control is validated
        private void txtTotalMonthlyExpenseValidated(object sender, EventArgs e)
        {
            Decimal expense = 0;

            if (Decimal.TryParse(this.txtTotalMonthlyExpense.Text, out expense))
            {
                _personInfo.TotalMonthlyExpenses = expense;
            }
        }//-------------------------

        //event is raised when the control is validated
        private void txtSalaryIncomeValidated(object sender, EventArgs e)
        {
            Decimal salary = 0;

            if (Decimal.TryParse(this.txtSalaryIncome.Text, out salary))
            {
                _personInfo.SalaryIncome = salary;
            }
        }//-------------------------
        //####################################################END TEXTBOX VALIDATION EVENTS###############################################

        //####################################################TEXTBOX textBoxDecimal EVENTS###############################################
        //event is raised when the control is validating
        private void txtDecimalValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ProcStatic.TextBoxValidateAmount((TextBox)sender);
        }//--------------------------

        //event is raised when the key is pressed
        private void txtDecimalKeyPress(object sender, KeyPressEventArgs e)
        {
            ProcStatic.TextBoxAmountOnly(e);
        }//-------------------------
        //####################################################END TEXTBOX textBoxDecimal EVENTS###############################################       

        //####################################################TEXTBOX textBoxInteger EVENTS###############################################
        //event is raised when the control is validating
        private void txtIntegerValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ProcStatic.TextBoxValidateInteger((TextBox)sender);
        }//-----------------------

        //event is raised when the control key is pressed
        private void txtIntegerKeyPress(object sender, KeyPressEventArgs e)
        {
            ProcStatic.TextBoxIntegersOnly(e);
        }//--------------------
        //####################################################END TEXTBOX txtNoOfDependencies EVENTS###############################################

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

            using (BaseServices.Control.DatePicker frmPicker = new BaseServices.Control.DatePicker(bDate))
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

            using (BaseServices.Control.DatePicker frmPicker = new BaseServices.Control.DatePicker(mDate))
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

        //####################################################LINKLABEL lnkEmployeeDate EVENTS###############################################
        //event is raised when the control is clicked
        private void lnkEmploymentDateLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            DateTime eDate = DateTime.MinValue;

            if (String.IsNullOrEmpty(_personInfo.EmploymentDate))
            {
                eDate = DateTime.Parse(_baseServiceManager.ServerDateTime);
            }
            else
            {
                eDate = DateTime.Parse(_personInfo.EmploymentDate);
            }

            using (BaseServices.Control.DatePicker frmPicker = new BaseServices.Control.DatePicker(eDate))
            {
                frmPicker.ShowDialog(this);

                if (frmPicker.HasSelectedDate)
                {
                    if (DateTime.TryParse(frmPicker.GetSelectedDate.ToLongDateString() + " " +
                            DateTime.Parse(_baseServiceManager.ServerDateTime).ToLongTimeString(), out eDate))
                    {
                        _personInfo.EmploymentDate = eDate.ToString();
                    }

                    this.txtEmploymentDate.Text = eDate.ToLongDateString();
                }
            }

            this.Cursor = Cursors.Arrow;
        }//--------------------
        //####################################################END LINKLABEL lnkEmployeeDate EVENTS###############################################

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
                    //Boolean openUpdateForm = false;

                    using (VerifyPersonExistenceList frmVerify = new VerifyPersonExistenceList(_userInfo, _baseServiceManager,
                        ProcStatic.GetCompleteNameMiddleInitial(_personInfo.LastName, _personInfo.FirstName, _personInfo.MiddleName), resultTable))
                    {
                        frmVerify.ShowDialog(this);

                        if (frmVerify.HasSelected)
                        {
                            _personInfo = _baseServiceManager.GetPersonDetails(_userInfo, frmVerify.PrimaryId);

                            _isForUpdatePerson = true;

                            this.Close();
                        }
                        else if (frmVerify.IsVerified)
                        {
                            //_personInfo = _baseServiceManager.GetPersonDetails(_userInfo, frmVerify.PrimaryId);

                            //this.AssingControlsValue();
                            this.SetPersonInformationControls(true);
                        }
                    }

                    if (_isForUpdatePerson)
                    {
                        if (!String.IsNullOrEmpty(_personInfo.PersonSysId))
                        {
                            using (PersonInformationUpdate frmUpdate = new PersonInformationUpdate(_userInfo,
                                _baseServiceManager.GetPersonDetails(_userInfo, _personInfo.PersonSysId), _baseServiceManager))
                            {
                                frmUpdate.PersonArchiveVisible = false;
                                frmUpdate.ShowDialog(this);

                                if (frmUpdate.HasUpdated)
                                {
                                    _personInfo = frmUpdate.PersonInfo;
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("The system has successfully verified that " + ProcStatic.GetCompleteNameMiddleInitial(
                              _personInfo.LastName, _personInfo.FirstName, _personInfo.MiddleName) + " does NOT currently exist on the database." +
                              "\n\nClick OK to proceed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   this.SetPersonInformationControls(true);
                }
            }
            catch (Exception ex)
            {
                ProcStatic.ShowErrorDialog(ex.Message + "\n Error loading person verify module.", "Error Loading");
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

                using (PersonSearchOnTextBoxList frmSearch = new PersonSearchOnTextBoxList(_userInfo, _baseServiceManager, _personInfo.PersonSysId))
                {
                    frmSearch.ShowDialog(this);

                    if (frmSearch.HasSelected && !frmSearch.UsePersonInfo)
                    {
                        _personInfo = _baseServiceManager.GetPersonDetails(_userInfo, frmSearch.PrimaryId);

                        _isForUpdatePerson = true;

                        this.Close();
                    }
                    else if (frmSearch.UsePersonInfo)
                    {
                        _personInfo = _baseServiceManager.GetPersonDetails(_userInfo, frmSearch.PrimaryId);

                        this.AssingControlsValue();
                        this.SetPersonInformationControls(true);
                    }
                }

                if (_isForUpdatePerson)
                {
                    if (!String.IsNullOrEmpty(_personInfo.PersonSysId))
                    {
                        using (PersonInformationUpdate frmUpdate = new PersonInformationUpdate(_userInfo,
                            _baseServiceManager.GetPersonDetails(_userInfo, _personInfo.PersonSysId), _baseServiceManager))
                        {
                            frmUpdate.PersonArchiveVisible = false;
                            frmUpdate.ShowDialog(this);

                            if (frmUpdate.HasUpdated)
                            {
                                _personInfo = frmUpdate.PersonInfo;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
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

        //####################################################COMBOBOX cboAppointment EVENTS###############################################
        //event is raised when the control is selected index changed
        private void cboAppointmentStatusSelectedIndexChanged(object sender, EventArgs e)
        {
            _personInfo.AppointmentStatusCode = _baseServiceManager.GetCodeReference(CommonExchange.CodeEntityId.AppointmentStatus, 
                this.cboAppointmentStatus.SelectedIndex);
        }//------------------------
        //####################################################END COMBOBOX cboAppointment EVENTS###############################################

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

        //####################################################BUTTON btnSearchOfficeInformation EVENTS###############################################
        //event is raised when the control the control is clicked
        private void btnSearchOfficeInformationClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            using (OfficeEmployerSearchOnTextBoxList frmSearch = new OfficeEmployerSearchOnTextBoxList(_userInfo, _baseServiceManager))
            {
                frmSearch.AdoptGridSize = true;
                frmSearch.ShowDialog(this);

                if (frmSearch.HasSelected)
                {
                    _personInfo.OfficeEmployerInfo = _baseServiceManager.GetOfficeEmployerInformationDetails(frmSearch.PrimaryId);

                    this.txtOfficeInformation.Text = _personInfo.OfficeEmployerInfo.OfficeEmployerName + " [" +
                        _personInfo.OfficeEmployerInfo.OfficeEmployerAcronym + "]";
                }
            }

            this.Cursor = Cursors.Arrow;
        }//------------------------------
        //####################################################END BUTTON btnSearchOfficeInformation EVENTS###############################################

        //####################################################PICTUREBOX pbxGeneralInformation EVENTS###############################################
        //event is raised when the control is clicked
        private void pbxGeneralInformationClick(object sender, EventArgs e)
        {
            this.tabCntPerson.SelectedIndex = 0; //select general information tab
        }//-----------------------------
        //####################################################END PICTUREBOX pbxGeneralInformation EVENTS###############################################

        //####################################################PICTUREBOX pbxPersonImage EVENTS###############################################
        //event is raised when the control is clicked
        private void pbxPersonImageClick(object sender, EventArgs e)
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

                    if (!_baseServiceManager.IsExistsSysIDPersonOriginalNamePersonDocument(_userInfo, _personInfo.PersonSysId, 
                        Path.GetFileName(imageChooser.FileName), _baseServiceManager.GetDocumentIdByPersonSysId(_personInfo.PersonSysId)) &&
                    !File.Exists(_personInfo.PersonDocumentsFolder(Application.StartupPath) + Path.GetFileName(imageChooser.FileName)))
                    {
                        _baseServiceManager.InsertPersonDocument(_personInfo, Path.GetFileName(imageChooser.FileName),
                            ProcStatic.GetFileArrayBytes(imageChooser.FileName), true);

                        File.Copy(imageChooser.FileName, _personInfo.PersonDocumentsFolder(Application.StartupPath) + @"\" +
                            Path.GetFileName(imageChooser.FileName));

                        this.pbxPersonImage.Image = Image.FromFile(imageChooser.FileName);

                        imageChooser.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("The document file name already exist.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    this.Cursor = Cursors.Arrow;
                }
            }
        }//------------------------------
        //####################################################END PICTUREBOX pbxPersonImage EVENTS###############################################
        #endregion

        #region Programmer-Defined Void Procedures
        //this procedure will set person name and other information
        public void SetPersonNameInformation()
        {
            this.lblPersonName.Text = ProcStatic.GetCompleteNameMiddleInitial(_personInfo.LastName, _personInfo.FirstName, _personInfo.MiddleName);
        }//------------------------

        //this procedure will set person information controls enabled property
        public void SetPersonInformationControls(Boolean isEnabled)
        {
            this.cboGender.Enabled = this.cboLifeStatus.Enabled = this.cboMaritalStatus.Enabled = this.txtBirthDate.Enabled =
                this.lnkBirthDate.Enabled = this.lnkMarriageDate.Enabled = this.txtPlaceOfBirth.Enabled =
                this.txtPressentAddress.Enabled = this.txtPressentPhone.Enabled = this.txtHomeAddress.Enabled =
                this.txtHomePhone.Enabled = this.txtNoOfDependents.Enabled =
                this.txtHouseOwnershipInformation.Enabled = this.txtSpecialSkills.Enabled = this.txtNationality.Enabled =
                this.txtEducationalAttainment.Enabled = this.txtEMail.Enabled = this.txtReligion.Enabled = this.txtCitizenship.Enabled =
                this.txtOtherInformation.Enabled = this.txtMarriageDate.Enabled = _isVerifiedUpdatedName = isEnabled;
        }//-------------------------

        //this procedure will assigne values to personal information controls
        public void AssingControlsValue()
        {
            this.txtLastName.Text = _personInfo.LastName;
            this.txtFirstName.Text = _personInfo.FirstName;
            this.txtMiddleName.Text = _personInfo.MiddleName;

            this.lblPersonName.Text = ProcStatic.GetCompleteNameMiddleInitial(_personInfo.LastName, _personInfo.FirstName, _personInfo.MiddleName);
            
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
            _baseServiceManager.InitializeCodeReferenceCombo(this.cboAppointmentStatus, CommonExchange.CodeEntityId.AppointmentStatus,
                _personInfo.AppointmentStatusCode.CodeReferenceId);

            DateTime dMarriageDate = DateTime.MinValue;

            this.txtMarriageDate.Clear();

            if (DateTime.TryParse(_personInfo.MarriageDate, out dMarriageDate))
            {
                this.txtMarriageDate.Text = DateTime.Compare(dMarriageDate, DateTime.MinValue) == 0 ? String.Empty : dMarriageDate.ToLongDateString();
            }

            this.txtOtherInformation.Text = _personInfo.OtherPersonInformation;
            this.txtNoOfDependents.Text = _personInfo.NoOfDependents.ToString();
            this.txtHouseOwnershipInformation.Text = _personInfo.HouseOwnershipInformation;
            this.txtEducationalAttainment.Text = _personInfo.EducationalAttainment;
            this.txtSpecialSkills.Text = _personInfo.SpecialSkills;

            this.txtOccupation.Text = _personInfo.Occupation;
            this.txtOfficeInformation.Text = !String.IsNullOrEmpty(_personInfo.OfficeEmployerInfo.OfficeEmployerName) ?
                _personInfo.OfficeEmployerInfo.OfficeEmployerName + " [" +  _personInfo.OfficeEmployerInfo.OfficeEmployerAcronym + "]" : String.Empty;

            DateTime dEmpDate = DateTime.MinValue;

            this.txtEmploymentDate.Clear();

            if (DateTime.TryParse(_personInfo.EmploymentDate, out dEmpDate))
            {
                this.txtEmploymentDate.Text = DateTime.Compare(dEmpDate, DateTime.MinValue) == 0 ? String.Empty : dEmpDate.ToLongDateString();
            }

            this.txtYearOfService.Text = _personInfo.YearsOfService.ToString();
            this.txtSalaryIncome.Text = _personInfo.SalaryIncome.ToString("N");
            this.txtTotalMonthlyExpense.Text = _personInfo.TotalMonthlyExpenses.ToString("N");
            this.txtNetDisposableIncome.Text = _personInfo.NetDisposableIncome.ToString("N");

            String personImagePath = _baseServiceManager.GetPersonPrimaryImagePath(_userInfo, _personInfo, true);

            if (!String.IsNullOrEmpty(personImagePath) && File.Exists(personImagePath))
            {
                this.pbxPersonImage.Image = Image.FromFile(personImagePath);
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
        public Boolean BaseValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.txtLastName, "");
            _errProvider.SetError(this.txtFirstName, "");

            if (String.IsNullOrEmpty(_personInfo.LastName))
            {
                _errProvider.SetError(this.txtLastName, "Person's last name is required.");
                _errProvider.SetIconAlignment(this.txtLastName, ErrorIconAlignment.MiddleRight);

                this.tblPersonalDetails.SelectedIndex = 0;

                isValid = false;
            }

            if (String.IsNullOrEmpty(_personInfo.FirstName))
            {
                _errProvider.SetError(this.txtFirstName, "Person's first name is required.");
                _errProvider.SetIconAlignment(this.txtFirstName, ErrorIconAlignment.MiddleRight);

                this.tblPersonalDetails.SelectedIndex = 0;

                isValid = false;
            }

            return isValid;
        }//-------------------------
        #endregion
    }
}
