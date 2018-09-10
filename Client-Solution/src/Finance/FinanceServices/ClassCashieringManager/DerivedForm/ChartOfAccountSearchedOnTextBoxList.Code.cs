using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class ChartOfAccountSearchedOnTextBoxList
    {
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private CashieringLogic _cashieringManager;
        #endregion

        #region Class Properties Declaration
        private Boolean _allowMultipleInsert = false;
        public Boolean AllowMultipleInsert
        {
            get { return _allowMultipleInsert; }
            set { _allowMultipleInsert = value; }
        }
        #endregion

        #region Class Constructors
        public ChartOfAccountSearchedOnTextBoxList(CommonExchange.SysAccess userInfo, CashieringLogic cashieringManager)
        {
            this.InitializeComponent();

            _cashieringManager = cashieringManager;
            _userInfo = userInfo;

            this.pbxRefresh.Click += new EventHandler(pbxRefreshClick);
            this.chkAllowMultipleInsert.CheckedChanged += new EventHandler(chkAllowMultipleInsertCheckedChanged);
        }       
        #endregion

        #region Class Event Void Procedures
        //####################################CLASS ChartOfAccountSearchedOnTextBoxList EVENTS####################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.SetDataGridViewSource(_cashieringManager.ChartOfAccountTableFormat);

            base.ClassLoad(sender, e);

            this.chkAllowMultipleInsert.Checked = _allowMultipleInsert;
        }//------------------------
        //####################################END CLASS ChartOfAccountSearchedOnTextBoxList EVENTS####################################

        //##################################TEXTBOX txtSearch EVENTS##########################################################
        //event is raised when the key is up
        protected override void txtSearchKeyUp(object sender, KeyEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    this.SetDataGridViewSource(_cashieringManager.GetSearchedChartOfAccount(_userInfo, ((TextBox)sender).Text, String.Empty, String.Empty, true));
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Retrieving Chart of Accounts Infomation List");
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }

            base.txtSearchKeyUp(sender, e);

            this.Cursor = Cursors.Arrow;
        }//-----------------------------------
        //##################################END TEXTBOX txtSearch EVENTS##########################################################

        //####################################################DATAGRIDVIEW dgvList EVENTS####################################################
        //event is raised when the control is double clicked
        protected override void dgvListDoubleClick(object sender, EventArgs e)
        {
            base.dgvListDoubleClick(sender, e);

            this.Close();
        }//--------------------------
        //####################################################END DATAGRIDVIEW dgvList EVENTS####################################################

        //##################################DATAGRIDVIEW dgvListDoubleClick EVENTS######################################################
        //event is raised when the key is pressed
        protected override void dgvListKeyPress(object sender, KeyPressEventArgs e)
        {
            base.dgvListKeyPress(sender, e);

            this.Close();
        }//---------------------------
        //##################################DATAGRIDVIEW dgvListDoubleClick EVENTS######################################################

        //##################################PICTUREBOX pbxRefresh EVENTS######################################################
        //event is raised when the picture box is clicked
        private void pbxRefreshClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.SetDataGridViewSource(_cashieringManager.ChartOfAccountTableFormat);

            this.txtSearch.Clear();

            this.Cursor = Cursors.Arrow;
        }//---------------------------------
        //##################################END PICTUREBOX pbxRefresh EVENTS######################################################

        //##################################CHECKBOX chkAllowMultipleInsert EVENTS######################################################
        //event is raised when the checked status is changed
        private void chkAllowMultipleInsertCheckedChanged(object sender, EventArgs e)
        {
            _allowMultipleInsert = this.chkAllowMultipleInsert.Checked;
        }//-------------------------------
        //##################################END CHECKBOX chkAllowMultipleInsert EVENTS######################################################
        #endregion

        #region Programmer's Defined Void Procedures
        //this procedure will show/hide control allow multiple insert
        public void ShowAllowMultipleInsert(Boolean allow)
        {
            this.chkAllowMultipleInsert.Visible = allow;
        }//-----------------------
        #endregion
    }
}
