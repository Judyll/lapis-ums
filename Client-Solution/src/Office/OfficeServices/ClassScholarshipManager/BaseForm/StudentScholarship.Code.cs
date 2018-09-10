using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace OfficeServices
{
    partial class StudentScholarship : IDisposable
    {
        #region Class Data Member Declaration
        protected CommonExchange.SysAccess _userInfo;
        protected CommonExchange.StudentScholarship _studentScholarshipInfo;
        protected ScholarshipLogic _scholarshipManager;
        protected CommonExchange.Student _studentInfo;
        protected CommonExchange.ScholarshipInformation _scholarshipInfo;

        private ErrorProvider _errProvidre;
        #endregion

        #region Class Constructors
        public StudentScholarship()
        {
            this.InitializeComponent();
        }

        public StudentScholarship(CommonExchange.SysAccess userInfo, ScholarshipLogic scholarshipManager)
        {
            this.InitializeComponent();

            _errProvidre = new ErrorProvider();

            _userInfo = userInfo;
            _scholarshipManager = scholarshipManager;

            this.Load += new EventHandler(ClassLoad);
            this.btnSearchScholarship.Click += new EventHandler(btnSearchScholarshipClick);
            this.btnSearchStudent.Click += new EventHandler(btnSearchStudentClick);
        }

        void IDisposable.Dispose()
        {
            if (pbxStudent.Image != null)
            {
                pbxStudent.Image.Dispose();
                pbxStudent.Image = null;

                pbxStudent.Dispose();
                pbxStudent = null;
            }

            GC.SuppressFinalize(this);
            GC.Collect();
        }

        #endregion

        #region Class Event Void Procedure
        //####################################CLASS StudentScholarship EVENTS####################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            _studentScholarshipInfo = new CommonExchange.StudentScholarship();
            _scholarshipInfo = new CommonExchange.ScholarshipInformation();
        }//--------------------
        //####################################END CLASS StudentScholarship EVENTS####################################

        //##################################BUTTON btnSearchStudent EVENTS##########################################################
        //event is raised when the control is clicked
        private void btnSearchStudentClick(object sender, EventArgs e)
        {
            using (StudentSearch frmSearch = new StudentSearch(_userInfo, _scholarshipManager, false, false))
            {
                frmSearch.ShowDialog(this);

                if (frmSearch.HasSelected)
                {
                    if (this.pbxStudent.Image != null)
                    {
                        this.pbxStudent.Image.Dispose();
                        this.pbxStudent.Image = null;
                    }

                    GC.SuppressFinalize(this);
                    GC.Collect();

                    _studentInfo = _scholarshipManager.GetDetailsStudentInformation(_userInfo, frmSearch.PrimaryId, Application.StartupPath, true);
                
                    this.lblStdFirstName.Text = _studentInfo.PersonInfo.FirstName;
                    this.lblStdLastName.Text = _studentInfo.PersonInfo.LastName;
                    this.lblStdStudentId.Text = _studentInfo.StudentId;
                    this.lblMiddleName.Text = _studentInfo.PersonInfo.MiddleName;

                    _studentScholarshipInfo.StudentEnrolmentLevelInfo.EnrolmentLevelSysId = _scholarshipManager.GetEnrolmentLevelSysId(_studentInfo.StudentSysId);

                    if (!String.IsNullOrEmpty(_studentInfo.PersonInfo.FilePath))
                    {
                        this.pbxStudent.Image = Image.FromFile(_studentInfo.PersonInfo.FilePath);
                    }
                }
            }           
        }//---------------------------------
        //##################################END BUTTON btnSearchStudent EVENTS##########################################################

        //##################################BUTTON btnSearchScholarship EVENTS##########################################################
        //event is raised when the control is clicked
        private void btnSearchScholarshipClick(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                using (StudentScholarshipSearchOnTextBoxList frmSearch = new StudentScholarshipSearchOnTextBoxList(_userInfo, _scholarshipManager))
                {
                    frmSearch.AdoptGridSize = true;
                    frmSearch.ShowDialog(this);

                    if (frmSearch.HasSelected)
                    {
                        _scholarshipInfo = _scholarshipManager.GetDetailsScholarshipInformation(frmSearch.PrimaryId);

                        _studentScholarshipInfo.ScholarshipInfo = _scholarshipInfo;
                       
                        this.lblCourseGroupDescription.Text = _scholarshipManager.GetCourseGroupDescription(_scholarshipInfo.CourseGroupInfo.CourseGroupId);
                        this.lblDepartmentDescription.Text = _scholarshipManager.GetDepartmentDescription(_scholarshipInfo.DepartmentInfo.DepartmentId);
                        this.lblScholarshipDescription.Text = _scholarshipInfo.ScholarshipDescription;
                        this.chkNonAcademic.Checked = _scholarshipInfo.IsNonAcademic;
                    }
                }

                this.Cursor = Cursors.Arrow;
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }
        }//-------------------------------
        //##################################END BUTTON btnSearchScholarship EVENTS##########################################################
        #endregion

        #region Programes-Defined Function
        //this fucntion will validate controls
        public Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvidre.SetError(this.lblScholarshipDescription, "");
            _errProvidre.SetError(this.btnSearchStudent, "");

            if (_studentInfo == null || String.IsNullOrEmpty(_studentInfo.StudentSysId))
            {
                _errProvidre.SetError(this.btnSearchStudent, "You must select a student.");
                _errProvidre.SetIconAlignment(this.btnSearchStudent, ErrorIconAlignment.MiddleLeft);

                isValid = false;
            }

            if (String.IsNullOrEmpty(_studentScholarshipInfo.ScholarshipInfo.ScholarshipSysId))
            {
                _errProvidre.SetError(this.lblScholarshipDescription, "You must select a scholarship.");
                _errProvidre.SetIconAlignment(this.lblScholarshipDescription, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            if (_scholarshipManager.IsExistsSysIDStudentScholarshipEnrolmentLevelStudentScholarship(_userInfo, _studentScholarshipInfo))
            {
                _errProvidre.SetError(this.lblScholarshipDescription, "Student scholarship already exist.");
                _errProvidre.SetIconAlignment(this.lblScholarshipDescription, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            return isValid;
        }
        #endregion
    }
}
