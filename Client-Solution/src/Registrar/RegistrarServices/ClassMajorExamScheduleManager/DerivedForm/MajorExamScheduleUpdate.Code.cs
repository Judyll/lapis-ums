using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RegistrarServices
{
    partial class MajorExamScheduleUpdate
    {
        #region Class Data Member Declaration
        private CommonExchange.MajorExamSchedule _majorExamScheduleInfoTemp;
        #endregion

        #region Class Properties Declarations
        private Boolean _hasUpDated = false;
        public Boolean HasUpated
        {
            get { return _hasUpDated; }
        }

        private Boolean _hasDeleted = false;
        public Boolean HasDeleted
        {
            get { return _hasDeleted; }
        }
        #endregion

        #region Class Constructors
        public MajorExamScheduleUpdate(CommonExchange.SysAccess userInfo, CommonExchange.MajorExamSchedule majorExamScheduleInfo,
            MajorExamScheduleLogic majorExamScheduleManager)
            : base(userInfo, majorExamScheduleManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _majorExamScheduleInfo =  majorExamScheduleInfo;
            _majorExamScheduleInfoTemp = (CommonExchange.MajorExamSchedule)majorExamScheduleInfo.Clone();

            _majorExamScheduleManager = majorExamScheduleManager;

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);
            this.btnDelete.Click += new EventHandler(btnDeleteClick);
        }
        #endregion

        #region Class Event Void Procedure
        //####################################################CLASS MajorExamScheduleCreate EVENTS###############################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.lblSysID.Text = _majorExamScheduleInfo.MajorExamId.ToString();


            this.cboCourseGroup.SelectedIndexChanged -= new EventHandler(cboCourseGroupSelectedIndexChanged);

            _majorExamScheduleManager.InitializeCourseGroupCombo(this.cboCourseGroup, _majorExamScheduleInfo.CourseGroupId);
            _majorExamScheduleManager.InitializeSchoolYearCombo(this.cboYear, _majorExamScheduleInfo.YearId);
            _majorExamScheduleManager.InitializeSemesterCombo(this.cboSemester, _majorExamScheduleInfo.SemesterSysId, _majorExamScheduleInfo.YearId);
            _majorExamScheduleManager.InitializeMajorExamInfoCombo(this.cboExamDescription, _majorExamScheduleInfo.CourseGroupId,
                _majorExamScheduleInfo.ExamInformationId);

            this.cboCourseGroup.SelectedIndexChanged += new EventHandler(cboCourseGroupSelectedIndexChanged);

            this.cboSemester.Enabled = _majorExamScheduleManager.IsSemestral(this.cboCourseGroup.SelectedIndex) ? true : false;          

            DateTime eDate;

            if (DateTime.TryParse(_majorExamScheduleInfo.ExamDate, out eDate))
            {
                this.txtExamDate.Text = eDate.ToLongDateString();
            }
        }//-------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasUpDated && !_hasDeleted && !_majorExamScheduleInfo.Equals(_majorExamScheduleInfoTemp))
            {
                String strMsg = "There has been changes made in the current examination schedule. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";

                DialogResult msgResutl = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResutl == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
        //####################################################END CLASS MajorExamScheduleCreate EVENTS###############################################

        //####################################################COMBOBOX cboYear EVENTS###############################################
        //event is raised when the selected index is changed
        protected override void cboYearSelectedIndexChanged(object sender, EventArgs e)
        {
            base.cboYearSelectedIndexChanged(sender, e);

            this.IsRecordLocked(this.lblStatus, this.btnUpdate, this.btnDelete, false);
        }//---------------------------
        //####################################################END COMBOBOX cboYear EVENTS###############################################

        //####################################################COMBOBOX cboSemester EVENTS###############################################
        //event is raised when the selected index is changed
        protected override void cboSemesterSelectedIndexChanged(object sender, EventArgs e)
        {
            base.cboSemesterSelectedIndexChanged(sender, e);

            this.IsRecordLocked(this.lblStatus, this.btnUpdate, this.btnDelete, false);
        }//-------------------------
        //####################################################END COMBOBOX cboSemester EVENTS###############################################

        //####################################################BUTTON btnClose EVENTS###############################################
        //event is raised when the selected index is changed
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//---------------------------
        //####################################################END BUTTON btnClose EVENTS###############################################}

        //####################################################BUTTON btnUpdate EVENTS###############################################
        //event is raised when the control is clicked
        private void btnUpdateClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateControls())
                {
                    String strMsg = "Are you sure you want to update the examination schedule?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The examination schedule has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _majorExamScheduleManager.UpdateMajorExamSchedule(_userInfo, _majorExamScheduleInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpDated = true;

                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Updating");
            }
        }//-------------------------
        //####################################################END BUTTON btnUpdate EVENTS###############################################

        //####################################################BUTTON btnDelete EVENTS###############################################
        //event is raised when the control is clicked
        private void btnDeleteClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateControls())
                {
                    String strMsg = "Marking a major exam schedule information as deleted might affect the following:" +
                               "\n\n1.) The system inventory." +
                               "\n2.) The student's statement of account printing date." +
                               "\n\nAre you sure you want to mark as deleted the major exam schedule information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Mark As Deleted", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "Are you sure you want to delete the examination schedule?";

                        msgResult = MessageBox.Show(strMsg, "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                        if (msgResult == DialogResult.Yes)
                        {
                            strMsg = "The examination schedule has been successfully deleted.";

                            this.Cursor = Cursors.WaitCursor;

                            _majorExamScheduleManager.DeleteMajorExamSchedule(_userInfo, _majorExamScheduleInfo);

                            this.Cursor = Cursors.Arrow;

                            MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                            _hasDeleted = true;

                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Updating");
            }
        }//-------------------------
        //####################################################END BUTTON btnDelete EVENTS###############################################

        #endregion

      
    }
}
