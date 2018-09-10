using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FinanceServices
{
    internal partial class SchoolFeeDetailsUpdate
    {

        #region Class General Variable Declaration
        private CommonExchange.SchoolFeeDetails _detailsInfoTemp;
        #endregion

        #region Class Properties Declarations
        private Boolean _hasUpdated = false;
        public Boolean HasUpdated
        {
            get { return _hasUpdated; }
        }

        private Boolean _hasDeleted = false;
        public Boolean HasDeleted
        {
            get { return _hasDeleted; }
        }
        #endregion

        #region Class Constructors
        public SchoolFeeDetailsUpdate()
        {
            this.InitializeComponent();
        }
        
        public SchoolFeeDetailsUpdate(CommonExchange.SysAccess userInfo, CommonExchange.SchoolFeeDetails detailsInfo, SchoolFeeLogic schoolFeeManager,
            String yearId, String courseGroupId, String yearLevelId, String feeLevelSysId)
            : base(userInfo, schoolFeeManager, yearId, courseGroupId, yearLevelId, feeLevelSysId)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _detailsInfo = detailsInfo;
            _detailsInfoTemp = (CommonExchange.SchoolFeeDetails)detailsInfo.Clone();
            _schoolFeeManager = schoolFeeManager;

            _isForCreate = false;

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnEdit.Click += new EventHandler(btnEditClick);
            this.btnDelete.Click += new EventHandler(btnDeleteClick);
        }     
        
        #endregion

        #region Class Event Void Procedure
        //############################################CLASS SchoolFeeDetailsUpdate EVENTS#######################################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            _schoolFeeManager.InitializedSchoolFeeParticularCombo(this.cboSchoolYearParticular, _detailsInfo.SchoolFeeParticularInfo.FeeParticularSysId, 
                _detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.YearLevelId);

            this.SetIncludeFirstSecondSemSummberCombo(_schoolFeeManager.IsSummer(_yearId));

            this.chkOptional.Checked = _detailsInfo.IsOptional;
            this.chkOfficeAccess.Checked = _detailsInfo.IsOfficeAccess;
            this.chkEntryLevelIncluded.Checked = _detailsInfo.IsEntryLevelIncluded;
            this.chkGraduationFee.Checked = _detailsInfo.IsGraduationFee;
            this.chklncldMale.Checked = _detailsInfo.IncludeMale;
            this.chklncldFemale.Checked = _detailsInfo.IncludeFemale;

            if (this.chklncldFirstSem.Enabled)
            {
                this.chklncldFirstSem.Checked = _detailsInfo.IncludeFirstSemester;
                this.chklncldSecondSem.Checked = _detailsInfo.IncludeSecondSemester;
            }

            if (this.chklncldSummer.Enabled)
            {
                this.chklncldSummer.Checked = _detailsInfo.IncludeSummer;
            }

            this.lblSysID.Text = _detailsInfo.FeeDetailsSysId;
            this.txtAmount.Text = _detailsInfo.Amount.ToString("N");

            this.chkLevelIncrease.Checked = _detailsInfo.IsLevelIncrease;
        }//----------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if ((!_hasUpdated || !_hasDeleted) && !_detailsInfo.Equals(_detailsInfoTemp))
            {
                String strMsg = "There has been changes made in the current School Fee Details Module. \nExiting will not save this changes." +
                               "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//--------------------------
        //############################################END CLASS SchoolFeeDetailsUpdate EVENTS#######################################################

        //################################################BUTTON btnClose EVENTS####################################################
        //event is raised when btnClose is Clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//-------------------
        //################################################END BUTTON btnClose EVENTS####################################################

        //################################################BUTTON btnUpdate EVENTS####################################################
        //event is raised when btnUpdate is Clicked
        private void btnEditClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to edit the school fee details [" + _detailsInfo.SchoolFeeParticularInfo.ParticularDescription + 
                        " - " + _detailsInfo.Amount + "]";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Create", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The school fee details has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _schoolFeeManager.UpdateSchoolFeeDetails(_detailsInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdated = _hasDeleted = true;

                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Updating");
                }
            }
        }//-------------------
        //################################################END BUTTON btnUpdate EVENTS####################################################

        //################################################BUTTON btnDelete EVENTS####################################################
        //event is raised when btnDelete is Clicked
        private void btnDeleteClick(object sender, EventArgs e)
        {
            try
            {
                String strMsg = "Are you sure you want to delete the school fee details [" + _detailsInfo.SchoolFeeParticularInfo.ParticularDescription + " - " +
                    _detailsInfo.Amount + "]";

                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (msgResult == DialogResult.Yes)
                {
                    strMsg = "The school fee details has been successfully deleted.";

                    this.Cursor = Cursors.WaitCursor;

                    _schoolFeeManager.DeleteSchoolFeeDetails(_detailsInfo);

                    this.Cursor = Cursors.Arrow;

                    MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    _hasDeleted = _hasUpdated = true;

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Deleting");
            }
        }//------------------------
        //################################################END BUTTON btnDelete EVENTS####################################################
        #endregion
    }
}
