using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BaseServices
{
    partial class PersonRelationshipUpdate
    {
        #region Class Data Member Declaration
        private CommonExchange.PersonRelationship _personRelationshipInfoTemp;
        #endregion

        #region Class Properties Declarations
        private Boolean _hasUpdated = false;
        public Boolean HasUpdated
        {
            get { return _hasUpdated; }
        }

        private Boolean _hasDeleted = false;
        public Boolean HasDeleted
        {
            get { return _hasDeleted; }
        }
        #endregion

        #region Class Constructors
        public PersonRelationshipUpdate(CommonExchange.SysAccess userInfo, BaseServicesLogic baseServiceManager,
            CommonExchange.PersonRelationship personRelationshipInfo, String personSysId)
            : base(userInfo, baseServiceManager, personSysId)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _baseServiceManager = baseServiceManager;
            _personRelationshipInfo = personRelationshipInfo;
            _personRelationshipInfoTemp = (CommonExchange.PersonRelationship)personRelationshipInfo.Clone();

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);
            this.btnDelete.Click += new EventHandler(btnDeleteClick);
        }
        #endregion

        #region Class Event Void Procedures
        //#####################################CLASS PersonRelationshipUpdate EVENTS########################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            _baseServiceManager.InitializePersonRelationshipTypeCombo(this.cboRelationshipType, _personRelationshipInfo.RelationshipTypeInfo.RelationshipTypeId);

            this.lblPersonLastName.Text = _personRelationshipInfo.PersonInRelationshipWith.LastName;
            this.lblPersonFirstName.Text = _personRelationshipInfo.PersonInRelationshipWith.FirstName;
            this.lblPersonMiddleName.Text = _personRelationshipInfo.PersonInRelationshipWith.MiddleName;
            this.lblPresentAddress.Text = _personRelationshipInfo.PersonInRelationshipWith.PresentAddress;
            this.lblPresentPhoneNo.Text = _personRelationshipInfo.PersonInRelationshipWith.PresentPhoneNos;

            if (!String.IsNullOrEmpty(_personRelationshipInfo.PersonInRelationshipWith.FilePath) && 
                File.Exists(_personRelationshipInfo.PersonInRelationshipWith.FilePath))
            {
                this.pbxPerson.Image = Image.FromFile(_personRelationshipInfo.PersonInRelationshipWith.FilePath);
            }

            this.chkEmergencyContact.Checked = _personRelationshipInfo.IsEmergencyContact;

            this.lnkViewFullDetails.Enabled = true;
            this.btnSearchPerson.Visible = false;
        }//-----------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if ((!_hasUpdated || !_hasDeleted) && !_personRelationshipInfo.Equals(_personRelationshipInfoTemp))
            {
                String strMsg = "There has been changes made in the current person relationship information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//-----------------------------
        //#####################################END CLASS PersonRelationshipUpdate EVENTS########################################

        //#####################################BUTTON btnClose EVENTS########################################
        //event is raised when the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//-----------------------------
        //#####################################END BUTTON btnClose EVENTS########################################

        //#####################################BUTTON btnUpdate EVENTS########################################
        //event is raised when the control is clicked
        private void btnUpdateClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to update the person relationship?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The person relationship has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _personRelationshipInfo.ObjectState = DataRowState.Modified;

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdated = _hasDeleted = true;

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
        //#####################################END BUTTON btnUpdate EVENTS########################################

        //#####################################BUTTON btnDelete EVENTS########################################
        //event is raised when the control is clicked
        private void btnDeleteClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to delete the person relationship?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The person relationship has been successfully deleted.";

                        this.Cursor = Cursors.WaitCursor;

                        _personRelationshipInfo.ObjectState = DataRowState.Deleted;

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdated = _hasDeleted = true;

                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Deleting");
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
