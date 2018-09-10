using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data;

namespace HomeHealthSearch
{
    /// <summary>
    /// Summary description for HomeHealth
    /// </summary>
    public static class HomeHealth
    {
        private static Boolean _isInitialized = false;
        private static HomeHealthProvider _provider;
        private static HomeHealthDataProvidersSection _providersSection;

        public static HomeHealthProvider Provider
        {
            get
            {
                Initialize();
                return _provider;
            }
        }

        public static List<CommonExchange.HomeHealth> SelectAsListHomeHealthInformation()
        {
            return Provider.SelectAsListHomeHealthInformation();
        }

        public static DataTable SelectAsTableHomeHealthInformation()
        {
            return Provider.SelectAsTableHomeHealthInformation();
        }

        public static void InsertHomeHealthInformation(CommonExchange.HomeHealth homeHealthInfo)
        {
            Provider.InsertHomeHealthInformation(homeHealthInfo);
        }

        public static void UpdateHomeHealthInformation(CommonExchange.HomeHealth homeHealthInfo)
        {
            Provider.UpdateHomeHealthInformation(homeHealthInfo);
        }

        public static String SaveHomeHealthInformationLogoImageUrl(Page page, FileUpload fileUpload)
        {
            return Provider.SaveHomeHealthInformationLogoImageUrl(page, fileUpload);
        }

        public static String UpdateHomeHealthInformationLogoImageUrl(Int32 homeHealthId, Page page, FileUpload fileUpload)
        {
            return Provider.UpdateHomeHealthInformationLogoImageUrl(homeHealthId, page, fileUpload);
        }

        private static void Initialize()
        {
            if (!_isInitialized)
            {
                _providersSection = (ConfigurationManager.GetSection("HomeHealthDataProviders")) as HomeHealthDataProvidersSection;

                if (_providersSection == null)
                {
                    throw new InvalidOperationException(Messages.HomeHealthConfigSectionNotFound);
                }

                _provider = ProvidersHelper.InstantiateProvider(_providersSection.HomeHealthProviders[_providersSection.HomeHealthProviderName],
                    typeof(HomeHealthProvider)) as HomeHealthProvider;

                if (_provider == null)
                {
                    throw new InvalidOperationException(Messages.HomeHealthProviderInstantiationError);
                }

                _isInitialized = true;

            }
        }
    }
}
