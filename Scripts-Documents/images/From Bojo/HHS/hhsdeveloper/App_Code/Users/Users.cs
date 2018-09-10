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
    /// Summary description for Users
    /// </summary>
    public static class Users
    {
        private static Boolean _isInitialized = false;
        private static UsersProvider _provider;
        private static HomeHealthDataProvidersSection _providersSection;

        public static UsersProvider Provider
        {
            get
            {
                Initialize();
                return _provider;
            }
        }

        public static Boolean IsActiveUser(CommonExchange.Users userInfo)
        {
            return Provider.IsActiveUser(userInfo);
        }

        private static void Initialize()
        {
            if (!_isInitialized)
            {
                _providersSection = (ConfigurationManager.GetSection("HomeHealthDataProviders")) as HomeHealthDataProvidersSection;

                if (_providersSection == null)
                {
                    throw new InvalidOperationException(Messages.UsersConfigSectionNotFound);
                }

                _provider = ProvidersHelper.InstantiateProvider(_providersSection.UsersProviders[_providersSection.UsersProviderName],
                    typeof(UsersProvider)) as UsersProvider;

                if (_provider == null)
                {
                    throw new InvalidOperationException(Messages.UsersProviderInstantiationError);
                }

                _isInitialized = true;

            }
        }
    }
}
