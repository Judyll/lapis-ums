using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RegistrarServices
{
    partial class Classroom
    {
        #region Class General Variable Declarations
        protected CommonExchange.SysAccess _userInfo;
        protected CommonExchange.ClassroomInformation _roomInfo;
        protected CourseLogic _courseManager;

        private ErrorProvider _errProvider;

        #endregion

        #region Class Constructor
        public Classroom()
        {
            InitializeComponent();

            _errProvider = new ErrorProvider();

            this.txtClassroomCode.Validated += new EventHandler(txtClassroomCodeValidated);
            this.txtDescription.Validated += new EventHandler(txtDescriptionValidated);
            this.txtOtherInfo.Validated += new EventHandler(txtOtherInfoValidated);
            this.txtCapacity.KeyPress += new KeyPressEventHandler(txtCapacityKeyPress);
            this.txtCapacity.Validated += new EventHandler(txtCapacityValidated);
        }
        
        #endregion

        #region Class Event Void Procedures

        //###############################################TEXTBOX txtCapacity EVENTS################################################
        //event is raised when the key is pressed
        private void txtCapacityKeyPress(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxIntegersOnly(e);
   
        } //------------------------------  
      
        //event is raised when the control is validated
        private void txtCapacityValidated(object sender, EventArgs e)
        {
            Byte maxCap;

            if (Byte.TryParse(txtCapacity.Text, out maxCap))
            {
                _roomInfo.MaximumCapacity = maxCap;
            }
        } //-------------------------------------
        //###########################################END TEXTBOX txtCapacity EVENTS################################################

        //#############################################TEXTBOX txtClassroom EVENTS################################################
        //event is raised when the control is validated
        private void txtClassroomCodeValidated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtClassroomCode.Text))
            {
                _roomInfo.ClassroomCode = RemoteClient.ProcStatic.TrimStartEndString(txtClassroomCode.Text);
            }
        } //---------------------------------
        //############################################END TEXTBOX txtClassroom EVENTS#############################################

        //##########################################TEXTBOX txtDescription EVENTS#################################################
        //event is raised when the control is validated
        private void txtDescriptionValidated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDescription.Text))
            {
                _roomInfo.Description = RemoteClient.ProcStatic.TrimStartEndString(txtDescription.Text);
            }
        } //---------------------------------
        //########################################END TEXTBOX txtDescription EVENTS###############################################

        //#################################################TEXTBOX txtOtherInformation EVENTS#####################################
        //event is raised when the control is validated
        private void txtOtherInfoValidated(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtOtherInfo.Text))
            {
                _roomInfo.OtherInformation = RemoteClient.ProcStatic.TrimStartEndString(txtOtherInfo.Text);
            }
        } //------------------------------------
        //##############################################END TEXTBOX txtOtherInformation EVENTS####################################
        #endregion

        #region Programmer-Defined Function Procedures
        //this function validates the controls
        protected Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetIconAlignment(txtClassroomCode, ErrorIconAlignment.MiddleLeft);
            _errProvider.SetError(txtClassroomCode, "");
            _errProvider.SetIconAlignment(txtCapacity, ErrorIconAlignment.MiddleLeft);
            _errProvider.SetError(txtCapacity, "");

            if (String.IsNullOrEmpty(_roomInfo.ClassroomCode))
            {
                _errProvider.SetError(txtClassroomCode, "A classroom code is required.");
                isValid = false;
            }
            else
            {
                if (_courseManager.IsExistCodeClassroomInformation(_userInfo, _roomInfo.ClassroomCode, _roomInfo.ClassroomSysId))
                {
                    _errProvider.SetError(txtClassroomCode, "The classroom code already exists.");
                    isValid = false;
                }
            }

            if (_roomInfo.MaximumCapacity <= 0)
            {
                _errProvider.SetError(txtCapacity, "A classroom maximum capacity must be greater than zero.");
                isValid = false;
            }
            
            return isValid;
        }
        #endregion

    }
}
