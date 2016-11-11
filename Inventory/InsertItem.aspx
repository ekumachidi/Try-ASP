<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="InsertItem.aspx.cs" Inherits="InsertItem" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 169px;
        }
        .style2
        {
            width: 178px;
        }
        .style3
        {
            width: 183px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <div style=" width: 544px; font-family: candara; font-size: small;">
        <table style="width: 100%;">
            <tr>
                <td style="border-width: thick; border-color: #000000; font-family: Candara; font-size: large; font-weight: bold; text-align: center; border-bottom-style: solid;">
                    INSERT ITEM</td>
            </tr>
        </table>

    </div>

    <ol class="round">
                <table>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1" style="font-weight: bold">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1" style="font-weight: bold">
                    CATEGORY</td>
                <td>
                    <asp:DropDownList ID="ddlCategory" runat="server" Width="200px" DataSourceID="CategoryDataSource" DataTextField="Name" DataValueField="ID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="CategoryDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:InventoryConnectionString %>" SelectCommand="SELECT * FROM [Category]"></asp:SqlDataSource>
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1" style="font-weight: bold">
                    ITEM NAME:</td>
                <td>
                    <asp:TextBox ID="txtItemName" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td class="style3">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtItemName" InitialValue="Type Item Name" ErrorMessage="Please enter Item name" 
                        ForeColor="Red" ValidationGroup="a">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">
                    </td>
                <td class="auto-style1" style="font-weight: bold">
                    <asp:Label ID="Label1" runat="server" Text="MANUFACTURER:"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="ddlManufacturer" runat="server" Width="200px" DataSourceID="ManufacturerDataSource" DataTextField="NAME" DataValueField="ID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="ManufacturerDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:InventoryConnectionString %>" SelectCommand="SELECT * FROM [Manufacturer]"></asp:SqlDataSource>
                </td>
                <td class="style3">
                    </td>
                <td class="auto-style1">
                    </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1" style="font-weight: bold">
                    SERIAL NO.</td>
                <td>
                    <asp:TextBox ID="txtSerialNo" runat="server" Width="188px"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1" style="font-weight: bold">
                    CONDITION</td>
                <td>
                    <asp:DropDownList ID="ddlCondition" runat="server" Width="200px" DataSourceID="ConditionDataSource" DataTextField="Name" DataValueField="ID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="ConditionDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:InventoryConnectionString %>" SelectCommand="SELECT * FROM [Condition]"></asp:SqlDataSource>
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1" style="font-weight: bold">
                    DATE</td>
                <td>
                    <telerik:RadDatePicker ID="RadDatePicker" Runat="server" Culture="en-GB" 
                        FocusedDate="2010-01-01" MaxDate="2014-12-31" MinDate="2010-01-01">
                    </telerik:RadDatePicker>
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1" style="font-weight: bold">
                    LOCATION</td>
                <td>
                    <asp:DropDownList ID="ddlLocation" runat="server" Width="200px" DataSourceID="LocationDataSource" DataTextField="Name" DataValueField="ID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="LocationDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:InventoryConnectionString %>" SelectCommand="SELECT * FROM [Location]"></asp:SqlDataSource>
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1" style="font-weight: bold">
                    COMMENT</td>
                <td>
                    <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine" Width="200px"></asp:TextBox>
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1" style="font-weight: bold">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btnInsertItem" runat="server" Text="INSERT ITEM" OnClick="btnInsertItem_Click" />
                </td>
                <td class="style3">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </ol>
</asp:Content>

