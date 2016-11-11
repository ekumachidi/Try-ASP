<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="AddCategory.aspx.cs" Inherits="AddCategory" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div>
    <table style="width: 55%;">
        <tr>
            <td style="border-width: thick; border-color: #000000; font-family: Candara; font-size: large; font-weight: bold; text-align: center; border-bottom-style: solid;">
                ADD CATEGORY</td>
        </tr>
    </table>
    <table style="text-align: justify; width: 396px;">
        <tr><td class="style2">&#160;</td><td class="style1">&#160;</td><td>&#160;</td><td>&#160;</td><td>&#160;</td></tr><tr><td class="style2">&nbsp;</td><td class="style1" style="font-weight: bold">CATEGORY:</td><td>

        <asp:TextBox ID="txtCategory" runat="server"></asp:TextBox>
        <tr><td class="style2">&nbsp;</td><td class="style1" style="font-weight: bold">&nbsp;</td><td>

            <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" />

        <tr><td class="style2">&nbsp;</td><td class="style1" style="font-weight: bold">&nbsp;</td><td>

            &nbsp;<tr><td class="style2">&nbsp;</td><td class="style1" style="font-weight: bold">&nbsp;</td><td>

        <asp:GridView ID="grdCategory" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="grdCategoryDataSource">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="S/N" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            </Columns>
        </asp:GridView>
    
    </table>
    </div>
    <div>

    <%--<aside>
        <h3>Menu</h3>
        <p>        
            ********.
        </p>
        <ul>
            <li><a runat="server" href="~/">Home</a></li>
            <li><a runat="server" href="~/About">About</a></li>
            <li><a runat="server" href="~/Contact">Contact</a></li>
            <li><a runat="server" href="AddCategory.aspx">Add New Category</a></li>
            <li><a runat="server" href="#">Add New Condition</a></li>
            <li><a runat="server" href="InsertItem.aspx">Add New Equipment</a></li>
            <li><a runat="server" href="AddLocation.aspx">Add Location</a></li>
            <li><a runat="server" href="AddManufacturer.aspx">Add Manufacturer</a></li>
        </ul>
    </aside>--%>
        <asp:SqlDataSource ID="grdCategoryDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:InventoryConnectionString %>" SelectCommand="SELECT * FROM [Category]"></asp:SqlDataSource>

    </div>
    </asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="HeadContent">
    </asp:Content>

