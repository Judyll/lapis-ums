using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class StudentEntryLevel
    {

        #region Class General Variable Declaration
        protected CommonExchange.SysAccess _userInfo;
        protected CommonExchange.StudentEnrolmentLevel _enrolmentLevelInfo;
        protected StudentLogic _studentManager;

        protected DateTime _dateStart = DateTime.MinValue;
        protected DateTime _dateEnd = DateTime.MinValue;

        protected CommonExchange.StudentEnrolmentCourse _enrolmentCourseInfo;
        private String _yearId = "";
        private String _yearLevelId = String.Empty;
    
        private ErrorProvider _errProvider;
        #endregion

        #region Class Constructors
        public StudentEntryLevel()
        {
            this.InitializeComponent();
        }

        public StudentEntryLevel(CommonExchange.SysAccess userInfo, CommonExchange.StudentEnrolmentCourse enrolmentCourseInfo, StudentLogic studentManager, String yearLevelId)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _studentManager = studentManager;
            _yearLevelId = yearLevelId;

            _enrolmentLevelInfo = new CommonExchange.StudentEnrolmentLevel();

            _enrolmentCourseInfo = enrolmentCourseInfo;
            _enrolmentLevelInfo.StudentEnrolmentCourseInfo.EnrolmentCourseSysId = enrolmentCourseInfo.EnrolmentCourseSysId;         

            _errProvider = new ErrorProvider();
            
            this.Load += new EventHandler(ClassLoad);
            this.cboYearLevel.SelectedIndexChanged += new EventHandler(cboYearLevelSelectedIndexChanged);
            this.cboYear.SelectedIndexChanged += new EventHandler(cboYearSelectedIndexChanged);
            this.cboSemester.SelectedIndexChanged += new EventHandler(cboSemesterSelectedIndexChanged);
        }

        #endregion

        #region Class Event Void Procedures
        //#########################################CLASS StudentEntryLevel EVENTS###########################################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            _studentManager.InitializeSchoolYearComboLevelCreate(this.cboYear, 
                _studentManager.GetSchoolYearDateStart(_studentManager.GetYearIdBySysIdSchoolFee(_enrolmentCourseInfo.SchoolFeeInfo.FeeInformationSysId)));

            //_studentManager.InitializeYearLevelCombo(this.cboYearLevel, _enrolmentCourseInfo.CourseInfo.CourseId);

            CommonExchange.CourseInformation courseInfo = _studentManager.GetSelectedCourse(_enrolmentCourseInfo.CourseInfo.CourseId);

            this.lblSysIdCourse.Text = courseInfo.CourseId;
            this.lblCourseTitle.Text = courseInfo.CourseTitle;
            this.lblDepartmentName.Text = _studentManager.GetCourseDepartmentName(courseInfo.CourseId);

            String semester = String.IsNullOrEmpty(_studentManager.GetSemesterDescription(_enrolmentCourseInfo.SemesterInfo.SemesterSysId)) ? String.Empty :
                _studentManager.GetSemesterDescription(_enrolmentCourseInfo.SemesterInfo.SemesterSysId) + "  ";

            this.lblSchoolYearSemester.Text = semester + 
                _studentManager.GetYearDescriptionByFeeInformationSystemId(_enrolmentCourseInfo.SchoolFeeInfo.FeeInformationSysId);

            this.chkIsEntryLevel.Enabled = false;
            this.chkIsEntryLevel.Checked = _enrolmentLevelInfo.IsEntryLevel = true;
            this.cboSemester.Enabled = _studentManager.IsSemestralByCourse(_enrolmentCourseInfo.CourseInfo.CourseId);
        }//-----------------------------
        //#########################################END CLASS StudentEntryLevel EVENTS###########################################################

        //#########################################COMBOBOX cboYear EVENTS###########################################################
        //event is raised when the control selected index changed
        protected virtual void cboYearSelectedIndexChanged(object sender, EventArgs e)
        {
            if (_studentManager.IsSemestralByCourse(_enrolmentCourseInfo.CourseInfo.CourseId))
            {
                _studentManager.InitializeSemesterComboLevelCreate(this.cboSemester, this.cboYear.SelectedIndex,
                    _studentManager.GetSemesterDateStart(_enrolmentCourseInfo.SemesterInfo.SemesterSysId));
            }

            _studentManager.SelectBySysIDSchoolFeeSchoolFeeLevel(_userInfo, _studentManager.GetFeeInformationSysId(this.cboYear.SelectedIndex));

            _studentManager.InitializeYearLevelCombo(this.cboYearLevel, _enrolmentCourseInfo.CourseInfo.CourseId, _yearLevelId);

            _yearId = _studentManager.GetYearId(this.cboYear.SelectedIndex);

            _dateStart = _studentManager.GetSchoolYearDateStart(_yearId);
            _dateEnd = _studentManager.GetSchoolYearDateEnd(_yearId);
        }//--------------------------
        //#########################################END COMBOBOX cboYear EVENTS###########################################################

        //#########################################COMBOBOX cboSemester EVENTS###########################################################
        //event is raised when the control selected index changed
        protected virtual void cboSemesterSelectedIndexChanged(object sender, EventArgs e)
        {
            _enrolmentLevelInfo.SemesterInfo.SemesterSysId = _studentManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex);

            _dateStart = _studentManager.GetSemesterDateStart(_enrolmentLevelInfo.SemesterInfo.SemesterSysId);
            _dateEnd = _studentManager.GetSemesterDateEnd(_enrolmentLevelInfo.SemesterInfo.SemesterSysId);
        }//---------------------------
        //#########################################END COMBOBOX cboSemester EVENTS###########################################################

        //#########################################COMBOBOX cboYearLevel EVENTS###########################################################
        //event is raised when the control selected index changed
        private void cboYearLevelSelectedIndexChanged(object sender, EventArgs e)
        {
            _enrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId = 
                _studentManager.GetFeeLevelSysId(_studentManager.GetYearLevelId(_enrolmentCourseInfo.CourseInfo.CourseId, this.cboYearLevel.SelectedIndex));
        }//----------------------------       
        #endregion

        #region Programmers Defined Functions
        //this fucntion will validate controls
        public Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.cboYearLevel, "");
            _errProvider.SetError(this.cboYear, "");
            _errProvider.SetError(this.cboSemester, "");

            if (String.IsNullOrEmpty(_enrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId))
            {
                _errProvider.SetIconAlignment(this.cboYearLevel, ErrorIconAlignment.MiddleRight);
                _errProvider.SetError(this.cboYearLevel, "There is no school fee created for this level.");
                isValid = false;
            }

            if (_studentManager.IsSemestralByCourse(_enrolmentCourseInfo.CourseInfo.CourseId) && 
                String.IsNullOrEmpty(_enrolmentLevelInfo.SemesterInfo.SemesterSysId))
            {
                _errProvider.SetIconAlignment(this.cboSemester, ErrorIconAlignment.MiddleRight);
                _errProvider.SetError(this.cboSemester, "You must select a semester.");
                isValid = false;
            }

            if (this.cboYearLevel.SelectedIndex == -1)
            {
                _errProvider.SetIconAlignment(this.cboYearLevel, ErrorIconAlignment.MiddleRight);
                _errProvider.SetError(this.cboYearLevel, "You must select a year level.");
                isValid = false;
            }
            else if (_studentManager.IsCourseYearLevelNoLesserStudentEnrolmentLevel(_userInfo,
                _enrolmentCourseInfo.StudentInfo.StudentSysId, _enrolmentCourseInfo.CourseInfo.CourseId,
                _studentManager.GetYearLevelId(_enrolmentCourseInfo.CourseInfo.CourseId, this.cboYearLevel.SelectedIndex)))
            {
                _errProvider.SetIconAlignment(this.cboYearLevel, ErrorIconAlignment.MiddleRight);
                _errProvider.SetError(this.cboYearLevel, "You must select a higher year level.");
                isValid = false;
            }

            if (_studentManager.IsExistSysIDStudentCourseLevelSemesterEnrolmentLevel(_userInfo, _enrolmentLevelInfo, _enrolmentCourseInfo.StudentInfo.StudentSysId, 
                _enrolmentLevelInfo.StudentEnrolmentCourseInfo.EnrolmentCourseSysId, 
                _enrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId, _enrolmentLevelInfo.SemesterInfo.SemesterSysId))
            {                
                _errProvider.SetIconAlignment(this.cboYearLevel, ErrorIconAlignment.MiddleRight);
                _errProvider.SetError(this.cboYearLevel, "Entry Level already exist.");
                isValid = false;
            }

            if (_studentManager.IsExistLevelSemesterYear(_enrolmentLevelInfo.SemesterInfo.SemesterSysId, _yearId))
            {
                _errProvider.SetIconAlignment(this.cboYear, ErrorIconAlignment.MiddleRight);
                _errProvider.SetError(this.cboYear, "You can only create one entry level for each school year and semester.");
                isValid = false;
            }

            if (!String.Equals(_enrolmentCourseInfo.EnrolmentCourseSysId.Substring(0, 6), "SYSTMP"))
            {
                if (!_studentManager.IsValidByCourseInformationSchoolFeeSysIDSemesterStudentEnrolmentCourse(_userInfo, _enrolmentCourseInfo.EnrolmentCourseSysId,
                    _enrolmentCourseInfo.SchoolFeeInfo.FeeInformationSysId, _enrolmentCourseInfo.SemesterInfo.SemesterSysId))
                {
                    _errProvider.SetIconAlignment(this.cboYear, ErrorIconAlignment.MiddleRight);
                    _errProvider.SetError(this.cboYear, "School year/semester is not valid.");
                    isValid = false;
                }
            }

            return isValid;
        }//----------------------------
        #endregion

    }
}