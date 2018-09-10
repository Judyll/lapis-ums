using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class Service
    {

        #region Class General Variable Declaration
        protected CommonExchange.SysAccess _userInfo;
        protected CommonExchange.AuxiliaryServiceInformation _serviceInfo;
        protected AuxiliaryServiceLogic _auxiliaryManager;

        private ErrorProvider _errProvider;
        #endregion

        #region Class Constructors
        public Service()
        {
            this.InitializeComponent();
        }

        public Service(CommonExchange.SysAccess userInfo, AuxiliaryServiceLogic auxiliaryInfoManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _auxiliaryManager = auxiliaryInfoManager;

            _errProvider = new ErrorProvider();

            this.Load += new EventHandler(ClassLoad);
            this.lnkOtherInfo.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkOtherInfoLinkClicked);
            this.cboCourseGroup.SelectedIndexChanged += new EventHandler(cboServiceGroupSelectedIndexChanged);
            this.cboDepartment.SelectedIndexChanged += new EventHandler(cboDepartmentSelectedIndexChanged);
            this.txtCode.Validated += new EventHandler(txtCodeValidated);
            this.txtTitle.Validated += new EventHandler(txtTitleValidated);
            this.optUnits.CheckedChanged += new EventHandler(UnitHoursCheckedChange);
            this.optHours.CheckedChanged += new EventHandler(UnitHoursCheckedChange);
            this.txtLecture.KeyPress += new KeyPressEventHandler(UnitsKeyPress);
            this.txtLecture.Validating += new System.ComponentModel.CancelEventHandler(UnitsValidating);
            this.txtLecture.Validated += new EventHandler(txtLectureValidated);
            this.txtLaboratory.KeyPress += new KeyPressEventHandler(UnitsKeyPress);
            this.txtLaboratory.Validating += new System.ComponentModel.CancelEventHandler(UnitsValidating);
            this.txtLaboratory.Validated += new EventHandler(txtLaboratoryValidated);
            this.hrmHours.Validated += new EventHandler(hrmHoursValidated);
        }

        #region Class Event Void Procedures

        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            if (!(RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo) || 
                RemoteServerLib.ProcStatic.IsSystemAccessVpOfAcademicAffairs(_userInfo) ||
                RemoteServerLib.ProcStatic.IsSystemAccessSecretaryOftheVpOfAcademicAffairs(_userInfo)))
            {
                throw new Exception("You are not authorized to access this module.");
            }

            _serviceInfo = new CommonExchange.AuxiliaryServiceInformation();

            _auxiliaryManager.InitializeServiceGroupCombo(this.cboCourseGroup);
            _auxiliaryManager.InitializeDepartmentCombo(this.cboDepartment);
        }

        //############################################LINKLABEL lnkOtherInfo EVENTS#####################################################
        //event is raised when the link is clicked
        private void lnkOtherInfoLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (OtherInformation frmInfo = new OtherInformation())
            {
                frmInfo.AuxiliaryServiceOtherInformation = _serviceInfo.OtherInformation;

                frmInfo.ShowDialog(this);

                _serviceInfo.OtherInformation = RemoteClient.ProcStatic.TrimStartEndString(frmInfo.AuxiliaryServiceOtherInformation);
            }
        }//---------------------------------------
        //#########################################END LINKLABEL lnkOtherInfo EVENTS####################################################

        //###########################################COMBOBOX cboDepartment EVENTS##################################################
        //event is raised when the selected index is changed
        private void cboDepartmentSelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBox)sender).SelectedIndex != -1)
            {
                _serviceInfo.DepartmentInfo.DepartmentId = _auxiliaryManager.GetDepartmentId(((ComboBox)sender).SelectedIndex);
                _serviceInfo.DepartmentInfo.DepartmentName = _auxiliaryManager.GetDepartmentName(((ComboBox)sender).SelectedIndex);
            }
        }//---------------------------
        //###########################################END COMBOBOX cboDepartment EVENTS##################################################

        //###########################################COMBOBOX cboServiceGroup EVENTS##################################################
        //event is raised when the selected index is changed
        private void cboServiceGroupSelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 index = ((ComboBox)sender).SelectedIndex;

            if (index != -1)
            {
                index += 1;

                _serviceInfo.CourseGroupInfo.CourseGroupId = _auxiliaryManager.GetCourseGroupId(index);
                _serviceInfo.CourseGroupInfo.GroupNo = _auxiliaryManager.GetCourseGroupNo(_serviceInfo.CourseGroupInfo.CourseGroupId);
                _serviceInfo.CourseGroupInfo.IsSemestral = _auxiliaryManager.GetCourseGroupIsSemestral(_serviceInfo.CourseGroupInfo.CourseGroupId);

                if (!_serviceInfo.CourseGroupInfo.IsSemestral)
                {
                    this.optHours.Checked = true;                  
                }
                else
                {
                    this.optUnits.Checked = true;
                }

                //if (!_serviceInfo.CourseGroupInfo.IsSemestral)
                //{
                //    this.optHours.Checked = true;
                //    this.optHours.Enabled = true;
                //    this.optUnits.Checked = false;
                //    this.optUnits.Enabled = false;
                //}
                //else
                //{
                //    this.optHours.Checked = false;
                //    this.optHours.Enabled = false;
                //    this.optUnits.Checked = true;
                //    this.optUnits.Enabled = true;
                //}
            }
        }//----------------------------------
        //###########################################END COMBOBOX cboServiceGroup EVENTS##################################################

        //###########################################TEXTBOX txtCode EVENTS###########################################################
        //event is raised when the control is validated
        private void txtCodeValidated(object sender, EventArgs e)
        {
            _serviceInfo.ServiceCode = RemoteClient.ProcStatic.TrimStartEndString(txtCode.Text);
        } //-----------------------------
        //#########################################END TEXTBOX txtCode EVENTS#########################################################

        //###########################################TEXTBOX txtTitle EVENTS###########################################################
        //event is raised when the control is validated
        private void txtTitleValidated(object sender, EventArgs e)
        {
            _serviceInfo.DescriptiveTitle = RemoteClient.ProcStatic.TrimStartEndString(txtTitle.Text);
        }//-----------------------------
        //###########################################END TEXTBOX txtTitle EVENTS###########################################################

        //#################################################OPTIONBUTTONS EVENTS#######################################################
        //event is raised when the checked is changed
        private void UnitHoursCheckedChange(object sender, EventArgs e)
        {
            this.SetUnitsHoursControl();
        }//-----------------------------
        //#################################################END OPTIONBUTTONS EVENTS#######################################################
        
        //################################################TEXTBOX EVENTS###############################################################
        //event is raised when the key is pressed
        private void UnitsKeyPress(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxIntegersOnly(e);
        } //---------------------------------------

        //event is raised when the control is validating
        private void UnitsValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxValidateInteger((TextBox)sender);
        } //-------------------------------
        //##############################################END TEXTBOX EVENTS#############################################################

        //#################################################TEXTBOX txtLaboratory EVENTS###################################################
        //event is raised when the control is validated
        private void txtLaboratoryValidated(object sender, EventArgs e)
        {
            Byte labUnits;

            if (Byte.TryParse(txtLaboratory.Text, out labUnits))
            {
                _serviceInfo.LabUnits = labUnits;
            }
        }//---------------------------------
        //###############################################END TEXTBOX txtLaboratory EVENTS#################################################

        //################################################TEXTBOX txtLecture EVENTS####################################################
        //event is raised when the control is validated
        private void txtLectureValidated(object sender, EventArgs e)
        {
            Byte lecUnits;

            if (Byte.TryParse(txtLecture.Text, out lecUnits))
            {
                _serviceInfo.LectureUnits = lecUnits;
            }
        }//-------------------------------
        //################################################END TEXTBOX txtLecture EVENTS####################################################    

        //#################################################HOURMINUTE hrmHours EVENTS#####################################################
        //event is raised when the control is validated
        private void hrmHoursValidated(object sender, EventArgs e)
        {
            _serviceInfo.NoHours = hrmHours.SelectedHourMinute;
        }//-------------------------------
        //#################################################END HOURMINUTE hrmHours EVENTS#####################################################  

        #endregion

        #endregion

        #region Programmer-Defined Void Procedures
        //this procedure sets the units hours control
        private void SetUnitsHoursControl()
        {
            this.txtLecture.Enabled = optUnits.Checked;
            this.txtLaboratory.Enabled = optUnits.Checked;
            this.lblLecture.Enabled = optUnits.Checked;
            this.lblLaboratory.Enabled = optUnits.Checked;

            this.hrmHours.EnableControl = optHours.Checked;
            this.lblHours.Enabled = optHours.Checked;

            if (this.optUnits.Checked)
            {
                this.hrmHours.ResetHoursMinutes();

                _serviceInfo.NoHours = hrmHours.SelectedHourMinute;
            }
            else
            {
                this.txtLecture.Text = "0";
                this.txtLaboratory.Text = "0";

                _serviceInfo.LectureUnits = 0;
                _serviceInfo.LabUnits = 0;
            }

        } //---------------------------
        #endregion

        #region Programmer-Defined Function Procedures

        //this function determines if the controls are validated
        protected Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.cboDepartment, "");
            _errProvider.SetError(this.txtCode, "");
            _errProvider.SetError(this.txtTitle, "");
            _errProvider.SetError(this.cboCourseGroup, "");
            _errProvider.SetError(this.lblLecture, "");
            _errProvider.SetError(this.lblHours, "");

            if (this.cboDepartment.SelectedIndex == -1)
            {
                _errProvider.SetError(this.cboDepartment, "Please select a department.");
                isValid = false;
            }

            if (String.IsNullOrEmpty(this.txtCode.Text.Trim()))
            {
                _errProvider.SetError(this.txtCode, "An auxiliary service code is required.");
                isValid = false;
            }
            else
            {
                if (String.IsNullOrEmpty(this.txtTitle.Text.Trim()))
                {
                    _errProvider.SetError(this.txtTitle, "An auxiliary service descriptive title is required.");
                    isValid = false;
                }
                else if (_auxiliaryManager.IsExistCodeDescriptionAuxiliaryServiceInformation(_userInfo, _serviceInfo))
                {
                    _errProvider.SetError(this.txtCode, "The auxiliary service code and descriptive title already exist.");
                    _errProvider.SetError(this.txtTitle, "The auxiliary code and descriptive title already exist.");
                    isValid = false;
                }
            }

            if (this.cboCourseGroup.SelectedIndex == -1)
            {
                _errProvider.SetError(this.cboCourseGroup, "Please select a course group for the subject.");
                isValid = false;
            }

            Byte lecUnits;

            if (Byte.TryParse(this.txtLecture.Text, out lecUnits))
            {
                if (this.optUnits.Checked && lecUnits == 0)
                {
                    _errProvider.SetError(this.lblLecture, "A lecture units is required.");
                    isValid = false;
                }
            }

            if (this.optHours.Checked && this.hrmHours.IsHourMinuteZero())
            {
                _errProvider.SetError(this.lblHours, "A number of hours/minutes must not be equal to zero.");
                isValid = false;
            }

            return isValid;
        }

        #endregion
    }
}
