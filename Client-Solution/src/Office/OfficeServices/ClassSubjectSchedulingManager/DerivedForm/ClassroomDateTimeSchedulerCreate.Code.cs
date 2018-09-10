using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class ClassroomDateTimeSchedulerCreate
    {
        #region Class Properties Declaration
        private Boolean _hasInserted = false;
        public Boolean HasInserted
        {
            get { return _hasInserted; }
        }
        #endregion

        #region Class Constructors
        public ClassroomDateTimeSchedulerCreate(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformation schedInfo,
            SubjectSchedulingLogic scheduleManager, CommonExchange.ScheduleInformationDetails schedDetailsInfo)
            : base(userInfo, schedInfo, scheduleManager, schedDetailsInfo)
        {
            this.InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnCancel.Click += new EventHandler(btnCloseClick);
            this.btnInsert.Click += new EventHandler(btnInsertClick);
        }      
        #endregion       

        #region Class Event Void Procedures
        //################################################ClassroomDateTimeSchedulerCreate ClassClossing EVENTS####################################################
        //event is raised when this class is clossing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasInserted)
            {
                String strMsg = "Are you sure you want to cancel the creation of a new classroom/day time information?";
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
        }//-------------------------
        //################################################END ClassroomDateTimeSchedulerCreate ClassClossing EVENTS##########################################

        //################################################BUTTON btnClose EVENTS####################################################
        //event is raised when btnClose is Clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//------------------------
        //################################################END BUTTON btnClose EVENTS####################################################

        //################################################BUTTON btnInsert EVENTS####################################################
        //event is raised when the btnInsert is Clicked
        private void btnInsertClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
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
            }
        }//----------------------------
        //################################################END BUTTON btnInsert EVENTS####################################################
        #endregion
    }
}
