using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BaseServices
{
    partial class OfficeInformation
    {
        #region Class Data Member Decleration
        protected CommonExchange.SysAccess _userInfo;
        protected CommonExchange.OfficeEmployer _officeEmployerInfo;
        protected BaseServicesLogic _baseServicesManager;

        private ErrorProvider _errProvider;
        #endregion

        #region Class Constructos
        public OfficeInformation()
        {
            this.InitializeComponent();
        }

        public OfficeInformation(CommonExchange.SysAccess userInfo, BaseServicesLogic baseServicesManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _baseServicesManager = baseServicesManager;

            _errProvider = new ErrorProvider();

            this.Load += new EventHandler(ClassLoad);
            this.txtName.Validated += new EventHandler(txtNameValidated);
            this.txtAcronym.Validated += new EventHandler(txtAcronymValidated);
            this.txtAddress.Validated += new EventHandler(txtAddressValidated);
            this.txtPhoneNo.Validated += new EventHandler(txtPhoneNoValidated);
        }

        

        #endregion

        #region Class Event Void Procedures
        //####################################################CLASS OfficeInformation EVENTS###############################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            _officeEmployerInfo = new CommonExchange.OfficeEmployer();
        }//------------------------
        //####################################################END CLASS OfficeInformation EVENTS###############################################

        //####################################################TEXTBOX txtPhoneNo EVENTS###############################################
        //event is raised when the control is validated
        private void txtPhoneNoValidated(object sender, EventArgs e)
        {
            _officeEmployerInfo.OfficeEmployerPhoneNos = ProcStatic.TrimStartEndString(this.txtPhoneNo.Text);
        }//----------------------
        //####################################################END TEXTBOX txtPhoneNo EVENTS###############################################

        //####################################################TEXTBOX txtAddress EVENTS###############################################
        //event is raised when the control is validated
        private void txtAddressValidated(object sender, EventArgs e)
        {
            _officeEmployerInfo.OfficeEmployerAddress = ProcStatic.TrimStartEndString(this.txtAddress.Text);
        }//---------------------
        //####################################################END TEXTBOX txtAddress EVENTS###############################################

        //####################################################TEXTBOX txtAcronym EVENTS###############################################
        //event is raised when the control is validated
        private void txtAcronymValidated(object sender, EventArgs e)
        {
            _officeEmployerInfo.OfficeEmployerAcronym = ProcStatic.TrimStartEndString(this.txtAcronym.Text);
        }//-----------------------
        //####################################################END TEXTBOX txtAcronym EVENTS###############################################

        //####################################################TEXTBOX txtName EVENTS###############################################
        //event is raised when the control is validated
        private void txtNameValidated(object sender, EventArgs e)
        {
            _officeEmployerInfo.OfficeEmployerName = ProcStatic.TrimStartEndString(this.txtName.Text);
        }//-----------------------
        //####################################################END TEXTBOX txtName EVENTS###############################################
        #endregion

        #region Programmers-Defined Function
        //this fucntion will validate controls
        public Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.txtName, String.Empty);
            _errProvider.SetError(this.txtAcronym, String.Empty);


            if (String.IsNullOrEmpty(_officeEmployerInfo.OfficeEmployerName))
            {
                _errProvider.SetError(this.txtName, "Office/Employer name is required.");
                _errProvider.SetIconAlignment(this.txtName, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            if (_baseServicesManager.IsExistsNameOfficeEmployerInformation(_userInfo, _officeEmployerInfo.OfficeEmployerId, 
                _officeEmployerInfo.OfficeEmployerName))
            {
                _errProvider.SetError(this.txtName, "Office/Employer name already exist.");
                _errProvider.SetIconAlignment(this.txtName, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            if (_baseServicesManager.IsExistsAcronymOfficeEmployerInformation(_userInfo, _officeEmployerInfo.OfficeEmployerId,
                _officeEmployerInfo.OfficeEmployerAcronym))
            {
                _errProvider.SetError(this.txtAcronym, "Office/Employer acronum already exist.");
                _errProvider.SetIconAlignment(this.txtAcronym, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            return isValid;
        }//------------------
        #endregion
    }
}
