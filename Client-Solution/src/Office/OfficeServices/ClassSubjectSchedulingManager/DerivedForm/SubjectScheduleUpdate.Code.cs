using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace OfficeServices
{
    partial class SubjectScheduleUpdate
    {
        #region Class General Variable Declarations
        private CommonExchange.ScheduleInformation _schedInfoTemp;

        private String _dateStart = String.Empty;
        private String _dateEnd = String.Empty;
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

        public SubjectScheduleUpdate(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformation schedInfo, SubjectSchedulingLogic scheduleManager)
            : base(userInfo, scheduleManager)
        {

            this.InitializeComponent();

            _schedInfo = schedInfo;
            _schedInfoTemp = (CommonExchange.ScheduleInformation)schedInfo.Clone();
         
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(ClassClosing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);
            this.btnDelete.Click += new EventHandler(btnDeleteClick);
        }
        #endregion

        #region Class Event Void Procedures
        //#####################################CLASS SubjectScheduleUpdate EVENTS########################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.lblSysID.Text = _schedInfo.ScheduleSysId;

            this.cboYearSemester.SelectedIndexChanged -= new EventHandler(cboYearSemesterSelectedIndexChanged);

            _scheduleManager.InitializeSchoolYearSemesterCombo(cboYearSemester, _schedInfo.SubjectInfo.CourseGroupInfo.IsSemestral, 
                _schedInfo.SchoolYearInfo.YearId, _schedInfo.SemesterInfo.SemesterSysId);

            this.cboYearSemester.SelectedIndexChanged += new EventHandler(cboYearSemesterSelectedIndexChanged);

            this.chkIsTeamTeaching.Checked = _schedInfo.IsTeamTeaching;

            this.chkFixedAmount.Checked = _schedInfo.IsFixedAmount;

            this.txtFixedAmount.Text = _schedInfo.Amount.ToString("N");

            if (_schedInfo.IsTeamTeaching)
            {
                this.chkIsTeamTeaching.Enabled = false;
            }
            else
            {
                this.lnkAddDetails.Enabled = false;
            }

            this.chkIsIrregularModular.CheckedChanged -= new EventHandler(chkIsIrregularModularCheckedChanged);

            this.chkIsIrregularModular.Checked = _schedInfo.IsIrregularModular;

            this.chkIsIrregularModular.CheckedChanged -= new EventHandler(chkIsIrregularModularCheckedChanged);
            this.chkIsIrregularModular.CheckedChanged += new EventHandler(chkIsIrregularModularCheckedChanged);

            this.chkIsIrregularModular.Enabled = false;

            this.lblSysIdSubject.Text = _schedInfo.SubjectInfo.SubjectSysId;
            this.lblSubjectCodeDescription.Text = _schedInfo.SubjectInfo.SubjectCode + " - " + _schedInfo.SubjectInfo.DescriptiveTitle;
            this.lblSubjectDepartment.Text = _schedInfo.SubjectInfo.DepartmentInfo.DepartmentName;
            this.lblUnitsLabHours.Text = _scheduleManager.GetSubjectUnitsHours(_schedInfo.SubjectInfo.LectureUnits, 
                _schedInfo.SubjectInfo.LabUnits, _schedInfo.SubjectInfo.NoHours);

            if (_schedInfo.SubjectInfo.CourseGroupInfo.IsSemestral)
            {
                _dateStart = _scheduleManager.GetSemesterDateStart(_schedInfo.SemesterInfo.SemesterSysId).ToShortDateString() + " 12:00:00 AM";
                _dateEnd = _scheduleManager.GetSemesterDateEnd(_schedInfo.SemesterInfo.SemesterSysId).ToShortDateString() + " 11:59:59 PM";
            }
            else
            {
                _dateStart = _scheduleManager.GetSchoolYearDateStart(_schedInfo.SchoolYearInfo.YearId).ToShortDateString() + " 12:00:00 AM";
                _dateEnd = _scheduleManager.GetSchoolYearDateEnd(_schedInfo.SchoolYearInfo.YearId).ToShortDateString() + " 11:59:59 PM";
            }       
           
            if (RemoteClient.ProcStatic.IsRecordLocked(DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd),
                DateTime.Parse(_scheduleManager.ServerDateTime), (Int32)CommonExchange.SystemRange.MonthAllowance) ||
                !(RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) ||
                RemoteServerLib.ProcStatic.IsSystemAccessVpOfAcademicAffairs(_userInfo) ||
                RemoteServerLib.ProcStatic.IsSystemAccessCashier(_userInfo) || RemoteServerLib.ProcStatic.IsSystemAccessVpOfFinance(_userInfo) ||
                RemoteServerLib.ProcStatic.IsSystemAccessOfficeUser(_userInfo, _schedInfo.SubjectInfo.DepartmentInfo.DepartmentId)) || _schedInfo.IsMarkedDeleted)
            {
                lblStatus.Text = "This record is LOCKED.";
                this.lnkAddDetails.Enabled = false;
                this.chkIsTeamTeaching.Enabled = this.chkFixedAmount.Enabled = false;

                this.pbxLocked.Visible = true;
                this.pbxUnlock.Visible = false;

                this.btnSearchSubject.Visible = this.btnDelete.Visible = this.btnUpdate.Visible = false;
            }
            else if (_scheduleManager.IsScheduleHasScheduleDetailsLoaded(_schedInfo.ScheduleSysId))
            {
                lblStatus.Text = "This record is OPEN.";

                this.pbxLocked.Visible = false;
                this.pbxUnlock.Visible = true;

                this.btnSearchSubject.Visible = this.btnDelete.Visible = this.btnUpdate.Visible = true;
            }

            if (RemoteServerLib.ProcStatic.IsSystemAccessCashier(_userInfo) || RemoteServerLib.ProcStatic.IsSystemAccessVpOfFinance(_userInfo))
            {
                this.btnDelete.Visible = false;
            }

            this.btnSearchSubject.Visible = false;

            Int32 detailsLoaded = 0;

            this.dgvScheduleDetails.DataSource = _scheduleManager.GetBySysIdScheduleScheduleDetailsTable(_schedInfo.ScheduleSysId, false, ref detailsLoaded);

            if (detailsLoaded > 0)
            {
                this.btnDelete.Enabled = false;
            }

            this.dgvMarkDeleted.DataSource = _scheduleManager.GetBySysIdScheduleScheduleDetailsTable(_schedInfo.ScheduleSysId, true, ref detailsLoaded);

            _scheduleManager.SelectBySysIDScheduleListStudentLoad(_userInfo, _schedInfo.ScheduleSysId);

            this.dgvStudentEnrolled.DataSource = _scheduleManager.GetStudentEnrolled(true);
            this.dgvStudentWithdrawn.DataSource = _scheduleManager.GetStudentEnrolled(false);

            this.tblStudentEnrolled.Text = "Student Enrolled  (" + this.dgvStudentEnrolled.Rows.Count.ToString() + ")";
            this.tblStudentWithdrawn.Text = "Student Withdrawn  (" + this.dgvStudentWithdrawn.Rows.Count.ToString() + ")";

            RemoteClient.ProcStatic.SetDataGridViewColumns(this.dgvScheduleDetails, false);
            RemoteClient.ProcStatic.SetDataGridViewColumns(this.dgvMarkDeleted, false);
            RemoteClient.ProcStatic.SetDataGridViewColumns(this.dgvStudentEnrolled, false);
            RemoteClient.ProcStatic.SetDataGridViewColumns(this.dgvStudentWithdrawn, false);

            this.SetAddDetailsTeamTeachingControls();


            if (RemoteServerLib.ProcStatic.IsSystemAccessCashier(_userInfo) || RemoteServerLib.ProcStatic.IsSystemAccessVpOfFinance(_userInfo))
            {
                this.chkIsTeamTeaching.Enabled = this.lnkAddDetails.Enabled = false;
            }

            if (RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) ||
               RemoteServerLib.ProcStatic.IsSystemAccessOfficeUser(_userInfo))
            {
                this.txtAdditionalSlots.Visible = this.lblSlots.Visible = true;

                this.txtAdditionalSlots.Text = _schedInfo.AdditionalSlots.ToString();
            }
            else
            {
                this.txtAdditionalSlots.Visible = this.lblSlots.Visible = false;
            }
        }//-------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if ((!_hasUpdated && !_schedInfo.Equals(_schedInfoTemp)) || _hasUpdatedScheduleDetails)
            {
                String strMsg = "There has been changes made in the current subject schedule information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    _scheduleManager.ClearCachedData();
                }
            }
        }//-------------------------
        //#####################################END CLASS SubjectScheduleUpdate EVENTS########################################

        //#########################################BUTTON btnClose EVENTS##################################################
        //event is raised when the button is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//---------------------------
        //#########################################END BUTTON btnClose EVENTS##################################################

        //##############################################BUTTON btnUpdate EVENTS##############################################
        //event is raised when the button is clicked
        private void btnUpdateClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to update the schedule information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The schedule information has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _scheduleManager.UpdateScheduleInformation(_userInfo, _schedInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdated = true;
                        _hasUpdatedScheduleDetails = false;

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
        }//-----------------------------
        //##############################################END BUTTON btnUpdate EVENTS##############################################

        //###############################################BUTTON btnDelete EVENTS################################################
        //event is raised when the button is clicked
        private void btnDeleteClick(object sender, EventArgs e)
        {
            try
            {
                String strMsg = "Marking a schedule information as deleted might affect the following:" +
                                "\n\n1.) The student enrollment subject list." +
                                "\n2.) The employee subject loading and salary." +
                                "\n\nAre you sure you want to mark as deleted the schedule information?";

                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Mark As Deleted", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (msgResult == DialogResult.Yes)
                {
                    strMsg = "Are you really sure you want to mark as deleted the schedule information?";

                    msgResult = MessageBox.Show(strMsg, "Confirm Mark As Deleted", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The schedule information has been successfully marked as deleted.";

                        this.Cursor = Cursors.WaitCursor;

                        _scheduleManager.DeleteScheduleInformation(_userInfo, _schedInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasDeleted = true;
                        _hasUpdatedScheduleDetails = false;

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
            
        }//-------------------
        //###############################################END BUTTON btnDelete EVENTS################################################   
        #endregion      
    }
}
