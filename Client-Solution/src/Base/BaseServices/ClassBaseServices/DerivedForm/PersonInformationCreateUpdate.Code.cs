using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace BaseServices
{
    partial class PersonInformationCreateUpdate
    {
        #region Class Data Member Declaration
        private CommonExchange.Person _personInfoTemp;
        #endregion

        #region Class Properties Declatation
        private Boolean _hasRecorded = false;
        public Boolean HasRecorded
        {
            get { return _hasRecorded; }
        }

        public Boolean SetRecordButtonEnable
        {
            set { this.btnRecord.Enabled = value; }
        }
        #endregion

        #region Class Constructors
        public PersonInformationCreateUpdate(CommonExchange.SysAccess userInfo)
            : base(userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;

            _baseServiceManager = new BaseServicesLogic(_userInfo);
            _personInfo = new CommonExchange.Person();
            _personInfo.ObjectState = DataRowState.Added;

            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnRecord.Click += new EventHandler(btnRecordClick);
        }

        public PersonInformationCreateUpdate(CommonExchange.SysAccess userInfo, CommonExchange.Person personInfo)
            : base(userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _personInfo = _personInfoTemp = personInfo;
            _personInfo.ObjectState = DataRowState.Modified;

            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnRecord.Click += new EventHandler(btnRecordClick);
        }

        public PersonInformationCreateUpdate(CommonExchange.SysAccess userInfo, CommonExchange.Person personInfo, BaseServices.BaseServicesLogic baseServiceManager)
            : base(userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _baseServiceManager = baseServiceManager;
            _personInfo = _personInfoTemp = personInfo;
            _personInfo.ObjectState = DataRowState.Modified;

            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnRecord.Click += new EventHandler(btnRecordClick);
        }
        #endregion

        #region Class Event Void Procedures
        //####################################################CLASS PersonalInformationCreate EVENTS###############################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.AssingControlsValue();

            _errProvider = new ErrorProvider();

            _baseServiceManager.InitializeCodeReferenceCombo(this.cboGender, CommonExchange.CodeEntityId.Gender);
            _baseServiceManager.InitializeCodeReferenceCombo(this.cboLifeStatus, CommonExchange.CodeEntityId.LifeStatus);
            _baseServiceManager.InitializeCodeReferenceCombo(this.cboMaritalStatus, CommonExchange.CodeEntityId.MaritalStatus);

            _baseServiceManager.InitializePersonRelationshipDataGridView(this.dgvRelationship, _personInfo.PersonRelationshipList, lblEmerStatus);

            RemoteClient.ProcStatic.SetDataGridViewColumns(this.dgvRelationship, false);

        }//---------------------------
        //####################################################END CLASS PersonalInformationCreate EVENTS###############################################

        //##############################################TEXTBOXES EVENTS####################################################################
        //event is raised when the key is pressed
        protected override void TextBoxKeyPressLettersOnly(object sender, KeyPressEventArgs e)
        {
            base.TextBoxKeyPressLettersOnly(sender, e);

            this.btnRecord.Enabled = false;
        }//-----------------------
        //##############################################END TEXTBOXES EVENTS####################################################################

        //####################################################BUTTON bntClose EVENTS###############################################
        //event is raised when the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//-------------------------
        //####################################################END BUTTON bntClose EVENTS###############################################

        //####################################################BUTTON btnCreate EVENTS###############################################
        //event is raised when the control is clicked
        private void btnRecordClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    String strMsg = "Are you sure you whant to record a new person information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The person information has been successfully recorded.";

                        this.Cursor = Cursors.WaitCursor;

                        _baseServiceManager.InsertUpdatePersonInformation(_userInfo, ref _personInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasRecorded = true;

                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message + "\n\nError Recording Person Information", "Error Recording");
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }
        }//---------------------------
        //####################################################END BUTTON btnCreate EVENTS###############################################
        #endregion
    }
}
