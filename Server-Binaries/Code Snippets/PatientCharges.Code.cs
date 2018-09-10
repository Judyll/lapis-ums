using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DentalLib
{
    partial class PatientCharges
    {
        #region Class Member Declarations
        protected CommonExchange.SysAccess _userInfo;        
        protected CommonExchange.Patient _patientInfo;
        protected CommonExchange.RegistrationDetails _detailsInfo;
        protected CommonExchange.Registration _regInfo;
        protected ChargesLogic _chargesManager;
        protected Boolean _hasErrors = false;

        private ErrorProvider _errProvider;

        #endregion

        #region Class Constructor
        public PatientCharges()
        {
            this.InitializeComponent();
        }

        public PatientCharges(CommonExchange.SysAccess userInfo, CommonExchange.Patient patientInfo, CommonExchange.Registration regInfo,
            ChargesLogic chargesManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _patientInfo = patientInfo;
            _regInfo = regInfo;
            _chargesManager = chargesManager;

            _errProvider = new ErrorProvider();

            this.Load += new EventHandler(ClassLoad);
            this.lnkChange.LinkClicked += new LinkLabelLinkClickedEventHandler(lnkChangeLinkClicked);
            this.btnSearch.Click += new EventHandler(btnSearchClick);
            this.txtAmount.KeyPress += new KeyPressEventHandler(txtAmountKeyPress);
            this.txtAmount.Validating += new System.ComponentModel.CancelEventHandler(txtAmountValidating);
            this.txtAmount.Validated += new EventHandler(txtAmountValidated);
            this.txtRemarks.Validated += new EventHandler(txtRemarksValidated);
            this.txtToothNo.Validated += new EventHandler(txtToothNoValidated);

        }       
        
        
        #endregion

        #region Class Event Void Procedures
        //############################################CLASS PatientCharges EVENTS#######################################################
        //event is raised when the class is loaded
        protected virtual void ClassLoad(object sender, EventArgs e)
        {
            if (!DatabaseLib.ProcStatic.IsSystemAccessAdmin(_userInfo) && !DatabaseLib.ProcStatic.IsSystemAccessDentalUser(_userInfo))
            {
                DentalLib.ProcStatic.ShowErrorDialog("You are not allowed to access this module.",
                    "Patient Charges");

                _hasErrors = true;

                this.Close();
            }
            else if (!DatabaseLib.ProcStatic.IsSystemAccessAdmin(_userInfo))
            {
                this.lnkChange.Visible = false;
            }

            _detailsInfo = new CommonExchange.RegistrationDetails();
            _detailsInfo.DateAdministered = _chargesManager.ServerDateTime;
            _detailsInfo.RegistrationSystemId = _regInfo.RegistrationSystemId;

            this.lblDate.Text = DateTime.Parse(_detailsInfo.DateAdministered).ToLongDateString();


        } //------------------------------------------------------------
        //############################################END CLASS PatientCharges EVENTS#######################################################

        //##############################################LINKBUTTON lnkChange EVENTS################################################################
        //event is raised when the link is clicked
        private void lnkChangeLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            DateTime bDate = DateTime.Parse(_detailsInfo.DateAdministered);

            using (DatePicker frmPicker = new DatePicker(bDate))
            {
                frmPicker.ShowDialog(this);

                if (frmPicker.HasSelectedDate)
                {
                    if (DateTime.TryParse(frmPicker.GetSelectedDate.ToShortDateString() + " " +
                        DateTime.Parse(_chargesManager.ServerDateTime).ToLongTimeString(), out bDate))
                    {
                        _detailsInfo.DateAdministered = bDate.ToString();
                    }

                    this.lblDate.Text = DateTime.Parse(_detailsInfo.DateAdministered).ToLongDateString();
                }
            }

            this.Cursor = Cursors.Arrow;

        } //-------------------------------
        //############################################END LINKBUTTON lnkChange EVENTS##############################################################

        //############################################BUTTON btnSearch EVENTS#####################################################################
        //event is raised when the button is clicked
        private void btnSearchClick(object sender, EventArgs e)
        {
            try
            {
                using (DentalLib.ProcedureSearchOnTextboxList frmProcedure = new DentalLib.ProcedureSearchOnTextboxList(_userInfo, false))
                {
                    frmProcedure.ShowDialog(this);

                    if (frmProcedure.HasSelected)
                    {
                        CommonExchange.Procedure procInfo = frmProcedure.ProcedureInformation;

                        _detailsInfo.ProcedureSystemId = procInfo.ProcedureSystemId;
                        _detailsInfo.ProcedureName = procInfo.ProcedureName;

                        this.lblProcedureId.Text = _detailsInfo.ProcedureSystemId;
                        this.lblProcedureName.Text = _detailsInfo.ProcedureName;

                        Decimal amount = 0;

                        if (Decimal.TryParse(procInfo.Amount.ToString(), out amount))
                        {
                            _detailsInfo.Amount = procInfo.Amount;

                            this.txtAmount.Text = _detailsInfo.Amount.ToString("N");
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                DentalLib.ProcStatic.ShowErrorDialog(ex.Message, "Procedure List Error");
            }
        } //----------------------------------------
        //##########################################END BUTTON btnSearch EVENTS####################################################################

        //############################################TEXTBOX txtAmount EVENTS####################################################################
        private void txtAmountValidated(object sender, EventArgs e)
        {
            Decimal result = 0;

            if (Decimal.TryParse(this.txtAmount.Text, out result))
            {
                _detailsInfo.Amount = result;
            }
            
        } //-------------------------------

        private void txtAmountValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DentalLib.ProcStatic.TextBoxValidateAmount((TextBox)sender);   
        }

        private void txtAmountKeyPress(object sender, KeyPressEventArgs e)
        {
            DentalLib.ProcStatic.TextBoxAmountOnly((TextBox)sender, e);
        }
        //#########################################END TEXTBOX txtAmount EVENTS###################################################################

        //###########################################TEXTBOX txtToothNo EVENTS####################################################################
        //event is raised when the control is validated
        private void txtToothNoValidated(object sender, EventArgs e)
        {
            _detailsInfo.ToothNo = DentalLib.ProcStatic.TrimStartEndString(this.txtToothNo.Text);
        }
        //##########################################END TEXTBOX txtToothNo EVENTS#################################################################

        //###########################################TEXTBOX txtRemarks EVENTS####################################################################
        //event is raised when the control is validated
        private void txtRemarksValidated(object sender, EventArgs e)
        {
            _detailsInfo.Remarks = DentalLib.ProcStatic.TrimStartEndString(this.txtRemarks.Text);
        } //-------------------------------
        //#########################################END TEXTBOX txtRemarks EVENTS###################################################################
        #endregion

        #region Programmer-Defined Function Procedures

        //this function determines if the controls are validated
        protected Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.btnSearch, "");
            _errProvider.SetError(this.txtAmount, "");

            if (String.IsNullOrEmpty(_detailsInfo.ProcedureSystemId) || String.IsNullOrEmpty(_detailsInfo.ProcedureName))
            {
                _errProvider.SetIconAlignment(this.btnSearch, ErrorIconAlignment.MiddleLeft);
                _errProvider.SetError(this.btnSearch, "Please select a procedure.");
                isValid = false;
            }


            if (_detailsInfo.Amount == 0)
            {
                _errProvider.SetIconAlignment(this.txtAmount, ErrorIconAlignment.TopLeft);
                _errProvider.SetError(this.txtAmount, "A charge amount is required.");
                isValid = false;
            }            

            return isValid;
        } //------------------------

        #endregion


    }
}
