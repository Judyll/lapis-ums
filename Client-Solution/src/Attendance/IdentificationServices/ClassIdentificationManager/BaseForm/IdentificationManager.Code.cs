using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace IdentificationServices
{
    partial class IdentificationManager
    {
        #region Class General Variable Declaration
        private CommonExchange.SysAccess _userInfo;
        private SearchList _frmIdentificationSearch;
        private IdentificationLogic _identificationManager;
        #endregion

        #region Class Constructor
        public IdentificationManager()
        {
            this.InitializeComponent();
        }

        public IdentificationManager(CommonExchange.SysAccess userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;

            this.Load += new EventHandler(ClassLoad);
            //this.FormClosed += new FormClosedEventHandler(ClassClosed);
            ctlManager.OnClose += new RemoteClient.ControlManagerCloseButtonClick(ctlManagerOnClose);
            ctlManager.OnRefresh += new RemoteClient.ControlManagerRefreshButtonClick(ctlManagerOnRefresh);
            ctlManager.OnTextBoxKeyUp += new RemoteClient.ControlManagerTextBoxSearchKeyUp(ctlManagerOnTextBoxKeyUp);
            ctlManager.OnPressEnter += new RemoteClient.ControlIdentificationManagerPressEnter(ctlManagerOnPressEnter);
        }        
        #endregion

        #region Class Event Void Procedures

        //###########################################CLASS IdentificationManager EVENTS#####################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            try
            {
                if (!(RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessIDMaker(_userInfo)))
                {
                    throw new Exception("You are not authorized to access this module.");
                }

                _identificationManager = new IdentificationLogic(_userInfo);

                _frmIdentificationSearch = new SearchList();
                _frmIdentificationSearch.OnDoubleClickEnter += new SearchListDataGridDoubleClickEnter(_frmIdentificationSearchOnDoubleClickEnter);
                _frmIdentificationSearch.LocationPoint = new Point(50, 300);
                _frmIdentificationSearch.AdoptGridSize = false;
                _frmIdentificationSearch.MdiParent = this;

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_identificationManager.ServerDateTime).ToString();
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Authenticating");

                this.Close();
            }
        }//---------------------

        ////event is raised when the class is closed
        //private void ClassClosed(object sender, FormClosedEventArgs e)
        //{
        //    _identificationManager.DeleteImageDirectory(Application.StartupPath);
        //}//-----------------
        //###########################################END CLASS IdentificationManager EVENTS#####################################################

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

                _identificationManager.InitializeClass(_userInfo);

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_identificationManager.ServerDateTime).ToString();

                this.ShowSearchResultDialog(true);
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Refreshing Identification Manager.");
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
                _frmIdentificationSearch.SelectFirstRowInDataGridView();
            }
            else if (String.IsNullOrEmpty(RemoteClient.ProcStatic.TrimStartEndString(ctlManager.GetSearchString)))
            {
                _frmIdentificationSearch.WindowState = FormWindowState.Minimized;

                this.ctlManager.SetFocusOnSearchTextBox();
            }
        }//--------------------

        //event is raised when Press Enter
        private void ctlManagerOnPressEnter(object sender, KeyEventArgs e)
        {
            this.ShowSearchResultDialog(true);
        }//---------------------
        //############################################END CONTROLCLASSROOMSUBJECTMANAGER ctlManager EVENTS##########################################
        
        //##########################################CLASS SearchList EVENTS#######################################################
        private void _frmIdentificationSearchOnDoubleClickEnter(string id)
        {
            ShowUpdateStudentEmployeeInfomation(id);
        }//------------
        //##########################################END CLASS SearchList EVENTS#######################################################
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
                    _frmIdentificationSearch.DataSource = _identificationManager.GetSearchEmployeeStudentInformation(_userInfo, queryString, isNewQuery);
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

        //this procedure shows Student Employee Information
        private void ShowUpdateStudentEmployeeInfomation(String id)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_identificationManager.IsStudent(id))
                {
                    using (IdentificationStudentUpdate frmStudentUpdate = new IdentificationStudentUpdate(_userInfo, 
                        _identificationManager.GetDetailsStudentInformation(_userInfo, id, Application.StartupPath), _identificationManager))
                    {
                        _frmIdentificationSearch.WindowState = FormWindowState.Minimized;

                        frmStudentUpdate.ShowDialog(this);

                        if (frmStudentUpdate.HasUpDated)
                        {
                            this.ShowSearchResultDialog(false);
                        }

                        _frmIdentificationSearch.WindowState = FormWindowState.Normal;

                        ctlManager.SetFocusOnSearchTextBox();
                    }                    
                }
                else
                {
                    using (IdentificationEmployeeUpdate frmEmployeeUpdate = new IdentificationEmployeeUpdate(_userInfo, 
                        _identificationManager.GetDetailsEmployeeInformation(_userInfo, id, Application.StartupPath), _identificationManager))
                    {
                        _frmIdentificationSearch.WindowState = FormWindowState.Minimized;

                        frmEmployeeUpdate.ShowDialog(this);

                        if (frmEmployeeUpdate.HasUpDated)
                        {
                            this.ShowSearchResultDialog(false);
                        }

                        _frmIdentificationSearch.WindowState = FormWindowState.Normal;

                        ctlManager.SetFocusOnSearchTextBox();
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Update Identification Module");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//-------------------------

        #endregion

        
    }
}
