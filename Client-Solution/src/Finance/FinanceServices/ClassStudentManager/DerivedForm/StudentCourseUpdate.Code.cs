using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class StudentCourseUpdate
    {
        #region Class General Variable Declaration
        private CommonExchange.StudentEnrolmentCourse _enrolmentCourseInfoTemp;
        #endregion

        #region Class Properties Declaration
        private Boolean _hasUpDated = false;
        public Boolean HasUpDated
        {
            get { return _hasUpDated; }
        }

        private String _studentSysId = "";
        public String StudentSysId
        {
            get { return _studentSysId; }
            set { _studentSysId = value; }
        }
        #endregion

        #region Class Constructors
        public StudentCourseUpdate(CommonExchange.SysAccess userInfo, CommonExchange.Student studentInfo, 
            CommonExchange.StudentEnrolmentCourse enrolmentCourseInfo, StudentLogic studentManager, String courseGroupId)     
            : base(userInfo, studentInfo, studentManager, courseGroupId)
        {
            this.InitializeComponent();

            _enrolmentCourseInfo = enrolmentCourseInfo;

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);
        }        
        
        #endregion

        #region Class Event Void Procedures
        //########################################CLASS StudentCourseUpdate EVENTS####################################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            String semesterSysIdTemp = _enrolmentCourseInfo.SemesterInfo.SemesterSysId;

            _studentManager.InitializeSchoolYearComboCourse(this.cboYear, _enrolmentCourseInfo.SchoolFeeInfo.FeeInformationSysId);

            _studentManager.InitializeSemesterComboUpdateCourse(this.cboSemester, this.cboYear.SelectedIndex, semesterSysIdTemp);

            _enrolmentCourseInfoTemp = (CommonExchange.StudentEnrolmentCourse)_enrolmentCourseInfo.Clone();

            this.btnSearchCourse.Visible = false;

            this.chkIsCurrentCourse.Checked = _enrolmentCourseInfo.IsCurrentCourse;

            this.chkIsCurrentCourse.Enabled = _enrolmentCourseInfo.IsCurrentCourse ? false : true;

            this.cboSemester.Enabled = _studentManager.IsSemestralByCourse(_enrolmentCourseInfo.CourseInfo.CourseId) ? true : false;
            
            this.lblSysID.Text = _enrolmentCourseInfo.EnrolmentCourseSysId;
            this.lblSysIdCourse.Text = _enrolmentCourseInfo.CourseInfo.CourseId;
            this.lblCourseTitle.Text = _studentManager.GetCourseTitle(_enrolmentCourseInfo.CourseInfo.CourseId);
            this.lblDepartmentName.Text = _studentManager.GetCourseDepartmentName(_enrolmentCourseInfo.CourseInfo.CourseId);

            this.cboYear.Enabled = this.cboSemester.Enabled = false;
        }//-----------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasUpDated && !_enrolmentCourseInfo.Equals(_enrolmentCourseInfoTemp))
            {
                String strMsg = "There has been changes made in the current enrolment course information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";

                DialogResult msgResutl = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (msgResutl == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//------------------------------
        //########################################END CLASS StudentCourseUpdate EVENTS####################################################

        //########################################BUTTON btnClose EVENTS####################################################
        //event is raised when the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//----------------------------
        //########################################END BUTTON btnClose EVENTS####################################################

        //#########################################COMBOX cboYear EVENTS###########################################################
        //event is raised when the control is clicked
        protected override void cboYearSelectedIndexChanged(object sender, EventArgs e)
        {
            base.cboYearSelectedIndexChanged(sender, e);

            //this.SetRecordLocked();
        }//----------------------------
        //#########################################END COMBOX cboYear EVENTS###########################################################

        //#########################################COMBOX cboSemester EVENTS###########################################################
        //event is raised when the control is clicked
        protected override void cboSemesterSelectedIndexChanged(object sender, EventArgs e)
        {
            base.cboSemesterSelectedIndexChanged(sender, e);

            //this.SetRecordLocked();
        }//---------------------------
        //#########################################END COMBOX cboSemester EVENTS###########################################################

        //########################################BUTTON btnUpdate EVENTS####################################################
        //event is raised when the control is clicked
        private void btnUpdateClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateControls(true))
                {
                    String strMsg = "Are you sure you want to update the student course information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student course information has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _studentManager.UpdateStudentEnrolmentCourse(_enrolmentCourseInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpDated = true;

                        _studentSysId = _enrolmentCourseInfo.StudentInfo.StudentSysId;

                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Updating");
            }
        }//------------------------
        //########################################BUTTON btnUpdate EVENTS####################################################
        #endregion

        #region Programmer Defined Void Procedures
        ////this procedure will set record locked
        //private void SetRecordLocked()
        //{
        //    if (RemoteClient.ProcStatic.IsRecordLocked(_dateEnd, DateTime.Parse(_studentManager.ServerDateTime),
        //        (Int32)CommonExchange.SystemRange.MonthAllowance))
        //    {
        //        this.btnUpdate.Visible = false;

        //        this.lblStatus.Text = "This record is LOCKED";

        //        this.pbxLocked.Visible = true;
        //        this.pbxUnlock.Visible = false;
        //    }
        //    else
        //    {
        //        this.btnUpdate.Visible = true;

        //        this.lblStatus.Text = "This record is OPEN";

        //        this.pbxLocked.Visible = false;
        //        this.pbxUnlock.Visible = true;
        //    }
        //}//------------------------
        #endregion
    }
}
