using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class StudentGuidanceUpdate
    {
        #region Class Data Member Declaration
        private CommonExchange.Student _studentInfo;
        private CommonExchange.Student _studentInfoTemp;
        private StudentLogic _studentManager;

        private Boolean _hasEnter = false;
        #endregion

        #region Class Properties Declaration
        private Boolean _hasUpDated = false;
        public Boolean HasUpDated
        {
            get { return _hasUpDated; }
        }
        #endregion

        #region Class Constructors
        public StudentGuidanceUpdate()
        {
            this.InitializeComponent();
        }

        public StudentGuidanceUpdate(CommonExchange.SysAccess userInfo, CommonExchange.Student studentInfo, StudentLogic studentManager) 
            : base(userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _studentInfo = studentInfo;

            _studentInfo.ObjectState = System.Data.DataRowState.Modified;

            _studentInfoTemp = (CommonExchange.Student)_studentInfo.Clone();

            _studentManager = studentManager;

            _errProvider = new ErrorProvider();

            this.txtStudentOtherInformation.Validated += new EventHandler(txtStudentOtherInformationValidated);
            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.chkForm138.CheckedChanged += new EventHandler(chkForm138CheckedChanged);
            this.chkHonorableDismissal.CheckedChanged += new EventHandler(chkHonorableDismissalCheckedChanged);
            this.chkTranscriptOfRecords.CheckedChanged += new EventHandler(chkTranscriptOfRecordsCheckedChanged);
            this.chkGoodMoral.CheckedChanged += new EventHandler(chkGoodMoralCheckedChanged);
            this.chkBirthCertificate.CheckedChanged += new EventHandler(chkBirthCertificateCheckedChanged);
            this.chkMarriageContract.CheckedChanged += new EventHandler(chkMarriageContractCheckedChanged);
            this.chkPhoto.CheckedChanged += new EventHandler(chkPhotoCheckedChanged);
            this.chkNCAE.CheckedChanged += new EventHandler(chkNCAECheckedChanged);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);
        }
        #endregion

        #region Class Event Void Procedures
        //#########################################CLASS Student EVENTS###########################################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.lnkPersonArchive.Visible = this.lnkVerify.Enabled = false;

            _baseServiceManager = new BaseServices.BaseServicesLogic(_userInfo);

            _personInfo = _studentInfo.PersonInfo;

            this.AssingControlsValue();
            this.SetPersonInformationControls(true);

            if (!_hasEnter && _studentInfo.Equals(_studentInfoTemp))
            {
                _baseServiceManager.InitializePersonRelationshipDataGridView(this.dgvRelationship, _personInfo.PersonRelationshipList, this.lblEmerStatus);

                RemoteClient.ProcStatic.SetDataGridViewColumns(this.dgvRelationship, false);

                _hasEnter = true;
            }

            this.lblStdStudentId.Text = _studentInfo.StudentId;
            this.lblStdLastName.Text = _studentInfo.PersonInfo.LastName;
            this.lblStdFirstName.Text = _studentInfo.PersonInfo.FirstName;
            this.lblMiddleName.Text = _studentInfo.PersonInfo.MiddleName;
            this.lblStdCourse.Text = _studentInfo.CourseInfo.CourseTitle;
            this.lblStdScholarship.Text = _studentInfo.Scholarship;
            this.chkIsInternational.Checked = _studentInfo.IsInternational;
            this.txtStudentOtherInformation.Text = _studentInfo.OtherStudentInformation;

            this.chkForm138.Checked = _studentInfo.HasHsCard;
            this.chkTranscriptOfRecords.Checked = _studentInfo.HasTor;
            this.chkHonorableDismissal.Checked = _studentInfo.HasHonDismissal;
            this.chkGoodMoral.Checked = _studentInfo.HasGoodMoral;
            this.chkBirthCertificate.Checked = _studentInfo.HasBirthCert;
            this.chkMarriageContract.Checked = _studentInfo.HasMarriageContract;
            this.chkPhoto.Checked = _studentInfo.HasLatestPhoto;
            this.chkNCAE.Checked = _studentInfo.HasNcaeResult;

        }//--------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasUpDated && !_studentInfo.Equals(_studentInfoTemp))
            {
                String strMsg = "There has been changes made in the current student information. \nExiting will not save this changes." +
                            "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//-------------------------
        //#########################################END CLASS Student EVENTS###########################################################

        //#########################################CHECKBOX chkNCAE EVENTS###########################################################
        //event is raised when the control checked change
        private void chkNCAECheckedChanged(object sender, EventArgs e)
        {
            _studentInfo.HasNcaeResult = this.chkNCAE.Checked;
        }//---------------------------
        //#########################################END CHECKBOX chkNCAE EVENTS###########################################################

        //#########################################CHECKBOX chkPhoto EVENTS###########################################################
        //event is raised when the control checked change
        private void chkPhotoCheckedChanged(object sender, EventArgs e)
        {
            _studentInfo.HasLatestPhoto = this.chkPhoto.Checked;
        }//----------------------------
        //#########################################END CHECKBOX chkPhoto EVENTS###########################################################

        //#########################################CHECKBOX chkMarriageContract EVENTS###########################################################
        //event is raised when the control checked change
        private void chkMarriageContractCheckedChanged(object sender, EventArgs e)
        {
            _studentInfo.HasMarriageContract = this.chkMarriageContract.Checked;
        }//---------------
        //#########################################END CHECKBOX chkMarriageContract EVENTS###########################################################

        //#########################################CHECKBOX chkBirthCertificate EVENTS###########################################################
        //event is raised when the control checked change
        private void chkBirthCertificateCheckedChanged(object sender, EventArgs e)
        {
            _studentInfo.HasBirthCert = this.chkBirthCertificate.Checked;
        }//---------------------------
        //#########################################END CHECKBOX chkBirthCertificate EVENTS###########################################################

        //#########################################CHECKBOX chkGoodMoral EVENTS###########################################################
        //event is raised when the control checked change
        private void chkGoodMoralCheckedChanged(object sender, EventArgs e)
        {
            _studentInfo.HasGoodMoral = this.chkGoodMoral.Checked;
        }//-----------------------------
        //#########################################END CHECKBOX chkGoodMoral EVENTS###########################################################

        //#########################################CHECKBOX chkTranscriptOfRecords EVENTS###########################################################
        //event is raised when the control checked change
        private void chkTranscriptOfRecordsCheckedChanged(object sender, EventArgs e)
        {
            _studentInfo.HasTor = this.chkTranscriptOfRecords.Checked;
        }//------------------------------
        //#########################################END CHECKBOX chkTranscriptOfRecords EVENTS###########################################################

        //#########################################CHECKBOX chkHonorableDismissal EVENTS###########################################################
        //event is raised when the control checked change
        private void chkHonorableDismissalCheckedChanged(object sender, EventArgs e)
        {
            _studentInfo.HasHonDismissal = this.chkHonorableDismissal.Checked;
        }//-------------------------------
        //#########################################END CHECKBOX chkHonorableDismissal EVENTS###########################################################

        //#########################################CHECKBOX chkForm138 EVENTS###########################################################
        //event is raised when the control checked change
        private void chkForm138CheckedChanged(object sender, EventArgs e)
        {
            _studentInfo.HasHsCard = this.chkForm138.Checked;
        }//-------------------------------
        //#########################################END CHECKBOX chkForm138 EVENTS###########################################################

        //#########################################TEXTBOX txtStudentOtherInformation EVENTS###########################################################
        //event is raised when the control is validated
        private void txtStudentOtherInformationValidated(object sender, EventArgs e)
        {
            _studentInfo.OtherStudentInformation = RemoteClient.ProcStatic.TrimStartEndString(this.txtStudentOtherInformation.Text);
        }//-------------------------
        //#########################################END TEXTBOX txtStudentOtherInformation EVENTS###########################################################

        //#########################################BUTTON btnClose EVENTS###########################################################
        //event is raised when the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//----------------------
        //#########################################END BUTTON btnClose EVENTS###########################################################

        //#########################################BUTTON btnUpdate EVENTS###########################################################
        //event is raised when the control is clicked
        private void btnUpdateClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to update the student information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student information has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _personInfo.ObjectState = System.Data.DataRowState.Modified;
                        _studentInfo.PersonInfo = _personInfo;

                        DataTable tempTable = new DataTable("");

                        _studentManager.UpdateStudentInformation(_userInfo, _studentInfo, false, ref tempTable);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpDated = true;

                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Updating");
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }
        }//-------------------------
        //#########################################END BUTTON btnUpdate EVENTS###########################################################

        //Disable Verify Existence if the function is for update student
        ////#########################################LINLLABEL lnkVerified EVENTS###########################################################
        ////event is raised when the control is clicked
        //protected override void lnkVerifyLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    base.IsForStudentVerification = true;
        //    base.IsForPersonVerification = true;

        //    base.lnkVerifyLinkClicked(sender, e);

        //    this.btnUpdate.Enabled = base.IsVerifiedUpdatedName ? true : false;

        //    if (base.HasSelectedPersonFromVerification)
        //    {
        //        if (!String.IsNullOrEmpty(_studentInfo.StudentSysId))
        //        {
        //            base.AssingControlsValue();
        //        }
        //    }
        //}//------------------------
        ////#########################################END LINLLABEL lnkVerified EVENTS###########################################################

        //Disable Verify Existence if the function is for update student
        ////#########################################TEXTBOX txtName EVENTS###########################################################
        ////event is raised when the control is clicked
        //protected override void TextBoxKeyPressLettersOnly(object sender, KeyPressEventArgs e)
        //{
        //    base.TextBoxKeyPressLettersOnly(sender, e);

        //    this.btnUpdate.Enabled = false;
        //}//------------------------
        ////#########################################END TEXTBOX txtName EVENTS###########################################################
        #endregion
    }
}
