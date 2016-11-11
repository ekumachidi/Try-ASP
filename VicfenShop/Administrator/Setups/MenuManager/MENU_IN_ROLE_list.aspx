<%@ Page Language="c#" AutoEventWireup="true" CodeFile="MENU_IN_ROLE_list.aspx.cs" Inherits="CMENU_IN_ROLE_list"%>

<%@ Register Assembly="Infragistics2.WebUI.WebDataInput.v7.1, Version=7.1.20071.40, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.WebDataInput" TagPrefix="igtxt" %>

<html>
  <head id="Head1" runat="server">
    <title>dbo.MENU_IN_ROLE</title>
    <LINK href="include/style.css" type="text/css" rel="stylesheet"/>
    <script language = JavaScript>
    
    var bSelected=false;
    function ChSel()
    {
        var theForm = document.forms['frmList'];
        if (!theForm) theForm = document.frmList;
        bSelected = !bSelected; 
        var i;
        for (i=0;i<theForm.chDelete.length;++i) theForm.chDelete[i].checked=bSelected;
    } 
    
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
      <asp:linkbutton id="lnkBackToMainList" runat="server" OnClick="lnkBackToMainList_Click">Back to Master list</asp:linkbutton>       
      
      <asp:sqldatasource id="maspnet_RolesSqlDataSource"
          SelectCommand="select [ApplicationId],   [RoleId],   [RoleName],   [LoweredRoleName],   [Description]   From [dbo].[aspnet_Roles] "
          ConnectionString="<%$ ConnectionStrings:Project1ConnectionString%>"          
          ProviderName="<%$ ConnectionStrings:Project1ConnectionString.providerName%>"
          runat="server">
       </asp:sqldatasource>
          &nbsp;
       <asp:GridView id="dbGrid_faspnet_Roles" runat="server" CssClass="Grid" AutoGenerateColumns="False" BorderStyle="Dotted" Width="100%">
              <RowStyle CssClass="shade"/>
              <HeaderStyle CssClass="blackshade" VerticalAlign="Middle"  HorizontalAlign="left" Wrap="False" Font-Bold="true"></HeaderStyle>
              <Columns>
                          
                <asp:BoundField DataField="RoleName" ReadOnly="True" HeaderText="RoleName"
                          
                >
                    
                </asp:BoundField>
                              
              </Columns>
            </asp:GridView><p/>
      
      <TABLE id="tblTop" cellSpacing="3" align="center" border="0" Width="100%">
        <TR>
          <TD width=30>&nbsp;</TD>
          <TD align=center nowrap><font size=+0><b>Role Menus:</b></font></TD>
          <TD vAlign="middle">
            <asp:linkbutton id="hlkBackToMenu" runat="server" OnClick="hlkBackToMenu_Click">Back to menu</asp:linkbutton>
          </TD>
          
          <TD vAlign="middle" align="center">
              &nbsp; &nbsp;&nbsp;
          </TD>
          
          <TD vAlign="middle" width="20">&nbsp;</TD>
          <TD vAlign="middle" align="center">
            <asp:hyperlink id="hlnkAdvSearch" runat="server" NavigateUrl="MENU_IN_ROLE_Search.aspx">Advanced search</asp:hyperlink>
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
                  <asp:linkbutton id="btnAdd" runat="server" OnClick="btnAdd_Click">Add New Menu(s) To This Role</asp:linkbutton></nobr>
                </TD>               
                          
                <TD id="tdSearch" runat="server" class="shade" vAlign="middle" align="center" width="800">&nbsp;                
                <B>Search for:&nbsp; </B>&nbsp;&nbsp;&nbsp;
                  <asp:dropdownlist id="ddlSearchField" runat="server">
                    <asp:ListItem Value="Any Field">Any field</asp:ListItem>
            <asp:ListItem Value="MenuId">Menu</asp:ListItem>
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

                 (dbGrid_MENU_IN_ROLE.PageCount ==0)?0:dbGrid_MENU_IN_ROLE.PageIndex + 1
                  %>&nbsp;of&nbsp;<%=dbGrid_MENU_IN_ROLE.PageCount%></asp:label>
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

      <p>
      <a href=# onClick = "ChSel()">Select/Unselect all</a>
      <asp:linkbutton id="btnDelete" runat="server" OnClick="btnDelete_Click">Delete selected</asp:linkbutton>
      </p>

            <asp:sqldatasource id="MENU_IN_ROLESqlDataSource"
                SelectCommand="select [MenuId],   [RoleId]   From [dbo].[MENU_IN_ROLE] "
                DeleteCommand="delete from [dbo].[MENU_IN_ROLE] where [MenuId]=@MenuId and [RoleId]=@RoleId"
                ConnectionString="<%$ ConnectionStrings:Project1ConnectionString%>"
                ProviderName="<%$ ConnectionStrings:Project1ConnectionString.providerName%>"
                OnSelected="MENU_IN_ROLESqlDataSource_Selected" 
        OnDeleting="MENU_IN_ROLESqlDataSource_Deleting"   runat="server">
            </asp:sqldatasource>
            <asp:GridView id="dbGrid_MENU_IN_ROLE" runat="server" CssClass="Grid" Width="100%"
                  datasourceid="MENU_IN_ROLESqlDataSource" DataKeyNames="MenuId,RoleId"
                  OnPageIndexChanged="dbGrid_MENU_IN_ROLE_PageIndexChanged" OnRowCommand="dbGrid_MENU_IN_ROLE_RowCommand" OnSorted="dbGrid_MENU_IN_ROLE_Sorted"

                  OnRowCreated="dbGrid_MENU_IN_ROLE_RowCreated"

                  OnRowDataBound="dbGrid_MENU_IN_ROLE_RowDataBound" 

                  OnRowDeleted="dbGrid_MENU_IN_ROLE_RowDeleted"                  

                  AutoGenerateColumns="False" AllowPaging="True" AllowSorting="True" BorderStyle="Dotted" EmptyDataText="No records found">
        <SelectedRowStyle CssClass="GridSelected" />
        <AlternatingRowStyle CssClass="GridItemOdd" />
        <EmptyDataRowStyle BorderStyle="None" BorderWidth="0px" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle" />
        <RowStyle CssClass="shade" />
        <HeaderStyle CssClass="blackshade" VerticalAlign="Middle"  HorizontalAlign="Center" Wrap="False"></HeaderStyle>
        
              <Columns>

                <asp:TemplateField HeaderImageUrl="images\icon_delete.gif">
              <ItemStyle HorizontalAlign=Center />
                  <ItemTemplate>          
          <input type="checkbox" name="chDelete" value='<%#DataBinder.Eval(Container,"RowIndex")%>'/>
                  </ItemTemplate>
                </asp:TemplateField>        

                <asp:BoundField DataField="MenuId" ReadOnly="True" HeaderText="Menu" SortExpression="MenuId">
                  
                </asp:BoundField>

              </Columns>
            </asp:GridView>
          </TD>
        </TR>
      </TABLE>      
      
    </div>
    
    </form>
  </body>
</html>

