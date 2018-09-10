using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace BaseServices
{
    partial class PersonReferenceCreate
    {
        #region Class Properties Declarations
        private Boolean _hasAdded = false;
        public Boolean HasAdded
        {
            get { return _hasAdded; }
        }
        #endregion

        #region Class Constructors
        public PersonReferenceCreate(CommonExchange.SysAccess userInfo, BaseServicesLogic baseServicesManager, String sysIdPersonExcludeList)
            : base(userInfo, baseServicesManager, sysIdPersonExcludeList)
        {
            this.InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(ClassClossing);
            this.btnCancel.Click += new EventHandler(btnCancelClick);
            this.btnAdd.Click += new EventHandler(btnAddClick);
        }
        #endregion

        #region Class Event Void Procedures
        //#####################################CLASS PersonReferenceCreate EVENTS########################################
        //event is raised when the class is closing
        private void ClassClossing(object sender, FormClosingEventArgs e)
        {
            if (!_hasAdded)
            {
                String strMsg = "Are you sure you want to cancel the creation of a new person reference information?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//------------------------------------
        //#####################################END  CLASS PersonReferenceCreate EVENTS########################################

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
                    String strMsg = "Are you sure you want to add a new person reference?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The person reference has been successfully added.";

                        this.Cursor = Cursors.WaitCursor;

                        _personReferenceInfo.ObjectState = DataRowState.Added;

                        _personReferenceInfo.ReferenceId = _baseServiceManager.ReferenceIdCount - 1;

                        _baseServiceManager.ReferenceIdCount = _personReferenceInfo.ReferenceId;

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
