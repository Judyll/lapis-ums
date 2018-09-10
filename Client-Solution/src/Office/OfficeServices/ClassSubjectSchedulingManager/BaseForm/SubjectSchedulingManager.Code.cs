using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace OfficeServices
{
    partial class SubjectSchedulingManager
    {
        #region Class Data Member Declarations
        private SubjectSchedulingLogic _scheduleManager;
        private CommonExchange.SysAccess _userInfo;
        private SubjectScheduleSearchList _frmSubjectScheduleSearch;

        private String _dateStart = String.Empty;
        private String _dateEnd = String.Empty;
        #endregion

        #region Class Constructor
        public SubjectSchedulingManager(CommonExchange.SysAccess userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;

            this.Load += new EventHandler(ClassLoad);
            this.ctlManager.OnClose += new RemoteClient.ControlManagerCloseButtonClick(ctlManagerOnClose);
            this.ctlManager.OnRefresh += new RemoteClient.ControlManagerRefreshButtonClick(ctlManagerOnRefresh);
            this.ctlManager.OnPressEnter += new RemoteClient.ControlSubjectSchedulingManagerPressEnter(ctlManagerOnPressEnter);
            this.ctlManager.OnTextBoxKeyUp += new RemoteClient.ControlManagerTextBoxSearchKeyUp(ctlManagerOnTextBoxKeyUp);
            this.ctlManager.OnOptionCheckedChanged += new RemoteClient.ControlSubjectSchedulingManagerOptionCheckedChanged(ctlManagerOnOptionCheckedChanged);
            this.ctlManager.OnSchoolYearSelectedIndexChanged += 
                new RemoteClient.ControlSubjectSchedulingManagerSchoolYearSelectedIndexChanged(ctlManagerOnSchoolYearSelectedIndexChanged);
            this.ctlManager.OnSemesterSelectedIndexChanged += 
                new RemoteClient.ControlSubjectSchedulingManagerSemesterSelectedIndexChanged(ctlManagerOnSemesterSelectedIndexChanged);
        }

        #endregion

        #region Class Event Void Procedures
        //####################################################CLASS SubjectSchedulingManager EVENTS###############################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            try
            {
                if (!(RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) ||
                   RemoteServerLib.ProcStatic.IsSystemAccessVpOfAcademicAffairs(_userInfo) ||
                   RemoteServerLib.ProcStatic.IsSystemAccessOfficeUser(_userInfo) ||
                   RemoteServerLib.ProcStatic.IsSystemAccessCashier(_userInfo) ||
                   RemoteServerLib.ProcStatic.IsSystemAccessVpOfFinance(_userInfo)))
                {
                    throw new Exception("You are not authorized to access this module.");
                }

                _scheduleManager = new SubjectSchedulingLogic(_userInfo);

                _frmSubjectScheduleSearch = new SubjectScheduleSearchList();
                _frmSubjectScheduleSearch.OnDoubleClickEnter += new SearchListDataGridDoubleClickEnter(_frmSubjectScheduleSearchOnDoubleClickEnter);
                _frmSubjectScheduleSearch.OnCreate += new SubjectScheduleSearchListLinkCreateClick(frmSubjectScheduleSearchOnCreate);
                _frmSubjectScheduleSearch.OnPrint += new SubjectScheduleSearchListLinkCreateClick(_frmSubjectScheduleSearchOnPrint);
                _frmSubjectScheduleSearch.LocationPoint = new Point(10, 400);
                _frmSubjectScheduleSearch.AdoptGridSize = false;
                _frmSubjectScheduleSearch.MdiParent = this;

                if (RemoteServerLib.ProcStatic.IsSystemAccessCashier(_userInfo) || RemoteServerLib.ProcStatic.IsSystemAccessVpOfFinance(_userInfo))
                {
                    _frmSubjectScheduleSearch.SetCreateButton(false);
                }                

                _scheduleManager.InitializeSchoolYearCombo(this.ctlManager.SchoolYearComboBox);               

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_scheduleManager.ServerDateTime).ToString();               
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog("\n" + ex.Message, "Error Authenticating");

                this.Close();
            }

        }
        //----------------------------------------
        //################################################END CLASS SubjectSchedulingManager EVENTS################################################

        //############################################CONTROLSPECIALCLASSMANAGER ctlManager EVENTS##########################################
        //event is raised when the button is click
        private void ctlManagerOnClose()
        {
            this.Close();
        } //---------------------------------

        //event is raised when the refresh button is clicked
        private void ctlManagerOnRefresh()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _scheduleManager.RefreshSpecialClassData(_userInfo);

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_scheduleManager.ServerDateTime).ToString();
                
                this.ShowSearchResultDialog();
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Refreshing Subject Scheduling Manager");
            }
            finally
            {
                this.ctlManager.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }
        } //----------------------------

        //event is raised when the user press the enter key
        private void ctlManagerOnPressEnter(object sender, KeyEventArgs e)
        {
            this.ShowSearchResultDialog();
        } //--------------------------------

        //event is raised when the key is up on the search box
        private void ctlManagerOnTextBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                _frmSubjectScheduleSearch.SelectFirstRowInDataGridView();
            }
            else if (String.IsNullOrEmpty(RemoteClient.ProcStatic.TrimStartEndString(ctlManager.GetSearchString)))
            {
                _frmSubjectScheduleSearch.WindowState = FormWindowState.Minimized;

                this.ctlManager.SetFocusOnSearchTextBox();
            }
        } //--------------------------------

        //event is raised when the semester selected index is changed
        private void ctlManagerOnSemesterSelectedIndexChanged()
        {           
            _dateStart = _scheduleManager.GetSemesterDateStart(_scheduleManager.GetSemesterSystemId(this.ctlManager.SchoolYearIndex,
                            this.ctlManager.SemesterIndex)).ToShortDateString() + " 12:00:00 AM";
            _dateEnd = _scheduleManager.GetSemesterDateEnd(_scheduleManager.GetSemesterSystemId(this.ctlManager.SchoolYearIndex,
                this.ctlManager.SemesterIndex)).ToShortDateString() + " 11:59:59 PM";
           
            this.ShowSearchResultDialog();
        } //-----------------------------------

        //event is raised when the school year selected index is changed
        private void ctlManagerOnSchoolYearSelectedIndexChanged()
        {
            _dateStart = _scheduleManager.GetSchoolYearDateStart(_scheduleManager.GetSchoolYearYearId(ctlManager.SchoolYearIndex)).ToShortDateString() +
                    " 12:00:00 AM";
            _dateEnd = _scheduleManager.GetSchoolYearDateEnd(_scheduleManager.GetSchoolYearYearId(ctlManager.SchoolYearIndex)).ToShortDateString() +
                " 11:59:59 PM";

            _scheduleManager.InitializeSemesterCombo(this.ctlManager.SemesterComboBox, this.ctlManager.SchoolYearIndex);

            this.ShowSearchResultDialog();

        } //-----------------------------------

        //event is raised when the option checked is changed
        private void ctlManagerOnOptionCheckedChanged()
        {
            if (this.ctlManager.SchoolYearIndex != -1)
            {
                _dateStart = _scheduleManager.GetSchoolYearDateStart(_scheduleManager.GetSchoolYearYearId(ctlManager.SchoolYearIndex)).ToShortDateString() +
                    " 12:00:00 AM";
                _dateEnd = _scheduleManager.GetSchoolYearDateEnd(_scheduleManager.GetSchoolYearYearId(ctlManager.SchoolYearIndex)).ToShortDateString() + 
                    " 11:59:59 PM";
                             
                _scheduleManager.InitializeSemesterCombo(this.ctlManager.SemesterComboBox, this.ctlManager.SchoolYearIndex);

                this.ShowSearchResultDialog();
            }
        } //-------------------------------

        //#########################################END CONTROLSPECIALCLASSMANAGER ctlManager EVENTS#########################################

        //##########################################CLASS SubjectScheduleSearchList EVENTS#######################################################
        //event is raised when the link open is clicked
        private void frmSubjectScheduleSearchOnCreate()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (SubjectScheduleCreate frmCreate = new SubjectScheduleCreate(_userInfo, _scheduleManager))
                {
                    _frmSubjectScheduleSearch.WindowState = FormWindowState.Minimized;

                    frmCreate.ShowDialog(this);

                    if (frmCreate.HasCreated)
                    {           
                        this.ShowSearchResultDialog();
                    }

                    _frmSubjectScheduleSearch.WindowState = FormWindowState.Normal;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Creating A Subject Schedule");
            }
            finally
            {
                this.ctlManager.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }
        }//--------------------------------

        //event is raised when the datagrid is double clicked or entered
        private void _frmSubjectScheduleSearchOnDoubleClickEnter(String id)
        {
            this.ShowUpdateSubjectScheduleDialog(id);
        }//---------------------------------

        //event is raised when the print button is clicked
        private void _frmSubjectScheduleSearchOnPrint()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                String sem = this.ctlManager.SemesterIndex != -1 ? " - " + this.ctlManager.SemesterComboBox.Text : String.Empty;

                _scheduleManager.PrintScheduleDetailsList(_userInfo, this.ctlManager.SchoolYearComboBox.Text + sem);

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Printing");
            }
        }
        //##########################################END CLASS SubjectScheduleSearchList EVENTS###################################################
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure updates the special class data by date start and date end
        private void SelectByDateStartEndScheduleInformationDetails(String queryString)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (this.ctlManager.SchoolYearIndex != -1)
                {
                    _scheduleManager.SelectByDateStartEndScheduleInformationDetails(_userInfo, queryString, _dateStart, 
                        _dateEnd, this.ctlManager.IsMarkedDeleted);
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
        }//--------------------------------

        //this procedure shows the search result
        private void ShowSearchResultDialog()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                String queryString = RemoteClient.ProcStatic.TrimStartEndString(ctlManager.GetSearchString);

                if (!String.IsNullOrEmpty(queryString) && this.ctlManager.SchoolYearIndex != -1 )
                {
                    this.SelectByDateStartEndScheduleInformationDetails(queryString);
                  
                    _frmSubjectScheduleSearch.DataSource = _scheduleManager.GetSearchedScheduleInformationDetails();
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
        }//--------------------------

        //this procedure shows the subject schedule update dialog
        private void ShowUpdateSubjectScheduleDialog(String id)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (SubjectScheduleUpdate frmUpdate = new SubjectScheduleUpdate(_userInfo, _scheduleManager.GetDetailsScheduleInformation(id), 
                    _scheduleManager))
                {
                    _frmSubjectScheduleSearch.WindowState = FormWindowState.Minimized;

                    frmUpdate.ShowDialog(this);
                                                                     
                    if (frmUpdate.HasUpdated || frmUpdate.HasDeleted)
                    {
                        this.ShowSearchResultDialog();
                    }

                    _frmSubjectScheduleSearch.WindowState = FormWindowState.Normal;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Update Subject Schedule Module");
            }
            finally
            {
                this.ctlManager.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }
        }//-------------------------

        #endregion
    }
}
