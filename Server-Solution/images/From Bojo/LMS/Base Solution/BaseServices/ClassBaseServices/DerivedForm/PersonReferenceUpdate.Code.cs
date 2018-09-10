using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace BaseServices
{
    partial class PersonReferenceUpdate
    {
        #region Class Data Member Decleration
        private CommonExchange.PersonReference _tempPersonReferenceInfo;
        #endregion

        #region Class Properties Declarations
        private Boolean _hasDeleted = false;
        public Boolean HasDeleted
        {
            get { return _hasDeleted; }
        }
        #endregion

        #region Class Constructors
        public PersonReferenceUpdate(CommonExchange.SysAccess userInfo, CommonExchange.PersonReference personReferenceInfo,
            BaseServicesLogic baseServicesManager, String sysIDPersonExcludeList)
            : base(userInfo, baseServicesManager, sysIDPersonExcludeList)
        {
            this.InitializeComponent();

            _baseServiceManager = baseServicesManager;
            _userInfo = userInfo;
            _personReferenceInfo = personReferenceInfo;
            _tempPersonReferenceInfo = (CommonExchange.PersonReference)personReferenceInfo.Clone();

            this.FormClosing += new FormClosingEventHandler(ClassClossing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnDelete.Click += new EventHandler(btnDeleteClick);
        }

       
        #endregion

        #region Class Event Void Procedures       
        //#####################################CLASS PersonReferenceUpdate EVENTS########################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            this.lblPersonLastName.Text = _personReferenceInfo.PersonInReferenceWith.LastName;
            this.lblPersonFirstName.Text = _personReferenceInfo.PersonInReferenceWith.FirstName;
            this.lblPersonMiddleName.Text = _personReferenceInfo.PersonInReferenceWith.MiddleName;
            this.lblPresentAddress.Text = _personReferenceInfo.PersonInReferenceWith.PresentAddress;
            this.lblPresentPhoneNo.Text = _personReferenceInfo.PersonInReferenceWith.PresentPhoneNos;

            this.lnkViewFullDetails.Enabled = true;
        }//----------------------

        //event is raised when the class is clossing
        private void ClassClossing(object sender, FormClosingEventArgs e)
        {
            if (!_hasDeleted && !_personReferenceInfo.Equals(_tempPersonReferenceInfo))
            {
                String strMsg = "There has been changes made in the current person reference information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//---------------------------
        //#####################################END CLASS PersonReferenceUpdate EVENTS########################################

        //#####################################BUTTON btnClose EVENTS########################################
        //event is raised when the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//-----------------------------
        //#####################################END BUTTON btnClose EVENTS########################################

        //#####################################BUTTON btnDelete EVENTS########################################
        //event is raised when the control is clicked
        private void btnDeleteClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to delete the person reference?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The person reference has been successfully deleted.";

                        this.Cursor = Cursors.WaitCursor;

                        _personReferenceInfo.ObjectState = DataRowState.Deleted;

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasDeleted = true;

                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    ProcStatic.ShowErrorDialog(ex.Message, "Error Deleting");
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }
        }//----------------------
        //#####################################END BUTTON btnDelete EVENTS########################################
        #endregion

    }
}
