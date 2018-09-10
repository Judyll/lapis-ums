using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Schema;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace HomeHealthSearch
{
    /// <summary>
    /// Summary description for XmlHomeHealthProvider
    /// </summary>
    public class XmlHomeHealthProvider : HomeHealthProvider, IDisposable
    {
        private String _xmlFile;
        private String _xsdFile;

        /// <summary>
        /// Reads xml and xsd file names from the web.config file
        /// </summary>
        public XmlHomeHealthProvider()
        {
            HomeHealthSearch.HomeHealthDataProvidersSection sec = (ConfigurationManager.GetSection("HomeHealthDataProviders")) as
                HomeHealthSearch.HomeHealthDataProvidersSection;

            String xmlFile = sec.HomeHealthProviders[sec.HomeHealthProviderName].Parameters["dataFile"];
            String xsdFile = sec.HomeHealthProviders[sec.HomeHealthProviderName].Parameters["schemaFile"];

            _xmlFile = HttpContext.Current.Request.MapPath("~/App_Data/" + xmlFile);
            _xsdFile = HttpContext.Current.Request.MapPath("~/App_Data/schemas/" + xsdFile);
        }

        void IDisposable.Dispose() { }

        /// <summary>
        /// Returns all the home health information
        /// </summary>
        /// <returns></returns>
        public override List<CommonExchange.HomeHealth> SelectAsListHomeHealthInformation()
        {
            DataSet dbSet = Util.ReadAndValidateXml(_xmlFile, _xsdFile);
            List<CommonExchange.HomeHealth> list = new List<CommonExchange.HomeHealth>();

            if (dbSet.Tables["home_health_item"] != null)
            {
                DataRow[] selectRow = dbSet.Tables["home_health_item"].Select("", "home_health_id ASC");

                foreach (DataRow hRow in selectRow)
                {
                    CommonExchange.HomeHealth hItem = new CommonExchange.HomeHealth();

                    hItem.HomeHealthId = hRow["home_health_id"] is DBNull ? 0 : (Int32)hRow["home_health_id"];
                    hItem.HomeHealthName = hRow["home_health_name"] is DBNull ? String.Empty : (String)hRow["home_health_name"];
                    hItem.OfficeAddress = hRow["office_address"] is DBNull ? String.Empty : (String)hRow["office_address"];
                    hItem.PhoneNos = hRow["phone_nos"] is DBNull ? String.Empty : (String)hRow["phone_nos"];
                    hItem.FaxNos = hRow["fax_nos"] is DBNull ? String.Empty : (String)hRow["fax_nos"];
                    hItem.DateCertified = hRow["date_certified"] is DBNull ? DateTime.MinValue : (DateTime)hRow["date_certified"];
                    hItem.NationalProviderId = hRow["national_provider_id"] is DBNull ? String.Empty : (String)hRow["national_provider_id"];
                    hItem.Ownership = hRow["ownership"] is DBNull ? String.Empty : (String)hRow["ownership"];
                    hItem.Owner = hRow["owner"] is DBNull ? String.Empty : (String)hRow["owner"];
                    hItem.Administrator = hRow["administrator"] is DBNull ? String.Empty : (String)hRow["administrator"];
                    hItem.DirectorOfNursing = hRow["director_of_nursing"] is DBNull ? String.Empty : (String)hRow["director_of_nursing"];
                    hItem.MedicareProviderNo = hRow["medicare_provider_no"] is DBNull ? String.Empty : (String)hRow["medicare_provider_no"];
                    hItem.WebSite = hRow["website"] is DBNull ? String.Empty : (String)hRow["website"];
                    hItem.LogoPath = hRow["logo_path"] is DBNull ? String.Empty : (String)hRow["logo_path"];

                    list.Add(hItem);
                }
            }

            return list;
        }

        /// <summary>
        /// Returns all the home health information
        /// </summary>
        /// <returns></returns>
        public override DataTable SelectAsTableHomeHealthInformation()
        {
            DataSet dbSet = Util.ReadAndValidateXml(_xmlFile, _xsdFile);

            DataTable dbTable = new DataTable("HomeHealthInformationTable");
            dbTable.Columns.Add("home_health_id", System.Type.GetType("System.Int32"));
            dbTable.Columns.Add("home_health_name", System.Type.GetType("System.String"));
            dbTable.Columns.Add("office_address", System.Type.GetType("System.String"));
            dbTable.Columns.Add("phone_nos", System.Type.GetType("System.String"));
            dbTable.Columns.Add("fax_nos", System.Type.GetType("System.String"));
            dbTable.Columns.Add("date_certified", System.Type.GetType("System.DateTime"));
            dbTable.Columns.Add("national_provider_id", System.Type.GetType("System.String"));
            dbTable.Columns.Add("ownership", System.Type.GetType("System.String"));
            dbTable.Columns.Add("owner", System.Type.GetType("System.String"));
            dbTable.Columns.Add("administrator", System.Type.GetType("System.String"));
            dbTable.Columns.Add("director_of_nursing", System.Type.GetType("System.String"));
            dbTable.Columns.Add("medicare_provider_no", System.Type.GetType("System.String"));
            dbTable.Columns.Add("website", System.Type.GetType("System.String"));
            dbTable.Columns.Add("logo_path", System.Type.GetType("System.String"));

            if (dbSet.Tables["home_health_item"] != null)
            {

                DataRow[] selectRow = dbSet.Tables["home_health_item"].Select("", "home_health_name ASC");

                foreach (DataRow hRow in selectRow)
                {
                    DataRow newRow = dbTable.NewRow();

                    newRow["home_health_id"] = hRow["home_health_id"] is DBNull ? 0 : (Int32)hRow["home_health_id"];
                    newRow["home_health_name"] = hRow["home_health_name"] is DBNull ? String.Empty : (String)hRow["home_health_name"];
                    newRow["office_address"] = hRow["office_address"] is DBNull ? String.Empty : (String)hRow["office_address"];
                    newRow["phone_nos"] = hRow["phone_nos"] is DBNull ? String.Empty : (String)hRow["phone_nos"];
                    newRow["fax_nos"] = hRow["fax_nos"] is DBNull ? String.Empty : (String)hRow["fax_nos"];
                    newRow["date_certified"] = hRow["date_certified"] is DBNull ? DateTime.MinValue : (DateTime)hRow["date_certified"];
                    newRow["national_provider_id"] = hRow["national_provider_id"] is DBNull ? String.Empty : (String)hRow["national_provider_id"];
                    newRow["ownership"] = hRow["ownership"] is DBNull ? String.Empty : (String)hRow["ownership"];
                    newRow["owner"] = hRow["owner"] is DBNull ? String.Empty : (String)hRow["owner"];
                    newRow["administrator"] = hRow["administrator"] is DBNull ? String.Empty : (String)hRow["administrator"];
                    newRow["director_of_nursing"] = hRow["director_of_nursing"] is DBNull ? String.Empty : (String)hRow["director_of_nursing"];
                    newRow["medicare_provider_no"] = hRow["medicare_provider_no"] is DBNull ? String.Empty : (String)hRow["medicare_provider_no"];
                    newRow["website"] = hRow["website"] is DBNull ? String.Empty : (String)hRow["website"];
                    newRow["logo_path"] = hRow["logo_path"] is DBNull ? String.Empty : (String)hRow["logo_path"];

                    dbTable.Rows.Add(newRow);
                }

            }

            dbTable.AcceptChanges();

            return dbTable;
        }

        /// <summary>
        /// This procedure inserts a new home health information
        /// </summary>
        /// <param name="homeHealthInfo"></param>
        public override void InsertHomeHealthInformation(CommonExchange.HomeHealth homeHealthInfo)
        {
            List<CommonExchange.HomeHealth> list = this.SelectAsListHomeHealthInformation();

            using (XmlTextWriter writer = new XmlTextWriter(_xmlFile, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 5;
                writer.WriteStartDocument();
                writer.WriteStartElement("home_health_information"); //home_health_information start 

                foreach (CommonExchange.HomeHealth h in list)
                {

                    writer.WriteStartElement("home_health_item"); //home_health_item start

                    writer.WriteElementString("home_health_id", h.HomeHealthId.ToString());
                    writer.WriteElementString("home_health_name", h.HomeHealthName);
                    writer.WriteElementString("office_address", h.OfficeAddress);
                    writer.WriteElementString("phone_nos", h.PhoneNos);
                    writer.WriteElementString("fax_nos", h.FaxNos);
                    writer.WriteElementString("date_certified", h.DateCertified.ToString("yyyy-MM-dd") + "T23:59:59.0Z");
                    writer.WriteElementString("national_provider_id", h.NationalProviderId);
                    writer.WriteElementString("ownership", h.Ownership);
                    writer.WriteElementString("owner", h.Owner);
                    writer.WriteElementString("administrator", h.Administrator);
                    writer.WriteElementString("director_of_nursing", h.DirectorOfNursing);
                    writer.WriteElementString("medicare_provider_no", h.MedicareProviderNo);
                    writer.WriteElementString("website", h.WebSite);
                    writer.WriteElementString("logo_path", h.LogoPath);

                    writer.WriteEndElement(); //home_health_item end
                }

                writer.WriteStartElement("home_health_item"); //home_health_item start

                writer.WriteElementString("home_health_id", (list.Count + 1).ToString());
                writer.WriteElementString("home_health_name", homeHealthInfo.HomeHealthName);
                writer.WriteElementString("office_address", homeHealthInfo.OfficeAddress);
                writer.WriteElementString("phone_nos", homeHealthInfo.PhoneNos);
                writer.WriteElementString("fax_nos", homeHealthInfo.FaxNos);
                writer.WriteElementString("date_certified", homeHealthInfo.DateCertified.ToString("yyyy-MM-dd") + "T23:59:59.0Z");
                writer.WriteElementString("national_provider_id", homeHealthInfo.NationalProviderId);
                writer.WriteElementString("ownership", homeHealthInfo.Ownership);
                writer.WriteElementString("owner", homeHealthInfo.Owner);
                writer.WriteElementString("administrator", homeHealthInfo.Administrator);
                writer.WriteElementString("director_of_nursing", homeHealthInfo.DirectorOfNursing);
                writer.WriteElementString("medicare_provider_no", homeHealthInfo.MedicareProviderNo);
                writer.WriteElementString("website", homeHealthInfo.WebSite);
                writer.WriteElementString("logo_path", homeHealthInfo.LogoPath);

                writer.WriteEndElement(); //home_health_item end

                writer.WriteEndElement(); //home_health_information end
                writer.WriteEndDocument();
                writer.Close();
            }
        }

        /// <summary>
        /// This procedure updates home health information
        /// </summary>
        /// <param name="homeHealthInfo"></param>
        public override void UpdateHomeHealthInformation(CommonExchange.HomeHealth homeHealthInfo)
        {
            List<CommonExchange.HomeHealth> list = this.SelectAsListHomeHealthInformation();

            using (XmlTextWriter writer = new XmlTextWriter(_xmlFile, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 5;
                writer.WriteStartDocument();
                writer.WriteStartElement("home_health_information"); //home_health_information start 

                foreach (CommonExchange.HomeHealth h in list)
                {
                    if (h.HomeHealthId == homeHealthInfo.HomeHealthId)
                    {
                        writer.WriteStartElement("home_health_item"); //home_health_item start

                        writer.WriteElementString("home_health_id", homeHealthInfo.HomeHealthId.ToString());
                        writer.WriteElementString("home_health_name", homeHealthInfo.HomeHealthName);
                        writer.WriteElementString("office_address", homeHealthInfo.OfficeAddress);
                        writer.WriteElementString("phone_nos", homeHealthInfo.PhoneNos);
                        writer.WriteElementString("fax_nos", homeHealthInfo.FaxNos);
                        writer.WriteElementString("date_certified", homeHealthInfo.DateCertified.ToString("yyyy-MM-dd") + "T23:59:59.0Z");
                        writer.WriteElementString("national_provider_id", homeHealthInfo.NationalProviderId);
                        writer.WriteElementString("ownership", homeHealthInfo.Ownership);
                        writer.WriteElementString("owner", homeHealthInfo.Owner);
                        writer.WriteElementString("administrator", homeHealthInfo.Administrator);
                        writer.WriteElementString("director_of_nursing", homeHealthInfo.DirectorOfNursing);
                        writer.WriteElementString("medicare_provider_no", homeHealthInfo.MedicareProviderNo);
                        writer.WriteElementString("website", homeHealthInfo.WebSite);
                        writer.WriteElementString("logo_path", homeHealthInfo.LogoPath);

                        writer.WriteEndElement(); //home_health_item end
                    }
                    else
                    {
                        writer.WriteStartElement("home_health_item"); //home_health_item start

                        writer.WriteElementString("home_health_id", h.HomeHealthId.ToString());
                        writer.WriteElementString("home_health_name", h.HomeHealthName);
                        writer.WriteElementString("office_address", h.OfficeAddress);
                        writer.WriteElementString("phone_nos", h.PhoneNos);
                        writer.WriteElementString("fax_nos", h.FaxNos);
                        writer.WriteElementString("date_certified", h.DateCertified.ToString("yyyy-MM-dd") + "T23:59:59.0Z");
                        writer.WriteElementString("national_provider_id", h.NationalProviderId);
                        writer.WriteElementString("ownership", h.Ownership);
                        writer.WriteElementString("owner", h.Owner);
                        writer.WriteElementString("administrator", h.Administrator);
                        writer.WriteElementString("director_of_nursing", h.DirectorOfNursing);
                        writer.WriteElementString("medicare_provider_no", h.MedicareProviderNo);
                        writer.WriteElementString("website", h.WebSite);
                        writer.WriteElementString("logo_path", h.LogoPath);

                        writer.WriteEndElement(); //home_health_item end
                    }
                }

                writer.WriteEndElement(); //home_health_information end
                writer.WriteEndDocument();
                writer.Close();
            }
        }

        /// <summary>
        /// This function saves and returns the image logo path of the home health information
        /// </summary>
        /// <param name="page"></param>
        /// <param name="fileUpload"></param>
        /// <returns></returns>
        public override string SaveHomeHealthInformationLogoImageUrl(Page page, FileUpload fileUpload)
        {
            String imageUrl = String.Empty;
            String saveDir = CommonExchange.SystemConfiguration.LogoLocalImagesPath;
            String appPath = page.Request.PhysicalApplicationPath;

            if (fileUpload.HasFile && Directory.Exists(appPath + saveDir))
            {
                imageUrl = "logo" + (this.SelectAsListHomeHealthInformation().Count + 1).ToString() + Path.GetExtension(fileUpload.FileName);
                String savePath = appPath + saveDir + imageUrl;

                fileUpload.SaveAs(savePath);
            }

            return imageUrl;
        }

        /// <summary>
        /// This function updates and returns the image logo path of the home health information
        /// </summary>
        /// <param name="homeHealthId"></param>
        /// <param name="page"></param>
        /// <param name="fileUpload"></param>
        /// <returns></returns>
        public override string UpdateHomeHealthInformationLogoImageUrl(int homeHealthId, Page page, FileUpload fileUpload)
        {
            String imageUrl = String.Empty;
            String saveDir = CommonExchange.SystemConfiguration.LogoLocalImagesPath;
            String appPath = page.Request.PhysicalApplicationPath;

            if (fileUpload.HasFile && Directory.Exists(appPath + saveDir))
            {
                imageUrl = "logo" + homeHealthId.ToString() + Path.GetExtension(fileUpload.FileName);
                String savePath = appPath + saveDir + imageUrl;

                fileUpload.SaveAs(savePath);
            }

            return imageUrl;
        }
    }
}