using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace FinanceServices
{
    partial class StudentCourse
    {       
        #region Class Data Member Variable Declaration
        protected CommonExchange.SysAccess _userInfo;
        protected CommonExchange.StudentEnrolmentCourse _enrolmentCourseInfo;
        protected StudentLogic _studentManager;
        protected String _couseGroupId = "";

        protected DateTime _dateStart = DateTime.MinValue;
        protected DateTime _dateEnd = DateTime.MinValue;

        public Boolean _hasSelected = false;

        private ErrorProvider _errProvider;        
        #endregion

        #region Class Constructors
        public StudentCourse()
        {
            this.InitializeComponent();
        }

        public StudentCourse(CommonExchange.SysAccess userInfo, CommonExchange.Student studentInfo, StudentLogic studentManager, String couseGroupId)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _studentManager = studentManager;

            _errProvider = new ErrorProvider();

            _couseGroupId = couseGroupId;

            _enrolmentCourseInfo = new CommonExchange.StudentEnrolmentCourse();

            if (String.IsNullOrEmpty(studentInfo.StudentSysId))
            {
                _enrolmentCourseInfo.StudentInfo.StudentSysId = "SYSTMP " + studentInfo.StudentId;
            }
            else
            {
                _enrolmentCourseInfo.StudentInfo.StudentSysId = studentInfo.StudentSysId;
            }

            this.Load += new EventHandler(ClassLoad);
            this.cboYear.SelectedIndexChanged += new EventHandler(cboYearSelectedIndexChanged);
            this.cboSemester.SelectedIndexChanged += new EventHandler(cboSemesterSelectedIndexChanged);
            this.btnSearchCourse.Click += new EventHandler(btnSearchCourseClick);
            this.chkIsCurrentCourse.CheckedChanged += new EventHandler(chkIsCurrentCourseCheckedChanged);
        }           

        #endregion

        #region Class Event Void Procedures
        //#########################################CLASS StudentCourse EVENTS###########################################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            _studentManager.InitializeSchoolYearCombo(this.cboYear);

            this.chkIsCurrentCourse.Checked = true;

            this.chkIsCurrentCourse.Enabled = false;

            this.cboSemester.Enabled = _studentManager.IsSemestralByCourseGroup(_couseGroupId);
        }//-----------------------------
        //#########################################END CLASS StudentCourse EVENTS###########################################################

        //#########################################COMBOX cboYear EVENTS###########################################################
        //event is raised when the control is clicked
        protected virtual void cboYearSelectedIndexChanged(object sender, EventArgs e)
        {
            _studentManager.InitializeSemesterCombo(this.cboSemester, this.cboYear.SelectedIndex);

            _enrolmentCourseInfo.SemesterInfo.SemesterSysId = String.Empty;

            _studentManager.SelectBySysIDSchoolFeeSchoolFeeLevel(_userInfo, _studentManager.GetFeeInformationSysId(this.cboYear.SelectedIndex));

            _enrolmentCourseInfo.SchoolFeeInfo.FeeInformationSysId = _studentManager.GetFeeInformationSysId(this.cboYear.SelectedIndex);

            _dateStart = _studentManager.GetSchoolYearDateStart(_studentManager.GetYearId(this.cboYear.SelectedIndex));
            _dateEnd = _studentManager.GetSchoolYearDateEnd(_studentManager.GetYearId(this.cboYear.SelectedIndex));
        }//-----------------------------
        //#########################################END COMBOX cboYear EVENTS###########################################################

        //#########################################COMBOX cboSemester EVENTS###########################################################
        //event is raised when the control is clicked
        protected virtual void cboSemesterSelectedIndexChanged(object sender, EventArgs e)
        {
            _enrolmentCourseInfo.SemesterInfo.SemesterSysId = _studentManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex);

            _dateStart = _studentManager.GetSemesterDateStart(_enrolmentCourseInfo.SemesterInfo.SemesterSysId);
            _dateEnd = _studentManager.GetSemesterDateEnd(_enrolmentCourseInfo.SemesterInfo.SemesterSysId);
        }//----------------------------
        //#########################################END COMBOX cboSemester EVENTS###########################################################

        //#########################################BUTTON btnSearchCourse EVENTS###########################################################
        //event is raised when the control is clicked
        private void btnSearchCourseClick(object sender, EventArgs e)
        {
            try
            {
                using (SearchOnTextBoxListCourse frmSearch = new SearchOnTextBoxListCourse(_userInfo, _studentManager, _couseGroupId))
                {
                    frmSearch.AdoptGridSize = true;
                    frmSearch.ShowDialog(this);

                    if (frmSearch.HasSelected)
                    {
                        CommonExchange.CourseInformation courseInfo = _studentManager.GetSelectedCourse(frmSearch.PrimaryId);

                        _enrolmentCourseInfo.CourseInfo.CourseId = courseInfo.CourseId;                      
                        
                        this.lblSysIdCourse.Text = _enrolmentCourseInfo.CourseInfo.CourseId;
                        this.lblCourseTitle.Text = courseInfo.CourseTitle;
                        this.lblDepartmentName.Text = _studentManager.GetCourseDepartmentName(courseInfo.CourseId);                  
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading search course module. \n\n" + ex.Message, "Error Loading", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }//----------------------------
        //#########################################END BUTTON btnSearchCourse EVENTS###########################################################

        //#########################################CHECKBOX chkIsCurrentCourse EVENTS###########################################################
        //event is raised when the control checked changed
        private void chkIsCurrentCourseCheckedChanged(object sender, EventArgs e)
        {
            _enrolmentCourseInfo.IsCurrentCourse = this.chkIsCurrentCourse.Checked;           
        }//----------------------------
        //#########################################END CHECKBOX chkIsCurrentCourse EVENTS###########################################################
        #endregion

        #region Programers-Defined Functions
        //this function will validate controls
        public Boolean ValidateControls(Boolean isUpdate)
        {
            Boolean isValid = true;

            _errProvider.SetError(this.lblCourseTitle, "");
            _errProvider.SetError(this.cboYear, "");
            _errProvider.SetError(this.cboSemester, "");
            _errProvider.SetError(this.lblSysIdCourse, "");

            if (String.IsNullOrEmpty(_enrolmentCourseInfo.CourseInfo.CourseId))
            {
                _errProvider.SetIconAlignment(this.lblCourseTitle, ErrorIconAlignment.MiddleRight);
                _errProvider.SetError(this.lblCourseTitle, "You must select a course.");

                isValid = false;
            }

            if (String.IsNullOrEmpty(_enrolmentCourseInfo.SchoolFeeInfo.FeeInformationSysId))
            {
                _errProvider.SetIconAlignment(this.cboYear, ErrorIconAlignment.MiddleRight);
                _errProvider.SetError(this.cboYear, "You must select a school fee information.");

                isValid = false;
            }

            if (_studentManager.IsSemestralByCourse(_enrolmentCourseInfo.CourseInfo.CourseId) &&
                String.IsNullOrEmpty(_enrolmentCourseInfo.SemesterInfo.SemesterSysId))
            {
                _errProvider.SetIconAlignment(this.cboSemester, ErrorIconAlignment.MiddleRight);
                _errProvider.SetError(this.cboSemester, "You must select a semester.");

                isValid = false;
            }

            if (_studentManager.IsExistsStudentCourseStudentEnrolmentCourse(_userInfo, _enrolmentCourseInfo.StudentInfo.StudentSysId, 
                _enrolmentCourseInfo.CourseInfo.CourseId) && !isUpdate)
            {
                _errProvider.SetIconAlignment(this.lblSysIdCourse, ErrorIconAlignment.MiddleRight);
                _errProvider.SetError(this.lblSysIdCourse, "The course already exist in this student.");

                isValid = false;
            }

            if (isUpdate && _studentManager.IsNotValidForCourseSchoolFeeSysIDSemesterStudentEnrolmentLevel(_userInfo, _enrolmentCourseInfo.EnrolmentCourseSysId,
                _enrolmentCourseInfo.SchoolFeeInfo.FeeInformationSysId, _enrolmentCourseInfo.SemesterInfo.SemesterSysId))
            {
                _errProvider.SetIconAlignment(this.cboYear, ErrorIconAlignment.MiddleRight);
                _errProvider.SetError(this.cboYear, "School year/semester is not valid for update.\n" + 
                    "There is a year level with a lower school year/semester that the school year/semester supplied in the course.");

                isValid = false;
            }

            return isValid;
        }
        #endregion
    }
}