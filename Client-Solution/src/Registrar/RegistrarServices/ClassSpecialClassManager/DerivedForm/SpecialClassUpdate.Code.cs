using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RegistrarServices
{
    partial class SpecialClassUpdate
    {
        #region Class General Variable Declarations
        private CommonExchange.SpecialClassInformation _specialInfoTemp;
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

        #region Class Constructor
        public SpecialClassUpdate(CommonExchange.SysAccess userInfo, CommonExchange.SpecialClassInformation specialInfo,
            SpecialClassLogic specialManager)
            : base(userInfo, specialManager)
        {
            this.InitializeComponent();

            _specialInfo = specialInfo;
            _specialInfoTemp = (CommonExchange.SpecialClassInformation)specialInfo.Clone();

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);
            this.btnDelete.Click += new EventHandler(btnDeleteClick);
        }
        
        #endregion

        #region Class Event Void Procedures
        //#####################################CLASS LoanInformationCreate EVENTS########################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            _specialManager.InitializeLoadDeLoadPrematureDeloadedTable();

            lblSysID.Text = _specialInfo.SpecialClassSysId;

            this.cboYearSemester.SelectedIndexChanged -= new EventHandler(cboYearSemesterSelectedIndexChanged);

            _specialManager.InitializeSchoolYearSemesterCombo(cboYearSemester, _specialInfo.IsSemestral, _specialInfo.YearId, _specialInfo.SemesterSysId);

            this.cboYearSemester.SelectedIndexChanged += new EventHandler(cboYearSemesterSelectedIndexChanged);

            lblSysIdSubject.Text = _specialInfo.SubjectSysId;
            lblSubjectCodeDescription.Text = _specialInfo.SubjectCode + " - " + _specialInfo.DescriptiveTitle;
            lblSubjectDepartment.Text = _specialInfo.SubjectDepartmentName;
            lblUnitsLabHours.Text = _specialManager.GetSubjectUnitsHours(_specialInfo.LectureUnits, _specialInfo.LabUnits, _specialInfo.NoHours);

            lblEmployeeId.Text = _specialInfo.EmployeeId;
            lblEmployeeName.Text = _specialInfo.LastName.ToUpper() + ", " + _specialInfo.FirstName + " " + _specialInfo.MiddleName;
            lblEmployeeStatus.Text = _specialInfo.StatusDescription + ", " + _specialInfo.TypeDescription;
            lblEmployeeDepartmentName.Text = _specialInfo.EmployeeDepartmentName;

            txtAmount.Text = _specialInfo.Amount.ToString("N");

            _specialManager.GetBySpecialClassIdSpecialClassLoadTable(_userInfo, _specialInfo.SpecialClassSysId);

            this.dgvEnrolled.DataSource = _specialManager.GetEnrolledWithdrawnSpecialClassLoadTable(true);
            this.dgvWithdrawn.DataSource = _specialManager.GetEnrolledWithdrawnSpecialClassLoadTable(false);

            RemoteClient.ProcStatic.SetDataGridViewColumns(this.dgvEnrolled, false);
            RemoteClient.ProcStatic.SetDataGridViewColumns(this.dgvWithdrawn, false);

            _canWithdraw = RemoteServerLib.ProcStatic.IsSystemAccessPayrollMaster(_userInfo) ||
                RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) ? true : false;

            this.btnSearchEmployee.Enabled = this.lnkEnroll.Enabled = true;

            //DD Code
            //this.lnkWithdraw.Enabled = _canWithdraw;

            if (_specialInfo.IsSemestral)
            {
                _dateStart = _specialManager.GetSemesterDateStart(_specialInfo.SemesterSysId).ToShortDateString() + " 12:00:00 AM";
                _dateEnd = _specialManager.GetSemesterDateEnd(_specialInfo.SemesterSysId).ToShortDateString() + " 11:59:59 PM";
            }
            else
            {
                _dateStart = _specialManager.GetSchoolYearDateStart(_specialInfo.YearId).ToShortDateString() + " 12:00:00 AM";
                _dateEnd = _specialManager.GetSchoolYearDateEnd(_specialInfo.YearId).ToShortDateString() + " 11:59:59 PM";
            }

            if (RemoteClient.ProcStatic.IsRecordLocked(DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd),
                DateTime.Parse(_specialManager.ServerDateTime), (Int32)CommonExchange.SystemRange.MonthAllowance) ||
                !(RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) || 
                RemoteServerLib.ProcStatic.IsSystemAccessPayrollMaster(_userInfo) ||
                RemoteServerLib.ProcStatic.IsSystemAccessCollegeRegistrar(_userInfo) ||
                RemoteServerLib.ProcStatic.IsSystemAccessVpOfFinance(_userInfo) ||
                RemoteServerLib.ProcStatic.IsSystemAccessCashier(_userInfo)) || _specialInfo.IsMarkedDeleted)
            {
                lblStatus.Text = "This record is LOCKED.";

                this.pbxLocked.Visible = true;
                this.pbxUnlock.Visible = false;

                this.btnDelete.Visible = this.btnUpdate.Visible = this.lnkEnroll.Visible = this.lnkWithdraw.Visible = _canWithdraw = false;
            }
            else if (RemoteServerLib.ProcStatic.IsSystemAccessCashier(_userInfo) ||
                RemoteServerLib.ProcStatic.IsSystemAccessVpOfFinance(_userInfo))
            {
                this.btnSearchSubject.Visible = this.btnSearchEmployee.Visible = this.lnkEnroll.Enabled = this.lnkWithdraw.Enabled = false;
            }
            else if (RemoteServerLib.ProcStatic.IsSystemAccessPayrollMaster(_userInfo))
            {
                this.btnSearchSubject.Visible = this.btnSearchEmployee.Visible = this.lnkEnroll.Enabled = false;
            }

            this.btnSearchEmployee.Visible = this.btnSearchSubject.Visible = false;

            this.btnDelete.Enabled = _canWithdraw;

        } //----------------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasUpdated && (!_specialInfo.Equals(_specialInfoTemp) || _specialManager.HasEnrollWithdrawChanges()))
            {
                String strMsg = "There has been changes made in the current special class information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }

            _specialManager.SetLoadDeloadTableToNull();

        } //----------------------------------
        //####################################END CLASS LoanInformationCreate EVENTS######################################

        //#########################################BUTTON btnClose EVENTS##################################################
        //event is raised when the button is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        } //------------------------------------------
        //#######################################END BUTTON btnClose EVENTS#################################################

        //##############################################BUTTON btnUpdate EVENTS##############################################
        //event is raised when the button is clicked
        private void btnUpdateClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to update the special class information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The special class information has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _specialManager.UpdateSpecialClassInformation(_userInfo, _specialInfo);

                        this.Cursor = Cursors.Arrow;

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
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }
        } //---------------------------------------
        //############################################END BUTTON btnUpdate EVENTS############################################

        //###############################################BUTTON btnDelete EVENTS################################################
        //event is raised when the button is clicked
        private void btnDeleteClick(object sender, EventArgs e)
        {
            try
            {
                String strMsg = "Marking a special class information as deleted might affect the following:" +
                                "\n\n1.) The system inventory." +
                                "\n2.) The employee salary." +
                                "\n\nAre you sure you want to mark as deleted the special class information?";

                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Mark As Deleted", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

                if (msgResult == DialogResult.Yes)
                {
                    strMsg = "Are you really sure you want to mark as deleted the special class information?";

                    msgResult = MessageBox.Show(strMsg, "Confirm Mark As Deleted", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The special class information has been successfully marked as deleted.";

                        this.Cursor = Cursors.WaitCursor;

                        _specialManager.DeleteSpecialClassInformation(_userInfo, _specialInfo.SpecialClassSysId);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasDeleted = true;

                        this.Close();
                    }
                    else if (msgResult == DialogResult.Cancel)
                    {
                        this.Close();
                    }
                }
                else if (msgResult == DialogResult.Cancel)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Deleting");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }

        } //------------------------------
        //#############################################END BUTTON btnDelete EVENTS##############################################
        #endregion
    }
}
