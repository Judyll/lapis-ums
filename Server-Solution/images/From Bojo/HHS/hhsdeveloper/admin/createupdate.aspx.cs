using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Caching;

public partial class createupdate : System.Web.UI.Page
{
    #region Class Event Void Procedures
    /// <summary>
    /// Event is raised when the pase is initialized
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Init(object sender, EventArgs e)
    {
        if (Request.QueryString["signout"] != null && String.Equals(Request.QueryString["signout"], "yes"))
        {
            Session["users"] = null;

            Response.Redirect("~/admin/default.aspx");
        }

        CommonExchange.Users userInfo = (CommonExchange.Users)Session["users"];

        if (userInfo == null)
        {
            Response.Redirect("~/admin/default.aspx");
        }

        if (String.Equals(Request.QueryString["panelview"], "create"))
        {
            this.lblFormDescription.Text = "Create Home Health Information";
            this.btnCreateUpdateHomeHealth.Text = "Create";
            this.btnCreateUpdateHomeHealth.PostBackUrl = "~/admin/createupdate.aspx?createhomehealth=yes";
            this.imgDisplayLogo.Visible = false;
        }
        else if (String.Equals(Request.QueryString["panelview"], "update"))
        {
            this.lblFormDescription.Text = "Update Home Health Information";
            this.btnCreateUpdateHomeHealth.Text = "Update";
            this.btnCreateUpdateHomeHealth.PostBackUrl = "~/admin/createupdate.aspx?createhomehealth=no";
            this.imgDisplayLogo.Visible = true;
        }
    }//------------------------

