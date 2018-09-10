using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace EmployeeServices
{
    partial class EarningDeduction
    {
        #region Class General Variable Declarations
        protected CommonExchange.SysAccess _userInfo;
        protected DeductionLogic _decManager;
        protected EarningLogic _incManager;
        protected CommonExchange.DeductionInformation _deductionInfo;
        protected CommonExchange.EarningInformation _earningInfo;

        private ErrorProvider _errProvider = new ErrorProvider();
        #endregion

        #region Class Constructor
        public EarningDeduction()
        {
            InitializeComponent();
        }
        #endregion

        #region Programmer-Defined Function Procedures

        //this procedure validates the controls
        protected Boolean ValidateDeductionControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(txtDescription, "");

            if (String.IsNullOrEmpty(txtDescription.Text.Trim()))
            {
                _errProvider.SetError(txtDescription, "A deduction description is required.");
                isValid = false;
            }

            if (_decManager.IsDeductionDescriptionExist(_userInfo, RemoteClient.ProcStatic.TrimStartEndString(txtDescription.Text), _deductionInfo.DeductionSysId))
            {
                _errProvider.SetError(txtDescription, "The deduction description already exist.");
                isValid = false;
            }

            return isValid;
        } //---------------------------

        //this procedure validates the controls
        protected Boolean ValidateEarningControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(txtDescription, "");

            if (String.IsNullOrEmpty(txtDescription.Text.Trim()))
            {
                _errProvider.SetError(txtDescription, "An earning description is required.");
                isValid = false;
            }

            if (_incManager.IsEarningDescriptionExist(_userInfo, RemoteClient.ProcStatic.TrimStartEndString(txtDescription.Text), _earningInfo.EarningSysId))
            {
                _errProvider.SetError(txtDescription, "The earning description already exist.");
                isValid = false;
            }

            return isValid;
        } //---------------------------

        #endregion

        
    }
}
