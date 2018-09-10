using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace EmployeeServices
{
    partial class Employee
    {
        #region Class Data Member Declarations
        protected EmployeeLogic _empManager;        

        private Timer _tmrAlert = new Timer();

        protected Int32 _rowIndexForPersonSearch = -1;
        #endregion

        #region Class Properties Declaration
        protected CommonExchange.Employee _empInfo;
        public CommonExchange.Employee EmployeeInformationUpdate
        {
            get { return _empInfo; }
        }

        protected Boolean _isForEmployeeUpdate = false;
        public Boolean IsForEmployeeUpdate
        {
            get { return _isForEmployeeUpdate; }
        }  
        #endregion

        #region Class Constructor
        public Employee()
        {
            this.InitializeComponent();
        }

        public Employee(CommonExchange.SysAccess userInfo, EmployeeLogic empManager)
            : base(userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _empManager = empManager;

            this.Load += new EventHandler(ClassLoad);
            this.cboType.SelectedIndexChanged += new EventHandler(cboTypeSelectedIndexChanged);
            this.cboStatus.SelectedIndexChanged += new EventHandler(cboStatusSelectedIndexChanged);
            this.cboDepartment.SelectedIndexChanged += new EventHandler(cboDepartmentSelectedIndexChanged);
            this.cboLevel.SelectedIndexChanged += new EventHandler(cboLevelSelectedIndexChanged);
            this.cboCategory.SelectedIndexChanged += new EventHandler(cboCategorySelectedIndexChanged);
            this.cboDegree.SelectedIndexChanged += new EventHandler(cboDegreeSelectedIndexChanged);
            this.cboPoints.SelectedIndexChanged += new EventHandler(cboPointsSelectedIndexChanged);
            this.cboRestDay.SelectedIndexChanged += new EventHandler(cboRestDaySelectedIndexChanged);
            this.txtPagibigId.Validated += new EventHandler(txtPagibigIdValidated);
            this.txtSssId.Validated += new EventHandler(txtSssIdValidated);
            this.txtPhilHealthId.Validated += new EventHandler(txtPhilHealthIdValidated);
            
            this.tmeFirstIn.Validated += new EventHandler(tmeFirstInValidated);
            this.tmeFirstOut.Validated += new EventHandler(tmeFirstOutValidated);
            this.tmeSecondIn.Validated += new EventHandler(tmeSecondInValidated);
            this.tmeSecondOut.Validated += new EventHandler(tmeSecondOutValidated);

            this.txtEmployeeId.Validated += new EventHandler(txtEmployeeIdValidated);

            this.chkFixedTime.CheckedChanged += new EventHandler(chkFixedTimeCheckedChanged);

            this._tmrAlert.Tick += new EventHandler(tmrAlertTick);
            //----------------            
        }
        #endregion

        #region Class Event Void Procedures

        //##################################CLASS Employee EVENTS########################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            base.ClassLoad(sender, e);            
        }//-------------------------
        //###############################END CLASS Employee EVENTS########################################  

        //#########################################LINLLABEL lnkCreateRelationship EVENTS###########################################################
        //event is raised when the control is clicked
        protected override void lnkCreateRelationshipLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            base.lnkCreateRelationshipLinkClicked(sender, e);

            if (_hasAddedRelationship)
            {
                _baseServiceManager.InitializePersonRelationshipDataGridView(this.dgvRelationship, _personInfo.PersonRelationshipList, lblEmerStatus);

                _hasAddedRelationship = false;
            }
        }//------------------------
        //#########################################END LINLLABEL lnkCreateRelationship EVENTS###########################################################     

        //#########################################LINLLABEL lnkVerified EVENTS###########################################################
        //event is raised when the control is clicked
        protected override void lnkVerifyLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            base.IsForStudentVerification = base.IsForPersonVerification = false;

            base.lnkVerifyLinkClicked(sender, e);

            if (base.HasSelectedPersonFromVerification)
            {
                _empInfo = _empManager.GetDetailsEmployeeInformation(_userInfo, base.PersonInfo.PersonSysId, Application.StartupPath, false);

                if (String.IsNullOrEmpty(_empInfo.PersonInfo.PersonSysId))
                    _empInfo.PersonInfo = base.PersonInfo;

                if (String.IsNullOrEmpty(_empInfo.EmployeeSysId))
                {
                    this.InitializeControls();
                }
            }
        }//------------------------
        //#########################################END LINLLABEL lnkVerified EVENTS###########################################################

        //#########################################LINLLABEL lnkPersonArchive EVENTS###########################################################
        //event is raised when the control is clicked
        protected override void lnkPersonArchiveLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            base.IsForStudentVerification = base.IsForPersonVerification = false;

            base.lnkPersonArchiveLinkClicked(sender, e);

            if (base.HasSelectedForPersonUpdate)
            {
                _empInfo = base.EmployeeInformation;
            }

            _rowIndexForPersonSearch = base.RowIndexForPersonSearch;        
        }//-------------------------
        //#########################################END LINLLABEL lnkPersonArchive EVENTS###########################################################

        //#########################################TEXTBOX txtEmployeeID EVENTS###########################################################
        //event is raised when the control is Validated
        private void txtEmployeeIdValidated(object sender, EventArgs e)
        {
            _empInfo.EmployeeId = RemoteClient.ProcStatic.TrimStartEndString(txtEmployeeId.Text);
        }//--------------------------
        //#########################################END TEXTBOX txtEmployeeID EVENTS###########################################################

        //#########################################USER CONTROL tmeSecoundOut EVENTS###########################################################
        //event is raised when the control is Validated
        private void tmeSecondOutValidated(object sender, EventArgs e)
        {
            _empInfo.SalaryInfo.SecondOut = tmeSecondOut.SelectedTime.ToShortTimeString();
        }//-----------------------
        //#########################################END USER CONTROL tmeSecoundOut EVENTS###########################################################

        //#########################################USER CONTROL tmeSecondIn EVENTS###########################################################
        //event is raised when the control is Validated
        private void tmeSecondInValidated(object sender, EventArgs e)
        {
            _empInfo.SalaryInfo.SecondIn = tmeSecondIn.SelectedTime.ToShortTimeString();
        }//-------------------------
        //#########################################END USER CONTROL tmeSecondIn EVENTS###########################################################

        //#########################################USER CONTROL tmeFirstOut EVENTS###########################################################
        //event is raised when the control is Validated
        private void tmeFirstOutValidated(object sender, EventArgs e)
        {
            _empInfo.SalaryInfo.FirstOut = tmeFirstOut.SelectedTime.ToShortTimeString();
        }//--------------------------
        //#########################################END USER CONTROL tmeFirstOut EVENTS###########################################################

        //#########################################USER CONTROL tmeFirstIn EVENTS###########################################################
        //event is raised when the control is Validated
        private void tmeFirstInValidated(object sender, EventArgs e)
        {
            _empInfo.SalaryInfo.FirstIn = tmeFirstIn.SelectedTime.ToShortTimeString();
        }//---------------------------
        //#########################################END USER CONTROL tmeFirstIn EVENTS###########################################################

        //######################################COMBOBOX cboType EVENTS##########################################################
        //event is raised when the selected index is changed
        private void cboTypeSelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex != -1)
            {
                this.SetEmploymentTypeControls(((ComboBox)sender).SelectedIndex + 1);
            }
        } //------------------------------
        //#####################################END COMBOBOX cboType EVENTS########################################################

        //######################################COMBOBOX cboStatus EVENTS##########################################################
        //event is raised when the selected index is changed
        protected virtual void cboStatusSelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex != -1)
            {
                this.SetStatusControls(((ComboBox)sender).SelectedIndex + 1);
            }
        } //---------------------------
        //######################################END COMBOBOX cboStatus EVENTS######################################################

        //######################################COMBOBOX cboRestDay EVENTS##########################################################
        //event is raised when the selected index is changed
        private void cboRestDaySelectedIndexChanged(object sender, EventArgs e)
        {
            _empInfo.SalaryInfo.RestDay.WeekId = (DayOfWeek)cboRestDay.SelectedIndex;
        }//------------------------------
        //######################################END COMBOBOX cboRestDay EVENTS##########################################################

        //######################################COMBOBOX cboDepartment EVENTS##########################################################
        //event is raised when the selected index is changed
        private void cboDepartmentSelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex != -1)
            {
                _empInfo.SalaryInfo.DepartmentInfo.DepartmentId = _empManager.GetDepartmentId(this.cboDepartment.SelectedIndex);
            }
        }//----------------------------
        //######################################END COMBOBOX cboDepartment EVENTS##########################################################

        //##########################################COMBOBOX cboLevel EVENTS#########################################################
        //event is raised when the selected index is changed
        private void cboLevelSelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex != -1)
            {
                this.SetRankLevelControls(((ComboBox)sender).SelectedItem.ToString());
            }
        } //---------------------------
        //#############################################END COMBOBOX cboLevel EVENTS##################################################

        //###########################################COMBOBOX cboCategory EVENTS#######################################################
        //event is raised when the selected index is changed
        private void cboCategorySelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex != -1)
            {
                this.SetRankCategoryControls(((ComboBox)sender).SelectedIndex + 1);
            }

        } //-------------------------------
        //###########################################END COMBOBOX cboCategory EVENTS###################################################

        //###########################################COMBOBOX cboDegree EVENTS###########################################################
        //event is raised when the selected index is changed
        private void cboDegreeSelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex != -1)
            {
                this.SetRankDegreeControls(((ComboBox)sender).SelectedIndex + 1);
            }          
  
        } //--------------------------------------
        //###########################################END COMBOBOX cboDegree EVENTS######################################################

        //##############################################COMBOBOX cboPoints EVENTS##########################################################
        //event is raised when the selected index is changed
        private void cboPointsSelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex != -1)
            {
                this.SetRankRateControls(((ComboBox)sender).SelectedIndex);
            }  
        } //------------------------------------
        //############################################END COMBOBOX cboPoints EVENTS#########################################################

        //##############################################TEXTBOX txtPagibigContribution EVENTS##############################################
        //event is raised when the control is Validated
        private void txtAmountKeyPress(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxAmountOnly(e);
        }//--------------------------
               
        //event is raised when the control is validating
        private void txtAmountValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxValidateAmount((TextBox)sender);
        } //----------------------------------

        //event is raised when the control is validated
        private void txtPagibigIdValidated(object sender, EventArgs e)
        {
            _empInfo.PagibigMembershipId = RemoteClient.ProcStatic.TrimStartEndString(txtPagibigId.Text);
        }//-----------------------------------
        //############################################END TEXTBOX txtPagibigContribution EVENTS#############################################

        //##############################################TEXTBOX txtPhilHealthIdValidated EVENTS##############################################
        //event is raised when the control is Validated
        private void txtPhilHealthIdValidated(object sender, EventArgs e)
        {
            _empInfo.PhilHealthMembershipId = RemoteClient.ProcStatic.TrimStartEndString(txtPhilHealthId.Text);
        }//-----------------------
        //##############################################END TEXTBOX txtPhilHealthIdValidated EVENTS##############################################

        //##############################################TEXTBOX txtSssIdValidated EVENTS##############################################
        //event is raised when the control is validated
        private void txtSssIdValidated(object sender, EventArgs e)
        {
            _empInfo.SssMembershipId = RemoteClient.ProcStatic.TrimStartEndString(txtSssId.Text);
        }//---------------------        
        //##############################################END TEXTBOX txtSssIdValidated EVENTS##############################################

        //################################################CHECKEDBOX chkFixedTime EVENTS###################################################################
        //event is raised when the timer ticks
        private void chkFixedTimeCheckedChanged(object sender, EventArgs e)
        {
            _empInfo.SalaryInfo.IsFixedLogInOut = this.chkFixedTime.Checked;

            if (!this.chkFixedTime.Checked)
            {
                //initialize the rest day combo box
                _empManager.InitializeRestDayCombo(cboRestDay);
                cboRestDay.SelectedIndex = 0;

                DateTime firstIn;
                DateTime firstOut;
                DateTime secondIn;
                DateTime secondOut;

                if (!DateTime.TryParse("08:00 AM", out firstIn))
                    firstIn = DateTime.Parse(_empManager.ServerDateTime);
                if (!DateTime.TryParse("12:00 PM", out firstOut))
                    firstOut = DateTime.Parse(_empManager.ServerDateTime);
                if (!DateTime.TryParse("01:00 PM", out secondIn))
                    secondIn = DateTime.Parse(_empManager.ServerDateTime);
                if (!DateTime.TryParse("05:00 PM", out secondOut))
                    secondOut = DateTime.Parse(_empManager.ServerDateTime);

                tmeFirstIn.SetTime(firstIn);
                tmeFirstOut.SetTime(firstOut);
                tmeSecondIn.SetTime(secondIn);
                tmeSecondOut.SetTime(secondOut);

                _empInfo.SalaryInfo.FirstIn = firstIn.ToShortTimeString();
                _empInfo.SalaryInfo.FirstOut = firstOut.ToShortTimeString();
                _empInfo.SalaryInfo.SecondIn = secondIn.ToShortTimeString();
                _empInfo.SalaryInfo.SecondOut = secondOut.ToShortTimeString();

                this.gbxFirstPart.Enabled = this.gbxSecondPart.Enabled = this.gbxRestDay.Enabled = false;
            }
            else
            {
                this.gbxFirstPart.Enabled = this.gbxSecondPart.Enabled = this.gbxRestDay.Enabled = true;
            }
        }//------------------------------
        //################################################END CHECKEDBOX chkFixedTime EVENTS###################################################################

        //################################################TIMER tmrAlert EVENTS###################################################################
        //event is raised when the timer ticks
        private void tmrAlertTick(object sender, EventArgs e)
        {
            this.lblAlert.Visible = !this.lblAlert.Visible;
            this.lblAlert.Text = "ALERT: New rank level detected! Please record the changes to take effect.";
        } //---------------------------
        //###############################################END TIMER tmrAlert EVENTS################################################################

        //################################################TEXTBOX txtOtherInformationEmployee EVENTS#######################################################
        //event is raised when the control is validated
        private void txtOtherInformationEmployeeValidated(object sender, EventArgs e)
        {
            _empInfo.OtherEmployeeInformation = RemoteClient.ProcStatic.TrimStartEndString(this.txtOtherInformationEmployee.Text);
        }//-------------------------
        //################################################END TEXTBOX txtOtherInformationEmployee EVENTS###########################################        
        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure sets the ranks control
        private void SetEmploymentTypeControls(Int32 index)
        {
            //gets the employment id
            _empInfo.SalaryInfo.EmploymentTypeInfo.EmploymentId = _empManager.GetEmploymentTypeId(index);

            _empInfo.SalaryInfo.EmploymentTypeInfo.TypeNo = 
                (CommonExchange.EmploymentTypeNo)_empManager.GetEmploymentTypeNo(_empInfo.SalaryInfo.EmploymentTypeInfo.EmploymentId);
                       

            cboStatus.SelectedIndex = -1;
            cboDepartment.SelectedIndex = -1;
            cboLevel.SelectedIndex = -1;
            cboCategory.SelectedIndex = -1;
            cboDegree.SelectedIndex = -1;
            cboPoints.SelectedIndex = -1;
            txtBasicRate.Text = "0.00";

            cboLevel.Enabled = false;
            cboCategory.Enabled = false;
            cboDegree.Enabled = false;
            cboPoints.Enabled = false;

            cboStatus.Enabled = true;
            cboDepartment.Enabled = true;

            //initialize the rank level combo box
            _empManager.InitializeRankLevelCombo(this.cboLevel, _empInfo.SalaryInfo.EmploymentTypeInfo.EmploymentId);

        } //-----------------------

        //this procedure sets the status control
        private void SetStatusControls(Int32 index)
        {
            if (index != (Int32)CommonExchange.EmploymentStatusNo.LayOff)
            {
                gbxJobInfo.Enabled = true;
                gbxDailyTime.Enabled = true;

                cboLevel.SelectedIndex = -1;
                cboCategory.SelectedIndex = -1;
                cboDegree.SelectedIndex = -1;
                cboPoints.SelectedIndex = -1;
                txtBasicRate.Text = "0.00";

                cboLevel.Enabled = true;
                cboCategory.Enabled = false;
                cboDegree.Enabled = false;
                cboPoints.Enabled = false;
            }
            else
            {
                gbxJobInfo.Enabled = false;
                gbxDailyTime.Enabled = false;
            }

            _empInfo.SalaryInfo.EmployeeStatusInfo.StatusId = _empManager.GetEmploymentStatusId(index);

        } //---------------------

        //this procedure sets the rank level control
        private void SetRankLevelControls(String levelDescription)
        {
            _empInfo.SalaryInfo.RankLevelInfo.LevelId = 
                _empManager.GetRankLevelId(levelDescription, _empInfo.SalaryInfo.EmploymentTypeInfo.EmploymentId);

            cboCategory.Enabled = true;
            cboCategory.SelectedIndex = -1;
            cboDegree.SelectedIndex = -1;
            cboPoints.SelectedIndex = -1;
            txtBasicRate.Text = "0.00";

            //initialize the rank category combo box
            _empManager.InitializeRankCategoryCombo(cboCategory, _empInfo.SalaryInfo.RankLevelInfo.LevelId);
            //_empInfo.SalaryInfo.EmployeeStatusInfo.StatusId, _empInfo.SalaryInfo.EmploymentTypeInfo.EmploymentId);

        } //-------------------------

        //this procedure sets the rank category control
        private void SetRankCategoryControls(Int32 index)
        {
            _empInfo.SalaryInfo.RankCategoryInfo.CategoryId = _empManager.GetRankCategoryId(index, _empInfo.SalaryInfo.RankLevelInfo.LevelId);

            cboDegree.Enabled = true;
            cboDegree.SelectedIndex = -1;
            cboPoints.SelectedIndex = -1;
            txtBasicRate.Text = "0.00";

            //initialize the rank degree control
            _empManager.InitializeRankDegreeCombo(cboDegree, _empInfo.SalaryInfo.RankCategoryInfo.CategoryId);

            //initialize the level points control
            _empManager.InitializeLevelPointsCombo(cboPoints, _empInfo.SalaryInfo.RankLevelInfo.LevelId);
        } //--------------------------------

        //this procedure sets the rank degree control
        private void SetRankDegreeControls(Int32 index)
        {
            _empInfo.SalaryInfo.RankDegreeInfo.DegreeId = _empManager.GetRankDegreeId(index, _empInfo.SalaryInfo.RankCategoryInfo.CategoryId);

            cboPoints.Enabled = true;
            cboPoints.SelectedIndex = -1;
            txtBasicRate.Text = "0.00";
        } //-----------------------------

        //this procedure sets the rank rate control
        private void SetRankRateControls(Int32 index)
        {
            _empInfo.SalaryInfo.RankDegreeLevelPointsInfo.DegreeId = 
                _empManager.GetRankDegreeIdLevelPoints(index, _empInfo.SalaryInfo.RankLevelInfo.LevelId);

            if (index != -1)
            {
                Int64 rateId = _empManager.GetRankRateId(_empInfo.SalaryInfo.RankDegreeLevelPointsInfo.DegreeId);

                if (rateId != _empInfo.SalaryInfo.RankSalaryRateInfo.RateId)
                {
                    this._tmrAlert.Interval = 500;
                    _tmrAlert.Start();
                }
                else
                {
                    this.lblAlert.Visible = false;
                    _tmrAlert.Stop();
                }

                _empInfo.SalaryInfo.RankSalaryRateInfo.RateId = rateId;
            }

            _empInfo.SalaryInfo.RankSalaryRateInfo.PreviousRate = _empManager.GetRankDegreePreviousRate(_empInfo.SalaryInfo.RankDegreeInfo.DegreeId);
            _empInfo.SalaryInfo.RankSalaryRateInfo.IncreaseRate = _empManager.GetRankDegreeIncreaseRate(_empInfo.SalaryInfo.RankDegreeLevelPointsInfo.DegreeId);

            txtBasicRate.Text = (_empInfo.SalaryInfo.RankSalaryRateInfo.PreviousRate + _empInfo.SalaryInfo.RankSalaryRateInfo.IncreaseRate).ToString("N");
        } //--------------------------------

        //this procedure initializes the controls
        protected void InitializeControls()
        {
            //initialize the employment type combo box
            _empManager.InitializeEmploymentTypeCombo(this.cboType);
            //intialize the department type combo box
            _empManager.InitializeDepartmentCombo(this.cboDepartment);
            //initialize the employment status combo box
            _empManager.InitializeEmploymentStatusCombo(this.cboStatus);            
            //initialize the rest day combo box
            _empManager.InitializeRestDayCombo(this.cboRestDay);
            cboRestDay.SelectedIndex = 0;

            DateTime firstIn;
            DateTime firstOut;
            DateTime secondIn;
            DateTime secondOut;

            if (!DateTime.TryParse("08:00 AM", out firstIn))
                firstIn = DateTime.Parse(_empManager.ServerDateTime);
            if (!DateTime.TryParse("12:00 PM", out firstOut))
                firstOut = DateTime.Parse(_empManager.ServerDateTime);
            if (!DateTime.TryParse("01:00 PM", out secondIn))
                secondIn = DateTime.Parse(_empManager.ServerDateTime);
            if (!DateTime.TryParse("05:00 PM", out secondOut))
                secondOut = DateTime.Parse(_empManager.ServerDateTime);

            tmeFirstIn.SetTime(firstIn);
            tmeFirstOut.SetTime(firstOut);
            tmeSecondIn.SetTime(secondIn);
            tmeSecondOut.SetTime(secondOut);

            _empInfo.SalaryInfo.FirstIn = firstIn.ToShortTimeString();
            _empInfo.SalaryInfo.FirstOut = firstOut.ToShortTimeString();
            _empInfo.SalaryInfo.SecondIn = secondIn.ToShortTimeString();
            _empInfo.SalaryInfo.SecondOut = secondOut.ToShortTimeString();

            gbxJobInfo.Enabled = false;
            this.gbxFirstPart.Enabled = this.gbxSecondPart.Enabled = this.gbxRestDay.Enabled =  true;

            this.chkFixedTime.Checked = false;

            cboStatus.Enabled = false;
            cboDepartment.Enabled = false;


            txtPresentAddress.Clear();
            txtPresentPhone.Clear();
            txtHomeAddress.Clear();
            txtHomeAddress.Clear();
            txtHomeAddress.Clear();
            txtHomePhone.Clear();

            txtCitizenship.Clear();
            txtNationality.Clear();
            txtReligion.Clear();

            txtECode.Clear();

            txtEmployeeId.Clear();
            txtPagibigId.Clear();
            txtSssId.Clear();
            txtPhilHealthId.Clear();
            txtOtherInformationEmployee.Clear(); 

            this.txtLastName.Focus();

        } //-------------------------------      

        #endregion

        #region Programmer-Defined Function Procedures

        //this function determines if the controls are validated
        public Boolean ValidateControlsEmployee()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.cboType, "");
            _errProvider.SetError(this.cboStatus, "");
            _errProvider.SetError(this.cboDepartment, "");
            _errProvider.SetError(this.lblEmpIdLabel, "");
            //_errProvider.SetError(this.lblLevel, "");
            //_errProvider.SetError(this.lblCategory, "");
            //_errProvider.SetError(this.lblDegree, "");
            //_errProvider.SetError(this.lblLevelPoints, "");
            
            if (this.cboType.SelectedIndex == -1)
            {
                _errProvider.SetError(this.cboType, "Please select an employment type.");
                _errProvider.SetIconAlignment(this.cboType, ErrorIconAlignment.MiddleLeft);
                this.TabCntPerson.SelectedIndex = 2;
                isValid = false;
            }

            if (this.cboStatus.SelectedIndex == -1)
            {
                _errProvider.SetError(this.cboStatus, "Please select an employment status.");
                _errProvider.SetIconAlignment(this.cboStatus, ErrorIconAlignment.MiddleLeft);
                this.TabCntPerson.SelectedIndex = 2;
                isValid = false;
            }

            if (this.cboDepartment.SelectedIndex == -1)
            {
                _errProvider.SetError(this.cboDepartment, "Please select an employee department.");
                _errProvider.SetIconAlignment(this.cboDepartment, ErrorIconAlignment.MiddleLeft);
                this.TabCntPerson.SelectedIndex = 2;
                isValid = false;
            }

            if (String.IsNullOrEmpty(RemoteClient.ProcStatic.TrimStartEndString(_empInfo.EmployeeId)))
            {
                _errProvider.SetError(this.lblEmpIdLabel, "An employee ID is required.");
                _errProvider.SetIconAlignment(this.lblEmpIdLabel, ErrorIconAlignment.MiddleLeft);
                this.TabCntPerson.SelectedIndex = 2;
                isValid = false;
            }
            else if (_empManager.IsExistsEmployeeIdEmployeeInformation(_userInfo, RemoteClient.ProcStatic.TrimStartEndString(_empInfo.EmployeeId),
                _empInfo.EmployeeSysId))
            {
                _errProvider.SetError(this.lblEmpIdLabel, "The employee ID already exist.");
                _errProvider.SetIconAlignment(this.lblEmpIdLabel, ErrorIconAlignment.MiddleLeft);
                this.TabCntPerson.SelectedIndex = 2;
                isValid = false;
            }
            
            //if (cboLevel.SelectedIndex == -1)
            //{
            //    _errProvider.SetError(this.lblLevel, "Please select an employee rank level.");
            //    _errProvider.SetIconAlignment(this.lblLevel, ErrorIconAlignment.MiddleLeft);
            //    this.TabCntPerson.SelectedIndex = 2;
            //    isValid = false;
            //}

            //if (cboCategory.SelectedIndex == -1)
            //{
            //    _errProvider.SetError(this.lblCategory, "Please select an employee rank category.");
            //    _errProvider.SetIconAlignment(this.lblCategory, ErrorIconAlignment.MiddleLeft);
            //    this.TabCntPerson.SelectedIndex = 2;
            //    isValid = false;
            //}

            //if (cboDegree.SelectedIndex == -1)
            //{
            //    _errProvider.SetError(this.lblDegree, "Please select an employee rank degree.");
            //    _errProvider.SetIconAlignment(this.lblDegree, ErrorIconAlignment.MiddleLeft);
            //    this.TabCntPerson.SelectedIndex = 2;
            //    isValid = false;
            //}

            //if (cboPoints.SelectedIndex == -1)
            //{
            //    _errProvider.SetError(this.lblLevelPoints, "Please select an employee level points.");
            //    _errProvider.SetIconAlignment(this.lblLevelPoints, ErrorIconAlignment.MiddleLeft);
            //    this.TabCntPerson.SelectedIndex = 2;
            //    isValid = false;
            //}

            return isValid;

        } //--------------------------
        #endregion
    }
}
