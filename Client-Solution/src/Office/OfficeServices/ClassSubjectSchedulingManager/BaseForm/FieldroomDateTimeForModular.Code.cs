using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class FieldroomDateTimeForModular
    {
        #region Class Data Member Declaration
        protected CommonExchange.SysAccess _userInfo;
        protected SubjectSchedulingLogic _scheduleManager;
        protected CommonExchange.ScheduleInformation _schedInfo;
        protected CommonExchange.ScheduleInformationDetails _schedDetailsInfo;
        #endregion       

        #region Class Constructors
        public FieldroomDateTimeForModular()
        {
            this.InitializeComponent();
        }

        public FieldroomDateTimeForModular(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformation schedInfo,
            SubjectSchedulingLogic scheduleManager, ref CommonExchange.ScheduleInformationDetails scheduleDetailsInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _schedInfo = schedInfo;
            _scheduleManager = scheduleManager;
            _schedDetailsInfo = scheduleDetailsInfo;

            this.txtDayAndTime.Validated += new EventHandler(txtDayAndTimeValidated);
        }        
        #endregion

        #region Class Event Void Procedures
        //################################################TEXTBOX txtDayAndTime EVENTS####################################################
        //event is raised when thie control is validated
        private void txtDayAndTimeValidated(object sender, EventArgs e)
        {
            _schedDetailsInfo.ManualScheduleFieldRoom = RemoteClient.ProcStatic.TrimStartEndString(this.txtDayAndTime.Text);
        }//-------------------------
        //################################################END TEXTBOX txtDayAndTime EVENTS####################################################
        #endregion
    }
}
