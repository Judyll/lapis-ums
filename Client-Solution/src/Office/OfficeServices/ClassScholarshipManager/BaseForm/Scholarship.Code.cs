using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class Scholarship
    {
        #region Class Data Member Declearatioin
        protected CommonExchange.SysAccess _userInfo;
        protected CommonExchange.ScholarshipInformation _scholarshipInfo;
        protected ScholarshipLogic _scholarshipManager;

        private ErrorProvider _errProvider;
        #endregion

        #region Class Constructor
        public Scholarship()
        {
            this.InitializeComponent();
        }

        public Scholarship(CommonExchange.SysAccess userInfo, ScholarshipLogic scholarshipManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _scholarshipManager = scholarshipManager;

            _errProvider = new ErrorProvider();

            this.Load += new EventHandler(ClassLoad);
            this.cboCourseGroup.SelectedIndexChanged += new EventHandler(cboCourseGroupSelectedIndexChanged);
            this.cboDepartment.SelectedIndexChanged += new EventHandler(cboDepartmentSelectedIndexChanged);
            this.chkNonAcademic.CheckedChanged += new EventHandler(chkNonAcademicCheckedChanged);
            this.txtScholarship.Validated += new EventHandler(txtScholarshipValidated);
        }
       
        #endregion

        #region Class Event Void Procedure
        //###############################################CLASS Scholarship EVENTS##################################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            _scholarshipInfo = new CommonExchange.ScholarshipInformation();

            _scholarshipManager.InitializeCourseGroupCombo(this.cboCourseGroup);
            _scholarshipManager.InitializeDepartmentCombo(this.cboDepartment);
        }//---------------------
        //###############################################END CLASS Scholarship EVENTS##################################################

        //###############################################COMBOBOX cboCourseGroup EVENTS##################################################
        //event is raised when the selected index is changed
        private void cboCourseGroupSelectedIndexChanged(object sender, EventArgs e)
        {
            _scholarshipInfo.CourseGroupInfo = _scholarshipManager.GetCourseGroupInformationDetails(this.cboCourseGroup.SelectedIndex);
        }//-------------------
        //###############################################END COMBOBOX cboCourseGroup EVENTS##################################################

        //###############################################COMBOBOX cboDepartment EVENTS##################################################
        //event is raised when the selected index is changed
        private void cboDepartmentSelectedIndexChanged(object sender, EventArgs e)
        {
            _scholarshipInfo.DepartmentInfo = _scholarshipManager.GetDepartmentInfo(this.cboDepartment.SelectedIndex);           
        }//-------------------
        //###############################################END COMBOBOX cboDepartment EVENTS##################################################

        //###############################################CHECKEDBOX chkNonAcademinct EVENTS##################################################
        //event is raised when the checked is changed
        private void chkNonAcademicCheckedChanged(object sender, EventArgs e)
        {
            _scholarshipInfo.IsNonAcademic = this.chkNonAcademic.Checked;
        }//-----------------
        //###############################################END CHECKEDBOX chkNonAcademinc EVENTS##################################################

        //###############################################TEXTBOX txtScholarship EVENTS##################################################
        //event is raised when the control is validated
        private void txtScholarshipValidated(object sender, EventArgs e)
        {
            _scholarshipInfo.ScholarshipDescription = RemoteClient.ProcStatic.TrimStartEndString(this.txtScholarship.Text);
        }//---------------------
        //###############################################END TEXTBOX txtScholarship EVENTS##################################################
        #endregion

        #region Programer-Defined Fucntions
        //this fucntion will validate controls
        public Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.cboCourseGroup, "");
            _errProvider.SetError(this.cboDepartment, "");
            _errProvider.SetError(this.txtScholarship, "");

            if (String.IsNullOrEmpty(_scholarshipInfo.CourseGroupInfo.CourseGroupId))
            {
                _errProvider.SetError(this.cboCourseGroup, "You must select a course group.");
                _errProvider.SetIconAlignment(this.cboCourseGroup, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            if (String.IsNullOrEmpty(_scholarshipInfo.DepartmentInfo.DepartmentId))
            {
                _errProvider.SetError(this.cboDepartment, "You must select a department.");
                _errProvider.SetIconAlignment(this.cboDepartment, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            if (String.IsNullOrEmpty(_scholarshipInfo.ScholarshipDescription))
            {
                _errProvider.SetError(this.txtScholarship, "You must select create a scholarship description.");
                _errProvider.SetIconAlignment(this.txtScholarship, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            if (isValid && _scholarshipManager.IsExistsScholarshipDescriptionScholarshipInformation(_userInfo, _scholarshipInfo))
            {
                _errProvider.SetError(this.txtScholarship, "Scholarship description already exist.");
                _errProvider.SetIconAlignment(this.txtScholarship, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            return isValid;
        }//-----------------------
        #endregion
    }
}
