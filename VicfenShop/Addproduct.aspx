<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Addproduct.aspx.cs" Inherits="Addproduct" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" type="text/css" href="lib/bootstrap/css/bootstrap.css">
    
    <link rel="stylesheet" type="text/css" href="stylesheets/theme2.css">
    <link rel="stylesheet" href="lib/font-awesome/css/font-awesome.css">
    `
    <script src="lib/jquery-1.7.2.min.js" type="text/javascript"></script>

   <style type="text/css">
        #line-chart {
            height:300px;
            width:800px;
            margin: 0px auto;
            margin-top: 1em;
        }
        .brand { font-family: georgia, serif; }
        .brand .first {
            color: #ccc;
            font-style: italic;
        }
        .brand .second {
            color: #fff;
            font-weight: bold;
        }
       </style>
    <style type="text/css">
      label {float:left; width: 100%; text-align: right;
               margin-right: 0.5em;}
      fieldset {padding: 1em; border: 1px solid; width: 50em;}
      legend {padding: 2px 4px; border: 1px solid; font-weight:bold;}
      .validation-summary-errors {font-weight:bold; color:red; font-size: 11pt;}
        .style2
        {
            width: 332px;
            margin-left: 80px;
        }
        .style3
        {            text-align: left;
        }
        .style4
        {
            font-size: small;
        }
   </style>
</head>
<body>
    <br />
  
<form runat="server" id="form1" style=" margin-left:2px; margin-right:2px;">
<fieldset>
           <legend>Add New Product</legend>
    <table align="center" border="0">
        <tr>
            <td align="center" colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="style3">
                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="ProductName">Product Name:</asp:Label></td>
            <td align="left" style="font-weight: bold" class="style2">
                <asp:TextBox ID="ProductName" runat="server" Width="142px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="ProductNameRequired" runat="server" ControlToValidate="ProductName"
                    ErrorMessage="User Name is required." ToolTip="Product Name is required.">* Product Name is required.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="style3">
                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Price">Price:</asp:Label></td>
            <td align="left" class="style2">
                <asp:TextBox ID="Price" runat="server" Width="142px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="PriceRequired" runat="server" ControlToValidate="Price"
                    ErrorMessage="Price is required." ToolTip="Price is required.">* Price is required.</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="style3">
                Manufacturer:</td>
            <td align="left" class="style2">
                <asp:DropDownList ID="ddManufacturer" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" class="style3">
                Category:</td>
            <td align="left" class="style2">
                <asp:DropDownList ID="ddCategory" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr style="font-weight: bold; font-size: 14pt">
            <td align="right" class="style3" colspan="2">
                <span class="style4">Photo</span><br />
                <asp:FileUpload ID="FileUpload1" runat="server" /></td>
        </tr>
        <tr style="font-weight: bold; font-size: 14pt">
            <td align="right" class="style3" colspan="2">
                 <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" 
         Text="Upload Photo" /><br />
                <asp:Label ID="Label1" runat="server" style="font-size: small; text-align: left"></asp:Label>
                 <asp:Label ID="LabelPhoto" runat="server" Text="" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="color: red">
                <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="color: red">
                <asp:Button ID="btnCreateUser" runat="server" Text="Save Product" 
                    onclick="btnCreateUser_Click"  /></td>
        </tr>
    </table>
 </fieldset>
</form>
</body>
</html>
