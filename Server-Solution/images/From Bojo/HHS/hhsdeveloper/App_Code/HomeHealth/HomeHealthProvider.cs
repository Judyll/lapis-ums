using System.Configuration.Provider;
using System.Collections.Generic;
using System;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Data;

namespace HomeHealthSearch
{
    /// <summary>
    /// base data access class
    /// </summary>
    public abstract class HomeHealthProvider : ProviderBase
    {
        public abstract List<CommonExchange.HomeHealth> SelectAsListHomeHealthInformation();
        public abstract DataTable SelectAsTableHomeHealthInformation();
        public abstract void InsertHomeHealthInformation(CommonExchange.HomeHealth homeHealthInfo);
        public abstract void UpdateHomeHealthInformation(CommonExchange.HomeHealth homeHealthInfo);
        public abstract String SaveHomeHealthInformationLogoImageUrl(Page page, FileUpload fileUpload);
        public abstract String UpdateHomeHealthInformationLogoImageUrl(Int32 homeHealthId, Page page, FileUpload fileUpload);
    }
}
