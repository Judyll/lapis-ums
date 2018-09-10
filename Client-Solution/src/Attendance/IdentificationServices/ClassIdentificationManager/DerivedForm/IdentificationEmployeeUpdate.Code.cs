using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace IdentificationServices
{
    partial class IdentificationEmployeeUpdate : IDisposable
    {
        #region Class General Variable Declaration
        private CommonExchange.Employee _employeeInfoTemp;
        #endregion

        #region Class Properties Declaration
        private Boolean _hasUpDated = false;
        public Boolean HasUpDated
        {
            get { return _hasUpDated; }
        }
        #endregion

        #region Class Constructor and Distructor

        public IdentificationEmployeeUpdate(CommonExchange.SysAccess userInfo,CommonExchange.Employee employeeInfo,
            IdentificationLogic identificationManager)
            : base(userInfo,identificationManager)
        {
            this.InitializeComponent();

            _employeeInfo = employeeInfo;
            _employeeInfoTemp = (CommonExchange.Employee)employeeInfo.Clone();

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(IdentificationEmployeeUpdateFormClosing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);
        }

        void IDisposable.Dispose()
        {
            if (pbxPhoto.Image != null)
            {
                pbxPhoto.Image.Dispose();
                pbxPhoto.Image = null;

                pbxPhoto.Dispose();
                pbxPhoto = null;
            }

            GC.SuppressFinalize(this);
            GC.Collect();
        }

        #endregion

        #region Class Event Void Procedures

        //###########################################CLASS IDENTIFICATIONEMPLOYEEUPDATE ClassLoad EVENTS#####################################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            _studentInfo = new CommonExchange.Student();

            this.txtIdName.Text = _employeeInfo.EmployeeId;
            this.txtName.Text = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(_employeeInfo.PersonInfo.LastName, 
                _employeeInfo.PersonInfo.FirstName, _employeeInfo.PersonInfo.MiddleName);
            this.txtTypeName.Text = _employeeInfo.SalaryInfo.DepartmentInfo.DepartmentName;
            this.txtAddressName.Text = _employeeInfo.PersonInfo.PresentAddress;

            CommonExchange.PersonRelationship emrContact = _identificationManager.GetPersonEmergencyContact(_employeeInfo.PersonInfo.PersonRelationshipList);

            this.txtEmerName.Text = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(emrContact.PersonInRelationshipWith.LastName,
                emrContact.PersonInRelationshipWith.FirstName, emrContact.PersonInRelationshipWith.MiddleName);
            this.txtEmerAddress.Text = emrContact.PersonInRelationshipWith.PresentAddress;
            this.txtEmerPhone.Text = emrContact.PersonInRelationshipWith.PresentPhoneNos;
            this.txtRelationship.Text = emrContact.RelationshipTypeInfo.RelationshipDescription;

            this.txtCardNumber.Text = _employeeInfo.CardNumber;

            if (!String.IsNullOrEmpty(_employeeInfo.PersonInfo.FilePath))
            {
                this.pbxPhoto.Image = Image.FromFile(_employeeInfo.PersonInfo.FilePath);
            }
        }
        
        //event is raised when the form is closing
        private void IdentificationEmployeeUpdateFormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (!_hasUpDated && !_employeeInfo.Equals(_employeeInfoTemp))
            {
                String strMsg = "There has been changes made in the current student information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";

                DialogResult msgResutl = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResutl == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//---------------------
        //###########################################END CLASS IDENTIFICATIONEMPLOYEEUPDATE ClassLoad EVENTS#####################################################
        
        //########################################BUTTON btnClose EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//--------------------
        //########################################END BUTTON btnClose EVENTS#####################################################

        //########################################BUTTON btnUpdate EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnUpdateClick(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to update the employee information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The employee information has been successfully updated.";
                                                             
                        this.Cursor = Cursors.WaitCursor;

                        _identificationManager.UpdateForIdMakerEmployeeInformation(_userInfo, _employeeInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpDated = true;

                        this.Close();
                    }
                    else if (msgResult == DialogResult.Cancel)
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Updating");
                }
            }
        }//----------------
        //########################################END BUTTON btnUpdate EVENTS#####################################################

        #endregion

        #region Programer-Defined Void Procedures

        //this procedure will Validate controls
        private Boolean ValidateControls()
        {
            Boolean isValid = true;

            ErrorProvider errProvider = new ErrorProvider();

            errProvider.SetError(grpCardNUmber, "");


            if (String.IsNullOrEmpty(_employeeInfo.CardNumber))
            {
                errProvider.RightToLeft = true;
                errProvider.SetError(grpCardNUmber, "Card Number is required.");
                this.txtCardNumber.Focus();

                isValid = false;
            }

            if (_identificationManager.IsExistCardNumber(_userInfo, _employeeInfo.CardNumber, _employeeInfo.EmployeeSysId, false))
            {
                errProvider.RightToLeft = true;
                errProvider.SetError(grpCardNUmber, "Card Number is already exist.");
                this.txtCardNumber.Focus();

                isValid = false;
            }

            return isValid;
        }//---------------------

        #endregion
    }
}
