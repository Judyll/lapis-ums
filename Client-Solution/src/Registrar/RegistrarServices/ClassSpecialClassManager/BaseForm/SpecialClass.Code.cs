using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RegistrarServices
{
    partial class SpecialClass
    {
        #region Class General Variable Declarations
        protected CommonExchange.SysAccess _userInfo;
        protected CommonExchange.SpecialClassInformation _specialInfo;
        protected CommonExchange.SubjectInformation _subjectInfo;
        protected CommonExchange.Employee _employeeInfo;
        protected SpecialClassLogic _specialManager;
        protected Boolean _canWithdraw;
        protected Boolean _hasErrors;

        private Int64 _loadId;
        private ErrorProvider _errProvider;

        protected String _dateStart;
        protected String _dateEnd;
        #endregion

        #region Class Constructor
        public SpecialClass()
        {
            this.InitializeComponent();
        }
        public SpecialClass(CommonExchange.SysAccess userInfo, SpecialClassLogic specialManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _specialManager = specialManager;

            _errProvider = new ErrorProvider();

            this.Load += new EventHandler(ClassLoad);
            this.cboYearSemester.SelectedIndexChanged += new EventHandler(cboYearSemesterSelectedIndexChanged);
            this.btnSearchSubject.Click += new EventHandler(btnSearchSubjectClick);
            this.btnSearchEmployee.Click += new EventHandler(btnSearchEmployeeClick);
            this.txtAmount.KeyPress += new KeyPressEventHandler(txtAmountKeyPress);
            this.txtAmount.Validating += new System.ComponentModel.CancelEventHandler(txtAmountValidating);
            this.txtAmount.Validated += new EventHandler(txtAmountValidated);
            this.lnkEnroll.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkEnrollLinkClicked);
            this.lnkWithdraw.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkWithdrawLinkClicked);
            this.dgvEnrolled.MouseDown += new MouseEventHandler(dgvEnrolledMouseDown);
            this.dgvEnrolled.KeyPress += new KeyPressEventHandler(dgvEnrolledKeyPress);
            this.dgvEnrolled.KeyUp += new KeyEventHandler(dgvEnrolledKeyUp);
            this.dgvEnrolled.DataSourceChanged += new EventHandler(dgvEnrolledDataSourceChanged);
            this.dgvEnrolled.SelectionChanged += new EventHandler(dgvEnrolledSelectionChanged);
            this.dgvWithdrawn.DataSourceChanged += new EventHandler(dgvWithdrawnDataSourceChanged);
            this.dgvWithdrawn.MouseDown += new MouseEventHandler(dgvEnrolledMouseDown);
            this.lnkRealoadSpecialClass.Click += new EventHandler(lnkRealoadSpecialClassClick);
        }                   
        
        #endregion

        #region Class Event Void Procedures

        //############################################CLASS SpecialClass EVENTS#######################################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {            
            if (_specialManager.MustOpenSchoolYearSemester())
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Please open another school year / semester before creating a new special class.", 
                    "Error Creating A Special Class");

                _hasErrors = true;

                this.Close();
            }

            _specialInfo = new CommonExchange.SpecialClassInformation();

            this.cboYearSemester.Enabled = false;
            this.txtAmount.Text = "0.00";
            this.lblCountEnrolled.Text = "0 Student";
            this.lblCountWithdrawn.Text = "0 Student";

            _canWithdraw = RemoteServerLib.ProcStatic.IsSystemAccessCollegeRegistrar(_userInfo) ? false : true;            

        } //-------------------------------
        //##########################################END CLASS SpecialClass EVENTS#####################################################

        //#############################################COMBOBOX cboYearSemester EVENTS#################################################
        //event is raised when the selected index is changed
        protected void cboYearSemesterSelectedIndexChanged(object sender, EventArgs e)
        {
            if (_specialInfo.IsSemestral)
            {
                _specialInfo.SemesterSysId = _specialManager.GetYearSemesterId(_specialInfo.IsSemestral, ((ComboBox)sender).SelectedIndex);
            }
            else
            {
                _specialInfo.YearId = _specialManager.GetYearSemesterId(_specialInfo.IsSemestral, ((ComboBox)sender).SelectedIndex);
            }
        } //-----------------------------------------
        //############################################END COMBOBOX cboYearSemester EVENTS##############################################

        //##############################################BUTTON btnSearchSubject EVENTS####################################################
        //event is raised when the button is clicked
        private void btnSearchSubjectClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (SubjectSearchOnTextboxList frmSearch = new SubjectSearchOnTextboxList(_userInfo, _specialManager))
                {

                    frmSearch.AdoptGridSize = true;
                    frmSearch.ShowDialog(this);

                    if (frmSearch.HasSelected)
                    {
                        _subjectInfo = _specialManager.GetDetailsSubjectInformation(frmSearch.PrimaryId);

                        _specialInfo.SubjectSysId = _subjectInfo.SubjectSysId;
                        _specialInfo.IsSemestral = _subjectInfo.CourseGroupInfo.IsSemestral;
                        _specialInfo.SubjectDepartmentName = _subjectInfo.DepartmentInfo.DepartmentName;
                        
                        lblSysIdSubject.Text = _subjectInfo.SubjectSysId;
                        lblSubjectCodeDescription.Text = _subjectInfo.SubjectCode + " - " + _subjectInfo.DescriptiveTitle;
                        lblSubjectDepartment.Text = _subjectInfo.DepartmentInfo.DepartmentName;
                        lblUnitsLabHours.Text = _specialManager.GetSubjectUnitsHours(_subjectInfo.LectureUnits, _subjectInfo.LabUnits, _subjectInfo.NoHours);

                        _specialManager.InitializeSchoolYearSemesterCombo(cboYearSemester, _subjectInfo.CourseGroupInfo.IsSemestral);

                        if (_subjectInfo.CourseGroupInfo.IsSemestral)
                        {
                            _dateStart = _specialManager.GetSemesterDateStart(_specialManager.GetYearSemesterId(_subjectInfo.CourseGroupInfo.IsSemestral,
                                this.cboYearSemester.SelectedIndex)).ToShortDateString() + " 12:00:00 AM";
                            _dateEnd = _specialManager.GetSemesterDateEnd(_specialManager.GetYearSemesterId(_subjectInfo.CourseGroupInfo.IsSemestral,
                                this.cboYearSemester.SelectedIndex)).ToShortDateString() + " 11:59:59 PM";
                        }
                        else
                        {
                            _dateStart = _specialManager.GetSchoolYearDateStart(_specialManager.GetYearSemesterId(_subjectInfo.CourseGroupInfo.IsSemestral,
                                this.cboYearSemester.SelectedIndex)).ToShortDateString() + " 12:00:00 AM";
                            _dateEnd = _specialManager.GetSchoolYearDateEnd(_specialManager.GetYearSemesterId(_subjectInfo.CourseGroupInfo.IsSemestral,
                                this.cboYearSemester.SelectedIndex)).ToShortDateString() + " 11:59:59 PM";
                        }

                        this.cboYearSemester.Enabled = this.btnSearchEmployee.Enabled = this.lnkEnroll.Enabled = true;

                        this.lnkWithdraw.Enabled = _canWithdraw;
                    }

                    _specialManager.SetSelectedDataTableToNull();
                }

            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Subject Search Module");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
            
        } //-------------------------------------------
        //############################################END BUTTON btnSearchSubject EVENTS#################################################

        //###############################################BUTTON btnSearchEmployee EVENTS#####################################################
        //event is raised when the button is clicked
        private void btnSearchEmployeeClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (EmployeeSearchOnTextboxList frmSearch = new EmployeeSearchOnTextboxList(_userInfo, _specialManager))
                {
                    frmSearch.AdoptGridSize = true;
                    frmSearch.ShowDialog(this);

                    if (frmSearch.HasSelected)
                    {
                        _employeeInfo = _specialManager.GetDetailsByEmployeeIdEmployeeInformation(frmSearch.PrimaryId);

                        _specialInfo.EmployeeSysId = _employeeInfo.EmployeeSysId;

                        lblEmployeeId.Text = _employeeInfo.EmployeeId;
                        lblEmployeeName.Text = _employeeInfo.PersonInfo.LastName.ToUpper() + ", " + _employeeInfo.PersonInfo.FirstName + " " +
                            _employeeInfo.PersonInfo.MiddleName;
                        lblEmployeeStatus.Text = _employeeInfo.SalaryInfo.EmployeeStatusInfo.StatusDescription + ", " + 
                            _employeeInfo.SalaryInfo.EmploymentTypeInfo.TypeDescription;
                        lblEmployeeDepartmentName.Text = _employeeInfo.SalaryInfo.DepartmentInfo.DepartmentName;

                    }

                    _specialManager.SetSelectedDataTableToNull();
                }

            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Subject Search Module");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        } //---------------------------------------
        //##############################################END BUTTON btnSearchEmployee EVENTS##################################################

        //#################################################TEXTBOX txtAmount EVENTS###########################################################
        //event is raised when the key is pressed
        private void txtAmountKeyPress(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxAmountOnly(e);
        } //-----------------------------------

        //event is raised when the control is validating
        private void txtAmountValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxValidateAmount((TextBox)sender);
        } //-----------------------------------

        //event is raised when the control is validated
        private void txtAmountValidated(object sender, EventArgs e)
        {
            Decimal amount = 0;

            if (Decimal.TryParse(txtAmount.Text, out amount))
            {
                _specialInfo.Amount = amount;
            }

        } //---------------------------------
        //################################################END TEXTBOX txtAmount EVENTS########################################################

        //################################################LINKBUTTON lnkEnroll EVENTS#########################################################
        //event is raised when the link is clicked
        private void lnkEnrollLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (StudentSearchOnTextboxList frmSearch = new StudentSearchOnTextboxList(_userInfo, _specialManager, _dateStart, _dateEnd))
                {
                    frmSearch.AdoptGridSize = false;
                    frmSearch.ShowDialog(this);

                    if (frmSearch.HasSelected)
                    {
                        CommonExchange.StudentEnrolmentLevel studentEnrolmentLevelInfo = _specialManager.GetDetailsByStudentIdStudentInformation(frmSearch.PrimaryId);

                        if (_specialManager.IsAlreadyEnrolled(studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.StudentInfo.StudentId))
                        {
                            MessageBox.Show("The student is already enrolled in the special class.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            this.dgvEnrolled.DataSource = _specialManager.EnrollSpecialClassLoad(studentEnrolmentLevelInfo);
                        }                        
                    }

                    _specialManager.SetSelectedDataTableToNull();
                }
               
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Student Search Module");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        } //---------------------------------
        //#############################################END LINKBUTTON lnkEnroll EVENTS########################################################

        //###############################################LINKBUTTON lnkReaload EVENTS########################################################
        //event is raised when the link is clicked
        private void lnkRealoadSpecialClassClick(object sender, EventArgs e)
        {
            String msgConfirm = "Are you sure you want to reaload the student from the special class?";

            if (MessageBox.Show(msgConfirm, "Confirm Reaload", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.dgvEnrolled.DataSource = _specialManager.RealoadSpecialClassLoad(_loadId);
                this.dgvWithdrawn.DataSource = _specialManager.GetEnrolledWithdrawnSpecialClassLoadTable(false);
            }
        }//----------------------------
        //###############################################END LINKBUTTON lnkReaload EVENTS########################################################

        //###############################################LINKBUTTON lnkWithdraw EVENTS########################################################
        //event is raised when the link is clicked
        private void lnkWithdrawLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            String msgConfirm = "Are you sure you want to withdraw the student from the special class?";

            if (MessageBox.Show(msgConfirm, "Confirm Withdraw", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.dgvEnrolled.DataSource = _specialManager.WithdrawSpecialClassLoad(_loadId);
                this.dgvWithdrawn.DataSource = _specialManager.GetEnrolledWithdrawnSpecialClassLoadTable(false);
            }
        } //----------------------------------
        //#############################################END LINKBUTTON lnkWithdraw EVENTS######################################################

        //#########################################DATAGRIDVIEW dgvEnrolled EVENTS###########################################################
        //event is raised when the mouse is down
        private void dgvEnrolledMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                DataGridView dgvBase = (DataGridView)sender;

                DataGridView.HitTestInfo hitTest = dgvBase.HitTest(e.X, e.Y);

                Int32 rowIndex = -1;

                switch (hitTest.Type)
                {
                    case DataGridViewHitTestType.Cell:
                        rowIndex = hitTest.RowIndex;
                        break;
                    case DataGridViewHitTestType.RowHeader:
                        rowIndex = hitTest.RowIndex;
                        break;
                    default:
                        rowIndex = -1;
                        _loadId = 0;
                        break;
                }

                if (rowIndex != -1)
                {
                    Int64 id;

                    if (Int64.TryParse(dgvBase[0, rowIndex].Value.ToString(), out id))
                    {
                        _loadId = id;

                        if (this.tabSpecialInformation.SelectedIndex == 2 &&
                            (RemoteServerLib.ProcStatic.IsSystemAccessCollegeRegistrar(_userInfo) ||
                            RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo)))
                        {
                            this.dgvWithdrawn.ContextMenuStrip = cmsRealod;
                        }
                    }

                    this.lnkWithdraw.Enabled = _canWithdraw;
                }
                else
                {
                    this.dgvWithdrawn.ContextMenuStrip = null;
                }
            }
        } //----------------------------------------

        //event is raised when the key is pressed
        private void dgvEnrolledKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }  //-----------------------------

        //event is raised when the key is up
        private void dgvEnrolledKeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        } //------------------------------

        //event is raised when the data source is changed
        private void dgvEnrolledDataSourceChanged(object sender, EventArgs e)
        {
            DataGridView dgvBase = (DataGridView)sender;
            Int32 result = dgvBase.Rows.Count;

            if (result == 1)
            {
                Int64 id;

                if (Int64.TryParse(dgvBase[0, 0].Value.ToString(), out id))
                {
                    _loadId = id;
                }
            }
            else
            {
                _loadId = 0;
            }

            if (dgvBase.Rows.Count >= 1)
            {
                dgvBase.Rows[0].Selected = false;
            }

            if (result == 0 || result == 1)
            {
                this.lblCountEnrolled.Text = result.ToString() + " Student";                
            }
            else
            {
                this.lblCountEnrolled.Text = result.ToString() + " Students";
            }

            this.tbpEnrolled.Text = "Enrolled (" + result.ToString() + ")";

            this.lnkWithdraw.Enabled = _canWithdraw;
        } //---------------------------

        //event is raised when the selection is changed
        private void dgvEnrolledSelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgvBase = (DataGridView)sender;

            if (dgvBase.Rows.GetRowCount(DataGridViewElementStates.Selected) > 0)
            {
                DataGridViewRow row = dgvBase.SelectedRows[0];

                Int64 id;

                if (Int64.TryParse(row.Cells[0].Value.ToString(), out id))
                {
                    _loadId = id;
                }
            }

            this.lnkWithdraw.Enabled = _canWithdraw;
            
        } //-----------------------------------
        //######################################END DATAGRIDVIEW dgvEnrolled EVENTS##########################################################

        //###########################################DATAGRIDVIEW dgvWithdrawn EVENTS########################################################
        //event is raised when the data source is changed
        private void dgvWithdrawnDataSourceChanged(object sender, EventArgs e)
        {
            DataGridView dgvBase = (DataGridView)sender;
            Int32 result = dgvBase.Rows.Count;

            if (result == 0 || result == 1)
            {
                this.lblCountWithdrawn.Text = result.ToString() + " Student";
            }
            else
            {
                this.lblCountWithdrawn.Text = result.ToString() + " Students";
            }

            this.tbpWithdrawn.Text = "Withdrawn (" + result.ToString() + ")";
            
        } //---------------------------

        //########################################END DATAGRIDVIEW dgvWithdrawn EVENTS#######################################################
      
        #endregion

        #region Programmer-Defined Function Procedures

        //this function determines if the controls are validated
        protected Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(cboYearSemester, "");
            _errProvider.SetError(btnSearchEmployee, "");
            _errProvider.SetError(btnSearchSubject, "");
            _errProvider.SetError(txtAmount, "");

            if (cboYearSemester.SelectedIndex == -1)
            {
                _errProvider.SetIconAlignment(cboYearSemester, ErrorIconAlignment.MiddleLeft);
                _errProvider.SetError(cboYearSemester, "Please select a school year / semester the special class is enrolled.");
                isValid = false;

                this.tabSpecialInformation.SelectedIndex = 0;
            }

            if (String.IsNullOrEmpty(_specialInfo.EmployeeSysId))
            {
                _errProvider.SetIconAlignment(btnSearchEmployee, ErrorIconAlignment.MiddleLeft);
                _errProvider.SetError(btnSearchEmployee, "Please select an instructor for the special class.");
                isValid = false;

                this.tabSpecialInformation.SelectedIndex = 0;
            }

            if (String.IsNullOrEmpty(_specialInfo.SubjectSysId))
            {
                _errProvider.SetIconAlignment(btnSearchSubject, ErrorIconAlignment.MiddleLeft);
                _errProvider.SetError(btnSearchSubject, "Please select a subject for the special class.");
                isValid = false;

                this.tabSpecialInformation.SelectedIndex = 0;
            }

            Decimal amount;

            if (Decimal.TryParse(txtAmount.Text, out amount))
            {
                if (amount <= 0)
                {
                    _errProvider.SetIconAlignment(txtAmount, ErrorIconAlignment.MiddleLeft);
                    _errProvider.SetError(txtAmount, "Please enter a valid amount for the special class.");
                    isValid = false;

                    this.tabSpecialInformation.SelectedIndex = 0;
                }
            }

            return isValid;
        } //------------------------

        #endregion

    }
}
