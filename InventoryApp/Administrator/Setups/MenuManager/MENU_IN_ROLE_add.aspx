<%@ Page Language="c#" AutoEventWireup="true" CodeFile="MENU_IN_ROLE_Add.aspx.cs" Inherits="CMENU_IN_ROLE_Add"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>dbo.MENU_IN_ROLE - Add new</title>
    <script language="JavaScript" src="include/calendar.js"></script>
    <link href="include/style.css" type="text/css" rel="stylesheet"/>
    <style>
      .visible { VISIBILITY: visible }
      .hide { VISIBILITY: hidden }        
    </style>    
</head>

<body>
    <form id="editform" runat="server">
        <asp:label id="lblInsert" runat="server" Font-Bold="True">Table:&nbsp;dbo.MENU_IN_ROLE,&nbsp;Add new record</asp:label>
        <hr width="100%" SIZE="1">
        <asp:hyperlink id="lnkBackToList" runat="server" NavigateUrl="MENU_IN_ROLE_list.aspx">Back to list</asp:hyperlink>
        <p><asp:label id="lblMessage" runat="server" CssClass="message"></asp:label><asp:validationsummary id="vsUpdatePage" runat="server" ShowMessageBox="True" ShowSummary="False" Height="32px"></asp:validationsummary>    
        <asp:SqlDataSource id="MENU_IN_ROLESqlDataSource" runat="server" 

        InsertCommand="insert into [dbo].[MENU_IN_ROLE] ([MenuId], [RoleId]) values (@MenuId, @RoleId) "

    OnInserted="MENU_IN_ROLESqlDataSource_Inserted"
    OnInserting="MENU_IN_ROLESqlDataSource_Inserting"
        ConnectionString="<%$ ConnectionStrings:Project1ConnectionString %>"
        ProviderName="<%$ ConnectionStrings:Project1ConnectionString.providerName %>"
    >
        <SelectParameters>
            <asp:QueryStringParameter  QueryStringField="MenuId" Name="MenuId" Type="Int32" DefaultValue="-1" />
            <asp:QueryStringParameter  QueryStringField="RoleId" Name="RoleId" Type="String" DefaultValue="-1" />

        </SelectParameters>       
        <InsertParameters>
            <asp:Parameter Name="MenuId" Type="Int32"/>
            <asp:Parameter Name="RoleId" Type="String"/>
            
        </InsertParameters>
    </asp:SqlDataSource>
    <asp:DetailsView id="MENU_IN_ROLEDetailsView" runat="server" AutoGenerateRows="False" 
      DataKeyNames="MenuId,RoleId"
            DataSourceID="MENU_IN_ROLESqlDataSource"
            OnDataBound="MENU_IN_ROLEDetailsView_DataBound" OnItemInserting="MENU_IN_ROLEDetailsView_ItemInserting"
            AutoGenerateInsertButton="True" 
            DefaultMode="Insert" 
            GridLines="None" 
            RowStyle-CssClass=""
    >          
        <FieldHeaderStyle CssClass="shade" />
        <Fields>

            <asp:TemplateField HeaderText="Menu">
                <InsertItemTemplate>
                    <asp:DropDownList id="fldMenuId" 
                  DataTextField="MenuTitle" DataValueField="MenuId" SelectedValue='<%# Bind("MenuId") %>'
                  DataSource=<%# func.GetSqlDataSource("SELECT [MenuId], [MenuTitle] FROM [dbo].[MENU_SUB]  ") %>
                  AppendDataBoundItems="True" runat="server">
            <asp:ListItem Value=""></asp:ListItem>
          </asp:DropDownList>

                    <img alt="Key field" src="images/icon_key.gif">

                </InsertItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Role">
                <InsertItemTemplate>
                    <asp:DropDownList id="fldRoleId" 
                  DataTextField="RoleName" DataValueField="RoleId" SelectedValue='<%# Bind("RoleId") %>'
                  DataSource=<%# func.GetSqlDataSource("SELECT [RoleId], [RoleName] FROM [dbo].[aspnet_Roles]  ") %>
                  AppendDataBoundItems="True" runat="server">
            <asp:ListItem Value=""></asp:ListItem>
          </asp:DropDownList>

                    <img alt="Key field" src="images/icon_key.gif">

                </InsertItemTemplate>
            </asp:TemplateField>

        </Fields>
    </asp:DetailsView>        
    </form>
</body>
</html>