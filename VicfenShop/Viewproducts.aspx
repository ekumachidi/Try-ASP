<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Viewproducts.aspx.cs" Inherits="Viewproducts" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="lib/bootstrap/css/bootstrap.css">
    
    <link rel="stylesheet" type="text/css" href="stylesheets/theme2.css">
    <link rel="stylesheet" href="lib/font-awesome/css/font-awesome.css">
 
    <style type="text/css">
        .style1
        {
            width: 639px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <fieldset>
           <legend>List of Available Products</legend>
    <table align="left" border="0">
        <tr>
            <td align="center" class="style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" style="color: red" class="style1">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:ApplicationServices %>" 
                    SelectCommand="SELECT * FROM [PRODUCTS]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td align="center" style="color: red" class="style1">
                <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="center" style="color: red" class="style1">
                <br />
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                    Width="775px">
                    <Columns>
                        <asp:TemplateField HeaderText="S/N">
                            <EditItemTemplate>
                                <%#(Container.DataItemIndex+1) %>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <%#(Container.DataItemIndex+1) %> 
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="PRODUCT_NAME" HeaderText="PRODUCT" />
                        <asp:BoundField DataField="CATEGORY_NAME" HeaderText="CATEGORY" />
                        <asp:BoundField DataField="PRICE" HeaderText="PRICE" />
                        <asp:BoundField DataField="MANUFACTURER_NAME" HeaderText="MANUFACTURER" />
                        <asp:BoundField DataField="UserName" HeaderText="ADDED BY" />
                          <asp:TemplateField HeaderText="ACTION">
                            <EditItemTemplate>
                                <%#(Container.DataItemIndex+1) %>
                            </EditItemTemplate>
                            <ItemTemplate>
                                 <a href="UpdateProduct.aspx?id=<%#(Container.DataItemIndex+1) %>">Edit</a> | <a href="DeleteProduct.aspx?id=<%#(Container.DataItemIndex+1) %>">Delete</a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
 </fieldset>
    </div>
    </form>
</body>
</html>
