using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class ScholarshipManager
    {
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private ScholarshipLogic _scholarshipManager;
        private SearchListStudentScholarship _frmStudentScholarshipSearch;
       
        private String _dateStart = String.Empty;
        private String _dateEnd = String.Empty;

        private Boolean _isRecordLocked = false;
        #endregion

        #region Class Constructor
        public ScholarshipManager(CommonExchange.SysAccess userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;

            this.Load += new EventHandler(ClassLoad);
            this.ctlManager.OnClose += new RemoteClient.ControlManagerCloseButtonClick(ctlManagerOnClose);
            this.ctlManager.OnRefresh += new RemoteClient.ControlManagerRefreshButtonClick(ctlManagerOnRefresh);
            this.ctlManager.OnTextBoxKeyUp += new RemoteClient.ControlManagerTextBoxSearchKeyUp(ctlManagerOnTextBoxKeyUp);
            this.ctlManager.OnPressEnter += new RemoteClient.ControlScholarshipManagerPressEnter(ctlManagerOnPressEnter);
            this.ctlManager.OnSchoolYearSelectedIndexChanged += 
                new RemoteClient.ControlScholarshipManagerSchoolYearSelectedIndexChanged(ctlManagerOnSchoolYearSelectedIndexChanged);
            this.ctlManager.OnSemesterSelectedIndexChanged += 
                new RemoteClient.ControlScholarshipManagerSemesterSelectedIndexChanged(ctlManagerOnSemesterSelectedIndexChanged);
            this.ctlManager.OnDepartmentSelectedIndexChanged +=
                new RemoteClient.ControlScholarshipManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnScholarshipYearLevelDepartmentSelectedIndexChanged);
            this.ctlManager.OnYearLevelSelectedIndexChanged += new
                RemoteClient.ControlScholarshipManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnScholarshipYearLevelDepartmentSelectedIndexChanged);
            this.ctlManager.OnScholarshipSelectedIndexChanged += 
                new RemoteClient.ControlScholarshipManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnScholarshipYearLevelDepartmentSelectedIndexChanged);
            this.ctlManager.OnResetLinkClicked += new RemoteClient.ControlScholarshipManagerResetQueryLinkClicked(ctlManagerOnResetLinkClicked);
            this.ctlManager.OnScholarshipInformationClick += 
                new RemoteClient.ControlScholarshipManagerScholarshipButtonClick(ctlManagerOnScholarshipInformationClick);
        }
        #endregion

        #region Class Event Void Procedures
        //###########################################CLASS ScholarshipManager EVENTS#####################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            try
            {
                if (!(RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessVpOfAcademicAffairs(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessSecretaryOftheVpOfAcademicAffairs(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessCollegeRegistrar(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessCashier(_userInfo)))
                {
                    throw new Exception("You are not authorized to access this module.");
                }

                if (RemoteServerLib.ProcStatic.IsSystemAccessCashier(_userInfo))
                {
                    this.ctlManager.DisableScholarshipButton(true);
                }

                _scholarshipManager = new ScholarshipLogic(_userInfo);

                _frmStudentScholarshipSearch = new SearchListStudentScholarship(_userInfo, _scholarshipManager);
                _frmStudentScholarshipSearch.OnCreate += new StudentSearchButtonCreateSchoolshipClick(_frmStudentScholarshipSearchOnCreate);
                _frmStudentScholarshipSearch.OnDoubleClickEnter +=
                    new SearchListDataGridDoubleClickEnterStudentScholarship(_frmStudentScholarshipSearchOnDoubleClickEnter);
                _frmStudentScholarshipSearch.LocationPoint = new Point(14, 300);
                _frmStudentScholarshipSearch.AdoptGridSize = false;
                _frmStudentScholarshipSearch.MdiParent = this;

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_scholarshipManager.ServerDateTime).ToString();

                _scholarshipManager.InitializeSchoolYearComboManager(this.ctlManager.SchoolYearComboBox);
                _scholarshipManager.InitializeDepartmentCheckedListBox(this.ctlManager.DepartmentCheckedListBox);
                _scholarshipManager.InitializeYearLevelCheckedListBox(this.ctlManager.YearLevelCheckedListBox);
                _scholarshipManager.InitializeScholarshipListBox(this.ctlManager.ScholarshipCheckedListBox);

                
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog("\n" + ex.Message, "Error Authenticating");

                this.Close();
            }
        }//------------------------
        //###########################################CLASS ScholarshipManager EVENTS#####################################################


        //############################################CONTROLScholarship ctlManager EVENTS##########################################
        //event is raised when the button is click
        private void ctlManagerOnClose()
        {
            this.Close();
        }//--------------------

        //event is raised whe the button is click
        private void ctlManagerOnRefresh()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _scholarshipManager.RefreshScholarshipData(_userInfo);

                _scholarshipManager.InitializeSchoolYearComboManager(this.ctlManager.SchoolYearComboBox);
                _scholarshipManager.InitializeDepartmentCheckedListBox(this.ctlManager.DepartmentCheckedListBox);
                _scholarshipManager.InitializeYearLevelCheckedListBox(this.ctlManager.YearLevelCheckedListBox);
                _scholarshipManager.InitializeScholarshipListBox(this.ctlManager.ScholarshipCheckedListBox);

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_scholarshipManager.ServerDateTime).ToString();

                this.ShowSearchResultDialog();
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Refreshing Scholarship Data Manager");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//-----------------------

        //event is raised when the key is up
        private void ctlManagerOnTextBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                _frmStudentScholarshipSearch.SelectFirstRowInDataGridView();
            }
            else if (string.IsNullOrEmpty(RemoteClient.ProcStatic.TrimStartEndString(ctlManager.GetSearchString)))
            {
                _frmStudentScholarshipSearch.WindowState = FormWindowState.Minimized;

                this.ctlManager.SetFocusOnSearchTextBox();
            }
        }//-----------------------

        //event is raised when the enter key is pressed
        private void ctlManagerOnPressEnter(object sender, KeyEventArgs e)
        {
            this.ShowSearchResultDialog();
        }//------------------------

        //event is raised when the selected index is changed
        private void ctlManagerOnSchoolYearSelectedIndexChanged()
        {
            _dateStart = _scholarshipManager.GetSchoolYearDateStart(
                _scholarshipManager.GetSchoolYearYearId(this.ctlManager.SchoolYearIndex)).ToShortDateString() + " 12:00:00 AM";
            _dateEnd = _scholarshipManager.GetSchoolYearDateEnd(
                _scholarshipManager.GetSchoolYearYearId(this.ctlManager.SchoolYearIndex)).ToShortDateString() + " 11:59:59 PM";

            _scholarshipManager.InitializeSemesterCombo(this.ctlManager.SemesterComboBox, this.ctlManager.SchoolYearIndex);

            this.ShowSearchResultDialog();

            this.IsRecordLocked();
        }//------------------

        //event is raised when the selected index is changed
        private void ctlManagerOnSemesterSelectedIndexChanged()
        {
            _dateStart = _scholarshipManager.GetSemesterDateStart(
                _scholarshipManager.GetSemesterSystemId(this.ctlManager.SchoolYearIndex, this.ctlManager.SemesterIndex)).ToShortDateString() + " 12:00:00 AM";
            _dateEnd = _scholarshipManager.GetSemesterDateEnd(
                _scholarshipManager.GetSemesterSystemId(this.ctlManager.SchoolYearIndex, this.ctlManager.SemesterIndex)).ToShortDateString() + " 11:59:59 PM";

            this.ShowSearchResultDialog();

            this.IsRecordLocked();
        }//---------------------

        //event is raised when the selected index is changed
        private void ctlManagerOnScholarshipYearLevelDepartmentSelectedIndexChanged()
        {
            this.ShowSearchResultDialog();
        }//-------------------------

        //event is raised when the link is clicked
        private void ctlManagerOnResetLinkClicked()
        {
            this.ctlManager.OnDepartmentSelectedIndexChanged -=
                new RemoteClient.ControlScholarshipManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnScholarshipYearLevelDepartmentSelectedIndexChanged);
            this.ctlManager.OnYearLevelSelectedIndexChanged -= new
                RemoteClient.ControlScholarshipManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnScholarshipYearLevelDepartmentSelectedIndexChanged);
            this.ctlManager.OnScholarshipSelectedIndexChanged -=
                new RemoteClient.ControlScholarshipManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnScholarshipYearLevelDepartmentSelectedIndexChanged);

            _scholarshipManager.InitializeSchoolYearComboManager(this.ctlManager.SchoolYearComboBox);

            _scholarshipManager.InitializeDepartmentCheckedListBox(this.ctlManager.DepartmentCheckedListBox);
            _scholarshipManager.InitializeYearLevelCheckedListBox(this.ctlManager.YearLevelCheckedListBox);
            _scholarshipManager.InitializeScholarshipListBox(this.ctlManager.ScholarshipCheckedListBox);            

            this.ctlManager.OnDepartmentSelectedIndexChanged +=
                new RemoteClient.ControlScholarshipManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnScholarshipYearLevelDepartmentSelectedIndexChanged);
            this.ctlManager.OnYearLevelSelectedIndexChanged += new
                RemoteClient.ControlScholarshipManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnScholarshipYearLevelDepartmentSelectedIndexChanged);
            this.ctlManager.OnScholarshipSelectedIndexChanged +=
                new RemoteClient.ControlScholarshipManagerCheckedListBoxSelectedIndexChanged(ctlManagerOnScholarshipYearLevelDepartmentSelectedIndexChanged);

            _frmStudentScholarshipSearch.WindowState = FormWindowState.Minimized;
        }//----------------------

        //event is raised when the control is clicked
        private void ctlManagerOnScholarshipInformationClick()
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                using (ScholarshipSearchOnTextBoxList frmShow = new ScholarshipSearchOnTextBoxList(_userInfo, _scholarshipManager))
                {                   
                    frmShow.AdoptGridSize = true;
                    frmShow.Location = new Point(14, 200);
                    frmShow.ShowDialog(this);
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Laoding");
            }

            this.Cursor = Cursors.Arrow;
        }//-----------------------
        //############################################CONTROLScholarship ctlManager EVENTS##########################################

        //############################################STUDENTSCHLARSHPSEARCH _frmScholarshiopSearch EVENTS##########################################
        //event is reais whent the control is clicked
        private void _frmStudentScholarshipSearchOnCreate()
        {
            using (StudentScholarshipCreate frmCreate = new StudentScholarshipCreate(_userInfo, _scholarshipManager))
            {
                frmCreate.ShowDialog(this);

                if (frmCreate.HasCreated)
                {
                    this.ShowSearchResultDialog();
                }
            }
        }//--------------------

        //event is raised whe  the conrol is couble clicked        
        private void _frmStudentScholarshipSearchOnDoubleClickEnter(string id)
        {
            try
            {
                using (StudentScholarshipUpdate frmUpdate = new StudentScholarshipUpdate(_userInfo,
                    _scholarshipManager.GetDetailsStudentInformation(_userInfo, _frmStudentScholarshipSearch.PrimaryId, Application.StartupPath, false),
                    _scholarshipManager.GetDetailsStudentScholarshipInformation(_frmStudentScholarshipSearch.PrimaryId), _scholarshipManager, _isRecordLocked))
                {
                    frmUpdate.ShowDialog(this);

                    if (frmUpdate.HasUpDated || frmUpdate.HasDeleted)
                    {
                        this.ShowSearchResultDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }
        }
        //############################################END STUDENTSCHLARSHPSEARCH _frmScholarshiopSearch EVENTS##########################################
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
                    _frmStudentScholarshipSearch.DataSource = _scholarshipManager.GetSearchedStudentScholarship(_userInfo, queryString, _dateStart, _dateEnd,
                        _scholarshipManager.GetDepartmentYearLevelScholarshipStringFormat(this.ctlManager.ScholarshipCheckedListBox, false, false, true),
                        _scholarshipManager.GetDepartmentYearLevelScholarshipStringFormat(this.ctlManager.DepartmentCheckedListBox, false, true, false),
                        _scholarshipManager.GetDepartmentYearLevelScholarshipStringFormat(this.ctlManager.YearLevelCheckedListBox, true, false, false));
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

        //this procedure will set record locked
        private void IsRecordLocked()
        {
            if (RemoteClient.ProcStatic.IsRecordLocked(DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd), DateTime.Parse(_scholarshipManager.ServerDateTime)) &&
                RemoteClient.ProcStatic.IsRecordLocked(DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd), DateTime.Parse(_scholarshipManager.ServerDateTime),
                (Int32)CommonExchange.SystemRange.MonthAllowance))            
            {
                _isRecordLocked = true;

                _frmStudentScholarshipSearch.IsVisibleButtonCreate(false);
            }
            else
            {
                _isRecordLocked = false;

                _frmStudentScholarshipSearch.IsVisibleButtonCreate(true);
            }
        }//--------------------------------
        #endregion
    }
}
