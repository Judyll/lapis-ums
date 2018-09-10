using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AdministratorServices
{
    partial class UserInfoAdmin
    {
        #region Class Data Member Declaration
        protected AdministrtationLogic _administarationManager;

        protected Boolean _hasErrors = false;

        protected Int32 _rowIndexForPersonSearch = -1;
        #endregion

        #region Class Constructors
        public UserInfoAdmin()
        {
            this.InitializeComponent();
        }

        public UserInfoAdmin(CommonExchange.SysAccess userInfo, AdministrtationLogic administrationManager)
            : base(userInfo)
        {
            this.InitializeComponent();

            _userInfo = userInfo;
            _administarationManager = administrationManager;

            base.IsForPersonVerification = true;
            base.IsForNewUserVerification = true;
            base.IsForStudentVerification = false;

            this.txtUserName.Validated += new EventHandler(txtUserNameValidated);
            this.txtPassword.Validated += new EventHandler(txtPasswordValidated);
            this.txtUserName.KeyPress += new KeyPressEventHandler(textBoxKeyPress);
            this.lblStatus.Click += new EventHandler(lblStatusClick);
            this.dgvList.RowValidated += new DataGridViewCellEventHandler(dgvListRowValidated);
        }
        #endregion

        #region Class Event Void Procedures
        //####################################################CLASS UserInfoAdmin EVENTS###############################################
        ////event is raised when the class is loaded
        protected override void ClassLoad(object sender, EventArgs e)
        {
            try
            {
                if (!RemoteServerLib.ProcStatic.IsSystemAccessAdmin(_userInfo))
                {
                    throw new Exception("You are not authorized to access this module.");
                }
            }
            catch(Exception ex)
            {
                RemoteClient.ProcStatic.ShowErrorDialog(ex.Message, "Error Loading");
                this.Close();
            }

            base.ClassLoad(sender, e);

            _newUserInfo = new CommonExchange.SysAccess();
            _newUserInfo.UserStatus = true;

            this.SetDataGridViewColumns();

            _administarationManager.InitializeAccessRightsDataGridView(this.dgvList);
        }//-----------------------
        //####################################################END CLASS UserInfoAdmin EVENTS###############################################

        //####################################################TEXTBOX EVENTS###############################################
        //event is raised when the key is pressed
        private void textBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            RemoteClient.ProcStatic.TextBoxForUserNamePassword(e);
        }//-----------------------
        //####################################################END TEXTBOX EVENTS###############################################

        //####################################################TEXTBOX txtUserName EVENTS###############################################
        //event is raised when the control is validated
        private void txtUserNameValidated(object sender, EventArgs e)
        {
            _newUserInfo.UserName = RemoteClient.ProcStatic.TrimStartEndString(this.txtUserName.Text);
        }//-------------------
        //####################################################END TEXTBOX txtUserName EVENTS###############################################

        //####################################################TEXTBOX txtPassword EVENTS###############################################
        //event is raised when the control is validated
        private void txtPasswordValidated(object sender, EventArgs e)
        {
            _newUserInfo.Password = RemoteClient.ProcStatic.TrimStartEndString(this.txtPassword.Text);
        }//-------------------
        //####################################################END TEXTBOX txtPassword EVENTS###############################################

        //####################################################LABEL lblStatus EVENTS###############################################
        //event is raised when the selected index is changed
        private void lblStatusClick(object sender, EventArgs e)
        {
            this.SetUserStatusControl();
        }//-------------------
        //####################################################END LABEL lblStatus EVENTS###############################################

        //####################################################DATAGRIDVIEW dgvList EVENTS###############################################
        //event is raised when the row is validated
        private void dgvListRowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (((Boolean)dgvList["checkbox_column", e.RowIndex].Value) && dgvList["department_name", e.RowIndex].Value == null)
            {
                dgvList["department_name", e.RowIndex].ErrorText = "You must select a department.";

                _hasErrors = true;
            }
            else
            {
                dgvList["department_name", e.RowIndex].ErrorText = String.Empty;

                _hasErrors = false;
            }
        }//------------------------
        //####################################################END DATAGRIDVIEW dgvList EVENTS###############################################

        //#########################################LINLLABEL lnkPersonArchive EVENTS###########################################################
        //event is raised when the control is clicked
        protected override void lnkPersonArchiveLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            base.lnkPersonArchiveLinkClicked(sender, e);

            if (base.HasSelectedForPersonUpdate)
            {
                _newUserInfo = base.NewUserInfo;
            }

            _rowIndexForPersonSearch = base.RowIndexForPersonSearch;   
        }//-------------------------
        //#########################################END LINLLABEL lnkPersonArchive EVENTS###########################################################
        #endregion

        #region Programmer-Defined Void Procedures
        //this procedure will Set Data Grid View Columuns
        protected void SetDataGridViewColumns()
        {
            DataGridViewColumn chkCol = new DataGridViewColumn();
            chkCol.Name = "checkbox_column";
            chkCol.HeaderText = String.Empty;
            chkCol.Width = 19;
            this.dgvList.Columns.Add(chkCol);
            
            DataGridViewColumn accsDescription = new DataGridViewColumn();
            accsDescription.Name = "access_description";
            accsDescription.HeaderText = "Access Description";
            accsDescription.Width = 350;
            accsDescription.ReadOnly = true;
            this.dgvList.Columns.Add(accsDescription);

            DataGridViewColumn dept = new DataGridViewColumn();
            dept.Name = "department_name";
            dept.HeaderText = "Department Name";
            dept.Width = 320;
            this.dgvList.Columns.Add(dept);

            this.dgvList.SelectionMode = DataGridViewSelectionMode.CellSelect;
        }//-------------------------------
        #endregion

        #region Programmer-Defined Void Procedures
        //this procedure will set user status control
        public void SetUserStatusControl()
        {
            _newUserInfo.UserStatus = !_newUserInfo.UserStatus;

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
        }//-------------------

        //this procedure will set datagrid view do events
        public void SetDataGridViewDoEvents(Int32 rowCount)
        {
            this.dgvList.Rows[rowCount].Selected = true;
            this.dgvList.FirstDisplayedScrollingRowIndex = rowCount;

            this.dgvList.Refresh();
        }//-------------------
        #endregion

        #region Programmer-Defined Functions
        //this function will validate controls
        public Boolean ValidateControlsUser()
        {
            Boolean isValid = true;

            _errProvider.SetError(this.txtUserName, "");
            _errProvider.SetError(this.txtPassword, "");
            _errProvider.SetError(this.txtConfirmPassword, "");
            _errProvider.SetError(this.txtLastName, "");
            _errProvider.SetError(this.txtFirstName, "");
            _errProvider.SetError(this.txtMiddleName, "");
            _errProvider.SetError(this.gbxAccessRights, "");

            if (String.IsNullOrEmpty(_newUserInfo.UserName))
            {
                _errProvider.SetError(this.txtUserName, "User name is required.");
                _errProvider.SetIconAlignment(this.txtUserName, ErrorIconAlignment.MiddleRight);

                isValid = false;

                this.TabCntPerson.SelectedIndex = 2;
            }

            if (isValid && _newUserInfo.UserName.Length < 6)
            {
                _errProvider.SetError(this.txtUserName, "User name requires at least six (6) characters.");
                _errProvider.SetIconAlignment(this.txtUserName, ErrorIconAlignment.MiddleRight);

                isValid = false;
            }

            if (String.IsNullOrEmpty(_newUserInfo.Password))
            {
                _errProvider.SetError(this.txtPassword, "Password is required.");
                _errProvider.SetIconAlignment(this.txtPassword, ErrorIconAlignment.MiddleRight);

                isValid = false;

                this.TabCntPerson.SelectedIndex = 2;
            }

            if (String.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                _errProvider.SetError(this.txtConfirmPassword, "Confirm Password is required.");
                _errProvider.SetIconAlignment(this.txtConfirmPassword, ErrorIconAlignment.MiddleRight);

                isValid = false;

                this.TabCntPerson.SelectedIndex = 2;
            }

            if (isValid && !String.Equals(_newUserInfo.Password, RemoteClient.ProcStatic.TrimStartEndString(this.txtConfirmPassword.Text)))
            {
                _errProvider.SetError(this.txtConfirmPassword, "Password mismatch.");
                _errProvider.SetIconAlignment(this.txtConfirmPassword, ErrorIconAlignment.MiddleRight);

                _errProvider.SetError(this.txtPassword, "Password mismatch.");
                _errProvider.SetIconAlignment(this.txtPassword, ErrorIconAlignment.MiddleRight);

                isValid = false;

                this.TabCntPerson.SelectedIndex = 2;
            }

            if (isValid && _newUserInfo.Password.Length < 6)
            {
                _errProvider.SetError(this.txtPassword, "Password requires at least six (6) characters.");
                _errProvider.SetIconAlignment(this.txtPassword, ErrorIconAlignment.MiddleRight);

                isValid = false;

                this.TabCntPerson.SelectedIndex = 2;
            }

            if (String.IsNullOrEmpty(_personInfo.LastName))
            {
                _errProvider.SetError(this.txtLastName, "Last name is required.");
                _errProvider.SetIconAlignment(this.txtLastName, ErrorIconAlignment.MiddleRight);

                isValid = false;

                this.TabCntPerson.SelectedIndex = 0;
            }

            if (String.IsNullOrEmpty(_personInfo.FirstName))
            {
                _errProvider.SetError(this.txtFirstName, "First name is required.");
                _errProvider.SetIconAlignment(this.txtFirstName, ErrorIconAlignment.MiddleRight);

                isValid = false;

                this.TabCntPerson.SelectedIndex = 0;
            }

            if (_administarationManager.IsExistsNameSystemUserInformation(_userInfo, _newUserInfo))
            {
                _errProvider.SetError(this.txtUserName, "User authentication already exist.");
                _errProvider.SetIconAlignment(this.txtUserName, ErrorIconAlignment.MiddleRight);

                isValid = false;

                this.TabCntPerson.SelectedIndex = 2;
            }

            if (_newUserInfo.AccessRightsGrantedList.Count < 1)
            {
                _errProvider.SetError(this.gbxAccessRights, "You must select at least one access rights.");
                _errProvider.SetIconAlignment(this.gbxAccessRights, ErrorIconAlignment.TopRight);

                isValid = false;

                this.TabCntPerson.SelectedIndex = 2;
            }
            else
            {
                foreach (CommonExchange.AccessRightsGranted list in _newUserInfo.AccessRightsGrantedList)
                {
                    if (String.IsNullOrEmpty(list.DepartmentInfo.DepartmentId) || String.IsNullOrEmpty(list.AccessRightsInfo.AccessRights))
                    {
                        _errProvider.SetError(this.gbxAccessRights, "You must select a department in each access rights.");
                        _errProvider.SetIconAlignment(this.gbxAccessRights, ErrorIconAlignment.TopRight);

                        isValid = false;

                        this.TabCntPerson.SelectedIndex = 2;
                    }
                }
            }

            return isValid;
        }//-----------------------
        #endregion
    }
}
