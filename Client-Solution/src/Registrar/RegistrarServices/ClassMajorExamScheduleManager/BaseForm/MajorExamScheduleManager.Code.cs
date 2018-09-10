using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace RegistrarServices
{
    partial class MajorExamScheduleManager
    {
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private MajorExamScheduleLogic _majorExamScheduleManager;

        private MajorExamScheduleSearchList _frmMajorExamScheduleSearch;

        private String _dateStart = String.Empty;
        private String _dateEnd = String.Empty;
        #endregion

        #region Class Constructors
        public MajorExamScheduleManager(CommonExchange.SysAccess userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;

            this.Load += new EventHandler(ClassLoad);
            this.ctlManager.OnClose += new RemoteClient.ControlManagerCloseButtonClick(ctlManagerOnClose);
            this.ctlManager.OnRefresh += new RemoteClient.ControlManagerRefreshButtonClick(ctlManagerOnRefresh);
            this.ctlManager.OnTextBoxKeyUp += new RemoteClient.ControlManagerTextBoxSearchKeyUp(ctlManagerOnTextBoxKeyUp);
            this.ctlManager.OnSchoolYearSelectedIndexChanged += 
                new RemoteClient.ControlMajorExamScheduleManagerSchoolYearSelectedIndexChanged(ctlManagerOnSchoolYearSelectedIndexChanged);
            this.ctlManager.OnSemesterSelectedIndexChanged += 
                new RemoteClient.ControlMajorExamScheduleManagerSemesterSelectedIndexChanged(ctlManagerOnSemesterSelectedIndexChanged);
            this.ctlManager.OnCourseGroupSelectedIndexChanged += 
                new RemoteClient.ControlMajorExamScheduleManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnCourseGroupExamScheduleSelectedIndexChanged);
            this.ctlManager.OnExamSelectedIndexChanged += 
                new RemoteClient.ControlMajorExamScheduleManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnCourseGroupExamScheduleSelectedIndexChanged);
            this.ctlManager.OnResetLinkClicked += new RemoteClient.ControlMajorExamScheduleManagerResetQueryLinkClicked(ctlManagerOnResetLinkClicked);

        }
        #endregion

        #region Class Event Void Procedure
        //####################################################CLASS MajorExamScheduleManager EVENTS###############################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            try
            {
                if (!(RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessCollegeRegistrar(_userInfo)))
                {
                    throw new Exception("You are not authorized to access this module.");
                }

                _majorExamScheduleManager = new MajorExamScheduleLogic(_userInfo);

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_majorExamScheduleManager.ServerDateTime).ToString();

                _frmMajorExamScheduleSearch = new MajorExamScheduleSearchList();
                _frmMajorExamScheduleSearch.OnCreate += new MajorExamScheduleSearchListLinkCreateClick(_frmMajorExamScheduleSearchOnCreate);
                _frmMajorExamScheduleSearch.OnDoubleClickEnter += new SearchListDataGridDoubleClickEnter(_frmMajorExamScheduleSearchOnDoubleClickEnter);
                _frmMajorExamScheduleSearch.Location = new Point(14, 300);
                _frmMajorExamScheduleSearch.AdoptGridSize = false;
                _frmMajorExamScheduleSearch.MdiParent = this;

                _majorExamScheduleManager.InitializeSchoolYearComboManager(this.ctlManager.SchoolYearComboBox);
                _majorExamScheduleManager.InitializeCourseGroupCheckedListBox(this.ctlManager.CourseGroupCheckedListBox);
                _majorExamScheduleManager.InitializeMajorExamInformationCheckedListBox(this.ctlManager.ExamCheckedListBox);
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog("\n" + ex.Message, "Error Authenticating");

                this.Close();
            }
        }        
        //----------------------
        //####################################################END CLASS MajorExamScheduleManager EVENTS###############################################

        //############################################CONTROLSPECIALCLASSMANAGER ctlManager EVENTS##########################################
        //event is raised when the button is click
        private void ctlManagerOnClose()
        {
            this.Close();
        }//--------------------

        //event is raised when the button is click
        private void ctlManagerOnRefresh()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _majorExamScheduleManager.RefreshStudentData(_userInfo);

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_majorExamScheduleManager.ServerDateTime).ToString();

                this.ShowSearchResultDialog();
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Refreshing Major Exam Schedule Data Manager");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//--------------------

        //event is raised when the key is up
        private void ctlManagerOnTextBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                _frmMajorExamScheduleSearch.SelectFirstRowInDataGridView();
            }
            else if (string.IsNullOrEmpty(RemoteClient.ProcStatic.TrimStartEndString(ctlManager.GetSearchString)))
            {
                _frmMajorExamScheduleSearch.WindowState = FormWindowState.Minimized;

                this.ctlManager.SetFocusOnSearchTextBox();
            }
        }//-------------------------

        //event is raised when the selected index is changed
        private void ctlManagerOnSchoolYearSelectedIndexChanged()
        {
            _dateStart = _majorExamScheduleManager.GetSchoolYearDateStart
                        (_majorExamScheduleManager.GetSchoolYearYearId(this.ctlManager.SchoolYearIndex)).ToShortDateString() + " 12:00:00 AM";
            _dateEnd = _majorExamScheduleManager.GetSchoolYearDateEnd
                        (_majorExamScheduleManager.GetSchoolYearYearId(this.ctlManager.SchoolYearIndex)).ToShortDateString() + " 11:59:59 PM";

            _majorExamScheduleManager.InitializeSemesterCombo(this.ctlManager.SemesterComboBox, this.ctlManager.SchoolYearIndex);

            this.ShowSearchResultDialog();
        }//---------------------

        //event is raised when the selected index is changed
        private void ctlManagerOnSemesterSelectedIndexChanged()
        {
            _dateStart = _majorExamScheduleManager.GetSemesterDateStart(
                _majorExamScheduleManager.GetSemesterSystemId(this.ctlManager.SchoolYearIndex, this.ctlManager.SemesterIndex)).ToShortDateString() + " 12:00:00 AM";

            _dateEnd = _majorExamScheduleManager.GetSemesterDateEnd(
                _majorExamScheduleManager.GetSemesterSystemId(this.ctlManager.SchoolYearIndex, this.ctlManager.SemesterIndex)).ToShortDateString() + " 11:59:59 PM";

            this.ShowSearchResultDialog();
        }//------------------------
             
        //event is raised when the semester, course gourp, exam schedule selected index is changed
        private void ctlManagerOnCourseGroupExamScheduleSelectedIndexChanged()
        {
            this.ShowSearchResultDialog();
        }//---------------------

        //event is raised when the link is clicked
        private void ctlManagerOnResetLinkClicked()
        {
            this.ctlManager.OnCourseGroupSelectedIndexChanged -=
                new RemoteClient.ControlMajorExamScheduleManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnCourseGroupExamScheduleSelectedIndexChanged);
            this.ctlManager.OnExamSelectedIndexChanged -=
                new RemoteClient.ControlMajorExamScheduleManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnCourseGroupExamScheduleSelectedIndexChanged);

            _majorExamScheduleManager.InitializeSchoolYearComboManager(this.ctlManager.SchoolYearComboBox);
            _majorExamScheduleManager.InitializeCourseGroupCheckedListBox(this.ctlManager.CourseGroupCheckedListBox);
            _majorExamScheduleManager.InitializeMajorExamInformationCheckedListBox(this.ctlManager.ExamCheckedListBox);

            _dateStart = _dateEnd = String.Empty;

            this.ctlManager.SemesterComboBox.Items.Clear();

            this.ctlManager.OnCourseGroupSelectedIndexChanged +=
                new RemoteClient.ControlMajorExamScheduleManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnCourseGroupExamScheduleSelectedIndexChanged);
            this.ctlManager.OnExamSelectedIndexChanged +=
                new RemoteClient.ControlMajorExamScheduleManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnCourseGroupExamScheduleSelectedIndexChanged);

            _frmMajorExamScheduleSearch.WindowState = FormWindowState.Minimized;
        }//-----------------------------
        //############################################END CONTROLSPECIALCLASSMANAGER ctlManager EVENTS##########################################

        //############################################EXAMINATIONSCHEDULESEARCH frmMajorExamSchedule EVENTS##########################################
        //event is raised when the control is clicked
        private void _frmMajorExamScheduleSearchOnCreate()
        {
            try
            {
                using (MajorExamScheduleCreate frmCreate = new MajorExamScheduleCreate(_userInfo, _majorExamScheduleManager))
                {
                    frmCreate.ShowDialog(this);

                    if (frmCreate.HasCreated)
                    {
                        this.ShowSearchResultDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }
        }//--------------------------

        //event is raised when the control is clicked
        private void _frmMajorExamScheduleSearchOnDoubleClickEnter(string id)
        {
            try
            {
                using (MajorExamScheduleUpdate frmUpdate = new MajorExamScheduleUpdate(_userInfo,
                    _majorExamScheduleManager.GetDetailsMajorExamSchedule(_frmMajorExamScheduleSearch.PrimaryId), _majorExamScheduleManager))
                {
                    frmUpdate.ShowDialog(this);

                    if (frmUpdate.HasUpated || frmUpdate.HasDeleted)
                    {
                        this.ShowSearchResultDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }
        }//---------------------
        //############################################END EXAMINATIONSCHEDULESEARCH frmMajorExamSchedule EVENTS##########################################
        #endregion

        #region Programer-Defined Void Procedures
        //this procedure shows the search result
        private void ShowSearchResultDialog()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _frmMajorExamScheduleSearch.DataSource = _majorExamScheduleManager.GetSearchMajorExamSchedule(_userInfo, _dateStart, _dateEnd,
                    _majorExamScheduleManager.GetCourseGroupExamStringFormat(this.ctlManager.CourseGroupCheckedListBox, true),
                    _majorExamScheduleManager.GetCourseGroupExamStringFormat(this.ctlManager.ExamCheckedListBox, false));
                
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Retrieving Data");
            }
            finally
            {
                this.ctlManager.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }

        }//---------------------------------
        #endregion
    }
}