    /// <summary>
    /// Event is raised when the page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!this.IsPostBack)
        {
            if (Request.QueryString["errorstring"] != null)
            {
                this.lblError.Visible = true;

                this.lblError.Text = Request.QueryString["errorstring"].ToString();
            }
            else
            {
                this.lblError.Visible = false;
            }

            //-------- START QUERY STRING ((( homehealthid ))) ----------------
            if (Request.QueryString["homehealthid"] != null && !String.IsNullOrEmpty(Request.QueryString["homehealthid"].ToString()))
            {
                CommonExchange.HomeHealth homeHealthInfo = this.GetDetailsHomeHealthInformation(Int32.Parse(Request.QueryString["homehealthid"].ToString()));

                this.txtHomeHealthName.Text = homeHealthInfo.HomeHealthName;
                this.txtOfficeAddress.Text = homeHealthInfo.OfficeAddress;
                this.txtPhoneNo.Text = homeHealthInfo.PhoneNos;
                this.txtFaxNo.Text = homeHealthInfo.FaxNos;

                if (!String.IsNullOrEmpty(homeHealthInfo.DateCertified.ToString()))
                {
                    this.dtpDateCertified.SelectedDate = homeHealthInfo.DateCertified;
                }

                this.txtNationalProviderId.Text = homeHealthInfo.NationalProviderId;
                this.txtOwnerShip.Text = homeHealthInfo.Ownership;
                this.txtOwner.Text = homeHealthInfo.Owner;
                this.txtAdministrator.Text = homeHealthInfo.Administrator;
                this.txtDirectorOfNursing.Text = homeHealthInfo.DirectorOfNursing;
                this.txtMedicareProviderNo.Text = homeHealthInfo.MedicareProviderNo;
                this.txtWebsite.Text = homeHealthInfo.WebSite;

                String appPath = this.Request.PhysicalApplicationPath;

                if (!Base.ProcStatic.FileExists(appPath + CommonExchange.SystemConfiguration.LogoLocalImagesPath + homeHealthInfo.LogoPath))
                {
                    imgDisplayLogo.ImageUrl = CommonExchange.SystemConfiguration.LogoVirtualImagePath + "noimage.jpg";
                }
                else
                {
                    imgDisplayLogo.ImageUrl = CommonExchange.SystemConfiguration.LogoVirtualImagePath + homeHealthInfo.LogoPath;
                }   

                this.btnCreateUpdateHomeHealth.PostBackUrl += "&homehealthid=" + homeHealthInfo.HomeHealthId;
            }
            //-------- END QUERY STRING ((( homehealthid ))) ----------------
        }
        else
        {
            //-------- START QUERY STRING ((( createhomehealth ))) ----------------
            if (Request.QueryString["createhomehealth"] != null && String.Equals(Request.QueryString["createhomehealth"], "yes"))
            {
                CommonExchange.HomeHealth homeHealthInfo = new CommonExchange.HomeHealth();

                homeHealthInfo.HomeHealthName = this.txtHomeHealthName.Text;
                homeHealthInfo.OfficeAddress = this.txtOfficeAddress.Text;
                homeHealthInfo.PhoneNos = this.txtPhoneNo.Text;
                homeHealthInfo.FaxNos = this.txtFaxNo.Text;
                homeHealthInfo.DateCertified = DateTime.Parse(this.dtpDateCertified.SelectedDate.ToShortDateString() + " 12:00:00 AM");
                homeHealthInfo.NationalProviderId = this.txtNationalProviderId.Text;
                homeHealthInfo.Ownership = this.txtOwnerShip.Text;
                homeHealthInfo.Owner = this.txtOwner.Text;
                homeHealthInfo.Administrator = this.txtAdministrator.Text;
                homeHealthInfo.DirectorOfNursing = this.txtDirectorOfNursing.Text;
                homeHealthInfo.MedicareProviderNo = this.txtMedicareProviderNo.Text;
                homeHealthInfo.WebSite = this.txtWebsite.Text;

                if (!String.IsNullOrEmpty(fudLogo.FileName))
                {
                    homeHealthInfo.LogoPath = HomeHealthSearch.HomeHealth.SaveHomeHealthInformationLogoImageUrl(this, fudLogo);
                }
                else
                {
                    homeHealthInfo.LogoPath = "noimage.jpg";
                }

                if (this.ValidateControls(homeHealthInfo))
                {
                    HomeHealthSearch.HomeHealth.InsertHomeHealthInformation(homeHealthInfo);
                }
                else
                {
                    Response.Redirect("~/admin/createupdate.aspx?errorstring=Required field must be fill up.&panelview=create");
                }

                Cache[CommonExchange.CacheName.HomeHealthInformation] = HomeHealthSearch.HomeHealth.SelectAsTableHomeHealthInformation();

                Response.Redirect("~/admin/search.aspx?panelview=search&querystring=%%");
            }
            else if (Request.QueryString["createhomehealth"] != null && String.Equals(Request.QueryString["createhomehealth"], "no"))
            {
                if (!String.IsNullOrEmpty(Request.QueryString["homehealthid"].ToString()))
                {
                    CommonExchange.HomeHealth homeHealthInfo = this.GetDetailsHomeHealthInformation(Int32.Parse(Request.QueryString["homehealthid"].ToString()));

                    homeHealthInfo.HomeHealthName = this.txtHomeHealthName.Text;
                    homeHealthInfo.OfficeAddress = this.txtOfficeAddress.Text;
                    homeHealthInfo.PhoneNos = this.txtPhoneNo.Text;
                    homeHealthInfo.FaxNos = this.txtFaxNo.Text;
                    homeHealthInfo.DateCertified = DateTime.Parse(this.dtpDateCertified.SelectedDate.ToShortDateString() + " 12:00:00 AM");
                    homeHealthInfo.NationalProviderId = this.txtNationalProviderId.Text;
                    homeHealthInfo.Ownership = this.txtOwnerShip.Text;
                    homeHealthInfo.Owner = this.txtOwner.Text;
                    homeHealthInfo.Administrator = this.txtAdministrator.Text;
                    homeHealthInfo.DirectorOfNursing = this.txtDirectorOfNursing.Text;
                    homeHealthInfo.MedicareProviderNo = this.txtMedicareProviderNo.Text;
                    homeHealthInfo.WebSite = this.txtWebsite.Text;

                    if (!String.IsNullOrEmpty(fudLogo.FileName))
                    {
                        homeHealthInfo.LogoPath = HomeHealthSearch.HomeHealth.UpdateHomeHealthInformationLogoImageUrl(homeHealthInfo.HomeHealthId, this, fudLogo);
                    }
                  
                    if (this.ValidateControls(homeHealthInfo))
                    {
                        HomeHealthSearch.HomeHealth.UpdateHomeHealthInformation(homeHealthInfo);
                    }
                    else
                    {
                        Response.Redirect("~/admin/createupdate.aspx?errorstring=Required field must be fill up.&panelview=update");
                    }

                    Cache[CommonExchange.CacheName.HomeHealthInformation] = HomeHealthSearch.HomeHealth.SelectAsTableHomeHealthInformation();

                    Response.Redirect("~/admin/search.aspx?panelview=search&querystring=%%");
                }
            }
            //-------- END QUERY STRING ((( createhomehealth ))) ----------------            
        }
    }//----------------------
    #endregion

    #region Programmer's Defined Functions
    //this function will get details home health information
    private CommonExchange.HomeHealth GetDetailsHomeHealthInformation(Int32 homeHealthId)
    {
        CommonExchange.HomeHealth homeHealthInfo = new CommonExchange.HomeHealth();

          DataTable homeHealthTable = (DataTable)Cache[CommonExchange.CacheName.HomeHealthInformation];

        if (homeHealthTable == null)
        {
            Cache.Insert(CommonExchange.CacheName.HomeHealthInformation, HomeHealthSearch.HomeHealth.SelectAsTableHomeHealthInformation());
        }

        String strFilter = "home_health_id = " + homeHealthId;
        DataRow[] selectRow = homeHealthTable.Select(strFilter);

        foreach (DataRow hRow in selectRow)
        {
            homeHealthInfo.HomeHealthId = hRow["home_health_id"] is DBNull ? 0 : (Int32)hRow["home_health_id"];
            homeHealthInfo.HomeHealthName = hRow["home_health_name"] is DBNull ? String.Empty : (String)hRow["home_health_name"];
            homeHealthInfo.OfficeAddress = hRow["office_address"] is DBNull ? String.Empty : (String)hRow["office_address"];
            homeHealthInfo.PhoneNos = hRow["phone_nos"] is DBNull ? String.Empty : (String)hRow["phone_nos"];
            homeHealthInfo.FaxNos = hRow["fax_nos"] is DBNull ? String.Empty : (String)hRow["fax_nos"];
            homeHealthInfo.DateCertified = hRow["date_certified"] is DBNull ? DateTime.MinValue : (DateTime)hRow["date_certified"];
            homeHealthInfo.NationalProviderId = hRow["national_provider_id"] is DBNull ? String.Empty : (String)hRow["national_provider_id"];
            homeHealthInfo.Ownership = hRow["ownership"] is DBNull ? String.Empty : (String)hRow["ownership"];
            homeHealthInfo.Owner = hRow["owner"] is DBNull ? String.Empty : (String)hRow["owner"];
            homeHealthInfo.Administrator = hRow["administrator"] is DBNull ? String.Empty : (String)hRow["administrator"];
            homeHealthInfo.DirectorOfNursing = hRow["director_of_nursing"] is DBNull ? String.Empty : (String)hRow["director_of_nursing"];
            homeHealthInfo.MedicareProviderNo = hRow["medicare_provider_no"] is DBNull ? String.Empty : (String)hRow["medicare_provider_no"];
            homeHealthInfo.LogoPath = hRow["logo_path"] is DBNull ? String.Empty : (String)hRow["logo_path"];
            homeHealthInfo.WebSite = hRow["website"] is DBNull ? String.Empty : (String)hRow["website"];

            break;
        }

        return homeHealthInfo;
    }//-----------------------

    //this function will validate controls
    private Boolean ValidateControls(CommonExchange.HomeHealth homeHealthInfo)
    {
        Boolean isValid = false;

        if (!String.IsNullOrEmpty(homeHealthInfo.HomeHealthName) && !String.IsNullOrEmpty(homeHealthInfo.OfficeAddress) &&
            !String.IsNullOrEmpty(homeHealthInfo.PhoneNos) && !String.IsNullOrEmpty(homeHealthInfo.FaxNos) && !String.IsNullOrEmpty(homeHealthInfo.NationalProviderId) &&
            !String.IsNullOrEmpty(homeHealthInfo.Owner) && !String.IsNullOrEmpty(homeHealthInfo.Ownership) && !String.IsNullOrEmpty(homeHealthInfo.Administrator) &&
            !String.IsNullOrEmpty(homeHealthInfo.DirectorOfNursing) && !String.IsNullOrEmpty(homeHealthInfo.MedicareProviderNo) && !String.IsNullOrEmpty(homeHealthInfo.LogoPath))
        {
            isValid = true;
        }

        return isValid;
    }//-----------------------
    #endregion


}
