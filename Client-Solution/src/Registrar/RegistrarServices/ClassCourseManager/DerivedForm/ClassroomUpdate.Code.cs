using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RegistrarServices
{
    partial class ClassroomUpdate
    {
        #region Class General Variable Declarations
        private CommonExchange.ClassroomInformation _roomInfoTemp;
        #endregion

        #region Class Properties Declarations
        private Boolean _hasUpdated = false;
        public Boolean HasUpdated
        {
            get { return _hasUpdated; }
        }
        #endregion

        #region Class Constructor
        public ClassroomUpdate(CommonExchange.SysAccess userInfo, CommonExchange.ClassroomInformation roomInfo,
                                    CourseLogic courseManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _roomInfo = roomInfo;
            _roomInfoTemp = (CommonExchange.ClassroomInformation)roomInfo.Clone();
            _courseManager = courseManager;

            this.Load += new EventHandler(ClassLoad);
            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);
        }

        #endregion

        #region Class Event Void Procedures

        //########################################CLASS ClassroomUpdate EVENTS####################################################
        //event is raised when the class is loaded
        private void ClassLoad(object sender, EventArgs e)
        {
            lblSysID.Text = _roomInfo.ClassroomSysId;
            txtClassroomCode.Text = _roomInfo.ClassroomCode;
            txtDescription.Text = _roomInfo.Description;
            txtCapacity.Text = _roomInfo.MaximumCapacity.ToString();
            txtOtherInfo.Text = _roomInfo.OtherInformation;

        } //----------------------------

        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_hasUpdated && !_roomInfo.Equals(_roomInfoTemp))
            {
                String strMsg = "There has been changes made in the current classroom information. \nExiting will not save this changes." +
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
                    String strMsg = "Are you sure you want to update the classroom information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The classroom information has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _courseManager.UpdateClassroomInformation(_userInfo, _roomInfo);

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
