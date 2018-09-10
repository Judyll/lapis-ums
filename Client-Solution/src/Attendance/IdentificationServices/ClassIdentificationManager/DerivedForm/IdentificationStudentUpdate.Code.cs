using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace IdentificationServices
{
    partial class IdentificationStudentUpdate : IDisposable
    {

        #region Class General Variable Declaration
        private CommonExchange.Student _studentInfoTemp;
        #endregion

        #region Class Properties Declaration
        private Boolean _hasUpDated = false;
        public Boolean HasUpDated
        {
            get { return _hasUpDated; }
        }
        #endregion

        #region Constructor and Distructor

        public IdentificationStudentUpdate(CommonExchange.SysAccess userInfo,CommonExchange.Student studentInfo ,
            IdentificationLogic identificationManager)
            :base(userInfo,identificationManager)
        {
            this.InitializeComponent();

            _studentInfo = studentInfo;
            _studentInfoTemp = (CommonExchange.Student)studentInfo.Clone();

            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(IdentificationStudentUpdateFormClosing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);

            if (!String.IsNullOrEmpty(_studentInfo.PersonInfo.FilePath))
            {
                this.pbxPhoto.Image = Image.FromFile(_studentInfo.PersonInfo.FilePath);
            }
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

        //###########################################CLASS IDENTIFICATIONSTUDENTUPDATE ClassLoad EVENTS#####################################################
        //event is raised when the class is loaded
        protected override void  ClassLoad(object sender, EventArgs e)
        {
            _employeeInfo = new CommonExchange.Employee();

            this.txtIdName.Text = _studentInfo.StudentId;
            this.txtName.Text = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(_studentInfo.PersonInfo.LastName, 
                _studentInfo.PersonInfo.FirstName, _studentInfo.PersonInfo.MiddleName);
            this.txtTypeName.Text = _studentInfo.CourseInfo.CourseTitle;
            this.txtAddressName.Text = _studentInfo.PersonInfo.PresentAddress;
            
            CommonExchange.PersonRelationship emrContact = _identificationManager.GetPersonEmergencyContact(_studentInfo.PersonInfo.PersonRelationshipList);

            this.txtEmerName.Text = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(emrContact.PersonInRelationshipWith.LastName,
                  emrContact.PersonInRelationshipWith.FirstName, emrContact.PersonInRelationshipWith.MiddleName);
            this.txtEmerAddress.Text = emrContact.PersonInRelationshipWith.PresentAddress;
            this.txtEmerPhone.Text = emrContact.PersonInRelationshipWith.PresentPhoneNos;
            this.txtRelationship.Text = emrContact.RelationshipTypeInfo.RelationshipDescription;

            this.txtCardNumber.Text = _studentInfo.CardNumber;

            if (!String.IsNullOrEmpty(_studentInfo.PersonInfo.FilePath))
            {
                this.pbxPhoto.Image = Image.FromFile(_studentInfo.PersonInfo.FilePath);
            }
        }

        //event is raised when the Form is Closing
        private void IdentificationStudentUpdateFormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (!_hasUpDated && !_studentInfo.Equals(_studentInfoTemp))
            {
                String strMsg = "There has been changes made in the current student information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";

                DialogResult msgResutl = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResutl == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }            
        }//-----------------------
        //###########################################END CLASS IDENTIFICATIONSTUDENTUPDATE ClassLoad EVENTS##################

        //########################################BUTTON btnClose EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//----------------------
        //########################################BUTTON btnClose EVENTS#####################################################

        //########################################BUTTON btnUpdate EVENTS#####################################################
        //event is raised when the control is clicked
        private void btnUpdateClick(object sender, EventArgs e)
        {
            if (ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to update the student information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student information has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _identificationManager.UpdateForIdMakerStudentInformation(_userInfo, _studentInfo);

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
        }//-----------------------
        //########################################END BUTTON btnUpdate EVENTS#####################################################

        #endregion

        #region Programer-Define Void Procedures

        //this Procedure will Validate Controls
        private Boolean ValidateControls()
        {
            Boolean isValid = true;

            ErrorProvider errProvider = new ErrorProvider();

            errProvider.SetError(grpCardNUmber, "");

            if (String.IsNullOrEmpty(_studentInfo.CardNumber))
            {
                errProvider.RightToLeft = true;
                errProvider.SetError(grpCardNUmber, "Card Number is required.");
                this.txtCardNumber.Focus();

                isValid = false;
            }

            if (_identificationManager.IsExistCardNumber(_userInfo, _studentInfo.CardNumber, _studentInfo.StudentSysId, true))
            {
                errProvider.RightToLeft = true;
                errProvider.SetError(grpCardNUmber, "Card Number is already exist.");
                this.txtCardNumber.Focus();

                isValid = false;
            }

            return isValid;
        }

        #endregion
    }
}
