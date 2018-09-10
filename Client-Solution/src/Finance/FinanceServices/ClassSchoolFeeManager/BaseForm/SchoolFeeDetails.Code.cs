using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class SchoolFeeDetails
    {
        #region Class General Variable Declaration
        protected CommonExchange.SysAccess _userInfo;
        protected CommonExchange.SchoolFeeDetails _detailsInfo;
        protected SchoolFeeLogic _schoolFeeManager;

        protected Boolean _isForCreate = true;

        protected String _yearId = String.Empty;

        private ErrorProvider _errProvider;
        #endregion

        #region Class Constructors
        public SchoolFeeDetails()
        {
            this.InitializeComponent();
        }

        public SchoolFeeDetails(CommonExchange.SysAccess userInfo, SchoolFeeLogic schoolFeeManager,
            String yearId, String courseGroupId, String yearLevelId, String feeLevelSysId)
        {
            this.InitializeComponent();

            _userInfo = userInfo;

            _schoolFeeManager = schoolFeeManager;

            _detailsInfo = new CommonExchange.SchoolFeeDetails();

            _detailsInfo.SchoolFeeLevelInfo.SchoolFeeInfo.SchoolYearInfo.YearId = yearLevelId;
            _detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.CourseGroupInfo.CourseGroupId = courseGroupId;
            _detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.YearLevelId = yearLevelId;
            _detailsInfo.SchoolFeeLevelInfo.FeeLevelSysId = feeLevelSysId;

            _yearId = yearId;

            this.lblSchoolYear.Text = _schoolFeeManager.GetSchoolYearDescription(yearId);
            this.lblCourseGroup.Text = _schoolFeeManager.GetCourseGroupDescription(courseGroupId);
            this.lblYearLevel.Text = _schoolFeeManager.GetYearLevelDescription(yearLevelId);

            _errProvider = new ErrorProvider();

            this.Load += new EventHandler(ClassLoad);
            this.cboSchoolYearParticular.SelectedIndexChanged += new EventHandler(cboSchoolYearParticularSelectedIndexChanged);
            this.chkLevelIncrease.CheckedChanged += new EventHandler(chkLevelIncreaseCheckedChanged);
            this.chkOptional.CheckedChanged += new EventHandler(chkOptionalCheckedChanged);
            this.chkGraduationFee.CheckedChanged += new EventHandler(chkGraduationFeeCheckedChanged);
            this.chkOfficeAccess.CheckedChanged += new EventHandler(chkOfficeAccessCheckedChanged);
            this.chkEntryLevelIncluded.CheckedChanged += new EventHandler(chkEntryLevelIncludedCheckedChanged);
            this.chklncldMale.CheckedChanged += new EventHandler(chklncldMaleCheckedChanged);
            this.chklncldFemale.CheckedChanged += new EventHandler(chklncldFemaleCheckedChanged);
            this.chklncldFirstSem.CheckedChanged += new EventHandler(chklncldFirstSemCheckedChanged);
            this.chklncldSecondSem.CheckedChanged += new EventHandler(chklncldSecondSemCheckedChanged);
            this.chklncldSummer.CheckedChanged += new EventHandler(chklncldSummerCheckedChanged);
            this.txtAmount.KeyPress += new KeyPressEventHandler(txtAmountKeyPress);
            this.txtAmount.Validating += new CancelEventHandler(txtAmountValidating);
            this.txtAmount.Validated += new EventHandler(txtAmountValidated);
        }
        #endregion

        #region Class Event Void Procedures
        //#####################################################CLASS SchoolFeeDetails EVENTS #################################################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            _schoolFeeManager.InitializedSchoolFeeParticularCombo(this.cboSchoolYearParticular, _detailsInfo.SchoolFeeLevelInfo.YearLevelInfo.YearLevelId);

            this.SetIncludeFirstSecondSemSummberCombo(_schoolFeeManager.IsSummer(_yearId));

            _detailsInfo.IncludeMale = this.chklncldMale.Checked = true;
            _detailsInfo.IncludeFemale = this.chklncldFemale.Checked = true;
        }//---------------------------
        //#####################################################END CLASS SchoolFeeDetails EVENTS #################################################################

        //##############################################COMBOBOX cboSchoolYearParticular EVENTS####################################################
        //event is raised when the control is validated
        private void cboSchoolYearParticularSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboSchoolYearParticular.SelectedIndex != -1)
            {
                _detailsInfo.SchoolFeeParticularInfo.FeeParticularSysId =
                    _schoolFeeManager.GetParticularSysId(_schoolFeeManager.GetConcatParticularSysId(this.cboSchoolYearParticular.Text));

                this.txtAmount.Focus();

                if (_isForCreate)
                {
                    _schoolFeeManager.InitializeSchoolFeeParticularCheckedBox(_detailsInfo.SchoolFeeParticularInfo.FeeParticularSysId, this.chkOptional,
                        this.chkOfficeAccess, this.chkEntryLevelIncluded, this.chkGraduationFee, ref _detailsInfo);
                }
            }
        }//------------------------------
        //##############################################END COMBOBOX cboSchoolYearParticular EVENTS####################################################

        //##############################################CHECKBOX chkLevelIncrease EVENTS####################################################
        //event is raised when the checked is changed
        private void chkLevelIncreaseCheckedChanged(object sender, EventArgs e)
        {
            _detailsInfo.IsLevelIncrease = this.chkLevelIncrease.Checked;
        }//-----------------------------
        //##############################################CHECKBOX chkLevelIncrease EVENTS####################################################

        //##############################################CHECKBOX chklncldSummer EVENTS####################################################
        //event is raised when the checked is changed
        private void chklncldSummerCheckedChanged(object sender, EventArgs e)
        {
            _detailsInfo.IncludeSummer = this.chklncldSummer.Checked;
        }//---------------------------
        //##############################################END CHECKBOX chklncldSummer EVENTS####################################################

        //##############################################CHECKBOX chklncldSecondSem EVENTS####################################################
        //event is raised when the checked is changed
        private void chklncldSecondSemCheckedChanged(object sender, EventArgs e)
        {
            _detailsInfo.IncludeSecondSemester = this.chklncldSecondSem.Checked;
        }//-----------------------------
        //##############################################END CHECKBOX chklncldSecondSem EVENTS####################################################

        //##############################################CHECKBOX  chklncldFirstSem EVENTS####################################################
        //event is raised when the checked is changed
        private void chklncldFirstSemCheckedChanged(object sender, EventArgs e)
        {
            _detailsInfo.IncludeFirstSemester = this.chklncldFirstSem.Checked;
        }//--------------------------------
        //##############################################END CHECKBOX  chklncldFirstSem EVENTS####################################################

        //##############################################CHECKBOX chklncldFemale EVENTS####################################################
        //event is raised when the checked is changed
        private void chklncldFemaleCheckedChanged(object sender, EventArgs e)
        {
            _detailsInfo.IncludeFemale = this.chklncldFemale.Checked;
        }//------------------------
        //##############################################END CHECKBOX chklncldFemale EVENTS####################################################

        //##############################################CHECKBOX chklncldMale EVENTS####################################################
        //event is raised when the checked is changed
        private void chklncldMaleCheckedChanged(object sender, EventArgs e)
        {
            _detailsInfo.IncludeMale = this.chklncldMale.Checked;
        }//--------------------
        //##############################################END CHECKBOX chklncldMale EVENTS####################################################

        //##############################################CHECKBOX chkEntryLevelIncluded EVENTS####################################################
        //event is raised when the checked is changed
        private void chkEntryLevelIncludedCheckedChanged(object sender, EventArgs e)
        {
            _detailsInfo.IsEntryLevelIncluded = this.chkEntryLevelIncluded.Checked;
        }//------------------------
        //##############################################END CHECKBOX chkEntryLevelIncluded EVENTS####################################################

        //##############################################CHECKBOX chkOfficeAccess EVENTS####################################################
        //event is raised when the checked is changed
        private void chkOfficeAccessCheckedChanged(object sender, EventArgs e)
        {
            _detailsInfo.IsOfficeAccess = this.chkOfficeAccess.Checked;
        }//-------------------------
        //##############################################END CHECKBOX chkOfficeAccess EVENTS####################################################

        //##############################################CHECKBOX chkGraduationFee EVENTS####################################################
        //event is raised when the checked is changed
        private void chkGraduationFeeCheckedChanged(object sender, EventArgs e)
        {
            _detailsInfo.IsGraduationFee = this.chkGraduationFee.Checked;
        }//--------------------------
        //##############################################END CHECKBOX chkGraduationFee EVENTS####################################################

        //##############################################CHECKBOX  chkOptional EVENTS####################################################
        //event is raised when the checked is changed
        private void chkOptionalCheckedChanged(object sender, EventArgs e)
        {
            _detailsInfo.IsOptional = this.chkOptional.Checked;
        }//----------------------------
        //##############################################END CHECKBOX  chkOptional EVENTS####################################################

        //##############################################END TEXTBOX txtAmount EVENTS####################################################
        //event is raised when the control is validated
        private void txtAmountValidated(object sender, EventArgs e)
        {
            Decimal amount;

            if (Decimal.TryParse(txtAmount.Text, out amount))
            {
                _detailsInfo.Amount = amount;
            }
        }//--------------------------

        //event is raised when the control is validating
        private void txtAmountValidating(object sender, CancelEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxValidateAmount((TextBox)sender);
        }//---------------------

        //event is raised when the control keypress
        private void txtAmountKeyPress(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxAmountOnly(e);
        }//----------------------
        //##############################################END TEXTBOX txtAmount EVENTS####################################################
        #endregion

        #region Programmers-Defined Void Procedures
        //this procedure will set include first sem, include second sem and include summer combo
        public void SetIncludeFirstSecondSemSummberCombo(Boolean isSummer)
        {
            if (isSummer)
            {
                this.chklncldSummer.Enabled = true;

                if (_isForCreate)
                {
                    this.chklncldSummer.Checked = true;
                }

                this.chklncldFirstSem.Enabled = this.chklncldSecondSem.Enabled = false;
                this.chklncldFirstSem.Checked = this.chklncldSecondSem.Checked = false;
            }
            else
            {
                this.chklncldSummer.Enabled = false;
                this.chklncldSummer.Checked = false;

                this.chklncldFirstSem.Enabled = this.chklncldSecondSem.Enabled = true;
                this.chklncldFirstSem.Checked = this.chklncldSecondSem.Checked = false;
            }
        }//-----------------------
        #endregion

        #region Programes-Defined Functions
        //this function will validate controls
        public Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.cboSchoolYearParticular, "");
            _errProvider.SetError(this.txtAmount, "");

            if (String.IsNullOrEmpty(_detailsInfo.SchoolFeeParticularInfo.FeeParticularSysId))
            {
                _errProvider.SetIconAlignment(this.cboSchoolYearParticular, ErrorIconAlignment.MiddleLeft);
                _errProvider.SetError(this.cboSchoolYearParticular, "School Fee Particular is required.");
                isValid = false;
            }

            if (_detailsInfo.Amount < 1)
            {
                _errProvider.SetIconAlignment(this.txtAmount, ErrorIconAlignment.MiddleRight);
                _errProvider.SetError(this.txtAmount, "An amount is required.");
                isValid = false;
            }

            if (_schoolFeeManager.IsExistsLevelParticularSchoolFeeDetails(_detailsInfo.SchoolFeeLevelInfo.FeeLevelSysId, 
                _detailsInfo.SchoolFeeParticularInfo.FeeParticularSysId))
            {
                _errProvider.SetIconAlignment(this.cboSchoolYearParticular, ErrorIconAlignment.MiddleRight);
                _errProvider.SetError(this.cboSchoolYearParticular, "Particular Description already exist.");

                isValid = false;
            }

            return isValid;
        }//-----------------------------        
        #endregion
    }
}
