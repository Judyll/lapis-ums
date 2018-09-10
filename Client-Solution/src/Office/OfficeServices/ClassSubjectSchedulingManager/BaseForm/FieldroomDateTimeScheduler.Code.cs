using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeServices
{
    partial class FieldroomDateTimeScheduler
    {
        #region Class Data Member Declaration
        protected CommonExchange.SysAccess _userInfo;
        protected SubjectSchedulingLogic _scheduleManager;
        protected CommonExchange.ScheduleInformation _schedInfo;
        #endregion       

        #region Class Properties Declaration
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
            set { _readOnlyValue = value; }
        }

        public Int32 TimeInterval
        {
            get { return this.ctfDayTime.TimeInterval; }
        }
        #endregion

        #region Class Constructors
        public FieldroomDateTimeScheduler()
        {
            this.InitializeComponent();
        }

        public FieldroomDateTimeScheduler(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformation schedInfo,
            SubjectSchedulingLogic scheduleManager, CommonExchange.ScheduleInformationDetails scheduleDetailsInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _schedInfo = schedInfo;
            _scheduleManager = scheduleManager;
            _schedDetailsInfo = scheduleDetailsInfo;

            this.Load += new EventHandler(ClassLoad);
        }

      
        #endregion

        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            this.ctfDayTime.InitializeTimeFrameTables(_scheduleManager.GetWeekDayTable(this.ctfDayTime.WeekDayIdFieldName,
                this.ctfDayTime.WeekDayDescriptionFieldName, this.ctfDayTime.WeekDayAcronymFieldName),
                _scheduleManager.GetWeekTimeTable(this.ctfDayTime.TimeIdFieldName, this.ctfDayTime.TimeDescriptionFieldName),
                _scheduleManager.GetReadOnlySlotTable(this.ctfDayTime.ReadOnlySubjectCodeFieldName, this.ctfDayTime.TimeIdFieldName,
                this.ctfDayTime.WeekDayIdFieldName), 10);

            this.ctfDayTime.TimeFrames = _scheduleManager.GetTimeFrames(this.ctfDayTime.NumberOfDaysDisplayed, this.ctfDayTime.NumberOfTimeSlotsDisplayed,
                (Int32)RemoteClient.ControlTimeFrame.SelectedReadOnlyIndex.Selected, (Int32)RemoteClient.ControlTimeFrame.SelectedReadOnlyIndex.ReadOnly,
                (Int32)RemoteClient.ControlTimeFrame.SelectedValue.Selected, (Int32)RemoteClient.ControlTimeFrame.ReadOnlyValue.ReadOnly,
                (Int32)RemoteClient.ControlTimeFrame.SelectedValue.NotSelected, (Int32)RemoteClient.ControlTimeFrame.ReadOnlyValue.NotReadOnly);
        }
    }
}
