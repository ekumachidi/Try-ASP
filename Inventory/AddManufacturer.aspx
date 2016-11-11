<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddManufacturer.aspx.cs" Inherits="AddManufacturer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
    <table style="width: 55%;">
        <tr>
            <td style="border-width: thick; border-color: #000000; font-family: Candara; font-size: large; font-weight: bold; text-align: center; border-bottom-style: solid;">
                ADD MANUFACTURER</td>
        </tr>
    </table>
    <table style="text-align: justify; width: 396px;">
        <tr><td class="style2">&#160;</td><td class="style1">&#160;</td><td>&#160;</td><td>&#160;</td><td>&#160;</td></tr><tr><td class="style2">&nbsp;</td><td class="style1" style="font-weight: bold">MANUFACTURER:</td><td>

        <asp:TextBox ID="txtManufacturer" runat="server"></asp:TextBox>
        <tr><td class="style2">&nbsp;</td><td class="style1" style="font-weight: bold">&nbsp;</td><td>

            <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" />

        <tr><td class="style2">&nbsp;</td><td class="style1" style="font-weight: bold">&nbsp;</td><td>

            &nbsp;<tr><td class="style2">&nbsp;</td><td class="style1" style="font-weight: bold">&nbsp;</td><td>

            <asp:GridView ID="grdManufacturer" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="ManufacturerDataSource">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="NAME" HeaderText="NAME" SortExpression="NAME" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="ManufacturerDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:InventoryConnectionString %>" SelectCommand="SELECT * FROM [Manufacturer]"></asp:SqlDataSource>

    </table>
    </div>
</asp:Content>

