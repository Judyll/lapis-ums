using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace OfficeServices
{
    partial class StudentSearch
    {
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private ScholarshipLogic _scholarshipManager;

        private String _dateStart = String.Empty;
        private String _dateEnd = String.Empty;
  
        private Int32 _primaryIndex = 0;

        private Boolean _isRecordLocked = false;
        private Boolean _byPassRecordLocked = false;
        private Boolean _isEnabledYearCombo = false;
        
        #endregion 
        
        #region Class Prperties Declaration
        private String _primaryId = "";
        public String PrimaryId
        {
            get { return _primaryId; }
        }

        private Boolean _hasSelected = false;
        public Boolean HasSelected
        {
            get { return _hasSelected; }
        }
        #endregion

        #region Class Constructors
        public StudentSearch(CommonExchange.SysAccess userInfo, ScholarshipLogic scholarshipManager, Boolean byPassRecordLocked, Boolean isEnabledYearCombo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _scholarshipManager = scholarshipManager;
            _byPassRecordLocked = byPassRecordLocked;
            _isEnabledYearCombo = isEnabledYearCombo;

            this.Load += new EventHandler(ClassLoad);
            this.dgvList.MouseDown += new MouseEventHandler(dgvListMouseDown);
            this.dgvList.MouseDoubleClick += new MouseEventHandler(dgvListDoubleClick);
            this.dgvList.DataSourceChanged += new EventHandler(dgvListDataSourceChanged); 
            this.dgvList.SelectionChanged += new EventHandler(dgvListSelectionChanged);
            this.ctlStudentSearch.OnClose += new RemoteClient.ControlManagerCloseButtonClick(ctlStudentSearchOnClose);
            this.ctlStudentSearch.OnRefresh += new RemoteClient.ControlManagerRefreshButtonClick(ctlStudentSearchOnRefresh);
            this.ctlStudentSearch.OnTextBoxKeyUp += new RemoteClient.ControlManagerTextBoxSearchKeyUp(ctlStudentSearchOnTextBoxKeyUp);
            this.ctlStudentSearch.OnPressEnter += new RemoteClient.ControlStudentManagerPressEnter(ctlStudentSearchOnPressEnter);
            this.ctlStudentSearch.OnSchoolYearSelectedIndexChanged += 
                new RemoteClient.ControlStudentManagerSchoolYearSelectedIndexChanged(ctlStudentSearchOnSchoolYearSelectedIndexChanged);
            this.ctlStudentSearch.OnSemesterSelectedIndexChanged += 
                new RemoteClient.ControlStudentManagerSemesterSelectedIndexChanged(ctlStudentSearchOnSemesterSelectedIndexChanged);
            this.ctlStudentSearch.OnCourseSelectedIndexChanged += 
                new RemoteClient.ControlStudentManagerCheckedListBoxSelectedIndexChanged(ctlStudentSearchOnCourseLevelSelectedIndexChanged);
            this.ctlStudentSearch.OnYearLevelSelectedIndexChanged += 
                new RemoteClient.ControlStudentManagerCheckedListBoxSelectedIndexChanged(ctlStudentSearchOnCourseLevelSelectedIndexChanged);
            this.ctlStudentSearch.OnResetLinkClicked += new RemoteClient.ControlStudentManagerResetQueryLinkClicked(ctlStudentSearchOnResetLinkClicked);
        }
        #endregion

        #region Class Event Void Procedure
        //###############################################CLASS StudentSearch EVENTS##################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            dgvList.DataSource = _scholarshipManager.StudentTableFormat;
            
            RemoteClient.ProcStatic.SetDataGridViewColumns(dgvList, false);

            this.ctlStudentSearch.SchoolYearComboBox.Enabled = _isEnabledYearCombo;
            this.ctlStudentSearch.DisableMoveCapability();

            if (!_isEnabledYearCombo)
            {
                _scholarshipManager.InitializeSchoolYearCombo(this.ctlStudentSearch.SchoolYearComboBox);
            }
            else
            {
                _scholarshipManager.InitializeSchoolYearComboManagerWithOutSelectedIndex(this.ctlStudentSearch.SchoolYearComboBox);

                this.lblStatus.Visible = this.pbxLocked.Visible = this.pbxUnlock.Visible = false;
            }

            _scholarshipManager.InitializeCourseCheckedListBox(this.ctlStudentSearch.CourseCheckedListBox);
            _scholarshipManager.InitializeYearLevelCheckedListBox(this.ctlStudentSearch.YearLevelCheckedListBox);

            this.ctlStudentSearch.Select();
            this.ctlStudentSearch.SetFocusOnSearchTextBox();
        }//------------------------        
        //###############################################END CLASS StudentSearch EVENTS##################################################

        //####################################################DATAGRIDVIEW dgvList EVENTS####################################################
        //event is raised when the mouse is down
        private void dgvListMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView dgvBase = (DataGridView)sender;

                DataGridView.HitTestInfo hitTest = dgvBase.HitTest(e.X, e.Y);

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
                        _primaryId = "";
                        break;
                }

                if (rowIndex != -1)
                {
                    _primaryId = dgvBase[_primaryIndex, rowIndex].Value.ToString();
                }
            }
        }//----------------------

        //event is raised when the mouse is double clicked
        private void dgvListDoubleClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(_primaryId) && !_isRecordLocked)
            {
                _hasSelected = true;

                this.Close();
            }
        } //---------------------------------

        //event is raised when the data source is changed
        private void dgvListDataSourceChanged(object sender, EventArgs e)
        {
            DataGridView dgvBase = (DataGridView)sender;
            Int32 result = dgvBase.Rows.Count;

            if (result == 1)
            {
                _primaryId = dgvBase[_primaryIndex, 0].Value.ToString();
            }
            else
            {
                _primaryId = "";
            }

            if (result == 0 || result == 1)
            {
                this.lblResult.Text = result.ToString() + " Record";
            }
            else
            {
                this.lblResult.Text = result.ToString() + " Records";
            }

        } //--------------------------------

        //event is raised when the selection is changed
        private void dgvListSelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgvBase = (DataGridView)sender;

            if (dgvBase.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {
                DataGridViewRow row = dgvBase.SelectedRows[0];

                _primaryId = row.Cells[_primaryIndex].Value.ToString();
            }
        } //------------------------------------       
        //####################################################END DATAGRIDVIEW dgvList EVENTS####################################################

        //############################################CONTROLCLASSROOMSUBJECTMANAGER ctlManager EVENTS##########################################
        //event is raised when the button is click
        private void ctlStudentSearchOnClose()
        {
            this.Close();
        }//---------------------------

        //event is raised when the refresh button is clicked
        private void ctlStudentSearchOnRefresh()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _scholarshipManager.RefreshScholarshipData(_userInfo);

                this.ShowSearchResultDialog();
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Refreshing Student's Data Manager");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//------------------------

        //event is raised when the key is up
        private void ctlStudentSearchOnTextBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                SelectFirstRowInDataGridView();
            }
            else if (String.IsNullOrEmpty(RemoteClient.ProcStatic.TrimStartEndString(ctlStudentSearch.GetSearchString)))
            {
                this.ctlStudentSearch.SetFocusOnSearchTextBox();
            }
        }//--------------------

        //event is raised when the enter key is pressed
        private void ctlStudentSearchOnPressEnter(object sender, KeyEventArgs e)
        {
            this.ShowSearchResultDialog();
        }//-------------------------------

        //event is raised when the selected index is changed
        private void ctlStudentSearchOnSchoolYearSelectedIndexChanged()
        {
            _dateStart = _scholarshipManager.GetSchoolYearDateStart(_scholarshipManager.GetSchoolYearYearId(this.ctlStudentSearch.SchoolYearComboBox.SelectedIndex)).ToShortDateString()
                + " 12:00:00 AM";
            _dateEnd = _scholarshipManager.GetSchoolYearDateEnd(_scholarshipManager.GetSchoolYearYearId(this.ctlStudentSearch.SchoolYearComboBox.SelectedIndex)).ToShortDateString()
                + " 11:59:59 PM";

            this.IsRecordLocked();

            _scholarshipManager.InitializeSemesterCombo(this.ctlStudentSearch.SemesterComboBox, this.ctlStudentSearch.SchoolYearComboBox.SelectedIndex);

            this.ShowSearchResultDialog();
        }//---------------------------       

        //event is raised when the selected index is changed
        private void ctlStudentSearchOnSemesterSelectedIndexChanged()
        {
            _dateStart = _scholarshipManager.GetSemesterDateStart(_scholarshipManager.GetSemesterSystemId(this.ctlStudentSearch.SchoolYearComboBox.SelectedIndex,
               this.ctlStudentSearch.SemesterComboBox.SelectedIndex)).ToShortDateString() + " 12:00:00 AM";
            _dateEnd = _scholarshipManager.GetSemesterDateEnd(_scholarshipManager.GetSemesterSystemId(this.ctlStudentSearch.SchoolYearComboBox.SelectedIndex,
                this.ctlStudentSearch.SemesterComboBox.SelectedIndex)).ToShortDateString() + " 11:59:59 PM";

            this.IsRecordLocked();

            this.ShowSearchResultDialog();
        }//-------------------------

        //event is raised when the selected index is changed
        private void ctlStudentSearchOnCourseLevelSelectedIndexChanged()
        {
            this.ShowSearchResultDialog();
        }//---------------------

        //event is raised when the control is clicked
        private void ctlStudentSearchOnResetLinkClicked()
        {
            this.ctlStudentSearch.OnCourseSelectedIndexChanged -=
                  new RemoteClient.ControlStudentManagerCheckedListBoxSelectedIndexChanged(ctlStudentSearchOnCourseLevelSelectedIndexChanged);
            this.ctlStudentSearch.OnYearLevelSelectedIndexChanged -=
                new RemoteClient.ControlStudentManagerCheckedListBoxSelectedIndexChanged(ctlStudentSearchOnCourseLevelSelectedIndexChanged);

            if (!_isEnabledYearCombo)
            {
                _scholarshipManager.InitializeSchoolYearCombo(this.ctlStudentSearch.SchoolYearComboBox);
            }
            else
            {
                _scholarshipManager.InitializeSchoolYearComboManagerWithOutSelectedIndex(this.ctlStudentSearch.SchoolYearComboBox);
            }

            _scholarshipManager.InitializeCourseCheckedListBox(this.ctlStudentSearch.CourseCheckedListBox);
            _scholarshipManager.InitializeYearLevelCheckedListBox(this.ctlStudentSearch.YearLevelCheckedListBox);

            this.ctlStudentSearch.OnCourseSelectedIndexChanged +=
                new RemoteClient.ControlStudentManagerCheckedListBoxSelectedIndexChanged(ctlStudentSearchOnCourseLevelSelectedIndexChanged);
            this.ctlStudentSearch.OnYearLevelSelectedIndexChanged +=
                new RemoteClient.ControlStudentManagerCheckedListBoxSelectedIndexChanged(ctlStudentSearchOnCourseLevelSelectedIndexChanged);          

        }//---------------------
        //############################################END CONTROLCLASSROOMSUBJECTMANAGER ctlManager EVENTS##########################################
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure selects the first row in the datagridview
        private void SelectFirstRowInDataGridView()
        {
            if (dgvList.Rows.Count >= 1)
            {
                dgvList.Rows[0].Selected = true;
                dgvList.Focus();
            }
        } //-----------------------

        //this procedure shows the search result
        private void ShowSearchResultDialog()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string queryString = RemoteClient.ProcStatic.TrimStartEndString(ctlStudentSearch.GetSearchString);

                if (!_isEnabledYearCombo)
                {
                    if (!String.IsNullOrEmpty(queryString) && !String.IsNullOrEmpty(_dateStart) && !String.IsNullOrEmpty(_dateEnd))
                    {
                        dgvList.DataSource = _scholarshipManager.GetSearchedStudentInformation(_userInfo, queryString,
                           _dateStart, _dateEnd, _scholarshipManager.GetCourseYearLevelStringFormat(this.ctlStudentSearch.YearLevelCheckedListBox, false),
                           _scholarshipManager.GetCourseYearLevelStringFormat(this.ctlStudentSearch.CourseCheckedListBox, true));
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(queryString))
                    {
                        dgvList.DataSource = _scholarshipManager.GetSearchedStudentInformation(_userInfo, queryString,
                           _dateStart, _dateEnd, _scholarshipManager.GetCourseYearLevelStringFormat(this.ctlStudentSearch.YearLevelCheckedListBox, false),
                           _scholarshipManager.GetCourseYearLevelStringFormat(this.ctlStudentSearch.CourseCheckedListBox, true));
                    }
                }
                
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Retrieving Data");
            }
            finally
            {
                this.ctlStudentSearch.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }

        }//--------------------------------- 

        //this procedure will set record locked
        private void IsRecordLocked()
        {
            if (!_byPassRecordLocked)
            {
                if (RemoteClient.ProcStatic.IsRecordLocked(DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd), DateTime.Parse(_scholarshipManager.ServerDateTime)) &&
                    RemoteClient.ProcStatic.IsRecordLocked(DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd), DateTime.Parse(_scholarshipManager.ServerDateTime),
                    (Int32)CommonExchange.SystemRange.MonthAllowance))
                {
                    this.lblStatus.Text = "This record is LOCKED";

                    this.pbxLocked.Visible = true;
                    this.pbxUnlock.Visible = false;

                    _isRecordLocked = true;
                }
                else
                {
                    this.lblStatus.Text = "This record is OPEN";

                    this.pbxLocked.Visible = true;
                    this.pbxUnlock.Visible = false;

                    _isRecordLocked = false;
                }
            }
            else
            {
                this.lblStatus.Visible = this.pbxLocked.Visible = this.pbxUnlock.Visible = false;
            }
        }//--------------------------------
        #endregion

    }
}
