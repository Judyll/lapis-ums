using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class AuxiliaryScheduleDetailsUpdate
    {
        #region Class General Variable Declaration
        private CommonExchange.AuxiliaryServiceDetails _serviceInfoDetailsTemp;

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
        public AuxiliaryScheduleDetailsUpdate(CommonExchange.SysAccess userInfo, CommonExchange.AuxiliaryServiceSchedule serviceInfoSchedule,
            CommonExchange.AuxiliaryServiceDetails serviceInfoDetails, AuxiliaryServiceLogic auxiliaryManager)
            : base(userInfo, serviceInfoSchedule, auxiliaryManager)
        {
            this.InitializeComponent();

            _serviceInfoDetails = serviceInfoDetails;
            _serviceInfoDetailsTemp = (CommonExchange.AuxiliaryServiceDetails)serviceInfoDetails.Clone();

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnEdit.Click += new EventHandler(btnEditClick);
            this.btnDelete.Click += new EventHandler(btnDeleteClick);
        }
        #endregion

        #region Class Event Void Procedures
        //#####################################CLASS AuxiliaryScheduleDetailsUpdate EVENTS########################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            _serviceInfoDetails.AuxiliaryServiceScheduleInfo.AuxiliaryServiceInfo.ServiceCode = 
                _serviceInfoDetailsTemp.AuxiliaryServiceScheduleInfo.AuxiliaryServiceInfo.ServiceCode = _serviceInfoSchedule.AuxiliaryServiceInfo.ServiceCode;
            _serviceInfoDetails.AuxiliaryServiceScheduleInfo.AuxiliaryServiceInfo.DescriptiveTitle = 
                _serviceInfoDetailsTemp.AuxiliaryServiceScheduleInfo.AuxiliaryServiceInfo.DescriptiveTitle = 
                _serviceInfoSchedule.AuxiliaryServiceInfo.DescriptiveTitle;

            this.lblSysIdAuxiliary.Text = _serviceInfoSchedule.AuxiliaryServiceInfo.AuxServiceSysId;
            this.lblAuxiliaryServiceCodeDescription.Text = _serviceInfoSchedule.AuxiliaryServiceInfo.ServiceCode + " - " + 
                _serviceInfoSchedule.AuxiliaryServiceInfo.DescriptiveTitle;
            this.lblAuxiliaryDepartment.Text = _serviceInfoSchedule.AuxiliaryServiceInfo.DepartmentInfo.DepartmentName;
            this.lblUnitsLabHours.Text = _auxiliaryManager.GetAuxiliaryUnitsHours(_serviceInfoSchedule.AuxiliaryServiceInfo.LectureUnits, 
                _serviceInfoSchedule.AuxiliaryServiceInfo.LabUnits, _serviceInfoSchedule.AuxiliaryServiceInfo.NoHours);

            if (_serviceInfoSchedule.AuxiliaryServiceInfo.CourseGroupInfo.IsSemestral)
            {
                //this.optUnits.Enabled = this.optUnits.Checked = true;
                //this.txtLecture.Enabled = true;
                //this.txtLaboratory.Enabled = true;

                _dateStart = _auxiliaryManager.GetSemesterDateStart(_serviceInfoSchedule.SemesterInfo.SemesterSysId).ToShortDateString() + " 12:00:00 AM";
                _dateEnd = _auxiliaryManager.GetSemesterDateEnd(_serviceInfoSchedule.SemesterInfo.SemesterSysId).ToShortDateString() + " 11:59:59 PM";
            }
            else
            {
                //this.optHours.Enabled = this.optHours.Checked = true;
                //this.hrmHours.Enabled = true;

                _dateStart = _auxiliaryManager.GetSchoolYearDateStart(_serviceInfoSchedule.SchoolYearInfo.YearId).ToShortDateString() + " 12:00:00 AM";
                _dateEnd = _auxiliaryManager.GetSchoolYearDateEnd(_serviceInfoSchedule.SchoolYearInfo.YearId).ToShortDateString() + " 11:59:59 PM";
            }

            this.txtLecture.Text = _serviceInfoDetails.LectureUnits.ToString();
            this.txtLaboratory.Text = _serviceInfoDetails.LabUnits.ToString();


            Int32 hours = 0, minutes = 0, count = 1;

            if (!String.IsNullOrEmpty(_serviceInfoDetails.NoHours))
            {
                String[] strSplit = _serviceInfoDetails.NoHours.Split(':');

                foreach (String value in strSplit)
                {
                    if (!String.IsNullOrEmpty(value))
                    {
                        if (count == 1)
                        {
                            hours = Int32.Parse(value);
                        }
                        else
                        {
                            minutes = Int32.Parse(value);
                        }
                    }

                    count++;
                }
            }

            this.hrmHours.SetHoursMinutes(hours, minutes);
            //this.hrmHours.SetHoursMinutes(DateTime.Parse(_serviceInfoDetails.NoHours));
           
            //if (!this.hrmHours.IsHourMinuteZero())
            //{
            //    this.optHours.Checked = true;
            //    this.optUnits.Checked = false;
            //}
            //else
            //{
            //    this.optHours.Checked = false;
            //    this.optUnits.Checked = true;
            //}

            if (_serviceInfoDetails.LectureUnits > 0 || _serviceInfoDetails.LabUnits > 0)
            {
                this.optUnits.Checked = true;
                this.txtLecture.Enabled = true;
                this.txtLaboratory.Enabled = true;
            }
            else
            {
                this.optHours.Checked = true;
                this.hrmHours.Enabled = true;

                count = 1;

                if (!String.IsNullOrEmpty(_serviceInfoDetails.NoHours))
                {
                    String[] strSplit = _serviceInfoDetails.NoHours.Split(':');

                    foreach (String value in strSplit)
                    {
                        if (!String.IsNullOrEmpty(value))
                        {
                            if (count == 1)
                            {
                                hours = Int32.Parse(value);
                            }
                            else
                            {
                                minutes = Int32.Parse(value);
                            }
                        }

                        count++;
                    }
                }

                this.hrmHours.SetHoursMinutes(hours, minutes);
                //this.hrmHours.SetHoursMinutes(DateTime.Parse(_serviceInfoDetails.NoHours));
            }

            if (RemoteClient.ProcStatic.IsRecordLocked(DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd),
                DateTime.Parse(_auxiliaryManager.ServerDateTime), (Int32)CommonExchange.SystemRange.MonthAllowance) ||
                !(RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) ||
                RemoteServerLib.ProcStatic.IsSystemAccessSecretaryOftheVpOfAcademicAffairs(_userInfo) ||
                RemoteServerLib.ProcStatic.IsSystemAccessVpOfAcademicAffairs(_userInfo)) || _serviceInfoSchedule.IsMarkedDeleted)
            {
                this.lblStatus.Text = "This record is LOCKED.";
                this.lblStatus.Visible = true;

                this.pbxLocked.Visible = true;
                this.pbxUnlock.Visible = false;

                this.btnDelete.Visible = this.btnEdit.Visible = false;
            }
            else if (!String.IsNullOrEmpty(_serviceInfoDetails.EmployeeInfo.EmployeeSysId))
            {
                this.lblStatus.Text = "This record is LOCKED by " + RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(_serviceInfoDetails.EmployeeInfo.PersonInfo.LastName,
                    _serviceInfoDetails.EmployeeInfo.PersonInfo.FirstName, _serviceInfoDetails.EmployeeInfo.PersonInfo.MiddleName);
                this.lblStatus.Visible = true;

                this.pbxLocked.Visible = true;
                this.pbxUnlock.Visible = false;

                this.btnDelete.Visible = this.btnEdit.Visible = false;
            }
            else
            {
                this.lblStatus.Text = "This record is OPEN.";
                this.lblStatus.Visible = true;

                this.pbxLocked.Visible = false;
                this.pbxUnlock.Visible = true;
            }         

          
        }//---------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if ((!_hasUpdated && !_hasDeleted) && !_serviceInfoDetails.Equals(_serviceInfoDetailsTemp))
            {
                String strMsg = "There has been changes made in the current auxiliary service schedule information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//-----------------------
        //#####################################END CLASS AuxiliaryScheduleDetailsUpdate EVENTS########################################

        //################################################BUTTON btnClose EVENTS####################################################
        //event is raised when btnClose is Clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//----------------------------------
        //################################################END BUTTON btnClose EVENTS####################################################

        //################################################BUTTON btnUpdate EVENTS####################################################
        //event is raised when btnUpdate is Clicked
        private void btnEditClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to update the auxiliary service schedule information details?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The auxiliary service schedule information details has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _auxiliaryManager.UpdateAuxiliaryServiceDetailsInfomation(_serviceInfoDetails);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdated = true;

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
        }//--------------------------------
        //################################################END BUTTON btnUpdate EVENTS####################################################

        //################################################BUTTON btnDelete EVENTS####################################################
        //event is raised when btnDelete is Clicked
        private void btnDeleteClick(object sender, EventArgs e)
        {
            try
            {
                String strMsg = "Marking an auxiliary service schedule details information as deleted might affect the following:" +
                                "\n\n1.) The system inventory." +
                                "\n2.) The teacher's load and salary." +
                                "\n\nAre you sure you want to mark as deleted the subject schedule details information?";

                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Mark As Deleted", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

                if (msgResult == DialogResult.Yes)
                {
                    strMsg = "Are you really sure you want to mark as deleted the auxiliary service schedule details information?";

                    msgResult = MessageBox.Show(strMsg, "Confirm Mark As Deleted", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The auxiliary service schedule details information has been successfully marked as deleted.";

                        this.Cursor = Cursors.WaitCursor;

                        _auxiliaryManager.DeleteAuxiliaryServiceDetailsInformation(_serviceInfoDetails);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasDeleted = true;

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
        }//--------------------------------
        //################################################END BUTTON btnDelete EVENTS####################################################
        #endregion
    }
}
