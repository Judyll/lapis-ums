using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class StudentCashierUpdate
    {
        #region Class General Variable Declaration
        private CommonExchange.Student _studentInfoTemp;
        #endregion

        #region Class Properties Declaration
        private Boolean _hasUpDated = false;
        public Boolean HasUpDated
        {
            get { return _hasUpDated; }
        }

        private Boolean _fromCashiering;
        public Boolean FromCashiering
        {
            get { return _fromCashiering; }
        }

        private DataTable _studentTable;
        public DataTable StudentTable
        {
            get { return _studentTable; }
        }
        #endregion

        #region Class Constructor
        public StudentCashierUpdate(CommonExchange.SysAccess userInfo, CommonExchange.Student studentInfo,
            StudentLogic studentManager, Boolean isForRegistrar, Boolean fromCashiering, ref DataTable studentTable)
            : base(userInfo, studentManager, isForRegistrar)
        {
            this.InitializeComponent();

            _studentInfo = studentInfo;
            _studentInfo.ObjectState = System.Data.DataRowState.Modified;
            _studentInfoTemp = (CommonExchange.Student)_studentInfo.Clone();

            _fromCashiering = fromCashiering;
            _studentTable = studentTable;

            this.FormClosing += new FormClosingEventHandler(StudentCashierUpdateFormClosing);

            this.btnClose.Click += new EventHandler(btnCloseClick);         
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);
        }

        #endregion

        #region Class Event Void procedures
        //########################################CLASS ClassroomUpdate EVENTS####################################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            _studentManager.InitializeStudentEnrolmentCourseLevelTable(_userInfo, _studentInfo.StudentSysId);
          
            _studentSysId = _studentInfo.StudentSysId;

            this.txtStudentId.Text = _studentInfo.StudentId;
            this.txtStudentLastName.Text = _studentInfo.PersonInfo.LastName;
            this.txtStudentFirstName.Text = _studentInfo.PersonInfo.FirstName;
            this.txtMiddleName.Text = _studentInfo.PersonInfo.MiddleName;
            this.txtScholarship.Text = _studentInfo.Scholarship;
            this.chkIsInternational.Checked = _studentInfo.IsInternational;
            this.chkRequiredDownPayment.Checked = _studentInfo.IsNoDownpaymentRequired;

            this.gbxEnrolmentInfo.Enabled = !String.IsNullOrEmpty(_studentInfo.StudentSysId) ? true : false;

            if (RemoteServerLib.ProcStatic.IsSystemAccessCollegeRegistrar(_userInfo))
            {
                _studentManager.InitializeTreeViewControl(this.trvStudentEnrolment, null, null, null, null, _hasGenerateStudentId, _courseGroupId);

                this.lnkGenerateStudentId.Enabled = this.chkIsInternational.Enabled = this.chkRequiredDownPayment.Enabled = false;
            }
            else
            {
                _studentManager.InitializeTreeViewControl(this.trvStudentEnrolment, this.mnuCreateCourse,
                    this.mnuUpdateCourse, this.mnuDelete, this.mnuCreateEntryLevel, _hasGenerateStudentId, _courseGroupId);
            }

            if (!String.IsNullOrEmpty(_studentInfo.PersonInfo.FilePath))
            {
                this.pbxStudent.Image = Image.FromFile(_studentInfo.PersonInfo.FilePath);
            }

            this.lnkPersonArchive.Visible = this.lnkVerify.Enabled = false;

        }//--------------------

        //event is raised when the class is closing
        private void StudentCashierUpdateFormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (!_isForUpdateStudent)
            {
                if ((!_hasUpDated && !_studentInfo.Equals(_studentInfoTemp)) || _hasUpdatedCourseLevel)
                {
                    String strMsg = "There has been changes made in the current student information. \nExiting will not save this changes." +
                                    "\n\nAre you sure you want to exit?";

                    DialogResult msgResutl = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResutl == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        _studentManager.ClearCachedData();
                    }
                }
                else
                {
                    _studentManager.ClearCachedData();
                }
            }
        }//--------------------
        //########################################END CLASS ClassroomUpdate EVENTS####################################################

        //#########################################BUTTON btnClose EVENTS##################################################
        //event is raised when the button is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//-------------------
        //#########################################END BUTTON btnClose EVENTS##################################################

        //Disable Verify Existence if the function is for update student
        ////########################################TEXTBOX txtName EVENTS##################################################
        ////event is raised when the key is pressed
        //protected override void textBoxKeyPress(object sender, KeyPressEventArgs e)
        //{
        //    base.textBoxKeyPress(sender, e);

        //    this.btnUpdate.Enabled = _isVerified;
        //}//-------------------------
        ////########################################END TEXTBOX txtName EVENTS##################################################

        //Disable Verify Existence if the function is for update student
        ////########################################LINKLABEL lnkVerify EVENTS##################################################
        ////event is raised when the linked is clicked
        //protected override void lnkVerifyLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    base.lnkVerifyLinkClicked(sender, e);

        //    this.btnUpdate.Enabled = _isVerified;
        //}//----------------------
        ////########################################END LINKLABEL lnkVerify EVENTS##################################################

        //########################################LINKLABEl lnkUpdateStudentEntryLevel EVENTS#####################################################       
        //event is raised when the control is clicked
        protected override void lnkUpdateStudentEntryLevelClick(object sender, EventArgs e)
        {
            base.lnkUpdateStudentEntryLevelClick(sender, e);

            if (_hasDeletedEntryLevel)
            {
                this.btnUpdate.Enabled = false;
            }
        }//----------------------
        //########################################END LINKLABEl lnkUpdateStudentEntryLevel EVENTS#####################################################

        //########################################LINKLABEL lnkStudentEntryLevel EVENTS#####################################################
        //event is raised when the is clicked
        protected override void lnkCreateStudentEntryLevelClick(object sender, EventArgs e)
        {
            base.lnkCreateStudentEntryLevelClick(sender, e);

            if (_hasAddEntryLevel)
            {
                this.btnUpdate.Enabled = true;
            }
        }//-----------------------
        //########################################END LINKLABEL lnkStudentEntryLevel EVENTS#####################################################

        //########################################LINKLABEL lnkCreateCourse EVENTS#####################################################
        //event is raised when the control is clicked
        protected override void lnkCreateCourseClick(object sender, EventArgs e)
        {
            base.lnkCreateCourseClick(sender, e);

            if (_hasUpdatedCourseLevel)
            {
                this.btnUpdate.Enabled = true;
            }
        }//--------------------
        //########################################END LINKLABEL lnkCreateCourse EVENTS#####################################################

        //########################################LINKLABEL lnkUpdateCourse EVENTS#####################################################
        //event is raised when the control is clicked
        protected override void lnkUpdateCourseClick(object sender, EventArgs e)
        {
            base.lnkUpdateCourseClick(sender, e);

            if (_hasUpdatedCourseLevel)
            {
                this.btnUpdate.Enabled = true;
            }
        }//--------------------
        //########################################END LINKLABEL lnkUpdateCourse EVENTS#####################################################

        //#########################################BUTTON btnUpdate EVENTS#####################################################
        //event is raised when the button is clicked
        private void btnUpdateClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to update the student information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student information has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _studentInfo.PersonInfo.ObjectState = System.Data.DataRowState.Modified;

                        _studentManager.UpdateStudentInformation(_userInfo, _studentInfo, _fromCashiering, ref _studentTable);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpDated = true;
                        _hasUpdatedCourseLevel = false;

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
        }//----------------------
        //###########################################END BUTTON btnUpdate EVENTS#####################################################
        #endregion
    }
}
