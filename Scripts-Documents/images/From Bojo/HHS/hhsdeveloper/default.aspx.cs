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

public partial class _Default : System.Web.UI.Page
{

    #region Class Event Void Procedures
    /// <summary>
    /// Event is raised when the page is initialized
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Init(object sender, EventArgs e)
    {
        this.pnlHomeHealSearch.Visible = true;

        DataTable homeHealthTable = (DataTable)Cache[CommonExchange.CacheName.HomeHealthInformation];

        if (homeHealthTable == null)
        {
            Cache.Insert(CommonExchange.CacheName.HomeHealthInformation, HomeHealthSearch.HomeHealth.SelectAsTableHomeHealthInformation());
        }       

        
    }//-----------------------

    /// <summary>
    /// Event is raised when the Page is Loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        String querystring = "%" + this.txtSearch.Text + "%";

        if (!this.IsPostBack)
        {
            if (Request.QueryString["querystring"] != null)
            {
                querystring = Request.QueryString["querystring"].ToString();
            }

           this.chkHomeHealthName.Checked = Request.QueryString["ch"] != null ? Boolean.Parse(Request.QueryString["chh"]) : true;
           this.chkAddress.Checked = Request.QueryString["cad"] != null ? Boolean.Parse(Request.QueryString["cad"]) : true;
           this.chkPhone.Checked = Request.QueryString["cpn"] != null ? Boolean.Parse(Request.QueryString["cpn"]) : true;
           this.chkFaxNo.Checked = Request.QueryString["cfn"] != null ? Boolean.Parse(Request.QueryString["cfn"]) : true;
           this.chkNationalProviderId.Checked = Request.QueryString["cnp"] != null ? Boolean.Parse(Request.QueryString["cnp"]) : true;
           this.chkOwnership.Checked = Request.QueryString["cos"] != null ? Boolean.Parse(Request.QueryString["cos"]) : true;
           this.chkOwner.Checked = Request.QueryString["cor"] != null ? Boolean.Parse(Request.QueryString["cor"]) : true;
           this.chkAdministrator.Checked = Request.QueryString["cam"] != null ? Boolean.Parse(Request.QueryString["cam"]) : true;
           this.chkDirectorOfNursing.Checked = Request.QueryString["cdn"] != null ? Boolean.Parse(Request.QueryString["cdn"]) : true;
           this.chkMedicareProviderNo.Checked = Request.QueryString["cmp"] != null ? Boolean.Parse(Request.QueryString["cmp"]) : true;
           
        }
        else
        {
            this.lnkGo.NavigateUrl = "~/default.aspx?panelview=search&querystring=%" + this.txtSearch.Text + "%&chh=" + this.chkHomeHealthName.Checked.ToString() +
                "&cad=" + this.chkAddress.Checked.ToString() + "&cpn=" + this.chkPhone.Checked.ToString() + "&cfn=" + this.chkFaxNo.Checked.ToString() +
                "&cnp=" + this.chkNationalProviderId.Checked.ToString() + "&cos=" + this.chkOwnership.Checked.ToString() + "&cor=" + this.chkOwner.Checked.ToString() +
                "&cam=" + this.chkAdministrator.Checked.ToString() + "&cdn=" + this.chkDirectorOfNursing.Checked.ToString() + "&cmp=" + this.chkMedicareProviderNo.Checked.ToString();
        }
      
