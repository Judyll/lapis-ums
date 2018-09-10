using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Collections;

namespace CommonExchange
{
    #region Common Structure Exchange

    [Serializable()]
    public class HomeHealth : BaseObject
    {
        public HomeHealth()
        {
            _homeHealthId = 0;
            _homeHealthName = String.Empty;
            _officeAddress = String.Empty;
            _phoneNos = String.Empty;
            _faxNos = String.Empty;
            _dateCertified = DateTime.MinValue;
            _nationalProviderId = String.Empty;
            _ownership = String.Empty;
            _owner = String.Empty;
            _administrator = String.Empty;
            _directorOfNursing = String.Empty;
            _medicareProviderNo = String.Empty;
            _webSite = String.Empty;
            _logoPath = String.Empty;
        }

        public Boolean Equals(HomeHealth obj)
        {
            if (base.Equals<HomeHealth>(obj))
            {
                return true;
            }

            return false;

        }

        private Int32 _homeHealthId;
        public Int32 HomeHealthId
        {
            get { return _homeHealthId; }
            set { _homeHealthId = value; }
        }

        private String _homeHealthName;
        public String HomeHealthName
        {
            get { return _homeHealthName; }
            set { _homeHealthName = value; }
        }

        private String _officeAddress;
        public String OfficeAddress
        {
            get { return _officeAddress; }
            set { _officeAddress = value; }
        }

        private String _phoneNos;
        public String PhoneNos
        {
            get { return _phoneNos; }
            set { _phoneNos = value; }
        }
    
        private String _faxNos;
        public String FaxNos
        {
            get { return _faxNos; }
            set { _faxNos = value; }
        }
    
        private DateTime _dateCertified;
        public DateTime DateCertified
        {
            get { return _dateCertified; }
            set { _dateCertified = value; }
        }

        private String _nationalProviderId;
        public String NationalProviderId
        {
            get { return _nationalProviderId; }
            set { _nationalProviderId = value; }
        }
    
        private String _ownership;
        public String Ownership
        {
            get { return _ownership; }
            set { _ownership = value; }
        }
   
        private String _owner;
        public String Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }
    
        private String _administrator;
        public String Administrator
        {
            get { return _administrator; }
            set { _administrator = value; }
        }
    
        private String _directorOfNursing;
        public String DirectorOfNursing
        {
            get { return _directorOfNursing; }
            set { _directorOfNursing = value; }
        }
    
        private String _medicareProviderNo;
        public String MedicareProviderNo
        {
            get { return _medicareProviderNo; }
            set { _medicareProviderNo = value; }
        }

        private String _webSite;
        public String WebSite
        {
            get { return _webSite; }
            set { _webSite = value; }
        }

        private String _logoPath;
        public String LogoPath
        {
            get { return _logoPath; }
            set { _logoPath = value; }
        }
    }

    #endregion

}
