using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace AdministratorServices
{
    public class AdministrtationLogic : BaseServices.BaseServicesLogic
    {
        #region Class Data Member Declaration
        private DataSet _classDataSet;
        private DataTable _userInformationTable;
        private DataTable _transactionLogTable;
        #endregion

        #region Class Properties Declaration
       
        public DataTable UserInformationTable
        {
            get
            {
                DataTable newTable = new DataTable("UserInformationTable");
                newTable.Columns.Add("system_user_id", System.Type.GetType("System.String"));
                newTable.Columns.Add("system_user_name", System.Type.GetType("System.String"));
                newTable.Columns.Add("user_name", System.Type.GetType("System.String"));
                newTable.Columns.Add("access_description", System.Type.GetType("System.String"));
                newTable.Columns.Add("department_name", System.Type.GetType("System.String"));

                return newTable;
            }
        }

        public DataTable TransactionLogTable
        {
            get
            {
                DataTable newTable = new DataTable("UserInformationTable");
                newTable.Columns.Add("transaction_id", System.Type.GetType("System.String"));
                newTable.Columns.Add("transaction_date_string", System.Type.GetType("System.String"));
                newTable.Columns.Add("user_name", System.Type.GetType("System.String"));
                newTable.Columns.Add("access_description", System.Type.GetType("System.String"));
                newTable.Columns.Add("transaction_done", System.Type.GetType("System.String"));

                return newTable;
            }
        }
        #endregion

        #region Class Constructors
        public AdministrtationLogic(CommonExchange.SysAccess userInfo)
            : base(userInfo)
        {
            this.InitializeClass(userInfo);
        }
        #endregion

        #region Programmer-Defined Void Procedures
        //this procedure will initialize the class
        private void InitializeClass(CommonExchange.SysAccess userInfo)
        {
            //get the server date and time
            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                _serverDateTime = remClient.GetServerDateTime(userInfo);
            }//---------------------
           
            //the the dataset administrator manager
            using (RemoteClient.RemCntAdministratorManager remClient = new RemoteClient.RemCntAdministratorManager())
            {
                _classDataSet = remClient.GetDataSetForAdministrator(userInfo);
            }//------------------
        }//-------------------------

        //this procedure will insert new User Information
        public void InsertSystemUserInfo(CommonExchange.SysAccess userInfo, CommonExchange.SysAccess newUserInfo)
        {
            using (RemoteClient.RemCntAdministratorManager remClient = new RemoteClient.RemCntAdministratorManager())
            {   
                remClient.InsertSystemUserInfo(userInfo, ref newUserInfo);
            }

            DataRow newRow = _userInformationTable.NewRow();

            newRow["system_user_id"] = newUserInfo.UserId;
            newRow["system_user_name"] = newUserInfo.UserName;           
            newRow["system_user_status"] = newUserInfo.UserStatus;
            newRow["last_name"] = newUserInfo.PersonInfo.LastName;
            newRow["first_name"] = newUserInfo.PersonInfo.FirstName;
            newRow["middle_name"] = newUserInfo.PersonInfo.MiddleName;

            _userInformationTable.Rows.Add(newRow);
        }//------------------------

        //this procedure will update User Information
        public void UpdateSystemUserInfo(CommonExchange.SysAccess userInfo, CommonExchange.SysAccess editUserInfo)
        {
            using (RemoteClient.RemCntAdministratorManager remClient = new RemoteClient.RemCntAdministratorManager())
            {
                remClient.UpdateSystemUserInfo(userInfo, editUserInfo);
            }

            Int32 index = 0;

            foreach (DataRow userRow in _userInformationTable.Rows)
            {
                if (String.Equals(editUserInfo.UserId, RemoteServerLib.ProcStatic.DataRowConvert(userRow, "system_user_id", "")))
                {

                    DataRow editRow = _userInformationTable.Rows[index];

                    editRow.BeginEdit();

                    editRow["system_user_id"] = editUserInfo.UserId;
                    editRow["system_user_name"] = editUserInfo.UserName;
                    editRow["last_name"] = editUserInfo.PersonInfo.LastName;
                    editRow["first_name"] = editUserInfo.PersonInfo.FirstName;
                    editRow["middle_name"] = editUserInfo.PersonInfo.MiddleName;

                    editRow.EndEdit();
                }

                index++;
            }
        }//------------------------        

        //this procedure will Initialize access rights datagridview
        public void InitializeAccessRightsDataGridView(DataGridView dgvBase)
        {
            if (_classDataSet != null)
            {
                foreach (DataRow accessRow in _classDataSet.Tables["SystemAccessRightsTable"].Rows)
                {
                    DataGridViewCheckBoxCell chkCell = new DataGridViewCheckBoxCell();
                    DataGridViewTextBoxCell txtAccessDescriptionCell = new DataGridViewTextBoxCell();
                    DataGridViewComboBoxCell cboCell = new DataGridViewComboBoxCell();

                    foreach (DataRow depRow in _classDataSet.Tables["DepartmentInformationTable"].Rows)
                    {
                        cboCell.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(depRow, "department_name", ""));
                    }

                    chkCell.Value = false;
                    txtAccessDescriptionCell.Value = RemoteServerLib.ProcStatic.DataRowConvert(accessRow, "access_description", "");
                  
                    DataGridViewCell[] dgvCell = new DataGridViewCell[] {chkCell, txtAccessDescriptionCell, cboCell };
                    DataGridViewRow dgvRow = new DataGridViewRow();
                    dgvRow.Cells.AddRange(dgvCell);
 
                    dgvBase.Rows.Add(dgvRow);
                }
            }
        }//---------------------

        //this procedure will Initialize access rights datagridview
        public void InitializeAccessRightsDataGridView(DataGridView dgvBase, List<CommonExchange.AccessRightsGranted> accessGrantedList)
        {
            if (_classDataSet != null)
            {
                foreach (DataRow accessRow in _classDataSet.Tables["SystemAccessRightsTable"].Rows)
                {
                    DataGridViewCheckBoxCell chkCell = new DataGridViewCheckBoxCell();
                    DataGridViewTextBoxCell txtAccessDescriptionCell = new DataGridViewTextBoxCell();
                    DataGridViewComboBoxCell cboCell = new DataGridViewComboBoxCell();

                    foreach (DataRow depRow in _classDataSet.Tables["DepartmentInformationTable"].Rows)
                    {
                        cboCell.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(depRow, "department_name", ""));
                    }

                    Boolean isChecked = false;
                   
                    foreach (CommonExchange.AccessRightsGranted list in accessGrantedList)
                    {
                        if (String.Equals(list.AccessRightsInfo.AccessRights, RemoteServerLib.ProcStatic.DataRowConvert(accessRow, "access_rights", "")))
                        {
                            foreach (DataRow depRow in _classDataSet.Tables["DepartmentInformationTable"].Rows)
                            {
                                if (String.Equals(list.DepartmentInfo.DepartmentId, RemoteServerLib.ProcStatic.DataRowConvert(depRow, "department_id", "")))
                                {
                                    cboCell.Value = RemoteServerLib.ProcStatic.DataRowConvert(depRow, "department_name", "");

                                    break;
                                }
                            }

                            isChecked = true;
                            
                            break;
                        }
                    }

                    chkCell.Value = isChecked;
                    txtAccessDescriptionCell.Value = RemoteServerLib.ProcStatic.DataRowConvert(accessRow, "access_description", "");
                    
                    DataGridViewCell[] dgvCell = new DataGridViewCell[] { chkCell, txtAccessDescriptionCell, cboCell };
                    DataGridViewRow dgvRow = new DataGridViewRow();
                    dgvRow.Cells.AddRange(dgvCell);

                    dgvBase.Rows.Add(dgvRow);
                }
            }
        }//---------------------

        //this procedure will Initialize department combo
        public void InitializeDepartmentCombo(DataGridViewComboBoxColumn cboBase)
        {
            cboBase.Items.Clear();

            foreach (DataRow accessRow in _classDataSet.Tables["DepartmentInformationTable"].Rows)
            {
                cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(accessRow, "department_name", "") + " - " +
                    RemoteServerLib.ProcStatic.DataRowConvert(accessRow, "acronym", ""));
            }
        }//--------------------

        //this procedure will Initialize department combo
        public void InitializeDepartmentCombo(DataGridViewComboBoxColumn cboBase, String departmentId)
        {
            cboBase.Items.Clear();

            Boolean isIndex = false;

            foreach (DataRow accessRow in _classDataSet.Tables["DepartmentInformationTable"].Rows)
            {
                cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(accessRow, "department_name", "") + " - " +
                    RemoteServerLib.ProcStatic.DataRowConvert(accessRow, "acronym", ""));

                if (!isIndex)
                {
                    isIndex = true;
                }
            }
        }//--------------------

        //this procedure will initialize the user combo
        public void InitializeUserCombo(ComboBox cboBase)
        {

            cboBase.Items.Clear();

            foreach (DataRow userRow in _userInformationTable.Rows)
            {
                cboBase.Items.Add(RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userRow, "last_name", "first_name", "middle_name") + " - [" +
                    RemoteServerLib.ProcStatic.DataRowConvert(userRow, "access_description", "") + "]");
            }

            cboBase.SelectedIndex = -1;
        }//------------------------------

        //this procedure will select user information
        public void SelectUserInformation(CommonExchange.SysAccess userInfo, String queryString)
        {
            using (RemoteClient.RemCntAdministratorManager remClient = new RemoteClient.RemCntAdministratorManager())
            {
                _userInformationTable = remClient.SelectSystemUserInfo(userInfo, queryString);
            }
        }//--------------------------
        #endregion

        #region Programmer-Defined Function
        //this function will get search users information
        public DataTable GetSearchUserInformation(CommonExchange.SysAccess userInfo, String queryString)
        {
            DataTable newTable = new DataTable("UserInformationTable");
            newTable.Columns.Add("system_user_id", System.Type.GetType("System.String"));
            newTable.Columns.Add("system_user_name", System.Type.GetType("System.String"));
            newTable.Columns.Add("user_name", System.Type.GetType("System.String"));
            newTable.Columns.Add("access_description", System.Type.GetType("System.String"));

            this.SelectUserInformation(userInfo, queryString);

            foreach (DataRow userRow in _userInformationTable.Rows)
            {
                DataRow newRow = newTable.NewRow();

                newRow["system_user_id"] = RemoteServerLib.ProcStatic.DataRowConvert(userRow, "system_user_id", "");
                newRow["system_user_name"] = RemoteServerLib.ProcStatic.DataRowConvert(userRow, "system_user_name", "");
                newRow["user_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userRow, "last_name", "first_name", "middle_name");
                newRow["access_description"] = RemoteServerLib.ProcStatic.DataRowConvert(userRow, "access_description", "");

                newTable.Rows.Add(newRow);
            }

            return newTable; 
        }//---------------------

        //this function will get search taransaction log
        public DataTable GetSearchTransactionLog(CommonExchange.SysAccess userInfo, String queryString, String userId, String dateStart, String dateEnd)
        {
            DataTable newTable = new DataTable("UserInformationTable");
            newTable.Columns.Add("transaction_id", System.Type.GetType("System.String"));
            newTable.Columns.Add("transaction_date_string", System.Type.GetType("System.String"));
            newTable.Columns.Add("user_name", System.Type.GetType("System.String"));
            newTable.Columns.Add("access_description", System.Type.GetType("System.String"));
            newTable.Columns.Add("transaction_done", System.Type.GetType("System.String"));

            using (RemoteClient.RemCntAdministratorManager remClient = new RemoteClient.RemCntAdministratorManager())
            {
                _transactionLogTable = remClient.SelectTransactionLog(userInfo, queryString, userId, dateStart, dateEnd);
            }

            foreach (DataRow logRow in _transactionLogTable.Rows)
            {
                DataRow newRow = newTable.NewRow();

                newRow["transaction_id"] = RemoteServerLib.ProcStatic.DataRowConvert(logRow, "transaction_id", "");
                newRow["transaction_date_string"] = RemoteServerLib.ProcStatic.DataRowConvert(logRow, "transaction_date_string", "");
                newRow["user_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(logRow, "last_name", "first_name", "middle_name");
                newRow["access_description"] = RemoteServerLib.ProcStatic.DataRowConvert(logRow, "access_description", "");
                newRow["transaction_done"] = RemoteServerLib.ProcStatic.DataRowConvert(logRow, "transaction_done", "");                        

                newTable.Rows.Add(newRow);
            }

            return newTable;
        }//-----------------------

        //this fucntion will get details User Information
        public CommonExchange.SysAccess GetDetailsUserInformation(CommonExchange.SysAccess userInfo, String userSysId, String startUp)
        {
            CommonExchange.SysAccess newUserInfo = new CommonExchange.SysAccess();

            using (RemoteClient.RemCntAdministratorManager remClient = new RemoteClient.RemCntAdministratorManager())
            {
                newUserInfo = remClient.SelectBySystemUserIDSystemUserInfo(userInfo, userSysId);
            }

            newUserInfo.PersonInfo.FilePath = base.GetPersonImagePath(userInfo, newUserInfo.PersonInfo.PersonSysId,
                newUserInfo.PersonInfo.PersonImagesFolder(startUp));

            return newUserInfo;
        }//------------------------

        //this function will get transaction log details
        public CommonExchange.TransactionLog GetDetailsTransactionLog(String transactioId)
        {
            CommonExchange.TransactionLog transactionLogInfo = new CommonExchange.TransactionLog();

            String strFilter = "transaction_id = '" + transactioId + "'";
            DataRow[] selectRow = _transactionLogTable.Select(strFilter);

            foreach (DataRow logRow in selectRow)
            {
                transactionLogInfo.AccessDescription = RemoteServerLib.ProcStatic.DataRowConvert(logRow, "access_description", "");
                transactionLogInfo.UserInfo.PersonInfo.FirstName = RemoteServerLib.ProcStatic.DataRowConvert(logRow, "first_name", "");
                transactionLogInfo.UserInfo.PersonInfo.LastName = RemoteServerLib.ProcStatic.DataRowConvert(logRow, "last_name", "");
                transactionLogInfo.UserInfo.PersonInfo.MiddleName = RemoteServerLib.ProcStatic.DataRowConvert(logRow, "middle_name", "");
                transactionLogInfo.NetworkInformation = RemoteServerLib.ProcStatic.DataRowConvert(logRow, "network_information", "");
                transactionLogInfo.TransactionDate = RemoteServerLib.ProcStatic.DataRowConvert(logRow, "transaction_date_string", "");
                transactionLogInfo.TransactionDone = RemoteServerLib.ProcStatic.DataRowConvert(logRow, "transaction_done", "");
                transactionLogInfo.TransactionId = RemoteServerLib.ProcStatic.DataRowConvert(logRow, "transaction_id", Int64.Parse("0"));
                transactionLogInfo.UserInfo.UserId = RemoteServerLib.ProcStatic.DataRowConvert(logRow, "system_user_id", "");
                transactionLogInfo.UserInfo.UserName = RemoteServerLib.ProcStatic.DataRowConvert(logRow, "system_user_name", "");
                transactionLogInfo.UserStatusString = RemoteServerLib.ProcStatic.DataRowConvert(logRow, "system_user_status_string", "");

                break;
            }

            return transactionLogInfo;
        }//------------------------

        //this function gets access rights
        public String GetAccessRights(Int32 index)
        {
            DataRow accessRow = _classDataSet.Tables["SystemAccessRightsTable"].Rows[index];

            return RemoteServerLib.ProcStatic.DataRowConvert(accessRow, "access_rights", "");
        }//----------------------

        //this function gets the department id
        public String GetDepartmentId(String departmentName)
        {
            String value = String.Empty;

            if (_classDataSet.Tables["DepartmentInformationTable"] != null)
            {
                foreach (DataRow depRow in _classDataSet.Tables["DepartmentInformationTable"].Rows)
                {
                    if (String.Equals(departmentName, RemoteServerLib.ProcStatic.DataRowConvert(depRow, "department_name", "")))
                    {
                        value = RemoteServerLib.ProcStatic.DataRowConvert(depRow, "department_id", "");

                        break;
                    }
                }
            }

            return value;
        }//------------------

        //this function gets the user id
        public String GetUserId(Int32 index)
        {
            DataRow userRow = _userInformationTable.Rows[index];

            return RemoteServerLib.ProcStatic.DataRowConvert(userRow, "system_user_id", "");
        }//-------------------------      

        //this fucntion gets department id
        public String GetDepartmentId(Int32 index)
        {
            DataRow depRow = _classDataSet.Tables["DepartmentInformationTable"].Rows[index];

            return RemoteServerLib.ProcStatic.DataRowConvert(depRow, "department_id", "");
        }//----------------------

        //this function determines if the user name and password already exist
        public Boolean IsExistsNameSystemUserInformation(CommonExchange.SysAccess userInfo, CommonExchange.SysAccess newUserInfo)
        {
            using (RemoteClient.RemCntAdministratorManager remClient = new RemoteClient.RemCntAdministratorManager())
            {
                return remClient.IsExistsNameSystemUserInformation(userInfo, newUserInfo);
            }
        }//------------------
        #endregion
    }
}
