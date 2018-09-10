using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class FieldroomDateTimeForModularCreate
    {
        #region Class Properties Declaration
        private Boolean _hasInserted = false;
        public Boolean HasInserted
        {
            get { return _hasInserted; }
        }
        #endregion

        #region Class Constructors
        public FieldroomDateTimeForModularCreate(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformation schedInfo,
           SubjectSchedulingLogic scheduleManager, ref CommonExchange.ScheduleInformationDetails schedDetailsInfo)
            : base(userInfo, schedInfo, scheduleManager, ref schedDetailsInfo)
        {
            this.InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(ClassClossing);
            this.btnCancel.Click += new EventHandler(btnCancelClick);
            this.btnInsert.Click += new EventHandler(btnInsertClick);
            
        }            
        #endregion

        #region Class Event Void Procedures
        //################################################FieldroomDateTimeForModularCreate ClassClossing EVENTS##############################################
        //event is raised when btnClose is Clicked
        private void ClassClossing(object sender, FormClosingEventArgs e)
        {
            if (!_hasInserted)
            {
                String strMsg = "Are you sure you whant to cancel the creation of a new day time information?";
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
        }//------------------------
        //################################################END FieldroomDateTimeForModularCreate ClassClossing EVENTS##############################################

        //################################################BUTTON btnClose EVENTS####################################################
        //event is raised when btnClose is Clicked
        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }//-----------------------
        //################################################END BUTTON btnClose EVENTS####################################################

        //################################################BUTTON btnInsert EVENTS####################################################
        //event is raised when btnInsert is Clicked
        private void btnInsertClick(object sender, EventArgs e)
        {
            _hasInserted = true;

            _schedDetailsInfo.ManualScheduleFieldRoom = String.IsNullOrEmpty(_schedDetailsInfo.ManualScheduleFieldRoom) ?
                "TBA" : _schedDetailsInfo.ManualScheduleFieldRoom;
          
            _scheduleManager.InsertScheduleInformationDetails(ref _schedDetailsInfo, _schedInfo.IsIrregularModular);

            this.Close();
        }//-----------------------
        //################################################END BUTTON btnInsert EVENTS####################################################
        #endregion
    }
}
