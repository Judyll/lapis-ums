using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RegistrarServices
{
    partial class MajorExamSchedule
    {
        #region Class Data Member Declaration
        protected CommonExchange.SysAccess _userInfo;
        protected CommonExchange.MajorExamSchedule _majorExamScheduleInfo;
        protected MajorExamScheduleLogic _majorExamScheduleManager;

        private DateTime _dateStart = DateTime.MinValue;
        private DateTime _dateEnd = DateTime.MinValue;
        private ErrorProvider _errProvider;
        #endregion

        #region Class Constructos
        public MajorExamSchedule()
        {
            this.InitializeComponent();
        }

        public MajorExamSchedule(CommonExchange.SysAccess userInfo, MajorExamScheduleLogic majorExamScheduleManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _majorExamScheduleManager = majorExamScheduleManager;

            _majorExamScheduleInfo = new CommonExchange.MajorExamSchedule();
            _errProvider = new ErrorProvider();

            this.Load += new EventHandler(ClassLoad);
            this.cboCourseGroup.SelectedIndexChanged += new EventHandler(cboCourseGroupSelectedIndexChanged);
            this.cboYear.SelectedIndexChanged += new EventHandler(cboYearSelectedIndexChanged);
            this.cboSemester.SelectedIndexChanged += new EventHandler(cboSemesterSelectedIndexChanged);
            this.cboExamDescription.SelectedIndexChanged += new EventHandler(cboExamDescriptionSelectedIndexChanged);
            this.txtExamDate.Validated += new EventHandler(txtExamDateValidated);
            this.lnkChangeDate.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkChangeDateLinkClicked);
        }
             
        #endregion

        #region Class Event Void Procedure
        //####################################################CLASS MajorExamSchedule EVENTS###############################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            _majorExamScheduleInfo = new CommonExchange.MajorExamSchedule();

            _majorExamScheduleManager.InitializeCourseGroupCombo(this.cboCourseGroup);
        }//-------------------------
        //####################################################END CLASS MajorExamSchedule EVENTS###############################################

        //####################################################COMBOBOX cboCourseGroup EVENTS###############################################
        //event is raised when the selected index is changed
        protected virtual void cboCourseGroupSelectedIndexChanged(object sender, EventArgs e)
        {
            _majorExamScheduleInfo.CourseGroupId = _majorExamScheduleManager.GetCourseGroupId(this.cboCourseGroup.SelectedIndex);
            _majorExamScheduleInfo.GroupDescription = _majorExamScheduleManager.GetCourseGroupDescription(this.cboCourseGroup.SelectedIndex);

            _majorExamScheduleManager.InitializeMajorExamInfoCombo(this.cboExamDescription, _majorExamScheduleInfo.CourseGroupId);

            _majorExamScheduleInfo.ExamInformationId = _majorExamScheduleInfo.ExamDescription = String.Empty;

            _majorExamScheduleManager.InitializeSchoolYearCombo(this.cboYear);

            if (_majorExamScheduleManager.IsSemestral(this.cboCourseGroup.SelectedIndex))
            {
                this.cboSemester.Enabled = true;

                _majorExamScheduleInfo.SemesterSysId = String.Empty;
            }
            else
            {
                this.cboSemester.Enabled = false;

                _majorExamScheduleManager.InitializeSchoolYearCombo(this.cboYear);

                _majorExamScheduleInfo.SemesterSysId = String.Empty;
            }
        }//---------------------
        //####################################################END COMBOBOX cboCourseGroup EVENTS###############################################

        //####################################################COMBOBOX cboYear EVENTS###############################################
        //event is raised when the selected index is changed
        protected virtual void cboYearSelectedIndexChanged(object sender, EventArgs e)
        {
            _majorExamScheduleManager.InitializeSemesterCombo(this.cboSemester, this.cboYear.SelectedIndex);

            _majorExamScheduleInfo.YearId = _majorExamScheduleManager.GetSchoolYearYearId(this.cboYear.SelectedIndex);

            _dateStart = _majorExamScheduleManager.GetSchoolYearDateStart(_majorExamScheduleInfo.YearId);
            _dateEnd = _majorExamScheduleManager.GetSchoolYearDateEnd(_majorExamScheduleInfo.YearId);
        }//-------------------
        //####################################################END COMBOBOX cboYear EVENTS###############################################

        //####################################################COMBOBOX cboSemester EVENTS###############################################
        //event is raised when the selected index is changed
        protected virtual void cboSemesterSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboSemester.SelectedIndex != -1)
            {
                _majorExamScheduleInfo.SemesterSysId = _majorExamScheduleManager.GetSemesterSystemId(this.cboYear.SelectedIndex, this.cboSemester.SelectedIndex);

                _dateStart = _majorExamScheduleManager.GetSemesterDateStart(_majorExamScheduleInfo.SemesterSysId);
                _dateEnd = _majorExamScheduleManager.GetSemesterDateEnd(_majorExamScheduleInfo.SemesterSysId);
            }
        }//---------------------
        //####################################################END COMBOBOX cboSemester EVENTS###############################################

        //####################################################COMBOBOX cboExamDescription EVENTS###############################################
        //event is raised when the selected index is changed
        private void cboExamDescriptionSelectedIndexChanged(object sender, EventArgs e)
        {
            _majorExamScheduleInfo.ExamInformationId = _majorExamScheduleManager.GetExamInformationIdDescription(this.cboExamDescription.SelectedIndex, 
                _majorExamScheduleInfo.CourseGroupId, true);
            _majorExamScheduleInfo.ExamDescription = _majorExamScheduleManager.GetExamInformationIdDescription(this.cboExamDescription.SelectedIndex,
                _majorExamScheduleInfo.CourseGroupId, false);
        }//---------------------
        //####################################################END COMBOBOX cboExamDescription EVENTS###############################################

        //####################################################TEXTBOX txtExamDate EVENTS###############################################
        //event is raised when the selected index is changed
        private void txtExamDateValidated(object sender, EventArgs e)
        {
            _majorExamScheduleInfo.ExamDate = RemoteClient.ProcStatic.TrimStartEndString(this.txtExamDate.Text);
        }//----------------------
        //####################################################END TEXTBOX txtExamDate EVENTS###############################################

        //####################################################TEXTBOX txtExamDate EVENTS###############################################
        //event is raised when the selected index is changed
        private void lnkChangeDateLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            DateTime eDate = DateTime.MinValue;

            if (String.IsNullOrEmpty(_majorExamScheduleInfo.ExamDate))
            {
                eDate = DateTime.Parse(_majorExamScheduleManager.ServerDateTime);
            }
            else
            {
                eDate = DateTime.Parse(_majorExamScheduleInfo.ExamDate);
            }

            using (RemoteClient.DatePicker frmPicker = new RemoteClient.DatePicker(eDate))
            {
                frmPicker.ShowDialog(this);

                if (frmPicker.HasSelectedDate)
                {
                    if (DateTime.TryParse(frmPicker.GetSelectedDate.ToLongDateString() + " " +
                        DateTime.Parse(_majorExamScheduleManager.ServerDateTime).ToLongTimeString(), out eDate))
                    {
                        _majorExamScheduleInfo.ExamDate = eDate.ToShortDateString() + " 12:00:00 AM";
                    }

                    this.txtExamDate.Text = eDate.ToLongDateString();
                }
            }

            this.Cursor = Cursors.Arrow;
        }//-------------------------
        //####################################################END TEXTBOX txtExamDate EVENTS###############################################
        #endregion

        #region Programer-Defined Void Procedures
        //this procedure will determine if the record is locked
        public void IsRecordLocked(Label lblStatus, Button btnCreateUpdate, Button btnDelete, Boolean isCreate)
        {
            if (RemoteClient.ProcStatic.IsRecordLocked(_dateStart, _dateEnd, DateTime.Parse(_majorExamScheduleManager.ServerDateTime),
                (Int32)CommonExchange.SystemRange.MonthAllowance))
            {
                lblStatus.Text = "This record is LOCKED";

                this.pbxLocked.Visible = true;
                this.pbxUnlock.Visible = false;

                if (isCreate)
                {
                    btnCreateUpdate.Visible = false;
                }
                else
                {
                    btnDelete.Visible = btnCreateUpdate.Visible = false;
                }
            }
            else
            {
                lblStatus.Text = "This record is OPEN";

                this.pbxLocked.Visible = false;
                this.pbxUnlock.Visible = true;

                if (isCreate)
                {
                    btnCreateUpdate.Visible = true;
                }
                else
                {
                    btnDelete.Visible = btnCreateUpdate.Visible = true;
                }
            }

        }//------------------------

        #endregion

        #region Programer-Defined Functions
        //this procedure will validate controls
        public Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.cboYear, "");
            _errProvider.SetError(this.cboSemester, "");
            _errProvider.SetError(this.cboExamDescription, "");
            _errProvider.SetError(this.txtExamDate, "");

            if (String.IsNullOrEmpty(_majorExamScheduleInfo.YearId))
            {
                _errProvider.SetError(this.cboYear, "You must select a school year.");
                _errProvider.SetIconAlignment(this.cboYear, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            if (!String.IsNullOrEmpty(_majorExamScheduleInfo.CourseGroupId))                 
            {
                if (_majorExamScheduleManager.IsSemestral(this.cboCourseGroup.SelectedIndex) && String.IsNullOrEmpty(_majorExamScheduleInfo.SemesterSysId))
                {
                    _errProvider.SetError(this.cboSemester, "You must select a semester.");
                    _errProvider.SetIconAlignment(this.cboSemester, ErrorIconAlignment.MiddleRight);

                    isValid = false;
                }
            }

            if (String.IsNullOrEmpty(_majorExamScheduleInfo.ExamInformationId))
            {
                _errProvider.SetError(this.cboExamDescription, "You must select a examination information.");
                _errProvider.SetIconAlignment(this.cboExamDescription, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            if (String.IsNullOrEmpty(_majorExamScheduleInfo.ExamDate))
            {
                _errProvider.SetError(this.txtExamDate, "You must create a examination schedule date.");
                _errProvider.SetIconAlignment(this.txtExamDate, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }      

            if (isValid)
            {
                DateTime inputDate = DateTime.Parse(_majorExamScheduleManager.ServerDateTime);
             
                if (!String.IsNullOrEmpty(_majorExamScheduleInfo.ExamDate) && DateTime.TryParse(_majorExamScheduleInfo.ExamDate, out inputDate))
                {
                    if (!_majorExamScheduleManager.IsValidDate(_dateStart, _dateEnd, inputDate))
                    {
                        _errProvider.SetError(this.txtExamDate, "Invalid examination date.");
                        _errProvider.SetIconAlignment(this.txtExamDate, ErrorIconAlignment.MiddleRight);

                        isValid = false;
                    }
                }

                if (_majorExamScheduleManager.IsExistsYearSemesterIDExamDateInformationIDExamSchedule(_userInfo, _majorExamScheduleInfo))
                {
                    _errProvider.SetError(this.cboExamDescription, "The examination description/date already exist.");
                    _errProvider.SetIconAlignment(this.cboExamDescription, ErrorIconAlignment.MiddleRight);

                    isValid = false;
                }
            }
            
            return isValid;
        }//-------------------
        #endregion       
    }
}
