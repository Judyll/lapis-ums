using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EmployeeServices
{
    partial class ApplyDeduction
    {
        #region Class General Variable Declarations
        private CommonExchange.SysAccess _userInfo;
        private CommonExchange.DeductionInformation _decInfo;
        private DeductionLogic _decManager;
        #endregion

        #region Class Properties Declarations
        private Boolean _hasCreated = false;
        public Boolean HasCreated
        {
            get { return _hasCreated; }
        }
        #endregion

        #region Class Constructor
        public ApplyDeduction(CommonExchange.SysAccess userInfo, CommonExchange.DeductionInformation decInfo, DeductionLogic decManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _decInfo = decInfo;
            _decManager = decManager;

            this.Load += new EventHandler(ClassLoad);
            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.ctlManager.OnClose += new RemoteClient.ControlManagerCloseButtonClick(ctlManagerOnClose);
            this.ctlManager.OnRefresh += new RemoteClient.ControlManagerRefreshButtonClick(ctlManagerOnRefresh);
            this.ctlManager.OnTextBoxKeyUp += new RemoteClient.ControlManagerTextBoxSearchKeyUp(ctlManagerOnTextBoxKeyUp);
            this.ctlManager.OnStatusCheckedChanged += new RemoteClient.ControlEmployeeManagerStatusOptionCheckedChanged(ctlManagerOnStatusCheckedChanged);            
            this.lnkChange.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkChangeLinkClicked);
            
        }        
        
        #endregion

        #region Class Event Void Procedures

        //############################################CLASS ApplyDeduction EVENTS######################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            lblId.Text = _decInfo.DeductionSysId;
            lblDescription.Text = _decInfo.Description;

            _decInfo.DeductionDate = _decManager.ServerDateTime;          
                       
            lblDate.Text = DateTime.Parse(_decInfo.DeductionDate).ToLongDateString();
            
        } //--------------------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasCreated)
            {
                String strMsg = "Are you sure you want to cancel the application of a deduction to employee(s)?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }

        } //------------------------------------
        //#########################################END CLASS ApplyDeduction EVENTS#####################################################

        //###########################################CONTROLEMPLOYEEMANAGER ctlManager EVENTS##########################################
        //event is raised when the button is clicked
        private void ctlManagerOnClose()
        {
            this.Close();   
        } //-------------------------------------

        //event is raised when the button is clicked
        private void ctlManagerOnRefresh()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                _decManager.RefreshDeductionData(_userInfo);                

            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Refreshing Deduction Manager");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }

        } //-------------------------------------

        //event is raised when the key is up on the search box
        void ctlManagerOnTextBoxKeyUp(object sender, KeyEventArgs e)
        {

            this.ShowSearchResultDialog();
            
        } //--------------------------------

        //event is raised when the status check changed
        private void ctlManagerOnStatusCheckedChanged()
        {
            this.ShowSearchResultDialog();
        } //-----------------------------
        //#######################################END CONTROLEMPLOYEEMANAGER ctlManager EVENTS##########################################        

        //############################################LINKBUTTON lnkChange EVENTS########################################################
        //event is raised when the link is clicked
        private void lnkChangeLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            DateTime bDate = DateTime.Parse(_decManager.ServerDateTime);

            using (RemoteClient.DatePicker frmPicker = new RemoteClient.DatePicker(bDate))
            {
                frmPicker.ShowDialog(this);

                if (frmPicker.HasSelectedDate)
                {
                    if (DateTime.TryParse(frmPicker.GetSelectedDate.ToShortDateString() + " " +
                        DateTime.Parse(_decManager.ServerDateTime).ToLongTimeString(), out bDate))
                    {
                        _decInfo.DeductionDate = bDate.ToString("o");
                    }

                    lblDate.Text = DateTime.Parse(_decInfo.DeductionDate).ToLongDateString();
                }
            }

            this.Cursor = Cursors.Arrow;

        } //--------------------------------
        //############################################END LINKBUTTON lnkChange EVENTS####################################################

        //################################################BUTTON btnApply EVENTS##########################################################
        //event is raised when the button is clicked
        protected override void btnApplyClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    String strMsg = "Are you sure you want to apply the deduction to the selected employee(s)?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Apply", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The deduction has been successfully applied to the selected employee(s).";

                        Decimal amount = 0;

                        if (Decimal.TryParse(txtAmount.Text, out amount))
                        {
                            _decInfo.Amount = amount;
                        }

                        _decManager.InsertEmployeeDeduction(_userInfo, _decInfo, cbxEmployee);

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasCreated = true;

                        this.Close();
                    }
                    else if (msgResult == DialogResult.Cancel)
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Applying");
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }

        } //--------------------------------------------
        //###############################################END BUTTON btnApply EVENTS#######################################################


        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure shows the search result
        private void ShowSearchResultDialog()
        {
            ClientExchange.EmployeeSearchFilter searchFilter = new ClientExchange.EmployeeSearchFilter();

            searchFilter.StringSearch = String.IsNullOrEmpty(ctlManager.GetSearchString) ? "" : ctlManager.GetSearchString;
            searchFilter.IncludePartTime = ctlManager.IncludePartTime;
            searchFilter.IncludeProbationary = ctlManager.IncludeProbationary;
            searchFilter.IncludeRegular = ctlManager.IncludeRegular;
            searchFilter.IncludeLayOff = false;
            searchFilter.IncludeGraduateSchoolFaculty = ctlManager.IncludeGraduateSchoolFaculty;
            searchFilter.IncludeGraduateSchoolCollegeFaculty = ctlManager.IncludeGraduateSchoolCollegeFaculty;
            searchFilter.IncludeGraduateSchoolHighSchoolFaculty = ctlManager.IncludeGraduateSchoolHighSchoolFaculty;
            searchFilter.IncludeGraduateSchoolGradeKinderFaculty = ctlManager.IncludeGraduateSchoolGradeSchoolKinderFaculty;
            searchFilter.IncludeCollegeFaculty = ctlManager.IncludeCollegeFaculty;
            searchFilter.IncludeHighSchoolFaculty = ctlManager.IncludeHighSchoolFaculty;
            searchFilter.IncludeGradeKinderFaculty = ctlManager.IncludeGradeKinderFaculty;
            searchFilter.IncludeStaff = ctlManager.IncludeStaff;
            searchFilter.IncludeAcademic = ctlManager.IncludeAcademic;
            searchFilter.IncludeMaintenance = ctlManager.IncludeMaintenance;

            this.SetEmployeeCheckedListBox(_decManager.GetSelectedEmployeeForDeduction(searchFilter), "employee_name");

            this.ctlManager.SetFocusOnSearchTextBox();

        } //--------------------------

        #endregion
    }
}
