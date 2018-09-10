using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace AttendaceServices
{
    partial class AttendaceManager
    {
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private AttendanceLogic _attendaceManager;
        private SearchList _frmAttendanceSearchList;
        #endregion

        #region Class Constructors
        public AttendaceManager(CommonExchange.SysAccess userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;

            this.Load += new EventHandler(ClassLoad);
            ctlManager.OnClose += new RemoteClient.ControlManagerCloseButtonClick(ctlManagerOnClose);
            ctlManager.OnRefresh += new RemoteClient.ControlManagerRefreshButtonClick(ctlManagerOnRefresh);
            ctlManager.OnTextBoxKeyUp += new RemoteClient.ControlManagerTextBoxSearchKeyUp(ctlManagerOnTextBoxKeyUp);
            ctlManager.OnPressEnter += new RemoteClient.ControlIdentificationManagerPressEnter(ctlManagerOnPressEnter);
        }
        #endregion

        #region Class Event Void Procedures
        //###########################################CLASS AttendaceManager EVENTS#####################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            _attendaceManager = new AttendanceLogic(_userInfo);

            _frmAttendanceSearchList = new SearchList();
            _frmAttendanceSearchList.OnDoubleClickEnter += new SearchListDataGridDoubleClickEnter(_frmAttendanceSearchListOnDoubleClickEnter);
            _frmAttendanceSearchList.LocationPoint = new Point(50, 300);
            _frmAttendanceSearchList.AdoptGridSize = true;
            _frmAttendanceSearchList.MdiParent = this;

            lblRecordDate.Text = "Record Date: " + DateTime.Parse(_attendaceManager.ServerDateTime).ToString();
        }//------------------------
        //###########################################END CLASS AttendaceManager EVENTS#####################################################

        //##########################################CLASS SearchList EVENTS#######################################################
        //event is raised when the mouse is double clicked
        private void _frmAttendanceSearchListOnDoubleClickEnter(string id)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_attendaceManager.IsStudent(id))
                {
                    using (LogInLogOutStudentInformation frmUpDate = new LogInLogOutStudentInformation(_userInfo,
                        _attendaceManager.GetDetailsStudentInformation(_userInfo, id, Application.StartupPath), _attendaceManager))
                    {
                        _frmAttendanceSearchList.WindowState = FormWindowState.Minimized;

                        frmUpDate.ShowDialog(this);

                        _frmAttendanceSearchList.WindowState = FormWindowState.Normal;

                        this.ctlManager.SetFocusOnSearchTextBox();
                    }
                }
                else
                {
                    using (LogInLogOutEmployeeInformation frmUpdate = new LogInLogOutEmployeeInformation(_userInfo,
                        _attendaceManager.GetDetailsEmployeeInformation(_userInfo, id, Application.StartupPath), _attendaceManager))
                    {
                        _frmAttendanceSearchList.WindowState = FormWindowState.Minimized;

                        frmUpdate.ShowDialog(this);

                        _frmAttendanceSearchList.WindowState = FormWindowState.Normal;

                        this.ctlManager.SetFocusOnSearchTextBox();

                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Update Campus Access Module Module");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//-----------------------
        //##########################################END CLASS SearchList EVENTS#######################################################

        //############################################CONTROLCLASSROOMSUBJECTMANAGER ctlManager EVENTS##########################################
        //event is raised when the button is click
        private void ctlManagerOnClose()
        {
            this.Close();
        }//--------------------

        //event is raised when the refresh button is clicked
        private void ctlManagerOnRefresh()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _attendaceManager.InitializeClass(_userInfo);

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_attendaceManager.ServerDateTime).ToString();

                this.ShowSearchResultDialog(true);
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Refreshing Campus Access Manager.");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }

        //event is raised when the key is up
        private void ctlManagerOnTextBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                _frmAttendanceSearchList.SelectFirstRowInDataGridView();
            }
            else if (String.IsNullOrEmpty(RemoteClient.ProcStatic.TrimStartEndString(ctlManager.GetSearchString)))
            {
                _frmAttendanceSearchList.WindowState = FormWindowState.Minimized;

                this.ctlManager.SetFocusOnSearchTextBox();
            }
        }//--------------------

        //event is raised when Press Enter
        private void ctlManagerOnPressEnter(object sender, KeyEventArgs e)
        {
            this.ShowSearchResultDialog(true);
        }//------------------------
        //############################################END CONTROLCLASSROOMSUBJECTMANAGER ctlManager EVENTS##########################################

        #endregion

        #region Programer-Defined Void Procedures
        //this procedure shows the search resul
        private void ShowSearchResultDialog(Boolean isNewQuery)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                String queryString = RemoteClient.ProcStatic.TrimStartEndString(ctlManager.GetSearchString);

                if (!String.IsNullOrEmpty(queryString))
                {
                    _frmAttendanceSearchList.DataSource = _attendaceManager.GetSearchedEmployeeStudentInformation(_userInfo, queryString, isNewQuery);
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
