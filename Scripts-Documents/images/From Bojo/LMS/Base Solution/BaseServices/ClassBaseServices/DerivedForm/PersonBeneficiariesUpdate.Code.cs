using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;

namespace BaseServices
{
    partial class PersonBeneficiariesUpdate
    {
        #region Class Data Member Decleration
        private CommonExchange.PersonBeneficiary _personBeneficiaryInfoTemp;
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
        public PersonBeneficiariesUpdate(CommonExchange.SysAccess userInfo, CommonExchange.PersonBeneficiary personBeneficiaryInfo,
            BaseServicesLogic baseServiceManager, String personSysIdList)
            : base(userInfo, baseServiceManager, personSysIdList)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _baseServiceManager = baseServiceManager;
            _personBeneficiaryInfo = personBeneficiaryInfo;
            _personBeneficiaryInfoTemp = (CommonExchange.PersonBeneficiary)personBeneficiaryInfo.Clone();

            this.FormClosing += new FormClosingEventHandler(ClassClossing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);
            this.btnDelete.Click += new EventHandler(btnDeleteClick);
        }
        #endregion

        #region Class Event Void Procedures
        //#####################################CLASS PersonBeneficiariesUpdate EVENTS########################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            _baseServiceManager.InitializePersonRelationshipTypeCombo(this.cboRelationshipType, _personBeneficiaryInfo.RelationshipTypeInfo.RelationshipTypeId);

            this.lblPersonLastName.Text = _personBeneficiaryInfo.PersonInRelationshipWith.LastName;
            this.lblPersonFirstName.Text = _personBeneficiaryInfo.PersonInRelationshipWith.FirstName;
            this.lblPersonMiddleName.Text = _personBeneficiaryInfo.PersonInRelationshipWith.MiddleName;
            this.lblPresentAddress.Text = _personBeneficiaryInfo.PersonInRelationshipWith.PresentAddress;
            this.lblPresentPhoneNo.Text = _personBeneficiaryInfo.PersonInRelationshipWith.PresentPhoneNos;

            this.chkPrimaryBeneficiary.Checked = _personBeneficiaryInfo.IsPrimaryBeneficiary;

            this.lnkViewFullDetails.Enabled = true;
            this.btnSearchPerson.Visible = false;
        }//---------------------------

        //event is raised when the class is clossing
        private void ClassClossing(object sender, FormClosingEventArgs e)
        {
            if ((!_hasUpdated || !_hasDeleted) && !_personBeneficiaryInfo.Equals(_personBeneficiaryInfoTemp))
            {
                String strMsg = "There has been changes made in the current person relationship information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//--------------------------
        //#####################################END CLASS PersonBeneficiariesUpdate EVENTS########################################

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

                        _personBeneficiaryInfo.ObjectState = DataRowState.Modified;

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdated = _hasDeleted = true;

                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    ProcStatic.ShowErrorDialog(ex.Message, "Error Updating");
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

                        _personBeneficiaryInfo.ObjectState = DataRowState.Deleted;

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdated = _hasDeleted = true;

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
