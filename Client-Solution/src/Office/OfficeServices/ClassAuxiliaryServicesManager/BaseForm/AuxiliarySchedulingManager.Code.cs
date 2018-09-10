using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class AuxiliarySchedulingManager
    {
        #region Class Data Member Declaration
        private AuxiliaryServiceLogic _auxiliaryManager;
        private CommonExchange.SysAccess _userInfo;
        private AuxiliaryScheduleDetailsSearchList _frmServiceScheduleSearch;

        private String _dateStart;
        private String _dateEnd;
        #endregion

        #region Class Constructor
        public AuxiliarySchedulingManager(CommonExchange.SysAccess userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;

            this.Load += new EventHandler(ClassLoad);
            this.ctlManagerAux.OnClose += new RemoteClient.ControlManagerCloseButtonClick(cltMangerOnClose);
            this.ctlManagerAux.OnRefresh += new RemoteClient.ControlManagerRefreshButtonClick(ctlManagerOnRefresh);
            this.ctlManagerAux.OnPressEnter += new RemoteClient.ControlSubjectSchedulingManagerPressEnter(ctlManagerAuxOnPressEnter);
            this.ctlManagerAux.OnTextBoxKeyUp += new RemoteClient.ControlManagerTextBoxSearchKeyUp(ctlManagerOnTextBoxKeyUp);
            this.ctlManagerAux.OnOptionCheckedChanged += new RemoteClient.ControlSubjectSchedulingManagerOptionCheckedChanged(ctlManagerOnOptionCheckedChanged);
            this.ctlManagerAux.OnSchoolYearSelectedIndexChanged += 
                new RemoteClient.ControlSubjectSchedulingManagerSchoolYearSelectedIndexChanged(ctlManagerOnSchoolYearSelectedIndexChanged);
            this.ctlManagerAux.OnSemesterSelectedIndexChanged += 
                new RemoteClient.ControlSubjectSchedulingManagerSemesterSelectedIndexChanged(ctlManagerOnSemesterSelectedIndexChanged);
        }

        #endregion

        #region Class Event Void Procedure
        //####################################################CLASS SubjectSchedulingManager EVENTS###############################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            try
            {
                if (!(RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessVpOfAcademicAffairs(_userInfo) ||
                    RemoteServerLib.ProcStatic.IsSystemAccessSecretaryOftheVpOfAcademicAffairs(_userInfo)))
                {
                    throw new Exception("You are not authorized to access this module.");
                }
           
            _auxiliaryManager = new AuxiliaryServiceLogic(_userInfo);

            _frmServiceScheduleSearch = new AuxiliaryScheduleDetailsSearchList();
            _frmServiceScheduleSearch.OnDoubleClickEnter += new SearchListDataGridDoubleClickEnter(_frmServiceScheduleSearchOnDoubleClickEnter);
            _frmServiceScheduleSearch.OnCreate += new AuxiliaryScheduleDetailsListLinkCreateClick(_frmServiceScheduleSearchOnCreate);
            _frmServiceScheduleSearch.LocationPoint = new Point(10, 300);
            _frmServiceScheduleSearch.AdoptGridSize = true;
            _frmServiceScheduleSearch.MdiParent = this;

            _auxiliaryManager.InitializeSchoolYearCombo(this.ctlManagerAux.SchoolYearComboBox);

            if (this.ctlManagerAux.SchoolYearIndex != -1)
                _auxiliaryManager.InitializeSemesterCombo(this.ctlManagerAux.SemesterComboBox, this.ctlManagerAux.SchoolYearIndex);
            
            lblRecordDate.Text = "Record Date: " + DateTime.Parse(_auxiliaryManager.ServerDateTime).ToString();
        }
        catch (Exception ex)
        {
            RemoteClient.ProcStatic.ShowErrorDialog("\n" + ex.Message, "Error Authenticating");
            this.Close();
        }

        }//---------------------------------
        //####################################################END CLASS SubjectSchedulingManager EVENTS###############################################

        //############################################CONTROLSPECIALCLASSMANAGER ctlManager EVENTS##########################################
        //event is raised when the button is click
        private void cltMangerOnClose()
        {
            this.Close();
        }//---------------------------

        ////event is raised when the button is click
        void ctlManagerOnRefresh()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _auxiliaryManager.RefreshAuxiliaryServiceInformationClassData(_userInfo);

                lblRecordDate.Text = "Record Date: " + DateTime.Parse(_auxiliaryManager.ServerDateTime).ToString();

                this.ShowSearchResultDialog();
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Refreshing Subject Scheduling Manager");
            }
            finally
            {
                this.ctlManagerAux.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }
        }//-----------------------------

        //event is raised when key is up on search textbox
        private void ctlManagerOnTextBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                _frmServiceScheduleSearch.SelectFirstRowInDataGridView();
            }
            else if (String.IsNullOrEmpty(RemoteClient.ProcStatic.TrimStartEndString(ctlManagerAux.GetSearchString)))
            {
                _frmServiceScheduleSearch.WindowState = FormWindowState.Minimized;

                this.ctlManagerAux.SetFocusOnSearchTextBox();
            }
        }//-------------------------------

        //event is raised when option checked change
        private void ctlManagerOnOptionCheckedChanged()
        {
            if (this.ctlManagerAux.SchoolYearIndex != -1)
            {
                _auxiliaryManager.InitializeSchoolYearCombo(this.ctlManagerAux.SchoolYearComboBox);
                //_auxiliaryManager.InitializeSemesterCombo(this.ctlManagerAux.SemesterComboBox, this.ctlManagerAux.SchoolYearIndex);

                this.ShowSearchResultDialog();
            }
        }//---------------------------

        //event is raised when school year selected index change
        private void ctlManagerOnSchoolYearSelectedIndexChanged()
        {
            if (this.ctlManagerAux.SchoolYearIndex != -1)
            {
                _auxiliaryManager.InitializeSemesterCombo(this.ctlManagerAux.SemesterComboBox, this.ctlManagerAux.SchoolYearIndex);

                _dateStart = _auxiliaryManager.GetSchoolYearDateStart(_auxiliaryManager.GetSchoolYearYearId(ctlManagerAux.SchoolYearIndex)).ToShortDateString() +
                    " 12:00:00 AM";
                _dateEnd = _auxiliaryManager.GetSchoolYearDateEnd(_auxiliaryManager.GetSchoolYearYearId(ctlManagerAux.SchoolYearIndex)).ToShortDateString() +
                    " 11:59:59 PM";
                
                this.ShowSearchResultDialog();
            }
        }//------------------------

        //event is raised when semester selected index change
        private void ctlManagerOnSemesterSelectedIndexChanged()
        {
            _dateStart = _auxiliaryManager.GetSemesterDateStart(_auxiliaryManager.GetSemesterSystemId(this.ctlManagerAux.SchoolYearIndex,
                this.ctlManagerAux.SemesterIndex)).ToShortDateString() + " 12:00:00 AM"; ;
            _dateEnd = _auxiliaryManager.GetSemesterDateEnd(_auxiliaryManager.GetSemesterSystemId(this.ctlManagerAux.SchoolYearIndex,
                this.ctlManagerAux.SemesterIndex)).ToShortDateString() + " 11:59:59 PM";            

            this.ShowSearchResultDialog();
        }//----------------------------------------

        //event is raised when enter key is pressed
        private void ctlManagerAuxOnPressEnter(object sender, KeyEventArgs e)
        {
            if (this.ctlManagerAux.SchoolYearIndex != -1)
                this.ShowSearchResultDialog();
        }
        //#########################################END CONTROLSPECIALCLASSMANAGER ctlManager EVENTS#########################################

        //##########################################CLASS SubjectScheduleSearchList EVENTS#######################################################
        //event is raised when the datagrid is double clicked or entered
        private void _frmServiceScheduleSearchOnDoubleClickEnter(String id)
        {
            this.ShowUpdateAuxiliaryServiceScheduleDialog(id);
        }

        //event is raised when the link open is clicked
        private void _frmServiceScheduleSearchOnCreate()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (AuxiliaryScheduleCreate frmCreate = new AuxiliaryScheduleCreate(_userInfo, _auxiliaryManager))
                {
                    _frmServiceScheduleSearch.WindowState = FormWindowState.Minimized;

                    frmCreate.ShowDialog(this);

                    if (frmCreate.HasCreated)
                    {
                        this.ShowSearchResultDialog();
                    }

                    _frmServiceScheduleSearch.WindowState = FormWindowState.Normal;
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Creating A Subject Schedule");
            }
            finally
            {
                this.ctlManagerAux.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }
        }
        //##########################################END CLASS SubjectScheduleSearchList EVENTS#######################################################

        #endregion

        #region Programers-Defined Void Procedures
        //this procedure updates the special class data by date start and date end
        private void SelectByDateStartEndScheduleInformationDetails(String queryString)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _auxiliaryManager.SelectByDateStartEndAuxiliaryServiceDetails(_userInfo, queryString, _dateStart, _dateEnd, this.ctlManagerAux.IsMarkedDeleted);
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Retrieving Data");
            }
            finally
            {
                this.ctlManagerAux.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }
        }//--------------------------------

        //this procedure shows the search result
        private void ShowSearchResultDialog()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                String queryString = RemoteClient.ProcStatic.TrimStartEndString(ctlManagerAux.GetSearchString);

                if (!String.IsNullOrEmpty(queryString))
                {
                    this.SelectByDateStartEndScheduleInformationDetails(queryString);
                   
                    _frmServiceScheduleSearch.DataSource = _auxiliaryManager.GetAuxiliaryServiceScheduleDetailsInfomation();
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Retrieving Data");
            }
            finally
            {
                this.ctlManagerAux.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }

        } //--------------------------

        //this procedure shows the subject schedule update dialog
        private void ShowUpdateAuxiliaryServiceScheduleDialog(String id)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (AuxiliaryScheduleUpdate frmUpdate = new AuxiliaryScheduleUpdate(_userInfo, _auxiliaryManager.GetDetailsAuxiliarySchedule(id),
                    _auxiliaryManager))
                {
                    _frmServiceScheduleSearch.WindowState = FormWindowState.Minimized;

                    frmUpdate.ShowDialog(this);

                    if (frmUpdate.HasUpdated || frmUpdate.HasDeleted)
                    {
                        this.ShowSearchResultDialog();
                    }

                    _frmServiceScheduleSearch.WindowState = FormWindowState.Normal;
                }

            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Update Auxiliary Service Schedule Module");
            }
            finally
            {
                this.ctlManagerAux.SetFocusOnSearchTextBox();

                this.Cursor = Cursors.Arrow;
            }
        } //-------------------------

        #endregion
    }
}
