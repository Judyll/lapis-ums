using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class FieldRoomDateTimeSchedulerCreate
    {
        #region Class Properties Declaration
        private Boolean _hasInserted = false;
        public Boolean HasInserted
        {
            get { return _hasInserted; }
        }
        #endregion

        #region Class Constructors
        public FieldRoomDateTimeSchedulerCreate(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformation schedInfo,
            SubjectSchedulingLogic scheduleManager, CommonExchange.ScheduleInformationDetails schedDetailsInfo)
            : base(userInfo, schedInfo, scheduleManager, schedDetailsInfo)
        {
            this.InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(ClassClossing);
            this.btnCancel.Click += new EventHandler(btnCancelClick);
            this.btnInsert.Click += new EventHandler(btnInsertClick);
        }       
       
        #endregion

        #region Class Event Void Procedures
        //################################################FieldRoomDateTimeSchedulerCreate ClassClossing EVENTS####################################################
        //event is raised when the class is clossing
        private void ClassClossing(object sender, FormClosingEventArgs e)
        {
            if (!_hasInserted)
            {
                String strMsg = "Are you sure you whant to cancel the creation of a new day and time information?";
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
        }//----------------------
        //############################################ END FieldRoomDateTimeSchedulerCreate ClassClossing EVENTS####################################################

        //################################################BUTTON btnClose EVENTS####################################################
        //event is raised when btnClose is Clicked
        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }//-----------------------
        //################################################END BUTTON btnClose EVENTS####################################################

        //################################################BUTTON btnInsert EVENTS####################################################
        //event is raised when the btnInsert is Clicked
        private void btnInsertClick(object sender, EventArgs e)
        {
            _hasInserted = true;

            _tFrames = this.ctfDayTime.TimeFrames;
            _noOfDaysDisplayed = this.ctfDayTime.NumberOfDaysDisplayed;
            _noOfTimeSlotsDisplayed = this.ctfDayTime.NumberOfTimeSlotsDisplayed;
            _selectedIndex = (Int32)RemoteClient.ControlTimeFrame.SelectedReadOnlyIndex.Selected;
            _readOnlyIndex = (Int32)RemoteClient.ControlTimeFrame.SelectedReadOnlyIndex.ReadOnly;
            _selectedValue = (Int32)RemoteClient.ControlTimeFrame.SelectedValue.Selected;
            _readOnlyValue = (Int32)RemoteClient.ControlTimeFrame.ReadOnlyValue.ReadOnly;

            _scheduleManager.InsertScheduleInformationDetails(ref _schedDetailsInfo, _tFrames, _noOfDaysDisplayed, _noOfTimeSlotsDisplayed,
                        _selectedIndex, _readOnlyIndex, _selectedValue, _readOnlyValue, _schedInfo.IsIrregularModular);

            this.Close();
        }//-----------------------
        //################################################END BUTTON btnInsert EVENTS####################################################
        #endregion

    }
}
