using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class StudentEntryLevelCreate
    {
        #region Class Properties Declarations
        private Boolean _hasCreated = false;
        public Boolean HasCreated
        {
            get { return _hasCreated; }
        }
        #endregion

        #region Class Constructors
        public StudentEntryLevelCreate(CommonExchange.SysAccess userInfo, CommonExchange.StudentEnrolmentCourse enrolmentCourseInfo, StudentLogic studentManager, String yearLevelId)
            : base(userInfo, enrolmentCourseInfo, studentManager, yearLevelId)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _studentManager = studentManager;

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnCancel.Click += new EventHandler(btnCancelClick);
            this.btnCreate.Click += new EventHandler(btnCreateClick);
        }     

        #endregion

        #region Class Event Void Procedures
        //#########################################CLASS StudentEntryLevelCreate EVENTS###########################################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            base.ClassLoad(sender, e);
        }//-----------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasCreated)
            {
                String strMsg = "Are you sure you want to cancel the creation of a new student entry level?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//-------------------------------
        //#########################################END CLASS StudentEntryLevelCreate EVENTS###########################################################

        //#########################################BUTTON btnClose EVENTS###########################################################
        //event is raised when the control is clicked
        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }//----------------------------------
        //#########################################END BUTTON btnClose EVENTS###########################################################

        //#########################################COMBOBOX cboYear EVENTS###########################################################
        //event is raised when the control selected index changed
        protected override void cboYearSelectedIndexChanged(object sender, EventArgs e)
        {
            base.cboYearSelectedIndexChanged(sender, e);

            this.SetRecordLocked();
        }//------------------------
        //#########################################END  COMBOBOX cboYear EVENTS###########################################################

        //#########################################COMBOBOX cboSemester EVENTS###########################################################
        //event is raised when the control selected index changed
        protected override void cboSemesterSelectedIndexChanged(object sender, EventArgs e)
        {
            base.cboSemesterSelectedIndexChanged(sender, e);

            this.SetRecordLocked();
        }//----------------------
        //#########################################END COMBOBOX cboSemester EVENTS###########################################################

        //#########################################BUTTON btnCreate EVENTS###########################################################
        //event is raised when the control is clicked
        private void btnCreateClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to create the new student entry level?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Create", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The new student entry level has been successfully created.";

                        this.Cursor = Cursors.WaitCursor;

                        _studentManager.InsertStudentEnrolmentLevel(_enrolmentLevelInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasCreated = true;

                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Creating", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }//-----------------------------------
        //#########################################END BUTTON btnCreate EVENTS###########################################################       
        #endregion

        #region Programmer Defined Void Procedures
        //this procedure will set record locked
        private void SetRecordLocked()
        {
            if (RemoteClient.ProcStatic.IsRecordLocked(_dateEnd, DateTime.Parse(_studentManager.ServerDateTime),
                (Int32)CommonExchange.SystemRange.MonthAllowance))
            {
                this.btnCreate.Visible = false;

                this.lblStatus.Text = "This record is LOCKED";

                this.pbxLocked.Visible = true;
                this.pbxUnlock.Visible = false;
            }
            else
            {
                this.btnCreate.Visible = true;

                this.lblStatus.Text = "This record is OPEN";

                this.pbxLocked.Visible = false;
                this.pbxUnlock.Visible = true;
            }
        }//------------------------
        #endregion
    }
}
