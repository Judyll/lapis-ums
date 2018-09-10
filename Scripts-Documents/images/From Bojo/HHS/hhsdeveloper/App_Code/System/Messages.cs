using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace HomeHealthSearch
{
    /// <summary>
    /// Error messages
    /// </summary>
    public class Messages
    {
        public static string AdminProviderInstantiationError = "Admin default provider could not be instantiated";
        public static string AdminConfigSectionNotFound = "Admin configuration section could not be found";

        public static string HomeHealthConfigSectionNotFound = "HomeHealth configuration section could not be found";
        public static string HomeHealthProviderInstantiationError = "HomeHealth default provider could not be instantiated";

        public static string UsersConfigSectionNotFound = "Users configuration section could not be found";
        public static string UsersProviderInstantiationError = "Users default provider could not be instantiated";

    }

}
