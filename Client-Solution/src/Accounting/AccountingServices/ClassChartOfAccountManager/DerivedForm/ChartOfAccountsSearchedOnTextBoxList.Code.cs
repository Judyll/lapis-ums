using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AccountingServices
{
    partial class ChartOfAccountsSearchedOnTextBoxList
    {
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private ChartOfAccountLogic _chartOfAccountManager;

        private Boolean _isForUpdateChartOfAccount;
        #endregion

        #region Class Properties Decleration       
        private Boolean _hasUpdate = false;
        public Boolean HasUpdate
        {
            get { return _hasUpdate; }
        }
        #endregion

        #region Class Constructors
        public ChartOfAccountsSearchedOnTextBoxList(CommonExchange.SysAccess userInfo, ChartOfAccountLogic chartOfAccountManager, Boolean isForUpdateChartOfAccount)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _chartOfAccountManager = chartOfAccountManager;

            _isForUpdateChartOfAccount = isForUpdateChartOfAccount;

            this.pbxRefresh.Click += new EventHandler(pbxRefreshClick);
        }
        #endregion

        #region Class Event Void Procedures

        //####################################CLASS ChartOfAccountsSearchedOnTextBoxList EVENTS####################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.SetDataGridViewSource(_chartOfAccountManager.ChartOfAccountTable);

            base.ClassLoad(sender, e);
        }//-------------------------
        //####################################END CLASS ChartOfAccountsSearchedOnTextBoxList EVENTS####################################

        //##################################TEXTBOX txtSearch EVENTS##########################################################
        //event is raised when the key is up
        protected override void txtSearchKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    this.SetDataGridViewSource(_chartOfAccountManager.GetSearchedChartOfAccountInformations(((TextBox)sender).Text));
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Retrieving Scholarship List");
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }

            base.txtSearchKeyUp(sender, e);
        }//--------------------
        //##################################END TEXTBOX txtSearch EVENTS##########################################################

        //##################################DATAGRIDVIEW dgvList EVENTS##########################################################
        //event is raised when the key is up
        //event is raised when the mouse is double clicked
        protected override void dgvListDoubleClick(object sender, EventArgs e)
        {
            base.dgvListDoubleClick(sender, e);

            if (!String.IsNullOrEmpty(this.PrimaryId))
            {
                if (!_isForUpdateChartOfAccount)
                {
                    this.Close();
                }
                else
                {
                    using (ChartOfAccountUpdate frmUpdate = new ChartOfAccountUpdate(_userInfo, _chartOfAccountManager.GetDetailsChartOfAccount(_userInfo, this.PrimaryId),
                        _chartOfAccountManager))
                    {
                        frmUpdate.ShowDialog(this);

                        if (frmUpdate.HasUpdated)
                        {
                            _hasUpdate = true;

                            this.SetDataGridViewSource(_chartOfAccountManager.GetSearchedChartOfAccountInformations(this.txtSearch.Text));
                        }
                    }
                }
            }
        }
        //--------------------------
        //##################################END DATAGRIDVIEW dgvList EVENTS##########################################################

        //##################################PICTUREBOX pbxRefresh EVENTS######################################################
        //event is raised when the picture box is clicked
        private void pbxRefreshClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            this.txtSearch.Clear();

            this.Cursor = Cursors.Arrow;
        }//-----------------
        //##################################END PICTUREBOX pbxRefresh EVENTS######################################################

        #endregion
    }
}
