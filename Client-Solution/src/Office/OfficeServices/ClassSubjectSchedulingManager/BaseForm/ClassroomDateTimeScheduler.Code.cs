using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class ClassroomDateTimeScheduler
    {
        #region Class Data Member Declaration
        protected CommonExchange.SysAccess _userInfo;
        protected SubjectSchedulingLogic _scheduleManager;
        protected CommonExchange.ScheduleInformation _schedInfo;

        private ErrorProvider _errProvider;
        #endregion

        #region Class Properties Declaration
        protected CommonExchange.ClassroomInformation _classRoomInfo;
        public CommonExchange.ClassroomInformation ClassRoomInfo
        {
            get { return _classRoomInfo; }            
        }

        protected CommonExchange.ScheduleInformationDetails _schedDetailsInfo;
        public CommonExchange.ScheduleInformationDetails ScheduleInformationDetails
        {
            get { return _schedDetailsInfo; }
            set { _schedDetailsInfo = value; }
        }

        protected Int32[][][] _tFrames;
        public Int32[][][] TFrames
        {
            get { return _tFrames; }
            set { _tFrames = value; }
        }

        protected Int32 _noOfDaysDisplayed;
        public Int32 NoOfDaysDisplayed
        {
            get { return _noOfDaysDisplayed; }
            set { _noOfDaysDisplayed = value; }
        }

        protected Int32 _noOfTimeSlotsDisplayed;
        public Int32 NoOfTimeSlotsDisplayed
        {
            get { return _noOfTimeSlotsDisplayed; }
            set { _noOfTimeSlotsDisplayed = value; }
        }

        protected Int32 _selectedIndex;
        public Int32 SelectedIndex
        {
            get { return _selectedIndex; }
            set { _selectedIndex = value; }
        }

        protected Int32 _readOnlyIndex;
        public Int32 ReadOnlyIndex
        {
            get { return _readOnlyIndex; }
            set { _readOnlyIndex = value; }
        }

        protected Int32 _selectedValue;
        public Int32 SelectedValue
        {
            get { return _selectedValue; }
            set { _selectedValue = value; }
        }

        protected Int32 _readOnlyValue;
        public Int32 ReadOnlyValue
        {
            get { return _readOnlyValue; }
            set{_readOnlyValue = value; }
        }

        public Int32 TimeInterval
        {
            get { return this.ctfDayTime.TimeInterval; }
        }
        #endregion

        #region Class Constructors
        public ClassroomDateTimeScheduler()
        {
            this.InitializeComponent();
        }

        public ClassroomDateTimeScheduler(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformation schedInfo,
            SubjectSchedulingLogic scheduleManager, CommonExchange.ScheduleInformationDetails scheduleDetailsInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _scheduleManager = scheduleManager;
            _schedInfo = schedInfo;
            _schedDetailsInfo = scheduleDetailsInfo;

            _errProvider = new ErrorProvider();

            this.Load += new EventHandler(ClassLoad);
            this.btnSearchClassroom.Click += new EventHandler(btnSearchClassroomClick);
        }
        #endregion

        #region Class Event Void Procedures
        //############################################CLASS ClassroomDateTimeScheduler EVENTS#######################################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            _classRoomInfo = new CommonExchange.ClassroomInformation();
        }//----------------------
        //############################################END CLASS ClassroomDateTimeScheduler EVENTS#######################################################

        //################################################BUTTON btnSearchClassromm EVENTS####################################################
        //event is raised when btnSearchClassromm is Clicked
        private void btnSearchClassroomClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (ClassroomSearchOnTextboxList frmSearch = new ClassroomSearchOnTextboxList(_userInfo, _scheduleManager))
                {
                    frmSearch.AdoptGridSize = true;
                    frmSearch.ShowDialog(this);

                    if (frmSearch.HasSelected)
                    {
                        this.Cursor = Cursors.WaitCursor;

                        this.gbxDayTime.Enabled = true;

                        _classRoomInfo = _scheduleManager.GetDetailsClassroomInformation(frmSearch.PrimaryId);

                        this.lblClassroomCode.Text = _classRoomInfo.ClassroomCode;
                        this.lblMaxCapacity.Text = _classRoomInfo.MaximumCapacity.ToString();

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
                            _classRoomInfo.ClassroomSysId, _schedDetailsInfo.ScheduleDetailsSysId);

                        this.ctfDayTime.InitializeTimeFrameTables(_scheduleManager.GetWeekDayTable(this.ctfDayTime.WeekDayIdFieldName, 
                            this.ctfDayTime.WeekDayDescriptionFieldName, this.ctfDayTime.WeekDayAcronymFieldName),
                            _scheduleManager.GetWeekTimeTable(this.ctfDayTime.TimeIdFieldName, this.ctfDayTime.TimeDescriptionFieldName),
                            _scheduleManager.GetReadOnlySlotTable(this.ctfDayTime.ReadOnlySubjectCodeFieldName, this.ctfDayTime.TimeIdFieldName, 
                            this.ctfDayTime.WeekDayIdFieldName), 10);

                        this.ctfDayTime.TimeFrames = _scheduleManager.GetTimeFrames(this.ctfDayTime.NumberOfDaysDisplayed, 
                            this.ctfDayTime.NumberOfTimeSlotsDisplayed, (Int32)RemoteClient.ControlTimeFrame.SelectedReadOnlyIndex.Selected, 
                            (Int32)RemoteClient.ControlTimeFrame.SelectedReadOnlyIndex.ReadOnly, (Int32)RemoteClient.ControlTimeFrame.SelectedValue.Selected, 
                            (Int32)RemoteClient.ControlTimeFrame.ReadOnlyValue.ReadOnly, (Int32)RemoteClient.ControlTimeFrame.SelectedValue.NotSelected, 
                            (Int32)RemoteClient.ControlTimeFrame.ReadOnlyValue.NotReadOnly);
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Classroom Search Module");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//-------------------------
        //################################################END BUTTON btnSearchClassromm EVENTS####################################################
        #endregion

        #region Programmer-Defined Functions
        //this function will validate controls
        public Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.btnSearchClassroom, "");

            if (String.IsNullOrEmpty(_classRoomInfo.ClassroomSysId))
            {
                _errProvider.SetError(this.btnSearchClassroom, "Please select a classroom for the schedule information.");
                _errProvider.SetIconAlignment(this.btnSearchClassroom, ErrorIconAlignment.MiddleLeft);

                isValid = false;
            }

            return isValid;
        }//--------------------
        #endregion
    }
}
