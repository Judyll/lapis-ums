using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace OfficeServices
{
    partial class SubjectScheduleCreate
    {
        #region Class Properties Declarations
        private Boolean _hasCreated = false;
        public Boolean HasCreated
        {
            get { return _hasCreated; }
        }
        #endregion

        #region Class Constructor

        public SubjectScheduleCreate()
        {
            this.InitializeComponent();
        }

        public SubjectScheduleCreate(CommonExchange.SysAccess userInfo, SubjectSchedulingLogic scheduleManager)
            : base(userInfo, scheduleManager)
        {

            this.InitializeComponent();
     
            this.tabSchedule.TabPages.Remove(this.tblStudentEnrolled);
            this.tabSchedule.TabPages.Remove(this.tblStudentWithdrawn);

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnCancel.Click += new EventHandler(btnCancelClick);
            this.btnCreate.Click += new EventHandler(btnCreateClick);
        }       
        #endregion

        #region Class Event Void Procedures
        //#####################################CLASS SubjectScheduleCreate EVENTS########################################
        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasCreated && !_hasErrors)
            {
                String strMsg = "Are you sure you want to cancel the creation of a new subject schedule information?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    _scheduleManager.ClearCachedData();
                }
            }
        }//-------------------------------
        //#####################################END CLASS SubjectScheduleCreate EVENTS########################################

        //################################################BUTTON btnCancel EVENTS####################################################
        //event is raised when btnCancel is Clicked
        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }//----------------------------
        //################################################END BUTTON btnCancel EVENTS####################################################

        //################################################BUTTON btnCreate EVENTS####################################################
        //event is raised when btnCreate is Clicked
        private void btnCreateClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to create the new schedule information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Create", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The schedule information has been successfully created.";

                        this.Cursor = Cursors.WaitCursor;

                        _scheduleManager.InsertScheduleInformation(_userInfo, _schedInfo);

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
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Creating");
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }
        }//---------------------------------
        //################################################END BUTTON btnCreate EVENTS####################################################

        #endregion
    }
}
