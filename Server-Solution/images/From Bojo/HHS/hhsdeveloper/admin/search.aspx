<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>NewMediaIX HomeHealth Search</title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link rel="stylesheet" href="StyleSheetAdmin.css" type="text/css" />
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
                        <li><asp:HyperLink ID="lnkSigOutSearch" runat="server" NavigateUrl="~/admin/search.aspx?signouts=yes">Sign Out</asp:HyperLink></li>
                    </ul>
                </div>
           </div><%--end of header--%>
           
        
        <div id="main">    
        <center>
        <asp:Panel ID="pnlHomeHealSearch" runat="server" OnInit="Page_Init">
                <div id="searchwrapper"> 
                    <div id="searchbox">
                        <asp:TextBox ID="txtSearch" runat="server" AutoPostBack="true" Width="520" BackColor="transparent" 
                        BorderStyle="Solid" BorderColor="transparent" Font-Size="16" ForeColor="#ced1d1" CssClass="searchbox"></asp:TextBox>
                    
                        <asp:HyperLink ID="lnkGo" runat="server" Text="" ImageUrl="../images/search_blank_bg.gif"  
                        NavigateUrl="~/admin/search.aspx?panelView=search&queryString=Go" CssClass="searchbox_submit" ToolTip="Search"> </asp:HyperLink>
                   
                        <asp:HyperLink ID="lnkAll" runat="server" Text="Search All" ImageUrl="../images/searchall_blank_bg.gif" 
                        NavigateUrl="~/admin/search.aspx?panelView=search&queryString=%%" CssClass="searchbox_all" ToolTip="Search All"> </asp:HyperLink>           
                   
                        <asp:HyperLink ID="lnkCreateHomeHealth" runat="server" Text="" ImageUrl="../images/searchall_blank_bg.gif"
                        NavigateUrl="~/admin/createupdate.aspx?panelView=create" CssClass="searchbox_create" ToolTip="Create Information"></asp:HyperLink>
                    </div>
                </div> <%--end of search wrapper--%>
              
               <asp:Label ID="lblSearchText" runat="server" Text="Search your Home Health by:" CssClass="searchbox_info" Width="400"></asp:Label> 
          
             <asp:CheckBox ID="chkHomeHealthName" runat="server" Text="Home Health Name" />
             <asp:CheckBox ID="chkAddress" runat="server" Text="Office Address" />
             <asp:CheckBox ID="chkPhone" runat="server" Text="Phone No." />
             <asp:CheckBox ID="chkFaxNo" runat="server" Text="Fax No." />
             <asp:CheckBox ID="chkNationalProviderId" runat="server" Text="National Provider ID" />
             <asp:CheckBox ID="chkOwnership" runat="server" Text="Ownership" />
             <asp:CheckBox ID="chkOwner" runat="server" Text="Owner" />
             <asp:CheckBox ID="chkAdministrator" runat="server" Text="Administrator" />
             <asp:CheckBox ID="chkDirectorOfNursing" runat="server" Text="Director of Nursing" />
             <asp:CheckBox ID="chkMedicareProviderNo" runat="server" Text="Medicare Provider No." />            

                <div id="content">
                    <asp:GridView ID="dgvHomeHealth" runat="server" CssClass="listitem_main" AutoGenerateColumns="false" AllowPaging="true" PageSize="5" BorderWidth="0" BorderColor="white" 
                        PagerSettings-LastPageText="Last" PagerSettings-NextPageText="Next" PagerSettings-PreviousPageText="Previous"
                        OnRowDataBound="dgvHomeHealthRowDataBound" OnPageIndexChanging="dgvHomeHealthPageIndexChanging" >                
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                <div class="listitem">
                                    <div class="thumbnail">
                                        <asp:Image ID="imgLogoHomeHealth" runat="server" ImageUrl='<%# Eval("LogoPath") %>' Width="160" Height="120"/>
                                    </div>
                                    <h2>
                                        <asp:HyperLink ID="HyperLink1" runat="server">
                                            <%# Eval("HomeHealthName").ToString()%>
                                        </asp:HyperLink>
                                    </h2>
                                    
                                    <p><span class="label">Address&nbsp:</span>  <%# Eval("OfficeAddress")%>                       
                                    <br /><span class="label">Pnone No.:</span>  <%# Eval("PhoneNos")%> 
                                    <br /><span class="label">Fax No.:</span>  <%# Eval("FaxNos")%>
                                    <br /><span class="label">Date Certified:</span>  <%# DateTime.Compare(DateTime.MinValue, (DateTime)Eval("DateCertified")) != 0 ? DateTime.Parse(Eval("DateCertified").ToString()).ToLongDateString() : String.Empty %> 
                                    <br /><span class="label">National Provider Id:</span>  <%# Eval("NationalProviderId")%>
                                    <br /><span class="label">Ownership:</span>  <%# Eval("Ownership")%>
                                    <br /><span class="label">Owner:</span>  <%# Eval("Owner")%>
                                    <br /><span class="label">Administrator:</span>  <%# Eval("Administrator")%>
                                    <br /><span class="label">Director of Nursing:</span>  <%# Eval("DirectorOfNursing")%> 
                                    <br /><span class="label">Medicare Provider No.:</span>  <%# Eval("MedicareProviderNo")%>
                                   <br /><span class="label">Website:</span> <asp:HyperLink ID="lnkWebsite" runat="server" NavigateUrl='<%# "http://" + Eval("WebSite")%> '> 
                                        <%# Eval("WebSite")%> </asp:HyperLink></p>    
                                        
                                    <asp:HyperLink ID="lnkUpdateHomeHealth" runat="server" Text="Update Home Health Information" 
                                        NavigateUrl='<%# "~/admin/createupdate.aspx?panelview=update&homehealthid=" + (Int32)Eval("HomeHealthId") %>'> </asp:HyperLink>
                                        
                                    <div class="dashedline">
                                    </div>
                           
                                    <div class="clearlist">
                                    </div>
                                </div> <%--end of listitem--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings Mode="NumericFirstLast" Position="Bottom" PageButtonCount="10"/>
                    </asp:GridView>
                </div><%--end of content  --%>
            </asp:Panel>
            </center>
        </div> <%--end of main--%>
        
        
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
