using System;
using System.Configuration;

namespace HomeHealthSearch
{
    public class HomeHealthDataProvidersSection : ConfigurationSection
    {

        [ConfigurationProperty("homeHealthProviderName", IsRequired = true)]
        public string HomeHealthProviderName
        {
            get { return (string)this["homeHealthProviderName"]; }
            set { this["homeHealthProviderName"] = value; }
        }

        [ConfigurationProperty("HomeHealthProviders")]
        [ConfigurationValidatorAttribute(typeof(ProviderSettingsValidation))]
        public ProviderSettingsCollection HomeHealthProviders
        {
            get { return (ProviderSettingsCollection)this["HomeHealthProviders"]; }

        }

        [ConfigurationProperty("usersProviderName", IsRequired = true)]
        public string UsersProviderName
        {
            get { return (string)this["usersProviderName"]; }
            set { this["usersProviderName"] = value; }
        }

        [ConfigurationProperty("UsersProviders")]
        [ConfigurationValidatorAttribute(typeof(ProviderSettingsValidation))]
        public ProviderSettingsCollection UsersProviders
        {
            get { return (ProviderSettingsCollection)this["UsersProviders"]; }
        }

    } // end class

}