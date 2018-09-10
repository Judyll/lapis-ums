using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace EmployeeServices
{
    partial class EmployeeUpdate
    {
        #region Class General Variable Declarations
        private CommonExchange.Employee _empTemp;

        private Boolean _hasEnter = false;
        #endregion

        #region Class Properties Declarations
        private Boolean _hasUpdated = false;
        public Boolean HasUpdated
        {
            get { return _hasUpdated; }
        }       
        #endregion

        #region Class Constructors
         public EmployeeUpdate(CommonExchange.SysAccess userInfo, CommonExchange.Employee empInfo, EmployeeLogic empManager) 
            : base(userInfo, empManager)
        {
            this.InitializeComponent();

            _empInfo = empInfo;

            _errProvider = new ErrorProvider();
            
            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);
            this.btnClose.Click += new EventHandler(btnDoneClick);
        }
        #endregion

        #region Class Event Void Procedures
        //#######################################CLASS EmployeeUpdate EVENTS#####################################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.lnkPersonArchive.Visible = this.lnkVerify.Enabled = false;

            _baseServiceManager = new BaseServices.BaseServicesLogic(_userInfo);

            _personInfo = _empInfo.PersonInfo;

            this.AssingControlsValue();
            this.SetPersonInformationControls(true);

            if (!_hasEnter)
            {
                this.InitializeControlsForUpdate();

                _baseServiceManager.InitializePersonRelationshipDataGridView(this.dgvRelationship, _personInfo.PersonRelationshipList, lblEmerStatus);

                RemoteClient.ProcStatic.SetDataGridViewColumns(this.dgvRelationship, false);

                _hasEnter = true;
            }

            _empTemp = (CommonExchange.Employee)_empInfo.Clone();
        }//--------------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!IsForEmployeeUpdate && (!_hasUpdated && !_empInfo.Equals(_empTemp)))
            {  
                String strMsg = "There has been changes made in the current employee information. \nExiting will not save this changes." +
                            "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//------------------------------
        //#######################################END CLASS EmployeeUpdate EVENTS#####################################################

        //Disable Verify Existence if the function is for update employee information
        ////#########################################LINLLABEL lnkVerified EVENTS###########################################################
        ////event is raised when the control is clicked
        //protected override void lnkVerifyLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    base.IsForStudentVerification = base.IsForPersonVerification = false;

        //    base.lnkVerifyLinkClicked(sender, e);

        //    this.btnUpdate.Enabled = base.IsVerifiedUpdatedName ? true : false;

        //    if (base.HasSelectedPersonFromVerification)
        //    {
        //        if (!String.IsNullOrEmpty(_empInfo.EmployeeSysId))
        //        {
        //            base.AssingControlsValue();
        //            this.InitializeControlsForUpdate();
        //        }
        //    }         
        //}//------------------------
        ////#########################################END LINLLABEL lnkVerified EVENTS###########################################################

        //Disable Verify Existence if the function is for update student
        ////#########################################TEXTBOX txtName EVENTS###########################################################
        ////event is raised when the control is clicked
        //protected override void TextBoxKeyPressLettersOnly(object sender, KeyPressEventArgs e)
        //{
        //    base.TextBoxKeyPressLettersOnly(sender, e);

        //    this.btnUpdate.Enabled = false;
        //}//------------------------
        ////#########################################END TEXTBOX txtName EVENTS###########################################################

        //#########################################BUTTON btnDone EVENTS###########################################################
        //event is raised when the button is clicked
        private void btnDoneClick(object sender, EventArgs e)
        {
            this.Close();
        }//-----------------------------
        //########################################END BUTTON btnDone EVENTS#########################################################

        //###########################################BUTTON btnUpdate EVENTS#######################################################
        //event is raised when the button is clicked
        private void btnUpdateClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to update the employee information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The employee has been successfully updated.";

                        _empInfo.ObjectState = _empInfo.Equals(_empTemp) ? DataRowState.Unchanged : DataRowState.Modified;

                        _personInfo.ObjectState = _personInfo.Equals(_empTemp.PersonInfo) ? DataRowState.Unchanged : DataRowState.Modified;
                        _empInfo.PersonInfo = _personInfo;

                        _empManager.UpdateEmployeeInformation(_userInfo, _empInfo);

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdated = true;

                        this.Close();
                    }
                    else if (msgResult == DialogResult.Cancel)
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Updating");
                }
            }
        }//------------------------------
        //##########################################END BUTTON btnUpdate EVENTS######################################################
        #endregion

        #region Programmer-Defined Void Procedures
        //this procedure initializes the controls
        private void InitializeControlsForUpdate()
        {
            _empManager.InitializeEmploymentTypeCombo(cboType, _empInfo.SalaryInfo.EmploymentTypeInfo.EmploymentId);

            _empManager.InitializeEmploymentStatusCombo(cboStatus, _empInfo.SalaryInfo.EmployeeStatusInfo.StatusId);

            _empManager.InitializeDepartmentCombo(cboDepartment, _empInfo.SalaryInfo.DepartmentInfo.DepartmentId);

            txtPresentAddress.Text = _empInfo.PersonInfo.PresentAddress;
            txtPresentPhone.Text = _empInfo.PersonInfo.PresentPhoneNos;
            txtHomeAddress.Text = _empInfo.PersonInfo.HomeAddress;
            txtHomePhone.Text = _empInfo.PersonInfo.HomePhoneNos;

            txtCitizenship.Text = _empInfo.PersonInfo.Citizenship;
            txtNationality.Text = _empInfo.PersonInfo.Nationality;
            txtReligion.Text = _empInfo.PersonInfo.Religion;

            txtECode.Text = _empInfo.PersonInfo.ECode;

            txtEmployeeId.Text = _empInfo.EmployeeId;
            txtPagibigId.Text = _empInfo.PagibigMembershipId;
            txtSssId.Text = _empInfo.SssMembershipId;
            txtPhilHealthId.Text = _empInfo.PhilHealthMembershipId;
            txtOtherInformationEmployee.Text = _empInfo.OtherEmployeeInformation;
            
            chkFixedTime.Checked = _empInfo.SalaryInfo.IsFixedLogInOut;

            if (!String.IsNullOrEmpty(_empInfo.SalaryInfo.RankLevelInfo.LevelId))
            {
                _empManager.InitializeRankLevelCombo(cboLevel, _empInfo.SalaryInfo.EmploymentTypeInfo.EmploymentId, _empInfo.SalaryInfo.RankLevelInfo.LevelId);
            }

            if (!String.IsNullOrEmpty(_empInfo.SalaryInfo.RankLevelInfo.LevelId) && !String.IsNullOrEmpty(_empInfo.SalaryInfo.RankCategoryInfo.CategoryId))
            {
                _empManager.InitializeRankCategoryCombo(cboCategory, _empInfo.SalaryInfo.RankLevelInfo.LevelId, _empInfo.SalaryInfo.EmployeeStatusInfo.StatusId,
                    _empInfo.SalaryInfo.EmploymentTypeInfo.EmploymentId, _empInfo.SalaryInfo.RankCategoryInfo.CategoryId);
            }

            if (!String.IsNullOrEmpty(_empInfo.SalaryInfo.RankCategoryInfo.CategoryId) && !String.IsNullOrEmpty(_empInfo.SalaryInfo.RankDegreeInfo.DegreeId))
            {
                _empManager.InitializeRankDegreeCombo(cboDegree, _empInfo.SalaryInfo.RankCategoryInfo.CategoryId, _empInfo.SalaryInfo.RankDegreeInfo.DegreeId);
            }

            if (!String.IsNullOrEmpty(_empInfo.SalaryInfo.RankLevelInfo.LevelId) && !String.IsNullOrEmpty(_empInfo.SalaryInfo.RankDegreeLevelPointsInfo.DegreeId))
            {
                _empManager.InitializeLevelPointsCombo(cboPoints, _empInfo.SalaryInfo.RankLevelInfo.LevelId, _empInfo.SalaryInfo.RankDegreeLevelPointsInfo.DegreeId);
            }

            DateTime firstIn;
            DateTime firstOut;
            DateTime secondIn;
            DateTime secondOut;

            if (!DateTime.TryParse(_empInfo.SalaryInfo.FirstIn, out firstIn))
                firstIn = DateTime.Parse(_empManager.ServerDateTime);
            if (!DateTime.TryParse(_empInfo.SalaryInfo.FirstOut, out firstOut))
                firstOut = DateTime.Parse(_empManager.ServerDateTime);
            if (!DateTime.TryParse(_empInfo.SalaryInfo.SecondIn, out secondIn))
                secondIn = DateTime.Parse(_empManager.ServerDateTime);
            if (!DateTime.TryParse(_empInfo.SalaryInfo.SecondOut, out secondOut))
                secondOut = DateTime.Parse(_empManager.ServerDateTime);

            tmeFirstIn.SetTime(firstIn);
            tmeFirstOut.SetTime(firstOut);
            tmeSecondIn.SetTime(secondIn);
            tmeSecondOut.SetTime(secondOut);

            _empManager.InitializeRestDayCombo(cboRestDay, (Byte)(DayOfWeek)_empInfo.SalaryInfo.RestDay.WeekId);

            _baseServiceManager.InitializePersonRelationshipDataGridView(this.dgvRelationship, _personInfo.PersonRelationshipList, lblEmerStatus);
        }//---------------------------
        #endregion
    }
}
