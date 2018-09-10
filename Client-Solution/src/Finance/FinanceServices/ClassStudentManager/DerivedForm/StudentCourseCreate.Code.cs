using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class StudentCourseCreate
    {
        #region Class Properties Declarations
        private Boolean _hasCreatedCourse = false;
        public Boolean HasCreatedCourse
        {
            get { return _hasCreatedCourse; }
        }

        private String _studentSysId = "";
        public String StudentSysId
        {
            get { return _studentSysId; }
            set { _studentSysId = value; }
        }
        #endregion

        #region Class Constructors
        public StudentCourseCreate(CommonExchange.SysAccess userInfo, CommonExchange.Student studentInfo, StudentLogic studentManager, String couseGroupId)
            : base (userInfo, studentInfo, studentManager, couseGroupId) 
        {
            this.InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnCancel.Click += new EventHandler(btnCancelClick);
            this.btnCreate.Click += new EventHandler(btnCreateClick);
        }       
        
        #endregion

        #region Class Event Void Procedures
        //#########################################CLASS StudentCourseCreate EVENTS###########################################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            base.ClassLoad(sender, e);
        }//----------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasCreatedCourse)
            {
                String strMsg = "Are you sure you want to cancel the creation of a new student course?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//--------------------------
        //#########################################END CLASS StudentCourseCreate EVENTS###########################################################

        //#########################################BUTTON btnCancel EVENTS###########################################################
        //event is raised when the control is clicked
        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }//--------------------------
        //#########################################END BUTTON btnCancel EVENTS###########################################################

        //#########################################COMBOX cboYear EVENTS###########################################################
        //event is raised when the control is clicked
        protected override void cboYearSelectedIndexChanged(object sender, EventArgs e)
        {
            base.cboYearSelectedIndexChanged(sender, e);

            this.SetRecordLocked();
        }//----------------------------
        //#########################################END COMBOX cboYear EVENTS###########################################################

        //#########################################COMBOX cboSemester EVENTS###########################################################
        //event is raised when the control is clicked
        protected override void cboSemesterSelectedIndexChanged(object sender, EventArgs e)
        {
            base.cboSemesterSelectedIndexChanged(sender, e);

            this.SetRecordLocked();
        }//---------------------------
        //#########################################END COMBOX cboSemester EVENTS###########################################################

        //#########################################BUTTON btnCreate EVENTS###########################################################
        //event is raised when the control is clicked
        private void btnCreateClick(object sender, EventArgs e)
        {
            if (this.ValidateControls(false))
            {
                try
                {
                    String strMsg = "Are you sure you want to create the new student course information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Create", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student course information has been successfully created.";

                        this.Cursor = Cursors.WaitCursor;

                        _studentManager.InsertStudentEnrolmentCourse(ref _enrolmentCourseInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasCreatedCourse = true;

                        _studentSysId = _enrolmentCourseInfo.StudentInfo.StudentSysId;

                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Creating", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }//---------------------------
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
