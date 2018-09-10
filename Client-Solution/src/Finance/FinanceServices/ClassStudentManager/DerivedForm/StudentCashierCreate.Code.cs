using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FinanceServices
{
    partial class StudentCashierCreate
    {

        #region Class Properties Declarations
        private Boolean _hasCreated = false;
        public Boolean HasCreated
        {
            get { return _hasCreated; }
        }       
        #endregion

        #region Class Constructor
        public StudentCashierCreate(CommonExchange.SysAccess userInfo, StudentLogic studentManager, Boolean isForRegistrar)
            : base(userInfo, studentManager, isForRegistrar)
        {
            this.InitializeComponent();

            this.FormClosing += new FormClosingEventHandler(StudentCreateFormClosing);
            this.btnCancel.Click += new EventHandler(btnCancelClick);
            this.btnCreate.Click += new EventHandler(btnCreateClick);
        }
     
        #endregion

        #region Class Event Void Procedures

        //############################################CLASS ClassroomCreate EVENTS#######################################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            base.ClassLoad(sender, e);

            _studentManager.ClearCachedData();

            _studentInfo.ObjectState = System.Data.DataRowState.Added;
        }//------------------------ 
               
        //event is raised when the class is closing
        private void StudentCreateFormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isForUpdateStudent)
            {
                if (!_hasCreated || !_hasUpdatedCourseLevel)
                {
                    String strMsg = "Are you sure you want to cancel the creation of a new student information?";
                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.No)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        _studentManager.ClearCachedData();
                    }
                }
                else
                {
                    _studentManager.ClearCachedData();
                }
            }
        }//--------------------------
        //############################################END CLASS ClassroomCreate EVENTS#######################################################

        //########################################TEXTBOX txtName EVENTS##################################################
        //event is raised when the key is pressed
        protected override void textBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            base.textBoxKeyPress(sender, e);

            this.btnCreate.Enabled = _isVerified;
        }//-------------------------
        //########################################END TEXTBOX txtName EVENTS##################################################

        //########################################LINKLABEL lnkVerify EVENTS##################################################
        //event is raised when the linked is clicked
        protected override void lnkVerifyLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            base.lnkVerifyLinkClicked(sender, e);

            this.btnCreate.Enabled = _isVerified;
        }//----------------------
        //########################################END LINKLABEL lnkVerify EVENTS##################################################

        //##############################################BUTTON btnCancel EVENTS########################################################
        //event is raised when the button is clicked
        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }//-----------------------
        //##############################################END BUTTON btnCancel EVENTS########################################################

        //#############################################BUTTON btnCreate EVENTS########################################################
        //event is raised when the button is clicked
        private void btnCreateClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to create the new student information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Create", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student information has been successfully created.";

                        this.Cursor = Cursors.WaitCursor;

                        _studentInfo.PersonInfo.ObjectState = System.Data.DataRowState.Added;

                        _studentManager.InsertStudentInformation(_userInfo, ref _studentInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasCreated = _hasUpdatedCourseLevel = true;

                        this.Close();
                    }
                    else if (msgResult == DialogResult.Cancel)
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Creating");
                }
            }
        }//----------------------
        //#############################################END BUTTON btnCreate EVENTS########################################################

        #endregion
    }
}
