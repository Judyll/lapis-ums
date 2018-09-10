using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace OfficeServices
{
    partial class SubjectScheduleDetailsUpdate
    {
        #region Class General Variable Declarations
        private CommonExchange.ScheduleInformationDetails _schedDetailsInfoTemp;

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
        public SubjectScheduleDetailsUpdate(CommonExchange.SysAccess userInfo, SubjectSchedulingLogic scheduleManager, 
            CommonExchange.ScheduleInformation schedInfo, CommonExchange.ScheduleInformationDetails schedDetailsInfo)
            : base(userInfo, scheduleManager, schedInfo)
        {
            this.InitializeComponent();
           
            _schedDetailsInfo = schedDetailsInfo;
      
            this.FormClosing += new FormClosingEventHandler(ClassClossing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnEdit.Click += new EventHandler(btnUpdateClick);
            this.btnDelete.Click += new EventHandler(btnDeleteClick);
        }

        #endregion

        #region Class Event Void Procedures
        //#####################################CLASS SubjectScheduleDetailsUpate EVENTS########################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            _isForUpdate = true;

            _schedDetailsInfo.ScheduleInfo.SubjectInfo.SubjectCode = _schedInfo.SubjectInfo.SubjectCode;
            _schedDetailsInfo.ScheduleInfo.SubjectInfo.DescriptiveTitle = _schedInfo.SubjectInfo.DescriptiveTitle;

            lblSysIdSubject.Text = _schedInfo.SubjectInfo.SubjectSysId;
            lblSubjectCodeDescription.Text = _schedInfo.SubjectInfo.SubjectCode + " - " + _schedInfo.SubjectInfo.DescriptiveTitle;
            lblSubjectDepartment.Text = _schedInfo.SubjectInfo.DepartmentInfo.DepartmentName;
            lblUnitsLabHours.Text = _scheduleManager.GetSubjectUnitsHours(_schedInfo.SubjectInfo.LectureUnits, 
                _schedInfo.SubjectInfo.LabUnits, _schedInfo.SubjectInfo.NoHours);
      
            this.optField.CheckedChanged -= new EventHandler(optFieldCheckedChanged);
            this.optTBA.CheckedChanged -= new EventHandler(optTBACheckedChanged);
            this.optCampus.CheckedChanged -= new EventHandler(optCampusCheckedChanged);

            if (String.IsNullOrEmpty(_schedDetailsInfo.ClassroomInfo.ClassroomSysId) &&
                (String.IsNullOrEmpty(_schedDetailsInfo.FieldRoom) && String.Equals(_schedDetailsInfo.DayTimeFieldRoom, "TBA")))
            {
                this.optTBA.Checked = true;
                this.optField.Checked = this.optCampus.Checked =  this.lblClassCode.Visible = this.lnkEdit.Visible =
                    this.txtFieldRoom.Visible = this.lblMCapacity.Visible = this.pnlClassroomBased.Visible = 
                    this.lnkEditTimeFieldRoom.Visible = this.pnlFieldRoom.Visible =  false;              
            }
            else
            {
                this.optTBA.Checked = false;
                this.optField.Checked = !_schedDetailsInfo.IsClassroom;
                this.optCampus.Checked = _schedDetailsInfo.IsClassroom;

                if (!_schedDetailsInfo.IsClassroom)
                {
                    this.lblClassCode.Visible = this.lblMCapacity.Visible = this.lnkEdit.Visible = false;
                }
            }
            
            if (this.optField.Checked)
            {
                this.txtFieldRoom.Enabled = this.txtFieldRoom.Visible = this.lnkEditTimeFieldRoom.Visible = true;
                this.txtFieldRoom.Text = _schedDetailsInfo.FieldRoom;
                this.lblEditTimeClassroomBased.Visible = this.pnlClassroomBased.Visible = this.lnkEdit.Visible = false;

                this.lblFieldRoomTime.Text = !_schedInfo.IsIrregularModular ? _schedDetailsInfo.DayTimeFieldRoom : 
                    String.IsNullOrEmpty(_schedDetailsInfo.ManualScheduleFieldRoom) ? "TBA" : _schedDetailsInfo.ManualScheduleFieldRoom;

                this.lblEditTimeClassroomBased.Text = String.Empty;
            }
            else if (this.optCampus.Checked)
            {
                this.txtFieldRoom.Enabled = this.lnkEditTimeFieldRoom.Visible = this.pnlFieldRoom.Visible = false;
                this.lblEditTimeClassroomBased.Visible = this.pnlClassroomBased.Visible = this.lnkEdit.Visible = true;
            }

            if (_schedDetailsInfo.LectureUnits > 0 || _schedDetailsInfo.LabUnits > 0)
            {
                this.optUnits.Checked = true;
                this.txtLecture.Enabled = true;
                this.txtLaboratory.Enabled = true;
            }
            else
            {
                this.optHours.Checked = true;
                this.hrmHours.Enabled = true;

                 Int32 hours = 0, minutes = 0, count = 1;

                if (!String.IsNullOrEmpty(_schedDetailsInfo.NoHours))
                {
                    String[] strSplit = _schedDetailsInfo.NoHours.Split(':');

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
            }

            this.optField.CheckedChanged += new EventHandler(optFieldCheckedChanged);
            this.optTBA.CheckedChanged += new EventHandler(optTBACheckedChanged);
            this.optCampus.CheckedChanged += new EventHandler(optCampusCheckedChanged);

            if (_schedDetailsInfo.IsClassroom)
            {
                this.lblClassCode.Visible = true;
                this.lblMCapacity.Visible = true;
                this.lblClassroomCode.Visible = true;
                this.lblMaxCapacity.Visible = true;
                this.lnkEdit.Visible = this.pnlClassroomBased.Visible = this.lnkEdit.Visible = true;

                this.lblClassroomCode.Text = _schedDetailsInfo.ClassroomInfo.ClassroomCode;
                this.lblMaxCapacity.Text = _schedDetailsInfo.ClassroomInfo.MaximumCapacity.ToString();

                this.lblEditTimeClassroomBased.Text = !_schedInfo.IsIrregularModular ? _schedDetailsInfo.DayTimeClassroom :
                    String.IsNullOrEmpty(_schedDetailsInfo.ManualScheduleClassroom) ? "TBA" : _schedDetailsInfo.ManualScheduleClassroom;

                String temp = this.lblEditTimeClassroomBased.Text.Replace("&", "&&");

                this.lblEditTimeClassroomBased.Text = temp;

                this.lblFieldRoomTime.Text = String.Empty;
            }          

            this.txtLecture.Text = _schedDetailsInfo.LectureUnits.ToString();
            this.txtLaboratory.Text = _schedDetailsInfo.LabUnits.ToString();
            this.txtSection.Text = _schedDetailsInfo.Section;

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
               RemoteServerLib.ProcStatic.IsSystemAccessOfficeUser(_userInfo, _schedInfo.SubjectInfo.DepartmentInfo.DepartmentId)) ||
               _schedInfo.IsMarkedDeleted)
            {
                this.lblStatus.Text = "This record is LOCKED.";
                this.lblStatus.Visible = true;

                this.pbxLocked.Visible = true;
                this.pbxUnlock.Visible = false;

                this.btnDelete.Visible = this.btnEdit.Visible = this.lnkEdit.Visible = false;
            }
            else if (!String.IsNullOrEmpty(_schedDetailsInfo.EmployeeInfo.EmployeeSysId))
            {
                this.lblStatus.Text = "This record is LOCKED by " + 
                    RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(_schedDetailsInfo.EmployeeInfo.PersonInfo.LastName,
                    _schedDetailsInfo.EmployeeInfo.PersonInfo.FirstName, _schedDetailsInfo.EmployeeInfo.PersonInfo.MiddleName);
                this.lblStatus.Visible = true;

                this.pbxLocked.Visible = true;
                this.pbxUnlock.Visible = false;

                this.btnDelete.Visible = this.btnEdit.Visible = this.lnkEdit.Visible = false;
            }
            else
            {
                this.lblStatus.Text = "This record is OPEN.";
                this.lblStatus.Visible = true;

                this.pbxLocked.Visible = false;
                this.pbxUnlock.Visible = true;

                this.btnDelete.Visible = this.btnEdit.Visible = true;
            }

            _schedDetailsInfoTemp = (CommonExchange.ScheduleInformationDetails)_schedDetailsInfo.Clone();
        }//----------------------

        //event is raised when the class is closing
        private void ClassClossing(object sender, FormClosingEventArgs e)
        {
            if (!_hasUpdated && !_schedDetailsInfo.Equals(_schedDetailsInfoTemp))
            {
                String strMsg = "There has been changes made in the current schedule information details. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else  
                {
                    //clears only schedule details list so that i will not appear in the schedule list
                    _scheduleManager.ClearScheduleList(_schedDetailsInfo.ScheduleDetailsSysId);
                }
            }
        }//--------------------
        //#####################################END  CLASS SubjectScheduleDetailsUpate EVENTS########################################

        //################################################BUTTON btnClose EVENTS####################################################
        //event is raised when btnClose is Clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//----------------------
        //################################################END BUTTON btnClose EVENTS####################################################

        //################################################BUTTON btnUpdate EVENTS####################################################
        //event is raised when btnUpdate is Clicked
        private void btnUpdateClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {                
                try
                {
                    String strMsg = "Are you sure you want to update the schedule information details?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The schedule information details has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _schedDetailsInfo.ManualSchedule = _schedDetailsInfo.IsClassroom ?
                            _schedDetailsInfo.ManualScheduleClassroom : _schedDetailsInfo.ManualScheduleFieldRoom;

                        _scheduleManager.UpdateScheduleInformationDetails(_schedDetailsInfo, _tFrames, _noOfDaysDisplayed, _noOfTimeSlotsDisplayed, 
                            _selectedIndex, _readOnlyIndex, _selectedValue, _readOnlyValue, _schedInfo.IsIrregularModular);

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
        }//------------------------
        //################################################END BUTTON btnUpdate EVENTS####################################################

         //################################################BUTTON btnDelete EVENTS####################################################
        //event is raised when btnDelete is Clicked
        private void btnDeleteClick(object sender, EventArgs e)
        {
            try
            {
                String strMsg = "Marking a subject schedule details information as deleted might affect the following:" +
                                "\n\n1.) The system inventory." +
                                "\n2.) The teacher's load and salary." +
                                "\n3.) The student's subject load schedule." +
                                "\n\nAre you sure you want to mark as deleted the subject schedule details information?";

                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Mark As Deleted", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

                if (msgResult == DialogResult.Yes)
                {
                    strMsg = "Are you really sure you want to mark as deleted the subject schedule details information?";

                    msgResult = MessageBox.Show(strMsg, "Confirm Mark As Deleted", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The subject schedule details information has been successfully marked as deleted.";

                        this.Cursor = Cursors.WaitCursor;

                        _scheduleManager.DeleteScheduleInformationDetails(_schedDetailsInfo, _tFrames, _noOfDaysDisplayed, _noOfTimeSlotsDisplayed,
                            _selectedIndex, _readOnlyIndex, _selectedValue, _readOnlyValue);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasDeleted = _hasUpdated = true;

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
        }//-----------------------------
        //################################################END BUTTON btnDelete EVENTS####################################################        
        #endregion
    }
}
