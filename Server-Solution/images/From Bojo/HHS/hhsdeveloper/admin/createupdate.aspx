<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createupdate.aspx.cs" Inherits="createupdate" %>

<%@ Register Assembly="EO.Web" Namespace="EO.Web" TagPrefix="eo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>NewMediaIX HomeHealth Search</title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link rel="Stylesheet" href="StyleSheetAdmin.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    
     <div id="header">
            <div class="container">
                <a href= "#" id= "logo"></a>
                <ul id = "main-menu">
                    <li class = "active"><a href = "default.aspx">Home</a></li>
                    <li><a href = "http://newmediaix.com/about_us.html">About</a></li>
                    <li><a href = "http://newmediaix.com/services.html">Services</a></li>
                    <li><a href = "http://newmediaix.com/portfolio.html">Portfolio</a></li>
                    <li><a href = "http://newmediaix.com/contacts.html">Contact</a></li>
                    <li><asp:HyperLink ID="lnkSigOut" runat="server" NavigateUrl="~/admin/createupdate.aspx?signout=yes">Sign Out</asp:HyperLink></li>
                </ul>
            </div>
       </div><%--end of header--%>
       
       <div id="main">
         <div id="wrapper">
            <div class="container">
                <div id="content">
                   <div id="update">
                        <asp:Panel ID="pnlHomeHealth" runat="server" OnInit="Page_Init">   
                        <div class="error_msg"><asp:Label ID="lblError" runat="server" Visible="false" ForeColor="red"></asp:Label></div>
                             <table>                                    
                                    <tr>
                                        <td colspan="3"><b><asp:Label ID="lblFormDescription" runat="server" ></asp:Label></b></td>
                                    </tr>
                                    <tr>
                                        <td><asp:Label ID="Label49" runat="server" Text="*Home Health Name:"></asp:Label></td>
                                        <td><asp:TextBox ID="txtHomeHealthName" runat="server" AutoPostBack="false" Width="222px"></asp:TextBox></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                     <tr>
                                        <td><asp:Label ID="Label50" runat="server" Text="*Office Address:"></asp:Label></td>
                                        <td><asp:TextBox ID="txtOfficeAddress" runat="server" AutoPostBack="false" Width="222px"></asp:TextBox></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td><asp:Label ID="Label51" runat="server" Text="*Phone Nos.:"></asp:Label></td>
                                        <td><asp:TextBox ID="txtPhoneNo" runat="server" AutoPostBack="false" Width="222px"></asp:TextBox></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td><asp:Label ID="Label53" runat="server" Text="*Fax Nos.:"></asp:Label></td>
                                        <td><asp:TextBox ID="txtFaxNo" runat="server" AutoPostBack="false" Width="222px"></asp:TextBox></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td><asp:Label ID="Label58" runat="server" Text="Date Certified:" ></asp:Label></td>
                                        <td>
                                            <eo:DatePicker ID="dtpDateCertified" runat="server" DayCellHeight="16" DayCellWidth="21"
                                                DayHeaderFormat="FirstLetter" GridLineColor="207, 217, 227" GridLineFrameVisible="False"
                                                GridLineVisible="True" TitleFormat="MMM yyyy" TitleLeftArrowHtml="<" TitleRightArrowHtml=">"
                                                Width="228px">
                                                <SelectedDayStyle CssText="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; background-color: white" />
                                                <CalendarStyle CssText="border-right: #cfd9e3 1px solid; border-top: #cfd9e3 1px solid; font-size: 11px; border-left: #cfd9e3 1px solid; cursor: hand; border-bottom: #cfd9e3 1px solid; font-family: verdana; background-color: #eaeaea" />
                                                <DayHoverStyle CssText="border-right: black 1px solid; border-top: black 1px solid; border-left: black 1px solid; border-bottom: black 1px solid; background-color: white" />
                                                <MonthStyle CssText="font-size: 11px; font-family: verdana;" />
                                                <TitleStyle CssText="padding-right: 3px; padding-left: 3px; font-weight: bold; padding-bottom: 3px; color: white; padding-top: 3px; border-bottom: #cfd9e3 1px solid; background-color: #006699; font-size: 11px; font-family: verdana;" />
                                                <DayHeaderStyle CssText="height: 17px" />
                                                <DayStyle CssText="border-right: #eaeaea 1px solid; border-top: #eaeaea 1px solid; border-left: #eaeaea 1px solid; border-bottom: #eaeaea 1px solid; background-color: #eaeaea" /> 
                                            </eo:DatePicker> 
                                        </td>
                                    </tr>
                                    <tr>
                                        <td><asp:Label ID="Label1" runat="server" Text="*National Provider Id:"></asp:Label></td>
                                        <td><asp:TextBox ID="txtNationalProviderId" runat="server" AutoPostBack="false" Width="222px"></asp:TextBox></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                     <tr>
                                        <td><asp:Label ID="Label2" runat="server" Text="*Ownership:"></asp:Label></td>
                                        <td><asp:TextBox ID="txtOwnerShip" runat="server" AutoPostBack="false" Width="222px"></asp:TextBox></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td><asp:Label ID="Label3" runat="server" Text="*Owner:"></asp:Label></td>
                                        <td><asp:TextBox ID="txtOwner" runat="server" AutoPostBack="false" Width="222px"></asp:TextBox></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td><asp:Label ID="Label4" runat="server" Text="*Administrator:"></asp:Label></td>
                                        <td><asp:TextBox ID="txtAdministrator" runat="server" AutoPostBack="false" Width="222px"></asp:TextBox></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                     <tr>
                                        <td><asp:Label ID="Label5" runat="server" Text="*Director of Nursing:"></asp:Label></td>
                                        <td><asp:TextBox ID="txtDirectorOfNursing" runat="server" AutoPostBack="false" Width="222px"></asp:TextBox></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                     <tr>
                                        <td><asp:Label ID="Label6" runat="server" Text="*MedicareProviderNo:"></asp:Label></td>
                                        <td><asp:TextBox ID="txtMedicareProviderNo" runat="server" AutoPostBack="false" Width="222px"></asp:TextBox></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                     <tr>
                                        <td><asp:Label ID="Label7" runat="server" Text="Website:"></asp:Label></td>
                                        <td><asp:TextBox ID="txtWebsite" runat="server" AutoPostBack="false" Width="222px"></asp:TextBox>
                                            <div class="sample">(Ex: www.newmedia.com)</div>
                                        </td>                                        
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td><asp:Label ID="Label47" runat="server" Text="Image:"></asp:Label></td>
                                        <td><asp:FileUpload ID="fudLogo" runat="server" Width="228px" /></td>
                                        <td><asp:Image ID="imgDisplayLogo" runat= "server" Width="150" Height="150" /></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td><asp:Button ID="btnCreateUpdateHomeHealth" runat="server" /></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                </table> 
                      
                        </asp:Panel>
                        </div>        
            </div> <%--end of content--%>
         </div>
      </div> <%--end of wrapper--%>
  </div>  <%--end of main--%>
        
            <div id="footer">
        <div class = "container">
            <ul id = "footer-menu">
                    <li class = "active"><a href = "default.aspx">Home</a></li>
                    <li><a href = "http://newmediaix.com/about_us.html">About</a></li>
                    <li><a href = "http://newmediaix.com/services.html">Services</a></li>
                    <li><a href = "http://newmediaix.com/portfolio.html">Portfolio</a></li>
                    <li><a href = "http://newmediaix.com/contacts.html">Contact</a></li>
            <li class = "last"><a href = "">Contact</a></li>
            </ul>
        
            <div id="info">
                NewMediaIX &copy; 2009 All Rights Reserved.
            </div>
            </div>
        </div>
        
    </form>
</body>
</html>
