using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace OfficeServices
{
    partial class SubjectSchedule
    {
        #region Class General Variable Declaration
        protected CommonExchange.SysAccess _userInfo;
        protected CommonExchange.ScheduleInformation _schedInfo;
        protected SubjectSchedulingLogic _scheduleManager;
        protected Boolean _hasErrors;
        protected Boolean _hasUpdatedScheduleDetails = false;

        private ErrorProvider _errProvider;
        private String _sysIdScheduleDetails;
        private String _sysIdStudent;
        #endregion

        #region Class Constructor

        public SubjectSchedule()
        {
            this.InitializeComponent();
        }

        public SubjectSchedule(CommonExchange.SysAccess userInfo, SubjectSchedulingLogic scheduleManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _scheduleManager = scheduleManager;

            _errProvider = new ErrorProvider();

            this.Load += new EventHandler(ClassLoad);
            this.cboYearSemester.SelectedIndexChanged += new EventHandler(cboYearSemesterSelectedIndexChanged);
            this.btnSearchSubject.Click += new EventHandler(btnSearchSubjectClick);
            this.txtFixedAmount.KeyPress += new KeyPressEventHandler(txtFixedAmountKeyPress);
            this.txtFixedAmount.Validating += new System.ComponentModel.CancelEventHandler(txtFixedAmountValidating);
            this.txtFixedAmount.Validated += new EventHandler(txtFixedAmountValidated);
            this.txtAdditionalSlots.KeyPress += new KeyPressEventHandler(txtAdditionalSlotsKeyPress);
            this.txtAdditionalSlots.Validating += new System.ComponentModel.CancelEventHandler(txtAdditionalSlotsValidating);
            this.txtAdditionalSlots.Validated += new EventHandler(txtAdditionalSlotsValidated);
            this.lnkAddDetails.Click += new EventHandler(lnkAddDetailsClick);
            this.lnkPrintList.Click += new EventHandler(lnkPrintListClick);
            this.chkIsTeamTeaching.CheckedChanged += new EventHandler(chkIsTeamTeachingCheckedChanged);
            this.chkFixedAmount.CheckedChanged += new EventHandler(chkFixedAmountCheckedChanged);
            this.chkIsIrregularModular.CheckedChanged += new EventHandler(chkIsIrregularModularCheckedChanged);
            this.dgvScheduleDetails.MouseDown += new MouseEventHandler(dgvScheduleDetailsMouseDown);
            this.dgvScheduleDetails.DoubleClick += new EventHandler(dgvScheduleDetailsDoubleClick);
            this.dgvStudentEnrolled.MouseDown += new MouseEventHandler(dgvStudentEnrolledMouseDown);
            this.dgvStudentEnrolled.DoubleClick += new EventHandler(dgvStudentEnrolledDoubleClick);
        }             
        #endregion

        #region Class Event Void Procedures
        //############################################CLASS SubjectSchedule EVENTS#######################################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            if (_scheduleManager.MustOpenSchoolYearSemester())
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Please open another school year / semester before creating a new subject schedule.",
                    "Error Creating A Subject Schedule");

                _hasErrors = true;

                this.Close();
            }

            _schedInfo = new CommonExchange.ScheduleInformation();

            this.cboYearSemester.Enabled = this.tabSchedule.Enabled = false;

            this.dgvMarkDeleted.DataSource = this.dgvScheduleDetails.DataSource = _scheduleManager.ScheduleDetailsTableFormat;
            RemoteClient.ProcStatic.SetDataGridViewColumns(dgvScheduleDetails, false);
            RemoteClient.ProcStatic.SetDataGridViewColumns(dgvMarkDeleted, false);

            _schedInfo.IsTeamTeaching = false;

            this.SetAddDetailsTeamTeachingControls();

            if (RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) ||
                RemoteServerLib.ProcStatic.IsSystemAccessOfficeUser(_userInfo))
            {
                this.txtAdditionalSlots.Visible = this.lblSlots.Visible = true;
            }
            else
            {
                this.txtAdditionalSlots.Visible = this.lblSlots.Visible = false;
            }
        }//---------------------------
        //############################################END CLASS SubjectSchedule EVENTS#######################################################

        //#############################################COMBOBOX cboYearSemester EVENTS#######################################################
        //event is raised when the selected index is changed
        protected void cboYearSemesterSelectedIndexChanged(object sender, EventArgs e)
        {
            if (_schedInfo.SubjectInfo.CourseGroupInfo.IsSemestral)
            {
                _schedInfo.SemesterInfo.SemesterSysId = _scheduleManager.GetYearSemesterId(_schedInfo.SubjectInfo.CourseGroupInfo.IsSemestral, 
                    ((ComboBox)sender).SelectedIndex);
            }
            else
            {
                _schedInfo.SchoolYearInfo.YearId = _scheduleManager.GetYearSemesterId(_schedInfo.SubjectInfo.CourseGroupInfo.IsSemestral, 
                    ((ComboBox)sender).SelectedIndex);
            }
        }//---------------------------
        //#############################################END COMBOBOX cboYearSemester EVENTS#################################################

        //##############################################BUTTON btnSearchSubject EVENTS####################################################
        //event is raised when the button is clicked
        private void btnSearchSubjectClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (SubjectSearchOnTextboxList frmSearch = new SubjectSearchOnTextboxList(_userInfo, _scheduleManager, 0))
                {
                    frmSearch.AdoptGridSize = true;
                    frmSearch.ShowDialog(this);

                    if (frmSearch.HasSelected)
                    {
                        CommonExchange.SubjectInformation subjectInfo = _scheduleManager.GetDetailsSubjectInformation(frmSearch.PrimaryId);

                        _schedInfo.SubjectInfo.SubjectSysId = subjectInfo.SubjectSysId;
                        _schedInfo.SubjectInfo.CourseGroupInfo.IsSemestral = subjectInfo.CourseGroupInfo.IsSemestral;
                        _schedInfo.SubjectInfo.DepartmentInfo.DepartmentName = subjectInfo.DepartmentInfo.DepartmentName;
                        _schedInfo.SubjectInfo.SubjectCode = subjectInfo.SubjectCode;
                        _schedInfo.SubjectInfo.DescriptiveTitle = subjectInfo.DescriptiveTitle;
                        _schedInfo.SubjectInfo.DepartmentInfo.DepartmentId = subjectInfo.DepartmentInfo.DepartmentId;
                        _schedInfo.SubjectInfo.LectureUnits = subjectInfo.LectureUnits;
                        _schedInfo.SubjectInfo.LabUnits = subjectInfo.LabUnits;
                        _schedInfo.SubjectInfo.NoHours = subjectInfo.NoHours;
                        
                        lblSysIdSubject.Text = subjectInfo.SubjectSysId;
                        lblSubjectCodeDescription.Text = subjectInfo.SubjectCode + " - " + subjectInfo.DescriptiveTitle;
                        lblSubjectDepartment.Text = subjectInfo.DepartmentInfo.DepartmentName;
                        lblUnitsLabHours.Text = _scheduleManager.GetSubjectUnitsHours(subjectInfo.LectureUnits, subjectInfo.LabUnits, subjectInfo.NoHours);

                        _scheduleManager.InitializeSchoolYearSemesterCombo(cboYearSemester, subjectInfo.CourseGroupInfo.IsSemestral);

                        this.cboYearSemester.Enabled = this.tabSchedule.Enabled = this.lnkAddDetails.Enabled = true;

                        this.btnSearchSubject.Visible = false;
                    }
                }

                this.lnkAddDetails.Focus();
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Subject Search Module");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//------------------------
        //##############################################END BUTTON btnSearchSubject EVENTS####################################################

        //##############################################TEXTBOX txtFixedAmount EVENTS#########################################################
        //event is raised when the textbox keypress
        private void txtFixedAmountKeyPress(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxAmountOnly(e);
        }//---------------------------

        //event is raised when the textbox is validating
        private void txtFixedAmountValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxValidateAmount((TextBox)sender);
        }//----------------------------

        //event is raised when the textbox is validated
        private void txtFixedAmountValidated(object sender, EventArgs e)
        {            
            Decimal amount;

            if (Decimal.TryParse(txtFixedAmount.Text, out amount) && _schedInfo.IsFixedAmount)
            {
                _schedInfo.Amount = amount;
            }
        }//----------------------------
        //##############################################END TEXTBOX txtFixedAmount EVENTS####################################################

        //##############################################TEXTBOX txtAdditionalSlots EVENTS#########################################################
        //event is raised when the textbox validated
        private void txtAdditionalSlotsValidated(object sender, EventArgs e)
        {
            Int16 slots;

            if (Int16.TryParse(this.txtAdditionalSlots.Text, out slots))
            {
                _schedInfo.AdditionalSlots = slots;
            }
        }//-------------------------

        //event is raised when the textbox is validating
        private void txtAdditionalSlotsValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxValidateInt16((TextBox)sender);
        }//-------------------------

        //event is raised when the textbox key is pressed
        private void txtAdditionalSlotsKeyPress(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxIntegersWithNegationOnly(e);
        }//-------------------------
        //##############################################END TEXTBOX txtAdditionalSlots EVENTS#########################################################

        //##############################################LINKLABEL lnkAddDetails EVENTS####################################################
        //event is raised when the link label is clicked
        private void lnkAddDetailsClick(object sender, EventArgs e)
        {
            try
            {               
                this.Cursor = Cursors.WaitCursor;

                using (SubjectScheduleDetailsCreate frmCreate = new SubjectScheduleDetailsCreate(_userInfo, _scheduleManager, _schedInfo))
                {
                    frmCreate.ShowDialog(this);
                   
                    if (frmCreate.HasCreated)
                    {
                        _hasUpdatedScheduleDetails = true;

                        Int32 detailsLoaded = 0;

                        this.dgvScheduleDetails.DataSource = _scheduleManager.GetBySysIdScheduleScheduleDetailsTable(_schedInfo.ScheduleSysId, 
                            false, ref detailsLoaded);
                        this.dgvMarkDeleted.DataSource = _scheduleManager.GetBySysIdScheduleScheduleDetailsTable(_schedInfo.ScheduleSysId, true, ref detailsLoaded);

                        this.SetAddDetailsTeamTeachingControls();

                        this.chkIsIrregularModular.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Subject Details Create Module");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//-------------------------------
        //##############################################END LINKLABEL lnkAddDetails EVENTS####################################################

        //##############################################LINKLABEL lnkPrintList EVENTS#########################################################
        //event is raised when the link label is clicked
        private void lnkPrintListClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;               

                _scheduleManager.PrintStudentEnrolledList(_userInfo, _schedInfo, this.cboYearSemester.Text,
                    _scheduleManager.GetBySysIdScheduleScheduleDetailsTable(_schedInfo.ScheduleSysId, _schedInfo.IsIrregularModular));
                
                this.Cursor = Cursors.Arrow;

            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Print Student Enrolled List.");
            }
        }//------------------------
        //##############################################END LINKLABEL lnkPrintList EVENTS####################################################

        //##############################################CHECKBOX chkFixedAmount EVENTS#######################################################
        //event is raised when the check box is clicked
        private void chkFixedAmountCheckedChanged(object sender, EventArgs e)
        {
            _schedInfo.IsFixedAmount = this.chkFixedAmount.Checked;

            if (_schedInfo.IsFixedAmount)
            {
                this.txtFixedAmount.Enabled = true;
                this.txtFixedAmount.Focus();
            }
            else
            {
                this.txtFixedAmount.Enabled = false;

                Decimal amount;

                if (Decimal.TryParse(txtFixedAmount.Text, out amount) && _schedInfo.IsFixedAmount)
                {
                    _schedInfo.Amount = amount;
                }

                this.txtFixedAmount.Text = _schedInfo.Amount.ToString("N");
            }
        }//--------------------------
        //##############################################END CHECKBOX chkFixedAmount EVENTS####################################################

        //##############################################CHECKBOX chkIsTeamTeaching EVENTS#####################################################
        //event is raised when the check box is clicked
        private void chkIsTeamTeachingCheckedChanged(object sender, EventArgs e)
        {
            _schedInfo.IsTeamTeaching = this.chkIsTeamTeaching.Checked;

            if (_schedInfo.IsTeamTeaching)
            {
                this.lnkAddDetails.Enabled = true;
            }
            else
            {
                this.SetAddDetailsTeamTeachingControls();
            }         
        }//------------------------------
        //##############################################END CHECKBOX chkIsTeamTeaching EVENTS#####################################################

        //##############################################CHECKBOX chkIsIrregularModular EVENTS#####################################################
        //event is raised when the check box is clicked
        protected virtual void chkIsIrregularModularCheckedChanged(object sender, EventArgs e)
        {
            if (this.chkIsIrregularModular.Checked)
            {
                String strMsg = "Marking the schedule as IRREGULAR/MODULAR changes the system's capability in " +
                    "handling schedule conflicts of the following module:\n\n" +
                    "\t1) Student Loading - the system CANNOT anymore determine a SUBJECT LOAD schedule conflict.\n" +
                    "\t2) Teacher Loading - the system CANNOT anymore determine a TEACHER LOAD schedule conflict.\n\n" +
                    "Are you sure you want to mark the schedule as IRREGULAR/MODULAR?";

                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Checked", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.Yes)
                {
                    _schedInfo.IsIrregularModular = this.chkIsIrregularModular.Checked;
                }
                else
                {
                    this.chkIsIrregularModular.CheckedChanged -= new EventHandler(chkIsIrregularModularCheckedChanged);

                    this.chkIsIrregularModular.Checked = _schedInfo.IsIrregularModular = false;

                    this.chkIsIrregularModular.CheckedChanged -= new EventHandler(chkIsIrregularModularCheckedChanged);
                    this.chkIsIrregularModular.CheckedChanged += new EventHandler(chkIsIrregularModularCheckedChanged);
                }
            }
            else
            {
                _schedInfo.IsIrregularModular = false;
            }
        }//-----------------------------
        //##############################################END CHECKBOX chkIsIrregularModular EVENTS#####################################################

        //##############################################DATAGRIDVIEW dgvScheduleDetails EVENTS####################################################
        //event is raised when dvbScheduleDetails MouseDown
        private void dgvScheduleDetailsMouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitTest = dgvScheduleDetails.HitTest(e.X, e.Y);

            Int32 rowIndex = -1;

            switch (hitTest.Type)
            {
                case DataGridViewHitTestType.Cell:
                    rowIndex = hitTest.RowIndex;
                    break;
                case DataGridViewHitTestType.RowHeader:
                    rowIndex = hitTest.RowIndex;
                    break;
                default:
                    rowIndex = -1;
                    _sysIdScheduleDetails = "";
                    break;
            }

            if (rowIndex != -1)
            {
                _sysIdScheduleDetails = dgvScheduleDetails[0, rowIndex].Value.ToString();
            }            
        }//----------------------------

        //this event is raised when dgvscheduleDetails is double clicked
        private void dgvScheduleDetailsDoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!String.IsNullOrEmpty(_sysIdScheduleDetails))
                {
                    using (SubjectScheduleDetailsUpdate frmUpdate = new SubjectScheduleDetailsUpdate(_userInfo, _scheduleManager, _schedInfo,
                        _scheduleManager.GetDetailsScheduleInformationDetails(_sysIdScheduleDetails)))
                    {
                        frmUpdate.ShowDialog(this);

                        if (frmUpdate.HasUpdated || frmUpdate.HasDeleted)
                        {
                            _hasUpdatedScheduleDetails = true;

                            Int32 detailsLoaded = 0;

                            this.dgvScheduleDetails.DataSource = _scheduleManager.GetBySysIdScheduleScheduleDetailsTable(_schedInfo.ScheduleSysId, 
                                false, ref detailsLoaded);
                            this.dgvMarkDeleted.DataSource = _scheduleManager.GetBySysIdScheduleScheduleDetailsTable(_schedInfo.ScheduleSysId, 
                                true, ref detailsLoaded);

                            if (frmUpdate.HasDeleted && !_scheduleManager.HasValidCountOfScheduleDetails(_schedInfo.ScheduleSysId, _schedInfo.IsTeamTeaching))
                            {
                                this.chkIsTeamTeaching.Enabled = true;

                                if (dgvScheduleDetails.Rows.Count > 0 && _schedInfo.IsIrregularModular)
                                {
                                    this.chkIsIrregularModular.Enabled = false;
                                }
                                else if (dgvScheduleDetails.Rows.Count <= 0)
                                {
                                    this.chkIsIrregularModular.Enabled = this.lnkAddDetails.Enabled = true;
                                }
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Subject Schedule Details Module");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }            
        }//--------------------------
        //##############################################END DATAGRIDVIEW dtgScheduleDetails EVENTS####################################################

        //##############################################DATAGRIDVIEW dgvStudentEnrolled EVENTS########################################################
        //event is raised when dvbScheduleDetails MouseDown
        private void dgvStudentEnrolledMouseDown(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitTest = dgvStudentEnrolled.HitTest(e.X, e.Y);

            Int32 rowIndex = -1;

            switch (hitTest.Type)
            {
                case DataGridViewHitTestType.Cell:
                    rowIndex = hitTest.RowIndex;
                    break;
                case DataGridViewHitTestType.RowHeader:
                    rowIndex = hitTest.RowIndex;
                    break;
                default:
                    rowIndex = -1;
                    _sysIdScheduleDetails = "";
                    break;
            }

            if (rowIndex != -1)
            {
                _sysIdStudent = dgvStudentEnrolled[0, rowIndex].Value.ToString();
            }
        }//------------------------

        //event is raised when the control is double clicked
        private void dgvStudentEnrolledDoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                StudentLoadingLogic studentManager = new StudentLoadingLogic(_userInfo);

                studentManager.GetSearchedStudentInformation(_userInfo, _sysIdStudent, String.Empty, String.Empty, String.Empty, String.Empty);

                using (StudentLoading frmShow = new StudentLoading(_userInfo,
                    _scheduleManager.GetDetailsStudentInformation(_userInfo, _sysIdStudent, Application.StartupPath), studentManager))
                {                  
                    frmShow.ShowDialog(this);

                    _scheduleManager.SelectBySysIDScheduleListStudentLoad(_userInfo, _schedInfo.ScheduleSysId);

                    this.dgvStudentEnrolled.DataSource = _scheduleManager.GetStudentEnrolled(true);
                    this.dgvStudentWithdrawn.DataSource = _scheduleManager.GetStudentEnrolled(false);

                    this.tblStudentEnrolled.Text = "Student Enrolled  (" + this.dgvStudentEnrolled.Rows.Count.ToString() + ")";
                    this.tblStudentWithdrawn.Text = "Student Withdrawn  (" + this.dgvStudentWithdrawn.Rows.Count.ToString() + ")";
                }
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Student Loading Mudule.", "Error Loading");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//------------------------
        //##############################################END DATAGRIDVIEW dgvStudentEnrolled EVENTS####################################################
        #endregion

        #region Programer-Defined Void Procedures
        //this procedure will SetAddDetailsTeamTeachingControls
        protected void SetAddDetailsTeamTeachingControls()
        {
            if (!_scheduleManager.HasValidCountOfScheduleDetails(_schedInfo.ScheduleSysId, _schedInfo.IsTeamTeaching))
            {
                if (!_schedInfo.IsTeamTeaching)
                {
                    this.lnkAddDetails.Enabled = false;
                }
                else
                {
                    this.lnkAddDetails.Enabled = true;
                }
            }
            else if (_schedInfo.IsTeamTeaching)
            {
                this.chkIsTeamTeaching.Enabled = false;
            }
            else
            {
                this.lnkAddDetails.Enabled = false;
                this.chkIsTeamTeaching.Enabled = true;
            }
         
        }//--------------------
        #endregion

        #region Programer-Defined Funtions
        //this function determines if the controls are validated
        protected Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.cboYearSemester, "");
            _errProvider.SetError(this.btnSearchSubject, "");
            _errProvider.SetError(this.lnkAddDetails, "");
            _errProvider.SetError(this.chkIsTeamTeaching, "");
            
            if (cboYearSemester.SelectedIndex == -1)
            {
                _errProvider.SetIconAlignment(this.cboYearSemester, ErrorIconAlignment.MiddleRight);
                _errProvider.SetError(this.cboYearSemester, "Please select a school year / semester the schedule information is enrolled.");
                isValid = false;
            }

            if (String.IsNullOrEmpty(_schedInfo.SubjectInfo.SubjectSysId))
            {
                _errProvider.SetIconAlignment(this.btnSearchSubject, ErrorIconAlignment.MiddleLeft);
                _errProvider.SetError(this.btnSearchSubject, "Please select a subject for the schedule information.");
                isValid = false;
            }

            if (!_scheduleManager.HasValidCountOfScheduleDetails(_schedInfo.ScheduleSysId, _schedInfo.IsTeamTeaching))
            {
                if (_schedInfo.IsTeamTeaching)
                {
                    _errProvider.SetIconAlignment(this.chkIsTeamTeaching, ErrorIconAlignment.MiddleRight);
                    _errProvider.SetError(this.chkIsTeamTeaching, "Not a valid team teaching schedule.");
                }
                else
                {
                    _errProvider.SetIconAlignment(this.lnkAddDetails, ErrorIconAlignment.MiddleLeft);
                    _errProvider.SetError(this.lnkAddDetails, "There must be at least one schedule details.");
                }
                isValid = false;

                this.tabSchedule.SelectedIndex = 0;
            }

            return isValid;
        } //------------------------
        #endregion

    }
}
