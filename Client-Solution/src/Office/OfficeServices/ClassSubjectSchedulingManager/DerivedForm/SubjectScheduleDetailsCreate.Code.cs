using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace OfficeServices
{
    partial class SubjectScheduleDetailsCreate
    {
        #region Class Properties Declarations
        private Boolean _hasCreated = false;
        public Boolean HasCreated
        {
            get { return _hasCreated; }
        }
        #endregion

        #region Class Constructor
        public SubjectScheduleDetailsCreate(CommonExchange.SysAccess userInfo, SubjectSchedulingLogic scheduleManager, 
            CommonExchange.ScheduleInformation schedInfo)
            : base(userInfo, scheduleManager, schedInfo)
        {
            this.InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnCancel.Click += new EventHandler(btnCancelClick);
            this.btnAddDetails.Click += new EventHandler(btnAddDetailsClick);
        }
        #endregion

        #region Class Event Void Procedures
        //################################################CLASS SubjectScheduleDetailsCreate EVENTS#######################################################
        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasCreated && !_hasErrors)
            {
                String strMsg = "Are you sure you want to cancel the creation of a new schedule information details?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                   //clears only schedule details list so that i will not appear in the schedule list
                    _scheduleManager.ClearScheduleList(_schedDetailsInfo.ScheduleDetailsSysId);
                }
            }

        } //---------------------------

        //#############################################END CLASS SubjectScheduleDetailsCreate EVENTS#######################################################

        //##############################################BUTTON btnCancel EVENTS########################################################
        //event is raised when the button is clicked
        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        } //------------------------------
        //############################################END BUTTON btnCancel EVENTS######################################################

        //#############################################BUTTON btnAddDetails EVENTS########################################################
        //event is raised when the button is clicked
        private void btnAddDetailsClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to add the new schedule information details?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The schedule information details has been successfully added.";

                        this.Cursor = Cursors.WaitCursor;

                        _schedDetailsInfo.ManualSchedule = _schedDetailsInfo.IsClassroom ?
                            _schedDetailsInfo.ManualScheduleClassroom : _schedDetailsInfo.ManualScheduleFieldRoom;

                        _scheduleManager.InsertScheduleInformationDetails(ref _schedDetailsInfo, _tFrames, _noOfDaysDisplayed, _noOfTimeSlotsDisplayed,
                            _selectedIndex, _readOnlyIndex, _selectedValue, _readOnlyValue, _schedInfo.IsIrregularModular);
                        
                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasCreated = true;

                        this.Close();
                    }
                    else if (msgResult == DialogResult.Cancel)
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Adding");
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }
        } //---------------------------------
        //#########################################END BUTTON btnAddDetails EVENTS########################################################

        #endregion

    }
}
