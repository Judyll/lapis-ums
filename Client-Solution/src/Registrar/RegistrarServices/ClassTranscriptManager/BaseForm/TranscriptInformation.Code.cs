using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RegistrarServices
{
    partial class TranscriptInformation :  IDisposable
    {
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private TranscriptLogic _transcriptManager;
        private OfficeServices.StudentLoadingLogic _studentManager;

        private CommonExchange.TranscriptInformation _transcripInfo;
        private CommonExchange.TranscriptInformation _tempTranscriptInfo;
        private CommonExchange.Student _studentInfo;

        private DataTable _transcriptDetailsTable;

        private CommonExchange.StudentEnrolmentLevel _enrolmentLevelInfo;

        private Int32 _rowIndex = -1;

        private String _dateStart = String.Empty;
        private String _dateEnd = String.Empty;
        private String _enrolmentCourseSysId = String.Empty;
        private String _enrolmentLevelSysId = String.Empty;

        private Boolean _isCheacked = false;
        private Boolean _hasModified = false;

        private ListView _copySubjectListView;

        private ErrorProvider _errProvider;

        private const Int32 c_OneRow = 1;
        private const Int32 c_TenRow = 10;
        #endregion

        #region Class Constructor and Distructors
        public TranscriptInformation()
        {
            this.InitializeComponent();
        }

        public TranscriptInformation(CommonExchange.SysAccess userInfo, TranscriptLogic transcriptManager,
            DataTable transcriptDetailsTable, CommonExchange.TranscriptInformation transcriptInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _transcriptManager = transcriptManager;

            _transcriptDetailsTable = transcriptDetailsTable;

            _transcripInfo = transcriptInfo;
            _tempTranscriptInfo = (CommonExchange.TranscriptInformation)_transcripInfo.Clone();

            _errProvider = new ErrorProvider();

            this.Load += new EventHandler(ClassLoad);
            this.FormClosing += new FormClosingEventHandler(ClassClossing);
            this.txtStudentId.Validated += new EventHandler(txtStudentIdValidated);
            this.txtLastName.Validated += new EventHandler(txtLastNameValidated);
            this.txtFirstName.Validated += new EventHandler(txtFirstNameValidated);
            this.txtMiddleName.Validated += new EventHandler(txtMiddleNameValidated);
            this.txtLastName.Validating += new System.ComponentModel.CancelEventHandler(txtNameValidating);
            this.txtFirstName.Validating += new System.ComponentModel.CancelEventHandler(txtNameValidating);
            this.txtMiddleName.Validating += new System.ComponentModel.CancelEventHandler(txtNameValidating);
            this.txtCourseTitle.Validated += new EventHandler(txtCourseTitleValidated);
            this.txtDepartmentName.Validated += new EventHandler(txtDepartmentNameValidated);
            this.txtEntranceData.Validated += new EventHandler(txtEntranceDataValidated);
            this.txtRecordOfGraduation.Validated += new EventHandler(txtRecordOfGraduationValidated);
            this.txtPursposeOfRequest.Validated += new EventHandler(txtPursposeOfRequestValidated);
            this.dgvList.MouseDown += new MouseEventHandler(dgvListMouseDown);
            this.lblAddRowAfter.Click += new EventHandler(lblAddRowAfterClick);
            this.lblAddRowBefore.Click += new EventHandler(lblAddRowBeforeClick);
            this.lblAddTenRowsAfter.Click += new EventHandler(lblAddTenRowsAfterClick);
            this.lblAddTenRowsBefore.Click += new EventHandler(lblAddTenRowsBeforeClick);
            this.lblAddBreakPointAfter.Click += new EventHandler(lblAddBreakPointAfterClick);
            this.lblAddBreakPointBefore.Click += new EventHandler(lblAddBreakPointBeforeClick);
            this.lblDeleteRow.Click += new EventHandler(lblDeleteRowClick);
            this.lblDeleteSelectedRows.Click += new EventHandler(lblDeleteSelectedRowsClick);
            this.lblInsertEnrolmentInformation.Click += new EventHandler(lblInsertEnrolmentInformationClick);
            this.lblCutDetails.Click += new EventHandler(lblCutDetailsClick);
            this.lblPasteDetails.Click += new EventHandler(lblPasteDetailsClick);
            this.lblCopyTranscriptDetails.Click += new EventHandler(lblCopyTranscriptDetailsClick);
            this.lblPasteTranscriptDetails.Click += new EventHandler(lblPasteTranscriptDetailsClick);
            this.btnSearchStudent.Click += new EventHandler(btnSearchStudentClick);
            this.cboYear.SelectedIndexChanged += new EventHandler(cboYearSelectedIndexChanged);
            this.cboSemester.SelectedIndexChanged += new EventHandler(cboSemesterSelectedIndexChanged);
            this.lsvSubjectLoad.ColumnClick += new ColumnClickEventHandler(lsvSubjectLoadColumnClick);
            this.lsvWithdrawnSubjects.ColumnClick += new ColumnClickEventHandler(lsvSubjectLoadColumnClick);
            this.lsvSpecialClass.ColumnClick += new ColumnClickEventHandler(lsvSubjectLoadColumnClick);
            this.lsvWithdrawnSpecialClass.ColumnClick += new ColumnClickEventHandler(lsvSubjectLoadColumnClick);
            this.lsvSubjectLoad.ItemChecked += new ItemCheckedEventHandler(lsvSubjectLoadItemChecked);
            this.lsvWithdrawnSubjects.ItemChecked += new ItemCheckedEventHandler(lsvSubjectLoadItemChecked);
            this.lsvSpecialClass.ItemChecked += new ItemCheckedEventHandler(lsvSubjectLoadItemChecked);
            this.lsvWithdrawnSpecialClass.ItemChecked += new ItemCheckedEventHandler(lsvSubjectLoadItemChecked);
            this.tabStudentSubject.SelectedIndexChanged += new EventHandler(tabStudentSubjectSelectedIndexChanged);
            this.btnCopySelectedSubject.Click += new EventHandler(btnCopySelectedSubjectLoadClick);
            this.btnEnrolmentHistory.Click += new EventHandler(btnEnrolmentHistoryClick);
            this.pbxStudent.Click += new EventHandler(pbxStudentClick);
            this.btnRecord.Click += new EventHandler(btnRecordClick);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnPrint.Click += new EventHandler(btnPrintClick);
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
        //####################################CLASS Transcript EVENTS####################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            _studentManager = new OfficeServices.StudentLoadingLogic(_userInfo);
            _studentInfo = new CommonExchange.Student();

            _copySubjectListView = new ListView();

            _enrolmentLevelInfo = new CommonExchange.StudentEnrolmentLevel();            

            this.dgvList.DataSource = _transcriptDetailsTable;

            if (_transcriptDetailsTable.Rows.Count <= 1)
            {
                this.btnPrint.Enabled = false;

                this.txtStudentId.Focus();
            }
       
            RemoteClient.ProcStatic.SetDataGridViewColumns(dgvList, false);

            this.dgvList.ReadOnly = false;
            this.dgvList.MultiSelect = true;

            this.dgvList.Columns["sequence_no"].ReadOnly = true;
            this.dgvList.Columns["transcript_id"].ReadOnly = true;
            this.dgvList.Columns["sysid_schedule_no_freeze"].ReadOnly = true;

            _studentInfo = _transcriptManager.SelectByStudentIDStudentInformation(_userInfo, _transcripInfo.StudentId);

            this.InitializeStudentInformationControls(false);

            _studentManager.InitializeSchoolYearCombo(this.cboYear);

            this.lblPasteTranscriptDetails.Enabled = _transcriptManager.HasCopiedTranscriptDetails();
        }//----------------------------

        //event is raised when the class is clossing
        private void ClassClossing(object sender, FormClosingEventArgs e)
        {
            if (String.IsNullOrEmpty(_transcripInfo.TranscriptSysId))
            {
                String strMsg = "Are you sure you want to cancel the creation of a new transcript information?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            else if (!String.IsNullOrEmpty(_transcripInfo.TranscriptSysId) && (!_tempTranscriptInfo.Equals(_transcripInfo) || _hasModified))
            {
                String strMsg = "There has been changes made in the current transcript information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//--------------------------------
        //####################################End CLASS Transcript EVENTS####################################

        //##################################TEXTBOX txtStudentId EVENTS##########################################################
        //event is raised when the control is validated
        protected virtual void txtStudentIdValidated(object sender, EventArgs e)
        {
            _transcripInfo.StudentId = RemoteClient.ProcStatic.TrimStartEndString(this.txtStudentId.Text);

            if (String.IsNullOrEmpty(_studentInfo.StudentId) || !String.Equals(_studentInfo.StudentId, _transcripInfo.StudentId))
            {
                this.Cursor = Cursors.WaitCursor;

                _studentInfo = _transcriptManager.SelectByStudentIDStudentInformation(_userInfo, _transcripInfo.StudentId);               

                if (!String.IsNullOrEmpty(_studentInfo.StudentId))
                {
                    this.InitializeStudentInformationControls(false);
                }

                this.Cursor = Cursors.Arrow;
            }

            this.btnPrint.Enabled = false;
        }//-----------------------
        //##################################END TEXTBOX txtStudentId EVENTS##########################################################

        //##################################TEXTBOX txtLastName EVENTS##########################################################
        //event is raised when the control is validated
        private void txtLastNameValidated(object sender, EventArgs e)
        {
            _transcripInfo.LastName = RemoteClient.ProcStatic.TrimStartEndString(this.txtLastName.Text);

            this.btnPrint.Enabled = false;
        }//---------------------
        //##################################END TEXTBOX txtLastName EVENTS##########################################################

        //##################################TEXTBOX txtFirstName EVENTS##########################################################
        //event is raised when the control is validated
        private void txtFirstNameValidated(object sender, EventArgs e)
        {
            _transcripInfo.FirstName = RemoteClient.ProcStatic.TrimStartEndString(this.txtFirstName.Text);

            this.btnPrint.Enabled = false;
        }//--------------------
        //##################################END TEXTBOX txtFirstName EVENTS##########################################################

        //##################################TEXTBOX txtMiddleName EVENTS##########################################################
        //event is raised when the control is validated
        private void txtMiddleNameValidated(object sender, EventArgs e)
        {
            _transcripInfo.MiddleName = RemoteClient.ProcStatic.TrimStartEndString(this.txtMiddleName.Text);

            this.btnPrint.Enabled = false;
        }//--------------------
        //##################################END TEXTBOX txtMiddleName EVENTS##########################################################

        //##################################TEXTBOX txtNameValidating EVENTS##########################################################
        //event is raised when the control is validated
        private void txtNameValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            TextBox txtBase = (TextBox)sender;

            txtBase.Text = this.SetFirstLetterToUpper(txtBase.Text);
        }//----------------------
        //##################################END TEXTBOX txtNameValidating EVENTS##########################################################

        //##################################TEXTBOX txtCourseTitle EVENTS##########################################################
        //event is raised when the control is validated
        private void txtCourseTitleValidated(object sender, EventArgs e)
        {
            _transcripInfo.CourseTitle = RemoteClient.ProcStatic.TrimStartEndString(this.txtCourseTitle.Text);

            this.btnPrint.Enabled = false;
        }//-------------------
        //##################################END TEXTBOX txtCourseTitle EVENTS##########################################################

        //##################################TEXTBOX txtDepartmentName EVENTS##########################################################
        //event is raised when the control is validated
        private void txtDepartmentNameValidated(object sender, EventArgs e)
        {
            _transcripInfo.DepartmentName = RemoteClient.ProcStatic.TrimStartEndString(this.txtDepartmentName.Text);

            this.btnPrint.Enabled = false;
        }//--------------------
        //##################################END TEXTBOX txtDepartmentName EVENTS##########################################################

        //##################################TEXTBOX txtEntranceData EVENTS##########################################################
        //event is raised when the control is validated
        private void txtEntranceDataValidated(object sender, EventArgs e)
        {
            _transcripInfo.EntranceData = RemoteClient.ProcStatic.TrimStartEndString(this.txtEntranceData.Text);

            this.btnPrint.Enabled = false;
        }//------------------
        //##################################END TEXTBOX txtEntranceData EVENTS##########################################################

        //##################################TEXTBOX txtGraduationRecord EVENTS##########################################################
        //event is raised when the control is validated
        private void txtRecordOfGraduationValidated(object sender, EventArgs e)
        {
            _transcripInfo.RecordsOfGraduation = RemoteClient.ProcStatic.TrimStartEndString(this.txtRecordOfGraduation.Text);

            this.btnPrint.Enabled = false;
        }//------------------
        //##################################END TEXTBOX txtGraduationRecord EVENTS##########################################################

        //##################################TEXTBOX txtPursposeOfRequest EVENTS##########################################################
        //event is raised when the control is validated
        private void txtPursposeOfRequestValidated(object sender, EventArgs e)
        {
            _transcripInfo.PurposeOfRequest = RemoteClient.ProcStatic.TrimStartEndString(this.txtPursposeOfRequest.Text);

            this.btnPrint.Enabled = false;
        }//------------------------
        //##################################END TEXTBOX txtPursposeOfRequest EVENTS##########################################################

        //##################################DATAGRIDVIEW dgvList EVENTS##########################################################
        //event is raised when the mouse is down
        private void dgvListMouseDown(object sender, MouseEventArgs e)
        {
            //this.dgvList.Focus();

            DataGridView.HitTestInfo hitTest = this.dgvList.HitTest(e.X, e.Y);

            switch (hitTest.Type)
            {
                case DataGridViewHitTestType.RowHeader:
                    _rowIndex = hitTest.RowIndex;
                    this.dgvList.ContextMenuStrip = lnkCutDetails;
                    this.dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    this.dgvList.Rows[hitTest.RowIndex].Selected = true;
                    break;
                case DataGridViewHitTestType.Cell:
                    this.dgvList.ContextMenuStrip = null;
                    this.dgvList.SelectionMode = DataGridViewSelectionMode.CellSelect;
                    break;                
                default:
                    _rowIndex = -1;
                    this.dgvList.ContextMenuStrip = null;
                    break;
            }

            this.lblDeleteRow.Enabled = this.dgvList.Rows.Count <= 1 ? false : true;

            this.lblCutDetails.Enabled = this.dgvList.Rows.Count == 1 ? false : true;
        }//---------------------
        //##################################END DATAGRIDVIEW dgvList EVENTS##########################################################

        //##################################LABEL lblAddRowBefore EVENTS##########################################################
        //event is raised when the control is clicked
        private void lblAddRowBeforeClick(object sender, EventArgs e)
        {
            if (_rowIndex != -1)
            {
                Int32 addedRow = 0;

                this.dgvList[9, _rowIndex].Selected = true;

                this.dgvList.DataSource = _transcriptManager.AddRowBreakPointBeforeOrAfter((DataTable)this.dgvList.DataSource, _rowIndex,
                    (Int16)this.dgvList["sequence_no", _rowIndex].Value, c_OneRow, true, false, ref addedRow);

                this.dgvList.Rows[addedRow].Selected = true;
                this.dgvList[0, addedRow].Selected = true;

                this.btnPrint.Enabled = false;

                _hasModified = true;
            }
        }//-----------------------
        //##################################END LABEL lblAddRowBefore EVENTS##########################################################

        //##################################LABEL lblAddRowAfter EVENTS##########################################################
        //event is raised when the control is clicked
        private void lblAddRowAfterClick(object sender, EventArgs e)
        {
            if (_rowIndex != -1)
            {
                Int32 addedRow = 0;

                this.dgvList[9, _rowIndex].Selected = true;

                this.dgvList.DataSource = _transcriptManager.AddRowBreakPointBeforeOrAfter((DataTable)this.dgvList.DataSource, _rowIndex, 
                    (Int16)this.dgvList["sequence_no", _rowIndex].Value, c_OneRow, false, false, ref addedRow);

                this.dgvList.Rows[addedRow].Selected = true;
                this.dgvList[0, addedRow].Selected = true;

                this.btnPrint.Enabled = false;

                _hasModified = true;
            }
        }//--------------
        //##################################END LABEL lblAddRowAfter EVENTS##########################################################

        //##################################LABEL lblAddTenRowBefore EVENTS##########################################################
        //event is raised when the control is clicked
        private void lblAddTenRowsBeforeClick(object sender, EventArgs e)
        {
            if (_rowIndex != -1)
            {
                Int32 addedRow = 0;

                this.dgvList[9, _rowIndex].Selected = true;

                this.dgvList.DataSource = _transcriptManager.AddRowBreakPointBeforeOrAfter((DataTable)this.dgvList.DataSource, _rowIndex,
                    (Int16)this.dgvList["sequence_no", _rowIndex].Value, c_TenRow, true, false, ref addedRow);

                this.dgvList.Rows[addedRow].Selected = true;
                this.dgvList[0, addedRow].Selected = true;

                this.btnPrint.Enabled = false;

                _hasModified = true;
            }
        }//---------------------------------
        //##################################END LABEL lblAddTenRowBefore EVENTS##########################################################

        //##################################LABEL lblAddTenRowAfter EVENTS##########################################################
        //event is raised when the control is clicked
        private void lblAddTenRowsAfterClick(object sender, EventArgs e)
        {
            if (_rowIndex != -1)
            {
                Int32 addedRow = 0;

                this.dgvList[9, _rowIndex].Selected = true;

                this.dgvList.DataSource = _transcriptManager.AddRowBreakPointBeforeOrAfter((DataTable)this.dgvList.DataSource, _rowIndex,
                    (Int16)this.dgvList["sequence_no", _rowIndex].Value, c_TenRow, false, false, ref addedRow);

                this.dgvList.Rows[addedRow].Selected = true;
                this.dgvList[0, addedRow].Selected = true;

                this.btnPrint.Enabled = false;

                _hasModified = true;
            }
        }//------------------------------
        //##################################END LABEL lblAddTenRowAfter EVENTS##########################################################

        //##################################LABEL lblAddBreakPointBefore EVENTS##########################################################
        //event is raised when the control is clicked
        private void lblAddBreakPointBeforeClick(object sender, EventArgs e)
        {
            if (_rowIndex != -1)
            {
                Int32 addedRow = 0;

                this.dgvList[9, _rowIndex].Selected = true;

                this.dgvList.DataSource = _transcriptManager.AddRowBreakPointBeforeOrAfter((DataTable)this.dgvList.DataSource, _rowIndex,
                    (Int16)this.dgvList["sequence_no", _rowIndex].Value, c_OneRow, true, true, ref addedRow);

                this.dgvList.Rows[addedRow].Selected = true;
                this.dgvList[0, addedRow].Selected = true;

                this.btnPrint.Enabled = false;

                _hasModified = true;
            }
        }//------------------------
        //##################################END LABEL lblAddBreakPointBefore EVENTS##########################################################

        //##################################LABEL lblAddBreakPointAfter EVENTS##########################################################
        //event is raised when the control is clicked
        private void lblAddBreakPointAfterClick(object sender, EventArgs e)
        {
            if (_rowIndex != -1)
            {
                Int32 addedRow = 0;

                this.dgvList[9, _rowIndex].Selected = true;

                this.dgvList.DataSource = _transcriptManager.AddRowBreakPointBeforeOrAfter((DataTable)this.dgvList.DataSource, _rowIndex,
                    (Int16)this.dgvList["sequence_no", _rowIndex].Value, c_OneRow, false, true, ref addedRow);

                this.dgvList.Rows[addedRow].Selected = true;
                this.dgvList[0, addedRow].Selected = true;

                this.btnPrint.Enabled = false;

                _hasModified = true;
            }
        }//----------------------
        //##################################END LABEL lblAddBreakPointAfter EVENTS##########################################################

        //##################################LABEL lblDeleteRow EVENTS##########################################################
        //event is raised when the control is clicked
        private void lblDeleteRowClick(object sender, EventArgs e)
        {
            if (_rowIndex != -1)
            {
                this.dgvList.DataSource = _transcriptManager.DeleteRow((DataTable)this.dgvList.DataSource, (Int16)this.dgvList["sequence_no", _rowIndex].Value);

                if (_rowIndex > this.dgvList.Rows.Count)
                {
                    this.dgvList.Rows[_rowIndex].Selected = true;
                    this.dgvList[0, _rowIndex].Selected = true;
                }

                this.btnPrint.Enabled = false;

                _hasModified = true;
            }
        }//-----------------------
        //##################################END LABEL lblDeleteRow EVENTS##########################################################

        //##################################LABEL lblDeleteSelectedRows EVENTS##########################################################
        //event is raised when the control is clicked
        private void lblDeleteSelectedRowsClick(object sender, EventArgs e)
        {
            if (_rowIndex != -1)
            {
                this.dgvList.DataSource = _transcriptManager.DeleteSelectedRowsTranscriptDetails(this.dgvList);

                if (this.dgvList.Rows.Count == 0)
                {
                    Int32 addedRow = 0;

                    this.dgvList.DataSource = _transcriptManager.AddRowBreakPointBeforeOrAfter((DataTable)this.dgvList.DataSource, 0, 0, c_OneRow, true, false, ref addedRow);

                    this.btnPrint.Enabled = false;

                    _hasModified = true;
                }

                this.btnPrint.Enabled = false;

                _hasModified = true;
            }
        }//------------------------
        //##################################END LABEL lblDeleteSelectedRows EVENTS##########################################################

        //##################################LABEL lblInsertEnrolmentInformation EVENTS##########################################################
        //event is raised when the control is clicked
        private void lblInsertEnrolmentInformationClick(object sender, EventArgs e)
        {
            if (_rowIndex != -1)
            {
                this.dgvList.DataSource = _transcriptManager.AddRowsFormStudentLoadTable((DataTable)this.dgvList.DataSource, 
                    _rowIndex, (Int16)this.dgvList["sequence_no", _rowIndex].Value);

                this.lblInsertEnrolmentInformation.Enabled = false;

                this.tabTranscript.SelectedIndex = 0;

                this.dgvList.Rows[_rowIndex].Selected = true;
                this.dgvList[0, _rowIndex].Selected = true;

                this.btnPrint.Enabled = false;

                _hasModified = true;
            }
        }//----------------------
        //##################################END LABEL lblInsertEnrolmentInformation EVENTS##########################################################

        //##################################LABEL lblPasteDetails EVENTS##########################################################
        //event is raised when the control is clicked
        private void lblPasteDetailsClick(object sender, EventArgs e)
        {
            Int32 rowStartPaste = 0;

            this.dgvList.DataSource = _transcriptManager.PasteToStudentTranscriptDetails((DataTable)this.dgvList.DataSource,
                _rowIndex, (Int16)this.dgvList["sequence_no", _rowIndex].Value, ref rowStartPaste);

            this.dgvList.ClearSelection();

            this.dgvList.Rows[_rowIndex].Selected = true;

            this.btnRecord.Enabled = true;

            this.lblPasteDetails.Enabled = false;
            this.lblCutDetails.Enabled = true;

            _hasModified = true;
        }//---------------------
        //##################################END LABEL lblPasteDetails EVENTS##########################################################

        //##################################LABEL lblCutDetails EVENTS##########################################################
        //event is raised when the control is clicked
        private void lblCutDetailsClick(object sender, EventArgs e)
        {
            this.dgvList.DataSource = _transcriptManager.CutStudentTranscriptDetails(this.dgvList);

            this.btnRecord.Enabled = false;

            this.lblPasteDetails.Enabled = true;
            this.lblCutDetails.Enabled = false;

            _hasModified = true;
        }//-----------------------
        //##################################END LABEL lblCutDetails EVENTS##########################################################

        //##################################LABEL lblCopyTranscriptDetails EVENTS##########################################################
        //event is raised when the control is clicked
        private void lblCopyTranscriptDetailsClick(object sender, EventArgs e)
        {
            _transcriptManager.SetCopyTranscriptDetails(this.dgvList);
        }//-------------------------
        //##################################END LABEL lblCopyTranscriptDetails EVENTS##########################################################

        //##################################LABEL lblPasteTranscriptDetails EVENTS##########################################################
        //event is raised when the control is clicked
        private void lblPasteTranscriptDetailsClick(object sender, EventArgs e)
        {
            Int32 rowStartPaste = 0;

            this.dgvList.DataSource = _transcriptManager.PasteCopiedTranscriptDetails((DataTable)this.dgvList.DataSource,
                _rowIndex, (Int16)this.dgvList["sequence_no", _rowIndex].Value, ref rowStartPaste);

            this.dgvList.ClearSelection();

            this.dgvList.Rows[_rowIndex].Selected = true;

            this.btnRecord.Enabled = true;

            _hasModified = true;
        }//-------------------------
        //##################################END LABEL lblPasteTranscriptDetails EVENTS##########################################################

        //##################################BUTTON btnStudentSearch EVENTS##########################################################
        //event is raised when the control is clicked
        private void btnSearchStudentClick(object sender, EventArgs e)
        {
            OfficeServices.ScholarshipLogic scholarshipManager = new OfficeServices.ScholarshipLogic(_userInfo);

            using (OfficeServices.StudentSearch frmSearch = new OfficeServices.StudentSearch(_userInfo, scholarshipManager, true, true))
            {
                frmSearch.ShowDialog(this);

                if (frmSearch.HasSelected)
                {
                    if (this.pbxStudent.Image != null)
                    {
                        this.pbxStudent.Image.Dispose();
                        this.pbxStudent.Image = null;
                    }

                    GC.SuppressFinalize(this);
                    GC.Collect();

                    _studentInfo = scholarshipManager.GetDetailsStudentInformation(_userInfo, frmSearch.PrimaryId, Application.StartupPath, true);

                    this.InitializeStudentInformationControls(true);

                    _studentManager.InitializeSchoolYearCombo(this.cboYear);

                    this.btnPrint.Enabled = false;
                }
            }          
        }//--------------------
        //##################################END BUTTON btnStudentSearch EVENTS##########################################################

        //##################################COMBOBOX cboYear EVENTS##########################################################
        //event is raised when the selected index is changed
        private void cboYearSelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            _dateStart = _studentManager.GetSchoolYearDateStart(_studentManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)).ToShortDateString() +
                " 12:00:00 AM";
            _dateEnd = _studentManager.GetSchoolYearDateEnd(_studentManager.GetSchoolYearYearId(this.cboYear.SelectedIndex)).ToShortDateString() + 
                " 11:59:59 PM";

            DataTable tempTable = _studentManager.StudentLoadtable;

            tempTable.Rows.Clear();

            _studentManager.StudentLoadtable = tempTable;

            _studentManager.InitializeSemesterCombo(this.cboSemester, this.cboYear.SelectedIndex);

            if (!String.IsNullOrEmpty(_studentInfo.StudentSysId))
            {
                _studentManager.SelectBySysIDStudentDateStartEndStudentEnrolmentCourse(_userInfo, _studentInfo.StudentSysId, _dateStart, _dateEnd);

                if (_studentManager.IsSemestral())
                {
                    this.cboSemester.Enabled = true;
                }
                else
                {
                    _studentManager.InitializedCourseTextBox(this.txtCourse, String.Empty, false, ref _enrolmentCourseSysId);

                    if (!String.IsNullOrEmpty(_studentInfo.StudentId))
                    {
                        _studentManager.SelectBySysIDStudentYearIDSemesterStudentEnrolmentLevel(_userInfo, _studentInfo.StudentSysId,
                            _studentManager.GetSchoolYearYearId(this.cboYear.SelectedIndex), String.Empty, _enrolmentCourseSysId, String.Empty);

                        _studentManager.SelectBySysIDStudentListDateStartEndSpecialClassInformation(_userInfo, _studentInfo.StudentSysId, _dateStart, _dateEnd);
                    }

                    _studentManager.InitializedYearLevelTextBox(this.txtLevel, ref _enrolmentLevelSysId);

                    _enrolmentLevelInfo = _studentManager.GetStudentEnrolmentLevelInfo(_enrolmentLevelSysId);

                    Boolean isEnrolled = !String.IsNullOrEmpty(this.txtLevel.Text) ? true : false;

                    if (!String.IsNullOrEmpty(_studentInfo.StudentSysId))
                    {
                        _studentManager.SelectBySysIDEnrolmentLevelDateStartEndSubjectScheduleStudentLoad(_userInfo, _studentInfo.StudentSysId,
                            _enrolmentLevelInfo.EnrolmentLevelSysId, _enrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId,
                            _studentManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex),
                            _enrolmentLevelInfo.IsGraduateStudent, _enrolmentLevelInfo.IsInternational, true, isEnrolled, _dateStart, _dateEnd);
                    }

                    _studentManager.InitializeSubjectLoadListViewTranscript(this.lsvSubjectLoad, this.lblTotal, tblSubjectLoad);
                    _studentManager.InitializeWithdrawSubjectLoadListViewTranscript(this.lsvWithdrawnSubjects, this.tblWithdrawn);
                    _studentManager.InitializeSpecialClassLoadedWithdrawnListViewTranscript(this.lsvSpecialClass, this.lblSpeicalClass, this.tblSpecialClass, false);
                    _studentManager.InitializeSpecialClassLoadedWithdrawnListViewTranscript(this.lsvWithdrawnSpecialClass,
                        this.lblWithdrawnSpecialClass, this.tblWithdrawnSpecialClass, true);
                }
            }

            this.Cursor = Cursors.Arrow;
        }//---------------------
        //##################################END COMBOBOX cboYear EVENTS##########################################################

        //##################################COMBOBOX cboSemester EVENTS##########################################################
        //event is raised when the selected index is changed
        private void cboSemesterSelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            _dateStart = _studentManager.GetSemesterDateStart(_studentManager.GetSemesterSystemId(this.cboYear.SelectedIndex,
                 this.cboSemester.SelectedIndex)).ToShortDateString() + " 12:00:00 AM";
            _dateEnd = _studentManager.GetSemesterDateEnd(_studentManager.GetSemesterSystemId(this.cboYear.SelectedIndex,
                this.cboSemester.SelectedIndex)).ToShortDateString() + " 11:59:59 PM";

            DataTable tempTable = _studentManager.StudentLoadtable;

            tempTable.Rows.Clear();

            _studentManager.StudentLoadtable = tempTable;

            if (!String.IsNullOrEmpty(_studentInfo.StudentSysId))
            {
                _studentManager.SelectBySysIDStudentDateStartEndStudentEnrolmentCourse(_userInfo, _studentInfo.StudentSysId, _dateStart, _dateEnd);


                _studentManager.InitializedCourseTextBox(this.txtCourse, _studentManager.GetSemesterSystemId(this.cboYear.SelectedIndex,
                    this.cboSemester.SelectedIndex), true, ref _enrolmentCourseSysId);

                if (!String.IsNullOrEmpty(_studentInfo.StudentSysId))
                {
                    _studentManager.SelectBySysIDStudentYearIDSemesterStudentEnrolmentLevel(_userInfo, _studentInfo.StudentSysId,
                        _studentManager.GetSchoolYearYearId(this.cboYear.SelectedIndex),
                        _studentManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex), _enrolmentCourseSysId, String.Empty);

                    _studentManager.SelectBySysIDStudentListDateStartEndSpecialClassInformation(_userInfo, _studentInfo.StudentSysId, _dateStart, _dateEnd);
                }

                _studentManager.InitializedYearLevelTextBox(this.txtLevel, ref _enrolmentLevelSysId);

                _enrolmentLevelInfo = _studentManager.GetStudentEnrolmentLevelInfo(_enrolmentLevelSysId);

                Boolean isEnrolled = !String.IsNullOrEmpty(this.txtLevel.Text) ? true : false;

                if (!String.IsNullOrEmpty(_studentInfo.StudentSysId))
                {
                    _studentManager.SelectBySysIDEnrolmentLevelDateStartEndSubjectScheduleStudentLoad(_userInfo, _studentInfo.StudentSysId,
                        _enrolmentLevelInfo.EnrolmentLevelSysId, _enrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId,
                        _studentManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex),
                        _enrolmentLevelInfo.IsGraduateStudent, _enrolmentLevelInfo.IsInternational, true, isEnrolled, _dateStart, _dateEnd);
                }

                _studentManager.InitializeSubjectLoadListViewTranscript(this.lsvSubjectLoad, this.lblTotal, tblSubjectLoad);
                _studentManager.InitializeWithdrawSubjectLoadListViewTranscript(this.lsvWithdrawnSubjects, this.tblWithdrawn);
                _studentManager.InitializeSpecialClassLoadedWithdrawnListViewTranscript(this.lsvSpecialClass, this.lblSpeicalClass, this.tblSpecialClass, false);
                _studentManager.InitializeSpecialClassLoadedWithdrawnListViewTranscript(this.lsvWithdrawnSpecialClass,
                    this.lblWithdrawnSpecialClass, this.tblWithdrawnSpecialClass, true);
            }

            this.Cursor = Cursors.Arrow;
        }//----------------------
        //##################################END COMBOBOX cboSemester EVENTS##########################################################

        //##################################LISTVIEW lsvSubjectLoad EVENTS##########################################################
        //event is raised when the column is clicked
        private void lsvSubjectLoadColumnClick(object sender, ColumnClickEventArgs e)
        {   
            if (e.Column == 0)
            {
                _isCheacked = !_isCheacked;

                if (this.tabStudentSubject.SelectedIndex == 0)
                {
                    foreach (ListViewItem item in this.lsvSubjectLoad.Items)
                    {
                        item.Checked = _isCheacked;
                    }
                }
                else if (this.tabStudentSubject.SelectedIndex == 1)
                {
                    foreach (ListViewItem item in this.lsvWithdrawnSubjects.Items)
                    {
                        item.Checked = _isCheacked;
                    }
                }
                else if (this.tabStudentSubject.SelectedIndex == 2)
                {
                    foreach (ListViewItem item in this.lsvSpecialClass.Items)
                    {
                        item.Checked = _isCheacked;
                    }
                }
                else if (this.tabStudentSubject.SelectedIndex == 3)
                {
                    foreach (ListViewItem item in this.lsvWithdrawnSpecialClass.Items)
                    {
                        item.Checked = _isCheacked;
                    }
                }

                if (_isCheacked)
                {
                    this.btnCopySelectedSubject.Enabled = true;
                }
            }
        }//---------------------

        //event is raised when the item checked is changed
        private void lsvSubjectLoadItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (this.tabStudentSubject.SelectedIndex == 0)
            {
                this.btnCopySelectedSubject.Enabled = this.lsvSubjectLoad.CheckedItems.Count > 0 ? true : false;
            }
            else if (this.tabStudentSubject.SelectedIndex == 1)
            {
                this.btnCopySelectedSubject.Enabled = this.lsvWithdrawnSubjects.CheckedItems.Count > 0 ? true : false;
            }
            else if (this.tabStudentSubject.SelectedIndex == 2)
            {
                this.btnCopySelectedSubject.Enabled = this.lsvSpecialClass.CheckedItems.Count > 0 ? true : false;
            }
            else if (this.tabStudentSubject.SelectedIndex == 3)
            {
                this.btnCopySelectedSubject.Enabled = this.lsvWithdrawnSpecialClass.CheckedItems.Count > 0 ? true : false;
            }
        }//----------------------
        //##################################END LISTVIEW lsvSubjectLoad EVENTS##########################################################

        //##################################TAB CONTROL tabStudentSubjectLoad EVENTS##########################################################
        //event is raised when the selected index is changed
        private void tabStudentSubjectSelectedIndexChanged(object sender, EventArgs e)
        {
            _isCheacked = false;
           
            foreach (ListViewItem item in this.lsvSubjectLoad.Items)
            {
                item.Checked = _isCheacked;
            }

            foreach (ListViewItem item in this.lsvWithdrawnSubjects.Items)
            {
                item.Checked = _isCheacked;
            }

            foreach (ListViewItem item in this.lsvSpecialClass.Items)
            {
                item.Checked = _isCheacked;
            }

            foreach (ListViewItem item in this.lsvWithdrawnSpecialClass.Items)
            {
                item.Checked = _isCheacked;
            }       

            this.btnCopySelectedSubject.Enabled = false;
        }//-------------------------
        //##################################END TAB CONTROL tabStudentSubjectLoad EVENTS##########################################################

        //##################################BUTTON btnCopySelectedSubject EVENTS##########################################################
        //event is raised when the control is clicked
        private void btnCopySelectedSubjectLoadClick(object sender, EventArgs e)
        {
            if (this.tabStudentSubject.SelectedIndex == 0)
            {
                _transcriptManager.SetCopiedSubjectTable(this.lsvSubjectLoad, false);
            }
            else if (this.tabStudentSubject.SelectedIndex == 1)
            {
                _transcriptManager.SetCopiedSubjectTable(this.lsvWithdrawnSubjects, false);
            }
            else if (this.tabStudentSubject.SelectedIndex == 2)
            {
                _transcriptManager.SetCopiedSubjectTable(this.lsvSpecialClass, true);
            }
            else if (this.tabStudentSubject.SelectedIndex == 3)
            {
                _transcriptManager.SetCopiedSubjectTable(this.lsvWithdrawnSpecialClass, true);
            }         

            this.lblInsertEnrolmentInformation.Enabled = true;
        }//----------------------------
        //##################################END BUTTON btnCopySelectedSubject EVENTS##########################################################

        //##################################BUTTON btnEnrolmentHistory EVENTS##########################################################
        //event is raised when the control is clicked
        private void btnEnrolmentHistoryClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _studentManager.SelectBySysIDStudentForEnrolmentHistoryEnrolmentCourseLevel(_userInfo, _studentInfo.StudentSysId);

                using (OfficeServices.StudentEnrolmentHistory frmHistory = new OfficeServices.StudentEnrolmentHistory(_studentManager))
                {
                    frmHistory.ShowDialog();
                }

                this.Cursor = Cursors.Arrow;
            }
            catch
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Enrolment History Module.", "Error Loading");
            }
        }//--------------------------
        //##################################END BUTTON btnEnrolmentHistory EVENTS##########################################################

        //##################################PICTUREBOX pbxStudent EVENTS##########################################################
        //event is raised when the control is clicked
        private void pbxStudentClick(object sender, EventArgs e)
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

                    this.pbxStudent.Image = Image.FromFile(imageChooser.FileName);

                    _transcripInfo.FilePath = imageChooser.FileName;

                   _transcripInfo.FileData = RemoteClient.ProcStatic.GetFileArrayBytes(_transcripInfo.FilePath);
                   _transcripInfo.FileExtension = _transcriptManager.GetImageExtensionName(_transcripInfo.FilePath);
                   _transcripInfo.FileName = Path.GetFileName(_transcripInfo.FilePath);

                    this.Cursor = Cursors.Arrow;

                    this.btnPrint.Enabled = false;

                    _hasModified = true;
                }
            }
        }//---------------------------
        //##################################PICTUREBOX pbxStudent EVENTS##########################################################

        //##################################BUTTON btnRecordTranscriptInformation EVENTS##########################################################
        //event is raised when the control is clicked
        private void btnRecordClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to record transcript information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The transcript information has been successfully recorded.";

                        this.Cursor = Cursors.WaitCursor;

                        if (String.IsNullOrEmpty(_transcripInfo.TranscriptSysId))
                        {
                            _transcriptManager.InsertTranscriptInformation(_userInfo, ref _transcripInfo, (DataTable)this.dgvList.DataSource);
                        }
                        else
                        {
                            _transcriptManager.UpdateTranscriptInformation(_userInfo, _transcripInfo, (DataTable)this.dgvList.DataSource);
                        }

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        this.dgvList.DataSource = _transcriptManager.SelectBySysIDTranscriptDetails(_userInfo, _transcripInfo.TranscriptSysId, false);

                        _tempTranscriptInfo = (CommonExchange.TranscriptInformation)_transcripInfo.Clone();

                        this.btnPrint.Enabled = true;

                        _hasModified = false;
                    }
                    else if (msgResult == DialogResult.Cancel)
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Reacording");
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }
        }//--------------------------
        //##################################END BUTTON btnRecordTranscriptInformation EVENTS##########################################################

        //##################################BUTTON btnClose EVENTS##########################################################
        //event is raised when the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//-------------------------
        //##################################END BUTTON btnClose EVENTS##########################################################

        //##################################BUTTON btnPrint EVENTS##########################################################
        //event is raised when the control is clicked
        private void btnPrintClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            _transcriptManager.PrintStudentTranscriptOfRecord(_userInfo, _transcripInfo, this.pbxStudent.Image, (DataTable)this.dgvList.DataSource, this.chkIncludePicture.Checked);

            this.Cursor = Cursors.Arrow;
        }//-----------------
        //##################################BUTTON btnPrint EVENTS##########################################################
        #endregion      

        #region Programmers-Defined Void Procedures
        //this procedure will set student information controls
        private void InitializeStudentInformationControls(Boolean isFormSearch)
        {
            this.Cursor = Cursors.WaitCursor;

            this.pbxStudent.Image = null;

            //Note: There is no system id schedule in the DLL.. and sysid_schedule filed when calling GetTranscriptInformation
            _transcripInfo = _transcriptManager.GetTranscriptInformation(_userInfo, _transcripInfo.StudentId);

            if (!String.IsNullOrEmpty(_studentInfo.StudentId))
            {
                _transcripInfo.StudentId = _studentInfo.StudentId;

                if (isFormSearch)
                {
                    _transcripInfo.LastName = _studentInfo.PersonInfo.LastName;
                    _transcripInfo.FirstName = _studentInfo.PersonInfo.FirstName;
                    _transcripInfo.MiddleName = _studentInfo.PersonInfo.MiddleName;
                }
            }
            else
            {
                _studentInfo.StudentId = _transcripInfo.StudentId;
                _studentInfo.PersonInfo.LastName = _transcripInfo.LastName;
                _studentInfo.PersonInfo.FirstName = _transcripInfo.FirstName;
                _studentInfo.PersonInfo.MiddleName = _transcripInfo.MiddleName;
            }

            this.dgvList.DataSource = _transcriptManager.SelectBySysIDTranscriptDetails(_userInfo, _transcripInfo.TranscriptSysId, false);

            if (this.dgvList.Rows.Count == 0)
            {
                Int32 temp = 0;

                this.dgvList.DataSource = _transcriptManager.AddRowBreakPointBeforeOrAfter((DataTable)this.dgvList.DataSource, 0, 0, c_OneRow, true, false, ref temp);
            }

            if (String.IsNullOrEmpty(_studentInfo.PersonInfo.FilePath))
            {
                _studentInfo.PersonInfo.FilePath = _transcriptManager.GetPersonImagePathTranscript(_userInfo, _transcripInfo.TranscriptSysId,
                    _studentInfo.PersonInfo.PersonImagesFolder(Application.StartupPath));
            }            

            this.txtStudentId.Text = _transcripInfo.StudentId;
            this.txtLastName.Text =  _transcripInfo.LastName;
            this.txtFirstName.Text = _transcripInfo.FirstName;
            this.txtMiddleName.Text = _transcripInfo.MiddleName;
            this.txtCourseTitle.Text = _transcripInfo.CourseTitle;
            this.txtDepartmentName.Text = _transcripInfo.DepartmentName;
            this.txtEntranceData.Text = _transcripInfo.EntranceData;
            this.txtRecordOfGraduation.Text = _transcripInfo.RecordsOfGraduation;
            this.txtPursposeOfRequest.Text = _transcripInfo.PurposeOfRequest;
            
            if (!String.IsNullOrEmpty(_studentInfo.PersonInfo.FilePath))
            {
                this.pbxStudent.Image = Image.FromFile(_studentInfo.PersonInfo.FilePath);

                _transcripInfo.FilePath = _studentInfo.PersonInfo.FilePath;

                _transcripInfo.FileData = RemoteClient.ProcStatic.GetFileArrayBytes(_studentInfo.PersonInfo.FilePath);
                _transcripInfo.FileExtension = _transcriptManager.GetImageExtensionName(_studentInfo.PersonInfo.FilePath);
                _transcripInfo.FileName = Path.GetFileName(_studentInfo.PersonInfo.FilePath);
            }
            else if (!String.IsNullOrEmpty(_transcripInfo.TranscriptSysId))
            {
                if (File.Exists(_transcripInfo.PersonImagesFolder(Application.StartupPath) + _transcripInfo.TranscriptSysId + ".jpg"))
                {
                    this.pbxStudent.Image = Image.FromFile(_transcripInfo.PersonImagesFolder(Application.StartupPath) + _transcripInfo.TranscriptSysId + ".jpg");
                }
            }

            _tempTranscriptInfo = (CommonExchange.TranscriptInformation)_transcripInfo.Clone();

            this.Cursor = Cursors.Arrow;
        }//----------------------------
        #endregion

        #region Programmers-Defined Functions
        //this function will validate controls
        public Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.txtStudentId, "");
            _errProvider.SetError(this.txtLastName, "");
            _errProvider.SetError(this.txtFirstName, "");

            if (String.IsNullOrEmpty(_transcripInfo.StudentId))
            {
                _errProvider.SetIconAlignment(this.txtStudentId, ErrorIconAlignment.MiddleLeft);
                _errProvider.SetError(this.txtStudentId, "A student ID is required.");

                isValid = false;
            }

            if (String.IsNullOrEmpty(_transcripInfo.LastName))
            {
                _errProvider.SetIconAlignment(this.txtLastName, ErrorIconAlignment.MiddleLeft);
                _errProvider.SetError(this.txtLastName, "A student last name is required.");

                isValid = false;
            }

            if (String.IsNullOrEmpty(_transcripInfo.FirstName))
            {
                _errProvider.SetIconAlignment(this.txtFirstName, ErrorIconAlignment.MiddleLeft);
                _errProvider.SetError(this.txtFirstName, "A student firts name is required.");

                isValid = false;
            }

            if (_transcriptManager.IsExistStudentIDTranscriptInformation(_userInfo, _transcripInfo.StudentId, _transcripInfo.TranscriptSysId))
            {
                _errProvider.SetIconAlignment(this.txtStudentId, ErrorIconAlignment.MiddleLeft);
                _errProvider.SetError(this.txtStudentId, "A student id / transcript information already exist.");

                isValid = false;
            }

            return isValid;
        }//------------------

        //this fucntion will set firt letter to upper case
        private String SetFirstLetterToUpper(String strBase)
        {
            StringBuilder strBlock = new StringBuilder();
            Boolean forUpper = false;
            Boolean isWhiteSpace = false;

            for (Int32 i = 0; i <= strBase.Length - 1; i++)
            {
                if (i == 0 || (forUpper && strBase[i] != ' ') || (strBase[i] == 'i' || strBase[i] == 'I'))
                {
                    strBlock.Append(strBase[i].ToString().ToUpper());
                    forUpper = false;
                    isWhiteSpace = false;
                }
                else if (strBase[i] == ' ' && !isWhiteSpace)
                {
                    strBlock.Append(strBase[i]);
                    forUpper = true;
                    isWhiteSpace = true;
                }
                else if (!isWhiteSpace)
                {
                    strBlock.Append(strBase[i].ToString().ToLower());
                    isWhiteSpace = false;
                }
            }

            return strBlock.ToString();
        }//-----------------------
        #endregion
    }
}


