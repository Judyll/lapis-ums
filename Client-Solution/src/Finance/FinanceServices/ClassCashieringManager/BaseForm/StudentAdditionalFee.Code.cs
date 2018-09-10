using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class StudentAdditionalFee
    {
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _userInfo;
        private CommonExchange.Student _studentInfo;
        private CommonExchange.StudentAdditionalFee _studentAdditionalFeeInfo;
        private CommonExchange.StudentAdditionalFee _studentAdditionalFeeInfoTemp;
        private CashieringLogic _cashieringManager;

        private Int32 _index;

        private String _dateStart;
        private String _dateEnd;

        private Boolean _hasUpdatedForClosing = false;

        #region Class Properties Declaration
        private Boolean _hasUpDated = false;
        public Boolean HasUpDated
        {
            get { return _hasUpDated; }
        }

        private Boolean _hasDeleted = false;
        public Boolean HasDeleted
        {
            get { return _hasDeleted; }
            set { _hasDeleted = value; }
        }
        #endregion

        private ErrorProvider _errProvider;
        #endregion

        #region Class Constructors
        public StudentAdditionalFee(CommonExchange.SysAccess userInfo, CashieringLogic cashieringManager, Int32 index,
            String dateStart, String dateEnd)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _cashieringManager = cashieringManager;
            _index = index;
            _dateStart = dateStart;
            _dateEnd = dateEnd;

            _errProvider = new ErrorProvider();

            this.Load += new EventHandler(ClassLoad);
            this.FormClosing += new FormClosingEventHandler(StudentAdditionalFeeFormClosing);
            this.txtAdditionalPaymentAmount.KeyPress += new KeyPressEventHandler(txtAmountKeyPress);
            this.txtAdditionalPaymentAmount.Validating += new System.ComponentModel.CancelEventHandler(txtAmountValidating);
            this.txtAdditionalPaymentAmount.Validated += new EventHandler(txtAmountValidated);
            this.txtAdditionalFeeRemarks.Validated += new EventHandler(txtAdditionalFeeRemarksValidated);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnSearchAdditionalFee.Click += new EventHandler(btnSearchAdditionalFeeClick);
            this.btnDeleteAdditionalPayment.Click += new EventHandler(btnDeleteAdditionalPaymentClick);
            this.btnUpdateAdditionalPayment.Click += new EventHandler(btnUpdateAdditionalPaymentClick);
        }
        #endregion

        #region Class Event Void Procedures
        //####################################CLASS StudentAdditionalFee EVENTS####################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            _studentInfo = new CommonExchange.Student();

            _studentInfo = _cashieringManager.GetDetailsStudentInformation(_userInfo, _index, Application.StartupPath.ToString());
           
            this.Text = "  " + RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(_studentInfo.PersonInfo.LastName, 
                _studentInfo.PersonInfo.FirstName, _studentInfo.PersonInfo.MiddleName);

            _studentAdditionalFeeInfo = _cashieringManager.GetDetailsStudentAdditionalFeeByStudent(_index);
            _studentAdditionalFeeInfoTemp = (CommonExchange.StudentAdditionalFee)_studentAdditionalFeeInfo.Clone();
           
            this.lblParticularDescription.Text = _studentAdditionalFeeInfo.SchoolFeeParticularInfo.ParticularDescription;
            this.txtAdditionalPaymentAmount.Text = _studentAdditionalFeeInfo.Amount.ToString("N");
            this.txtAdditionalFeeRemarks.Text = _studentAdditionalFeeInfo.Remarks;

            this.txtAdditionalPaymentAmount.Focus();

            this.IsRecordLocked();
        }//----------------

        //event is raised when the class is closing
        private void StudentAdditionalFeeFormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasUpdatedForClosing && !_studentAdditionalFeeInfo.Equals(_studentAdditionalFeeInfoTemp))
            {
                String strMsg = "There has been changes made in the current student additional fee module. \nExiting will not save this changes." +
                               "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//-----------------------
        //####################################END CLASS StudentAdditionalFee EVENTS####################################

        //###########################################TEXTBOX txtAmount EVENTS#####################################################
        //event is raised when the key is pressed
        private void txtAmountKeyPress(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxAmountOnly(e);
        }//----------------------

        //event is raised when the control is validating
        private void txtAmountValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxValidateAmount((TextBox)sender);
        }//---------------------        

        //event is raised when the control is validated
        private void txtAmountValidated(object sender, EventArgs e)
        {
            Decimal amount;

            if (Decimal.TryParse(txtAdditionalPaymentAmount.Text, out amount))
            {
                _studentAdditionalFeeInfo.Amount = amount;
            }
        }//-----------------------------
        //###########################################END TEXTBOX txtAmount EVENTS#####################################################        

        //####################################TEXTBOX txtAdditionalFeeRemarks EVENTS####################################
        //event is raised when the the control is validated
        private void txtAdditionalFeeRemarksValidated(object sender, EventArgs e)
        {
            _studentAdditionalFeeInfo.Remarks = RemoteClient.ProcStatic.TrimStartEndString(this.txtAdditionalFeeRemarks.Text);
        }//--------------------------
        //####################################END TEXTBOX txtAdditionalFeeRemarks EVENTS####################################

        //####################################BUTTON btnClose EVENTS####################################
        //event is raised when the the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//------------------------
        //####################################END BUTTON btnClose EVENTS####################################

        //####################################BUTTON btnSearchAdditionalFee EVENTS####################################
        //event is raised when the the control is clicked
        private void btnSearchAdditionalFeeClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            try
            {
                using (AdditionalFeeSearchOnTextBoxList frmSearch = new AdditionalFeeSearchOnTextBoxList(_cashieringManager))
                {
                    frmSearch.AdoptGridSize = false;
                    frmSearch.ShowDialog(this);

                    if (frmSearch.HasSelected)
                    {
                        CommonExchange.StudentAdditionalFee studentAdditionalFeeTemp = _cashieringManager.GetDetailsAdditionalFee(frmSearch.PrimaryId);

                        _studentAdditionalFeeInfo.SchoolFeeParticularInfo.FeeParticularSysId =
                            studentAdditionalFeeTemp.SchoolFeeParticularInfo.FeeParticularSysId;
                        _studentAdditionalFeeInfo.SchoolFeeParticularInfo.ParticularDescription =
                            studentAdditionalFeeTemp.SchoolFeeParticularInfo.ParticularDescription;

                        this.lblParticularDescription.Text = _studentAdditionalFeeInfo.SchoolFeeParticularInfo.ParticularDescription;
                        this.txtAdditionalPaymentAmount.Text = _studentAdditionalFeeInfo.Amount.ToString("N");

                        this.txtAdditionalPaymentAmount.Focus();
                        this.txtAdditionalPaymentAmount.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
            }

            this.Cursor = Cursors.Arrow;
        }//-----------------------------
        //####################################END BUTTON btnSearchAdditionalFee EVENTS####################################

        //####################################BUTTON btnUpdateAdditionalPayment EVENTS####################################
        //event is raised when the the control is clicked
        private void btnUpdateAdditionalPaymentClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateControls())
                {
                    String strMsg = "Are you sure you want to update the student additional payment?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student additional payment has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _cashieringManager.UpdateStudentAdditionalFee(_userInfo, _studentAdditionalFeeInfo, true);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpDated = true;

                        _hasUpdatedForClosing = true;

                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Recording");
            }
        }//----------------------------
        //####################################END BUTTON btnUpdateAdditionalPayment EVENTS####################################

        //####################################BUTTON btnDeleteAdditionalPayment EVENTS####################################
        //event is raised when the the control is clicked
        private void btnDeleteAdditionalPaymentClick(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateControls())
                {
                    String strMsg = "Are you sure you want to delete the student additional payment?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student additional payment has been successfully deleted.";

                        this.Cursor = Cursors.WaitCursor;

                        _cashieringManager.DeleteStudentAdditionalFee(_userInfo, _studentAdditionalFeeInfo, true);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasDeleted = true;

                        _hasUpdatedForClosing = true;

                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Recording");
            }
        }//---------------------------
        //####################################END BUTTON btnDeleteAdditionalPayment EVENTS####################################
        #endregion

        #region Programmer-Defined Functions
        //this procedure will set record locked controls
        private void IsRecordLocked()
        {
            //record locking for additional fee
            if (RemoteClient.ProcStatic.IsRecordLockForOptionalAdditionalDiscountFee(DateTime.Parse(_dateStart), DateTime.Parse(_dateEnd),
                DateTime.Parse(_cashieringManager.ServerDateTime), (Int32)CommonExchange.SystemRange.MonthAllowance, false,
                _studentAdditionalFeeInfo.StudentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.IsCurrentCourse, false, true, false))
            {
                this.lblStatus.Text = "This record is LOCKED";

                this.pbxLocked.Visible = this.txtAdditionalPaymentAmount.ReadOnly = true;
                this.pbxUnlock.Visible = this.btnSearchAdditionalFee.Visible = false;

                this.btnUpdateAdditionalPayment.Enabled = this.btnDeleteAdditionalPayment.Enabled = false;
            }
            else
            {
                this.lblStatus.Text = "This record is OPEN";

                this.pbxLocked.Visible = false;
                this.pbxUnlock.Visible = true;

                this.btnUpdateAdditionalPayment.Enabled = this.btnDeleteAdditionalPayment.Enabled = true;
            }
            //----------------------          
        }//--------------------------
        #endregion

        #region Programmer-Defined Functions
        //this fucntion will validate controls student additional fee
        private Boolean ValidateControls()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.lblParticularDescription, "");
            _errProvider.SetError(this.txtAdditionalPaymentAmount, "");

            if (String.IsNullOrEmpty(_studentAdditionalFeeInfo.SchoolFeeParticularInfo.FeeParticularSysId))
            {
                _errProvider.SetError(this.lblParticularDescription, "You must select an additional fee.");
                _errProvider.SetIconAlignment(this.lblParticularDescription, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            if (_studentAdditionalFeeInfo.Amount <= 0)
            {
                _errProvider.SetError(this.txtAdditionalPaymentAmount, "Amount must be greater than zero.");
                _errProvider.SetIconAlignment(this.txtAdditionalPaymentAmount, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            return isValid;
        }//---------------------
        #endregion
    }
}
