using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class AuxiliaryInformationManager
    {
        #region Class Data Member Declaration
        private AuxiliaryServiceLogic _auxiliaryManager;
        private CommonExchange.SysAccess _userInfo;
        private AuxiliaryInformationSearchList _frmAuxiliaryInfoSearch;
        #endregion

        #region Class Constructor
        public AuxiliaryInformationManager(CommonExchange.SysAccess userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;

            this.Load += new EventHandler(ClassLoad);
            this.ctlManager.OnClose += new RemoteClient.ControlManagerCloseButtonClick(ctlManagerOnClose);
            this.ctlManager.OnRefresh += new RemoteClient.ControlManagerRefreshButtonClick(ctlManagerOnRefresh);
            this.ctlManager.OnPressEnter += new RemoteClient.ControlAuxiliaryManagerPressEnter(ctlManagerOnPressEnter);
            this.ctlManager.OnTextBoxKeyUp += new RemoteClient.ControlManagerTextBoxSearchKeyUp(ctlManagerOnTextBoxKeyUp);
        }

        #endregion

        #region Class Event Void Procedures

        //####################################################CLASS AuxiliaryInformationManager EVENTS###############################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            try
            {
                if (!(RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessVpOfAcademicAffairs(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessSecretaryOftheVpOfAcademicAffairs(_userInfo)))
                {
                    throw new Exception("You are not authorized to access this module.");
                }

                _auxiliaryManager = new AuxiliaryServiceLogic(_userInfo);

                _frmAuxiliaryInfoSearch = new AuxiliaryInformationSearchList();
                _frmAuxiliaryInfoSearch.OnDoubleClickEnter += new SearchListDataGridDoubleClickEnter(_frmAuxiliaryInfoSearchOnDoubleClickEnter);
                _frmAuxiliaryInfoSearch.OnCreate += new AuxiliaryInformationSearchListLinkCreateClick(_frmAuxiliaryInfoSearchOnCreate);
                _frmAuxiliaryInfoSearch.LocationPoint = new Point(20, 300);
                _frmAuxiliaryInfoSearch.AdoptGridSize = true;
                _frmAuxiliaryInfoSearch.MdiParent = this;

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_auxiliaryManager.ServerDateTime).ToString();
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog("\n" + ex.Message, "Error Authenticating");

                this.Close();
            }
        }//------------------------------
        //####################################################END CLASS AuxiliaryInformationManager EVENTS###############################################

        //############################################CONTROLSPECIALCLASSMANAGER ctlManager EVENTS##########################################
        //event is raised when the key is up on the search box
        private void ctlManagerOnTextBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                _frmAuxiliaryInfoSearch.SelectFirstRowInDataGridView();
            }
            else if (String.IsNullOrEmpty(RemoteClient.ProcStatic.TrimStartEndString(ctlManager.GetSearchString)))
            {
                _frmAuxiliaryInfoSearch.WindowState = FormWindowState.Minimized;

                this.ctlManager.SetFocusOnSearchTextBox();
            }
        }//------------------------------------    

        //event is raised when the refresh button is clicked
        private void ctlManagerOnRefresh()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _auxiliaryManager.RefreshAuxiliaryServiceInformationClassData(_userInfo);

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_auxiliaryManager.ServerDateTime).ToString();

                this.ShowSearchResultDialog(true);
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
        }//------------------------------   

        //event is raised when the close button is clicked
        private void ctlManagerOnClose()
        {
            this.Close();
        }//----------------------------  

        //event is raised when Enter key is pressed
        private void ctlManagerOnPressEnter(object sender, KeyEventArgs e)
        {
            this.ShowSearchResultDialog(true);
        }//------------------------------
        //############################################END CONTROLSPECIALCLASSMANAGER ctlManager EVENTS##########################################

        //##########################################CLASS AuxiliaryInformationSearchList EVENTS#######################################################
        //event is raised when the datagrid is double clicked or entered
        private void _frmAuxiliaryInfoSearchOnDoubleClickEnter(string id)
        {
            this.ShowUpdateAuxiliaryServiceDialog(id);
        }//-----------------------------

        //event is raised when the link open is clicked
        private void _frmAuxiliaryInfoSearchOnCreate()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (AuxiliaryServiceCreate frmCreate = new AuxiliaryServiceCreate(_userInfo, _auxiliaryManager))
                {
                    _frmAuxiliaryInfoSearch.WindowState = FormWindowState.Minimized;

                    frmCreate.ShowDialog(this);

                    if (frmCreate.HasCreated)
                    {
                        this.ShowSearchResultDialog(true);
                    }
                    
                    _frmAuxiliaryInfoSearch.WindowState = FormWindowState.Normal;
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
        }//-----------------------------
        //##########################################END CLASS AuxiliaryInformationSearchList EVENTS#######################################################

        #endregion

        #region Programers-Defined Void Procedures

        //this procedure shows the search result
        private void ShowSearchResultDialog(Boolean isNewQuery)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                String queryString = RemoteClient.ProcStatic.TrimStartEndString(ctlManager.GetSearchString);

                if (!String.IsNullOrEmpty(queryString))
                {
                    _frmAuxiliaryInfoSearch.DataSource = _auxiliaryManager.GetAuxiliaryServiceInformation(_userInfo, queryString, isNewQuery);
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

        //this procedure shows the subject schedule update dialog
        private void ShowUpdateAuxiliaryServiceDialog(String id)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (AuxiliaryServiceUpdate frmUpdate = new AuxiliaryServiceUpdate(_userInfo, _auxiliaryManager.GetDetailsAuxiliaryServiceInfomation(id),
                    _auxiliaryManager))
                {
                    _frmAuxiliaryInfoSearch.WindowState = FormWindowState.Minimized;

                    frmUpdate.ShowDialog(this);

                    if (frmUpdate.HasUpdated)
                    {
                        this.ShowSearchResultDialog(true);
                    }

                    _frmAuxiliaryInfoSearch.WindowState = FormWindowState.Normal;
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
        } //-------------------------

        #endregion

    }
}
