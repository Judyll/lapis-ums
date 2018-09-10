using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class AuxiliaryScheduleDetails
    {
        #region General Variable Declaration
        protected CommonExchange.SysAccess _userInfo;
        protected CommonExchange.AuxiliaryServiceSchedule _serviceInfoSchedule;
        protected CommonExchange.AuxiliaryServiceDetails _serviceInfoDetails;
        protected AuxiliaryServiceLogic _auxiliaryManager;
        protected Boolean _hasErrors;

        private ErrorProvider _errProvider;
        #endregion

        #region Class Constructors
        public AuxiliaryScheduleDetails()
        {
            this.InitializeComponent();
        }

        public AuxiliaryScheduleDetails(CommonExchange.SysAccess userInfo, CommonExchange.AuxiliaryServiceSchedule serviceInfoSchedule,
            AuxiliaryServiceLogic auxiliaryManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _serviceInfoSchedule = serviceInfoSchedule;
            _auxiliaryManager = auxiliaryManager;

            _errProvider = new ErrorProvider();

            this.Load += new EventHandler(ClassLoad);
            this.optUnits.CheckedChanged += new EventHandler(optUnitsHoursCheckedChanged);
            this.optHours.CheckedChanged += new EventHandler(optUnitsHoursCheckedChanged);
            this.txtLecture.KeyPress += new KeyPressEventHandler(UnitsKeyPress);
            this.txtLaboratory.KeyPress += new KeyPressEventHandler(UnitsKeyPress);
            this.txtLecture.Validating += new System.ComponentModel.CancelEventHandler(UnitsValidating);
            this.txtLaboratory.Validating += new System.ComponentModel.CancelEventHandler(UnitsValidating);
            this.txtLecture.Validated += new EventHandler(txtLectureValidated);
            this.txtLaboratory.Validated += new EventHandler(txtLaboratoryValidated);
            this.hrmHours.Validated += new EventHandler(hrmHoursValidated);
        }       

        #endregion

        #region Class Event Void Procedures
        //############################################CLASS SubjectScheduleDetails EVENTS#######################################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            if (_auxiliaryManager.MustOpenSchoolYearSemester())
            {
                RemoteClient.ProcStatic.ShowErrorDialog("Please open another school year / semester before creating a new subject schedule.",
                    "Error Creating A Subject Schedule");

                _hasErrors = true;

                this.Close();
            }

            _serviceInfoDetails = new CommonExchange.AuxiliaryServiceDetails();

            this.lblSysIdAuxiliary.Text = _serviceInfoSchedule.AuxiliaryServiceInfo.AuxServiceSysId;
            this.lblAuxiliaryServiceCodeDescription.Text = _serviceInfoSchedule.AuxiliaryServiceInfo.ServiceCode + " - " + 
                _serviceInfoSchedule.AuxiliaryServiceInfo.DescriptiveTitle;
            this.lblAuxiliaryDepartment.Text = _serviceInfoSchedule.AuxiliaryServiceInfo.DepartmentInfo.DepartmentName;
            this.lblUnitsLabHours.Text = _auxiliaryManager.GetAuxiliaryUnitsHours(_serviceInfoSchedule.AuxiliaryServiceInfo.LectureUnits, 
                _serviceInfoSchedule.AuxiliaryServiceInfo.LabUnits, _serviceInfoSchedule.AuxiliaryServiceInfo.NoHours);

            _serviceInfoDetails.AuxiliaryServiceScheduleInfo.AuxiliaryServiceInfo.ServiceCode = _serviceInfoSchedule.AuxiliaryServiceInfo.ServiceCode;
            _serviceInfoDetails.AuxiliaryServiceScheduleInfo.AuxiliaryServiceInfo.DescriptiveTitle = 
                _serviceInfoSchedule.AuxiliaryServiceInfo.DescriptiveTitle;
            _serviceInfoDetails.NoHours = this.hrmHours.SelectedHourMinute;
            _serviceInfoDetails.AuxiliaryServiceScheduleInfo.AuxServiceScheduleSysId = _serviceInfoSchedule.AuxServiceScheduleSysId;

            //if (_serviceInfoSchedule.AuxiliaryServiceInfo.CourseGroupInfo.IsSemestral)
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
            
        }//------------------------
        //############################################END CLASS SubjectScheduleDetails EVENTS#######################################################

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

                _serviceInfoDetails.NoHours = this.hrmHours.SelectedHourMinute;
            }
            else
            {
                this.txtLaboratory.Enabled = false;
                this.txtLecture.Enabled = false;

                this.txtLecture.Text = "0";
                this.txtLaboratory.Text = "0";

                _serviceInfoDetails.LectureUnits = 0;
                _serviceInfoDetails.LabUnits = 0;

                this.hrmHours.Enabled = true;
            }
        }//--------------------------
        //#############################################END OPTIONBOX optUnits EVENTS#################################################

        //################################################TEXTBOX EVENTS####################################################
        //event is raised when the controls is key pressed
        private void UnitsKeyPress(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxFloatDecimalOnly(e);
        }//------------------------------

        //event is raised when the control is validating
        private void UnitsValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxValidateFloatMaxTwoDecimal((TextBox)sender);
        }//------------------------------

        //event is raised when the control is validated
        private void txtLectureValidated(object sender, EventArgs e)
        {
            Single lecUnits;

            if (Single.TryParse(txtLecture.Text, out lecUnits))
            {
                _serviceInfoDetails.LectureUnits = lecUnits;
            }
        }//---------------------------

        //-----------------------------
        private void txtLaboratoryValidated(object sender, EventArgs e)
        {
            Single labUnits;

            if (Single.TryParse(txtLaboratory.Text, out labUnits))
            {
                _serviceInfoDetails.LabUnits = labUnits;
            }
        }
        //################################################END TEXTBOX EVENTS####################################################

        //#################################################HOURMINUTE hrmHours EVENTS#####################################################
        //event is raised when the control is validated
        private void hrmHoursValidated(object sender, EventArgs e)
        {
            _serviceInfoDetails.NoHours = hrmHours.SelectedHourMinute;
        }//------------------------------
        //#################################################END HOURMINUTE hrmHours EVENTS#####################################################
        #endregion

        #region Programes-Defined Void Procedures

        //this function determines if the controls are validated
        protected Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.optUnits, "");
            _errProvider.SetError(this.optHours, "");

            if (this.optUnits.Checked && (_serviceInfoDetails.LectureUnits == 0 && _serviceInfoDetails.LabUnits == 0))
            {
                _errProvider.SetIconAlignment(this.optUnits, ErrorIconAlignment.MiddleLeft);
                _errProvider.SetError(this.optUnits, "Lecture or Laboratory/RLE units is required.");
                isValid = false;
            }

            if (this.optHours.Checked && this.hrmHours.IsHourMinuteZero())
            {
                _errProvider.SetIconAlignment(this.optHours, ErrorIconAlignment.MiddleLeft);
                _errProvider.SetError(this.optHours, "Number of hours is required.");
                isValid = false;
            }

            return isValid;

        } //------------------------

        #endregion
    }
}
