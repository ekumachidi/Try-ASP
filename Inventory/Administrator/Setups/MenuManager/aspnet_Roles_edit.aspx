<%@ Page Language="c#" AutoEventWireup="true" CodeFile="aspnet_Roles_edit.aspx.cs" Inherits="Caspnet_Roles_Edit"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>dbo.aspnet_Roles - Edit</title>
    <script language="JavaScript" src="include/calendar.js"></script>
    <link href="include/style.css" type="text/css" rel="stylesheet"/>
    <style>
      .visible { VISIBILITY: visible }
      .hide { VISIBILITY: hidden }        
    </style>    
</head>

<body>
    <form id="editform" runat="server">
        <asp:label id="lblUpdate" runat="server" Font-Bold="True">Table:&nbsp;dbo.aspnet_Roles,&nbsp;Edit record</asp:label>
        <hr width="100%" SIZE="1">
        <asp:hyperlink id="lnkBackToList" runat="server" NavigateUrl="aspnet_Roles_list.aspx">Back to list</asp:hyperlink>
        <p><asp:label id="lblMessage" runat="server" CssClass="message"></asp:label><asp:validationsummary id="vsUpdatePage" runat="server" ShowMessageBox="True" ShowSummary="False" Height="32px"></asp:validationsummary>
        <asp:SqlDataSource id="aspnet_RolesSqlDataSource" runat="server" 
            SelectCommand="select [RoleName],  [RoleId] from [dbo].[aspnet_Roles] where [RoleId]=@RoleId" 
            UpdateCommand="update [dbo].[aspnet_Roles] set [RoleName]=@RoleName where  cast([RoleId] as nvarchar(100))=@RoleId"
            OnSelected="aspnet_RolesSqlDataSource_Selected" 
            OnUpdated="aspnet_RolesSqlDataSource_Updated"
            OnUpdating="aspnet_RolesSqlDataSource_Updating"
            ConnectionString="<%$ ConnectionStrings:MIC1ConnectionString%>"
            ProviderName="<%$ ConnectionStrings:MIC1ConnectionString.providerName%>"
        >
        <SelectParameters>
            <asp:QueryStringParameter  QueryStringField="RoleId" Name="RoleId" Type="String" DefaultValue="-1" />

        </SelectParameters>       
        <UpdateParameters>
            <asp:Parameter Name="RoleName" Type="String"/>

            <asp:QueryStringParameter  QueryStringField="RoleId" Name="RoleId" Type="String" DefaultValue="-1" />

        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:DetailsView ID="aspnet_RolesDetailsView" runat="server" AutoGenerateRows="False" 
      DataKeyNames="RoleId"
            DataSourceID="aspnet_RolesSqlDataSource"
            OnDataBound="aspnet_RolesDetailsView_DataBound" OnItemUpdating="aspnet_RolesDetailsView_ItemUpdating"
            AutoGenerateEditButton="True" 
            DefaultMode="Edit" 
            GridLines="None" 
            RowStyle-CssClass=""
    >          
        <FieldHeaderStyle CssClass="shade" />
        <Fields>

            <asp:TemplateField HeaderText="RoleName">
                <EditItemTemplate>
                    <asp:TextBox id="fldRoleName"  size="20"  maxlength="25"  Text='<%# Bind("RoleName") %>' runat="server"/>&nbsp;

                    <img alt="Required" src="images/icon_required.gif">
                    <asp:RequiredFieldValidator runat="server" id="rvffldRoleName" ControlToValidate="fldRoleName" Display="None" ErrorMessage="Field RoleName can&#146;t be blank" />

                </EditItemTemplate>
            </asp:TemplateField>

        </Fields>
    </asp:DetailsView>        
    </form>
</body>
</html>