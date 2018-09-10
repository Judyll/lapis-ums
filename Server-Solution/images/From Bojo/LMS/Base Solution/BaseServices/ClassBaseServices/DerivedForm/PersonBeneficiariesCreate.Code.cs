using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace BaseServices
{
    partial class PersonBeneficiariesCreate
    {
        #region Class Properties Declarations
        private Boolean _hasAdded = false;
        public Boolean HasAdded
        {
            get { return _hasAdded; }
        }
        #endregion

        #region Class Constructors
        public PersonBeneficiariesCreate(CommonExchange.SysAccess userInfo, BaseServicesLogic baseServicesManager, String personSysIdList)
            : base(userInfo, baseServicesManager, personSysIdList)
        {
            this.InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnCancel.Click += new EventHandler(btnCancelClick);
            this.btnAdd.Click += new EventHandler(btnAddClick);
        }
        #endregion

        #region Class Event Void Procedures
        //#####################################CLASS PersonRelationshipCreate EVENTS########################################
        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasAdded)
            {
                String strMsg = "Are you sure you want to cancel the creation of a new person relationship information?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }            
        }//-----------------------
        //#####################################END CLASS PersonRelationshipCreate EVENTS########################################

        //################################################BUTTON btnCancel EVENTS####################################################
        //event is raised when btnCancel is Clicked
        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }//-----------------------
        //################################################END BUTTON btnCancel EVENTS####################################################

        //################################################BUTTON btnAdd EVENTS####################################################
        //event is raised when btnAdd is Clicked
        private void btnAddClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to add a new person relationship?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The person relationship has been successfully added.";

                        this.Cursor = Cursors.WaitCursor;

                        _personBeneficiaryInfo.ObjectState = DataRowState.Added;

                        _personBeneficiaryInfo.BeneficiaryId = _baseServiceManager.BeneficiaryIdCount - 1;

                        _baseServiceManager.BeneficiaryIdCount = _personBeneficiaryInfo.BeneficiaryId;

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasAdded = true;

                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    ProcStatic.ShowErrorDialog(ex.Message, "Error Adding");
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }
        }//--------------------
        //################################################END BUTTON btnAdd EVENTS####################################################
        #endregion
    }
}
