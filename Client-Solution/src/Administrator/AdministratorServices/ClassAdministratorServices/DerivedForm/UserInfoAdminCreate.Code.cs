using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace AdministratorServices
{
    partial class UserInfoAdminCreate
    {
        #region Class Properties Declarations
        private Boolean _isForUserUpdate = false;
        public Boolean IsForUserUpdate
        {
            get { return _isForUserUpdate; }
        }

        private Boolean _hasCreated = false;
        public Boolean HasCreated
        {
            get { return _hasCreated; }
        }
        #endregion

        #region Class Constructors
        public UserInfoAdminCreate(CommonExchange.SysAccess userInfo, AdministrtationLogic administarationManager)
            : base(userInfo, administarationManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _administarationManager = administarationManager;

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnCancel.Click += new EventHandler(btnCancelClick);
            this.btnCreate.Click += new EventHandler(btnCreateClick);
        }
        #endregion

        #region Class Event Void Procedures 
        //###############################################CLASS UserInfoAdminCreate EVENTS##################################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            base.ClassLoad(sender, e);

            _newUserInfo.ObjectState = DataRowState.Added;
        }//-------------------
        //###############################################END CLASS UserInfoAdminCreate EVENTS##################################################

        //###############################################CLASS UserInformationCreate EVENTS##################################################
        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isForUserUpdate && !_hasCreated)
            {
                String strMsg = "Are you sure you want to cancel the creation of a new user information?";
                DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (msgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//--------------------------
        //###############################################END CLASS UserInformationCreate EVENTS##################################################

        //###############################################BUTTON btnClose EVENTS##################################################
        private void btnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }//---------------------
        //##############################################END BUTTON btnClose EVENTS##################################################

        //################################################BUTTON btnCreate EVENTS####################################################
        //event is raised when btnCreate is Clicked
        private void btnCreateClick(object sender, EventArgs e)
        {
            this.InsertUserAccessRights();

            if (this.ValidateControls() && this.ValidateControlsUser())
            {
                try
                {
                    String strMsg = "Are you sure you want to create the new user information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Create", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {
                        strMsg = "The new user information has been successfully created.";

                        this.Cursor = Cursors.WaitCursor;

                        _personInfo.ObjectState = DataRowState.Added;
                        _newUserInfo.PersonInfo = _personInfo;
                        _newUserInfo.ObjectState = DataRowState.Added;

                        _administarationManager.InsertSystemUserInfo(_userInfo, _newUserInfo);

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
        //################################################END BUTTON btnCreate EVENTS####################################################

        //#########################################LINLLABEL lnkPersonArchive EVENTS###########################################################
        //event is raised when the control is clicked
        protected override void lnkPersonArchiveLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            base.lnkPersonArchiveLinkClicked(sender, e);

            if (_newUserInfo != null && !String.IsNullOrEmpty(_newUserInfo.UserId))
            {
                _isForUserUpdate = true;

                this.Close();
            }
            else
            {
                if (base.HasSelectedForPersonUpdate)
                {
                    if (this.pbxPerson.Image != null)
                    {
                        this.pbxPerson.Image.Dispose();
                        this.pbxPerson.Image = null;
                    }

                    GC.SuppressFinalize(this);
                    GC.Collect();

                    _personInfo = _baseServiceManager.GetPersonDetails(_userInfo,
                                 _baseServiceManager.GetPersonSysId(_rowIndexForPersonSearch), Application.StartupPath);

                    base.AssingControlsValue();
                    base.SetPersonInformationControls(true);

                    this.btnCreate.Enabled = true;
                }
            }
        }//-------------------------
        //#########################################END LINLLABEL lnkPersonArchive EVENTS###########################################################
        #endregion

        #region Programmer-Defined Void Procedures
        //this procedure will insert user access rights
        private void InsertUserAccessRights()
        {
            Int32 index = 0;

            _newUserInfo.AccessRightsGrantedList.Clear();

            foreach (DataGridViewRow dgvRow in this.dgvList.Rows)
            {
                this.SetDataGridViewDoEvents(index);

                if ((Boolean)dgvRow.Cells["checkbox_column"].Value && dgvRow.Cells["department_name"].Value != null)
                {
                    CommonExchange.AccessRightsGranted list = new CommonExchange.AccessRightsGranted();

                    list.AccessRightsInfo.AccessRights = _administarationManager.GetAccessRights(index);
                    list.DepartmentInfo.DepartmentId = _administarationManager.GetDepartmentId(dgvRow.Cells["department_name"].Value.ToString());
                    list.ObjectState = DataRowState.Added;

                    _newUserInfo.AccessRightsGrantedList.Add(list);
                }

                index++;

                Application.DoEvents();
                this.Refresh();
            }
        }//----------------------------
        #endregion
    }
}
