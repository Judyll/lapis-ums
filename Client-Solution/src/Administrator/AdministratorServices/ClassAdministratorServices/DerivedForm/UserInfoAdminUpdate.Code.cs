using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AdministratorServices
{
    partial class UserInfoAdminUpdate
    {
        #region Class Data Member Declaration
        private CommonExchange.SysAccess _newUserInfoTemp;
        #endregion

        #region Class Properties Declaration
        private Boolean _hasUpdated = false;
        public Boolean HasUpdated
        {
            get { return _hasUpdated; }
        }

        private Boolean _exitUMS = false;
        public Boolean ExitUMS
        {
            get { return _exitUMS; }
        }
        #endregion

        #region Class Constructors
        public UserInfoAdminUpdate(CommonExchange.SysAccess userInfo, AdministrtationLogic administarationManager, CommonExchange.SysAccess newUserInfo)
            : base(userInfo, administarationManager)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _administarationManager = administarationManager;
            _newUserInfo = newUserInfo;
            _newUserInfoTemp = (CommonExchange.SysAccess)newUserInfo.Clone();
            
            _errProvider = new ErrorProvider();

            this.FormClosing += new FormClosingEventHandler(ClassClosing);
            this.btnClose.Click += new EventHandler(btnCloseClick);
            this.txtLastName.KeyUp += new KeyEventHandler(textBoxKeyUp);
            this.txtFirstName.KeyUp += new KeyEventHandler(textBoxKeyUp);
            this.btnUpdate.Click += new EventHandler(btnUpdateClick);
        }
        #endregion

        #region Class Event Void Procedures
        //###############################################CLASS UserInfoAdminUpdate EVENTS##################################################
        //event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            try
            {
                if (!RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo))
                {
                    throw new Exception("You are not authorized to access this module.");
                }
            }
            catch (Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
                this.Close();
            }
            
            this.lnkPersonArchive.Visible = false;

            _baseServiceManager = new BaseServices.BaseServicesLogic(_userInfo);

            _personInfo = _newUserInfo.PersonInfo;

            this.AssingControlsValue();
            this.SetPersonInformationControls(true);

            this.SetDataGridViewColumns();
        
            this.txtUserName.Text = _newUserInfo.UserName;
            this.txtPassword.Text = this.txtConfirmPassword.Text = _newUserInfo.Password;

            if (_newUserInfo.UserStatus)
            {
                this.lblStatus.Text = "ACTIVE";
                this.lblStatus.ForeColor = Color.Green;
            }
            else
            {
                this.lblStatus.Text = "DEACTIVATED";
                this.lblStatus.ForeColor = Color.Red;
            }

            _administarationManager.InitializeAccessRightsDataGridView(this.dgvList, _newUserInfo.AccessRightsGrantedList);
        }//------------------------
        //###############################################END CLASS UserInfoAdminUpdate EVENTS##################################################

        //###############################################CLASS UserInfoAdminUpdate EVENTS##################################################
        //event is raised when the class is closing
        private void ClassClosing(object sender, FormClosingEventArgs e)
        {
            this.UpdateUserAccessRights();

            if (!_hasUpdated && !_newUserInfo.Equals(_newUserInfoTemp))
            {
                String strMsg = "There has been changes made in the current user information. \nExiting will not save this changes." +
                              "\n\nAre you sure you want to exit?";

                DialogResult msgResutl = MessageBox.Show(strMsg, "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                                                                                    
                if (msgResutl == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }//----------------------
        //###############################################END CLASS UserInfoAdminUpdate EVENTS##################################################

        //###############################################BUTTON btnClose EVENTS##################################################
        //event is raised when the control is clicked
        private void btnCloseClick(object sender, EventArgs e)
        {
            this.Close();
        }//---------------------
        //###############################################END BUTTON btnClose EVENTS##################################################

        //###############################################TEXTBOX EVENTS##################################################
        //event is raised when the key is up
        private void textBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                this.btnUpdate.Enabled = false;

                this.lblInfo.Visible = this.lnkVerify.Enabled = true;
            }
        }//----------------------
        //###############################################END TEXTBOX EVENTS##################################################

        //###############################################LINKLABEL lblVerify EVENTS##################################################
        //event is raised when the control is clicked
        protected override void lnkVerifyLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            base.lnkVerifyLinkClicked(sender, e);

            this.btnUpdate.Enabled = this.IsVerifiedUpdatedName;

            this.lblInfo.Visible = this.btnUpdate.Enabled ? false : true;
        }//---------------------
        //###############################################END LINKLABEL lblVerify EVENTS##################################################       
            
        //###############################################BUTTON btnUpdate EVENTS##################################################
        //event is raised when the control is clicked
        private void btnUpdateClick(object sender, EventArgs e)
        {
            this.UpdateUserAccessRights();

            if (this.ValidateControls() && this.ValidateControlsUser() && !_hasErrors)
            {
                try
                {
                    String strMsg = "Are you sure you want to update the user information?";

                    DialogResult msgResult = MessageBox.Show(strMsg, "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (msgResult == DialogResult.Yes)
                    {                        
                        strMsg = "The user information has been successfully updated.";

                        this.Cursor = Cursors.WaitCursor;

                        _newUserInfo.ObjectState = _newUserInfo.Equals(_newUserInfoTemp) ? DataRowState.Unchanged : DataRowState.Modified;

                        _personInfo.ObjectState = _personInfo.Equals(_newUserInfoTemp.PersonInfo) ? DataRowState.Unchanged : DataRowState.Modified;
                        _newUserInfo.PersonInfo = _personInfo;                       

                        _administarationManager.UpdateSystemUserInfo(_userInfo, _newUserInfo);

                        this.Cursor = Cursors.Arrow;

                        if (!String.Equals(_userInfo.UserId, _newUserInfo.UserId))
                        {
                            MessageBox.Show(strMsg, "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                            _exitUMS = false;
                        }
                        else
                        {
                            MessageBox.Show(strMsg + "\n\nWhen click OK, the system will exit and you must login again."
                                , "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                            _exitUMS = true;
                        }

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
                    RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error in Creating");
                }
                finally
                {
                    this.Cursor = Cursors.Arrow;
                }
            }
        }//---------------------
        //###############################################END BUTTON btnUpdate EVENTS##################################################
        #endregion

        #region Programmer-Defined Void Procedures
        //this procedure will update user access rights
        private void UpdateUserAccessRights()
        {
            Int32 index = 0;
            
            foreach (DataGridViewRow dgvRow in this.dgvList.Rows)
            {
                this.SetDataGridViewDoEvents(index);

                if ((Boolean)dgvRow.Cells["checkbox_column"].Value && dgvRow.Cells["department_name"].Value != null)
                {
                    Boolean isExist = false;
                    Int32 accessCount = 0;

                    foreach (CommonExchange.AccessRightsGranted list in _newUserInfo.AccessRightsGrantedList)
                    {
                        if (String.Equals(_administarationManager.GetAccessRights(index), list.AccessRightsInfo.AccessRights) &&
                            !String.Equals(_administarationManager.GetDepartmentId(dgvRow.Cells["department_name"].Value.ToString()),
                            list.DepartmentInfo.DepartmentId))
                        {
                            _newUserInfo.AccessRightsGrantedList[accessCount].DepartmentInfo.DepartmentId =
                                _administarationManager.GetDepartmentId(dgvRow.Cells["department_name"].Value.ToString());
                            _newUserInfo.AccessRightsGrantedList[accessCount].ObjectState = DataRowState.Modified;

                            isExist = true;
                        }
                        else if (String.Equals(_administarationManager.GetAccessRights(index), list.AccessRightsInfo.AccessRights))
                        {
                            isExist = true;
                        }

                        accessCount++;
                    }

                    if (!isExist)
                    {
                        CommonExchange.AccessRightsGranted list = new CommonExchange.AccessRightsGranted();

                        list.AccessRightsInfo.AccessRights = _administarationManager.GetAccessRights(index);
                        list.DepartmentInfo.DepartmentId = _administarationManager.GetDepartmentId(dgvRow.Cells["department_name"].Value.ToString());
                        list.ObjectState = DataRowState.Added;

                        _newUserInfo.AccessRightsGrantedList.Add(list);
                    }
                }
                else if (!(Boolean)dgvRow.Cells["checkbox_column"].Value)
                {
                    Int32 count = 0;

                    foreach (CommonExchange.AccessRightsGranted list in _newUserInfo.AccessRightsGrantedList)
                    {
                        if (String.Equals(_administarationManager.GetAccessRights(index), list.AccessRightsInfo.AccessRights))
                        {
                            list.ObjectState = DataRowState.Deleted;

                            break;
                        }

                        count++;
                    }
                }

                index++;

                Application.DoEvents();
                this.Refresh();
            }
        }//-------------------------------------
        #endregion
    }
}
