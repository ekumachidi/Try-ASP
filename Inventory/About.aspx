<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Your app description page.</h2>
    </hgroup>

    <article>
        <p>        
            Use this area to provide additional information.
        </p>

        <p>        
            Use this area to provide additional information.
        </p>

        <p>        
            Use this area to provide additional information.
        </p>
    </article>

    <aside>
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
    </aside>
</asp:Content>