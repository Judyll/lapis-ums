using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OfficeServices
{
    partial class StudentScholarshipCreate
    {
        #region Class Properties Declarations
        private Boolean _hasCreated = false;
        public Boolean HasCreated
        {
            get { return _hasCreated; }
        }
        #endregion

        #region Class  Constructors
        public StudentScholarshipCreate(CommonExchange.SysAccess userInfo, ScholarshipLogic scholarshipManager)
            : base(userInfo,  scholarshipManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _scholarshipManager = scholarshipManager;

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnCancel.Click += new EventHandler(btnCancelClick);
            this.btnCreate.Click += new EventHandler(btnCreateClick);
        }
        #endregion

        #region Class Event Void Procedures
        //###############################################CLASS ScholarshipCreate EVENTS##################################################
        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasCreated)
            {
                String strMsg = "Are you sure you want to cancel the creation of a new student scholarship information?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//------------------------
        //###############################################END CLASS ScholarshipCreate EVENTS##################################################

        //###############################################BUTTON btnCancel EVENTS##################################################
        //event is raised when the class is closing
        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }//------------------------
        //###############################################END BUTTON btnCancel EVENTS##################################################

        //###############################################BUTTON btnCreate EVENTS##################################################
        //event is raised when the class is closing
        private void btnCreateClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to create the new student scholarship information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Create", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The student scholarship information has been successfully created.";

                        this.Cursor = Cursors.WaitCursor;

                        _scholarshipManager.InsertStudentScholarship(_userInfo, _studentScholarshipInfo);

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasCreated = true;

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
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }
        }//---------------------
        //###############################################BUTTON btnCreate EVENTS##################################################
        #endregion
    }
}
