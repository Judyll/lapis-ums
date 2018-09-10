using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class ClassroomDateTimeForModularUpdate
    {
        #region Class Data Member Declaration
        CommonExchange.ClassroomInformation _classRoomInfoTemp;
        #endregion

        #region Class Properties Declaration
        private Boolean _hasUpdated = false;
        public Boolean HasUpdated
        {
            get { return _hasUpdated; }
        }
        #endregion

        #region Class Constructors
        public ClassroomDateTimeForModularUpdate(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformation schedInfo,
            String sysIdClassRoom, SubjectSchedulingLogic scheduleManager,ref CommonExchange.ScheduleInformationDetails schedDetailsInfo)
            : base(userInfo, schedInfo, scheduleManager,ref schedDetailsInfo)
        {
            this.InitializeComponent();

            _classRoomInfo = _scheduleManager.GetDetailsClassroomInformation(sysIdClassRoom);
            _classRoomInfoTemp = (CommonExchange.ClassroomInformation)_classRoomInfo.Clone();

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnEdit.Click += new EventHandler(btnEditClick);
        }          
        
        #endregion

        #region Class Event Void Procedures
        //############################################CLASS ClassroomDateTimeForModularUpdate EVENTS#######################################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.lblClassroomCode.Text = _classRoomInfo.ClassroomCode;
            this.lblMaxCapacity.Text = _classRoomInfo.MaximumCapacity.ToString();
            this.txtDayAndTime.Text = _schedDetailsInfo.ManualScheduleClassroom;
        }//--------------------
        //############################################END CLASS ClassroomDateTimeForModularUpdate EVENTS#######################################################

        //#####################################CLASS ClassroomDateTimeForModularUpdate EVENTS########################################
        //event is raised when the class is loaded
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasUpdated && (!_classRoomInfo.Equals(_classRoomInfoTemp)))
            {
                String strMsg = "There has been changes made in the current classroom date time scheduler module. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    _schedDetailsInfo.ManualScheduleClassroom = String.Empty;
                }
            }
        }//---------------------
        //#####################################END CLASS ClassroomDateTimeForModularUpdate EVENTS########################################

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
            if (this.ValidateControls())
            {
                _hasUpdated = true;

                _scheduleManager.UpdateScheduleInformationDetails(_schedDetailsInfo, _schedInfo.IsIrregularModular);

                this.Close();
            }
        }//-------------------
        //#####################################END BUTTON btnEdit EVENTS########################################
        #endregion
    }
}
