using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace OfficeServices
{
    partial class StudentLoadingManager
    {
        #region Class General Variable Declerations

        private CommonExchange.SysAccess _userInfo;
        private StudentLoadingLogic _studentManager;
        private SearchListForStudent _frmStudentSearch;

        private String _dateStart = String.Empty;
        private String _dateEnd = String.Empty;
        #endregion

        #region Class Constructor
        public StudentLoadingManager(CommonExchange.SysAccess userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
           
            this.Load += new EventHandler(ClassLoad);
            this.FormClosed += new FormClosedEventHandler(ClassClosed);
            this.ctlManager.OnClose += new RemoteClient.ControlManagerCloseButtonClick(ctlManagerOnClose);
            this.ctlManager.OnRefresh += new RemoteClient.ControlManagerRefreshButtonClick(ctlManagerOnRefresh);
            this.ctlManager.OnTextBoxKeyUp += new RemoteClient.ControlManagerTextBoxSearchKeyUp(ctlManagerOnTextBoxKeyUp);
            this.ctlManager.OnPressEnter += new RemoteClient.ControlStudentManagerPressEnter(ctlManagerOnPressEnter);
            this.ctlManager.OnSchoolYearSelectedIndexChanged += 
                new RemoteClient.ControlStudentManagerSchoolYearSelectedIndexChanged(ctlManagerOnSchoolYearSelectedIndexChanged);
            this.ctlManager.OnSemesterSelectedIndexChanged += 
                new RemoteClient.ControlStudentManagerSemesterSelectedIndexChanged(ctlManagerOnSemesterSelectedIndexChanged);
            this.ctlManager.OnCourseSelectedIndexChanged += 
                new RemoteClient.ControlStudentManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnCourseSelectedIndexChanged);
            this.ctlManager.OnYearLevelSelectedIndexChanged += 
                new RemoteClient.ControlStudentManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnYearLevelSelectedIndexChanged);
            this.ctlManager.OnResetLinkClicked += new RemoteClient.ControlStudentManagerResetQueryLinkClicked(ctlManagerOnResetLinkClicked);           
        }
       #endregion

        #region Class Event Void Procedures

        //###########################################CLASS StudentManager EVENTS#####################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            _studentManager = new StudentLoadingLogic(_userInfo);

            try
            {
                if (!(RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) ||
                   RemoteServerLib.ProcStatic.IsSystemAccessOfficeUser(_userInfo) ||
                   RemoteServerLib.ProcStatic.IsSystemAccessCashier(_userInfo) ||
                   RemoteServerLib.ProcStatic.IsSystemAccessVpOfFinance(_userInfo) ||
                   RemoteServerLib.ProcStatic.IsSystemAccessVpOfAcademicAffairs(_userInfo) || 
                   RemoteServerLib.ProcStatic.IsSystemAccessCollegeRegistrar(_userInfo) ||
                   RemoteServerLib.ProcStatic.IsSystemAccessStudentDataController(_userInfo) ||
                   RemoteServerLib.ProcStatic.IsSystemAccessSecretaryOftheVpOfAcademicAffairs(_userInfo)))
                {
                    throw new Exception("You are not authorized to access this module.");
                }          

                _studentManager.InitializeSchoolYearComboManager(this.ctlManager.SchoolYearComboBox);
                _studentManager.InitializeCourseCheckedListBox(this.ctlManager.CourseCheckedListBox);
                _studentManager.InitializeYearLevelCheckedListBox(this.ctlManager.YearLevelCheckedListBox);

                _frmStudentSearch = new SearchListForStudent();
                _frmStudentSearch.OnDoubleClickEnter += new SearchListDataGridDoubleClickEnterStudent(_frmStudentSearchOnDoubleClickEnter);
                _frmStudentSearch.OnDataSourceChange += new SearchListDataSourceChange(_frmStudentSearchOnDataSourceChange);
                _frmStudentSearch.OnPrintStudentLoadClick += new SearchListPrintButtonClick(_frmStudentSearchOnPrintStudentLoadClick);
                _frmStudentSearch.OnPrintStatementOfAccountClick += new SearchListPrintButtonClick(_frmStudentSearchOnPrintStatementOfAccountClick);
                _frmStudentSearch.OnPrintStudentMasterListClick += new SearchListPrintButtonClick(_frmStudentSearchOnPrintStudentMasterListClick);
                _frmStudentSearch.OnPrintStudentInsuranceListClick += new SearchListPrintButtonClick(_frmStudentSearchOnPrintStudentInsuranceListClick);
                _frmStudentSearch.OnPrintStudentEnrolmentListClick += new SearchListPrintButtonClick(_frmStudentSearchOnPrintStudentEnrolmentListClick);
                _frmStudentSearch.OnPrintStudentListClick += new SearchListPrintButtonClick(_frmStudentSearchOnPrintStudentListClick);
                _frmStudentSearch.OnPrintStudentQuickCountClick += new SearchListPrintButtonClick(_frmStudentSearchOnPrintStudentQuickCountClick);

                _frmStudentSearch.LocationPoint = new Point(14, 300);
                _frmStudentSearch.AdoptGridSize = false;
                _frmStudentSearch.MdiParent = this;

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_studentManager.ServerDateTime).ToString();
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog("\n" + ex.Message, "Error Authenticating");

                this.Close();
            }
        }//-------------------------------
       
        //event is raised when the class is closed
        private void ClassClosed(object sender, FormClosedEventArgs e)
        {
            _studentManager.DeleteImageDirectory(Application.StartupPath);
        }//-------------------------
        //###########################################END CLASS StudentManager EVENTS#####################################################

        //##########################################CLASS StudentSearchList EVENTS#######################################################       
        //event is raised when the datagrid is double clicked or enter
        private void _frmStudentSearchOnDoubleClickEnter(String id)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (StudentLoading frmShow = new StudentLoading(_userInfo, 
                    _studentManager.GetDetailsStudentInformation(_userInfo, id, Application.StartupPath), _studentManager))
                {
                    _frmStudentSearch.WindowState = FormWindowState.Minimized;

                    frmShow.ShowDialog(this);

                    _frmStudentSearch.WindowState = FormWindowState.Normal;

                    this.ctlManager.SetFocusOnSearchTextBox();
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Error Loading Student Loading Mudule.\n\n" + ex.Message, "Error Loading");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//---------------------     

        //event is raised when the datasource is changed
        private void _frmStudentSearchOnDataSourceChange()
        {
            _frmStudentSearch.SetProgressBarValue(0);
        }//----------------------

        //event is raised when the print student load button is clicked
        private void _frmStudentSearchOnPrintStudentLoadClick()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                DateTime dateEnding;

                if (this.ctlManager.SemesterComboBox.SelectedIndex >= 0)
                {
                    dateEnding = _studentManager.GetSemesterDateStart(_studentManager.GetSemesterSystemId(this.ctlManager.SchoolYearComboBox.SelectedIndex,
                        this.ctlManager.SemesterComboBox.SelectedIndex));
                }
                else
                {
                     dateEnding = _studentManager.GetSchoolYearDateStart(_studentManager.GetSchoolYearYearId(this.ctlManager.SchoolYearComboBox.SelectedIndex));
                }

                _studentManager.PrintStudentLoad(_userInfo,_dateStart, _dateEnd, dateEnding.AddDays(-1).ToShortDateString() + " 11:59:59 PM",
                    _frmStudentSearch.pgbPrint);

                this.Cursor = Cursors.Arrow;

                _frmStudentSearch.SetProgressBarValue(0);
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Printing");
            }
        }//---------------------------

        //event is raised when the print statement of account button is clicked
        private void _frmStudentSearchOnPrintStatementOfAccountClick()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _studentManager.SelectMajorExamScheduleTable(_userInfo, _dateStart, _dateEnd, String.Empty, true);

                using (MajorExamSchedule frmPrint = new MajorExamSchedule(_userInfo, _studentManager, true))
                {
                    frmPrint.ShowDialog(this);

                    if (frmPrint.HasClickedPrint)
                    {
                        DateTime dateEnding;

                        if (this.ctlManager.SemesterComboBox.SelectedIndex >= 0)
                        {
                            dateEnding = _studentManager.GetSemesterDateStart(_studentManager.GetSemesterSystemId(this.ctlManager.SchoolYearComboBox.SelectedIndex,
                                this.ctlManager.SemesterComboBox.SelectedIndex));
                        }
                        else
                        {
                            dateEnding = 
                                _studentManager.GetSchoolYearDateStart(_studentManager.GetSchoolYearYearId(this.ctlManager.SchoolYearComboBox.SelectedIndex));
                        }

                        this.Cursor = Cursors.WaitCursor;
                                                
                        _studentManager.PrintStudentStatementOfAccount(_userInfo, frmPrint.StudentTable, _dateStart, _dateEnd, 
                            dateEnding.AddDays(-1).ToShortDateString() + " 11:59:59 PM", _frmStudentSearch.pgbPrint, 
                            _studentManager.IsSchoolYearForSummer(_studentManager.GetSchoolYearYearId(this.ctlManager.SchoolYearComboBox.SelectedIndex)));

                        this.Cursor = Cursors.Arrow;
                    }
                }

                this.Cursor = Cursors.Arrow;

                _frmStudentSearch.SetProgressBarValue(0);
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Printing");
            }
        }//---------------------------

        //event is raised when the print student master list button is clicked
        private void _frmStudentSearchOnPrintStudentMasterListClick()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                String sem = String.Empty;

                sem = this.ctlManager.SemesterComboBox.SelectedIndex != -1 ? " - " + this.ctlManager.SemesterComboBox.Text : String.Empty;

                _studentManager.PrintStudentMasterList(this.ctlManager.CourseCheckedListBox, this.ctlManager.YearLevelCheckedListBox,
                    this.ctlManager.SchoolYearComboBox.Text + sem, _frmStudentSearch.pgbPrint, _userInfo);

                this.Cursor = Cursors.Arrow;

                _frmStudentSearch.SetProgressBarValue(0);
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Printing");
            }
        }//---------------------------

        //event is raised when the print student insurance list is clicked
        private void _frmStudentSearchOnPrintStudentInsuranceListClick()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                String sem = String.Empty;

                sem = this.ctlManager.SemesterComboBox.SelectedIndex != -1 ? " - " + this.ctlManager.SemesterComboBox.Text : String.Empty;

                _studentManager.PrintStudentInsuranceList(_userInfo, _frmStudentSearch.pgbPrint, this.ctlManager.SchoolYearComboBox.Text + sem);

                this.Cursor = Cursors.Arrow;

                _frmStudentSearch.SetProgressBarValue(0);
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Printing");
            }
        }//--------------------------------

        //event is raised when the print student enrolment list button clicked
        private void _frmStudentSearchOnPrintStudentEnrolmentListClick()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                String sem = String.Empty;

                sem = this.ctlManager.SemesterComboBox.SelectedIndex != -1 ? " - " + this.ctlManager.SemesterComboBox.Text : String.Empty;

                _studentManager.PrintStudentEnrolmentList(_userInfo, this.ctlManager.CourseCheckedListBox,
                    this.ctlManager.YearLevelCheckedListBox, _frmStudentSearch.pgbPrint, this.ctlManager.SchoolYearComboBox.Text + sem, _dateStart, _dateEnd);

                this.Cursor = Cursors.Arrow;

                _frmStudentSearch.SetProgressBarValue(0);
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Printing");
            }
        }//-------------------

        //event is raised when the print student list button is clicked
        private void _frmStudentSearchOnPrintStudentListClick()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                String sem = String.Empty;

                sem = this.ctlManager.SemesterComboBox.SelectedIndex != -1 ? " - " + this.ctlManager.SemesterComboBox.Text : String.Empty;

                _studentManager.PrintStudentList(_userInfo, _frmStudentSearch.pgbPrint, this.ctlManager.SchoolYearComboBox.Text + sem);

                this.Cursor = Cursors.Arrow;

                _frmStudentSearch.SetProgressBarValue(0);
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Printing");
            }
        }//---------------------

        //event is raised when the print enrollment quick count is clicked
        private void _frmStudentSearchOnPrintStudentQuickCountClick()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                String sem = String.Empty;

                sem = this.ctlManager.SemesterComboBox.SelectedIndex != -1 ? " - " + this.ctlManager.SemesterComboBox.Text : String.Empty;

                _studentManager.PrintEnrolmentQuickCount(this.ctlManager.CourseCheckedListBox, this.ctlManager.YearLevelCheckedListBox,
                    this.ctlManager.SchoolYearComboBox.Text + sem, _frmStudentSearch.pgbPrint, _userInfo);

                this.Cursor = Cursors.Arrow;

                _frmStudentSearch.SetProgressBarValue(0);
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Printing");
            }
        }//------------------------
        //##########################################END CLASS StudentSearchList EVENTS#######################################################       
        
        //############################################CONTROLCLASSROOMSUBJECTMANAGER ctlManager EVENTS##########################################
        //event is raised when the button is click
        private void ctlManagerOnClose()
        {
            this.Close();
        }//-------------------------

        //event is raised when the refresh button is clicked
        private void ctlManagerOnRefresh()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _studentManager.RefreshStudentData(_userInfo);

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_studentManager.ServerDateTime).ToString();

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
        private void ctlManagerOnTextBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                _frmStudentSearch.SelectFirstRowInDataGridView();
            }
            else if(string.IsNullOrEmpty(RemoteClient.ProcStatic.TrimStartEndString(ctlManager.GetSearchString)))
            {
                _frmStudentSearch.WindowState = FormWindowState.Minimized;

                this.ctlManager.SetFocusOnSearchTextBox();
            }
        }//-------------------------

        //event is raised when the enter key is pressed
        private void ctlManagerOnPressEnter(object sender, KeyEventArgs e)
        {
            this.ShowSearchResultDialog();
        }//-------------------------------

        //event is raised when the selected index is changed
        private void ctlManagerOnSchoolYearSelectedIndexChanged()
        {
            _dateStart =
                _studentManager.GetSchoolYearDateStart(_studentManager.GetSchoolYearYearId(this.ctlManager.SchoolYearComboBox.SelectedIndex)).ToShortDateString() 
                + " 12:00:00 AM";
            _dateEnd = 
                _studentManager.GetSchoolYearDateEnd(_studentManager.GetSchoolYearYearId(this.ctlManager.SchoolYearComboBox.SelectedIndex)).ToShortDateString() 
                + " 11:59:59 PM";
             
            _studentManager.InitializeSemesterCombo(this.ctlManager.SemesterComboBox, this.ctlManager.SchoolYearComboBox.SelectedIndex);

            _frmStudentSearch.DisableEnableButtonStudentRecordStatementOfAccount(true, _userInfo);

            this.ShowSearchResultDialog();
        }//-------------------------------

        //event is raised when the selected index is changed
        private void ctlManagerOnSemesterSelectedIndexChanged()
        {
            _dateStart = _studentManager.GetSemesterDateStart(_studentManager.GetSemesterSystemId(this.ctlManager.SchoolYearComboBox.SelectedIndex,
                this.ctlManager.SemesterComboBox.SelectedIndex)).ToShortDateString() + " 12:00:00 AM";
            _dateEnd = _studentManager.GetSemesterDateEnd(_studentManager.GetSemesterSystemId(this.ctlManager.SchoolYearComboBox.SelectedIndex,
                this.ctlManager.SemesterComboBox.SelectedIndex)).ToShortDateString() + " 11:59:59 PM";

            _frmStudentSearch.DisableEnableButtonStudentList(_userInfo, true);

            this.ShowSearchResultDialog();
        }//-----------------------------

        //event is raised when the selected index is changed
        private void ctlManagerOnCourseSelectedIndexChanged()
        {
            this.ShowSearchResultDialog();
        }//------------------------------

        //event is raised when the selected index is changed
        private void ctlManagerOnYearLevelSelectedIndexChanged()
        {
            this.ShowSearchResultDialog();
        }//----------------------------

        //event is raised when the control is clicked
        private void ctlManagerOnResetLinkClicked()
        {
            this.ctlManager.OnSchoolYearSelectedIndexChanged -=
                new RemoteClient.ControlStudentManagerSchoolYearSelectedIndexChanged(ctlManagerOnSchoolYearSelectedIndexChanged);
            this.ctlManager.OnCourseSelectedIndexChanged -=
                  new RemoteClient.ControlStudentManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnCourseSelectedIndexChanged);
            this.ctlManager.OnYearLevelSelectedIndexChanged -=
                new RemoteClient.ControlStudentManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnYearLevelSelectedIndexChanged);

            _studentManager.InitializeSchoolYearComboManager(this.ctlManager.SchoolYearComboBox);

            this.ctlManager.SemesterComboBox.Items.Clear();

            _studentManager.InitializeCourseCheckedListBox(this.ctlManager.CourseCheckedListBox);
            _studentManager.InitializeYearLevelCheckedListBox(this.ctlManager.YearLevelCheckedListBox);

            this.ctlManager.OnSchoolYearSelectedIndexChanged -=
                new RemoteClient.ControlStudentManagerSchoolYearSelectedIndexChanged(ctlManagerOnSchoolYearSelectedIndexChanged);
            this.ctlManager.OnCourseSelectedIndexChanged -=
                  new RemoteClient.ControlStudentManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnCourseSelectedIndexChanged);
            this.ctlManager.OnYearLevelSelectedIndexChanged -=
                new RemoteClient.ControlStudentManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnYearLevelSelectedIndexChanged);
            this.ctlManager.OnSchoolYearSelectedIndexChanged +=
                new RemoteClient.ControlStudentManagerSchoolYearSelectedIndexChanged(ctlManagerOnSchoolYearSelectedIndexChanged);
            this.ctlManager.OnCourseSelectedIndexChanged +=
                new RemoteClient.ControlStudentManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnCourseSelectedIndexChanged);
            this.ctlManager.OnYearLevelSelectedIndexChanged +=
                new RemoteClient.ControlStudentManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnYearLevelSelectedIndexChanged);

            _frmStudentSearch.WindowState = FormWindowState.Minimized;

            _dateStart = String.Empty;
            _dateEnd = String.Empty;

            _frmStudentSearch.DisableEnableButtonStudentRecordStatementOfAccount(false, _userInfo);
            _frmStudentSearch.DisableEnablePrintStudentMasterStudentEnrolmentList(false, _userInfo);
            _frmStudentSearch.DisableEnableButtonStudentList(_userInfo, false);
        }//----------------------------
        //############################################END CONTROLCLASSROOMSUBJECTMANAGER ctlManager EVENTS##########################################
        #endregion

        #region Programer-Define Void Procedures
        //this procedure shows the search result
        private void ShowSearchResultDialog()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;      

                String queryString = RemoteClient.ProcStatic.TrimStartEndString(ctlManager.GetSearchString);

                if (!String.IsNullOrEmpty(queryString))
                {
                    _frmStudentSearch.DataSource = _studentManager.GetSearchedStudentInformation(_userInfo, queryString,
                       _dateStart, _dateEnd, _studentManager.GetCourseYearLevelStringFormat(this.ctlManager.YearLevelCheckedListBox, false),
                       _studentManager.GetCourseYearLevelStringFormat(this.ctlManager.CourseCheckedListBox, true)); 
                }

                _frmStudentSearch.SetProgressBarValue(0);

                if (this.ctlManager.SchoolYearComboBox.SelectedIndex <= -1)
                {
                    _frmStudentSearch.DisableEnableButtonStudentRecordStatementOfAccount(false, _userInfo);
                }
                else
                {
                    _frmStudentSearch.DisableEnableButtonStudentRecordStatementOfAccount(true, _userInfo);
                }

                if ((this.ctlManager.SchoolYearComboBox.SelectedIndex >= 0 ||
                    this.ctlManager.SemesterComboBox.SelectedIndex >= 0) &&
                    (this.ctlManager.CourseCheckedListBox.CheckedIndices.Count != 0 &&
                    this.ctlManager.YearLevelCheckedListBox.CheckedIndices.Count != 0))
                {
                    _frmStudentSearch.DisableEnablePrintStudentMasterStudentEnrolmentList(true, _userInfo);
                }
                else
                {
                    _frmStudentSearch.DisableEnablePrintStudentMasterStudentEnrolmentList(false, _userInfo);
                }
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
