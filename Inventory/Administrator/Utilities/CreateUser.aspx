<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateUser.aspx.cs" Inherits="micModules_Utilities_CreateUser" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div>
        <div style=" width: 544px; font-family: candara; font-size: small;">
                        <table style="width: 100%;">
                            <tr>
                                <td style="border-width: thick; border-color: #000000; font-family: Candara; font-size: large; font-weight: bold; text-align: center; border-bottom-style: solid;">
                                    CREATE USER ACCOUNT</td>
                            </tr>
                        </table>

                    </div><br />
        <div>
            
        
                                <table style="width: 31%; height: 162px;" align="center">
                                    <tr>
                                        <td align="center" class="style4" colspan="2" 
                                            
                                            
                                            style="font-weight: bold; font-size: small; background-color: #CC6600; color: #FFFFFF;">
                                            CREATE USER ACCOUNT</td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="style4" style="border-style: solid; border-width: 1px;">
                                            UserName:</td>
                                        <td align="justify" class="style5" 
                                            style="border-style: solid; border-width: 1px">
                                            <asp:TextBox ID="txtbxUsername" runat="server" 
                                                Width="141px"></asp:TextBox>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                ControlToValidate="txtbxUsername" ErrorMessage="Please Enter Username" 
                                                ValidationGroup="a">*</asp:RequiredFieldValidator>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="style4" style="border-style: solid; border-width: 1px;">
                                            Password:</td>
                                        <td align="justify" class="style8" 
                                            style="border-style: solid; border-width: 1px">
                                            <asp:TextBox ID="txtbxPassword" runat="server" 
                                                Width="141px" TextMode="Password"></asp:TextBox>

                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                                ControlToValidate="txtbxPassword" ErrorMessage="Please Enter Password" 
                                                ValidationGroup="a">*</asp:RequiredFieldValidator>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="style4" style="border-style: solid; border-width: 1px;">
                                            Confirm Password:</td>
                                        <td align="justify" class="style8" 
                                            style="border-style: solid; border-width: 1px">
                                            <asp:TextBox ID="txtbxPasswordC" runat="server" 
                                                Width="141px" TextMode="Password"></asp:TextBox>

                                            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                                ControlToCompare="txtbxPassword" ControlToValidate="txtbxPasswordC" 
                                                ErrorMessage="Passoword mismatch" ValidationGroup="a">*</asp:CompareValidator>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="style4" style="border-style: solid; border-width: 1px;">
                                            Select Campus:</td>
                                        <td align="justify" class="style8" 
                                            style="border-style: solid; border-width: 1px">
                            <asp:DropDownList ID="ddlCampus" runat="server" Font-Names="Arial"
                                Font-Size="8pt" ForeColor="Black" Width="146px">
                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                                                ControlToValidate="ddlCampus" ErrorMessage="Please Select campus" 
                                                InitialValue="Select Campus" ValidationGroup="a">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="style4" style="border-style: solid; border-width: 1px;">
                                            Select Role to Assign:</td>
                                        <td align="justify" class="style8" 
                                            style="border-style: solid; border-width: 1px">
                            <asp:DropDownList ID="ddlRole" runat="server" Font-Names="Arial"
                                Font-Size="8pt" ForeColor="Black" Width="146px">
                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                                                ControlToValidate="ddlRole" ErrorMessage="Please Select role" 
                                                InitialValue="Select Role" ValidationGroup="a">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" class="style4" style="font-weight: bold">
                                            &nbsp;</td>
                                        <td align="justify" class="style19">
                                            <asp:Button ID="btnCreate" runat="server" Text="Create Account" 
                                                ValidationGroup="a" onclick="btnCreate_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" class="style4" style="font-weight: bold" colspan="2">
                           <telerik:RadNotification ID="RadNotification1" runat="server" Skin="Sunset" 
                            EnableRoundedCorners="True" ShowTitleMenu="True" 
                            Title="Progress Notification!" Position="Center" 
                            Width="306px" Height="150px">
                            <ContentTemplate>
                                <div align="center" style="width: 263px">
                                    <img alt="" src="../../images/Notification.png" style="height: 42px; width: 46px" />
                                    <asp:Label ID="lblNotif" runat="server" Font-Bold="True"></asp:Label>
                                </div>
                            </ContentTemplate>
                            <NotificationMenu ID="TitleMenu">
                            </NotificationMenu>
                        </telerik:RadNotification>
                                        </td>
                                    </tr>
                                </table>
                                
                                
        </div>
          
        
        <div>
                <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Names="Courier New"
                            Font-Size="9pt" ForeColor="Red" Height="0px" Width="677px"></asp:Label>
        </div>
        <div>
                <asp:Label ID="lblStatus" runat="server" Font-Bold="True" Font-Names="Courier New"
                            Font-Size="9pt" ForeColor="Red" Height="0px" Width="677px"></asp:Label>
        </div>
        <p>
        
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                ShowMessageBox="True" ShowSummary="False" ValidationGroup="a" />
    
    </div>
    </center>
    </form>
</body>
</html>
