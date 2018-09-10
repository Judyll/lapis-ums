using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class StudentLoading : IDisposable
    {
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private CommonExchange.Student _studentInfo;
        private CommonExchange.StudentEnrolmentLevel _studentEnrolmentLevelInfo;
        private StudentLoadingLogic _studentManager;

        private String _sysIdSubjectSchedule = String.Empty;
        private String _enrolmentCourseSysId = String.Empty;
        private String _sysIdSchoolFeeDetails = String.Empty;
        private String _courseId = String.Empty;
        private String _dateStart = String.Empty;
        private String _dateEnd = String.Empty;

        private Int64 _optionalFeeId = 0;
        private Int32 _oldIndexCourse = -1;
        private Int32 _oldIndexYearLevel = -1;
        private Int32 _oldIndexYear = -1;
        private Int32 _oldIndexSemester = -1;
        private Int32 _flag = 0;
       
        private Boolean _askConfirmation = true;
        private Boolean _hasRecorded = true;
        private Boolean _hasUpdatedOptionalFee = false;
        private Boolean _isCurrentCourse = false;
        private Boolean _isOpenSubjectLoadWithdrawn = true;

        private ErrorProvider _errProvider;
        #endregion

        #region Class Constructor and distructor
        public StudentLoading(CommonExchange.SysAccess userInfo, CommonExchange.Student studentInfo, StudentLoadingLogic studentManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _studentInfo = studentInfo;
            _studentManager = studentManager;

            _errProvider = new ErrorProvider();
            _studentEnrolmentLevelInfo = new CommonExchange.StudentEnrolmentLevel();
         
            this.Load += new EventHandler(ClassLoad);
            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnClose.Click += new EventHandler(btnCloseClick); 
            this.btnRecord.Click += new EventHandler(btnRecordClick); 
            this.btnAddSubjectLoad.Click += new EventHandler(btnAddSubjectLoadClick);
            this.btnOptinalFee.Click += new EventHandler(btnOptionalFeeClick);
            this.btnPrintStudentLoad.Click += new EventHandler(btnPrintStudentLoadClick);
            this.btnEnrolmentHistory.Click += new EventHandler(btnEnrolmentHistoryClick);
            this.btnLegend.Click += new EventHandler(btnLegendClick);
            this.btnGrade.Click += new EventHandler(btnGradeClick);
            this.btnPrintStatementOfAccount.Click += new EventHandler(btnPrintStatementOfAccountClick);
            this.btnDelete.Click += new EventHandler(btnDeleteClick);
            this.btnShiftToCurrentCourse.Click += new EventHandler(btnShiftToCurrentCourseClick);
            this.btnChangeLevel.Click += new EventHandler(btnChangeLevelClick);
            this.cboYear.SelectedIndexChanged += new EventHandler(cboYearSelectedIndexChanged);
            this.cboSemester.SelectedIndexChanged += new EventHandler(cboSemesterSelectedIndexChanged);
            this.cboCourse.SelectedIndexChanged += new EventHandler(cboCourseSelectedIndexChanged);
            this.cboYearLevel.SelectedIndexChanged += new EventHandler(cboYearLevelSelectedIndexChanged);
            this.cboMajorIn.SelectedIndexChanged += new EventHandler(cboMajorInSelectedIndexChanged);
            this.txtSection.Validated += new EventHandler(txtSectionValidated);
            this.chkIsInternational.CheckedChanged += new EventHandler(chkIsInternationalCheckedChanged);
            this.chkIsGraduating.CheckedChanged += new EventHandler(chkIsGraduatingCheckedChanged);
            this.lsvSubjectLoad.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(lsvSubjectLoadItemSelectionChanged);
            this.lsvSubjectLoad.MouseDown += new MouseEventHandler(lsvSubjectLoadMouseDown);
            this.lsvWithdrawnSubjects.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(lsvWithdrawnSubjectsItemSelectionChanged);
            this.lsvWithdrawnSubjects.MouseDown += new MouseEventHandler(lsvWithdrawnSubjectsMouseDown);            
            this.lsvCharges.MouseDown += new MouseEventHandler(lsvChargesMouseDown);
            this.lnkWithdrawSubject.Click += new EventHandler(lnkWithdrawSubjectClick);
            this.lnkRealoadSubject.Click += new EventHandler(lnkRealoadSubjectClick);
            this.lnkDeleteOptionalFee.Click += new EventHandler(lnkDeleteOptionalFeeClick);            
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
        //###########################################CLASS StudentLoading EVENTS#####################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            _studentManager.InitializeSchoolYearCombo(this.cboYear);

            this.lblStdStudentId.Text = _studentInfo.StudentId;
            this.lblStdLastName.Text = _studentInfo.PersonInfo.LastName;
            this.lblStdFirstName.Text = _studentInfo.PersonInfo.FirstName;
            this.lblMiddleName.Text = _studentInfo.PersonInfo.MiddleName;

            if (!String.IsNullOrEmpty(_studentInfo.PersonInfo.FilePath))
            {
                this.pbxStudent.Image = Image.FromFile(_studentInfo.PersonInfo.FilePath);
            }

            _studentManager.SelectBySysIDStudentForEnrolmentHistoryEnrolmentCourseLevel(_userInfo, _studentInfo.StudentSysId);

        }//---------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasRecorded)
            {
                String strMsg = "There has been changes made in the current student loading module. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    _studentManager.ClearCachedData();
                }
            }           
        }//------------------------       
        //###########################################END CLASS StudentLoading EVENTS#####################################################       

        //###########################################BUTTON btnClose EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//----------------------------
        //###########################################END BUTTON btnClose EVENTS#####################################################

        //###########################################BUTTON btnRecord EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnRecordClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateControls())
                {
                    String strMsg = "Are you sure you want to record the new student load?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Record", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student load has been successfully recorded.";

                        this.Cursor = Cursors.WaitCursor;

                        _studentManager.RecordStudentLoad(_userInfo, ref _studentEnrolmentLevelInfo, _studentManager.IsEnrolled(this.cboYearLevel.SelectedIndex));

                        this.Cursor = Cursors.Arrow;
                                                
                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasRecorded = true;

                        _hasUpdatedOptionalFee = false;

                        this.btnPrintStatementOfAccount.Enabled = this.btnPrintStudentLoad.Enabled = true;

                        this.InitializeStudentEnrolmentLevel(this.cboSemester.SelectedIndex != -1 ?
                            _studentManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex) : String.Empty);

                        _studentManager.InitializedYearLevelCombo(this.cboYearLevel);

                        if (RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) ||
                           RemoteServerLib.ProcStatic.IsSystemAccessCashier(_userInfo) ||
                           RemoteServerLib.ProcStatic.IsSystemAccessVpOfFinance(_userInfo))
                        {
                            this.chkIsInternational.Enabled = true;
                        } 
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Recording");
            }
        }//---------------------------
        //###########################################END BUTTON btnRecord EVENTS#####################################################

        //###########################################BUTTON btnAddSubjectLoad EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnAddSubjectLoadClick(object sender, EventArgs e)
        {
            this.AddSubjectLoad(false);
        }//-------------------------
        //###########################################END BUTTON btnAddSubjectLoad EVENTS#####################################################

        //###########################################BUTTON btnAdditionalFee EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnOptionalFeeClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (OptinalFeeSearchOnTextBoxList frmSearch = new OptinalFeeSearchOnTextBoxList(_studentManager))
                {
                    frmSearch.AdoptGridSize = true;
                    frmSearch.ShowDialog(this);

                    if (frmSearch.HasSelected)
                    {
                        _studentManager.InsertOptionalFee(frmSearch.PrimaryId, _studentEnrolmentLevelInfo.EnrolmentLevelSysId);

                        _studentManager.InitializeStudentChargesListView(this.lsvCharges, this.lblMenu, _studentInfo.StudentSysId);

                        _hasRecorded = false;

                        _hasUpdatedOptionalFee = true;

                        this.btnPrintStatementOfAccount.Enabled = this.btnPrintStudentLoad.Enabled = false;
                    }
                }

                this.Cursor = Cursors.Arrow;
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Optional Fee Search Module.", "Error Loading");
            }
        }//----------------------------
        //###########################################END BUTTON btnAdditionalFee EVENTS#####################################################

        //###########################################BUTTON btnPrintStudentLoad EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnPrintStudentLoadClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                String sem = String.IsNullOrEmpty(this.cboSemester.Text) ? String.Empty : " - " + this.cboSemester.Text;

                _studentManager.PrintStudentLoad(_userInfo, _studentInfo.StudentSysId, this.cboYear.Text + sem, 
                    _studentEnrolmentLevelInfo.EnrolmentLevelSysId, _enrolmentCourseSysId, _studentEnrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId);

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Student Loading Printing Module.");
            }
        }//-------------------------
        //###########################################END BUTTON btnPrintStudentLoad EVENTS#####################################################

        //###########################################BUTTON btnPrintStatementOfAccount EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnPrintStatementOfAccountClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _studentManager.SelectMajorExamScheduleTable(_userInfo, _dateStart, _dateEnd,
                    _studentManager.GetStudentCourseGroupId(_studentInfo.StudentSysId), false);

                using (MajorExamSchedule frmPrint = new MajorExamSchedule(_userInfo, _studentManager, false))
                {
                    frmPrint.ShowDialog(this);

                    if (frmPrint.HasClickedPrint)
                    {
                         String sem = String.IsNullOrEmpty(this.cboSemester.Text) ? String.Empty : " - " + this.cboSemester.Text;

                         _studentManager.PrintStudentStatementOfAccount(_userInfo, _studentInfo.StudentSysId,
                             this.cboYear.Text + sem, _studentEnrolmentLevelInfo.EnrolmentLevelSysId, 
                             _studentEnrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId, _enrolmentCourseSysId, 
                             DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd), 
                             _studentManager.IsSchoolYearForSummer(_studentManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)));
                    }
                }

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }
        }//------------------------
        //###########################################END BUTTON btnPrintStatementOfAccount EVENTS#####################################################

        //###########################################BUTTON btnEnrolmentHistroy EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnEnrolmentHistoryClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (StudentEnrolmentHistory frmHistory = new StudentEnrolmentHistory(_studentManager))
                {
                    frmHistory.ShowDialog();
                }

                this.Cursor = Cursors.Arrow;
            }
            catch 
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Enrolment History Module.", "Error Loading");
            }
        }//------------------------
        //###########################################END BUTTON btnEnrolmentHistroy EVENTS#####################################################

        //###########################################BUTTON btnLegend EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnLegendClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (BaseServices.SubjectLegend frmLegend = new BaseServices.SubjectLegend())
                {
                    frmLegend.ShowDialog(this);
                }

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Subject Schedule Type Module.\n\n" + ex.Message, "Error Loading");
            }
        }//---------------------------
        //###########################################END BUTTON btnLegend EVENTS#####################################################

        //###########################################BUTTON btnGrade EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnGradeClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (StudentGrades frmShow = new StudentGrades(_userInfo, _studentManager, _studentInfo))
                {
                    frmShow.ShowDialog(this);
                }

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Student Grade Module.\n\n" + ex.Message, "Error Loading");
            }
        }//---------------------------
        //###########################################END BUTTON btnGrade EVENTS#####################################################

        //###########################################BUTTON btnDeleteLevel EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnDeleteClick(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(_studentEnrolmentLevelInfo.EnrolmentLevelSysId))
                {
                    String strMsg = "Marking the student enrolment level as deleted might affect the following:" +
                      "\n\n1. The student enrolment subject list. \n2. The student charges. \n3. The student scholarship list." +
                      "\n\nAre you sure you want to mark as deleted the student enrolment entry level?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                        MessageBoxDefaultButton.Button2);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "This operation cannot be UNDONE and will cause some loss of data.\n\n" +
                            "Are you really sure you want to mark as deleted the student enrolment level?";

                        msgResult = MessageBox.Show(strMsg, "Confirm Mark As Deleted", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2);

                        if (msgResult == DialogResult.Yes)
                        {
                            strMsg = "The student level information has been successfully deleted.";

                            this.Cursor = Cursors.WaitCursor;

                            _studentManager.DeleteStudentEnrolmentLevel(_userInfo, _studentEnrolmentLevelInfo);

                            this.Cursor = Cursors.Arrow;

                            MessageBox.Show(strMsg, "Success");

                            this.btnRecord.Enabled = false;

                            _hasUpdatedOptionalFee = false;

                            this.Cursor = Cursors.WaitCursor;

                            //this.cboYearLevel.SelectedIndexChanged -= new EventHandler(cboYearLevelSelectedIndexChanged);

                            this.InitializeStudentEnrolmentLevel(this.cboSemester.SelectedIndex != -1 ?
                                _studentManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex) : String.Empty);

                            _studentManager.InitializedYearLevelCombo(this.cboYearLevel);

                            //this.cboYearLevel.SelectedIndexChanged += new EventHandler(cboYearLevelSelectedIndexChanged);

                            this.InitializeStudentControls(true);

                            this.Cursor = Cursors.Arrow;
                        }
                    }
                }
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Deleting Student Enrolment Level", "Error Deleting");
            }
        }//--------------------------
        //###########################################END BUTTON btnDeleteLevel EVENTS#####################################################

        //###########################################BUTTON btnShiftToCurrentCourse EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnShiftToCurrentCourseClick(object sender, EventArgs e)
        {
            try
            {
                String strMsg = "Are you sure you want to shift this current " + 
                    _studentEnrolmentLevelInfo.SchoolFeeLevelInfo.YearLevelInfo.YearLevelDescription + " ENROLLMENT LEVEL with the course of " + 
                    _studentManager.GetCourseDescription(_studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.EnrolmentCourseSysId) + 
                    " to the current course " + _studentManager.GetStudentCurrentCourseSystemIdDescripton(false) + "?";

                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (msgResult == DialogResult.Yes)
                {
                    strMsg = "The student enrollment record is successfully updated.";

                    this.Cursor = Cursors.WaitCursor;

                    _studentEnrolmentLevelInfo.EnrolmentCourseMajorList.Clear();

                    _studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.EnrolmentCourseSysId = _studentManager.GetStudentCurrentCourseSystemIdDescripton(true);

                    _studentManager.UpdateStudentEnrollmentLevel(_userInfo, _studentEnrolmentLevelInfo);

                    this.Cursor = Cursors.Arrow;

                    MessageBox.Show(strMsg, "Success");

                    this.Cursor = Cursors.WaitCursor;

                    this.cboYearLevel.Items.Clear();
                    _studentManager.InitializedCourseCombo(this.cboCourse,
                        _studentManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex), true);

                    this.Cursor = Cursors.Arrow;
                }
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Updating Student Enrolment Level", "Error Deleting");
            }
        }//----------------------------
        //###########################################END BUTTON btnShiftToCurrentCourse EVENTS#####################################################         

        //###########################################BUTTON btnChangeLevel EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnChangeLevelClick(object sender, EventArgs e)
        {
            using (ChangeStudentEnrollmentLevel frmChange = new ChangeStudentEnrollmentLevel(_userInfo, _studentEnrolmentLevelInfo,
                _studentManager, _studentManager.GetStudentEnrolmentLevelFormatForChangeStudentEnrolmentLevel(), _studentInfo.StudentSysId,
                _studentManager.GetSchoolYearYearId(this.cboYear.SelectedIndex), _studentManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex)))
            {
                frmChange.ShowDialog(this);

                if (frmChange.HasUpdated)
                {
                    this.Cursor = Cursors.WaitCursor;

                    this.cboYearLevel.Items.Clear();
                    _studentManager.InitializedCourseCombo(this.cboCourse,
                        _studentManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex), true);

                    _studentManager.SelectBySysIDStudentForEnrolmentHistoryEnrolmentCourseLevel(_userInfo, _studentInfo.StudentSysId);

                    this.Cursor = Cursors.Arrow;
                }
            }
        }//-----------------------------
        //###########################################END BUTTON btnChangeLevel EVENTS#####################################################

        //###########################################COMBOBOX cboYear EVENTS#####################################################
        //event is raised when selected index is changed
        private void cboYearSelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (this.SetAskedConfermationForStudentLoad("school year", true, false, false, false))
            {
                _oldIndexYear = this.cboYear.SelectedIndex;

                this.InitializeStudentControls(false);

                this.InitializeYearComboSelectedIndexChanged();

                _askConfirmation = true;
            }

            this.Cursor = Cursors.Arrow;
        }//---------------------------
        //###########################################END COMBOBOX cboYear EVENTS#####################################################

        //###########################################COMBOBOX cboSemester EVENTS#####################################################
        //event is raised when selected index is changed
        private void cboSemesterSelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (this.SetAskedConfermationForStudentLoad("semester", false, true, false, false))
            {
                _oldIndexSemester = this.cboSemester.SelectedIndex;

                this.InitializeStudentControls(false);

                this.InitializeSemesterComboSelectedIndexChanged();

                _askConfirmation = true;
            }

            this.Cursor = Cursors.Arrow;
        }//---------------------------
        //###########################################END COMBOBOX cboSemester EVENTS#####################################################

        //###########################################COMBOBOX cboCourse EVENTS#####################################################
        //event is raised when selected index is changed
        private void cboCourseSelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (this.SetAskedConfermationForStudentLoad("course", false, false, true, false))
            {
                _oldIndexCourse = this.cboCourse.SelectedIndex;

                this.InitializeStudentControls(false);

                if (this.cboSemester.SelectedIndex >= 0)
                {
                    _enrolmentCourseSysId = _studentManager.GetEnrolmentCourseSysId(this.cboCourse.SelectedIndex,
                        _studentManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex), true,
                        ref _courseId, ref _isCurrentCourse);

                    this.InitializeStudentEnrolmentLevel(_studentManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex));
                }
                else
                {
                    _enrolmentCourseSysId = _studentManager.GetEnrolmentCourseSysId(this.cboCourse.SelectedIndex, String.Empty, false, 
                        ref _courseId, ref _isCurrentCourse);

                    this.InitializeStudentEnrolmentLevel(String.Empty);
                }

                this.btnAddSubjectLoad.Enabled = this.btnOptinalFee.Enabled = this.btnDelete.Enabled =
                    this.btnRecord.Enabled = !_studentManager.IsCurrentCourse(_enrolmentCourseSysId) ? false : true;
                
                _studentManager.InitializedYearLevelCombo(this.cboYearLevel);                

                _askConfirmation = true;
            }

            this.Cursor = Cursors.Arrow;
        }//-------------------------
        //###########################################END COMBOBOX cboCourse EVENTS#####################################################

        //###########################################COMBOBOX cboYearLevel EVENTS#####################################################
        //event is raised when selected index is changed
        private void cboYearLevelSelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
           
            if (this.SetAskedConfermationForStudentLoad("year level", false, false, false, true))
            {
                _oldIndexYearLevel = this.cboYearLevel.SelectedIndex;

                this.InitializeYearLevelSelectedIndexChanged();

                _askConfirmation = true;
            }

            this.Cursor = Cursors.Arrow;
        }//---------------------------
        //###########################################END COMBOBOX cboYearLevel EVENTS#####################################################

        //###########################################COMBOBOX cboMajorIn EVENTS#####################################################
        //event is raised when selected index is changed
        private void cboMajorInSelectedIndexChanged(object sender, EventArgs e)
        {
            _studentEnrolmentLevelInfo.EnrolmentCourseMajorList.Clear();

            _studentEnrolmentLevelInfo.EnrolmentCourseMajorList.Add(_studentManager.GetSelectedCourseMajor(this.cboMajorIn.SelectedIndex));
            _studentEnrolmentLevelInfo.EnrolmentCourseMajorList.Add(_studentManager.GetCurrentCourseMajor());
        }//--------------------------
        //###########################################END COMBOBOX cboMajorIn EVENTS#####################################################

        //###########################################TEXTBOX txtSection EVENTS#####################################################
        //event is raised when the control is validated
        private void txtSectionValidated(object sender, EventArgs e)
        {
            _studentEnrolmentLevelInfo.LevelSection = RemoteClient.ProcStatic.TrimStartEndString(this.txtSection.Text);
        }//----------------------------
        //###########################################END TEXTBOX txtSection EVENTS#####################################################   

        //###########################################CHECKEDBOX chkIsGraduating EVENTS#####################################################
        //event is raised when the checked changed
        private void chkIsInternationalCheckedChanged(object sender, EventArgs e)
        {
            _studentEnrolmentLevelInfo.IsInternational = this.chkIsInternational.Checked;

            if (this.cboYearLevel.SelectedIndex >= 0)
            {
                _studentManager.SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoad(_userInfo, _studentInfo.StudentSysId,
                    _studentEnrolmentLevelInfo.EnrolmentLevelSysId, _studentEnrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId,
                    _studentManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex),
                   _studentEnrolmentLevelInfo.IsGraduateStudent, _studentEnrolmentLevelInfo.IsInternational,
                   _studentManager.IsEnrolled(this.cboYearLevel.SelectedIndex), _studentEnrolmentLevelInfo.IsMarkedDeleted, false);

                _studentManager.InitializeStudentChargesListView(this.lsvCharges, this.lblMenu, _studentInfo.StudentSysId);
            }          
        }//----------------------------
        //###########################################END CHECKEDBOX chkIsGraduating EVENTS#####################################################

        //###########################################CHECKEDBOX chkIsGraduating EVENTS#####################################################
        //event is raised when the checked changed
        private void chkIsGraduatingCheckedChanged(object sender, EventArgs e)
        {
            _studentEnrolmentLevelInfo.IsGraduateStudent = this.chkIsGraduating.Checked;

            _studentManager.SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoad(_userInfo, _studentInfo.StudentSysId,
                _studentEnrolmentLevelInfo.EnrolmentLevelSysId, _studentEnrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId,
                _studentManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex),
               _studentEnrolmentLevelInfo.IsGraduateStudent, _studentEnrolmentLevelInfo.IsInternational,
               _studentManager.IsEnrolled(this.cboYearLevel.SelectedIndex), _studentEnrolmentLevelInfo.IsMarkedDeleted, false);

            _studentManager.InitializeStudentChargesListView(this.lsvCharges, this.lblMenu, _studentInfo.StudentSysId);
        }//---------------------------
        //###########################################END CHECKEDBOX chkIsGraduating EVENTS#####################################################

        //###########################################LISTVIEW lsvSubjectLoad EVENTS#####################################################
        //event is raised when the item selection is changed
        private void lsvSubjectLoadItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                _studentManager.InitializeSubjectLoadWithdrawDetailsListViewDataGridView(this.lsvSubjectDetails, e.Item.SubItems[0].Text, true, null);
            }           
        }//-------------------------------            

        //event is raised when the mouse is down
        private void lsvSubjectLoadMouseDown(object sender, MouseEventArgs e)
        {
            if (_isOpenSubjectLoadWithdrawn)
            {
                if ((e.Button == MouseButtons.Right || e.Button == MouseButtons.Left) &&
                    (this.lsvSubjectLoad.Items.Count > 0 && this.lsvSubjectLoad.FocusedItem != null))
                {
                    if (this.lsvSubjectLoad.SelectedItems.Count > 0)
                    {
                        if (this.lsvSubjectLoad.GetItemAt(e.X, e.Y) != null && e.Button == MouseButtons.Right)
                        {
                            if (_studentManager.HassAccessToDeloadReaload(_userInfo, this.lsvSubjectLoad.GetItemAt(e.X, e.Y).Text))
                            {
                                String strMsg = "Withdraw subject schedule - [" + this.lsvSubjectLoad.GetItemAt(e.X, e.Y).Text + "].";

                                _sysIdSubjectSchedule = this.lsvSubjectLoad.GetItemAt(e.X, e.Y).Text;

                                this.cmsWithdrawSubject.Items[0].Text = strMsg;
                                this.cmsWithdrawSubject.Show(this.lsvSubjectLoad, new Point(e.X, e.Y));
                            }
                        }
                    }
                    else
                    {
                        _studentManager.InitializeSubjectLoadWithdrawDetailsListViewDataGridView(this.lsvSubjectDetails, String.Empty, true, null);
                    }
                }
            }
        }//-------------------------------
        //###########################################END LISTVIEW lsvSubjectLoad EVENTS#####################################################

        //###########################################LISTVIEW lsvWithdrawnSubject EVENTS#####################################################
        //event is raised when the mouse is down
        private void lsvWithdrawnSubjectsMouseDown(object sender, MouseEventArgs e)
        {
            if (_isOpenSubjectLoadWithdrawn)
            {
                if ((e.Button == MouseButtons.Right || e.Button == MouseButtons.Left) &&
                    (this.lsvWithdrawnSubjects.Items.Count > 0 && this.lsvWithdrawnSubjects.FocusedItem != null))
                {
                    if (this.lsvWithdrawnSubjects.SelectedItems.Count > 0)
                    {
                        if (this.lsvWithdrawnSubjects.GetItemAt(e.X, e.Y) != null && e.Button == MouseButtons.Right)
                        {
                            if (_studentManager.HassAccessToDeloadReaload(_userInfo, this.lsvWithdrawnSubjects.GetItemAt(e.X, e.Y).Text))
                            {
                                String strMsg = "Reload subject schedule - [" + this.lsvWithdrawnSubjects.GetItemAt(e.X, e.Y).Text + "].";

                                _sysIdSubjectSchedule = this.lsvWithdrawnSubjects.GetItemAt(e.X, e.Y).Text;

                                this.cmsRealoadSubject.Items[0].Text = strMsg;
                                this.cmsRealoadSubject.Show(this.lsvWithdrawnSubjects, new Point(e.X, e.Y));
                            }
                        }
                    }
                    else
                    {
                        _studentManager.InitializeSubjectLoadWithdrawDetailsListViewDataGridView(this.lsvWithdrawnSubjectDetails, String.Empty, true, null);
                    }
                }
            }
        }//-----------------------------

        //event is raised when the selection is changed
        private void lsvWithdrawnSubjectsItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                _studentManager.InitializeSubjectLoadWithdrawDetailsListViewDataGridView(this.lsvWithdrawnSubjectDetails, e.Item.SubItems[0].Text, true, null);
            }
        }//-----------------------------
        //###########################################END LISTVIEW lsvWithdrawnSubject EVENTS#####################################################

        //###########################################LISTVIEW lsvCharges EVENTS#####################################################
        //event is raised when the mouse is down
        private void lsvChargesMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && !(RemoteServerLib.ProcStatic.IsSystemAccessVpOfAcademicAffairs(_userInfo) ||
                RemoteServerLib.ProcStatic.IsSystemAccessCollegeRegistrar(_userInfo)))
            {
                if ((this.lsvCharges.Items.Count > 0 && this.lsvCharges.FocusedItem != null) && this.lsvCharges.GetItemAt(e.X, e.Y) != null)
                {
                    if (Int64.TryParse(this.lsvCharges.GetItemAt(e.X, e.Y).SubItems[2].Text, out _optionalFeeId))
                    {
                        if (_studentManager.IsOptionalFeeAndIsOfficeAccess(_optionalFeeId))
                        {
                            String strMsg = "Delete optional fee - [" +
                                this.lsvCharges.GetItemAt(e.X, e.Y).Text.Substring(19) + "].";

                            _sysIdSchoolFeeDetails = this.lsvCharges.GetItemAt(e.X, e.Y).SubItems[3].Text;

                            this.cmsDelete.Items[0].Text = strMsg;
                            this.cmsDelete.Show(this.lsvCharges, new Point(e.X, e.Y));
                        }
                    }
                }                       
            }
        }//---------------------------
        //###########################################END LISTVIEW lsvCharges EVENTS#####################################################

        //###########################################LINKLABEL lnkRealoadSubject EVENTS#####################################################
        //event is raised when the item selection is changed
        private void lnkRealoadSubjectClick(object sender, EventArgs e)
        {
            try
            {
                String errorValue = String.Empty;

                if (!_studentManager.HasConflictSchedule(_sysIdSubjectSchedule, ref errorValue))
                {
                    String strMsg = "Are you sure you whant to reaload [" + _studentManager.GetSubjectCodeTitle(_sysIdSubjectSchedule) + "] ?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Reaload", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        _studentManager.RealoadWithdrawnStudentLoad(_sysIdSubjectSchedule);

                        _studentManager.InitializeSubjectLoadListView(this.lsvSubjectLoad, this.lblTotal, this.tblSubjectLoad);
                        _studentManager.InitializeWithdrawSubjectLoadListView(this.lsvWithdrawnSubjects, this.tblWithdrawn);

                        _studentManager.InitializeSubjectLoadWithdrawDetailsListViewDataGridView(this.lsvSubjectDetails, String.Empty, true, null);

                        _studentManager.InitializeStudentChargesListView(this.lsvCharges, lblMenu, _studentInfo.StudentSysId);

                        this.btnPrintStudentLoad.Enabled = this.btnPrintStatementOfAccount.Enabled = false;

                        _hasRecorded = false;
                    }
                }
                else
                {
                    MessageBox.Show(errorValue, "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Realoading");
            }
        }//---------------------------
        //###########################################LINKLABEL lnkRealoadSubject EVENTS#####################################################

        //###########################################LINKLABEL lnkWithdrawSubject EVENTS#####################################################
        //event is raised when the item selection is changed
        private void lnkWithdrawSubjectClick(object sender, EventArgs e)
        {
            try
            {
                String strMsg = "Are you sure you want to withdraw [" + _studentManager.GetSubjectCodeTitle(_sysIdSubjectSchedule) + "] ?";

                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Withdraw", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (msgResult == DialogResult.Yes)
                {
                    _studentManager.WithdrawStudentSubjectLoad(_sysIdSubjectSchedule);

                    _studentManager.InitializeSubjectLoadListView(this.lsvSubjectLoad, this.lblTotal, this.tblSubjectLoad);
                    _studentManager.InitializeWithdrawSubjectLoadListView(this.lsvWithdrawnSubjects, this.tblWithdrawn);

                    _studentManager.InitializeSubjectLoadWithdrawDetailsListViewDataGridView(this.lsvSubjectDetails, String.Empty, true, null);

                    _studentManager.InitializeStudentChargesListView(this.lsvCharges, lblMenu, _studentInfo.StudentSysId);

                    this.btnPrintStudentLoad.Enabled = this.btnPrintStatementOfAccount.Enabled = false;

                    _hasRecorded = false;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Deloading");
            }
        }//----------------------------
        //###########################################END LINKLABEL lnkWithdrawSubject EVENTS#####################################################

        //###########################################LINKLABEL lnkDeleteOptionalFee EVENTS#####################################################
        //event is raised when the item selection is changed
        private void lnkDeleteOptionalFeeClick(object sender, EventArgs e)
        {
            try
            {
                String strMsg = "Are you sure you want to delete [" + _studentManager.GetParticularDescription(_sysIdSchoolFeeDetails) + "]";

                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.Yes)
                {
                    _studentManager.DeleteOptionalFee(_optionalFeeId);

                    _studentManager.InitializeStudentChargesListView(this.lsvCharges, this.lblMenu, _studentInfo.StudentSysId);

                    _hasRecorded = false;

                    _hasUpdatedOptionalFee = true;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Deleting");
            }
        }//---------------------------
        //###########################################END LINKLABEL lnkDeleteOptionalFee EVENTS#####################################################
        #endregion

        #region Programes Defined Void Procedures
        //this procedure will initialze student tab subject
        private void InitializeStudentTabCharges()
        {
            this.tblSubjectLoad.Text = "Student Load";
            this.tblWithdrawn.Text = "Withdrawn Subjects";
            this.tabSpecialClass.Text = "Special Class";
            this.tabWithdrawnSpecialClass.Text = "Withdrawn Special Class";
        }//----------------------

        //this procedure initialize the year combo selected index changed
        private void InitializeYearComboSelectedIndexChanged()
        {
            this.InitializeStudentControls(false);

            _dateStart = _studentManager.GetSchoolYearDateStart(_studentManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)).ToShortDateString() +
                " 12:00:00 AM";
            _dateEnd = _studentManager.GetSchoolYearDateEnd(_studentManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)).ToShortDateString() + " 11:59:59 PM";

            _studentManager.SelectBySysIDStudentDateStartEndStudentEnrolmentCourse(_userInfo, _studentInfo.StudentSysId, _dateStart, _dateEnd);

            _studentManager.SelectBySysIDStudentListDateStartEndStudentPaymentsDiscounts(_userInfo, _studentInfo.StudentSysId, _dateStart, _dateEnd);

            _studentManager.InitializeSemesterCombo(this.cboSemester, this.cboYear.SelectedIndex);

            if (_studentManager.IsSemestral())
            {
                this.cboYearLevel.Items.Clear();
                this.cboMajorIn.Items.Clear();

                this.cboSemester.Enabled = this.cboMajorIn.Enabled = true;
            }
            else
            {
                if (_studentInfo.IsNoDownpaymentRequired ||
                    (!_studentInfo.IsNoDownpaymentRequired &&
                    _studentManager.IsExistsPaymentBySysIDStudentDateStartEndStudentPayments(_userInfo, _studentInfo.StudentSysId, _dateStart, _dateEnd)))
                {
                    this.lblHasPayment.Text = String.Empty;

                    //AD
                    this.cboYearLevel.Items.Clear();
                    _studentManager.InitializedCourseCombo(this.cboCourse, String.Empty, false);

                    this.gbxEnrolmentInfo.Enabled = this.gbxStudentLoad.Enabled = this.gbxCharges.Enabled = true;
                }
                else
                {
                    this.InitializeStudentControls(false);

                    this.lblHasPayment.Text = "A downpayment is required before this student can be enrolled.";

                    this.btnRecord.Enabled = this.btnDelete.Enabled = this.btnOptinalFee.Enabled = this.btnShiftToCurrentCourse.Enabled =
                        this.btnPrintStatementOfAccount.Enabled = this.btnAddSubjectLoad.Enabled = this.btnPrintStudentLoad.Enabled =
                        this.gbxEnrolmentInfo.Enabled = this.gbxStudentLoad.Enabled = this.gbxCharges.Enabled = false;
                }
            }

            this.InitializeStudentChargesSubjectLoadControls();
            this.SetRecordStatus(false);
        }//-------------------------

        //this procedure initialize the semester combo selected index changed
        private void InitializeSemesterComboSelectedIndexChanged()
        {
            _dateStart = _studentManager.GetSemesterDateStart(_studentManager.GetSemesterSystemId(this.cboYear.SelectedIndex, 
                this.cboSemester.SelectedIndex)).ToShortDateString() + " 12:00:00 AM";
            _dateEnd = _studentManager.GetSemesterDateEnd(_studentManager.GetSemesterSystemId(this.cboYear.SelectedIndex, 
                this.cboSemester.SelectedIndex)).ToShortDateString() + " 11:59:59 PM";

            _studentManager.SelectBySysIDStudentDateStartEndStudentEnrolmentCourse(_userInfo, _studentInfo.StudentSysId, _dateStart, _dateEnd);

            _studentManager.SelectBySysIDStudentListDateStartEndStudentPaymentsDiscounts(_userInfo, _studentInfo.StudentSysId, _dateStart, _dateEnd);

            this.InitializeStudentControls(false);

            this.cboMajorIn.Items.Clear();

            if (_studentInfo.IsNoDownpaymentRequired ||
                    (!_studentInfo.IsNoDownpaymentRequired &&
                    _studentManager.IsExistsPaymentBySysIDStudentDateStartEndStudentPayments(_userInfo, _studentInfo.StudentSysId, _dateStart, _dateEnd)))
            {
                this.lblHasPayment.Text = String.Empty;

                this.cboYearLevel.Items.Clear();
                _studentManager.InitializedCourseCombo(this.cboCourse,
                    _studentManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex), true);

                this.gbxEnrolmentInfo.Enabled = this.gbxStudentLoad.Enabled = this.gbxCharges.Enabled = true;
            }
            else
            {
                this.InitializeStudentControls(false);

                this.lblHasPayment.Text = "A downpayment is required before this student can be enrolled.";

                this.btnRecord.Enabled = this.btnDelete.Enabled = this.btnOptinalFee.Enabled =
                    this.btnPrintStatementOfAccount.Enabled = this.btnAddSubjectLoad.Enabled = this.btnPrintStudentLoad.Enabled =
                    this.gbxEnrolmentInfo.Enabled = this.gbxStudentLoad.Enabled = this.gbxCharges.Enabled = false;
            }

            this.InitializeStudentChargesSubjectLoadControls();
            this.SetRecordStatus(false);
        }//-----------------------------

        //this procedure initialize the year level selected index changed
        private void InitializeYearLevelSelectedIndexChanged()
        {
            _studentManager.ClearCachedData();

            this.InitializeStudentTabCharges();

            this.lsvSubjectLoad.Items.Clear();
            this.lsvSubjectDetails.Items.Clear();
            this.lsvWithdrawnSubjects.Items.Clear();
            this.lsvWithdrawnSubjectDetails.Items.Clear();
            this.lsvSpecialClass.Items.Clear();
            this.lsvWithdrawnSpecialClass.Items.Clear();

            this.btnShiftToCurrentCourse.Enabled = false;

            _studentEnrolmentLevelInfo = _studentManager.GetStudentEnrolmentLevelInfo(this.cboYearLevel.SelectedIndex);

            _studentManager.SelectByCourseIDSysIDEnrolmentLevelEnrolmentCourseMajor(_userInfo, _studentInfo.StudentSysId,
                   _studentManager.GetCourseId(_studentEnrolmentLevelInfo.SemesterInfo.SemesterSysId, _studentManager.IsSemestral(), _isCurrentCourse),
                   _studentEnrolmentLevelInfo.EnrolmentLevelSysId);

            _studentManager.InitializeCourseMajorCombo(this.cboMajorIn);

            if (this.cboYearLevel.SelectedIndex != 0)
            {
                _studentEnrolmentLevelInfo.SemesterInfo.SemesterSysId = _studentManager.GetSemesterSystemId(this.cboYear.SelectedIndex, 
                    this.cboSemester.SelectedIndex);

                _studentManager.SelectBySysIDEnrolmentLevelDateStartEndScheduleDetailsStudentLoad(_userInfo, _studentEnrolmentLevelInfo.EnrolmentLevelSysId,
                    _dateStart, _dateEnd, _studentEnrolmentLevelInfo.EnrolmentLevelSysId);

                _studentManager.SelectBySysIDEnrolmentLevelDateStartEndSubjectScheduleStudentLoad(_userInfo, _studentInfo.StudentSysId,
                    _studentEnrolmentLevelInfo.EnrolmentLevelSysId, _studentEnrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId,
                    _studentManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex),
                   _studentEnrolmentLevelInfo.IsGraduateStudent, _studentEnrolmentLevelInfo.IsInternational, false,
                   _studentManager.IsEnrolled(this.cboYearLevel.SelectedIndex), _dateStart, _dateEnd);

                _studentManager.SelectBySysIDStudentListDateStartEndSpecialClassInformation(_userInfo, _studentInfo.StudentSysId, _dateStart, _dateEnd);

                _studentManager.SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoad(_userInfo, _studentInfo.StudentSysId,
                    _studentEnrolmentLevelInfo.EnrolmentLevelSysId, _studentEnrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId,
                    _studentManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex),
                   _studentEnrolmentLevelInfo.IsGraduateStudent, _studentEnrolmentLevelInfo.IsInternational,
                   _studentManager.IsEnrolled(this.cboYearLevel.SelectedIndex), _studentEnrolmentLevelInfo.IsMarkedDeleted, false);

                _studentManager.SelectBySysIDStudentFeeLevelSemesterForOptionalFeeDetailsStudentOptionalFee(_userInfo, _studentInfo.StudentSysId,
                    _studentEnrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId, _studentManager.GetSemesterSystemId(this.cboYear.SelectedIndex, 
                    this.cboSemester.SelectedIndex), _studentEnrolmentLevelInfo.IsInternational);               

                DateTime dateEnding;

                if (_studentManager.IsSemestral())
                {
                    dateEnding = _studentManager.GetSemesterDateStart(_studentManager.GetSemesterSystemId(this.cboYear.SelectedIndex,
                        this.cboSemester.SelectedIndex));
                }
                else
                {
                    dateEnding = _studentManager.GetSchoolYearDateStart(_studentManager.GetSchoolYearYearId(this.cboYear.SelectedIndex));
                }

                _studentManager.SelectBySysIDStudentListDateEndingBalanceCarriedForwardStudentLoad(_userInfo, _studentInfo.StudentSysId,
                    _studentEnrolmentLevelInfo.EnrolmentLevelSysId, dateEnding.AddDays(-1).ToShortDateString() + " 11:59:59 PM");

                _studentManager.InitializeStudentChargesListView(this.lsvCharges, this.lblMenu, _studentInfo.StudentSysId);
                _studentManager.InitializeSubjectLoadListView(this.lsvSubjectLoad, this.lblTotal, this.tblSubjectLoad);
                _studentManager.InitializeWithdrawSubjectLoadListView(this.lsvWithdrawnSubjects, this.tblWithdrawn);
                _studentManager.InitializeSpecialClassLoadedWithdrawnListView(this.lsvSpecialClass, this.lblSpeicalClass, this.tabSpecialClass, false);
                _studentManager.InitializeSpecialClassLoadedWithdrawnListView(this.lsvWithdrawnSpecialClass,
                    this.lblWithdrawnSpecialClass, this.tabWithdrawnSpecialClass, true);

                _studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.EnrolmentCourseSysId = _enrolmentCourseSysId;

                this.txtSection.Text = _studentEnrolmentLevelInfo.LevelSection;

                if (this.cboYearLevel.SelectedIndex != 0)
                {
                    this.chkIsGraduating.Enabled = _studentManager.IsGraduateLevel(this.cboYearLevel.SelectedIndex);
                    this.chkIsGraduating.Checked = _studentEnrolmentLevelInfo.IsGraduateStudent;
                }
             
                this.chkIsInternational.Checked = _studentEnrolmentLevelInfo.IsInternational;

                this.txtSection.Focus();

                if (_studentEnrolmentLevelInfo.IsMarkedDeleted)
                {
                    this.btnDelete.Enabled = this.btnAddSubjectLoad.Enabled = false;
                }
                else if (String.IsNullOrEmpty(_studentEnrolmentLevelInfo.EnrolmentLevelSysId) ||
                    _studentEnrolmentLevelInfo.IsMarkedDeleted)
                {
                    this.btnDelete.Enabled = false;
                    this.btnPrintStatementOfAccount.Enabled = this.btnPrintStudentLoad.Enabled = false;
                }
                else
                {
                    this.btnDelete.Enabled = this.btnAddSubjectLoad.Enabled = true;
                }

                this.btnShiftToCurrentCourse.Enabled = _studentManager.IsValidForShiftToCurrentCourseStudentEnrolmentLevel(_userInfo,
                    _studentEnrolmentLevelInfo.EnrolmentLevelSysId, _studentManager.GetStudentCurrentCourseSystemIdDescripton(true));

                this.InitializeStudentChargesSubjectLoadControls();
                this.SetRecordStatus(_studentEnrolmentLevelInfo.IsMarkedDeleted);


                this.btnChangeLevel.Visible = RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) &&
                    _studentManager.IsValidForYearLevelChange(_userInfo, _studentInfo.StudentSysId, _studentEnrolmentLevelInfo.EnrolmentLevelSysId) ? true : false;
            }
            else
            {
                this.btnChangeLevel.Visible = false;

                this.lsvCharges.Items.Clear();
                this.lsvSubjectLoad.Items.Clear();
                this.lsvSubjectDetails.Items.Clear();
                this.lsvWithdrawnSubjectDetails.Items.Clear();
                this.lsvWithdrawnSubjects.Items.Clear();

                this.txtSection.Clear();
                this.chkIsGraduating.Checked = this.btnOptinalFee.Enabled = this.chkIsGraduating.Enabled =
                    this.btnPrintStatementOfAccount.Enabled = this.btnAddSubjectLoad.Enabled = 
                    this.btnPrintStudentLoad.Enabled = this.btnDelete.Enabled = this.btnRecord.Enabled = false;

                this.lblMenu.Text = String.Empty;
                this.lblHasPayment.Text = String.Empty;
            }
        }//-------------------------

        //this procedure initialize student enrolment level
        private void InitializeStudentEnrolmentLevel(String sysIdSemester)
        {
            //String enrolmentLevelSysIdExcludeList = (RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) &&
            //    !String.IsNullOrEmpty(_studentEnrolmentLevelInfo.EnrolmentLevelSysId)) ? _studentEnrolmentLevelInfo.EnrolmentLevelSysId : String.Empty;

            _studentManager.SelectBySysIDStudentYearIDSemesterStudentEnrolmentLevel(_userInfo, _studentInfo.StudentSysId,
              _studentManager.GetSchoolYearYearId(this.cboYear.SelectedIndex), sysIdSemester, _enrolmentCourseSysId, String.Empty);
        }//----------------------------

        //this procedure initialize student loading controls
        private void InitializeStudentControls(Boolean isOpen)
        {
            this.lsvCharges.Items.Clear();
            this.lsvSubjectLoad.Items.Clear();
            this.lsvSubjectDetails.Items.Clear();
            this.lsvWithdrawnSubjectDetails.Items.Clear();
            this.lsvWithdrawnSubjects.Items.Clear();

            this.tblSubjectLoad.Text = "Subject Load";
            this.tblWithdrawn.Text = "Withdrawn Subjects";
            this.tabSpecialClass.Text = "Special Class";
            this.tabWithdrawnSpecialClass.Text = "Withdrawn Special Class";

            this.txtSection.Clear();
            this.chkIsGraduating.Checked = this.btnOptinalFee.Enabled =
                this.btnPrintStatementOfAccount.Enabled = this.btnAddSubjectLoad.Enabled = this.btnPrintStudentLoad.Enabled = false;

            if (!isOpen)
            {
                _enrolmentCourseSysId = String.Empty;
            }

            this.lblMenu.Text = String.Empty;
            this.lblHasPayment.Text = String.Empty;
        }//-------------------------

        //this procedure initialize student charges/student load controls
        private void InitializeStudentChargesSubjectLoadControls()
        {
            if (!String.IsNullOrEmpty(_enrolmentCourseSysId) && this.cboYearLevel.SelectedIndex != 0)
            {
                this.btnOptinalFee.Enabled = this.btnPrintStatementOfAccount.Enabled = this.btnPrintStudentLoad.Enabled = this.btnRecord.Enabled = true;
            }
            else
            {
                this.btnOptinalFee.Enabled = this.btnPrintStatementOfAccount.Enabled = this.btnAddSubjectLoad.Enabled = 
                    this.btnPrintStudentLoad.Enabled = this.btnRecord.Enabled = false;
            }
        }//------------------------------

        //this procedure will add subject load
        private void AddSubjectLoad(Boolean isIrregularLoading)
        {  
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (SubjectSearchOnTextBoxListStudentLoading frmSearch = new SubjectSearchOnTextBoxListStudentLoading(_userInfo, _studentManager, 1,
                    _studentEnrolmentLevelInfo.IsInternational))
                {
                    frmSearch.IsIrregularLoading = isIrregularLoading;
                    frmSearch.AdoptGridSize = false;
                    frmSearch.ShowDialog(this);

                    if (frmSearch.HasSelected)
                    {
                        _studentManager.InitializeSubjectLoadListView(this.lsvSubjectLoad, this.lblTotal, this.tblSubjectLoad);

                        _studentManager.InitializeStudentChargesListView(lsvCharges, lblMenu, _studentInfo.StudentSysId);

                        this.btnPrintStudentLoad.Enabled = this.btnPrintStatementOfAccount.Enabled = false;

                        this.btnRecord.Enabled = true;
                        this.lblHasPayment.Text = String.Empty;

                        _hasRecorded = false;
                    }

                    isIrregularLoading = frmSearch.IsIrregularLoading;
                }

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message + "\n\nError Loading Subject Search Module", "Error Loading");
            }

            if (isIrregularLoading)
            {
                this.AddSubjectLoad(isIrregularLoading);
            }
        }//---------------------------

        //this procedure will set record status
        private void SetRecordStatus(Boolean isMarkedDeleted)
        {
            DateTime dateStart = DateTime.Parse(_dateStart);
            DateTime dateEnd = DateTime.Parse(_dateEnd);
            DateTime serverDateTime = DateTime.Parse(_studentManager.ServerDateTime);

            if ((this.cboSemester.SelectedIndex >= 0) &&
                RemoteClient.ProcStatic.IsRecordLocked(dateStart, dateEnd, serverDateTime, (Int32)CommonExchange.SystemRange.MonthAllowance))
            {
                _isOpenSubjectLoadWithdrawn = false;

                if (!RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo))//Code Added::Feb. 9,2011..Code Purpose remove record locking for adminstrator
                {
                    this.lblStatus.Text = "This record is LOCKED";

                    this.pbxLocked.Visible = true;
                    this.pbxUnlock.Visible = false;

                    this.btnRecord.Enabled = this.btnDelete.Enabled = this.btnShiftToCurrentCourse.Enabled = this.btnAddSubjectLoad.Enabled =
                        this.btnOptinalFee.Enabled = this.chkIsGraduating.Enabled = false;

                    if (this.cboYearLevel.SelectedIndex == 0)
                    {
                        this.btnPrintStudentLoad.Enabled = this.btnPrintStatementOfAccount.Enabled = false;
                    }

                    this.lsvSubjectLoad.MouseDown -= new MouseEventHandler(lsvSubjectLoadMouseDown);
                    this.lsvCharges.MouseDown -= new MouseEventHandler(lsvChargesMouseDown);
                    this.lsvWithdrawnSubjects.MouseDown -= new MouseEventHandler(lsvWithdrawnSubjectsMouseDown);

                    this.cboMajorIn.Enabled = this.txtSection.Enabled = false;
                }
                else
                {
                    this.btnDelete.Enabled = this.btnShiftToCurrentCourse.Enabled = this.btnAddSubjectLoad.Enabled = this.btnChangeLevel.Enabled = false;

                    this.btnRecord.Enabled = this.btnOptinalFee.Enabled = true;

                    this.chkIsGraduating.Enabled = _studentManager.IsGraduateLevel(this.cboYearLevel.SelectedIndex);
                }
            }
            else if ((this.cboSemester.SelectedIndex < 0) &&
                RemoteClient.ProcStatic.IsRecordLocked(dateStart, dateEnd, serverDateTime, (Int32)CommonExchange.SystemRange.MonthAllowance))
            {
                if (!RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo))//Code Added::Feb. 9,2011..Code Purpose remove record locking for adminstrator
                {
                    this.lblStatus.Text = "This record is LOCKED";

                    this.pbxLocked.Visible = true;
                    this.pbxUnlock.Visible = false;

                    this.btnRecord.Enabled = this.btnDelete.Enabled = this.btnShiftToCurrentCourse.Enabled = this.btnAddSubjectLoad.Enabled =
                        this.btnOptinalFee.Enabled = this.chkIsGraduating.Enabled = false;

                    if (this.cboYearLevel.SelectedIndex == 0)
                    {
                        this.btnPrintStudentLoad.Enabled = this.btnPrintStatementOfAccount.Enabled = false;
                    }

                    this.lsvSubjectLoad.MouseDown -= new MouseEventHandler(lsvSubjectLoadMouseDown);
                    this.lsvCharges.MouseDown -= new MouseEventHandler(lsvChargesMouseDown);
                    this.lsvWithdrawnSubjects.MouseDown -= new MouseEventHandler(lsvWithdrawnSubjectsMouseDown);

                    this.cboMajorIn.Enabled = this.txtSection.Enabled = false;
                }
                else
                {
                    this.btnDelete.Enabled = this.btnShiftToCurrentCourse.Enabled = this.btnAddSubjectLoad.Enabled = this.btnChangeLevel.Enabled = false;

                    this.btnRecord.Enabled = this.btnOptinalFee.Enabled = true;

                    this.chkIsGraduating.Enabled = _studentManager.IsGraduateLevel(this.cboYearLevel.SelectedIndex);
                }
            }
            else
            {
                this.lsvSubjectLoad.MouseDown -= new MouseEventHandler(lsvSubjectLoadMouseDown);
                this.lsvCharges.MouseDown -= new MouseEventHandler(lsvChargesMouseDown);
                this.lsvWithdrawnSubjects.MouseDown -= new MouseEventHandler(lsvWithdrawnSubjectsMouseDown);
                this.lsvSubjectLoad.MouseDown += new MouseEventHandler(lsvSubjectLoadMouseDown);
                this.lsvCharges.MouseDown += new MouseEventHandler(lsvChargesMouseDown);
                this.lsvWithdrawnSubjects.MouseDown += new MouseEventHandler(lsvWithdrawnSubjectsMouseDown);

                _isOpenSubjectLoadWithdrawn = true;

                this.btnRecord.Enabled = false;

                this.lblStatus.Text = "This record is OPEN";

                this.pbxLocked.Visible = false;
                this.pbxUnlock.Visible = true;

                Boolean isAdmin = RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo);
                Boolean isOfficeUser = RemoteServerLib.ProcStatic.IsSystemAccessOfficeUser(_userInfo);
                Boolean isCashier = RemoteServerLib.ProcStatic.IsSystemAccessCashier(_userInfo);
                Boolean isVPOfFinance = RemoteServerLib.ProcStatic.IsSystemAccessVpOfFinance(_userInfo);
                Boolean isVPOfAcademinAffairs = RemoteServerLib.ProcStatic.IsSystemAccessVpOfAcademicAffairs(_userInfo);
                Boolean isSecAcadAffairs = RemoteServerLib.ProcStatic.IsSystemAccessSecretaryOftheVpOfAcademicAffairs(_userInfo);
                Boolean registrar = RemoteServerLib.ProcStatic.IsSystemAccessCollegeRegistrar(_userInfo);

                if (isAdmin || isOfficeUser)
                {
                    this.chkIsInternational.Enabled = false;
                   
                    if (!String.IsNullOrEmpty(_enrolmentCourseSysId) && this.cboYearLevel.SelectedIndex != 0)
                    {
                        if (isOfficeUser && !RemoteServerLib.ProcStatic.IsSystemAccessOfficeUser(_userInfo, _studentManager.GetDepartmentId(_courseId)))
                        {
                            this.cboMajorIn.Enabled = this.txtSection.Enabled = false;
                        }
                        else
                        {
                            this.cboMajorIn.Enabled = this.txtSection.Enabled = true;
                        }

                        if (isMarkedDeleted)
                        {
                            this.btnAddSubjectLoad.Enabled = this.btnOptinalFee.Enabled = this.btnRecord.Enabled = this.btnDelete.Enabled = false;
                        }
                        else
                        {
                            this.btnAddSubjectLoad.Enabled = this.btnOptinalFee.Enabled = this.btnRecord.Enabled = this.btnDelete.Enabled = true;
                        }                     

                        if (String.IsNullOrEmpty(_studentEnrolmentLevelInfo.EnrolmentLevelSysId))
                        {
                            this.btnDelete.Enabled = false;
                            this.btnPrintStatementOfAccount.Enabled = this.btnPrintStudentLoad.Enabled = false;

                            if (isOfficeUser && !RemoteServerLib.ProcStatic.IsSystemAccessOfficeUser(_userInfo, _studentManager.GetDepartmentId(_courseId)))
                            {
                                this.btnRecord.Enabled = this.btnDelete.Enabled = this.btnAddSubjectLoad.Enabled = this.btnOptinalFee.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        this.btnOptinalFee.Enabled = this.btnAddSubjectLoad.Enabled = this.btnDelete.Enabled =
                            this.btnRecord.Enabled = this.btnPrintStudentLoad.Enabled = this.cboMajorIn.Enabled = this.txtSection.Enabled = false;     
                    }                    
                }

                if ((isVPOfFinance || isCashier) && !(isAdmin || isOfficeUser))
                {
                    this.btnAddSubjectLoad.Enabled = this.txtSection.Enabled = this.cboMajorIn.Enabled = false;

                    if (!String.IsNullOrEmpty(_enrolmentCourseSysId) && this.cboYearLevel.SelectedIndex != 0)
                    {
                        this.btnOptinalFee.Enabled = this.btnDelete.Enabled = this.btnRecord.Enabled = true;

                        if (isMarkedDeleted || String.IsNullOrEmpty(_studentEnrolmentLevelInfo.EnrolmentLevelSysId))
                        {
                            this.btnOptinalFee.Enabled = this.btnRecord.Enabled =  this.btnShiftToCurrentCourse.Enabled = this.btnDelete.Enabled = false;
                        }
                        else
                        {
                            this.btnOptinalFee.Enabled = this.btnRecord.Enabled = this.btnDelete.Enabled = true;
                        }
                    }
                    else
                    {
                        this.btnOptinalFee.Enabled = this.btnShiftToCurrentCourse.Enabled = this.btnDelete.Enabled = this.btnRecord.Enabled = false;
                    }

                    this.chkIsGraduating.Enabled = this.btnShiftToCurrentCourse.Enabled = this.btnDelete.Enabled = false;
                }

                if ((isVPOfAcademinAffairs || isSecAcadAffairs) && !(isAdmin || isOfficeUser))
                {
                    this.btnOptinalFee.Enabled = this.btnAddSubjectLoad.Enabled = this.btnRecord.Enabled = this.btnDelete.Enabled = 
                        this.btnShiftToCurrentCourse.Enabled = this.chkIsInternational.Enabled = this.txtSection.Enabled = 
                        this.cboMajorIn.Enabled = this.cboMajorIn.Enabled = false;
                }

                if (registrar && !(isAdmin || isOfficeUser))
                {
                    this.btnRecord.Enabled = this.btnDelete.Enabled = this.btnAddSubjectLoad.Enabled = this.btnDelete.Enabled = this.btnShiftToCurrentCourse.Enabled =
                        this.btnOptinalFee.Enabled = this.chkIsInternational.Enabled = this.txtSection.Enabled = this.cboMajorIn.Enabled = false;     

                    if (!String.IsNullOrEmpty(_enrolmentCourseSysId) && this.cboYearLevel.SelectedIndex != 0)
                    {
                        this.btnPrintStudentLoad.Enabled = true;
                    }
                    else
                    {
                        this.btnPrintStudentLoad.Enabled = false;
                    }
                }

                //Code for downpayment exist...
                if (RemoteServerLib.ProcStatic.IsSystemAccessVpOfAcademicAffairs(_userInfo) &&
                    (_studentInfo.IsNoDownpaymentRequired ||
                    (!_studentInfo.IsNoDownpaymentRequired &&
                    _studentManager.IsExistsPaymentBySysIDStudentDateStartEndStudentPayments(_userInfo, _studentInfo.StudentSysId, _dateStart, _dateEnd))))
                {
                    this.lblHasPayment.Text = "A downpayment is required before this student can be enrolled.";

                    this.btnRecord.Enabled = this.btnDelete.Enabled = this.btnOptinalFee.Enabled = this.btnShiftToCurrentCourse.Enabled = 
                        this.btnPrintStatementOfAccount.Enabled = this.btnAddSubjectLoad.Enabled = this.btnPrintStudentLoad.Enabled =
                        this.gbxEnrolmentInfo.Enabled = this.gbxStudentLoad.Enabled = this.gbxCharges.Enabled = false;
                }
                else if (RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessVpOfFinance(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessCashier(_userInfo))
                {
                    this.chkIsInternational.Enabled = true;
                }

                if (_studentEnrolmentLevelInfo.IsEntryLevel &&
                    !(RemoteServerLib.ProcStatic.IsSystemAccessCashier(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessVpOfFinance(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo)))
                {
                    this.btnDelete.Enabled = false;
                }
                else //AD because when the access is for cashier the button is disabled
                {
                    this.btnDelete.Enabled = true;
                }

                //there must be no special class before you can delete an student enrolment level
                if (this.lsvSpecialClass.Items.Count > 0)
                {
                    this.btnDelete.Enabled = false;
                }

                if (RemoteServerLib.ProcStatic.IsSystemAccessStudentDataController(_userInfo))
                {
                    this.btnRecord.Visible = this.btnDelete.Visible = this.btnShiftToCurrentCourse.Enabled = this.btnPrintStatementOfAccount.Enabled = 
                        this.btnOptinalFee.Enabled = this.btnAddSubjectLoad.Enabled = this.cboMajorIn.Enabled =
                        this.chkIsGraduating.Enabled = this.txtSection.Enabled = false;
                }
            }
        }//-------------------------
        #endregion

        #region Programes Defined Functions
        //this function will validate controls
        private Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.cboYearLevel, "");
         
            if (this.cboYearLevel.SelectedIndex < 0)
            {
                _errProvider.SetIconAlignment(this.cboYearLevel, ErrorIconAlignment.MiddleLeft);
                _errProvider.SetError(this.cboYearLevel, "A student year level is required.");

                isValid = false;
            }

            return isValid;
        }//---------------------

        //this fucntion will set asked confermation for student loading module
        private Boolean SetAskedConfermationForStudentLoad(String msgDescription, Boolean isSchoolYear, Boolean isSemester,Boolean isCourse, Boolean isYearLevel)
        {
            Boolean hasEnter = false;

            if (_askConfirmation && (_studentManager.HasUnrecordedSubjectLoad() || _hasUpdatedOptionalFee))
            { 
                String strMsg = "There are unrecorded subject load/student optional fee, changing " + msgDescription +
                    " without recording it causes data loss.\n\n" + "Are you sure you want to continue?";

                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    _askConfirmation = false;

                    hasEnter = true;

                    _flag++;

                    if (isCourse)
                    {
                        if (this.cboCourse.SelectedIndex == _oldIndexCourse)
                            _askConfirmation = true;

                        this.cboCourse.SelectedIndex = _oldIndexCourse;
                    }
                    else if (isYearLevel)
                    {
                        if (this.cboYearLevel.SelectedIndex == _oldIndexYearLevel)
                            _askConfirmation = true;

                        this.cboYearLevel.SelectedIndex = _oldIndexYearLevel;
                    }
                    else if (isSchoolYear)
                    {
                        if (this.cboYear.SelectedIndex == _oldIndexYear)
                            _askConfirmation = true;

                        this.cboYear.SelectedIndex = _oldIndexYear;
                    }
                    else if (isSemester)
                    {
                        if (this.cboSemester.SelectedIndex == _oldIndexSemester)
                            _askConfirmation = true;

                        this.cboSemester.SelectedIndex = _oldIndexSemester;
                    }
                }
                else
                {
                    if (isCourse)
                    {
                        _oldIndexCourse = this.cboCourse.SelectedIndex;
                    }
                    else if (isYearLevel)
                    {
                        _oldIndexYearLevel = this.cboYearLevel.SelectedIndex;
                    }
                    else if (isSchoolYear)
                    {
                        _oldIndexYear = this.cboYear.SelectedIndex;
                    }
                    else if (isSemester)
                    {
                        _oldIndexSemester = this.cboSemester.SelectedIndex;
                    }

                    _hasUpdatedOptionalFee = false;

                    _studentManager.ClearStudentLoadTable();

                    hasEnter = false;

                    if (this.lsvSubjectLoad.Items.Count > 0)
                    {
                        this.btnPrintStudentLoad.Enabled = this.btnPrintStatementOfAccount.Enabled = true;
                    }
                }
            }
            else
            {
                _askConfirmation = true;

                if (_flag == 0)
                {
                    hasEnter = false;
                }
                else
                {
                    hasEnter = true;

                    _flag = 0;
                }

                if (this.lsvSubjectLoad.Items.Count > 0)
                {
                    this.btnPrintStudentLoad.Enabled = this.btnPrintStatementOfAccount.Enabled = true;
                }
            }

            return !hasEnter;
        }//----------------------------       
        #endregion
    }
}
