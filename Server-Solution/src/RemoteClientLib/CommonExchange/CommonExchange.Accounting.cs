using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CommonExchange
{
    #region Common Structure Exchange

    [Serializable()]
    public class AccountingCategory : BaseObject
    {
        public AccountingCategory() 
        {
            _accountingCategoryId = String.Empty;
            _categoryDescription = String.Empty;
            _categoryNo = 0;
        }

        public Boolean Equals(AccountingCategory obj)
        {
            if (base.Equals<AccountingCategory>(obj))
            {
                return true;
            }

            return false;

        }

        private String _accountingCategoryId;
        public String AccountingCategoryId
        {
            get { return _accountingCategoryId; }
            set { _accountingCategoryId = value; }
        }

        private String _categoryDescription;
        public String CategoryDescription
        {
            get { return _categoryDescription; }
            set { _categoryDescription = value; }
        }

        private Byte _categoryNo;
        public Byte CategoryNo
        {
            get { return _categoryNo; }
            set { _categoryNo = value; }
        }

        public static String AccountingElementId
        {
            get { return "ACID01"; }
        }

        public static Byte AccountingElementNo
        {
            get { return 1; }
        }

        public static String ClassificationId
        {
            get { return "ACID02"; }
        }

        public static Byte ClassificationNo
        {
            get { return 2; }
        }

        public static String ControllingAccountId
        {
            get { return "ACID03"; }
        }

        public static Byte ControllingAccountNo
        {
            get { return 1; }
        }

        public static String SubsidiaryAccountId
        {
            get { return "ACID04"; }
        }

        public static Byte SubsidiaryAccountNo
        {
            get { return 1; }
        }        
    }

    [Serializable()]
    public class SummaryAccount : BaseObject
    {
        public SummaryAccount()
        {
            _accountSysId = String.Empty;
            _accountingCategoryInfo = new AccountingCategory();
            _accountCode = String.Empty;
            _accountName = String.Empty;
            _accountDescription = String.Empty;
            _companyPolicyProcedure = String.Empty;
            _isDebitSideIncrease = false;
            _isActiveAccount = false;
        }

        public Boolean Equals(SummaryAccount obj)
        {
            if (base.Equals<SummaryAccount>(obj) &&
                _accountingCategoryInfo.Equals(obj.AccountingCategoryInfo))
            {
                return true;
            }

            return false;

        }

        private String _accountSysId;
        public String AccountSysId
        {
            get { return _accountSysId; }
            set { _accountSysId = value; }
        }

        private AccountingCategory _accountingCategoryInfo;
        public AccountingCategory AccountingCategoryInfo
        {
            get { return _accountingCategoryInfo; }
            set { _accountingCategoryInfo = value; }
        }

        private String _accountCode;
        public String AccountCode
        {
            get { return _accountCode; }
            set { _accountCode = value; }
        }

        private String _accountName;
        public String AccountName
        {
            get { return _accountName; }
            set { _accountName = value; }
        }

        private String _accountDescription;
        public String AccountDescription
        {
            get { return _accountDescription; }
            set { _accountDescription = value; }
        }

        private String _companyPolicyProcedure;
        public String CompanyPolicyProcedure
        {
            get { return _companyPolicyProcedure; }
            set { _companyPolicyProcedure = value; }
        }

        private Boolean _isDebitSideIncrease;
        public Boolean IsDebitSideIncrease
        {
            get { return _isDebitSideIncrease; }
            set { _isDebitSideIncrease = value; }
        }

        private Boolean _isActiveAccount;
        public Boolean IsActiveAccount
        {
            get { return _isActiveAccount; }
            set { _isActiveAccount = value; }
        }
    }

    [Serializable()]
    public class ChartOfAccount : BaseObject
    {
        public ChartOfAccount()
        {
            _accountSysId = String.Empty;
            _accountingCategoryInfo = new AccountingCategory();
            _accountCode = String.Empty;
            _accountName = String.Empty;
            _accountDescription = String.Empty;
            _companyPolicyProcedure = String.Empty;
            _summaryAccount = new SummaryAccount();
            _isDebitSideIncrease = false;
            _isActiveAccount = false;
        }

        public Boolean Equals(ChartOfAccount obj)
        {
            if (base.Equals<ChartOfAccount>(obj) &&
                _accountingCategoryInfo.Equals(obj.AccountingCategoryInfo) &&
                _summaryAccount.Equals(obj.SummaryAccount))
            {
                return true;
            }

            return false;

        }

        private String _accountSysId;
        public String AccountSysId
        {
            get { return _accountSysId; }
            set { _accountSysId = value; }
        }

        private AccountingCategory _accountingCategoryInfo;
        public AccountingCategory AccountingCategoryInfo
        {
            get { return _accountingCategoryInfo; }
            set { _accountingCategoryInfo = value; }
        }

        private String _accountCode;
        public String AccountCode
        {
            get { return _accountCode; }
            set { _accountCode = value; }
        }

        private String _accountName;
        public String AccountName
        {
            get { return _accountName; }
            set { _accountName = value; }
        }

        private String _accountDescription;
        public String AccountDescription
        {
            get { return _accountDescription; }
            set { _accountDescription = value; }
        }

        private String _companyPolicyProcedure;
        public String CompanyPolicyProcedure
        {
            get { return _companyPolicyProcedure; }
            set { _companyPolicyProcedure = value; }
        }

        private SummaryAccount _summaryAccount;
        public SummaryAccount SummaryAccount
        {
            get { return _summaryAccount; }
            set { _summaryAccount = value; }
        }

        private Boolean _isDebitSideIncrease;
        public Boolean IsDebitSideIncrease
        {
            get { return _isDebitSideIncrease; }
            set { _isDebitSideIncrease = value; }
        }

        private Boolean _isActiveAccount;
        public Boolean IsActiveAccount
        {
            get { return _isActiveAccount; }
            set { _isActiveAccount = value; }
        }
        
    }

    #endregion
}