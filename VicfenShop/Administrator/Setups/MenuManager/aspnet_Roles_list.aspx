<%@ Page Language="c#" AutoEventWireup="true" CodeFile="aspnet_Roles_list.aspx.cs" Inherits="Caspnet_Roles_list"%>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>dbo.aspnet_Roles</title>
    <LINK href="include/style.css" type="text/css" rel="stylesheet"/>
    <script language = JavaScript>
    
    function OnKeyDown()
    {
        e = window.event;
        if (e.keyCode == 13)
        {
            e.cancel = true;
            var theForm = document.forms['frmList'];
            if (!theForm) theForm = document.frmList;                
            theForm.btnSearch.click();              
        }
    }
    
    </script> 
  </head>    
   <body>
    <form id="frmList" runat="server" defaultbutton='btnSearch' defaultfocus='txtSearchValue'>   

      <div>
            
      <TABLE id="tblTop" cellSpacing="3" align="center" border="0" Width="100%">
        <TR>
          <TD width=30>&nbsp;</TD>
          <TD align=center nowrap><font size=+0><b>Menu Manger</b></font></TD>
          <TD vAlign="middle">
            <asp:linkbutton id="hlkBackToMenu" runat="server" OnClick="hlkBackToMenu_Click">Back to menu</asp:linkbutton>
          </TD>
          
          <TD vAlign="middle" align="center">
              &nbsp; &nbsp;&nbsp;
          </TD>
          
          <TD vAlign="middle" width="20">&nbsp;</TD>
          <TD vAlign="middle" align="center">
            <asp:hyperlink id="hlnkAdvSearch" runat="server" NavigateUrl="aspnet_Roles_Search.aspx">Advanced search</asp:hyperlink>
          </TD>
          
          <td width=30>&nbsp;</td>
        </TR>
      </TABLE>
      <TABLE id="tblMain" cellSpacing="1" cellPadding="1" align='center' width='95%' border="0">
        <TR>
          <TD>
            <TABLE id="tblSearch" cellSpacing="1" cellPadding="5" width="100%" border="0"  bgcolor=black>
              <TR>
                <TD class="shade" align="center" width="50"><nobr>
                  <asp:linkbutton id="btnAdd" runat="server" OnClick="btnAdd_Click">Add new</asp:linkbutton></nobr>
                </TD>               
                          
                <TD id="tdSearch" runat="server" class="shade" vAlign="middle" align="center" width="800">&nbsp;                
                <B>Search for:&nbsp; </B>&nbsp;&nbsp;&nbsp;
                  <asp:dropdownlist id="ddlSearchField" runat="server">
                    <asp:ListItem Value="Any Field">Any field</asp:ListItem>
            <asp:ListItem Value="RoleName">RoleName</asp:ListItem>
                  </asp:dropdownlist>&nbsp;&nbsp;
                  <asp:dropdownlist id="ddlSearchOperation" runat="server">
                    <asp:ListItem Value="Contains">Contains</asp:ListItem>
                    <asp:ListItem Value="Equals">Equals</asp:ListItem>
                    <asp:ListItem Value="Starts with ...">Starts with ...</asp:ListItem>
                    <asp:ListItem Value="More than ...">More than ...</asp:ListItem>
                    <asp:ListItem Value="Less than ...">Less than ...</asp:ListItem>
                    <asp:ListItem Value="Equal or more than ...">Equal or more than ...</asp:ListItem>
                    <asp:ListItem Value="Equal or less than ...">Equal or less than ...</asp:ListItem>
                    <asp:ListItem Value="IsNull">Empty</asp:ListItem>                   
                  </asp:dropdownlist>
                  <asp:textbox id="txtSearchValue" runat="server" Width="136px"></asp:textbox>
                  <asp:button id="btnSearch" runat="server" CssClass="button" Text="Search" OnClick="btnSearch_Click"></asp:button>
                  <asp:button id="btnShowAll" runat="server" CssClass="button" Text="Show all" OnClick="btnShowAll_Click"></asp:button>&nbsp;&nbsp;&nbsp;
                </TD>               
                
                <TD id="tdInfo" runat="server" class="shade" align="center" width="100">
                  <asp:label id="lblCount" runat="server" Height="3px">Details found:&nbsp;0</asp:label><BR>
                  <asp:label id="lblPage" runat="server">Page&nbsp;<%=

                 (dbGrid_aspnet_Roles.PageCount ==0)?0:dbGrid_aspnet_Roles.PageIndex + 1
                  %>&nbsp;of&nbsp;<%=dbGrid_aspnet_Roles.PageCount%></asp:label>
                </TD>
                <TD id="tdPageCount" runat="server" class="shade" align="left">
          <table><tr><td align="center">
            Records Per Page::<BR>
            <asp:dropdownlist id="ddlPagerCount" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPagerCount_SelectedIndexChanged">
              <asp:ListItem Value="10">10</asp:ListItem>
              <asp:ListItem Value="20">20</asp:ListItem>
              <asp:ListItem Value="30">30</asp:ListItem>
              <asp:ListItem Value="50">50</asp:ListItem>
              <asp:ListItem Value="100">100</asp:ListItem>
              <asp:ListItem Value="500">500</asp:ListItem>
            </asp:dropdownlist>
          </td></tr></table>  
                </TD>
              </TR>
            </TABLE>
            <asp:label id="lblMessage" runat="server" ForeColor="Red"></asp:label>
          </td>
        </tr>
        <tr>
          <td>

            <asp:sqldatasource id="aspnet_RolesSqlDataSource"
                SelectCommand="select [ApplicationId],   [RoleId],   [RoleName],   [LoweredRoleName],   [Description]   From [dbo].[aspnet_Roles] "
                DeleteCommand="delete from [dbo].[aspnet_Roles] where [RoleId]=@RoleId"
                ConnectionString="<%$ ConnectionStrings:Project1ConnectionString%>"
                ProviderName="<%$ ConnectionStrings:Project1ConnectionString.providerName%>"
                OnSelected="aspnet_RolesSqlDataSource_Selected" 
         runat="server">
            </asp:sqldatasource>
            <asp:GridView id="dbGrid_aspnet_Roles" runat="server" CssClass="Grid" Width="100%"
                  datasourceid="aspnet_RolesSqlDataSource" DataKeyNames="RoleId" ShowFooter="True"
                  OnPageIndexChanged="dbGrid_aspnet_Roles_PageIndexChanged" OnRowCommand="dbGrid_aspnet_Roles_RowCommand" OnSorted="dbGrid_aspnet_Roles_Sorted"

                  OnRowDataBound="dbGrid_aspnet_Roles_RowDataBound" 

                  AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" BorderStyle="Dotted" EmptyDataText="No records found">
        <SelectedRowStyle CssClass="GridSelected" />
        <AlternatingRowStyle CssClass="GridItemOdd" />
        <EmptyDataRowStyle BorderStyle="None" BorderWidth="0px" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
        <RowStyle CssClass="shade" />
        <HeaderStyle CssClass="blackshade" VerticalAlign="Middle" HorizontalAlign="Left" Wrap="False"></HeaderStyle>
        <FooterStyle CssClass="blackshade"></FooterStyle>
              <Columns>

              <asp:ButtonField Text="" CommandName="" HeaderImageUrl="images\icon_edit.gif"></asp:ButtonField>

                <asp:ButtonField Text="Role Menus" CommandName="Details_MENU_IN_ROLE"></asp:ButtonField>

                <asp:BoundField DataField="RoleName" ReadOnly="True" HeaderText="RoleName" SortExpression="RoleName">
                  
                </asp:BoundField>

              </Columns>
            </asp:GridView>
          </TD>
        </TR>
      </TABLE>      
      
    </div>
    
    </form>
  </body>
</HTML>

