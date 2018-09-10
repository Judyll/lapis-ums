using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FinanceServices
{
    partial class StudentEnrolmentHistory
    {
        #region Class Constructors
        public StudentEnrolmentHistory(CommonExchange.SysAccess userInfo, StudentLogic studentManager, CommonExchange.Student studentInfo, Boolean isForRegistrar)
            : base(userInfo, studentManager, isForRegistrar)
        {
            this.InitializeComponent();

            _studentInfo = studentInfo;

            this.btnClose.Click += new EventHandler(btnCloseClick);
        }        
        #endregion

        #region Class Event Void Procedures
        protected override void ClassLoad(object sender, EventArgs e)
        {
            _studentManager.SelectBySysIDStudentForEnrolmentHistoryEnrolmentCourseLevel(_userInfo, _studentInfo.StudentSysId);

            _studentManager.InitializeTreeViewControl(_userInfo, this.trvStudentEnrolment);

            this.txtStudentId.Text = _studentInfo.StudentId;
            this.txtStudentLastName.Text = _studentInfo.PersonInfo.LastName;
            this.txtStudentFirstName.Text = _studentInfo.PersonInfo.FirstName;
            this.txtMiddleName.Text = _studentInfo.PersonInfo.MiddleName;
            this.txtScholarship.Text = _studentInfo.Scholarship;
            this.chkIsInternational.Checked = _studentInfo.IsInternational;

            if (!String.IsNullOrEmpty(_studentInfo.PersonInfo.FilePath))
            {
                this.pbxStudent.Image = Image.FromFile(_studentInfo.PersonInfo.FilePath);
            }

            this.gbxEnrolmentInfo.Enabled = this.trvStudentEnrolment.Enabled = true;
        }

        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
