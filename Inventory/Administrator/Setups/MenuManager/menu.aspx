<%@ Page Language="c#" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Menu" %>
<HTML>
  <HEAD>
    <link REL="stylesheet" href="include/style.css" type="text/css">
  </HEAD>
  <body>
    <form id="Form1" method="post" runat="server">
       
      <asp:hyperlink runat="server" id="hlnkPrint_MENU_IN_ROLE" NavigateUrl="MENU_IN_ROLE_list.aspx">dbo.MENU_IN_ROLE</asp:hyperlink><br>
       
      <asp:hyperlink runat="server" id="hlnkPrint_aspnet_Roles" NavigateUrl="aspnet_Roles_list.aspx">dbo.aspnet_Roles</asp:hyperlink><br>
      
    </form>
  </body>
</HTML>
