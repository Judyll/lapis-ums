using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class StudentScholarshipUpdate
    {
        #region Class Data Member Declaration
        private CommonExchange.StudentScholarship _studentScholarshipInfoTemp;
        #endregion

        #region Class Properties Declaration
        private Boolean _hasUpDated = false;
        public Boolean HasUpDated
        {
            get { return _hasUpDated; }
        }

        private Boolean _hasDeleted = false;
        public Boolean HasDeleted
        {
            get { return _hasDeleted; }
        }
        #endregion

        #region Class Constructor
        public StudentScholarshipUpdate(CommonExchange.SysAccess userInfo, CommonExchange.Student studentInfo,
            CommonExchange.StudentScholarship studentScholarshipInfo, ScholarshipLogic scholarshipManager, Boolean isRecordLocked)
            : base(userInfo, scholarshipManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _studentInfo = studentInfo;
            _studentScholarshipInfo = studentScholarshipInfo;
            _studentScholarshipInfoTemp = (CommonExchange.StudentScholarship)studentScholarshipInfo.Clone();
            _scholarshipManager = scholarshipManager;
            
            if (isRecordLocked)
            {
                this.lblStatus.Text = "This record is LOCKED";

                this.btnEdit.Visible = this.btnDelete.Visible = this.btnSearchScholarship.Visible = false;
            }
            else
            {
                this.lblStatus.Text = "This record is OPEN";

                this.btnEdit.Visible = this.btnDelete.Visible = this.btnSearchScholarship.Visible = true;
            }

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnEdit.Click += new EventHandler(btnEditClick);
            this.btnDelete.Click += new EventHandler(btnDeleteClick); 
        }
        #endregion

        //####################################CLASS StudentScholarshipUpdate EVENTS####################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.btnSearchStudent.Visible = false;

            this.lblSysID.Text = _studentScholarshipInfo.StudentScholarshipSysId;
            this.lblStdFirstName.Text = _studentInfo.PersonInfo.FirstName;
            this.lblStdLastName.Text = _studentInfo.PersonInfo.LastName;
            this.lblStdStudentId.Text = _studentInfo.StudentId;
            this.lblMiddleName.Text = _studentInfo.PersonInfo.MiddleName;
                        
            if (!String.IsNullOrEmpty(_studentInfo.PersonInfo.FilePath))
            {
                this.pbxStudent.Image = Image.FromFile(_studentInfo.PersonInfo.FilePath);
            }

            _scholarshipInfo = _scholarshipManager.GetDetailsScholarshipInformation(_studentScholarshipInfo.ScholarshipInfo.ScholarshipSysId);

            this.lblCourseGroupDescription.Text = _scholarshipManager.GetCourseGroupDescription(_scholarshipInfo.CourseGroupInfo.CourseGroupId);
            this.lblDepartmentDescription.Text = _scholarshipManager.GetDepartmentDescription(_scholarshipInfo.DepartmentInfo.DepartmentId);
            this.lblScholarshipDescription.Text = _studentScholarshipInfo.ScholarshipInfo.ScholarshipDescription;
            this.chkNonAcademic.Checked = _studentScholarshipInfo.ScholarshipInfo.IsNonAcademic;
        }//----------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if ((!_hasUpDated || !_hasDeleted) && !_studentScholarshipInfo.Equals(_studentScholarshipInfoTemp))
            {
                String strMsg = "There has been changes made in the current student scholarship information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";

                DialogResult msgResutl = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResutl == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//-----------------------
        //####################################CLASS StudentScholarshipUpdate EVENTS####################################

        //###################################BUTTON btnClose EVENTS####################################
        //event is raised when the the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//----------------------------
        //###################################BUTTON btnClose EVENTS####################################        

        //###################################BUTTON btnEdit EVENTS####################################
        //event is raised when the control is clicked
        private void btnEditClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to update the student scholarship information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student scholarship information has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _scholarshipManager.UpdateStudentScholarshipInformation(_userInfo, _studentScholarshipInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpDated = true;

                        this.Close();
                    }
                    else if (msgResult == DialogResult.Cancel)
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Updating");
                }
            }
        }//-----------------------
        //###################################END BUTTON btnEdit EVENTS####################################

        //###################################BUTTON btnDelete EVENTS####################################
        //event is raised when the the control is clicked
        private void btnDeleteClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to delete the student scholarship information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student scholarship information has been successfully deleted.";

                        this.Cursor = Cursors.WaitCursor;

                        _scholarshipManager.DeleteStudentScholarshipInformation(_userInfo, _studentScholarshipInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasDeleted = true;

                        this.Close();
                    }
                    else if (msgResult == DialogResult.Cancel)
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Updating");
                }
            }
        }//-------------------------
        //###################################END BUTTON btnDelete EVENTS####################################
    }
}


