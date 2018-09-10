using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace AdministratorServices
{
    partial class AdministrationManagerLog
    {
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private CommonExchange.TransactionLog _transactionLogInfo;
        private AdministrtationLogic _administrationManager;
              
        private String _primaryId = String.Empty;
        private Int32 _primaryIndex = 0;
        #endregion

        #region Class Constructors
        public AdministrationManagerLog(CommonExchange.SysAccess userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;

            this.Load += new EventHandler(ClassLoad);
            this.cboUser.SelectedIndexChanged += new EventHandler(cboUserSelectedIndexChanged);
            this.txtSearch.KeyPress += new KeyPressEventHandler(txtSearchKeyPress);
            this.dgvList.MouseDown += new MouseEventHandler(dgvListMouseDown);
            this.dgvList.DataSourceChanged += new EventHandler(dgvListDataSourceChanged);
            this.dgvList.SelectionChanged += new EventHandler(dgvListSelectionChanged);
            this.dgvList.MouseDoubleClick += new MouseEventHandler(dgvListMouseDoubleClick);
            this.btnSearch.Click += new EventHandler(btnSearchClick);
            this.lnkReset.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkResetLinkClicked);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.chkInclude.CheckedChanged += new EventHandler(chkIncludeCheckedChanged);
        }
        
        #endregion

        #region Class Event Void Procedures
        //###########################################CLASS AdministationManagerLog EVENTS#####################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
             try
            {
                if (!RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo))
                {
                    throw new Exception("You are not authorized to access this module.");
                }

                _administrationManager = new AdministrtationLogic(_userInfo);

                _transactionLogInfo = new CommonExchange.TransactionLog();

                _administrationManager.SelectUserInformation(_userInfo, "*");

                _administrationManager.InitializeUserCombo(this.cboUser);

                this.SetDataGridViewSource(_administrationManager.TransactionLogTable);

                RemoteClient.ProcStatic.SetDataGridViewColumns(this.dgvList, false);

                DateTime serverDateTime = DateTime.MinValue;

                if (DateTime.TryParse(_administrationManager.ServerDateTime, out serverDateTime))
                {
                    this.dtpStart.Value = this.dtpEnd.Value = serverDateTime;
                }               
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog("\n" + ex.Message, "Error Authenticating");

                this.Close();
            }
        }//------------------------------
        //###########################################END CLASS AdministationManagerLog EVENTS#####################################################

        //###########################################COMBOBOX cboUserId EVENTS#####################################################
        //event is raised when the selected index is changed
        private void cboUserSelectedIndexChanged(object sender, EventArgs e)
        {
            _transactionLogInfo.UserInfo.UserId = _administrationManager.GetUserId(this.cboUser.SelectedIndex);
        }//------------------------------
        //###########################################END COMBOBOX cboUserId EVENTS#####################################################

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

                    using (TransactionDone frmShow = new TransactionDone(_userInfo, _administrationManager,
                        _administrationManager.GetDetailsTransactionLog(_primaryId)))
                    {
                        frmShow.ShowDialog(this);
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

        //####################################################BUTTON btnSearch EVENTS####################################################
        //event is raised when the control is clicked
        private void btnSearchClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                String dateStart, dateEnd = String.Empty;

                dateStart = this.chkInclude.Checked ? this.dtpStart.Value.ToShortDateString() +  " 12:00:00 AM" : String.Empty;
                dateEnd = this.chkInclude.Checked ? this.dtpEnd.Value.ToShortDateString() +  " 11:59:59 PM" : String.Empty;

                this.SetDataGridViewSource(_administrationManager.GetSearchTransactionLog(_userInfo, this.txtSearch.Text,
                    _transactionLogInfo.UserInfo.UserId, dateStart, dateEnd));
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }

            this.Cursor = Cursors.Arrow;

        }//-------------------------
        //####################################################END BUTTON btnSearch EVENTS####################################################

        //####################################################LINKLABEL lnkResset EVENTS####################################################
        //event is raised when the control is clicked
        private void lnkResetLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.txtSearch.Clear();

            _administrationManager.SelectUserInformation(_userInfo, "*");
            _administrationManager.InitializeUserCombo(this.cboUser);

            _transactionLogInfo.UserInfo.UserId = String.Empty;

            this.dtpEnd.Checked = this.dtpStart.Checked = false;

            this.txtSearch.Focus();
        }//-------------------------
        //####################################################END LINKLABEL lnkResset EVENTS####################################################

        //####################################################BUTTON btnClose EVENTS####################################################
        //event is raised when the the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//-----------------------
        //###################################################END BUTTON btnClose EVENTS####################################################

        private void chkIncludeCheckedChanged(object sender, EventArgs e)
        {
            if (this.chkInclude.Checked)
            {
                this.dtpStart.Enabled = this.dtpEnd.Enabled = true;
            }
            else
            {
                this.dtpStart.Enabled = this.dtpEnd.Enabled = false;
            }
        }
        #endregion

        #region Programmer-Defined Void Procedures
        private void SetDataGridViewSource(DataTable srcTable)
        {
            this.Cursor = Cursors.WaitCursor;

            this.dgvList.DataSource = srcTable;

            this.Cursor = Cursors.Arrow;
        }//---------------------
        #endregion
    }
}
