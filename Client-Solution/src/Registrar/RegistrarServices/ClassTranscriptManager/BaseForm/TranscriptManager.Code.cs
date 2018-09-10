using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RegistrarServices
{
    partial class TranscriptManager
    {
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private TranscriptLogic _transcriptManager;
        private TranscriptSearchList _frmTranscriptSearchList;
        #endregion

        #region Class Constructors
        public TranscriptManager(CommonExchange.SysAccess userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;

            this.Load += new EventHandler(ClassLoad);
            this.ctlManager.OnClose += new RemoteClient.ControlManagerCloseButtonClick(ctlManagerOnClose);
            this.ctlManager.OnRefresh += new RemoteClient.ControlManagerRefreshButtonClick(ctlManagerOnRefresh);
            this.ctlManager.OnPressEnter += new RemoteClient.ControlTranscriptManagerPressEnter(ctlManagerOnPressEnter);
            this.ctlManager.OnTextBoxKeyUp += new RemoteClient.ControlManagerTextBoxSearchKeyUp(ctlManagerOnTextBoxKeyUp);
        }
        
        #endregion

        #region Class Event Void Procedures
        //####################################################CLASS TranscriptManager EVENTS###############################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            try
            {
                if (!(RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) ||
                   RemoteServerLib.ProcStatic.IsSystemAccessCollegeRegistrar(_userInfo)))
                {
                    throw new Exception("You are not authorized to access this module.");
                }

                _transcriptManager = new TranscriptLogic(_userInfo);

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_transcriptManager.ServerDateTime).ToString();

                _frmTranscriptSearchList = new TranscriptSearchList();

                if (RemoteServerLib.ProcStatic.IsSystemAccessCollegeRegistrar(_userInfo) || RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo))
                {
                    _frmTranscriptSearchList.OnCreate += new TranscriptSearchListLinkCreateClick(_frmTranscriptSearchListOnCreate);
                    _frmTranscriptSearchList.OnDoubleClickEnter += new SearchListDataGridDoubleClickEnter(_frmTranscriptSearchListOnDoubleClickEnter);
                }
                else
                {
                    _frmTranscriptSearchList.CreateButtonEnableProperty(false);
                }

                _frmTranscriptSearchList.LocationPoint = new Point(10, 400);
                _frmTranscriptSearchList.AdoptGridSize = false;
                _frmTranscriptSearchList.MdiParent = this;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog("\n" + ex.Message, "Error Authenticating");

                this.Close();
            }
        }//-------------------------
        //####################################################END CLASS TranscriptManager EVENTS###############################################

        //############################################CONTROL TRANSCRIPTMANAGER ctlManager EVENTS##########################################
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

                _transcriptManager.RefreshSpecialClassData(_userInfo);

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_transcriptManager.ServerDateTime).ToString();
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Refreshing Transcript Manager");
            }
            finally
            {
                this.ctlManager.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }
        }//---------------------------

        //event is raised when the enter key is pressed
        private void ctlManagerOnPressEnter(object sender, KeyEventArgs e)
        {
            this.ShowSearchResultDialog();
        }//-------------------------

        //event is raised when the textbox key is up
        private void ctlManagerOnTextBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                _frmTranscriptSearchList.SelectFirstRowInDataGridView();
            }
            else if (String.IsNullOrEmpty(RemoteClient.ProcStatic.TrimStartEndString(ctlManager.GetSearchString)))
            {
                _frmTranscriptSearchList.WindowState = FormWindowState.Minimized;

                this.ctlManager.SetFocusOnSearchTextBox();
            }
        }//-------------------------
        //############################################END CONTROL TRANSCRIPTMANAGER ctlManager EVENTS##########################################

        //##########################################CLASS TranscriptSearchList EVENTS#######################################################
        //event is raised when the link open is clicked
        private void _frmTranscriptSearchListOnCreate()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (TranscriptInformation frmCreate = new TranscriptInformation(_userInfo, _transcriptManager,
                    _transcriptManager.SelectBySysIDTranscriptDetails(_userInfo, String.Empty, true), _transcriptManager.GetTranscriptInformation(String.Empty)))
                {
                    frmCreate.ShowDialog();
                }

                this.ShowSearchResultDialog();

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Transcript Information Create Module.");
            }
        }//-------------------------

        //event is raised when the dgvList row is double clicked
        private void _frmTranscriptSearchListOnDoubleClickEnter(string id)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (TranscriptInformation frmUpdate = new TranscriptInformation(_userInfo, _transcriptManager,
                    _transcriptManager.SelectBySysIDTranscriptDetails(_userInfo, id, false), _transcriptManager.GetTranscriptInformation(id)))
                {
                    frmUpdate.ShowDialog();
                }

                this.ShowSearchResultDialog();

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Transcript Information Update Module.");
            }
        }//-----------------------
        //##########################################END CLASS TranscriptSearchList EVENTS#######################################################
        #endregion

        #region Programmers-Defined Void Procedures
        //this procedure shows the search result
        private void ShowSearchResultDialog()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                String queryString = RemoteClient.ProcStatic.TrimStartEndString(ctlManager.GetSearchString);

                if (!String.IsNullOrEmpty(queryString))
                {
                    _frmTranscriptSearchList.DataSource = _transcriptManager.SelectTranscriptInformation(_userInfo, queryString);
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
        #endregion
    }
}
