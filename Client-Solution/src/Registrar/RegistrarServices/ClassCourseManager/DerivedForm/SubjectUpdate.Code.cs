using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RegistrarServices
{
    partial class SubjectUpdate
    {
        #region Class General Variable Declarations
        private CommonExchange.SubjectInformation _subjectInfoTemp;
        #endregion

        #region Class Properties Declarations
        private Boolean _hasUpdated = false;
        public Boolean HasUpdated
        {
            get { return _hasUpdated; }
        }
        #endregion

        #region Class Constructor
        public SubjectUpdate(CommonExchange.SysAccess userInfo, CommonExchange.SubjectInformation subjectInfo,
                                    CourseLogic courseManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _subjectInfo = subjectInfo;
            _subjectInfoTemp = (CommonExchange.SubjectInformation)subjectInfo.Clone();
            _courseManager = courseManager;

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);
        }
        #endregion

        #region Class Event Void Procedures

        //########################################CLASS ClassroomUpdate EVENTS####################################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            _courseManager.InitializeDepartmentCombo(this.cboDepartment, _subjectInfo.DepartmentInfo.DepartmentId);

            _courseManager.InitializeSubjectCategoryCombo(this.cboSubjectCategory, _subjectInfo.CategoryInfo.CategoryId);

            this.txtCode.Text = _subjectInfo.SubjectCode;
            this.txtTitle.Text = _subjectInfo.DescriptiveTitle;

            this.chkNonAcademic.Checked = _subjectInfo.IsNonAcademic;

            _courseManager.InitializeCourseGroupCombo(this.cboCourseGroup, _subjectInfo.CourseGroupInfo.CourseGroupId);

            this.cboCourseGroup.Enabled = false;

            this.txtLecture.Text = _subjectInfo.LectureUnits.ToString();
            this.txtLaboratory.Text = _subjectInfo.LabUnits.ToString();
            this.chkNonAcademic.Checked = _subjectInfo.IsNonAcademic;
            this.chkIsOpenAccess.Checked = _subjectInfo.IsOpenAccess;

            Int32 hours = 0, minutes = 0, count = 1;

            if (!String.IsNullOrEmpty(_subjectInfo.NoHours))
            {
                String[] strSplit = _subjectInfo.NoHours.Split(':');

                foreach (String value in strSplit)
                {
                    if (!String.IsNullOrEmpty(value))
                    {
                        if (count == 1)
                        {
                            hours = Int32.Parse(value);
                        }
                        else
                        {
                            minutes = Int32.Parse(value);
                        }
                    }

                    count++;
                }
            }

            this.hrmHours.SetHoursMinutes(hours, minutes);
            //this.hrmHours.SetHoursMinutes(DateTime.Parse(_subjectInfo.NoHours));

            this.dgvList.DataSource = _courseManager.GetBySubjectIdSubjectPrerequisiteTable(_userInfo, _subjectInfo.SubjectSysId);

            RemoteClient.ProcStatic.SetDataGridViewColumns(this.dgvList, false);

            if (!this.hrmHours.IsHourMinuteZero())
            {
                this.optHours.Checked = true;
                this.optUnits.Checked = false;
            }
            else
            {
                this.optHours.Checked = false;
                this.optUnits.Checked = true;
            }

            this.lnkRemove.Enabled = false;

        } //----------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasUpdated && (!_subjectInfo.Equals(_subjectInfoTemp) || _courseManager.HasPreRequisiteListChanges()))
            {
                String strMsg = "There has been changes made in the current subject information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        } //----------------------------------
        //######################################END CLASS ClassroomUpdate EVENTS##################################################

        //#########################################BUTTON btnClose EVENTS##################################################
        //event is raised when the button is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        } //------------------------------------------
        //#######################################END BUTTON btnClose EVENTS#################################################

        //###########################################BUTTON btnUpdate EVENTS#####################################################
        //event is raised when the button is clicked
        private void btnUpdateClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to update the subject information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The subject information has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _courseManager.UpdateSubjectInformation(_userInfo, _subjectInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdated = true;

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
        }
        //##########################################END BUTTON btnUpdate EVENTS##################################################
        #endregion

    }
}