        this.dgvHomeHealth.DataSource = this.GetSearchedHomeHealthInformation(querystring);
        this.dgvHomeHealth.DataBind();
    }//----------------------

    /// <summary>
    /// Event is raised when the control is binded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dgvHomeHealthRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            Image pbxBase = (Image)e.Row.FindControl("imgLogoHomeHealth");

            String fileName = (String)DataBinder.Eval(e.Row.DataItem, "LogoPath");
            String appPath = this.Request.PhysicalApplicationPath;

            if (!Base.ProcStatic.FileExists(appPath + CommonExchange.SystemConfiguration.LogoLocalImagesPath + fileName))
            {
                pbxBase.ImageUrl = CommonExchange.SystemConfiguration.LogoVirtualImagePath + "noimage.jpg";
            }
            else
            {
                pbxBase.ImageUrl = CommonExchange.SystemConfiguration.LogoVirtualImagePath + fileName;
            }         
        }
    }//----------------------

    /// <summary>
    /// Event is raised when the dgvOrderCart page index change
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dgvHomeHealthPageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.dgvHomeHealth.PageIndex = e.NewPageIndex;
        this.dgvHomeHealth.DataBind();
    }//----------------------------   
    #endregion

    #region Programmer's Defined Functions
    //this function will return the searched home health information
    private List<CommonExchange.HomeHealth> GetSearchedHomeHealthInformation(String querystring)
    {
        List<CommonExchange.HomeHealth> homeHealthList = new List<CommonExchange.HomeHealth>();

        querystring = querystring.Replace("*", "").Replace("'", "''");

        DataTable homeHealthTable = (DataTable)Cache[CommonExchange.CacheName.HomeHealthInformation];

        if (homeHealthTable == null)
        {
            Cache.Insert(CommonExchange.CacheName.HomeHealthInformation, HomeHealthSearch.HomeHealth.SelectAsTableHomeHealthInformation());
        }

        if (homeHealthTable != null)
        {
            //String strFilter = "home_health_name LIKE '" + querystring + "' OR office_address LIKE '" + querystring + "' OR phone_nos LIKE '" + querystring +
            //    "' OR fax_nos LIKE '" + querystring + "' OR national_provider_id LIKE '" + querystring +
            //    "' OR ownership LIKE '" + querystring + "' OR owner LIKE '" + querystring + "' OR administrator LIKE '" + querystring +
            //    "' OR director_of_nursing LIKE '" + querystring + "' OR medicare_provider_no LIKE '" + querystring + "'";

            String strFilter = String.Empty;

            strFilter = this.chkHomeHealthName.Checked ? "home_health_name LIKE '" + querystring + "'" : strFilter;
            strFilter += this.chkAddress.Checked ? (!String.IsNullOrEmpty(strFilter) ? " OR office_address LIKE '" + querystring + "'" :
                " office_address LIKE '" + querystring + "'") : String.Empty;
            strFilter += this.chkPhone.Checked ? (!String.IsNullOrEmpty(strFilter) ? " OR phone_nos LIKE '" + querystring + "'" :
                " phone_nos LIKE '" + querystring + "'") : String.Empty;
            strFilter += this.chkFaxNo.Checked ? (!String.IsNullOrEmpty(strFilter) ? " OR fax_nos LIKE '" + querystring + "'" :
                " fax_nos LIKE '" + querystring + "'") : String.Empty;
            strFilter += this.chkNationalProviderId.Checked ? (!String.IsNullOrEmpty(strFilter) ? " OR national_provider_id LIKE '" + querystring + "'" :
                " national_provider_id LIKE '" + querystring + "'") : String.Empty;
            strFilter += this.chkOwnership.Checked ? (!String.IsNullOrEmpty(strFilter) ? " OR ownership LIKE '" + querystring + "'" :
                " ownership LIKE '" + querystring + "'") : String.Empty;
            strFilter += this.chkOwner.Checked ? (!String.IsNullOrEmpty(strFilter) ? " OR owner LIKE '" + querystring + "'" :
                " owner LIKE '" + querystring + "'") : String.Empty;
            strFilter += this.chkAdministrator.Checked ? (!String.IsNullOrEmpty(strFilter) ? " OR administrator LIKE '" + querystring + "'" :
                " administrator LIKE '" + querystring + "'") : String.Empty;
            strFilter += this.chkDirectorOfNursing.Checked ? (!String.IsNullOrEmpty(strFilter) ? " OR director_of_nursing LIKE '" + querystring + "'" :
                " director_of_nursing LIKE '" + querystring + "'") : String.Empty;
            strFilter += this.chkMedicareProviderNo.Checked ? (!String.IsNullOrEmpty(strFilter) ? " OR medicare_provider_no LIKE '" + querystring + "'" :
                " OR medicare_provider_no LIKE '" + querystring + "'") : String.Empty;

            DataRow[] selectRow = homeHealthTable.Select(strFilter);

            foreach (DataRow hRow in selectRow)
            {
                CommonExchange.HomeHealth homeHealthInfo = new CommonExchange.HomeHealth();

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

                homeHealthList.Add(homeHealthInfo); 
            }
        }

        return homeHealthList;
    }//------------------
    #endregion

   
}
