using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace OfficeServices
{
    partial class SubjectScheduleDetails
    {
        #region Class General Variable Declaration
        protected CommonExchange.SysAccess _userInfo;
        protected CommonExchange.ScheduleInformation _schedInfo;
        protected CommonExchange.ScheduleInformationDetails _schedDetailsInfo;
        protected SubjectSchedulingLogic _scheduleManager;

        protected Int32[][][] _tFrames;
        protected Int32 _noOfDaysDisplayed;
        protected Int32 _noOfTimeSlotsDisplayed;
        protected Int32 _readOnlyIndex;
        protected Int32 _selectedIndex;
        protected Int32 _selectedValue;
        protected Int32 _readOnlyValue;
        protected Boolean _hasErrors;
        protected Boolean _isForUpdate = false;
        protected Boolean _hasClickEdit = false;
             
        private ErrorProvider _errProvider;
        #endregion
        
        #region Class Constructor
        public SubjectScheduleDetails()
        {
            this.InitializeComponent();
        }

        public SubjectScheduleDetails(CommonExchange.SysAccess userInfo, SubjectSchedulingLogic scheduleManager, CommonExchange.ScheduleInformation schedInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _schedInfo = schedInfo;
            _scheduleManager = scheduleManager;

            _errProvider = new ErrorProvider();

            this.Load += new EventHandler(ClassLoad);
            this.optField.CheckedChanged += new EventHandler(optFieldCheckedChanged);
            this.optTBA.CheckedChanged += new EventHandler(optTBACheckedChanged);
            this.optCampus.CheckedChanged += new EventHandler(optCampusCheckedChanged);
            this.optUnits.CheckedChanged += new EventHandler(optUnitsHoursCheckedChanged);
            this.optHours.CheckedChanged += new EventHandler(optUnitsHoursCheckedChanged);
            this.txtSection.Validated += new EventHandler(txtSectionValidated);
            this.txtFieldRoom.Validated += new EventHandler(txtFieldRoomValidated);
            this.txtLaboratory.KeyPress += new KeyPressEventHandler(UnitsKeyPress);
            this.txtLecture.KeyPress += new KeyPressEventHandler(UnitsKeyPress);
            this.txtLaboratory.Validating += new System.ComponentModel.CancelEventHandler(UnitsValidating);
            this.txtLecture.Validating += new System.ComponentModel.CancelEventHandler(UnitsValidating);
            this.txtLecture.Validated += new EventHandler(txtLectureValidated);
            this.txtLaboratory.Validated += new EventHandler(txtLaboratoryValidated);
            this.hrmHours.Validated += new EventHandler(hrmHoursValidated);
            this.lnkEdit.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkEditLinkClicked);
            this.lnkEditTimeFieldRoom.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkEditTimeFieldRoomLinkClicked);
          
        }
        
        #endregion

        #region Class Event Void Procedures
        //############################################CLASS SubjectScheduleDetails EVENTS#######################################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            if (_scheduleManager.MustOpenSchoolYearSemester())
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Please open another school year / semester before creating a new subject schedule.",
                    "Error Creating A Subject Schedule");

                _hasErrors = true;

                this.Close();
            }

            _schedDetailsInfo = new CommonExchange.ScheduleInformationDetails();

            lblSysIdSubject.Text = _schedInfo.SubjectInfo.SubjectSysId;
            lblSubjectCodeDescription.Text = _schedInfo.SubjectInfo.SubjectCode + " - " + _schedInfo.SubjectInfo.DescriptiveTitle;
            lblSubjectDepartment.Text = _schedInfo.SubjectInfo.DepartmentInfo.DepartmentName;
            lblUnitsLabHours.Text = _scheduleManager.GetSubjectUnitsHours(_schedInfo.SubjectInfo.LectureUnits, _schedInfo.SubjectInfo.LabUnits, 
                _schedInfo.SubjectInfo.NoHours);

            _schedDetailsInfo.ScheduleInfo.SubjectInfo.SubjectCode = _schedInfo.SubjectInfo.SubjectCode;
            _schedDetailsInfo.ScheduleInfo.SubjectInfo.DescriptiveTitle = _schedInfo.SubjectInfo.DescriptiveTitle;
            _schedDetailsInfo.NoHours = this.hrmHours.SelectedHourMinute;
            _schedDetailsInfo.ScheduleInfo.ScheduleSysId = _schedInfo.ScheduleSysId;
           
            //if (_schedInfo.SubjectInfo.CourseGroupInfo.IsSemestral)
            //{
            //    this.optUnits.Enabled = this.optUnits.Checked = true;
            //    this.txtLecture.Enabled = true;
            //    this.txtLaboratory.Enabled = true;
            //}
            //else
            //{
            //    this.optHours.Enabled = this.optHours.Checked = true;
            //    this.hrmHours.Enabled = true;  
            //}            
            
            optTBA.Checked = true;
        }//------------------------
        //############################################END CLASS SubjectScheduleDetails EVENTS#######################################################

        //#############################################OPTIONBOX optCampus EVENTS#################################################
        //event is raised when optCampus is changed
        protected void optCampusCheckedChanged(object sender, EventArgs e)
        {
            if (!_isForUpdate)
            {
                if (this.optCampus.Checked)
                {
                    if (!_schedInfo.IsIrregularModular)
                    {
                        using (ClassroomDateTimeSchedulerCreate frmCreate = new ClassroomDateTimeSchedulerCreate(_userInfo, _schedInfo, _scheduleManager,
                            _schedDetailsInfo))
                        {
                            frmCreate.ShowDialog(this);

                            if (frmCreate.HasInserted)
                            {
                                _tFrames = frmCreate.TFrames;
                                _noOfDaysDisplayed = frmCreate.NoOfDaysDisplayed;
                                _noOfTimeSlotsDisplayed = frmCreate.NoOfTimeSlotsDisplayed;
                                _selectedIndex = frmCreate.SelectedIndex;
                                _readOnlyIndex = frmCreate.ReadOnlyIndex;
                                _selectedValue = frmCreate.SelectedValue;
                                _readOnlyValue = frmCreate.ReadOnlyValue;

                                _schedDetailsInfo.ClassroomInfo = frmCreate.ClassRoomInfo;
                                _schedDetailsInfo.DayTimeClassroom = _scheduleManager.GetDayTimeString(_scheduleManager.GenerateScheduleTable(_tFrames, 
                                    _noOfDaysDisplayed, _noOfTimeSlotsDisplayed, _selectedIndex, _readOnlyIndex, 
                                    _selectedValue, _readOnlyValue), frmCreate.TimeInterval);
                            }
                        }
                    }
                    else
                    {
                        using (ClassroomDateTimeForModularCreate frmCreate = new ClassroomDateTimeForModularCreate(_userInfo, _schedInfo,
                            _scheduleManager, ref _schedDetailsInfo))
                        {
                            frmCreate.ShowDialog(this);

                            if (frmCreate.HasInserted)
                            {
                                _schedDetailsInfo.ClassroomInfo = frmCreate.ClassRoomInfo;
                            }
                        }
                    }
                }
            }

            this.SetClassroomControls();
        }//------------------------------
        //#############################################END OPTIONBOX optCampus EVENTS#################################################
      
        //#############################################OPTIONBOX optTBA EVENTS#################################################
        //event is raised when optTBA is changed
        protected void optTBACheckedChanged(object sender, EventArgs e)
        {
            this.SetClassroomControls();
        }//-------------------------------
        //#############################################END OPTIONBOX optTBA EVENTS#################################################

        //#############################################OPTIONBOX optField EVENTS#################################################
        //event is raised when optField is changed
        protected void optFieldCheckedChanged(object sender, EventArgs e)
        {
            this.SetClassroomControls();            
        }//-----------------------------
        //#############################################END OPTIONBOX optField EVENTS#################################################

        //#############################################OPTIONBOX optUnits EVENTS#################################################
        //event is raised when optUnits is changed
        private void optUnitsHoursCheckedChanged(object sender, EventArgs e)
        {
            if (this.optUnits.Checked)
            {
                this.txtLecture.Enabled = true;
                this.txtLaboratory.Enabled = true;

                this.hrmHours.Enabled = false;
                this.hrmHours.SetHoursMinutes(DateTime.Parse("00:00"));

                _schedDetailsInfo.NoHours = this.hrmHours.SelectedHourMinute;
            }
            else
            {
                this.txtLaboratory.Enabled = false;
                this.txtLecture.Enabled = false;

                this.txtLecture.Text = "0";
                this.txtLaboratory.Text = "0";

                _schedDetailsInfo.LectureUnits = 0;
                _schedDetailsInfo.LabUnits = 0;

                this.hrmHours.Enabled = true;
            }
        }//-----------------------------
        //#############################################END OPTIONBOX optUnits EVENTS#################################################

        //#############################################TEXTBOX txtField EVENTS#################################################
        //event is raised when the txtFieldRoom is Validated
        private void txtFieldRoomValidated(object sender, EventArgs e)
        {
            _schedDetailsInfo.FieldRoom = RemoteClient.ProcStatic.TrimStartEndString(txtFieldRoom.Text);
        }//-------------------------
        //#############################################END TEXTBOX txtField EVENTS#################################################

        //#############################################TEXTBOX txtSection EVENTS#################################################
        //event is raised when the txtSection is Validated
        private void txtSectionValidated(object sender, EventArgs e)
        {
            _schedDetailsInfo.Section = RemoteClient.ProcStatic.TrimStartEndString(txtSection.Text);
        }//-------------------------
        //#############################################END TEXTBOX txtSection EVENTS#################################################

        //#################################################HOURMINUTE hrmHours EVENTS#####################################################
        //event is raised when the control is validated
        private void hrmHoursValidated(object sender, EventArgs e)
        {
            _schedDetailsInfo.NoHours = hrmHours.SelectedHourMinute;
        }//------------------------
        //#################################################END  HOURMINUTE hrmHours EVENTS#####################################################

        //#################################################TEXTBOX txtLaboratory EVENTS###################################################
        //event is raised when the control is validated
        private void txtLaboratoryValidated(object sender, EventArgs e)
        {
            Single labUnits;

            if (Single.TryParse(txtLaboratory.Text, out labUnits))
            {
                _schedDetailsInfo.LabUnits = labUnits;
            }
        }//--------------------------
        //#################################################END TEXTBOX txtLaboratory EVENTS###################################################

        //################################################TEXTBOX txtLecture EVENTS####################################################
        //event is raised when the control is validated
        private void txtLectureValidated(object sender, EventArgs e)
        {
            Single lecUnits;

            if (Single.TryParse(txtLecture.Text, out lecUnits))
            {
                _schedDetailsInfo.LectureUnits = lecUnits;
            }
        }//-------------------------

        //event is raised when Validating txtLecture and txtlaboratory
        private void UnitsValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxValidateFloatMaxTwoDecimal((TextBox)sender);
        }//-------------------------

        //event is raised when txtLecture and txtLaboratory is KeyPress
        private void UnitsKeyPress(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxFloatDecimalOnly(e);
        }//------------------------
        //################################################END TEXTBOX txtLecture EVENTS####################################################        

        //################################################LINKLABEL lnkEdit EVENTS####################################################
        //event is raised when the control is clicked
        private void lnkEditLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!_schedInfo.IsIrregularModular)
                {
                    using (ClassroomDateTimeSchedulerUpdate frmEdit = new ClassroomDateTimeSchedulerUpdate(_userInfo, _schedInfo,
                        _schedDetailsInfo.ClassroomInfo.ClassroomSysId, _scheduleManager, _schedDetailsInfo))
                    {
                        frmEdit.TFrames = _tFrames;
                        frmEdit.NoOfDaysDisplayed = _noOfDaysDisplayed;
                        frmEdit.NoOfTimeSlotsDisplayed = _noOfTimeSlotsDisplayed;
                        frmEdit.SelectedIndex = _selectedIndex;
                        frmEdit.ReadOnlyIndex = _readOnlyIndex;
                        frmEdit.SelectedValue = _selectedValue;
                        frmEdit.ReadOnlyValue = _readOnlyValue;

                        frmEdit.ShowDialog(this);

                        if (frmEdit.HasUpdated)
                        {
                            _tFrames = frmEdit.TFrames;
                            _noOfDaysDisplayed = frmEdit.NoOfDaysDisplayed;
                            _noOfTimeSlotsDisplayed = frmEdit.NoOfTimeSlotsDisplayed;
                            _selectedIndex = frmEdit.SelectedIndex;
                            _readOnlyIndex = frmEdit.ReadOnlyIndex;
                            _selectedValue = frmEdit.SelectedValue;
                            _readOnlyValue = frmEdit.ReadOnlyValue;

                            _schedDetailsInfo.ClassroomInfo = frmEdit.ClassRoomInfo;
                            _schedDetailsInfo.DayTimeClassroom = _scheduleManager.GetDayTimeString(_scheduleManager.GenerateScheduleTable(_tFrames,
                                _noOfDaysDisplayed, _noOfTimeSlotsDisplayed, _selectedIndex, _readOnlyIndex, _selectedValue, _readOnlyValue), frmEdit.TimeInterval);

                            this.lblClassroomCode.Text = frmEdit.ClassRoomInfo.ClassroomCode;
                            this.lblMaxCapacity.Text = frmEdit.ClassRoomInfo.MaximumCapacity.ToString();
                            this.lblEditTimeClassroomBased.Text = String.IsNullOrEmpty(_schedDetailsInfo.DayTimeClassroom) ? 
                                "TBA" : _schedDetailsInfo.DayTimeClassroom;
                        }
                    }
                }
                else
                {
                    using (ClassroomDateTimeForModularUpdate frmUpdate = new ClassroomDateTimeForModularUpdate(_userInfo, _schedInfo,
                        _schedDetailsInfo.ClassroomInfo.ClassroomSysId, _scheduleManager, ref _schedDetailsInfo))
                    {
                        frmUpdate.ShowDialog(this);

                        if (frmUpdate.HasUpdated)
                        {
                            _schedDetailsInfo.ClassroomInfo = frmUpdate.ClassRoomInfo;

                            this.lblClassroomCode.Text = frmUpdate.ClassRoomInfo.ClassroomCode;
                            this.lblMaxCapacity.Text = frmUpdate.ClassRoomInfo.MaximumCapacity.ToString();
                            this.lblEditTimeClassroomBased.Text = String.IsNullOrEmpty(_schedDetailsInfo.ManualScheduleClassroom) ? 
                                "TBA" : _schedDetailsInfo.ManualScheduleClassroom;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Classroom Scheduler Module");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//-------------------------
        //################################################END LINKLABEL lnkEdit EVENTS####################################################

        //################################################LINKLABEL lnkEditTimeFieldRoom EVENTS####################################################
        //event is raised when the control is clicked
        private void lnkEditTimeFieldRoomLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (!_schedInfo.IsIrregularModular)
                {
                    if (String.IsNullOrEmpty(_schedDetailsInfo.DayTimeFieldRoom) && !_isForUpdate)
                    {
                        using (FieldRoomDateTimeSchedulerCreate frmCreate = new FieldRoomDateTimeSchedulerCreate(_userInfo, _schedInfo, 
                            _scheduleManager, _schedDetailsInfo))
                        {
                            frmCreate.ShowDialog(this);

                            if (frmCreate.HasInserted)
                            {
                                _tFrames = frmCreate.TFrames;
                                _noOfDaysDisplayed = frmCreate.NoOfDaysDisplayed;
                                _noOfTimeSlotsDisplayed = frmCreate.NoOfTimeSlotsDisplayed;
                                _selectedIndex = frmCreate.SelectedIndex;
                                _readOnlyIndex = frmCreate.ReadOnlyIndex;
                                _selectedValue = frmCreate.SelectedValue;
                                _readOnlyValue = frmCreate.ReadOnlyValue;
                              
                                _schedDetailsInfo.DayTimeFieldRoom = _scheduleManager.GetDayTimeString(_scheduleManager.GenerateScheduleTable(_tFrames, 
                                    _noOfDaysDisplayed, _noOfTimeSlotsDisplayed, _selectedIndex, _readOnlyIndex, 
                                    _selectedValue, _readOnlyValue), frmCreate.TimeInterval);

                                this.lblFieldRoomTime.Text = String.IsNullOrEmpty(_schedDetailsInfo.DayTimeFieldRoom) ?
                                    "TBA" : _schedDetailsInfo.DayTimeFieldRoom;
                            }
                        }
                    }
                    else
                    {
                        using (FieldRoomDateTimeSchedulerUpdate frmUpdate = new FieldRoomDateTimeSchedulerUpdate(_userInfo, _schedInfo,
                            _scheduleManager, _schedDetailsInfo))
                        {
                            frmUpdate.TFrames = _tFrames;
                            frmUpdate.NoOfDaysDisplayed = _noOfDaysDisplayed;
                            frmUpdate.NoOfTimeSlotsDisplayed = _noOfTimeSlotsDisplayed;
                            frmUpdate.SelectedIndex = _selectedIndex;
                            frmUpdate.ReadOnlyIndex = _readOnlyIndex;
                            frmUpdate.SelectedValue = _selectedValue;
                            frmUpdate.ReadOnlyValue = _readOnlyValue;

                            frmUpdate.ShowDialog(this);

                            if (frmUpdate.HasUpdated)
                            {
                                _tFrames = frmUpdate.TFrames;
                                _noOfDaysDisplayed = frmUpdate.NoOfDaysDisplayed;
                                _noOfTimeSlotsDisplayed = frmUpdate.NoOfTimeSlotsDisplayed;
                                _selectedIndex = frmUpdate.SelectedIndex;
                                _readOnlyIndex = frmUpdate.ReadOnlyIndex;
                                _selectedValue = frmUpdate.SelectedValue;
                                _readOnlyValue = frmUpdate.ReadOnlyValue;

                                _schedDetailsInfo.DayTimeFieldRoom = _scheduleManager.GetDayTimeString(_scheduleManager.GenerateScheduleTable(_tFrames, 
                                    _noOfDaysDisplayed, _noOfTimeSlotsDisplayed, _selectedIndex, _readOnlyIndex, _selectedValue, 
                                    _readOnlyValue), frmUpdate.TimeInterval);

                                this.lblFieldRoomTime.Text = String.IsNullOrEmpty(_schedDetailsInfo.DayTimeFieldRoom) ? 
                                    "TBA" : _schedDetailsInfo.DayTimeFieldRoom;
                            }
                        }
                    }
                }
                else
                {
                    if (String.IsNullOrEmpty(_schedDetailsInfo.DayTimeFieldRoom) && !_isForUpdate)
                    {
                        using (FieldroomDateTimeForModularCreate frmCreate = new FieldroomDateTimeForModularCreate(_userInfo, _schedInfo, 
                            _scheduleManager, ref _schedDetailsInfo))
                        {
                            frmCreate.ShowDialog(this);

                            if (frmCreate.HasInserted)
                            {
                                this.lblFieldRoomTime.Text = String.IsNullOrEmpty(_schedDetailsInfo.ManualScheduleFieldRoom) ?
                                    "TBA" : _schedDetailsInfo.ManualScheduleFieldRoom;
                            }
                        }
                    }
                    else
                    {
                        using (FieldroomDateTimeForModularUpdate frmUpdate = new FieldroomDateTimeForModularUpdate(_userInfo, _schedInfo, _scheduleManager,
                            ref _schedDetailsInfo))
                        {
                            frmUpdate.ShowDialog(this);

                            if (frmUpdate.HasUpdated)
                            {
                                this.lblFieldRoomTime.Text = String.IsNullOrEmpty(_schedDetailsInfo.ManualScheduleFieldRoom) ?
                                    "TBA" : _schedDetailsInfo.ManualScheduleFieldRoom;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading Fieldroom Scheduler Module");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }
        }//------------------------
        //################################################END LINKLABEL lnkEditTimeFieldRoom EVENTS####################################################
        #endregion

        #region Programer-Defined Procedures

        //this function determines if the controls are validated
        protected Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.optCampus, "");
            _errProvider.SetError(this.optUnits, "");
            _errProvider.SetError(this.optHours, "");

            if (this.optCampus.Checked && String.IsNullOrEmpty(_schedDetailsInfo.ClassroomInfo.ClassroomSysId))
            {
                _errProvider.SetIconAlignment(this.optCampus, ErrorIconAlignment.MiddleLeft);
                _errProvider.SetError(this.optCampus, "Please select a classroom for the schedule information.");
                isValid = false;
                this.tabDetails.SelectedIndex = 0;
            }

            return isValid;
        }//------------------------

        //this procedure sets the classrom controls
        protected void SetClassroomControls()
        {
            if (this.optTBA.Checked)
            {
                this.lblClassCode.Visible = false;
                this.lblMCapacity.Visible = false;
                this.lblClassroomCode.Visible = false;
                this.lblMaxCapacity.Visible = false;
                this.txtFieldRoom.Visible = false;
                this.lnkEditTimeFieldRoom.Visible = false;
                this.pnlFieldRoom.Visible = false;
                this.lblEditTimeClassroomBased.Visible = false;
                this.lnkEdit.Visible = false;
                this.pnlClassroomBased.Visible = false;

                _schedDetailsInfo.IsClassroom = false;
            }
            else if (this.optField.Checked)
            {
                this.txtFieldRoom.Visible = true;
                this.lnkEditTimeFieldRoom.Visible = true;
                this.pnlFieldRoom.Visible = true;
                this.lblClassCode.Visible = false;
                this.lblMCapacity.Visible = false;
                this.lblClassroomCode.Visible = false;
                this.lblMaxCapacity.Visible = false;
                this.lblEditTimeClassroomBased.Visible = false;
                this.lnkEdit.Visible = false;
                this.pnlClassroomBased.Visible = false;
                this.txtFieldRoom.Enabled = true;
                this.txtFieldRoom.ReadOnly = false;
                this.txtFieldRoom.Focus();

                this.txtFieldRoom.Text = _schedDetailsInfo.FieldRoom;

                _schedDetailsInfo.IsClassroom = false;
            }
            else if (this.optCampus.Checked)
            {
                this.txtFieldRoom.Visible = false;
                this.lnkEditTimeFieldRoom.Visible = false;
                this.pnlFieldRoom.Visible = false;
                this.lblClassCode.Visible = true;
                this.lblMCapacity.Visible = true;
                this.lblClassroomCode.Visible = true;
                this.lblEditTimeClassroomBased.Visible = true;
                this.lblMaxCapacity.Visible = true;
                this.lnkEdit.Visible = true;
                this.pnlClassroomBased.Visible = true;

                this.lblClassroomCode.Text = _schedDetailsInfo.ClassroomInfo.ClassroomCode;
                this.lblMaxCapacity.Text = _schedDetailsInfo.ClassroomInfo.MaximumCapacity.ToString();              

                this.lblEditTimeClassroomBased.Text = _schedInfo.IsIrregularModular ? 
                    (String.IsNullOrEmpty(_schedDetailsInfo.ManualScheduleClassroom) ? "TBA" : _schedDetailsInfo.ManualScheduleClassroom) :
                    (String.IsNullOrEmpty(_schedDetailsInfo.DayTimeClassroom) ? "TBA" : _schedDetailsInfo.DayTimeClassroom);

                _schedDetailsInfo.IsClassroom = true;
            }      

        } //-------------------------
        #endregion
    }
}


