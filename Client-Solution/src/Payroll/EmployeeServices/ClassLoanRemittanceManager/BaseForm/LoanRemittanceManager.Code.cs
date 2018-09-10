using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace EmployeeServices
{
    partial class LoanRemittanceManager
    {
        #region Class General Variable Declarations
        private LoanRemittanceLogic _loanManager;
        private CommonExchange.SysAccess _userInfo;
        private LoanTypeSearchList _frmLoanTypeSearch;
        private LoanRemittanceEmployeeSearchList _frmEmpSearch;

        private Boolean _forLoanType;
        #endregion

        #region Class Constructor
        public LoanRemittanceManager(CommonExchange.SysAccess userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;

            this.Load += new EventHandler(ClassLoad);
            this.ctlManager.OnClose += new RemoteClient.ControlManagerCloseButtonClick(ctlManagerOnClose);
            this.ctlManager.OnRefresh += new RemoteClient.ControlManagerRefreshButtonClick(ctlManagerOnRefresh);
            this.ctlManager.OnPressEnter += new RemoteClient.ControlLoanRemittancePressEnter(ctlManagerOnPressEnter);
            this.ctlManager.OnTextBoxKeyUp += new RemoteClient.ControlManagerTextBoxSearchKeyUp(ctlManagerOnTextBoxKeyUp);
            this.ctlManager.OnModeOptionCheckedChanged += new RemoteClient.ControlLoanRemittanceModeOptionCheckedChanged(ctlManagerOnModeOptionCheckedChanged);

        }
        #endregion

        #region Class Event Void Procedures

        //###########################################CLASS EarningManager EVENTS#####################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            try
            {
                _loanManager = new LoanRemittanceLogic(_userInfo);

                _frmLoanTypeSearch = new LoanTypeSearchList();
                _frmLoanTypeSearch.OnDoubleClickEnter += new SearchListLoanDataGridDoubleClickEnter(_frmLoanTypeSearchOnDoubleClickEnter); 
                _frmLoanTypeSearch.OnCreate += new LoanTypeSearchListLinkCreateClick(_frmLoanTypeSearchOnCreate);
                _frmLoanTypeSearch.LocationPoint = new Point(50, 300);
                _frmLoanTypeSearch.AdoptGridSize = true;
                _frmLoanTypeSearch.MdiParent = this;

                _frmEmpSearch = new LoanRemittanceEmployeeSearchList();
                _frmEmpSearch.OnDoubleClickEnter += new SearchListDataGridDoubleClickEnter(_frmEmpSearchOnDoubleClickEnter);
                _frmEmpSearch.LocationPoint = new Point(50, 300);
                _frmEmpSearch.AdoptGridSize = true;
                _frmEmpSearch.MdiParent = this;
                
                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_loanManager.ServerDateTime).ToString();

                _forLoanType = true;

                if (!(RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessVpOfFinance(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessPayrollMaster(_userInfo)))
                {
                    throw new Exception("You are not authorized to access this module.");
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog("\n" + ex.Message, "Error Authenticating");

                this.Close();
            }

        }

        //#######################################END CLASS EarningManager EVENTS#####################################################

        //############################################CONTROLEARNINGMANAGER ctlManager EVENTS##########################################
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

                _loanManager.RefreshLoanRemittanceData(_userInfo);

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_loanManager.ServerDateTime).ToString();

                this.ShowSearchResultDialog();
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Refreshing Loan Remittance Manager");
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
            this.ShowSearchResultDialog();
        } //--------------------------------

        //event is raised when the key is up on the search box
        private void ctlManagerOnTextBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (_forLoanType)
                {
                    _frmLoanTypeSearch.SelectFirstRowInDataGridView();
                }
                else
                {
                    _frmEmpSearch.SelectFirstRowInDataGridView();
                }
            }
            else if (String.IsNullOrEmpty(RemoteClient.ProcStatic.TrimStartEndString(ctlManager.GetSearchString)))
            {
                if (_forLoanType)
                {
                    _frmLoanTypeSearch.WindowState = FormWindowState.Minimized;
                }
                else
                {
                    _frmEmpSearch.WindowState = FormWindowState.Minimized;
                }      

                this.ctlManager.SetFocusOnSearchTextBox();
            }
            
        } //--------------------------------

        //event is raised when the option button is changed
        private void ctlManagerOnModeOptionCheckedChanged(bool forLoanType)
        {
            _frmLoanTypeSearch.WindowState = FormWindowState.Minimized;
            _frmLoanTypeSearch.Hide();

            _frmEmpSearch.WindowState = FormWindowState.Minimized;
            _frmEmpSearch.Hide();

            _forLoanType = forLoanType;
        } //-------------------------------

        //#########################################END CONTROLEARNINGMANAGER ctlManager EVENTS#########################################

        //############################################CLASS LoanTypeSearchList EVENTS##############################################
        //event is raised when the datagrid is double click or enter
        private void _frmLoanTypeSearchOnDoubleClickEnter(string id)
        {
            this.ShowUpdateLoanTypeDialog(id);
            
        } //----------------------------

        //event is raised when the link is clicked
        private void _frmLoanTypeSearchOnCreate()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (LoanTypeCreate frmCreate = new LoanTypeCreate(_userInfo, _loanManager))
                {
                    _frmLoanTypeSearch.WindowState = FormWindowState.Minimized;

                    frmCreate.ShowDialog(this);

                    if (frmCreate.HasCreated)
                    {
                        this.ShowSearchResultDialog();
                    }

                    _frmLoanTypeSearch.WindowState = FormWindowState.Normal;

                }
                
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Creating A New Loan Type");
            }
            finally
            {
                this.ctlManager.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }

        } //--------------------------------------        
        //##########################################END CLASS LoanTypeSearchList EVENTS############################################

        //#########################################CLASS LoanRemittanceEmployeeSearchList EVENTS##########################################
        //event is raised when the datagrid view is double click or entered
        private void _frmEmpSearchOnDoubleClickEnter(string id)
        {
            try
            {

                using (LoanRemittanceSummary frmSummary = new LoanRemittanceSummary(_userInfo, _loanManager.GetEmployeeInformationDetails(id), _loanManager))
                {
                    _frmEmpSearch.WindowState = FormWindowState.Minimized;

                    frmSummary.ShowDialog();

                    if (frmSummary.HasCreated || frmSummary.HasUpdated)
                    {
                        _loanManager.UpdateSelectedEmployeeInformation(id);

                        this.ShowSearchResultDialog();
                    }

                    _frmEmpSearch.WindowState = FormWindowState.Normal;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Loan Remittance Summary");
            }
            finally
            {
                this.ctlManager.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }
        } //-------------------------------------
        //#########################################END CLASS LoanRemittanceEmployeeSearchList EVENTS##########################################


        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure shows the search result
        private void ShowSearchResultDialog()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                String queryString = RemoteClient.ProcStatic.TrimStartEndString(ctlManager.GetSearchString);

                if (!String.IsNullOrEmpty(queryString))
                {
                    if (_forLoanType)
                    {
                        _frmLoanTypeSearch.DataSource = _loanManager.GetSearchedLoanTypeInformation(queryString);
                    }
                    else
                    {
                        ClientExchange.EmployeeSearchFilter searchFilter = new ClientExchange.EmployeeSearchFilter();

                        searchFilter.StringSearch = queryString;

                        _frmEmpSearch.DataSource = _loanManager.GetSelectedEmployeeInformation(searchFilter);
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

        //this procedure show the update loan type dialog
        private void ShowUpdateLoanTypeDialog(String id)
        {
            try
            {
                using (LoanTypeUpdate frmUpdate = new LoanTypeUpdate(_userInfo, _loanManager, id))
                {
                    _frmLoanTypeSearch.WindowState = FormWindowState.Minimized;

                    frmUpdate.ShowDialog();

                    if (frmUpdate.HasUpdated)
                    {
                        this.ShowSearchResultDialog();
                    }

                    _frmLoanTypeSearch.WindowState = FormWindowState.Normal;
                }

            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Update Loan Type Module");
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
