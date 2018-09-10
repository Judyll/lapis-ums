using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EmployeeServices
{
    partial class LoanType
    {
        #region Class General Variable Declarations
        protected CommonExchange.SysAccess _userInfo;
        protected LoanRemittanceLogic _loanManager;
        protected CommonExchange.LoanInformation _loanInfo;

        private ErrorProvider _errProvider = new ErrorProvider();
        #endregion

        #region Class Constructor
        public LoanType()
        {
            InitializeComponent();
        }
        #endregion

        #region Programmer-Defined Function Procedures

        //this procedure validates the controls
        protected Boolean ValidateLoanControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(txtDescription, "");

            if (String.IsNullOrEmpty(txtDescription.Text.Trim()))
            {
                _errProvider.SetError(txtDescription, "A loan type description is required.");
                isValid = false;
            }

            if (_loanManager.IsLoanTypeDescriptionExist(_userInfo, txtDescription.Text, _loanInfo.LoanSysId))
            {
                _errProvider.SetError(txtDescription, "The loan type description already exist.");
                isValid = false;
            }

            return isValid;
        } //---------------------------        

        #endregion
    }
}
