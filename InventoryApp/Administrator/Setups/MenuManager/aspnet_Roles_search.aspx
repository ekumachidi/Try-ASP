<%@ Page Language="c#" AutoEventWireup="true" CodeFile="aspnet_Roles_search.aspx.cs" Inherits="Caspnet_Roles_search"%>
<HTML>
  <HEAD>
    <title>dbo.aspnet_Roles - Advanced search page</title>
    <script language="JavaScript" src="include/calendar.js"></script>
    <LINK href="include/style.css" type="text/css" rel="stylesheet"/>   
      <STYLE>
      .vis1 { VISIBILITY: visible }
      .vis2 { VISIBILITY: hidden }
      </STYLE>
      <script>  
        function ShowHideControls()
        {                   
          for (i=0;i<document.forms.frmSearch.elements.length; ++i)
          {
          sName = document.forms.frmSearch.elements[i].name;
          if (sName.indexOf("ddlOperation_") == 0)
            {
            
            s = "fld2" + sName.substring(13, sName.length)
            if (document.getElementById(s) == null) s = "fld2M" + sName.substring(13, sName.length)
            if (document.getElementById(s) == null) continue;
            document.getElementById(s).className =  
            document.forms.frmSearch.elements[i].options.length > 1 &&
                (document.forms.frmSearch.elements[i].options.length - 2 == 
                  document.forms.frmSearch.elements[i].selectedIndex) ? 'vis1' : 'vis2'; 
            if (document.getElementById(s+"_Cal") != null) 
        document.getElementById(s+"_Cal").className =document.getElementById(s).className;          
            }
          }
        return false;
        }

        function OnKeyDown()
        {
          e = window.event;
          if (e.keyCode == 13)
          {
            e.cancel = true;
            document.forms[0].submit();
          } 
        }
        function resetValues()
        {
        e = document.forms[0].elements; 
        for (i=0;i<e.length;i++) 
        { 
        if (e[i].name!='SearchOption' && e[i].className!='button' && e[i].type!='hidden')        
          e[i].value = ''; 
        } 
        ShowHideControls();

        }
      </script>
  </HEAD>
  <body bgcolor="white" onLoad="javascript:document.forms[0].onkeydown = OnKeyDown; return ShowHideControls();">
    <form id="frmSearch" method="post" runat="server">
      <table  cellSpacing="-1" cellPadding="1" width="750" align="center" style="BORDER: #cccccc 1px solid;">
        <tr vAlign="middle">
          <td vAlign="middle" align="center" colSpan="3">
        <table width=100% CELLSPACING=0 CELLPADDING=3><tr>
        <td width=200 class=tableheader>dbo.aspnet_Roles</td>
        <td align=center class=tableheader>Advanced search page</td>
        <td width=200 class=tableheader>&nbsp;</td>
      </tr></table>           
            <asp:label id="lblMessage" runat="server" CssClass="message"></asp:label>
            <table  cellSpacing="1" cellPadding="1" width="100%" border="0" >
          <tr class="shade">
                <td colspan="5" align=center valign=middle class=header2>           
          <table><tr><td width=200>&nbsp;</td><td align=center width=300>
            <b class="xtop"><b class="xb1"></b><b class="xb2"></b><b class="xb3"></b><b class="xb4"></b></b>
            <div class="xboxcontent">
            <span class=fieldname>Search for:</span>
              <asp:RadioButton ID="rbAnd" runat="server" Checked="True" GroupName="s" Text="All conditions" />
                            <asp:RadioButton ID="rbOr" runat="server" GroupName="s" Text="Any condition" />           
            </div>
            <b class="xbottom"><b class="xb4"></b><b class="xb3"></b><b class="xb2"></b><b class="xb1"></b></b>
          </td><td width=200>&nbsp;</td></tr></table>
                </td>
                </tr>
        <tr class="shade" >
          <td align="left" width="33%" class=tableheader>&nbsp;</td>
          <td align="center" width="30" class=tableheader>Not</td>
          <td align="left" class=tableheader>&nbsp;</td>
          <td align="center" width="33%" class=tableheader>&nbsp;</td>
          <td align="center" width="33%" class=tableheader>&nbsp;</td>
        </tr>

                <tr class="shade">
                <td align="left" width="33%" class=fieldname>
                  RoleName
                </td>
                <td align="center">
                  <asp:CheckBox ID="chNot_RoleName" runat="server" />                  
                </td>       
                <td align="center" width="1">
                  <asp:dropdownlist id="ddlOperation_RoleName" runat="server" onChange="return ShowHideControls();">
                    <asp:ListItem Value="Contains">Contains</asp:ListItem>
                    <asp:ListItem Value="Equals">Equals</asp:ListItem>
                    <asp:ListItem Value="Starts with ...">Starts with ...</asp:ListItem>
                    <asp:ListItem Value="More than ...">More than ...</asp:ListItem>
                    <asp:ListItem Value="Less than ...">Less than ...</asp:ListItem>
                    <asp:ListItem Value="Equal or more than ...">Equal or more than ...</asp:ListItem>
                    <asp:ListItem Value="Equal or less than ...">Equal or less than ...</asp:ListItem>
                    <asp:ListItem Value="Between">Between</asp:ListItem>
                    <asp:ListItem Value="IsNull">Empty</asp:ListItem>                   
                  </asp:dropdownlist>
                </td>
                <td align="center" width="33%">             
                  <asp:TextBox id="fldRoleName" runat="server" Width="100%"></asp:TextBox>
                </td>
                <td align="center" width="33%">
                  <asp:TextBox id="fld2RoleName" runat="server" Width="100%" CssClass='vis2'></asp:TextBox>
        </td>
        </tr>         
                
            </TABLE>
          </td>
        </tr>
        <tr class="blackshade">
          <td align="center" colSpan="3">
            <asp:button id="btnSearch" runat="server" CssClass="button" Text="Search" OnClick="btnSearch_Click"></asp:button>&nbsp;
            <input class="button" type=button value="Reset"  onClick="resetValues();">&nbsp;
            <asp:button id="hlBack" runat="server" CssClass="button" Text="Back to list" OnClick="hlBack_Click"></asp:button>
          </td>
        </tr>
      </table>
    </form>
  </body>
</HTML>
