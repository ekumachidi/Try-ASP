<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AddLocation.aspx.cs" Inherits="AddLocation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
    <table style="width: 55%;">
        <tr>
            <td style="border-width: thick; border-color: #000000; font-family: Candara; font-size: large; font-weight: bold; text-align: center; border-bottom-style: solid;">
                ADD NEW LOCATION</td>
        </tr>
    </table>
    <table style="text-align: justify; width: 396px;">
        <tr><td class="style2">&#160;</td><td class="style1">&#160;</td><td>&#160;</td><td>&#160;</td><td>&#160;</td></tr><tr><td class="style2">&nbsp;</td><td class="style1" style="font-weight: bold">LOCATION:</td><td>

        <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
        <tr><td class="style2">&nbsp;</td><td class="style1" style="font-weight: bold">&nbsp;</td><td>

            <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" />

        <tr><td class="style2">&nbsp;</td><td class="style1" style="font-weight: bold">&nbsp;</td><td>

            <asp:GridView ID="grdLocation" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="LocationDataSource">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="SN" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="LocationDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:InventoryConnectionString %>" SelectCommand="SELECT * FROM [Location]"></asp:SqlDataSource>

    </table>
    </div>
</asp:Content>

