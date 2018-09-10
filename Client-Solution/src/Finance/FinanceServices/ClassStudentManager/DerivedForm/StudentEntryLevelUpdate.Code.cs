using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class StudentEntryLevelUpdate : StudentEntryLevel
    {
        #region Class Date Member Declaration
        private CommonExchange.StudentEnrolmentLevel _enrolmentLevelInfoTemp;
        #endregion

        #region Class Properties Declaration
        private Boolean _hasDeleted = false;
        public Boolean HasDeleted
        {
            get { return _hasDeleted; }
        }

        #endregion

        #region Class Constructors
        public StudentEntryLevelUpdate(CommonExchange.SysAccess userInfo, CommonExchange.StudentEnrolmentLevel enrolmentLevelInfo, 
           CommonExchange.StudentEnrolmentCourse enrolmentCourseInfo, StudentLogic studentManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _studentManager = studentManager;

            _enrolmentCourseInfo = enrolmentCourseInfo;

            _enrolmentLevelInfo = enrolmentLevelInfo;
            _enrolmentLevelInfoTemp = (CommonExchange.StudentEnrolmentLevel)enrolmentLevelInfo.Clone();

            CommonExchange.CourseInformation courseInfo = _studentManager.GetSelectedCourse(_enrolmentCourseInfo.CourseInfo.CourseId);

            this.lblSysIdCourse.Text = courseInfo.CourseId;
            this.lblCourseTitle.Text = courseInfo.CourseTitle;
            this.lblDepartmentName.Text = _studentManager.GetCourseDepartmentName(courseInfo.CourseId);

            String semester = String.IsNullOrEmpty(_studentManager.GetSemesterDescription(_enrolmentCourseInfo.SemesterInfo.SemesterSysId)) ? String.Empty :
                _studentManager.GetSemesterDescription(_enrolmentCourseInfo.SemesterInfo.SemesterSysId) + "  ";

            this.lblSchoolYearSemester.Text = semester +
                _studentManager.GetYearDescriptionByFeeInformationSystemId(_enrolmentCourseInfo.SchoolFeeInfo.FeeInformationSysId);

            this.lblSysID.Text = _enrolmentLevelInfo.EnrolmentLevelSysId;

            this.chkIsEntryLevel.Checked = _enrolmentLevelInfo.IsEntryLevel;
            this.chkIsEntryLevel.Enabled = false;
            
            _studentManager.InitializeSchoolYearComboLevelUpdate(this.cboYear, _studentManager.GetYearIdByEnrolmentLevelSysId(_enrolmentLevelInfo.EnrolmentLevelSysId));

            if (_studentManager.IsSemestralByCourse(_enrolmentCourseInfo.CourseInfo.CourseId))
            {
                _studentManager.InitializeSemesterComboUpdateLevel(this.cboSemester, _enrolmentLevelInfo.SemesterInfo.SemesterSysId);

                _dateStart = _studentManager.GetSemesterDateStart(_enrolmentLevelInfo.SemesterInfo.SemesterSysId);
                _dateEnd = _studentManager.GetSemesterDateEnd(_enrolmentLevelInfo.SemesterInfo.SemesterSysId);               
            }
            else
            {
                _dateStart = _studentManager.GetSchoolYearDateStart(_studentManager.GetYearIdByEnrolmentLevelSysId(_enrolmentLevelInfo.EnrolmentLevelSysId));
                _dateEnd = _studentManager.GetSchoolYearDateEnd(_studentManager.GetYearIdByEnrolmentLevelSysId(_enrolmentLevelInfo.EnrolmentLevelSysId));
            }

            _studentManager.InitializeYearLevelComboUpdate(this.cboYearLevel, _enrolmentLevelInfo.EnrolmentLevelSysId);

            this.SetRecordLocked();

            this.cboSemester.Enabled = _studentManager.IsSemestralByCourse(courseInfo.CourseId) ? true : false;

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnDelete.Click += new EventHandler(btnDeleteClick);
        }
        #endregion

        #region Class Event Void Procedures
        //########################################CLASS StudentEntryLevel EVENTS####################################################
        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasDeleted && !_enrolmentLevelInfo.Equals(_enrolmentLevelInfoTemp))
            {
                String strMsg = "There has been changes made in the current entry level information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";

                DialogResult msgResutl = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResutl == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//--------------------------------
        //########################################END CLASS StudentEntryLevel EVENTS####################################################

        //########################################BUTTON btnClose EVENTS####################################################
        //event is raised when the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//------------------------------
        //########################################END BUTTON btnClose EVENTS####################################################

        //#########################################COMBOBOX cboYear EVENTS###########################################################
        //event is raised when the control selected index changed
        protected override void cboYearSelectedIndexChanged(object sender, EventArgs e)
        {
            base.cboYearSelectedIndexChanged(sender, e);
        }//------------------------
        //#########################################END  COMBOBOX cboYear EVENTS###########################################################

        //#########################################COMBOBOX cboSemester EVENTS###########################################################
        //event is raised when the control selected index changed
        protected override void cboSemesterSelectedIndexChanged(object sender, EventArgs e)
        {
            base.cboSemesterSelectedIndexChanged(sender, e);
        }//----------------------
        //#########################################END COMBOBOX cboSemester EVENTS###########################################################

        //########################################BUTTON btnUpdate EVENTS####################################################
        //event is raised when the control is clicked
        private void btnDeleteClick(object sender, EventArgs e)
        {
            try
            {
                String strMsg = "Marking the student enrolment entry level as deleted might affect the following:" +
                     "\n\n1. The student enrolment subject list. \n2. The student charges. \n3. The student scholarship list." +
                     "\n\nAre you sure you want to mark as deleted the student enrolment entry level?";
       
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, 
                    MessageBoxDefaultButton.Button2);

                if (msgResult == DialogResult.Yes)
                {
                    strMsg = "This operation cannot be UNDONE and will cause some loss of data.\n\n" +
                        "Are you really sure you want to mark as deleted the student enrolment entry level?";

                    msgResult = MessageBox.Show(strMsg, "Confirm Mark As Deleted", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, 
                        MessageBoxDefaultButton.Button2);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student entry level information has been successfully deleted.";

                        this.Cursor = Cursors.WaitCursor;

                        _studentManager.DeleteStudentEnrolmentLevel(_userInfo, _enrolmentLevelInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasDeleted = true;

                        this.Close();
                    }
                }                
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Deleting");
            }
        }//-----------------------------
        //########################################END BUTTON btnUpdate EVENTS####################################################
        #endregion

        #region Programmer Defined Void Procedures
        //this procedure will set record locked
        private void SetRecordLocked()
        {
            if (RemoteClient.ProcStatic.IsRecordLocked(_dateEnd, DateTime.Parse(_studentManager.ServerDateTime),
                (Int32)CommonExchange.SystemRange.MonthAllowance))
            {
                this.btnDelete.Visible = false;

                this.lblStatus.Text = "This record is LOCKED";

                this.pbxLocked.Visible = true;
                this.pbxUnlock.Visible = false;
            }
            else
            {
                this.btnDelete.Visible = true;

                this.lblStatus.Text = "This record is OPEN";

                this.pbxLocked.Visible = false;
                this.pbxUnlock.Visible = true;

                this.btnDelete.Enabled = !_studentManager.HasSpecialClassLoad(_userInfo, _enrolmentCourseInfo.StudentInfo.StudentSysId,
                    _dateStart.ToShortDateString() + " 12:00:00 AM", _dateEnd.ToShortDateString() + " 11:59:59 PM");
            }
        }//------------------------
        #endregion
    }
}
