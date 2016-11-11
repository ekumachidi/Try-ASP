<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateProduct.aspx.cs" Inherits="UpdateProduct" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <link rel="stylesheet" type="text/css" href="lib/bootstrap/css/bootstrap.css">
    
    <link rel="stylesheet" type="text/css" href="stylesheets/theme2.css">
    <link rel="stylesheet" href="lib/font-awesome/css/font-awesome.css">
    `
    <style type="text/css">

form {
  margin: 0 0 20px;
}
      fieldset {padding: 1em; border: 1px solid; width: 50em;}
      fieldset {
  padding: 0;
  margin: 0;
  border: 0;
}
      legend {padding: 2px 4px; border: 1px solid; font-weight:bold;}
      legend {
  display: block;
  width: 100%;
  padding: 0;
  margin-bottom: 20px;
  font-size: 21px;
  line-height: 40px;
  color: #333333;
  border: 0;
  border-bottom: 1px solid #e5e5e5;
}
table {
  max-width: 100%;
  background-color: transparent;
  border-collapse: collapse;
  border-spacing: 0;
            text-align: center;
        }
        .style3
        {
            width: 140px;
        }
      label {float:left; width: 100%; text-align: right;
               margin-right: 0.5em;}
      label {
  display: block;
  margin-bottom: 5px;
}
label,
input,
button,
select,
textarea {
  font-size: 14px;
  font-weight: normal;
  line-height: 20px;
}
        .style2
        {
            width: 332px;
            margin-left: 80px;
        }
        input[type="text"],
input[type="password"] {
  -webkit-border-radius: 0px;
  -moz-border-radius: 0px;
  border-radius: 0px;
  -moz-background-clip: padding;
  -webkit-background-clip: padding-box;
  background-clip: padding-box;
}
textarea,
input[type="text"],
input[type="password"],
input[type="datetime"],
input[type="datetime-local"],
input[type="date"],
input[type="month"],
input[type="time"],
input[type="week"],
input[type="number"],
input[type="email"],
input[type="url"],
input[type="search"],
input[type="tel"],
input[type="color"],
.uneditable-input {
  background-color: #ffffff;
  border: 1px solid #cccccc;
  -webkit-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
  -moz-box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
  box-shadow: inset 0 1px 1px rgba(0, 0, 0, 0.075);
  -webkit-transition: border linear .2s, box-shadow linear .2s;
  -moz-transition: border linear .2s, box-shadow linear .2s;
  -o-transition: border linear .2s, box-shadow linear .2s;
  transition: border linear .2s, box-shadow linear .2s;
}
select,
textarea,
input[type="text"],
input[type="password"],
input[type="datetime"],
input[type="datetime-local"],
input[type="date"],
input[type="month"],
input[type="time"],
input[type="week"],
input[type="number"],
input[type="email"],
input[type="url"],
input[type="search"],
input[type="tel"],
input[type="color"],
.uneditable-input {
  display: inline-block;
  height: 20px;
  padding: 4px 6px;
  margin-bottom: 9px;
  font-size: 14px;
  line-height: 20px;
  color: #555555;
  -webkit-border-radius: 3px;
  -moz-border-radius: 3px;
  border-radius: 3px;
}
  input,
  textarea,
  .uneditable-input {
    margin-left: 0;
  }
  input,
  textarea,
  .uneditable-input {
    margin-left: 0;
  }
  input,
textarea,
.uneditable-input {
  margin-left: 0;
}
input,
textarea,
.uneditable-input {
  width: 206px;
}
input,
button,
select,
textarea {
  font-family: "Helvetica Neue", Helvetica, Arial, sans-serif;
}
button,
input {
  *overflow: visible;
  line-height: normal;
}
button,
input,
select,
textarea {
  margin: 0;
  font-size: 100%;
  vertical-align: middle;
}
select {
  width: 220px;
  border: 1px solid #cccccc;
  background-color: #ffffff;
}
select,
input[type="file"] {
  height: 30px;
  /* In IE7, the height of the select element cannot be changed by height, only font-size */

  *margin-top: 4px;
  /* For IE7, add top margin to align select with labels */

  line-height: 30px;
}
input[type="file"],
input[type="image"],
input[type="submit"],
input[type="reset"],
input[type="button"],
input[type="radio"],
input[type="checkbox"] {
  width: auto;
}
button,
input[type="button"],
input[type="reset"],
input[type="submit"] {
  cursor: pointer;
  -webkit-appearance: button;
}
    </style>
</head>
<body>
      
<form runat="server" id="form1" style=" margin-left:2px; margin-right:2px;">
<fieldset>
           <legend>Update Product</legend>
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
            <td align="right" class="style3">
            </td>
            <td align="left" class="style2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="color: red">
                <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" style="color: red">
                <asp:Button ID="btnUpdateProduct" runat="server" Text="Update" 
                    onclick="btnUpdateProduct_Click"  /></td>
        </tr>
    </table>
 </fieldset>
</form>
      
</body>
</html>
