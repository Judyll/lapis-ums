using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace EmployeeServices
{
    partial class EarningManager
    {
        #region Class General Variable Declarations
        private EarningLogic _incManager;
        private CommonExchange.SysAccess _userInfo;
        private EarningDeductionSearchList _frmIncDecSearch;
        private EarningDeductionEmployeeSearchList _frmEmpSearch;
        private Boolean _forApply;
        #endregion

        #region Class Constructor
        public EarningManager(CommonExchange.SysAccess userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;

            this.Load += new EventHandler(ClassLoad);
            this.ctlManager.OnClose += new RemoteClient.ControlManagerCloseButtonClick(ctlManagerOnClose);
            this.ctlManager.OnRefresh += new RemoteClient.ControlManagerRefreshButtonClick(ctlManagerOnRefresh);
            this.ctlManager.OnPressEnter += new RemoteClient.ControlEarningDeductionManagerPressEnter(ctlManagerOnPressEnter);
            this.ctlManager.OnTextBoxKeyUp += new RemoteClient.ControlManagerTextBoxSearchKeyUp(ctlManagerOnTextBoxKeyUp);
            this.ctlManager.OnModeOptionCheckedChanged += 
                new RemoteClient.ControlEarningDeductionManagerModeOptionCheckedChanged(ctlManagerOnModeOptionCheckedChanged);

        }
        
        #endregion

        #region Class Event Void Procedures

        //###########################################CLASS EarningManager EVENTS#####################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            try
            {
                ctlManager.InitializeControl(false);

                _incManager = new EarningLogic(_userInfo);

                _frmIncDecSearch = new EarningDeductionSearchList();
                _frmIncDecSearch.Text = "  Earning Information List";
                _frmIncDecSearch.InitializeControl(false);
                _frmIncDecSearch.OnDoubleClickEnter += new SearchListDataGridDoubleClickEnter(_frmIncDecSearchOnDoubleClickEnter);
                _frmIncDecSearch.OnAdd += new EarningDeductionSearchListLinkAddClick(_frmIncDecSearchOnAdd);
                _frmIncDecSearch.OnUpdate += new EarningDeductionSearchListLinkUpdateClick(_frmIncDecSearchOnUpdate);
                _frmIncDecSearch.LocationPoint = new Point(50, 300);
                _frmIncDecSearch.AdoptGridSize = true;
                _frmIncDecSearch.MdiParent = this;

                _frmEmpSearch = new EarningDeductionEmployeeSearchList();
                _frmEmpSearch.OnDoubleClickEnter += new SearchListDataGridDoubleClickEnter(_frmEmpSearchOnDoubleClickEnter);
                _frmEmpSearch.LocationPoint = new Point(50, 300);
                _frmEmpSearch.AdoptGridSize = true;
                _frmEmpSearch.MdiParent = this;

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_incManager.ServerDateTime).ToString();

                _forApply = true;

                if (!(RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessVpOfFinance(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessPayrollMaster(_userInfo)))
                {
                    throw new Exception("You are not authorized to access this module.");
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Earning Manager");
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

                _incManager.RefreshEarningData(_userInfo);

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_incManager.ServerDateTime).ToString();

                this.ShowSearchResultDialog();
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Refreshing Earning Manager");
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
                if (_forApply)
                {
                    _frmIncDecSearch.SelectFirstRowInDataGridView();
                }
                else
                {
                    _frmEmpSearch.SelectFirstRowInDataGridView();
                }
            }
            else if (String.IsNullOrEmpty(RemoteClient.ProcStatic.TrimStartEndString(ctlManager.GetSearchString)))
            {
                if (_forApply)
                {
                    _frmIncDecSearch.WindowState = FormWindowState.Minimized;
                }
                else
                {
                    _frmEmpSearch.WindowState = FormWindowState.Minimized;
                }

                this.ctlManager.SetFocusOnSearchTextBox();
            }
        } //--------------------------------

        //event is raised when the option button is changed
        private void ctlManagerOnModeOptionCheckedChanged(bool forApply)
        {
            _frmIncDecSearch.WindowState = FormWindowState.Minimized;
            _frmIncDecSearch.Hide();

            _frmEmpSearch.WindowState = FormWindowState.Minimized;
            _frmEmpSearch.Hide();

            _forApply = forApply;
        } //-------------------------------

        //#########################################END CONTROLEARNINGMANAGER ctlManager EVENTS#########################################

        //############################################CLASS EarningDeductionSearchList EVENTS##############################################
        //event is raised when the datagrid is double click or enter
        private void _frmIncDecSearchOnDoubleClickEnter(string id)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (ApplyEarning frmApply = new ApplyEarning(_userInfo, _incManager.GetDetailsEarningInformation(id), _incManager))
                {
                    _frmIncDecSearch.WindowState = FormWindowState.Minimized;

                    frmApply.ShowDialog(this);

                    _frmIncDecSearch.WindowState = FormWindowState.Normal;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Apply Earning Module");
            }
            finally
            {
                this.ctlManager.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }

        } //----------------------------

        //event is raised when the link is clicked
        private void _frmIncDecSearchOnAdd()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (EarningCreate frmCreate = new EarningCreate(_userInfo, _incManager))
                {
                    _frmIncDecSearch.WindowState = FormWindowState.Minimized;

                    frmCreate.ShowDialog(this);

                    if (frmCreate.HasCreated)
                    {
                        this.ShowSearchResultDialog();
                    }

                    _frmIncDecSearch.WindowState = FormWindowState.Normal;
                }
                
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Creating A Earning");
            }
            finally
            {
                this.ctlManager.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }

        } //--------------------------------------

        //event is raised when the link is clicked
        private void _frmIncDecSearchOnUpdate(string id)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (EarningUpdate frmUpdate = new EarningUpdate(_userInfo, _incManager, id))
                {
                    _frmIncDecSearch.WindowState = FormWindowState.Minimized;

                    frmUpdate.ShowDialog(this);

                    if (frmUpdate.HasUpdated)
                    {
                        this.ShowSearchResultDialog();
                    }

                    _frmIncDecSearch.WindowState = FormWindowState.Normal;
                }
                
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Updating An Earning");
            }
            finally
            {
                this.ctlManager.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }

        } //--------------------------------
        //##########################################END CLASS EarningDeductionSearchList EVENTS############################################

        //#########################################CLASS EarningDeductionEmployeeSearchList EVENTS##########################################
        //event is raised when the datagrid view is double click or entered
        private void _frmEmpSearchOnDoubleClickEnter(string id)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (EmployeeEarningSummary frmSummary = new EmployeeEarningSummary(_userInfo, _incManager.GetDetailsEmployeeInformation(id), _incManager))
                {
                    _frmEmpSearch.WindowState = FormWindowState.Minimized;

                    frmSummary.ShowDialog(this);

                    _frmEmpSearch.WindowState = FormWindowState.Normal;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Employee Earning Summary");
            }
            finally
            {
                this.ctlManager.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }
        } //-------------------------------------
        //#########################################END CLASS EarningDeductionEmployeeSearchList EVENTS##########################################


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
                    if (_forApply)
                    {
                        _frmIncDecSearch.DataSource = _incManager.GetSearchedEarningInformation(queryString);
                    }
                    else
                    {
                        ClientExchange.EmployeeSearchFilter searchFilter = new ClientExchange.EmployeeSearchFilter();

                        searchFilter.StringSearch = queryString;

                        _frmEmpSearch.DataSource = _incManager.GetSelectedEmployeeInformation(searchFilter);
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

        #endregion

    }
}
