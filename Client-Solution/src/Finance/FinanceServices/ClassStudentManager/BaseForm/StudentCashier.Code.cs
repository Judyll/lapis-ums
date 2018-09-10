using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace FinanceServices
{
    partial class StudentCashier : IDisposable
    {
        #region Class Member Variable Declaration
        protected CommonExchange.SysAccess _userInfo;

        protected StudentLogic _studentManager;
        
        protected String _studentSysId = "";
        protected String _yearLevelId = String.Empty;
        protected String _courseGroupId = String.Empty;
        protected Boolean _hasGenerateStudentId = false;

        private ErrorProvider _errProvider;

        protected Boolean _isForRegistrar;
        protected Boolean _hasUpdatedCourseLevel = false;
        protected Boolean _isVerified = false;
        protected Boolean _hasDeletedEntryLevel = false;
        protected Boolean _hasAddEntryLevel = false;

        #endregion

        #region Class Properties Declaration
        protected Boolean _isForUpdateStudent = false;
        public Boolean IsForStudentUpdate
        {
            get { return _isForUpdateStudent; }
        }      

        protected CommonExchange.Student _studentInfo;
        public CommonExchange.Student StudentInfo
        {
            get { return _studentInfo; }
        }
        #endregion

        #region Class Constructors and Destructors

        public StudentCashier()
        {
            this.InitializeComponent();
        }

        public StudentCashier(CommonExchange.SysAccess userInfo, StudentLogic studentManager, Boolean isForRegistrar)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _studentManager = studentManager;
            _isForRegistrar = isForRegistrar;

            _errProvider = new ErrorProvider();

            this.Load += new EventHandler(ClassLoad);
            this.txtStudentId.Validated += new EventHandler(txtStudentIdValidated);        
            this.txtStudentLastName.KeyPress += new KeyPressEventHandler(textBoxKeyPress);
            this.txtStudentFirstName.KeyPress += new KeyPressEventHandler(textBoxKeyPress);
            this.txtScholarship.Validated += new EventHandler(txtScholarshipValidated);
            this.chkIsInternational.CheckedChanged += new EventHandler(chkIsInternationalCheckedChanged);
            this.chkRequiredDownPayment.CheckedChanged += new EventHandler(chkRequiredDownPaymentCheckedChanged);
            this.lnkCreateStudentEntryLevel.Click += new EventHandler(lnkCreateStudentEntryLevelClick);
            this.lnkUpdateStudentEntryLevel.Click += new EventHandler(lnkUpdateStudentEntryLevelClick);
            this.lnkGenerateStudentId.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkGenerateStudentIdLinkClicked);
            this.trvStudentEnrolment.NodeMouseClick += new TreeNodeMouseClickEventHandler(trvStudentEnrolmentNodeMouseClick);
            this.lnkVerify.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkVerifyLinkClicked);
            this.lnkPersonArchive.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkPersonArchiveLinkClicked);

            if (!_isForRegistrar)
            {
                this.txtStudentLastName.Validated += new EventHandler(txtStudentLastNameValidated);
                this.txtStudentFirstName.Validated += new EventHandler(txtStudentFirstNameValidated);
                this.txtMiddleName.Validated += new EventHandler(txtMiddleNameValidated);
                this.txtStudentLastName.Validating += new System.ComponentModel.CancelEventHandler(txtNameValidating);
                this.txtStudentFirstName.Validating += new System.ComponentModel.CancelEventHandler(txtNameValidating);
                this.txtMiddleName.Validating += new System.ComponentModel.CancelEventHandler(txtNameValidating);
                this.lnkCreateCourse.Click += new EventHandler(lnkCreateCourseClick);
                this.lnkUpdateCourse.Click += new EventHandler(lnkUpdateCourseClick);
            }
            else
            {
                this.lnkGenerateStudentId.Enabled = this.lnkVerify.Enabled = this.lnkPersonArchive.Enabled = this.chkIsInternational.Enabled = false;
            }

        }  
      
        void IDisposable.Dispose()
        {
            if (pbxStudent.Image != null)
            {
                pbxStudent.Image.Dispose();
                pbxStudent.Image = null;

                pbxStudent.Dispose();
                pbxStudent = null;
            }

            GC.SuppressFinalize(this);
            GC.Collect();
        }
        #endregion

        #region Class Event Void Procedures

        //#########################################CLASS Course EVENTS###########################################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            _studentInfo = new CommonExchange.Student();

            if (!_isForRegistrar)
            {
                _studentManager.InitializeStudentEnrolmentCourseLevelTable(_userInfo, _studentInfo.StudentSysId);

                _studentManager.InitializeTreeViewControl(this.trvStudentEnrolment, this.mnuCreateCourse,
                     this.mnuUpdateCourse, this.mnuDelete, this.mnuCreateEntryLevel, _hasGenerateStudentId, _courseGroupId);
            }
            else
            {
                _studentManager.SelectBySysIDStudentForEnrolmentHistoryEnrolmentCourseLevel(_userInfo, _studentInfo.StudentSysId);

                _studentManager.InitializeTreeViewControl(_userInfo, this.trvStudentEnrolment);
            }

            _studentInfo.PersonInfo.BirthDate = _studentManager.ServerDateTime;          
        }//-------------------------
        //#########################################END CLASS Course EVENTS###########################################################

        //########################################TEXTBOX txtScholarship EVENTS#####################################################
        //event is raised when the control is validated
        private void txtScholarshipValidated(object sender, EventArgs e)
        {
            _studentInfo.Scholarship = RemoteClient.ProcStatic.TrimStartEndString(txtScholarship.Text);
        }//----------------------------
        //########################################END TEXTBOX txtScholarship EVENTS#####################################################

        //########################################TEXTBOX txtStudentMiddleName EVENTS#####################################################
        //event is raised when the control is validated
        private void txtMiddleNameValidated(object sender, EventArgs e)
        {
           _studentInfo.PersonInfo.MiddleName = RemoteClient.ProcStatic.TrimStartEndString(txtMiddleName.Text);
        }//------------------------
        //########################################END TEXTBOX txtStudentMiddleName EVENTS#####################################################

        //########################################TEXTBOX txtNameValidating EVENTS#####################################################
        //event is raised when the control is validating
        private void txtNameValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox txtBase = (TextBox)sender;

            txtBase.Text = this.SetFirstLetterToUpper(txtBase.Text);
        }//-------------------------
        //########################################END TEXTBOX txtNameValidating EVENTS#####################################################

        //########################################TEXTBOX TextBoxName EVENTS#####################################################
        //event is raised when the key is pressed
        protected virtual void textBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            _isVerified = false;
        }//-------------------
        //########################################END TEXTBOX TextBoxName EVENTS#####################################################

        //########################################TEXTBOX txtStudentFirstName EVENTS#####################################################
        //event is raised when the control is validated
        private void txtStudentFirstNameValidated(object sender, EventArgs e)
        {
            _studentInfo.PersonInfo.FirstName = RemoteClient.ProcStatic.TrimStartEndString(txtStudentFirstName.Text);

            if (String.IsNullOrEmpty(_studentInfo.PersonInfo.PersonSysId))
            {
                if (!String.IsNullOrEmpty(_studentInfo.PersonInfo.FirstName) && !String.IsNullOrEmpty(_studentInfo.PersonInfo.LastName))
                {
                    this.lnkVerify.Enabled = true;
                }
                else
                {
                    this.lnkVerify.Enabled = false;
                }
            }
        }//-------------------------
        //########################################END TEXTBOX txtStudentFirstName EVENTS####################################################

        //########################################TEXTBOX txtStudentLastName EVENTS#####################################################
        //event is raised when the control is validated
        private void txtStudentLastNameValidated(object sender, EventArgs e)
        {
            _studentInfo.PersonInfo.LastName = RemoteClient.ProcStatic.TrimStartEndString(txtStudentLastName.Text);

            if (String.IsNullOrEmpty(_studentInfo.PersonInfo.PersonSysId))
            {
                if (!String.IsNullOrEmpty(_studentInfo.PersonInfo.FirstName) && !String.IsNullOrEmpty(_studentInfo.PersonInfo.LastName))
                {
                    this.lnkVerify.Enabled = true;
                }
                else
                {
                    this.lnkVerify.Enabled = false;
                }
            }
        }//-------------------------
        //########################################END TEXTBOX txtStudentLastName EVENTS#####################################################

        //########################################TEXTBOX txtStudentId EVENTS#####################################################
        //event is raised when the control is validated
        private void txtStudentIdValidated(object sender, EventArgs e)
        {
            _studentInfo.StudentId = RemoteClient.ProcStatic.TrimStartEndString(txtStudentId.Text);

            _hasGenerateStudentId = false;

            _studentManager.InitializeTreeViewControl(this.trvStudentEnrolment, this.mnuCreateCourse, this.mnuUpdateCourse, this.mnuDelete,
               this.mnuCreateEntryLevel, _hasGenerateStudentId, _courseGroupId);
        }//---------------------------
        //########################################END TEXTBOX txtStudentId EVENTS#####################################################       

        //########################################CHECKBOX chkIsInternational EVENTS#####################################################
        //event is raised when the control checked changed
        private void chkIsInternationalCheckedChanged(object sender, EventArgs e)
        {
            _studentInfo.IsInternational = this.chkIsInternational.Checked;
        }//--------------------------
        //########################################END CHECKBOX chkIsInternational EVENTS#####################################################

        //########################################CHECKBOX chkRequiredDownpayment EVENTS#####################################################
        //event is raised when the control checked changed
        private void chkRequiredDownPaymentCheckedChanged(object sender, EventArgs e)
        {
            _studentInfo.IsNoDownpaymentRequired = this.chkRequiredDownPayment.Checked;
        }//----------------------------
        //########################################END CHECKBOX chkRequiredDownpayment EVENTS#####################################################

        //########################################LINKLABEL lnkCreateCourse EVENTS#####################################################
        //event is raised when the control is clicked
        protected virtual void lnkCreateCourseClick(object sender, EventArgs e)
        {
            try
            {
                using (StudentCourseCreate frmCreate = new StudentCourseCreate(_userInfo, _studentInfo, 
                    _studentManager, _studentManager.GetSystemId(this.trvStudentEnrolment.SelectedNode.Text)))
                {
                    frmCreate.ShowDialog(this);

                    if (frmCreate.HasCreatedCourse)
                    {
                        _studentManager.InitializeTreeViewControl(this.trvStudentEnrolment, this.mnuCreateCourse,
                            this.mnuUpdateCourse, this.mnuDelete, this.mnuCreateEntryLevel, _hasGenerateStudentId, _courseGroupId);

                        _studentSysId = frmCreate.StudentSysId;

                        _hasUpdatedCourseLevel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading create course module.\n\n" + ex.Message, "Error Loading", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//----------------------------                   
        //########################################END LINKLABEL lnkCreateCourse EVENTS#####################################################

        //########################################LINKLABEL lnkUpdateCourse EVENTS#####################################################
        //event is raised when the control is clicked
        protected virtual void lnkUpdateCourseClick(object sender, EventArgs e)
        {
            try
            {
                if (this.trvStudentEnrolment.SelectedNode.Text != null)
                {
                    using (StudentCourseUpdate frmUpdate = new StudentCourseUpdate(_userInfo, _studentInfo,
                        _studentManager.GetDetailsStudentCourseInfoByCourseId(_studentManager.GetSystemId(this.trvStudentEnrolment.SelectedNode.Text)),
                        _studentManager, _studentManager.GetSystemId(this.trvStudentEnrolment.SelectedNode.Text)))
                    {
                        frmUpdate.ShowDialog(this);

                        if (frmUpdate.HasUpDated)
                        {
                            _studentManager.InitializeTreeViewControl(this.trvStudentEnrolment, this.mnuCreateCourse,
                                this.mnuUpdateCourse, this.mnuDelete, this.mnuCreateEntryLevel, _hasGenerateStudentId, _courseGroupId);

                            _studentSysId = frmUpdate.StudentSysId;

                            _hasUpdatedCourseLevel = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading update course module.\n\n" + ex.Message, "Error Loading", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//--------------------------
        //########################################LINKLABEL lnkUpdateCourse EVENTS#####################################################

        //########################################LINKLABEL lnkStudentEntryLevel EVENTS#####################################################
        //event is raised when the control is clicked
        protected virtual void lnkCreateStudentEntryLevelClick(object sender, EventArgs e)
        {
            try
            {
                using (StudentEntryLevelCreate frmCreate = new StudentEntryLevelCreate(_userInfo,
                    _studentManager.GetDetailsStudentCourseInfo(_studentManager.GetSystemId(this.trvStudentEnrolment.SelectedNode.Text)), 
                    _studentManager, _yearLevelId))
                {
                    frmCreate.ShowDialog(this);

                    if (frmCreate.HasCreated)
                    {
                        _studentManager.InitializeTreeViewControl(this.trvStudentEnrolment,
                            this.mnuCreateCourse, this.mnuUpdateCourse, this.mnuDelete, this.mnuCreateEntryLevel, _hasGenerateStudentId, _courseGroupId);

                        _hasUpdatedCourseLevel = _hasAddEntryLevel = true;
                    }
                    else
                    {
                        _hasAddEntryLevel = _hasUpdatedCourseLevel = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading create entry level module.\n\n" + ex.Message, "Error Loading", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//--------------------------
        //########################################END LINKLABEL lnkStudentEntryLevel EVENTS#####################################################
        
        //########################################LINKLABEl lnkUpdateStudentEntryLevel EVENTS#####################################################       
        //event is raised when the control is double clicked
        protected virtual void lnkUpdateStudentEntryLevelClick(object sender, EventArgs e)
        {
            try
            {
                if (this.trvStudentEnrolment.SelectedNode.Text != null)
                {
                    using (StudentEntryLevelUpdate frmUpdate = new StudentEntryLevelUpdate(_userInfo,
                        _studentManager.GetDetailsStudentEnrolmentLevel(_studentManager.GetSystemId(this.trvStudentEnrolment.SelectedNode.Text)),
                        _studentManager.GetDetailsStudentCourseInfoByEnrolmentCourse(
                        _studentManager.GetSysIdEnrolmentCourse(_studentManager.GetSystemId(this.trvStudentEnrolment.SelectedNode.Text))), _studentManager))
                    {
                        frmUpdate.ShowDialog(this);

                        if (frmUpdate.HasDeleted)
                        {
                            _studentManager.InitializeTreeViewControl(this.trvStudentEnrolment,
                                this.mnuCreateCourse, this.mnuUpdateCourse, this.mnuDelete, this.mnuCreateEntryLevel, _hasGenerateStudentId, _courseGroupId);

                            _hasDeletedEntryLevel = true;
                        }
                        else
                        {
                            _hasDeletedEntryLevel = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading update entry level module.\n\n" + ex.Message, "Error Loading", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//------------------------------
        //########################################END LINKLABEl lnkUpdateStudentEntryLevel EVENTS#####################################################  

        //########################################LINKLABEL lnkGenerateStudentIdLink EVENTS#####################################################
        //event is raised when the control is clicked
        private void lnkGenerateStudentIdLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (StudentIdGenerator frmCreate = new StudentIdGenerator(_userInfo, _studentManager))
            {
                frmCreate.ShowDialog(this);

                if (frmCreate.HasAdded)
                {
                    this.txtStudentId.Text = frmCreate.StudentId;
                    _yearLevelId = frmCreate.YearLevelId;
                    _courseGroupId = frmCreate.CourseGroupId;

                    _studentInfo.StudentId = RemoteClient.ProcStatic.TrimStartEndString(this.txtStudentId.Text);

                    _hasGenerateStudentId = true;
                    
                    this.txtStudentLastName.Focus();
                }
            }
        }//---------------------------
        //########################################END LINKLABEL lnkGenerateStudentIdLink EVENTS#####################################################

        //########################################TREEVIEW trvStudentEnrolment EVENTS#####################################################
        //event is raised when the control is clicked
        private void trvStudentEnrolmentNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            this.trvStudentEnrolment.SelectedNode = e.Node;
        }//---------------------------
        //########################################END TREEVIEW trvStudentEnrolment EVENTS#####################################################

        //########################################LINKLABEL lnkVerify EVENTS#####################################################
        //event is raised when the link is clicked
        protected virtual void lnkVerifyLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                DataTable resultTable = _studentManager.GetSearchPersonInformation(_userInfo, String.Empty, _studentInfo.PersonInfo.LastName,
                    _studentInfo.PersonInfo.FirstName, String.Empty, true);

                if (resultTable.Rows.Count > 0)
                {
                    using (BaseServices.VerifyPersonExistenceList frmVerify = new BaseServices.VerifyPersonExistenceList(_userInfo, _studentManager,
                        RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(_studentInfo.PersonInfo.LastName,
                        _studentInfo.PersonInfo.FirstName, _studentInfo.PersonInfo.MiddleName), resultTable, true, false, ref this.pbxStudent))
                    {
                        frmVerify.ShowDialog(this);

                        if (frmVerify.HasSelected)
                        {
                            _studentInfo = frmVerify.StudentInfo;

                            if (!String.IsNullOrEmpty(_studentInfo.StudentSysId))
                            {
                                _isForUpdateStudent = true;

                                this.Close();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("The system has successfully verified that " + RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(
                              _studentInfo.PersonInfo.LastName, _studentInfo.PersonInfo.FirstName, _studentInfo.PersonInfo.MiddleName) +
                              " does NOT currently exist on the database." +
                              "\n\nClick OK to proceed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _isVerified = true;

                this.SetStudentCashierControls();
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Person Verify Module");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//---------------------------
        //########################################LINKLABEL lnkVerify EVENTS#####################################################  

        //########################################LINKLABEL lnkPersonArchive EVENTS#####################################################
        //event is raised when the link is clicked
        private void lnkPersonArchiveLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (BaseServices.PersonSearchOnTextBoxList frmSearch = new BaseServices.PersonSearchOnTextBoxList(_userInfo, _studentManager, 
                    true, false, this.pbxStudent))
                {
                    frmSearch.CreatePersonVisible = false;
                    frmSearch.ShowDialog(this);

                    if (frmSearch.HasSelected)
                    {  
                        if (!String.IsNullOrEmpty(frmSearch.StudentInfo.StudentSysId))
                        {
                            _studentInfo = frmSearch.StudentInfo;

                            _isForUpdateStudent = true;

                            this.Close();
                        }
                        else
                        {
                            _studentInfo.PersonInfo = _studentManager.GetPersonDetails(_userInfo, _studentManager.GetPersonSysId(frmSearch.RowIndex),
                                Application.StartupPath);

                            this.SetStudentCashierControls();
                        }
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
        //########################################END LINKLABEL lnkPersonArchive EVENTS#####################################################    
        #endregion

        #region Programmer-Defined Void Procedures
        //this procedure will set student cashier controls
        private void SetStudentCashierControls()
        {
            _studentManager.InitializeStudentEnrolmentCourseLevelTable(_userInfo, _studentInfo.StudentSysId);

            _studentSysId = _studentInfo.StudentSysId;

            this.txtStudentId.Text = _studentInfo.StudentId;
            this.txtStudentLastName.Text = _studentInfo.PersonInfo.LastName;
            this.txtStudentFirstName.Text = _studentInfo.PersonInfo.FirstName;
            this.txtMiddleName.Text = _studentInfo.PersonInfo.MiddleName;
            this.txtScholarship.Text = _studentInfo.Scholarship;
            this.chkIsInternational.Checked = _studentInfo.IsInternational;

            this.gbxEnrolmentInfo.Enabled = !String.IsNullOrEmpty(_studentInfo.StudentSysId) ? true : false;

            _studentManager.InitializeTreeViewControl(this.trvStudentEnrolment, this.mnuCreateCourse, this.mnuUpdateCourse, this.mnuDelete, 
                this.mnuCreateEntryLevel, _hasGenerateStudentId, _courseGroupId);

            this.pbxStudent.Image = null;

            if (!String.IsNullOrEmpty(_studentInfo.PersonInfo.FilePath))
            {
                this.pbxStudent.Image = Image.FromFile(_studentInfo.PersonInfo.FilePath);
            }

            this.gbxEnrolmentInfo.Enabled = true;
        }//-----------------------------
        #endregion

        #region Programmer-Defined Function Procedures
        //this procedure will set first letter of an input
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
        }//------------------------------

        //this function determines if the controls are validated
        protected Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.lblStudentId, "");
            _errProvider.SetError(this.lblFirstName, "");
            _errProvider.SetError(this.lblLastName, "");
            _errProvider.SetError(this.trvStudentEnrolment, "");
                   
            if (String.IsNullOrEmpty(txtStudentId.Text.Trim()))
            {
                _errProvider.SetError(this.lblStudentId, "A student ID is required.");
                isValid = false;
            }
            else if (_studentManager.IsExistStudentIdStudentInformation(_userInfo, _studentInfo.StudentId, _studentInfo.StudentSysId))
            {
                _errProvider.SetError(this.lblStudentId, "The student ID already exists.");
                isValid = false;
            }

            if (String.IsNullOrEmpty(txtStudentFirstName.Text.Trim()))
            {
                _errProvider.SetError(this.lblFirstName, "A student First Name is required.");
                isValid = false;
            }

            if (String.IsNullOrEmpty(txtStudentLastName.Text.Trim()))
            {
                _errProvider.SetError(this.lblLastName, "A student Last Name is required.");
                isValid = false;
            }

            if (!_studentManager.HasCurrentCourseEntryLevelCreated())
            {
                _errProvider.SetIconAlignment(this.trvStudentEnrolment, ErrorIconAlignment.TopLeft);
                _errProvider.SetError(this.trvStudentEnrolment, "You must create an student entry level for the student current course.");
                isValid = false;
            }

            if (String.IsNullOrEmpty(_studentInfo.StudentSysId))
            {
                if (!_studentManager.HasCurrentCourse())
                {
                    _errProvider.SetIconAlignment(this.trvStudentEnrolment, ErrorIconAlignment.TopLeft);
                    _errProvider.SetError(this.trvStudentEnrolment, "You must create a current course.");
                    isValid = false;
                }
            }           

            return isValid;
        }//-----------------------


        #endregion

    }
}
