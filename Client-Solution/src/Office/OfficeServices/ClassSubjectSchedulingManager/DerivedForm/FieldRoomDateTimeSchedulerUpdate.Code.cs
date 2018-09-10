using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class FieldRoomDateTimeSchedulerUpdate
    {
        #region Class Properties Declaration
        private Boolean _hasUpdated = false;
        public Boolean HasUpdated
        {
            get { return _hasUpdated; }
        }
        #endregion

        #region Class Constructors
        public FieldRoomDateTimeSchedulerUpdate(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformation schedInfo,
            SubjectSchedulingLogic scheduleManager, CommonExchange.ScheduleInformationDetails schedDetailsInfo)
            : base(userInfo, schedInfo, scheduleManager, schedDetailsInfo)
        {
            this.InitializeComponent();

            //this.Load += new EventHandler(ClassLoad);
            this.FormClosing += new FormClosingEventHandler(ClassClossing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnEdit.Click += new EventHandler(btnEditClick);
        }       
        #endregion

        #region Class Event Void Procedure
        //############################################CLASS FieldRoomDateTimeSchedulerUpdate EVENTS#######################################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            DateTime dateStart = DateTime.Parse(_scheduleManager.ServerDateTime);
            DateTime dateEnd = dateStart;

            if (_schedInfo.SubjectInfo.CourseGroupInfo.IsSemestral && !String.IsNullOrEmpty(_schedInfo.SemesterInfo.SemesterSysId))
            {
                dateStart = _scheduleManager.GetSemesterDateStart(_schedInfo.SemesterInfo.SemesterSysId);
                dateEnd = _scheduleManager.GetSemesterDateEnd(_schedInfo.SemesterInfo.SemesterSysId);
            }
            else if (!_schedInfo.SubjectInfo.CourseGroupInfo.IsSemestral && !String.IsNullOrEmpty(_schedInfo.SchoolYearInfo.YearId))
            {
                dateStart = _scheduleManager.GetSchoolYearDateStart(_schedInfo.SchoolYearInfo.YearId);
                dateEnd = _scheduleManager.GetSchoolYearDateEnd(_schedInfo.SchoolYearInfo.YearId);
            }
            
            _scheduleManager.SelectByClassroomCodeSubjectSchedule(_userInfo, dateStart.ToString(), dateEnd.ToString(),
                String.Empty, _schedDetailsInfo.ScheduleDetailsSysId);

            this.ctfDayTime.InitializeTimeFrameTables(_scheduleManager.GetWeekDayTable(this.ctfDayTime.WeekDayIdFieldName,
                this.ctfDayTime.WeekDayDescriptionFieldName, this.ctfDayTime.WeekDayAcronymFieldName),
                _scheduleManager.GetWeekTimeTable(this.ctfDayTime.TimeIdFieldName, this.ctfDayTime.TimeDescriptionFieldName),
                _scheduleManager.GetReadOnlySlotTable(this.ctfDayTime.ReadOnlySubjectCodeFieldName, this.ctfDayTime.TimeIdFieldName,
                this.ctfDayTime.WeekDayIdFieldName), 10);

            this.ctfDayTime.TimeFrames = _scheduleManager.GetTimeFrames(this.ctfDayTime.NumberOfDaysDisplayed, this.ctfDayTime.NumberOfTimeSlotsDisplayed,
                (Int32)RemoteClient.ControlTimeFrame.SelectedReadOnlyIndex.Selected, (Int32)RemoteClient.ControlTimeFrame.SelectedReadOnlyIndex.ReadOnly,
                (Int32)RemoteClient.ControlTimeFrame.SelectedValue.Selected, (Int32)RemoteClient.ControlTimeFrame.ReadOnlyValue.ReadOnly,
                (Int32)RemoteClient.ControlTimeFrame.SelectedValue.NotSelected, (Int32)RemoteClient.ControlTimeFrame.ReadOnlyValue.NotReadOnly);
        }//---------------------
        //############################################END CLASS FieldRoomDateTimeSchedulerUpdate EVENTS#######################################################

        //#####################################CLASS FieldRoomDateTimeSchedulerUpdate EVENTS########################################
        //event is raised when the class is clossi
        private void ClassClossing(object sender, FormClosingEventArgs e)
        {
            if (!_hasUpdated)
            {
                String strMsg = "There has been changes made in the current field room date time scheduler module. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    _scheduleManager.ClearDayTimeTable();
                }
            }
        }//---------------------
        //#####################################END CLASS FieldRoomDateTimeSchedulerUpdate EVENTS########################################

        //################################################BUTTON btnClose EVENTS####################################################
        //event is raised when btnClose is Clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//--------------------
        //################################################END BUTTON btnClose EVENTS####################################################

        //################################################BUTTON btnEdit EVENTS####################################################
        //event is raised when btnEdit is Clicked
        private void btnEditClick(object sender, EventArgs e)
        {
            _hasUpdated = true;

            _tFrames = this.ctfDayTime.TimeFrames;
            _noOfDaysDisplayed = this.ctfDayTime.NumberOfDaysDisplayed;
            _noOfTimeSlotsDisplayed = this.ctfDayTime.NumberOfTimeSlotsDisplayed;
            _selectedIndex = (Int32)RemoteClient.ControlTimeFrame.SelectedReadOnlyIndex.Selected;
            _readOnlyIndex = (Int32)RemoteClient.ControlTimeFrame.SelectedReadOnlyIndex.ReadOnly;
            _selectedValue = (Int32)RemoteClient.ControlTimeFrame.SelectedValue.Selected;
            _readOnlyValue = (Int32)RemoteClient.ControlTimeFrame.ReadOnlyValue.ReadOnly;

            _scheduleManager.UpdateScheduleInformationDetails(_schedDetailsInfo, _tFrames, _noOfDaysDisplayed, _noOfTimeSlotsDisplayed,
                        _selectedIndex, _readOnlyIndex, _selectedValue, _readOnlyValue, _schedInfo.IsIrregularModular);

            this.Close();
        }//-----------------------
        //################################################END BUTTON btnEdit EVENTS####################################################
        #endregion
    }
}
