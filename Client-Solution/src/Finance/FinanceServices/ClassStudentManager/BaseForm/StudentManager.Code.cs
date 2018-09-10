using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FinanceServices
{
    partial class StudentManager
    {
        #region Class Data Member Declarations

        private CommonExchange.SysAccess _userInfo;
        private StudentLogic _studentManager;
        private StudentSearchList _frmStudentSearch;

        private String _dateStart = String.Empty;
        private String _dateEnd = String.Empty;
        #endregion

        #region Class Constructor

        public StudentManager(CommonExchange.SysAccess userInfo)
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
                new RemoteClient.ControlStudentManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnCourseYearLevelSelectedIndexChanged);
            this.ctlManager.OnYearLevelSelectedIndexChanged +=
                new RemoteClient.ControlStudentManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnCourseYearLevelSelectedIndexChanged);
            this.ctlManager.OnResetLinkClicked += new RemoteClient.ControlStudentManagerResetQueryLinkClicked(ctlManagerOnResetLinkClicked);
          }       
       
        #endregion

        #region Class Event Void Procedures

        //###########################################CLASS StudentManager EVENTS#####################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            try
            {
                _studentManager = new StudentLogic(_userInfo);

                _studentManager.InitializeSchoolYearComboManager(this.ctlManager.SchoolYearComboBox);
                _studentManager.InitializeCourseCheckedListBox(this.ctlManager.CourseCheckedListBox);
                _studentManager.InitializeYearLevelCheckedListBox(this.ctlManager.YearLevelCheckedListBox);

                _frmStudentSearch = new StudentSearchList();
                _frmStudentSearch.OnDoubleClickEnter += new SearchListDataGridDoubleClickEnter(_frmStudentSearchOnDoubleClickEnter);
                _frmStudentSearch.OnCreate += new StudentSearchListLinkCreateClick(_frmStudentSearchOnCreate);
                _frmStudentSearch.OnCashierUpdateClick += new SearchListDataGridContextMenuClick(_frmStudentSearchOnCashierUpdateClick);
                _frmStudentSearch.OnDataControllerUpdateClick += new SearchListDataGridContextMenuClick(_frmStudentSearchOnDataControllerUpdateClick);
                _frmStudentSearch.OnViewEnrolmentHistoryClick += new SearchListDataGridContextMenuClick(_frmStudentSearchOnViewEnrolmentHistoryClick);
                _frmStudentSearch.LocationPoint = new Point(14, 300);
                _frmStudentSearch.AdoptGridSize = false;
                _frmStudentSearch.MdiParent = this;
                _frmStudentSearch.DisableContextMenu(false, false, false, false);
                
                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_studentManager.ServerDateTime).ToString();

                Boolean dataController = false;
                Boolean cashierRegistrar = false;

                if (!(RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessStudentDataController(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessCashier(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessVpOfFinance(_userInfo) || 
                    RemoteServerLib.ProcStatic.IsSystemAccessCollegeRegistrar(_userInfo)))
                {
                    throw new Exception("You are not authorized to access this module.");
                }

                if (RemoteServerLib.ProcStatic.IsSystemAccessStudentDataController(_userInfo))
                {
                    _frmStudentSearch.DisableCreateLink();

                    dataController = true;
                }

                if (RemoteServerLib.ProcStatic.IsSystemAccessCashier(_userInfo) || RemoteServerLib.ProcStatic.IsSystemAccessVpOfFinance(_userInfo))
                {
                    cashierRegistrar = true;
                }

                if (RemoteServerLib.ProcStatic.IsSystemAccessCollegeRegistrar(_userInfo))
                {
                    _frmStudentSearch.DisableCreateLink();

                    cashierRegistrar = true;
                }

                if (RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo))
                {
                    _frmStudentSearch.DisableContextMenu(false, true, true, true);
                }
                else
                {
                    _frmStudentSearch.DisableContextMenu(false, dataController, cashierRegistrar, true);
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog("\n" + ex.Message, "Error Authenticating");

                this.Close();
            }
        }//---------------------------

        //event is raised when the class is closed
        private void ClassClosed(object sender, FormClosedEventArgs e)
        {
            _studentManager.DeleteImageDirectory(Application.StartupPath);
        }//-------------------------
        //###########################################END CLASS StudentManager EVENTS#####################################################

        //##########################################CLASS StudentSearchList EVENTS#######################################################
        //event is raised when the link open is clicked
        private void _frmStudentSearchOnCreate()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                CommonExchange.Student studentInfoTemp = new CommonExchange.Student();
                Boolean hasUpdated = false;

                using (StudentCashierCreate frmCreate = new StudentCashierCreate(_userInfo, _studentManager, false))
                {
                    _frmStudentSearch.WindowState = FormWindowState.Minimized;

                    frmCreate.ShowDialog(this);

                    if (frmCreate.HasCreated)
                    {
                        this.ShowSearchResultDialog();
                    }
                    else if (frmCreate.IsForStudentUpdate)
                    {
                        this.ShowUpdateStudentInformationDialog(frmCreate.StudentInfo);
                    }

                    studentInfoTemp = frmCreate.StudentInfo;
                    hasUpdated = frmCreate.HasCreated;

                    _frmStudentSearch.WindowState = FormWindowState.Normal;
                }

                if (hasUpdated &&
                        (RemoteServerLib.ProcStatic.IsSystemAccessCashier(_userInfo) || RemoteServerLib.ProcStatic.IsSystemAccessVpOfFinance(_userInfo)))
                {
                    this.ConfirmRedirect(studentInfoTemp);
                }

                this.ctlManager.SetFocusOnSearchTextBox();
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Creating A Student Information");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//----------------------

        //event is raised when the datagrid is double clicked or enter
        private void _frmStudentSearchOnDoubleClickEnter(String id)
        {
            if (RemoteServerLib.ProcStatic.IsSystemAccessStudentDataController(_userInfo))
            {
                this.ShowUpdateStudentInformationDialog(id, true);
            }
            else if (RemoteServerLib.ProcStatic.IsSystemAccessCashier(_userInfo) || RemoteServerLib.ProcStatic.IsSystemAccessVpOfFinance(_userInfo))
            {
                this.ShowUpdateStudentInformationDialog(id, false);
            }
            
        }//---------------------

        //this event is raised when the contextmenustrip is clicked
        private void _frmStudentSearchOnDataControllerUpdateClick(string id)
        {
            this.ShowUpdateStudentInformationDialog(id, true);
        }//--------------------------

        //this event is raised whent the contexmenustrip is clicked
        private void _frmStudentSearchOnViewEnrolmentHistoryClick(string id)
        {
            this.ShowStudentEnrolmentHistory(id);
        }//-------------------------------------

        //this event is raised when the contextmenustrip is clicked
        private void _frmStudentSearchOnCashierUpdateClick(string id)
        {
            this.ShowUpdateStudentInformationDialog(id, false);
        }//--------------------------
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
            _dateStart = _studentManager.GetSchoolYearDateStart(
                _studentManager.GetSchoolYearYearId(this.ctlManager.SchoolYearComboBox.SelectedIndex)).ToShortDateString() + " 12:00:00 AM";
            _dateEnd = _studentManager.GetSchoolYearDateEnd(
                _studentManager.GetSchoolYearYearId(this.ctlManager.SchoolYearComboBox.SelectedIndex)).ToShortDateString() + " 11:59:59 PM";

            _studentManager.InitializeSemesterCombo(this.ctlManager.SemesterComboBox, this.ctlManager.SchoolYearComboBox.SelectedIndex);
          
            this.ShowSearchResultDialog();           
        }//-------------------------------

        //event is raised when the selected index is changed
        private void ctlManagerOnSemesterSelectedIndexChanged()
        {
            _dateStart = _studentManager.GetSemesterDateStart(_studentManager.GetSemesterSystemId(this.ctlManager.SchoolYearComboBox.SelectedIndex,
                this.ctlManager.SemesterComboBox.SelectedIndex)).ToShortDateString() + " 12:00:00 AM";
            _dateEnd = _studentManager.GetSemesterDateEnd(_studentManager.GetSemesterSystemId(this.ctlManager.SchoolYearComboBox.SelectedIndex,
                this.ctlManager.SemesterComboBox.SelectedIndex)).ToShortDateString() + " 11:59:59 PM";

            this.ShowSearchResultDialog();
        }//--------------------------------

        //event is raised when the selected index is changed
        private void ctlManagerOnCourseYearLevelSelectedIndexChanged()
        {
            this.ShowSearchResultDialog();
        }//----------------------------

        //event is raised when the control is clicked
        private void ctlManagerOnResetLinkClicked()
        {
            this.ctlManager.OnCourseSelectedIndexChanged -=
                 new RemoteClient.ControlStudentManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnCourseYearLevelSelectedIndexChanged);
            this.ctlManager.OnYearLevelSelectedIndexChanged -=
                new RemoteClient.ControlStudentManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnCourseYearLevelSelectedIndexChanged);

            _studentManager.InitializeSchoolYearComboManager(this.ctlManager.SchoolYearComboBox);

            this.ctlManager.SemesterComboBox.Items.Clear();

            _studentManager.InitializeCourseCheckedListBox(this.ctlManager.CourseCheckedListBox);
            _studentManager.InitializeYearLevelCheckedListBox(this.ctlManager.YearLevelCheckedListBox);

            _dateStart = String.Empty;
            _dateEnd = String.Empty;

            this.ctlManager.OnCourseSelectedIndexChanged +=
                new RemoteClient.ControlStudentManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnCourseYearLevelSelectedIndexChanged);
            this.ctlManager.OnYearLevelSelectedIndexChanged +=
                new RemoteClient.ControlStudentManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnCourseYearLevelSelectedIndexChanged);

            _frmStudentSearch.WindowState = FormWindowState.Minimized;
        }//----------------------
        //############################################END CONTROLCLASSROOMSUBJECTMANAGER ctlManager EVENTS##########################################
        #endregion

        #region Programer-Define Void Procedures
        //this procedure shows the search result
        private void ShowSearchResultDialog()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string queryString = RemoteClient.ProcStatic.TrimStartEndString(ctlManager.GetSearchString);

                if(!string.IsNullOrEmpty(queryString))
                {
                    _frmStudentSearch.DataSource = _studentManager.GetSearchedStudentInformation(_userInfo, queryString,
                        _dateStart, _dateEnd, _studentManager.GetCourseYearLevelStringFormat(this.ctlManager.YearLevelCheckedListBox, false),
                        _studentManager.GetCourseYearLevelStringFormat(this.ctlManager.CourseCheckedListBox, true)); 
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

        //this procedure show the student enrolment history
        private void ShowStudentEnrolmentHistory(String id)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;                
                
                using (StudentEnrolmentHistory frmShow = new StudentEnrolmentHistory(_userInfo, _studentManager,
                    _studentManager.GetDetailsStudentInformation(_userInfo, id, Application.StartupPath), true))
                {
                    _frmStudentSearch.WindowState = FormWindowState.Minimized;

                    frmShow.ShowDialog(this);

                    _frmStudentSearch.WindowState = FormWindowState.Normal;

                    this.ctlManager.SetFocusOnSearchTextBox();
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Student Enrolment History Module");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//------------------------------

        //this procedure shows the view update student Information
        private void ShowUpdateStudentInformationDialog(String id, Boolean isAdvance)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                if (isAdvance)
                {
                    using (StudentGuidanceUpdate frmUpdate = new StudentGuidanceUpdate(_userInfo,
                        _studentManager.GetDetailsStudentInformation(_userInfo, id, Application.StartupPath), _studentManager))
                    {
                        _frmStudentSearch.WindowState = FormWindowState.Minimized;

                        frmUpdate.ShowDialog(this);

                        if (frmUpdate.HasUpDated)
                        {
                            this.ShowSearchResultDialog();
                        }

                        _frmStudentSearch.WindowState = FormWindowState.Normal;

                        this.ctlManager.SetFocusOnSearchTextBox();
                    }
                }
                else
                {
                    DataTable tempTable = new DataTable("");

                    CommonExchange.Student studentInfoTemp = new CommonExchange.Student();
                    Boolean hasUpdated = false;

                    using (StudentCashierUpdate frmUpdate = new StudentCashierUpdate(_userInfo,
                        _studentManager.GetDetailsStudentInformation(_userInfo, id, Application.StartupPath), _studentManager, false, false, ref tempTable))
                    {
                        _frmStudentSearch.WindowState = FormWindowState.Minimized;

                        frmUpdate.ShowDialog(this);

                        if (frmUpdate.HasUpDated)
                        {
                            this.ShowSearchResultDialog();
                        }
                        else if (frmUpdate.IsForStudentUpdate)
                        {
                            this.ShowUpdateStudentInformationDialog(frmUpdate.StudentInfo);
                        }

                        studentInfoTemp = frmUpdate.StudentInfo;
                        hasUpdated = frmUpdate.HasUpDated;

                        _frmStudentSearch.WindowState = FormWindowState.Normal;

                        this.ctlManager.SetFocusOnSearchTextBox();
                    }

                    if (hasUpdated && 
                        (RemoteServerLib.ProcStatic.IsSystemAccessCashier(_userInfo) || RemoteServerLib.ProcStatic.IsSystemAccessVpOfFinance(_userInfo)))
                    {
                        this.ConfirmRedirect(studentInfoTemp);
                    }

                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Update Student Information Module");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//----------------------

        //this procedure shows the view update student Information
        private void ShowUpdateStudentInformationDialog(CommonExchange.Student studentInfo)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Boolean isForStudentUpdate = false;

                DataTable tempTable = new DataTable("");

                using (StudentCashierUpdate frmUpdate = new StudentCashierUpdate(_userInfo, studentInfo, _studentManager, false, false, ref tempTable))
                {
                    _frmStudentSearch.WindowState = FormWindowState.Minimized;

                    frmUpdate.ShowDialog(this);

                    if (frmUpdate.HasUpDated)
                    {
                        this.ShowSearchResultDialog();

                        _frmStudentSearch.WindowState = FormWindowState.Normal;
                    }
                    else if (frmUpdate.IsForStudentUpdate)
                    {
                        isForStudentUpdate = true;

                        studentInfo = frmUpdate.StudentInfo;
                    }

                    this.ctlManager.SetFocusOnSearchTextBox();
                }

                if (isForStudentUpdate)
                {
                    this.ShowUpdateStudentInformationDialog(studentInfo);
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Update Student Information Module");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//----------------------

        //this procedure will asked the user he/she whants to redicrect the page into the student tab page
        private void ConfirmRedirect(CommonExchange.Student studentInfo)
        {
            String strMsg = "Do you want to be redirected to the STUDENT TAB of " + 
                RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(studentInfo.PersonInfo.LastName,
                studentInfo.PersonInfo.FirstName, studentInfo.PersonInfo.MiddleName) + "?";

            DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Redirect", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

            if (msgResult == DialogResult.Yes)
            {
                CashieringLogic cashieringManager = new CashieringLogic(_userInfo);

                String receiptDate = DateTime.Parse(String.IsNullOrEmpty(BaseServices.BaseServicesLogic.ReceiptDate) ?
                    _studentManager.ServerDateTime : BaseServices.BaseServicesLogic.ReceiptDate).ToLongDateString() + " 12:00:00 AM"; 

                using (StudentTab frmShow = new StudentTab(_userInfo, studentInfo, cashieringManager, receiptDate))
                {
                    frmShow.ShowDialog(this);
                }
            }
        }//----------------------
        #endregion
    }
}
