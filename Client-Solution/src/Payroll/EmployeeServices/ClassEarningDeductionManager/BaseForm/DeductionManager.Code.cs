using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace EmployeeServices
{
    partial class DeductionManager
    {

        #region Class General Variable Declarations
        private DeductionLogic _decManager;
        private CommonExchange.SysAccess _userInfo;
        private EarningDeductionSearchList _frmIncDecSearch;
        private EarningDeductionEmployeeSearchList _frmEmpSearch;
        private Boolean _forApply;
        #endregion

        #region Class Constructor
        public DeductionManager(CommonExchange.SysAccess userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;

            this.Load += new EventHandler(ClassLoad);
            this.ctlManager.OnClose += new RemoteClient.ControlManagerCloseButtonClick(ctlManagerOnClose);
            this.ctlManager.OnRefresh += new RemoteClient.ControlManagerRefreshButtonClick(ctlManagerOnRefresh);
            this.ctlManager.OnPressEnter += new RemoteClient.ControlEarningDeductionManagerPressEnter(ctlManagerOnPressEnter);
            this.ctlManager.OnTextBoxKeyUp += new RemoteClient.ControlManagerTextBoxSearchKeyUp(ctlManagerOnTextBoxKeyUp);
            this.ctlManager.OnModeOptionCheckedChanged += new RemoteClient.ControlEarningDeductionManagerModeOptionCheckedChanged(ctlManagerOnModeOptionCheckedChanged);

        }
        
        #endregion

        #region Class Event Void Procedures

        //###########################################CLASS DeductionManager EVENTS#####################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            try
            {
                _decManager = new DeductionLogic(_userInfo);

                _frmIncDecSearch = new EarningDeductionSearchList();
                _frmIncDecSearch.InitializeControl(true);
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

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_decManager.ServerDateTime).ToString();

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
                RemoteClient.ProcStatic.ShowErrorDialog("\n" + ex.Message, "Error Authenticating");

                this.Close();
            }

        }

        //#######################################END CLASS DeductionManager EVENTS#####################################################

        //############################################CONTROLDEDUCTIONMANAGER ctlManager EVENTS##########################################
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

                _decManager.RefreshDeductionData(_userInfo);

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_decManager.ServerDateTime).ToString();
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Refreshing Deduction Manager");
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

        //#########################################END CONTROLDEDUCTIONMANAGER ctlManager EVENTS#########################################

        //############################################CLASS EarningDeductionSearchList EVENTS##############################################
        //event is raised when the datagrid is double click or enter
        private void _frmIncDecSearchOnDoubleClickEnter(string id)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (ApplyDeduction frmApply = new ApplyDeduction(_userInfo, _decManager.GetDetailsDeductionInformation(id), _decManager))
                {
                    _frmIncDecSearch.WindowState = FormWindowState.Minimized;

                    frmApply.ShowDialog(this);

                    _frmIncDecSearch.WindowState = FormWindowState.Normal;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Apply Deduction Module");
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

                using (DeductionCreate frmCreate = new DeductionCreate(_userInfo, _decManager))
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
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Creating A Deduction");
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

                using (DeductionUpdate frmUpdate = new DeductionUpdate(_userInfo, _decManager, id))
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
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Updating A Deduction");
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

                using (EmployeeDeductionSummary frmSummary = new EmployeeDeductionSummary(_userInfo, _decManager.GetDetailsEmployeeInformation(id), _decManager))
                {
                    _frmEmpSearch.WindowState = FormWindowState.Minimized;

                    frmSummary.ShowDialog();

                    _frmEmpSearch.WindowState = FormWindowState.Normal;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Employee Deduction Summary");
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
                        _frmIncDecSearch.DataSource = _decManager.GetSearchedDeductionInformation(queryString);
                    }
                    else
                    {
                        ClientExchange.EmployeeSearchFilter searchFilter = new ClientExchange.EmployeeSearchFilter();

                        searchFilter.StringSearch = queryString;

                        _frmEmpSearch.DataSource = _decManager.GetSelectedEmployeeInformation(searchFilter);
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
