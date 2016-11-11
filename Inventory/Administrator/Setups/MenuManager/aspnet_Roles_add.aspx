<%@ Page Language="c#" AutoEventWireup="true" CodeFile="aspnet_Roles_Add.aspx.cs" Inherits="Caspnet_Roles_Add"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>dbo.aspnet_Roles - Add new</title>
    <script language="JavaScript" src="include/calendar.js"></script>
    <link href="include/style.css" type="text/css" rel="stylesheet"/>
    <style>
      .visible { VISIBILITY: visible }
      .hide { VISIBILITY: hidden }        
    </style>    
</head>

<body>
    <form id="editform" runat="server">
        <asp:label id="lblInsert" runat="server" Font-Bold="True">Table:&nbsp;dbo.aspnet_Roles,&nbsp;Add new record</asp:label>
        <hr width="100%" SIZE="1">
        <asp:hyperlink id="lnkBackToList" runat="server" NavigateUrl="aspnet_Roles_list.aspx">Back to list</asp:hyperlink>
        <p><asp:label id="lblMessage" runat="server" CssClass="message"></asp:label><asp:validationsummary id="vsUpdatePage" runat="server" ShowMessageBox="True" ShowSummary="False" Height="32px"></asp:validationsummary>    
        <asp:SqlDataSource id="aspnet_RolesSqlDataSource" runat="server" 

        InsertCommand="insert into [dbo].[aspnet_Roles] ([RoleName],[LoweredRoleName]) values (@RoleName,Lower(@RoleName)) "

    OnInserted="aspnet_RolesSqlDataSource_Inserted"
    OnInserting="aspnet_RolesSqlDataSource_Inserting"
        ConnectionString="<%$ ConnectionStrings:MIC1ConnectionString %>"
        ProviderName="<%$ ConnectionStrings:MIC1ConnectionString.providerName %>"
    >
        <SelectParameters>
            <asp:QueryStringParameter  QueryStringField="RoleId" Name="RoleId" Type="String" DefaultValue="-1" />

        </SelectParameters>       
        <InsertParameters>
            <asp:Parameter Name="RoleName" Type="String"/>
            
        </InsertParameters>
    </asp:SqlDataSource>
    <asp:DetailsView id="aspnet_RolesDetailsView" runat="server" AutoGenerateRows="False" 
      DataKeyNames="RoleId"
            DataSourceID="aspnet_RolesSqlDataSource"
            OnDataBound="aspnet_RolesDetailsView_DataBound" OnItemInserting="aspnet_RolesDetailsView_ItemInserting"
            AutoGenerateInsertButton="True" 
            DefaultMode="Insert" 
            GridLines="None" 
            RowStyle-CssClass="" 
            OnPageIndexChanging="aspnet_RolesDetailsView_PageIndexChanging" oniteminserted="aspnet_RolesDetailsView_ItemInserted"
    >          
        <FieldHeaderStyle CssClass="shade" />
        <Fields>

            <asp:TemplateField HeaderText="RoleName">
                <InsertItemTemplate>
                    <asp:TextBox id="fldRoleName"  size="20"  maxlength="25" Text='<%# Bind("RoleName") %>' runat="server" ></asp:textbox>&nbsp;

                    <img alt="Required" src="images/icon_required.gif">
                    <asp:RequiredFieldValidator runat="server" id="rvffldRoleName" ControlToValidate="fldRoleName" Display="None" ErrorMessage="Field RoleName can&#146;t be blank" />

                </InsertItemTemplate>
            </asp:TemplateField>

        </Fields>
    </asp:DetailsView>        
            <p>
                &nbsp;</p>
            <p>
            </p>
            
    </form>
</body>
</html>