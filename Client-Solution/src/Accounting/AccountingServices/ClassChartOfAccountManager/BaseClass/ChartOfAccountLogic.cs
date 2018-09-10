using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace AccountingServices
{
    internal class ChartOfAccountLogic
    {
        #region Class Nested Classes
        internal class AccountHierarchy
        {
            public AccountHierarchy()
            {
            }

            private List<AccountHierarchy> _childAccount = new List<AccountHierarchy>();
            public List<AccountHierarchy> ChildAccount
            {
                get { return _childAccount; }
                set { _childAccount = value; }
            }

            private String _accountCodeName = String.Empty;
            public String AccountCodeName
            {
                get { return _accountCodeName; }
                set { _accountCodeName = value; }
            }

            private String _sysIdAccount = String.Empty;
            public String SystemIdAccount
            {
                get { return _sysIdAccount; }
                set { _sysIdAccount = value; }
            }

            private String _accountingCategorySysId = String.Empty;
            public String AccountingCategorySysId
            {
                get { return _accountingCategorySysId; }
                set { _accountingCategorySysId = value; }
            }
        }
        #endregion

        #region Class Data Member Declaration
        private DataSet _classDataSet;
        private DataTable _chartOfAccountsTable;

        private List<AccountHierarchy> _chartOfAccountHierarchList;
        #endregion

        #region Class Properties Decleration

        public DataTable ChartOfAccountTable
        {
            get
            {
                DataTable newTable = new DataTable("AccountChartTable");
                newTable.Columns.Add("sysid_account", System.Type.GetType("System.String"));
                newTable.Columns.Add("account_code_name", System.Type.GetType("System.String"));
                newTable.Columns.Add("category_description", System.Type.GetType("System.String"));
                newTable.Columns.Add("account_code_name_summary", System.Type.GetType("System.String"));
                newTable.Columns.Add("category_description_summary", System.Type.GetType("System.String"));

                return newTable;
            }
        }

        private String _serverDateTime = String.Empty;
        public String ServerDateTime
        {
            get { return _serverDateTime; }
        }
        #endregion

        #region Class Constructors
        public ChartOfAccountLogic(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);

            _chartOfAccountHierarchList = new List<AccountHierarchy>();
        }
        #endregion

        #region Programmer's Defined Void Procedures
        //this procedure will print chart of Account
        public void PrintChartOfAccount(CommonExchange.SysAccess userInfo)
        {
            DataTable accountTable = new DataTable("Account Table");
            accountTable.Columns.Add("sysid_account", System.Type.GetType("System.String"));
            accountTable.Columns.Add("account_code", System.Type.GetType("System.String"));
            accountTable.Columns.Add("account_name", System.Type.GetType("System.String"));
            
            if (_chartOfAccountsTable != null)
            {
                foreach (DataRow accountRow in _chartOfAccountsTable.Rows)
                {
                    DataRow newRow = accountTable.NewRow();

                    newRow["sysid_account"] = RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "sysid_account", String.Empty);
                    newRow["account_code"] = RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "account_code", String.Empty);
                    newRow["account_name"] = RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "account_name", String.Empty);

                    accountTable.Rows.Add(newRow);
                }
            }

            using (AccountingServices.ClassChartOfAccountManager.CrystalReport.CrystalChartOfAccount rptChartOfAccount =
                 new AccountingServices.ClassChartOfAccountManager.CrystalReport.CrystalChartOfAccount())
            {
                rptChartOfAccount.Database.Tables["account_table"].SetDataSource(accountTable);
                rptChartOfAccount.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                rptChartOfAccount.SetParameterValue("@form_name", "Chart of Accounts");
                rptChartOfAccount.SetParameterValue("@date_printed", DateTime.Parse(this.ServerDateTime).ToLongDateString());
                rptChartOfAccount.SetParameterValue("@print_Info", "Date/Time Printed: " +
                    DateTime.Parse(this.ServerDateTime).ToShortDateString() + " " +
                    DateTime.Parse(this.ServerDateTime).ToShortTimeString() + "      Printed by: " +
                    RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName, userInfo.PersonInfo.FirstName,
                    userInfo.PersonInfo.MiddleName));

                using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptChartOfAccount))
                {
                    frmViewer.Text = "Chart of Account";
                    frmViewer.ShowDialog();
                }
            }
        }//----------------------------------

        //this procedure will insert chart of account information
        public void InsertChartOfAccounts(CommonExchange.SysAccess userInfo, CommonExchange.ChartOfAccount chartOfAccount)
        {
            using (RemoteClient.RemCntAccountingManager remClient = new RemoteClient.RemCntAccountingManager())
            {
                remClient.InsertChartOfAccounts(userInfo, ref chartOfAccount);
            }

            if (_chartOfAccountsTable != null)
            {
                DataRow newRow = _chartOfAccountsTable.NewRow();

                newRow["sysid_account"] = chartOfAccount.AccountSysId;
                newRow["account_code"] = chartOfAccount.AccountCode;
                newRow["account_name"] = chartOfAccount.AccountName;
                newRow["is_debit_side_increase"] = chartOfAccount.IsDebitSideIncrease;
                newRow["is_active_account"] = chartOfAccount.IsActiveAccount;
                newRow["accounting_category_id"] = chartOfAccount.AccountingCategoryInfo.AccountingCategoryId;
                newRow["category_description"] = chartOfAccount.AccountingCategoryInfo.CategoryDescription;
                newRow["sysid_account_summary"] = chartOfAccount.SummaryAccount.AccountSysId;
                newRow["account_code_summary"] = chartOfAccount.SummaryAccount.AccountCode;
                newRow["account_name_summary"] = chartOfAccount.SummaryAccount.AccountName;
                newRow["is_debit_side_increase_summary"] = chartOfAccount.SummaryAccount.IsDebitSideIncrease;
                newRow["is_active_account_summary"] = chartOfAccount.SummaryAccount.IsActiveAccount;
                newRow["accounting_category_id_summary"] = chartOfAccount.SummaryAccount.AccountingCategoryInfo.AccountingCategoryId;
                newRow["category_description_summary"] = chartOfAccount.SummaryAccount.AccountingCategoryInfo.CategoryDescription;

                _chartOfAccountsTable.Rows.Add(newRow);
            }
        }//------------------

        //this procedure will update chart of account information
        public void UpdateChartOfAccounts(CommonExchange.SysAccess userInfo, CommonExchange.ChartOfAccount chartOfAccount)
        {
            using (RemoteClient.RemCntAccountingManager remClient = new RemoteClient.RemCntAccountingManager())
            {
                remClient.UpdateChartOfAccounts(userInfo, chartOfAccount);
            }

            if (_chartOfAccountsTable != null)
            {
                Int32 index = 0;

                foreach (DataRow accountRow in _chartOfAccountsTable.Rows)
                {
                    if (String.Equals(chartOfAccount.AccountSysId, RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "sysid_account", String.Empty)))
                    {
                        DataRow editRow = _chartOfAccountsTable.Rows[index];

                        editRow.BeginEdit();

                        editRow["sysid_account"] = chartOfAccount.AccountSysId;
                        editRow["account_code"] = chartOfAccount.AccountCode;
                        editRow["account_name"] = chartOfAccount.AccountName;
                        editRow["is_debit_side_increase"] = chartOfAccount.IsDebitSideIncrease;
                        editRow["is_active_account"] = chartOfAccount.IsActiveAccount;
                        editRow["accounting_category_id"] = chartOfAccount.AccountingCategoryInfo.AccountingCategoryId;
                        editRow["category_description"] = chartOfAccount.AccountingCategoryInfo.CategoryDescription;
                        editRow["sysid_account_summary"] = chartOfAccount.SummaryAccount.AccountSysId;
                        editRow["account_code_summary"] = chartOfAccount.SummaryAccount.AccountCode;
                        editRow["account_name_summary"] = chartOfAccount.SummaryAccount.AccountName;
                        editRow["is_debit_side_increase_summary"] = chartOfAccount.SummaryAccount.IsDebitSideIncrease;
                        editRow["is_active_account_summary"] = chartOfAccount.SummaryAccount.IsActiveAccount;
                        editRow["accounting_category_id_summary"] = chartOfAccount.SummaryAccount.AccountingCategoryInfo.AccountingCategoryId;
                        editRow["category_description_summary"] = chartOfAccount.SummaryAccount.AccountingCategoryInfo.CategoryDescription;

                        editRow.EndEdit();

                        break;
                    }

                    index++;
                }
            }
        }//---------------------

        //this procedure will initialize account category information
        public void InitializeAccountCategoryComboBox(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            if (_classDataSet.Tables["AccountingCategoryTable"] != null)
            {
                cboBase.Items.Add("-- Select an Account Category --");

                foreach (DataRow accountRow in _classDataSet.Tables["AccountingCategoryTable"].Rows)
                {
                    cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "category_description", String.Empty));
                }

                cboBase.SelectedIndex = 0;
            }
        }//----------------------

        //this procedure will initialize account category information
        public void InitializeAccountCategoryComboBox(ComboBox cboBase, String categoryId)
        {
            cboBase.Items.Clear();

            Int32 index = 0;
            Boolean hasEnter = false;

                if (_classDataSet.Tables["AccountingCategoryTable"] != null)
            {
                cboBase.Items.Add("-- Select an Account Category --");

                foreach (DataRow accountRow in _classDataSet.Tables["AccountingCategoryTable"].Rows)
                {
                    cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "category_description", String.Empty));

                    if (!hasEnter)
                    {
                        if (String.Equals(categoryId, RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "accounting_category_id", String.Empty)))
                        {
                            cboBase.SelectedIndex = index + 1;

                            hasEnter = true;
                        }
                    }

                    index++;
                }
            }
        }//----------------------

        //this procedure will initialize the chart of account listview
        public void InitializeChartOfAccountListView(TreeView trvBase)
        {
            trvBase.Nodes.Clear();

            if (_chartOfAccountsTable != null)
            {
                Int32 index = 0;

                foreach (AccountHierarchy list in _chartOfAccountHierarchList)
                {
                    TreeNode accountNode = new TreeNode(list.AccountCodeName);

                    this.GetChildNodeChartOfAccount(accountNode, list.ChildAccount);

                    if (String.Equals(CommonExchange.AccountingCategory.AccountingElementId, list.AccountingCategorySysId))
                    {
                        accountNode.ForeColor = Color.Navy;
                    }

                    trvBase.Nodes.Add(accountNode);

                    index++;
                }
            }
        }//-------------------       

        //this procedure will arrage Account Hierarchy List
        public void ArrageAccountHierarchyList()
        {
            if (_chartOfAccountsTable != null)
            {
                Int32 index = -1;

                _chartOfAccountHierarchList.Clear();

                foreach (DataRow accountRow in _chartOfAccountsTable.Rows)
                {
                    index = 0;

                    if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "sysid_account_summary", String.Empty)))
                    {
                        _chartOfAccountHierarchList.Add(this.GetAccountHierarchyDetails(RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "sysid_account", String.Empty)));
                    }
                    else
                    {
                        this.InitializeAccountHierarchyList(_chartOfAccountHierarchList,
                            RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "sysid_account_summary", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "sysid_account", String.Empty), index);
                    }
                }
            }
        }//-------------------------

        //this procedure will select chart of accounts
        public void SelectChartOfAccountsArrangedList(CommonExchange.SysAccess userInfo, String queryString,
            String summaryAccount, String accountingCategoryIdList, Boolean isActiveAccount)
        {
            using (RemoteClient.RemCntAccountingManager remClient = new RemoteClient.RemCntAccountingManager())
            {
                _chartOfAccountsTable = remClient.SelectChartOfAccounts(userInfo, queryString, summaryAccount, accountingCategoryIdList, isActiveAccount);
            }           
        }//------------------------

        //this procedure will recursively create and arraged the chart of account based on it's parent account
        private void InitializeAccountHierarchyList(List<AccountHierarchy> accountHierarchyList, String parentSysIdAccount, String childSysIdAccount, Int32 index)
        {
            foreach (AccountHierarchy list in accountHierarchyList)
            {
                if (String.Equals(list.SystemIdAccount, parentSysIdAccount))
                {  
                    index = this.GetParentNodeIndex(accountHierarchyList, parentSysIdAccount);

                    accountHierarchyList[index].ChildAccount.Add(this.GetAccountHierarchyDetails(childSysIdAccount));

                    break;
                }
                else
                {
                    this.InitializeAccountHierarchyList(list.ChildAccount, parentSysIdAccount, childSysIdAccount, index);
                }

                index++;
            }
        }//---------------------------

        //this procedure will initialize class
        private void InitializeClass(CommonExchange.SysAccess userInfo)
        {
            //get the server date and time
            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                _serverDateTime = remClient.GetServerDateTime(userInfo);
            }//---------------------

            //get class Data Set
            using (RemoteClient.RemCntAccountingManager remClient = new RemoteClient.RemCntAccountingManager())
            {
                _classDataSet = remClient.GetDataSetForAccounting(userInfo);
            }//--------------------
        }//---------------------------
        #endregion

        #region Programmer's Defined Functions
        //this function will get searched chart of account informations
        public DataTable GetSearchedChartOfAccountInformations(String queryString)
        {
            DataTable newTable = this.ChartOfAccountTable;

            if (_chartOfAccountsTable != null)
            {
                String strFilter = "account_code LIKE '%" + queryString + "%' OR account_name LIKE '%" + queryString + "%'";
                DataRow[] selectRow = _chartOfAccountsTable.Select(strFilter);

                foreach (DataRow accountRow in selectRow)
                {
                    DataRow newRow = newTable.NewRow();

                    newRow["sysid_account"] = RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "sysid_account", String.Empty);
                    newRow["account_code_name"] = RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "account_code", String.Empty) + "  (" +
                        RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "account_name", String.Empty) + ")";
                    newRow["category_description"] = RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "category_description", String.Empty);
                    newRow["account_code_name_summary"] = RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "account_code_summary", String.Empty) + "  (" +
                        RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "account_name_summary", String.Empty) + ")";
                    newRow["category_description_summary"] = RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "category_description_summary", String.Empty);

                    newTable.Rows.Add(newRow);
                }
            }

            return newTable;
        }//------------------------        

        //this function will get details of each chart of account information
        public CommonExchange.ChartOfAccount GetDetailsChartOfAccount(CommonExchange.SysAccess userInfo, String accountSysId)
        {
            CommonExchange.ChartOfAccount chartOfAccountInfo = new CommonExchange.ChartOfAccount();

            using (RemoteClient.RemCntAccountingManager remClient = new RemoteClient.RemCntAccountingManager())
            {
                chartOfAccountInfo = remClient.SelectBySysIDAccountChartOfAccounts(userInfo, accountSysId);
            }

            return chartOfAccountInfo;
        }//---------------------

        //this function will get details of each account summary information
        public CommonExchange.SummaryAccount GetDetailsSummaryOfAccount(String accountSysId)
        {
            CommonExchange.SummaryAccount summaryAccountInfo = new CommonExchange.SummaryAccount();

            if (_chartOfAccountsTable != null)
            {
                String strFilter = "sysid_account = '" + accountSysId + "'";
                DataRow[] selectRow = _chartOfAccountsTable.Select(strFilter);

                foreach (DataRow accountRow in selectRow)
                {
                    summaryAccountInfo.AccountCode = RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "account_code", String.Empty);
                    summaryAccountInfo.AccountName = RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "account_name", String.Empty);
                    summaryAccountInfo.AccountSysId = RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "sysid_account", String.Empty);
                    summaryAccountInfo.AccountingCategoryInfo.AccountingCategoryId =
                        RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "accounting_category_id", String.Empty);
                    summaryAccountInfo.AccountingCategoryInfo.CategoryDescription =
                        RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "category_description", String.Empty);
                    summaryAccountInfo.IsDebitSideIncrease = RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "is_debit_side_increase", false);
                    summaryAccountInfo.IsActiveAccount = RemoteServerLib.ProcStatic.DataRowConvert(accountRow, "is_active_account", false);

                    break;
                }
            }

            return summaryAccountInfo;
        }//---------------------

        //this function will get details of each accounting category information
        public CommonExchange.AccountingCategory GetDetailsAccountingCategory(Int32 index)
        {
            CommonExchange.AccountingCategory accountingCategoryInfo = new CommonExchange.AccountingCategory();

            if (_classDataSet.Tables["AccountingCategoryTable"] != null && index != 0)
            {
                DataRow categoryRow = _classDataSet.Tables["AccountingCategoryTable"].Rows[index - 1];

                accountingCategoryInfo.AccountingCategoryId = RemoteServerLib.ProcStatic.DataRowConvert(categoryRow, "accounting_category_id", String.Empty);
                accountingCategoryInfo.CategoryDescription = RemoteServerLib.ProcStatic.DataRowConvert(categoryRow, "category_description", String.Empty);
                accountingCategoryInfo.CategoryNo = RemoteServerLib.ProcStatic.DataRowConvert(categoryRow, "category_no", Byte.Parse("0"));
            }

            return accountingCategoryInfo;
        }//---------------------

        //this function will determine if the accounting category is valid for summary account
        public Boolean IsValidCategoryBySummaryAccountChartOfAccount(CommonExchange.SysAccess userInfo, String accountingCategoryId, String summaryAccount)
        {
            Boolean isValid = false;

            using (RemoteClient.RemCntAccountingManager remClient = new RemoteClient.RemCntAccountingManager())
            {
                isValid = remClient.IsValidCategoryBySummaryAccountChartOfAccount(userInfo, accountingCategoryId, summaryAccount);
            }

            return isValid;
        }//---------------------

        //this function will determine if the account code already exist
        public Boolean IsExistsAccountCodeChartOfAccount(CommonExchange.SysAccess userInfo, String accountSysId, String accountCode, String summaryAccount)
        {
            Boolean isExist = false;

            using (RemoteClient.RemCntAccountingManager remClient = new RemoteClient.RemCntAccountingManager())
            {
                isExist = remClient.IsExistsAccountCodeChartOfAccount(userInfo, accountSysId, accountCode, summaryAccount);
            }

            return isExist;
        }//--------------------

        //this function will get child Node Chart of Account
        private TreeNode GetChildNodeChartOfAccount(TreeNode accountNode, List<AccountHierarchy> accountHierarchyList)
        {
            foreach (AccountHierarchy list in accountHierarchyList)
            {
                TreeNode childNode = new TreeNode(list.AccountCodeName);

                if (String.Equals(CommonExchange.AccountingCategory.AccountingElementId, list.AccountingCategorySysId))
                {
                    childNode.ForeColor = Color.Navy;
                }
                else if (String.Equals(CommonExchange.AccountingCategory.ClassificationId, list.AccountingCategorySysId))
                {
                    childNode.ForeColor = Color.Maroon;
                }
                else if (String.Equals(CommonExchange.AccountingCategory.ControllingAccountId, list.AccountingCategorySysId))
                {
                    childNode.ForeColor = Color.DarkOrange;
                }
                else if (String.Equals(CommonExchange.AccountingCategory.SubsidiaryAccountId, list.AccountingCategorySysId))
                {
                    childNode.ForeColor = Color.Olive;
                }

                accountNode.Nodes.Add(childNode);

                this.GetChildNodeChartOfAccount(childNode, list.ChildAccount);
            }

            return accountNode;
        }//---------------------

        //this fucntion will get details chart of account hierarchy
        private AccountHierarchy GetAccountHierarchyDetails(String accountSysId)
        {
            AccountHierarchy accountHierarchyInfo = new AccountHierarchy();

            String strFilter = "sysid_account = '" + accountSysId + "'";
            DataRow[] selectRow = _chartOfAccountsTable.Select(strFilter);

            foreach (DataRow accountElementRow in selectRow)
            {

                accountHierarchyInfo.AccountCodeName = RemoteServerLib.ProcStatic.DataRowConvert(accountElementRow, "account_code", String.Empty) + "  (" +
                    RemoteServerLib.ProcStatic.DataRowConvert(accountElementRow, "account_name", String.Empty) + ")";
                accountHierarchyInfo.SystemIdAccount = RemoteServerLib.ProcStatic.DataRowConvert(accountElementRow, "sysid_account", String.Empty);
                accountHierarchyInfo.AccountingCategorySysId = RemoteServerLib.ProcStatic.DataRowConvert(accountElementRow, "accounting_category_id", String.Empty);

            }

            return accountHierarchyInfo;
        }//------------------

        //this function will get the index of the parent node
        private Int32 GetParentNodeIndex(List<AccountHierarchy> accountHierarchyList, String parentSysIdAccount)
        {
            Int32 index = 0;

            foreach (AccountHierarchy list in accountHierarchyList)
            {
                if (String.Equals(list.SystemIdAccount, parentSysIdAccount))
                {
                    break;
                }

                index++;
            }

            return index;
        }//----------------------
        #endregion
    }
}
