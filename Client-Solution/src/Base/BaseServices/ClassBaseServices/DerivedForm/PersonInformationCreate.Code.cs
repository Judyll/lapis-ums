using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BaseServices
{
    partial class PersonInformationCreate
    {
        #region Class Properties Declaration

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

        #region Class Contructors
        public PersonInformationCreate(CommonExchange.SysAccess userInfo, BaseServices.BaseServicesLogic baseServiceManager)
            : base(userInfo)
        {
            this.InitializeComponent();

            _personInfo = new CommonExchange.Person();
            _baseServiceManager = baseServiceManager;

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnRecord.Click += new EventHandler(btnRecordClick);
        }

        public PersonInformationCreate(CommonExchange.SysAccess userInfo, CommonExchange.Person personInfo, BaseServices.BaseServicesLogic baseServiceManager)
            : base(userInfo)
        {
            this.InitializeComponent();

            _personInfo = personInfo;
            _baseServiceManager = baseServiceManager;

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnRecord.Click += new EventHandler(btnRecordClick);
        }
        #endregion

        #region Class Event Void Procedures
        //##################################CLASS PersonInformationCreate EVENTS########################################
        //event is raised when the colass is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            base.AssingControlsValue();
        }//------------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasRecorded)
            {
                String strMsg = "Are you sure you want to cancel the creation of a new person?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//--------------------
        //##################################END CLASS PersonInformationCreate EVENTS########################################

        //##############################################TEXTBOXES EVENTS####################################################################
        //event is raised when the key is pressed
        protected override void TextBoxKeyPressLettersOnly(object sender, KeyPressEventArgs e)
        {
            base.TextBoxKeyPressLettersOnly(sender, e);

            this.btnRecord.Enabled = false;
        }//-----------------------
        //##############################################END TEXTBOXES EVENTS####################################################################

        //####################################################LINKLABEL lnkVerify EVENTS###############################################
        //event is raised when the control is clicked
        protected override void lnkVerifyLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            base.IsForPersonVerification = true;

            base.lnkVerifyLinkClicked(sender, e);

            this.btnRecord.Enabled = base.IsVerifiedUpdatedName ? true : false;
        }//----------------------
        //####################################################END LINKLABEL lnkVerify EVENTS###############################################

        //##################################BUTTON btnClose EVENTS########################################
        //event is raised whent the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//--------------------
        //##################################END BUTTON btnClose EVENTS########################################

        //##################################BUTTON btnRecord EVENTS########################################
        //event is raised whent the control is clicked
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

                        _personInfo.ObjectState = System.Data.DataRowState.Added;

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
        }//--------------------
        //##################################END BUTTON btnRecord EVENTS########################################
        #endregion
    }
}
