using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace RegistrarServices
{
    partial class SpecialClassManager
    {
        #region Class General Variable Declarations
        private SpecialClassLogic _specialManager;
        private CommonExchange.SysAccess _userInfo;
        private SpecialClassSearchList _frmSpecialClassSearch;

        private String _dateStart = String.Empty;
        private String _dateEnd = String.Empty;
        #endregion

        #region Class Constructor
        public SpecialClassManager(CommonExchange.SysAccess userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;

            this.Load += new EventHandler(ClassLoad);
            this.ctlManager.OnClose += new RemoteClient.ControlManagerCloseButtonClick(ctlManagerOnClose);
            this.ctlManager.OnRefresh += new RemoteClient.ControlManagerRefreshButtonClick(ctlManagerOnRefresh);
            this.ctlManager.OnPressEnter += new RemoteClient.ControlSpecialClassManagerPressEnter(ctlManagerOnPressEnter);
            this.ctlManager.OnTextBoxKeyUp += new RemoteClient.ControlManagerTextBoxSearchKeyUp(ctlManagerOnTextBoxKeyUp);
            this.ctlManager.OnOptionCheckedChanged += new RemoteClient.ControlSpecialClassManagerOptionCheckedChanged(ctlManagerOnOptionCheckedChanged);
            this.ctlManager.OnSchoolYearSelectedIndexChanged += new RemoteClient.ControlSpecialClassManagerSchoolYearSelectedIndexChanged(ctlManagerOnSchoolYearSelectedIndexChanged);
            this.ctlManager.OnSemesterSelectedIndexChanged += new RemoteClient.ControlSpecialClassManagerSemesterSelectedIndexChanged(ctlManagerOnSemesterSelectedIndexChanged);
        }

        
        #endregion

        #region Class Event Void Procedures

        //####################################################CLASS SpecialClassManager EVENTS###############################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            try
            {
                _specialManager = new SpecialClassLogic(_userInfo);

                _frmSpecialClassSearch = new SpecialClassSearchList();
                _frmSpecialClassSearch.OnDoubleClickEnter += new SearchListDataGridDoubleClickEnter(_frmSpecialClassSearchOnDoubleClickEnter);
                _frmSpecialClassSearch.OnCreate += new SpecialClassSearchListLinkCreateClick(_frmSpecialClassSearchOnCreate);
                _frmSpecialClassSearch.LocationPoint = new Point(10, 400);
                _frmSpecialClassSearch.AdoptGridSize = true;
                _frmSpecialClassSearch.MdiParent = this;

                _specialManager.InitializeSchoolYearCombo(this.ctlManager.SchoolYearComboBox);

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_specialManager.ServerDateTime).ToString();

                if (!(RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessPayrollMaster(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessCashier(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessVpOfFinance(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessCollegeRegistrar(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessHighSchoolGradeSchoolRegistrar(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessVpOfAcademicAffairs(_userInfo)))
                {
                    throw new Exception("You are not authorized to access this module.");
                }
                else if (RemoteServerLib.ProcStatic.IsSystemAccessPayrollMaster(_userInfo) || 
                    RemoteServerLib.ProcStatic.IsSystemAccessCashier(_userInfo))
                {
                    _frmSpecialClassSearch.DisableCreateLink(false);
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog("\n" + ex.Message, "Error Authenticating");

                this.Close();
            }
        } //----------------------------------------
        //################################################END CLASS SpecialClassManager EVENTS################################################

        //############################################CONTROLSPECIALCLASSMANAGER ctlManager EVENTS##########################################
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

                _specialManager.RefreshSpecialClassData(_userInfo);

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_specialManager.ServerDateTime).ToString();

                this.ShowSearchResultDialog();
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Refreshing Classroom and Subject Manager");
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
                _frmSpecialClassSearch.SelectFirstRowInDataGridView();
            }
            else if (String.IsNullOrEmpty(RemoteClient.ProcStatic.TrimStartEndString(ctlManager.GetSearchString)))
            {
                _frmSpecialClassSearch.WindowState = FormWindowState.Minimized;

                this.ctlManager.SetFocusOnSearchTextBox();
            }
        } //--------------------------------

        //event is raised when the semester selected index is changed
        private void ctlManagerOnSemesterSelectedIndexChanged()
        {
            _dateStart = _specialManager.GetSemesterDateStart(_specialManager.GetSemesterSystemId(this.ctlManager.SchoolYearIndex,
               this.ctlManager.SemesterIndex)).ToShortDateString() + " 12:00:00 AM";
            _dateEnd = _specialManager.GetSemesterDateEnd(_specialManager.GetSemesterSystemId(this.ctlManager.SchoolYearIndex,
                this.ctlManager.SemesterIndex)).ToShortDateString() + " 11:59:59 PM";

            this.UpdateSpecialClassDataByDateStartEnd();

            this.ShowSearchResultDialog();
        } //-----------------------------------

        //event is raised when the school year selected index is changed
        private void ctlManagerOnSchoolYearSelectedIndexChanged()
        {
            _dateStart = _specialManager.GetSchoolYearDateStart(_specialManager.GetSchoolYearYearId(ctlManager.SchoolYearIndex)).ToShortDateString() +
                " 12:00:00 AM";
            _dateEnd = _specialManager.GetSchoolYearDateEnd(_specialManager.GetSchoolYearYearId(ctlManager.SchoolYearIndex)).ToShortDateString() + " 11:59:59 PM";

            this.UpdateSpecialClassDataByDateStartEnd();

            _specialManager.InitializeSemesterCombo(this.ctlManager.SemesterComboBox, this.ctlManager.SchoolYearIndex);

            this.ShowSearchResultDialog();
        } //-----------------------------------

        //event is raised when the option checked is changed
        private void ctlManagerOnOptionCheckedChanged()
        {
            _dateStart = _specialManager.GetSchoolYearDateStart(_specialManager.GetSchoolYearYearId(ctlManager.SchoolYearIndex)).ToShortDateString() +
                " 12:00:00 AM";
            _dateEnd = _specialManager.GetSchoolYearDateEnd(_specialManager.GetSchoolYearYearId(ctlManager.SchoolYearIndex)).ToShortDateString() + " 11:59:59 PM";

            this.UpdateSpecialClassDataByDateStartEnd();

            _specialManager.InitializeSemesterCombo(this.ctlManager.SemesterComboBox, this.ctlManager.SchoolYearIndex);

            this.ShowSearchResultDialog();
        } //-------------------------------

        //#########################################END CONTROLSPECIALCLASSMANAGER ctlManager EVENTS#########################################

        //##########################################CLASS SpecialClassSearchList EVENTS#######################################################
        //event is raised when the link open is clicked
        private void _frmSpecialClassSearchOnCreate()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (SpecialClassCreate frmCreate = new SpecialClassCreate(_userInfo, _specialManager))
                {
                    _frmSpecialClassSearch.WindowState = FormWindowState.Minimized;

                    frmCreate.ShowDialog(this);

                    if (frmCreate.HasCreated)
                    {
                        this.ShowSearchResultDialog();
                    }

                    _frmSpecialClassSearch.WindowState = FormWindowState.Normal;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Creating A Special Class Information");
            }
            finally
            {
                this.ctlManager.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }
        } //--------------------------------

        //event is raised when the datagrid is double clicked or entered
        private void _frmSpecialClassSearchOnDoubleClickEnter(string id)
        {
            this.ShowUpdateSpecialClassDialog(id);
        } //---------------------------------
        //##########################################END CLASS SpecialClassSearchList EVENTS###################################################
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure updates the special class data by date start and date end
        private void UpdateSpecialClassDataByDateStartEnd()
        {
            if (this.ctlManager.SchoolYearIndex != -1)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    _specialManager.GetByDateStartEndSpecialClassInformationTable(_userInfo, _dateStart, _dateEnd, ctlManager.IsMarkedDeleted);
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
            }
        } //--------------------------------

        //this procedure shows the search result
        private void ShowSearchResultDialog()
        {
            if (this.ctlManager.SchoolYearIndex != -1)
            {

                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    String queryString = RemoteClient.ProcStatic.TrimStartEndString(ctlManager.GetSearchString);

                    if (!String.IsNullOrEmpty(queryString))
                    {
                        if (ctlManager.SemesterIndex == -1)
                        {
                            _frmSpecialClassSearch.DataSource = _specialManager.GetSearchedSpecialClassInformation(queryString);
                        }
                        else
                        {
                            _frmSpecialClassSearch.DataSource = _specialManager.GetSearchedSpecialClassInformation(queryString,
                                _specialManager.GetSemesterSystemId(ctlManager.SchoolYearIndex, ctlManager.SemesterIndex));
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
            }
        }//--------------------------

        //this procedure shows the special class update dialog
        private void ShowUpdateSpecialClassDialog(String id)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (SpecialClassUpdate frmUpdate = new SpecialClassUpdate(_userInfo, _specialManager.GetDetailsSpecialClassInformation(id), _specialManager))
                {
                    _frmSpecialClassSearch.WindowState = FormWindowState.Minimized;

                    frmUpdate.ShowDialog(this);

                    if (frmUpdate.HasUpdated || frmUpdate.HasDeleted)
                    {
                        this.ShowSearchResultDialog();
                    }

                    _frmSpecialClassSearch.WindowState = FormWindowState.Normal;
                }

            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Update Special Class Information Module");
            }
            finally
            {
                this.ctlManager.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }
        } //-------------------------

        #endregion
    }
}
