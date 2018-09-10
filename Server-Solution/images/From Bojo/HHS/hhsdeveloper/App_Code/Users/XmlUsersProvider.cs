using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Schema;
using System.Collections.Generic;
using System.Text;


namespace HomeHealthSearch
{
    /// <summary>
    /// XML Data Layer for Users Page
    /// </summary>
    public class XmlUsersProvider : UsersProvider, IDisposable
    {
        private String _xmlFile;
        private String _xsdFile;

        /// <summary>
        /// Reads xml and xsd file names from the web.config file
        /// </summary>
        public XmlUsersProvider()
        {
            HomeHealthSearch.HomeHealthDataProvidersSection sec = (ConfigurationManager.GetSection("HomeHealthDataProviders")) as
                HomeHealthSearch.HomeHealthDataProvidersSection;

            String xmlFile = sec.UsersProviders[sec.UsersProviderName].Parameters["dataFile"];
            String xsdFile = sec.UsersProviders[sec.UsersProviderName].Parameters["schemaFile"];

            _xmlFile = HttpContext.Current.Request.MapPath("~/App_Data/" + xmlFile);
            _xsdFile = HttpContext.Current.Request.MapPath("~/App_Data/schemas/" + xsdFile);
        }

        void IDisposable.Dispose() { }

        /// <summary>
        /// determines if the user is active
        /// </summary>
        public override Boolean IsActiveUser(CommonExchange.Users userInfo)
        {
            List<CommonExchange.Users> userList = this.GetAllUsersInfo();

            foreach (CommonExchange.Users list in userList)
            {
                if (String.Equals(userInfo.UserName, list.UserName) && String.Equals(userInfo.Password, list.Password) && list.IsActive)
                {
                    return list.IsActive;
                }
            }

            return false;
        }

        /// <summary>
        /// gets all the users
        /// </summary>
        private List<CommonExchange.Users> GetAllUsersInfo()
        {
            DataSet dbSet = Util.ReadAndValidateXml(_xmlFile, _xsdFile);
            List<CommonExchange.Users> list = new List<CommonExchange.Users>();

            if (dbSet.Tables["usersInfo"] != null)
            {
                foreach (DataRow userRow in dbSet.Tables["usersInfo"].Rows)
                {
                    CommonExchange.Users uInfo = new CommonExchange.Users();

                    uInfo.Id = userRow["id"] is DBNull ? String.Empty : (String)userRow["id"];
                    uInfo.UserName = userRow["user_name"] is DBNull ? String.Empty : (String)userRow["user_name"];
                    uInfo.Password = userRow["password"] is DBNull ? String.Empty : (String)userRow["password"];
                    uInfo.IsActive = userRow["is_active"] is DBNull ? false : (Boolean)userRow["is_active"];

                    list.Add(uInfo);
                }
            }

            return list;
        }
    }
}
