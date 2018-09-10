using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace AdministratorServices
{
    partial class AdministrationManagerUser
    {
        #region Class Data Member Declaration
        protected CommonExchange.SysAccess _userInfo;
        protected AdministrtationLogic _administrationManager; 

        private ToolTip ttpTool;

        private Int32 _primaryIndex = 0;
        private String _primaryId = String.Empty;
        #endregion

        #region Class Properties Declaration
        private Boolean _exitUMS = false;
        public Boolean ExitUMS
        {
            get { return _exitUMS; }
        }
        #endregion

        #region Class Constructors
        public AdministrationManagerUser()
        {
            this.InitializeComponent();
        }

        public AdministrationManagerUser(CommonExchange.SysAccess userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
         
            this.Load += new EventHandler(ClassLoad);
            this.txtSearch.KeyPress += new KeyPressEventHandler(txtSearchKeyPress);
            this.txtSearch.KeyUp += new KeyEventHandler(txtSearchKeyUp);
            this.dgvList.MouseDown += new MouseEventHandler(dgvListMouseDown);
            this.dgvList.DataSourceChanged += new EventHandler(dgvListDataSourceChanged);
            this.dgvList.SelectionChanged += new EventHandler(dgvListSelectionChanged);
            this.dgvList.MouseDoubleClick += new MouseEventHandler(dgvListMouseDoubleClick);
            this.btnAddUser.Click += new EventHandler(btnAddUserClick);
            this.pbxDone.Click += new EventHandler(pbxDoneClick);
            this.pbxRefresh.Click += new EventHandler(pbxRefreshClick);
            this.btnClose.Click += new EventHandler(btnCloseClick);
        }        
        #endregion

        #region Class Event Void Procedures
        //###########################################CLASS AdministationManager EVENTS#####################################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            try
            {
                if (!RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo))
                {
                    throw new Exception("You are not authorized to access this module.");
                }

                _administrationManager = new AdministrtationLogic(_userInfo);

                _administrationManager.SelectUserInformation(_userInfo, "*");

                this.SetDataGridViewSource(_administrationManager.UserInformationTable);

                RemoteClient.ProcStatic.SetDataGridViewColumns(this.dgvList, false);

                ttpTool = new ToolTip();

                ttpTool.SetToolTip(pbxDone, "Close");
                ttpTool.SetToolTip(pbxRefresh, "Refresh");
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog("\n" + ex.Message, "Error Authenticating");

                this.Close();
            }
        }//------------------------
        //###########################################END CLASS AdministationManager EVENTS#####################################################


        //###################################################TEXTBOX txtSearch EVENTS########################################################
        //event is raised when the key is pressed
        private void txtSearchKeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) ||
                char.IsWhiteSpace(e.KeyChar) || e.KeyChar == '*' || e.KeyChar == '\r' || char.IsPunctuation(e.KeyChar))
            {
                txtSearch.ReadOnly = false;
            }
            else
            {
                txtSearch.ReadOnly = true;
            }
        }//--------------------------      

        //event is raised when the key is up
        protected virtual void txtSearchKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    this.SetDataGridViewSource(_administrationManager.GetSearchUserInformation(_userInfo, this.txtSearch.Text));
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
                }

            }
        }//----------------------------
        //###################################################END TEXTBOX txtSearch EVENTS########################################################

        //####################################################DATAGRIDVIEW dgvList EVENTS####################################################
        //event is raised when the mouse is down
        private void dgvListMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataGridView dgvBase = (DataGridView)sender;

                DataGridView.HitTestInfo hitTest = dgvBase.HitTest(e.X, e.Y);

                Int32 rowIndex = -1;

                switch (hitTest.Type)
                {
                    case DataGridViewHitTestType.Cell:
                        rowIndex = hitTest.RowIndex;
                        break;
                    case DataGridViewHitTestType.RowHeader:
                        rowIndex = hitTest.RowIndex;
                        break;
                    default:
                        rowIndex = -1;
                        _primaryId = "";
                        break;
                }

                if (rowIndex != -1)
                {
                    _primaryId = dgvBase[_primaryIndex, rowIndex].Value.ToString();
                }
            }
        }//--------------------------

        //event is raised when the selection is changed
        private void dgvListSelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvList.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {
                DataGridViewRow row = this.dgvList.SelectedRows[0];

                _primaryId = row.Cells[_primaryIndex].Value.ToString();
            }
        }//---------------------

        //event is raised when the datasource changed
        private void dgvListDataSourceChanged(object sender, EventArgs e)
        {
            DataGridView dgvBase = (DataGridView)sender;
            Int32 result = dgvBase.Rows.Count;

            if (result == 1)
            {
                _primaryId = dgvBase[_primaryIndex, 0].Value.ToString();
            }
            else
            {
                _primaryId = "";
            }

            if (result == 0 || result == 1)
            {
                this.lblResult.Text = result.ToString() + " Record";
            }
            else
            {
                this.lblResult.Text = result.ToString() + " Records";
            }
        }//----------------------------      

        //event is raised when the control is double clicked
        protected void dgvListMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!String.IsNullOrEmpty(_primaryId))
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    using (UserInfoAdminUpdate frmUpdate = new UserInfoAdminUpdate(_userInfo, _administrationManager,
                        _administrationManager.GetDetailsUserInformation(_userInfo, _primaryId, Application.StartupPath)))
                    {
                        frmUpdate.ShowDialog(this);

                        if (frmUpdate.HasUpdated)
                        {
                            if (frmUpdate.ExitUMS)
                            {
                                _exitUMS = true;
                            }
                            else
                            {
                                this.SetDataGridViewSource(_administrationManager.GetSearchUserInformation(_userInfo, this.txtSearch.Text));
                            }
                        }
                    }

                    if (_exitUMS)
                    {
                        this.Close();
                    }

                    this.Cursor = Cursors.Arrow;
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
                }
            }
        }//--------------------
        //####################################################END DATAGRIDVIEW dgvList EVENTS####################################################

        //####################################################BUTTON btnAddUser EVENTS####################################################
        //event is raised when the the control is clicked
        private void btnAddUserClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (UserInfoAdminCreate frmCreate = new UserInfoAdminCreate(_userInfo, _administrationManager))
                {
                    frmCreate.ShowDialog(this);

                    if (frmCreate.HasCreated)
                    {
                        this.SetDataGridViewSource(_administrationManager.GetSearchUserInformation(_userInfo, this.txtSearch.Text));
                    }
                    else if (frmCreate.IsForUserUpdate)
                    {
                        this.ShowUpdateDialog(frmCreate.NewUserInfo);
                    }
                }
               
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }
        }//------------------------------
        //####################################################END BUTTON btnAddUser EVENTS####################################################

        //####################################################PICTUREBox pbxDone EVENTS####################################################
        //event is raised when the the control is clicked
        private void pbxDoneClick(object sender, EventArgs e)
        {
            this.Close();
        }//--------------------------
        //####################################################END PICTUREBox pbxDone EVENTS####################################################

        //####################################################PICTUREBox pbxRefres EVENTS####################################################
        //event is raised when the the control is clicked
        private void pbxRefreshClick(object sender, EventArgs e)
        {
            try
            {
                this.SetDataGridViewSource(_administrationManager.GetSearchUserInformation(_userInfo, this.txtSearch.Text));
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }
        }//-----------------------------
        //####################################################END PICTUREBox pbxRefres EVENTS####################################################      

        //####################################################BUTTON btnClose EVENTS####################################################
        //event is raised when the the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//-----------------------
        //###################################################END BUTTON btnClose EVENTS####################################################
        #endregion

        #region Programmer-Defined Void Procedures
        //this procedure will set data source
        private void SetDataGridViewSource(DataTable srcTable)
        {
            this.Cursor = Cursors.WaitCursor;

            this.dgvList.DataSource = srcTable;

            this.Cursor = Cursors.Arrow;            
        }//-----------------------

        //this procedure will show update user
        private void ShowUpdateDialog(CommonExchange.SysAccess newUserInfo)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (UserInfoAdminUpdate frmUpdate = new UserInfoAdminUpdate(_userInfo, _administrationManager, newUserInfo))
                {
                    frmUpdate.ShowDialog(this);

                    if (frmUpdate.HasUpdated)
                    {
                        if (frmUpdate.ExitUMS)
                        {
                            _exitUMS = true;
                        }
                        else
                        {
                            this.SetDataGridViewSource(_administrationManager.GetSearchUserInformation(_userInfo, this.txtSearch.Text));
                        }
                    }
                }

                if (_exitUMS)
                {
                    this.Close();
                }

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }
        }//-----------------------------
        #endregion
    }
}
