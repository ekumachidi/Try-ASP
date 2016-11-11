<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Attendance.aspx.cs" Inherits="SearchSchMgr.Modules.Attendance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table style="width: 613px; height: 58px;">
        <tr>
            <td align="left" colspan="2" rowspan="2">
                &nbsp;<asp:Label ID="Label2" runat="server" Text="VIEW  CLASS LIST" Font-Bold="True" Font-Size="14pt" Width="428px"></asp:Label></td>
            <td align="left" colspan="1" rowspan="2">
            </td>
            <td align="left" style="width: 725px">
                &nbsp;</td>
            <td style="width: 5px" rowspan="6">
            </td>
        </tr>
        <tr>
            <td align="left" style="width: 122px">
                </td>
            <td align="left" style="width: 725px">
        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label></td>
            <td align="left" style="width: 725px">
                </td>
        </tr>
        <tr>
            <td align="left" style="width: 122px">
                <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Campus" Width="148px" Font-Names="Arial" Font-Size="10pt"></asp:Label></td>
            <td align="left" style="width: 725px">
                <asp:DropDownList ID="ddlCampus" runat="server" AutoPostBack="True"></asp:DropDownList></td>
            <td align="left" style="width: 725px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlCampus"
                    ErrorMessage="Select Campus" InitialValue="Select Campus" ValidationGroup="c">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="left" style="width: 122px">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Class" 
                    Width="84px" Font-Names="Arial" Font-Size="10pt"></asp:Label></td>
            <td align="left" style="width: 725px">
                <asp:DropDownList ID="ddlClass" runat="server">
                </asp:DropDownList></td>
            <td align="left" style="width: 725px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlClass"
                    ErrorMessage="Select Class" InitialValue="Select Class" 
                    ValidationGroup="c">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="left" style="width: 122px">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Session" Width="148px" Font-Names="Arial" Font-Size="10pt"></asp:Label></td>
            <td align="left" style="width: 725px">
                <asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="True">
                </asp:DropDownList></td>
            <td align="left" style="width: 725px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlSession"
                    ErrorMessage="Select Session" InitialValue="Select Session" ValidationGroup="c">*</asp:RequiredFieldValidator></td>
        </tr>        
        <tr>
            <td style="width: 122px">
            </td>
            <td align="left" style="width: 725px">
                <asp:Button ID="btnView" runat="server" Text="View"
                    Width="147px" ValidationGroup="c" OnClick="btnView_Click" />&nbsp;
            </td>
            <td align="left" style="width: 725px">
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
