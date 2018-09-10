using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class ClassroomDateTimeForModular
    {
        #region Class Data Member Declaration
        protected CommonExchange.SysAccess _userInfo;
        protected SubjectSchedulingLogic _scheduleManager;
        protected CommonExchange.ScheduleInformation _schedInfo;
        protected CommonExchange.ScheduleInformationDetails _schedDetailsInfo;

        private ErrorProvider _errProvider;
        #endregion

        #region Class Properties Declaration
        protected CommonExchange.ClassroomInformation _classRoomInfo;
        public CommonExchange.ClassroomInformation ClassRoomInfo
        {
            get { return _classRoomInfo; }
        }
        #endregion

        #region Class Constructors
        public ClassroomDateTimeForModular()
        {
            this.InitializeComponent();
        }

        public ClassroomDateTimeForModular(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformation schedInfo,
            SubjectSchedulingLogic scheduleManager, ref CommonExchange.ScheduleInformationDetails scheduleDetailsInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _schedInfo = schedInfo;
            _scheduleManager = scheduleManager;
            _schedDetailsInfo = scheduleDetailsInfo;

            _errProvider = new ErrorProvider();

            this.Load += new EventHandler(ClassLoad);
            this.btnSearchClassroom.Click += new EventHandler(btnSearchClassroomClick);
            this.txtDayAndTime.Validated += new EventHandler(txtDayAndTimeValidated);
        }     
     
        #endregion

        #region Class Event Void Procedures
        //############################################CLASS ClassroomDateTimeForModular EVENTS#######################################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            _classRoomInfo = new CommonExchange.ClassroomInformation();
        }//-------------------
        //############################################END CLASS ClassroomDateTimeForModular EVENTS#######################################################

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

                        _classRoomInfo = _scheduleManager.GetDetailsClassroomInformation(frmSearch.PrimaryId);

                        this.lblClassroomCode.Text = _classRoomInfo.ClassroomCode;
                        this.lblMaxCapacity.Text = _classRoomInfo.MaximumCapacity.ToString();

                        this.txtDayAndTime.Focus();
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
        }//-----------------
        //################################################END BUTTON btnSearchClassromm EVENTS####################################################

        //################################################TEXTBOX txtDayAndTime EVENTS####################################################
        //event is raised when thie control is validated
        private void txtDayAndTimeValidated(object sender, EventArgs e)
        {
            _schedDetailsInfo.ManualScheduleClassroom = RemoteClient.ProcStatic.TrimStartEndString(this.txtDayAndTime.Text);
        }//-----------------
        //################################################END TEXTBOX txtDayAndTime EVENTS####################################################

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
