using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class AuxiliaryScheduleUpdate
    {
        #region Class General Variable Declaration
        private CommonExchange.AuxiliaryServiceSchedule _serviceInfoScheduleTemp;

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

        #region Class Constructors
        public AuxiliaryScheduleUpdate(CommonExchange.SysAccess userInfo, CommonExchange.AuxiliaryServiceSchedule serviceInfoSchedule, 
            AuxiliaryServiceLogic auxiliaryManager)
            : base (userInfo, auxiliaryManager)
        {
            this.InitializeComponent();

            _serviceInfoSchedule = serviceInfoSchedule;
            _serviceInfoScheduleTemp = (CommonExchange.AuxiliaryServiceSchedule)serviceInfoSchedule.Clone();

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);
            this.btnDelete.Click += new EventHandler(btnDeleteClick);
        }
        #endregion

        #region Class Event Void Procedure
        //#####################################CLASS AuxiliaryScheduleUpdate EVENTS########################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.tabAuxiliary.Enabled = true;

            lblSysID.Text = _serviceInfoSchedule.AuxiliaryServiceInfo.AuxServiceSysId;

            this.cboYearSemester.SelectedIndexChanged -= new EventHandler(cboYearSemesterSelectedIndexChanged);

            _auxiliaryManager.InitializeSchoolYearSemesterCombo(cboYearSemester, _serviceInfoSchedule.SchoolYearInfo.YearId, 
                _serviceInfoSchedule.SemesterInfo.SemesterSysId);

            this.cboYearSemester.SelectedIndexChanged += new EventHandler(cboYearSemesterSelectedIndexChanged);

            this.lblSysIdAuxiliary.Text = _serviceInfoSchedule.AuxiliaryServiceInfo.AuxServiceSysId;
            this.lblAuxiliaryCodeDescription.Text = _serviceInfoSchedule.AuxiliaryServiceInfo.ServiceCode + " - " + 
                _serviceInfoSchedule.AuxiliaryServiceInfo.DescriptiveTitle;
            this.lblAuxiliaryDepartment.Text = _serviceInfoSchedule.AuxiliaryServiceInfo.DepartmentInfo.DepartmentName;
            this.lblUnitsLabHours.Text = _auxiliaryManager.GetAuxiliaryUnitsHours(_serviceInfoSchedule.AuxiliaryServiceInfo.LectureUnits, 
                _serviceInfoSchedule.AuxiliaryServiceInfo.LabUnits, _serviceInfoSchedule.AuxiliaryServiceInfo.NoHours);
            this.chkFixedAmount.Checked = _serviceInfoSchedule.IsFixedAmount;
            this.txtFixedAmount.Text = _serviceInfoSchedule.Amount.ToString("N");

            if (_serviceInfoSchedule.AuxiliaryServiceInfo.CourseGroupInfo.IsSemestral)
            {
                _dateStart = _auxiliaryManager.GetSemesterDateStart(_serviceInfoSchedule.SemesterInfo.SemesterSysId).ToShortDateString() + " 12:00:00 AM";
                _dateEnd = _auxiliaryManager.GetSemesterDateEnd(_serviceInfoSchedule.SemesterInfo.SemesterSysId).ToShortDateString() + " 11:59:59 PM";
            }
            else
            {
                _dateStart = _auxiliaryManager.GetSchoolYearDateStart(_serviceInfoSchedule.SchoolYearInfo.YearId).ToShortDateString() + " 12:00:00 AM";
                _dateEnd = _auxiliaryManager.GetSchoolYearDateEnd(_serviceInfoSchedule.SchoolYearInfo.YearId).ToShortDateString() + " 11:59:59 PM";
            }

            if (RemoteClient.ProcStatic.IsRecordLocked(DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd),
                DateTime.Parse(_auxiliaryManager.ServerDateTime), (Int32)CommonExchange.SystemRange.MonthAllowance) ||
                !(RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) || 
                RemoteServerLib.ProcStatic.IsSystemAccessSecretaryOftheVpOfAcademicAffairs(_userInfo) ||
                RemoteServerLib.ProcStatic.IsSystemAccessVpOfAcademicAffairs(_userInfo)) ||
                _serviceInfoSchedule.IsMarkedDeleted)
            {
                lblStatus.Text = "This record is LOCKED";
                this.lnkAddDetails.Enabled = false;

                this.pbxLocked.Visible = true;
                this.pbxUnlock.Visible = false;

                this.btnDelete.Visible = this.btnUpdate.Visible = this.chkFixedAmount.Enabled = false;
            }
            else if (_auxiliaryManager.IsScheduleHasScheduleDetailsLoaded(_serviceInfoSchedule.AuxiliaryServiceInfo.AuxServiceSysId))
            {
                lblStatus.Text = "This record is OPEN.";

                this.pbxLocked.Visible = false;
                this.pbxUnlock.Visible = true;

                this.btnDelete.Visible = false;
            }

            this.btnSearchAuxiliary.Visible = false;

            this.dgvAuxiliaryDetails.DataSource = _auxiliaryManager.GetBySysIdAuxiliaryServiceDetailsTable(_serviceInfoSchedule.AuxServiceScheduleSysId, false);
            this.dgvMarkDeleted.DataSource = _auxiliaryManager.GetBySysIdAuxiliaryServiceDetailsTable(_serviceInfoSchedule.AuxServiceScheduleSysId, true);

            RemoteClient.ProcStatic.SetDataGridViewColumns(this.dgvAuxiliaryDetails, false);
            RemoteClient.ProcStatic.SetDataGridViewColumns(this.dgvMarkDeleted, false);

        }//------------------------------

        //event is raised when the control is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if ((!_hasUpdated && !_serviceInfoSchedule.Equals(_serviceInfoScheduleTemp)) || _hasUpdatedDetails)
            {
                String strMsg = "There has been changes made in the current auxiliary service schedule information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//------------------------------
        //#####################################END CLASS AuxiliaryScheduleUpdate EVENTS########################################

        //#########################################BUTTON btnClose EVENTS##################################################
        //event is raised when the button is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//----------------------------------------
        //#########################################END BUTTON btnClose EVENTS##################################################

        //##############################################BUTTON btnUpdate EVENTS##############################################
        //event is raised when the button is clicked
        private void btnUpdateClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to update the auxiliary service schedule information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The auxiliary service schedule information has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _auxiliaryManager.UpdateAuxiliaryServiceSchedule(_userInfo, _serviceInfoSchedule);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdated = true;
                        _hasUpdatedDetails = false;

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
        }//------------------------------------
        //##############################################END BUTTON btnUpdate EVENTS##############################################

        //###############################################BUTTON btnDelete EVENTS################################################
        //event is raised when the button is clicked
        private void btnDeleteClick(object sender, EventArgs e)
        {
            try
            {
                String strMsg = "Marking a auxiliary service schedule information as deleted might affect the following:" +
                                "\n\n1.) The employee subject loading and salary." +
                                "\n\nAre you sure you want to mark as deleted the schedule information?";

                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Mark As Deleted", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

                if (msgResult == DialogResult.Yes)
                {
                    strMsg = "Are you really sure you want to mark as deleted the auxiliary service schedule information?";

                    msgResult = MessageBox.Show(strMsg, "Confirm Mark As Deleted", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The auxiliary service schedule information has been successfully marked as deleted.";

                        this.Cursor = Cursors.WaitCursor;

                        _auxiliaryManager.DeleteAuxiliaryServiceSchedule(_userInfo, _serviceInfoSchedule);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasDeleted = true;
                        _hasUpdatedDetails = false;

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
        }//---------------------------------
        //###############################################END BUTTON btnDelete EVENTS################################################
        #endregion
    }
}

