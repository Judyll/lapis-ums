using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace RegistrarServices
{
    partial class SchoolYearSemesterManager
    {
        #region Class General Variable Declarations
        private SchoolYearLogic _yearSemManager;
        private CommonExchange.SysAccess _userInfo;
        private SchoolYearSearchList _frmSchoolYearSearch;
        private SemesterSearchList _frmSemesterSearch;
        private Boolean _forSchoolYear;
        #endregion

        #region Class Constructor
        public SchoolYearSemesterManager(CommonExchange.SysAccess userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;

            this.Load += new EventHandler(ClassLoad);
            this.ctlManager.OnClose += new RemoteClient.ControlManagerCloseButtonClick(ctlManagerOnClose);
            this.ctlManager.OnRefresh += new RemoteClient.ControlManagerRefreshButtonClick(ctlManagerOnRefresh);
            this.ctlManager.OnTextBoxKeyUp += new RemoteClient.ControlManagerTextBoxSearchKeyUp(ctlManagerOnTextBoxKeyUp);
            this.ctlManager.OnPressEnter += new RemoteClient.ControlSchoolYearSemesterManagerPressEnter(ctlManagerOnPressEnter);
            this.ctlManager.OnModeOptionCheckedChanged += new RemoteClient.ControlSchoolYearSemesterManagerModeOptionCheckedChanged(ctlManagerOnModeOptionCheckedChanged);
        }
        
        #endregion

        #region Class Event Void Procedures

        //####################################################CLASS SchoolYearSemesterManager EVENTS###############################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            try
            {
                _yearSemManager = new SchoolYearLogic(_userInfo);

                _frmSchoolYearSearch = new SchoolYearSearchList();
                _frmSchoolYearSearch.OnDoubleClickEnter += new SearchListDataGridDoubleClickEnter(_frmSchoolYearSearchOnDoubleClickEnter);
                _frmSchoolYearSearch.OnOpen += new SchoolYearSearchListLinkOpenClick(_frmSchoolYearSearchOnOpen);
                _frmSchoolYearSearch.LocationPoint = new Point(50, 300);
                _frmSchoolYearSearch.AdoptGridSize = true;
                _frmSchoolYearSearch.MdiParent = this;

                _frmSemesterSearch = new SemesterSearchList();
                _frmSemesterSearch.OnDoubleClickEnter += new SearchListDataGridDoubleClickEnter(_frmSemesterSearchOnDoubleClickEnter);
                _frmSemesterSearch.LocationPoint = new Point(50, 300);
                _frmSemesterSearch.AdoptGridSize = true;
                _frmSemesterSearch.MdiParent = this;
                _frmSemesterSearch.DisableOpenSemeterLink();

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_yearSemManager.ServerDateTime).ToString();

                _forSchoolYear = true;

                if (!(RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessCollegeRegistrar(_userInfo)))
                {
                    throw new Exception("You are not authorized to access this module.");
                }

                if (!(CommonExchange.EnrolmentComponent.IncludeCollege || CommonExchange.EnrolmentComponent.IncludeGraduateSchoolDoctorate))
                {
                    ctlManager.DisableSemesterOption();
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog("\n" + ex.Message, "Error Authenticating");

                this.Close();
            }
            
        } //----------------------------------------
        //################################################END CLASS SchoolYearSemesterManager EVENTS################################################

        //############################################CONTROLSCHOOLYEARMANAGER ctlManager EVENTS##########################################
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

                _yearSemManager.RefreshSchoolYearSemesterData(_userInfo);

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_yearSemManager.ServerDateTime).ToString();

                this.ShowSearchResultDialog(false);
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Refreshing School Year and Semester Manager");
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
            this.ShowSearchResultDialog(true);
        } //--------------------------------

        //event is raised when the key is up on the search box
        private void ctlManagerOnTextBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (_forSchoolYear)
                {
                    _frmSchoolYearSearch.SelectFirstRowInDataGridView();
                }
                else
                {
                    _frmSemesterSearch.SelectFirstRowInDataGridView();
                }
            }
            else if (String.IsNullOrEmpty(RemoteClient.ProcStatic.TrimStartEndString(ctlManager.GetSearchString)))
            {
                if (_forSchoolYear)
                {
                    _frmSchoolYearSearch.WindowState = FormWindowState.Minimized;
                }
                else
                {
                    _frmSemesterSearch.WindowState = FormWindowState.Minimized;
                }

                this.ctlManager.SetFocusOnSearchTextBox();
            }

            
        } //--------------------------------

        //event is raised when the option button is changed
        private void ctlManagerOnModeOptionCheckedChanged(bool forSchoolYear)
        {
            _frmSchoolYearSearch.WindowState = FormWindowState.Minimized;
            _frmSchoolYearSearch.Hide();

            _frmSemesterSearch.WindowState = FormWindowState.Minimized;
            _frmSemesterSearch.Hide();

            _forSchoolYear = forSchoolYear;
        } //-------------------------------

        //#########################################END CONTROLSCHOOLYEARMANAGER ctlManager EVENTS#########################################

        //##########################################CLASS SchoolYearSearchList EVENTS#######################################################
        //event is raised when the link open is clicked
        private void _frmSchoolYearSearchOnOpen()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (SchoolYearOpen frmOpen = new SchoolYearOpen(_userInfo, _yearSemManager))
                {
                    _frmSchoolYearSearch.WindowState = FormWindowState.Minimized;

                    frmOpen.ShowDialog(this);

                    if (frmOpen.HasCreated)
                    {
                        this.ShowSearchResultDialog(false);
                    }

                    _frmSchoolYearSearch.WindowState = FormWindowState.Normal;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Opening A School Year");
            }
            finally
            {
                this.ctlManager.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }
            
        } //--------------------------------

        //event is raised when the datagrid is double clicked or entered
        private void _frmSchoolYearSearchOnDoubleClickEnter(string id)
        {
            this.ShowViewSchoolYearDialog();
            
        } //---------------------------------
        //##########################################END CLASS SchoolYearSearchList EVENTS###################################################

        //###############################################CLASS SemesterSearchList EVENTS######################################################
        //event is raised when the link open is clicked
        //private void _frmSemesterSearchOnOpen()
        //{
        //    try
        //    {
        //        this.Cursor = Cursors.WaitCursor;

        //        using (SemesterOpen frmOpen = new SemesterOpen(_userInfo, _yearSemManager))
        //        {
        //            _frmSchoolYearSearch.WindowState = FormWindowState.Minimized;

        //            frmOpen.ShowDialog(this);

        //            if (frmOpen.HasCreated)
        //            {
        //                this.ShowSearchResultDialog(false);
        //            }

        //            _frmSchoolYearSearch.WindowState = FormWindowState.Normal;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Opening A Semester");
        //    }
        //    finally
        //    {
        //        this.ctlManager.SetFocusOnSearchTextBox();

        //        this.Cursor = Cursors.Arrow;
        //    }

        //} //--------------------------------

        //event is raised when the datagrid is double clicked or entered
        private void _frmSemesterSearchOnDoubleClickEnter(string id)
        {
            this.ShowViewSemesterDialog();
        } //---------------------------------
        //##############################################END CLASS SemesterSearchList EVENTS###################################################
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure shows the search result
        private void ShowSearchResultDialog(Boolean isNewQuery)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                String queryString = RemoteClient.ProcStatic.TrimStartEndString(ctlManager.GetSearchString);

                if (!String.IsNullOrEmpty(queryString))
                {
                    if (_forSchoolYear)
                    {
                        _frmSchoolYearSearch.DataSource = _yearSemManager.GetSearchedSchoolYearInformation(_userInfo, queryString, isNewQuery);
                    }
                    else
                    {
                        _frmSemesterSearch.DataSource = _yearSemManager.GetSearchedSemesterInformation(_userInfo, queryString, isNewQuery);
                    }                    
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

        } //--------------------------

        //this procedure shows the view school year dialog
        private void ShowViewSchoolYearDialog()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (SchoolYearView frmView = new SchoolYearView(_yearSemManager.GetDetailsSchoolYearInformation(_frmSchoolYearSearch.PrimaryId)))
                {
                    _frmSchoolYearSearch.WindowState = FormWindowState.Minimized;

                    frmView.ShowDialog(this);

                    _frmSchoolYearSearch.WindowState = FormWindowState.Normal;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Viewing A School Year");
            }
            finally
            {
                this.ctlManager.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }
        } //--------------------------

        //this procedure shows the view school semester dialog
        private void ShowViewSemesterDialog()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (SemesterView frmView = new SemesterView(_yearSemManager.GetDetailsSemesterInformation(_frmSemesterSearch.PrimaryId)))
                {
                    _frmSemesterSearch.WindowState = FormWindowState.Minimized;

                    frmView.ShowDialog(this);

                    _frmSemesterSearch.WindowState = FormWindowState.Normal;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Viewing A Semester");
            }
            finally
            {
                this.ctlManager.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }
        } //-----------------------------------

        #endregion
    }
}
