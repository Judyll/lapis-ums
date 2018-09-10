using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class ClassroomDateTimeForModularCreate
    {
        #region Class Properties Declaration
        private Boolean _hasInserted = false;
        public Boolean HasInserted
        {
            get { return _hasInserted; }
        }
        #endregion

        #region Class Constructors
        public ClassroomDateTimeForModularCreate(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformation schedInfo,
           SubjectSchedulingLogic scheduleManager,ref CommonExchange.ScheduleInformationDetails schedDetailsInfo)
            : base(userInfo, schedInfo, scheduleManager, ref schedDetailsInfo)
        {
            this.InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(ClassClossing);
            this.btnCancel.Click += new EventHandler(btnCloseClick);
            this.btnInsert.Click += new EventHandler(btnInsertClick);
        }        
        #endregion

        #region Class Event Void Procedures
        //################################################ClassroomDateTimeSchedulerCreate ClassClossing EVENTS####################################################
        //event is raised when btnClose is Clicked
        private void ClassClossing(object sender, FormClosingEventArgs e)
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
                    _schedDetailsInfo.ManualScheduleClassroom = String.Empty;
                }
            }
        }//------------------------
        //################################################END ClassroomDateTimeSchedulerCreate ClassClossing EVENTS###############################################

        //################################################BUTTON btnClose EVENTS####################################################
        //event is raised when btnClose is Clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//-----------------------
        //################################################END BUTTON btnClose EVENTS####################################################

        //################################################BUTTON btnInsert EVENTS####################################################
        //event is raised when btnInsert is Clicked
        private void btnInsertClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                _hasInserted = true;               

                _scheduleManager.InsertScheduleInformationDetails(ref _schedDetailsInfo, _schedInfo.IsIrregularModular);

                this.Close();
            }
        }//----------------------
        //################################################END BUTTON btnInsert EVENTS####################################################
        #endregion
    }
}
