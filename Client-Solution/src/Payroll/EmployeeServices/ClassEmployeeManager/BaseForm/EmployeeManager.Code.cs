using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace EmployeeServices
{
    partial class EmployeeManager
    {
        #region Class General Variable Declarations
        private EmployeeLogic _empManager;
        private CommonExchange.SysAccess _userInfo;
        private EmployeeSearchList _frmSearch;        
        private ClientExchange.EmployeeSearchFilter _searchFilter;
        #endregion

        #region Class Constructor
        public EmployeeManager(CommonExchange.SysAccess userInfo)
        {
            _userInfo = userInfo;

            this.InitializeComponent();

            this.Load += new EventHandler(ClassLoad);
            this.FormClosed += new FormClosedEventHandler(ClassClosed);
            this.ctlManager.OnClose += new RemoteClient.ControlManagerCloseButtonClick(ctlManagerOnClose);
            this.ctlManager.OnRefresh += new RemoteClient.ControlManagerRefreshButtonClick(ctlManagerOnRefresh);
            this.ctlManager.OnAdd += new RemoteClient.ControlEmployeeManagerButtonAddClick(ctlManagerOnAdd);
            this.ctlManager.OnPressEnter += new RemoteClient.ControlEmployeeManagerPressEnter(ctlManagerOnPressEnter);
            this.ctlManager.OnTextBoxKeyUp += new RemoteClient.ControlManagerTextBoxSearchKeyUp(ctlManagerOnTextBoxKeyUp);
            this.ctlManager.OnStatusCheckedChanged += new RemoteClient.ControlEmployeeManagerStatusOptionCheckedChanged(ctlManagerOnStatusCheckedChanged);
        }
        #endregion

        #region Class Event Void Procedures
        //###########################################CLASS EmployeeManager EVENTS#############################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            try
            {
                _empManager = new EmployeeLogic(_userInfo);
                _searchFilter = new ClientExchange.EmployeeSearchFilter();

                _frmSearch = new EmployeeSearchList();
                _frmSearch.OnDoubleClickEnter += new SearchListDataGridDoubleClickEnter(_frmSearchOnDoubleClickEnter);
                _frmSearch.LocationPoint = new Point(50, 300);
                _frmSearch.AdoptGridSize = true;
                _frmSearch.MdiParent = this;

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_empManager.ServerDateTime).ToString();

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
            
        }//------------------------------

        //event is raised when the class is closed
        private void ClassClosed(object sender, FormClosedEventArgs e)
        {
            _empManager.DeleteImageDirectory(Application.StartupPath);
        }//------------------------------

        //########################################END CLASS EmployeeManager EVENTS##############################################

        //#################################CONTROLEMPLOYEEMANAGER ctlManager EVENTS#######################################
        //event is raised when the close button is clicked
        private void ctlManagerOnClose()
        {
            this.Close();
        }//----------------------------

        //event is raised when the refresh button is clicked
        private void ctlManagerOnRefresh()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _empManager.RefreshEmployeeData(_userInfo);

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_empManager.ServerDateTime).ToString();

                this.ShowSearchResultDialog();
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Refreshing Employee Manager");
            }
            finally
            {
                this.ctlManager.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }

        }//----------------------------

        //event is raised when the add button is clicked
        private void ctlManagerOnAdd()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (EmployeeCreate frmCreate = new EmployeeCreate(_userInfo, _empManager))
                {
                    this._frmSearch.WindowState = FormWindowState.Minimized;
                    this._frmSearch.Hide();

                    frmCreate.ShowDialog(this);

                    if (frmCreate.HasCreated)
                    {
                        this.ShowSearchResultDialog();
                    }
                    else if (frmCreate.IsForEmployeeUpdate)
                    {
                        this.ShowUpdateEmployeeDialog(frmCreate.EmployeeInformationUpdate);
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Create Employee Module");
            }
            finally
            {
                this.ctlManager.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }            
        }//----------------------------

        //event is raised when the user press the enter key
        private void ctlManagerOnPressEnter(object sender, KeyEventArgs e)
        {
            this.ShowSearchResultDialog();
        }//--------------------------------

        //event is raised when the key is up on the search box
        private void ctlManagerOnTextBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                _frmSearch.SelectFirstRowInDataGridView();
            }
            else if (String.IsNullOrEmpty(RemoteClient.ProcStatic.TrimStartEndString(ctlManager.GetSearchString)))
            {
                _frmSearch.WindowState = FormWindowState.Minimized;

                this.ctlManager.SetFocusOnSearchTextBox();
            }
        }//--------------------------------

        //event is raised when the status check changed
        private void ctlManagerOnStatusCheckedChanged()
        {
            this.ShowSearchResultDialog();
        }//-----------------------------
        //################################END CONTROLEMPLOYEEMANAGER ctlManager EVENTS#####################################    
    
        //#####################################CLASS EmployeeSearchList EVENTS###############################################
        //event is raised when the class double clicks or press enter
        private void _frmSearchOnDoubleClickEnter(string id)
        {
            this.ShowUpdateEmployeeDialog(id);
        }//----------------------------------
        //####################################END CLASS EmployeeSearchList EVENTS##############################################
        
        #endregion

        #region Programmer-Defined Void Procedures
        //this procedure shows the search result
        private void ShowSearchResultDialog()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _searchFilter.StringSearch = RemoteClient.ProcStatic.TrimStartEndString(ctlManager.GetSearchString);
                _searchFilter.IncludePartTime = ctlManager.IncludePartTime;
                _searchFilter.IncludeProbationary = ctlManager.IncludeProbationary;
                _searchFilter.IncludeRegular = ctlManager.IncludeRegular;
                _searchFilter.IncludeLayOff = ctlManager.IncludeLayOff;
                _searchFilter.IncludeGraduateSchoolFaculty = ctlManager.IncludeGraduateSchoolFaculty;
                _searchFilter.IncludeGraduateSchoolCollegeFaculty = ctlManager.IncludeGraduateSchoolCollegeFaculty;
                _searchFilter.IncludeGraduateSchoolHighSchoolFaculty = ctlManager.IncludeGraduateSchoolHighSchoolFaculty;
                _searchFilter.IncludeGraduateSchoolGradeKinderFaculty = ctlManager.IncludeGraduateSchoolGradeSchoolKinderFaculty;
                _searchFilter.IncludeCollegeFaculty = ctlManager.IncludeCollegeFaculty;
                _searchFilter.IncludeHighSchoolFaculty = ctlManager.IncludeHighSchoolFaculty;
                _searchFilter.IncludeGradeKinderFaculty = ctlManager.IncludeGradeKinderFaculty;
                _searchFilter.IncludeStaff = ctlManager.IncludeStaff;
                _searchFilter.IncludeAcademic = ctlManager.IncludeAcademic;
                _searchFilter.IncludeMaintenance = ctlManager.IncludeMaintenance;

                if (!String.IsNullOrEmpty(_searchFilter.StringSearch))
                {
                    _frmSearch.DataSource = _empManager.GetSelectedEmployeeInformation(_searchFilter);
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

        //this procedure shows the updated form
        private void ShowUpdateEmployeeDialog(String id)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!String.IsNullOrEmpty(id))
                {
                    using (EmployeeUpdate frmUpdate = new EmployeeUpdate(_userInfo,
                        _empManager.GetDetailsEmployeeInformation(_userInfo, id, Application.StartupPath, true), _empManager))
                    {
                        _frmSearch.WindowState = FormWindowState.Minimized;

                        frmUpdate.ShowDialog(this);

                        if (frmUpdate.HasUpdated)
                        {
                            _frmSearch.DataSource = _empManager.GetSelectedEmployeeInformation(_searchFilter);
                        }

                        _frmSearch.WindowState = FormWindowState.Normal;
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Update Employee Module");
            }
            finally
            {
                this.ctlManager.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }
        }//-------------------------------

        //this procedure shows the updated form
        private void ShowUpdateEmployeeDialog(CommonExchange.Employee empInfo)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (empInfo != null)
                {
                    Boolean isForEmployeeUpdate = false;

                    using (EmployeeUpdate frmUpdate = new EmployeeUpdate(_userInfo, empInfo, _empManager))
                    {
                        _frmSearch.WindowState = FormWindowState.Minimized;

                        frmUpdate.ShowDialog(this);

                        if (frmUpdate.HasUpdated)
                        {
                            _frmSearch.DataSource = _empManager.GetSelectedEmployeeInformation(_searchFilter);
                        }
                        else if (frmUpdate.IsForEmployeeUpdate)
                        {
                            isForEmployeeUpdate = true;

                            empInfo = frmUpdate.EmployeeInformation;
                        }

                        _frmSearch.WindowState = FormWindowState.Normal;
                    }

                    if (isForEmployeeUpdate)
                    {
                        this.ShowUpdateEmployeeDialog(empInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Update Employee Module");
            }
            finally
            {
                this.ctlManager.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }
        }//-------------------------------
        #endregion

    }
}
