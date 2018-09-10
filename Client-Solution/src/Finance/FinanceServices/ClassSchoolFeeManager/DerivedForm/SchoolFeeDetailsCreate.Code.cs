using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FinanceServices
{
    internal partial class SchoolFeeDetailsCreate
    {
        #region Class Properties Declarations
        private Boolean _hasCreated = false;
        public Boolean HasCreated
        {
            get { return _hasCreated; }
        }
        #endregion

        #region Class Constructors
        public SchoolFeeDetailsCreate()
        {
            this.InitializeComponent();
        }

        public SchoolFeeDetailsCreate(CommonExchange.SysAccess userInfo, SchoolFeeLogic schoolFeeManager, String yearId,
            String courseGroupId, String yearLevelId, String feeLevelSysId)
            : base(userInfo, schoolFeeManager, yearId, courseGroupId, yearLevelId, feeLevelSysId)
        {
            this.InitializeComponent();

            _isForCreate = true;

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnCancel.Click += new EventHandler(btnCancelClick);
            this.btnCreate.Click += new EventHandler(btnCreateClick);
        }     

        #endregion

        #region Class Event Void Procedures
        //############################################CLASS SchoolFeeDetailsCreate EVENTS#######################################################
        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasCreated)
            {
                String strMsg = "Are you sure you want to cancel the creation of a new school fee details?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//---------------------------      
        //############################################END CLASS SchoolFeeDetailsCreate EVENTS#######################################################

        //############################################BUTTON btnClose EVENTS#######################################################
        //event is raised when the control is clicked
        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }//---------------------------
        //############################################END BUTTON btnClose EVENTS#######################################################

        //############################################BUTTON btnCreate EVENTS#######################################################
        //event is raised when the control is loaded
        private void btnCreateClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to create the new school fee details?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Create", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The school fee details has been successfully created.";

                        this.Cursor = Cursors.WaitCursor;

                        _schoolFeeManager.InsertSchoolFeeDetails(_detailsInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasCreated = true;

                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Creating");
                }
            }
        }//------------------------------
        //############################################END BUTTON btnCreate EVENTS#######################################################
        #endregion

    }
}
