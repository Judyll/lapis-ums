using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class ChangeStudentEnrollmentLevel
    {
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private CommonExchange.StudentEnrolmentLevel _enrolmentLevelInfo;
        private StudentLoadingLogic _studentManager;

        private String _enrolmentLevelSysIdExcludeList = String.Empty;
        private String _studentSysId = String.Empty;
        private String _yearId = String.Empty;
        private String _sysIdSemester = String.Empty;

        private ErrorProvider _errProvider;
        #endregion

        #region Class Properties Declaration
        private Boolean _hasUpdated = false;
        public Boolean HasUpdated
        {
            get { return _hasUpdated; }
        }
        #endregion

        #region Class Constructors
        public ChangeStudentEnrollmentLevel(CommonExchange.SysAccess userInfo, CommonExchange.StudentEnrolmentLevel enrolmentLevelInfo,
            StudentLoadingLogic studentManager, String enrolmentLevelSysIdExcludeLIst, String studentSysId, String yearId, String sysIdSemester)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _enrolmentLevelInfo = enrolmentLevelInfo;
            _studentManager = studentManager;
            _studentSysId = studentSysId;
            _yearId = yearId;
            _sysIdSemester = sysIdSemester;

            _enrolmentLevelSysIdExcludeList = enrolmentLevelSysIdExcludeLIst;

            this.Load += new EventHandler(ClassLoad);
            this.cboYearLevel.SelectedIndexChanged += new EventHandler(cboYearLevelSelectedIndexChanged);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);
        }        
        #endregion

        #region Class Event Void Procedures

        //###############################################CLASS ChangeStudentEnrollmentLevel EVENTS##################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            _errProvider = new ErrorProvider();

            _enrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId = String.Empty;

            this.lblCurrentYearLevel.Text = _enrolmentLevelInfo.SchoolFeeLevelInfo.YearLevelInfo.YearLevelDescription;
            this.lblSysIdCourse.Text = _enrolmentLevelInfo.StudentEnrolmentCourseInfo.CourseInfo.CourseId;
            this.lblCourseTitle.Text = _studentManager.GetCourseTitleCourseGroup(_enrolmentLevelInfo.StudentEnrolmentCourseInfo.EnrolmentCourseSysId);
            this.lblDepartmentName.Text = _studentManager.GetDepartmentDescription(_enrolmentLevelInfo.StudentEnrolmentCourseInfo.CourseInfo.CourseId);

            String semester = String.IsNullOrEmpty(_studentManager.GetSemesterDescription(_enrolmentLevelInfo.SemesterInfo.SemesterSysId)) ? String.Empty :
                _studentManager.GetSemesterDescription(_enrolmentLevelInfo.SemesterInfo.SemesterSysId) + "  ";

            this.lblSchoolYearSemester.Text = semester +
                _studentManager.GetYearLevelDescription(_enrolmentLevelInfo.SchoolFeeLevelInfo.SchoolFeeInfo.FeeInformationSysId);

            _studentManager.SelectBySysIDStudentYearIDSemesterStudentEnrolmentLevelForChangeStudentEnrollmentLevel(_userInfo, _studentSysId,
                _yearId, _sysIdSemester, _enrolmentLevelInfo.StudentEnrolmentCourseInfo.EnrolmentCourseSysId, _enrolmentLevelSysIdExcludeList);

            _studentManager.InitializedForChangeStudentEnrollmentLevelYearLevelCombo(this.cboYearLevel);
        }//-----------------------
        //###############################################END CLASS ChangeStudentEnrollmentLevel EVENTS##################################################

        //#########################################COMBOBOX cboYearLevel EVENTS###########################################################
        //event is raised when the control selected index changed
        private void cboYearLevelSelectedIndexChanged(object sender, EventArgs e)
        {
            _enrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId = _studentManager.GetStudentSchoolFeeLevelSysId(this.cboYearLevel.SelectedIndex);
        }//-------------------
        //#########################################COMBOBOX cboYearLevel EVENTS###########################################################

        //#########################################BUTTON btnClose EVENTS###########################################################
        //event is raised when the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            _studentManager.ClearChangeYearLevelTable();

            this.Close();
        }//--------------------
        //#########################################END BUTTON btnClose EVENTS###########################################################

        //#########################################BUTTON btnUpdate EVENTS###########################################################
        //event is raised when the control is clicked
        private void btnUpdateClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to update the student enrolment level?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student enrolment level has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _studentManager.UpdateStudentEnrollmentLevel(_userInfo, _enrolmentLevelInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdated = true;

                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Updating");
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }
        }//-----------------------
        //#########################################END BUTTON btnUpdate EVENTS###########################################################
        #endregion

        #region Programmer's Defined void procedures
        //this procedure will validate controls
        private Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.cboYearLevel, String.Empty);

            if (String.IsNullOrEmpty(_enrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId))
            {
                _errProvider.SetError(this.cboYearLevel, "You must select a new year level.");
                _errProvider.SetIconAlignment(this.cboYearLevel, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            return isValid;
        }//-------------------------------
        #endregion
    }
}
