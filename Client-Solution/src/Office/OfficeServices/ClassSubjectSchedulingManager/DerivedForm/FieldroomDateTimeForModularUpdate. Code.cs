using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class FieldroomDateTimeForModularUpdate
    {
        #region Class Properties Declaration
        private Boolean _hasUpdated = false;
        public Boolean HasUpdated
        {
            get { return _hasUpdated; }
        }
        #endregion

        #region Class Constructors
        public FieldroomDateTimeForModularUpdate(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformation schedInfo,
            SubjectSchedulingLogic scheduleManager, ref CommonExchange.ScheduleInformationDetails schedDetailsInfo)
            : base(userInfo, schedInfo, scheduleManager, ref schedDetailsInfo)
        {
            this.InitializeComponent();

            this.Load += new EventHandler(ClassLoad);
            this.FormClosing += new FormClosingEventHandler(ClassClossing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnEdit.Click += new EventHandler(btnEditClick);
        }
        #endregion

        #region Class Event Void Procedures
        //############################################CLASS FieldroomDateTimeForModularUpdate EVENTS#######################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            this.txtDayAndTime.Text = _schedDetailsInfo.ManualScheduleFieldRoom;
        }//----------------------
        //############################################END CLASS FieldroomDateTimeForModularUpdate EVENTS#######################################################

        //#####################################CLASS FieldroomDateTimeForModularUpdate EVENTS########################################
        //event is raised when the class is loaded
        private void ClassClossing(object sender, FormClosingEventArgs e)
        {
            if (!_hasUpdated)
            {
                String strMsg = "There has been changes made in the current filedroom date time scheduler module. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    _schedDetailsInfo.ManualScheduleFieldRoom = String.Empty;
                }
            }
        }//-------------------
        //#####################################END CLASS FieldroomDateTimeForModularUpdate EVENTS########################################

        //#####################################BUTTON btnClose EVENTS########################################
        //event is raised when the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//------------------
        //#####################################END BUTTON btnClose EVENTS########################################

        //#####################################BUTTON btnEdit EVENTS########################################
        //event is raised when the control is clicked
        private void btnEditClick(object sender, EventArgs e)
        {
            _hasUpdated = true;

            _schedDetailsInfo.ManualScheduleFieldRoom = String.IsNullOrEmpty(_schedDetailsInfo.ManualScheduleFieldRoom) ?
                "TBA" : _schedDetailsInfo.ManualScheduleFieldRoom;

            _scheduleManager.UpdateScheduleInformationDetails(_schedDetailsInfo, _schedInfo.IsIrregularModular);

            this.Close();
        }//-------------------
        //#####################################END BUTTON btnEdit EVENTS########################################
        #endregion
    }
}
