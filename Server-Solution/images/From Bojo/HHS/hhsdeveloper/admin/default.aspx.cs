using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class login : System.Web.UI.Page
{
    #region Class Event Void Procedures
    /// <summary>
    /// Event is raised when the page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            CommonExchange.Users userInfo = (CommonExchange.Users)Session["users"];

            if (userInfo != null)
            {
                Session["users"] = null;
            }

            Session.Clear();

        }
    }//---------------------

    /// <summary>
    /// Event is raised whent the button submit is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmitClick(object sender, EventArgs e)
    {
        CommonExchange.Users userInfo = new CommonExchange.Users();

        userInfo.UserName = this.txtUsername.Text;
        userInfo.Password = this.txtPassword.Text;

        try
        {
            if (HomeHealthSearch.Users.IsActiveUser(userInfo))
            {
                Session["users"] = userInfo;

                Response.Redirect("~/admin/search.aspx");
            }
            else
            {
                //Response.Write("<script language='javascript'> alert('You have entered some information that is incorrect. Please try again.');</script>");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }//-------------------------

    /// <summary>
    /// Event is raised when the reset button is clicked
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnResetClick(object sender, EventArgs e)
    {
        this.txtUsername.Text = String.Empty;
        this.txtPassword.Text = String.Empty;
        this.txtUsername.Focus();
    }//---------------------
    #endregion
}
