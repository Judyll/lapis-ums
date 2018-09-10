using System.Configuration.Provider;
using System.Collections.Generic;
using System;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace HomeHealthSearch
{
    /// <summary>
    /// base data access class
    /// </summary>
    public abstract class UsersProvider : ProviderBase
    {
        public abstract Boolean IsActiveUser(CommonExchange.Users userInfo);
    }
}
