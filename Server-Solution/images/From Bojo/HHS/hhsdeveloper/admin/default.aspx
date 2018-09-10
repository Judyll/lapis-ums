<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>HomeHealth Search LogIn</title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <link rel="stylesheet" href="StyleSheetAdmin.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="loginheader">
            <div class="container">
                <a href= "#" id= "logo"></a>
                <ul id = "main-menu">
                   <li class = "active"><a href = "default.aspx">Home</a></li>
                    <li><a href = "http://newmediaix.com/about_us.html">About</a></li>
                    <li><a href = "http://newmediaix.com/services.html">Services</a></li>
                    <li><a href = "http://newmediaix.com/portfolio.html">Portfolio</a></li>
                    <li><a href = "http://newmediaix.com/contacts.html">Contact</a></li>
                </ul>
            </div>
       </div><%--end of header--%>
       
       <div id="main">
        <div id="login">
         <table>
                <tr>
                    <td><asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label></td>
                    <td><asp:TextBox ID="txtUsername" runat="server" Text="" Width="150"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="lblPassword" runat="server" Text="Password: "></asp:Label></td>
                    <td><asp:TextBox ID="txtPassword" runat="server" Text="" Width="150" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
               
                    <td colspan="2" style="height: 26px"><asp:Button ID="btnSubmit" runat="server" Text="Submit" Width="70" OnClick="btnSubmitClick"/>
                    <asp:Button ID="btnReset" runat="server" Text="Reset" Width="70" OnClick="btnResetClick" /></td>
                </tr>
             </table>
             </div>
    
        </div>
            
    </form>
</body>
</html>
