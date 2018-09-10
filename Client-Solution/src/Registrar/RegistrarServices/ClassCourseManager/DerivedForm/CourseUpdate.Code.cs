using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RegistrarServices
{
    partial class CourseUpdate
    {
        #region Class General Variable Declarations
        private CommonExchange.CourseInformation _courseInfoTemp;
        #endregion

        #region Class Properties Declarations
        private Boolean _hasUpdated = false;
        public Boolean HasUpdated
        {
            get { return _hasUpdated; }
        }
        #endregion

        #region Class Constructor
        public CourseUpdate(CommonExchange.SysAccess userInfo, CommonExchange.CourseInformation courseInfo,
                                    CourseLogic courseManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _courseInfo = courseInfo;
            _courseInfoTemp = (CommonExchange.CourseInformation)courseInfo.Clone();
            _courseManager = courseManager;

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);
        }

        #endregion

        #region Class Event Void Procedures

        //########################################CLASS ClassroomUpdate EVENTS####################################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            lblSysID.Text = _courseInfo.CourseId;
            txtTitle.Text = _courseInfo.CourseTitle;
            txtAcronym.Text = _courseInfo.Acronym;

            if (RemoteServerLib.ProcStatic.IsSystemAccessHighSchoolGradeSchoolRegistrar(_userInfo))
            {
                this.btnUpdate.Enabled = false;
            }

        } //----------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasUpdated && !_courseInfo.Equals(_courseInfoTemp))
            {
                String strMsg = "There has been changes made in the current course information. \nExiting will not save this changes." +
                                "\n\nAre you sure you want to exit?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        } //----------------------------------
        //######################################END CLASS ClassroomUpdate EVENTS##################################################

        //#########################################BUTTON btnClose EVENTS##################################################
        //event is raised when the button is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        } //------------------------------------------
        //#######################################END BUTTON btnClose EVENTS#################################################

        //###########################################BUTTON btnUpdate EVENTS#####################################################
        //event is raised when the button is clicked
        private void btnUpdateClick(object sender, EventArgs e)
        {
            if (this.ValidateControls())
            {
                try
                {
                    String strMsg = "Are you sure you want to update the course information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The course information has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        this.Cursor = Cursors.Arrow;

                        MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        _hasUpdated = true;

                        this.Close();
                    }
                    else if (msgResult == DialogResult.Cancel)
                    {
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Updating");
                }
            }
        } //------------------------------
        //##########################################END BUTTON btnUpdate EVENTS##################################################

        #endregion
    }
}
