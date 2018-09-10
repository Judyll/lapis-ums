using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AccountingServices
{
    partial class ChartOfAccountManager
    {
        #region Class Data Member Decleration
        private CommonExchange.SysAccess _userInfo;
        private ChartOfAccountLogic _chartOfAccountManager;
        #endregion

        #region Class Constructors
        public ChartOfAccountManager(CommonExchange.SysAccess userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;

            _chartOfAccountManager = new ChartOfAccountLogic(_userInfo);

            this.Load += new EventHandler(ClassLoad);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnCreateChartOfAccount.Click += new EventHandler(btnCreateChartOfAccountClick);
            this.btnSearchChartOfAccount.Click += new EventHandler(btnSearchChartOfAccountClick);
            this.btnPrintChartOfAccounts.Click += new EventHandler(btnPrintChartOfAccountsClick);
        }
        #endregion

        #region Class Event Void Procedures
        //###############################################CLASS ChartOfAccountManager EVENTS##################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            this.InitializeChartOfAccountView(true);
        }//--------------------------
        //##############################################END CLASS ChartOfAccountManager EVENTS##################################################

        //##################################BUTTON btnClose EVENTS######################################################
        //event is raised when the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//----------------------
        //##################################END BUTTON btnClose EVENTS######################################################

        //##################################BUTTON btnCreate EVENTS######################################################
        //event is raised when the control is clicked
        private void btnCreateChartOfAccountClick(object sender, EventArgs e)
        {
            using (ChartOfAccountCreate frmCreate = new ChartOfAccountCreate(_userInfo, _chartOfAccountManager))
            {
                frmCreate.ShowDialog(this);

                if (frmCreate.HasCreated)
                {
                    this.InitializeChartOfAccountView(false);
                }
            }
        }//----------------
        //##################################END BUTTON btnCreate EVENTS######################################################

        //##################################BUTTON btnSearchChartOfAccount EVENTS######################################################
        //event is raised when the control is clicked
        private void btnSearchChartOfAccountClick(object sender, EventArgs e)
        {
            using (ChartOfAccountsSearchedOnTextBoxList frmSearch = new ChartOfAccountsSearchedOnTextBoxList(_userInfo, _chartOfAccountManager, true))
            {
                frmSearch.AdoptGridSize = false;
                frmSearch.ShowDialog(this);

                if (frmSearch.HasUpdate)
                {
                    this.InitializeChartOfAccountView(false);
                }
            }
        }//----------------
        //##################################END BUTTON btnSearchChartOfAccount EVENTS######################################################

        //##################################BUTTON btnPrintChartOfAccount EVENTS######################################################
        //event is raised when the control is clicked
        private void btnPrintChartOfAccountsClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            _chartOfAccountManager.PrintChartOfAccount(_userInfo);

            this.Cursor = Cursors.Arrow;
        }//-----------------------
        //##################################END BUTTON btnPrintChartOfAccount EVENTS######################################################
        #endregion

        #region Programmer's Defined Void Procedures
        //this procedure will initialize chart of account view
        private void InitializeChartOfAccountView(Boolean isRefrestChartOfAccount)
        {
            if (isRefrestChartOfAccount)
            {
                _chartOfAccountManager.SelectChartOfAccountsArrangedList(_userInfo, "*", String.Empty, String.Empty, true);
            }

            _chartOfAccountManager.ArrageAccountHierarchyList();
            _chartOfAccountManager.InitializeChartOfAccountListView(this.trvChartOfAccounts);

        }//-------------------
        #endregion
    }
}
