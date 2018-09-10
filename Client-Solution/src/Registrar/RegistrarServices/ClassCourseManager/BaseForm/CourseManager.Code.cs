using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace RegistrarServices
{
    partial class CourseManager
    {
        #region Class General Variable Declarations
        private CourseLogic _courseManager;
        private CommonExchange.SysAccess _userInfo;
        private ClassroomSearchList _frmClassroomSearch;
        private SubjectSearchList _frmSubjectSearch;
        private CourseSearchList _frmCourseSearch;
        private ClientExchange.RoomSubjectCourseFilter _courseFilter;
        #endregion

        #region Class Constructor
        public CourseManager(CommonExchange.SysAccess userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;

            this.Load += new EventHandler(ClassLoad);
            this.ctlManager.OnClose += new RemoteClient.ControlManagerCloseButtonClick(ctlManagerOnClose);
            this.ctlManager.OnRefresh += new RemoteClient.ControlManagerRefreshButtonClick(ctlManagerOnRefresh);
            this.ctlManager.OnPressEnter += new RemoteClient.ControlClassroomSubjectManagerPressEnter(ctlManagerOnPressEnter);
            this.ctlManager.OnTextBoxKeyUp += new RemoteClient.ControlManagerTextBoxSearchKeyUp(ctlManagerOnTextBoxKeyUp);
            this.ctlManager.OnModeOptionCheckedChanged += new RemoteClient.ControlClassroomSubjectManagerModeOptionCheckedChanged(ctlManagerOnModeOptionCheckedChanged);            
        }      
        
        #endregion

        #region Class Event Void Procedures

        //####################################################CLASS ClassroomSubjectManager EVENTS###############################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            try
            {
                _courseManager = new CourseLogic(_userInfo);

                _frmClassroomSearch = new ClassroomSearchList();
                _frmClassroomSearch.OnDoubleClickEnter += new SearchListDataGridDoubleClickEnter(_frmClassroomSearchOnDoubleClickEnter);
                _frmClassroomSearch.OnCreate += new ClassroomSearchListLinkCreateClick(_frmClassroomSearchOnCreate);
                _frmClassroomSearch.LocationPoint = new Point(10, 360);
                _frmClassroomSearch.AdoptGridSize = true;
                _frmClassroomSearch.MdiParent = this;

                _frmSubjectSearch = new SubjectSearchList();
                _frmSubjectSearch.OnDoubleClickEnter += new SearchListDataGridDoubleClickEnter(_frmSubjectSearchOnDoubleClickEnter);
                _frmSubjectSearch.OnCreate += new SubjectSearchListLinkCreateClick(_frmSubjectSearchOnCreate);
                _frmSubjectSearch.LocationPoint = new Point(10, 360);
                _frmSubjectSearch.AdoptGridSize = false;
                _frmSubjectSearch.MdiParent = this;

                _frmCourseSearch = new CourseSearchList();
                _frmCourseSearch.OnDoubleClickEnter += new SearchListDataGridDoubleClickEnter(_frmCourseSearchOnDoubleClickEnter);
                _frmCourseSearch.OnCreate += new CourseSearchListLinkCreateClick(_frmCourseSearchOnCreate);
                _frmCourseSearch.LocationPoint = new Point(50, 360);
                _frmCourseSearch.AdoptGridSize = true;
                _frmCourseSearch.MdiParent = this;                

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_courseManager.ServerDateTime).ToString();

                _courseFilter = new ClientExchange.RoomSubjectCourseFilter();
                _courseFilter.ForSubject = true;

                if (!(RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessCollegeRegistrar(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessHighSchoolGradeSchoolRegistrar(_userInfo)))
                {
                    throw new Exception("You are not authorized to access this module.");
                }                
                else if (RemoteServerLib.ProcStatic.IsSystemAccessHighSchoolGradeSchoolRegistrar(_userInfo))
                {
                    _frmCourseSearch.DisableCreateLink();
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog("\n" + ex.Message, "Error Authenticating");

                this.Close();
            }

        } //----------------------------------------
        //################################################END CLASS ClassroomSubjectManager EVENTS################################################

        //############################################CONTROLCLASSROOMSUBJECTMANAGER ctlManager EVENTS##########################################
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

                _courseManager.RefreshClassroomSubjectData(_userInfo);

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_courseManager.ServerDateTime).ToString();

                this.ShowSearchResultDialog(true);
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Refreshing Classroom and Subject Manager");
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
                if (_courseFilter.ForRoom)
                {
                    _frmClassroomSearch.SelectFirstRowInDataGridView();
                }
                else if (_courseFilter.ForSubject)
                {
                    _frmSubjectSearch.SelectFirstRowInDataGridView();
                }
                else if (_courseFilter.ForCourse)
                {
                    _frmCourseSearch.SelectFirstRowInDataGridView();
                }
            }
            else if (String.IsNullOrEmpty(RemoteClient.ProcStatic.TrimStartEndString(ctlManager.GetSearchString)))
            {
                if (_courseFilter.ForRoom)
                {
                    _frmClassroomSearch.WindowState = FormWindowState.Minimized;
                }
                else if (_courseFilter.ForSubject)
                {
                    _frmSubjectSearch.WindowState = FormWindowState.Minimized;
                }
                else if (_courseFilter.ForCourse)
                {
                    _frmCourseSearch.WindowState = FormWindowState.Minimized;
                }

                this.ctlManager.SetFocusOnSearchTextBox();
            }
        } //--------------------------------

        //event is raised when the option button is changed
        private void ctlManagerOnModeOptionCheckedChanged(ClientExchange.RoomSubjectCourseFilter courseFilter)
        {
            _frmClassroomSearch.WindowState = FormWindowState.Minimized;
            _frmClassroomSearch.Hide();

            _frmSubjectSearch.WindowState = FormWindowState.Minimized;
            _frmSubjectSearch.Hide();

            _frmCourseSearch.WindowState = FormWindowState.Minimized;
            _frmCourseSearch.Hide();

            _courseFilter = courseFilter;
        } //-------------------------------

        //#########################################END CONTROLCLASSROOMSUBJECTMANAGER ctlManager EVENTS#########################################

        //##########################################CLASS ClassroomSearchList EVENTS#######################################################
        //event is raised when the link open is clicked
        private void _frmClassroomSearchOnCreate()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (ClassroomCreate frmCreate = new ClassroomCreate(_userInfo, _courseManager))
                {
                    _frmClassroomSearch.WindowState = FormWindowState.Minimized;

                    frmCreate.ShowDialog(this);

                    if (frmCreate.HasCreated)
                    {
                        this.ShowSearchResultDialog(false);
                    }

                    _frmClassroomSearch.WindowState = FormWindowState.Normal;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Creating A Classroom Information");
            }
            finally
            {
                this.ctlManager.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }
        } //--------------------------------

        //event is raised when the datagrid is double clicked or entered
        private void _frmClassroomSearchOnDoubleClickEnter(string id)
        {
            this.ShowUpdateClassroomDialog(id);
        } //---------------------------------
        //##########################################END CLASS ClassroomSearchList EVENTS###################################################

        //##########################################CLASS SubjectSearchList EVENTS#######################################################
        //event is raised when the link open is clicked
        private void _frmSubjectSearchOnCreate()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (SubjectCreate frmCreate = new SubjectCreate(_userInfo, _courseManager))
                {
                    _frmSubjectSearch.WindowState = FormWindowState.Minimized;

                    frmCreate.ShowDialog(this);

                    if (frmCreate.HasCreated)
                    {
                        this.ShowSearchResultDialog(false);
                    }

                    _frmSubjectSearch.WindowState = FormWindowState.Normal;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Creating A Subject Information");
            }
            finally
            {
                this.ctlManager.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }
        } //--------------------------------

        //event is raised when the datagrid is double clicked or entered
        private void _frmSubjectSearchOnDoubleClickEnter(string id)
        {
            this.ShowUpdateSubjectDialog(id);
        } //---------------------------------
        //##########################################END CLASS SubjectSearchList EVENTS###################################################

        //##########################################CLASS CourseSearchList EVENTS#######################################################
        //event is raised when the link open is clicked
        private void _frmCourseSearchOnCreate()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (CourseCreate frmCreate = new CourseCreate(_userInfo, _courseManager))
                {
                    _frmCourseSearch.WindowState = FormWindowState.Minimized;

                    frmCreate.ShowDialog(this);

                    if (frmCreate.HasCreated)
                    {
                        this.ShowSearchResultDialog(false);
                    }

                    _frmCourseSearch.WindowState = FormWindowState.Normal;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Creating A Course Information");
            }
            finally
            {
                this.ctlManager.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }
        } //--------------------------------

        //event is raised when the datagrid is double clicked or entered
        private void _frmCourseSearchOnDoubleClickEnter(string id)
        {
            this.ShowUpdateCourseDialog(id);
        } //---------------------------------
        //##########################################END CLASS SubjectSearchList EVENTS###################################################

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
                    if (_courseFilter.ForRoom)
                    {
                        _frmClassroomSearch.DataSource = _courseManager.GetSearchedClassroomInformation(_userInfo, queryString, isNewQuery);
                    }
                    else if (_courseFilter.ForSubject)
                    {
                        _frmSubjectSearch.DataSource = _courseManager.GetSearchedSubjectInformation(_userInfo, queryString, isNewQuery);
                    }
                    else if (_courseFilter.ForCourse)
                    {
                        _frmCourseSearch.DataSource = _courseManager.GetSearchedCourseInformation(_userInfo, queryString, isNewQuery);
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

        //this procedure shows the view update classroom information
        private void ShowUpdateClassroomDialog(String id)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (ClassroomUpdate frmUpdate = new ClassroomUpdate(_userInfo, _courseManager.GetDetailsClassroomInformation(id), 
                                            _courseManager))
                {
                    _frmClassroomSearch.WindowState = FormWindowState.Minimized;

                    frmUpdate.ShowDialog(this);

                    if (frmUpdate.HasUpdated)
                    {
                        this.ShowSearchResultDialog(true);
                    }

                    _frmClassroomSearch.WindowState = FormWindowState.Normal;
                }

            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Update Classroom Information Module");
            }
            finally
            {
                this.ctlManager.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }
        } //----------------------------------

        //this procedure shows the view update subject information
        private void ShowUpdateSubjectDialog(String id)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (SubjectUpdate frmUpdate = new SubjectUpdate(_userInfo, _courseManager.GetDetailsSubjectInformation(id), _courseManager))
                {
                    _frmClassroomSearch.WindowState = FormWindowState.Minimized;

                    frmUpdate.ShowDialog(this);

                    if (frmUpdate.HasUpdated)
                    {
                        this.ShowSearchResultDialog(true);
                    }

                    _frmClassroomSearch.WindowState = FormWindowState.Normal;
                }

            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Update Subject Information Module");
            }
            finally
            {
                this.ctlManager.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }
        } //----------------------------------

        //this procedure shows the view update course information
        private void ShowUpdateCourseDialog(String id)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (CourseUpdate frmUpdate = new CourseUpdate(_userInfo, _courseManager.GetDetailsCourseInformation(id), _courseManager))
                {
                    _frmCourseSearch.WindowState = FormWindowState.Minimized;

                    frmUpdate.ShowDialog(this);

                    if (frmUpdate.HasUpdated)
                    {
                        this.ShowSearchResultDialog(true);
                    }

                    _frmCourseSearch.WindowState = FormWindowState.Normal;
                }

            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Update Course Information Module");
            }
            finally
            {
                this.ctlManager.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }
        } //----------------------------------


        #endregion
    }
}
