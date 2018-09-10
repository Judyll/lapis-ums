using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EmployeeServices
{
    partial class ViewUpdateEarningDeduction
    {
        #region Class General Variable Declarations
        private ErrorProvider errProvider = new ErrorProvider();
        #endregion

        #region Class Properties Declarations
        protected Boolean _hasUpdated = false;
        public Boolean HasUpdated
        {
            get { return _hasUpdated; }
        }
        #endregion

        #region Class Constructor
        public ViewUpdateEarningDeduction()
        {
            InitializeComponent();

            this.txtAmount.KeyPress += new KeyPressEventHandler(txtAmountKeyPress);
            this.txtAmount.Validating += new System.ComponentModel.CancelEventHandler(txtAmountValidating);
            this.btnDelete.Click += new EventHandler(btnDeleteClick);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);
            this.btnClose.Click += new EventHandler(btnCloseClick);
        }       

        
        #endregion

        #region Class Event Void Procedures

        //########################################TEXTBOX txtAmount EVENTS###########################################################
        //event is raised when the key is pressed
        private void txtAmountKeyPress(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxAmountOnly(e);

        } //----------------------------------

        //event is raised when the control is validating
        private void txtAmountValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxValidateAmount((TextBox)sender);
        } //-----------------------------------------
        //#######################################END TEXTBOX txtAmount EVENTS########################################################

        //#############################################BUTTON btnClose EVENTS###########################################################
        //event is raised when the button is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        } //-----------------------------------
        //##########################################END BUTTON btnClose EVENTS###########################################################

        //################################################BUTTON btnDelete EVENTS##########################################################
        //event is raised when the button is clicked
        protected virtual void btnDeleteClick(object sender, EventArgs e)
        {
            
        } //----------------------------------------
        //##############################################END BUTTON btnDelete EVENTS########################################################

        //################################################BUTTON btnUpdate EVENTS##########################################################
        //event is raised when the button is clicked
        protected virtual void btnUpdateClick(object sender, EventArgs e)
        {
            
        } //----------------------------------------
        //###############################################END BUTTON btnUpdate EVENTS########################################################
        #endregion

        #region Programmer-Defined Function Procedures

        //this function validates the controls
        protected Boolean ValidateControls()
        {
            Boolean isValid = true;

            errProvider.SetIconAlignment(txtAmount, ErrorIconAlignment.MiddleLeft);
            errProvider.SetError(txtAmount, "");

            Decimal amount = 0;

            if (!Decimal.TryParse(txtAmount.Text, out amount) || amount == 0)
            {
                errProvider.SetError(txtAmount, "An amount is required or the amount should not be equal to zero.");
                isValid = false;
            }

            return isValid;

        } //-------------------------
        #endregion
    }
}
